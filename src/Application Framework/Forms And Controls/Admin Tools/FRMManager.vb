Public Class FRMManager : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpItems As System.Windows.Forms.GroupBox

    Friend WithEvents dgManager As System.Windows.Forms.DataGrid
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents tabSystemSettings As System.Windows.Forms.TabControl
    Friend WithEvents tabPrefix As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCalloutPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtMiscPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtPPMPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtQuotePrefix As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveSettings As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cboWorkingHoursEnd As System.Windows.Forms.ComboBox
    Friend WithEvents cboWorkingHoursStart As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblTimeSlot As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtRatesMarkup As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPartsMarkup As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMileageRate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tabCharges As System.Windows.Forms.TabPage
    Friend WithEvents tabInvoicePrefix As System.Windows.Forms.TabPage
    Friend WithEvents txtInvoicePrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPercentageRate As System.Windows.Forms.TextBox
    Friend WithEvents lblPercentageRate As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRecallVariable As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tabImportSettings As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPartsImportMarkup As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceFromLetterPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkMandatory As System.Windows.Forms.CheckBox
    Friend WithEvents cboTimeSlot As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpItems = New System.Windows.Forms.GroupBox()
        Me.dgManager = New System.Windows.Forms.DataGrid()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.chkMandatory = New System.Windows.Forms.CheckBox()
        Me.txtPercentageRate = New System.Windows.Forms.TextBox()
        Me.lblPercentageRate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpSettings = New System.Windows.Forms.GroupBox()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.tabSystemSettings = New System.Windows.Forms.TabControl()
        Me.tabImportSettings = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPartsImportMarkup = New System.Windows.Forms.TextBox()
        Me.tabCharges = New System.Windows.Forms.TabPage()
        Me.txtRatesMarkup = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPartsMarkup = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMileageRate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabPrefix = New System.Windows.Forms.TabPage()
        Me.txtServiceFromLetterPrefix = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtQuotePrefix = New System.Windows.Forms.TextBox()
        Me.txtPPMPrefix = New System.Windows.Forms.TextBox()
        Me.txtMiscPrefix = New System.Windows.Forms.TextBox()
        Me.txtCalloutPrefix = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cboTimeSlot = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTimeSlot = New System.Windows.Forms.Label()
        Me.cboWorkingHoursEnd = New System.Windows.Forms.ComboBox()
        Me.cboWorkingHoursStart = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tabInvoicePrefix = New System.Windows.Forms.TabPage()
        Me.txtInvoicePrefix = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRecallVariable = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grpItems.SuspendLayout()
        CType(Me.dgManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetails.SuspendLayout()
        Me.grpSettings.SuspendLayout()
        Me.tabSystemSettings.SuspendLayout()
        Me.tabImportSettings.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tabCharges.SuspendLayout()
        Me.tabPrefix.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tabInvoicePrefix.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpItems
        '
        Me.grpItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpItems.Controls.Add(Me.dgManager)
        Me.grpItems.Controls.Add(Me.btnAddNew)
        Me.grpItems.Controls.Add(Me.btnDelete)
        Me.grpItems.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpItems.Location = New System.Drawing.Point(8, 72)
        Me.grpItems.Name = "grpItems"
        Me.grpItems.Size = New System.Drawing.Size(368, 416)
        Me.grpItems.TabIndex = 5
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "Items"
        '
        'dgManager
        '
        Me.dgManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgManager.DataMember = ""
        Me.dgManager.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgManager.Location = New System.Drawing.Point(8, 53)
        Me.dgManager.Name = "dgManager"
        Me.dgManager.Size = New System.Drawing.Size(352, 355)
        Me.dgManager.TabIndex = 3
        '
        'btnAddNew
        '
        Me.btnAddNew.AccessibleDescription = "Add new item"
        Me.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNew.Location = New System.Drawing.Point(8, 24)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(48, 23)
        Me.btnAddNew.TabIndex = 2
        Me.btnAddNew.Text = "New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "Delete item"
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Location = New System.Drawing.Point(312, 24)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(48, 23)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select Type"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboType.DisplayMember = "Description"
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(88, 45)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(288, 21)
        Me.cboType.TabIndex = 1
        Me.cboType.ValueMember = "Value"
        '
        'grpDetails
        '
        Me.grpDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetails.Controls.Add(Me.chkMandatory)
        Me.grpDetails.Controls.Add(Me.txtPercentageRate)
        Me.grpDetails.Controls.Add(Me.lblPercentageRate)
        Me.grpDetails.Controls.Add(Me.Label3)
        Me.grpDetails.Controls.Add(Me.txtName)
        Me.grpDetails.Controls.Add(Me.txtDescription)
        Me.grpDetails.Controls.Add(Me.Label2)
        Me.grpDetails.Controls.Add(Me.btnSave)
        Me.grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpDetails.Location = New System.Drawing.Point(384, 40)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(392, 216)
        Me.grpDetails.TabIndex = 7
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Details"
        '
        'chkMandatory
        '
        Me.chkMandatory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkMandatory.AutoSize = True
        Me.chkMandatory.Location = New System.Drawing.Point(208, 188)
        Me.chkMandatory.Name = "chkMandatory"
        Me.chkMandatory.Size = New System.Drawing.Size(86, 17)
        Me.chkMandatory.TabIndex = 10
        Me.chkMandatory.Text = "Mandatory"
        Me.chkMandatory.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMandatory.UseVisualStyleBackColor = True
        '
        'txtPercentageRate
        '
        Me.txtPercentageRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPercentageRate.Location = New System.Drawing.Point(104, 184)
        Me.txtPercentageRate.MaxLength = 255
        Me.txtPercentageRate.Name = "txtPercentageRate"
        Me.txtPercentageRate.Size = New System.Drawing.Size(87, 21)
        Me.txtPercentageRate.TabIndex = 9
        Me.txtPercentageRate.Visible = False
        '
        'lblPercentageRate
        '
        Me.lblPercentageRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPercentageRate.Location = New System.Drawing.Point(6, 184)
        Me.lblPercentageRate.Name = "lblPercentageRate"
        Me.lblPercentageRate.Size = New System.Drawing.Size(72, 21)
        Me.lblPercentageRate.TabIndex = 8
        Me.lblPercentageRate.Text = "Rate (%)"
        Me.lblPercentageRate.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Description"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(104, 24)
        Me.txtName.MaxLength = 255
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(280, 21)
        Me.txtName.TabIndex = 5
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Location = New System.Drawing.Point(104, 56)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(280, 120)
        Me.txtDescription.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Name"
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "Save item"
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ImageIndex = 1
        Me.btnSave.Location = New System.Drawing.Point(336, 184)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(48, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grpSettings
        '
        Me.grpSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSettings.Controls.Add(Me.btnSaveSettings)
        Me.grpSettings.Controls.Add(Me.tabSystemSettings)
        Me.grpSettings.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSettings.Location = New System.Drawing.Point(384, 256)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(392, 232)
        Me.grpSettings.TabIndex = 11
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "System Settings"
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.AccessibleDescription = "Save system settings"
        Me.btnSaveSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveSettings.ImageIndex = 1
        Me.btnSaveSettings.Location = New System.Drawing.Point(336, 200)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(48, 23)
        Me.btnSaveSettings.TabIndex = 20
        Me.btnSaveSettings.Text = "Save"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'tabSystemSettings
        '
        Me.tabSystemSettings.Controls.Add(Me.tabImportSettings)
        Me.tabSystemSettings.Controls.Add(Me.tabCharges)
        Me.tabSystemSettings.Controls.Add(Me.tabPrefix)
        Me.tabSystemSettings.Controls.Add(Me.TabPage1)
        Me.tabSystemSettings.Controls.Add(Me.tabInvoicePrefix)
        Me.tabSystemSettings.Controls.Add(Me.TabPage2)
        Me.tabSystemSettings.Location = New System.Drawing.Point(8, 24)
        Me.tabSystemSettings.Name = "tabSystemSettings"
        Me.tabSystemSettings.SelectedIndex = 0
        Me.tabSystemSettings.Size = New System.Drawing.Size(376, 170)
        Me.tabSystemSettings.TabIndex = 0
        '
        'tabImportSettings
        '
        Me.tabImportSettings.Controls.Add(Me.GroupBox2)
        Me.tabImportSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabImportSettings.Name = "tabImportSettings"
        Me.tabImportSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tabImportSettings.Size = New System.Drawing.Size(368, 144)
        Me.tabImportSettings.TabIndex = 5
        Me.tabImportSettings.Text = "Import Settings"
        Me.tabImportSettings.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPartsImportMarkup)
        Me.GroupBox2.Location = New System.Drawing.Point(5, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 132)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Part Import Markup"
        '
        'txtPartsImportMarkup
        '
        Me.txtPartsImportMarkup.Location = New System.Drawing.Point(6, 20)
        Me.txtPartsImportMarkup.Name = "txtPartsImportMarkup"
        Me.txtPartsImportMarkup.Size = New System.Drawing.Size(119, 21)
        Me.txtPartsImportMarkup.TabIndex = 0
        '
        'tabCharges
        '
        Me.tabCharges.Controls.Add(Me.txtRatesMarkup)
        Me.tabCharges.Controls.Add(Me.Label13)
        Me.tabCharges.Controls.Add(Me.txtPartsMarkup)
        Me.tabCharges.Controls.Add(Me.Label12)
        Me.tabCharges.Controls.Add(Me.txtMileageRate)
        Me.tabCharges.Controls.Add(Me.Label4)
        Me.tabCharges.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCharges.Location = New System.Drawing.Point(4, 22)
        Me.tabCharges.Name = "tabCharges"
        Me.tabCharges.Size = New System.Drawing.Size(368, 144)
        Me.tabCharges.TabIndex = 0
        Me.tabCharges.Text = "Charges"
        Me.tabCharges.UseVisualStyleBackColor = True
        '
        'txtRatesMarkup
        '
        Me.txtRatesMarkup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRatesMarkup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRatesMarkup.Location = New System.Drawing.Point(152, 72)
        Me.txtRatesMarkup.Name = "txtRatesMarkup"
        Me.txtRatesMarkup.Size = New System.Drawing.Size(208, 21)
        Me.txtRatesMarkup.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(144, 23)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Rates Markup"
        '
        'txtPartsMarkup
        '
        Me.txtPartsMarkup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPartsMarkup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartsMarkup.Location = New System.Drawing.Point(152, 40)
        Me.txtPartsMarkup.Name = "txtPartsMarkup"
        Me.txtPartsMarkup.Size = New System.Drawing.Size(208, 21)
        Me.txtPartsMarkup.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 23)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Parts Markup"
        '
        'txtMileageRate
        '
        Me.txtMileageRate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMileageRate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMileageRate.Location = New System.Drawing.Point(152, 8)
        Me.txtMileageRate.Name = "txtMileageRate"
        Me.txtMileageRate.Size = New System.Drawing.Size(208, 21)
        Me.txtMileageRate.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 23)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Mileage Rate:"
        '
        'tabPrefix
        '
        Me.tabPrefix.Controls.Add(Me.txtServiceFromLetterPrefix)
        Me.tabPrefix.Controls.Add(Me.Label7)
        Me.tabPrefix.Controls.Add(Me.txtQuotePrefix)
        Me.tabPrefix.Controls.Add(Me.txtPPMPrefix)
        Me.tabPrefix.Controls.Add(Me.txtMiscPrefix)
        Me.tabPrefix.Controls.Add(Me.txtCalloutPrefix)
        Me.tabPrefix.Controls.Add(Me.Label11)
        Me.tabPrefix.Controls.Add(Me.Label10)
        Me.tabPrefix.Controls.Add(Me.Label9)
        Me.tabPrefix.Controls.Add(Me.Label8)
        Me.tabPrefix.Location = New System.Drawing.Point(4, 22)
        Me.tabPrefix.Name = "tabPrefix"
        Me.tabPrefix.Size = New System.Drawing.Size(368, 144)
        Me.tabPrefix.TabIndex = 1
        Me.tabPrefix.Text = "Job Prefixes"
        Me.tabPrefix.UseVisualStyleBackColor = True
        '
        'txtServiceFromLetterPrefix
        '
        Me.txtServiceFromLetterPrefix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServiceFromLetterPrefix.Location = New System.Drawing.Point(174, 116)
        Me.txtServiceFromLetterPrefix.MaxLength = 4
        Me.txtServiceFromLetterPrefix.Name = "txtServiceFromLetterPrefix"
        Me.txtServiceFromLetterPrefix.Size = New System.Drawing.Size(186, 21)
        Me.txtServiceFromLetterPrefix.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 23)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Service From Letter Prefix:"
        '
        'txtQuotePrefix
        '
        Me.txtQuotePrefix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuotePrefix.Location = New System.Drawing.Point(174, 89)
        Me.txtQuotePrefix.MaxLength = 4
        Me.txtQuotePrefix.Name = "txtQuotePrefix"
        Me.txtQuotePrefix.Size = New System.Drawing.Size(186, 21)
        Me.txtQuotePrefix.TabIndex = 16
        '
        'txtPPMPrefix
        '
        Me.txtPPMPrefix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPPMPrefix.Location = New System.Drawing.Point(174, 62)
        Me.txtPPMPrefix.MaxLength = 4
        Me.txtPPMPrefix.Name = "txtPPMPrefix"
        Me.txtPPMPrefix.Size = New System.Drawing.Size(186, 21)
        Me.txtPPMPrefix.TabIndex = 15
        '
        'txtMiscPrefix
        '
        Me.txtMiscPrefix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMiscPrefix.Location = New System.Drawing.Point(174, 35)
        Me.txtMiscPrefix.MaxLength = 4
        Me.txtMiscPrefix.Name = "txtMiscPrefix"
        Me.txtMiscPrefix.Size = New System.Drawing.Size(186, 21)
        Me.txtMiscPrefix.TabIndex = 14
        '
        'txtCalloutPrefix
        '
        Me.txtCalloutPrefix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCalloutPrefix.Location = New System.Drawing.Point(174, 8)
        Me.txtCalloutPrefix.MaxLength = 4
        Me.txtCalloutPrefix.Name = "txtCalloutPrefix"
        Me.txtCalloutPrefix.Size = New System.Drawing.Size(186, 21)
        Me.txtCalloutPrefix.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 23)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Quote Prefix:"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 23)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "PPM Prefix:"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 23)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Miscellaneous Prefix:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 23)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Callout Prefix:"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cboTimeSlot)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.lblTimeSlot)
        Me.TabPage1.Controls.Add(Me.cboWorkingHoursEnd)
        Me.TabPage1.Controls.Add(Me.cboWorkingHoursStart)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(368, 144)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Working Day"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cboTimeSlot
        '
        Me.cboTimeSlot.Items.AddRange(New Object() {"15", "30", "45", "60"})
        Me.cboTimeSlot.Location = New System.Drawing.Point(152, 8)
        Me.cboTimeSlot.Name = "cboTimeSlot"
        Me.cboTimeSlot.Size = New System.Drawing.Size(80, 21)
        Me.cboTimeSlot.TabIndex = 53
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(240, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 16)
        Me.Label14.TabIndex = 51
        Me.Label14.Text = "Minutes"
        '
        'lblTimeSlot
        '
        Me.lblTimeSlot.Location = New System.Drawing.Point(8, 8)
        Me.lblTimeSlot.Name = "lblTimeSlot"
        Me.lblTimeSlot.Size = New System.Drawing.Size(128, 23)
        Me.lblTimeSlot.TabIndex = 47
        Me.lblTimeSlot.Text = "Time Slot Duration"
        '
        'cboWorkingHoursEnd
        '
        Me.cboWorkingHoursEnd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboWorkingHoursEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWorkingHoursEnd.Location = New System.Drawing.Point(152, 72)
        Me.cboWorkingHoursEnd.Name = "cboWorkingHoursEnd"
        Me.cboWorkingHoursEnd.Size = New System.Drawing.Size(80, 21)
        Me.cboWorkingHoursEnd.TabIndex = 18
        '
        'cboWorkingHoursStart
        '
        Me.cboWorkingHoursStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboWorkingHoursStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWorkingHoursStart.Location = New System.Drawing.Point(152, 40)
        Me.cboWorkingHoursStart.Name = "cboWorkingHoursStart"
        Me.cboWorkingHoursStart.Size = New System.Drawing.Size(80, 21)
        Me.cboWorkingHoursStart.TabIndex = 17
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 16)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "Working Hours End"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 23)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "Working Hours Start"
        '
        'tabInvoicePrefix
        '
        Me.tabInvoicePrefix.Controls.Add(Me.txtInvoicePrefix)
        Me.tabInvoicePrefix.Controls.Add(Me.Label5)
        Me.tabInvoicePrefix.Location = New System.Drawing.Point(4, 22)
        Me.tabInvoicePrefix.Name = "tabInvoicePrefix"
        Me.tabInvoicePrefix.Size = New System.Drawing.Size(368, 144)
        Me.tabInvoicePrefix.TabIndex = 3
        Me.tabInvoicePrefix.Text = "Invoice Prefix"
        Me.tabInvoicePrefix.UseVisualStyleBackColor = True
        '
        'txtInvoicePrefix
        '
        Me.txtInvoicePrefix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInvoicePrefix.Location = New System.Drawing.Point(144, 16)
        Me.txtInvoicePrefix.MaxLength = 4
        Me.txtInvoicePrefix.Name = "txtInvoicePrefix"
        Me.txtInvoicePrefix.Size = New System.Drawing.Size(208, 21)
        Me.txtInvoicePrefix.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 23)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Invoice Prefix:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(368, 144)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "Engineers Performance"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtRecallVariable)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(359, 132)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Engineer Performance Report"
        '
        'txtRecallVariable
        '
        Me.txtRecallVariable.Location = New System.Drawing.Point(9, 54)
        Me.txtRecallVariable.Name = "txtRecallVariable"
        Me.txtRecallVariable.Size = New System.Drawing.Size(100, 21)
        Me.txtRecallVariable.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(288, 44)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Engineer Performance - No Of Days to see if a recall has been carried out at site" &
    "."
        '
        'FRMManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(784, 494)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.grpDetails)
        Me.Controls.Add(Me.grpItems)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboType)
        Me.MinimumSize = New System.Drawing.Size(792, 528)
        Me.Name = "FRMManager"
        Me.Text = "Picklists / Settings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.cboType, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.grpItems, 0)
        Me.Controls.SetChildIndex(Me.grpDetails, 0)
        Me.Controls.SetChildIndex(Me.grpSettings, 0)
        Me.grpItems.ResumeLayout(False)
        CType(Me.dgManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.grpSettings.ResumeLayout(False)
        Me.tabSystemSettings.ResumeLayout(False)
        Me.tabImportSettings.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tabCharges.ResumeLayout(False)
        Me.tabCharges.PerformLayout()
        Me.tabPrefix.ResumeLayout(False)
        Me.tabPrefix.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.tabInvoicePrefix.ResumeLayout(False)
        Me.tabInvoicePrefix.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupManagerDataGrid()

        Settings = DB.Manager.Get

        Combo.SetUpCombo(Me.cboType, DB.Picklists.PickListTypes().Table, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
        cboTimeSlot.SelectedItem = Settings.TimeSlot.ToString()
        Combo.SetUpCombo(Me.cboWorkingHoursStart, DynamicDataTables.Times(cboTimeSlot.SelectedItem), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetUpCombo(Me.cboWorkingHoursEnd, DynamicDataTables.Times(cboTimeSlot.SelectedItem), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)

        PopulateDatagrid(Entity.Sys.Enums.FormState.Load)

        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboWorkingHoursStart, Settings.WorkingHoursStart)
        Combo.SetSelectedComboItem_By_Value(Me.cboWorkingHoursEnd, Settings.WorkingHoursEnd)

        Me.txtMileageRate.Text = Settings.MileageRate
        Me.txtPartsMarkup.Text = Settings.PartsMarkup
        Me.txtRatesMarkup.Text = Settings.RatesMarkup
        Me.txtCalloutPrefix.Text = Settings.CalloutPrefix
        Me.txtMiscPrefix.Text = Settings.MiscPrefix
        Me.txtQuotePrefix.Text = Settings.QuotePrefix
        Me.txtPPMPrefix.Text = Settings.PPMPrefix
        Me.txtRecallVariable.Text = Settings.RecallVariable
        Me.txtInvoicePrefix.Text = Settings.InvoicePrefix
        Me.txtPartsImportMarkup.Text = Settings.PartsImportMarkup
        Me.txtServiceFromLetterPrefix.Text = Settings.ServiceFromLetterPrefix
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

    Private _pageState As Entity.Sys.Enums.FormState

    Private Property PageState() As Entity.Sys.Enums.FormState
        Get
            Return _pageState
        End Get
        Set(ByVal Value As Entity.Sys.Enums.FormState)
            _pageState = Value
        End Set
    End Property

    Private _dvManager As DataView

    Private Property ManagerDataview() As DataView
        Get
            Return _dvManager
        End Get
        Set(ByVal value As DataView)
            _dvManager = value
            _dvManager.AllowNew = False
            _dvManager.AllowEdit = False
            _dvManager.AllowDelete = False
            _dvManager.Table.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString
            Me.dgManager.DataSource = ManagerDataview
        End Set
    End Property

    Private ReadOnly Property SelectedManagerDataRow() As DataRow
        Get
            If Not Me.dgManager.CurrentRowIndex = -1 Then
                Return ManagerDataview(Me.dgManager.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _settings As Entity.Management.Settings = Nothing

    Public Property Settings() As Entity.Management.Settings
        Get
            Return _settings
        End Get
        Set(ByVal Value As Entity.Management.Settings)
            _settings = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupManagerDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgManager.TableStyles(0)

        Dim name As New DataGridLabelColumn
        name.Format = ""
        name.FormatInfo = Nothing
        name.HeaderText = "Name"
        name.MappingName = "Name"
        name.ReadOnly = True
        name.Width = 177
        name.NullText = ""
        tbStyle.GridColumnStyles.Add(name)

        Dim description As New DataGridLabelColumn
        description.Format = ""
        description.FormatInfo = Nothing
        description.HeaderText = "Description"
        description.MappingName = "Description"
        description.ReadOnly = True
        description.Width = 177
        description.NullText = ""
        tbStyle.GridColumnStyles.Add(description)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPickLists.ToString
        Me.dgManager.TableStyles.Add(tbStyle)
    End Sub

    Private Sub SetUpPageState(ByVal state As Entity.Sys.Enums.FormState)
        Entity.Sys.Helper.ClearGroupBox(Me.grpDetails)
        Select Case state
            Case Entity.Sys.Enums.FormState.Load
                Me.grpDetails.Enabled = False
                Me.btnAddNew.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnSave.Enabled = False
            Case Entity.Sys.Enums.FormState.Insert
                Me.grpDetails.Enabled = True
                Me.btnAddNew.Enabled = True
                Me.btnDelete.Enabled = False
                Me.btnSave.Enabled = True
            Case Entity.Sys.Enums.FormState.Update
                Me.btnAddNew.Enabled = True
                Me.grpDetails.Enabled = True
                Me.btnSave.Enabled = True
                Me.btnDelete.Enabled = True
        End Select
        PageState = state
    End Sub

#End Region

#Region "Events"

    Private Sub FRMManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If Me.cboType.SelectedIndex = 0 Then
            PopulateDatagrid(Entity.Sys.Enums.FormState.Load)
        Else
            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
        End If
        'If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.PickListTypes.Engineer_Levels) Then
        '    cbxShowOnJob.Visible = True
        'Else
        '    cbxShowOnJob.Visible = False

        'End If
    End Sub

    Private Sub dgManager_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgManager.Click, dgManager.CurrentCellChanged
        Try
            SetUpPageState(Entity.Sys.Enums.FormState.Update)
            If Not SelectedManagerDataRow Is Nothing Then
                If Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow("Name")) = "RC - Recall" Then
                    ShowMessage("This item cannont be edited", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SetUpPageState(Entity.Sys.Enums.FormState.Insert)
                    Exit Sub
                End If

                Me.txtName.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow("Name"))
                Me.txtDescription.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow("Description"))
                Me.txtPercentageRate.Text = CDbl(Entity.Sys.Helper.MakeDoubleValid(SelectedManagerDataRow("PercentageRate")))
                Me.chkMandatory.Checked = Entity.Sys.Helper.MakeBooleanValid(SelectedManagerDataRow("Mandatory"))
                'If (CDbl(Entity.Sys.Helper.MakeDoubleValid(SelectedManagerDataRow("PercentageRate"))) = 0.0) Then
                '    cbxShowOnJob.Checked = 0
                'Else
                '    cbxShowOnJob.Checked = 1
                'End If
            Else
                If Me.cboType.SelectedIndex = 0 Then
                    SetUpPageState(Entity.Sys.Enums.FormState.Load)
                Else
                    SetUpPageState(Entity.Sys.Enums.FormState.Insert)
                End If
            End If
        Catch ex As Exception
            ShowMessage("Item data cannot load : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        SetUpPageState(Entity.Sys.Enums.FormState.Insert)
    End Sub

    Private Sub btnSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSettings.Click
        SaveSettings()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Delete()
    End Sub

    Private Sub cboTimeSlot_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTimeSlot.SelectedValueChanged
        Combo.SetUpCombo(Me.cboWorkingHoursStart, DynamicDataTables.Times(cboTimeSlot.SelectedItem), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)
        Combo.SetUpCombo(Me.cboWorkingHoursEnd, DynamicDataTables.Times(cboTimeSlot.SelectedItem), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None)

        Combo.SetSelectedComboItem_By_Value(Me.cboWorkingHoursStart, Settings.WorkingHoursStart)
        If Combo.GetSelectedItemValue(Me.cboWorkingHoursStart) = "0" Then
            Me.cboWorkingHoursStart.SelectedIndex = 0
        End If

        Combo.SetSelectedComboItem_By_Value(Me.cboWorkingHoursEnd, Settings.WorkingHoursEnd)
        If Combo.GetSelectedItemValue(Me.cboWorkingHoursEnd) = "0" Then
            Me.cboWorkingHoursEnd.SelectedIndex = Me.cboWorkingHoursEnd.Items.Count - 1
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub PopulateDatagrid(ByVal state As Entity.Sys.Enums.FormState)
        Try
            Me.lblPercentageRate.Visible = False
            Me.txtPercentageRate.Visible = False

            If CInt(Combo.GetSelectedItemValue(Me.cboType)) = 0 Then
                Dim dt As New DataTable
                dt.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString
                ManagerDataview = New DataView(dt)
            Else
                ManagerDataview = DB.Picklists.GetAll(CInt(Combo.GetSelectedItemValue(Me.cboType)))

                Select Case CInt(Combo.GetSelectedItemValue(Me.cboType))
                    Case CInt(Entity.Sys.Enums.PickListTypes.VATCodes), CInt(Entity.Sys.Enums.PickListTypes.PartCategories), CInt(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts)
                        lblPercentageRate.Text = "Perc Rate"
                        Me.lblPercentageRate.Visible = True
                        Me.txtPercentageRate.Visible = True
                    Case CInt(Entity.Sys.Enums.PickListTypes.Engineer_Levels)
                        lblPercentageRate.Text = "Rate"
                        Me.lblPercentageRate.Visible = True
                        Me.txtPercentageRate.Visible = True

                End Select
            End If
            SetUpPageState(state)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveSettings()
        Try
            Settings.IgnoreExceptionsOnSetMethods = True
            Settings.SetWorkingHoursStart = Combo.GetSelectedItemValue(Me.cboWorkingHoursStart)
            Settings.SetWorkingHoursEnd = Combo.GetSelectedItemValue(Me.cboWorkingHoursEnd)
            Settings.SetMileageRate = Me.txtMileageRate.Text.Trim
            Settings.SetPartsMarkup = Me.txtPartsMarkup.Text.Trim
            Settings.SetRatesMarkup = Me.txtRatesMarkup.Text.Trim
            Settings.SetCalloutPrefix = Me.txtCalloutPrefix.Text.Trim
            Settings.SetMiscPrefix = Me.txtMiscPrefix.Text.Trim
            Settings.SetPPMPrefix = Me.txtPPMPrefix.Text.Trim
            Settings.SetQuotePrefix = Me.txtQuotePrefix.Text.Trim
            Settings.SetTimeSlot = cboTimeSlot.SelectedItem
            Settings.SetInvoicePrefix = Me.txtInvoicePrefix.Text.Trim
            Settings.SetRecallVariable = Me.txtRecallVariable.Text.Trim
            Settings.SetPartsImportMarkup = Me.txtPartsImportMarkup.Text.Trim
            Settings.SetServiceFromLetterPrefix = Me.txtServiceFromLetterPrefix.Text.Trim

            Dim sV As New Entity.Management.SettingsValidator
            sV.Validate(Settings)

            DB.Manager.UpdateSettings(Settings)

            'UPDATE ALL CUSTOMERS WHO ACCEPT CHANGES
            DB.CustomerCharge.UpdateALL(Settings.MileageRate, Settings.PartsMarkup, Settings.RatesMarkup)

            ShowMessage("Settings updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch vex As ValidationException
            Dim msg As String = "Please correct the following errors: " & vbNewLine & "{0}{1}"
            msg = String.Format(msg, vbNewLine, vex.Validator.CriticalMessagesString())
            ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error Saving : " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Save()
        Dim picklist As New Entity.PickLists.PickList
        picklist.IgnoreExceptionsOnSetMethods = True
        picklist.SetName = Me.txtName.Text.Trim
        picklist.SetDescription = Me.txtDescription.Text.Trim
        picklist.SetEnumTypeID = Combo.GetSelectedItemValue(Me.cboType)
        picklist.SetMandatory = chkMandatory.Checked
        Select Case CInt(Combo.GetSelectedItemValue(Me.cboType))
            Case CInt(Entity.Sys.Enums.PickListTypes.VATCodes), CInt(Entity.Sys.Enums.PickListTypes.PartCategories), CInt(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts)
                picklist.SetPercentageRate = Me.txtPercentageRate.Text.Trim
            Case Else
                picklist.SetPercentageRate = 0.0
                If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.PickListTypes.Engineer_Levels) Then
                    picklist.SetPercentageRate = Me.txtPercentageRate.Text.Trim
                End If

        End Select

        If PageState = Entity.Sys.Enums.FormState.Update Then

            picklist.SetManagerID = SelectedManagerDataRow.Item("ManagerID")

        End If

        Dim validator As New Entity.PickLists.PickListValidator

        Try
            validator.Validate(picklist)

            Select Case PageState
                Case Entity.Sys.Enums.FormState.Insert
                    DB.Picklists.Insert(picklist)
                Case Entity.Sys.Enums.FormState.Update
                    DB.Picklists.Update(picklist)
                    If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.PickListTypes.PartCategories) Then DB.Picklists.UpdateSellPrices(picklist)
            End Select

            PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
        Catch ex As ValidationException
            ShowMessage(validator.CriticalMessagesString, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            ShowMessage("Error Saving : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Delete()
        Try
            If Not SelectedManagerDataRow Is Nothing Then
                If ShowMessage("Are you sure you want to delete """ & SelectedManagerDataRow("Name") & """ from """ & Combo.GetSelectedItemDescription(Me.cboType) & """?", MessageBoxButtons.YesNo, MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    If CType(CInt(Combo.GetSelectedItemValue(Me.cboType)), Entity.Sys.Enums.PickListTypes) = Entity.Sys.Enums.PickListTypes.Regions Then
                        Dim dv As DataView = DB.Picklists.Region_Usage(SelectedManagerDataRow("ManagerID"))
                        If dv.Table.Rows.Count > 0 Then
                            Dim str As String = "The region you are trying to delete is still allocated to the following records:" & vbCrLf
                            For Each dr As DataRow In dv.Table.Rows
                                str += "* " & dr("type") & " - " & dr("Name") & vbCrLf
                            Next
                            MessageBox.Show(str, "Region Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If

                    DB.Picklists.Delete(SelectedManagerDataRow("ManagerID"))
                    PopulateDatagrid(Entity.Sys.Enums.FormState.Insert)
                End If
            Else
                ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ShowMessage("Error deleting : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class