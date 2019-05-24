namespace PaknampoScale.view.master
{
    partial class MST002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MST002));
            this.txtProductUnitName = new System.Windows.Forms.TextBox();
            this.lblProductUnitName = new System.Windows.Forms.Label();
            this.lblHead = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCountData = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductUnitId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProductUnitName
            // 
            this.txtProductUnitName.BackColor = System.Drawing.SystemColors.Window;
            this.txtProductUnitName.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtProductUnitName.Location = new System.Drawing.Point(665, 57);
            this.txtProductUnitName.MaxLength = 50;
            this.txtProductUnitName.Multiline = true;
            this.txtProductUnitName.Name = "txtProductUnitName";
            this.txtProductUnitName.Size = new System.Drawing.Size(300, 33);
            this.txtProductUnitName.TabIndex = 2;
            // 
            // lblProductUnitName
            // 
            this.lblProductUnitName.AutoSize = true;
            this.lblProductUnitName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductUnitName.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.lblProductUnitName.Location = new System.Drawing.Point(513, 57);
            this.lblProductUnitName.Name = "lblProductUnitName";
            this.lblProductUnitName.Size = new System.Drawing.Size(127, 33);
            this.lblProductUnitName.TabIndex = 3;
            this.lblProductUnitName.Text = "ชื่อหน่วยสินค้า* :";
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.BackColor = System.Drawing.Color.Transparent;
            this.lblHead.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.lblHead.Location = new System.Drawing.Point(403, 3);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(204, 33);
            this.lblHead.TabIndex = 16;
            this.lblHead.Text = "MST002 : ข้อมูลหน่วยสินค้า";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 254);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 260);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblCountData
            // 
            this.lblCountData.AutoSize = true;
            this.lblCountData.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Bold);
            this.lblCountData.Location = new System.Drawing.Point(787, 226);
            this.lblCountData.Name = "lblCountData";
            this.lblCountData.Size = new System.Drawing.Size(65, 22);
            this.lblCountData.TabIndex = 18;
            this.lblCountData.Text = "CountData";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(330, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 70);
            this.btnSave.TabIndex = 21;
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
            this.btnCancel.Location = new System.Drawing.Point(440, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 70);
            this.btnCancel.TabIndex = 20;
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
            this.btnDelete.Location = new System.Drawing.Point(550, 151);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 70);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(35, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 33);
            this.label1.TabIndex = 23;
            this.label1.Text = "รหัสหน่วยสินค้า* :";
            // 
            // txtProductUnitId
            // 
            this.txtProductUnitId.BackColor = System.Drawing.SystemColors.Window;
            this.txtProductUnitId.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F);
            this.txtProductUnitId.Location = new System.Drawing.Point(196, 57);
            this.txtProductUnitId.MaxLength = 10;
            this.txtProductUnitId.Multiline = true;
            this.txtProductUnitId.Name = "txtProductUnitId";
            this.txtProductUnitId.Size = new System.Drawing.Size(300, 33);
            this.txtProductUnitId.TabIndex = 1;
            // 
            // MST002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1008, 526);
            this.Controls.Add(this.txtProductUnitId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblCountData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.txtProductUnitName);
            this.Controls.Add(this.lblProductUnitName);
            this.Name = "MST002";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ข้อมูลหน่วยสินค้า";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductUnitName;
        private System.Windows.Forms.Label lblProductUnitName;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCountData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductUnitId;
    }
}