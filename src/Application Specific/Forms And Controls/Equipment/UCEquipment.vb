Imports System.Collections

Public Class UCEquipment : Inherits FSM.UCBase : Implements IUserControl



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()


        Combo.SetUpCombo(Me.cboEquipmentType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EquipmentType).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        'Combo.SetUpCombo(Me.cboEquipmentType, DynamicDataTables.EquipmentType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

        Combo.SetUpCombo(Me.cboStatus, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.EquipmentStatus).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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
    Friend WithEvents txtDecription As System.Windows.Forms.TextBox
    Friend WithEvents lblRegistration As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents dtpCalibrationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInsuranceDue As System.Windows.Forms.Label
    Friend WithEvents dtpWarrantyExpires As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMOTDue As System.Windows.Forms.Label
    Friend WithEvents lblTaxDue As System.Windows.Forms.Label
    Friend WithEvents lblAssetId As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCallibrationPeriod As System.Windows.Forms.TextBox
    Friend WithEvents btnfindEngineer As System.Windows.Forms.Button
    Friend WithEvents txtEngineer As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCalibrationCert As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboEquipmentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents tabHistory As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtAssetNumber As TextBox
    Friend WithEvents dgEquipmentAudits As DataGrid
    Friend WithEvents lblCalibrationStatus As Label
    Friend WithEvents tabDocuments As TabPage
    Friend WithEvents btnUnassign As Button
    Friend WithEvents tabGenerateWO As TabPage
    Friend WithEvents grpWorkOrder As GroupBox
    Friend WithEvents txtFaults As TextBox
    Friend WithEvents lblFaults As Label
    Friend WithEvents btnGenerate As Button
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents btnGenerateAndEmail As Button
    Friend WithEvents Label6 As System.Windows.Forms.Label



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tcVans = New System.Windows.Forms.TabControl()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.grpVan = New System.Windows.Forms.GroupBox()
        Me.btnUnassign = New System.Windows.Forms.Button()
        Me.lblCalibrationStatus = New System.Windows.Forms.Label()
        Me.txtAssetNumber = New System.Windows.Forms.TextBox()
        Me.txtSerialNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboEquipmentType = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCalibrationCert = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnfindEngineer = New System.Windows.Forms.Button()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCallibrationPeriod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDecription = New System.Windows.Forms.TextBox()
        Me.lblRegistration = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.dtpCalibrationDate = New System.Windows.Forms.DateTimePicker()
        Me.lblInsuranceDue = New System.Windows.Forms.Label()
        Me.dtpWarrantyExpires = New System.Windows.Forms.DateTimePicker()
        Me.lblMOTDue = New System.Windows.Forms.Label()
        Me.lblTaxDue = New System.Windows.Forms.Label()
        Me.lblAssetId = New System.Windows.Forms.Label()
        Me.tabHistory = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgEquipmentAudits = New System.Windows.Forms.DataGrid()
        Me.tabDocuments = New System.Windows.Forms.TabPage()
        Me.tabGenerateWO = New System.Windows.Forms.TabPage()
        Me.grpWorkOrder = New System.Windows.Forms.GroupBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.btnGenerateAndEmail = New System.Windows.Forms.Button()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.txtFaults = New System.Windows.Forms.TextBox()
        Me.lblFaults = New System.Windows.Forms.Label()
        Me.tcVans.SuspendLayout()
        Me.tabDetails.SuspendLayout()
        Me.grpVan.SuspendLayout()
        Me.tabHistory.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgEquipmentAudits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGenerateWO.SuspendLayout()
        Me.grpWorkOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcVans
        '
        Me.tcVans.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcVans.Controls.Add(Me.tabDetails)
        Me.tcVans.Controls.Add(Me.tabHistory)
        Me.tcVans.Controls.Add(Me.tabDocuments)
        Me.tcVans.Controls.Add(Me.tabGenerateWO)
        Me.tcVans.Location = New System.Drawing.Point(3, 7)
        Me.tcVans.Name = "tcVans"
        Me.tcVans.SelectedIndex = 0
        Me.tcVans.Size = New System.Drawing.Size(683, 670)
        Me.tcVans.TabIndex = 14
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
        Me.grpVan.Controls.Add(Me.btnUnassign)
        Me.grpVan.Controls.Add(Me.lblCalibrationStatus)
        Me.grpVan.Controls.Add(Me.txtAssetNumber)
        Me.grpVan.Controls.Add(Me.txtSerialNo)
        Me.grpVan.Controls.Add(Me.Label6)
        Me.grpVan.Controls.Add(Me.cboEquipmentType)
        Me.grpVan.Controls.Add(Me.Label4)
        Me.grpVan.Controls.Add(Me.txtCalibrationCert)
        Me.grpVan.Controls.Add(Me.Label3)
        Me.grpVan.Controls.Add(Me.btnfindEngineer)
        Me.grpVan.Controls.Add(Me.txtEngineer)
        Me.grpVan.Controls.Add(Me.Label5)
        Me.grpVan.Controls.Add(Me.cboStatus)
        Me.grpVan.Controls.Add(Me.Label1)
        Me.grpVan.Controls.Add(Me.txtCallibrationPeriod)
        Me.grpVan.Controls.Add(Me.Label2)
        Me.grpVan.Controls.Add(Me.txtDecription)
        Me.grpVan.Controls.Add(Me.lblRegistration)
        Me.grpVan.Controls.Add(Me.txtNotes)
        Me.grpVan.Controls.Add(Me.lblNotes)
        Me.grpVan.Controls.Add(Me.dtpCalibrationDate)
        Me.grpVan.Controls.Add(Me.lblInsuranceDue)
        Me.grpVan.Controls.Add(Me.dtpWarrantyExpires)
        Me.grpVan.Controls.Add(Me.lblMOTDue)
        Me.grpVan.Controls.Add(Me.lblTaxDue)
        Me.grpVan.Controls.Add(Me.lblAssetId)
        Me.grpVan.Location = New System.Drawing.Point(8, 8)
        Me.grpVan.Name = "grpVan"
        Me.grpVan.Size = New System.Drawing.Size(664, 631)
        Me.grpVan.TabIndex = 200
        Me.grpVan.TabStop = False
        Me.grpVan.Text = "Details"
        '
        'btnUnassign
        '
        Me.btnUnassign.BackColor = System.Drawing.Color.White
        Me.btnUnassign.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnassign.Location = New System.Drawing.Point(447, 278)
        Me.btnUnassign.Name = "btnUnassign"
        Me.btnUnassign.Size = New System.Drawing.Size(82, 23)
        Me.btnUnassign.TabIndex = 472
        Me.btnUnassign.Text = "Un-assign"
        Me.btnUnassign.UseVisualStyleBackColor = False
        '
        'lblCalibrationStatus
        '
        Me.lblCalibrationStatus.Location = New System.Drawing.Point(382, 118)
        Me.lblCalibrationStatus.Name = "lblCalibrationStatus"
        Me.lblCalibrationStatus.Size = New System.Drawing.Size(136, 20)
        Me.lblCalibrationStatus.TabIndex = 471
        Me.lblCalibrationStatus.Text = "[Calibration Status]"
        '
        'txtAssetNumber
        '
        Me.txtAssetNumber.Location = New System.Drawing.Point(175, 252)
        Me.txtAssetNumber.MaxLength = 9
        Me.txtAssetNumber.Name = "txtAssetNumber"
        Me.txtAssetNumber.Size = New System.Drawing.Size(201, 21)
        Me.txtAssetNumber.TabIndex = 9
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSerialNo.Location = New System.Drawing.Point(175, 88)
        Me.txtSerialNo.MaxLength = 20
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.Size = New System.Drawing.Size(373, 21)
        Me.txtSerialNo.TabIndex = 3
        Me.txtSerialNo.Tag = "Van.Registration"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 20)
        Me.Label6.TabIndex = 470
        Me.Label6.Text = "Serial No."
        '
        'cboEquipmentType
        '
        Me.cboEquipmentType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboEquipmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEquipmentType.FormattingEnabled = True
        Me.cboEquipmentType.Location = New System.Drawing.Point(175, 33)
        Me.cboEquipmentType.Name = "cboEquipmentType"
        Me.cboEquipmentType.Size = New System.Drawing.Size(201, 21)
        Me.cboEquipmentType.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 20)
        Me.Label4.TabIndex = 440
        Me.Label4.Text = "Type of Equipment"
        '
        'txtCalibrationCert
        '
        Me.txtCalibrationCert.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCalibrationCert.Location = New System.Drawing.Point(175, 170)
        Me.txtCalibrationCert.MaxLength = 20
        Me.txtCalibrationCert.Name = "txtCalibrationCert"
        Me.txtCalibrationCert.Size = New System.Drawing.Size(373, 21)
        Me.txtCalibrationCert.TabIndex = 6
        Me.txtCalibrationCert.Tag = "Van.Registration"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 20)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Calibration Certificate"
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(409, 278)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 11
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(175, 279)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(228, 21)
        Me.txtEngineer.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 282)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 410
        Me.Label5.Text = "Engineer"
        '
        'cboStatus
        '
        Me.cboStatus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(175, 226)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(201, 21)
        Me.cboStatus.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 20)
        Me.Label1.TabIndex = 370
        Me.Label1.Text = "Calibration Period (Months)"
        '
        'txtCallibrationPeriod
        '
        Me.txtCallibrationPeriod.Location = New System.Drawing.Point(175, 142)
        Me.txtCallibrationPeriod.MaxLength = 9
        Me.txtCallibrationPeriod.Name = "txtCallibrationPeriod"
        Me.txtCallibrationPeriod.Size = New System.Drawing.Size(43, 21)
        Me.txtCallibrationPeriod.TabIndex = 5
        Me.txtCallibrationPeriod.Text = "12"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 278)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 20)
        Me.Label2.TabIndex = 340
        '
        'txtDecription
        '
        Me.txtDecription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDecription.Location = New System.Drawing.Point(175, 61)
        Me.txtDecription.MaxLength = 20
        Me.txtDecription.Name = "txtDecription"
        Me.txtDecription.Size = New System.Drawing.Size(373, 21)
        Me.txtDecription.TabIndex = 2
        Me.txtDecription.Tag = "Van.Registration"
        '
        'lblRegistration
        '
        Me.lblRegistration.Location = New System.Drawing.Point(8, 64)
        Me.lblRegistration.Name = "lblRegistration"
        Me.lblRegistration.Size = New System.Drawing.Size(144, 20)
        Me.lblRegistration.TabIndex = 310
        Me.lblRegistration.Text = "Description"
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(175, 321)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(467, 259)
        Me.txtNotes.TabIndex = 12
        Me.txtNotes.Tag = "Van.Notes"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 324)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(53, 20)
        Me.lblNotes.TabIndex = 310
        Me.lblNotes.Text = "Notes"
        '
        'dtpCalibrationDate
        '
        Me.dtpCalibrationDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpCalibrationDate.Location = New System.Drawing.Point(175, 115)
        Me.dtpCalibrationDate.Name = "dtpCalibrationDate"
        Me.dtpCalibrationDate.Size = New System.Drawing.Size(201, 21)
        Me.dtpCalibrationDate.TabIndex = 4
        Me.dtpCalibrationDate.Tag = "Van.InsuranceDue"
        '
        'lblInsuranceDue
        '
        Me.lblInsuranceDue.Location = New System.Drawing.Point(8, 121)
        Me.lblInsuranceDue.Name = "lblInsuranceDue"
        Me.lblInsuranceDue.Size = New System.Drawing.Size(136, 20)
        Me.lblInsuranceDue.TabIndex = 31
        Me.lblInsuranceDue.Text = "Calibration Date"
        '
        'dtpWarrantyExpires
        '
        Me.dtpWarrantyExpires.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpWarrantyExpires.Location = New System.Drawing.Point(175, 200)
        Me.dtpWarrantyExpires.Name = "dtpWarrantyExpires"
        Me.dtpWarrantyExpires.Size = New System.Drawing.Size(201, 21)
        Me.dtpWarrantyExpires.TabIndex = 7
        Me.dtpWarrantyExpires.Tag = "Van.MOTDue"
        '
        'lblMOTDue
        '
        Me.lblMOTDue.Location = New System.Drawing.Point(8, 201)
        Me.lblMOTDue.Name = "lblMOTDue"
        Me.lblMOTDue.Size = New System.Drawing.Size(114, 20)
        Me.lblMOTDue.TabIndex = 310
        Me.lblMOTDue.Text = "Warranty Expires"
        '
        'lblTaxDue
        '
        Me.lblTaxDue.Location = New System.Drawing.Point(8, 228)
        Me.lblTaxDue.Name = "lblTaxDue"
        Me.lblTaxDue.Size = New System.Drawing.Size(64, 20)
        Me.lblTaxDue.TabIndex = 31
        Me.lblTaxDue.Text = "Status"
        '
        'lblAssetId
        '
        Me.lblAssetId.Location = New System.Drawing.Point(8, 255)
        Me.lblAssetId.Name = "lblAssetId"
        Me.lblAssetId.Size = New System.Drawing.Size(123, 20)
        Me.lblAssetId.TabIndex = 310
        Me.lblAssetId.Text = "Asset Number"
        '
        'tabHistory
        '
        Me.tabHistory.BackColor = System.Drawing.SystemColors.Control
        Me.tabHistory.Controls.Add(Me.GroupBox1)
        Me.tabHistory.Location = New System.Drawing.Point(4, 22)
        Me.tabHistory.Name = "tabHistory"
        Me.tabHistory.Size = New System.Drawing.Size(675, 644)
        Me.tabHistory.TabIndex = 10
        Me.tabHistory.Text = "History"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgEquipmentAudits)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 631)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Equipment Audit"
        '
        'dgEquipmentAudits
        '
        Me.dgEquipmentAudits.DataMember = ""
        Me.dgEquipmentAudits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgEquipmentAudits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEquipmentAudits.Location = New System.Drawing.Point(3, 17)
        Me.dgEquipmentAudits.Name = "dgEquipmentAudits"
        Me.dgEquipmentAudits.Size = New System.Drawing.Size(658, 611)
        Me.dgEquipmentAudits.TabIndex = 15
        '
        'tabDocuments
        '
        Me.tabDocuments.Location = New System.Drawing.Point(4, 22)
        Me.tabDocuments.Name = "tabDocuments"
        Me.tabDocuments.Size = New System.Drawing.Size(675, 644)
        Me.tabDocuments.TabIndex = 11
        Me.tabDocuments.Text = "Documents"
        Me.tabDocuments.UseVisualStyleBackColor = True
        '
        'tabGenerateWO
        '
        Me.tabGenerateWO.Controls.Add(Me.grpWorkOrder)
        Me.tabGenerateWO.Location = New System.Drawing.Point(4, 22)
        Me.tabGenerateWO.Name = "tabGenerateWO"
        Me.tabGenerateWO.Size = New System.Drawing.Size(675, 644)
        Me.tabGenerateWO.TabIndex = 12
        Me.tabGenerateWO.Text = "Generate WO"
        Me.tabGenerateWO.UseVisualStyleBackColor = True
        '
        'grpWorkOrder
        '
        Me.grpWorkOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpWorkOrder.BackColor = System.Drawing.SystemColors.Control
        Me.grpWorkOrder.Controls.Add(Me.txtEmail)
        Me.grpWorkOrder.Controls.Add(Me.lblEmail)
        Me.grpWorkOrder.Controls.Add(Me.btnGenerateAndEmail)
        Me.grpWorkOrder.Controls.Add(Me.btnGenerate)
        Me.grpWorkOrder.Controls.Add(Me.txtFaults)
        Me.grpWorkOrder.Controls.Add(Me.lblFaults)
        Me.grpWorkOrder.Location = New System.Drawing.Point(5, 7)
        Me.grpWorkOrder.Name = "grpWorkOrder"
        Me.grpWorkOrder.Size = New System.Drawing.Size(664, 262)
        Me.grpWorkOrder.TabIndex = 4
        Me.grpWorkOrder.TabStop = False
        Me.grpWorkOrder.Text = "Equipment Work Order"
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Location = New System.Drawing.Point(105, 164)
        Me.txtEmail.MaxLength = 256
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(542, 21)
        Me.txtEmail.TabIndex = 475
        Me.txtEmail.Tag = "Van.Registration"
        '
        'lblEmail
        '
        Me.lblEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblEmail.Location = New System.Drawing.Point(6, 167)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(85, 20)
        Me.lblEmail.TabIndex = 476
        Me.lblEmail.Text = "Email"
        '
        'btnGenerateAndEmail
        '
        Me.btnGenerateAndEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateAndEmail.BackColor = System.Drawing.Color.White
        Me.btnGenerateAndEmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateAndEmail.Location = New System.Drawing.Point(495, 213)
        Me.btnGenerateAndEmail.Name = "btnGenerateAndEmail"
        Me.btnGenerateAndEmail.Size = New System.Drawing.Size(152, 33)
        Me.btnGenerateAndEmail.TabIndex = 474
        Me.btnGenerateAndEmail.Text = "Generate And Email"
        Me.btnGenerateAndEmail.UseVisualStyleBackColor = False
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.BackColor = System.Drawing.Color.White
        Me.btnGenerate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.Location = New System.Drawing.Point(6, 213)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(152, 33)
        Me.btnGenerate.TabIndex = 473
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'txtFaults
        '
        Me.txtFaults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFaults.Location = New System.Drawing.Point(105, 25)
        Me.txtFaults.Multiline = True
        Me.txtFaults.Name = "txtFaults"
        Me.txtFaults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFaults.Size = New System.Drawing.Size(542, 105)
        Me.txtFaults.TabIndex = 311
        Me.txtFaults.Tag = ""
        '
        'lblFaults
        '
        Me.lblFaults.Location = New System.Drawing.Point(6, 28)
        Me.lblFaults.Name = "lblFaults"
        Me.lblFaults.Size = New System.Drawing.Size(53, 20)
        Me.lblFaults.TabIndex = 312
        Me.lblFaults.Text = "Faults"
        '
        'UCEquipment
        '
        Me.Controls.Add(Me.tcVans)
        Me.Name = "UCEquipment"
        Me.Size = New System.Drawing.Size(693, 680)
        Me.tcVans.ResumeLayout(False)
        Me.tabDetails.ResumeLayout(False)
        Me.grpVan.ResumeLayout(False)
        Me.grpVan.PerformLayout()
        Me.tabHistory.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgEquipmentAudits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGenerateWO.ResumeLayout(False)
        Me.grpWorkOrder.ResumeLayout(False)
        Me.grpWorkOrder.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private DocumentsControl As UCDocumentsList

#End Region

#Region "Interface Object"

    Private Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs) Implements IUserControl.LoadForm
        LoadBaseControl(Me)
        SetupDataGrid()
        'SetupPartsDatagrid()
        'SetupProductsDatagrid()
        'SetupWarehousesDatagrid()
        'SetupPartsDataGridView()
        'Me.dgParts.ReadOnly = False
    End Sub

    Public ReadOnly Property LoadedItem() As Object Implements IUserControl.LoadedItem
        Get
            Return CurrentEquipment

        End Get
    End Property

#End Region

#Region "Properties"

    Public Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String) Implements IUserControl.RecordsChanged
    Public Event StateChanged(ByVal newID As Integer) Implements IUserControl.StateChanged

    'Private _currentVan As Entity.Vans.Van
    'Public Property CurrentVan() As Entity.Vans.Van
    '    Get
    '        Return _currentVan
    '    End Get
    '    Set(ByVal Value As Entity.Vans.Van)
    '        _currentVan = Value

    '        If CurrentVan Is Nothing Then
    '            CurrentVan = New Entity.Vans.Van
    '            CurrentVan.Exists = False
    '        End If

    '        If CurrentVan.Exists Then
    '            'Populate()
    '            Me.btnEngineerHistory.Enabled = True
    '        Else
    '            WarehousesDataView = DB.Warehouse.Warehouse_GetAll_For_Van2(0)
    '            Me.btnEngineerHistory.Enabled = False
    '        End If
    '    End Set
    ' End Property

    Private CurrentStatus As Integer = 0

    Private _currentEquipment As Entity.Engineers.Equipment
    Public Property CurrentEquipment() As Entity.Engineers.Equipment
        Get
            Return _currentEquipment
        End Get
        Set(ByVal Value As Entity.Engineers.Equipment)
            _currentEquipment = Value

            If CurrentEquipment Is Nothing Then
                CurrentEquipment = New Entity.Engineers.Equipment
                CurrentEquipment.Exists = False
            End If

            If CurrentEquipment.Exists Then
                Populate()

                Me.tabDocuments.Controls.Clear()
                DocumentsControl = New UCDocumentsList(Entity.Sys.Enums.TableNames.tblEquipment,
                                                       CurrentEquipment.EquipmentID)
                Me.tabDocuments.Controls.Add(DocumentsControl)

            Else

            End If

        End Set
    End Property

    Private _theEngineer As Entity.Engineers.Engineer
    Public Property theEngineer() As Entity.Engineers.Engineer
        Get
            Return _theEngineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _theEngineer = Value
            If Not _theEngineer Is Nothing Then
                Me.txtEngineer.Text = theEngineer.Name
            Else
                Me.txtEngineer.Text = ""
            End If
        End Set
    End Property

    Private _dvEquipmentAudits As DataView
    Private Property EquipmentAuditsDataview() As DataView
        Get
            Return _dvEquipmentAudits
        End Get
        Set(ByVal value As DataView)
            _dvEquipmentAudits = value
            _dvEquipmentAudits.AllowNew = False
            _dvEquipmentAudits.AllowEdit = False
            _dvEquipmentAudits.AllowDelete = False
            _dvEquipmentAudits.Table.TableName = Entity.Sys.Enums.TableNames.tblEquipmentAudit.ToString
            Me.dgEquipmentAudits.DataSource = EquipmentAuditsDataview
        End Set
    End Property

#End Region

#Region "Setup"
    Private Sub SetupDataGrid()
        Dim tStyle As DataGridTableStyle = Me.dgEquipmentAudits.TableStyles(0)
        tStyle.GridColumnStyles.Clear()

        Dim Name As New DataGridLabelColumn
        Name.Format = ""
        Name.FormatInfo = Nothing
        Name.HeaderText = "Action"
        Name.MappingName = "ActionChange"
        Name.ReadOnly = True
        Name.Width = 300
        Name.NullText = ""
        tStyle.GridColumnStyles.Add(Name)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Date"
        Site.MappingName = "ActionDateTime"
        Site.ReadOnly = True
        Site.Width = 200
        Site.NullText = ""
        tStyle.GridColumnStyles.Add(Site)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "User"
        Type.MappingName = "Fullname"
        Type.ReadOnly = True
        Type.Width = 200
        Type.NullText = ""
        tStyle.GridColumnStyles.Add(Type)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblEquipmentAudit.ToString
        Me.dgEquipmentAudits.TableStyles.Add(tStyle)
    End Sub
#End Region

#Region "Events"

    Private Sub UCEqupment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(sender, e)
    End Sub



    'Private Sub dgParts_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgParts.CurrentCellChanged
    '    If SelectedPartDataRow Is Nothing Then
    '        Exit Sub
    '    End If

    '    'update the row

    '    Dim RecordID As Integer = 0
    '    RecordID = SelectedPartDataRow.Item("MinMaxID")

    'End Sub

    'Private Sub dgvParts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvParts.DoubleClick
    '    If Me.dgvParts.CurrentRow Is Nothing Then
    '        Exit Sub
    '    End If
    '    ShowForm(GetType(FRMPart), True, New Object() {Me.dgvParts.CurrentRow.Cells(7).Value, True})
    '    PartsDataGridView = DB.PartTransaction.GetByVan2(CurrentVan.VanID, True, False, Combo.GetSelectedItemValue(cboPreferredSupplierID))
    'End Sub




#End Region

#Region "Functions"
    Private Sub Populate(Optional ByVal ID As Integer = 0) Implements IUserControl.Populate
        ControlLoading = True
        If Not ID = 0 Then
            DisableControls()
            CurrentEquipment = DB.Engineer.Equipment_Get(ID)

            theEngineer = DB.Engineer.Engineer_Get(CurrentEquipment.EngineerID)

            If theEngineer Is Nothing Then
                Me.txtEngineer.Text = "<Not Set>"
            ElseIf theEngineer.EngineerID = 0 Then
                Me.txtEngineer.Text = "<Not Set>"
            Else
                Me.txtEngineer.Text = theEngineer.Name
            End If

            'check if unit is out of calibration
            If Not IsEquipmentCalibrationValid(CurrentEquipment.CalibrationDate,
                                               CurrentEquipment.CalibrationMonths) And
                                               CurrentEquipment.StatusID <>
                                               Entity.Sys.Enums.EquipmentStatus.OutOfCalibration Then
                lblCalibrationStatus.Text = "Out of calibration"
                lblCalibrationStatus.ForeColor = Color.Red
            Else
                lblCalibrationStatus.Text = "Still in Calibration"
                lblCalibrationStatus.ForeColor = Color.Green
            End If

            Me.txtNotes.Text = CurrentEquipment.Notes
            Me.txtAssetNumber.Text = CurrentEquipment.AssetNo
            Me.txtCallibrationPeriod.Text = CurrentEquipment.CalibrationMonths
            Me.txtCalibrationCert.Text = CurrentEquipment.CertificateNumber
            Combo.SetSelectedComboItem_By_Value(cboEquipmentType, CurrentEquipment.EquipmentTypeID)

            Me.dtpCalibrationDate.Value = CurrentEquipment.CalibrationDate
            Me.dtpWarrantyExpires.Value = CurrentEquipment.WarrantyEndDate
            Me.txtDecription.Text = CurrentEquipment.Name
            Me.txtSerialNo.Text = CurrentEquipment.SerialNumber
            Combo.SetSelectedComboItem_By_Value(cboStatus, CurrentEquipment.StatusID)

            CurrentStatus = CurrentEquipment.StatusID

            PopulateEquipmentAuditDatagrid()
        End If
    End Sub

    Private Sub PopulateEquipmentAuditDatagrid()
        Try
            EquipmentAuditsDataview = DB.Engineer.EquipmentAudit_Get(CurrentEquipment.EquipmentID)
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DisableControls()
        Dim ssm As Entity.Sys.Enums.SecuritySystemModules
        ssm = Entity.Sys.Enums.SecuritySystemModules.Equipment
        If loggedInUser.HasAccessToModule(ssm) = False Then
            cboEquipmentType.Enabled = False
            txtDecription.Enabled = False
            txtSerialNo.Enabled = False
            dtpCalibrationDate.Enabled = False
            txtCallibrationPeriod.Enabled = False
            txtCalibrationCert.Enabled = False
            dtpWarrantyExpires.Enabled = False
            txtAssetNumber.Enabled = False
        End If
    End Sub

    Public Function Save() As Boolean Implements IUserControl.Save
        Try
            If Me.txtCallibrationPeriod.Text.Length = 0 Then
                ShowMessage("Please enter a calibration period", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
            If Not IsNumeric(txtCallibrationPeriod.Text) Then
                ShowMessage("The Calibration Period Must be a Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
            If txtDecription.Text.Length = 0 Then
                ShowMessage("You Must give this Equipment a Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If
            If Combo.GetSelectedItemValue(cboStatus) = 0 Or Combo.GetSelectedItemValue(cboEquipmentType) = 0 Then
                ShowMessage("Please select a Staus and Equipment Type", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Function
            End If

            Me.Cursor = Cursors.WaitCursor
            CurrentEquipment.IgnoreExceptionsOnSetMethods = True

            Dim change As String = UpdateAudit()

            If theEngineer Is Nothing Then
                CurrentEquipment.SetEngineerID = 0
            ElseIf theEngineer.EngineerID = 0 Then
                CurrentEquipment.SetEngineerID = 0
            Else
                CurrentEquipment.SetEngineerID = theEngineer.EngineerID
            End If

            With CurrentEquipment
                .StatusChangeDate = Date.Now
                .SetNotes = Me.txtNotes.Text.Trim
                .SetCalibrationMonths = Me.txtCallibrationPeriod.Text
                .SetCertificateNumber = Me.txtCalibrationCert.Text
                .SetEquipmentTypeID = Combo.GetSelectedItemValue(cboEquipmentType)
                .CalibrationDate = Me.dtpCalibrationDate.Value
                .SetAssetNo = txtAssetNumber.Text
                .WarrantyEndDate = Me.dtpWarrantyExpires.Value
                .SetName = Me.txtDecription.Text
                .SetSerialNumber = Me.txtSerialNo.Text
                .SetStatusID = Combo.GetSelectedItemValue(cboStatus)
            End With


            If CurrentEquipment.Exists Then
                DB.Engineer.EquipmentUpdate(CurrentEquipment)
            Else
                CurrentEquipment = DB.Engineer.EquipmentInsert(CurrentEquipment)
            End If

            If Not String.IsNullOrEmpty(change) Then DB.Engineer.EquipmentAudit_Insert(CurrentEquipment.EquipmentID, change)

            RaiseEvent RecordsChanged(DB.Engineer.Equipment_GetAll(), Entity.Sys.Enums.PageViewing.Equipment, True, False, "")
            RaiseEvent StateChanged(CurrentEquipment.EquipmentID)


            MainForm.RefreshEntity(CurrentEquipment.EquipmentID)

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
            Me.Cursor = Cursors.Default
        End Try
    End Function

    ''' <summary>
    ''' Check what has been changed and add it to log
    ''' </summary>
    ''' <returns></returns>
    Private Function UpdateAudit() As String
        'we need to see whats different

        Dim update As Boolean = False
        Dim change As String = ""

        With CurrentEquipment
            If .EquipmentID > 0 Then
                If .EquipmentTypeID <> Combo.GetSelectedItemValue(cboEquipmentType) Then
                    update = True
                    change += "Equipment type changed from: " & DB.Picklists.Get_One_As_Object(.EquipmentTypeID).Name &
                    " to: " & DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(cboEquipmentType)).Name
                End If

                If .Name <> txtDecription.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Name changed from: " & .Name & " to: " &
                    txtDecription.Text
                End If

                If .SerialNumber <> txtSerialNo.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Serial number changed from: " & .SerialNumber & " to: " &
                    txtSerialNo.Text
                End If

                If .CalibrationDate <> dtpCalibrationDate.Value Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Calibration date changed from: " & .EquipmentTypeID & " to: " &
                    dtpCalibrationDate.Value
                End If

                If .CalibrationMonths <> txtCallibrationPeriod.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Calibration period changed from: " & .CalibrationMonths & " to: " &
                    txtCallibrationPeriod.Text
                End If

                If .CertificateNumber <> txtCalibrationCert.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Certifcate changed from: " & .CertificateNumber & " to: " &
                    txtCalibrationCert.Text
                End If

                If .WarrantyEndDate <> dtpWarrantyExpires.Value Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Warranty end date changed from: " & .WarrantyEndDate & " to: " &
                    dtpWarrantyExpires.Value
                End If

                If .StatusID <> Combo.GetSelectedItemValue(cboStatus) Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Status changed from: " & DB.Picklists.Get_One_As_Object(.StatusID).Name &
                    " to: " & DB.Picklists.Get_One_As_Object(Combo.GetSelectedItemValue(cboStatus)).Name
                End If

                If .AssetNo <> txtAssetNumber.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Asset number changed from: " & .AssetNo & " to: " &
                    txtAssetNumber.Text
                End If

                If theEngineer Is Nothing And .EngineerID > 0 Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Equipment un-assigned from: " & DB.Engineer.Engineer_Get(.EngineerID).Name
                Else
                    If theEngineer IsNot Nothing Then
                        If .EngineerID <> theEngineer.EngineerID Then
                            If update Then
                                change += ", "
                            End If
                            update = True
                            If .EngineerID = 0 Then

                                change += "Engineer added: " & theEngineer.Name
                            Else

                                change += "Engineer changed from: " & DB.Engineer.Engineer_Get(.EngineerID).Name &
                                " to: " & theEngineer.Name
                            End If
                        End If
                    End If
                End If

                If .Notes <> txtNotes.Text Then
                    If update Then
                        change += ", "
                    End If
                    update = True
                    change += "Notes were updated"
                End If
            End If
        End With
        Return change
    End Function

#End Region

    Private Sub btnfindEngineer_Click_1(sender As Object, e As EventArgs) Handles btnfindEngineer.Click
        If IsEquipmentCalibrationValid(Me.dtpCalibrationDate.Value,
                                           CInt(Me.txtCallibrationPeriod.Text)) Then
            Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineer)
            If Not ID = 0 Then
                theEngineer = DB.Engineer.Engineer_Get(ID)
                Combo.SetSelectedComboItem_By_Value(cboStatus, CInt(Entity.Sys.Enums.EquipmentStatus.IssedToEngineer))
            End If
        Else
            ShowMessage("Equipment is out calibration, please update date before assigning to engineer",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    ''' <summary>
    ''' Check to see if equipment calibration is still vali
    ''' </summary>
    ''' <param name="caliDate"></param>
    ''' <param name="caliPeriod"></param>
    ''' <returns>True if valid</returns>
    Public Function IsEquipmentCalibrationValid(ByVal caliDate As Date, ByVal caliMonths As Integer) As Boolean
        If caliMonths = 0 Then caliMonths = 12 'default to 12 months calibration period
        Return caliDate.AddMonths(caliMonths) > Date.Now
    End Function

    Private Sub dtpCalibrationDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpCalibrationDate.ValueChanged

        'check if unit is out of calibration
        If IsEquipmentCalibrationValid(Me.dtpCalibrationDate.Value, CurrentEquipment.CalibrationMonths) Then
            lblCalibrationStatus.Text = "Still in Calibration"
            lblCalibrationStatus.ForeColor = Color.Green
        Else
            lblCalibrationStatus.Text = "Out of calibration"
            lblCalibrationStatus.ForeColor = Color.Red
        End If

    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        'check if unit is out of calibration
        If Not IsEquipmentCalibrationValid(Me.dtpCalibrationDate.Value,
                                           CInt(Me.txtCallibrationPeriod.Text)) Then
            If Combo.GetSelectedItemValue(cboStatus) = Entity.Sys.Enums.EquipmentStatus.ReadyForIssue Or
                Combo.GetSelectedItemValue(cboStatus) = Entity.Sys.Enums.EquipmentStatus.IssedToEngineer Then
                ShowMessage("Equipment is out calibration, please update date before assigning to engineer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CurrentEquipment.SetStatusID = CInt(Entity.Sys.Enums.EquipmentStatus.OutOfCalibration)
                Combo.SetSelectedComboItem_By_Value(cboStatus, CurrentEquipment.StatusID)
            End If
        Else
            If Combo.GetSelectedItemValue(cboStatus) = Entity.Sys.Enums.EquipmentStatus.ReadyForIssue Then
                If theEngineer IsNot Nothing Then theEngineer = Nothing
                Me.txtEngineer.Text = "<Not Set>"
            End If
        End If
    End Sub

    Private Sub btnUnassign_Click(sender As Object, e As EventArgs) Handles btnUnassign.Click
        If theEngineer IsNot Nothing Then theEngineer = Nothing
        Me.txtEngineer.Text = "<Not Set>"
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If CurrentEquipment Is Nothing Then Exit Sub
        If Not txtFaults.Text.Length > 0 Then
            ShowMessage("Please add faults!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        GenerateWorkOrder()
    End Sub

    Private Sub btnGenerateAndEmail_Click(sender As Object, e As EventArgs) Handles btnGenerateAndEmail.Click
        If CurrentEquipment Is Nothing Then Exit Sub
        If Not txtFaults.Text.Length > 0 Then
            ShowMessage("Please add faults!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not txtEmail.Text.Length > 0 Then
            ShowMessage("Please add email address!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        GenerateWorkOrder(True)
    End Sub

    Public Sub GenerateWorkOrder(Optional ByVal email As Boolean = False)
        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("EquipmentID"))
        dt.Columns.Add(New DataColumn("SerialNumber"))
        dt.Columns.Add(New DataColumn("Faults"))
        dt.Columns.Add(New DataColumn("EmailAddress"))
        dt.Columns.Add(New DataColumn("SendEmail"))

        Dim r As DataRow
        r = dt.NewRow
        r("EquipmentID") = CurrentEquipment.EquipmentID
        r("SerialNumber") = CurrentEquipment.SerialNumber
        r("Faults") = Me.txtFaults.Text
        r("EmailAddress") = Me.txtEmail.Text.Trim
        r("SendEmail") = email
        dt.Rows.Add(r)

        Dim oPrint As New Entity.Sys.Printing(dt, "Analyser ", Entity.Sys.Enums.SystemDocumentType.Analyser)
    End Sub
End Class

