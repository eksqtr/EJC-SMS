# EJS SMS (Short Message Service)

## Version 0.5 - March 15, 2020
## Programming Language: C# (C-Sharp)
---
### Having trouble on making your own Send and Read Messages code for your Project / System using your GSM Modem Device? Say no more. EJC SMS (EJC Short Message Service) is a library uses AT Comamnd that will let you to Send and Read Messages at ease in which helps you to minimized your time developing your system with SMS Feature.
---
**EJC SMS Features**
- [x] **Easy to use**
- [x] **Code Friendly**
- [x] **Ability to Send Single SMS**
- [x] **Ability to Send Multiple Recipients**
- [x] **Ability to Read Inbox SMS**
- [x] **Smart Validiation of Phone Numbers based on Philippines Sim Card Prefixes**


##**EJC SMS Available Functions:**

- **InitSMS()**
   - > **Parameter:** port_name (string)
   - > Initialize the EJC SMS with your Com Port of GSM Modem Device. To get the port you must check it on **Device Manager> Ports (Com & LPT)**
   
- **IsValidRecipientNumber()**
    - > **Parameter:** recipient_number (string)
    - > **Return:** return as boolean true: means valid false: invalid
    - > Smart Validation if the number is valid based on Sim Card Philippines Prefixes.
    
- **SendSMS()**
    - > **Parameter:** recipient_number (string) | recipient_message (string)
    - > **Return:** return as boolean true: means success false: failed
    - > Send Single Message to a Recipient.
    
- **SendMultipleSMS()**
    - > **Parameter:** number (List<string>), recipient_message (string)
    - > **Return:** return as integer where it counts number of fail to send to recipient.
    - > Send Message to Multiple Recipient.
 
 - **ReadAllMessages()**
    - > **Parameter:** None
    - > Reads all the Messages in your Sim Card Inbox.


---
## Tutorial on how to use it.
#### **Sending Single Message**
- Step 1: Intiantiate the EJCSMS.cs from your form the above of all form control methods.
   - > EJCSMS SMS = new EJCSMS(allow_long_msg: true, allow_empty_sms: false);
   
- Step 2: On Form_Load Init EJC SMS with your existing port of your GSM Modem Device
   - > SMS.InitSMS(GSM_MODEM_PORT); // Initialize the SMS.
   
- Step 3: Call the SendSMS() method on SMS Object.
   - > SMS.SendSMS("your_phone_number", "your message here");
   
- You are done! Easy right?

#### **Sending Message to Multiple Recipient**
- Step 1: Intiantiate the EJCSMS.cs from your form the above of all form control methods.
   - > EJCSMS SMS = new EJCSMS(allow_long_msg: true, allow_empty_sms: false);
   
- Step 2: On Form_Load Init EJC SMS with your existing port of your GSM Modem Device
   - > SMS.InitSMS(GSM_MODEM_PORT); // Initialize the SMS.
   
- Step 3: Declare List<string> phonenumba = new List<string>(); and add some phone numbers to it.
   - > List< string > phonenumba = new List < string > ();
      phonenumba.Add("phone_number_1");
      phonenumba.Add("phone_number_2");
      phonenumba.Add("phone_number_3");
 
- Step 4: After adding phone number on the List you can just call phonenumba and insert it on SMS.SendMultipleSMS first parameter.
   - > SMS.SendMultipleSMS(phonenumba, "Your message here"); 
   
- You are done!

#### **How to Read All Messages**
- Step 1: Intiantiate the EJCSMS.cs from your form the above of all form control methods.
   - > EJCSMS SMS = new EJCSMS(allow_long_msg: true, allow_empty_sms: false);
   
- Step 2: On Form_Load Init EJC SMS with your existing port of your GSM Modem Device
   - > SMS.InitSMS(GSM_MODEM_PORT); // Initialize the SMS.
   
- Step 3: Create a DatagridView Control on your form. Then just set the datasource just like this.
   - > yourDataGridView.DataSource = SMS.ReadAllMesasges();
   
- You are done! Easy right? with EJC SMS you can show all SMS in just one line.
---
## **SMS Sending error? or No SMS receive?**
### You can check EJC_SMS Directory folder inside of your respective project (/bin/debug/EJC_SMS). There you can find debug.txt and error.txt allowing you to determine what cause your SMS fail in some events.
#### **Directory Folder:**

![Directory](https://github.com/eksqtr/EJC-SMS/blob/master/Screenshots/DirectoryFolder.png)

#### **Debug:**

![DebugTxt](https://github.com/eksqtr/EJC-SMS/blob/master/Screenshots/Debugtxt.png)

#### **Error:**

![ErrorTxt](https://github.com/eksqtr/EJC-SMS/blob/master/Screenshots/Errortxt.png)

---
## I made an example System on how to use this EJC SMS

### Singe Recipient
![SendSMSSingle](https://github.com/eksqtr/EJC-SMS/blob/master/Screenshots/Send_SMS_(Single).png)
![SendSMSSingleProof](https://github.com/eksqtr/EJC-SMS/blob/master/Screenshots/Single_SMS_(Proof).jpg)

### Multiple Recipient
![SendSMSMultiple](https://github.com/eksqtr/EJC-SMS/blob/master/Screenshots/Send_SMS_(Multiple).png)
![SendSMSMultipleProof](https://github.com/eksqtr/EJC-SMS/blob/master/Screenshots/Multiple_SMS_(Proof).jpg)

### Reading SMS
![ReadSMS](https://github.com/eksqtr/EJC-SMS/blob/master/Screenshots/Inbox_Dashboard.png)

##### *Hard Coded by: [Clemente](https://www.facebook.com/eksqtr)*
