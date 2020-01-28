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
using PaknampoScale.view;
using log4net;
using System.Management;
using System.Security.Cryptography;

namespace PaknampoScale.view
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            queryDataHardDrive();
            queryDataRegister();
            lblDigit.Text = txtRegister.Text.Length.ToString() + " ตัวอักษร";
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        REGISTER formRegister = new REGISTER();
        List<HardDriveForm> lstHD = new List<HardDriveForm>();
        HardDriveForm formHardDrive = new HardDriveForm();
        string passwordNonHash = "";

        public void queryDataHardDrive()
        {
            try
            {
                //String physicalName = ("\\\\.\\PHYSICALDRIVE1").Replace("\\", "\\\\");
                //ManagementObjectSearcher manageObj = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE DeviceID = \"" + physicalName + "\"");
                ManagementObjectSearcher manageObj = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (ManagementObject obj in manageObj.Get())
                {
                    formHardDrive.model = obj["Model"].ToString();  //Model Number
                    formHardDrive.type = obj["InterfaceType"].ToString();  //Interface Type
                    formHardDrive.serialNo = obj["SerialNumber"].ToString();  //Serial Number
                    formHardDrive.deviceID = obj["DeviceID"].ToString();

                    lstHD.Add(formHardDrive);

                    txtNameHarddisk.Text = Util.toString(formHardDrive.model);
                    txtSerialNo.Text = Util.toString(formHardDrive.serialNo);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
            
        }

        public void queryDataRegister()
        {
            try
            {
                RegisterController registerCtrl = new RegisterController();
                object[] resultRegister = registerCtrl.checkRegister();
                MsgForm msgRegisterForm = (MsgForm)resultRegister[0];
                REGISTER dataRegister = (REGISTER)resultRegister[1];

                ////String xxxxx = BCrypt.Net.BCrypt.HashPassword(Util.toString(form.serialNo), BCrypt.Net.BCrypt.GenerateSalt(12));
                if (msgRegisterForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(dataRegister))
                    {
                        formRegister = dataRegister;
                        dataRegister.REGISTER_CODE = Util.toString(CryptoUtil.decrypt(dataRegister.REGISTER_CODE));
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgRegisterForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void checkRegister()
        {
            if (Util.isEmpty(txtRegister.Text)) 
            {
                MessageBox.Show(CommonUtil.REQUIRE_MESSAGE_REGISTER);
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                passwordNonHash = formHardDrive.serialNo + formRegister.REGISTER_CODE;
                bool checkHash = BCrypt.Net.BCrypt.Verify(Util.toString(passwordNonHash), txtRegister.Text);
                if (txtRegister.Text.Length.Equals(60))
                {
                    if (checkHash.Equals(true))
                    {
                        if (updateDataRegister())
                        {
                            MessageBox.Show(CommonUtil.MESSAGE_REGISTER_SUCCESS);
                            Login login = new Login();
                            this.Hide();
                            login.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show(CommonUtil.MESSAGE_REGISTER_FAILED);
                    }
                }
                else
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE_CHAR_DIGIT);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public bool updateDataRegister()
        {
            RegisterController registerCtrl = new RegisterController();
            REGISTER form = new REGISTER();
            try
            {
                form.REGISTER_ID = formRegister.REGISTER_ID;
                form.REGISTER_MODEL = formHardDrive.model;
                form.REGISTER_TYPE = formHardDrive.type;
                form.REGISTER_SERIAL_NO = formHardDrive.serialNo;
                form.REGISTER_DEVICE_ID = formHardDrive.deviceID;
                form.REGISTER_PASSWORD_HASH = txtRegister.Text;
                form.REGISTER_CODE = formRegister.REGISTER_CODE;
                //form.CREATE_DATE = formRegister.CREATE_DATE;

                if (Util.isEmpty(form))
                {
                    return false;
                }

                object[] result = registerCtrl.updateDataRegister(form);

                MsgForm msgForm = (MsgForm)result[0];

                if (msgForm.statusFlag.Equals(1))
                {
                    //MessageBox.Show(CommonUtil.SAVE_DATA_SUCCESS);
                    return true;
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
            return false;
        }

        private void txtRegister_TextChanged(object sender, EventArgs e)
        {
            lblDigit.Text = txtRegister.Text.Length.ToString() + " ตัวอักษร";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            checkRegister();
        }
    }
}
