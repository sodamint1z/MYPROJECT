namespace HomeScale.view.master
{
    partial class MST005
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MST005));
            this.txtCarRegistertionName = new System.Windows.Forms.TextBox();
            this.lblCarRegistertionName = new System.Windows.Forms.Label();
            this.lblCarRegistertionVendorId = new System.Windows.Forms.Label();
            this.cboCarRegistertionVendorId = new System.Windows.Forms.ComboBox();
            this.lblHead = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCarRegistertionId = new System.Windows.Forms.TextBox();
            this.lblCarRegistertionId = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblCountData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCarRegistertionName
            // 
            this.txtCarRegistertionName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCarRegistertionName.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtCarRegistertionName.Location = new System.Drawing.Point(651, 95);
            this.txtCarRegistertionName.MaxLength = 50;
            this.txtCarRegistertionName.Multiline = true;
            this.txtCarRegistertionName.Name = "txtCarRegistertionName";
            this.txtCarRegistertionName.Size = new System.Drawing.Size(300, 33);
            this.txtCarRegistertionName.TabIndex = 1;
            // 
            // lblCarRegistertionName
            // 
            this.lblCarRegistertionName.AutoSize = true;
            this.lblCarRegistertionName.BackColor = System.Drawing.Color.Transparent;
            this.lblCarRegistertionName.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.lblCarRegistertionName.Location = new System.Drawing.Point(533, 98);
            this.lblCarRegistertionName.Name = "lblCarRegistertionName";
            this.lblCarRegistertionName.Size = new System.Drawing.Size(101, 33);
            this.lblCarRegistertionName.TabIndex = 5;
            this.lblCarRegistertionName.Text = "ทะเบียนรถ* :";
            // 
            // lblCarRegistertionVendorId
            // 
            this.lblCarRegistertionVendorId.AutoSize = true;
            this.lblCarRegistertionVendorId.BackColor = System.Drawing.Color.Transparent;
            this.lblCarRegistertionVendorId.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.lblCarRegistertionVendorId.Location = new System.Drawing.Point(99, 142);
            this.lblCarRegistertionVendorId.Name = "lblCarRegistertionVendorId";
            this.lblCarRegistertionVendorId.Size = new System.Drawing.Size(88, 33);
            this.lblCarRegistertionVendorId.TabIndex = 7;
            this.lblCarRegistertionVendorId.Text = "ชื่อผู้ขาย* :";
            // 
            // cboCarRegistertionVendorId
            // 
            this.cboCarRegistertionVendorId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarRegistertionVendorId.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F);
            this.cboCarRegistertionVendorId.FormattingEnabled = true;
            this.cboCarRegistertionVendorId.Location = new System.Drawing.Point(207, 141);
            this.cboCarRegistertionVendorId.MaxLength = 100;
            this.cboCarRegistertionVendorId.Name = "cboCarRegistertionVendorId";
            this.cboCarRegistertionVendorId.Size = new System.Drawing.Size(300, 34);
            this.cboCarRegistertionVendorId.TabIndex = 2;
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.BackColor = System.Drawing.Color.Transparent;
            this.lblHead.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.lblHead.Location = new System.Drawing.Point(374, 42);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(243, 33);
            this.lblHead.TabIndex = 23;
            this.lblHead.Text = "MST005 : ข้อมูลกำหนดทะเบียนรถ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 290);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 324);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtCarRegistertionId
            // 
            this.txtCarRegistertionId.BackColor = System.Drawing.SystemColors.Window;
            this.txtCarRegistertionId.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtCarRegistertionId.Location = new System.Drawing.Point(207, 95);
            this.txtCarRegistertionId.MaxLength = 10;
            this.txtCarRegistertionId.Multiline = true;
            this.txtCarRegistertionId.Name = "txtCarRegistertionId";
            this.txtCarRegistertionId.Size = new System.Drawing.Size(300, 33);
            this.txtCarRegistertionId.TabIndex = 0;
            // 
            // lblCarRegistertionId
            // 
            this.lblCarRegistertionId.AutoSize = true;
            this.lblCarRegistertionId.BackColor = System.Drawing.Color.Transparent;
            this.lblCarRegistertionId.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.lblCarRegistertionId.Location = new System.Drawing.Point(58, 98);
            this.lblCarRegistertionId.Name = "lblCarRegistertionId";
            this.lblCarRegistertionId.Size = new System.Drawing.Size(129, 33);
            this.lblCarRegistertionId.TabIndex = 25;
            this.lblCarRegistertionId.Text = "รหัสทะเบียนรถ* :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(330, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 70);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "บันทึก";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGreen;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(440, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 70);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(550, 190);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 70);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCountData
            // 
            this.lblCountData.AutoSize = true;
            this.lblCountData.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Bold);
            this.lblCountData.Location = new System.Drawing.Point(776, 265);
            this.lblCountData.Name = "lblCountData";
            this.lblCountData.Size = new System.Drawing.Size(65, 22);
            this.lblCountData.TabIndex = 31;
            this.lblCountData.Text = "CountData";
            // 
            // MST005
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1008, 626);
            this.Controls.Add(this.lblCountData);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtCarRegistertionId);
            this.Controls.Add(this.lblCarRegistertionId);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.cboCarRegistertionVendorId);
            this.Controls.Add(this.lblCarRegistertionVendorId);
            this.Controls.Add(this.txtCarRegistertionName);
            this.Controls.Add(this.lblCarRegistertionName);
            this.Name = "MST005";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลกำหนดทะเบียนรถ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCarRegistertionName;
        private System.Windows.Forms.Label lblCarRegistertionName;
        private System.Windows.Forms.Label lblCarRegistertionVendorId;
        private System.Windows.Forms.ComboBox cboCarRegistertionVendorId;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCarRegistertionId;
        private System.Windows.Forms.Label lblCarRegistertionId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCountData;
    }
}