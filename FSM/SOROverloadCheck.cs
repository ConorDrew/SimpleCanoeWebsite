// Decompiled with JetBrains decompiler
// Type: FSM.SOROverloadCheck
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.MaxEngineerTimes;
using FSM.Entity.Sys;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class SOROverloadCheck : ScheduleTest
  {
    protected override string TestName
    {
      get
      {
        return "SOR Overload";
      }
    }

    public override ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day)
    {
      if ((uint) DateTime.Compare(day, DateTime.MinValue) <= 0U)
        return new ScheduleTest.TestResult();
      int num1 = 0;
      MaxEngineerTime forEngineer = App.DB.MaxEngineerTime.MaxEngineerTime_GetForEngineer(engineerID);
      if (forEngineer != null)
      {
        switch (day.DayOfWeek)
        {
          case DayOfWeek.Sunday:
            num1 = forEngineer.SundayValue;
            break;
          case DayOfWeek.Monday:
            num1 = forEngineer.MondayValue;
            break;
          case DayOfWeek.Tuesday:
            num1 = forEngineer.TuesdayValue;
            break;
          case DayOfWeek.Wednesday:
            num1 = forEngineer.WednesdayValue;
            break;
          case DayOfWeek.Thursday:
            num1 = forEngineer.ThursdayValue;
            break;
          case DayOfWeek.Friday:
            num1 = forEngineer.FridayValue;
            break;
          case DayOfWeek.Saturday:
            num1 = forEngineer.SaturdayValue;
            break;
        }
      }
      DataTable forEngineerAndDay = App.DB.Scheduler.SORTime_GetForEngineerAndDay(engineerID, day);
      int num2 = 0;
      if (forEngineerAndDay.Rows.Count > 0)
        num2 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(forEngineerAndDay.Rows[0]["TotalDaySOR"]));
      return checked (num2 + Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(testRow["summedSOR"]))) > num1 ? new ScheduleTest.TestResult(string.Format("The SOR time total will overload this engineers time for the day"), false, true) : new ScheduleTest.TestResult();
    }
  }
}
