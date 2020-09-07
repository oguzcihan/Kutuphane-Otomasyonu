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
    public partial class uyeListesi : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        SqlDataAdapter da;
        DataTable dt;
        public uyeListesi()
        {
            baglanti = new SqlConnection(con.adres);
            dt = new DataTable();
            InitializeComponent();
        }

        public void listele()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            try
            {
                baglanti.Open();
                SqlCommand com = new SqlCommand("select*from Uyeler", baglanti);
                da = new SqlDataAdapter(com);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                com.Dispose();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void uyeListesi_Load(object sender, EventArgs e)
        {
            listele();
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            aramakriteri();
        }

        public void aramakriteri()
        {
            try
            {
                if (comboBox1.Text == "Ad")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Uyeler where uyeAdi like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();

                }
                else if (comboBox1.Text == "Soyad")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Uyeler where uyeSoyad like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                else if (comboBox1.Text == "Telefon Numarası")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Uyeler where uyeTel like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                else if (comboBox1.Text == "E-Posta")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Uyeler where uyePosta like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
    }
}
