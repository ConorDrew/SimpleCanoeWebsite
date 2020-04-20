Public Class StockReplenishmentColourColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        'set the color required dependant on the column value
        Dim brush As Brush

        brush = Brushes.LightGreen
        'IS THERE ANY ON ORDER?
        If Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("UnitsOnOrder")) > 0 _
             And (Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("UnitsOnOrder")) + _
            Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("Amount"))) >= _
           Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("MinimumQuantity")) Then

            brush = Brushes.LightBlue
        Else
            If Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("Amount")) < Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("MinimumQuantity")) Then
                brush = Brushes.Salmon
            Else
                If Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("Amount")) < Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("RecommendedQuantity")) Then
                    brush = Brushes.Yellow
                Else
                    brush = Brushes.LightGreen
                End If
            End If

        End If
        'color the row cell
        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)
        g.DrawString(Entity.Sys.Helper.MakeIntegerValid([source].List.Item(rowNum).row.item("Amount")), Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
    End Sub

#End Region

End Class
