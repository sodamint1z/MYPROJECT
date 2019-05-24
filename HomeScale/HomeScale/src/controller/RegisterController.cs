using log4net;
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
    public class RegisterController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] checkRegister()
        {
            log.Info("Start log INFO... checkRegister");
            MsgForm msgError = new MsgForm();
            REGISTER result = new REGISTER();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    result = (from row in db.REGISTERs where row.REGISTER_ID == 1 select row).FirstOrDefault();
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
                log.Info("End log INFO... checkRegister");
            }
            return new object[] { msgError, result };
        }

        public object[] updateDataRegister(REGISTER param)
        {
            log.Info("Start log INFO... updateDataRegister");
            MsgForm msgError = new MsgForm();
            REGISTER form = new REGISTER();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.REGISTERs where row.REGISTER_ID == param.REGISTER_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        form.REGISTER_MODEL = Util.toString(CryptoUtil.encrypt(param.REGISTER_MODEL));
                        form.REGISTER_TYPE = Util.toString(CryptoUtil.encrypt(param.REGISTER_TYPE));
                        form.REGISTER_SERIAL_NO = Util.toString(CryptoUtil.encrypt(param.REGISTER_SERIAL_NO));
                        form.REGISTER_DEVICE_ID = Util.toString(CryptoUtil.encrypt(param.REGISTER_DEVICE_ID));
                        form.REGISTER_PASSWORD_HASH = param.REGISTER_PASSWORD_HASH;
                        form.REGISTER_CODE = Util.toString(CryptoUtil.encrypt(param.REGISTER_CODE));
                        log.Info("Update Data form REGISTER WHERE " + form.REGISTER_ID
                            + " REGISTER_MODEL : " + form.REGISTER_MODEL
                            + " REGISTER_TYPE : " + form.REGISTER_TYPE
                            + " REGISTER_SERIAL_NO : " + form.REGISTER_SERIAL_NO
                            + " REGISTER_DEVICE_ID : " + form.REGISTER_DEVICE_ID
                            + " REGISTER_PASSWORD_HASH : " + form.REGISTER_PASSWORD_HASH
                            + " REGISTER_CODE : " + form.REGISTER_CODE
                            );
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
                log.Info("End log INFO... updateDataRegister");
            }
            return new object[] { msgError };
        }
    }
}
