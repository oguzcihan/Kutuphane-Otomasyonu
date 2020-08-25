using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu2020
{

    public class GirisClass
    {
        Connect con = new Connect();
        SqlConnection baglanti;

        public void login()
        {
            baglanti = new SqlConnection(con.adres);
        }

    }
}
