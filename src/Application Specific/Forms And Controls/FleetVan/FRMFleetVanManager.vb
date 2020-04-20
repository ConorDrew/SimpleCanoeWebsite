Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection

Public Class FRMFleetVanManager : Inherits FRMBaseForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboFaultType, DB.FleetVanFault.FaultTypes_GetAll().Table,
                        "VanFaultTypeID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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
    Friend WithEvents grpFaultsFilter As System.Windows.Forms.GroupBox
    Friend WithEvents grpFaultDG As GroupBox
    Friend WithEvents dgFaults As DataGrid
    Friend WithEvents grpEngineerFilter As GroupBox
    Friend WithEvents grpEngineerHistory As GroupBox
    Friend WithEvents grpFilter As GroupBox
    Friend WithEvents lblRegistration As Label
    Friend WithEvents btnfindVan As Button
    Friend WithEvents txtVanReg As TextBox
    Friend WithEvents cboFaultType As ComboBox
    Friend WithEvents lblFaultType As Label
    Friend WithEvents dtpResolvedTo As DateTimePicker
    Friend WithEvents dtpResolvedFrom As DateTimePicker
    Friend WithEvents lblResolvedTo As Label
    Friend WithEvents lblResolvedFrom As Label
    Friend WithEvents chkResolved As CheckBox
    Friend WithEvents dtpFaultTo As DateTimePicker
    Friend WithEvents dtpFaultFrom As DateTimePicker
    Friend WithEvents lblFaultTo As Label
    Friend WithEvents lblFaultFrom As Label
    Friend WithEvents chkFaultDate As CheckBox
    Friend WithEvents dtpEngineerTo As DateTimePicker
    Friend WithEvents dtpEngineerFrom As DateTimePicker
    Friend WithEvents lblEngineerTo As Label
    Friend WithEvents lblEngineerFrom As Label
    Friend WithEvents btnSearchFault As Button
    Friend WithEvents btnSearchEngineer As Button
    Friend WithEvents btnfindEngineer As Button
    Friend WithEvents txtEngineer As TextBox
    Friend WithEvents lblEngineer As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents dgEngineerHistory As DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpFaultsFilter = New System.Windows.Forms.GroupBox()
        Me.btnSearchFault = New System.Windows.Forms.Button()
        Me.dtpResolvedTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpResolvedFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblResolvedTo = New System.Windows.Forms.Label()
        Me.lblResolvedFrom = New System.Windows.Forms.Label()
        Me.chkResolved = New System.Windows.Forms.CheckBox()
        Me.dtpFaultTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFaultFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblFaultTo = New System.Windows.Forms.Label()
        Me.lblFaultFrom = New System.Windows.Forms.Label()
        Me.chkFaultDate = New System.Windows.Forms.CheckBox()
        Me.cboFaultType = New System.Windows.Forms.ComboBox()
        Me.lblFaultType = New System.Windows.Forms.Label()
        Me.grpFaultDG = New System.Windows.Forms.GroupBox()
        Me.dgFaults = New System.Windows.Forms.DataGrid()
        Me.grpEngineerFilter = New System.Windows.Forms.GroupBox()
        Me.btnfindEngineer = New System.Windows.Forms.Button()
        Me.txtEngineer = New System.Windows.Forms.TextBox()
        Me.lblEngineer = New System.Windows.Forms.Label()
        Me.btnSearchEngineer = New System.Windows.Forms.Button()
        Me.dtpEngineerTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpEngineerFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblEngineerTo = New System.Windows.Forms.Label()
        Me.lblEngineerFrom = New System.Windows.Forms.Label()
        Me.grpEngineerHistory = New System.Windows.Forms.GroupBox()
        Me.dgEngineerHistory = New System.Windows.Forms.DataGrid()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.lblRegistration = New System.Windows.Forms.Label()
        Me.btnfindVan = New System.Windows.Forms.Button()
        Me.txtVanReg = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.grpFaultsFilter.SuspendLayout()
        Me.grpFaultDG.SuspendLayout()
        CType(Me.dgFaults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpEngineerFilter.SuspendLayout()
        Me.grpEngineerHistory.SuspendLayout()
        CType(Me.dgEngineerHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFaultsFilter
        '
        Me.grpFaultsFilter.Controls.Add(Me.btnSearchFault)
        Me.grpFaultsFilter.Controls.Add(Me.dtpResolvedTo)
        Me.grpFaultsFilter.Controls.Add(Me.dtpResolvedFrom)
        Me.grpFaultsFilter.Controls.Add(Me.lblResolvedTo)
        Me.grpFaultsFilter.Controls.Add(Me.lblResolvedFrom)
        Me.grpFaultsFilter.Controls.Add(Me.chkResolved)
        Me.grpFaultsFilter.Controls.Add(Me.dtpFaultTo)
        Me.grpFaultsFilter.Controls.Add(Me.dtpFaultFrom)
        Me.grpFaultsFilter.Controls.Add(Me.lblFaultTo)
        Me.grpFaultsFilter.Controls.Add(Me.lblFaultFrom)
        Me.grpFaultsFilter.Controls.Add(Me.chkFaultDate)
        Me.grpFaultsFilter.Controls.Add(Me.cboFaultType)
        Me.grpFaultsFilter.Controls.Add(Me.lblFaultType)
        Me.grpFaultsFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpFaultsFilter.Location = New System.Drawing.Point(8, 107)
        Me.grpFaultsFilter.Name = "grpFaultsFilter"
        Me.grpFaultsFilter.Size = New System.Drawing.Size(842, 169)
        Me.grpFaultsFilter.TabIndex = 3
        Me.grpFaultsFilter.TabStop = False
        Me.grpFaultsFilter.Text = "Filter Faults"
        '
        'btnSearchFault
        '
        Me.btnSearchFault.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchFault.Location = New System.Drawing.Point(766, 140)
        Me.btnSearchFault.Name = "btnSearchFault"
        Me.btnSearchFault.Size = New System.Drawing.Size(70, 23)
        Me.btnSearchFault.TabIndex = 78
        Me.btnSearchFault.Text = "Run Filter"
        '
        'dtpResolvedTo
        '
        Me.dtpResolvedTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpResolvedTo.Location = New System.Drawing.Point(325, 103)
        Me.dtpResolvedTo.Name = "dtpResolvedTo"
        Me.dtpResolvedTo.Size = New System.Drawing.Size(156, 21)
        Me.dtpResolvedTo.TabIndex = 77
        '
        'dtpResolvedFrom
        '
        Me.dtpResolvedFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpResolvedFrom.Location = New System.Drawing.Point(325, 72)
        Me.dtpResolvedFrom.Name = "dtpResolvedFrom"
        Me.dtpResolvedFrom.Size = New System.Drawing.Size(156, 21)
        Me.dtpResolvedFrom.TabIndex = 76
        '
        'lblResolvedTo
        '
        Me.lblResolvedTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResolvedTo.Location = New System.Drawing.Point(271, 108)
        Me.lblResolvedTo.Name = "lblResolvedTo"
        Me.lblResolvedTo.Size = New System.Drawing.Size(48, 16)
        Me.lblResolvedTo.TabIndex = 74
        Me.lblResolvedTo.Text = "To"
        '
        'lblResolvedFrom
        '
        Me.lblResolvedFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResolvedFrom.Location = New System.Drawing.Point(271, 77)
        Me.lblResolvedFrom.Name = "lblResolvedFrom"
        Me.lblResolvedFrom.Size = New System.Drawing.Size(48, 16)
        Me.lblResolvedFrom.TabIndex = 73
        Me.lblResolvedFrom.Text = "From"
        '
        'chkResolved
        '
        Me.chkResolved.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkResolved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkResolved.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkResolved.Location = New System.Drawing.Point(274, 48)
        Me.chkResolved.Name = "chkResolved"
        Me.chkResolved.Size = New System.Drawing.Size(112, 24)
        Me.chkResolved.TabIndex = 75
        Me.chkResolved.Text = "Resolved Date"
        '
        'dtpFaultTo
        '
        Me.dtpFaultTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFaultTo.Location = New System.Drawing.Point(61, 104)
        Me.dtpFaultTo.Name = "dtpFaultTo"
        Me.dtpFaultTo.Size = New System.Drawing.Size(156, 21)
        Me.dtpFaultTo.TabIndex = 72
        '
        'dtpFaultFrom
        '
        Me.dtpFaultFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFaultFrom.Location = New System.Drawing.Point(61, 73)
        Me.dtpFaultFrom.Name = "dtpFaultFrom"
        Me.dtpFaultFrom.Size = New System.Drawing.Size(156, 21)
        Me.dtpFaultFrom.TabIndex = 71
        '
        'lblFaultTo
        '
        Me.lblFaultTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFaultTo.Location = New System.Drawing.Point(7, 109)
        Me.lblFaultTo.Name = "lblFaultTo"
        Me.lblFaultTo.Size = New System.Drawing.Size(48, 16)
        Me.lblFaultTo.TabIndex = 69
        Me.lblFaultTo.Text = "To"
        '
        'lblFaultFrom
        '
        Me.lblFaultFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFaultFrom.Location = New System.Drawing.Point(7, 78)
        Me.lblFaultFrom.Name = "lblFaultFrom"
        Me.lblFaultFrom.Size = New System.Drawing.Size(48, 16)
        Me.lblFaultFrom.TabIndex = 68
        Me.lblFaultFrom.Text = "From"
        '
        'chkFaultDate
        '
        Me.chkFaultDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkFaultDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkFaultDate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkFaultDate.Location = New System.Drawing.Point(10, 48)
        Me.chkFaultDate.Name = "chkFaultDate"
        Me.chkFaultDate.Size = New System.Drawing.Size(80, 24)
        Me.chkFaultDate.TabIndex = 70
        Me.chkFaultDate.Text = "Fault Date"
        '
        'cboFaultType
        '
        Me.cboFaultType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboFaultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFaultType.Location = New System.Drawing.Point(108, 20)
        Me.cboFaultType.Name = "cboFaultType"
        Me.cboFaultType.Size = New System.Drawing.Size(171, 21)
        Me.cboFaultType.TabIndex = 32
        Me.cboFaultType.Tag = ""
        '
        'lblFaultType
        '
        Me.lblFaultType.Location = New System.Drawing.Point(6, 23)
        Me.lblFaultType.Name = "lblFaultType"
        Me.lblFaultType.Size = New System.Drawing.Size(96, 20)
        Me.lblFaultType.TabIndex = 33
        Me.lblFaultType.Text = "Fault Type"
        '
        'grpFaultDG
        '
        Me.grpFaultDG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpFaultDG.Controls.Add(Me.dgFaults)
        Me.grpFaultDG.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpFaultDG.Location = New System.Drawing.Point(8, 282)
        Me.grpFaultDG.Name = "grpFaultDG"
        Me.grpFaultDG.Size = New System.Drawing.Size(842, 420)
        Me.grpFaultDG.TabIndex = 14
        Me.grpFaultDG.TabStop = False
        Me.grpFaultDG.Text = "Faults"
        '
        'dgFaults
        '
        Me.dgFaults.DataMember = ""
        Me.dgFaults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFaults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgFaults.Location = New System.Drawing.Point(3, 17)
        Me.dgFaults.Name = "dgFaults"
        Me.dgFaults.Size = New System.Drawing.Size(836, 400)
        Me.dgFaults.TabIndex = 45
        '
        'grpEngineerFilter
        '
        Me.grpEngineerFilter.Controls.Add(Me.btnfindEngineer)
        Me.grpEngineerFilter.Controls.Add(Me.txtEngineer)
        Me.grpEngineerFilter.Controls.Add(Me.lblEngineer)
        Me.grpEngineerFilter.Controls.Add(Me.btnSearchEngineer)
        Me.grpEngineerFilter.Controls.Add(Me.dtpEngineerTo)
        Me.grpEngineerFilter.Controls.Add(Me.dtpEngineerFrom)
        Me.grpEngineerFilter.Controls.Add(Me.lblEngineerTo)
        Me.grpEngineerFilter.Controls.Add(Me.lblEngineerFrom)
        Me.grpEngineerFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpEngineerFilter.Location = New System.Drawing.Point(856, 107)
        Me.grpEngineerFilter.Name = "grpEngineerFilter"
        Me.grpEngineerFilter.Size = New System.Drawing.Size(639, 169)
        Me.grpEngineerFilter.TabIndex = 14
        Me.grpEngineerFilter.TabStop = False
        Me.grpEngineerFilter.Text = "Filter Engineer"
        '
        'btnfindEngineer
        '
        Me.btnfindEngineer.BackColor = System.Drawing.Color.White
        Me.btnfindEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindEngineer.Location = New System.Drawing.Point(316, 18)
        Me.btnfindEngineer.Name = "btnfindEngineer"
        Me.btnfindEngineer.Size = New System.Drawing.Size(32, 23)
        Me.btnfindEngineer.TabIndex = 84
        Me.btnfindEngineer.Text = "..."
        Me.btnfindEngineer.UseVisualStyleBackColor = False
        '
        'txtEngineer
        '
        Me.txtEngineer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngineer.Location = New System.Drawing.Point(100, 20)
        Me.txtEngineer.Name = "txtEngineer"
        Me.txtEngineer.ReadOnly = True
        Me.txtEngineer.Size = New System.Drawing.Size(201, 21)
        Me.txtEngineer.TabIndex = 83
        '
        'lblEngineer
        '
        Me.lblEngineer.Location = New System.Drawing.Point(6, 23)
        Me.lblEngineer.Name = "lblEngineer"
        Me.lblEngineer.Size = New System.Drawing.Size(85, 20)
        Me.lblEngineer.TabIndex = 85
        Me.lblEngineer.Text = "Engineer"
        '
        'btnSearchEngineer
        '
        Me.btnSearchEngineer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearchEngineer.Location = New System.Drawing.Point(563, 140)
        Me.btnSearchEngineer.Name = "btnSearchEngineer"
        Me.btnSearchEngineer.Size = New System.Drawing.Size(70, 23)
        Me.btnSearchEngineer.TabIndex = 79
        Me.btnSearchEngineer.Text = "Run Filter"
        '
        'dtpEngineerTo
        '
        Me.dtpEngineerTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpEngineerTo.Location = New System.Drawing.Point(66, 99)
        Me.dtpEngineerTo.Name = "dtpEngineerTo"
        Me.dtpEngineerTo.Size = New System.Drawing.Size(156, 21)
        Me.dtpEngineerTo.TabIndex = 82
        '
        'dtpEngineerFrom
        '
        Me.dtpEngineerFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpEngineerFrom.Location = New System.Drawing.Point(66, 63)
        Me.dtpEngineerFrom.Name = "dtpEngineerFrom"
        Me.dtpEngineerFrom.Size = New System.Drawing.Size(156, 21)
        Me.dtpEngineerFrom.TabIndex = 81
        '
        'lblEngineerTo
        '
        Me.lblEngineerTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEngineerTo.Location = New System.Drawing.Point(12, 104)
        Me.lblEngineerTo.Name = "lblEngineerTo"
        Me.lblEngineerTo.Size = New System.Drawing.Size(48, 16)
        Me.lblEngineerTo.TabIndex = 79
        Me.lblEngineerTo.Text = "To"
        '
        'lblEngineerFrom
        '
        Me.lblEngineerFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEngineerFrom.Location = New System.Drawing.Point(12, 68)
        Me.lblEngineerFrom.Name = "lblEngineerFrom"
        Me.lblEngineerFrom.Size = New System.Drawing.Size(48, 16)
        Me.lblEngineerFrom.TabIndex = 78
        Me.lblEngineerFrom.Text = "From"
        '
        'grpEngineerHistory
        '
        Me.grpEngineerHistory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpEngineerHistory.Controls.Add(Me.dgEngineerHistory)
        Me.grpEngineerHistory.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpEngineerHistory.Location = New System.Drawing.Point(856, 282)
        Me.grpEngineerHistory.Name = "grpEngineerHistory"
        Me.grpEngineerHistory.Size = New System.Drawing.Size(639, 420)
        Me.grpEngineerHistory.TabIndex = 46
        Me.grpEngineerHistory.TabStop = False
        Me.grpEngineerHistory.Text = "Engineers"
        '
        'dgEngineerHistory
        '
        Me.dgEngineerHistory.DataMember = ""
        Me.dgEngineerHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgEngineerHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgEngineerHistory.Location = New System.Drawing.Point(3, 17)
        Me.dgEngineerHistory.Name = "dgEngineerHistory"
        Me.dgEngineerHistory.Size = New System.Drawing.Size(633, 400)
        Me.dgEngineerHistory.TabIndex = 45
        '
        'grpFilter
        '
        Me.grpFilter.Controls.Add(Me.btnClear)
        Me.grpFilter.Controls.Add(Me.lblRegistration)
        Me.grpFilter.Controls.Add(Me.btnfindVan)
        Me.grpFilter.Controls.Add(Me.txtVanReg)
        Me.grpFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpFilter.Location = New System.Drawing.Point(8, 38)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(1484, 63)
        Me.grpFilter.TabIndex = 40
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'lblRegistration
        '
        Me.lblRegistration.AutoSize = True
        Me.lblRegistration.Location = New System.Drawing.Point(6, 22)
        Me.lblRegistration.Name = "lblRegistration"
        Me.lblRegistration.Size = New System.Drawing.Size(80, 13)
        Me.lblRegistration.TabIndex = 42
        Me.lblRegistration.Text = "Registration:"
        '
        'btnfindVan
        '
        Me.btnfindVan.BackColor = System.Drawing.Color.White
        Me.btnfindVan.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnfindVan.Location = New System.Drawing.Point(324, 17)
        Me.btnfindVan.Name = "btnfindVan"
        Me.btnfindVan.Size = New System.Drawing.Size(32, 23)
        Me.btnfindVan.TabIndex = 41
        Me.btnfindVan.Text = "..."
        Me.btnfindVan.UseVisualStyleBackColor = False
        '
        'txtVanReg
        '
        Me.txtVanReg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVanReg.Location = New System.Drawing.Point(108, 19)
        Me.txtVanReg.Name = "txtVanReg"
        Me.txtVanReg.ReadOnly = True
        Me.txtVanReg.Size = New System.Drawing.Size(201, 21)
        Me.txtVanReg.TabIndex = 40
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(1408, 17)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(70, 23)
        Me.btnClear.TabIndex = 79
        Me.btnClear.Text = "Clear"
        '
        'FRMFleetVanManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1502, 714)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.grpEngineerHistory)
        Me.Controls.Add(Me.grpEngineerFilter)
        Me.Controls.Add(Me.grpFaultDG)
        Me.Controls.Add(Me.grpFaultsFilter)
        Me.Name = "FRMFleetVanManager"
        Me.Text = "Fleet Van Mileage Import"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpFaultsFilter, 0)
        Me.Controls.SetChildIndex(Me.grpFaultDG, 0)
        Me.Controls.SetChildIndex(Me.grpEngineerFilter, 0)
        Me.Controls.SetChildIndex(Me.grpEngineerHistory, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.grpFaultsFilter.ResumeLayout(False)
        Me.grpFaultDG.ResumeLayout(False)
        CType(Me.dgFaults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpEngineerFilter.ResumeLayout(False)
        Me.grpEngineerFilter.PerformLayout()
        Me.grpEngineerHistory.ResumeLayout(False)
        CType(Me.dgEngineerHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Public ReadOnly Property LoadedControl() As IUserControl
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Properties"

    Private _currentVan As Entity.FleetVans.FleetVan
    Public Property CurrentVan() As Entity.FleetVans.FleetVan
        Get
            Return _currentVan
        End Get
        Set(ByVal Value As Entity.FleetVans.FleetVan)
            _currentVan = Value

            If CurrentVan Is Nothing Then
                CurrentVan = New Entity.FleetVans.FleetVan
                CurrentVan.Exists = False
                Me.txtVanReg.Text = ""
            Else
                Me.txtVanReg.Text = CurrentVan.Registration
            End If
        End Set
    End Property

    Private _engineer As Entity.Engineers.Engineer
    Public Property Engineer() As Entity.Engineers.Engineer
        Get
            Return _engineer
        End Get
        Set(ByVal Value As Entity.Engineers.Engineer)
            _engineer = Value
            If Engineer Is Nothing Then
                Engineer = New Entity.Engineers.Engineer
                CurrentVan.Exists = False
                Me.txtEngineer.Text = ""
            Else
                Me.txtEngineer.Text = Engineer.Name
            End If
        End Set
    End Property

    Private _dvFaults As DataView = Nothing
    Public Property FaultsDataView() As DataView
        Get
            Return _dvFaults
        End Get
        Set(ByVal Value As DataView)
            _dvFaults = Value
            If FaultsDataView IsNot Nothing Then
                _dvFaults.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
                _dvFaults.AllowNew = False
                _dvFaults.AllowEdit = False
                _dvFaults.AllowDelete = False
            End If
            Me.dgFaults.DataSource = FaultsDataView
        End Set
    End Property

    Private ReadOnly Property SelectedFaultDataRow() As DataRow
        Get
            If Not Me.dgFaults.CurrentRowIndex = -1 Then
                Return FaultsDataView(Me.dgFaults.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _dvEngineerHistory As DataView
    Private Property EngineerHistoryDataview() As DataView
        Get
            Return _dvEngineerHistory
        End Get
        Set(ByVal value As DataView)
            _dvEngineerHistory = value
            If EngineerHistoryDataview IsNot Nothing Then
                _dvEngineerHistory.AllowNew = False
                _dvEngineerHistory.AllowEdit = False
                _dvEngineerHistory.AllowDelete = False
                _dvEngineerHistory.Table.TableName = Entity.Sys.Enums.TableNames.tblFleetVanEngineer.ToString
            End If
            Me.dgEngineerHistory.DataSource = EngineerHistoryDataview
        End Set
    End Property

    Private ReadOnly Property SelectedEngineerDataRow() As DataRow
        Get
            If Not Me.dgEngineerHistory.CurrentRowIndex = -1 Then
                Return EngineerHistoryDataview(Me.dgEngineerHistory.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property
#End Region

#Region "Setup"
    Public Sub SetupDGFault()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgFaults)
        Dim tStyle As DataGridTableStyle = Me.dgFaults.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim reg As New DataGridLabelColumn
        reg.Format = ""
        reg.FormatInfo = Nothing
        reg.HeaderText = "Registration"
        reg.MappingName = "Registration"
        reg.ReadOnly = True
        reg.Width = 130
        reg.NullText = ""
        tStyle.GridColumnStyles.Add(reg)

        Dim faultType As New DataGridLabelColumn
        faultType.Format = ""
        faultType.FormatInfo = Nothing
        faultType.HeaderText = "Fault"
        faultType.MappingName = "Name"
        faultType.ReadOnly = True
        faultType.Width = 130
        faultType.NullText = ""
        tStyle.GridColumnStyles.Add(faultType)

        Dim faultDate As New DataGridLabelColumn
        faultDate.Format = "dd/MM/yyyy"
        faultDate.FormatInfo = Nothing
        faultDate.HeaderText = "Fault Date"
        faultDate.MappingName = "FaultDate"
        faultDate.ReadOnly = True
        faultDate.Width = 105
        faultDate.NullText = ""
        tStyle.GridColumnStyles.Add(faultDate)

        Dim resolvedDate As New DataGridLabelColumn
        resolvedDate.Format = "dd/MM/yyyy"
        resolvedDate.FormatInfo = Nothing
        resolvedDate.HeaderText = "Resolved Date"
        resolvedDate.MappingName = "ResolvedDate"
        resolvedDate.ReadOnly = True
        resolvedDate.Width = 105
        resolvedDate.NullText = ""
        tStyle.GridColumnStyles.Add(resolvedDate)

        Dim engineerNotes As New DataGridLabelColumn
        engineerNotes.Format = "dd/MM/yyyy"
        engineerNotes.FormatInfo = Nothing
        engineerNotes.HeaderText = "Engineer Notes"
        engineerNotes.MappingName = "EngineerNotes"
        engineerNotes.ReadOnly = True
        engineerNotes.Width = 200
        engineerNotes.NullText = ""
        tStyle.GridColumnStyles.Add(engineerNotes)

        Dim lastChanged As New DataGridLabelColumn
        lastChanged.Format = "dd/MM/yyyy"
        lastChanged.FormatInfo = Nothing
        lastChanged.HeaderText = "Last Changed"
        lastChanged.MappingName = "LastChanged"
        lastChanged.ReadOnly = True
        lastChanged.Width = 105
        lastChanged.NullText = ""
        tStyle.GridColumnStyles.Add(lastChanged)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanFault.ToString
        Me.dgFaults.TableStyles.Add(tStyle)

    End Sub

    Public Sub SetupDGEngineerHistory()
        Entity.Sys.Helper.SetUpDataGrid(Me.dgEngineerHistory)
        Dim tStyle As DataGridTableStyle = Me.dgEngineerHistory.TableStyles(0)

        tStyle.GridColumnStyles.Clear()

        Dim reg As New DataGridLabelColumn
        reg.Format = ""
        reg.FormatInfo = Nothing
        reg.HeaderText = "Registration"
        reg.MappingName = "Registration"
        reg.ReadOnly = True
        reg.Width = 130
        reg.NullText = ""
        tStyle.GridColumnStyles.Add(reg)

        Dim name As New DataGridLabelColumn
        name.Format = ""
        name.FormatInfo = Nothing
        name.HeaderText = "Name"
        name.MappingName = "Name"
        name.ReadOnly = True
        name.Width = 130
        name.NullText = ""
        tStyle.GridColumnStyles.Add(name)

        Dim startDate As New DataGridLabelColumn
        startDate.Format = "dd/MM/yyyy"
        startDate.FormatInfo = Nothing
        startDate.HeaderText = "From"
        startDate.MappingName = "StartDateTime"
        startDate.ReadOnly = True
        startDate.Width = 150
        startDate.NullText = ""
        tStyle.GridColumnStyles.Add(startDate)

        Dim endDate As New DataGridLabelColumn
        endDate.Format = "dd/MM/yyyy"
        endDate.FormatInfo = Nothing
        endDate.HeaderText = "To"
        endDate.MappingName = "EndDateTime"
        endDate.ReadOnly = True
        endDate.Width = 150
        endDate.NullText = ""
        tStyle.GridColumnStyles.Add(endDate)

        tStyle.ReadOnly = True
        tStyle.MappingName = Entity.Sys.Enums.TableNames.tblFleetVanEngineer.ToString
        Me.dgEngineerHistory.TableStyles.Add(tStyle)

    End Sub
#End Region

#Region "Events"

    Private Sub FRMImport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetupDGFault()
        SetupDGEngineerHistory()
    End Sub

    Private Sub btnfindVan_Click(sender As Object, e As EventArgs) Handles btnfindVan.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblFleetVan)
        If Not ID = 0 Then
            CurrentVan = DB.FleetVan.Get(ID)
        End If
    End Sub

    Private Sub btnfindEngineer_Click(sender As Object, e As EventArgs) Handles btnfindEngineer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblEngineer)
        If Not ID = 0 Then
            Engineer = DB.Engineer.Engineer_Get(ID)
        End If
    End Sub

    Private Sub btnSearchFault_Click(sender As Object, e As EventArgs) Handles btnSearchFault.Click
        PopulateFaultsDatagrid()
    End Sub

    Private Sub btnSearchEngineer_Click(sender As Object, e As EventArgs) Handles btnSearchEngineer.Click
        PopulateEngineerDatagrid()
    End Sub

    Private Sub dgFaults_DoubleClick(sender As Object, e As EventArgs) Handles dgFaults.DoubleClick
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblFleetVan)
        If Not ID = 0 Then
            Dim newVan As Entity.FleetVans.FleetVan = DB.FleetVan.Get(ID)
            If newVan IsNot Nothing Then
                If ShowMessage("Move fault? The fault will now be assigned to: " & newVan.Registration &
                               ", Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim faultToMove As Entity.FleetVans.FleetVanFault = DB.FleetVanFault.Get(SelectedFaultDataRow.Item("VanFaultID"))
                    faultToMove.SetVanID = newVan.VanID
                    DB.FleetVanFault.Update(faultToMove)

                    ShowMessage("Fault has been moved to " & newVan.Registration, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        FaultsDataView = Nothing
        EngineerHistoryDataview = Nothing
        CurrentVan = Nothing
        Engineer = Nothing
    End Sub
#End Region

#Region "Functions"
    Public Sub PopulateFaultsDatagrid()
        Try
            Dim whereClause As String = "(1 = 1"

            If Not CurrentVan Is Nothing Then
                whereClause += " AND tblFleetVan.VanID = " & CurrentVan.VanID & ""
            End If
            If Not Combo.GetSelectedItemValue(Me.cboFaultType) = 0 Then
                whereClause += " AND tblFleetVanFault.FaultType = " & Combo.GetSelectedItemValue(Me.cboFaultType) & ""
            End If
            If Me.chkFaultDate.Checked Then
                whereClause += " AND tblFleetVanFault.FaultDate >= '" & Format(Me.dtpFaultFrom.Value, "dd-MMM-yyyy 00:00:00") &
                    "' AND tblFleetVanFault.FaultDate <= '" & Format(Me.dtpFaultTo.Value, "dd-MMM-yyyy 23:59:59") & "'"
            End If
            If Me.chkResolved.Checked Then
                whereClause += " AND tblFleetVanFault.ResolvedDate >= '" & Format(Me.dtpResolvedFrom.Value, "dd-MMM-yyyy 00:00:00") &
                    "' AND tblFleetVanFault.ResolvedDate <= '" & Format(Me.dtpResolvedTo.Value, "dd-MMM-yyyy 23:59:59") & "'"
            End If

            whereClause += ")"

            FaultsDataView = DB.FleetVanFault.GetAll_Trans(whereClause)

            Dim count As Integer = 0
            count = FaultsDataView.Count
            Me.grpFaultDG.Text = "Double Click To Move Fault (" + CStr(count) + ")"

        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub PopulateEngineerDatagrid()
        Try
            Dim whereClause As String = "(1 = 1"

            If Not CurrentVan Is Nothing Then
                whereClause += " AND tblFleetVan.VanID = " & CurrentVan.VanID & ""
            End If
            If Not Engineer Is Nothing Then
                whereClause += " AND tblFleetVanEngineer.EngineerID = " & Engineer.EngineerID & ""
            End If
            whereClause += " AND tblFleetVanEngineer.StartDateTime >= '" & Format(Me.dtpEngineerFrom.Value, "dd-MMM-yyyy 00:00:00") & "'" &
                " And tblFleetVanEngineer.StartDateTime <= '" & Format(Me.dtpEngineerTo.Value, "dd-MMM-yyyy 23:59:59") & "'" &
                " AND ((tblFleetVanEngineer.EndDateTime >= '" & Format(Me.dtpEngineerFrom.Value, "dd-MMM-yyyy 00:00:00") & "'" &
                    " AND tblFleetVanEngineer.EndDateTime <= '" & Format(Me.dtpEngineerTo.Value, "dd-MMM-yyyy 23:59:59") & "')" &
                    "Or tblFleetVanEngineer.EndDateTime Is NULL)"
            whereClause += ")"

            EngineerHistoryDataview = DB.FleetVanEngineer.GetAll_Trans(whereClause)
            Dim count As Integer = 0
            count = EngineerHistoryDataview.Count
            Me.grpEngineerHistory.Text = "Vehicles (" + CStr(count) + ")"

        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

End Class
