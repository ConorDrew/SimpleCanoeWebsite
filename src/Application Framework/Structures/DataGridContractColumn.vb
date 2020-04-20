Public Class DataGridContractColumn : Inherits DataGridLabelColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle,
                                            ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer,
                                            ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush,
                                            ByVal alignToRight As Boolean)

        'Need to get row information from data
        Dim row As DataRow = [source].List.Item(rowNum).row

        'check for row before we call it
        Dim renewed As Boolean = False
        If row.Table.Columns.Contains("Renewed") Then
            Select Case Entity.Sys.Helper.MakeStringValid(row("Renewed"))
                Case "Renewed"
                    renewed = True
                Case "Transfered"
                    renewed = True
                Case Else
                    renewed = False
            End Select
        End If

        Dim contactMade As Boolean = False
        If row.Table.Columns.Contains("ContactMade") Then
            contactMade = Entity.Sys.Helper.MakeBooleanValid(row("ContactMade"))
        End If

        If Not renewed And Not contactMade Then
            backBrush = Brushes.Red
        ElseIf Not renewed And contactMade Then
            backBrush = Brushes.Yellow
        Else : backBrush = backBrush
        End If

        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)

    End Sub

#End Region

End Class
