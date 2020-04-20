using System.Collections;

namespace FSM.Entity
{
    namespace EngineerVisitCharges
    {
        public class EngineerVisitCharge
        {
            private DataTypeValidator _dataTypeValidator;

            public EngineerVisitCharge()
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
            private int _EngineerVisitChargeID = 0;

            public int EngineerVisitChargeID
            {
                get
                {
                    return _EngineerVisitChargeID;
                }
            }

            public object SetEngineerVisitChargeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitChargeID", value);
                }
            }

            private int _EngineerVisitID = 0;

            public int EngineerVisitID
            {
                get
                {
                    return _EngineerVisitID;
                }
            }

            public object SetEngineerVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVisitID", value);
                }
            }

            private double _LabourRate = 1;

            public double LabourRate
            {
                get
                {
                    return _LabourRate;
                }
            }

            public object SetLabourRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LabourRate", value);
                }
            }

            private bool _ApplyMileageToTotal = true;

            public bool ApplyMileageToTotal
            {
                get
                {
                    return _ApplyMileageToTotal;
                }
            }

            public object SetApplyMileageToTotal
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ApplyMileageToTotal", value);
                }
            }

            private double _JobValue = 0;

            public double JobValue
            {
                get
                {
                    return _JobValue;
                }
            }

            public object SetJobValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobValue", value);
                }
            }

            private int _ChargeTypeID = 0;

            public int ChargeTypeID
            {
                get
                {
                    return _ChargeTypeID;
                }
            }

            public object SetChargeTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ChargeTypeID", value);
                }
            }

            private double _Charge = 0;

            public double Charge
            {
                get
                {
                    return _Charge;
                }
            }

            public object SetCharge
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Charge", value);
                }
            }

            private int _InvoiceReadyID = 0;

            public int InvoiceReadyID
            {
                get
                {
                    return _InvoiceReadyID;
                }
            }

            public object SetInvoiceReadyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoiceReadyID", value);
                }
            }

            private decimal _mainContractorDiscount = 0;

            public decimal MainContractorDiscount
            {
                get
                {
                    return _mainContractorDiscount;
                }
            }

            public object SetMainContractorDiscount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_mainContractorDiscount", value);
                }
            }

            private string _NominalCode = "";

            public string NominalCode
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

            private string _Department = "";

            public string Department
            {
                get
                {
                    return _Department;
                }
            }

            public object SetDepartment
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Department", value);
                }
            }

            private string _ForSageAccountCode = "";

            public string ForSageAccountCode
            {
                get
                {
                    return _ForSageAccountCode;
                }
            }

            public object SetForSageAccountCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ForSageAccountCode", value);
                }
            }

            private int _TaxRateID = 0;

            public int TaxRateID
            {
                get
                {
                    return _TaxRateID;
                }
            }

            public object SetTaxRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TaxRateID", value);
                }
            }

            private int _partsMarkUp = 0;

            public int PartsMarkUp
            {
                get
                {
                    return _partsMarkUp;
                }
            }

            public object SetPartsMarkUp
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_partsMarkUp", value);
                }
            }

            private decimal _partsPrice = 0;

            public decimal PartsPrice
            {
                get
                {
                    return _partsPrice;
                }
            }

            public object SetPartsPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_partsPrice", value);
                }
            }

            private decimal _labourPrice = 0;

            public decimal LabourPrice
            {
                get
                {
                    return _labourPrice;
                }
            }

            public object SetLabourPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_labourPrice", value);
                }
            }

            private bool _hasChargeFromJob;

            public bool HasChargesFromJob
            {
                get
                {
                    return _hasChargeFromJob;
                }
            }

            public object SetHasChargesFromJob
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_hasChargeFromJob", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}