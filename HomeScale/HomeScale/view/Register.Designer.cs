﻿namespace PaknampoScale.view
{
    partial class Register
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
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.txtRegister = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDigit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtSerialNo.Location = new System.Drawing.Point(133, 100);
            this.txtSerialNo.MaxLength = 100;
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.ReadOnly = true;
            this.txtSerialNo.Size = new System.Drawing.Size(300, 31);
            this.txtSerialNo.TabIndex = 1;
            // 
            // txtRegister
            // 
            this.txtRegister.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtRegister.Location = new System.Drawing.Point(133, 145);
            this.txtRegister.MaxLength = 100;
            this.txtRegister.Name = "txtRegister";
            this.txtRegister.Size = new System.Drawing.Size(300, 31);
            this.txtRegister.TabIndex = 0;
            this.txtRegister.TextChanged += new System.EventHandler(this.txtRegister_TextChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Location = new System.Drawing.Point(133, 204);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(109, 70);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "ลงทะเบียน";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(287, 204);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(146, 70);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "ออกจากโปรแกรม";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // lblDigit
            // 
            this.lblDigit.AutoSize = true;
            this.lblDigit.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Bold);
            this.lblDigit.Location = new System.Drawing.Point(449, 152);
            this.lblDigit.Name = "lblDigit";
            this.lblDigit.Size = new System.Drawing.Size(46, 18);
            this.lblDigit.TabIndex = 4;
            this.lblDigit.Text = "ตัวอักษร";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.lblDigit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtRegister);
            this.Controls.Add(this.txtSerialNo);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaknampoScale";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.TextBox txtRegister;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDigit;
    }
}