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
    public partial class emanetListe : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public emanetListe()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }

        
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            

        }

        private void emanetListe_Load(object sender, EventArgs e)
        {
            liste();
            cbarmaT.SelectedIndex = 0;
        }
        public void liste()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            try
            {
                baglanti.Open();
                string sorgu = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE teslimEdildi='Hayır' ";
                SqlCommand komut2 = new SqlCommand(sorgu, baglanti);
                da = new SqlDataAdapter(komut2); 
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                komut2.Dispose();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
        public static string EmanetListeleSecilen;
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            EmanetListeleSecilen = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["emanetId"].Value.ToString();
            if (EmanetListeleSecilen == "")
            {
                MessageBox.Show("Boş satır seçilemez.");
            }
            else
            {
                emanetListeDetay detay = new emanetListeDetay();
                detay.ShowDialog();
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            birimler();
        }
        public void birimler()
        {
            string emnaetIdS = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE teslimEdildi='Hayır' AND emanetId like '";
            string uyeAS = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE teslimEdildi='Hayır' AND uyeAdi like '";
            string KitapAS = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId WHERE teslimEdildi='Hayır' AND kitapAdi like '";

            try
            {
                if (cbarmaT.Text == "Emanet No")
                {
                    liste();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(emnaetIdS +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                    

                }
                else if (cbarmaT.Text == "Üye Ad")
                {
                    liste();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(uyeAS +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                else if (cbarmaT.Text == "Kitap Adı")
                {
                    liste();
                    baglanti.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(KitapAS +
                    txtAra.Text + "%'", baglanti);
                    dt.Clear();
                    ada.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbarmaT.Text=="-- Seçiniz --")
            {
                txtAra.Text = "";
                MessageBox.Show("Lütfen Arama Türü Seçiniz.");
                txtAra.Text = "";
            }
            else if(cbarmaT.Text=="Emanet No")
            {
                txtAra.Text = "";
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            else if (cbarmaT.Text=="Üye Ad")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }
            else if(cbarmaT.Text=="Kitap Adı")
            {
                txtAra.Text = "";
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
            }
            
        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            liste();
        }
    }
}
