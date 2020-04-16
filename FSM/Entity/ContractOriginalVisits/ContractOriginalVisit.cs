// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ContractOriginalVisits.ContractOriginalVisit
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ContractOriginalVisits
{
    public class ContractOriginalVisit
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private int _ContractVisitID;
        private string _SubContractor;
        private string _PreferredEngineer;
        private string _VisitType;
        private string _Frequency;
        private int _ContractSiteID;
        private DateTime _EstimatedVisitDate;
        private int _JobID;
        private int _SubContractorID;
        private int _PreferredEngineerID;
        private double _Cost;
        private int _FrequencyID;
        private int _VisitTypeID;
        private int _HoursReq;
        private string _AdditionalNotes;

        public ContractOriginalVisit()
        {
            this._exists = false;
            this._ContractVisitID = 0;
            this._SubContractor = Conversions.ToString(0);
            this._PreferredEngineer = "";
            this._VisitType = "";
            this._Frequency = "";
            this._ContractSiteID = 0;
            this._EstimatedVisitDate = DateTime.MinValue;
            this._JobID = 0;
            this._SubContractorID = 0;
            this._PreferredEngineerID = 0;
            this._Cost = 0.0;
            this._FrequencyID = 0;
            this._VisitTypeID = 0;
            this._HoursReq = 0;
            this._AdditionalNotes = "";
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

        public int ContractVisitID
        {
            get
            {
                return this._ContractVisitID;
            }
        }

        public object SetContractVisitID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContractVisitID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string SubContractor
        {
            get
            {
                return this._SubContractor;
            }
        }

        public object SetSubContractor
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SubContractor", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string PreferredEngineer
        {
            get
            {
                return this._PreferredEngineer;
            }
        }

        public object SetPreferredEngineer
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PreferredEngineer", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string VisitType
        {
            get
            {
                return this._VisitType;
            }
        }

        public object SetVisitType
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VisitType", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Frequency
        {
            get
            {
                return this._Frequency;
            }
        }

        public object SetFrequency
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Frequency", RuntimeHelpers.GetObjectValue(value));
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

        public DateTime EstimatedVisitDate
        {
            get
            {
                return this._EstimatedVisitDate;
            }
            set
            {
                this._EstimatedVisitDate = value;
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

        public int SubContractorID
        {
            get
            {
                return this._SubContractorID;
            }
        }

        public object SetSubContractorID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SubContractorID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int PreferredEngineerID
        {
            get
            {
                return this._PreferredEngineerID;
            }
        }

        public object SetPreferredEngineerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PreferredEngineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public double Cost
        {
            get
            {
                return this._Cost;
            }
        }

        public object SetCost
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Cost", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int FrequencyID
        {
            get
            {
                return this._FrequencyID;
            }
        }

        public object SetFrequencyID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FrequencyID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int VisitTypeID
        {
            get
            {
                return this._VisitTypeID;
            }
        }

        public object SetVisitTypeID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_VisitType", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int HoursReq
        {
            get
            {
                return this._HoursReq;
            }
        }

        public object SetHoursReq
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_HoursReq", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string AdditionalNotes
        {
            get
            {
                return this._AdditionalNotes;
            }
        }

        public object SetAdditionalNotes
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AdditionalNotes", RuntimeHelpers.GetObjectValue(value));
            }
        }
    }
}