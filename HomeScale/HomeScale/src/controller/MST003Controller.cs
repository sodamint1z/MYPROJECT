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
    public class MST003Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] searchDataMstVendor()
        {
            log.Info("Start log INFO... searchDataMstVendor");
            MsgForm msgError = new MsgForm();
            List<MST_VENDOR> resultList = new List<MST_VENDOR>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_VENDOR select row).ToList();
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
                log.Info("End log INFO... searchDataMstVendor");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstVendorByVendorId(MST_VENDOR param)
        {
            log.Info("Start log INFO... queryDataMstVendorByVendorId");
            MsgForm msgError = new MsgForm();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_VENDOR where row.VENDOR_ID == param.VENDOR_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataMstVendorByVendorId");
            }
            return new object[] { msgError, form };
        }

        public object[] insertOrUpdateDataMstVendor(MST_VENDOR param, string flagAddEdit)
        {
            log.Info("Start log INFO... insertOrUpdateDataMstVendor");
            MsgForm msgError = new MsgForm();
            MST_VENDOR formInsert = new MST_VENDOR();
            MST_VENDOR formUpdate = new MST_VENDOR();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_VENDOR where row.VENDOR_ID == param.VENDOR_ID select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (Util.isEmpty(formUpdate))
                        {
                            formInsert.VENDOR_ID = param.VENDOR_ID;
                            formInsert.VENDOR_NAME = param.VENDOR_NAME;
                            formInsert.VENDOR_ADDRESS = param.VENDOR_ADDRESS;
                            formInsert.VENDOR_SUB_DISTRICT = param.VENDOR_SUB_DISTRICT;
                            formInsert.VENDOR_DISTRICT = param.VENDOR_DISTRICT;
                            formInsert.VENDOR_PROVINCE = param.VENDOR_PROVINCE;
                            formInsert.VENDOR_POSTCODE = param.VENDOR_POSTCODE;
                            formInsert.VENDOR_TEL_NO = param.VENDOR_TEL_NO;
                            formInsert.VENDOR_FAX = param.VENDOR_FAX;
                            db.MST_VENDOR.Add(formInsert);
                            log.Info("Insert Data form MST_VENDOR"
                                + " VENDOR_ID : " + formInsert.VENDOR_ID
                                + " VENDOR_NAME : " + formInsert.VENDOR_NAME
                                + " VENDOR_ADDRESS : " + formInsert.VENDOR_ADDRESS
                                + " VENDOR_SUB_DISTRICT : " + formInsert.VENDOR_SUB_DISTRICT
                                + " VENDOR_DISTRICT : " + formInsert.VENDOR_DISTRICT
                                + " VENDOR_PROVINCE : " + formInsert.VENDOR_PROVINCE
                                + " VENDOR_POSTCODE : " + formInsert.VENDOR_POSTCODE
                                + " VENDOR_TEL_NO : " + formInsert.VENDOR_TEL_NO
                                + " VENDOR_FAX : " + formInsert.VENDOR_FAX
                                );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (Util.isNotEmpty(formUpdate))
                        {
                            formUpdate.VENDOR_ID = param.VENDOR_ID;
                            formUpdate.VENDOR_NAME = param.VENDOR_NAME;
                            formUpdate.VENDOR_ADDRESS = param.VENDOR_ADDRESS;
                            formUpdate.VENDOR_SUB_DISTRICT = param.VENDOR_SUB_DISTRICT;
                            formUpdate.VENDOR_DISTRICT = param.VENDOR_DISTRICT;
                            formUpdate.VENDOR_PROVINCE = param.VENDOR_PROVINCE;
                            formUpdate.VENDOR_POSTCODE = param.VENDOR_POSTCODE;
                            formUpdate.VENDOR_TEL_NO = param.VENDOR_TEL_NO;
                            formUpdate.VENDOR_FAX = param.VENDOR_FAX;
                            log.Info("Update Data form MST_VENDOR"
                                + " VENDOR_ID : " + formUpdate.VENDOR_ID
                                + " VENDOR_NAME : " + formUpdate.VENDOR_NAME
                                + " VENDOR_ADDRESS : " + formUpdate.VENDOR_ADDRESS
                                + " VENDOR_SUB_DISTRICT : " + formUpdate.VENDOR_SUB_DISTRICT
                                + " VENDOR_DISTRICT : " + formUpdate.VENDOR_DISTRICT
                                + " VENDOR_PROVINCE : " + formUpdate.VENDOR_PROVINCE
                                + " VENDOR_POSTCODE : " + formUpdate.VENDOR_POSTCODE
                                + " VENDOR_TEL_NO : " + formUpdate.VENDOR_TEL_NO
                                + " VENDOR_FAX : " + formUpdate.VENDOR_FAX
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
                log.Info("End log INFO... insertOrUpdateDataMstVendor");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] updateDataMstVendor(MST_VENDOR param)
        {
            log.Info("Start log INFO... updateDataMstVendor");
            MsgForm msgError = new MsgForm();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_VENDOR where row.VENDOR_ID == param.VENDOR_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        form.VENDOR_NAME = param.VENDOR_NAME;
                        form.VENDOR_ADDRESS = param.VENDOR_ADDRESS;
                        form.VENDOR_SUB_DISTRICT = param.VENDOR_SUB_DISTRICT;
                        form.VENDOR_DISTRICT = param.VENDOR_DISTRICT;
                        form.VENDOR_PROVINCE = param.VENDOR_PROVINCE;
                        form.VENDOR_POSTCODE = param.VENDOR_POSTCODE;
                        form.VENDOR_TEL_NO = param.VENDOR_TEL_NO;
                        form.VENDOR_FAX = param.VENDOR_FAX;
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
                log.Info("End log INFO... updateDataMstVendor");
            }
            return new object[] { msgError };
        }

        public object[] deleteDataMstVendor(MST_VENDOR param)
        {
            log.Info("Start log INFO... deleteDataMstVendor");
            MsgForm msgError = new MsgForm();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_VENDOR where row.VENDOR_ID == param.VENDOR_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        log.Info("Delete Data form MST_VENDOR"
                            + " VENDOR_ID : " + form.VENDOR_ID
                            );
                        db.MST_VENDOR.Remove(form);
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
                log.Info("End log INFO... deleteDataMstVendor");
            }
            return new object[] { msgError };
        }
    }
}
