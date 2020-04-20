Public Class SOROverloadCheck
    Inherits ScheduleTest

    Protected Overrides ReadOnly Property TestName() As String
        Get
            Return "SOR Overload"
        End Get
    End Property

    Public Overrides Function Test(ByVal testRow As System.Data.DataRow,
                                   ByVal engineerID As Integer,
                                   ByVal day As Date) As ScheduleTest.TestResult

        If Not day = Nothing Then
            Dim freeMins As Integer = 0
            Dim maxTimes As Entity.MaxEngineerTimes.MaxEngineerTime = DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(engineerID)

            If Not maxTimes Is Nothing Then
                Select Case day.DayOfWeek
                    Case DayOfWeek.Monday
                        freeMins = maxTimes.MondayValue
                    Case DayOfWeek.Tuesday
                        freeMins = maxTimes.TuesdayValue
                    Case DayOfWeek.Wednesday
                        freeMins = maxTimes.WednesdayValue
                    Case DayOfWeek.Thursday
                        freeMins = maxTimes.ThursdayValue
                    Case DayOfWeek.Friday
                        freeMins = maxTimes.FridayValue
                    Case DayOfWeek.Saturday
                        freeMins = maxTimes.SaturdayValue
                    Case DayOfWeek.Sunday
                        freeMins = maxTimes.SundayValue
                End Select
            End If

            Dim dtSOR As DataTable = DB.Scheduler.SORTime_GetForEngineerAndDay(engineerID, day)
            Dim totalDaySOR As Integer = 0
            If dtSOR.Rows.Count > 0 Then
                totalDaySOR = Entity.Sys.Helper.MakeIntegerValid(dtSOR.Rows(0).Item("TotalDaySOR"))
            End If

            If totalDaySOR + Entity.Sys.Helper.MakeIntegerValid(testRow("summedSOR")) > freeMins Then
                Return New ScheduleTest.TestResult(String.Format("The SOR time total will overload this engineers time for the day"), False, True)
            Else
                Return New ScheduleTest.TestResult
            End If
        Else
            Return New ScheduleTest.TestResult
        End If

    End Function

End Class