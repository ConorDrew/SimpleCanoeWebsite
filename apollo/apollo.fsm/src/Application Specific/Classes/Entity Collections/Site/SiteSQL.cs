using System;
using System.Data;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.Sites
{
    public class SiteSQL
    {
        public enum GetBy
        {
            SiteId = 1,
            Uprn = 2,
            Asset = 3,
            EngineerVisitId = 4,
            CustomerHq = 5,
            JobId = 6
        }

        private Database _database;

        public SiteSQL(Database database)
        {
            _database = database;
        }

        public void Delete(int SiteID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            _database.ExecuteSP_NO_Return("Site_Delete");
        }

        public Site Get(object @ref, GetBy getBy = GetBy.SiteId, object ref2 = null)
        {
            _database.ClearParameter();

            // Get the datatable from the database store in dt
            DataTable dt = null;
            switch (getBy)
            {
                case GetBy.Uprn:
                    {
                        _database.AddParameter("@UPRN", Helper.MakeStringValid(@ref), true);
                        _database.AddParameter("@CustomerId", Helper.MakeIntegerValid(ref2), true);
                        dt = _database.ExecuteSP_DataTable("Site_Get_ForUPRN");
                        break;
                    }

                case GetBy.Asset:
                    {
                        _database.AddParameter("@AssetID", Helper.MakeIntegerValid(@ref), true);
                        dt = _database.ExecuteSP_DataTable("Site_Get_ForAssetID");
                        break;
                    }

                case GetBy.EngineerVisitId:
                    {
                        _database.AddParameter("@EngineerVisitID", Helper.MakeIntegerValid(@ref), true);
                        dt = _database.ExecuteSP_DataTable("Site_Get_ForEngineerVisitID");
                        break;
                    }

                case GetBy.CustomerHq:
                    {
                        _database.AddParameter("@CustomerID", Helper.MakeIntegerValid(@ref), true);
                        dt = _database.ExecuteSP_DataTable("[Sites_GetHOForCustomer]");
                        break;
                    }

                case GetBy.JobId:
                    {
                        _database.AddParameter("@JobID ", Helper.MakeIntegerValid(@ref));
                        dt = _database.ExecuteSP_DataTable("Site_Get_ForJobID");
                        break;
                    }

                case GetBy.SiteId:
                    {
                        _database.AddParameter("@SiteID", Helper.MakeIntegerValid(@ref));
                        dt = _database.ExecuteSP_DataTable("Site_Get");
                        break;
                    }

                default:
                    {
                        _database.AddParameter("@SiteID", Helper.MakeIntegerValid(@ref));
                        dt = _database.ExecuteSP_DataTable("Site_Get");
                        break;
                    }
            }

            if (dt is object)
            {
                if (dt.Rows.Count > 0)
                {
                    var oSite = new Site();
                    oSite.IgnoreExceptionsOnSetMethods = true;
                    if (dt.Columns.Contains("SiteID"))
                        oSite.SetSiteID = Helper.MakeIntegerValid(dt.Rows[0]["SiteID"]);
                    if (dt.Columns.Contains("Name"))
                        oSite.SetName = Helper.MakeStringValid(dt.Rows[0]["Name"]);
                    if (dt.Columns.Contains("CustomerID"))
                        oSite.SetCustomerID = Helper.MakeIntegerValid(dt.Rows[0]["CustomerID"]);
                    if (dt.Columns.Contains("RegionID"))
                        oSite.SetRegionID = Helper.MakeIntegerValid(dt.Rows[0]["RegionID"]);
                    if (dt.Columns.Contains("HeadOffice"))
                        oSite.SetHeadOffice = Helper.MakeBooleanValid(dt.Rows[0]["HeadOffice"]);
                    if (dt.Columns.Contains("Notes"))
                        oSite.SetNotes = Helper.MakeStringValid(dt.Rows[0]["Notes"]);
                    if (dt.Columns.Contains("Address1"))
                        oSite.SetAddress1 = Helper.MakeStringValid(dt.Rows[0]["Address1"]);
                    if (dt.Columns.Contains("Address2"))
                        oSite.SetAddress2 = Helper.MakeStringValid(dt.Rows[0]["Address2"]);
                    if (dt.Columns.Contains("Address3"))
                        oSite.SetAddress3 = Helper.MakeStringValid(dt.Rows[0]["Address3"]);
                    if (dt.Columns.Contains("Address4"))
                        oSite.SetAddress4 = Helper.MakeStringValid(dt.Rows[0]["Address4"]);
                    if (dt.Columns.Contains("Address5"))
                        oSite.SetAddress5 = Helper.MakeStringValid(dt.Rows[0]["Address5"]);
                    if (dt.Columns.Contains("Postcode"))
                        oSite.SetPostcode = Helper.MakeStringValid(dt.Rows[0]["Postcode"]);
                    if (dt.Columns.Contains("TelephoneNum"))
                        oSite.SetTelephoneNum = Helper.MakeStringValid(dt.Rows[0]["TelephoneNum"]);
                    if (dt.Columns.Contains("FaxNum"))
                        oSite.SetFaxNum = Helper.MakeStringValid(dt.Rows[0]["FaxNum"]);
                    if (dt.Columns.Contains("EmailAddress"))
                        oSite.SetEmailAddress = Helper.MakeStringValid(dt.Rows[0]["EmailAddress"]);
                    if (dt.Columns.Contains("EngineerID"))
                        oSite.SetEngineerID = Helper.MakeIntegerValid(dt.Rows[0]["EngineerID"]);
                    if (dt.Columns.Contains("PoNumReqd"))
                        oSite.SetPoNumReqd = Helper.MakeBooleanValid(dt.Rows[0]["PoNumReqd"]);
                    if (dt.Columns.Contains("Deleted"))
                        oSite.SetDeleted = Helper.MakeBooleanValid(dt.Rows[0]["Deleted"]);
                    if (dt.Columns.Contains("PolicyNumber"))
                        oSite.SetPolicyNumber = Helper.MakeStringValid(dt.Rows[0]["PolicyNumber"]);
                    if (dt.Columns.Contains("AcceptChargesChanges"))
                        oSite.SetAcceptChargesChanges = Helper.MakeBooleanValid(dt.Rows[0]["AcceptChargesChanges"]);
                    if (dt.Columns.Contains("SourceOfCustomerID"))
                        oSite.SetSourceOfCustomerID = Helper.MakeIntegerValid(dt.Rows[0]["SourceOfCustomerID"]);
                    if (dt.Columns.Contains("NoMarketing"))
                        oSite.SetNoMarketing = Helper.MakeBooleanValid(dt.Rows[0]["NoMarketing"]);
                    if (dt.Columns.Contains("ReasonForContactID"))
                        oSite.SetReasonForContactID = Helper.MakeIntegerValid(dt.Rows[0]["ReasonForContactID"]);
                    if (dt.Columns.Contains("OnStop"))
                        oSite.SetOnStop = Helper.MakeBooleanValid(dt.Rows[0]["OnStop"]);
                    if (dt.Columns.Contains("SolidFuel"))
                        oSite.SetSolidFuel = Helper.MakeBooleanValid(dt.Rows[0]["SolidFuel"]);
                    if (dt.Columns.Contains("NoService"))
                        oSite.SetNoService = Helper.MakeBooleanValid(dt.Rows[0]["NoService"]);
                    if (dt.Columns.Contains("LeaseHold"))
                        oSite.SetLeaseHold = Helper.MakeBooleanValid(dt.Rows[0]["LeaseHold"]);
                    if (dt.Columns.Contains("CommercialDistrict"))
                        oSite.SetCommercialDistrict = Helper.MakeBooleanValid(dt.Rows[0]["CommercialDistrict"]);
                    if (dt.Columns.Contains("LastServiceDate"))
                        oSite.LastServiceDate = Helper.MakeDateTimeValid(dt.Rows[0]["LastServiceDate"]);
                    if (dt.Columns.Contains("ActualServiceDate"))
                        oSite.ActualServiceDate = Helper.MakeDateTimeValid(dt.Rows[0]["ActualServiceDate"]);
                    if (dt.Columns.Contains("PropertyVoid"))
                        oSite.SetPropertyVoid = Helper.MakeBooleanValid(dt.Rows[0]["PropertyVoid"]);
                    if (dt.Columns.Contains("SiteFuel"))
                        oSite.SetSiteFuel = Helper.MakeStringValid(dt.Rows[0]["SiteFuel"]);
                    if (dt.Columns.Contains("Salutation"))
                        oSite.SetSalutation = Helper.MakeStringValid(dt.Rows[0]["Salutation"]);
                    if (dt.Columns.Contains("FirstName"))
                        oSite.SetFirstName = Helper.MakeStringValid(dt.Rows[0]["FirstName"]);
                    if (dt.Columns.Contains("Surname"))
                        oSite.SetSurname = Helper.MakeStringValid(dt.Rows[0]["Surname"]);
                    if (dt.Columns.Contains("asbestos"))
                        oSite.SetAsbestos = Helper.MakeStringValid(dt.Rows[0]["asbestos"].ToString().Replace("/n", Constants.vbNewLine));
                    if (dt.Columns.Contains("ContactAlerts"))
                        oSite.SetContactAlerts = Helper.MakeStringValid(dt.Rows[0]["ContactAlerts"]);
                    if (dt.Columns.Contains("Longitude"))
                        oSite.SetLongitude = Conversions.ToDecimal(Helper.MakeDoubleValid(dt.Rows[0]["Longitude"]));
                    if (dt.Columns.Contains("Latitude"))
                        oSite.SetLatitude = Conversions.ToDecimal(Helper.MakeDoubleValid(dt.Rows[0]["Latitude"]));
                    if (dt.Columns.Contains("DirectDebitRef"))
                        oSite.SetDirectDebitRef = Helper.MakeStringValid(dt.Rows[0]["DirectDebitRef"]);
                    if (dt.Columns.Contains("BuildDate"))
                        oSite.BuildDate = Helper.MakeDateTimeValid(dt.Rows[0]["BuildDate"]);
                    if (dt.Columns.Contains("HousingOfficer"))
                        oSite.SetHousingOfficer = Helper.MakeStringValid(dt.Rows[0]["HousingOfficer"]);
                    if (dt.Columns.Contains("EstateOfficer"))
                        oSite.SetEstateOfficer = Helper.MakeStringValid(dt.Rows[0]["EstateOfficer"]);
                    if (dt.Columns.Contains("HousingManager"))
                        oSite.SetHousingManager = Helper.MakeStringValid(dt.Rows[0]["HousingManager"]);
                    if (dt.Columns.Contains("WarrantyPeriodInMonths"))
                        oSite.SetWarrantyPeriodInMonths = Helper.MakeIntegerValid(dt.Rows[0]["WarrantyPeriodInMonths"]);
                    if (dt.Columns.Contains("PropertyVoidDate"))
                        oSite.PropertyVoidDate = Helper.MakeDateTimeValid(dt.Rows[0]["PropertyVoidDate"]);
                    if (dt.Columns.Contains("Defects"))
                        oSite.SetDefects = Helper.MakeStringValid(dt.Rows[0]["Defects"]);
                    if (dt.Columns.Contains("DefectEndDate"))
                        oSite.DefectEndDate = Helper.MakeDateTimeValid(dt.Rows[0]["DefectEndDate"]);
                    if (dt.Columns.Contains("AccomTypeID"))
                        oSite.SetAccomTypeID = Helper.MakeIntegerValid(dt.Rows[0]["AccomTypeID"]);
                    oSite.Exists = true;
                    return oSite;
                }
                else
                {
                    return null;
                }
            }

            return default;
        }

        public DataView GetAll_FleetGarage(int userId)
        {
            _database.ClearParameter();
            _database.AddParameter("@UserID", userId, true);
            var dt = _database.ExecuteSP_DataTable("Site_GetAll_FleetGarage_Mk1");
            dt.TableName = Enums.TableNames.tblSite.ToString();
            return new DataView(dt);
        }

        public DataView GetAll_Light_New(int userId)
        {
            _database.ClearParameter();
            _database.AddParameter("@UserID", userId, true);
            var dt = _database.ExecuteSP_DataTable("Site_GetAll_Light_New_Mk1");
            dt.TableName = Enums.TableNames.tblSite.ToString();
            return new DataView(dt);
        }

        public DataView GetForCustomer_Light(int CustomerID, int userId)
        {
            _database.ClearParameter();
            _database.AddParameter("@CustomerID", CustomerID, true);
            _database.AddParameter("@UserID", userId, true);
            var dt = _database.ExecuteSP_DataTable("[Sites_GetForCustomer_Light_Mk1]");
            dt.TableName = Enums.TableNames.tblSite.ToString();
            return new DataView(dt);
        }

        public DataView Search(string Criteria, int userId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SearchString", Criteria, true);
            _database.AddParameter("@UserID", userId, true);
            var dt = _database.ExecuteSP_DataTable("Site_SearchList_Mk1");
            dt.TableName = Enums.TableNames.tblSite.ToString();
            return new DataView(dt);
        }

        public DataView Search_JobWizard(string Criteria, int userId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SearchString", Criteria, true);
            _database.AddParameter("@UserID", userId, true);
            var dt = _database.ExecuteSP_DataTable("Site_Search_JobWizard");
            dt.TableName = Enums.TableNames.tblSite.ToString();
            return new DataView(dt);
        }

        public DataView Search_FleetGarage(string Criteria, int userId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SearchString", Criteria, true);
            _database.AddParameter("@UserID", userId, true);
            var dt = _database.ExecuteSP_DataTable("Site_SearchList_FleetGarage_Mk1");
            dt.TableName = Enums.TableNames.tblFleetGarage.ToString();
            return new DataView(dt);
        }

        public Site Insert(Site oSite)
        {
            _database.ClearParameter();
            AddPropertyParametersToCommand(ref oSite);
            _database.AddParameter("@SiteAddedByUserID", App.loggedInUser.UserID, true);
            oSite.SetSiteID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Site_Insert"));
            oSite.Exists = true;
            Check_And_Insert_Postal_Region(oSite.Postcode);
            return oSite;
        }

        public void Update(Site oSite)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", oSite.SiteID, true);
            AddPropertyParametersToCommand(ref oSite);
            _database.ExecuteSP_NO_Return("Site_Update");
            Check_And_Insert_Postal_Region(oSite.Postcode);
        }

        public void Update_Customer(int siteId, int oldCustomerId, int customerId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", siteId, true);
            _database.AddParameter("@CustomerID", customerId, true);
            _database.ExecuteSP_NO_Return("Site_Update_Customer");

            // INSERT AUDIT RECORD
            var scAudit = new SiteCustomerAudits.SiteCustomerAudit();
            scAudit.DateChanged = DateAndTime.Now;
            scAudit.SetSiteID = siteId;
            scAudit.SetPreviousCustomerID = oldCustomerId;
            scAudit.SetUserID = App.loggedInUser.UserID;
            App.DB.SiteCustomerAudit.Insert(scAudit);
        }

        private void AddPropertyParametersToCommand(ref Site oSite)
        {
            {
                var withBlock = _database;
                withBlock.AddParameter("@CustomerID", oSite.CustomerID, true);
                withBlock.AddParameter("@Name", oSite.Name, true);
                withBlock.AddParameter("@RegionID", oSite.RegionID, true);
                withBlock.AddParameter("@HeadOffice", oSite.HeadOffice, true);
                withBlock.AddParameter("@Notes", oSite.Notes, true);
                withBlock.AddParameter("@Address1", oSite.Address1, true);
                withBlock.AddParameter("@Address2", oSite.Address2, true);
                withBlock.AddParameter("@Address3", oSite.Address3, true);
                withBlock.AddParameter("@Address4", oSite.Address4, true);
                withBlock.AddParameter("@Address5", oSite.Address5, true);
                withBlock.AddParameter("@Postcode", oSite.Postcode, true);
                withBlock.AddParameter("@TelephoneNum", oSite.TelephoneNum, true);
                withBlock.AddParameter("@FaxNum", oSite.FaxNum, true);
                withBlock.AddParameter("@EmailAddress", oSite.EmailAddress, true);
                withBlock.AddParameter("@EngineerID", oSite.EngineerID, true);
                withBlock.AddParameter("@PONumReqd", oSite.PoNumReqd, true);
                withBlock.AddParameter("@PolicyNumber", oSite.PolicyNumber, true);
                withBlock.AddParameter("@AcceptChargesChanges", oSite.AcceptChargesChanges, true);
                withBlock.AddParameter("@SourceOfCustomerID", oSite.SourceOfCustomerID, true);
                withBlock.AddParameter("@NoMarketing", oSite.NoMarketing, true);
                withBlock.AddParameter("@NoService", oSite.NoService, true);
                withBlock.AddParameter("@ReasonForContactID", oSite.ReasonForContactID, true);
                withBlock.AddParameter("@OnStop", oSite.OnStop, true);
                withBlock.AddParameter("@LeaseHold", oSite.LeaseHold, true);
                withBlock.AddParameter("@PropertyVoid", oSite.PropertyVoid, true);
                withBlock.AddParameter("@SiteFuel", oSite.SiteFuel, true);
                withBlock.AddParameter("@Salutation", oSite.Salutation, true);
                withBlock.AddParameter("@FirstName", oSite.FirstName, true);
                withBlock.AddParameter("@Surname", oSite.Surname, true);
                withBlock.AddParameter("@Longs", oSite.Longitude, true);
                withBlock.AddParameter("@Lat", oSite.Latitude, true);
                withBlock.AddParameter("@DirectDebitRef", oSite.DirectDebitRef, true);
                withBlock.AddParameter("@BuildDate", Helper.InsertDateIntoDb(oSite.BuildDate), true);
                withBlock.AddParameter("@WarrantyPeriodInMonths", oSite.WarrantyPeriodInMonths, true);
                withBlock.AddParameter("@PropertyVoidDate", Helper.InsertDateIntoDb(oSite.PropertyVoidDate), true);
                withBlock.AddParameter("@ContactAlerts", oSite.ContactAlerts, true);
                withBlock.AddParameter("@Defects", oSite.Defects, true);
                withBlock.AddParameter("@DefectEndDate", Helper.InsertDateIntoDb(oSite.DefectEndDate), true);
                withBlock.AddParameter("@HousingOfficer", oSite.HousingOfficer, true);
                withBlock.AddParameter("@HousingManager", oSite.HousingManager, true);
                withBlock.AddParameter("@EstateManager", oSite.EstateOfficer, true);
                withBlock.AddParameter("@AccomTypeID", oSite.AccomTypeID, true);
            }
        }

        private void Check_And_Insert_Postal_Region(string postcode)
        {
            string postcodePrefix = postcode.Split('-')[0].Trim();
            string SQL = "SELECT COUNT(ManagerID) AS 'numberOfRegions' FROM tblpicklists WHERE Deleted = 0 AND EnumTypeID = " + Conversions.ToInteger(Enums.PickListTypes.PostalRegions) + " AND Name = '" + postcodePrefix + "'";
            int numberOfRegions = Helper.MakeIntegerValid(_database.ExecuteScalar(SQL, false));
            if (numberOfRegions == 0)
            {
                var picklist = new PickLists.PickList();
                picklist.IgnoreExceptionsOnSetMethods = true;
                picklist.SetName = postcodePrefix;
                picklist.SetEnumTypeID = Conversions.ToInteger(Enums.PickListTypes.PostalRegions);
                picklist.SetManagerID = _database.Picklists.Insert(picklist);
                App.ShowForm(typeof(FRMPostcodeManager), true, new object[] { picklist.ManagerID });
            }
        }

        public DataView Site_CanItBeDeleted(int SiteID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            _database.AddParameter("@AwaitingConfirmationID", Conversions.ToInteger(Enums.OrderStatus.AwaitingConfirmation), true);
            _database.AddParameter("@ConfirmedID", Conversions.ToInteger(Enums.OrderStatus.Confirmed), true);
            var dt = _database.ExecuteSP_DataTable("Site_CanItBeDeleted");
            dt.TableName = Enums.TableNames.tblSite.ToString();
            return new DataView(dt);
        }

        public void Site_UpdateLastServiceDate(int SiteID, DateTime LastServiceDate, DateTime actualServiceDate, bool Override = false)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            _database.AddParameter("@LastServiceDate", LastServiceDate, true);
            _database.AddParameter("@ActualServiceDate", actualServiceDate, true);
            _database.AddParameter("@Override", Override, true);
            _database.ExecuteSP_NO_Return("Site_UpdateLastServiceDate");
        }

        public bool Site_Update_ContactAlerts(int siteId, string contactAlert)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", siteId, true);
            _database.AddParameter("@ContactAlerts", contactAlert, true);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("Site_Update_ContactAlerts") == 1);
        }

        public DataView GetSiteNotes(int siteID)
        {
            //
            _database.ClearParameter();
            _database.AddParameter("@SiteID", siteID, true);
            var dt = _database.ExecuteSP_DataTable("SiteNote_Get_For_Site");
            dt.TableName = Enums.TableNames.tblSiteNotes.ToString();
            return new DataView(dt);
        }

        public DataView SaveSiteNotes(int SiteNoteID, string Note, int EditedByUserID, int SiteID, int CreatedByUserID)
        {
            _database.ClearParameter();
            if (SiteNoteID > 0)
            {
                _database.AddParameter("@SiteNoteID", SiteNoteID, true);
                _database.AddParameter("@Note", Note, true);
                _database.AddParameter("@EditedByUserID", EditedByUserID, true);
                _database.ExecuteSP_NO_Return("SiteNote_Update");
            }
            else
            {
                _database.AddParameter("@SiteID", SiteID, true);
                _database.AddParameter("@Note", Note, true);
                _database.AddParameter("@CreatedByUserID", CreatedByUserID, true);
                _database.ExecuteSP_NO_Return("SiteNote_Insert");
            }

            return GetSiteNotes(SiteID);
        }

        public void DeleteSiteNote(int siteNoteID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteNoteID", siteNoteID, true);
            _database.ExecuteSP_NO_Return("SiteNote_Delete");
        }

        public DataView SiteFuel_GetAll_ForSite(int siteID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", siteID, true);
            var dt = _database.ExecuteSP_DataTable("SiteFuel_GetAll_ForSite");
            dt.TableName = Enums.TableNames.tblSiteFuel.ToString();
            return new DataView(dt);
        }

        public DataView SiteFuel_Get_ForEngineerVisit(int EngineerVisitID)
        {
            _database.ClearParameter();
            _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
            var dt = _database.ExecuteSP_DataTable("SiteFuel_Get_ForEngineerVisit");
            dt.TableName = Enums.TableNames.tblSiteFuel.ToString();
            return new DataView(dt);
        }

        public SiteFuel SiteFuel_Get(int siteFuelId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteFuelID", siteFuelId, true);

            // Get the datatable from the database store in dt
            var dt = _database.ExecuteSP_DataTable("SiteFuel_Get");
            if (dt is object)
            {
                if (dt.Rows.Count > 0)
                {
                    var oSiteFuel = new SiteFuel();
                    oSiteFuel.IgnoreExceptionsOnSetMethods = true;
                    if (dt.Columns.Contains("SiteFuelID"))
                        oSiteFuel.SetSiteFuelID = dt.Rows[0]["SiteFuelID"];
                    if (dt.Columns.Contains("SiteID"))
                        oSiteFuel.SetSiteID = dt.Rows[0]["SiteID"];
                    if (dt.Columns.Contains("FuelID"))
                        oSiteFuel.SetFuelID = dt.Rows[0]["FuelID"];
                    if (dt.Columns.Contains("SiteFuelChargeID"))
                        oSiteFuel.SetSiteFuelChargeID = dt.Rows[0]["SiteFuelChargeID"];
                    if (dt.Columns.Contains("LastServiceDate"))
                        oSiteFuel.LastServiceDate = Conversions.ToDate(dt.Rows[0]["LastServiceDate"]);
                    if (dt.Columns.Contains("ActualServiceDate"))
                        oSiteFuel.ActualServiceDate = Conversions.ToDate(dt.Rows[0]["ActualServiceDate"]);
                    if (dt.Columns.Contains("DateAdded"))
                        oSiteFuel.DateAdded = Conversions.ToDate(dt.Rows[0]["DateAdded"]);
                    if (dt.Columns.Contains("AddedBy"))
                        oSiteFuel.SetAddedBy = dt.Rows[0]["AddedBy"];
                    oSiteFuel.Exists = true;
                    return oSiteFuel;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool SiteFuel_Update(SiteFuel siteFuel)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteFuelID", siteFuel.SiteFuelID, true);
            _database.AddParameter("@SiteID", siteFuel.SiteID, true);
            _database.AddParameter("@FuelID", siteFuel.FuelID, true);
            _database.AddParameter("@LastServiceDate", siteFuel.LastServiceDate, true);
            _database.AddParameter("@ActualServiceDate", siteFuel.ActualServiceDate, true);
            _database.AddParameter("@SiteFuelChargeID", siteFuel.SiteFuelChargeID, true);
            _database.AddParameter("@AddedBy", App.loggedInUser.UserID, true);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("SiteFuel_Update") == 1);
        }

        public bool SiteFuel_Update_LastServiceDate(int siteId, int fuelId, DateTime lastServiceDate, DateTime actualServiceDate)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", siteId, true);
            _database.AddParameter("@FuelID", fuelId, true);
            _database.AddParameter("@LastServiceDate", lastServiceDate, true);
            _database.AddParameter("@ActualServiceDate", actualServiceDate, true);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("SiteFuel_Update_LastServiceDate") == 1);
        }

        public bool SiteFuel_Delete(int siteFuelId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteFuelID", siteFuelId, true);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("SiteFuel_Delete") == 1);
        }

        public void SiteFuelAudit_Insert(int siteID, string actionChange)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", siteID, true);
            _database.AddParameter("@ActionChange", actionChange, true);
            _database.AddParameter("@ActionDateTime", DateTime.Now, true);
            _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
            _database.ExecuteSP_NO_Return("SiteFuelAudit_Insert");
        }

        public DataView SiteFuelAudit_Get(int siteId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", siteId, true);
            var dt = _database.ExecuteSP_DataTable("SiteFuelAudit_Get");
            dt.TableName = Enums.TableNames.tblSiteFuel.ToString();
            return new DataView(dt);
        }

        public DataView SiteFuelCharge_GetAll()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("SiteFuelCharge_GetAll");
            dt.TableName = Enums.TableNames.tblSiteFuel.ToString();
            return new DataView(dt);
        }
    }
}