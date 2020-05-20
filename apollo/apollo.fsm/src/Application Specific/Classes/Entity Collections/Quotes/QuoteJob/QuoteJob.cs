using System;
using System.Collections;
using System.Data;

namespace FSM.Entity
{
    namespace QuoteJobs
    {
        public class QuoteJob
        {
            private DataTypeValidator _dataTypeValidator;

            public QuoteJob()
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

            
            
            private int _QuoteJobID = 0;

            public int QuoteJobID
            {
                get
                {
                    return _QuoteJobID;
                }
            }

            public object SetQuoteJobID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuoteJobID", value);
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

            private string _Reference = string.Empty;

            public string Reference
            {
                get
                {
                    return _Reference;
                }
            }

            public object SetReference
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Reference", value);
                }
            }

            private int _JobDefinitionEnumID = 0;

            public int JobDefinitionEnumID
            {
                get
                {
                    return _JobDefinitionEnumID;
                }
            }

            public object SetJobDefinitionEnumID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobDefinitionEnumID", value);
                }
            }

            private int _JobTypeID = 0;

            public int JobTypeID
            {
                get
                {
                    return _JobTypeID;
                }
            }

            public object SetJobTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_JobTypeID", value);
                }
            }

            private int _StatusEnumID = 0;

            public int StatusEnumID
            {
                get
                {
                    return _StatusEnumID;
                }
            }

            public object SetStatusEnumID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_StatusEnumID", value);
                }
            }

            private DateTime _DateCreated = default;

            public DateTime DateCreated
            {
                get
                {
                    return _DateCreated;
                }

                set
                {
                    _DateCreated = value;
                }
            }

            private int _CreatedByUserID = 0;

            public int CreatedByUserID
            {
                get
                {
                    return _CreatedByUserID;
                }
            }

            public object SetCreatedByUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CreatedByUserID", value);
                }
            }

            private decimal _PartsAndProductsTotal = 0;

            public decimal PartsAndProductsTotal
            {
                get
                {
                    return _PartsAndProductsTotal;
                }
            }

            public object SetPartsAndProductsTotal
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsAndProductsTotal", value);
                }
            }

            private decimal _PartsAndProductsMarkup = 0;

            public decimal PartsAndProductsMarkup
            {
                get
                {
                    return _PartsAndProductsMarkup;
                }
            }

            public object SetPartsAndProductsMarkup
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsAndProductsMarkup", value);
                }
            }

            private decimal _ScheduleOfRatesTotal = 0;

            public decimal ScheduleOfRatesTotal
            {
                get
                {
                    return _ScheduleOfRatesTotal;
                }
            }

            public object SetScheduleOfRatesTotal
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ScheduleOfRatesTotal", value);
                }
            }

            private decimal _ScheduleOfRatesMarkup = 0;

            public decimal ScheduleOfRatesMarkup
            {
                get
                {
                    return _ScheduleOfRatesMarkup;
                }
            }

            public object SetScheduleOfRatesMarkup
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ScheduleOfRatesMarkup", value);
                }
            }

            private decimal _EstimatedMileage = 0;

            public decimal EstimatedMileage
            {
                get
                {
                    return _EstimatedMileage;
                }
            }

            public object SetEstimatedMileage
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EstimatedMileage", value);
                }
            }

            private decimal _MileageRate = 1;

            public decimal MileageRate
            {
                get
                {
                    return _MileageRate;
                }
            }

            public object SetMileageRate
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_MileageRate", value);
                }
            }

            private decimal _GrandTotal = 0;

            public decimal GrandTotal
            {
                get
                {
                    return _GrandTotal;
                }
            }

            public object SetGrandTotal
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_GrandTotal", value);
                }
            }

            private string _ReasonForReject = string.Empty;

            public string ReasonForReject
            {
                get
                {
                    return _ReasonForReject;
                }
            }

            public object SetReasonForReject
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForReject", value);
                }
            }

            private int _ReasonForRejectID = 0;

            public int ReasonForRejectID
            {
                get
                {
                    return _ReasonForRejectID;
                }
            }

            public object SetReasonForRejectID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForRejectID", value);
                }
            }

            private string _NotesToEngineer = "";

            public string NotesToEngineer
            {
                get
                {
                    return _NotesToEngineer;
                }
            }

            public object SetNotesToEngineer
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NotesToEngineer", value);
                }
            }

            private string _NotesToElectrician = "";

            public string NotesToElectrician
            {
                get
                {
                    return _NotesToElectrician;
                }
            }

            public object SetNotesToElectrician
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NotesToElectrician", value);
                }
            }

            private string _NotesToBuilder = "";

            public string NotesToBuilder
            {
                get
                {
                    return _NotesToBuilder;
                }
            }

            public object SetNotesToBuilder
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NotesToBuilder", value);
                }
            }

            private double _EngineerLabourHrs = 0;

            public double EngineerLabourHrs
            {
                get
                {
                    return _EngineerLabourHrs;
                }
            }

            public object SetEngineerLabourHrs
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerLabourHrs", value);
                }
            }

            private double _ElectricianLabourHrs = 0;

            public double ElectricianLabourHrs
            {
                get
                {
                    return _ElectricianLabourHrs;
                }
            }

            public object SetElectricianLabourHrs
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ElectricianLabourHrs", value);
                }
            }

            private double _BuilderLabourHrs = 0;

            public double BuilderLabourHrs
            {
                get
                {
                    return _BuilderLabourHrs;
                }
            }

            public object SetBuilderLabourHrs
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BuilderLabourHrs", value);
                }
            }

            private double _EngineerMarkUp = 0;

            public double EngineerMarkUp
            {
                get
                {
                    return _EngineerMarkUp;
                }
            }

            public object SetEngineerMarkUp
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerMarkUp", value);
                }
            }

            private double _ElectricianMarkUp = 0;

            public double ElectricianMarkUp
            {
                get
                {
                    return _ElectricianMarkUp;
                }
            }

            public object SetElectricianMarkUp
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ElectricianMarkUp", value);
                }
            }

            private double _BuilderMarkUp = 0;

            public double BuilderMarkUp
            {
                get
                {
                    return _BuilderMarkUp;
                }
            }

            public object SetBuilderMarkUp
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BuilderMarkUp", value);
                }
            }

            private int _ElectricianArrivalDayNo = 0;

            public int ElectricianArrivalDayNo
            {
                get
                {
                    return _ElectricianArrivalDayNo;
                }
            }

            public object SetElectricianArrivalDayNo
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ElectricianArrivalDayNo", value);
                }
            }

            private int _ElectricianArrivalHour = 0;

            public int ElectricianArrivalHour
            {
                get
                {
                    return _ElectricianArrivalHour;
                }
            }

            public object SetElectricianArrivalHour
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ElectricianArrivalHour", value);
                }
            }

            private int _BuilderArrivalDayNo = 0;

            public int BuilderArrivalDayNo
            {
                get
                {
                    return _BuilderArrivalDayNo;
                }
            }

            public object SetBuilderArrivalDayNo
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BuilderArrivalDayNo", value);
                }
            }

            private int _BuilderArrivalHour = 0;

            public int BuilderArrivalHour
            {
                get
                {
                    return _BuilderArrivalHour;
                }
            }

            public object SetBuilderArrivalHour
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BuilderArrivalHour", value);
                }
            }

            private double _PartsCost = 0;

            public double PartsCost
            {
                get
                {
                    return _PartsCost;
                }
            }

            public object SetPartsCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PartsCost", value);
                }
            }

            private double _EngineerCost = 0;

            public double EngineerCost
            {
                get
                {
                    return _EngineerCost;
                }
            }

            public object SetEngineerCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerCost", value);
                }
            }

            private double _BuilderCost = 0;

            public double BuilderCost
            {
                get
                {
                    return _BuilderCost;
                }
            }

            public object SetBuilderCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BuilderCost", value);
                }
            }

            private double _ElectricianCost = 0;

            public double ElectricianCost
            {
                get
                {
                    return _ElectricianCost;
                }
            }

            public object SetElectricianCost
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ElectricianCost", value);
                }
            }

            private double _QuotedAmount = 0;

            public double QuotedAmount
            {
                get
                {
                    return _QuotedAmount;
                }
            }

            public object SetQuotedAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_QuotedAmount", value);
                }
            }

            private double _DepositAmount = 0;

            public double DepositAmount
            {
                get
                {
                    return _DepositAmount;
                }
            }

            public object SetDepositAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DepositAmount", value);
                }
            }

            private int _VatRateID = 0;

            public int VatRateID
            {
                get
                {
                    return _VatRateID;
                }
            }

            public object SetVatRateID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_VatRateID", value);
                }
            }

            private double _SORCharge = 0;

            public double SORCharge
            {
                get
                {
                    return _SORCharge;
                }
            }

            public object SetSORCharge
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SORCharge", value);
                }
            }

            private double _AdditionalCosts = 0;

            public double AdditionalCosts
            {
                get
                {
                    return _AdditionalCosts;
                }
            }

            public object SetAdditionalCosts
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AdditionalCosts", value);
                }
            }

            private DateTime _ChangedDateTime = default;

            public DateTime ChangedDateTime
            {
                get
                {
                    return _ChangedDateTime;
                }

                set
                {
                    _ChangedDateTime = value;
                }
            }

            private int _ChangedByUserID = 0;

            public int ChangedByUserID
            {
                get
                {
                    return _ChangedByUserID;
                }
            }

            public object SetChangedByUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ChangedByUserID", value);
                }
            }

            private double _OriginalQuotedAmount = 0;

            public double OriginalQuotedAmount
            {
                get
                {
                    return _OriginalQuotedAmount;
                }
            }

            public object SetOriginalQuotedAmount
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OriginalQuotedAmount", value);
                }
            }

            private int _ElectricianPackTypeID = 0;

            public int ElectricianPackTypeID
            {
                get
                {
                    return _ElectricianPackTypeID;
                }
            }

            public object SetElectricianPackTypeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ElectricianPackTypeID", value);
                }
            }

            private int _AccessEquipmentID = 0;

            public int AccessEquipmentID
            {
                get
                {
                    return _AccessEquipmentID;
                }
            }

            public object SetAccessEquipmentID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AccessEquipmentID", value);
                }
            }

            private int _AsbestosID = 0;

            public int AsbestosID
            {
                get
                {
                    return _AsbestosID;
                }
            }

            public object SetAsbestosID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AsbestosID", value);
                }
            }

            private string _AsbestosComment = "";

            public string AsbestosComment
            {
                get
                {
                    return _AsbestosComment;
                }
            }

            public object SetAsbestosComment
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AsbestosComment", value);
                }
            }

            private DateTime _EstStartDate = DateTime.MinValue;

            public DateTime EstStartDate
            {
                get
                {
                    return _EstStartDate;
                }

                set
                {
                    _EstStartDate = value;
                }
            }

            private int _SurveyVisitID = 0;

            public int SurveyVisitID
            {
                get
                {
                    return _SurveyVisitID;
                }
            }

            public object SetSurveyVisitID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SurveyVisitID", value);
                }
            }

            private string _department = "";

            public string Department
            {
                get
                {
                    return _department;
                }
            }

            public object SetDepartment
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_department", value);
                }
            }

            
            
            private ArrayList _QuoteAssets = new ArrayList();

            public ArrayList QuoteAssets
            {
                get
                {
                    return _QuoteAssets;
                }

                set
                {
                    _QuoteAssets = value;
                }
            }

            private ArrayList _QuoteJobOfWorks = new ArrayList();

            public ArrayList QuoteJobOfWorks
            {
                get
                {
                    return _QuoteJobOfWorks;
                }

                set
                {
                    _QuoteJobOfWorks = value;
                }
            }

            private DataView _QuoteJobPartsAndProducts = new DataView();

            public DataView QuoteJobPartsAndProducts
            {
                get
                {
                    return _QuoteJobPartsAndProducts;
                }

                set
                {
                    _QuoteJobPartsAndProducts = value;
                }
            }

            private DataView _ScheduleOfRates;

            public DataView ScheduleOfRates
            {
                get
                {
                    return _ScheduleOfRates;
                }

                set
                {
                    _ScheduleOfRates = value;
                }
            }

            
        }
    }
}