// Decompiled with JetBrains decompiler
// Type: FSM.PostcodeRegionCheck
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class PostcodeRegionCheck : ScheduleTest
  {
    protected override string TestName
    {
      get
      {
        return "Postcode region";
      }
    }

    public override ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day)
    {
      return -(App.DB.EngineerPostalRegion.Check(engineerID, Conversions.ToString(testRow["Postcode1"])) ? 1 : 0) == 0 ? new ScheduleTest.TestResult(string.Format("This Engineer is not associated with the Postcode: {0}", RuntimeHelpers.GetObjectValue(testRow["Postcode1"])), false, false) : new ScheduleTest.TestResult();
    }
  }
}
