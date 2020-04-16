// Decompiled with JetBrains decompiler
// Type: FSM.DueDateCheck
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class DueDateCheck : ScheduleTest
  {
    protected override string TestName
    {
      get
      {
        return "Due date";
      }
    }

    public override ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day)
    {
      if (!testRow.Table.Columns.Contains("DueDate"))
        return new ScheduleTest.TestResult();
      if (DateTime.Compare(Helper.MakeDateTimeValid((object) day).Date, DateTime.MinValue) == 0)
        return new ScheduleTest.TestResult();
      if (DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(testRow["DueDate"])), DateTime.MinValue) == 0)
        return new ScheduleTest.TestResult();
      return DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(testRow["DueDate"])).Date, Helper.MakeDateTimeValid((object) day).Date) == 0 ? new ScheduleTest.TestResult() : new ScheduleTest.TestResult(string.Format("You are about to schedule the visit on a different date to the due date: " + Strings.Format((object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(testRow["DueDate"])).Date, "dd/MM/yyyy")), false, false);
    }
  }
}
