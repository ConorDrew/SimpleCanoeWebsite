using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity.EngineerLevels
{
    public class EngineerLevelSQL
    {
        private Sys.Database _database;

        public EngineerLevelSQL(Sys.Database database)
        {
            _database = database;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void Insert(int EngineerID, DataTable t)
        {

            // delete all first
            _database.ClearParameter();
            _database.AddParameter("@EngineerID", EngineerID, true);
            _database.ExecuteSP_NO_Return("EngineerLevel_Delete");
            if (t is object)
            {
                foreach (DataRow r in t.Rows)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@EngineerID", EngineerID, true);
                    _database.AddParameter("@LevelID", r["LevelID"], true);
                    _database.AddParameter("@Notes", Sys.Helper.MakeStringValid(r["Notes"]), true);
                    _database.AddParameter("@DatePassed", r["DatePassed"], true);
                    _database.AddParameter("@DateExpires", r["DateExpires"], true);
                    _database.AddParameter("@DateBooked", r["DateBooked"], true);
                    _database.ExecuteSP_NO_Return("EngineerLevel_Insert");
                }
            }
        }

        public DataView Get(int EngineerID)
        {
            // _database.ClearParameter()
            // _database.AddParameter("@EngineerID", EngineerID, True)

            var command = new SqlCommand("EngineerLevels_Get", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EngineerID", EngineerID);
            var dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = Sys.Enums.TableNames.tblEngineerLevel.ToString();
            return new DataView(dt);
        }

        public DataView GetAllInDate()
        {
            // _database.ClearParameter()
            // _database.AddParameter("@EngineerID", EngineerID, True)

            var command = new SqlCommand("EngineerLevels_GetALLInDate", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            var dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = Sys.Enums.TableNames.tblEngineerLevel.ToString();
            return new DataView(dt);
        }

        public DataView GetForSetup(int EngineerID)
        {
            _database.ClearParameter();
            _database.AddParameter("@EngineerID", EngineerID, true);
            var dt = _database.ExecuteSP_DataTable("EngineerLevels_Setup_Get");
            dt.TableName = Sys.Enums.TableNames.tblEngineerLevel.ToString();
            return new DataView(dt);
        }

        public DataTable Get_List_For_JobType(int JobTypeID)
        {
            var command = new SqlCommand("EngineerLevels_Get_For_JobType", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@JobTypeID", JobTypeID);
            var dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = Sys.Enums.TableNames.tblEngineerLevel.ToString();
            return dt;
        }

        public DataTable Get_List_For_JobType_GetALL()
        {
            var command = new SqlCommand("EngineerLevels_Get_For_JobType_GetALL", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            var dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = Sys.Enums.TableNames.tblEngineerLevel.ToString();
            return dt;
        }

        public DataTable EngineerLevel_Insert_For_JobType(int JobTypeID, int SkillID)
        {
            var command = new SqlCommand("[EngineerLevel_Insert_For_JobType]", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@JobTypeID", JobTypeID);
            command.Parameters.AddWithValue("@SkillID", SkillID);
            var dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = Sys.Enums.TableNames.tblEngineerLevel.ToString();
            return dt;
        }

        public DataTable EngineerLevel_Delete_For_JobType(int JobTypeID, int SkillID)
        {
            var command = new SqlCommand("[EngineerLevel_Delete_For_JobType]", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@JobTypeID", JobTypeID);
            command.Parameters.AddWithValue("@SkillID", SkillID);
            var dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = Sys.Enums.TableNames.tblEngineerLevel.ToString();
            return dt;
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */



    }
}