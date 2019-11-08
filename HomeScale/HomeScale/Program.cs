using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaknampoScale.src.model.entities;
using PaknampoScale.src.controller;
using PaknampoScale.src.model.form;
using PaknampoScale.src.util;
using System.Management;
using System.Security.Cryptography;

namespace PaknampoScale
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<HardDriveForm> lstHD = new List<HardDriveForm>();
            HardDriveForm form = new HardDriveForm();
            //String physicalName = ("\\\\.\\PHYSICALDRIVE0").Replace("\\", "\\\\");
            //ManagementObjectSearcher manageObj = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE DeviceID = \"" + physicalName + "\"");
            ManagementObjectSearcher manageObj = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject obj in manageObj.Get())
            {
                form.model = obj["Model"].ToString();  //Model Number
                form.type = obj["InterfaceType"].ToString();  //Interface Type
                form.serialNo = obj["SerialNumber"].ToString();  //Serial Number
                form.deviceID = obj["DeviceID"].ToString();

                lstHD.Add(form);
            }

            RegisterController registerCtrl = new RegisterController();
            object[] resultRegister = registerCtrl.checkRegister();
            MsgForm msgRegisterForm = (MsgForm)resultRegister[0];
            REGISTER dataRegister = (REGISTER)resultRegister[1];

            if (msgRegisterForm.statusFlag.Equals(1))
            {
                if (Util.isNotEmpty(dataRegister))
                {
                    dataRegister.REGISTER_MODEL = Util.toString(CryptoUtil.decrypt(dataRegister.REGISTER_MODEL));
                    dataRegister.REGISTER_TYPE = Util.toString(CryptoUtil.decrypt(dataRegister.REGISTER_TYPE));
                    dataRegister.REGISTER_SERIAL_NO = Util.toString(CryptoUtil.decrypt(dataRegister.REGISTER_SERIAL_NO));
                    dataRegister.REGISTER_DEVICE_ID = Util.toString(CryptoUtil.decrypt(dataRegister.REGISTER_DEVICE_ID));
                    dataRegister.REGISTER_CODE = Util.toString(CryptoUtil.decrypt(dataRegister.REGISTER_CODE));

                    string passwordNew = form.serialNo + dataRegister.REGISTER_CODE;
                    string passwordOld = dataRegister.REGISTER_SERIAL_NO + dataRegister.REGISTER_CODE;
                    bool checkHash = false;

                    if (Util.isNotEmpty(Util.toString(passwordNew)) && Util.isNotEmpty(dataRegister.REGISTER_PASSWORD_HASH)) 
                    {
                        if (dataRegister.REGISTER_PASSWORD_HASH.Length.Equals(60))
                        {
                            checkHash = BCrypt.Net.BCrypt.Verify(Util.toString(passwordNew), dataRegister.REGISTER_PASSWORD_HASH);
                        }
                    }

                    if (Util.isNotEmpty(passwordNew) && Util.isNotEmpty(passwordOld))
                    {
                        if (passwordNew.Equals(passwordOld) && checkHash.Equals(true))
                        {
                            LoginController loginCtrl = new LoginController();

                            object[] result = loginCtrl.checkStatusLogin();

                            MsgForm msgForm = (MsgForm)result[0];
                            LOGIN_STATUS data = (LOGIN_STATUS)result[1];

                            if (msgForm.statusFlag.Equals(1))
                            {
                                if (Util.isNotEmpty(data))
                                {
                                    if (data.LOGIN_STATUS_VALUE.Equals(1))
                                    {
                                        Application.EnableVisualStyles();
                                        Application.SetCompatibleTextRenderingDefault(false);
                                        Application.Run(new view.Login());
                                    }
                                    else
                                    {
                                        Application.EnableVisualStyles();
                                        Application.SetCompatibleTextRenderingDefault(false);
                                        Application.Run(new view.MenuMain());
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error : " + msgForm.messageDescription);
                            }
                        }
                        else
                        {
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new view.Register());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error : " + msgRegisterForm.messageDescription);
            }
        }
    }
}
