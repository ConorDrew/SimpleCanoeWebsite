// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartSupplierPriceRequests.PartSupplierPriceRequestSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PartSupplierPriceRequests
{
  public class PartSupplierPriceRequestSQL
  {
    private Database _database;

    public PartSupplierPriceRequestSQL(Database database)
    {
      this._database = database;
    }

    public void DeleteForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("PartSupplierPriceRequest_DeleteForOrder", true);
    }

    public void Delete(int PartSupplierPriceRequestID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartSupplierPriceRequestID", (object) PartSupplierPriceRequestID, true);
      this._database.ExecuteSP_NO_Return("PartSupplierPriceRequest_Delete", true);
    }

    public PartSupplierPriceRequest PartSupplierPriceRequest_Get(
      int PartSupplierPriceRequestID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartSupplierPriceRequestID", (object) PartSupplierPriceRequestID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (PartSupplierPriceRequest_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (PartSupplierPriceRequest) null;
      PartSupplierPriceRequest supplierPriceRequest1 = new PartSupplierPriceRequest();
      PartSupplierPriceRequest supplierPriceRequest2 = supplierPriceRequest1;
      supplierPriceRequest2.IgnoreExceptionsOnSetMethods = true;
      supplierPriceRequest2.SetPartSupplierPriceRequestID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (PartSupplierPriceRequestID)]);
      supplierPriceRequest2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
      supplierPriceRequest2.SetSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierID"]);
      supplierPriceRequest2.SetPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartID"]);
      supplierPriceRequest2.SetQuantityInPack = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuantityInPack"]);
      supplierPriceRequest2.SetComplete = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Complete"]);
      supplierPriceRequest2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      supplierPriceRequest1.Exists = true;
      return supplierPriceRequest1;
    }

    public DataView PartSupplierPriceRequest_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (PartSupplierPriceRequest_GetForOrder), true);
      table.TableName = Enums.TableNames.tblPart.ToString();
      return new DataView(table);
    }

    public DataView PartSupplierPriceRequest_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (PartSupplierPriceRequest_GetAll), true);
      table.TableName = Enums.TableNames.tblPartSupplierPriceRequest.ToString();
      return new DataView(table);
    }

    public PartSupplierPriceRequest Insert(
      PartSupplierPriceRequest oPartSupplierPriceRequest)
    {
      this._database.ClearParameter();
      this.AddPartSupplierPriceRequestParametersToCommand(ref oPartSupplierPriceRequest);
      this._database.AddParameter("@QuoteID", (object) oPartSupplierPriceRequest.QuoteID, true);
      this._database.AddParameter("@OrderID", (object) oPartSupplierPriceRequest.OrderID, true);
      oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("PartSupplierPriceRequest_Insert", true)));
      oPartSupplierPriceRequest.Exists = true;
      return oPartSupplierPriceRequest;
    }

    public PartSupplierPriceRequest InsertForQuote(
      PartSupplierPriceRequest oPartSupplierPriceRequest)
    {
      this._database.ClearParameter();
      this.AddPartSupplierPriceRequestParametersToCommand(ref oPartSupplierPriceRequest);
      this._database.AddParameter("@QuoteID", (object) oPartSupplierPriceRequest.QuoteID, true);
      oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForQuote", true)));
      oPartSupplierPriceRequest.Exists = true;
      return oPartSupplierPriceRequest;
    }

    public PartSupplierPriceRequest InsertForOrder(
      PartSupplierPriceRequest oPartSupplierPriceRequest)
    {
      this._database.ClearParameter();
      this.AddPartSupplierPriceRequestParametersToCommand(ref oPartSupplierPriceRequest);
      this._database.AddParameter("@OrderID", (object) oPartSupplierPriceRequest.OrderID, true);
      oPartSupplierPriceRequest.SetPartSupplierPriceRequestID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForOrder", true)));
      oPartSupplierPriceRequest.Exists = true;
      return oPartSupplierPriceRequest;
    }

    public void Complete(int PartSupplierPriceRequestID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartSupplierPriceRequestID", (object) PartSupplierPriceRequestID, true);
      this._database.ExecuteSP_NO_Return("PartSupplierPriceRequest_Complete", true);
    }

    private void AddPartSupplierPriceRequestParametersToCommand(
      ref PartSupplierPriceRequest oPartSupplierPriceRequest)
    {
      Database database = this._database;
      database.AddParameter("@SupplierID", (object) oPartSupplierPriceRequest.SupplierID, true);
      database.AddParameter("@PartID", (object) oPartSupplierPriceRequest.PartID, true);
      database.AddParameter("@QuantityInPack", (object) oPartSupplierPriceRequest.QuantityInPack, true);
      database.AddParameter("@Complete", (object) oPartSupplierPriceRequest.Complete, true);
    }
  }
}
