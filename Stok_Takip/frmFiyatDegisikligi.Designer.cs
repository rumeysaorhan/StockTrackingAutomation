namespace Stok_Takip
{
    partial class frmFiyatDegisikligi
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnuygula = new System.Windows.Forms.Button();
            this.txtbarkod = new System.Windows.Forms.TextBox();
            this.txtsatis = new System.Windows.Forms.TextBox();
            this.txtyeni = new System.Windows.Forms.TextBox();
            this.txttarih = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Satış Fiyatı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Yeni Fiyat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tarih";
            // 
            // btnuygula
            // 
            this.btnuygula.Location = new System.Drawing.Point(163, 175);
            this.btnuygula.Name = "btnuygula";
            this.btnuygula.Size = new System.Drawing.Size(75, 23);
            this.btnuygula.TabIndex = 1;
            this.btnuygula.Text = "Uygula";
            this.btnuygula.UseVisualStyleBackColor = true;
            this.btnuygula.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtbarkod
            // 
            this.txtbarkod.Location = new System.Drawing.Point(138, 21);
            this.txtbarkod.Name = "txtbarkod";
            this.txtbarkod.Size = new System.Drawing.Size(100, 20);
            this.txtbarkod.TabIndex = 2;
            // 
            // txtsatis
            // 
            this.txtsatis.Location = new System.Drawing.Point(138, 56);
            this.txtsatis.Name = "txtsatis";
            this.txtsatis.Size = new System.Drawing.Size(100, 20);
            this.txtsatis.TabIndex = 2;
            // 
            // txtyeni
            // 
            this.txtyeni.Location = new System.Drawing.Point(138, 91);
            this.txtyeni.Name = "txtyeni";
            this.txtyeni.Size = new System.Drawing.Size(100, 20);
            this.txtyeni.TabIndex = 2;
            // 
            // txttarih
            // 
            this.txttarih.Location = new System.Drawing.Point(138, 126);
            this.txttarih.Name = "txttarih";
            this.txttarih.Size = new System.Drawing.Size(100, 20);
            this.txttarih.TabIndex = 2;
            // 
            // frmFiyatDegisikligi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 236);
            this.Controls.Add(this.txttarih);
            this.Controls.Add(this.txtyeni);
            this.Controls.Add(this.txtsatis);
            this.Controls.Add(this.txtbarkod);
            this.Controls.Add(this.btnuygula);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmFiyatDegisikligi";
            this.Text = "Hızlı Fiyat Değişikliği";
            this.Load += new System.EventHandler(this.frmFiyatDegisikligi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnuygula;
        private System.Windows.Forms.TextBox txtbarkod;
        private System.Windows.Forms.TextBox txtsatis;
        private System.Windows.Forms.TextBox txtyeni;
        private System.Windows.Forms.TextBox txttarih;
    }
}