// Decompiled with JetBrains decompiler
// Type: FSM.MySettings
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FSM
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal sealed class MySettings : ApplicationSettingsBase
  {
    private static MySettings defaultInstance = (MySettings) SettingsBase.Synchronized((SettingsBase) new MySettings());

    public static MySettings Default
    {
      get
      {
        MySettings defaultInstance = MySettings.defaultInstance;
        return defaultInstance;
      }
    }

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [SpecialSetting(SpecialSetting.ConnectionString)]
    [DefaultSettingValue("Data Source=BLUEPLEX\\MSDE;Initial Catalog=FSM;Integrated Security=True")]
    public string FSM
    {
      get
      {
        return Conversions.ToString(this[nameof (FSM)]);
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool FirstRun
    {
      get
      {
        return Conversions.ToBoolean(this[nameof (FirstRun)]);
      }
      set
      {
        this[nameof (FirstRun)] = (object) value;
      }
    }
  }
}
