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
                        formMstDataBasic.BASIC_RECEIPT_NO = data.BASIC_RECEIPT_NO;
                        formMstDataBasic.BASIC_DECIMAL_NUMBER = data.BASIC_DECIMAL_NUMBER;
                        formMstDataBasic.BASIC_MOVE_NO = data.BASIC_MOVE_NO;
                        formMstDataBasic.BASIC_DEDUCTION = data.BASIC_DEDUCTION;
                        formMstDataBasic.BASIC_FARE = data.BASIC_FARE;

                        txtBasicCardNo.Text = data.BASIC_CARD_NO.ToString();
                        txtBasicReceiptNo.Text = data.BASIC_RECEIPT_NO.ToString();
                        txtBasicDecimalNumber.Text = data.BASIC_DECIMAL_NUMBER.ToString();
                        txtBasicMoveNo.Text = data.BASIC_MOVE_NO.ToString();
                        txtBasicDeduction.Text = data.BASIC_DEDUCTION.ToString();
                        txtBasicFare.Text = data.BASIC_FARE.ToString();
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
    }
}
