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
using PaknampoScale.view.master;
using log4net;

namespace PaknampoScale.view.scale
{
    public partial class LMS001 : Form
    {
        public LMS001()
        {
            InitializeComponent();
        }

        public void callMenuMain()
        {
            MenuMain menuMain = new MenuMain();
            this.Hide();
            menuMain.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            callMenuMain();
        }
    }
}
