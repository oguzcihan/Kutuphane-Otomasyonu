using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu2020
{
    public partial class PersonelKayıt : Form
    {
        Connect con = new Connect();
        SqlConnection baglanti;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //arama butonu
            
        }

        public PersonelKayıt()
        {
            InitializeComponent();
        }
        public void random()
        {
            Random rnd = new Random();
            int sayi = rnd.Next(1, 1234567);
            textBox1.Text = sayi.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text=="")
            {
                MessageBox.Show("Alanların dolu olduğundan emin olunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox2.SelectedIndex == 0) { MessageBox.Show("Geçersiz Baskı Yılı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            else
            {
                

                try
                {
                    DialogResult d;
                    d = MessageBox.Show("Kaydetmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                       
                        personelekle ekle = new personelekle();
                        ekle.PersonelKayıt(Convert.ToInt32 (textBox1.Text),textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,comboBox2.Text);

                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }



        
        
        

        private void PersonelKayıt_Load(object sender, EventArgs e)
        {
            personelsil silTablo = new personelsil();
            silTablo.DataGridDoldur(dataGridView1, "SELECT perNo, perAdi, perSoyad, perKullaniciadi, eposta, gorevi FROM Personel","Personel");

            random();


        }

        private void button3_Click(object sender, EventArgs e)

        {

            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int no = Convert.ToInt32(drow.Cells[0].Value);

                personelsil sil = new personelsil();
                sil.delete(no);

            }
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
        }
    }
}
