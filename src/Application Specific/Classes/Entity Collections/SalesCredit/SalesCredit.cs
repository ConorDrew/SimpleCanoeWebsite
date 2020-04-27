using System;
using System.Collections;

namespace FSM.Entity
{
    namespace SalesCredits
    {
        public class SalesCredit
        {
            private DataTypeValidator _dataTypeValidator;

            public SalesCredit()
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

            private DateTime _DateCredited = default;

            public DateTime DateCredited
            {
                get
                {
                    return _DateCredited;
                }

                set
                {
                    _DateCredited = value;
                }
            }

            private DateTime _DateExportedToSage = default;

            public DateTime DateExportedToSage
            {
                get
                {
                    return _DateExportedToSage;
                }

                set
                {
                    _DateExportedToSage = value;
                }
            }

            private double _VATAmount = 0;

            public double VATAmount
            {
                get
                {
                    return _VATAmount;
                }
            }

            public object SetVATAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VATAmount", value);
                }
            }

            private int _SalesCreditID = 0;

            public int SalesCreditID
            {
                get
                {
                    return _SalesCreditID;
                }
            }

            public object SetSalesCreditID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SalesCreditID", value);
                }
            }

            private double _AmountCredited = 0;

            public double AmountCredited
            {
                get
                {
                    return _AmountCredited;
                }
            }

            public object SetAmountCredited
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AmountCredited", value);
                }
            }

            private string _Notes = 0.ToString();

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

            private int _TaxCodeID = 0;

            public int TaxCodeID
            {
                get
                {
                    return _TaxCodeID;
                }
            }

            public object SetTaxCodeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TaxCodeID", value);
                }
            }

            private string _ExtraRef = 0.ToString();

            public string ExtraRef
            {
                get
                {
                    return _ExtraRef;
                }
            }

            public object SetExtraRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ExtraRef", value);
                }
            }

            private string _CreditReference = 0.ToString();

            public string CreditReference
            {
                get
                {
                    return _CreditReference;
                }
            }

            public object SetCreditReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CreditReference", value);
                }
            }

            private int _NominalCode = 0;

            public int NominalCode
            {
                get
                {
                    return _NominalCode;
                }
            }

            public object SetNominalCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NominalCode", value);
                }
            }

            private string _DepartmentRef = "";

            public string DepartmentRef
            {
                get
                {
                    return _DepartmentRef;
                }
            }

            public object SetDepartmentRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DepartmentRef", value);
                }
            }

            private int _InvoicedLineID = 0;

            public int InvoicedLineID
            {
                get
                {
                    return _InvoicedLineID;
                }
            }

            public object SetInvoicedLineID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoicedLineID", value);
                }
            }

            private int _AddedByUser = 0;

            public int AddedByUser
            {
                get
                {
                    return _AddedByUser;
                }
            }

            public object SetAddedByUser
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AddedByUser", value);
                }
            }

            private int _RequestedBy = 0;

            public int RequestedBy
            {
                get
                {
                    return _RequestedBy;
                }
            }

            public object SetRequestedBy
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RequestedBy", value);
                }
            }

            private string _ReasonForCredit = 0.ToString();

            public string ReasonForCredit
            {
                get
                {
                    return _ReasonForCredit;
                }
            }

            public object SetReasonForCredit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForCredit", value);
                }
            }

            private string _AccountNumber = "";

            public string AccountNumber
            {
                get
                {
                    return _AccountNumber;
                }
            }

            public object SetAccountNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AccountNumber", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}