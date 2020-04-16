// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobContacts.JobContact
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobContacts
{
  public class JobContact
  {
    private DataTypeValidator _dataTypeValidator;
    private int _jobContactID;
    private int _jobID;
    private string _contactType;
    private DateTime _dateActioned;

    public JobContact()
    {
      this._jobContactID = 0;
      this._jobID = 0;
      this._contactType = "";
      this._dateActioned = DateTime.MinValue;
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

    public int jobContactID
    {
      get
      {
        return this._jobContactID;
      }
    }

    public object SetjobContactID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobContactID", RuntimeHelpers.GetObjectValue(value));
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

    public string contactType
    {
      get
      {
        return this._contactType;
      }
    }

    public object SetcontactType
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_contactType", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime dateActioned
    {
      get
      {
        return this._dateActioned;
      }
      set
      {
        this._dateActioned = value;
      }
    }
  }
}
