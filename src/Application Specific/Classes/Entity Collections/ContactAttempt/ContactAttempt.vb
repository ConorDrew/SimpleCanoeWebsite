Namespace Entity.ContactAttempts

    Public Class ContactAttempt

        Public Sub New()
        End Sub

        Public Property ContactAttemptID() As Integer
        Public Property ContactMethedID() As Integer
        Public Property LinkID() As Integer
        Public Property LinkRef() As Integer
        Public Property ContactMade() As DateTime
        Public Property Notes() As String
        Public Property ContactMadeByUserId() As Integer

        Public Property ContactMethod() As String
        Public Property ContactMadeBy() As String

    End Class

End Namespace