Namespace Entity

    Namespace Accounts

        Public Class AccountsHelper

            Public Shared Function FormatSunDepartment(ByVal department As String) As String

                Select Case True
                    Case IsGasway
                        Return Entity.Sys.Helper.MakeIntegerValid(department).ToString("000")
                    Case Else
                        Return Entity.Sys.Helper.MakeStringValid(department)
                End Select

            End Function

            Public Shared Function GetAccountPeriod(ByVal dt As Date) As String
                Dim accMonth As Integer = dt.Month
                Dim accPeriod As String = String.Empty
                Select Case accMonth
                    Case 1 'Jan
                        accPeriod = dt.Year & "/" & "10"
                    Case 2 'Feb
                        accPeriod = dt.Year & "/" & "11"
                    Case 3 'Mar
                        accPeriod = dt.Year & "/" & "12"
                    Case 4 'Apr
                        accPeriod = dt.AddYears(1).Year & "/" & "01"
                    Case 5 'May
                        accPeriod = dt.AddYears(1).Year & "/" & "02"
                    Case 6 'Jun
                        accPeriod = dt.AddYears(1).Year & "/" & "03"
                    Case 7 'Jul
                        accPeriod = dt.AddYears(1).Year & "/" & "04"
                    Case 8 'Aug
                        accPeriod = dt.AddYears(1).Year & "/" & "05"
                    Case 9 'Sep
                        accPeriod = dt.AddYears(1).Year & "/" & "06"
                    Case 10 'Oct
                        accPeriod = dt.AddYears(1).Year & "/" & "07"
                    Case 11 'Nov
                        accPeriod = dt.AddYears(1).Year & "/" & "08"
                    Case 12 'Dec
                        accPeriod = dt.AddYears(1).Year & "/" & "09"
                End Select
                Return accPeriod
            End Function

        End Class

    End Namespace

End Namespace