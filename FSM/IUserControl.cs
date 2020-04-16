// Decompiled with JetBrains decompiler
// Type: FSM.IUserControl
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;

namespace FSM
{
  public interface IUserControl
  {
    void LoadForm(object sender, EventArgs e);

    object LoadedItem { get; }

    event IUserControl.RecordsChangedEventHandler RecordsChanged;

    event IUserControl.StateChangedEventHandler StateChanged;

    void Populate(int ID = 0);

    bool Save();

    delegate void RecordsChangedEventHandler(
      DataView dv,
      Enums.PageViewing pageIn,
      bool FromASave,
      bool FromADelete,
      string extraText);

    delegate void StateChangedEventHandler(int newID);
  }
}
