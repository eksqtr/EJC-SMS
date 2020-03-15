namespace SMS_Sender
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gridViewInbox = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblDateToday = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.checkSendMultiple = new System.Windows.Forms.CheckBox();
            this.bttnClear = new System.Windows.Forms.Button();
            this.bttnAddPhoneNumber = new System.Windows.Forms.Button();
            this.txtAddingNumber = new System.Windows.Forms.TextBox();
            this.lboxPhoneNumbers = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bttnSend = new System.Windows.Forms.Button();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.InboxHeartbeat = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInbox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(4, 141);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(815, 371);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(807, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inbox";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gridViewInbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 336);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inbox";
            // 
            // gridViewInbox
            // 
            this.gridViewInbox.AllowUserToAddRows = false;
            this.gridViewInbox.AllowUserToDeleteRows = false;
            this.gridViewInbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewInbox.Location = new System.Drawing.Point(18, 45);
            this.gridViewInbox.MultiSelect = false;
            this.gridViewInbox.Name = "gridViewInbox";
            this.gridViewInbox.ReadOnly = true;
            this.gridViewInbox.Size = new System.Drawing.Size(759, 258);
            this.gridViewInbox.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblDateToday);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtMessage);
            this.tabPage2.Controls.Add(this.checkSendMultiple);
            this.tabPage2.Controls.Add(this.bttnClear);
            this.tabPage2.Controls.Add(this.bttnAddPhoneNumber);
            this.tabPage2.Controls.Add(this.txtAddingNumber);
            this.tabPage2.Controls.Add(this.lboxPhoneNumbers);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.bttnSend);
            this.tabPage2.Controls.Add(this.txtPhoneNumber);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(807, 342);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SMS Dashboard";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblDateToday
            // 
            this.lblDateToday.Location = new System.Drawing.Point(638, 6);
            this.lblDateToday.Name = "lblDateToday";
            this.lblDateToday.Size = new System.Drawing.Size(163, 26);
            this.lblDateToday.TabIndex = 9;
            this.lblDateToday.Text = "March 15, 2020";
            this.lblDateToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Message:";
            // 
            // txtMessage
            // 
            this.txtMessage.DetectUrls = false;
            this.txtMessage.Location = new System.Drawing.Point(200, 156);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(401, 158);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.Text = "";
            // 
            // checkSendMultiple
            // 
            this.checkSendMultiple.AutoSize = true;
            this.checkSendMultiple.Location = new System.Drawing.Point(654, 256);
            this.checkSendMultiple.Name = "checkSendMultiple";
            this.checkSendMultiple.Size = new System.Drawing.Size(154, 20);
            this.checkSendMultiple.TabIndex = 6;
            this.checkSendMultiple.Text = "Send Multiple Msg";
            this.checkSendMultiple.UseVisualStyleBackColor = true;
            this.checkSendMultiple.CheckedChanged += new System.EventHandler(this.checkSendMultiple_CheckedChanged);
            // 
            // bttnClear
            // 
            this.bttnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnClear.Image = global::SMS_Sender.Properties.Resources.icons8_delete_30px;
            this.bttnClear.Location = new System.Drawing.Point(6, 297);
            this.bttnClear.Name = "bttnClear";
            this.bttnClear.Size = new System.Drawing.Size(169, 42);
            this.bttnClear.TabIndex = 5;
            this.bttnClear.Text = "Clear Numbers";
            this.bttnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttnClear.UseVisualStyleBackColor = true;
            this.bttnClear.Click += new System.EventHandler(this.bttnClear_Click);
            // 
            // bttnAddPhoneNumber
            // 
            this.bttnAddPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnAddPhoneNumber.Image = global::SMS_Sender.Properties.Resources.add_30px;
            this.bttnAddPhoneNumber.Location = new System.Drawing.Point(6, 252);
            this.bttnAddPhoneNumber.Name = "bttnAddPhoneNumber";
            this.bttnAddPhoneNumber.Size = new System.Drawing.Size(169, 42);
            this.bttnAddPhoneNumber.TabIndex = 5;
            this.bttnAddPhoneNumber.Text = "Add Phone Number";
            this.bttnAddPhoneNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttnAddPhoneNumber.UseVisualStyleBackColor = true;
            this.bttnAddPhoneNumber.Click += new System.EventHandler(this.bttnAddPhoneNumber_Click);
            // 
            // txtAddingNumber
            // 
            this.txtAddingNumber.Location = new System.Drawing.Point(5, 224);
            this.txtAddingNumber.MaxLength = 11;
            this.txtAddingNumber.Name = "txtAddingNumber";
            this.txtAddingNumber.Size = new System.Drawing.Size(169, 22);
            this.txtAddingNumber.TabIndex = 4;
            this.txtAddingNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddingNumber_KeyPress);
            // 
            // lboxPhoneNumbers
            // 
            this.lboxPhoneNumbers.FormattingEnabled = true;
            this.lboxPhoneNumbers.ItemHeight = 16;
            this.lboxPhoneNumbers.Location = new System.Drawing.Point(3, 6);
            this.lboxPhoneNumbers.Name = "lboxPhoneNumbers";
            this.lboxPhoneNumbers.Size = new System.Drawing.Size(171, 212);
            this.lboxPhoneNumbers.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Phone Number:";
            // 
            // bttnSend
            // 
            this.bttnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnSend.Image = global::SMS_Sender.Properties.Resources.send_30px;
            this.bttnSend.Location = new System.Drawing.Point(654, 282);
            this.bttnSend.Name = "bttnSend";
            this.bttnSend.Size = new System.Drawing.Size(150, 54);
            this.bttnSend.TabIndex = 1;
            this.bttnSend.Text = "Send Message";
            this.bttnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bttnSend.UseVisualStyleBackColor = true;
            this.bttnSend.Click += new System.EventHandler(this.bttnSend_Click);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(200, 111);
            this.txtPhoneNumber.MaxLength = 11;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(169, 22);
            this.txtPhoneNumber.TabIndex = 0;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(316, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(283, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Short Message Service";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(316, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "EJC";
            // 
            // InboxHeartbeat
            // 
            this.InboxHeartbeat.Enabled = true;
            this.InboxHeartbeat.Interval = 10000;
            this.InboxHeartbeat.Tick += new System.EventHandler(this.InboxHeartbeat_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SMS_Sender.Properties.Resources.EJC_sms_Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(186, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 107);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EJC SMS - Dashboard";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInbox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridViewInbox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bttnSend;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.ListBox lboxPhoneNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bttnAddPhoneNumber;
        private System.Windows.Forms.TextBox txtAddingNumber;
        private System.Windows.Forms.CheckBox checkSendMultiple;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer InboxHeartbeat;
        private System.Windows.Forms.Button bttnClear;
        private System.Windows.Forms.Label lblDateToday;
    }
}