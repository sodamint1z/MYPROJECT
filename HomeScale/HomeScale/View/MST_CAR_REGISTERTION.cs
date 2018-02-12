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
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        HomeScale.src.model.entities.MST_CAR_REGISTERTION formMstCarRegistertion = new src.model.entities.MST_CAR_REGISTERTION();
        public void resetDataMstCarRegistertion()
        {
            txtLicensePlate.Text = "";
            cboVendorName.Text = "";
            formMstCarRegistertion.CAR_REGISTERTION_ID = "";
            formMstCarRegistertion.CAR_REGISTERTION_NAME = "";
            formMstCarRegistertion.CAR_REGISTERTION_VENDOR_ID = Int32.Parse("");
        }

        public void queryComboMstVendor()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            try
            {
                var result = mstCarRegistertionCtrl.queryComboMstVendor();

                var statusError = result[0];
                var msgError = result[1];
                var data = result[2];

                if (statusError.Equals(1))
                {
                    cboVendorName.ValueMember = "VENDOR_ID";
                    cboVendorName.DisplayMember = "VENDOR_NAME";
                    cboVendorName.DataSource = data;

                    cboVendorName.SelectedValue = "VENDOR_ID";
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

        public void searchDataVwMstCarRegistertion()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            try
            {
                var result = mstCarRegistertionCtrl.searchDataVwMstCarRegistertion();

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
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสทะเบียนรถ";
                    dataGridView1.Columns[1].HeaderCell.Value = "ทะเบียนรถ";
                    dataGridView1.Columns[2].HeaderCell.Value = "รหัสผู้ขาย";
                    dataGridView1.Columns[3].HeaderCell.Value = "ชื่อผู้ขาย";
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

        public void insertOrUpdateDataMstCarRegistertion()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            HomeScale.src.model.entities.MST_CAR_REGISTERTION form = new src.model.entities.MST_CAR_REGISTERTION();
            try
            {
                if (CheckUtil.isEmpty(txtLicensePlate.Text) && CheckUtil.isEmpty(cboVendorName.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                int convertVendorName = Int32.Parse(cboVendorName.Text);
                form.CAR_REGISTERTION_ID = formMstCarRegistertion.CAR_REGISTERTION_ID;
                form.CAR_REGISTERTION_NAME = txtLicensePlate.Text;
                form.CAR_REGISTERTION_VENDOR_ID = convertVendorName;

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                object[] result = mstCarRegistertionCtrl.insertOrUpdateDataMstCarRegistertion(form);

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

        public void deleteDataMstCarRegistertion()
        {
            MstCarRegistertionController mstCarRegistertionCtrl = new MstCarRegistertionController();
            HomeScale.src.model.entities.MST_CAR_REGISTERTION form = new src.model.entities.MST_CAR_REGISTERTION();
            try
            {
                form.CAR_REGISTERTION_ID = formMstCarRegistertion.CAR_REGISTERTION_ID;

                if (CheckUtil.isEmpty(form.CAR_REGISTERTION_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.TITLE_DELETE, CommonUtil.CONFIRM_DELETE_DATA, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = new object[2];

                    if (CheckUtil.isNotEmpty(form.CAR_REGISTERTION_ID))
                    {
                        result = mstCarRegistertionCtrl.deleteDataMstCarRegistertion(form);
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
