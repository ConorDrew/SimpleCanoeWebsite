// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderConsolidations.OrderConsolidation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.OrderConsolidations
{
  public class OrderConsolidation
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private int _OrderConsolidationID;
    private int _SupplierID;
    private int _LocationID;
    private DateTime _ConsolidationDate;
    private string _ConsolidationRef;
    private string _Comments;
    private int _ConsolidatedOrderStatusID;
    private bool _HasSupplierPO;
    private string _supplierInvoiceReference;
    private DateTime _supplierInvoiceDate;
    private double _supplierInvoiceAmount;
    private double _VATAmount;
    private string _ExtraRef;
    private int _TaxCodeID;
    private string _NominalCode;
    private string _DepartmentRef;
    private bool _ReadyToSendToSage;
    private bool _sentToSage;
    private DateTime _DateExported;

    public OrderConsolidation()
    {
      this._exists = false;
      this._OrderConsolidationID = 0;
      this._SupplierID = 0;
      this._LocationID = 0;
      this._ConsolidationDate = DateTime.MinValue;
      this._ConsolidationRef = string.Empty;
      this._Comments = string.Empty;
      this._HasSupplierPO = false;
      this._supplierInvoiceReference = "";
      this._supplierInvoiceDate = DateTime.MinValue;
      this._supplierInvoiceAmount = 0.0;
      this._VATAmount = 0.0;
      this._ExtraRef = "";
      this._TaxCodeID = 0;
      this._NominalCode = "";
      this._DepartmentRef = "";
      this._ReadyToSendToSage = false;
      this._sentToSage = false;
      this._DateExported = DateTime.MinValue;
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

    public int OrderConsolidationID
    {
      get
      {
        return this._OrderConsolidationID;
      }
    }

    public object SetOrderConsolidationID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OrderConsolidationID", RuntimeHelpers.GetObjectValue(value));
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

    public int LocationID
    {
      get
      {
        return this._LocationID;
      }
    }

    public object SetLocationID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_LocationID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime ConsolidationDate
    {
      get
      {
        return this._ConsolidationDate;
      }
      set
      {
        this._ConsolidationDate = value;
      }
    }

    public string ConsolidationRef
    {
      get
      {
        return this._ConsolidationRef;
      }
    }

    public object SetConsolidationRef
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ConsolidationRef", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Comments
    {
      get
      {
        return this._Comments;
      }
    }

    public object SetComments
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Comments", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ConsolidatedOrderStatusID
    {
      get
      {
        return this._ConsolidatedOrderStatusID;
      }
    }

    public int SetConsolidatedOrderStatusID
    {
      set
      {
        this._ConsolidatedOrderStatusID = value;
      }
    }

    public bool HasSupplierPO
    {
      get
      {
        return this._HasSupplierPO;
      }
      set
      {
        this._HasSupplierPO = value;
      }
    }

    public string SupplierInvoiceReference
    {
      get
      {
        return this._supplierInvoiceReference;
      }
    }

    public object SetSupplierInvoiceReference
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_supplierInvoiceReference", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime SupplierInvoiceDate
    {
      get
      {
        return this._supplierInvoiceDate;
      }
      set
      {
        this._supplierInvoiceDate = value;
      }
    }

    public double SupplierInvoiceAmount
    {
      get
      {
        return this._supplierInvoiceAmount;
      }
    }

    public object SetSupplierInvoiceAmount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_supplierInvoiceAmount", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double VATAmount
    {
      get
      {
        return this._VATAmount;
      }
    }

    public object SetVATAmount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VATAmount", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string ExtraRef
    {
      get
      {
        return this._ExtraRef;
      }
    }

    public object SetExtraRef
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ExtraRef", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int TaxCodeID
    {
      get
      {
        return this._TaxCodeID;
      }
    }

    public object SetTaxCodeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TaxCodeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string NominalCode
    {
      get
      {
        return this._NominalCode;
      }
    }

    public object SetNominalCode
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_NominalCode", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string DepartmentRef
    {
      get
      {
        return this._DepartmentRef;
      }
    }

    public object SetDepartmentRef
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DepartmentRef", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool ReadyToSendToSage
    {
      get
      {
        return this._ReadyToSendToSage;
      }
    }

    public bool SetReadyToSendToSage
    {
      set
      {
        this._ReadyToSendToSage = value;
      }
    }

    public bool SentToSage
    {
      get
      {
        return this._sentToSage;
      }
    }

    public object SetSentToSage
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_sentToSage", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime DateExported
    {
      get
      {
        return this._DateExported;
      }
      set
      {
        this._DateExported = value;
      }
    }
  }
}
