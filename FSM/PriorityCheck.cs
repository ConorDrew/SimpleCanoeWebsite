// Decompiled with JetBrains decompiler
// Type: FSM.PriorityCheck
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class PriorityCheck : ScheduleTest
  {
    protected override string TestName
    {
      get
      {
        return "Priority Check";
      }
    }

    public override ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day)
    {
      ArrayList failMessages = new ArrayList();
      if (DateTime.Compare(Helper.MakeDateTimeValid((object) day), DateTime.MinValue) == 0 && (uint) DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(testRow["StartDateTime"])), DateTime.MinValue) > 0U)
        day = Conversions.ToDate(testRow["StartDateTime"]);
      if ((uint) DateTime.Compare(day, DateTime.MinValue) > 0U)
      {
        DateTime t1 = Helper.MakeDateTimeValid((object) day);
        DataTable forEngineerVisitId = App.DB.JobOfWorks.JobOfWork_Get_ForEngineerVisitID(Conversions.ToInteger(testRow["EngineerVisitID"]));
        if (forEngineerVisitId.Rows.Count > 0)
        {
          int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(forEngineerVisitId.Rows[0]["Priority"]));
          DateTime date = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(forEngineerVisitId.Rows[0]["JobCreatedDateTime"]));
          DateTime dateTime = DateTime.MinValue;
          switch ((Enums.JobPriority) num)
          {
            case Enums.JobPriority.PriortyOneFiveDays:
              dateTime = DateHelper.AddWorkingDays(date, 5);
              break;
            case Enums.JobPriority.EMTwentyFourHours:
            case Enums.JobPriority.EMTwentyFourHoursOOH:
              dateTime = DateHelper.AddWorkingDays(date, 1);
              break;
            case Enums.JobPriority.RoutineOneTwentyDays:
              dateTime = DateHelper.AddWorkingDays(date, 20);
              break;
            case Enums.JobPriority.PriortyThreeDays:
              dateTime = DateHelper.AddWorkingDays(date, 3);
              break;
            case Enums.JobPriority.ApptTwentyEightDays:
              dateTime = DateHelper.AddWorkingDays(date, 28);
              break;
          }
          if (DateTime.Compare(dateTime, DateTime.MinValue) != 0 && DateTime.Compare(t1, dateTime) > 0)
            failMessages.Add((object) "Visit date outside of priority, please change priority or create new job!");
        }
      }
      return failMessages.Count == 0 ? new ScheduleTest.TestResult() : new ScheduleTest.TestResult(failMessages, true, false);
    }
  }
}
