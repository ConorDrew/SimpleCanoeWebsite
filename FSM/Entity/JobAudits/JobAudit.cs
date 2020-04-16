// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobAudits.JobAudit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobAudits
{
  public class JobAudit
  {
    private DataTypeValidator _dataTypeValidator;
    private int _jobAuditID;
    private int _jobID;
    private string _actionChange;

    public JobAudit()
    {
      this._jobAuditID = 0;
      this._jobID = 0;
      this._actionChange = "";
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

    public int JobAuditID
    {
      get
      {
        return this._jobAuditID;
      }
    }

    public object SetJobAuditID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobAuditID", RuntimeHelpers.GetObjectValue(value));
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

    public string ActionChange
    {
      get
      {
        return this._actionChange;
      }
    }

    public object SetActionChange
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_actionChange", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
