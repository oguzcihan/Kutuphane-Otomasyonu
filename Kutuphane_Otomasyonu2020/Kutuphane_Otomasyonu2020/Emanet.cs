using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu2020
{
    class Emanet
    {
        public SqlConnection baglanti;
        public Connect con = new Connect();
        public Emanet()
        {
            baglanti = new SqlConnection(con.adres);
            baglanti.Open();
        }
        public void veritabaniac()
        {
            baglanti.Open();
        }
        public void veritabanikapa()
        {
            baglanti.Close();
        }
        public void DataGridDoldur(DataGridView dataGrid,string sorgu,string tabload)
        {
            SqlCommand cmd = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(tabload);
            sda.Fill(dt);
            dataGrid.DataSource = dt.DefaultView;
        }
        public int idbul(string sorgu, Dictionary<string, string> input)
        {
            var cmd = new SqlCommand
            {
                CommandText = sorgu
            };
            foreach (var i in input)
            {
                cmd.Parameters.AddWithValue(i.Key, i.Value);
            }
            cmd.Connection = baglanti;
            int ret;
            if (int.TryParse(cmd.ExecuteScalar().ToString(), out ret))
            {
                return ret;
            }
            else
                return 0;
        }
    }   
}
