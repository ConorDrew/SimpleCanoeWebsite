// Decompiled with JetBrains decompiler
// Type: FSM.Interfaces
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
  [StandardModule]
  public sealed class Interfaces
  {
    public interface IPersistable
    {
      string CurrentLocation { get; set; }

      string DefaultName { get; }

      bool HasBeenPersisted { get; set; }

      string PersistName { get; set; }
    }
  }
}
