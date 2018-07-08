namespace HomeScale.view.master
{
    partial class MST007
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MST007));
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserFirstname = new System.Windows.Forms.TextBox();
            this.txtUserLastname = new System.Windows.Forms.TextBox();
            this.cboStatusFlag = new System.Windows.Forms.ComboBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblUserFirstname = new System.Windows.Forms.Label();
            this.lblUserLastname = new System.Windows.Forms.Label();
            this.lblStatusFlag = new System.Windows.Forms.Label();
            this.lblHead = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblCountData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserId
            // 
            this.txtUserId.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserId.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtUserId.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserId.Location = new System.Drawing.Point(194, 94);
            this.txtUserId.MaxLength = 50;
            this.txtUserId.Multiline = true;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(300, 33);
            this.txtUserId.TabIndex = 59;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPassword.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtUserPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserPassword.Location = new System.Drawing.Point(630, 95);
            this.txtUserPassword.MaxLength = 50;
            this.txtUserPassword.Multiline = true;
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(300, 33);
            this.txtUserPassword.TabIndex = 60;
            // 
            // txtUserFirstname
            // 
            this.txtUserFirstname.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserFirstname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserFirstname.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtUserFirstname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserFirstname.Location = new System.Drawing.Point(195, 140);
            this.txtUserFirstname.MaxLength = 50;
            this.txtUserFirstname.Multiline = true;
            this.txtUserFirstname.Name = "txtUserFirstname";
            this.txtUserFirstname.Size = new System.Drawing.Size(300, 33);
            this.txtUserFirstname.TabIndex = 61;
            // 
            // txtUserLastname
            // 
            this.txtUserLastname.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserLastname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserLastname.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtUserLastname.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUserLastname.Location = new System.Drawing.Point(631, 140);
            this.txtUserLastname.MaxLength = 50;
            this.txtUserLastname.Multiline = true;
            this.txtUserLastname.Name = "txtUserLastname";
            this.txtUserLastname.Size = new System.Drawing.Size(300, 33);
            this.txtUserLastname.TabIndex = 62;
            // 
            // cboStatusFlag
            // 
            this.cboStatusFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusFlag.Font = new System.Drawing.Font("TH SarabunPSK", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatusFlag.FormattingEnabled = true;
            this.cboStatusFlag.IntegralHeight = false;
            this.cboStatusFlag.Location = new System.Drawing.Point(194, 185);
            this.cboStatusFlag.MaxLength = 50;
            this.cboStatusFlag.Name = "cboStatusFlag";
            this.cboStatusFlag.Size = new System.Drawing.Size(300, 34);
            this.cboStatusFlag.TabIndex = 63;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.BackColor = System.Drawing.Color.Transparent;
            this.lblUserId.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(74, 94);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(103, 33);
            this.lblUserId.TabIndex = 64;
            this.lblUserId.Text = "ชื่อผู้ใช้งาน* :";
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblUserPassword.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserPassword.Location = new System.Drawing.Point(526, 94);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(88, 33);
            this.lblUserPassword.TabIndex = 65;
            this.lblUserPassword.Text = "รหัสผ่าน* :";
            // 
            // lblUserFirstname
            // 
            this.lblUserFirstname.AutoSize = true;
            this.lblUserFirstname.BackColor = System.Drawing.Color.Transparent;
            this.lblUserFirstname.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserFirstname.Location = new System.Drawing.Point(134, 140);
            this.lblUserFirstname.Name = "lblUserFirstname";
            this.lblUserFirstname.Size = new System.Drawing.Size(43, 33);
            this.lblUserFirstname.TabIndex = 66;
            this.lblUserFirstname.Text = "ชื่อ :";
            // 
            // lblUserLastname
            // 
            this.lblUserLastname.AutoSize = true;
            this.lblUserLastname.BackColor = System.Drawing.Color.Transparent;
            this.lblUserLastname.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserLastname.Location = new System.Drawing.Point(533, 140);
            this.lblUserLastname.Name = "lblUserLastname";
            this.lblUserLastname.Size = new System.Drawing.Size(81, 33);
            this.lblUserLastname.TabIndex = 67;
            this.lblUserLastname.Text = "นามสกุล :";
            // 
            // lblStatusFlag
            // 
            this.lblStatusFlag.AutoSize = true;
            this.lblStatusFlag.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusFlag.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusFlag.Location = new System.Drawing.Point(34, 186);
            this.lblStatusFlag.Name = "lblStatusFlag";
            this.lblStatusFlag.Size = new System.Drawing.Size(143, 33);
            this.lblStatusFlag.TabIndex = 68;
            this.lblStatusFlag.Text = "แสดงหน้าล็อกอิน* :";
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.BackColor = System.Drawing.Color.Transparent;
            this.lblHead.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.Location = new System.Drawing.Point(380, 42);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(216, 33);
            this.lblHead.TabIndex = 69;
            this.lblHead.Text = "MST007 : ข้อมูลผู้ใช้งานระบบ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(57, 339);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(885, 275);
            this.dataGridView1.TabIndex = 70;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(330, 235);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 70);
            this.btnSave.TabIndex = 74;
            this.btnSave.Text = "บันทึก";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGreen;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(440, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 70);
            this.btnCancel.TabIndex = 73;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(550, 235);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 70);
            this.btnDelete.TabIndex = 72;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCountData
            // 
            this.lblCountData.AutoSize = true;
            this.lblCountData.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountData.Location = new System.Drawing.Point(800, 310);
            this.lblCountData.Name = "lblCountData";
            this.lblCountData.Size = new System.Drawing.Size(65, 22);
            this.lblCountData.TabIndex = 76;
            this.lblCountData.Text = "CountData";
            // 
            // MST007
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1008, 626);
            this.Controls.Add(this.lblCountData);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.lblStatusFlag);
            this.Controls.Add(this.lblUserLastname);
            this.Controls.Add(this.lblUserFirstname);
            this.Controls.Add(this.lblUserPassword);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.cboStatusFlag);
            this.Controls.Add(this.txtUserLastname);
            this.Controls.Add(this.txtUserFirstname);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.txtUserId);
            this.Name = "MST007";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลผู้ใช้งานระบบ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserFirstname;
        private System.Windows.Forms.TextBox txtUserLastname;
        private System.Windows.Forms.ComboBox cboStatusFlag;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Label lblUserFirstname;
        private System.Windows.Forms.Label lblUserLastname;
        private System.Windows.Forms.Label lblStatusFlag;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCountData;
    }
}