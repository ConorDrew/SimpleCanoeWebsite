using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.JobImport
{
    public class JobImportSQL
    {
        private Sys.Database _database;

        public JobImportSQL(Sys.Database database)
        {
            _database = database;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public JobImport JobImport_Insert(JobImport oJobImport)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteId", oJobImport.SiteID, true);
            _database.AddParameter("@UPRN", oJobImport.UPRN, true);
            _database.AddParameter("@JobImportTypeId", oJobImport.JobImportTypeID, true);
            _database.AddParameter("@DateAdded", oJobImport.DateAdded, true);
            oJobImport.SetJobImportID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobImport_Insert"));
            oJobImport.Exists = true;
            return oJobImport;
        }

        public bool JobImport_Exist(int siteId, int jobImportTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteId", siteId);
            _database.AddParameter("@JobImportTypeId", jobImportTypeId);
            int count = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobImport_Exist"));
            bool exist = false;
            if (count > 0)
            {
                exist = true;
            }

            return exist;
        }

        public DataView JobImport_Get_ByJobNumber(string jobNumber)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobNumber", jobNumber);
            var dt = _database.ExecuteSP_DataTable("JobImport_Get_ByJobNumber");
            dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView JobImport_Get_BySiteID(int siteId, int jobImportTypeId = 0)
        {
            _database.ClearParameter();
            _database.AddParameter("@SiteId", siteId);
            _database.AddParameter("@JobImportTypeId", jobImportTypeId);
            var dt = _database.ExecuteSP_DataTable("JobImport_Get_BySiteID");
            dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView JobImport_Get_L1Jobs(int jobImportTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportTypeId", jobImportTypeId);
            var dt = _database.ExecuteSP_DataTable("JobImport_Get_L1Jobs");
            dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView JobImport_Get_L1Jobs_NoOrder(int jobImportTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportTypeId", jobImportTypeId);
            var dt = _database.ExecuteSP_DataTable("JobImport_Get_L1Jobs_NoOrder");
            dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView JobImport_Get_L2Jobs(int jobImportTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportTypeId", jobImportTypeId);
            var dt = _database.ExecuteSP_DataTable("JobImport_Get_L2Jobs");
            dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public DataView JobImport_Get_EngineerJobs(DateTime startDate, DateTime endDate, int jobImportTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@StartDate", startDate, true);
            _database.AddParameter("@EndDate", endDate, true);
            _database.AddParameter("@JobImportTypeId", Interaction.IIf(jobImportTypeId > 0, jobImportTypeId, null), true);
            var dt = _database.ExecuteSP_DataTable("JobImport_Get_EngineerJobs");
            dt.TableName = Sys.Enums.TableNames.tblJob.ToString();
            return new DataView(dt);
        }

        public bool JobImport_Update_Job(int jobImportId, Jobs.Job oJob)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportID", jobImportId);
            _database.AddParameter("@JobID", oJob.JobID);
            _database.AddParameter("@JobNumber", oJob.JobNumber);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("JobImport_Update_Job") == 1);
        }

        public bool JobImport_Update_Letter1(DataRow dr, Jobs.Job oJob)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportID", Conversions.ToInteger(dr["JobImportID"]));
            _database.AddParameter("@JobID", oJob.JobID);
            _database.AddParameter("@JobNumber", oJob.JobNumber);
            _database.AddParameter("@Status", Sys.Enums.EngineerVisitOutcomes.NOT_SET);
            _database.AddParameter("@BookedDate", Conversions.ToDate(dr["BookedVisit"]), true);
            _database.AddParameter("@Letter1", DateAndTime.Now, true);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("JobImport_Update_Letter1") == 1);
        }

        public bool JobImport_Update_Letter2(DataRow dr, Jobs.Job oJob)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportID", Conversions.ToInteger(dr["JobImportID"]));
            _database.AddParameter("@Status", Sys.Enums.EngineerVisitOutcomes.Carded);
            _database.AddParameter("@BookedDate", Conversions.ToDate(dr["BookedVisit"]), true);
            _database.AddParameter("@Letter2", DateAndTime.Now, true);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("JobImport_Update_Letter2") == 1);
        }

        public bool JobImport_Delete_WithJobType(int jobImportId, int jobImportTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportTypeId", jobImportTypeId);
            _database.AddParameter("@JobImportId", jobImportId);
            return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("JobImport_Delete_WithJobType"), 1, false));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public DataView JobImportType_GetAll()
        {
            _database.ClearParameter();
            return new DataView(_database.ExecuteSP_DataTable("JobImportType_GetAll"));
        }

        public JobImportType JobImportType_Get(int jobImportTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportTypeId", jobImportTypeId);

            // Get the datatable from the database store in dt
            var dt = _database.ExecuteSP_DataTable("JobImportType_Get");
            if (dt is object)
            {
                if (dt.Rows.Count > 0)
                {
                    var oJobImportType = new JobImportType();
                    oJobImportType.IgnoreExceptionsOnSetMethods = true;
                    oJobImportType.SetJobImportTypeID = dt.Rows[0]["JobImportTypeID"];
                    oJobImportType.SetCycle = dt.Rows[0]["Cycle"];
                    oJobImportType.SetJobTypeID = dt.Rows[0]["JobTypeID"];
                    oJobImportType.SetName = dt.Rows[0]["Name"];
                    oJobImportType.SetJobTypeName = dt.Rows[0]["JobTypeName"];
                    oJobImportType.SetEngineerQualID = dt.Rows[0]["EngineerQualID"];
                    oJobImportType.Exists = true;
                    return oJobImportType;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public JobImportType JobImportType_Insert(JobImportType oJobImportType)
        {
            _database.ClearParameter();
            _database.AddParameter("@Name", oJobImportType.Name);
            _database.AddParameter("@JobTypeID", oJobImportType.JobTypeID);
            _database.AddParameter("@EngineerQualID", oJobImportType.EngineerQualID);
            _database.AddParameter("@Cycle", oJobImportType.Cycle);
            oJobImportType.SetJobImportTypeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("JobImportType_Insert"));
            oJobImportType.Exists = true;
            return oJobImportType;
        }

        public bool JobImportType_Update(JobImportType oJobImportType)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportTypeID", oJobImportType.JobImportTypeID);
            _database.AddParameter("@Name", oJobImportType.Name);
            _database.AddParameter("@JobTypeID", oJobImportType.JobTypeID);
            _database.AddParameter("@EngineerQualID", oJobImportType.EngineerQualID);
            _database.AddParameter("@Cycle", oJobImportType.Cycle);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("JobImportType_Update") == 1);
        }

        public bool JobImportType_Delete(JobImportType oJobImportType)
        {
            _database.ClearParameter();
            _database.AddParameter("@JobImportTypeID", oJobImportType.JobImportTypeID);
            return Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(_database.ExecuteSP_OBJECT("JobImportType_Delete"), 1, false));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}