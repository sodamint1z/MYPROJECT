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

namespace HomeScale.view.master
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
        HomeScale.src.model.entities.MST_PRODUCT formMstProduct = new src.model.entities.MST_PRODUCT();
        string flagAddEdit = "A";
        public void resetDataMstProduct()
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            cboProductUnit.SelectedValue = "1";
            formMstProduct.PRODUCT_ID = "";
            formMstProduct.PRODUCT_NAME = "";
            formMstProduct.PRODUCT_UNIT = Int32.Parse("0");
            flagAddEdit = "A";
            txtProductId.Enabled = true;
            txtProductId.Focus();
        }

        public void queryComboMstProductUnit()
        {
            MstProductController mstProductCtrl = new MstProductController();
            try
            {
                object[] result = mstProductCtrl.queryComboMstProductUnit();

                //var statusError = result[0];
                //var msgError = result[1];
                MsgForm msgForm = (MsgForm)result[0];
                List<HomeScale.src.model.entities.MST_PRODUCT_UNIT> lstdata = (List<src.model.entities.MST_PRODUCT_UNIT>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboProductUnit.DataSource = lstdata;
                    cboProductUnit.ValueMember = "PRODUCT_UNIT_ID";
                    cboProductUnit.DisplayMember = "PRODUCT_UNIT_NAME";

                    cboProductUnit.SelectedValue = "1";
                    //cboProductUnit.SelectedItem = "PRODUCT_UNIT_ID";

                    //MessageBox.Show(cboProductUnit.SelectedValue.ToString());

                    //cboProductUnit.SelectedValue = "1";
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
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
                object[] result = mstProductCtrl.searchDataVwMstProduct();

                //var statusError = result[0];
                //var msgError = result[1];
                MsgForm msgForm = (MsgForm)result[0];
                List<HomeScale.src.model.entities.VW_MST_PRODUCT> lstdata = (List<src.model.entities.VW_MST_PRODUCT>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    dataGridView1.DataSource = lstdata;
                    dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 18);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 18, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสสินค้า";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อสินค้า";
                    dataGridView1.Columns[2].HeaderCell.Value = "ชื่อหน่วยสินค้า";
                    //dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 16, FontStyle.Bold);
                    lblCountData.Text = "แสดงข้อมูลทั้งหมด " + lstdata.Count() +" รายการ";
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
            }
        }

        public void queryDataMstProductByProductId()
        {
            MstProductController mstProductCtrl = new MstProductController();
            try
            {
                //formMstProduct.PRODUCT_ID = "1";
                //MessageBox.Show(formMstProduct.PRODUCT_ID);
                object[] result = mstProductCtrl.queryDataMstProductByProductId(formMstProduct);
                
                //var statusError = result[0];
                //var msgError = result[1];
                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_PRODUCT data = (src.model.entities.MST_PRODUCT)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (CheckUtil.isNotEmpty(result))
                    {
                        txtProductId.Text = data.PRODUCT_ID;
                        txtProductName.Text = data.PRODUCT_NAME;
                        string convertProductUnitToString = data.PRODUCT_UNIT.ToString();
                        cboProductUnit.SelectedValue = convertProductUnitToString;
                        formMstProduct.PRODUCT_ID = data.PRODUCT_ID;
                        formMstProduct.PRODUCT_NAME = data.PRODUCT_NAME;
                        formMstProduct.PRODUCT_UNIT = data.PRODUCT_UNIT;
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
            }
        }

        public void insertOrUpdateDataMstProduct()
        {
            MstProductController mstProductCtrl = new MstProductController();
            HomeScale.src.model.entities.MST_PRODUCT form = new src.model.entities.MST_PRODUCT();
            try
            {
                if (CheckUtil.isEmpty(txtProductId.Text) 
                    || CheckUtil.isEmpty(txtProductName.Text) 
                    || CheckUtil.isEmpty(cboProductUnit.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.PRODUCT_ID = txtProductId.Text;
                form.PRODUCT_NAME = txtProductName.Text;
                form.PRODUCT_UNIT = Int32.Parse(cboProductUnit.SelectedValue.ToString());

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                object[] result = mstProductCtrl.insertOrUpdateDataMstProduct(form, flagAddEdit);

                //var statusError = result[0];
                //var msgError = result[1];
                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_PRODUCT data = (src.model.entities.MST_PRODUCT)result[1];

                if (flagAddEdit.Equals("A"))
                {
                    if (CheckUtil.isNotEmpty(data))
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
                Log.Error(ex.ToString(), ex);
            }
        }

        public void deleteDataMstProduct()
        {
            MstProductController mstProductCtrl = new MstProductController();
            HomeScale.src.model.entities.MST_PRODUCT form = new src.model.entities.MST_PRODUCT();
            try
            {
                form.PRODUCT_ID = txtProductId.Text;

                if (CheckUtil.isEmpty(form.PRODUCT_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mstProductCtrl.deleteDataMstProduct(form);

                    //if (CheckUtil.isNotEmpty(form.PRODUCT_ID))
                    //{
                    //    result = mstProductCtrl.deleteDataMstProduct(form);
                    //}

                    //var statusError = result[0];
                    //var msgError = result[1];
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
                Log.Error(ex.ToString(), ex);
            }
        }

        public void callMenuMaster()
        {
            MenuMaster menuMaster = new MenuMaster();
            this.Hide();
            menuMaster.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                formMstProduct.PRODUCT_ID = row.Cells[0].Value.ToString();
                //formMstProduct.PRODUCT_NAME = row.Cells[1].Value.ToString();
                //formMstProduct.PRODUCT_UNIT = Int32.Parse(row.Cells[2].Value.ToString());
                //txtProductId.Text = row.Cells[0].Value.ToString();
                //txtProductName.Text = row.Cells[1].Value.ToString();
                //cboProductUnit.Text = row.Cells[3].Value.ToString();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            callMenuMaster();
        }
    }
}
