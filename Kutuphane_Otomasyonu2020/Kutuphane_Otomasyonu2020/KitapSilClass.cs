using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu2020
{
    class KitapSilClass
    {
        Connect con = new Connect();
        SqlConnection baglanti;
        public void delete(int no)
        {
            baglanti = new SqlConnection(con.adres);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Kitaplar where kitapId=@no", baglanti);
            komut.Parameters.AddWithValue("@no", no);
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();

        }
    }
}
