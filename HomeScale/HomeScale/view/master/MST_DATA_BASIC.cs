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
    public partial class MST_DATA_BASIC : Form
    {
        public MST_DATA_BASIC()
        {
            InitializeComponent();
            queryDataMstDataBasic();
        }
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        HomeScale.src.model.entities.MST_DATA_BASIC formMstDataBasic = new src.model.entities.MST_DATA_BASIC();

        public void queryDataMstDataBasic()
        {
            MstDataBasicController mstDataBasicCtrl = new MstDataBasicController();
            formMstDataBasic.BASIC_ID = 1;
            try
            {
                object[] result = mstDataBasicCtrl.queryDataMstDataBasic(formMstDataBasic);

                MsgForm msgForm = (MsgForm)result[0];
                HomeScale.src.model.entities.MST_DATA_BASIC data = (src.model.entities.MST_DATA_BASIC)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (CheckUtil.isNotEmpty(data))
                    {
                        formMstDataBasic.BASIC_ID = data.BASIC_ID;
                        formMstDataBasic.BASIC_CARD_NO = data.BASIC_CARD_NO;
                        formMstDataBasic.BASIC_CARD_NO_SCOOP = data.BASIC_CARD_NO_SCOOP;
                        formMstDataBasic.BASIC_RECEIPT_NO = data.BASIC_RECEIPT_NO;
                        formMstDataBasic.BASIC_DECIMAL = data.BASIC_DECIMAL;
                        formMstDataBasic.BASIC_MOVE_NO = data.BASIC_MOVE_NO;
                        formMstDataBasic.BASIC_DEDUCTION = data.BASIC_DEDUCTION;
                        formMstDataBasic.BASIC_FARE = data.BASIC_FARE;
                        formMstDataBasic.BASIC_STATUS_PRINT_CARD_NO = data.BASIC_STATUS_PRINT_CARD_NO;
                        formMstDataBasic.BASIC_STATUS_PRINT_CARD_SEND = data.BASIC_STATUS_PRINT_CARD_SEND;
                        formMstDataBasic.BASIC_STATIS_SHOW_CARD_FARE = data.BASIC_STATIS_SHOW_CARD_FARE;
                        formMstDataBasic.BASIC_STATUS_PRINT_OUTLOOK_VENDOR = data.BASIC_STATUS_PRINT_OUTLOOK_VENDOR;

                        txtBasicCardNo.Text = data.BASIC_CARD_NO.ToString();
                        txtBasicReceiptNo.Text = data.BASIC_RECEIPT_NO.ToString();
                        txtBasicCardNoScoop.Text = data.BASIC_CARD_NO_SCOOP.ToString();
                        txtBasicDecimal.Text = data.BASIC_DECIMAL.ToString();
                        txtBasicMoveNo.Text = data.BASIC_MOVE_NO.ToString();
                        txtBasicDeduction.Text = data.BASIC_DEDUCTION.ToString();
                        txtBasicFare.Text = data.BASIC_FARE.ToString();
                        chkStatusPrintCardNo.Checked = CheckUtil.chkboxToBool(data.BASIC_STATUS_PRINT_CARD_NO);
                        chkStatusPrintCardSend.Checked = CheckUtil.chkboxToBool(data.BASIC_STATUS_PRINT_CARD_SEND);
                        chkStatusShowCardFare.Checked = CheckUtil.chkboxToBool(data.BASIC_STATIS_SHOW_CARD_FARE);
                        chkStatusPrintOutlookVendor.Checked = CheckUtil.chkboxToBool(data.BASIC_STATUS_PRINT_OUTLOOK_VENDOR);
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString(), ex);
            }
        }

        public void updateDataMstDataBasic()
        {
            MstDataBasicController mstDataBasicCtrl = new MstDataBasicController();
            HomeScale.src.model.entities.MST_DATA_BASIC form = new HomeScale.src.model.entities.MST_DATA_BASIC();
            try
            {
                form.BASIC_ID = formMstDataBasic.BASIC_ID;
                form.BASIC_CARD_NO = Int32.Parse(txtBasicCardNo.ToString());
                form.BASIC_CARD_NO_SCOOP = Int32.Parse(txtBasicCardNoScoop.ToString());
                form.BASIC_RECEIPT_NO = Int32.Parse(txtBasicReceiptNo.ToString());
                form.BASIC_DECIMAL = Int32.Parse(txtBasicDecimal.ToString());
                form.BASIC_MOVE_NO = Int32.Parse(txtBasicMoveNo.ToString());
                form.BASIC_DEDUCTION = Int32.Parse(txtBasicDeduction.ToString());
                form.BASIC_FARE = Int32.Parse(txtBasicFare.ToString());
                form.BASIC_STATUS_PRINT_CARD_NO = CheckUtil.chkboxToNumber(chkStatusPrintCardNo.Checked);
                form.BASIC_STATUS_PRINT_CARD_SEND = CheckUtil.chkboxToNumber(chkStatusPrintCardSend.Checked);
                form.BASIC_STATIS_SHOW_CARD_FARE = CheckUtil.chkboxToNumber(chkStatusShowCardFare.Checked);
                form.BASIC_STATUS_PRINT_OUTLOOK_VENDOR = CheckUtil.chkboxToNumber(chkStatusPrintOutlookVendor.Checked);

                if (CheckUtil.isEmpty(form))
                {
                    return;
                }

                object[] result = mstDataBasicCtrl.updateDataMstDataBasic(form);

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
                Log.Error(ex.ToString(), ex);
            }
        }
    }
}
