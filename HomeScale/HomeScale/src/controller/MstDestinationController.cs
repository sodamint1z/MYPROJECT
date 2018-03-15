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
    public class MstDestinationController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public object[] searchDataMstDestination()
        {
            Log.Info("Start log INFO... searchDataMstDestination");
            MsgForm msgError = new MsgForm();
            List<MST_DESTINATION> resultList = new List<MST_DESTINATION>();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    resultList = (from row in db.MST_DESTINATION select row).ToList();
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
                Log.Info("End log INFO... searchDataMstDestination");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstDestinationByDestinationId(MST_DESTINATION param)
        {
            Log.Info("Start log INFO... queryDataMstDestinationByDestinationId");
            MsgForm msgError = new MsgForm();
            MST_DESTINATION form = new MST_DESTINATION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_DESTINATION where row.DESTINATION_ID == param.DESTINATION_ID select row).FirstOrDefault();
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
                Log.Info("End log INFO... queryDataMstDestinationByDestinationId");
            }
            return new object[] { msgError, form };
        }

        public object[] insertOrUpdateDataMstDestination(MST_DESTINATION param, string flagAddEdit)
        {
            Log.Info("Start log INFO... insertOrUpdateDataMstDestination");
            MsgForm msgError = new MsgForm();
            MST_DESTINATION formInsert = new MST_DESTINATION();
            MST_DESTINATION formUpdate = new MST_DESTINATION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_DESTINATION where row.DESTINATION_ID == param.DESTINATION_ID select row).FirstOrDefault();
                    if (flagAddEdit.Equals("A"))
                    {
                        if (CheckUtil.isEmpty(formUpdate))
                        {
                            //formInsert.PRODUCT_ID = db.MST_PRODUCT.Count() + 1;
                            formInsert.DESTINATION_ID = param.DESTINATION_ID;
                            formInsert.DESTINATION_NAME = param.DESTINATION_NAME;
                            formInsert.DESTINATION_ADDRESS = param.DESTINATION_ADDRESS;
                            formInsert.DESTINATION_DISTRICT_ONE = param.DESTINATION_DISTRICT_ONE;
                            formInsert.DESTINATION_DISTRICT_TWO = param.DESTINATION_DISTRICT_TWO;
                            formInsert.DESTINATION_COUNTY = param.DESTINATION_COUNTY;
                            formInsert.DESTINATION_POSTCODE = param.DESTINATION_POSTCODE;
                            formInsert.DESTINATION_TEL_NO = param.DESTINATION_TEL_NO;
                            formInsert.DESTINATION_FAX = param.DESTINATION_FAX;
                            db.MST_DESTINATION.Add(formInsert);
                            Log.Info("Insert Data form MST_DESTINATION"
                            + " DESTINATION_ID : " + formInsert.DESTINATION_ID
                            + " DESTINATION_NAME : " + formInsert.DESTINATION_NAME
                            + " DESTINATION_ADDRESS : " + formInsert.DESTINATION_ADDRESS
                            + " DESTINATION_DISTRICT_ONE : " + formInsert.DESTINATION_DISTRICT_ONE
                            + " DESTINATION_DISTRICT_TWO : " + formInsert.DESTINATION_DISTRICT_TWO
                            + " DESTINATION_COUNTY : " + formInsert.DESTINATION_COUNTY
                            + " DESTINATION_POSTCODE : " + formInsert.DESTINATION_POSTCODE
                            + " DESTINATION_TEL_NO : " + formInsert.DESTINATION_TEL_NO
                            + " DESTINATION_FAX : " + formInsert.DESTINATION_FAX
                            );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (CheckUtil.isNotEmpty(formUpdate))
                        {
                            formUpdate.DESTINATION_ID = param.DESTINATION_ID;
                            formUpdate.DESTINATION_NAME = param.DESTINATION_NAME;
                            formUpdate.DESTINATION_ADDRESS = param.DESTINATION_ADDRESS;
                            formUpdate.DESTINATION_DISTRICT_ONE = param.DESTINATION_DISTRICT_ONE;
                            formUpdate.DESTINATION_DISTRICT_TWO = param.DESTINATION_DISTRICT_TWO;
                            formUpdate.DESTINATION_COUNTY = param.DESTINATION_COUNTY;
                            formUpdate.DESTINATION_POSTCODE = param.DESTINATION_POSTCODE;
                            formUpdate.DESTINATION_TEL_NO = param.DESTINATION_TEL_NO;
                            formUpdate.DESTINATION_FAX = param.DESTINATION_FAX;
                            Log.Info("Update Data form MST_DESTINATION"
                            + " DESTINATION_ID : " + formUpdate.DESTINATION_ID
                            + " DESTINATION_NAME : " + formUpdate.DESTINATION_NAME
                            + " DESTINATION_ADDRESS : " + formUpdate.DESTINATION_ADDRESS
                            + " DESTINATION_DISTRICT_ONE : " + formUpdate.DESTINATION_DISTRICT_ONE
                            + " DESTINATION_DISTRICT_TWO : " + formUpdate.DESTINATION_DISTRICT_TWO
                            + " DESTINATION_COUNTY : " + formUpdate.DESTINATION_COUNTY
                            + " DESTINATION_POSTCODE : " + formUpdate.DESTINATION_POSTCODE
                            + " DESTINATION_TEL_NO : " + formUpdate.DESTINATION_TEL_NO
                            + " DESTINATION_FAX : " + formUpdate.DESTINATION_FAX
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
                Log.Info("End log INFO... insertOrUpdateDataMstDestination");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] deleteDataMstDestination(MST_DESTINATION param)
        {
            Log.Info("Start log INFO... deleteDataMstDestination");
            MsgForm msgError = new MsgForm();
            MST_DESTINATION form = new MST_DESTINATION();
            try
            {
                using (var db = new HomeScaleDBEntities())
                {
                    form = (from row in db.MST_DESTINATION where row.DESTINATION_ID == param.DESTINATION_ID select row).FirstOrDefault();
                    if (CheckUtil.isNotEmpty(form))
                    {
                        db.MST_DESTINATION.Remove(form);
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
                Log.Info("End log INFO... deleteDataMstDestination");
            }
            return new object[] { msgError };
        }
    }
}
