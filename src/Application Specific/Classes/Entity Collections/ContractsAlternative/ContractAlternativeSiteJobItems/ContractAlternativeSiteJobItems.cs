using System.Collections;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteJobItems
    {
        public class ContractAlternativeSiteJobItems
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractAlternativeSiteJobItems()
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

            private int _ContractSiteJobItemID = 0;

            public int ContractSiteJobItemID
            {
                get
                {
                    return _ContractSiteJobItemID;
                }
            }

            public object SetContractSiteJobItemID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContractSiteJobItemID", value);
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

            private string _Description = string.Empty;

            public string Description
            {
                get
                {
                    return _Description;
                }
            }

            public object SetDescription
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Description", value);
                }
            }

            private int _VisitFrequencyID = 0;

            public int VisitFrequencyID
            {
                get
                {
                    return _VisitFrequencyID;
                }
            }

            public object SetVisitFrequencyID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitFrequencyID", value);
                }
            }

            private int _VisitDuration = 0;

            public int VisitDuration
            {
                get
                {
                    return _VisitDuration;
                }
            }

            public object SetVisitDuration
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VisitDuration", value);
                }
            }

            private double _ItemPricePerVisit = 0.0;

            public double ItemPricePerVisit
            {
                get
                {
                    return _ItemPricePerVisit;
                }
            }

            public object SetItemPricePerVisit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ItemPricePerVisit", value);
                }
            }

            private int _JobOfWorkID = 0;

            public int JobOfWorkID
            {
                get
                {
                    return _JobOfWorkID;
                }
            }

            public object SetJobOfWorkID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobOfWorkID", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}