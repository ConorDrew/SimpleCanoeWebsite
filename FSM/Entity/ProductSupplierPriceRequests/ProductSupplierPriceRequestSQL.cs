// Decompiled with JetBrains decompiler
// Type: FSM.Entity.ProductSupplierPriceRequests.ProductSupplierPriceRequestSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.ProductSupplierPriceRequests
{
  public class ProductSupplierPriceRequestSQL
  {
    private Database _database;

    public ProductSupplierPriceRequestSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int ProductSupplierPriceRequestID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductSupplierPriceRequestID", (object) ProductSupplierPriceRequestID, true);
      this._database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_Delete", true);
    }

    public void DeleteForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      this._database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_DeleteForOrder", true);
    }

    public ProductSupplierPriceRequest ProductSupplierPriceRequest_Get(
      int ProductSupplierPriceRequestID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductSupplierPriceRequestID", (object) ProductSupplierPriceRequestID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (ProductSupplierPriceRequest_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (ProductSupplierPriceRequest) null;
      ProductSupplierPriceRequest supplierPriceRequest1 = new ProductSupplierPriceRequest();
      ProductSupplierPriceRequest supplierPriceRequest2 = supplierPriceRequest1;
      supplierPriceRequest2.IgnoreExceptionsOnSetMethods = true;
      supplierPriceRequest2.SetProductSupplierPriceRequestID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ProductSupplierPriceRequestID)]);
      supplierPriceRequest2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
      supplierPriceRequest2.SetQuantityInPack = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuantityInPack"]);
      supplierPriceRequest2.SetComplete = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Complete"]);
      supplierPriceRequest2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductID"]);
      supplierPriceRequest2.SetSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierID"]);
      supplierPriceRequest2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      supplierPriceRequest1.Exists = true;
      return supplierPriceRequest1;
    }

    public object ProductSupplierPriceRequest_GetForOrder(int OrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (ProductSupplierPriceRequest_GetForOrder), true);
      table.TableName = Enums.TableNames.tblProduct.ToString();
      return (object) new DataView(table);
    }

    public DataView ProductSupplierPriceRequest_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (ProductSupplierPriceRequest_GetAll), true);
      table.TableName = Enums.TableNames.tblProductSupplierPriceRequest.ToString();
      return new DataView(table);
    }

    public ProductSupplierPriceRequest Insert(
      ProductSupplierPriceRequest oProductSupplierPriceRequest)
    {
      this._database.ClearParameter();
      this.AddProductSupplierPriceRequestParametersToCommand(ref oProductSupplierPriceRequest);
      this._database.AddParameter("@QuoteID", (object) oProductSupplierPriceRequest.QuoteID, true);
      this._database.AddParameter("@OrderID", (object) oProductSupplierPriceRequest.OrderID, true);
      oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ProductSupplierPriceRequest_Insert", true)));
      oProductSupplierPriceRequest.Exists = true;
      return oProductSupplierPriceRequest;
    }

    public ProductSupplierPriceRequest InsertForQuote(
      ProductSupplierPriceRequest oProductSupplierPriceRequest)
    {
      this._database.ClearParameter();
      this.AddProductSupplierPriceRequestParametersToCommand(ref oProductSupplierPriceRequest);
      this._database.AddParameter("@QuoteID", (object) oProductSupplierPriceRequest.QuoteID, true);
      oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("ProductSupplierPriceRequest_InsertForQuote", true)));
      oProductSupplierPriceRequest.Exists = true;
      return oProductSupplierPriceRequest;
    }

    public ProductSupplierPriceRequest InsertForOrder(
      ProductSupplierPriceRequest oProductSupplierPriceRequest)
    {
      this._database.ClearParameter();
      this.AddProductSupplierPriceRequestParametersToCommand(ref oProductSupplierPriceRequest);
      this._database.AddParameter("@OrderID", (object) oProductSupplierPriceRequest.OrderID, true);
      oProductSupplierPriceRequest.SetProductSupplierPriceRequestID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("PartSupplierPriceRequest_InsertForOrder", true)));
      oProductSupplierPriceRequest.Exists = true;
      return oProductSupplierPriceRequest;
    }

    public void Complete(int ProductSupplierPriceRequestID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductSupplierPriceRequestID", (object) ProductSupplierPriceRequestID, true);
      this._database.ExecuteSP_NO_Return("ProductSupplierPriceRequest_Complete", true);
    }

    private void AddProductSupplierPriceRequestParametersToCommand(
      ref ProductSupplierPriceRequest oProductSupplierPriceRequest)
    {
      Database database = this._database;
      database.AddParameter("@QuantityInPack", (object) oProductSupplierPriceRequest.QuantityInPack, true);
      database.AddParameter("@Complete", (object) oProductSupplierPriceRequest.Complete, true);
      database.AddParameter("@ProductID", (object) oProductSupplierPriceRequest.ProductID, true);
      database.AddParameter("@SupplierID", (object) oProductSupplierPriceRequest.SupplierID, true);
    }
  }
}
