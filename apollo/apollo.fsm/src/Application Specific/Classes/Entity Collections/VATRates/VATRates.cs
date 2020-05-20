using System;
using System.Collections;

namespace FSM.Entity
{
    namespace VATRatess
    {
        public class VATRates
        {
            private DataTypeValidator _dataTypeValidator;

            public VATRates()
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

            
            

            private int _VATRateID = 0;

            public int VATRateID
            {
                get
                {
                    return _VATRateID;
                }
            }

            public object SetVATRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VATRateID", value);
                }
            }

            private double _VATRate = 0;

            public double VATRate
            {
                get
                {
                    return _VATRate;
                }
            }

            public object SetVATRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VATRate", value);
                }
            }

            private DateTime _DateIntroduced = default;

            public DateTime DateIntroduced
            {
                get
                {
                    return _DateIntroduced;
                }

                set
                {
                    _DateIntroduced = value;
                }
            }

            private string _VATRateCode = "";

            public string VATRateCode
            {
                get
                {
                    return _VATRateCode;
                }
            }

            public object SetVATRateCode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VATRateCode", value);
                }
            }

            
        }
    }
}