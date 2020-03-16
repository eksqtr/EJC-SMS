<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gridViewInbox = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.checkMultiple = New System.Windows.Forms.CheckBox()
        Me.txtMessage = New System.Windows.Forms.RichTextBox()
        Me.bttnClearNumber = New System.Windows.Forms.Button()
        Me.bttnSend = New System.Windows.Forms.Button()
        Me.bttnAddPhoneNumber = New System.Windows.Forms.Button()
        Me.lboxPhoneNumber = New System.Windows.Forms.ListBox()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.txtAddPhoneNumber = New System.Windows.Forms.TextBox()
        Me.bttnRefresh = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDateToday = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gridViewInbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.EJC_SMS_VBNet.My.Resources.Resources.inbox_70px
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(29, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(65, 47)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 256)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(963, 388)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(955, 359)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Inbox"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(949, 353)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.bttnRefresh)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.gridViewInbox)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(949, 353)
        Me.Panel2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(100, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 29)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Inbox"
        '
        'gridViewInbox
        '
        Me.gridViewInbox.AllowUserToAddRows = False
        Me.gridViewInbox.AllowUserToDeleteRows = False
        Me.gridViewInbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridViewInbox.Location = New System.Drawing.Point(29, 65)
        Me.gridViewInbox.Name = "gridViewInbox"
        Me.gridViewInbox.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.gridViewInbox.Size = New System.Drawing.Size(883, 264)
        Me.gridViewInbox.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.lblDateToday)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.PictureBox3)
        Me.TabPage2.Controls.Add(Me.checkMultiple)
        Me.TabPage2.Controls.Add(Me.txtMessage)
        Me.TabPage2.Controls.Add(Me.bttnClearNumber)
        Me.TabPage2.Controls.Add(Me.bttnSend)
        Me.TabPage2.Controls.Add(Me.bttnAddPhoneNumber)
        Me.TabPage2.Controls.Add(Me.lboxPhoneNumber)
        Me.TabPage2.Controls.Add(Me.txtPhoneNumber)
        Me.TabPage2.Controls.Add(Me.txtAddPhoneNumber)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(955, 359)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "SMS Dashboard"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Message:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(191, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Phone Number:"
        '
        'checkMultiple
        '
        Me.checkMultiple.AutoSize = True
        Me.checkMultiple.Location = New System.Drawing.Point(790, 283)
        Me.checkMultiple.Name = "checkMultiple"
        Me.checkMultiple.Size = New System.Drawing.Size(154, 20)
        Me.checkMultiple.TabIndex = 15
        Me.checkMultiple.Text = "Send Multiple Msg"
        Me.checkMultiple.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(193, 135)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(590, 118)
        Me.txtMessage.TabIndex = 14
        Me.txtMessage.Text = ""
        '
        'bttnClearNumber
        '
        Me.bttnClearNumber.Image = Global.EJC_SMS_VBNet.My.Resources.Resources.icons8_delete_30px
        Me.bttnClearNumber.Location = New System.Drawing.Point(6, 313)
        Me.bttnClearNumber.Name = "bttnClearNumber"
        Me.bttnClearNumber.Size = New System.Drawing.Size(180, 41)
        Me.bttnClearNumber.TabIndex = 13
        Me.bttnClearNumber.Text = "Clear Number"
        Me.bttnClearNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bttnClearNumber.UseVisualStyleBackColor = True
        '
        'bttnSend
        '
        Me.bttnSend.Image = Global.EJC_SMS_VBNet.My.Resources.Resources.send_30px
        Me.bttnSend.Location = New System.Drawing.Point(790, 305)
        Me.bttnSend.Name = "bttnSend"
        Me.bttnSend.Size = New System.Drawing.Size(160, 41)
        Me.bttnSend.TabIndex = 11
        Me.bttnSend.Text = "Send Message"
        Me.bttnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bttnSend.UseVisualStyleBackColor = True
        '
        'bttnAddPhoneNumber
        '
        Me.bttnAddPhoneNumber.Image = Global.EJC_SMS_VBNet.My.Resources.Resources.add_30px
        Me.bttnAddPhoneNumber.Location = New System.Drawing.Point(6, 266)
        Me.bttnAddPhoneNumber.Name = "bttnAddPhoneNumber"
        Me.bttnAddPhoneNumber.Size = New System.Drawing.Size(180, 41)
        Me.bttnAddPhoneNumber.TabIndex = 12
        Me.bttnAddPhoneNumber.Text = "Add Phone Number"
        Me.bttnAddPhoneNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.bttnAddPhoneNumber.UseVisualStyleBackColor = True
        '
        'lboxPhoneNumber
        '
        Me.lboxPhoneNumber.FormattingEnabled = True
        Me.lboxPhoneNumber.ItemHeight = 16
        Me.lboxPhoneNumber.Location = New System.Drawing.Point(4, 4)
        Me.lboxPhoneNumber.Name = "lboxPhoneNumber"
        Me.lboxPhoneNumber.Size = New System.Drawing.Size(180, 228)
        Me.lboxPhoneNumber.TabIndex = 10
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(193, 81)
        Me.txtPhoneNumber.MaxLength = 11
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(180, 22)
        Me.txtPhoneNumber.TabIndex = 8
        '
        'txtAddPhoneNumber
        '
        Me.txtAddPhoneNumber.Location = New System.Drawing.Point(6, 238)
        Me.txtAddPhoneNumber.MaxLength = 11
        Me.txtAddPhoneNumber.Name = "txtAddPhoneNumber"
        Me.txtAddPhoneNumber.Size = New System.Drawing.Size(180, 22)
        Me.txtAddPhoneNumber.TabIndex = 9
        '
        'bttnRefresh
        '
        Me.bttnRefresh.Location = New System.Drawing.Point(837, 40)
        Me.bttnRefresh.Name = "bttnRefresh"
        Me.bttnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.bttnRefresh.TabIndex = 2
        Me.bttnRefresh.Text = "Refresh"
        Me.bttnRefresh.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label4.Location = New System.Drawing.Point(391, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 29)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "EJC"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(391, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(283, 29)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Short Message Service"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(451, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 20)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "(VB.Net Version)"
        '
        'lblDateToday
        '
        Me.lblDateToday.Location = New System.Drawing.Point(760, 4)
        Me.lblDateToday.Name = "lblDateToday"
        Me.lblDateToday.Size = New System.Drawing.Size(192, 22)
        Me.lblDateToday.TabIndex = 17
        Me.lblDateToday.Text = "March 16, 2020"
        Me.lblDateToday.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.EJC_SMS_VBNet.My.Resources.Resources.EJC_sms_Logo
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(264, 58)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(121, 99)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.EJC_SMS_VBNet.My.Resources.Resources.send_30px
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(427, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(65, 47)
        Me.PictureBox3.TabIndex = 0
        Me.PictureBox3.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(498, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "SMS Dashboard"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaGreen
        Me.ClientSize = New System.Drawing.Size(987, 665)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EJC SMS - Dashboard"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.gridViewInbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents checkMultiple As CheckBox
    Friend WithEvents txtMessage As RichTextBox
    Friend WithEvents bttnClearNumber As Button
    Friend WithEvents bttnSend As Button
    Friend WithEvents bttnAddPhoneNumber As Button
    Friend WithEvents lboxPhoneNumber As ListBox
    Friend WithEvents txtPhoneNumber As TextBox
    Friend WithEvents txtAddPhoneNumber As TextBox
    Friend WithEvents gridViewInbox As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents bttnRefresh As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDateToday As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox3 As PictureBox
End Class
