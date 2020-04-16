// Decompiled with JetBrains decompiler
// Type: FSM.IForm
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;

namespace FSM
{
  public interface IForm
  {
    void LoadMe(object sender, EventArgs e);

    IUserControl LoadedControl { get; }

    void ResetMe(int newID);
  }
}
