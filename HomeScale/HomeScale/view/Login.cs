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
using HomeScale.view;
using log4net;

namespace HomeScale.view
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private void btnLogin_Click(object sender, EventArgs e)
        {
            checkLogin();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                checkLogin();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtPassword.Focus();
        //    }
        //}

        //private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        txtUsername.Focus();
        //    }
        //}

        public void checkLogin()
        {
            LoginController loginCtrl = new LoginController();
            USER_LOGIN form = new USER_LOGIN();
            try
            {
                if (Util.isEmpty(txtUsername.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE_USER_LOGIN);
                    return;
                }
                if (Util.isEmpty(txtPassword.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE_PASSWORD_LOGIN);
                    return;
                }

                form.USER_ID = txtUsername.Text;
                form.USER_PASSWORD = txtPassword.Text;

                if (Util.isEmpty(form))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                object[] result = loginCtrl.checkLogin(form);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.USER_LOGIN data = (src.model.entities.USER_LOGIN)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isEmpty(data))
                    {
                        MessageBox.Show(CommonUtil.DATA_NOTFOUND_AGAIN_LOGIN);
                    }
                    else
                    {
                        MenuMain menuMain = new MenuMain();
                        this.Hide();
                        menuMain.Show();
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
    }
}
