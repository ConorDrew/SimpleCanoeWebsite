// Decompiled with JetBrains decompiler
// Type: FSM.DataGridSiteFuelColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DataGridSiteFuelColumn : DataGridLabelColumn
  {
    protected override void Paint(
      Graphics g,
      Rectangle bounds,
      CurrencyManager source,
      int rowNum,
      Brush backBrush,
      Brush foreBrush,
      bool alignToRight)
    {
      DataRow dataRow = (DataRow) NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null);
      if (dataRow.Table.Columns.Contains("LastServiceDate"))
      {
        DateTime t1_1 = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["LastServiceDate"]));
        if (DateTime.Compare(t1_1, DateTime.MinValue) != 0 && DateTime.Compare(t1_1, SqlDateTime.MinValue.Value.AddYears(1)) > 0)
        {
          if (DateTime.Compare(t1_1, DateAndTime.Now.AddDays(-365.0)) <= 0)
          {
            backBrush = Brushes.Black;
            foreBrush = Brushes.Yellow;
          }
          else
          {
            int num1 = DateTime.Compare(t1_1, DateAndTime.Now.AddDays(-352.0)) <= 0 ? 1 : 0;
            DateTime t1_2 = t1_1;
            DateTime now = DateAndTime.Now;
            DateTime t2_1 = now.AddDays(-365.0);
            int num2 = DateTime.Compare(t1_2, t2_1) > 0 ? 1 : 0;
            if ((num1 & num2) != 0)
            {
              backBrush = Brushes.Red;
            }
            else
            {
              DateTime t1_3 = t1_1;
              now = DateAndTime.Now;
              DateTime t2_2 = now.AddDays(-330.0);
              int num3 = DateTime.Compare(t1_3, t2_2) <= 0 ? 1 : 0;
              DateTime t1_4 = t1_1;
              now = DateAndTime.Now;
              DateTime t2_3 = now.AddDays(-352.0);
              int num4 = DateTime.Compare(t1_4, t2_3) > 0 ? 1 : 0;
              if ((num3 & num4) != 0)
              {
                backBrush = Brushes.Orange;
              }
              else
              {
                DateTime t1_5 = t1_1;
                now = DateAndTime.Now;
                DateTime t2_4 = now.AddDays(-309.0);
                int num5 = DateTime.Compare(t1_5, t2_4) <= 0 ? 1 : 0;
                DateTime t1_6 = t1_1;
                now = DateAndTime.Now;
                DateTime t2_5 = now.AddDays(-330.0);
                int num6 = DateTime.Compare(t1_6, t2_5) > 0 ? 1 : 0;
                if ((num5 & num6) != 0)
                {
                  backBrush = Brushes.Yellow;
                }
                else
                {
                  DateTime t1_7 = t1_1;
                  now = DateAndTime.Now;
                  DateTime t2_6 = now.AddDays(-281.0);
                  int num7 = DateTime.Compare(t1_7, t2_6) <= 0 ? 1 : 0;
                  DateTime t1_8 = t1_1;
                  now = DateAndTime.Now;
                  DateTime t2_7 = now.AddDays(-309.0);
                  int num8 = DateTime.Compare(t1_8, t2_7) > 0 ? 1 : 0;
                  backBrush = (num7 & num8) == 0 ? backBrush : Brushes.PaleGreen;
                }
              }
            }
          }
        }
      }
      base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
    }
  }
}
