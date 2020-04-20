Imports System.Linq
Imports FSM.Entity.Sys

Public Class DataGridJobTypeColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle,
                                            ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush,
                                            ByVal alignToRight As Boolean)
        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        'check for row before we call it
        If row.Table.Columns.Contains("JobTypeID") Then
            Dim jobTypeId As Integer = Helper.MakeIntegerValid(row("JobTypeID"))
            Dim color As Color = Color.Transparent

            If row.Table.Columns.Contains("Colour") Then
                Dim colour As String = Helper.MakeStringValid(row("Colour"))
                If Not String.IsNullOrWhiteSpace(colour) Then
                    color = Color.FromName(colour)
                End If
            End If

            If color <> Color.Transparent Then
                backBrush = New SolidBrush(color)
                foreBrush = New SolidBrush(Helper.ContrastColor(color))
            End If

        End If
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
    End Sub

#End Region

End Class