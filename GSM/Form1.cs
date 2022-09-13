using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSM.ADO.NETModels;

namespace GSM
{
    public partial class Form1 : Form
    {
        private GSMsms gsmSms;
        //private MessageDbUtil messageDbUtil;
        private MessageRepository repository;

        public Form1()
        {
            //string cnUrl = ConfigurationManager.ConnectionStrings["ezedb"].ConnectionString;
            //messageDbUtil = MessageDbUtil.getInstance(cnUrl);
            repository = MessageRepository.getInstance();
            gsmSms = GSMsms.getInstance(repository);
            InitializeComponent();
            //PopulateComboBoxWithPorts();
        }

        //private void PopulateComboBoxWithPorts()
        //{
        //    foreach (string portname in SerialPort.GetPortNames())
        //    {
        //        cboxPorts.Items.Add(portname);
        //    }
        //}


        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (gsmSms.isConnected)
            {
                string phoneAddress = txtPhoneNum.Text;
                string message = txtSendMessage.Text;
                gsmSms.Send(phoneAddress, message);

            }
        }

        private void timerGsmMessagePoll_Tick(object sender, EventArgs e)
        {
            List<ADO.NETModels.Message> messages = repository.getMessages();
            listView1.Items.Clear();
            listView1.Refresh();
            if (messages == null) return;
            for (int i = 0; i < messages.Count; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { i.ToString(), messages.ElementAt(i).Sender, messages.ElementAt(i).Code });
                listView1.Items.Add(item);
            }
        }

        //private void cboxPorts_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    ComboBox cbox = sender as ComboBox;
        //    if (cbox != null)
        //    {
        //        gsmSms.setGsmPortNumber(cbox.Text);
        //    }
        //}

        private void btnConnect_Click(object sender, EventArgs e)
        {
            gsmSms.Connect();
            if (gsmSms.isConnected)
            {
                MessageBox.Show("Connected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Connected";
                timerGsmMessagePoll.Start();
            }
            else
            {
                MessageBox.Show("Connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            gsmSms.Disconnect();
            if(!gsmSms.isConnected)
            {
                MessageBox.Show("Disconnected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Disconnected";
                timerGsmMessagePoll.Stop();
            } else
            {
                MessageBox.Show("Disconnection failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStartReadIntervalMessage_Click(object sender, EventArgs e)
        {
            if (gsmSms.isConnected)
            {
                gsmSms.Start_Read_Interval();
            }
        }

        private void btnDeleteMessages_Click(object sender, EventArgs e)
        {
            string output = gsmSms.Delete();
            if(output == null)
            {
                MessageBox.Show("Delete failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                MessageBox.Show("Delete successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFetchMessage_Click(object sender, EventArgs e)
        {
            if (gsmSms.isConnected)
            {
                timerGsmMessagePoll.Stop();
                gsmSms.Stop_Read_Interval();

                listView1.Refresh();

                List<ADO.NETModels.Message> messages = repository.getMessages();
                if (messages != null)
                {
                    for (int i = 0; i < messages.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(new string[] { i.ToString(), messages.ElementAt(i).Sender, messages.ElementAt(i).Code });
                        listView1.Items.Add(item);
                    }
                }
                timerGsmMessagePoll.Start();
                gsmSms.Start_Read_Interval();
            }
        }

        private void btnClearMessageList_Click(object sender, EventArgs e)
        {
            // clear list view
            Console.WriteLine("Clear list view");
            listView1.Items.Clear();
            listView1.Refresh();
        }
    }
}
