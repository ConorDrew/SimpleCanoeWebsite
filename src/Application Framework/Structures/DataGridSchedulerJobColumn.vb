Public Class DataGridSchedulerJobColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)

        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        If row.Table.Columns.Contains("IsJobLate") Then
            If Entity.Sys.Helper.MakeBooleanValid(row("IsJobLate")) Then
                backBrush = Brushes.Red
            End If
        End If

        If row.Table.Columns.Contains("IsServiceOverDue") Then
            If Entity.Sys.Helper.MakeBooleanValid(row("IsServiceOverDue")) Then
                backBrush = Brushes.Orange
            End If
        End If

        If row.Table.Columns.Contains("Declined") Then
            If Entity.Sys.Helper.MakeBooleanValid(row("Declined")) Then
                backBrush = Brushes.LightGray
            End If
        End If

        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub

#End Region

End Class