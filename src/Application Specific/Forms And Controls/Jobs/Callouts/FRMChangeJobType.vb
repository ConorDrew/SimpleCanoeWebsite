Public Class FRMChangeJobType

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cboJobType) = 0 Then
            ShowMessage("Please select a job type", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangeJobType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Combo.SetUpCombo(cboJobType, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JobTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

End Class