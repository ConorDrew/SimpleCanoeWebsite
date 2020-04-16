// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobOfWorks.JobOfWork
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobOfWorks
{
  public class JobOfWork
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _JobOfWorkID;
    private int _JobID;
    private string _PONumber;
    private int _Priority;
    private int _Status;
    private DateTime _PriorityDateSet;
    private int _qualificationId;
    private ArrayList _jobItems;
    private ArrayList _engineerVisits;

    public JobOfWork()
    {
      this._exists = false;
      this._deleted = false;
      this._JobOfWorkID = 0;
      this._JobID = 0;
      this._Priority = 0;
      this._Status = 1;
      this._PriorityDateSet = DateTime.MinValue;
      this._qualificationId = 0;
      this._jobItems = new ArrayList();
      this._engineerVisits = new ArrayList();
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

    public int JobOfWorkID
    {
      get
      {
        return this._JobOfWorkID;
      }
    }

    public object SetJobOfWorkID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobOfWorkID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobID
    {
      get
      {
        return this._JobID;
      }
    }

    public object SetJobID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string PONumber
    {
      get
      {
        return this._PONumber;
      }
    }

    public object SetPONumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PONumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Priority
    {
      get
      {
        return this._Priority;
      }
    }

    public object SetPriority
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Priority", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Status
    {
      get
      {
        return this._Status;
      }
    }

    public object SetStatus
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Status", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime PriorityDateSet
    {
      get
      {
        return this._PriorityDateSet;
      }
      set
      {
        this._PriorityDateSet = value;
      }
    }

    public int QualificationID
    {
      get
      {
        return this._qualificationId;
      }
    }

    public object SetQualificationID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_qualificationId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public ArrayList JobItems
    {
      get
      {
        return this._jobItems;
      }
      set
      {
        this._jobItems = value;
      }
    }

    public ArrayList EngineerVisits
    {
      get
      {
        return this._engineerVisits;
      }
      set
      {
        this._engineerVisits = value;
      }
    }
  }
}
