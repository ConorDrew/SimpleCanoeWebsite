// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Suppliers.Supplier
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Suppliers
{
  public class Supplier
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private bool _SecondaryPrice;
    private int _SupplierID;
    private string _AccountNumber;
    private string _secondAccountNumber;
    private string _Name;
    private string _Address1;
    private string _Address2;
    private string _Address3;
    private string _Address4;
    private string _Address5;
    private string _Postcode;
    private string _TelephoneNum;
    private string _FaxNum;
    private string _EmailAddress;
    private string _Notes;
    private string _FilePath;
    private string _GaswayAccount;
    private int _MasterSupplierID;
    private bool _ReleaseToTablets;
    private bool _SubContractor;
    private string _DefaultNominal;

    public Supplier()
    {
      this._exists = false;
      this._deleted = false;
      this._SupplierID = 0;
      this._AccountNumber = string.Empty;
      this._secondAccountNumber = string.Empty;
      this._Name = string.Empty;
      this._Address1 = string.Empty;
      this._Address2 = string.Empty;
      this._Address3 = string.Empty;
      this._Address4 = string.Empty;
      this._Address5 = string.Empty;
      this._Postcode = string.Empty;
      this._TelephoneNum = string.Empty;
      this._FaxNum = string.Empty;
      this._EmailAddress = string.Empty;
      this._Notes = string.Empty;
      this._FilePath = string.Empty;
      this._GaswayAccount = string.Empty;
      this._MasterSupplierID = 0;
      this._ReleaseToTablets = false;
      this._SubContractor = false;
      this._DefaultNominal = string.Empty;
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

    public bool SecondaryPrice
    {
      get
      {
        return this._SecondaryPrice;
      }
      set
      {
        this._SecondaryPrice = value;
      }
    }

    public int SupplierID
    {
      get
      {
        return this._SupplierID;
      }
    }

    public object SetSupplierID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SupplierID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string AccountNumber
    {
      get
      {
        return this._AccountNumber;
      }
    }

    public object SetAccountNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AccountNumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string SecondAccountNumber
    {
      get
      {
        return this._secondAccountNumber;
      }
    }

    public object SetSecondAccountNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_secondAccountNumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Name
    {
      get
      {
        return this._Name;
      }
    }

    public object SetName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Name", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address1
    {
      get
      {
        return this._Address1;
      }
    }

    public object SetAddress1
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address1", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address2
    {
      get
      {
        return this._Address2;
      }
    }

    public object SetAddress2
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address2", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address3
    {
      get
      {
        return this._Address3;
      }
    }

    public object SetAddress3
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address3", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address4
    {
      get
      {
        return this._Address4;
      }
    }

    public object SetAddress4
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address4", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Address5
    {
      get
      {
        return this._Address5;
      }
    }

    public object SetAddress5
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Address5", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Postcode
    {
      get
      {
        return this._Postcode;
      }
    }

    public object SetPostcode
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Postcode", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string TelephoneNum
    {
      get
      {
        return this._TelephoneNum;
      }
    }

    public object SetTelephoneNum
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TelephoneNum", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string FaxNum
    {
      get
      {
        return this._FaxNum;
      }
    }

    public object SetFaxNum
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FaxNum", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string EmailAddress
    {
      get
      {
        return this._EmailAddress;
      }
    }

    public object SetEmailAddress
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EmailAddress", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Notes
    {
      get
      {
        return this._Notes;
      }
    }

    public object SetNotes
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Notes", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string FilePath
    {
      get
      {
        return this._FilePath;
      }
    }

    public object SetFilePath
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_FilePath", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string GaswayAccount
    {
      get
      {
        return this._GaswayAccount;
      }
    }

    public object SetGaswayAccount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_GaswayAccount", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string MasterSupplierID
    {
      get
      {
        return Conversions.ToString(this._MasterSupplierID);
      }
    }

    public object SetMasterSupplierID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MasterSupplierID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string ReleaseToTablets
    {
      get
      {
        return Conversions.ToString(this._ReleaseToTablets);
      }
    }

    public object SetReleaseToTablets
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ReleaseToTablets", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool SubContractor
    {
      get
      {
        return this._SubContractor;
      }
    }

    public object SetSubContractor
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SubContractor", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string DefaultNominal
    {
      get
      {
        return this._DefaultNominal;
      }
    }

    public object SetDefaultNominal
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DefaultNominal", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
