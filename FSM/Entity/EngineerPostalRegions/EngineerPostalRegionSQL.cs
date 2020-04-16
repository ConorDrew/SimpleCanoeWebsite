// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerPostalRegions.EngineerPostalRegionSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity.EngineerPostalRegions
{
    public class EngineerPostalRegionSQL
    {
        private Database _database;

        public EngineerPostalRegionSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int EngineerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            this._database.ExecuteSP_NO_Return("EngineerPostalRegion_Delete", true);
        }

        public void Insert(int EngineerID, int PostalRegionID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@PostalRegionID", (object)PostalRegionID, true);
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            this._database.ExecuteSP_NO_Return("EngineerPostalRegion_Insert", true);
        }

        public DataView Get(int EngineerID)
        {
            SqlCommand Command = new SqlCommand("EngineerPostalRegion_Get", new SqlConnection(this._database.ServerConnectionString));
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@EngineerID", (object)EngineerID);
            DataTable table = this._database.ExecuteCommand_DataTable(Command);
            table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
            return new DataView(table);
        }

        public DataView GetALLTicked()
        {
            DataTable table = this._database.ExecuteCommand_DataTable(new SqlCommand("EngineerPostalRegion_GetALL", new SqlConnection(this._database.ServerConnectionString))
            {
                CommandType = CommandType.StoredProcedure
            });
            table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
            return new DataView(table);
        }

        public DataView GetTicked(int EngineerID)
        {
            SqlCommand Command = new SqlCommand("EngineerPostalRegion_Get_OnlyTicked", new SqlConnection(this._database.ServerConnectionString));
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@EngineerID", (object)EngineerID);
            DataTable table = this._database.ExecuteCommand_DataTable(Command);
            table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
            return new DataView(table);
        }

        public DataView GetUnTicked(int EngineerID)
        {
            SqlCommand Command = new SqlCommand("EngineerPostalRegion_Get_OnlyUnTicked", new SqlConnection(this._database.ServerConnectionString));
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@EngineerID", (object)EngineerID);
            DataTable table = this._database.ExecuteCommand_DataTable(Command);
            table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
            return new DataView(table);
        }

        public bool Check(int EngineerID, string PostalRegion)
        {
            SqlCommand sqlCommand = new SqlCommand("EngineerPostalRegion_Check", new SqlConnection(this._database.ServerConnectionString));
            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EngineerID", (object)EngineerID);
                sqlCommand.Parameters.AddWithValue("@PostalRegion", (object)PostalRegion);
                sqlCommand.Connection.Open();
                return Conversions.ToBoolean(sqlCommand.ExecuteScalar());
            }
            finally
            {
                sqlCommand.Connection.Close();
            }
        }

        public DataView EngineerPostalRegion_Get_For_Postcode(string Postcode)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Postcode", (object)Postcode, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerPostalRegion_Get_For_Postcode), true);
            table.TableName = Enums.TableNames.tblEngineerPostalRegion.ToString();
            return new DataView(table);
        }
    }
}