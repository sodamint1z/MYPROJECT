using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PaknampoScale.src.model.entities;
using PaknampoScale.src.controller;
using PaknampoScale.src.model.form;
using PaknampoScale.src.model.form.combo;
using PaknampoScale.src.util;
using log4net;

namespace PaknampoScale.view.master
{
    public partial class MST009 : Form
    {
        public MST009()
        {
            InitializeComponent();
            loadCombo();
            queryLstDataMstServiceCharge();
            searchDataVwMstCustomer();
            queryComboMstProvinces();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        List<MST_SERVICE_CHARGE> lstFormMstServiceCharge = new List<MST_SERVICE_CHARGE>();
        List<MST_CUSTOMER_SERVICE> lstFormMstCustomerService = new List<MST_CUSTOMER_SERVICE>();
        MST_CUSTOMER formMstCustomer = new MST_CUSTOMER();
        MST_CUSTOMER_SERVICE formMstCustomerService = new MST_CUSTOMER_SERVICE();
        List<MST_AMPHURES> lstdataAmphure = new List<MST_AMPHURES>();
        List<MST_DISTRICTS> lstdataDistricts = new List<MST_DISTRICTS>();
        string flagAddEdit = "A";

        public void resetDataMstCustomer()
        {
            txtId.Text = "";
            cboCustomerStatementStatus.SelectedValue = "";
            txtName.Text = "";
            txtAddress.Text = "";
            cboDistricts.SelectedValue = "";
            cboAmphure.SelectedValue = "";
            cboProvince.SelectedValue = "";
            txtPostcode.Text = "";
            txtTelNo.Text = "";
            txtFax.Text = "";

            formMstCustomer = new MST_CUSTOMER();
            formMstCustomerService = new MST_CUSTOMER_SERVICE();
            flagAddEdit = "A";
            txtId.Enabled = true;
            txtId.Focus();

            lstdataAmphure = new List<MST_AMPHURES>();
            lstdataDistricts = new List<MST_DISTRICTS>();

            cboAmphure.DataSource = lstdataAmphure;
            cboAmphure.ValueMember = "AMPHURE_ID";
            cboAmphure.DisplayMember = "NAME_TH";
            cboAmphure.SelectedValue = "";

            cboDistricts.DataSource = lstdataDistricts;
            cboDistricts.ValueMember = "DISTRICT_ID";
            cboDistricts.DisplayMember = "NAME_TH";
            cboDistricts.SelectedValue = "";
        }

        public void resetDataMstCustomerService()
        {
            txtCustomerServiceId1.Text = "";
            txtCustomerServiceId2.Text = "";
            txtCustomerServiceId3.Text = "";
            txtCustomerServiceId4.Text = "";
            txtCustomerServiceId5.Text = "";
            txtCustomerServiceId6.Text = "";
            txtCustomerServiceId7.Text = "";
            txtCustomerServiceId8.Text = "";
            txtCustomerServiceId9.Text = "";
            txtCustomerServiceId10.Text = "";

            txtCustomerServiceValue1.Text = "";
            txtCustomerServiceValue2.Text = "";
            txtCustomerServiceValue3.Text = "";
            txtCustomerServiceValue4.Text = "";
            txtCustomerServiceValue5.Text = "";
            txtCustomerServiceValue6.Text = "";
            txtCustomerServiceValue7.Text = "";
            txtCustomerServiceValue8.Text = "";
            txtCustomerServiceValue9.Text = "";
            txtCustomerServiceValue10.Text = "";
        }

        public void loadCombo()
        {
            List<ComboStatementOrNotStatementForm> lstComboStatement = new List<ComboStatementOrNotStatementForm>();
            try
            {
                lstComboStatement = LoadComboUtil.loadComboStatement();

                cboCustomerStatementStatus.DataSource = lstComboStatement;
                cboCustomerStatementStatus.ValueMember = "statementId";
                cboCustomerStatementStatus.DisplayMember = "statementValue";
                cboCustomerStatementStatus.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void searchDataVwMstCustomer()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            try
            {
                object[] result = mst009Ctrl.searchDataVwMstCustomer();

                MsgForm msgForm = (MsgForm)result[0];
                List<VW_MST_CUSTOMER> lstData = (List<VW_MST_CUSTOMER>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    dataGridView1.DataSource = lstData;
                    dataGridView1.DefaultCellStyle.Font = new Font("TH SarabunPSK", 16);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("TH SarabunPSK", 16, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;

                    dataGridView1.Columns[0].HeaderCell.Value = "รหัส";
                    dataGridView1.Columns[1].HeaderCell.Value = "บัญชี";
                    dataGridView1.Columns[2].HeaderCell.Value = "ชื่อ";
                    dataGridView1.Columns[3].HeaderCell.Value = "ที่อยู่";
                    dataGridView1.Columns[4].HeaderCell.Value = "ตำบล";
                    dataGridView1.Columns[5].HeaderCell.Value = "อำเภอ";
                    dataGridView1.Columns[6].HeaderCell.Value = "จังหวัด";
                    dataGridView1.Columns[7].HeaderCell.Value = "รหัสไปรษณีย์";
                    dataGridView1.Columns[8].HeaderCell.Value = "เบอร์โทรศัพท์";
                    dataGridView1.Columns[9].HeaderCell.Value = "แฟกซ์";

                    foreach (MST_SERVICE_CHARGE data in lstFormMstServiceCharge)
                    {
                        if (data.SERVICE_CHARGE_ID.Equals(1))
                        {
                            dataGridView1.Columns[10].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(2))
                        {
                            dataGridView1.Columns[11].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(3))
                        {
                            dataGridView1.Columns[12].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(4))
                        {
                            dataGridView1.Columns[13].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(5))
                        {
                            dataGridView1.Columns[14].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(6))
                        {
                            dataGridView1.Columns[15].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(7))
                        {
                            dataGridView1.Columns[16].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(8))
                        {
                            dataGridView1.Columns[17].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(9))
                        {
                            dataGridView1.Columns[18].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                        else if (data.SERVICE_CHARGE_ID.Equals(10))
                        {
                            dataGridView1.Columns[19].HeaderCell.Value = data.SERVICE_CHARGE_VALUE;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryDataMstCustomer()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            try
            {
                object[] result = mst009Ctrl.queryDataMstCustomer(formMstCustomer);

                MsgForm msgForm = (MsgForm)result[0];
                MST_CUSTOMER data = (MST_CUSTOMER)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        txtId.Text = data.CUSTOMER_ID.ToString();
                        cboCustomerStatementStatus.SelectedValue = data.CUSTOMER_STATEMENT_STATUS;
                        txtName.Text = data.CUSTOMER_NAME;
                        txtAddress.Text = data.CUSTOMER_ADDRESS;
                        
                        txtPostcode.Text = data.CUSTOMER_POSTCODE;
                        txtTelNo.Text = data.CUSTOMER_TEL_NO;
                        txtFax.Text = data.CUSTOMER_FAX;

                        formMstCustomer = data;

                        formMstCustomer.CUSTOMER_PROVINCE = data.CUSTOMER_PROVINCE;
                        formMstCustomer.CUSTOMER_AMPHURE = data.CUSTOMER_AMPHURE;
                        formMstCustomer.CUSTOMER_DISTRICT = data.CUSTOMER_DISTRICT;

                        queryComboMstAmphures();
                        queryComboMstDistricts();

                        cboDistricts.SelectedValue = data.CUSTOMER_DISTRICT;
                        cboAmphure.SelectedValue = data.CUSTOMER_AMPHURE;
                        cboProvince.SelectedValue = data.CUSTOMER_PROVINCE;
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryLstDataMstCustomerService()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            try
            {
                object[] result = mst009Ctrl.queryLstDataMstCustomerService(formMstCustomerService);

                MsgForm msgForm = (MsgForm)result[0];
                List<MST_CUSTOMER_SERVICE> lstData = (List<MST_CUSTOMER_SERVICE>)result[1];

                resetDataMstCustomerService();

                if (msgForm.statusFlag.Equals(1))
                {
                    if (!lstData.Equals(null))
                    {
                        lstFormMstCustomerService = lstData;

                        foreach (MST_CUSTOMER_SERVICE data in lstData) 
                        {
                            if (data.SERVICE_CHARGE_ID.Equals(1))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId1.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId1.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue1.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue1.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(2))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId2.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId2.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue2.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue2.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(3))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId3.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId3.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue3.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue3.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(4))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId4.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId4.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue4.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue4.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(5))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId5.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId5.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue5.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue5.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(6))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId6.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId6.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue6.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue6.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(7))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId7.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId7.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue7.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue7.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(8))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId8.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId8.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue8.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue8.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(9))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId9.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId9.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue9.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue9.Text = "";
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(10))
                            {
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_ID))
                                {
                                    txtCustomerServiceId10.Text = data.CUSTOMER_SERVICE_ID.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceId10.Text = "";
                                }
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue10.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue10.Text = "";
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex) 
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryLstDataMstServiceCharge()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            try
            {
                object[] result = mst009Ctrl.queryLstDataMstServiceCharge();

                MsgForm msgForm = (MsgForm)result[0];
                List<MST_SERVICE_CHARGE> lstData = (List<MST_SERVICE_CHARGE>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (!lstData.Equals(null))
                    {
                        lstFormMstServiceCharge = lstData;

                        foreach (MST_SERVICE_CHARGE data in lstData)
                        {
                            if (data.SERVICE_CHARGE_ID.Equals(1))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue1.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus1.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(2))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue2.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus2.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(3))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue3.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus3.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(4))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue4.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus4.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(5))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue5.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus5.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(6))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue6.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus6.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(7))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue7.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus7.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(8))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue8.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus8.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(9))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue9.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus9.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                            else if (data.SERVICE_CHARGE_ID.Equals(10))
                            {
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_VALUE))
                                {
                                    txtServiceChargeValue10.Text = data.SERVICE_CHARGE_VALUE.ToString();
                                }
                                if (Util.isNotEmpty(data.SERVICE_CHARGE_STATUS))
                                {
                                    chkServiceChargeStatus10.Checked = Util.chkboxToBool(data.SERVICE_CHARGE_STATUS);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void insertOrUpdateDataMst009()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            MST_CUSTOMER form = new MST_CUSTOMER();
            MST_CUSTOMER_SERVICE formService = new MST_CUSTOMER_SERVICE();
            List<MST_CUSTOMER_SERVICE> lstForm = new List<MST_CUSTOMER_SERVICE>();
            try
            {
                if (Util.isEmpty(txtId.Text) || Util.isEmpty(cboCustomerStatementStatus.SelectedValue))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.CUSTOMER_ID = Int32.Parse(txtId.Text);
                form.CUSTOMER_STATEMENT_STATUS = Int32.Parse(cboCustomerStatementStatus.SelectedValue.ToString());
                form.CUSTOMER_NAME = txtName.Text;
                form.CUSTOMER_ADDRESS = txtAddress.Text;
                form.CUSTOMER_DISTRICT = Int32.Parse(cboDistricts.SelectedValue.ToString());
                form.CUSTOMER_AMPHURE = Int32.Parse(cboAmphure.SelectedValue.ToString());
                form.CUSTOMER_PROVINCE = Int32.Parse(cboProvince.SelectedValue.ToString());
                form.CUSTOMER_POSTCODE = txtPostcode.Text;
                form.CUSTOMER_TEL_NO = txtTelNo.Text;
                form.CUSTOMER_FAX = txtFax.Text;
                
                if (flagAddEdit.Equals("A"))
                {
                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue1.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 1;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue2.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 2;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue3.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 3;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue4.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 4;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue5.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 5;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue6.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 6;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue7.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 7;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue8.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 8;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue9.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 9;
                    lstForm.Add(formService);

                    formService = new MST_CUSTOMER_SERVICE();
                    formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue10.Text);
                    formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                    formService.SERVICE_CHARGE_ID = 10;
                    lstForm.Add(formService);
                }
                else if (flagAddEdit.Equals("E"))
                {
                    foreach (MST_CUSTOMER_SERVICE dbean in lstFormMstCustomerService)
                    {
                        if (dbean.SERVICE_CHARGE_ID.Equals(1))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue1.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(2))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue2.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(3))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue3.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(4))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue4.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(5))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue5.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(6))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue6.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(7))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue7.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(8))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue8.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(9))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue9.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                        else if (dbean.SERVICE_CHARGE_ID.Equals(10))
                        {
                            formService = new MST_CUSTOMER_SERVICE();
                            formService.CUSTOMER_SERVICE_ID = dbean.CUSTOMER_SERVICE_ID;
                            formService.CUSTOMER_SERVICE_VALUE = Int32.Parse(txtCustomerServiceValue10.Text);
                            formService.CUSTOMER_ID = Int32.Parse(txtId.Text);
                            formService.SERVICE_CHARGE_ID = dbean.SERVICE_CHARGE_ID;
                            lstForm.Add(formService);
                        }
                    }
                }

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mst009Ctrl.insertOrUpdateDataMst009(form, lstForm, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                MST_CUSTOMER data = (MST_CUSTOMER)result[1];

                if (flagAddEdit.Equals("A"))
                {
                    if (Util.isNotEmpty(data))
                    {
                        if (msgForm.statusFlag.Equals(1))
                        {
                            MessageBox.Show(CommonUtil.DUPLICATE_DATA);
                        }
                        else
                        {
                            MessageBox.Show("Error : " + msgForm.messageDescription);
                        }
                    }
                    else
                    {
                        if (msgForm.statusFlag.Equals(1))
                        {
                            resetDataMstCustomer();
                            resetDataMstCustomerService();
                            searchDataVwMstCustomer();
                            MessageBox.Show(CommonUtil.SAVE_DATA_SUCCESS);
                        }
                        else
                        {
                            MessageBox.Show("Error : " + msgForm.messageDescription);
                        }
                    }
                }
                else if (flagAddEdit.Equals("E"))
                {
                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstCustomer();
                        resetDataMstCustomerService();
                        searchDataVwMstCustomer();
                        MessageBox.Show(CommonUtil.SAVE_DATA_SUCCESS);
                    }
                    else
                    {
                        MessageBox.Show("Error : " + msgForm.messageDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void deleteDataMst009()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            MST_CUSTOMER form = new MST_CUSTOMER();
            try
            {
                form.CUSTOMER_ID = Int32.Parse(txtId.Text);

                if (Util.isEmpty(form.CUSTOMER_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mst009Ctrl.deleteDataMst009(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstCustomer();
                        resetDataMstCustomerService();
                        searchDataVwMstCustomer();
                        MessageBox.Show(CommonUtil.DELETE_DATA_SUCCESS);
                    }
                    else
                    {
                        MessageBox.Show("Error : " + msgForm.messageDescription);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryComboMstProvinces()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            try
            {
                object[] result = mst009Ctrl.queryComboMstProvinces();

                MsgForm msgForm = (MsgForm)result[0];
                List<MST_PROVINCES> lstdata = (List<MST_PROVINCES>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboProvince.DataSource = lstdata;
                    cboProvince.ValueMember = "PROVINCE_ID";
                    cboProvince.DisplayMember = "NAME_TH";
                    cboProvince.SelectedValue = "";
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryComboMstAmphures()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            MST_AMPHURES form = new MST_AMPHURES();
            try
            {
                if (!formMstCustomer.CUSTOMER_PROVINCE.Equals(0))
                {
                    form.PROVINCE_ID = formMstCustomer.CUSTOMER_PROVINCE;
                }
                else
                {
                    form.PROVINCE_ID = Int32.Parse(cboProvince.SelectedValue.ToString());
                }

                if (Util.isEmpty(form.PROVINCE_ID))
                {
                    return;
                }

                object[] result = mst009Ctrl.queryComboMstAmphures(form);

                MsgForm msgForm = (MsgForm)result[0];
                lstdataAmphure = (List<MST_AMPHURES>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboAmphure.DataSource = lstdataAmphure;
                    cboAmphure.ValueMember = "AMPHURE_ID";
                    cboAmphure.DisplayMember = "NAME_TH";
                    cboAmphure.SelectedValue = "";
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryComboMstDistricts()
        {
            MST009Controller mst009Ctrl = new MST009Controller();
            MST_DISTRICTS form = new MST_DISTRICTS();
            try
            {
                if (!formMstCustomer.CUSTOMER_AMPHURE.Equals(0))
                {
                    form.AMPHURE_ID = formMstCustomer.CUSTOMER_AMPHURE;
                }
                else
                {
                    form.AMPHURE_ID = Int32.Parse(cboAmphure.SelectedValue.ToString());
                }

                if (Util.isEmpty(form.AMPHURE_ID))
                {
                    return;
                }

                object[] result = mst009Ctrl.queryComboMstDistricts(form);

                MsgForm msgForm = (MsgForm)result[0];
                lstdataDistricts = (List<MST_DISTRICTS>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    cboDistricts.DataSource = lstdataDistricts;
                    cboDistricts.ValueMember = "DISTRICT_ID";
                    cboDistricts.DisplayMember = "NAME_TH";
                    cboDistricts.SelectedValue = "";
                }
                else
                {
                    MessageBox.Show("Error : " + msgForm.messageDescription);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                formMstCustomer.CUSTOMER_ID = Int32.Parse(row.Cells[0].Value.ToString());
                formMstCustomerService.CUSTOMER_ID = Int32.Parse(row.Cells[0].Value.ToString());
                queryDataMstCustomer();
                queryLstDataMstCustomerService();

                flagAddEdit = "E";
                txtId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataMst009();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataMstCustomer();
            resetDataMstCustomerService();
            queryLstDataMstServiceCharge();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataMst009();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MenuMaster menuMaster = new MenuMaster();
            this.Hide();
            menuMaster.Show();
        }

        private void cboProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formMstCustomer.CUSTOMER_PROVINCE = 0;
            //formMstCustomer = new MST_CUSTOMER();
            //formMstCustomerService = new MST_CUSTOMER_SERVICE();
            lstdataAmphure = new List<MST_AMPHURES>();
            lstdataDistricts = new List<MST_DISTRICTS>();

            cboAmphure.DataSource = lstdataAmphure;
            cboAmphure.ValueMember = "AMPHURE_ID";
            cboAmphure.DisplayMember = "NAME_TH";
            cboAmphure.SelectedValue = "";

            cboDistricts.DataSource = lstdataDistricts;
            cboDistricts.ValueMember = "DISTRICT_ID";
            cboDistricts.DisplayMember = "NAME_TH";
            cboDistricts.SelectedValue = "";

            txtPostcode.Text = "";

            queryComboMstAmphures();
        }

        private void cboAmphure_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formMstCustomer.CUSTOMER_AMPHURE = 0;
            //formMstCustomer = new MST_CUSTOMER();
            //formMstCustomerService = new MST_CUSTOMER_SERVICE();
            lstdataDistricts = new List<MST_DISTRICTS>();

            cboDistricts.DataSource = lstdataDistricts;
            cboDistricts.ValueMember = "DISTRICT_ID";
            cboDistricts.DisplayMember = "NAME_TH";
            cboDistricts.SelectedValue = "";

            txtPostcode.Text = "";

            queryComboMstDistricts();
        }

        private void cboDistricts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtPostcode.Text = "";

            foreach (MST_DISTRICTS data in lstdataDistricts)
            {
                if (cboDistricts.SelectedValue.ToString().Equals(data.DISTRICT_ID.ToString()))
                {
                    txtPostcode.Text = data.ZIP_CODE.ToString();
                    break;
                }
            }
        }
        
    }
}
