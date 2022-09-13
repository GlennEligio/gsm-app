using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using Timer = System.Timers.Timer;
using System.Globalization;
using GSM.ADO.NETModels;
using Message = GSM.ADO.NETModels.Message;

namespace GSM
{
    class GSMsms
    {
        private readonly string AT = "AT" + Environment.NewLine;
        private readonly string GSM_TE_SET = "AT+CSCS=\"GSM\"" + Environment.NewLine;
        private SerialPort gsmPort;
        public bool isConnected { get; private set; } = false;
        public string gsmPortNumber { get; private set; } = "";

        private static GSMsms instance = null;

        private Timer timer = null;

        private bool initialPoll = true;

        //private MessageDbUtil messageDbUtil;
        private MessageRepository messageRepository;

        //private GSMsms(MessageDbUtil util)
        //{
        //    messageDbUtil = util;
        //}

        private GSMsms(MessageRepository repo)
        {
            messageRepository = repo;
        }

        //public static GSMsms getInstance(MessageDbUtil dbUtil)
        //{
        //    if (instance == null)
        //    {
        //        // creating instance of GSMsms
        //        Console.WriteLine("Creating new instance");
        //        instance = new GSMsms(dbUtil);
        //    }
        //    return instance;
        //}

        public static GSMsms getInstance(MessageRepository repo)
        {
            if (instance == null)
            {
                // creating instance of GSMsms
                Console.WriteLine("Creating new instance");
                instance = new GSMsms(repo);
            }
            return instance;
        }

        public bool Connect()
        {
            if (gsmPort == null || !isConnected || !gsmPort.IsOpen)
            {
                Console.WriteLine("Connecting");
                string gsmPortConfig = ConfigurationManager.AppSettings["gsmPortNumber"];
                if (gsmPortConfig == null || gsmPortConfig == "")
                {
                    Console.WriteLine("Connected");
                    MessageBox.Show("No port specified, please edit the config file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                try
                {
                    gsmPort = new SerialPort();
                    gsmPort.PortName = gsmPortConfig;
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
                timer.Stop();
                timer.Dispose();
                gsmPort.Close();
                gsmPort.Dispose();
                isConnected = false;
                initialPoll = true;
            }
        }

        public bool Send(string toAddress, string message)
        {
            Console.WriteLine("Sending..");

            gsmPort.WriteLine("AT+CMGF=1"); // Set mode to Text(1) or PDU(0)
            Thread.Sleep(200);
            gsmPort.WriteLine($"AT+CMGS=\"{toAddress}\"");
            Thread.Sleep(200);
            gsmPort.WriteLine(message + char.ConvertFromUtf32(26));
            Thread.Sleep(1000);

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
            try
            {
                List<Message> messages = new List<Message>();
                if (isConnected)
                {
                    gsmPort.DiscardInBuffer();
                    Console.WriteLine("Reading..");

                    gsmPort.WriteLine("AT+CMGF=1"); // Set mode to Text(1) or PDU(0)
                    Thread.Sleep(1000); // Give a second to write
                    gsmPort.WriteLine("AT+CPMS=\"SM\""); // Set storage to SIM(SM)
                    Thread.Sleep(1000);
                    gsmPort.WriteLine("AT+CMGL=\"REC UNREAD\""); // What category to read ALL, REC READ, or REC UNREAD
                    Thread.Sleep(1000);
                    gsmPort.WriteLine("\r");
                    Thread.Sleep(1000);

                    string response = gsmPort.ReadExisting();

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
                            string e = m.Groups[5].Value; // date of message received in yy/MM/dd,HH:mm:ss+z format
                            string f = m.Groups[6].Value; // contents of message

                            // populate messages property
                            Console.WriteLine(c + ": " + f + ": " + e);
                            DateTime dt = DateTime.ParseExact(e.Split('+')[0], "yy/MM/dd,HH:mm:ss", CultureInfo.InvariantCulture);
                            Console.WriteLine(dt.ToString());
                            Message newMessage = new Message() { Code = f, DateReceived = dt, Sender = c };
                            messageRepository.addMessage(newMessage);
                            Console.WriteLine(m);
                            messages.Add(newMessage);
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
                    Console.WriteLine("You are not connected yet to GSM");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            };

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

        public bool Start_Read_Interval()
        {
            try
            {
                Console.WriteLine("Start reading in intervals...");
                if (timer == null || timer.Enabled == false)
                {
                    timer = new Timer(15000);
                    timer.Elapsed += OnTimedEvent;
                    timer.AutoReset = true;
                }
                if (!timer.Enabled)
                {
                    timer.Start();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading intervals failed" + e.Message);
                return false;
            }
        }

        public bool Stop_Read_Interval()
        {
            try
            {
                if (timer != null && timer.Enabled)
                {
                    Console.WriteLine("Stopping the read interval");
                    timer.Stop();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Stopping the read interval failed");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (initialPoll)
            {
                initialPoll = false;
                return;
            }
            Read();
        }

        //private string smsDateTimeFormatter(string smsDate)
        //{
        //    string[] dateTime = smsDate.Split('+');
        //    string[] dateAndTime = dateTime[0].Split(',');
        //    string[] dates = dateAndTime[0].Split('/');
        //    string newDate = dates[1] + dates[2] + dates[0] + " " + dateAndTime[1];
        //    return newDate;
        //}
    }
}
