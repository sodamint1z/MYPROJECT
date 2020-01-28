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
    public partial class MST004 : Form
    {
        public MST004()
        {
            InitializeComponent();
            searchDataVwMstDestination();
            queryComboMstProvinces();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_DESTINATION formMstDistination = new MST_DESTINATION();
        List<MST_AMPHURES> lstdataAmphure = new List<MST_AMPHURES>();
        List<MST_DISTRICTS> lstdataDistricts = new List<MST_DISTRICTS>();
        string flagAddEdit = "A";
        public void resetDataMstDistination()
        {
            txtDistinationId.Text = "";
            txtDistinationName.Text = "";
            txtDistinationAddress.Text = "";
            cboDistricts.SelectedValue = "";
            cboAmphure.SelectedValue = "";
            cboProvince.SelectedValue = "";
            txtDistinationPostcode.Text = "";
            txtDistinationTelNo.Text = "";
            txtDistinationFax.Text = "";
            formMstDistination = new MST_DESTINATION();
            flagAddEdit = "A";
            txtDistinationId.Enabled = true;
            txtDistinationId.Focus();

            lstdataAmphure = new List<MST_AMPHURES>();
            lstdataDistricts = new List<MST_DISTRICTS>();

            cboAmphure.DataSource = lstdataAmphure;
            cboAmphure.ValueMember = "AMPHURE_ID";
            cboAmphure.DisplayMember = "NAME_TH";
            cboAmphure.SelectedValue = "";

            cboDistricts.DataSource = lstdataDistricts;
            cboDistricts.ValueMember = "DISTRICT_ID";
            cboDistricts.DisplayMember = "NAME_TH";
            cboDistricts.SelectedValue = "";
        }

        public void searchDataVwMstDestination()
        {
            MST004Controller mst004Ctrl = new MST004Controller();
            try
            {
                object[] result = mst004Ctrl.searchDataVwMstDestination();

                MsgForm msgForm = (MsgForm)result[0];
                List<VW_MST_DESTINATION> lstdata = (List<VW_MST_DESTINATION>)result[1];

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
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสปลายทาง";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อปลายทาง";
                    dataGridView1.Columns[2].HeaderCell.Value = "ที่อยู่ผู้ขาย";
                    dataGridView1.Columns[3].HeaderCell.Value = "ตำบล";
                    dataGridView1.Columns[4].HeaderCell.Value = "อำเภอ";
                    dataGridView1.Columns[5].HeaderCell.Value = "จังหวัด";
                    dataGridView1.Columns[6].HeaderCell.Value = "รหัสไปรษณีย์";
                    dataGridView1.Columns[7].HeaderCell.Value = "เบอร์โทรศัพท์";
                    dataGridView1.Columns[8].HeaderCell.Value = "แฟกซ์";
                    lblCountData.Text = "แสดงข้อมูลทั้งหมด " + lstdata.Count() + " รายการ";
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

        public void queryDataMstDistinationByDestinationId()
        {
            MST004Controller mst004Ctrl = new MST004Controller();
            try
            {
                object[] result = mst004Ctrl.queryDataMstDestinationByDestinationId(formMstDistination);

                MsgForm msgForm = (MsgForm)result[0];
                MST_DESTINATION data = (MST_DESTINATION)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        txtDistinationId.Text = data.DESTINATION_ID;
                        txtDistinationName.Text = data.DESTINATION_NAME;
                        txtDistinationAddress.Text = data.DESTINATION_ADDRESS;
                        //cboDistricts.SelectedValue = data.DESTINATION_DISTRICT;
                        //cboAmphure.SelectedValue = data.DESTINATION_AMPHURE;
                        //cboProvince.SelectedValue = data.DESTINATION_PROVINCE;
                        txtDistinationPostcode.Text = data.DESTINATION_POSTCODE;
                        txtDistinationTelNo.Text = data.DESTINATION_TEL_NO;
                        txtDistinationFax.Text = data.DESTINATION_FAX;
                        formMstDistination = data;

                        formMstDistination.DESTINATION_DISTRICT = data.DESTINATION_DISTRICT;
                        formMstDistination.DESTINATION_AMPHURE = data.DESTINATION_AMPHURE;
                        formMstDistination.DESTINATION_PROVINCE = data.DESTINATION_PROVINCE;

                        queryComboMstAmphures();
                        queryComboMstDistricts();

                        cboDistricts.SelectedValue = data.DESTINATION_DISTRICT;
                        cboAmphure.SelectedValue = data.DESTINATION_AMPHURE;
                        cboProvince.SelectedValue = data.DESTINATION_PROVINCE;
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

        public void insertOrUpdateDataMstDestination()
        {
            MST004Controller mst004Ctrl = new MST004Controller();
            MST_DESTINATION form = new MST_DESTINATION();
            try
            {
                if (Util.isEmpty(txtDistinationId.Text) 
                    || Util.isEmpty(txtDistinationName.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.DESTINATION_ID = txtDistinationId.Text;
                form.DESTINATION_NAME = txtDistinationName.Text;
                form.DESTINATION_ADDRESS = txtDistinationAddress.Text;
                form.DESTINATION_DISTRICT = Int32.Parse(cboDistricts.SelectedValue.ToString());
                form.DESTINATION_AMPHURE = Int32.Parse(cboAmphure.SelectedValue.ToString());
                form.DESTINATION_PROVINCE = Int32.Parse(cboProvince.SelectedValue.ToString());
                form.DESTINATION_POSTCODE = txtDistinationPostcode.Text;
                form.DESTINATION_TEL_NO = txtDistinationTelNo.Text;
                form.DESTINATION_FAX = txtDistinationFax.Text;

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mst004Ctrl.insertOrUpdateDataMstDestination(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                MST_DESTINATION data = (MST_DESTINATION)result[1];

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
                            resetDataMstDistination();
                            searchDataVwMstDestination();
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
                        searchDataVwMstDestination();
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

        public void deleteDataMstDestination()
        {
            MST004Controller mst004Ctrl = new MST004Controller();
            MST_DESTINATION form = new MST_DESTINATION();
            try
            {
                form.DESTINATION_ID = txtDistinationId.Text;

                if (Util.isEmpty(form.DESTINATION_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mst004Ctrl.deleteDataMstDestination(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstDistination();
                        searchDataVwMstDestination();
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

        public void queryComboMstProvinces()
        {
            MST004Controller mst004Ctrl = new MST004Controller();
            try
            {
                object[] result = mst004Ctrl.queryComboMstProvinces();

                MsgForm msgForm = (MsgForm)result[0];
                List<MST_PROVINCES> lstdata = (List<MST_PROVINCES>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboProvince.DataSource = lstdata;
                    cboProvince.ValueMember = "PROVINCE_ID";
                    cboProvince.DisplayMember = "NAME_TH";
                    cboProvince.SelectedValue = "";
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

        public void queryComboMstAmphures()
        {
            MST004Controller mst004Ctrl = new MST004Controller();
            MST_AMPHURES form = new MST_AMPHURES();
            try
            {
                if (!formMstDistination.DESTINATION_PROVINCE.Equals(0))
                {
                    form.PROVINCE_ID = formMstDistination.DESTINATION_PROVINCE;
                }
                else
                {
                    form.PROVINCE_ID = Int32.Parse(cboProvince.SelectedValue.ToString());
                }

                if (Util.isEmpty(form.PROVINCE_ID))
                {
                    return;
                }

                object[] result = mst004Ctrl.queryComboMstAmphures(form);

                MsgForm msgForm = (MsgForm)result[0];
                lstdataAmphure = (List<MST_AMPHURES>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboAmphure.DataSource = lstdataAmphure;
                    cboAmphure.ValueMember = "AMPHURE_ID";
                    cboAmphure.DisplayMember = "NAME_TH";
                    cboAmphure.SelectedValue = "";
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

        public void queryComboMstDistricts()
        {
            MST004Controller mst004Ctrl = new MST004Controller();
            MST_DISTRICTS form = new MST_DISTRICTS();
            try
            {
                if (!formMstDistination.DESTINATION_AMPHURE.Equals(0))
                {
                    form.AMPHURE_ID = formMstDistination.DESTINATION_AMPHURE;
                }
                else
                {
                    form.AMPHURE_ID = Int32.Parse(cboAmphure.SelectedValue.ToString());
                }

                if (Util.isEmpty(form.AMPHURE_ID))
                {
                    return;
                }

                object[] result = mst004Ctrl.queryComboMstDistricts(form);

                MsgForm msgForm = (MsgForm)result[0];
                lstdataDistricts = (List<MST_DISTRICTS>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboDistricts.DataSource = lstdataDistricts;
                    cboDistricts.ValueMember = "DISTRICT_ID";
                    cboDistricts.DisplayMember = "NAME_TH";
                    cboDistricts.SelectedValue = "";
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
            Cursor.Current = Cursors.WaitCursor;
            MenuMaster menuMaster = new MenuMaster();
            this.Hide();
            menuMaster.Show();
        }

        private void cboProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formMstDistination = new MST_DESTINATION();
            lstdataAmphure = new List<MST_AMPHURES>();
            lstdataDistricts = new List<MST_DISTRICTS>();

            cboAmphure.DataSource = lstdataAmphure;
            cboAmphure.ValueMember = "AMPHURE_ID";
            cboAmphure.DisplayMember = "NAME_TH";
            cboAmphure.SelectedValue = "";

            cboDistricts.DataSource = lstdataDistricts;
            cboDistricts.ValueMember = "DISTRICT_ID";
            cboDistricts.DisplayMember = "NAME_TH";
            cboDistricts.SelectedValue = "";

            txtDistinationPostcode.Text = "";

            queryComboMstAmphures();
        }

        private void cboAmphure_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formMstDistination = new MST_DESTINATION();
            lstdataDistricts = new List<MST_DISTRICTS>();

            cboDistricts.DataSource = lstdataDistricts;
            cboDistricts.ValueMember = "DISTRICT_ID";
            cboDistricts.DisplayMember = "NAME_TH";
            cboDistricts.SelectedValue = "";

            txtDistinationPostcode.Text = "";

            queryComboMstDistricts();
        }

        private void cboDistricts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDistinationPostcode.Text = "";

            foreach (MST_DISTRICTS data in lstdataDistricts)
            {
                if (cboDistricts.SelectedValue.ToString().Equals(data.DISTRICT_ID.ToString()))
                {
                    txtDistinationPostcode.Text = data.ZIP_CODE.ToString();
                    break;
                }
            }
        }
    }
}
