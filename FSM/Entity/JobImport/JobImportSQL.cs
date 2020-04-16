// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobImport.JobImportSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Jobs;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobImport
{
    public class JobImportSQL
    {
        private Database _database;

        public JobImportSQL(Database database)
        {
            this._database = database;
        }

        public FSM.Entity.JobImport.JobImport JobImport_Insert(FSM.Entity.JobImport.JobImport oJobImport)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteId", (object)oJobImport.SiteID, true);
            this._database.AddParameter("@UPRN", (object)oJobImport.UPRN, true);
            this._database.AddParameter("@JobImportTypeId", (object)oJobImport.JobImportTypeID, true);
            this._database.AddParameter("@DateAdded", (object)oJobImport.DateAdded, true);
            oJobImport.SetJobImportID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(JobImport_Insert), true)));
            oJobImport.Exists = true;
            return oJobImport;
        }

        public bool JobImport_Exist(int siteId, int jobImportTypeId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteId", (object)siteId, false);
            this._database.AddParameter("@JobImportTypeId", (object)jobImportTypeId, false);
            int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(JobImport_Exist), true)));
            bool flag = false;
            if (num > 0)
                flag = true;
            return flag;
        }

        public DataView JobImport_Get_ByJobNumber(string jobNumber)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobNumber", (object)jobNumber, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(JobImport_Get_ByJobNumber), true);
            table.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(table);
        }

        public DataView JobImport_Get_BySiteID(int siteId, int jobImportTypeId = 0)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SiteId", (object)siteId, false);
            this._database.AddParameter("@JobImportTypeId", (object)jobImportTypeId, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(JobImport_Get_BySiteID), true);
            table.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(table);
        }

        public DataView JobImport_Get_L1Jobs(int jobImportTypeId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportTypeId", (object)jobImportTypeId, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(JobImport_Get_L1Jobs), true);
            table.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(table);
        }

        public DataView JobImport_Get_L1Jobs_NoOrder(int jobImportTypeId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportTypeId", (object)jobImportTypeId, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(JobImport_Get_L1Jobs_NoOrder), true);
            table.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(table);
        }

        public DataView JobImport_Get_L2Jobs(int jobImportTypeId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportTypeId", (object)jobImportTypeId, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(JobImport_Get_L2Jobs), true);
            table.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(table);
        }

        public DataView JobImport_Get_EngineerJobs(
          DateTime startDate,
          DateTime endDate,
          int jobImportTypeId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@StartDate", (object)startDate, true);
            this._database.AddParameter("@EndDate", (object)endDate, true);
            this._database.AddParameter("@JobImportTypeId", RuntimeHelpers.GetObjectValue(Interaction.IIf(jobImportTypeId > 0, (object)jobImportTypeId, (object)null)), true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(JobImport_Get_EngineerJobs), true);
            table.TableName = Enums.TableNames.tblJob.ToString();
            return new DataView(table);
        }

        public bool JobImport_Update_Job(int jobImportId, Job oJob)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportID", (object)jobImportId, false);
            this._database.AddParameter("@JobID", (object)oJob.JobID, false);
            this._database.AddParameter("@JobNumber", (object)oJob.JobNumber, false);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(JobImport_Update_Job)) == 1;
        }

        public bool JobImport_Update_Letter1(DataRow dr, Job oJob)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportID", (object)Conversions.ToInteger(dr["JobImportID"]), false);
            this._database.AddParameter("@JobID", (object)oJob.JobID, false);
            this._database.AddParameter("@JobNumber", (object)oJob.JobNumber, false);
            this._database.AddParameter("@Status", (object)Enums.EngineerVisitOutcomes.NOT_SET, false);
            this._database.AddParameter("@BookedDate", (object)Conversions.ToDate(dr["BookedVisit"]), true);
            this._database.AddParameter("@Letter1", (object)DateAndTime.Now, true);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(JobImport_Update_Letter1)) == 1;
        }

        public bool JobImport_Update_Letter2(DataRow dr, Job oJob)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportID", (object)Conversions.ToInteger(dr["JobImportID"]), false);
            this._database.AddParameter("@Status", (object)Enums.EngineerVisitOutcomes.Carded, false);
            this._database.AddParameter("@BookedDate", (object)Conversions.ToDate(dr["BookedVisit"]), true);
            this._database.AddParameter("@Letter2", (object)DateAndTime.Now, true);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(JobImport_Update_Letter2)) == 1;
        }

        public bool JobImport_Delete_WithJobType(int jobImportId, int jobImportTypeId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportTypeId", (object)jobImportTypeId, false);
            this._database.AddParameter("@JobImportId", (object)jobImportId, false);
            return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT(nameof(JobImport_Delete_WithJobType), true), (object)1, false);
        }

        public DataView JobImportType_GetAll()
        {
            this._database.ClearParameter();
            return new DataView(this._database.ExecuteSP_DataTable(nameof(JobImportType_GetAll), true));
        }

        public JobImportType JobImportType_Get(int jobImportTypeId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportTypeId", (object)jobImportTypeId, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(JobImportType_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (JobImportType)null;
            JobImportType jobImportType1 = new JobImportType();
            JobImportType jobImportType2 = jobImportType1;
            jobImportType2.IgnoreExceptionsOnSetMethods = true;
            jobImportType2.SetJobImportTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobImportTypeID"]);
            jobImportType2.SetCycle = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Cycle"]);
            jobImportType2.SetJobTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeID"]);
            jobImportType2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
            jobImportType2.SetJobTypeName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeName"]);
            jobImportType2.SetEngineerQualID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerQualID"]);
            jobImportType1.Exists = true;
            return jobImportType1;
        }

        public JobImportType JobImportType_Insert(JobImportType oJobImportType)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Name", (object)oJobImportType.Name, false);
            this._database.AddParameter("@JobTypeID", (object)oJobImportType.JobTypeID, false);
            this._database.AddParameter("@EngineerQualID", (object)oJobImportType.EngineerQualID, false);
            this._database.AddParameter("@Cycle", (object)oJobImportType.Cycle, false);
            oJobImportType.SetJobImportTypeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(JobImportType_Insert), true)));
            oJobImportType.Exists = true;
            return oJobImportType;
        }

        public bool JobImportType_Update(JobImportType oJobImportType)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportTypeID", (object)oJobImportType.JobImportTypeID, false);
            this._database.AddParameter("@Name", (object)oJobImportType.Name, false);
            this._database.AddParameter("@JobTypeID", (object)oJobImportType.JobTypeID, false);
            this._database.AddParameter("@EngineerQualID", (object)oJobImportType.EngineerQualID, false);
            this._database.AddParameter("@Cycle", (object)oJobImportType.Cycle, false);
            return this._database.ExecuteSP_ReturnRowsAffected(nameof(JobImportType_Update)) == 1;
        }

        public bool JobImportType_Delete(JobImportType oJobImportType)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobImportTypeID", (object)oJobImportType.JobImportTypeID, false);
            return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this._database.ExecuteSP_OBJECT(nameof(JobImportType_Delete), true), (object)1, false);
        }
    }
}