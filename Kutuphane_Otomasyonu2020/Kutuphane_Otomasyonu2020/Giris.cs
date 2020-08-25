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
    public partial class Giris : Form
    {
        Connect con = new Connect();
        SqlConnection baglanti;
        public Giris()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip ac = new ToolTip();
            ac.SetToolTip(btnsifregoster, "Şifre Göster");
        }
        public Boolean sayac;
        private void btnsifregoster_Click(object sender, EventArgs e)
        {
            if (sayac == true)
            {
                txtsifre.PasswordChar = '\0';
                sayac = false;
            }
            else
            {
                txtsifre.PasswordChar = '*';
                sayac = true;
            }
        }
        public static string kullaniciAdi;
        public static string gorev;
        public void login()
        {
            //kayıt 
            try
            {
                if (txtkullaniciAdi.Text == "" && txtsifre.Text == "") { MessageBox.Show("Giriş yapmak için tüm boşlukları doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("select* from Personel where perKullaniciadi=@ad", baglanti);
                    komut.Parameters.AddWithValue("@ad", txtkullaniciAdi.Text);
                    SqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        if (oku["perKullaniciadi"].ToString() == txtkullaniciAdi.Text && oku["sifre"].ToString() == txtsifre.Text && oku["gorevi"].ToString() == "YÖNETİCİ")
                        {

                            kullaniciAdi = txtkullaniciAdi.Text;
                            gorev = lblgorev.Text;
                            this.Hide();

                            Form frm1 = new Anasayfa();
                            frm1.Show();
                            break;


                        }
                        else if (oku["perKullaniciadi"].ToString() == txtkullaniciAdi.Text && oku["sifre"].ToString() == txtsifre.Text && oku["gorevi"].ToString() == "PERSONEL")
                        {


                            kullaniciAdi = txtkullaniciAdi.Text;
                            gorev = lblgorev.Text;
                            this.Hide();
                            Form frm1 = new Anasayfa();
                            frm1.Show();

                            break;

                        }
                        else { MessageBox.Show("Giriş bilgilerinizi kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

                    }

                    baglanti.Close();
                }
            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "EROR", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void txtkullaniciAdi_TextChanged(object sender, EventArgs e)
        {
            if (txtkullaniciAdi.Text == "")
            {
                txtsifre.Clear();

                
            }
            try
            {
                baglanti.Open();
                SqlCommand k = new SqlCommand("select*from Personel where perKullaniciAdi=@ad", baglanti);
                k.Parameters.AddWithValue("@ad", txtkullaniciAdi.Text);
                SqlDataReader oku = k.ExecuteReader();
                while (oku.Read())
                {

                    lblgorev.Text = oku["gorevi"].ToString();

                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void txtsifre_TextChanged(object sender, EventArgs e)
        {
            txtsifre.PasswordChar = '*';
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //x tuşu kapatır.
                DialogResult g = MessageBox.Show("Uygulamayı kapatmak istiyor musunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (g == DialogResult.No)
                {
                    e.Cancel = true;
                    return;

                }
                Environment.Exit(-1);
            }catch(Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }
    }
}
