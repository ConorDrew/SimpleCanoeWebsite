// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3s.ContractOption3
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3s
{
  public class ContractOption3
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _ContractID;
    private int _CustomerID;
    private string _ContractReference;
    private int _ContractStatusID;
    private double _ContractPrice;
    private int _QuoteContractID;

    public ContractOption3()
    {
      this._exists = false;
      this._deleted = false;
      this._ContractID = 0;
      this._CustomerID = 0;
      this._ContractReference = string.Empty;
      this._ContractStatusID = 0;
      this._ContractPrice = 0.0;
      this._QuoteContractID = 0;
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

    public int CustomerID
    {
      get
      {
        return this._CustomerID;
      }
    }

    public object SetCustomerID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CustomerID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string ContractReference
    {
      get
      {
        return this._ContractReference;
      }
    }

    public object SetContractReference
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractReference", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ContractStatusID
    {
      get
      {
        return this._ContractStatusID;
      }
    }

    public object SetContractStatusID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractStatusID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double ContractPrice
    {
      get
      {
        return this._ContractPrice;
      }
    }

    public object SetContractPrice
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractPrice", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int QuoteContractID
    {
      get
      {
        return this._QuoteContractID;
      }
    }

    public object SetQuoteContractID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteContractID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
