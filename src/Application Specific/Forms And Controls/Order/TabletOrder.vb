Imports FSM.Business.Orders
Imports FSM.Entity.Customers
Imports FSM.Entity.Sys

Public Class TabletOrder : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboCostCentre, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboCostCentre, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select
        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal trans As SqlClient.SqlTransaction)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal EngineerIDin As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        EngineerID = EngineerIDin
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

    Friend WithEvents btnFindPart As System.Windows.Forms.Button
    Friend WithEvents txtPartSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents nudQty As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgParts As System.Windows.Forms.DataGridView
    Friend WithEvents lblTopLabel As System.Windows.Forms.Label
    Friend WithEvents btnAddPart As System.Windows.Forms.Button
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents pnlFilters As System.Windows.Forms.Panel
    Friend WithEvents dgvSearch As DataGridView
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents lblCostCentre As Label
    Friend WithEvents cboCostCentre As ComboBox
    Friend WithEvents txtNewOrderNumber As TextBox
    Friend WithEvents lblDate As Label
    Friend WithEvents dtpDatePlaced As DateTimePicker

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnFindPart = New System.Windows.Forms.Button()
        Me.txtPartSearch = New System.Windows.Forms.TextBox()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.nudQty = New System.Windows.Forms.NumericUpDown()
        Me.dgParts = New System.Windows.Forms.DataGridView()
        Me.lblTopLabel = New System.Windows.Forms.Label()
        Me.btnAddPart = New System.Windows.Forms.Button()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.rbYes = New System.Windows.Forms.RadioButton()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.dtpDatePlaced = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.cboCostCentre = New System.Windows.Forms.ComboBox()
        Me.lblCostCentre = New System.Windows.Forms.Label()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.txtNewOrderNumber = New System.Windows.Forms.TextBox()
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnFindPart
        '
        Me.btnFindPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindPart.Location = New System.Drawing.Point(856, 105)
        Me.btnFindPart.Name = "btnFindPart"
        Me.btnFindPart.Size = New System.Drawing.Size(145, 34)
        Me.btnFindPart.TabIndex = 13
        Me.btnFindPart.Text = "Find"
        Me.btnFindPart.UseVisualStyleBackColor = True
        '
        'txtPartSearch
        '
        Me.txtPartSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartSearch.Location = New System.Drawing.Point(321, 62)
        Me.txtPartSearch.Name = "txtPartSearch"
        Me.txtPartSearch.Size = New System.Drawing.Size(680, 29)
        Me.txtPartSearch.TabIndex = 2
        '
        'lblQty
        '
        Me.lblQty.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblQty.Location = New System.Drawing.Point(4, 67)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(120, 21)
        Me.lblQty.TabIndex = 19
        Me.lblQty.Text = "Qty"
        '
        'btnCreate
        '
        Me.btnCreate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.Location = New System.Drawing.Point(857, 552)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(146, 40)
        Me.btnCreate.TabIndex = 130
        Me.btnCreate.Text = "Create Order"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(249, 67)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(67, 21)
        Me.lblSearch.TabIndex = 20
        Me.lblSearch.Text = "Search"
        '
        'lblSupplier
        '
        Me.lblSupplier.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSupplier.Location = New System.Drawing.Point(4, 22)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(120, 21)
        Me.lblSupplier.TabIndex = 18
        Me.lblSupplier.Text = "Supplier"
        '
        'nudQty
        '
        Me.nudQty.BackColor = System.Drawing.Color.White
        Me.nudQty.Font = New System.Drawing.Font("Verdana", 16.0!)
        Me.nudQty.Location = New System.Drawing.Point(130, 61)
        Me.nudQty.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQty.Name = "nudQty"
        Me.nudQty.Size = New System.Drawing.Size(112, 33)
        Me.nudQty.TabIndex = 9
        Me.nudQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dgParts
        '
        Me.dgParts.AllowUserToAddRows = False
        Me.dgParts.AllowUserToDeleteRows = False
        Me.dgParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgParts.Location = New System.Drawing.Point(13, 413)
        Me.dgParts.Name = "dgParts"
        Me.dgParts.Size = New System.Drawing.Size(990, 133)
        Me.dgParts.TabIndex = 133
        '
        'lblTopLabel
        '
        Me.lblTopLabel.AutoSize = True
        Me.lblTopLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTopLabel.Location = New System.Drawing.Point(17, 50)
        Me.lblTopLabel.Name = "lblTopLabel"
        Me.lblTopLabel.Size = New System.Drawing.Size(539, 24)
        Me.lblTopLabel.TabIndex = 132
        Me.lblTopLabel.Text = "Are these parts to be fitted on this visit?  (NO creates a new visit)"
        '
        'btnAddPart
        '
        Me.btnAddPart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddPart.Enabled = False
        Me.btnAddPart.Location = New System.Drawing.Point(857, 372)
        Me.btnAddPart.Name = "btnAddPart"
        Me.btnAddPart.Size = New System.Drawing.Size(146, 34)
        Me.btnAddPart.TabIndex = 124
        Me.btnAddPart.Text = "Add"
        Me.btnAddPart.UseVisualStyleBackColor = True
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNo.Location = New System.Drawing.Point(949, 49)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(53, 28)
        Me.rbNo.TabIndex = 127
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbYes.Location = New System.Drawing.Point(836, 50)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(60, 28)
        Me.rbYes.TabIndex = 126
        Me.rbYes.TabStop = True
        Me.rbYes.Text = "Yes"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(12, 552)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(146, 40)
        Me.btnBack.TabIndex = 125
        Me.btnBack.Text = "Close"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'pnlFilters
        '
        Me.pnlFilters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFilters.BackColor = System.Drawing.SystemColors.Info
        Me.pnlFilters.Controls.Add(Me.dtpDatePlaced)
        Me.pnlFilters.Controls.Add(Me.lblDate)
        Me.pnlFilters.Controls.Add(Me.cboCostCentre)
        Me.pnlFilters.Controls.Add(Me.lblCostCentre)
        Me.pnlFilters.Controls.Add(Me.txtSupplier)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Controls.Add(Me.lblSupplier)
        Me.pnlFilters.Controls.Add(Me.btnFindPart)
        Me.pnlFilters.Controls.Add(Me.txtPartSearch)
        Me.pnlFilters.Controls.Add(Me.nudQty)
        Me.pnlFilters.Controls.Add(Me.lblQty)
        Me.pnlFilters.Location = New System.Drawing.Point(1, 91)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(1013, 145)
        Me.pnlFilters.TabIndex = 123
        '
        'dtpDatePlaced
        '
        Me.dtpDatePlaced.Location = New System.Drawing.Point(130, 105)
        Me.dtpDatePlaced.Name = "dtpDatePlaced"
        Me.dtpDatePlaced.Size = New System.Drawing.Size(702, 21)
        Me.dtpDatePlaced.TabIndex = 25
        '
        'lblDate
        '
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDate.Location = New System.Drawing.Point(4, 110)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(120, 21)
        Me.lblDate.TabIndex = 24
        Me.lblDate.Text = "Date Placed"
        '
        'cboCostCentre
        '
        Me.cboCostCentre.FormattingEnabled = True
        Me.cboCostCentre.Location = New System.Drawing.Point(764, 29)
        Me.cboCostCentre.Name = "cboCostCentre"
        Me.cboCostCentre.Size = New System.Drawing.Size(237, 21)
        Me.cboCostCentre.TabIndex = 23
        '
        'lblCostCentre
        '
        Me.lblCostCentre.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.lblCostCentre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCostCentre.Location = New System.Drawing.Point(761, 12)
        Me.lblCostCentre.Name = "lblCostCentre"
        Me.lblCostCentre.Size = New System.Drawing.Size(89, 21)
        Me.lblCostCentre.TabIndex = 22
        Me.lblCostCentre.Text = "Cost Centre:"
        '
        'txtSupplier
        '
        Me.txtSupplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplier.Location = New System.Drawing.Point(130, 21)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(625, 29)
        Me.txtSupplier.TabIndex = 21
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.AllowUserToResizeRows = False
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSearch.Location = New System.Drawing.Point(12, 242)
        Me.dgvSearch.MultiSelect = False
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ReadOnly = True
        Me.dgvSearch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearch.ShowCellErrors = False
        Me.dgvSearch.ShowCellToolTips = False
        Me.dgvSearch.ShowEditingIcon = False
        Me.dgvSearch.ShowRowErrors = False
        Me.dgvSearch.Size = New System.Drawing.Size(839, 165)
        Me.dgvSearch.TabIndex = 134
        '
        'txtNewOrderNumber
        '
        Me.txtNewOrderNumber.BackColor = System.Drawing.Color.White
        Me.txtNewOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNewOrderNumber.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewOrderNumber.ForeColor = System.Drawing.Color.Red
        Me.txtNewOrderNumber.Location = New System.Drawing.Point(243, 563)
        Me.txtNewOrderNumber.Name = "txtNewOrderNumber"
        Me.txtNewOrderNumber.ReadOnly = True
        Me.txtNewOrderNumber.Size = New System.Drawing.Size(543, 20)
        Me.txtNewOrderNumber.TabIndex = 135
        Me.txtNewOrderNumber.Text = "Your order number will be displayed here once created."
        Me.txtNewOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabletOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1014, 608)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtNewOrderNumber)
        Me.Controls.Add(Me.dgvSearch)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.dgParts)
        Me.Controls.Add(Me.lblTopLabel)
        Me.Controls.Add(Me.btnAddPart)
        Me.Controls.Add(Me.rbNo)
        Me.Controls.Add(Me.rbYes)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.pnlFilters)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1030, 647)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1030, 647)
        Me.Name = "TabletOrder"
        Me.Text = "Part Search"
        Me.Controls.SetChildIndex(Me.pnlFilters, 0)
        Me.Controls.SetChildIndex(Me.btnBack, 0)
        Me.Controls.SetChildIndex(Me.rbYes, 0)
        Me.Controls.SetChildIndex(Me.rbNo, 0)
        Me.Controls.SetChildIndex(Me.btnAddPart, 0)
        Me.Controls.SetChildIndex(Me.lblTopLabel, 0)
        Me.Controls.SetChildIndex(Me.dgParts, 0)
        Me.Controls.SetChildIndex(Me.btnCreate, 0)
        Me.Controls.SetChildIndex(Me.dgvSearch, 0)
        Me.Controls.SetChildIndex(Me.txtNewOrderNumber, 0)
        CType(Me.nudQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region "Part Datagrid"

    Private Sub SetupDataTable()
        PartsList.Columns.Add("PartSupplierID")
        PartsList.Columns.Add("SPN")
        PartsList.Columns.Add("Description")
        PartsList.Columns.Add("Qty")
        PartsList.Columns.Add("Supplier")
        PartsList.Columns.Add("PartID")
        PartsList.Columns.Add("Price")
        PartsList.Columns.Add("IsSpecialPart")
    End Sub

    Private Sub SetupPartsDataGrid()
        Try
            'dgParts.TableStyles.Add(New DataGridTableStyle)
            'Globals.FormatDatagrid(dgParts)

            'Dim tStyle As DataGridTableStyle = dgParts.TableStyles(0)

            Dim PartSupplierID As New DataGridViewTextBoxColumn
            PartSupplierID.HeaderText = "PartSupplierID"
            PartSupplierID.DataPropertyName = "PartSupplierID"
            PartSupplierID.Visible = False
            'PartSupplierID. = ""
            PartSupplierID.Width = 10
            dgParts.Columns.Add(PartSupplierID)

            'tStyle.GridColumnStyles.Add(PartSupplierID)

            Dim PartID As New DataGridViewTextBoxColumn
            PartID.HeaderText = "PartID"
            PartID.DataPropertyName = "PartID"
            PartID.Visible = False
            'PartSupplierID. = ""
            PartID.Width = 10
            dgParts.Columns.Add(PartID)

            Dim SPN As New DataGridViewTextBoxColumn
            SPN.HeaderText = "SPN"
            SPN.DataPropertyName = "SPN"
            'PartSupplierID. = ""
            SPN.Width = 200
            dgParts.Columns.Add(SPN)
            SPN.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet

            Dim Description As New DataGridViewTextBoxColumn
            Description.HeaderText = "Description"
            Description.DataPropertyName = "Description"
            dgParts.Columns.Add(Description)
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            Description.Width = 300

            Dim Qty As New DataGridViewTextBoxColumn
            Qty.HeaderText = "Qty"
            Qty.DataPropertyName = "Qty"
            Qty.Width = 70
            dgParts.Columns.Add(Qty)
            Qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            Qty.Width = 70

            Dim Price As New DataGridViewTextBoxColumn
            Price.HeaderText = "Buy Price"
            Price.DataPropertyName = "Price"
            Price.Width = 70
            dgParts.Columns.Add(Price)
            Qty.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            Qty.Width = 70
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub SetupSearchDataGrid()
        Try
            '   SearchDataView = New DataView
            dgvSearch.AutoGenerateColumns = False
            '_searchDataView.AllowNew = False
            '_searchDataView.AllowEdit = False
            '_searchDataView.AllowDelete = False

            Dim PartSupplierID As New DataGridViewTextBoxColumn
            PartSupplierID.HeaderText = "PartSupplierID"
            PartSupplierID.DataPropertyName = "PartSupplierID"
            PartSupplierID.Width = 10
            dgvSearch.Columns.Add(PartSupplierID)
            PartSupplierID.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            PartSupplierID.Visible = False

            Dim IsSpecialPart As New DataGridViewTextBoxColumn
            IsSpecialPart.HeaderText = "IsSpecialPart"
            IsSpecialPart.DataPropertyName = "IsSpecialPart"
            IsSpecialPart.Width = 10
            dgvSearch.Columns.Add(IsSpecialPart)
            IsSpecialPart.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet
            IsSpecialPart.Visible = False

            Dim SupplierID As New DataGridViewTextBoxColumn
            SupplierID.HeaderText = "SupplierID"
            SupplierID.DataPropertyName = "SupplierID"
            SupplierID.Name = "SupplierID"
            SupplierID.Visible = True
            'PartSupplierID. = ""
            SupplierID.Width = 5
            dgvSearch.Columns.Add(SupplierID)

            Dim Supplier As New DataGridViewTextBoxColumn
            Supplier.HeaderText = "Supplier"
            Supplier.DataPropertyName = "Supplier"
            Supplier.Visible = True
            'PartSupplierID. = ""
            Supplier.Width = 120
            dgvSearch.Columns.Add(Supplier)

            Dim SPN As New DataGridViewTextBoxColumn
            SPN.HeaderText = "SPN"
            SPN.DataPropertyName = "PartCode"
            SPN.Width = 80
            dgvSearch.Columns.Add(SPN)
            SPN.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet

            Dim Number As New DataGridViewTextBoxColumn
            Number.HeaderText = "Number"
            Number.DataPropertyName = "Number"
            Number.Width = 80
            dgvSearch.Columns.Add(Number)

            Dim Description As New DataGridViewTextBoxColumn
            Description.HeaderText = "Description"
            Description.DataPropertyName = "Name"
            Description.Width = 400
            dgvSearch.Columns.Add(Description)

            Dim Price As New DataGridViewTextBoxColumn
            Price.HeaderText = "Buy Price"
            Price.DataPropertyName = "price"
            Price.Width = 80
            dgvSearch.Columns.Add(Price)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private _partsDataView As DataView

    Private Property PartsDataView() As DataView
        Get
            Return _partsDataView
        End Get
        Set(ByVal Value As DataView)
            If Not Value Is Nothing Then
                _partsDataView = Value
                _partsDataView.Table.TableName = "tblPart"
            End If
            dgParts.DataSource = _partsDataView
        End Set
    End Property

    Public ReadOnly Property SelectedPartsRow() As DataRow
        Get
            If Not PartsDataView Is Nothing Then
                If PartsDataView.Table.Rows.Count > 0 Then
                    Return PartsDataView(Me.dgParts.CurrentRow.Index).Row
                Else
                    Return Nothing
                End If
                Return Nothing
            End If
            Return Nothing
        End Get
    End Property

    Private _searchDataView As DataView

    Private Property SearchDataView() As DataView
        Get
            Return _searchDataView
        End Get
        Set(ByVal Value As DataView)
            If Not Value Is Nothing Then

                _searchDataView = Value
                _searchDataView.Table.TableName = "tblSearch"
            End If
            dgvSearch.DataSource = _searchDataView
        End Set
    End Property

    Public ReadOnly Property SelectedSearchRow() As DataRow
        Get
            If Not SearchDataView Is Nothing Then
                If SearchDataView.Table.Rows.Count > 0 Then
                    Return SearchDataView(Me.dgvSearch.CurrentRow.Index).Row
                Else
                    Return Nothing
                End If
                Return Nothing
            End If
            Return Nothing
        End Get
    End Property

    Dim SupplierID As Integer = 0

#End Region

#Region "Properties"

    Private _OrderNumber As New JobNumber

    Public Property OrderNumber() As JobNumber
        Get
            Return _OrderNumber
        End Get
        Set(ByVal Value As JobNumber)
            _OrderNumber = Value
            _OrderNumber.OrderNumber = OrderNumber.JobNumber
            While OrderNumber.OrderNumber.Length < 5
                _OrderNumber.OrderNumber = "0" & OrderNumber.OrderNumber
            End While
            Dim typePrefix As String = ""
            typePrefix = "V"
            Dim userPrefix As String = ""
            Dim username() As String = loggedInUser.Fullname.Split(" ")
            For Each s As String In username
                userPrefix += s.Substring(0, 1)
            Next
            _OrderNumber.OrderNumber = userPrefix & typePrefix & OrderNumber.OrderNumber
        End Set
    End Property

    Private _engineerVisitID As Integer

    Public Property EngineerVisitID() As Integer
        Get
            Return _engineerVisitID
        End Get
        Set(ByVal Value As Integer)
            _engineerVisitID = Value
        End Set
    End Property

    Private _engineerID As Integer

    Public Property EngineerID() As Integer
        Get
            Return _engineerID
        End Get
        Set(ByVal Value As Integer)
            _engineerID = Value
        End Set
    End Property

    Private PartsList As New DataTable

#End Region

#Region "Events"

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        If rbNo.Checked = False And rbYes.Checked = False Then
            ShowMessage("You must select the visit option to be able to create an order.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If PartsList.Rows.Count = 0 Then
            ShowMessage("You must select a part to create an order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboCostCentre))

        If Helper.IsValidInteger(department) AndAlso Helper.MakeIntegerValid(department) <= 0 Then
            ShowMessage("You need to enter a department to create an order", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim oJobAudit As New Entity.JobAudits.JobAudit

        Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure

        Dim oJob As Entity.Jobs.Job = DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID)
        Dim Job_JobID As String = oJob.JobID
        Dim Job_VisitType As Integer = oJob.JobTypeID
        Dim Job_SiteID As Integer = oJob.PropertyID

        If rbNo.Checked = True Then
            If Job_VisitType = 519 Then ' = service then create a new breakdown job
                Dim oJobNumber As JobNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.Callout)
                Dim Job_JobNumber As String = oJobNumber.JobNumber
                Dim Job_JobPrefix As String = oJobNumber.Prefix
                Job_JobNumber = Job_JobPrefix & Job_JobNumber

                Dim oNewJob As New Entity.Jobs.Job
                oNewJob.SetPropertyID = Job_SiteID
                oNewJob.SetJobDefinitionEnumID = Entity.Sys.Enums.JobDefinition.Callout
                oNewJob.SetJobTypeID = 4703
                oNewJob.SetCreatedByUserID = loggedInUser.UserID
                oNewJob.SetJobNumber = Job_JobNumber
                oNewJob.SetPONumber = Nothing
                oNewJob.SetQuoteID = 0
                oNewJob.SetContractID = 0
                oNewJob.SetToBePartPaid = False
                oNewJob.SetRetention = 0
                oNewJob.SetCollectPayment = False
                oNewJob.SetPOC = False
                oNewJob.SetOTI = False
                oNewJob.SetFOC = False
                oNewJob.SetDeleted = False
                oNewJob = DB.Job.Insert(oNewJob)
                Job_JobID = oNewJob.JobID

                Dim NewJobActionChange As String = "New Job Inserted (By User " & loggedInUser.Fullname.ToString & ") - JobNumber: " & Job_JobNumber & " (Unique Job ID: " & Job_JobID & ")"
                oJobAudit = New Entity.JobAudits.JobAudit
                oJobAudit.SetJobID = Job_JobID
                oJobAudit.SetActionChange = NewJobActionChange
                DB.JobAudit.Insert(oJobAudit)
            End If
            Dim trans As SqlClient.SqlTransaction
            Dim con As SqlClient.SqlConnection

            con = New SqlClient.SqlConnection(DB.ServerConnectionString)
            con.Open()
            trans = con.BeginTransaction(IsolationLevel.ReadUncommitted)
            Dim oJOW As New Entity.JobOfWorks.JobOfWork
            Dim JoW_JoWID As Integer
            oJOW.SetJobID = Job_JobID
            oJOW.SetDeleted = False
            oJOW.SetPONumber = ""
            oJOW.SetStatus = 1
            oJOW.SetPriority = Nothing

            oJOW = DB.JobOfWorks.Insert(oJOW, trans)
            JoW_JoWID = oJOW.JobOfWorkID
            trans.Commit()
            con.Close()
            Dim oEngVisit As New Entity.EngineerVisits.EngineerVisit
            oEngVisit.SetJobOfWorkID = JoW_JoWID
            oEngVisit.SetEngineerID = 0
            oEngVisit.SetStatusEnumID = 4
            oEngVisit.SetNotesFromEngineer = "Created for Tablet from Head Office"
            oEngVisit.SetPartsToFit = 1
            oEngVisit.SetExpectedEngineerID = 0
            oEngVisit.SetRecharge = 0
            oEngVisit.SetDeleted = False
            oEngVisit.SetAMPM = Nothing
            oEngVisit = DB.EngineerVisits.Insert(oEngVisit, Job_JobID)
            EngineerVisitID = oEngVisit.EngineerVisitID

            Dim ActionChange As String = "New Visit Inserted (By User " & loggedInUser.Fullname & ") - Status: NOT SET (Unique Visit ID: " & EngineerVisitID & ")"
            oJobAudit = New Entity.JobAudits.JobAudit
            oJobAudit.SetJobID = Job_JobID
            oJobAudit.SetActionChange = ActionChange
            DB.JobAudit.Insert(oJobAudit)
        Else
            Dim oEngVisit As Entity.EngineerVisits.EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID)
            If oEngVisit IsNot Nothing Then
                oEngVisit.SetPartsToFit = True
                DB.EngineerVisits.Update(oEngVisit, Job_JobID, True)
            End If

        End If

        Dim oOrder As New Entity.Orders.Order
        oOrder.IgnoreExceptionsOnSetMethods = True
        oOrder.SetSentToSage = False

        'validate a customer/van/warehouse has been selected

        oOrder.SetOrderID = 0 ' new
        oOrder.DatePlaced = Now
        oOrder.SetOrderTypeID = 4  ' Job
        oOrder.SetUserID = loggedInUser.UserID
        oOrder.SetOrderStatusID = CInt(2) ' Confirmed
        oOrder.DeliveryDeadline = Nothing 'TODO
        oOrder.SupplierInvoiceDate = Nothing
        OrderNumber = DB.Job.GetNextJobNumber(Entity.Sys.Enums.JobDefinition.ORDER)
        oOrder.SetDepartmentRef = department
        oOrder.SetDoNotConsolidated = True
        oOrder.DatePlaced = Me.dtpDatePlaced.Value
        'check if customer is pfh
        oOrder.SetOrderReference = OrderNumber.OrderNumber
        Dim customer As Customer = DB.Customer.Customer_Get_ForSiteID(oJob.PropertyID)
        If (customer.IsPFH = True) Then
            If DB.Supplier.Supplier_GetSecondaryPrice(SupplierID) Then
                oOrder.SetOrderReference = OrderNumber.OrderNumber & "F"
            End If
        End If

        oOrder = DB.Order.Insert(oOrder)

        Dim oEngineerVisitOrder As New Entity.EngineerVisitOrders.EngineerVisitOrder
        oEngineerVisitOrder.SetOrderID = oOrder.OrderID

        oEngineerVisitOrder.SetEngineerVisitID = EngineerVisitID

        DB.EngineerVisitOrder.EngineerVisitOrder_DeleteForOrder(oOrder.OrderID)
        oEngineerVisitOrder = DB.EngineerVisitOrder.Insert(oEngineerVisitOrder)

        'Add parts

        For Each dr As DataRow In PartsList.Rows

            Dim oOrderPart As New Entity.OrderParts.OrderPart
            oOrderPart.IgnoreExceptionsOnSetMethods = True
            oOrderPart.SetOrderID = oOrder.OrderID
            oOrderPart.SetPartSupplierID = dr("PartSupplierID")

            Dim partID As Integer = dr("PartID")
            Dim IsSpecialPart As Boolean = dr("IsSpecialPart")

            If IsSpecialPart Then
                Dim f As New FRMSpecialOrder(dr("PartSupplierID"),
                                                             dr("Price"), dr("Qty"))
                f.ShowDialog()
                If f.DialogResult = DialogResult.OK Then
                    oOrderPart.SetQuantity = f.Quantity
                    oOrderPart.SetBuyPrice = f.Price
                    oOrderPart.SetSpecialDescription = f.PartName
                    oOrderPart.SetSpecialPartNumber = f.SPN
                    oOrderPart.SetQuantityReceived = f.Quantity
                Else
                    Exit Sub
                End If
            Else

                oOrderPart.SetQuantity = dr("Qty")
                oOrderPart.SetBuyPrice = dr("Price")
                oOrderPart.SetQuantityReceived = dr("Qty")

            End If

            oOrderPart.SetChildSupplierID = 0

            Dim warehouseID As Integer = 0

            Dim val As New Entity.OrderParts.OrderPartValidator
            val.Validate(oOrderPart)

            oOrderPart = DB.OrderPart.Insert(oOrderPart, False)

            DB.EngineerVisitPartProductAllocated.InsertOne(EngineerVisitID,
                               "Part", oOrderPart.Quantity, oOrderPart.OrderPartID,
                                        dr("PartID"), 1) ' 1 = Supplier

        Next
        Dim orderControl As OrderControl = New OrderControl(oOrder)
        If orderControl.IsWithinJobSpendLimit() Then
            oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Complete) ' take it straight to complete
        Else
            If loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POAuthorisation) Then
                ShowMessage("Job cost capacity was exceeded when creating this purchase order!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                oOrder.SetOrderStatusID = CInt(Entity.Sys.Enums.OrderStatus.Complete) ' take it straight to complete
            Else
                ShowMessage("Job cost capacity was exceeded when creating this purchase order!" & vbCrLf & vbCrLf &
                            "Please note that this order is currently awaiting approval!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                oOrder.SetOrderStatusID = CInt(Enums.OrderStatus.AwaitingApproval)
            End If
        End If
        DB.Order.Update(oOrder)
        txtNewOrderNumber.Text = "Created Purchase Order Number : " & oOrder.OrderReference
        txtNewOrderNumber.Visible = If(oOrder.OrderStatusID = Enums.OrderStatus.AwaitingApproval, False, True)
        btnCreate.Enabled = False
    End Sub

    Private Sub TabletOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnFindPart_Click(sender As Object, e As EventArgs) Handles btnFindPart.Click
        Dim MasterSupplierID As Integer
        Dim cmd As String = "SELECT COALESCE(MasterSupplierID,0) FROM tblSupplier WHERE SupplierID = " & SupplierID
        MasterSupplierID = DB.ExecuteScalar(cmd)

        Dim PartFound As DataTable
        If MasterSupplierID = 0 Then
            SearchDataView = DB.PartSupplier.PartSupplier_FindTabletOrder(txtPartSearch.Text, SupplierID)
        Else
            SearchDataView = DB.PartSupplier.PartSupplier_FindTabletOrder(txtPartSearch.Text, SupplierID)
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellClick

        If dgvSearch.SelectedRows(0).Index > -1 Then
            btnAddPart.Enabled = True
        Else
            btnAddPart.Enabled = False
        End If
    End Sub

    Private Sub FrmPartSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetupDataTable()
            SetupPartsDataGrid()
            SetupSearchDataGrid()

            Me.Text = "Create Order (Current Visit: " & EngineerVisitID & " for Engineer: " & EngineerID & ")"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Try
            DialogResult = DialogResult.Cancel
            Close()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnAddPart_Click(sender As Object, e As EventArgs) Handles btnAddPart.Click, dgvSearch.CellDoubleClick

        Dim MasterSupplierID As Integer
        Dim cmd As String = "SELECT COALESCE(MasterSupplierID,0) FROM tblSupplier WHERE SupplierID = " & SupplierID
        MasterSupplierID = DB.ExecuteScalar(cmd)
        If dgvSearch.SelectedCells(0).RowIndex > -1 Then
            PartsList.Rows.Add(SelectedSearchRow("PartSupplierID"), SelectedSearchRow("PartCode"), SelectedSearchRow("Name"), nudQty.Value, SelectedSearchRow("Supplier"), SelectedSearchRow("PartID"), SelectedSearchRow("Price"), SelectedSearchRow("IsSpecialPart"))
            txtPartSearch.Text = Nothing
            btnAddPart.Enabled = False
            dgParts.DataSource = PartsList
            nudQty.Value = 1
            If MasterSupplierID > 0 Then
                SupplierID = MasterSupplierID
            Else
                SupplierID = SelectedSearchRow("SupplierID")
            End If
            'SupplierID = SelectedSearchRow("SupplierID")
            txtSupplier.Text = SelectedSearchRow("Supplier")
            SearchDataView.Table.Clear()
        Else
            MsgBox("Please select an item", MsgBoxStyle.OkOnly, "Opps")
        End If
    End Sub

    Private Sub txtPartSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartSearch.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnFindPart_Click(sender, e)
        End If
    End Sub

#End Region

End Class