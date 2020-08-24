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
    class personelsil
    {
        public SqlConnection baglanti;
        public Connect con = new Connect();
       
        public void veritabaniac()
        {
            baglanti.Open();
        }
        public void veritabanikapa()
        {
            baglanti.Close();
        }
        public void DataGridDoldur(DataGridView dataGrid, string sorgu, string tabload)
        {
            baglanti = new SqlConnection(con.adres);
            baglanti.Open();
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

            if (int.TryParse(cmd.ExecuteScalar().ToString(), out int ret))
            {
                return ret;
            }
            else
                return 0;
        }
        public void delete(string sorgu, Dictionary<string, string> input)
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

            cmd.ExecuteNonQuery();
        }
    }
}
