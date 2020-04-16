// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SalesCredits.SalesCredit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.SalesCredits
{
    public class SalesCredit
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private DateTime _DateCredited;
        private DateTime _DateExportedToSage;
        private double _VATAmount;
        private int _SalesCreditID;
        private double _AmountCredited;
        private string _Notes;
        private int _TaxCodeID;
        private string _ExtraRef;
        private string _CreditReference;
        private int _NominalCode;
        private int _DepartmentRef;
        private int _InvoicedLineID;
        private int _AddedByUser;
        private int _RequestedBy;
        private string _ReasonForCredit;
        private string _AccountNumber;

        public SalesCredit()
        {
            this._exists = false;
            this._deleted = false;
            this._DateCredited = DateTime.MinValue;
            this._DateExportedToSage = DateTime.MinValue;
            this._VATAmount = 0.0;
            this._SalesCreditID = 0;
            this._AmountCredited = 0.0;
            this._Notes = Conversions.ToString(0);
            this._TaxCodeID = 0;
            this._ExtraRef = Conversions.ToString(0);
            this._CreditReference = Conversions.ToString(0);
            this._NominalCode = 0;
            this._DepartmentRef = 0;
            this._InvoicedLineID = 0;
            this._AddedByUser = 0;
            this._RequestedBy = 0;
            this._ReasonForCredit = Conversions.ToString(0);
            this._AccountNumber = "";
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

        public DateTime DateCredited
        {
            get
            {
                return this._DateCredited;
            }
            set
            {
                this._DateCredited = value;
            }
        }

        public DateTime DateExportedToSage
        {
            get
            {
                return this._DateExportedToSage;
            }
            set
            {
                this._DateExportedToSage = value;
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
                this._dataTypeValidator.SetValue((object)this, "_VATAmount", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SalesCreditID
        {
            get
            {
                return this._SalesCreditID;
            }
        }

        public object SetSalesCreditID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SalesCreditID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double AmountCredited
        {
            get
            {
                return this._AmountCredited;
            }
        }

        public object SetAmountCredited
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AmountCredited", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_Notes", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_TaxCodeID", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_ExtraRef", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string CreditReference
        {
            get
            {
                return this._CreditReference;
            }
        }

        public object SetCreditReference
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CreditReference", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int NominalCode
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
                this._dataTypeValidator.SetValue((object)this, "_NominalCode", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int DepartmentRef
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
                this._dataTypeValidator.SetValue((object)this, "_DepartmentRef", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int InvoicedLineID
        {
            get
            {
                return this._InvoicedLineID;
            }
        }

        public object SetInvoicedLineID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoicedLineID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int AddedByUser
        {
            get
            {
                return this._AddedByUser;
            }
        }

        public object SetAddedByUser
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AddedByUser", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int RequestedBy
        {
            get
            {
                return this._RequestedBy;
            }
        }

        public object SetRequestedBy
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_RequestedBy", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string ReasonForCredit
        {
            get
            {
                return this._ReasonForCredit;
            }
        }

        public object SetReasonForCredit
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ReasonForCredit", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_AccountNumber", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}