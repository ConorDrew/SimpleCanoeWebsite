// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitCharges.EngineerVisitCharge
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitCharges
{
    public class EngineerVisitCharge
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _EngineerVisitChargeID;
        private int _EngineerVisitID;
        private double _LabourRate;
        private bool _ApplyMileageToTotal;
        private double _JobValue;
        private int _ChargeTypeID;
        private double _Charge;
        private int _InvoiceReadyID;
        private Decimal _mainContractorDiscount;
        private string _NominalCode;
        private string _Department;
        private string _ForSageAccountCode;
        private int _TaxRateID;
        private int _partsMarkUp;
        private Decimal _partsPrice;
        private Decimal _labourPrice;
        private bool _hasChargeFromJob;

        public EngineerVisitCharge()
        {
            this._exists = false;
            this._deleted = false;
            this._EngineerVisitChargeID = 0;
            this._EngineerVisitID = 0;
            this._LabourRate = 1.0;
            this._ApplyMileageToTotal = true;
            this._JobValue = 0.0;
            this._ChargeTypeID = 0;
            this._Charge = 0.0;
            this._InvoiceReadyID = 0;
            this._mainContractorDiscount = new Decimal();
            this._NominalCode = "";
            this._Department = "";
            this._ForSageAccountCode = "";
            this._TaxRateID = 0;
            this._partsMarkUp = 0;
            this._partsPrice = new Decimal();
            this._labourPrice = new Decimal();
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

        public int EngineerVisitChargeID
        {
            get
            {
                return this._EngineerVisitChargeID;
            }
        }

        public object SetEngineerVisitChargeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerVisitChargeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerVisitID
        {
            get
            {
                return this._EngineerVisitID;
            }
        }

        public object SetEngineerVisitID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerVisitID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double LabourRate
        {
            get
            {
                return this._LabourRate;
            }
        }

        public object SetLabourRate
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LabourRate", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool ApplyMileageToTotal
        {
            get
            {
                return this._ApplyMileageToTotal;
            }
        }

        public object SetApplyMileageToTotal
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ApplyMileageToTotal", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double JobValue
        {
            get
            {
                return this._JobValue;
            }
        }

        public object SetJobValue
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_JobValue", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ChargeTypeID
        {
            get
            {
                return this._ChargeTypeID;
            }
        }

        public object SetChargeTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ChargeTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double Charge
        {
            get
            {
                return this._Charge;
            }
        }

        public object SetCharge
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Charge", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int InvoiceReadyID
        {
            get
            {
                return this._InvoiceReadyID;
            }
        }

        public object SetInvoiceReadyID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceReadyID", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_mainContractorDiscount", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_NominalCode", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Department
        {
            get
            {
                return this._Department;
            }
        }

        public object SetDepartment
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Department", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string ForSageAccountCode
        {
            get
            {
                return this._ForSageAccountCode;
            }
        }

        public object SetForSageAccountCode
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ForSageAccountCode", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int TaxRateID
        {
            get
            {
                return this._TaxRateID;
            }
        }

        public object SetTaxRateID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TaxRateID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PartsMarkUp
        {
            get
            {
                return this._partsMarkUp;
            }
        }

        public object SetPartsMarkUp
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_partsMarkUp", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public Decimal PartsPrice
        {
            get
            {
                return this._partsPrice;
            }
        }

        public object SetPartsPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_partsPrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public Decimal LabourPrice
        {
            get
            {
                return this._labourPrice;
            }
        }

        public object SetLabourPrice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_labourPrice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool HasChargesFromJob
        {
            get
            {
                return this._hasChargeFromJob;
            }
        }

        public object SetHasChargesFromJob
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_hasChargeFromJob", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}