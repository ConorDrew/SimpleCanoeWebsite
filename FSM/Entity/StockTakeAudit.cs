// Decompiled with JetBrains decompiler
// Type: FSM.Entity.StockTakeAudit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity
{
    public class StockTakeAudit
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _stockTakeAuditID;
        private int _partID;
        private int _originalAmount;
        private int _newAmount;
        private int _reasonChangeID;
        private int _locationID;
        private int _userID;

        public StockTakeAudit()
        {
            this._exists = false;
            this._deleted = false;
            this._stockTakeAuditID = 0;
            this._partID = 0;
            this._originalAmount = 0;
            this._newAmount = 0;
            this._reasonChangeID = 0;
            this._locationID = 0;
            this._userID = 0;
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

        public int StockTakeAuditID
        {
            get
            {
                return this._stockTakeAuditID;
            }
        }

        public object SetStockTakeAuditID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_stockTakeAuditID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PartID
        {
            get
            {
                return this._partID;
            }
        }

        public object SetPartID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_partID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int OriginalAmount
        {
            get
            {
                return this._originalAmount;
            }
        }

        public object SetOriginalAmount
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_originalAmount", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int NewAmount
        {
            get
            {
                return this._newAmount;
            }
        }

        public object SetNewAmount
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_newAmount", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ReasonChange
        {
            get
            {
                return this._reasonChangeID;
            }
        }

        public int SetReasonChange
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_reasonChangeID", (object)value);
            }
        }

        public int LocationID
        {
            get
            {
                return this._locationID;
            }
        }

        public object SetLocationID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_locationID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int UserID
        {
            get
            {
                return this._userID;
            }
        }

        public object SetUserID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_userID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}