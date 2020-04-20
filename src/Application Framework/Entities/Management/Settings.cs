using System.Collections;

namespace FSM.Entity
{
    namespace Management
    {
        public class Settings
        {
            private DataTypeValidator _dataTypeValidator;

            public Settings()
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
            private string _WorkingHoursStart = string.Empty;

            public string WorkingHoursStart
            {
                get
                {
                    return _WorkingHoursStart;
                }
            }

            public object SetWorkingHoursStart
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WorkingHoursStart", value);
                }
            }

            private string _WorkingHoursEnd = string.Empty;

            public string WorkingHoursEnd
            {
                get
                {
                    return _WorkingHoursEnd;
                }
            }

            public object SetWorkingHoursEnd
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WorkingHoursEnd", value);
                }
            }

            private string _OverridePassword = string.Empty;

            public string OverridePassword
            {
                get
                {
                    return _OverridePassword;
                }
            }

            public object SetOverridePassword
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OverridePassword", value);
                }
            }

            private string _OverridePassword_Service = string.Empty;

            public string OverridePassword_Service
            {
                get
                {
                    return _OverridePassword_Service;
                }
            }

            public object SetOverridePassword_Service
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OverridePassword_Service", value);
                }
            }

            private double _MileageRate = 1;

            public double MileageRate
            {
                get
                {
                    return _MileageRate;
                }
            }

            public object SetMileageRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MileageRate", value);
                }
            }

            private double _PartsMarkup = 0;

            public double PartsMarkup
            {
                get
                {
                    return _PartsMarkup;
                }
            }

            public object SetPartsMarkup
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsMarkup", value);
                }
            }

            private double _RatesMarkup = 0;

            public double RatesMarkup
            {
                get
                {
                    return _RatesMarkup;
                }
            }

            public object SetRatesMarkup
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RatesMarkup", value);
                }
            }

            private string _CalloutPrefix = string.Empty;

            public string CalloutPrefix
            {
                get
                {
                    return _CalloutPrefix;
                }
            }

            public object SetCalloutPrefix
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CalloutPrefix", value);
                }
            }

            private string _MiscPrefix = string.Empty;

            public string MiscPrefix
            {
                get
                {
                    return _MiscPrefix;
                }
            }

            public object SetMiscPrefix
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MiscPrefix", value);
                }
            }

            private string _PPMPrefix = string.Empty;

            public string PPMPrefix
            {
                get
                {
                    return _PPMPrefix;
                }
            }

            public object SetPPMPrefix
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PPMPrefix", value);
                }
            }

            private string _QuotePrefix = string.Empty;

            public string QuotePrefix
            {
                get
                {
                    return _QuotePrefix;
                }
            }

            public object SetQuotePrefix
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuotePrefix", value);
                }
            }

            private int _TimeSlot = 0;

            public int TimeSlot
            {
                get
                {
                    return _TimeSlot;
                }
            }

            public object SetTimeSlot
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TimeSlot", value);
                }
            }

            private string _InvoicePrefix = string.Empty;

            public string InvoicePrefix
            {
                get
                {
                    return _InvoicePrefix;
                }
            }

            public object SetInvoicePrefix
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_InvoicePrefix", value);
                }
            }

            private int _RecallVariable = 0;

            public int RecallVariable
            {
                get
                {
                    return _RecallVariable;
                }
            }

            public object SetRecallVariable
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RecallVariable", value);
                }
            }

            private double _PartsImportMarkup = 0;

            public double PartsImportMarkup
            {
                get
                {
                    return _PartsImportMarkup;
                }
            }

            public object SetPartsImportMarkup
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsImportMarkup", value);
                }
            }

            private string _ServiceFromLetterPrefix = string.Empty;

            public string ServiceFromLetterPrefix
            {
                get
                {
                    return _ServiceFromLetterPrefix;
                }
            }

            public object SetServiceFromLetterPrefix
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ServiceFromLetterPrefix", value);
                }
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}