using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace JobOfWorks
    {
        public class JobOfWorkSQL
        {
            private Database _database;

            public JobOfWorkSQL(Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                _database.ExecuteSP_NO_Return("JobOfWork_Delete");
            }

            public void Delete(int JobOfWorkID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobOfWork_Delete";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@JobOfWorkID", JobOfWorkID));
                Command.ExecuteNonQuery();
            }

            public JobOfWork Insert(JobOfWork oJobOfWork, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobOfWork_Insert";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@JobID", oJobOfWork.JobID));
                Command.Parameters.Add(new SqlParameter("@Deleted", oJobOfWork.Deleted));
                Command.Parameters.Add(new SqlParameter("@PONumber", oJobOfWork.PONumber));
                Command.Parameters.Add(new SqlParameter("@Status", oJobOfWork.Status));
                Command.Parameters.Add(new SqlParameter("@Priority", oJobOfWork.Priority));
                Command.Parameters.Add(new SqlParameter("@QualificationID", oJobOfWork.QualificationID));
                if (oJobOfWork.PriorityDateSet == DateTime.MinValue)
                {
                    Command.Parameters.Add(new SqlParameter("@PriorityDateSet", DBNull.Value));
                }
                else
                {
                    Command.Parameters.Add(new SqlParameter("@PriorityDateSet", oJobOfWork.PriorityDateSet));
                }

                oJobOfWork.SetJobOfWorkID = Helper.MakeIntegerValid(Command.ExecuteScalar());
                oJobOfWork.Exists = true;
                foreach (JobItems.JobItem jobItem in oJobOfWork.JobItems)
                {
                    jobItem.SetJobOfWorkID = oJobOfWork.JobOfWorkID;
                    _database.JobItems.Insert(jobItem, trans);
                }

                foreach (EngineerVisits.EngineerVisit engineerVisit in oJobOfWork.EngineerVisits)
                {
                    engineerVisit.SetJobOfWorkID = oJobOfWork.JobOfWorkID;
                    _database.EngineerVisits.Insert(engineerVisit, oJobOfWork.JobID, trans);
                }

                return oJobOfWork;
            }

            public JobOfWork Insert(JobOfWork oJobOfWork)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", oJobOfWork.JobID, true);
                _database.AddParameter("@Deleted", oJobOfWork.Deleted, true);
                _database.AddParameter("@PONumber ", oJobOfWork.PONumber, true);
                _database.AddParameter("@Status", oJobOfWork.Status, true);
                _database.AddParameter("@Priority ", oJobOfWork.Priority, true);
                _database.AddParameter("@QualificationID ", oJobOfWork.QualificationID, true);
                if (oJobOfWork.PriorityDateSet == DateTime.MinValue | oJobOfWork.PriorityDateSet == default)
                {
                    _database.AddParameter("@PriorityDateSet ", DBNull.Value, true);
                }
                else
                {
                    _database.AddParameter("@PriorityDateSet ", oJobOfWork.PriorityDateSet, true);
                }

                oJobOfWork.SetJobOfWorkID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobOfWork_Insert"));
                oJobOfWork.Exists = true;
                foreach (JobItems.JobItem jobItem in oJobOfWork.JobItems)
                {
                    jobItem.SetJobOfWorkID = oJobOfWork.JobOfWorkID;
                    _database.JobItems.Insert(jobItem);
                }

                foreach (EngineerVisits.EngineerVisit engineerVisit in oJobOfWork.EngineerVisits)
                {
                    engineerVisit.SetJobOfWorkID = oJobOfWork.JobOfWorkID;
                    _database.EngineerVisits.Insert(engineerVisit, oJobOfWork.JobID);
                }

                return oJobOfWork;
            }

            public void Update_PONumber(JobOfWork oJobOfWork)
            {
                if (oJobOfWork.PriorityDateSet == DateTime.MinValue)
                {
                    oJobOfWork.PriorityDateSet = DateTime.Now;
                }

                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", oJobOfWork.JobOfWorkID, true);
                _database.AddParameter("@PONumber ", oJobOfWork.PONumber, true);
                _database.AddParameter("@Priority", oJobOfWork.Priority, true);
                _database.AddParameter("@PriorityDateSet", oJobOfWork.PriorityDateSet, true);
                _database.AddParameter("@QualificationID", oJobOfWork.QualificationID, true);
                _database.ExecuteSP_NO_Return("JobOfWork_Update_PONumber");
            }

            public void Update_PONumber(JobOfWork oJobOfWork, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobOfWork_Update_PONumber";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.Add(new SqlParameter("@JobOfWorkID", oJobOfWork.JobOfWorkID));
                Command.Parameters.Add(new SqlParameter("@PONumber", oJobOfWork.PONumber));
                Command.Parameters.Add(new SqlParameter("@QualificationID", oJobOfWork.QualificationID));
                Command.Parameters.Add(new SqlParameter("@Priority", oJobOfWork.Priority));
                if (oJobOfWork.PriorityDateSet == DateTime.MinValue)
                {
                    Command.Parameters.Add(new SqlParameter("@PriorityDateSet", DBNull.Value));
                }
                else
                {
                    Command.Parameters.Add(new SqlParameter("@PriorityDateSet", oJobOfWork.PriorityDateSet));
                }

                Command.ExecuteNonQuery();
            }

            public void Update_Status(int JobOfWorkID, int Status)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                _database.AddParameter("@Status ", Status, true);
                _database.ExecuteSP_NO_Return("JobOfWork_Update_Status");
            }

            public void Update_Priority(JobOfWork Jow)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", Jow.JobOfWorkID, true);
                _database.AddParameter("@Priority ", Jow.Priority, true);
                _database.AddParameter("@PriorityDateSet ", Jow.PriorityDateSet, true);
                _database.AddParameter("@QualificationID ", Jow.QualificationID, true);
                _database.ExecuteSP_NO_Return("JobOfWork_Update_Priority");
            }

            public DataView JobOfWork_Get_For_Job(int JobID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", JobID, true);
                var dt = _database.ExecuteSP_DataTable("JobOfWork_Get_For_Job");
                dt.TableName = Enums.TableNames.tblJobOfWork.ToString();
                return new DataView(dt);
            }

            public DataView JobOfWork_Get_For_Job(int JobID, SqlTransaction trans)
            {
                var Command = new SqlCommand();
                Command.CommandText = "JobOfWork_Get_For_Job";
                Command.CommandType = CommandType.StoredProcedure;
                Command.Transaction = trans;
                Command.Connection = trans.Connection;
                Command.Parameters.AddWithValue("@JobID", JobID);
                var Adapter = new SqlDataAdapter(Command);
                var returnDS = new DataSet();
                Adapter.Fill(returnDS);
                var dt = returnDS.Tables[0];
                dt.TableName = Enums.TableNames.tblJobOfWork.ToString();
                return new DataView(dt);
            }

            public DataTable JobOfWork_Get_ForEngineerVisitID(int engineerVisitId)
            {
                var dt = new DataTable();
                var command = new SqlCommand("JobOfWork_Get_ForEngineerVisitID", new SqlConnection(_database.ServerConnectionString));
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EngineerVisitID", engineerVisitId);
                    dt = _database.ExecuteCommand_DataTable(command);
                    dt.TableName = "tblJobOfWork";
                    return dt;
                }
                catch (Exception ex)
                {
                    return dt;
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            public JobOfWork JobOfWork_Get(int JobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", JobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("JobOfWork_Get");
                JobOfWork jobOfWork = null;
                if (dt.Rows.Count > 0)
                {
                    jobOfWork = new JobOfWork();
                    {
                        var withBlock = dt.Rows[0];
                        jobOfWork.IgnoreExceptionsOnSetMethods = true;
                        jobOfWork.Exists = true;
                        jobOfWork.SetJobOfWorkID = withBlock["JobOFWorkID"];
                        jobOfWork.SetJobID = withBlock["JobID"];
                        jobOfWork.SetPONumber = withBlock["PONumber"];
                        jobOfWork.SetDeleted = Conversions.ToBoolean(withBlock["Deleted"]);
                        jobOfWork.SetStatus = Helper.MakeIntegerValid(withBlock["Status"]);
                        jobOfWork.SetPriority = Helper.MakeIntegerValid(withBlock["Priority"]);
                        jobOfWork.PriorityDateSet = Helper.MakeDateTimeValid(withBlock["PriorityDateSet"]);
                        if (dt.Rows[0].Table.Columns.Contains("QualificationID"))
                            jobOfWork.SetQualificationID = Helper.MakeIntegerValid(withBlock["QualificationID"]);
                    }
                }

                return jobOfWork;
            }

            public JobOfWork JobOfWork_Get_As_Object(int jobOfWorkID)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID", jobOfWorkID, true);
                var dt = _database.ExecuteSP_DataTable("JobOfWork_Get");
                JobOfWork jobOfWork = null;
                if (dt.Rows.Count > 0)
                {
                    jobOfWork = new JobOfWork();
                    {
                        var withBlock = dt.Rows[0];
                        jobOfWork.IgnoreExceptionsOnSetMethods = true;
                        jobOfWork.Exists = true;
                        jobOfWork.SetJobOfWorkID = withBlock["JobOFWorkID"];
                        jobOfWork.SetJobID = withBlock["JobID"];
                        jobOfWork.SetPONumber = withBlock["PONumber"];
                        jobOfWork.SetDeleted = Conversions.ToBoolean(withBlock["Deleted"]);
                        jobOfWork.SetStatus = Helper.MakeIntegerValid(withBlock["Status"]);
                        jobOfWork.SetPriority = Helper.MakeIntegerValid(withBlock["Priority"]);
                        jobOfWork.PriorityDateSet = Helper.MakeDateTimeValid(withBlock["PriorityDateSet"]);
                        if (dt.Rows[0].Table.Columns.Contains("QualificationID"))
                            jobOfWork.SetQualificationID = Helper.MakeIntegerValid(withBlock["QualificationID"]);
                        jobOfWork.JobItems = _database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID);
                        jobOfWork.EngineerVisits = _database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(jobOfWork.JobOfWorkID);
                    }
                }

                return jobOfWork;
            }

            public ArrayList JobOfWork_Get_For_Job_As_Objects(int JobID, SqlTransaction trans)
            {
                var jobOfWorks = new ArrayList();
                foreach (DataRow row in JobOfWork_Get_For_Job(JobID, trans).Table.Rows)
                {
                    var jobOfWork = new JobOfWork();
                    jobOfWork.IgnoreExceptionsOnSetMethods = true;
                    jobOfWork.Exists = true;
                    jobOfWork.SetJobOfWorkID = row["JobOFWorkID"];
                    jobOfWork.SetJobID = row["JobID"];
                    jobOfWork.SetPONumber = row["PONumber"];
                    jobOfWork.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
                    jobOfWork.SetStatus = Helper.MakeIntegerValid(row["Status"]);
                    jobOfWork.SetPriority = Helper.MakeIntegerValid(row["Priority"]);
                    jobOfWork.PriorityDateSet = Helper.MakeDateTimeValid(row["PriorityDateSet"]);
                    if (row.Table.Columns.Contains("QualificationID"))
                        jobOfWork.SetQualificationID = Helper.MakeIntegerValid(row["QualificationID"]);
                    jobOfWork.JobItems = _database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID, trans);
                    jobOfWork.EngineerVisits = _database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID, trans);
                    jobOfWorks.Add(jobOfWork);
                }

                return jobOfWorks;
            }

            public ArrayList JobOfWork_Get_For_Job_As_Objects(int JobID)
            {
                var jobOfWorks = new ArrayList();
                foreach (DataRow row in JobOfWork_Get_For_Job(JobID).Table.Rows)
                {
                    var jobOfWork = new JobOfWork();
                    jobOfWork.IgnoreExceptionsOnSetMethods = true;
                    jobOfWork.Exists = true;
                    jobOfWork.SetJobOfWorkID = row["JobOFWorkID"];
                    jobOfWork.SetJobID = row["JobID"];
                    jobOfWork.SetPONumber = row["PONumber"];
                    jobOfWork.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
                    jobOfWork.SetStatus = Helper.MakeIntegerValid(row["Status"]);
                    jobOfWork.SetPriority = Helper.MakeIntegerValid(row["Priority"]);
                    jobOfWork.PriorityDateSet = Helper.MakeDateTimeValid(row["PriorityDateSet"]);
                    if (row.Table.Columns.Contains("QualificationID"))
                        jobOfWork.SetQualificationID = Helper.MakeIntegerValid(row["QualificationID"]);
                    jobOfWork.JobItems = _database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID);
                    jobOfWork.EngineerVisits = _database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(jobOfWork.JobOfWorkID);
                    jobOfWorks.Add(jobOfWork);
                }

                return jobOfWorks;
            }

            public void Update_PONumberByJobOfWorkID(int jobOfWorkId, string poNumber)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobOfWorkID ", jobOfWorkId, true);
                _database.AddParameter("@PONumber ", poNumber, true);
                _database.ExecuteSP_NO_Return("JobOfWork_Update_PONumberByJobOfWorkID");
            }

            public List<JobOfWork> Get_ByJobId(int jobId)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobId, true);
                var dt = _database.ExecuteSP_DataTable("JobOfWork_Get_For_Job");
                if (dt is object && dt.Rows.Count > 0)
                {
                    var jobOfWorks = (from x in dt.AsEnumerable()
                                      select new JobOfWork()
                                      {
                                          Exists = true,
                                          SetJobOfWorkID = Helper.MakeIntegerValid(x["JobOfWorkId"]),
                                          SetJobID = Helper.MakeIntegerValid(x["JobId"]),
                                          SetPONumber = Helper.MakeStringValid(x["PONumber"]),
                                          SetPriority = Helper.MakeIntegerValid(x["Priority"]),
                                          SetStatus = Helper.MakeIntegerValid(x["Status"]),
                                          PriorityDateSet = Helper.MakeDateTimeValid(x["PriorityDateSet"]),
                                          SetQualificationID = Helper.MakeIntegerValid(x["QualificationID"])
                                      }).ToList();
                    return jobOfWorks;
                }
                else
                {
                    return null;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}