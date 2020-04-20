using System;
using System.Collections;
using System.Data;

namespace FSM.Entity
{
    namespace ContractOriginalSites
    {
        public class ContractOriginalSite
        {
            private DataTypeValidator _dataTypeValidator;

            public ContractOriginalSite()
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

            private bool _LLCertReqd = false;

            public bool LLCertReqd
            {
                get
                {
                    return _LLCertReqd;
                }
            }

            public object SetLLCertReqd
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LLCertReqd", value);
                }
            }

            private string _AdditionalNotes = string.Empty;

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

            private bool _Commercial = false;

            public bool Commercial
            {
                get
                {
                    return _Commercial;
                }
            }

            public object SetCommercial
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Commercial", value);
                }
            }

            private int _MainAppliances = 0;

            public int MainAppliances
            {
                get
                {
                    return _MainAppliances;
                }
            }

            public object SetMainAppliances
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MainAppliances", value);
                }
            }

            private int _SecondryAppliances = 0;

            public int SecondryAppliances
            {
                get
                {
                    return _SecondryAppliances;
                }
            }

            public object SetSecondryAppliances
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SecondryAppliances", value);
                }
            }



            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}