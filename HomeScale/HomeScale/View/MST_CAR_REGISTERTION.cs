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
    public partial class MST_CAR_REGISTERTION : Form
    {
        public MST_CAR_REGISTERTION()
        {
            InitializeComponent();
            queryComboMstVendor();
            searchDataVwMstCarRegistertion();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        HomeScale.src.model.entities.MST_CAR_REGISTERTION formMstCarRegistertion = new src.model.entities.MST_CAR_REGISTERTION();
        string flagAddEdit = "A";
        public void resetDataMstCarRegistertion()
        {
            txtCarRegistertionId.Text = "";
            txtCarRegistertionName.Text = "";
            cboCarRegistertionVendorId.SelectedValue = "";
            formMstCarRegistertion.CAR_REGISTERTION_ID = "";
            formMstCarRegistertion.CAR_REGISTERTION_NAME = "";
            formMstCarRegistertion.CAR_REGISTERTION_VENDOR_ID = Int32.Parse("0");
            flagAddEdit = "A";
            txtCarRegistertionId.Enabled = true;
            txtCarRegistertionId.Focus();
        }

        public void queryComboMstVendor()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            try
            {
                object[] result = mstCarRegistertionCtrl.queryComboMstVendor();

                MsgForm msgForm = (MsgForm)result[0];
                List<HomeScale.src.model.entities.MST_VENDOR> lstdata = (List<src.model.entities.MST_VENDOR>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboCarRegistertionVendorId.DataSource = lstdata;
                    cboCarRegistertionVendorId.ValueMember = "VENDOR_ID";
                    cboCarRegistertionVendorId.DisplayMember = "VENDOR_NAME";

                    cboCarRegistertionVendorId.SelectedValue = "";
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

        public void searchDataVwMstCarRegistertion()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            try
            {
                object[] result = mstCarRegistertionCtrl.searchDataVwMstCarRegistertion();

                MsgForm msgForm = (MsgForm)result[0];
                List<HomeScale.src.model.entities.VW_MST_CAR_REGISTERTION> lstdata = (List<src.model.entities.VW_MST_CAR_REGISTERTION>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    dataGridView1.DataSource = lstdata;
                    dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 18);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 18, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสทะเบียนรถ";
                    dataGridView1.Columns[1].HeaderCell.Value = "ทะเบียนรถ";
                    dataGridView1.Columns[2].HeaderCell.Value = "รหัสผู้ขาย";
                    dataGridView1.Columns[3].HeaderCell.Value = "ชื่อผู้ขาย";
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

        public void queryDataMstCarRegistertionByCarRegistertionId()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            try
            {
                object[] result = mstCarRegistertionCtrl.queryDataMstCarRegistertionByCarRegistertionId(formMstCarRegistertion);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_CAR_REGISTERTION data = (src.model.entities.MST_CAR_REGISTERTION)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (CheckUtil.isNotEmpty(result))
                    {
                        txtCarRegistertionId.Text = data.CAR_REGISTERTION_ID;
                        txtCarRegistertionName.Text = data.CAR_REGISTERTION_NAME;
                        string convertVendorNameToString = data.CAR_REGISTERTION_VENDOR_ID.ToString();
                        cboCarRegistertionVendorId.SelectedValue = convertVendorNameToString;
                        formMstCarRegistertion.CAR_REGISTERTION_ID = data.CAR_REGISTERTION_ID;
                        formMstCarRegistertion.CAR_REGISTERTION_NAME = data.CAR_REGISTERTION_NAME;
                        formMstCarRegistertion.CAR_REGISTERTION_VENDOR_ID = data.CAR_REGISTERTION_VENDOR_ID;
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

        public void insertOrUpdateDataMstCarRegistertion()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            HomeScale.src.model.entities.MST_CAR_REGISTERTION form = new src.model.entities.MST_CAR_REGISTERTION();
            try
            {
                if (CheckUtil.isEmpty(txtCarRegistertionId.Text) 
                    || CheckUtil.isEmpty(txtCarRegistertionName.Text) 
                    || CheckUtil.isEmpty(cboCarRegistertionVendorId.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.CAR_REGISTERTION_ID = txtCarRegistertionId.Text;
                form.CAR_REGISTERTION_NAME = txtCarRegistertionName.Text;
                form.CAR_REGISTERTION_VENDOR_ID = Int32.Parse(cboCarRegistertionVendorId.SelectedValue.ToString());

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                object[] result = mstCarRegistertionCtrl.insertOrUpdateDataMstCarRegistertion(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_CAR_REGISTERTION data = (src.model.entities.MST_CAR_REGISTERTION)result[1];

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
                            resetDataMstCarRegistertion();
                            searchDataVwMstCarRegistertion();
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
                        resetDataMstCarRegistertion();
                        searchDataVwMstCarRegistertion();
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

        public void deleteDataMstCarRegistertion()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            HomeScale.src.model.entities.MST_CAR_REGISTERTION form = new src.model.entities.MST_CAR_REGISTERTION();
            try
            {
                form.CAR_REGISTERTION_ID = txtCarRegistertionId.Text;

                if (CheckUtil.isEmpty(form.CAR_REGISTERTION_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mstCarRegistertionCtrl.deleteDataMstCarRegistertion(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstCarRegistertion();
                        searchDataVwMstCarRegistertion();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                formMstCarRegistertion.CAR_REGISTERTION_ID = row.Cells[0].Value.ToString();
                queryDataMstCarRegistertionByCarRegistertionId();
                flagAddEdit = "E";
                txtCarRegistertionId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataMstCarRegistertion();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataMstCarRegistertion();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataMstCarRegistertion();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
