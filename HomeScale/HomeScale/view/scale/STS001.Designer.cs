namespace HomeScale.view.scale
{
    partial class STS001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STS001));
            this.lblHead = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.lblProductUnit = new System.Windows.Forms.Label();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbDigital = new System.Windows.Forms.RichTextBox();
            this.chkStatusConnectScale = new System.Windows.Forms.CheckBox();
            this.cboHandShaking = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbConnection = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.BackColor = System.Drawing.Color.Transparent;
            this.lblHead.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.lblHead.Location = new System.Drawing.Point(414, 42);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(196, 33);
            this.lblHead.TabIndex = 92;
            this.lblHead.Text = "STS001 : ปรับแต่งเครื่องชั่ง";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(395, 501);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 70);
            this.btnSave.TabIndex = 95;
            this.btnSave.Text = "บันทึก";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGreen;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(505, 501);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 70);
            this.btnCancel.TabIndex = 94;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Pink;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBack.Location = new System.Drawing.Point(887, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(109, 70);
            this.btnBack.TabIndex = 96;
            this.btnBack.Text = "ย้อนกลับ";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // cboPorts
            // 
            this.cboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPorts.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F);
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(297, 105);
            this.cboPorts.MaxLength = 50;
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(150, 34);
            this.cboPorts.TabIndex = 98;
            this.cboPorts.SelectedIndexChanged += new System.EventHandler(this.cboPorts_SelectedIndexChanged);
            // 
            // lblProductUnit
            // 
            this.lblProductUnit.AutoSize = true;
            this.lblProductUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblProductUnit.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.lblProductUnit.Location = new System.Drawing.Point(215, 107);
            this.lblProductUnit.Name = "lblProductUnit";
            this.lblProductUnit.Size = new System.Drawing.Size(76, 33);
            this.lblProductUnit.TabIndex = 97;
            this.lblProductUnit.Text = "PortNo :";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaudRate.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F);
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Location = new System.Drawing.Point(297, 155);
            this.cboBaudRate.MaxLength = 50;
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(150, 34);
            this.cboBaudRate.TabIndex = 100;
            this.cboBaudRate.SelectedIndexChanged += new System.EventHandler(this.cboBaudRate_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(195, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 33);
            this.label1.TabIndex = 99;
            this.label1.Text = "BaudRate :";
            // 
            // cboDataBits
            // 
            this.cboDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDataBits.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F);
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Location = new System.Drawing.Point(297, 205);
            this.cboDataBits.MaxLength = 50;
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(150, 34);
            this.cboDataBits.TabIndex = 102;
            this.cboDataBits.SelectedIndexChanged += new System.EventHandler(this.cboDataBits_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(212, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 101;
            this.label2.Text = "DataBit :";
            // 
            // cboParity
            // 
            this.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParity.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F);
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(622, 157);
            this.cboParity.MaxLength = 50;
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(150, 34);
            this.cboParity.TabIndex = 104;
            this.cboParity.SelectedIndexChanged += new System.EventHandler(this.cboParity_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(549, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 33);
            this.label3.TabIndex = 103;
            this.label3.Text = "Parity :";
            // 
            // cboStopBits
            // 
            this.cboStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStopBits.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F);
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Location = new System.Drawing.Point(622, 107);
            this.cboStopBits.MaxLength = 50;
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(150, 34);
            this.cboStopBits.TabIndex = 106;
            this.cboStopBits.SelectedIndexChanged += new System.EventHandler(this.cboStopBits_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(537, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 33);
            this.label4.TabIndex = 105;
            this.label4.Text = "StopBit :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbDigital);
            this.groupBox1.Location = new System.Drawing.Point(420, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 158);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Digital Indicator";
            // 
            // rtbDigital
            // 
            this.rtbDigital.Enabled = false;
            this.rtbDigital.Font = new System.Drawing.Font("TH SarabunPSK", 75.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rtbDigital.ForeColor = System.Drawing.Color.Red;
            this.rtbDigital.Location = new System.Drawing.Point(6, 19);
            this.rtbDigital.Name = "rtbDigital";
            this.rtbDigital.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbDigital.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDigital.Size = new System.Drawing.Size(340, 132);
            this.rtbDigital.TabIndex = 0;
            this.rtbDigital.Text = "";
            // 
            // chkStatusConnectScale
            // 
            this.chkStatusConnectScale.AutoSize = true;
            this.chkStatusConnectScale.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatusConnectScale.Location = new System.Drawing.Point(385, 435);
            this.chkStatusConnectScale.Name = "chkStatusConnectScale";
            this.chkStatusConnectScale.Size = new System.Drawing.Size(242, 37);
            this.chkStatusConnectScale.TabIndex = 127;
            this.chkStatusConnectScale.Text = "รับสัญญาณน้ำหนักจากเครื่องชั่ง";
            this.chkStatusConnectScale.UseVisualStyleBackColor = true;
            this.chkStatusConnectScale.CheckedChanged += new System.EventHandler(this.chkStatusConnectScale_CheckedChanged);
            // 
            // cboHandShaking
            // 
            this.cboHandShaking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHandShaking.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F);
            this.cboHandShaking.FormattingEnabled = true;
            this.cboHandShaking.Location = new System.Drawing.Point(622, 207);
            this.cboHandShaking.MaxLength = 50;
            this.cboHandShaking.Name = "cboHandShaking";
            this.cboHandShaking.Size = new System.Drawing.Size(150, 34);
            this.cboHandShaking.TabIndex = 129;
            this.cboHandShaking.SelectedIndexChanged += new System.EventHandler(this.cboHandShaking_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(494, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 33);
            this.label12.TabIndex = 128;
            this.label12.Text = "HandShaking :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbConnection);
            this.groupBox2.Location = new System.Drawing.Point(201, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 158);
            this.groupBox2.TabIndex = 126;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection Indicator";
            // 
            // rtbConnection
            // 
            this.rtbConnection.Enabled = false;
            this.rtbConnection.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rtbConnection.ForeColor = System.Drawing.Color.Red;
            this.rtbConnection.Location = new System.Drawing.Point(6, 19);
            this.rtbConnection.Name = "rtbConnection";
            this.rtbConnection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rtbConnection.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbConnection.Size = new System.Drawing.Size(197, 132);
            this.rtbConnection.TabIndex = 0;
            this.rtbConnection.Text = "";
            // 
            // STS001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1008, 626);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cboHandShaking);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkStatusConnectScale);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboStopBits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboParity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDataBits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPorts);
            this.Controls.Add(this.lblProductUnit);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblHead);
            this.Name = "STS001";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STS001";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.Label lblProductUnit;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkStatusConnectScale;
        private System.Windows.Forms.RichTextBox rtbDigital;
        private System.Windows.Forms.ComboBox cboHandShaking;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbConnection;
    }
}