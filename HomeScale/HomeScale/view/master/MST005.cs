﻿using System;
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
    public partial class MST005 : Form
    {
        public MST005()
        {
            InitializeComponent();
            queryComboMstVendor();
            searchDataVwMstCarRegistertion();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_CAR_REGISTERTION formMstCarRegistertion = new MST_CAR_REGISTERTION();
        string flagAddEdit = "A";
        public void resetDataMstCarRegistertion()
        {
            txtCarRegistertionId.Text = "";
            txtCarRegistertionName.Text = "";
            cboCarRegistertionVendorId.SelectedValue = "";
            formMstCarRegistertion = new MST_CAR_REGISTERTION();
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
                List<MST_VENDOR> lstdata = (List<MST_VENDOR>)result[1];

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
                List<VW_MST_CAR_REGISTERTION> lstdata = (List<VW_MST_CAR_REGISTERTION>)result[1];

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
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสทะเบียนรถ";
                    dataGridView1.Columns[1].HeaderCell.Value = "ทะเบียนรถ";
                    dataGridView1.Columns[2].HeaderCell.Value = "รหัสผู้ขาย";
                    dataGridView1.Columns[3].HeaderCell.Value = "ชื่อผู้ขาย";
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
                MST_CAR_REGISTERTION data = (MST_CAR_REGISTERTION)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(result))
                    {
                        txtCarRegistertionId.Text = data.CAR_REGISTERTION_ID;
                        txtCarRegistertionName.Text = data.CAR_REGISTERTION_NAME;
                        cboCarRegistertionVendorId.SelectedValue = data.CAR_REGISTERTION_VENDOR_ID.ToString();
                        formMstCarRegistertion = data;
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
            MST_CAR_REGISTERTION form = new MST_CAR_REGISTERTION();
            try
            {
                if (Util.isEmpty(txtCarRegistertionId.Text) 
                    || Util.isEmpty(txtCarRegistertionName.Text) 
                    || Util.isEmpty(cboCarRegistertionVendorId.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.CAR_REGISTERTION_ID = txtCarRegistertionId.Text;
                form.CAR_REGISTERTION_NAME = txtCarRegistertionName.Text;
                form.CAR_REGISTERTION_VENDOR_ID = Int32.Parse(cboCarRegistertionVendorId.SelectedValue.ToString());

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mstCarRegistertionCtrl.insertOrUpdateDataMstCarRegistertion(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                MST_CAR_REGISTERTION data = (MST_CAR_REGISTERTION)result[1];

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
            MST_CAR_REGISTERTION form = new MST_CAR_REGISTERTION();
            try
            {
                form.CAR_REGISTERTION_ID = txtCarRegistertionId.Text;

                if (Util.isEmpty(form.CAR_REGISTERTION_ID))
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
    }
}
