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
using PaknampoScale.view.scale;
using PaknampoScale.view.report;
using log4net;
using System.Diagnostics;

namespace PaknampoScale.view
{
    public partial class MenuMain : Form
    {
        public MenuMain()
        {
            InitializeComponent();
            queryDataMstBusiness();
            timer1.Start();
            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Interval = 1000;
            //timer.Elapsed += ;
            //timer.Start();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_BUSINESS formMstBusiness = new MST_BUSINESS();

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        } 

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

        private void btnReport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MenuReport menuReport = new MenuReport();
            this.Hide();
            menuReport.Show();
        }

    }
}
