Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports FSM.Entity.Orders
Imports FSM.Entity.PartsToBeCrediteds
Imports FSM.Entity.Sys
Imports FSM.Importer
Imports LinqToExcel

Public Class FRMSupplierInvoiceImporter : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Combo.SetUpCombo(Me.cboValidateType, DynamicDataTables.PartsInvoiceImportValidationResults, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

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
    Friend WithEvents lblDownloadTemplate As LinkLabel
    Friend WithEvents txtNominal As TextBox
    Friend WithEvents lblNominal As Label
    Friend WithEvents btnValidateResults As Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpExcelFile = New System.Windows.Forms.GroupBox()
        Me.txtNominal = New System.Windows.Forms.TextBox()
        Me.lblNominal = New System.Windows.Forms.Label()
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
        Me.cboValidateType = New System.Windows.Forms.ComboBox()
        Me.btnProcessIndiv = New System.Windows.Forms.Button()
        Me.grpCatImport = New System.Windows.Forms.GroupBox()
        Me.btnValidateResults = New System.Windows.Forms.Button()
        Me.lbl_Stats = New System.Windows.Forms.Label()
        Me.lblDownloadTemplate = New System.Windows.Forms.LinkLabel()
        Me.grpExcelFile.SuspendLayout()
        Me.grpCatImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpExcelFile
        '
        Me.grpExcelFile.Controls.Add(Me.txtNominal)
        Me.grpExcelFile.Controls.Add(Me.lblNominal)
        Me.grpExcelFile.Controls.Add(Me.btnFindExcelFile)
        Me.grpExcelFile.Controls.Add(Me.txtSupplier)
        Me.grpExcelFile.Controls.Add(Me.lblSupplier)
        Me.grpExcelFile.Controls.Add(Me.btnImport)
        Me.grpExcelFile.Controls.Add(Me.btnFindSupplier)
        Me.grpExcelFile.Controls.Add(Me.txtExcelFile)
        Me.grpExcelFile.Controls.Add(Me.lblFile)
        Me.grpExcelFile.Location = New System.Drawing.Point(8, 40)
        Me.grpExcelFile.Name = "grpExcelFile"
        Me.grpExcelFile.Size = New System.Drawing.Size(515, 123)
        Me.grpExcelFile.TabIndex = 3
        Me.grpExcelFile.TabStop = False
        Me.grpExcelFile.Text = "Initial Import"
        '
        'txtNominal
        '
        Me.txtNominal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNominal.Location = New System.Drawing.Point(71, 51)
        Me.txtNominal.Name = "txtNominal"
        Me.txtNominal.Size = New System.Drawing.Size(336, 21)
        Me.txtNominal.TabIndex = 22
        '
        'lblNominal
        '
        Me.lblNominal.AutoSize = True
        Me.lblNominal.Location = New System.Drawing.Point(6, 54)
        Me.lblNominal.Name = "lblNominal"
        Me.lblNominal.Size = New System.Drawing.Size(58, 13)
        Me.lblNominal.TabIndex = 21
        Me.lblNominal.Text = "Nominal:"
        '
        'btnFindExcelFile
        '
        Me.btnFindExcelFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindExcelFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFindExcelFile.Location = New System.Drawing.Point(413, 85)
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
        Me.btnImport.Location = New System.Drawing.Point(451, 85)
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
        Me.txtExcelFile.Location = New System.Drawing.Point(43, 87)
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.ReadOnly = True
        Me.txtExcelFile.Size = New System.Drawing.Size(364, 21)
        Me.txtExcelFile.TabIndex = 15
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(6, 90)
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
        Me.tcData.Location = New System.Drawing.Point(8, 169)
        Me.tcData.Name = "tcData"
        Me.tcData.SelectedIndex = 0
        Me.tcData.Size = New System.Drawing.Size(920, 449)
        Me.tcData.TabIndex = 8
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbStatus.Location = New System.Drawing.Point(17, 645)
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
        Me.btnProcessIndiv.Location = New System.Drawing.Point(157, 54)
        Me.btnProcessIndiv.Name = "btnProcessIndiv"
        Me.btnProcessIndiv.Size = New System.Drawing.Size(236, 23)
        Me.btnProcessIndiv.TabIndex = 4
        Me.btnProcessIndiv.Text = "Process -->"
        Me.btnProcessIndiv.UseVisualStyleBackColor = True
        '
        'grpCatImport
        '
        Me.grpCatImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCatImport.Controls.Add(Me.btnValidateResults)
        Me.grpCatImport.Controls.Add(Me.btnProcessIndiv)
        Me.grpCatImport.Controls.Add(Me.cboValidateType)
        Me.grpCatImport.Location = New System.Drawing.Point(529, 40)
        Me.grpCatImport.Name = "grpCatImport"
        Me.grpCatImport.Size = New System.Drawing.Size(399, 123)
        Me.grpCatImport.TabIndex = 6
        Me.grpCatImport.TabStop = False
        Me.grpCatImport.Text = "Category Processing"
        '
        'btnValidateResults
        '
        Me.btnValidateResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValidateResults.Location = New System.Drawing.Point(6, 54)
        Me.btnValidateResults.Name = "btnValidateResults"
        Me.btnValidateResults.Size = New System.Drawing.Size(145, 23)
        Me.btnValidateResults.TabIndex = 7
        Me.btnValidateResults.Text = "Revalidate Results"
        Me.btnValidateResults.UseVisualStyleBackColor = True
        '
        'lbl_Stats
        '
        Me.lbl_Stats.AutoSize = True
        Me.lbl_Stats.Location = New System.Drawing.Point(126, 8)
        Me.lbl_Stats.Name = "lbl_Stats"
        Me.lbl_Stats.Size = New System.Drawing.Size(0, 13)
        Me.lbl_Stats.TabIndex = 15
        '
        'lblDownloadTemplate
        '
        Me.lblDownloadTemplate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDownloadTemplate.Location = New System.Drawing.Point(800, 8)
        Me.lblDownloadTemplate.Name = "lblDownloadTemplate"
        Me.lblDownloadTemplate.Size = New System.Drawing.Size(128, 23)
        Me.lblDownloadTemplate.TabIndex = 16
        Me.lblDownloadTemplate.TabStop = True
        Me.lblDownloadTemplate.Text = "Download Template"
        '
        'FRMSupplierInvoiceImporter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(940, 680)
        Me.Controls.Add(Me.lblDownloadTemplate)
        Me.Controls.Add(Me.grpExcelFile)
        Me.Controls.Add(Me.btnExportResults)
        Me.Controls.Add(Me.lbl_Stats)
        Me.Controls.Add(Me.grpCatImport)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.tcData)
        Me.MinimumSize = New System.Drawing.Size(920, 688)
        Me.Name = "FRMSupplierInvoiceImporter"
        Me.Text = "Supplier Invoice Importer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.tcData, 0)
        Me.Controls.SetChildIndex(Me.pbStatus, 0)
        Me.Controls.SetChildIndex(Me.lblProgress, 0)
        Me.Controls.SetChildIndex(Me.lblMessages, 0)
        Me.Controls.SetChildIndex(Me.grpCatImport, 0)
        Me.Controls.SetChildIndex(Me.lbl_Stats, 0)
        Me.Controls.SetChildIndex(Me.btnExportResults, 0)
        Me.Controls.SetChildIndex(Me.grpExcelFile, 0)
        Me.Controls.SetChildIndex(Me.lblDownloadTemplate, 0)
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

    Public Property File As IO.FileInfo
    Private Property DuplicateInvoices() As New List(Of DuplicateInvoice)

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
                Me.txtSupplier.Text = ""
            Else
                Me.txtSupplier.Text = _supplier.Name
                Me.txtNominal.Text = _supplier.DefaultNominal.Trim
            End If
        End Set
    End Property

    Private _nominalCode As String

    Public Property NominalCode() As String
        Get
            Return _nominalCode
        End Get
        Set(ByVal value As String)
            _nominalCode = value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMSupplierInvoiceImporter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim StatsTable As DataTable
        StatsTable = DB.ImportValidation.Parts_PreImportStats
        If Not StatsTable.Rows(0).Item(2) = "0" Then
            lbl_Stats.Text = "Import started on " & FormatDateTime(StatsTable.Rows(0).Item(0), DateFormat.ShortDate) & " at " & FormatDateTime(StatsTable.Rows(0).Item(0), DateFormat.ShortTime) & " finishing at " & FormatDateTime(StatsTable.Rows(0).Item(1), DateFormat.ShortTime) & " and contains " & StatsTable.Rows(0).Item(2) & " records."
        End If
    End Sub

    Private Sub cboValidateType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboValidateType.SelectedIndexChanged
        ShowData(Combo.GetSelectedItemValue(cboValidateType))
        Select Case Combo.GetSelectedItemValue(cboValidateType)
            Case Enums.PartsInvoiceImportValidationResults.Unverified,
                 Enums.PartsInvoiceImportValidationResults.Replenishment,
                 Enums.PartsInvoiceImportValidationResults.UnableToLocatePO,
                 Enums.PartsInvoiceImportValidationResults.JobIncomplete,
                 Enums.PartsInvoiceImportValidationResults.SuppliersDoNotMatch

                btnProcessIndiv.Visible = False

            Case Enums.PartsInvoiceImportValidationResults.MatchedPOPriceCorrect,
                 Enums.PartsInvoiceImportValidationResults.MatchedPOPriceAbove,
                 Enums.PartsInvoiceImportValidationResults.MatchedPOPriceBelow,
                 Enums.PartsInvoiceImportValidationResults.PurchaseCredit

                btnProcessIndiv.Visible = True
                btnProcessIndiv.Text = "Update PO's With Invoice Details -->"

            Case Enums.PartsInvoiceImportValidationResults.SupplierInvoiceCreated,
                  Enums.PartsInvoiceImportValidationResults.MatchedPOSentToSage
                btnProcessIndiv.Visible = False
                btnProcessIndiv.Text = "Remove Records -->"

            Case Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncluded 'Matched PO no parts added so no cost
                btnProcessIndiv.Visible = False
                btnProcessIndiv.Text = "Update PO's With Included Parts and Invoice Details -->"

        End Select
    End Sub

    Private Sub btnProcessIndiv_Click(sender As System.Object, e As System.EventArgs) Handles btnProcessIndiv.Click

        Cursor.Current = Cursors.WaitCursor
        Dim validationResult As Integer = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboValidateType))
        Select Case validationResult
            Case Enums.PartsInvoiceImportValidationResults.UnableToLocatePO
                ValidateOrder(validationResult)
                MoveProgressOn(True)
                ShowData(validationResult)
            Case Enums.PartsInvoiceImportValidationResults.MatchedPOPriceCorrect,
                 Enums.PartsInvoiceImportValidationResults.MatchedPOPriceAbove,
                 Enums.PartsInvoiceImportValidationResults.MatchedPOPriceBelow,
                 Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncluded

                CreateSupplierInvoice(validationResult)
                ValidateAllRecords()
                ShowData(validationResult)

            Case Enums.PartsInvoiceImportValidationResults.PurchaseCredit
                CreatePurchaseCredit(validationResult)
                ShowData(validationResult)

            Case Enums.PartsInvoiceImportValidationResults.SupplierInvoiceCreated  'Supplier Invoice Created
                btnProcessIndiv.Visible = False
                btnProcessIndiv.Text = "Remove Records -->"

            Case Enums.PartsInvoiceImportValidationResults.MatchedPOSentToSage

        End Select
        Cursor.Current = Cursors.Default
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

    Private Sub btnFindExcelFile_Click(sender As Object, e As EventArgs) Handles btnFindExcelFile.Click
        LoadData()
    End Sub

    Private Sub btnFindSupplier_Click(sender As Object, e As EventArgs) Handles btnFindSupplier.Click
        FindSupplier()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Import()
    End Sub

    Private Sub btnValidateResults_Click(sender As Object, e As EventArgs) Handles btnValidateResults.Click
        ValidateAllRecords()
    End Sub

#End Region

#Region "Functions"

    Private Sub CreateSupplierInvoice(ByVal validationResult As Integer)
        Dim dvProcessData As DataView = DB.ImportValidation.POInvoiceImport_ShowData(validationResult)

        pbStatus.Value = 0
        pbStatus.Maximum = dvProcessData.Count + 1

        For Each dr As DataRow In dvProcessData.Table.Rows
            Dim insertDb As Boolean = True
            Dim orderId As Integer = Helper.MakeIntegerValid(dr("OrderID"))
            Dim requiresAuth As Boolean = Helper.MakeBooleanValid(dr("RequiresAuthorisation"))

            If orderId = 0 Then
                insertDb = False
                ShowMessage("An error has occurred:" & vbCrLf & "Unable to locate the OrderID for PO " & dr("PurchaseOrderNo") & ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MoveProgressOn(False)
            ElseIf Helper.MakeBooleanValid(dr("Exclude")) Then
                insertDb = False
            End If

            Dim orderStatusId As Integer = Helper.MakeIntegerValid(DB.ImportValidation.POInvoiceImport_GetOrderStatus(orderId))
            If orderStatusId = 1 Then
                insertDb = False
                ShowMessage("An error has occurred:" & vbCrLf & "Supplier Invoice for PO " & dr("PurchaseOrderNo") &
                            " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MoveProgressOn(False)
            End If

            If insertDb Then
                Dim order As Order = DB.Order.Order_Get(orderId)
                Dim nominal As Integer = Helper.MakeIntegerValid(dr("NominalCode"))
                If nominal = 0 Then nominal = 5300

                Dim isSubby As Boolean = Helper.MakeBooleanValid(dr("SubContractor"))
                Dim vatCodeId As Integer
                If isSubby AndAlso Helper.MakeDoubleValid(dr("TotalVatAmount")) = 0 Then
                    vatCodeId = CInt(Enums.PlVatRates.T9)
                ElseIf Helper.MakeDoubleValid(dr("TotalVatAmount")) > 0 Then
                    vatCodeId = CInt(Enums.PlVatRates.T1)
                Else
                    vatCodeId = CInt(Enums.PlVatRates.T0)
                End If

                Dim supplierInvoice As New SupplierInvoice With {
                    .SetOrderID = orderId,
                    .SetInvoiceReference = dr("InvoiceNo"),
                    .SetInvoiceDate = Helper.MakeDateTimeValid(dr("InvoiceDate")),
                    .SetGoodsAmount = Helper.MakeDoubleValid(dr("TotalGrossAmount")),
                    .SetVATAmount = Helper.MakeDoubleValid(dr("TotalVatAmount")),
                    .SetTotalAmount = Helper.MakeDoubleValid(dr("TotalNetAmount")),
                    .SetTaxCodeID = vatCodeId,
                    .SetNominalCode = nominal,
                    .SetSentToSage = 0,
                    .SetOldSystemInvoice = 0,
                    .SetDateExported = Nothing,
                    .SetKeyedBy = loggedInUser.UserID,
                    .SetExtraRef = ".",
                    .SetReadyToSendToSage = True
                }
                Select Case True
                    Case IsGasway
                    Case Else
                        If requiresAuth Then
                            supplierInvoice.SetReadyToSendToSage = False
                        End If
                End Select

                If order?.OrderTypeID = Enums.OrderType.Job Then
                    Dim dtCharge As DataTable = DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(orderId)
                    If dtCharge.Rows.Count > 0 Then
                        Dim chargeNominal As String = dtCharge.Rows(0).Item("ChargeNominalCode")
                        If chargeNominal > 0 Then
                            supplierInvoice.SetExtraRef = chargeNominal
                        End If
                    End If

                End If

                Try
                    DB.SupplierInvoices.Insert(supplierInvoice)
                    DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(dr("ID"), True)
                    If requiresAuth Then
                        DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dr("ID"), requiresAuth)
                    Else
                        DB.ImportValidation.POInvoiceImport_UpdateValidationType(dr("ID").ToString, 7)
                    End If
                Catch ex As Exception
                    ShowMessage("An error has occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                MoveProgressOn(False)

            End If

        Next
    End Sub

    Private Sub CreatePurchaseCredit(ByVal validationResult As Integer)
        Dim dvProcessData As DataView = DB.ImportValidation.POInvoiceImport_ShowData(validationResult)

        pbStatus.Value = 0
        pbStatus.Maximum = dvProcessData.Count + 1

        For Each dr As DataRow In dvProcessData.Table.Rows
            Dim insertDb As Boolean = True
            Dim orderId As Integer = Helper.MakeIntegerValid(dr("OrderID"))
            Dim requiresAuth As Boolean = Helper.MakeBooleanValid(dr("RequiresAuthorisation"))

            If orderId = 0 Then
                insertDb = False
                If requiresAuth Then
                    DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dr("ID"), requiresAuth)
                End If
                ShowMessage("An error has occurred:" & vbCrLf & "Unable to locate the OrderID for PO " & dr("PurchaseOrderNo") & ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MoveProgressOn(False)
            ElseIf Helper.MakeBooleanValid(dr("Exclude")) Then
                insertDb = False
            End If

            Dim orderStatusId As Integer = Helper.MakeIntegerValid(DB.ImportValidation.POInvoiceImport_GetOrderStatus(orderId))
            If orderStatusId = 1 Then
                insertDb = False
                ShowMessage("An error has occurred:" & vbCrLf & "Supplier Invoice for PO " & dr("PurchaseOrderNo") &
                            " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MoveProgressOn(False)
            End If

            If insertDb Then
                Dim order As Order = DB.Order.Order_Get(orderId)
                Dim taxCodeId As Integer
                Dim isSubby As Boolean = Helper.MakeBooleanValid(dr("SubContractor"))
                If isSubby AndAlso Helper.MakeDoubleValid(dr("TotalVatAmount")) = 0 Then
                    taxCodeId = CInt(Enums.PlVatRates.T9)
                ElseIf Helper.MakeDoubleValid(dr("TotalVatAmount")) > 0 Then
                    taxCodeId = CInt(Enums.PlVatRates.T1)
                Else
                    taxCodeId = CInt(Enums.PlVatRates.T0)
                End If

                Dim purchaseCredit As New PartsToBeCredited With {
                    .SetOrderID = orderId,
                    .SetOrderReference = order.OrderReference,
                    .SetSupplierID = Helper.MakeIntegerValid(dr("SupplierID")),
                    .SetStatusID = 3
                }

                Dim chargeNominal As String = ""
                If order?.OrderTypeID = Enums.OrderType.Job Then
                    Dim dtCharge As DataTable = DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(orderId)
                    If dtCharge.Rows.Count > 0 Then
                        chargeNominal = dtCharge.Rows(0).Item("ChargeNominalCode")
                    End If
                End If

                Dim dtPartsToCredit As New DataTable
                Dim dtInvoicedParts As DataTable = DB.ExecuteWithReturn("Select * from tblPOInvoiceImport_Parts Where InvoiceNo = '" & dr("InvoiceNo") & "'")

                Dim failed As Boolean = True
                For Each row As DataRow In dtInvoicedParts.Rows
                    'insert the parts to be credited
                    Dim part As Entity.Parts.Part = DB.Part.Part_Get_For_Code_And_Supplier(row("SupplierPartCode"), dr("SupplierID"))
                    Dim supplierPartId As Integer = -1
                    If part IsNot Nothing Then
                        supplierPartId = part.SPartID
                    End If

                    Dim dtOrderPart As DataTable = DB.ExecuteWithReturn("Select * From tblOrderPart Where OrderID = " & orderId & " AND PartSupplierID = " & supplierPartId)

                    If dtOrderPart.Rows.Count > 0 Then
                        failed = False
                        purchaseCredit.SetPartID = part.PartID
                        purchaseCredit.SetQty = row("Quantity")
                        purchaseCredit.SetCreditReceived = CDbl(row("NetAmount").ToString.Replace("-", ""))
                        purchaseCredit.SetPartOrderID = dtOrderPart.Rows(0)("OrderPartID")

                        dtPartsToCredit = DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(dtOrderPart.Rows(0)("OrderPartID")).Table
                        If dtPartsToCredit.Rows.Count > 0 Then 'Update
                            purchaseCredit.SetPartsToBeCreditedID = dtPartsToCredit.Rows(0)("PartsToBeCreditedID")
                            DB.PartsToBeCredited.Update(purchaseCredit)
                        Else
                            purchaseCredit = DB.PartsToBeCredited.Insert(purchaseCredit)
                        End If
                    End If
                Next  ' parts for invoice loop

                If failed = True Then  ' we couldnt match any parts it was a disaster so only option is add the credit against first part in order
                    Dim dtOrderPart As DataTable = DB.ExecuteWithReturn("Select Top (1) * From tblOrderPart Where OrderID = " & orderId)
                    Dim partid As Integer = DB.ExecuteScalar("Select Top (1) PartID From tblPartSupplier Where PartSupplierID = " & dtOrderPart.Rows(0)("PartSupplierID"))

                    purchaseCredit.SetPartID = partid
                    purchaseCredit.SetQty = 1
                    purchaseCredit.SetCreditReceived = CDbl(dr("TotalNetAmount").ToString.Replace("-", ""))
                    purchaseCredit.SetPartOrderID = dtOrderPart.Rows(0)("OrderPartID")
                    dtPartsToCredit = DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(dtOrderPart.Rows(0)("OrderPartID")).Table  'table containing the part in question

                    If dtPartsToCredit.Rows.Count > 0 Then 'Update
                        purchaseCredit.SetPartsToBeCreditedID = dtPartsToCredit.Rows(0)("PartsToBeCreditedID")
                        DB.PartsToBeCredited.Update(purchaseCredit)
                    Else ' Insert
                        purchaseCredit = DB.PartsToBeCredited.Insert(purchaseCredit)
                    End If
                End If

                If dtPartsToCredit.Rows.Count = 0 Then

                    Dim partcreditsID As Integer = DB.PartsToBeCredited.PartCredits_Insert(
                        CDbl(dr("TotalNetAmount").ToString.Replace("-", "")), "", dr("InvoiceDate"), Date.MinValue, taxCodeId, "5300",
                        order.DepartmentRef, chargeNominal, dr("InvoiceNo"))

                    DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" & partcreditsID & "," & purchaseCredit.PartsToBeCreditedID & ")")
                ElseIf IsDBNull(dtPartsToCredit.Rows(0)("PartCreditsID")) Then
                    Dim partcreditsID As Integer = DB.PartsToBeCredited.PartCredits_Insert(
                        CDbl(dr("TotalNetAmount").ToString.Replace("-", "")), "", dr("InvoiceDate").ToString, Date.MinValue, taxCodeId, "5300",
                        order.DepartmentRef, chargeNominal, dr("InvoiceNo"))

                    DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" & partcreditsID & "," & purchaseCredit.PartsToBeCreditedID & ")")
                Else
                    DB.PartsToBeCredited.PartCredits_Update(
                        dtPartsToCredit.Rows(0)("PartCreditsID"), CDbl(dr("TotalNetAmount").ToString.Replace("-", "")), "",
                        dr("InvoiceDate").ToString, Date.MinValue, taxCodeId, "5300",
                        order.DepartmentRef, chargeNominal, dr("InvoiceNo"))
                End If
                DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(dr("ID"), True)
                MoveProgressOn(False)

            End If
        Next
    End Sub

    Public Sub ShowData(Optional ByVal ValidateType As Integer = 0)
        Me.tcData.TabPages.Clear()

        Dim tp As New TabPage

        Dim data As New UCDataPartsInvoiceImport
        data.Dock = DockStyle.Fill
        data.Data = DB.ImportValidation.POInvoiceImport_ShowData(ValidateType)
        data.ValidateType = Combo.GetSelectedItemValue(cboValidateType)
        tp.Text = "Supplier Invoice Import Data (" & data.Data.Count & " Records)"

        tp.Controls.Add(data)
        Me.tcData.TabPages.Add(tp)
        Me.tcData.SelectedIndex = 0

        MoveProgressOn(True)
    End Sub

    Private Sub LoadData()
        Dim dlg As OpenFileDialog = Nothing
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

    Private Function IsFormValid() As Boolean
        If Helper.MakeIntegerValid(Supplier?.SupplierID) = 0 Then
            ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Helper.MakeIntegerValid(txtNominal.Text.Trim()) <= 0 Then
            ShowMessage("Please enter a numeric nominal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function

    Private Sub Import()
        If Not IsFormValid() Then Exit Sub
        NominalCode = txtNominal.Text.Trim()

        Dim success As Boolean = False
        lblMessages.Text = "Starting import..."
        lblMessages.Visible = True

        DuplicateInvoices.Clear()

        pbStatus.Value = 0
        pbStatus.Maximum = 1
        If PreImportData() Then
            Combo.SetSelectedComboItem_By_Value(cboValidateType, "0")
            'once import is completed show data imported
            ShowData()
            lblMessages.Text = "Import complete."
            lblMessages.Visible = True

            If DuplicateInvoices.Count > 0 Then
                Dim duplicates As New List(Of String)
                For Each duplicate As DuplicateInvoice In DuplicateInvoices
                    With duplicate
                        duplicates.Add("Invovice: " & .InvoiceNo & " InvoiceDate: " & .InvoiceDate & " PartCode:  " & .SupplierPartCode)
                    End With
                Next

                If ShowMessageWithDetails("Import Complete", "The following invoices are duplicates and have not been imported.", duplicates) = DialogResult.OK Then
                    Dim frmDuplicateInvoices As FRMDuplicateInvoices = New FRMDuplicateInvoices(DuplicateInvoices)
                    frmDuplicateInvoices.ShowDialog()
                End If
            Else
                ShowMessage("Import Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim filePath As String = TheSystem.Configuration.DocumentsLocation & "PartsInvoiceFiles\" & Supplier.Name.Replace("/", "").Replace("\", "") & "\Proccessed\"
            Directory.CreateDirectory(filePath)
            Dim fileType As String = Path.GetExtension(File.Name)
            IO.File.Move(File.FullName, filePath & File.Name.Replace(fileType, "_" & Now.ToString("ddMMyyHHmmss") & fileType))

            File = Nothing
            Me.txtExcelFile.Text = ""
            Me.txtNominal.Text = ""
            Supplier = Nothing
            NominalCode = Nothing

            Me.pbStatus.Value = Me.pbStatus.Maximum
            Me.btnFindExcelFile.Enabled = True
            Me.btnImport.Enabled = True
            Me.pbStatus.Value = 0

            'clear duplicate list
            DuplicateInvoices.Clear()
            Cursor.Current = Cursors.Default
        Else
            ShowMessage("Error uploading excel document", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Function PreImportData() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            lblMessages.Visible = True
            lblMessages.Text = "Downloading data from file..."
            Me.btnFindExcelFile.Enabled = False
            Me.btnImport.Enabled = False
            Me.pbStatus.Value = 0
            Application.DoEvents()

            Dim excel As ExcelQueryFactory = New ExcelQueryFactory(File.FullName)

            Dim obj As Object = From a In excel.Worksheet() Select a
            Dim ij As Object = excel.GetWorksheetNames()

            Dim columnNames As Object = excel.GetColumnNames("Sheet1")

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
            dt.Columns.Add("InvoiceNo")
            dt.Columns.Add("InvoiceDate")
            dt.Columns.Add("PurchaseOrderNo")
            dt.Columns.Add("SupplierPartCode")
            dt.Columns.Add("Description")
            dt.Columns.Add("Quantity")
            dt.Columns.Add("UnitPrice")
            dt.Columns.Add("NetAmount")
            dt.Columns.Add("VATAmount")
            dt.Columns.Add("GrossAmount")
            dt.Columns.Add("InsertDB")

            For Each row As DataRow In data.Rows
                Dim dr As DataRow = dt.NewRow()

                If row("Invoice Number") Is DBNull.Value Then
                    Continue For
                Else
                    dr("InvoiceNo") = Helper.MakeStringValid(row("Invoice Number")).Trim()
                End If

                If row("Invoice Date") Is DBNull.Value Then
                    Continue For
                Else
                    dr("InvoiceDate") = Helper.MakeStringValid(row("Invoice Date"))
                End If

                If row("Purchase Order Reference") Is DBNull.Value Then
                    Continue For
                Else
                    dr("PurchaseOrderNo") = Helper.MakeStringValid(row("Purchase Order Reference")).Trim()
                End If

                If row.Table.Columns.Contains("Product Code") Then dr("SupplierPartCode") = Helper.MakeStringValid(row("Product Code"))
                If row.Table.Columns.Contains("Product Description") Then dr("Description") = Helper.MakeStringValid(row("Product Description"))
                If row.Table.Columns.Contains("Quantity") Then dr("Quantity") = Helper.MakeStringValid(row("Quantity"))

                If row("Unit Price") Is DBNull.Value Then
                    Continue For
                Else
                    dr("UnitPrice") = Helper.MakeStringValid(row("Unit Price")).Trim()
                End If

                If row("Net Amount") Is DBNull.Value Then
                    Continue For
                Else
                    dr("NetAmount") = Helper.MakeStringValid(row("Net Amount")).Trim()
                End If

                If row("VAT Amount") Is DBNull.Value Then
                    Continue For
                Else
                    dr("VATAmount") = Helper.MakeStringValid(row("VAT Amount")).Trim()
                End If

                If row("Gross Amount") Is DBNull.Value Then
                    Continue For
                Else
                    dr("GrossAmount") = Helper.MakeStringValid(row("Gross Amount")).Trim()
                End If

                dr("InsertDB") = True
                dt.Rows.Add(dr)
            Next

            Try
                For Each row As DataRow In dt.Rows

                    Dim invoiceNo As String = Helper.MakeStringValid(row("InvoiceNo"))
                    Dim invoiceDate As DateTime = Helper.MakeDateTimeValid(row("InvoiceDate"))
                    Dim purchaseOrderNo As String = Helper.MakeStringValid(row("PurchaseOrderNo"))
                    Dim supplierPartCode As String = Helper.MakeStringValid(row("SupplierPartCode"))
                    Dim description As String = Helper.MakeStringValid(row("Description"))
                    Dim quantity As Integer = Helper.MakeIntegerValid(row("Quantity"))
                    Dim unitPrice As Double = Helper.MakeDoubleValid(row("UnitPrice"))
                    Dim netAmount As Double = Helper.MakeDoubleValid(row("NetAmount"))
                    Dim vatAmount As Double = Helper.MakeDoubleValid(row("VATAmount"))
                    Dim grossAmount As Double = Helper.MakeDoubleValid(row("GrossAmount"))

                    Dim hasOrderBeenSent As Integer = DB.ImportValidation.POInvoiceImport_CheckImportHasBeenSent(invoiceNo, invoiceDate, supplierPartCode)
                    If hasOrderBeenSent > 0 Then
                        row("InsertDB") = False
                        MoveProgressOn()
                        Continue For
                    End If

                    Dim importExists As Integer = DB.ImportValidation.POInvoiceImport_CheckImportInvoiceExists(invoiceNo, invoiceDate, supplierPartCode)
                    If importExists > 0 Then
                        Dim duplicate As New DuplicateInvoice With {
                            .PurchaseOrderNo = purchaseOrderNo,
                            .SupplierPartCode = supplierPartCode,
                            .Description = description,
                            .Quantity = quantity,
                            .UnitPrice = unitPrice,
                            .NetAmount = netAmount,
                            .VATAmount = vatAmount,
                            .GrossAmount = grossAmount,
                            .InvoiceNo = invoiceNo,
                            .InvoiceDate = invoiceDate,
                            .SupplierID = Supplier.SupplierID,
                            .TotalQtyOfParts = quantity
                        }
                        DuplicateInvoices.Add(duplicate)
                        row("InsertDB") = False
                    End If

                    If Helper.MakeBooleanValid(row("InsertDB")) Then
                        Dim orderId As Integer = DB.ImportValidation.Orders_GetID(purchaseOrderNo, Supplier.SupplierID, invoiceNo)
                        If orderId = 0 Then
                            orderId = DB.ImportValidation.POInvoiceImport_InsertOrder(invoiceNo, invoiceDate, purchaseOrderNo, Supplier.SupplierID, "Unspecified", NominalCode)
                        End If
                        DB.ImportValidation.POInvoiceImport_InsertPart(purchaseOrderNo, supplierPartCode, description, quantity, unitPrice, netAmount, vatAmount, grossAmount, invoiceNo)
                        DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(purchaseOrderNo, quantity, unitPrice, netAmount, vatAmount, grossAmount, quantity, invoiceNo)
                        If orderId > 0 Then
                            DB.ImportValidation.POInvoiceImport_ValidateOrder(orderId)
                        End If
                    End If
                Next

                MoveProgressOn(True)
                Return True
            Catch ex As Exception
                lblMessages.Visible = False
                Return False
            End Try
        Catch ex As Exception
            lblMessages.Visible = False
            Return False
        End Try

    End Function

    Private Sub FindSupplier()
        Dim ID As Integer = FindRecord(Enums.TableNames.tblSupplier, 1)
        If Not ID = 0 Then
            Supplier = DB.Supplier.Supplier_Get(ID)
        End If
    End Sub

    Private Sub lblDownloadTemplate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblDownloadTemplate.LinkClicked
        Dim dlg As FolderBrowserDialog = Nothing
        Dim oExcel As Excel.Application = Nothing
        Try
            Cursor.Current = Cursors.WaitCursor

            dlg = New FolderBrowserDialog
            If dlg.ShowDialog = DialogResult.OK Then
                oExcel = New Excel.Application
                oExcel.Workbooks.Add(Application.StartupPath & "\GenericDocuments\SupplierInvoiceImportTemplate.xlsx")
                If IO.File.Exists(dlg.SelectedPath & "\SupplierInvoiceImporter.xlsx") Then
                    IO.File.Delete(dlg.SelectedPath & "\SupplierInvoiceImporter.xlsx")
                End If
                oExcel.Workbooks.Item(1).SaveAs(dlg.SelectedPath & "\SupplierInvoiceImporter.xlsx")

                ShowMessage("File downloaded to " & dlg.SelectedPath & "\SupplierInvoiceImporter.xlsx", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ShowMessage("Template could not be saved : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            KillInstances(oExcel)
            dlg.Dispose()
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

    Public Sub ValidateOrder(ByVal ValidateType As Integer)
        lblMessages.Text = "Now validating orders, this can take up to two minutes. Please be patient."
        lblMessages.Visible = True
        Cursor.Current = Cursors.WaitCursor
        DB.ImportValidation.POInvoiceImport_ValidateOrders(Combo.GetSelectedItemValue(cboValidateType))
        ShowData(Combo.GetSelectedItemValue(cboValidateType))
        lblMessages.Text = "Validation complete."
        lblMessages.Visible = True
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ValidateAllRecords()
        lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient."
        lblMessages.Visible = True

        Cursor.Current = Cursors.WaitCursor
        Dim dvAllData As DataView = DB.ImportValidation.POInvoiceImport_ShowData_Mk1()
        Dim Steps As Integer = dvAllData.Count
        pbStatus.Value = 0
        pbStatus.Maximum = Steps + 1

        For Each dr As DataRow In dvAllData.Table.Rows
            Dim id As Integer = Helper.MakeIntegerValid(dr("ID"))
            DB.ImportValidation.POInvoiceImport_ValidateOrder(id)
            MoveProgressOn()
        Next

        Combo.SetSelectedComboItem_By_Value(cboValidateType, "0")
        ShowData()
        lblMessages.Text = "Validation complete."
        lblMessages.Visible = True
        Cursor.Current = Cursors.Default
    End Sub

#End Region

End Class