// Decompiled with JetBrains decompiler
// Type: FSM.DataGridContractColumn
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DataGridContractColumn : DataGridLabelColumn
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
      bool flag1 = false;
      if (dataRow.Table.Columns.Contains("Renewed"))
      {
        string Left = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Renewed"]));
        flag1 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Renewed", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Transfered", false) == 0;
      }
      bool flag2 = false;
      if (dataRow.Table.Columns.Contains("ContactMade"))
        flag2 = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataRow["ContactMade"]));
      backBrush = !(!flag1 & !flag2) ? (!(!flag1 & flag2) ? backBrush : Brushes.Yellow) : Brushes.Red;
      base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
    }
  }
}
