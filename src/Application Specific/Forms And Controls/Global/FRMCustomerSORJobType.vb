Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.CostCentres
Imports FSM.Entity.CostCentres.Enums
Imports FSM.Entity.CostCentres.LinkTypes.Enums
Imports FSM.Entity.Customers
Imports FSM.Entity.Sys

Public Class FRMCustomerSORJobType : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpLocks As System.Windows.Forms.GroupBox

    Friend WithEvents dgSOR As System.Windows.Forms.DataGrid
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents lblCustomerSorJobType As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents CboSOR As ComboBox
    Friend WithEvents lblSor As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lbSorCustomer As Label
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents btnFindCustomer As Button
    Friend WithEvents grpCostCentreMatrix As GroupBox
    Friend WithEvents cboRegion As ComboBox
    Friend WithEvents lblRegion As Label
    Friend WithEvents cboCCJobType As ComboBox
    Friend WithEvents btnDeleteCCM As Button
    Friend WithEvents lblJobType As Label
    Friend WithEvents dgCostCentreMatrix As DataGrid
    Friend WithEvents btnAddCCM As Button
    Friend WithEvents cboCostCentre As ComboBox
    Friend WithEvents lblCostCentre As Label
    Friend WithEvents cboLinkType As ComboBox
    Friend WithEvents lblLinkType As Label
    Friend WithEvents lblCcCustomer As Label
    Friend WithEvents btnCcFindCustomer As Button
    Friend WithEvents txtCcCustomer As TextBox
    Friend WithEvents txtJobSpendLimit As TextBox
    Friend WithEvents lblJobSpendLimit As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpLocks = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lbSorCustomer = New System.Windows.Forms.Label()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.CboSOR = New System.Windows.Forms.ComboBox()
        Me.lblSor = New System.Windows.Forms.Label()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.lblCustomerSorJobType = New System.Windows.Forms.Label()
        Me.dgSOR = New System.Windows.Forms.DataGrid()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpCostCentreMatrix = New System.Windows.Forms.GroupBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtJobSpendLimit = New System.Windows.Forms.TextBox()
        Me.lblJobSpendLimit = New System.Windows.Forms.Label()
        Me.cboLinkType = New System.Windows.Forms.ComboBox()
        Me.lblLinkType = New System.Windows.Forms.Label()
        Me.lblCcCustomer = New System.Windows.Forms.Label()
        Me.btnCcFindCustomer = New System.Windows.Forms.Button()
        Me.txtCcCustomer = New System.Windows.Forms.TextBox()
        Me.cboCostCentre = New System.Windows.Forms.ComboBox()
        Me.lblCostCentre = New System.Windows.Forms.Label()
        Me.btnAddCCM = New System.Windows.Forms.Button()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.lblRegion = New System.Windows.Forms.Label()
        Me.cboCCJobType = New System.Windows.Forms.ComboBox()
        Me.btnDeleteCCM = New System.Windows.Forms.Button()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.dgCostCentreMatrix = New System.Windows.Forms.DataGrid()
        Me.grpLocks.SuspendLayout()
        CType(Me.dgSOR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCostCentreMatrix.SuspendLayout()
        CType(Me.dgCostCentreMatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpLocks
        '
        Me.grpLocks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpLocks.Controls.Add(Me.btnSave)
        Me.grpLocks.Controls.Add(Me.lbSorCustomer)
        Me.grpLocks.Controls.Add(Me.txtCustomer)
        Me.grpLocks.Controls.Add(Me.btnFindCustomer)
        Me.grpLocks.Controls.Add(Me.btnDelete)
        Me.grpLocks.Controls.Add(Me.btnAdd)
        Me.grpLocks.Controls.Add(Me.CboSOR)
        Me.grpLocks.Controls.Add(Me.lblSor)
        Me.grpLocks.Controls.Add(Me.cboJobType)
        Me.grpLocks.Controls.Add(Me.lblCustomerSorJobType)
        Me.grpLocks.Controls.Add(Me.dgSOR)
        Me.grpLocks.Location = New System.Drawing.Point(8, 40)
        Me.grpLocks.Name = "grpLocks"
        Me.grpLocks.Size = New System.Drawing.Size(683, 743)
        Me.grpLocks.TabIndex = 1
        Me.grpLocks.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.AccessibleDescription = "Save item"
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.ImageIndex = 1
        Me.btnSave.Location = New System.Drawing.Point(621, 714)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(56, 22)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lbSorCustomer
        '
        Me.lbSorCustomer.Location = New System.Drawing.Point(6, 23)
        Me.lbSorCustomer.Name = "lbSorCustomer"
        Me.lbSorCustomer.Size = New System.Drawing.Size(64, 16)
        Me.lbSorCustomer.TabIndex = 36
        Me.lbSorCustomer.Text = "Customer"
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(76, 20)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(131, 21)
        Me.txtCustomer.TabIndex = 34
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(213, 18)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(25, 23)
        Me.btnFindCustomer.TabIndex = 35
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.AccessibleDescription = "Save item"
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.ImageIndex = 1
        Me.btnDelete.Location = New System.Drawing.Point(9, 714)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(56, 22)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleDescription = "Save item"
        Me.btnAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.ImageIndex = 1
        Me.btnAdd.Location = New System.Drawing.Point(8, 47)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(667, 23)
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'CboSOR
        '
        Me.CboSOR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboSOR.FormattingEnabled = True
        Me.CboSOR.Location = New System.Drawing.Point(451, 21)
        Me.CboSOR.Name = "CboSOR"
        Me.CboSOR.Size = New System.Drawing.Size(222, 21)
        Me.CboSOR.TabIndex = 32
        '
        'lblSor
        '
        Me.lblSor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSor.AutoSize = True
        Me.lblSor.Location = New System.Drawing.Point(413, 23)
        Me.lblSor.Name = "lblSor"
        Me.lblSor.Size = New System.Drawing.Size(32, 13)
        Me.lblSor.TabIndex = 31
        Me.lblSor.Text = "SOR"
        '
        'cboJobType
        '
        Me.cboJobType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJobType.FormattingEnabled = True
        Me.cboJobType.Location = New System.Drawing.Point(307, 20)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(100, 21)
        Me.cboJobType.TabIndex = 3
        '
        'lblCustomerSorJobType
        '
        Me.lblCustomerSorJobType.AutoSize = True
        Me.lblCustomerSorJobType.Location = New System.Drawing.Point(244, 24)
        Me.lblCustomerSorJobType.Name = "lblCustomerSorJobType"
        Me.lblCustomerSorJobType.Size = New System.Drawing.Size(57, 13)
        Me.lblCustomerSorJobType.TabIndex = 2
        Me.lblCustomerSorJobType.Text = "Job Type"
        '
        'dgSOR
        '
        Me.dgSOR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSOR.DataMember = ""
        Me.dgSOR.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSOR.Location = New System.Drawing.Point(8, 76)
        Me.dgSOR.Name = "dgSOR"
        Me.dgSOR.Size = New System.Drawing.Size(667, 623)
        Me.dgSOR.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = "Save item"
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.ImageIndex = 1
        Me.btnClose.Location = New System.Drawing.Point(16, 802)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 24)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpCostCentreMatrix
        '
        Me.grpCostCentreMatrix.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCostCentreMatrix.Controls.Add(Me.btnReset)
        Me.grpCostCentreMatrix.Controls.Add(Me.txtJobSpendLimit)
        Me.grpCostCentreMatrix.Controls.Add(Me.lblJobSpendLimit)
        Me.grpCostCentreMatrix.Controls.Add(Me.cboLinkType)
        Me.grpCostCentreMatrix.Controls.Add(Me.lblLinkType)
        Me.grpCostCentreMatrix.Controls.Add(Me.lblCcCustomer)
        Me.grpCostCentreMatrix.Controls.Add(Me.btnCcFindCustomer)
        Me.grpCostCentreMatrix.Controls.Add(Me.txtCcCustomer)
        Me.grpCostCentreMatrix.Controls.Add(Me.cboCostCentre)
        Me.grpCostCentreMatrix.Controls.Add(Me.lblCostCentre)
        Me.grpCostCentreMatrix.Controls.Add(Me.btnAddCCM)
        Me.grpCostCentreMatrix.Controls.Add(Me.cboRegion)
        Me.grpCostCentreMatrix.Controls.Add(Me.lblRegion)
        Me.grpCostCentreMatrix.Controls.Add(Me.cboCCJobType)
        Me.grpCostCentreMatrix.Controls.Add(Me.btnDeleteCCM)
        Me.grpCostCentreMatrix.Controls.Add(Me.lblJobType)
        Me.grpCostCentreMatrix.Controls.Add(Me.dgCostCentreMatrix)
        Me.grpCostCentreMatrix.Location = New System.Drawing.Point(697, 40)
        Me.grpCostCentreMatrix.Name = "grpCostCentreMatrix"
        Me.grpCostCentreMatrix.Size = New System.Drawing.Size(896, 743)
        Me.grpCostCentreMatrix.TabIndex = 35
        Me.grpCostCentreMatrix.TabStop = False
        Me.grpCostCentreMatrix.Text = "Cost Centre Matrix"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(810, 50)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(78, 20)
        Me.btnReset.TabIndex = 77
        Me.btnReset.Tag = ""
        Me.btnReset.Text = "Reset"
        '
        'txtJobSpendLimit
        '
        Me.txtJobSpendLimit.Location = New System.Drawing.Point(336, 49)
        Me.txtJobSpendLimit.Name = "txtJobSpendLimit"
        Me.txtJobSpendLimit.Size = New System.Drawing.Size(117, 21)
        Me.txtJobSpendLimit.TabIndex = 76
        '
        'lblJobSpendLimit
        '
        Me.lblJobSpendLimit.AutoSize = True
        Me.lblJobSpendLimit.Location = New System.Drawing.Point(222, 52)
        Me.lblJobSpendLimit.Name = "lblJobSpendLimit"
        Me.lblJobSpendLimit.Size = New System.Drawing.Size(108, 13)
        Me.lblJobSpendLimit.TabIndex = 75
        Me.lblJobSpendLimit.Text = "Job Spend Limit £"
        '
        'cboLinkType
        '
        Me.cboLinkType.FormattingEnabled = True
        Me.cboLinkType.Location = New System.Drawing.Point(90, 49)
        Me.cboLinkType.Name = "cboLinkType"
        Me.cboLinkType.Size = New System.Drawing.Size(119, 21)
        Me.cboLinkType.TabIndex = 74
        '
        'lblLinkType
        '
        Me.lblLinkType.AutoSize = True
        Me.lblLinkType.Location = New System.Drawing.Point(8, 52)
        Me.lblLinkType.Name = "lblLinkType"
        Me.lblLinkType.Size = New System.Drawing.Size(61, 13)
        Me.lblLinkType.TabIndex = 73
        Me.lblLinkType.Text = "Link Type"
        '
        'lblCcCustomer
        '
        Me.lblCcCustomer.AutoSize = True
        Me.lblCcCustomer.Location = New System.Drawing.Point(471, 25)
        Me.lblCcCustomer.Name = "lblCcCustomer"
        Me.lblCcCustomer.Size = New System.Drawing.Size(63, 13)
        Me.lblCcCustomer.TabIndex = 72
        Me.lblCcCustomer.Text = "Customer"
        Me.lblCcCustomer.Visible = False
        '
        'btnCcFindCustomer
        '
        Me.btnCcFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnCcFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCcFindCustomer.Location = New System.Drawing.Point(712, 18)
        Me.btnCcFindCustomer.Name = "btnCcFindCustomer"
        Me.btnCcFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnCcFindCustomer.TabIndex = 71
        Me.btnCcFindCustomer.Text = "..."
        Me.btnCcFindCustomer.UseVisualStyleBackColor = False
        Me.btnCcFindCustomer.Visible = False
        '
        'txtCcCustomer
        '
        Me.txtCcCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCcCustomer.Location = New System.Drawing.Point(540, 19)
        Me.txtCcCustomer.Name = "txtCcCustomer"
        Me.txtCcCustomer.ReadOnly = True
        Me.txtCcCustomer.Size = New System.Drawing.Size(166, 21)
        Me.txtCcCustomer.TabIndex = 70
        Me.txtCcCustomer.Visible = False
        '
        'cboCostCentre
        '
        Me.cboCostCentre.FormattingEnabled = True
        Me.cboCostCentre.Location = New System.Drawing.Point(90, 19)
        Me.cboCostCentre.Name = "cboCostCentre"
        Me.cboCostCentre.Size = New System.Drawing.Size(73, 21)
        Me.cboCostCentre.TabIndex = 69
        '
        'lblCostCentre
        '
        Me.lblCostCentre.AutoSize = True
        Me.lblCostCentre.Location = New System.Drawing.Point(8, 23)
        Me.lblCostCentre.Name = "lblCostCentre"
        Me.lblCostCentre.Size = New System.Drawing.Size(76, 13)
        Me.lblCostCentre.TabIndex = 68
        Me.lblCostCentre.Text = "Cost Centre"
        '
        'btnAddCCM
        '
        Me.btnAddCCM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddCCM.Location = New System.Drawing.Point(810, 20)
        Me.btnAddCCM.Name = "btnAddCCM"
        Me.btnAddCCM.Size = New System.Drawing.Size(78, 20)
        Me.btnAddCCM.TabIndex = 67
        Me.btnAddCCM.Tag = ""
        Me.btnAddCCM.Text = "Save"
        '
        'cboRegion
        '
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Location = New System.Drawing.Point(523, 19)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(159, 21)
        Me.cboRegion.TabIndex = 32
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(471, 23)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(46, 13)
        Me.lblRegion.TabIndex = 31
        Me.lblRegion.Text = "Region"
        '
        'cboCCJobType
        '
        Me.cboCCJobType.FormattingEnabled = True
        Me.cboCCJobType.Location = New System.Drawing.Point(300, 19)
        Me.cboCCJobType.Name = "cboCCJobType"
        Me.cboCCJobType.Size = New System.Drawing.Size(153, 21)
        Me.cboCCJobType.TabIndex = 3
        '
        'btnDeleteCCM
        '
        Me.btnDeleteCCM.AccessibleDescription = "Save item"
        Me.btnDeleteCCM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteCCM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteCCM.ImageIndex = 1
        Me.btnDeleteCCM.Location = New System.Drawing.Point(810, 714)
        Me.btnDeleteCCM.Name = "btnDeleteCCM"
        Me.btnDeleteCCM.Size = New System.Drawing.Size(78, 22)
        Me.btnDeleteCCM.TabIndex = 2
        Me.btnDeleteCCM.Text = "Delete"
        Me.btnDeleteCCM.UseVisualStyleBackColor = True
        '
        'lblJobType
        '
        Me.lblJobType.AutoSize = True
        Me.lblJobType.Location = New System.Drawing.Point(222, 23)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(57, 13)
        Me.lblJobType.TabIndex = 2
        Me.lblJobType.Text = "Job Type"
        '
        'dgCostCentreMatrix
        '
        Me.dgCostCentreMatrix.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCostCentreMatrix.DataMember = ""
        Me.dgCostCentreMatrix.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCostCentreMatrix.Location = New System.Drawing.Point(11, 76)
        Me.dgCostCentreMatrix.Name = "dgCostCentreMatrix"
        Me.dgCostCentreMatrix.Size = New System.Drawing.Size(880, 623)
        Me.dgCostCentreMatrix.TabIndex = 1
        '
        'FRMCustomerSORJobType
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1604, 852)
        Me.Controls.Add(Me.grpCostCentreMatrix)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpLocks)
        Me.MinimumSize = New System.Drawing.Size(793, 520)
        Me.Name = "FRMCustomerSORJobType"
        Me.Text = "Setup"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpLocks, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.grpCostCentreMatrix, 0)
        Me.grpLocks.ResumeLayout(False)
        Me.grpLocks.PerformLayout()
        CType(Me.dgSOR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCostCentreMatrix.ResumeLayout(False)
        Me.grpCostCentreMatrix.PerformLayout()
        CType(Me.dgCostCentreMatrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupDataGrid()
        SetupCCMDataGrid()
        Combo.SetUpCombo(Me.cboJobType, DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboCCJobType, DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboLinkType, DB.CostCentreLinkType.GetAll().Table, "Id", "Name", Enums.ComboValues.Please_Select)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboCostCentre, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboCostCentre, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select

        Me.cboLinkType.Items.RemoveAt(0)
        Combo.SetSelectedComboItem_By_Value(cboLinkType, 1)
        Combo.SetUpCombo(Me.CboSOR, DB.CustomerScheduleOfRate.GetAll_For_CustomerID(CurrentCustomerID).Table, "CustomerScheduleOfRateID", "Description", Enums.ComboValues.Please_Select)
        SORSkills = DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll()
        UpdateCostCentreMatrixDg()

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
                Me.txtCustomer.Text = theCustomer.Name & " (A/C No : " & _theCustomer.AccountNumber & ")"
                Combo.SetUpCombo(Me.CboSOR, DB.CustomerScheduleOfRate.GetAll_For_CustomerID(_theCustomer.CustomerID).Table, "CustomerScheduleOfRateID", "Description", Enums.ComboValues.Please_Select)
            Else
                Me.txtCustomer.Text = ""
            End If
        End Set
    End Property

    Private _customer As Customer

    Public Property Customer As Customer
        Get
            Return _customer
        End Get
        Set(value As Customer)
            _customer = value
            If Helper.MakeIntegerValid(_customer?.CustomerID) > 0 Then
                txtCcCustomer.Text = _customer.Name
            Else
                txtCcCustomer.Text = ""
            End If
        End Set
    End Property

    Private _SORSkills As DataView

    Private Property SORSkills() As DataView
        Get
            Return _SORSkills
        End Get
        Set(ByVal value As DataView)
            _SORSkills = value
            _SORSkills.AllowNew = False
            _SORSkills.AllowEdit = False
            _SORSkills.AllowDelete = False
            _SORSkills.Table.TableName = "Skills"
            Me.dgSOR.DataSource = _SORSkills
        End Set
    End Property

    Private ReadOnly Property SelectedDataRow() As DataRow
        Get
            If Not Me.dgSOR.CurrentRowIndex = -1 Then
                Return SORSkills(Me.dgSOR.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _costCentreMatrix As DataView

    Private Property CostCentreMatrix() As DataView
        Get
            Return _costCentreMatrix
        End Get
        Set(ByVal value As DataView)
            _costCentreMatrix = value
            _costCentreMatrix.AllowNew = False
            _costCentreMatrix.AllowEdit = False
            _costCentreMatrix.AllowDelete = False
            _costCentreMatrix.Table.TableName = "CostCentreMatrix"
            dgCostCentreMatrix.DataSource = CostCentreMatrix
        End Set
    End Property

    Private ReadOnly Property SelectedDataRowCCM() As DataRow
        Get
            If Not dgCostCentreMatrix.CurrentRowIndex = -1 Then
                Return CostCentreMatrix(dgCostCentreMatrix.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDataGrid()
        Helper.SetUpDataGrid(Me.dgSOR)
        Dim tbStyle As DataGridTableStyle = Me.dgSOR.TableStyles(0)

        Dim CustomerJobTypeSORID As New DataGridLabelColumn
        CustomerJobTypeSORID.Format = ""
        CustomerJobTypeSORID.FormatInfo = Nothing
        CustomerJobTypeSORID.HeaderText = "CustomerJobTypeSORID"
        CustomerJobTypeSORID.MappingName = "CustomerJobTypeSORID"
        CustomerJobTypeSORID.ReadOnly = True
        CustomerJobTypeSORID.Width = 5
        CustomerJobTypeSORID.NullText = ""
        tbStyle.GridColumnStyles.Add(CustomerJobTypeSORID)

        Dim CustomerScheduleOfRateID As New DataGridLabelColumn
        CustomerScheduleOfRateID.Format = ""
        CustomerScheduleOfRateID.FormatInfo = Nothing
        CustomerScheduleOfRateID.HeaderText = "CustomerScheduleOfRateID"
        CustomerScheduleOfRateID.MappingName = "CustomerScheduleOfRateID"
        CustomerScheduleOfRateID.ReadOnly = True
        CustomerScheduleOfRateID.Width = 5
        CustomerScheduleOfRateID.NullText = ""
        tbStyle.GridColumnStyles.Add(CustomerScheduleOfRateID)

        Dim CustomerID As New DataGridLabelColumn
        CustomerID.Format = ""
        CustomerID.FormatInfo = Nothing
        CustomerID.HeaderText = "CustomerID"
        CustomerID.MappingName = "CustomerID"
        CustomerID.ReadOnly = True
        CustomerID.Width = 5
        CustomerID.NullText = ""
        tbStyle.GridColumnStyles.Add(CustomerID)

        Dim JobTypeID As New DataGridLabelColumn
        JobTypeID.Format = ""
        JobTypeID.FormatInfo = Nothing
        JobTypeID.HeaderText = "JobTypeID"
        JobTypeID.MappingName = "JobTypeID"
        JobTypeID.ReadOnly = True
        JobTypeID.Width = 5
        JobTypeID.NullText = ""
        tbStyle.GridColumnStyles.Add(JobTypeID)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer Name"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 100
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Type"
        JobNumber.MappingName = "JobType"
        JobNumber.ReadOnly = True
        JobNumber.Width = 150
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim SORCode As New DataGridLabelColumn
        SORCode.Format = ""
        SORCode.FormatInfo = Nothing
        SORCode.HeaderText = "SOR Code"
        SORCode.MappingName = "code"
        SORCode.ReadOnly = True
        SORCode.Width = 100
        SORCode.NullText = ""
        tbStyle.GridColumnStyles.Add(SORCode)

        Dim FullName As New DataGridLabelColumn
        FullName.Format = ""
        FullName.FormatInfo = Nothing
        FullName.HeaderText = "SOR Description"
        FullName.MappingName = "Description"
        FullName.ReadOnly = True
        FullName.Width = 150
        FullName.NullText = ""
        tbStyle.GridColumnStyles.Add(FullName)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = "Skills"
        Me.dgSOR.TableStyles.Add(tbStyle)

    End Sub

    Private Sub SetupCCMDataGrid()
        Helper.SetUpDataGrid(Me.dgCostCentreMatrix)
        Dim tbStyle As DataGridTableStyle = Me.dgCostCentreMatrix.TableStyles(0)

        Dim costCentre As New DataGridLabelColumn
        costCentre.Format = ""
        costCentre.FormatInfo = Nothing
        costCentre.HeaderText = "Cost Centre"
        costCentre.MappingName = "CostCentre"
        costCentre.ReadOnly = True
        costCentre.Width = 100
        costCentre.NullText = ""
        tbStyle.GridColumnStyles.Add(costCentre)

        Dim jobType As New DataGridLabelColumn
        jobType.Format = ""
        jobType.FormatInfo = Nothing
        jobType.HeaderText = "Job Type"
        jobType.MappingName = "JobType"
        jobType.ReadOnly = True
        jobType.Width = 250
        jobType.NullText = ""
        tbStyle.GridColumnStyles.Add(jobType)

        Dim link As New DataGridLabelColumn
        link.Format = ""
        link.FormatInfo = Nothing
        link.HeaderText = "Link"
        link.MappingName = "Link"
        link.ReadOnly = True
        link.Width = 200
        link.NullText = ""
        tbStyle.GridColumnStyles.Add(link)

        Dim linkType As New DataGridLabelColumn
        linkType.Format = ""
        linkType.FormatInfo = Nothing
        linkType.HeaderText = "Link Type"
        linkType.MappingName = "LinkType"
        linkType.ReadOnly = True
        linkType.Width = 150
        linkType.NullText = ""
        tbStyle.GridColumnStyles.Add(linkType)

        Dim jobSpendLimit As New DataGridLabelColumn
        jobSpendLimit.Format = "c"
        jobSpendLimit.FormatInfo = Nothing
        jobSpendLimit.HeaderText = "Job Spend Limit"
        jobSpendLimit.MappingName = "JobSpendLimit"
        jobSpendLimit.ReadOnly = True
        jobSpendLimit.Width = 150
        jobSpendLimit.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(jobSpendLimit)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = "CostCentreMatrix"
        Me.dgCostCentreMatrix.TableStyles.Add(tbStyle)

    End Sub

#End Region

#Region "Events"

    Private Sub FRMJobLocks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If SelectedDataRow Is Nothing Then
            ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If EnterOverridePassword() = True Then
            If ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If

            Try
                Cursor.Current = Cursors.WaitCursor

                DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Delete(SelectedDataRow("CustomerJobTypeSORID"))
                SORSkills = DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll()
            Catch ex As Exception
                ShowMessage("Error unlocking job : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If theCustomer.CustomerID > 0 And Combo.GetSelectedItemValue(cboJobType) > 0 And Combo.GetSelectedItemValue(CboSOR) > 0 Then
            DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Insert(theCustomer.CustomerID, Combo.GetSelectedItemValue(cboJobType), Combo.GetSelectedItemValue(CboSOR))
            SORSkills = DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_GetAll()
        End If
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            theCustomer = DB.Customer.Customer_Get(ID)
        End If
    End Sub

    Private Sub btnCcFindCustomer_Click(sender As Object, e As EventArgs) Handles btnCcFindCustomer.Click
        Dim ID As Integer = FindRecord(Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            Customer = DB.Customer.Customer_Get(ID)
        End If
    End Sub

    Private Sub btnAddCCM_Click(sender As Object, e As EventArgs) Handles btnAddCCM.Click

        Dim _ssmList As New List(Of Enums.SecuritySystemModules)
        _ssmList.Add(Enums.SecuritySystemModules.IT)
        _ssmList.Add(Enums.SecuritySystemModules.Finance)

        If Not loggedInUser.HasAccessToMulitpleModules(_ssmList) Then
            ShowSecurityError()
        End If

        Dim costCentre As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboCostCentre).Trim())
        Dim jobTypeId As Integer = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboCCJobType))
        Dim costCap As Decimal = If(Me.txtJobSpendLimit.Text.Length > 0, Helper.MakeDoubleValid(Me.txtJobSpendLimit.Text), Nothing)
        If jobTypeId = 0 Or costCentre = "-1" Then Exit Sub
        Dim ccs As List(Of CostCentre) = DB.CostCentre.Get(jobTypeId, Nothing, GetBy.JobTypeId)

        Dim linkId As Integer = 0
        Dim linkTypeId As Integer = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboLinkType))
        Select Case linkTypeId
            Case CInt(LinkType.RegionId)
                linkId = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboRegion))
                If linkId = 0 Then
                    ShowMessage("Please select a region!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Case CInt(LinkType.CustomerId)
                linkId = Helper.MakeIntegerValid(Customer?.CustomerID)
                If linkId = 0 Then
                    ShowMessage("Please select a customer!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
        End Select

        If ccs IsNot Nothing Then ccs = ccs.Where(Function(x) x.JobTypeId = jobTypeId And x.LinkId = linkId And x.LinkTypeId = linkTypeId).ToList()
        If ccs IsNot Nothing AndAlso ccs.Count > 0 Then
            ccs.FirstOrDefault().CostCentre = costCentre
            ccs.FirstOrDefault().JobTypeId = jobTypeId
            ccs.FirstOrDefault().LinkId = linkId
            ccs.FirstOrDefault().LinkTypeId = linkTypeId
            ccs.FirstOrDefault().JobSpendLimit = costCap

            DB.CostCentre.Update(ccs.FirstOrDefault())
            UpdateCostCentreMatrixDg()
        Else

            Dim cc As New CostCentre() With {.CostCentre = costCentre, .JobTypeId = jobTypeId, .LinkId = linkId, .LinkTypeId = linkTypeId, .JobSpendLimit = costCap}
            cc = DB.CostCentre.Insert(cc)
            If cc.Id > 0 Then UpdateCostCentreMatrixDg()
        End If

    End Sub

    Public Sub UpdateCostCentreMatrixDg()
        CostCentreMatrix = DB.CostCentre.GetAll()
        ResetControls()
    End Sub

    Public Sub ResetControls()
        Combo.SetSelectedComboItem_By_Value(cboCCJobType, 0)
        Combo.SetSelectedComboItem_By_Value(cboRegion, 0)
        Combo.SetSelectedComboItem_By_Value(cboCostCentre, "-1")
        Customer = Nothing
        Me.txtJobSpendLimit.Text = ""
    End Sub

    Private Sub btnDeleteCCM_Click(sender As Object, e As EventArgs) Handles btnDeleteCCM.Click
        Dim _ssmList As New List(Of Enums.SecuritySystemModules)
        _ssmList.Add(Enums.SecuritySystemModules.IT)
        _ssmList.Add(Enums.SecuritySystemModules.Finance)

        If Not loggedInUser.HasAccessToMulitpleModules(_ssmList) Then
            ShowSecurityError()
        End If

        If SelectedDataRowCCM Is Nothing Then
            ShowMessage("Please select a line to remove", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ShowMessage("Are you sure you wish to delete this row?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Exit Sub
        End If

        Try
            Cursor.Current = Cursors.WaitCursor
            DB.CostCentre.Delete(SelectedDataRowCCM("Id"))
            UpdateCostCentreMatrixDg()
        Catch ex As Exception
            ShowMessage("Error deleting: " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cboLinkType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLinkType.SelectedIndexChanged
        Dim linkTypeId As Integer = Helper.MakeIntegerValid(Combo.GetSelectedItemValue(cboLinkType))
        Select Case linkTypeId
            Case CInt(LinkType.RegionId)
                lblRegion.Visible = True
                cboRegion.Visible = True

                lblCcCustomer.Visible = False
                txtCcCustomer.Visible = False
                btnCcFindCustomer.Visible = False

            Case CInt(LinkType.CustomerId)
                lblCcCustomer.Visible = True
                txtCcCustomer.Visible = True
                btnCcFindCustomer.Visible = True

                lblRegion.Visible = False
                cboRegion.Visible = False
        End Select
    End Sub

    Private Sub dgCostCentreMatrix_Click(sender As Object, e As EventArgs) Handles dgCostCentreMatrix.Click
        If SelectedDataRowCCM Is Nothing Then Exit Sub

        Dim costCentre As CostCentre = DB.CostCentre.Get(SelectedDataRowCCM("Id"), Nothing, GetBy.Id).FirstOrDefault()
        With costCentre
            Combo.SetSelectedComboItem_By_Value(cboCostCentre, .CostCentre)
            Combo.SetSelectedComboItem_By_Value(cboCCJobType, .JobTypeId)
            Combo.SetSelectedComboItem_By_Value(cboLinkType, .LinkTypeId)

            If .LinkTypeId = LinkType.RegionId Then
                Combo.SetSelectedComboItem_By_Value(cboRegion, .LinkId)
            Else
                Customer = DB.Customer.Customer_Get(.LinkId)
            End If

            Me.txtJobSpendLimit.Text = Helper.MakeStringValid(.JobSpendLimit)
        End With
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ResetControls()
    End Sub

#End Region

End Class