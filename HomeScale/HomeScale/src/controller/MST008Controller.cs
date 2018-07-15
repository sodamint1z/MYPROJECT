﻿using System;
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
    public class MST008Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public object[] queryDataMstBusiness(MST_BUSINESS param)
        {
            log.Info("Start log INFO... queryDataMstBusiness");
            MsgForm msgError = new MsgForm();
            MST_BUSINESS form = new MST_BUSINESS();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_BUSINESS where row.BUSINESS_ID == param.BUSINESS_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataMstBusiness");
            }
            return new object[] { msgError, form };
        }

        public object[] updateDataMstBusiness(MST_BUSINESS param)
        {
            log.Info("Start log INFO... updateDataMstBusiness");
            MsgForm msgError = new MsgForm();
            MST_BUSINESS form = new MST_BUSINESS();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_BUSINESS where row.BUSINESS_ID == param.BUSINESS_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        form.BUSINESS_NAME = param.BUSINESS_NAME;
                        form.BUSINESS_ADDRESS = param.BUSINESS_ADDRESS;
                        form.BUSINESS_TEL_NO = param.BUSINESS_TEL_NO;
                        log.Info("Update Data form MST_BUSINESS WHERE " + form.BUSINESS_ID
                            + " BUSINESS_NAME : " + form.BUSINESS_NAME
                            + " BUSINESS_ADDRESS : " + form.BUSINESS_ADDRESS
                            + " BUSINESS_TEL_NO : " + form.BUSINESS_TEL_NO
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
                log.Info("End log INFO... updateDataMstBusiness");
            }
            return new object[] { msgError };
        }
    }
}