using System;
using System.Collections;

namespace FSM.Entity
{
    namespace ContractAlternativeSiteJobOfWorks
    {
        public class ContractAlternativeSiteJobOfWork
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractAlternativeSiteJobOfWork()
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

            private DateTime _FirstVisitDate = default;

            public DateTime FirstVisitDate
            {
                get
                {
                    return _FirstVisitDate;
                }

                set
                {
                    _FirstVisitDate = value;
                }
            }

            private double _PricePerVisit = 0.0;

            public double PricePerVisit
            {
                get
                {
                    return _PricePerVisit;
                }
            }

            public object SetPricePerVisit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PricePerVisit", value);
                }
            }

            private double _AverageMileage = 0.0;

            public double AverageMileage
            {
                get
                {
                    return _AverageMileage;
                }
            }

            public object SetAverageMileage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AverageMileage", value);
                }
            }

            private double _PricePerMile = 0.0;

            public double PricePerMile
            {
                get
                {
                    return _PricePerMile;
                }
            }

            public object SetPricePerMile
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PricePerMile", value);
                }
            }

            private bool _IncludeMileagePrice = false;

            public bool IncludeMileagePrice
            {
                get
                {
                    return _IncludeMileagePrice;
                }
            }

            public object SetIncludeMileagePrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_IncludeMileagePrice", value);
                }
            }

            private bool _IncludeRates = false;

            public bool IncludeRates
            {
                get
                {
                    return _IncludeRates;
                }
            }

            public object SetIncludeRates
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_IncludeRates", value);
                }
            }

            private double _TotalSitePrice = 0;

            public double TotalSitePrice
            {
                get
                {
                    return _TotalSitePrice;
                }
            }

            public object SetTotalSitePrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TotalSitePrice", value);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}