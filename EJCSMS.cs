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

                   Having trouble on making your own Send and Read Messages code for your 
            Project / System using your GSM Modem Device? Say no more. EJC SMS (EJC Short 
            Message Service) is a library that use AT Comamnd will let you to Send 
            and Read Messages at ease in which helps you to minimized your time developing 
            your system with SMS Feature.

            For more Information about AT Commands please refer to this site:
                https://www.developershome.com/sms/

                                                  Developed by: https://github.com/eksqtr
 */
#define DEBUG_PRINT

using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;
using System.Collections.Generic;

namespace SMS_Sender
{
    class EJCSMS
    {
        private SerialPort serialPort = new SerialPort();
        /* EJC SMS Configuration */

        /* System Config*/
        private const int 
            MAX_SMS_CHARACTERS  =           155,        // Message MAX Character is 155 in sending message. Change the value at your own risk.
            THREAD_SLEEP =                  100,        // 1000 miliseconds = 1 second.
            DELAY_SEND =                    1000        // 1000 miliseconds = 1 second - Delay sending the message
            ;

        /* Philippines Mobile Phone Sim Card Prefixes
         * Source: https://www.prefix.ph/prefixes/2019-updated-complete-list-of-philippine-mobile-network-prefixes/
         */
        private readonly string[]
            LISTS_PHILIPPINES_SIM_PREFIXES = {
               // Globe/TM Sim
                "0817", "0973", "0904", "0916", "0935", "0956", "0975", "0979", "0905", "0917", "0936", 
                "0965", "0976", "0994", "0906", "0926", "0937", "0966", "0977", "0995", "0915", "0927", "0945", "0967", "0978","0997",
                // Globe Prepaid Sim
                "09173", "09178", "09256", "09175", "09253", "09257", "09176", "09255", "09258",
                // Smart/TNT Sim
                "0907", "0912", "0946", "0909", "0930", "0948", "0910", "0938", "0950", "0813", "0913", "0919", "0928", "0947", "0970", "0998",
                "0908", "0914", "0920", "0929", "0949", "0981", "0999", "0911", "0918", "0921", "0939", "0961", "0989",
                //Sun Sim
                "0922", "0931", "0941", "0923", "0932", "0942", "0924", "0933", "0943", "0925", "0934", "0944"
            };

        public static readonly string 
            SMS_DIRECTORY = string.Format("{0}\\EJC_SMS", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        
        /* User Config*/
        private bool 
            ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS = false,       // true: Allowing to send long message even exceeds to MAX_SMS_CHARACTERS false: Not allowed.
            ENABLE_EMPTY_SMS_MESSAGE =            false;       // true: Allowing to send empty message to the recipient.

        /*  =================== METHODS ======================= */

        /* Method: EJCSMS (Constructor)
        * Parameter: bool::allow_long_msg
        * Description: Enabling/Disabling the long message in sending messages
        * 
        * Parameter: bool::allow_empty_sms
        * Description: Enabling/Disabling sending empty message to the recipient
        */
        public EJCSMS(bool allow_long_msg, bool allow_empty_sms)
        {
            if (!Directory.Exists(SMS_DIRECTORY)) Directory.CreateDirectory(SMS_DIRECTORY);
            ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS = allow_long_msg;
            ENABLE_EMPTY_SMS_MESSAGE = allow_empty_sms;
        }

        /* Method: DebugPrint
         * Parameter: string::print
         * Description: A message that the system print 
         * 
         * Parameter: bool::error
         * Description: Whether it is an error or debug 
         */
        private void DebugPrint(string print, bool error = false)
        {
            string smserialPortath = string.Format("{0}\\{1}", SMS_DIRECTORY, (error) ? ("error.txt") : ("debug.txt"));
            string printEx = string.Format("Date Occured: {0}\n{1}: {2}", DateTime.Now, (error) ? ("Error") : ("Debug"), print);

            if(!File.Exists(smserialPortath)) File.Create(smserialPortath).Dispose();
            using (var textFile = File.AppendText(smserialPortath))
            {
                textFile.WriteLine(printEx);
                textFile.WriteLine("-----------------------------------------------------------------------------------------------");
            }
        }

        /* Method: createMessage
         * Parameter: string::recipient_number
         * Description: Recipient number is the one receiving message
         * 
         * Parameter: string::recipient_message
         * Description: A message that you wanted to say to the recipient number
         */
        private void createMessage(string recipient_number, string recipient_message)
        {
            try
            {
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    serialPort.WriteLine("AT" + Environment.NewLine);
                    Thread.Sleep(THREAD_SLEEP);
                    serialPort.WriteLine("AT+CMGF=1" + Environment.NewLine);
                    Thread.Sleep(THREAD_SLEEP);
                    serialPort.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                    Thread.Sleep(THREAD_SLEEP);
                    serialPort.WriteLine("AT+CMGS=\"" + recipient_number + "\"\r" + Environment.NewLine);
                    Thread.Sleep(THREAD_SLEEP);

                    serialPort.WriteLine(recipient_message);
                    Thread.Sleep(DELAY_SEND);
                    serialPort.Write(new byte[] { 26 }, 0, 1);

                    #if (DEBUG_PRINT)
                        DebugPrint(serialPort.ReadExisting());
                    #endif

                    serialPort.Close();
                }
            }
            catch (Exception ex) { DebugPrint(ex.Message, true); }
        }

        /* Method: ReadAllMessages
        * Description: This returns all messages as DataTable
        */
        public DataTable ReadAllMessages()
        {
            DataTable inboxTable = new DataTable();
            inboxTable.Columns.Add("Recipient", typeof(string));
            inboxTable.Columns.Add("Date & Time", typeof(DateTime));
            inboxTable.Columns.Add("Message", typeof(string));

            try
            {
                serialPort.Open();
                serialPort.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(THREAD_SLEEP);
                serialPort.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(THREAD_SLEEP);
                serialPort.WriteLine("AT+CMGL=\"ALL\"\r" + Environment.NewLine);
                Thread.Sleep(THREAD_SLEEP);
                serialPort.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(THREAD_SLEEP);

                // Regular Expression
                var read = Regex.Match(serialPort.ReadExisting(), @"\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n");

                // If success match then loop
                while (read.Success)
                {
                    DataRow row = inboxTable.NewRow();
                    row[0] = read.Groups[3].Value;

                    // Fixing the Date Format 
                    string[] splitStr = read.Groups[5].Value.Substring(0, 8).Split('/');
                    string tempDate = string.Format("{0}/{1}/{2} {3}", splitStr[1], splitStr[2], splitStr[0], read.Groups[5].Value.Substring(9, 8));

                    row[1] = Convert.ToDateTime(tempDate); // Convert it to Date and time
                    row[2] = read.Groups[6].Value;
                    inboxTable.Rows.Add(row);
                    read = read.NextMatch();
                }
                serialPort.Close();
                return inboxTable;
            }
            catch (Exception ex) { DebugPrint(ex.Message, true); }
            return inboxTable;

        }



        /* Method: IsValidRecipientNumber
        * Parameter: string::recipient_number
        * Description: This validates if the number of the input recipient number exists.
        */
        public bool IsValidRecipientNumber(string recipient_number)
        {
            if (recipient_number.Length < 11 || recipient_number.Length > 11) return false;
            foreach (var num in LISTS_PHILIPPINES_SIM_PREFIXES)
                if (recipient_number.Substring(0, 4).Contains(num) || recipient_number.Substring(0, 5).Contains(num)) return true;
            return false;
        }

        /* Method: InitSMS
         * Parameter: string::port_name
         * Description: This will set the serial port of the system in which initiate the GSM Modem Device.
         */ 
        public void InitSMS(string port_name)
        {
            serialPort.PortName = port_name;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.Handshake = Handshake.XOnXOff;
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;
            serialPort.NewLine = Environment.NewLine;
        }

        /* Method: SendSMS
         * Parameter: string::recipient_number
         * Description: Recipient number is the one receiving message
         * 
         * Parameter: string::recipient_message
         * Description: A message that you wanted to say to the recipient number
         * 
         * Return in boolean
         */
        public bool SendSMS(string recipient_number, string recipient_message)
        {
            string tempStr;
            if(!IsValidRecipientNumber(recipient_number))
            {
                tempStr = string.Format("{0}\n\nWarning: Invalid Phone Number!", recipient_number);
                DebugPrint(tempStr, true);
                return false;
            }
            if(!ENABLE_EMPTY_SMS_MESSAGE && string.IsNullOrEmpty(recipient_message))
            {
                tempStr = string.Format("Recipient({0})\nWarning: ENABLE_EMPTY_SMS_MESSAGE in EJC SMS Config is disabled therefore empty or nulled string cannot be send.", recipient_number);
                DebugPrint(tempStr, true);
                return false;
            }
            if (ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS && recipient_message.Length > MAX_SMS_CHARACTERS)
            {
                int recipient_messageLength = recipient_message.Length;
                int loop = 0;
                double value = (double)recipient_messageLength / MAX_SMS_CHARACTERS;
                double maxcount = value;

                for (int x = 0; x < maxcount; x++) loop++;

                createMessage(recipient_number, recipient_message.Substring(0, MAX_SMS_CHARACTERS));
                int getLastCut = MAX_SMS_CHARACTERS;

                for (int x = 0; x < loop; x++)
                {
                    if (getLastCut > recipient_message.Length) break;
                    recipient_messageLength -= MAX_SMS_CHARACTERS;
                    int getLastCutEx = (recipient_messageLength > MAX_SMS_CHARACTERS) ? (MAX_SMS_CHARACTERS) : (recipient_messageLength);
                    createMessage(recipient_number, recipient_message.Substring(getLastCut, getLastCutEx));
                    getLastCut += MAX_SMS_CHARACTERS;
                }
            }
            else
            {
                if (recipient_message.Length > MAX_SMS_CHARACTERS && !ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS)
                {
                    tempStr = string.Format("Recipient({0}) - {1}\n\nWarning: ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS in EJC SMS Config is disabled there for the max character you wanted to send exceeds!", recipient_number,recipient_message);
                    DebugPrint(tempStr, true);
                    return false;
                }
                createMessage(recipient_number, recipient_message);
            }
            return true;
        }

        /* Method: SendMultipleSMS
         * Parameter: string::number
         * Description: Recipient number is the one receiving message in list
         * 
         * Parameter: string::recipient_message
         * Description: A message that you wanted to say to the recipient number
         * 
         * Return in how many SMS fail to send. if return 0 means all message send successfuly.
         */
        public int SendMultipleSMS(List<string> number, string recipient_message)
        {
            int countFail = 0;
            foreach(string recipient_number in number)
            {
                string tempStr;
                if (!IsValidRecipientNumber(recipient_number))
                {
                    tempStr = string.Format("{0}\n\nWarning: Invalid Phone Number!", recipient_number);
                    DebugPrint(tempStr, true);
                    countFail++;
                }
                if (!ENABLE_EMPTY_SMS_MESSAGE && string.IsNullOrEmpty(recipient_message))
                {
                    tempStr = string.Format("Recipient({0})\nWarning: ENABLE_EMPTY_SMS_MESSAGE in EJC SMS Config is disabled therefore empty or nulled string cannot be send.", recipient_number);
                    DebugPrint(tempStr, true);
                    countFail++;
                }
                if (ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS && recipient_message.Length > MAX_SMS_CHARACTERS)
                {
                    int recipient_messageLength = recipient_message.Length;
                    int loop = 0;
                    double value = (double)recipient_messageLength / MAX_SMS_CHARACTERS;
                    double maxcount = value;

                    for (int x = 0; x < maxcount; x++) loop++;

                    createMessage(recipient_number, recipient_message.Substring(0, MAX_SMS_CHARACTERS));
                    int getLastCut = MAX_SMS_CHARACTERS;

                    for (int x = 0; x < loop; x++)
                    {
                        if (getLastCut > recipient_message.Length) break;
                        recipient_messageLength -= MAX_SMS_CHARACTERS;
                        int getLastCutEx = (recipient_messageLength > MAX_SMS_CHARACTERS) ? (MAX_SMS_CHARACTERS) : (recipient_messageLength);
                        createMessage(recipient_number, recipient_message.Substring(getLastCut, getLastCutEx));
                        getLastCut += MAX_SMS_CHARACTERS;
                    }
                }
                else
                {
                    if (recipient_message.Length > MAX_SMS_CHARACTERS && !ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS)
                    {
                        tempStr = string.Format("Recipient({0}) - {1}\n\nWarning: ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS in EJC SMS Config is disabled there for the max character you wanted to send exceeds!", recipient_number, recipient_message);
                        DebugPrint(tempStr, true);
                        countFail++;
                    }
                    createMessage(recipient_number, recipient_message);
                }
            }
            return countFail;
        }
    }
}
