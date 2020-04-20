Public Class ColourColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        'set the color required dependant on the column value
        Dim brush As Brush
        Dim str As String = ""

        brush = Brushes.White

        Select Case Me.MappingName.ToString
            Case "PartsToFit"
                If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item(Me.MappingName.ToString)) Then
                    brush = Brushes.Orange
                End If
                If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item("PartsNeedOrdering")) Then
                    brush = Brushes.Purple
                End If
                Me.TextBox.Text = ""
            Case "AllPartsReceived"
                If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item(Me.MappingName.ToString)) Then
                    brush = Brushes.Blue
                End If
                Me.TextBox.Text = ""
                'Case "PartsNeedOrdering"
                '    If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item(Me.MappingName.ToString)) Then
                '        brush = Brushes.Purple
                '    End If
                '    Me.TextBox.Text = ""

        End Select
        'color the row cell
        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)
        g.DrawString(str, Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

    End Sub

#End Region

End Class
