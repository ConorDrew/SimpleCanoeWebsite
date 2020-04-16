// Decompiled with JetBrains decompiler
// Type: FSM.SimpleStringArrayOld
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
  public class SimpleStringArrayOld : SimpleObjectArray
  {
    public virtual void AddNew(string @string)
    {
      this.AddNew((object) @string);
    }

    public virtual string this[int index]
    {
      get
      {
        return Conversions.ToString(base[index]);
      }
    }
  }
}
