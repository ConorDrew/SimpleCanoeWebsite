// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerAbsence.EngineerAbsence
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerAbsence
{
  public class EngineerAbsence
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerAbsenceID;
    private string _EngineerID;
    private int _AbsenceTypeID;
    private DateTime _DateFrom;
    private DateTime _DateTo;
    private int _MorningSlots;
    private int _AfternoonSlots;
    private string _Comments;

    public EngineerAbsence()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerAbsenceID = 0;
      this._EngineerID = string.Empty;
      this._AbsenceTypeID = 0;
      this._DateFrom = DateTime.MinValue;
      this._DateTo = DateTime.MinValue;
      this._MorningSlots = 0;
      this._AfternoonSlots = 0;
      this._Comments = string.Empty;
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

    public int EngineerAbsenceID
    {
      get
      {
        return this._EngineerAbsenceID;
      }
    }

    public object SetEngineerAbsenceID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerAbsenceID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string EngineerID
    {
      get
      {
        return this._EngineerID;
      }
    }

    public object SetEngineerID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int AbsenceTypeID
    {
      get
      {
        return this._AbsenceTypeID;
      }
    }

    public object SetAbsenceTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AbsenceTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime DateFrom
    {
      get
      {
        return this._DateFrom;
      }
      set
      {
        this._DateFrom = value;
      }
    }

    public DateTime DateTo
    {
      get
      {
        return this._DateTo;
      }
      set
      {
        this._DateTo = value;
      }
    }

    public int MorningSlots
    {
      get
      {
        return this._MorningSlots;
      }
    }

    public object SetMorningSlots
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MorningSlots", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int AfternoonSlots
    {
      get
      {
        return this._AfternoonSlots;
      }
    }

    public object SetAfternoonSlots
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AfternoonSlots", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Comments
    {
      get
      {
        return this._Comments;
      }
    }

    public object SetComments
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Comments", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
