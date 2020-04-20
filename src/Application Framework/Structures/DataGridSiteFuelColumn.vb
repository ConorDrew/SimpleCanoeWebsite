Public Class DataGridSiteFuelColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle,
                                            ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush,
                                            ByVal alignToRight As Boolean)

        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        'check for row before we call it
        If row.Table.Columns.Contains("LastServiceDate") Then
            Dim lsd As DateTime = Entity.Sys.Helper.MakeDateTimeValid(row("LastServiceDate"))
            If lsd <> Nothing AndAlso lsd > SqlTypes.SqlDateTime.MinValue.Value.AddYears(1) Then
                If lsd <= Now().AddDays(-365) Then
                    backBrush = Brushes.Black
                    foreBrush = Brushes.Yellow
                ElseIf lsd <= Now().AddDays(-352) And lsd > Now().AddDays(-365) Then
                    backBrush = Brushes.Red
                ElseIf lsd <= Now().AddDays(-330) And lsd > Now().AddDays(-352) Then
                    backBrush = Brushes.Orange
                ElseIf lsd <= Now().AddDays(-309) And lsd > Now().AddDays(-330) Then
                    backBrush = Brushes.Yellow
                ElseIf lsd <= Now().AddDays(-281) And lsd > Now().AddDays(-309) Then
                    backBrush = Brushes.PaleGreen
                Else
                    backBrush = backBrush
                End If
            End If
        End If
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

    End Sub

#End Region

End Class
