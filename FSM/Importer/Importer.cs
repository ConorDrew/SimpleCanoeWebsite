// Decompiled with JetBrains decompiler
// Type: FSM.Importer.Importer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Contacts;
using FSM.Entity.Management;
using FSM.Entity.Parts;
using FSM.Entity.PartSuppliers;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Importer
{
  public class Importer
  {
    private Database _database;
    private ArrayList _DataToImport;
    private ArrayList _arrayList;
    private FRMPartsImport _fRMImportNew;
    private static TransactionalDatabase _Tdatabase;
    private static SqlTransaction _Trans;
    private FRMImport _ImportForm;

    public Importer(Database database)
    {
      this._database = database;
    }

    public Importer(ArrayList arrayList, FRMPartsImport fRMImportNew)
    {
      this._arrayList = arrayList;
      this._fRMImportNew = fRMImportNew;
    }

    public ArrayList DataToImport
    {
      get
      {
        return this._DataToImport;
      }
      set
      {
        this._DataToImport = value;
      }
    }

    public TransactionalDatabase Tdatabase
    {
      get
      {
        return FSM.Importer.Importer._Tdatabase;
      }
      set
      {
        FSM.Importer.Importer._Tdatabase = value;
      }
    }

    public SqlTransaction Trans
    {
      get
      {
        return FSM.Importer.Importer._Trans;
      }
      set
      {
        FSM.Importer.Importer._Trans = value;
      }
    }

    public FRMImport ImportForm
    {
      get
      {
        return this._ImportForm;
      }
      set
      {
        this._ImportForm = value;
      }
    }

    public Importer(ArrayList DataToImportIn, ref FRMImport ImportFormIn)
    {
      this.DataToImport = DataToImportIn;
      FSM.Importer.Importer._Tdatabase = new TransactionalDatabase();
      FSM.Importer.Importer._Trans = (SqlTransaction) null;
      this.ImportForm = ImportFormIn;
      this.ImportForm.MoveProgressOn(false);
    }

    public void Import(int SupplierID, int UnitTypeID, int CustomerID = 0)
    {
      double partsImportMarkup = App.DB.Manager.Get().PartsImportMarkup;
      this.Trans = this.Tdatabase.Transaction_Get();
      try
      {
        int num = checked (this.DataToImport.Count - 1);
        int index = 0;
        while (index <= num)
        {
          DataView dvParts = (DataView) this.DataToImport[index];
          if (index == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dvParts.Table.TableName, "Parts", false) == 0)
            this.ImportParts(dvParts, SupplierID, partsImportMarkup, UnitTypeID);
          else if (!(index == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dvParts.Table.TableName, "Sites", false) == 0))
            ;
          checked { ++index; }
        }
        this.Tdatabase.Transaction_Commit(this.Trans);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        this.Tdatabase.Transaction_Rollback(this.Trans);
        throw new Exception("Error Importing, all actions have been rolled back.\r\n" + exception.Message);
      }
    }

    public void PreImport(
      int SupplierID,
      string PartCode,
      string Description,
      string Category,
      string SupplierPartCode,
      double SupplierPrice)
    {
      this.Part_PreImportInsert(SupplierID, PartCode, Description, Category, SupplierPartCode, SupplierPrice);
    }

    private void ImportSites(
      DataView dvSites,
      int CustomerID,
      string SourceOfCustomer,
      string ReasonForContact)
    {
      FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(CustomerID);
      Settings oSettings = App.DB.Manager.Get();
      int num1 = 0;
      DataRow[] dataRowArray1 = App.DB.Picklists.GetAll(Enums.PickListTypes.ReasonsForContact, false).Table.Select("Name ='" + ReasonForContact + "'");
      if (dataRowArray1.Length > 0)
        num1 = Conversions.ToInteger(dataRowArray1[0]["ManagerID"]);
      int num2 = 0;
      DataRow[] dataRowArray2 = App.DB.Picklists.GetAll(Enums.PickListTypes.SourceOfCustomer, false).Table.Select("Name ='" + SourceOfCustomer + "'");
      if (dataRowArray2.Length > 0)
        num2 = Conversions.ToInteger(dataRowArray2[0]["ManagerID"]);
      int num3 = checked (dvSites.Count - 1);
      int index = 0;
      while (index <= num3)
      {
        DataRowView dvSite = dvSites[index];
        Site oSite = new Site()
        {
          SetAcceptChargesChanges = (object) 1,
          SetCommercialDistrict = (object) 0,
          SetCustomerID = (object) CustomerID,
          SetEngineerID = (object) 0,
          SetHeadOffice = (object) false,
          SetNoMarketing = (object) false,
          SetNoService = (object) false,
          SetOnStop = (object) false,
          SetPoNumReqd = (object) false,
          SetReasonForContactID = (object) num1,
          SetRegionID = (object) customer.RegionID,
          SetSolidFuel = (object) false,
          SetSourceOfCustomerID = (object) num2
        };
        oSite.SetCustomerID = (object) CustomerID;
        if (dvSite["PolicyNumber"] != DBNull.Value)
          oSite.SetPolicyNumber = RuntimeHelpers.GetObjectValue(dvSite["PolicyNumber"]);
        if (dvSite["Tenant"] != DBNull.Value)
        {
          oSite.SetPropertyVoid = !Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Conversions.ToString(dvSite["Tenant"])), "Void", false) == 0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(dvSite["Tenant"], (object) "V", false))) ? (object) false : (object) true;
          oSite.SetLeaseHold = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dvSite["Tenant"], (object) "L", false) ? (object) false : (object) true;
        }
        if (dvSite["Address 1"] != DBNull.Value)
          oSite.SetAddress1 = Strings.Len(RuntimeHelpers.GetObjectValue(dvSite["Address 1"])) <= 0 ? (object) null : RuntimeHelpers.GetObjectValue(dvSite["Address 1"]);
        if (dvSite["Address 2"] != DBNull.Value)
          oSite.SetAddress2 = Strings.Len(RuntimeHelpers.GetObjectValue(dvSite["Address 2"])) <= 0 ? (object) null : (object) Strings.Trim(Conversions.ToString(dvSite["Address 2"]));
        if (dvSite["Address 3"] != DBNull.Value)
          oSite.SetAddress3 = Strings.Len(RuntimeHelpers.GetObjectValue(dvSite["Address 3"])) <= 0 ? (object) null : (object) Strings.Trim(Conversions.ToString(dvSite["Address 3"]));
        if (dvSite["Address 4"] != DBNull.Value)
          oSite.SetAddress4 = Strings.Len(RuntimeHelpers.GetObjectValue(dvSite["Address 4"])) <= 0 ? (object) null : (object) Strings.Trim(Conversions.ToString(dvSite["Address 4"]));
        if (dvSite["PostCode"] != DBNull.Value)
        {
          if (Strings.Len(RuntimeHelpers.GetObjectValue(dvSite["PostCode"])) > 0)
          {
            oSite.SetPostcode = (object) Strings.Replace(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dvSite["PostCode"])), " ", "-", 1, -1, CompareMethod.Binary);
            if (oSite.Postcode.Length == 0)
              oSite.SetPostcode = (object) "XXX-XXX";
          }
          else
            oSite.SetPostcode = (object) "XXX-XXX";
        }
        else
          oSite.SetPostcode = (object) "XXX-XXX";
        if (dvSite["Tenant"] != DBNull.Value)
        {
          string str1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dvSite["Tenant"]));
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(str1), "Void", false) == 0)
          {
            if (dvSite["Address 1"] != DBNull.Value)
            {
              string str2 = Conversions.ToString(dvSite["Address 1"]);
              oSite.SetName = (object) str2;
            }
          }
          else
          {
            string str2 = Strings.Trim(str1);
            oSite.SetName = (object) str2;
          }
        }
        else if (dvSite["Address 1"] != DBNull.Value)
        {
          string str = Conversions.ToString(dvSite["Address 1"]);
          oSite.SetName = (object) str;
        }
        if (dvSite["EmailAddress"] != DBNull.Value)
          oSite.SetEmailAddress = Strings.Len(Strings.Trim(dvSite["EmailAddress"].ToString())) <= 0 ? (object) null : (object) Conversions.ToString(dvSite["EmailAddress"]);
        if (dvSite["FaxNum"] != DBNull.Value)
          oSite.SetFaxNum = Strings.Len(Strings.Trim(dvSite["FaxNum"].ToString())) <= 0 ? (object) null : (object) Conversions.ToString(dvSite["FaxNum"]);
        if (dvSite["TelephoneNum"] != DBNull.Value)
          oSite.SetTelephoneNum = Strings.Len(Strings.Trim(dvSite["TelephoneNum"].ToString())) <= 0 ? (object) 0 : (object) Conversions.ToString(dvSite["TelephoneNum"]);
        if (dvSite["heating type"] != DBNull.Value)
        {
          string str = Strings.Trim(dvSite["heating type"].ToString());
          oSite.SetSiteFuel = (object) str;
        }
        if (dvSite["Notes"] != DBNull.Value)
        {
          Helper.MakeStringValid((object) dvSite["Notes"].ToString()).Trim();
          if ((uint) Helper.MakeStringValid((object) dvSite["Notes"].ToString()).Trim().Length > 0U)
          {
            string str = Helper.MakeStringValid((object) dvSite["Notes"].ToString()).Trim();
            oSite.SetNotes = (object) Strings.Trim(str);
          }
        }
        if (dvSite["Last Service Date"] != DBNull.Value && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dvSite["Last Service Date"].ToString(), "", false) != 0)
        {
          DateTime date = Conversions.ToDate(Conversions.ToString(dvSite["Last Service Date"]));
          oSite.LastServiceDate = date;
        }
        if (oSite.Exists)
          this.Update_Site(oSite);
        else
          oSite.SetSiteID = (object) this.Insert_Site(oSite, oSettings);
        if (dvSite["Tenant"] != DBNull.Value && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Trim(Conversions.ToString(dvSite["Tenant"])), "Void", false) != 0)
        {
          Contact contact = new Contact();
          Strings.Split(Conversions.ToString(dvSite["Tenant"]), " ", -1, CompareMethod.Binary);
        }
        this.ImportForm.MoveProgressOn(false);
        checked { ++index; }
      }
    }

    private void Part_PreImportInsert(
      int SupplierID,
      string PartCode,
      string Description,
      string Category,
      string SupplierPartCode,
      double SupplierPrice)
    {
      SqlCommand storedProcedure = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure(nameof (Part_PreImportInsert), this.Trans);
      storedProcedure.Parameters.Clear();
      storedProcedure.Parameters.AddWithValue(nameof (SupplierID), (object) SupplierID);
      storedProcedure.Parameters.AddWithValue(nameof (PartCode), (object) PartCode);
      storedProcedure.Parameters.AddWithValue(nameof (Description), (object) Description);
      storedProcedure.Parameters.AddWithValue(nameof (Category), (object) Category);
      storedProcedure.Parameters.AddWithValue(nameof (SupplierPartCode), (object) SupplierPartCode);
      storedProcedure.Parameters.AddWithValue(nameof (SupplierPrice), (object) SupplierPrice);
    }

    private void ImportParts(
      DataView dvParts,
      int SupplierID,
      double PartsImportMarkup,
      int UnitTypeID)
    {
      int num = checked (dvParts.Count - 1);
      int index = 0;
      while (index <= num)
      {
        DataRowView dvPart = dvParts[index];
        int CategoryID = App.DB.ImportValidation.CategoryID(Conversions.ToString(dvPart["Category"]), this.Trans);
        string str = !Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Part Code"])) && Conversions.ToString(dvPart["Supplier Part Code"]).Length > 0 ? Conversions.ToString(dvPart["Supplier Part Code"]) : Conversions.ToString(dvPart["Part Code"]);
        int PartID = App.DB.Part.Part_Exists(Conversions.ToString(dvPart["Part Code"]), Conversions.ToString(dvPart["Supplier Part Code"]), this.Trans);
        if (PartID == 0)
        {
          double SellPrice = Helper.MakeDoubleValid((object) Strings.Format((object) Helper.MakeDoubleValid((object) (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Supplier Price"])) * (PartsImportMarkup / 100.0 + 1.0))), "F"));
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Sell Price"])) && (object) dvPart["Sell Price"].GetType() == (object) typeof (Decimal))
            SellPrice = Helper.MakeDoubleValid((object) Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Sell Price"])), "F"));
          string Notes = "";
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Notes"])) && Conversions.ToString(dvPart["Notes"]).Length > 0)
            Notes = Conversions.ToString(dvPart["Notes"]);
          this.Insert_Part_Supplier(this.Insert_Part(Conversions.ToString(dvPart["Part Code"]), Conversions.ToString(dvPart["Name/Description"]), CategoryID, UnitTypeID, Notes, SellPrice), str, SupplierID, Helper.MakeDoubleValid((object) Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Supplier Price"])), "F")), Helper.MakeIntegerValid((object) Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Supplier Qty"])), "F")));
        }
        else
        {
          bool flag1 = false;
          Part oPart = App.DB.Part.Part_Get(PartID, this.Trans);
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Category"])) && Conversions.ToString(dvPart["Category"]).Length > 0)
          {
            oPart.SetCategoryID = (object) CategoryID;
            flag1 = true;
          }
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Notes"])) && Conversions.ToString(dvPart["Notes"]).Length > 0)
          {
            oPart.SetNotes = RuntimeHelpers.GetObjectValue(dvPart["Notes"]);
            flag1 = true;
          }
          if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Sell Price"])) && (object) dvPart["Sell Price"].GetType() == (object) typeof (Decimal))
          {
            oPart.SetSellPrice = (object) Helper.MakeDoubleValid((object) Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Sell Price"])), "F"));
            flag1 = true;
          }
          if (flag1)
            this.Update_Part(oPart);
          Array array = (Array) App.DB.PartSupplier.Get_ByPartID(oPart.PartID, this.Trans).Table.Select("SupplierID = " + Conversions.ToString(SupplierID));
          if (array.Length == 0)
          {
            this.Insert_Part_Supplier(oPart.PartID, str, SupplierID, Helper.MakeDoubleValid((object) Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Supplier Price"])), "F")), Helper.MakeIntegerValid((object) Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Supplier Qty"])), "F")));
          }
          else
          {
            PartSupplier oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(Conversions.ToInteger(((DataRow) NewLateBinding.LateIndexGet((object) array, new object[1]
            {
              (object) 0
            }, (string[]) null))["PartSupplierID"]), this.Trans);
            bool flag2 = false;
            if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, (string) null, false) > 0U && str.Length > 0)
            {
              oPartSupplier.SetPartCode = (object) str;
              flag2 = true;
            }
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Qty"])) && (object) dvPart["Supplier Qty"].GetType() == (object) typeof (double))
            {
              oPartSupplier.SetQuantityInPack = (object) Helper.MakeIntegerValid((object) Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Supplier Qty"])), "F"));
              flag2 = true;
            }
            if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Price"])) && (object) dvPart["Supplier Price"].GetType() == (object) typeof (Decimal))
            {
              oPartSupplier.SetPrice = (object) Helper.MakeDoubleValid((object) Strings.Format((object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dvPart["Supplier Price"])), "F"));
              flag2 = true;
            }
            if (flag2)
              this.Update_Part_Supplier(oPartSupplier);
          }
        }
        this.ImportForm.MoveProgressOn(false);
        checked { ++index; }
      }
    }

    public DataView GetByPolicyNumber(string policyNumber, int customerID)
    {
      SqlCommand storedProcedure = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("Site_GetByPolicyNumber", this.Trans);
      storedProcedure.Parameters.Clear();
      storedProcedure.Parameters.AddWithValue("@policyNumber", (object) policyNumber);
      storedProcedure.Parameters.AddWithValue("@customerID", (object) customerID);
      return new DataView(FSM.Importer.Importer._Tdatabase.ExecuteTableSPTrans(storedProcedure));
    }

    public int Insert_Site(Site oSite, Settings oSettings)
    {
      SqlCommand storedProcedure1 = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("Site_Insert", this.Trans);
      storedProcedure1.Parameters.Clear();
      storedProcedure1.Parameters.AddWithValue("@SiteAddedByUserID", (object) App.loggedInUser.UserID);
      storedProcedure1.Parameters.AddWithValue("@CustomerID", (object) oSite.CustomerID);
      storedProcedure1.Parameters.AddWithValue("@Name", (object) oSite.Name);
      storedProcedure1.Parameters.AddWithValue("@RegionID", (object) oSite.RegionID);
      storedProcedure1.Parameters.AddWithValue("@HeadOffice", (object) oSite.HeadOffice);
      storedProcedure1.Parameters.AddWithValue("@Notes", (object) oSite.Notes);
      storedProcedure1.Parameters.AddWithValue("@Address1", (object) oSite.Address1);
      storedProcedure1.Parameters.AddWithValue("@Address2", (object) oSite.Address2);
      storedProcedure1.Parameters.AddWithValue("@Address3", (object) oSite.Address3);
      storedProcedure1.Parameters.AddWithValue("@Address4", (object) oSite.Address4);
      storedProcedure1.Parameters.AddWithValue("@Address5", (object) oSite.Address5);
      storedProcedure1.Parameters.AddWithValue("@Postcode", (object) oSite.Postcode);
      storedProcedure1.Parameters.AddWithValue("@TelephoneNum", (object) oSite.TelephoneNum);
      storedProcedure1.Parameters.AddWithValue("@FaxNum", (object) oSite.FaxNum);
      storedProcedure1.Parameters.AddWithValue("@EmailAddress", (object) oSite.EmailAddress);
      storedProcedure1.Parameters.AddWithValue("@EngineerID", (object) oSite.EngineerID);
      storedProcedure1.Parameters.AddWithValue("@PONumReqd", (object) oSite.PoNumReqd);
      storedProcedure1.Parameters.AddWithValue("@PolicyNumber", (object) oSite.PolicyNumber);
      storedProcedure1.Parameters.AddWithValue("@AcceptChargesChanges", (object) oSite.AcceptChargesChanges);
      storedProcedure1.Parameters.AddWithValue("@SourceOfCustomerID", (object) oSite.SourceOfCustomerID);
      storedProcedure1.Parameters.AddWithValue("@NoMarketing", (object) oSite.NoMarketing);
      storedProcedure1.Parameters.AddWithValue("@ReasonForContactID", (object) oSite.ReasonForContactID);
      storedProcedure1.Parameters.AddWithValue("@OnStop", (object) oSite.OnStop);
      storedProcedure1.Parameters.AddWithValue("@LeaseHold", (object) oSite.LeaseHold);
      storedProcedure1.Parameters.AddWithValue("@PropertyVoid", (object) oSite.PropertyVoid);
      storedProcedure1.Parameters.AddWithValue("@SiteFuel", (object) oSite.SiteFuel);
      int num = FSM.Importer.Importer._Tdatabase.ExecuteScalarSPTrans(storedProcedure1);
      SqlCommand storedProcedure2 = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("SiteCharge_Insert", this.Trans);
      storedProcedure2.Parameters.Clear();
      storedProcedure2.Parameters.AddWithValue("@SiteID", (object) num);
      storedProcedure2.Parameters.AddWithValue("@MileageRate", (object) oSettings.MileageRate);
      storedProcedure2.Parameters.AddWithValue("@PartsMarkup", (object) oSettings.PartsMarkup);
      storedProcedure2.Parameters.AddWithValue("@RatesMarkup", (object) oSettings.RatesMarkup);
      FSM.Importer.Importer._Tdatabase.ExecuteNonQuerySPTrans(storedProcedure2);
      SqlCommand storedProcedure3 = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("SiteScheduleOfRate_Insert_Defaults", this.Trans);
      storedProcedure3.Parameters.Clear();
      storedProcedure3.Parameters.AddWithValue("@SiteID", (object) num);
      storedProcedure3.Parameters.AddWithValue("@CustomerID", (object) oSite.CustomerID);
      FSM.Importer.Importer._Tdatabase.ExecuteNonQuerySPTrans(storedProcedure3);
      return num;
    }

    public void Update_Site(Site oSite)
    {
      SqlCommand storedProcedure = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("Site_Update", this.Trans);
      storedProcedure.Parameters.Clear();
      storedProcedure.Parameters.AddWithValue("@SiteID", (object) oSite.SiteID);
      storedProcedure.Parameters.AddWithValue("@CustomerID", (object) oSite.CustomerID);
      storedProcedure.Parameters.AddWithValue("@Name", (object) oSite.Name);
      storedProcedure.Parameters.AddWithValue("@RegionID", (object) oSite.RegionID);
      storedProcedure.Parameters.AddWithValue("@HeadOffice", (object) oSite.HeadOffice);
      storedProcedure.Parameters.AddWithValue("@Notes", (object) oSite.Notes);
      storedProcedure.Parameters.AddWithValue("@Address1", (object) oSite.Address1);
      storedProcedure.Parameters.AddWithValue("@Address2", (object) oSite.Address2);
      storedProcedure.Parameters.AddWithValue("@Address3", (object) oSite.Address3);
      storedProcedure.Parameters.AddWithValue("@Address4", (object) oSite.Address4);
      storedProcedure.Parameters.AddWithValue("@Address5", (object) oSite.Address5);
      storedProcedure.Parameters.AddWithValue("@Postcode", (object) oSite.Postcode);
      storedProcedure.Parameters.AddWithValue("@TelephoneNum", (object) oSite.TelephoneNum);
      storedProcedure.Parameters.AddWithValue("@FaxNum", (object) oSite.FaxNum);
      storedProcedure.Parameters.AddWithValue("@EmailAddress", (object) oSite.EmailAddress);
      storedProcedure.Parameters.AddWithValue("@EngineerID", (object) oSite.EngineerID);
      storedProcedure.Parameters.AddWithValue("@PONumReqd", (object) oSite.PoNumReqd);
      storedProcedure.Parameters.AddWithValue("@PolicyNumber", (object) oSite.PolicyNumber);
      storedProcedure.Parameters.AddWithValue("@AcceptChargesChanges", (object) oSite.AcceptChargesChanges);
      storedProcedure.Parameters.AddWithValue("@SourceOfCustomerID", (object) oSite.SourceOfCustomerID);
      storedProcedure.Parameters.AddWithValue("@NoMarketing", (object) oSite.NoMarketing);
      storedProcedure.Parameters.AddWithValue("@ReasonForContactID", (object) oSite.ReasonForContactID);
      storedProcedure.Parameters.AddWithValue("@OnStop", (object) oSite.OnStop);
      storedProcedure.Parameters.AddWithValue("@LeaseHold", (object) oSite.LeaseHold);
      storedProcedure.Parameters.AddWithValue("@PropertyVoid", (object) oSite.PropertyVoid);
      storedProcedure.Parameters.AddWithValue("@SiteFuel", (object) oSite.SiteFuel);
      FSM.Importer.Importer._Tdatabase.ExecuteNonQuerySPTrans(storedProcedure);
    }

    public DataView Contact_Get_ByFirstName(string FirstName, int SiteID)
    {
      SqlCommand storedProcedure = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure(nameof (Contact_Get_ByFirstName), this.Trans);
      storedProcedure.Parameters.Clear();
      storedProcedure.Parameters.AddWithValue("@FirstName", (object) FirstName);
      storedProcedure.Parameters.AddWithValue("@SiteID", (object) SiteID);
      return new DataView(FSM.Importer.Importer._Tdatabase.ExecuteTableSPTrans(storedProcedure));
    }

    public int InsertUpdate_Contact(Contact oContact, string InsertUpdate)
    {
      SqlCommand cmd = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(InsertUpdate, "Insert", false) != 0 ? FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("Contact_Update", this.Trans) : FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("Contact_Insert", this.Trans);
      cmd.Parameters.Clear();
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(InsertUpdate, "Insert", false) > 0U)
        cmd.Parameters.AddWithValue("@ContactID", (object) oContact.ContactID);
      cmd.Parameters.AddWithValue("@FirstName", (object) oContact.FirstName);
      cmd.Parameters.AddWithValue("@Surname", (object) oContact.Surname);
      cmd.Parameters.AddWithValue("@TelephoneNum", (object) oContact.TelephoneNum);
      cmd.Parameters.AddWithValue("@EmailAddress", (object) oContact.EmailAddress);
      cmd.Parameters.AddWithValue("@FaxNum", (object) oContact.FaxNum);
      cmd.Parameters.AddWithValue("@SiteID", (object) oContact.PropertyID);
      cmd.Parameters.AddWithValue("@MobileNo", (object) oContact.MobileNo);
      if ((uint) oContact.PortalUserName.Trim().Length > 0U)
        cmd.Parameters.AddWithValue("@PortalUserName", (object) oContact.PortalUserName);
      if ((uint) oContact.PortalPassword.Trim().Length > 0U)
        cmd.Parameters.AddWithValue("@PortalPassword", (object) oContact.PortalPassword);
      return FSM.Importer.Importer._Tdatabase.ExecuteScalarSPTrans(cmd);
    }

    public int Insert_Part(
      string Number,
      string Name,
      int CategoryID,
      int UnitTypeID,
      string Notes,
      double SellPrice)
    {
      SqlCommand storedProcedure = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("Part_Insert", this.Trans);
      storedProcedure.Parameters.Clear();
      storedProcedure.Parameters.AddWithValue("@Name", (object) Name);
      storedProcedure.Parameters.AddWithValue("@Number", (object) Number);
      storedProcedure.Parameters.AddWithValue("@Reference", (object) "");
      storedProcedure.Parameters.AddWithValue("@Notes", (object) Notes);
      storedProcedure.Parameters.AddWithValue("@unitTypeID", (object) UnitTypeID);
      storedProcedure.Parameters.AddWithValue("@sellPrice", (object) SellPrice);
      storedProcedure.Parameters.AddWithValue("@recommendedQuantity", (object) 0);
      storedProcedure.Parameters.AddWithValue("@minimumQuantity", (object) 0);
      storedProcedure.Parameters.AddWithValue("@CategoryID", (object) CategoryID);
      storedProcedure.Parameters.AddWithValue("@WarehouseID", (object) 0);
      storedProcedure.Parameters.AddWithValue("@ShelfID", (object) 0);
      storedProcedure.Parameters.AddWithValue("@BinID", (object) 0);
      storedProcedure.Parameters.AddWithValue("@WarehouseIDAlternative", (object) 0);
      storedProcedure.Parameters.AddWithValue("@ShelfIDAlternative", (object) 0);
      storedProcedure.Parameters.AddWithValue("@BinIDAlternative", (object) 0);
      storedProcedure.Parameters.AddWithValue("@EndFlagged", (object) false);
      storedProcedure.Parameters.AddWithValue("@Equipment", (object) false);
      return FSM.Importer.Importer._Tdatabase.ExecuteScalarSPTrans(storedProcedure);
    }

    public void Update_Part(Part oPart)
    {
      SqlCommand storedProcedure = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("Part_Update", this.Trans);
      storedProcedure.Parameters.Clear();
      storedProcedure.Parameters.AddWithValue("@PartID", (object) oPart.PartID);
      storedProcedure.Parameters.AddWithValue("@Name", (object) oPart.Name);
      storedProcedure.Parameters.AddWithValue("@Number", (object) oPart.Number);
      storedProcedure.Parameters.AddWithValue("@Reference", (object) oPart.Reference);
      storedProcedure.Parameters.AddWithValue("@Notes", (object) oPart.Notes);
      storedProcedure.Parameters.AddWithValue("@unitTypeID", (object) oPart.UnitTypeID);
      storedProcedure.Parameters.AddWithValue("@sellPrice", (object) oPart.SellPrice);
      storedProcedure.Parameters.AddWithValue("@recommendedQuantity", (object) oPart.RecommendedQuantity);
      storedProcedure.Parameters.AddWithValue("@minimumQuantity", (object) oPart.MinimumQuantity);
      storedProcedure.Parameters.AddWithValue("@CategoryID", (object) oPart.CategoryID);
      storedProcedure.Parameters.AddWithValue("@WarehouseID", (object) oPart.WarehouseID);
      storedProcedure.Parameters.AddWithValue("@ShelfID", (object) oPart.ShelfID);
      storedProcedure.Parameters.AddWithValue("@BinID", (object) oPart.BinID);
      storedProcedure.Parameters.AddWithValue("@WarehouseIDAlternative", (object) oPart.WarehouseIDAlternative);
      storedProcedure.Parameters.AddWithValue("@ShelfIDAlternative", (object) oPart.ShelfIDAlternative);
      storedProcedure.Parameters.AddWithValue("@BinIDAlternative", (object) oPart.BinIDAlternative);
      storedProcedure.Parameters.AddWithValue("@EndFlagged", (object) oPart.EndFlagged);
      storedProcedure.Parameters.AddWithValue("@Equipment", (object) oPart.Equipment);
      FSM.Importer.Importer._Tdatabase.ExecuteNonQuerySPTrans(storedProcedure);
    }

    public void Insert_Part_Supplier(
      int PartID,
      string Code,
      int SupplierID,
      double Price,
      int Quantity)
    {
      SqlCommand storedProcedure = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("PartSupplier_Insert", this.Trans);
      storedProcedure.Parameters.Clear();
      storedProcedure.Parameters.AddWithValue("@PartCode", (object) Code);
      storedProcedure.Parameters.AddWithValue("@PartID", (object) PartID);
      storedProcedure.Parameters.AddWithValue("@SupplierID", (object) SupplierID);
      storedProcedure.Parameters.AddWithValue("@Price", (object) Price);
      storedProcedure.Parameters.AddWithValue("@quantityInPack", (object) Quantity);
      storedProcedure.Parameters.AddWithValue("@UserID", (object) App.loggedInUser.UserID);
      FSM.Importer.Importer._Tdatabase.ExecuteNonQuerySPTrans(storedProcedure);
    }

    public void Update_Part_Supplier(PartSupplier oPartSupplier)
    {
      SqlCommand storedProcedure = FSM.Importer.Importer._Tdatabase.CreateStoredProcedure("PartSupplier_Update", this.Trans);
      storedProcedure.Parameters.Clear();
      storedProcedure.Parameters.AddWithValue("@PartSupplierID", (object) oPartSupplier.PartSupplierID);
      storedProcedure.Parameters.AddWithValue("@PartCode", (object) oPartSupplier.PartCode);
      storedProcedure.Parameters.AddWithValue("@PartID", (object) oPartSupplier.PartID);
      storedProcedure.Parameters.AddWithValue("@SupplierID", (object) oPartSupplier.SupplierID);
      storedProcedure.Parameters.AddWithValue("@Price", (object) oPartSupplier.Price);
      storedProcedure.Parameters.AddWithValue("@quantityInPack", (object) oPartSupplier.QuantityInPack);
      storedProcedure.Parameters.AddWithValue("@UserID", (object) App.loggedInUser.UserID);
      FSM.Importer.Importer._Tdatabase.ExecuteNonQuerySPTrans(storedProcedure);
    }
  }
}
