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
    public class MenuMainController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public object[] queryDataMstBusiness(MST_BUSINESS param)
        {
            log.Info("Start log INFO... queryDataMstBusiness");
            MsgForm msgError = new MsgForm();
            MST_BUSINESS form = new MST_BUSINESS();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_BUSINESS where row.BUSINESS_ID == param.BUSINESS_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataMstBusiness");
            }
            return new object[] { msgError, form };
        }
    }
}
