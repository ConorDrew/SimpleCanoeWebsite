Public Class DueDateCheck
    Inherits ScheduleTest

    Protected Overrides ReadOnly Property TestName() As String
        Get
            Return "Due date"
        End Get
    End Property

    Public Overrides Function Test(ByVal testRow As System.Data.DataRow, _
                                   ByVal engineerID As Integer, _
                                   ByVal day As Date) As ScheduleTest.TestResult

        If testRow.Table.Columns.Contains("DueDate") Then
            If Entity.Sys.Helper.MakeDateTimeValid(day).Date = Nothing Then
                Return New ScheduleTest.TestResult
            Else
                If Entity.Sys.Helper.MakeDateTimeValid(testRow.Item("DueDate")) = Nothing Then
                    Return New ScheduleTest.TestResult
                Else
                    If Entity.Sys.Helper.MakeDateTimeValid(testRow.Item("DueDate")).Date = Entity.Sys.Helper.MakeDateTimeValid(day).Date Then
                        Return New ScheduleTest.TestResult
                    Else
                        Return New ScheduleTest.TestResult(String.Format("You are about to schedule the visit on a different date to the due date: " & Format(Entity.Sys.Helper.MakeDateTimeValid(testRow.Item("DueDate")).Date, "dd/MM/yyyy")))
                    End If
                End If
            End If
        Else
            Return New ScheduleTest.TestResult
        End If
    End Function
End Class
