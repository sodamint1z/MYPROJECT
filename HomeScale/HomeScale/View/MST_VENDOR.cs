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
    public partial class MST_VENDOR : Form
    {
        public MST_VENDOR()
        {
            InitializeComponent();
            searchDataMstVendor();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        HomeScale.src.model.entities.MST_VENDOR formMstVendor = new src.model.entities.MST_VENDOR();
        public void resetDataMstVendor()
        {
            txtVendorName.Text = "";
            txtVendorAddress.Text = "";
            txtVendorDistrictOne.Text = "";
            txtVendorDistrictTwo.Text = "";
            txtVendorCounty.Text = "";
            txtVendorPostcode.Text = "";
            txtVendorTelNo.Text = "";
            txtVendorFax.Text = "";
            formMstVendor.VENDOR_ID = "";
            formMstVendor.VENDOR_NAME = "";
            formMstVendor.VENDOR_ADDRESS = "";
            formMstVendor.VENDOR_DISTRICT_ONE = "";
            formMstVendor.VENDOR_DISTRICT_TWO = "";
            formMstVendor.VENDOR_COUNTY = "";
            formMstVendor.VENDOR_POSTCODE = "";
            formMstVendor.VENDOR_TEL_NO = "";
            formMstVendor.VENDOR_FAX = "";
        }

        public void searchDataMstVendor()
        {
            MstVendorController mstVendorCtrl = new MstVendorController();
            try
            {
                var result = mstVendorCtrl.searchDataMstVendor();

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
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสผู้ขาย";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อผู้ขาย";
                    dataGridView1.Columns[2].HeaderCell.Value = "ที่อยู่ผู้ขาย";
                    dataGridView1.Columns[3].HeaderCell.Value = "ตำบล";
                    dataGridView1.Columns[4].HeaderCell.Value = "อำเภอ";
                    dataGridView1.Columns[5].HeaderCell.Value = "จังหวัด";
                    dataGridView1.Columns[6].HeaderCell.Value = "รหัสไปรษณีย์";
                    dataGridView1.Columns[7].HeaderCell.Value = "เบอร์โทรศัพท์";
                    dataGridView1.Columns[8].HeaderCell.Value = "แฟกซ์";
                    //dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 16, FontStyle.Bold);
                    //lblCountData.Text = "แสดงข้อมูลทั้งหมด " + countData + " รายการ";
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

        public void insertOrUpdateDataMstVendor()
        {
            MstVendorController mstVendorCtrl = new MstVendorController();
            HomeScale.src.model.entities.MST_VENDOR form = new src.model.entities.MST_VENDOR();
            try
            {
                if (CheckUtil.isEmpty(txtVendorName.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.VENDOR_ID = formMstVendor.VENDOR_ID;
                form.VENDOR_NAME = txtVendorName.Text;
                form.VENDOR_ADDRESS = txtVendorAddress.Text;
                form.VENDOR_DISTRICT_ONE = txtVendorDistrictOne.Text;
                form.VENDOR_DISTRICT_TWO = txtVendorDistrictTwo.Text;
                form.VENDOR_COUNTY = txtVendorCounty.Text;
                form.VENDOR_POSTCODE = txtVendorPostcode.Text;
                form.VENDOR_TEL_NO = txtVendorTelNo.Text;
                form.VENDOR_FAX = txtVendorFax.Text;

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                object[] result = mstVendorCtrl.insertOrUpdateDataMstVendor(form);

                var statusError = result[0];
                var msgError = result[1];

                if (statusError.Equals(1))
                {
                    MessageBox.Show(CommonUtil.SAVE_DATA_SUCCESS);
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

        public void deleteDataMstVendor()
        {
            MstVendorController mstVendorCtrl = new MstVendorController();
            HomeScale.src.model.entities.MST_VENDOR form = new src.model.entities.MST_VENDOR();
            try
            {
                form.VENDOR_ID = formMstVendor.VENDOR_ID;

                if (CheckUtil.isEmpty(form.VENDOR_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.TITLE_DELETE, CommonUtil.CONFIRM_DELETE_DATA, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = new object[2];

                    if (CheckUtil.isNotEmpty(form.VENDOR_ID))
                    {
                        result = mstVendorCtrl.deleteDataMstVendor(form);
                    }

                    var statusError = result[0];
                    var msgError = result[1];

                    if (statusError.Equals(1))
                    {
                        MessageBox.Show(CommonUtil.DELETE_DATA_SUCCESS);
                    }
                    else
                    {
                        MessageBox.Show("Error : " + msgError);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
            }
        }
    }
}
