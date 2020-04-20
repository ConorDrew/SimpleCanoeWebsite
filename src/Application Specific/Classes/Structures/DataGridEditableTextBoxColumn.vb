Public Class DataGridEditableTextBoxColumn
    Inherits DataGridTextBoxColumn

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)
        Try
            backBrush = _backColour

            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

        Catch ex As Exception

        End Try
    End Sub


    Private _backColour As Brush = Brushes.White
    Public Property BackColourBrush() As Brush
        Get
            Return _backColour
        End Get
        Set(ByVal Value As Brush)
            _backColour = Value
        End Set
    End Property

End Class

