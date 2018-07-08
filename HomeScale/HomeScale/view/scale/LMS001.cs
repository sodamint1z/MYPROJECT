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
using HomeScale.view.master;
using log4net;

namespace HomeScale.view.scale
{
    public partial class LMS001 : Form
    {
        public LMS001()
        {
            InitializeComponent();
            MST001 mst001 = new MST001();
            MST002 mst002 = new MST002();
            AddNewTab(mst001);
            AddNewTab(mst002);
        }

        private void AddNewTab(Form frm)
        {

            TabPage tab = new TabPage(frm.Text);

            frm.TopLevel = false;

            frm.Parent = tab;

            frm.Visible = true;

            tabControl1.TabPages.Add(tab);

            //frm.Location = new Point((tab.Width - frm.Width) / 2, (tab.Height - frm.Height) / 2);

            //tabControl1.SelectedTab = tab;

        }
    }
}
