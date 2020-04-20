Public Class DueDateColourColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        'set the color required dependant on the column value
        Dim brush As Brush

        If (Entity.Sys.Helper.MakeDateTimeValid([source].List.Item(rowNum).row.item("NextVisitDate")) < Now.AddDays(14) And Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item("Type")) <> "Letter 3") _
            Or (Entity.Sys.Helper.MakeDateTimeValid([source].List.Item(rowNum).row.item("NextVisitDate")) < Now.AddDays(9) And Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item("Type")) = "Letter 3") Then

            brush = Brushes.Red
        Else
            brush = Brushes.White
        End If



        'color the row cell
        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)
        Dim strDate As String
        strDate = Strings.Format(Entity.Sys.Helper.MakeDateTimeValid([source].List.Item(rowNum).row.item("NextVisitDate")), "dddd dd/MM/yyyy")

        g.DrawString(strDate, Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
    End Sub

#End Region

End Class
