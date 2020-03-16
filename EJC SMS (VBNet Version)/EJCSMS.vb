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

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class EJCSMS

    Private serialPort As New IO.Ports.SerialPort
    'EJC SMS Configuration

    ' System Configuration
    Private Const MAX_SMS_CHARACTERS = 155
    Private Const THREAD_SLEEP = 100
    Private Const DELAY_SEND = 1000

    ' Philippines Mobile Phone Sim Card Prefixes
    ' Source: https://www.prefix.ph/prefixes/2019-updated-complete-list-of-philippine-mobile-network-prefixes/
    Private LISTS_PHILIPPINES_SIM_PREFIXES() As String =
            {"0817", "0973", "0904", "0916", "0935", "0956", "0975", "0979", "0905", "0917", "0936",
                "0965", "0976", "0994", "0906", "0926", "0937", "0966", "0977", "0995", "0915", "0927", "0945", "0967", "0978",
                "0997", "09173", "09178", "09256", "09175", "09253", "09257", "09176", "09255", "09258", "0907", "0912", "0946",
                "0909", "0930", "0948", "0910", "0938", "0950", "0813", "0913", "0919", "0928", "0947", "0970", "0998",
                "0908", "0914", "0920", "0929", "0949", "0981", "0999", "0911", "0918", "0921", "0939", "0961", "0989",
                "0922", "0931", "0941", "0923", "0932", "0942", "0924", "0933", "0943", "0925", "0934", "0944"}

    Private ReadOnly SMS_DIRECTORY As String = String.Format("{0}\\EJC_SMS", Application.StartupPath())

    'User Config
    Private ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS As Boolean = False
    Private ENABLE_EMPTY_SMS_MESSAGE As Boolean = False

    '  =================== METHODS ======================= 
    '/* Method EJCSMS (Constructor)
    '   * Parameter: bool:allow_long_msg
    '   * Description: Enabling/Disabling the long message in sending messages
    '   * 
    '   * Parameter: bool:allow_empty_sms
    '   * Description: Enabling/Disabling sending empty message to the recipient
    '   */
    Public Sub New(ByVal allow_long_msg As Boolean, ByVal allow_empty_sms As Boolean)

        Dim IsDirectoryExist As Boolean = Directory.Exists(SMS_DIRECTORY)
        If Not IsDirectoryExist Then
            Dim dir = Directory.CreateDirectory(SMS_DIRECTORY)
            dir.Create()
        End If

        ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS = allow_long_msg
        ENABLE_EMPTY_SMS_MESSAGE = allow_empty_sms
    End Sub


    '/* Method DebugPrint
    '     * Parameter: String : print
    '     * Description: A message that the system print 
    '     * 
    '     * Parameter: bool:Error
    '     * Description: Whether it Is an Error Or debug 
    '     */
    Private Sub DebugPrint(ByVal print As String, Optional ByVal IsError As Boolean = False)
        Dim smsPath As String = String.Format("{0}\\{1}", SMS_DIRECTORY, IIf(IsError = False, "error.txt", "debug.txt"))
        Dim printEx As String = String.Format("Date Occured: {0}\n{1}: {2}", DateTime.Now, IIf(IsError = False, "Error", "Debug"), print)
        If Not File.Exists(smsPath) Then
            File.Create(smsPath).Dispose()
        End If

        Using streamWriter As New StreamWriter(File.Open(smsPath, FileMode.OpenOrCreate))
            streamWriter.WriteLine(printEx)
            streamWriter.WriteLine("---------------------------------------------------------------------------")
        End Using

    End Sub


    '/* Method InitSMS
    '     * Parameter: String : port_name
    '     * Description: This will Set the serial port Of the system In which initiate the GSM Modem Device.
    '     */ 
    Public Sub InitSMS(ByVal port_name As String)
        With serialPort
            .PortName = port_name
            .Parity = Nothing
            .DataBits = 8
            .Handshake = IO.Ports.Handshake.XOnXOff
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = Environment.NewLine
        End With
    End Sub

    '/* Method createMessage
    '     * Parameter: String : recipient_number
    '     * Description: Recipient number Is the one receiving message
    '     * 
    '     * Parameter: String : recipient_message
    '     * Description: A message that you wanted To say To the recipient number
    '     */
    Private Sub createMessage(ByVal recipient_number As String, ByVal recipient_message As String)
        Try
            serialPort.Open()
            If (serialPort.IsOpen) Then
                With serialPort
                    .WriteLine("AT" & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .WriteLine("AT+CMGF=1" & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .WriteLine("AT+CSCS=""GSM"" " & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .WriteLine("AT+CMGS=" & Chr(34) & recipient_number & Chr(34) & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .Write(recipient_message & Chr(26))
                    Thread.Sleep(THREAD_SLEEP)
                    DebugPrint(serialPort.ReadExisting())

                End With
                serialPort.Close()
            End If
        Catch ex As Exception
            DebugPrint(ex.Message, True)
        End Try
    End Sub

    '/* Method: IsValidRecipientNumber
    '    * Parameter: String : recipient_number
    '    * Description: This validates If the number Of the input recipient number exists.
    '    */
    Public Function IsValidRecipientNumber(ByVal recipient_number As String) As Boolean
        If recipient_number.Length < 11 Or recipient_number.Length > 11 Then
            Return False
        End If

        Dim num
        For Each num In LISTS_PHILIPPINES_SIM_PREFIXES
            If recipient_number.Substring(0, 4).Contains(num) Or recipient_number.Substring(0, 5).Contains(num) Then
                Return True
            End If
        Next
        Return False
    End Function

    '/* Method: ReadAllMessages
    '    * Description: This returns all messages As DataTable
    '    */
    Public Function ReadAllMessages() As DataTable
        Dim inboxTable As New DataTable
        inboxTable.Columns.Add("Recipient", GetType(String))
        inboxTable.Columns.Add("Date & Time", GetType(Date))
        inboxTable.Columns.Add("Message", GetType(String))

        Try
            serialPort.Open()
            If serialPort.IsOpen Then
                With serialPort
                    .WriteLine("AT" & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .WriteLine("AT+CMGF=1" & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .WriteLine("AT+CMGL=""ALL"" " & vbCrLf)
                    Thread.Sleep(THREAD_SLEEP)
                    .Write(Chr(26))
                    Thread.Sleep(THREAD_SLEEP)
                End With

                Dim match As Match = Regex.Match(serialPort.ReadExisting(), "\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n")

                While match.Success
                    Dim row = inboxTable.NewRow()
                    row(0) = match.Groups(3).Value

                    Dim splitStr() = match.Groups(5).Value.Substring(0, 8).Split("/")
                    Dim tempDate As String = String.Format("{0}/{1}/{2} {3}", splitStr(1), splitStr(2), splitStr(0), match.Groups(5).Value.Substring(9, 8))

                    row(1) = Convert.ToDateTime(tempDate)
                    row(2) = match.Groups(6).Value

                    inboxTable.Rows.Add(row)
                    match = match.NextMatch()
                End While
                serialPort.Close()
                Return inboxTable
            End If

        Catch ex As Exception
            DebugPrint(ex.Message, True)
        End Try

        Return inboxTable
    End Function

    '/* Method SendSMS
    '     * Parameter: String : recipient_number
    '     * Description: Recipient number Is the one receiving message
    '     * 
    '     * Parameter: String : recipient_message
    '     * Description: A message that you wanted To say To the recipient number
    '     * 
    '     * Return in boolean
    '     */
    Public Function SendSMS(ByVal recipient_number As String, ByVal recipient_message As String) As Boolean
        Dim tempStr As String = ""
        If IsValidRecipientNumber(recipient_number) = False Then
            tempStr = String.Format("{0}\n\nWarning: Invalid Phone Number!", recipient_number)
            DebugPrint(tempStr, True)
            Return False
        End If

        If ENABLE_EMPTY_SMS_MESSAGE = False And String.IsNullOrEmpty(recipient_message) Then
            tempStr = String.Format("Recipient({0})\nWarning: ENABLE_EMPTY_SMS_MESSAGE in EJC SMS Config is disabled therefore empty or nulled string cannot be send.", recipient_number)
            DebugPrint(tempStr, True)
            Return False
        End If
        If ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS = True And recipient_message.Length > MAX_SMS_CHARACTERS Then
            Dim recipient_messageLength As Integer = recipient_message.Length
            Dim lowp As Integer = 0
            Dim value As Double = Convert.ToDouble(recipient_messageLength / MAX_SMS_CHARACTERS)
            Dim maxcount As Double = value

            For index As Integer = 0 To maxcount
                lowp += 1
            Next
            createMessage(recipient_number, recipient_message.Substring(0, MAX_SMS_CHARACTERS))
            Console.WriteLine(recipient_message.Substring(0, MAX_SMS_CHARACTERS))
            Dim getLastCut As Integer = MAX_SMS_CHARACTERS

            For index As Integer = 0 To lowp
                If getLastCut > recipient_messageLength Then
                    Exit For
                End If
                recipient_messageLength -= MAX_SMS_CHARACTERS
                Dim getLastCutEx As Integer = IIf(recipient_messageLength > MAX_SMS_CHARACTERS, MAX_SMS_CHARACTERS, recipient_messageLength)
                createMessage(recipient_number, recipient_message.Substring(getLastCut, getLastCutEx))
                Console.WriteLine(recipient_message.Substring(getLastCut, getLastCutEx))
                getLastCut += MAX_SMS_CHARACTERS
            Next

        Else
            If recipient_message.Length > MAX_SMS_CHARACTERS And Not ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS Then
                tempStr = String.Format("Recipient({0}) - {1}\n\nWarning: ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS in EJC SMS Config is disabled there for the max character you wanted to send exceeds!", recipient_number, recipient_message)
                DebugPrint(tempStr, True)
                Return False
            Else
                createMessage(recipient_number, recipient_message)
            End If
        End If
        Return True
    End Function

    '/* Method SendMultipleSMS
    '     * Parameter: String : number
    '     * Description: Recipient number Is the one receiving message In list
    '     * 
    '     * Parameter: String : recipient_message
    '     * Description: A message that you wanted To say To the recipient number
    '     * 
    '     * Return in how many SMS fail to send. if return 0 means all message send successfuly.
    '     */
    Public Function SendMultipleSMS(ByVal number As List(Of String), ByVal recipient_message As String) As Integer
        Dim countFail As Integer = 0
        For Each recipient_number In number
            Dim tempStr As String = ""
            If IsValidRecipientNumber(recipient_number) = False Then
                tempStr = String.Format("{0}\n\nWarning: Invalid Phone Number!", recipient_number)
                DebugPrint(tempStr, True)
                countFail += 1
            End If

            If ENABLE_EMPTY_SMS_MESSAGE = False And String.IsNullOrEmpty(recipient_message) Then
                tempStr = String.Format("Recipient({0})\nWarning: ENABLE_EMPTY_SMS_MESSAGE in EJC SMS Config is disabled therefore empty or nulled string cannot be send.", recipient_number)
                DebugPrint(tempStr, True)
                countFail += 1
            End If
            If ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS = True And recipient_message.Length > MAX_SMS_CHARACTERS Then
                Dim recipient_messageLength As Integer = recipient_message.Length
                Dim lowp As Integer = 0
                Dim value As Double = Convert.ToDouble(recipient_messageLength / MAX_SMS_CHARACTERS)
                Dim maxcount As Double = value

                For index As Integer = 0 To maxcount
                    lowp += 1
                Next
                createMessage(recipient_number, recipient_message.Substring(0, MAX_SMS_CHARACTERS))
                Console.WriteLine(recipient_message.Substring(0, MAX_SMS_CHARACTERS))
                Dim getLastCut As Integer = MAX_SMS_CHARACTERS

                For index As Integer = 0 To lowp
                    If getLastCut > recipient_messageLength Then
                        Exit For
                    End If
                    recipient_messageLength -= MAX_SMS_CHARACTERS
                    Dim getLastCutEx As Integer = IIf(recipient_messageLength > MAX_SMS_CHARACTERS, MAX_SMS_CHARACTERS, recipient_messageLength)
                    createMessage(recipient_number, recipient_message.Substring(getLastCut, getLastCutEx))
                    Console.WriteLine(recipient_message.Substring(getLastCut, getLastCutEx))
                    getLastCut += MAX_SMS_CHARACTERS
                Next

            Else
                If recipient_message.Length > MAX_SMS_CHARACTERS And Not ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS Then
                    tempStr = String.Format("Recipient({0}) - {1}\n\nWarning: ENABLE_EXCEED_MAXIMUM_CHARACTER_SMS in EJC SMS Config is disabled there for the max character you wanted to send exceeds!", recipient_number, recipient_message)
                    DebugPrint(tempStr, True)
                    countFail += 1
                Else
                    createMessage(recipient_number, recipient_message)
                End If
            End If
        Next
        Return countFail
    End Function
End Class
