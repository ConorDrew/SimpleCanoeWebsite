// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Vans.Van
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Vans
{
  public class Van
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _VanID;
    private string _Registration;
    private string _Notes;
    private DateTime _InsuranceDue;
    private DateTime _MOTDue;
    private DateTime _TaxDue;
    private DateTime _ServiceDue;
    private bool _SecondaryPrice;
    private int _EngineerVanID;
    private double _MileageLimit;
    private int _PeriodValue;
    private int _PeriodType;
    private int _PreferredSupplierID;
    private bool _UseContainerStock;
    private bool _ExcludeFromAutoReplenishment;

    public Van()
    {
      this._exists = false;
      this._deleted = false;
      this._VanID = 0;
      this._Registration = string.Empty;
      this._Notes = string.Empty;
      this._InsuranceDue = DateTime.MinValue;
      this._MOTDue = DateTime.MinValue;
      this._TaxDue = DateTime.MinValue;
      this._ServiceDue = DateTime.MinValue;
      this._MileageLimit = 0.0;
      this._PeriodValue = 0;
      this._PeriodType = 0;
      this._PreferredSupplierID = 0;
      this._UseContainerStock = false;
      this._ExcludeFromAutoReplenishment = false;
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

    public int VanID
    {
      get
      {
        return this._VanID;
      }
    }

    public object SetVanID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VanID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Registration
    {
      get
      {
        return this._Registration;
      }
    }

    public object SetRegistration
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Registration", RuntimeHelpers.GetObjectValue(value));
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

    public DateTime InsuranceDue
    {
      get
      {
        return this._InsuranceDue;
      }
      set
      {
        this._InsuranceDue = value;
      }
    }

    public DateTime MOTDue
    {
      get
      {
        return this._MOTDue;
      }
      set
      {
        this._MOTDue = value;
      }
    }

    public DateTime TaxDue
    {
      get
      {
        return this._TaxDue;
      }
      set
      {
        this._TaxDue = value;
      }
    }

    public DateTime ServiceDue
    {
      get
      {
        return this._ServiceDue;
      }
      set
      {
        this._ServiceDue = value;
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

    public int EngineerVanID
    {
      get
      {
        return this._EngineerVanID;
      }
    }

    public object SetEngineerVanID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerVanID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double MileageLimit
    {
      get
      {
        return this._MileageLimit;
      }
    }

    public object SetMileageLimit
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MileageLimit", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PeriodValue
    {
      get
      {
        return this._PeriodValue;
      }
    }

    public object SetPeriodValue
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PeriodValue", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PeriodType
    {
      get
      {
        return this._PeriodType;
      }
    }

    public object SetPeriodType
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PeriodType", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PreferredSupplierID
    {
      get
      {
        return this._PreferredSupplierID;
      }
    }

    public object SetPreferredSupplierID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PreferredSupplierID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool UseContainerStock
    {
      get
      {
        return this._UseContainerStock;
      }
    }

    public bool SetUseContainerStock
    {
      set
      {
        this._UseContainerStock = value;
      }
    }

    public bool ExcludeFromAutoReplenishment
    {
      get
      {
        return this._ExcludeFromAutoReplenishment;
      }
    }

    public bool SetExcludeFromAutoReplenishment
    {
      set
      {
        this._ExcludeFromAutoReplenishment = value;
      }
    }
  }
}
