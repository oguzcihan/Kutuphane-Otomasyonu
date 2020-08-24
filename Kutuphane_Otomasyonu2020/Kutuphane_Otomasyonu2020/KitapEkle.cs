using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu2020
{
    public class KitapEkle
    {
       
        SqlConnection baglanti;
        Connect con = new Connect();
        public void insert(int no, string kitapAdi, string yazar, int baskiyili, int sayfaSayisi, string yayinevi, string not)
        {
            baglanti = new SqlConnection(con.adres);
            try
            {
                DialogResult d;
                d = MessageBox.Show("Kaydetmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    baglanti.Open();
                    string sorgu = "insert into Kitaplar (kitapId,kitapAdi,yazar,baskiYili,sayfaSayisi,yayınEvi,notlar) values (@no,@ad,@yazar,@baski,@sayfa,@yayin,@not)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@no", no);
                    komut.Parameters.AddWithValue("@ad", kitapAdi);
                    komut.Parameters.AddWithValue("@yazar", yazar);
                    komut.Parameters.AddWithValue("@baski", baskiyili);
                    komut.Parameters.AddWithValue("@sayfa", sayfaSayisi);
                    komut.Parameters.AddWithValue("@yayin", yayinevi);
                    komut.Parameters.AddWithValue("@not", not);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    komut.Dispose();

                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        
    }
}
