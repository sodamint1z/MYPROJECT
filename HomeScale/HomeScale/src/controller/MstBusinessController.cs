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
    public class MstBusinessController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] updateDataMstBusiness(MST_BUSINESS param)
        {
            Log.Info("Start log INFO... updateDataMstBusiness");
            MsgForm msgError = new MsgForm();
            MST_BUSINESS form = new MST_BUSINESS();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_BUSINESS where row.BUSINESS_ID == param.BUSINESS_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        form.BUSINESS_NAME = param.BUSINESS_NAME;
                        form.BUSINESS_ADDRESS = param.BUSINESS_ADDRESS;
                        form.BUSINESS_TEL_NO = param.BUSINESS_TEL_NO;
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
                Log.Info("End log INFO... updateDataMstBusiness");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }
    }
}
