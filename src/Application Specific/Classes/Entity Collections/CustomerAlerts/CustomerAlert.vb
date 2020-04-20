Namespace Entity.Customers

    Public Class CustomerAlert

        Public Sub New()
        End Sub

        Public Property Id() As Integer
        Public Property CustomerId() As Integer
        Public Property AlertTypeId() As Integer
        Public Property EmailAddress() As String
        Public Property Created() As DateTime

        Public Property AlertType() As String
    End Class

End Namespace