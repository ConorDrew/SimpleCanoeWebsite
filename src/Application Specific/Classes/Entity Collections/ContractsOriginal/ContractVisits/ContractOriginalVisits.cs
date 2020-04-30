using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractOriginalVisits
    {
        public class ContractOriginalVisit
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOriginalVisit()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            
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

            
            

            private int _ContractVisitID = 0;

            public int ContractVisitID
            {
                get
                {
                    return _ContractVisitID;
                }
            }

            public object SetContractVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractVisitID", value);
                }
            }

            private string _SubContractor = 0.ToString();

            public string SubContractor
            {
                get
                {
                    return _SubContractor;
                }
            }

            public object SetSubContractor
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SubContractor", value);
                }
            }

            private string _PreferredEngineer = "";

            public string PreferredEngineer
            {
                get
                {
                    return _PreferredEngineer;
                }
            }

            public object SetPreferredEngineer
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PreferredEngineer", value);
                }
            }

            private string _VisitType = "";

            public string VisitType
            {
                get
                {
                    return _VisitType;
                }
            }

            public object SetVisitType
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitType", value);
                }
            }

            private string _Frequency = "";

            public string Frequency
            {
                get
                {
                    return _Frequency;
                }
            }

            public object SetFrequency
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Frequency", value);
                }
            }

            private int _ContractSiteID = 0;

            public int ContractSiteID
            {
                get
                {
                    return _ContractSiteID;
                }
            }

            public object SetContractSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteID", value);
                }
            }

            private DateTime _EstimatedVisitDate = default;

            public DateTime EstimatedVisitDate
            {
                get
                {
                    return _EstimatedVisitDate;
                }

                set
                {
                    _EstimatedVisitDate = value;
                }
            }

            private int _JobID = 0;

            public int JobID
            {
                get
                {
                    return _JobID;
                }
            }

            public object SetJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobID", value);
                }
            }

            private int _SubContractorID = 0;

            public int SubContractorID
            {
                get
                {
                    return _SubContractorID;
                }
            }

            public object SetSubContractorID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SubContractorID", value);
                }
            }

            private int _PreferredEngineerID = 0;

            public int PreferredEngineerID
            {
                get
                {
                    return _PreferredEngineerID;
                }
            }

            public object SetPreferredEngineerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PreferredEngineerID", value);
                }
            }

            private double _Cost = 0;

            public double Cost
            {
                get
                {
                    return _Cost;
                }
            }

            public object SetCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Cost", value);
                }
            }

            private int _FrequencyID = 0;

            public int FrequencyID
            {
                get
                {
                    return _FrequencyID;
                }
            }

            public object SetFrequencyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FrequencyID", value);
                }
            }

            private int _VisitTypeID = 0;

            public int VisitTypeID
            {
                get
                {
                    return _VisitTypeID;
                }
            }

            public object SetVisitTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitType", value);
                }
            }

            private int _HoursReq = 0;

            public int HoursReq
            {
                get
                {
                    return _HoursReq;
                }
            }

            public object SetHoursReq
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_HoursReq", value);
                }
            }

            private string _AdditionalNotes = "";

            public string AdditionalNotes
            {
                get
                {
                    return _AdditionalNotes;
                }
            }

            public object SetAdditionalNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AdditionalNotes", value);
                }
            }


            
        }
    }
}