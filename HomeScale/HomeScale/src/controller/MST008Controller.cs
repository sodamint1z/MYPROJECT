using System;
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
                using (var db = new PaknampoScaleDBEntities())
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

        public object[] queryComboMstProvinces()
        {
            log.Info("Start log INFO... queryComboMstProvinces");
            MsgForm msgError = new MsgForm();
            List<MST_PROVINCES> resultList = new List<MST_PROVINCES>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_PROVINCES select row).ToList();
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
                log.Info("End log INFO... queryComboMstProvinces");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryComboMstAmphures(MST_AMPHURES param)
        {
            log.Info("Start log INFO... queryComboMstAmphures");
            MsgForm msgError = new MsgForm();
            List<MST_AMPHURES> resultList = new List<MST_AMPHURES>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_AMPHURES where row.PROVINCE_ID == param.PROVINCE_ID select row).ToList();
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
                log.Info("End log INFO... queryComboMstAmphures");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryComboMstDistricts(MST_DISTRICTS param)
        {
            log.Info("Start log INFO... queryComboMstDistricts");
            MsgForm msgError = new MsgForm();
            List<MST_DISTRICTS> resultList = new List<MST_DISTRICTS>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_DISTRICTS where row.AMPHURE_ID == param.AMPHURE_ID select row).ToList();
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
                log.Info("End log INFO... queryComboMstDistricts");
            }
            return new object[] { msgError, resultList };
        }

        public object[] updateDataMstBusiness(MST_BUSINESS param)
        {
            log.Info("Start log INFO... updateDataMstBusiness");
            MsgForm msgError = new MsgForm();
            MST_BUSINESS form = new MST_BUSINESS();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_BUSINESS where row.BUSINESS_ID == param.BUSINESS_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        form.BUSINESS_NAME = param.BUSINESS_NAME;
                        form.BUSINESS_ADDRESS = param.BUSINESS_ADDRESS;
                        form.BUSINESS_DISTRICT = param.BUSINESS_DISTRICT;
                        form.BUSINESS_AMPHURE = param.BUSINESS_AMPHURE;
                        form.BUSINESS_PROVINCE = param.BUSINESS_PROVINCE;
                        form.BUSINESS_POSTCODE = param.BUSINESS_POSTCODE;
                        form.BUSINESS_TEL_NO = param.BUSINESS_TEL_NO;
                        form.BUSINESS_FAX = param.BUSINESS_FAX;
                        log.Info("Update Data form MST_BUSINESS WHERE " + form.BUSINESS_ID
                            + " BUSINESS_NAME : " + form.BUSINESS_NAME
                            + " BUSINESS_ADDRESS : " + form.BUSINESS_ADDRESS
                            + " BUSINESS_DISTRICT : " + form.BUSINESS_DISTRICT
                            + " BUSINESS_AMPHURE : " + form.BUSINESS_AMPHURE
                            + " BUSINESS_PROVINCE : " + form.BUSINESS_PROVINCE
                            + " BUSINESS_POSTCODE : " + form.BUSINESS_POSTCODE
                            + " BUSINESS_TEL_NO : " + form.BUSINESS_TEL_NO
                            + " BUSINESS_FAX : " + form.BUSINESS_FAX
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
