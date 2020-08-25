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
            personelara ara = new personelara();
            ara.ara(dataGridView1, "select*from Personel where perAdi like'", textBox7.Text, "Personel");


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
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Alanların dolu olduğundan emin olunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox2.SelectedIndex == 0) { MessageBox.Show("Görevi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            else
            {


                try
                {
                    DialogResult d;
                    d = MessageBox.Show("Kaydetmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {

                        personelekle ekle = new personelekle();
                        ekle.PersonelKayıt(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox2.Text);

                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        personelsil silTablo = new personelsil();
                        silTablo.DataGridDoldur(dataGridView1, "SELECT perNo, perAdi, perSoyad, perKullaniciadi, eposta, gorevi FROM Personel", "Personel");

                        random();
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox2.SelectedIndex = 0;

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
            silTablo.DataGridDoldur(dataGridView1, "SELECT perNo, perAdi, perSoyad, perKullaniciadi, eposta, gorevi FROM Personel", "Personel");


            random();

            textBox1.Enabled = false;
            comboBox2.SelectedIndex = 0;



        }

        private void button3_Click(object sender, EventArgs e)

        {

            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int no = Convert.ToInt32(drow.Cells[0].Value);

                personelsil sil = new personelsil();
                sil.delete(no);

            }

            personelsil silTablo = new personelsil();
            silTablo.DataGridDoldur(dataGridView1, "SELECT perNo, perAdi, perSoyad, perKullaniciadi, eposta, gorevi FROM Personel", "Personel");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Alanların dolu olduğundan emin olunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox2.SelectedIndex == 0) { MessageBox.Show("Geçersiz Baskı Yılı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
                        string sorgu = "update Personel set perAdi=@ad,perSoyad=@soyad,perKullaniciadi=@kullanici,sifre=@sifre,eposta=@eposta,gorevi=@gorevi where perNo=@no";
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@no", textBox1.Text);
                        komut.Parameters.AddWithValue("@ad", textBox2.Text);
                        komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                        komut.Parameters.AddWithValue("@kullanici", textBox4.Text);
                        komut.Parameters.AddWithValue("@sifre", textBox5.Text);
                        komut.Parameters.AddWithValue("@eposta", textBox6.Text);
                        komut.Parameters.AddWithValue("@gorevi", comboBox2.Text);
                        komut.ExecuteNonQuery();

                        MessageBox.Show(textBox1.Text + "No'lu personel düzenleme başarılı..", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        komut.Dispose();

                        personelsil silTablo = new personelsil();
                        silTablo.DataGridDoldur(dataGridView1, "SELECT perNo, perAdi, perSoyad, perKullaniciadi, eposta, gorevi FROM Personel", "Personel");


                        random();
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        comboBox2.SelectedIndex = 0;
                        baglanti.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
