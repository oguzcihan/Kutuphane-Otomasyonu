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
    public partial class Anasayfa : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        public Anasayfa()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            
            lblkadi.Text = Giris.kullaniciAdi;
            lblgorev.Text = Giris.gorev;

            if (lblgorev.Text == "PERSONEL")
            {
                üyeİşlemleriToolStripMenuItem.Visible = false;
                kitapSilToolStripMenuItem.Visible = false;
                yedekleToolStripMenuItem.Visible = false;
                btnperKayit.Visible = false;
            }
        }

        private void kitapKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kitap = new kitapKayit();
            kitap.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form kitap = new kitapKayit();
            kitap.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltarihsaat.Text= DateTime.Now.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form personel = new PersonelKayıt();
            personel.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form emanet = new emanetForm();
            emanet.ShowDialog();
        }

        private void Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
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

            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
