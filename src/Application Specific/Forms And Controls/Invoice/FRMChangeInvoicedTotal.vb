Public Class FRMChangeInvoicedTotal : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        txtInvoicedTotal.Text = Entity.Sys.Helper.MakeDoubleValid(GetParameter(1))
        txtAccount.Text = Entity.Sys.Helper.MakeStringValid(GetParameter(2))
        txtDept.Text = Entity.Sys.Helper.MakeStringValid(GetParameter(3))
        txtNominal.Text = Entity.Sys.Helper.MakeStringValid(GetParameter(4))
        dtpTaxDate.Value = Entity.Sys.Helper.MakeDateTimeValid(GetParameter(5))
        typeID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(6))

        LoadForm(sender, e, Me)

        Me.txtInvoicedTotal.Enabled = False
        Me.txtNominal.Enabled = False
        Me.txtDept.Enabled = False
        Me.txtAccount.Enabled = False
        Me.dtpTaxDate.Enabled = False
        Me.btnSave.Enabled = False

    End Sub

    Dim typeID As Integer

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        ID = newID
    End Sub

#End Region

#Region "Properties"

    Private _ID As Integer = 0

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value

        End Set
    End Property

#End Region

#Region "Events"

    Private Sub FRMChangeInvoicedTotal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtInvoicedTotal.Text.Replace("£", "").Length > 0 And IsNumeric(txtInvoicedTotal.Text.Replace("£", "")) Then

            DB.InvoicedLines.InvoicedLinesTotal_Change(ID, txtInvoicedTotal.Text.Replace("£", ""))

            DB.InvoicedLines.InvoicedLinesTotal_ChangeInvoiceDetails(ID, txtAccount.Text, txtDept.Text, txtNominal.Text, dtpTaxDate.Value, typeID)

            Me.DialogResult = DialogResult.OK
        Else
            ShowMessage("Enter An Amount", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        If Entity.Sys.Helper.HashPassword(Me.txtPassword.Text.Trim) = DB.Manager.Get.OverridePassword_Service Then
            Me.txtInvoicedTotal.Enabled = True
            Me.txtNominal.Enabled = True
            Me.txtDept.Enabled = True
            Me.txtAccount.Enabled = True
            Me.dtpTaxDate.Enabled = True
            Me.btnSave.Enabled = True
        Else
            Me.txtInvoicedTotal.Enabled = False
            Me.txtNominal.Enabled = False
            Me.txtDept.Enabled = False
            Me.txtAccount.Enabled = False
            Me.dtpTaxDate.Enabled = False
            Me.btnSave.Enabled = False
        End If
    End Sub

#End Region

End Class