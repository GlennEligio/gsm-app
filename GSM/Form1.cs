using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSM
{
    public partial class Form1 : Form
    {
        private readonly string AT = "AT" + Environment.NewLine;
        private readonly string SMS_MODE = "AT+CMGF=1" + Environment.NewLine;
        private readonly string GSM_TE_SET = "AT+CSCS=\"GSM\"" + Environment.NewLine;
        private readonly string READ_MESSAGE = "AT+CMGL" + Environment.NewLine;
        private string gsmPortNumber = "";
        private SerialPort gsmPort;
        private bool isConnected = false;

        public Form1()
        {
            InitializeComponent();
            PopulateComboBoxWithPorts();
        }

        private string setPhoneNumberString(string message)
        {
            return "AT+CMGS=\"" + message + "\"" + Environment.NewLine;
        }

        private void PopulateComboBoxWithPorts()
        {
            foreach (string portname in SerialPort.GetPortNames())
            {
                cboxPorts.Items.Add(portname);
            }
        }

        private bool Connect()
        {
            Console.WriteLine("Connecting");
            if (gsmPort == null || !isConnected || gsmPort.IsOpen)
            {
                gsmPort = new SerialPort();
                if (gsmPortNumber == null || gsmPortNumber == "")
                {
                    MessageBox.Show("No port specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    gsmPort.PortName = gsmPortNumber;
                    gsmPort.Open();
                    isConnected = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    isConnected = false;
                }

            }

            return isConnected;
        }

        public void Disconnect()
        {
            if (gsmPort != null || isConnected || gsmPort.IsOpen)
            {
                gsmPort.Close();
                gsmPort.Dispose();
                isConnected = false;
            }
        }

        private void Send(string toAddress, string message)
        {
            Console.WriteLine("Sending..");

            gsmPort.WriteLine(AT);
            Thread.Sleep(100);
            gsmPort.WriteLine("AT+CMGF=1" + Environment.NewLine); // Set mode to Text(1) or PDU(0)
            Thread.Sleep(100);
            gsmPort.WriteLine(GSM_TE_SET);
            Thread.Sleep(100);
            gsmPort.WriteLine("AT+CMGS=\"" + toAddress + "\"" + Environment.NewLine);
            Thread.Sleep(100);
            gsmPort.Write(message);
            gsmPort.Write(new byte[] { 26 }, 0, 1);
            Thread.Sleep(100);

            string response = gsmPort.ReadExisting();

            if (response.EndsWith("\r\nOK\r\n") && response.Contains("+CMGS:")) // IF CMGS IS MISSING IT MEANS THE MESSAGE WAS NOT SENT!
            {
                Console.WriteLine(response);
                // add more code here to manipulate reponse string.
            }
            else
            {
                // add more code here to handle error.
                Console.WriteLine(response);
            }
        }


        private string Read()
        {
            Console.WriteLine("Reading..");

            gsmPort.WriteLine("AT+CMGF=1"); // Set mode to Text(1) or PDU(0)
            Thread.Sleep(1000); // Give a second to write
            gsmPort.WriteLine("AT+CPMS=\"SM\""); // Set storage to SIM(SM)
            Thread.Sleep(1000);
            gsmPort.WriteLine("AT+CMGL=\"ALL\""); // What category to read ALL, REC READ, or REC UNREAD
            Thread.Sleep(1000);
            gsmPort.Write("\r");
            Thread.Sleep(1000);

            string response = gsmPort.ReadExisting();

            if (response.EndsWith("\r\nOK\r\n"))
            {
                Console.WriteLine(response);
                return response;
            }
            else
            {
                // add more code here to handle error.
                Console.WriteLine(response);
                return null;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                string phoneAddress = txtPhoneNum.Text;
                string message = txtSendMessage.Text;
                Send(phoneAddress, message);

            }
        }

        private void timerGsmMessagePoll_Tick(object sender, EventArgs e)
        {
            if (isConnected)
            {
                string receivedMessages = Read();
                if (receivedMessages != null)
                {
                    txtReceivedMessages.AppendText(receivedMessages);
                }
            }
        }

        private void cboxPorts_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbox = sender as ComboBox;
            if (cbox != null)
            {
                gsmPortNumber = cbox.Text;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
            if (isConnected)
            {
                MessageBox.Show("Connected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void btnReadMessage_Click(object sender, EventArgs e)
        {
            if(isConnected)
            {
                string messages = Read();
                if(messages != null)
                {
                    txtReceivedMessages.AppendText(messages);
                }
            }
        }
    }
}
