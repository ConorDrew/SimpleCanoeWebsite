Public Class FRMManualApp

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cboInitialPaymentType) = 0 Then
            ShowMessage("Please select an Appliance type", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Combo.SetUpCombo(Me.cboInitialPaymentType, DynamicDataTables.ManualApp, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Combo.SetSelectedComboItem_By_Value(cboInitialPaymentType, "0")
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class