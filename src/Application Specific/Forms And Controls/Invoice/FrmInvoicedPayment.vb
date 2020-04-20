Public Class FrmInvoicedPayment : Inherits FSM.FRMBaseForm : Implements IForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Combo.SetUpCombo(Me.cboPaymentTerm, DB.Picklists.GetAll(65).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPaidBy, DB.Picklists.GetAll(66).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
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

    Friend WithEvents gpbPayment As System.Windows.Forms.GroupBox
    Friend WithEvents btnPay As System.Windows.Forms.Button
    Friend WithEvents gpbInvoiceInformation As System.Windows.Forms.GroupBox
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceAddress As System.Windows.Forms.Label
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtInvAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtInvNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblInvoiceTotal As System.Windows.Forms.Label
    Friend WithEvents lblInvoice As System.Windows.Forms.Label
    Friend WithEvents txtRaisedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtRaisedDate As System.Windows.Forms.TextBox
    Friend WithEvents lblRaisedBy As System.Windows.Forms.Label
    Friend WithEvents cboPaidBy As ComboBox
    Friend WithEvents lblPaidBy As Label
    Friend WithEvents cboPaymentTerm As ComboBox
    Friend WithEvents lblPaymentTerm As Label
    Friend WithEvents lblAccountNumber As Label
    Friend WithEvents txtAccountNumber As TextBox
    Friend WithEvents lblRaisedDate As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.gpbPayment = New System.Windows.Forms.GroupBox()
        Me.lblAccountNumber = New System.Windows.Forms.Label()
        Me.txtAccountNumber = New System.Windows.Forms.TextBox()
        Me.cboPaidBy = New System.Windows.Forms.ComboBox()
        Me.lblPaidBy = New System.Windows.Forms.Label()
        Me.cboPaymentTerm = New System.Windows.Forms.ComboBox()
        Me.lblPaymentTerm = New System.Windows.Forms.Label()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.gpbInvoiceInformation = New System.Windows.Forms.GroupBox()
        Me.txtRaisedBy = New System.Windows.Forms.TextBox()
        Me.txtRaisedDate = New System.Windows.Forms.TextBox()
        Me.lblRaisedBy = New System.Windows.Forms.Label()
        Me.lblRaisedDate = New System.Windows.Forms.Label()
        Me.txtInvAmount = New System.Windows.Forms.TextBox()
        Me.txtInvNumber = New System.Windows.Forms.TextBox()
        Me.lblInvoiceTotal = New System.Windows.Forms.Label()
        Me.lblInvoice = New System.Windows.Forms.Label()
        Me.txtInvoiceAddress = New System.Windows.Forms.TextBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.lblInvoiceAddress = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        Me.gpbPayment.SuspendLayout()
        Me.gpbInvoiceInformation.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbPayment
        '
        Me.gpbPayment.Controls.Add(Me.lblAccountNumber)
        Me.gpbPayment.Controls.Add(Me.txtAccountNumber)
        Me.gpbPayment.Controls.Add(Me.cboPaidBy)
        Me.gpbPayment.Controls.Add(Me.lblPaidBy)
        Me.gpbPayment.Controls.Add(Me.cboPaymentTerm)
        Me.gpbPayment.Controls.Add(Me.lblPaymentTerm)
        Me.gpbPayment.Controls.Add(Me.btnPay)
        Me.gpbPayment.Location = New System.Drawing.Point(8, 170)
        Me.gpbPayment.Name = "gpbPayment"
        Me.gpbPayment.Size = New System.Drawing.Size(436, 153)
        Me.gpbPayment.TabIndex = 1
        Me.gpbPayment.TabStop = False
        Me.gpbPayment.Text = "Payment"
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.Location = New System.Drawing.Point(8, 84)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Size = New System.Drawing.Size(136, 23)
        Me.lblAccountNumber.TabIndex = 16
        Me.lblAccountNumber.Text = "Account Number"
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.Location = New System.Drawing.Point(145, 81)
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(279, 21)
        Me.txtAccountNumber.TabIndex = 15
        '
        'cboPaidBy
        '
        Me.cboPaidBy.FormattingEnabled = True
        Me.cboPaidBy.Location = New System.Drawing.Point(145, 54)
        Me.cboPaidBy.Name = "cboPaidBy"
        Me.cboPaidBy.Size = New System.Drawing.Size(279, 21)
        Me.cboPaidBy.TabIndex = 14
        '
        'lblPaidBy
        '
        Me.lblPaidBy.AutoSize = True
        Me.lblPaidBy.Location = New System.Drawing.Point(9, 54)
        Me.lblPaidBy.Name = "lblPaidBy"
        Me.lblPaidBy.Size = New System.Drawing.Size(50, 13)
        Me.lblPaidBy.TabIndex = 13
        Me.lblPaidBy.Text = "Paid By"
        '
        'cboPaymentTerm
        '
        Me.cboPaymentTerm.FormattingEnabled = True
        Me.cboPaymentTerm.Location = New System.Drawing.Point(145, 24)
        Me.cboPaymentTerm.Name = "cboPaymentTerm"
        Me.cboPaymentTerm.Size = New System.Drawing.Size(279, 21)
        Me.cboPaymentTerm.TabIndex = 12
        '
        'lblPaymentTerm
        '
        Me.lblPaymentTerm.AutoSize = True
        Me.lblPaymentTerm.Location = New System.Drawing.Point(8, 24)
        Me.lblPaymentTerm.Name = "lblPaymentTerm"
        Me.lblPaymentTerm.Size = New System.Drawing.Size(90, 13)
        Me.lblPaymentTerm.TabIndex = 11
        Me.lblPaymentTerm.Text = "Payment Term"
        '
        'btnPay
        '
        Me.btnPay.Location = New System.Drawing.Point(349, 114)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(75, 23)
        Me.btnPay.TabIndex = 6
        Me.btnPay.Text = "Pay"
        '
        'gpbInvoiceInformation
        '
        Me.gpbInvoiceInformation.Controls.Add(Me.txtRaisedBy)
        Me.gpbInvoiceInformation.Controls.Add(Me.txtRaisedDate)
        Me.gpbInvoiceInformation.Controls.Add(Me.lblRaisedBy)
        Me.gpbInvoiceInformation.Controls.Add(Me.lblRaisedDate)
        Me.gpbInvoiceInformation.Controls.Add(Me.txtInvAmount)
        Me.gpbInvoiceInformation.Controls.Add(Me.txtInvNumber)
        Me.gpbInvoiceInformation.Controls.Add(Me.lblInvoiceTotal)
        Me.gpbInvoiceInformation.Controls.Add(Me.lblInvoice)
        Me.gpbInvoiceInformation.Controls.Add(Me.txtInvoiceAddress)
        Me.gpbInvoiceInformation.Controls.Add(Me.txtCustomer)
        Me.gpbInvoiceInformation.Controls.Add(Me.lblInvoiceAddress)
        Me.gpbInvoiceInformation.Controls.Add(Me.lblCustomer)
        Me.gpbInvoiceInformation.Location = New System.Drawing.Point(8, 32)
        Me.gpbInvoiceInformation.Name = "gpbInvoiceInformation"
        Me.gpbInvoiceInformation.Size = New System.Drawing.Size(436, 132)
        Me.gpbInvoiceInformation.TabIndex = 2
        Me.gpbInvoiceInformation.TabStop = False
        Me.gpbInvoiceInformation.Text = "Invoice Information"
        '
        'txtRaisedBy
        '
        Me.txtRaisedBy.Location = New System.Drawing.Point(312, 94)
        Me.txtRaisedBy.Name = "txtRaisedBy"
        Me.txtRaisedBy.ReadOnly = True
        Me.txtRaisedBy.Size = New System.Drawing.Size(112, 21)
        Me.txtRaisedBy.TabIndex = 11
        '
        'txtRaisedDate
        '
        Me.txtRaisedDate.Location = New System.Drawing.Point(312, 70)
        Me.txtRaisedDate.Name = "txtRaisedDate"
        Me.txtRaisedDate.ReadOnly = True
        Me.txtRaisedDate.Size = New System.Drawing.Size(112, 21)
        Me.txtRaisedDate.TabIndex = 10
        '
        'lblRaisedBy
        '
        Me.lblRaisedBy.Location = New System.Drawing.Point(232, 94)
        Me.lblRaisedBy.Name = "lblRaisedBy"
        Me.lblRaisedBy.Size = New System.Drawing.Size(80, 23)
        Me.lblRaisedBy.TabIndex = 9
        Me.lblRaisedBy.Text = "Raised By"
        '
        'lblRaisedDate
        '
        Me.lblRaisedDate.Location = New System.Drawing.Point(232, 70)
        Me.lblRaisedDate.Name = "lblRaisedDate"
        Me.lblRaisedDate.Size = New System.Drawing.Size(80, 23)
        Me.lblRaisedDate.TabIndex = 8
        Me.lblRaisedDate.Text = "Raised Date"
        '
        'txtInvAmount
        '
        Me.txtInvAmount.Location = New System.Drawing.Point(112, 94)
        Me.txtInvAmount.Name = "txtInvAmount"
        Me.txtInvAmount.ReadOnly = True
        Me.txtInvAmount.Size = New System.Drawing.Size(112, 21)
        Me.txtInvAmount.TabIndex = 7
        '
        'txtInvNumber
        '
        Me.txtInvNumber.Location = New System.Drawing.Point(112, 70)
        Me.txtInvNumber.Name = "txtInvNumber"
        Me.txtInvNumber.ReadOnly = True
        Me.txtInvNumber.Size = New System.Drawing.Size(112, 21)
        Me.txtInvNumber.TabIndex = 6
        '
        'lblInvoiceTotal
        '
        Me.lblInvoiceTotal.Location = New System.Drawing.Point(8, 94)
        Me.lblInvoiceTotal.Name = "lblInvoiceTotal"
        Me.lblInvoiceTotal.Size = New System.Drawing.Size(96, 23)
        Me.lblInvoiceTotal.TabIndex = 5
        Me.lblInvoiceTotal.Text = "Invoice Total"
        '
        'lblInvoice
        '
        Me.lblInvoice.Location = New System.Drawing.Point(8, 70)
        Me.lblInvoice.Name = "lblInvoice"
        Me.lblInvoice.Size = New System.Drawing.Size(101, 23)
        Me.lblInvoice.TabIndex = 4
        Me.lblInvoice.Text = "Invoice Number"
        '
        'txtInvoiceAddress
        '
        Me.txtInvoiceAddress.Location = New System.Drawing.Point(112, 40)
        Me.txtInvoiceAddress.Name = "txtInvoiceAddress"
        Me.txtInvoiceAddress.ReadOnly = True
        Me.txtInvoiceAddress.Size = New System.Drawing.Size(312, 21)
        Me.txtInvoiceAddress.TabIndex = 3
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(112, 16)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(312, 21)
        Me.txtCustomer.TabIndex = 2
        '
        'lblInvoiceAddress
        '
        Me.lblInvoiceAddress.Location = New System.Drawing.Point(8, 40)
        Me.lblInvoiceAddress.Name = "lblInvoiceAddress"
        Me.lblInvoiceAddress.Size = New System.Drawing.Size(100, 23)
        Me.lblInvoiceAddress.TabIndex = 1
        Me.lblInvoiceAddress.Text = "Invoice Address"
        '
        'lblCustomer
        '
        Me.lblCustomer.Location = New System.Drawing.Point(8, 16)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(100, 23)
        Me.lblCustomer.TabIndex = 0
        Me.lblCustomer.Text = "Customer"
        '
        'FrmInvoicedPayment
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(451, 334)
        Me.Controls.Add(Me.gpbInvoiceInformation)
        Me.Controls.Add(Me.gpbPayment)
        Me.Name = "FrmInvoicedPayment"
        Me.Text = "Invoice Payment"
        Me.Controls.SetChildIndex(Me.gpbPayment, 0)
        Me.Controls.SetChildIndex(Me.gpbInvoiceInformation, 0)
        Me.gpbPayment.ResumeLayout(False)
        Me.gpbPayment.PerformLayout()
        Me.gpbInvoiceInformation.ResumeLayout(False)
        Me.gpbInvoiceInformation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
        InvoicedID = GetParameter(0)
        EngineerVisitID = GetParameter(6)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region

#Region " Properties "

    Private _changingAmount As Boolean = False

    Private _InvoicedID As Integer = 0

    Private Property InvoicedID() As Integer
        Get
            Return _InvoicedID
        End Get
        Set(ByVal Value As Integer)
            _InvoicedID = Value
            Populate()
        End Set
    End Property

    Private _InvoiceTotal As Double = 0

    Private Property InvoiceTotal() As Double
        Get
            Return _InvoiceTotal
        End Get
        Set(ByVal Value As Double)
            _InvoiceTotal = Value
        End Set
    End Property

    Private _EngineerVisitID As Integer = 0

    Private Property EngineerVisitID() As Integer
        Get
            Return _EngineerVisitID
        End Get
        Set(ByVal Value As Integer)
            _EngineerVisitID = Value
        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMInvoiceManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnAddPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPay.Click
        If Not loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Finance) Then
            Dim msg As String = "You do not have the necessary security permissions."
            Throw New Security.SecurityException(msg)
        End If
        MakePayment()
    End Sub

#End Region

#Region "Functions"

    Private Sub Populate()
        Me.txtCustomer.Text = GetParameter(1)
        Me.txtInvoiceAddress.Text = GetParameter(2)
        Me.txtInvNumber.Text = GetParameter(3)
        Me.txtRaisedDate.Text = Format(GetParameter(4), "dd/MM/yyyy")
        Me.txtRaisedBy.Text = GetParameter(5)

        For Each dr As DataRow In DB.InvoicedLines.InvoicedLines_GetAll_ByInvoicedID(InvoicedID).Table.Rows
            InvoiceTotal += Entity.Sys.Helper.MakeDoubleValid(dr.Item("Amount"))
        Next dr

        Dim vatRate As Double = Entity.Sys.Helper.MakeDoubleValid(GetParameter(7)) / 100
        Dim vatAmount As Double = InvoiceTotal * vatRate
        Dim total As Double = InvoiceTotal + Math.Round(vatAmount, 2, MidpointRounding.ToEven)
        Me.txtInvAmount.Text = Format(total, "C")
    End Sub

    Private Sub MakePayment()
        Try
            Dim PaidBy As Integer = 0
            If Combo.GetSelectedItemValue(cboPaidBy) > 0 And Combo.GetSelectedItemValue(cboPaymentTerm) = 69491 Then
                PaidBy = Combo.GetSelectedItemValue(cboPaidBy)
            End If
            DB.InvoicedLines.Invoiced_ChangeTerm(InvoicedID, Combo.GetSelectedItemValue(cboPaymentTerm), PaidBy)

            Dim EngVisitCharge As Entity.EngineerVisitCharges.EngineerVisitCharge = DB.EngineerVisitCharge.EngineerVisitCharge_Get(EngineerVisitID)

            EngVisitCharge.SetForSageAccountCode = Me.txtAccountNumber.Text.Trim

            DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge)

            If ShowMessage("Print?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub
            Dim oPrint As New Entity.Sys.Printing(InvoicedID, "Receipt", Entity.Sys.Enums.SystemDocumentType.PaymentReceipt)
        Catch ex As Exception
            ShowMessage("Error processing payment" & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class