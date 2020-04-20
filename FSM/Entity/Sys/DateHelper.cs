// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.DateHelper
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;

namespace FSM.Entity.Sys
{
    public class DateHelper
    {
        public static int GetDays(DateTime d1, DateTime d2)
        {
            return checked((int)Math.Round((d2.Date - d1.Date).TotalDays));
        }

        public static int GetWorkingDays(DateTime Startdate, DateTime EndDate)
        {
            int num1 = 0;
            int days = (EndDate - Startdate).Days;
            DataView all = App.DB.TimeSlotRates.BankHolidays_GetAll();
            int num2 = days;
            int num3 = 0;
            while (num3 <= num2)
            {
                DayOfWeek dayOfWeek = Startdate.AddDays((double)num3).DayOfWeek;
                if (all.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Strings.Format((object)Startdate.AddDays((double)num3), "dd/MM/yyyy"))) + "'").Length <= 0 && (dayOfWeek != DayOfWeek.Saturday && (uint)dayOfWeek > 0U))
                    checked { ++num1; }
                checked { ++num3; }
            }
            return num1;
        }

        public static List<DateTime> GetWorkingDates(DateTime Startdate, DateTime EndDate)
        {
            List<DateTime> dateTimeList = new List<DateTime>();
            int days = (EndDate - Startdate).Days;
            DataView all = App.DB.TimeSlotRates.BankHolidays_GetAll();
            int num1 = days;
            int num2 = 0;
            while (num2 <= num1)
            {
                DateTime dateTime = Startdate.AddDays((double)num2);
                DayOfWeek dayOfWeek = dateTime.DayOfWeek;
                if (all.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Strings.Format((object)dateTime, "dd/MM/yyyy"))) + "'").Length <= 0 && (dayOfWeek != DayOfWeek.Saturday && (uint)dayOfWeek > 0U))
                    dateTimeList.Add(dateTime);
                checked { ++num2; }
            }
            return dateTimeList;
        }

        public static List<DateTime> GetDatesBetween(DateTime Startdate, DateTime EndDate)
        {
            List<DateTime> dateTimeList = new List<DateTime>();
            int days = (EndDate - Startdate).Days;
            int num = 0;
            while (num <= days)
            {
                DateTime dateTime = Startdate.AddDays((double)num);
                dateTimeList.Add(dateTime);
                checked { ++num; }
            }
            return dateTimeList;
        }

        public static DateTime GetFirstDayOfMonth(DateTime sourceDate)
        {
            return new DateTime(sourceDate.Year, sourceDate.Month, 1);
        }

        public static DateTime GetLastDayOfMonth(DateTime sourceDate)
        {
            return new DateTime(sourceDate.Year, sourceDate.Month, 1).AddMonths(1).AddDays(-1.0);
        }

        public static DateTime GetTheFriday(DateTime DateIn)
        {
            DateTime dateTime = default;
            switch (DateIn.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dateTime = DateIn.AddDays(-2.0);
                    break;

                case DayOfWeek.Monday:
                    dateTime = DateIn.AddDays(4.0);
                    break;

                case DayOfWeek.Tuesday:
                    dateTime = DateIn.AddDays(3.0);
                    break;

                case DayOfWeek.Wednesday:
                    dateTime = DateIn.AddDays(2.0);
                    break;

                case DayOfWeek.Thursday:
                    dateTime = DateIn.AddDays(1.0);
                    break;

                case DayOfWeek.Friday:
                    dateTime = DateIn;
                    break;

                case DayOfWeek.Saturday:
                    dateTime = DateIn.AddDays(-1.0);
                    break;
            }
            return dateTime;
        }

        public static DateTime GetTheMonday(DateTime DateIn)
        {
            DateTime dateTime = default;
            switch (DateIn.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dateTime = DateIn.AddDays(-6.0);
                    break;

                case DayOfWeek.Monday:
                    dateTime = DateIn;
                    break;

                case DayOfWeek.Tuesday:
                    dateTime = DateIn.AddDays(-1.0);
                    break;

                case DayOfWeek.Wednesday:
                    dateTime = DateIn.AddDays(-2.0);
                    break;

                case DayOfWeek.Thursday:
                    dateTime = DateIn.AddDays(-3.0);
                    break;

                case DayOfWeek.Friday:
                    dateTime = DateIn.AddDays(-4.0);
                    break;

                case DayOfWeek.Saturday:
                    dateTime = DateIn.AddDays(-5.0);
                    break;
            }
            return dateTime;
        }

        public static DateTime GetDateZeroTime(DateTime sourceDate)
        {
            return new DateTime(sourceDate.Year, sourceDate.Month, sourceDate.Day, 0, 0, 0);
        }

        public static DateTime CheckBankHolidaySatOrSun(DateTime sourceDate, bool async = false)
        {
            if (sourceDate.DayOfWeek == DayOfWeek.Sunday)
                sourceDate = DateHelper.CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, -2.0, sourceDate), async);
            if (sourceDate.DayOfWeek == DayOfWeek.Saturday)
                sourceDate = DateHelper.CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, -1.0, sourceDate), async);
            DataView dataView = async ? App.DB.TimeSlotRates.BankHolidays_GetAllAsync() : App.DB.TimeSlotRates.BankHolidays_GetAll();
            while (dataView.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Strings.Format((object)sourceDate, "dd/MM/yyyy"))) + "'").Length > 0)
                sourceDate = DateHelper.CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, -1.0, sourceDate), async);
            return sourceDate;
        }

        public static DateTime CheckBankHolidaySatOrSunForward(DateTime sourceDate, bool async = false)
        {
            if (sourceDate.DayOfWeek == DayOfWeek.Sunday)
                sourceDate = DateHelper.CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, 1.0, sourceDate), async);
            if (sourceDate.DayOfWeek == DayOfWeek.Saturday)
                sourceDate = DateHelper.CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, 2.0, sourceDate), async);
            DataView dataView = async ? App.DB.TimeSlotRates.BankHolidays_GetAllAsync() : App.DB.TimeSlotRates.BankHolidays_GetAll();
            while (dataView.Table.Select("BankHolidayDate='" + Conversions.ToString(Conversions.ToDate(Strings.Format((object)sourceDate, "dd/MM/yyyy"))) + "'").Length > 0)
                sourceDate = DateHelper.CheckBankHolidaySatOrSun(DateAndTime.DateAdd(DateInterval.Day, 1.0, sourceDate), async);
            return sourceDate;
        }

        public static double GetYearsBetween(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) + (((end.Month > start.Month) || ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }

        public static DateTime AddWorkingDays(DateTime date, int days)
        {
            return DateHelper.CheckBankHolidaySatOrSunForward(date.AddDays((double)days), true);
        }

        public static bool IsBetweenDates(string startDate, string endDate, string testDate)
        {
            return DateTime.Compare(Conversions.ToDate(testDate), Conversions.ToDate(startDate)) > 0 & DateTime.Compare(Conversions.ToDate(testDate), Conversions.ToDate(endDate)) <= 0;
        }
    }
}