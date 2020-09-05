using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu2020
{
    class EmanetTeslim:Emanet
    {
        private SqlCommand _cmd;

        public void update(int emanet, string teslim)
        {
            baglanti.Open();
            string sqlcommand = "UPTADE OduncKitap SET teslimEdildi=@teslimE WHERE emanetId=@emanetId ";
            _cmd = new SqlCommand(sqlcommand, baglanti);
            _cmd.Parameters.AddWithValue("@emanetId", emanet);
            _cmd.Parameters.AddWithValue("@teslimE", teslim);
            _cmd.ExecuteNonQuery();
            _cmd.Dispose();
            baglanti.Close();
        }
    }
}
