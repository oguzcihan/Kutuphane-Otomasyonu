using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu2020
{
    public partial class emanetSil : Form
    {
        string uyeA, emanetId;
        public emanetSil()
        {
            InitializeComponent();
        }

        private void emanetSil_Load(object sender, EventArgs e)
        {
            btnSil.Text = "Sil";
            EmanetSilClass silTablo = new EmanetSilClass();
            silTablo.DataGridDoldur(dgvSilTablo, "SELECT emanetId, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
            dgvSilTablo.Columns[0].HeaderText = "Emanet No";
            dgvSilTablo.Columns[1].HeaderText = "Ad";
            dgvSilTablo.Columns[2].HeaderText = "Soyad";
            dgvSilTablo.Columns[3].HeaderText = "Telefon No:";
            dgvSilTablo.Columns[4].HeaderText = "E-Posta";
            dgvSilTablo.Columns[5].HeaderText = "Adres";
            dgvSilTablo.Columns[6].HeaderText = "Kitap Adı";
            dgvSilTablo.Columns[7].HeaderText = "Yazar";
            dgvSilTablo.Columns[8].HeaderText = "Yayınevi";
            dgvSilTablo.Columns[9].HeaderText = "Emanet Verildiği Tarih";
            dgvSilTablo.Columns[10].HeaderText = "Geri Alınacağı Tarhi";
        }
        private void dgvSilTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        public void dgvSilTablo_SelectionChanged(object sender, EventArgs e)
        {
            emanetId = dgvSilTablo.CurrentRow.Cells[0].Value.ToString();
            uyeA = dgvSilTablo.CurrentRow.Cells[1].Value.ToString();
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (uyeA == "")
            {
                MessageBox.Show("Boş satır silinemez.");
            }
            else
            {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Kaydı silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (sonuc == DialogResult.OK)
                {
                    try
                    {
                        EmanetSilClass silBtn = new EmanetSilClass();
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("@emanetID", emanetId.ToString());
                        silBtn.delete("DELETE FROM OduncKitap WHERE emanetId=@emanetID", dic);
                        silBtn.DataGridDoldur(dgvSilTablo, "SELECT emanetId, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
                        MessageBox.Show("Kayıt silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }


    }
}
