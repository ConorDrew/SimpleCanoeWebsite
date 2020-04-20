Imports FSM.Entity.Sys

Public Class FRMOrderManager : Inherits FSM.FRMBaseForm : Implements IForm

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

    Friend WithEvents grpJobs As System.Windows.Forms.GroupBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkDateCreated As System.Windows.Forms.CheckBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents dgOrders As System.Windows.Forms.DataGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOrderRef As System.Windows.Forms.TextBox
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents btnFindRecord As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDeliveryDeadlineTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDeliveryDeadlineFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkDeliveryDeadline As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSupplierInvoiceSent As System.Windows.Forms.ComboBox
    Friend WithEvents txtConsolidationRef As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtContains As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkEngineerNotReceived As System.Windows.Forms.CheckBox
    Friend WithEvents btnFilterResults As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents chkOutstanding As CheckBox
    Friend WithEvents cboSupplier As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobs = New System.Windows.Forms.GroupBox()
        Me.dgOrders = New System.Windows.Forms.DataGrid()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.chkOutstanding = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.btnFilterResults = New System.Windows.Forms.Button()
        Me.chkEngineerNotReceived = New System.Windows.Forms.CheckBox()
        Me.txtContains = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtConsolidationRef = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboSupplierInvoiceSent = New System.Windows.Forms.ComboBox()
        Me.dtpDeliveryDeadlineTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpDeliveryDeadlineFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSupplier = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindRecord = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtOrderRef = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkDateCreated = New System.Windows.Forms.CheckBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.chkDeliveryDeadline = New System.Windows.Forms.CheckBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.grpJobs.SuspendLayout()
        CType(Me.dgOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgOrders)
        Me.grpJobs.Location = New System.Drawing.Point(8, 321)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(1360, 260)
        Me.grpJobs.TabIndex = 1
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Results (awaiting search) - Double Click To View / Edit"
        '
        'dgOrders
        '
        Me.dgOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgOrders.DataMember = ""
        Me.dgOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgOrders.Location = New System.Drawing.Point(8, 30)
        Me.dgOrders.Name = "dgOrders"
        Me.dgOrders.Size = New System.Drawing.Size(1344, 222)
        Me.dgOrders.TabIndex = 11
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 589)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.chkOutstanding)
        Me.grpFilter.Controls.Add(Me.Label12)
        Me.grpFilter.Controls.Add(Me.cboDepartment)
        Me.grpFilter.Controls.Add(Me.btnFilterResults)
        Me.grpFilter.Controls.Add(Me.chkEngineerNotReceived)
        Me.grpFilter.Controls.Add(Me.txtContains)
        Me.grpFilter.Controls.Add(Me.Label7)
        Me.grpFilter.Controls.Add(Me.txtConsolidationRef)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Controls.Add(Me.Label5)
        Me.grpFilter.Controls.Add(Me.cboSupplierInvoiceSent)
        Me.grpFilter.Controls.Add(Me.dtpDeliveryDeadlineTo)
        Me.grpFilter.Controls.Add(Me.dtpDeliveryDeadlineFrom)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.Label3)
        Me.grpFilter.Controls.Add(Me.cboSupplier)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.btnFindRecord)
        Me.grpFilter.Controls.Add(Me.txtSearch)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.txtOrderRef)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Controls.Add(Me.chkDateCreated)
        Me.grpFilter.Controls.Add(Me.lblSearch)
        Me.grpFilter.Controls.Add(Me.Label10)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Controls.Add(Me.Label11)
        Me.grpFilter.Controls.Add(Me.cboStatus)
        Me.grpFilter.Controls.Add(Me.chkDeliveryDeadline)
        Me.grpFilter.Location = New System.Drawing.Point(8, 40)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(1360, 275)
        Me.grpFilter.TabIndex = 0
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'chkOutstanding
        '
        Me.chkOutstanding.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkOutstanding.Location = New System.Drawing.Point(420, 122)
        Me.chkOutstanding.Name = "chkOutstanding"
        Me.chkOutstanding.Size = New System.Drawing.Size(221, 24)
        Me.chkOutstanding.TabIndex = 34
        Me.chkOutstanding.Text = "PO not reconciled (outstanding)"
        Me.chkOutstanding.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(13, 249)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 20)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Cost Centre"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Location = New System.Drawing.Point(136, 247)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(142, 21)
        Me.cboDepartment.TabIndex = 32
        '
        'btnFilterResults
        '
        Me.btnFilterResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterResults.Location = New System.Drawing.Point(1243, 244)
        Me.btnFilterResults.Name = "btnFilterResults"
        Me.btnFilterResults.Size = New System.Drawing.Size(109, 23)
        Me.btnFilterResults.TabIndex = 31
        Me.btnFilterResults.Text = "Filter Results"
        Me.btnFilterResults.UseVisualStyleBackColor = True
        '
        'chkEngineerNotReceived
        '
        Me.chkEngineerNotReceived.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkEngineerNotReceived.Location = New System.Drawing.Point(289, 123)
        Me.chkEngineerNotReceived.Name = "chkEngineerNotReceived"
        Me.chkEngineerNotReceived.Size = New System.Drawing.Size(141, 24)
        Me.chkEngineerNotReceived.TabIndex = 7
        Me.chkEngineerNotReceived.Text = "Eng Not Received"
        Me.chkEngineerNotReceived.UseVisualStyleBackColor = True
        '
        'txtContains
        '
        Me.txtContains.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContains.Location = New System.Drawing.Point(624, 92)
        Me.txtContains.MaxLength = 100
        Me.txtContains.Name = "txtContains"
        Me.txtContains.Size = New System.Drawing.Size(727, 21)
        Me.txtContains.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(523, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 23)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Order Contains"
        '
        'txtConsolidationRef
        '
        Me.txtConsolidationRef.Location = New System.Drawing.Point(395, 92)
        Me.txtConsolidationRef.Name = "txtConsolidationRef"
        Me.txtConsolidationRef.Size = New System.Drawing.Size(122, 21)
        Me.txtConsolidationRef.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(284, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 20)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Consolidation Ref"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(974, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(266, 23)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Supplier Invoice Sent to Accounts Package"
        '
        'cboSupplierInvoiceSent
        '
        Me.cboSupplierInvoiceSent.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSupplierInvoiceSent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplierInvoiceSent.Location = New System.Drawing.Point(1242, 121)
        Me.cboSupplierInvoiceSent.Name = "cboSupplierInvoiceSent"
        Me.cboSupplierInvoiceSent.Size = New System.Drawing.Size(110, 21)
        Me.cboSupplierInvoiceSent.TabIndex = 8
        '
        'dtpDeliveryDeadlineTo
        '
        Me.dtpDeliveryDeadlineTo.Location = New System.Drawing.Point(596, 216)
        Me.dtpDeliveryDeadlineTo.Name = "dtpDeliveryDeadlineTo"
        Me.dtpDeliveryDeadlineTo.Size = New System.Drawing.Size(224, 21)
        Me.dtpDeliveryDeadlineTo.TabIndex = 15
        '
        'dtpDeliveryDeadlineFrom
        '
        Me.dtpDeliveryDeadlineFrom.Location = New System.Drawing.Point(596, 184)
        Me.dtpDeliveryDeadlineFrom.Name = "dtpDeliveryDeadlineFrom"
        Me.dtpDeliveryDeadlineFrom.Size = New System.Drawing.Size(224, 21)
        Me.dtpDeliveryDeadlineFrom.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(548, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "To"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(548, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "From"
        '
        'cboSupplier
        '
        Me.cboSupplier.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplier.Location = New System.Drawing.Point(136, 152)
        Me.cboSupplier.Name = "cboSupplier"
        Me.cboSupplier.Size = New System.Drawing.Size(1216, 21)
        Me.cboSupplier.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Supplier"
        '
        'btnFindRecord
        '
        Me.btnFindRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindRecord.BackColor = System.Drawing.Color.White
        Me.btnFindRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindRecord.Location = New System.Drawing.Point(1320, 58)
        Me.btnFindRecord.Name = "btnFindRecord"
        Me.btnFindRecord.Size = New System.Drawing.Size(32, 23)
        Me.btnFindRecord.TabIndex = 2
        Me.btnFindRecord.Text = "..."
        Me.btnFindRecord.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(136, 60)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.ReadOnly = True
        Me.txtSearch.Size = New System.Drawing.Size(1176, 21)
        Me.txtSearch.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 20)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Order Ref"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(183, 216)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(224, 21)
        Me.dtpTo.TabIndex = 12
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(183, 184)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(224, 21)
        Me.dtpFrom.TabIndex = 11
        '
        'txtOrderRef
        '
        Me.txtOrderRef.Location = New System.Drawing.Point(136, 92)
        Me.txtOrderRef.Name = "txtOrderRef"
        Me.txtOrderRef.Size = New System.Drawing.Size(142, 21)
        Me.txtOrderRef.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(135, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(135, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "From"
        '
        'chkDateCreated
        '
        Me.chkDateCreated.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDateCreated.Location = New System.Drawing.Point(16, 184)
        Me.chkDateCreated.Name = "chkDateCreated"
        Me.chkDateCreated.Size = New System.Drawing.Size(104, 24)
        Me.chkDateCreated.TabIndex = 10
        Me.chkDateCreated.Text = "Date Placed"
        Me.chkDateCreated.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.Location = New System.Drawing.Point(16, 56)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(112, 20)
        Me.lblSearch.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 20)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type"
        '
        'cboType
        '
        Me.cboType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(136, 29)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(1216, 21)
        Me.cboType.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 20)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Status"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(136, 124)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(142, 21)
        Me.cboStatus.TabIndex = 6
        '
        'chkDeliveryDeadline
        '
        Me.chkDeliveryDeadline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkDeliveryDeadline.Location = New System.Drawing.Point(420, 184)
        Me.chkDeliveryDeadline.Name = "chkDeliveryDeadline"
        Me.chkDeliveryDeadline.Size = New System.Drawing.Size(132, 24)
        Me.chkDeliveryDeadline.TabIndex = 13
        Me.chkDeliveryDeadline.Text = "Delivery Deadline"
        Me.chkDeliveryDeadline.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 589)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        '
        'FRMOrderManager
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(1376, 619)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(852, 592)
        Me.Name = "FRMOrderManager"
        Me.Text = "Order Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Classes"

    Public Class PartsNotReceivedColourColumn : Inherits DataGridLabelColumn

#Region "Functions"

        Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
            'set the color required dependant on the column value
            Dim brush As Brush = Brushes.White

            If Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item("OrderTypeID")) = CInt(Entity.Sys.Enums.OrderType.Job) Or Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item("OrderTypeID")) = CInt(Entity.Sys.Enums.OrderType.StockProfile) Then
                If Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item("PartsNotReceived")) Then
                    brush = Brushes.Red
                Else
                    brush = Brushes.Green
                End If
            End If
            'color the row cell
            Dim rect As Rectangle = bounds
            g.FillRectangle(brush, rect)
            g.DrawString("", Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
        End Sub

#End Region

    End Class

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupOrdersDataGrid()
        Combo.SetUpCombo(Me.cboType, DynamicDataTables.OrderTypeForSearch, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboStatus, DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboSupplierInvoiceSent, DynamicDataTables.Yes_No, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboSupplier, DB.Supplier.Supplier_GetAll.Table, "SupplierID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)

        Select Case True
            Case IsGasway
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative)
            Case Else
                Combo.SetUpCombo(Me.cboDepartment, DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative)
        End Select

        ResetFilters()

        If Not GetParameter(0) Is Nothing Then
            PopulateDatagrid()
        End If
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

    Private _dvOrders As DataView

    Private Property OrdersDataview() As DataView
        Get
            Return _dvOrders
        End Get
        Set(ByVal value As DataView)
            _dvOrders = value
            _dvOrders.AllowNew = False
            _dvOrders.AllowEdit = False
            _dvOrders.AllowDelete = False
            _dvOrders.Table.TableName = Entity.Sys.Enums.TableNames.tblOrder.ToString
            Me.dgOrders.DataSource = OrdersDataview
        End Set
    End Property

    Private ReadOnly Property SelectedOrderDataRow() As DataRow
        Get
            If Not Me.dgOrders.CurrentRowIndex = -1 Then
                Return OrdersDataview(Me.dgOrders.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private _oSite As Entity.Sites.Site

    Public Property theSite() As Entity.Sites.Site
        Get
            Return _oSite
        End Get
        Set(ByVal Value As Entity.Sites.Site)
            _oSite = Value
            If Not _oSite Is Nothing Then
                Me.txtSearch.Text = theSite.Address1 & ", " & theSite.Address2 & ", " & theSite.Postcode
            Else
                Me.txtSearch.Text = ""
            End If
        End Set
    End Property

    Private _oVan As Entity.Vans.Van

    Public Property Van() As Entity.Vans.Van
        Get
            Return _oVan
        End Get
        Set(ByVal Value As Entity.Vans.Van)
            _oVan = Value
            If Not _oVan Is Nothing Then
                Me.txtSearch.Text = _oVan.Registration
            Else
                Me.txtSearch.Text = ""
            End If
        End Set
    End Property

    Private _oWarehouse As Entity.Warehouses.Warehouse

    Public Property Warehouse() As Entity.Warehouses.Warehouse
        Get
            Return _oWarehouse
        End Get
        Set(ByVal Value As Entity.Warehouses.Warehouse)
            _oWarehouse = Value
            If Not _oWarehouse Is Nothing Then
                Me.txtSearch.Text = _oWarehouse.Name & " (" & _oWarehouse.Address1 & ", " & _oWarehouse.Postcode & ")"
            Else
                Me.txtSearch.Text = ""
            End If
        End Set
    End Property

    Private _oJob As Entity.Jobs.Job

    Public Property Job() As Entity.Jobs.Job
        Get
            Return _oJob
        End Get
        Set(ByVal Value As Entity.Jobs.Job)
            _oJob = Value
            If Not _oJob Is Nothing Then
                Me.txtSearch.Text = _oJob.JobNumber
            Else
                Me.txtSearch.Text = ""
            End If
        End Set
    End Property

#End Region

#Region "Setup"

    Private Sub SetupOrdersDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgOrders.TableStyles(0)

        Dim PartsNotReceived As New PartsNotReceivedColourColumn
        PartsNotReceived.Format = ""
        PartsNotReceived.FormatInfo = Nothing
        PartsNotReceived.HeaderText = ""
        PartsNotReceived.MappingName = "PartsNotReceived"
        PartsNotReceived.ReadOnly = True
        PartsNotReceived.Width = 25
        PartsNotReceived.NullText = ""
        tbStyle.GridColumnStyles.Add(PartsNotReceived)

        Dim DateCreated As New DataGridLabelColumn
        DateCreated.Format = "dd/MMM/yyyy"
        DateCreated.FormatInfo = Nothing
        DateCreated.HeaderText = "Date Placed"
        DateCreated.MappingName = "DatePlaced"
        DateCreated.ReadOnly = True
        DateCreated.Width = 90
        DateCreated.NullText = ""
        tbStyle.GridColumnStyles.Add(DateCreated)

        Dim DeliveryDeadline As New DataGridLabelColumn
        DeliveryDeadline.Format = "dd/MMM/yyyy"
        DeliveryDeadline.FormatInfo = Nothing
        DeliveryDeadline.HeaderText = "Delivery Deadline"
        DeliveryDeadline.MappingName = "DeliveryDeadline"
        DeliveryDeadline.ReadOnly = True
        DeliveryDeadline.Width = 90
        DeliveryDeadline.NullText = ""
        tbStyle.GridColumnStyles.Add(DeliveryDeadline)

        Dim OrderReference As New DataGridLabelColumn
        OrderReference.Format = ""
        OrderReference.FormatInfo = Nothing
        OrderReference.HeaderText = "Order Reference"
        OrderReference.MappingName = "OrderReference"
        OrderReference.ReadOnly = True
        OrderReference.Width = 110
        OrderReference.NullText = ""
        tbStyle.GridColumnStyles.Add(OrderReference)

        Dim ConsolidationRef As New DataGridLabelColumn
        ConsolidationRef.Format = ""
        ConsolidationRef.FormatInfo = Nothing
        ConsolidationRef.HeaderText = "Consol Ref"
        ConsolidationRef.MappingName = "ConsolidationRef"
        ConsolidationRef.ReadOnly = True
        ConsolidationRef.Width = 110
        ConsolidationRef.NullText = ""
        tbStyle.GridColumnStyles.Add(ConsolidationRef)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tbStyle.GridColumnStyles.Add(Type)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 140
        Customer.NullText = "N/A"
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Property"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 140
        Site.NullText = "N/A"
        tbStyle.GridColumnStyles.Add(Site)

        Dim Supplier As New DataGridLabelColumn
        Supplier.Format = ""
        Supplier.FormatInfo = Nothing
        Supplier.HeaderText = "Supplier"
        Supplier.MappingName = "Supplier"
        Supplier.ReadOnly = True
        Supplier.Width = 100
        Supplier.NullText = "N/A"
        tbStyle.GridColumnStyles.Add(Supplier)

        Dim Van As New DataGridLabelColumn
        Van.Format = ""
        Van.FormatInfo = Nothing
        Van.HeaderText = "Van"
        Van.MappingName = "Registration"
        Van.ReadOnly = True
        Van.Width = 90
        Van.NullText = "N/A"
        tbStyle.GridColumnStyles.Add(Van)

        Dim Warehouse As New DataGridLabelColumn
        Warehouse.Format = ""
        Warehouse.FormatInfo = Nothing
        Warehouse.HeaderText = "Warehouse"
        Warehouse.MappingName = "Warehouse"
        Warehouse.ReadOnly = True
        Warehouse.Width = 100
        Warehouse.NullText = "N/A"
        tbStyle.GridColumnStyles.Add(Warehouse)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 100
        JobNumber.NullText = "N/A"
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim OrderStatus As New DataGridLabelColumn
        OrderStatus.Format = ""
        OrderStatus.FormatInfo = Nothing
        OrderStatus.HeaderText = "Status"
        OrderStatus.MappingName = "DisplayStatus"
        OrderStatus.ReadOnly = True
        OrderStatus.Width = 120
        OrderStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(OrderStatus)

        Dim SupplierExported As New DataGridLabelColumn
        SupplierExported.Format = ""
        SupplierExported.FormatInfo = Nothing
        SupplierExported.HeaderText = "Sup Inv Sent to Sage"
        SupplierExported.MappingName = "SupplierExported"
        SupplierExported.ReadOnly = True
        SupplierExported.Width = 50
        SupplierExported.NullText = ""
        tbStyle.GridColumnStyles.Add(SupplierExported)

        Dim BuyPrice As New DataGridLabelColumn
        BuyPrice.Format = "C"
        BuyPrice.FormatInfo = Nothing
        BuyPrice.HeaderText = "Cost"
        BuyPrice.MappingName = "BuyPrice"
        BuyPrice.ReadOnly = True
        BuyPrice.Width = 75
        BuyPrice.NullText = "0"
        tbStyle.GridColumnStyles.Add(BuyPrice)

        Dim SellPrice As New DataGridLabelColumn
        SellPrice.Format = "C"
        SellPrice.FormatInfo = Nothing
        SellPrice.HeaderText = "SI Amount"
        SellPrice.MappingName = "SupplierInvoiceAmount"
        SellPrice.ReadOnly = True
        SellPrice.Width = 75
        SellPrice.NullText = "£0.00"
        tbStyle.GridColumnStyles.Add(SellPrice)

        Dim Credit As New DataGridLabelColumn
        Credit.Format = "C"
        Credit.FormatInfo = Nothing
        Credit.HeaderText = "Credited Amount"
        Credit.MappingName = "CreditAmount"
        Credit.ReadOnly = True
        Credit.Width = 75
        Credit.NullText = "£0.00"
        tbStyle.GridColumnStyles.Add(Credit)

        Dim CreatedBy As New DataGridLabelColumn
        CreatedBy.Format = ""
        CreatedBy.FormatInfo = Nothing
        CreatedBy.HeaderText = "Created By"
        CreatedBy.MappingName = "CreatedBy"
        CreatedBy.ReadOnly = True
        CreatedBy.Width = 100
        CreatedBy.NullText = ""
        tbStyle.GridColumnStyles.Add(CreatedBy)

        Dim Department As New DataGridLabelColumn
        Department.Format = ""
        Department.FormatInfo = Nothing
        Department.HeaderText = "Dept"
        Department.MappingName = "DepartmentRef"
        Department.ReadOnly = True
        Department.Width = 100
        Department.NullText = ""
        tbStyle.GridColumnStyles.Add(Department)

        Me.dgOrders.ReadOnly = True
        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblOrder.ToString
        Me.dgOrders.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMOrderManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub chkDateCreated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDateCreated.CheckedChanged
        If Me.chkDateCreated.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Value = Today
            Me.dtpTo.Value = Today
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
        'RunFilter()
    End Sub

    Private Sub chkDeliveryDeadline_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDeliveryDeadline.CheckedChanged
        If Me.chkDeliveryDeadline.Checked Then
            Me.dtpDeliveryDeadlineFrom.Enabled = True
            Me.dtpDeliveryDeadlineTo.Enabled = True
        Else
            Me.dtpDeliveryDeadlineFrom.Value = Today
            Me.dtpDeliveryDeadlineTo.Value = Today
            Me.dtpDeliveryDeadlineFrom.Enabled = False
            Me.dtpDeliveryDeadlineTo.Enabled = False
        End If
        'RunFilter()
    End Sub

    Private Sub cboSite_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'RunFilter()
    End Sub

    Private Sub cboVan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'RunFilter()
    End Sub

    Private Sub cboWarehouse_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'RunFilter()
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        theSite = Nothing
        Van = Nothing
        Job = Nothing
        Warehouse = Nothing
        Select Case Combo.GetSelectedItemValue(cboType)
            Case 0
                Me.lblSearch.Text = "Select Type"
                Me.txtSearch.Text = ""
                Me.btnFindRecord.Enabled = False
            Case 1
                Me.lblSearch.Text = "Select Property"
                Me.txtSearch.Text = ""
                Me.btnFindRecord.Enabled = True
            Case 2
                Me.lblSearch.Text = "Select Warehouse"
                Me.txtSearch.Text = ""
                Me.btnFindRecord.Enabled = True
            Case 3
                Me.lblSearch.Text = "Select Van"
                Me.txtSearch.Text = ""
                Me.btnFindRecord.Enabled = True
            Case 4
                Me.lblSearch.Text = "Select Warehouse"
                Me.txtSearch.Text = ""
                Me.btnFindRecord.Enabled = True
            Case 5
                Me.lblSearch.Text = "Select Job"
                Me.txtSearch.Text = ""
                Me.btnFindRecord.Enabled = True
        End Select
        'RunFilter()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
        'RunFilter()
    End Sub

    Private Sub chkEngineerNotReceived_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEngineerNotReceived.CheckedChanged
        RunFilter()
    End Sub

    Private Sub cboSupplierInvoiceSent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSupplierInvoiceSent.SelectedIndexChanged
        'RunFilter()
    End Sub

    Private Sub txtOrderRef_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOrderRef.KeyDown

        If e.KeyCode = Keys.Enter Then
            Query()
        End If

    End Sub

    Private Sub txtConsolidationRef_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConsolidationRef.TextChanged
        'RunFilter()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        'RunFilter()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        'RunFilter()
    End Sub

    Private Sub dtpDeliveryDeadlineFrom_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDeliveryDeadlineFrom.ValueChanged
        'RunFilter()
    End Sub

    Private Sub dtpDeliveryDeadlineTo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDeliveryDeadlineTo.ValueChanged
        'RunFilter()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

    Private Sub cboSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSupplier.SelectedIndexChanged
        'RunFilter()
    End Sub

    Private Sub txtContains_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContains.TextChanged
        'Try
        '    If txtContains.Text.Length >= 3 Then

        '        Cursor.Current = Cursors.WaitCursor

        '        OrdersDataview = DB.Order.Order_GetAll(Me.txtContains.Text.Trim)

        '        RunFilter()
        '    End If
        'Catch ex As Exception
        '    Exit Sub
        'Finally
        '    Cursor.Current = Cursors.Default
        'End Try
    End Sub

    Private Sub dgOrders_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOrders.DoubleClick
        If SelectedOrderDataRow Is Nothing Then
            ShowMessage("Please select an order to view", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Select Case CInt(SelectedOrderDataRow.Item("OrderTypeID"))
            Case Entity.Sys.Enums.OrderType.Customer
                ShowForm(GetType(FRMOrder), False, New Object() {SelectedOrderDataRow.Item("OrderID"), Entity.Sys.Helper.MakeIntegerValid(SelectedOrderDataRow.Item("SiteID")), 0, Me})
            Case Entity.Sys.Enums.OrderType.StockProfile
                ShowForm(GetType(FRMOrder), False, New Object() {SelectedOrderDataRow.Item("OrderID"), SelectedOrderDataRow.Item("VanID"), 0, Me})
            Case Entity.Sys.Enums.OrderType.Warehouse
                ShowForm(GetType(FRMOrder), False, New Object() {SelectedOrderDataRow.Item("OrderID"), SelectedOrderDataRow.Item("WarehouseID"), 0, Me})
            Case Entity.Sys.Enums.OrderType.Job
                ShowForm(GetType(FRMOrder), False, New Object() {SelectedOrderDataRow.Item("OrderID"), SelectedOrderDataRow.Item("EngineerVisitID"), 0, Me})
        End Select

    End Sub

    Private Sub btnFindRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRecord.Click

        Select Case Combo.GetSelectedItemValue(cboType)
            Case 0

            Case 1
                Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSite)
                If Not ID = 0 Then
                    theSite = DB.Sites.Get(ID)
                    RunFilter()
                End If
            Case 2
                Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
                If Not ID = 0 Then
                    Warehouse = DB.Warehouse.Warehouse_Get(ID)
                    RunFilter()
                End If
            Case 3
                Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblVan)
                If Not ID = 0 Then
                    Van = DB.Van.Van_Get(ID)
                    RunFilter()
                End If
            Case 4
                Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse)
                If Not ID = 0 Then
                    Warehouse = DB.Warehouse.Warehouse_Get(ID)
                    RunFilter()
                End If
            Case 5
                Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblJob)
                If Not ID = 0 Then
                    Job = DB.Job.Job_Get(ID)
                    RunFilter()
                End If
        End Select
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try

            'If GetParameter(0) = "" ThenElse
            If GetParameter(0) Is Nothing Then
                OrdersDataview = DB.Order.Order_GetAll(Me.txtContains.Text.Trim)
                RunFilter()
            Else
                OrdersDataview = GetParameter(0)
                Me.grpFilter.Enabled = False
            End If

            'If Not GetParameter(0) = "" Then
            grpJobs.Text = String.Format("Results ({0}) - Double Click To View / Edit", OrdersDataview.Count)
            'End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()

        Combo.SetSelectedComboItem_By_Value(Me.cboType, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboSupplierInvoiceSent, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboSupplier, 0)
        Me.chkDateCreated.Checked = False
        Me.dtpFrom.Value = Today
        Me.dtpFrom.Enabled = False
        Me.dtpTo.Value = Today
        Me.dtpTo.Enabled = False
        Me.chkDeliveryDeadline.Checked = False
        Me.dtpDeliveryDeadlineFrom.Value = Today
        Me.dtpDeliveryDeadlineFrom.Enabled = False
        Me.dtpDeliveryDeadlineTo.Value = Today
        Me.dtpDeliveryDeadlineTo.Enabled = False
        Me.grpFilter.Enabled = True
        Me.txtSearch.Text = ""
        Me.txtConsolidationRef.Text = ""
        Me.txtOrderRef.Text = ""
    End Sub

    Private Sub RunFilter()
        If Not OrdersDataview Is Nothing Then

            Dim whereClause As String = "Deleted = 0 "

            If Not theSite Is Nothing Then
                whereClause += " AND SiteID = " & theSite.SiteID & ""
            End If
            If Not Van Is Nothing Then
                whereClause += " AND VanID = " & Van.VanID & ""
            End If
            If Not Warehouse Is Nothing Then
                whereClause += " AND WarehouseID = " & Warehouse.WarehouseID & ""
            End If
            If Not Job Is Nothing Then
                whereClause += " AND JobID = " & Job.JobID & ""
            End If
            If Me.chkEngineerNotReceived.Checked Then
                whereClause += " AND PartsNotReceived = 1 "
            End If

            Select Case Combo.GetSelectedItemValue(cboType)
                Case 0

                Case 1
                    whereClause += " AND OrderTypeID = 1" & ""
                Case 2
                    whereClause += " AND OrderTypeID = 1" & ""
                Case 3
                    whereClause += " AND OrderTypeID = 2" & ""
                Case 4
                    whereClause += " AND OrderTypeID = 3" & ""
                Case 5
                    whereClause += " AND OrderTypeID = 4" & ""
            End Select

            If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 Then
                whereClause += " AND DisplayStatusID = " & Combo.GetSelectedItemValue(Me.cboStatus) & ""
            End If

            If Not Combo.GetSelectedItemValue(Me.cboSupplier) = 0 Then
                whereClause += " AND SupplierID = " & Combo.GetSelectedItemValue(Me.cboSupplier) & ""
            End If

            If Not Combo.GetSelectedItemValue(Me.cboSupplierInvoiceSent) = "0" Then
                whereClause += " AND SupplierExported = '" & Combo.GetSelectedItemDescription(Me.cboSupplierInvoiceSent) & "'"
            End If

            If Not Me.txtOrderRef.Text.Trim.Length = 0 Then
                whereClause += " AND OrderReference LIKE '%" & Me.txtOrderRef.Text.Trim & "%'"
            End If
            If Not Me.txtConsolidationRef.Text.Trim.Length = 0 Then
                whereClause += " AND ConsolidationRef LIKE '%" & Me.txtConsolidationRef.Text.Trim & "%'"
            End If
            If Me.chkDateCreated.Checked Then
                whereClause += " AND DatePlaced >= '" & Format(Me.dtpFrom.Value, "dd/MM/yyyy 00:00:00") & "' AND DatePlaced <= '" & Format(Me.dtpTo.Value, "dd/MM/yyyy 23:59:59") & "'"
            End If
            If Me.chkDeliveryDeadline.Checked Then
                whereClause += " AND DeliveryDeadline >= '" & Format(Me.dtpDeliveryDeadlineFrom.Value, "dd/MM/yyyy 00:00:00") & "' AND DeliveryDeadline <= '" & Format(Me.dtpDeliveryDeadlineTo.Value, "dd/MM/yyyy 23:59:59") & "'"
            End If

            If Me.chkOutstanding.Checked Then
                whereClause += " AND CONVERT(NUMERIC(10,2),SupplierInvoiceAmount) <= CONVERT(NUMERIC(10,2),BuyPrice) "
            End If

            OrdersDataview.RowFilter = whereClause

            grpJobs.Text = String.Format("Results ({0}) - Double Click To View / Edit", OrdersDataview.Count)
        End If
    End Sub

    Public Sub Export()

        Dim exportData As New DataTable
        exportData.Columns.Add("DatePlaced")
        exportData.Columns.Add("DeliveryDeadline")
        exportData.Columns.Add("OrderReference")
        exportData.Columns.Add("ConsolidationRef")
        exportData.Columns.Add("Type")
        exportData.Columns.Add("Customer")
        exportData.Columns.Add("Property")
        exportData.Columns.Add("Supplier")
        exportData.Columns.Add("Van")
        exportData.Columns.Add("Warehouse")
        exportData.Columns.Add("JobNumber")
        exportData.Columns.Add("Status")
        exportData.Columns.Add("Supplier Invoice Sent To Sage")
        exportData.Columns.Add("BuyPrice", GetType(Double))
        exportData.Columns.Add("SellPrice", GetType(Double))
        exportData.Columns.Add("CreatedBy")
        exportData.Columns.Add("DepartmentRef")
        Dim ssm As Entity.Sys.Enums.SecuritySystemModules
        ssm = Entity.Sys.Enums.SecuritySystemModules.IT

        If loggedInUser.HasAccessToModule(ssm) = True Then
            exportData.Columns.Add("OrderID")
        End If

        For Each dr As DataRowView In CType(dgOrders.DataSource, DataView)
            Dim newRw As DataRow = exportData.NewRow
            newRw("DatePlaced") = dr("DatePlaced")
            newRw("DeliveryDeadline") = dr("DeliveryDeadline")
            newRw("OrderReference") = dr("OrderReference")
            newRw("ConsolidationRef") = dr("ConsolidationRef")
            newRw("Type") = dr("Type")
            newRw("Customer") = dr("Customer")
            newRw("Property") = dr("Site")
            newRw("Supplier") = dr("Supplier")
            newRw("Van") = dr("Registration")
            newRw("Warehouse") = dr("Warehouse")
            newRw("JobNumber") = dr("JobNumber")
            newRw("Status") = dr("DisplayStatus")
            newRw("Supplier Invoice Sent To Sage") = dr("SupplierExported")
            newRw("BuyPrice") = dr("BuyPrice")
            newRw("SellPrice") = dr("SellPrice")
            newRw("CreatedBy") = dr("CreatedBy")
            newRw("DepartmentRef") = dr("DepartmentRef")
            If loggedInUser.HasAccessToModule(ssm) = True Then
                newRw("OrderID") = dr("OrderID")
            End If
            exportData.Rows.Add(newRw)
        Next
        ExportHelper.Export(exportData, "Order List", Enums.ExportType.XLS)
    End Sub

#End Region

    Private Sub btnFilterResults_Click(sender As Object, e As EventArgs) Handles btnFilterResults.Click
        Query()
    End Sub

    Sub Query()

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim OrderSiteID As Integer = 0
            If Not theSite Is Nothing Then
                OrderSiteID = theSite.SiteID
            End If

            Dim OrderVanID As Integer = 0
            If Not Van Is Nothing Then
                OrderVanID = Van.VanID
            End If

            Dim OrderWarehouseID As Integer = 0
            If Not Warehouse Is Nothing Then
                OrderWarehouseID = Warehouse.WarehouseID
            End If

            Dim OrderJobID As Integer = 0
            If Not Job Is Nothing Then
                OrderJobID = Job.JobID
            End If
            Dim OrderTypeID As Integer = 0
            Select Case Combo.GetSelectedItemValue(cboType)
                Case 0

                Case 1
                    OrderTypeID = 1
                Case 2
                    OrderTypeID = 1
                Case 3
                    OrderTypeID = 2
                Case 4
                    OrderTypeID = 3
                Case 5
                    OrderTypeID = 4
            End Select

            Dim PartsNotReceived As Integer = Nothing
            If chkEngineerNotReceived.Checked Then
                PartsNotReceived = 1
            Else
                PartsNotReceived = 0
            End If

            Dim OrderSupplierID As Integer = 0
            If Not Combo.GetSelectedItemValue(Me.cboSupplier) = "0" Then
                OrderSupplierID = Combo.GetSelectedItemValue(Me.cboSupplier)
            End If
            Dim OrderSupplierExported As Integer = 0
            If Combo.GetSelectedItemValue(Me.cboSupplierInvoiceSent) = "0" Then
                OrderSupplierExported = 0
            ElseIf Combo.GetSelectedItemValue(Me.cboSupplierInvoiceSent) = "Yes" Then
                OrderSupplierExported = 1
            Else
                OrderSupplierExported = 2
            End If

            Dim OrderReference As String = Nothing
            If Me.txtOrderRef.Text.Trim = "" Then
                OrderReference = "%"
            Else
                OrderReference = "%" & Me.txtOrderRef.Text.Trim & "%"
            End If
            Dim OrderConsolidationRef As String = Nothing
            If Me.txtConsolidationRef.Text.Trim = "" Then
                OrderConsolidationRef = "%%"
            Else
                OrderConsolidationRef = "%" & Me.txtConsolidationRef.Text.Trim & "%"
            End If
            Dim OrderDatePlacedFrom As DateTime? = Nothing
            Dim OrderDatePlacedTo As DateTime? = Nothing

            If Me.chkDateCreated.Checked Then
                OrderDatePlacedFrom = Format(Me.dtpFrom.Value, "dd/MM/yyyy 00:00:00")
                OrderDatePlacedTo = Format(Me.dtpTo.Value, "dd/MM/yyyy 23:59:59")
            End If

            Dim OrderDeliveryDeadlineFrom As DateTime? = Nothing
            Dim OrderDeliveryDeadlineTo As DateTime? = Nothing

            If Me.chkDeliveryDeadline.Checked Then
                OrderDeliveryDeadlineFrom = Format(Me.dtpDeliveryDeadlineFrom.Value, "dd/MM/yyyy 00:00:00")
                OrderDeliveryDeadlineTo = Format(Me.dtpDeliveryDeadlineTo.Value, "dd/MM/yyyy 23:59:59")
            End If

            Dim OrderStatus As Integer = 0
            If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 Then
                OrderStatus = Combo.GetSelectedItemValue(Me.cboStatus)
            End If

            Dim OrderContains As String = Nothing
            If Me.txtContains.Text.Trim = "" Then
                OrderContains = ""
            Else
                OrderContains = Me.txtContains.Text.Trim
            End If

            Dim OrderDepartment As String = "%%"
            Dim department As String = Helper.MakeStringValid(Combo.GetSelectedItemValue(cboDepartment))
            If Helper.IsValidInteger(department) AndAlso Not Helper.MakeIntegerValid(department) <= 0 Then
                OrderDepartment = department
            ElseIf Not IsNumeric(department) Then
                OrderDepartment = department
            End If

            OrdersDataview = DB.Order.Order_GetAll_NEW(OrderContains, OrderSiteID, OrderVanID, OrderWarehouseID, OrderJobID, OrderTypeID, OrderReference, OrderConsolidationRef, OrderStatus, PartsNotReceived, OrderSupplierExported, OrderSupplierID, OrderDatePlacedFrom, OrderDatePlacedTo, OrderDeliveryDeadlineFrom, OrderDeliveryDeadlineTo, OrderDepartment)
            If Me.chkOutstanding.Checked Then
                OrdersDataview.RowFilter = "Isnull(SupplierInvoiceAmount,0) < BuyPrice"
            End If
            grpJobs.Text = String.Format("Results ({0}) - Double Click To View / Edit", OrdersDataview.Count)
        Catch ex As Exception
            Exit Sub
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub txtOrderRef_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub chkOutstanding_CheckedChanged(sender As Object, e As EventArgs) Handles chkOutstanding.CheckedChanged

    End Sub

End Class