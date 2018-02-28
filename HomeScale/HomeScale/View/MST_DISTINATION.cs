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
    public partial class MST_DISTINATION : Form
    {
        public MST_DISTINATION()
        {
            InitializeComponent();
            searchDataMstDistination();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        HomeScale.src.model.entities.MST_DISTINATION formMstDistination = new src.model.entities.MST_DISTINATION();
        string flagAddEdit = "A";
        public void resetDataMstDistination()
        {
            txtDistinationId.Text = "";
            txtDistinationName.Text = "";
            txtDistinationAddress.Text = "";
            txtDistinationDistrictOne.Text = "";
            txtDistinationDistrictTwo.Text = "";
            txtDistinationCounty.Text = "";
            txtDistinationPostcode.Text = "";
            txtDistinationTelNo.Text = "";
            txtDistinationFax.Text = "";
            formMstDistination.DISTINATION_ID = "";
            formMstDistination.DISTINATION_NAME = "";
            formMstDistination.DISTINATION_ADDRESS = "";
            formMstDistination.DISTINATION_DISTRICT_ONE = "";
            formMstDistination.DISTINATION_DISTRICT_TWO = "";
            formMstDistination.DISTINATION_COUNTY = "";
            formMstDistination.DISTINATION_POSTCODE = "";
            formMstDistination.DISTINATION_TEL_NO = "";
            formMstDistination.DISTINATION_FAX = "";
            flagAddEdit = "A";
            txtDistinationId.Enabled = true;
            txtDistinationId.Focus();
        }

        public void searchDataMstDistination()
        {
            MstDistinationController mstDistinationCtrl = new MstDistinationController();
            try
            {
                object[] result = mstDistinationCtrl.searchDataMstDistination();

                MsgForm msgForm = (MsgForm)result[0];
                List<HomeScale.src.model.entities.MST_DISTINATION> lstdata = (List<src.model.entities.MST_DISTINATION>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    dataGridView1.DataSource = lstdata;
                    dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 18);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 18, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสปลายทาง";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อปลายทาง";
                    dataGridView1.Columns[2].HeaderCell.Value = "ที่อยู่ผู้ขาย";
                    dataGridView1.Columns[3].HeaderCell.Value = "ตำบล";
                    dataGridView1.Columns[4].HeaderCell.Value = "อำเภอ";
                    dataGridView1.Columns[5].HeaderCell.Value = "จังหวัด";
                    dataGridView1.Columns[6].HeaderCell.Value = "รหัสไปรษณีย์";
                    dataGridView1.Columns[7].HeaderCell.Value = "เบอร์โทรศัพท์";
                    dataGridView1.Columns[8].HeaderCell.Value = "แฟกซ์";
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

        public void queryDataMstDistinationByDistinationId()
        {
            MstDistinationController mstDistinationCtrl = new MstDistinationController();
            try
            {
                object[] result = mstDistinationCtrl.queryDataMstDistinationByDistinationId(formMstDistination);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_DISTINATION data = (src.model.entities.MST_DISTINATION)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (CheckUtil.isNotEmpty(result))
                    {
                        txtDistinationId.Text = data.DISTINATION_ID;
                        txtDistinationName.Text = data.DISTINATION_NAME;
                        txtDistinationAddress.Text = data.DISTINATION_ADDRESS;
                        txtDistinationDistrictOne.Text = data.DISTINATION_DISTRICT_ONE;
                        txtDistinationDistrictTwo.Text = data.DISTINATION_DISTRICT_TWO;
                        txtDistinationCounty.Text = data.DISTINATION_COUNTY;
                        txtDistinationPostcode.Text = data.DISTINATION_POSTCODE;
                        txtDistinationTelNo.Text = data.DISTINATION_TEL_NO;
                        txtDistinationFax.Text = data.DISTINATION_FAX;
                        formMstDistination.DISTINATION_ID = data.DISTINATION_ID;
                        formMstDistination.DISTINATION_NAME = data.DISTINATION_NAME;
                        formMstDistination.DISTINATION_ADDRESS = data.DISTINATION_ADDRESS;
                        formMstDistination.DISTINATION_DISTRICT_ONE = data.DISTINATION_DISTRICT_ONE;
                        formMstDistination.DISTINATION_DISTRICT_TWO = data.DISTINATION_DISTRICT_TWO;
                        formMstDistination.DISTINATION_COUNTY = data.DISTINATION_COUNTY;
                        formMstDistination.DISTINATION_POSTCODE = data.DISTINATION_POSTCODE;
                        formMstDistination.DISTINATION_TEL_NO = data.DISTINATION_TEL_NO;
                        formMstDistination.DISTINATION_FAX = data.DISTINATION_FAX;
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

        public void insertOrUpdateDataMstDistination()
        {
            MstDistinationController mstDistinationCtrl = new MstDistinationController();
            HomeScale.src.model.entities.MST_DISTINATION form = new src.model.entities.MST_DISTINATION();
            try
            {
                if (CheckUtil.isEmpty(txtDistinationId.Text) 
                    || CheckUtil.isEmpty(txtDistinationName.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.DISTINATION_ID = txtDistinationId.Text;
                form.DISTINATION_NAME = txtDistinationName.Text;
                form.DISTINATION_ADDRESS = txtDistinationAddress.Text;
                form.DISTINATION_DISTRICT_ONE = txtDistinationDistrictOne.Text;
                form.DISTINATION_DISTRICT_TWO = txtDistinationDistrictTwo.Text;
                form.DISTINATION_COUNTY = txtDistinationCounty.Text;
                form.DISTINATION_POSTCODE = txtDistinationPostcode.Text;
                form.DISTINATION_TEL_NO = txtDistinationTelNo.Text;
                form.DISTINATION_FAX = txtDistinationFax.Text;

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                object[] result = mstDistinationCtrl.insertOrUpdateDataMstDistination(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_DISTINATION data = (src.model.entities.MST_DISTINATION)result[1];

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
                            resetDataMstDistination();
                            searchDataMstDistination();
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
                        resetDataMstDistination();
                        searchDataMstDistination();
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

        public void deleteDataMstDistination()
        {
            MstDistinationController mstDistinationCtrl = new MstDistinationController();
            HomeScale.src.model.entities.MST_DISTINATION form = new src.model.entities.MST_DISTINATION();
            try
            {
                form.DISTINATION_ID = txtDistinationId.Text;

                if (CheckUtil.isEmpty(form.DISTINATION_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mstDistinationCtrl.deleteDataMstDistination(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstDistination();
                        searchDataMstDistination();
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
                formMstDistination.DISTINATION_ID = row.Cells[0].Value.ToString();
                queryDataMstDistinationByDistinationId();
                flagAddEdit = "E";
                txtDistinationId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataMstDistination();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataMstDistination();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataMstDistination();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
