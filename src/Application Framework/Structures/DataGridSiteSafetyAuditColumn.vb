Imports FSM.Entity.Sys

Public Class DataGridSiteSafetyAuditColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle,
                                            ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush,
                                            ByVal alignToRight As Boolean)

        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        'check for row before we call it
        If row.Table.Columns.Contains("Result") Then
            Dim result As Double = Helper.MakeDoubleValid(row("Result"))

            If result >= 90 Then
                backBrush = Brushes.Green
                foreBrush = New SolidBrush(Helper.ContrastColor(Color.Green))
            ElseIf result >= 75 AndAlso result < 90 Then
                backBrush = Brushes.Orange
                foreBrush = New SolidBrush(Helper.ContrastColor(Color.Orange))
            ElseIf result >= 60 AndAlso result < 75 Then
                backBrush = Brushes.Orange
                foreBrush = New SolidBrush(Helper.ContrastColor(Color.Orange))
            Else
                backBrush = Brushes.Red
                foreBrush = New SolidBrush(Helper.ContrastColor(Color.Red))
            End If
        End If
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

    End Sub

#End Region

End Class