Public Class DLGPickPartProductSupplier : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents grpResults As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dgResults As System.Windows.Forms.DataGrid
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.grpResults = New System.Windows.Forms.GroupBox
        Me.dgResults = New System.Windows.Forms.DataGrid
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblDetails = New System.Windows.Forms.Label
        Me.grpResults.SuspendLayout()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filter By Name"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(104, 72)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(584, 21)
        Me.txtFilter.TabIndex = 1
        Me.txtFilter.Text = ""
        '
        'grpResults
        '
        Me.grpResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpResults.Controls.Add(Me.dgResults)
        Me.grpResults.Location = New System.Drawing.Point(8, 104)
        Me.grpResults.Name = "grpResults"
        Me.grpResults.Size = New System.Drawing.Size(680, 216)
        Me.grpResults.TabIndex = 4
        Me.grpResults.TabStop = False
        Me.grpResults.Text = "Select record and click OK"
        '
        'dgResults
        '
        Me.dgResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResults.DataMember = ""
        Me.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResults.Location = New System.Drawing.Point(8, 25)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.Size = New System.Drawing.Size(664, 183)
        Me.dgResults.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(632, 328)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(56, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(8, 328)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(56, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'lblDetails
        '
        Me.lblDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetails.Location = New System.Drawing.Point(8, 40)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(680, 24)
        Me.lblDetails.TabIndex = 7
        '
        'DLGPickPartProductSupplier
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(696, 358)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpResults)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(704, 392)
        Me.Name = "DLGPickPartProductSupplier"
        Me.Text = "Find {0}"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtFilter, 0)
        Me.Controls.SetChildIndex(Me.grpResults, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.lblDetails, 0)
        Me.grpResults.ResumeLayout(False)
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Me.ActiveControl = Me.txtFilter
        Me.txtFilter.Focus()

        SetupDG()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Properties"

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property

    Private _TableToSearch As Entity.Sys.Enums.TableNames = Entity.Sys.Enums.TableNames.NO_TABLE
    Public Property TableToSearch() As Entity.Sys.Enums.TableNames
        Get
            Return _TableToSearch
        End Get
        Set(ByVal Value As Entity.Sys.Enums.TableNames)
            _TableToSearch = Value

            Me.Text = "Pick From Available Suppliers"

            Select Case TableToSearch
                Case Entity.Sys.Enums.TableNames.tblPartSupplier
                    Records = DB.PartSupplier.Get_ByPartID(ID)

                    Dim oPart As Entity.Parts.Part = DB.Part.Part_Get(ID)
                    Me.lblDetails.Text = "Select supplier for part : " & oPart.Name & " (" & oPart.Number & ")"
                Case Entity.Sys.Enums.TableNames.tblProductSupplier
                    Records = DB.ProductSupplier.Get_ByProductID(ID)

                    Dim oProduct As Entity.Products.Product = DB.Product.Product_Get(ID)
                    Me.lblDetails.Text = "Select supplier for product : " & oProduct.Name & " (" & oProduct.Number & ")"
            End Select
        End Set
    End Property

    Private _dvRecords As DataView
    Private Property Records() As DataView
        Get
            Return _dvRecords
        End Get
        Set(ByVal value As DataView)
            _dvRecords = value
            _dvRecords.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString
            _dvRecords.AllowNew = False
            _dvRecords.AllowEdit = False
            _dvRecords.AllowDelete = False
            Me.dgResults.DataSource = Records
        End Set
    End Property

    Private ReadOnly Property SelectedDataRow() As DataRow
        Get
            If Not Me.dgResults.CurrentRowIndex = -1 Then
                Return Records(Me.dgResults.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDG()
        Dim tStyle As DataGridTableStyle = Me.dgResults.TableStyles(0)

        Select Case TableToSearch
            Case Entity.Sys.Enums.TableNames.tblPartSupplier

                Dim Supplier As New DataGridLabelColumn
                Supplier.Format = ""
                Supplier.FormatInfo = Nothing
                Supplier.HeaderText = "Supplier"
                Supplier.MappingName = "SupplierName"
                Supplier.ReadOnly = True
                Supplier.Width = 130
                Supplier.NullText = ""
                tStyle.GridColumnStyles.Add(Supplier)

                Dim PartName As New DataGridLabelColumn
                PartName.Format = ""
                PartName.FormatInfo = Nothing
                PartName.HeaderText = "Name"
                PartName.MappingName = "Name"
                PartName.ReadOnly = True
                PartName.Width = 130
                PartName.NullText = ""
                tStyle.GridColumnStyles.Add(PartName)

                Dim PartNumber As New DataGridLabelColumn
                PartNumber.Format = ""
                PartNumber.FormatInfo = Nothing
                PartNumber.HeaderText = "Part Number"
                PartNumber.MappingName = "Number"
                PartNumber.ReadOnly = True
                PartNumber.Width = 130
                PartNumber.NullText = ""
                tStyle.GridColumnStyles.Add(PartNumber)

                Dim QuantityInPack As New DataGridLabelColumn
                QuantityInPack.Format = ""
                QuantityInPack.FormatInfo = Nothing
                QuantityInPack.HeaderText = "Quantity In Pack"
                QuantityInPack.MappingName = "QuantityInPack"
                QuantityInPack.ReadOnly = True
                QuantityInPack.Width = 130
                QuantityInPack.NullText = ""
                tStyle.GridColumnStyles.Add(QuantityInPack)

                Dim PartCode As New DataGridLabelColumn
                PartCode.Format = ""
                PartCode.FormatInfo = Nothing
                PartCode.HeaderText = "Supplier Part Number"
                PartCode.MappingName = "PartCode"
                PartCode.ReadOnly = True
                PartCode.Width = 130
                PartCode.NullText = ""
                tStyle.GridColumnStyles.Add(PartCode)

                Dim Price As New DataGridLabelColumn
                Price.Format = ""
                Price.FormatInfo = Nothing
                Price.HeaderText = "Price"
                Price.MappingName = "Price"
                Price.ReadOnly = True
                Price.Width = 130
                Price.NullText = ""
                tStyle.GridColumnStyles.Add(Price)

            Case Entity.Sys.Enums.TableNames.tblProductSupplier

                Dim Supplier As New DataGridLabelColumn
                Supplier.Format = ""
                Supplier.FormatInfo = Nothing
                Supplier.HeaderText = "Supplier"
                Supplier.MappingName = "SupplierName"
                Supplier.ReadOnly = True
                Supplier.Width = 130
                Supplier.NullText = ""
                tStyle.GridColumnStyles.Add(Supplier)

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
                ProductNumber.HeaderText = "Product Number"
                ProductNumber.MappingName = "Number"
                ProductNumber.ReadOnly = True
                ProductNumber.Width = 130
                ProductNumber.NullText = ""
                tStyle.GridColumnStyles.Add(ProductNumber)

                Dim QuantityInPack As New DataGridLabelColumn
                QuantityInPack.Format = ""
                QuantityInPack.FormatInfo = Nothing
                QuantityInPack.HeaderText = "Quantity In Pack"
                QuantityInPack.MappingName = "QuantityInPack"
                QuantityInPack.ReadOnly = True
                QuantityInPack.Width = 130
                QuantityInPack.NullText = ""
                tStyle.GridColumnStyles.Add(QuantityInPack)

                Dim ProductCode As New DataGridLabelColumn
                ProductCode.Format = ""
                ProductCode.FormatInfo = Nothing
                ProductCode.HeaderText = "Supplier Product Number"
                ProductCode.MappingName = "ProductCode"
                ProductCode.ReadOnly = True
                ProductCode.Width = 130
                ProductCode.NullText = ""
                tStyle.GridColumnStyles.Add(ProductCode)

                Dim Price As New DataGridLabelColumn
                Price.Format = ""
                Price.FormatInfo = Nothing
                Price.HeaderText = "Price"
                Price.MappingName = "Price"
                Price.ReadOnly = True
                Price.Width = 130
                Price.NullText = ""
                tStyle.GridColumnStyles.Add(Price)

        End Select

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString
        Me.dgResults.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub DLGPickPartProductSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        RunFilter()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub dgResults_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgResults.DoubleClick
        SelectItem()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SelectItem()
    End Sub

#End Region

#Region "Functions"

    Private Sub SelectItem()
        If SelectedDataRow Is Nothing Then
            ShowMessage("No record selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Select Case TableToSearch
            Case Entity.Sys.Enums.TableNames.tblPartSupplier
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("PartSupplierID"))
            Case Entity.Sys.Enums.TableNames.tblProductSupplier
                ID = Entity.Sys.Helper.MakeIntegerValid(SelectedDataRow.Item("ProductSupplierID"))
        End Select

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = "Deleted = 0"

        If Not Me.txtFilter.Text.Trim.Length = 0 Then
            whereClause += " AND SupplierName LIKE '" & Me.txtFilter.Text.Trim & "%'"
        End If

        Records.RowFilter = whereClause
    End Sub

#End Region

End Class
