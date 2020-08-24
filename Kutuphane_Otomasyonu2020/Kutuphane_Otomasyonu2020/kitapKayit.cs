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
    public partial class kitapKayit : Form
    {
        SqlConnection baglanti;
        Connect con = new Connect();
        public kitapKayit()
        {
            baglanti = new SqlConnection(con.adres);
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        private void kitapKayit_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DateTime mydate = System.DateTime.Now;
            string year = mydate.Year.ToString();
            for (int i = 1990; i <= mydate.Year; i++)
            {
                cmbBaski.Items.Add(i);
            }

            random();
            listele();
            cmbBaski.SelectedIndex = 0;
            Isimler name = new Isimler();
            dataGridView1.Columns[0].HeaderText = name.kitapId;
            dataGridView1.Columns[1].HeaderText = name.kitapAdi;
            dataGridView1.Columns[2].HeaderText = name.yazar;
            dataGridView1.Columns[3].HeaderText = name.baski;
            dataGridView1.Columns[4].HeaderText = name.sayfa;
            dataGridView1.Columns[5].HeaderText = name.yayin;
            dataGridView1.Columns[6].HeaderText = name.not;
            dataGridView1.Columns[6].Width = 300;

        }
        public void random()
        {
            Random rnd = new Random();
            int sayi = rnd.Next(1, 1234567);
            lblkitapNo.Text = sayi.ToString();
        }

        public void insert()
        {
            if (txtkitapAdi.Text == "" || txtYazar.Text == "" || txtsayfaSayisi.Text == "")
            {
                MessageBox.Show("Alanların dolu olduğundan emin olunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbBaski.SelectedIndex == 0) { MessageBox.Show("Geçersiz Baskı Yılı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                try
                {
                    DialogResult d;
                    d = MessageBox.Show("Kaydetmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();
                        string sorgu = "insert into Kitaplar (kitapId,kitapAdi,yazar,baskiYili,sayfaSayisi,yayınEvi,notlar) values (@no,@ad,@yazar,@baski,@sayfa,@yayin,@not)";
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@no", lblkitapNo.Text);
                        komut.Parameters.AddWithValue("@ad", txtkitapAdi.Text);
                        komut.Parameters.AddWithValue("@yazar", txtYazar.Text);
                        komut.Parameters.AddWithValue("@baski", cmbBaski.Text);
                        komut.Parameters.AddWithValue("@sayfa", txtsayfaSayisi.Text);
                        komut.Parameters.AddWithValue("@yayin", txtYayinevi.Text);
                        komut.Parameters.AddWithValue("@not", txtNot.Text);
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Kayıt Başarılı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        komut.Dispose();
                        listele();
                        temizle();
                        baglanti.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        public void listele()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            dt.Clear();
            try
            {
                baglanti.Open();
                string sorgu = "select*from Kitaplar";
                SqlCommand komut2 = new SqlCommand(sorgu, baglanti);
                da = new SqlDataAdapter(komut2);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
                komut2.Dispose();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            insert();


        }
        public void temizle()
        {
            txtkitapAdi.Clear();
            txtNot.Clear();
            txtsayfaSayisi.Clear();
            txtYayinevi.Clear();
            txtYazar.Clear();
            random();
            cmbBaski.SelectedIndex = 0;
        }

        private void txtsayfaSayisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            Form sil = new KitapSil();
            sil.ShowDialog();
        }
    }
}
