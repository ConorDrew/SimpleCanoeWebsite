// Decompiled with JetBrains decompiler
// Type: FSM.SimpleBooleanArray
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;

namespace FSM
{
  public class SimpleBooleanArray
  {
    internal bool[] array;

    public virtual void AddNew(bool item)
    {
      int index = !Information.IsNothing((object) this.array) ? checked (this.array.GetUpperBound(0) + 1) : 0;
      // ISSUE: variable of a reference type
      bool[]& local;
      // ISSUE: explicit reference operation
      bool[] flagArray = (bool[]) Utils.CopyArray((Array) ^(local = ref this.array), (Array) new bool[checked (index + 1)]);
      local = flagArray;
      this.array[index] = item;
    }

    public bool get_Exists(bool item)
    {
      return this.array != null && Array.IndexOf<bool>(this.array, item) > -1;
    }

    public int Count
    {
      get
      {
        return Information.IsNothing((object) this.array) ? 0 : checked (this.UpperBound + 1);
      }
    }

    public virtual string this[bool index]
    {
      get
      {
        if (-(index ? 1 : 0) < 0 | -(index ? 1 : 0) > this.UpperBound)
          throw new IndexOutOfRangeException();
        return Conversions.ToString(this.array[-(index ? 1 : 0)]);
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
