// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Orders.SupplierInvoice
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Orders
{
  public class SupplierInvoice
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _InvoiceID;
    private int _OrderID;
    private string _InvoiceReference;
    private DateTime _InvoiceDate;
    private double _GoodsAmount;
    private double _VATAmount;
    private double _TotalAmount;
    private int _TaxCodeID;
    private string _NominalCode;
    private string _ExtraRef;
    private bool _ReadyToSendToSage;
    private bool _SentToSage;
    private bool _OldSystemInvoice;
    private DateTime _DateExported;
    private int _KeyedBy;

    public SupplierInvoice()
    {
      this._exists = false;
      this._deleted = false;
      this._InvoiceID = 0;
      this._OrderID = 0;
      this._InvoiceDate = DateTime.MinValue;
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

    public int InvoiceID
    {
      get
      {
        return this._InvoiceID;
      }
    }

    public object SetInvoiceID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InvoiceID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int OrderID
    {
      get
      {
        return this._OrderID;
      }
    }

    public object SetOrderID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OrderID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string InvoiceReference
    {
      get
      {
        return this._InvoiceReference;
      }
    }

    public object SetInvoiceReference
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InvoiceReference", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime InvoiceDate
    {
      get
      {
        return this._InvoiceDate;
      }
    }

    public object SetInvoiceDate
    {
      set
      {
        this._InvoiceDate = Conversions.ToDate(value);
      }
    }

    public double GoodsAmount
    {
      get
      {
        return this._GoodsAmount;
      }
    }

    public object SetGoodsAmount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_GoodsAmount", RuntimeHelpers.GetObjectValue(value));
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

    public double TotalAmount
    {
      get
      {
        return this._TotalAmount;
      }
    }

    public object SetTotalAmount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TotalAmount", RuntimeHelpers.GetObjectValue(value));
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
        this._TaxCodeID = Conversions.ToInteger(value);
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

    public bool ReadyToSendToSage
    {
      get
      {
        return this._ReadyToSendToSage;
      }
    }

    public object SetReadyToSendToSage
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ReadyToSendToSage", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool SentToSage
    {
      get
      {
        return this._SentToSage;
      }
    }

    public object SetSentToSage
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SentToSage", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool OldSystemInvoice
    {
      get
      {
        return this._OldSystemInvoice;
      }
    }

    public object SetOldSystemInvoice
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OldSystemInvoice", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime DateExported
    {
      get
      {
        return this._DateExported;
      }
    }

    public object SetDateExported
    {
      set
      {
        this._DateExported = Conversions.ToDate(value);
      }
    }

    public int KeyedBy
    {
      get
      {
        return this._KeyedBy;
      }
    }

    public object SetKeyedBy
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_KeyedBy", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
