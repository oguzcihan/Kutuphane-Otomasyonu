namespace Kutuphane_Otomasyonu2020
{
    partial class emanetSil
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
            this.dgvSilTablo = new System.Windows.Forms.DataGridView();
            this.btnSil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSilTablo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSilTablo
            // 
            this.dgvSilTablo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSilTablo.Location = new System.Drawing.Point(12, 12);
            this.dgvSilTablo.Name = "dgvSilTablo";
            this.dgvSilTablo.RowHeadersWidth = 51;
            this.dgvSilTablo.RowTemplate.Height = 24;
            this.dgvSilTablo.Size = new System.Drawing.Size(1125, 564);
            this.dgvSilTablo.TabIndex = 0;
            this.dgvSilTablo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSilTablo_CellContentClick);
            this.dgvSilTablo.SelectionChanged += new System.EventHandler(this.dgvSilTablo_SelectionChanged);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(500, 596);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(131, 45);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "button1";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // emanetSil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 698);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.dgvSilTablo);
            this.Name = "emanetSil";
            this.Text = "emanetSil";
            this.Load += new System.EventHandler(this.emanetSil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSilTablo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSilTablo;
        private System.Windows.Forms.Button btnSil;
    }
}