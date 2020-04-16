// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Engineers.Engineer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Engineers
{
  public class Engineer
  {
    private DataTypeValidator _dataTypeValidator;
    private bool _exists;
    private bool _deleted;
    private int _EngineerID;
    private int _RegionID;
    private string _Name;
    private string _TelephoneNum;
    private int _PDAID;
    private bool _Apprentice;
    private double _costToCompanyDouble;
    private double _costToCompanyTimeAndHalf;
    private double _costToCompanyNormal;
    private string _nextOfKinName;
    private string _nextOfKinContact;
    private string _startingDetails;
    private string _drivingLicenceNo;
    private DateTime _drivingLicenceIssueDate;
    private int _payGradeID;
    private Decimal _annualSalary;
    private string _nINumber;
    private string _holidayYearStart;
    private string _holidayYearEnd;
    private Decimal _daysHolidayAllowed;
    private string _gasSafeNo;
    private string _oftecNo;
    private int _engineerGroupID;
    private string _supervisor;
    private string _technician;
    private string _Department;
    private int _ServPri;
    private int _BreakPri;
    private int _DailyServiceLimit;
    private string _HomePostcode;
    private Decimal _Longitude;
    private Decimal _Latitude;
    private int _ManagerUserID;
    private string _WebAppPassword;
    private int _ragRating;
    private int _UserID;
    private Decimal _visitSpendLimit;
    private Decimal _engineerRoleId;
    private string _emailAddress;

    public Engineer()
    {
      this._exists = false;
      this._deleted = false;
      this._EngineerID = 0;
      this._RegionID = 0;
      this._Name = string.Empty;
      this._TelephoneNum = string.Empty;
      this._PDAID = 0;
      this._Apprentice = false;
      this._costToCompanyDouble = 0.0;
      this._costToCompanyTimeAndHalf = 0.0;
      this._costToCompanyNormal = 0.0;
      this._nextOfKinName = "";
      this._nextOfKinContact = "";
      this._startingDetails = "";
      this._drivingLicenceNo = "";
      this._drivingLicenceIssueDate = DateTime.MinValue;
      this._payGradeID = 0;
      this._annualSalary = new Decimal();
      this._nINumber = "";
      this._holidayYearStart = "01/01";
      this._holidayYearEnd = "31/12";
      this._daysHolidayAllowed = new Decimal();
      this._gasSafeNo = "";
      this._oftecNo = "";
      this._engineerGroupID = 0;
      this._supervisor = "";
      this._technician = "";
      this._Department = "";
      this._ServPri = 0;
      this._BreakPri = 0;
      this._DailyServiceLimit = 0;
      this._HomePostcode = "";
      this._Longitude = new Decimal();
      this._Latitude = new Decimal();
      this._ManagerUserID = 0;
      this._WebAppPassword = "";
      this._ragRating = 0;
      this._UserID = 0;
      this.RagDate = DateTime.MinValue;
      this._visitSpendLimit = new Decimal();
      this._engineerRoleId = new Decimal();
      this._emailAddress = string.Empty;
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

    public int EngineerID
    {
      get
      {
        return this._EngineerID;
      }
    }

    public object SetEngineerID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_EngineerID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int RegionID
    {
      get
      {
        return this._RegionID;
      }
    }

    public object SetRegionID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_RegionID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Name
    {
      get
      {
        return this._Name;
      }
    }

    public object SetName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Name", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string TelephoneNum
    {
      get
      {
        return this._TelephoneNum;
      }
    }

    public object SetTelephoneNum
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_TelephoneNum", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int PDAID
    {
      get
      {
        return this._PDAID;
      }
    }

    public object SetPDAID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_PDAID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public bool Apprentice
    {
      get
      {
        return this._Apprentice;
      }
    }

    public object SetApprentice
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Apprentice", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double CostToCompanyDouble
    {
      get
      {
        return this._costToCompanyDouble;
      }
    }

    public object SetCostToCompanyDouble
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_costToCompanyDouble", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double CostToCompanyTimeAndHalf
    {
      get
      {
        return this._costToCompanyTimeAndHalf;
      }
    }

    public object SetCostToCompanyTimeAndHalf
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_costToCompanyTimeAndHalf", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public double CostToCompanyNormal
    {
      get
      {
        return this._costToCompanyNormal;
      }
    }

    public object SetCostToCompanyNormal
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_costToCompanyNormal", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string NextOfKinName
    {
      get
      {
        return this._nextOfKinName;
      }
    }

    public object SetNextOfKinName
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_nextOfKinName", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string NextOfKinContact
    {
      get
      {
        return this._nextOfKinContact;
      }
    }

    public object SetNextOfKinContact
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_nextOfKinContact", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string StartingDetails
    {
      get
      {
        return this._startingDetails;
      }
    }

    public object SetStartingDetails
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_startingDetails", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string DrivingLicenceNo
    {
      get
      {
        return this._drivingLicenceNo;
      }
    }

    public object SetDrivingLicenceNo
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_drivingLicenceNo", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime DrivingLicenceIssueDate
    {
      get
      {
        return this._drivingLicenceIssueDate;
      }
      set
      {
        this._drivingLicenceIssueDate = value;
      }
    }

    public int PayGradeID
    {
      get
      {
        return this._payGradeID;
      }
    }

    public object SetPayGradeID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_payGradeID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal AnnualSalary
    {
      get
      {
        return this._annualSalary;
      }
    }

    public object SetAnnualSalary
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_annualSalary", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string NINumber
    {
      get
      {
        return this._nINumber;
      }
    }

    public object SetNINumber
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_nINumber", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string HolidayYearStart
    {
      get
      {
        return this._holidayYearStart;
      }
    }

    public object SetHolidayYearStart
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_holidayYearStart", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string HolidayYearEnd
    {
      get
      {
        return this._holidayYearEnd;
      }
    }

    public object SetHolidayYearEnd
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_holidayYearEnd", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal DaysHolidayAllowed
    {
      get
      {
        return this._daysHolidayAllowed;
      }
    }

    public object SetDaysHolidayAllowed
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_daysHolidayAllowed", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string GasSafeNo
    {
      get
      {
        return this._gasSafeNo;
      }
    }

    public object SetGasSafeNo
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_gasSafeNo", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string OftecNo
    {
      get
      {
        return this._oftecNo;
      }
    }

    public object SetOftecNo
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_oftecNo", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int EngineerGroupID
    {
      get
      {
        return this._engineerGroupID;
      }
    }

    public object SetEngineerGroupID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_engineerGroupID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Supervisor
    {
      get
      {
        return this._supervisor;
      }
    }

    public object SetSupervisor
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_supervisor", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Technician
    {
      get
      {
        return this._technician;
      }
    }

    public object SetTechnician
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_technician", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string Department
    {
      get
      {
        return this._Department;
      }
    }

    public object SetDepartment
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Department", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ServPri
    {
      get
      {
        return this._ServPri;
      }
    }

    public object SetServPri
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ServPri", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int BreakPri
    {
      get
      {
        return this._BreakPri;
      }
    }

    public object SetBreakPri
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_BreakPri", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int DailyServiceLimit
    {
      get
      {
        return this._DailyServiceLimit;
      }
    }

    public object SetDailyServiceLimit
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_DailyServiceLimit", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string HomePostcode
    {
      get
      {
        return this._HomePostcode;
      }
    }

    public object SetHomePostcode
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_HomePostcode", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal Longitude
    {
      get
      {
        return this._Longitude;
      }
    }

    public object SetLongitude
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Longitude", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public Decimal Latitude
    {
      get
      {
        return this._Latitude;
      }
    }

    public object SetLatitude
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_Latitude", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int ManagerUserID
    {
      get
      {
        return this._ManagerUserID;
      }
    }

    public object SetManagerUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ManagerUserID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string WebAppPassword
    {
      get
      {
        return this._WebAppPassword;
      }
    }

    public object SetWebAppPassword
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_WebAppPassword", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int RagRating
    {
      get
      {
        return this._ragRating;
      }
    }

    public object SetRagRating
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_ragRating", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int UserID
    {
      get
      {
        return this._UserID;
      }
    }

    public object SetUserID
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_UserID", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public DateTime RagDate { get; set; }

    public Decimal VisitSpendLimit
    {
      get
      {
        return this._visitSpendLimit;
      }
    }

    public object SetVisitSpendLimit
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_visitSpendLimit", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public int EngineerRoleId
    {
      get
      {
        return Convert.ToInt32(this._engineerRoleId);
      }
    }

    public object SetEngineerRoleId
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_engineerRoleId", RuntimeHelpers.GetObjectValue(value));
      }
    }

    public string EmailAddress
    {
      get
      {
        return this._emailAddress;
      }
    }

    public object SetEmailAddress
    {
      set
      {
        this._dataTypeValidator.SetValue((object) this, "_emailAddress", RuntimeHelpers.GetObjectValue(value));
      }
    }
  }
}
