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
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtUyeId.Text == "" || txtKitapId.Text == "")
            {
                MessageBox.Show("Kitap No ve Üye No Boş Bırakılamaz!");
            }
            else
            {
                string tarih = "a";
                EmanetEkleClass ekle = new EmanetEkleClass();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("@uyeNo", txtUyeId.Text.ToString());
                dic.Add("@kitapId", txtKitapId.Text.ToString());
                dic.Add("@eTarih", tarih.ToString());
                dic.Add("@gTarih", tarih.ToString());
                dic.Add("@iTarih", tarih.ToString());
                dic.Add("@notlar", tarih.ToString());
                dic.Add("@tEdildi", tarih.ToString());
                ekle.insert("INSERT INTO OduncKitap (uyeNo, kitapId, emanetTarihi, gerialınacakTarih, islemTarihi, notlar, teslimEdildi) VALUES(@uyeNo, @kitapId, @eTarih, @gTarih, @iTarih, @notlar, @tEdildi)", dic);
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

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Form sil = new emanetSil();
            sil.ShowDialog();
        }


       

        private void btnUyeAra_Click(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            Form KAra = new kitapAra();
            KAra.ShowDialog();
        }
    }
}
