Public Class FRMVisitManager : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpVisits As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVisits As System.Windows.Forms.DataGridView
    Friend WithEvents pnlFilters As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboJobType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNoDate As System.Windows.Forms.RadioButton
    Friend WithEvents rdoVisitDate As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPONumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents grpJob As System.Windows.Forms.GroupBox
    Friend WithEvents cboJobDefinition As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboOutcome As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnfindEngineer As System.Windows.Forms.Button
    Friend WithEvents txtEngineer As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateOrder As System.Windows.Forms.Button
    Friend WithEvents btnRequiringParts As System.Windows.Forms.Button
    Friend WithEvents cboContractType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboLetterNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents rdoDueDate As System.Windows.Forms.RadioButton
    Friend WithEvents cboCharge As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboCostsTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpVisits = New System.Windows.Forms.GroupBox()
        Me.dgvVisits = New System.Windows.Forms.DataGridView()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnCreateOrder = New System.Windows.Forms.Button()
        Me.btnRequiringParts = New System.Windows.Forms.Button()
        Me.grpJob = New System.Windows.Forms.GroupBox()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboContractType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboJobDefinition = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPONumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboCostsTo = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboCharge = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboLetterNumber = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnfindEngineer = New System.Windows.Forms.Button()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboOutcome = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoDueDate = New System.Windows.Forms.RadioButton()
        Me.rdoNoDate = New System.Windows.Forms.RadioButton()
        Me.rdoVisitDate = New System.Windows.Forms.RadioButton()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.grpVisits.SuspendLayout()
        CType(Me.dgvVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.grpJob.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpVisits
        '
        Me.grpVisits.Controls.Add(Me.dgvVisits)
        Me.grpVisits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpVisits.Location = New System.Drawing.Point(0, 389)
        Me.grpVisits.Name = "grpVisits"
        Me.grpVisits.Size = New System.Drawing.Size(834, 212)
        Me.grpVisits.TabIndex = 44
        Me.grpVisits.TabStop = False
        Me.grpVisits.Text = "Results (awaiting search) - Double Click To View / Edit"
        '
        'dgvVisits
        '
        Me.dgvVisits.AllowUserToAddRows = False
        Me.dgvVisits.AllowUserToDeleteRows = False
        Me.dgvVisits.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVisits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVisits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVisits.BackgroundColor = System.Drawing.Color.White
        Me.dgvVisits.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVisits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVisits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVisits.EnableHeadersVisualStyles = False
        Me.dgvVisits.GridColor = System.Drawing.Color.LightSteelBlue
        Me.dgvVisits.Location = New System.Drawing.Point(3, 17)
        Me.dgvVisits.MultiSelect = False
        Me.dgvVisits.Name = "dgvVisits"
        Me.dgvVisits.ReadOnly = True
        Me.dgvVisits.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVisits.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVisits.RowTemplate.Height = 29
        Me.dgvVisits.RowTemplate.ReadOnly = True
        Me.dgvVisits.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVisits.Size = New System.Drawing.Size(828, 192)
        Me.dgvVisits.TabIndex = 0
        Me.dgvVisits.VirtualMode = True
        '
        'pnlFilters
        '
        Me.pnlFilters.Controls.Add(Me.btnCreateOrder)
        Me.pnlFilters.Controls.Add(Me.btnRequiringParts)
        Me.pnlFilters.Controls.Add(Me.grpJob)
        Me.pnlFilters.Controls.Add(Me.btnExport)
        Me.pnlFilters.Controls.Add(Me.GroupBox2)
        Me.pnlFilters.Controls.Add(Me.btnReset)
        Me.pnlFilters.Controls.Add(Me.btnSearch)
        Me.pnlFilters.Controls.Add(Me.GroupBox3)
        Me.pnlFilters.Controls.Add(Me.GroupBox1)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 32)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(834, 357)
        Me.pnlFilters.TabIndex = 43
        '
        'btnCreateOrder
        '
        Me.btnCreateOrder.Location = New System.Drawing.Point(300, 324)
        Me.btnCreateOrder.Name = "btnCreateOrder"
        Me.btnCreateOrder.Size = New System.Drawing.Size(112, 23)
        Me.btnCreateOrder.TabIndex = 43
        Me.btnCreateOrder.Text = "Create Order"
        '
        'btnRequiringParts
        '
        Me.btnRequiringParts.Location = New System.Drawing.Point(150, 324)
        Me.btnRequiringParts.Name = "btnRequiringParts"
        Me.btnRequiringParts.Size = New System.Drawing.Size(144, 23)
        Me.btnRequiringParts.TabIndex = 42
        Me.btnRequiringParts.Text = "Visits Requiring Parts"
        '
        'grpJob
        '
        Me.grpJob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJob.Controls.Add(Me.cboPriority)
        Me.grpJob.Controls.Add(Me.cboRegion)
        Me.grpJob.Controls.Add(Me.Label17)
        Me.grpJob.Controls.Add(Me.cboContractType)
        Me.grpJob.Controls.Add(Me.Label13)
        Me.grpJob.Controls.Add(Me.cboJobDefinition)
        Me.grpJob.Controls.Add(Me.Label2)
        Me.grpJob.Controls.Add(Me.txtPONumber)
        Me.grpJob.Controls.Add(Me.Label7)
        Me.grpJob.Controls.Add(Me.cboJobType)
        Me.grpJob.Controls.Add(Me.Label10)
        Me.grpJob.Controls.Add(Me.txtJobNumber)
        Me.grpJob.Controls.Add(Me.Label6)
        Me.grpJob.Location = New System.Drawing.Point(423, 185)
        Me.grpJob.Name = "grpJob"
        Me.grpJob.Size = New System.Drawing.Size(401, 133)
        Me.grpJob.TabIndex = 41
        Me.grpJob.TabStop = False
        Me.grpJob.Text = "Job"
        '
        'cboPriority
        '
        Me.cboPriority.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriority.Location = New System.Drawing.Point(109, 106)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(284, 21)
        Me.cboPriority.TabIndex = 18
        '
        'cboRegion
        '
        Me.cboRegion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.Location = New System.Drawing.Point(68, 48)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(125, 21)
        Me.cboRegion.TabIndex = 36
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(6, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 19)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Priority"
        '
        'cboContractType
        '
        Me.cboContractType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboContractType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContractType.Location = New System.Drawing.Point(108, 78)
        Me.cboContractType.Name = "cboContractType"
        Me.cboContractType.Size = New System.Drawing.Size(284, 21)
        Me.cboContractType.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(5, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 19)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Contract Type"
        '
        'cboJobDefinition
        '
        Me.cboJobDefinition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJobDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobDefinition.Location = New System.Drawing.Point(69, 48)
        Me.cboJobDefinition.Name = "cboJobDefinition"
        Me.cboJobDefinition.Size = New System.Drawing.Size(124, 21)
        Me.cboJobDefinition.TabIndex = 14
        Me.cboJobDefinition.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Region"
        '
        'txtPONumber
        '
        Me.txtPONumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPONumber.Location = New System.Drawing.Point(276, 46)
        Me.txtPONumber.Name = "txtPONumber"
        Me.txtPONumber.Size = New System.Drawing.Size(117, 21)
        Me.txtPONumber.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(199, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "PO Number"
        '
        'cboJobType
        '
        Me.cboJobType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobType.Location = New System.Drawing.Point(69, 21)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(124, 21)
        Me.cboJobType.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(4, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 19)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type"
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobNumber.Location = New System.Drawing.Point(276, 18)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(117, 21)
        Me.txtJobNumber.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(199, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Number"
        '
        'btnExport
        '
        Me.btnExport.UseVisualStyleBackColor = True
        Me.btnExport.Location = New System.Drawing.Point(12, 324)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(132, 23)
        Me.btnExport.TabIndex = 40
        Me.btnExport.Text = "Export"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnFindSite)
        Me.GroupBox2.Controls.Add(Me.txtSite)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtPostcode)
        Me.GroupBox2.Controls.Add(Me.txtCustomer)
        Me.GroupBox2.Controls.Add(Me.btnFindCustomer)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(405, 176)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(374, 43)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(25, 23)
        Me.btnFindSite.TabIndex = 35
        Me.btnFindSite.Text = "..."
        Me.btnFindSite.UseVisualStyleBackColor = False
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(107, 45)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(262, 21)
        Me.txtSite.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 22)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Property"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(11, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Customer"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Postcode"
        '
        'txtPostcode
        '
        Me.txtPostcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostcode.Location = New System.Drawing.Point(107, 72)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(292, 21)
        Me.txtPostcode.TabIndex = 5
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(107, 18)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(262, 21)
        Me.txtCustomer.TabIndex = 1
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.UseVisualStyleBackColor = True
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(374, 17)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(25, 23)
        Me.btnFindCustomer.TabIndex = 2
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.UseVisualStyleBackColor = True
        Me.btnReset.Location = New System.Drawing.Point(565, 324)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(132, 23)
        Me.btnReset.TabIndex = 16
        Me.btnReset.Text = "Reset All Filters"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(703, 324)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(125, 23)
        Me.btnSearch.TabIndex = 39
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.cboCostsTo)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.cboCharge)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.cboLetterNumber)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.btnfindEngineer)
        Me.GroupBox3.Controls.Add(Me.txtEngineer)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.cboOutcome)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cboStatus)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(421, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(401, 176)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Visit"
        '
        'cboCostsTo
        '
        Me.cboCostsTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCostsTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCostsTo.Location = New System.Drawing.Point(71, 149)
        Me.cboCostsTo.Name = "cboCostsTo"
        Me.cboCostsTo.Size = New System.Drawing.Size(324, 21)
        Me.cboCostsTo.TabIndex = 43
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 153)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Costs To"
        '
        'cboCharge
        '
        Me.cboCharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCharge.Location = New System.Drawing.Point(71, 124)
        Me.cboCharge.Name = "cboCharge"
        Me.cboCharge.Size = New System.Drawing.Size(324, 21)
        Me.cboCharge.TabIndex = 41
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Charge"
        '
        'cboLetterNumber
        '
        Me.cboLetterNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLetterNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLetterNumber.Location = New System.Drawing.Point(71, 97)
        Me.cboLetterNumber.Name = "cboLetterNumber"
        Me.cboLetterNumber.Size = New System.Drawing.Size(324, 21)
        Me.cboLetterNumber.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(6, 101)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 16)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Letter No."
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(369, 68)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(25, 23)
        Me.btnfindEngineer.TabIndex = 37
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(71, 70)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(292, 21)
        Me.txtEngineer.TabIndex = 36
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(7, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 18)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Engineer"
        '
        'cboOutcome
        '
        Me.cboOutcome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOutcome.Location = New System.Drawing.Point(70, 43)
        Me.cboOutcome.Name = "cboOutcome"
        Me.cboOutcome.Size = New System.Drawing.Size(324, 21)
        Me.cboOutcome.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Outcome"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(70, 16)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(324, 21)
        Me.cboStatus.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(6, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Status"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rdoDueDate)
        Me.GroupBox1.Controls.Add(Me.rdoNoDate)
        Me.GroupBox1.Controls.Add(Me.rdoVisitDate)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 185)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 127)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Criteria"
        '
        'rdoDueDate
        '
        Me.rdoDueDate.AutoSize = True
        Me.rdoDueDate.Location = New System.Drawing.Point(8, 69)
        Me.rdoDueDate.Name = "rdoDueDate"
        Me.rdoDueDate.Size = New System.Drawing.Size(79, 17)
        Me.rdoDueDate.TabIndex = 16
        Me.rdoDueDate.Text = "Due Date"
        Me.rdoDueDate.UseVisualStyleBackColor = True
        '
        'rdoNoDate
        '
        Me.rdoNoDate.AutoSize = True
        Me.rdoNoDate.Checked = True
        Me.rdoNoDate.Location = New System.Drawing.Point(8, 22)
        Me.rdoNoDate.Name = "rdoNoDate"
        Me.rdoNoDate.Size = New System.Drawing.Size(54, 17)
        Me.rdoNoDate.TabIndex = 11
        Me.rdoNoDate.TabStop = True
        Me.rdoNoDate.Text = "None"
        Me.rdoNoDate.UseVisualStyleBackColor = True
        '
        'rdoVisitDate
        '
        Me.rdoVisitDate.AutoSize = True
        Me.rdoVisitDate.Location = New System.Drawing.Point(8, 46)
        Me.rdoVisitDate.Name = "rdoVisitDate"
        Me.rdoVisitDate.Size = New System.Drawing.Size(80, 17)
        Me.rdoVisitDate.TabIndex = 12
        Me.rdoVisitDate.Text = "Visit Date"
        Me.rdoVisitDate.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(230, 20)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(169, 21)
        Me.dtpFrom.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(176, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "From"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(176, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(230, 47)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(169, 21)
        Me.dtpTo.TabIndex = 15
        '
        'FRMVisitManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(834, 601)
        Me.Controls.Add(Me.grpVisits)
        Me.Controls.Add(Me.pnlFilters)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMVisitManager"
        Me.Text = "Visit Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlFilters, 0)
        Me.Controls.SetChildIndex(Me.grpVisits, 0)
        Me.grpVisits.ResumeLayout(False)
        CType(Me.dgvVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.grpJob.ResumeLayout(False)
        Me.grpJob.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupVisitsDataGridView()
        Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboJobType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboJobDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboContractType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ContractTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboLetterNumber, DynamicDataTables.LetterType, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboCharge, DynamicDataTables.ChargeInProgress, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboCostsTo, DynamicDataTables.CostsTo, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboCharge, 1)
        Combo.SetUpCombo(Me.cboPriority, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JOWPriority).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Me.rdoVisitDate.Checked = True
        Me.dtpFrom.Value = Now.AddMonths(-1)


        'LoadLastFilters()


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

    Private _theCustomer As New Entity.Customers.Customer
    Public Property theCustomer() As Entity.Customers.Customer
        Get
            Return _theCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _theCustomer = Value
            If Not _theCustomer.CustomerID = 0 Then
                Me.txtCustomer.Text = theCustomer.Name & " (A/C No : " & theCustomer.AccountNumber & ")"
            Else
                Me.txtCustomer.Text = ""
            End If
        End Set
    End Property

    Private _oSite As New Entity.Sites.Site
    Public Property theSite() As Entity.Sites.Site
        Get
            Return _oSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _oSite = Value
            If Not _oSite.SiteID = 0 Then
                Me.txtSite.Text = theSite.Address1 & ", " & theSite.Address2 & ", " & theSite.Postcode
            Else
                Me.txtSite.Text = ""
            End If
        End Set
    End Property

    Private _theEngineer As New Entity.Engineers.Engineer
    Public Property theEngineer() As Entity.Engineers.Engineer
        Get
            Return _theEngineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _theEngineer = Value
            If Not _theEngineer.EngineerID = 0 Then
                Me.txtEngineer.Text = theEngineer.Name
            Else
                Me.txtEngineer.Text = ""
            End If
        End Set
    End Property


    Private _dtVisit As New DataTable
    Public Property dtVisitFilters() As DataTable
        Get
            If _dtVisit.Columns.Count = 0 Then
                _dtVisit.Columns.Add("Field")
                _dtVisit.Columns.Add("Value")
                _dtVisit.Columns.Add("Type")
            End If
            Return _dtVisit
        End Get
        Set(ByVal value As DataTable)
            _dtVisit = value
        End Set
    End Property



#End Region

#Region "Visits DataGridView"

    Private _Visits As New Entity.EngineerVisits.EngineerVisitSQL.Visits_PagedQuery(3000)

    Private Sub SetupVisitsDataGridView()


        Dim Customer As New DataGridViewTextBoxColumn
        Customer.FillWeight = 150
        Customer.HeaderText = "Customer"
        Customer.DataPropertyName = "Customer"
        Customer.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(Customer)

        Dim Site As New DataGridViewTextBoxColumn
        Site.FillWeight = 200
        Site.HeaderText = "Property"
        Site.DataPropertyName = "Site"
        Site.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(Site)

        Dim JobNumber As New DataGridViewTextBoxColumn
        JobNumber.FillWeight = 100
        JobNumber.HeaderText = "Job Number"
        JobNumber.DataPropertyName = "JobNumber"
        JobNumber.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(JobNumber)

        Dim JobDefinition As New DataGridViewTextBoxColumn
        JobDefinition.FillWeight = 75
        JobDefinition.HeaderText = "Definition"
        JobDefinition.DataPropertyName = "JobDefinition"
        JobDefinition.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(JobDefinition)

        Dim Type As New DataGridViewTextBoxColumn
        Type.FillWeight = 75
        Type.HeaderText = "Type"
        Type.DataPropertyName = "Type"
        Type.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(Type)

        Dim ContractType As New DataGridViewTextBoxColumn
        ContractType.FillWeight = 100
        ContractType.HeaderText = "Contract Type"
        ContractType.DataPropertyName = "ContractType"
        ContractType.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(ContractType)

        Dim PartsToFit As New DataGridViewCheckBoxColumn
        PartsToFit.FillWeight = 55
        PartsToFit.ReadOnly = True
        PartsToFit.HeaderText = "Parts To Fit"
        PartsToFit.DataPropertyName = "PartsToFit"
        PartsToFit.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(PartsToFit)

        Dim Recharge As New DataGridViewCheckBoxColumn
        Recharge.FillWeight = 55
        Recharge.ReadOnly = True
        Recharge.HeaderText = "Recharge"
        Recharge.DataPropertyName = "Recharge"
        Recharge.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(Recharge)

        Dim VisitStatus As New DataGridViewTextBoxColumn
        VisitStatus.FillWeight = 100
        VisitStatus.HeaderText = "Status"
        VisitStatus.DataPropertyName = "VisitStatus"
        VisitStatus.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(VisitStatus)


        Dim VisitOutcome As New DataGridViewTextBoxColumn
        VisitOutcome.FillWeight = 75
        VisitOutcome.HeaderText = "Outcome"
        VisitOutcome.DataPropertyName = "VisitOutcome"
        VisitOutcome.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(VisitOutcome)


        Dim VisitDate As New DataGridViewTextBoxColumn
        VisitDate.FillWeight = 100
        VisitDate.HeaderText = "Visit Date"
        VisitDate.DataPropertyName = "VisitDate"
        VisitDate.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(VisitDate)


        Dim Engineer As New DataGridViewTextBoxColumn
        Engineer.FillWeight = 75
        Engineer.HeaderText = "Engineer"
        Engineer.DataPropertyName = "Engineer"
        Engineer.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(Engineer)


        Dim EmailReceipt As New DataGridViewCheckBoxColumn
        EmailReceipt.FillWeight = 55
        EmailReceipt.HeaderText = "Email Receipt"
        EmailReceipt.ReadOnly = True
        EmailReceipt.DataPropertyName = "EmailReceipt"
        EmailReceipt.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(EmailReceipt)


        Dim PONumber As New DataGridViewTextBoxColumn
        PONumber.FillWeight = 75
        PONumber.HeaderText = "PO Number"
        PONumber.DataPropertyName = "PONumber"
        PONumber.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(PONumber)

        Dim ExpectedEngineer As New DataGridViewTextBoxColumn
        ExpectedEngineer.FillWeight = 75
        ExpectedEngineer.HeaderText = "Expected Engineer"
        ExpectedEngineer.DataPropertyName = "ExpectedEngineer"
        ExpectedEngineer.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(ExpectedEngineer)

        Dim LetterType As New DataGridViewTextBoxColumn
        LetterType.FillWeight = 75
        LetterType.HeaderText = "Visit For Letter #"
        LetterType.DataPropertyName = "LetterType"
        LetterType.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(LetterType)

        Dim DueDate As New DataGridViewTextBoxColumn
        DueDate.FillWeight = 100
        DueDate.HeaderText = "Due Date"
        DueDate.DataPropertyName = "DueDate"
        DueDate.DefaultCellStyle.Format = "dd/MMM/yyyy"
        DueDate.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(DueDate)

        Dim AMPM As New DataGridViewTextBoxColumn
        AMPM.FillWeight = 75
        AMPM.HeaderText = "AM/PM"
        AMPM.DataPropertyName = "AMPM"
        AMPM.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(AMPM)

        Dim SitePostcode As New DataGridViewTextBoxColumn
        SitePostcode.FillWeight = 75
        SitePostcode.HeaderText = "Postcode"
        SitePostcode.DataPropertyName = "Postcode"
        SitePostcode.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(SitePostcode)

        Dim JobItems As New DataGridViewTextBoxColumn
        JobItems.FillWeight = 200
        JobItems.HeaderText = "JobItems"
        JobItems.DataPropertyName = "JobItems"
        JobItems.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(JobItems)

        Dim CostsTo As New DataGridViewTextBoxColumn
        CostsTo.FillWeight = 200
        CostsTo.HeaderText = "Costs To"
        CostsTo.DataPropertyName = "CostsTo"
        CostsTo.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(CostsTo)

        'Dim Priority As New DataGridViewTextBoxColumn
        'Priority.FillWeight = 200
        'Priority.HeaderText = "Priority"
        'Priority.DataPropertyName = "Priority"
        'Priority.SortMode = DataGridViewColumnSortMode.Programmatic
        'dgvVisits.Columns.Add(Priority)

        Dim PriorityName As New DataGridViewTextBoxColumn
        PriorityName.FillWeight = 200
        PriorityName.HeaderText = "Priority"
        PriorityName.DataPropertyName = "PriorityName"
        PriorityName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgvVisits.Columns.Add(PriorityName)


    End Sub

    Private Sub dgvVisits_CellValueNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles dgvVisits.CellValueNeeded
        e.Value = _Visits.GetCellValue(e.RowIndex, dgvVisits.Columns(e.ColumnIndex).DataPropertyName)
    End Sub

    Private Sub dgvVisits_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvVisits.ColumnHeaderMouseClick

        dgvVisits.RowCount = 0
        dgvVisits.ClearSelection()

        dgvVisits.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = _Visits.Sort(dgvVisits.Columns(e.ColumnIndex).DataPropertyName)

        dgvVisits.RowCount = _Visits.TotalCount
        dgvVisits.Invalidate()
    End Sub

    Public ReadOnly Property SelectedVisitRow() As DataRow
        Get
            If dgvVisits.SelectedRows.Count > 0 Then
                Return _Visits.GetRow(dgvVisits.SelectedRows(0).Index)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        PopulateDatagrid()
    End Sub

#End Region

#Region "Events"

    Private Sub FRMVisitManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    'Private Sub rdoDateCreated_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoVisitDate.CheckedChanged
    '    dtpFrom.Enabled = rdoVisitDate.Checked
    '    dtpTo.Enabled = rdoVisitDate.Checked
    'End Sub

    Private Sub rdoNoDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoNoDate.CheckedChanged
        dtpFrom.Enabled = Not rdoNoDate.Checked
        dtpTo.Enabled = Not rdoNoDate.Checked
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            theCustomer = DB.Customer.Customer_Get(ID)
        End If
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        Dim ID As Integer
        If theCustomer Is Nothing Then
            ID = FindRecord(Entity.Sys.Enums.TableNames.tblSite)
        Else
            ID = FindRecord(Entity.Sys.Enums.TableNames.tblSite, theCustomer.CustomerID)
        End If

        If Not ID = 0 Then
            theSite = DB.Sites.Get(ID)
        End If
    End Sub

    Private Sub btnfindEngineer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfindEngineer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            theEngineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

    Private Sub dgvVisits_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvVisits.DoubleClick
        If SelectedVisitRow Is Nothing Then
            ShowMessage("Please select a visit to view", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim [continue] As Boolean = False

        Select Case CInt(SelectedVisitRow.Item("StatusEnumID"))
            Case CInt(Entity.Sys.Enums.VisitStatus.NOT_SET)
                If ShowMessage("This visit has not entered a visit life span yet.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitRow.Item("JobID"), SelectedVisitRow.Item("SiteID"), Me})
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Parts_Need_Ordering)
                If ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitRow.Item("JobID"), SelectedVisitRow.Item("SiteID"), Me})
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts)
                If ShowMessage("This visit is waiting for parts, once recieved you may proceed.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitRow.Item("JobID"), SelectedVisitRow.Item("SiteID"), Me})
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule)
                If ShowMessage("This visit is ready for schedule, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    [continue] = True
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Scheduled)
                If ShowMessage("This visit is scheduled, would you like to manually complete the visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    [continue] = True
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Downloaded)
                If ShowMessage("This visit is currently with an engineer, once returned you may view the details.  View related job details?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    ShowForm(GetType(FRMLogCallout), True, New Object() {SelectedVisitRow.Item("JobID"), SelectedVisitRow.Item("SiteID"), Me})
                End If
            Case CInt(Entity.Sys.Enums.VisitStatus.Uploaded)
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Not_To_Be_Invoiced
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Ready_To_Be_Invoiced
                [continue] = True
            Case Entity.Sys.Enums.VisitStatus.Invoiced
                [continue] = True
        End Select

        If [continue] Then
            ShowForm(GetType(FRMEngineerVisit), True, New Object() {SelectedVisitRow.Item("EngineerVisitID")})

            LoadLastFilters()

        End If
    End Sub

    Private Sub btnRequiringParts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequiringParts.Click
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts))
        PopulateDatagrid()
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            Cursor.Current = Cursors.WaitCursor
            dgvVisits.Enabled = False

            dgvVisits.RowCount = 0
            dgvVisits.ClearSelection()

            Dim DateFrom As DateTime? = Nothing
            Dim DateTo As DateTime? = Nothing

            If Me.rdoVisitDate.Checked Then
                DateFrom = Format(Me.dtpFrom.Value, "dd/MM/yyyy 00:00:00")
                DateTo = Format(Me.dtpTo.Value, "dd/MM/yyyy 23:59:59")
            End If

            Dim DueDateFrom As DateTime? = Nothing
            Dim DueDateTo As DateTime? = Nothing

            If Me.rdoDueDate.Checked Then
                DueDateFrom = Format(Me.dtpFrom.Value, "dd/MM/yyyy 00:00:00")
                DueDateTo = Format(Me.dtpTo.Value, "dd/MM/yyyy 23:59:59")
            End If

            Dim CostsTo As String
            If CStr(Combo.GetSelectedItemValue(cboCostsTo)) = "0" Then
                CostsTo = "%"
            Else
                CostsTo = Combo.GetSelectedItemValue(cboCostsTo)
            End If

            Dim Priority As String
            If CStr(Combo.GetSelectedItemValue(cboPriority)) = "0" Then
                Priority = "%"
            Else
                Priority = Combo.GetSelectedItemValue(cboPriority)
            End If

            _Visits.Refresh(theCustomer.CustomerID, theSite.SiteID, _
                            theEngineer.EngineerID, Combo.GetSelectedItemValue(cboJobDefinition), _
                            Combo.GetSelectedItemValue(cboJobType), _
                            Combo.GetSelectedItemValue(cboStatus), _
                            Combo.GetSelectedItemValue(cboOutcome), _
                            txtJobNumber.Text, txtPONumber.Text, _
                            txtPostcode.Text, _
                            DateFrom, DateTo, Combo.GetSelectedItemValue(cboRegion), Combo.GetSelectedItemValue(cboContractType), _
                            Combo.GetSelectedItemValue(cboLetterNumber), _
                            DueDateFrom, _
                            DueDateTo, _
                            Combo.GetSelectedItemValue(cboCharge), _
                            CostsTo, _
                            Priority)

            dgvVisits.RowCount = _Visits.TotalCount

            grpVisits.Text = String.Format("Results ({0}) - Double Click To View / Edit", dgvVisits.RowCount)
            dgvVisits.Enabled = True

            'LOG THE CURRENT SEARCH CRITERIA
            LogSearchCriteria()


            Cursor.Current = Cursors.Default
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadLastFilters()
        If Controls.Count > 0 Then

            If dtVisitFilters.Rows.Count > 0 Then
                For Each dr As DataRow In dtVisitFilters.Rows
                    Select Case dr("Type")
                        Case "Object"
                            Select Case dr("Field")
                                Case "theCustomer"
                                    Dim cust As Entity.Customers.Customer = DB.Customer.Customer_Get(dr("Value"))
                                    If Not cust Is Nothing Then
                                        theCustomer = cust
                                    End If

                                Case "theSite"
                                    Dim s As Entity.Sites.Site = DB.Sites.Get(dr("Value"))
                                    If Not s Is Nothing Then
                                        theSite = s
                                    End If

                                Case "theEngineer"
                                    Dim eng As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(dr("Value"))
                                    If Not eng Is Nothing Then
                                        theEngineer = eng
                                    End If

                            End Select
                        Case "Combo"
                            Combo.SetSelectedComboItem_By_Value(Controls.Find(dr("Field"), True)(0), dr("Value"))
                        Case "Text"
                            CType(Controls.Find(dr("Field"), True)(0), TextBox).Text = dr("Value")
                        Case "Radio"
                            CType(Controls.Find(dr("Field"), True)(0), RadioButton).Checked = dr("Value")
                        Case "DTP"
                            CType(Controls.Find(dr("Field"), True)(0), DateTimePicker).Value = dr("Value")
                        Case "CHECK"
                            CType(Controls.Find(dr("Field"), True)(0), CheckBox).Checked = dr("Value")
                    End Select
                Next
                PopulateDatagrid()
            End If

        End If
    End Sub

    Private Sub LogSearchCriteria()
        dtVisitFilters.Rows.Clear()
        Dim dt As DataTable = dtVisitFilters
        Dim dr As DataRow

        dr = dt.NewRow
        dr("Field") = "theCustomer"
        dr("Value") = theCustomer.CustomerID
        dr("Type") = "Object"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "theSite"
        dr("Value") = theSite.SiteID
        dr("Type") = "Object"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "theEngineer"
        dr("Value") = theEngineer.EngineerID
        dr("Type") = "Object"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboJobDefinition"
        dr("Value") = Combo.GetSelectedItemValue(cboJobDefinition)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboJobType"
        dr("Value") = Combo.GetSelectedItemValue(cboJobType)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboStatus"
        dr("Value") = Combo.GetSelectedItemValue(cboStatus)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboOutcome"
        dr("Value") = Combo.GetSelectedItemValue(cboOutcome)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboContractType"
        dr("Value") = Combo.GetSelectedItemValue(cboContractType)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboLetterNumber"
        dr("Value") = Combo.GetSelectedItemValue(cboLetterNumber)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "cboCharge"
        dr("Value") = Combo.GetSelectedItemValue(cboCharge)
        dr("Type") = "Combo"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "txtJobNumber"
        dr("Value") = txtJobNumber.Text
        dr("Type") = "Text"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "txtPONumber"
        dr("Value") = txtPONumber.Text
        dr("Type") = "Text"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "txtPostcode"
        dr("Value") = txtPostcode.Text
        dr("Type") = "Text"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "rdoVisitDate"
        dr("Value") = rdoVisitDate.Checked
        dr("Type") = "Radio"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "rdoDueDate"
        dr("Value") = rdoDueDate.Checked
        dr("Type") = "Radio"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "dtpFrom"
        dr("Value") = dtpFrom.Value
        dr("Type") = "DTP"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Field") = "dtpTo"
        dr("Value") = dtpTo.Value
        dr("Type") = "DTP"
        dt.Rows.Add(dr)



    End Sub

    Private Sub ResetFilters()
        theCustomer = New Entity.Customers.Customer
        theSite = New Entity.Sites.Site
        theEngineer = New Entity.Engineers.Engineer

        Combo.SetSelectedComboItem_By_Value(Me.cboJobType, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboJobDefinition, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboOutcome, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboContractType, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboLetterNumber, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboCharge, 1)
        Combo.SetSelectedComboItem_By_Value(Me.cboPriority, 0)

        Me.txtJobNumber.Text = ""
        Me.txtPostcode.Text = ""
        Me.rdoVisitDate.Checked = True
        Me.dtpFrom.Value = Today
        Me.dtpTo.Value = Today
        Me.dtpFrom.Enabled = True
        Me.dtpTo.Enabled = True
        Me.dtpFrom.Value = Now.AddMonths(-1)
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        'Dim exporter As New Entity.Sys.Exporting(_Visits.UnpagedData, "Visit List")
        'exporter = Nothing
        Dim whereClause As String = "AND (1 = 1 "

        If Not theCustomer Is Nothing Then
            If theCustomer.CustomerID > 0 Then
                whereClause += " AND tblCustomer.CustomerID = " & theCustomer.CustomerID & ""
            End If
        End If
        If Not theSite Is Nothing Then
            If theSite.SiteID > 0 Then
                whereClause += " AND tblSite.SiteID = " & theSite.SiteID & ""
            End If
        End If
        If Not Combo.GetSelectedItemValue(Me.cboJobDefinition) = 0 Then
            whereClause += " AND tblJob.JobDefinitionEnumID = " & Combo.GetSelectedItemValue(Me.cboJobDefinition) & ""
        End If

        If Not Combo.GetSelectedItemValue(Me.cboContractType) = 0 Then
            whereClause += " AND ContractTypeID = " & Combo.GetSelectedItemValue(Me.cboContractType) & ""
        End If

        If Not theEngineer Is Nothing Then
            If theEngineer.EngineerID > 0 Then
                whereClause += " AND tblEngineer.EngineerID = " & theEngineer.EngineerID & ""
            End If
        End If
        If Not Combo.GetSelectedItemValue(Me.cboJobType) = 0 Then
            whereClause += " AND tblJob.JobTypeID = " & Combo.GetSelectedItemValue(Me.cboJobType) & ""
        End If
        If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 Then
            whereClause += " AND @THEStatusEnumIDString = " & Combo.GetSelectedItemValue(Me.cboStatus) & ""
        End If
        If Not Combo.GetSelectedItemValue(Me.cboOutcome) = 0 Then
            whereClause += " AND tblEngineerVisit.OutcomeEnumID = " & Combo.GetSelectedItemValue(Me.cboOutcome) & ""
        End If
        If Not Me.txtJobNumber.Text.Trim.Length = 0 Then
            whereClause += " AND tblJob.JobNumber LIKE '%" & Me.txtJobNumber.Text.Trim & "%'"
        End If
        If Not Me.txtPONumber.Text.Trim.Length = 0 Then
            whereClause += " AND tblJobOfWork.PONumber LIKE '%" & Me.txtPONumber.Text.Trim & "%'"
        End If
        If Me.rdoVisitDate.Checked Then
            whereClause += " AND tblEngineerVisit.StartDateTime >= '" & Format(Me.dtpFrom.Value, "dd-MMM-yyyy 00:00:00") & "' AND tblEngineerVisit.StartDateTime <= '" & Format(Me.dtpTo.Value, "dd-MMM-yyyy 23:59:59") & "'"
        End If
        If Me.rdoDueDate.Checked Then
            whereClause += " AND tblEngineerVisit.DueDate >= '" & Format(Me.dtpFrom.Value, "dd-MMM-yyyy 00:00:00") & "' AND tblEngineerVisit.DueDate <= '" & Format(Me.dtpTo.Value, "dd-MMM-yyyy 23:59:59") & "'"
        End If
        If Not Me.txtPostcode.Text.Trim.Length = 0 Then
            whereClause += " AND tblSite.Postcode LIKE '%" & Me.txtPostcode.Text.Trim & "%'"
        End If

        If loggedInUser.RegionID <> 0 Then
            whereClause += " AND tblSite.RegionID = '" & loggedInUser.RegionID & "'"
        End If

        If Not Combo.GetSelectedItemValue(Me.cboLetterNumber).Replace("Letter ", "") = "0" Then
            whereClause += " AND tblLettersGenerated.LetterType  = '" & Combo.GetSelectedItemValue(Me.cboLetterNumber) & "'"
        End If

        'If Not CStr(Combo.GetSelectedItemValue(Me.cboCostsTo)) = "0" Then
        '    whereClause += " AND tblEngineerVisit.CostsTo  = '" & Combo.GetSelectedItemValue(Me.cboCostsTo) & "'"
        'End If

        whereClause += ")"

        Dim visits As DataView = DB.EngineerVisits.EngineerVisits_Get_All(whereClause)

        Dim exportData As New DataTable
        exportData.Columns.Add("Customer")
        exportData.Columns.Add("Site")
        exportData.Columns.Add("JobNumber")
        exportData.Columns.Add("JobDefinition")
        exportData.Columns.Add("Type")
        exportData.Columns.Add("ContractType")
        exportData.Columns.Add("VisitStatus")
        exportData.Columns.Add("StartDateTime", GetType(Date))
        exportData.Columns.Add("Engineer")
        exportData.Columns.Add("VisitValue", GetType(Double))
        exportData.Columns.Add("VisitCharge")
        exportData.Columns.Add("EngineerCost", GetType(Double))
        exportData.Columns.Add("PartProductCost", GetType(Double))
        exportData.Columns.Add("PONumber")
        exportData.Columns.Add("SupplierInvoice", GetType(Double))
        exportData.Columns.Add("CreditedAmount", GetType(Double))
        exportData.Columns.Add("NotesToEngineer")
        exportData.Columns.Add("OutcomeDetails")
        exportData.Columns.Add("VisitOutcome")
        exportData.Columns.Add("ExpectedEngineer")
        exportData.Columns.Add("LetterType")
        exportData.Columns.Add("DueDate")
        exportData.Columns.Add("AMPM")
        exportData.Columns.Add("SiteName")
        exportData.Columns.Add("Address1")
        exportData.Columns.Add("Address2")
        exportData.Columns.Add("Postcode")

        exportData.Columns.Add("TelephoneNumber")
        exportData.Columns.Add("EmailAddress")
        exportData.Columns.Add("JobItems")
        exportData.Columns.Add("CostsTo")
        exportData.Columns.Add("Priority")

        For Each dr As DataRow In visits.Table.Rows
            Dim newRw As DataRow
            newRw = exportData.NewRow

            newRw("Customer") = dr("Customer")
            newRw("Site") = dr("Site")
            newRw("JobNumber") = dr("JobNumber")
            newRw("PONumber") = dr("PONumber")
            newRw("JobDefinition") = dr("JobDefinition")
            newRw("Type") = dr("Type")
            newRw("ContractType") = dr("ContractType")
            newRw("VisitStatus") = dr("VisitStatus")
            newRw("StartDateTime") = dr("StartDateTime")
            newRw("Engineer") = dr("Engineer")
            newRw("VisitValue") = dr("VisitValue")
            newRw("VisitCharge") = dr("VisitCharge")
            newRw("EngineerCost") = dr("EngineerCost")
            newRw("PartProductCost") = dr("PartProductCost")
            newRw("SupplierInvoice") = dr("SupInvoice")
            newRw("CreditedAmount") = dr("Credit")
            newRw("NotesToEngineer") = dr("NotesToEngineer")
            newRw("OutcomeDetails") = dr("OutcomeDetails")
            newRw("VisitOutcome") = dr("VisitOutcome")
            newRw("ExpectedEngineer") = dr("ExpectedEngineer")
            newRw("LetterType") = dr("LetterType")
            newRw("DueDate") = dr("DueDate")
            newRw("AMPM") = dr("AMPM")
            newRw("SiteName") = dr("SiteName")
            newRw("Address1") = dr("Address1")
            newRw("Address2") = dr("Address2")
            newRw("Postcode") = dr("Postcode")

            newRw("TelephoneNumber") = dr("TelephoneNum")
            newRw("EmailAddress") = dr("EmailAddress")
            newRw("JobItems") = dr("JobItems")
            newRw("CostsTo") = dr("CostsTo")
            newRw("Priority") = dr("Priority")
            exportData.Rows.Add(newRw)
        Next

        Dim exporter As New Entity.Sys.Exporting(exportData, "Visit List")
        exporter = Nothing
    End Sub

    'Public Sub Export()
    '    Dim exportData As New DataTable
    '    exportData.Columns.Add("Customer")
    '    exportData.Columns.Add("Site")
    '    exportData.Columns.Add("SitePostcode")
    '    exportData.Columns.Add("VisitNumber")
    '    exportData.Columns.Add("PONumber")
    '    exportData.Columns.Add("VisitDefinition")
    '    exportData.Columns.Add("Type")
    '    exportData.Columns.Add("VisitStatus")
    '    exportData.Columns.Add("VisitStatus")
    '    exportData.Columns.Add("DateCreated")
    '    exportData.Columns.Add("CreatedBy")
    '    exportData.Columns.Add("VisitValue", GetType(Double))
    '    exportData.Columns.Add("VisitCharge")
    '    exportData.Columns.Add("EngineerCost", GetType(Double))
    '    exportData.Columns.Add("PartProductCost", GetType(Double))
    '    exportData.Columns.Add("NumberOfAssets", GetType(Integer))

    '    For itm As Integer = 0 To CType(dgVisits.DataSource, DataView).Count - 1
    '        dgVisits.CurrentRowIndex = itm
    '        Dim newRw As DataRow
    '        newRw = exportData.NewRow

    '        newRw("Customer") = SelectedVisitDataRow("Customer")
    '        newRw("Site") = SelectedVisitDataRow("Site")
    '        newRw("SitePostcode") = SelectedVisitDataRow("SitePostcode")
    '        newRw("VisitNumber") = SelectedVisitDataRow("VisitNumber")
    '        newRw("PONumber") = SelectedVisitDataRow("PONumber")
    '        newRw("VisitDefinition") = SelectedVisitDataRow("VisitDefinition")
    '        newRw("Type") = SelectedVisitDataRow("Type")
    '        newRw("VisitStatus") = SelectedVisitDataRow("VisitStatus")
    '        newRw("VisitStatus") = SelectedVisitDataRow("VisitStatus")
    '        newRw("DateCreated") = SelectedVisitDataRow("DateCreated")
    '        newRw("CreatedBy") = SelectedVisitDataRow("CreatedBy")
    '        newRw("VisitValue") = SelectedVisitDataRow("VisitValue")
    '        newRw("VisitCharge") = SelectedVisitDataRow("VisitCharge")
    '        newRw("EngineerCost") = SelectedVisitDataRow("EngineerCost")
    '        newRw("PartProductCost") = SelectedVisitDataRow("PartProductCost")
    '        newRw("NumberOfAssets") = SelectedVisitDataRow("NumberOfAssets")

    '        exportData.Rows.Add(newRw)

    '        dgVisits.UnSelect(itm)
    '    Next itm

    '    Dim exporter As New Entity.Sys.Exporting(exportData, "Visit List")
    '    exporter = Nothing
    'End Sub

#End Region

    Private Sub cboLetterNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLetterNumber.SelectedIndexChanged

    End Sub

End Class
