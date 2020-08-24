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
    }
}
