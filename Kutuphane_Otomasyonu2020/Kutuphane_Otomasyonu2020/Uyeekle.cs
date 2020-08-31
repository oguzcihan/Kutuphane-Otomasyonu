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
    public partial class Uyeekle : Form
    {
        public Uyeekle()
        {
            InitializeComponent();
        }
        public void random()
        {
            Random rnd = new Random();
            int sayi = rnd.Next(1, 1234567);
            textBox1.Text = sayi.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        Connect con = new Connect();
        SqlConnection baglanti;
        SqlDataAdapter da;
        DataTable dt = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Alanların dolu olduğundan emin olunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

            else
            {


                try
                {
                    DialogResult d;
                    d = MessageBox.Show("Kaydetmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {

                         Uyekle ekle = new Uyekle();
                       ekle.UyeKayıt(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToInt32 (textBox4.Text), textBox5.Text, textBox6.Text);

                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        uyesil silTablo = new uyesil();
                       silTablo.DataGridDoldur(dataGridView1, "SELECT uyeNo, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres FROM Uyeler", "Uyeler");

                        random();
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                     

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Alanların dolu olduğundan emin olunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show(textBox1.Text + "No'lu personeli düzenlemek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti = new SqlConnection(con.adres);

                        baglanti.Open();
                        string sorgu = "update Personel set uyeAdi=@ad,uyeSoyad=@soyad,uyeTel=@tel,uyePosta=@eposta,uyeAdres=@adres where uyeNO=@no";
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@no", textBox1.Text);
                        komut.Parameters.AddWithValue("@ad", textBox2.Text);
                        komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                        komut.Parameters.AddWithValue("@tel", textBox4.Text);
                        komut.Parameters.AddWithValue("@eposta", textBox5.Text);
                        komut.Parameters.AddWithValue("@adres", textBox6.Text);
                        komut.ExecuteNonQuery();

                        MessageBox.Show(textBox1.Text + "No'lu uyeyi düzenleme başarılı..", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        komut.Dispose();

                        personelsil silTablo = new personelsil();
                        silTablo.DataGridDoldur(dataGridView1, "SELECT uyeNo, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres FROM Uyeler", "Uyeler");


                        random();
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        baglanti.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int no = Convert.ToInt32(drow.Cells[0].Value);

                uyesil sil = new uyesil();
                sil.delete(no);

            }

            personelsil silTablo = new personelsil();
            silTablo.DataGridDoldur(dataGridView1, "SELECT uyeNo, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres FROM Uyeler", "Uyeler");

        }

        private void Uyeekle_Load(object sender, EventArgs e)
        {

            random();

            textBox1.Enabled = false;
            personelsil silTablo = new personelsil();
            silTablo.DataGridDoldur(dataGridView1, "SELECT uyeNo, uyeAdi, uyeSoyad, uyeTel, uyePosta, uyeAdres FROM Uyeler", "Uyeler");


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            uyearama ara = new uyearama();
            ara.ara(dataGridView1, "select*from Uyeler where uyeAdi like'", textBox7.Text, "Uyeler");

        }
    }
}
