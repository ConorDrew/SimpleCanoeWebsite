// Decompiled with JetBrains decompiler
// Type: FSM.DataGridRowHeightSetter
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DataGridRowHeightSetter
  {
    private DataGrid dg;
    private ArrayList rowObjects;

    public DataGridRowHeightSetter(DataGrid dg)
    {
      this.dg = dg;
      this.InitHeights();
    }

    public int this[int row]
    {
      get
      {
        try
        {
          return Conversions.ToInteger(Conversion.Fix(RuntimeHelpers.GetObjectValue(this.rowObjects[row].GetType().GetProperty("Height").GetValue(RuntimeHelpers.GetObjectValue(this.rowObjects[row]), (object[]) null))));
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          throw new ArgumentException("invalid row index");
        }
      }
      set
      {
        try
        {
          this.rowObjects[row].GetType().GetProperty("Height").SetValue(RuntimeHelpers.GetObjectValue(this.rowObjects[row]), (object) value, (object[]) null);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          throw new ArgumentException("Invalid row index");
        }
      }
    }

    private void InitHeights()
    {
      Array array = (Array) this.dg.GetType().GetMethod("get_DataGridRows", BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy).Invoke((object) this.dg, (object[]) null);
      this.rowObjects = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = array.GetEnumerator();
        while (enumerator.MoveNext())
        {
          object objectValue = RuntimeHelpers.GetObjectValue(enumerator.Current);
          if (objectValue.ToString().EndsWith("DataGridRelationshipRow"))
            this.rowObjects.Add(RuntimeHelpers.GetObjectValue(objectValue));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }
  }
}
