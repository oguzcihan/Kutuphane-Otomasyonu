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
using System.Windows.Forms.VisualStyles;

namespace Kutuphane_Otomasyonu2020
{
    public partial class emanetForm : Form
    {
        string emanetId;
        string uyeAd, uyeSoyad, uyePosta, kitapAdi, yazar, yayinevi;

        SqlConnection baglanti;
        Connect con = new Connect();
        public emanetForm()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
            Emanet emanet = new Emanet();
            emanet.DataGridDoldur(dgvTablo, "SELECT emanetId, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
        }

        private void emanetForm_Load(object sender, EventArgs e)
        {            
            dgvTablo.Columns[1].HeaderText = "Ad";
            dgvTablo.Columns[2].HeaderText = "Soyad";
            dgvTablo.Columns[3].HeaderText = "Telefon No:";
            dgvTablo.Columns[4].HeaderText = "E-Posta";
            dgvTablo.Columns[5].HeaderText = "Adres";
            dgvTablo.Columns[6].HeaderText = "Kitap Adı";
            dgvTablo.Columns[7].HeaderText = "Yazar";
            dgvTablo.Columns[8].HeaderText = "Yayınevi";
            dgvTablo.Columns[9].HeaderText = "Emanet Verildiği Tarih";
            dgvTablo.Columns[10].HeaderText = "Geri Alınacağı Tarih";
            dgvTablo.Columns[0].HeaderText = "Emanet No";
           

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
                ekle.insert("INSERT INTO OduncKitap (uyeNo, kitapId, emanetTarihi, gerialınacakTarih, islemTarih, notlar, teslimEdildi) VALUES(@uyeNo, @kitapId, @eTarih, @gTarih, @iTarih, @notlar, @tEdildi)", dic);
                ekle.DataGridDoldur(dgvTablo, "SELECT emanetId, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
                dgvTablo.Columns[0].HeaderText = "Emanet No";
                dgvTablo.Columns[1].HeaderText = "Ad";
                dgvTablo.Columns[2].HeaderText = "Soyad";
                dgvTablo.Columns[3].HeaderText = "Telefon No:";
                dgvTablo.Columns[4].HeaderText = "E-Posta";
                dgvTablo.Columns[5].HeaderText = "Adres";
                dgvTablo.Columns[6].HeaderText = "Kitap Adı";
                dgvTablo.Columns[7].HeaderText = "Yazar";
                dgvTablo.Columns[8].HeaderText = "Yayınevi";
                dgvTablo.Columns[9].HeaderText = "Emanet Verildiği Tarih";
                dgvTablo.Columns[10].HeaderText = "Geri Alınacağı Tarih";
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Form sil = new emanetSil();
            sil.ShowDialog();
        }



        uyeAra uyeAra = new uyeAra();
        private void btnUyeAra_Click(object sender, EventArgs e)
        {
            if (uyeAra == null)
            {
                uyeAra = new uyeAra();
            }
            uyeAra.uyeSecildi += ara_uyesecildi;
            uyeAra.ShowDialog();
        }
        public void ara_uyesecildi()
        {
            txtUyeId.Text = uyeAra.SecilenUye;
            
        }

        kitapAra ara = new kitapAra();
        private SqlCommand _cmd;

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (ara == null)
            {
                ara = new kitapAra();
            }
            ara.kitapSecildi += ara_kitapsecildi;
            ara.ShowDialog();
        }
        
        public void ara_kitapsecildi()
        {
            txtKitapId.Text = ara.SecilenKitap;
            
        }
        public void oku()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Kitaplar where kitapId=@kod", baglanti);
            komut.Parameters.AddWithValue("@kod", txtKitapId.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblKAd.Text = oku["kitapAdi"].ToString();
                lblKYazar.Text = oku["yazar"].ToString();
                lblKYEvi.Text = oku["yayınEvi"].ToString();
               
            }
            oku.Close();
            baglanti.Close();

        }

        private void txtKitapId_TextChanged(object sender, EventArgs e)
        {
            oku();
        }

        private void txtUyeId_TextChanged(object sender, EventArgs e)
        {
            uyeOku();
        }
        public void uyeOku()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Uyeler where uyeNo=@no", baglanti);
            komut.Parameters.AddWithValue("@no", txtUyeId.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblAd.Text = oku["uyeAdi"].ToString();
                lblSoyad.Text = oku["uyeSoyad"].ToString();
                lblTel.Text = oku["uyeTel"].ToString();
                lblPosta.Text = oku["uyePosta"].ToString();


            }
            oku.Close();
            baglanti.Close();
        }

        private void txtKitapId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (txtKitapId.SelectionStart > 0)
            {
                

            }
        }

        private void txtUyeId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtKitapId_KeyUp(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) { return; }

            if (e.KeyCode == Keys.Back && textBox.Text.Length == 0)
            {
                lblKAd.Text = " -- ";
                lblKYazar.Text = " -- ";
                lblKYEvi.Text = " -- ";
                this.Select(true, false);
            }
        }

        private void txtUyeId_KeyUp(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) { return; }

            if (e.KeyCode == Keys.Back && textBox.Text.Length == 0)
            {
                lblAd.Text = " -- ";
                lblSoyad.Text = " -- ";
                lblTel.Text = " -- ";
                lblPosta.Text = " -- ";
                this.Select(true, false);
            }
        }

        
        private void dgvTablo_SelectionChanged(object sender, EventArgs e)
        {
            emanetId = dgvTablo.CurrentRow.Cells[0].ToString();
            uyeAd = dgvTablo.CurrentRow.Cells[1].ToString();
            uyeSoyad = dgvTablo.CurrentRow.Cells[2].ToString();
            uyePosta = dgvTablo.CurrentRow.Cells[4].ToString();
            kitapAdi = dgvTablo.CurrentRow.Cells[6].ToString();
            yazar = dgvTablo.CurrentRow.Cells[7].ToString();
            yayinevi = dgvTablo.CurrentRow.Cells[8].ToString();
        }
    }
}
