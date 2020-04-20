Public Class FRMNewPrice

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtPrice.Text) And txtPrice.Text.Length < 1 Then
            ShowMessage("Please enter a valid amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtPrice.Text = "0"
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class