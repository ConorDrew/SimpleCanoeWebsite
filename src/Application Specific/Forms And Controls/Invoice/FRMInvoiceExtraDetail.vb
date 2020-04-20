Public Class FRMInvoiceExtraDetail

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cbo) = 0 Then
            ShowMessage("Please enter a valid VAT Amount", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Combo.SetUpCombo(Me.cbo, DB.VATRatesSQL.VATRates_GetAll_Valid.Table, "VATRATEID", "Description", Entity.Sys.Enums.ComboValues.Please_Select)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Combo.SetSelectedComboItem_By_Value(cbo, "0")
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class