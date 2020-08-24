using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu2020
{
    class personelekle
    {
        public SqlConnection baglanti;
        public Connect con = new Connect();



        public void PersonelKayıt(int no, string ad, string soyad, string kullaniciadi, string sifre, string eposta, string gorevi)
        {
            baglanti = new SqlConnection(con.adres);



            try
            {

                baglanti.Open();
                string sorgu = "insert into Personel (perNo,perAdi,perSoyad,perKullaniciadi,sifre,eposta,gorevi) values (@no,@ad,@soyad,@kullaniciadi,@sifre,@eposta,@gorevi)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@no", no);
                komut.Parameters.AddWithValue("@ad", ad);
                komut.Parameters.AddWithValue("@soyad", soyad);
                komut.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
                komut.Parameters.AddWithValue("@sifre", sifre);
                komut.Parameters.AddWithValue("@eposta", eposta);
                komut.Parameters.AddWithValue("@gorevi", gorevi);


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



