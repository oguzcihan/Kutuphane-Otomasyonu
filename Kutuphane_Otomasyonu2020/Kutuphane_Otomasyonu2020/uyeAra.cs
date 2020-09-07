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
    public partial class uyeAra : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        SqlDataAdapter da;
        DataTable dt;
        public uyeAra()
        {
            baglanti = new SqlConnection(con.adres);
            dt = new DataTable();
            InitializeComponent();
        }

        private void uyeAra_Load(object sender, EventArgs e)
        {
            listele();
            comboBox1.SelectedIndex = 0;
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
        public event kitapSecildiHandle uyeSecildi;
        public string SecilenUye { get; set; }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //interface
            SecilenUye = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            uyeSecildi?.Invoke();
            this.Hide();
        }
        public void birimler()
        {
            try
            {
                if (comboBox1.Text == "Üye No")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Uyeler where uyeNo like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();

                }
                else if (comboBox1.Text == "Üye Adı")
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
                else if (comboBox1.Text == "Üye Adresi")
                {
                    listele();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter("select*from Uyeler where uyeAdres like '" +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
           
          
          
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            birimler();
        }
        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text == "-- Seçiniz --")
            {
                txtAra.Text = "";
                MessageBox.Show("Lütfen Arama Türü Seçiniz.");
                txtAra.Text = "";
            }
            else if (comboBox1.Text == "Üye No")
            {
                txtAra.Text = "";
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            else if (comboBox1.Text == "Üye Adı")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }
            else if (comboBox1.Text == "Üye Adresi")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }

        }
    }
}
