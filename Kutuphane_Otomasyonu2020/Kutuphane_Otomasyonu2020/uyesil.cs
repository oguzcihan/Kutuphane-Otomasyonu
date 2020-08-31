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
    class uyesil
    {

        public SqlConnection baglanti;
        public Connect con = new Connect();


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

        public void delete(int no)
        {
            try
            {

                DialogResult d;
                d = MessageBox.Show("Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    baglanti = new SqlConnection(con.adres);
                    baglanti.Open();
                    SqlCommand ole = new SqlCommand("delete from Uyeler where uyeNo=@no", baglanti);
                    ole.Parameters.AddWithValue("@no", no);
                    ole.ExecuteNonQuery();
                    ole.Dispose();
                    baglanti.Close();

                }

            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
    }
}
