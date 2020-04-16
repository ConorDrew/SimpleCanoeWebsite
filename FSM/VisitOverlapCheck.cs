// Decompiled with JetBrains decompiler
// Type: FSM.VisitOverlapCheck
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class VisitOverlapCheck : ScheduleTest
  {
    protected override string TestName
    {
      get
      {
        return "Visit Overlap";
      }
    }

    public override ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day)
    {
      if (!Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(testRow["EngineerID"], (object) 0, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(testRow["EngineerID"], (object) engineerID, false))))
        return new ScheduleTest.TestResult();
      return !Information.IsDBNull(RuntimeHelpers.GetObjectValue(testRow["StartDateTime"])) && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(testRow["EndDateTime"])) && App.DB.Scheduler.VisitOverlaps(Conversions.ToString(engineerID), Conversions.ToDate(testRow["StartDateTime"]), Conversions.ToDate(testRow["EndDateTime"])) ? new ScheduleTest.TestResult(string.Format("This visit would overlap an existing visit in the schedule"), false, false) : new ScheduleTest.TestResult();
    }
  }
}
