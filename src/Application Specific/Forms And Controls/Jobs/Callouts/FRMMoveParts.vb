Imports FSM.Entity.EngineerVisits
Imports FSM.Entity.Sys

Public Class FRMMoveParts

    Private _EngineerVisitId As Integer

    Public Property EngineerVisitId() As Integer
        Get
            Return _EngineerVisitId
        End Get
        Set(ByVal Value As Integer)
            _EngineerVisitId = Value
        End Set
    End Property

    Private _jobNumber As String

    Public Property JobNumber() As String
        Get
            Return _jobNumber
        End Get
        Set(ByVal value As String)
            _jobNumber = value
        End Set
    End Property

    Private changeJob As Boolean = False

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Combo.GetSelectedItemValue(cboVisit) = 0 Then
            ShowMessage("Please select a Visit", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Me.Modal Then
                Me.Close()
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Combo.SetSelectedComboItem_By_Value(cboVisit, 0)
        If Me.Modal Then
            Me.Close()
        Else
            Me.Dispose()
        End If

    End Sub

    Private Sub FRMMoveParts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtJobNumber.Text = JobNumber
        UpdateVisitList(EngineerVisitId, False)
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        If changeJob Then
            Dim jobNo As String = Helper.MakeStringValid(Me.txtJobNumber.Text).Trim()
            Dim visit As EngineerVisit = DB.EngineerVisits.EngineerVisits_Get_LastForJob(0, jobNo)
            If visit Is Nothing Then
                ShowMessage("No Job Found!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                UpdateVisitList(visit.EngineerVisitID, True)
            End If
        Else
            changeJob = True
            Me.txtJobNumber.Enabled = True
            Me.btnChange.Text = "Search"
            Me.cboVisit.Enabled = False
        End If
    End Sub

    Private Sub UpdateVisitList(ByVal visitId As Integer, ByVal includeCurrentVisit As Boolean)
        Dim dt As DataTable = DB.EngineerVisits.GetFutureVisits(visitId, includeCurrentVisit)
        Dim newDt As New DataTable
        newDt.Columns.Add("ManagerID")
        newDt.Columns.Add("Name")
        Dim nr As DataRow
        For Each r As DataRow In dt.Rows
            nr = newDt.NewRow
            nr("ManagerID") = r("EngineerVisitID")
            nr("Name") = r("EngineerVisitID") & " - " & r("Engineer") & " - " & r("DateTime") & " - " & r("Notes")
            newDt.Rows.Add(nr)
        Next
        Combo.SetUpCombo(cboVisit, newDt, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select)
        Me.txtJobNumber.Enabled = False
        Me.cboVisit.Enabled = True
        Me.btnChange.Text = "Change"
        changeJob = False
    End Sub

End Class