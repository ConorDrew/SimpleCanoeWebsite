// Decompiled with JetBrains decompiler
// Type: FSM.Entity.FleetVans.FleetVanFault
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.FleetVans
{
  public class FleetVanFault
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _vanFaultID;
    private int _vanID;
    private int _faultTypeID;
    private DateTime _faultDate;
    private DateTime _resolvedDate;
    private string _engineerNotes;
    private string _notes;
    private int _jobID;
    private bool _archive;

    public FleetVanFault()
    {
      this._exists = false;
      this._deleted = false;
      this._vanFaultID = 0;
      this._vanID = 0;
      this._faultTypeID = 0;
      this._faultDate = DateTime.MinValue;
      this._resolvedDate = DateTime.MinValue;
      this._engineerNotes = string.Empty;
      this._notes = string.Empty;
      this._jobID = 0;
      this._archive = false;
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

    public int VanFaultID
    {
      get
      {
        return this._vanFaultID;
      }
    }

    public object SetVanFaultID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_vanFaultID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int VanID
    {
      get
      {
        return this._vanID;
      }
    }

    public object SetVanID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_vanID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int FaultTypeID
    {
      get
      {
        return this._faultTypeID;
      }
    }

    public object SetFaultTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_faultTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime FaultDate
    {
      get
      {
        return this._faultDate;
      }
      set
      {
        this._faultDate = value;
      }
    }

    public DateTime ResolvedDate
    {
      get
      {
        return this._resolvedDate;
      }
      set
      {
        this._resolvedDate = value;
      }
    }

    public string EngineerNotes
    {
      get
      {
        return this._engineerNotes;
      }
    }

    public object SetEngineerNotes
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_engineerNotes", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Notes
    {
      get
      {
        return this._notes;
      }
    }

    public object SetNotes
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_notes", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobID
    {
      get
      {
        return this._jobID;
      }
    }

    public object SetJobID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool Archive
    {
      get
      {
        return this._archive;
      }
    }

    public bool SetArchive
    {
      set
      {
        this._archive = value;
      }
    }
  }
}
