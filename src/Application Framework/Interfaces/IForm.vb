Public Interface IForm

    Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs)

    ReadOnly Property LoadedControl() As IUserControl

    Sub ResetMe(ByVal newID As Integer)

End Interface
