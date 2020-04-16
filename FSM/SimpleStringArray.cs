// Decompiled with JetBrains decompiler
// Type: FSM.SimpleStringArray
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;

namespace FSM
{
  public class SimpleStringArray
  {
    internal string[] array;

    public virtual void AddNew(string item)
    {
      int index = !Information.IsNothing((object) this.array) ? checked (this.array.GetUpperBound(0) + 1) : 0;
      // ISSUE: variable of a reference type
      string[]& local;
      // ISSUE: explicit reference operation
      string[] strArray = (string[]) Utils.CopyArray((Array) ^(local = ref this.array), (Array) new string[checked (index + 1)]);
      local = strArray;
      this.array[index] = item;
    }

    public bool get_Exists(string item)
    {
      return this.array != null && Array.IndexOf<string>(this.array, item) > -1;
    }

    public int Count
    {
      get
      {
        return Information.IsNothing((object) this.array) ? 0 : checked (this.UpperBound + 1);
      }
    }

    public virtual string this[int index]
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
