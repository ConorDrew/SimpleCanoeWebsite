Public Class ImporterLabelColumn : Inherits DataGridTextBoxColumn

#Region "Functions"

    Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String)
    End Sub

    Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
    End Sub

    Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean)
    End Sub

    Private _ColumnName As String
    Public Property ColumnName() As String
        Get
            Return _ColumnName
        End Get
        Set(ByVal Value As String)
            _ColumnName = Value
        End Set
    End Property

    Public Sub New(ByVal ColumnNameIn As String)
        ColumnName = ColumnNameIn
    End Sub

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

        Dim rect As Rectangle = bounds

        Try
            If [source].List.Item(rowNum).row.item(ColumnName & "COLOURBOOLEANCOLUMN") Then
                g.FillRectangle(Brushes.Red, rect)
            Else
                g.FillRectangle(Brushes.White, rect)
            End If
        Catch
            g.FillRectangle(Brushes.White, rect)
        End Try

        g.DrawString(Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item(ColumnName)), Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
    End Sub

#End Region

End Class