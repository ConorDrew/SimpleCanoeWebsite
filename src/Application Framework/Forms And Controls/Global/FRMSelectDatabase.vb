Public Class FRMSelectDatabase

    Private _selectdDb As Integer = 0
    Friend WithEvents btnOk As Button

    Public Property SelectedDb As Integer
        Get
            Return _selectdDb
        End Get
        Set(value As Integer)
            _selectdDb = value
        End Set
    End Property

    Private Sub FRMSelectDatabase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Combo.SetUpCombo(Me.cboDatabase, Databases, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select)
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Combo.GetSelectedItemValue(Me.cboDatabase) = 0 Then ' oppps
            MsgBox("Please a database to use", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        SelectedDb = Combo.GetSelectedItemValue(Me.cboDatabase) - 1 ' take care of 0 actually being please select but is row 0 also
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If
    End Sub

End Class