Public Class FRMGenDropBox

    Public IncDD As Boolean = True

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If cbo1.Visible And Combo.GetSelectedItemValue(cbo1) = 0 Then
            ShowMessage("Please select a Valid Option", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf cbo2.Visible And Combo.GetSelectedItemValue(cbo2) = 0 Then
            ShowMessage("Please select a Valid Option", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf txtref.Visible And txtref.Text.Length = 0 Then
            ShowMessage("Please enter a payment reference", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            DialogResult = DialogResult.OK
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Combo.SetUpCombo(Me.cbo1, DynamicDataTables.ContractInitialPaymentTypes, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Combo.SetSelectedComboItem_By_Value(cbo1, "0")
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class