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
using HomeScale.src.model.entities;
using HomeScale.src.controller;
using HomeScale.src.model.form;
using HomeScale.src.model.form.combo;
using HomeScale.src.util;
using log4net;

namespace HomeScale.view.scale
{
    public partial class STS001 : Form
    {
        SerialPort comPort = new SerialPort();

        internal delegate void SerialDataReceivedEventHandlerDelegate(object sender, SerialDataReceivedEventArgs e);
        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        private SerialPinChangedEventHandler serialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);
        string inputData = String.Empty;
        public STS001()
        {
            InitializeComponent();
            getSerialPorts();
            loadCombo();
            queryDataStsSerialPort();
            serialPinChangedEventHandler1 = new SerialPinChangedEventHandler(pinChanged);
            comPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived_1);
        }
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        STS_SERIAL_PORT formStsSerialPort = new STS_SERIAL_PORT();

        public void getSerialPorts()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string comPortName = null;
            try
            {
                //Com Ports
            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                index += 1;
                cboPorts.Items.Add(ArrayComPortsNames[index]);


            } while (!((ArrayComPortsNames[index] == comPortName) || (index == ArrayComPortsNames.GetUpperBound(0))));
            Array.Sort(ArrayComPortsNames);

            if (index == ArrayComPortsNames.GetUpperBound(0))
            {
                comPortName = ArrayComPortsNames[0];
            }
            //get first item print in text
            cboPorts.Text = ArrayComPortsNames[0];
            //Baud Rate
            //cboBaudRate.Items.Add(300);
            //cboBaudRate.Items.Add(600);
            //cboBaudRate.Items.Add(1200);
            //cboBaudRate.Items.Add(2400);
            //cboBaudRate.Items.Add(9600);
            //cboBaudRate.Items.Add(14400);
            //cboBaudRate.Items.Add(19200);
            //cboBaudRate.Items.Add(38400);
            //cboBaudRate.Items.Add(57600);
            //cboBaudRate.Items.Add(115200);
            //cboBaudRate.Items.ToString();
            ////get first item print in text
            //cboBaudRate.Text = cboBaudRate.Items[0].ToString();
            ////Data Bits
            //cboDataBits.Items.Add(7);
            //cboDataBits.Items.Add(8);
            ////get the first item print it in the text 
            //cboDataBits.Text = cboDataBits.Items[0].ToString();

            ////Stop Bits
            //cboStopBits.Items.Add("One");
            //cboStopBits.Items.Add("OnePointFive");
            //cboStopBits.Items.Add("Two");
            ////get the first item print in the text
            //cboStopBits.Text = cboStopBits.Items[0].ToString();
            ////Parity 
            //cboParity.Items.Add("None");
            //cboParity.Items.Add("Even");
            //cboParity.Items.Add("Mark");
            //cboParity.Items.Add("Odd");
            //cboParity.Items.Add("Space");
            ////get the first item print in the text
            //cboParity.Text = cboParity.Items[0].ToString();
            ////Handshake
            //cboHandShaking.Items.Add("None");
            //cboHandShaking.Items.Add("XOnXOff");
            //cboHandShaking.Items.Add("RequestToSend");
            //cboHandShaking.Items.Add("RequestToSendXOnXOff");
            ////get the first item print it in the text 
            //cboHandShaking.Text = cboHandShaking.Items[0].ToString();

            //if (comPort.IsOpen)
            //{
            //    comPort.PortName = Convert.ToString(cboPorts.Text);
            //    comPort.BaudRate = Convert.ToInt32(cboBaudRate.Text);
            //    comPort.DataBits = Convert.ToInt16(cboDataBits.Text);
            //    comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
            //    comPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cboHandShaking.Text);
            //    comPort.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text);
            //    comPort.Open();
            //}

            }
            catch (Exception ex)
            {
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
            this.richTextBox1.Text = text;
        }

        internal void pinChanged(object sender, SerialPinChangedEventArgs e)
        {
            SerialPinChange SerialPinChange1 = 0;
            bool signalState = false;

            SerialPinChange1 = e.EventType;
            lblCTSStatus.BackColor = Color.Green;
            lblDSRStatus.BackColor = Color.Green;
            lblRIStatus.BackColor = Color.Green;
            lblBreakStatus.BackColor = Color.Green;
            switch (SerialPinChange1)
            {
                case SerialPinChange.Break:
                    lblBreakStatus.BackColor = Color.Red;
                    //MessageBox.Show("Break is Set");
                    break;
                case SerialPinChange.CDChanged:
                    signalState = comPort.CtsHolding;
                    //  MessageBox.Show("CD = " + signalState.ToString());
                    break;
                case SerialPinChange.CtsChanged:
                    signalState = comPort.CDHolding;
                    lblCTSStatus.BackColor = Color.Red;
                    //MessageBox.Show("CTS = " + signalState.ToString());
                    break;
                case SerialPinChange.DsrChanged:
                    signalState = comPort.DsrHolding;
                    lblDSRStatus.BackColor = Color.Red;
                    // MessageBox.Show("DSR = " + signalState.ToString());
                    break;
                case SerialPinChange.Ring:
                    lblRIStatus.BackColor = Color.Red;
                    //MessageBox.Show("Ring Detected");
                    break;
            }
        }

        public void loadCombo()
        {
            List<ComboBaudRateForm> lstComboBaudRate = new List<ComboBaudRateForm>();
            List<ComboDataBitsForm> lstComboDataBits = new List<ComboDataBitsForm>();
            List<ComboStopBitsForm> lstComboStopBits = new List<ComboStopBitsForm>();
            List<ComboParityForm> lstComboParity = new List<ComboParityForm>();
            List<ComboHandShakingForm> lstComboHandShaking = new List<ComboHandShakingForm>();

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
                        cboBaudRate.SelectedValue = data.SERIAL_PORT_BAUD_RATE;
                        cboDataBits.SelectedValue = data.SERIAL_PORT_DATA_BITS;
                        cboStopBits.SelectedValue = data.SERIAL_PORT_STOP_BITS;
                        cboParity.SelectedValue = data.SERIAL_PORT_PARITY;
                        cboHandShaking.SelectedValue = data.SERIAL_PORT_HAND_SHAKING;
                        chkStatusConnectScale.Checked = Util.chkboxToBool(data.SERIAL_PORT_STATUS_FLAG);

                        //if (formStsSerialPort.SERIAL_PORT_STATUS_FLAG.Equals(1))
                        //{
                        //    comPort.PortName = formStsSerialPort.SERIAL_PORT_PORT_NO;
                        //    comPort.BaudRate = Convert.ToInt32(formStsSerialPort.SERIAL_PORT_BAUD_RATE);
                        //    comPort.DataBits = Convert.ToInt16(formStsSerialPort.SERIAL_PORT_DATA_BITS);
                        //    comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), formStsSerialPort.SERIAL_PORT_STOP_BITS.ToString());
                        //    comPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), formStsSerialPort.SERIAL_PORT_HAND_SHAKING.ToString());
                        //    comPort.Parity = (Parity)Enum.Parse(typeof(Parity), formStsSerialPort.SERIAL_PORT_PARITY.ToString());
                        //    comPort.Open();
                        //}
                        //else if (formStsSerialPort.SERIAL_PORT_STATUS_FLAG.Equals(0))
                        //{
                        //    comPort.Close();
                        //}
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                comPort.WriteLine("TEST");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            queryDataStsSerialPort();
        }

        private void chkStatusConnectScale_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!comPort.IsOpen)
                {
                    comPort.PortName = Convert.ToString(cboPorts.Text);
                    comPort.BaudRate = Convert.ToInt32(cboBaudRate.Text);
                    comPort.DataBits = Convert.ToInt16(cboDataBits.Text);
                    comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cboStopBits.Text);
                    comPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), cboHandShaking.Text);
                    comPort.Parity = (Parity)Enum.Parse(typeof(Parity), cboParity.Text);
                    comPort.Open();
                }
                else if (comPort.IsOpen)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuMain menuMain = new MenuMain();
            this.Hide();
            menuMain.Show();
        }
    }
}
