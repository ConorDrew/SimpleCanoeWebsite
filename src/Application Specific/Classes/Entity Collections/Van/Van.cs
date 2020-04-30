using System;
using System.Collections;

namespace FSM.Entity
{
    namespace Vans
    {
        public class Van
        {
            private DataTypeValidator _dataTypeValidator;

            public Van()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            
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

            
            
            private int _VanID = 0;

            public int VanID
            {
                get
                {
                    return _VanID;
                }
            }

            public object SetVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VanID", value);
                }
            }

            private string _Registration = string.Empty;

            public string Registration
            {
                get
                {
                    return _Registration;
                }
            }

            public object SetRegistration
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Registration", value);
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

            private DateTime _InsuranceDue = default;

            public DateTime InsuranceDue
            {
                get
                {
                    return _InsuranceDue;
                }

                set
                {
                    _InsuranceDue = value;
                }
            }

            private DateTime _MOTDue = default;

            public DateTime MOTDue
            {
                get
                {
                    return _MOTDue;
                }

                set
                {
                    _MOTDue = value;
                }
            }

            private DateTime _TaxDue = default;

            public DateTime TaxDue
            {
                get
                {
                    return _TaxDue;
                }

                set
                {
                    _TaxDue = value;
                }
            }

            private DateTime _ServiceDue = default;

            public DateTime ServiceDue
            {
                get
                {
                    return _ServiceDue;
                }

                set
                {
                    _ServiceDue = value;
                }
            }

            private bool _SecondaryPrice;

            public bool SecondaryPrice
            {
                get
                {
                    return _SecondaryPrice;
                }

                set
                {
                    _SecondaryPrice = value;
                }
            }

            private int _EngineerVanID;

            public int EngineerVanID
            {
                get
                {
                    return _EngineerVanID;
                }
            }

            public object SetEngineerVanID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerVanID", value);
                }
            }

            private double _MileageLimit = 0.0;

            public double MileageLimit
            {
                get
                {
                    return _MileageLimit;
                }
            }

            public object SetMileageLimit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MileageLimit", value);
                }
            }

            private int _PeriodValue = 0;

            public int PeriodValue
            {
                get
                {
                    return _PeriodValue;
                }
            }

            public object SetPeriodValue
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PeriodValue", value);
                }
            }

            private int _PeriodType = 0;

            public int PeriodType
            {
                get
                {
                    return _PeriodType;
                }
            }

            public object SetPeriodType
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PeriodType", value);
                }
            }

            private int _PreferredSupplierID = 0;

            public int PreferredSupplierID
            {
                get
                {
                    return _PreferredSupplierID;
                }
            }

            public object SetPreferredSupplierID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PreferredSupplierID", value);
                }
            }

            private bool _UseContainerStock = false;

            public bool UseContainerStock
            {
                get
                {
                    return _UseContainerStock;
                }
            }

            public bool SetUseContainerStock
            {
                set
                {
                    _UseContainerStock = value;
                }
            }

            private bool _ExcludeFromAutoReplenishment = false;

            public bool ExcludeFromAutoReplenishment
            {
                get
                {
                    return _ExcludeFromAutoReplenishment;
                }
            }

            public bool SetExcludeFromAutoReplenishment
            {
                set
                {
                    _ExcludeFromAutoReplenishment = value;
                }
            }

            
        }
    }
}