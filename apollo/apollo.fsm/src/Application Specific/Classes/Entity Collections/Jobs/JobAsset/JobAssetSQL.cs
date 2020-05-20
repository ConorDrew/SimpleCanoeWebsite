using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace JobAssets
    {
        public class JobAssetSQL
        {
            private Sys.Database _database;

            public JobAssetSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public JobAsset Insert(JobAsset oJobAsset, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobAsset_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@JobID", oJobAsset.JobID));
                Command.Parameters.Add(new SqlParameter("@AssetID", oJobAsset.AssetID));
                oJobAsset.SetJobAssetID = Sys.Helper.MakeIntegerValid(Command.ExecuteScalar());
                return oJobAsset;
            }

            public JobAsset Insert(JobAsset oJobAsset)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", oJobAsset.JobID, true);
                _database.AddParameter("@AssetID", oJobAsset.AssetID, true);
                oJobAsset.SetJobAssetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobAsset_Insert"));
                return oJobAsset;
            }

            public void Delete(int JobID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobAsset_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@JobID", JobID));
                Command.ExecuteNonQuery();
            }

            public void Delete(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                _database.ExecuteSP_OBJECT("JobAsset_Delete");
            }

            public DataView JobAsset_Get_For_Job(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("JobAsset_Get_For_Job");
                dt.TableName = Sys.Enums.TableNames.tblJobAsset.ToString();
                return new DataView(dt);
            }

            public DataView JobAsset_Get_For_Job(int JobID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobAsset_Get_For_Job";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@JobID", JobID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblJobAsset.ToString();
                return new DataView(dt);
            }

            public ArrayList JobAsset_Get_For_Job_As_Objects(int JobID)
            {
                var assets = new ArrayList();
                foreach (DataRow row in JobAsset_Get_For_Job(JobID).Table.Rows)
                {
                    var asset = new JobAsset();
                    asset.IgnoreExceptionsOnSetMethods = true;
                    asset.SetJobAssetID = row["JobAssetID"];
                    asset.SetJobID = row["JobID"];
                    asset.SetAssetID = row["AssetID"];
                    assets.Add(asset);
                }

                return assets;
            }

            public ArrayList JobAsset_Get_For_Job_As_Objects(int JobID, SqlTransaction trans)
            {
                var assets = new ArrayList();
                foreach (DataRow row in JobAsset_Get_For_Job(JobID, trans).Table.Rows)
                {
                    var asset = new JobAsset();
                    asset.IgnoreExceptionsOnSetMethods = true;
                    asset.SetJobAssetID = row["JobAssetID"];
                    asset.SetJobID = row["JobID"];
                    asset.SetAssetID = row["AssetID"];
                    assets.Add(asset);
                }

                return assets;
            }

            
        }
    }
}