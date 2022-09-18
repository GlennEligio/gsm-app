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
using GSM.Repository;

namespace GSM
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private GSMsms gsmSms;
        //private MessageDbUtil messageDbUtil;
        private MessageRepository repository;
        private ProfessorRepository profRepo;

        public Form1()
        {
            repository = MessageRepository.getInstance();
            profRepo = ProfessorRepository.getInstance();
            gsmSms = GSMsms.getInstance(repository);
            InitializeComponent();
            
            List<Professor> professors = profRepo.getProfessors();
            cboProfName.DataSource = professors;
            cboProfName.ValueMember = "Contact_Number";
            cboProfName.DisplayMember = "Name";
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
            refreshMessageDataGridView();
        }

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

        private void btnFetchCodes_Click(object sender, EventArgs e)
        {
            refreshMessageDataGridView();
        }

        private void btnStartPollTodayCodes_Click(object sender, EventArgs e)
        {
            if(timerGsmMessagePoll != null && timerGsmMessagePoll.Enabled == false)
            {
                timerGsmMessagePoll.Start();
            }
        }
        private void btnSearchMessage_Click(object sender, EventArgs e)
        {
            timerGsmMessagePoll.Stop();
            DateTime selectedDt = dateTimePicker1.Value.Date;
            string profNum = cboProfName.SelectedValue.ToString();

            List<ADO.NETModels.Message> messages = repository.getMessagesByDateAndSender(selectedDt, profNum);
            populateMessageDataGridView(messages);
        }

        private void btnClearMessages_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void btnReadMessage_Click(object sender, EventArgs e)
        {
            if(gsmSms.isConnected)
            {
                gsmSms.Stop_Read_Interval();
                gsmSms.Read();
                gsmSms.Start_Read_Interval();
            }
        }

        private void refreshMessageDataGridView()
        {
            BindingSource bindingSource = new BindingSource();
            List<ADO.NETModels.Message> messages = repository.getMessages();
            var query = from t in messages
                        select new { t.Sender, t.Code, t.DateReceived };
            bindingSource.DataSource = query.ToList();
            dataGridView1.DataSource = bindingSource;
            dataGridView1.Refresh();
        }

        private void populateMessageDataGridView(List<ADO.NETModels.Message> messages) 
        {
            BindingSource bi = new BindingSource();
            var query = from t in messages
                        select new { t.Sender, t.Code, t.DateReceived };
            bi.DataSource = query.ToList();
            dataGridView1.DataSource = bi;
            dataGridView1.Refresh();
        }
    }
}
