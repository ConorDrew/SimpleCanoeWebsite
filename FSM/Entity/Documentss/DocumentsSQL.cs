// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Documentss.DocumentsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.FleetVans;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Documentss
{
  public class DocumentsSQL
  {
    private Database _database;

    public DocumentsSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int DocumentID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@DocumentID", (object) DocumentID, true);
      this._database.ExecuteSP_NO_Return("Documents_Delete", true);
    }

    public Documents Documents_Get(int DocumentID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@DocumentID", (object) DocumentID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Documents_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Documents) null;
      Documents documents1 = new Documents();
      Documents documents2 = documents1;
      documents2.IgnoreExceptionsOnSetMethods = true;
      documents2.SetDocumentID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (DocumentID)]);
      documents2.SetTableEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TableEnumID"]);
      documents2.SetRecordID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RecordID"]);
      documents2.SetDocumentTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DocumentTypeID"]);
      documents2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
      documents2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      documents2.SetLocation = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Location"]);
      documents2.AddedOn = Conversions.ToDate(dataTable.Rows[0]["AddedOn"]);
      documents2.SetAddedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddedByUserID"]);
      documents2.LastUpdatedOn = Conversions.ToDate(dataTable.Rows[0]["LastUpdatedOn"]);
      documents2.SetLastUpdatedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastUpdatedByUserID"]);
      documents2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      documents2.Type = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Type"]));
      documents2.AddedByUserName = Conversions.ToString(dataTable.Rows[0]["AddedByUserName"]);
      documents2.LastUpdatedByUserName = Conversions.ToString(dataTable.Rows[0]["LastUpdatedByUserName"]);
      documents1.Exists = true;
      return documents1;
    }

    public DataView Documents_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Documents_GetAll), true);
      table.TableName = Enums.TableNames.tblDocuments.ToString();
      return new DataView(table);
    }

    public DataView Documents_GetAll_For_Customer_ID(
      Enums.TableNames EntityToSearchBy,
      int RecordID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@TableEnumID", (object) (int) EntityToSearchBy, true);
      this._database.AddParameter("@RecordID", (object) RecordID, true);
      this._database.AddParameter("@SiteTableEnumID", (object) 24, true);
      this._database.AddParameter("@DomesticCustomerID", (object) Enums.Customer.Domestic, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Documents_GetAll_For_Customer_ID), true);
      table.TableName = Enums.TableNames.tblDocuments.ToString();
      return new DataView(table);
    }

    public DataView Documents_GetAll_For_Site_ID(
      Enums.TableNames EntityToSearchBy,
      int RecordID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@TableEnumID", (object) (int) EntityToSearchBy, true);
      this._database.AddParameter("@RecordID", (object) RecordID, true);
      this._database.AddParameter("@CustomerTableEnumID", (object) 12, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Documents_GetAll_For_Site_ID), true);
      table.TableName = Enums.TableNames.tblDocuments.ToString();
      return new DataView(table);
    }

    public DataView Documents_GetAll_For_Entity_ID(
      Enums.TableNames EntityToSearchBy,
      int RecordID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@TableEnumID", (object) (int) EntityToSearchBy, true);
      this._database.AddParameter("@RecordID", (object) RecordID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Documents_GetAll_For_Entity_ID), true);
      table.TableName = Enums.TableNames.tblDocuments.ToString();
      return new DataView(table);
    }

    public Documents Insert(Documents oDocuments, bool buildLocationAndSave = true)
    {
      string str1;
      string str2;
      if (oDocuments.TableEnumID == 150)
      {
        str1 = "Fleet\\";
        FleetVan fleetVan = App.DB.FleetVan.Get(oDocuments.RecordID);
        str2 = fleetVan == null ? Conversions.ToString(oDocuments.RecordID) + "\\" : fleetVan.Registration + "\\";
      }
      else
      {
        str1 = Conversions.ToString(oDocuments.TableEnumID) + "\\";
        str2 = Conversions.ToString(oDocuments.RecordID) + "\\";
      }
      this._database.ClearParameter();
      this._database.AddParameter("@TableEnumID", (object) oDocuments.TableEnumID, true);
      this._database.AddParameter("@RecordID", (object) oDocuments.RecordID, true);
      this._database.AddParameter("@DocumentTypeID", (object) oDocuments.DocumentTypeID, true);
      this._database.AddParameter("@Name", (object) oDocuments.Name, true);
      this._database.AddParameter("@Notes", (object) oDocuments.Notes, true);
      string str3 = "";
      if (buildLocationAndSave)
      {
        if (oDocuments.Location.Length > 0)
        {
          string path1 = App.TheSystem.Configuration.DocumentsLocation + str1;
          if (!Directory.Exists(path1))
            Directory.CreateDirectory(path1);
          string path2 = path1 + str2;
          if (!Directory.Exists(path2))
            Directory.CreateDirectory(path2);
          string fileName = Path.GetFileName(oDocuments.Location);
          string str4 = fileName.Replace(Path.GetFileNameWithoutExtension(fileName), Helper.RemoveSpecialCharacters(Path.GetFileNameWithoutExtension(fileName)));
          str3 = path2 + str4;
        }
        else
          str3 = "";
        this._database.AddParameter("@Location", (object) str3, true);
      }
      else
        this._database.AddParameter("@Location", (object) oDocuments.Location, true);
      this._database.AddParameter("@AddedByUserID", (object) App.loggedInUser.UserID, true);
      oDocuments.SetDocumentID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Documents_Insert", true)));
      oDocuments.Exists = true;
      if (buildLocationAndSave && str3.Length > 0)
      {
        if (File.Exists(str3))
          File.Delete(str3);
        File.Copy(oDocuments.Location, str3);
      }
      return oDocuments;
    }

    public DataView Documents_Search(string criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Criteria", (object) criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Documents_Search), true);
      table.TableName = Enums.TableNames.tblDocuments.ToString();
      return new DataView(table);
    }

    public void Update(Documents oDocuments)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@DocumentID", (object) oDocuments.DocumentID, true);
      this._database.AddParameter("@DocumentTypeID", (object) oDocuments.DocumentTypeID, true);
      this._database.AddParameter("@Name", (object) oDocuments.Name, true);
      this._database.AddParameter("@Notes", (object) oDocuments.Notes, true);
      this._database.AddParameter("@LastUpdatedByUserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return("Documents_Update", true);
    }

    public void Opened(int documentID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@DocumentID", (object) documentID, true);
      this._database.AddParameter("@LastUpdatedByUserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return("Documents_Opened", true);
    }

    public Documents Documents_Get_ByFilePath(string Location)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Location", (object) Location, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Documents_Get_ByFilePath), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Documents) null;
      Documents documents1 = new Documents();
      Documents documents2 = documents1;
      documents2.IgnoreExceptionsOnSetMethods = true;
      documents2.SetDocumentID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DocumentID"]);
      documents2.SetTableEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TableEnumID"]);
      documents2.SetRecordID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RecordID"]);
      documents2.SetDocumentTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DocumentTypeID"]);
      documents2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
      documents2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      documents2.SetLocation = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (Location)]);
      documents2.AddedOn = Conversions.ToDate(dataTable.Rows[0]["AddedOn"]);
      documents2.SetAddedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddedByUserID"]);
      documents2.LastUpdatedOn = Conversions.ToDate(dataTable.Rows[0]["LastUpdatedOn"]);
      documents2.SetLastUpdatedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LastUpdatedByUserID"]);
      documents2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      documents2.Type = Conversions.ToString(dataTable.Rows[0]["Type"]);
      documents2.AddedByUserName = Conversions.ToString(dataTable.Rows[0]["AddedByUserName"]);
      documents2.LastUpdatedByUserName = Conversions.ToString(dataTable.Rows[0]["LastUpdatedByUserName"]);
      documents1.Exists = true;
      return documents1;
    }
  }
}
