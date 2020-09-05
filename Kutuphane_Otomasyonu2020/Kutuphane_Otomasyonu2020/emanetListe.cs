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
        }
        public void liste()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            try
            {
                baglanti.Open();
                string sorgu = "SELECT emanetId,uyeAdi,uyeSoyad,uyeTel,kitapAdi,emanetTarihi,gerialınacakTarih,teslimEdildi,EmanetNot From OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON Kitaplar.kitapId=OduncKitap.kitapId Where teslimEdildi='Hayır'";
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
            emanetListeDetay detay = new emanetListeDetay();
            detay.ShowDialog();
        }
    }
}
