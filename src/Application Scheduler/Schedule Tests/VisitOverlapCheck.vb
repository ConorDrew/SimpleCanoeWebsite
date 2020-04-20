Public Class VisitOverlapCheck
    Inherits ScheduleTest

    Protected Overrides ReadOnly Property TestName() As String
        Get
            Return "Visit Overlap"
        End Get
    End Property

    Public Overrides Function Test(ByVal testRow As System.Data.DataRow, _
                                   ByVal engineerID As Integer, _
                                   ByVal day As Date) As ScheduleTest.TestResult


        If testRow.Item("EngineerID") = 0 Or testRow.Item("EngineerID") = engineerID Then

            If IsDBNull(testRow("StartDateTime")) = False AndAlso IsDBNull(testRow("EndDateTime")) = False AndAlso DB.Scheduler.VisitOverlaps(engineerID, testRow("StartDateTime"), testRow("EndDateTime")) = True Then
                Return New ScheduleTest.TestResult(String.Format("This visit would overlap an existing visit in the schedule"))
            Else
                Return New ScheduleTest.TestResult
            End If
        Else

            Return New ScheduleTest.TestResult
        End If


    End Function
End Class
