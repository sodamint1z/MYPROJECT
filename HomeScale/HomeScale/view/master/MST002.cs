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
using PaknampoScale.src.util;
using log4net;

namespace PaknampoScale.view.master
{
    public partial class MST002 : Form
    {
        public MST002()
        {
            InitializeComponent();
            searchDataMstProductUnit();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_PRODUCT_UNIT formMstProductUnit = new MST_PRODUCT_UNIT();
        string flagAddEdit = "A";
        public void resetDataMstProductUnit()
        {
            txtProductUnitId.Text = "";
            txtProductUnitName.Text = "";
            formMstProductUnit = new MST_PRODUCT_UNIT();
            flagAddEdit = "A";
            txtProductUnitId.Enabled = true;
            txtProductUnitId.Focus();
        }

        public void searchDataMstProductUnit()
        {
            MST002Controller mst002Ctrl = new MST002Controller();
            try
            {
                object[] result = mst002Ctrl.searchDataMstProductUnit();

                MsgForm msgForm = (MsgForm)result[0];
                List<MST_PRODUCT_UNIT> lstdata = (List<MST_PRODUCT_UNIT>)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    dataGridView1.DataSource = lstdata;
                    dataGridView1.DefaultCellStyle.Font = new Font("TH SarabunPSK", 16);
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
                    dataGridView1.ColumnHeadersHeight = 150;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("TH SarabunPSK", 16, FontStyle.Bold);
                    dataGridView1.RowTemplate.Height = 40;
                    dataGridView1.Columns[0].HeaderCell.Value = "รหัสหน่วยสินค้า";
                    dataGridView1.Columns[1].HeaderCell.Value = "ชื่อหน่วยสินค้า";
                    lblCountData.Text = "แสดงข้อมูลทั้งหมด " + lstdata.Count() + " รายการ";
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

        public void queryDataMstProductUnitByProductUnitId()
        {
            MST002Controller mst002Ctrl = new MST002Controller();
            try
            {
                object[] result = mst002Ctrl.queryDataMstProductUnitByProductUnitId(formMstProductUnit);

                MsgForm msgForm = (MsgForm)result[0];
                MST_PRODUCT_UNIT data = (MST_PRODUCT_UNIT)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        txtProductUnitId.Text = data.PRODUCT_UNIT_ID;
                        txtProductUnitName.Text = data.PRODUCT_UNIT_NAME;
                        formMstProductUnit = data;
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

        public void insertOrUpdateDataMstProductUnit()
        {
            MST002Controller mst002Ctrl = new MST002Controller();
            MST_PRODUCT_UNIT form = new MST_PRODUCT_UNIT();
            try
            {
                if (Util.isEmpty(txtProductUnitId.Text) 
                    || Util.isEmpty(txtProductUnitName.Text))
                {
                    MessageBox.Show(CommonUtil.REQUIRE_MESSAGE);
                    return;
                }

                form.PRODUCT_UNIT_ID = txtProductUnitId.Text;
                form.PRODUCT_UNIT_NAME = txtProductUnitName.Text;

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mst002Ctrl.insertOrUpdateDataMstProductUnit(form, flagAddEdit);

                MsgForm msgForm = (MsgForm)result[0];
                MST_PRODUCT_UNIT data = (MST_PRODUCT_UNIT)result[1];

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
                            resetDataMstProductUnit();
                            searchDataMstProductUnit();
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
                        resetDataMstProductUnit();
                        searchDataMstProductUnit();
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

        public void deleteDataMstProductUnit()
        {
            MST002Controller mst002Ctrl = new MST002Controller();
            MST_PRODUCT_UNIT form = new MST_PRODUCT_UNIT();
            try
            {
                form.PRODUCT_UNIT_ID = txtProductUnitId.Text;

                if (Util.isEmpty(form.PRODUCT_UNIT_ID))
                {
                    MessageBox.Show(CommonUtil.SELECT_DATA_DELETE);
                    return;
                }

                if (MessageBox.Show(CommonUtil.CONFIRM_DELETE_DATA, CommonUtil.TITLE_DELETE, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    object[] result = mst002Ctrl.deleteDataMstProductUnit(form);

                    MsgForm msgForm = (MsgForm)result[0];

                    if (msgForm.statusFlag.Equals(1))
                    {
                        resetDataMstProductUnit();
                        searchDataMstProductUnit();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                formMstProductUnit.PRODUCT_UNIT_ID = row.Cells[0].Value.ToString();
                queryDataMstProductUnitByProductUnitId();
                flagAddEdit = "E";
                txtProductUnitId.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            insertOrUpdateDataMstProductUnit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetDataMstProductUnit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteDataMstProductUnit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MenuMaster menuMaster = new MenuMaster();
            this.Hide();
            menuMaster.Show();
        }
    }
}
