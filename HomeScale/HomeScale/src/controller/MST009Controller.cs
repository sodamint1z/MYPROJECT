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
    public class MST009Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Dictionary<string, string> xxxx()
        {
            Dictionary<string, string> aaaaa = new Dictionary<string, string>();
            aaaaa[""] = "";

            return aaaaa;
        }

        public object[] searchDataVwMstCustomer()
        {
            log.Info("Start log INFO... searchDataVwMstCustomer");
            MsgForm msgError = new MsgForm();
            List<VW_MST_CUSTOMER> resultList = new List<VW_MST_CUSTOMER>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.VW_MST_CUSTOMER select row).ToList();
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
                log.Info("End log INFO... searchDataVwMstCustomer");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryDataMstCustomer(MST_CUSTOMER param)
        {
            log.Info("Start log INFO... queryDataMstCustomer");
            MsgForm msgError = new MsgForm();
            MST_CUSTOMER form = new MST_CUSTOMER();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_CUSTOMER where row.CUSTOMER_ID == param.CUSTOMER_ID select row).FirstOrDefault();
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
                log.Info("End log INFO... queryDataMstCustomer");
            }
            return new object[] { msgError, form };
        }

        public object[] queryLstDataMstCustomerService(MST_CUSTOMER_SERVICE param)
        {
            log.Info("Start log INFO... queryLstDataMstCustomerService");
            MsgForm msgError = new MsgForm();
            List<MST_CUSTOMER_SERVICE> resultList = new List<MST_CUSTOMER_SERVICE>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_CUSTOMER_SERVICE where row.CUSTOMER_ID == param.CUSTOMER_ID select row).ToList();
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
                log.Info("End log INFO... queryLstDataMstCustomerService");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryLstDataMstServiceCharge()
        {
            log.Info("Start log INFO... queryLstDataMstServiceCharge");
            MsgForm msgError = new MsgForm();
            List<MST_SERVICE_CHARGE> resultList = new List<MST_SERVICE_CHARGE>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_SERVICE_CHARGE select row).ToList();
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
                log.Info("End log INFO... queryLstDataMstServiceCharge");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryComboMstProvinces()
        {
            log.Info("Start log INFO... queryComboMstProvinces");
            MsgForm msgError = new MsgForm();
            List<MST_PROVINCES> resultList = new List<MST_PROVINCES>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_PROVINCES select row).ToList();
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
                log.Info("End log INFO... queryComboMstProvinces");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryComboMstAmphures(MST_AMPHURES param)
        {
            log.Info("Start log INFO... queryComboMstAmphures");
            MsgForm msgError = new MsgForm();
            List<MST_AMPHURES> resultList = new List<MST_AMPHURES>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_AMPHURES where row.PROVINCE_ID == param.PROVINCE_ID select row).ToList();
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
                log.Info("End log INFO... queryComboMstAmphures");
            }
            return new object[] { msgError, resultList };
        }

        public object[] queryComboMstDistricts(MST_DISTRICTS param)
        {
            log.Info("Start log INFO... queryComboMstDistricts");
            MsgForm msgError = new MsgForm();
            List<MST_DISTRICTS> resultList = new List<MST_DISTRICTS>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    resultList = (from row in db.MST_DISTRICTS where row.AMPHURE_ID == param.AMPHURE_ID select row).ToList();
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
                log.Info("End log INFO... queryComboMstDistricts");
            }
            return new object[] { msgError, resultList };
        }

        public object[] insertOrUpdateDataMst009(MST_CUSTOMER param, List<MST_CUSTOMER_SERVICE> lstParamCustomerService, string flagAddEdit)
        {
            log.Info("Start log INFO... insertOrUpdateDataMst009");
            MsgForm msgError = new MsgForm();
            MST_CUSTOMER formInsert = new MST_CUSTOMER();
            MST_CUSTOMER formUpdate = new MST_CUSTOMER();
            MST_CUSTOMER_SERVICE formInsertCustomerService = new MST_CUSTOMER_SERVICE();
            MST_CUSTOMER_SERVICE formUpdateCustomerService = new MST_CUSTOMER_SERVICE();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    formUpdate = (from row in db.MST_CUSTOMER where row.CUSTOMER_ID == param.CUSTOMER_ID select row).FirstOrDefault();

                    if (flagAddEdit.Equals("A"))
                    {
                        if (Util.isEmpty(formUpdate))
                        {
                            formInsert.CUSTOMER_ID = param.CUSTOMER_ID;
                            formInsert.CUSTOMER_STATEMENT_STATUS = param.CUSTOMER_STATEMENT_STATUS;
                            formInsert.CUSTOMER_NAME = param.CUSTOMER_NAME;
                            formInsert.CUSTOMER_ADDRESS = param.CUSTOMER_ADDRESS;
                            formInsert.CUSTOMER_DISTRICT = param.CUSTOMER_DISTRICT;
                            formInsert.CUSTOMER_AMPHURE = param.CUSTOMER_AMPHURE;
                            formInsert.CUSTOMER_PROVINCE = param.CUSTOMER_PROVINCE;
                            formInsert.CUSTOMER_POSTCODE = param.CUSTOMER_POSTCODE;
                            formInsert.CUSTOMER_TEL_NO = param.CUSTOMER_TEL_NO;
                            formInsert.CUSTOMER_FAX = param.CUSTOMER_FAX;
                            db.MST_CUSTOMER.Add(formInsert);
                            log.Info("Update Data form MST_CUSTOMER"
                            + " CUSTOMER_ID : " + formInsert.CUSTOMER_ID
                            + " CUSTOMER_STATEMENT_STATUS : " + formInsert.CUSTOMER_STATEMENT_STATUS
                            + " CUSTOMER_NAME : " + formInsert.CUSTOMER_NAME
                            + " CUSTOMER_ADDRESS : " + formInsert.CUSTOMER_ADDRESS
                            + " CUSTOMER_DISTRICT : " + formInsert.CUSTOMER_DISTRICT
                            + " CUSTOMER_AMPHURE : " + formInsert.CUSTOMER_AMPHURE
                            + " CUSTOMER_PROVINCE : " + formInsert.CUSTOMER_PROVINCE
                            + " CUSTOMER_POSTCODE : " + formInsert.CUSTOMER_POSTCODE
                            + " CUSTOMER_TEL_NO : " + formInsert.CUSTOMER_TEL_NO
                            + " CUSTOMER_FAX : " + formInsert.CUSTOMER_FAX
                            );
                        }
                    }
                    else if (flagAddEdit.Equals("E"))
                    {
                        if (Util.isNotEmpty(formUpdate))
                        {
                            formUpdate.CUSTOMER_STATEMENT_STATUS = param.CUSTOMER_STATEMENT_STATUS;
                            formUpdate.CUSTOMER_NAME = param.CUSTOMER_NAME;
                            formUpdate.CUSTOMER_ADDRESS = param.CUSTOMER_ADDRESS;
                            formUpdate.CUSTOMER_DISTRICT = param.CUSTOMER_DISTRICT;
                            formUpdate.CUSTOMER_AMPHURE = param.CUSTOMER_AMPHURE;
                            formUpdate.CUSTOMER_PROVINCE = param.CUSTOMER_PROVINCE;
                            formUpdate.CUSTOMER_POSTCODE = param.CUSTOMER_POSTCODE;
                            formUpdate.CUSTOMER_TEL_NO = param.CUSTOMER_TEL_NO;
                            formUpdate.CUSTOMER_FAX = param.CUSTOMER_FAX;
                            log.Info("Update Data form MST_CUSTOMER"
                            + " CUSTOMER_STATEMENT_STATUS : " + formUpdate.CUSTOMER_STATEMENT_STATUS
                            + " CUSTOMER_NAME : " + formUpdate.CUSTOMER_NAME
                            + " CUSTOMER_ADDRESS : " + formUpdate.CUSTOMER_ADDRESS
                            + " CUSTOMER_DISTRICT : " + formUpdate.CUSTOMER_DISTRICT
                            + " CUSTOMER_AMPHURE : " + formUpdate.CUSTOMER_AMPHURE
                            + " CUSTOMER_PROVINCE : " + formUpdate.CUSTOMER_PROVINCE
                            + " CUSTOMER_POSTCODE : " + formUpdate.CUSTOMER_POSTCODE
                            + " CUSTOMER_TEL_NO : " + formUpdate.CUSTOMER_TEL_NO
                            + " CUSTOMER_FAX : " + formUpdate.CUSTOMER_FAX
                            );
                        }
                    }

                    foreach (MST_CUSTOMER_SERVICE dbean in lstParamCustomerService)
                    {
                        formUpdateCustomerService = (from row in db.MST_CUSTOMER_SERVICE where row.CUSTOMER_SERVICE_ID == dbean.CUSTOMER_SERVICE_ID select row).FirstOrDefault();

                        if (Util.isEmpty(formUpdateCustomerService))
                        {
                            //formInsertCustomerService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formInsertCustomerService = new MST_CUSTOMER_SERVICE();
                            formInsertCustomerService.CUSTOMER_SERVICE_ID = db.MST_CUSTOMER_SERVICE.Count() + 1;
                            formInsertCustomerService.CUSTOMER_SERVICE_VALUE = dbean.CUSTOMER_SERVICE_VALUE;
                            formInsertCustomerService.CUSTOMER_ID = dbean.CUSTOMER_ID;
                            formInsertCustomerService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            db.MST_CUSTOMER_SERVICE.Add(formInsertCustomerService);
                            log.Info("Insert Data form MST_CUSTOMER_SERVICE"
                            + " CUSTOMER_SERVICE_ID : " + formInsertCustomerService.CUSTOMER_SERVICE_ID
                            + " CUSTOMER_SERVICE_VALUE : " + formInsertCustomerService.CUSTOMER_SERVICE_VALUE
                            + " CUSTOMER_ID : " + formInsertCustomerService.CUSTOMER_ID
                            + " SERVICE_CHARGE_ID : " + formInsertCustomerService.SERVICE_CHARGE_ID
                            );
                        }
                        else
                        {
                            formUpdateCustomerService.CUSTOMER_SERVICE_VALUE = dbean.CUSTOMER_SERVICE_VALUE;
                            formUpdateCustomerService.CUSTOMER_ID = dbean.CUSTOMER_ID;
                            formUpdateCustomerService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            log.Info("Update Data form MST_CUSTOMER_SERVICE"
                            + " CUSTOMER_SERVICE_ID : " + formUpdateCustomerService.CUSTOMER_SERVICE_ID
                            + " CUSTOMER_SERVICE_VALUE : " + formUpdateCustomerService.CUSTOMER_SERVICE_VALUE
                            + " CUSTOMER_ID : " + formUpdateCustomerService.CUSTOMER_ID
                            + " SERVICE_CHARGE_ID : " + formUpdateCustomerService.SERVICE_CHARGE_ID
                            );
                        }

                        //if (flagAddEdit.Equals("A"))
                        //{
                        //    if (Util.isEmpty(formUpdateCustomerService))
                        //    {
                        //        //formInsertCustomerService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                        //        formInsertCustomerService = new MST_CUSTOMER_SERVICE();
                        //        formInsertCustomerService.CUSTOMER_SERVICE_ID = db.MST_CUSTOMER_SERVICE.Count() + 1;
                        //        formInsertCustomerService.CUSTOMER_SERVICE_VALUE = dbean.CUSTOMER_SERVICE_VALUE;
                        //        formInsertCustomerService.CUSTOMER_ID = dbean.CUSTOMER_ID;
                        //        formInsertCustomerService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                        //        db.MST_CUSTOMER_SERVICE.Add(formInsertCustomerService);
                        //        log.Info("Insert Data form MST_CUSTOMER_SERVICE"
                        //        + " CUSTOMER_SERVICE_ID : " + formInsertCustomerService.CUSTOMER_SERVICE_ID
                        //        + " CUSTOMER_SERVICE_VALUE : " + formInsertCustomerService.CUSTOMER_SERVICE_VALUE
                        //        + " CUSTOMER_ID : " + formInsertCustomerService.CUSTOMER_ID
                        //        + " SERVICE_CHARGE_ID : " + formInsertCustomerService.SERVICE_CHARGE_ID
                        //        );
                        //    }
                        //}
                        //else if (flagAddEdit.Equals("E"))
                        //{
                        //    if (Util.isNotEmpty(formUpdateCustomerService))
                        //    {
                        //        formUpdateCustomerService.CUSTOMER_SERVICE_VALUE = dbean.CUSTOMER_SERVICE_VALUE;
                        //        formUpdateCustomerService.CUSTOMER_ID = dbean.CUSTOMER_ID;
                        //        formUpdateCustomerService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                        //        log.Info("Update Data form MST_CUSTOMER_SERVICE"
                        //        + " CUSTOMER_SERVICE_ID : " + formUpdateCustomerService.CUSTOMER_SERVICE_ID
                        //        + " CUSTOMER_SERVICE_VALUE : " + formUpdateCustomerService.CUSTOMER_SERVICE_VALUE
                        //        + " CUSTOMER_ID : " + formUpdateCustomerService.CUSTOMER_ID
                        //        + " SERVICE_CHARGE_ID : " + formUpdateCustomerService.SERVICE_CHARGE_ID
                        //        );
                        //    }
                        //}
                        db.SaveChanges();
                    }
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
                log.Info("End log INFO... insertOrUpdateDataMst009");
            }
            return new object[] { msgError, formUpdate };
        }

        public object[] deleteDataMst009(MST_CUSTOMER param)
        {
            log.Info("Start log INFO... deleteDataMst009");
            MsgForm msgError = new MsgForm();
            MST_CUSTOMER form = new MST_CUSTOMER();
            List<MST_CUSTOMER_SERVICE> lstFormCustomerService = new List<MST_CUSTOMER_SERVICE>();
            try
            {
                using (var db = new PaknampoScaleDBEntities())
                {
                    form = (from row in db.MST_CUSTOMER where row.CUSTOMER_ID == param.CUSTOMER_ID select row).FirstOrDefault();
                    if (Util.isNotEmpty(form))
                    {
                        db.MST_CUSTOMER.Remove(form);
                    }

                    lstFormCustomerService = (from row in db.MST_CUSTOMER_SERVICE where row.CUSTOMER_ID == param.CUSTOMER_ID select row).ToList();
                    if (Util.isNotEmpty(lstFormCustomerService))
                    {
                        db.MST_CUSTOMER_SERVICE.RemoveRange(lstFormCustomerService);
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
                log.Info("End log INFO... deleteDataMst009");
            }
            return new object[] { msgError };
        }
    }
}
