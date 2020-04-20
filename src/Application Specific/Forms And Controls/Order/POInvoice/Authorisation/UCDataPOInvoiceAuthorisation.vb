Imports System.ComponentModel

Public Class UCDataPOInvoiceAuthorisation : Inherits UCBase

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

    Friend WithEvents dgvData As System.Windows.Forms.DataGridView

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(512, 344)
        Me.dgvData.TabIndex = 3
        '
        'UCDataPartsInvoiceImport
        '
        Me.Controls.Add(Me.dgvData)
        Me.Name = "UCDataPartsInvoiceImport"
        Me.Size = New System.Drawing.Size(512, 344)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Public ReadOnly Property LoadedItem() As Object
        Get
            Return Data
        End Get
    End Property

#End Region

#Region "Properties"

    Private _Data As DataView

    Public Property Data() As DataView
        Get
            Return _Data
        End Get
        Set(ByVal value As DataView)
            _Data = value
            _Data.AllowNew = False
            _Data.AllowEdit = True
            _Data.AllowDelete = False
            dgvData.AutoGenerateColumns = False
            Me.dgvData.DataSource = Data
        End Set
    End Property

    Private _ValidateType As System.String

    Public Property ValidateType() As System.String
        Get
            Return ValidateType
        End Get
        Set(ByVal Value As System.String)
            _ValidateType = Value
        End Set
    End Property

    Private _Department As System.String

    Public Property Department() As System.String
        Get
            Return Department
        End Get
        Set(ByVal Value As System.String)
            _Department = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Private m_SelectedStyle As New DataGridViewCellStyle
    Private m_SelectedRow As Integer = -1

    Public Sub SetupDG()

        dgvData.AutoGenerateColumns = False

        Dim InvoiceNo As New DataGridViewTextBoxColumn
        InvoiceNo.HeaderText = "Invoice No"
        InvoiceNo.DataPropertyName = "InvoiceNo"
        InvoiceNo.Name = "InvoiceNo"
        InvoiceNo.FillWeight = 15
        InvoiceNo.ReadOnly = True
        InvoiceNo.Visible = True
        InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(InvoiceNo)

        Dim Exclude As New DataGridViewCheckBoxColumn
        Exclude.FillWeight = 5
        Exclude.HeaderText = "Exclude"
        Exclude.DataPropertyName = "Exclude"
        Exclude.Name = "Exclude"
        Exclude.ReadOnly = False
        Exclude.Visible = False
        Exclude.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Exclude)

        Dim ID As New DataGridViewTextBoxColumn
        ID.HeaderText = "ID"
        ID.DataPropertyName = "ID"
        ID.Name = "ID"
        ID.ReadOnly = True
        ID.Visible = False
        ID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ID)

        'Dim InvoiceNo As New DataGridViewTextBoxColumn
        'InvoiceNo.HeaderText = "Invoice No"
        'InvoiceNo.DataPropertyName = "InvoiceNo"
        'InvoiceNo.FillWeight = 15
        'InvoiceNo.ReadOnly = True
        'InvoiceNo.Visible = True
        'InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvData.Columns.Add(InvoiceNo)

        Dim InvoiceDate As New DataGridViewTextBoxColumn
        InvoiceDate.HeaderText = "Invoice Date"
        InvoiceDate.DataPropertyName = "InvoiceDate"
        InvoiceDate.Name = "InvoiceDate"
        'InvoiceDate.FillWeight = 15
        InvoiceDate.ReadOnly = True
        InvoiceDate.Visible = True
        InvoiceDate.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(InvoiceDate)

        Dim PurchaseOrderNo As New DataGridViewTextBoxColumn
        PurchaseOrderNo.HeaderText = "Purchase Order No"
        PurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
        PurchaseOrderNo.Name = "PurchaseOrderNo"
        'PurchaseOrderNo.FillWeight = 20
        PurchaseOrderNo.ReadOnly = False
        PurchaseOrderNo.Visible = True
        PurchaseOrderNo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PurchaseOrderNo)

        Dim SupplierID As New DataGridViewTextBoxColumn
        SupplierID.HeaderText = "Supplier ID"
        SupplierID.DataPropertyName = "SupplierID"
        SupplierID.Name = "SupplierID"
        SupplierID.ReadOnly = True
        SupplierID.Visible = False
        SupplierID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierID)

        Dim SupplierName As New DataGridViewTextBoxColumn
        SupplierName.HeaderText = "Supplier"
        SupplierName.DataPropertyName = "SupplierName"
        SupplierName.Name = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Visible = True
        SupplierName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(SupplierName)

        Dim NoOfParts As New DataGridViewTextBoxColumn
        NoOfParts.HeaderText = "No Of Parts"
        NoOfParts.DataPropertyName = "NoOfParts"
        NoOfParts.Name = "NoOfParts"
        NoOfParts.ReadOnly = False
        NoOfParts.Visible = False
        NoOfParts.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(NoOfParts)

        Dim Quantities As New DataGridViewTextBoxColumn
        Quantities.HeaderText = "No of Parts (total qty)"
        Quantities.DataPropertyName = "Quantities"
        Quantities.Name = "Quantities"
        Quantities.FillWeight = 10
        Quantities.ReadOnly = False
        Quantities.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Quantities)

        Dim TotalUnitPrice As New DataGridViewTextBoxColumn
        TotalUnitPrice.HeaderText = "Total Unit Price"
        TotalUnitPrice.DataPropertyName = "TotalUnitPrice"
        TotalUnitPrice.Name = "TotalUnitPrice"
        'TotalUnitPrice.FillWeight = 10
        TotalUnitPrice.ReadOnly = True
        TotalUnitPrice.Visible = False
        TotalUnitPrice.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(TotalUnitPrice)

        Dim PONetValue As New DataGridViewTextBoxColumn
        PONetValue.HeaderText = "PO Net Value"
        PONetValue.DataPropertyName = "PONetValue"
        PONetValue.Name = "PONetValue"
        'TotalUnitPrice.FillWeight = 10
        PONetValue.ReadOnly = True
        PONetValue.Visible = True
        PONetValue.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PONetValue)

        Dim PONetDifference As New DataGridViewTextBoxColumn
        PONetDifference.HeaderText = "Net Difference (£)"
        PONetDifference.DataPropertyName = "PONetDifference"
        PONetDifference.Name = "PONetDifference"
        'TotalUnitPrice.FillWeight = 10
        PONetDifference.ReadOnly = True
        PONetDifference.Visible = True
        PONetDifference.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PONetDifference)

        Dim TotalNetAmount As New DataGridViewTextBoxColumn
        TotalNetAmount.HeaderText = "Invoice Net Amount"
        TotalNetAmount.DataPropertyName = "TotalNetAmount"
        TotalNetAmount.Name = "TotalNetAmount"
        'TotalNetAmount.FillWeight = 10
        TotalNetAmount.ReadOnly = True
        TotalNetAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(TotalNetAmount)

        Dim TotalVATAmount As New DataGridViewTextBoxColumn
        TotalVATAmount.HeaderText = "Invoice VAT Amount"
        TotalVATAmount.DataPropertyName = "TotalVATAmount"
        TotalVATAmount.Name = "TotalVATAmount"
        'TotalVATAmount.FillWeight = 10
        TotalVATAmount.ReadOnly = True
        TotalVATAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(TotalVATAmount)

        Dim TotalGrossAmount As New DataGridViewTextBoxColumn
        TotalGrossAmount.HeaderText = "Invoice Gross Amount"
        TotalGrossAmount.DataPropertyName = "TotalGrossAmount"
        TotalGrossAmount.Name = "TotalGrossAmount"
        'TotalGrossAmount.FillWeight = 10
        TotalGrossAmount.ReadOnly = True
        TotalGrossAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(TotalGrossAmount)

        Dim creditAmount As New DataGridViewTextBoxColumn
        creditAmount.HeaderText = "Total Credit on Order"
        creditAmount.DataPropertyName = "CreditAmount"
        creditAmount.Name = "CreditAmount"
        'TotalGrossAmount.FillWeight = 10
        creditAmount.ReadOnly = True
        creditAmount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(creditAmount)

        Dim ValidateResult As New DataGridViewTextBoxColumn
        ValidateResult.HeaderText = "Validate Result"
        ValidateResult.DataPropertyName = "ValidateResult"
        ValidateResult.Name = "ValidateResult"
        ValidateResult.ReadOnly = True
        ValidateResult.Visible = False
        ValidateResult.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ValidateResult)

        Dim POOrderID As New DataGridViewTextBoxColumn
        POOrderID.HeaderText = "POOrderID"
        POOrderID.DataPropertyName = "OrderID"
        POOrderID.Name = "OrderID"
        POOrderID.ReadOnly = True
        POOrderID.Visible = False
        POOrderID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(POOrderID)

        Dim ViewParts As New DataGridViewTextBoxColumn
        ViewParts.HeaderText = "View Parts"
        ViewParts.DataPropertyName = "ViewParts"
        ViewParts.Name = "ViewParts"
        ViewParts.ReadOnly = True
        ViewParts.Visible = True
        ViewParts.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ViewParts)

        Dim OrderTypeID As New DataGridViewTextBoxColumn
        OrderTypeID.HeaderText = "OrderTypeID"
        OrderTypeID.DataPropertyName = "OrderTypeID"
        OrderTypeID.Name = "OrderTypeID"
        OrderTypeID.ReadOnly = True
        OrderTypeID.Visible = False
        OrderTypeID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(OrderTypeID)

        Dim OrderForID As New DataGridViewTextBoxColumn
        OrderForID.HeaderText = "OrderForID"
        OrderForID.DataPropertyName = "OrderForID"
        OrderForID.Name = "OrderForID"
        OrderForID.ReadOnly = True
        OrderForID.Visible = False
        OrderForID.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(OrderForID)

        Dim ViewOrder As New DataGridViewTextBoxColumn
        ViewOrder.HeaderText = "View Order"
        ViewOrder.DataPropertyName = "ViewOrder"
        ViewOrder.Name = "ViewOrder"
        ViewOrder.ReadOnly = True
        ViewOrder.Visible = True
        ViewOrder.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(ViewOrder)

        Dim Authorise As New DataGridViewTextBoxColumn
        Authorise.HeaderText = "Authorise"
        Authorise.DataPropertyName = "Authorise"
        Authorise.Name = "Authorise"
        Authorise.ReadOnly = True
        Authorise.Visible = True
        Authorise.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(Authorise)

        Dim PODepartment As New DataGridViewTextBoxColumn
        PODepartment.HeaderText = "Department"
        PODepartment.DataPropertyName = "PODepartment"
        PODepartment.Name = "PODepartment"
        PODepartment.FillWeight = 15
        PODepartment.ReadOnly = True
        PODepartment.Visible = True
        PODepartment.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvData.Columns.Add(PODepartment)

        dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

    End Sub

#End Region

#Region "Events"

    'Private Sub UCData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'End Sub
    Private Sub UCDataPOInvoiceAuthorisation_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetupDG()
        m_SelectedStyle.BackColor = Color.LightBlue
    End Sub

    Private Sub dgvData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvData.ColumnHeaderMouseClick

        Try
            Dim newColumn As DataGridViewColumn = dgvData.Columns(e.ColumnIndex)
            Dim oldColumn As DataGridViewColumn = dgvData.SortedColumn
            Dim direction As System.ComponentModel.ListSortDirection

            ' If oldColumn is null, then the DataGridView is not currently sorted.
            If oldColumn IsNot Nothing Then
                ' Sort the same column again, reversing the SortOrder.
                If oldColumn Is newColumn AndAlso dgvData.SortOrder = SortOrder.Ascending Then
                    direction = System.ComponentModel.ListSortDirection.Descending
                Else
                    ' Sort a new column and remove the old SortGlyph.
                    direction = System.ComponentModel.ListSortDirection.Ascending
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None
                End If
            Else
                direction = System.ComponentModel.ListSortDirection.Ascending
            End If

            ' Sort the selected column.

            If newColumn.ValueType IsNot Nothing Then

                dgvData.Sort(newColumn, direction)
                If direction = System.ComponentModel.ListSortDirection.Ascending Then
                    newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
                Else
                    newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

#End Region

    Private Sub dgvData_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvData.Click

        Try

            Dim columnIndex As Integer = 0
            If dgvData IsNot Nothing AndAlso dgvData.CurrentCell IsNot Nothing Then
                columnIndex = dgvData.CurrentCell.ColumnIndex
            End If

            If columnIndex > 0 Then
                Dim columnName As String = dgvData.Columns(columnIndex).Name

                If e.Button = MouseButtons.Left Then
                    Select Case columnName.ToLower
                        Case "viewparts"
                            Dim dialogue As FRMPOInvoiceIncludedItems
                            dialogue = checkIfExists(GetType(FRMPOInvoiceIncludedItems).Name, True)
                            If dialogue Is Nothing Then
                                dialogue = Activator.CreateInstance(GetType(FRMPOInvoiceIncludedItems))
                            End If

                            dialogue.ShowInTaskbar = False
                            Dim poNoIndex As Integer = dgvData.Columns.IndexOf(dgvData.Columns("PurchaseOrderNo"))
                            dialogue.POToShow = dgvData.Item(poNoIndex, dgvData.CurrentCell.RowIndex).Value
                            Dim invoiceIndex As Integer = dgvData.Columns.IndexOf(dgvData.Columns("InvoiceNo"))
                            dialogue.InvoiceNo = dgvData.Item(invoiceIndex, dgvData.CurrentCell.RowIndex).Value
                            dialogue.ShowDialog()

                            If dialogue.DialogResult = DialogResult.OK Then
                                If _Department = "" Then
                                    Me.Data = DB.POInvoice.POInvoiceImport_RefreshData(_ValidateType, "%")
                                Else
                                    Me.Data = DB.POInvoice.POInvoiceImport_RefreshData(_ValidateType, _Department)
                                End If
                            Else
                                If _Department = "" Then
                                    Me.Data = DB.POInvoice.POInvoiceImport_RefreshData(_ValidateType, "%")
                                Else
                                    Me.Data = DB.POInvoice.POInvoiceImport_RefreshData(_ValidateType, _Department)
                                End If
                            End If
                            dialogue.Close()

                        Case "vieworder"
                            Dim orderIdIndex As Integer = dgvData.Columns.IndexOf(dgvData.Columns("OrderID"))
                            Dim orderForIdIndex As Integer = dgvData.Columns.IndexOf(dgvData.Columns("OrderForID"))
                            If Not dgvData.Item(orderIdIndex, dgvData.CurrentCell.RowIndex).Value Is DBNull.Value Then
                                ShowForm(GetType(FRMOrder), True, New Object() {dgvData.Item(orderIdIndex, dgvData.CurrentCell.RowIndex).Value, dgvData.Item(orderForIdIndex, dgvData.CurrentCell.RowIndex).Value, 0, Me, True})
                            End If

                        Case "authorise"
                            Dim idIndex As Integer = dgvData.Columns.IndexOf(dgvData.Columns("ID"))
                            Dim id As Integer = dgvData.Item(idIndex, dgvData.CurrentCell.RowIndex).Value

                            Dim dialogue As FRMPOInvoiceAuthReasons
                            dialogue = checkIfExists(GetType(FRMPOInvoiceAuthReasons).Name, True)
                            If dialogue Is Nothing Then
                                dialogue = Activator.CreateInstance(GetType(FRMPOInvoiceAuthReasons))
                            End If

                            dialogue.ShowInTaskbar = False
                            dialogue.AuthReason = Nothing
                            dialogue.AuthReasonDetail = Nothing
                            dialogue.ShowDialog()

                            If dialogue.DialogResult = DialogResult.OK Then
                                Dim NewAuthReason As String = String.Empty
                                If Not dialogue._AuthReason Is Nothing Then
                                    NewAuthReason = dialogue._AuthReason
                                End If
                                Dim NewAuthReasonDetail As String = String.Empty
                                If Not dialogue._AuthReasonDetail Is Nothing Then
                                    NewAuthReasonDetail = dialogue._AuthReasonDetail
                                End If

                                Dim sortedColumn As Integer = If(Me.dgvData.SortedColumn Is Nothing, 0, Me.dgvData.SortedColumn.Index)
                                Dim sortedDirection As SortOrder = Me.dgvData.SortOrder
                                DB.POInvoice.POInvoiceImport_UpdateAuthorised(id, True, loggedInUser.UserID, Now, NewAuthReason, NewAuthReasonDetail)
                                If _Department = "" Then
                                    Me.Data = DB.POInvoice.POInvoiceImport_RefreshData(_ValidateType, "%")
                                Else
                                    Me.Data = DB.POInvoice.POInvoiceImport_RefreshData(_ValidateType, _Department)
                                End If
                                Try
                                    Select Case sortedDirection
                                        Case SortOrder.Ascending
                                            Me.dgvData.Sort(Me.dgvData.Columns(sortedColumn), ListSortDirection.Ascending)
                                        Case SortOrder.Descending
                                            Me.dgvData.Sort(Me.dgvData.Columns(sortedColumn), ListSortDirection.Descending)
                                    End Select
                                Catch ex As Exception

                                End Try
                            Else
                            End If
                            dialogue.Close()
                    End Select

                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

End Class