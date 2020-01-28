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
    public partial class MST008 : Form
    {
        public MST008()
        {
            InitializeComponent();
            queryComboMstProvinces();
            queryDataMstBusiness();
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MST_BUSINESS formMstBusiness = new MST_BUSINESS();
        List<MST_AMPHURES> lstdataAmphure = new List<MST_AMPHURES>();
        List<MST_DISTRICTS> lstdataDistricts = new List<MST_DISTRICTS>();

        public void queryDataMstBusiness()
        {
            MST008Controller mst008Ctrl = new MST008Controller();
            formMstBusiness.BUSINESS_ID = 1;
            try
            {
                object[] result = mst008Ctrl.queryDataMstBusiness(formMstBusiness);

                MsgForm msgForm = (MsgForm)result[0];
                MST_BUSINESS data = (MST_BUSINESS)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        formMstBusiness = data;

                        txtBusinessName.Text = data.BUSINESS_NAME;
                        txtBusinessAddress.Text = data.BUSINESS_ADDRESS;
                        txtPostcode.Text = data.BUSINESS_POSTCODE;
                        txtBusinessTelNo.Text = data.BUSINESS_TEL_NO;
                        txtFax.Text = data.BUSINESS_FAX;
                        formMstBusiness.BUSINESS_PROVINCE = data.BUSINESS_PROVINCE;
                        formMstBusiness.BUSINESS_AMPHURE = data.BUSINESS_AMPHURE;
                        formMstBusiness.BUSINESS_DISTRICT = data.BUSINESS_DISTRICT;

                        queryComboMstAmphures();
                        queryComboMstDistricts();

                        cboDistricts.SelectedValue = data.BUSINESS_DISTRICT;
                        cboAmphure.SelectedValue = data.BUSINESS_AMPHURE;
                        cboProvince.SelectedValue = data.BUSINESS_PROVINCE;
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

        public void queryComboMstProvinces()
        {
            MST008Controller mst008Ctrl = new MST008Controller();
            try
            {
                object[] result = mst008Ctrl.queryComboMstProvinces();

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
            MST008Controller mst008Ctrl = new MST008Controller();
            MST_AMPHURES form = new MST_AMPHURES();
            try
            {
                if (!formMstBusiness.BUSINESS_PROVINCE.Equals(0))
                {
                    form.PROVINCE_ID = formMstBusiness.BUSINESS_PROVINCE;
                }
                else
                {
                    form.PROVINCE_ID = Int32.Parse(cboProvince.SelectedValue.ToString());
                }

                if (Util.isEmpty(form.PROVINCE_ID))
                {
                    return;
                }

                object[] result = mst008Ctrl.queryComboMstAmphures(form);

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
            MST008Controller mst008Ctrl = new MST008Controller();
            MST_DISTRICTS form = new MST_DISTRICTS();
            try
            {
                if (!formMstBusiness.BUSINESS_AMPHURE.Equals(0))
                {
                    form.AMPHURE_ID = formMstBusiness.BUSINESS_AMPHURE;
                }
                else
                {
                    form.AMPHURE_ID = Int32.Parse(cboAmphure.SelectedValue.ToString());
                }

                if (Util.isEmpty(form.AMPHURE_ID))
                {
                    return;
                }

                object[] result = mst008Ctrl.queryComboMstDistricts(form);

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

        public void updateDataMstBusiness()
        {
            MST008Controller mst008Ctrl = new MST008Controller();
            MST_BUSINESS form = new MST_BUSINESS();
            try
            {
                form.BUSINESS_ID = formMstBusiness.BUSINESS_ID;
                form.BUSINESS_NAME = txtBusinessName.Text;
                form.BUSINESS_ADDRESS = txtBusinessAddress.Text;
                form.BUSINESS_DISTRICT = Int32.Parse(cboDistricts.SelectedValue.ToString());
                form.BUSINESS_AMPHURE = Int32.Parse(cboAmphure.SelectedValue.ToString());
                form.BUSINESS_PROVINCE = Int32.Parse(cboProvince.SelectedValue.ToString());
                form.BUSINESS_POSTCODE = txtPostcode.Text;
                form.BUSINESS_TEL_NO = txtBusinessTelNo.Text;
                form.BUSINESS_FAX = txtFax.Text;

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = mst008Ctrl.updateDataMstBusiness(form);

                MsgForm msgForm = (MsgForm)result[0];

                if (msgForm.statusFlag.Equals(1))
                {
                    MessageBox.Show(CommonUtil.SAVE_DATA_SUCCESS);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            updateDataMstBusiness();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            queryDataMstBusiness();
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
            //formMstBusiness = new MST_BUSINESS();
            formMstBusiness.BUSINESS_PROVINCE = 0;
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
            //formMstBusiness = new MST_BUSINESS();
            formMstBusiness.BUSINESS_AMPHURE = 0;
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
