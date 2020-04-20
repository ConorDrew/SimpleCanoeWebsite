Public Class FRMAbsenceColourKey

    Private Sub FRMAbsenceColourKey_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        setUpDg()
        dgAbsences.DataSource = DB.EngineerAbsence.EngineerAbsenceTypes_GetAll()
    End Sub
    Private Sub setUpDg()
        SetUpSchedulerDataGrid(dgAbsences, False)

        Dim tsSummary As DataGridTableStyle = dgAbsences.TableStyles(0)

        Dim absence As New frmEngineerSchedule.unavailableBar
        absence.Format = ""
        absence.FormatInfo = Nothing
        absence.HeaderText = "Colour"
        absence.MappingName = "AbsenceColumn"
        absence.ReadOnly = True
        absence.Width = 60
        absence.NullText = ""
        tsSummary.GridColumnStyles.Add(absence)


        Dim Description As New DataGridLabelColumn
        Description.MappingName = "Description"
        Description.HeaderText = "Absence Type"
        Description.ReadOnly = True
        Description.Alignment = HorizontalAlignment.Center
        Description.Width = 100
        tsSummary.GridColumnStyles.Add(Description)

        tsSummary.MappingName = "tblEngineerAbsenceTypes"

    End Sub
End Class