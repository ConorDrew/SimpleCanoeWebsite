Public Class FRMAddPartToBeCredited : Inherits FSM.FRMBaseForm : Implements IForm

    Public Sub New(ByVal qty As Integer)
        MyBase.New()

        InitializeComponent()
        Me.txtQtyAvailable.Text = qty
    End Sub

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Private Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
    End Sub

#End Region
 
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Entity.Sys.Helper.MakeIntegerValid(txtQtyAvailable.Text) < Entity.Sys.Helper.MakeIntegerValid(txtQtyToReturn.Text) Then
            ShowMessage("Cannot return more than was allocated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.DialogResult =DialogResult.OK
    End Sub

End Class