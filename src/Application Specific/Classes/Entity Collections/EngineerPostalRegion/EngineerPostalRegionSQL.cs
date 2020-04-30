using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace EngineerPostalRegions
    {
        public class EngineerPostalRegionSQL
        {
            private Sys.Database _database;

            public EngineerPostalRegionSQL(Sys.Database database)
            {
                _database = database;
            }

            

            public void Delete(int EngineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.ExecuteSP_NO_Return("EngineerPostalRegion_Delete");
            }

            public void Insert(int EngineerID, int PostalRegionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PostalRegionID", PostalRegionID, true);
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.ExecuteSP_NO_Return("EngineerPostalRegion_Insert");
            }

            public DataView Get(int EngineerID)
            {
                // _database.ClearParameter()
                // _database.AddParameter("@EngineerID", EngineerID, True)

                var command = new SqlCommand("EngineerPostalRegion_Get", new SqlConnection(_database.ServerConnectionString));
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EngineerID", EngineerID);
                var dt = _database.ExecuteCommand_DataTable(command);
                dt.TableName = Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
                return new DataView(dt);
            }

            public DataView GetAll()
            {
                // _database.ClearParameter()
                // _database.AddParameter("@EngineerID", EngineerID, True)

                var command = new SqlCommand("EngineerPostalRegion_GetALL", new SqlConnection(_database.ServerConnectionString));
                command.CommandType = CommandType.StoredProcedure;
                var dt = _database.ExecuteCommand_DataTable(command);
                dt.TableName = Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
                return new DataView(dt);
            }

            public DataView GetOnlyTicked(int EngineerID)
            {
                // _database.ClearParameter()
                // _database.AddParameter("@EngineerID", EngineerID, True)

                var command = new SqlCommand("EngineerPostalRegion_Get_OnlyTicked", new SqlConnection(_database.ServerConnectionString));
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EngineerID", EngineerID);
                var dt = _database.ExecuteCommand_DataTable(command);
                dt.TableName = Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
                return new DataView(dt);
            }

            public DataView GetAllTicked()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("EngineerPostalRegion_GetAllTicked");
                dt.TableName = Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
                return new DataView(dt);
            }

            public DataView GetUnTicked(int EngineerID)
            {
                // _database.ClearParameter()
                // _database.AddParameter("@EngineerID", EngineerID, True)

                var command = new SqlCommand("EngineerPostalRegion_Get_OnlyUnTicked", new SqlConnection(_database.ServerConnectionString));
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EngineerID", EngineerID);
                var dt = _database.ExecuteCommand_DataTable(command);
                dt.TableName = Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
                return new DataView(dt);
            }

            public bool Check(int EngineerID, string PostalRegion)
            {
                var command = new SqlCommand("EngineerPostalRegion_Check", new SqlConnection(_database.ServerConnectionString));
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EngineerID", EngineerID);
                    command.Parameters.AddWithValue("@PostalRegion", PostalRegion);
                    command.Connection.Open();
                    return Conversions.ToBoolean(command.ExecuteScalar());
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            public DataView EngineerPostalRegion_Get_For_Postcode(string Postcode)
            {
                _database.ClearParameter();
                _database.AddParameter("@Postcode", Postcode, true);
                var dt = _database.ExecuteSP_DataTable("EngineerPostalRegion_Get_For_Postcode");
                dt.TableName = Sys.Enums.TableNames.tblEngineerPostalRegion.ToString();
                return new DataView(dt);
            }

            
        }
    }
}