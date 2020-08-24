using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu2020
{
    public partial class KitapSil : Form
    {
        Connect con = new Connect();
        SqlConnection baglanti;
        
        public KitapSil()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataTable dt = new DataTable();

        private void KitapSil_Load(object sender, EventArgs e)
        {
            Isimler name = new Isimler();
            listele();
            dataGridView1.Columns[0].HeaderText = name.kitapId;
            dataGridView1.Columns[1].HeaderText = name.kitapAdi;
            dataGridView1.Columns[2].HeaderText = name.yazar;
            dataGridView1.Columns[3].HeaderText = name.baski;
            dataGridView1.Columns[4].HeaderText = name.sayfa;
            dataGridView1.Columns[5].HeaderText = name.yayin;
            dataGridView1.Columns[6].HeaderText = name.not;

        }

        public void delete(int no)
        {
            try
            {

                DialogResult d;
                d = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand ole = new SqlCommand("delete from Kitaplar where kitapId=@no", baglanti);
                    ole.Parameters.AddWithValue("@no", no);
                    ole.ExecuteNonQuery();
                    ole.Dispose();
                    baglanti.Close();
                   
                }

            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int no = Convert.ToInt32(drow.Cells[0].Value);
                delete(no);
            }
            listele();
        }
        public void listele()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            try
            {
                baglanti.Open();
                string sorgu = "select*from Kitaplar";
                SqlCommand komut2 = new SqlCommand(sorgu, baglanti);
                da = new SqlDataAdapter(komut2);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                komut2.Dispose();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //arama butonu
            try
            {
                baglanti.Open();
                dt.Clear();
                SqlDataAdapter adap = new SqlDataAdapter("select*from Kitaplar where kitapAdi like'" + textBox7.Text + "%'", baglanti);
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
    }
}
