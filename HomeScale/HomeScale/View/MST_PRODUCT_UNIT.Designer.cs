namespace HomeScale.View
{
    partial class MST_PRODUCT_UNIT
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
            this.txtProductUnitName = new System.Windows.Forms.TextBox();
            this.lblProductUnitName = new System.Windows.Forms.Label();
            this.lblHead = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblCountData = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductUnitId = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatuslblCredit = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProductUnitName
            // 
            this.txtProductUnitName.BackColor = System.Drawing.SystemColors.Window;
            this.txtProductUnitName.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductUnitName.Location = new System.Drawing.Point(652, 182);
            this.txtProductUnitName.MaxLength = 50;
            this.txtProductUnitName.Multiline = true;
            this.txtProductUnitName.Name = "txtProductUnitName";
            this.txtProductUnitName.Size = new System.Drawing.Size(300, 40);
            this.txtProductUnitName.TabIndex = 2;
            // 
            // lblProductUnitName
            // 
            this.lblProductUnitName.AutoSize = true;
            this.lblProductUnitName.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblProductUnitName.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductUnitName.Location = new System.Drawing.Point(500, 185);
            this.lblProductUnitName.Name = "lblProductUnitName";
            this.lblProductUnitName.Size = new System.Drawing.Size(138, 29);
            this.lblProductUnitName.TabIndex = 3;
            this.lblProductUnitName.Text = "ชื่อหน่วยสินค้า :";
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblHead.Font = new System.Drawing.Font("Verdana", 18F);
            this.lblHead.Location = new System.Drawing.Point(436, 42);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(150, 29);
            this.lblHead.TabIndex = 16;
            this.lblHead.Text = "ข้อมูลหน่วยสินค้า";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 314);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 300);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblCountData
            // 
            this.lblCountData.AutoSize = true;
            this.lblCountData.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountData.Location = new System.Drawing.Point(775, 286);
            this.lblCountData.Name = "lblCountData";
            this.lblCountData.Size = new System.Drawing.Size(95, 18);
            this.lblCountData.TabIndex = 18;
            this.lblCountData.Text = "CountData";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Wheat;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.Font = new System.Drawing.Font("Verdana", 18F);
            this.btnBack.Location = new System.Drawing.Point(684, 90);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 80);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "ย้อนกลับ";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 18F);
            this.btnSave.Location = new System.Drawing.Point(174, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 80);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGreen;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 18F);
            this.btnCancel.Location = new System.Drawing.Point(344, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 80);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Salmon;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 18F);
            this.btnDelete.Location = new System.Drawing.Point(514, 90);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 80);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "รหัสหน่วยสินค้า :";
            // 
            // txtProductUnitId
            // 
            this.txtProductUnitId.BackColor = System.Drawing.SystemColors.Window;
            this.txtProductUnitId.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductUnitId.Location = new System.Drawing.Point(184, 182);
            this.txtProductUnitId.MaxLength = 50;
            this.txtProductUnitId.Multiline = true;
            this.txtProductUnitId.Name = "txtProductUnitId";
            this.txtProductUnitId.Size = new System.Drawing.Size(300, 40);
            this.txtProductUnitId.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatuslblCredit});
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatuslblCredit
            // 
            this.toolStripStatuslblCredit.Name = "toolStripStatuslblCredit";
            this.toolStripStatuslblCredit.Size = new System.Drawing.Size(263, 17);
            this.toolStripStatuslblCredit.Text = "Copyright©2018  Credit : Pro. All rights reserved.";
            // 
            // MST_PRODUCT_UNIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtProductUnitId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblCountData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblHead);
            this.Controls.Add(this.txtProductUnitName);
            this.Controls.Add(this.lblProductUnitName);
            this.Name = "MST_PRODUCT_UNIT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeScale";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductUnitName;
        private System.Windows.Forms.Label lblProductUnitName;
        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblCountData;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductUnitId;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslblCredit;
    }
}