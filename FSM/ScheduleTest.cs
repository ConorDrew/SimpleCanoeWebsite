// Decompiled with JetBrains decompiler
// Type: FSM.ScheduleTest
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Data;

namespace FSM
{
  public abstract class ScheduleTest
  {
    protected abstract string TestName { get; }

    public abstract ScheduleTest.TestResult Test(
      DataRow testRow,
      int engineerID,
      DateTime day);

    public class TestResult
    {
      private bool _pass;
      private bool _cancelSchedule;
      private bool _passwordPrompt;
      private string _failMessage;
      private ArrayList _failMessages;

      public TestResult()
      {
        this._failMessages = new ArrayList();
        this._pass = true;
        this._failMessage = this.failMessage;
        this._cancelSchedule = false;
        this._passwordPrompt = false;
      }

      public TestResult(string failMessage, bool cancelSchedule = false, bool passwordPrompt = false)
      {
        this._failMessages = new ArrayList();
        this._pass = false;
        this._failMessage = failMessage;
        this._cancelSchedule = cancelSchedule;
        this._passwordPrompt = passwordPrompt;
      }

      public TestResult(ArrayList failMessages, bool cancelSchedule = false, bool passwordPrompt = false)
      {
        this._failMessages = new ArrayList();
        this._pass = false;
        this._failMessages = failMessages;
        this._cancelSchedule = cancelSchedule;
        this._passwordPrompt = passwordPrompt;
      }

      public bool pass
      {
        get
        {
          return this._pass;
        }
      }

      public string failMessage
      {
        get
        {
          return this._failMessage;
        }
      }

      public ArrayList failMessages
      {
        get
        {
          return this._failMessages;
        }
      }

      public bool CancelSchedule
      {
        get
        {
          return this._cancelSchedule;
        }
      }

      public bool PasswordPrompt
      {
        get
        {
          return this._passwordPrompt;
        }
      }
    }
  }
}
