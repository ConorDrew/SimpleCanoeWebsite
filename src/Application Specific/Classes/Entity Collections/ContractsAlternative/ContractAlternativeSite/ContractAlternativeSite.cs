using System.Collections;

namespace FSM.Entity
{
    namespace ContractAlternativeSites
    {
        public class ContractAlternativeSite
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractAlternativeSite()
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

            private int _ContractID = 0;

            public int ContractID
            {
                get
                {
                    return _ContractID;
                }
            }

            public object SetContractID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractID", value);
                }
            }

            private int _PropertyID = 0;

            public int PropertyID
            {
                get
                {
                    return _PropertyID;
                }
            }

            public object SetPropertyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PropertyID", value);
                }
            }

            private ArrayList _jobOfWorks = new ArrayList();

            public ArrayList JobOfWorks
            {
                get
                {
                    return _jobOfWorks;
                }

                set
                {
                    _jobOfWorks = value;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}