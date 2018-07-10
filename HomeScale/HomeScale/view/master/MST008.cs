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
using log4net;

namespace HomeScale.view.master
{
    public partial class MST008 : Form
    {
        public MST008()
        {
            InitializeComponent();
            queryDataMstBusiness();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_BUSINESS formMstBusiness = new MST_BUSINESS();

        public void queryDataMstBusiness()
        {
            MST008Controller mstBusinessCtrl = new MST008Controller();
            formMstBusiness.BUSINESS_ID = 1;
            try
            {
                object[] result = mstBusinessCtrl.queryDataMstBusiness(formMstBusiness);

                MsgForm msgForm = (MsgForm)result[0];
                MST_BUSINESS data = (MST_BUSINESS)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        formMstBusiness = data;

                        txtBusinessName.Text = data.BUSINESS_NAME;
                        txtBusinessAddress.Text = data.BUSINESS_ADDRESS;
                        txtBusinessTelNo.Text = data.BUSINESS_TEL_NO;
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
            }
        }

        public void updateDataMstBusiness()
        {
            MST008Controller mstBusinessCtrl = new MST008Controller();
            MST_BUSINESS form = new MST_BUSINESS();
            try
            {
                form.BUSINESS_ID = formMstBusiness.BUSINESS_ID;
                form.BUSINESS_NAME = txtBusinessName.Text;
                form.BUSINESS_ADDRESS = txtBusinessAddress.Text;
                form.BUSINESS_TEL_NO = txtBusinessTelNo.Text;

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mstBusinessCtrl.updateDataMstBusiness(form);

                MsgForm msgForm = (MsgForm)result[0];

                if (msgForm.statusFlag.Equals(1))
                {
                    MessageBox.Show(CommonUtil.SAVE_DATA_SUCCESS);
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updateDataMstBusiness();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            queryDataMstBusiness();
        }
    }
}
