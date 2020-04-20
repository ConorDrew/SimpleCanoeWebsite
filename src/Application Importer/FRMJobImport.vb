Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports FSM.Entity
Imports FSM.Entity.Customers
Imports FSM.Entity.Engineers
Imports FSM.Entity.Sites
Imports FSM.Entity.Sys

Public Class FRMJobImport : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(cboJobType, DB.JobImports.JobImportType_GetAll().Table, "JobImportTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents grpExcelFile As System.Windows.Forms.GroupBox

    Friend WithEvents txtExcelFile As System.Windows.Forms.TextBox
    Friend WithEvents btnFindExcelFile As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents lblMessages As System.Windows.Forms.Label
    Friend WithEvents cboJobType As System.Windows.Forms.ComboBox
    Friend WithEvents grpFailedImports As GroupBox
    Friend WithEvents dgFailedImports As DataGrid
    Friend WithEvents btnExportFailed As Button
    Friend WithEvents radBtnJobStatus As RadioButton
    Friend WithEvents radBtnJob As RadioButton
    Friend WithEvents lblJobType As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents btnFindCustomer As Button
    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblVisitDate As Label
    Friend WithEvents dtpVisitDate As DateTimePicker
    Friend WithEvents txtEngineer As TextBox
    Friend WithEvents btnFindEngineer As Button
    Friend WithEvents lblEngineer As Label
    Friend WithEvents chkCreateJob As CheckBox
    Friend WithEvents lblProgress As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpExcelFile = New System.Windows.Forms.GroupBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.radBtnJobStatus = New System.Windows.Forms.RadioButton()
        Me.radBtnJob = New System.Windows.Forms.RadioButton()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnFindExcelFile = New System.Windows.Forms.Button()
        Me.txtExcelFile = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.grpFailedImports = New System.Windows.Forms.GroupBox()
        Me.dgFailedImports = New System.Windows.Forms.DataGrid()
        Me.btnExportFailed = New System.Windows.Forms.Button()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.btnFindEngineer = New System.Windows.Forms.Button()
        Me.lblEngineer = New System.Windows.Forms.Label()
        Me.dtpVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.chkCreateJob = New System.Windows.Forms.CheckBox()
        Me.grpExcelFile.SuspendLayout()
        Me.grpFailedImports.SuspendLayout()
        CType(Me.dgFailedImports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpExcelFile
        '
        Me.grpExcelFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpExcelFile.Controls.Add(Me.chkCreateJob)
        Me.grpExcelFile.Controls.Add(Me.lblVisitDate)
        Me.grpExcelFile.Controls.Add(Me.dtpVisitDate)
        Me.grpExcelFile.Controls.Add(Me.txtEngineer)
        Me.grpExcelFile.Controls.Add(Me.btnFindEngineer)
        Me.grpExcelFile.Controls.Add(Me.lblEngineer)
        Me.grpExcelFile.Controls.Add(Me.txtCustomer)
        Me.grpExcelFile.Controls.Add(Me.btnFindCustomer)
        Me.grpExcelFile.Controls.Add(Me.lblCustomer)
        Me.grpExcelFile.Controls.Add(Me.radBtnJobStatus)
        Me.grpExcelFile.Controls.Add(Me.radBtnJob)
        Me.grpExcelFile.Controls.Add(Me.cboJobType)
        Me.grpExcelFile.Controls.Add(Me.lblJobType)
        Me.grpExcelFile.Controls.Add(Me.lblFile)
        Me.grpExcelFile.Controls.Add(Me.btnImport)
        Me.grpExcelFile.Controls.Add(Me.btnFindExcelFile)
        Me.grpExcelFile.Controls.Add(Me.txtExcelFile)
        Me.grpExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpExcelFile.Location = New System.Drawing.Point(8, 40)
        Me.grpExcelFile.Name = "grpExcelFile"
        Me.grpExcelFile.Size = New System.Drawing.Size(896, 134)
        Me.grpExcelFile.TabIndex = 3
        Me.grpExcelFile.TabStop = False
        Me.grpExcelFile.Text = "Select data file to import"
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Location = New System.Drawing.Point(429, 56)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(423, 21)
        Me.txtCustomer.TabIndex = 40
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.Location = New System.Drawing.Point(858, 54)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 39
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = True
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Location = New System.Drawing.Point(349, 59)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(74, 13)
        Me.lblCustomer.TabIndex = 38
        Me.lblCustomer.Text = "Customers:"
        '
        'radBtnJobStatus
        '
        Me.radBtnJobStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radBtnJobStatus.AutoSize = True
        Me.radBtnJobStatus.Checked = True
        Me.radBtnJobStatus.Location = New System.Drawing.Point(670, 24)
        Me.radBtnJobStatus.Name = "radBtnJobStatus"
        Me.radBtnJobStatus.Size = New System.Drawing.Size(84, 17)
        Me.radBtnJobStatus.TabIndex = 37
        Me.radBtnJobStatus.TabStop = True
        Me.radBtnJobStatus.Text = "Job Status"
        Me.radBtnJobStatus.UseVisualStyleBackColor = True
        '
        'radBtnJob
        '
        Me.radBtnJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radBtnJob.AutoSize = True
        Me.radBtnJob.Location = New System.Drawing.Point(760, 24)
        Me.radBtnJob.Name = "radBtnJob"
        Me.radBtnJob.Size = New System.Drawing.Size(44, 17)
        Me.radBtnJob.TabIndex = 36
        Me.radBtnJob.Text = "Job"
        Me.radBtnJob.UseVisualStyleBackColor = True
        '
        'cboJobType
        '
        Me.cboJobType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobType.Location = New System.Drawing.Point(86, 56)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(242, 21)
        Me.cboJobType.TabIndex = 35
        Me.cboJobType.Tag = "Site.RegionID"
        '
        'lblJobType
        '
        Me.lblJobType.AutoSize = True
        Me.lblJobType.Location = New System.Drawing.Point(6, 59)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(62, 13)
        Me.lblJobType.TabIndex = 19
        Me.lblJobType.Text = "Job Type:"
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(6, 23)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(31, 13)
        Me.lblFile.TabIndex = 13
        Me.lblFile.Text = "File:"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImport.Location = New System.Drawing.Point(826, 18)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(64, 23)
        Me.btnImport.TabIndex = 7
        Me.btnImport.Text = "Import"
        '
        'btnFindExcelFile
        '
        Me.btnFindExcelFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFindExcelFile.Location = New System.Drawing.Point(616, 20)
        Me.btnFindExcelFile.Name = "btnFindExcelFile"
        Me.btnFindExcelFile.Size = New System.Drawing.Size(32, 23)
        Me.btnFindExcelFile.TabIndex = 5
        Me.btnFindExcelFile.Text = "..."
        '
        'txtExcelFile
        '
        Me.txtExcelFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExcelFile.Location = New System.Drawing.Point(43, 20)
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.ReadOnly = True
        Me.txtExcelFile.Size = New System.Drawing.Size(567, 21)
        Me.txtExcelFile.TabIndex = 4
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Location = New System.Drawing.Point(848, 624)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbStatus.Location = New System.Drawing.Point(8, 624)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(784, 23)
        Me.pbStatus.Step = 1
        Me.pbStatus.TabIndex = 10
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.Location = New System.Drawing.Point(800, 627)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(40, 16)
        Me.lblProgress.TabIndex = 11
        Me.lblProgress.Text = "0%"
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessages
        '
        Me.lblMessages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessages.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessages.ForeColor = System.Drawing.Color.Red
        Me.lblMessages.Location = New System.Drawing.Point(5, 595)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(787, 19)
        Me.lblMessages.TabIndex = 12
        Me.lblMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMessages.Visible = False
        '
        'grpFailedImports
        '
        Me.grpFailedImports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFailedImports.Controls.Add(Me.dgFailedImports)
        Me.grpFailedImports.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpFailedImports.Location = New System.Drawing.Point(8, 180)
        Me.grpFailedImports.Name = "grpFailedImports"
        Me.grpFailedImports.Size = New System.Drawing.Size(896, 402)
        Me.grpFailedImports.TabIndex = 15
        Me.grpFailedImports.TabStop = False
        Me.grpFailedImports.Text = "Failed Imports"
        '
        'dgFailedImports
        '
        Me.dgFailedImports.DataMember = ""
        Me.dgFailedImports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFailedImports.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgFailedImports.Location = New System.Drawing.Point(3, 17)
        Me.dgFailedImports.Name = "dgFailedImports"
        Me.dgFailedImports.Size = New System.Drawing.Size(890, 382)
        Me.dgFailedImports.TabIndex = 45
        '
        'btnExportFailed
        '
        Me.btnExportFailed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportFailed.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnExportFailed.Location = New System.Drawing.Point(800, 593)
        Me.btnExportFailed.Name = "btnExportFailed"
        Me.btnExportFailed.Size = New System.Drawing.Size(104, 23)
        Me.btnExportFailed.TabIndex = 16
        Me.btnExportFailed.Text = "Export Failures"
        Me.btnExportFailed.Visible = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEngineer.Location = New System.Drawing.Point(616, 93)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(236, 21)
        Me.txtEngineer.TabIndex = 43
        '
        'btnFindEngineer
        '
        Me.btnFindEngineer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindEngineer.Enabled = False
        Me.btnFindEngineer.Location = New System.Drawing.Point(858, 91)
        Me.btnFindEngineer.Name = "btnFindEngineer"
        Me.btnFindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindEngineer.TabIndex = 42
        Me.btnFindEngineer.Text = "..."
        Me.btnFindEngineer.UseVisualStyleBackColor = True
        '
        'lblEngineer
        '
        Me.lblEngineer.AutoSize = True
        Me.lblEngineer.Location = New System.Drawing.Point(548, 96)
        Me.lblEngineer.Name = "lblEngineer"
        Me.lblEngineer.Size = New System.Drawing.Size(62, 13)
        Me.lblEngineer.TabIndex = 41
        Me.lblEngineer.Text = "Engineer:"
        '
        'dtpVisitDate
        '
        Me.dtpVisitDate.Enabled = False
        Me.dtpVisitDate.Location = New System.Drawing.Point(370, 93)
        Me.dtpVisitDate.Name = "dtpVisitDate"
        Me.dtpVisitDate.Size = New System.Drawing.Size(151, 21)
        Me.dtpVisitDate.TabIndex = 44
        '
        'lblVisitDate
        '
        Me.lblVisitDate.AutoSize = True
        Me.lblVisitDate.Location = New System.Drawing.Point(290, 96)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(67, 13)
        Me.lblVisitDate.TabIndex = 45
        Me.lblVisitDate.Text = "Visit Date:"
        '
        'chkCreateJob
        '
        Me.chkCreateJob.AutoCheck = False
        Me.chkCreateJob.AutoSize = True
        Me.chkCreateJob.Location = New System.Drawing.Point(9, 95)
        Me.chkCreateJob.Name = "chkCreateJob"
        Me.chkCreateJob.Size = New System.Drawing.Size(94, 17)
        Me.chkCreateJob.TabIndex = 46
        Me.chkCreateJob.Text = "Create Jobs"
        Me.chkCreateJob.UseVisualStyleBackColor = True
        '
        'FRMJobImport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(912, 654)
        Me.Controls.Add(Me.btnExportFailed)
        Me.Controls.Add(Me.grpFailedImports)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpExcelFile)
        Me.MinimumSize = New System.Drawing.Size(920, 688)
        Me.Name = "FRMJobImport"
        Me.Text = "Job Importer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpExcelFile, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.pbStatus, 0)
        Me.Controls.SetChildIndex(Me.lblProgress, 0)
        Me.Controls.SetChildIndex(Me.lblMessages, 0)
        Me.Controls.SetChildIndex(Me.grpFailedImports, 0)
        Me.Controls.SetChildIndex(Me.btnExportFailed, 0)
        Me.grpExcelFile.ResumeLayout(False)
        Me.grpExcelFile.PerformLayout()
        Me.grpFailedImports.ResumeLayout(False)
        CType(Me.dgFailedImports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Public ReadOnly Property LoadedControl() As IUserControl
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Properties"

    Private _file As IO.FileInfo

    Public Property File As IO.FileInfo
        Get
            Return _file
        End Get
        Set(value As IO.FileInfo)
            _file = value
        End Set
    End Property

    Private _failedImports As New DataTable

    Private Property FailedImports As DataTable
        Get
            Return _failedImports
        End Get
        Set(value As DataTable)
            _failedImports = value
        End Set
    End Property

    Private _customers As New List(Of Customer)

    Public Property Customers() As List(Of Customer)
        Get
            Return _customers
        End Get
        Set(ByVal value As List(Of Customer))
            _customers = value
            If _customers.Count > 0 Then
                Dim custText As String = String.Empty
                Dim addComma As Boolean = False
                For Each cust As Customer In _customers
                    If addComma Then custText += ", "
                    custText += cust.Name
                    addComma = True
                Next
                Me.txtCustomer.Text = custText
            Else
                Me.txtCustomer.Text = ""
            End If
        End Set
    End Property

    Private _engineer As Engineer

    Public Property Engineer() As Engineer
        Get
            Return _engineer
        End Get
        Set
            _engineer = Value
            If Not _engineer Is Nothing Then
                Me.txtEngineer.Text = Engineer.Name
            Else
                Me.txtEngineer.Text = "<Not Set>"
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMJobImport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        radBtnJob.Visible = loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Compliance)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnFindExcelFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFindExcelFile.Click
        LoadData()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Import()
    End Sub

    Private Sub btnExportFailed_Click(sender As Object, e As EventArgs) Handles btnExportFailed.Click
        Export()
    End Sub

#End Region

#Region "Functions"

    Private Sub LoadData()
        Dim dlg As OpenFileDialog
        Dim oExcel As Excel.Application
        Try
            Cursor.Current = Cursors.WaitCursor

            Me.btnFindExcelFile.Enabled = False
            Me.txtExcelFile.Text = ""
            Me.btnImport.Enabled = False

            dlg = New OpenFileDialog
            If dlg.ShowDialog = DialogResult.OK Then
                Dim tempfile As New System.IO.FileInfo(dlg.FileName)

                'Is it an excel file?
                If tempfile.Extension = ".xls" Or tempfile.Extension = ".xlsx" Then
                    File = tempfile
                    'Is an Excel file
                    Me.txtExcelFile.Text = File.FullName
                    Me.btnImport.Enabled = True
                Else
                    ShowMessage("File must be .xls, or .xlsx.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            Me.txtExcelFile.Text = ""
            Me.btnImport.Enabled = False
            ShowMessage("File data could not be loaded : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dlg.Dispose()
            Me.btnFindExcelFile.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Import()
        Dim jobImportTypeID As Integer = Combo.GetSelectedItemValue(cboJobType)
        If radBtnJob.Checked Then
            If jobImportTypeID = 0 Then
                ShowMessage("Please select a job type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Customers.Count = 0 Then
                ShowMessage("Please select a customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Dim oExcel As Excel.Application

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.btnClose.Enabled = False
            Me.btnFindExcelFile.Enabled = False
            Me.btnImport.Enabled = False
            Me.pbStatus.Value = 0
            cboJobType.Enabled = False

            oExcel = New Excel.Application
            oExcel.DisplayAlerts = False
            Dim oWorksheet As Excel.Worksheet
            oExcel.Workbooks.Add(File.FullName)
            oWorksheet = oExcel.Worksheets(1)

            Dim strCom As String = " SELECT * FROM [" & oWorksheet.Name & "$]"
            Dim strCon As String = ""
            If File.Extension.Trim.ToLower = ".xls".ToLower Then
                strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & File.FullName & " ; Extended Properties=Excel 8.0; "
            ElseIf File.Extension.Trim.ToLower = ".xlsx".ToLower Then
                strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " & File.FullName & " ; Extended Properties=Excel 12.0; "
            End If
            Dim conn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(strCon)
            Dim adapter As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
            Dim data As New DataSet

            adapter.SelectCommand = New System.Data.OleDb.OleDbCommand(strCom, conn)
            data.Clear()
            adapter.Fill(data)

            If radBtnJob.Checked Then ImportJobs(data, jobImportTypeID) Else ImportJobsStatus(data)
        Catch ex As Exception
            ShowMessage("File data could not be imported : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            KillInstances(oExcel)

            Dim filePath As String = TheSystem.Configuration.DocumentsLocation
            filePath += IIf(radBtnJob.Checked, "JobImports\", "JobImports\JobStatusImports\")

            Directory.CreateDirectory(filePath)

            Dim fileType As String = Path.GetExtension(File.Name)
            IO.File.Move(File.FullName, filePath & File.Name.Replace(fileType, "_" & Now.ToString("dd_MMM_yyyy_HH_mm_ss") & fileType))
            File = Nothing
            Me.txtExcelFile.Text = ""

            If FailedImports.Rows.Count > 0 Then
                btnExportFailed.Visible = True
            End If

            Me.pbStatus.Value = Me.pbStatus.Maximum
            Me.btnClose.Enabled = True
            Me.btnFindExcelFile.Enabled = True
            cboJobType.Enabled = True
            Me.btnImport.Enabled = True
            Me.pbStatus.Value = 0
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ImportJobsStatus(ByVal data As DataSet)
        data.Tables(0).Columns.Add("Failure Reason")
        FailedImports = data.Tables(0).Clone

        Me.pbStatus.Maximum = data.Tables(0).Rows.Count
        For i As Integer = 0 To data.Tables(0).Rows.Count - 1
            Dim row As DataRow = data.Tables(0).Rows(i)
            Dim jobNumber As String = String.Empty
            Dim status As String = String.Empty
            Dim startDate As String = String.Empty
            Dim visit As Entity.EngineerVisits.EngineerVisit = Nothing

            If data.Tables(0).Columns.Contains("EngineerVisitID") Then
                If row.Item("EngineerVisitID") IsNot DBNull.Value Then
                    Try
                        visit = DB.EngineerVisits.EngineerVisits_Get_As_Object(CInt(row.Item("EngineerVisitID")))
                    Catch ex As Exception

                    End Try
                End If
            End If

            If visit Is Nothing Then
                If row.Item("JobNumber") Is DBNull.Value Then
                    row("Failure Reason") = "No job number"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                Else
                    jobNumber = row.Item("JobNumber")
                End If

                If row.Item("StartDateTime") Is DBNull.Value Then
                    row("Failure Reason") = "No visit start date"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                Else
                    startDate = row.Item("StartDateTime")
                End If

                Dim dvEngineerVisits As DataView = DB.EngineerVisits.EngineerVisits_Get_All_JobNumber_Light(jobNumber)
                If Not dvEngineerVisits.Count > 0 Then
                    row("Failure Reason") = "Cannot find any visits associated to job number"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                End If

                For Each visitRow As DataRow In dvEngineerVisits.Table.Rows
                    If CDate(visitRow("StartDateTime")).Date = CDate(startDate).Date Then
                        visit = DB.EngineerVisits.EngineerVisits_Get_As_Object(CInt(visitRow("EngineerVisitID")))
                    End If
                Next
            End If

            If row.Item("Status") Is DBNull.Value Then
                row("Failure Reason") = "No status found"
                FailedImports.ImportRow(row)
                GoTo nextrow
            Else
                status = row.Item("Status")
            End If

            If visit IsNot Nothing Then
                'check if visitdate matches orginal date
                If row.Item("StartDateTime") Is DBNull.Value Then
                    row("Failure Reason") = "No visit start date"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                Else
                    startDate = row.Item("StartDateTime")
                End If

                If CDate(startDate).Date <> visit.StartDateTime.Date Then
                    row("Failure Reason") = "Start date does not match"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                End If

                If visit.StatusEnumID <> Entity.Sys.Enums.VisitStatus.Scheduled Then
                    row("Failure Reason") = "Visit Status has already been updated"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                End If

                Dim outcomeID As Integer
                Select Case Entity.Sys.Helper.MakeIntegerValid(status)
                    Case Entity.Sys.Enums.JobImportStatus.DidNotAttend 'engineer hasn't attended
                        outcomeID = CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Could_Not_Start)
                        row("Failure Reason") = "Please manually rescheduled"
                        FailedImports.ImportRow(row)
                        GoTo nextrow

                    Case Entity.Sys.Enums.JobImportStatus.Carded 'carded
                        outcomeID = CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Carded)
                    Case Entity.Sys.Enums.JobImportStatus.Complete 'complete
                        outcomeID = CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Complete)
                    Case Else
                        row("Failure Reason") = "Invalid status"
                        FailedImports.ImportRow(row)
                        GoTo nextrow
                End Select

                If Not DB.EngineerVisits.EngineerVisits_UpdateStatus(
                visit.EngineerVisitID, CInt(Entity.Sys.Enums.VisitStatus.Uploaded), outcomeID) Then

                    row("Failure Reason") = "Failed to update status"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                End If
            Else
                row("Failure Reason") = "Cannot find any visits"
                FailedImports.ImportRow(row)
            End If
nextrow:
            MoveProgressOn()
        Next

        MoveProgressOn(True)
        ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.lblMessages.Visible = False

        If FailedImports.Rows.Count > 0 Then
            dgFailedImports.DataSource = FailedImports
        End If
    End Sub

    Private Sub ImportJobs(ByVal data As DataSet, ByVal jobImportTypeID As Integer)
        data.Tables(0).Columns.Add("Failure Reason")
        FailedImports = data.Tables(0).Clone

        Me.pbStatus.Maximum = data.Tables(0).Rows.Count
        For i As Integer = 0 To data.Tables(0).Rows.Count - 1
            Dim row As DataRow = data.Tables(0).Rows(i)
            Dim uprn As String = String.Empty

            If row.Item("UPRN") Is DBNull.Value Then
                row("Failure Reason") = "No uprn"
                FailedImports.ImportRow(row)
                GoTo nextrow
            Else
                uprn = row.Item("UPRN")
            End If

            Dim site As Site = Nothing
            For Each customer As Customer In Customers
                If site Is Nothing Then
                    site = DB.Sites.Get(uprn, SiteSQL.GetBy.Uprn, customer.CustomerID)
                End If
            Next
            If site Is Nothing Then
                row("Failure Reason") = "Cannot find site"
                FailedImports.ImportRow(row)
                MoveProgressOn()
            Else
                If DB.JobImports.JobImport_Exist(site.SiteID, jobImportTypeID) Then
                    row("Failure Reason") = "Site and job exists in system"
                    FailedImports.ImportRow(row)
                    MoveProgressOn()
                End If

                Dim jobImport As New JobImport.JobImport
                With jobImport
                    .SetSiteID = site.SiteID
                    .SetUPRN = site.PolicyNumber
                    .SetJobImportTypeID = jobImportTypeID
                    .DateAdded = Now
                End With

                jobImport = DB.JobImports.JobImport_Insert(jobImport)
                If Not jobImport.Exists Then
                    row("Failure Reason") = "Database failure"
                    FailedImports.ImportRow(row)
                End If

                If chkCreateJob.Checked AndAlso Helper.MakeIntegerValid(Engineer?.EngineerID) > 0 Then
                    Dim job As Jobs.Job = CreateJob(site, jobImportTypeID)
                    If Helper.MakeIntegerValid(job?.JobID) > 0 Then
                        DB.ExecuteWithOutReturn("UPDATE tblJobImport SET JobID = " & job.JobID & ", JobNumber = '" & job.JobNumber & "', Status = " & 0 & ", BookedVisit = '" & Format(dtpVisitDate.Value, "yyyy-MM-dd") & "', Letter1 = '" & Format(Now, "yyyy-MM-dd") & "' WHERE JobImportID = " & jobImport.JobImportID & "")
                    End If
                End If
            End If
nextrow:
            MoveProgressOn()
        Next

        MoveProgressOn(True)
        ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.lblMessages.Visible = False

        If FailedImports.Rows.Count > 0 Then
            dgFailedImports.DataSource = FailedImports
            btnExportFailed.Visible = True
        End If
    End Sub

    Public Function CreateJob(ByVal oSite As Site, ByVal jobImportTypeId As Integer) As Jobs.Job
        Dim theVisitDate As DateTime

        Dim jobImportType As JobImport.JobImportType = DB.JobImports.JobImportType_Get(jobImportTypeId)
        If jobImportType Is Nothing Then Return Nothing

        Dim SORdt As DataTable = DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID).Table
        Dim visittime As Integer = 0

        Dim JobNumber As New JobNumber
        JobNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout)
        Dim job As New Jobs.Job With {
            .SetPropertyID = oSite.SiteID,
            .SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Callout),
            .SetJobTypeID = jobImportType.JobTypeID,
            .SetStatusEnumID = CInt(Enums.JobStatus.Open),
            .SetCreatedByUserID = loggedInUser.UserID,
            .SetFOC = True,
            .SetJobCreationType = CInt(Enums.JobCreationType.JobManager),
            .SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber,
            .SetPONumber = "",
            .SetQuoteID = 0,
            .SetContractID = 0
        }

        Dim jobOfWork As New JobOfWorks.JobOfWork

        'Get service priority
        Dim servicePriority As Integer = 0
        Dim rows As Array = DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'Dayworks'")
        If rows.Length = 0 Then
            Dim oPickList As New PickLists.PickList
            oPickList.SetName = "Dayworks"
            oPickList.SetEnumTypeID = CInt(Enums.PickListTypes.JOWPriority)
            servicePriority = DB.Picklists.Insert(oPickList)
        Else
            servicePriority = CType(rows(0), DataRow).Item("ManagerID")
        End If

        '  INSERT JOB ITEM
        jobOfWork.SetPONumber = ""
        jobOfWork.SetPriority = servicePriority
        If Not jobOfWork.Priority = 0 Then
            jobOfWork.PriorityDateSet = Now
        End If
        jobOfWork.IgnoreExceptionsOnSetMethods = True

        For Each sorRow As DataRow In SORdt.Rows
            Dim customerSors As DataTable = DB.CustomerScheduleOfRate.Exists(sorRow("ScheduleOfRatesCategoryID"), sorRow("Description"), sorRow("Code"), oSite.CustomerID)
            Dim customerSorId As Integer = 0
            If customerSors.Rows.Count > 0 Then customerSorId = Helper.MakeIntegerValid(customerSors.Rows(0).Item(0))

            If Not customerSorId > 0 Then
                Dim customerSor As New CustomerScheduleOfRates.CustomerScheduleOfRate With {
                    .SetCode = sorRow("Code"),
                    .SetDescription = sorRow("Description"),
                    .SetPrice = sorRow("Price"),
                    .SetScheduleOfRatesCategoryID = sorRow("ScheduleOfRatesCategoryID"),
                    .SetTimeInMins = sorRow("TimeInMins"),
                    .SetCustomerID = oSite.CustomerID
                }
                customerSorId = DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID
                DB.CustomerScheduleOfRate.Delete(customerSorId)
            End If

            visittime = sorRow("TimeInMins")

            Dim jobItem As New JobItems.JobItem
            jobItem.IgnoreExceptionsOnSetMethods = True
            jobItem.SetSummary = sorRow("Description")
            jobItem.SetQty = 1
            jobItem.SetRateID = customerSorId
            jobItem.SetSystemLinkID = CInt(Enums.TableNames.tblCustomerScheduleOfRate)
            jobOfWork.JobItems.Add(jobItem)
        Next

        Dim engineerVisit As New EngineerVisits.EngineerVisit
        engineerVisit.IgnoreExceptionsOnSetMethods = True
        engineerVisit.SetEngineerID = 0
        engineerVisit.SetEngineerID = Engineer.EngineerID
        engineerVisit.SetNotesToEngineer = jobImportType.Name

        engineerVisit.StartDateTime = dtpVisitDate.Value
        engineerVisit.EndDateTime = dtpVisitDate.Value.AddHours(1)
        engineerVisit.SetStatusEnumID = CInt(Enums.VisitStatus.Scheduled)
        engineerVisit.DueDate = theVisitDate
        engineerVisit.SetAMPM = "AM"
        engineerVisit.SetVisitNumber = 1

        jobOfWork.EngineerVisits.Add(engineerVisit)
        job.JobOfWorks.Add(jobOfWork)
        job = DB.Job.Insert(job)
        Return job
    End Function

    Private Sub Export()
        ExportHelper.Export(FailedImports, "Job Imports", Enums.ExportType.XLS)
        FailedImports.Clear()
        btnExportFailed.Visible = False
    End Sub

    Public Sub MoveProgressOn(Optional ByVal toMaximum As Boolean = False)
        Try
            If toMaximum Then
                Me.pbStatus.Value = Me.pbStatus.Maximum
                Me.lblProgress.Text = "100%"
            Else
                Me.pbStatus.Value += 1
                Me.lblProgress.Text = Math.Floor((Me.pbStatus.Value / Me.pbStatus.Maximum) * 100) & "%"
            End If
            Application.DoEvents()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub KillInstances(ByVal app As Excel.Application)
        On Error Resume Next

        app.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(app)
        app = Nothing
        GC.Collect()

        Dim mp As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        Dim p As System.Diagnostics.Process
        For Each p In mp
            If p.Responding Then
                If p.MainWindowTitle = "" Then
                    p.Kill()
                End If
            Else
                p.Kill()
            End If
        Next p

        On Error GoTo - 1
    End Sub

    Private Sub radBtnJob_CheckedChanged(sender As Object, e As EventArgs) Handles radBtnJob.CheckedChanged, radBtnJobStatus.CheckedChanged
        lblJobType.Visible = radBtnJob.Checked
        cboJobType.Visible = radBtnJob.Checked
        txtCustomer.Visible = radBtnJob.Checked
        btnFindCustomer.Visible = radBtnJob.Checked
        lblCustomer.Visible = radBtnJob.Checked
        lblEngineer.Visible = radBtnJob.Checked
        lblVisitDate.Visible = radBtnJob.Checked
        dtpVisitDate.Visible = radBtnJob.Checked
        txtEngineer.Visible = radBtnJob.Checked
        btnFindEngineer.Visible = radBtnJob.Checked
    End Sub

    Private Sub btnFindCustomer_Click(sender As Object, e As EventArgs) Handles btnFindCustomer.Click
        Dim frmFindCust As New FRMFindCustomers
        frmFindCust.ShowDialog()

        Customers = New List(Of Customer)
        Dim dvCustomers As DataView = frmFindCust.CustomerDataView
        Dim drCustomers() As DataRow =
                (From row In dvCustomers.Table.AsEnumerable()
                 Where row.Field(Of Boolean)("Include") = True
                 Select row).ToArray()

        Dim cIds As List(Of Integer) = (From dr In drCustomers Select (Entity.Sys.Helper.MakeIntegerValid(dr("CustomerID")))).ToList()

        For Each cId As Integer In cIds
            Customers.Add(DB.Customer.Customer_Get(cId))
        Next
        Customers = Customers
    End Sub

    Private Sub chkCreateJob_Click(sender As Object, e As EventArgs) Handles chkCreateJob.Click
        chkCreateJob.Checked = Not chkCreateJob.Checked
        dtpVisitDate.Enabled = chkCreateJob.Checked
        btnFindEngineer.Enabled = chkCreateJob.Checked
    End Sub

    Private Sub btnFindEngineer_Click(sender As Object, e As EventArgs) Handles btnFindEngineer.Click
        Dim ID As Integer = FindRecord(Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            Engineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

#End Region

End Class