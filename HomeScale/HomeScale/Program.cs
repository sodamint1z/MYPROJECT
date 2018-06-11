using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeScale.src.model.entities;
using HomeScale.src.controller;
using HomeScale.src.model.form;
using HomeScale.src.util;

namespace HomeScale
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoginController loginCtrl = new LoginController();
            USER_LOGIN form = new USER_LOGIN();

            form.USER_ID = "admin";
            form.USER_PASSWORD = "admin";

            object[] result = loginCtrl.checkLogin(form);

            MsgForm msgForm = (MsgForm)result[0];
            HomeScale.src.model.entities.USER_LOGIN data = (src.model.entities.USER_LOGIN)result[1];

            if (msgForm.statusFlag.Equals(1))
            {
                if (CheckUtil.isNotEmpty(data))
                {
                    if(data.STATUS_FLAG.Equals(1))
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
    }
}
