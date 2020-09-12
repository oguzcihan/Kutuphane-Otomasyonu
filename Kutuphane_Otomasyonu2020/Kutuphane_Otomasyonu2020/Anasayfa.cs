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
               
                personelİşlemleriToolStripMenuItem.Visible = false;
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
            lbltarihsaat.Text = DateTime.Now.ToString();
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
                Environment.Exit(0);

            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form uye = new Uyeekle();
            uye.ShowDialog();
        }

        private void tarihiGeçenKitaplarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ödüçKitapVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form emanet = new emanetForm();
            emanet.ShowDialog();
        }

        private void ödünçKitapListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form teslim = new emanetListe();
            teslim.ShowDialog();
        }

        private void üyeListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new uyeListesi();
            frm.ShowDialog();
        }

        private void kitapListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new kitapListesi();
            frm.ShowDialog();
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this,"help.chm");
            Form frm = new yardim();
            frm.ShowDialog();
        }

        private void personelListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new personelListesi();
            frm.ShowDialog();
        }

        private void teslimEdildiListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form teslim = new teslimEdilenForm();
            teslim.ShowDialog();
        }

        private void kullanıcıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Anasayfa kapat = new Anasayfa();
            kapat.Close();
            Giris frm1 = new Giris();
            frm1.Show();
            this.Hide();
        }

        private void güvenliÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void yedekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "(*.BAK) | *.BAK|(*.rar)|*.rar";
                save.FilterIndex = 0;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string sql = string.Format(@"BACKUP database Kutuphane to disk='{0}'", save.FileName);
                    SqlCommand cmd = new SqlCommand(sql, baglanti);
                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Yedeklendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void yardımToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form help = new yardim();
            help.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            emanetListe ac = new emanetListe();
            ac.ShowDialog();
        }
    }
}
