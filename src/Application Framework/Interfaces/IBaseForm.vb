Public Interface IBaseForm

    Property FormButtons() As ArrayList

    Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs, ByVal frm As IForm)

    Sub LoadForm(ByVal frm As Form)

    Sub LoopControls(ByVal controlToLoop As Control)

    Sub SetupButtonMouseOvers()

    Sub CreateHover(ByVal sender As Object, ByVal e As System.EventArgs)

    WriteOnly Property SetFormParameters() As Array

    ReadOnly Property GetParameter(Optional ByVal indexOfArrayToGet As Integer = 0) As Object
    ReadOnly Property GetParameterCount() As Integer

End Interface