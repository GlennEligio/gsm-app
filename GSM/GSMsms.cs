using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSM
{
    class GSMsms
    {
        private readonly string AT = "AT" + Environment.NewLine;
        private readonly string GSM_TE_SET = "AT+CSCS=\"GSM\"" + Environment.NewLine;
        private SerialPort gsmPort;
        public bool isConnected { get; private set; } = false;
        public bool initialPoll { get; set; } = true;
        public string gsmPortNumber { get; set; } = "";
        public List<Message> messages { get; private set; } = new List<Message>();
        private static GSMsms instance = null;
        private GSMsms() { }

        public static GSMsms getInstance()
        {
            if(instance == null)
            {
                instance = new GSMsms();
            }
            return instance;
        }

        public bool Connect()
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

        public bool Send(string toAddress, string message)
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
                return true;
            }
            else
            {
                // add more code here to handle error.
                Console.WriteLine(response);
                return false;
            }
        }


        public List<Message> Read()
        {
            if (isConnected)
            {
                Console.WriteLine("Reading..");

                gsmPort.WriteLine("AT+CMGF=1" + Environment.NewLine); // Set mode to Text(1) or PDU(0)
                Thread.Sleep(1000); // Give a second to write
                gsmPort.WriteLine("AT+CPMS=\"SM\"" + Environment.NewLine); // Set storage to SIM(SM)
                Thread.Sleep(1000);
                gsmPort.WriteLine("AT+CMGL=\"ALL\"\r" + Environment.NewLine); // What category to read ALL, REC READ, or REC UNREAD
                Thread.Sleep(3000);

                string response = gsmPort.ReadExisting();

                // clear listView
                messages.Clear();

                if (response.Contains("\r\nOK\r\n"))
                {
                    Regex r = new Regex(@"\+CMGL: (\d+),""(.+)"",""(.+)"",""(.*)"",""(.+)""\r\n(.+)\r\n");
                    Match m = r.Match(response);

                    while (m.Success)
                    {
                        string a = m.Groups[1].Value; // message index in sim (ZERO index)
                        string b = m.Groups[2].Value; // status of message (REC READ or REC UNREAD whether msg is read or)
                        string c = m.Groups[3].Value; // phone number
                        string d = m.Groups[4].Value;
                        string e = m.Groups[5].Value; // date of message received
                        string f = m.Groups[6].Value; // contents of message

                        // populate listItem
                        messages.Add(new Message(c, f));
                        Console.WriteLine(c + ": " + f);
                        m = m.NextMatch();
                    }
                    return messages;
                }
                else
                {
                    // add more code here to handle error.
                    Console.WriteLine("Error message" + response);
                    return null;
                }
            }
            else
            {
                MessageBox.Show("You are not connected yet to GSM", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public string Delete()
        {
            Console.WriteLine("Deleting...");
            gsmPort.WriteLine("AT+CMGD=1,4" + Environment.NewLine);
            Thread.Sleep(1000);

            string response = gsmPort.ReadExisting();

            if (response.EndsWith("\r\nOK\r\n"))
            {
                // clears listItem
                return response;
            }
            else
            {
                // add more code here to handle error.
                Console.WriteLine(response);
                return null;
            }
        }

    }
}
