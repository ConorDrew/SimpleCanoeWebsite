// Decompiled with JetBrains decompiler
// Type: FSM.RegionCheck
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class RegionCheck : ScheduleTest
  {
    protected override string TestName
    {
      get
      {
        return "Region";
      }
    }

    public override ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day)
    {
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual((object) App.DB.Engineer.Engineer_Get(engineerID).RegionID, testRow["RegionID"], false) ? new ScheduleTest.TestResult(string.Format("This Engineer is not associated with the region: {0}", RuntimeHelpers.GetObjectValue(testRow["Region"])), false, false) : new ScheduleTest.TestResult();
    }
  }
}
