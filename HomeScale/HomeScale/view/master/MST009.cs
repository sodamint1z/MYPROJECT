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
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        List<MST_SERVICE_CHARGE> lstFormMstServiceCharge = new List<MST_SERVICE_CHARGE>();
        List<MST_CUSTOMER_SERVICE> lstFormMstCustomerService = new List<MST_CUSTOMER_SERVICE>();
        MST_CUSTOMER formMstCustomer = new MST_CUSTOMER();
        MST_CUSTOMER_SERVICE formMstCustomerService = new MST_CUSTOMER_SERVICE();
        string flagAddEdit = "A";

        public void resetDataMstCustomerService()
        {
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
                        else
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
                        //txt.Text = data.PRODUCT_ID;
                        //txtProductName.Text = data.PRODUCT_NAME;
                        //cboProductUnit.SelectedValue = data.PRODUCT_UNIT.ToString();
                        formMstCustomer = data;
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
                                if (Util.isNotEmpty(data.CUSTOMER_SERVICE_VALUE))
                                {
                                    txtCustomerServiceValue9.Text = data.CUSTOMER_SERVICE_VALUE.ToString();
                                }
                                else
                                {
                                    txtCustomerServiceValue9.Text = "";
                                }
                            }
                            else
                            {
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
                            else
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
            }
        }

    }
}
