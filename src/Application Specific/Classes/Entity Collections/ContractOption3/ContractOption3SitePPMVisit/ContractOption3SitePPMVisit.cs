using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractOption3SitePPMVisits
    {
        public class ContractOption3SitePPMVisit
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOption3SitePPMVisit()
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

            private bool _deleted = false;

            public bool Deleted
            {
                get
                {
                    return _deleted;
                }
            }

            public bool SetDeleted
            {
                set
                {
                    _deleted = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private int _ContractSitePPMVisitID = 0;

            public int ContractSitePPMVisitID
            {
                get
                {
                    return _ContractSitePPMVisitID;
                }
            }

            public object SetContractSitePPMVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSitePPMVisitID", value);
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

            private DateTime _VisitDate = default;

            public DateTime VisitDate
            {
                get
                {
                    return _VisitDate;
                }

                set
                {
                    _VisitDate = value;
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