Public Class PostcodeRegionCheck
    Inherits ScheduleTest

    Protected Overrides ReadOnly Property TestName() As String
        Get
            Return "Postcode region"
        End Get
    End Property

    Public Overrides Function Test(ByVal testRow As System.Data.DataRow, ByVal engineerID As Integer, ByVal day As Date) As ScheduleTest.TestResult

        If DB.EngineerPostalRegion.Check(engineerID, testRow("Postcode1")) = 0 Then
            Return New ScheduleTest.TestResult(String.Format("This Engineer is not associated with the Postcode: {0}", testRow("Postcode1")))
        Else
            Return New ScheduleTest.TestResult
        End If

    End Function

End Class