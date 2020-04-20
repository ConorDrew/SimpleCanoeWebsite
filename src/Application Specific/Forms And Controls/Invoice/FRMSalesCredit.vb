Public Class FRMSalesCredit : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    '("InvoicedID")
    Public Sub New(ByVal IDToLinkToIn As DataRow(), Optional ByVal FromQuoteJobIn As Boolean = False, Optional ByVal FromJobIn As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        FromQuoteJob = FromQuoteJobIn
        FromJob = FromJobIn
        IDToLinkTo = IDToLinkToIn
        Combo.SetUpCombo(Me.cboUser, DB.User.GetAll.Table, "UserID", "Fullname", Entity.Sys.Enums.ComboValues.No_Filter)

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
    Friend WithEvents grpSystemScheduleOfRate As System.Windows.Forms.GroupBox

    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents txtAfter As System.Windows.Forms.TextBox
    Friend WithEvents txtCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiced As System.Windows.Forms.TextBox
    Friend WithEvents txtExRef As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgRates As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNominal As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpSystemScheduleOfRate = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dgRates = New System.Windows.Forms.DataGridView()
        Me.txtAfter = New System.Windows.Forms.TextBox()
        Me.txtCredit = New System.Windows.Forms.TextBox()
        Me.txtInvoiced = New System.Windows.Forms.TextBox()
        Me.txtExRef = New System.Windows.Forms.TextBox()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNominal = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDept = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpSystemScheduleOfRate.SuspendLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSystemScheduleOfRate
        '
        Me.grpSystemScheduleOfRate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtDept)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label9)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtNominal)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label8)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label7)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.DateTimePicker1)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.dgRates)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtAfter)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtCredit)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtInvoiced)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtExRef)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.cboUser)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label1)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.txtReason)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnCancel)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.btnAdd)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label3)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label2)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label5)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label4)
        Me.grpSystemScheduleOfRate.Controls.Add(Me.Label6)
        Me.grpSystemScheduleOfRate.Location = New System.Drawing.Point(8, 32)
        Me.grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate"
        Me.grpSystemScheduleOfRate.Size = New System.Drawing.Size(632, 432)
        Me.grpSystemScheduleOfRate.TabIndex = 2
        Me.grpSystemScheduleOfRate.TabStop = False
        Me.grpSystemScheduleOfRate.Text = "Credit Details"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 287)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Date of Credit"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(9, 303)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(324, 21)
        Me.DateTimePicker1.TabIndex = 48
        '
        'dgRates
        '
        Me.dgRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRates.Location = New System.Drawing.Point(6, 20)
        Me.dgRates.Name = "dgRates"
        Me.dgRates.Size = New System.Drawing.Size(620, 170)
        Me.dgRates.TabIndex = 47
        '
        'txtAfter
        '
        Me.txtAfter.Location = New System.Drawing.Point(495, 306)
        Me.txtAfter.Name = "txtAfter"
        Me.txtAfter.ReadOnly = True
        Me.txtAfter.Size = New System.Drawing.Size(112, 21)
        Me.txtAfter.TabIndex = 45
        '
        'txtCredit
        '
        Me.txtCredit.Location = New System.Drawing.Point(495, 262)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.ReadOnly = True
        Me.txtCredit.Size = New System.Drawing.Size(112, 21)
        Me.txtCredit.TabIndex = 43
        '
        'txtInvoiced
        '
        Me.txtInvoiced.Location = New System.Drawing.Point(495, 221)
        Me.txtInvoiced.Name = "txtInvoiced"
        Me.txtInvoiced.ReadOnly = True
        Me.txtInvoiced.Size = New System.Drawing.Size(112, 21)
        Me.txtInvoiced.TabIndex = 41
        '
        'txtExRef
        '
        Me.txtExRef.Location = New System.Drawing.Point(233, 262)
        Me.txtExRef.Name = "txtExRef"
        Me.txtExRef.Size = New System.Drawing.Size(100, 21)
        Me.txtExRef.TabIndex = 39
        '
        'cboUser
        '
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Location = New System.Drawing.Point(9, 221)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(324, 21)
        Me.cboUser.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Reason For Credit"
        '
        'txtReason
        '
        Me.txtReason.Location = New System.Drawing.Point(8, 350)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(611, 40)
        Me.txtReason.TabIndex = 35
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(8, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 34
        Me.btnCancel.Text = "Cancel"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(518, 400)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(101, 23)
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "Create Credit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Ex Ref"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Requested By"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(505, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Total Credited"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(479, 203)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Total Originally Invoiced"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(474, 287)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Total Invoice after Credit"
        '
        'txtNominal
        '
        Me.txtNominal.Location = New System.Drawing.Point(9, 263)
        Me.txtNominal.Name = "txtNominal"
        Me.txtNominal.Size = New System.Drawing.Size(100, 21)
        Me.txtNominal.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 247)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Nominal"
        '
        'txtDept
        '
        Me.txtDept.Location = New System.Drawing.Point(121, 263)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.Size = New System.Drawing.Size(100, 21)
        Me.txtDept.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(119, 247)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Dept"
        '
        'FRMSalesCredit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(648, 470)
        Me.Controls.Add(Me.grpSystemScheduleOfRate)
        Me.MinimumSize = New System.Drawing.Size(656, 504)
        Me.Name = "FRMSalesCredit"
        Me.Text = "Property Schedule Of Rates List"
        Me.Controls.SetChildIndex(Me.grpSystemScheduleOfRate, 0)
        Me.grpSystemScheduleOfRate.ResumeLayout(False)
        Me.grpSystemScheduleOfRate.PerformLayout()
        CType(Me.dgRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        SetupRatesDataGrid()
        Populate()
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get

        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe

    End Sub

#End Region

#Region "Properties"

    Private _fromQuoteJob As Boolean

    Public Property FromQuoteJob() As Boolean
        Get
            Return _fromQuoteJob
        End Get
        Set(ByVal Value As Boolean)
            _fromQuoteJob = Value
        End Set
    End Property

    Private _fromJob As Boolean

    Public Property FromJob() As Boolean
        Get
            Return _fromJob
        End Get
        Set(ByVal Value As Boolean)
            _fromJob = Value
        End Set
    End Property

    Private _DataViewToLinkTo As DataView

    Public Property DataviewToLinkTo() As DataView
        Get
            Return _DataViewToLinkTo
        End Get
        Set(ByVal Value As DataView)
            _DataViewToLinkTo = Value
        End Set
    End Property

    Private _IDToLinkTo As DataRow() = Nothing

    Public Property IDToLinkTo As DataRow()
        Get
            Return _IDToLinkTo
        End Get
        Set(ByVal Value As DataRow())
            _IDToLinkTo = Value
        End Set
    End Property

    Private _dvRates As DataView

    Public Property RatesDataview() As DataView
        Get
            Return _dvRates
        End Get
        Set(ByVal value As DataView)
            _dvRates = value
            _dvRates.AllowNew = False
            _dvRates.AllowEdit = True
            _dvRates.AllowDelete = False
            _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
            Me.dgRates.DataSource = RatesDataview
        End Set
    End Property

    Private ReadOnly Property SelectedRatesDataRow() As DataGridViewRow
        Get
            If Not Me.dgRates.CurrentRow.Index = -1 Then
                Return Me.dgRates.CurrentRow
            Else
                Return Nothing
            End If

        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub SetupRatesDataGrid()
        Entity.Sys.Helper.SetUpDataGridView(Me.dgRates)
        dgRates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgRates.AutoGenerateColumns = False
        dgRates.Columns.Clear()
        dgRates.EditMode = DataGridViewEditMode.EditOnEnter

        Dim PartName As New DataGridViewTextBoxColumn
        PartName.FillWeight = 300
        PartName.HeaderText = "Address"
        PartName.DataPropertyName = "Address"
        PartName.ReadOnly = True
        PartName.Visible = True
        PartName.SortMode = DataGridViewColumnSortMode.Programmatic
        dgRates.Columns.Add(PartName)

        Dim PONetValue As New DataGridViewTextBoxColumn
        PONetValue.HeaderText = "Invoiced (Nett)"
        PONetValue.DataPropertyName = "Amount"
        'TotalUnitPrice.FillWeight = 10
        PONetValue.ReadOnly = True
        PONetValue.Visible = True
        PONetValue.Width = 100
        PONetValue.SortMode = DataGridViewColumnSortMode.Programmatic
        dgRates.Columns.Add(PONetValue)

        Dim creditApplied As New DataGridViewTextBoxColumn
        creditApplied.HeaderText = "Credit Applied (Nett)"
        creditApplied.DataPropertyName = "CreditApplied"
        'TotalUnitPrice.FillWeight = 10
        creditApplied.ReadOnly = True
        creditApplied.Visible = True
        creditApplied.Width = 100
        creditApplied.SortMode = DataGridViewColumnSortMode.Programmatic
        dgRates.Columns.Add(creditApplied)

        Dim PONetValue2 As New DataGridViewTextBoxColumn
        PONetValue2.HeaderText = "Credit Amount (Nett)"
        PONetValue2.DataPropertyName = "Credit"
        'TotalUnitPrice.FillWeight = 10
        PONetValue2.ReadOnly = False
        PONetValue2.Visible = True
        PONetValue2.Width = 100
        PONetValue2.SortMode = DataGridViewColumnSortMode.Programmatic
        dgRates.Columns.Add(PONetValue2)

    End Sub

#End Region

#Region "Events"

    Private Sub FRMSystemScheduleOfRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Add() Then
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        Else
            ShowMessage("Please ensure the credit value is greater than zero and equal or less to the original invoice value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnAdd.Enabled = True
        End If
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        RatesDataview = DB.SalesCredit.InvoicedLines_GetAll_ByInvoicedIDRows(IDToLinkTo)
        RatesDataview.Table.Columns.Add("SalesCreditID")
        RatesDataview.Table.Columns.Add("CreditReference")
        txtNominal.Text = RatesDataview.Table.Rows(0)("NominalCode")
        txtDept.Text = RatesDataview.Table.Rows(0)("Department")
    End Sub

    Private Function Add() As Boolean
        btnAdd.Enabled = False
        Dim raise As Boolean = False ' work out if we need to raise doc
        Dim jobnum As JobNumber = DB.Job.GetNextJobNumber(103)
        If txtAfter.Text.Trim.Length = 0 Then Return False
        Dim totalAfterCredit As Double = Entity.Sys.Helper.MakeDoubleValid(txtAfter.Text.Trim)
        For Each dr As DataRow In RatesDataview.Table.Rows
            If dr("Credit") > 0 AndAlso totalAfterCredit >= 0 Then
                raise = True ' yup
                Dim oSalesCredit As New Entity.SalesCredits.SalesCredit
                DB.ExecuteScalar("INSERT INTO tblInvoicedLinesCredit (InvoicedLineID,CreditAmount) VALUES (" & dr("InvoicedLineID") & "," & dr("Credit") & ")")
                Dim oInvoice As Entity.Invoiceds.Invoiced = DB.Invoiced.Invoiced_Get(dr("InvoicedID"))

                Dim oCredit As New Entity.SalesCredits.SalesCredit

                oCredit.SetAmountCredited = dr("Credit")     ' CDbl(txtCredit.Text)
                oCredit.SetNotes = ""
                oCredit.SetTaxCodeID = oInvoice.VATRateID
                oCredit.SetExtraRef = txtExRef.Text
                If IsDBNull(dr("NominalCode")) OrElse dr("NominalCode").ToString.Length = 0 Then
                    oCredit.SetNominalCode = 4900
                    oCredit.SetDepartmentRef = 100
                Else
                    oCredit.SetNominalCode = dr("NominalCode")
                    oCredit.SetDepartmentRef = dr("Department")
                End If

                oCredit.SetNominalCode = txtNominal.Text
                oCredit.SetDepartmentRef = txtDept.Text

                oCredit.SetInvoicedLineID = dr("InvoicedLineID")
                oCredit.SetAddedByUser = loggedInUser.UserID
                oCredit.SetRequestedBy = Combo.GetSelectedItemValue(cboUser)
                oCredit.SetReasonForCredit = txtReason.Text

                oCredit.SetCreditReference = jobnum.Prefix & jobnum.JobNumber

                oCredit.SetAccountNumber = dr("AccountNumber")
                oCredit.DateCredited = DateTimePicker1.Value

                dr("SalesCreditID") = DB.SalesCredit.Insert(oCredit)
                dr("CreditReference") = jobnum.Prefix & jobnum.JobNumber

            End If
        Next
        If raise Then ' and raise
            If ShowMessage("Do you want to generate the document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim oPrint As New Entity.Sys.Printing(RatesDataview.Table, "Sales Credit", Entity.Sys.Enums.SystemDocumentType.SalesCredit)
            End If
        End If

        Return raise ' so we can throw an error message

    End Function

    Private Sub dgvParts_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgRates.CellEndEdit
        If SelectedRatesDataRow Is Nothing Then
            Exit Sub
        End If

        'update the min max record

        DoTotals()

    End Sub

    Private Sub DoTotals()
        txtCredit.Text = 0
        txtInvoiced.Text = 0
        Dim creditApplied As Double = 0.0
        For Each dr As DataGridViewRow In dgRates.Rows
            txtInvoiced.Text += dr.Cells.Item(1).Value
            txtCredit.Text += dr.Cells.Item(3).Value
            creditApplied = Entity.Sys.Helper.MakeDoubleValid(dr.Cells.Item(2).Value)
        Next

        Dim creditTotal As Double = creditApplied + Entity.Sys.Helper.MakeDoubleValid(txtCredit.Text)

        txtAfter.Text = "£" & (txtInvoiced.Text - creditTotal)
        txtCredit.Text = "£" & txtCredit.Text
        txtInvoiced.Text = "£" & txtInvoiced.Text

    End Sub

#End Region

    Private Sub grpSystemScheduleOfRate_Enter(sender As Object, e As EventArgs) Handles grpSystemScheduleOfRate.Enter

    End Sub

End Class