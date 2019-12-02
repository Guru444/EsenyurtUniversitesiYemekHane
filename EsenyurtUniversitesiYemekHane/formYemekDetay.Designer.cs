namespace EsenyurtUniversitesiYemekHane
{
    partial class formYemekDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formYemekDetay));
            this.lblKalori = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblYemekAdi = new System.Windows.Forms.Label();
            this.lblIcerik = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblKalori
            // 
            this.lblKalori.AutoSize = true;
            this.lblKalori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKalori.Location = new System.Drawing.Point(15, 262);
            this.lblKalori.Name = "lblKalori";
            this.lblKalori.Size = new System.Drawing.Size(0, 20);
            this.lblKalori.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblYemekAdi);
            this.panel1.Controls.Add(this.lblIcerik);
            this.panel1.Location = new System.Drawing.Point(12, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 233);
            this.panel1.TabIndex = 2;
            // 
            // lblYemekAdi
            // 
            this.lblYemekAdi.AutoSize = true;
            this.lblYemekAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYemekAdi.Location = new System.Drawing.Point(12, 0);
            this.lblYemekAdi.Name = "lblYemekAdi";
            this.lblYemekAdi.Size = new System.Drawing.Size(0, 20);
            this.lblYemekAdi.TabIndex = 4;
            // 
            // lblIcerik
            // 
            this.lblIcerik.AutoSize = true;
            this.lblIcerik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIcerik.Location = new System.Drawing.Point(12, 34);
            this.lblIcerik.Name = "lblIcerik";
            this.lblIcerik.Size = new System.Drawing.Size(0, 20);
            this.lblIcerik.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(248, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 41);
            this.button1.TabIndex = 11;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formYemekDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblKalori);
            this.Controls.Add(this.panel1);
            this.Name = "formYemekDetay";
            this.Text = "Yemek Detay";
            this.Load += new System.EventHandler(this.formYemekDetay_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKalori;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblYemekAdi;
        private System.Windows.Forms.Label lblIcerik;
        private System.Windows.Forms.Button button1;
    }
}