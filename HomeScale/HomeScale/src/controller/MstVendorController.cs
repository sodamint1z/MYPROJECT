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
            return new object[] { msgError.statusFlag, msgError.messageDescription, resultList, resultList.Count() };
        }

        public object[] insertDataMstVendor(MST_VENDOR param)
        {
            Log.Info("Start log INFO... insertDataMstVendor");
            MsgForm msgError = new MsgForm();
            MST_VENDOR form = new MST_VENDOR();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form.VENDOR_ID = db.MST_VENDOR.Count() + 1;
                    form.VENDOR_NAME = param.VENDOR_NAME;
                    form.VENDOR_ADDRESS = param.VENDOR_ADDRESS;
                    form.VENDOR_DISTRICT_ONE = param.VENDOR_DISTRICT_ONE;
                    form.VENDOR_DISTRICT_TWO = param.VENDOR_DISTRICT_TWO;
                    form.VENDOR_COUNTY = param.VENDOR_COUNTY;
                    form.VENDOR_POSTCODE = param.VENDOR_POSTCODE;
                    form.VENDOR_TEL_NO = param.VENDOR_TEL_NO;
                    form.VENDOR_FAX = param.VENDOR_FAX;
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.MST_VENDOR.Add(form);
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
                Log.Info("End log INFO... insertDataMstVendor");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
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
            return new object[] { msgError.statusFlag, msgError.messageDescription };
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
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }
    }
}
