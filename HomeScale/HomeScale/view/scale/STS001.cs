using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using PaknampoScale.src.model.entities;
using PaknampoScale.src.controller;
using PaknampoScale.src.model.form;
using PaknampoScale.src.model.form.combo;
using PaknampoScale.src.util;
using log4net;
using System.Text.RegularExpressions;
using System.IO;

namespace PaknampoScale.view.scale
{
    public partial class STS001 : Form
    {
        SerialPort comPort = new SerialPort();

        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);
        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        private SerialPinChangedEventHandler serialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);
        string inputData = String.Empty;

        const int singleDataLength = 12;    // from 0x02 to 0x03
        const int weightDataLength = 7;     // +/-, and 6 digit weight
        const int decimalPositionIndex = 8; // index from 0x02
        static Regex rx = new Regex(@"\x02[+-][0-9]{6}[0-4][0-9A-F]{2}\x03", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static string fragmentString = "";
        public STS001()
        {
            InitializeComponent();
            getSerialPorts();
            loadCombo();
            queryDataStsSerialPort();
            //serialPinChangedEventHandler1 = new SerialPinChangedEventHandler(pinChanged);
            comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        STS_SERIAL_PORT formStsSerialPort = new STS_SERIAL_PORT();

        public void getSerialPorts()
        {
            string[] arrayComPortsNames = null;
            int index = -1;
            string comPortName = null;
            try
            {
                //Com Ports
            arrayComPortsNames = SerialPort.GetPortNames();

            if (arrayComPortsNames.Count() < 1) 
            {
                return;
            }

            do
            {
                index += 1;
                cboPorts.Items.Add(arrayComPortsNames[index]);

            } while (!((arrayComPortsNames[index] == comPortName) || (index == arrayComPortsNames.GetUpperBound(0))));
            Array.Sort(arrayComPortsNames);

            if (index == arrayComPortsNames.GetUpperBound(0))
            {
                comPortName = arrayComPortsNames[0];
            }
            //get first item print in text
            cboPorts.Text = arrayComPortsNames[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            inputData = comPort.ReadExisting();
            if (inputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(setText), new object[] { inputData });
            }
        }

        private void setText(string text)
        {
            //this.rtbConnection.Text += string.Format("{0:X2} ",text);
            this.rtbConnection.Text += text.Trim();

            

            //List<string> foundList = GetAvailableDataList(text, ref fragmentString);

            //this.rtbConnection.Text = foundList;

            if (rtbConnection.Text.Count() > 70)
            {
                this.rtbConnection.Text = "";
            }

            rtbDigital.Text = rtbConnection.Text;


            //int lastSTXIndex = text.LastIndexOf('\x02');
            //if (lastSTXIndex >= 0)
            //{
            //    MatchCollection mc = rx.Matches(text);
            //    foreach (Match m in mc)
            //    {
            //        if (m.Success)
            //        {
            //            // ToDo: XRL check must be implemented
            //            // bool checked = checkXRL(m.Value);
            //            // if (checked)
            //            // {
            //            string formatedData = m.Value.Substring(1, weightDataLength);
            //            int decimalPoint = int.Parse(m.Value.Substring(decimalPositionIndex, 1));
            //            if (decimalPoint > 0)
            //            {
            //                formatedData = formatedData.Insert((weightDataLength - decimalPoint), ".");
            //            }
            //            resultList.Add(formatedData);
            //            if (m.Index == lastSTXIndex)
            //            {
            //                lastSTXIndex = -1;
            //            }
            //            // }
            //        }
            //    }
            //}
            //if ((lastSTXIndex >= 0) && ((text.Length - lastSTXIndex) < singleDataLength))
            //{
            //    fragmentString = text.Substring(lastSTXIndex);
            //}
            //else
            //{
            //    fragmentString = "";
            //}

            //this.rtbConnection.Text += fragmentString;

            //rtbDigital.Text = rtbConnection.Text;
        }

    

        //internal void pinChanged(object sender, SerialPinChangedEventArgs e)
        //{
        //    SerialPinChange SerialPinChange1 = 0;
        //    bool signalState = false;

        //    SerialPinChange1 = e.EventType;
        //    lblCTSStatus.BackColor = Color.Green;
        //    lblDSRStatus.BackColor = Color.Green;
        //    lblRIStatus.BackColor = Color.Green;
        //    lblBreakStatus.BackColor = Color.Green;
        //    switch (SerialPinChange1)
        //    {
        //        case SerialPinChange.Break:
        //            lblBreakStatus.BackColor = Color.Red;
        //            //MessageBox.Show("Break is Set");
        //            break;
        //        case SerialPinChange.CDChanged:
        //            signalState = comPort.CtsHolding;
        //            //  MessageBox.Show("CD = " + signalState.ToString());
        //            break;
        //        case SerialPinChange.CtsChanged:
        //            signalState = comPort.CDHolding;
        //            lblCTSStatus.BackColor = Color.Red;
        //            //MessageBox.Show("CTS = " + signalState.ToString());
        //            break;
        //        case SerialPinChange.DsrChanged:
        //            signalState = comPort.DsrHolding;
        //            lblDSRStatus.BackColor = Color.Red;
        //            // MessageBox.Show("DSR = " + signalState.ToString());
        //            break;
        //        case SerialPinChange.Ring:
        //            lblRIStatus.BackColor = Color.Red;
        //            //MessageBox.Show("Ring Detected");
        //            break;
        //    }
        //}

        public void loadCombo()
        {
            List<ComboBaudRateForm> lstComboBaudRate = new List<ComboBaudRateForm>();
            List<ComboDataBitsForm> lstComboDataBits = new List<ComboDataBitsForm>();
            List<ComboStopBitsForm> lstComboStopBits = new List<ComboStopBitsForm>();
            List<ComboParityForm> lstComboParity = new List<ComboParityForm>();
            List<ComboHandShakingForm> lstComboHandShaking = new List<ComboHandShakingForm>();
            try
            {
                lstComboBaudRate = LoadComboUtil.loadComboBaudRate();
                lstComboDataBits = LoadComboUtil.loadComboDataBits();
                lstComboStopBits = LoadComboUtil.loadComboStopBits();
                lstComboParity = LoadComboUtil.loadComboParity();
                lstComboHandShaking = LoadComboUtil.loadComboHandShaking();

                cboBaudRate.DataSource = lstComboBaudRate;
                cboBaudRate.ValueMember = "baudRateId";
                cboBaudRate.DisplayMember = "baudRateValue";
                cboBaudRate.SelectedValue = 0;

                cboDataBits.DataSource = lstComboDataBits;
                cboDataBits.ValueMember = "dataBitsId";
                cboDataBits.DisplayMember = "dataBitsValue";
                cboDataBits.SelectedValue = 0;

                cboStopBits.DataSource = lstComboStopBits;
                cboStopBits.ValueMember = "stopBitsId";
                cboStopBits.DisplayMember = "stopBitsValue";
                cboStopBits.SelectedValue = 0;

                cboParity.DataSource = lstComboParity;
                cboParity.ValueMember = "parityId";
                cboParity.DisplayMember = "parityValue";
                cboParity.SelectedValue = 0;

                cboHandShaking.DataSource = lstComboHandShaking;
                cboHandShaking.ValueMember = "handShakingId";
                cboHandShaking.DisplayMember = "handShakingValue";
                cboHandShaking.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show("Error : " + ex.ToString());
            }
        }

        public void queryDataStsSerialPort()
        {
            STS001Controller sts001Ctrl = new STS001Controller();
            formStsSerialPort.SERIAL_PORT_ID = 1;
            try
            {
                object[] result = sts001Ctrl.queryDataStsSerialPort(formStsSerialPort);

                MsgForm msgForm = (MsgForm)result[0];
                STS_SERIAL_PORT data = (STS_SERIAL_PORT)result[1];

                if (msgForm.statusFlag.Equals(1))
                {
                    if (Util.isNotEmpty(data))
                    {
                        formStsSerialPort = data;

                        cboPorts.Text = data.SERIAL_PORT_PORT_NO.ToString();
                        cboBaudRate.Text = data.SERIAL_PORT_BAUD_RATE.ToString();
                        cboDataBits.Text = data.SERIAL_PORT_DATA_BITS.ToString();
                        cboStopBits.Text = data.SERIAL_PORT_STOP_BITS;
                        cboParity.Text = data.SERIAL_PORT_PARITY;
                        cboHandShaking.Text = data.SERIAL_PORT_HAND_SHAKING;
                        chkStatusConnectScale.Checked = Util.chkboxToBool(data.SERIAL_PORT_STATUS_FLAG);
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

        public void updateDataStsSerialPort()
        {
            STS001Controller sts001Ctrl = new STS001Controller();
            STS_SERIAL_PORT form = new STS_SERIAL_PORT();
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                form.SERIAL_PORT_ID = formStsSerialPort.SERIAL_PORT_ID;
                form.SERIAL_PORT_PORT_NO = cboPorts.Text;
                form.SERIAL_PORT_BAUD_RATE = Int32.Parse(cboBaudRate.Text);
                form.SERIAL_PORT_DATA_BITS = Int32.Parse(cboDataBits.Text);
                form.SERIAL_PORT_STOP_BITS = cboStopBits.Text;
                form.SERIAL_PORT_PARITY = cboParity.Text;
                form.SERIAL_PORT_HAND_SHAKING = cboHandShaking.Text;
                form.SERIAL_PORT_STATUS_FLAG = Util.chkboxToNumber(chkStatusConnectScale.Checked);

                if (Util.isEmpty(form))
                {
                    return;
                }

                object[] result = sts001Ctrl.updateDataStsSerialPort(form);

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

        public void connectSerialPort()
        {
            try
            {
                if (chkStatusConnectScale.Checked)
                {
                    if (Util.isNotEmpty(cboPorts.Text) &&
                        Util.isNotEmpty(cboBaudRate.Text) &&
                        Util.isNotEmpty(cboDataBits.Text) &&
                        Util.isNotEmpty(cboStopBits.Text) &&
                        Util.isNotEmpty(cboParity.Text) &&
                        Util.isNotEmpty(cboHandShaking.Text))
                    {
                        comPort.PortName = Convert.ToString(cboPorts.Text);
                        comPort.BaudRate = Convert.ToInt32(cboBaudRate.Text);
                        comPort.DataBits = Convert.ToInt16(cboDataBits.Text);
                        comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
                        comPort.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text);
                        comPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cboHandShaking.Text);
                        comPort.Open();
                    }
                }
                else if (!chkStatusConnectScale.Checked)
                {
                    comPort.Close();
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updateDataStsSerialPort();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            queryDataStsSerialPort();
        }

        private void chkStatusConnectScale_CheckedChanged(object sender, EventArgs e)
        {
            connectSerialPort();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            comPort.Close();
            MenuMain menuMain = new MenuMain();
            this.Hide();
            menuMain.Show();
        }

        private void cboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort.Close();
            connectSerialPort();
        }

        private void cboBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort.Close();
            connectSerialPort();
        }

        private void cboDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort.Close();
            connectSerialPort();
        }

        private void cboStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort.Close();
            connectSerialPort();
        }

        private void cboParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort.Close();
            connectSerialPort();
        }

        private void cboHandShaking_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPort.Close();
            connectSerialPort();
        }
    }
}
