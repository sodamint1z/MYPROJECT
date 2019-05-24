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
    public class STS001Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] queryDataStsSerialPort(STS_SERIAL_PORT param)
        {
            log.Info("Start log INFO... queryDataStsSerialPort");
            MsgForm msgError = new MsgForm();
            STS_SERIAL_PORT form = new STS_SERIAL_PORT();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.STS_SERIAL_PORT where row.SERIAL_PORT_ID == param.SERIAL_PORT_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataStsSerialPort");
            }
            return new object[] { msgError, form };
        }

        public object[] updateDataStsSerialPort(STS_SERIAL_PORT param)
        {
            log.Info("Start log INFO... updateDataStsSerialPort");
            MsgForm msgError = new MsgForm();
            STS_SERIAL_PORT form = new STS_SERIAL_PORT();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.STS_SERIAL_PORT where row.SERIAL_PORT_ID == param.SERIAL_PORT_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        form.SERIAL_PORT_PORT_NO = param.SERIAL_PORT_PORT_NO;
                        form.SERIAL_PORT_BAUD_RATE = param.SERIAL_PORT_BAUD_RATE;
                        form.SERIAL_PORT_DATA_BITS = param.SERIAL_PORT_DATA_BITS;
                        form.SERIAL_PORT_STOP_BITS = param.SERIAL_PORT_STOP_BITS;
                        form.SERIAL_PORT_PARITY = param.SERIAL_PORT_PARITY;
                        form.SERIAL_PORT_HAND_SHAKING = param.SERIAL_PORT_HAND_SHAKING;
                        form.SERIAL_PORT_STATUS_FLAG = param.SERIAL_PORT_STATUS_FLAG;
                        log.Info("Update Data form STS_SERIAL_PORT WHERE " + form.SERIAL_PORT_ID
                            + " SERIAL_PORT_PORT_NO : " + form.SERIAL_PORT_PORT_NO
                            + " SERIAL_PORT_BAUD_RATE : " + form.SERIAL_PORT_BAUD_RATE
                            + " SERIAL_PORT_DATA_BITS : " + form.SERIAL_PORT_DATA_BITS
                            + " SERIAL_PORT_STOP_BITS : " + form.SERIAL_PORT_STOP_BITS
                            + " SERIAL_PORT_PARITY : " + form.SERIAL_PORT_PARITY
                            + " SERIAL_PORT_HAND_SHAKING : " + form.SERIAL_PORT_HAND_SHAKING
                            + " SERIAL_PORT_STATUS_FLAG : " + form.SERIAL_PORT_STATUS_FLAG
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
                log.Info("End log INFO... updateDataStsSerialPort");
            }
            return new object[] { msgError };
        }
    }
}
