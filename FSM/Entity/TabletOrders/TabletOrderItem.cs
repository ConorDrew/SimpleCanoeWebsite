// Decompiled with JetBrains decompiler
// Type: FSM.Entity.TabletOrders.TabletOrderItem
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.TabletOrders
{
    public class TabletOrderItem
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _TabletOrderID;
        private int _EngineerID;
        private int _SupplierID;
        private int _SelectedVisitID;
        private bool _ForNextVisit;
        private string _Status;
        private DateTime _OrderCreated;
        private DateTime _LastUpdated;

        public TabletOrderItem()
        {
            this._exists = false;
            this._deleted = false;
            this._TabletOrderID = 0;
            this._Status = string.Empty;
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

        public int TabletOrderID
        {
            get
            {
                return this._TabletOrderID;
            }
        }

        public object SetTabletOrderID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_TabletOrderID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int EngineerID
        {
            get
            {
                return this._EngineerID;
            }
        }

        public object SetEngineerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EngineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SupplierID
        {
            get
            {
                return this._SupplierID;
            }
        }

        public object SetSupplierID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SupplierID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string SelectedVisitID
        {
            get
            {
                return Conversions.ToString(this._SelectedVisitID);
            }
        }

        public object SetSelectedVisitID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SelectedVisitID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool ForNextVisit
        {
            get
            {
                return this._ForNextVisit;
            }
        }

        public object SetForNextVisit
        {
            set
            {
                this._ForNextVisit = Conversions.ToBoolean(value);
            }
        }

        public string Status
        {
            get
            {
                return this._Status;
            }
        }

        public object SetStatus
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Status", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime OrderCreated
        {
            get
            {
                return this._OrderCreated;
            }
        }

        public object SetOrderCreated
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OrderCreated", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime LastUpdated
        {
            get
            {
                return this._LastUpdated;
            }
        }

        public object SetLastUpdated
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LastUpdated", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}