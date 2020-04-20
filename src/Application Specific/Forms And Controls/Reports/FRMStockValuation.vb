Public Class FRMStockValuation : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents grpParts As System.Windows.Forms.GroupBox
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents chkExact As System.Windows.Forms.CheckBox
    Friend WithEvents dgParts As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpParts = New System.Windows.Forms.GroupBox
        Me.dgParts = New System.Windows.Forms.DataGrid
        Me.btnExport = New System.Windows.Forms.Button
        Me.grpFilter = New System.Windows.Forms.GroupBox
        Me.chkExact = New System.Windows.Forms.CheckBox
        Me.txtLocation = New System.Windows.Forms.TextBox
        Me.cboLocation = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.cboCategory = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtReference = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnReset = New System.Windows.Forms.Button
        Me.grpParts.SuspendLayout()
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpParts
        '
        Me.grpParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpParts.Controls.Add(Me.dgParts)
        Me.grpParts.Location = New System.Drawing.Point(8, 136)
        Me.grpParts.Name = "grpParts"
        Me.grpParts.Size = New System.Drawing.Size(630, 162)
        Me.grpParts.TabIndex = 2
        Me.grpParts.TabStop = False
        Me.grpParts.Text = "Part replacement costs based on supplier"
        '
        'dgParts
        '
        Me.dgParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgParts.DataMember = ""
        Me.dgParts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgParts.Location = New System.Drawing.Point(8, 19)
        Me.dgParts.Name = "dgParts"
        Me.dgParts.Size = New System.Drawing.Size(614, 135)
        Me.dgParts.TabIndex = 14
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 306)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.chkExact)
        Me.grpFilter.Controls.Add(Me.txtLocation)
        Me.grpFilter.Controls.Add(Me.cboLocation)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.txtName)
        Me.grpFilter.Controls.Add(Me.txtNumber)
        Me.grpFilter.Controls.Add(Me.cboCategory)
        Me.grpFilter.Controls.Add(Me.Label3)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.txtReference)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(630, 98)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'chkExact
        '
        Me.chkExact.AutoSize = True
        Me.chkExact.Location = New System.Drawing.Point(52, 41)
        Me.chkExact.Name = "chkExact"
        Me.chkExact.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkExact.Size = New System.Drawing.Size(237, 17)
        Me.chkExact.TabIndex = 17
        Me.chkExact.Text = "Advanced Location Filter Exact Match"
        Me.chkExact.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocation.Location = New System.Drawing.Point(307, 39)
        Me.txtLocation.MaxLength = 50
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(58, 21)
        Me.txtLocation.TabIndex = 16
        '
        'cboLocation
        '
        Me.cboLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLocation.FormattingEnabled = True
        Me.cboLocation.Location = New System.Drawing.Point(64, 14)
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.Size = New System.Drawing.Size(301, 21)
        Me.cboLocation.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Location"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(64, 69)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(301, 21)
        Me.txtName.TabIndex = 2
        '
        'txtNumber
        '
        Me.txtNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber.Location = New System.Drawing.Point(445, 69)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(181, 21)
        Me.txtNumber.TabIndex = 4
        '
        'cboCategory
        '
        Me.cboCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(445, 14)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(181, 21)
        Me.cboCategory.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(369, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Category"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(371, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Reference"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Name"
        '
        'txtReference
        '
        Me.txtReference.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReference.Location = New System.Drawing.Point(445, 41)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(181, 21)
        Me.txtReference.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(371, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Number"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 306)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 4
        Me.btnReset.Text = "Reset"
        '
        'FRMStockValuation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(646, 336)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpParts)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(654, 370)
        Me.Name = "FRMStockValuation"
        Me.Text = "Stock Valuation Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpParts, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.grpParts.ResumeLayout(False)
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupDataGrid()

        'PopulateDatagrid()

        ResetFilters()
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

    Private _dvParts As DataView
    Private Property PartsDataview() As DataView
        Get
            Return _dvParts
        End Get
        Set(ByVal value As DataView)
            _dvParts = value
            _dvParts.AllowNew = False
            _dvParts.AllowEdit = False
            _dvParts.AllowDelete = False
            _dvParts.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
            Me.dgParts.DataSource = PartsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedPartDataRow() As DataRow
        Get
            If Not Me.dgParts.CurrentRowIndex = -1 Then
                Return PartsDataview(Me.dgParts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgParts.TableStyles(0)

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 150
        Category.NullText = ""
        tbStyle.GridColumnStyles.Add(Category)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 150
        Name.NullText = ""
        tbStyle.GridColumnStyles.Add(Name)

        Dim Number As New DataGridLabelColumn
        Number.Format = ""
        Number.FormatInfo = Nothing
        Number.HeaderText = "Number"
        Number.MappingName = "Number"
        Number.ReadOnly = True
        Number.Width = 75
        Number.NullText = ""
        tbStyle.GridColumnStyles.Add(Number)

        Dim Reference As New DataGridLabelColumn
        Reference.Format = ""
        Reference.FormatInfo = Nothing
        Reference.HeaderText = "Reference"
        Reference.MappingName = "Reference"
        Reference.ReadOnly = True
        Reference.Width = 75
        Reference.NullText = ""
        tbStyle.GridColumnStyles.Add(Reference)

        Dim ReplacementCost As New DataGridLabelColumn
        ReplacementCost.Format = "C"
        ReplacementCost.FormatInfo = Nothing
        ReplacementCost.HeaderText = "Cost"
        ReplacementCost.MappingName = "ReplacementCost"
        ReplacementCost.ReadOnly = True
        ReplacementCost.Width = 100
        ReplacementCost.NullText = "£0.00"
        tbStyle.GridColumnStyles.Add(ReplacementCost)

        Dim Undistributed As New DataGridLabelColumn
        Undistributed.Format = "C"
        Undistributed.FormatInfo = Nothing
        Undistributed.HeaderText = "Undistributed"
        Undistributed.MappingName = "Undistributed"
        Undistributed.ReadOnly = True
        Undistributed.Width = 100
        Undistributed.NullText = "£0.00"
        tbStyle.GridColumnStyles.Add(Undistributed)

        Dim Supplier As New DataGridLabelColumn
        Supplier.Format = ""
        Supplier.FormatInfo = Nothing
        Supplier.HeaderText = "Supplier"
        Supplier.MappingName = "Supplier"
        Supplier.ReadOnly = True
        Supplier.Width = 250
        Supplier.NullText = "No Supplier"
        tbStyle.GridColumnStyles.Add(Supplier)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString

        Me.dgParts.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMStockValuation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        RunFilter()
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        RunFilter()
    End Sub

    Private Sub txtNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumber.TextChanged
        RunFilter()
    End Sub

    Private Sub txtReference_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReference.TextChanged
        RunFilter()
    End Sub

    Private Sub cboLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
        PopulateDatagrid()
        RunFilter()
    End Sub

    Private Sub txtLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged
        PopulateDatagrid()
        RunFilter()
    End Sub

    Private Sub chkExact_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkExact.CheckedChanged
        PopulateDatagrid()
        RunFilter()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub dgParts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgParts.DoubleClick
        If SelectedPartDataRow Is Nothing Then
            Exit Sub
        End If
        ShowForm(GetType(FRMPart), True, New Object() {SelectedPartDataRow.Item("PartID"), True})
        PopulateDatagrid()
        RunFilter()
    End Sub

#End Region

#Region "Functions"

    Private Sub PopulateDatagrid()
        Try
            Dim WarehouseID As Integer = 0
            Dim VanID As Integer = 0

            If Not Combo.GetSelectedItemValue(Me.cboLocation) = "0" Then
                If Combo.GetSelectedItemValue(Me.cboLocation).StartsWith("W") Then
                    WarehouseID = Combo.GetSelectedItemValue(Me.cboLocation).Replace("W", "")
                Else
                    VanID = Combo.GetSelectedItemValue(Me.cboLocation).Replace("V", "")
                End If
            End If

            PartsDataview = New DataView(DB.Part.Stock_Valuation(0, WarehouseID, VanID, Me.txtLocation.Text.Trim, Me.chkExact.Checked).Tables(0))
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        'PopulateDatagrid()

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Location"))
        dt.Columns.Add(New DataColumn("Name"))

        For Each row As DataRow In DB.Warehouse.Warehouse_GetAll().Table.Rows
            Dim r As DataRow = dt.NewRow
            r("Location") = "W" & row.Item("WarehouseID")
            r("Name") = row.Item("Name")
            dt.Rows.Add(r)
        Next
        For Each row As DataRow In DB.Van.Van_GetAll(False).Table.Rows
            Dim r As DataRow = dt.NewRow
            r("Location") = "V" & row.Item("VanID")
            r("Name") = row.Item("Registration")
            dt.Rows.Add(r)
        Next

        Combo.SetUpCombo(Me.cboLocation, dt, "Location", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboLocation, 0)

        Combo.SetUpCombo(Me.cboCategory, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboCategory, 0)
        Me.txtName.Text = ""
        Me.txtNumber.Text = ""
        Me.txtReference.Text = ""

        RunFilter()
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = "1 = 1"

        If Not Combo.GetSelectedItemValue(Me.cboCategory) = 0 Then
            whereClause += " AND CategoryID = " & Combo.GetSelectedItemValue(Me.cboCategory) & ""
        End If
        If Not Me.txtName.Text.Trim.Length = 0 Then
            whereClause += " AND Name LIKE '%" & Me.txtName.Text.Trim & "%'"
        End If
        If Not Me.txtNumber.Text.Trim.Length = 0 Then
            whereClause += " AND Number LIKE '%" & Me.txtNumber.Text.Trim & "%'"
        End If
        If Not Me.txtReference.Text.Trim.Length = 0 Then
            whereClause += " AND Reference LIKE '%" & Me.txtReference.Text.Trim & "%'"
        End If

        PartsDataview.RowFilter = whereClause
    End Sub

    Public Sub Export()
        Dim exportData As New DataTable
        exportData.Columns.Add("Category")
        exportData.Columns.Add("Name")
        exportData.Columns.Add("Number")
        exportData.Columns.Add("Reference")
        exportData.Columns.Add("Cost")
        exportData.Columns.Add("Undistributed")
        exportData.Columns.Add("Supplier")

        For itm As Integer = 0 To CType(dgParts.DataSource, DataView).Count - 1
            dgParts.CurrentRowIndex = itm
            Dim newRw As DataRow
            newRw = exportData.NewRow

            newRw("Category") = SelectedPartDataRow("Category")
            newRw("Name") = SelectedPartDataRow("Name")
            newRw("Number") = SelectedPartDataRow("Number")
            newRw("Reference") = SelectedPartDataRow("Reference")
            newRw("Cost") = Format(SelectedPartDataRow("ReplacementCost"), "F")
            newRw("Undistributed") = Format(SelectedPartDataRow("Undistributed"), "F")
            newRw("Supplier") = SelectedPartDataRow("Supplier")

            exportData.Rows.Add(newRw)

            dgParts.UnSelect(itm)
        Next itm

        Dim exporter As New Entity.Sys.Exporting(exportData, "Stock Value Report")
        exporter = Nothing
    End Sub

#End Region

End Class
