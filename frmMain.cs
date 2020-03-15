/*
                $$$$$$$$\   $$$$$\  $$$$$$\         $$$$$$\  $$\      $$\  $$$$$$\  
                $$  _____|  \__$$ |$$  __$$\       $$  __$$\ $$$\    $$$ |$$  __$$\ 
                $$ |           $$ |$$ /  \__|      $$ /  \__|$$$$\  $$$$ |$$ /  \__|
                $$$$$\         $$ |$$ |            \$$$$$$\  $$\$$\$$ $$ |\$$$$$$\  
                $$  __|  $$\   $$ |$$ |             \____$$\ $$ \$$$  $$ | \____$$\ 
                $$ |     $$ |  $$ |$$ |  $$\       $$\   $$ |$$ |\$  /$$ |$$\   $$ |
                $$$$$$$$\\$$$$$$  |\$$$$$$  |      \$$$$$$  |$$ | \_/ $$ |\$$$$$$  |
                \________|\______/  \______/        \______/ \__|     \__| \______/ 

                                EJC Short Message Service v0.5

                    Having troubled making your own Send and Read Messages code for your 
            Project / System using your GSM Modem Device? Say no more. EJC SMS (EJC Short 
            Message Service) is a custom class that use AT Comamnd will let you to Send 
            and Read Messages at ease in which helps you to minimized your time developing 
            your system with SMS Feature.

            For more Information about AT Commands please refer to this site:
                https://www.developershome.com/sms/

                                                  Developed by: https://github.com/eksqtr
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS_Sender
{
    public partial class frmMain : Form
    {
        // Intantiate SMS as EJCSMS object and configure some of the EJCSMS Configurations.
        EJCSMS SMS = new EJCSMS(allow_long_msg: true, allow_empty_sms: false);
        private const string GSM_MODEM_PORT = "COM5";

        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblDateToday.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");
            SMS.InitSMS(GSM_MODEM_PORT); // Initialize the SMS.

            // Easy Peasy showing all the SMS from your Sim Card Inbox in just one line of code.
            gridViewInbox.DataSource = SMS.ReadAllMessages();
        }

        private void bttnSend_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Message Box is empty! Please input something.", "Message Box is Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMessage.Focus();
                return;
            }
            if(checkSendMultiple.CheckState != CheckState.Checked) // Single SMS
            {
                if (!SMS.IsValidRecipientNumber(txtPhoneNumber.Text))
                {
                    MessageBox.Show("Invalid Phone Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNumber.Focus();
                    return;
                }
                if (SMS.SendSMS(txtPhoneNumber.Text, txtMessage.Text))
                {
                    MessageBox.Show("Message has successfully sent!", "Delivering SMS Successfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhoneNumber.Text = "";
                    txtMessage.Text = "";

                }
                else MessageBox.Show("An error occured during sending message. Please check EJC_SMS Directory (debug.txt or error.txt) for more info.", "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // Multiple SMS
            {
                if (lboxPhoneNumbers.Items.Count < 1)
                {
                    MessageBox.Show("You haven't add any number of recipients in the list of phone numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddingNumber.Focus();
                    return;
                }
                if(MessageBox.Show("Are you sure do you want to send it to multiple recipient?", "Sending Multiple Recipient", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> recipients = new List<string>();
                    int countFail = 0; // Store the number of fail to send

                    // Loop all the phone numbers in lboxPhoneNumbers
                    foreach (string phoneNum in lboxPhoneNumbers.Items) recipients.Add(phoneNum);  // Add it on List<recipients>

                    // Now send the message
                    countFail = SMS.SendMultipleSMS(recipients, txtMessage.Text); 
                    string tempStr = string.Format("Number of fail to send ({0}).", countFail); // There are some error occured during sending the message
                    if (countFail == 0) tempStr = string.Format("All message has send successfully!"); // If countFail = 0 then all send with no issue
                    MessageBox.Show(tempStr, "Sending Multiple Recipient", MessageBoxButtons.OK, MessageBoxIcon.Information); // Show the message

                    // Clear this shit
                    checkSendMultiple.Checked = false;
                    lboxPhoneNumbers.Items.Clear();
                    txtMessage.Text = "";
                }
            }
        }

        private void bttnAddPhoneNumber_Click(object sender, EventArgs e)
        {
            if(!SMS.IsValidRecipientNumber(txtAddingNumber.Text))
            {
                MessageBox.Show("Invalid Phone Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddingNumber.Focus();
                return;
            }
            lboxPhoneNumbers.Items.Add(txtAddingNumber.Text);
            txtAddingNumber.Text = "";
            txtAddingNumber.Focus();
        }

        private void txtAddingNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // Allow only Numeric Key.
            if(e.KeyChar == (char)Keys.Return) bttnAddPhoneNumber.PerformClick(); // When Press Enter Perform Add Phone Number Click
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // Allow only Numeric Key.
            if (e.KeyChar == (char)Keys.Return) txtMessage.Focus(); // When Press enter Focus Message Box
        }

        private void bttnClear_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure do you want to clear the list of phone numbers?", "Clearing the list of phone numbers", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lboxPhoneNumbers.Items.Clear();
                checkSendMultiple.Checked = false;
            }
        }

        private void checkSendMultiple_CheckedChanged(object sender, EventArgs e)
        {
            if(checkSendMultiple.CheckState == CheckState.Checked)
            {
                if(lboxPhoneNumbers.Items.Count < 1)
                {
                    MessageBox.Show("You haven't add any number of recipients in the list of phone numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddingNumber.Focus();
                    checkSendMultiple.Checked = false;
                    return;
                }
            }
        }

        private void InboxHeartbeat_Tick(object sender, EventArgs e)
        {
            // Easy Peasy showing all the SMS from your Sim Card Inbox in just one line of code.
            gridViewInbox.DataSource = SMS.ReadAllMessages();
        }
    }
}
