using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using HomeScale.src.model.entities;
using HomeScale.src.model.form;
using HomeScale.src.util;

namespace HomeScale.src.controller
{
    public class MstDataBasicController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] queryDataMstDataBasic()
        {
            Log.Info("Start log INFO... queryDataMstDataBasic");
            MsgForm msgError = new MsgForm();
            MST_DATA_BASIC form = new MST_DATA_BASIC();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_DATA_BASIC select row).FirstOrDefault();
                    db.Dispose();
                    msgError.statusFlag = MsgForm.STATUS_SUCCESS;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                Log.Info("End log INFO... queryDataMstDataBasic");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription, form };
        }

        public object[] updateDataMstDataBasic(MST_DATA_BASIC param)
        {
            Log.Info("Start log INFO... updateDataMstDataBasic");
            MsgForm msgError = new MsgForm();
            MST_DATA_BASIC form = new MST_DATA_BASIC();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_DATA_BASIC where row.BASIC_ID == param.BASIC_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        form.BASIC_CARD_NO = param.BASIC_CARD_NO;
                        form.BASIC_RECEIPT_NO = param.BASIC_RECEIPT_NO;
                        form.BASIC_DECIMAL_NUMBER = param.BASIC_DECIMAL_NUMBER;
                        form.BASIC_MOVE_NO = param.BASIC_MOVE_NO;
                        form.BASIC_DEDUCTION = param.BASIC_DEDUCTION;
                        form.BASIC_FARE = param.BASIC_FARE;
                        form.BASIC_STATUS_SCALE_CARD = param.BASIC_STATUS_SCALE_CARD;
                        form.BASIC_STATUS_BALANCE = param.BASIC_STATUS_BALANCE;
                        form.BASIC_STATUS_CUSTOMER = param.BASIC_STATUS_CUSTOMER;
                    }
                    db.SaveChanges();
                    msgError.statusFlag = MsgForm.STATUS_SUCCESS;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                Log.Info("End log INFO... updateDataMstDataBasic");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }
    }
}
