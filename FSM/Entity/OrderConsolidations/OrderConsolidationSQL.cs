// Decompiled with JetBrains decompiler
// Type: FSM.Entity.OrderConsolidations.OrderConsolidationSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM.Entity.OrderConsolidations
{
  public class OrderConsolidationSQL
  {
    private Database _database;

    public OrderConsolidationSQL(Database database)
    {
      this._database = database;
    }

    public void OrderConsolidation_Clear_Orders(int OrderConsolidationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderConsolidationID", (object) OrderConsolidationID, true);
      this._database.ExecuteSP_NO_Return(nameof (OrderConsolidation_Clear_Orders), true);
    }

    public void Order_Set_Consolidated(
      int OrderConsolidationID,
      int OrderID,
      bool ReleaseConsolidated)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderConsolidationID", (object) OrderConsolidationID, true);
      this._database.AddParameter("@OrderID", (object) OrderID, true);
      if (ReleaseConsolidated)
        this._database.AddParameter("@ReleaseConsolidated", (object) 1, true);
      else
        this._database.AddParameter("@ReleaseConsolidated", (object) 0, true);
      this._database.ExecuteSP_NO_Return(nameof (Order_Set_Consolidated), true);
    }

    public void Order_Set_Consolidated(
      int OrderConsolidationID,
      int OrderID,
      bool ReleaseConsolidated,
      SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = nameof (Order_Set_Consolidated);
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@OrderConsolidationID", (object) OrderConsolidationID);
      sqlCommand.Parameters.AddWithValue("@OrderID", (object) OrderID);
      if (ReleaseConsolidated)
        sqlCommand.Parameters.AddWithValue("@ReleaseConsolidated", (object) 1);
      else
        sqlCommand.Parameters.AddWithValue("@ReleaseConsolidated", (object) 0);
      sqlCommand.ExecuteNonQuery();
    }

    public OrderConsolidation OrderConsolidation_Get(int OrderConsolidationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderConsolidationID", (object) OrderConsolidationID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (OrderConsolidation_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (OrderConsolidation) null;
      OrderConsolidation orderConsolidation1 = new OrderConsolidation();
      OrderConsolidation orderConsolidation2 = orderConsolidation1;
      orderConsolidation2.IgnoreExceptionsOnSetMethods = true;
      orderConsolidation2.SetOrderConsolidationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (OrderConsolidationID)]);
      orderConsolidation2.SetSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierID"]);
      orderConsolidation2.SetLocationID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LocationID"]);
      orderConsolidation2.ConsolidationDate = Conversions.ToDate(dataTable.Rows[0]["ConsolidationDate"]);
      orderConsolidation2.SetConsolidationRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ConsolidationRef"]);
      orderConsolidation2.SetComments = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Comments"]);
      orderConsolidation2.SetConsolidatedOrderStatusID = Conversions.ToInteger(dataTable.Rows[0]["ConsolidatedOrderStatusID"]);
      orderConsolidation2.HasSupplierPO = Conversions.ToBoolean(dataTable.Rows[0]["HasSupplierPO"]);
      orderConsolidation2.SetSupplierInvoiceReference = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierInvoiceReference"]);
      orderConsolidation2.SupplierInvoiceDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierInvoiceDate"]));
      orderConsolidation2.SetSupplierInvoiceAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierInvoiceAmount"]);
      orderConsolidation2.SetVATAmount = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VATAmount"]);
      orderConsolidation2.SetTaxCodeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TaxCodeID"]);
      orderConsolidation2.SetExtraRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ExtraRef"]);
      orderConsolidation2.SetNominalCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NominalCode"]);
      orderConsolidation2.SetDepartmentRef = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DepartmentRef"]);
      orderConsolidation2.SetReadyToSendToSage = Conversions.ToBoolean(dataTable.Rows[0]["ReadyToSendToSage"]);
      orderConsolidation2.SetSentToSage = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SentToSage"]);
      orderConsolidation2.DateExported = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DateExported"]));
      orderConsolidation1.Exists = true;
      return orderConsolidation1;
    }

    public DataView OrderConsolidation_GetAll(bool forLocation, string SearchCriteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchCriteria", (object) SearchCriteria, true);
      if (forLocation)
        this._database.AddParameter("@ForLocation", (object) 1, true);
      else
        this._database.AddParameter("@ForLocation", (object) 0, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (OrderConsolidation_GetAll), true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_GetForConsolidation(int SupplierID, int LocationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      DataTable table = this._database.ExecuteSP_DataTable("[Order_GetForConsolidation]", true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_GetForConsolidationByID(
      int OrderConsolidationID,
      int SupplierID,
      int LocationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderConsolidationID", (object) OrderConsolidationID, true);
      this._database.AddParameter("@SupplierID", (object) SupplierID, true);
      this._database.AddParameter("@LocationID", (object) LocationID, true);
      DataTable table = this._database.ExecuteSP_DataTable("[Order_GetForConsolidationByID]", true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataView Order_GetForConsolidationByID_Confirmed(
      int OrderConsolidationID,
      bool ForLocation)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderConsolidationID", (object) OrderConsolidationID, true);
      if (ForLocation)
        this._database.AddParameter("@ForLocation", (object) 1, true);
      else
        this._database.AddParameter("@ForLocation", (object) 0, true);
      DataTable table = this._database.ExecuteSP_DataTable("[Order_GetForConsolidationByID_Confirmed]", true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public void Create_And_Insert_Supplier(int PartSupplierID, int ProductSupplierID, int OrderID)
    {
      int num1 = 0;
      try
      {
        if ((uint) PartSupplierID > 0U)
          num1 = App.DB.PartSupplier.PartSupplier_Get(PartSupplierID).SupplierID;
        else if ((uint) ProductSupplierID > 0U)
          num1 = App.DB.ProductSupplier.ProductSupplier_Get(ProductSupplierID).SupplierID;
        if (num1 == 0)
          throw new Exception("Supplier could not be determined");
        int OrderConsolidationID = App.DB.Order.Order_Get(OrderID).OrderConsolidationID;
        if (OrderConsolidationID == 0)
        {
          this._database.ClearParameter();
          this._database.AddParameter("@SupplierID", (object) num1, true);
          this._database.AddParameter("@LocationID", (object) 0, true);
          OrderConsolidationID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderConsolidation_Check_If_Exists", true)));
        }
        if (OrderConsolidationID == 0)
        {
          OrderConsolidation oOrderConsolidation = new OrderConsolidation();
          oOrderConsolidation.SetSupplierID = (object) num1;
          oOrderConsolidation.SetComments = (object) "Automatically Created";
          oOrderConsolidation.SetConsolidatedOrderStatusID = 1;
          JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.CONSOLIDATION);
          nextJobNumber.OrderNumber = Conversions.ToString(nextJobNumber.JobNumber);
          while (nextJobNumber.OrderNumber.Length < 5)
            nextJobNumber.OrderNumber = "0" + nextJobNumber.OrderNumber;
          string str1 = "W";
          string str2 = "";
          string[] strArray = App.loggedInUser.Fullname.Split(' ');
          int index = 0;
          while (index < strArray.Length)
          {
            string str3 = strArray[index];
            str2 += str3.Substring(0, 1);
            checked { ++index; }
          }
          nextJobNumber.OrderNumber = str2 + str1 + nextJobNumber.OrderNumber;
          oOrderConsolidation.SetConsolidationRef = (object) nextJobNumber.OrderNumber;
          OrderConsolidationID = this.Insert(oOrderConsolidation);
        }
        this.Order_Set_Consolidated(OrderConsolidationID, OrderID, false);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num2 = (int) App.ShowMessage("Consolidation could not be created:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void Create_And_Insert_Supplier(
      int PartSupplierID,
      int ProductSupplierID,
      int OrderID,
      SqlTransaction trans)
    {
      int num1 = 0;
      try
      {
        if ((uint) PartSupplierID > 0U)
          num1 = App.DB.PartSupplier.PartSupplier_Get(PartSupplierID, trans).SupplierID;
        else if ((uint) ProductSupplierID > 0U)
          num1 = App.DB.ProductSupplier.ProductSupplier_Get(ProductSupplierID, trans).SupplierID;
        if (num1 == 0)
          throw new Exception("Supplier could not be determined");
        int OrderConsolidationID = App.DB.Order.Order_Get(OrderID, trans).OrderConsolidationID;
        if (OrderConsolidationID == 0)
        {
          SqlCommand sqlCommand = new SqlCommand();
          sqlCommand.CommandText = "OrderConsolidation_Check_If_Exists";
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Transaction = trans;
          sqlCommand.Connection = trans.Connection;
          sqlCommand.Parameters.AddWithValue("@SupplierID", (object) num1);
          sqlCommand.Parameters.AddWithValue("@LocationID", (object) 0);
          OrderConsolidationID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
        }
        if (OrderConsolidationID == 0)
        {
          OrderConsolidation oOrderConsolidation = new OrderConsolidation();
          oOrderConsolidation.SetSupplierID = (object) num1;
          oOrderConsolidation.SetComments = (object) "Automatically Created";
          oOrderConsolidation.SetConsolidatedOrderStatusID = 1;
          JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.CONSOLIDATION, trans);
          nextJobNumber.OrderNumber = Conversions.ToString(nextJobNumber.JobNumber);
          while (nextJobNumber.OrderNumber.Length < 5)
            nextJobNumber.OrderNumber = "0" + nextJobNumber.OrderNumber;
          string str1 = "W";
          string str2 = "";
          string[] strArray = App.loggedInUser.Fullname.Split(' ');
          int index = 0;
          while (index < strArray.Length)
          {
            string str3 = strArray[index];
            str2 += str3.Substring(0, 1);
            checked { ++index; }
          }
          nextJobNumber.OrderNumber = str2 + str1 + nextJobNumber.OrderNumber;
          oOrderConsolidation.SetConsolidationRef = (object) nextJobNumber.OrderNumber;
          OrderConsolidationID = this.Insert(oOrderConsolidation, trans);
        }
        this.Order_Set_Consolidated(OrderConsolidationID, OrderID, false, trans);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num2 = (int) App.ShowMessage("Consolidation could not be created:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void Create_And_Insert_Location(int LocationID, int OrderID, SqlTransaction trans)
    {
      try
      {
        if (LocationID == 0)
          throw new Exception("Location could not be determined");
        int OrderConsolidationID = App.DB.Order.Order_Get(OrderID, trans).OrderConsolidationID;
        if (OrderConsolidationID == 0)
        {
          SqlCommand sqlCommand = new SqlCommand();
          sqlCommand.CommandText = "OrderConsolidation_Check_If_Exists";
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Transaction = trans;
          sqlCommand.Connection = trans.Connection;
          sqlCommand.Parameters.AddWithValue("@SupplierID", (object) 0);
          sqlCommand.Parameters.AddWithValue("@LocationID", (object) LocationID);
          OrderConsolidationID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
        }
        if (OrderConsolidationID == 0)
        {
          OrderConsolidation oOrderConsolidation = new OrderConsolidation();
          oOrderConsolidation.SetLocationID = (object) LocationID;
          oOrderConsolidation.SetComments = (object) "Automatically Created";
          oOrderConsolidation.SetConsolidatedOrderStatusID = 1;
          JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.CONSOLIDATION, trans);
          nextJobNumber.OrderNumber = Conversions.ToString(nextJobNumber.JobNumber);
          while (nextJobNumber.OrderNumber.Length < 6)
            nextJobNumber.OrderNumber = "0" + nextJobNumber.OrderNumber;
          oOrderConsolidation.SetConsolidationRef = (object) (nextJobNumber.Prefix + nextJobNumber.OrderNumber);
          OrderConsolidationID = this.Insert(oOrderConsolidation, trans);
        }
        this.Order_Set_Consolidated(OrderConsolidationID, OrderID, false, trans);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Consolidation could not be created:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void Create_And_Insert_Location(int LocationID, int OrderID)
    {
      try
      {
        if (LocationID == 0)
          throw new Exception("Location could not be determined");
        int OrderConsolidationID = App.DB.Order.Order_Get(OrderID).OrderConsolidationID;
        if (OrderConsolidationID == 0)
        {
          this._database.ClearParameter();
          this._database.AddParameter("@SupplierID", (object) 0, true);
          this._database.AddParameter("@LocationID", (object) LocationID, true);
          OrderConsolidationID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderConsolidation_Check_If_Exists", true)));
        }
        if (OrderConsolidationID == 0)
        {
          OrderConsolidation oOrderConsolidation = new OrderConsolidation();
          oOrderConsolidation.SetLocationID = (object) LocationID;
          oOrderConsolidation.SetComments = (object) "Automatically Created";
          oOrderConsolidation.SetConsolidatedOrderStatusID = 1;
          JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.CONSOLIDATION);
          nextJobNumber.OrderNumber = Conversions.ToString(nextJobNumber.JobNumber);
          while (nextJobNumber.OrderNumber.Length < 6)
            nextJobNumber.OrderNumber = "0" + nextJobNumber.OrderNumber;
          oOrderConsolidation.SetConsolidationRef = (object) (nextJobNumber.Prefix + nextJobNumber.OrderNumber);
          OrderConsolidationID = this.Insert(oOrderConsolidation);
        }
        this.Order_Set_Consolidated(OrderConsolidationID, OrderID, false);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Consolidation could not be created:\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public int Insert(OrderConsolidation oOrderConsolidation)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SupplierID", (object) oOrderConsolidation.SupplierID, true);
      this._database.AddParameter("@LocationID", (object) oOrderConsolidation.LocationID, true);
      this._database.AddParameter("@ConsolidationRef", (object) oOrderConsolidation.ConsolidationRef, true);
      this._database.AddParameter("@Comments", (object) oOrderConsolidation.Comments, true);
      this._database.AddParameter("@ConsolidatedOrderStatusID", (object) oOrderConsolidation.ConsolidatedOrderStatusID, true);
      oOrderConsolidation.SetOrderConsolidationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("OrderConsolidation_Insert", true)));
      oOrderConsolidation.Exists = true;
      return oOrderConsolidation.OrderConsolidationID;
    }

    public int Insert(OrderConsolidation oOrderConsolidation, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "OrderConsolidation_Insert";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.AddWithValue("@SupplierID", (object) oOrderConsolidation.SupplierID);
      sqlCommand.Parameters.AddWithValue("@LocationID", (object) oOrderConsolidation.LocationID);
      sqlCommand.Parameters.AddWithValue("@ConsolidationRef", (object) oOrderConsolidation.ConsolidationRef);
      sqlCommand.Parameters.AddWithValue("@Comments", (object) oOrderConsolidation.Comments);
      sqlCommand.Parameters.AddWithValue("@ConsolidatedOrderStatusID", (object) oOrderConsolidation.ConsolidatedOrderStatusID);
      oOrderConsolidation.SetOrderConsolidationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
      oOrderConsolidation.Exists = true;
      return oOrderConsolidation.OrderConsolidationID;
    }

    public void Update(OrderConsolidation oOrderConsolidation)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderConsolidationID", (object) oOrderConsolidation.OrderConsolidationID, true);
      this._database.AddParameter("@Comments", (object) oOrderConsolidation.Comments, true);
      this._database.AddParameter("@ConsolidatedOrderStatusID", (object) oOrderConsolidation.ConsolidatedOrderStatusID, true);
      if (oOrderConsolidation.HasSupplierPO)
        this._database.AddParameter("@HasSupplierPO", (object) 1, true);
      else
        this._database.AddParameter("@HasSupplierPO", (object) 0, true);
      this._database.AddParameter("@SupplierInvoiceReference", (object) oOrderConsolidation.SupplierInvoiceReference, true);
      if (DateTime.Compare(oOrderConsolidation.SupplierInvoiceDate, DateTime.MinValue) == 0)
        this._database.AddParameter("@SupplierInvoiceDate", (object) DBNull.Value, true);
      else
        this._database.AddParameter("@SupplierInvoiceDate", (object) oOrderConsolidation.SupplierInvoiceDate, true);
      this._database.AddParameter("@SupplierInvoiceAmount", (object) oOrderConsolidation.SupplierInvoiceAmount, true);
      this._database.AddParameter("@VATAmount", (object) oOrderConsolidation.VATAmount, true);
      this._database.AddParameter("@TaxCodeID", (object) oOrderConsolidation.TaxCodeID, true);
      this._database.AddParameter("@ExtraRef", (object) oOrderConsolidation.ExtraRef, true);
      this._database.AddParameter("@NominalCode", (object) oOrderConsolidation.NominalCode, true);
      this._database.AddParameter("@DepartmentRef", (object) oOrderConsolidation.DepartmentRef, true);
      if (oOrderConsolidation.ReadyToSendToSage)
        this._database.AddParameter("@ReadyToSendToSage", (object) 1, true);
      else
        this._database.AddParameter("@ReadyToSendToSage", (object) 0, true);
      this._database.ExecuteSP_NO_Return("OrderConsolidation_Update", true);
    }

    public DataView Order_GetItemForConsolidationID(
      int OrderConsolidationID,
      bool ForLocation)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderConsolidationID", (object) OrderConsolidationID, true);
      if (ForLocation)
        this._database.AddParameter("@ForLocation", (object) 1, true);
      else
        this._database.AddParameter("@ForLocation", (object) 0, true);
      DataTable table = this._database.ExecuteSP_DataTable("[Order_GetItemForConsolidationID]", true);
      table.TableName = Enums.TableNames.tblOrder.ToString();
      return new DataView(table);
    }

    public DataSet Orders_Complete_ByConsolidationOrderID(int OrderConsolidationID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderConsolidationID", (object) OrderConsolidationID, true);
      return this._database.ExecuteSP_DataSet("[Orders_Complete_ByConsolidationOrderID]", true);
    }
  }
}
