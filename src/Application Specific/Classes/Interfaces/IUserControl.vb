Public Interface IUserControl

    Sub LoadForm(ByVal sender As Object, ByVal e As System.EventArgs)

    ReadOnly Property LoadedItem() As Object

    Event RecordsChanged(ByVal dv As DataView, ByVal pageIn As Entity.Sys.Enums.PageViewing, ByVal FromASave As Boolean, ByVal FromADelete As Boolean, ByVal extraText As String)

    Event StateChanged(ByVal newID As Integer)

    Sub Populate(Optional ByVal ID As Integer = 0)

    Function Save() As Boolean


End Interface
