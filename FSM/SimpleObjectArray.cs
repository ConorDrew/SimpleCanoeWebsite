// Decompiled with JetBrains decompiler
// Type: FSM.SimpleObjectArray
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class SimpleObjectArray
  {
    internal object[] array;

    public virtual void AddNew(object item)
    {
      int index = !Information.IsNothing((object) this.array) ? checked (this.array.GetUpperBound(0) + 1) : 0;
      // ISSUE: variable of a reference type
      object[]& local;
      // ISSUE: explicit reference operation
      object[] objArray = (object[]) Utils.CopyArray((Array) ^(local = ref this.array), (Array) new object[checked (index + 1)]);
      local = objArray;
      this.array[index] = RuntimeHelpers.GetObjectValue(item);
    }

    public bool get_Exists(object item)
    {
      if (this.array == null)
        return false;
      int num = checked (this.array.Length - 1);
      int index = 0;
      while (index <= num)
      {
        Debug.WriteLine(this.array[index].ToString());
        checked { ++index; }
      }
      return Array.IndexOf<object>(this.array, RuntimeHelpers.GetObjectValue(item)) > -1;
    }

    public int Count
    {
      get
      {
        return Information.IsNothing((object) this.array) ? 0 : checked (this.UpperBound + 1);
      }
    }

    public virtual object this[int index]
    {
      get
      {
        if (index < 0 | index > this.UpperBound)
          throw new IndexOutOfRangeException();
        return this.array[index];
      }
    }

    private int UpperBound
    {
      get
      {
        return this.array != null ? this.array.GetUpperBound(0) : 0;
      }
    }
  }
}
