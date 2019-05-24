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
    public class MST005Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] queryComboMstVendor()
        {
            log.Info("Start log INFO... queryComboMstVendor");
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
                log.Info("End log INFO... queryComboMstVendor");
            }
            return new object[] { msgError, resultList };
        }

        public object[] searchDataVwMstCarRegistertion()
        {
            log.Info("Start log INFO... searchDataVwMstCarRegistertion");
            MsgForm msgError = new MsgForm();
            List<VW_MST_CAR_REGISTERTION> resultList = new List<VW_MST_CAR_REGISTERTION>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.VW_MST_CAR_REGISTERTION select row).ToList();
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
                log.Info("End log INFO... searchDataVwMstCarRegistertion");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstCarRegistertionByCarRegistertionId(MST_CAR_REGISTERTION param)
        {
            log.Info("Start log INFO... queryDataMstCarRegistertionBycarRegistertionId");
            MsgForm msgError = new MsgForm();
            MST_CAR_REGISTERTION form = new MST_CAR_REGISTERTION();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_CAR_REGISTERTION where row.CAR_REGISTERTION_ID == param.CAR_REGISTERTION_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataMstCarRegistertionBycarRegistertionId");
            }
            return new object[] { msgError, form };
        }

        public object[] insertOrUpdateDataMstCarRegistertion(MST_CAR_REGISTERTION param, string flagAddEdit)
        {
            log.Info("Start log INFO... insertOrUpdateDataMstCarRegistertion");
            MsgForm msgError = new MsgForm();
            MST_CAR_REGISTERTION formInsert = new MST_CAR_REGISTERTION();
            MST_CAR_REGISTERTION formUpdate = new MST_CAR_REGISTERTION();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_CAR_REGISTERTION where row.CAR_REGISTERTION_ID == param.CAR_REGISTERTION_ID select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (Util.isEmpty(formUpdate))
                        {
                            formInsert.CAR_REGISTERTION_ID = param.CAR_REGISTERTION_ID;
                            formInsert.CAR_REGISTERTION_NAME = param.CAR_REGISTERTION_NAME;
                            formInsert.CAR_REGISTERTION_VENDOR_ID = param.CAR_REGISTERTION_VENDOR_ID;
                            db.MST_CAR_REGISTERTION.Add(formInsert);
                            log.Info("Insert Data form MST_CAR_REGISTERTION"
                            + " CAR_REGISTERTION_ID : " + formInsert.CAR_REGISTERTION_ID
                            + " CAR_REGISTERTION_NAME : " + formInsert.CAR_REGISTERTION_NAME
                            + " CAR_REGISTERTION_VENDOR_ID : " + formInsert.CAR_REGISTERTION_VENDOR_ID
                            );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (Util.isNotEmpty(formUpdate))
                        {
                            formUpdate.CAR_REGISTERTION_ID = param.CAR_REGISTERTION_ID;
                            formUpdate.CAR_REGISTERTION_NAME = param.CAR_REGISTERTION_NAME;
                            formUpdate.CAR_REGISTERTION_VENDOR_ID = param.CAR_REGISTERTION_VENDOR_ID;
                            log.Info("Update Data form MST_CAR_REGISTERTION"
                            + " CAR_REGISTERTION_ID : " + formUpdate.CAR_REGISTERTION_ID
                            + " CAR_REGISTERTION_NAME : " + formUpdate.CAR_REGISTERTION_NAME
                            + " CAR_REGISTERTION_VENDOR_ID : " + formUpdate.CAR_REGISTERTION_VENDOR_ID
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
                log.Info("End log INFO... insertOrUpdateDataMstCarRegistertion");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] updateDataMstCarRegistertion(MST_CAR_REGISTERTION param)
        {
            log.Info("Start log INFO... updateDataMstCarRegistertion");
            MsgForm msgError = new MsgForm();
            MST_CAR_REGISTERTION form = new MST_CAR_REGISTERTION();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_CAR_REGISTERTION where row.CAR_REGISTERTION_ID == param.CAR_REGISTERTION_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
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
                log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                log.Info("End log INFO... updateDataMstCarRegistertion");
            }
            return new object[] { msgError };
        }

        public object[] deleteDataMstCarRegistertion(MST_CAR_REGISTERTION param)
        {
            log.Info("Start log INFO... deleteDataMstCarRegistertion");
            MsgForm msgError = new MsgForm();
            MST_CAR_REGISTERTION form = new MST_CAR_REGISTERTION();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_CAR_REGISTERTION where row.CAR_REGISTERTION_ID == param.CAR_REGISTERTION_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        db.MST_CAR_REGISTERTION.Remove(form);
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
                log.Info("End log INFO... deleteDataMstCarRegistertion");
            }
            return new object[] { msgError };
        }
    }
}
