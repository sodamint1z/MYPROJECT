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
    public class MstDistinationController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] searchDataMstDistination()
        {
            Log.Info("Start log INFO... searchDataMstDistination");
            MsgForm msgError = new MsgForm();
            List<MST_DISTINATION> resultList = new List<MST_DISTINATION>();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    resultList = (from row in db.MST_DISTINATION select row).ToList();
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
                Log.Info("End log INFO... searchDataMstDistination");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstDistinationByDistinationId(MST_DISTINATION param)
        {
            Log.Info("Start log INFO... queryDataMstDistinationByDistinationId");
            MsgForm msgError = new MsgForm();
            MST_DISTINATION form = new MST_DISTINATION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_DISTINATION where row.DISTINATION_ID == param.DISTINATION_ID select row).FirstOrDefault();
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
                Log.Info("End log INFO... queryDataMstDistinationByDistinationId");
            }
            return new object[] { msgError, form };
        }

        public object[] insertOrUpdateDataMstDistination(MST_DISTINATION param, string flagAddEdit)
        {
            Log.Info("Start log INFO... insertOrUpdateDataMstDistination");
            MsgForm msgError = new MsgForm();
            MST_DISTINATION formInsert = new MST_DISTINATION();
            MST_DISTINATION formUpdate = new MST_DISTINATION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_DISTINATION where row.DISTINATION_ID == param.DISTINATION_ID select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (CheckUtil.isEmpty(formUpdate))
                        {
                            //formInsert.PRODUCT_ID = db.MST_PRODUCT.Count() + 1;
                            formInsert.DISTINATION_ID = param.DISTINATION_ID;
                            formInsert.DISTINATION_NAME = param.DISTINATION_NAME;
                            formInsert.DISTINATION_ADDRESS = param.DISTINATION_ADDRESS;
                            formInsert.DISTINATION_DISTRICT_ONE = param.DISTINATION_DISTRICT_ONE;
                            formInsert.DISTINATION_DISTRICT_TWO = param.DISTINATION_DISTRICT_TWO;
                            formInsert.DISTINATION_COUNTY = param.DISTINATION_COUNTY;
                            formInsert.DISTINATION_POSTCODE = param.DISTINATION_POSTCODE;
                            formInsert.DISTINATION_TEL_NO = param.DISTINATION_TEL_NO;
                            formInsert.DISTINATION_FAX = param.DISTINATION_FAX;
                            db.MST_DISTINATION.Add(formInsert);
                            Log.Info("Insert Data form MST_DISTINATION"
                            + " DISTINATION_ID : " + formInsert.DISTINATION_ID
                            + " DISTINATION_NAME : " + formInsert.DISTINATION_NAME
                            + " DISTINATION_ADDRESS : " + formInsert.DISTINATION_ADDRESS
                            + " DISTINATION_DISTRICT_ONE : " + formInsert.DISTINATION_DISTRICT_ONE
                            + " DISTINATION_DISTRICT_TWO : " + formInsert.DISTINATION_DISTRICT_TWO
                            + " DISTINATION_COUNTY : " + formInsert.DISTINATION_COUNTY
                            + " DISTINATION_POSTCODE : " + formInsert.DISTINATION_POSTCODE
                            + " DISTINATION_TEL_NO : " + formInsert.DISTINATION_TEL_NO
                            + " DISTINATION_FAX : " + formInsert.DISTINATION_FAX
                            );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (CheckUtil.isNotEmpty(formUpdate))
                        {
                            formUpdate.DISTINATION_ID = param.DISTINATION_ID;
                            formUpdate.DISTINATION_NAME = param.DISTINATION_NAME;
                            formUpdate.DISTINATION_ADDRESS = param.DISTINATION_ADDRESS;
                            formUpdate.DISTINATION_DISTRICT_ONE = param.DISTINATION_DISTRICT_ONE;
                            formUpdate.DISTINATION_DISTRICT_TWO = param.DISTINATION_DISTRICT_TWO;
                            formUpdate.DISTINATION_COUNTY = param.DISTINATION_COUNTY;
                            formUpdate.DISTINATION_POSTCODE = param.DISTINATION_POSTCODE;
                            formUpdate.DISTINATION_TEL_NO = param.DISTINATION_TEL_NO;
                            formUpdate.DISTINATION_FAX = param.DISTINATION_FAX;
                            Log.Info("Update Data form MST_DISTINATION"
                            + " DISTINATION_ID : " + formUpdate.DISTINATION_ID
                            + " DISTINATION_NAME : " + formUpdate.DISTINATION_NAME
                            + " DISTINATION_ADDRESS : " + formUpdate.DISTINATION_ADDRESS
                            + " DISTINATION_DISTRICT_ONE : " + formUpdate.DISTINATION_DISTRICT_ONE
                            + " DISTINATION_DISTRICT_TWO : " + formUpdate.DISTINATION_DISTRICT_TWO
                            + " DISTINATION_COUNTY : " + formUpdate.DISTINATION_COUNTY
                            + " DISTINATION_POSTCODE : " + formUpdate.DISTINATION_POSTCODE
                            + " DISTINATION_TEL_NO : " + formUpdate.DISTINATION_TEL_NO
                            + " DISTINATION_FAX : " + formUpdate.DISTINATION_FAX
                            );
                        }
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
                Log.Info("End log INFO... insertOrUpdateDataMstDistination");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] deleteDataMstDistination(MST_DISTINATION param)
        {
            Log.Info("Start log INFO... deleteDataMstDistination");
            MsgForm msgError = new MsgForm();
            MST_DISTINATION form = new MST_DISTINATION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_DISTINATION where row.DISTINATION_ID == param.DISTINATION_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.MST_DISTINATION.Remove(form);
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
                Log.Info("End log INFO... deleteDataMstDistination");
            }
            return new object[] { msgError };
        }
    }
}
