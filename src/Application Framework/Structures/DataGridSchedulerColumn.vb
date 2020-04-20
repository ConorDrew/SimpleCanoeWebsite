Public Class DataGridSchedulerColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)

        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

        Dim brush As Brush = Brushes.White
        Dim strBrush As Brush = Brushes.MidnightBlue
        Dim str As String = ""

        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        'check for row before we call it
        If row.Table.Columns.Contains("IsJobLate") Then
            If Entity.Sys.Helper.MakeBooleanValid(row("IsJobLate")) Then
                brush = Brushes.Red
                str = "L"
            End If
        End If

        'check for row before we call it
        If row.Table.Columns.Contains("IsServiceOverDue") Then
            If Entity.Sys.Helper.MakeBooleanValid(row("IsServiceOverDue")) Then
                brush = Brushes.Orange
                str = "O"
            End If
        End If

        'check for row before we call it
        If row.Table.Columns.Contains("Declined") Then
            If Entity.Sys.Helper.MakeBooleanValid(row("Declined")) Then
                brush = Brushes.LightGray
                str = "D"
            End If
        End If

        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)
        g.DrawString(str, Me.DataGridTableStyle.DataGrid.Font, strBrush, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

    End Sub

#End Region

End Class