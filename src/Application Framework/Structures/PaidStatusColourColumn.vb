Public Class PaidStatusColourColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        'set the color required dependant on the column value
        Dim brush As Brush
        Select Case Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("PaidStatus"))
            Case -2
                brush = Brushes.White
            Case -1
                brush = Brushes.Red
            Case 0
                brush = Brushes.Gold
            Case 1
                brush = Brushes.LightGreen
        End Select

        'color the row cell
        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)
        g.DrawString("", Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
    End Sub

#End Region

End Class
