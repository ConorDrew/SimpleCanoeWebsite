// Decompiled with JetBrains decompiler
// Type: FSM.AbsenceOverlapCheck
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class AbsenceOverlapCheck : ScheduleTest
  {
    protected override string TestName
    {
      get
      {
        return "Absence Overlap";
      }
    }

    public override ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day)
    {
      if (DateTime.Compare(Helper.MakeDateTimeValid((object) day), DateTime.MinValue) == 0 && (uint) DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(testRow["StartDateTime"])), DateTime.MinValue) > 0U)
        day = Conversions.ToDate(testRow["StartDateTime"]);
      if ((uint) DateTime.Compare(Helper.MakeDateTimeValid((object) day), DateTime.MinValue) <= 0U)
        return new ScheduleTest.TestResult();
      return App.DB.Scheduler.AbsenceOverlap(Conversions.ToString(engineerID), day) ? new ScheduleTest.TestResult(string.Format("WARNING: This visit may overlap an absence in the schedule"), false, false) : new ScheduleTest.TestResult();
    }
  }
}
