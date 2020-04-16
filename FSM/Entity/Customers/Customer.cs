// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Customers.Customer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Customers
{
  public class Customer
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _CustomerID;
    private string _Name;
    private int _RegionID;
    private int _CustomerTypeID;
    private string _Notes;
    private string _AccountNumber;
    private int _Status;
    private bool _PoNumReqd;
    private bool _SuperBook;
    private bool _AcceptChargesChanges;
    private Decimal _mainContractorDiscount;
    private byte[] _Logo;
    private bool _JobPriorityMandatory;
    private string _Nominal;
    private string _OverrideDept;
    private int _Terms;
    private int _SummerServ;
    private int _WinterServ;
    private string _alertEmail;
    private bool _motStyleService;
    private bool _isOutOfScope;
    private bool _IsPFH;
    private Decimal _jobSpendLimit;

    public Customer()
    {
      this._exists = false;
      this._deleted = false;
      this._CustomerID = 0;
      this._Name = string.Empty;
      this._RegionID = 0;
      this._CustomerTypeID = 0;
      this._Notes = string.Empty;
      this._AccountNumber = string.Empty;
      this._Status = 0;
      this._PoNumReqd = false;
      this._SuperBook = false;
      this._AcceptChargesChanges = true;
      this._mainContractorDiscount = new Decimal();
      this._Logo = (byte[]) null;
      this._JobPriorityMandatory = false;
      this._Nominal = string.Empty;
      this._OverrideDept = string.Empty;
      this._Terms = 0;
      this._SummerServ = 0;
      this._WinterServ = 0;
      this._alertEmail = string.Empty;
      this._motStyleService = false;
      this._isOutOfScope = false;
      this._IsPFH = false;
      this._jobSpendLimit = new Decimal();
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

    public int RegionID
    {
      get
      {
        return this._RegionID;
      }
    }

    public object SetRegionID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_RegionID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int CustomerTypeID
    {
      get
      {
        return this._CustomerTypeID;
      }
    }

    public object SetCustomerTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CustomerTypeID", RuntimeHelpers.GetObjectValue(value));
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

    public bool PoNumReqd
    {
      get
      {
        return this._PoNumReqd;
      }
    }

    public object SetPoNumReqd
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PoNumReqd", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool SuperBook
    {
      get
      {
        return this._SuperBook;
      }
    }

    public object SetSuperBook
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SuperBook", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool AcceptChargesChanges
    {
      get
      {
        return this._AcceptChargesChanges;
      }
    }

    public object SetAcceptChargesChanges
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AcceptChargesChanges", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal MainContractorDiscount
    {
      get
      {
        return this._mainContractorDiscount;
      }
    }

    public object SetMainContractorDiscount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_mainContractorDiscount", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public byte[] Logo
    {
      get
      {
        if (this._Logo != null)
          ;
        return this._Logo;
      }
      set
      {
        this._Logo = value;
      }
    }

    public bool JobPriorityMandatory
    {
      get
      {
        return this._JobPriorityMandatory;
      }
    }

    public object SetJobPriorityMandatory
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobPriorityMandatory", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Nominal
    {
      get
      {
        return this._Nominal;
      }
    }

    public object SetNominal
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Nominal", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string OverrideDept
    {
      get
      {
        return this._OverrideDept;
      }
    }

    public object SetOverrideDept
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OverrideDept", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int Terms
    {
      get
      {
        return this._Terms;
      }
    }

    public object SetTerms
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Terms", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SummerServ
    {
      get
      {
        return this._SummerServ;
      }
    }

    public object SetSummerServ
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SummerServ", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int WinterServ
    {
      get
      {
        return this._WinterServ;
      }
    }

    public object SetWinterServ
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_WinterServ", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string AlertEmail
    {
      get
      {
        return this._alertEmail;
      }
    }

    public object SetAlertEmail
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_alertEmail", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool MOTStyleService
    {
      get
      {
        return this._motStyleService;
      }
    }

    public bool SetMOTStyleService
    {
      set
      {
        this._motStyleService = value;
      }
    }

    public bool IsOutOfScope
    {
      get
      {
        return this._isOutOfScope;
      }
    }

    public bool SetIsOutOfScope
    {
      set
      {
        this._isOutOfScope = value;
      }
    }

    public bool IsPFH
    {
      get
      {
        return this._IsPFH;
      }
    }

    public bool SetIsPFH
    {
      set
      {
        this._IsPFH = value;
      }
    }

    public Decimal JobSpendLimit
    {
      get
      {
        return this._jobSpendLimit;
      }
    }

    public object SetJobSpendLimit
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_jobSpendLimit", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
