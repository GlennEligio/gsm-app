using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool initialPoll = true;

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
            if (gsmPort == null || !isConnected || !gsmPort.IsOpen)
            {
                Console.WriteLine("Connecting");
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
            if(isConnected)
            {
                Console.WriteLine("Reading..");

                gsmPort.WriteLine("AT+CMGF=1" + Environment.NewLine); // Set mode to Text(1) or PDU(0)
                Thread.Sleep(1000); // Give a second to write
                gsmPort.WriteLine("AT+CPMS=\"SM\"" + Environment.NewLine); // Set storage to SIM(SM)
                Thread.Sleep(1000);
                gsmPort.WriteLine("AT+CMGL=\"ALL\"\r" + Environment.NewLine); // What category to read ALL, REC READ, or REC UNREAD
                Thread.Sleep(3000);

                string response = gsmPort.ReadExisting();

                if (response.Contains("\r\nOK\r\n"))
                {
                    Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",""(.*)"",""(.+)""\r\n(.+)\r\n");
                    Match m = r.Match(response);

                    // clear listView
                    listView1.Items.Clear();
                    listView1.Refresh();

                    while (m.Success)
                    {
                        string a = m.Groups[1].Value; // message index in sim (ZERO index)
                        string b = m.Groups[2].Value; // status of message (REC READ or REC UNREAD whether msg is read or)
                        string c = m.Groups[3].Value; // phone number
                        string d = m.Groups[4].Value;
                        string e = m.Groups[5].Value; // date of message received
                        string f = m.Groups[6].Value; // contents of message

                        // populate listItem
                        ListViewItem item = new ListViewItem(new string[] { a, b, c, d, e, f });
                        listView1.Items.Add(item);
                        m = m.NextMatch();

                    }
                    return response;
                }
                else
                {
                    // add more code here to handle error.
                    Console.WriteLine("Error message" + response);
                    return null;
                }
            } else
            {
                MessageBox.Show("You are not connected yet to GSM", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string Delete()
        {
            timerGsmMessagePoll.Stop();
            Console.WriteLine("Deleting...");
            gsmPort.WriteLine("AT+CMGD=1,4" + Environment.NewLine);
            Thread.Sleep(200);

            string response = gsmPort.ReadExisting();

            if (response.EndsWith("\r\nOK\r\n"))
            {
                // clears listItem
                listView1.Items.Clear();
                listView1.Refresh();
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
                if(initialPoll)
                {
                    Thread.Sleep(1000);
                    initialPoll = false;
                    return;
                }
                Read();
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
                timerGsmMessagePoll.Start();
            }
            else
            {
                MessageBox.Show("Connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
            if(!isConnected)
            {
                MessageBox.Show("Disconnected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                timerGsmMessagePoll.Stop();
            } else
            {
                MessageBox.Show("Disconnection failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadMessage_Click(object sender, EventArgs e)
        {
            if(isConnected)
            {
                timerGsmMessagePoll.Stop();
                Read();
                timerGsmMessagePoll.Start();
            }
        }

        private void btnDeleteMessages_Click(object sender, EventArgs e)
        {
            string output = Delete();
            if(output == null)
            {
                MessageBox.Show("Delete failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                MessageBox.Show("Delete successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
