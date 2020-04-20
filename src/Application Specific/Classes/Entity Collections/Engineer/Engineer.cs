using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Engineers
    {
        public class Engineer
        {
            private DataTypeValidator _dataTypeValidator;

            public Engineer()
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
            private int _EngineerID = 0;

            public int EngineerID
            {
                get
                {
                    return _EngineerID;
                }
            }

            public object SetEngineerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EngineerID", value);
                }
            }

            private int _RegionID = 0;

            public int RegionID
            {
                get
                {
                    return _RegionID;
                }
            }

            public object SetRegionID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_RegionID", value);
                }
            }

            private string _Name = string.Empty;

            public string Name
            {
                get
                {
                    return _Name;
                }
            }

            public object SetName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Name", value);
                }
            }

            private string _TelephoneNum = string.Empty;

            public string TelephoneNum
            {
                get
                {
                    return _TelephoneNum;
                }
            }

            public object SetTelephoneNum
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_TelephoneNum", value);
                }
            }

            private int _PDAID = 0;

            public int PDAID
            {
                get
                {
                    return _PDAID;
                }
            }

            public object SetPDAID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PDAID", value);
                }
            }

            private bool _Apprentice = false;

            public bool Apprentice
            {
                get
                {
                    return _Apprentice;
                }
            }

            public object SetApprentice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Apprentice", value);
                }
            }

            private double _costToCompanyDouble = 0;

            public double CostToCompanyDouble
            {
                get
                {
                    return _costToCompanyDouble;
                }
            }

            public object SetCostToCompanyDouble
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_costToCompanyDouble", value);
                }
            }

            private double _costToCompanyTimeAndHalf = 0;

            public double CostToCompanyTimeAndHalf
            {
                get
                {
                    return _costToCompanyTimeAndHalf;
                }
            }

            public object SetCostToCompanyTimeAndHalf
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_costToCompanyTimeAndHalf", value);
                }
            }

            private double _costToCompanyNormal = 0;

            public double CostToCompanyNormal
            {
                get
                {
                    return _costToCompanyNormal;
                }
            }

            public object SetCostToCompanyNormal
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_costToCompanyNormal", value);
                }
            }

            private string _nextOfKinName = "";

            public string NextOfKinName
            {
                get
                {
                    return _nextOfKinName;
                }
            }

            public object SetNextOfKinName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_nextOfKinName", value);
                }
            }

            private string _nextOfKinContact = "";

            public string NextOfKinContact
            {
                get
                {
                    return _nextOfKinContact;
                }
            }

            public object SetNextOfKinContact
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_nextOfKinContact", value);
                }
            }

            private string _startingDetails = "";

            public string StartingDetails
            {
                get
                {
                    return _startingDetails;
                }
            }

            public object SetStartingDetails
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_startingDetails", value);
                }
            }

            private string _drivingLicenceNo = "";

            public string DrivingLicenceNo
            {
                get
                {
                    return _drivingLicenceNo;
                }
            }

            public object SetDrivingLicenceNo
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_drivingLicenceNo", value);
                }
            }

            private DateTime _drivingLicenceIssueDate = default;

            public DateTime DrivingLicenceIssueDate
            {
                get
                {
                    return _drivingLicenceIssueDate;
                }

                set
                {
                    _drivingLicenceIssueDate = value;
                }
            }

            private int _payGradeID = 0;

            public int PayGradeID
            {
                get
                {
                    return _payGradeID;
                }
            }

            public object SetPayGradeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_payGradeID", value);
                }
            }

            private decimal _annualSalary = 0;

            public decimal AnnualSalary
            {
                get
                {
                    return _annualSalary;
                }
            }

            public object SetAnnualSalary
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_annualSalary", value);
                }
            }

            private string _nINumber = "";

            public string NINumber
            {
                get
                {
                    return _nINumber;
                }
            }

            public object SetNINumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_nINumber", value);
                }
            }

            private string _holidayYearStart = "01/01";

            public string HolidayYearStart
            {
                get
                {
                    return _holidayYearStart;
                }
            }

            public object SetHolidayYearStart
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_holidayYearStart", value);
                }
            }

            private string _holidayYearEnd = "31/12";

            public string HolidayYearEnd
            {
                get
                {
                    return _holidayYearEnd;
                }
            }

            public object SetHolidayYearEnd
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_holidayYearEnd", value);
                }
            }

            private decimal _daysHolidayAllowed = 0;

            public decimal DaysHolidayAllowed
            {
                get
                {
                    return _daysHolidayAllowed;
                }
            }

            public object SetDaysHolidayAllowed
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_daysHolidayAllowed", value);
                }
            }

            private string _gasSafeNo = "";

            public string GasSafeNo
            {
                get
                {
                    return _gasSafeNo;
                }
            }

            public object SetGasSafeNo
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_gasSafeNo", value);
                }
            }

            private string _oftecNo = "";

            public string OftecNo
            {
                get
                {
                    return _oftecNo;
                }
            }

            public object SetOftecNo
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_oftecNo", value);
                }
            }

            private int _engineerGroupID = 0;

            public int EngineerGroupID
            {
                get
                {
                    return _engineerGroupID;
                }
            }

            public object SetEngineerGroupID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_engineerGroupID", value);
                }
            }

            private string _supervisor = "";

            public string Supervisor
            {
                get
                {
                    return _supervisor;
                }
            }

            public object SetSupervisor
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_supervisor", value);
                }
            }

            private string _technician = "";

            public string Technician
            {
                get
                {
                    return _technician;
                }
            }

            public object SetTechnician
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_technician", value);
                }
            }

            private string _Department = "";

            public string Department
            {
                get
                {
                    return _Department;
                }
            }

            public object SetDepartment
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Department", value);
                }
            }

            private int _ServPri = 0;

            public int ServPri
            {
                get
                {
                    return _ServPri;
                }
            }

            public object SetServPri
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ServPri", value);
                }
            }

            private int _BreakPri = 0;

            public int BreakPri
            {
                get
                {
                    return _BreakPri;
                }
            }

            public object SetBreakPri
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_BreakPri", value);
                }
            }

            private int _DailyServiceLimit = 0;

            public int DailyServiceLimit
            {
                get
                {
                    return _DailyServiceLimit;
                }
            }

            public object SetDailyServiceLimit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_DailyServiceLimit", value);
                }
            }

            private string _HomePostcode = "";

            public string HomePostcode
            {
                get
                {
                    return _HomePostcode;
                }
            }

            public object SetHomePostcode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_HomePostcode", value);
                }
            }

            private decimal _Longitude = 0;

            public decimal Longitude
            {
                get
                {
                    return _Longitude;
                }
            }

            public object SetLongitude
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Longitude", value);
                }
            }

            private decimal _Latitude = 0;

            public decimal Latitude
            {
                get
                {
                    return _Latitude;
                }
            }

            public object SetLatitude
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Latitude", value);
                }
            }

            private int _ManagerUserID = Conversions.ToInteger(false);

            public int ManagerUserID
            {
                get
                {
                    return _ManagerUserID;
                }
            }

            public object SetManagerUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ManagerUserID", value);
                }
            }

            private string _WebAppPassword = "";

            public string WebAppPassword
            {
                get
                {
                    return _WebAppPassword;
                }
            }

            public object SetWebAppPassword
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_WebAppPassword", value);
                }
            }

            private int _ragRating = 0;

            public int RagRating
            {
                get
                {
                    return _ragRating;
                }
            }

            public object SetRagRating
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ragRating", value);
                }
            }

            private int _UserID = 0;

            public int UserID
            {
                get
                {
                    return _UserID;
                }
            }

            public object SetUserID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_UserID", value);
                }
            }

            public DateTime RagDate { get; set; } = default;

            private decimal _visitSpendLimit = default;

            public decimal VisitSpendLimit
            {
                get
                {
                    return _visitSpendLimit;
                }
            }

            public object SetVisitSpendLimit
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_visitSpendLimit", value);
                }
            }

            private decimal _engineerRoleId = default;

            public int EngineerRoleId
            {
                get
                {
                    return Conversions.ToInteger(_engineerRoleId);
                }
            }

            public object SetEngineerRoleId
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_engineerRoleId", value);
                }
            }

            private string _emailAddress = string.Empty;

            public string EmailAddress
            {
                get
                {
                    return _emailAddress;
                }
            }

            public object SetEmailAddress
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_emailAddress", value);
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}