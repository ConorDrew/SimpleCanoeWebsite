Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Customers
Imports FSM.Entity.Sys

Public Class FRMInvoiceManager : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents grpInvoices As System.Windows.Forms.GroupBox

    Friend WithEvents dgInvoices As System.Windows.Forms.DataGrid
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomers As System.Windows.Forms.Label
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnDeselectAll As System.Windows.Forms.Button
    Friend WithEvents btnPrintOneItemOneInvoice As System.Windows.Forms.Button
    Friend WithEvents btnPrintManyItemsOnOneInvoice As System.Windows.Forms.Button
    Friend WithEvents btnAddInvoiceAddress As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnBackToVisitManager As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ts1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ts2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RaiseProFormaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnChangeLine As Button
    Friend WithEvents lblDept As Label
    Friend WithEvents cboDept As ComboBox
    Friend WithEvents txtAccNo As TextBox
    Friend WithEvents lblAccNo As Label
    Friend WithEvents btnView As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.grpInvoices = New System.Windows.Forms.GroupBox()
        Me.btnChangeLine = New System.Windows.Forms.Button()
        Me.btnBackToVisitManager = New System.Windows.Forms.Button()
        Me.dgInvoices = New System.Windows.Forms.DataGrid()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnDeselectAll = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.txtAccNo = New System.Windows.Forms.TextBox()
        Me.lblAccNo = New System.Windows.Forms.Label()
        Me.lblDept = New System.Windows.Forms.Label()
        Me.cboDept = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboRegion = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.lblCustomers = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnPrintOneItemOneInvoice = New System.Windows.Forms.Button()
        Me.btnPrintManyItemsOnOneInvoice = New System.Windows.Forms.Button()
        Me.btnAddInvoiceAddress = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ts1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RaiseProFormaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpInvoices.SuspendLayout()
        CType(Me.dgInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInvoices
        '
        Me.grpInvoices.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInvoices.Controls.Add(Me.btnChangeLine)
        Me.grpInvoices.Controls.Add(Me.btnBackToVisitManager)
        Me.grpInvoices.Controls.Add(Me.dgInvoices)
        Me.grpInvoices.Controls.Add(Me.btnSelectAll)
        Me.grpInvoices.Controls.Add(Me.btnDeselectAll)
        Me.grpInvoices.Location = New System.Drawing.Point(8, 186)
        Me.grpInvoices.Name = "grpInvoices"
        Me.grpInvoices.Size = New System.Drawing.Size(1182, 324)
        Me.grpInvoices.TabIndex = 3
        Me.grpInvoices.TabStop = False
        Me.grpInvoices.Text = "Items Ready To Be Invoiced"
        '
        'btnChangeLine
        '
        Me.btnChangeLine.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeLine.Location = New System.Drawing.Point(848, 20)
        Me.btnChangeLine.Name = "btnChangeLine"
        Me.btnChangeLine.Size = New System.Drawing.Size(160, 23)
        Me.btnChangeLine.TabIndex = 22
        Me.btnChangeLine.Text = "Change Line"
        '
        'btnBackToVisitManager
        '
        Me.btnBackToVisitManager.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBackToVisitManager.Location = New System.Drawing.Point(1014, 20)
        Me.btnBackToVisitManager.Name = "btnBackToVisitManager"
        Me.btnBackToVisitManager.Size = New System.Drawing.Size(160, 23)
        Me.btnBackToVisitManager.TabIndex = 21
        Me.btnBackToVisitManager.Text = "Back To Visit Manager"
        '
        'dgInvoices
        '
        Me.dgInvoices.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInvoices.DataMember = ""
        Me.dgInvoices.HeaderForeColor = SystemColors.ControlText
        Me.dgInvoices.Location = New System.Drawing.Point(8, 49)
        Me.dgInvoices.Name = "dgInvoices"
        Me.dgInvoices.Size = New System.Drawing.Size(1166, 267)
        Me.dgInvoices.TabIndex = 14
        '
        'btnSelectAll
        '
        Me.btnSelectAll.AccessibleDescription = "Export Job List To Excel"
        Me.btnSelectAll.Location = New System.Drawing.Point(7, 20)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(88, 23)
        Me.btnSelectAll.TabIndex = 19
        Me.btnSelectAll.Text = "Select All"
        '
        'btnDeselectAll
        '
        Me.btnDeselectAll.Location = New System.Drawing.Point(103, 20)
        Me.btnDeselectAll.Name = "btnDeselectAll"
        Me.btnDeselectAll.Size = New System.Drawing.Size(88, 23)
        Me.btnDeselectAll.TabIndex = 20
        Me.btnDeselectAll.Text = "Deselect All"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.txtAccNo)
        Me.grpFilter.Controls.Add(Me.lblAccNo)
        Me.grpFilter.Controls.Add(Me.lblDept)
        Me.grpFilter.Controls.Add(Me.cboDept)
        Me.grpFilter.Controls.Add(Me.Label13)
        Me.grpFilter.Controls.Add(Me.cboRegion)
        Me.grpFilter.Controls.Add(Me.btnSearch)
        Me.grpFilter.Controls.Add(Me.btnFindCustomer)
        Me.grpFilter.Controls.Add(Me.txtCustomer)
        Me.grpFilter.Controls.Add(Me.lblCustomers)
        Me.grpFilter.Controls.Add(Me.txtPostcode)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.btnFindSite)
        Me.grpFilter.Controls.Add(Me.txtSite)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.txtJobNumber)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.Label10)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(1182, 155)
        Me.grpFilter.TabIndex = 4
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'txtAccNo
        '
        Me.txtAccNo.Location = New System.Drawing.Point(742, 123)
        Me.txtAccNo.Name = "txtAccNo"
        Me.txtAccNo.Size = New System.Drawing.Size(160, 21)
        Me.txtAccNo.TabIndex = 41
        '
        'lblAccNo
        '
        Me.lblAccNo.Location = New System.Drawing.Point(606, 126)
        Me.lblAccNo.Name = "lblAccNo"
        Me.lblAccNo.Size = New System.Drawing.Size(84, 16)
        Me.lblAccNo.TabIndex = 40
        Me.lblAccNo.Text = "Acc No"
        '
        'lblDept
        '
        Me.lblDept.Location = New System.Drawing.Point(328, 123)
        Me.lblDept.Name = "lblDept"
        Me.lblDept.Size = New System.Drawing.Size(84, 16)
        Me.lblDept.TabIndex = 38
        Me.lblDept.Text = "Cost Centre"
        '
        'cboDept
        '
        Me.cboDept.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboDept.Location = New System.Drawing.Point(418, 123)
        Me.cboDept.Name = "cboDept"
        Me.cboDept.Size = New System.Drawing.Size(160, 21)
        Me.cboDept.TabIndex = 39
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 123)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Region"
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboRegion.Location = New System.Drawing.Point(160, 120)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(160, 21)
        Me.cboRegion.TabIndex = 36
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleDescription = "Export Job List To Excel"
        Me.btnSearch.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(1014, 123)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 23)
        Me.btnSearch.TabIndex = 28
        Me.btnSearch.Text = "Run Filter"
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(1142, 48)
        Me.btnFindCustomer.Name = "btnFindCustomer"
        Me.btnFindCustomer.Size = New System.Drawing.Size(32, 23)
        Me.btnFindCustomer.TabIndex = 2
        Me.btnFindCustomer.Text = "..."
        Me.btnFindCustomer.UseVisualStyleBackColor = False
        '
        'txtCustomer
        '
        Me.txtCustomer.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(160, 48)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(974, 21)
        Me.txtCustomer.TabIndex = 1
        '
        'lblCustomers
        '
        Me.lblCustomers.Location = New System.Drawing.Point(8, 48)
        Me.lblCustomers.Name = "lblCustomers"
        Me.lblCustomers.Size = New System.Drawing.Size(72, 21)
        Me.lblCustomers.TabIndex = 27
        Me.lblCustomers.Text = "Customers"
        '
        'txtPostcode
        '
        Me.txtPostcode.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostcode.Location = New System.Drawing.Point(160, 96)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(160, 21)
        Me.txtPostcode.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Postcode"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(1142, 72)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSite.TabIndex = 4
        Me.btnFindSite.Text = "..."
        Me.btnFindSite.UseVisualStyleBackColor = False
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(160, 72)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(974, 21)
        Me.txtSite.TabIndex = 3
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(376, 24)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(160, 21)
        Me.dtpTo.TabIndex = 13
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(160, 24)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(160, 21)
        Me.dtpFrom.TabIndex = 12
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobNumber.Location = New System.Drawing.Point(742, 96)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(392, 21)
        Me.txtJobNumber.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(336, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "and"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "To Raise Date Between : "
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(606, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Job/Order/Contract No"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Property"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(328, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(418, 96)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(160, 21)
        Me.cboType.TabIndex = 7
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 518)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 17
        Me.btnExport.Text = "Export"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 518)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 18
        Me.btnReset.Text = "Reset"
        '
        'btnPrintOneItemOneInvoice
        '
        Me.btnPrintOneItemOneInvoice.AccessibleDescription = "Export Job List To Excel"
        Me.btnPrintOneItemOneInvoice.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintOneItemOneInvoice.Location = New System.Drawing.Point(136, 518)
        Me.btnPrintOneItemOneInvoice.Name = "btnPrintOneItemOneInvoice"
        Me.btnPrintOneItemOneInvoice.Size = New System.Drawing.Size(216, 23)
        Me.btnPrintOneItemOneInvoice.TabIndex = 21
        Me.btnPrintOneItemOneInvoice.Text = "Print One Item One Invoice"
        '
        'btnPrintManyItemsOnOneInvoice
        '
        Me.btnPrintManyItemsOnOneInvoice.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintManyItemsOnOneInvoice.Location = New System.Drawing.Point(360, 518)
        Me.btnPrintManyItemsOnOneInvoice.Name = "btnPrintManyItemsOnOneInvoice"
        Me.btnPrintManyItemsOnOneInvoice.Size = New System.Drawing.Size(216, 23)
        Me.btnPrintManyItemsOnOneInvoice.TabIndex = 22
        Me.btnPrintManyItemsOnOneInvoice.Text = "Print Many Items on One Invoice"
        '
        'btnAddInvoiceAddress
        '
        Me.btnAddInvoiceAddress.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddInvoiceAddress.Location = New System.Drawing.Point(584, 518)
        Me.btnAddInvoiceAddress.Name = "btnAddInvoiceAddress"
        Me.btnAddInvoiceAddress.Size = New System.Drawing.Size(160, 23)
        Me.btnAddInvoiceAddress.TabIndex = 23
        Me.btnAddInvoiceAddress.Text = "Add Invoice Address"
        '
        'btnView
        '
        Me.btnView.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.Location = New System.Drawing.Point(1060, 518)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(130, 23)
        Me.btnView.TabIndex = 24
        Me.btnView.Text = "View"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Button1.Location = New System.Drawing.Point(750, 518)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Raise Alternative Doc"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts1, Me.ts2, Me.RaiseProFormaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(173, 70)
        '
        'ts1
        '
        Me.ts1.Name = "ts1"
        Me.ts1.Size = New System.Drawing.Size(172, 22)
        Me.ts1.Text = "Missed DD Invoice"
        '
        'ts2
        '
        Me.ts2.Name = "ts2"
        Me.ts2.Size = New System.Drawing.Size(172, 22)
        Me.ts2.Text = "Missed DD Receipt"
        '
        'RaiseProFormaToolStripMenuItem
        '
        Me.RaiseProFormaToolStripMenuItem.Name = "RaiseProFormaToolStripMenuItem"
        Me.RaiseProFormaToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.RaiseProFormaToolStripMenuItem.Text = "Raise Pro-Forma"
        '
        'FRMInvoiceManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1198, 548)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnAddInvoiceAddress)
        Me.Controls.Add(Me.btnPrintOneItemOneInvoice)
        Me.Controls.Add(Me.btnPrintManyItemsOnOneInvoice)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.grpInvoices)
        Me.Name = "FRMInvoiceManager"
        Me.Text = "Ready To Be Invoice Manager"
        Me.WindowState = FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpInvoices, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.btnPrintManyItemsOnOneInvoice, 0)
        Me.Controls.SetChildIndex(Me.btnPrintOneItemOneInvoice, 0)
        Me.Controls.SetChildIndex(Me.btnAddInvoiceAddress, 0)
        Me.Controls.SetChildIndex(Me.btnView, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.grpInvoices.ResumeLayout(False)
        CType(Me.dgInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupInvoiceDataGrid()
        ResetFilters()

        Try
            If Not GetParameter(2) Is Nothing AndAlso GetParameter(2).GetType().Equals(GetType(System.Data.DataTable)) Then

                dtVisitFilters = GetParameter(2)

            End If

            If Not GetParameter(0) Is Nothing Then

                If GetParameter(0).Table.rows.count > 0 Then
                    Me.dtpFrom.Value = GetParameter(0).Table.Select("RaiseDate = MIN(RaiseDate)")(0).Item("RaiseDate")
                    Me.dtpTo.Value = GetParameter(0).Table.Select("RaiseDate = MAX(RaiseDate)")(0).Item("RaiseDate")
                End If

                InvoicesDataview = GetParameter(0)

                CType(Me, IBaseForm).SetFormParameters = Nothing
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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

    Private _dvInvoices As DataView

    Private Property InvoicesDataview() As DataView
        Get
            Return _dvInvoices
        End Get
        Set(ByVal value As DataView)
            _dvInvoices = value
            _dvInvoices.AllowNew = False
            _dvInvoices.AllowEdit = False
            _dvInvoices.AllowDelete = False
            _dvInvoices.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
            Me.dgInvoices.DataSource = InvoicesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedInvoiceDataRow() As DataRow
        Get
            If Not Me.dgInvoices.CurrentRowIndex = -1 Then
                Return InvoicesDataview(Me.dgInvoices.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _customers As New List(Of Entity.Customers.Customer)

    Public Property Customers() As List(Of Entity.Customers.Customer)
        Get
            Return _customers
        End Get
        Set(ByVal value As List(Of Entity.Customers.Customer))
            _customers = value
            theSite = Nothing
            If _customers.Count > 0 Then
                Dim custText As String = String.Empty
                Dim addComma As Boolean = False
                For Each cust As Entity.Customers.Customer In _customers
                    If addComma Then custText += ", "
                    custText += cust.Name & " (A/C No : " & cust.AccountNumber & ")"
                    addComma = True
                Next
                Me.txtCustomer.Text = custText
            Else
                Me.txtCustomer.Text = ""
            End If
        End Set
    End Property

    Private _oSite As Entity.Sites.Site

    Public Property theSite() As Entity.Sites.Site
        Get
            Return _oSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _oSite = Value
            If Not _oSite Is Nothing Then
                Me.txtSite.Text = theSite.Address1 & ", " & theSite.Address2 & ", " & theSite.Postcode
            Else
                Me.txtSite.Text = ""
            End If
        End Set
    End Property

    Private _invoicesToPrint As New ArrayList

    Private Property InvoicesToPrint() As ArrayList
        Get
            Return _invoicesToPrint
        End Get
        Set(ByVal Value As ArrayList)
            _invoicesToPrint = Value
        End Set
    End Property

    Private _IsLoading As Boolean = True

    Private Property IsLoading() As Boolean
        Get
            Return _IsLoading
        End Get
        Set(ByVal Value As Boolean)
            _IsLoading = Value
        End Set
    End Property

    Public DDpaidBy As String = ""

#End Region

#Region "Setup"

    Private Sub SetupInvoiceDataGrid()
        Helper.SetUpDataGrid(dgInvoices)
        Dim tbStyle As DataGridTableStyle = Me.dgInvoices.TableStyles(0)

        tbStyle.GridColumnStyles.Clear()
        '  tbStyle.AllowSorting = False

        Dim Tick As New DataGridBoolColumn
        Tick.HeaderText = ""
        Tick.MappingName = "Tick"
        Tick.ReadOnly = True
        Tick.Width = 25
        Tick.NullText = ""
        tbStyle.GridColumnStyles.Add(Tick)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 100
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 100
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim InvoiceType As New DataGridLabelColumn
        InvoiceType.Format = ""
        InvoiceType.FormatInfo = Nothing
        InvoiceType.HeaderText = "Inv. Type"
        InvoiceType.MappingName = "InvoiceType"
        InvoiceType.ReadOnly = True
        InvoiceType.Width = 70
        InvoiceType.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceType)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job/Order/Contract No."
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 140
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim RaiseDate As New DataGridLabelColumn
        RaiseDate.Format = "dd/MMM/yyyy"
        RaiseDate.FormatInfo = Nothing
        RaiseDate.HeaderText = "Raise Date"
        RaiseDate.MappingName = "RaiseDate"
        RaiseDate.ReadOnly = True
        RaiseDate.Width = 85
        RaiseDate.NullText = ""
        tbStyle.GridColumnStyles.Add(RaiseDate)

        Dim InvoiceAddressType As New DataGridLabelColumn
        InvoiceAddressType.Format = ""
        InvoiceAddressType.FormatInfo = Nothing
        InvoiceAddressType.HeaderText = "Inv. Addr. Type"
        InvoiceAddressType.MappingName = "InvoiceAddressType"
        InvoiceAddressType.ReadOnly = True
        InvoiceAddressType.Width = 100
        InvoiceAddressType.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceAddressType)

        Dim InvoiceAddress As New DataGridLabelColumn
        InvoiceAddress.Format = ""
        InvoiceAddress.FormatInfo = Nothing
        InvoiceAddress.HeaderText = "Invoice Address"
        InvoiceAddress.MappingName = "InvoiceAddress"
        InvoiceAddress.ReadOnly = True
        InvoiceAddress.Width = 100
        InvoiceAddress.NullText = ""
        tbStyle.GridColumnStyles.Add(InvoiceAddress)

        Dim dept As New DataGridLabelColumn
        dept.Format = ""
        dept.FormatInfo = Nothing
        dept.HeaderText = "Department"
        dept.MappingName = "Department"
        dept.ReadOnly = True
        dept.Width = 100
        dept.NullText = ""
        tbStyle.GridColumnStyles.Add(dept)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = "C"
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 75
        Amount.NullText = ""
        tbStyle.GridColumnStyles.Add(Amount)

        Dim vatCode As New DataGridLabelColumn
        vatCode.Format = ""
        vatCode.FormatInfo = Nothing
        vatCode.HeaderText = "VAT Code"
        vatCode.MappingName = "VatCode"
        vatCode.ReadOnly = True
        vatCode.Width = 75
        vatCode.NullText = ""
        tbStyle.GridColumnStyles.Add(vatCode)

        Dim VAT As New DataGridLabelColumn
        VAT.Format = ""
        VAT.FormatInfo = Nothing
        VAT.HeaderText = "VAT %"
        VAT.MappingName = "VAT"
        VAT.ReadOnly = True
        VAT.Width = 75
        VAT.NullText = ""
        tbStyle.GridColumnStyles.Add(VAT)

        tbStyle.ReadOnly = True

        'dgInvoices.ReadOnly = False
        tbStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString
        Me.dgInvoices.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub dgInvoices_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgInvoices.DoubleClick
        view()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        view()
    End Sub

    Private Sub FRMInvoiceManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IsLoading = True
        LoadMe(sender, e)
        IsLoading = False
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim frmFindCust As New FRMFindCustomers
        frmFindCust.ShowDialog()

        Customers = New List(Of Customer)
        Dim dvCustomers As DataView = frmFindCust.CustomerDataView
        Dim drCustomers() As DataRow =
                (From row In dvCustomers.Table.AsEnumerable()
                 Where row.Field(Of Boolean)("Include") = True
                 Select row).ToArray()

        Dim cIds As List(Of Integer) = (From dr In drCustomers Select (Helper.MakeIntegerValid(dr("CustomerID")))).ToList()

        For Each cId As Integer In cIds
            Customers.Add(DB.Customer.Customer_Get(cId))
        Next
        Customers = Customers
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        Dim ID As Integer
        If Customers.Count > 0 Then
            ID = FindRecordMultiId(Enums.TableNames.tblSite, Customers.Select(Function(x) x.CustomerID).Distinct().ToList())
        Else
            ID = FindRecord(Enums.TableNames.tblSite)
        End If
        If Not ID = 0 Then
            theSite = DB.Sites.Get(ID)
            '   RunFilter()
        End If
    End Sub

    Private Sub dgInvoices_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgInvoices.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgInvoices.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            If HitTestInfo.Column = 0 Then
                Dim selected As Boolean = Not Helper.MakeBooleanValid(SelectedInvoiceDataRow.Item("tick"))
                SelectedInvoiceDataRow.Item("Tick") = selected
            End If
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        For Each dr As DataRow In InvoicesDataview.Table.Select(InvoicesDataview.RowFilter)
            dr("tick") = 1
        Next
    End Sub

    Private Sub btnDeselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselectAll.Click
        For Each dr As DataRow In InvoicesDataview.Table.Rows
            dr("tick") = 0
        Next
    End Sub

    Private Sub btnPrintOneItemOneInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintOneItemOneInvoice.Click
        Try
            Dim zeroInvoices As Boolean = False

            If ValidateInvoiceAddress() Then
                FindPartPayJobs(False)

                For Each i As DataRow In InvoicesDataview.Table.Rows
                    If Helper.MakeBooleanValid(i("tick")) = True And i("PaymentTermID") <> 69817 Then
                        If Helper.MakeDoubleValid(i("Amount")) > 0 Then

                            'CHECK THAT ANOTHER USERS HASN'T GENERATED SINCE WE LAST REFRESHED OUR SCREEN

                            If DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(i("InvoiceToBeRaisedID")).Count = 0 Then

                                Dim inv As New Entity.Invoiceds.Invoiced
                                'AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                                Dim invNum As New JobNumber
                                invNum = DB.Job.GetNextJobNumber(5)
                                inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                                inv.SetRaisedByUserID = loggedInUser.UserID
                                inv.RaisedDate = i("RaiseDate")

                                If i("TAXRateID") > 0 Then
                                    inv.SetVATRateID = i("TAXRateID")
                                Else
                                    inv.SetVATRateID = DB.VATRatesSQL.VATRates_Get_ByDate(Now)
                                End If

                                inv.SetPaymentTermID = i("PaymentTermID")
                                inv.SetPaidByID = i("PaidByID")
                                inv = DB.Invoiced.Insert(inv)

                                Dim invLines As New Entity.InvoicedLiness.InvoicedLines
                                invLines.SetAmount = (i("Amount"))
                                invLines.SetInvoicedID = inv.InvoicedID
                                invLines.SetInvoiceToBeRaisedID = i("InvoiceToBeRaisedID")
                                invLines = DB.InvoicedLines.Insert(invLines)

                                Dim PrintArray As New ArrayList
                                PrintArray.Add(inv.InvoicedID)
                                PrintArray.Add(i("RegionID"))
                                InvoicesToPrint.Add(PrintArray)

                            End If
                        Else
                            zeroInvoices = True
                        End If
                    End If
                Next

                If zeroInvoices Then
                    ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Print()

                PopulateDatagrid()

            End If
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnPrintManyItemsOnOneInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintManyItemsOnOneInvoice.Click
        Try
            Dim zeroInvoices As Boolean = False

            If ValidateInvoiceAddress() Then
                FindPartPayJobs(True)

                Dim dtDone As New DataTable
                dtDone.Columns.Add("AddressTypeID")
                dtDone.Columns.Add("AddressID")
                Dim lastVat As Integer = -1

                For Each i As DataRow In InvoicesDataview.Table.Select("tick = 1")
                    If lastVat > -1 AndAlso lastVat <> i("TAXRateID") Then
                        MsgBox("Different VAT rates cannot be batched", MsgBoxStyle.OkOnly, "Ooops")
                        Exit Sub
                    End If
                    lastVat = i("TAXRateID")
                Next

                Dim raiseDate As DateTime = Now
                Dim f As New FRMChangeRaiseDate
                f.dtpTaxDate.Value = raiseDate.Date
                f.ShowDialog()
                If f.DialogResult = DialogResult.OK Then
                    raiseDate = f.dtpTaxDate.Value
                Else
                    Exit Sub
                End If

                For Each i As DataRow In InvoicesDataview.Table.Rows
                    If Helper.MakeBooleanValid(i("tick")) = True And i("PAYMENTTERMID") <> 69817 Then ' i("PAIDBYID") <> 69792
                        If Helper.MakeDoubleValid(i("Amount")) > 0 Then
                            If DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(i("InvoiceToBeRaisedID")).Count = 0 Then

                                If dtDone.Select("AddressTypeID=" & i("AddressTypeID") & " AND AddressID=" & i("AddressID")).Length = 0 Then
                                    Dim drInv() As DataRow = InvoicesDataview.Table.Select("AddressTypeID=" & i("AddressTypeID") & " AND AddressID=" & i("AddressID") & " AND Tick = 1")
                                    Dim inv As New Entity.Invoiceds.Invoiced
                                    Dim invNum As New JobNumber
                                    invNum = DB.Job.GetNextJobNumber(5)
                                    inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                                    inv.SetRaisedByUserID = loggedInUser.UserID
                                    inv.RaisedDate = raiseDate

                                    inv.SetVATRateID = (lastVat)
                                    inv = DB.Invoiced.Insert(inv)

                                    For j As Integer = 0 To drInv.Length - 1
                                        Dim invLines As New Entity.InvoicedLiness.InvoicedLines
                                        invLines.SetAmount = Helper.MakeDoubleValid(drInv(j).Item("Amount"))
                                        invLines.SetInvoicedID = inv.InvoicedID
                                        invLines.SetInvoiceToBeRaisedID = drInv(j).Item("InvoiceToBeRaisedID")

                                        invLines = DB.InvoicedLines.Insert(invLines)
                                    Next j

                                    Dim PrintArray As New ArrayList
                                    PrintArray.Add(inv.InvoicedID)
                                    PrintArray.Add(i("RegionID"))
                                    InvoicesToPrint.Add(PrintArray)

                                    Dim r As DataRow
                                    r = dtDone.NewRow
                                    r("AddressTypeID") = i("AddressTypeID")
                                    r("AddressID") = i("AddressID")
                                    dtDone.Rows.Add(r)
                                End If

                            End If
                        Else
                            zeroInvoices = True
                        End If
                    End If
                Next

                If zeroInvoices Then
                    ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                Print()

                PopulateDatagrid()
            End If
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnAddInvoiceAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddInvoiceAddress.Click
        If Not SelectedInvoiceDataRow Is Nothing Then
            If Helper.MakeIntegerValid(SelectedInvoiceDataRow("AddressLinkID")) = 0 Then
                ShowForm(GetType(FRMAddInvoiceAddress), True, New Object() {SelectedInvoiceDataRow("LinkID"), SelectedInvoiceDataRow("InvoiceToBeRaisedID"), Me})
            Else
                MessageBox.Show("This line has an Invoice Address", "Invoice Address", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        PopulateDatagrid()
    End Sub

    Private Sub btnBackToVisitManager_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackToVisitManager.Click
        Navigation.Navigate(Enums.MenuTypes.Jobs)
        ShowForm(GetType(FRMVisitManager), False, New Object() {Nothing, dtVisitFilters, "From Invoice Manager"})
        ' {"FromInvoice"}
    End Sub

#End Region

#Region "Functions"

    Private Sub view()
        If Not SelectedInvoiceDataRow Is Nothing Then

            Select Case Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("InvoiceTypeID"))
                Case Enums.InvoiceType.Contract_Option1
                    ShowForm(GetType(FRMContractOriginal), True, New Object() {
                             Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("ContractID")),
                             Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("CustomerID")),
                             Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("InvoiceToBeRaisedID"))})
                Case Enums.InvoiceType.Order
                    Select Case CInt(SelectedInvoiceDataRow.Item("OrderTypeID"))
                        Case Enums.OrderType.Customer
                            ShowForm(GetType(FRMOrder), False, New Object() {SelectedInvoiceDataRow.Item("OrderID"), Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("OrderSiteID")), 0, Me})
                        Case Enums.OrderType.StockProfile
                            ShowForm(GetType(FRMOrder), False, New Object() {SelectedInvoiceDataRow.Item("OrderID"), SelectedInvoiceDataRow.Item("VanID"), 0, Me})
                        Case Enums.OrderType.Warehouse
                            ShowForm(GetType(FRMOrder), False, New Object() {SelectedInvoiceDataRow.Item("OrderID"), SelectedInvoiceDataRow.Item("WarehouseID"), 0, Me})
                        Case Enums.OrderType.Job
                            ShowForm(GetType(FRMOrder), False, New Object() {SelectedInvoiceDataRow.Item("OrderID"), SelectedInvoiceDataRow.Item("EngineerVisitID"), 0, Me})
                    End Select
                Case Enums.InvoiceType.Visit
                    ShowForm(GetType(FRMEngineerVisit), True, New Object() {Helper.MakeIntegerValid(SelectedInvoiceDataRow.Item("EngineerVisitID"))})
            End Select
            PopulateDatagrid()
        Else
            ShowMessage("Please select an invoice.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub PopulateDatagrid()
        Cursor.Current = Cursors.WaitCursor
        InvoicesDataview = DB.InvoiceToBeRaised.Invoices_GetAll_Manager(dtpFrom.Value, dtpTo.Value)
        RunFilter()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ResetFilters()

        Customers = New List(Of Entity.Customers.Customer)

        Dim fromDate As DateTime

        Select Case Today.DayOfWeek
            Case DayOfWeek.Monday
                fromDate = Now
            Case DayOfWeek.Tuesday
                fromDate = Now.AddDays(-1)
            Case DayOfWeek.Wednesday
                fromDate = Now.AddDays(-2)
            Case DayOfWeek.Thursday
                fromDate = Now.AddDays(-3)
            Case DayOfWeek.Friday
                fromDate = Now.AddDays(-4)
            Case DayOfWeek.Saturday
                fromDate = Now.AddDays(-5)
            Case DayOfWeek.Sunday
                fromDate = Now.AddDays(-6)
        End Select

        Me.dtpFrom.Value = fromDate
        Me.dtpTo.Value = fromDate.AddDays(7)

        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTypes).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter)
        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Combo.SetUpCombo(Me.cboRegion, DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter)
        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDept, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select

        Me.txtJobNumber.Text = ""
        Me.txtPostcode.Text = ""
    End Sub

    Private Sub RunFilter()
        If InvoicesDataview Is Nothing Then
            Exit Sub
        End If

        Dim whereClause As String = "1 = 1 "

        If Customers.Count > 0 Then
            whereClause += " AND CustomerID IN (" & String.Join(", ", Customers.Select(Function(x) x.CustomerID).Distinct()) & ")"
        End If

        If Not theSite Is Nothing Then
            whereClause += " AND SiteID = " & theSite.SiteID & ""
        End If

        If Not Me.txtPostcode.Text.Trim.Length = 0 Then
            whereClause += " AND Postcode LIKE '" & Me.txtPostcode.Text.Trim & "%'"
        End If

        If Not Combo.GetSelectedItemValue(Me.cboType) = 0 Then
            whereClause += " AND InvoiceTypeID = " & Combo.GetSelectedItemValue(Me.cboType) & ""
        End If

        If Not Combo.GetSelectedItemValue(Me.cboRegion) = 0 Then
            whereClause += " AND RegionID = " & Combo.GetSelectedItemValue(Me.cboRegion) & ""
        End If

        Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(Me.cboDept))
        If Helper.IsValidInteger(department) AndAlso Not Helper.MakeIntegerValid(department) <= 0 Then
            whereClause += " AND Department = '" & department & "'"
        ElseIf Not IsNumeric(department) Then
            whereClause += " AND Department = '" & department & "'"
        End If

        If Not Me.txtJobNumber.Text.Trim.Length = 0 Then
            whereClause += " AND JobNumber LIKE '" & Me.txtJobNumber.Text.Trim & "%'"
        End If

        If Not Me.txtAccNo.Text.Trim.Length = 0 Then
            whereClause += " AND AccountNumber LIKE '" & Me.txtAccNo.Text.Trim & "%'"
        End If

        InvoicesDataview.RowFilter = whereClause
    End Sub

    Public Sub Export()
        Cursor.Current = Cursors.WaitCursor
        Dim exportData As New DataTable

        exportData.Columns.Add("Customer")
        exportData.Columns.Add("Site")
        exportData.Columns.Add("InvoiceType")
        exportData.Columns.Add("JobNumber")
        exportData.Columns.Add("RaiseDate")
        exportData.Columns.Add("InvoiceAddressType")
        exportData.Columns.Add("InvoiceAddress")
        exportData.Columns.Add("SorDescription")
        exportData.Columns.Add("DDMSRef")
        exportData.Columns.Add("CostCentre")
        exportData.Columns.Add("VatCode")
        exportData.Columns.Add("Amount", GetType(Double))

        For Each dr As DataRowView In CType(dgInvoices.DataSource, DataView)
            Dim newRw As DataRow = exportData.NewRow
            newRw("Customer") = dr("Customer")
            newRw("Site") = dr("Site")
            newRw("InvoiceType") = dr("InvoiceType")
            newRw("JobNumber") = dr("JobNumber")
            newRw("RaiseDate") = Format(dr("RaiseDate"), "dd/MM/yyyy")
            newRw("InvoiceAddressType") = dr("InvoiceAddressType")
            newRw("InvoiceAddress") = dr("InvoiceAddress")
            newRw("CostCentre") = dr("Department")
            newRw("VatCode") = dr("VatCode")
            newRw("DDMSRef") = dr("DDMSRef")

            Dim engineerVisitId As Integer = Helper.MakeIntegerValid(dr("EngineerVisitID"))
            If engineerVisitId > 0 Then
                Dim dvChargeBreakdown As DataView = DB.EngineerVisitCharge.EngineerVisitCharge_Get_ChargedBreakDown(engineerVisitId)
                Dim sorDescription As String =
                    String.Join(" / ", dvChargeBreakdown.Table.AsEnumerable().Where(Function(row) row.Field(Of String)("Type") = "SOR").
                    Select(Function(row) row.Field(Of String)("Description")).ToArray())

                newRw("SorDescription") = sorDescription
            Else
                newRw("SorDescription") = String.Empty
            End If

            newRw("Amount") = dr("Amount")
            exportData.Rows.Add(newRw)
        Next
        ExportHelper.Export(exportData, "Invoice List", Enums.ExportType.XLS)
        Cursor.Current = Cursors.Default
    End Sub

    Public Function ValidateInvoiceAddress() As Boolean
        Dim s As String = "The following lines are missing invoice addresses: " & vbCrLf
        Dim valid As Boolean = True

        For Each i As DataRow In InvoicesDataview.Table.Rows
            If Helper.MakeBooleanValid(i("tick")) = True Then
                If i.Item("AddressLinkID") = 0 Then
                    s += "* " & i.Item("JobNumber") & vbCrLf
                    valid = False
                End If
            End If
        Next

        If valid = False Then
            MessageBox.Show(s, "Invoice Addresses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        Return valid

    End Function

    Public Sub Print()
        Dim details As New ArrayList
        details.Add(InvoicesToPrint)
        Dim oPrint As New Entity.Sys.Printing(details, "Invoice", Enums.SystemDocumentType.Invoice, True)
        InvoicesToPrint.Clear()
    End Sub

    Public Sub FindPartPayJobs(ByVal Multi As Boolean)
        Try
            'FOR EVERY TICKED RECORD
            For Each dr As DataRow In InvoicesDataview.Table.Rows
                If Helper.MakeBooleanValid(dr("tick")) = True Then
                    'VISIT RECORDS
                    If CType(dr("InvoiceTypeID"), Entity.Sys.Enums.InvoiceType) = Entity.Sys.Enums.InvoiceType.Visit Then
                        'SEE IF JOB IS PART PAY
                        If DB.Job.Job_Get(dr("JobID")).ToBePartPaid = True Then
                            'UNTICK - We'll add to print list from here

                            dr("tick") = 0
                            'IS IT INVOICED?
                            If Helper.MakeIntegerValid(dr("invoicedID")) = 0 Then 'Invoiced =NO

                                'IS THERE AN Invoice for any other visits on this job?
                                Dim dt As DataTable = DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(dr("JobID")).Table
                                If dt.Rows.Count > 0 Then 'Exisiting Invoice =YES

                                    'Add to Exisiting Invoice
                                    InsertInvoiceLines(Helper.MakeDoubleValid(dr.Item("Amount")),
                                    dt.Rows(0).Item("InvoicedID"), dr.Item("InvoiceToBeRaisedID"))

                                    'Add Invoice to print list

                                    Dim exists As Boolean = False
                                    For Each al As ArrayList In InvoicesToPrint
                                        If al(0) = dt.Rows(0).Item("InvoicedID") Then ' check if the invoice id is already in....
                                            exists = True
                                        End If
                                    Next

                                    If exists = False Then ' if not add it.
                                        Dim PrintArray As New ArrayList
                                        PrintArray.Add(dt.Rows(0).Item("InvoicedID"))
                                        PrintArray.Add(dr("RegionID"))
                                        InvoicesToPrint.Add(PrintArray)
                                    End If
                                Else 'Exisiting Invoice =NO
                                    'CREATE NEW INVOICE
                                    Dim inv As New Entity.Invoiceds.Invoiced
                                    Dim invNum As New JobNumber
                                    invNum = DB.Job.GetNextJobNumber(5)
                                    inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                                    inv.SetRaisedByUserID = loggedInUser.UserID
                                    inv.RaisedDate = Now
                                    inv = DB.Invoiced.Insert(inv)
                                    'ADD ALL THE VISITS READY FOR INVOICE
                                    Dim dtVisits As DataTable = DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(dr("JobID")).Table
                                    For Each v As DataRow In dtVisits.Rows
                                        InsertInvoiceLines(Helper.MakeDoubleValid(v.Item("Amount")),
                                        inv.InvoicedID, v.Item("InvoiceToBeRaisedID"))
                                    Next v

                                    'IF its multi line invoice add on anyother things
                                    If Multi Then
                                        MultiInvoicePPJob(dr, inv, dtVisits)
                                    End If

                                    'Add Invoice to print list
                                    Dim exists As Boolean = False
                                    For Each al As ArrayList In InvoicesToPrint
                                        If al(0) = inv.InvoicedID Then ' check if the invoice id is already in....
                                            exists = True
                                        End If
                                    Next

                                    If exists = False Then ' if not add it.
                                        Dim PrintArray As New ArrayList
                                        PrintArray.Add(inv.InvoicedID)
                                        PrintArray.Add(dr("RegionID"))
                                        InvoicesToPrint.Add(PrintArray)
                                    End If
                                End If
                            Else 'Invoiced = YES
                                'ARE THERE ANY OTHER VISITS THAT SHOUlD BE ONE THIS INVOICE THAT AREN'T?
                                'ADD THEM
                                For Each v As DataRow In DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(dr("JobID"))
                                    If dr("InvoiceToBeRaisedID") <> v("InvoiceToBeRaisedID") Then
                                        InsertInvoiceLines(Helper.MakeDoubleValid(v.Item("Amount")),
                                        dr("invoicedID"), v.Item("InvoiceToBeRaisedID"))
                                    End If
                                Next

                                'Add Invoice to print list
                                Dim exists As Boolean = False
                                For Each al As ArrayList In InvoicesToPrint
                                    If al(0) = dr("InvoicedID") Then ' check if the invoice id is already in....
                                        exists = True
                                    End If
                                Next

                                If exists = False Then ' if not add it.
                                    Dim PrintArray As New ArrayList
                                    PrintArray.Add(dr("InvoicedID"))
                                    PrintArray.Add(dr("RegionID"))
                                    InvoicesToPrint.Add(PrintArray)
                                End If
                            End If

                        End If
                    End If
                End If

            Next
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub MultiInvoicePPJob(ByVal dr As DataRow, ByVal inv As Entity.Invoiceds.Invoiced, ByVal dtVisits As DataTable)
        Try
            'GET ALL ITEMS THAT YOU WANNA PUT ON THE INVOICE
            Dim drInv() As DataRow = InvoicesDataview.Table.Select("AddressTypeID=" & dr("AddressTypeID") & " AND AddressID=" & dr("AddressID"))
            For i As Integer = 0 To drInv.Length - 1

                'IS IT INVOICED ALREADY?
                '    If Entity.Sys.Helper.MakeIntegerValid(drInv(i).Item("invoicedID")) = 0 Then 'NO

                'IS IT A VISIT OR AN ORDER?
                If CType(drInv(i).Item("InvoiceTypeID"), Entity.Sys.Enums.InvoiceType) = Entity.Sys.Enums.InvoiceType.Order Then
                    'ORDER
                    'UNTICK
                    drInv(i).Item("tick") = 0
                    InsertInvoiceLines(Helper.MakeDoubleValid(drInv(i).Item("Amount")),
                       inv.InvoicedID, drInv(i).Item("InvoiceToBeRaisedID"))
                Else 'VISIT

                    'IS THE VISIT ALREADY INSERTED ABOVE?
                    If dtVisits.Select("InvoiceToBeRaisedID=" & drInv(i).Item("InvoiceToBeRaisedID")).Length > 0 Then
                        'YES UNTICK
                        drInv(i).Item("tick") = 0
                    Else
                        'NO - IS IT PP JOB ?
                        If DB.Job.Job_Get(drInv(i).Item("JobID")).ToBePartPaid = True Then 'YES
                            'IS THERE ANY EXISTING INVOICES FOR THE JOB'S VISIT
                            Dim jobAlreadyInvoiced As Boolean = False

                            Dim alreadyInv As DataTable = DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(drInv(i).Item("JobID")).Table
                            If alreadyInv.Rows.Count > 0 Then
                                'AND ITS A DIFFERENT INVOICE TO THIS ONE
                                For Each aInv As DataRow In alreadyInv.Rows
                                    If Helper.MakeIntegerValid(drInv(i).Item("InvoicedID")) = Helper.MakeIntegerValid(aInv("InvoicedID")) Then
                                        jobAlreadyInvoiced = True ' Just leave the this alone it will picked up later
                                    End If
                                Next aInv
                                If jobAlreadyInvoiced Then
                                    ' Just leave the this alone it will picked up later
                                Else
                                    'UNTICK AND INSERT
                                    drInv(i).Item("tick") = 0
                                    InsertInvoiceLines(Helper.MakeDoubleValid(drInv(i).Item("Amount")),
                                                inv.InvoicedID, drInv(i).Item("InvoiceToBeRaisedID"))
                                End If
                            Else 'NO INVOICE
                                'UNTICK AND INSERT
                                drInv(i).Item("tick") = 0
                                InsertInvoiceLines(Helper.MakeDoubleValid(drInv(i).Item("Amount")),
                                            inv.InvoicedID, drInv(i).Item("InvoiceToBeRaisedID"))
                            End If
                        Else 'NO
                            'UNTICK AND INSERT
                            drInv(i).Item("tick") = 0
                            InsertInvoiceLines(Helper.MakeDoubleValid(drInv(i).Item("Amount")),
                                                 inv.InvoicedID, drInv(i).Item("InvoiceToBeRaisedID"))
                        End If
                    End If
                End If
                'Else ' ALREADY INVOICED SO JUST UNTICK
                'drInv(i).Item("tick") = 0
                'End If
            Next i
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub InsertInvoiceLines(ByVal amount As Double, ByVal invoicedID As Integer, ByVal InvoiceToBeRaisedID As Integer)
        Dim invLines As New Entity.InvoicedLiness.InvoicedLines
        invLines.SetAmount = amount
        invLines.SetInvoicedID = invoicedID
        invLines.SetInvoiceToBeRaisedID = InvoiceToBeRaisedID
        invLines = DB.InvoicedLines.Insert(invLines)
    End Sub

#End Region

    Private Sub txtJobNumber_TextChanged(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtJobNumber.KeyDown, txtPostcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            PopulateDatagrid()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ContextMenuStrip1.Show(Button1, New Point(0, 0))
    End Sub

    Private Sub ts1_Click(sender As Object, e As EventArgs) Handles ts1.Click 'inv
        Try
            Dim zeroInvoices As Boolean = False

            If ValidateInvoiceAddress() Then
                FindPartPayJobs(False)

                For Each i As DataRow In InvoicesDataview.Table.Rows
                    If Helper.MakeBooleanValid(i("tick")) = True And i("PAYMENTTERMID") <> 69817 Then
                        If Helper.MakeDoubleValid(i("Amount")) > 0 Then

                            'CHECK THAT ANOTHER USERS HASN'T GENERATED SINCE WE LAST REFRESHED OUR SCREEN

                            If DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(i("InvoiceToBeRaisedID")).Count = 0 Then

                                Dim inv As New Entity.Invoiceds.Invoiced
                                'AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                                Dim invNum As New JobNumber
                                invNum = DB.Job.GetNextJobNumber(5)
                                inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                                inv.SetRaisedByUserID = loggedInUser.UserID
                                inv.RaisedDate = i("RaiseDate")

                                If i("TAXRateID") > 0 Then
                                    inv.SetVATRateID = i("TAXRateID")
                                Else
                                    inv.SetVATRateID = DB.VATRatesSQL.VATRates_Get_ByDate(Now)
                                End If

                                inv.SetPaymentTermID = i("PaymentTermID")
                                inv.SetPaidByID = i("PaidByID")
                                inv.SetAdhocInvoiceType = "DDINVOICE"
                                inv = DB.Invoiced.Insert(inv)

                                Dim invLines As New Entity.InvoicedLiness.InvoicedLines
                                invLines.SetAmount = (i("Amount"))
                                invLines.SetInvoicedID = inv.InvoicedID
                                invLines.SetInvoiceToBeRaisedID = i("InvoiceToBeRaisedID")
                                invLines = DB.InvoicedLines.Insert(invLines)

                                Dim PrintArray As New ArrayList
                                PrintArray.Add(inv.InvoicedID)
                                PrintArray.Add(i("RegionID"))
                                InvoicesToPrint.Add(PrintArray)

                            End If
                        Else
                            zeroInvoices = True
                        End If
                    End If
                Next

                If zeroInvoices Then
                    ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                PrintAdhocInvoice("DDINVOICE")

                PopulateDatagrid()

            End If
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ts2_Click(sender As Object, e As EventArgs) Handles ts2.Click 'receipt
        Try
            Dim zeroInvoices As Boolean = False

            If ValidateInvoiceAddress() Then
                FindPartPayJobs(False)

                Dim f As New FRMPaidBy

                f.ShowDialog()

                If Combo.GetSelectedItemValue(f.cboDDPaid) = 0 Then Exit Sub

                DDpaidBy = Combo.GetSelectedItemDescription(f.cboDDPaid)

                For Each i As DataRow In InvoicesDataview.Table.Rows
                    If Helper.MakeBooleanValid(i("tick")) = True And i("PAYMENTTERMID") <> 69817 Then
                        If Helper.MakeDoubleValid(i("Amount")) > 0 Then

                            'CHECK THAT ANOTHER USERS HASN'T GENERATED SINCE WE LAST REFRESHED OUR SCREEN

                            If DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(i("InvoiceToBeRaisedID")).Count = 0 Then

                                Dim inv As New Entity.Invoiceds.Invoiced
                                'AMY IS CHEATING AND USING JOB NUMBER - 5 isn't a job definition!
                                Dim invNum As New JobNumber
                                invNum = DB.Job.GetNextJobNumber(5)
                                inv.SetInvoiceNumber = invNum.Prefix & invNum.JobNumber
                                inv.SetRaisedByUserID = loggedInUser.UserID
                                inv.RaisedDate = i("RaiseDate")

                                If i("TAXRateID") > 0 Then
                                    inv.SetVATRateID = i("TAXRateID")
                                Else
                                    inv.SetVATRateID = DB.VATRatesSQL.VATRates_Get_ByDate(Now)
                                End If

                                inv.SetPaymentTermID = i("PaymentTermID")
                                inv.SetPaidByID = Combo.GetSelectedItemValue(f.cboDDPaid)
                                inv.SetAdhocInvoiceType = "DDRECEIPT"
                                inv = DB.Invoiced.Insert(inv)

                                Dim invLines As New Entity.InvoicedLiness.InvoicedLines
                                invLines.SetAmount = (i("Amount"))
                                invLines.SetInvoicedID = inv.InvoicedID
                                invLines.SetInvoiceToBeRaisedID = i("InvoiceToBeRaisedID")
                                invLines = DB.InvoicedLines.Insert(invLines)

                                Dim PrintArray As New ArrayList
                                PrintArray.Add(inv.InvoicedID)
                                PrintArray.Add(i("RegionID"))
                                InvoicesToPrint.Add(PrintArray)

                            End If
                        Else
                            zeroInvoices = True
                        End If
                    End If
                Next

                If zeroInvoices Then
                    ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                PrintAdhocInvoice("DDRECEIPT")

                PopulateDatagrid()

            End If
        Catch ex As Exception
            MessageBox.Show("An Error has occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub PrintAdhocInvoice(ByVal type As String)
        Dim details As New ArrayList
        details.Add(InvoicesToPrint)
        details.Add(type)
        details.Add(DDpaidBy)
        Dim oPrint As New Entity.Sys.Printing(details, "Invoice", Enums.SystemDocumentType.Invoice, True)
        '   System.Diagnostics.Process.Start(TheSystem.Configuration.DocumentsLocation)
        InvoicesToPrint.Clear()
    End Sub

    Private Sub RaiseProFormaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RaiseProFormaToolStripMenuItem.Click
        Dim details As New ArrayList

        '0 is type 327 contract , 260 visit [InvoiceTypeID]
        '1 is job or contractoriginalSITE  jobid and cos

        If InvoicesDataview.Table.Select("TICK = 1")(0)("InvoiceTypeID") = 327 Then
            details.Add("CONTRACT")
            details.Add(DB.ContractOriginalSite.Get(InvoicesDataview.Table.Select("TICK = 1")(0)("cos")))
        Else
            details.Add("JOB")
            details.Add(DB.Job.Job_Get(InvoicesDataview.Table.Select("TICK = 1")(0)("JobID")))
        End If

        Dim f As New FRMInvoiceExtraDetail

        f.ShowDialog()

        '2 is invoice notes
        details.Add(f.txtNotes.Text)
        '3 is Price
        details.Add(CDbl(f.txtCharge.Text))
        '4 is VAT double

        details.Add(DB.VATRatesSQL.VATRates_Get(Combo.GetSelectedItemValue(f.cbo)).VATRate)
        '5 is readytobeinvoicedID
        details.Add(InvoicesDataview.Table.Select("TICK = 1")(0)("InvoiceToBeRaisedID"))

        Dim oPrint As New Entity.Sys.Printing(details, "ProForma", Enums.SystemDocumentType.ProForma, True)
    End Sub

    Private Sub btnChangeLine_Click(sender As Object, e As EventArgs) Handles btnChangeLine.Click
        If InvoicesDataview IsNot Nothing Then
            If EnterOverridePasswordINV() Then
                Dim dr() As DataRow = (From sf In InvoicesDataview.Table.AsEnumerable()
                                       Where sf.Field(Of Boolean)("Tick") = True Select sf).ToArray()
                For Each r As DataRow In dr
                    Dim fCIL As FRMChangeInvoiceLine = ShowForm(GetType(FRMChangeInvoiceLine), True, New Object() {r("Amount"), r("TAXRateID")})
                    If fCIL.DialogResult = DialogResult.OK Then
                        r("Amount") = CDbl(fCIL.txtAmount.Text)
                        r("TAXRateID") = Combo.GetSelectedItemValue(fCIL.cboInvoiceTaxCodeNew)
                        r("VAT") = DB.VATRatesSQL.VATRates_Get(Combo.GetSelectedItemValue(fCIL.cboInvoiceTaxCodeNew)).VATRate
                    End If
                Next
            End If
        End If
    End Sub

End Class