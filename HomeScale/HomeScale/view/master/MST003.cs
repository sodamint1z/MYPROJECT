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
    public partial class MST003 : Form
    {
        public MST003()
        {
            InitializeComponent();
            searchDataVwMstVendor();
            queryComboMstProvinces();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_VENDOR formMstVendor = new MST_VENDOR();
        List<MST_AMPHURES> lstdataAmphure = new List<MST_AMPHURES>();
        List<MST_DISTRICTS> lstdataDistricts = new List<MST_DISTRICTS>();
        string flagAddEdit = "A";

        public void resetDataMstVendor()
        {
            txtVendorId.Text = "";
            txtVendorName.Text = "";
            txtVendorAddress.Text = "";
            cboDistricts.SelectedValue = "";
            cboAmphure.SelectedValue = "";
            cboProvince.SelectedValue = "";
            txtVendorPostcode.Text = "";
            txtVendorTelNo.Text = "";
            txtVendorFax.Text = "";
            formMstVendor = new MST_VENDOR();
            flagAddEdit = "A";
            txtVendorId.Enabled = true;
            txtVendorId.Focus();

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

        public void searchDataVwMstVendor()
        {
            MST003Controller mst003Ctrl = new MST003Controller();
            try
            {
                object[] result = mst003Ctrl.searchDataVwMstVendor();

                MsgForm msgForm = (MsgForm)result[0];
                List<VW_MST_VENDOR> lstdata = (List<VW_MST_VENDOR>)result[1];

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
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสผู้ขาย";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อผู้ขาย";
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

        public void queryDataMstVendorByVendorId()
        {
            MST003Controller mst003Ctrl = new MST003Controller();
            try
            {
                object[] result = mst003Ctrl.queryDataMstVendorByVendorId(formMstVendor);

                MsgForm msgForm = (MsgForm)result[0];
                MST_VENDOR data = (MST_VENDOR)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        txtVendorId.Text = data.VENDOR_ID;
                        txtVendorName.Text = data.VENDOR_NAME;
                        txtVendorAddress.Text = data.VENDOR_ADDRESS;
                        //cboDistricts.SelectedValue = data.VENDOR_DISTRICT;
                        //cboAmphure.SelectedValue = data.VENDOR_AMPHURE;
                        //cboProvince.SelectedValue = data.VENDOR_PROVINCE;
                        txtVendorPostcode.Text = data.VENDOR_POSTCODE;
                        txtVendorTelNo.Text = data.VENDOR_TEL_NO;
                        txtVendorFax.Text = data.VENDOR_FAX;
                        formMstVendor = data;

                        formMstVendor.VENDOR_PROVINCE = data.VENDOR_PROVINCE;
                        formMstVendor.VENDOR_AMPHURE = data.VENDOR_AMPHURE;
                        formMstVendor.VENDOR_DISTRICT = data.VENDOR_DISTRICT;

                        queryComboMstAmphures();
                        queryComboMstDistricts();

                        cboDistricts.SelectedValue = data.VENDOR_DISTRICT;
                        cboAmphure.SelectedValue = data.VENDOR_AMPHURE;
                        cboProvince.SelectedValue = data.VENDOR_PROVINCE;
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

        public void insertOrUpdateDataMstVendor()
        {
            MST003Controller mst003Ctrl = new MST003Controller();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                if (Util.isEmpty(txtVendorId.Text) || Util.isEmpty(txtVendorName.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.VENDOR_ID = txtVendorId.Text;
                form.VENDOR_NAME = txtVendorName.Text;
                form.VENDOR_ADDRESS = txtVendorAddress.Text;
                form.VENDOR_DISTRICT = Int32.Parse(cboDistricts.SelectedValue.ToString());
                form.VENDOR_AMPHURE = Int32.Parse(cboAmphure.SelectedValue.ToString());
                form.VENDOR_PROVINCE = Int32.Parse(cboProvince.SelectedValue.ToString());
                form.VENDOR_POSTCODE = txtVendorPostcode.Text;
                form.VENDOR_TEL_NO = txtVendorTelNo.Text;
                form.VENDOR_FAX = txtVendorFax.Text;

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mst003Ctrl.insertOrUpdateDataMstVendor(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                MST_VENDOR data = (MST_VENDOR)result[1];

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
                            resetDataMstVendor();
                            searchDataVwMstVendor();
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
                        resetDataMstVendor();
                        searchDataVwMstVendor();
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

        public void deleteDataMstVendor()
        {
            MST003Controller mst003Ctrl = new MST003Controller();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                form.VENDOR_ID = txtVendorId.Text;

                if (Util.isEmpty(form.VENDOR_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mst003Ctrl.deleteDataMstVendor(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstVendor();
                        searchDataVwMstVendor();
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

        //public void queryComboMstGeographies()
        //{
        //    MST003Controller mst003Ctrl = new MST003Controller();
        //    try
        //    {
        //        object[] result = mst003Ctrl.queryComboMstGeographies();

        //        MsgForm msgForm = (MsgForm)result[0];
        //        List<MST_GEOGRAPHIES> lstdata = (List<MST_GEOGRAPHIES>)result[1];

        //        if (msgForm.statusFlag.Equals(1))
        //        {
        //            cboGeography.DataSource = lstdata;
        //            cboGeography.ValueMember = "GEOGRAPHY_ID";
        //            cboGeography.DisplayMember = "NAME";
        //            cboGeography.SelectedValue = "";
        //            cboGeography.Text = "---กรุณาเลือก---";
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error : " + msgForm.messageDescription);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.ToString(), ex);
        //        MessageBox.Show("Error : " + ex.ToString());
        //    }
        //}

        public void queryComboMstProvinces()
        {
            MST003Controller mst003Ctrl = new MST003Controller();
            try
            {
                object[] result = mst003Ctrl.queryComboMstProvinces();

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
            MST003Controller mst003Ctrl = new MST003Controller();
            MST_AMPHURES form = new MST_AMPHURES();
            try
            {
                if (!formMstVendor.VENDOR_PROVINCE.Equals(0))
                {
                    form.PROVINCE_ID = formMstVendor.VENDOR_PROVINCE;
                }
                else
                {
                    form.PROVINCE_ID = Int32.Parse(cboProvince.SelectedValue.ToString());
                }

                if (Util.isEmpty(form.PROVINCE_ID))
                {
                    return;
                }

                object[] result = mst003Ctrl.queryComboMstAmphures(form);

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
            MST003Controller mst003Ctrl = new MST003Controller();
            MST_DISTRICTS form = new MST_DISTRICTS();
            try
            {
                if (!formMstVendor.VENDOR_AMPHURE.Equals(0))
                {
                    form.AMPHURE_ID = formMstVendor.VENDOR_AMPHURE;
                }
                else
                {
                    form.AMPHURE_ID = Int32.Parse(cboAmphure.SelectedValue.ToString());
                }

                if (Util.isEmpty(form.AMPHURE_ID))
                {
                    return;
                }

                object[] result = mst003Ctrl.queryComboMstDistricts(form);

                MsgForm msgForm = (MsgForm)result[0];
                //List<MST_DISTRICTS> lstdata = (List<MST_DISTRICTS>)result[1];
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
                formMstVendor.VENDOR_ID = row.Cells[0].Value.ToString();

                //formMstVendor.VENDOR_DISTRICT = Int32.Parse(row.Cells[3].Value.ToString());
                //formMstVendor.VENDOR_AMPHURE = Int32.Parse(row.Cells[4].Value.ToString());
                //formMstVendor.VENDOR_PROVINCE = Int32.Parse(row.Cells[5].Value.ToString());

                queryDataMstVendorByVendorId();

                //queryComboMstAmphures();
                //queryComboMstDistricts();
                
                flagAddEdit = "E";
                txtVendorId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataMstVendor();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataMstVendor();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataMstVendor();
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
            formMstVendor = new MST_VENDOR();
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

            txtVendorPostcode.Text = "";

            queryComboMstAmphures();
        }

        private void cboAmphure_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formMstVendor = new MST_VENDOR();
            lstdataDistricts = new List<MST_DISTRICTS>();

            cboDistricts.DataSource = lstdataDistricts;
            cboDistricts.ValueMember = "DISTRICT_ID";
            cboDistricts.DisplayMember = "NAME_TH";
            cboDistricts.SelectedValue = "";

            txtVendorPostcode.Text = "";

            queryComboMstDistricts();
        }

        private void cboDistricts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtVendorPostcode.Text = "";

            foreach (MST_DISTRICTS data in lstdataDistricts)
            {
                if (cboDistricts.SelectedValue.ToString().Equals(data.DISTRICT_ID.ToString()))
                {
                    txtVendorPostcode.Text = data.ZIP_CODE.ToString();
                    break;
                }
            }
        }
    }
}
