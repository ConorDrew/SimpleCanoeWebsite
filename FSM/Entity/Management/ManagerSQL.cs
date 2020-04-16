// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Management.ManagerSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Management
{
  public class ManagerSQL
  {
    private Database _database;

    public ManagerSQL(Database databaseIn)
    {
      this._database = databaseIn;
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteWithReturn(Helper.GetTextResource("Settings_Get.sql"), false);
      table.TableName = Enums.TableNames.tblSettings.ToString();
      return new DataView(table);
    }

    public Settings Get()
    {
      Settings settings = new Settings();
      DataView all = this.GetAll();
      if (all.Table.Rows.Count > 0)
      {
        DataRow row = all.Table.Rows[0];
        settings.SetWorkingHoursStart = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["WorkingHoursStart"]));
        settings.SetWorkingHoursEnd = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["WorkingHoursEnd"]));
        settings.SetOverridePassword = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["OverridePassword"]));
        settings.SetOverridePassword_Service = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["OverridePassword_Service"]));
        settings.SetMileageRate = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["MileageRate"]));
        settings.SetPartsMarkup = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["PartsMarkup"]));
        settings.SetRatesMarkup = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["RatesMarkup"]));
        settings.SetCalloutPrefix = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["CalloutPrefix"]));
        settings.SetMiscPrefix = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["MiscPrefix"]));
        settings.SetPPMPrefix = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["PPMPrefix"]));
        settings.SetQuotePrefix = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["QuotePrefix"]));
        settings.SetTimeSlot = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["TimeSlot"]));
        settings.SetInvoicePrefix = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["InvoicePrefix"]));
        settings.SetRecallVariable = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["RecallVariable"]));
        settings.SetPartsImportMarkup = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(row["PartsImportMarkup"]));
        settings.SetServiceFromLetterPrefix = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["ServiceFromLetterPrefix"]));
        settings.Exists = true;
      }
      return settings;
    }

    public void UpdateSettings(Settings settings)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?WorkingHoursStart", (object) settings.WorkingHoursStart, false);
      this._database.AddParameter("?WorkingHoursEnd", (object) settings.WorkingHoursEnd, false);
      this._database.AddParameter("?MileageRate", (object) settings.MileageRate, false);
      this._database.AddParameter("?PartsMarkup", (object) settings.PartsMarkup, false);
      this._database.AddParameter("?RatesMarkup", (object) settings.RatesMarkup, false);
      this._database.AddParameter("?CalloutPrefix", (object) settings.CalloutPrefix, false);
      this._database.AddParameter("?MiscPrefix", (object) settings.MiscPrefix, false);
      this._database.AddParameter("?PPMPrefix", (object) settings.PPMPrefix, false);
      this._database.AddParameter("?QuotePrefix", (object) settings.QuotePrefix, false);
      this._database.AddParameter("?TimeSlot", (object) settings.TimeSlot, false);
      this._database.AddParameter("?InvoicePrefix", (object) settings.InvoicePrefix, false);
      this._database.AddParameter("?RecallVariable", (object) settings.RecallVariable, false);
      this._database.AddParameter("?PartsImportMarkup", (object) settings.PartsImportMarkup, false);
      this._database.AddParameter("?ServiceFromLetterPrefix", (object) settings.ServiceFromLetterPrefix, false);
      this._database.ExecuteCommand_NO_Return("Settings_Update.sql", true);
    }

    public void UpdateOverridePassword(string Password)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?Password", (object) Helper.HashPassword(Password), false);
      this._database.ExecuteCommand_NO_Return("Settings_UpdateOverridePassword.sql", true);
    }

    public void UpdateOverridePassword_Service(string Password)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?Password", (object) Helper.HashPassword(Password), false);
      this._database.ExecuteCommand_NO_Return("Settings_UpdateOverridePassword_Service.sql", true);
    }

    public DataView GetHistory(int LimitNumber)
    {
      string textResource = Helper.GetTextResource("History_Get.sql");
      DataTable table = this._database.ExecuteWithReturn((uint) LimitNumber <= 0U ? string.Format(textResource, (object) "") : string.Format(textResource, (object) (" TOP " + Conversions.ToString(LimitNumber))), true);
      table.TableName = Enums.TableNames.tblHistory.ToString();
      return new DataView(table);
    }

    public void DeleteHistory()
    {
      this._database.ExecuteWithOutReturn(Helper.GetTextResource("History_Delete.sql"), true);
    }

    public DataView Get_Tables()
    {
      DataTable table = new DataTable();
      table.Columns.Add(new DataColumn("TableEnumID"));
      table.Columns.Add(new DataColumn("TableName"));
      table.Columns.Add(new DataColumn("Deleted", Type.GetType("System.Boolean")));
      DataRow row1 = table.NewRow();
      row1["TableEnumID"] = (object) 12;
      row1["TableName"] = (object) "Customers";
      row1["Deleted"] = (object) false;
      table.Rows.Add(row1);
      DataRow row2 = table.NewRow();
      row2["TableEnumID"] = (object) 24;
      row2["TableName"] = (object) "Sites";
      row2["Deleted"] = (object) false;
      table.Rows.Add(row2);
      DataRow row3 = table.NewRow();
      row3["TableEnumID"] = (object) 15;
      row3["TableName"] = (object) "Suppliers";
      row3["Deleted"] = (object) false;
      table.Rows.Add(row3);
      DataRow row4 = table.NewRow();
      row4["TableEnumID"] = (object) 13;
      row4["TableName"] = (object) "Parts";
      row4["Deleted"] = (object) false;
      table.Rows.Add(row4);
      DataRow row5 = table.NewRow();
      row5["TableEnumID"] = (object) 14;
      row5["TableName"] = (object) "Products";
      row5["Deleted"] = (object) false;
      table.Rows.Add(row5);
      DataRow row6 = table.NewRow();
      row6["TableEnumID"] = (object) 16;
      row6["TableName"] = (object) "Assets";
      row6["Deleted"] = (object) false;
      table.Rows.Add(row6);
      DataRow row7 = table.NewRow();
      row7["TableEnumID"] = (object) 20;
      row7["TableName"] = (object) "Types";
      row7["Deleted"] = (object) false;
      table.Rows.Add(row7);
      DataRow row8 = table.NewRow();
      row8["TableEnumID"] = (object) 18;
      row8["TableName"] = (object) "Makes";
      row8["Deleted"] = (object) false;
      table.Rows.Add(row8);
      DataRow row9 = table.NewRow();
      row9["TableEnumID"] = (object) 19;
      row9["TableName"] = (object) "Models";
      row9["Deleted"] = (object) false;
      table.Rows.Add(row9);
      DataRow row10 = table.NewRow();
      row10["TableEnumID"] = (object) 59;
      row10["TableName"] = (object) "Locations";
      row10["Deleted"] = (object) false;
      table.Rows.Add(row10);
      DataRow row11 = table.NewRow();
      row11["TableEnumID"] = (object) 17;
      row11["TableName"] = (object) "Engineers";
      row11["Deleted"] = (object) false;
      table.Rows.Add(row11);
      DataRow row12 = table.NewRow();
      row12["TableEnumID"] = (object) 3;
      row12["TableName"] = (object) "System History";
      row12["Deleted"] = (object) false;
      table.Rows.Add(row12);
      return new DataView(table);
    }

    public DataView Record_Summary(DateTime fromDate, DateTime toDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@FromDate", (object) Strings.Format((object) fromDate, "dd-MMMM-yyyy 00:00:00"), true);
      this._database.AddParameter("@ToDate", (object) Strings.Format((object) toDate, "dd-MMMM-yyyy 23:59:59"), true);
      DataTable table = this._database.ExecuteSP_DataTable("Report_Record_Summary", true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
      return new DataView(table);
    }
  }
}
