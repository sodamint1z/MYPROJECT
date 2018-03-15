namespace HomeScale.view.master
{
    partial class MenuMaster
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
            this.btnDataProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDataProduct
            // 
            this.btnDataProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDataProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDataProduct.Font = new System.Drawing.Font("TH SarabunPSK", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnDataProduct.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDataProduct.Location = new System.Drawing.Point(77, 97);
            this.btnDataProduct.Name = "btnDataProduct";
            this.btnDataProduct.Size = new System.Drawing.Size(180, 100);
            this.btnDataProduct.TabIndex = 11;
            this.btnDataProduct.Text = "ฐานข้อมูลสินค้า";
            this.btnDataProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDataProduct.UseVisualStyleBackColor = false;
            this.btnDataProduct.Click += new System.EventHandler(this.btnDataProduct_Click);
            // 
            // MenuMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1008, 481);
            this.Controls.Add(this.btnDataProduct);
            this.Name = "MenuMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeScale";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDataProduct;
    }
}