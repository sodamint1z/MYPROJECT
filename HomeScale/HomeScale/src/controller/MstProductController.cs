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
    public class MstProductController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] queryComboMstProductUnit()
        {
            Log.Info("Start log INFO... queryComboMstProductUnit");
            MsgForm msgError = new MsgForm();
            List<MST_PRODUCT_UNIT> resultList = new List<MST_PRODUCT_UNIT>();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    resultList = (from row in db.MST_PRODUCT_UNIT select row).ToList();
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
                Log.Info("End log INFO... queryComboMstProductUnit");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription, resultList };
        }

        public object[] searchDataMstProduct()
        {
            Log.Info("Start log INFO... searchDataMstProduct");
            MsgForm msgError = new MsgForm();
            List<MST_PRODUCT> resultList = new List<MST_PRODUCT>();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    resultList = (from row in db.MST_PRODUCT select row).ToList();
                    db.Dispose();
                    msgError.statusFlag = MsgForm.STATUS_SUCCESS;
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString(), ex);
                msgError.statusFlag = MsgForm.STATUS_ERROR;
                msgError.messageDescription = ex.ToString();
            }
            finally
            {
                Log.Info("End log INFO... searchDataMstProduct");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription, resultList };
        }

        public object[] saveDataMstProduct(MST_PRODUCT param)
        {
            Log.Info("Start log INFO... saveDataMstProduct");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT form = new MST_PRODUCT();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form.PRODUCT_ID = db.MST_PRODUCT.Count() + 1;
                    form.PRODUCT_NAME = param.PRODUCT_NAME;
                    form.PRODUCT_UNIT = param.PRODUCT_UNIT;
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.MST_PRODUCT.Add(form);
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
                Log.Info("End log INFO... saveDataMstProduct");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }

        public object[] updateDataMstProduct(MST_PRODUCT param)
        {
            Log.Info("Start log INFO... updateDataMstProduct");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT form = new MST_PRODUCT();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_PRODUCT where row.PRODUCT_ID == param.PRODUCT_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        form.PRODUCT_NAME = param.PRODUCT_NAME;
                        form.PRODUCT_UNIT = param.PRODUCT_UNIT;
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
                Log.Info("End log INFO... updateDataMstProduct");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }

        public object[] deleteDataMstProduct(MST_PRODUCT param)
        {
            Log.Info("Start log INFO... deleteDataMstProduct");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT form = new MST_PRODUCT();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_PRODUCT where row.PRODUCT_ID == param.PRODUCT_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.MST_PRODUCT.Remove(form);
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
                Log.Info("End log INFO... deleteDataMstProduct");
            }
            return new object[] { msgError.statusFlag, msgError.messageDescription };
        }
    }
}
