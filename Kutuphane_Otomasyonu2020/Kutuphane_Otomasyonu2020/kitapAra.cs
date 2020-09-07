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
    public partial class kitapAra : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        SqlDataAdapter da;
        DataTable dt;
        public kitapAra()
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
        private void kitapAra_Load(object sender, EventArgs e)
        {
            listele();
            comboBox1.SelectedIndex = 0;
        }

        public event kitapSecildiHandle kitapSecildi;
        public string SecilenKitap { get; set; }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //interface
            SecilenKitap = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            kitapSecildi?.Invoke();
            this.Hide();

        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            birimler();
        }
        public void birimler()
        {
            try
            {
                if (comboBox1.Text == "Kitap No")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Kitaplar where kitapId like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();

                }
                else if (comboBox1.Text == "Kitap Adı")
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
                else if (comboBox1.Text == "Yayınevi")
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

        }
        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "-- Seçiniz --")
            {
                txtAra.Text = "";
                MessageBox.Show("Lütfen Arama Türü Seçiniz.");
                txtAra.Text = "";
            }
            else if (comboBox1.Text == "Kitap No")
            {
                txtAra.Text = "";
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            else if (comboBox1.Text == "Kitap Adı")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }
            else if (comboBox1.Text == "Yazar")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }
            else if (comboBox1.Text == "Yayınevi")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }
            else if (comboBox1.Text == "Baskı Yılı")
            {
                txtAra.Text = "";
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
