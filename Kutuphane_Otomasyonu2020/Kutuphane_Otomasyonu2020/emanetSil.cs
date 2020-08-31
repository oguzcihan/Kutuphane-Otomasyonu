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
        string uyeA, uyeS, uyeT, uyeP, kitapA, yazar, yayinE;
        public emanetSil()
        {
            InitializeComponent();
        }

        private void emanetSil_Load(object sender, EventArgs e)
        {
            btnSil.Text = "Sil";
            EmanetSilClass silTablo = new EmanetSilClass();
            silTablo.DataGridDoldur(dgvSilTablo, "SELECT uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
            dgvSilTablo.Columns[0].HeaderText = "Ad";
            dgvSilTablo.Columns[1].HeaderText = "Soyad";
            dgvSilTablo.Columns[2].HeaderText = "Telefon No:";
            dgvSilTablo.Columns[3].HeaderText = "E-Posta";
            dgvSilTablo.Columns[4].HeaderText = "Adres";
            dgvSilTablo.Columns[5].HeaderText = "Kitap Adı";
            dgvSilTablo.Columns[6].HeaderText = "Yazar";
            dgvSilTablo.Columns[7].HeaderText = "Yayınevi";
            dgvSilTablo.Columns[8].HeaderText = "Emanet Verildiği Tarih";
            dgvSilTablo.Columns[9].HeaderText = "Geri Alınacağı Tarhi";
        }
        private void dgvSilTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
        public void dgvSilTablo_SelectionChanged(object sender, EventArgs e)
        {
            uyeA = dgvSilTablo.CurrentRow.Cells[0].Value.ToString();
            uyeS = dgvSilTablo.CurrentRow.Cells[1].Value.ToString();
            uyeT = dgvSilTablo.CurrentRow.Cells[2].Value.ToString();
            uyeP = dgvSilTablo.CurrentRow.Cells[3].Value.ToString();
            kitapA = dgvSilTablo.CurrentRow.Cells[5].Value.ToString();
            yazar = dgvSilTablo.CurrentRow.Cells[6].Value.ToString();
            yayinE = dgvSilTablo.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (uyeA == "")
            {
                MessageBox.Show("Boş satır silinemez.");
            }
            else
            {
                EmanetSilClass silBtn = new EmanetSilClass();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("@uyeAdi", uyeA);
                dic.Add("@uyeSoyad", uyeS);
                dic.Add("@uyeTel", uyeT);
                dic.Add("@uyePosta", uyeP);
                int uyeId = silBtn.idbul("SELECT uyeNo FROM Uyeler WHERE uyeAdi = @uyeAdi AND uyeSoyad = @uyeSoyad AND uyeTel = @uyeTel AND uyePosta = @uyePosta", dic);
                dic.Clear();
                dic.Add("@kitapAdi", kitapA);
                dic.Add("@yazar", yazar);
                dic.Add("@yayınEvi", yayinE);
                int kitapId = silBtn.idbul("SELECT kitapId FROM Kitaplar WHERE kitapAdi = @kitapAdi AND yazar = @yazar AND yayınEvi = @yayınEvi ", dic);
                dic.Clear();
                dic.Add("@uyeNo", uyeId.ToString());
                dic.Add("@kitapId", kitapId.ToString());
                int emanetId = silBtn.idbul("SELECT emanetId FROM OduncKitap WHERE uyeNo=@uyeNo AND kitapId = @kitapId ", dic);
                dic.Clear();
                dic.Add("@emanetID", emanetId.ToString());
                silBtn.delete("DELETE FROM OduncKitap WHERE emanetId=@emanetID", dic);
                silBtn.DataGridDoldur(dgvSilTablo, "SELECT uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres, kitapAdi, yazar, yayınEvi, emanetTarihi, gerialınacakTarih FROM OduncKitap INNER JOIN Uyeler ON OduncKitap.uyeNo = Uyeler.uyeNo INNER JOIN Kitaplar ON OduncKitap.kitapId = Kitaplar.kitapId", "OduncKitap");
            }
        }


    }
}
