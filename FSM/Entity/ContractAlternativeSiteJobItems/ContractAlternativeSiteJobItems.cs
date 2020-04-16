// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractAlternativeSiteJobItems.ContractAlternativeSiteJobItems
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractAlternativeSiteJobItems
{
    public class ContractAlternativeSiteJobItems
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _ContractSiteJobItemID;
        private int _ContractSiteID;
        private string _Description;
        private int _VisitFrequencyID;
        private int _VisitDuration;
        private double _ItemPricePerVisit;
        private int _JobOfWorkID;

        public ContractAlternativeSiteJobItems()
        {
            this._exists = false;
            this._deleted = false;
            this._ContractSiteJobItemID = 0;
            this._ContractSiteID = 0;
            this._Description = string.Empty;
            this._VisitFrequencyID = 0;
            this._VisitDuration = 0;
            this._ItemPricePerVisit = 0.0;
            this._JobOfWorkID = 0;
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

        public int ContractSiteJobItemID
        {
            get
            {
                return this._ContractSiteJobItemID;
            }
        }

        public object SetContractSiteJobItemID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractSiteJobItemID", RuntimeHelpers.GetObjectValue(value));
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

        public string Description
        {
            get
            {
                return this._Description;
            }
        }

        public object SetDescription
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Description", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VisitFrequencyID
        {
            get
            {
                return this._VisitFrequencyID;
            }
        }

        public object SetVisitFrequencyID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VisitFrequencyID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VisitDuration
        {
            get
            {
                return this._VisitDuration;
            }
        }

        public object SetVisitDuration
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VisitDuration", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double ItemPricePerVisit
        {
            get
            {
                return this._ItemPricePerVisit;
            }
        }

        public object SetItemPricePerVisit
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ItemPricePerVisit", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int JobOfWorkID
        {
            get
            {
                return this._JobOfWorkID;
            }
        }

        public object SetJobOfWorkID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_JobOfWorkID", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}