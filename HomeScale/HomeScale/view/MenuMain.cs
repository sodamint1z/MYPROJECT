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
using System.Diagnostics;

namespace HomeScale.view
{
    public partial class MenuMain : Form
    {
        public MenuMain()
        {
            InitializeComponent();
            queryDataMstBusiness();
            
            lblTime.Text = DateTime.Now.ToString();
            Stopwatch sw = Stopwatch.StartNew();
            
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_BUSINESS formMstBusiness = new MST_BUSINESS();

        public void queryDataMstBusiness()
        {
            MST008Controller mst008Ctrl = new MST008Controller();
            formMstBusiness.BUSINESS_ID = 1;
            try
            {
                object[] result = mst008Ctrl.queryDataMstBusiness(formMstBusiness);

                MsgForm msgForm = (MsgForm)result[0];
                MST_BUSINESS data = (MST_BUSINESS)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        formMstBusiness = data;

                        lblBusiness.Text = data.BUSINESS_NAME;
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void btnMainScale_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LMS001 lms001 = new LMS001();
            this.Hide();
            lms001.Show();
        }

        private void btnDataScale_Click(object sender, EventArgs e)
        {

        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MenuMaster menuMaster = new MenuMaster();
            this.Hide();
            menuMaster.Show();
        }

        private void btnConfigScale_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            STS001 sts001 = new STS001();
            this.Hide();
            sts001.Show();
        }

    }
}
