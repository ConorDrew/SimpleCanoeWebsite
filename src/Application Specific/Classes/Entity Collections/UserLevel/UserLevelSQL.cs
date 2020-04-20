using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity.UserLevels
{
    public class UserLevelSQL
    {
        private Sys.Database _database;

        public UserLevelSQL(Sys.Database database)
        {
            _database = database;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void Insert(int UserID, DataTable t)
        {

            // delete all first
            _database.ClearParameter();
            _database.AddParameter("@UserID", UserID, true);
            _database.ExecuteSP_NO_Return("UserLevel_Delete");
            if (t is object)
            {
                foreach (DataRow r in t.Rows)
                {
                    _database.ClearParameter();
                    _database.AddParameter("@UserID", UserID, true);
                    _database.AddParameter("@LevelID", r["LevelID"], true);
                    _database.AddParameter("@Notes", Sys.Helper.MakeStringValid(r["Notes"]), true);
                    _database.AddParameter("@DatePassed", r["DatePassed"], true);
                    _database.AddParameter("@DateExpires", r["DateExpires"], true);
                    _database.AddParameter("@DateBooked", r["DateBooked"], true);
                    _database.ExecuteSP_NO_Return("UserLevel_Insert");
                }
            }
        }

        public DataView Get(int UserID)
        {
            var command = new SqlCommand("UserLevels_Get", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserID", UserID);
            var dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = Sys.Enums.TableNames.tblUserQualification.ToString();
            return new DataView(dt);
        }

        public DataView GetForSetup(int UserID)
        {
            _database.ClearParameter();
            _database.AddParameter("@UserID", UserID, true);
            var dt = _database.ExecuteSP_DataTable("UserLevels_Setup_Get");
            dt.TableName = Sys.Enums.TableNames.tblUserQualification.ToString();
            return new DataView(dt);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}