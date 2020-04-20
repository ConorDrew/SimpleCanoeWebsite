using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractAlternativePPMVisits
    {
        public class ContractAlternativePPMVisit
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractAlternativePPMVisit()
            {
                _dataTypeValidator = new DataTypeValidator();
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

            private int _ContractSiteJobOfWorkID = 0;

            public int ContractSiteJobOfWorkID
            {
                get
                {
                    return _ContractSiteJobOfWorkID;
                }
            }

            public object SetContractSiteJobOfWorkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteJobOfWorkID", value);
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



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}