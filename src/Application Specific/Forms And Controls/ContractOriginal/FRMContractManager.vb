Imports System.Collections.Generic
Imports FSM.Entity.ContactAttempts
Imports FSM.Entity.Sys

Public Class FRMContractManager : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox

    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtContractReference As System.Windows.Forms.TextBox
    Friend WithEvents grpContracts As System.Windows.Forms.GroupBox
    Friend WithEvents dgContracts As System.Windows.Forms.DataGrid
    Friend WithEvents cbxContractExpiryDate As System.Windows.Forms.CheckBox
    Friend WithEvents cbxAllVisitsComplete As System.Windows.Forms.CheckBox
    Friend WithEvents btnRenew As System.Windows.Forms.Button
    Friend WithEvents btnPrintExpiryLetter As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button
    Friend WithEvents btnActivate As System.Windows.Forms.Button
    Friend WithEvents btnDeActive As System.Windows.Forms.Button
    Friend WithEvents cbxCancelledDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceFrequency As System.Windows.Forms.ComboBox
    Friend WithEvents chxStartedBetween As System.Windows.Forms.CheckBox
    Friend WithEvents btnResetFilters As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboRenewal As System.Windows.Forms.ComboBox
    Friend WithEvents cbxDoNotRenew As System.Windows.Forms.CheckBox
    Friend WithEvents pbStatus As System.Windows.Forms.ProgressBar

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.cbxDoNotRenew = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboRenewal = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.btnResetFilters = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboInvoiceFrequency = New System.Windows.Forms.ComboBox()
        Me.chxStartedBetween = New System.Windows.Forms.CheckBox()
        Me.cbxCancelledDate = New System.Windows.Forms.CheckBox()
        Me.cbxAllVisitsComplete = New System.Windows.Forms.CheckBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtContractReference = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxContractExpiryDate = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpContracts = New System.Windows.Forms.GroupBox()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.dgContracts = New System.Windows.Forms.DataGrid()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnRenew = New System.Windows.Forms.Button()
        Me.btnPrintExpiryLetter = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.btnActivate = New System.Windows.Forms.Button()
        Me.btnDeActive = New System.Windows.Forms.Button()
        Me.grpFilter.SuspendLayout()
        Me.grpContracts.SuspendLayout()
        CType(Me.dgContracts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.cbxDoNotRenew)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.CboRenewal)
        Me.grpFilter.Controls.Add(Me.Label13)
        Me.grpFilter.Controls.Add(Me.cboRegion)
        Me.grpFilter.Controls.Add(Me.btnResetFilters)
        Me.grpFilter.Controls.Add(Me.btnSearch)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.cboInvoiceFrequency)
        Me.grpFilter.Controls.Add(Me.chxStartedBetween)
        Me.grpFilter.Controls.Add(Me.cbxCancelledDate)
        Me.grpFilter.Controls.Add(Me.cbxAllVisitsComplete)
        Me.grpFilter.Controls.Add(Me.btnFindCustomer)
        Me.grpFilter.Controls.Add(Me.txtCustomer)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.txtContractReference)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.cbxContractExpiryDate)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Controls.Add(Me.Label11)
        Me.grpFilter.Controls.Add(Me.cboStatus)
        Me.grpFilter.Controls.Add(Me.Label10)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(882, 206)
        Me.grpFilter.TabIndex = 17
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'cbxDoNotRenew
        '
        Me.cbxDoNotRenew.BackColor = System.Drawing.Color.White
        Me.cbxDoNotRenew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbxDoNotRenew.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDoNotRenew.Location = New System.Drawing.Point(104, 149)
        Me.cbxDoNotRenew.Name = "cbxDoNotRenew"
        Me.cbxDoNotRenew.Size = New System.Drawing.Size(192, 24)
        Me.cbxDoNotRenew.TabIndex = 40
        Me.cbxDoNotRenew.Text = "Also Show Do Not renew "
        Me.cbxDoNotRenew.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(532, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 16)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Renewed"
        '
        'CboRenewal
        '
        Me.CboRenewal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboRenewal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRenewal.Location = New System.Drawing.Point(659, 145)
        Me.CboRenewal.Name = "CboRenewal"
        Me.CboRenewal.Size = New System.Drawing.Size(167, 21)
        Me.CboRenewal.TabIndex = 38
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(532, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 16)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Region"
        '
        'cboRegion
        '
        Me.cboRegion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.Location = New System.Drawing.Point(659, 118)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(167, 21)
        Me.cboRegion.TabIndex = 36
        '
        'btnResetFilters
        '
        Me.btnResetFilters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnResetFilters.Location = New System.Drawing.Point(651, 171)
        Me.btnResetFilters.Name = "btnResetFilters"
        Me.btnResetFilters.Size = New System.Drawing.Size(96, 23)
        Me.btnResetFilters.TabIndex = 31
        Me.btnResetFilters.Text = "Reset Filters"
        Me.btnResetFilters.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(753, 171)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 30
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(532, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 19)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Invoice Frequency"
        '
        'cboInvoiceFrequency
        '
        Me.cboInvoiceFrequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboInvoiceFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInvoiceFrequency.Location = New System.Drawing.Point(659, 91)
        Me.cboInvoiceFrequency.Name = "cboInvoiceFrequency"
        Me.cboInvoiceFrequency.Size = New System.Drawing.Size(167, 21)
        Me.cboInvoiceFrequency.TabIndex = 28
        '
        'chxStartedBetween
        '
        Me.chxStartedBetween.BackColor = System.Drawing.Color.White
        Me.chxStartedBetween.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chxStartedBetween.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chxStartedBetween.Location = New System.Drawing.Point(104, 86)
        Me.chxStartedBetween.Name = "chxStartedBetween"
        Me.chxStartedBetween.Size = New System.Drawing.Size(192, 24)
        Me.chxStartedBetween.TabIndex = 27
        Me.chxStartedBetween.Text = "Contract Started between"
        Me.chxStartedBetween.UseVisualStyleBackColor = False
        '
        'cbxCancelledDate
        '
        Me.cbxCancelledDate.BackColor = System.Drawing.Color.White
        Me.cbxCancelledDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbxCancelledDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCancelledDate.Location = New System.Drawing.Point(104, 128)
        Me.cbxCancelledDate.Name = "cbxCancelledDate"
        Me.cbxCancelledDate.Size = New System.Drawing.Size(192, 24)
        Me.cbxCancelledDate.TabIndex = 26
        Me.cbxCancelledDate.Text = "Contract Cancelled between"
        Me.cbxCancelledDate.UseVisualStyleBackColor = False
        '
        'cbxAllVisitsComplete
        '
        Me.cbxAllVisitsComplete.Location = New System.Drawing.Point(104, 111)
        Me.cbxAllVisitsComplete.Name = "cbxAllVisitsComplete"
        Me.cbxAllVisitsComplete.Size = New System.Drawing.Size(192, 16)
        Me.cbxAllVisitsComplete.TabIndex = 25
        Me.cbxAllVisitsComplete.Text = "All Visits Complete"
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(834, 16)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 2
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(104, 16)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(722, 21)
        Me.txtCustomer.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Customer"
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.Location = New System.Drawing.Point(576, 64)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(250, 21)
        Me.dtpTo.TabIndex = 13
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(328, 64)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(184, 21)
        Me.dtpFrom.TabIndex = 12
        '
        'txtContractReference
        '
        Me.txtContractReference.Location = New System.Drawing.Point(104, 40)
        Me.txtContractReference.Name = "txtContractReference"
        Me.txtContractReference.Size = New System.Drawing.Size(184, 21)
        Me.txtContractReference.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(520, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "And"
        '
        'cbxContractExpiryDate
        '
        Me.cbxContractExpiryDate.BackColor = System.Drawing.Color.White
        Me.cbxContractExpiryDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbxContractExpiryDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxContractExpiryDate.Location = New System.Drawing.Point(104, 64)
        Me.cbxContractExpiryDate.Name = "cbxContractExpiryDate"
        Me.cbxContractExpiryDate.Size = New System.Drawing.Size(176, 24)
        Me.cbxContractExpiryDate.TabIndex = 11
        Me.cbxContractExpiryDate.Text = "Contract Expiries between"
        Me.cbxContractExpiryDate.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Contract Ref."
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(328, 40)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(184, 21)
        Me.cboType.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(520, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(576, 40)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(250, 21)
        Me.cboStatus.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(292, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type"
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 544)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 19
        Me.btnExport.Text = "Export"
        '
        'grpContracts
        '
        Me.grpContracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpContracts.Controls.Add(Me.btnSelectAll)
        Me.grpContracts.Controls.Add(Me.btnDeselectAll)
        Me.grpContracts.Controls.Add(Me.dgContracts)
        Me.grpContracts.Location = New System.Drawing.Point(8, 244)
        Me.grpContracts.Name = "grpContracts"
        Me.grpContracts.Size = New System.Drawing.Size(882, 294)
        Me.grpContracts.TabIndex = 18
        Me.grpContracts.TabStop = False
        Me.grpContracts.Text = "Double Click To View / Edit"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.AccessibleDescription = "Export Job List To Excel"
        Me.btnSelectAll.Location = New System.Drawing.Point(8, 13)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(88, 23)
        Me.btnSelectAll.TabIndex = 21
        Me.btnSelectAll.Text = "Select All"
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Location = New System.Drawing.Point(104, 13)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(88, 23)
        Me.btnDeselectAll.TabIndex = 22
        Me.btnDeselectAll.Text = "Deselect All"
        '
        'dgContracts
        '
        Me.dgContracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgContracts.DataMember = ""
        Me.dgContracts.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgContracts.Location = New System.Drawing.Point(8, 42)
        Me.dgContracts.Name = "dgContracts"
        Me.dgContracts.Size = New System.Drawing.Size(866, 244)
        Me.dgContracts.TabIndex = 14
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 544)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 20
        Me.btnReset.Text = "Reset"
        '
        'btnRenew
        '
        Me.btnRenew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRenew.Location = New System.Drawing.Point(136, 544)
        Me.btnRenew.Name = "btnRenew"
        Me.btnRenew.Size = New System.Drawing.Size(56, 23)
        Me.btnRenew.TabIndex = 21
        Me.btnRenew.Text = "Renew"
        '
        'btnPrintExpiryLetter
        '
        Me.btnPrintExpiryLetter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintExpiryLetter.Location = New System.Drawing.Point(746, 544)
        Me.btnPrintExpiryLetter.Name = "btnPrintExpiryLetter"
        Me.btnPrintExpiryLetter.Size = New System.Drawing.Size(136, 23)
        Me.btnPrintExpiryLetter.TabIndex = 22
        Me.btnPrintExpiryLetter.Text = "Print Expiry Letters"
        '
        'pbStatus
        '
        Me.pbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbStatus.Location = New System.Drawing.Point(373, 544)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(365, 23)
        Me.pbStatus.TabIndex = 23
        '
        'btnActivate
        '
        Me.btnActivate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnActivate.Location = New System.Drawing.Point(198, 544)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(74, 23)
        Me.btnActivate.TabIndex = 24
        Me.btnActivate.Text = "Activate"
        '
        'btnDeActive
        '
        Me.btnDeActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeActive.Location = New System.Drawing.Point(278, 544)
        Me.btnDeActive.Name = "btnDeActive"
        Me.btnDeActive.Size = New System.Drawing.Size(89, 23)
        Me.btnDeActive.TabIndex = 25
        Me.btnDeActive.Text = "Deactivate"
        '
        'FRMContractManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(898, 574)
        Me.Controls.Add(Me.btnDeActive)
        Me.Controls.Add(Me.btnActivate)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.btnPrintExpiryLetter)
        Me.Controls.Add(Me.btnRenew)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpContracts)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMContractManager"
        Me.Text = "Contract Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpContracts, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.btnRenew, 0)
        Me.Controls.SetChildIndex(Me.btnPrintExpiryLetter, 0)
        Me.Controls.SetChildIndex(Me.pbStatus, 0)
        Me.Controls.SetChildIndex(Me.btnActivate, 0)
        Me.Controls.SetChildIndex(Me.btnDeActive, 0)
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.grpContracts.ResumeLayout(False)
        CType(Me.dgContracts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        Loading = True

        LoadForm(sender, e, Me)

        SetupContractsDataGrid()
        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ContractTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboInvoiceFrequency, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.CboRenewal, DynamicDataTables.ContractRenewal, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        ResetFilters()
        'PopulateDatagrid()
        Loading = False
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

    Private _Contracts As DataView

    Private Property Contracts() As DataView
        Get
            Return _Contracts
        End Get
        Set(ByVal value As DataView)
            _Contracts = value
            _Contracts.AllowNew = False
            _Contracts.AllowEdit = False
            _Contracts.AllowDelete = False
            _Contracts.Table.TableName = Entity.Sys.Enums.TableNames.tblContract.ToString
            Me.dgContracts.DataSource = Contracts
        End Set
    End Property

    Private ReadOnly Property SelectedContractDataRow() As DataRow
        Get
            If Not Me.dgContracts.CurrentRowIndex = -1 Then
                Return Contracts(Me.dgContracts.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _theCustomer As Entity.Customers.Customer

    Public Property theCustomer() As Entity.Customers.Customer
        Get
            Return _theCustomer
        End Get
        Set(ByVal Value As Entity.Customers.Customer)
            _theCustomer = Value
            If Not _theCustomer Is Nothing Then
                Me.txtCustomer.Text = theCustomer.Name & " (A/C No : " & theCustomer.AccountNumber & ")"
            Else
                Me.txtCustomer.Text = ""
            End If
        End Set
    End Property

    Private _Loading As Boolean = True

    Public Property Loading() As Boolean
        Get
            Return _Loading
        End Get
        Set(ByVal Value As Boolean)
            _Loading = Value
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupContractsDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgContracts.TableStyles(0)

        Dim tick As New DataGridBoolColumn
        tick.HeaderText = ""
        tick.MappingName = "tick"
        tick.ReadOnly = True
        tick.Width = 25
        tick.NullText = ""
        tbStyle.GridColumnStyles.Add(tick)

        Dim madeContact As New DataGridBoolColumn
        madeContact.HeaderText = "Contact Made"
        madeContact.MappingName = "ContactMade"
        madeContact.ReadOnly = True
        madeContact.Width = 100
        madeContact.NullText = ""
        tbStyle.GridColumnStyles.Add(madeContact)

        Dim PropertySite As New DataGridLabelColumn
        PropertySite.Format = ""
        PropertySite.FormatInfo = Nothing
        PropertySite.HeaderText = "Property"
        PropertySite.MappingName = "Property"
        PropertySite.ReadOnly = True
        PropertySite.Width = 150
        PropertySite.NullText = ""
        tbStyle.GridColumnStyles.Add(PropertySite)

        Dim ContractReference As New DataGridLabelColumn
        ContractReference.Format = ""
        ContractReference.FormatInfo = Nothing
        ContractReference.HeaderText = "Contract Reference"
        ContractReference.MappingName = "ContractReference"
        ContractReference.ReadOnly = True
        ContractReference.Width = 120
        ContractReference.NullText = ""
        tbStyle.GridColumnStyles.Add(ContractReference)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 100
        Type.NullText = ""
        tbStyle.GridColumnStyles.Add(Type)

        Dim ContractStatus As New DataGridLabelColumn
        ContractStatus.Format = ""
        ContractStatus.FormatInfo = Nothing
        ContractStatus.HeaderText = "Contract Status"
        ContractStatus.MappingName = "ContractStatus"
        ContractStatus.ReadOnly = True
        ContractStatus.Width = 100
        ContractStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(ContractStatus)

        Dim ContractStartDate As New DataGridLabelColumn
        ContractStartDate.Format = "dd/MMM/yyyy"
        ContractStartDate.FormatInfo = Nothing
        ContractStartDate.HeaderText = "Start Date"
        ContractStartDate.MappingName = "ContractStartDate"
        ContractStartDate.ReadOnly = True
        ContractStartDate.Width = 80
        ContractStartDate.NullText = ""
        tbStyle.GridColumnStyles.Add(ContractStartDate)

        Dim ContractEndDate As New DataGridLabelColumn
        ContractEndDate.Format = "dd/MMM/yyyy"
        ContractEndDate.FormatInfo = Nothing
        ContractEndDate.HeaderText = "End Date"
        ContractEndDate.MappingName = "ContractEndDate"
        ContractEndDate.ReadOnly = True
        ContractEndDate.Width = 80
        ContractEndDate.NullText = ""
        tbStyle.GridColumnStyles.Add(ContractEndDate)

        Dim ContractPrice As New DataGridLabelColumn
        ContractPrice.Format = "C"
        ContractPrice.FormatInfo = Nothing
        ContractPrice.HeaderText = "Contract Price"
        ContractPrice.MappingName = "ContractPrice"
        ContractPrice.ReadOnly = True
        ContractPrice.Width = 90
        ContractPrice.NullText = ""
        tbStyle.GridColumnStyles.Add(ContractPrice)

        Dim Renewed As New DataGridContractColumn
        Renewed.Format = ""
        Renewed.FormatInfo = Nothing
        Renewed.HeaderText = "Renewed"
        Renewed.MappingName = "Renewed"
        Renewed.ReadOnly = True
        Renewed.Width = 100
        Renewed.NullText = ""
        tbStyle.GridColumnStyles.Add(Renewed)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 150
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim CancelledDate As New DataGridLabelColumn
        CancelledDate.HeaderText = "Cancelled Date"
        CancelledDate.MappingName = "CancelledDate"
        CancelledDate.ReadOnly = True
        CancelledDate.Width = 100
        CancelledDate.NullText = "n/a"
        tbStyle.GridColumnStyles.Add(CancelledDate)

        Dim CancelledReason As New DataGridLabelColumn
        CancelledReason.Format = ""
        CancelledReason.FormatInfo = Nothing
        CancelledReason.HeaderText = "Cancelled Reason"
        CancelledReason.MappingName = "CancelledReason"
        CancelledReason.ReadOnly = True
        CancelledReason.Width = 150
        CancelledReason.NullText = ""
        tbStyle.GridColumnStyles.Add(CancelledReason)

        Dim GasSupplyPipework As New DataGridLabelColumn
        GasSupplyPipework.Format = ""
        GasSupplyPipework.FormatInfo = Nothing
        GasSupplyPipework.HeaderText = "AHE"
        GasSupplyPipework.MappingName = "AHE" 'change for ahe
        GasSupplyPipework.ReadOnly = True
        GasSupplyPipework.Width = 80
        GasSupplyPipework.NullText = ""
        tbStyle.GridColumnStyles.Add(GasSupplyPipework)

        Dim InvoiceFrequency As New DataGridLabelColumn
        InvoiceFrequency.Format = ""
        InvoiceFrequency.FormatInfo = Nothing
        InvoiceFrequency.HeaderText = "Invoice Frequency"
        InvoiceFrequency.MappingName = "InvoiceFrequency"
        InvoiceFrequency.ReadOnly = True
        InvoiceFrequency.Width = 100
        InvoiceFrequency.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceFrequency)

        Dim madeContactDate As New DataGridLabelColumn
        madeContactDate.HeaderText = "Date Contact Made"
        madeContactDate.MappingName = "DateContactMade"
        madeContactDate.ReadOnly = True
        madeContactDate.Width = 120
        madeContactDate.NullText = ""
        tbStyle.GridColumnStyles.Add(madeContactDate)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblContract.ToString

        Me.dgContracts.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMContractManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            theCustomer = DB.Customer.Customer_Get(ID)
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub cbxContractExpiryDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxContractExpiryDate.CheckedChanged
        If Me.cbxContractExpiryDate.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
    End Sub

    Private Sub cbxCancelledDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCancelledDate.CheckedChanged
        If Me.cbxCancelledDate.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
    End Sub

    Private Sub chxStartedBetween_CheckedChanged(sender As Object, e As EventArgs) Handles chxStartedBetween.CheckedChanged
        If Me.chxStartedBetween.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
    End Sub

    Private Sub cbxAllVisitsComplete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxAllVisitsComplete.CheckedChanged
        If Me.cbxAllVisitsComplete.Checked Then
            cbxContractExpiryDate.Checked = False
            cbxCancelledDate.Checked = False
            chxStartedBetween.Checked = False
        End If
    End Sub

    Private Sub dgContracts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContracts.DoubleClick
        If SelectedContractDataRow Is Nothing Then
            Exit Sub
        End If

        If SelectedContractDataRow("ContractType") = Entity.Sys.Enums.QuoteType.Contract_Opt_1.ToString Then
            ShowForm(GetType(FRMContractOriginal), True, New Object() {Entity.Sys.Helper.MakeIntegerValid(SelectedContractDataRow.Item("ContractID")), SelectedContractDataRow.Item("CustomerID"), 0, Me})
        End If
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click

        If Not SelectedContractDataRow Is Nothing Then

            If Entity.Sys.Helper.MakeIntegerValid(SelectedContractDataRow("NewContractID")) <> 0 Then
                If ShowMessage("This contract has already been renewed. Would you like to reprint the renewal document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Select Case Entity.Sys.Helper.MakeStringValid(SelectedContractDataRow("ContractType"))
                        Case Entity.Sys.Enums.QuoteType.Contract_Opt_1.ToString
                            Dim newContractID As Integer = DB.ContractManager.ContractRenewals_GetNewID_ByOldID(SelectedContractDataRow("ContractID"), CInt(Entity.Sys.Enums.QuoteType.Contract_Opt_1))
                            Dim dtContracts As DataTable = DB.ContractOriginal.ProcessContract(newContractID)
                            If dtContracts Is Nothing Then Exit Sub
                            Dim details As New ArrayList() From {dtContracts}
                            Dim oPrint As New Entity.Sys.Printing(details, "", Entity.Sys.Enums.SystemDocumentType.ContractOption1)
                    End Select
                End If
            Else
                ShowForm(GetType(FRMContractRenewal), True, New Object() {SelectedContractDataRow("ContractType"), SelectedContractDataRow("ContractID"), Me})
            End If
        End If
    End Sub

    Private Sub btnPrintExpiryLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintExpiryLetter.Click
        Me.pbStatus.Value = 0
        Me.pbStatus.Maximum = CType(dgContracts.DataSource, DataView).Count + CType(dgContracts.DataSource, DataView).Count + 5

        Dim ContractIDs As String = ""
        For itm As Integer = 0 To CType(dgContracts.DataSource, DataView).Count - 1
            dgContracts.CurrentRowIndex = itm
            ContractIDs += SelectedContractDataRow("ContractID") & ","
        Next
        If ContractIDs.Length > 0 Then
            ContractIDs = ContractIDs.Substring(0, ContractIDs.Length - 1)
        End If

        Dim dvAddresses As DataView = DB.ContractManager.Contracts_GetAddresses(ContractIDs)

        Dim printData As New DataTable
        printData.Columns.Add("ContractID")
        printData.Columns.Add("ContractReference")
        printData.Columns.Add("Name")
        printData.Columns.Add("Address1")
        printData.Columns.Add("Address2")
        printData.Columns.Add("Address3")
        printData.Columns.Add("Address4")
        printData.Columns.Add("Address5")
        printData.Columns.Add("Postcode")
        printData.Columns.Add("ContractEndDate")
        printData.Columns.Add("Cheque")
        printData.Columns.Add("CreditCard")
        printData.Columns.Add("DirectDebit")
        printData.Columns.Add("ContractType")
        printData.Columns.Add("SiteAddress1")

        For itm As Integer = 0 To CType(dgContracts.DataSource, DataView).Count - 1
            dgContracts.CurrentRowIndex = itm
            Dim newRw As DataRow
            newRw = printData.NewRow
            newRw("ContractID") = SelectedContractDataRow("ContractID")
            newRw("ContractReference") = SelectedContractDataRow("ContractReference")
            newRw("ContractEndDate") = SelectedContractDataRow("ContractEndDate")
            newRw("Cheque") = SelectedContractDataRow("Cheque")
            newRw("CreditCard") = SelectedContractDataRow("CreditCard")
            newRw("DirectDebit") = SelectedContractDataRow("DirectDebit")
            newRw("ContractType") = SelectedContractDataRow("Type")
            newRw("SiteAddress1") = SelectedContractDataRow("SiteAddress1")

            If SelectedContractDataRow("CustomerID") = Entity.Sys.Enums.Customer.Domestic Then
                'GET SITE ADDRESS FOR DOMESTIC CUSTOMER
                'drAdd = dvAddresses.Table.Select("Type='Site' AND ContractID=" & SelectedContractDataRow("ContractID"))
                newRw("Name") = Entity.Sys.Helper.MakeStringValid(SelectedContractDataRow("SiteName"))
                newRw("Address1") = Entity.Sys.Helper.MakeStringValid(SelectedContractDataRow("SiteAddress1"))
                newRw("Address2") = Entity.Sys.Helper.MakeStringValid(SelectedContractDataRow("SiteAddress2"))
                newRw("Address3") = Entity.Sys.Helper.MakeStringValid(SelectedContractDataRow("SiteAddress3"))
                newRw("Address4") = Entity.Sys.Helper.MakeStringValid(SelectedContractDataRow("SiteAddress4"))
                newRw("Address5") = Entity.Sys.Helper.MakeStringValid(SelectedContractDataRow("SiteAddress5"))
                newRw("Postcode") = Entity.Sys.Helper.MakeStringValid(SelectedContractDataRow("SitePostcode"))
            Else  'ELSE CUSTOMER HQ
                Dim drAdd As DataRow()
                drAdd = dvAddresses.Table.Select("Type='HQ' AND ContractID=" & SelectedContractDataRow("ContractID"))
                If drAdd.Length > 0 Then
                    newRw("Name") = Entity.Sys.Helper.MakeStringValid(drAdd(0)("Name"))
                    newRw("Address1") = Entity.Sys.Helper.MakeStringValid(drAdd(0)("Address1"))
                    newRw("Address2") = Entity.Sys.Helper.MakeStringValid(drAdd(0)("Address2"))
                    newRw("Address3") = Entity.Sys.Helper.MakeStringValid(drAdd(0)("Address3"))
                    newRw("Address4") = Entity.Sys.Helper.MakeStringValid(drAdd(0)("Address4"))
                    newRw("Address5") = Entity.Sys.Helper.MakeStringValid(drAdd(0)("Address5"))
                    newRw("Postcode") = Entity.Sys.Helper.MakeStringValid(drAdd(0)("Postcode"))
                Else
                    newRw("Name") = ""
                    newRw("Address1") = ""
                    newRw("Address2") = ""
                    newRw("Address3") = ""
                    newRw("Address4") = ""
                    newRw("Address5") = ""
                    newRw("Postcode") = ""
                End If
            End If

            printData.Rows.Add(newRw)
            dgContracts.UnSelect(itm)
            MoveProgressOn()
        Next itm

        Dim details As New ArrayList
        details.Add(printData)
        details.Add(Me)
        Dim oPrint As New Entity.Sys.Printing(details, "Contract_Expiry_Letter", Entity.Sys.Enums.SystemDocumentType.ContractExpiry, True)
        For itm As Integer = 0 To CType(dgContracts.DataSource, DataView).Count - 1
            dgContracts.CurrentRowIndex = itm
            DB.ExecuteScalar("UPDATE tblContractOriginal SET Printed = 1 WHERE ContractID = " & CInt(SelectedContractDataRow("ContractID")))
        Next itm
        MoveProgressOn(True)

    End Sub

    Private Sub dgContracts_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgContracts.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgContracts.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            If HitTestInfo.Column = 0 Then
                Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(SelectedContractDataRow.Item("tick"))
                SelectedContractDataRow.Item("Tick") = selected
            End If

            If HitTestInfo.Column = 1 Then
                Dim contactMade As Boolean = Entity.Sys.Helper.MakeBooleanValid(SelectedContractDataRow.Item("ContactMade"))
                If contactMade Then Exit Sub

                Dim f As New FRMGenDropBox
                Dim contactMethod As DataTable = DB.ContactAttempts.ContactMethod_GetAll().Table
                f.cbo2.Items.Clear()

                Dim dt As New DataTable
                dt.Columns.Add(New DataColumn("ValueMember"))
                dt.Columns.Add(New DataColumn("DisplayMember"))
                dt.Columns.Add(New DataColumn("Deleted"))

                For Each dr As DataRow In contactMethod.Rows
                    dt.Rows.Add(New String() {dr("ContactMethodID"), dr("Name"), "0"})
                Next

                Combo.SetUpCombo(f.cbo2, dt, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
                f.cbo1.Visible = False
                f.cbo2.Visible = True
                f.lblTop.Text = "Please select method of contact"
                f.lblMiddle.Text = ""
                f.lblref.Text = ""
                f.txtref.Visible = False
                f.ShowDialog()

                If f.DialogResult = DialogResult.Cancel Then
                    Exit Sub
                End If

                Dim contactAttempt As New ContactAttempt
                With contactAttempt
                    .ContactMethedID = Combo.GetSelectedItemValue(f.cbo2)
                    .LinkID = CInt(Enums.TableNames.tblContract)
                    .LinkRef = Helper.MakeIntegerValid(SelectedContractDataRow("ContractID"))
                    .ContactMade = Now
                    .Notes = ""
                    .ContactMadeByUserId = loggedInUser.UserID
                End With
                contactAttempt = DB.ContactAttempts.Insert(contactAttempt)

                If contactAttempt.ContactAttemptID > 0 Then
                    SelectedContractDataRow.Item("ContactMade") = True
                    SelectedContractDataRow.Item("DateContactMade") = Now
                End If

            End If
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If Contracts IsNot Nothing AndAlso Contracts.Count > 0 Then
            For Each dr As DataRow In Contracts.Table.Rows
                dr("tick") = 1
            Next
        End If

    End Sub

    Private Sub btnDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        If Contracts IsNot Nothing AndAlso Contracts.Count > 0 Then
            For Each dr As DataRow In Contracts.Table.Rows
                dr("tick") = 0
            Next
        End If
    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivate.Click
        Dim oContracts As New List(Of Integer)

        If ShowMessage("This will set the status of the selected contracts to active. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For Each dr As DataRowView In Contracts
                If Entity.Sys.Helper.MakeBooleanValid(dr("tick")) = True Then

                    Dim CurrentContract As Entity.ContractsOriginal.ContractOriginal
                    CurrentContract = DB.ContractOriginal.Get(dr("ContractID"))

                    Dim Sites As DataView
                    Sites = DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, CurrentContract.CustomerID)

                    If Not CurrentContract Is Nothing Then
                        'IF UPDATING
                        If CurrentContract.Exists = True Then
                            'REACTIVE ANY SITE JOBS PREVIOUSLY DEACTIVATED
                            For Each site As DataRow In Sites.Table.Rows
                                If site("ContractSiteID") > 0 Then
                                    DB.ContractOriginalSite.ActiveInactive(site("ContractSiteID"), False)
                                End If
                            Next site
                            oContracts.Add(Helper.MakeIntegerValid(dr("ContractID")))
                        End If
                    End If
                    CurrentContract.SetContractStatusID = CInt(Entity.Sys.Enums.ContractStatus.Active)
                    DB.ContractOriginal.Update(CurrentContract)

                End If
            Next

            If oContracts.Count > 0 Then
                Dim oPrint As New Entity.Sys.Printing(oContracts, "Certificates", Entity.Sys.Enums.SystemDocumentType.ContractOption1, True)
            End If

            PopulateDatagrid()
        End If
    End Sub

    Private Sub btnDeActive_Click(sender As Object, e As EventArgs) Handles btnDeActive.Click
        If ShowMessage("This will set the status of the selected contracts to inactive. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            For Each dr As DataRowView In Contracts
                If Entity.Sys.Helper.MakeBooleanValid(dr("tick")) = True Then

                    Dim CurrentContract As Entity.ContractsOriginal.ContractOriginal
                    CurrentContract = DB.ContractOriginal.Get(dr("ContractID"))

                    Dim Sites As DataView
                    Sites = DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, CurrentContract.CustomerID)

                    If Not CurrentContract Is Nothing Then
                        'IF UPDATING
                        If CurrentContract.Exists = True Then
                            'REACTIVE ANY SITE JOBS PREVIOUSLY DEACTIVATED
                            For Each site As DataRow In Sites.Table.Rows
                                If site("ContractSiteID") > 0 Then
                                    DB.ContractOriginalSite.ActiveInactive(site("ContractSiteID"), True)
                                End If
                            Next site
                        End If
                    End If

                    CurrentContract.SetContractStatusID = CInt(Entity.Sys.Enums.ContractStatus.Inactive)
                    CurrentContract.CancelledDate = Now
                    DB.ContractOriginal.Update(CurrentContract)
                End If
            Next

            PopulateDatagrid()

        End If
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            If GetParameter(0) Is Nothing Then

                Dim DateFrom As DateTime = "1900-01-01"
                If Me.cbxAllVisitsComplete.Checked = False Then
                    If Not Me.dtpFrom.Value = Nothing Then
                        DateFrom = Me.dtpFrom.Value
                    End If
                End If

                Contracts = DB.ContractManager.Contracts_GetAll(DateFrom)
                RunFilter()
                Me.grpContracts.Text = "(" & Contracts.Count & " records)" & " Double Click To View / Edit"
            Else
                Contracts = GetParameter(0)
                Me.grpFilter.Enabled = False
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        theCustomer = Nothing
        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, 0)
        Me.txtContractReference.Text = ""

        Me.cbxContractExpiryDate.Checked = True
        Me.dtpFrom.Value = Today
        Me.dtpTo.Value = Today.AddMonths(1)
        Me.dtpFrom.Enabled = True
        Me.dtpTo.Enabled = True
        Me.grpFilter.Enabled = True
        Me.cbxAllVisitsComplete.Checked = False
        Me.cbxCancelledDate.Checked = False
    End Sub

    Private Sub RunFilter()
        If Not Contracts Is Nothing Then

            Dim whereClause As String = "Deleted = 0 "

            If Not theCustomer Is Nothing Then
                whereClause += " AND CustomerID = " & theCustomer.CustomerID & ""
            End If

            If Not Me.txtContractReference.Text.Trim.Length = 0 Then
                whereClause += " AND ContractReference LIKE '" & Me.txtContractReference.Text.Trim & "%'"
            End If

            If Not Combo.GetSelectedItemValue(Me.cboType) = 0 Then
                whereClause += " AND ContractTypeID = " & Combo.GetSelectedItemValue(Me.cboType)
            End If

            If Not Combo.GetSelectedItemValue(Me.cboRegion) = 0 Then
                whereClause += " AND RegionID = " & Combo.GetSelectedItemValue(Me.cboRegion)
            End If

            If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 Then
                whereClause += " AND ContractStatusID = " & Combo.GetSelectedItemValue(Me.cboStatus) & ""
            End If

            If cbxDoNotRenew.Checked = False Then
                whereClause += " AND DoNotRenew = 0"
            End If

            If Combo.GetSelectedItemValue(Me.CboRenewal) = 0 Then

            ElseIf Combo.GetSelectedItemValue(Me.CboRenewal) = 3 Then

                whereClause += " AND Renewed = 'Renewed'"
            ElseIf Combo.GetSelectedItemValue(Me.CboRenewal) = 4 Then
                whereClause += " AND Renewed = 'Not Renewed'"
            End If

            If Not Combo.GetSelectedItemValue(Me.cboInvoiceFrequency) = 0 Then
                whereClause += " AND InvoiceFrequencyID = " & Combo.GetSelectedItemValue(Me.cboInvoiceFrequency) & ""
            End If

            If Me.cbxContractExpiryDate.Checked Then
                whereClause += " AND ContractEndDate >= '" & Format(Me.dtpFrom.Value, "dd/MM/yyyy 00:00:00") & "' AND ContractEndDate <= '" & Format(Me.dtpTo.Value, "dd/MM/yyyy 23:59:59") & "'"
            End If

            If Me.chxStartedBetween.Checked Then
                whereClause += " AND ContractStartDate >= '" & Format(Me.dtpFrom.Value, "dd/MM/yyyy 00:00:00") & "' AND ContractStartDate <= '" & Format(Me.dtpTo.Value, "dd/MM/yyyy 23:59:59") & "'"
            End If

            If Me.cbxCancelledDate.Checked Then
                whereClause += " AND CancelledDate >= '" & Format(Me.dtpFrom.Value, "dd/MM/yyyy 00:00:00") & "' AND CancelledDate <= '" & Format(Me.dtpTo.Value, "dd/MM/yyyy 23:59:59") & "'"
            End If

            If Me.cbxAllVisitsComplete.Checked Then
                whereClause += " AND VisitsNotUploaded= 0"
            End If

            Contracts.RowFilter = whereClause

        End If
    End Sub

    Public Sub Export()

        Dim exportData As New DataTable
        exportData.Columns.Add("Property")
        exportData.Columns.Add("SitePostcode")
        exportData.Columns.Add("ContractReference")
        exportData.Columns.Add("ContractType")
        exportData.Columns.Add("ContractStatus")
        exportData.Columns.Add("ContractStartDate", GetType(Date))
        exportData.Columns.Add("ContractEndDate", GetType(Date))
        exportData.Columns.Add("ContractPrice", GetType(Double))
        exportData.Columns.Add("VisitsNotUploaded")
        exportData.Columns.Add("Renewed")
        exportData.Columns.Add("Customer")
        exportData.Columns.Add("SiteEmail")
        exportData.Columns.Add("CancelledDate", GetType(Date))
        exportData.Columns.Add("CancelledReason")
        exportData.Columns.Add("InvoiceFrequencyID")
        exportData.Columns.Add("GasSupplyPipework")
        exportData.Columns.Add("PlumbingDrainage")
        exportData.Columns.Add("WindowLockPest")
        exportData.Columns.Add("NoOfAppliancesCovered")
        exportData.Columns.Add("NoOfPrimaryAppliancesCovered")
        exportData.Columns.Add("NoOfAdditionalAppliancesCovered")
        exportData.Columns.Add("InvoiceFrequency")
        exportData.Columns.Add("CustomerType")
        exportData.Columns.Add("NoMarketing")

        For Each dr As DataRowView In CType(dgContracts.DataSource, DataView)
            Dim newRw As DataRow = exportData.NewRow
            newRw("Customer") = dr("Customer")
            newRw("ContractReference") = dr("ContractReference")
            newRw("ContractType") = dr("ContractType")
            newRw("ContractStatus") = dr("ContractStatus")
            newRw("ContractStartDate") = dr("ContractStartDate")
            newRw("ContractEndDate") = dr("ContractEndDate")
            newRw("ContractPrice") = dr("ContractPrice")
            newRw("VisitsNotUploaded") = dr("VisitsNotUploaded")
            newRw("Renewed") = dr("Renewed")
            newRw("Property") = dr("Property")
            newRw("SitePostcode") = dr("SitePostcode")
            newRw("SiteEmail") = dr("SiteEmail")
            newRw("CancelledDate") = dr("CancelledDate")
            newRw("CancelledReason") = dr("CancelledReason")
            newRw("InvoiceFrequencyID") = dr("InvoiceFrequencyID")
            newRw("GasSupplyPipework") = dr("GasSupplyPipework")
            newRw("PlumbingDrainage") = dr("PlumbingDrainage")
            newRw("WindowLockPest") = dr("WindowLockPest")
            newRw("NoOfAppliancesCovered") = dr("NoOfAppliancesCovered")
            newRw("NoOfPrimaryAppliancesCovered") = dr("NoOfPrimaryAppliancesCovered")
            newRw("NoOfAdditionalAppliancesCovered") = dr("NoOfAdditionalAppliancesCovered")
            newRw("InvoiceFrequency") = dr("InvoiceFrequency")
            newRw("CustomerType") = dr("NoOfContracts")
            newRw("NoMarketing") = dr("SiteNoMarketing")
            exportData.Rows.Add(newRw)
        Next
        ExportHelper.Export(exportData, "Contracts List", Enums.ExportType.XLS)
    End Sub

    Public Sub MoveProgressOn(Optional ByVal toMaximum As Boolean = False)
        If toMaximum Then
            Me.pbStatus.Value = Me.pbStatus.Maximum
        Else
            Me.pbStatus.Value += 1
        End If
        Application.DoEvents()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Cursor.Current = Cursors.WaitCursor
        PopulateDatagrid()
        Cursor.Current = Cursors.Default
    End Sub

#End Region

End Class