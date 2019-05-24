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
using PaknampoScale.view.master;
using log4net;

namespace PaknampoScale.view.master
{
    public partial class MenuMaster : Form
    {
        public MenuMaster()
        {
            InitializeComponent();
            showPageMst();
        }

        public void callMenuMain()
        {
            MenuMain menuMain = new MenuMain();
            this.Hide();
            menuMain.Show();
        }

        private void showPageMst()
        {
            MST001 mst001 = new MST001();
            MST002 mst002 = new MST002();
            MST003 mst003 = new MST003();
            MST004 mst004 = new MST004();
            MST005 mst005 = new MST005();
            MST006 mst006 = new MST006();
            MST007 mst007 = new MST007();
            MST008 mst008 = new MST008();

            addNewTab(mst001);
            addNewTab(mst002);
            addNewTab(mst003);
            addNewTab(mst004);
            addNewTab(mst005);
            addNewTab(mst006);
            addNewTab(mst007);
            addNewTab(mst008);
        }

        private void addNewTab(Form frm)
        {

            TabPage tab = new TabPage(frm.Text);
            frm.TopLevel = false;
            frm.Parent = tab;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowInTaskbar = false;

            tabControl1.TabPages.Add(tab);


            //frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);

            //tabControl1.SelectedTab = tab;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            callMenuMain();
        }
    }
}
