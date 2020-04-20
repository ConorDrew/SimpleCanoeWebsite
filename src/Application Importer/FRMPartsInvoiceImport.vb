Imports System.Collections.Generic

Public Class FRMPartsInvoiceImport : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Combo.SetUpCombo(Me.cboValidateType, DynamicDataTables.PartsInvoiceImportValidationResults, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        If Not loggedInUser.Fullname = "Hayleigh Mann" Then
            Button1.Visible = False
        End If
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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMessages As System.Windows.Forms.Label
    Friend WithEvents btnExportParts As System.Windows.Forms.LinkLabel
    Friend WithEvents btnCheckFiles As System.Windows.Forms.Button
    Friend WithEvents llOpenFolder As System.Windows.Forms.LinkLabel
    Friend WithEvents btnExportResults As System.Windows.Forms.Button
    Friend WithEvents cboValidateType As System.Windows.Forms.ComboBox
    Friend WithEvents btnProcessIndiv As System.Windows.Forms.Button
    Friend WithEvents grpCatImport As System.Windows.Forms.GroupBox
    Friend WithEvents btnValidateResults As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpExcelFile = New System.Windows.Forms.GroupBox()
        Me.btnExportResults = New System.Windows.Forms.Button()
        Me.btnCheckFiles = New System.Windows.Forms.Button()
        Me.tcData = New System.Windows.Forms.TabControl()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.btnExportParts = New System.Windows.Forms.LinkLabel()
        Me.llOpenFolder = New System.Windows.Forms.LinkLabel()
        Me.cboValidateType = New System.Windows.Forms.ComboBox()
        Me.btnProcessIndiv = New System.Windows.Forms.Button()
        Me.grpCatImport = New System.Windows.Forms.GroupBox()
        Me.btnValidateResults = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grpExcelFile.SuspendLayout()
        Me.grpCatImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpExcelFile
        '
        Me.grpExcelFile.Controls.Add(Me.btnExportResults)
        Me.grpExcelFile.Controls.Add(Me.btnCheckFiles)
        Me.grpExcelFile.Location = New System.Drawing.Point(8, 40)
        Me.grpExcelFile.Name = "grpExcelFile"
        Me.grpExcelFile.Size = New System.Drawing.Size(231, 57)
        Me.grpExcelFile.TabIndex = 3
        Me.grpExcelFile.TabStop = False
        Me.grpExcelFile.Text = "Initial Import"
        '
        'btnExportResults
        '
        Me.btnExportResults.Location = New System.Drawing.Point(118, 19)
        Me.btnExportResults.Name = "btnExportResults"
        Me.btnExportResults.Size = New System.Drawing.Size(106, 23)
        Me.btnExportResults.TabIndex = 5
        Me.btnExportResults.Text = "Export Results"
        Me.btnExportResults.UseVisualStyleBackColor = True
        '
        'btnCheckFiles
        '
        Me.btnCheckFiles.Location = New System.Drawing.Point(6, 20)
        Me.btnCheckFiles.Name = "btnCheckFiles"
        Me.btnCheckFiles.Size = New System.Drawing.Size(106, 23)
        Me.btnCheckFiles.TabIndex = 0
        Me.btnCheckFiles.Text = "Check Files"
        Me.btnCheckFiles.UseVisualStyleBackColor = True
        '
        'tcData
        '
        Me.tcData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcData.Location = New System.Drawing.Point(8, 103)
        Me.tcData.Name = "tcData"
        Me.tcData.SelectedIndex = 0
        Me.tcData.Size = New System.Drawing.Size(864, 483)
        Me.tcData.TabIndex = 8
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Location = New System.Drawing.Point(816, 621)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbStatus.Location = New System.Drawing.Point(8, 621)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(752, 23)
        Me.pbStatus.Step = 1
        Me.pbStatus.TabIndex = 10
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.Location = New System.Drawing.Point(768, 624)
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
        Me.lblMessages.Location = New System.Drawing.Point(5, 594)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(868, 19)
        Me.lblMessages.TabIndex = 12
        Me.lblMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMessages.Visible = False
        '
        'btnExportParts
        '
        Me.btnExportParts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportParts.Location = New System.Drawing.Point(690, 8)
        Me.btnExportParts.Name = "btnExportParts"
        Me.btnExportParts.Size = New System.Drawing.Size(88, 23)
        Me.btnExportParts.TabIndex = 13
        Me.btnExportParts.TabStop = True
        Me.btnExportParts.Text = "Export Parts"
        '
        'llOpenFolder
        '
        Me.llOpenFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.llOpenFolder.Location = New System.Drawing.Point(575, 8)
        Me.llOpenFolder.Name = "llOpenFolder"
        Me.llOpenFolder.Size = New System.Drawing.Size(88, 23)
        Me.llOpenFolder.TabIndex = 14
        Me.llOpenFolder.TabStop = True
        Me.llOpenFolder.Text = "Open Folders"
        '
        'cboValidateType
        '
        Me.cboValidateType.FormattingEnabled = True
        Me.cboValidateType.Location = New System.Drawing.Point(6, 21)
        Me.cboValidateType.Name = "cboValidateType"
        Me.cboValidateType.Size = New System.Drawing.Size(365, 21)
        Me.cboValidateType.TabIndex = 1
        '
        'btnProcessIndiv
        '
        Me.btnProcessIndiv.Location = New System.Drawing.Point(377, 19)
        Me.btnProcessIndiv.Name = "btnProcessIndiv"
        Me.btnProcessIndiv.Size = New System.Drawing.Size(345, 23)
        Me.btnProcessIndiv.TabIndex = 4
        Me.btnProcessIndiv.Text = "Process -->"
        Me.btnProcessIndiv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcessIndiv.UseVisualStyleBackColor = True
        '
        'grpCatImport
        '
        Me.grpCatImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCatImport.Controls.Add(Me.btnValidateResults)
        Me.grpCatImport.Controls.Add(Me.btnProcessIndiv)
        Me.grpCatImport.Controls.Add(Me.cboValidateType)

        Me.grpCatImport.Location = New System.Drawing.Point(245, 40)
        Me.grpCatImport.Name = "grpCatImport"
        Me.grpCatImport.Size = New System.Drawing.Size(627, 57)
        Me.grpCatImport.TabIndex = 6
        Me.grpCatImport.TabStop = False
        Me.grpCatImport.Text = "Category Processing"
        '
        'btnValidateResults
        '
        Me.btnValidateResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValidateResults.Location = New System.Drawing.Point(499, 19)
        Me.btnValidateResults.Name = "btnValidateResults"
        Me.btnValidateResults.Size = New System.Drawing.Size(122, 23)
        Me.btnValidateResults.TabIndex = 6
        Me.btnValidateResults.Text = "Revalidate Results"
        Me.btnValidateResults.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(403, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "ValidateOrdersNoParts"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FRMPartsInvoiceImport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(912, 654)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpCatImport)
        Me.Controls.Add(Me.llOpenFolder)
        Me.Controls.Add(Me.btnExportParts)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tcData)
        Me.Controls.Add(Me.grpExcelFile)
        Me.MinimumSize = New System.Drawing.Size(920, 688)
        Me.Name = "FRMPartsInvoiceImport"
        Me.Text = "(PII) Parts Invoice Import"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpExcelFile, 0)
        Me.Controls.SetChildIndex(Me.tcData, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.pbStatus, 0)
        Me.Controls.SetChildIndex(Me.lblProgress, 0)
        Me.Controls.SetChildIndex(Me.lblMessages, 0)
        Me.Controls.SetChildIndex(Me.btnExportParts, 0)
        Me.Controls.SetChildIndex(Me.llOpenFolder, 0)
        Me.Controls.SetChildIndex(Me.grpCatImport, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.grpExcelFile.ResumeLayout(False)
        Me.grpCatImport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Public ReadOnly Property LoadedControl() As IUserControl
        Get
            Return Nothing
        End Get
    End Property

    Private _duplicateInvoices As New List(Of Importer.DuplicateInvoice)

    Private Property DuplicateInvoices() As List(Of Importer.DuplicateInvoice)
        Get
            Return _duplicateInvoices
        End Get
        Set(ByVal value As List(Of Importer.DuplicateInvoice))
            _duplicateInvoices = value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub cboValidateType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboValidateType.SelectedIndexChanged
        ShowData(Combo.GetSelectedItemValue(cboValidateType))
        Select Case Combo.GetSelectedItemValue(cboValidateType)
            Case 0 'nothing
                btnProcessIndiv.Visible = False
            Case 1 'Replenishment
                btnProcessIndiv.Visible = False
            Case 2 'Unable to locate PO
                btnProcessIndiv.Visible = False
            Case 3 'Matched PO
                btnProcessIndiv.Visible = True
                btnProcessIndiv.Text = "Update PO's With Invoice Details -->"
            Case 4 'Matched PO Price Above
                btnProcessIndiv.Visible = True
                btnProcessIndiv.Text = "Update PO's With Invoice Details -->"
            Case 5 'Matched PO Price Below
                btnProcessIndiv.Visible = True
                btnProcessIndiv.Text = "Update PO's With Invoice Details -->"
            Case 6 'Purchase Credits
                btnProcessIndiv.Visible = True
                btnProcessIndiv.Text = "Update PO's With Invoice Details -->"
            Case 7 'Supplier Invoice Created
                btnProcessIndiv.Visible = False
                btnProcessIndiv.Text = "Remove Records -->"
            Case 8 'Matched PO no parts added so no cost
                btnProcessIndiv.Visible = False
                btnProcessIndiv.Text = "Update PO's With Included Parts and Invoice Details -->"
            Case 9 'SentToSage
                btnProcessIndiv.Visible = False
                btnProcessIndiv.Text = "Remove Records -->"
            Case 10 'Visit not done
                btnProcessIndiv.Visible = False
                ' btnProcessIndiv.Text = "Remove Records -->"
            Case 14 'Matched PO no parts added so no cost
                btnProcessIndiv.Visible = False
        End Select
    End Sub

    Private Sub btnProcessIndiv_Click(sender As System.Object, e As System.EventArgs) Handles btnProcessIndiv.Click
        Select Case Combo.GetSelectedItemValue(cboValidateType)
            Case 2 'Unable to Locate PO
                Cursor.Current = Cursors.WaitCursor
                ValidateOrder(Combo.GetSelectedItemValue(cboValidateType))

                MoveProgressOn(True)
                ShowData(Combo.GetSelectedItemValue(cboValidateType))
                Cursor.Current = Cursors.Default
            Case 3 'Matched PO Exactly

                Cursor.Current = Cursors.WaitCursor
                'get my datatable and loop round

                Dim dvProcessData As DataView
                dvProcessData = DB.ImportValidation.POInvoiceImport_ShowData(Combo.GetSelectedItemValue(cboValidateType))

                pbStatus.Value = 0
                pbStatus.Maximum = dvProcessData.Count + 1

                For i As Integer = 0 To dvProcessData.Count - 1
                    Dim InsertDB As Boolean = True
                    If dvProcessData.Table().Rows(i)("OrderID").ToString = "" Then
                        InsertDB = False
                        ShowMessage("An error has occurred:" & vbCrLf & "Unable to locate the OrderID for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                        'Exit Sub
                    ElseIf dvProcessData.Table().Rows(i)("Exclude").ToString = "True" Then 'excluded
                        InsertDB = False
                    End If

                    'get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                    Dim OrderStatusID As Integer = 0
                    OrderStatusID = DB.ImportValidation.POInvoiceImport_GetOrderStatus(dvProcessData.Table().Rows(i)("OrderID").ToString)
                    If OrderStatusID = 1 Then
                        InsertDB = False
                        ShowMessage("An error has occurred:" & vbCrLf & "Supplier Invoice for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                    End If

                    If InsertDB = True Then
                        Dim orderId As Integer = Entity.Sys.Helper.MakeIntegerValid(
                            dvProcessData.Table().Rows(i)("OrderID"))
                        Dim oOrder As Entity.Orders.Order = DB.Order.Order_Get(dvProcessData.Table().Rows(i)("OrderID").ToString)

                        Dim oSupplierInvoice As New Entity.Orders.SupplierInvoice
                        oSupplierInvoice.SetOrderID = dvProcessData.Table().Rows(i)("OrderID").ToString
                        oSupplierInvoice.SetInvoiceReference = dvProcessData.Table().Rows(i)("InvoiceNo").ToString
                        oSupplierInvoice.SetInvoiceDate = dvProcessData.Table().Rows(i)("InvoiceDate").ToString
                        oSupplierInvoice.SetGoodsAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalGrossAmount").ToString)
                        oSupplierInvoice.SetVATAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalVatAmount").ToString)
                        oSupplierInvoice.SetTotalAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalNetAmount").ToString)
                        oSupplierInvoice.SetTaxCodeID = 5373
                        oSupplierInvoice.SetNominalCode = GetNominalCode(orderId:=orderId)

                        If Not oOrder Is Nothing Then
                            If oOrder.OrderTypeID = Entity.Sys.Enums.OrderType.Job Then
                                Dim dtCharge As DataTable = DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID)
                                If dtCharge.Rows.Count > 0 Then
                                    Dim ChargeNominalCode As String = dtCharge.Rows(0).Item("ChargeNominalCode")
                                    If ChargeNominalCode = 0 Then
                                        oSupplierInvoice.SetExtraRef = "."
                                    Else
                                        oSupplierInvoice.SetExtraRef = ChargeNominalCode
                                    End If
                                Else
                                    oSupplierInvoice.SetExtraRef = "."
                                End If
                            Else
                                oSupplierInvoice.SetExtraRef = "."
                            End If
                        Else
                            oSupplierInvoice.SetExtraRef = "."
                        End If

                        oSupplierInvoice.SetReadyToSendToSage = True
                        oSupplierInvoice.SetSentToSage = 0
                        oSupplierInvoice.SetOldSystemInvoice = 0
                        oSupplierInvoice.SetDateExported = Nothing
                        oSupplierInvoice.SetKeyedBy = loggedInUser.UserID

                        Try
                            DB.SupplierInvoices.Insert(oSupplierInvoice)
                            DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(dvProcessData.Table().Rows(i)("ID").ToString, True)
                            Dim RequiresAuth As Boolean = CBool(dvProcessData.Table().Rows(i)("RequiresAuthorisation").ToString)
                            If RequiresAuth = True Then
                                DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dvProcessData.Table().Rows(i)("ID").ToString, RequiresAuth)
                            Else
                                DB.ImportValidation.POInvoiceImport_UpdateValidationType(dvProcessData.Table().Rows(i)("ID").ToString, 7)
                            End If
                        Catch ex As Exception
                            ShowMessage("An error has occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        MoveProgressOn(False)
                    End If
                Next
                ValidateAllRecords()
                ShowData(Combo.GetSelectedItemValue(cboValidateType))
                Cursor.Current = Cursors.Default
            Case 4 'Matched PO Price Above
                Cursor.Current = Cursors.WaitCursor
                'get my datatable and loop round

                Dim dvProcessData As DataView
                dvProcessData = DB.ImportValidation.POInvoiceImport_ShowData(Combo.GetSelectedItemValue(cboValidateType))

                pbStatus.Value = 0
                pbStatus.Maximum = dvProcessData.Count + 1

                For i As Integer = 0 To dvProcessData.Count - 1
                    Dim InsertDB As Boolean = True
                    If dvProcessData.Table().Rows(i)("OrderID").ToString = "" Then
                        InsertDB = False
                        ShowMessage("An error has occurred:" & vbCrLf & "Unable to locate the OrderID for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                        'Exit Sub
                    ElseIf dvProcessData.Table().Rows(i)("Exclude").ToString = "True" Then 'excluded
                        InsertDB = False
                    End If

                    'get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                    Dim OrderStatusID As Integer = 0
                    OrderStatusID = DB.ImportValidation.POInvoiceImport_GetOrderStatus(dvProcessData.Table().Rows(i)("OrderID").ToString)
                    If OrderStatusID = 1 Then
                        InsertDB = False
                        Dim RequiresAuth As Boolean = CBool(dvProcessData.Table().Rows(i)("RequiresAuthorisation").ToString)
                        If RequiresAuth = True Then
                            DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dvProcessData.Table().Rows(i)("ID").ToString, RequiresAuth)
                        End If
                        ShowMessage("An error has occurred:" & vbCrLf & "Supplier Invoice for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                    End If

                    If InsertDB = True Then
                        Dim orderId As Integer = Entity.Sys.Helper.MakeIntegerValid(
                            dvProcessData.Table().Rows(i)("OrderID"))
                        Dim oOrder As Entity.Orders.Order = DB.Order.Order_Get(dvProcessData.Table().Rows(i)("OrderID").ToString)

                        Dim oSupplierInvoice As New Entity.Orders.SupplierInvoice
                        oSupplierInvoice.SetOrderID = dvProcessData.Table().Rows(i)("OrderID").ToString
                        oSupplierInvoice.SetInvoiceReference = dvProcessData.Table().Rows(i)("InvoiceNo").ToString
                        oSupplierInvoice.SetInvoiceDate = dvProcessData.Table().Rows(i)("InvoiceDate").ToString
                        oSupplierInvoice.SetGoodsAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalGrossAmount").ToString)
                        oSupplierInvoice.SetVATAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalVatAmount").ToString)
                        oSupplierInvoice.SetTotalAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalNetAmount").ToString)
                        oSupplierInvoice.SetTaxCodeID = 5373
                        oSupplierInvoice.SetNominalCode = GetNominalCode(orderId)
                        'oSupplierInvoice.SetExtraRef = "."

                        If Not oOrder Is Nothing Then
                            If oOrder.OrderTypeID = Entity.Sys.Enums.OrderType.Job Then
                                Dim dtCharge As DataTable = DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID)
                                If dtCharge.Rows.Count > 0 Then
                                    Dim ChargeNominalCode As String = dtCharge.Rows(0).Item("ChargeNominalCode")
                                    If ChargeNominalCode = 0 Then
                                        oSupplierInvoice.SetExtraRef = "."
                                    Else
                                        oSupplierInvoice.SetExtraRef = ChargeNominalCode
                                    End If
                                Else
                                    oSupplierInvoice.SetExtraRef = "."
                                End If
                            Else
                                oSupplierInvoice.SetExtraRef = "."
                            End If
                        Else
                            oSupplierInvoice.SetExtraRef = "."
                        End If

                        oSupplierInvoice.SetReadyToSendToSage = True
                        oSupplierInvoice.SetSentToSage = 0
                        oSupplierInvoice.SetOldSystemInvoice = 0
                        oSupplierInvoice.SetDateExported = Nothing
                        oSupplierInvoice.SetKeyedBy = loggedInUser.UserID

                        Try
                            DB.SupplierInvoices.Insert(oSupplierInvoice)
                            DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(dvProcessData.Table().Rows(i)("ID").ToString, True)
                            Dim RequiresAuth As Boolean = CBool(dvProcessData.Table().Rows(i)("RequiresAuthorisation").ToString)
                            If RequiresAuth = True Then
                                DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dvProcessData.Table().Rows(i)("ID").ToString, RequiresAuth)
                            Else
                                DB.ImportValidation.POInvoiceImport_UpdateValidationType(dvProcessData.Table().Rows(i)("ID").ToString, 7)
                            End If
                        Catch ex As Exception
                            ShowMessage("An error has occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        MoveProgressOn(False)
                    End If
                Next
                ValidateAllRecords()
                ShowData(Combo.GetSelectedItemValue(cboValidateType))
                Cursor.Current = Cursors.Default

            Case 6 'Credits
                Cursor.Current = Cursors.WaitCursor
                'get my datatable and loop round

                Dim dvProcessData As DataView
                dvProcessData = DB.ImportValidation.POInvoiceImport_ShowData(Combo.GetSelectedItemValue(cboValidateType))

                pbStatus.Value = 0
                pbStatus.Maximum = dvProcessData.Count + 1

                For i As Integer = 0 To dvProcessData.Count - 1
                    Dim InsertDB As Boolean = True
                    If dvProcessData.Table().Rows(i)("OrderID").ToString = "" Then
                        InsertDB = False
                        Dim RequiresAuth As Boolean = CBool(dvProcessData.Table().Rows(i)("RequiresAuthorisation").ToString)
                        If RequiresAuth = True Then
                            DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dvProcessData.Table().Rows(i)("ID").ToString, RequiresAuth)
                        End If
                        ShowMessage("An error has occurred:" & vbCrLf & "Unable to locate the OrderID for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                        'Exit Sub
                    ElseIf dvProcessData.Table().Rows(i)("Exclude").ToString = "True" Then 'excluded
                        InsertDB = False
                    End If

                    'get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                    Dim OrderStatusID As Integer = 0
                    OrderStatusID = DB.ImportValidation.POInvoiceImport_GetOrderStatus(dvProcessData.Table().Rows(i)("OrderID").ToString)
                    If OrderStatusID = 1 Then
                        InsertDB = False
                        ShowMessage("An error has occurred:" & vbCrLf & "Supplier Invoice for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                    End If

                    If InsertDB = True Then
                        Dim oOrder As Entity.Orders.Order = DB.Order.Order_Get(dvProcessData.Table().Rows(i)("OrderID").ToString)
                        Dim OrderID As Integer = dvProcessData.Table().Rows(i)("OrderID").ToString
                        Dim CreditReference As String = dvProcessData.Table().Rows(i)("InvoiceNo").ToString
                        Dim CreditReceivedDate As String = dvProcessData.Table().Rows(i)("InvoiceDate").ToString
                        Dim Amount As String = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalGrossAmount").ToString)

                        Dim TaxCodeID As Integer = 5373
                        Dim NominalCode As Integer = GetNominalCode(OrderID)
                        'oCredit.SetExtraRef = "."
                        Dim ChargeNominalCode As String = ""
                        If Not oOrder Is Nothing Then
                            If oOrder.OrderTypeID = Entity.Sys.Enums.OrderType.Job Then
                                Dim dtCharge As DataTable = DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID)
                                If dtCharge.Rows.Count > 0 Then
                                    ChargeNominalCode = dtCharge.Rows(0).Item("ChargeNominalCode")
                                    If ChargeNominalCode = 0 Then
                                        ChargeNominalCode = ""
                                    Else

                                    End If
                                Else

                                End If
                            Else

                            End If
                        Else
                        End If

                        Dim oCredit As New Entity.PartsToBeCrediteds.PartsToBeCredited
                        oCredit = New Entity.PartsToBeCrediteds.PartsToBeCredited
                        oCredit.SetOrderID = OrderID
                        oCredit.SetOrderReference = DB.Order.Order_Get(OrderID).OrderReference
                        Dim dept As Integer = DB.Order.Order_Get(OrderID).DepartmentRef
                        Dim dtc As New DataTable
                        Dim dt As DataTable = DB.ExecuteWithReturn("Select * from tblPOInvoiceImport_Parts Where InvoiceNo = '" &
                                                                   dvProcessData.Table().Rows(i)("InvoiceNo").ToString & "'")

                        Dim failed As Boolean = True
                        For Each row As DataRow In dt.Rows
                            'insert the parts to be credited
                            Dim part As Entity.Parts.Part = DB.Part.Part_Get_For_Code_And_Supplier(row("SupplierPartCode"),
                                                                                                   dvProcessData.Table().Rows(i)("SupplierID"))
                            Dim sPartID As Integer = -1
                            If part Is Nothing Then
                                sPartID = -1
                            Else
                                sPartID = part.SPartID
                            End If

                            Dim InOrder As DataTable = DB.ExecuteWithReturn("Select * From tblOrderPart Where OrderID = " & OrderID & " AND PartSupplierID = " & sPartID)

                            If InOrder.Rows.Count > 0 Then
                                failed = False
                                oCredit.SetPartID = part.PartID
                                oCredit.SetQty = row("Quantity")
                                oCredit.SetCreditReceived = CDbl(row("NetAmount").ToString.Replace("-", ""))
                                oCredit.SetStatusID = 3
                                oCredit.SetSupplierID = dvProcessData.Table().Rows(i)("SupplierID")
                                oCredit.SetPartOrderID = InOrder.Rows(0)("OrderPartID")
                                dtc = DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(InOrder.Rows(0)("OrderPartID")).Table
                                If dtc.Rows.Count > 0 Then 'Update
                                    oCredit.SetPartsToBeCreditedID = dtc.Rows(0)("PartsToBeCreditedID")
                                    DB.PartsToBeCredited.Update(oCredit)
                                Else ' Insert
                                    oCredit = DB.PartsToBeCredited.Insert(oCredit)
                                End If
                            End If
                        Next  ' parts for invoice loop

                        If failed = True Then  ' we couldnt match any parts it was a disaster so only option is add the credit against first part in order
                            Dim InOrder As DataTable = DB.ExecuteWithReturn("Select Top (1) * From tblOrderPart Where OrderID = " & OrderID)
                            Dim partid As Integer = DB.ExecuteScalar("Select Top (1) PartID From tblPartSupplier Where PartSupplierID = " & InOrder.Rows(0)("PartSupplierID"))

                            oCredit.SetPartID = partid
                            oCredit.SetQty = 1
                            oCredit.SetCreditReceived = CDbl(dvProcessData.Table().Rows(i)("TotalNetAmount").ToString.Replace("-", ""))
                            oCredit.SetStatusID = 3
                            oCredit.SetSupplierID = dvProcessData.Table().Rows(i)("SupplierID")
                            oCredit.SetPartOrderID = InOrder.Rows(0)("OrderPartID")
                            dtc = DB.PartsToBeCredited.PartsToBeCredited_Get_OrderPartID(InOrder.Rows(0)("OrderPartID")).Table  'table containing the part in question

                            If dtc.Rows.Count > 0 Then 'Update
                                oCredit.SetPartsToBeCreditedID = dtc.Rows(0)("PartsToBeCreditedID")
                                DB.PartsToBeCredited.Update(oCredit)
                            Else ' Insert
                                oCredit = DB.PartsToBeCredited.Insert(oCredit)
                            End If
                        End If

                        If dtc.Rows.Count = 0 Then

                            Dim partcreditsID As Integer = DB.PartsToBeCredited.PartCredits_Insert(
                                CDbl(dvProcessData.Table().Rows(i)("TotalNetAmount").ToString.Replace("-", "")), "",
                                dvProcessData.Table().Rows(i)("InvoiceDate").ToString, Date.MinValue, TaxCodeID, "5300",
                                dept, ChargeNominalCode, dvProcessData.Table().Rows(i)("InvoiceNo").ToString)

                            DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" & partcreditsID & "," & oCredit.PartsToBeCreditedID & ")")
                        ElseIf IsDBNull(dtc.Rows(0)("PartCreditsID")) Then
                            Dim partcreditsID As Integer = DB.PartsToBeCredited.PartCredits_Insert(
                                CDbl(dvProcessData.Table().Rows(i)("TotalNetAmount").ToString.Replace("-", "")), "",
                                dvProcessData.Table().Rows(i)("InvoiceDate").ToString, Date.MinValue, TaxCodeID, "5300",
                                dept, ChargeNominalCode, dvProcessData.Table().Rows(i)("InvoiceNo").ToString)

                            DB.ExecuteScalar("INSERT INTO tblPartCreditParts (PartCreditID,PartsToBeCreditedID) VALUES (" & partcreditsID & "," & oCredit.PartsToBeCreditedID & ")")
                        Else
                            DB.PartsToBeCredited.PartCredits_Update(
                                dtc.Rows(0)("PartCreditsID"), CDbl(dvProcessData.Table().Rows(i)("TotalNetAmount").ToString.Replace("-", "")), "",
                                dvProcessData.Table().Rows(i)("InvoiceDate").ToString, Date.MinValue, TaxCodeID, "5300",
                                dept, ChargeNominalCode, dvProcessData.Table().Rows(i)("InvoiceNo").ToString)
                        End If
                        DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(dvProcessData.Table().Rows(i)("ID").ToString, True)
                        MoveProgressOn(False)
                    End If
                Next  ' next credit
                'ValidateAllRecords()
                ShowData(Combo.GetSelectedItemValue(cboValidateType))
                Cursor.Current = Cursors.Default
            Case 5 'Matched PO Price Below

                Cursor.Current = Cursors.WaitCursor
                'get my datatable and loop round

                Dim dvProcessData As DataView
                dvProcessData = DB.ImportValidation.POInvoiceImport_ShowData(Combo.GetSelectedItemValue(cboValidateType))
                pbStatus.Value = 0
                pbStatus.Maximum = dvProcessData.Count + 1

                For i As Integer = 0 To dvProcessData.Count - 1
                    Dim InsertDB As Boolean = True
                    If dvProcessData.Table().Rows(i)("OrderID").ToString = "" Then
                        InsertDB = False
                        ShowMessage("An error has occurred:" & vbCrLf & "Unable to locate the OrderID for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                        'Exit Sub
                    ElseIf dvProcessData.Table().Rows(i)("Exclude").ToString = "True" Then 'excluded
                        InsertDB = False
                    End If

                    'get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                    Dim OrderStatusID As Integer = 0
                    OrderStatusID = DB.ImportValidation.POInvoiceImport_GetOrderStatus(dvProcessData.Table().Rows(i)("OrderID").ToString)
                    If OrderStatusID = 1 Then
                        InsertDB = False
                        ShowMessage("An error has occurred:" & vbCrLf & "Supplier Invoice for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                    End If

                    If InsertDB = True Then
                        Dim orderId As Integer = Entity.Sys.Helper.MakeIntegerValid(
                            dvProcessData.Table().Rows(i)("OrderID"))
                        Dim oOrder As Entity.Orders.Order = DB.Order.Order_Get(dvProcessData.Table().Rows(i)("OrderID").ToString)

                        Dim oSupplierInvoice As New Entity.Orders.SupplierInvoice
                        oSupplierInvoice.SetOrderID = dvProcessData.Table().Rows(i)("OrderID").ToString
                        oSupplierInvoice.SetInvoiceReference = dvProcessData.Table().Rows(i)("InvoiceNo").ToString
                        oSupplierInvoice.SetInvoiceDate = dvProcessData.Table().Rows(i)("InvoiceDate").ToString
                        oSupplierInvoice.SetGoodsAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalGrossAmount").ToString)
                        oSupplierInvoice.SetVATAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalVatAmount").ToString)
                        oSupplierInvoice.SetTotalAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalNetAmount").ToString)
                        oSupplierInvoice.SetTaxCodeID = 5373
                        oSupplierInvoice.SetNominalCode = GetNominalCode(orderId)

                        If Not oOrder Is Nothing Then
                            If oOrder.OrderTypeID = Entity.Sys.Enums.OrderType.Job Then
                                Dim dtCharge As DataTable = DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID)
                                If dtCharge.Rows.Count > 0 Then
                                    Dim ChargeNominalCode As String = dtCharge.Rows(0).Item("ChargeNominalCode")
                                    If ChargeNominalCode = 0 Then
                                        oSupplierInvoice.SetExtraRef = "."
                                    Else
                                        oSupplierInvoice.SetExtraRef = ChargeNominalCode
                                    End If
                                Else
                                    oSupplierInvoice.SetExtraRef = "."
                                End If
                            Else
                                oSupplierInvoice.SetExtraRef = "."
                            End If
                        Else
                            oSupplierInvoice.SetExtraRef = "."
                        End If

                        oSupplierInvoice.SetReadyToSendToSage = True
                        oSupplierInvoice.SetSentToSage = 0
                        oSupplierInvoice.SetOldSystemInvoice = 0
                        oSupplierInvoice.SetDateExported = Nothing
                        oSupplierInvoice.SetKeyedBy = loggedInUser.UserID

                        Try
                            DB.SupplierInvoices.Insert(oSupplierInvoice)
                            DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(dvProcessData.Table().Rows(i)("ID").ToString, True)
                            Dim RequiresAuth As Boolean = CBool(dvProcessData.Table().Rows(i)("RequiresAuthorisation").ToString)
                            If RequiresAuth = True Then
                                DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dvProcessData.Table().Rows(i)("ID").ToString, RequiresAuth)
                            Else
                                DB.ImportValidation.POInvoiceImport_UpdateValidationType(dvProcessData.Table().Rows(i)("ID").ToString, 7)
                            End If
                        Catch ex As Exception
                            ShowMessage("An error has occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        MoveProgressOn(False)
                    End If
                Next
                ValidateAllRecords()
                ShowData(Combo.GetSelectedItemValue(cboValidateType))
                Cursor.Current = Cursors.Default
            Case 7 'Supplier Invoice Created
                btnProcessIndiv.Visible = False
                btnProcessIndiv.Text = "Remove Records -->"
            Case 8 'Matched PO no parts added so no cost, add parts and invoice
                Cursor.Current = Cursors.WaitCursor
                'get my datatable and loop round

                Dim dvProcessData As DataView
                dvProcessData = DB.ImportValidation.POInvoiceImport_ShowData(Combo.GetSelectedItemValue(cboValidateType))
                pbStatus.Value = 0
                pbStatus.Maximum = dvProcessData.Count + 1

                For i As Integer = 0 To dvProcessData.Count - 1
                    Dim InsertDB As Boolean = True
                    If dvProcessData.Table().Rows(i)("OrderID").ToString = "" Then
                        InsertDB = False
                        Dim RequiresAuth As Boolean = CBool(dvProcessData.Table().Rows(i)("RequiresAuthorisation").ToString)
                        If RequiresAuth = True Then
                            DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dvProcessData.Table().Rows(i)("ID").ToString, RequiresAuth)
                        End If
                        ShowMessage("An error has occurred:" & vbCrLf & "Unable to locate the OrderID for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    ", please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                        'Exit Sub
                    ElseIf dvProcessData.Table().Rows(i)("Exclude").ToString = "True" Then 'excluded
                        InsertDB = False
                    End If

                    'get the PO Status and check to see if Awaiting Confirmation OrderStatusID = 1
                    Dim OrderStatusID As Integer = 0
                    OrderStatusID = DB.ImportValidation.POInvoiceImport_GetOrderStatus(dvProcessData.Table().Rows(i)("OrderID").ToString)
                    If OrderStatusID = 1 Then
                        InsertDB = False
                        ShowMessage("An error has occurred:" & vbCrLf & "Supplier Invoice for PO " & dvProcessData.Table().Rows(i)("PurchaseOrderNo").ToString &
                                    " cannot be processed as the Status is set to Awaiting Confirmation, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MoveProgressOn(False)
                    End If

                    If InsertDB = True Then
                        Dim orderId As Integer = Entity.Sys.Helper.MakeIntegerValid(
                            dvProcessData.Table().Rows(i)("OrderID"))
                        Dim oOrder As Entity.Orders.Order = DB.Order.Order_Get(dvProcessData.Table().Rows(i)("OrderID").ToString)

                        Dim oSupplierInvoice As New Entity.Orders.SupplierInvoice
                        oSupplierInvoice.SetOrderID = dvProcessData.Table().Rows(i)("OrderID").ToString
                        oSupplierInvoice.SetInvoiceReference = dvProcessData.Table().Rows(i)("InvoiceNo").ToString
                        oSupplierInvoice.SetInvoiceDate = dvProcessData.Table().Rows(i)("InvoiceDate").ToString
                        oSupplierInvoice.SetGoodsAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalGrossAmount").ToString)
                        oSupplierInvoice.SetVATAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalVatAmount").ToString)
                        oSupplierInvoice.SetTotalAmount = Convert.ToDouble(dvProcessData.Table().Rows(i)("TotalNetAmount").ToString)
                        oSupplierInvoice.SetTaxCodeID = 5373
                        oSupplierInvoice.SetNominalCode = GetNominalCode(orderId)
                        'oSupplierInvoice.SetExtraRef = "."

                        If Not oOrder Is Nothing Then
                            If oOrder.OrderTypeID = Entity.Sys.Enums.OrderType.Job Then
                                Dim dtCharge As DataTable = DB.Invoiced.GetJobNominalCode_ForSupplierInvoice(oOrder.OrderID)
                                If dtCharge.Rows.Count > 0 Then
                                    Dim ChargeNominalCode As String = dtCharge.Rows(0).Item("ChargeNominalCode")
                                    If ChargeNominalCode = 0 Then
                                        oSupplierInvoice.SetExtraRef = "."
                                    Else
                                        oSupplierInvoice.SetExtraRef = ChargeNominalCode
                                    End If
                                Else
                                    oSupplierInvoice.SetExtraRef = "."
                                End If
                            Else
                                oSupplierInvoice.SetExtraRef = "."
                            End If
                        Else
                            oSupplierInvoice.SetExtraRef = "."
                        End If

                        oSupplierInvoice.SetReadyToSendToSage = True
                        oSupplierInvoice.SetSentToSage = 0
                        oSupplierInvoice.SetOldSystemInvoice = 0
                        oSupplierInvoice.SetDateExported = Nothing
                        oSupplierInvoice.SetKeyedBy = loggedInUser.UserID

                        Try
                            DB.SupplierInvoices.Insert(oSupplierInvoice)
                            DB.ImportValidation.POInvoiceImport_UpdateSupplierInvoiceCreated(dvProcessData.Table().Rows(i)("ID").ToString, True)

                            Dim RequiresAuth As Boolean = CBool(dvProcessData.Table().Rows(i)("RequiresAuthorisation").ToString)
                            If RequiresAuth = True Then
                                DB.ImportValidation.POInvoiceImport_UpdateRequiresAuthorisation(dvProcessData.Table().Rows(i)("ID").ToString, RequiresAuth)
                            Else
                                DB.ImportValidation.POInvoiceImport_UpdateValidationType(dvProcessData.Table().Rows(i)("ID").ToString, 7)
                            End If
                        Catch ex As Exception
                            ShowMessage("An error has occurred:" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        MoveProgressOn(False)
                    End If
                Next
                'ValidateAllRecords()
                ShowData(Combo.GetSelectedItemValue(cboValidateType))
                Cursor.Current = Cursors.Default
            Case 9 'SentToSage

        End Select
    End Sub

    Public Sub ValidateAllRecords()
        'ShowMessage("Validation can take up to two minutes.  The progress bar at the bottom will not increase during this time.  Please be patient.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient."
        lblMessages.Visible = True

        Cursor.Current = Cursors.WaitCursor
        Dim dvAllData As DataView = DB.ImportValidation.POInvoiceImport_ShowData_Mk1()
        Dim Steps As Integer = dvAllData.Count 'RD
        pbStatus.Value = 0
        pbStatus.Maximum = Steps + 1

        For Each dr As DataRow In dvAllData.Table.Rows
            Dim id As Integer = Entity.Sys.Helper.MakeIntegerValid(dr("ID"))
            DB.ImportValidation.POInvoiceImport_ValidateOrder(id) ' Then 'Then Debugger.Break()
            MoveProgressOn()
        Next

        Combo.SetSelectedComboItem_By_Value(cboValidateType, "0")
        ShowData()
        lblMessages.Text = "Validation complete."
        lblMessages.Visible = True
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ValidateCurrentlyDisplayedRecords()
        'ShowMessage("Validation can take up to two minutes.  The progress bar at the bottom will not increase during this time.  Please be patient.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        lblMessages.Text = "Now validating records, this can take up to two minutes. Please be patient."
        lblMessages.Visible = True
        Cursor.Current = Cursors.WaitCursor
        DB.ImportValidation.POInvoiceImport_ValidateOrders(Combo.GetSelectedItemValue(cboValidateType))
        ShowData(Combo.GetSelectedItemValue(cboValidateType))
        lblMessages.Text = "Validation complete."
        lblMessages.Visible = True
        Cursor.Current = Cursors.Default
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

    Private Sub btnCheckFiles_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckFiles.Click
        lblMessages.Text = "Starting import..."
        lblMessages.Visible = True

        'clear duplicate records list
        DuplicateInvoices.Clear()

        pbStatus.Value = 0
        pbStatus.Maximum = 1
        PreImportData()

        Combo.SetSelectedComboItem_By_Value(cboValidateType, "0")
        'once import is completed show data imported
        ShowData()
        lblMessages.Text = "Import complete."
        lblMessages.Visible = True

        'validate all
        'ValidateAllRecords()

        'if we have duplicates display them to user
        If DuplicateInvoices.Count > 0 Then
            Dim duplicates As New List(Of String)
            For Each duplicate As Importer.DuplicateInvoice In DuplicateInvoices
                With duplicate
                    duplicates.Add("Invovice: " & .InvoiceNo &
                               " InvoiceDate: " & .InvoiceDate &
                               " PartCode:  " & .SupplierPartCode)
                End With
            Next

            If ShowMessageWithDetails("Import Complete", "The following invoices are duplicates and have not been imported.", duplicates) = DialogResult.OK Then
                Dim frmDuplicateInvoices As FRMDuplicateInvoices = New FRMDuplicateInvoices(DuplicateInvoices)
                frmDuplicateInvoices.ShowDialog()
            End If
        Else
            ShowMessage("Import Completed!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'clear duplicate list
        DuplicateInvoices.Clear()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub PreImportData()
        Dim oExcel As Excel.Application

        'Build table to hold list of paths for checking.
        Dim dt_Folders As New DataTable
        dt_Folders.Columns.Add("FolderPath")
        dt_Folders.Columns.Add("FriendlyName")
        dt_Folders.Columns.Add("SupplierID")

        dt_Folders.Rows.Add(TheSystem.Configuration.DocumentsLocation & "PartsInvoiceFiles\NHC\", "NorwichHeatingComponents", "21")
        dt_Folders.Rows.Add(TheSystem.Configuration.DocumentsLocation & "PartsInvoiceFiles\PTS\", "PTS", "20")
        dt_Folders.Rows.Add(TheSystem.Configuration.DocumentsLocation & "PartsInvoiceFiles\PartsCenter\", "PartsCenter", "22")
        dt_Folders.Rows.Add(TheSystem.Configuration.DocumentsLocation & "PartsInvoiceFiles\Plumbase\", "Plumbase", "58")
        dt_Folders.Rows.Add(TheSystem.Configuration.DocumentsLocation & "PartsInvoiceFiles\CPS\", "CPS", "20")

        'Cycle through table looking for files.
        Dim FileCount As Integer = 0

        Dim dr_Folders As DataRow
        For Each dr_Folders In dt_Folders.Rows
            ' make a reference to a directory
            Dim di As New IO.DirectoryInfo(dr_Folders("FolderPath"))
            Dim diar1 As IO.FileInfo() = di.GetFiles()

            'list the names of all files in the specified directory
            Dim CurrentFile As IO.FileInfo
            For Each CurrentFile In diar1
                'Is it an excel file?
                If CurrentFile.Extension = ".xls" Or CurrentFile.Extension = ".xlsx" Then
                    'Is an Excel file
                    oExcel = New Excel.Application
                    oExcel.DisplayAlerts = False

                    Dim oWorksheet As Excel.Worksheet
                    oExcel.Workbooks.Add(CurrentFile.FullName)

                    oWorksheet = oExcel.Worksheets(1)

                    Dim strCom As String = " SELECT * FROM [" & oWorksheet.Name & "$]"
                    Dim strCon As String = ""
                    If CurrentFile.Extension.Trim.ToLower = ".xls".ToLower Then
                        strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & CurrentFile.FullName & " ; Extended Properties=Excel 8.0; "
                    ElseIf CurrentFile.Extension.Trim.ToLower = ".xlsx".ToLower Then
                        strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " & CurrentFile.FullName & " ; Extended Properties=Excel 12.0; "
                    End If
                    Dim conn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(strCon)
                    Dim adapter As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
                    Dim data As New DataSet

                    adapter.SelectCommand = New System.Data.OleDb.OleDbCommand(strCom, conn)
                    data.Clear()
                    adapter.Fill(data)

                    FileCount += 1
                    pbStatus.Maximum += data.Tables(0).Rows.Count
                Else
                    'Is NOT an Excel file
                    IO.File.Move(CurrentFile.FullName, dr_Folders("FolderPath") + "\Failed\" + CurrentFile.Name)
                End If
            Next
        Next

        Dim FileLoops As Integer = 0
        Dim PartLoops As Integer = 0

        For Each dr_Folders In dt_Folders.Rows
            ' make a reference to a directory
            Dim di As New IO.DirectoryInfo(dr_Folders("FolderPath"))
            Dim diar1 As IO.FileInfo() = di.GetFiles()

            'list the names of all files in the specified directory
            Dim CurrentFile As IO.FileInfo
            For Each CurrentFile In diar1
                'Is it an excel file?
                If CurrentFile.Extension = ".xls" Or CurrentFile.Extension = ".xlsx" Then
                    FileLoops += 1
                    PartLoops = 0
                    'Is an Excel file
                    oExcel = New Excel.Application
                    oExcel.DisplayAlerts = False

                    Dim oWorksheet As Excel.Worksheet
                    oExcel.Workbooks.Add(CurrentFile.FullName)

                    oWorksheet = oExcel.Worksheets(1)

                    Dim strCom As String = " SELECT * FROM [" & oWorksheet.Name & "$]"
                    Dim strCon As String = ""
                    If CurrentFile.Extension.Trim.ToLower = ".xls".ToLower Then
                        strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " & CurrentFile.FullName & " ; Extended Properties=Excel 8.0; "
                    ElseIf CurrentFile.Extension.Trim.ToLower = ".xlsx".ToLower Then
                        strCon = " Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = " & CurrentFile.FullName & " ; Extended Properties=Excel 12.0; "
                    End If

                    Dim conn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(strCon)
                    Dim adapter As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter
                    Dim data As New DataSet

                    Select Case dr_Folders("FriendlyName").ToString
                        Case "PartsCenter", "NorwichHeatingComponents", "CPS"
                            data.Tables.Add()
                            Dim colString As DataColumn = New DataColumn("Product Code")
                            colString.DataType = System.Type.GetType("System.String")
                            data.Tables(0).Columns.Add(colString)
                        Case "PTS"
                            data.Tables.Add()
                            Dim colString As DataColumn = New DataColumn("Keyword")
                            colString.DataType = System.Type.GetType("System.String")
                            data.Tables(0).Columns.Add(colString)
                        Case Else
                            data.Tables.Add()
                            Dim colString As DataColumn = New DataColumn("Keyword")
                            colString.DataType = System.Type.GetType("System.String")
                            data.Tables(0).Columns.Add(colString)
                    End Select

                    adapter.SelectCommand = New System.Data.OleDb.OleDbCommand(strCom, conn)
                    data.Clear()
                    adapter.Fill(data.Tables(0))

                    Dim dv As DataView
                    dv = New DataView(data.Tables(0))
                    If dr_Folders("FriendlyName").ToString = "PartsCenter" Then
                        dv.Sort = "Customer Order Number"
                    ElseIf dr_Folders("FriendlyName").ToString = "NorwichHeatingComponents" Then
                        dv.Sort = "Gasway Order No"
                    ElseIf dr_Folders("FriendlyName").ToString = "PTS" Then
                        dv.Sort = "Your Order"
                    ElseIf dr_Folders("FriendlyName").ToString = "CPS" Then
                        If dv.Table.Columns.Contains("Customer Order Number") Then dv.Sort = "Customer Order Number"
                        If dv.Table.Columns.Contains("Customer_Order_Number") Then dv.Sort = "Customer_Order_Number"
                    ElseIf dr_Folders("FriendlyName").ToString = "Plumbase" Then
                        dv.Sort = "Customer Order No (Hr)"
                    Else
                        dv.Sort = "Your Order"
                    End If
                    ' dv.Sort = "Customer Order Number"
                    data.Tables.Clear()
                    data.Tables.Add(dv.ToTable)

                    Dim LastPONumber(5000) As String
                    Dim LastInvoiceNumber(5000) As String
                    Dim NoOfParts As Integer = 0
                    Dim TotalQtyOfParts As Integer = 0
                    Dim TotalUnitPrice As Double = 0
                    Dim TotalNetAmount As Double = 0
                    Dim TotalVATAmount As Double = 0
                    Dim TotalGrossAmount As Double = 0
                    Dim SecondaryPart As Boolean = False
                    Dim lastpartinserted As Boolean = False
                    Dim orderID As Integer = 0

                    For i As Integer = 0 To data.Tables(0).Rows.Count - 1
                        Dim SupplierID As Integer = dr_Folders("SupplierID")
                        Dim InvoiceNo As String = Nothing
                        Dim InvoiceDate As String = Nothing
                        Dim PurchaseOrderNo As String = Nothing
                        Dim Engineer As String = Nothing
                        Dim SiteAddress As String = Nothing
                        Dim OrderType As String = Nothing
                        Dim SupplierPartCode As String = Nothing
                        Dim Description As String = "Unspecified"
                        Dim Quantity As Integer = 0
                        Dim UnitPrice As Double = 0
                        Dim NetAmount As Double = 0
                        Dim VATAmount As Double = 0
                        Dim GrossAmount As Double = 0

                        Dim InsertDB As Boolean = True

                        Dim Row As DataRow = data.Tables(0).Rows(i)
                        Select Case dr_Folders("FriendlyName").ToString
                            Case "NorwichHeatingComponents"
                                If Row.Item("Gasway Order No") Is DBNull.Value Then InsertDB = False
                                If Row.Item("Number") Is DBNull.Value Then InsertDB = False
                                If Row.Item("Product Code") Is DBNull.Value Then InsertDB = False

                                If IsDBNull(Row.Item("Number")) Then
                                    InvoiceNo = "Unspecified"
                                Else
                                    InvoiceNo = Trim(Row.Item("Number"))
                                End If
                                If Row.Item("Date") Is DBNull.Value Then
                                    InvoiceDate = "01/01/1900"
                                Else
                                    InvoiceDate = Trim(Row.Item("Date"))
                                End If
                                If Row.Item("Gasway Order No") Is DBNull.Value Then
                                    PurchaseOrderNo = "Unspecified"
                                Else
                                    PurchaseOrderNo = Trim(Row.Item("Gasway Order No"))
                                End If
                                If Row.Item("Product Code") Is DBNull.Value Then
                                    SupplierPartCode = "Unspecified"
                                Else
                                    SupplierPartCode = Trim(Row.Item("Product Code"))
                                End If
                                If Row.Item("Description") Is DBNull.Value Then
                                    Description = "Unspecified"
                                Else
                                    Description = Trim(Row.Item("Description"))
                                End If

                                If InsertDB Then

                                    OrderType = "Unspecified"
                                    If Row.Item("Quantity") Is DBNull.Value Then
                                        Quantity = 0
                                    Else
                                        Quantity = (Trim(Row.Item("Quantity")))
                                        TotalQtyOfParts += Quantity
                                    End If
                                    If Row.Item("Net Price") Is DBNull.Value Then
                                        UnitPrice = 0
                                    Else
                                        UnitPrice = Trim(Row.Item("Net Price"))
                                        TotalUnitPrice += UnitPrice
                                    End If
                                    If Row.Item("Net Amount") Is DBNull.Value Then
                                        NetAmount = 0
                                    Else
                                        NetAmount = Trim(Row.Item("Net Amount"))
                                        TotalNetAmount += NetAmount
                                    End If
                                    If Row.Item("Tax Amount") Is DBNull.Value Then
                                        VATAmount = 0
                                    Else
                                        VATAmount = Trim(Row.Item("Tax Amount"))
                                        TotalVATAmount += VATAmount
                                    End If
                                    If Row.Item("Gross Amount") Is DBNull.Value Then
                                        GrossAmount = 0
                                    Else
                                        GrossAmount = Trim(Row.Item("Gross Amount"))
                                        TotalGrossAmount += GrossAmount
                                    End If

                                End If
                            Case "PartsCenter"
                                If Row.Item("Customer Order Number") Is DBNull.Value Then InsertDB = False
                                If Row.Item("Product Code") Is DBNull.Value Then InsertDB = False
                                If Row.Item("Invoice Number") Is DBNull.Value Then InsertDB = False

                                If Row.Item("Invoice Number") Is DBNull.Value Then
                                    InvoiceNo = "Unspecified"
                                Else
                                    InvoiceNo = Trim(Row.Item("Invoice Number"))
                                End If
                                If Row.Item("Invoice Date") Is DBNull.Value Then
                                    InvoiceDate = "01/01/1900"
                                Else
                                    InvoiceDate = Trim(Row.Item("Invoice Date"))
                                End If
                                If Row.Item("Customer Order Number") Is DBNull.Value Then
                                    PurchaseOrderNo = "Unspecified"
                                Else
                                    PurchaseOrderNo = Trim(Row.Item("Customer Order Number"))
                                End If
                                SupplierPartCode = Trim(Row.Item("Product Code").ToString)
                                If Row.Item("Product Description") Is DBNull.Value Then
                                    Description = "Unspecified"
                                Else
                                    Description = Trim(Row.Item("Product Description"))
                                End If

                                If InsertDB Then

                                    OrderType = "Unspecified"
                                    Engineer = "Unspecified"
                                    SiteAddress = "Unspecified"

                                    If Row.Item("Line Qty") Is DBNull.Value Then
                                        Quantity = 0
                                    Else
                                        Quantity = Trim(Row.Item("Line Qty"))
                                        TotalQtyOfParts += Quantity
                                    End If
                                    If Row.Item("Unit Price") Is DBNull.Value Then
                                        UnitPrice = 0
                                    Else
                                        UnitPrice = Trim(Row.Item("Unit Price"))
                                        TotalUnitPrice += UnitPrice
                                    End If
                                    If Row.Item("Line Nett Value") Is DBNull.Value Then
                                        NetAmount = 0
                                    Else
                                        NetAmount = Trim(Row.Item("Line Nett Value"))
                                        TotalNetAmount += NetAmount
                                    End If
                                    If Row.Item("Line VAT Amount") Is DBNull.Value Then
                                        VATAmount = 0
                                    Else
                                        VATAmount = Trim(Row.Item("Line VAT Amount"))
                                        TotalVATAmount += VATAmount
                                    End If
                                    If Row.Item("Line Gross Value") Is DBNull.Value Then
                                        GrossAmount = 0
                                    Else
                                        GrossAmount = Trim(Row.Item("Line Gross Value"))
                                        TotalGrossAmount += GrossAmount
                                    End If

                                End If
                            Case "PTS"
                                If Row.Item("Your Order") Is DBNull.Value Then InsertDB = False
                                If Row.Item("InvNo") Is DBNull.Value Then InsertDB = False
                                If Row.Item("Keyword") Is DBNull.Value Then InsertDB = False
                                If Row.Item("INVNO") Is DBNull.Value Then
                                    InvoiceNo = "Unspecified"
                                Else
                                    InvoiceNo = Trim(Row.Item("INVNO"))
                                End If
                                If Row.Item("Date") Is DBNull.Value Then
                                    InvoiceDate = "01/01/1900"
                                Else
                                    InvoiceDate = Trim(Row.Item("Date"))
                                End If
                                If Row.Item("Your Order") Is DBNull.Value Then
                                    PurchaseOrderNo = "Unspecified"
                                Else
                                    PurchaseOrderNo = Trim(Row.Item("Your Order"))
                                End If
                                If Row.Item("Keyword") Is DBNull.Value Then
                                    SupplierPartCode = "Unspecified"
                                Else
                                    SupplierPartCode = Trim(Row.Item("Keyword"))
                                End If
                                If Row.Item("Description") Is DBNull.Value Then
                                    Description = "Unspecified"
                                Else
                                    Description = Trim(Row.Item("Description"))
                                End If

                                If InsertDB Then
                                    OrderType = "Unspecified"
                                    Engineer = "Unspecified"
                                    SiteAddress = "Unspecified"

                                    If Row.Item("Invoiced") Is DBNull.Value Then
                                        Quantity = 0
                                    Else
                                        Quantity = Trim(Row.Item("Invoiced"))
                                        TotalQtyOfParts += Quantity
                                    End If
                                    If Row.Item("Cost") Is DBNull.Value Then
                                        UnitPrice = 0
                                    Else
                                        UnitPrice = Trim(Row.Item("Cost"))
                                        TotalUnitPrice += UnitPrice
                                    End If
                                    If Row.Item("Value") Is DBNull.Value Then
                                        NetAmount = 0
                                    Else
                                        NetAmount = Trim(Row.Item("Value"))
                                        TotalNetAmount += NetAmount
                                    End If
                                    If Row.Item("VAT Value") Is DBNull.Value Then
                                        VATAmount = 0
                                    Else
                                        VATAmount = Trim(Row.Item("VAT Value"))
                                        TotalVATAmount += VATAmount
                                    End If
                                    GrossAmount = NetAmount + VATAmount
                                    TotalGrossAmount += GrossAmount
                                End If

                            Case "Plumbase"
                                If Row.Item("Customer Order No (Hr)") Is DBNull.Value Then InsertDB = False
                                If Row.Item("Invoice") Is DBNull.Value Then InsertDB = False
                                If Row.Item("Part Number (Li)") Is DBNull.Value Then InsertDB = False
                                If Row.Item("Invoice") Is DBNull.Value Then
                                    InvoiceNo = "Unspecified"
                                Else
                                    InvoiceNo = Trim(Row.Item("Invoice"))
                                End If
                                If Row.Item("Invoice Date (Li)") Is DBNull.Value Then
                                    InvoiceDate = "01/01/1900"
                                Else
                                    InvoiceDate = Trim(Row.Item("Invoice Date (Li)"))
                                End If
                                If Row.Item("Customer Order No (Hr)") Is DBNull.Value Then
                                    PurchaseOrderNo = "Unspecified"
                                Else
                                    PurchaseOrderNo = Trim(Row.Item("Customer Order No (Hr)"))
                                End If
                                If Row.Item("Part Number (Li)") Is DBNull.Value Then
                                    SupplierPartCode = "Unspecified"
                                Else
                                    SupplierPartCode = Trim(Row.Item("Part Number (Li)"))
                                End If
                                If Row.Item("Full Description (Li)") Is DBNull.Value Then
                                    Description = "Unspecified"
                                Else
                                    Description = Trim(Row.Item("Full Description (Li)"))
                                End If

                                If InsertDB Then
                                    OrderType = "Unspecified"
                                    Engineer = "Unspecified"
                                    SiteAddress = "Unspecified"

                                    If Row.Item("Quantity") Is DBNull.Value Then
                                        Quantity = 0
                                    Else
                                        Quantity = Trim(Row.Item("Quantity"))
                                        TotalQtyOfParts += Quantity
                                    End If
                                    If Row.Item("Price") Is DBNull.Value Then
                                        UnitPrice = 0
                                    Else
                                        UnitPrice = Trim(Row.Item("Price"))
                                        TotalUnitPrice += UnitPrice
                                    End If
                                    If Row.Item("Goods") Is DBNull.Value Then
                                        NetAmount = 0
                                    Else
                                        NetAmount = Trim(Row.Item("Goods"))
                                        TotalNetAmount += NetAmount
                                    End If
                                    If Row.Item("VAT") Is DBNull.Value Then
                                        VATAmount = 0
                                    Else
                                        VATAmount = Trim(Row.Item("VAT"))
                                        TotalVATAmount += VATAmount
                                    End If
                                    GrossAmount = NetAmount + VATAmount
                                    TotalGrossAmount += GrossAmount

                                End If
                            Case "CPS"
                                If Row.Table.Columns.Contains("Customer Order Number") Then
                                    If Row.Item("Customer Order Number") Is DBNull.Value Then
                                        InsertDB = False
                                        PurchaseOrderNo = "Unspecified"
                                    Else
                                        PurchaseOrderNo = Trim(Row.Item("Customer Order Number"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Customer_Order_Number") Then
                                    If Row.Item("Customer_Order_Number") Is DBNull.Value Then
                                        InsertDB = False
                                        PurchaseOrderNo = "Unspecified"
                                    Else
                                        PurchaseOrderNo = Trim(Row.Item("Customer_Order_Number"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Invoice Number") Then
                                    If Row.Item("Invoice Number") Is DBNull.Value Then
                                        InsertDB = False
                                        InvoiceNo = "Unspecified"
                                    Else
                                        InvoiceNo = Trim(Row.Item("Invoice Number"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Invoice_Number") Then
                                    If Row.Item("Invoice_Number") Is DBNull.Value Then
                                        InsertDB = False
                                        InvoiceNo = "Unspecified"
                                    Else
                                        InvoiceNo = Trim(Row.Item("Invoice_Number"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Product Code") Then
                                    If Row.Item("Product Code") Is DBNull.Value Then
                                        InsertDB = False
                                        SupplierPartCode = "Unspecified"
                                    Else
                                        SupplierPartCode = Trim(Row.Item("Product Code"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Product_Code") Then
                                    If Row.Item("Product_Code") Is DBNull.Value Then
                                        InsertDB = False
                                        SupplierPartCode = "Unspecified"
                                    Else
                                        SupplierPartCode = Trim(Row.Item("Product_Code"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Invoice Date") Then
                                    If Row.Item("Invoice Date") Is DBNull.Value Then
                                        InvoiceDate = "Unspecified"
                                    Else
                                        InvoiceDate = Trim(Row.Item("Invoice Date"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Invoice_Date") Then
                                    If Row.Item("Invoice_Date") Is DBNull.Value Then
                                        InvoiceDate = "Unspecified"
                                    Else
                                        InvoiceDate = Trim(Row.Item("Invoice_Date"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Product Description") Then
                                    If Row.Item("Product Description") Is DBNull.Value Then
                                        Description = "Unspecified"
                                    Else
                                        Description = Trim(Row.Item("Product Description"))
                                    End If
                                End If
                                If Row.Table.Columns.Contains("Product_Description") Then
                                    If Row.Item("Product_Description") Is DBNull.Value Then
                                        Description = "Unspecified"
                                    Else
                                        Description = Trim(Row.Item("Product_Description"))
                                    End If
                                End If

                                If InsertDB Then
                                    OrderType = "Unspecified"
                                    Engineer = "Unspecified"
                                    SiteAddress = "Unspecified"
                                    If Row.Table.Columns.Contains("Sales Quantity") Then
                                        If Row.Item("Sales Quantity") Is DBNull.Value Then
                                            Quantity = 0
                                        Else
                                            Quantity = Trim(Row.Item("Sales Quantity"))
                                            TotalQtyOfParts += Quantity
                                        End If
                                    End If
                                    If Row.Table.Columns.Contains("Sales_Quantity") Then
                                        If Row.Item("Sales_Quantity") Is DBNull.Value Then
                                            Quantity = 0
                                        Else
                                            Quantity = Trim(Row.Item("Sales_Quantity"))
                                            TotalQtyOfParts += Quantity
                                        End If
                                    End If
                                    If Row.Table.Columns.Contains("Price Per Item") Then
                                        If Row.Item("Price Per Item") Is DBNull.Value Then
                                            UnitPrice = 0
                                        Else
                                            UnitPrice = Trim(Row.Item("Price Per Item"))
                                            TotalUnitPrice += UnitPrice
                                        End If
                                    End If
                                    If Row.Table.Columns.Contains("Price_Per_Item") Then
                                        If Row.Item("Price_Per_Item") Is DBNull.Value Then
                                            UnitPrice = 0
                                        Else
                                            UnitPrice = Trim(Row.Item("Price_Per_Item"))
                                            TotalUnitPrice += UnitPrice
                                        End If
                                    End If
                                    If Row.Table.Columns.Contains("Sales Value") Then
                                        If Row.Item("Sales Value") Is DBNull.Value Then
                                            NetAmount = 0
                                        Else
                                            NetAmount = Trim(Row.Item("Sales Value"))
                                            TotalNetAmount += NetAmount
                                        End If
                                    End If
                                    If Row.Table.Columns.Contains("Sales_Value") Then
                                        If Row.Item("Sales_Value") Is DBNull.Value Then
                                            NetAmount = 0
                                        Else
                                            NetAmount = Trim(Row.Item("Sales_Value"))
                                            TotalNetAmount += NetAmount
                                        End If
                                    End If
                                    If Row.Table.Columns.Contains("Sales VAT Value") Then
                                        If Row.Item("Sales VAT Value") Is DBNull.Value Then
                                            VATAmount = 0
                                        Else
                                            VATAmount = Trim(Row.Item("Sales VAT Value"))
                                            TotalVATAmount += VATAmount
                                        End If
                                    End If
                                    If Row.Table.Columns.Contains("Sales_Vat_Value") Then
                                        If Row.Item("Sales_Vat_Value") Is DBNull.Value Then
                                            VATAmount = 0
                                        Else
                                            VATAmount = Trim(Row.Item("Sales_Vat_Value"))
                                            TotalVATAmount += VATAmount
                                        End If
                                    End If
                                    GrossAmount = NetAmount + VATAmount
                                    TotalGrossAmount += GrossAmount
                                End If

                        End Select
                        Try
                            Dim ImportOrderExistsAndHasBeenSent As Integer =
                                    DB.ImportValidation.POInvoiceImport_CheckImportHasBeenSent(InvoiceNo, InvoiceDate,
                                                                                                       SupplierPartCode)
                            'lets check if the import has been sent
                            If ImportOrderExistsAndHasBeenSent > 0 Then
                                MoveProgressOn()
                                Continue For
                            End If

                            Dim ImportOrderExists As Integer =
                                    DB.ImportValidation.POInvoiceImport_CheckImportInvoiceExists(InvoiceNo, InvoiceDate,
                                                                                                 SupplierPartCode)

                            If ImportOrderExists > 0 Then
                                InsertDB = False 'import already in db
                                Dim duplicate As Importer.DuplicateInvoice = New Importer.DuplicateInvoice
                                duplicate.PurchaseOrderNo = PurchaseOrderNo
                                duplicate.SupplierPartCode = SupplierPartCode
                                duplicate.Description = Description
                                duplicate.Quantity = Quantity
                                duplicate.UnitPrice = UnitPrice
                                duplicate.NetAmount = NetAmount
                                duplicate.VATAmount = VATAmount
                                duplicate.GrossAmount = GrossAmount
                                duplicate.InvoiceNo = InvoiceNo
                                duplicate.InvoiceDate = InvoiceDate
                                duplicate.SupplierID = SupplierID
                                duplicate.TotalQtyOfParts = TotalQtyOfParts

                                DuplicateInvoices.Add(duplicate)
                            End If
                            If InsertDB Then
                                If Not checkArray(LastPONumber, PurchaseOrderNo) Or
                                    checkArray(LastPONumber, PurchaseOrderNo) And Not checkArray(LastInvoiceNumber, InvoiceNo) Then
                                    'create the PO holder In the db
                                    NoOfParts = 0
                                    TotalQtyOfParts = 0
                                    TotalGrossAmount = 0
                                    TotalNetAmount = 0
                                    TotalUnitPrice = 0
                                    TotalVATAmount = 0
                                    'insert order into db and retrieve order id
                                    orderID =
                                        DB.ImportValidation.POInvoiceImport_InsertOrder(InvoiceNo, InvoiceDate,
                                                                                        PurchaseOrderNo, SupplierID,
                                                                                        OrderType)
                                    LastPONumber(i) = PurchaseOrderNo
                                    LastInvoiceNumber(i) = InvoiceNo
                                    SecondaryPart = False
                                    lastpartinserted = True
                                Else
                                    lastpartinserted = False
                                End If

                                NoOfParts += 1
                                'insert the part into the table
                                DB.ImportValidation.POInvoiceImport_InsertPart(PurchaseOrderNo, SupplierPartCode, Description, Quantity, UnitPrice, NetAmount, VATAmount, GrossAmount, InvoiceNo)
                                DB.ImportValidation.POInvoiceImport_UpdateOrderTotals(PurchaseOrderNo, Quantity, UnitPrice, NetAmount, VATAmount, GrossAmount, TotalQtyOfParts, InvoiceNo)
                                'validate order
                                If orderID > 0 Then
                                    DB.ImportValidation.POInvoiceImport_ValidateOrder(orderID)
                                End If
                            End If

                            If InsertDB Then
                                PartLoops += 1
                                lblMessages.Text = "Adding part " & PartLoops & " of " & data.Tables(0).Rows.Count & " from file " & FileLoops & " of " & FileCount & "."
                                lblMessages.Visible = True
                                'DB.ImportValidation.Parts_PartsInvoiceImportData(InvoiceNo, InvoiceDate, PurchaseOrderNo, Engineer, SiteAddress, OrderType, SupplierPartCode, Description, Quantity, UnitPrice, NetAmount, VATAmount, GrossAmount)
                            End If

                            MoveProgressOn()
                        Catch ex As Exception

                        End Try

                    Next
                    Try
                        IO.File.Move(CurrentFile.FullName, dr_Folders("FolderPath") + "\Processed\" + CurrentFile.Name)
                    Catch
                    End Try

                End If
            Next
        Next

        MoveProgressOn(True)

    End Sub

    Private Sub ValidateOrdersWithNoParts()
        Cursor.Current = Cursors.WaitCursor
        'get my datatable and loop round

        Dim dvOrderData As DataView
        dvOrderData = DB.ImportValidation.POInvoiceImport_GetOrdersWithNoParts(8)

        pbStatus.Value = 0
        pbStatus.Maximum = dvOrderData.Count + 1

        For i As Integer = 0 To dvOrderData.Count - 1

            Dim dvPartsData As DataView
            dvPartsData = DB.ImportValidation.POInvoiceImport_GetPOParts(dvOrderData.Table().Rows.Item(i).Item(3).ToString, dvOrderData.Table().Rows.Item(i).Item(1).ToString)

            If Not dvPartsData.Count = 0 Then

                Dim ValidPartCount As Integer = 0

                For p As Integer = 0 To dvPartsData.Count - 1

                    If CInt(dvPartsData.Table().Rows.Item(p).Item(3).ToString) < 0 Then
                        DB.ImportValidation.POInvoiceImport_UpdateFailedPart(dvPartsData.Table().Rows.Item(p).Item(9).ToString, 1)
                    ElseIf CInt(dvPartsData.Table().Rows.Item(p).Item(3).ToString) = 0 Then
                        DB.ImportValidation.POInvoiceImport_UpdateFailedPart(dvPartsData.Table().Rows.Item(p).Item(9).ToString, 1)
                    ElseIf DB.ImportValidation.POInvoiceImport_ValidatePart(dvOrderData.Table().Rows.Item(i).Item(4).ToString, dvPartsData.Table().Rows.Item(p).Item(1).ToString) = 1 Then
                        DB.ImportValidation.POInvoiceImport_UpdateFailedPart(dvPartsData.Table().Rows.Item(p).Item(9).ToString, 0)
                        ValidPartCount += 1
                    ElseIf DB.ImportValidation.POInvoiceImport_ValidatePart(dvOrderData.Table().Rows.Item(i).Item(4).ToString, dvPartsData.Table().Rows.Item(p).Item(1).ToString) = 0 Or DB.ImportValidation.POInvoiceImport_ValidatePart(dvOrderData.Table().Rows.Item(i).Item(4).ToString, dvPartsData.Table().Rows.Item(p).Item(1).ToString) > 1 Then
                        DB.ImportValidation.POInvoiceImport_UpdateFailedPart(dvPartsData.Table().Rows.Item(p).Item(9).ToString, 1)
                    End If

                Next

                If ValidPartCount = dvPartsData.Count Then
                    'insert the parts to the purchase order and revalidate orders

                    Dim CurrentOrder As Entity.Orders.Order = DB.Order.Order_Get(dvOrderData.Table().Rows.Item(i).Item(14).ToString)

                    For p As Integer = 0 To dvPartsData.Count - 1
                        Dim PartID As Integer = DB.ImportValidation.POInvoiceImport_GetPartID(dvOrderData.Table().Rows.Item(i).Item(4).ToString, dvPartsData.Table().Rows.Item(p).Item(1).ToString)
                        Dim Part As Entity.Parts.Part = DB.Part.Part_Get(PartID)
                        Dim dvPartSupplier As DataView = DB.PartSupplier.Get_ByPartIDAndSupplierID(PartID, dvOrderData.Table().Rows.Item(i).Item(4).ToString)
                        If dvPartSupplier.Count = 0 Then
                        ElseIf dvPartSupplier.Count = 1 Then
                            Dim EngineerVisit As Entity.EngineerVisitOrders.EngineerVisitOrder = DB.EngineerVisitOrder.EngineerVisitOrder_GetForOrder(CurrentOrder.OrderID)

                            Dim oOrderPart As New Entity.OrderParts.OrderPart
                            oOrderPart.IgnoreExceptionsOnSetMethods = True
                            oOrderPart.SetOrderID = CurrentOrder.OrderID
                            oOrderPart.SetPartSupplierID = dvPartSupplier.Table().Rows.Item(0).Item(0).ToString
                            oOrderPart.SetQuantity = dvPartsData.Table().Rows.Item(p).Item(3).ToString
                            oOrderPart.SetBuyPrice = dvPartSupplier.Table().Rows.Item(0).Item(4).ToString
                            oOrderPart.SetSellPrice = Part.SellPrice
                            oOrderPart.SetQuantityReceived = dvPartsData.Table().Rows.Item(p).Item(3).ToString

                            Dim val As New Entity.OrderParts.OrderPartValidator
                            val.Validate(oOrderPart)

                            oOrderPart = DB.OrderPart.Insert(oOrderPart, Not (CurrentOrder.DoNotConsolidated))
                            If CurrentOrder.OrderTypeID = Entity.Sys.Enums.OrderType.Job Then

                                DB.EngineerVisitPartProductAllocated.InsertOne(EngineerVisit.EngineerVisitID,
                               "Part", oOrderPart.Quantity, oOrderPart.OrderPartID,
                                        PartID, 1)
                            End If

                            CurrentOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Complete)
                            DB.Order.Update(CurrentOrder)
                        Else
                            ShowMessage("Unable to process Part - Multiple Part Supplier Found for Part : " & dvPartsData.Table().Rows.Item(p).Item(1).ToString, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Next

                    DB.ImportValidation.POInvoiceImport_ValidateOrders(8)
                Else
                    DB.ImportValidation.POInvoiceImport_UpdateValidationType(dvOrderData.Table().Rows.Item(i).Item(0).ToString, 12)
                End If

            End If

            MoveProgressOn(False)

        Next

        MoveProgressOn(True)

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnExportResults_Click(sender As System.Object, e As System.EventArgs) Handles btnExportResults.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            Dim data As DataView
            Dim sheetName As String = ""
            Dim sql As String = ""

            If Combo.GetSelectedItemValue(cboValidateType) = CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncludedUnableToMatchParts) Then
                sql = "EXEC POInvoiceImport_ExportResultsIncPartDetail " & Combo.GetSelectedItemValue(cboValidateType)
                data = New DataView(DB.ExecuteWithReturn(sql))

                For Each col As DataColumn In data.Table.Columns
                    If col.DataType Is System.Type.GetType("System.String") Then
                        For Each row As DataRow In data.Table.Rows
                            row.Item(col.ColumnName) = "'" & row.Item(col.ColumnName)
                        Next
                    End If
                Next
            Else
                sql = "EXEC POInvoiceImport_ExportResults " & Combo.GetSelectedItemValue(cboValidateType)
                data = New DataView(DB.ExecuteWithReturn(sql))

                For Each col As DataColumn In data.Table.Columns
                    If col.DataType Is System.Type.GetType("System.String") Then
                        For Each row As DataRow In data.Table.Rows
                            row.Item(col.ColumnName) = "'" & row.Item(col.ColumnName)
                        Next
                    End If
                Next
            End If

            sheetName = (((Trim(Combo.GetSelectedItemDescription(cboValidateType))).Replace("(", "")).Replace(")", "")).Replace(" ", "")

            If Len(sheetName) < 23 Then
            Else
                sheetName = sheetName.Substring(0, 23)
            End If
            sheetName = sheetName & CStr(Today).Replace("/", "")

            Dim exporter As New Entity.Sys.Exporting(data.Table, sheetName)
        Catch ex As Exception
            ShowMessage("Error exporting : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub llOpenFolder_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llOpenFolder.LinkClicked
        Process.Start("explorer.exe", TheSystem.Configuration.DocumentsLocation & "PartsInvoiceFiles\")
    End Sub

    Private Sub btnValidateResults_Click(sender As Object, e As EventArgs) Handles btnValidateResults.Click
        ValidateAllRecords()
    End Sub

#End Region

#Region "Functions"

    Public Function checkArray(ByVal var() As String, ByVal Text As String) As Boolean
        If Array.IndexOf(var, Text) > -1 Then
            Return True ' found
        Else
            Return False
        End If

    End Function

    Public Sub ShowData(Optional ByVal ValidateType As Integer = 0)
        Me.tcData.TabPages.Clear()

        Dim tp As New TabPage

        Dim data As New UCDataPartsInvoiceImport
        data.Dock = DockStyle.Fill
        data.Data = DB.ImportValidation.POInvoiceImport_ShowData(ValidateType)
        data.ValidateType = Combo.GetSelectedItemValue(cboValidateType)
        tp.Text = "PO Invoice Import Data (" & data.Data.Count & " Records)"

        tp.Controls.Add(data)
        Me.tcData.TabPages.Add(tp)
        Me.tcData.SelectedIndex = 0

        MoveProgressOn(True)
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

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ValidateOrdersWithNoParts()
    End Sub

    ''' <summary>
    ''' Get nominal code for order
    ''' </summary>
    ''' <param name="orderId">Integer</param>
    ''' <returns>Integer</returns>
    Public Function GetNominalCode(ByVal orderId As Integer) As Integer
        'give nominal code a default value incase db can't find anything
        Dim nominalCode As Integer = 5300

        'using the orderid, get the job information
        Dim dvJob As DataView = DB.Order.Orders_GetJob(orderId)
        'populate the data with the purchase nominal data
        Dim dtPurchaseNominal As DataTable =
                DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PurchaseNominal).Table

        'check if dataview is not empty
        If dvJob.Table.Rows.Count > 0 Then
            'get the region id from the job
            Dim regionID As Integer =
                Entity.Sys.Helper.MakeIntegerValid(dvJob(0)("RegionID"))

            'if the region id is gasway commerical then give it different else give it the default value
            Try
                If regionID = Entity.Sys.Enums.Region.GaswayCommercial Then
                    If dtPurchaseNominal.Select("Name='Gasway Commerical'").Length > 0 Then
                        Dim row As DataRow = dtPurchaseNominal.Select("Name='Gasway Commerical'")(0)
                        If Not row.IsNull("Name") Then
                            nominalCode = Entity.Sys.Helper.MakeIntegerValid(row("Description"))
                        End If
                    Else
                        Throw New Exception()
                    End If
                Else
                    Throw New Exception()
                End If
            Catch ex As Exception
                If dtPurchaseNominal.Select("Name='Standard'").Length > 0 Then
                    Dim row As DataRow = dtPurchaseNominal.Select("Name='Standard'")(0)
                    If Not row.IsNull("Name") Then
                        nominalCode = Entity.Sys.Helper.MakeIntegerValid(row("Description"))
                    End If
                End If
            End Try
        End If

        Return nominalCode
    End Function

End Class