Public Class Contract3AssetsColourColumn : Inherits DataGridEditableTextBoxColumn

#Region "Functions"

    Protected Overloads Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal bounds As System.Drawing.Rectangle, ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As System.Drawing.Brush, ByVal foreBrush As System.Drawing.Brush, ByVal alignToRight As Boolean)
        MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        'set the color required dependant on the column value
        Dim brush As Brush
        Dim str As String = ""

        If Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item(Me.MappingName.ToString)) = "" Then
            str = "-"
            brush = Brushes.White
            Me.ReadOnly = True
        Else
            brush = Brushes.Yellow
            str = Entity.Sys.Helper.MakeStringValid([source].List.Item(rowNum).row.item(Me.MappingName.ToString))
            Me.ReadOnly = False
            AddHandler Me.TextBox.TextChanged, AddressOf ValidateAssetDuration
        End If
        'color the row cell
        Dim rect As Rectangle = bounds
        g.FillRectangle(brush, rect)
        g.DrawString(str, Me.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom))

    End Sub

    Private Sub ValidateAssetDuration(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not IsNumeric(CType(sender, TextBox).Text) And CType(sender, TextBox).Text.Trim.Length > 0 Then
            CType(sender, TextBox).Text = 0
        End If
    End Sub
#End Region

End Class
