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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFetchMessage = new System.Windows.Forms.Button();
            this.btnClearMessageList = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
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
            this.txtSendMessage.Size = new System.Drawing.Size(201, 112);
            this.txtSendMessage.TabIndex = 5;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(127, 238);
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
            this.txtPhoneNum.Size = new System.Drawing.Size(201, 20);
            this.txtPhoneNum.TabIndex = 3;
            // 
            // timerGsmMessagePoll
            // 
            this.timerGsmMessagePoll.Interval = 15000;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Messages";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(127, 281);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(114, 23);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(261, 281);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(114, 23);
            this.btnDisconnect.TabIndex = 11;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnStartReadInterval
            // 
            this.btnStartReadInterval.Location = new System.Drawing.Point(607, 238);
            this.btnStartReadInterval.Name = "btnStartReadInterval";
            this.btnStartReadInterval.Size = new System.Drawing.Size(140, 23);
            this.btnStartReadInterval.TabIndex = 12;
            this.btnStartReadInterval.Text = "Start Reading Interval";
            this.btnStartReadInterval.UseVisualStyleBackColor = true;
            this.btnStartReadInterval.Click += new System.EventHandler(this.btnStartReadIntervalMessage_Click);
            // 
            // btnDeleteMessages
            // 
            this.btnDeleteMessages.Location = new System.Drawing.Point(774, 238);
            this.btnDeleteMessages.Name = "btnDeleteMessages";
            this.btnDeleteMessages.Size = new System.Drawing.Size(140, 23);
            this.btnDeleteMessages.TabIndex = 13;
            this.btnDeleteMessages.Text = "Delete messages";
            this.btnDeleteMessages.UseVisualStyleBackColor = true;
            this.btnDeleteMessages.Click += new System.EventHandler(this.btnDeleteMessages_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(428, 91);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(486, 121);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Index";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Sender";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Message";
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
            // btnClearMessageList
            // 
            this.btnClearMessageList.Location = new System.Drawing.Point(428, 281);
            this.btnClearMessageList.Name = "btnClearMessageList";
            this.btnClearMessageList.Size = new System.Drawing.Size(140, 23);
            this.btnClearMessageList.TabIndex = 16;
            this.btnClearMessageList.Text = "Clear Message List";
            this.btnClearMessageList.UseVisualStyleBackColor = true;
            this.btnClearMessageList.Click += new System.EventHandler(this.btnClearMessageList_Click);
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
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 362);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnClearMessageList);
            this.Controls.Add(this.btnFetchMessage);
            this.Controls.Add(this.listView1);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnFetchMessage;
        private System.Windows.Forms.Button btnClearMessageList;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lblStatus;
    }
}

