// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobOfWorks.QuoteJobOfWork
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobOfWorks
{
    public class QuoteJobOfWork
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _QuoteJobOfWorkID;
        private int _QuoteJobID;
        private ArrayList _QuotejobItems;
        private ArrayList _QuoteengineerVisits;

        public QuoteJobOfWork()
        {
            this._exists = false;
            this._deleted = false;
            this._QuoteJobOfWorkID = 0;
            this._QuoteJobID = 0;
            this._QuotejobItems = new ArrayList();
            this._QuoteengineerVisits = new ArrayList();
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

        public int QuoteJobOfWorkID
        {
            get
            {
                return this._QuoteJobOfWorkID;
            }
        }

        public object SetQuoteJobOfWorkID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteJobOfWorkID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int QuoteJobID
        {
            get
            {
                return this._QuoteJobID;
            }
        }

        public object SetQuoteJobID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_QuoteJobID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public ArrayList QuoteJobItems
        {
            get
            {
                return this._QuotejobItems;
            }
            set
            {
                this._QuotejobItems = value;
            }
        }

        public ArrayList QuoteEngineerVisits
        {
            get
            {
                return this._QuoteengineerVisits;
            }
            set
            {
                this._QuoteengineerVisits = value;
            }
        }
    }
}