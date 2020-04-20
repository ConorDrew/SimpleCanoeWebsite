Public Class FRMSmokeComo

    Public AdditionalID As Integer = 0
    Public EngineerVisitID As Integer = 0

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cboPower) = 0 Then
            ShowMessage("Please select a Power Type", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Combo.GetSelectedItemValue(cboDateType) = 0 Then
            ShowMessage("Please select a Date Type", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Combo.GetSelectedItemValue(cboDetType) = 0 Then
            ShowMessage("Please select a Detector Type", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf txtLocation.Text.Length = 0 Then
            ShowMessage("Please enter a Location", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim additional As Entity.EngineerVisitAdditionals.EngineerVisitAdditional = New Entity.EngineerVisitAdditionals.EngineerVisitAdditional
            If chkNA.Checked Then
                additional.SetTest11 = "Not Known"
            Else
                additional.SetTest11 = dtpDate.Value.ToString("d MMM yyyy")
            End If
            additional.SetEngineerVisitID = EngineerVisitID
            additional.SetTest1 = 386
            additional.SetTestTypeID = Combo.GetSelectedItemValue(cboDetType)
            additional.SetTest2 = Combo.GetSelectedItemValue(cboPower)
            additional.SetTest12 = Combo.GetSelectedItemDescription(cboDateType)
            additional.SetTest13 = txtLocation.Text

            additional.SetEngineerVisitAdditionalID = AdditionalID

            If AdditionalID = 0 Then
                DB.EngineerVisitAdditional.Insert(additional)
            Else
                DB.EngineerVisitAdditional.Update(additional)
            End If
            Me.DialogResult = DialogResult.OK
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub chkNA_CheckedChanged(sender As Object, e As EventArgs) Handles chkNA.CheckedChanged
        If chkNA.Checked Then
            dtpDate.Enabled = False
        Else
            dtpDate.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If

    End Sub

End Class