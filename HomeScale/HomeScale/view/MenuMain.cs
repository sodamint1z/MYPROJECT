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
using HomeScale.view.scale;
using log4net;

namespace HomeScale.view
{
    public partial class MenuMain : Form
    {
        public MenuMain()
        {
            InitializeComponent();
        }

        private void btnMainScale_Click(object sender, EventArgs e)
        {
            LMS001 lms001 = new LMS001();
            this.Hide();
            lms001.Show();
        }

        private void btnDataScale_Click(object sender, EventArgs e)
        {

        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            MenuMaster menuMaster = new MenuMaster();
            this.Hide();
            menuMaster.Show();
        }

    }
}
