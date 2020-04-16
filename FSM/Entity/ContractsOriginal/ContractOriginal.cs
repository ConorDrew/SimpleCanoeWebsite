// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractsOriginal.ContractOriginal
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractsOriginal
{
  public class ContractOriginal
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _ContractID;
    private int _ContractTypeID;
    private int _DiscountID;
    private int _CustomerID;
    private string _ContractReference;
    private DateTime _ContractStartDate;
    private DateTime _ContractEndDate;
    private int _ContractStatusID;
    private Decimal _ContractPrice;
    private double _ContractPriceAfterVAT;
    private int _QuoteContractID;
    private int _InvoiceFrequencyID;
    private int _PreviousInvoiceFrequencyID;
    private DateTime _FirstInvoiceDate;
    private int _InvoiceAddressTypeID;
    private int _InvoiceAddressID;
    private string _sortCode;
    private string _accountNumber;
    private string _bankName;
    private string _PoNumber;
    private string _DDMSRef;
    private bool _directDebit;
    private bool _DoNotRenew;
    private bool _creditCard;
    private bool _cheque;
    private bool _Annual;
    private bool _GasSupplyPipework;
    private bool _PlumbingDrainage;
    private bool _WindowLockPest;
    private string _ContractType;
    private DateTime _CancelledDate;
    private int _ReasonID;
    private string _Notes;

    public ContractOriginal()
    {
      this._exists = false;
      this._deleted = false;
      this._ContractID = 0;
      this._ContractTypeID = 0;
      this._DiscountID = 0;
      this._CustomerID = 0;
      this._ContractReference = string.Empty;
      this._ContractStartDate = DateTime.MinValue;
      this._ContractEndDate = DateTime.MinValue;
      this._ContractStatusID = 0;
      this._ContractPrice = new Decimal();
      this._ContractPriceAfterVAT = 0.0;
      this._QuoteContractID = 0;
      this._InvoiceFrequencyID = 0;
      this._PreviousInvoiceFrequencyID = 0;
      this._InvoiceAddressID = 0;
      this._sortCode = "";
      this._accountNumber = "";
      this._bankName = "";
      this._PoNumber = "";
      this._DDMSRef = "";
      this._directDebit = false;
      this._DoNotRenew = false;
      this._creditCard = false;
      this._cheque = false;
      this._Annual = false;
      this._GasSupplyPipework = false;
      this._PlumbingDrainage = false;
      this._WindowLockPest = false;
      this._ContractType = string.Empty;
      this._CancelledDate = DateTime.MinValue;
      this._ReasonID = 0;
      this._Notes = string.Empty;
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

    public int ContractTypeID
    {
      get
      {
        return this._ContractTypeID;
      }
    }

    public object SetContractTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int DiscountID
    {
      get
      {
        return this._DiscountID;
      }
    }

    public object SetDiscountID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DiscountID", RuntimeHelpers.GetObjectValue(value));
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

    public DateTime ContractStartDate
    {
      get
      {
        return this._ContractStartDate;
      }
      set
      {
        this._ContractStartDate = value;
      }
    }

    public DateTime ContractEndDate
    {
      get
      {
        return this._ContractEndDate;
      }
      set
      {
        this._ContractEndDate = value;
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

    public Decimal ContractPrice
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

    public double ContractPriceAfterVAT
    {
      get
      {
        return this._ContractPriceAfterVAT;
      }
    }

    public object SetContractPriceAfterVAT
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractPriceAfterVAT", RuntimeHelpers.GetObjectValue(value));
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

    public int InvoiceFrequencyID
    {
      get
      {
        return this._InvoiceFrequencyID;
      }
    }

    public object SetInvoiceFrequencyID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InvoiceFrequencyID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PreviousInvoiceFrequencyID
    {
      get
      {
        return this._PreviousInvoiceFrequencyID;
      }
    }

    public object SetPreviousInvoiceFrequencyID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PreviousInvoiceFrequencyID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime FirstInvoiceDate
    {
      get
      {
        return this._FirstInvoiceDate;
      }
      set
      {
        this._FirstInvoiceDate = value;
      }
    }

    public int InvoiceAddressTypeID
    {
      get
      {
        return this._InvoiceAddressTypeID;
      }
    }

    public object SetInvoiceAddressTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InvoiceAddressTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int InvoiceAddressID
    {
      get
      {
        return this._InvoiceAddressID;
      }
    }

    public object SetInvoiceAddressID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_InvoiceAddressID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string SortCode
    {
      get
      {
        return this._sortCode;
      }
    }

    public object SetSortCode
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_sortCode", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string AccountNumber
    {
      get
      {
        return this._accountNumber;
      }
    }

    public object SetAccountNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_accountNumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string BankName
    {
      get
      {
        return this._bankName;
      }
    }

    public object SetBankName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_bankName", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string PoNumber
    {
      get
      {
        return this._PoNumber;
      }
    }

    public object SetPoNumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PoNumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string DDMSRef
    {
      get
      {
        return this._DDMSRef;
      }
    }

    public object SetDDMSRef
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DDMSRef", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool DirectDebit
    {
      get
      {
        return this._directDebit;
      }
    }

    public object SetDirectDebit
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_directDebit", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool DoNotRenew
    {
      get
      {
        return this._DoNotRenew;
      }
    }

    public object SetDoNotRenew
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DoNotRenew", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool CreditCard
    {
      get
      {
        return this._creditCard;
      }
    }

    public object SetCreditCard
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_creditCard", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool Cheque
    {
      get
      {
        return this._cheque;
      }
    }

    public object SetCheque
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_cheque", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool Annual
    {
      get
      {
        return this._Annual;
      }
    }

    public object SetAnnual
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Annual", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool GasSupplyPipework
    {
      get
      {
        return this._GasSupplyPipework;
      }
    }

    public object SetGasSupplyPipework
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_GasSupplyPipework", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool PlumbingDrainage
    {
      get
      {
        return this._PlumbingDrainage;
      }
    }

    public object SetPlumbingDrainage
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PlumbingDrainage", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool WindowLockPest
    {
      get
      {
        return this._WindowLockPest;
      }
    }

    public object SetWindowLockPest
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_WindowLockPest", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string ContractType
    {
      get
      {
        return this._ContractType;
      }
    }

    public object SetContractType
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ContractType", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime CancelledDate
    {
      get
      {
        return this._CancelledDate;
      }
      set
      {
        this._CancelledDate = value;
      }
    }

    public int ReasonID
    {
      get
      {
        return this._ReasonID;
      }
    }

    public object SetReasonID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ReasonID", RuntimeHelpers.GetObjectValue(value));
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
  }
}
