// Decompiled with JetBrains decompiler
// Type: FSM.Entity.InvoicedLiness.InvoicedLines
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.InvoicedLiness
{
    public class InvoicedLines
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _InvoicedLineID;
        private int _InvoicedID;
        private int _InvoiceToBeRaisedID;
        private double _Amount;

        public InvoicedLines()
        {
            this._exists = false;
            this._deleted = false;
            this._InvoicedLineID = 0;
            this._InvoicedID = 0;
            this._InvoiceToBeRaisedID = 0;
            this._Amount = 0.0;
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

        public int InvoicedID
        {
            get
            {
                return this._InvoicedID;
            }
        }

        public object SetInvoicedID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoicedID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int InvoiceToBeRaisedID
        {
            get
            {
                return this._InvoiceToBeRaisedID;
            }
        }

        public object SetInvoiceToBeRaisedID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_InvoiceToBeRaisedID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double Amount
        {
            get
            {
                return this._Amount;
            }
        }

        public object SetAmount
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Amount", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}