Public Class FRMContractUpgradeDowngrade

    Private _EffDate As Date = Date.MinValue

    Public Property EffDate() As Date
        Get
            Return _EffDate
        End Get
        Set(ByVal Value As Date)
            _EffDate = Value
        End Set
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        EffDate = dtpEffDate.Value
        Me.DialogResult = DialogResult.OK
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub FRMChangePriority_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpEffDate.Value = Now
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class