// Decompiled with JetBrains decompiler
// Type: FSM.ISchedulerForm
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Data;
using System.Windows.Forms;

namespace FSM
{
  public interface ISchedulerForm
  {
    string Name { get; }

    string EngineerID { get; set; }

    bool IsDisposed { get; }

    PictureBox PicPlanner { get; }

    DataTable TimeSlotDt { get; set; }

    string selectedDay();

    IntPtr Handle { get; }
  }
}
