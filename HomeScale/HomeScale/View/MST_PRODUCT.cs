using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeScale.src.model.entities;
using HomeScale.src.controller;
using HomeScale.src.model.form;
using HomeScale.src.util;
using log4net;

namespace HomeScale.View
{
    public partial class MST_PRODUCT : Form
    {
        public MST_PRODUCT()
        {
            InitializeComponent();
            queryComboMstProductUnit();
            searchDataVwMstProduct();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void queryComboMstProductUnit()
        {
            MstProductController mstProductCtrl = new MstProductController();
            try
            {
                var result = mstProductCtrl.queryComboMstProductUnit();

                var statusError = result[0];
                var msgError = result[1];
                var data = result[2];

                if (statusError.Equals(1))
                {
                    cboProductUnit.ValueMember = "PRODUCT_UNIT_ID";
                    cboProductUnit.DisplayMember = "PRODUCT_UNIT_NAME";
                    cboProductUnit.DataSource = data;

                    cboProductUnit.SelectedValue = "PRODUCT_UNIT_ID";
                }
                else
                {
                    MessageBox.Show("Error : " + msgError);
                }
            }
            catch (Exception ex) 
            {
                Log.Error(ex.ToString(), ex);
            }
        }

        public void searchDataVwMstProduct()
        {
            MstProductController mstProductCtrl = new MstProductController();
            try
            {
                var result = mstProductCtrl.searchDataVwMstProduct();

                var statusError = result[0];
                var msgError = result[1];
                var data = result[2];
                var countData = result[3];

                if (statusError.Equals(1))
                {
                    dataGridView1.DataSource = data;
                    dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 18);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 18, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสสินค้า";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อสินค้า";
                    dataGridView1.Columns[2].HeaderCell.Value = "รหัสหน่วยสินค้า";
                    dataGridView1.Columns[3].HeaderCell.Value = "ชื่อหน่วยสินค้า";
                    //dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 16, FontStyle.Bold);
                    lblCountData.Text = "แสดงข้อมูลทั้งหมด " + countData + " รายการ";
                }
                else
                {
                    MessageBox.Show("Error : " + msgError);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
            }
        }
    }
}
