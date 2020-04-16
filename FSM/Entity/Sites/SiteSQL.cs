// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sites.SiteSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.PickLists;
using FSM.Entity.SiteCustomerAudits;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Sites
{
  public class SiteSQL
  {
    private Database _database;

    public SiteSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      this._database.ExecuteSP_NO_Return("Site_Delete", true);
    }

    public Site Get(object @ref, SiteSQL.GetBy getBy = SiteSQL.GetBy.SiteId, object ref2 = null)
    {
      this._database.ClearParameter();
      DataTable dataTable;
      switch (getBy)
      {
        case SiteSQL.GetBy.SiteId:
          this._database.AddParameter("@SiteID", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), false);
          dataTable = this._database.ExecuteSP_DataTable("Site_Get", true);
          break;
        case SiteSQL.GetBy.Uprn:
          this._database.AddParameter("@UPRN", (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          this._database.AddParameter("@CustomerId", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(ref2)), true);
          dataTable = this._database.ExecuteSP_DataTable("Site_Get_ForUPRN", true);
          break;
        case SiteSQL.GetBy.Asset:
          this._database.AddParameter("@AssetID", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          dataTable = this._database.ExecuteSP_DataTable("Site_Get_ForAssetID", true);
          break;
        case SiteSQL.GetBy.EngineerVisitId:
          this._database.AddParameter("@EngineerVisitID", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          dataTable = this._database.ExecuteSP_DataTable("Site_Get_ForEngineerVisitID", true);
          break;
        case SiteSQL.GetBy.CustomerHq:
          this._database.AddParameter("@CustomerID", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), true);
          dataTable = this._database.ExecuteSP_DataTable("[Sites_GetHOForCustomer]", true);
          break;
        case SiteSQL.GetBy.JobId:
          this._database.AddParameter("@JobID ", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), false);
          dataTable = this._database.ExecuteSP_DataTable("Site_Get_ForJobID", true);
          break;
        default:
          this._database.AddParameter("@SiteID", (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(@ref)), false);
          dataTable = this._database.ExecuteSP_DataTable("Site_Get", true);
          break;
      }
      Site site1;
      if (dataTable != null)
      {
        if (dataTable.Rows.Count > 0)
        {
          Site site2 = new Site();
          Site site3 = site2;
          site3.IgnoreExceptionsOnSetMethods = true;
          if (dataTable.Columns.Contains("SiteID"))
            site3.SetSiteID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]));
          if (dataTable.Columns.Contains("Name"))
            site3.SetName = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]));
          if (dataTable.Columns.Contains("CustomerID"))
            site3.SetCustomerID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CustomerID"]));
          if (dataTable.Columns.Contains("RegionID"))
            site3.SetRegionID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RegionID"]));
          if (dataTable.Columns.Contains("HeadOffice"))
            site3.SetHeadOffice = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HeadOffice"]));
          if (dataTable.Columns.Contains("Notes"))
            site3.SetNotes = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]));
          if (dataTable.Columns.Contains("Address1"))
            site3.SetAddress1 = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address1"]));
          if (dataTable.Columns.Contains("Address2"))
            site3.SetAddress2 = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address2"]));
          if (dataTable.Columns.Contains("Address3"))
            site3.SetAddress3 = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address3"]));
          if (dataTable.Columns.Contains("Address4"))
            site3.SetAddress4 = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address4"]));
          if (dataTable.Columns.Contains("Address5"))
            site3.SetAddress5 = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Address5"]));
          if (dataTable.Columns.Contains("Postcode"))
            site3.SetPostcode = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Postcode"]));
          if (dataTable.Columns.Contains("TelephoneNum"))
            site3.SetTelephoneNum = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNum"]));
          if (dataTable.Columns.Contains("FaxNum"))
            site3.SetFaxNum = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FaxNum"]));
          if (dataTable.Columns.Contains("EmailAddress"))
            site3.SetEmailAddress = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]));
          if (dataTable.Columns.Contains("EngineerID"))
            site3.SetEngineerID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]));
          if (dataTable.Columns.Contains("PoNumReqd"))
            site3.SetPoNumReqd = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PoNumReqd"]));
          if (dataTable.Columns.Contains("Deleted"))
            site3.SetDeleted = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Deleted"]));
          if (dataTable.Columns.Contains("PolicyNumber"))
            site3.SetPolicyNumber = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PolicyNumber"]));
          if (dataTable.Columns.Contains("AcceptChargesChanges"))
            site3.SetAcceptChargesChanges = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AcceptChargesChanges"]));
          if (dataTable.Columns.Contains("SourceOfCustomerID"))
            site3.SetSourceOfCustomerID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SourceOfCustomerID"]));
          if (dataTable.Columns.Contains("NoMarketing"))
            site3.SetNoMarketing = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NoMarketing"]));
          if (dataTable.Columns.Contains("ReasonForContactID"))
            site3.SetReasonForContactID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ReasonForContactID"]));
          if (dataTable.Columns.Contains("OnStop"))
            site3.SetOnStop = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OnStop"]));
          if (dataTable.Columns.Contains("SolidFuel"))
            site3.SetSolidFuel = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SolidFuel"]));
          if (dataTable.Columns.Contains("NoService"))
            site3.SetNoService = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NoService"]));
          if (dataTable.Columns.Contains("LeaseHold"))
            site3.SetLeaseHold = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LeaseHold"]));
          if (dataTable.Columns.Contains("CommercialDistrict"))
            site3.SetCommercialDistrict = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CommercialDistrict"]));
          if (dataTable.Columns.Contains("LastServiceDate"))
            site3.LastServiceDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastServiceDate"]));
          if (dataTable.Columns.Contains("ActualServiceDate"))
            site3.ActualServiceDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ActualServiceDate"]));
          if (dataTable.Columns.Contains("PropertyVoid"))
            site3.SetPropertyVoid = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PropertyVoid"]));
          if (dataTable.Columns.Contains("SiteFuel"))
            site3.SetSiteFuel = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteFuel"]));
          if (dataTable.Columns.Contains("Salutation"))
            site3.SetSalutation = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Salutation"]));
          if (dataTable.Columns.Contains("FirstName"))
            site3.SetFirstName = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FirstName"]));
          if (dataTable.Columns.Contains("Surname"))
            site3.SetSurname = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Surname"]));
          if (dataTable.Columns.Contains("asbestos"))
            site3.SetAsbestos = (object) Helper.MakeStringValid((object) dataTable.Rows[0]["asbestos"].ToString().Replace("/n", "\r\n"));
          if (dataTable.Columns.Contains("ContactAlerts"))
            site3.SetContactAlerts = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContactAlerts"]));
          if (dataTable.Columns.Contains("Longitude"))
            site3.SetLongitude = new Decimal(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Longitude"])));
          if (dataTable.Columns.Contains("Latitude"))
            site3.SetLatitude = new Decimal(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Latitude"])));
          if (dataTable.Columns.Contains("DirectDebitRef"))
            site3.SetDirectDebitRef = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DirectDebitRef"]));
          if (dataTable.Columns.Contains("BuildDate"))
            site3.BuildDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BuildDate"]));
          if (dataTable.Columns.Contains("HousingOfficer"))
            site3.SetHousingOfficer = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HousingOfficer"]));
          if (dataTable.Columns.Contains("EstateOfficer"))
            site3.SetEstateOfficer = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EstateOfficer"]));
          if (dataTable.Columns.Contains("HousingManager"))
            site3.SetHousingManager = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HousingManager"]));
          if (dataTable.Columns.Contains("WarrantyPeriodInMonths"))
            site3.SetWarrantyPeriodInMonths = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarrantyPeriodInMonths"]));
          if (dataTable.Columns.Contains("PropertyVoidDate"))
            site3.PropertyVoidDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PropertyVoidDate"]));
          if (dataTable.Columns.Contains("Defects"))
            site3.SetDefects = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Defects"]));
          if (dataTable.Columns.Contains("DefectEndDate"))
            site3.DefectEndDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DefectEndDate"]));
          if (dataTable.Columns.Contains("AccomTypeID"))
            site3.SetAccomTypeID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AccomTypeID"]));
          site2.Exists = true;
          site1 = site2;
        }
        else
          site1 = (Site) null;
      }
      return site1;
    }

    public DataView GetAll_FleetGarage(int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("Site_GetAll_FleetGarage_Mk1", true);
      table.TableName = Enums.TableNames.tblSite.ToString();
      return new DataView(table);
    }

    public DataView GetAll_Light(int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("Site_GetAll_Light_Mk1", true);
      table.TableName = Enums.TableNames.tblSite.ToString();
      return new DataView(table);
    }

    public DataView GetAll_Light_New(int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("Site_GetAll_Light_New_Mk1", true);
      table.TableName = Enums.TableNames.tblSite.ToString();
      return new DataView(table);
    }

    public DataView GetForCustomer_Light(int CustomerID, int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("[Sites_GetForCustomer_Light_Mk1]", true);
      table.TableName = Enums.TableNames.tblSite.ToString();
      return new DataView(table);
    }

    public DataView Search(string Criteria, int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) Criteria, true);
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("Site_SearchList_Mk1", true);
      table.TableName = Enums.TableNames.tblSite.ToString();
      return new DataView(table);
    }

    public DataView Search_JobWizard(string Criteria, int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) Criteria, true);
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("Site_Search_JobWizard", true);
      table.TableName = Enums.TableNames.tblSite.ToString();
      return new DataView(table);
    }

    public DataView Search_FleetGarage(string Criteria, int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) Criteria, true);
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("Site_SearchList_FleetGarage_Mk1", true);
      table.TableName = Enums.TableNames.tblFleetGarage.ToString();
      return new DataView(table);
    }

    public Site Insert(Site oSite)
    {
      this._database.ClearParameter();
      this.AddPropertyParametersToCommand(ref oSite);
      this._database.AddParameter("@SiteAddedByUserID", (object) App.loggedInUser.UserID, true);
      oSite.SetSiteID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Site_Insert", true)));
      oSite.Exists = true;
      this.Check_And_Insert_Postal_Region(oSite.Postcode);
      return oSite;
    }

    public void Update(Site oSite)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) oSite.SiteID, true);
      this.AddPropertyParametersToCommand(ref oSite);
      this._database.ExecuteSP_NO_Return("Site_Update", true);
      this.Check_And_Insert_Postal_Region(oSite.Postcode);
    }

    public void Update_Customer(int siteId, int oldCustomerId, int customerId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteId, true);
      this._database.AddParameter("@CustomerID", (object) customerId, true);
      this._database.ExecuteSP_NO_Return("Site_Update_Customer", true);
      App.DB.SiteCustomerAudit.Insert(new SiteCustomerAudit()
      {
        DateChanged = DateAndTime.Now,
        SetSiteID = (object) siteId,
        SetPreviousCustomerID = (object) oldCustomerId,
        SetUserID = (object) App.loggedInUser.UserID
      });
    }

    private void AddPropertyParametersToCommand(ref Site oSite)
    {
      Database database = this._database;
      database.AddParameter("@CustomerID", (object) oSite.CustomerID, true);
      database.AddParameter("@Name", (object) oSite.Name, true);
      database.AddParameter("@RegionID", (object) oSite.RegionID, true);
      database.AddParameter("@HeadOffice", (object) oSite.HeadOffice, true);
      database.AddParameter("@Notes", (object) oSite.Notes, true);
      database.AddParameter("@Address1", (object) oSite.Address1, true);
      database.AddParameter("@Address2", (object) oSite.Address2, true);
      database.AddParameter("@Address3", (object) oSite.Address3, true);
      database.AddParameter("@Address4", (object) oSite.Address4, true);
      database.AddParameter("@Address5", (object) oSite.Address5, true);
      database.AddParameter("@Postcode", (object) oSite.Postcode, true);
      database.AddParameter("@TelephoneNum", (object) oSite.TelephoneNum, true);
      database.AddParameter("@FaxNum", (object) oSite.FaxNum, true);
      database.AddParameter("@EmailAddress", (object) oSite.EmailAddress, true);
      database.AddParameter("@EngineerID", (object) oSite.EngineerID, true);
      database.AddParameter("@PONumReqd", (object) oSite.PoNumReqd, true);
      database.AddParameter("@PolicyNumber", (object) oSite.PolicyNumber, true);
      database.AddParameter("@AcceptChargesChanges", (object) oSite.AcceptChargesChanges, true);
      database.AddParameter("@SourceOfCustomerID", (object) oSite.SourceOfCustomerID, true);
      database.AddParameter("@NoMarketing", (object) oSite.NoMarketing, true);
      database.AddParameter("@NoService", (object) oSite.NoService, true);
      database.AddParameter("@ReasonForContactID", (object) oSite.ReasonForContactID, true);
      database.AddParameter("@OnStop", (object) oSite.OnStop, true);
      database.AddParameter("@LeaseHold", (object) oSite.LeaseHold, true);
      database.AddParameter("@PropertyVoid", (object) oSite.PropertyVoid, true);
      database.AddParameter("@SiteFuel", (object) oSite.SiteFuel, true);
      database.AddParameter("@Salutation", (object) oSite.Salutation, true);
      database.AddParameter("@FirstName", (object) oSite.FirstName, true);
      database.AddParameter("@Surname", (object) oSite.Surname, true);
      database.AddParameter("@Longs", (object) oSite.Longitude, true);
      database.AddParameter("@Lat", (object) oSite.Latitude, true);
      database.AddParameter("@DirectDebitRef", (object) oSite.DirectDebitRef, true);
      database.AddParameter("@BuildDate", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oSite.BuildDate)), true);
      database.AddParameter("@WarrantyPeriodInMonths", (object) oSite.WarrantyPeriodInMonths, true);
      database.AddParameter("@PropertyVoidDate", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oSite.PropertyVoidDate)), true);
      database.AddParameter("@ContactAlerts", (object) oSite.ContactAlerts, true);
      database.AddParameter("@Defects", (object) oSite.Defects, true);
      database.AddParameter("@DefectEndDate", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(oSite.DefectEndDate)), true);
      database.AddParameter("@HousingOfficer", (object) oSite.HousingOfficer, true);
      database.AddParameter("@HousingManager", (object) oSite.HousingManager, true);
      database.AddParameter("@EstateManager", (object) oSite.EstateOfficer, true);
      database.AddParameter("@AccomTypeID", (object) oSite.AccomTypeID, true);
    }

    private void Check_And_Insert_Postal_Region(string postcode)
    {
      string str = postcode.Split('-')[0].Trim();
      if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(ManagerID) AS 'numberOfRegions' FROM tblpicklists WHERE Deleted = 0 AND EnumTypeID = " + Conversions.ToString(10) + " AND Name = '" + str + "'", false, false))) != 0)
        return;
      PickList pickList = new PickList()
      {
        IgnoreExceptionsOnSetMethods = true,
        SetName = (object) str,
        SetEnumTypeID = (object) 10
      };
      pickList.SetManagerID = (object) this._database.Picklists.Insert(pickList);
      App.ShowForm(typeof (FRMPostcodeManager), true, new object[1]
      {
        (object) pickList.ManagerID
      }, false);
    }

    public DataView Site_CanItBeDeleted(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      this._database.AddParameter("@AwaitingConfirmationID", (object) 1, true);
      this._database.AddParameter("@ConfirmedID", (object) 2, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Site_CanItBeDeleted), true);
      table.TableName = Enums.TableNames.tblSite.ToString();
      return new DataView(table);
    }

    public void Site_UpdateLastServiceDate(
      int SiteID,
      DateTime LastServiceDate,
      DateTime actualServiceDate,
      bool Override = false)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      this._database.AddParameter("@LastServiceDate", (object) LastServiceDate, true);
      this._database.AddParameter("@ActualServiceDate", (object) actualServiceDate, true);
      this._database.AddParameter("@Override", (object) Override, true);
      this._database.ExecuteSP_NO_Return(nameof (Site_UpdateLastServiceDate), true);
    }

    public bool Site_Update_ContactAlerts(int siteId, string contactAlert)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteId, true);
      this._database.AddParameter("@ContactAlerts", (object) contactAlert, true);
      return this._database.ExecuteSP_ReturnRowsAffected(nameof (Site_Update_ContactAlerts)) == 1;
    }

    public DataView GetSiteNotes(int siteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteID, true);
      DataTable table = this._database.ExecuteSP_DataTable("SiteNote_Get_For_Site", true);
      table.TableName = Enums.TableNames.tblSiteNotes.ToString();
      return new DataView(table);
    }

    public DataView SaveSiteNotes(
      int SiteNoteID,
      string Note,
      int EditedByUserID,
      int SiteID,
      int CreatedByUserID)
    {
      this._database.ClearParameter();
      if (SiteNoteID > 0)
      {
        this._database.AddParameter("@SiteNoteID", (object) SiteNoteID, true);
        this._database.AddParameter("@Note", (object) Note, true);
        this._database.AddParameter("@EditedByUserID", (object) EditedByUserID, true);
        this._database.ExecuteSP_NO_Return("SiteNote_Update", true);
      }
      else
      {
        this._database.AddParameter("@SiteID", (object) SiteID, true);
        this._database.AddParameter("@Note", (object) Note, true);
        this._database.AddParameter("@CreatedByUserID", (object) CreatedByUserID, true);
        this._database.ExecuteSP_NO_Return("SiteNote_Insert", true);
      }
      return this.GetSiteNotes(SiteID);
    }

    public void DeleteSiteNote(int siteNoteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteNoteID", (object) siteNoteID, true);
      this._database.ExecuteSP_NO_Return("SiteNote_Delete", true);
    }

    public DataView SiteFuel_GetAll_ForSite(int siteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (SiteFuel_GetAll_ForSite), true);
      table.TableName = Enums.TableNames.tblSiteFuel.ToString();
      return new DataView(table);
    }

    public DataView SiteFuel_Get_ForEngineerVisit(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (SiteFuel_Get_ForEngineerVisit), true);
      table.TableName = Enums.TableNames.tblSiteFuel.ToString();
      return new DataView(table);
    }

    public SiteFuel SiteFuel_Get(int siteFuelId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteFuelID", (object) siteFuelId, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (SiteFuel_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (SiteFuel) null;
      SiteFuel siteFuel1 = new SiteFuel();
      SiteFuel siteFuel2 = siteFuel1;
      siteFuel2.IgnoreExceptionsOnSetMethods = true;
      if (dataTable.Columns.Contains("SiteFuelID"))
        siteFuel2.SetSiteFuelID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteFuelID"]);
      if (dataTable.Columns.Contains("SiteID"))
        siteFuel2.SetSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
      if (dataTable.Columns.Contains("FuelID"))
        siteFuel2.SetFuelID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FuelID"]);
      if (dataTable.Columns.Contains("SiteFuelChargeID"))
        siteFuel2.SetSiteFuelChargeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteFuelChargeID"]);
      if (dataTable.Columns.Contains("LastServiceDate"))
        siteFuel2.LastServiceDate = Conversions.ToDate(dataTable.Rows[0]["LastServiceDate"]);
      if (dataTable.Columns.Contains("ActualServiceDate"))
        siteFuel2.ActualServiceDate = Conversions.ToDate(dataTable.Rows[0]["ActualServiceDate"]);
      if (dataTable.Columns.Contains("DateAdded"))
        siteFuel2.DateAdded = Conversions.ToDate(dataTable.Rows[0]["DateAdded"]);
      if (dataTable.Columns.Contains("AddedBy"))
        siteFuel2.SetAddedBy = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddedBy"]);
      siteFuel1.Exists = true;
      return siteFuel1;
    }

    public bool SiteFuel_Update(SiteFuel siteFuel)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteFuelID", (object) siteFuel.SiteFuelID, true);
      this._database.AddParameter("@SiteID", (object) siteFuel.SiteID, true);
      this._database.AddParameter("@FuelID", (object) siteFuel.FuelID, true);
      this._database.AddParameter("@LastServiceDate", (object) siteFuel.LastServiceDate, true);
      this._database.AddParameter("@ActualServiceDate", (object) siteFuel.ActualServiceDate, true);
      this._database.AddParameter("@SiteFuelChargeID", (object) siteFuel.SiteFuelChargeID, true);
      this._database.AddParameter("@AddedBy", (object) App.loggedInUser.UserID, true);
      return this._database.ExecuteSP_ReturnRowsAffected(nameof (SiteFuel_Update)) == 1;
    }

    public bool SiteFuel_Update_LastServiceDate(
      int siteId,
      int fuelId,
      DateTime lastServiceDate,
      DateTime actualServiceDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteId, true);
      this._database.AddParameter("@FuelID", (object) fuelId, true);
      this._database.AddParameter("@LastServiceDate", (object) lastServiceDate, true);
      this._database.AddParameter("@ActualServiceDate", (object) actualServiceDate, true);
      return this._database.ExecuteSP_ReturnRowsAffected(nameof (SiteFuel_Update_LastServiceDate)) == 1;
    }

    public bool SiteFuel_Delete(int siteFuelId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteFuelID", (object) siteFuelId, true);
      return this._database.ExecuteSP_ReturnRowsAffected(nameof (SiteFuel_Delete)) == 1;
    }

    public void SiteFuelAudit_Insert(int siteID, string actionChange)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteID, true);
      this._database.AddParameter("@ActionChange", (object) actionChange, true);
      this._database.AddParameter("@ActionDateTime", (object) DateTime.Now, true);
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return(nameof (SiteFuelAudit_Insert), true);
    }

    public DataView SiteFuelAudit_Get(int siteId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteId, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (SiteFuelAudit_Get), true);
      table.TableName = Enums.TableNames.tblSiteFuel.ToString();
      return new DataView(table);
    }

    public DataView SiteFuelCharge_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (SiteFuelCharge_GetAll), true);
      table.TableName = Enums.TableNames.tblSiteFuel.ToString();
      return new DataView(table);
    }

    public enum GetBy
    {
      SiteId = 1,
      Uprn = 2,
      Asset = 3,
      EngineerVisitId = 4,
      CustomerHq = 5,
      JobId = 6,
    }
  }
}
