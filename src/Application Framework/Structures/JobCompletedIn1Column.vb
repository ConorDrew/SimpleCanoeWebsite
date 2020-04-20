Public Class JobCompletedIn1Column : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        'set the color required dependant on the column value
        Dim brush As Brush
        Select Case Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item("VisitCompletedInOne"))
            Case "Yes"
                brush = Brushes.LightGreen
            Case "No"
                brush = Brushes.Salmon
            Case Else
                brush = Brushes.White
        End Select

        'color the row cell
        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)
        g.DrawString(Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item("VisitCompletedInOne")), Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
    End Sub

#End Region

End Class
