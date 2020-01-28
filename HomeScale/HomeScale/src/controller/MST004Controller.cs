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
    public class MST004Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] searchDataMstDestination()
        {
            log.Info("Start log INFO... searchDataMstDestination");
            MsgForm msgError = new MsgForm();
            List<MST_DESTINATION> resultList = new List<MST_DESTINATION>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_DESTINATION select row).ToList();
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
                log.Info("End log INFO... searchDataMstDestination");
            }
            return new object[] { msgError, resultList };
        }

        public object[] searchDataVwMstDestination()
        {
            log.Info("Start log INFO... searchDataVwMstDestination");
            MsgForm msgError = new MsgForm();
            List<VW_MST_DESTINATION> resultList = new List<VW_MST_DESTINATION>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.VW_MST_DESTINATION select row).ToList();
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
                log.Info("End log INFO... searchDataVwMstDestination");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstDestinationByDestinationId(MST_DESTINATION param)
        {
            log.Info("Start log INFO... queryDataMstDestinationByDestinationId");
            MsgForm msgError = new MsgForm();
            MST_DESTINATION form = new MST_DESTINATION();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_DESTINATION where row.DESTINATION_ID == param.DESTINATION_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataMstDestinationByDestinationId");
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

        public object[] insertOrUpdateDataMstDestination(MST_DESTINATION param, string flagAddEdit)
        {
            log.Info("Start log INFO... insertOrUpdateDataMstDestination");
            MsgForm msgError = new MsgForm();
            MST_DESTINATION formInsert = new MST_DESTINATION();
            MST_DESTINATION formUpdate = new MST_DESTINATION();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_DESTINATION where row.DESTINATION_ID == param.DESTINATION_ID select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (Util.isEmpty(formUpdate))
                        {
                            //formInsert.PRODUCT_ID = db.MST_PRODUCT.Count() + 1;
                            formInsert.DESTINATION_ID = param.DESTINATION_ID;
                            formInsert.DESTINATION_NAME = param.DESTINATION_NAME;
                            formInsert.DESTINATION_ADDRESS = param.DESTINATION_ADDRESS;
                            formInsert.DESTINATION_DISTRICT = param.DESTINATION_DISTRICT;
                            formInsert.DESTINATION_AMPHURE = param.DESTINATION_AMPHURE;
                            formInsert.DESTINATION_PROVINCE = param.DESTINATION_PROVINCE;
                            formInsert.DESTINATION_POSTCODE = param.DESTINATION_POSTCODE;
                            formInsert.DESTINATION_TEL_NO = param.DESTINATION_TEL_NO;
                            formInsert.DESTINATION_FAX = param.DESTINATION_FAX;
                            db.MST_DESTINATION.Add(formInsert);
                            log.Info("Insert Data form MST_DESTINATION"
                            + " DESTINATION_ID : " + formInsert.DESTINATION_ID
                            + " DESTINATION_NAME : " + formInsert.DESTINATION_NAME
                            + " DESTINATION_ADDRESS : " + formInsert.DESTINATION_ADDRESS
                            + " DESTINATION_DISTRICT : " + formInsert.DESTINATION_DISTRICT
                            + " DESTINATION_AMPHURE : " + formInsert.DESTINATION_AMPHURE
                            + " DESTINATION_PROVINCE : " + formInsert.DESTINATION_PROVINCE
                            + " DESTINATION_POSTCODE : " + formInsert.DESTINATION_POSTCODE
                            + " DESTINATION_TEL_NO : " + formInsert.DESTINATION_TEL_NO
                            + " DESTINATION_FAX : " + formInsert.DESTINATION_FAX
                            );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (Util.isNotEmpty(formUpdate))
                        {
                            formUpdate.DESTINATION_ID = param.DESTINATION_ID;
                            formUpdate.DESTINATION_NAME = param.DESTINATION_NAME;
                            formUpdate.DESTINATION_ADDRESS = param.DESTINATION_ADDRESS;
                            formUpdate.DESTINATION_DISTRICT = param.DESTINATION_DISTRICT;
                            formUpdate.DESTINATION_AMPHURE = param.DESTINATION_AMPHURE;
                            formUpdate.DESTINATION_PROVINCE = param.DESTINATION_PROVINCE;
                            formUpdate.DESTINATION_POSTCODE = param.DESTINATION_POSTCODE;
                            formUpdate.DESTINATION_TEL_NO = param.DESTINATION_TEL_NO;
                            formUpdate.DESTINATION_FAX = param.DESTINATION_FAX;
                            log.Info("Update Data form MST_DESTINATION"
                            + " DESTINATION_ID : " + formUpdate.DESTINATION_ID
                            + " DESTINATION_NAME : " + formUpdate.DESTINATION_NAME
                            + " DESTINATION_ADDRESS : " + formUpdate.DESTINATION_ADDRESS
                            + " DESTINATION_DISTRICT : " + formUpdate.DESTINATION_DISTRICT
                            + " DESTINATION_AMPHURE : " + formUpdate.DESTINATION_AMPHURE
                            + " DESTINATION_PROVINCE : " + formUpdate.DESTINATION_PROVINCE
                            + " DESTINATION_POSTCODE : " + formUpdate.DESTINATION_POSTCODE
                            + " DESTINATION_TEL_NO : " + formUpdate.DESTINATION_TEL_NO
                            + " DESTINATION_FAX : " + formUpdate.DESTINATION_FAX
                            );
                        }
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
                log.Info("End log INFO... insertOrUpdateDataMstDestination");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] deleteDataMstDestination(MST_DESTINATION param)
        {
            log.Info("Start log INFO... deleteDataMstDestination");
            MsgForm msgError = new MsgForm();
            MST_DESTINATION form = new MST_DESTINATION();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_DESTINATION where row.DESTINATION_ID == param.DESTINATION_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        db.MST_DESTINATION.Remove(form);
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
                log.Info("End log INFO... deleteDataMstDestination");
            }
            return new object[] { msgError };
        }
    }
}
