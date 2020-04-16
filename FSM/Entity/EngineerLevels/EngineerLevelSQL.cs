// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerLevels.EngineerLevelSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerLevels
{
    public class EngineerLevelSQL
    {
        private Database _database;

        public EngineerLevelSQL(Database database)
        {
            this._database = database;
        }

        public void Insert(int EngineerID, DataTable t)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            this._database.ExecuteSP_NO_Return("EngineerLevel_Delete", true);
            if (t == null)
                return;

            foreach (DataRow dr in t.Rows)
            {
                this._database.ClearParameter();
                this._database.AddParameter("@EngineerID", (object)EngineerID, true);
                this._database.AddParameter("@LevelID", RuntimeHelpers.GetObjectValue(dr["LevelID"]), true);
                this._database.AddParameter("@Notes", (object)Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Notes"])), true);
                this._database.AddParameter("@DatePassed", RuntimeHelpers.GetObjectValue(dr["DatePassed"]), true);
                this._database.AddParameter("@DateExpires", RuntimeHelpers.GetObjectValue(dr["DateExpires"]), true);
                this._database.AddParameter("@DateBooked", RuntimeHelpers.GetObjectValue(dr["DateBooked"]), true);
                this._database.ExecuteSP_NO_Return("EngineerLevel_Insert", true);
            }
        }

        public DataView Get(int EngineerID)
        {
            SqlCommand Command = new SqlCommand("EngineerLevels_Get", new SqlConnection(this._database.ServerConnectionString));
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@EngineerID", (object)EngineerID);
            DataTable table = this._database.ExecuteCommand_DataTable(Command);
            table.TableName = Enums.TableNames.tblEngineerLevel.ToString();
            return new DataView(table);
        }

        public DataView GetAllInDate()
        {
            DataTable table = this._database.ExecuteCommand_DataTable(new SqlCommand("EngineerLevels_GetALLInDate", new SqlConnection(this._database.ServerConnectionString))
            {
                CommandType = CommandType.StoredProcedure
            });
            table.TableName = Enums.TableNames.tblEngineerLevel.ToString();
            return new DataView(table);
        }

        public DataView GetForSetup(int EngineerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object)EngineerID, true);
            DataTable table = this._database.ExecuteSP_DataTable("EngineerLevels_Setup_Get", true);
            table.TableName = Enums.TableNames.tblEngineerLevel.ToString();
            return new DataView(table);
        }

        public DataTable Get_List_For_JobType(int JobTypeID)
        {
            SqlCommand Command = new SqlCommand("EngineerLevels_Get_For_JobType", new SqlConnection(this._database.ServerConnectionString));
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@JobTypeID", (object)JobTypeID);
            DataTable dataTable = this._database.ExecuteCommand_DataTable(Command);
            dataTable.TableName = Enums.TableNames.tblEngineerLevel.ToString();
            return dataTable;
        }

        public DataTable Get_List_For_JobType_GetALL()
        {
            DataTable dataTable = this._database.ExecuteCommand_DataTable(new SqlCommand("EngineerLevels_Get_For_JobType_GetALL", new SqlConnection(this._database.ServerConnectionString))
            {
                CommandType = CommandType.StoredProcedure
            });
            dataTable.TableName = Enums.TableNames.tblEngineerLevel.ToString();
            return dataTable;
        }

        public DataTable EngineerLevel_Insert_For_JobType(int JobTypeID, int SkillID)
        {
            SqlCommand Command = new SqlCommand("[EngineerLevel_Insert_For_JobType]", new SqlConnection(this._database.ServerConnectionString));
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@JobTypeID", (object)JobTypeID);
            Command.Parameters.AddWithValue("@SkillID", (object)SkillID);
            DataTable dataTable = this._database.ExecuteCommand_DataTable(Command);
            dataTable.TableName = Enums.TableNames.tblEngineerLevel.ToString();
            return dataTable;
        }

        public DataTable EngineerLevel_Delete_For_JobType(int JobTypeID, int SkillID)
        {
            SqlCommand Command = new SqlCommand("[EngineerLevel_Delete_For_JobType]", new SqlConnection(this._database.ServerConnectionString));
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@JobTypeID", (object)JobTypeID);
            Command.Parameters.AddWithValue("@SkillID", (object)SkillID);
            DataTable dataTable = this._database.ExecuteCommand_DataTable(Command);
            dataTable.TableName = Enums.TableNames.tblEngineerLevel.ToString();
            return dataTable;
        }
    }
}