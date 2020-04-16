// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Appointments.Appointment
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Appointments
{
  public class Appointment
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _AppointmentID;
    private string _Name;
    private TimeSpan _StartTime;
    private TimeSpan _EndTime;

    public Appointment()
    {
      this._exists = false;
      this._deleted = false;
      this._AppointmentID = 0;
      this._dataTypeValidator = new DataTypeValidator();
    }

    public bool IgnoreExceptionsOnSetMethods
    {
      get
      {
        return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
      }
      set
      {
        this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
      }
    }

    public Hashtable Errors
    {
      get
      {
        return this._dataTypeValidator.Errors;
      }
    }

    public DataTypeValidator DTValidator
    {
      get
      {
        return this._dataTypeValidator;
      }
    }

    public bool Exists
    {
      get
      {
        return this._exists;
      }
      set
      {
        this._exists = value;
      }
    }

    public bool Deleted
    {
      get
      {
        return this._deleted;
      }
    }

    public bool SetDeleted
    {
      set
      {
        this._deleted = value;
      }
    }

    public int AppointmentID
    {
      get
      {
        return this._AppointmentID;
      }
    }

    public object SetAppointmentID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AppointmentID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Name
    {
      get
      {
        return this._Name;
      }
    }

    public object SetName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Name", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public TimeSpan StartTime
    {
      get
      {
        return this._StartTime;
      }
    }

    public object SetStartTime
    {
      set
      {
        object obj = value;
        this._StartTime = obj != null ? (TimeSpan) obj : new TimeSpan();
      }
    }

    public TimeSpan EndTime
    {
      get
      {
        return this._EndTime;
      }
    }

    public object SetEndTime
    {
      set
      {
        object obj = value;
        this._EndTime = obj != null ? (TimeSpan) obj : new TimeSpan();
      }
    }
  }
}
