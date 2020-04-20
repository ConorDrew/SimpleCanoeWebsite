Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection

Public Class FRMFleetVanImporter : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents grpFailedImports As GroupBox
    Friend WithEvents dgFailedImports As DataGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpExcelFile = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnFindExcelFile = New System.Windows.Forms.Button()
        Me.txtExcelFile = New System.Windows.Forms.TextBox()
        Me.grpFailedImports = New System.Windows.Forms.GroupBox()
        Me.dgFailedImports = New System.Windows.Forms.DataGrid()
        Me.grpExcelFile.SuspendLayout()
        Me.grpFailedImports.SuspendLayout()
        CType(Me.dgFailedImports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpExcelFile
        '
        Me.grpExcelFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpExcelFile.Controls.Add(Me.Label2)
        Me.grpExcelFile.Controls.Add(Me.btnImport)
        Me.grpExcelFile.Controls.Add(Me.btnFindExcelFile)
        Me.grpExcelFile.Controls.Add(Me.txtExcelFile)
        Me.grpExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpExcelFile.Location = New System.Drawing.Point(8, 40)
        Me.grpExcelFile.Name = "grpExcelFile"
        Me.grpExcelFile.Size = New System.Drawing.Size(655, 64)
        Me.grpExcelFile.TabIndex = 3
        Me.grpExcelFile.TabStop = False
        Me.grpExcelFile.Text = "Select file to import"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "File:"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImport.Location = New System.Drawing.Point(574, 17)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(64, 23)
        Me.btnImport.TabIndex = 7
        Me.btnImport.Text = "Import"
        '
        'btnFindExcelFile
        '
        Me.btnFindExcelFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFindExcelFile.Location = New System.Drawing.Point(536, 17)
        Me.btnFindExcelFile.Name = "btnFindExcelFile"
        Me.btnFindExcelFile.Size = New System.Drawing.Size(32, 23)
        Me.btnFindExcelFile.TabIndex = 5
        Me.btnFindExcelFile.Text = "..."
        '
        'txtExcelFile
        '
        Me.txtExcelFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExcelFile.Location = New System.Drawing.Point(50, 19)
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.ReadOnly = True
        Me.txtExcelFile.Size = New System.Drawing.Size(480, 21)
        Me.txtExcelFile.TabIndex = 4
        '
        'grpFailedImports
        '
        Me.grpFailedImports.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFailedImports.Controls.Add(Me.dgFailedImports)
        Me.grpFailedImports.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpFailedImports.Location = New System.Drawing.Point(8, 110)
        Me.grpFailedImports.Name = "grpFailedImports"
        Me.grpFailedImports.Size = New System.Drawing.Size(655, 477)
        Me.grpFailedImports.TabIndex = 14
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
        Me.dgFailedImports.Size = New System.Drawing.Size(649, 457)
        Me.dgFailedImports.TabIndex = 45
        '
        'FRMFleetVanImporter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(671, 599)
        Me.Controls.Add(Me.grpFailedImports)
        Me.Controls.Add(Me.grpExcelFile)
        Me.Name = "FRMFleetVanImporter"
        Me.Text = "Fleet Van Mileage Import"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpExcelFile, 0)
        Me.Controls.SetChildIndex(Me.grpFailedImports, 0)
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

    Private _currentVan As Entity.FleetVans.FleetVan
    Public Property CurrentVan() As Entity.FleetVans.FleetVan
        Get
            Return _currentVan
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVan)
            _currentVan = Value

            If CurrentVan Is Nothing Then
                CurrentVan = New Entity.FleetVans.FleetVan
                CurrentVan.Exists = False
            End If
        End Set
    End Property

    Private _currentVanMaintenance As Entity.FleetVans.FleetVanMaintenance
    Public Property CurrentVanMaintenance() As Entity.FleetVans.FleetVanMaintenance
        Get
            Return _currentVanMaintenance
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVanMaintenance)
            _currentVanMaintenance = Value

            If CurrentVanMaintenance Is Nothing Then
                CurrentVanMaintenance = New Entity.FleetVans.FleetVanMaintenance
                CurrentVanMaintenance.Exists = False
            End If
        End Set
    End Property

    Private _currentContract As Entity.FleetVans.FleetVanContract
    Public Property CurrentContract() As Entity.FleetVans.FleetVanContract
        Get
            Return _currentContract
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVanContract)
            _currentContract = Value

            If CurrentContract Is Nothing Then
                CurrentContract = New Entity.FleetVans.FleetVanContract
                CurrentContract.Exists = False
            End If
        End Set
    End Property

    Private _failedVans As New List(Of FailedFleetVanImports)
    Private Property FailedVans() As List(Of FailedFleetVanImports)
        Get
            Return _failedVans
        End Get
        Set(ByVal value As List(Of FailedFleetVanImports))
            _failedVans = value
        End Set
    End Property

    Public Class FailedFleetVanImports
        Public Property Driver As String
        Public Property Registration As String
        Public Property Make As String
        Public Property Model As String
        Public Property Mileage As Integer
    End Class
#End Region

#Region "Events"

    Private Sub FRMImport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Private Sub btnFindExcelFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFindExcelFile.Click
        LoadData()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Import()
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

    Private Sub Import()
        Dim oExcel As Excel.Application
        Try
            Cursor.Current = Cursors.WaitCursor

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
            For i As Integer = 0 To data.Tables(0).Rows.Count - 1
                Dim Row As DataRow = data.Tables(0).Rows(i)
                Dim driver As String = String.Empty
                Dim reg As String = String.Empty
                Dim make As String = String.Empty
                Dim model As String = String.Empty
                Dim mileage As Integer = 0
                Dim insertDB As Boolean = True

                If Row.Item("Registration") Is DBNull.Value Then
                    insertDB = False
                Else
                    reg = Row.Item("Registration")
                    reg = reg.Replace(" ", String.Empty)
                End If

                If Row.Item("End Odometer") Is DBNull.Value Then
                    insertDB = False
                Else
                    mileage = Entity.Sys.Helper.MakeIntegerValid(Row.Item("End Odometer"))
                End If

                driver = Entity.Sys.Helper.MakeStringValid(Row.Item("Driver Name"))
                make = Entity.Sys.Helper.MakeStringValid(Row.Item("Make"))
                model = Entity.Sys.Helper.MakeStringValid(Row.Item("Model"))

                If insertDB Then
                    CurrentVan = DB.FleetVan.Get_ByRegistration(reg)
                    If CurrentVan.Exists Then
                        CurrentVanMaintenance = DB.FleetVanMaintenance.Get_ByVanID(CurrentVan.VanID)
                        CurrentContract = DB.FleetVanContract.Get_ByVanID(CurrentVan.VanID)

                        CurrentVan.SetMileage = mileage
                        RunEstimateUpdates()

                        DB.FleetVan.Update(CurrentVan)

                        Dim faultsdv As DataView = DB.FleetVanFault.GetAll_ByVanID(CurrentVan.VanID)
                        If faultsdv.Table.Rows.Count > 0 Then
                            For Each rowView As DataRowView In faultsdv
                                Dim rowfault As DataRow = rowView.Row
                                Dim fault As Entity.FleetVans.FleetVanFault
                                fault = DB.FleetVanFault.Get(rowfault.Item("VanFaultID"))
                                If fault IsNot Nothing Then
                                    If fault.FaultTypeID = Entity.Sys.Enums.FleetVanFaultType.InvalidMileage Then
                                        fault.ResolvedDate = Date.Now
                                        fault.SetNotes = fault.Notes & "-- Fault resolved via import"
                                        DB.FleetVanFault.Update(fault)
                                    End If
                                End If
                            Next
                        End If

                        DB.FleetVanMaintenance.Update(CurrentVanMaintenance)
                        DB.FleetVanContract.Update(CurrentContract)
                    Else
                        UpdateFailedVans(driver, reg, make, model, mileage)
                    End If
                Else
                    UpdateFailedVans(driver, reg, make, model, mileage)
                End If

            Next

            If FailedVans.Count > 0 Then
                Dim dt As DataTable = ConvertToDataTable(Of FailedFleetVanImports)(FailedVans)
                Dim dv As DataView = New DataView(dt)
                dgFailedImports.DataSource = dv
            End If

        Catch ex As Exception
            Me.txtExcelFile.Text = ""
            Me.btnImport.Enabled = False
            ShowMessage("File data could not be loaded : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            KillInstances(oExcel)

            Dim filePath As String = TheSystem.Configuration.DocumentsLocation & "Fleet\VanImports\"
            IO.File.Move(File.FullName, filePath + File.Name)
            File = Nothing

            Me.btnFindExcelFile.Enabled = True
            Me.txtExcelFile.Text = ""
            Me.btnImport.Enabled = False
            ShowMessage("Import Completed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub RunEstimateUpdates()

        'First we need to calculate the average mileage
        'Get the weeks between now and the last service date
        If Not CurrentVanMaintenance.Exists Then
            Exit Sub
        End If
        Dim weeks As Integer = DateDiff(DateInterval.WeekOfYear, CurrentVanMaintenance.LastService, Date.Now)
        If weeks < 1 Then
            weeks = 1
        End If
        If CurrentVan.Mileage < 1 Then
            Exit Sub
        End If
        Dim mileageDiff As Integer = CurrentVan.Mileage - CurrentVanMaintenance.LastServiceMileage
        Dim avgMileages As New List(Of Integer)

        'calculate average mileage based on last service
        Dim currentContractLength As Integer = 0
        Dim lastServiceAverageMileage As Double = 0

        'multiple the average mileage by 4
        lastServiceAverageMileage = Math.Round((mileageDiff / weeks) * 4.3, MidpointRounding.AwayFromZero)
        CurrentVan.SetAverageMileage = lastServiceAverageMileage

        If CurrentContract.Exists Then
            If CurrentContract.ContractStart < Date.Now And
                    CurrentContract.ProcurementMethod <> Entity.Sys.Enums.FleetVanContractProcurementMethod.Owned And
                    CurrentContract.ContractLength > 0 Then
                avgMileages.Add(lastServiceAverageMileage)

                'calculate the average mileage over the contract period
                currentContractLength =
                    DateDiff(DateInterval.WeekOfYear, CurrentContract.ContractStart, Date.Now)

                Dim mileageFromContractStart As Integer = CurrentVan.Mileage - CurrentContract.StartingMileage

                If currentContractLength > 0 Then
                    Dim currentAverageMileageOverContract As Double =
                        Math.Round((mileageFromContractStart / currentContractLength) * 4.3, MidpointRounding.AwayFromZero)

                    avgMileages.Add(currentAverageMileageOverContract)
                    CurrentVan.SetAverageMileage = CInt(avgMileages.Average)
                End If
            End If
        End If

        Dim vanType As Entity.FleetVans.FleetVanType =
            DB.FleetVanType.Get(CurrentVan.VanTypeID)

        'next service based on date
        Dim nsDate As Date = CurrentVanMaintenance.LastService.AddMonths(vanType.DateServiceInterval)

        ' lets see how many months it will take to get to next service mileage
        Dim avg As Integer = vanType.MileageServiceInterval / CurrentVan.AverageMileage
        'next service based on mileage 
        Dim nsMileage As Date = CurrentVanMaintenance.LastService.AddMonths(avg)

        If nsDate < nsMileage Then
            CurrentVanMaintenance.NextService = nsDate
        Else
            CurrentVanMaintenance.NextService = nsMileage
        End If

        If CurrentContract.ContractMileage = 0 Then
            CurrentContract.SetExcessMileageCost = 0
            CurrentContract.SetForecastExcessMileageCost = CurrentContract.ExcessMileageCost
            Exit Sub
        End If

        'calculate the excess mileage cost
        If CurrentVan.Mileage > CurrentContract.ContractMileage Then
            Dim contractMileageDiff As Integer = CurrentVan.Mileage - CurrentContract.ContractMileage

            Dim excessMileageCost As Double = CurrentContract.ExcessMileageRate * contractMileageDiff
            CurrentContract.SetExcessMileageCost = excessMileageCost
        Else
            CurrentContract.SetExcessMileageCost = 0
        End If

        If CurrentContract.ContractEnd = Nothing Then
            Exit Sub
        End If

        'get contract length 
        CurrentContract.SetContractLength = DateDiff(DateInterval.Month, CurrentContract.ContractStart,
                                                     CurrentContract.ContractEnd) + 1

        Dim remainingLength As Integer =
            Math.Round(CurrentContract.ContractLength - (currentContractLength / 4.3))

        Dim estMileageOverRemainingLength As Double =
            lastServiceAverageMileage * remainingLength

        Dim estContractMileage As Integer =
            estMileageOverRemainingLength + CurrentVan.Mileage

        If estContractMileage > CurrentContract.ContractMileage Then
            Dim contractMileageDiff As Integer = estContractMileage - CurrentContract.ContractMileage

            Dim excessMileageCost As Double = CurrentContract.ExcessMileageRate * contractMileageDiff
            CurrentContract.SetForecastExcessMileageCost = Math.Round(excessMileageCost, 2,
                                                                      MidpointRounding.AwayFromZero)
        Else
            CurrentContract.SetForecastExcessMileageCost = CurrentContract.ExcessMileageCost
        End If
    End Sub

    Private Sub UpdateFailedVans(ByVal driver As String, ByVal reg As String, ByVal make As String,
                                 ByVal model As String, ByVal mileage As String)
        Dim failedVan As FailedFleetVanImports = New FailedFleetVanImports
        With failedVan
            .Driver = driver
            .Registration = reg
            .Make = make
            .Model = model
            .Mileage = mileage
        End With
        FailedVans.Add(failedVan)
    End Sub

    ''' <summary>
    ''' Converts a list of a class to a datatable
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="list"></param>
    ''' <returns></returns>
    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        'declare new datatable
        Dim dt As New DataTable()

        'if the list is empty then we return a blank table
        If Not list.Any Then
            Return dt
        End If
        'get all the class properties 
        Dim fields() As PropertyInfo = list.First.GetType.GetProperties
        'use the class properties as column name
        For Each field As PropertyInfo In fields
            dt.Columns.Add(field.Name, field.PropertyType)
        Next
        'populate datatable with values
        For Each item As T In list
            Dim row As DataRow = dt.NewRow()
            For Each field As PropertyInfo In fields
                Dim p = item.GetType.GetProperty(field.Name)
                row(field.Name) = p.GetValue(item, Nothing)
            Next
            dt.Rows.Add(row)
        Next
        Return dt
    End Function
#End Region

End Class
