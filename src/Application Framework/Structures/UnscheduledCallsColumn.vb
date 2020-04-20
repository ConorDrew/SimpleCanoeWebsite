

Public Class UnscheduledCallsColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)

        'set the color required dependant on the column value
        Dim brush As Brush
        Dim str As String = ""

        brush = Brushes.White

        If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item("FollowUpDeclined")) = True Then
            brush = Brushes.Salmon
        Else : brush = backBrush
        End If

        'If Entity.Sys.Helper.MakeBooleanValid([source].List.Item(rowNum).row.item("PartsNeedOrdering")) = True Then
        '    brush = Brushes.Purple
        'Else : brush = backBrush
        'End If



        Me.TextBox.Text = ""

        'color the row cell
        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)

        MyBase.Paint(g, bounds, source, rowNum, brush, foreBrush, alignToRight)

    End Sub

#End Region

End Class

