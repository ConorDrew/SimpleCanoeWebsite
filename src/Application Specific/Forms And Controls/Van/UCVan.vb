Imports System.Collections

Public Class UCVan : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboPreferredSupplierID, DynamicDataTables.SupplierIDList, "SupplierID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents tcVans As System.Windows.Forms.TabControl

    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents grpVan As System.Windows.Forms.GroupBox
    Friend WithEvents txtProfile As System.Windows.Forms.TextBox
    Friend WithEvents lblProfile As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents tabStock As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgProducts As System.Windows.Forms.DataGrid
    Friend WithEvents dgParts As System.Windows.Forms.DataGrid
    Friend WithEvents btnCopyProfile As System.Windows.Forms.Button
    Friend WithEvents tpWarehouses As System.Windows.Forms.TabPage
    Friend WithEvents grpWarehouses As System.Windows.Forms.GroupBox
    Friend WithEvents dgWarehouses As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboPreferredSupplierID As System.Windows.Forms.ComboBox
    Friend WithEvents chkExcludeFromAutoStockReplen As System.Windows.Forms.CheckBox
    Friend WithEvents dgvParts As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddPartStockProfile As System.Windows.Forms.Button
    Friend WithEvents btnDeletePartStockProfile As System.Windows.Forms.Button
    Friend WithEvents btnClearVanStockProfile As System.Windows.Forms.Button
    Friend WithEvents btnExportStockProfile As System.Windows.Forms.Button
    Friend WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents chkSecondaryPrice As CheckBox
    Friend WithEvents chkContainer As CheckBox
    Friend WithEvents tabEquipment As TabPage
    Friend WithEvents grpVanEquipment As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtEquipmentTool As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSaveEquipment As Button
    Friend WithEvents btnDeleteEquipment As Button
    Friend WithEvents dgEquipment As DataGrid
    Friend WithEvents txtCurEngineer As TextBox
    Friend WithEvents lblCurEngineer As Label
    Friend WithEvents txtCurEngineerFleet As TextBox
    Friend WithEvents lblCurEngineerFleet As Label
    Friend WithEvents btnEngineerHistory As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tcVans = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.grpVan = New System.Windows.Forms.GroupBox()
        Me.txtCurEngineerFleet = New System.Windows.Forms.TextBox()
        Me.lblCurEngineerFleet = New System.Windows.Forms.Label()
        Me.txtCurEngineer = New System.Windows.Forms.TextBox()
        Me.lblCurEngineer = New System.Windows.Forms.Label()
        Me.btnCopyProfile = New System.Windows.Forms.Button()
        Me.btnEngineerHistory = New System.Windows.Forms.Button()
        Me.txtProfile = New System.Windows.Forms.TextBox()
        Me.lblProfile = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.tabStock = New System.Windows.Forms.TabPage()
        Me.chkContainer = New System.Windows.Forms.CheckBox()
        Me.chkSecondaryPrice = New System.Windows.Forms.CheckBox()
        Me.chkExcludeFromAutoStockReplen = New System.Windows.Forms.CheckBox()
        Me.dgParts = New System.Windows.Forms.DataGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboPreferredSupplierID = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.btnExportStockProfile = New System.Windows.Forms.Button()
        Me.btnClearVanStockProfile = New System.Windows.Forms.Button()
        Me.btnDeletePartStockProfile = New System.Windows.Forms.Button()
        Me.btnAddPartStockProfile = New System.Windows.Forms.Button()
        Me.dgvParts = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgProducts = New System.Windows.Forms.DataGrid()
        Me.tpWarehouses = New System.Windows.Forms.TabPage()
        Me.grpWarehouses = New System.Windows.Forms.GroupBox()
        Me.dgWarehouses = New System.Windows.Forms.DataGrid()
        Me.tabEquipment = New System.Windows.Forms.TabPage()
        Me.grpVanEquipment = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtEquipmentTool = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSaveEquipment = New System.Windows.Forms.Button()
        Me.btnDeleteEquipment = New System.Windows.Forms.Button()
        Me.dgEquipment = New System.Windows.Forms.DataGrid()
        Me.tcVans.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.grpVan.SuspendLayout()
        Me.tabStock.SuspendLayout()
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvParts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpWarehouses.SuspendLayout()
        Me.grpWarehouses.SuspendLayout()
        CType(Me.dgWarehouses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEquipment.SuspendLayout()
        Me.grpVanEquipment.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcVans
        '
        Me.tcVans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcVans.Controls.Add(Me.tabDetails)
        Me.tcVans.Controls.Add(Me.tabStock)
        Me.tcVans.Controls.Add(Me.tpWarehouses)
        Me.tcVans.Controls.Add(Me.tabEquipment)
        Me.tcVans.Location = New System.Drawing.Point(4, 7)
        Me.tcVans.Name = "tcVans"
        Me.tcVans.SelectedIndex = 0
        Me.tcVans.Size = New System.Drawing.Size(1206, 798)
        Me.tcVans.TabIndex = 0
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.grpVan)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New System.Drawing.Size(675, 644)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Main Details"
        '
        'grpVan
        '
        Me.grpVan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVan.Controls.Add(Me.txtCurEngineerFleet)
        Me.grpVan.Controls.Add(Me.lblCurEngineerFleet)
        Me.grpVan.Controls.Add(Me.txtCurEngineer)
        Me.grpVan.Controls.Add(Me.lblCurEngineer)
        Me.grpVan.Controls.Add(Me.btnCopyProfile)
        Me.grpVan.Controls.Add(Me.btnEngineerHistory)
        Me.grpVan.Controls.Add(Me.txtProfile)
        Me.grpVan.Controls.Add(Me.lblProfile)
        Me.grpVan.Controls.Add(Me.txtNotes)
        Me.grpVan.Controls.Add(Me.lblNotes)
        Me.grpVan.Location = New System.Drawing.Point(8, 8)
        Me.grpVan.Name = "grpVan"
        Me.grpVan.Size = New System.Drawing.Size(664, 631)
        Me.grpVan.TabIndex = 2
        Me.grpVan.TabStop = False
        Me.grpVan.Text = "Details"
        '
        'txtCurEngineerFleet
        '
        Me.txtCurEngineerFleet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurEngineerFleet.Enabled = False
        Me.txtCurEngineerFleet.Location = New System.Drawing.Point(131, 77)
        Me.txtCurEngineerFleet.MaxLength = 20
        Me.txtCurEngineerFleet.Name = "txtCurEngineerFleet"
        Me.txtCurEngineerFleet.Size = New System.Drawing.Size(380, 21)
        Me.txtCurEngineerFleet.TabIndex = 39
        Me.txtCurEngineerFleet.Tag = "Profile.EngineerFleet"
        '
        'lblCurEngineerFleet
        '
        Me.lblCurEngineerFleet.Location = New System.Drawing.Point(8, 80)
        Me.lblCurEngineerFleet.Name = "lblCurEngineerFleet"
        Me.lblCurEngineerFleet.Size = New System.Drawing.Size(117, 20)
        Me.lblCurEngineerFleet.TabIndex = 38
        Me.lblCurEngineerFleet.Text = "Engineer Fleet"
        '
        'txtCurEngineer
        '
        Me.txtCurEngineer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurEngineer.Enabled = False
        Me.txtCurEngineer.Location = New System.Drawing.Point(131, 50)
        Me.txtCurEngineer.MaxLength = 20
        Me.txtCurEngineer.Name = "txtCurEngineer"
        Me.txtCurEngineer.Size = New System.Drawing.Size(380, 21)
        Me.txtCurEngineer.TabIndex = 37
        Me.txtCurEngineer.Tag = "Profile.Engineer"
        '
        'lblCurEngineer
        '
        Me.lblCurEngineer.Location = New System.Drawing.Point(8, 53)
        Me.lblCurEngineer.Name = "lblCurEngineer"
        Me.lblCurEngineer.Size = New System.Drawing.Size(117, 20)
        Me.lblCurEngineer.TabIndex = 36
        Me.lblCurEngineer.Text = "Current Engineer"
        '
        'btnCopyProfile
        '
        Me.btnCopyProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopyProfile.Location = New System.Drawing.Point(6, 602)
        Me.btnCopyProfile.Name = "btnCopyProfile"
        Me.btnCopyProfile.Size = New System.Drawing.Size(87, 23)
        Me.btnCopyProfile.TabIndex = 35
        Me.btnCopyProfile.Text = "Copy Profile"
        Me.btnCopyProfile.UseVisualStyleBackColor = True
        '
        'btnEngineerHistory
        '
        Me.btnEngineerHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEngineerHistory.Location = New System.Drawing.Point(530, 19)
        Me.btnEngineerHistory.Name = "btnEngineerHistory"
        Me.btnEngineerHistory.Size = New System.Drawing.Size(112, 23)
        Me.btnEngineerHistory.TabIndex = 2
        Me.btnEngineerHistory.Text = "Engineer History"
        '
        'txtProfile
        '
        Me.txtProfile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProfile.Location = New System.Drawing.Point(131, 21)
        Me.txtProfile.MaxLength = 20
        Me.txtProfile.Name = "txtProfile"
        Me.txtProfile.Size = New System.Drawing.Size(380, 21)
        Me.txtProfile.TabIndex = 1
        Me.txtProfile.Tag = "Profile.Name"
        '
        'lblProfile
        '
        Me.lblProfile.Location = New System.Drawing.Point(8, 24)
        Me.lblProfile.Name = "lblProfile"
        Me.lblProfile.Size = New System.Drawing.Size(85, 20)
        Me.lblProfile.TabIndex = 31
        Me.lblProfile.Text = "Profile Name"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(131, 117)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(511, 473)
        Me.txtNotes.TabIndex = 7
        Me.txtNotes.Tag = "Profile.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 117)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(53, 22)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'tabStock
        '
        Me.tabStock.Controls.Add(Me.chkContainer)
        Me.tabStock.Controls.Add(Me.chkSecondaryPrice)
        Me.tabStock.Controls.Add(Me.chkExcludeFromAutoStockReplen)
        Me.tabStock.Controls.Add(Me.dgParts)
        Me.tabStock.Controls.Add(Me.GroupBox3)
        Me.tabStock.Controls.Add(Me.GroupBox2)
        Me.tabStock.Controls.Add(Me.GroupBox1)
        Me.tabStock.Location = New System.Drawing.Point(4, 22)
        Me.tabStock.Name = "tabStock"
        Me.tabStock.Size = New System.Drawing.Size(1198, 772)
        Me.tabStock.TabIndex = 1
        Me.tabStock.Text = "Stock"
        '
        'chkContainer
        '
        Me.chkContainer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkContainer.AutoSize = True
        Me.chkContainer.Location = New System.Drawing.Point(528, 742)
        Me.chkContainer.Name = "chkContainer"
        Me.chkContainer.Size = New System.Drawing.Size(143, 17)
        Me.chkContainer.TabIndex = 5
        Me.chkContainer.Text = "Use Container Stock"
        Me.chkContainer.UseVisualStyleBackColor = True
        '
        'chkSecondaryPrice
        '
        Me.chkSecondaryPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSecondaryPrice.AutoSize = True
        Me.chkSecondaryPrice.Location = New System.Drawing.Point(330, 742)
        Me.chkSecondaryPrice.Name = "chkSecondaryPrice"
        Me.chkSecondaryPrice.Size = New System.Drawing.Size(144, 17)
        Me.chkSecondaryPrice.TabIndex = 4
        Me.chkSecondaryPrice.Text = "Use Secondary Price"
        Me.chkSecondaryPrice.UseVisualStyleBackColor = True
        '
        'chkExcludeFromAutoStockReplen
        '
        Me.chkExcludeFromAutoStockReplen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkExcludeFromAutoStockReplen.AutoSize = True
        Me.chkExcludeFromAutoStockReplen.Location = New System.Drawing.Point(16, 742)
        Me.chkExcludeFromAutoStockReplen.Name = "chkExcludeFromAutoStockReplen"
        Me.chkExcludeFromAutoStockReplen.Size = New System.Drawing.Size(288, 17)
        Me.chkExcludeFromAutoStockReplen.TabIndex = 3
        Me.chkExcludeFromAutoStockReplen.Text = "Exclude From Automatic Stock Replenishment"
        Me.chkExcludeFromAutoStockReplen.UseVisualStyleBackColor = True
        '
        'dgParts
        '
        Me.dgParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgParts.DataMember = ""
        Me.dgParts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgParts.Location = New System.Drawing.Point(637, 259)
        Me.dgParts.Name = "dgParts"
        Me.dgParts.Size = New System.Drawing.Size(558, 380)
        Me.dgParts.TabIndex = 2
        Me.dgParts.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cboPreferredSupplierID)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 680)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1179, 49)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Preferred Supplier"
        '
        'cboPreferredSupplierID
        '
        Me.cboPreferredSupplierID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboPreferredSupplierID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPreferredSupplierID.FormattingEnabled = True
        Me.cboPreferredSupplierID.Location = New System.Drawing.Point(8, 20)
        Me.cboPreferredSupplierID.Name = "cboPreferredSupplierID"
        Me.cboPreferredSupplierID.Size = New System.Drawing.Size(616, 21)
        Me.cboPreferredSupplierID.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnMerge)
        Me.GroupBox2.Controls.Add(Me.btnExportStockProfile)
        Me.GroupBox2.Controls.Add(Me.btnClearVanStockProfile)
        Me.GroupBox2.Controls.Add(Me.btnDeletePartStockProfile)
        Me.GroupBox2.Controls.Add(Me.btnAddPartStockProfile)
        Me.GroupBox2.Controls.Add(Me.dgvParts)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 239)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1179, 435)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parts Held On Profile"
        '
        'btnMerge
        '
        Me.btnMerge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMerge.Location = New System.Drawing.Point(137, 406)
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.Size = New System.Drawing.Size(159, 23)
        Me.btnMerge.TabIndex = 37
        Me.btnMerge.Text = "Merge Another Profile"
        Me.btnMerge.UseVisualStyleBackColor = True
        '
        'btnExportStockProfile
        '
        Me.btnExportStockProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportStockProfile.Location = New System.Drawing.Point(557, 406)
        Me.btnExportStockProfile.Name = "btnExportStockProfile"
        Me.btnExportStockProfile.Size = New System.Drawing.Size(200, 23)
        Me.btnExportStockProfile.TabIndex = 7
        Me.btnExportStockProfile.Text = "Export Stock Profile"
        Me.btnExportStockProfile.UseVisualStyleBackColor = True
        '
        'btnClearVanStockProfile
        '
        Me.btnClearVanStockProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearVanStockProfile.Location = New System.Drawing.Point(8, 406)
        Me.btnClearVanStockProfile.MaximumSize = New System.Drawing.Size(181, 23)
        Me.btnClearVanStockProfile.Name = "btnClearVanStockProfile"
        Me.btnClearVanStockProfile.Size = New System.Drawing.Size(123, 23)
        Me.btnClearVanStockProfile.TabIndex = 6
        Me.btnClearVanStockProfile.Text = "Clear Stock Profile"
        Me.btnClearVanStockProfile.UseVisualStyleBackColor = True
        '
        'btnDeletePartStockProfile
        '
        Me.btnDeletePartStockProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeletePartStockProfile.Location = New System.Drawing.Point(971, 406)
        Me.btnDeletePartStockProfile.MaximumSize = New System.Drawing.Size(0, 23)
        Me.btnDeletePartStockProfile.Name = "btnDeletePartStockProfile"
        Me.btnDeletePartStockProfile.Size = New System.Drawing.Size(200, 23)
        Me.btnDeletePartStockProfile.TabIndex = 5
        Me.btnDeletePartStockProfile.Text = "Remove Part from Stock Profile"
        Me.btnDeletePartStockProfile.UseVisualStyleBackColor = True
        '
        'btnAddPartStockProfile
        '
        Me.btnAddPartStockProfile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddPartStockProfile.Location = New System.Drawing.Point(763, 406)
        Me.btnAddPartStockProfile.Name = "btnAddPartStockProfile"
        Me.btnAddPartStockProfile.Size = New System.Drawing.Size(200, 23)
        Me.btnAddPartStockProfile.TabIndex = 4
        Me.btnAddPartStockProfile.Text = "Add Part to Stock Profile"
        Me.btnAddPartStockProfile.UseVisualStyleBackColor = True
        '
        'dgvParts
        '
        Me.dgvParts.AllowUserToAddRows = False
        Me.dgvParts.AllowUserToDeleteRows = False
        Me.dgvParts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParts.Location = New System.Drawing.Point(8, 20)
        Me.dgvParts.Name = "dgvParts"
        Me.dgvParts.Size = New System.Drawing.Size(1162, 380)
        Me.dgvParts.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgProducts)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1179, 224)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Products Held On Profile"
        '
        'dgProducts
        '
        Me.dgProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProducts.DataMember = ""
        Me.dgProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProducts.Location = New System.Drawing.Point(8, 34)
        Me.dgProducts.Name = "dgProducts"
        Me.dgProducts.Size = New System.Drawing.Size(1163, 184)
        Me.dgProducts.TabIndex = 1
        '
        'tpWarehouses
        '
        Me.tpWarehouses.Controls.Add(Me.grpWarehouses)
        Me.tpWarehouses.Location = New System.Drawing.Point(4, 22)
        Me.tpWarehouses.Name = "tpWarehouses"
        Me.tpWarehouses.Padding = New System.Windows.Forms.Padding(3)
        Me.tpWarehouses.Size = New System.Drawing.Size(675, 644)
        Me.tpWarehouses.TabIndex = 2
        Me.tpWarehouses.Text = "Warehouse Locations"
        Me.tpWarehouses.UseVisualStyleBackColor = True
        '
        'grpWarehouses
        '
        Me.grpWarehouses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpWarehouses.Controls.Add(Me.dgWarehouses)
        Me.grpWarehouses.Location = New System.Drawing.Point(6, 6)
        Me.grpWarehouses.Name = "grpWarehouses"
        Me.grpWarehouses.Size = New System.Drawing.Size(663, 632)
        Me.grpWarehouses.TabIndex = 3
        Me.grpWarehouses.TabStop = False
        Me.grpWarehouses.Text = "Tick those warehouses for this profile"
        '
        'dgWarehouses
        '
        Me.dgWarehouses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgWarehouses.DataMember = ""
        Me.dgWarehouses.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgWarehouses.Location = New System.Drawing.Point(6, 20)
        Me.dgWarehouses.Name = "dgWarehouses"
        Me.dgWarehouses.Size = New System.Drawing.Size(651, 606)
        Me.dgWarehouses.TabIndex = 2
        '
        'tabEquipment
        '
        Me.tabEquipment.BackColor = System.Drawing.SystemColors.Control
        Me.tabEquipment.Controls.Add(Me.grpVanEquipment)
        Me.tabEquipment.Location = New System.Drawing.Point(4, 22)
        Me.tabEquipment.Name = "tabEquipment"
        Me.tabEquipment.Size = New System.Drawing.Size(675, 644)
        Me.tabEquipment.TabIndex = 3
        Me.tabEquipment.Text = "Capital Tools"
        '
        'grpVanEquipment
        '
        Me.grpVanEquipment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpVanEquipment.Controls.Add(Me.Panel2)
        Me.grpVanEquipment.Controls.Add(Me.btnDeleteEquipment)
        Me.grpVanEquipment.Controls.Add(Me.dgEquipment)
        Me.grpVanEquipment.Location = New System.Drawing.Point(3, 13)
        Me.grpVanEquipment.Name = "grpVanEquipment"
        Me.grpVanEquipment.Size = New System.Drawing.Size(662, 617)
        Me.grpVanEquipment.TabIndex = 14
        Me.grpVanEquipment.TabStop = False
        Me.grpVanEquipment.Text = "Capital Tools"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtEquipmentTool)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btnSaveEquipment)
        Me.Panel2.Location = New System.Drawing.Point(8, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(648, 69)
        Me.Panel2.TabIndex = 2
        '
        'txtEquipmentTool
        '
        Me.txtEquipmentTool.AcceptsReturn = True
        Me.txtEquipmentTool.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEquipmentTool.Location = New System.Drawing.Point(115, 4)
        Me.txtEquipmentTool.MaxLength = 255
        Me.txtEquipmentTool.Multiline = True
        Me.txtEquipmentTool.Name = "txtEquipmentTool"
        Me.txtEquipmentTool.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEquipmentTool.Size = New System.Drawing.Size(432, 56)
        Me.txtEquipmentTool.TabIndex = 1
        Me.txtEquipmentTool.Tag = "Engineer.Name"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 20)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Equipment\Tool"
        '
        'btnSaveEquipment
        '
        Me.btnSaveEquipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveEquipment.Location = New System.Drawing.Point(560, 36)
        Me.btnSaveEquipment.Name = "btnSaveEquipment"
        Me.btnSaveEquipment.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveEquipment.TabIndex = 2
        Me.btnSaveEquipment.Text = "Save"
        '
        'btnDeleteEquipment
        '
        Me.btnDeleteEquipment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteEquipment.Location = New System.Drawing.Point(8, 585)
        Me.btnDeleteEquipment.Name = "btnDeleteEquipment"
        Me.btnDeleteEquipment.Size = New System.Drawing.Size(75, 23)
        Me.btnDeleteEquipment.TabIndex = 4
        Me.btnDeleteEquipment.Text = "Delete"
        '
        'dgEquipment
        '
        Me.dgEquipment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgEquipment.DataMember = ""
        Me.dgEquipment.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEquipment.Location = New System.Drawing.Point(8, 103)
        Me.dgEquipment.Name = "dgEquipment"
        Me.dgEquipment.Size = New System.Drawing.Size(646, 474)
        Me.dgEquipment.TabIndex = 3
        '
        'UCVan
        '
        Me.Controls.Add(Me.tcVans)
        Me.Name = "UCVan"
        Me.Size = New System.Drawing.Size(1216, 808)
        Me.tcVans.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.grpVan.ResumeLayout(False)
        Me.grpVan.PerformLayout()
        Me.tabStock.ResumeLayout(False)
        Me.tabStock.PerformLayout()
        CType(Me.dgParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvParts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpWarehouses.ResumeLayout(False)
        Me.grpWarehouses.ResumeLayout(False)
        CType(Me.dgWarehouses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEquipment.ResumeLayout(False)
        Me.grpVanEquipment.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupPartsDatagrid()
        SetupProductsDatagrid()
        SetupWarehousesDatagrid()
        SetupPartsDataGridView()
        DgSetupVanEquipment()
        Me.dgParts.ReadOnly = False
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentVan
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private oldDepartment As Integer = 0

    Private _currentVan As Entity.Vans.Van

    Public Property CurrentVan() As Entity.Vans.Van
        Get
            Return _currentVan
        End Get
        Set(ByVal Value As Entity.Vans.Van)
            _currentVan = Value

            If _currentVan Is Nothing Then
                _currentVan = New Entity.Vans.Van
                _currentVan.Exists = False
            End If

            If _currentVan.Exists Then
                Me.btnEngineerHistory.Enabled = True
            Else
                WarehousesDataView = DB.Warehouse.Warehouse_GetAll_For_Van2(0)
                Me.btnEngineerHistory.Enabled = False
            End If
        End Set
    End Property

    Private m_dTable As DataView = Nothing

    Public Property ProductsDataView() As DataView
        Get
            Return m_dTable
        End Get
        Set(ByVal Value As DataView)
            m_dTable = Value
            m_dTable.Table.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString
            m_dTable.AllowNew = False
            m_dTable.AllowEdit = False
            m_dTable.AllowDelete = False
            Me.dgProducts.DataSource = ProductsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedProductDataRow() As DataRow
        Get
            If Not Me.dgProducts.CurrentRowIndex = -1 Then
                Return ProductsDataView(Me.dgProducts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private m_dTable2 As DataView = Nothing

    Public Property PartsDataView() As DataView
        Get
            Return m_dTable2
        End Get
        Set(ByVal Value As DataView)
            m_dTable2 = Value
            m_dTable2.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
            m_dTable2.AllowNew = False
            m_dTable2.AllowEdit = True
            m_dTable2.AllowDelete = False
            Me.dgParts.DataSource = PartsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedPartDataRow() As DataRow
        Get
            If Not Me.dgParts.CurrentRowIndex = -1 Then
                Return PartsDataView(Me.dgParts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private ReadOnly Property SelecteddgvPartDataRow() As DataGridViewRow
        Get
            If Not Me.dgvParts.CurrentRow.Index = -1 Then
                Return Me.dgvParts.CurrentRow
            Else
                Return Nothing
            End If

        End Get
    End Property

    Private _WarehousesDataView As DataView = Nothing

    Public Property WarehousesDataView() As DataView
        Get
            Return _WarehousesDataView
        End Get
        Set(ByVal Value As DataView)
            _WarehousesDataView = Value
            _WarehousesDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
            _WarehousesDataView.AllowNew = False
            _WarehousesDataView.AllowEdit = False
            _WarehousesDataView.AllowDelete = False
            Me.dgWarehouses.DataSource = WarehousesDataView
        End Set
    End Property

    Private ReadOnly Property SelectedWarehouseDataRow() As DataRow
        Get
            If Not Me.dgWarehouses.CurrentRowIndex = -1 Then
                Return WarehousesDataView(Me.dgWarehouses.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private m_dTable5 As DataTable = Nothing

    Public Property PartsDataGridView() As DataTable
        Get
            Return m_dTable5
        End Get
        Set(ByVal Value As DataTable)
            m_dTable5 = Value
            Me.dgvParts.DataSource = Value
        End Set
    End Property

    Private _dvEquipment As DataView = Nothing

    Public Property DvEquipment() As DataView
        Get
            Return _dvEquipment
        End Get
        Set(ByVal Value As DataView)
            _dvEquipment = Value
            _dvEquipment.AllowNew = False
            _dvEquipment.AllowEdit = False
            _dvEquipment.AllowDelete = False
            Me.dgEquipment.DataSource = DvEquipment
        End Set
    End Property

    Private ReadOnly Property DrSelectedEquipment() As DataRow
        Get
            If Not Me.dgEquipment.CurrentRowIndex = -1 Then
                Return DvEquipment(Me.dgEquipment.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Events"

    Private Sub UCVan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub
    Private Sub btnEngineerHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEngineerHistory.Click
        ShowForm(GetType(FRMEngineerHistory), True, New Object() {CurrentVan.VanID})
        Populate(CurrentVan.VanID)
    End Sub

    Private Sub dgvParts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvParts.DoubleClick
        If Me.dgvParts.CurrentRow Is Nothing Then
            Exit Sub
        End If
        ShowForm(GetType(FRMPart), True, New Object() {Me.dgvParts.CurrentRow.Cells(7).Value, True})
        PartsDataGridView = DB.PartTransaction.GetByVan2(CurrentVan.VanID, True, False, Combo.GetSelectedItemValue(cboPreferredSupplierID))
    End Sub

    Private Sub btnCopyVan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyProfile.Click

        If CurrentVan.Exists Then
            Try
                Dim newVan As New Entity.Vans.Van
                Me.Cursor = Cursors.WaitCursor
                newVan.IgnoreExceptionsOnSetMethods = True

                newVan.SetRegistration = InputBox("Please enter new profile name:", "Profile")
                newVan.SetNotes = Me.txtNotes.Text.Trim
                newVan.SetPreferredSupplierID = Combo.GetSelectedItemValue(Me.cboPreferredSupplierID)

                If CurrentVan.InsuranceDue = Nothing Then CurrentVan.InsuranceDue = Now
                If CurrentVan.MOTDue = Nothing Then CurrentVan.MOTDue = Now
                If CurrentVan.TaxDue = Nothing Then CurrentVan.TaxDue = Now
                If CurrentVan.ServiceDue = Nothing Then CurrentVan.ServiceDue = Now

                Dim cV As New Entity.Vans.VanValidator
                cV.Validate(newVan)
                newVan = DB.Van.CopyVan(newVan, CurrentVan.Registration, WarehousesDataView, False)

                RaiseEvent RecordsChanged(DB.Van.Van_GetAll(True), Entity.Sys.Enums.PageViewing.StockProfile, True, False, "")
                RaiseEvent StateChanged(CurrentVan.VanID)
                MainForm.RefreshEntity(CurrentVan.VanID)

                ShowMessage("Profile Copy Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch vex As ValidationException
                Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
                msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As Exception
                ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            ShowMessage("Save current Profile before continuing", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnMergeProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerge.Click

        If CurrentVan.Exists Then
            Try
                Dim Van As New Entity.Vans.Van
                Me.Cursor = Cursors.WaitCursor
                Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblVan)
                If Not ID = 0 Then
                    Van = DB.Van.Van_Get(ID)
                Else
                    Exit Sub
                End If



                CurrentVan = DB.Van.MergeVan(Van, CurrentVan)  '  hereer

                RaiseEvent RecordsChanged(DB.Van.Van_GetAll(True), Entity.Sys.Enums.PageViewing.Van, True, False, "")
                RaiseEvent StateChanged(CurrentVan.VanID)
                MainForm.RefreshEntity(CurrentVan.VanID)

                ShowMessage("Van Merge Process Completed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch vex As ValidationException
                Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
                msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
                ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As Exception
                ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            ShowMessage("Save current van before continuing", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgWarehouses_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgWarehouses.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgWarehouses.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgWarehouses.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedWarehouseDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(Me.dgWarehouses(Me.dgWarehouses.CurrentRowIndex, 0))

            If Not selected Then
                If SelectedWarehouseDataRow.Item("IsGasway") Then
                    ShowMessage("Gasway warehouse cannot be unselected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            Me.dgWarehouses(Me.dgWarehouses.CurrentRowIndex, 0) = selected
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentVan = DB.Van.Van_Get(ID)
        End If

        CurrentVan.SetRegistration = CurrentVan.Registration.Split("*")(0).Trim

        Dim dvCurrentEngineersOnVan As DataView = DB.EngineerVan.EngineerVan_GetAll_For_Van(ID)

        Dim drActiveEngineers As DataRow() = dvCurrentEngineersOnVan.Table.Select("EnddateTime > '" + Date.Now + "' Or EnddateTime Is null")

        If drActiveEngineers.Length < 1 Then
            Me.txtCurEngineer.Text = "<<No engineer is currently set/active to this profile>>"
            Me.txtCurEngineerFleet.Text = "<<Engineer is not currently assigned to a van>>"
        Else
            Me.txtCurEngineer.Text = drActiveEngineers(0)("Engineer")
            Dim dvCurrentEngineerFleet As DataView = DB.FleetVanEngineer.GetAll_ByEngineerID(drActiveEngineers(0)("EngineerID"))
            If dvCurrentEngineerFleet?.Count > 0 Then
                Me.txtCurEngineerFleet.Text = dvCurrentEngineerFleet(0)("Registration")
            Else
                Me.txtCurEngineerFleet.Text = "<<Engineer is not currently assigned to a van>>"
            End If
        End If

        Me.txtProfile.Text = CurrentVan.Registration
        Me.txtNotes.Text = CurrentVan.Notes
        Combo.SetSelectedComboItem_By_Value(Me.cboPreferredSupplierID, CurrentVan.PreferredSupplierID)
        If CurrentVan.ExcludeFromAutoReplenishment = True Then
            Me.chkExcludeFromAutoStockReplen.Checked = True
        End If

        If CurrentVan.UseContainerStock = True Then
            Me.chkContainer.Checked = True
        End If

        Me.chkSecondaryPrice.Checked = CurrentVan.SecondaryPrice
        Me.chkSecondaryPrice.Visible = IIf(CurrentVan.EngineerVanID > 0, True, False)

        PartsDataGridView = DB.PartTransaction.GetByVan2(CurrentVan.VanID, True, False, Combo.GetSelectedItemValue(cboPreferredSupplierID))
        WarehousesDataView = DB.Warehouse.Warehouse_GetAll_For_Van2(CurrentVan.VanID)
        DvEquipment = DB.VanEquipments.Get(CurrentVan.VanID)
        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Me.Cursor = Cursors.WaitCursor
            CurrentVan.IgnoreExceptionsOnSetMethods = True

            CurrentVan.SetRegistration = Me.txtProfile.Text.Trim
            CurrentVan.SetNotes = Me.txtNotes.Text.Trim
            CurrentVan.SetPreferredSupplierID = Combo.GetSelectedItemValue(Me.cboPreferredSupplierID)
            If CurrentVan.InsuranceDue = Nothing Then CurrentVan.InsuranceDue = Now
            If CurrentVan.MOTDue = Nothing Then CurrentVan.MOTDue = Now
            If CurrentVan.TaxDue = Nothing Then CurrentVan.TaxDue = Now
            If CurrentVan.ServiceDue = Nothing Then CurrentVan.ServiceDue = Now
            If CurrentVan.MileageLimit < 1 Then CurrentVan.SetMileageLimit = 1
            If CurrentVan.PeriodValue < 1 Then CurrentVan.SetPeriodValue = 1
            If CurrentVan.PeriodType < 1 Then CurrentVan.SetPeriodType = 1

            If Me.chkExcludeFromAutoStockReplen.Checked = True Then
                CurrentVan.SetExcludeFromAutoReplenishment = True
            Else
                CurrentVan.SetExcludeFromAutoReplenishment = False
            End If
            If Me.chkContainer.Checked = True Then
                CurrentVan.SetUseContainerStock = True
            Else
                CurrentVan.SetUseContainerStock = False
            End If
            CurrentVan.SecondaryPrice = Me.chkSecondaryPrice.Checked

            Dim cV As New Entity.Vans.VanValidator
            cV.Validate(CurrentVan)

            If CurrentVan.Exists Then
                DB.Van.Update(CurrentVan, WarehousesDataView, False)
            Else
                CurrentVan = DB.Van.Insert(CurrentVan, "", WarehousesDataView, False)
            End If

            MainForm.RefreshEntity(CurrentVan.VanID)

            Return True
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            ShowMessage(CurrentVan.Registration & " profile has been saved.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Public Sub SetupProductsDatagrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgProducts)
        Dim tStyle As DataGridTableStyle = Me.dgProducts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 100
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim ProductName As New DataGridLabelColumn
        ProductName.Format = ""
        ProductName.FormatInfo = Nothing
        ProductName.HeaderText = "Description"
        ProductName.MappingName = "typemakemodel"
        ProductName.ReadOnly = True
        ProductName.Width = 180
        ProductName.NullText = ""
        tStyle.GridColumnStyles.Add(ProductName)

        Dim ProductNumber As New DataGridLabelColumn
        ProductNumber.Format = ""
        ProductNumber.FormatInfo = Nothing
        ProductNumber.HeaderText = "GC Number"
        ProductNumber.MappingName = "ProductNumber"
        ProductNumber.ReadOnly = True
        ProductNumber.Width = 140
        ProductNumber.NullText = ""
        tStyle.GridColumnStyles.Add(ProductNumber)

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
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProduct.ToString
        Me.dgProducts.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupPartsDatagrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgParts)
        Me.dgParts.ReadOnly = False
        Dim tStyle As DataGridTableStyle = Me.dgParts.TableStyles(0)

        tStyle.GridColumnStyles.Clear()
        tStyle.ReadOnly = False

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 100
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim PartName As New DataGridLabelColumn
        PartName.Format = ""
        PartName.FormatInfo = Nothing
        PartName.HeaderText = "Part Name"
        PartName.MappingName = "PartName"
        PartName.ReadOnly = True
        PartName.Width = 180
        PartName.NullText = ""
        tStyle.GridColumnStyles.Add(PartName)

        Dim PartNumber As New DataGridLabelColumn
        PartNumber.Format = ""
        PartNumber.FormatInfo = Nothing
        PartNumber.HeaderText = "Part Number"
        PartNumber.MappingName = "PartNumber"
        PartNumber.ReadOnly = True
        PartNumber.Width = 140
        PartNumber.NullText = ""
        tStyle.GridColumnStyles.Add(PartNumber)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = ""
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 120
        Amount.NullText = ""
        tStyle.GridColumnStyles.Add(Amount)

        Dim MinQty As New DataGridEditableTextBoxColumn
        MinQty.Format = ""
        MinQty.FormatInfo = Nothing
        MinQty.HeaderText = "MinQty"
        MinQty.MappingName = "Min"
        MinQty.ReadOnly = False
        MinQty.Width = 120
        MinQty.NullText = ""
        tStyle.GridColumnStyles.Add(MinQty)

        Dim MaxQty As New DataGridEditableTextBoxColumn
        MaxQty.Format = ""
        MaxQty.FormatInfo = Nothing
        MaxQty.HeaderText = "MaxQty"
        MaxQty.MappingName = "Max"
        MaxQty.ReadOnly = False
        MaxQty.Width = 120
        MaxQty.NullText = ""
        tStyle.GridColumnStyles.Add(MaxQty)

        Dim MinMaxID As New DataGridLabelColumn
        MinMaxID.Format = ""
        MinMaxID.FormatInfo = Nothing
        MinMaxID.HeaderText = "MinMaxID"
        MinMaxID.MappingName = "MinMaxID"
        MinMaxID.ReadOnly = True
        MinMaxID.Width = 100
        MinMaxID.NullText = ""
        tStyle.GridColumnStyles.Add(MinMaxID)

        tStyle.ReadOnly = False
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString
        Me.dgParts.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupWarehousesDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgWarehouses)
        Dim tStyle As DataGridTableStyle = Me.dgWarehouses.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        tStyle.ReadOnly = False
        tStyle.AllowSorting = False
        dgWarehouses.ReadOnly = False
        dgWarehouses.AllowSorting = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tStyle.GridColumnStyles.Add(Tick)

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Name"
        Name.MappingName = "Name"
        Name.ReadOnly = True
        Name.Width = 300
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblWarehouse.ToString
        Me.dgWarehouses.TableStyles.Add(tStyle)
    End Sub

    Public Sub DgSetupVanEquipment()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgEquipment)
        Dim tStyle As DataGridTableStyle = Me.dgEquipment.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim equipment As New DataGridLabelColumn
        equipment.Format = ""
        equipment.FormatInfo = Nothing
        equipment.HeaderText = "Equipment/Tool"
        equipment.MappingName = "Equipment"
        equipment.ReadOnly = True
        equipment.Width = 400
        equipment.NullText = ""
        tStyle.GridColumnStyles.Add(equipment)

        Dim created As New DataGridLabelColumn
        created.Format = "dd/MM/yyyy"
        created.FormatInfo = Nothing
        created.HeaderText = "Date Added"
        created.MappingName = "Created"
        created.ReadOnly = True
        created.Width = 100
        created.NullText = ""
        tStyle.GridColumnStyles.Add(created)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblVan.ToString
        Me.dgEquipment.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupPartsDataGridView()
        Entity.Sys.Helper.SetUpDataGridView(Me.dgvParts)
        dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvParts.AutoGenerateColumns = False
        dgvParts.Columns.Clear()
        dgvParts.EditMode = DataGridViewEditMode.EditOnEnter

        Dim Location As New DataGridViewTextBoxColumn
        Location.HeaderText = "Location"
        Location.FillWeight = 15
        Location.DataPropertyName = "Location"
        Location.ReadOnly = True
        Location.Visible = True
        Location.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(Location)

        Dim PartName As New DataGridViewTextBoxColumn
        PartName.FillWeight = 60
        PartName.HeaderText = "Part Name"
        PartName.DataPropertyName = "PartName"
        PartName.ReadOnly = True
        PartName.Visible = True
        PartName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(PartName)

        Dim PartNumber As New DataGridViewTextBoxColumn
        PartNumber.HeaderText = "Part Number"
        PartNumber.DataPropertyName = "PartNumber"
        PartNumber.FillWeight = 25
        PartNumber.ReadOnly = True
        PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(PartNumber)

        Dim Amount As New DataGridViewTextBoxColumn
        Amount.HeaderText = "Amount"
        Amount.DataPropertyName = "Amount"
        Amount.FillWeight = 15
        Amount.ReadOnly = True
        Amount.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(Amount)

        Dim MinQty As New DataGridViewTextBoxColumn
        MinQty.HeaderText = "Min"
        MinQty.DataPropertyName = "Min"
        MinQty.FillWeight = 15
        MinQty.ReadOnly = False
        MinQty.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(MinQty)

        Dim MaxQty As New DataGridViewTextBoxColumn
        MaxQty.HeaderText = "Max"
        MaxQty.DataPropertyName = "Max"
        MaxQty.FillWeight = 16
        MaxQty.ReadOnly = False
        MaxQty.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvParts.Columns.Add(MaxQty)

        Dim MinMaxID As New DataGridViewTextBoxColumn
        MinMaxID.HeaderText = "MinMaxID"
        MinMaxID.DataPropertyName = "MinMaxID"
        MinMaxID.FillWeight = 1
        MinMaxID.ReadOnly = True
        MinMaxID.SortMode = DataGridViewColumnSortMode.Programmatic
        MinMaxID.Visible = False
        dgvParts.Columns.Add(MinMaxID)

        Dim PartID As New DataGridViewTextBoxColumn
        PartID.HeaderText = "PartID"
        PartID.DataPropertyName = "PartID"
        'PartID.FillWeight = 75
        PartID.FillWeight = 1
        PartID.ReadOnly = True
        PartID.SortMode = DataGridViewColumnSortMode.Programmatic
        'PartID.Visible = True
        PartID.Visible = False
        dgvParts.Columns.Add(PartID)

        Dim LocationID As New DataGridViewTextBoxColumn
        LocationID.HeaderText = "LocationID"
        LocationID.DataPropertyName = "LocationID"
        LocationID.FillWeight = 1
        LocationID.ReadOnly = True
        LocationID.SortMode = DataGridViewColumnSortMode.Programmatic
        LocationID.Visible = False
        dgvParts.Columns.Add(LocationID)

        Dim SPN As New DataGridViewTextBoxColumn
        SPN.HeaderText = "SPN"
        SPN.DataPropertyName = "SPN"
        SPN.FillWeight = 25
        SPN.ReadOnly = True
        SPN.SortMode = DataGridViewColumnSortMode.Programmatic
        SPN.Visible = True
        dgvParts.Columns.Add(SPN)

        dgvParts.Sort(MinMaxID, System.ComponentModel.ListSortDirection.Descending)

    End Sub

#End Region

    Private Sub dgvParts_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvParts.CellEndEdit
        If SelecteddgvPartDataRow Is Nothing Then
            Exit Sub
        End If

        'update the min max record

        Dim RecordID As Integer = 0
        Dim MinValue As Integer = 0
        Dim MaxValue As Integer = 0
        Dim PartID As Integer = 0
        Dim LocationID As Integer = 0
        RecordID = SelecteddgvPartDataRow.Cells.Item(6).Value
        MinValue = SelecteddgvPartDataRow.Cells.Item(4).Value
        MaxValue = SelecteddgvPartDataRow.Cells.Item(5).Value
        PartID = SelecteddgvPartDataRow.Cells.Item(7).Value
        LocationID = SelecteddgvPartDataRow.Cells.Item(8).Value

        If RecordID = 0 Then
            Dim NewRecord As Integer = DB.PartTransaction.PartLocations_Insert2(PartID, LocationID, MinValue, MaxValue)
            SelecteddgvPartDataRow.Cells.Item(6).Value = NewRecord
        Else
            DB.PartTransaction.UpdateMinMaxValues(RecordID, MinValue, MaxValue)
        End If
    End Sub

    Private Sub btnAddPartVanStock_Click(sender As Object, e As EventArgs) Handles btnAddPartStockProfile.Click
        Me.Cursor = Cursors.WaitCursor
        Dim LocationID As Integer = 0 ' 59 Adam Sutherland
        Dim PartID As Integer = 0 ' 499059 15ISV
        Dim MinQty As Integer = 1
        Dim MaxQty As Integer = 1

        Dim locationdv As DataView = DB.Location.Locations_Get_ForVanReg_ActiveOnly(CurrentVan.Registration)

        'PartID = FindRecord(Entity.Sys.Enums.TableNames.tblPart)
        Dim dialogue1 As FRMFindPart
        dialogue1 = checkIfExists(GetType(FRMFindPart).Name, True)
        If dialogue1 Is Nothing Then
            dialogue1 = Activator.CreateInstance(GetType(FRMFindPart))
        End If
        '  dialogue1.Icon = New Icon(dialogue1.GetType(), "Logo.ico")
        dialogue1.ShowInTaskbar = False
        dialogue1.TableToSearch = Entity.Sys.Enums.TableNames.tblPartSupplier
        dialogue1.ShowDialog()
        Dim datarows() As DataRow
        If dialogue1.DialogResult = DialogResult.OK Then
            datarows = dialogue1.Datarows
        Else
            Exit Sub
        End If
        dialogue1.Close()

        'WHICH LOCATION TO ASSIGN TO
        If locationdv.Count > 0 Then
            'LocationID = ShowForm(FRMPartSelectLocation, True, locationdv)
            Dim dialogue As FRMPartSelectLocation
            dialogue = checkIfExists(GetType(FRMPartSelectLocation).Name, True)
            If dialogue Is Nothing Then
                dialogue = Activator.CreateInstance(GetType(FRMPartSelectLocation))
            End If
            dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = False
            dialogue.LocationsDataGridView = locationdv.ToTable
            dialogue.ShowDialog()

            If dialogue.DialogResult = DialogResult.OK Then
                LocationID = dialogue.LocationID
            Else
            End If
            dialogue.Close()
        ElseIf locationdv.Count = 1 Then
            LocationID = CInt(locationdv.Table.Rows(0).Item("LocationID"))
        Else
            ShowMessage("No Locations available for this engineer, unable to proceed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If LocationID = 0 Then
            ShowMessage("No Locations selected for this part, unable to proceed, please try again", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        For Each dr As DataRow In datarows

            PartID = dr("PartID")

            Dim partAlreadyPresent As Boolean = PartsDataGridView.Select(String.Format("PartID = {0} and LocationID = {1}", dr("PartID"), LocationID)).Length > 0
            If partAlreadyPresent Then
                ShowMessage("A part has already been added and therefore cannot be added again. - " & dr("PartName"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Continue For
            End If

            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
            oPartTransaction.SetLocationID = LocationID 'row.Item("LocationID")
            oPartTransaction.SetAmount = 0
            oPartTransaction.SetPartID = PartID 'row.Item("PartID")
            oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockAdjustment)
            DB.PartTransaction.Insert(oPartTransaction)

            DB.Part.Part_Locations_Insert(PartID, LocationID, MinQty, MaxQty)

        Next

        If datarows.Length > -1 Then
            PartsDataGridView = DB.PartTransaction.GetByVan2(CurrentVan.VanID, True, False, Combo.GetSelectedItemValue(cboPreferredSupplierID))

            Dim column As DataGridViewColumn = Me.dgvParts.Columns.Item(6)
            If Not column Is Nothing Then
                Me.dgvParts.Sort(column, System.ComponentModel.ListSortDirection.Descending)
            End If

            ShowMessage("Part(s) Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnDeletePartVanStock_Click(sender As Object, e As EventArgs) Handles btnDeletePartStockProfile.Click
        Me.Cursor = Cursors.WaitCursor
        Dim rows As New ArrayList
        Dim loops As Integer = 0
        For Each c As DataGridViewCell In dgvParts.SelectedCells
            rows.Add(c.OwningRow)

        Next
        rows.Reverse()

        For Each i As DataGridViewRow In rows
            Dim LocationID As Integer = 0 ' 59 Adam Sutherland
            Dim PartID As Integer = 0 ' 499059 15ISV

            If CInt(i.Cells.Item(3).Value) > 0 Then
                ShowMessage("The part " + i.Cells.Item(2).Value + " has positive stock, please process an adjustment before deleting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                PartID = i.Cells.Item(7).Value
                LocationID = i.Cells.Item(8).Value
            End If

            If Not PartID = 0 And Not LocationID = 0 Then

                Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                oPartTransaction.SetLocationID = LocationID 'row.Item("LocationID")
                oPartTransaction.SetAmount = 0
                oPartTransaction.SetPartID = PartID 'row.Item("PartID")
                oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockAdjustment)
                DB.PartTransaction.Insert(oPartTransaction)

                DB.PartTransaction.DeleteByPartAndLocation(PartID, LocationID)

                DB.Part.Part_Locations_Delete(PartID, LocationID) '' deletes part location matrix in tblpartlocations

                'Dim column As DataGridViewColumn = Me.dgvParts.Columns.Item(6)
                'If Not column Is Nothing Then
                '    Me.dgvParts.Sort(column, System.ComponentModel.ListSortDirection.Descending)
                'End If

            End If
        Next
        PartsDataGridView = DB.PartTransaction.GetByVan2(CurrentVan.VanID, True, False, Combo.GetSelectedItemValue(cboPreferredSupplierID))
        ShowMessage("Part(s) Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvParts_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvParts.ColumnHeaderMouseClick
        Dim newColumn As DataGridViewColumn = dgvParts.Columns(e.ColumnIndex)
        Dim oldColumn As DataGridViewColumn = dgvParts.SortedColumn
        Dim direction As System.ComponentModel.ListSortDirection

        ' If oldColumn is null, then the DataGridView is not currently sorted.
        If oldColumn IsNot Nothing Then
            ' Sort the same column again, reversing the SortOrder.
            If oldColumn Is newColumn AndAlso dgvParts.SortOrder = SortOrder.Ascending Then
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
        dgvParts.Sort(newColumn, direction)
        If direction = System.ComponentModel.ListSortDirection.Ascending Then
            newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
        Else
            newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
        End If
    End Sub

    Private Sub btnClearVanStockProfile_Click(sender As Object, e As EventArgs) Handles btnClearVanStockProfile.Click
        Me.Cursor = Cursors.WaitCursor
        Dim PartAmount As Integer = 0
        Dim MinValue As Integer = 0
        Dim MaxValue As Integer = 0
        Dim PartID As Integer = 0
        Dim LocationID As Integer = 0
        Dim recordID As Integer = 0
        Dim DeletedCount As Integer = 0
        Dim ssm As Entity.Sys.Enums.SecuritySystemModules
        ssm = Entity.Sys.Enums.SecuritySystemModules.IT
        Dim ssm2 As Entity.Sys.Enums.SecuritySystemModules
        ssm2 = Entity.Sys.Enums.SecuritySystemModules.AllFeatures

        If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then
            If ShowMessage("Do you want to clear only the items with 0, 0, 0?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For Each row As DataGridViewRow In Me.dgvParts.Rows

                    PartAmount = row.Cells.Item(3).Value
                    PartID = row.Cells.Item(7).Value
                    LocationID = row.Cells.Item(8).Value
                    recordID = row.Cells.Item(6).Value
                    MinValue = row.Cells.Item(4).Value
                    MaxValue = row.Cells.Item(5).Value
                    If PartAmount = 0 And MinValue = 0 And MaxValue = 0 Then
                        If Not PartID = 0 And Not LocationID = 0 Then

                            Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                            oPartTransaction.SetLocationID = LocationID 'row.Item("LocationID")
                            oPartTransaction.SetAmount = 0
                            oPartTransaction.SetPartID = PartID 'row.Item("PartID")
                            oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockAdjustment)
                            DB.PartTransaction.Insert(oPartTransaction)

                            DB.PartTransaction.DeleteByPartAndLocation(PartID, LocationID)

                            DB.Part.Part_Locations_Delete(PartID, LocationID)
                            DeletedCount += 1
                        End If
                    End If
                Next
            Else 'clear all items
                For Each row As DataGridViewRow In Me.dgvParts.Rows

                    PartAmount = row.Cells.Item(3).Value
                    PartID = row.Cells.Item(7).Value
                    LocationID = row.Cells.Item(8).Value
                    recordID = row.Cells.Item(6).Value
                    MinValue = row.Cells.Item(4).Value
                    MaxValue = row.Cells.Item(5).Value
                    If Not PartID = 0 And Not LocationID = 0 Then

                        Dim oPartTransaction As New Entity.PartTransactions.PartTransaction
                        oPartTransaction.SetLocationID = LocationID 'row.Item("LocationID")
                        oPartTransaction.SetAmount = 0
                        oPartTransaction.SetPartID = PartID 'row.Item("PartID")
                        oPartTransaction.SetTransactionTypeID = CInt(Entity.Sys.Enums.Transaction.StockAdjustment)
                        DB.PartTransaction.Insert(oPartTransaction)

                        DB.PartTransaction.DeleteByPartAndLocation(PartID, LocationID)

                        DB.Part.Part_Locations_Delete(PartID, LocationID)
                        DeletedCount += 1
                    End If
                Next
            End If

            PartsDataGridView = DB.PartTransaction.GetByVan2(CurrentVan.VanID, True, False, Combo.GetSelectedItemValue(cboPreferredSupplierID))

            ShowMessage("Parts Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ShowMessage("This process can only be used by a member of IT or Barry Ellis", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub Export()
        Dim ssm As Entity.Sys.Enums.SecuritySystemModules
        ssm = Entity.Sys.Enums.SecuritySystemModules.IT

        Dim exportData As New DataTable
        exportData.Columns.Add("Location")
        exportData.Columns.Add("Part Name")
        exportData.Columns.Add("Part Number (MPN)")
        exportData.Columns.Add("Amount")
        exportData.Columns.Add("Min")
        exportData.Columns.Add("Max")
        If loggedInUser.HasAccessToModule(ssm) = True Then
            exportData.Columns.Add("PartID")
        End If
        exportData.Columns.Add("SPN")

        Dim drRow As DataGridViewRow

        For itm As Integer = 0 To dgvParts.Rows.Count - 1
            drRow = dgvParts.Rows(itm)
            Dim newRw As DataRow
            newRw = exportData.NewRow

            newRw("Location") = drRow.Cells(0).Value
            newRw("Part Name") = drRow.Cells(1).Value
            newRw("Part Number (MPN)") = drRow.Cells(2).Value
            newRw("Amount") = drRow.Cells(3).Value
            newRw("Min") = drRow.Cells(4).Value
            newRw("Max") = drRow.Cells(5).Value
            If loggedInUser.HasAccessToModule(ssm) = True Then
                newRw("PartID") = drRow.Cells(7).Value
            End If
            newRw("SPN") = drRow.Cells(9).Value

            exportData.Rows.Add(newRw)

            '            dgParts.UnSelect(itm)
        Next itm

        Dim exporter As New Entity.Sys.Exporting(exportData, "Van Stock Profiles")
        exporter = Nothing
    End Sub

    Private Sub btnExportStockProfile_Click(sender As Object, e As EventArgs) Handles btnExportStockProfile.Click
        Export()
    End Sub

    Private Sub btnSaveEquipment_Click(sender As Object, e As EventArgs) Handles btnSaveEquipment.Click

        Dim equipment As String = Me.txtEquipmentTool.Text.Trim
        Dim vanId As Integer = Entity.Sys.Helper.MakeIntegerValid(CurrentVan?.VanID)

        If vanId = 0 Then Exit Sub
        If String.IsNullOrWhiteSpace(equipment) Then
            ShowMessage("Tool required!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        DB.VanEquipments.Insert(vanId, equipment)
        DvEquipment = DB.VanEquipments.Get(vanId)
    End Sub

    Private Sub btnDeleteEquipment_Click(sender As Object, e As EventArgs) Handles btnDeleteEquipment.Click
        Dim vanId As Integer = Entity.Sys.Helper.MakeIntegerValid(CurrentVan?.VanID)
        If vanId = 0 Then Exit Sub
        If DrSelectedEquipment Is Nothing Then Exit Sub

        Dim id As Integer = Entity.Sys.Helper.MakeIntegerValid(DrSelectedEquipment("Id"))
        DB.VanEquipments.Delete(id)
        DvEquipment = DB.VanEquipments.Get(vanId)
    End Sub

End Class