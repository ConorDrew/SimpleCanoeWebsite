Public Class FRMPOInvoiceAuthReasons : Inherits FSM.FRMBaseForm : Implements IForm
    Public ReadOnly Property LoadedControl As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub LoadMe(sender As Object, e As EventArgs) Implements IForm.LoadMe
        LoadForm(sender, e, Me)

    End Sub

    Public Sub ResetMe(newID As Integer) Implements IForm.ResetMe

    End Sub
#Region "Properties"
    Public _AuthReason As System.String
    Public Property AuthReason() As System.String
        Get
            Return AuthReason
        End Get
        Set(ByVal Value As System.String)

            'Me.MinimumSize = New Size(New Point(704, 392))

            _AuthReason = Value
            'SetupDG()
            'Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow)

            'Me.MinimumSize = Me.Size
        End Set
    End Property

    Public _AuthReasonDetail As System.String
    Public Property AuthReasonDetail() As System.String
        Get
            Return AuthReasonDetail
        End Get
        Set(ByVal Value As System.String)

            'Me.MinimumSize = New Size(New Point(704, 392))

            _AuthReasonDetail = Value
            'SetupDG()
            'Records = DB.ImportValidation.POInvoiceImport_ShowPOParts(_POToShow)

            'Me.MinimumSize = Me.Size
        End Set
    End Property
#End Region
#Region "Events"
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If AuthReasonOption3.Checked = True And txtAuthReasonOther.Text = "" Then
            ShowMessage("An error has occurred:" & vbCrLf & "When selecting other you must enter a reason", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

#End Region

    Private Sub AuthReasonOption1_CheckedChanged(sender As Object, e As EventArgs) Handles AuthReasonOption1.CheckedChanged
        _AuthReason = AuthReasonOption1.Text
    End Sub

    Private Sub AuthReasonOption2_CheckedChanged(sender As Object, e As EventArgs) Handles AuthReasonOption2.CheckedChanged
        _AuthReason = AuthReasonOption2.Text
    End Sub

    Private Sub AuthReasonOption3_CheckedChanged(sender As Object, e As EventArgs) Handles AuthReasonOption3.CheckedChanged
        _AuthReason = AuthReasonOption3.Text
    End Sub

    Private Sub txtAuthReasonOther_TextChanged(sender As Object, e As EventArgs) Handles txtAuthReasonOther.TextChanged
        _AuthReasonDetail = txtAuthReasonOther.Text
    End Sub
End Class