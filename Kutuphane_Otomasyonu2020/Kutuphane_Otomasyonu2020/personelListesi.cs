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
    public partial class personelListesi : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        SqlDataAdapter da;
        DataTable dt;
        public personelListesi()
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
                SqlCommand com = new SqlCommand("select*from Personel", baglanti);
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

        private void personelListesi_Load(object sender, EventArgs e)
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
                if (comboBox1.Text == "Ad")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Personel where perAdi like '" +
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
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Personel where perSoyad like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                else if (comboBox1.Text == "Kullanıcı Adı")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Personel where perKullaniciAdi like '" +
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
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Personel where eposta like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                else if (comboBox1.Text == "Görev")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Personel where gorevi like '" +
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
