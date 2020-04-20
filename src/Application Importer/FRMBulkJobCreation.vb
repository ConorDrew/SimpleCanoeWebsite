Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports FSM.Entity
Imports FSM.Entity.Customers
Imports FSM.Entity.Engineers
Imports FSM.Entity.Sites
Imports FSM.Entity.Sys

Public Class FRMBulkJobCreation : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboJobType, DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
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
    Friend WithEvents lblJobType As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents btnFindCustomer As Button
    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblVisitDate As Label
    Friend WithEvents dtpVisitDate As DateTimePicker
    Friend WithEvents txtEngineer As TextBox
    Friend WithEvents btnFindEngineer As Button
    Friend WithEvents lblEngineer As Label
    Friend WithEvents txtNotes As RichTextBox
    Friend WithEvents lblVisitNotes As Label
    Friend WithEvents lblProgress As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpExcelFile = New System.Windows.Forms.GroupBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.dtpVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.btnFindEngineer = New System.Windows.Forms.Button()
        Me.lblEngineer = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.lblCustomer = New System.Windows.Forms.Label()
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
        Me.lblVisitNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.grpExcelFile.SuspendLayout()
        Me.grpFailedImports.SuspendLayout()
        CType(Me.dgFailedImports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpExcelFile
        '
        Me.grpExcelFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpExcelFile.Controls.Add(Me.txtNotes)
        Me.grpExcelFile.Controls.Add(Me.lblVisitNotes)
        Me.grpExcelFile.Controls.Add(Me.lblVisitDate)
        Me.grpExcelFile.Controls.Add(Me.dtpVisitDate)
        Me.grpExcelFile.Controls.Add(Me.txtEngineer)
        Me.grpExcelFile.Controls.Add(Me.btnFindEngineer)
        Me.grpExcelFile.Controls.Add(Me.lblEngineer)
        Me.grpExcelFile.Controls.Add(Me.txtCustomer)
        Me.grpExcelFile.Controls.Add(Me.btnFindCustomer)
        Me.grpExcelFile.Controls.Add(Me.lblCustomer)
        Me.grpExcelFile.Controls.Add(Me.cboJobType)
        Me.grpExcelFile.Controls.Add(Me.lblJobType)
        Me.grpExcelFile.Controls.Add(Me.lblFile)
        Me.grpExcelFile.Controls.Add(Me.btnImport)
        Me.grpExcelFile.Controls.Add(Me.btnFindExcelFile)
        Me.grpExcelFile.Controls.Add(Me.txtExcelFile)
        Me.grpExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpExcelFile.Location = New System.Drawing.Point(8, 40)
        Me.grpExcelFile.Name = "grpExcelFile"
        Me.grpExcelFile.Size = New System.Drawing.Size(896, 159)
        Me.grpExcelFile.TabIndex = 3
        Me.grpExcelFile.TabStop = False
        Me.grpExcelFile.Text = "Select data file to import"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.AutoSize = True
        Me.lblVisitDate.Location = New System.Drawing.Point(9, 60)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(67, 13)
        Me.lblVisitDate.TabIndex = 45
        Me.lblVisitDate.Text = "Visit Date:"
        '
        'dtpVisitDate
        '
        Me.dtpVisitDate.Location = New System.Drawing.Point(89, 54)
        Me.dtpVisitDate.Name = "dtpVisitDate"
        Me.dtpVisitDate.Size = New System.Drawing.Size(151, 21)
        Me.dtpVisitDate.TabIndex = 44
        '
        'txtEngineer
        '
        Me.txtEngineer.Location = New System.Drawing.Point(324, 54)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(168, 21)
        Me.txtEngineer.TabIndex = 43
        '
        'btnFindEngineer
        '
        Me.btnFindEngineer.Location = New System.Drawing.Point(498, 54)
        Me.btnFindEngineer.Name = "btnFindEngineer"
        Me.btnFindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindEngineer.TabIndex = 42
        Me.btnFindEngineer.Text = "..."
        Me.btnFindEngineer.UseVisualStyleBackColor = True
        '
        'lblEngineer
        '
        Me.lblEngineer.AutoSize = True
        Me.lblEngineer.Location = New System.Drawing.Point(256, 59)
        Me.lblEngineer.Name = "lblEngineer"
        Me.lblEngineer.Size = New System.Drawing.Size(62, 13)
        Me.lblEngineer.TabIndex = 41
        Me.lblEngineer.Text = "Engineer:"
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Location = New System.Drawing.Point(616, 56)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(236, 21)
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
        Me.lblCustomer.Location = New System.Drawing.Point(536, 59)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(74, 13)
        Me.lblCustomer.TabIndex = 38
        Me.lblCustomer.Text = "Customers:"
        '
        'cboJobType
        '
        Me.cboJobType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJobType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobType.Location = New System.Drawing.Point(653, 20)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(158, 21)
        Me.cboJobType.TabIndex = 35
        Me.cboJobType.Tag = "Site.RegionID"
        '
        'lblJobType
        '
        Me.lblJobType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblJobType.AutoSize = True
        Me.lblJobType.Location = New System.Drawing.Point(585, 23)
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
        Me.btnFindExcelFile.Location = New System.Drawing.Point(539, 18)
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
        Me.txtExcelFile.Size = New System.Drawing.Size(487, 21)
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
        Me.grpFailedImports.Location = New System.Drawing.Point(8, 205)
        Me.grpFailedImports.Name = "grpFailedImports"
        Me.grpFailedImports.Size = New System.Drawing.Size(896, 377)
        Me.grpFailedImports.TabIndex = 15
        Me.grpFailedImports.TabStop = False
        Me.grpFailedImports.Text = "Failed Jobs"
        '
        'dgFailedImports
        '
        Me.dgFailedImports.DataMember = ""
        Me.dgFailedImports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFailedImports.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgFailedImports.Location = New System.Drawing.Point(3, 17)
        Me.dgFailedImports.Name = "dgFailedImports"
        Me.dgFailedImports.Size = New System.Drawing.Size(890, 357)
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
        'lblVisitNotes
        '
        Me.lblVisitNotes.AutoSize = True
        Me.lblVisitNotes.Location = New System.Drawing.Point(9, 97)
        Me.lblVisitNotes.Name = "lblVisitNotes"
        Me.lblVisitNotes.Size = New System.Drawing.Size(72, 13)
        Me.lblVisitNotes.TabIndex = 46
        Me.lblVisitNotes.Text = "Visit Notes:"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(89, 94)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(801, 50)
        Me.txtNotes.TabIndex = 47
        Me.txtNotes.Text = ""
        '
        'FRMBulkJobCreation
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
        Me.Name = "FRMBulkJobCreation"
        Me.Text = "Bulk Create Jobs"
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

    Private Sub FRMBulkJobCreation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Function IsFormValid() As Boolean
        If Customers Is Nothing Then
            ShowMessage("Please select a customer!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Helper.MakeIntegerValid(Engineer?.EngineerID) = 0 Then
            ShowMessage("Please select a Engineer!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboJobType) = 0) Then
            ShowMessage("Please select a job type!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Private Sub Import()

        If Not IsFormValid() Then Exit Sub

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
            Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(strCon)
            Dim adapter As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
            Dim data As New DataSet

            adapter.SelectCommand = New System.Data.OleDb.OleDbCommand(strCom, conn)
            data.Clear()
            adapter.Fill(data)

            ImportJobs(data)
        Catch ex As Exception
            ShowMessage("File data could not be imported : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            KillInstances(oExcel)

            Dim filePath As String = TheSystem.Configuration.DocumentsLocation & "BulkJobCreation\"

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

    Private Sub ImportJobs(ByVal data As DataSet)
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
                CreateJob(site)
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

    Public Sub CreateJob(ByVal oSite As Site)

        Dim JobNumber As New JobNumber
        JobNumber = DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout)
        Dim job As New Jobs.Job With {
            .SetPropertyID = oSite.SiteID,
            .SetJobDefinitionEnumID = CInt(Enums.JobDefinition.Callout),
            .SetJobTypeID = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboJobType)),
            .SetStatusEnumID = CInt(Enums.JobStatus.Open),
            .SetCreatedByUserID = loggedInUser.UserID,
            .SetFOC = True,
            .SetJobCreationType = CInt(Enums.JobCreationType.JobManager),
            .SetJobNumber = JobNumber.Prefix & JobNumber.JobNumber,
            .SetPONumber = "",
            .SetQuoteID = 0,
            .SetContractID = 0
        }

        Dim jobOfWork As New JobOfWorks.JobOfWork With {
            .SetPONumber = "",
            .SetPriority = 0
        }

        Dim engineerVisit As New EngineerVisits.EngineerVisit With {
            .IgnoreExceptionsOnSetMethods = True,
            .SetEngineerID = Engineer.EngineerID,
            .SetNotesToEngineer = txtNotes.Text.Trim(),
            .StartDateTime = dtpVisitDate.Value,
            .EndDateTime = dtpVisitDate.Value.AddHours(1),
            .SetStatusEnumID = CInt(Enums.VisitStatus.Scheduled),
            .SetAMPM = "AM",
            .SetVisitNumber = 1
        }

        jobOfWork.EngineerVisits.Add(engineerVisit)
        job.JobOfWorks.Add(jobOfWork)
        job = DB.Job.Insert(job)
    End Sub

    Private Sub Export()
        ExportHelper.Export(FailedImports, "Jobs", Enums.ExportType.XLS)
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

    Private Sub btnFindEngineer_Click(sender As Object, e As EventArgs) Handles btnFindEngineer.Click
        Dim ID As Integer = FindRecord(Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            Engineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

#End Region

End Class