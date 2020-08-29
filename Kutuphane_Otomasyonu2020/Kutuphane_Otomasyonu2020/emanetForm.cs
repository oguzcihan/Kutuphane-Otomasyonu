using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu2020
{
    public partial class emanetForm : Form
    {
       
        
        private void dgvTablo_SelectionChanged(object sender, EventArgs e)
        {
           
        }
        

        private void dgvTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMusteriGetir_Click(object sender, EventArgs e)
        {
            Emanet getir = new Emanet();
            getir.DataGridDoldur(dgvTablo, "SELECT uyeNo, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres FROM Uyeler", "Uyeler");
            dgvTablo.Columns[0].HeaderText = "Uye No";
            dgvTablo.Columns[1].HeaderText = "Ad";
            dgvTablo.Columns[2].HeaderText = "Soyad";
            dgvTablo.Columns[3].HeaderText = "Telefon No:";
            dgvTablo.Columns[4].HeaderText = "E-Posta";
            dgvTablo.Columns[5].HeaderText = "Adres";
            btnMusteriSec.Visible = true;

        }

        SqlConnection baglanti;
        Connect con = new Connect();
        public emanetForm()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
            Emanet emanet = new Emanet();
            emanet.DataGridDoldur(dgvTablo, "SELECT uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
        }

        private void emanetForm_Load(object sender, EventArgs e)
        {
            
            btnAra.Text = "Kitap Ara ";
            btnKaydet.Text = "KAYDET";
            btnSil.Text = "SIL";
            btnMusteriGetir.Text = "Uyeleri Getir";
            btnKitapGetir.Text = "Kitapları Getir";
            btnMusteriSec.Text = "Musteri Sec";
            btnKitapSec.Text = "Kitap Sec";

            
            dgvTablo.Columns[0].HeaderText = "Ad";
            dgvTablo.Columns[1].HeaderText = "Soyad";
            dgvTablo.Columns[2].HeaderText = "Telefon No:";
            dgvTablo.Columns[3].HeaderText = "E-Posta";
            dgvTablo.Columns[4].HeaderText = "Adres";
            dgvTablo.Columns[5].HeaderText = "Kitap Adı";
            dgvTablo.Columns[6].HeaderText = "Yazar";
            dgvTablo.Columns[7].HeaderText = "Yayınevi";
            dgvTablo.Columns[8].HeaderText = "Emanet Verildiği Tarih";
            dgvTablo.Columns[9].HeaderText = "Geri Alınacağı Tarih";

            lblMAd.Visible = false;
            lblMSad.Visible = false;
            lblMTel.Visible = false;
            lblMPosta.Visible = false;
            lblKAd.Visible = false;
            lblKYazar.Visible = false;
            lblKYEvi.Visible = false;
            uyeId.Visible = false;
            kitapId.Visible = false;
            btnKaydet.Visible = false;
            btnKitapGetir.Visible = false;
            btnKitapSec.Visible = false;
            btnMusteriSec.Visible = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string tarih = "a";
            EmanetEkleClass ekle = new EmanetEkleClass();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@uyeNo", uyeId.Text.ToString());
            dic.Add("@kitapId", kitapId.Text.ToString());
            dic.Add("@eTarih", tarih.ToString());
            dic.Add("@gTarih", tarih.ToString());
            dic.Add("@iTarih", tarih.ToString());
            dic.Add("@notlar", tarih.ToString());
            dic.Add("@tEdildi", tarih.ToString());
            ekle.insert("INSERT INTO OduncKitap (uyeNo, kitapId, emanetTarihi, gerialınacakTarih, islemTarihi, notlar, teslimEdildi) VALUES(@uyeNo, @kitapId, @eTarih, @gTarih, @iTarih, @notlar, @tEdildi)",dic);
            ekle.DataGridDoldur(dgvTablo, "SELECT uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
            dgvTablo.Columns[0].HeaderText = "Ad";
            dgvTablo.Columns[1].HeaderText = "Soyad";
            dgvTablo.Columns[2].HeaderText = "Telefon No:";
            dgvTablo.Columns[3].HeaderText = "E-Posta";
            dgvTablo.Columns[4].HeaderText = "Adres";
            dgvTablo.Columns[5].HeaderText = "Kitap Adı";
            dgvTablo.Columns[6].HeaderText = "Yazar";
            dgvTablo.Columns[7].HeaderText = "Yayınevi";
            dgvTablo.Columns[8].HeaderText = "Emanet Verildiği Tarih";
            dgvTablo.Columns[9].HeaderText = "Geri Alınacağı Tarih";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Form sil = new emanetSil();
            sil.ShowDialog();
        }

        private void btnKitapGetir_Click(object sender, EventArgs e)
        {
            Emanet kgetir = new Emanet();
            kgetir.DataGridDoldur(dgvTablo, "SELECT kitapId, kitapAdi, yazar, baskiYili, sayfaSayisi, yayınEvi FROM Kitaplar","Kitaplar");
            dgvTablo.Columns[0].HeaderText="Kitap Numara";
            dgvTablo.Columns[1].HeaderText = "Kitap Adi";
            dgvTablo.Columns[2].HeaderText = "Yazar";
            dgvTablo.Columns[3].HeaderText = "Baskı Yılı";
            dgvTablo.Columns[4].HeaderText = "Sayfa Sayısı";
            dgvTablo.Columns[5].HeaderText = "Yayın Evi";
            btnKitapSec.Visible = true;
            btnMusteriSec.Visible = false;
            btnMusteriGetir.Visible = false;

        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            lblMAd.Visible = true;
            lblMSad.Visible = true;
            lblMTel.Visible = true;
            lblMPosta.Visible = true;
            uyeId.Text = dgvTablo.CurrentRow.Cells[0].Value.ToString();
            lblMAd.Text = dgvTablo.CurrentRow.Cells[1].Value.ToString();
            lblMSad.Text = dgvTablo.CurrentRow.Cells[2].Value.ToString();
            lblMTel.Text = dgvTablo.CurrentRow.Cells[3].Value.ToString();
            lblMPosta.Text = dgvTablo.CurrentRow.Cells[4].Value.ToString();
            btnKitapGetir.Visible = true;
        }

        private void btnKitapSec_Click(object sender, EventArgs e)
        {
            lblKAd.Visible = true;
            lblKYazar.Visible = true;
            lblKYEvi.Visible = true;
            kitapId.Text = dgvTablo.CurrentRow.Cells[0].Value.ToString();
            lblKAd.Text = dgvTablo.CurrentRow.Cells[1].Value.ToString();
            lblKYazar.Text = dgvTablo.CurrentRow.Cells[2].Value.ToString();
            lblKYEvi.Text = dgvTablo.CurrentRow.Cells[5].Value.ToString();
            btnKaydet.Visible = true;
        }
    }
}
