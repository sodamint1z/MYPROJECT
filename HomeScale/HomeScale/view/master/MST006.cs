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
    public partial class MST006 : Form
    {
        public MST006()
        {
            InitializeComponent();
            queryDataMstDataBasic();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_DATA_BASIC formMstDataBasic = new MST_DATA_BASIC();

        public void queryDataMstDataBasic()
        {
            MST006Controller mst006Ctrl = new MST006Controller();
            formMstDataBasic.BASIC_ID = 1;
            try
            {
                object[] result = mst006Ctrl.queryDataMstDataBasic(formMstDataBasic);

                MsgForm msgForm = (MsgForm)result[0];
                MST_DATA_BASIC data = (MST_DATA_BASIC)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        formMstDataBasic = data;

                        txtBasicCardNo.Text = data.BASIC_CARD_NO.ToString();
                        txtBasicReceiptNo.Text = data.BASIC_RECEIPT_NO.ToString();
                        txtBasicCardNoScoop.Text = data.BASIC_CARD_NO_SCOOP.ToString();
                        txtBasicDecimal.Text = data.BASIC_DECIMAL.ToString();
                        txtBasicMoveNo.Text = data.BASIC_MOVE_NO.ToString();
                        txtBasicDeduction.Text = data.BASIC_DEDUCTION.ToString();
                        txtBasicFare.Text = data.BASIC_FARE.ToString();
                        chkStatusPrintCardNo.Checked = Util.chkboxToBool(data.BASIC_STATUS_PRINT_CARD_NO);
                        chkStatusPrintCardSend.Checked = Util.chkboxToBool(data.BASIC_STATUS_PRINT_CARD_SEND);
                        chkStatusShowCardFare.Checked = Util.chkboxToBool(data.BASIC_STATIS_SHOW_CARD_FARE);
                        chkStatusPrintOutlookVendor.Checked = Util.chkboxToBool(data.BASIC_STATUS_PRINT_OUTLOOK_VENDOR);
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void updateDataMstDataBasic()
        {
            MST006Controller mst006Ctrl = new MST006Controller();
            MST_DATA_BASIC form = new MST_DATA_BASIC();
            try
            {
                form.BASIC_ID = formMstDataBasic.BASIC_ID;
                form.BASIC_CARD_NO = Int32.Parse(txtBasicCardNo.Text);
                form.BASIC_CARD_NO_SCOOP = Int32.Parse(txtBasicCardNoScoop.Text);
                form.BASIC_RECEIPT_NO = Int32.Parse(txtBasicReceiptNo.Text);
                form.BASIC_DECIMAL = Int32.Parse(txtBasicDecimal.Text);
                form.BASIC_MOVE_NO = Int32.Parse(txtBasicMoveNo.Text);
                form.BASIC_DEDUCTION = Int32.Parse(txtBasicDeduction.Text);
                form.BASIC_FARE = Int32.Parse(txtBasicFare.Text);
                form.BASIC_STATUS_PRINT_CARD_NO = Util.chkboxToNumber(chkStatusPrintCardNo.Checked);
                form.BASIC_STATUS_PRINT_CARD_SEND = Util.chkboxToNumber(chkStatusPrintCardSend.Checked);
                form.BASIC_STATIS_SHOW_CARD_FARE = Util.chkboxToNumber(chkStatusShowCardFare.Checked);
                form.BASIC_STATUS_PRINT_OUTLOOK_VENDOR = Util.chkboxToNumber(chkStatusPrintOutlookVendor.Checked);

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mst006Ctrl.updateDataMstDataBasic(form);

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
            catch(Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updateDataMstDataBasic();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            queryDataMstDataBasic();
        }
    }
}
