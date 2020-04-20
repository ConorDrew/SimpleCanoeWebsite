Imports FSM.Entity.Sys.Enums
Imports FSM.Entity.Sys.Helper
Imports System.Collections.Generic
Imports System.Linq

Public Class LevelsCheck
    Inherits ScheduleTest

    Protected Overrides ReadOnly Property TestName() As String
        Get
            Return "Levels"
        End Get
    End Property

    Public Overrides Function Test(ByVal testRow As System.Data.DataRow,
                                   ByVal engineerID As Integer,
                                   ByVal day As Date) As ScheduleTest.TestResult
        Dim cancelSchedule As Boolean = False
        Dim levels As DataTable = DB.EngineerLevel.Get(engineerID).Table
        Dim levelsGot As List(Of DataRow) = levels.Select("Tick = 1 AND Mandatory = 1").ToList()
        Dim levelsNeeded As DataRow() = DB.Job.JobQualificationsLevels_Get(testRow("JobID")).Table.Select("Tick = 1")

        Dim levelMessages As New ArrayList
        For Each levelNeeded As DataRow In levelsNeeded
            Dim found As Boolean = False
            For Each levelGot As DataRow In levelsGot
                If levelNeeded.Item("ManagerID") = levelGot.Item("ManagerID") Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                levelMessages.Add("This Engineer has not got the qualification '" & levelNeeded.Item("Name") & "' which is needed")
            End If
        Next

        If MakeIntegerValid(testRow("JobTypeID")) = CInt(JobTypes.QualityControl) Then
            Dim levelAuditor As DataRow = levels.Select("ManagerID =" & CInt(EngineerQual.AUDITOR) & " AND Tick = 1").FirstOrDefault()
            If levelAuditor Is Nothing Then
                cancelSchedule = True
                levelMessages.Add("This is a QC Job, and Engineer does not have qualification")
                GoTo failure
            Else
                levelsGot.Add(levelAuditor)
            End If
        End If

        For Each levelGot As DataRow In levelsGot
            Dim expDate As Date = IIf(IsDBNull(levelGot.Item("DateExpires")), Now.AddMinutes(1), CDate(levelGot.Item("DateExpires")))
            If expDate < CDate(Today) Then
                cancelSchedule = True
                levelMessages.Add("One or more mandatory qualifications have expired")
                Exit For
            End If
        Next
failure:
        If levelMessages.Count = 0 Then
            Return New ScheduleTest.TestResult
        Else
            Return New ScheduleTest.TestResult(levelMessages, cancelSchedule)
        End If
    End Function

End Class