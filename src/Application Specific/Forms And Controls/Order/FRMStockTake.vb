Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Sys

Public Class FRMStockTake : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Combo.SetUpCombo(Me.cboCategory, DB.Picklists.GetAll(Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter)

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
    Friend WithEvents grpStockLevels As System.Windows.Forms.GroupBox

    Friend WithEvents grpFilterArea As System.Windows.Forms.GroupBox
    Friend WithEvents radVans As System.Windows.Forms.RadioButton
    Friend WithEvents radWarehouses As System.Windows.Forms.RadioButton
    Friend WithEvents cboFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgStock As System.Windows.Forms.DataGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblShow As System.Windows.Forms.Label
    Friend WithEvents lblArrow As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents radBothLocations As System.Windows.Forms.RadioButton
    Friend WithEvents lblBottomInfo As System.Windows.Forms.Label
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents chkLocations As System.Windows.Forms.CheckBox
    Friend WithEvents txtLocationFilter As System.Windows.Forms.TextBox
    Friend WithEvents lblLocationFilter As System.Windows.Forms.Label
    Friend WithEvents lblStockValuation As System.Windows.Forms.Label
    Friend WithEvents chkExpectedNotZero As System.Windows.Forms.CheckBox
    Friend WithEvents lblPartMpn As System.Windows.Forms.Label
    Friend WithEvents txtMPN As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents btnStockReplenishment As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgStock = New System.Windows.Forms.DataGrid()
        Me.grpStockLevels = New System.Windows.Forms.GroupBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.lblStockValuation = New System.Windows.Forms.Label()
        Me.txtLocationFilter = New System.Windows.Forms.TextBox()
        Me.lblLocationFilter = New System.Windows.Forms.Label()
        Me.grpFilterArea = New System.Windows.Forms.GroupBox()
        Me.txtMPN = New System.Windows.Forms.TextBox()
        Me.lblPartMpn = New System.Windows.Forms.Label()
        Me.chkExpectedNotZero = New System.Windows.Forms.CheckBox()
        Me.chkLocations = New System.Windows.Forms.CheckBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.radBothLocations = New System.Windows.Forms.RadioButton()
        Me.radWarehouses = New System.Windows.Forms.RadioButton()
        Me.radVans = New System.Windows.Forms.RadioButton()
        Me.lblArrow = New System.Windows.Forms.Label()
        Me.cboFilter = New System.Windows.Forms.ComboBox()
        Me.lblShow = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblBottomInfo = New System.Windows.Forms.Label()
        Me.btnStockReplenishment = New System.Windows.Forms.Button()
        CType(Me.dgStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStockLevels.SuspendLayout()
        Me.grpFilterArea.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgStock
        '
        Me.dgStock.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgStock.DataMember = ""
        Me.dgStock.HeaderForeColor = SystemColors.ControlText
        Me.dgStock.Location = New System.Drawing.Point(10, 45)
        Me.dgStock.Name = "dgStock"
        Me.dgStock.Size = New System.Drawing.Size(884, 296)
        Me.dgStock.TabIndex = 8
        '
        'grpStockLevels
        '
        Me.grpStockLevels.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStockLevels.Controls.Add(Me.txtPrice)
        Me.grpStockLevels.Controls.Add(Me.lblStockValuation)
        Me.grpStockLevels.Controls.Add(Me.txtLocationFilter)
        Me.grpStockLevels.Controls.Add(Me.lblLocationFilter)
        Me.grpStockLevels.Controls.Add(Me.dgStock)
        Me.grpStockLevels.Location = New System.Drawing.Point(8, 160)
        Me.grpStockLevels.Name = "grpStockLevels"
        Me.grpStockLevels.Size = New System.Drawing.Size(903, 349)
        Me.grpStockLevels.TabIndex = 1
        Me.grpStockLevels.TabStop = False
        Me.grpStockLevels.Text = "Current Stock Levels"
        '
        'txtPrice
        '
        Me.txtPrice.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrice.Location = New System.Drawing.Point(764, 13)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.ReadOnly = True
        Me.txtPrice.Size = New System.Drawing.Size(130, 21)
        Me.txtPrice.TabIndex = 16
        '
        'lblStockValuation
        '
        Me.lblStockValuation.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStockValuation.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockValuation.Location = New System.Drawing.Point(652, 16)
        Me.lblStockValuation.Name = "lblStockValuation"
        Me.lblStockValuation.Size = New System.Drawing.Size(118, 22)
        Me.lblStockValuation.TabIndex = 14
        Me.lblStockValuation.Text = "Stock Valuation"
        '
        'txtLocationFilter
        '
        Me.txtLocationFilter.Location = New System.Drawing.Point(100, 17)
        Me.txtLocationFilter.Name = "txtLocationFilter"
        Me.txtLocationFilter.Size = New System.Drawing.Size(214, 21)
        Me.txtLocationFilter.TabIndex = 11
        '
        'lblLocationFilter
        '
        Me.lblLocationFilter.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocationFilter.Location = New System.Drawing.Point(7, 20)
        Me.lblLocationFilter.Name = "lblLocationFilter"
        Me.lblLocationFilter.Size = New System.Drawing.Size(105, 22)
        Me.lblLocationFilter.TabIndex = 9
        Me.lblLocationFilter.Text = "Location filter"
        '
        'grpFilterArea
        '
        Me.grpFilterArea.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilterArea.Controls.Add(Me.txtMPN)
        Me.grpFilterArea.Controls.Add(Me.lblPartMpn)
        Me.grpFilterArea.Controls.Add(Me.chkExpectedNotZero)
        Me.grpFilterArea.Controls.Add(Me.chkLocations)
        Me.grpFilterArea.Controls.Add(Me.btnRun)
        Me.grpFilterArea.Controls.Add(Me.cboCategory)
        Me.grpFilterArea.Controls.Add(Me.lblCategory)
        Me.grpFilterArea.Controls.Add(Me.Panel2)
        Me.grpFilterArea.Controls.Add(Me.lblShow)
        Me.grpFilterArea.Location = New System.Drawing.Point(8, 48)
        Me.grpFilterArea.Name = "grpFilterArea"
        Me.grpFilterArea.Size = New System.Drawing.Size(903, 106)
        Me.grpFilterArea.TabIndex = 2
        Me.grpFilterArea.TabStop = False
        Me.grpFilterArea.Text = "Filters"
        '
        'txtMPN
        '
        Me.txtMPN.Location = New System.Drawing.Point(72, 79)
        Me.txtMPN.Name = "txtMPN"
        Me.txtMPN.Size = New System.Drawing.Size(244, 21)
        Me.txtMPN.TabIndex = 14
        '
        'lblPartMpn
        '
        Me.lblPartMpn.AutoSize = True
        Me.lblPartMpn.Location = New System.Drawing.Point(9, 82)
        Me.lblPartMpn.Name = "lblPartMpn"
        Me.lblPartMpn.Size = New System.Drawing.Size(58, 13)
        Me.lblPartMpn.TabIndex = 13
        Me.lblPartMpn.Text = "Part MPN"
        '
        'chkExpectedNotZero
        '
        Me.chkExpectedNotZero.AutoSize = True
        Me.chkExpectedNotZero.Location = New System.Drawing.Point(334, 77)
        Me.chkExpectedNotZero.Name = "chkExpectedNotZero"
        Me.chkExpectedNotZero.Size = New System.Drawing.Size(259, 17)
        Me.chkExpectedNotZero.TabIndex = 12
        Me.chkExpectedNotZero.Text = "Only show parts where expected is not 0"
        Me.chkExpectedNotZero.UseVisualStyleBackColor = True
        '
        'chkLocations
        '
        Me.chkLocations.AutoSize = True
        Me.chkLocations.Checked = True
        Me.chkLocations.CheckState = CheckState.Checked
        Me.chkLocations.Location = New System.Drawing.Point(334, 57)
        Me.chkLocations.Name = "chkLocations"
        Me.chkLocations.Size = New System.Drawing.Size(225, 17)
        Me.chkLocations.TabIndex = 11
        Me.chkLocations.Text = "Only show parts with a location set"
        Me.chkLocations.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(840, 78)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(56, 25)
        Me.btnRun.TabIndex = 10
        Me.btnRun.Text = "Run"
        '
        'cboCategory
        '
        Me.cboCategory.Location = New System.Drawing.Point(72, 53)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(244, 21)
        Me.cboCategory.TabIndex = 9
        '
        'lblCategory
        '
        Me.lblCategory.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(9, 51)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(64, 22)
        Me.lblCategory.TabIndex = 8
        Me.lblCategory.Text = "Category"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.radBothLocations)
        Me.Panel2.Controls.Add(Me.radWarehouses)
        Me.Panel2.Controls.Add(Me.radVans)
        Me.Panel2.Controls.Add(Me.lblArrow)
        Me.Panel2.Controls.Add(Me.cboFilter)
        Me.Panel2.Location = New System.Drawing.Point(62, 14)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(835, 32)
        Me.Panel2.TabIndex = 6
        '
        'radBothLocations
        '
        Me.radBothLocations.Checked = True
        Me.radBothLocations.Location = New System.Drawing.Point(216, 6)
        Me.radBothLocations.Name = "radBothLocations"
        Me.radBothLocations.Size = New System.Drawing.Size(56, 26)
        Me.radBothLocations.TabIndex = 6
        Me.radBothLocations.TabStop = True
        Me.radBothLocations.Text = "Both"
        '
        'radWarehouses
        '
        Me.radWarehouses.Location = New System.Drawing.Point(8, 6)
        Me.radWarehouses.Name = "radWarehouses"
        Me.radWarehouses.Size = New System.Drawing.Size(96, 26)
        Me.radWarehouses.TabIndex = 4
        Me.radWarehouses.Text = "Warehouses"
        '
        'radVans
        '
        Me.radVans.Location = New System.Drawing.Point(110, 6)
        Me.radVans.Name = "radVans"
        Me.radVans.Size = New System.Drawing.Size(97, 26)
        Me.radVans.TabIndex = 5
        Me.radVans.Text = "Stock Profile"
        '
        'lblArrow
        '
        Me.lblArrow.Location = New System.Drawing.Point(267, 10)
        Me.lblArrow.Name = "lblArrow"
        Me.lblArrow.Size = New System.Drawing.Size(24, 23)
        Me.lblArrow.TabIndex = 7
        Me.lblArrow.Text = ">"
        '
        'cboFilter
        '
        Me.cboFilter.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFilter.Location = New System.Drawing.Point(293, 8)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(534, 21)
        Me.cboFilter.TabIndex = 7
        '
        'lblShow
        '
        Me.lblShow.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblShow.Location = New System.Drawing.Point(8, 24)
        Me.lblShow.Name = "lblShow"
        Me.lblShow.Size = New System.Drawing.Size(48, 22)
        Me.lblShow.TabIndex = 7
        Me.lblShow.Text = "Show"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(855, 520)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 25)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 520)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 25)
        Me.btnExport.TabIndex = 9
        Me.btnExport.Text = "Export"
        '
        'lblBottomInfo
        '
        Me.lblBottomInfo.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBottomInfo.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblBottomInfo.Font = New System.Drawing.Font("Verdana", 10.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblBottomInfo.Location = New System.Drawing.Point(180, 520)
        Me.lblBottomInfo.Name = "lblBottomInfo"
        Me.lblBottomInfo.Size = New System.Drawing.Size(675, 23)
        Me.lblBottomInfo.TabIndex = 5
        Me.lblBottomInfo.Text = "Use last columns to enter ACTUAL STOCK AMOUNT AND REASON then click save"
        Me.lblBottomInfo.TextAlign = ContentAlignment.MiddleCenter
        '
        'btnStockReplenishment
        '
        Me.btnStockReplenishment.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStockReplenishment.Location = New System.Drawing.Point(72, 520)
        Me.btnStockReplenishment.Name = "btnStockReplenishment"
        Me.btnStockReplenishment.Size = New System.Drawing.Size(184, 25)
        Me.btnStockReplenishment.TabIndex = 10
        Me.btnStockReplenishment.Text = "Manage Stock Replenishment"
        '
        'FRMStockTake
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(919, 550)
        Me.Controls.Add(Me.btnStockReplenishment)
        Me.Controls.Add(Me.lblBottomInfo)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpFilterArea)
        Me.Controls.Add(Me.grpStockLevels)
        Me.MinimumSize = New System.Drawing.Size(860, 584)
        Me.Name = "FRMStockTake"
        Me.Text = "Stock Take"
        Me.WindowState = FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpStockLevels, 0)
        Me.Controls.SetChildIndex(Me.grpFilterArea, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.lblBottomInfo, 0)
        Me.Controls.SetChildIndex(Me.btnStockReplenishment, 0)
        CType(Me.dgStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStockLevels.ResumeLayout(False)
        Me.grpStockLevels.PerformLayout()
        Me.grpFilterArea.ResumeLayout(False)
        Me.grpFilterArea.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        If IsRFT Then
            DvStockTakeReason = DB.Location.StockTakeReason_Get()
            Dim nr As DataRow = DvStockTakeReason.Table.NewRow()
            nr("StockTakeReasonID") = 0
            nr("StockTakeReasonType") = "-- Select reason --"
            DvStockTakeReason.Table.Rows.InsertAt(nr, 0)
        End If

        StockDgSetup()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        'DO NOTHING
    End Sub

#End Region

#Region "Properties"

    Private _StockDataView As DataView = Nothing

    Public Property StockDataView() As DataView
        Get
            Return _StockDataView
        End Get
        Set(ByVal Value As DataView)
            _StockDataView = Value
            _StockDataView.AllowNew = False
            _StockDataView.AllowEdit = True
            _StockDataView.AllowDelete = False
            _StockDataView.Table.TableName = Enums.TableNames.tblStock.ToString
            Me.dgStock.DataSource = StockDataView
        End Set
    End Property

    Private _dvStockTakeReason As DataView

    Private Property DvStockTakeReason() As DataView
        Get
            Return _dvStockTakeReason
        End Get
        Set(ByVal value As DataView)
            _dvStockTakeReason = value
        End Set
    End Property

#End Region

#Region "Setup"

    Public Sub StockDgSetup()
        Dim tbStyle As DataGridTableStyle = Me.dgStock.TableStyles(0)

        Dim Category As New DataGridLabelColumn
        Category.Format = ""
        Category.FormatInfo = Nothing
        Category.HeaderText = "Category"
        Category.MappingName = "Category"
        Category.ReadOnly = True
        Category.Width = 200
        Category.NullText = ""
        tbStyle.GridColumnStyles.Add(Category)

        Dim partName As New DataGridLabelColumn
        partName.Format = ""
        partName.FormatInfo = Nothing
        partName.HeaderText = "Name"
        partName.MappingName = "Name"
        partName.ReadOnly = True
        partName.Width = 200
        partName.NullText = ""
        tbStyle.GridColumnStyles.Add(partName)

        Dim partNumber As New DataGridLabelColumn
        partNumber.Format = ""
        partNumber.FormatInfo = Nothing
        partNumber.HeaderText = "Number"
        partNumber.MappingName = "Number"
        partNumber.ReadOnly = True
        partNumber.Width = 100
        partNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(partNumber)

        Dim PartReference As New DataGridLabelColumn
        PartReference.Format = ""
        PartReference.FormatInfo = Nothing
        PartReference.HeaderText = "Reference"
        PartReference.MappingName = "Reference"
        PartReference.ReadOnly = True
        PartReference.Width = 100
        PartReference.NullText = ""
        tbStyle.GridColumnStyles.Add(PartReference)

        Dim Cost As New DataGridLabelColumn
        Cost.Format = "c"
        Cost.FormatInfo = Nothing
        Cost.HeaderText = "Unit Cost"
        Cost.MappingName = "Cost"
        Cost.ReadOnly = True
        Cost.Width = 80
        Cost.NullText = ""
        tbStyle.GridColumnStyles.Add(Cost)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 100
        Location.NullText = ""
        tbStyle.GridColumnStyles.Add(Location)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Expected"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 80
        Amount.NullText = ""
        tbStyle.GridColumnStyles.Add(Amount)

        Dim actualAmount As New DataGridOrderTextBoxColumn
        actualAmount.Format = ""
        actualAmount.FormatInfo = Nothing
        actualAmount.HeaderText = "Actual"
        actualAmount.MappingName = "ActualAmount"
        actualAmount.ReadOnly = False
        actualAmount.Width = 80
        actualAmount.NullText = ""
        tbStyle.GridColumnStyles.Add(actualAmount)

        If IsRFT Then
            Dim reason As New DataGridComboBoxColumn
            reason.HeaderText = "Reason"
            reason.MappingName = "Reason"
            reason.ReadOnly = False
            reason.Width = 250
            reason.ComboBox.DataSource = DvStockTakeReason
            reason.ComboBox.DisplayMember = "StockTakeReasonType"
            reason.ComboBox.ValueMember = "StockTakeReasonID"
            tbStyle.GridColumnStyles.Add(reason)
        End If

        tbStyle.ReadOnly = False
        Me.dgStock.ReadOnly = False
        tbStyle.MappingName = Enums.TableNames.tblStock.ToString
        Me.dgStock.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMStockTake_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub radWarehouses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radWarehouses.CheckedChanged
        Combo.SetUpCombo(Me.cboFilter, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboFilter, 0)
        Me.cboFilter.Enabled = True
    End Sub

    Private Sub radVans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radVans.CheckedChanged
        Combo.SetUpCombo(Me.cboFilter, DB.Van.Van_GetAll(False).Table, "VanID", "Registration", Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboFilter, 0)
        Me.cboFilter.Enabled = True
    End Sub

    Private Sub radBothLocations_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radBothLocations.CheckedChanged
        Combo.SetUpCombo(Me.cboFilter, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboFilter, 0)
        Me.cboFilter.Enabled = False
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        Populate()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnStockReplenishment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockReplenishment.Click
        ShowForm(GetType(FRMStockReplenishment), True, New Object() {False})

        Populate()
    End Sub

    Private Sub txtLocationFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocationFilter.TextChanged
        Filter()
    End Sub

    Private Sub txtMPN_TextChanged(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMPN.KeyDown
        If e.KeyCode = Keys.Enter Then
            Populate()
        End If

    End Sub

#End Region

#Region "Functions"

    Private Sub Filter()
        If StockDataView Is Nothing Then
            Exit Sub
        End If

        Dim whereClause As String = "1 = 1 "

        If Not Me.txtLocationFilter.Text.Trim.Length = 0 Then
            whereClause += " AND Location LIKE '%" & Helper.RemoveSpecialCharacters(Me.txtLocationFilter.Text.Trim) & "%' "
        End If
        whereClause = whereClause.Replace("*", "[*]")

        StockDataView.RowFilter = whereClause
        CalcValuation()
    End Sub

    Private Sub Populate()
        Dim WarehouseID As Integer = 0
        Dim VanID As Integer = 0
        Dim ShowOnlyWarehouses As Boolean = 0
        Dim ShowOnlyVans As Boolean = 0

        If Me.radWarehouses.Checked Then
            WarehouseID = Combo.GetSelectedItemValue(Me.cboFilter)
            ShowOnlyWarehouses = 1
        End If

        If Me.radVans.Checked Then
            VanID = Combo.GetSelectedItemValue(Me.cboFilter)
            ShowOnlyVans = 1
        End If

        Cursor.Current = Cursors.WaitCursor
        If Len(Me.txtMPN.Text) = 0 Then
            StockDataView = DB.Location.StockTake_GetAll(Me.chkLocations.Checked, Combo.GetSelectedItemValue(Me.cboCategory), WarehouseID, VanID, Me.chkExpectedNotZero.Checked, ShowOnlyWarehouses, ShowOnlyVans)
        Else
            StockDataView = DB.Location.StockTake_GetAll_WithName(Me.chkLocations.Checked, Combo.GetSelectedItemValue(Me.cboCategory), WarehouseID, VanID, Me.chkExpectedNotZero.Checked, ShowOnlyWarehouses, ShowOnlyVans, Me.txtMPN.Text)
        End If

        CalcValuation()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Save()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim errString As String = ""
            Dim valid As Boolean = True

            Dim drChangedAmounts As DataRow() = StockDataView.Table.AsEnumerable.Where(Function(x) Not Helper.IsStringEmpty(x("actualAmount"))).ToArray()

            For Each row As DataRow In drChangedAmounts

                If Not CStr(row.Item("actualAmount")).Trim.Length = 0 Then
                    If Not Helper.IsValidInteger(row.Item("actualAmount")) Then
                        valid = False
                        If CInt(row.Item("PartID")) > 0 Then
                            errString += "Amount for part '" & row.Item("Number") & "' in '" & row.Item("Location") & "' is invalid" & vbCrLf
                        Else
                            errString += "Amount for product '" & row.Item("Number") & "' in '" & row.Item("Location") & "' is invalid" & vbCrLf
                        End If
                    End If
                    If IsRFT AndAlso Not Helper.MakeIntegerValid(row.Item("Reason")) > 0 AndAlso Helper.MakeIntegerValid(row.Item("actualAmount")) <> Helper.MakeIntegerValid(row.Item("Amount")) Then
                        valid = False
                        If CInt(row.Item("PartID")) > 0 Then
                            errString += "Reason for part '" & row.Item("Number") & "' in '" & row.Item("Location") & "' is missing" & vbCrLf
                        Else
                            errString += "Reason for product '" & row.Item("Number") & "' in '" & row.Item("Location") & "' is missing" & vbCrLf
                        End If
                    End If
                End If
            Next

            If Not valid Then
                Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
                msg = String.Format(msg, vbNewLine, errString)
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                Exit Sub
            End If

            If ShowMessage("Perform stock adjustments now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            For Each row As DataRow In drChangedAmounts
                If Helper.IsValidInteger(row.Item("actualAmount")) Then
                    If Not CInt(row.Item("PartID")) = 0 Then
                        DB.PartTransaction.PartTransaction_Consolidate_All(row.Item("LocationID"), row.Item("PartID"))

                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction.SetLocationID = row.Item("LocationID")
                        oPartTransaction.SetAmount = row("actualAmount") - row.Item("Amount")
                        oPartTransaction.SetPartID = row.Item("PartID")
                        oPartTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockAdjustment)

                        DB.PartTransaction.Insert(oPartTransaction)
                    Else
                        DB.ProductTransaction.ProductTransaction_Consolidate_All(row.Item("LocationID"), row.Item("ProductID"))

                        Dim oProductTransaction As New Entity.ProductTransactions.ProductTransaction
                        oProductTransaction.SetLocationID = row.Item("LocationID")
                        oProductTransaction.SetAmount = row("actualAmount") - row("Amount")
                        oProductTransaction.SetProductID = row.Item("ProductID")
                        oProductTransaction.SetTransactionTypeID = CInt(Enums.Transaction.StockAdjustment)
                        DB.ProductTransaction.Insert(oProductTransaction)
                    End If

                    If IsRFT Then
                        Dim oStockTakeAudit As New Entity.StockTakeAudit
                        oStockTakeAudit.SetPartID = row.Item("PartID")
                        oStockTakeAudit.SetOriginalAmount = row.Item("Amount")
                        oStockTakeAudit.SetNewAmount = row.Item("actualAmount")
                        oStockTakeAudit.SetReasonChange = row.Item("Reason")
                        oStockTakeAudit.SetLocationID = row.Item("LocationID")

                        DB.StockTakeAudit.Insert(oStockTakeAudit)
                    End If
                End If
            Next

            Populate()
        Catch ex As Exception
            ShowMessage("Could not perform stock adjustments : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub Export()
        If StockDataView Is Nothing Then
            Exit Sub
        End If

        Dim exportData As New DataTable
        exportData.Columns.Add("Category")
        exportData.Columns.Add("Location")
        exportData.Columns.Add("Name")
        exportData.Columns.Add("Number")
        exportData.Columns.Add("Reference")
        exportData.Columns.Add("Cost")
        exportData.Columns.Add("MinQty")
        exportData.Columns.Add("MaxQty")
        exportData.Columns.Add("Amount Expected")
        exportData.Columns.Add("Actual Amount")

        For Each row As DataRow In StockDataView.Table.Rows
            Dim newRw As DataRow
            newRw = exportData.NewRow

            newRw("Category") = row.Item("Category")
            newRw("Location") = row.Item("Location")
            newRw("Name") = row.Item("Name")
            newRw("Number") = row.Item("Number")
            newRw("Reference") = row.Item("Reference")
            newRw("Cost") = row.Item("Cost")
            newRw("Amount Expected") = row.Item("Amount")
            newRw("Actual Amount") = row.Item("ActualAmount")
            newRw("MinQty") = row.Item("MinQty")
            newRw("MaxQty") = row.Item("RecQty")

            exportData.Rows.Add(newRw)
        Next

        Dim exporter As New Entity.Sys.Exporting(exportData, "Stock Take")
        exporter = Nothing
    End Sub

    Public Sub CalcValuation()
        Dim valuation As Double = 0.00
        For Each row As DataRowView In StockDataView
            Dim stockAmount As Double = Helper.MakeDoubleValid(row.Item("Amount"))
            If stockAmount > 0 Then
                valuation += (Helper.MakeDoubleValid(row.Item("Cost")) * stockAmount)
            End If
        Next

        Me.txtPrice.Text = Math.Round(valuation, 2, MidpointRounding.AwayFromZero).ToString("C")
    End Sub

#End Region

End Class