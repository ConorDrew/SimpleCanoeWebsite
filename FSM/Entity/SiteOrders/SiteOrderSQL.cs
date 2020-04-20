// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SiteOrders.SiteOrderSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.SiteOrders
{
    public class SiteOrderSQL
    {
        private Database _database;

        public SiteOrderSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int SiteOrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteOrderID", (object)SiteOrderID, true);
            this._database.ExecuteSP_NO_Return("SiteOrder_Delete", true);
        }

        public void DeleteByOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, true);
            this._database.ExecuteSP_NO_Return("SiteOrder_DeleteByOrder", true);
        }

        public SiteOrder SiteOrder_Get(int SiteOrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteOrderID", (object)SiteOrderID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(SiteOrder_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (SiteOrder)null;
            SiteOrder siteOrder1 = new SiteOrder();
            SiteOrder siteOrder2 = siteOrder1;
            siteOrder2.IgnoreExceptionsOnSetMethods = true;
            siteOrder2.SetSiteOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(SiteOrderID)]);
            siteOrder2.SetSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
            siteOrder2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderID"]);
            siteOrder1.Exists = true;
            return siteOrder1;
        }

        public SiteOrder SiteOrder_GetForOrder(int OrderID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object)OrderID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(SiteOrder_GetForOrder), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (SiteOrder)null;
            SiteOrder siteOrder1 = new SiteOrder();
            SiteOrder siteOrder2 = siteOrder1;
            siteOrder2.IgnoreExceptionsOnSetMethods = true;
            siteOrder2.SetSiteOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteOrderID"]);
            siteOrder2.SetSiteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
            siteOrder2.SetOrderID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(OrderID)]);
            siteOrder1.Exists = true;
            return siteOrder1;
        }

        public DataView SiteOrder_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SiteOrder_GetAll), true);
            table.TableName = Enums.TableNames.tblSiteOrder.ToString();
            return new DataView(table);
        }

        public SiteOrder Insert(SiteOrder oSiteOrder, SqlTransaction trans)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SiteOrder_Insert";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Transaction = trans;
            sqlCommand.Connection = trans.Connection;
            sqlCommand.Parameters.AddWithValue("@OrderID", (object)oSiteOrder.OrderID);
            sqlCommand.Parameters.AddWithValue("@SiteID", (object)oSiteOrder.SiteID);
            oSiteOrder.SetSiteOrderID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
            oSiteOrder.Exists = true;
            return oSiteOrder;
        }

        public SiteOrder Insert(SiteOrder oSiteOrder)
        {
            this._database.ClearParameter();
            this.AddSiteOrderParametersToCommand(ref oSiteOrder);
            oSiteOrder.SetSiteOrderID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("SiteOrder_Insert", true)));
            oSiteOrder.Exists = true;
            return oSiteOrder;
        }

        public void Update(SiteOrder oSiteOrder)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteOrderID", (object)oSiteOrder.SiteOrderID, true);
            this.AddSiteOrderParametersToCommand(ref oSiteOrder);
            this._database.ExecuteSP_NO_Return("SiteOrder_Update", true);
        }

        private void AddSiteOrderParametersToCommand(ref SiteOrder oSiteOrder)
        {
            Database database = this._database;
            database.AddParameter("@SiteID", (object)oSiteOrder.SiteID, true);
            database.AddParameter("@OrderID", (object)oSiteOrder.OrderID, true);
        }
    }
}