// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOption3SitePPMVisits.ContractOption3SitePPMVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOption3SitePPMVisits
{
    public class ContractOption3SitePPMVisit
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _ContractSitePPMVisitID;
        private int _ContractSiteID;
        private DateTime _VisitDate;
        private int _JobID;

        public ContractOption3SitePPMVisit()
        {
            this._exists = false;
            this._deleted = false;
            this._ContractSitePPMVisitID = 0;
            this._ContractSiteID = 0;
            this._VisitDate = DateTime.MinValue;
            this._JobID = 0;
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

        public int ContractSitePPMVisitID
        {
            get
            {
                return this._ContractSitePPMVisitID;
            }
        }

        public object SetContractSitePPMVisitID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractSitePPMVisitID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ContractSiteID
        {
            get
            {
                return this._ContractSiteID;
            }
        }

        public object SetContractSiteID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractSiteID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime VisitDate
        {
            get
            {
                return this._VisitDate;
            }
            set
            {
                this._VisitDate = value;
            }
        }

        public int JobID
        {
            get
            {
                return this._JobID;
            }
        }

        public object SetJobID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_JobID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}