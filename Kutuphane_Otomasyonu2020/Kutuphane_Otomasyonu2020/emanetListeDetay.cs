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
    public partial class emanetListeDetay : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public emanetListeDetay()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        private void emanetListeDetay_Load(object sender, EventArgs e)
        {
            liste();
        }
        public void liste()
        {
            
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            try
            {
                baglanti.Open();
                SqlCommand EmanetListeleDetay = new SqlCommand("SELECT * FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE OduncKitap.emanetId = @secilenEmanetNo", baglanti);
                EmanetListeleDetay.Parameters.Add("@secilenEmanetNo", SqlDbType.Int).Value = emanetListe.EmanetListeleSecilen.ToString();

                SqlDataReader sonuclar = EmanetListeleDetay.ExecuteReader();
                while (sonuclar.Read())
                {
                    labelEmanetNoVeri.Text = sonuclar["emanetId"].ToString();
                    labelEmanetVermeTarihVeri.Text = sonuclar["emanetTarihi"].ToString();
                    labelEmanetAlmaVeri.Text = sonuclar["gerialınacakTarih"].ToString();
                    labelEmanetIslemTarihVeri.Text = sonuclar["islemTarih"].ToString();
                    labelEmanetNotVeri.Text = sonuclar["EmanetNot"].ToString();

                    labelUyeNoVeri.Text = sonuclar["uyeNo"].ToString();
                    labelUyeAdVeri.Text = sonuclar["UyeAdi"].ToString();
                    labelUyeSoyadVeri.Text = sonuclar["uyeSoyad"].ToString();
                    labelUyeTelefonVeri.Text = sonuclar["uyeTel"].ToString();
                    labelUyeEpostaVeri.Text = sonuclar["uyePosta"].ToString();
                    labelUyeAdresVeri.Text = sonuclar["uyeAdres"].ToString();

                    labelKitapNoVeri.Text = sonuclar["kitapId"].ToString();
                    labelKitapAdVeri.Text = sonuclar["kitapAdi"].ToString();
                    labelKitapYazarVeri.Text = sonuclar["yazar"].ToString();
                    labelKitapBaskiYilVeri.Text = sonuclar["baskiYili"].ToString();
                    labelKitapSayfaSayiVeri.Text = sonuclar["sayfaSayisi"].ToString();
                  
                    labelKitapYayinEviVeri.Text = sonuclar["yayınEvi"].ToString();
                    labelKitapAciklamaVeri.Text = sonuclar["notlar"].ToString();


                }

                baglanti.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            
        }

        private void buttonKitapTeslimAlindi_Click(object sender, EventArgs e)
        {
            teslimUpdate();
        }
        public void teslimUpdate()
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kitabın Alındığını teyit ediyormusunuz?", "Uyarı", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                try
                {


                    baglanti.Open();
                    SqlCommand EmanetTeslimEdildi = new SqlCommand("UPDATE OduncKitap SET teslimEdildi='Evet' WHERE emanetId = @secilen   ", baglanti);
                    EmanetTeslimEdildi.Parameters.Add("@secilen", SqlDbType.Int).Value = emanetListe.EmanetListeleSecilen.ToString();
                    EmanetTeslimEdildi.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kitap Teslim Alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    emanetListe list = new emanetListe();
                    list.liste();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
