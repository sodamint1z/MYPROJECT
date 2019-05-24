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
    public class MST007Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] queryDataLoginStatus()
        {
            log.Info("Start log INFO... queryDataLoginStatus");
            MsgForm msgError = new MsgForm();
            LOGIN_STATUS form = new LOGIN_STATUS();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.LOGIN_STATUS where row.LOGIN_STATUS_ID == 1 select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataLoginStatus");
            }
            return new object[] { msgError, form };
        }

        public object[] searchDataManageUserLogin()
        {
            log.Info("Start log INFO... searchDataManageUserLogin");
            MsgForm msgError = new MsgForm();
            List<USER_LOGIN> resultList = new List<USER_LOGIN>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.USER_LOGIN select row).ToList();
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
                log.Info("End log INFO... searchDataManageUserLogin");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataManageUserLoginByUserId(USER_LOGIN param)
        {
            log.Info("Start log INFO... queryDataManageUserLoginByUserId");
            MsgForm msgError = new MsgForm();
            USER_LOGIN form = new USER_LOGIN();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.USER_LOGIN where row.USER_ID == param.USER_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataManageUserLoginByUserId");
            }
            return new object[] { msgError, form };
        }

        public object[] insertOrUpdateDataManageUserLogin(USER_LOGIN param, LOGIN_STATUS paramStatus, string flagAddEdit)
        {
            log.Info("Start log INFO... insertOrUpdateDataManageUserLogin");
            MsgForm msgError = new MsgForm();
            USER_LOGIN formInsert = new USER_LOGIN();
            USER_LOGIN formUpdate = new USER_LOGIN();
            LOGIN_STATUS formUpdateStatusLogin = new LOGIN_STATUS();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    formUpdate = (from row in db.USER_LOGIN where row.USER_ID == param.USER_ID select row).FirstOrDefault();
                    formUpdateStatusLogin = (from row in db.LOGIN_STATUS where row.LOGIN_STATUS_ID == 1 select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (Util.isEmpty(formUpdate))
                        {
                            formInsert.USER_ID = param.USER_ID;
                            formInsert.USER_PASSWORD = param.USER_PASSWORD;
                            formInsert.USER_FIRSTNAME = param.USER_FIRSTNAME;
                            formInsert.USER_LASTNAME = param.USER_LASTNAME;
                            formInsert.STATUS_FLAG = param.STATUS_FLAG;
                            db.USER_LOGIN.Add(formInsert);
                            log.Info("Insert Data form USER_LOGIN"
                            + " USER_ID : " + formInsert.USER_ID
                            + " USER_PASSWORD : " + formInsert.USER_PASSWORD
                            + " USER_FIRSTNAME : " + formInsert.USER_FIRSTNAME
                            + " USER_LASTNAME : " + formInsert.USER_LASTNAME
                            + " STATUS_FLAG : " + formInsert.STATUS_FLAG
                            );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (Util.isNotEmpty(formUpdate))
                        {
                            formUpdate.USER_PASSWORD = param.USER_PASSWORD;
                            formUpdate.USER_FIRSTNAME = param.USER_FIRSTNAME;
                            formUpdate.USER_LASTNAME = param.USER_LASTNAME;
                            formUpdate.STATUS_FLAG = param.STATUS_FLAG;
                            log.Info("Update Data form USER_LOGIN"
                            + " USER_ID : " + formUpdate.USER_ID
                            + " USER_PASSWORD : " + formUpdate.USER_PASSWORD
                            + " USER_FIRSTNAME : " + formUpdate.USER_FIRSTNAME
                            + " USER_LASTNAME : " + formUpdate.USER_LASTNAME
                            + " STATUS_FLAG : " + formUpdate.STATUS_FLAG
                            );
                        }
                    }
                    formUpdateStatusLogin.LOGIN_STATUS_VALUE = paramStatus.LOGIN_STATUS_VALUE;
                    log.Info("Update Data form LOGIN_STATUS"
                            + " LOGIN_STATUS_ID : " + paramStatus.LOGIN_STATUS_ID
                            + " LOGIN_STATUS_VALUE : " + paramStatus.LOGIN_STATUS_VALUE
                            );
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
                log.Info("End log INFO... insertOrUpdateDataManageUserLogin");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] deleteDataManageUserLogin(USER_LOGIN param)
        {
            log.Info("Start log INFO... deleteDataManageUserLogin");
            MsgForm msgError = new MsgForm();
            USER_LOGIN form = new USER_LOGIN();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.USER_LOGIN where row.USER_ID == param.USER_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        db.USER_LOGIN.Remove(form);
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
                log.Info("End log INFO... deleteDataManageUserLogin");
            }
            return new object[] { msgError };
        }
    }
}
