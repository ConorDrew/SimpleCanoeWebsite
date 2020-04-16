// Decompiled with JetBrains decompiler
// Type: FSM.LevelsCheck
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class LevelsCheck : ScheduleTest
  {
    protected override string TestName
    {
      get
      {
        return "Levels";
      }
    }

    public override ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day)
    {
      bool cancelSchedule = false;
      DataTable table = App.DB.EngineerLevel.Get(engineerID).Table;
      List<DataRow> list = ((IEnumerable<DataRow>) table.Select("Tick = 1 AND Mandatory = 1")).ToList<DataRow>();
      DataRow[] dataRowArray1 = App.DB.Job.JobQualificationsLevels_Get(Conversions.ToInteger(testRow["JobID"])).Table.Select("Tick = 1");
      ArrayList failMessages = new ArrayList();
      DataRow[] dataRowArray2 = dataRowArray1;
      int index = 0;
      while (index < dataRowArray2.Length)
      {
        DataRow dataRow1 = dataRowArray2[index];
        bool flag = false;
        try
        {
          foreach (DataRow dataRow2 in list)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataRow1["ManagerID"], dataRow2["ManagerID"], false))
            {
              flag = true;
              break;
            }
          }
        }
        finally
        {
          List<DataRow>.Enumerator enumerator;
          enumerator.Dispose();
        }
        if (!flag)
          failMessages.Add(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "This Engineer has not got the qualification '", dataRow1["Name"]), (object) "' which is needed"));
        checked { ++index; }
      }
      if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(testRow["JobTypeID"])) == 66971)
      {
        DataRow dataRow = ((IEnumerable<DataRow>) table.Select("ManagerID =" + Conversions.ToString(71469) + " AND Tick = 1")).FirstOrDefault<DataRow>();
        if (dataRow == null)
        {
          cancelSchedule = true;
          failMessages.Add((object) "This is a QC Job, and Engineer does not have qualification");
          goto label_21;
        }
        else
          list.Add(dataRow);
      }
      try
      {
        foreach (DataRow dataRow in list)
        {
          if (DateTime.Compare(Conversions.ToDate(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataRow["DateExpires"])), (object) DateAndTime.Now.AddMinutes(1.0), (object) Conversions.ToDate(dataRow["DateExpires"]))), DateAndTime.Today) < 0)
          {
            cancelSchedule = true;
            failMessages.Add((object) "One or more mandatory qualifications have expired");
            break;
          }
        }
      }
      finally
      {
        List<DataRow>.Enumerator enumerator;
        enumerator.Dispose();
      }
label_21:
      return failMessages.Count == 0 ? new ScheduleTest.TestResult() : new ScheduleTest.TestResult(failMessages, cancelSchedule, false);
    }
  }
}
