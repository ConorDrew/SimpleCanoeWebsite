// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Data;

namespace FSM.Entity.EngineerVisitsPartsAndProducts
{
  public class EngineerVisitPartsAndProductsSQL
  {
    private Database _database;

    public EngineerVisitPartsAndProductsSQL(Database database)
    {
      this._database = database;
    }

    public DataView EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(
      int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID2", true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      int count = table.Constraints.Count;
      return new DataView(table);
    }

    public DataView EngineerVisitPartsAndProductsNeeded_Get_For_EngineerVisitID(
      int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitPartsAndProductsNeeded_Get_For_EngineerVisitID), true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
      return new DataView(table);
    }

    public void PartsUsed_Delete(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Delete", true);
    }

    public void PartsUsed_Insert(
      EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) oEngineerVisitPartsAndProducts.EngineerVisitID, true);
      this._database.AddParameter("@PartID", (object) oEngineerVisitPartsAndProducts.PartOrProductID, true);
      this._database.AddParameter("@Quantity", (object) oEngineerVisitPartsAndProducts.Quantity, true);
      this._database.AddParameter("@AssetID", (object) oEngineerVisitPartsAndProducts.AssetID, true);
      this._database.AddParameter("@EngineerVisitPartAllocatedID", (object) oEngineerVisitPartsAndProducts.AllocatedID, true);
      this._database.AddParameter("@LocationID", (object) oEngineerVisitPartsAndProducts.LocationID, true);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(oEngineerVisitPartsAndProducts.SpecialDescription, "", false) != 0)
      {
        this._database.AddParameter("@SpecialPrice", (object) oEngineerVisitPartsAndProducts.SpecialPrice, true);
        this._database.AddParameter("@SpecialDescription", (object) oEngineerVisitPartsAndProducts.SpecialDescription, true);
        this._database.AddParameter("@SpecialPartNumber", (object) oEngineerVisitPartsAndProducts.SpecialPartNumber, true);
      }
      this._database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Insert", true);
    }

    public void ProductsUsed_Delete(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Delete", true);
    }

    public void ProductsUsed_Insert(
      EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) oEngineerVisitPartsAndProducts.EngineerVisitID, true);
      this._database.AddParameter("@ProductID", (object) oEngineerVisitPartsAndProducts.PartOrProductID, true);
      this._database.AddParameter("@Quantity", (object) oEngineerVisitPartsAndProducts.Quantity, true);
      this._database.AddParameter("@EngineerVisitProductAllocatedID", (object) oEngineerVisitPartsAndProducts.AllocatedID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Insert", true);
    }

    public void PartsNeeded_Delete(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitPartsNeeded_Delete", true);
    }

    public void PartsNeeded_Insert(
      EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) oEngineerVisitPartsAndProducts.EngineerVisitID, true);
      this._database.AddParameter("@PartID", (object) oEngineerVisitPartsAndProducts.PartOrProductID, true);
      this._database.AddParameter("@Quantity", (object) oEngineerVisitPartsAndProducts.Quantity, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitPartsNeeded_Insert", true);
    }

    public void ProductsNeeded_Delete(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitProductsNeeded_Delete", true);
    }

    public void ProductsNeeded_Insert(
      EngineerVisitPartsAndProducts oEngineerVisitPartsAndProducts)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) oEngineerVisitPartsAndProducts.EngineerVisitID, true);
      this._database.AddParameter("@ProductID", (object) oEngineerVisitPartsAndProducts.PartOrProductID, true);
      this._database.AddParameter("@Quantity", (object) oEngineerVisitPartsAndProducts.Quantity, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitProductsNeeded_Insert", true);
    }

    public DataView EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit(
      int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit), true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
      return new DataView(table);
    }

    public DataView EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution), true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
      return new DataView(table);
    }

    public DataView EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution2(int id)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartID", (object) id, true);
      DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3", true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
      return new DataView(table);
    }

    public DataView EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3(int id)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartID", (object) id, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3), true);
      table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString();
      return new DataView(table);
    }

    public DataView Parts_Used_Report(DateTime fromDate, DateTime toDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@fromDate", (object) fromDate, true);
      this._database.AddParameter("@toDate", (object) toDate, true);
      this._database.AddParameter("@OrderLocationSupplierEnumValue", (object) 1, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Parts_Used_Report), true);
      table.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table);
    }

    public DataView Equipment_Used_Report(DateTime fromDate, DateTime toDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@fromDate", (object) fromDate, true);
      this._database.AddParameter("@toDate", (object) toDate, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Equipment_Used_Report), true);
      table.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table);
    }

    public void PartsUsed_DeleteOne(int EngineerVisitPartsUsedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitPartsUsedID", (object) EngineerVisitPartsUsedID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Delete_One", true);
    }

    public void ProductsUsed_DeleteOne(int EngineerVisitProductsUsedID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitProductsUsedID", (object) EngineerVisitProductsUsedID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Delete_One", true);
    }

    public void ProductsUsed_Update(int EngineerVisitProductsUsedID, int Quantity)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitProductsUsedID", (object) EngineerVisitProductsUsedID, true);
      this._database.AddParameter("@Quantity", (object) Quantity, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_UpdateQty", true);
    }

    public void PartsUsed_Update(int EngineerVisitPartsUsedID, int Quantity)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitPartsUsedID", (object) EngineerVisitPartsUsedID, true);
      this._database.AddParameter("@Quantity", (object) Quantity, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_UpdateQty", true);
    }

    public DataView Get_CurrentCost_ByJobID(int jobId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) jobId, true);
      return new DataView(this._database.ExecuteSP_DataTable("EngineerVisitParts_Get_CurrentCost_ByJobID", true));
    }
  }
}
