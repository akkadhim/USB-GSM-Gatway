using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace SendSMS
{
    public partial class SendSMS : Form
    {
        private SerialPort _serialPort;
        private bool portOpened;
        private List<string> commands = new List<string>();
        private int commandsPointer = 0;
        private bool completed = false;

        public SendSMS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBoxNumber.Text = "+9647830707775";
            //textBoxMessage.Text = "Hi";
            string[] ports = SerialPort.GetPortNames();
            portsCB.DataSource = ports;
            SetPortState(false);
            FillCommands();
        }

        private void FillCommands()
        {
            //commands.Add("AT\r");                   //0 - Once the handshake test is successful, it will back to OK
            //commands.Add("AT+CSQ\r");               //1- Signal quality test, value range is 0-31 , 31 is the best
            //commands.Add("AT+CCID\r");              //2- Read SIM information to confirm whether the SIM is plugged
            //commands.Add("AT+CREG?\r");             //3- Check whether it has registered in the network
            commands.Add("AT+CSCS=\"UCS2\"\r");      //4- displays the codepages supported by the modem (UCS2,HEX) SMS doesn’t effected by this command
            commands.Add("AT+CMGF=1\r");            //6- Configuring TEXT mode, other option could not send mobile terminated message (PDU Mode)
            commands.Add("AT+CSMP=17,167,0,8\r");   //5- specify the correct DCS (Data Coding Scheme) for Unicode messages
            commands.Add("AT+CMGS=");               //7- change with country code and xxxxxxxxxxx with phone number to sms
            //commands.Add("message content");//text content
        }

        private void SetPortState(bool state)
        {
            portOpened = state;
            portToggleBtn.Text = state ? "Disconnect" : "Connect";
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            completed = false;
            buttonSend.Enabled = false;
            SendMessage();
        }

        private void SendMessage()
        {
            if (portOpened)
            {
                if (commandsPointer == (commands.Count - 1))
                {
                    string number = "\"" + textBoxNumber.Text + "\",145\r";
                    _serialPort.Write(commands[commandsPointer] + number);
                }
                else if (commandsPointer == commands.Count)
                {
                    commandsPointer++;
                    completed = true;
                    string message = textBoxMessage.Text;
                    //_serialPort.Write(message + (char)(26));
                    //string msg = Str2Hex("مرحبا");
                    //message = Encoding.BigEndianUnicode.GetString(Encoding.Default.GetBytes(message));
                    //_serialPort.Encoding = Encoding.Unicode;
                    _serialPort.Write(message + "\x1A");
                    //byte[] ba = Encoding.Unicode.GetBytes(message);
                   // _serialPort.Write(new byte[] { 0xFE, 0xA5 },0,2);
                    _serialPort.Write("\x1A");
                    _serialPort.Encoding = Encoding.ASCII;
                    //06450631062D06280627
                }
                else
                {
                    _serialPort.Write(commands[commandsPointer]);
                }
                commandsPointer++;
                Thread.Sleep(1000);
            }
            else
            {
                MessageBox.Show("Port must be open");
                commandsPointer = 0;
                buttonSend.Enabled = true;
            }
        }

        public static string Str2Hex(string strMessage)
        {
            byte[] ba = Encoding.BigEndianUnicode.GetBytes(strMessage);
            string strHex = BitConverter.ToString(ba);
            strHex = strHex.Replace("-", "");
            return strHex;
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String data = _serialPort.ReadExisting();
            if (statusTB.InvokeRequired)
            {
                statusTB.BeginInvoke((MethodInvoker)delegate () { this.statusTB.AppendText(data);});
            }
            else
            {
                statusTB.Text = _serialPort.ReadExisting();
            }

            if (commandsPointer >= (commands.Count + 1) || completed)
            {
                commandsPointer = 0;
                if (buttonSend.InvokeRequired)
                {
                    buttonSend.BeginInvoke((MethodInvoker)delegate () { this.buttonSend.Enabled = true; });
                }
                else
                {
                    buttonSend.Enabled = true;
                }
            }
            else
            {
                SendMessage();
            }
        }

        private void portToggleBtn_Click(object sender, EventArgs e)
        {
            commandsPointer = 0;
            SetPortState(!portOpened);
            if (portOpened)
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                _serialPort = new SerialPort();
                _serialPort.PortName = portsCB.Text;
                //_serialPort.Encoding = Encoding.BigEndianUnicode;
                _serialPort.BaudRate = 115200;
                _serialPort.Parity = System.IO.Ports.Parity.None;
                _serialPort.DataBits = 8;
                _serialPort.StopBits = System.IO.Ports.StopBits.One;
                _serialPort.Handshake = System.IO.Ports.Handshake.None;
                _serialPort.RtsEnable = true;
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                Thread.Sleep(1000);
                _serialPort.Open();
                if (_serialPort.IsOpen)
                {
                    MessageBox.Show("Port opened");
                }
            }
            else
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    if (_serialPort.IsOpen == false)
                    {
                        MessageBox.Show("Port cloased");
                    }
                }
            }
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            if (portOpened)
            {
                if (string.IsNullOrEmpty(directCommandTB.Text))
                {
                    //_serialPort.Write("AT\r");
                    _serialPort.WriteLine("AT+CMGF=1\r");
             
                    //_serialPort.Write("AT+CSCS=?\r");
                    completed = true;
                }
                else
                {
                    byte[] ba = Encoding.Unicode.GetBytes(directCommandTB.Text);
                    //_serialPort.Encoding = Encoding.BigEndianUnicode;
                    //_serialPort.Write(directCommandTB.Text + "\r");
                    //_serialPort.Encoding = Encoding.ASCII;
                    //_serialPort.Write(char.ConvertFromUtf32(26));
                    completed = true;

                    //directCommandTB.Text = Str2Hex("السلام");
                }
            }
        }
    }
}


//AT

//+CME ERROR:58
//AT+CSQ

//+CSQ: 25,99

//OK
//AT+CCID

//+SCID: SIM Card ID: 8996405605084009552F

//OK
//AT+CREG?

//+CREG: 1,1

//OK
//AT+CMGF=1

//OK
//AT+CMGS=+9647738467559

//> Alroia
//+CMGS: 1

//OK
