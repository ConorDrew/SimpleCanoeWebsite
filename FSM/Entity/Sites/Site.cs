// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sites.Site
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Sites
{
    public class Site
    {
        private DataTypeValidator _dataTypeValidator;
        private bool _exists;
        private bool _deleted;
        private int _SiteID;
        private int _CustomerID;
        private int _RegionID;
        private bool _HeadOffice;
        private string _Notes;
        private string _Asbestos;
        private string _Name;
        private string _Address1;
        private string _Address2;
        private string _Address3;
        private string _Address4;
        private string _Address5;
        private string _Postcode;
        private string _TelephoneNum;
        private string _FaxNum;
        private string _EmailAddress;
        private int _EngineerID;
        private bool _PoNumReqd;
        private bool _AcceptChargesChanges;
        private int _SourceOfCustomerID;
        private string _PolicyNumber;
        private string _directDebitRef;
        private bool _NoMarketing;
        private int _ReasonForContactID;
        private bool _OnStop;
        private bool _SolidFuel;
        private bool _NoService;
        private bool _LeaseHold;
        private bool _CommercialDistrict;
        private bool _PropertyVoid;
        private DateTime _LastServiceDate;
        private DateTime _ActualServiceDate;
        private string _SiteFuel;
        private string _Salutation;
        private string _FirstName;
        private string _Surname;
        private string _ContactAlerts;
        private Decimal _Longitude;
        private Decimal _Latitude;
        private DateTime _buildDate;
        private int _warrantyPeriodInMonths;
        private string _HousingOfficer;
        private string _HousingManager;
        private string _EstateOfficer;
        private DateTime _PropertyVoidDate;
        private string _defects;
        private DateTime _DefectEndDate;
        private int _accomTypeID;

        public Site()
        {
            this._exists = false;
            this._deleted = false;
            this._SiteID = 0;
            this._CustomerID = 0;
            this._RegionID = 0;
            this._HeadOffice = false;
            this._Notes = string.Empty;
            this._Asbestos = string.Empty;
            this._Name = string.Empty;
            this._Address1 = string.Empty;
            this._Address2 = string.Empty;
            this._Address3 = string.Empty;
            this._Address4 = string.Empty;
            this._Address5 = string.Empty;
            this._Postcode = string.Empty;
            this._TelephoneNum = string.Empty;
            this._FaxNum = string.Empty;
            this._EmailAddress = string.Empty;
            this._EngineerID = 0;
            this._PoNumReqd = false;
            this._AcceptChargesChanges = true;
            this._SourceOfCustomerID = 0;
            this._PolicyNumber = string.Empty;
            this._directDebitRef = string.Empty;
            this._NoMarketing = true;
            this._ReasonForContactID = 0;
            this._OnStop = true;
            this._SolidFuel = false;
            this._NoService = false;
            this._LeaseHold = false;
            this._CommercialDistrict = false;
            this._PropertyVoid = false;
            this._LastServiceDate = DateTime.MinValue;
            this._ActualServiceDate = DateTime.MinValue;
            this._SiteFuel = string.Empty;
            this._Salutation = string.Empty;
            this._FirstName = string.Empty;
            this._Surname = string.Empty;
            this._ContactAlerts = string.Empty;
            this._Longitude = new Decimal();
            this._Latitude = new Decimal();
            this._buildDate = DateTime.MinValue;
            this._warrantyPeriodInMonths = 0;
            this._HousingOfficer = string.Empty;
            this._HousingManager = string.Empty;
            this._EstateOfficer = string.Empty;
            this._PropertyVoidDate = DateTime.MinValue;
            this._defects = string.Empty;
            this._DefectEndDate = DateTime.MinValue;
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
                this._dataTypeValidator.SetValue((object)this, "_SiteID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int CustomerID
        {
            get
            {
                return this._CustomerID;
            }
        }

        public object SetCustomerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CustomerID", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_RegionID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool HeadOffice
        {
            get
            {
                return this._HeadOffice;
            }
        }

        public object SetHeadOffice
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_HeadOffice", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Notes
        {
            get
            {
                return this._Notes;
            }
        }

        public object SetNotes
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Notes", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Asbestos
        {
            get
            {
                return this._Asbestos;
            }
        }

        public object SetAsbestos
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Asbestos", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_Name", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address1
        {
            get
            {
                return this._Address1;
            }
        }

        public object SetAddress1
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address1", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address2
        {
            get
            {
                return this._Address2;
            }
        }

        public object SetAddress2
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address2", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address3
        {
            get
            {
                return this._Address3;
            }
        }

        public object SetAddress3
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address3", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address4
        {
            get
            {
                return this._Address4;
            }
        }

        public object SetAddress4
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address4", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Address5
        {
            get
            {
                return this._Address5;
            }
        }

        public object SetAddress5
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Address5", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Postcode
        {
            get
            {
                return this._Postcode;
            }
        }

        public object SetPostcode
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Postcode", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_TelephoneNum", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string FaxNum
        {
            get
            {
                return this._FaxNum;
            }
        }

        public object SetFaxNum
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FaxNum", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string EmailAddress
        {
            get
            {
                return this._EmailAddress;
            }
        }

        public object SetEmailAddress
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EmailAddress", RuntimeHelpers.GetObjectValue(value));
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
                this._dataTypeValidator.SetValue((object)this, "_EngineerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool PoNumReqd
        {
            get
            {
                return this._PoNumReqd;
            }
        }

        public object SetPoNumReqd
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PoNumReqd", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool AcceptChargesChanges
        {
            get
            {
                return this._AcceptChargesChanges;
            }
        }

        public object SetAcceptChargesChanges
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_AcceptChargesChanges", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int SourceOfCustomerID
        {
            get
            {
                return this._SourceOfCustomerID;
            }
        }

        public object SetSourceOfCustomerID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SourceOfCustomerID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string PolicyNumber
        {
            get
            {
                return this._PolicyNumber;
            }
        }

        public object SetPolicyNumber
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PolicyNumber", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string DirectDebitRef
        {
            get
            {
                return this._directDebitRef;
            }
        }

        public object SetDirectDebitRef
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_directDebitRef", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool NoMarketing
        {
            get
            {
                return this._NoMarketing;
            }
        }

        public object SetNoMarketing
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_NoMarketing", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public int ReasonForContactID
        {
            get
            {
                return this._ReasonForContactID;
            }
        }

        public object SetReasonForContactID
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ReasonForContactID", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool OnStop
        {
            get
            {
                return this._OnStop;
            }
        }

        public object SetOnStop
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_OnStop", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool SolidFuel
        {
            get
            {
                return this._SolidFuel;
            }
        }

        public object SetSolidFuel
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SolidFuel", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool NoService
        {
            get
            {
                return this._NoService;
            }
        }

        public object SetNoService
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_NoService", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool LeaseHold
        {
            get
            {
                return this._LeaseHold;
            }
        }

        public object SetLeaseHold
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_LeaseHold", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool CommercialDistrict
        {
            get
            {
                return this._CommercialDistrict;
            }
        }

        public object SetCommercialDistrict
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_CommercialDistrict", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public bool PropertyVoid
        {
            get
            {
                return this._PropertyVoid;
            }
        }

        public object SetPropertyVoid
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_PropertyVoid", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime LastServiceDate
        {
            get
            {
                return this._LastServiceDate;
            }
            set
            {
                this._LastServiceDate = value;
            }
        }

        public DateTime ActualServiceDate
        {
            get
            {
                return this._ActualServiceDate;
            }
            set
            {
                this._ActualServiceDate = value;
            }
        }

        public string SiteFuel
        {
            get
            {
                return this._SiteFuel;
            }
        }

        public object SetSiteFuel
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_SiteFuel", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Salutation
        {
            get
            {
                return this._Salutation;
            }
        }

        public object SetSalutation
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Salutation", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
        }

        public object SetFirstName
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_FirstName", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string Surname
        {
            get
            {
                return this._Surname;
            }
        }

        public object SetSurname
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Surname", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string ContactAlerts
        {
            get
            {
                return this._ContactAlerts;
            }
        }

        public object SetContactAlerts
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_ContactAlerts", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public Decimal Longitude
        {
            get
            {
                return this._Longitude;
            }
        }

        public Decimal SetLongitude
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Longitude", (object)value);
            }
        }

        public Decimal Latitude
        {
            get
            {
                return this._Latitude;
            }
        }

        public Decimal SetLatitude
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_Latitude", (object)value);
            }
        }

        public DateTime BuildDate
        {
            get
            {
                return this._buildDate;
            }
            set
            {
                this._buildDate = value;
            }
        }

        public int WarrantyPeriodInMonths
        {
            get
            {
                return this._warrantyPeriodInMonths;
            }
        }

        public object SetWarrantyPeriodInMonths
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_warrantyPeriodInMonths", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string HousingOfficer
        {
            get
            {
                return this._HousingOfficer;
            }
        }

        public object SetHousingOfficer
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_HousingOfficer", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string HousingManager
        {
            get
            {
                return this._HousingManager;
            }
        }

        public object SetHousingManager
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_HousingManager", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public string EstateOfficer
        {
            get
            {
                return this._EstateOfficer;
            }
        }

        public object SetEstateOfficer
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_EstateOfficer", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime PropertyVoidDate
        {
            get
            {
                return this._PropertyVoidDate;
            }
            set
            {
                this._PropertyVoidDate = value;
            }
        }

        public string Defects
        {
            get
            {
                return this._defects;
            }
        }

        public object SetDefects
        {
            set
            {
                this._dataTypeValidator.SetValue((object)this, "_defects", RuntimeHelpers.GetObjectValue(value));
            }
        }

        public DateTime DefectEndDate
        {
            get
            {
                return this._DefectEndDate;
            }
            set
            {
                this._DefectEndDate = value;
            }
        }

        public int AccomTypeID
        {
            get
            {
                return this._accomTypeID;
            }
        }

        public int SetAccomTypeID
        {
            set
            {
                this._accomTypeID = value;
            }
        }
    }
}