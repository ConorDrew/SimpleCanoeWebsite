// Decompiled with JetBrains decompiler
// Type: FSM.IBaseForm
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Windows.Forms;

namespace FSM
{
  public interface IBaseForm
  {
    ArrayList FormButtons { get; set; }

    void LoadForm(object sender, EventArgs e, IForm frm);

    void LoadForm(Form frm);

    void LoopControls(Control controlToLoop);

    void SetupButtonMouseOvers();

    void CreateHover(object sender, EventArgs e);

    Array SetFormParameters { set; }

    object get_GetParameter(int indexOfArrayToGet = 0);

    int GetParameterCount { get; }
  }
}
