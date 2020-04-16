// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativeSites.ContractAlternativeSite
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractAlternativeSites
{
  public class ContractAlternativeSite
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _ContractSiteID;
    private int _ContractID;
    private int _PropertyID;
    private ArrayList _jobOfWorks;

    public ContractAlternativeSite()
    {
      this._exists = false;
      this._deleted = false;
      this._ContractSiteID = 0;
      this._ContractID = 0;
      this._PropertyID = 0;
      this._jobOfWorks = new ArrayList();
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

    public int ContractID
    {
      get
      {
        return this._ContractID;
      }
    }

    public object SetContractID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PropertyID
    {
      get
      {
        return this._PropertyID;
      }
    }

    public object SetPropertyID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PropertyID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public ArrayList JobOfWorks
    {
      get
      {
        return this._jobOfWorks;
      }
      set
      {
        this._jobOfWorks = value;
      }
    }
  }
}
