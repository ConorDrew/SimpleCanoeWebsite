using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace JobItems
    {
        public class JobItemSQL
        {
            private Sys.Database _database;

            public JobItemSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(string JobItemIDs, int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobItemIDs", JobItemIDs, true);
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                _database.ExecuteSP_NO_Return("JobItem_Delete");
            }

            public void DeleteAll_ForJOW(int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                _database.ExecuteSP_NO_Return("JobItem_DeleteALL_ForJOW");
            }

            public void Delete(string JobItemIDs, int JobOfWorkID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobItem_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@JobOfWorkID", JobOfWorkID));
                Command.Parameters.Add(new SqlParameter("@JobItemIDs", JobItemIDs));
                Command.ExecuteNonQuery();
            }

            public JobItem Insert(JobItem oJobItem, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                string IDs = "";
                // AMY CHANGED THIS BECAUSE I NEED TO RETAIN THE LINK!
                if (oJobItem.JobItemID > 0)
                {
                    // UPDATE
                    Command.CommandText = "JobItem_Update";
                    Command.Parameters.Add(new SqlParameter("@JobItemID", oJobItem.JobItemID));
                }
                else
                {
                    // INSERT
                    Command.CommandText = "JobItem_Insert";
                }

                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@JobOfWorkID", oJobItem.JobOfWorkID));
                Command.Parameters.Add(new SqlParameter("@Summary", oJobItem.Summary));
                Command.Parameters.Add(new SqlParameter("@RateID", oJobItem.RateID));
                Command.Parameters.Add(new SqlParameter("@Qty", oJobItem.Qty));
                Command.Parameters.Add(new SqlParameter("@SystemLinkID", oJobItem.SystemLinkID));
                if (oJobItem.JobItemID > 0)
                {
                    Command.ExecuteNonQuery();
                }
                else
                {
                    oJobItem.SetJobItemID = Command.ExecuteScalar();
                }

                return oJobItem;
            }

            public JobItem Insert(JobItem oJobItem)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", oJobItem.JobOfWorkID, true);
                _database.AddParameter("@Summary", oJobItem.Summary, true);
                _database.AddParameter("@RateID", oJobItem.RateID, true);
                _database.AddParameter("@Qty", oJobItem.Qty, true);
                _database.AddParameter("@SystemLinkID", oJobItem.SystemLinkID, true);
                string IDs = "";
                // AMY CHANGED THIS BECAUSE I NEED TO RETAIN THE LINK!
                if (oJobItem.JobItemID > 0)
                {
                    // UPDATE
                    _database.AddParameter("@JobItemID", oJobItem.JobItemID, true);
                    _database.ExecuteSP_NO_Return("JobItem_Update");
                }
                else
                {
                    // INSERT
                    oJobItem.SetJobItemID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobItem_Insert"));
                }

                return oJobItem;
            }

            public DataView JobItems_Get_For_Job_Of_Work(int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("JobItems_Get_For_Job_Of_Work");
                dt.TableName = Sys.Enums.TableNames.tblJobItem.ToString();
                return new DataView(dt);
            }

            public DataView JobItems_Get_For_Job_Of_Work(int JobOfWorkID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobItems_Get_For_Job_Of_Work";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@JobOfWorkID", JobOfWorkID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Sys.Enums.TableNames.tblJobItem.ToString();
                return new DataView(dt);
            }

            public ArrayList JobOfWork_Get_For_Job_Of_Work_As_Objects(int JobOfWorkID)
            {
                var jobItems = new ArrayList();
                foreach (DataRow row in JobItems_Get_For_Job_Of_Work(JobOfWorkID).Table.Rows)
                {
                    var jobItem = new JobItem();
                    jobItem.IgnoreExceptionsOnSetMethods = true;
                    jobItem.SetJobItemID = row["JobItemID"];
                    jobItem.SetJobOfWorkID = row["JobOfWorkID"];
                    jobItem.SetSummary = row["Summary"];
                    jobItem.SetRateID = row["RateID"];
                    jobItem.SetQty = row["Qty"];
                    if (row.Table.Columns.Contains("SystemLinkID"))
                        jobItem.SetSystemLinkID = row["SystemLinkID"];
                    jobItems.Add(jobItem);
                }

                return jobItems;
            }

            public ArrayList JobOfWork_Get_For_Job_Of_Work_As_Objects(int JobOfWorkID, SqlTransaction trans)
            {
                var jobItems = new ArrayList();
                foreach (DataRow row in JobItems_Get_For_Job_Of_Work(JobOfWorkID, trans).Table.Rows)
                {
                    var jobItem = new JobItem();
                    jobItem.IgnoreExceptionsOnSetMethods = true;
                    jobItem.SetJobItemID = row["JobItemID"];
                    jobItem.SetJobOfWorkID = row["JobOfWorkID"];
                    jobItem.SetSummary = row["Summary"];
                    jobItem.SetRateID = row["RateID"];
                    jobItem.SetQty = row["Qty"];
                    if (row.Table.Columns.Contains("SystemLinkID"))
                        jobItem.SetSystemLinkID = row["SystemLinkID"];
                    jobItems.Add(jobItem);
                }

                return jobItems;
            }

            public DataView JobItems_Get_For_Job(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("JobItems_Get_For_Job");
                dt.TableName = Sys.Enums.TableNames.tblJobItem.ToString();
                return new DataView(dt);
            }

            
        }
    }
}