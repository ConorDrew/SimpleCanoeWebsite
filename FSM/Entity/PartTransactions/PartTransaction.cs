// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartTransactions.PartTransaction
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PartTransactions
{
    public class PartTransaction
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _PartTransactionID;
        private int _PartID;
        private int _Amount;
        private DateTime _TransactionDate;
        private int _UserID;
        private int _TransactionTypeID;
        private int _LocationID;
        private int _OrderPartID;
        private int _OrderLocationPartID;

        public PartTransaction()
        {
            this._exists = false;
            this._deleted = false;
            this._PartTransactionID = 0;
            this._PartID = 0;
            this._Amount = 0;
            this._TransactionDate = DateTime.MinValue;
            this._UserID = 0;
            this._TransactionTypeID = 0;
            this._LocationID = 0;
            this._OrderPartID = 0;
            this._OrderLocationPartID = 0;
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

        public int PartTransactionID
        {
            get
            {
                return this._PartTransactionID;
            }
        }

        public object SetPartTransactionID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartTransactionID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PartID
        {
            get
            {
                return this._PartID;
            }
        }

        public object SetPartID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PartID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int Amount
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

        public DateTime TransactionDate
        {
            get
            {
                return this._TransactionDate;
            }
            set
            {
                this._TransactionDate = value;
            }
        }

        public int UserID
        {
            get
            {
                return this._UserID;
            }
        }

        public object SetUserID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_UserID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int TransactionTypeID
        {
            get
            {
                return this._TransactionTypeID;
            }
        }

        public object SetTransactionTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TransactionTypeID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int LocationID
        {
            get
            {
                return this._LocationID;
            }
        }

        public object SetLocationID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LocationID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OrderPartID
        {
            get
            {
                return this._OrderPartID;
            }
        }

        public object SetOrderPartID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderPartID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OrderLocationPartID
        {
            get
            {
                return this._OrderLocationPartID;
            }
        }

        public object SetOrderLocationPartID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderLocationPartID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}