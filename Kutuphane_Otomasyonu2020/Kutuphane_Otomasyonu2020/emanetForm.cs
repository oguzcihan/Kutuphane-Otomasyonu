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
    public partial class emanetForm : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        public emanetForm()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
            Emanet emanet = new Emanet();
            emanet.DataGridDoldur(dgvTablo, "SELECT uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
            emanet.ComboBoxDoldur(cbKAd, "SELECT * FROM Kitaplar", "Kitaplar", "kitapAdi");
            emanet.ComboBoxDoldur(cbKYazar, "SELECT * FROM Kitaplar", "Kitaplar", "yazar");
            emanet.ComboBoxDoldur(cbKYEvi, "SELECT * FROM Kitaplar", "Kitaplar", "yayınEvi");
        }

        private void emanetForm_Load(object sender, EventArgs e)
        {
            lblMAd.Text = "Ad: ";
            lblMSad.Text = "Soyad: ";
            lblMTel.Text = "Telefon No: ";
            lblMPosta.Text = "E-posta: ";
            lblMAdres.Text = "Adres: ";
            lblKAd.Text = "Kitap Adı: ";
            lblKYazar.Text = "Kitap Yazarı:";
            lblKYEvi.Text = "Yayınevi: ";
            lblGTarih.Text = "Geri Alınacağı Tarih: ";
            btnAra.Text = "Kitap Ara ";
            btnKaydet.Text = "KAYDET";
            btnDuzenle.Text = "DUZENLE";
            btnSil.Text = "SIL";

            /*
            dataGridView1.Columns[0].HeaderText = "Kitap No";
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Baskı Yılı";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].HeaderText = "Yayın Evi";
            dataGridView1.Columns[6].HeaderText = "Notlar";*/
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(tbMAd.Text == "")
            {
                MessageBox.Show("Lütfen Ad Giriniz.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Form sil = new emanetSil();
            sil.ShowDialog();
        }
    }
}
