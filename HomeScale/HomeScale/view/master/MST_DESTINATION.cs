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
    public partial class MST_DESTINATION : Form
    {
        public MST_DESTINATION()
        {
            InitializeComponent();
            searchDataMstDestination();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        HomeScale.src.model.entities.MST_DESTINATION formMstDistination = new src.model.entities.MST_DESTINATION();
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
            formMstDistination.DESTINATION_ID = "";
            formMstDistination.DESTINATION_NAME = "";
            formMstDistination.DESTINATION_ADDRESS = "";
            formMstDistination.DESTINATION_DISTRICT_ONE = "";
            formMstDistination.DESTINATION_DISTRICT_TWO = "";
            formMstDistination.DESTINATION_COUNTY = "";
            formMstDistination.DESTINATION_POSTCODE = "";
            formMstDistination.DESTINATION_TEL_NO = "";
            formMstDistination.DESTINATION_FAX = "";
            flagAddEdit = "A";
            txtDistinationId.Enabled = true;
            txtDistinationId.Focus();
        }

        public void searchDataMstDestination()
        {
            MstDestinationController mstDistinationCtrl = new MstDestinationController();
            try
            {
                object[] result = mstDistinationCtrl.searchDataMstDestination();

                MsgForm msgForm = (MsgForm)result[0];
                List<HomeScale.src.model.entities.MST_DESTINATION> lstdata = (List<src.model.entities.MST_DESTINATION>)result[1];

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

        public void queryDataMstDistinationByDestinationId()
        {
            MstDestinationController mstDestinationCtrl = new MstDestinationController();
            try
            {
                object[] result = mstDestinationCtrl.queryDataMstDestinationByDestinationId(formMstDistination);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_DESTINATION data = (src.model.entities.MST_DESTINATION)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (CheckUtil.isNotEmpty(result))
                    {
                        txtDistinationId.Text = data.DESTINATION_ID;
                        txtDistinationName.Text = data.DESTINATION_NAME;
                        txtDistinationAddress.Text = data.DESTINATION_ADDRESS;
                        txtDistinationDistrictOne.Text = data.DESTINATION_DISTRICT_ONE;
                        txtDistinationDistrictTwo.Text = data.DESTINATION_DISTRICT_TWO;
                        txtDistinationCounty.Text = data.DESTINATION_COUNTY;
                        txtDistinationPostcode.Text = data.DESTINATION_POSTCODE;
                        txtDistinationTelNo.Text = data.DESTINATION_TEL_NO;
                        txtDistinationFax.Text = data.DESTINATION_FAX;
                        formMstDistination.DESTINATION_ID = data.DESTINATION_ID;
                        formMstDistination.DESTINATION_NAME = data.DESTINATION_NAME;
                        formMstDistination.DESTINATION_ADDRESS = data.DESTINATION_ADDRESS;
                        formMstDistination.DESTINATION_DISTRICT_ONE = data.DESTINATION_DISTRICT_ONE;
                        formMstDistination.DESTINATION_DISTRICT_TWO = data.DESTINATION_DISTRICT_TWO;
                        formMstDistination.DESTINATION_COUNTY = data.DESTINATION_COUNTY;
                        formMstDistination.DESTINATION_POSTCODE = data.DESTINATION_POSTCODE;
                        formMstDistination.DESTINATION_TEL_NO = data.DESTINATION_TEL_NO;
                        formMstDistination.DESTINATION_FAX = data.DESTINATION_FAX;
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

        public void insertOrUpdateDataMstDestination()
        {
            MstDestinationController mstDestinationCtrl = new MstDestinationController();
            HomeScale.src.model.entities.MST_DESTINATION form = new src.model.entities.MST_DESTINATION();
            try
            {
                if (CheckUtil.isEmpty(txtDistinationId.Text) 
                    || CheckUtil.isEmpty(txtDistinationName.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.DESTINATION_ID = txtDistinationId.Text;
                form.DESTINATION_NAME = txtDistinationName.Text;
                form.DESTINATION_ADDRESS = txtDistinationAddress.Text;
                form.DESTINATION_DISTRICT_ONE = txtDistinationDistrictOne.Text;
                form.DESTINATION_DISTRICT_TWO = txtDistinationDistrictTwo.Text;
                form.DESTINATION_COUNTY = txtDistinationCounty.Text;
                form.DESTINATION_POSTCODE = txtDistinationPostcode.Text;
                form.DESTINATION_TEL_NO = txtDistinationTelNo.Text;
                form.DESTINATION_FAX = txtDistinationFax.Text;

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                object[] result = mstDestinationCtrl.insertOrUpdateDataMstDestination(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_DESTINATION data = (src.model.entities.MST_DESTINATION)result[1];

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
                            searchDataMstDestination();
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
                        searchDataMstDestination();
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

        public void deleteDataMstDestination()
        {
            MstDestinationController mstDistinationCtrl = new MstDestinationController();
            HomeScale.src.model.entities.MST_DESTINATION form = new src.model.entities.MST_DESTINATION();
            try
            {
                form.DESTINATION_ID = txtDistinationId.Text;

                if (CheckUtil.isEmpty(form.DESTINATION_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mstDistinationCtrl.deleteDataMstDestination(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstDistination();
                        searchDataMstDestination();
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
                formMstDistination.DESTINATION_ID = row.Cells[0].Value.ToString();
                queryDataMstDistinationByDestinationId();
                flagAddEdit = "E";
                txtDistinationId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataMstDestination();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataMstDistination();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataMstDestination();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            callMenuMaster();
        }
    }
}
