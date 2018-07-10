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
    public partial class MST003 : Form
    {
        public MST003()
        {
            InitializeComponent();
            searchDataMstVendor();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_VENDOR formMstVendor = new MST_VENDOR();
        string flagAddEdit = "A";
        public void resetDataMstVendor()
        {
            txtVendorId.Text = "";
            txtVendorName.Text = "";
            txtVendorAddress.Text = "";
            txtVendorSubDistrict.Text = "";
            txtVendorDistrict.Text = "";
            txtVendorProvince.Text = "";
            txtVendorPostcode.Text = "";
            txtVendorTelNo.Text = "";
            txtVendorFax.Text = "";
            formMstVendor = new MST_VENDOR();
            flagAddEdit = "A";
            txtVendorId.Enabled = true;
            txtVendorId.Focus();
        }

        public void searchDataMstVendor()
        {
            MST003Controller mstVendorCtrl = new MST003Controller();
            try
            {
                object[] result = mstVendorCtrl.searchDataMstVendor();

                MsgForm msgForm = (MsgForm)result[0];
                List<MST_VENDOR> lstdata = (List<MST_VENDOR>)result[1];

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
                Log.Error(ex.ToString(), ex);
            }
        }

        public void queryDataMstVendorByVendorId()
        {
            MST003Controller mstVendorCtrl = new MST003Controller();
            try
            {
                object[] result = mstVendorCtrl.queryDataMstVendorByVendorId(formMstVendor);

                MsgForm msgForm = (MsgForm)result[0];
                MST_VENDOR data = (MST_VENDOR)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        txtVendorId.Text = data.VENDOR_ID;
                        txtVendorName.Text = data.VENDOR_NAME;
                        txtVendorAddress.Text = data.VENDOR_ADDRESS;
                        txtVendorSubDistrict.Text = data.VENDOR_SUB_DISTRICT;
                        txtVendorDistrict.Text = data.VENDOR_DISTRICT;
                        txtVendorProvince.Text = data.VENDOR_PROVINCE;
                        txtVendorPostcode.Text = data.VENDOR_POSTCODE;
                        txtVendorTelNo.Text = data.VENDOR_TEL_NO;
                        txtVendorFax.Text = data.VENDOR_FAX;
                        formMstVendor = data;
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

        public void insertOrUpdateDataMstVendor()
        {
            MST003Controller mstVendorCtrl = new MST003Controller();
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
                form.VENDOR_SUB_DISTRICT = txtVendorSubDistrict.Text;
                form.VENDOR_DISTRICT = txtVendorDistrict.Text;
                form.VENDOR_PROVINCE = txtVendorProvince.Text;
                form.VENDOR_POSTCODE = txtVendorPostcode.Text;
                form.VENDOR_TEL_NO = txtVendorTelNo.Text;
                form.VENDOR_FAX = txtVendorFax.Text;

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mstVendorCtrl.insertOrUpdateDataMstVendor(form, flagAddEdit);

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
                            searchDataMstVendor();
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
                        searchDataMstVendor();
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

        public void deleteDataMstVendor()
        {
            MST003Controller mstVendorCtrl = new MST003Controller();
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
                    object[] result = mstVendorCtrl.deleteDataMstVendor(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstVendor();
                        searchDataMstVendor();
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
                formMstVendor.VENDOR_ID = row.Cells[0].Value.ToString();
                queryDataMstVendorByVendorId();
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
    }
}
