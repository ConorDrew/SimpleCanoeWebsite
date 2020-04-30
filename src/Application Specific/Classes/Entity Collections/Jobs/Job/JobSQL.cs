using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.Jobs
{
    public class JobSQL
    {
        private Database _database;

        public JobSQL(Database database)
        {
            _database = database;
        }

        public void DeleteReservedOrderNumber(int JobNumber, string Prefix)
        {
            string sql;
            sql = "DELETE FROM tblJobNumber WHERE JobNumber = " + JobNumber + " AND Prefix = '" + Prefix + "'";
            App.DB.ExecuteWithOutReturn(sql);
        }

        public JobNumber GetNextJobNumber(Enums.JobDefinition JobDefinition)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobDefinition", Conversions.ToInteger(JobDefinition), true);
            var dt = App.DB.ExecuteSP_DataTable("JobNumber_Get");
            var oJobNumber = new JobNumber(Conversions.ToInteger(dt.Rows[0]["JobNumber"]), Conversions.ToString(dt.Rows[0]["prefix"]));
            return oJobNumber;
        }

        public JobNumber GetNextJobNumber(Enums.JobDefinition JobDefinition, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "JobNumber_Get";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@JobDefinition", JobDefinition);
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);
            var dt = returnDS.Tables[0];
            var oJobNumber = new JobNumber(Conversions.ToInteger(dt.Rows[0]["JobNumber"]), Conversions.ToString(dt.Rows[0]["prefix"]));
            return oJobNumber;
        }

        public Job Insert(Job oJob, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "Job_Insert";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.Add(new SqlParameter("@SiteID", oJob.PropertyID));
            Command.Parameters.Add(new SqlParameter("@JobDefinitionEnumID", oJob.JobDefinitionEnumID));
            Command.Parameters.Add(new SqlParameter("@JobTypeID", oJob.JobTypeID));
            Command.Parameters.Add(new SqlParameter("@CreatedByUserID", App.loggedInUser.UserID));
            Command.Parameters.Add(new SqlParameter("@JobNumber", oJob.JobNumber));
            Command.Parameters.Add(new SqlParameter("@PONumber", oJob.PONumber));
            Command.Parameters.Add(new SqlParameter("@QuoteID", oJob.QuoteID));
            Command.Parameters.Add(new SqlParameter("@ContractID", oJob.ContractID));
            Command.Parameters.Add(new SqlParameter("@ToBePartPaid", oJob.ToBePartPaid));
            Command.Parameters.Add(new SqlParameter("@Retention", oJob.Retention));
            Command.Parameters.Add(new SqlParameter("@CollectPayment", oJob.CollectPayment));
            Command.Parameters.Add(new SqlParameter("@POC", oJob.POC));
            Command.Parameters.Add(new SqlParameter("@OTI", oJob.OTI));
            Command.Parameters.Add(new SqlParameter("@FOC", oJob.FOC));
            Command.Parameters.Add(new SqlParameter("@SalesRepUserID", oJob.SalesRepUserID));
            Command.Parameters.Add(new SqlParameter("@JobCreationType", oJob.JobCreationType));
            Command.Parameters.Add(new SqlParameter("@Deleted", oJob.Deleted));
            Command.Parameters.Add(new SqlParameter("@Headline", oJob.Headline));
            oJob.SetJobID = Helper.MakeIntegerValid(Command.ExecuteScalar());
            oJob.Exists = true;
            foreach (JobAssets.JobAsset asset in oJob.Assets)
            {
                asset.SetJobID = oJob.JobID;
                _database.JobAsset.Insert(asset, trans);
            }

            foreach (JobOfWorks.JobOfWork jobOfWork in oJob.JobOfWorks)
            {
                jobOfWork.SetJobID = oJob.JobID;
                _database.JobOfWorks.Insert(jobOfWork, trans);
            }

            JobQualificationsLevels_Insert(oJob, trans);
            JobSheets_Insert(oJob, trans);
            var jA = new JobAudits.JobAudit();
            jA.SetJobID = oJob.JobID;
            jA.SetActionChange = "Job Created";
            App.DB.JobAudit.Insert(jA, trans);

            // GET THE JOB COMPLETELY
            return App.DB.Job.Job_Get(oJob.JobID, trans);
        }

        public Job Insert(Job oJob)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", oJob.PropertyID, true);
            _database.AddParameter("@JobDefinitionEnumID", oJob.JobDefinitionEnumID, true);
            _database.AddParameter("@JobTypeID", oJob.JobTypeID, true);
            _database.AddParameter("@CreatedByUserID", App.loggedInUser.UserID, true);
            _database.AddParameter("@JobNumber", oJob.JobNumber, true);
            _database.AddParameter("@PONumber", oJob.PONumber, true);
            _database.AddParameter("@QuoteID", oJob.QuoteID, true);
            _database.AddParameter("@ContractID", oJob.ContractID, true);
            _database.AddParameter("@ToBePartPaid", oJob.ToBePartPaid, true);
            _database.AddParameter("@Retention", oJob.Retention, true);
            _database.AddParameter("@CollectPayment", oJob.CollectPayment, true);
            _database.AddParameter("@POC", oJob.POC, true);
            _database.AddParameter("@OTI", oJob.OTI, true);
            _database.AddParameter("@FOC", oJob.FOC, true);
            _database.AddParameter("@SalesRepUserID", oJob.SalesRepUserID, true);
            _database.AddParameter("@JobCreationType", oJob.JobCreationType, true);
            _database.AddParameter("@Deleted", oJob.Deleted, true);
            oJob.SetJobID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Job_Insert"));
            oJob.Exists = true;
            foreach (JobAssets.JobAsset asset in oJob.Assets)
            {
                asset.SetJobID = oJob.JobID;
                _database.JobAsset.Insert(asset);
            }

            foreach (JobOfWorks.JobOfWork jobOfWork in oJob.JobOfWorks)
            {
                jobOfWork.SetJobID = oJob.JobID;
                _database.JobOfWorks.Insert(jobOfWork);
            }

            JobQualificationsLevels_Insert(oJob);
            JobSheets_Insert(oJob);
            var jA = new JobAudits.JobAudit();
            jA.SetJobID = oJob.JobID;
            jA.SetActionChange = "Job Created";
            App.DB.JobAudit.Insert(jA);

            // GET THE JOB COMPLETELY
            return App.DB.Job.Job_Get(oJob.JobID);
        }

        public Job Update(Job oJob, ArrayList JobOfWorksRemoved, ArrayList EngineerVisitsRemoved, ArrayList EngineerVisitsOrdersRemoved, SqlTransaction trans)
        {
            foreach (int item in JobOfWorksRemoved)
                _database.JobOfWorks.Delete(item, trans);
            foreach (int item in EngineerVisitsRemoved)
                _database.EngineerVisits.Delete(item, trans);
            foreach (int item in EngineerVisitsOrdersRemoved)
                _database.Order.Delete(item, trans);
            var Command = new SqlCommand();
            Command.CommandText = "Job_Update";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.Add(new SqlParameter("@JobTypeID", oJob.JobTypeID));
            Command.Parameters.Add(new SqlParameter("@JobID", oJob.JobID));
            Command.Parameters.Add(new SqlParameter("@PONumber", oJob.PONumber));
            Command.Parameters.Add(new SqlParameter("@FOC", oJob.FOC));
            Command.Parameters.Add(new SqlParameter("@OTI", oJob.OTI));
            Command.Parameters.Add(new SqlParameter("@POC", oJob.POC));
            Command.Parameters.Add(new SqlParameter("@SalesRepUserID", oJob.SalesRepUserID));
            Command.Parameters.Add(new SqlParameter("@JobCreationType", oJob.JobCreationType));
            Command.Parameters.Add(new SqlParameter("@Headline", oJob.Headline));
            Command.ExecuteNonQuery();
            foreach (JobAssets.JobAsset asset in oJob.Assets)
            {
                asset.SetJobID = oJob.JobID;
                _database.JobAsset.Insert(asset, trans);
            }

            foreach (JobOfWorks.JobOfWork jobOfWork in oJob.JobOfWorks)
            {
                jobOfWork.SetJobID = oJob.JobID;
                if (!jobOfWork.Exists)
                {
                    _database.JobOfWorks.Insert(jobOfWork, trans);
                }
                else
                {
                    _database.JobOfWorks.Update_PONumber(jobOfWork, trans);
                    string IDs = "";
                    foreach (JobItems.JobItem jobItem in jobOfWork.JobItems)
                    {
                        jobItem.SetJobOfWorkID = jobOfWork.JobOfWorkID;
                        _database.JobItems.Insert(jobItem, trans);
                        IDs += jobItem.JobItemID + ",";
                    }
                    // DELETE ANY JOB ITEMS  NOT JUST UPDATED OR INSERTED
                    if (IDs.Length > 0)
                    {
                        IDs = IDs.Substring(0, IDs.Length - 1);
                    }
                    // If IDs.Length > 0 Then
                    _database.JobItems.Delete(IDs, jobOfWork.JobOfWorkID, trans);
                    // End If
                    foreach (EngineerVisits.EngineerVisit engineerVisit in jobOfWork.EngineerVisits)
                    {
                        engineerVisit.SetJobOfWorkID = jobOfWork.JobOfWorkID;
                        if (!engineerVisit.Exists)
                        {
                            _database.EngineerVisits.Insert(engineerVisit, jobOfWork.JobID, trans);
                        }
                        else
                        {
                            _database.EngineerVisits.Update(engineerVisit, jobOfWork.JobID, false, trans);
                        }
                    }
                }
            }

            JobQualificationsLevels_Insert(oJob, trans);
            JobSheets_Insert(oJob, trans);
            return Job_Get(oJob.JobID, trans);
        }

        public Job Update(Job oJob, ArrayList JobOfWorksRemoved, ArrayList EngineerVisitsRemoved, ArrayList EngineerVisitsOrdersRemoved)
        {
            foreach (int item in JobOfWorksRemoved)
                _database.JobOfWorks.Delete(item);
            foreach (int item in EngineerVisitsRemoved)
                _database.EngineerVisits.Delete(item);
            foreach (int item in EngineerVisitsOrdersRemoved)
                _database.Order.Delete(item);
            _database.ClearParameter();
            _database.AddParameter("@JobTypeID", oJob.JobTypeID, true);
            _database.AddParameter("@PONumber", oJob.PONumber, true);
            _database.AddParameter("@JobID", oJob.JobID, true);
            _database.AddParameter("@FOC", oJob.FOC, true);
            _database.AddParameter("@OTI", oJob.OTI, true);
            _database.AddParameter("@POC", oJob.POC, true);
            _database.AddParameter("@SalesRepUserID", oJob.SalesRepUserID, true);
            _database.AddParameter("@JobCreationType", oJob.JobCreationType, true);
            _database.AddParameter("@Headline", oJob.Headline, true);
            _database.ExecuteSP_NO_Return("Job_Update");
            foreach (JobAssets.JobAsset asset in oJob.Assets)
            {
                asset.SetJobID = oJob.JobID;
                _database.JobAsset.Insert(asset);
            }

            foreach (JobOfWorks.JobOfWork jobOfWork in oJob.JobOfWorks)
            {
                jobOfWork.SetJobID = oJob.JobID;
                if (!jobOfWork.Exists)
                {
                    _database.JobOfWorks.Insert(jobOfWork);
                }
                else
                {
                    _database.JobOfWorks.Update_PONumber(jobOfWork);
                    string IDs = "";
                    foreach (JobItems.JobItem jobItem in jobOfWork.JobItems)
                    {
                        jobItem.SetJobOfWorkID = jobOfWork.JobOfWorkID;
                        _database.JobItems.Insert(jobItem);
                        IDs += jobItem.JobItemID + ",";
                    }
                    // DELETE ANY JOB ITEMS  NOT JUST UPDATED OR INSERTED
                    if (IDs.Length > 0)
                    {
                        IDs = IDs.Substring(0, IDs.Length - 1);
                    }
                    // If IDs.Length > 0 Then
                    _database.JobItems.Delete(IDs, jobOfWork.JobOfWorkID);
                    // End If
                    foreach (EngineerVisits.EngineerVisit engineerVisit in jobOfWork.EngineerVisits)
                    {
                        engineerVisit.SetJobOfWorkID = jobOfWork.JobOfWorkID;
                        if (!engineerVisit.Exists)
                        {
                            _database.EngineerVisits.Insert(engineerVisit, jobOfWork.JobID);
                        }
                        else
                        {
                            _database.EngineerVisits.Update(engineerVisit, jobOfWork.JobID, false);
                        }
                    }
                }
            }

            JobQualificationsLevels_Insert(oJob);
            JobSheets_Insert(oJob);
            return Job_Get(oJob.JobID);
        }

        public Job Update(Job oJob)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobTypeID", oJob.JobTypeID, true);
            _database.AddParameter("@PONumber", oJob.PONumber, true);
            _database.AddParameter("@JobID", oJob.JobID, true);
            _database.AddParameter("@FOC", oJob.FOC, true);
            _database.AddParameter("@OTI", oJob.OTI, true);
            _database.AddParameter("@POC", oJob.POC, true);
            _database.AddParameter("@SalesRepUserID", oJob.SalesRepUserID, true);
            _database.AddParameter("@JobCreationType", oJob.JobCreationType, true);
            _database.AddParameter("@Headline", oJob.Headline, true);
            _database.ExecuteSP_NO_Return("Job_Update");
            _database.JobAsset.Delete(oJob.JobID);
            foreach (JobAssets.JobAsset asset in oJob.Assets)
            {
                asset.SetJobID = oJob.JobID;
                _database.JobAsset.Insert(asset);
            }

            foreach (JobOfWorks.JobOfWork jobOfWork in oJob.JobOfWorks)
            {
                jobOfWork.SetJobID = oJob.JobID;
                if (!jobOfWork.Exists)
                {
                    _database.JobOfWorks.Insert(jobOfWork);
                }
                else
                {
                    _database.JobOfWorks.Update_PONumber(jobOfWork);
                    string IDs = "";
                    foreach (JobItems.JobItem jobItem in jobOfWork.JobItems)
                    {
                        jobItem.SetJobOfWorkID = jobOfWork.JobOfWorkID;
                        _database.JobItems.Insert(jobItem);
                        IDs += jobItem.JobItemID + ",";
                    }
                    // DELETE ANY JOB ITEMS  NOT JUST UPDATED OR INSERTED
                    if (IDs.Length > 0)
                    {
                        IDs = IDs.Substring(0, IDs.Length - 1);
                    }
                    // If IDs.Length > 0 Then
                    _database.JobItems.Delete(IDs, jobOfWork.JobOfWorkID);
                    // End If

                    foreach (EngineerVisits.EngineerVisit engineerVisit in jobOfWork.EngineerVisits)
                    {
                        engineerVisit.SetJobOfWorkID = jobOfWork.JobOfWorkID;
                        if (!engineerVisit.Exists)
                        {
                            _database.EngineerVisits.Insert(engineerVisit, jobOfWork.JobID);
                        }
                        else
                        {
                            _database.EngineerVisits.Update(engineerVisit, jobOfWork.JobID, false);
                        }
                    }
                }
            }

            JobQualificationsLevels_Insert(oJob);
            JobSheets_Insert(oJob);
            return Job_Get(oJob.JobID);
        }

        public bool Job_WasGeneratedByLetter(int JobID)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", JobID, true);
            var dt = _database.ExecuteSP_DataTable("Job_Get_Generated_By_Letter");
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataView Job_Get_All(string whereClause)
        {
            _database.ClearParameter();
            _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, true);
            _database.AddParameter("@whereClause", whereClause, true);
            var dt = _database.ExecuteSP_DataTable("Job_Get_All");
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView Job_Manager_Search(DateTime dateFrom, DateTime dateTo, string jobNumber, string postcode, int jobTypeId, int customerId, int siteId, int statusEnumId, int regionId, string poNumber, bool isJobOpen)
        {
            _database.ClearParameter();
            _database.AddParameter("@DateFrom", Helper.InsertDateIntoDb(dateFrom), true);
            _database.AddParameter("@DateTo", Helper.InsertDateIntoDb(dateTo), true);
            _database.AddParameter("@JobNumber", jobNumber, true);
            _database.AddParameter("@PostCode", postcode, true);
            _database.AddParameter("@JobTypeID", jobTypeId, true);
            _database.AddParameter("@CustomerID", customerId, true);
            _database.AddParameter("@SiteID", siteId, true);
            _database.AddParameter("@StatusEnumID", statusEnumId, true);
            _database.AddParameter("@RegionID", regionId, true);
            _database.AddParameter("@PoNumber", poNumber, true);
            _database.AddParameter("@IsJobOpen", isJobOpen, true);
            var dt = _database.ExecuteSP_DataTable("Job_Manager_Search");
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView Search(string Criteria, int userId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SearchString", Criteria, true);
            _database.AddParameter("@UserID", userId, true);
            var dt = _database.ExecuteSP_DataTable("Job_Search_Mk1");
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView Job_GetTop100_For_Site(int SiteID, int customerID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            _database.AddParameter("@CustomerID", customerID, true);
            _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, true);
            var dt = _database.ExecuteSP_DataTable("Job_GetTop100_For_Site_New");
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView Job_GetTop_For_Site(int SiteID, int customerID, int top)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            _database.AddParameter("@CustomerID", customerID, true);
            _database.AddParameter("@Top", top, true);
            _database.AddParameter("@InvoiceTypeIDEnum", Enums.InvoiceType.Visit, true);
            var dt = _database.ExecuteSP_DataTable("Job_GetTop_For_Site_New");
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView Job_GetAll_For_Asset(int AssetID)
        {
            _database.ClearParameter();
            _database.AddParameter("@AssetID", AssetID, true);
            var dt = _database.ExecuteSP_DataTable("Job_GetAll_For_Asset");
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public Job Job_Get(int JobID, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "Job_Get";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@JobID", JobID);
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);
            var dt = returnDS.Tables[0];
            if (dt.Rows.Count > 0)
            {
                var job = new Job();
                job.IgnoreExceptionsOnSetMethods = true;
                job.Exists = true;
                job.SetJobID = dt.Rows[0]["JobID"];
                job.SetPropertyID = dt.Rows[0]["SiteID"];
                job.SetJobDefinitionEnumID = dt.Rows[0]["JobDefinitionEnumID"];
                job.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                job.SetStatusEnumID = dt.Rows[0]["StatusEnumID"];
                job.DateCreated = Conversions.ToDate(dt.Rows[0]["DateCreated"]);
                job.SetCreatedByUserID = dt.Rows[0]["CreatedByUserID"];
                job.SetJobNumber = dt.Rows[0]["JobNumber"];
                job.SetPONumber = dt.Rows[0]["PONumber"];
                job.SetQuoteID = dt.Rows[0]["QuoteID"];
                job.SetContractID = dt.Rows[0]["ContractID"];
                job.SetToBePartPaid = dt.Rows[0]["ToBePartPaid"];
                job.SetRetention = dt.Rows[0]["Retention"];
                job.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID, trans);
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID, trans);
                job.JobQualificationsLevels = JobQualificationsLevels_Get(job.JobID, trans);
                job.JobSheets = JobSheets_Get(job.JobID, trans);
                job.SetCollectPayment = dt.Rows[0]["CollectPayment"];
                job.SetPOC = dt.Rows[0]["POC"];
                job.SetOTI = dt.Rows[0]["OTI"];
                job.SetFOC = dt.Rows[0]["FOC"];
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows[0]["SalesRepUserID"]);
                if (dt.Columns.Contains("JobCreationType"))
                {
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows[0]["JobCreationType"]);
                }

                return job;
            }
            else
            {
                return null;
            }
        }

        public Job Job_Get(int JobID)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", JobID, true);
            var dt = _database.ExecuteSP_DataTable("Job_Get");
            if (dt.Rows.Count > 0)
            {
                var job = new Job();
                job.IgnoreExceptionsOnSetMethods = true;
                job.Exists = true;
                job.SetJobID = dt.Rows[0]["JobID"];
                job.SetPropertyID = dt.Rows[0]["SiteID"];
                job.SetJobDefinitionEnumID = dt.Rows[0]["JobDefinitionEnumID"];
                job.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                job.SetStatusEnumID = dt.Rows[0]["StatusEnumID"];
                job.DateCreated = Conversions.ToDate(dt.Rows[0]["DateCreated"]);
                job.SetCreatedByUserID = dt.Rows[0]["CreatedByUserID"];
                job.SetJobNumber = dt.Rows[0]["JobNumber"];
                job.SetPONumber = dt.Rows[0]["PONumber"];
                job.SetQuoteID = dt.Rows[0]["QuoteID"];
                job.SetContractID = dt.Rows[0]["ContractID"];
                job.SetToBePartPaid = dt.Rows[0]["ToBePartPaid"];
                job.SetRetention = dt.Rows[0]["Retention"];
                job.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID);
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID);
                job.JobQualificationsLevels = JobQualificationsLevels_Get(job.JobID);
                job.JobSheets = JobSheets_Get(job.JobID);
                job.SetCollectPayment = dt.Rows[0]["CollectPayment"];
                job.SetPOC = dt.Rows[0]["POC"];
                job.SetOTI = dt.Rows[0]["OTI"];
                job.SetFOC = dt.Rows[0]["FOC"];
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows[0]["SalesRepUserID"]);
                if (dt.Columns.Contains("JobCreationType"))
                {
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows[0]["JobCreationType"]);
                }

                job.SetHeadline = dt.Rows[0]["Headline"];
                return job;
            }
            else
            {
                return null;
            }
        }

        public Job Get(int id, GetBy getBy = GetBy.JobId)
        {
            _database.ClearParameter();
            // Get the datatable from the database store in dt
            DataTable dt = null;
            switch (getBy)
            {
                case GetBy.EngineerVisitId:
                    {
                        _database.AddParameter("@EngineerVisitID", Helper.MakeIntegerValid(id), true);
                        dt = _database.ExecuteSP_DataTable("Job_Get_For_An_EngineerVisit_ID");
                        break;
                    }

                default:
                    {
                        _database.AddParameter("@JobID", Helper.MakeIntegerValid(id));
                        dt = _database.ExecuteSP_DataTable("Job_Get");
                        break;
                    }
            }

            if (dt is object && dt.Rows.Count > 0)
            {
                var job = new Job();
                job.IgnoreExceptionsOnSetMethods = true;
                job.Exists = true;
                job.SetJobID = dt.Rows[0]["JobID"];
                job.SetPropertyID = dt.Rows[0]["SiteID"];
                job.SetJobDefinitionEnumID = dt.Rows[0]["JobDefinitionEnumID"];
                job.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                job.SetStatusEnumID = dt.Rows[0]["StatusEnumID"];
                job.DateCreated = Conversions.ToDate(dt.Rows[0]["DateCreated"]);
                job.SetCreatedByUserID = dt.Rows[0]["CreatedByUserID"];
                job.SetJobNumber = dt.Rows[0]["JobNumber"];
                if (dt.Columns.Contains("PONumber"))
                    job.SetPONumber = dt.Rows[0]["PONumber"];
                job.SetQuoteID = dt.Rows[0]["QuoteID"];
                job.SetContractID = dt.Rows[0]["ContractID"];
                job.SetToBePartPaid = dt.Rows[0]["ToBePartPaid"];
                job.SetRetention = dt.Rows[0]["Retention"];
                job.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                job.SetCollectPayment = dt.Rows[0]["CollectPayment"];
                job.SetPOC = dt.Rows[0]["POC"];
                job.SetOTI = dt.Rows[0]["OTI"];
                job.SetFOC = dt.Rows[0]["FOC"];
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows[0]["SalesRepUserID"]);
                if (dt.Columns.Contains("JobCreationType"))
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows[0]["JobCreationType"]);
                if (dt.Columns.Contains("Headline"))
                    job.SetHeadline = dt.Rows[0]["Headline"];
                return job;
            }
            else
            {
                return null;
            }
        }

        public Job Job_Get_ByOrderID(int orderID)
        {
            _database.ClearParameter();
            _database.AddParameter("@OrderID", orderID, true);
            var dt = _database.ExecuteSP_DataTable("Job_Get_ByOrderID");
            if (dt.Rows.Count > 0)
            {
                var job = new Job();
                job.IgnoreExceptionsOnSetMethods = true;
                job.Exists = true;
                job.SetJobID = dt.Rows[0]["JobID"];
                job.SetPropertyID = dt.Rows[0]["SiteID"];
                job.SetJobDefinitionEnumID = dt.Rows[0]["JobDefinitionEnumID"];
                job.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                job.SetStatusEnumID = dt.Rows[0]["StatusEnumID"];
                job.DateCreated = Conversions.ToDate(dt.Rows[0]["DateCreated"]);
                job.SetCreatedByUserID = dt.Rows[0]["CreatedByUserID"];
                job.SetJobNumber = dt.Rows[0]["JobNumber"];
                job.SetPONumber = dt.Rows[0]["PONumber"];
                job.SetQuoteID = dt.Rows[0]["QuoteID"];
                job.SetContractID = dt.Rows[0]["ContractID"];
                job.SetToBePartPaid = dt.Rows[0]["ToBePartPaid"];
                job.SetRetention = dt.Rows[0]["Retention"];
                job.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID);
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID);
                job.JobQualificationsLevels = JobQualificationsLevels_Get(job.JobID);
                job.JobSheets = JobSheets_Get(job.JobID);
                job.SetCollectPayment = dt.Rows[0]["CollectPayment"];
                job.SetPOC = dt.Rows[0]["POC"];
                job.SetOTI = dt.Rows[0]["OTI"];
                job.SetFOC = dt.Rows[0]["FOC"];
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows[0]["SalesRepUserID"]);
                if (dt.Columns.Contains("JobCreationType"))
                {
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows[0]["JobCreationType"]);
                }

                return job;
            }
            else
            {
                return null;
            }
        }

        public Job Job_Get_For_Quote_ID(int QuoteJobID)
        {
            _database.ClearParameter();
            _database.AddParameter("@QuoteJobID", QuoteJobID, true);
            var dt = _database.ExecuteSP_DataTable("Job_Get_For_Quote_ID");
            if (dt.Rows.Count > 0)
            {
                var job = new Job();
                job.IgnoreExceptionsOnSetMethods = true;
                job.Exists = true;
                job.SetJobID = dt.Rows[0]["JobID"];
                job.SetPropertyID = dt.Rows[0]["SiteID"];
                job.SetJobDefinitionEnumID = dt.Rows[0]["JobDefinitionEnumID"];
                job.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                job.SetStatusEnumID = dt.Rows[0]["StatusEnumID"];
                job.DateCreated = Conversions.ToDate(dt.Rows[0]["DateCreated"]);
                job.SetCreatedByUserID = dt.Rows[0]["CreatedByUserID"];
                job.SetJobNumber = dt.Rows[0]["JobNumber"];
                job.SetPONumber = dt.Rows[0]["PONumber"];
                job.SetQuoteID = dt.Rows[0]["QuoteID"];
                job.SetContractID = dt.Rows[0]["ContractID"];
                job.SetToBePartPaid = dt.Rows[0]["ToBePartPaid"];
                job.SetRetention = dt.Rows[0]["Retention"];
                job.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID);
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID);
                job.SetCollectPayment = dt.Rows[0]["CollectPayment"];
                job.SetCollectPayment = dt.Rows[0]["POC"];
                job.SetOTI = dt.Rows[0]["OTI"];
                job.SetFOC = dt.Rows[0]["FOC"];
                job.SetHeadline = dt.Rows[0]["Headline"];
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows[0]["SalesRepUserID"]);
                if (dt.Columns.Contains("JobCreationType"))
                {
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows[0]["JobCreationType"]);
                }

                JobQualificationsLevels_Get(job.JobID);
                job.JobSheets = JobSheets_Get(job.JobID);
                return job;
            }
            else
            {
                return null;
            }
        }

        public Job Job_Get_For_An_EngineerVisit_ID(int engineerVisitID, SqlTransaction trans)
        {
            // THIS ONLY GETS tblJob INFO NOT THE RELATED ENTITIES - Assets, JOW's etc
            var Command = new SqlCommand();
            Command.CommandText = "Job_Get_For_An_EngineerVisit_ID";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.Add(new SqlParameter("@engineerVisitID", engineerVisitID));
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);
            var dt = returnDS.Tables[0];
            if (dt.Rows.Count > 0)
            {
                var job = new Job();
                job.IgnoreExceptionsOnSetMethods = true;
                job.Exists = true;
                job.SetJobID = dt.Rows[0]["JobID"];
                job.SetPropertyID = dt.Rows[0]["SiteID"];
                job.SetJobDefinitionEnumID = dt.Rows[0]["JobDefinitionEnumID"];
                job.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                job.SetStatusEnumID = dt.Rows[0]["StatusEnumID"];
                job.DateCreated = Conversions.ToDate(dt.Rows[0]["DateCreated"]);
                job.SetCreatedByUserID = dt.Rows[0]["CreatedByUserID"];
                job.SetJobNumber = dt.Rows[0]["JobNumber"];
                job.SetPONumber = ""; // dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows[0]["QuoteID"];
                job.SetContractID = dt.Rows[0]["ContractID"];
                job.SetToBePartPaid = dt.Rows[0]["ToBePartPaid"];
                job.SetRetention = dt.Rows[0]["Retention"];
                job.SetCollectPayment = dt.Rows[0]["CollectPayment"];
                job.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                job.SetCollectPayment = dt.Rows[0]["POC"];
                job.SetOTI = dt.Rows[0]["OTI"];
                job.SetFOC = dt.Rows[0]["FOC"];
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows[0]["SalesRepUserID"]);
                if (dt.Columns.Contains("JobCreationType"))
                {
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows[0]["JobCreationType"]);
                }
                // job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID)
                // job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID)
                // JobQualificationsLevels_Get(job.JobID)
                // job.JobSheets = JobSheets_Get(job.JobID)
                job.SetHeadline = dt.Rows[0]["Headline"];
                return job;
            }
            else
            {
                return null;
            }
        }

        public Job Job_Get_For_An_EngineerVisit_ID(int engineerVisitID)
        {
            _database.ClearParameter();
            _database.AddParameter("@engineerVisitID", engineerVisitID, true);
            var dt = _database.ExecuteSP_DataTable("Job_Get_For_An_EngineerVisit_ID");
            if (dt.Rows.Count > 0)
            {
                var job = new Job();
                job.IgnoreExceptionsOnSetMethods = true;
                job.Exists = true;
                job.SetJobID = dt.Rows[0]["JobID"];
                job.SetPropertyID = dt.Rows[0]["SiteID"];
                job.SetJobDefinitionEnumID = dt.Rows[0]["JobDefinitionEnumID"];
                job.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                job.SetStatusEnumID = dt.Rows[0]["StatusEnumID"];
                job.DateCreated = Conversions.ToDate(dt.Rows[0]["DateCreated"]);
                job.SetCreatedByUserID = dt.Rows[0]["CreatedByUserID"];
                job.SetJobNumber = dt.Rows[0]["JobNumber"];
                job.SetPONumber = ""; // dt.Rows(0).Item("PONumber")
                job.SetQuoteID = dt.Rows[0]["QuoteID"];
                job.SetContractID = dt.Rows[0]["ContractID"];
                job.SetToBePartPaid = dt.Rows[0]["ToBePartPaid"];
                job.SetRetention = dt.Rows[0]["Retention"];
                job.SetCollectPayment = dt.Rows[0]["CollectPayment"];
                job.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                job.SetCollectPayment = dt.Rows[0]["POC"];
                job.SetOTI = dt.Rows[0]["OTI"];
                job.SetFOC = dt.Rows[0]["FOC"];
                job.SetHeadline = dt.Rows[0]["Headline"];
                job.SetSalesRepUserID = Helper.MakeIntegerValid(dt.Rows[0]["SalesRepUserID"]);
                if (dt.Columns.Contains("JobCreationType"))
                {
                    job.SetJobCreationType = Helper.MakeIntegerValid(dt.Rows[0]["JobCreationType"]);
                }

                job.Assets = _database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID);
                job.JobOfWorks = _database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID);
                JobQualificationsLevels_Get(job.JobID);
                job.JobSheets = JobSheets_Get(job.JobID);
                return job;
            }
            else
            {
                return null;
            }
        }

        public bool Job_Check_Before_Delete(int JobID)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", JobID, true);
            var dt = _database.ExecuteSP_DataTable("Job_Check_Before_Delete");
            foreach (DataRow row in dt.Rows)
            {
                if (Conversions.ToInteger(row["StatusEnumID"]) >= Conversions.ToInteger(Enums.VisitStatus.Scheduled))
                {
                    return false;
                }

                var dvVisitParts = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(Conversions.ToInteger(row["EngineerVisitID"]));
                if (dvVisitParts.Count > 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void Job_Delete(int JobID)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", JobID, true);
            _database.ExecuteSP_NO_Return("Job_Delete");
        }

        public void Job_Delete_BySite(int SiteID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            _database.ExecuteSP_NO_Return("Job_Delete_BySite");
        }

        public bool Job_MoveSite(int jobId, int oldSiteId, int newSiteId)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", jobId, true);
            _database.AddParameter("@OldSiteID", oldSiteId, true);
            _database.AddParameter("@NewSiteID", newSiteId, true);
            return Helper.MakeBooleanValid(_database.ExecuteSP_ReturnRowsAffected("Job_MoveSite") == 1);
        }

        public DataView JobQualificationsLevels_Get(int JobID)
        {
            var command = new SqlCommand("JobQualificationsLevels_Get", new SqlConnection(_database.ServerConnectionString));
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@JobID", JobID);
            var dt = _database.ExecuteCommand_DataTable(command);
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView JobQualificationsLevels_Get(int JobID, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "JobQualificationsLevels_Get";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@JobID", JobID);
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);
            var dt = returnDS.Tables[0];
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        private void JobQualificationsLevels_Insert(Job oJob)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", oJob.JobID, true);
            _database.ExecuteSP_NO_Return("JobQualificationsLevels_Delete");
            if (oJob.JobQualificationsLevels.Table is object)
            {
                foreach (DataRow r in oJob.JobQualificationsLevels.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Tick"], true, false)))
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@JobID", oJob.JobID, true);
                        _database.AddParameter("@QualificationLevelID", r["ManagerID"]);
                        _database.ExecuteSP_NO_Return("JobQualificationsLevels_Insert");
                    }
                }
            }
        }

        private void JobQualificationsLevels_Insert(Job oJob, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "JobQualificationsLevels_Delete";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@JobID", oJob.JobID);
            Command.ExecuteNonQuery();
            if (oJob.JobQualificationsLevels.Table is object)
            {
                foreach (DataRow r in oJob.JobQualificationsLevels.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Tick"], true, false)))
                    {
                        var CommandInsert = new SqlCommand();
                        CommandInsert.CommandText = "JobQualificationsLevels_Insert";
                        CommandInsert.CommandType = CommandType.StoredProcedure;
                        CommandInsert.Transaction = trans;
                        CommandInsert.Connection = trans.Connection;
                        CommandInsert.Parameters.AddWithValue("@JobID", oJob.JobID);
                        CommandInsert.Parameters.AddWithValue("@QualificationLevelID", r["ManagerID"]);
                        CommandInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        public DataView JobSheets_Get(int JobID)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", JobID, true);
            var dt = _database.ExecuteSP_DataTable("JobSheet_Get_JobID");
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView JobSheets_Get(int JobID, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "JobSheet_Get_JobID";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@JobID", JobID);
            var Adapter = new SqlDataAdapter(Command);
            var returnDS = new DataSet();
            Adapter.Fill(returnDS);
            var dt = returnDS.Tables[0];
            dt.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        private void JobSheets_Insert(Job oJob, SqlTransaction trans)
        {
            var Command = new SqlCommand();
            Command.CommandText = "JobSheet_Delete";
            Command.CommandType = CommandType.StoredProcedure;
            Command.Transaction = trans;
            Command.Connection = trans.Connection;
            Command.Parameters.AddWithValue("@JobID", oJob.JobID);
            Command.ExecuteNonQuery();
            if (oJob.JobSheets.Table is object)
            {
                foreach (DataRow r in oJob.JobSheets.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Tick"], true, false)))
                    {
                        var CommandInsert = new SqlCommand();
                        CommandInsert.CommandText = "JobSheet_Insert";
                        CommandInsert.CommandType = CommandType.StoredProcedure;
                        CommandInsert.Transaction = trans;
                        CommandInsert.Connection = trans.Connection;
                        CommandInsert.Parameters.AddWithValue("@JobID", oJob.JobID);
                        CommandInsert.Parameters.AddWithValue("@JobSheetID", r["JobSheetID"]);
                        CommandInsert.ExecuteNonQuery();
                    }
                }
            }
        }

        private void JobSheets_Insert(Job oJob)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", oJob.JobID, true);
            _database.ExecuteSP_NO_Return("JobSheet_Delete");
            if (oJob.JobSheets.Table is object)
            {
                foreach (DataRow r in oJob.JobSheets.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(r["Tick"], true, false)))
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@JobID", oJob.JobID, true);
                        _database.AddParameter("@JobSheetID", r["JobSheetID"]);
                        _database.ExecuteSP_NO_Return("JobSheet_Insert");
                    }
                }
            }
        }

        public bool JobOfWork_Required_Priority(int SiteID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            return Helper.MakeBooleanValid(_database.ExecuteSP_OBJECT("JobOfWork_Required_Priority"));
        }

        public Job CreateJobImportAdHocVisit(DataRow r, bool scheduleJobs)
        {
            var theVisitDate = default(DateTime);

            // get the sor info from the job type
            var jobImportType = App.DB.JobImports.JobImportType_Get(Helper.MakeIntegerValid(r["JobImportTypeID"]));
            if (jobImportType is null)
                return null;
            var SORdt = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID).Table;
            int siteId = Helper.MakeIntegerValid(r["SiteID"]);
            var oSite = App.DB.Sites.Get(siteId);
            int visittime = 0;
            int jobId = Helper.MakeIntegerValid(r["JobID"]);
            Job job;
            var jobOfWork = new JobOfWorks.JobOfWork();
            if (jobId == 0)
            {
                job = new Job();
                job.SetPropertyID = siteId;
                job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Callout);
                job.SetJobTypeID = jobImportType.JobTypeID;
                job.SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open);
                job.SetCreatedByUserID = App.loggedInUser.UserID;
                job.SetFOC = true;
                job.SetJobCreationType = Conversions.ToInteger(Enums.JobCreationType.JobManager);

                // get job number
                var JobNumber = new JobNumber();
                JobNumber = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)Conversions.ToInteger(Enums.JobDefinition.Callout));
                job.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                job.SetPONumber = "";
                job.SetQuoteID = 0;
                job.SetContractID = 0;

                // Get service priority
                int servicePriority;
                DataRow[] rows = App.DB.Picklists.GetAll((Enums.PickListTypes)Conversions.ToInteger(Enums.PickListTypes.JOWPriority)).Table.Select("Name = 'Dayworks'");
                if (rows.Length == 0)
                {
                    var oPickList = new PickLists.PickList();
                    oPickList.SetName = "Dayworks";
                    oPickList.SetEnumTypeID = Conversions.ToInteger(Enums.PickListTypes.JOWPriority);
                    servicePriority = App.DB.Picklists.Insert(oPickList);
                }
                else
                {
                    servicePriority = Conversions.ToInteger(rows[0]["ManagerID"]);
                }

                // INSERT JOB ITEM
                jobOfWork.SetPONumber = "";
                jobOfWork.SetPriority = servicePriority;
                if (!(jobOfWork.Priority == 0))
                {
                    jobOfWork.PriorityDateSet = DateAndTime.Now;
                }

                jobOfWork.IgnoreExceptionsOnSetMethods = true;
                foreach (DataRow sorRow in SORdt.Rows)
                {
                    var customerSors = App.DB.CustomerScheduleOfRate.Exists(Helper.MakeIntegerValid(sorRow["ScheduleOfRatesCategoryID"]), Helper.MakeStringValid(sorRow["Description"]), Helper.MakeStringValid(sorRow["Code"]), oSite.CustomerID);
                    int customerSorId = 0;
                    if (customerSors.Rows.Count > 0)
                        customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                    if (!(customerSorId > 0))
                    {
                        var customerSor = new CustomerScheduleOfRates.CustomerScheduleOfRate()
                        {
                            SetCode = Helper.MakeStringValid(sorRow["Code"]),
                            SetDescription = Helper.MakeStringValid(sorRow["Description"]),
                            SetPrice = Helper.MakeDoubleValid(sorRow["Price"]),
                            SetScheduleOfRatesCategoryID = Helper.MakeIntegerValid(sorRow["ScheduleOfRatesCategoryID"]),
                            SetTimeInMins = Helper.MakeIntegerValid(sorRow["TimeInMins"]),
                            SetCustomerID = oSite.CustomerID
                        };
                        customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                        App.DB.CustomerScheduleOfRate.Delete(customerSorId);
                    }

                    var jobItem = new JobItems.JobItem();
                    jobItem.IgnoreExceptionsOnSetMethods = true;
                    jobItem.SetSummary = Helper.MakeStringValid(sorRow["Description"]);
                    jobItem.SetQty = 1;
                    jobItem.SetRateID = customerSorId;
                    jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                    jobOfWork.JobItems.Add(jobItem);
                }
            }
            else
            {
                job = Job_Get(jobId);
                job.SetJobCreationType = Conversions.ToInteger(Enums.JobCreationType.JobManager);
                jobOfWork = (JobOfWorks.JobOfWork)job.JobOfWorks[0];
                EngineerVisits.EngineerVisit oEngineerVisit = (EngineerVisits.EngineerVisit)jobOfWork.EngineerVisits[0];
                visittime = Conversions.ToInteger(oEngineerVisit.EndDateTime.Subtract(oEngineerVisit.StartDateTime).TotalMinutes);
            }

            var engineerVisit = new EngineerVisits.EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.SetEngineerID = 0;
            if (scheduleJobs)
            {
                engineerVisit.SetEngineerID = Helper.MakeIntegerValid(r["EngineerID"]);
                engineerVisit.SetNotesToEngineer = "(" + r["AMPM"] + ") " + jobImportType.Name;
                if (oSite.CustomerID == (int)Enums.Customer.Victory)
                {
                    if (jobId > 0)
                    {
                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + Constants.vbCrLf + Constants.vbCrLf + "Collect overdue letter from office first!";
                    }

                    engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + Constants.vbCrLf + Constants.vbCrLf + "We are looking for ‘satisfactory’ certificates so we must under take essential remedial works whilst onsite – C1s & C2s." + Constants.vbCrLf + Constants.vbCrLf + "We don’t want CU upgraded to current Regs unless it is in a particularly high risk location." + Constants.vbCrLf + Constants.vbCrLf + "If a property doesn't have a hardwired smoke detector on each floor then record this on the test cert.";
                }

                var DT = App.DB.EngineerVisits.Find_The_Gap(Strings.Format(Helper.MakeDateTimeValid(r["NextVisitDate"]), "yyyy-MM-dd"), Helper.MakeIntegerValid(r["EngineerID"]), Helper.MakeStringValid(r["AMPM"]));
                string startdatetime = "";
                if (Conversions.ToBoolean(DT.Rows.Count == 0 & Operators.ConditionalCompareObjectEqual(r["AMPM"], "AM", false)))
                {
                    startdatetime = Helper.MakeStringValid(r["NextVisitDate"]).Substring(0, 10) + " 08:05:00";
                    startdatetime.Replace("/", "-");
                }
                else if (Conversions.ToBoolean(DT.Rows.Count == 0 & Operators.ConditionalCompareObjectEqual(r["AMPM"], "PM", false)))
                {
                    startdatetime = Helper.MakeStringValid(r["NextVisitDate"]).Substring(0, 10) + " 12:05:00";
                    startdatetime.Replace("/", "-");
                }
                else
                {
                    startdatetime = Helper.MakeStringValid(DT.Rows[0]["EndDateTime"]);
                }

                string enddatetime = Conversions.ToString(Helper.MakeDateTimeValid(startdatetime).AddMinutes(Conversions.ToDouble(visittime)));
                startdatetime = Strings.Format(Helper.MakeDateTimeValid(startdatetime), "yyyy-MM-dd HH:mm:ss");
                enddatetime = Strings.Format(Helper.MakeDateTimeValid(enddatetime), "yyyy-MM-dd HH:mm:ss");
                engineerVisit.StartDateTime = Conversions.ToDate(startdatetime);
                engineerVisit.EndDateTime = Conversions.ToDate(enddatetime);
                engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Scheduled);
                engineerVisit.DueDate = theVisitDate;
                engineerVisit.SetAMPM = Helper.MakeStringValid(r["AMPM"]);
            }
            else
            {
                engineerVisit.SetNotesToEngineer = "";
                engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
            }

            if (jobId == 0)
            {
                engineerVisit.SetVisitNumber = 1;
            }
            else
            {
                engineerVisit.SetVisitNumber = App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(Conversions.ToInteger(r["JobID"])).Count + 1;
            }

            jobOfWork.EngineerVisits.Add(engineerVisit);
            if (jobId == 0)
            {
                job.JobOfWorks.Add(jobOfWork);
                job = App.DB.Job.Insert(job);
            }
            else
            {
                job = App.DB.Job.Update(job);
            }

            return job;
        }

        public Job GenerateServiceLetterJob(DataRow r, int customerID, string AMPM, int fuelId = 0)
        {
            var theVisitDate = default(DateTime);
            var SORdt = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table;
            var oSite = App.DB.Sites.Get(Helper.MakeIntegerValid(r["SiteID"]));
            int visittime = 0;
            string fuel;
            var sorRowsL1COM = SORdt.Select("Code='EA7008' OR Code = 'PATCH'");
            var sorRowsL1SOLID = SORdt.Select("Code='EA7001'");
            var sorRowsL1STD = SORdt.Select("Code='EA7007'");
            var sorRowsL2COM = SORdt.Select("Code='EA7008*' OR Code = 'PATCH'");
            var sorRowsL2SOLID = SORdt.Select("Code='EA7001*'");
            var sorRowsL2STD = SORdt.Select("Code='EA7007*'");
            var sorRowsL3COM = SORdt.Select("Code='EA7008^' OR Code = 'PATCH'");
            var sorRowsL3SOLID = SORdt.Select("Code='EA7001^'");
            var sorRowsL3STD = SORdt.Select("Code='EA7007^'");

            // lets see if site has a job booked in on that day
            Job _currentJob;
            var jobOfWork = new JobOfWorks.JobOfWork();
            var multipleFuel = App.DB.LetterManager.LetterManager_GetJob_FromSiteAndDate(oSite.SiteID, Helper.MakeDateTimeValid(r["BookedDateTime"]).Date);
            if (multipleFuel.Rows.Count > 0)
            {
                _currentJob = App.DB.Job.Job_Get(Helper.MakeIntegerValid(multipleFuel.Rows[0]["JobID"]));
                jobOfWork = (JobOfWorks.JobOfWork)_currentJob.JobOfWorks[0];
            }
            else
            {
                var JobNumber = new JobNumber();
                switch (customerID)
                {
                    case (int)Enums.Customer.NCC: // Norwich City Council
                        {
                            JobNumber = GetNextJobNumber(Enums.JobDefinition.SERVICE_LETTER_JOB);
                            break;
                        }

                    default:
                        {
                            JobNumber = GetNextJobNumber(Enums.JobDefinition.Callout);
                            break;
                        }
                }

                int servicePriority = 0;
                DataRow[] rows = App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table.Select("Name = 'Service'");
                if (rows.Length == 0)
                {
                    var oPickList = new PickLists.PickList();
                    oPickList.SetName = "Service";
                    oPickList.SetEnumTypeID = Conversions.ToInteger(Enums.PickListTypes.JOWPriority);
                    servicePriority = App.DB.Picklists.Insert(oPickList);
                }
                else
                {
                    servicePriority = Conversions.ToInteger(rows[0]["ManagerID"]);
                }

                _currentJob = new Job();
                _currentJob.SetPropertyID = Helper.MakeIntegerValid(r["SiteID"]);
                _currentJob.SetJobCreationType = Conversions.ToInteger(Enums.JobCreationType.LetterManager);
                _currentJob.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Callout);
                _currentJob.SetJobTypeID = Conversions.ToInteger(Enums.JobTypes.ServiceCertificate);
                _currentJob.SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open);
                _currentJob.SetCreatedByUserID = App.loggedInUser.UserID;
                _currentJob.SetFOC = true;
                _currentJob.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                _currentJob.SetPONumber = "";
                _currentJob.SetQuoteID = 0;
                _currentJob.SetContractID = 0;

                // INSERT JOB ITEM
                jobOfWork.SetPONumber = "";
                jobOfWork.SetPriority = servicePriority;
                if (!(jobOfWork.Priority == 0))
                {
                    jobOfWork.PriorityDateSet = DateAndTime.Now;
                }

                jobOfWork.IgnoreExceptionsOnSetMethods = true;
            }

            string siteFuel = Helper.MakeStringValid(r["SiteFuel"]);
            string letterType = Helper.MakeStringValid(r["Type"]);
            bool patchCheck = Conversions.ToBoolean(r.Table.Columns.Contains("PatchCheck") && Operators.ConditionalCompareObjectEqual(r["PatchCheck"], true, false));
            DataRow[] sorRows = null;
            if ((letterType ?? "") == "Letter 1")
            {
                if (oSite.CommercialDistrict == true | patchCheck)
                {
                    sorRows = sorRowsL1COM;
                    visittime = 15;
                }
                else if (oSite.SolidFuel == true | siteFuel.Contains("Solid"))
                {
                    sorRows = sorRowsL1SOLID;
                    visittime = 75;
                }
                else if (siteFuel.Contains("Oil"))
                {
                    sorRows = sorRowsL1STD;
                    visittime = 60;
                }
                else
                {
                    sorRows = sorRowsL1STD;
                    visittime = 40;
                }
            }
            else if ((letterType ?? "") == "Letter 2")
            {
                if (oSite.CommercialDistrict == true | patchCheck)
                {
                    sorRows = sorRowsL2COM;
                    visittime = 15;
                }
                else if (oSite.SolidFuel == true | siteFuel.Contains("Solid"))
                {
                    sorRows = sorRowsL2SOLID;
                    visittime = 75;
                }
                else if (siteFuel.Contains("Oil"))
                {
                    sorRows = sorRowsL2STD;
                    visittime = 60;
                }
                else
                {
                    sorRows = sorRowsL2STD;
                    visittime = 40;
                }
            }
            else if ((letterType ?? "") == "Letter 3")
            {
                if (oSite.CommercialDistrict == true | patchCheck)
                {
                    sorRows = sorRowsL3COM;
                    visittime = 15;
                }
                else if (oSite.SolidFuel == true | siteFuel.Contains("Solid"))
                {
                    sorRows = sorRowsL3SOLID;
                    visittime = 75;
                }
                else if (siteFuel.Contains("Oil"))
                {
                    sorRows = sorRowsL3STD;
                    visittime = 60;
                }
                else
                {
                    sorRows = sorRowsL3STD;
                    visittime = 40;
                }
            }

            if (sorRows.Length > 0)
            {
                foreach (DataRow sorRow in sorRows)
                {
                    var customerSors = App.DB.CustomerScheduleOfRate.Exists(Helper.MakeIntegerValid(sorRow["ScheduleOfRatesCategoryID"]), Helper.MakeStringValid(sorRow["Description"]), Helper.MakeStringValid(sorRow["Code"]), oSite.CustomerID);
                    int customerSorId = 0;
                    if (customerSors.Rows.Count > 0)
                        customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                    if (!(customerSorId > 0))
                    {
                        var customerSor = new CustomerScheduleOfRates.CustomerScheduleOfRate()
                        {
                            SetCode = Helper.MakeStringValid(sorRow["Code"]),
                            SetDescription = Helper.MakeStringValid(sorRow["Description"]),
                            SetPrice = Helper.MakeDoubleValid(sorRow["Price"]),
                            SetScheduleOfRatesCategoryID = Helper.MakeIntegerValid(sorRow["ScheduleOfRatesCategoryID"]),
                            SetTimeInMins = Helper.MakeIntegerValid(sorRow["TimeInMins"]),
                            SetCustomerID = oSite.CustomerID
                        };
                        customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                        App.DB.CustomerScheduleOfRate.Delete(customerSorId);
                    }

                    var jobItem = new JobItems.JobItem();
                    jobItem.IgnoreExceptionsOnSetMethods = true;
                    jobItem.SetSummary = Helper.MakeStringValid(sorRow["Description"]);
                    jobItem.SetQty = 1;
                    jobItem.SetRateID = customerSorId;
                    jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                    jobOfWork.JobItems.Add(jobItem);
                }
            }

            var engineerVisit = new EngineerVisits.EngineerVisit();
            engineerVisit.IgnoreExceptionsOnSetMethods = true;
            engineerVisit.SetEngineerID = 0;
            engineerVisit.SetEngineerID = r["EngineerID"];
            // set site fuel in visit notes

            if (patchCheck)
            {
                engineerVisit.SetNotesToEngineer = "(" + AMPM + ") - Patch Check";
            }
            else
            {
                if (Helper.IsStringEmpty(siteFuel))
                {
                    fuel = "";
                }
                else if ((siteFuel ?? "") == "Gas" | (siteFuel ?? "") == "0")
                {
                    fuel = "";
                }
                else
                {
                    fuel = siteFuel;
                }

                if (fuelId == 0)
                {
                    if (r.Table.Columns.Contains("FuelID") && !Information.IsDBNull(r["FuelID"]))
                        fuelId = Helper.MakeIntegerValid(r["FuelID"]);
                }

                if (r.Table.Columns.Contains("MultipleFuelSite") && Helper.MakeBooleanValid(r["MultipleFuelSite"]))
                    fuel += " - Multiple Fuel Site";
                string visitNotes = string.Empty;
                if (!string.IsNullOrEmpty(oSite.ContactAlerts))
                    visitNotes += oSite.ContactAlerts + " ";
                visitNotes += "(" + AMPM + ") - " + fuel + " - Carry out safety inspection";
                engineerVisit.SetNotesToEngineer = visitNotes;
                engineerVisit.SetFuelID = fuelId;
                switch (customerID)
                {
                    case (int)Enums.Customer.NCC: // Norwich City Council
                        {
                            if ((letterType ?? "") == "Letter 2")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Take hand delivered letter and red sticker. ";
                            }
                            else if ((letterType ?? "") == "Letter 3")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape.";
                            }

                            if ((letterType ?? "") != "Letter 1")
                            {
                                engineerVisit.SetPartsToFit = true;
                            }

                            break;
                        }

                    case (int)Enums.Customer.Victory:
                        {
                            if ((letterType ?? "") == "Letter 1")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Please ensure service timer is re-set and record that this has been done. Set to 11 months from visit and code - 8727";
                            }
                            else if ((letterType ?? "") == "Letter 2")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Second Visit, Take hand delivered letter and Yellow Sticker. Service Expires: " + Conversions.ToDate(r["LastServiceDate"]).AddYears(1) + ", Please ensure service timer is re-set and record that this has been done. Set to 11 months from visit and code - 8727";
                            }
                            else if ((letterType ?? "") == "Letter 3")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape.";
                            }

                            if ((letterType ?? "") != "Letter 1")
                            {
                                engineerVisit.SetPartsToFit = true;
                            }

                            break;
                        }

                    case (int)Enums.Customer.WDC:
                        {
                            var ChangedDate = Conversions.ToDate(r["LastServiceDate"]).AddYears(1);
                            ChangedDate = ChangedDate.AddDays(-7);
                            ChangedDate = DateHelper.CheckBankHolidaySatOrSun(ChangedDate);
                            if ((letterType ?? "") == "Letter 2")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Second Visit, Take hand delivered letter and Red Sticker. Final Visit: " + ChangedDate;
                            }
                            else if ((letterType ?? "") == "Letter 3")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", Yellow tape visit, take hand delivered letter, camera and yellow tape.";
                            }

                            if ((letterType ?? "") != "Letter 1")
                            {
                                engineerVisit.SetPartsToFit = true;
                            }

                            break;
                        }

                    case (int)Enums.Customer.Flagship:
                    case (int)Enums.Customer.FlagshipMarketRented:
                        {
                            if ((letterType ?? "") == "Letter 2")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ", *PLEASE ADVISE IF METER IS INTERNAL*";
                            }
                            else if ((letterType ?? "") == "Letter 3")
                            {
                                if (Helper.MakeIntegerValid(r["CustomerID"]) == (int)Enums.Customer.NCC)
                                {
                                    engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                                }
                                else if (Helper.MakeIntegerValid(r["CustomerID"]) == (int)Enums.Customer.Saffron)
                                {
                                    engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                                }
                                else
                                {
                                }
                            }

                            if ((letterType ?? "") != "Letter 1")
                            {
                                engineerVisit.SetPartsToFit = false;
                            }

                            break;
                        }

                    case (int)Enums.Customer.Tendring:
                        {
                            engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + ". *Please ensure service timer is re-set and record that this has been done*";
                            break;
                        }

                    default:
                        {
                            if ((letterType ?? "") == "Letter 2")
                            {
                                engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                            }
                            else if ((letterType ?? "") == "Letter 3")
                            {
                                if (Helper.MakeIntegerValid(r["CustomerID"]) == (int)Enums.Customer.NCC)
                                {
                                    engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                                }
                                else if (Helper.MakeIntegerValid(r["CustomerID"]) == (int)Enums.Customer.Saffron)
                                {
                                    engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer;
                                }
                                else
                                {
                                }
                            }

                            if ((letterType ?? "") != "Letter 1")
                            {
                                engineerVisit.SetPartsToFit = false;
                            }

                            break;
                        }
                }
            }

            /// find the Gap
            var DT = App.DB.EngineerVisits.Find_The_Gap(Helper.MakeDateTimeValid(r["BookedDateTime"]).ToString("yyyy-MM-dd"), Helper.MakeIntegerValid(r["EngineerID"]), Helper.MakeStringValid(r["AMPM"]));
            string startdatetime;
            if (DT.Rows.Count == 0 & (Helper.MakeStringValid(r["AMPM"]) ?? "") == "AM")
            {
                startdatetime = Helper.MakeStringValid(r["BookedDateTime"]).Substring(0, 10) + " 08:05:00";
                startdatetime.Replace("/", "-");
            }
            else if (Conversions.ToBoolean(DT.Rows.Count == 0 & Operators.ConditionalCompareObjectEqual(r["AMPM"], "PM", false)))
            {
                startdatetime = Helper.MakeStringValid(r["BookedDateTime"]).Substring(0, 10) + " 12:05:00";
                startdatetime.Replace("/", "-");
            }
            else
            {
                startdatetime = Helper.MakeStringValid(DT.Rows[0]["EndDateTime"]);
            }

            string enddatetime = Conversions.ToString(Helper.MakeDateTimeValid(startdatetime).AddMinutes(Conversions.ToDouble(visittime)));
            startdatetime = Strings.Format(Helper.MakeDateTimeValid(startdatetime), "yyyy-MM-dd HH:mm:ss");
            enddatetime = Strings.Format(Helper.MakeDateTimeValid(enddatetime), "yyyy-MM-dd HH:mm:ss");
            engineerVisit.StartDateTime = Conversions.ToDate(startdatetime);
            engineerVisit.EndDateTime = Conversions.ToDate(enddatetime);
            engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Scheduled);
            engineerVisit.DueDate = theVisitDate;
            engineerVisit.SetAMPM = AMPM;
            if ((Helper.MakeStringValid(r["Type"]) ?? "") == "Letter 1")
            {
                engineerVisit.SetVisitNumber = 1;
            }
            else if ((Helper.MakeStringValid(r["Type"]) ?? "") == "Letter 2")
            {
                engineerVisit.SetVisitNumber = 2;
            }
            else if ((Helper.MakeStringValid(r["Type"]) ?? "") == "Letter 3")
            {
                engineerVisit.SetVisitNumber = 3;
            }

            jobOfWork.EngineerVisits.Add(engineerVisit);
            if (multipleFuel.Rows.Count > 0)
            {
                _currentJob = App.DB.Job.Update(_currentJob);
            }
            else
            {
                _currentJob.JobOfWorks.Add(jobOfWork);
                _currentJob = App.DB.Job.Insert(_currentJob);
            }

            return _currentJob;
        }

        public DataView GetJobNotes(int jobID)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobID", jobID, true);
            var dt = _database.ExecuteSP_DataTable("JobNote_Get_For_Job");
            dt.TableName = Enums.TableNames.tblJobNotes.ToString();
            return new DataView(dt);
        }

        public DataTable GetAllJobNotes(int SiteID)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteID", SiteID, true);
            var dt = _database.ExecuteSP_DataTable("JobNotes_Get_For_site");
            dt.TableName = Enums.TableNames.tblJobNotes.ToString();
            return dt;
        }

        public DataView SaveJobNotes(int JobNoteID, string Note, int EditedByUserID, int JobID, int CreatedByUserID)
        {
            _database.ClearParameter();
            if (JobNoteID > 0)
            {
                _database.AddParameter("@JobNoteID", JobNoteID, true);
                _database.AddParameter("@Note", Note, true);
                _database.AddParameter("@EditedByUserID", EditedByUserID, true);
                _database.ExecuteSP_NO_Return("JobNote_Update");
            }
            else
            {
                _database.AddParameter("@JobID", JobID, true);
                _database.AddParameter("@Note", Note, true);
                _database.AddParameter("@CreatedByUserID", CreatedByUserID, true);
                _database.ExecuteSP_NO_Return("JobNote_Insert");
            }

            return GetJobNotes(JobID);
        }

        public void DeleteJobNote(int jobNoteID)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobNoteID", jobNoteID, true);
            _database.ExecuteSP_NO_Return("JobNote_Delete");
        }
    }
}