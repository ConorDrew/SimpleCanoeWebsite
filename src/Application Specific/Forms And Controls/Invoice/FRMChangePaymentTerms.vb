Public Class FRMChangePaymentTerms : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        '    txtInvoicedTotal.Text = Entity.Sys.Helper.MakeDoubleValid(GetParameter(1))
        LoadForm(sender, e, Me)
        Combo.SetUpCombo(Me.cboPaymentTerm, DB.Picklists.GetAll(65).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Combo.SetUpCombo(Me.cboPaidBy, DB.Picklists.GetAll(66).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

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
        If Combo.GetSelectedItemValue(cboPaymentTerm) > 0 Then
            Dim PaidBy As Integer = 0
            If Combo.GetSelectedItemValue(cboPaidBy) > 0 And Combo.GetSelectedItemValue(cboPaymentTerm) = 69491 Then
                PaidBy = Combo.GetSelectedItemValue(cboPaidBy)
            End If
            DB.InvoicedLines.Invoiced_ChangeTerm(ID, Combo.GetSelectedItemValue(cboPaymentTerm), PaidBy)
            Me.DialogResult = DialogResult.OK
        Else
            ShowMessage("Please Select a Term", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        If Entity.Sys.Helper.HashPassword(Me.txtPassword.Text.Trim) = DB.Manager.Get.OverridePassword_Service Then
            cboPaymentTerm.Enabled = True
            Me.btnSave.Enabled = True
        Else
            cboPaymentTerm.Enabled = False
            Me.btnSave.Enabled = False
        End If
    End Sub

#End Region

    Private Sub cboPaymentTerm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaymentTerm.SelectedIndexChanged
        If Combo.GetSelectedItemValue(cboPaymentTerm) = Entity.Sys.Enums.QuoteJobOfWorkTypes.Reciept Then
            lblPaidBy.Visible = True
            cboPaidBy.Visible = True
        Else
            lblPaidBy.Visible = False
            cboPaidBy.Visible = False
        End If
    End Sub

End Class