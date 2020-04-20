Imports System.IO
Imports FSM.Entity.Sys

Public Class UCCustomerServiceProcess : Inherits FSM.UCBase : Implements IUserControl

    Public Sub New(ByVal _customerId As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        CustomerId = _customerId

        Populate()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents grpBxServiceDate As GroupBox
    Friend WithEvents lnkDownloadExampleTemplate As LinkLabel
    Friend WithEvents grpTemplate3 As GroupBox
    Friend WithEvents btnDownloadTemplate3 As Button
    Friend WithEvents btnAddTemplate3 As Button
    Friend WithEvents btnTestTemplate3 As Button
    Friend WithEvents grpTemplate2 As GroupBox
    Friend WithEvents btnDownloadTemplate2 As Button
    Friend WithEvents btnAddTemplate2 As Button
    Friend WithEvents btnTestTemplate2 As Button
    Friend WithEvents grpTemplate1 As GroupBox
    Friend WithEvents btnDownloadTemplate1 As Button
    Friend WithEvents btnAddTemplate1 As Button
    Friend WithEvents btnTestTemplate1 As Button
    Friend WithEvents btnDeleteProcess As Button
    Friend WithEvents txtAppointment3 As TextBox
    Friend WithEvents lblAppointment3 As Label
    Friend WithEvents txtAppointment2 As TextBox
    Friend WithEvents lblAppointment2 As Label
    Friend WithEvents txtAppointment1 As TextBox
    Friend WithEvents lblAppointment1 As Label
    Friend WithEvents txtLetter3 As TextBox
    Friend WithEvents lblLetter3 As Label
    Friend WithEvents txtLetter2 As TextBox
    Friend WithEvents lblLetter2 As Label
    Friend WithEvents txtLetter1 As TextBox
    Friend WithEvents lblLetter1 As Label
    Friend WithEvents btnSaveServiceProcess As Button
    Friend WithEvents grpPatchCheck As GroupBox
    Friend WithEvents btnDownloadPatchCheckTemplate As Button
    Friend WithEvents btnAddPatchCheckTemplate As Button
    Friend WithEvents btnTestPatchCheckTemplate As Button

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpBxServiceDate = New System.Windows.Forms.GroupBox()
        Me.grpPatchCheck = New System.Windows.Forms.GroupBox()
        Me.btnDownloadPatchCheckTemplate = New System.Windows.Forms.Button()
        Me.btnAddPatchCheckTemplate = New System.Windows.Forms.Button()
        Me.btnTestPatchCheckTemplate = New System.Windows.Forms.Button()
        Me.lnkDownloadExampleTemplate = New System.Windows.Forms.LinkLabel()
        Me.grpTemplate3 = New System.Windows.Forms.GroupBox()
        Me.btnDownloadTemplate3 = New System.Windows.Forms.Button()
        Me.btnAddTemplate3 = New System.Windows.Forms.Button()
        Me.btnTestTemplate3 = New System.Windows.Forms.Button()
        Me.grpTemplate2 = New System.Windows.Forms.GroupBox()
        Me.btnDownloadTemplate2 = New System.Windows.Forms.Button()
        Me.btnAddTemplate2 = New System.Windows.Forms.Button()
        Me.btnTestTemplate2 = New System.Windows.Forms.Button()
        Me.grpTemplate1 = New System.Windows.Forms.GroupBox()
        Me.btnDownloadTemplate1 = New System.Windows.Forms.Button()
        Me.btnAddTemplate1 = New System.Windows.Forms.Button()
        Me.btnTestTemplate1 = New System.Windows.Forms.Button()
        Me.btnDeleteProcess = New System.Windows.Forms.Button()
        Me.txtAppointment3 = New System.Windows.Forms.TextBox()
        Me.lblAppointment3 = New System.Windows.Forms.Label()
        Me.txtAppointment2 = New System.Windows.Forms.TextBox()
        Me.lblAppointment2 = New System.Windows.Forms.Label()
        Me.txtAppointment1 = New System.Windows.Forms.TextBox()
        Me.lblAppointment1 = New System.Windows.Forms.Label()
        Me.txtLetter3 = New System.Windows.Forms.TextBox()
        Me.lblLetter3 = New System.Windows.Forms.Label()
        Me.txtLetter2 = New System.Windows.Forms.TextBox()
        Me.lblLetter2 = New System.Windows.Forms.Label()
        Me.txtLetter1 = New System.Windows.Forms.TextBox()
        Me.lblLetter1 = New System.Windows.Forms.Label()
        Me.btnSaveServiceProcess = New System.Windows.Forms.Button()
        Me.grpBxServiceDate.SuspendLayout()
        Me.grpPatchCheck.SuspendLayout()
        Me.grpTemplate3.SuspendLayout()
        Me.grpTemplate2.SuspendLayout()
        Me.grpTemplate1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBxServiceDate
        '
        Me.grpBxServiceDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBxServiceDate.Controls.Add(Me.grpPatchCheck)
        Me.grpBxServiceDate.Controls.Add(Me.lnkDownloadExampleTemplate)
        Me.grpBxServiceDate.Controls.Add(Me.grpTemplate3)
        Me.grpBxServiceDate.Controls.Add(Me.grpTemplate2)
        Me.grpBxServiceDate.Controls.Add(Me.grpTemplate1)
        Me.grpBxServiceDate.Controls.Add(Me.btnDeleteProcess)
        Me.grpBxServiceDate.Controls.Add(Me.txtAppointment3)
        Me.grpBxServiceDate.Controls.Add(Me.lblAppointment3)
        Me.grpBxServiceDate.Controls.Add(Me.txtAppointment2)
        Me.grpBxServiceDate.Controls.Add(Me.lblAppointment2)
        Me.grpBxServiceDate.Controls.Add(Me.txtAppointment1)
        Me.grpBxServiceDate.Controls.Add(Me.lblAppointment1)
        Me.grpBxServiceDate.Controls.Add(Me.txtLetter3)
        Me.grpBxServiceDate.Controls.Add(Me.lblLetter3)
        Me.grpBxServiceDate.Controls.Add(Me.txtLetter2)
        Me.grpBxServiceDate.Controls.Add(Me.lblLetter2)
        Me.grpBxServiceDate.Controls.Add(Me.txtLetter1)
        Me.grpBxServiceDate.Controls.Add(Me.lblLetter1)
        Me.grpBxServiceDate.Controls.Add(Me.btnSaveServiceProcess)
        Me.grpBxServiceDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpBxServiceDate.Location = New System.Drawing.Point(3, 3)
        Me.grpBxServiceDate.Name = "grpBxServiceDate"
        Me.grpBxServiceDate.Size = New System.Drawing.Size(621, 550)
        Me.grpBxServiceDate.TabIndex = 3
        Me.grpBxServiceDate.TabStop = False
        Me.grpBxServiceDate.Text = "Service Process"
        '
        'grpPatchCheck
        '
        Me.grpPatchCheck.Controls.Add(Me.btnDownloadPatchCheckTemplate)
        Me.grpPatchCheck.Controls.Add(Me.btnAddPatchCheckTemplate)
        Me.grpPatchCheck.Controls.Add(Me.btnTestPatchCheckTemplate)
        Me.grpPatchCheck.Location = New System.Drawing.Point(13, 371)
        Me.grpPatchCheck.Name = "grpPatchCheck"
        Me.grpPatchCheck.Size = New System.Drawing.Size(358, 61)
        Me.grpPatchCheck.TabIndex = 165
        Me.grpPatchCheck.TabStop = False
        Me.grpPatchCheck.Text = "Patch Check"
        '
        'btnDownloadPatchCheckTemplate
        '
        Me.btnDownloadPatchCheckTemplate.Location = New System.Drawing.Point(127, 22)
        Me.btnDownloadPatchCheckTemplate.Name = "btnDownloadPatchCheckTemplate"
        Me.btnDownloadPatchCheckTemplate.Size = New System.Drawing.Size(86, 25)
        Me.btnDownloadPatchCheckTemplate.TabIndex = 157
        Me.btnDownloadPatchCheckTemplate.Text = "Download"
        Me.btnDownloadPatchCheckTemplate.Visible = False
        '
        'btnAddPatchCheckTemplate
        '
        Me.btnAddPatchCheckTemplate.Location = New System.Drawing.Point(10, 22)
        Me.btnAddPatchCheckTemplate.Name = "btnAddPatchCheckTemplate"
        Me.btnAddPatchCheckTemplate.Size = New System.Drawing.Size(70, 25)
        Me.btnAddPatchCheckTemplate.TabIndex = 148
        Me.btnAddPatchCheckTemplate.Text = "Add"
        '
        'btnTestPatchCheckTemplate
        '
        Me.btnTestPatchCheckTemplate.Location = New System.Drawing.Point(260, 22)
        Me.btnTestPatchCheckTemplate.Name = "btnTestPatchCheckTemplate"
        Me.btnTestPatchCheckTemplate.Size = New System.Drawing.Size(70, 25)
        Me.btnTestPatchCheckTemplate.TabIndex = 156
        Me.btnTestPatchCheckTemplate.Text = "Test"
        Me.btnTestPatchCheckTemplate.Visible = False
        '
        'lnkDownloadExampleTemplate
        '
        Me.lnkDownloadExampleTemplate.AutoSize = True
        Me.lnkDownloadExampleTemplate.Location = New System.Drawing.Point(433, 28)
        Me.lnkDownloadExampleTemplate.Name = "lnkDownloadExampleTemplate"
        Me.lnkDownloadExampleTemplate.Size = New System.Drawing.Size(172, 13)
        Me.lnkDownloadExampleTemplate.TabIndex = 164
        Me.lnkDownloadExampleTemplate.TabStop = True
        Me.lnkDownloadExampleTemplate.Text = "Download Example Template"
        '
        'grpTemplate3
        '
        Me.grpTemplate3.Controls.Add(Me.btnDownloadTemplate3)
        Me.grpTemplate3.Controls.Add(Me.btnAddTemplate3)
        Me.grpTemplate3.Controls.Add(Me.btnTestTemplate3)
        Me.grpTemplate3.Location = New System.Drawing.Point(13, 283)
        Me.grpTemplate3.Name = "grpTemplate3"
        Me.grpTemplate3.Size = New System.Drawing.Size(358, 61)
        Me.grpTemplate3.TabIndex = 163
        Me.grpTemplate3.TabStop = False
        Me.grpTemplate3.Text = "Template"
        '
        'btnDownloadTemplate3
        '
        Me.btnDownloadTemplate3.Location = New System.Drawing.Point(127, 22)
        Me.btnDownloadTemplate3.Name = "btnDownloadTemplate3"
        Me.btnDownloadTemplate3.Size = New System.Drawing.Size(86, 25)
        Me.btnDownloadTemplate3.TabIndex = 157
        Me.btnDownloadTemplate3.Text = "Download"
        Me.btnDownloadTemplate3.Visible = False
        '
        'btnAddTemplate3
        '
        Me.btnAddTemplate3.Location = New System.Drawing.Point(10, 22)
        Me.btnAddTemplate3.Name = "btnAddTemplate3"
        Me.btnAddTemplate3.Size = New System.Drawing.Size(70, 25)
        Me.btnAddTemplate3.TabIndex = 148
        Me.btnAddTemplate3.Text = "Add"
        '
        'btnTestTemplate3
        '
        Me.btnTestTemplate3.Location = New System.Drawing.Point(260, 22)
        Me.btnTestTemplate3.Name = "btnTestTemplate3"
        Me.btnTestTemplate3.Size = New System.Drawing.Size(70, 25)
        Me.btnTestTemplate3.TabIndex = 156
        Me.btnTestTemplate3.Text = "Test"
        Me.btnTestTemplate3.Visible = False
        '
        'grpTemplate2
        '
        Me.grpTemplate2.Controls.Add(Me.btnDownloadTemplate2)
        Me.grpTemplate2.Controls.Add(Me.btnAddTemplate2)
        Me.grpTemplate2.Controls.Add(Me.btnTestTemplate2)
        Me.grpTemplate2.Location = New System.Drawing.Point(13, 170)
        Me.grpTemplate2.Name = "grpTemplate2"
        Me.grpTemplate2.Size = New System.Drawing.Size(358, 61)
        Me.grpTemplate2.TabIndex = 162
        Me.grpTemplate2.TabStop = False
        Me.grpTemplate2.Text = "Template"
        '
        'btnDownloadTemplate2
        '
        Me.btnDownloadTemplate2.Location = New System.Drawing.Point(127, 22)
        Me.btnDownloadTemplate2.Name = "btnDownloadTemplate2"
        Me.btnDownloadTemplate2.Size = New System.Drawing.Size(86, 25)
        Me.btnDownloadTemplate2.TabIndex = 157
        Me.btnDownloadTemplate2.Text = "Download"
        Me.btnDownloadTemplate2.Visible = False
        '
        'btnAddTemplate2
        '
        Me.btnAddTemplate2.Location = New System.Drawing.Point(10, 22)
        Me.btnAddTemplate2.Name = "btnAddTemplate2"
        Me.btnAddTemplate2.Size = New System.Drawing.Size(70, 25)
        Me.btnAddTemplate2.TabIndex = 148
        Me.btnAddTemplate2.Text = "Add"
        '
        'btnTestTemplate2
        '
        Me.btnTestTemplate2.Location = New System.Drawing.Point(260, 22)
        Me.btnTestTemplate2.Name = "btnTestTemplate2"
        Me.btnTestTemplate2.Size = New System.Drawing.Size(70, 25)
        Me.btnTestTemplate2.TabIndex = 156
        Me.btnTestTemplate2.Text = "Test"
        Me.btnTestTemplate2.Visible = False
        '
        'grpTemplate1
        '
        Me.grpTemplate1.Controls.Add(Me.btnDownloadTemplate1)
        Me.grpTemplate1.Controls.Add(Me.btnAddTemplate1)
        Me.grpTemplate1.Controls.Add(Me.btnTestTemplate1)
        Me.grpTemplate1.Location = New System.Drawing.Point(13, 55)
        Me.grpTemplate1.Name = "grpTemplate1"
        Me.grpTemplate1.Size = New System.Drawing.Size(358, 61)
        Me.grpTemplate1.TabIndex = 161
        Me.grpTemplate1.TabStop = False
        Me.grpTemplate1.Text = "Template"
        '
        'btnDownloadTemplate1
        '
        Me.btnDownloadTemplate1.Location = New System.Drawing.Point(127, 22)
        Me.btnDownloadTemplate1.Name = "btnDownloadTemplate1"
        Me.btnDownloadTemplate1.Size = New System.Drawing.Size(86, 25)
        Me.btnDownloadTemplate1.TabIndex = 157
        Me.btnDownloadTemplate1.Text = "Download"
        Me.btnDownloadTemplate1.Visible = False
        '
        'btnAddTemplate1
        '
        Me.btnAddTemplate1.Location = New System.Drawing.Point(10, 22)
        Me.btnAddTemplate1.Name = "btnAddTemplate1"
        Me.btnAddTemplate1.Size = New System.Drawing.Size(70, 25)
        Me.btnAddTemplate1.TabIndex = 148
        Me.btnAddTemplate1.Text = "Add"
        '
        'btnTestTemplate1
        '
        Me.btnTestTemplate1.Location = New System.Drawing.Point(260, 22)
        Me.btnTestTemplate1.Name = "btnTestTemplate1"
        Me.btnTestTemplate1.Size = New System.Drawing.Size(70, 25)
        Me.btnTestTemplate1.TabIndex = 156
        Me.btnTestTemplate1.Text = "Test"
        Me.btnTestTemplate1.Visible = False
        '
        'btnDeleteProcess
        '
        Me.btnDeleteProcess.Location = New System.Drawing.Point(13, 508)
        Me.btnDeleteProcess.Name = "btnDeleteProcess"
        Me.btnDeleteProcess.Size = New System.Drawing.Size(90, 23)
        Me.btnDeleteProcess.TabIndex = 146
        Me.btnDeleteProcess.Text = "Delete"
        '
        'txtAppointment3
        '
        Me.txtAppointment3.Location = New System.Drawing.Point(274, 256)
        Me.txtAppointment3.Name = "txtAppointment3"
        Me.txtAppointment3.Size = New System.Drawing.Size(57, 21)
        Me.txtAppointment3.TabIndex = 145
        '
        'lblAppointment3
        '
        Me.lblAppointment3.AutoSize = True
        Me.lblAppointment3.Location = New System.Drawing.Point(169, 259)
        Me.lblAppointment3.Name = "lblAppointment3"
        Me.lblAppointment3.Size = New System.Drawing.Size(90, 13)
        Me.lblAppointment3.TabIndex = 144
        Me.lblAppointment3.Text = "Appointment 3"
        '
        'txtAppointment2
        '
        Me.txtAppointment2.Location = New System.Drawing.Point(274, 143)
        Me.txtAppointment2.Name = "txtAppointment2"
        Me.txtAppointment2.Size = New System.Drawing.Size(57, 21)
        Me.txtAppointment2.TabIndex = 143
        '
        'lblAppointment2
        '
        Me.lblAppointment2.AutoSize = True
        Me.lblAppointment2.Location = New System.Drawing.Point(169, 146)
        Me.lblAppointment2.Name = "lblAppointment2"
        Me.lblAppointment2.Size = New System.Drawing.Size(90, 13)
        Me.lblAppointment2.TabIndex = 142
        Me.lblAppointment2.Text = "Appointment 2"
        '
        'txtAppointment1
        '
        Me.txtAppointment1.Location = New System.Drawing.Point(274, 28)
        Me.txtAppointment1.Name = "txtAppointment1"
        Me.txtAppointment1.Size = New System.Drawing.Size(57, 21)
        Me.txtAppointment1.TabIndex = 141
        '
        'lblAppointment1
        '
        Me.lblAppointment1.AutoSize = True
        Me.lblAppointment1.Location = New System.Drawing.Point(169, 31)
        Me.lblAppointment1.Name = "lblAppointment1"
        Me.lblAppointment1.Size = New System.Drawing.Size(90, 13)
        Me.lblAppointment1.TabIndex = 140
        Me.lblAppointment1.Text = "Appointment 1"
        '
        'txtLetter3
        '
        Me.txtLetter3.Location = New System.Drawing.Point(88, 256)
        Me.txtLetter3.Name = "txtLetter3"
        Me.txtLetter3.Size = New System.Drawing.Size(57, 21)
        Me.txtLetter3.TabIndex = 139
        '
        'lblLetter3
        '
        Me.lblLetter3.AutoSize = True
        Me.lblLetter3.Location = New System.Drawing.Point(20, 259)
        Me.lblLetter3.Name = "lblLetter3"
        Me.lblLetter3.Size = New System.Drawing.Size(51, 13)
        Me.lblLetter3.TabIndex = 138
        Me.lblLetter3.Text = "Letter 3"
        '
        'txtLetter2
        '
        Me.txtLetter2.Location = New System.Drawing.Point(88, 143)
        Me.txtLetter2.Name = "txtLetter2"
        Me.txtLetter2.Size = New System.Drawing.Size(57, 21)
        Me.txtLetter2.TabIndex = 137
        '
        'lblLetter2
        '
        Me.lblLetter2.AutoSize = True
        Me.lblLetter2.Location = New System.Drawing.Point(20, 146)
        Me.lblLetter2.Name = "lblLetter2"
        Me.lblLetter2.Size = New System.Drawing.Size(51, 13)
        Me.lblLetter2.TabIndex = 136
        Me.lblLetter2.Text = "Letter 2"
        '
        'txtLetter1
        '
        Me.txtLetter1.Location = New System.Drawing.Point(88, 28)
        Me.txtLetter1.Name = "txtLetter1"
        Me.txtLetter1.Size = New System.Drawing.Size(57, 21)
        Me.txtLetter1.TabIndex = 135
        '
        'lblLetter1
        '
        Me.lblLetter1.AutoSize = True
        Me.lblLetter1.Location = New System.Drawing.Point(20, 31)
        Me.lblLetter1.Name = "lblLetter1"
        Me.lblLetter1.Size = New System.Drawing.Size(51, 13)
        Me.lblLetter1.TabIndex = 134
        Me.lblLetter1.Text = "Letter 1"
        '
        'btnSaveServiceProcess
        '
        Me.btnSaveServiceProcess.Location = New System.Drawing.Point(515, 508)
        Me.btnSaveServiceProcess.Name = "btnSaveServiceProcess"
        Me.btnSaveServiceProcess.Size = New System.Drawing.Size(90, 23)
        Me.btnSaveServiceProcess.TabIndex = 61
        Me.btnSaveServiceProcess.Text = "Save"
        '
        'UCCustomerServiceProcess
        '
        Me.Controls.Add(Me.grpBxServiceDate)
        Me.Name = "UCCustomerServiceProcess"
        Me.Size = New System.Drawing.Size(640, 569)
        Me.grpBxServiceDate.ResumeLayout(False)
        Me.grpBxServiceDate.PerformLayout()
        Me.grpPatchCheck.ResumeLayout(False)
        Me.grpTemplate3.ResumeLayout(False)
        Me.grpTemplate2.ResumeLayout(False)
        Me.grpTemplate1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _customerId As Integer

    Public Property CustomerId() As Integer
        Get
            Return _customerId
        End Get
        Set(ByVal value As Integer)
            _customerId = value
        End Set
    End Property

    Private _serviceProcess As Entity.Customers.CustomerServiceProcess

    Public Property ServiceProcess() As Entity.Customers.CustomerServiceProcess
        Get
            Return _serviceProcess
        End Get
        Set(value As Entity.Customers.CustomerServiceProcess)
            _serviceProcess = value
            If _serviceProcess Is Nothing Then
                _serviceProcess = New Entity.Customers.CustomerServiceProcess
                _serviceProcess.Exists = False
            End If
        End Set
    End Property

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Public ReadOnly Property LoadedItem As Object Implements IUserControl.LoadedItem
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Sub LoadForm(sender As Object, e As EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
    End Sub

    Private Sub btnSaveServiceProcess_Click(sender As Object, e As EventArgs) Handles btnSaveServiceProcess.Click
        Save()
    End Sub

    Private Sub btnDeleteProcess_Click(sender As Object, e As EventArgs) Handles btnDeleteProcess.Click
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.FSMAdmin) Then
            Dim msg As String = "You do not have the necessary security permissions to edit this information."
            Throw New Security.SecurityException(msg)
        End If
        If Helper.MakeIntegerValid(ServiceProcess?.CustomerServiceProcessID) = 0 Then
            Exit Sub
        End If

        Try
            If Not DB.Customer.[CustomerServiceProcess_Delete](ServiceProcess.CustomerServiceProcessID) Then
                Throw New Exception("Failed to delete!")
            End If
            Populate()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddTemplate1_Click(sender As Object, e As EventArgs) Handles btnAddTemplate1.Click
        Dim template As Byte() = TemplateHelper.AddTemplate()
        If template IsNot Nothing Then
            ServiceProcess.Template1 = template
            btnAddTemplate1.Text = "Change"
            btnTestTemplate1.Visible = True
            btnDownloadTemplate1.Visible = True
        ElseIf ServiceProcess.Template1 IsNot Nothing Then
            btnAddTemplate1.Text = "Change"
            btnTestTemplate1.Visible = True
            btnDownloadTemplate1.Visible = True
        Else
            btnAddTemplate1.Text = "Add"
            btnTestTemplate1.Visible = False
            btnDownloadTemplate1.Visible = False
        End If
    End Sub

    Private Sub btnAddTemplate2_Click(sender As Object, e As EventArgs) Handles btnAddTemplate2.Click
        Dim template As Byte() = TemplateHelper.AddTemplate()
        If template IsNot Nothing Then
            ServiceProcess.Template2 = template
            btnAddTemplate2.Text = "Change"
            btnTestTemplate2.Visible = True
            btnDownloadTemplate2.Visible = True
        ElseIf ServiceProcess.Template2 IsNot Nothing Then
            btnAddTemplate2.Text = "Change"
            btnTestTemplate2.Visible = True
            btnDownloadTemplate2.Visible = True
        Else
            btnAddTemplate2.Text = "Add"
            btnTestTemplate2.Visible = False
            btnDownloadTemplate2.Visible = False
        End If
    End Sub

    Private Sub btnAddTemplate3_Click(sender As Object, e As EventArgs) Handles btnAddTemplate3.Click
        Dim template As Byte() = TemplateHelper.AddTemplate()
        If template IsNot Nothing Then
            ServiceProcess.Template3 = template
            btnAddTemplate3.Text = "Change"
            btnTestTemplate3.Visible = True
            btnDownloadTemplate3.Visible = True
        ElseIf ServiceProcess.Template3 IsNot Nothing Then
            btnAddTemplate3.Text = "Change"
            btnTestTemplate3.Visible = True
            btnDownloadTemplate3.Visible = True
        Else
            btnAddTemplate3.Text = "Add"
            btnTestTemplate3.Visible = False
            btnDownloadTemplate3.Visible = False
        End If
    End Sub

    Private Sub btnAddPatchCheckTemplate_Click(sender As Object, e As EventArgs) Handles btnAddPatchCheckTemplate.Click
        Dim template As Byte() = TemplateHelper.AddTemplate()
        If template IsNot Nothing Then
            ServiceProcess.PatchCheckTemplate = template
            btnAddPatchCheckTemplate.Text = "Change"
            btnTestPatchCheckTemplate.Visible = True
            btnDownloadPatchCheckTemplate.Visible = True
        ElseIf ServiceProcess.PatchCheckTemplate IsNot Nothing Then
            btnAddPatchCheckTemplate.Text = "Change"
            btnTestPatchCheckTemplate.Visible = True
            btnDownloadPatchCheckTemplate.Visible = True
        Else
            btnAddPatchCheckTemplate.Text = "Add"
            btnTestPatchCheckTemplate.Visible = False
            btnDownloadPatchCheckTemplate.Visible = False
        End If
    End Sub

    Private Sub btnTestTemplate1_Click(sender As Object, e As EventArgs) Handles btnTestTemplate1.Click
        If ServiceProcess.Template1 IsNot Nothing Then TemplateHelper.TestTemplate(ServiceProcess.Template1, Enums.TemplateType.ServiceLetter)
    End Sub

    Private Sub btnTestTemplate2_Click(sender As Object, e As EventArgs) Handles btnTestTemplate2.Click
        If ServiceProcess.Template2 IsNot Nothing Then TemplateHelper.TestTemplate(ServiceProcess.Template2, Enums.TemplateType.ServiceLetter)
    End Sub

    Private Sub btnTestTemplate3_Click(sender As Object, e As EventArgs) Handles btnTestTemplate3.Click
        If ServiceProcess.Template3 IsNot Nothing Then TemplateHelper.TestTemplate(ServiceProcess.Template3, Enums.TemplateType.ServiceLetter)
    End Sub

    Private Sub btnTestPatchCheckTemplate_Click(sender As Object, e As EventArgs) Handles btnTestPatchCheckTemplate.Click
        If ServiceProcess.PatchCheckTemplate IsNot Nothing Then TemplateHelper.TestTemplate(ServiceProcess.PatchCheckTemplate, Enums.TemplateType.ServiceLetter)
    End Sub

    Private Sub btnDownloadTemplate1_Click(sender As Object, e As EventArgs) Handles btnDownloadTemplate1.Click
        If ServiceProcess.Template1 IsNot Nothing Then TemplateHelper.DownloadTemplate(ServiceProcess.Template1)
    End Sub

    Private Sub btnDownloadTemplate2_Click(sender As Object, e As EventArgs) Handles btnDownloadTemplate2.Click
        If ServiceProcess.Template2 IsNot Nothing Then TemplateHelper.DownloadTemplate(ServiceProcess.Template2)
    End Sub

    Private Sub btnDownloadTemplate3_Click(sender As Object, e As EventArgs) Handles btnDownloadTemplate3.Click
        If ServiceProcess.Template3 IsNot Nothing Then TemplateHelper.DownloadTemplate(ServiceProcess.Template3)
    End Sub

    Private Sub btnDownloadPatchCheckTemplate_Click(sender As Object, e As EventArgs) Handles btnDownloadPatchCheckTemplate.Click
        If ServiceProcess.PatchCheckTemplate IsNot Nothing Then TemplateHelper.DownloadTemplate(ServiceProcess.PatchCheckTemplate)
    End Sub

    Private Sub lnkDownloadExampleTemplate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDownloadExampleTemplate.LinkClicked
        Dim dlg As New FolderBrowserDialog
        Try
            Cursor.Current = Cursors.WaitCursor
            If dlg.ShowDialog = DialogResult.OK Then
                Dim savePath As String = dlg.SelectedPath & "\ServiceLetterTemplate.docx"
                File.Copy(Application.StartupPath & TheSystem.Configuration.TemplateLocation & "\ServiceLetters\ServiceLetterExample.docx", savePath)
                ShowMessage("File downloaded to " & dlg.SelectedPath & "\ServiceLetterTemplate.docx", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ShowMessage("Template could not be saved : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dlg.Dispose()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub Populate(Optional ID As Integer = 0) Implements IUserControl.Populate
        ServiceProcess = DB.Customer.CustomerServiceProcess_Get_ForCustomer(CustomerId)

        Me.txtLetter1.Text = ServiceProcess.Letter1
        Me.txtLetter2.Text = ServiceProcess.Letter2
        Me.txtLetter3.Text = ServiceProcess.Letter3
        Me.txtAppointment1.Text = ServiceProcess.Appointment1
        Me.txtAppointment2.Text = ServiceProcess.Appointment2
        Me.txtAppointment3.Text = ServiceProcess.Appointment3

        btnAddTemplate1.Text = If(ServiceProcess.Template1 IsNot Nothing, "Change", "Add")
        btnTestTemplate1.Visible = ServiceProcess.Template1 IsNot Nothing
        btnDownloadTemplate1.Visible = ServiceProcess.Template1 IsNot Nothing

        btnAddTemplate2.Text = If(ServiceProcess.Template2 IsNot Nothing, "Change", "Add")
        btnTestTemplate2.Visible = ServiceProcess.Template2 IsNot Nothing
        btnDownloadTemplate2.Visible = ServiceProcess.Template2 IsNot Nothing

        btnAddTemplate3.Text = If(ServiceProcess.Template3 IsNot Nothing, "Change", "Add")
        btnTestTemplate3.Visible = ServiceProcess.Template3 IsNot Nothing
        btnDownloadTemplate3.Visible = ServiceProcess.Template3 IsNot Nothing

        btnAddPatchCheckTemplate.Text = If(ServiceProcess.PatchCheckTemplate IsNot Nothing, "Change", "Add")
        btnTestPatchCheckTemplate.Visible = ServiceProcess.PatchCheckTemplate IsNot Nothing
        btnDownloadPatchCheckTemplate.Visible = ServiceProcess.PatchCheckTemplate IsNot Nothing
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try

            If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.IT) Then
                Dim msg As String = "You do not have the necessary security permissions to edit this information."
                Throw New Security.SecurityException(msg)
            End If
            If ShowMessage("Save service process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                With ServiceProcess
                    .SetCustomerID = CustomerId
                    .SetLetter1 = Helper.MakeIntegerValid(txtLetter1.Text)
                    .SetLetter2 = Helper.MakeIntegerValid(txtLetter2.Text)
                    .SetLetter3 = Helper.MakeIntegerValid(txtLetter3.Text)
                    .SetAppointment1 = Helper.MakeIntegerValid(txtAppointment1.Text)
                    .SetAppointment2 = Helper.MakeIntegerValid(txtAppointment2.Text)
                    .SetAppointment3 = Helper.MakeIntegerValid(txtAppointment3.Text)
                End With

                If Not DB.Customer.CustomerServiceProcess_Update(ServiceProcess) Then
                    Throw New Exception("Failed to save!")
                End If

                ShowMessage("Process saved!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ShowMessage("Error saving details : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

End Class