// Decompiled with JetBrains decompiler
// Type: FSM.ValidatorMessages
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;

namespace FSM
{
  public class ValidatorMessages
  {
    private ArrayList _criticalMessages;
    private ArrayList _warningMessages;

    public ArrayList CriticalMessages
    {
      get
      {
        return this._criticalMessages;
      }
    }

    public ArrayList WarningMessages
    {
      get
      {
        return this._warningMessages;
      }
    }

    public ValidatorMessages()
    {
      this._criticalMessages = new ArrayList();
      this._warningMessages = new ArrayList();
    }
  }
}
