namespace YazilimSınamaProje
{
    partial class Form3
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
            this.dt_rapor = new System.Windows.Forms.DataGridView();
            this.btn_rapor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_rapor_odaadi = new System.Windows.Forms.ComboBox();
            this.btn_rapor_goster = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dt_rapor)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_rapor
            // 
            this.dt_rapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_rapor.Location = new System.Drawing.Point(13, 13);
            this.dt_rapor.Name = "dt_rapor";
            this.dt_rapor.Size = new System.Drawing.Size(317, 409);
            this.dt_rapor.TabIndex = 0;
            // 
            // btn_rapor
            // 
            this.btn_rapor.Location = new System.Drawing.Point(372, 198);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.Size = new System.Drawing.Size(117, 48);
            this.btn_rapor.TabIndex = 1;
            this.btn_rapor.Text = "Rapor Çıkar";
            this.btn_rapor.UseVisualStyleBackColor = true;
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Oda Adı";
            // 
            // cmb_rapor_odaadi
            // 
            this.cmb_rapor_odaadi.FormattingEnabled = true;
            this.cmb_rapor_odaadi.Location = new System.Drawing.Point(387, 76);
            this.cmb_rapor_odaadi.Name = "cmb_rapor_odaadi";
            this.cmb_rapor_odaadi.Size = new System.Drawing.Size(116, 21);
            this.cmb_rapor_odaadi.TabIndex = 3;
            // 
            // btn_rapor_goster
            // 
            this.btn_rapor_goster.Location = new System.Drawing.Point(372, 138);
            this.btn_rapor_goster.Name = "btn_rapor_goster";
            this.btn_rapor_goster.Size = new System.Drawing.Size(117, 43);
            this.btn_rapor_goster.TabIndex = 4;
            this.btn_rapor_goster.Text = "Rapor göster";
            this.btn_rapor_goster.UseVisualStyleBackColor = true;
            this.btn_rapor_goster.Click += new System.EventHandler(this.btn_rapor_goster_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 434);
            this.Controls.Add(this.btn_rapor_goster);
            this.Controls.Add(this.cmb_rapor_odaadi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.dt_rapor);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_rapor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_rapor;
        private System.Windows.Forms.Button btn_rapor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_rapor_odaadi;
        private System.Windows.Forms.Button btn_rapor_goster;
    }
}