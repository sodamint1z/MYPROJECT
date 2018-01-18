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
    public class MstCarRegistertionController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] queryComboMstVendor()
        {
            Log.Info("Start log INFO... queryComboMstVendor");
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
                Log.Info("End log INFO... queryComboMstVendor");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription, resultList };
        }

        public object[] searchDataVwMstCarRegistertion()
        {
            Log.Info("Start log INFO... searchDataVwMstCarRegistertion");
            MsgForm msgError = new MsgForm();
            List<VW_MST_CAR_REGISTERTION> resultList = new List<VW_MST_CAR_REGISTERTION>();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    resultList = (from row in db.VW_MST_CAR_REGISTERTION select row).ToList();
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
                Log.Info("End log INFO... searchDataVwMstCarRegistertion");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription, resultList, resultList.Count() };
        }

        public object[] insertDataMstCarRegistertion(MST_CAR_REGISTERTION param)
        {
            Log.Info("Start log INFO... insertDataMstCarRegistertion");
            MsgForm msgError = new MsgForm();
            MST_CAR_REGISTERTION form = new MST_CAR_REGISTERTION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form.CAR_REGISTERTION_ID = db.MST_CAR_REGISTERTION.Count() + 1;
                    form.CAR_REGISTERTION_NAME = param.CAR_REGISTERTION_NAME;
                    form.CAR_REGISTERTION_VENDOR_ID = param.CAR_REGISTERTION_VENDOR_ID;
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.MST_CAR_REGISTERTION.Add(form);
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
                Log.Info("End log INFO... insertDataMstCarRegistertion");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }

        public object[] updateDataMstCarRegistertion(MST_CAR_REGISTERTION param)
        {
            Log.Info("Start log INFO... updateDataMstCarRegistertion");
            MsgForm msgError = new MsgForm();
            MST_CAR_REGISTERTION form = new MST_CAR_REGISTERTION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_CAR_REGISTERTION where row.CAR_REGISTERTION_ID == param.CAR_REGISTERTION_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        form.CAR_REGISTERTION_NAME = param.CAR_REGISTERTION_NAME;
                        form.CAR_REGISTERTION_VENDOR_ID = param.CAR_REGISTERTION_VENDOR_ID;
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
                Log.Info("End log INFO... updateDataMstCarRegistertion");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }

        public object[] deleteDataMstCarRegistertion(MST_CAR_REGISTERTION param)
        {
            Log.Info("Start log INFO... deleteDataMstCarRegistertion");
            MsgForm msgError = new MsgForm();
            MST_CAR_REGISTERTION form = new MST_CAR_REGISTERTION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_CAR_REGISTERTION where row.CAR_REGISTERTION_ID == param.CAR_REGISTERTION_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.MST_CAR_REGISTERTION.Remove(form);
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
                Log.Info("End log INFO... deleteDataMstCarRegistertion");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }
    }
}
