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
    class uyearama
    {

        public void ara(DataGridView dataGrid, string sorgu, string aranan, string tabload)
        {

            Connect con = new Connect();
            SqlConnection baglanti;
            SqlDataAdapter da;
            DataTable dt = new DataTable(tabload);
            try
            {


                baglanti = new SqlConnection(con.adres);

                baglanti.Open();
                dt.Clear();
                SqlDataAdapter adap = new SqlDataAdapter(sorgu + aranan + "%'", baglanti);
                adap.Fill(dt);
                dataGrid.DataSource = dt;
                baglanti.Close();



            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
    }
}
