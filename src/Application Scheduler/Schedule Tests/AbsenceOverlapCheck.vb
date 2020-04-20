Public Class AbsenceOverlapCheck
    Inherits ScheduleTest

    Protected Overrides ReadOnly Property TestName() As String
        Get
            Return "Absence Overlap"
        End Get
    End Property

    Public Overrides Function Test(ByVal testRow As System.Data.DataRow, _
                                   ByVal engineerID As Integer, _
                                   ByVal day As Date) As ScheduleTest.TestResult


        If Entity.Sys.Helper.MakeDateTimeValid(day) = Nothing Then
            If Not Entity.Sys.Helper.MakeDateTimeValid(testRow.Item("StartDateTime")) = Nothing Then
                day = testRow.Item("StartDateTime")
            End If
        End If

        If Not Entity.Sys.Helper.MakeDateTimeValid(day) = Nothing Then
            If DB.Scheduler.AbsenceOverlap(engineerID, day) = True Then
                Return New ScheduleTest.TestResult(String.Format("WARNING: This visit may overlap an absence in the schedule"))
            Else
                Return New ScheduleTest.TestResult
            End If
        Else
            Return New ScheduleTest.TestResult
        End If



    End Function
End Class
