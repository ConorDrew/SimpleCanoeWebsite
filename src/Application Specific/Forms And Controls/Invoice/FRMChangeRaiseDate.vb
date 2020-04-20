Public Class FRMChangeRaiseDate : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe



        LoadForm(sender, e, Me)

        dtpTaxDate.Enabled = False
        btnSave.Enabled = False


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

        DialogResult = DialogResult.OK

    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        If Entity.Sys.Helper.HashPassword(Me.txtPassword.Text.Trim) = Entity.Sys.Helper.HashPassword("boiler123") Then
            dtpTaxDate.Enabled = True
            btnSave.Enabled = True
        Else

            dtpTaxDate.Enabled = False
            btnSave.Enabled = False
        End If
    End Sub

#End Region


End Class