Public Class DataGridVisitManagerColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle,
                                            ByVal source As CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As Brush, ByVal foreBrush As Brush,
                                            ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        'check for row before we call it
        Dim chargable As Boolean = False
        If row.Table.Columns.Contains("VisitChargeable") Then
            Select Case Entity.Sys.Helper.MakeIntegerValid(row("VisitChargeable"))
                Case CInt(Entity.Sys.Enums.TabletYesNoNA.Yes)
                    backBrush = Brushes.Yellow
                Case CInt(Entity.Sys.Enums.TabletYesNoNA.No)
                    backBrush = Brushes.LightGreen
                Case Else
                    backBrush = backBrush
            End Select
        End If

        Dim rect As Rectangle = bounds
        g.FillRectangle(backBrush, rect)
        g.DrawString("", Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))
    End Sub

#End Region

End Class