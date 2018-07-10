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
                using (var db = new HomeScaleDBEntities())
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

        public object[] queryDataMstDestinationByDestinationId(MST_DESTINATION param)
        {
            log.Info("Start log INFO... queryDataMstDestinationByDestinationId");
            MsgForm msgError = new MsgForm();
            MST_DESTINATION form = new MST_DESTINATION();
            try
            {
                using (var db = new HomeScaleDBEntities())
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

        public object[] insertOrUpdateDataMstDestination(MST_DESTINATION param, string flagAddEdit)
        {
            log.Info("Start log INFO... insertOrUpdateDataMstDestination");
            MsgForm msgError = new MsgForm();
            MST_DESTINATION formInsert = new MST_DESTINATION();
            MST_DESTINATION formUpdate = new MST_DESTINATION();
            try
            {
                using (var db = new HomeScaleDBEntities())
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
                            formInsert.DESTINATION_SUB_DISTRICT = param.DESTINATION_SUB_DISTRICT;
                            formInsert.DESTINATION_DISTRICT = param.DESTINATION_DISTRICT;
                            formInsert.DESTINATION_PROVINCE = param.DESTINATION_PROVINCE;
                            formInsert.DESTINATION_POSTCODE = param.DESTINATION_POSTCODE;
                            formInsert.DESTINATION_TEL_NO = param.DESTINATION_TEL_NO;
                            formInsert.DESTINATION_FAX = param.DESTINATION_FAX;
                            db.MST_DESTINATION.Add(formInsert);
                            log.Info("Insert Data form MST_DESTINATION"
                            + " DESTINATION_ID : " + formInsert.DESTINATION_ID
                            + " DESTINATION_NAME : " + formInsert.DESTINATION_NAME
                            + " DESTINATION_ADDRESS : " + formInsert.DESTINATION_ADDRESS
                            + " DESTINATION_SUB_DISTRICT : " + formInsert.DESTINATION_SUB_DISTRICT
                            + " DESTINATION_DISTRICT : " + formInsert.DESTINATION_DISTRICT
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
                            formUpdate.DESTINATION_SUB_DISTRICT = param.DESTINATION_SUB_DISTRICT;
                            formUpdate.DESTINATION_DISTRICT = param.DESTINATION_DISTRICT;
                            formUpdate.DESTINATION_PROVINCE = param.DESTINATION_PROVINCE;
                            formUpdate.DESTINATION_POSTCODE = param.DESTINATION_POSTCODE;
                            formUpdate.DESTINATION_TEL_NO = param.DESTINATION_TEL_NO;
                            formUpdate.DESTINATION_FAX = param.DESTINATION_FAX;
                            log.Info("Update Data form MST_DESTINATION"
                            + " DESTINATION_ID : " + formUpdate.DESTINATION_ID
                            + " DESTINATION_NAME : " + formUpdate.DESTINATION_NAME
                            + " DESTINATION_ADDRESS : " + formUpdate.DESTINATION_ADDRESS
                            + " DESTINATION_SUB_DISTRICT : " + formUpdate.DESTINATION_SUB_DISTRICT
                            + " DESTINATION_DISTRICT : " + formUpdate.DESTINATION_DISTRICT
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
                using (var db = new HomeScaleDBEntities())
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
