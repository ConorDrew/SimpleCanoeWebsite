using System.Collections;
using System.Data;

namespace FSM.Entity
{
    namespace QuoteContractOriginalSites
    {
        public class QuoteContractOriginalSite
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteContractOriginalSite()
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

            
            

            private int _QuoteContractSiteID = 0;

            public int QuoteContractSiteID
            {
                get
                {
                    return _QuoteContractSiteID;
                }
            }

            public object SetQuoteContractSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractSiteID", value);
                }
            }

            private int _QuoteContractID = 0;

            public int QuoteContractID
            {
                get
                {
                    return _QuoteContractID;
                }
            }

            public object SetQuoteContractID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteContractID", value);
                }
            }

            private int _SiteID = 0;

            public int SiteID
            {
                get
                {
                    return _SiteID;
                }
            }

            public object SetSiteID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteID", value);
                }
            }

            private double _PricePerVisit = 0;

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

            private bool _IncludeAssetPrice = false;

            public bool IncludeAssetPrice
            {
                get
                {
                    return _IncludeAssetPrice;
                }
            }

            public object SetIncludeAssetPrice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_IncludeAssetPrice", value);
                }
            }

            private double _AverageMileage = 0;

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

            private double _PricePerMile = 0;

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

            private DataView _ContractSiteScheduleOfRates;

            public DataView ContractSiteScheduleOfRates
            {
                get
                {
                    return _ContractSiteScheduleOfRates;
                }

                set
                {
                    _ContractSiteScheduleOfRates = value;
                }
            }

            
        }
    }
}