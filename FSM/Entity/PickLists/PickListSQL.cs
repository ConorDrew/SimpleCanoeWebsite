// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PickLists.PickListSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PickLists
{
  public class PickListSQL
  {
    private Database _database;

    public PickListSQL(Database databaseIn)
    {
      this._database = databaseIn;
    }

    public DataView PickListTypes()
    {
      DataTable table = new DataTable();
      table.Columns.Add(new DataColumn("ValueMember"));
      table.Columns.Add(new DataColumn("DisplayMember"));
      table.Columns.Add(new DataColumn("Deleted"));
      DataRow row1 = table.NewRow();
      row1["ValueMember"] = (object) 3;
      row1["DisplayMember"] = (object) "Regions";
      row1["Deleted"] = (object) false;
      table.Rows.Add(row1);
      DataRow row2 = table.NewRow();
      row2["ValueMember"] = (object) 14;
      row2["DisplayMember"] = (object) "Customer Types";
      row2["Deleted"] = (object) false;
      table.Rows.Add(row2);
      DataRow row3 = table.NewRow();
      row3["ValueMember"] = (object) 11;
      row3["DisplayMember"] = (object) "Job Types";
      row3["Deleted"] = (object) false;
      table.Rows.Add(row3);
      DataRow row4 = table.NewRow();
      row4["ValueMember"] = (object) 4;
      row4["DisplayMember"] = (object) "Product Types";
      row4["Deleted"] = (object) false;
      table.Rows.Add(row4);
      DataRow row5 = table.NewRow();
      row5["ValueMember"] = (object) 5;
      row5["DisplayMember"] = (object) "Product Makes";
      row5["Deleted"] = (object) false;
      table.Rows.Add(row5);
      DataRow row6 = table.NewRow();
      row6["ValueMember"] = (object) 6;
      row6["DisplayMember"] = (object) "Product Models";
      row6["Deleted"] = (object) false;
      table.Rows.Add(row6);
      DataRow row7 = table.NewRow();
      row7["ValueMember"] = (object) 21;
      row7["DisplayMember"] = (object) "Part Categories";
      row7["Deleted"] = (object) false;
      table.Rows.Add(row7);
      DataRow row8 = table.NewRow();
      row8["ValueMember"] = (object) 9;
      row8["DisplayMember"] = (object) "Unit Types";
      row8["Deleted"] = (object) false;
      table.Rows.Add(row8);
      DataRow row9 = table.NewRow();
      row9["ValueMember"] = (object) 15;
      row9["DisplayMember"] = (object) "Charge Types";
      row9["Deleted"] = (object) false;
      table.Rows.Add(row9);
      DataRow row10 = table.NewRow();
      row10["ValueMember"] = (object) 7;
      row10["DisplayMember"] = (object) "Engineer Levels/Qualifications";
      row10["Deleted"] = (object) false;
      table.Rows.Add(row10);
      DataRow row11 = table.NewRow();
      row11["ValueMember"] = (object) 36;
      row11["DisplayMember"] = (object) "Engineer Groups";
      row11["Deleted"] = (object) false;
      table.Rows.Add(row11);
      DataRow row12 = table.NewRow();
      row12["ValueMember"] = (object) 16;
      row12["DisplayMember"] = (object) "Note Categories";
      row12["Deleted"] = (object) false;
      table.Rows.Add(row12);
      DataRow row13 = table.NewRow();
      row13["ValueMember"] = (object) 8;
      row13["DisplayMember"] = (object) "Document Types";
      row13["Deleted"] = (object) false;
      table.Rows.Add(row13);
      DataRow row14 = table.NewRow();
      row14["ValueMember"] = (object) 13;
      row14["DisplayMember"] = (object) "Rejection Reasons";
      row14["Deleted"] = (object) false;
      table.Rows.Add(row14);
      DataRow row15 = table.NewRow();
      row15["ValueMember"] = (object) 17;
      row15["DisplayMember"] = (object) "Timesheet Types";
      row15["Deleted"] = (object) false;
      table.Rows.Add(row15);
      DataRow row16 = table.NewRow();
      row16["ValueMember"] = (object) 18;
      row16["DisplayMember"] = (object) "Scheduled Rates Categories";
      row16["Deleted"] = (object) false;
      table.Rows.Add(row16);
      DataRow row17 = table.NewRow();
      row17["ValueMember"] = (object) 22;
      row17["DisplayMember"] = (object) "Pay Grades";
      row17["Deleted"] = (object) false;
      table.Rows.Add(row17);
      DataRow row18 = table.NewRow();
      row18["ValueMember"] = (object) 23;
      row18["DisplayMember"] = (object) "Disciplinary Statuses";
      row18["Deleted"] = (object) false;
      table.Rows.Add(row18);
      DataRow row19 = table.NewRow();
      row19["ValueMember"] = (object) 40;
      row19["DisplayMember"] = (object) "Part Shelf References";
      row19["Deleted"] = (object) false;
      table.Rows.Add(row19);
      DataRow row20 = table.NewRow();
      row20["ValueMember"] = (object) 34;
      row20["DisplayMember"] = (object) "Part Bin References";
      row20["Deleted"] = (object) false;
      table.Rows.Add(row20);
      DataRow row21 = table.NewRow();
      row21["ValueMember"] = (object) 37;
      row21["DisplayMember"] = (object) "Source Of Customer";
      row21["Deleted"] = (object) false;
      table.Rows.Add(row21);
      DataRow row22 = table.NewRow();
      row22["ValueMember"] = (object) 41;
      row22["DisplayMember"] = (object) "VAT Codes";
      row22["Deleted"] = (object) false;
      table.Rows.Add(row22);
      DataRow row23 = table.NewRow();
      row23["ValueMember"] = (object) 24;
      row23["DisplayMember"] = (object) "Contract Types";
      row23["Deleted"] = (object) false;
      table.Rows.Add(row23);
      DataRow row24 = table.NewRow();
      row24["ValueMember"] = (object) 42;
      row24["DisplayMember"] = (object) "Reasons For Contact";
      row24["Deleted"] = (object) false;
      table.Rows.Add(row24);
      DataRow row25 = table.NewRow();
      row25["ValueMember"] = (object) 45;
      row25["DisplayMember"] = (object) "Job Of Work Priorities";
      row25["Deleted"] = (object) false;
      table.Rows.Add(row25);
      DataRow row26 = table.NewRow();
      row26["ValueMember"] = (object) 46;
      row26["DisplayMember"] = (object) "Heating System Types";
      row26["Deleted"] = (object) false;
      table.Rows.Add(row26);
      DataRow row27 = table.NewRow();
      row27["ValueMember"] = (object) 47;
      row27["DisplayMember"] = (object) "Cylinder Types";
      row27["Deleted"] = (object) false;
      table.Rows.Add(row27);
      DataRow row28 = table.NewRow();
      row28["ValueMember"] = (object) 48;
      row28["DisplayMember"] = (object) "Jackets";
      row28["Deleted"] = (object) false;
      table.Rows.Add(row28);
      DataRow row29 = table.NewRow();
      row29["ValueMember"] = (object) 49;
      row29["DisplayMember"] = (object) "Certificate Types";
      row29["Deleted"] = (object) false;
      table.Rows.Add(row29);
      DataRow row30 = table.NewRow();
      row30["ValueMember"] = (object) 50;
      row30["DisplayMember"] = (object) "Cancellation Reasons";
      row30["Deleted"] = (object) false;
      table.Rows.Add(row30);
      DataRow row31 = table.NewRow();
      row31["ValueMember"] = (object) 52;
      row31["DisplayMember"] = (object) "Renewal Prices";
      row31["Deleted"] = (object) false;
      table.Rows.Add(row31);
      DataRow row32 = table.NewRow();
      row32["ValueMember"] = (object) 57;
      row32["DisplayMember"] = (object) "FTFCodes";
      row32["Deleted"] = (object) false;
      table.Rows.Add(row32);
      DataRow row33 = table.NewRow();
      row33["ValueMember"] = (object) 60;
      row33["DisplayMember"] = (object) "CoverPlan Discounts";
      row33["Deleted"] = (object) false;
      table.Rows.Add(row33);
      DataRow row34 = table.NewRow();
      row34["ValueMember"] = (object) 105;
      row34["DisplayMember"] = (object) "Equipment Types";
      row34["Deleted"] = (object) false;
      table.Rows.Add(row34);
      DataRow row35 = table.NewRow();
      row35["ValueMember"] = (object) 106;
      row35["DisplayMember"] = (object) "Equipment Status";
      row35["Deleted"] = (object) false;
      table.Rows.Add(row35);
      DataRow row36 = table.NewRow();
      row36["ValueMember"] = (object) 110;
      row36["DisplayMember"] = (object) "Sales Nominal For Region";
      row36["Deleted"] = (object) false;
      table.Rows.Add(row36);
      DataRow row37 = table.NewRow();
      row37["ValueMember"] = (object) 111;
      row37["DisplayMember"] = (object) "Purchase Nominal For Region";
      row37["Deleted"] = (object) false;
      table.Rows.Add(row37);
      DataRow row38 = table.NewRow();
      row38["ValueMember"] = (object) 113;
      row38["DisplayMember"] = (object) "Departments";
      row38["Deleted"] = (object) false;
      table.Rows.Add(row38);
      DataRow row39 = table.NewRow();
      row39["ValueMember"] = (object) 65;
      row39["DisplayMember"] = (object) "Invoice Terms";
      row39["Deleted"] = (object) false;
      table.Rows.Add(row39);
      DataRow row40 = table.NewRow();
      row40["ValueMember"] = (object) 71;
      row40["DisplayMember"] = (object) "Price List";
      row40["Deleted"] = (object) false;
      table.Rows.Add(row40);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLPickListTypes.ToString();
      return new DataView(table);
    }

    public DataView PickListTypesLimited()
    {
      DataTable table = new DataTable();
      table.Columns.Add(new DataColumn("ValueMember"));
      table.Columns.Add(new DataColumn("DisplayMember"));
      table.Columns.Add(new DataColumn("Deleted"));
      DataRow row1 = table.NewRow();
      row1["ValueMember"] = (object) 4;
      row1["DisplayMember"] = (object) "Product Types";
      row1["Deleted"] = (object) false;
      table.Rows.Add(row1);
      DataRow row2 = table.NewRow();
      row2["ValueMember"] = (object) 5;
      row2["DisplayMember"] = (object) "Product Makes";
      row2["Deleted"] = (object) false;
      table.Rows.Add(row2);
      DataRow row3 = table.NewRow();
      row3["ValueMember"] = (object) 6;
      row3["DisplayMember"] = (object) "Product Models";
      row3["Deleted"] = (object) false;
      table.Rows.Add(row3);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLPickListTypes.ToString();
      return new DataView(table);
    }

    public DataView GetAll(Enums.PickListTypes enumTypeID, bool async = false)
    {
      DataTable table;
      if (async)
      {
        table = this._database.ExecuteSP_DataTable("Picklists_GetAll_ForEnumType", new SqlParameter("@EnumTypeId", (object) (int) enumTypeID));
      }
      else
      {
        this._database.ClearParameter();
        this._database.AddParameter("?EnumTypeID", (object) (int) enumTypeID, false);
        table = this._database.ExecuteCommand_DataTable("Picklists_Get.sql", true);
      }
      table.TableName = Enums.TableNames.tblPickLists.ToString();
      return new DataView(table);
    }

    public DataView GetAllPartMappings(Enums.PickListTypes enumTypeID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?EnumTypeID", (object) (int) enumTypeID, false);
      DataTable table = this._database.ExecuteCommand_DataTable("Picklists_Get_PartMapping.sql", true);
      table.TableName = Enums.TableNames.tblPartCategoryMapping.ToString();
      return new DataView(table);
    }

    public PickList Get_One_As_Object(int ManagerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?ManagerID", (object) ManagerID, false);
      DataTable dataTable = this._database.ExecuteCommand_DataTable("Picklists_GetOne.sql", true);
      if (dataTable.Rows.Count <= 0)
        return new PickList();
      PickList pickList = new PickList();
      pickList.SetManagerID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ManagerID)]));
      pickList.SetEnumTypeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EnumTypeID"]));
      pickList.SetName = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]));
      pickList.SetDescription = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]));
      pickList.SetDeleted = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Deleted"]));
      pickList.SetPercentageRate = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PercentageRate"]));
      if (dataTable.Columns.Contains("Mandatory"))
        pickList.SetMandatory = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Mandatory"]));
      return pickList;
    }

    public int Insert(PickList pickList)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?EnumTypeID", (object) pickList.EnumTypeID, false);
      this._database.AddParameter("?Name", (object) pickList.Name, false);
      this._database.AddParameter("?Description", (object) pickList.Description, false);
      this._database.AddParameter("?Mandatory", (object) pickList.Mandatory, false);
      switch (pickList.EnumTypeID)
      {
        case 7:
          this._database.AddParameter("?PercentageRate", (object) pickList.PercentageRate, false);
          break;
        case 21:
        case 41:
        case 60:
          this._database.AddParameter("?PercentageRate", (object) pickList.PercentageRate, false);
          break;
        default:
          this._database.AddParameter("?PercentageRate", (object) 0, false);
          break;
      }
      return Conversions.ToInteger(this._database.ExecuteCommand_Object("Picklists_Insert.sql", true));
    }

    public int InsertPartCategory(int ManagerID, string PartMapMatch)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?ManagerID", (object) ManagerID, false);
      this._database.AddParameter("?PartMapMatch", (object) PartMapMatch, false);
      return Conversions.ToInteger(this._database.ExecuteCommand_Object("Picklists_InsertPartMapping.sql", true));
    }

    public void Update(PickList pickList)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?Name", (object) pickList.Name, false);
      this._database.AddParameter("?Description", (object) pickList.Description, false);
      this._database.AddParameter("?Mandatory", (object) pickList.Mandatory, false);
      this._database.AddParameter("?ManagerID", (object) pickList.ManagerID, false);
      switch (pickList.EnumTypeID)
      {
        case 7:
          this._database.AddParameter("?PercentageRate", (object) pickList.PercentageRate, false);
          break;
        case 21:
        case 41:
        case 60:
          this._database.AddParameter("?PercentageRate", (object) pickList.PercentageRate, false);
          break;
        default:
          this._database.AddParameter("?PercentageRate", (object) 0, false);
          break;
      }
      this._database.ExecuteCommand_NO_Return("Picklists_Update.sql", true);
    }

    public void UpdatePartMapping(int PartMapID, int ManagerID, string PartMapMatch)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?PartMapID", (object) PartMapID, false);
      this._database.AddParameter("?ManagerID", (object) ManagerID, false);
      this._database.AddParameter("?PartMapMatch", (object) PartMapMatch, false);
      this._database.ExecuteCommand_NO_Return("Picklists_UpdatePartMapping.sql", true);
    }

    public void UpdateSellPrices(PickList pickList)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CategoryID", (object) pickList.ManagerID, false);
      this._database.ExecuteSP_NO_Return("Picklists_UpdatePartsMargins", true);
    }

    public void UpdateSellPricesByPart(int CategoryID, int PartID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@CategoryID", (object) CategoryID, false);
      this._database.AddParameter("@PartID", (object) PartID, false);
      this._database.ExecuteSP_NO_Return("Picklists_UpdatePartsMarginsByPart", true);
    }

    public void Delete(int ManagerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?ManagerID", (object) ManagerID, false);
      this._database.ExecuteCommand_NO_Return("Picklists_Delete.sql", true);
    }

    public void DeletePartMapping(int PartMapID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("?PartMapID", (object) PartMapID, false);
      this._database.ExecuteCommand_NO_Return("Picklists_DeletePartMapping.sql", true);
    }

    public DataView Region_Usage(int RegionID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@RegionID", (object) RegionID, false);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Region_Usage), true);
      table.TableName = Enums.TableNames.tblRegion.ToString();
      return new DataView(table);
    }

    public bool Check_Unique_Name(string Name, int ID, Enums.PickListTypes type)
    {
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(ManagerID) as 'NumberOfRows' FROM tblpicklists WHERE EnumTypeID = " + Conversions.ToString((int) type) + " AND Name = '" + Name + "' AND ManagerID <> " + Conversions.ToString(ID), false, false))) == 0;
    }

    public string Get_Single_Description(string Name, Enums.PickListTypes type)
    {
      return Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT Description FROM tblpicklists WHERE EnumTypeID = " + Conversions.ToString((int) type) + " AND Name = '" + Name + "'", false, false)));
    }
  }
}
