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
    public partial class MST_PRODUCT_UNIT : Form
    {
        public MST_PRODUCT_UNIT()
        {
            InitializeComponent();
            searchDataMstProductUnit();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        HomeScale.src.model.entities.MST_PRODUCT_UNIT formMstProductUnit = new src.model.entities.MST_PRODUCT_UNIT();
        string flagAddEdit = "A";
        public void resetDataMstProductUnit()
        {
            txtProductUnitId.Text = "";
            txtProductUnitName.Text = "";
            formMstProductUnit.PRODUCT_UNIT_ID = "";
            formMstProductUnit.PRODUCT_UNIT_NAME = "";
            flagAddEdit = "A";
            txtProductUnitId.Enabled = true;
            txtProductUnitId.Focus();
        }

        public void searchDataMstProductUnit()
        {
            MstProductUnitController mstProductUnitCtrl = new MstProductUnitController();
            try
            {
                object[] result = mstProductUnitCtrl.searchDataMstProductUnit();

                MsgForm msgForm = (MsgForm)result[0];
                List<HomeScale.src.model.entities.MST_PRODUCT_UNIT> lstdata = (List<src.model.entities.MST_PRODUCT_UNIT>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    dataGridView1.DataSource = lstdata;
                    dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 18);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 18, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสหน่วยสินค้า";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อหน่วยสินค้า";
                    //dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 16, FontStyle.Bold);
                    lblCountData.Text = "แสดงข้อมูลทั้งหมด " + lstdata.Count() + " รายการ";
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

        public void queryDataMstProductUnitByProductUnitId()
        {
            MstProductUnitController mstProductUnitCtrl = new MstProductUnitController();
            try
            {
                object[] result = mstProductUnitCtrl.queryDataMstProductUnitByProductUnitId(formMstProductUnit);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_PRODUCT_UNIT data = (src.model.entities.MST_PRODUCT_UNIT)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (CheckUtil.isNotEmpty(result))
                    {
                        txtProductUnitId.Text = data.PRODUCT_UNIT_ID;
                        txtProductUnitName.Text = data.PRODUCT_UNIT_NAME;
                        formMstProductUnit.PRODUCT_UNIT_ID = data.PRODUCT_UNIT_ID;
                        formMstProductUnit.PRODUCT_UNIT_NAME = data.PRODUCT_UNIT_NAME;
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

        public void insertOrUpdateDataMstProductUnit()
        {
            MstProductUnitController mstProductUnitCtrl = new MstProductUnitController();
            HomeScale.src.model.entities.MST_PRODUCT_UNIT form = new src.model.entities.MST_PRODUCT_UNIT();
            try
            {
                if (CheckUtil.isEmpty(txtProductUnitId.Text) 
                    || CheckUtil.isEmpty(txtProductUnitName.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.PRODUCT_UNIT_ID = txtProductUnitId.Text;
                form.PRODUCT_UNIT_NAME = txtProductUnitName.Text;

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                object[] result = mstProductUnitCtrl.insertOrUpdateDataMstProductUnit(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_PRODUCT_UNIT data = (src.model.entities.MST_PRODUCT_UNIT)result[1];

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
                            resetDataMstProductUnit();
                            searchDataMstProductUnit();
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
                        resetDataMstProductUnit();
                        searchDataMstProductUnit();
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

        public void deleteDataMstProductUnit()
        {
            MstProductUnitController mstProductUnitCtrl = new MstProductUnitController();
            HomeScale.src.model.entities.MST_PRODUCT_UNIT form = new src.model.entities.MST_PRODUCT_UNIT();
            try
            {
                form.PRODUCT_UNIT_ID = txtProductUnitId.Text;

                if (CheckUtil.isEmpty(form.PRODUCT_UNIT_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mstProductUnitCtrl.deleteDataMstProductUnit(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstProductUnit();
                        searchDataMstProductUnit();
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
                formMstProductUnit.PRODUCT_UNIT_ID = row.Cells[0].Value.ToString();
                //formMstProduct.PRODUCT_NAME = row.Cells[1].Value.ToString();
                //formMstProduct.PRODUCT_UNIT = Int32.Parse(row.Cells[2].Value.ToString());
                //txtProductId.Text = row.Cells[0].Value.ToString();
                //txtProductName.Text = row.Cells[1].Value.ToString();
                //cboProductUnit.Text = row.Cells[3].Value.ToString();
                queryDataMstProductUnitByProductUnitId();
                flagAddEdit = "E";
                txtProductUnitId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataMstProductUnit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataMstProductUnit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataMstProductUnit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            callMenuMaster();
        }
    }
}
