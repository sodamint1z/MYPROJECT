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
using HomeScale.view.master;
using log4net;

namespace HomeScale.view.master
{
    public partial class MenuMaster : Form
    {
        public MenuMaster()
        {
            InitializeComponent();
        }

        public void callMenuMstProduct()
        {
            MST_PRODUCT mstProduct = new MST_PRODUCT();
            this.Hide();
            mstProduct.Show();
        }

        public void callMenuMstVendor()
        {
            MST_VENDOR mstVendor = new MST_VENDOR();
            this.Hide();
            mstVendor.Show();
        }

        public void callMenuMstDestination()
        {
            MST_DESTINATION mstDestination = new MST_DESTINATION();
            this.Hide();
            mstDestination.Show();
        }

        public void callMenuMstProductUnit()
        {
            MST_PRODUCT_UNIT mstProductUnit = new MST_PRODUCT_UNIT();
            this.Hide();
            mstProductUnit.Show();
        }

        public void callMenuMstCarRegistertion()
        {
            MST_CAR_REGISTERTION mstCarRegistertion = new MST_CAR_REGISTERTION();
            this.Hide();
            mstCarRegistertion.Show();
        }

        public void callMenuMain()
        {
            MenuMain menuMain = new MenuMain();
            this.Hide();
            menuMain.Show();
        }

        private void btnDataProduct_Click(object sender, EventArgs e)
        {
            callMenuMstProduct();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            callMenuMain();
        }

        private void btnDataVendor_Click(object sender, EventArgs e)
        {
            callMenuMstVendor();
        }
    }
}
