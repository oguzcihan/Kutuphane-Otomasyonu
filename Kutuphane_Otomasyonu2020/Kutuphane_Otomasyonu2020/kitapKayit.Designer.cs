namespace Kutuphane_Otomasyonu2020
{
    partial class kitapKayit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kitapKayit));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.Butonlar = new System.Windows.Forms.GroupBox();
            this.btnduzenle = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtkitapAdi = new System.Windows.Forms.TextBox();
            this.txtYazar = new System.Windows.Forms.TextBox();
            this.lblnot = new System.Windows.Forms.Label();
            this.cmbBaski = new System.Windows.Forms.ComboBox();
            this.lblyayınevi = new System.Windows.Forms.Label();
            this.txtsayfaSayisi = new System.Windows.Forms.TextBox();
            this.lblsayfaSayisi = new System.Windows.Forms.Label();
            this.lblyazar = new System.Windows.Forms.Label();
            this.txtNot = new System.Windows.Forms.TextBox();
            this.lblbaskiYili = new System.Windows.Forms.Label();
            this.lblkitapAdi = new System.Windows.Forms.Label();
            this.kitap = new System.Windows.Forms.Label();
            this.txtYayinevi = new System.Windows.Forms.TextBox();
            this.lblkitapNo = new System.Windows.Forms.Label();
            this.İşlemler = new System.Windows.Forms.GroupBox();
            this.btnyenikayit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Butonlar.SuspendLayout();
            this.İşlemler.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(356, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(741, 475);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnkaydet
            // 
            this.btnkaydet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnkaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkaydet.Location = new System.Drawing.Point(34, 26);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(72, 32);
            this.btnkaydet.TabIndex = 15;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.UseVisualStyleBackColor = true;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // Butonlar
            // 
            this.Butonlar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Butonlar.Controls.Add(this.btnduzenle);
            this.Butonlar.Controls.Add(this.btnkaydet);
            this.Butonlar.Controls.Add(this.btnsil);
            this.Butonlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Butonlar.Location = new System.Drawing.Point(1, 453);
            this.Butonlar.Name = "Butonlar";
            this.Butonlar.Size = new System.Drawing.Size(349, 73);
            this.Butonlar.TabIndex = 19;
            this.Butonlar.TabStop = false;
            this.Butonlar.Text = "Butonlar";
            // 
            // btnduzenle
            // 
            this.btnduzenle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnduzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnduzenle.Location = new System.Drawing.Point(136, 26);
            this.btnduzenle.Name = "btnduzenle";
            this.btnduzenle.Size = new System.Drawing.Size(70, 32);
            this.btnduzenle.TabIndex = 16;
            this.btnduzenle.Text = "Düzenle";
            this.btnduzenle.UseVisualStyleBackColor = true;
            this.btnduzenle.Click += new System.EventHandler(this.btnduzenle_Click);
            // 
            // btnsil
            // 
            this.btnsil.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsil.Location = new System.Drawing.Point(237, 26);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(74, 32);
            this.btnsil.TabIndex = 17;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(731, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Arama";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(746, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(212, 13);
            this.label14.TabIndex = 161;
            this.label14.Text = "<KİTAP ADINA GÖRE ARAMA YAPINIZ>>";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox7.Location = new System.Drawing.Point(786, 8);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(146, 23);
            this.textBox7.TabIndex = 20;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // txtkitapAdi
            // 
            this.txtkitapAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkitapAdi.Location = new System.Drawing.Point(112, 87);
            this.txtkitapAdi.Name = "txtkitapAdi";
            this.txtkitapAdi.Size = new System.Drawing.Size(151, 24);
            this.txtkitapAdi.TabIndex = 9;
            // 
            // txtYazar
            // 
            this.txtYazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYazar.Location = new System.Drawing.Point(111, 132);
            this.txtYazar.Name = "txtYazar";
            this.txtYazar.Size = new System.Drawing.Size(151, 24);
            this.txtYazar.TabIndex = 10;
            // 
            // lblnot
            // 
            this.lblnot.AutoSize = true;
            this.lblnot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblnot.Location = new System.Drawing.Point(75, 326);
            this.lblnot.Name = "lblnot";
            this.lblnot.Size = new System.Drawing.Size(36, 18);
            this.lblnot.TabIndex = 7;
            this.lblnot.Text = "Not:";
            // 
            // cmbBaski
            // 
            this.cmbBaski.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaski.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBaski.FormattingEnabled = true;
            this.cmbBaski.Items.AddRange(new object[] {
            "-- Seçiniz --"});
            this.cmbBaski.Location = new System.Drawing.Point(111, 179);
            this.cmbBaski.Name = "cmbBaski";
            this.cmbBaski.Size = new System.Drawing.Size(151, 26);
            this.cmbBaski.TabIndex = 11;
            // 
            // lblyayınevi
            // 
            this.lblyayınevi.AutoSize = true;
            this.lblyayınevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblyayınevi.Location = new System.Drawing.Point(40, 280);
            this.lblyayınevi.Name = "lblyayınevi";
            this.lblyayınevi.Size = new System.Drawing.Size(65, 18);
            this.lblyayınevi.TabIndex = 6;
            this.lblyayınevi.Text = "Yayınevi:";
            // 
            // txtsayfaSayisi
            // 
            this.txtsayfaSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsayfaSayisi.Location = new System.Drawing.Point(111, 230);
            this.txtsayfaSayisi.Name = "txtsayfaSayisi";
            this.txtsayfaSayisi.Size = new System.Drawing.Size(151, 24);
            this.txtsayfaSayisi.TabIndex = 12;
            this.txtsayfaSayisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsayfaSayisi_KeyPress);
            // 
            // lblsayfaSayisi
            // 
            this.lblsayfaSayisi.AutoSize = true;
            this.lblsayfaSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblsayfaSayisi.Location = new System.Drawing.Point(16, 233);
            this.lblsayfaSayisi.Name = "lblsayfaSayisi";
            this.lblsayfaSayisi.Size = new System.Drawing.Size(92, 18);
            this.lblsayfaSayisi.TabIndex = 5;
            this.lblsayfaSayisi.Text = "Sayfa Sayısı:";
            // 
            // lblyazar
            // 
            this.lblyazar.AutoSize = true;
            this.lblyazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblyazar.Location = new System.Drawing.Point(56, 135);
            this.lblyazar.Name = "lblyazar";
            this.lblyazar.Size = new System.Drawing.Size(50, 18);
            this.lblyazar.TabIndex = 4;
            this.lblyazar.Text = "Yazar:";
            // 
            // txtNot
            // 
            this.txtNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNot.Location = new System.Drawing.Point(111, 326);
            this.txtNot.Multiline = true;
            this.txtNot.Name = "txtNot";
            this.txtNot.Size = new System.Drawing.Size(151, 52);
            this.txtNot.TabIndex = 14;
            // 
            // lblbaskiYili
            // 
            this.lblbaskiYili.AutoSize = true;
            this.lblbaskiYili.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblbaskiYili.Location = new System.Drawing.Point(37, 182);
            this.lblbaskiYili.Name = "lblbaskiYili";
            this.lblbaskiYili.Size = new System.Drawing.Size(71, 18);
            this.lblbaskiYili.TabIndex = 3;
            this.lblbaskiYili.Text = "Baskı Yılı:";
            // 
            // lblkitapAdi
            // 
            this.lblkitapAdi.AutoSize = true;
            this.lblkitapAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblkitapAdi.Location = new System.Drawing.Point(38, 90);
            this.lblkitapAdi.Name = "lblkitapAdi";
            this.lblkitapAdi.Size = new System.Drawing.Size(69, 18);
            this.lblkitapAdi.TabIndex = 2;
            this.lblkitapAdi.Text = "Kitap Adı:";
            // 
            // kitap
            // 
            this.kitap.AutoSize = true;
            this.kitap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kitap.Location = new System.Drawing.Point(40, 47);
            this.kitap.Name = "kitap";
            this.kitap.Size = new System.Drawing.Size(69, 18);
            this.kitap.TabIndex = 1;
            this.kitap.Text = "Kitap No:";
            // 
            // txtYayinevi
            // 
            this.txtYayinevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYayinevi.Location = new System.Drawing.Point(111, 277);
            this.txtYayinevi.Name = "txtYayinevi";
            this.txtYayinevi.Size = new System.Drawing.Size(151, 24);
            this.txtYayinevi.TabIndex = 13;
            // 
            // lblkitapNo
            // 
            this.lblkitapNo.AutoSize = true;
            this.lblkitapNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblkitapNo.Location = new System.Drawing.Point(109, 47);
            this.lblkitapNo.Name = "lblkitapNo";
            this.lblkitapNo.Size = new System.Drawing.Size(18, 18);
            this.lblkitapNo.TabIndex = 15;
            this.lblkitapNo.Text = "--";
            // 
            // İşlemler
            // 
            this.İşlemler.BackColor = System.Drawing.SystemColors.Control;
            this.İşlemler.Controls.Add(this.btnyenikayit);
            this.İşlemler.Controls.Add(this.lblkitapNo);
            this.İşlemler.Controls.Add(this.txtYayinevi);
            this.İşlemler.Controls.Add(this.kitap);
            this.İşlemler.Controls.Add(this.lblkitapAdi);
            this.İşlemler.Controls.Add(this.lblbaskiYili);
            this.İşlemler.Controls.Add(this.txtNot);
            this.İşlemler.Controls.Add(this.lblyazar);
            this.İşlemler.Controls.Add(this.lblsayfaSayisi);
            this.İşlemler.Controls.Add(this.txtsayfaSayisi);
            this.İşlemler.Controls.Add(this.lblyayınevi);
            this.İşlemler.Controls.Add(this.cmbBaski);
            this.İşlemler.Controls.Add(this.lblnot);
            this.İşlemler.Controls.Add(this.txtYazar);
            this.İşlemler.Controls.Add(this.txtkitapAdi);
            this.İşlemler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.İşlemler.Location = new System.Drawing.Point(1, 8);
            this.İşlemler.Name = "İşlemler";
            this.İşlemler.Size = new System.Drawing.Size(349, 444);
            this.İşlemler.TabIndex = 18;
            this.İşlemler.TabStop = false;
            this.İşlemler.Text = "İşlemler";
            // 
            // btnyenikayit
            // 
            this.btnyenikayit.BackColor = System.Drawing.Color.Transparent;
            this.btnyenikayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyenikayit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnyenikayit.Image = ((System.Drawing.Image)(resources.GetObject("btnyenikayit.Image")));
            this.btnyenikayit.Location = new System.Drawing.Point(287, 27);
            this.btnyenikayit.Name = "btnyenikayit";
            this.btnyenikayit.Size = new System.Drawing.Size(56, 38);
            this.btnyenikayit.TabIndex = 166;
            this.btnyenikayit.UseVisualStyleBackColor = false;
            this.btnyenikayit.Click += new System.EventHandler(this.btnyenikayit_Click);
            // 
            // kitapKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 528);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.Butonlar);
            this.Controls.Add(this.İşlemler);
            this.Controls.Add(this.dataGridView1);
            this.Name = "kitapKayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitap İşlemleri";
            this.Load += new System.EventHandler(this.kitapKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Butonlar.ResumeLayout(false);
            this.İşlemler.ResumeLayout(false);
            this.İşlemler.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.GroupBox Butonlar;
        private System.Windows.Forms.Button btnduzenle;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox txtkitapAdi;
        private System.Windows.Forms.TextBox txtYazar;
        private System.Windows.Forms.Label lblnot;
        private System.Windows.Forms.ComboBox cmbBaski;
        private System.Windows.Forms.Label lblyayınevi;
        private System.Windows.Forms.TextBox txtsayfaSayisi;
        private System.Windows.Forms.Label lblsayfaSayisi;
        private System.Windows.Forms.Label lblyazar;
        private System.Windows.Forms.TextBox txtNot;
        private System.Windows.Forms.Label lblbaskiYili;
        private System.Windows.Forms.Label lblkitapAdi;
        private System.Windows.Forms.Label kitap;
        private System.Windows.Forms.TextBox txtYayinevi;
        private System.Windows.Forms.Label lblkitapNo;
        private System.Windows.Forms.GroupBox İşlemler;
        private System.Windows.Forms.Button btnyenikayit;
    }
}