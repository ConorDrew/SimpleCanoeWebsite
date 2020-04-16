// Decompiled with JetBrains decompiler
// Type: FSM.SimpleObjectArrayByKey
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Runtime.CompilerServices;

namespace FSM
{
  public class SimpleObjectArrayByKey : SimpleObjectArray
  {
    private SimpleStringArray myKeys;

    public SimpleObjectArrayByKey()
    {
      this.myKeys = new SimpleStringArray();
    }

    public virtual void AddNew(string Key, object item)
    {
      this.myKeys.AddNew(Key);
      this.AddNew(RuntimeHelpers.GetObjectValue(item));
    }

    public virtual bool get_Exists(string key)
    {
      return this.myKeys.get_Exists(key);
    }

    public object this[string key]
    {
      get
      {
        return this[Array.IndexOf<string>(this.myKeys.array, key)];
      }
    }
  }
}
