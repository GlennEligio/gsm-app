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
        private static GSMsms gsmSms;
        private bool initialPoll = true;

        public Form1()
        {
            gsmSms = GSMsms.getInstance();
            InitializeComponent();
            PopulateComboBoxWithPorts();
        }

        private void PopulateComboBoxWithPorts()
        {
            foreach (string portname in SerialPort.GetPortNames())
            {
                cboxPorts.Items.Add(portname);
            }
        }


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
            if (gsmSms.isConnected)
            {
                if(gsmSms.gsmMessages != null)
                {
                    if(gsmSms.gsmMessages.Count > 0)
                    {
                        listView1.Items.Clear();
                        listView1.Refresh();
                        for (int i = 0; i < gsmSms.gsmMessages.Count; i++)
                        {
                            ListViewItem item = new ListViewItem(new string[] { i.ToString(), gsmSms.gsmMessages.ElementAt(i).Sender, gsmSms.gsmMessages.ElementAt(i).Content });
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void cboxPorts_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbox = sender as ComboBox;
            if (cbox != null)
            {
                gsmSms.setGsmPortNumber(cbox.Text);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            gsmSms.Connect();
            if (gsmSms.isConnected)
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
            gsmSms.Disconnect();
            if(!gsmSms.isConnected)
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
            if (gsmSms.isConnected)
            {
                gsmSms.Read_Interval();
            }
        }

        private void btnReadMessage_Click1(object sender, EventArgs e)
        {
            if(gsmSms.isConnected)
            {
                timerGsmMessagePoll.Stop();

                // clear listView
                listView1.Items.Clear();
                listView1.Refresh();

                gsmSms.Read();
                if (gsmSms.gsmMessages != null)
                {
                    for(int i = 0; i < gsmSms.gsmMessages.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(new string[] { i.ToString(), gsmSms.gsmMessages.ElementAt(i).Sender, gsmSms.gsmMessages.ElementAt(i).Content });
                        listView1.Items.Add(item);
                    }
                }
                timerGsmMessagePoll.Start();
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

    }
}
