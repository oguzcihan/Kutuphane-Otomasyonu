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
    public partial class teslimEdilenForm : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public teslimEdilenForm()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void teslimEdilenForm_Load(object sender, EventArgs e)
        {
            liste();
            cbaramaT.SelectedIndex = 0;

        }
        public void liste()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            try
            {
                baglanti.Open();
                string sorgu = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE teslimEdildi='Evet' ";
                SqlCommand komut2 = new SqlCommand(sorgu, baglanti);
                da = new SqlDataAdapter(komut2);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                komut2.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            birimler();
        }
        public void birimler()
        {
            string emnaetIdS = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE teslimEdildi='Evet' AND emanetId like '";
            string uyeAS = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE teslimEdildi='Evet' AND uyeAdi like '";
            string KitapAS = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE teslimEdildi='Evet' AND kitapAdi like '";

            try
            {
                if (cbaramaT.Text == "Emanet No")
                {
                    liste();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(emnaetIdS +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();


                }
                else if (cbaramaT.Text == "Üye Ad")
                {
                    liste();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(uyeAS +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                else if (cbaramaT.Text == "Kitap Adı")
                {
                    liste();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(KitapAS +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbaramaT.Text == "-- Seçiniz --")
            {
                txtAra.Text = "";
                MessageBox.Show("Lütfen Arama Türü Seçiniz.");
                txtAra.Text = "";
            }
            else if (cbaramaT.Text == "Emanet No")
            {
                txtAra.Text = "";
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            else if (cbaramaT.Text == "Üye Ad")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }
            else if (cbaramaT.Text == "Kitap Adı")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }
        }

       
    }
}
