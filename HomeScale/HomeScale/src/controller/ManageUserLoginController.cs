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
    public class ManageUserLoginController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] searchDataManageUserLogin()
        {
            Log.Info("Start log INFO... searchDataManageUserLogin");
            MsgForm msgError = new MsgForm();
            List<USER_LOGIN> resultList = new List<USER_LOGIN>();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    resultList = (from row in db.USER_LOGIN select row).ToList();
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
                Log.Info("End log INFO... searchDataManageUserLogin");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription, resultList, resultList.Count() };
        }

        public object[] insertDataManageUserLogin(USER_LOGIN param)
        {
            Log.Info("Start log INFO... insertDataManageUserLogin");
            MsgForm msgError = new MsgForm();
            USER_LOGIN form = new USER_LOGIN();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form.USER_ID = param.USER_ID;
                    form.USER_PASSWORD = param.USER_PASSWORD;
                    form.USER_FIRSTNAME = param.USER_FIRSTNAME;
                    form.USER_LASTNAME = param.USER_LASTNAME;
                    form.STATUS_FLAG = param.STATUS_FLAG;
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.USER_LOGIN.Add(form);
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
                Log.Info("End log INFO... insertDataManageUserLogin");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }

        public object[] updateDataManageUserLogin(USER_LOGIN param)
        {
            Log.Info("Start log INFO... updateDataManageUserLogin");
            MsgForm msgError = new MsgForm();
            USER_LOGIN form = new USER_LOGIN();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.USER_LOGIN where row.USER_ID == param.USER_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        form.USER_PASSWORD = param.USER_PASSWORD;
                        form.USER_FIRSTNAME = param.USER_FIRSTNAME;
                        form.USER_LASTNAME = param.USER_LASTNAME;
                        form.STATUS_FLAG = param.STATUS_FLAG;
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
                Log.Info("End log INFO... updateDataManageUserLogin");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }

        public object[] deleteDataManageUserLogin(USER_LOGIN param)
        {
            Log.Info("Start log INFO... deleteDataManageUserLogin");
            MsgForm msgError = new MsgForm();
            USER_LOGIN form = new USER_LOGIN();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.USER_LOGIN where row.USER_ID == param.USER_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.USER_LOGIN.Remove(form);
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
                Log.Info("End log INFO... deleteDataManageUserLogin");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }
    }
}
