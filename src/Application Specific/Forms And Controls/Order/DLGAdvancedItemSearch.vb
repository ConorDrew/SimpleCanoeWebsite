Public Class DLGAdvancedItemSearch : Inherits FSM.FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        SetupPartsResultsDataGrid()
        Combo.SetUpCombo(Me.cboSearchFor, DynamicDataTables.Setup_Advanced_Search_Options(Entity.Sys.Enums.MenuTypes.Spares), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboSearchOn As System.Windows.Forms.ComboBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents cboSearchFor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnFindSupplier As System.Windows.Forms.Button
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgResults As System.Windows.Forms.DataGrid
    Friend WithEvents btnRequest As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnFindSupplier = New System.Windows.Forms.Button
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dgResults = New System.Windows.Forms.DataGrid
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtCriteria = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cboSearchOn = New System.Windows.Forms.ComboBox
        Me.label17 = New System.Windows.Forms.Label
        Me.cboSearchFor = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnRequest = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFindSupplier)
        Me.GroupBox1.Controls.Add(Me.txtSupplier)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dgResults)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtCriteria)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cboSearchOn)
        Me.GroupBox1.Controls.Add(Me.label17)
        Me.GroupBox1.Controls.Add(Me.cboSearchFor)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(608, 408)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'btnFindSupplier
        '
        Me.btnFindSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSupplier.BackColor = System.Drawing.Color.White
        Me.btnFindSupplier.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSupplier.Location = New System.Drawing.Point(560, 379)
        Me.btnFindSupplier.Name = "btnFindSupplier"
        Me.btnFindSupplier.Size = New System.Drawing.Size(32, 24)
        Me.btnFindSupplier.TabIndex = 95
        Me.btnFindSupplier.Text = "..."
        '
        'txtSupplier
        '
        Me.txtSupplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplier.Location = New System.Drawing.Point(88, 379)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(464, 21)
        Me.txtSupplier.TabIndex = 94
        Me.txtSupplier.Text = ""
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 376)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 24)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Supplier"
        '
        'dgResults
        '
        Me.dgResults.DataMember = ""
        Me.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResults.Location = New System.Drawing.Point(8, 88)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.Size = New System.Drawing.Size(592, 280)
        Me.dgResults.TabIndex = 8
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(520, 56)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        '
        'txtCriteria
        '
        Me.txtCriteria.Location = New System.Drawing.Point(104, 56)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(400, 21)
        Me.txtCriteria.TabIndex = 5
        Me.txtCriteria.Text = ""
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 56)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 23)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Criteria:"
        '
        'cboSearchOn
        '
        Me.cboSearchOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchOn.Location = New System.Drawing.Point(400, 24)
        Me.cboSearchOn.Name = "cboSearchOn"
        Me.cboSearchOn.Size = New System.Drawing.Size(200, 21)
        Me.cboSearchOn.TabIndex = 3
        '
        'label17
        '
        Me.label17.Location = New System.Drawing.Point(312, 24)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(80, 23)
        Me.label17.TabIndex = 2
        Me.label17.Text = "Search On:"
        '
        'cboSearchFor
        '
        Me.cboSearchFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchFor.Items.AddRange(New Object() {"Products", "Parts"})
        Me.cboSearchFor.Location = New System.Drawing.Point(104, 24)
        Me.cboSearchFor.Name = "cboSearchFor"
        Me.cboSearchFor.Size = New System.Drawing.Size(200, 21)
        Me.cboSearchFor.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 23)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Search For:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(120, 464)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'btnRequest
        '
        Me.btnRequest.Location = New System.Drawing.Point(8, 464)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(104, 23)
        Me.btnRequest.TabIndex = 8
        Me.btnRequest.Text = "Request Prices"
        '
        'DLGAdvancedItemSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(624, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnRequest)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.MaximumSize = New System.Drawing.Size(632, 528)
        Me.MinimumSize = New System.Drawing.Size(632, 528)
        Me.Name = "DLGAdvancedItemSearch"
        Me.Text = "Advanced Search"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnRequest, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Properties"

    Private _quoteID As Integer

    Public Property QuoteID() As Integer
        Get
            Return _quoteID
        End Get
        Set(ByVal Value As Integer)
            _quoteID = Value
        End Set
    End Property

    Private _supplier As Entity.Suppliers.Supplier

    Public Property Supplier() As Entity.Suppliers.Supplier
        Get
            Return _supplier
        End Get
        Set(ByVal Value As Entity.Suppliers.Supplier)
            _supplier = Value
            If Not _supplier Is Nothing Then
                Me.txtSupplier.Text = _supplier.Name & " (" & _supplier.AccountNumber & ")"
            End If
        End Set
    End Property

    Public Property ItemDataView() As DataView
        Get
            Return m_dTable2
        End Get
        Set(ByVal Value As DataView)
            m_dTable2 = Value
            m_dTable2.Table.TableName = "tblItem"
            m_dTable2.AllowNew = False
            m_dTable2.AllowEdit = False
            m_dTable2.AllowDelete = False
            Me.dgResults.DataSource = ItemDataView
        End Set
    End Property

    Private m_dTable2 As DataView = Nothing

    Private ReadOnly Property SelectedItemDataRow() As DataRow
        Get
            If Not Me.dgResults.CurrentRowIndex = -1 Then
                Return ItemDataView(Me.dgResults.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub btnFindSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSupplier.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSupplier)
        If Not ID = 0 Then
            Supplier = DB.Supplier.Supplier_Get(ID)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub cboSearchFor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchFor.SelectedIndexChanged
        Combo.SetUpCombo(Me.cboSearchOn, DynamicDataTables.Setup_Search_On_Options(Entity.Sys.Enums.MenuTypes.Spares, Combo.GetSelectedItemValue(Me.cboSearchFor)), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        If Combo.GetSelectedItemValue(cboSearchFor) = Entity.Sys.Enums.TableNames.tblPart Then
            SetupPartsResultsDataGrid()
        ElseIf Combo.GetSelectedItemValue(cboSearchFor) = Entity.Sys.Enums.TableNames.tblProduct Then
            SetupProductsResultsDataGrid()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Combo.GetSelectedItemValue(cboSearchFor) = Entity.Sys.Enums.TableNames.tblPart Then
            ItemDataView = DB.Part.Part_Search(Me.txtCriteria.Text.Trim, Combo.GetSelectedItemValue(cboSearchOn))
        ElseIf Combo.GetSelectedItemValue(cboSearchFor) = Entity.Sys.Enums.TableNames.tblProduct Then
            ItemDataView = DB.Product.Product_Search(Me.txtCriteria.Text.Trim, Combo.GetSelectedItemValue(cboSearchOn))
        End If
    End Sub

    Private Sub btnRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequest.Click
        SaveRequests()
    End Sub

#End Region

#Region "Setup"

    Public Function SetupPartsResultsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgResults)
        dgResults.ReadOnly = False

        Dim tStyle As DataGridTableStyle = Me.dgResults.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim chk As New DataGridCheckBox
        chk.HeaderText = "Selected"
        chk.MappingName = "Selected"
        chk.ReadOnly = True
        chk.Width = 50
        chk.NullText = ""
        tStyle.GridColumnStyles.Add(chk)

        Dim PartName As New DataGridLabelColumn
        PartName.Format = ""
        PartName.FormatInfo = Nothing
        PartName.HeaderText = "Name"
        PartName.MappingName = "Name"
        PartName.ReadOnly = True
        PartName.Width = 120
        PartName.NullText = ""
        tStyle.GridColumnStyles.Add(PartName)

        Dim PartNumber As New DataGridLabelColumn
        PartNumber.Format = ""
        PartNumber.FormatInfo = Nothing
        PartNumber.HeaderText = "Number"
        PartNumber.MappingName = "Number"
        PartNumber.ReadOnly = True
        PartNumber.Width = 110
        PartNumber.NullText = ""
        tStyle.GridColumnStyles.Add(PartNumber)

        Dim PartReference As New DataGridLabelColumn
        PartReference.Format = ""
        PartReference.FormatInfo = Nothing
        PartReference.HeaderText = "Part Reference"
        PartReference.MappingName = "Reference"
        PartReference.ReadOnly = True
        PartReference.Width = 170
        PartReference.NullText = ""
        tStyle.GridColumnStyles.Add(PartReference)

        Dim Quantity As New DataGridOrderTextBoxColumn
        Quantity.Format = "F"
        Quantity.FormatInfo = Nothing
        Quantity.HeaderText = "Quantity"
        Quantity.MappingName = "QuantityHolder"
        Quantity.ReadOnly = False
        Quantity.Width = 90
        Quantity.NullText = ""
        tStyle.GridColumnStyles.Add(Quantity)

        tStyle.ReadOnly = False
        tStyle.MappingName = "tblItem"
        Me.dgResults.TableStyles.Add(tStyle)
    End Function

    Public Function SetupProductsResultsDataGrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgResults)
        dgResults.ReadOnly = False

        Dim tStyle As DataGridTableStyle = Me.dgResults.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim chk As New DataGridCheckBox
        chk.HeaderText = "Selected"
        chk.MappingName = "Selected"
        chk.ReadOnly = True
        chk.Width = 50
        chk.NullText = ""
        tStyle.GridColumnStyles.Add(chk)

        Dim ProductName As New DataGridLabelColumn
        ProductName.Format = ""
        ProductName.FormatInfo = Nothing
        ProductName.HeaderText = "Name"
        ProductName.MappingName = "typemakemodel"
        ProductName.ReadOnly = True
        ProductName.Width = 130
        ProductName.NullText = ""
        tStyle.GridColumnStyles.Add(ProductName)

        Dim ProductNumber As New DataGridLabelColumn
        ProductNumber.Format = ""
        ProductNumber.FormatInfo = Nothing
        ProductNumber.HeaderText = "Number"
        ProductNumber.MappingName = "Number"
        ProductNumber.ReadOnly = True
        ProductNumber.Width = 130
        ProductNumber.NullText = ""
        tStyle.GridColumnStyles.Add(ProductNumber)

        Dim ProductReference As New DataGridLabelColumn
        ProductReference.Format = ""
        ProductReference.FormatInfo = Nothing
        ProductReference.HeaderText = "Product Reference"
        ProductReference.MappingName = "Reference"
        ProductReference.ReadOnly = True
        ProductReference.Width = 200
        ProductReference.NullText = ""
        tStyle.GridColumnStyles.Add(ProductReference)

        Dim Quantity As New DataGridOrderTextBoxColumn
        Quantity.Format = "F"
        Quantity.FormatInfo = Nothing
        Quantity.HeaderText = "Quantity"
        Quantity.MappingName = "QuantityHolder"
        Quantity.ReadOnly = False
        Quantity.Width = 90
        Quantity.NullText = ""
        tStyle.GridColumnStyles.Add(Quantity)

        tStyle.ReadOnly = False
        tStyle.MappingName = "tblItem"
        Me.dgResults.TableStyles.Add(tStyle)
    End Function

#End Region

#Region "Functions"

    Private Function SaveRequests()

        If Supplier Is Nothing Then
            ShowMessage("Please select a supplier", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If

        For Each row As DataRow In ItemDataView.Table.Select("Selected = 1")
            If IsDBNull(row.Item("QuantityHolder")) Or Not IsNumeric(row.Item("QuantityHolder")) Then
                ShowMessage("Please enter a quantity for each Item you have checked", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
        Next

        If QuoteID > 0 Then
            For Each row As DataRow In ItemDataView.Table.Select("Selected = 1")
                If Combo.GetSelectedItemValue(Me.cboSearchFor) = Entity.Sys.Enums.TableNames.tblPart Then
                    Dim partRequest As New Entity.PartSupplierPriceRequests.PartSupplierPriceRequest
                    partRequest.SetQuoteID = QuoteID
                    partRequest.SetPartID = row.Item("partID")
                    partRequest.SetQuantityInPack = row.Item("QuantityHolder")
                    partRequest.SetSupplierID = Supplier.SupplierID
                    partRequest.SetComplete = 0
                    DB.PartPriceRequest.InsertForQuote(partRequest)
                ElseIf Combo.GetSelectedItemValue(Me.cboSearchFor) = Entity.Sys.Enums.TableNames.tblProduct Then
                    Dim productRequest As New Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequest
                    productRequest.SetQuoteID = QuoteID
                    productRequest.SetProductID = row.Item("productID")
                    productRequest.SetQuantityInPack = row.Item("QuantityHolder")
                    productRequest.SetSupplierID = Supplier.SupplierID
                    productRequest.SetComplete = 0
                    DB.ProductPriceRequest.InsertForQuote(productRequest)
                End If
            Next
        End If

        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Function

#End Region

End Class