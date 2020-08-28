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
        string uyeA, uyeS, uyeT, uyeP, kitapA, yazar, yayinE;
        string gerialma = "2gun";
        string emanetTarih = "bugun";
        string islem = "bugun";
        string not = "a";
        string teslim = "h";
        private void cbKAd_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbMSad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbMTel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cbMPosta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cbKYazar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbKYEvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbMad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        private void dgvTablo_SelectionChanged(object sender, EventArgs e)
        {
            uyeA = dgvTablo.CurrentRow.Cells[0].Value.ToString();
            uyeS = dgvTablo.CurrentRow.Cells[1].Value.ToString();
            uyeT = dgvTablo.CurrentRow.Cells[2].Value.ToString();
            uyeP = dgvTablo.CurrentRow.Cells[3].Value.ToString();
            kitapA = dgvTablo.CurrentRow.Cells[5].Value.ToString();
            yazar = dgvTablo.CurrentRow.Cells[6].Value.ToString();
            yayinE = dgvTablo.CurrentRow.Cells[7].Value.ToString();
            cbMad.Text = dgvTablo.CurrentRow.Cells[0].Value.ToString();
            cbMSad.Text = dgvTablo.CurrentRow.Cells[1].Value.ToString();
            cbMTel.Text = dgvTablo.CurrentRow.Cells[2].Value.ToString();
            cbMPosta.Text = dgvTablo.CurrentRow.Cells[3].Value.ToString();
            cbKAd.Text = dgvTablo.CurrentRow.Cells[5].Value.ToString();
            cbKYazar.Text = dgvTablo.CurrentRow.Cells[6].Value.ToString();
            cbKYEvi.Text = dgvTablo.CurrentRow.Cells[7].Value.ToString();
        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            EmanetDuzenleClass duzenle = new EmanetDuzenleClass();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("@uyeAdi", uyeA);
            dic.Add("@uyeSoyad", uyeS);
            dic.Add("@uyeTel", uyeT);
            dic.Add("@uyePosta", uyeP);
            int uyeId = duzenle.idbul("SELECT uyeNo FROM Uyeler WHERE uyeAdi = @uyeAdi AND uyeSoyad = @uyeSoyad AND uyeTel = @uyeTel AND uyePosta = @uyePosta", dic);
            dic.Clear();
            dic.Add("@kitapAdi", kitapA);
            dic.Add("@yazar", yazar);
            dic.Add("@yayınEvi", yayinE);
            int kitapId = duzenle.idbul("SELECT kitapId FROM Kitaplar WHERE kitapAdi = @kitapAdi AND yazar = @yazar AND yayınEvi = @yayınEvi ", dic);
            dic.Clear();
            dic.Add("@uyeNo", uyeId.ToString());
            dic.Add("@kitapId", kitapId.ToString());
            int emanetId = duzenle.idbul("SELECT emanetId FROM OduncKitap WHERE uyeNo=@uyeNo AND kitapId = @kitapId ", dic);
            dic.Clear();
            dic.Add("@uyeAdi", cbMad.Text);
            dic.Add("@uyeSoyad", cbMSad.Text);
            dic.Add("@uyeTel", cbMTel.Text);
            dic.Add("@uyePosta", cbMPosta.Text);
            int uyeId2 = duzenle.idbul("SELECT uyeNo FROM Uyeler WHERE uyeAdi = @uyeAdi AND uyeSoyad = @uyeSoyad AND uyeTel = @uyeTel AND uyePosta = @uyePosta", dic);
            dic.Clear();
            dic.Add("@kitapAdi", cbKAd.Text);
            dic.Add("@yazar", cbKYazar.Text);
            dic.Add("@yayınEvi", cbKYEvi.Text);
            int kitapId2 = duzenle.idbul("SELECT kitapId FROM Kitaplar WHERE kitapAdi = @kitapAdi AND yazar = @yazar AND yayınEvi = @yayınEvi ", dic);
            dic.Clear();
            dic.Add("@emanetID", emanetId.ToString());
            dic.Add("@uyeNo", uyeId2.ToString());
            dic.Add("@kitapId", kitapId2.ToString());
            dic.Add("@emanetT", emanetTarih.ToString());
            dic.Add("@gerialmaT", gerialma.ToString());
            dic.Add("@notlar", not.ToString());
            dic.Add("@teslimE", teslim.ToString());
            duzenle.update("UPTADE OduncKitap (uyeNo, kitapId, emanetTarihi, gerialınacakTarih, islemTarihi, notlar, teslimEdildi) VALUES(@uyeNo, @kitapId, @emanetTarihi, @gerialma, @islem, @notlar, @teslim)", dic);
            duzenle.DataGridDoldur(dgvTablo, "SELECT uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");

        }

        private void dgvTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

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
            emanet.ComboBoxDoldur(cbMad, "SELECT * FROM Uyeler", "Uyeler", "uyeAdi");
            emanet.ComboBoxDoldur(cbMSad, "SELECT * FROM Uyeler", "Uyeler", "uyeSoyad");
            emanet.ComboBoxDoldur(cbMTel, "SELECT * FROM Uyeler", "Uyeler", "uyeTel");
            emanet.ComboBoxDoldur(cbMPosta, "SELECT * FROM Uyeler", "Uyeler", "uyePosta");
        }

        private void emanetForm_Load(object sender, EventArgs e)
        {
            lblMAd.Text = "Ad: ";
            lblMSad.Text = "Soyad: ";
            lblMTel.Text = "Telefon No: ";
            lblMPosta.Text = "E-posta: ";
            lblKAd.Text = "Kitap Adı: ";
            lblKYazar.Text = "Kitap Yazarı:";
            lblKYEvi.Text = "Yayınevi: ";
            lblGTarih.Text = "Geri Alınacağı Tarih: ";
            btnAra.Text = "Kitap Ara ";
            btnKaydet.Text = "KAYDET";
            btnDuzenle.Text = "DUZENLE";
            btnSil.Text = "SIL";

            
            dgvTablo.Columns[0].HeaderText = "Ad";
            dgvTablo.Columns[1].HeaderText = "Soyad";
            dgvTablo.Columns[2].HeaderText = "Telefon No:";
            dgvTablo.Columns[3].HeaderText = "E-Posta";
            dgvTablo.Columns[4].HeaderText = "Adres";
            dgvTablo.Columns[5].HeaderText = "Kitap Adı";
            dgvTablo.Columns[6].HeaderText = "Yazar";
            dgvTablo.Columns[7].HeaderText = "Yayınevi";
            dgvTablo.Columns[8].HeaderText = "Emanet Verildiği Tarih";
            dgvTablo.Columns[9].HeaderText = "Geri Alınacağı Tarhi";

            cbKAd.SelectedIndex = 0;
            cbKYazar.SelectedIndex = 0;
            cbKYEvi.SelectedIndex = 0;
            cbMad.SelectedIndex = 0;
            cbMSad.SelectedIndex = 0;
            cbMTel.SelectedIndex = 0;
            cbMPosta.SelectedIndex = 0;



        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            EmanetEkleClass ekleBtn = new EmanetEkleClass();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            uyeA = cbMad.SelectedItem.ToString();
            uyeS = cbMSad.Text;
            uyeT = cbMTel.Text;
            uyeP = cbMPosta.Text;
            kitapA = cbKAd.Text;
            yayinE = cbKYEvi.Text;
            yazar = cbKYazar.Text;
            dic.Add("@uyeAdi", uyeA);
            dic.Add("@uyeSoyad", uyeS);
            dic.Add("@uyeTel", uyeT);
            dic.Add("@uyePosta", uyeP);
            int uyeId = ekleBtn.idbul("SELECT uyeNo FROM Uyeler WHERE uyeAdi=@uyeAdi AND uyeSoyad=@uyeSoyad AND uyeTel=@uyeTel AND uyePosta=@uyePosta", dic);
            dic.Clear();
            dic.Add("@kitapAdi", kitapA);
            dic.Add("@yazar", yazar);
            dic.Add("@yayınEvi", yayinE);
            int kitapId = ekleBtn.idbul("SELECT kitapId FROM Kitaplar WHERE kitapAdi = @kitapAdi AND yazar = @yazar AND yayınEvi = @yayınEvi ", dic);
            dic.Clear();
            dic.Add("@uyeNo", uyeId.ToString());
            dic.Add("@kitapId", kitapId.ToString());
            dic.Add("@emanetTarihi", emanetTarih.ToString());
            dic.Add("@gerialma", gerialma.ToString());
            dic.Add("@islem", islem.ToString());
            dic.Add("@notlar", not.ToString());
            dic.Add("@teslim", teslim.ToString());
            ekleBtn.insert("INSERT INTO OduncKitap (uyeNo, kitapId, emanetTarihi, gerialınacakTarih, islemTarihi, notlar, teslimEdildi) VALUES(@uyeNo, @kitapId, @emanetTarihi, @gerialma, @islem, @notlar, @teslim)", dic);
            dic.Clear();
            ekleBtn.DataGridDoldur(dgvTablo, "SELECT uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Form sil = new emanetSil();
            sil.ShowDialog();
        }
    }
}
