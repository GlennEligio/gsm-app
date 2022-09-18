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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.timerGsmMessagePoll = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtSendMessage = new MetroFramework.Controls.MetroTextBox();
            this.txtPhoneNum = new MetroFramework.Controls.MetroTextBox();
            this.btnConnect = new MetroFramework.Controls.MetroButton();
            this.btnDisconnect = new MetroFramework.Controls.MetroButton();
            this.btnSendMessage = new MetroFramework.Controls.MetroButton();
            this.btnStartReadInterval = new MetroFramework.Controls.MetroButton();
            this.btnReadMessage = new MetroFramework.Controls.MetroButton();
            this.btnDeleteMessages = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.dateTimePicker1 = new MetroFramework.Controls.MetroDateTime();
            this.cboProfName = new MetroFramework.Controls.MetroComboBox();
            this.btnSearchMessage = new MetroFramework.Controls.MetroButton();
            this.btnFetchCodes = new MetroFramework.Controls.MetroButton();
            this.btnStartPollTodayCodes = new MetroFramework.Controls.MetroButton();
            this.btnClearMessages = new MetroFramework.Controls.MetroButton();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phone number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Message";
            // 
            // timerGsmMessagePoll
            // 
            this.timerGsmMessagePoll.Interval = 15000;
            this.timerGsmMessagePoll.Tick += new System.EventHandler(this.timerGsmMessagePoll_Tick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(43, 19);
            this.metroLabel1.TabIndex = 28;
            this.metroLabel1.Text = "Status";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(422, 69);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 29;
            this.metroLabel2.Text = "Messages";
            // 
            // txtSendMessage
            // 
            // 
            // 
            // 
            this.txtSendMessage.CustomButton.Image = null;
            this.txtSendMessage.CustomButton.Location = new System.Drawing.Point(128, 1);
            this.txtSendMessage.CustomButton.Name = "";
            this.txtSendMessage.CustomButton.Size = new System.Drawing.Size(119, 119);
            this.txtSendMessage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSendMessage.CustomButton.TabIndex = 1;
            this.txtSendMessage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSendMessage.CustomButton.UseSelectable = true;
            this.txtSendMessage.CustomButton.Visible = false;
            this.txtSendMessage.Lines = new string[] {
        "Type the message here..."};
            this.txtSendMessage.Location = new System.Drawing.Point(125, 141);
            this.txtSendMessage.MaxLength = 32767;
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.PasswordChar = '\0';
            this.txtSendMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSendMessage.SelectedText = "";
            this.txtSendMessage.SelectionLength = 0;
            this.txtSendMessage.SelectionStart = 0;
            this.txtSendMessage.ShortcutsEnabled = true;
            this.txtSendMessage.Size = new System.Drawing.Size(248, 121);
            this.txtSendMessage.TabIndex = 30;
            this.txtSendMessage.Text = "Type the message here...";
            this.txtSendMessage.UseSelectable = true;
            this.txtSendMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSendMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPhoneNum
            // 
            // 
            // 
            // 
            this.txtPhoneNum.CustomButton.Image = null;
            this.txtPhoneNum.CustomButton.Location = new System.Drawing.Point(221, 1);
            this.txtPhoneNum.CustomButton.Name = "";
            this.txtPhoneNum.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPhoneNum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPhoneNum.CustomButton.TabIndex = 1;
            this.txtPhoneNum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPhoneNum.CustomButton.UseSelectable = true;
            this.txtPhoneNum.CustomButton.Visible = false;
            this.txtPhoneNum.Lines = new string[0];
            this.txtPhoneNum.Location = new System.Drawing.Point(126, 104);
            this.txtPhoneNum.MaxLength = 32767;
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.PasswordChar = '\0';
            this.txtPhoneNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPhoneNum.SelectedText = "";
            this.txtPhoneNum.SelectionLength = 0;
            this.txtPhoneNum.SelectionStart = 0;
            this.txtPhoneNum.ShortcutsEnabled = true;
            this.txtPhoneNum.Size = new System.Drawing.Size(243, 23);
            this.txtPhoneNum.TabIndex = 31;
            this.txtPhoneNum.UseSelectable = true;
            this.txtPhoneNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPhoneNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(121, 278);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(114, 23);
            this.btnConnect.TabIndex = 32;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseSelectable = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(255, 278);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(114, 23);
            this.btnDisconnect.TabIndex = 33;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseSelectable = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(121, 307);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(114, 23);
            this.btnSendMessage.TabIndex = 34;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseSelectable = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnStartReadInterval
            // 
            this.btnStartReadInterval.Location = new System.Drawing.Point(255, 307);
            this.btnStartReadInterval.Name = "btnStartReadInterval";
            this.btnStartReadInterval.Size = new System.Drawing.Size(114, 23);
            this.btnStartReadInterval.TabIndex = 35;
            this.btnStartReadInterval.Text = "Start GSM Reading";
            this.btnStartReadInterval.UseSelectable = true;
            this.btnStartReadInterval.Click += new System.EventHandler(this.btnStartReadIntervalMessage_Click);
            // 
            // btnReadMessage
            // 
            this.btnReadMessage.Location = new System.Drawing.Point(255, 336);
            this.btnReadMessage.Name = "btnReadMessage";
            this.btnReadMessage.Size = new System.Drawing.Size(114, 23);
            this.btnReadMessage.TabIndex = 37;
            this.btnReadMessage.Text = "Read messages";
            this.btnReadMessage.UseSelectable = true;
            this.btnReadMessage.Click += new System.EventHandler(this.btnReadMessage_Click);
            // 
            // btnDeleteMessages
            // 
            this.btnDeleteMessages.Location = new System.Drawing.Point(121, 336);
            this.btnDeleteMessages.Name = "btnDeleteMessages";
            this.btnDeleteMessages.Size = new System.Drawing.Size(114, 23);
            this.btnDeleteMessages.TabIndex = 36;
            this.btnDeleteMessages.Text = "Delete messages";
            this.btnDeleteMessages.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(422, 103);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(36, 19);
            this.metroLabel3.TabIndex = 38;
            this.metroLabel3.Text = "Date";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(633, 104);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(50, 19);
            this.metroLabel4.TabIndex = 39;
            this.metroLabel4.Text = "Sender";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(477, 97);
            this.dateTimePicker1.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 29);
            this.dateTimePicker1.TabIndex = 40;
            // 
            // cboProfName
            // 
            this.cboProfName.FormattingEnabled = true;
            this.cboProfName.ItemHeight = 23;
            this.cboProfName.Location = new System.Drawing.Point(689, 98);
            this.cboProfName.Name = "cboProfName";
            this.cboProfName.Size = new System.Drawing.Size(121, 29);
            this.cboProfName.TabIndex = 41;
            this.cboProfName.UseSelectable = true;
            // 
            // btnSearchMessage
            // 
            this.btnSearchMessage.Location = new System.Drawing.Point(833, 102);
            this.btnSearchMessage.Name = "btnSearchMessage";
            this.btnSearchMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSearchMessage.TabIndex = 42;
            this.btnSearchMessage.Text = "Search";
            this.btnSearchMessage.UseSelectable = true;
            this.btnSearchMessage.Click += new System.EventHandler(this.btnSearchMessage_Click);
            // 
            // btnFetchCodes
            // 
            this.btnFetchCodes.Location = new System.Drawing.Point(422, 278);
            this.btnFetchCodes.Name = "btnFetchCodes";
            this.btnFetchCodes.Size = new System.Drawing.Size(114, 23);
            this.btnFetchCodes.TabIndex = 43;
            this.btnFetchCodes.Text = "Fetch Codes";
            this.btnFetchCodes.UseSelectable = true;
            this.btnFetchCodes.Click += new System.EventHandler(this.btnFetchCodes_Click);
            // 
            // btnStartPollTodayCodes
            // 
            this.btnStartPollTodayCodes.Location = new System.Drawing.Point(542, 277);
            this.btnStartPollTodayCodes.Name = "btnStartPollTodayCodes";
            this.btnStartPollTodayCodes.Size = new System.Drawing.Size(114, 23);
            this.btnStartPollTodayCodes.TabIndex = 44;
            this.btnStartPollTodayCodes.Text = "Poll Today\'s Codes";
            this.btnStartPollTodayCodes.UseSelectable = true;
            this.btnStartPollTodayCodes.Click += new System.EventHandler(this.btnStartPollTodayCodes_Click);
            // 
            // btnClearMessages
            // 
            this.btnClearMessages.Location = new System.Drawing.Point(662, 278);
            this.btnClearMessages.Name = "btnClearMessages";
            this.btnClearMessages.Size = new System.Drawing.Size(114, 23);
            this.btnClearMessages.TabIndex = 45;
            this.btnClearMessages.Text = "Clear Messages";
            this.btnClearMessages.UseSelectable = true;
            this.btnClearMessages.Click += new System.EventHandler(this.btnClearMessages_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(126, 69);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(28, 19);
            this.lblStatus.TabIndex = 46;
            this.lblStatus.Text = "Off";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(422, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(486, 121);
            this.dataGridView1.TabIndex = 48;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 440);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClearMessages);
            this.Controls.Add(this.btnStartPollTodayCodes);
            this.Controls.Add(this.btnFetchCodes);
            this.Controls.Add(this.btnSearchMessage);
            this.Controls.Add(this.cboProfName);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.btnReadMessage);
            this.Controls.Add(this.btnDeleteMessages);
            this.Controls.Add(this.btnStartReadInterval);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPhoneNum);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "GSM app";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label3;
        private System.Windows.Forms.Timer timerGsmMessagePoll;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtSendMessage;
        private MetroFramework.Controls.MetroTextBox txtPhoneNum;
        private MetroFramework.Controls.MetroButton btnConnect;
        private MetroFramework.Controls.MetroButton btnDisconnect;
        private MetroFramework.Controls.MetroButton btnSendMessage;
        private MetroFramework.Controls.MetroButton btnStartReadInterval;
        private MetroFramework.Controls.MetroButton btnReadMessage;
        private MetroFramework.Controls.MetroButton btnDeleteMessages;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroDateTime dateTimePicker1;
        private MetroFramework.Controls.MetroComboBox cboProfName;
        private MetroFramework.Controls.MetroButton btnSearchMessage;
        private MetroFramework.Controls.MetroButton btnFetchCodes;
        private MetroFramework.Controls.MetroButton btnStartPollTodayCodes;
        private MetroFramework.Controls.MetroButton btnClearMessages;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

