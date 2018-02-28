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
    public class MstVendorController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] searchDataMstVendor()
        {
            Log.Info("Start log INFO... searchDataMstVendor");
            MsgForm msgError = new MsgForm();
            List<MST_VENDOR> resultList = new List<MST_VENDOR>();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    resultList = (from row in db.MST_VENDOR select row).ToList();
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
                Log.Info("End log INFO... searchDataMstVendor");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstVendorByVendorId(MST_VENDOR param)
        {
            Log.Info("Start log INFO... queryDataMstVendorByVendorId");
            MsgForm msgError = new MsgForm();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_VENDOR where row.VENDOR_ID == param.VENDOR_ID select row).FirstOrDefault();
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
                Log.Info("End log INFO... queryDataMstVendorByVendorId");
            }
            return new object[] { msgError, form };
        }

        public object[] insertOrUpdateDataMstVendor(MST_VENDOR param, string flagAddEdit)
        {
            Log.Info("Start log INFO... insertOrUpdateDataMstVendor");
            MsgForm msgError = new MsgForm();
            MST_VENDOR formInsert = new MST_VENDOR();
            MST_VENDOR formUpdate = new MST_VENDOR();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_VENDOR where row.VENDOR_ID == param.VENDOR_ID select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (CheckUtil.isEmpty(formUpdate))
                        {
                            formInsert.VENDOR_ID = param.VENDOR_ID;
                            formInsert.VENDOR_NAME = param.VENDOR_NAME;
                            formInsert.VENDOR_ADDRESS = param.VENDOR_ADDRESS;
                            formInsert.VENDOR_DISTRICT_ONE = param.VENDOR_DISTRICT_ONE;
                            formInsert.VENDOR_DISTRICT_TWO = param.VENDOR_DISTRICT_TWO;
                            formInsert.VENDOR_COUNTY = param.VENDOR_COUNTY;
                            formInsert.VENDOR_POSTCODE = param.VENDOR_POSTCODE;
                            formInsert.VENDOR_TEL_NO = param.VENDOR_TEL_NO;
                            formInsert.VENDOR_FAX = param.VENDOR_FAX;
                            db.MST_VENDOR.Add(formInsert);
                            Log.Info("Insert Data form MST_VENDOR"
                                + " VENDOR_ID : " + formInsert.VENDOR_ID
                                + " VENDOR_NAME : " + formInsert.VENDOR_NAME
                                + " VENDOR_ADDRESS : " + formInsert.VENDOR_ADDRESS
                                + " VENDOR_DISTRICT_ONE : " + formInsert.VENDOR_DISTRICT_ONE
                                + " VENDOR_DISTRICT_TWO : " + formInsert.VENDOR_DISTRICT_TWO
                                + " VENDOR_COUNTY : " + formInsert.VENDOR_COUNTY
                                + " VENDOR_POSTCODE : " + formInsert.VENDOR_POSTCODE
                                + " VENDOR_TEL_NO : " + formInsert.VENDOR_TEL_NO
                                + " VENDOR_FAX : " + formInsert.VENDOR_FAX
                                );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (CheckUtil.isNotEmpty(formUpdate))
                        {
                            formUpdate.VENDOR_ID = param.VENDOR_ID;
                            formUpdate.VENDOR_NAME = param.VENDOR_NAME;
                            formUpdate.VENDOR_ADDRESS = param.VENDOR_ADDRESS;
                            formUpdate.VENDOR_DISTRICT_ONE = param.VENDOR_DISTRICT_ONE;
                            formUpdate.VENDOR_DISTRICT_TWO = param.VENDOR_DISTRICT_TWO;
                            formUpdate.VENDOR_COUNTY = param.VENDOR_COUNTY;
                            formUpdate.VENDOR_POSTCODE = param.VENDOR_POSTCODE;
                            formUpdate.VENDOR_TEL_NO = param.VENDOR_TEL_NO;
                            formUpdate.VENDOR_FAX = param.VENDOR_FAX;
                            Log.Info("Update Data form MST_VENDOR"
                                + " VENDOR_ID : " + formUpdate.VENDOR_ID
                                + " VENDOR_NAME : " + formUpdate.VENDOR_NAME
                                + " VENDOR_ADDRESS : " + formUpdate.VENDOR_ADDRESS
                                + " VENDOR_DISTRICT_ONE : " + formUpdate.VENDOR_DISTRICT_ONE
                                + " VENDOR_DISTRICT_TWO : " + formUpdate.VENDOR_DISTRICT_TWO
                                + " VENDOR_COUNTY : " + formUpdate.VENDOR_COUNTY
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
                Log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                Log.Info("End log INFO... insertOrUpdateDataMstVendor");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] updateDataMstVendor(MST_VENDOR param)
        {
            Log.Info("Start log INFO... updateDataMstVendor");
            MsgForm msgError = new MsgForm();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_VENDOR where row.VENDOR_ID == param.VENDOR_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        form.VENDOR_NAME = param.VENDOR_NAME;
                        form.VENDOR_ADDRESS = param.VENDOR_ADDRESS;
                        form.VENDOR_DISTRICT_ONE = param.VENDOR_DISTRICT_ONE;
                        form.VENDOR_DISTRICT_TWO = param.VENDOR_DISTRICT_TWO;
                        form.VENDOR_COUNTY = param.VENDOR_COUNTY;
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
                Log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                Log.Info("End log INFO... updateDataMstVendor");
            }
            return new object[] { msgError };
        }

        public object[] deleteDataMstVendor(MST_VENDOR param)
        {
            Log.Info("Start log INFO... deleteDataMstVendor");
            MsgForm msgError = new MsgForm();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_VENDOR where row.VENDOR_ID == param.VENDOR_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        Log.Info("Delete Data form MST_VENDOR"
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
                Log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                Log.Info("End log INFO... deleteDataMstVendor");
            }
            return new object[] { msgError };
        }
    }
}
