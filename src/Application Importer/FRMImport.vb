Imports FSM.Entity.Customers
Imports FSM.Entity.Sites
Imports FSM.Entity.Sys

Public Class FRMImport : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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
    Private components As ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents grpImporter As GroupBox

    Friend WithEvents txtFileLocation As TextBox
    Friend WithEvents btnFindFile As Button
    Friend WithEvents btnTemplateFile As LinkLabel
    Friend WithEvents btnImport As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents pbStatus As ProgressBar
    Friend WithEvents lblCustomer As Label
    Friend WithEvents lblFile As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents btnFindCustomer As Button
    Friend WithEvents lblMessages As Label
    Friend WithEvents grpErrors As GroupBox
    Friend WithEvents dgErrors As DataGrid
    Friend WithEvents lblProgress As Label

    <Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpImporter = New System.Windows.Forms.GroupBox()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnFindFile = New System.Windows.Forms.Button()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.btnTemplateFile = New System.Windows.Forms.LinkLabel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.grpErrors = New System.Windows.Forms.GroupBox()
        Me.dgErrors = New System.Windows.Forms.DataGrid()
        Me.grpImporter.SuspendLayout()
        Me.grpErrors.SuspendLayout()
        CType(Me.dgErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpImporter
        '
        Me.grpImporter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpImporter.Controls.Add(Me.lblFile)
        Me.grpImporter.Controls.Add(Me.txtCustomer)
        Me.grpImporter.Controls.Add(Me.btnFindCustomer)
        Me.grpImporter.Controls.Add(Me.lblCustomer)
        Me.grpImporter.Controls.Add(Me.btnImport)
        Me.grpImporter.Controls.Add(Me.btnFindFile)
        Me.grpImporter.Controls.Add(Me.txtFileLocation)
        Me.grpImporter.Location = New System.Drawing.Point(8, 40)
        Me.grpImporter.Name = "grpImporter"
        Me.grpImporter.Size = New System.Drawing.Size(896, 115)
        Me.grpImporter.TabIndex = 3
        Me.grpImporter.TabStop = False
        Me.grpImporter.Text = "Import"
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(6, 52)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(31, 13)
        Me.lblFile.TabIndex = 13
        Me.lblFile.Text = "File:"
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Location = New System.Drawing.Point(86, 20)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(766, 21)
        Me.txtCustomer.TabIndex = 12
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.Location = New System.Drawing.Point(858, 20)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 11
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = True
        '
        'lblCustomer
        '
        Me.lblCustomer.AutoSize = True
        Me.lblCustomer.Location = New System.Drawing.Point(6, 23)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(68, 13)
        Me.lblCustomer.TabIndex = 9
        Me.lblCustomer.Text = "Customer:"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.Location = New System.Drawing.Point(826, 84)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(64, 23)
        Me.btnImport.TabIndex = 7
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnFindFile
        '
        Me.btnFindFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindFile.Location = New System.Drawing.Point(858, 49)
        Me.btnFindFile.Name = "btnFindFile"
        Me.btnFindFile.Size = New System.Drawing.Size(32, 23)
        Me.btnFindFile.TabIndex = 5
        Me.btnFindFile.Text = "..."
        Me.btnFindFile.UseVisualStyleBackColor = True
        '
        'txtFileLocation
        '
        Me.txtFileLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileLocation.Location = New System.Drawing.Point(86, 49)
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.ReadOnly = True
        Me.txtFileLocation.Size = New System.Drawing.Size(766, 21)
        Me.txtFileLocation.TabIndex = 4
        '
        'btnTemplateFile
        '
        Me.btnTemplateFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTemplateFile.Location = New System.Drawing.Point(816, 8)
        Me.btnTemplateFile.Name = "btnTemplateFile"
        Me.btnTemplateFile.Size = New System.Drawing.Size(88, 23)
        Me.btnTemplateFile.TabIndex = 1
        Me.btnTemplateFile.TabStop = True
        Me.btnTemplateFile.Text = "Template File"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(848, 624)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 9
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
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
        Me.lblMessages.Size = New System.Drawing.Size(900, 19)
        Me.lblMessages.TabIndex = 12
        Me.lblMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMessages.Visible = False
        '
        'grpErrors
        '
        Me.grpErrors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpErrors.Controls.Add(Me.dgErrors)
        Me.grpErrors.Location = New System.Drawing.Point(8, 161)
        Me.grpErrors.Name = "grpErrors"
        Me.grpErrors.Size = New System.Drawing.Size(896, 453)
        Me.grpErrors.TabIndex = 14
        Me.grpErrors.TabStop = False
        Me.grpErrors.Text = "Errors"
        '
        'dgErrors
        '
        Me.dgErrors.DataMember = ""
        Me.dgErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgErrors.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgErrors.Location = New System.Drawing.Point(3, 17)
        Me.dgErrors.Name = "dgErrors"
        Me.dgErrors.Size = New System.Drawing.Size(890, 433)
        Me.dgErrors.TabIndex = 2
        '
        'FRMImport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(912, 654)
        Me.Controls.Add(Me.grpErrors)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnTemplateFile)
        Me.Controls.Add(Me.grpImporter)
        Me.MinimumSize = New System.Drawing.Size(920, 688)
        Me.Name = "FRMImport"
        Me.Text = "Site Importer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpImporter, 0)
        Me.Controls.SetChildIndex(Me.btnTemplateFile, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.pbStatus, 0)
        Me.Controls.SetChildIndex(Me.lblProgress, 0)
        Me.Controls.SetChildIndex(Me.lblMessages, 0)
        Me.Controls.SetChildIndex(Me.grpErrors, 0)
        Me.grpImporter.ResumeLayout(False)
        Me.grpImporter.PerformLayout()
        Me.grpErrors.ResumeLayout(False)
        CType(Me.dgErrors, System.ComponentModel.ISupportInitialize).EndInit()
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

    Private _customer As Customer

    Private Property Customer() As Customer
        Get
            Return _customer
        End Get
        Set(value As Customer)
            _customer = value
            If Customer IsNot Nothing Then
                txtCustomer.Text = Customer.Name
            Else
                txtCustomer.Text = String.Empty
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMImport_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnTemplateFile_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles btnTemplateFile.LinkClicked
        Dim dlg As FolderBrowserDialog
        Dim oExcel As Excel.Application
        Try
            Cursor.Current = Cursors.WaitCursor

            dlg = New FolderBrowserDialog
            If dlg.ShowDialog = DialogResult.OK Then
                oExcel = New Excel.Application
                oExcel.Workbooks.Add(Application.StartupPath & "\Templates\SiteImporter.xlsx")
                If IO.File.Exists(dlg.SelectedPath & "\SiteImporter.xlsx") Then
                    IO.File.Delete(dlg.SelectedPath & "\SiteImporter.xlsx")
                End If
                oExcel.Workbooks.Item(1).SaveAs(dlg.SelectedPath & "\SiteImporter.xlsx")

                ShowMessage("File downloaded to " & dlg.SelectedPath & "\SiteImporter.xlsx", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ShowMessage("Template could not be saved : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dlg.Dispose()
            KillInstances(oExcel)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnFindFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFindFile.Click
        LoadData()
    End Sub

    Private Sub btnImport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImport.Click
        Import()
    End Sub

    Private Sub btnSupplier_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFindCustomer.Click
        FindCustomer()
    End Sub

#End Region

#Region "Functions"

    Private Sub LoadData()
        Dim dlg As OpenFileDialog
        Dim oExcel As Excel.Application
        Try
            Cursor.Current = Cursors.WaitCursor

            Me.btnFindFile.Enabled = False
            Me.btnImport.Enabled = False
            Me.txtFileLocation.Text = ""

            dlg = New OpenFileDialog
            If dlg.ShowDialog = DialogResult.OK Then
                Dim tempfile As New IO.FileInfo(dlg.FileName)

                'Is it an excel file?
                If tempfile.Extension = ".xls" Or tempfile.Extension = ".xlsx" Then
                    File = tempfile
                    'Is an Excel file
                    Me.txtFileLocation.Text = File.FullName
                    Me.btnImport.Enabled = True
                Else
                    ShowMessage("File must be .xls, or .xlsx.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            Me.txtFileLocation.Text = ""
            Me.btnImport.Enabled = False
            ShowMessage("File data could not be loaded : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dlg.Dispose()
            Me.btnFindFile.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Import()
        If Customer Is Nothing Then
            ShowMessage("Please select a customer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim oExcel As Excel.Application

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.btnFindFile.Enabled = False
            Me.btnImport.Enabled = False
            Me.pbStatus.Value = 0

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
            Dim adapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter
            Dim data As New DataSet

            adapter.SelectCommand = New OleDb.OleDbCommand(strCom, conn)
            data.Clear()
            adapter.Fill(data)
            data.Tables(0).Columns.Add("Failure Reason")
            FailedImports = data.Tables(0).Clone

            Me.pbStatus.Maximum = data.Tables(0).Rows.Count
            For i As Integer = 0 To data.Tables(0).Rows.Count - 1
                Dim row As DataRow = data.Tables(0).Rows(i)
                Dim uprn As String = String.Empty
                Dim address1 As String = String.Empty
                Dim address2 As String = String.Empty
                Dim address3 As String = String.Empty
                Dim postcode As String = String.Empty
                Dim fuel As String = String.Empty
                Dim lsd As DateTime = Nothing
                Dim firstName As String = String.Empty
                Dim lastName As String = String.Empty
                Dim telNo As String = String.Empty
                Dim mobNo As String = String.Empty
                Dim email As String = String.Empty
                Dim buildDate As DateTime = Nothing
                Dim warrantyPeriodInMonths As Integer = 0

                uprn = Helper.MakeStringValid(row("UPRN"))

                If row("Address1") Is DBNull.Value Then
                    row("Failure Reason") = "No address 1"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                Else
                    address1 = Helper.MakeStringValid(row("Address1"))
                End If
                address2 = Helper.MakeStringValid(row("Address2"))
                address3 = Helper.MakeStringValid(row("Address3"))

                If row("Postcode") Is DBNull.Value Then
                    row("Failure Reason") = "No postcode"
                    FailedImports.ImportRow(row)
                    GoTo nextrow
                Else
                    postcode = Helper.ConvertToPostcode(row("Postcode"))

                    If Not postcode.Contains("-") Or postcode.Length > 9 Then
                        row("Failure Reason") = "Invalid postocde format"
                        FailedImports.ImportRow(row)
                        GoTo nextrow
                    End If
                End If
                lsd = Helper.MakeDateTimeValid(row("LastServiceDate"))
                fuel = Helper.MakeStringValid(row("Fuel"))
                firstName = Helper.MakeStringValid(row("FirstName"))
                lastName = Helper.MakeStringValid(row("LastName"))
                telNo = Helper.MakeStringValid(row("TelNo"))
                mobNo = Helper.MakeStringValid(row("MobNo"))
                email = Helper.MakeStringValid(row("Email"))
                buildDate = Helper.MakeDateTimeValid(row("BuildDate"))
                warrantyPeriodInMonths = Helper.MakeIntegerValid(row("WarrantyPeriodInMonths"))

                Dim name As String = String.Empty
                If Not String.IsNullOrWhiteSpace(firstName) Then name = firstName & " "
                If Not String.IsNullOrWhiteSpace(lastName) Then name += lastName

                Dim site As Site = DB.Sites.Get(uprn, SiteSQL.GetBy.Uprn, Customer.CustomerID)

                If site IsNot Nothing Then Continue For

                site = New Site
                With site
                    .IgnoreExceptionsOnSetMethods = True
                    .SetPolicyNumber = uprn
                    .SetAddress1 = address1
                    .SetAddress2 = address2
                    .SetAddress3 = address3
                    .SetPostcode = postcode
                    .LastServiceDate = lsd
                    .SetSiteFuel = fuel
                    .SetCustomerID = Customer.CustomerID
                    .SetRegionID = Customer.RegionID
                    .SetCommercialDistrict = 0
                    .SetEngineerID = 0
                    .SetHeadOffice = False
                    .SetNoMarketing = False
                    .SetNoService = False
                    .SetOnStop = False
                    .SetPoNumReqd = False
                    .SetSolidFuel = False
                    .SetFirstName = firstName
                    .SetSurname = lastName
                    .SetTelephoneNum = telNo
                    .SetFaxNum = mobNo
                    .SetEmailAddress = email
                    If Not String.IsNullOrWhiteSpace(name) Then .SetName = name
                    If buildDate <> Nothing Then .BuildDate = buildDate
                    .SetWarrantyPeriodInMonths = warrantyPeriodInMonths
                End With

                site = DB.Sites.Insert(site)
                If lsd = Nothing Then GoTo nextrow

                DB.Sites.Site_UpdateLastServiceDate(site.SiteID, lsd, lsd, True)
                Dim siteFuel As New SiteFuel
                With siteFuel
                    .SetSiteID = site.SiteID
                    .LastServiceDate = lsd
                    .ActualServiceDate = lsd
                End With

                If Not String.IsNullOrWhiteSpace(fuel) Then
                    Select Case True
                        Case fuel.ToLower.Contains("gas")
                            siteFuel.SetFuelID = CInt(Enums.FuelTypes.NatGas)
                        Case fuel.ToLower.Contains("solid")
                            siteFuel.SetFuelID = CInt(Enums.FuelTypes.SolidFuel)
                        Case fuel.ToLower.Contains("oil")
                            siteFuel.SetFuelID = CInt(Enums.FuelTypes.Oil)
                        Case fuel.ToLower.Contains("eletric")
                            siteFuel.SetFuelID = CInt(Enums.FuelTypes.Electric)
                    End Select
                End If
                siteFuel.SetSiteFuelChargeID = 0
                DB.Sites.SiteFuel_Update(siteFuel)
nextrow:
                MoveProgressOn()
            Next

            MoveProgressOn(True)
            ShowMessage("Data has been imported", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.lblMessages.Visible = False

            If FailedImports.Rows.Count > 0 Then
                dgErrors.DataSource = FailedImports
            End If
        Catch ex As Exception
            ShowMessage("File data could not be imported : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            KillInstances(oExcel)
            File = Nothing
            Me.txtFileLocation.Text = ""

            If FailedImports.Rows.Count > 0 Then
                btnExport.Visible = True
            End If

            Me.pbStatus.Value = Me.pbStatus.Maximum
            Me.btnFindFile.Enabled = True
            Me.btnImport.Enabled = True
            Me.pbStatus.Value = 0
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Export()
        If FailedImports.Rows.Count > 0 Then
            ExportHelper.Export(FailedImports, "Failed Sites", Enums.ExportType.XLS)
            FailedImports.Clear()
        End If
    End Sub

    Public Sub MoveProgressOn(Optional ByVal toMaximum As Boolean = False)
        If toMaximum Then
            Me.pbStatus.Value = Me.pbStatus.Maximum
            Me.lblProgress.Text = "100%"
        Else
            Me.pbStatus.Value += 1
            Me.lblProgress.Text = Math.Floor((Me.pbStatus.Value / Me.pbStatus.Maximum) * 100) & "%"
        End If
        Application.DoEvents()
    End Sub

    Private Sub FindCustomer()
        Dim id As Integer = FindRecord(Enums.TableNames.tblCustomer)
        If id > 0 Then
            Customer = DB.Customer.Customer_Get(id)
        End If
    End Sub

    Private Sub KillInstances(ByVal app As Excel.Application)
        On Error Resume Next

        app.Quit()
        Runtime.InteropServices.Marshal.ReleaseComObject(app)
        app = Nothing
        GC.Collect()

        Dim mp As Process() = Process.GetProcessesByName("EXCEL")
        Dim p As Process
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

#End Region

End Class