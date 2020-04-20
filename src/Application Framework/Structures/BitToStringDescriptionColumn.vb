Public Class BitToStringDescriptionColumn : Inherits DataGridEditableTextBoxColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        'set the color required dependant on the column value
        Dim brush As Brush = Brushes.White
        Dim str As String = ""

        Try
            'If CType([source].Current, DataRowView).Row.Item("EngineerVisitID") = Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("EngineerVisitID")) Then
            '    brush = Brushes.Gainsboro
            'Else
            '    brush = Brushes.White
            'End If
        Catch ex As Exception
        End Try

        If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item(Me.MappingName.ToString)) Then
            str = "Yes"
        Else
            str = "No"
        End If
        'color the row cell
        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)
        g.DrawString(str, Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

    End Sub

#End Region

End Class
