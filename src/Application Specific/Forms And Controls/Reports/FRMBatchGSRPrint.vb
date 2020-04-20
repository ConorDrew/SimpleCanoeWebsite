Public Class FRMBatchGSRPrint : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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

    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboDefinition As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkVisitDate As System.Windows.Forms.CheckBox
    Friend WithEvents grpEngineerVisits As System.Windows.Forms.GroupBox
    Friend WithEvents dgVisits As System.Windows.Forms.DataGrid
    Friend WithEvents btnFindSite As System.Windows.Forms.Button
    Friend WithEvents txtSite As System.Windows.Forms.TextBox
    Friend WithEvents txtPostcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindCustomer As System.Windows.Forms.Button
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboOutcome As System.Windows.Forms.ComboBox
    Friend WithEvents btnUnselect As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents chkPrintHdr As System.Windows.Forms.CheckBox
    Friend WithEvents chkExceptionsOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnShowdata As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpEngineerVisits = New System.Windows.Forms.GroupBox()
        Me.dgVisits = New System.Windows.Forms.DataGrid()
        Me.grpFilter = New System.Windows.Forms.GroupBox()
        Me.chkExceptionsOnly = New System.Windows.Forms.CheckBox()
        Me.chkPrintHdr = New System.Windows.Forms.CheckBox()
        Me.btnUnselect = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnShowdata = New System.Windows.Forms.Button()
        Me.cboOutcome = New System.Windows.Forms.ComboBox()
        Me.btnFindCustomer = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindSite = New System.Windows.Forms.Button()
        Me.txtSite = New System.Windows.Forms.TextBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtJobNumber = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkVisitDate = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboDefinition = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.grpEngineerVisits.SuspendLayout()
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpEngineerVisits
        '
        Me.grpEngineerVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpEngineerVisits.Controls.Add(Me.dgVisits)
        Me.grpEngineerVisits.Location = New System.Drawing.Point(8, 256)
        Me.grpEngineerVisits.Name = "grpEngineerVisits"
        Me.grpEngineerVisits.Size = New System.Drawing.Size(784, 205)
        Me.grpEngineerVisits.TabIndex = 2
        Me.grpEngineerVisits.TabStop = False
        Me.grpEngineerVisits.Text = "Double Click To View / Edit"
        '
        'dgVisits
        '
        Me.dgVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgVisits.DataMember = ""
        Me.dgVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgVisits.Location = New System.Drawing.Point(8, 18)
        Me.dgVisits.Name = "dgVisits"
        Me.dgVisits.Size = New System.Drawing.Size(768, 179)
        Me.dgVisits.TabIndex = 14
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.chkExceptionsOnly)
        Me.grpFilter.Controls.Add(Me.chkPrintHdr)
        Me.grpFilter.Controls.Add(Me.btnUnselect)
        Me.grpFilter.Controls.Add(Me.btnSelectAll)
        Me.grpFilter.Controls.Add(Me.btnShowdata)
        Me.grpFilter.Controls.Add(Me.cboOutcome)
        Me.grpFilter.Controls.Add(Me.btnFindCustomer)
        Me.grpFilter.Controls.Add(Me.txtCustomer)
        Me.grpFilter.Controls.Add(Me.Label4)
        Me.grpFilter.Controls.Add(Me.txtPostcode)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.btnFindSite)
        Me.grpFilter.Controls.Add(Me.txtSite)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.txtJobNumber)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Controls.Add(Me.chkVisitDate)
        Me.grpFilter.Controls.Add(Me.Label6)
        Me.grpFilter.Controls.Add(Me.Label3)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.Label10)
        Me.grpFilter.Controls.Add(Me.cboType)
        Me.grpFilter.Controls.Add(Me.Label11)
        Me.grpFilter.Controls.Add(Me.cboDefinition)
        Me.grpFilter.Controls.Add(Me.cboStatus)
        Me.grpFilter.Controls.Add(Me.Label13)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(784, 224)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'chkExceptionsOnly
        '
        Me.chkExceptionsOnly.AutoSize = True
        Me.chkExceptionsOnly.Location = New System.Drawing.Point(361, 197)
        Me.chkExceptionsOnly.Name = "chkExceptionsOnly"
        Me.chkExceptionsOnly.Size = New System.Drawing.Size(147, 17)
        Me.chkExceptionsOnly.TabIndex = 39
        Me.chkExceptionsOnly.Text = "Only Print Exceptions"
        Me.chkExceptionsOnly.UseVisualStyleBackColor = True
        '
        'chkPrintHdr
        '
        Me.chkPrintHdr.AutoSize = True
        Me.chkPrintHdr.Location = New System.Drawing.Point(216, 197)
        Me.chkPrintHdr.Name = "chkPrintHdr"
        Me.chkPrintHdr.Size = New System.Drawing.Size(129, 17)
        Me.chkPrintHdr.TabIndex = 38
        Me.chkPrintHdr.Text = "Print Header Page"
        Me.chkPrintHdr.UseVisualStyleBackColor = True
        '
        'btnUnselect
        '
        Me.btnUnselect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUnselect.Location = New System.Drawing.Point(113, 192)
        Me.btnUnselect.Name = "btnUnselect"
        Me.btnUnselect.Size = New System.Drawing.Size(96, 23)
        Me.btnUnselect.TabIndex = 37
        Me.btnUnselect.Text = "Unselect All"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Location = New System.Drawing.Point(11, 192)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(96, 23)
        Me.btnSelectAll.TabIndex = 36
        Me.btnSelectAll.Text = "Select All"
        '
        'btnShowdata
        '
        Me.btnShowdata.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowdata.Location = New System.Drawing.Point(679, 192)
        Me.btnShowdata.Name = "btnShowdata"
        Me.btnShowdata.Size = New System.Drawing.Size(96, 23)
        Me.btnShowdata.TabIndex = 35
        Me.btnShowdata.Text = "Show Data"
        '
        'cboOutcome
        '
        Me.cboOutcome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOutcome.Location = New System.Drawing.Point(600, 115)
        Me.cboOutcome.Name = "cboOutcome"
        Me.cboOutcome.Size = New System.Drawing.Size(176, 21)
        Me.cboOutcome.TabIndex = 34
        '
        'btnFindCustomer
        '
        Me.btnFindCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindCustomer.BackColor = System.Drawing.Color.White
        Me.btnFindCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindCustomer.Location = New System.Drawing.Point(736, 19)
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
        Me.txtCustomer.Location = New System.Drawing.Point(104, 19)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(624, 21)
        Me.txtCustomer.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Customer"
        '
        'txtPostcode
        '
        Me.txtPostcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPostcode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostcode.Location = New System.Drawing.Point(104, 67)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(184, 21)
        Me.txtPostcode.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Postcode"
        '
        'btnFindSite
        '
        Me.btnFindSite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFindSite.BackColor = System.Drawing.Color.White
        Me.btnFindSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindSite.Location = New System.Drawing.Point(736, 43)
        Me.btnFindSite.Name = "btnFindSite"
        Me.btnFindSite.Size = New System.Drawing.Size(32, 23)
        Me.btnFindSite.TabIndex = 4
        Me.btnFindSite.Text = "..."
        Me.btnFindSite.UseVisualStyleBackColor = False
        '
        'txtSite
        '
        Me.txtSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSite.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSite.Location = New System.Drawing.Point(104, 43)
        Me.txtSite.Name = "txtSite"
        Me.txtSite.ReadOnly = True
        Me.txtSite.Size = New System.Drawing.Size(624, 21)
        Me.txtSite.TabIndex = 3
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(144, 163)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(144, 21)
        Me.dtpTo.TabIndex = 13
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(144, 139)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(144, 21)
        Me.dtpFrom.TabIndex = 12
        '
        'txtJobNumber
        '
        Me.txtJobNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJobNumber.Location = New System.Drawing.Point(104, 115)
        Me.txtJobNumber.Name = "txtJobNumber"
        Me.txtJobNumber.Size = New System.Drawing.Size(184, 21)
        Me.txtJobNumber.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(104, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(104, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "From"
        '
        'chkVisitDate
        '
        Me.chkVisitDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkVisitDate.Location = New System.Drawing.Point(8, 136)
        Me.chkVisitDate.Name = "chkVisitDate"
        Me.chkVisitDate.Size = New System.Drawing.Size(80, 24)
        Me.chkVisitDate.TabIndex = 11
        Me.chkVisitDate.Text = "Visit Date"
        Me.chkVisitDate.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Job Number"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Definition"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Site"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.Location = New System.Drawing.Point(296, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Type"
        '
        'cboType
        '
        Me.cboType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Location = New System.Drawing.Point(344, 91)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(184, 21)
        Me.cboType.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Location = New System.Drawing.Point(536, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Status"
        '
        'cboDefinition
        '
        Me.cboDefinition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefinition.Location = New System.Drawing.Point(104, 92)
        Me.cboDefinition.Name = "cboDefinition"
        Me.cboDefinition.Size = New System.Drawing.Size(184, 21)
        Me.cboDefinition.TabIndex = 6
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Location = New System.Drawing.Point(600, 91)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(176, 21)
        Me.cboStatus.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Location = New System.Drawing.Point(536, 118)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 16)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Outcome"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(692, 467)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(96, 23)
        Me.btnPrint.TabIndex = 36
        Me.btnPrint.Text = "Print GSRs"
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(16, 467)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(96, 23)
        Me.btnExport.TabIndex = 37
        Me.btnExport.Text = "Export"
        '
        'FRMBatchGSRPrint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(800, 494)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.grpEngineerVisits)
        Me.Controls.Add(Me.grpFilter)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMBatchGSRPrint"
        Me.Text = "Batch GSR Print"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.Controls.SetChildIndex(Me.grpEngineerVisits, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.grpEngineerVisits.ResumeLayout(False)
        CType(Me.dgVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        Combo.SetUpCombo(Me.cboDefinition, DynamicDataTables.JobDefinitions, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboStatus, DynamicDataTables.VisitStatus_For_Viewing, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        Combo.SetUpCombo(Me.cboOutcome, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter)
        SetupVisitDataGrid()
        PopulateDatagrid()
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

    Private _dvVisits As DataView

    Private Property VisitsDataview() As DataView
        Get
            Return _dvVisits
        End Get
        Set(ByVal value As DataView)
            _dvVisits = value
            _dvVisits.AllowNew = False
            _dvVisits.AllowEdit = False
            _dvVisits.AllowDelete = False
            _dvVisits.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
            Me.dgVisits.DataSource = VisitsDataview
        End Set
    End Property

    Private ReadOnly Property SelectedVisitDataRow() As DataRow
        Get
            If Not Me.dgVisits.CurrentRowIndex = -1 Then
                Return VisitsDataview(Me.dgVisits.CurrentRowIndex).Row
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
            theSite = Nothing
            If Not _theCustomer Is Nothing Then
                Me.txtCustomer.Text = theCustomer.Name & " (A/C No : " & theCustomer.AccountNumber & ")"
                Me.btnFindSite.Enabled = True
            Else
                Me.txtCustomer.Text = ""
                Me.btnFindSite.Enabled = False
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

#End Region

#Region "Setup"

    Private Sub SetupVisitDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgVisits.TableStyles(0)

        Dim tick As New DataGridBoolColumn
        tick.HeaderText = ""
        tick.MappingName = "tick"
        tick.ReadOnly = True
        tick.Width = 25
        tick.NullText = ""
        tbStyle.GridColumnStyles.Add(tick)

        Dim Emailtick As New DataGridBoolColumn
        Emailtick.HeaderText = "Sending Email"
        Emailtick.MappingName = "EmailSend"
        Emailtick.ReadOnly = True
        Emailtick.Width = 75
        Emailtick.NullText = ""
        tbStyle.GridColumnStyles.Add(Emailtick)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 150
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Site As New DataGridLabelColumn
        Site.Format = ""
        Site.FormatInfo = Nothing
        Site.HeaderText = "Site"
        Site.MappingName = "Site"
        Site.ReadOnly = True
        Site.Width = 100
        Site.NullText = ""
        tbStyle.GridColumnStyles.Add(Site)

        Dim Postcode As New DataGridLabelColumn
        Postcode.Format = ""
        Postcode.FormatInfo = Nothing
        Postcode.HeaderText = "Postcode"
        Postcode.MappingName = "SitePostcode"
        Postcode.ReadOnly = True
        Postcode.Width = 75
        Postcode.NullText = ""
        tbStyle.GridColumnStyles.Add(Postcode)

        Dim JobNumber As New DataGridLabelColumn
        JobNumber.Format = ""
        JobNumber.FormatInfo = Nothing
        JobNumber.HeaderText = "Job Number"
        JobNumber.MappingName = "JobNumber"
        JobNumber.ReadOnly = True
        JobNumber.Width = 75
        JobNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(JobNumber)

        Dim PONumber As New DataGridLabelColumn
        PONumber.Format = ""
        PONumber.FormatInfo = Nothing
        PONumber.HeaderText = "PO Number"
        PONumber.MappingName = "PONumber"
        PONumber.ReadOnly = True
        PONumber.Width = 75
        PONumber.NullText = ""
        tbStyle.GridColumnStyles.Add(PONumber)

        Dim JobDefinition As New DataGridLabelColumn
        JobDefinition.Format = ""
        JobDefinition.FormatInfo = Nothing
        JobDefinition.HeaderText = "Definition"
        JobDefinition.MappingName = "JobDefinition"
        JobDefinition.ReadOnly = True
        JobDefinition.Width = 75
        JobDefinition.NullText = ""
        tbStyle.GridColumnStyles.Add(JobDefinition)

        Dim Type As New DataGridLabelColumn
        Type.Format = ""
        Type.FormatInfo = Nothing
        Type.HeaderText = "Type"
        Type.MappingName = "Type"
        Type.ReadOnly = True
        Type.Width = 75
        Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString.Replace("_", " ")
        tbStyle.GridColumnStyles.Add(Type)

        Dim VisitStatus As New DataGridLabelColumn
        VisitStatus.Format = ""
        VisitStatus.FormatInfo = Nothing
        VisitStatus.HeaderText = "Status"
        VisitStatus.MappingName = "VisitStatus"
        VisitStatus.ReadOnly = True
        VisitStatus.Width = 75
        VisitStatus.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitStatus)

        Dim VisitOutcome As New DataGridLabelColumn
        VisitOutcome.Format = ""
        VisitOutcome.FormatInfo = Nothing
        VisitOutcome.HeaderText = "Outcome"
        VisitOutcome.MappingName = "VisitOutcome"
        VisitOutcome.ReadOnly = True
        VisitOutcome.Width = 75
        VisitOutcome.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitOutcome)

        Dim EstimatedVisitDate As New DataGridLabelColumn
        EstimatedVisitDate.Format = "dd/MMM/yyyy"
        EstimatedVisitDate.FormatInfo = Nothing
        EstimatedVisitDate.HeaderText = "Estimated Visit Date"
        EstimatedVisitDate.MappingName = "EstimatedVisitDate"
        EstimatedVisitDate.ReadOnly = True
        EstimatedVisitDate.Width = 100
        EstimatedVisitDate.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(EstimatedVisitDate)

        Dim StartDateTime As New DataGridLabelColumn
        StartDateTime.Format = "dd/MMM/yyyy"
        StartDateTime.FormatInfo = Nothing
        StartDateTime.HeaderText = "Scheduled Date"
        StartDateTime.MappingName = "StartDateTime"
        StartDateTime.ReadOnly = True
        StartDateTime.Width = 100
        StartDateTime.NullText = "Not Set"
        tbStyle.GridColumnStyles.Add(StartDateTime)

        Dim Engineer As New DataGridLabelColumn
        Engineer.Format = ""
        Engineer.FormatInfo = Nothing
        Engineer.HeaderText = "Engineer"
        Engineer.MappingName = "Engineer"
        Engineer.ReadOnly = True
        Engineer.Width = 75
        Engineer.NullText = ""
        tbStyle.GridColumnStyles.Add(Engineer)

        Dim VisitValue As New DataGridLabelColumn
        VisitValue.Format = "C"
        VisitValue.FormatInfo = Nothing
        VisitValue.HeaderText = "Visit Value"
        VisitValue.MappingName = "VisitValue"
        VisitValue.ReadOnly = True
        VisitValue.Width = 75
        VisitValue.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitValue)

        Dim VisitCharge As New DataGridLabelColumn
        VisitCharge.Format = "C"
        VisitCharge.FormatInfo = Nothing
        VisitCharge.HeaderText = "Visit Charge"
        VisitCharge.MappingName = "VisitCharge"
        VisitCharge.ReadOnly = True
        VisitCharge.Width = 200
        VisitCharge.NullText = ""
        tbStyle.GridColumnStyles.Add(VisitCharge)

        Dim EngineerCost As New DataGridLabelColumn
        EngineerCost.Format = "C"
        EngineerCost.FormatInfo = Nothing
        EngineerCost.HeaderText = "Engineer Cost"
        EngineerCost.MappingName = "EngineerCost"
        EngineerCost.ReadOnly = True
        EngineerCost.Width = 100
        EngineerCost.NullText = ""
        tbStyle.GridColumnStyles.Add(EngineerCost)

        Dim PartProductCost As New DataGridLabelColumn
        PartProductCost.Format = "C"
        PartProductCost.FormatInfo = Nothing
        PartProductCost.HeaderText = "Part\Product Cost"
        PartProductCost.MappingName = "PartProductCost"
        PartProductCost.ReadOnly = True
        PartProductCost.Width = 100
        PartProductCost.NullText = ""
        tbStyle.GridColumnStyles.Add(PartProductCost)

        Dim DefectCount As New DataGridLabelColumn
        'DefectCount.Format = "C"
        DefectCount.FormatInfo = Nothing
        DefectCount.HeaderText = "DefectCount"
        DefectCount.MappingName = "DefectCount"
        DefectCount.ReadOnly = True
        DefectCount.Width = 100
        DefectCount.NullText = ""
        tbStyle.GridColumnStyles.Add(DefectCount)

        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString
        Me.dgVisits.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMVisitManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnFindCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCustomer.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblCustomer)
        If Not ID = 0 Then
            theCustomer = DB.Customer.Customer_Get(ID)
        End If
    End Sub

    Private Sub btnFindSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSite.Click
        Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.tblSite, theCustomer.CustomerID)
        If Not ID = 0 Then
            theSite = DB.Sites.Get(ID)
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ResetFilters()
    End Sub

    Private Sub chkVisitDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVisitDate.CheckedChanged
        If Me.chkVisitDate.Checked Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
        Else
            Me.dtpFrom.Value = Today
            Me.dtpTo.Value = Today
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
        End If
    End Sub

    Private Sub btnShowdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowdata.Click
        RunFilter()
    End Sub

    Private Sub dgVisits_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgVisits.MouseUp
        Dim HitTestInfo As DataGrid.HitTestInfo
        HitTestInfo = dgVisits.HitTest(e.X, e.Y)
        If HitTestInfo.Type = DataGrid.HitTestType.Cell Then
            If HitTestInfo.Column = 0 Then
                Dim selected As Boolean = Not Entity.Sys.Helper.MakeBooleanValid(SelectedVisitDataRow.Item("tick"))
                SelectedVisitDataRow.Item("Tick") = selected
            End If
        End If
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        If VisitsDataview IsNot Nothing AndAlso VisitsDataview.Count > 0 Then
            For Each dr As DataRow In VisitsDataview.Table.Rows
                If dr("EmailSend") = 0 Then
                    dr("tick") = True
                End If

            Next dr
        End If
    End Sub

    Private Sub btnUnselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnselect.Click
        If VisitsDataview IsNot Nothing AndAlso VisitsDataview.Count > 0 Then
            For Each dr As DataRow In VisitsDataview.Table.Rows
                dr("tick") = False
            Next dr
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Dim details As New ArrayList
        details.Add(VisitsDataview.Table.Select("Tick= true"))
        details.Add(chkPrintHdr.Checked)
        Dim oPrint As New Entity.Sys.Printing(details, "GSR Batch", Entity.Sys.Enums.SystemDocumentType.GSRBatch, True)
        RunFilter()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim dtExport As New DataTable
        dtExport.Columns.Add("Resident Name")
        dtExport.Columns.Add("Address 1")
        dtExport.Columns.Add("Postcode")
        dtExport.Columns.Add("Sub Area")
        dtExport.Columns.Add("Contact No.")
        dtExport.Columns.Add("PRI Data")
        dtExport.Columns.Add("Works")
        dtExport.Columns.Add("Date Completed")
        dtExport.Columns.Add("Operative")

        Dim nr As DataRow

        For Each dr As DataRow In VisitsDataview.Table.Rows
            If dr("Tick") = True Then
                nr = dtExport.NewRow
                Dim name As String = Entity.Sys.Helper.MakeStringValid(dr("SiteName"))
                If name.Contains("T2") Then
                    name = name.Substring(0, InStr(name, "T2") - 1)
                End If
                name = name.Replace("T1 ", "")
                name = name.Trim

                nr("Resident Name") = name
                nr("Address 1") = Entity.Sys.Helper.MakeStringValid(dr("Address1"))
                nr("Postcode") = Entity.Sys.Helper.MakeStringValid(dr("Postcode"))
                nr("Sub Area") = Entity.Sys.Helper.MakeStringValid(dr("Address2"))
                Dim phoneNum As String = ""
                Dim orginalPhoneNum As String = Entity.Sys.Helper.MakeStringValid(dr("TelephoneNum"))
                For i As Integer = 0 To orginalPhoneNum.Length - 1
                    If IsNumeric(orginalPhoneNum.Chars(i)) Or orginalPhoneNum.Chars(i) = " " Then
                        phoneNum += orginalPhoneNum.Chars(i)
                    End If
                Next

                nr("Contact No.") = "'" + phoneNum
                nr("PRI Data") = Entity.Sys.Helper.MakeStringValid(dr("SiteNotes"))
                nr("Works") = dr("Type")
                nr("Date Completed") = Format(Entity.Sys.Helper.MakeDateTimeValid(dr("StartDateTime")), "dd/MMM/yyyy")
                nr("Operative") = dr("Engineer")

                dtExport.Rows.Add(nr)
            End If
        Next

        Dim exporter As New Entity.Sys.Exporting(dtExport, "Gas Summary Spec")
        exporter = Nothing

    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            ResetFilters()
            If GetParameter(0) Is Nothing Then
            Else
                VisitsDataview = GetParameter(0)
                Me.grpFilter.Enabled = False
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        theCustomer = Nothing

        Combo.SetSelectedComboItem_By_Value(Me.cboDefinition, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboType, 4702)
        Combo.SetSelectedComboItem_By_Value(Me.cboStatus, 0)
        Combo.SetSelectedComboItem_By_Value(Me.cboOutcome, 1)
        Me.txtJobNumber.Text = ""

        Me.txtPostcode.Text = ""
        Me.chkVisitDate.Checked = True

        If Today.DayOfWeek = DayOfWeek.Monday Then
            Me.dtpFrom.Value = Today.AddDays(-1)
            Me.dtpTo.Value = Today.AddDays(-3)
        Else
            Me.dtpFrom.Value = Today.AddDays(-1)
            Me.dtpTo.Value = Today.AddDays(-1)
        End If

        Me.dtpFrom.Enabled = True
        Me.dtpTo.Enabled = True

        Me.grpFilter.Enabled = True
    End Sub

    Private Sub RunFilter()
        Dim whereClause As String = "AND tblEngineerVisit.Deleted = 0 "

        If Not theCustomer Is Nothing Then
            whereClause += " AND tblCustomer.CustomerID = " & theCustomer.CustomerID & ""
        End If
        If Not theSite Is Nothing Then
            whereClause += " AND tblSite.SiteID = " & theSite.SiteID & ""
        End If
        If Not Combo.GetSelectedItemValue(Me.cboDefinition) = 0 Then
            whereClause += " AND JobDefinitionEnumID = " & Combo.GetSelectedItemValue(Me.cboDefinition) & ""
        End If
        If Not Combo.GetSelectedItemValue(Me.cboType) = 0 Then
            whereClause += " AND JobTypeID = " & Combo.GetSelectedItemValue(Me.cboType) & ""
        End If
        If Not Combo.GetSelectedItemValue(Me.cboStatus) = 0 Then
            whereClause += " AND (CASE ISNULL(tblEngineerVisitCharge.InvoiceReadyID, 0) " &
           "  WHEN 0 THEN tblEngineerVisit.StatusEnumID " &
           "  WHEN 1 THEN tblEngineerVisit.StatusEnumID " &
           "  WHEN 2 THEN  " &
                    " CASE  " &
                    " WHEN ISNULL(tblInvoicedLines.InvoicedLineID, 0)>1 THEN 8 " &
                    " ELSE 7 " &
                    "   End " &
            " WHEN 3 THEN 6 " &
            "  End) = " & Combo.GetSelectedItemValue(Me.cboStatus)
        End If
        If Not Me.txtJobNumber.Text.Trim.Length = 0 Then
            whereClause += " AND JobNumber LIKE '" & Me.txtJobNumber.Text.Trim & "%'"
        End If

        If Me.chkVisitDate.Checked Then
            whereClause += " AND StartDateTime >= '" & Format(Me.dtpFrom.Value, "dd/MMM/yyyy 00:00:00") & "' AND StartDateTime <= '" & Format(Me.dtpTo.Value, "dd/MMM/yyyy 23:59:59") & "'"
        End If
        If Not Me.txtPostcode.Text.Trim.Length = 0 Then
            whereClause += " AND tblSite.Postcode LIKE '" & Me.txtPostcode.Text.Trim & "%'"
        End If

        If Not Combo.GetSelectedItemValue(Me.cboOutcome) = 0 Then
            whereClause += " AND OutcomeEnumID = " & Combo.GetSelectedItemValue(Me.cboOutcome) & ""
        End If

        If Me.chkExceptionsOnly.Checked Then
            whereClause += " AND DefectCount > 0"
        End If

        VisitsDataview = DB.EngineerVisits.EngineerVisits_Get_All(whereClause)
        Me.grpEngineerVisits.Text = "Double Click To View / Edit - Visits: " & VisitsDataview.Table.Rows.Count
    End Sub

    Public Sub Export()

        Dim exportData As New DataTable
        exportData.Columns.Add("Customer")
        exportData.Columns.Add("Site")
        exportData.Columns.Add("SitePostcode")
        exportData.Columns.Add("JobNumber")
        exportData.Columns.Add("PONumber")
        exportData.Columns.Add("JobDefinition")
        exportData.Columns.Add("Type")
        exportData.Columns.Add("VisitStatus")
        exportData.Columns.Add("StartDateTime")
        exportData.Columns.Add("Engineer")
        exportData.Columns.Add("VisitValue", GetType(Double))
        exportData.Columns.Add("VisitCharge")
        exportData.Columns.Add("EngineerCost", GetType(Double))
        exportData.Columns.Add("PartProductCost", GetType(Double))

        For itm As Integer = 0 To CType(dgVisits.DataSource, DataView).Count - 1
            dgVisits.CurrentRowIndex = itm

            Dim newRw As DataRow
            newRw = exportData.NewRow

            newRw("Customer") = SelectedVisitDataRow("Customer")
            newRw("Site") = SelectedVisitDataRow("Site")
            newRw("SitePostcode") = SelectedVisitDataRow("SitePostcode")
            newRw("JobNumber") = SelectedVisitDataRow("JobNumber")
            newRw("PONumber") = SelectedVisitDataRow("PONumber")
            newRw("JobDefinition") = SelectedVisitDataRow("JobDefinition")
            newRw("Type") = SelectedVisitDataRow("Type")
            newRw("VisitStatus") = SelectedVisitDataRow("VisitStatus")
            newRw("StartDateTime") = SelectedVisitDataRow("StartDateTime")
            newRw("Engineer") = SelectedVisitDataRow("Engineer")
            newRw("VisitValue") = SelectedVisitDataRow("VisitValue")
            newRw("VisitCharge") = SelectedVisitDataRow("VisitCharge")
            newRw("EngineerCost") = SelectedVisitDataRow("EngineerCost")
            newRw("PartProductCost") = SelectedVisitDataRow("PartProductCost")

            exportData.Rows.Add(newRw)

            dgVisits.UnSelect(itm)
        Next itm

    End Sub

    Private Sub dgVisits_DoubleClick(sender As Object, e As EventArgs) Handles dgVisits.DoubleClick
        ShowForm(GetType(FRMEngineerVisit), True, New Object() {SelectedVisitDataRow.Item("EngineerVisitID")})
    End Sub

#End Region

End Class