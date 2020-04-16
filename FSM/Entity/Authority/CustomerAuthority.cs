// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Authority.CustomerAuthority
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Authority
{
  public class CustomerAuthority
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _customerAuthorityID;
    private int _customerId;
    private int _authorityID;

    public CustomerAuthority()
    {
      this._exists = false;
      this._deleted = false;
      this._customerAuthorityID = 0;
      this._customerId = 0;
      this._authorityID = 0;
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

    public int CustomerAuthorityID
    {
      get
      {
        return this._customerAuthorityID;
      }
    }

    public object SetCustomerAuthorityID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_customerAuthorityID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int CustomerID
    {
      get
      {
        return this._customerId;
      }
    }

    public object SetCustomerID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_customerId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int AuthorityID
    {
      get
      {
        return this._authorityID;
      }
    }

    public object SetAuthorityID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_authorityID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
