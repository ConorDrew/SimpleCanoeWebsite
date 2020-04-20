Public Class FRMAddVanEquipment

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Combo.GetSelectedItemValue(cboEquipment) = 0 Then
            ShowMessage("Please select equipment", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMAddVanEquipment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetUpCombo(cboEquipment, DB.FleetEquipment.GetAll.Table, "EquipmentID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

End Class