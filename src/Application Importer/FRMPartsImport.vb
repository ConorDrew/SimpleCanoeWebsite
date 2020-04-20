Imports System.IO
Imports System.Linq
Imports FSM.Entity.Sys
Imports LinqToExcel

Public Class FRMPartsImport : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Combo.SetUpCombo(Me.cboValidateType, DynamicDataTables.PartValidationTypes, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

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

    Friend WithEvents tcData As System.Windows.Forms.TabControl
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMessages As System.Windows.Forms.Label
    Friend WithEvents btnExportParts As System.Windows.Forms.LinkLabel
    Friend WithEvents btnExportResults As System.Windows.Forms.Button
    Friend WithEvents cboValidateType As System.Windows.Forms.ComboBox
    Friend WithEvents btnProcessIndiv As System.Windows.Forms.Button
    Friend WithEvents grpCatImport As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Stats As System.Windows.Forms.Label
    Friend WithEvents lblFile As Label
    Friend WithEvents txtExcelFile As TextBox
    Friend WithEvents btnFindSupplier As Button
    Friend WithEvents btnImport As Button
    Friend WithEvents btnFindExcelFile As Button
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents lblSupplier As Label
    Friend WithEvents chkPFH As CheckBox
    Friend WithEvents llOpenFolder As LinkLabel
    Friend WithEvents lblProgress As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpExcelFile = New System.Windows.Forms.GroupBox()
        Me.chkPFH = New System.Windows.Forms.CheckBox()
        Me.btnFindExcelFile = New System.Windows.Forms.Button()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnFindSupplier = New System.Windows.Forms.Button()
        Me.txtExcelFile = New System.Windows.Forms.TextBox()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.btnExportResults = New System.Windows.Forms.Button()
        Me.tcData = New System.Windows.Forms.TabControl()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.btnExportParts = New System.Windows.Forms.LinkLabel()
        Me.cboValidateType = New System.Windows.Forms.ComboBox()
        Me.btnProcessIndiv = New System.Windows.Forms.Button()
        Me.grpCatImport = New System.Windows.Forms.GroupBox()
        Me.lbl_Stats = New System.Windows.Forms.Label()
        Me.llOpenFolder = New System.Windows.Forms.LinkLabel()
        Me.grpExcelFile.SuspendLayout()
        Me.grpCatImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpExcelFile
        '
        Me.grpExcelFile.Controls.Add(Me.chkPFH)
        Me.grpExcelFile.Controls.Add(Me.btnFindExcelFile)
        Me.grpExcelFile.Controls.Add(Me.txtSupplier)
        Me.grpExcelFile.Controls.Add(Me.lblSupplier)
        Me.grpExcelFile.Controls.Add(Me.btnImport)
        Me.grpExcelFile.Controls.Add(Me.btnFindSupplier)
        Me.grpExcelFile.Controls.Add(Me.txtExcelFile)
        Me.grpExcelFile.Controls.Add(Me.lblFile)
        Me.grpExcelFile.Location = New System.Drawing.Point(8, 40)
        Me.grpExcelFile.Name = "grpExcelFile"
        Me.grpExcelFile.Size = New System.Drawing.Size(515, 85)
        Me.grpExcelFile.TabIndex = 3
        Me.grpExcelFile.TabStop = False
        Me.grpExcelFile.Text = "Initial Import"
        '
        'chkPFH
        '
        Me.chkPFH.AutoSize = True
        Me.chkPFH.Location = New System.Drawing.Point(452, 22)
        Me.chkPFH.Name = "chkPFH"
        Me.chkPFH.Size = New System.Drawing.Size(47, 17)
        Me.chkPFH.TabIndex = 21
        Me.chkPFH.Text = "PFH"
        Me.chkPFH.UseVisualStyleBackColor = True
        '
        'btnFindExcelFile
        '
        Me.btnFindExcelFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFindExcelFile.Location = New System.Drawing.Point(413, 51)
        Me.btnFindExcelFile.Name = "btnFindExcelFile"
        Me.btnFindExcelFile.Size = New System.Drawing.Size(32, 23)
        Me.btnFindExcelFile.TabIndex = 20
        Me.btnFindExcelFile.Text = "..."
        '
        'txtSupplier
        '
        Me.txtSupplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier.Location = New System.Drawing.Point(71, 19)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(336, 21)
        Me.txtSupplier.TabIndex = 19
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Location = New System.Drawing.Point(6, 22)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(59, 13)
        Me.lblSupplier.TabIndex = 18
        Me.lblSupplier.Text = "Supplier:"
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImport.Location = New System.Drawing.Point(451, 51)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(58, 23)
        Me.btnImport.TabIndex = 17
        Me.btnImport.Text = "Import"
        '
        'btnFindSupplier
        '
        Me.btnFindSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFindSupplier.Location = New System.Drawing.Point(413, 17)
        Me.btnFindSupplier.Name = "btnFindSupplier"
        Me.btnFindSupplier.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSupplier.TabIndex = 16
        Me.btnFindSupplier.Text = "..."
        '
        'txtExcelFile
        '
        Me.txtExcelFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtExcelFile.Location = New System.Drawing.Point(43, 53)
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.ReadOnly = True
        Me.txtExcelFile.Size = New System.Drawing.Size(364, 21)
        Me.txtExcelFile.TabIndex = 15
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(6, 56)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(31, 13)
        Me.lblFile.TabIndex = 14
        Me.lblFile.Text = "File:"
        '
        'btnExportResults
        '
        Me.btnExportResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportResults.Location = New System.Drawing.Point(860, 641)
        Me.btnExportResults.Name = "btnExportResults"
        Me.btnExportResults.Size = New System.Drawing.Size(68, 27)
        Me.btnExportResults.TabIndex = 5
        Me.btnExportResults.Text = "Export"
        Me.btnExportResults.UseVisualStyleBackColor = True
        '
        'tcData
        '
        Me.tcData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcData.Location = New System.Drawing.Point(8, 131)
        Me.tcData.Name = "tcData"
        Me.tcData.SelectedIndex = 0
        Me.tcData.Size = New System.Drawing.Size(920, 487)
        Me.tcData.TabIndex = 8
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbStatus.Location = New System.Drawing.Point(10, 645)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(780, 23)
        Me.pbStatus.Step = 1
        Me.pbStatus.TabIndex = 10
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.Location = New System.Drawing.Point(796, 652)
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
        Me.lblMessages.Location = New System.Drawing.Point(7, 621)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(921, 19)
        Me.lblMessages.TabIndex = 12
        Me.lblMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMessages.Visible = False
        '
        'btnExportParts
        '
        Me.btnExportParts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportParts.Location = New System.Drawing.Point(840, 8)
        Me.btnExportParts.Name = "btnExportParts"
        Me.btnExportParts.Size = New System.Drawing.Size(88, 23)
        Me.btnExportParts.TabIndex = 13
        Me.btnExportParts.TabStop = True
        Me.btnExportParts.Text = "Export Parts"
        '
        'cboValidateType
        '
        Me.cboValidateType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboValidateType.FormattingEnabled = True
        Me.cboValidateType.Location = New System.Drawing.Point(6, 19)
        Me.cboValidateType.Name = "cboValidateType"
        Me.cboValidateType.Size = New System.Drawing.Size(387, 21)
        Me.cboValidateType.TabIndex = 1
        '
        'btnProcessIndiv
        '
        Me.btnProcessIndiv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProcessIndiv.Location = New System.Drawing.Point(178, 51)
        Me.btnProcessIndiv.Name = "btnProcessIndiv"
        Me.btnProcessIndiv.Size = New System.Drawing.Size(215, 23)
        Me.btnProcessIndiv.TabIndex = 4
        Me.btnProcessIndiv.Text = "Process -->"
        Me.btnProcessIndiv.UseVisualStyleBackColor = True
        '
        'grpCatImport
        '
        Me.grpCatImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCatImport.Controls.Add(Me.btnProcessIndiv)
        Me.grpCatImport.Controls.Add(Me.cboValidateType)
        Me.grpCatImport.Location = New System.Drawing.Point(529, 40)
        Me.grpCatImport.Name = "grpCatImport"
        Me.grpCatImport.Size = New System.Drawing.Size(399, 85)
        Me.grpCatImport.TabIndex = 6
        Me.grpCatImport.TabStop = False
        Me.grpCatImport.Text = "Category Processing"
        '
        'lbl_Stats
        '
        Me.lbl_Stats.AutoSize = True
        Me.lbl_Stats.Location = New System.Drawing.Point(126, 8)
        Me.lbl_Stats.Name = "lbl_Stats"
        Me.lbl_Stats.Size = New System.Drawing.Size(0, 13)
        Me.lbl_Stats.TabIndex = 15
        '
        'llOpenFolder
        '
        Me.llOpenFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llOpenFolder.Location = New System.Drawing.Point(707, 8)
        Me.llOpenFolder.Name = "llOpenFolder"
        Me.llOpenFolder.Size = New System.Drawing.Size(111, 23)
        Me.llOpenFolder.TabIndex = 16
        Me.llOpenFolder.TabStop = True
        Me.llOpenFolder.Text = "View Parts Files"
        '
        'FRMPartsImport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(940, 680)
        Me.Controls.Add(Me.llOpenFolder)
        Me.Controls.Add(Me.grpExcelFile)
        Me.Controls.Add(Me.btnExportResults)
        Me.Controls.Add(Me.lbl_Stats)
        Me.Controls.Add(Me.grpCatImport)
        Me.Controls.Add(Me.btnExportParts)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.tcData)
        Me.MinimumSize = New System.Drawing.Size(920, 688)
        Me.Name = "FRMPartsImport"
        Me.Text = "Parts Import"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.tcData, 0)
        Me.Controls.SetChildIndex(Me.pbStatus, 0)
        Me.Controls.SetChildIndex(Me.lblProgress, 0)
        Me.Controls.SetChildIndex(Me.lblMessages, 0)
        Me.Controls.SetChildIndex(Me.btnExportParts, 0)
        Me.Controls.SetChildIndex(Me.grpCatImport, 0)
        Me.Controls.SetChildIndex(Me.lbl_Stats, 0)
        Me.Controls.SetChildIndex(Me.btnExportResults, 0)
        Me.Controls.SetChildIndex(Me.grpExcelFile, 0)
        Me.Controls.SetChildIndex(Me.llOpenFolder, 0)
        Me.grpExcelFile.ResumeLayout(False)
        Me.grpExcelFile.PerformLayout()
        Me.grpCatImport.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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

    Private _supplier As Entity.Suppliers.Supplier

    Public Property Supplier() As Entity.Suppliers.Supplier
        Get
            Return _supplier
        End Get
        Set(ByVal Value As Entity.Suppliers.Supplier)
            _supplier = Value

            If _supplier Is Nothing Then
                _supplier = New Entity.Suppliers.Supplier
                _supplier.Exists = False
            Else
                Me.txtSupplier.Text = _supplier.Name
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMPartsImport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim StatsTable As DataTable
        StatsTable = DB.ImportValidation.Parts_PreImportStats
        If Not StatsTable.Rows(0).Item(2) = "0" Then
            lbl_Stats.Text = "Import started on " & FormatDateTime(StatsTable.Rows(0).Item(0), DateFormat.ShortDate) & " at " & FormatDateTime(StatsTable.Rows(0).Item(0), DateFormat.ShortTime) & " finishing at " & FormatDateTime(StatsTable.Rows(0).Item(1), DateFormat.ShortTime) & " and contains " & StatsTable.Rows(0).Item(2) & " records."
        End If
    End Sub

    Private Sub cboValidateType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboValidateType.SelectedIndexChanged
        ShowData()
        Select Case Combo.GetSelectedItemValue(cboValidateType)
            Case 0, 4, 7, 8, 9, 12, 13, 14
                btnProcessIndiv.Text = "Revalidate Results -->"
            Case 1
                btnProcessIndiv.Text = "Apply No Change -->"
            Case 2, 3
                btnProcessIndiv.Text = "Apply Price Change -->"
            Case 5
                btnProcessIndiv.Text = "Add Parts -->"
            Case 6
                btnProcessIndiv.Text = "Add Parts -->"
        End Select
    End Sub

    Private Sub btnProcessIndiv_Click(sender As System.Object, e As System.EventArgs) Handles btnProcessIndiv.Click
        Select Case Combo.GetSelectedItemValue(cboValidateType)
            Case 0, 4, 7, 8, 9, 12, 14
                If ShowMessage("This action will revalidate the pre-import data, no changes will be made to live parts.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    pbStatus.Value = 0
                    pbStatus.Maximum = [Enum].GetValues(GetType(Enums.PartValidationResults)).Cast(Of Enums.PartValidationResults)().Max()
                    Cursor.Current = Cursors.WaitCursor
                    ValidateAllRecords()
                    ShowData()
                    MoveProgressOn(True)
                    Cursor.Current = Cursors.Default
                End If
            Case 1
                If ShowMessage("This action will remove these parts from the pre-import data, no changes will be made to live parts other than the date update.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    pbStatus.Value = 0
                    pbStatus.Maximum = 1
                    Cursor.Current = Cursors.WaitCursor
                    DB.ImportValidation.Parts_PreImportNoChangeRemove(Not chkPFH.Checked)
                    ShowData()
                    Cursor.Current = Cursors.Default
                End If
            Case 2, 3
                If ShowMessage("This action will update PRICES ONLY on live parts.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    pbStatus.Value = 0
                    pbStatus.Maximum = 1
                    Cursor.Current = Cursors.WaitCursor
                    DB.ImportValidation.Parts_ImportApplyPriceChange(Combo.GetSelectedItemValue(cboValidateType))
                    ShowData()
                    Cursor.Current = Cursors.Default
                End If
            Case 5
                If ShowMessage("This action will attach the supplier (SPN) as a seller of this part, if the 'swap SPN' flag has been ticked then the supplier SPN will only be updated.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    pbStatus.Value = 0
                    pbStatus.Maximum = 1
                    Cursor.Current = Cursors.WaitCursor
                    DB.ImportValidation.Parts_ImportAddPartSuppliers()
                    ShowData()
                    Cursor.Current = Cursors.Default
                End If
            Case 6
                If ShowMessage("This action will add the part (MPN) as a complete new part and attach the supplier (SPN) as a seller of this part.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    pbStatus.Value = 0
                    pbStatus.Maximum = 1
                    Cursor.Current = Cursors.WaitCursor
                    DB.ImportValidation.Parts_ImportAddParts()
                    ShowData()
                    Cursor.Current = Cursors.Default
                End If
        End Select
    End Sub

    Private Sub btnExportResults_Click(sender As System.Object, e As System.EventArgs) Handles btnExportResults.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            Dim data As DataView
            Dim sheetName As String = ""

            Dim sql As String = ""
            sql = "EXEC Parts_GetPreImport " & Combo.GetSelectedItemValue(cboValidateType)
            data = New DataView(DB.ExecuteWithReturn(sql))

            For Each col As DataColumn In data.Table.Columns
                If col.DataType Is Type.GetType("System.String") Then
                    For Each row As DataRow In data.Table.Rows
                        row.Item(col.ColumnName) = "'" & row.Item(col.ColumnName)
                    Next
                End If
            Next

            sheetName = Combo.GetSelectedItemDescription(cboValidateType)
            ExportHelper.Export(data.Table, sheetName, Enums.ExportType.XLS)
        Catch ex As Exception
            ShowMessage("Error exporting : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnExportParts_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnExportParts.LinkClicked
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            Dim data As DataView

            Dim sql As String = ""
            sql = "SELECT tblPart.PartID, tblPart.Name, tblPart.Number, tblPart.Reference, tblPart.Notes, tblPart.UnitTypeID, tblPart.Deleted, tblPart.SellPrice, tblPart.MinimumQuantity, " &
                      "tblPart.RecommendedQuantity, tblPicklists.Name AS Category, tblPart.LastChanged, tblPart.BinID, tblPart.ShelfID, tblPart.WarehouseID, tblPart.BinIDAlternative, " &
                      "tblPart.ShelfIDAlternative, tblPart.WarehouseIDAlternative, tblPart.EndFlagged, tblPart.Equipment, tblSupplier.Name AS Supplier, tblPartSupplier.PartCode AS [Supplier Part Number],  " &
                      "tblPartSupplier.Price AS [Supplier Price] " &
                      " FROM tblPart INNER JOIN " &
                      " tblPicklists ON tblPart.CategoryID = tblPicklists.ManagerID INNER JOIN " &
                      " tblPartSupplier ON tblPart.PartID = tblPartSupplier.PartID INNER JOIN " &
                      " tblSupplier ON tblPartSupplier.SupplierID = tblSupplier.SupplierID " &
                      " WHERE tblPart.Deleted = 0"
            data = New DataView(DB.ExecuteWithReturn(sql))

            For Each col As DataColumn In data.Table.Columns
                If col.DataType Is System.Type.GetType("System.String") Then
                    For Each row As DataRow In data.Table.Rows
                        row.Item(col.ColumnName) = "'" & row.Item(col.ColumnName)
                    Next
                End If
            Next

            ExportHelper.Export(data.Table, "Parts", Enums.ExportType.XLS)
        Catch ex As Exception
            ShowMessage("Error exporting : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnFindExcelFile_Click(sender As Object, e As EventArgs) Handles btnFindExcelFile.Click
        LoadData()
    End Sub

    Private Sub btnFindSupplier_Click(sender As Object, e As EventArgs) Handles btnFindSupplier.Click
        FindSupplier()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Import()
    End Sub

#End Region

#Region "Functions"

    Public Sub ShowData()
        Me.tcData.TabPages.Clear()
        Cursor.Current = Cursors.WaitCursor
        Dim tp As New TabPage

        Dim data As New UCData
        data.SetupDG()

        If Combo.GetSelectedItemValue(cboValidateType) = Entity.Sys.Enums.PartValidationResults.NewForThisSupplier Then '5  Then
            data.dgvData.Columns("SwapSPN").Visible = True
        Else
            data.dgvData.Columns("SwapSPN").Visible = False
        End If

        If Combo.GetSelectedItemValue(cboValidateType) = Entity.Sys.Enums.PartValidationResults.CategoryNotFound Then
            data.dgvData.Columns("Category").ReadOnly = False
        Else
            data.dgvData.Columns("Category").ReadOnly = True
        End If

        data.Dock = DockStyle.Fill
        data.Data = DB.ImportValidation.Parts_GetPreImportData(Combo.GetSelectedItemValue(cboValidateType))
        tp.Text = "Parts Pre-Import (" & data.Data.Count & " Records)"

        tp.Controls.Add(data)
        Me.tcData.TabPages.Add(tp)
        Me.tcData.SelectedIndex = 0
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub LoadData()
        Dim dlg As OpenFileDialog = Nothing
        Dim oExcel As Excel.Application = Nothing
        Try
            Cursor.Current = Cursors.WaitCursor

            Me.btnFindSupplier.Enabled = False
            Me.txtExcelFile.Text = ""
            Me.btnImport.Enabled = False

            dlg = New OpenFileDialog
            If dlg.ShowDialog = DialogResult.OK Then
                Dim tempfile As New FileInfo(dlg.FileName)

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
            If dlg IsNot Nothing Then dlg.Dispose()
            Me.btnFindSupplier.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
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

    Public Sub SetLastPartAttempted(ByVal PartCode As String)
        lblMessages.Visible = True
        lblMessages.Text = PartCode
    End Sub

    Private Sub Import()
        If Supplier Is Nothing OrElse Not Supplier.Exists Then
            ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim success As Boolean = False
        Dim existingRecords As Integer = DB.ImportValidation.Parts_CheckPreImportCount

        If existingRecords > 0 Then
            If ShowMessage("There are already parts in the pre-import table.  You should process or clear them before importing more data.  Clear Now?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                DB.ImportValidation.Parts_ClearPreImport()
            Else Exit Sub
            End If
        End If

        If ShowMessage("You are about to load data from the parts files, to the temporary holding table, do you wish to continue?",
                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) <> DialogResult.Yes Then
            Exit Sub
        End If

        Dim oExcel As Excel.Application = Nothing

        Try
            Cursor.Current = Cursors.WaitCursor
            lblMessages.Visible = True
            lblMessages.Text = "Downloading data from file..."
            Me.btnFindExcelFile.Enabled = False
            Me.btnImport.Enabled = False
            Me.pbStatus.Value = 0
            Application.DoEvents()

            Dim excel As ExcelQueryFactory = New ExcelQueryFactory(File.FullName)

            Dim obj As Object = From a In excel.Worksheet("Upload Template") Select a

            Dim columnNames As Object = excel.GetColumnNames("Upload Template")

            Dim data As DataTable = New DataTable()
            For Each columnName As Object In columnNames
                data.Columns.Add(columnName)
            Next

            For Each rr As Row In obj
                Dim dr As DataRow = data.NewRow()
                For Each columnName As Object In columnNames
                    dr(columnName) = rr(columnName)
                Next
                data.Rows.Add(dr)
            Next

            pbStatus.Maximum += data.Rows.Count

            Dim dt As New DataTable

            dt.Columns.Add("SupplierID")
            dt.Columns.Add("Partcode")
            dt.Columns.Add("Description")
            dt.Columns.Add("SupplierPartCode")
            dt.Columns.Add("SupplierPrice")
            dt.Columns.Add("SupplierSecondaryPrice")
            dt.Columns.Add("Category")

            For i As Integer = 0 To data.Rows.Count - 1
                Dim row As DataRow = data.Rows(i)
                Dim supplierId As Integer = Supplier.SupplierID
                Dim mpn As String = String.Empty
                Dim description As String = String.Empty
                Dim spn As String = String.Empty
                Dim category As String = String.Empty
                Dim netPrice As Double = 0
                Dim pfhPrice As Double = 0

                If row.Item("SPN") Is DBNull.Value Then
                    GoTo nextrow
                Else
                    spn = Helper.MakeStringValid(row("SPN"))
                End If
                If row.Item("MPN") Is DBNull.Value Then
                    GoTo nextrow
                Else
                    mpn = Helper.MakeStringValid(row("MPN"))
                End If
                description = Helper.MakeStringValid(row("Description"))
                If row.Item("Net Price") Is DBNull.Value Then
                    GoTo nextrow
                Else
                    If chkPFH.Checked Then
                        pfhPrice = Helper.MakeDoubleValid(row("Net Price"))
                    Else
                        netPrice = Helper.MakeDoubleValid(row("Net Price"))
                    End If
                End If

                category = Helper.MakeStringValid(row("Category"))

                lblMessages.Text = "Adding part " & (i + 1) & " of " & data.Rows.Count & " from file."
                lblMessages.Visible = True

                dt.Rows.Add({supplierId, mpn, description, spn, netPrice, pfhPrice, category})

nextrow:
                MoveProgressOn()
            Next
            DB.ImportValidation.BulkInsert(dt)
            ValidateAllRecords()
            success = True
        Catch ex As Exception
            lblMessages.Text = "Error!"
            ShowMessage("File data could not be imported : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            MoveProgressOn(True)
            KillInstances(oExcel)

            If success Then
                Try
                    Dim sup As String = If(chkPFH.Checked, Supplier.Name & "_PFH", Supplier.Name)
                    Dim filePath As String = TheSystem.Configuration.DocumentsLocation & "PartsFiles\" & sup & "\"
                    Directory.CreateDirectory(filePath)

                    Dim fileType As String = Path.GetExtension(File.Name)
                    IO.File.Move(File.FullName, filePath &
                                 File.Name.Replace(fileType, "_" & Now.ToString("ddMMyyHHmmss") & fileType))
                Catch ex As Exception
                    ShowMessage("Data imported and validated but file has not been moved to archive as ... " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If

            File = Nothing
            Me.txtExcelFile.Text = ""

            Me.pbStatus.Value = Me.pbStatus.Maximum
            Me.btnFindExcelFile.Enabled = True
            Me.btnImport.Enabled = True
            Me.pbStatus.Value = 0
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub FindSupplier()
        Dim ID As Integer = FindRecord(Enums.TableNames.tblSupplier)
        If Not ID = 0 Then
            Supplier = DB.Supplier.Supplier_Get(ID)
        End If
    End Sub

    Private Sub ValidateAllRecords()
        lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient."
        lblMessages.Visible = True

        Cursor.Current = Cursors.WaitCursor
        Dim Steps As Integer = [Enum].GetValues(GetType(Enums.PartValidationResults)).Cast(Of Enums.PartValidationResults)().Max()
        pbStatus.Value = 0
        pbStatus.Maximum = Steps + 1

        '  For i As Integer = Steps To 0 Step -1
        DB.ImportValidation.Parts_ValidatePreImportData(0, chkPFH.Checked) 'i
        MoveProgressOn()
        '  Next

        Combo.SetSelectedComboItem_By_Value(cboValidateType, "0")
        ShowData()
        Cursor.Current = Cursors.Default
        'ShowMessage("Validation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        lblMessages.Text = "Validation Complete!"
        lblMessages.Visible = True
    End Sub

    Private Sub llOpenFolder_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llOpenFolder.LinkClicked
        Process.Start("explorer.exe", TheSystem.Configuration.DocumentsLocation & "PartsFiles")
    End Sub

#End Region

End Class