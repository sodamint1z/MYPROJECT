﻿using System;
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
using PaknampoScale.src.model.form.combo;
using PaknampoScale.src.util;
using log4net;

namespace PaknampoScale.view.master
{
    public partial class MST007 : Form
    {
        public MST007()
        {
            InitializeComponent();
            searchDataManageUserLogin();
            loadCombo();
            queryDataLoginStatus();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        USER_LOGIN formUserLogin = new USER_LOGIN();
        LOGIN_STATUS formLoginStatus = new LOGIN_STATUS();
        string flagAddEdit = "A";
        public void resetDataManageUserLogin()
        {
            txtUserId.Text = "";
            txtUserPassword.Text = "";
            txtUserFirstname.Text = "";
            txtUserLastname.Text = "";
            cboStatusFlag.SelectedValue = 1;
            formUserLogin = new USER_LOGIN();
            flagAddEdit = "A";
            txtUserId.Enabled = true;
            txtUserId.Focus();
            queryDataLoginStatus();
        }

        public void loadCombo()
        {
            List<ComboUseOrNotUseForm> lstCombo = new List<ComboUseOrNotUseForm>();
            try
            {
                lstCombo = LoadComboUtil.loadComboUseOrNotUse();

                cboStatusFlag.DataSource = lstCombo;
                cboStatusFlag.ValueMember = "useOrNotUseId";
                cboStatusFlag.DisplayMember = "useOrNotUseValue";
                cboStatusFlag.SelectedValue = 1;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryDataLoginStatus()
        {
            MST007Controller mst007Ctrl = new MST007Controller();
            try
            {
                object[] result = mst007Ctrl.queryDataLoginStatus();

                MsgForm msgForm = (MsgForm)result[0];
                LOGIN_STATUS data = (LOGIN_STATUS)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        cboStatusFlag.SelectedValue = data.LOGIN_STATUS_VALUE;
                        formLoginStatus = data;
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

        public void searchDataManageUserLogin()
        {
            MST007Controller mst007Ctrl = new MST007Controller();
            try
            {
                object[] result = mst007Ctrl.searchDataManageUserLogin();

                MsgForm msgForm = (MsgForm)result[0];
                List<USER_LOGIN> lstdata = (List<USER_LOGIN>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    List<UserLoginForm> lstUserLogin = new List<UserLoginForm>();
                    foreach (USER_LOGIN data in lstdata) 
                    {
                        UserLoginForm userLoginForm = new UserLoginForm();
                        userLoginForm.userId = data.USER_ID;
                        userLoginForm.userPassword = data.USER_PASSWORD;
                        userLoginForm.userFirstname = data.USER_FIRSTNAME;
                        userLoginForm.userLastname = data.USER_LASTNAME;
                        userLoginForm.status = data.STATUS_FLAG.Equals(0) ? "ไม่ใช้งาน" : data.STATUS_FLAG.Equals(1) ? "ใช้งาน" : "";
                        lstUserLogin.Add(userLoginForm);
                    }
                    dataGridView1.DataSource = lstUserLogin;
                    dataGridView1.DefaultCellStyle.Font = new Font("TH SarabunPSK", 16);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("TH SarabunPSK", 16, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.Columns[0].HeaderCell.Value = "ชื่อผู้ใช้งาน";
                    dataGridView1.Columns[1].HeaderCell.Value = "รหัสผ่าน";
                    dataGridView1.Columns[2].HeaderCell.Value = "ชื่อ";
                    dataGridView1.Columns[3].HeaderCell.Value = "นามสกุล";
                    dataGridView1.Columns[4].HeaderCell.Value = "สถานะ";
                    lblCountData.Text = "แสดงข้อมูลทั้งหมด " + lstUserLogin.Count() + " รายการ";
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

        public void queryDataManageUserLoginByUserId()
        {
            MST007Controller mst007Ctrl = new MST007Controller();
            try
            {
                object[] result = mst007Ctrl.queryDataManageUserLoginByUserId(formUserLogin);

                MsgForm msgForm = (MsgForm)result[0];
                USER_LOGIN data = (USER_LOGIN)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        txtUserId.Text = data.USER_ID;
                        txtUserPassword.Text = data.USER_PASSWORD;
                        txtUserFirstname.Text = data.USER_FIRSTNAME;
                        txtUserLastname.Text = data.USER_LASTNAME;
                        //cboStatusFlag.SelectedValue = data.STATUS_FLAG;
                        formUserLogin = data;
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

        public void insertOrUpdateDataManageUserLogin()
        {
            MST007Controller mst007Ctrl = new MST007Controller();
            USER_LOGIN form = new USER_LOGIN();
            LOGIN_STATUS formUpdateStatusLogin = new LOGIN_STATUS();
            try
            {
                if (Util.isEmpty(txtUserId.Text)
                    || Util.isEmpty(txtUserPassword.Text)
                    || Util.isEmpty(cboStatusFlag.SelectedValue)) 
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.USER_ID = txtUserId.Text;
                form.USER_PASSWORD = txtUserPassword.Text;
                form.USER_FIRSTNAME = txtUserFirstname.Text;
                form.USER_LASTNAME = txtUserLastname.Text;
                //form.STATUS_FLAG = Int32.Parse(cboStatusFlag.SelectedValue.ToString());
                form.STATUS_FLAG = Int32.Parse("1");
                formUpdateStatusLogin.LOGIN_STATUS_VALUE = Int32.Parse(cboStatusFlag.SelectedValue.ToString());

                if (Util.isEmpty(form) && Util.isEmpty(formUpdateStatusLogin.LOGIN_STATUS_VALUE))
                {
                    return;
                }

                object[] result = mst007Ctrl.insertOrUpdateDataManageUserLogin(form, formUpdateStatusLogin, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                USER_LOGIN data = (USER_LOGIN)result[1];

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
                            resetDataManageUserLogin();
                            searchDataManageUserLogin();
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
                        resetDataManageUserLogin();
                        searchDataManageUserLogin();
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

        public void deleteDataManageUserLogin()
        {
            MST007Controller mst007Ctrl = new MST007Controller();
            USER_LOGIN form = new USER_LOGIN();
            try
            {
                form.USER_ID = txtUserId.Text;

                if (Util.isEmpty(form.USER_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mst007Ctrl.deleteDataManageUserLogin(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataManageUserLogin();
                        searchDataManageUserLogin();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                formUserLogin.USER_ID = row.Cells[0].Value.ToString();
                queryDataManageUserLoginByUserId();
                flagAddEdit = "E";
                txtUserId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataManageUserLogin();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataManageUserLogin();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataManageUserLogin();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MenuMaster menuMaster = new MenuMaster();
            this.Hide();
            menuMaster.Show();
        }
    }
}
