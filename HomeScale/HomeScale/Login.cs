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

namespace HomeScale
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

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsername.Focus();
            }
        }

        public void checkLogin()
        {
            try
            {
                //Start Request
                LoginController loginCtrl = new LoginController();
                USER_LOGIN form = new USER_LOGIN();

                if (CheckUtil.isEmpty(txtUsername.Text))
                {
                    MessageBox.Show("กรุณากรอกบัญชีผู้ใช้");
                    return;
                }
                if (CheckUtil.isEmpty(txtPassword.Text))
                {
                    MessageBox.Show("กรุณากรอกรหัสผ่าน");
                    return;
                }

                form.USER_ID = txtUsername.Text;
                form.USER_PASSWORD = txtPassword.Text;

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                //form.USER_ID = "admin";
                //form.USER_PASSWORD = "admin";

                //End Request

                //Start Response
                object[] result = loginCtrl.checkLogin(form);

                //Status & MessageError
                var statusError = result[0];
                var msgError = result[1];
                //Data
                var data = result[2];
                //End Response

                if (statusError.Equals(1))
                {
                    if (CheckUtil.isEmpty(data))
                    {
                        MessageBox.Show("ไม่พบข้อมูลกรุณาล็อกอินอีกครั้ง");
                    }
                    else
                    {
                        //Next Page
                        MessageBox.Show("มี User ในระบบ");
                    }
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
    }
}
