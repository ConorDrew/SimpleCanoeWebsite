// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobImport.JobImport
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobImport
{
  public class JobImport
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _jobImportId;
    private int _siteId;
    private string _uprn;
    private int _jobImportTypeId;
    private DateTime _dateAdded;
    private int _jobId;
    private string _jobNumber;
    private int _status;
    private DateTime _bookedVisit;
    private DateTime _letter1;
    private DateTime _letter2;
    private bool _report;

    public JobImport()
    {
      this._exists = false;
      this._deleted = false;
      this._jobImportId = 0;
      this._siteId = 0;
      this._uprn = string.Empty;
      this._jobImportTypeId = 0;
      this._dateAdded = DateTime.MinValue;
      this._jobId = 0;
      this._jobNumber = string.Empty;
      this._status = 0;
      this._bookedVisit = DateTime.MinValue;
      this._letter1 = DateTime.MinValue;
      this._letter2 = DateTime.MinValue;
      this._report = false;
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

    public int JobImportID
    {
      get
      {
        return this._jobImportId;
      }
    }

    public object SetJobImportID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobImportId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SiteID
    {
      get
      {
        return this._siteId;
      }
    }

    public object SetSiteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_siteId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string UPRN
    {
      get
      {
        return this._uprn;
      }
    }

    public object SetUPRN
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_uprn", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobImportTypeID
    {
      get
      {
        return this._jobImportTypeId;
      }
    }

    public object SetJobImportTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobImportTypeId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime DateAdded
    {
      get
      {
        return this._dateAdded;
      }
      set
      {
        this._dateAdded = value;
      }
    }

    public int JobID
    {
      get
      {
        return this._jobId;
      }
    }

    public object SetJobID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string JobNumber
    {
      get
      {
        return this._jobNumber;
      }
    }

    public object SetJobNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobNumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Status
    {
      get
      {
        return this._status;
      }
    }

    public object SetStatus
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_status", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime BookedVisit
    {
      get
      {
        return this._bookedVisit;
      }
      set
      {
        this._bookedVisit = value;
      }
    }

    public DateTime Letter1
    {
      get
      {
        return this._letter1;
      }
      set
      {
        this._letter1 = value;
      }
    }

    public DateTime Letter2
    {
      get
      {
        return this._letter2;
      }
      set
      {
        this._letter2 = value;
      }
    }

    public bool Report
    {
      get
      {
        return this._report;
      }
    }

    public bool SetReport
    {
      set
      {
        this._report = value;
      }
    }
  }
}
