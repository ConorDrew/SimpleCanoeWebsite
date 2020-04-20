Imports FSM.Entity.JobOfWorks
Imports FSM.Entity.Jobs
Imports FSM.Entity.Sys

Public Class PriorityCheck
    Inherits ScheduleTest

    Protected Overrides ReadOnly Property TestName() As String
        Get
            Return "Priority Check"
        End Get
    End Property

    Public Overrides Function Test(ByVal testRow As DataRow,
                                   ByVal engineerID As Integer,
                                   ByVal day As Date) As ScheduleTest.TestResult
        Dim errorMsg As New ArrayList

        If Helper.MakeDateTimeValid(day) = Nothing Then
            If Not Helper.MakeDateTimeValid(testRow("StartDateTime")) = Nothing Then
                day = testRow("StartDateTime")
            End If
        End If

        If day <> Nothing Then
            Dim visitDate As DateTime = Helper.MakeDateTimeValid(day)
            Dim dtJobOfWork As DataTable = DB.JobOfWorks.JobOfWork_Get_ForEngineerVisitID(testRow("EngineerVisitID"))
            If dtJobOfWork.Rows.Count > 0 Then
                Dim priority As Integer = Helper.MakeIntegerValid(dtJobOfWork.Rows(0)("Priority"))
                Dim jobCreatedDateTime As DateTime = Helper.MakeDateTimeValid(dtJobOfWork.Rows(0)("JobCreatedDateTime"))

                Dim lastVisitDate As DateTime = Nothing
                Select Case CType(priority, Enums.JobPriority)
                    Case Enums.JobPriority.PriortyOneFiveDays
                        lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 5)

                    Case Enums.JobPriority.EMTwentyFourHours, Enums.JobPriority.EMTwentyFourHoursOOH
                        lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 1)

                    Case Enums.JobPriority.RoutineOneTwentyDays
                        lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 20)

                    Case Enums.JobPriority.PriortyThreeDays
                        lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 3)

                    Case Enums.JobPriority.ApptTwentyEightDays
                        lastVisitDate = DateHelper.AddWorkingDays(jobCreatedDateTime, 28)

                End Select

                If lastVisitDate <> Nothing AndAlso visitDate > lastVisitDate Then
                    errorMsg.Add("Visit date outside of priority, please change priority or create new job!")
                End If
            End If
        End If

        If errorMsg.Count = 0 Then
            Return New ScheduleTest.TestResult
        Else
            Return New ScheduleTest.TestResult(errorMsg, True, False)
        End If

    End Function

End Class