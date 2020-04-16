// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteJobs.QuoteJob
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteJobs
{
  public class QuoteJob
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _QuoteJobID;
    private int _SiteID;
    private string _Reference;
    private int _JobDefinitionEnumID;
    private int _JobTypeID;
    private int _StatusEnumID;
    private DateTime _DateCreated;
    private int _CreatedByUserID;
    private Decimal _PartsAndProductsTotal;
    private Decimal _PartsAndProductsMarkup;
    private Decimal _ScheduleOfRatesTotal;
    private Decimal _ScheduleOfRatesMarkup;
    private Decimal _EstimatedMileage;
    private Decimal _MileageRate;
    private Decimal _GrandTotal;
    private string _ReasonForReject;
    private int _ReasonForRejectID;
    private string _NotesToEngineer;
    private string _NotesToElectrician;
    private string _NotesToBuilder;
    private double _EngineerLabourHrs;
    private double _ElectricianLabourHrs;
    private double _BuilderLabourHrs;
    private double _EngineerMarkUp;
    private double _ElectricianMarkUp;
    private double _BuilderMarkUp;
    private int _ElectricianArrivalDayNo;
    private int _ElectricianArrivalHour;
    private int _BuilderArrivalDayNo;
    private int _BuilderArrivalHour;
    private double _PartsCost;
    private double _EngineerCost;
    private double _BuilderCost;
    private double _ElectricianCost;
    private double _QuotedAmount;
    private double _DepositAmount;
    private int _VatRateID;
    private double _SORCharge;
    private double _AdditionalCosts;
    private DateTime _ChangedDateTime;
    private int _ChangedByUserID;
    private double _OriginalQuotedAmount;
    private int _ElectricianPackTypeID;
    private int _AccessEquipmentID;
    private int _AsbestosID;
    private string _AsbestosComment;
    private DateTime _EstStartDate;
    private int _SurveyVisitID;
    private string _department;
    private ArrayList _QuoteAssets;
    private ArrayList _QuoteJobOfWorks;
    private DataView _QuoteJobPartsAndProducts;
    private DataView _ScheduleOfRates;

    public QuoteJob()
    {
      this._exists = false;
      this._deleted = false;
      this._QuoteJobID = 0;
      this._SiteID = 0;
      this._Reference = string.Empty;
      this._JobDefinitionEnumID = 0;
      this._JobTypeID = 0;
      this._StatusEnumID = 0;
      this._DateCreated = DateTime.MinValue;
      this._CreatedByUserID = 0;
      this._PartsAndProductsTotal = new Decimal();
      this._PartsAndProductsMarkup = new Decimal();
      this._ScheduleOfRatesTotal = new Decimal();
      this._ScheduleOfRatesMarkup = new Decimal();
      this._EstimatedMileage = new Decimal();
      this._MileageRate = Decimal.One;
      this._GrandTotal = new Decimal();
      this._ReasonForReject = string.Empty;
      this._ReasonForRejectID = 0;
      this._NotesToEngineer = "";
      this._NotesToElectrician = "";
      this._NotesToBuilder = "";
      this._EngineerLabourHrs = 0.0;
      this._ElectricianLabourHrs = 0.0;
      this._BuilderLabourHrs = 0.0;
      this._EngineerMarkUp = 0.0;
      this._ElectricianMarkUp = 0.0;
      this._BuilderMarkUp = 0.0;
      this._ElectricianArrivalDayNo = 0;
      this._ElectricianArrivalHour = 0;
      this._BuilderArrivalDayNo = 0;
      this._BuilderArrivalHour = 0;
      this._PartsCost = 0.0;
      this._EngineerCost = 0.0;
      this._BuilderCost = 0.0;
      this._ElectricianCost = 0.0;
      this._QuotedAmount = 0.0;
      this._DepositAmount = 0.0;
      this._VatRateID = 0;
      this._SORCharge = 0.0;
      this._AdditionalCosts = 0.0;
      this._ChangedDateTime = DateTime.MinValue;
      this._ChangedByUserID = 0;
      this._OriginalQuotedAmount = 0.0;
      this._ElectricianPackTypeID = 0;
      this._AccessEquipmentID = 0;
      this._AsbestosID = 0;
      this._AsbestosComment = "";
      this._EstStartDate = DateTime.MinValue;
      this._SurveyVisitID = 0;
      this._department = "";
      this._QuoteAssets = new ArrayList();
      this._QuoteJobOfWorks = new ArrayList();
      this._QuoteJobPartsAndProducts = new DataView();
      this._dataTypeValidator = new DataTypeValidator();
    }

    public bool IgnoreExceptionsOnSetMethods
    {
      get
      {
        return this._dataTypeValidator.IgnoreExceptionsOnSetMethods;
      }
      set
      {
        this._dataTypeValidator.IgnoreExceptionsOnSetMethods = value;
      }
    }

    public Hashtable Errors
    {
      get
      {
        return this._dataTypeValidator.Errors;
      }
    }

    public DataTypeValidator DTValidator
    {
      get
      {
        return this._dataTypeValidator;
      }
    }

    public bool Exists
    {
      get
      {
        return this._exists;
      }
      set
      {
        this._exists = value;
      }
    }

    public bool Deleted
    {
      get
      {
        return this._deleted;
      }
    }

    public bool SetDeleted
    {
      set
      {
        this._deleted = value;
      }
    }

    public int QuoteJobID
    {
      get
      {
        return this._QuoteJobID;
      }
    }

    public object SetQuoteJobID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuoteJobID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int SiteID
    {
      get
      {
        return this._SiteID;
      }
    }

    public object SetSiteID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SiteID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Reference
    {
      get
      {
        return this._Reference;
      }
    }

    public object SetReference
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Reference", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobDefinitionEnumID
    {
      get
      {
        return this._JobDefinitionEnumID;
      }
    }

    public object SetJobDefinitionEnumID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobDefinitionEnumID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int JobTypeID
    {
      get
      {
        return this._JobTypeID;
      }
    }

    public object SetJobTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_JobTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int StatusEnumID
    {
      get
      {
        return this._StatusEnumID;
      }
    }

    public object SetStatusEnumID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_StatusEnumID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime DateCreated
    {
      get
      {
        return this._DateCreated;
      }
      set
      {
        this._DateCreated = value;
      }
    }

    public int CreatedByUserID
    {
      get
      {
        return this._CreatedByUserID;
      }
    }

    public object SetCreatedByUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_CreatedByUserID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal PartsAndProductsTotal
    {
      get
      {
        return this._PartsAndProductsTotal;
      }
    }

    public object SetPartsAndProductsTotal
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PartsAndProductsTotal", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal PartsAndProductsMarkup
    {
      get
      {
        return this._PartsAndProductsMarkup;
      }
    }

    public object SetPartsAndProductsMarkup
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PartsAndProductsMarkup", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal ScheduleOfRatesTotal
    {
      get
      {
        return this._ScheduleOfRatesTotal;
      }
    }

    public object SetScheduleOfRatesTotal
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ScheduleOfRatesTotal", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal ScheduleOfRatesMarkup
    {
      get
      {
        return this._ScheduleOfRatesMarkup;
      }
    }

    public object SetScheduleOfRatesMarkup
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ScheduleOfRatesMarkup", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal EstimatedMileage
    {
      get
      {
        return this._EstimatedMileage;
      }
    }

    public object SetEstimatedMileage
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EstimatedMileage", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal MileageRate
    {
      get
      {
        return this._MileageRate;
      }
    }

    public object SetMileageRate
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_MileageRate", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal GrandTotal
    {
      get
      {
        return this._GrandTotal;
      }
    }

    public object SetGrandTotal
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_GrandTotal", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string ReasonForReject
    {
      get
      {
        return this._ReasonForReject;
      }
    }

    public object SetReasonForReject
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ReasonForReject", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ReasonForRejectID
    {
      get
      {
        return this._ReasonForRejectID;
      }
    }

    public object SetReasonForRejectID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ReasonForRejectID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string NotesToEngineer
    {
      get
      {
        return this._NotesToEngineer;
      }
    }

    public object SetNotesToEngineer
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_NotesToEngineer", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string NotesToElectrician
    {
      get
      {
        return this._NotesToElectrician;
      }
    }

    public object SetNotesToElectrician
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_NotesToElectrician", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string NotesToBuilder
    {
      get
      {
        return this._NotesToBuilder;
      }
    }

    public object SetNotesToBuilder
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_NotesToBuilder", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double EngineerLabourHrs
    {
      get
      {
        return this._EngineerLabourHrs;
      }
    }

    public object SetEngineerLabourHrs
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerLabourHrs", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double ElectricianLabourHrs
    {
      get
      {
        return this._ElectricianLabourHrs;
      }
    }

    public object SetElectricianLabourHrs
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ElectricianLabourHrs", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double BuilderLabourHrs
    {
      get
      {
        return this._BuilderLabourHrs;
      }
    }

    public object SetBuilderLabourHrs
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BuilderLabourHrs", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double EngineerMarkUp
    {
      get
      {
        return this._EngineerMarkUp;
      }
    }

    public object SetEngineerMarkUp
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerMarkUp", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double ElectricianMarkUp
    {
      get
      {
        return this._ElectricianMarkUp;
      }
    }

    public object SetElectricianMarkUp
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ElectricianMarkUp", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double BuilderMarkUp
    {
      get
      {
        return this._BuilderMarkUp;
      }
    }

    public object SetBuilderMarkUp
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BuilderMarkUp", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ElectricianArrivalDayNo
    {
      get
      {
        return this._ElectricianArrivalDayNo;
      }
    }

    public object SetElectricianArrivalDayNo
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ElectricianArrivalDayNo", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ElectricianArrivalHour
    {
      get
      {
        return this._ElectricianArrivalHour;
      }
    }

    public object SetElectricianArrivalHour
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ElectricianArrivalHour", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int BuilderArrivalDayNo
    {
      get
      {
        return this._BuilderArrivalDayNo;
      }
    }

    public object SetBuilderArrivalDayNo
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BuilderArrivalDayNo", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int BuilderArrivalHour
    {
      get
      {
        return this._BuilderArrivalHour;
      }
    }

    public object SetBuilderArrivalHour
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BuilderArrivalHour", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double PartsCost
    {
      get
      {
        return this._PartsCost;
      }
    }

    public object SetPartsCost
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PartsCost", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double EngineerCost
    {
      get
      {
        return this._EngineerCost;
      }
    }

    public object SetEngineerCost
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerCost", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double BuilderCost
    {
      get
      {
        return this._BuilderCost;
      }
    }

    public object SetBuilderCost
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BuilderCost", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double ElectricianCost
    {
      get
      {
        return this._ElectricianCost;
      }
    }

    public object SetElectricianCost
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ElectricianCost", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double QuotedAmount
    {
      get
      {
        return this._QuotedAmount;
      }
    }

    public object SetQuotedAmount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_QuotedAmount", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double DepositAmount
    {
      get
      {
        return this._DepositAmount;
      }
    }

    public object SetDepositAmount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DepositAmount", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int VatRateID
    {
      get
      {
        return this._VatRateID;
      }
    }

    public object SetVatRateID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_VatRateID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double SORCharge
    {
      get
      {
        return this._SORCharge;
      }
    }

    public object SetSORCharge
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SORCharge", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double AdditionalCosts
    {
      get
      {
        return this._AdditionalCosts;
      }
    }

    public object SetAdditionalCosts
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AdditionalCosts", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime ChangedDateTime
    {
      get
      {
        return this._ChangedDateTime;
      }
      set
      {
        this._ChangedDateTime = value;
      }
    }

    public int ChangedByUserID
    {
      get
      {
        return this._ChangedByUserID;
      }
    }

    public object SetChangedByUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ChangedByUserID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double OriginalQuotedAmount
    {
      get
      {
        return this._OriginalQuotedAmount;
      }
    }

    public object SetOriginalQuotedAmount
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_OriginalQuotedAmount", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ElectricianPackTypeID
    {
      get
      {
        return this._ElectricianPackTypeID;
      }
    }

    public object SetElectricianPackTypeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ElectricianPackTypeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int AccessEquipmentID
    {
      get
      {
        return this._AccessEquipmentID;
      }
    }

    public object SetAccessEquipmentID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AccessEquipmentID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int AsbestosID
    {
      get
      {
        return this._AsbestosID;
      }
    }

    public object SetAsbestosID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AsbestosID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string AsbestosComment
    {
      get
      {
        return this._AsbestosComment;
      }
    }

    public object SetAsbestosComment
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_AsbestosComment", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime EstStartDate
    {
      get
      {
        return this._EstStartDate;
      }
      set
      {
        this._EstStartDate = value;
      }
    }

    public int SurveyVisitID
    {
      get
      {
        return this._SurveyVisitID;
      }
    }

    public object SetSurveyVisitID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_SurveyVisitID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Department
    {
      get
      {
        return this._department;
      }
    }

    public object SetDepartment
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_department", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public ArrayList QuoteAssets
    {
      get
      {
        return this._QuoteAssets;
      }
      set
      {
        this._QuoteAssets = value;
      }
    }

    public ArrayList QuoteJobOfWorks
    {
      get
      {
        return this._QuoteJobOfWorks;
      }
      set
      {
        this._QuoteJobOfWorks = value;
      }
    }

    public DataView QuoteJobPartsAndProducts
    {
      get
      {
        return this._QuoteJobPartsAndProducts;
      }
      set
      {
        this._QuoteJobPartsAndProducts = value;
      }
    }

    public DataView ScheduleOfRates
    {
      get
      {
        return this._ScheduleOfRates;
      }
      set
      {
        this._ScheduleOfRates = value;
      }
    }
  }
}
