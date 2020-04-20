Public Class FRMStockMove : Inherits FSM.FRMBaseForm : Implements IForm

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

    Friend WithEvents radWarehouseCurrent As System.Windows.Forms.RadioButton
    Friend WithEvents radVanCurrent As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboLocationCurrent As System.Windows.Forms.ComboBox
    Friend WithEvents grpCurrent As System.Windows.Forms.GroupBox
    Friend WithEvents grpNew As System.Windows.Forms.GroupBox
    Friend WithEvents radWarehouseNew As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents radVanNew As System.Windows.Forms.RadioButton
    Friend WithEvents cboLocationNew As System.Windows.Forms.ComboBox
    Friend WithEvents grpItems As System.Windows.Forms.GroupBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgItems As System.Windows.Forms.DataGrid
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSelectAll As Button
    Friend WithEvents btnDeselectAll As Button
    Friend WithEvents Label4 As Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.radWarehouseCurrent = New System.Windows.Forms.RadioButton()
        Me.radVanCurrent = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboLocationCurrent = New System.Windows.Forms.ComboBox()
        Me.grpCurrent = New System.Windows.Forms.GroupBox()
        Me.grpNew = New System.Windows.Forms.GroupBox()
        Me.radWarehouseNew = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.radVanNew = New System.Windows.Forms.RadioButton()
        Me.cboLocationNew = New System.Windows.Forms.ComboBox()
        Me.grpItems = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgItems = New System.Windows.Forms.DataGrid()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.grpCurrent.SuspendLayout()
        Me.grpNew.SuspendLayout()
        Me.grpItems.SuspendLayout()
        CType(Me.dgItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'radWarehouseCurrent
        '
        Me.radWarehouseCurrent.Checked = True
        Me.radWarehouseCurrent.Location = New System.Drawing.Point(8, 20)
        Me.radWarehouseCurrent.Name = "radWarehouseCurrent"
        Me.radWarehouseCurrent.Size = New System.Drawing.Size(96, 26)
        Me.radWarehouseCurrent.TabIndex = 1
        Me.radWarehouseCurrent.TabStop = True
        Me.radWarehouseCurrent.Text = "Warehouse"
        '
        'radVanCurrent
        '
        Me.radVanCurrent.Location = New System.Drawing.Point(110, 20)
        Me.radVanCurrent.Name = "radVanCurrent"
        Me.radVanCurrent.Size = New System.Drawing.Size(99, 26)
        Me.radVanCurrent.TabIndex = 2
        Me.radVanCurrent.Text = "Stock Profile"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(214, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 23)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = ">"
        '
        'cboLocationCurrent
        '
        Me.cboLocationCurrent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLocationCurrent.Location = New System.Drawing.Point(247, 25)
        Me.cboLocationCurrent.Name = "cboLocationCurrent"
        Me.cboLocationCurrent.Size = New System.Drawing.Size(337, 21)
        Me.cboLocationCurrent.TabIndex = 3
        '
        'grpCurrent
        '
        Me.grpCurrent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCurrent.Controls.Add(Me.radWarehouseCurrent)
        Me.grpCurrent.Controls.Add(Me.Label5)
        Me.grpCurrent.Controls.Add(Me.radVanCurrent)
        Me.grpCurrent.Controls.Add(Me.cboLocationCurrent)
        Me.grpCurrent.Location = New System.Drawing.Point(4, 38)
        Me.grpCurrent.Name = "grpCurrent"
        Me.grpCurrent.Size = New System.Drawing.Size(592, 58)
        Me.grpCurrent.TabIndex = 1
        Me.grpCurrent.TabStop = False
        Me.grpCurrent.Text = "Select current stock location"
        '
        'grpNew
        '
        Me.grpNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNew.Controls.Add(Me.radWarehouseNew)
        Me.grpNew.Controls.Add(Me.Label1)
        Me.grpNew.Controls.Add(Me.radVanNew)
        Me.grpNew.Controls.Add(Me.cboLocationNew)
        Me.grpNew.Location = New System.Drawing.Point(4, 337)
        Me.grpNew.Name = "grpNew"
        Me.grpNew.Size = New System.Drawing.Size(592, 58)
        Me.grpNew.TabIndex = 3
        Me.grpNew.TabStop = False
        Me.grpNew.Text = "Select new stock location"
        '
        'radWarehouseNew
        '
        Me.radWarehouseNew.Checked = True
        Me.radWarehouseNew.Location = New System.Drawing.Point(8, 20)
        Me.radWarehouseNew.Name = "radWarehouseNew"
        Me.radWarehouseNew.Size = New System.Drawing.Size(96, 26)
        Me.radWarehouseNew.TabIndex = 1
        Me.radWarehouseNew.TabStop = True
        Me.radWarehouseNew.Text = "Warehouse"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(214, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = ">"
        '
        'radVanNew
        '
        Me.radVanNew.Location = New System.Drawing.Point(110, 20)
        Me.radVanNew.Name = "radVanNew"
        Me.radVanNew.Size = New System.Drawing.Size(98, 26)
        Me.radVanNew.TabIndex = 2
        Me.radVanNew.Text = "Stock Profile"
        '
        'cboLocationNew
        '
        Me.cboLocationNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLocationNew.Location = New System.Drawing.Point(247, 25)
        Me.cboLocationNew.Name = "cboLocationNew"
        Me.cboLocationNew.Size = New System.Drawing.Size(337, 21)
        Me.cboLocationNew.TabIndex = 3
        '
        'grpItems
        '
        Me.grpItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpItems.Controls.Add(Me.Label4)
        Me.grpItems.Controls.Add(Me.btnSelectAll)
        Me.grpItems.Controls.Add(Me.btnDeselectAll)
        Me.grpItems.Controls.Add(Me.txtFilter)
        Me.grpItems.Controls.Add(Me.Label3)
        Me.grpItems.Controls.Add(Me.txtQuantity)
        Me.grpItems.Controls.Add(Me.Label2)
        Me.grpItems.Controls.Add(Me.dgItems)
        Me.grpItems.Location = New System.Drawing.Point(4, 102)
        Me.grpItems.Name = "grpItems"
        Me.grpItems.Size = New System.Drawing.Size(592, 229)
        Me.grpItems.TabIndex = 2
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "Select item to move"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(295, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(255, 14)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "The current quantity will be moved across"
        Me.Label4.Visible = False
        '
        'btnSelectAll
        '
        Me.btnSelectAll.AccessibleDescription = "Export Job List To Excel"
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(400, 18)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(88, 23)
        Me.btnSelectAll.TabIndex = 21
        Me.btnSelectAll.Text = "Select All"
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeselectAll.Location = New System.Drawing.Point(496, 18)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(88, 23)
        Me.btnDeselectAll.TabIndex = 22
        Me.btnDeselectAll.Text = "Deselect All"
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(48, 20)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(335, 21)
        Me.txtFilter.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Filter"
        '
        'txtQuantity
        '
        Me.txtQuantity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtQuantity.Location = New System.Drawing.Point(189, 198)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 21)
        Me.txtQuantity.TabIndex = 3
        Me.txtQuantity.Text = "1"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(6, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Enter quantity being moved"
        '
        'dgItems
        '
        Me.dgItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgItems.DataMember = ""
        Me.dgItems.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgItems.Location = New System.Drawing.Point(6, 47)
        Me.dgItems.Name = "dgItems"
        Me.dgItems.Size = New System.Drawing.Size(580, 145)
        Me.dgItems.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(4, 401)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(59, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMove.Location = New System.Drawing.Point(537, 401)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(59, 23)
        Me.btnMove.TabIndex = 4
        Me.btnMove.Text = "Move"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'FRMStockMove
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(601, 435)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpItems)
        Me.Controls.Add(Me.grpNew)
        Me.Controls.Add(Me.grpCurrent)
        Me.MinimumSize = New System.Drawing.Size(609, 469)
        Me.Name = "FRMStockMove"
        Me.Text = "Internal Parts Transfer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpCurrent, 0)
        Me.Controls.SetChildIndex(Me.grpNew, 0)
        Me.Controls.SetChildIndex(Me.grpItems, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.btnMove, 0)
        Me.grpCurrent.ResumeLayout(False)
        Me.grpNew.ResumeLayout(False)
        Me.grpItems.ResumeLayout(False)
        Me.grpItems.PerformLayout()
        CType(Me.dgItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        Combo.SetUpCombo(Me.cboLocationCurrent, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.None)
        If (Me.cboLocationCurrent.Items.Count > 0) Then Me.cboLocationCurrent.SelectedIndex = 0

        ShowStock(Combo.GetSelectedItemValue(Me.cboLocationCurrent), 0)

        Combo.SetUpCombo(Me.cboLocationNew, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.None)
        If (Me.cboLocationNew.Items.Count > 0) Then Me.cboLocationNew.SelectedIndex = 0

        SetupDatagrid()
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

    Private CurrentQty As Integer = 1

    Private _StockDataView As DataView = Nothing

    Public Property StockDataView() As DataView
        Get
            Return _StockDataView
        End Get
        Set(ByVal Value As DataView)
            _StockDataView = Value
            _StockDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
            _StockDataView.AllowNew = False
            _StockDataView.AllowEdit = False
            _StockDataView.AllowDelete = False
            Me.dgItems.DataSource = StockDataView
        End Set
    End Property

    Private ReadOnly Property SelectedStockDataRow() As DataRow
        Get
            If Not Me.dgItems.CurrentRowIndex = -1 Then
                Return StockDataView(Me.dgItems.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgItems)

        Dim tStyle As DataGridTableStyle = Me.dgItems.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        tStyle.ReadOnly = False
        tStyle.AllowSorting = False
        dgItems.ReadOnly = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Select"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim Description As New DataGridLabelColumn
        Description.Format = ""
        Description.FormatInfo = Nothing
        Description.HeaderText = "Description"
        Description.MappingName = "Description"
        Description.ReadOnly = True
        Description.Width = 180
        Description.NullText = ""
        tStyle.GridColumnStyles.Add(Description)

        Dim Number As New DataGridLabelColumn
        Number.Format = ""
        Number.FormatInfo = Nothing
        Number.HeaderText = "Number"
        Number.MappingName = "Number"
        Number.ReadOnly = True
        Number.Width = 140
        Number.NullText = ""
        tStyle.GridColumnStyles.Add(Number)

        Dim Reference As New DataGridLabelColumn
        Reference.Format = ""
        Reference.FormatInfo = Nothing
        Reference.HeaderText = "Reference"
        Reference.MappingName = "Reference"
        Reference.ReadOnly = True
        Reference.Width = 200
        Reference.NullText = ""
        tStyle.GridColumnStyles.Add(Reference)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 120
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblStock.ToString
        Me.dgItems.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMStockMove_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub dgItems_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgItems.DoubleClick
        If SelectedStockDataRow Is Nothing Then
            Exit Sub
        End If
        If SelectedStockDataRow.Item("Type") = "PART" Then
            ShowForm(GetType(FRMPart), True, New Object() {SelectedStockDataRow.Item("ID"), True})
            ShowStock(Combo.GetSelectedItemValue(Me.cboLocationCurrent), 0)
        End If
    End Sub

    Private Sub radWarehouseCurrent_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radWarehouseCurrent.CheckedChanged
        If radWarehouseCurrent.Checked Then
            Combo.SetUpCombo(Me.cboLocationCurrent, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.None)

            If (Me.cboLocationCurrent.Items.Count > 0) Then
                Me.cboLocationCurrent.SelectedIndex = 0
                ShowStock(Combo.GetSelectedItemValue(Me.cboLocationCurrent), 0)
            End If
        End If
    End Sub

    Private Sub radVanCurrent_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radVanCurrent.CheckedChanged
        If radVanCurrent.Checked Then
            Combo.SetUpCombo(Me.cboLocationCurrent, DB.Van.Van_GetAll(False).Table, "VanID", "Registration", Entity.Sys.Enums.ComboValues.None)

            If (Me.cboLocationCurrent.Items.Count > 0) Then
                Me.cboLocationCurrent.SelectedIndex = 0
                ShowStock(0, Combo.GetSelectedItemValue(Me.cboLocationCurrent))
            End If
        End If
    End Sub

    Private Sub radWarehouseNew_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radWarehouseNew.CheckedChanged
        If radWarehouseNew.Checked Then
            Combo.SetUpCombo(Me.cboLocationNew, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.None)
            If (Me.cboLocationNew.Items.Count > 0) Then
                Me.cboLocationNew.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub radVanNew_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radVanNew.CheckedChanged
        If radVanNew.Checked Then
            Combo.SetUpCombo(Me.cboLocationNew, DB.Van.Van_GetAll(False).Table, "VanID", "Registration", Entity.Sys.Enums.ComboValues.None)

            If (Me.cboLocationNew.Items.Count > 0) Then
                Me.cboLocationNew.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cboLocationCurrent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocationCurrent.SelectedIndexChanged
        If Me.radWarehouseCurrent.Checked Then
            ShowStock(Combo.GetSelectedItemValue(Me.cboLocationCurrent), 0)
        Else
            ShowStock(0, Combo.GetSelectedItemValue(Me.cboLocationCurrent))
        End If
    End Sub

    Private Sub txtQuantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.GotFocus
        CurrentQty = Me.txtQuantity.Text.Trim
        Me.txtQuantity.Text = ""
    End Sub

    Private Sub txtQuantity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuantity.Validating
        Try
            If Entity.Sys.Helper.IsValidInteger(Me.txtQuantity.Text.Trim) Then
                CurrentQty = Me.txtQuantity.Text.Trim
            End If
        Catch ex As Exception
            'DO NOTHING
        End Try

        Me.txtQuantity.Text = CurrentQty
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMove.Click
        If SelectedStockDataRow Is Nothing Then
            ShowMessage("Please select an item to move", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Me.radWarehouseCurrent.Checked And Me.radWarehouseNew.Checked Then
            If Combo.GetSelectedItemValue(Me.cboLocationCurrent) = Combo.GetSelectedItemValue(Me.cboLocationNew) Then
                ShowMessage("You are attempting to move stock to the same place", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If
        If Me.radVanCurrent.Checked And Me.radVanNew.Checked Then
            If Combo.GetSelectedItemValue(Me.cboLocationCurrent) = Combo.GetSelectedItemValue(Me.cboLocationNew) Then
                ShowMessage("You are attempting to move stock to the same place", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        'lets check to see if we are moving multiple or individual part
        Dim mulitple As Boolean = False
        Dim selectedCount As Integer = 0
        For Each dr As DataRow In StockDataView.Table.Rows
            If dr("Select") = True Then
                selectedCount += 1
                If selectedCount > 1 Then
                    mulitple = True
                    Exit For
                End If
            End If
        Next

        If Not mulitple And CurrentQty > SelectedStockDataRow.Item("Amount") Then
            If ShowMessage("You are attempting to move more than there is available" & vbCrLf & "This will result in negative stock" & vbCrLf & "Are you sure you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim LocationID As Integer = 0
        For Each row As DataRow In DB.Location.Locations_GetAll.Table.Rows
            If Me.radWarehouseNew.Checked Then
                If Entity.Sys.Helper.MakeIntegerValid(row.Item("WarehouseID")) = Combo.GetSelectedItemValue(Me.cboLocationNew) Then
                    LocationID = row.Item("LocationID")
                    Exit For
                End If
            Else
                If Entity.Sys.Helper.MakeIntegerValid(row.Item("VanID")) = Combo.GetSelectedItemValue(Me.cboLocationNew) Then
                    LocationID = row.Item("LocationID")
                    Exit For
                End If
            End If
        Next

        If LocationID = 0 Then
            ShowMessage("Location being moved to could not be determined", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If mulitple Then
            If ShowMessage("You are about to mulitple parts/products from '" &
                           Combo.GetSelectedItemDescription(Me.cboLocationCurrent) &
                           "' to '" & Combo.GetSelectedItemDescription(Me.cboLocationNew) &
                           "'. Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                          DialogResult.No Then
                Exit Sub
            End If

            For Each dr As DataRow In StockDataView.Table.Rows
                If dr("Select") = True And dr.Item("Amount") > 0 Then
                    MovePart(dr, dr.Item("Amount"), LocationID)
                End If
            Next
        Else
            If ShowMessage("You are about to move " & CurrentQty & " '" &
                           SelectedStockDataRow.Item("Description") & "' from '" &
                           Combo.GetSelectedItemDescription(Me.cboLocationCurrent) & "' to '" &
                           Combo.GetSelectedItemDescription(Me.cboLocationNew) &
                           "'. Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
                          DialogResult.No Then
                Exit Sub
            End If

            MovePart(SelectedStockDataRow, CurrentQty, LocationID)
        End If

        If Me.radWarehouseCurrent.Checked Then
            ShowStock(Combo.GetSelectedItemValue(Me.cboLocationCurrent), 0)
        Else
            ShowStock(0, Combo.GetSelectedItemValue(Me.cboLocationCurrent))
        End If

        Dim whereClause As String = ""

        If Not Me.txtFilter.Text.Trim.Length = 0 Then
            whereClause += "(Description LIKE '%" & Me.txtFilter.Text.Trim & "%' "
            whereClause += "OR Number LIKE '%" & Me.txtFilter.Text.Trim & "%' "
            whereClause += "OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%')"
        End If

        StockDataView.RowFilter = whereClause

    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        If StockDataView Is Nothing Then
            Exit Sub
        End If
        If StockDataView.Table Is Nothing Then
            Exit Sub
        End If

        Dim whereClause As String = ""

        If Not Me.txtFilter.Text.Trim.Length = 0 Then
            whereClause += "(Description LIKE '%" & Me.txtFilter.Text.Trim & "%' "
            whereClause += "OR Number LIKE '%" & Me.txtFilter.Text.Trim & "%' "
            whereClause += "OR Reference LIKE '%" & Me.txtFilter.Text.Trim & "%')"
        End If

        StockDataView.RowFilter = whereClause
    End Sub

#End Region

#Region "Functions"

    Private Sub ShowStock(ByVal WarehouseID As Integer, ByVal VanID As Integer)
        Dim dt As New DataTable
        dt.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString

        dt.Columns.Add(New DataColumn("Select", GetType(Boolean)))
        dt.Columns.Add(New DataColumn("Type"))
        dt.Columns.Add(New DataColumn("ID"))
        dt.Columns.Add(New DataColumn("LocationID"))
        dt.Columns.Add(New DataColumn("Description"))
        dt.Columns.Add(New DataColumn("Number"))
        dt.Columns.Add(New DataColumn("Reference"))
        dt.Columns.Add(New DataColumn("Amount"))

        Dim r As DataRow

        If Not WarehouseID = 0 Then
            For Each row As DataRow In DB.PartTransaction.GetByWarehouse(WarehouseID, True).Table.Rows
                r = dt.NewRow
                r("Select") = False
                r("Type") = "PART"
                r("ID") = row.Item("PartID")
                r("LocationID") = row.Item("LocationID")
                r("Description") = row.Item("PartName")
                r("Number") = row.Item("PartNumber")
                r("Reference") = row.Item("Reference")
                r("Amount") = row.Item("Amount")
                dt.Rows.Add(r)
            Next
            For Each row As DataRow In DB.ProductTransaction.GetByWarehouse(WarehouseID).Table.Rows
                r = dt.NewRow
                r("Select") = False
                r("Type") = "PRODUCT"
                r("ID") = row.Item("ProductID")
                r("LocationID") = row.Item("LocationID")
                r("Description") = row.Item("typemakemodel")
                r("Number") = row.Item("ProductNumber")
                r("Reference") = ""
                r("Amount") = row.Item("Amount")
                dt.Rows.Add(r)
            Next
        Else
            For Each row As DataRow In DB.PartTransaction.GetByVan2(VanID, , True).Rows
                r = dt.NewRow
                r("Select") = False
                r("Type") = "PART"
                r("ID") = row.Item("PartID")
                r("LocationID") = row.Item("LocationID")
                r("Description") = row.Item("PartName")
                r("Number") = row.Item("PartNumber")
                r("Reference") = row.Item("Reference")
                r("Amount") = row.Item("Amount")
                dt.Rows.Add(r)
            Next
            For Each row As DataRow In DB.ProductTransaction.GetByVan(VanID).Table.Rows
                r = dt.NewRow
                r("Select") = False
                r("Type") = "PRODUCT"
                r("ID") = row.Item("ProductID")
                r("LocationID") = row.Item("LocationID")
                r("Description") = row.Item("typemakemodel")
                r("Number") = row.Item("ProductNumber")
                r("Reference") = ""
                r("Amount") = row.Item("Amount")
                dt.Rows.Add(r)
            Next
        End If

        StockDataView = New DataView(dt)

        CurrentQty = 1

        Me.txtQuantity.Text = CurrentQty
        Label2.Visible = True
        txtQuantity.Visible = True
        Label4.Visible = False
    End Sub

    Private Sub dgItems_Click(sender As Object, e As EventArgs) Handles dgItems.Click
        Label2.Visible = True
        txtQuantity.Visible = True
        Label4.Visible = False

        If SelectedStockDataRow Is Nothing Then
            Exit Sub
        End If

        Dim selected As Boolean = Not CBool(Me.dgItems(Me.dgItems.CurrentRowIndex, 0))
        Me.dgItems(Me.dgItems.CurrentRowIndex, 0) = selected

        Dim selectedCount As Integer = 0
        For Each dr As DataRow In StockDataView.Table.Rows
            If dr("Select") = True Then
                selectedCount += 1
                If selectedCount > 1 Then
                    Label2.Visible = False
                    txtQuantity.Visible = False
                    Label4.Visible = True
                    Exit For
                End If
            End If
        Next

    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For Each dr As DataRow In StockDataView.Table.Select(StockDataView.RowFilter)
            dr("Select") = True
        Next
        Label2.Visible = False
        txtQuantity.Visible = False
        Label4.Visible = True
    End Sub

    Private Sub btnDeselectAll_Click(sender As Object, e As EventArgs) Handles btnDeselectAll.Click
        For Each dr As DataRow In StockDataView.Table.Rows
            dr("Select") = False
        Next

        Label2.Visible = True
        txtQuantity.Visible = True
        Label4.Visible = False
    End Sub

    Public Sub MovePart(dr As DataRow, qty As Integer, locationID As Integer)
        Dim PartID As Integer = 0
        Dim ProductID As Integer = 0

        If dr.Item("Type") = "PART" Then
            Dim oPartTransactionOut As New Entity.PartTransactions.PartTransaction
            oPartTransactionOut.IgnoreExceptionsOnSetMethods = True
            oPartTransactionOut.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockOut)
            oPartTransactionOut.SetPartID = dr.Item("ID")
            oPartTransactionOut.SetAmount = -qty
            oPartTransactionOut.SetLocationID = dr.Item("LocationID")
            oPartTransactionOut = DB.PartTransaction.Insert(oPartTransactionOut)

            Dim oPartTransactionIn As New Entity.PartTransactions.PartTransaction
            oPartTransactionIn.IgnoreExceptionsOnSetMethods = True
            oPartTransactionIn.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockIn)
            oPartTransactionIn.SetPartID = dr.Item("ID")
            oPartTransactionIn.SetAmount = qty
            oPartTransactionIn.SetLocationID = locationID
            oPartTransactionIn = DB.PartTransaction.Insert(oPartTransactionIn)

            PartID = dr.Item("ID")
        Else
            Dim oProductTransactionOut As New Entity.ProductTransactions.ProductTransaction
            oProductTransactionOut.IgnoreExceptionsOnSetMethods = True
            oProductTransactionOut.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockOut)
            oProductTransactionOut.SetProductID = dr.Item("ID")
            oProductTransactionOut.SetAmount = -qty
            oProductTransactionOut.SetLocationID = dr.Item("LocationID")
            oProductTransactionOut = DB.ProductTransaction.Insert(oProductTransactionOut)

            Dim oProductTransactionIn As New Entity.ProductTransactions.ProductTransaction
            oProductTransactionIn.IgnoreExceptionsOnSetMethods = True
            oProductTransactionIn.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockIn)
            oProductTransactionIn.SetProductID = dr.Item("ID")
            oProductTransactionIn.SetAmount = qty
            oProductTransactionIn.SetLocationID = dr
            oProductTransactionIn = DB.ProductTransaction.Insert(oProductTransactionIn)

            ProductID = dr.Item("ID")
        End If

        DB.Location.IPT_Audit_Insert(PartID, ProductID, dr.Item("LocationID"), locationID, qty)

    End Sub

#End Region

End Class