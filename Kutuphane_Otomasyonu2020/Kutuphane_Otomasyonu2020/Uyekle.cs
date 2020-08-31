using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu2020
{
    class Uyekle
    {
        public SqlConnection baglanti;
        public Connect con = new Connect();



        public void UyeKayıt(int no, string ad, string soyad, int tel, string eposta, string adres)
        {
            baglanti = new SqlConnection(con.adres);



            try
            {

                baglanti.Open();
                string sorgu = "insert into Uyeler (uyeNo,uyeAdi,uyeSoyad,uyeTel,uyePosta,uyeAdres) values (@no,@ad,@soyad,@tel,@eposta,@adres)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@no", no);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@tel", tel);
                komut.Parameters.AddWithValue("@eposta", eposta);
                komut.Parameters.AddWithValue("@adres", adres);


                komut.ExecuteNonQuery();

                komut.Dispose();

                baglanti.Close();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
