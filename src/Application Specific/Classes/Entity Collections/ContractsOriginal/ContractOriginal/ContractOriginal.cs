using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractsOriginal
    {
        public class ContractOriginal
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOriginal()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public bool IgnoreExceptionsOnSetMethods
            {
                get
                {
                    return _dataTypeValidator.IgnoreExceptionsOnSetMethods;
                }

                set
                {
                    _dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
                }
            }

            public Hashtable Errors
            {
                get
                {
                    return _dataTypeValidator.Errors;
                }
            }

            public DataTypeValidator DTValidator
            {
                get
                {
                    return _dataTypeValidator;
                }
            }

            private bool _exists = false;

            public bool Exists
            {
                get
                {
                    return _exists;
                }

                set
                {
                    _exists = value;
                }
            }

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private int _ContractID = 0;

            public int ContractID
            {
                get
                {
                    return _ContractID;
                }
            }

            public object SetContractID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractID", value);
                }
            }

            private int _ContractTypeID = 0;

            public int ContractTypeID
            {
                get
                {
                    return _ContractTypeID;
                }
            }

            public object SetContractTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractTypeID", value);
                }
            }

            private int _DiscountID = 0;

            public int DiscountID
            {
                get
                {
                    return _DiscountID;
                }
            }

            public object SetDiscountID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DiscountID", value);
                }
            }

            private int _CustomerID = 0;

            public int CustomerID
            {
                get
                {
                    return _CustomerID;
                }
            }

            public object SetCustomerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerID", value);
                }
            }

            private string _ContractReference = string.Empty;

            public string ContractReference
            {
                get
                {
                    return _ContractReference;
                }
            }

            public object SetContractReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractReference", value);
                }
            }

            private DateTime _ContractStartDate = default;

            public DateTime ContractStartDate
            {
                get
                {
                    return _ContractStartDate;
                }

                set
                {
                    _ContractStartDate = value;
                }
            }

            private DateTime _ContractEndDate = default;

            public DateTime ContractEndDate
            {
                get
                {
                    return _ContractEndDate;
                }

                set
                {
                    _ContractEndDate = value;
                }
            }

            private int _ContractStatusID = 0;

            public int ContractStatusID
            {
                get
                {
                    return _ContractStatusID;
                }
            }

            public object SetContractStatusID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractStatusID", value);
                }
            }

            private decimal _ContractPrice = 0.0M;

            public decimal ContractPrice
            {
                get
                {
                    return _ContractPrice;
                }
            }

            public object SetContractPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractPrice", value);
                }
            }

            private double _ContractPriceAfterVAT = 0.0;

            public double ContractPriceAfterVAT
            {
                get
                {
                    return _ContractPriceAfterVAT;
                }
            }

            public object SetContractPriceAfterVAT
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractPriceAfterVAT", value);
                }
            }

            private int _QuoteContractID = 0;

            public int QuoteContractID
            {
                get
                {
                    return _QuoteContractID;
                }
            }

            public object SetQuoteContractID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractID", value);
                }
            }

            private int _InvoiceFrequencyID = 0;

            public int InvoiceFrequencyID
            {
                get
                {
                    return _InvoiceFrequencyID;
                }
            }

            public object SetInvoiceFrequencyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceFrequencyID", value);
                }
            }

            private int _PreviousInvoiceFrequencyID = 0;

            public int PreviousInvoiceFrequencyID
            {
                get
                {
                    return _PreviousInvoiceFrequencyID;
                }
            }

            public object SetPreviousInvoiceFrequencyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PreviousInvoiceFrequencyID", value);
                }
            }

            private DateTime _FirstInvoiceDate;

            public DateTime FirstInvoiceDate
            {
                get
                {
                    return _FirstInvoiceDate;
                }

                set
                {
                    _FirstInvoiceDate = value;
                }
            }

            private int _InvoiceAddressTypeID;

            public int InvoiceAddressTypeID
            {
                get
                {
                    return _InvoiceAddressTypeID;
                }
            }

            public object SetInvoiceAddressTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceAddressTypeID", value);
                }
            }

            private int _InvoiceAddressID = 0;

            public int InvoiceAddressID
            {
                get
                {
                    return _InvoiceAddressID;
                }
            }

            public object SetInvoiceAddressID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceAddressID", value);
                }
            }

            private string _sortCode = "";

            public string SortCode
            {
                get
                {
                    return _sortCode;
                }
            }

            public object SetSortCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_sortCode", value);
                }
            }

            private string _accountNumber = "";

            public string AccountNumber
            {
                get
                {
                    return _accountNumber;
                }
            }

            public object SetAccountNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_accountNumber", value);
                }
            }

            private string _bankName = "";

            public string BankName
            {
                get
                {
                    return _bankName;
                }
            }

            public object SetBankName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_bankName", value);
                }
            }

            private string _PoNumber = "";

            public string PoNumber
            {
                get
                {
                    return _PoNumber;
                }
            }

            public object SetPoNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PoNumber", value);
                }
            }

            private string _DDMSRef = "";

            public string DDMSRef
            {
                get
                {
                    return _DDMSRef;
                }
            }

            public object SetDDMSRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DDMSRef", value);
                }
            }

            private bool _directDebit = false;

            public bool DirectDebit
            {
                get
                {
                    return _directDebit;
                }
            }

            public object SetDirectDebit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_directDebit", value);
                }
            }

            private bool _DoNotRenew = false;

            public bool DoNotRenew
            {
                get
                {
                    return _DoNotRenew;
                }
            }

            public object SetDoNotRenew
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DoNotRenew", value);
                }
            }

            private bool _creditCard = false;

            public bool CreditCard
            {
                get
                {
                    return _creditCard;
                }
            }

            public object SetCreditCard
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_creditCard", value);
                }
            }

            private bool _cheque = false;

            public bool Cheque
            {
                get
                {
                    return _cheque;
                }
            }

            public object SetCheque
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_cheque", value);
                }
            }

            private bool _Annual = false;

            public bool Annual
            {
                get
                {
                    return _Annual;
                }
            }

            public object SetAnnual
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Annual", value);
                }
            }

            private bool _GasSupplyPipework = false;

            public bool GasSupplyPipework
            {
                get
                {
                    return _GasSupplyPipework;
                }
            }

            public object SetGasSupplyPipework
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_GasSupplyPipework", value);
                }
            }

            private bool _PlumbingDrainage = false;

            public bool PlumbingDrainage
            {
                get
                {
                    return _PlumbingDrainage;
                }
            }

            public object SetPlumbingDrainage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PlumbingDrainage", value);
                }
            }

            private bool _WindowLockPest = false;

            public bool WindowLockPest
            {
                get
                {
                    return _WindowLockPest;
                }
            }

            public object SetWindowLockPest
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WindowLockPest", value);
                }
            }


            // THIS IS A CHEAT
            private string _ContractType = string.Empty;

            public string ContractType
            {
                get
                {
                    return _ContractType;
                }
            }

            public object SetContractType
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractType", value);
                }
            }

            private DateTime _CancelledDate = DateTime.MinValue;

            public DateTime CancelledDate
            {
                get
                {
                    return _CancelledDate;
                }

                set
                {
                    _CancelledDate = value;
                }
            }

            private int _ReasonID = 0;

            public int ReasonID
            {
                get
                {
                    return _ReasonID;
                }
            }

            public object SetReasonID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonID", value);
                }
            }

            private string _Notes = string.Empty;

            public string Notes
            {
                get
                {
                    return _Notes;
                }
            }

            public object SetNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Notes", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}