// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Products.ProductSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ProductAssociatedParts;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Products
{
  public class ProductSQL
  {
    private Database _database;

    public ProductSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int ProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductID", (object) ProductID, true);
      this._database.ExecuteSP_NO_Return("Product_Delete", true);
    }

    public Product Product_Get(int ProductID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Product_Get);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@ProductID", (object) ProductID);
      new SqlDataAdapter(selectCommand).Fill(new DataSet());
      DataTable dataTable = this._database.ExecuteSP_DataTable("", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Product) null;
      Product product1 = new Product();
      Product product2 = product1;
      product2.IgnoreExceptionsOnSetMethods = true;
      product2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ProductID)]);
      product2.SetNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Number"]);
      product2.SetReference = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Reference"]));
      product2.SetTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TypeID"]);
      product2.SetMakeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MakeID"]);
      product2.SetModelID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ModelID"]);
      product2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      product2.SetSellPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SellPrice"]);
      product2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
      product2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      product2.SetMinimumQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MinimumQuantity"]);
      product2.SetRecommendedQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RecommendedQuantity"]);
      product2.AssociatedPart = App.DB.ProductAssociatedPart.GetAll_For_ProductID(ProductID);
      product1.Exists = true;
      return product1;
    }

    public Product Product_Get(int ProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductID", (object) ProductID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Product_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Product) null;
      Product product1 = new Product();
      Product product2 = product1;
      product2.IgnoreExceptionsOnSetMethods = true;
      product2.SetProductID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (ProductID)]);
      product2.SetNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Number"]);
      product2.SetReference = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Reference"]));
      product2.SetTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TypeID"]);
      product2.SetMakeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MakeID"]);
      product2.SetModelID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ModelID"]);
      product2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      product2.SetSellPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SellPrice"]);
      product2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
      product2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      product2.SetMinimumQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MinimumQuantity"]);
      product2.SetRecommendedQuantity = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RecommendedQuantity"]);
      product2.AssociatedPart = App.DB.ProductAssociatedPart.GetAll_For_ProductID(ProductID);
      product1.Exists = true;
      return product1;
    }

    public bool Check_Unique_Number(string Number, int ID)
    {
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(ProductID) as 'NumberOfProducts' FROM tblproduct WHERE deleted =0 AND Number = '" + Number + "' AND ProductID <> " + Conversions.ToString(ID), false, false))) == 0;
    }

    public DataView Product_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Product_GetAll), true);
      table.TableName = Enums.TableNames.tblProduct.ToString();
      return new DataView(table);
    }

    public DataView Product_GetAll(SqlTransaction trans)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
      {
        CommandText = nameof (Product_GetAll),
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection
      });
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblProduct.ToString();
      return new DataView(table);
    }

    public DataView Product_Search(string criteria, string SearchOnField)
    {
      if (SearchOnField.Trim().Length > 0)
        criteria = "'%" + criteria + "%'";
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) criteria, true);
      this._database.AddParameter("@SearchOnField", (object) SearchOnField, true);
      DataTable table = this._database.ExecuteSP_DataTable("Product_SearchList", true);
      table.TableName = Enums.TableNames.tblProduct.ToString();
      return new DataView(table);
    }

    public int Product_Check_Stock_Level(int ProductID, int LocationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductID", (object) ProductID, true);
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof (Product_Check_Stock_Level), true)));
    }

    public int Product_Check_Stock_Level(int ProductID, int LocationID, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = nameof (Product_Check_Stock_Level);
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@ProductID", (object) ProductID);
      sqlCommand.Parameters.AddWithValue("@LocationID", (object) LocationID);
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
    }

    public Product Insert(Product oProduct)
    {
      this._database.ClearParameter();
      this.AddProductParametersToCommand(ref oProduct);
      oProduct.SetProductID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Product_Insert", true)));
      oProduct.Exists = true;
      this.InsertAssociatedParts(oProduct);
      return oProduct;
    }

    public void Update(Product oProduct)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@ProductID", (object) oProduct.ProductID, true);
      this.AddProductParametersToCommand(ref oProduct);
      this._database.ExecuteSP_NO_Return("Product_Update", true);
      this.InsertAssociatedParts(oProduct);
    }

    private void AddProductParametersToCommand(ref Product oProduct)
    {
      Database database = this._database;
      database.AddParameter("@Number", (object) oProduct.Number, true);
      database.AddParameter("@Reference", (object) oProduct.Reference, true);
      database.AddParameter("@TypeID", (object) oProduct.TypeID, true);
      database.AddParameter("@MakeID", (object) oProduct.MakeID, true);
      database.AddParameter("@ModelID", (object) oProduct.ModelID, true);
      database.AddParameter("@Notes", (object) oProduct.Notes, true);
      database.AddParameter("@SellPrice", (object) oProduct.SellPrice, true);
      database.AddParameter("@MinimumQuantity", (object) oProduct.MinimumQuantity, true);
      database.AddParameter("@RecommendedQuantity", (object) oProduct.RecommendedQuantity, true);
    }

    private void InsertAssociatedParts(Product oProduct)
    {
      this._database.ProductAssociatedPart.Delete(oProduct.ProductID);
      ProductAssociatedPart oProductAssociatedPart = new ProductAssociatedPart();
      oProductAssociatedPart.SetProductID = (object) oProduct.ProductID;
      if (oProduct.AssociatedPart == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = oProduct.AssociatedPart.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Conversions.ToBoolean(current["Tick"]))
          {
            oProductAssociatedPart.SetPartID = RuntimeHelpers.GetObjectValue(current["PartID"]);
            this._database.ProductAssociatedPart.Insert(oProductAssociatedPart);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public DataView Stock_Get_Locations(int ProductID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@PartID", (object) 0, true);
      this._database.AddParameter("@ProductID", (object) ProductID, true);
      this._database.AddParameter("@WarehouseID", (object) 0, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Stock_Get_Locations), true);
      table.TableName = Enums.TableNames.tblStock.ToString();
      return new DataView(table);
    }

    public DataView Stock_Get_Locations(int ProductID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Stock_Get_Locations);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@PartID", (object) 0);
      selectCommand.Parameters.AddWithValue("@ProductID", (object) ProductID);
      selectCommand.Parameters.AddWithValue("@WarehouseID", (object) 0);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblStock.ToString();
      return new DataView(table);
    }
  }
}
