Public Class DataGridVoidColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle,
                                            ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush,
                                            ByVal alignToRight As Boolean)

        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        'check for row before we call it

        Dim voidProp As Boolean = False
        If row.Table.Columns.Contains("PropertyVoid") Then
            voidProp = Entity.Sys.Helper.MakeBooleanValid(row("PropertyVoid"))
        End If

        If voidProp Then
            backBrush = Brushes.Yellow
        Else : backBrush = backBrush
        End If

        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

    End Sub

#End Region

End Class
