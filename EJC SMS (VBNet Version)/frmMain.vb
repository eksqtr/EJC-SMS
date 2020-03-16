'
'                $$$$$$$$\   $$$$$\  $$$$$$\         $$$$$$\  $$\      $$\  $$$$$$\  
'                $$  _____|  \__$$ |$$  __$$\       $$  __$$\ $$$\    $$$ |$$  __$$\ 
'                $$ |           $$ |$$ /  \__|      $$ /  \__|$$$$\  $$$$ |$$ /  \__|
'                $$$$$\         $$ |$$ |            \$$$$$$\  $$\$$\$$ $$ |\$$$$$$\  
'                $$  __|  $$\   $$ |$$ |             \____$$\ $$ \$$$  $$ | \____$$\ 
'                $$ |     $$ |  $$ |$$ |  $$\       $$\   $$ |$$ |\$  /$$ |$$\   $$ |
'                $$$$$$$$\\$$$$$$  |\$$$$$$  |      \$$$$$$  |$$ | \_/ $$ |\$$$$$$  |
'                \________|\______/  \______/        \______/ \__|     \__| \______/ 

'                                EJC Short Message Service v0.5
'                             VB .Net Version (Converted from C#)

'                   Having trouble on making your own Send and Read Messages code for your 
'            Project / System using your GSM Modem Device? Say no more. EJC SMS (EJC Short 
'            Message Service) is a library that use AT Comamnd will let you to Send 
'            and Read Messages at ease in which helps you to minimized your time developing 
'            your system with SMS Feature.

'            Github Repository: https://github.com/eksqtr/EJC-SMS

'            For more Information about AT Commands please refer to this site:
'                https://www.developershome.com/sms/

'                                                  Developed by: https://github.com/eksqtr
'


Public Class frmMain
    'Intantiate the EJC SMS library to SMS as Object
    Dim SMS As New EJCSMS(allow_long_msg:=True, allow_empty_sms:=False) ' Configure your EJCSMS with these parameter

    Dim GSM_MODEM_PORT As String = "COM5" ' Please change this to your existing Com Port
    Private Sub bttnSend_Click(sender As Object, e As EventArgs) Handles bttnSend.Click

        If Not checkMultiple.CheckState = CheckState.Checked Then
            ' Check if the phone number is valid
            If Not SMS.IsValidRecipientNumber(txtPhoneNumber.Text) = True Then
                MessageBox.Show("Invalid Phone Number!", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If String.IsNullOrEmpty(txtMessage.Text) Then
                MessageBox.Show("You cannot send an Empty Message!", "Message is Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMessage.Select() ' now focus the txtmessage
                Return
            End If
            'Now Send the message
            If SMS.SendSMS(txtPhoneNumber.Text, txtMessage.Text) = True Then
                MessageBox.Show("Message successfuly sent!", "Delivering Message Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Message failed to send!", "Delivering Message Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else

            If String.IsNullOrEmpty(txtMessage.Text) Then
                MessageBox.Show("You cannot send an Empty Message!", "Message is Empty!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtMessage.Select() ' now focus the txtmessage
                Return
            End If


            Dim recipient_number As New List(Of String) ' You need to declare this as List for you to able to send multiple recipient
            For Each numero As String In lboxPhoneNumber.Items ' For Each the lboxPhoneNumber ListBox 
                recipient_number.Add(numero) ' Add it on recipient_number list
            Next
            Dim tempStr As String
            Dim countFail As Integer = SMS.SendMultipleSMS(recipient_number, txtMessage.Text) ' Now you can send it to multiple recipient by doing this

            ' Check if there are number of fail to send
            If countFail > 0 Then
                tempStr = String.Format("There are {0} number of message that has been failed to deliver.", countFail)
                MessageBox.Show(tempStr, "Delivering Message has failed!", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else ' If there were no fail then just show message normaly all message has been delivered.
                tempStr = String.Format("All mesages hsa been sent successfuly")
                MessageBox.Show(tempStr, "Message Delivery Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ' Clear this shit.
            lboxPhoneNumber.Items.Clear()
            txtMessage.Text = ""
            checkMultiple.Checked = False
        End If

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the EJC SMS with your existing GSM Modem Device Port
        SMS.InitSMS(GSM_MODEM_PORT)

        ' Read all the mesages and set it as DataSource to gridView
        gridViewInbox.DataSource = SMS.ReadAllMessages()
        lblDateToday.Text = Date.Now.ToString("MMMM dd, yyyy")
    End Sub

    Private Sub txtAddPhoneNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAddPhoneNumber.KeyPress
        ' Allow only Numeric Keys
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If user press enter in txtAddPhoneNumber perform addPhoneNumber button click
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            bttnAddPhoneNumber.PerformClick()
        End If
    End Sub

    Private Sub bttnAddPhoneNumber_Click(sender As Object, e As EventArgs) Handles bttnAddPhoneNumber.Click
        ' Validation if Adding phone number in multiple recipient is valid if not then this one-way selection statement will trigger.
        If SMS.IsValidRecipientNumber(txtAddPhoneNumber.Text) = False Then
            MessageBox.Show("Your not supposed to add Invalid Number!", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddPhoneNumber.Select() ' Focus the txtbox of adding phone number
            Return
        End If

        ' Reset this shit.
        lboxPhoneNumber.Items.Add(txtAddPhoneNumber.Text)
        txtAddPhoneNumber.Text = ""
        txtAddPhoneNumber.Select()
    End Sub

    Private Sub checkMultiple_CheckedChanged(sender As Object, e As EventArgs) Handles checkMultiple.CheckedChanged

        ' Validation check if the user add multiple recipients if not then this one-way selection statement will trigger.
        If checkMultiple.CheckState = CheckState.Checked Then
            If lboxPhoneNumber.Items.Count < 1 Then
                MessageBox.Show("There were no Phone Numbers added in the phone number lists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                checkMultiple.Checked = False
                txtAddPhoneNumber.Select()
            End If
        End If
    End Sub

    Private Sub txtPhoneNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhoneNumber.KeyPress
        ' Allow only Numeric Keys
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        ' If the user press enter focus textbox txtMesssage
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtMessage.Select()
        End If
    End Sub

    Private Sub bttnRefresh_Click(sender As Object, e As EventArgs) Handles bttnRefresh.Click

        ' Easy peasy in EJC SMS you can load the Inbox SMS with just one line of code.
        gridViewInbox.DataSource = SMS.ReadAllMessages()
    End Sub
End Class
