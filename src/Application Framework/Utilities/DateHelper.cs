using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.Sys
{
    public class DateHelper
    {

        /// <summary>
        /// Calculates the number of full days between two dates
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns>Integer</returns>
        public static int GetDays(DateTime d1, DateTime d2)
        {
            return Conversions.ToInteger((d2.Date - d1.Date).TotalDays);
        }

        /// <summary>
        /// Gets the amount of working days between dates
        /// </summary>
        /// <param name="Startdate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static int GetWorkingDays(DateTime Startdate, DateTime EndDate)
        {
            int count = 0;
            int totalDays = (EndDate - Startdate).Days;
            var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
            for (int i = 0, loopTo = totalDays; i <= loopTo; i++)
            {
                var weekday = Startdate.AddDays(i).DayOfWeek;
                if (dvBankHolidays.Table.Select("BankHolidayDate='" + Conversions.ToDate(Strings.Format(Startdate.AddDays(i), "dd/MM/yyyy")) + "'").Length > 0)
                {
                }
                else if (weekday != DayOfWeek.Saturday && weekday != DayOfWeek.Sunday)
                {
                    count += 1;
                }
            }

            return count;
        }

        /// <summary>
        /// Get the dates between two dates
        /// Options to include sat/sun/bankhols
        /// </summary>
        /// <param name="Startdate"></param>
        /// <param name="EndDate"></param>
        /// <param name="incSat"></param>
        /// <param name="incSun"></param>
        /// <param name="incBankHols"></param>
        /// <returns></returns>
        public static List<DateTime> GetWorkingDates(DateTime Startdate, DateTime EndDate)
        {
            var dates = new List<DateTime>();
            int totalDays = (EndDate - Startdate).Days;
            var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
            for (int i = 0, loopTo = totalDays; i <= loopTo; i++)
            {
                var currentDate = Startdate.AddDays(i);
                var weekday = currentDate.DayOfWeek;
                if (dvBankHolidays.Table.Select("BankHolidayDate='" + Conversions.ToDate(Strings.Format(currentDate, "dd/MM/yyyy")) + "'").Length > 0)
                {
                }
                else if (weekday != DayOfWeek.Saturday && weekday != DayOfWeek.Sunday)
                {
                    dates.Add(currentDate);
                }
            }

            return dates;
        }

        public static List<DateTime> GetDatesBetween(DateTime Startdate, DateTime EndDate)
        {
            var dates = new List<DateTime>();
            int totalDays = (EndDate - Startdate).Days;
            for (int i = 0, loopTo = totalDays; i <= loopTo; i++)
            {
                var currentDate = Startdate.AddDays(i);
                dates.Add(currentDate);
            }

            return dates;
        }

        /// <summary>
        /// Gets the first day of the month
        /// </summary>
        /// <param name="sourceDate"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(DateTime sourceDate)
        {
            return new DateTime(sourceDate.Year, sourceDate.Month, 1);
        }

        /// <summary>
        /// Gets the last day of the month
        /// </summary>
        /// <param name="sourceDate"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(DateTime sourceDate)
        {
            var lastDay = new DateTime(sourceDate.Year, sourceDate.Month, 1);
            return lastDay.AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Returns the friday date within the date week
        /// </summary>
        /// <param name="DateIn"></param>
        /// <returns></returns>
        public static DateTime GetTheFriday(DateTime DateIn)
        {
            var switchExpr = DateIn.DayOfWeek;
            switch (switchExpr)
            {
                case DayOfWeek.Monday:
                    {
                        return DateIn.AddDays(4);
                    }

                case DayOfWeek.Tuesday:
                    {
                        return DateIn.AddDays(3);
                    }

                case DayOfWeek.Wednesday:
                    {
                        return DateIn.AddDays(2);
                    }

                case DayOfWeek.Thursday:
                    {
                        return DateIn.AddDays(1);
                    }

                case DayOfWeek.Friday:
                    {
                        return DateIn;
                    }

                case DayOfWeek.Saturday:
                    {
                        return DateIn.AddDays(-1);
                    }

                case DayOfWeek.Sunday:
                    {
                        return DateIn.AddDays(-2);
                    }
            }

            return default;
        }

        /// <summary>
        /// Returns the monday date within the date week
        /// </summary>
        /// <param name="DateIn"></param>
        /// <returns></returns>
        public static DateTime GetTheMonday(DateTime DateIn)
        {
            var switchExpr = DateIn.DayOfWeek;
            switch (switchExpr)
            {
                case DayOfWeek.Monday:
                    {
                        return DateIn;
                    }

                case DayOfWeek.Tuesday:
                    {
                        return DateIn.AddDays(-1);
                    }

                case DayOfWeek.Wednesday:
                    {
                        return DateIn.AddDays(-2);
                    }

                case DayOfWeek.Thursday:
                    {
                        return DateIn.AddDays(-3);
                    }

                case DayOfWeek.Friday:
                    {
                        return DateIn.AddDays(-4);
                    }

                case DayOfWeek.Saturday:
                    {
                        return DateIn.AddDays(-5);
                    }

                case DayOfWeek.Sunday:
                    {
                        return DateIn.AddDays(-6);
                    }
            }

            return default;
        }

        /// <summary>
        /// Sets time of date to midnight
        /// </summary>
        /// <param name="sourceDate"></param>
        /// <returns></returns>
        public static DateTime GetDateZeroTime(DateTime sourceDate)
        {
            return new DateTime(sourceDate.Year, sourceDate.Month, sourceDate.Day, 0, 0, 0);
        }

        /// <summary>
        /// Assess whether the date is on a bank holiday/sat/sun and returns the working day before
        /// </summary>
        /// <param name="sourceDate"></param>
        /// <returns></returns>
        public static DateTime CheckBankHolidaySatOrSun(DateTime sourceDate, bool async = false)
        {
            if (sourceDate.DayOfWeek == DayOfWeek.Sunday)
            {
                sourceDate = CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, -2, sourceDate), async);
            }

            if (sourceDate.DayOfWeek == DayOfWeek.Saturday)
            {
                sourceDate = CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, -1, sourceDate), async);
            }

            var dvBankHolidays = async ? App.DB.TimeSlotRates.BankHolidays_GetAllAsync() : App.DB.TimeSlotRates.BankHolidays_GetAll();
            while (dvBankHolidays.Table.Select("BankHolidayDate='" + Conversions.ToDate(Strings.Format(sourceDate, "dd/MM/yyyy")) + "'").Length > 0)
                sourceDate = CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, -1, sourceDate), async);
            return sourceDate;
        }

        /// <summary>
        /// Assess whether the date is on a bank holiday/sat/sun and returns the working day after
        /// </summary>
        /// <param name="sourceDate"></param>
        /// <returns></returns>
        public static DateTime CheckBankHolidaySatOrSunForward(DateTime sourceDate, bool async = false)
        {
            if (sourceDate.DayOfWeek == DayOfWeek.Sunday)
            {
                sourceDate = CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, 1, sourceDate), async);
            }

            if (sourceDate.DayOfWeek == DayOfWeek.Saturday)
            {
                sourceDate = CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, 2, sourceDate), async);
            }

            var dvBankHolidays = async ? App.DB.TimeSlotRates.BankHolidays_GetAllAsync() : App.DB.TimeSlotRates.BankHolidays_GetAll();
            while (dvBankHolidays.Table.Select("BankHolidayDate='" + Conversions.ToDate(Strings.Format(sourceDate, "dd/MM/yyyy")) + "'").Length > 0)
                sourceDate = CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, 1, sourceDate), async);
            return sourceDate;
        }

        public static double GetYearsBetween(DateTime start, DateTime end)
        {
            return end.Year - start.Year - 1 + (end.Month > start.Month || end.Month == start.Month && end.Day >= start.Day ? 1 : 0);
        }

        public static DateTime AddWorkingDays(DateTime date, int days)
        {
            return CheckBankHolidaySatOrSunForward(date.AddDays(days), true);
        }

        public static bool IsBetweenDates(string startDate, string endDate, string testDate)
        {
            return Conversions.ToDate(testDate) > Conversions.ToDate(startDate) & Conversions.ToDate(testDate) <= Conversions.ToDate(endDate) ? true : false;
        }
    }
}