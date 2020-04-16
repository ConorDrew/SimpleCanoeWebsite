// Decompiled with JetBrains decompiler
// Type: FSM.My.MySettingsProperty
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FSM.My
{
  [StandardModule]
  [HideModuleName]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal sealed class MySettingsProperty
  {
    [HelpKeyword("My.Settings")]
    internal static MySettings Settings
    {
      get
      {
        MySettings mySettings = MySettings.Default;
        return mySettings;
      }
    }
  }
}
