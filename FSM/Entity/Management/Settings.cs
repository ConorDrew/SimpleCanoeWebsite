// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Management.Settings
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Management
{
    public class Settings
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private string _WorkingHoursStart;
        private string _WorkingHoursEnd;
        private string _OverridePassword;
        private string _OverridePassword_Service;
        private double _MileageRate;
        private double _PartsMarkup;
        private double _RatesMarkup;
        private string _CalloutPrefix;
        private string _MiscPrefix;
        private string _PPMPrefix;
        private string _QuotePrefix;
        private int _TimeSlot;
        private string _InvoicePrefix;
        private int _RecallVariable;
        private double _PartsImportMarkup;
        private string _ServiceFromLetterPrefix;

        public Settings()
        {
            this._exists = false;
            this._deleted = false;
            this._WorkingHoursStart = string.Empty;
            this._WorkingHoursEnd = string.Empty;
            this._OverridePassword = string.Empty;
            this._OverridePassword_Service = string.Empty;
            this._MileageRate = 1.0;
            this._PartsMarkup = 0.0;
            this._RatesMarkup = 0.0;
            this._CalloutPrefix = string.Empty;
            this._MiscPrefix = string.Empty;
            this._PPMPrefix = string.Empty;
            this._QuotePrefix = string.Empty;
            this._TimeSlot = 0;
            this._InvoicePrefix = string.Empty;
            this._RecallVariable = 0;
            this._PartsImportMarkup = 0.0;
            this._ServiceFromLetterPrefix = string.Empty;
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

        public string WorkingHoursStart
        {
            get
            {
                return this._WorkingHoursStart;
            }
        }

        public object SetWorkingHoursStart
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_WorkingHoursStart", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string WorkingHoursEnd
        {
            get
            {
                return this._WorkingHoursEnd;
            }
        }

        public object SetWorkingHoursEnd
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_WorkingHoursEnd", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string OverridePassword
        {
            get
            {
                return this._OverridePassword;
            }
        }

        public object SetOverridePassword
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OverridePassword", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string OverridePassword_Service
        {
            get
            {
                return this._OverridePassword_Service;
            }
        }

        public object SetOverridePassword_Service
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OverridePassword_Service", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double MileageRate
        {
            get
            {
                return this._MileageRate;
            }
        }

        public object SetMileageRate
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MileageRate", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double PartsMarkup
        {
            get
            {
                return this._PartsMarkup;
            }
        }

        public object SetPartsMarkup
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartsMarkup", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double RatesMarkup
        {
            get
            {
                return this._RatesMarkup;
            }
        }

        public object SetRatesMarkup
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_RatesMarkup", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string CalloutPrefix
        {
            get
            {
                return this._CalloutPrefix;
            }
        }

        public object SetCalloutPrefix
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CalloutPrefix", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string MiscPrefix
        {
            get
            {
                return this._MiscPrefix;
            }
        }

        public object SetMiscPrefix
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_MiscPrefix", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string PPMPrefix
        {
            get
            {
                return this._PPMPrefix;
            }
        }

        public object SetPPMPrefix
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PPMPrefix", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string QuotePrefix
        {
            get
            {
                return this._QuotePrefix;
            }
        }

        public object SetQuotePrefix
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuotePrefix", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int TimeSlot
        {
            get
            {
                return this._TimeSlot;
            }
        }

        public object SetTimeSlot
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TimeSlot", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string InvoicePrefix
        {
            get
            {
                return this._InvoicePrefix;
            }
        }

        public object SetInvoicePrefix
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoicePrefix", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int RecallVariable
        {
            get
            {
                return this._RecallVariable;
            }
        }

        public object SetRecallVariable
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_RecallVariable", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double PartsImportMarkup
        {
            get
            {
                return this._PartsImportMarkup;
            }
        }

        public object SetPartsImportMarkup
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartsImportMarkup", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string ServiceFromLetterPrefix
        {
            get
            {
                return this._ServiceFromLetterPrefix;
            }
        }

        public object SetServiceFromLetterPrefix
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ServiceFromLetterPrefix", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}