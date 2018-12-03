namespace CountriesWindowsForms_Api
{
    partial class Form1
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
            this.cob_names_countries = new System.Windows.Forms.ComboBox();
            this.picCountry = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCountry)).BeginInit();
            this.SuspendLayout();
            // 
            // cob_names_countries
            // 
            this.cob_names_countries.FormattingEnabled = true;
            this.cob_names_countries.Location = new System.Drawing.Point(116, 65);
            this.cob_names_countries.Name = "cob_names_countries";
            this.cob_names_countries.Size = new System.Drawing.Size(121, 21);
            this.cob_names_countries.TabIndex = 0;
            this.cob_names_countries.SelectedIndexChanged += new System.EventHandler(this.cob_names_countries_SelectedIndexChanged);
            // 
            // picCountry
            // 
            this.picCountry.Location = new System.Drawing.Point(63, 115);
            this.picCountry.Name = "picCountry";
            this.picCountry.Size = new System.Drawing.Size(246, 183);
            this.picCountry.TabIndex = 1;
            this.picCountry.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picCountry);
            this.Controls.Add(this.cob_names_countries);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCountry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cob_names_countries;
        private System.Windows.Forms.PictureBox picCountry;
    }
}

