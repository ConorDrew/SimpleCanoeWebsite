Public Class FRMChangePriority

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cboJobType) = 0 Then
            ShowMessage("Please select a priority", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.JOWPriority).Table
        Dim dr() As DataRow = dt.Select("Name<>'RC - Recall'")
        Dim newDt As DataTable = dt.Clone
        Dim nr As DataRow
        For Each r As DataRow In dr
            nr = newDt.NewRow
            nr("ManagerID") = r("ManagerID")
            nr("Name") = r("Name")
            newDt.Rows.Add(nr)
        Next
        Combo.SetUpCombo(cboJobType, newDt, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

End Class