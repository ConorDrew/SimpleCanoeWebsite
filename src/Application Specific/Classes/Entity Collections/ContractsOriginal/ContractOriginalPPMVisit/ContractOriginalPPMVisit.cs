using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractOriginalPPMVisits
    {
        public class ContractOriginalPPMVisit
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOriginalPPMVisit()
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

            
            

            private int _ContractPPMVisitID = 0;

            public int ContractPPMVisitID
            {
                get
                {
                    return _ContractPPMVisitID;
                }
            }

            public object SetContractPPMVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractPPMVisitID", value);
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



            
        }
    }
}