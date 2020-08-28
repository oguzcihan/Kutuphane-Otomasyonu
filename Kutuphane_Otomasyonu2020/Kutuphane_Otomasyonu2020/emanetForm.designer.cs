namespace Kutuphane_Otomasyonu2020
{
    partial class emanetForm
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
            this.lblMAd = new System.Windows.Forms.Label();
            this.lblMSad = new System.Windows.Forms.Label();
            this.lblMTel = new System.Windows.Forms.Label();
            this.lblMPosta = new System.Windows.Forms.Label();
            this.lblKAd = new System.Windows.Forms.Label();
            this.lblKYazar = new System.Windows.Forms.Label();
            this.lblKYEvi = new System.Windows.Forms.Label();
            this.cbKAd = new System.Windows.Forms.ComboBox();
            this.cbKYazar = new System.Windows.Forms.ComboBox();
            this.cbKYEvi = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lblGTarih = new System.Windows.Forms.Label();
            this.dtpGTarih = new System.Windows.Forms.DateTimePicker();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.dgvTablo = new System.Windows.Forms.DataGridView();
            this.btnAra = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbMPosta = new System.Windows.Forms.ComboBox();
            this.cbMTel = new System.Windows.Forms.ComboBox();
            this.cbMSad = new System.Windows.Forms.ComboBox();
            this.cbMad = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMAd
            // 
            this.lblMAd.AutoSize = true;
            this.lblMAd.Location = new System.Drawing.Point(48, 27);
            this.lblMAd.Name = "lblMAd";
            this.lblMAd.Size = new System.Drawing.Size(46, 17);
            this.lblMAd.TabIndex = 0;
            this.lblMAd.Text = "label1";
            // 
            // lblMSad
            // 
            this.lblMSad.AutoSize = true;
            this.lblMSad.Location = new System.Drawing.Point(48, 57);
            this.lblMSad.Name = "lblMSad";
            this.lblMSad.Size = new System.Drawing.Size(46, 17);
            this.lblMSad.TabIndex = 1;
            this.lblMSad.Text = "label2";
            // 
            // lblMTel
            // 
            this.lblMTel.AutoSize = true;
            this.lblMTel.Location = new System.Drawing.Point(48, 87);
            this.lblMTel.Name = "lblMTel";
            this.lblMTel.Size = new System.Drawing.Size(46, 17);
            this.lblMTel.TabIndex = 2;
            this.lblMTel.Text = "label3";
            // 
            // lblMPosta
            // 
            this.lblMPosta.AutoSize = true;
            this.lblMPosta.Location = new System.Drawing.Point(48, 117);
            this.lblMPosta.Name = "lblMPosta";
            this.lblMPosta.Size = new System.Drawing.Size(46, 17);
            this.lblMPosta.TabIndex = 3;
            this.lblMPosta.Text = "label1";
            // 
            // lblKAd
            // 
            this.lblKAd.AutoSize = true;
            this.lblKAd.Location = new System.Drawing.Point(48, 146);
            this.lblKAd.Name = "lblKAd";
            this.lblKAd.Size = new System.Drawing.Size(46, 17);
            this.lblKAd.TabIndex = 5;
            this.lblKAd.Text = "label1";
            // 
            // lblKYazar
            // 
            this.lblKYazar.AutoSize = true;
            this.lblKYazar.Location = new System.Drawing.Point(48, 174);
            this.lblKYazar.Name = "lblKYazar";
            this.lblKYazar.Size = new System.Drawing.Size(46, 17);
            this.lblKYazar.TabIndex = 6;
            this.lblKYazar.Text = "label1";
            // 
            // lblKYEvi
            // 
            this.lblKYEvi.AutoSize = true;
            this.lblKYEvi.Location = new System.Drawing.Point(48, 202);
            this.lblKYEvi.Name = "lblKYEvi";
            this.lblKYEvi.Size = new System.Drawing.Size(46, 17);
            this.lblKYEvi.TabIndex = 7;
            this.lblKYEvi.Text = "label1";
            // 
            // cbKAd
            // 
            this.cbKAd.FormattingEnabled = true;
            this.cbKAd.Location = new System.Drawing.Point(151, 146);
            this.cbKAd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbKAd.Name = "cbKAd";
            this.cbKAd.Size = new System.Drawing.Size(121, 24);
            this.cbKAd.TabIndex = 13;
            this.cbKAd.SelectedIndexChanged += new System.EventHandler(this.cbKAd_SelectedIndexChanged);
            // 
            // cbKYazar
            // 
            this.cbKYazar.FormattingEnabled = true;
            this.cbKYazar.Location = new System.Drawing.Point(151, 174);
            this.cbKYazar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbKYazar.Name = "cbKYazar";
            this.cbKYazar.Size = new System.Drawing.Size(121, 24);
            this.cbKYazar.TabIndex = 14;
            this.cbKYazar.SelectedIndexChanged += new System.EventHandler(this.cbKYazar_SelectedIndexChanged);
            // 
            // cbKYEvi
            // 
            this.cbKYEvi.FormattingEnabled = true;
            this.cbKYEvi.Location = new System.Drawing.Point(151, 202);
            this.cbKYEvi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbKYEvi.Name = "cbKYEvi";
            this.cbKYEvi.Size = new System.Drawing.Size(121, 24);
            this.cbKYEvi.TabIndex = 15;
            this.cbKYEvi.SelectedIndexChanged += new System.EventHandler(this.cbKYEvi_SelectedIndexChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(39, 385);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(115, 34);
            this.btnKaydet.TabIndex = 16;
            this.btnKaydet.Text = "button1";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblGTarih
            // 
            this.lblGTarih.AutoSize = true;
            this.lblGTarih.Location = new System.Drawing.Point(45, 243);
            this.lblGTarih.Name = "lblGTarih";
            this.lblGTarih.Size = new System.Drawing.Size(46, 17);
            this.lblGTarih.TabIndex = 17;
            this.lblGTarih.Text = "label1";
            // 
            // dtpGTarih
            // 
            this.dtpGTarih.Location = new System.Drawing.Point(48, 262);
            this.dtpGTarih.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpGTarih.Name = "dtpGTarih";
            this.dtpGTarih.Size = new System.Drawing.Size(200, 22);
            this.dtpGTarih.TabIndex = 18;
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(160, 385);
            this.btnDuzenle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(123, 34);
            this.btnDuzenle.TabIndex = 19;
            this.btnDuzenle.Text = "button1";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(289, 385);
            this.btnSil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(112, 34);
            this.btnSil.TabIndex = 20;
            this.btnSil.Text = "button1";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // dgvTablo
            // 
            this.dgvTablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablo.Location = new System.Drawing.Point(487, 2);
            this.dgvTablo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTablo.Name = "dgvTablo";
            this.dgvTablo.ReadOnly = true;
            this.dgvTablo.RowHeadersWidth = 51;
            this.dgvTablo.RowTemplate.Height = 24;
            this.dgvTablo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTablo.Size = new System.Drawing.Size(773, 532);
            this.dgvTablo.TabIndex = 21;
            this.dgvTablo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTablo_CellContentClick);
            this.dgvTablo.SelectionChanged += new System.EventHandler(this.dgvTablo_SelectionChanged);
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(145, 21);
            this.btnAra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(173, 38);
            this.btnAra.TabIndex = 24;
            this.btnAra.Text = "button1";
            this.btnAra.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbMPosta);
            this.groupBox1.Controls.Add(this.cbMTel);
            this.groupBox1.Controls.Add(this.cbMSad);
            this.groupBox1.Controls.Add(this.cbMad);
            this.groupBox1.Controls.Add(this.lblMAd);
            this.groupBox1.Controls.Add(this.lblMSad);
            this.groupBox1.Controls.Add(this.lblMTel);
            this.groupBox1.Controls.Add(this.lblMPosta);
            this.groupBox1.Controls.Add(this.dtpGTarih);
            this.groupBox1.Controls.Add(this.lblGTarih);
            this.groupBox1.Controls.Add(this.lblKAd);
            this.groupBox1.Controls.Add(this.lblKYazar);
            this.groupBox1.Controls.Add(this.cbKYEvi);
            this.groupBox1.Controls.Add(this.lblKYEvi);
            this.groupBox1.Controls.Add(this.cbKYazar);
            this.groupBox1.Controls.Add(this.cbKAd);
            this.groupBox1.Location = new System.Drawing.Point(16, 78);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(464, 301);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "İşlemler";
            // 
            // cbMPosta
            // 
            this.cbMPosta.FormattingEnabled = true;
            this.cbMPosta.Location = new System.Drawing.Point(151, 117);
            this.cbMPosta.Name = "cbMPosta";
            this.cbMPosta.Size = new System.Drawing.Size(121, 24);
            this.cbMPosta.TabIndex = 22;
            this.cbMPosta.SelectedIndexChanged += new System.EventHandler(this.cbMPosta_SelectedIndexChanged);
            // 
            // cbMTel
            // 
            this.cbMTel.FormattingEnabled = true;
            this.cbMTel.Location = new System.Drawing.Point(151, 87);
            this.cbMTel.Name = "cbMTel";
            this.cbMTel.Size = new System.Drawing.Size(121, 24);
            this.cbMTel.TabIndex = 21;
            this.cbMTel.SelectedIndexChanged += new System.EventHandler(this.cbMTel_SelectedIndexChanged);
            // 
            // cbMSad
            // 
            this.cbMSad.FormattingEnabled = true;
            this.cbMSad.Location = new System.Drawing.Point(151, 57);
            this.cbMSad.Name = "cbMSad";
            this.cbMSad.Size = new System.Drawing.Size(121, 24);
            this.cbMSad.TabIndex = 20;
            this.cbMSad.SelectedIndexChanged += new System.EventHandler(this.cbMSad_SelectedIndexChanged);
            // 
            // cbMad
            // 
            this.cbMad.FormattingEnabled = true;
            this.cbMad.Location = new System.Drawing.Point(151, 27);
            this.cbMad.Name = "cbMad";
            this.cbMad.Size = new System.Drawing.Size(121, 24);
            this.cbMad.TabIndex = 19;
            this.cbMad.SelectedIndexChanged += new System.EventHandler(this.cbMad_SelectedIndexChanged);
            // 
            // emanetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 539);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.dgvTablo);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnKaydet);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "emanetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "emanetForm";
            this.Load += new System.EventHandler(this.emanetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMAd;
        private System.Windows.Forms.Label lblMSad;
        private System.Windows.Forms.Label lblMTel;
        private System.Windows.Forms.Label lblMPosta;
        private System.Windows.Forms.Label lblKAd;
        private System.Windows.Forms.Label lblKYazar;
        private System.Windows.Forms.Label lblKYEvi;
        private System.Windows.Forms.ComboBox cbKAd;
        private System.Windows.Forms.ComboBox cbKYazar;
        private System.Windows.Forms.ComboBox cbKYEvi;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label lblGTarih;
        private System.Windows.Forms.DateTimePicker dtpGTarih;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.DataGridView dgvTablo;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbMPosta;
        private System.Windows.Forms.ComboBox cbMTel;
        private System.Windows.Forms.ComboBox cbMSad;
        private System.Windows.Forms.ComboBox cbMad;
    }
}