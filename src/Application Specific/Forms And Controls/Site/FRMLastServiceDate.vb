Public Class FRMLastServiceDate : Inherits FSM.FRMBaseForm : Implements IForm

#Region "Interface Methods"

    Private Sub LoadMe(ByVal sender As Object, ByVal e As System.EventArgs) Implements IForm.LoadMe
        ID = Entity.Sys.Helper.MakeIntegerValid(GetParameter(0))
        LoadForm(sender, e, Me)
    End Sub

    Public ReadOnly Property LoadedControl() As IUserControl Implements IForm.LoadedControl
        Get
            Return Nothing
        End Get
    End Property

    Public Sub ResetMe(ByVal newID As Integer) Implements IForm.ResetMe
        ID = newID
    End Sub
#End Region

#Region "Properties"
    Private _ID As Integer = 0
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value

        End Set
    End Property
#End Region

#Region "Events"

    Private Sub FRMLastServiceDate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadMe(sender, e)
        Dim oSite As Entity.Sites.Site = DB.Sites.Get(ID)
        If oSite IsNot Nothing AndAlso oSite.Exists Then
            If oSite.LastServiceDate <> Nothing Then
                Me.dtpLastServiceDate.Value = oSite.LastServiceDate.AddYears(1)
                Me.dtpActualServiceDate.Value = oSite.LastServiceDate
            End If

            If oSite.ActualServiceDate <> Nothing Then
                Me.dtpActualServiceDate.Value = oSite.ActualServiceDate
            End If
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        DB.Sites.Site_UpdateLastServiceDate(ID, dtpLastServiceDate.Value.AddYears(-1), dtpActualServiceDate.Value, True)
        Me.DialogResult = DialogResult.OK
    End Sub

#End Region


End Class