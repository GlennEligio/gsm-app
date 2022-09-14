namespace GSM
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.timerGsmMessagePoll = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnStartReadInterval = new System.Windows.Forms.Button();
            this.btnDeleteMessages = new System.Windows.Forms.Button();
            this.btnFetchMessage = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProfName = new System.Windows.Forms.ComboBox();
            this.btnSearchMessage = new System.Windows.Forms.Button();
            this.btnStartMessagePoll = new System.Windows.Forms.Button();
            this.btnClearMessages = new System.Windows.Forms.Button();
            this.btnReadMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phone number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Message";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(127, 100);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(248, 112);
            this.txtSendMessage.TabIndex = 5;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(127, 267);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(114, 23);
            this.btnSendMessage.TabIndex = 6;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(127, 63);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(248, 20);
            this.txtPhoneNum.TabIndex = 3;
            // 
            // timerGsmMessagePoll
            // 
            this.timerGsmMessagePoll.Interval = 15000;
            this.timerGsmMessagePoll.Tick += new System.EventHandler(this.timerGsmMessagePoll_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Messages";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(127, 238);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(114, 23);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(261, 238);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(114, 23);
            this.btnDisconnect.TabIndex = 11;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnStartReadInterval
            // 
            this.btnStartReadInterval.Location = new System.Drawing.Point(261, 267);
            this.btnStartReadInterval.Name = "btnStartReadInterval";
            this.btnStartReadInterval.Size = new System.Drawing.Size(114, 23);
            this.btnStartReadInterval.TabIndex = 12;
            this.btnStartReadInterval.Text = "Start GSM Reading";
            this.btnStartReadInterval.UseVisualStyleBackColor = true;
            this.btnStartReadInterval.Click += new System.EventHandler(this.btnStartReadIntervalMessage_Click);
            // 
            // btnDeleteMessages
            // 
            this.btnDeleteMessages.Location = new System.Drawing.Point(127, 296);
            this.btnDeleteMessages.Name = "btnDeleteMessages";
            this.btnDeleteMessages.Size = new System.Drawing.Size(114, 23);
            this.btnDeleteMessages.TabIndex = 13;
            this.btnDeleteMessages.Text = "Delete messages";
            this.btnDeleteMessages.UseVisualStyleBackColor = true;
            this.btnDeleteMessages.Click += new System.EventHandler(this.btnDeleteMessages_Click);
            // 
            // btnFetchMessage
            // 
            this.btnFetchMessage.Location = new System.Drawing.Point(428, 238);
            this.btnFetchMessage.Name = "btnFetchMessage";
            this.btnFetchMessage.Size = new System.Drawing.Size(140, 23);
            this.btnFetchMessage.TabIndex = 15;
            this.btnFetchMessage.Text = "Fetch messages";
            this.btnFetchMessage.UseVisualStyleBackColor = true;
            this.btnFetchMessage.Click += new System.EventHandler(this.btnFetchMessage_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(29, 34);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(37, 13);
            this.label.TabIndex = 17;
            this.label.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(124, 34);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(21, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Off";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(428, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(486, 130);
            this.dataGridView1.TabIndex = 19;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(464, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(118, 20);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(610, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Sender";
            // 
            // cboProfName
            // 
            this.cboProfName.FormattingEnabled = true;
            this.cboProfName.Location = new System.Drawing.Point(657, 62);
            this.cboProfName.Name = "cboProfName";
            this.cboProfName.Size = new System.Drawing.Size(121, 21);
            this.cboProfName.TabIndex = 23;
            // 
            // btnSearchMessage
            // 
            this.btnSearchMessage.Location = new System.Drawing.Point(803, 62);
            this.btnSearchMessage.Name = "btnSearchMessage";
            this.btnSearchMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSearchMessage.TabIndex = 24;
            this.btnSearchMessage.Text = "Search";
            this.btnSearchMessage.UseVisualStyleBackColor = true;
            this.btnSearchMessage.Click += new System.EventHandler(this.btnSearchMessage_Click);
            // 
            // btnStartMessagePoll
            // 
            this.btnStartMessagePoll.Location = new System.Drawing.Point(587, 237);
            this.btnStartMessagePoll.Name = "btnStartMessagePoll";
            this.btnStartMessagePoll.Size = new System.Drawing.Size(144, 23);
            this.btnStartMessagePoll.TabIndex = 25;
            this.btnStartMessagePoll.Text = "Start Message Poll";
            this.btnStartMessagePoll.UseVisualStyleBackColor = true;
            this.btnStartMessagePoll.Click += new System.EventHandler(this.btnStartMessagePoll_Click);
            // 
            // btnClearMessages
            // 
            this.btnClearMessages.Location = new System.Drawing.Point(746, 237);
            this.btnClearMessages.Name = "btnClearMessages";
            this.btnClearMessages.Size = new System.Drawing.Size(104, 23);
            this.btnClearMessages.TabIndex = 26;
            this.btnClearMessages.Text = "Clear Messages";
            this.btnClearMessages.UseVisualStyleBackColor = true;
            this.btnClearMessages.Click += new System.EventHandler(this.btnClearMessages_Click);
            // 
            // btnReadMessage
            // 
            this.btnReadMessage.Location = new System.Drawing.Point(261, 295);
            this.btnReadMessage.Name = "btnReadMessage";
            this.btnReadMessage.Size = new System.Drawing.Size(114, 23);
            this.btnReadMessage.TabIndex = 27;
            this.btnReadMessage.Text = "Read Message";
            this.btnReadMessage.UseVisualStyleBackColor = true;
            this.btnReadMessage.Click += new System.EventHandler(this.btnReadMessage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 362);
            this.Controls.Add(this.btnReadMessage);
            this.Controls.Add(this.btnClearMessages);
            this.Controls.Add(this.btnStartMessagePoll);
            this.Controls.Add(this.btnSearchMessage);
            this.Controls.Add(this.cboProfName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnFetchMessage);
            this.Controls.Add(this.btnDeleteMessages);
            this.Controls.Add(this.btnStartReadInterval);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.txtPhoneNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "GSM app";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.Timer timerGsmMessagePoll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnStartReadInterval;
        private System.Windows.Forms.Button btnDeleteMessages;
        private System.Windows.Forms.Button btnFetchMessage;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProfName;
        private System.Windows.Forms.Button btnSearchMessage;
        private System.Windows.Forms.Button btnStartMessagePoll;
        private System.Windows.Forms.Button btnClearMessages;
        private System.Windows.Forms.Button btnReadMessage;
    }
}

