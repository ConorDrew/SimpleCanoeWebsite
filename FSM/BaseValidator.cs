// Decompiled with JetBrains decompiler
// Type: FSM.BaseValidator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;

namespace FSM
{
  public class BaseValidator
  {
    protected ValidatorMessages _validatorMessages;

    public ValidatorMessages ValidatorMessages
    {
      get
      {
        return this._validatorMessages;
      }
      set
      {
        this._validatorMessages = value;
      }
    }

    public string CriticalMessagesString()
    {
      string str1 = "";
      IEnumerator enumerator;
      try
      {
        enumerator = this._validatorMessages.CriticalMessages.GetEnumerator();
        while (enumerator.MoveNext())
        {
          string str2 = Conversions.ToString(enumerator.Current);
          str1 = str1 + str2 + "\r\n";
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return str1;
    }

    public string WarningMessageString()
    {
      string str1 = "";
      IEnumerator enumerator;
      try
      {
        enumerator = this._validatorMessages.WarningMessages.GetEnumerator();
        while (enumerator.MoveNext())
        {
          string str2 = Conversions.ToString(enumerator.Current);
          str1 = str1 + str2 + "\r\n";
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return str1;
    }

    public BaseValidator()
    {
      this._validatorMessages = new ValidatorMessages();
    }

    public void AddCriticalMessage(string message)
    {
      this._validatorMessages.CriticalMessages.Add((object) message);
    }

    public void AddWarningMessage(string message)
    {
      this._validatorMessages.WarningMessages.Add((object) message);
    }
  }
}
