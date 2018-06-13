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
            return new object[] { msgError, resultList };
        }

        public object[] searchDataVwMstProduct()
        {
            Log.Info("Start log INFO... searchDataVwMstProduct");
            MsgForm msgError = new MsgForm();
            List<VW_MST_PRODUCT> resultList = new List<VW_MST_PRODUCT>();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    resultList = (from row in db.VW_MST_PRODUCT select row).ToList();
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
                Log.Info("End log INFO... searchDataVwMstProduct");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstProductByProductId(MST_PRODUCT param)
        {
            Log.Info("Start log INFO... queryDataMstProductByProductId");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT form = new MST_PRODUCT();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_PRODUCT where row.PRODUCT_ID == param.PRODUCT_ID select row).FirstOrDefault();
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
                Log.Info("End log INFO... queryDataMstProductByProductId");
            }
            return new object[] { msgError, form };
        }

        public object[] insertOrUpdateDataMstProduct(MST_PRODUCT param, string flagAddEdit)
        {
            Log.Info("Start log INFO... insertOrUpdateDataMstProduct");
            MsgForm msgError = new MsgForm();
            MST_PRODUCT formInsert = new MST_PRODUCT();
            MST_PRODUCT formUpdate = new MST_PRODUCT();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_PRODUCT where row.PRODUCT_ID == param.PRODUCT_ID select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (Util.isEmpty(formUpdate))
                        {
                            //formInsert.PRODUCT_ID = db.MST_PRODUCT.Count() + 1;
                            formInsert.PRODUCT_ID = param.PRODUCT_ID;
                            formInsert.PRODUCT_NAME = param.PRODUCT_NAME;
                            formInsert.PRODUCT_UNIT = param.PRODUCT_UNIT;
                            db.MST_PRODUCT.Add(formInsert);
                            Log.Info("Insert Data form MST_PRODUCT"
                            + " PRODUCT_ID : " + formInsert.PRODUCT_ID
                            + " PRODUCT_NAME : " + formInsert.PRODUCT_NAME
                            + " PRODUCT_UNIT : " + formInsert.PRODUCT_UNIT
                            );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (Util.isNotEmpty(formUpdate))
                        {
                            formUpdate.PRODUCT_ID = param.PRODUCT_ID;
                            formUpdate.PRODUCT_NAME = param.PRODUCT_NAME;
                            formUpdate.PRODUCT_UNIT = param.PRODUCT_UNIT;
                            Log.Info("Update Data form MST_PRODUCT"
                            + " PRODUCT_ID : " + formUpdate.PRODUCT_ID
                            + " PRODUCT_NAME : " + formUpdate.PRODUCT_NAME
                            + " PRODUCT_UNIT : " + formUpdate.PRODUCT_UNIT
                            );
                        }
                    }
                    //formUpdate = (from row in db.MST_PRODUCT where row.PRODUCT_ID == param.PRODUCT_ID select row).FirstOrDefault();
                    //if (CheckUtil.isEmpty(formUpdate))
                    //{
                    //    //formInsert.PRODUCT_ID = db.MST_PRODUCT.Count() + 1;
                    //    formInsert.PRODUCT_ID = param.PRODUCT_ID;
                    //    formInsert.PRODUCT_NAME = param.PRODUCT_NAME;
                    //    formInsert.PRODUCT_UNIT = param.PRODUCT_UNIT;
                    //    db.MST_PRODUCT.Add(formInsert);
                    //}
                    //else if (CheckUtil.isNotEmpty(formUpdate))
                    //{
                    //    formUpdate.PRODUCT_ID = param.PRODUCT_ID;
                    //    formUpdate.PRODUCT_NAME = param.PRODUCT_NAME;
                    //    formUpdate.PRODUCT_UNIT = param.PRODUCT_UNIT;
                    //}
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
                Log.Info("End log INFO... insertOrUpdateDataMstProduct");
            }
            return new object[] { msgError, formUpdate };
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
                    if (Util.isNotEmpty(form))
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
            return new object[] { msgError };
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
                    if (Util.isNotEmpty(form))
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
            return new object[] { msgError };
        }
    }
}
