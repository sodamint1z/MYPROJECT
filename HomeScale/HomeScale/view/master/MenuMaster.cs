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
            //showPageMst();
        }

        public void callMenuMain()
        {
            Cursor.Current = Cursors.WaitCursor;
            MenuMain menuMain = new MenuMain();
            this.Hide();
            menuMain.Show();
        }

        public void callPageMST001()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST001 menuMST001 = new MST001();
            this.Hide();
            menuMST001.Show();
        }

        public void callPageMST002()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST002 menuMST002 = new MST002();
            this.Hide();
            menuMST002.Show();
        }

        public void callPageMST003()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST003 menuMST003 = new MST003();
            this.Hide();
            menuMST003.Show();
        }

        public void callPageMST004()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST004 menuMST004 = new MST004();
            this.Hide();
            menuMST004.Show();
        }

        public void callPageMST005()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST005 menuMST005 = new MST005();
            this.Hide();
            menuMST005.Show();
        }

        public void callPageMST006()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST006 menuMST006 = new MST006();
            this.Hide();
            menuMST006.Show();
        }

        public void callPageMST007()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST007 menuMST007 = new MST007();
            this.Hide();
            menuMST007.Show();
        }

        public void callPageMST008()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST008 menuMST008 = new MST008();
            this.Hide();
            menuMST008.Show();
        }

        public void callPageMST009()
        {
            Cursor.Current = Cursors.WaitCursor;
            MST009 menuMST009 = new MST009();
            this.Hide();
            menuMST009.Show();
        }

        //private void showPageMst()
        //{
        //    MST001 mst001 = new MST001();
        //    MST002 mst002 = new MST002();
        //    MST003 mst003 = new MST003();
        //    MST004 mst004 = new MST004();
        //    MST005 mst005 = new MST005();
        //    MST006 mst006 = new MST006();
        //    MST007 mst007 = new MST007();
        //    MST008 mst008 = new MST008();
        //    MST009 mst009 = new MST009();

        //    addNewTab(mst001);
        //    addNewTab(mst002);
        //    addNewTab(mst003);
        //    addNewTab(mst004);
        //    addNewTab(mst005);
        //    addNewTab(mst006);
        //    addNewTab(mst007);
        //    addNewTab(mst008);
        //    addNewTab(mst009);
        //}

        //private void addNewTab(Form form)
        //{

        //    TabPage tab = new TabPage(form.Text);
        //    form.TopLevel = false;
        //    form.Parent = tab;
        //    form.Visible = true;
        //    form.FormBorderStyle = FormBorderStyle.None;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.ShowInTaskbar = false;

        //    tabControl1.TabPages.Add(tab);


        //    //frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);

        //    //tabControl1.SelectedTab = tab;

        //}

        //private void BuildMenuItems()
        //{
        //    ContextMenuStrip myMenu = new ContextMenuStrip();
        //    ToolStripMenuItem[] items = new ToolStripMenuItem[2]; // You would obviously calculate this value at runtime
        //    for (int i = 0; i < items.Length; i++)
        //    {
        //        items[i] = new ToolStripMenuItem();
        //        items[i].Name = "dynamicItem" + i.ToString();
        //        items[i].Tag = "specialDataHere";
        //        items[i].Text = "Visible Menu Text Here";
        //        items[i].Click += new EventHandler(MenuItemClickHandler);
        //    }

        //    myMenu.DropDownItems.AddRange(items);
        //}

        //private void MenuItemClickHandler(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
        //    // Take some action based on the data in clickedItem
        //}

        private void btnBack_Click(object sender, EventArgs e)
        {
            callMenuMain();
        }

        private void btnMST001_Click(object sender, EventArgs e)
        {
            callPageMST001();
        }

        private void btnMST002_Click(object sender, EventArgs e)
        {
            callPageMST002();
        }

        private void btnMST003_Click(object sender, EventArgs e)
        {
            callPageMST003();
        }

        private void btnMST004_Click(object sender, EventArgs e)
        {
            callPageMST004();
        }

        private void btnMST005_Click(object sender, EventArgs e)
        {
            callPageMST005();
        }

        private void btnMST006_Click(object sender, EventArgs e)
        {
            callPageMST006();
        }

        private void btnMST007_Click(object sender, EventArgs e)
        {
            callPageMST007();
        }

        private void btnMST008_Click(object sender, EventArgs e)
        {
            callPageMST008();
        }

        private void btnMST009_Click(object sender, EventArgs e)
        {
            callPageMST009();
        }
    }
}
