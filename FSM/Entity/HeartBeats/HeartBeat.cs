// Decompiled with JetBrains decompiler
// Type: FSM.Entity.HeartBeats.HeartBeat
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Runtime.CompilerServices;

namespace FSM.Entity.HeartBeats
{
  public class HeartBeat
  {
    private DataTypeValidator _dataTypeValidator;
    private int _LockedVisitID;
    private DateTime _LastHeartBeat;
    private DateTime _LastCheck;

    public HeartBeat()
    {
      this._LockedVisitID = 0;
      this._LastHeartBeat = DateTime.MinValue;
      this._LastCheck = DateTime.MinValue;
      this._dataTypeValidator = new DataTypeValidator();
    }

    public int LockedVisitID
    {
      get
      {
        return this._LockedVisitID;
      }
    }

    public object SetLockedVisitID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_LockedVisitID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime LastHeartBeat
    {
      get
      {
        return this._LastHeartBeat;
      }
      set
      {
        this._LastHeartBeat = value;
      }
    }

    public DateTime LastCheck
    {
      get
      {
        return this._LastCheck;
      }
      set
      {
        this._LastCheck = value;
      }
    }
  }
}
