Public Class FRMItemReturn

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cboJobType) = 0 Then
            ShowMessage("Please select an option", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Combo.GetSelectedItemValue(cboJobType) = 2 And TextBox2.Text.Length < 2 Then
            ShowMessage("Please enter a location to return / collect from", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        nr = newDt.NewRow
        nr("ManagerID") = 0
        nr("Name") = " - Please Select - "
        newDt.Rows.Add(nr)

        nr = newDt.NewRow
        nr("ManagerID") = 1
        nr("Name") = " Original Engineer To return Parts to supplier as not needed "
        newDt.Rows.Add(nr)

        nr = newDt.NewRow
        nr("ManagerID") = 2
        nr("Name") = " Original Engineer to Return Parts to the below location ready for the next engineer to pick up. "
        newDt.Rows.Add(nr)

        Combo.SetUpCombo(cboJobType, newDt, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Combo.SetSelectedComboItem_By_Value(cboJobType, 0)
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class