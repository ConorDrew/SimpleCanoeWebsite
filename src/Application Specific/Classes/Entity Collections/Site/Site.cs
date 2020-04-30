using System;
using System.Collections;

namespace FSM.Entity
{
    namespace Sites
    {
        public class Site
        {
            private DataTypeValidator _dataTypeValidator;

            public Site()
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

            private int _CustomerID = 0;

            public int CustomerID
            {
                get
                {
                    return _CustomerID;
                }
            }

            public object SetCustomerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CustomerID", value);
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

            private bool _HeadOffice = false;

            public bool HeadOffice
            {
                get
                {
                    return _HeadOffice;
                }
            }

            public object SetHeadOffice
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_HeadOffice", value);
                }
            }

            private string _Notes = string.Empty;

            public string Notes
            {
                get
                {
                    return _Notes;
                }
            }

            public object SetNotes
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Notes", value);
                }
            }

            private string _Asbestos = string.Empty;

            public string Asbestos
            {
                get
                {
                    return _Asbestos;
                }
            }

            public object SetAsbestos
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Asbestos", value);
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

            private string _Address1 = string.Empty;

            public string Address1
            {
                get
                {
                    return _Address1;
                }
            }

            public object SetAddress1
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address1", value);
                }
            }

            private string _Address2 = string.Empty;

            public string Address2
            {
                get
                {
                    return _Address2;
                }
            }

            public object SetAddress2
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address2", value);
                }
            }

            private string _Address3 = string.Empty;

            public string Address3
            {
                get
                {
                    return _Address3;
                }
            }

            public object SetAddress3
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address3", value);
                }
            }

            private string _Address4 = string.Empty;

            public string Address4
            {
                get
                {
                    return _Address4;
                }
            }

            public object SetAddress4
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address4", value);
                }
            }

            private string _Address5 = string.Empty;

            public string Address5
            {
                get
                {
                    return _Address5;
                }
            }

            public object SetAddress5
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Address5", value);
                }
            }

            private string _Postcode = string.Empty;

            public string Postcode
            {
                get
                {
                    return _Postcode;
                }
            }

            public object SetPostcode
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Postcode", value);
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

            private string _FaxNum = string.Empty;

            public string FaxNum
            {
                get
                {
                    return _FaxNum;
                }
            }

            public object SetFaxNum
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FaxNum", value);
                }
            }

            private string _EmailAddress = string.Empty;

            public string EmailAddress
            {
                get
                {
                    return _EmailAddress;
                }
            }

            public object SetEmailAddress
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EmailAddress", value);
                }
            }

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

            private bool _PoNumReqd = false;

            public bool PoNumReqd
            {
                get
                {
                    return _PoNumReqd;
                }
            }

            public object SetPoNumReqd
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PoNumReqd", value);
                }
            }

            private bool _AcceptChargesChanges = true;

            public bool AcceptChargesChanges
            {
                get
                {
                    return _AcceptChargesChanges;
                }
            }

            public object SetAcceptChargesChanges
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AcceptChargesChanges", value);
                }
            }

            private int _SourceOfCustomerID = 0;

            public int SourceOfCustomerID
            {
                get
                {
                    return _SourceOfCustomerID;
                }
            }

            public object SetSourceOfCustomerID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SourceOfCustomerID", value);
                }
            }

            private string _PolicyNumber = string.Empty;

            public string PolicyNumber
            {
                get
                {
                    return _PolicyNumber;
                }
            }

            public object SetPolicyNumber
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PolicyNumber", value);
                }
            }

            private string _directDebitRef = string.Empty;

            public string DirectDebitRef
            {
                get
                {
                    return _directDebitRef;
                }
            }

            public object SetDirectDebitRef
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_directDebitRef", value);
                }
            }

            private bool _NoMarketing = true;

            public bool NoMarketing
            {
                get
                {
                    return _NoMarketing;
                }
            }

            public object SetNoMarketing
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NoMarketing", value);
                }
            }

            private int _ReasonForContactID = 0;

            public int ReasonForContactID
            {
                get
                {
                    return _ReasonForContactID;
                }
            }

            public object SetReasonForContactID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ReasonForContactID", value);
                }
            }

            private bool _OnStop = true;

            public bool OnStop
            {
                get
                {
                    return _OnStop;
                }
            }

            public object SetOnStop
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_OnStop", value);
                }
            }

            private bool _SolidFuel = false;

            public bool SolidFuel
            {
                get
                {
                    return _SolidFuel;
                }
            }

            public object SetSolidFuel
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SolidFuel", value);
                }
            }

            private bool _NoService = false;

            public bool NoService
            {
                get
                {
                    return _NoService;
                }
            }

            public object SetNoService
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_NoService", value);
                }
            }

            private bool _LeaseHold = false;

            public bool LeaseHold
            {
                get
                {
                    return _LeaseHold;
                }
            }

            public object SetLeaseHold
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_LeaseHold", value);
                }
            }

            private bool _CommercialDistrict = false;

            public bool CommercialDistrict
            {
                get
                {
                    return _CommercialDistrict;
                }
            }

            public object SetCommercialDistrict
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_CommercialDistrict", value);
                }
            }

            private bool _PropertyVoid = false;

            public bool PropertyVoid
            {
                get
                {
                    return _PropertyVoid;
                }
            }

            public object SetPropertyVoid
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_PropertyVoid", value);
                }
            }

            private DateTime _LastServiceDate = default;

            public DateTime LastServiceDate
            {
                get
                {
                    return _LastServiceDate;
                }

                set
                {
                    _LastServiceDate = value;
                }
            }

            private DateTime _ActualServiceDate = default;

            public DateTime ActualServiceDate
            {
                get
                {
                    return _ActualServiceDate;
                }

                set
                {
                    _ActualServiceDate = value;
                }
            }

            private string _SiteFuel = string.Empty;

            public string SiteFuel
            {
                get
                {
                    return _SiteFuel;
                }
            }

            public object SetSiteFuel
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteFuel", value);
                }
            }

            private string _Salutation = string.Empty;

            public string Salutation
            {
                get
                {
                    return _Salutation;
                }
            }

            public object SetSalutation
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Salutation", value);
                }
            }

            private string _FirstName = string.Empty;

            public string FirstName
            {
                get
                {
                    return _FirstName;
                }
            }

            public object SetFirstName
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FirstName", value);
                }
            }

            private string _Surname = string.Empty;

            public string Surname
            {
                get
                {
                    return _Surname;
                }
            }

            public object SetSurname
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Surname", value);
                }
            }

            private string _ContactAlerts = string.Empty;

            public string ContactAlerts
            {
                get
                {
                    return _ContactAlerts;
                }
            }

            public object SetContactAlerts
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_ContactAlerts", value);
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

            public decimal SetLongitude
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

            public decimal SetLatitude
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_Latitude", value);
                }
            }

            private DateTime _buildDate = default;

            public DateTime BuildDate
            {
                get
                {
                    return _buildDate;
                }

                set
                {
                    _buildDate = value;
                }
            }

            private int _warrantyPeriodInMonths = 0;

            public int WarrantyPeriodInMonths
            {
                get
                {
                    return _warrantyPeriodInMonths;
                }
            }

            public object SetWarrantyPeriodInMonths
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_warrantyPeriodInMonths", value);
                }
            }

            private string _HousingOfficer = string.Empty;

            public string HousingOfficer
            {
                get
                {
                    return _HousingOfficer;
                }
            }

            public object SetHousingOfficer
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_HousingOfficer", value);
                }
            }

            private string _HousingManager = string.Empty;

            public string HousingManager
            {
                get
                {
                    return _HousingManager;
                }
            }

            public object SetHousingManager
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_HousingManager", value);
                }
            }

            private string _EstateOfficer = string.Empty;

            public string EstateOfficer
            {
                get
                {
                    return _EstateOfficer;
                }
            }

            public object SetEstateOfficer
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_EstateOfficer", value);
                }
            }

            private DateTime _PropertyVoidDate = default;

            public DateTime PropertyVoidDate
            {
                get
                {
                    return _PropertyVoidDate;
                }

                set
                {
                    _PropertyVoidDate = value;
                }
            }

            private string _defects = string.Empty;

            public string Defects
            {
                get
                {
                    return _defects;
                }
            }

            public object SetDefects
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_defects", value);
                }
            }

            private DateTime _DefectEndDate = default;

            public DateTime DefectEndDate
            {
                get
                {
                    return _DefectEndDate;
                }

                set
                {
                    _DefectEndDate = value;
                }
            }

            private int _accomTypeID;

            public int AccomTypeID
            {
                get
                {
                    return _accomTypeID;
                }
            }

            public int SetAccomTypeID
            {
                set
                {
                    _accomTypeID = value;
                }
            }

            
        }

        public class SiteFuel
        {
            private DataTypeValidator _dataTypeValidator;

            public SiteFuel()
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

            
            
            private int _SiteFuelID = 0;

            public int SiteFuelID
            {
                get
                {
                    return _SiteFuelID;
                }
            }

            public object SetSiteFuelID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteFuelID", value);
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

            private int _FuelID = 0;

            public int FuelID
            {
                get
                {
                    return _FuelID;
                }
            }

            public object SetFuelID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_FuelID", value);
                }
            }

            private int _SiteFuelChargeID = 0;

            public int SiteFuelChargeID
            {
                get
                {
                    return _SiteFuelChargeID;
                }
            }

            public object SetSiteFuelChargeID
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_SiteFuelChargeID", value);
                }
            }

            private DateTime _LastServiceDate = default;

            public DateTime LastServiceDate
            {
                get
                {
                    return _LastServiceDate;
                }

                set
                {
                    _LastServiceDate = value;
                }
            }

            private DateTime _ActualServiceDate = default;

            public DateTime ActualServiceDate
            {
                get
                {
                    return _ActualServiceDate;
                }

                set
                {
                    _ActualServiceDate = value;
                }
            }

            private DateTime _DateAdded = default;

            public DateTime DateAdded
            {
                get
                {
                    return _DateAdded;
                }

                set
                {
                    _DateAdded = value;
                }
            }

            private int _AddedBy = 0;

            public int AddedBy
            {
                get
                {
                    return _AddedBy;
                }
            }

            public object SetAddedBy
            {
                set
                {
                    _dataTypeValidator.SetValue(this, "_AddedBy", value);
                }
            }

            
        }
    }
}