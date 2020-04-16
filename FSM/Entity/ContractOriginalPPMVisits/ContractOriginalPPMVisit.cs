// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalPPMVisits
{
  public class ContractOriginalPPMVisit
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private int _ContractPPMVisitID;
    private int _ContractSiteID;
    private DateTime _EstimatedVisitDate;
    private int _JobID;

    public ContractOriginalPPMVisit()
    {
      this._exists = false;
      this._ContractPPMVisitID = 0;
      this._ContractSiteID = 0;
      this._EstimatedVisitDate = DateTime.MinValue;
      this._JobID = 0;
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

    public int ContractPPMVisitID
    {
      get
      {
        return this._ContractPPMVisitID;
      }
    }

    public object SetContractPPMVisitID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractPPMVisitID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ContractSiteID
    {
      get
      {
        return this._ContractSiteID;
      }
    }

    public object SetContractSiteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractSiteID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime EstimatedVisitDate
    {
      get
      {
        return this._EstimatedVisitDate;
      }
      set
      {
        this._EstimatedVisitDate = value;
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
  }
}
