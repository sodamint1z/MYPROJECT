using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeScale.src.model.entities;
using HomeScale.src.controller;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View.MST_DISTINATION());

            //MstProductController mstProControl = new MstProductController();
            //MST_PRODUCT form = new MST_PRODUCT
            //{
            //    PRODUCT_ID = 3,
            //    PRODUCT_NAME = "ข้าวสาร",
            //    PRODUCT_UNIT = 1
            //};
            //service.saveDataMstProduct(form);
            //service.updateDataMstProduct(form);
            //mstProControl.searchDataMstProduct();
            //mstProControl.insertOrUpdateDataMstProduct(form);
            //service.deleteDataMstProduct(form);

            //LoginController loginControl = new LoginController();
            //USER_LOGIN formLogin = new USER_LOGIN
            //{
            //    USER_ID = "admin",
            //    USER_PASSWORD = "admin"
            //};
            //loginControl.checkLogin(formLogin);
        }
    }
}
