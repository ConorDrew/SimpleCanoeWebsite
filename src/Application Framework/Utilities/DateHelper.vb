Imports System.Collections.Generic

Namespace Entity.Sys

    Public Class DateHelper

        ''' <summary>
        ''' Calculates the number of full days between two dates
        ''' </summary>
        ''' <param name="d1"></param>
        ''' <param name="d2"></param>
        ''' <returns>Integer</returns>
        Public Shared Function GetDays(d1 As DateTime, d2 As DateTime) As Integer
            Return (d2.Date - d1.Date).TotalDays
        End Function

        ''' <summary>
        ''' Gets the amount of working days between dates
        ''' </summary>
        ''' <param name="Startdate"></param>
        ''' <param name="EndDate"></param>
        ''' <returns></returns>
        Public Shared Function GetWorkingDays(ByVal Startdate As Date, ByVal EndDate As Date) As Integer

            Dim count As Integer = 0
            Dim totalDays As Integer = (EndDate - Startdate).Days
            Dim dvBankHolidays As DataView = DB.TimeSlotRates.BankHolidays_GetAll

            For i As Integer = 0 To totalDays
                Dim weekday As DayOfWeek = Startdate.AddDays(i).DayOfWeek
                If dvBankHolidays.Table.Select(
                        "BankHolidayDate='" & CDate(Strings.Format(Startdate.AddDays(i), "dd/MM/yyyy")) & "'").Length > 0 Then

                ElseIf weekday <> DayOfWeek.Saturday AndAlso weekday <> DayOfWeek.Sunday Then
                    count += 1
                End If

            Next
            Return count
        End Function

        ''' <summary>
        ''' Get the dates between two dates
        ''' Options to include sat/sun/bankhols
        ''' </summary>
        ''' <param name="Startdate"></param>
        ''' <param name="EndDate"></param>
        ''' <param name="incSat"></param>
        ''' <param name="incSun"></param>
        ''' <param name="incBankHols"></param>
        ''' <returns></returns>
        Public Shared Function GetWorkingDates(ByVal Startdate As Date, ByVal EndDate As Date) As List(Of Date)

            Dim dates As New List(Of Date)
            Dim totalDays As Integer = (EndDate - Startdate).Days
            Dim dvBankHolidays As DataView = DB.TimeSlotRates.BankHolidays_GetAll

            For i As Integer = 0 To totalDays
                Dim currentDate As Date = Startdate.AddDays(i)
                Dim weekday As DayOfWeek = currentDate.DayOfWeek
                If dvBankHolidays.Table.Select(
                        "BankHolidayDate='" & CDate(Strings.Format(currentDate, "dd/MM/yyyy")) & "'").Length > 0 Then
                ElseIf weekday <> DayOfWeek.Saturday AndAlso weekday <> DayOfWeek.Sunday Then
                    dates.Add(currentDate)
                End If
            Next

            Return dates
        End Function

        Public Shared Function GetDatesBetween(ByVal Startdate As DateTime, ByVal EndDate As DateTime) As List(Of DateTime)

            Dim dates As New List(Of DateTime)
            Dim totalDays As Integer = (EndDate - Startdate).Days

            For i As Integer = 0 To totalDays
                Dim currentDate As DateTime = Startdate.AddDays(i)
                dates.Add(currentDate)
            Next

            Return dates
        End Function

        ''' <summary>
        ''' Gets the first day of the month
        ''' </summary>
        ''' <param name="sourceDate"></param>
        ''' <returns></returns>
        Public Shared Function GetFirstDayOfMonth(ByVal sourceDate As DateTime) As DateTime
            Return New DateTime(sourceDate.Year, sourceDate.Month, 1)
        End Function

        ''' <summary>
        ''' Gets the last day of the month
        ''' </summary>
        ''' <param name="sourceDate"></param>
        ''' <returns></returns>
        Public Shared Function GetLastDayOfMonth(ByVal sourceDate As DateTime) As DateTime
            Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
            Return lastDay.AddMonths(1).AddDays(-1)
        End Function

        ''' <summary>
        ''' Returns the friday date within the date week
        ''' </summary>
        ''' <param name="DateIn"></param>
        ''' <returns></returns>
        Public Shared Function GetTheFriday(ByVal DateIn As DateTime) As DateTime

            Select Case DateIn.DayOfWeek
                Case DayOfWeek.Monday
                    Return DateIn.AddDays(4)
                Case DayOfWeek.Tuesday
                    Return DateIn.AddDays(3)
                Case DayOfWeek.Wednesday
                    Return DateIn.AddDays(2)
                Case DayOfWeek.Thursday
                    Return DateIn.AddDays(1)
                Case DayOfWeek.Friday
                    Return DateIn
                Case DayOfWeek.Saturday
                    Return DateIn.AddDays(-1)
                Case DayOfWeek.Sunday
                    Return DateIn.AddDays(-2)
            End Select
        End Function

        ''' <summary>
        ''' Returns the monday date within the date week
        ''' </summary>
        ''' <param name="DateIn"></param>
        ''' <returns></returns>
        Public Shared Function GetTheMonday(ByVal DateIn As DateTime) As DateTime

            Select Case DateIn.DayOfWeek
                Case DayOfWeek.Monday
                    Return DateIn
                Case DayOfWeek.Tuesday
                    Return DateIn.AddDays(-1)
                Case DayOfWeek.Wednesday
                    Return DateIn.AddDays(-2)
                Case DayOfWeek.Thursday
                    Return DateIn.AddDays(-3)
                Case DayOfWeek.Friday
                    Return DateIn.AddDays(-4)
                Case DayOfWeek.Saturday
                    Return DateIn.AddDays(-5)
                Case DayOfWeek.Sunday
                    Return DateIn.AddDays(-6)
            End Select
        End Function

        ''' <summary>
        ''' Sets time of date to midnight
        ''' </summary>
        ''' <param name="sourceDate"></param>
        ''' <returns></returns>
        Public Shared Function GetDateZeroTime(ByVal sourceDate As DateTime) As DateTime
            Return New DateTime(sourceDate.Year, sourceDate.Month, sourceDate.Day, 0, 0, 0)
        End Function

        ''' <summary>
        ''' Assess whether the date is on a bank holiday/sat/sun and returns the working day before
        ''' </summary>
        ''' <param name="sourceDate"></param>
        ''' <returns></returns>
        Public Shared Function CheckBankHolidaySatOrSun(ByVal sourceDate As DateTime, Optional ByVal async As Boolean = False) As DateTime
            If sourceDate.DayOfWeek = DayOfWeek.Sunday Then
                sourceDate = CheckBankHolidaySatOrSun(DateAdd(DateInterval.Day, -2, sourceDate), async)
            End If

            If sourceDate.DayOfWeek = DayOfWeek.Saturday Then
                sourceDate = CheckBankHolidaySatOrSun(DateAdd(DateInterval.Day, -1, sourceDate), async)
            End If

            Dim dvBankHolidays As DataView = If(async, DB.TimeSlotRates.BankHolidays_GetAllAsync, DB.TimeSlotRates.BankHolidays_GetAll)
            While dvBankHolidays.Table.Select("BankHolidayDate='" & CDate(Strings.Format(sourceDate, "dd/MM/yyyy")) & "'").Length > 0
                sourceDate = CheckBankHolidaySatOrSun(DateAdd(DateInterval.Day, -1, sourceDate), async)
            End While

            Return sourceDate
        End Function

        ''' <summary>
        ''' Assess whether the date is on a bank holiday/sat/sun and returns the working day after
        ''' </summary>
        ''' <param name="sourceDate"></param>
        ''' <returns></returns>
        Public Shared Function CheckBankHolidaySatOrSunForward(ByVal sourceDate As DateTime, Optional ByVal async As Boolean = False) As DateTime
            If sourceDate.DayOfWeek = DayOfWeek.Sunday Then
                sourceDate = CheckBankHolidaySatOrSun(DateAdd(DateInterval.Day, 1, sourceDate), async)
            End If

            If sourceDate.DayOfWeek = DayOfWeek.Saturday Then
                sourceDate = CheckBankHolidaySatOrSun(DateAdd(DateInterval.Day, 2, sourceDate), async)
            End If

            Dim dvBankHolidays As DataView = If(async, DB.TimeSlotRates.BankHolidays_GetAllAsync, DB.TimeSlotRates.BankHolidays_GetAll)
            While dvBankHolidays.Table.Select("BankHolidayDate='" & CDate(Strings.Format(sourceDate, "dd/MM/yyyy")) & "'").Length > 0
                sourceDate = CheckBankHolidaySatOrSun(DateAdd(DateInterval.Day, 1, sourceDate), async)
            End While

            Return sourceDate
        End Function

        Public Shared Function GetYearsBetween(ByVal start As DateTime, ByVal [end] As DateTime) As Double
            Return ([end].Year - start.Year - 1) + (If((([end].Month > start.Month) OrElse (([end].Month = start.Month) AndAlso ([end].Day >= start.Day))), 1, 0))
        End Function

        Public Shared Function AddWorkingDays(ByVal [date] As DateTime, ByVal days As Integer) As DateTime

            Return CheckBankHolidaySatOrSunForward([date].AddDays(days), True)
        End Function

        Public Shared Function IsBetweenDates(startDate As String, endDate As String, testDate As String) As Boolean
            Return If(CDate(testDate) > CDate(startDate) And CDate(testDate) <= CDate(endDate), True, False)
        End Function

    End Class

End Namespace