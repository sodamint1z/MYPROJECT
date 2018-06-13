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
            MST001 mstProduct = new MST001();
            this.Hide();
            mstProduct.Show();
        }

        public void callMenuMstVendor()
        {
            MST003 mstVendor = new MST003();
            this.Hide();
            mstVendor.Show();
        }

        public void callMenuMstDestination()
        {
            MST004 mstDestination = new MST004();
            this.Hide();
            mstDestination.Show();
        }

        public void callMenuMstProductUnit()
        {
            MST002 mstProductUnit = new MST002();
            this.Hide();
            mstProductUnit.Show();
        }

        public void callMenuMstCarRegistertion()
        {
            MST005 mstCarRegistertion = new MST005();
            this.Hide();
            mstCarRegistertion.Show();
        }

        public void callMenuMstDataBasic()
        {
            MST006 mstDataBasic = new MST006();
            this.Hide();
            mstDataBasic.Show();
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

        private void btnDataUnitProduct_Click(object sender, EventArgs e)
        {
            callMenuMstProductUnit();
        }

        private void btnDataDestination_Click(object sender, EventArgs e)
        {
            callMenuMstDestination();
        }

        private void btnDataLicensePlate_Click(object sender, EventArgs e)
        {
            callMenuMstCarRegistertion();
        }

        private void btnDataBasic_Click(object sender, EventArgs e)
        {
            callMenuMstDataBasic();
        }
    }
}
