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

            ToolTip Aciklama = new ToolTip();
            Aciklama.ToolTipTitle = "Temizle";
            Aciklama.ToolTipIcon = ToolTipIcon.Info;
            Aciklama.IsBalloon = true;
            Aciklama.SetToolTip(btnyenikayit, "Yeni Kayıt");

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

        public void update()
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
                    d = MessageBox.Show(lblkitapNo + "No'lu kitabı düzenlemek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        baglanti.Open();
                        string sorgu = "update Kitaplar set kitapAdi=@ad,yazar=@yazar,baskiYili=@baski,sayfaSayisi=@sayfa,yayınEvi=@yayin,notlar=@not where kitapId=@no";
                        SqlCommand komut = new SqlCommand(sorgu, baglanti);
                        komut.Parameters.AddWithValue("@no", lblkitapNo.Text);
                        komut.Parameters.AddWithValue("@ad", txtkitapAdi.Text);
                        komut.Parameters.AddWithValue("@yazar", txtYazar.Text);
                        komut.Parameters.AddWithValue("@baski", cmbBaski.Text);
                        komut.Parameters.AddWithValue("@sayfa", txtsayfaSayisi.Text);
                        komut.Parameters.AddWithValue("@yayin", txtYayinevi.Text);
                        komut.Parameters.AddWithValue("@not", txtNot.Text);
                        komut.ExecuteNonQuery();

                        MessageBox.Show(lblkitapNo+"No'lu kitabı düzenleme başarılı..", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                lblkitapNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtkitapAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtYazar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                cmbBaski.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtsayfaSayisi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtYayinevi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtNot.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
              
            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }

        private void btnduzenle_Click(object sender, EventArgs e)
        {
            update();
        }

        private void btnyenikayit_Click(object sender, EventArgs e)
        {
            temizle();
            random();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //arama butonu
            try
            {
                baglanti.Open();
                dt.Clear();
                SqlDataAdapter adap = new SqlDataAdapter("select*from Kitaplar where kitapAdi like'" + textBox7.Text + "%'", baglanti);
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception hata) { MessageBox.Show(hata.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
        }
    }
}
