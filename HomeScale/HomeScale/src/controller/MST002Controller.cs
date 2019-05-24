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
    public class MST002Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] searchDataMstProductUnit()
        {
            log.Info("Start log INFO... searchDataMstProductUnit");
            MsgForm msgError = new MsgForm();
            List<MST_PRODUCT_UNIT> resultList = new List<MST_PRODUCT_UNIT>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_PRODUCT_UNIT select row).ToList();
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
                log.Info("End log INFO... searchDataMstProductUnit");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstProductUnitByProductUnitId(MST_PRODUCT_UNIT param)
        {
            log.Info("Start log INFO... queryDataMstProductUnitByProductUnitId");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT_UNIT form = new MST_PRODUCT_UNIT();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_PRODUCT_UNIT where row.PRODUCT_UNIT_ID == param.PRODUCT_UNIT_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataMstProductUnitByProductUnitId");
            }
            return new object[] { msgError, form };
        }

        public object[] insertOrUpdateDataMstProductUnit(MST_PRODUCT_UNIT param, string flagAddEdit)
        {
            log.Info("Start log INFO... insertOrUpdateDataMstProductUnit");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT_UNIT formInsert = new MST_PRODUCT_UNIT();
            MST_PRODUCT_UNIT formUpdate = new MST_PRODUCT_UNIT();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_PRODUCT_UNIT where row.PRODUCT_UNIT_ID == param.PRODUCT_UNIT_ID select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (Util.isEmpty(formUpdate))
                        {
                            formInsert.PRODUCT_UNIT_ID = param.PRODUCT_UNIT_ID;
                            formInsert.PRODUCT_UNIT_NAME = param.PRODUCT_UNIT_NAME;
                            db.MST_PRODUCT_UNIT.Add(formInsert);
                            log.Info("Insert Data form MST_PRODUCT_UNIT"
                            + " PRODUCT_UNIT_ID : " + formInsert.PRODUCT_UNIT_ID
                            + " PRODUCT_UNIT_NAME : " + formInsert.PRODUCT_UNIT_NAME
                            );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (Util.isNotEmpty(formUpdate))
                        {
                            formUpdate.PRODUCT_UNIT_ID = param.PRODUCT_UNIT_ID;
                            formUpdate.PRODUCT_UNIT_NAME = param.PRODUCT_UNIT_NAME;
                            log.Info("Update Data form MST_PRODUCT_UNIT"
                            + " PRODUCT_UNIT_ID : " + formUpdate.PRODUCT_UNIT_ID
                            + " PRODUCT_UNIT_NAME : " + formUpdate.PRODUCT_UNIT_NAME
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
                log.Info("End log INFO... insertOrUpdateDataMstProductUnit");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] updateDataMstProductUnit(MST_PRODUCT_UNIT param)
        {
            log.Info("Start log INFO... updateDataMstProductUnit");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT_UNIT form = new MST_PRODUCT_UNIT();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_PRODUCT_UNIT where row.PRODUCT_UNIT_ID == param.PRODUCT_UNIT_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        form.PRODUCT_UNIT_NAME = param.PRODUCT_UNIT_NAME;
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
                log.Info("End log INFO... updateDataMstProductUnit");
            }
            return new object[] { msgError };
        }

        public object[] deleteDataMstProductUnit(MST_PRODUCT_UNIT param)
        {
            log.Info("Start log INFO... deleteDataMstProductUnit");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT_UNIT form = new MST_PRODUCT_UNIT();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_PRODUCT_UNIT where row.PRODUCT_UNIT_ID == param.PRODUCT_UNIT_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        log.Info("Delete Data form MST_PRODUCT_UNIT"
                            + " PRODUCT_UNIT_ID : " + form.PRODUCT_UNIT_ID
                            );
                        db.MST_PRODUCT_UNIT.Remove(form);
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
                log.Info("End log INFO... deleteDataMstProductUnit");
            }
            return new object[] { msgError };
        }
    }
}
