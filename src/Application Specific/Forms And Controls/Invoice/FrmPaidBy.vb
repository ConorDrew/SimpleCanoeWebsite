Public Class FRMPaidBy

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cboDDPaid) = 0 Then
            ShowMessage("Please enter a valid Payment", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Combo.SetUpCombo(Me.cboDDPaid, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PaymentMethods).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Combo.SetSelectedComboItem_By_Value(cboDDPaid, "0")
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class