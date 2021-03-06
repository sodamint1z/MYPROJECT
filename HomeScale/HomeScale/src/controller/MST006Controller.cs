﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using PaknampoScale.src.model.entities;
using PaknampoScale.src.model.form;
using PaknampoScale.src.util;

namespace PaknampoScale.src.controller
{
    public class MST006Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] queryDataMstDataBasic(MST_DATA_BASIC param)
        {
            log.Info("Start log INFO... queryDataMstDataBasic");
            MsgForm msgError = new MsgForm();
            MST_DATA_BASIC form = new MST_DATA_BASIC();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_DATA_BASIC where row.BASIC_ID == param.BASIC_ID select row).FirstOrDefault();
                    db.Dispose();
                    msgError.statusFlag = MsgForm.STATUS_SUCCESS;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                log.Info("End log INFO... queryDataMstDataBasic");
            }
            return new object[] { msgError, form };
        }

        public object[] updateDataMstDataBasic(MST_DATA_BASIC param)
        {
            log.Info("Start log INFO... updateDataMstDataBasic");
            MsgForm msgError = new MsgForm();
            MST_DATA_BASIC form = new MST_DATA_BASIC();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_DATA_BASIC where row.BASIC_ID == param.BASIC_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        form.BASIC_CARD_NO = param.BASIC_CARD_NO;
                        form.BASIC_CARD_NO_SCOOP = param.BASIC_CARD_NO_SCOOP;
                        form.BASIC_RECEIPT_NO = param.BASIC_RECEIPT_NO;
                        form.BASIC_DECIMAL = param.BASIC_DECIMAL;
                        form.BASIC_MOVE_NO = param.BASIC_MOVE_NO;
                        form.BASIC_DEDUCTION = param.BASIC_DEDUCTION;
                        form.BASIC_FARE = param.BASIC_FARE;
                        form.BASIC_STATUS_PRINT_CARD_NO = param.BASIC_STATUS_PRINT_CARD_NO;
                        form.BASIC_STATUS_PRINT_CARD_SEND = param.BASIC_STATUS_PRINT_CARD_SEND;
                        form.BASIC_STATIS_SHOW_CARD_FARE = param.BASIC_STATIS_SHOW_CARD_FARE;
                        form.BASIC_STATUS_PRINT_OUTLOOK_VENDOR = param.BASIC_STATUS_PRINT_OUTLOOK_VENDOR;
                        log.Info("Update Data form MST_DATA_BASIC WHERE " + form.BASIC_ID
                            + " BASIC_CARD_NO : " + form.BASIC_CARD_NO
                            + " BASIC_CARD_NO_SCOOP : " + form.BASIC_CARD_NO_SCOOP
                            + " BASIC_RECEIPT_NO : " + form.BASIC_RECEIPT_NO
                            + " BASIC_DECIMAL : " + form.BASIC_DECIMAL
                            + " BASIC_MOVE_NO : " + form.BASIC_MOVE_NO
                            + " BASIC_DEDUCTION : " + form.BASIC_DEDUCTION
                            + " BASIC_FARE : " + form.BASIC_FARE
                            + " BASIC_STATUS_PRINT_CARD_NO : " + form.BASIC_STATUS_PRINT_CARD_NO
                            + " BASIC_STATUS_PRINT_CARD_SEND : " + form.BASIC_STATUS_PRINT_CARD_SEND
                            + " BASIC_STATIS_SHOW_CARD_FARE : " + form.BASIC_STATIS_SHOW_CARD_FARE
                            + " BASIC_STATUS_PRINT_OUTLOOK_VENDOR : " + form.BASIC_STATUS_PRINT_OUTLOOK_VENDOR
                            );
                    }
                    db.SaveChanges();
                    msgError.statusFlag = MsgForm.STATUS_SUCCESS;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                log.Info("End log INFO... updateDataMstDataBasic");
            }
            return new object[] { msgError };
        }
    }
}
