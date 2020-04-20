Public Class FRMDirectDebitReport : Inherits FSM.FRMBaseForm : Implements IForm

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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgDirectDebits As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpJobs = New System.Windows.Forms.GroupBox
        Me.dgDirectDebits = New System.Windows.Forms.DataGrid
        Me.btnExport = New System.Windows.Forms.Button
        Me.grpFilter = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnReset = New System.Windows.Forms.Button
        Me.grpJobs.SuspendLayout()
        CType(Me.dgDirectDebits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpJobs
        '
        Me.grpJobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpJobs.Controls.Add(Me.dgDirectDebits)
        Me.grpJobs.Location = New System.Drawing.Point(8, 88)
        Me.grpJobs.Name = "grpJobs"
        Me.grpJobs.Size = New System.Drawing.Size(784, 368)
        Me.grpJobs.TabIndex = 1
        Me.grpJobs.TabStop = False
        Me.grpJobs.Text = "Results"
        '
        'dgDirectDebits
        '
        Me.dgDirectDebits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDirectDebits.DataMember = ""
        Me.dgDirectDebits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDirectDebits.Location = New System.Drawing.Point(8, 21)
        Me.dgDirectDebits.Name = "dgDirectDebits"
        Me.dgDirectDebits.Size = New System.Drawing.Size(768, 339)
        Me.dgDirectDebits.TabIndex = 0
        '
        'btnExport
        '
        Me.btnExport.AccessibleDescription = "Export Job List To Excel"
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(8, 464)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export"
        '
        'grpFilter
        '
        Me.grpFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.dtpTo)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.Label9)
        Me.grpFilter.Controls.Add(Me.Label8)
        Me.grpFilter.Location = New System.Drawing.Point(8, 32)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(784, 56)
        Me.grpFilter.TabIndex = 0
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "Filter"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Invoice Raise Date"
        '
        'dtpTo
        '
        Me.dtpTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTo.Location = New System.Drawing.Point(488, 24)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(248, 21)
        Me.dtpTo.TabIndex = 4
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(176, 24)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(248, 21)
        Me.dtpFrom.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(440, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "To"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(136, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "From"
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Location = New System.Drawing.Point(72, 464)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 23)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        '
        'FRMDirectDebitReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(800, 494)
        Me.Controls.Add(Me.grpFilter)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.grpJobs)
        Me.Controls.Add(Me.btnReset)
        Me.MinimumSize = New System.Drawing.Size(808, 528)
        Me.Name = "FRMDirectDebitReport"
        Me.Text = "Direct Debits Due"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.grpJobs, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.grpFilter, 0)
        Me.grpJobs.ResumeLayout(False)
        CType(Me.dgDirectDebits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

        SetupDirectDebitsDataGrid()
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

    Private _dvDD As DataView
    Private Property dvDD() As DataView
        Get
            Return _dvDD
        End Get
        Set(ByVal value As DataView)
            _dvDD = value
            _dvDD.AllowNew = False
            _dvDD.AllowEdit = False
            _dvDD.AllowDelete = False
            _dvDD.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString
            Me.dgDirectDebits.DataSource = dvDD
        End Set
    End Property

    Private ReadOnly Property SelectedDirectDebitDataRow() As DataRow
        Get
            If Not Me.dgDirectDebits.CurrentRowIndex = -1 Then
                Return dvDD(Me.dgDirectDebits.CurrentRowIndex).Row
            Else
                Return Nothing
            End If
        End Get
    End Property

#End Region

#Region "Setup"

    Private Sub SetupDirectDebitsDataGrid()
        Dim tbStyle As DataGridTableStyle = Me.dgDirectDebits.TableStyles(0)


        Dim ContractReference As New DataGridLabelColumn
        ContractReference.Format = ""
        ContractReference.FormatInfo = Nothing
        ContractReference.HeaderText = "Contract Ref"
        ContractReference.MappingName = "ContractReference"
        ContractReference.ReadOnly = True
        ContractReference.Width = 100
        ContractReference.NullText = ""
        tbStyle.GridColumnStyles.Add(ContractReference)

        Dim RaiseDate As New DataGridLabelColumn
        RaiseDate.Format = "dd/MMM/yyyy"
        RaiseDate.FormatInfo = Nothing
        RaiseDate.HeaderText = "Raise Date"
        RaiseDate.MappingName = "RaiseDate"
        RaiseDate.ReadOnly = True
        RaiseDate.Width = 100
        RaiseDate.NullText = ""
        tbStyle.GridColumnStyles.Add(RaiseDate)

        Dim Customer As New DataGridLabelColumn
        Customer.Format = ""
        Customer.FormatInfo = Nothing
        Customer.HeaderText = "Customer"
        Customer.MappingName = "Customer"
        Customer.ReadOnly = True
        Customer.Width = 200
        Customer.NullText = ""
        tbStyle.GridColumnStyles.Add(Customer)

        Dim Amount As New DataGridLabelColumn
        Amount.Format = "C"
        Amount.FormatInfo = Nothing
        Amount.HeaderText = "Amount"
        Amount.MappingName = "Amount"
        Amount.ReadOnly = True
        Amount.Width = 75
        Amount.NullText = ""
        tbStyle.GridColumnStyles.Add(Amount)

        Dim BankName As New DataGridLabelColumn
        BankName.Format = ""
        BankName.FormatInfo = Nothing
        BankName.HeaderText = "Bank Name"
        BankName.MappingName = "BankName"
        BankName.ReadOnly = True
        BankName.Width = 100
        BankName.NullText = ""
        tbStyle.GridColumnStyles.Add(BankName)

        Dim SortCode As New DataGridLabelColumn
        SortCode.Format = ""
        SortCode.FormatInfo = Nothing
        SortCode.HeaderText = "Sort Code"
        SortCode.MappingName = "SortCode"
        SortCode.ReadOnly = True
        SortCode.Width = 100
        SortCode.NullText = ""
        tbStyle.GridColumnStyles.Add(SortCode)

        Dim AccountNumber As New DataGridLabelColumn
        AccountNumber.Format = ""
        AccountNumber.FormatInfo = Nothing
        AccountNumber.HeaderText = "Account Number"
        AccountNumber.MappingName = "AccountNumber"
        AccountNumber.ReadOnly = True
        AccountNumber.Width = 100
        AccountNumber.NullText = ""
        tbStyle.GridColumnStyles.Add(AccountNumber)



        tbStyle.ReadOnly = True
        tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString

        Me.dgDirectDebits.TableStyles.Add(tbStyle)
    End Sub

#End Region

#Region "Events"

    Private Sub FRMJobManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetFilters()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        RunFilter()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        RunFilter()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Export()
    End Sub

#End Region

#Region "Functions"

    Public Sub PopulateDatagrid()
        Try
            ResetFilters()
            If GetParameter(0) Is Nothing Then
                ResetFilters()
            Else
                dvDD = GetParameter(0)
                Me.grpFilter.Enabled = False
            End If
        Catch ex As Exception
            ShowMessage("Form cannot setup : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetFilters()
        Me.dtpFrom.Value = Now
        Me.dtpTo.Value = Now.AddDays(7)
        Me.grpFilter.Enabled = True
    End Sub

    Private Sub RunFilter()
        dvDD = DB.InvoiceToBeRaised.Invoices_GetAll_ForDirectDebitRpt(dtpFrom.Value, dtpTo.Value)
    End Sub

    Public Sub Export()

        Dim exporter As New Entity.Sys.Exporting(dvDD.Table, "Direct Debit List")
        exporter = Nothing
    End Sub

#End Region

End Class
