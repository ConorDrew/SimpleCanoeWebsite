// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Invoiceds.Invoiced
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Invoiceds
{
  public class Invoiced
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _InvoicedID;
    private string _InvoiceNumber;
    private string _AdhocInvoiceType;
    private DateTime _RaisedDate;
    private int _RaisedByUserID;
    private int _VATRateID;
    private int _PaymentTermID;
    private int _PaidByID;

    public Invoiced()
    {
      this._exists = false;
      this._deleted = false;
      this._InvoicedID = 0;
      this._InvoiceNumber = string.Empty;
      this._AdhocInvoiceType = string.Empty;
      this._RaisedDate = DateTime.MinValue;
      this._RaisedByUserID = 0;
      this._VATRateID = 0;
      this._PaymentTermID = 0;
      this._PaidByID = 0;
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

    public int InvoicedID
    {
      get
      {
        return this._InvoicedID;
      }
    }

    public object SetInvoicedID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InvoicedID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string InvoiceNumber
    {
      get
      {
        return this._InvoiceNumber;
      }
    }

    public object SetInvoiceNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InvoiceNumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string AdhocInvoiceType
    {
      get
      {
        return this._AdhocInvoiceType;
      }
    }

    public object SetAdhocInvoiceType
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AdhocInvoiceType", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime RaisedDate
    {
      get
      {
        return this._RaisedDate;
      }
      set
      {
        this._RaisedDate = value;
      }
    }

    public int RaisedByUserID
    {
      get
      {
        return this._RaisedByUserID;
      }
    }

    public object SetRaisedByUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_RaisedByUserID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int VATRateID
    {
      get
      {
        return this._VATRateID;
      }
    }

    public object SetVATRateID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VATRateID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PaymentTermID
    {
      get
      {
        return this._PaymentTermID;
      }
    }

    public object SetPaymentTermID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PaymentTermID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PaidByID
    {
      get
      {
        return this._PaidByID;
      }
    }

    public object SetPaidByID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PaidByID", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
