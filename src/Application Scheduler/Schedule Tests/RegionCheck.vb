Public Class RegionCheck
    Inherits ScheduleTest

    Protected Overrides ReadOnly Property TestName() As String
        Get
            Return "Region"
        End Get
    End Property

    Public Overrides Function Test(ByVal testRow As System.Data.DataRow, _
                                   ByVal engineerID As Integer, _
                                   ByVal day As Date) As ScheduleTest.TestResult

        Dim engineer As Entity.Engineers.Engineer = DB.Engineer.Engineer_Get(engineerID)

        If engineer.RegionID <> testRow("RegionID") Then
            Return New ScheduleTest.TestResult(String.Format("This Engineer is not associated with the region: {0}", testRow("Region")))
        Else
            Return New ScheduleTest.TestResult
        End If

    End Function
End Class
