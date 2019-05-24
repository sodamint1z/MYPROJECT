using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaknampoScale.src.model.entities;
using PaknampoScale.src.controller;
using PaknampoScale.src.model.form;
using PaknampoScale.src.util;
using log4net;

namespace PaknampoScale.view.master
{
    public partial class MST001 : Form
    {
        public MST001()
        {
            InitializeComponent();
            queryComboMstProductUnit();
            searchDataVwMstProduct();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_PRODUCT formMstProduct = new MST_PRODUCT();
        string flagAddEdit = "A";
        public void resetDataMstProduct()
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            cboProductUnit.SelectedValue = "1";
            formMstProduct = new MST_PRODUCT();
            flagAddEdit = "A";
            txtProductId.Enabled = true;
            txtProductId.Focus();
        }

        public void queryComboMstProductUnit()
        {
            MST001Controller mst001Ctrl = new MST001Controller();
            try
            {
                object[] result = mst001Ctrl.queryComboMstProductUnit();

                MsgForm msgForm = (MsgForm)result[0];
                List<MST_PRODUCT_UNIT> lstdata = (List<MST_PRODUCT_UNIT>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboProductUnit.DataSource = lstdata;
                    cboProductUnit.ValueMember = "PRODUCT_UNIT_ID";
                    cboProductUnit.DisplayMember = "PRODUCT_UNIT_NAME";
                    cboProductUnit.SelectedValue = "1";
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex) 
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void searchDataVwMstProduct()
        {
            MST001Controller mst001Ctrl = new MST001Controller();
            try
            {
                object[] result = mst001Ctrl.searchDataVwMstProduct();

                MsgForm msgForm = (MsgForm)result[0];
                List<VW_MST_PRODUCT> lstdata = (List<VW_MST_PRODUCT>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    dataGridView1.DataSource = lstdata;
                    dataGridView1.DefaultCellStyle.Font = new Font("TH SarabunPSK", 16);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("TH SarabunPSK", 16, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสสินค้า";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อสินค้า";
                    dataGridView1.Columns[2].HeaderCell.Value = "ชื่อหน่วยสินค้า";
                    lblCountData.Text = "แสดงข้อมูลทั้งหมด " + lstdata.Count() +" รายการ";
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryDataMstProductByProductId()
        {
            MST001Controller mst001Ctrl = new MST001Controller();
            try
            {
                object[] result = mst001Ctrl.queryDataMstProductByProductId(formMstProduct);
                
                MsgForm msgForm = (MsgForm)result[0];
                MST_PRODUCT data = (MST_PRODUCT)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        txtProductId.Text = data.PRODUCT_ID;
                        txtProductName.Text = data.PRODUCT_NAME;
                        cboProductUnit.SelectedValue = data.PRODUCT_UNIT.ToString();
                        formMstProduct = data;
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void insertOrUpdateDataMstProduct()
        {
            MST001Controller mst001Ctrl = new MST001Controller();
            MST_PRODUCT form = new MST_PRODUCT();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (Util.isEmpty(txtProductId.Text) 
                    || Util.isEmpty(txtProductName.Text) 
                    || Util.isEmpty(cboProductUnit.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.PRODUCT_ID = txtProductId.Text;
                form.PRODUCT_NAME = txtProductName.Text;
                form.PRODUCT_UNIT = Int32.Parse(cboProductUnit.SelectedValue.ToString());

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mst001Ctrl.insertOrUpdateDataMstProduct(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                MST_PRODUCT data = (MST_PRODUCT)result[1];

                if (flagAddEdit.Equals("A"))
                {
                    if (Util.isNotEmpty(data))
                    {
                        if (msgForm.statusFlag.Equals(1))
                        {
                            MessageBox.Show(CommonUtil.DUPLICATE_DATA);
                        }
                        else
                        {
                            MessageBox.Show("Error : " + msgForm.messageDescription);
                        }
                    }
                    else
                    {
                        if (msgForm.statusFlag.Equals(1))
                        {
                            resetDataMstProduct();
                            searchDataVwMstProduct();
                            MessageBox.Show(CommonUtil.SAVE_DATA_SUCCESS);
                        }
                        else
                        {
                            MessageBox.Show("Error : " + msgForm.messageDescription);
                        }
                    }
                }
                else if (flagAddEdit.Equals("E"))
                {
                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstProduct();
                        searchDataVwMstProduct();
                        MessageBox.Show(CommonUtil.SAVE_DATA_SUCCESS);
                    }
                    else
                    {
                        MessageBox.Show("Error : " + msgForm.messageDescription);
                    }    
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void deleteDataMstProduct()
        {
            MST001Controller mst001Ctrl = new MST001Controller();
            MST_PRODUCT form = new MST_PRODUCT();
            try
            {
                form.PRODUCT_ID = txtProductId.Text;

                if (Util.isEmpty(form.PRODUCT_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mst001Ctrl.deleteDataMstProduct(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstProduct();
                        searchDataVwMstProduct();
                        MessageBox.Show(CommonUtil.DELETE_DATA_SUCCESS);
                    }
                    else
                    {
                        MessageBox.Show("Error : " + msgForm.messageDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                formMstProduct.PRODUCT_ID = row.Cells[0].Value.ToString();
                queryDataMstProductByProductId();
                flagAddEdit = "E";
                txtProductId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataMstProduct();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataMstProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataMstProduct();
        }
    }
}
