Public Class DataGridDistrictColumn : Inherits DataGridLabelColumn

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle,
                                            ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush,
                                            ByVal alignToRight As Boolean)

        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        'check for row before we call it

        Dim district As Boolean = False
        If row.Table.Columns.Contains("CommercialDistrict") Then
            district = Entity.Sys.Helper.MakeBooleanValid(row("CommercialDistrict"))
        End If

        If district Then
            backBrush = Brushes.Orange
        Else : backBrush = backBrush
        End If

        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

    End Sub

End Class