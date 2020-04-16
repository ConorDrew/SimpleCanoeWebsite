// Decompiled with JetBrains decompiler
// Type: FSM.Entity.QuoteOrderProducts.QuoteOrderProductSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.QuoteOrderProducts
{
  public class QuoteOrderProductSQL
  {
    private Database _database;

    public QuoteOrderProductSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int QuoteOrderProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteOrderProductID", (object) QuoteOrderProductID, true);
      this._database.ExecuteSP_NO_Return("QuoteOrderProduct_Delete", true);
    }

    public QuoteOrderProduct QuoteOrderProduct_Get(int QuoteOrderProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteOrderProductID", (object) QuoteOrderProductID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (QuoteOrderProduct_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (QuoteOrderProduct) null;
      QuoteOrderProduct quoteOrderProduct1 = new QuoteOrderProduct();
      QuoteOrderProduct quoteOrderProduct2 = quoteOrderProduct1;
      quoteOrderProduct2.IgnoreExceptionsOnSetMethods = true;
      quoteOrderProduct2.SetQuoteOrderProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (QuoteOrderProductID)]);
      quoteOrderProduct2.SetQuoteOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteOrderID"]);
      quoteOrderProduct2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ProductID"]);
      quoteOrderProduct2.SetPrice = (object) Helper.MakeDoubleValid((object) "Price");
      quoteOrderProduct2.SetQuantity = (object) Helper.MakeIntegerValid((object) "Quantity");
      quoteOrderProduct2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      quoteOrderProduct1.Exists = true;
      return quoteOrderProduct1;
    }

    public DataView QuoteOrderProduct_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (QuoteOrderProduct_GetAll), true);
      table.TableName = Enums.TableNames.tblQuoteOrderProduct.ToString();
      return new DataView(table);
    }

    public QuoteOrderProduct Insert(QuoteOrderProduct oQuoteOrderProduct)
    {
      this._database.ClearParameter();
      this.AddQuoteOrderProductParametersToCommand(ref oQuoteOrderProduct);
      oQuoteOrderProduct.SetQuoteOrderProductID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("QuoteOrderProduct_Insert", true)));
      oQuoteOrderProduct.Exists = true;
      return oQuoteOrderProduct;
    }

    public void Update(QuoteOrderProduct oQuoteOrderProduct)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteOrderProductID", (object) oQuoteOrderProduct.QuoteOrderProductID, true);
      this.AddQuoteOrderProductParametersToCommand(ref oQuoteOrderProduct);
      this._database.ExecuteSP_NO_Return("QuoteOrderProduct_Update", true);
    }

    public object QuoteOrderProduct_GetForQuoteOrder(int QuoteOrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteOrderID", (object) QuoteOrderID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (QuoteOrderProduct_GetForQuoteOrder), true);
      table.TableName = Enums.TableNames.tblProduct.ToString();
      return (object) new DataView(table);
    }

    private void AddQuoteOrderProductParametersToCommand(ref QuoteOrderProduct oQuoteOrderProduct)
    {
      Database database = this._database;
      database.AddParameter("@QuoteOrderID", (object) oQuoteOrderProduct.QuoteOrderID, true);
      database.AddParameter("@ProductID", (object) oQuoteOrderProduct.ProductID, true);
      database.AddParameter("@Price", (object) oQuoteOrderProduct.Price, true);
      database.AddParameter("@Quantity", (object) oQuoteOrderProduct.Quantity, true);
    }

    public void QuoteOrderProduct_DeleteForQuoteOrder(int QuoteOrderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteOrderID", (object) QuoteOrderID, true);
      this._database.ExecuteSP_NO_Return(nameof (QuoteOrderProduct_DeleteForQuoteOrder), true);
    }
  }
}
