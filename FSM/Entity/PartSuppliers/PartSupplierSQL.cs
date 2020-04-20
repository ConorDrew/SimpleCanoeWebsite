// Decompiled with JetBrains decompiler
// Type: FSM.Entity.PartSuppliers.PartSupplierSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.PartSuppliers
{
    public class PartSupplierSQL
    {
        private Database _database;

        public PartSupplierSQL(Database database)
        {
            this._database = database;
        }

        public object PartSupplier_FindTabletOrder(string SearchString, int SupplierID = 0)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Find", (object)SearchString, true);
            this._database.AddParameter("@SupplierID", (object)SupplierID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartSupplier_FindForTabletOrder", true);
            table.TableName = Enums.TableNames.tblPartSupplier.ToString();
            return (object)new DataView(table);
        }

        public object PartSupplier_Search(string SearchString, int SupplierID = 0, bool isFlagShip = false)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SearchString", (object)SearchString, true);
            this._database.AddParameter("@SupplierID", (object)SupplierID, true);
            this._database.AddParameter("@Flagship", (object)isFlagShip, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartSupplier_Search_2", true);
            table.TableName = Enums.TableNames.tblPart.ToString();
            return (object)new DataView(table);
        }

        public DataView PartSupplierPacks_Get(int PartID, int SupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@SupplierID", (object)SupplierID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(PartSupplierPacks_Get), true);
            table.TableName = Enums.TableNames.tblPartSupplier.ToString();
            return new DataView(table);
        }

        public DataView PartSupplierPacks_Get(int PartID, int SupplierID, SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(PartSupplierPacks_Get);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@PartID", (object)PartID);
            selectCommand.Parameters.AddWithValue("@SupplierID", (object)SupplierID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            table.TableName = Enums.TableNames.tblPartSupplier.ToString();
            return new DataView(table);
        }

        public PartSupplier PartSupplier_Get(int PartSupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartSupplierID", (object)PartSupplierID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(PartSupplier_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (PartSupplier)null;
            PartSupplier partSupplier1 = new PartSupplier();
            PartSupplier partSupplier2 = partSupplier1;
            partSupplier2.IgnoreExceptionsOnSetMethods = true;
            partSupplier2.SetPartID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartID"]);
            partSupplier2.SetPartSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(PartSupplierID)]);
            partSupplier2.SetPartCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PartCode"]);
            partSupplier2.SetPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Price"]);
            partSupplier2.SetSupplierID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SupplierID"]);
            partSupplier2.SetQuantityInPack = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuantityInPack"]);
            partSupplier2.SetPreferred = Conversions.ToBoolean(dataTable.Rows[0]["Preferred"]);
            if (dataTable.Columns.Contains("SecondaryPrice"))
                partSupplier2.SetSecondaryPrice = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SecondaryPrice"]));
            partSupplier1.Exists = true;
            return partSupplier1;
        }

        public PartSupplier PartSupplier_Get(int PartSupplierID, SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = nameof(PartSupplier_Get);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@PartSupplierID", (object)PartSupplierID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            if (table == null || table.Rows.Count <= 0)
                return (PartSupplier)null;
            PartSupplier partSupplier1 = new PartSupplier();
            PartSupplier partSupplier2 = partSupplier1;
            partSupplier2.IgnoreExceptionsOnSetMethods = true;
            partSupplier2.SetPartID = RuntimeHelpers.GetObjectValue(table.Rows[0]["PartID"]);
            partSupplier2.SetPartSupplierID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof(PartSupplierID)]);
            partSupplier2.SetPartCode = RuntimeHelpers.GetObjectValue(table.Rows[0]["PartCode"]);
            partSupplier2.SetPrice = RuntimeHelpers.GetObjectValue(table.Rows[0]["Price"]);
            partSupplier2.SetSupplierID = RuntimeHelpers.GetObjectValue(table.Rows[0]["SupplierID"]);
            partSupplier2.SetQuantityInPack = RuntimeHelpers.GetObjectValue(table.Rows[0]["QuantityInPack"]);
            partSupplier2.SetPreferred = Conversions.ToBoolean(table.Rows[0]["Preferred"]);
            if (table.Columns.Contains("SecondaryPrice"))
                partSupplier2.SetSecondaryPrice = (object)Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["SecondaryPrice"]));
            partSupplier1.Exists = true;
            return partSupplier1;
        }

        public DataView PartSupplierGet_All()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("PartSupplier_GetAll", true);
            table.TableName = Enums.TableNames.tblPartSupplier.ToString();
            return new DataView(table);
        }

        public DataView Get_ByPartID(int PartID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartSupplier_GetByPart", true);
            table.TableName = Enums.TableNames.tblPartSupplier.ToString();
            return new DataView(table);
        }

        public DataView Get_ByPartID(int PartID, SqlTransaction trans)
        {
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.CommandText = "PartSupplier_GetByPart";
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Transaction = trans;
            selectCommand.Connection = trans.Connection;
            selectCommand.Parameters.AddWithValue("@PartID", (object)PartID);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            table.TableName = Enums.TableNames.tblPartSupplier.ToString();
            return new DataView(table);
        }

        public DataView Get_ByPartIDAndSupplierID(int PartID, int SupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartID", (object)PartID, true);
            this._database.AddParameter("@SupplierID", (object)SupplierID, true);
            DataTable table = this._database.ExecuteSP_DataTable("PartSupplier_GetByPartAndSupplier", true);
            table.TableName = Enums.TableNames.tblPartSupplier.ToString();
            return new DataView(table);
        }

        public void Delete(int PartSupplierID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartSupplierID", (object)PartSupplierID, true);
            this._database.ExecuteSP_NO_Return("PartSupplier_Delete", true);
        }

        public PartSupplier Insert(PartSupplier oPartSupplier)
        {
            this._database.ClearParameter();
            this.AddPartSupplierParametersToCommand(ref oPartSupplier);
            oPartSupplier.SetPartSupplierID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("PartSupplier_Insert", true)));
            oPartSupplier.Exists = true;
            return oPartSupplier;
        }

        public void Update(
          PartSupplier oPartSupplier,
          bool PrimaryDateUpdate = false,
          bool SecondaryDateUpdate = false)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartSupplierID", (object)oPartSupplier.PartSupplierID, true);
            if (PrimaryDateUpdate)
                this._database.AddParameter("@PrimaryDateUpdate", (object)true, true);
            if (SecondaryDateUpdate)
                this._database.AddParameter("@SecondaryDateUpdate", (object)true, true);
            this.AddPartSupplierParametersToCommand(ref oPartSupplier);
            this._database.ExecuteSP_NO_Return("PartSupplier_Update", true);
        }

        private void AddPartSupplierParametersToCommand(ref PartSupplier oPartSupplier)
        {
            Database database = this._database;
            database.AddParameter("@PartCode", (object)oPartSupplier.PartCode, true);
            database.AddParameter("@PartID", (object)oPartSupplier.PartID, true);
            database.AddParameter("@SupplierID", (object)oPartSupplier.SupplierID, true);
            database.AddParameter("@Price", (object)oPartSupplier.Price, true);
            database.AddParameter("@QuantityInPack", (object)oPartSupplier.QuantityInPack, true);
            database.AddParameter("@UserID", (object)App.loggedInUser.UserID, true);
            if (oPartSupplier.SecondaryPrice > 0.0)
                database.AddParameter("@SecondaryPrice", (object)oPartSupplier.SecondaryPrice, true);
        }

        public void Update_Preferred(int PartSupplierID, bool Preferred)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PartSupplierID", (object)PartSupplierID, true);
            if (Preferred)
                this._database.AddParameter("@Preferred", (object)1, true);
            else
                this._database.AddParameter("@Preferred", (object)0, true);
            this._database.ExecuteSP_NO_Return("PartSupplier_Update_Preferred", true);
        }
    }
}