Public Class UCPart : Inherits FSM.UCBase : Implements IUserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Combo.SetUpCombo(Me.cboUnitType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.UnitTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCategory, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboFuel, DB.Picklists.GetAll(25).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        Combo.SetUpCombo(Me.cboManufacturer, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Makes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        'Combo.SetUpCombo(Me.cboWarehouse, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        'Combo.SetUpCombo(Me.choShelf, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartShelfReferences).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        ''Combo.SetUpCombo(Me.cboBinID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartBinReferences).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        'Combo.SetUpCombo(Me.cboWarehouseAlternative, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        'Combo.SetUpCombo(Me.cboShelfAlternatuve, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartShelfReferences).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
        'Combo.SetUpCombo(Me.cboBinAlternatuve, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartBinReferences).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl

    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents tabSuppliers As System.Windows.Forms.TabPage
    Friend WithEvents grpPart As System.Windows.Forms.GroupBox
    Friend WithEvents txtSellPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboUnitType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents dgPartSuppliers As System.Windows.Forms.DataGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReference As System.Windows.Forms.TextBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents tpStock As System.Windows.Forms.TabPage
    Friend WithEvents grpStock As System.Windows.Forms.GroupBox
    Friend WithEvents dgStock As System.Windows.Forms.DataGrid
    Friend WithEvents chkEndFlagged As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tpQuantities As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgQuantities As System.Windows.Forms.DataGrid
    Friend WithEvents cboFuel As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.grpPart = New System.Windows.Forms.GroupBox()
        Me.cboFuel = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkEndFlagged = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.txtSellPrice = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboUnitType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.tabSuppliers = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.dgPartSuppliers = New System.Windows.Forms.DataGrid()
        Me.tpQuantities = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgQuantities = New System.Windows.Forms.DataGrid()
        Me.tpStock = New System.Windows.Forms.TabPage()
        Me.grpStock = New System.Windows.Forms.GroupBox()
        Me.dgStock = New System.Windows.Forms.DataGrid()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboManufacturer = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.grpPart.SuspendLayout()
        Me.tabSuppliers.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgPartSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpQuantities.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgQuantities, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpStock.SuspendLayout()
        Me.grpStock.SuspendLayout()
        CType(Me.dgStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabDetails)
        Me.TabControl1.Controls.Add(Me.tabSuppliers)
        Me.TabControl1.Controls.Add(Me.tpQuantities)
        Me.TabControl1.Controls.Add(Me.tpStock)
        Me.TabControl1.Location = New System.Drawing.Point(1, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(632, 638)
        Me.TabControl1.TabIndex = 0
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.grpPart)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Size = New System.Drawing.Size(624, 612)
        Me.tabDetails.TabIndex = 0
        Me.tabDetails.Text = "Main Details"
        '
        'grpPart
        '
        Me.grpPart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPart.Controls.Add(Me.cboManufacturer)
        Me.grpPart.Controls.Add(Me.Label6)
        Me.grpPart.Controls.Add(Me.cboFuel)
        Me.grpPart.Controls.Add(Me.Label5)
        Me.grpPart.Controls.Add(Me.chkEndFlagged)
        Me.grpPart.Controls.Add(Me.Label14)
        Me.grpPart.Controls.Add(Me.Label8)
        Me.grpPart.Controls.Add(Me.cboCategory)
        Me.grpPart.Controls.Add(Me.Label7)
        Me.grpPart.Controls.Add(Me.txtReference)
        Me.grpPart.Controls.Add(Me.txtSellPrice)
        Me.grpPart.Controls.Add(Me.Label4)
        Me.grpPart.Controls.Add(Me.cboUnitType)
        Me.grpPart.Controls.Add(Me.Label3)
        Me.grpPart.Controls.Add(Me.Label2)
        Me.grpPart.Controls.Add(Me.Label1)
        Me.grpPart.Controls.Add(Me.txtName)
        Me.grpPart.Controls.Add(Me.txtNumber)
        Me.grpPart.Controls.Add(Me.txtNotes)
        Me.grpPart.Controls.Add(Me.lblNotes)
        Me.grpPart.Location = New System.Drawing.Point(8, 8)
        Me.grpPart.Name = "grpPart"
        Me.grpPart.Size = New System.Drawing.Size(609, 595)
        Me.grpPart.TabIndex = 0
        Me.grpPart.TabStop = False
        Me.grpPart.Text = "Main Details"
        '
        'cboFuel
        '
        Me.cboFuel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboFuel.Location = New System.Drawing.Point(160, 213)
        Me.cboFuel.Name = "cboFuel"
        Me.cboFuel.Size = New System.Drawing.Size(436, 21)
        Me.cboFuel.TabIndex = 57
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 23)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Fuel"
        '
        'chkEndFlagged
        '
        Me.chkEndFlagged.Location = New System.Drawing.Point(160, 356)
        Me.chkEndFlagged.Name = "chkEndFlagged"
        Me.chkEndFlagged.Size = New System.Drawing.Size(92, 24)
        Me.chkEndFlagged.TabIndex = 17
        Me.chkEndFlagged.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 356)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(152, 24)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "End Flagged"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 21)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Category"
        '
        'cboCategory
        '
        Me.cboCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCategory.Location = New System.Drawing.Point(160, 57)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(436, 21)
        Me.cboCategory.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 21)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Reference (GPN)"
        '
        'txtReference
        '
        Me.txtReference.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReference.Location = New System.Drawing.Point(160, 120)
        Me.txtReference.MaxLength = 100
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(436, 21)
        Me.txtReference.TabIndex = 3
        Me.txtReference.Tag = "Part.Reference"
        '
        'txtSellPrice
        '
        Me.txtSellPrice.Location = New System.Drawing.Point(160, 324)
        Me.txtSellPrice.Name = "txtSellPrice"
        Me.txtSellPrice.Size = New System.Drawing.Size(104, 21)
        Me.txtSellPrice.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 323)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 23)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Sell Price"
        '
        'cboUnitType
        '
        Me.cboUnitType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboUnitType.Location = New System.Drawing.Point(160, 153)
        Me.cboUnitType.Name = "cboUnitType"
        Me.cboUnitType.Size = New System.Drawing.Size(436, 21)
        Me.cboUnitType.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 23)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Unit Type"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 21)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 21)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Number (MPN)"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(160, 26)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(436, 21)
        Me.txtName.TabIndex = 0
        Me.txtName.Tag = "Part.Name"
        '
        'txtNumber
        '
        Me.txtNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumber.Location = New System.Drawing.Point(160, 89)
        Me.txtNumber.MaxLength = 100
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(436, 21)
        Me.txtNumber.TabIndex = 2
        Me.txtNumber.Tag = "Part.Number"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(160, 413)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(436, 176)
        Me.txtNotes.TabIndex = 19
        Me.txtNotes.Tag = "Part.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 413)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(57, 21)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'tabSuppliers
        '
        Me.tabSuppliers.Controls.Add(Me.GroupBox1)
        Me.tabSuppliers.Location = New System.Drawing.Point(4, 22)
        Me.tabSuppliers.Name = "tabSuppliers"
        Me.tabSuppliers.Size = New System.Drawing.Size(624, 612)
        Me.tabSuppliers.TabIndex = 1
        Me.tabSuppliers.Text = "Suppliers"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.dgPartSuppliers)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(609, 595)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Suppliers of this part"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(537, 563)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Remove"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(8, 563)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(64, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add"
        '
        'dgPartSuppliers
        '
        Me.dgPartSuppliers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPartSuppliers.DataMember = ""
        Me.dgPartSuppliers.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgPartSuppliers.Location = New System.Drawing.Point(8, 27)
        Me.dgPartSuppliers.Name = "dgPartSuppliers"
        Me.dgPartSuppliers.Size = New System.Drawing.Size(593, 530)
        Me.dgPartSuppliers.TabIndex = 1
        '
        'tpQuantities
        '
        Me.tpQuantities.Controls.Add(Me.GroupBox2)
        Me.tpQuantities.Location = New System.Drawing.Point(4, 22)
        Me.tpQuantities.Name = "tpQuantities"
        Me.tpQuantities.Padding = New System.Windows.Forms.Padding(3)
        Me.tpQuantities.Size = New System.Drawing.Size(624, 612)
        Me.tpQuantities.TabIndex = 3
        Me.tpQuantities.Text = "Min / Max Quantities"
        Me.tpQuantities.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.dgQuantities)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(609, 595)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Min /Max quantities held per location"
        '
        'dgQuantities
        '
        Me.dgQuantities.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgQuantities.DataMember = ""
        Me.dgQuantities.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgQuantities.Location = New System.Drawing.Point(8, 20)
        Me.dgQuantities.Name = "dgQuantities"
        Me.dgQuantities.Size = New System.Drawing.Size(593, 569)
        Me.dgQuantities.TabIndex = 1
        '
        'tpStock
        '
        Me.tpStock.Controls.Add(Me.grpStock)
        Me.tpStock.Location = New System.Drawing.Point(4, 22)
        Me.tpStock.Name = "tpStock"
        Me.tpStock.Padding = New System.Windows.Forms.Padding(3)
        Me.tpStock.Size = New System.Drawing.Size(624, 612)
        Me.tpStock.TabIndex = 2
        Me.tpStock.Text = "Stock Locations"
        Me.tpStock.UseVisualStyleBackColor = True
        '
        'grpStock
        '
        Me.grpStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStock.Controls.Add(Me.dgStock)
        Me.grpStock.Location = New System.Drawing.Point(8, 9)
        Me.grpStock.Name = "grpStock"
        Me.grpStock.Size = New System.Drawing.Size(609, 595)
        Me.grpStock.TabIndex = 2
        Me.grpStock.TabStop = False
        Me.grpStock.Text = "Locations of this part"
        '
        'dgStock
        '
        Me.dgStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgStock.DataMember = ""
        Me.dgStock.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStock.Location = New System.Drawing.Point(8, 20)
        Me.dgStock.Name = "dgStock"
        Me.dgStock.Size = New System.Drawing.Size(593, 569)
        Me.dgStock.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 21)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Manufacturer"
        '
        'cboManufacturer
        '
        Me.cboManufacturer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboManufacturer.Location = New System.Drawing.Point(160, 183)
        Me.cboManufacturer.Name = "cboManufacturer"
        Me.cboManufacturer.Size = New System.Drawing.Size(436, 21)
        Me.cboManufacturer.TabIndex = 61
        '
        'UCPart
        '
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "UCPart"
        Me.Size = New System.Drawing.Size(640, 648)
        Me.TabControl1.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.grpPart.ResumeLayout(False)
        Me.grpPart.PerformLayout()
        Me.tabSuppliers.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgPartSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpQuantities.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgQuantities, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpStock.ResumeLayout(False)
        Me.grpStock.ResumeLayout(False)
        CType(Me.dgStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupSuppliersDatagrid()
        SetupStockDatagrid()
        SetupQuantityDatagrid()
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentPart
        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged

    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    Private _FromOrder As Boolean

    Public Property FromOrder() As Boolean
        Get
            Return _FromOrder
        End Get
        Set(ByVal Value As Boolean)
            _FromOrder = Value
        End Set
    End Property

    Private _partSupplierDataview As DataView = Nothing

    Public Property PartSuppliersDataView() As DataView
        Get
            Return _partSupplierDataview
        End Get
        Set(ByVal Value As DataView)
            _partSupplierDataview = Value
            _partSupplierDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
            _partSupplierDataview.AllowNew = False
            _partSupplierDataview.AllowEdit = True
            _partSupplierDataview.AllowDelete = False
            Me.dgPartSuppliers.DataSource = PartSuppliersDataView
        End Set
    End Property

    Private ReadOnly Property SelectedPartSupplierDataRow() As DataRow
        Get
            If Not Me.dgPartSuppliers.CurrentRowIndex = -1 Then
                Return PartSuppliersDataView(Me.dgPartSuppliers.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _StockDataview As DataView = Nothing

    Public Property StockDataview() As DataView
        Get
            Return _StockDataview
        End Get
        Set(ByVal Value As DataView)
            _StockDataview = Value
            _StockDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString
            _StockDataview.AllowNew = False
            _StockDataview.AllowEdit = True
            _StockDataview.AllowDelete = False
            Me.dgStock.DataSource = StockDataview
        End Set
    End Property

    Private _currentPart As Entity.Parts.Part

    Public Property CurrentPart() As Entity.Parts.Part
        Get
            Return _currentPart
        End Get
        Set(ByVal Value As Entity.Parts.Part)
            _currentPart = Value

            If CurrentPart Is Nothing Then
                CurrentPart = New Entity.Parts.Part
                CurrentPart.Exists = False
                Me.btnAdd.Enabled = False
                Me.btnDelete.Enabled = False
            End If

            If CurrentPart.Exists Then
                Populate()
                Me.btnAdd.Enabled = True
                Me.btnDelete.Enabled = True
            Else
                'Bin = Nothing
                'BinAlternative = Nothing
                'Me.txtMinimumQuantity.Text = "0"
                'Me.txtRecommendedQuantity.Text = "0"
            End If

            PopulateSuppliers()
            PopulateStock()
            PopulateQuantities()
        End Set
    End Property

    Private _partQuantitiesDataview As DataView = Nothing

    Public Property PartQuantitiesDataview() As DataView
        Get
            Return _partQuantitiesDataview
        End Get
        Set(ByVal Value As DataView)
            _partQuantitiesDataview = Value
            _partQuantitiesDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString
            _partQuantitiesDataview.AllowNew = False
            _partQuantitiesDataview.AllowEdit = True
            _partQuantitiesDataview.AllowDelete = False
            Me.dgQuantities.DataSource = PartQuantitiesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedPartQuantityDataRow() As DataRow
        Get
            If Not Me.dgQuantities.CurrentRowIndex = -1 Then
                Return PartQuantitiesDataview(Me.dgQuantities.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    'Private _Bin As Entity.PickLists.PickList
    'Public Property Bin() As Entity.PickLists.PickList
    '    Get
    '        Return _Bin
    '    End Get
    '    Set(ByVal Value As Entity.PickLists.PickList)
    '        _Bin = Value

    '        If Bin Is Nothing Then
    '            Me.txtBin.Text = "Not Applicable"
    '        Else
    '            Me.txtBin.Text = Bin.Name
    '        End If
    '    End Set
    'End Property

    'Private _BinAlternative As Entity.PickLists.PickList
    'Public Property BinAlternative() As Entity.PickLists.PickList
    '    Get
    '        Return _BinAlternative
    '    End Get
    '    Set(ByVal Value As Entity.PickLists.PickList)
    '        _BinAlternative = Value

    '        If BinAlternative Is Nothing Then
    '            Me.txtBinAlternative.Text = "Not Applicable"
    '        Else
    '            Me.txtBinAlternative.Text = BinAlternative.Name
    '        End If
    '    End Set
    'End Property

#End Region

#Region "Setup"

    Public Sub SetupSuppliersDatagrid()

        Entity.Sys.Helper.SetUpDataGrid(Me.dgPartSuppliers)
        Dim tStyle As DataGridTableStyle = Me.dgPartSuppliers.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Me.dgPartSuppliers.ReadOnly = False
        Me.dgPartSuppliers.AllowSorting = False
        tStyle.ReadOnly = False

        Dim Preferred As New DataGridBoolColumn
        Preferred.HeaderText = "Preferred"
        Preferred.MappingName = "Preferred"
        Preferred.ReadOnly = False
        Preferred.Width = 25
        Preferred.NullText = ""
        tStyle.GridColumnStyles.Add(Preferred)

        Dim SupplierName As New DataGridLabelColumn
        SupplierName.Format = ""
        SupplierName.FormatInfo = Nothing
        SupplierName.HeaderText = "Supplier"
        SupplierName.MappingName = "SupplierName"
        SupplierName.ReadOnly = True
        SupplierName.Width = 130
        SupplierName.NullText = ""
        tStyle.GridColumnStyles.Add(SupplierName)

        Dim PartCode As New DataGridLabelColumn
        PartCode.Format = ""
        PartCode.FormatInfo = Nothing
        PartCode.HeaderText = "Supplier Part Code (SPN)"
        PartCode.MappingName = "PartCode"
        PartCode.ReadOnly = True
        PartCode.Width = 130
        PartCode.NullText = ""
        tStyle.GridColumnStyles.Add(PartCode)

        Dim Price As New DataGridLabelColumn
        Price.Format = "C"
        Price.FormatInfo = Nothing
        Price.HeaderText = "Supplier Price"
        Price.MappingName = "Price"
        Price.ReadOnly = True
        Price.Width = 85
        Price.NullText = ""
        tStyle.GridColumnStyles.Add(Price)

        Dim QuantityInPack As New DataGridLabelColumn
        QuantityInPack.Format = ""
        QuantityInPack.FormatInfo = Nothing
        QuantityInPack.HeaderText = "Quantity In Pack"
        QuantityInPack.MappingName = "QuantityInPack"
        QuantityInPack.ReadOnly = True
        QuantityInPack.Width = 110
        QuantityInPack.NullText = ""
        tStyle.GridColumnStyles.Add(QuantityInPack)

        Dim UpdatedBy As New DataGridLabelColumn
        UpdatedBy.Format = ""
        UpdatedBy.FormatInfo = Nothing
        UpdatedBy.HeaderText = "Updated By"
        UpdatedBy.MappingName = "UpdatedBy"
        UpdatedBy.ReadOnly = True
        UpdatedBy.Width = 150
        UpdatedBy.NullText = ""
        tStyle.GridColumnStyles.Add(UpdatedBy)

        Dim UpdatedOn As New DataGridLabelColumn
        UpdatedOn.Format = "dd/MM/yyyy HH:mm:ss"
        UpdatedOn.FormatInfo = Nothing
        UpdatedOn.HeaderText = "Updated On"
        UpdatedOn.MappingName = "UpdatedOn"
        UpdatedOn.ReadOnly = True
        UpdatedOn.Width = 150
        UpdatedOn.NullText = ""
        tStyle.GridColumnStyles.Add(UpdatedOn)

        Dim primaryPriceUpdated As New DataGridLabelColumn
        primaryPriceUpdated.Format = "dd/MM/yyyy"
        primaryPriceUpdated.FormatInfo = Nothing
        primaryPriceUpdated.HeaderText = "Primary Price Updated On"
        primaryPriceUpdated.MappingName = "PrimaryPriceUpdateDateTime"
        primaryPriceUpdated.ReadOnly = True
        primaryPriceUpdated.Width = 150
        primaryPriceUpdated.NullText = ""
        tStyle.GridColumnStyles.Add(primaryPriceUpdated)

        Dim secondaryPriceUpdated As New DataGridLabelColumn
        secondaryPriceUpdated.Format = "dd/MM/yyyy"
        secondaryPriceUpdated.FormatInfo = Nothing
        secondaryPriceUpdated.HeaderText = "Secondary Price Updated On"
        secondaryPriceUpdated.MappingName = "SecondaryPriceUpdateDateTime"
        secondaryPriceUpdated.ReadOnly = True
        secondaryPriceUpdated.Width = 150
        secondaryPriceUpdated.NullText = ""
        tStyle.GridColumnStyles.Add(secondaryPriceUpdated)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
        Me.dgPartSuppliers.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupStockDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgStock)
        Dim tStyle As DataGridTableStyle = Me.dgStock.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 100
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 200
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim Qty As New DataGridLabelColumn
        Qty.Format = ""
        Qty.FormatInfo = Nothing
        Qty.HeaderText = "Qty"
        Qty.MappingName = "Quantity"
        Qty.ReadOnly = True
        Qty.Width = 100
        Qty.NullText = ""
        tStyle.GridColumnStyles.Add(Qty)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblStock.ToString
        Me.dgStock.TableStyles.Add(tStyle)
    End Sub

    Public Sub SetupQuantityDatagrid()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgQuantities)
        Dim tStyle As DataGridTableStyle = Me.dgQuantities.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        tStyle.ReadOnly = False
        tStyle.AllowSorting = False
        Me.dgQuantities.AllowSorting = False
        Me.dgQuantities.ReadOnly = False

        Dim Location As New DataGridLabelColumn
        Location.Format = ""
        Location.FormatInfo = Nothing
        Location.HeaderText = "Location"
        Location.MappingName = "Location"
        Location.ReadOnly = True
        Location.Width = 250
        Location.NullText = ""
        tStyle.GridColumnStyles.Add(Location)

        Dim MinQty As New DataGridEditableTextBoxColumn
        MinQty.Format = ""
        MinQty.FormatInfo = Nothing
        MinQty.HeaderText = "Minimum"
        MinQty.MappingName = "MinQty"
        MinQty.ReadOnly = False
        MinQty.Width = 75
        MinQty.NullText = ""
        MinQty.BackColourBrush = Brushes.LightYellow
        tStyle.GridColumnStyles.Add(MinQty)

        Dim RecQty As New DataGridEditableTextBoxColumn
        RecQty.Format = ""
        RecQty.FormatInfo = Nothing
        RecQty.HeaderText = "Maximum"
        RecQty.MappingName = "RecQty"
        RecQty.ReadOnly = False
        RecQty.Width = 75
        RecQty.NullText = ""
        RecQty.BackColourBrush = Brushes.LightYellow
        tStyle.GridColumnStyles.Add(RecQty)

        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString
        Me.dgQuantities.TableStyles.Add(tStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub UCPart_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub

    Private Sub dgPartSuppliers_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgPartSuppliers.MouseUp
        Try
            Dim HitTestInfo As DataGrid.HitTestInfo
            HitTestInfo = dgPartSuppliers.HitTest(e.X, e.Y)
            If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
                dgPartSuppliers.CurrentRowIndex = HitTestInfo.Row()
            End If

            If Not HitTestInfo.Column = 0 Then
                Exit Sub
            End If
            If SelectedPartSupplierDataRow Is Nothing Then
                Exit Sub
            End If

            Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(Me.dgPartSuppliers(Me.dgPartSuppliers.CurrentRowIndex, 0))

            DB.PartSupplier.Update_Preferred(SelectedPartSupplierDataRow.Item("PartSupplierID"), selected)

            PartSuppliersDataView = DB.PartSupplier.Get_ByPartID(CurrentPart.PartID)
        Catch ex As Exception
            ShowMessage("Cannot change tick state : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgPartSuppliers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgPartSuppliers.DoubleClick
        If SelectedPartSupplierDataRow Is Nothing Then
            Exit Sub
        End If

        ShowForm(GetType(FRMPartSupplier), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedPartSupplierDataRow.Item("PartSupplierID")), CurrentPart.PartID, Me})
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim ssm As Entity.Sys.Enums.SecuritySystemModules
        ssm = Entity.Sys.Enums.SecuritySystemModules.EditParts
        Dim ssm2 As Entity.Sys.Enums.SecuritySystemModules
        ssm2 = Entity.Sys.Enums.SecuritySystemModules.CreateParts
        If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then ShowForm(GetType(FRMPartSupplier), True, New Object() {0, CurrentPart.PartID, Me})
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If SelectedPartSupplierDataRow Is Nothing Then
            ShowMessage("Please select a supplier to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim ssm As Entity.Sys.Enums.SecuritySystemModules
        ssm = Entity.Sys.Enums.SecuritySystemModules.EditParts
        Dim ssm2 As Entity.Sys.Enums.SecuritySystemModules
        ssm2 = Entity.Sys.Enums.SecuritySystemModules.CreateParts
        If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then

            'If EnterOverridePassword() = True Then
            'Check if part is on an order i.e in tblOrderPart
            Dim OrderedCount As Integer = DB.ExecuteScalar("SELECT COUNT(*) AS Expr1 FROM tblOrderPart WHERE (PartSupplierID = " & SelectedPartSupplierDataRow.Item("PartSupplierID") & ") AND (EngineerReceivedOn IS NULL) AND (Deleted = 0)")
            'If OrderedCount > 0 Then
            '    If ShowMessage("This part has been ordered and not received by an engineer and therefore cannot be deleted", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
            '        Exit Sub
            '    Else
            '        Exit Sub
            '    End If
            'End If
            If ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            DB.PartSupplier.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedPartSupplierDataRow.Item("PartSupplierID")))
            PartSuppliersDataView = DB.PartSupplier.Get_ByPartID(CurrentPart.PartID)
            'End If
        Else
            Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
            msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
            Throw New Security.SecurityException(msg)
            Exit Sub
        End If
    End Sub

    'Private Sub btnBin_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN)
    '    If ID = 0 Then
    '        Bin = Nothing
    '    Else
    '        Bin = DB.Picklists.Get_One_As_Object(ID)
    '    End If
    'End Sub

    'Private Sub btnBinAlternative_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN)
    '    If ID = 0 Then
    '        BinAlternative = Nothing
    '    Else
    '        BinAlternative = DB.Picklists.Get_One_As_Object(ID)
    '    End If
    'End Sub

#End Region

#Region "Functions"

    Public Sub PopulateSuppliers()
        PartSuppliersDataView = DB.PartSupplier.Get_ByPartID(CurrentPart.PartID)
    End Sub

    Public Sub PopulateStock()
        StockDataview = DB.Part.Stock_Get_Locations(CurrentPart.PartID)
    End Sub

    Public Sub PopulateQuantities()
        PartQuantitiesDataview = DB.Part.Part_Locations_Get(CurrentPart.PartID)
    End Sub

    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            CurrentPart = DB.Part.Part_Get(ID)
        End If

        Me.txtName.Text = CurrentPart.Name
        Me.txtNumber.Text = CurrentPart.Number
        Me.txtReference.Text = CurrentPart.Reference
        Me.txtNotes.Text = CurrentPart.Notes
        'Me.txtMinimumQuantity.Text = CurrentPart.MinimumQuantity
        'Me.txtRecommendedQuantity.Text = CurrentPart.RecommendedQuantity
        'Me.txtWarehouseQuantity.Text = CurrentPart.WarehouseQuantity
        Me.txtSellPrice.Text = CurrentPart.SellPrice
        Combo.SetSelectedComboItem_By_Value(Me.cboUnitType, CurrentPart.UnitTypeID)
        Combo.SetSelectedComboItem_By_Value(Me.cboCategory, CurrentPart.CategoryID)
        Combo.SetSelectedComboItem_By_Value(Me.cboFuel, CurrentPart.FuelID)
        Combo.SetSelectedComboItem_By_Value(Me.cboManufacturer, CurrentPart.MakeID)
        'Combo.SetSel  Combo.SetSelectedComboItem_By_Value(Me.cboCategory, CurrentPart.CategoryID)ectedComboItem_By_Value(Me.cboWarehouse, CurrentPart.WarehouseID)
        'Combo.SetSelectedComboItem_By_Value(Me.choShelf, CurrentPart.ShelfID)
        'If CurrentPart.BinID = 0 Then
        '    Bin = Nothing
        'Else
        '    Bin = DB.Picklists.Get_One_As_Object(CurrentPart.BinID)
        'End If
        'Combo.SetSelectedComboItem_By_Value(Me.cboBinID, CurrentPart.BinID)
        'Combo.SetSelectedComboItem_By_Value(Me.cboWarehouseAlternative, CurrentPart.WarehouseIDAlternative)
        'Combo.SetSelectedComboItem_By_Value(Me.cboShelfAlternatuve, CurrentPart.ShelfIDAlternative)
        'If CurrentPart.BinIDAlternative = 0 Then
        '    BinAlternative = Nothing
        'Else
        '    BinAlternative = DB.Picklists.Get_One_As_Object(CurrentPart.BinIDAlternative)
        'End If
        'Combo.SetSelectedComboItem_By_Value(Me.cboBinAlternatuve, CurrentPart.BinIDAlternative)
        Me.chkEndFlagged.Checked = CurrentPart.EndFlagged
        '   Me.chkEquipment.Checked = CurrentPart.Equipment
        AddChangeHandlers(Me)
        ControlChanged = False
        ControlLoading = False
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            Dim PerformSave As Boolean = False
            Dim ssm As Entity.Sys.Enums.SecuritySystemModules
            ssm = Entity.Sys.Enums.SecuritySystemModules.EditParts
            Dim ssm2 As Entity.Sys.Enums.SecuritySystemModules
            ssm2 = Entity.Sys.Enums.SecuritySystemModules.CreateParts
            If loggedInUser.HasAccessToModule(ssm) = True Or loggedInUser.HasAccessToModule(ssm2) = True Then
                PerformSave = True
            Else
                Dim msg As String = "You do not have the necessary security permissions to access this feature." & vbCrLf
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing."
                Throw New Security.SecurityException(msg)
                Return False
            End If

            If PerformSave Then
                Me.Cursor = Cursors.WaitCursor
                CurrentPart.IgnoreExceptionsOnSetMethods = True

                CurrentPart.SetName = Me.txtName.Text.Trim
                CurrentPart.SetNumber = Me.txtNumber.Text.Trim
                CurrentPart.SetReference = Me.txtReference.Text.Trim
                CurrentPart.SetNotes = Me.txtNotes.Text.Trim
                CurrentPart.SetUnitTypeID = Combo.GetSelectedItemValue(Me.cboUnitType)
                CurrentPart.SetSellPrice = Me.txtSellPrice.Text.Trim
                '    CurrentPart.SetMinimumQuantity = Me.txtMinimumQuantity.Text.Trim
                '    CurrentPart.SetRecommendedQuantity = Me.txtRecommendedQuantity.Text.Trim
                CurrentPart.SetCategoryID = Combo.GetSelectedItemValue(Me.cboCategory)
                CurrentPart.SetMakeID = Combo.GetSelectedItemValue(Me.cboManufacturer)
                CurrentPart.SetFuelID = Combo.GetSelectedItemValue(Me.cboFuel)
                '    CurrentPart.SetWarehouseID = Combo.GetSelectedItemValue(Me.cboWarehouse)
                '    CurrentPart.SetShelfID = Combo.GetSelectedItemValue(Me.choShelf)
                'If Bin Is Nothing Then
                '    CurrentPart.SetBinID = 0
                'Else
                '    CurrentPart.SetBinID = Bin.ManagerID
                'End If
                'CurrentPart.SetBinID = Combo.GetSelectedItemValue(Me.cboBinID)
                '   CurrentPart.SetWarehouseIDAlternative = Combo.GetSelectedItemValue(Me.cboWarehouseAlternative)
                '  CurrentPart.SetShelfIDAlternative = Combo.GetSelectedItemValue(Me.cboShelfAlternatuve)
                'If BinAlternative Is Nothing Then
                '    CurrentPart.SetBinIDAlternative = 0
                'Else
                '    CurrentPart.SetBinIDAlternative = BinAlternative.ManagerID
                'End If
                'CurrentPart.SetBinIDAlternative = Combo.GetSelectedItemValue(Me.cboBinAlternatuve)
                CurrentPart.SetEndFlagged = Me.chkEndFlagged.Checked

                '     CurrentPart.SetEquipment = Me.chkEquipment.Checked

                Dim cV As New Entity.Parts.PartValidator
                cV.Validate(CurrentPart)

                If CurrentPart.Exists Then
                    DB.Part.Update(CurrentPart)

                    DB.Part.Part_Locations_Update(CurrentPart.PartID, PartQuantitiesDataview)

                    DB.Picklists.UpdateSellPricesByPart(CurrentPart.CategoryID, CurrentPart.PartID)
                Else
                    CurrentPart = DB.Part.Insert(CurrentPart)
                End If

                If FromOrder = False Then
                    'RaiseEvent RecordsChanged(DB.Part.Part_GetAll(), Entity.Sys.Enums.PageViewing.Part, True, False, "")    --- RD
                    'MainForm.RefreshEntity(CurrentPart.PartID)
                End If

                RaiseEvent StateChanged(CurrentPart.PartID)

                Return True
            End If
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Return False
        Catch ex As Exception
            ShowMessage("Data cannot save : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

#End Region

End Class