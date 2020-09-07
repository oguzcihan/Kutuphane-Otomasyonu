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
    public partial class kitapListesi : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        SqlDataAdapter da;
        DataTable dt;
        public kitapListesi()
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
                SqlCommand com = new SqlCommand("select*from Kitaplar", baglanti);
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

        private void kitapListesi_Load(object sender, EventArgs e)
        {
            listele();
            comboBox1.SelectedIndex = 0;
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            aramakriteri();
        }

        public void aramakriteri()
        {
            try
            {
                if (comboBox1.Text == "Kitap Adı")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Kitaplar where kitapAdi like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();

                }
                else if (comboBox1.Text == "Yazar")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Kitaplar where yazar like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                else if (comboBox1.Text == "Baskı Yılı")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Kitaplar where baskiYili like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                else if (comboBox1.Text == "Yayın Evi")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Kitaplar where yayınEvi like '" +
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
