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
    public class LoginController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] checkLogin(USER_LOGIN param)
        {
            Log.Info("Start log INFO... checkLogin");
            MsgForm msgError = new MsgForm();
            USER_LOGIN result = new USER_LOGIN();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    result = (from row in db.USER_LOGIN where row.USER_ID == param.USER_ID && row.USER_PASSWORD == param.USER_PASSWORD select row).FirstOrDefault();
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
                Log.Info("End log INFO... checkLogin");
            }
            return new object[] { msgError, result };
        }
    }
}
