// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Jobs.JobSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.CustomerScheduleOfRates;
using FSM.Entity.EngineerVisits;
using FSM.Entity.JobAssets;
using FSM.Entity.JobAudits;
using FSM.Entity.JobImport;
using FSM.Entity.JobItems;
using FSM.Entity.JobOfWorks;
using FSM.Entity.PickLists;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM.Entity.Jobs
{
  public class JobSQL
  {
    private Database _database;

    public JobSQL(Database database)
    {
      this._database = database;
    }

    public void DeleteReservedOrderNumber(int JobNumber, string Prefix)
    {
      string sql = "DELETE FROM tblJobNumber WHERE JobNumber = " + Conversions.ToString(JobNumber) + " AND Prefix = '" + Prefix + "'";
      App.DB.ExecuteWithOutReturn(sql, true);
    }

    public JobNumber GetNextJobNumber(Enums.JobDefinition JobDefinition)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobDefinition", (object) (int) JobDefinition, true);
      DataTable dataTable = App.DB.ExecuteSP_DataTable("JobNumber_Get", true);
      return new JobNumber(Conversions.ToInteger(dataTable.Rows[0]["JobNumber"]), Conversions.ToString(dataTable.Rows[0]["prefix"]));
    }

    public JobNumber GetNextJobNumber(
      Enums.JobDefinition JobDefinition,
      SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = "JobNumber_Get";
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@JobDefinition", (object) JobDefinition);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      return new JobNumber(Conversions.ToInteger(table.Rows[0]["JobNumber"]), Conversions.ToString(table.Rows[0]["prefix"]));
    }

    public Job Insert(Job oJob, SqlTransaction trans)
    {
      oJob.SetJobID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(new SqlCommand()
      {
        CommandText = "Job_Insert",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@SiteID", (object) oJob.PropertyID),
          new SqlParameter("@JobDefinitionEnumID", (object) oJob.JobDefinitionEnumID),
          new SqlParameter("@JobTypeID", (object) oJob.JobTypeID),
          new SqlParameter("@CreatedByUserID", (object) App.loggedInUser.UserID),
          new SqlParameter("@JobNumber", (object) oJob.JobNumber),
          new SqlParameter("@PONumber", (object) oJob.PONumber),
          new SqlParameter("@QuoteID", (object) oJob.QuoteID),
          new SqlParameter("@ContractID", (object) oJob.ContractID),
          new SqlParameter("@ToBePartPaid", (object) oJob.ToBePartPaid),
          new SqlParameter("@Retention", (object) oJob.Retention),
          new SqlParameter("@CollectPayment", (object) oJob.CollectPayment),
          new SqlParameter("@POC", (object) oJob.POC),
          new SqlParameter("@OTI", (object) oJob.OTI),
          new SqlParameter("@FOC", (object) oJob.FOC),
          new SqlParameter("@SalesRepUserID", (object) oJob.SalesRepUserID),
          new SqlParameter("@JobCreationType", (object) oJob.JobCreationType),
          new SqlParameter("@Deleted", (object) oJob.Deleted),
          new SqlParameter("@Headline", (object) oJob.Headline)
        }
      }.ExecuteScalar()));
      oJob.Exists = true;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = oJob.Assets.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          JobAsset current = (JobAsset) enumerator1.Current;
          current.SetJobID = (object) oJob.JobID;
          this._database.JobAsset.Insert(current, trans);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = oJob.JobOfWorks.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          JobOfWork current = (JobOfWork) enumerator2.Current;
          current.SetJobID = (object) oJob.JobID;
          this._database.JobOfWorks.Insert(current, trans);
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this.JobQualificationsLevels_Insert(oJob, trans);
      this.JobSheets_Insert(oJob, trans);
      App.DB.JobAudit.Insert(new JobAudit()
      {
        SetJobID = (object) oJob.JobID,
        SetActionChange = (object) "Job Created"
      }, trans);
      return App.DB.Job.Job_Get(oJob.JobID, trans);
    }

    public Job Insert(Job oJob)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) oJob.PropertyID, true);
      this._database.AddParameter("@JobDefinitionEnumID", (object) oJob.JobDefinitionEnumID, true);
      this._database.AddParameter("@JobTypeID", (object) oJob.JobTypeID, true);
      this._database.AddParameter("@CreatedByUserID", (object) App.loggedInUser.UserID, true);
      this._database.AddParameter("@JobNumber", (object) oJob.JobNumber, true);
      this._database.AddParameter("@PONumber", (object) oJob.PONumber, true);
      this._database.AddParameter("@QuoteID", (object) oJob.QuoteID, true);
      this._database.AddParameter("@ContractID", (object) oJob.ContractID, true);
      this._database.AddParameter("@ToBePartPaid", (object) oJob.ToBePartPaid, true);
      this._database.AddParameter("@Retention", (object) oJob.Retention, true);
      this._database.AddParameter("@CollectPayment", (object) oJob.CollectPayment, true);
      this._database.AddParameter("@POC", (object) oJob.POC, true);
      this._database.AddParameter("@OTI", (object) oJob.OTI, true);
      this._database.AddParameter("@FOC", (object) oJob.FOC, true);
      this._database.AddParameter("@SalesRepUserID", (object) oJob.SalesRepUserID, true);
      this._database.AddParameter("@JobCreationType", (object) oJob.JobCreationType, true);
      this._database.AddParameter("@Deleted", (object) oJob.Deleted, true);
      oJob.SetJobID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Job_Insert", true)));
      oJob.Exists = true;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = oJob.Assets.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          JobAsset current = (JobAsset) enumerator1.Current;
          current.SetJobID = (object) oJob.JobID;
          this._database.JobAsset.Insert(current);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = oJob.JobOfWorks.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          JobOfWork current = (JobOfWork) enumerator2.Current;
          current.SetJobID = (object) oJob.JobID;
          this._database.JobOfWorks.Insert(current);
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this.JobQualificationsLevels_Insert(oJob);
      this.JobSheets_Insert(oJob);
      App.DB.JobAudit.Insert(new JobAudit()
      {
        SetJobID = (object) oJob.JobID,
        SetActionChange = (object) "Job Created"
      });
      return App.DB.Job.Job_Get(oJob.JobID);
    }

    public Job Update(
      Job oJob,
      ArrayList JobOfWorksRemoved,
      ArrayList EngineerVisitsRemoved,
      ArrayList EngineerVisitsOrdersRemoved,
      SqlTransaction trans)
    {
      IEnumerator enumerator1;
      try
      {
        enumerator1 = JobOfWorksRemoved.GetEnumerator();
        while (enumerator1.MoveNext())
          this._database.JobOfWorks.Delete(Conversions.ToInteger(enumerator1.Current), trans);
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = EngineerVisitsRemoved.GetEnumerator();
        while (enumerator2.MoveNext())
          this._database.EngineerVisits.Delete(Conversions.ToInteger(enumerator2.Current), trans);
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      IEnumerator enumerator3;
      try
      {
        enumerator3 = EngineerVisitsOrdersRemoved.GetEnumerator();
        while (enumerator3.MoveNext())
          this._database.Order.Delete(Conversions.ToInteger(enumerator3.Current), trans);
      }
      finally
      {
        if (enumerator3 is IDisposable)
          (enumerator3 as IDisposable).Dispose();
      }
      new SqlCommand()
      {
        CommandText = "Job_Update",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@JobTypeID", (object) oJob.JobTypeID),
          new SqlParameter("@JobID", (object) oJob.JobID),
          new SqlParameter("@PONumber", (object) oJob.PONumber),
          new SqlParameter("@FOC", (object) oJob.FOC),
          new SqlParameter("@OTI", (object) oJob.OTI),
          new SqlParameter("@POC", (object) oJob.POC),
          new SqlParameter("@SalesRepUserID", (object) oJob.SalesRepUserID),
          new SqlParameter("@JobCreationType", (object) oJob.JobCreationType),
          new SqlParameter("@Headline", (object) oJob.Headline)
        }
      }.ExecuteNonQuery();
      IEnumerator enumerator4;
      try
      {
        enumerator4 = oJob.Assets.GetEnumerator();
        while (enumerator4.MoveNext())
        {
          JobAsset current = (JobAsset) enumerator4.Current;
          current.SetJobID = (object) oJob.JobID;
          this._database.JobAsset.Insert(current, trans);
        }
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      IEnumerator enumerator5;
      try
      {
        enumerator5 = oJob.JobOfWorks.GetEnumerator();
        while (enumerator5.MoveNext())
        {
          JobOfWork current1 = (JobOfWork) enumerator5.Current;
          current1.SetJobID = (object) oJob.JobID;
          if (!current1.Exists)
          {
            this._database.JobOfWorks.Insert(current1, trans);
          }
          else
          {
            this._database.JobOfWorks.Update_PONumber(current1, trans);
            string JobItemIDs = "";
            IEnumerator enumerator6;
            try
            {
              enumerator6 = current1.JobItems.GetEnumerator();
              while (enumerator6.MoveNext())
              {
                JobItem current2 = (JobItem) enumerator6.Current;
                current2.SetJobOfWorkID = (object) current1.JobOfWorkID;
                JobItem jobItem = this._database.JobItems.Insert(current2, trans);
                JobItemIDs = JobItemIDs + Conversions.ToString(jobItem.JobItemID) + ",";
              }
            }
            finally
            {
              if (enumerator6 is IDisposable)
                (enumerator6 as IDisposable).Dispose();
            }
            if (JobItemIDs.Length > 0)
              JobItemIDs = JobItemIDs.Substring(0, checked (JobItemIDs.Length - 1));
            this._database.JobItems.Delete(JobItemIDs, current1.JobOfWorkID, trans);
            IEnumerator enumerator7;
            try
            {
              enumerator7 = current1.EngineerVisits.GetEnumerator();
              while (enumerator7.MoveNext())
              {
                EngineerVisit current2 = (EngineerVisit) enumerator7.Current;
                current2.SetJobOfWorkID = (object) current1.JobOfWorkID;
                if (!current2.Exists)
                  this._database.EngineerVisits.Insert(current2, current1.JobID, trans);
                else
                  this._database.EngineerVisits.Update(current2, current1.JobID, false, trans);
              }
            }
            finally
            {
              if (enumerator7 is IDisposable)
                (enumerator7 as IDisposable).Dispose();
            }
          }
        }
      }
      finally
      {
        if (enumerator5 is IDisposable)
          (enumerator5 as IDisposable).Dispose();
      }
      this.JobQualificationsLevels_Insert(oJob, trans);
      this.JobSheets_Insert(oJob, trans);
      return this.Job_Get(oJob.JobID, trans);
    }

    public Job Update(
      Job oJob,
      ArrayList JobOfWorksRemoved,
      ArrayList EngineerVisitsRemoved,
      ArrayList EngineerVisitsOrdersRemoved)
    {
      IEnumerator enumerator1;
      try
      {
        enumerator1 = JobOfWorksRemoved.GetEnumerator();
        while (enumerator1.MoveNext())
          this._database.JobOfWorks.Delete(Conversions.ToInteger(enumerator1.Current));
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = EngineerVisitsRemoved.GetEnumerator();
        while (enumerator2.MoveNext())
          this._database.EngineerVisits.Delete(Conversions.ToInteger(enumerator2.Current));
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      IEnumerator enumerator3;
      try
      {
        enumerator3 = EngineerVisitsOrdersRemoved.GetEnumerator();
        while (enumerator3.MoveNext())
          this._database.Order.Delete(Conversions.ToInteger(enumerator3.Current));
      }
      finally
      {
        if (enumerator3 is IDisposable)
          (enumerator3 as IDisposable).Dispose();
      }
      this._database.ClearParameter();
      this._database.AddParameter("@JobTypeID", (object) oJob.JobTypeID, true);
      this._database.AddParameter("@PONumber", (object) oJob.PONumber, true);
      this._database.AddParameter("@JobID", (object) oJob.JobID, true);
      this._database.AddParameter("@FOC", (object) oJob.FOC, true);
      this._database.AddParameter("@OTI", (object) oJob.OTI, true);
      this._database.AddParameter("@POC", (object) oJob.POC, true);
      this._database.AddParameter("@SalesRepUserID", (object) oJob.SalesRepUserID, true);
      this._database.AddParameter("@JobCreationType", (object) oJob.JobCreationType, true);
      this._database.AddParameter("@Headline", (object) oJob.Headline, true);
      this._database.ExecuteSP_NO_Return("Job_Update", true);
      IEnumerator enumerator4;
      try
      {
        enumerator4 = oJob.Assets.GetEnumerator();
        while (enumerator4.MoveNext())
        {
          JobAsset current = (JobAsset) enumerator4.Current;
          current.SetJobID = (object) oJob.JobID;
          this._database.JobAsset.Insert(current);
        }
      }
      finally
      {
        if (enumerator4 is IDisposable)
          (enumerator4 as IDisposable).Dispose();
      }
      IEnumerator enumerator5;
      try
      {
        enumerator5 = oJob.JobOfWorks.GetEnumerator();
        while (enumerator5.MoveNext())
        {
          JobOfWork current1 = (JobOfWork) enumerator5.Current;
          current1.SetJobID = (object) oJob.JobID;
          if (!current1.Exists)
          {
            this._database.JobOfWorks.Insert(current1);
          }
          else
          {
            this._database.JobOfWorks.Update_PONumber(current1);
            string JobItemIDs = "";
            IEnumerator enumerator6;
            try
            {
              enumerator6 = current1.JobItems.GetEnumerator();
              while (enumerator6.MoveNext())
              {
                JobItem current2 = (JobItem) enumerator6.Current;
                current2.SetJobOfWorkID = (object) current1.JobOfWorkID;
                JobItem jobItem = this._database.JobItems.Insert(current2);
                JobItemIDs = JobItemIDs + Conversions.ToString(jobItem.JobItemID) + ",";
              }
            }
            finally
            {
              if (enumerator6 is IDisposable)
                (enumerator6 as IDisposable).Dispose();
            }
            if (JobItemIDs.Length > 0)
              JobItemIDs = JobItemIDs.Substring(0, checked (JobItemIDs.Length - 1));
            this._database.JobItems.Delete(JobItemIDs, current1.JobOfWorkID);
            IEnumerator enumerator7;
            try
            {
              enumerator7 = current1.EngineerVisits.GetEnumerator();
              while (enumerator7.MoveNext())
              {
                EngineerVisit current2 = (EngineerVisit) enumerator7.Current;
                current2.SetJobOfWorkID = (object) current1.JobOfWorkID;
                if (!current2.Exists)
                  this._database.EngineerVisits.Insert(current2, current1.JobID, 0, 0);
                else
                  this._database.EngineerVisits.Update(current2, current1.JobID, false);
              }
            }
            finally
            {
              if (enumerator7 is IDisposable)
                (enumerator7 as IDisposable).Dispose();
            }
          }
        }
      }
      finally
      {
        if (enumerator5 is IDisposable)
          (enumerator5 as IDisposable).Dispose();
      }
      this.JobQualificationsLevels_Insert(oJob);
      this.JobSheets_Insert(oJob);
      return this.Job_Get(oJob.JobID);
    }

    public Job Update(Job oJob)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobTypeID", (object) oJob.JobTypeID, true);
      this._database.AddParameter("@PONumber", (object) oJob.PONumber, true);
      this._database.AddParameter("@JobID", (object) oJob.JobID, true);
      this._database.AddParameter("@FOC", (object) oJob.FOC, true);
      this._database.AddParameter("@OTI", (object) oJob.OTI, true);
      this._database.AddParameter("@POC", (object) oJob.POC, true);
      this._database.AddParameter("@SalesRepUserID", (object) oJob.SalesRepUserID, true);
      this._database.AddParameter("@JobCreationType", (object) oJob.JobCreationType, true);
      this._database.AddParameter("@Headline", (object) oJob.Headline, true);
      this._database.ExecuteSP_NO_Return("Job_Update", true);
      this._database.JobAsset.Delete(oJob.JobID);
      IEnumerator enumerator1;
      try
      {
        enumerator1 = oJob.Assets.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          JobAsset current = (JobAsset) enumerator1.Current;
          current.SetJobID = (object) oJob.JobID;
          this._database.JobAsset.Insert(current);
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      IEnumerator enumerator2;
      try
      {
        enumerator2 = oJob.JobOfWorks.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          JobOfWork current1 = (JobOfWork) enumerator2.Current;
          current1.SetJobID = (object) oJob.JobID;
          if (!current1.Exists)
          {
            this._database.JobOfWorks.Insert(current1);
          }
          else
          {
            this._database.JobOfWorks.Update_PONumber(current1);
            string JobItemIDs = "";
            IEnumerator enumerator3;
            try
            {
              enumerator3 = current1.JobItems.GetEnumerator();
              while (enumerator3.MoveNext())
              {
                JobItem current2 = (JobItem) enumerator3.Current;
                current2.SetJobOfWorkID = (object) current1.JobOfWorkID;
                JobItem jobItem = this._database.JobItems.Insert(current2);
                JobItemIDs = JobItemIDs + Conversions.ToString(jobItem.JobItemID) + ",";
              }
            }
            finally
            {
              if (enumerator3 is IDisposable)
                (enumerator3 as IDisposable).Dispose();
            }
            if (JobItemIDs.Length > 0)
              JobItemIDs = JobItemIDs.Substring(0, checked (JobItemIDs.Length - 1));
            this._database.JobItems.Delete(JobItemIDs, current1.JobOfWorkID);
            IEnumerator enumerator4;
            try
            {
              enumerator4 = current1.EngineerVisits.GetEnumerator();
              while (enumerator4.MoveNext())
              {
                EngineerVisit current2 = (EngineerVisit) enumerator4.Current;
                current2.SetJobOfWorkID = (object) current1.JobOfWorkID;
                if (!current2.Exists)
                  this._database.EngineerVisits.Insert(current2, current1.JobID, 0, 0);
                else
                  this._database.EngineerVisits.Update(current2, current1.JobID, false);
              }
            }
            finally
            {
              if (enumerator4 is IDisposable)
                (enumerator4 as IDisposable).Dispose();
            }
          }
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      this.JobQualificationsLevels_Insert(oJob);
      this.JobSheets_Insert(oJob);
      return this.Job_Get(oJob.JobID);
    }

    public bool Job_WasGeneratedByLetter(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      return this._database.ExecuteSP_DataTable("Job_Get_Generated_By_Letter", true).Rows.Count > 0;
    }

    public DataView Job_Get_All(string whereClause)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceTypeIDEnum", (object) Enums.InvoiceType.Visit, true);
      this._database.AddParameter("@whereClause", (object) whereClause, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Job_Get_All), true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public DataView Job_Manager_Search(
      DateTime dateFrom,
      DateTime dateTo,
      string jobNumber,
      string postcode,
      int jobTypeId,
      int customerId,
      int siteId,
      int statusEnumId,
      int regionId,
      string poNumber,
      bool isJobOpen)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@DateFrom", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(dateFrom)), true);
      this._database.AddParameter("@DateTo", RuntimeHelpers.GetObjectValue(Helper.InsertDateIntoDb(dateTo)), true);
      this._database.AddParameter("@JobNumber", (object) jobNumber, true);
      this._database.AddParameter("@PostCode", (object) postcode, true);
      this._database.AddParameter("@JobTypeID", (object) jobTypeId, true);
      this._database.AddParameter("@CustomerID", (object) customerId, true);
      this._database.AddParameter("@SiteID", (object) siteId, true);
      this._database.AddParameter("@StatusEnumID", (object) statusEnumId, true);
      this._database.AddParameter("@RegionID", (object) regionId, true);
      this._database.AddParameter("@PoNumber", (object) poNumber, true);
      this._database.AddParameter("@IsJobOpen", (object) isJobOpen, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Job_Manager_Search), true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public DataView Job_Search(string Criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Criteria", (object) Criteria, true);
      this._database.AddParameter("@InvoiceTypeIDEnum", (object) Enums.InvoiceType.Visit, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Job_Search), true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public DataView Search(string Criteria, int userId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) Criteria, true);
      this._database.AddParameter("@UserID", (object) userId, true);
      DataTable table = this._database.ExecuteSP_DataTable("Job_Search_Mk1", true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public DataView Job_GetTop100_For_Site(int SiteID, int customerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      this._database.AddParameter("@CustomerID", (object) customerID, true);
      this._database.AddParameter("@InvoiceTypeIDEnum", (object) Enums.InvoiceType.Visit, true);
      DataTable table = this._database.ExecuteSP_DataTable("Job_GetTop100_For_Site_New", true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public DataView Job_GetTop_For_Site(int SiteID, int customerID, int top)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      this._database.AddParameter("@CustomerID", (object) customerID, true);
      this._database.AddParameter("@Top", (object) top, true);
      this._database.AddParameter("@InvoiceTypeIDEnum", (object) Enums.InvoiceType.Visit, true);
      DataTable table = this._database.ExecuteSP_DataTable("Job_GetTop_For_Site_New", true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public DataView Job_GetAll_For_Asset(int AssetID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@AssetID", (object) AssetID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Job_GetAll_For_Asset), true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public Job Job_Get(int JobID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (Job_Get);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@JobID", (object) JobID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table.Rows.Count <= 0)
        return (Job) null;
      Job job = new Job()
      {
        IgnoreExceptionsOnSetMethods = true,
        Exists = true,
        SetJobID = RuntimeHelpers.GetObjectValue(table.Rows[0][nameof (JobID)]),
        SetPropertyID = RuntimeHelpers.GetObjectValue(table.Rows[0]["SiteID"]),
        SetJobDefinitionEnumID = RuntimeHelpers.GetObjectValue(table.Rows[0]["JobDefinitionEnumID"]),
        SetJobTypeID = RuntimeHelpers.GetObjectValue(table.Rows[0]["JobTypeID"]),
        SetStatusEnumID = RuntimeHelpers.GetObjectValue(table.Rows[0]["StatusEnumID"]),
        DateCreated = Conversions.ToDate(table.Rows[0]["DateCreated"]),
        SetCreatedByUserID = RuntimeHelpers.GetObjectValue(table.Rows[0]["CreatedByUserID"]),
        SetJobNumber = RuntimeHelpers.GetObjectValue(table.Rows[0]["JobNumber"]),
        SetPONumber = RuntimeHelpers.GetObjectValue(table.Rows[0]["PONumber"]),
        SetQuoteID = RuntimeHelpers.GetObjectValue(table.Rows[0]["QuoteID"]),
        SetContractID = RuntimeHelpers.GetObjectValue(table.Rows[0]["ContractID"]),
        SetToBePartPaid = RuntimeHelpers.GetObjectValue(table.Rows[0]["ToBePartPaid"]),
        SetRetention = RuntimeHelpers.GetObjectValue(table.Rows[0]["Retention"]),
        SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"])
      };
      job.Assets = this._database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID, trans);
      job.JobOfWorks = this._database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID, trans);
      job.JobQualificationsLevels = this.JobQualificationsLevels_Get(job.JobID, trans);
      job.JobSheets = this.JobSheets_Get(job.JobID, trans);
      job.SetCollectPayment = RuntimeHelpers.GetObjectValue(table.Rows[0]["CollectPayment"]);
      job.SetPOC = RuntimeHelpers.GetObjectValue(table.Rows[0]["POC"]);
      job.SetOTI = RuntimeHelpers.GetObjectValue(table.Rows[0]["OTI"]);
      job.SetFOC = RuntimeHelpers.GetObjectValue(table.Rows[0]["FOC"]);
      job.SetSalesRepUserID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["SalesRepUserID"]));
      if (table.Columns.Contains("JobCreationType"))
        job.SetJobCreationType = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["JobCreationType"]));
      return job;
    }

    public Job Job_Get(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Job_Get), true);
      if (dataTable.Rows.Count <= 0)
        return (Job) null;
      Job job = new Job()
      {
        IgnoreExceptionsOnSetMethods = true,
        Exists = true,
        SetJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (JobID)]),
        SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]),
        SetJobDefinitionEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobDefinitionEnumID"]),
        SetJobTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeID"]),
        SetStatusEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusEnumID"]),
        DateCreated = Conversions.ToDate(dataTable.Rows[0]["DateCreated"]),
        SetCreatedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreatedByUserID"]),
        SetJobNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobNumber"]),
        SetPONumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PONumber"]),
        SetQuoteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteID"]),
        SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]),
        SetToBePartPaid = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ToBePartPaid"]),
        SetRetention = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Retention"]),
        SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"])
      };
      job.Assets = this._database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID);
      job.JobOfWorks = this._database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID);
      job.JobQualificationsLevels = this.JobQualificationsLevels_Get(job.JobID);
      job.JobSheets = this.JobSheets_Get(job.JobID);
      job.SetCollectPayment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CollectPayment"]);
      job.SetPOC = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["POC"]);
      job.SetOTI = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OTI"]);
      job.SetFOC = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FOC"]);
      job.SetSalesRepUserID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SalesRepUserID"]));
      if (dataTable.Columns.Contains("JobCreationType"))
        job.SetJobCreationType = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobCreationType"]));
      job.SetHeadline = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Headline"]);
      return job;
    }

    public Job Get(int id, GetBy getBy = GetBy.JobId)
    {
      this._database.ClearParameter();
      DataTable dataTable;
      if (getBy == GetBy.EngineerVisitId)
      {
        this._database.AddParameter("@EngineerVisitID", (object) Helper.MakeIntegerValid((object) id), true);
        dataTable = this._database.ExecuteSP_DataTable("Job_Get_For_An_EngineerVisit_ID", true);
      }
      else
      {
        this._database.AddParameter("@JobID", (object) Helper.MakeIntegerValid((object) id), false);
        dataTable = this._database.ExecuteSP_DataTable("Job_Get", true);
      }
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Job) null;
      Job job = new Job();
      job.IgnoreExceptionsOnSetMethods = true;
      job.Exists = true;
      job.SetJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobID"]);
      job.SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]);
      job.SetJobDefinitionEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobDefinitionEnumID"]);
      job.SetJobTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeID"]);
      job.SetStatusEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusEnumID"]);
      job.DateCreated = Conversions.ToDate(dataTable.Rows[0]["DateCreated"]);
      job.SetCreatedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreatedByUserID"]);
      job.SetJobNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobNumber"]);
      if (dataTable.Columns.Contains("PONumber"))
        job.SetPONumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PONumber"]);
      job.SetQuoteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteID"]);
      job.SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]);
      job.SetToBePartPaid = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ToBePartPaid"]);
      job.SetRetention = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Retention"]);
      job.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      job.SetCollectPayment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CollectPayment"]);
      job.SetPOC = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["POC"]);
      job.SetOTI = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OTI"]);
      job.SetFOC = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FOC"]);
      job.SetSalesRepUserID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SalesRepUserID"]));
      if (dataTable.Columns.Contains("JobCreationType"))
        job.SetJobCreationType = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobCreationType"]));
      if (dataTable.Columns.Contains("Headline"))
        job.SetHeadline = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Headline"]);
      return job;
    }

    public Job Job_Get_ByOrderID(int orderID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@OrderID", (object) orderID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Job_Get_ByOrderID), true);
      if (dataTable.Rows.Count <= 0)
        return (Job) null;
      Job job = new Job()
      {
        IgnoreExceptionsOnSetMethods = true,
        Exists = true,
        SetJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobID"]),
        SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]),
        SetJobDefinitionEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobDefinitionEnumID"]),
        SetJobTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeID"]),
        SetStatusEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusEnumID"]),
        DateCreated = Conversions.ToDate(dataTable.Rows[0]["DateCreated"]),
        SetCreatedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreatedByUserID"]),
        SetJobNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobNumber"]),
        SetPONumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PONumber"]),
        SetQuoteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteID"]),
        SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]),
        SetToBePartPaid = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ToBePartPaid"]),
        SetRetention = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Retention"]),
        SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"])
      };
      job.Assets = this._database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID);
      job.JobOfWorks = this._database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID);
      job.JobQualificationsLevels = this.JobQualificationsLevels_Get(job.JobID);
      job.JobSheets = this.JobSheets_Get(job.JobID);
      job.SetCollectPayment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CollectPayment"]);
      job.SetPOC = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["POC"]);
      job.SetOTI = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OTI"]);
      job.SetFOC = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FOC"]);
      job.SetSalesRepUserID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SalesRepUserID"]));
      if (dataTable.Columns.Contains("JobCreationType"))
        job.SetJobCreationType = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobCreationType"]));
      return job;
    }

    public Job Job_Get_For_Quote_ID(int QuoteJobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@QuoteJobID", (object) QuoteJobID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Job_Get_For_Quote_ID), true);
      if (dataTable.Rows.Count <= 0)
        return (Job) null;
      Job job = new Job()
      {
        IgnoreExceptionsOnSetMethods = true,
        Exists = true,
        SetJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobID"]),
        SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]),
        SetJobDefinitionEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobDefinitionEnumID"]),
        SetJobTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeID"]),
        SetStatusEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusEnumID"]),
        DateCreated = Conversions.ToDate(dataTable.Rows[0]["DateCreated"]),
        SetCreatedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreatedByUserID"]),
        SetJobNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobNumber"]),
        SetPONumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PONumber"]),
        SetQuoteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteID"]),
        SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]),
        SetToBePartPaid = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ToBePartPaid"]),
        SetRetention = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Retention"]),
        SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"])
      };
      job.Assets = this._database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID);
      job.JobOfWorks = this._database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID);
      job.SetCollectPayment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CollectPayment"]);
      job.SetCollectPayment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["POC"]);
      job.SetOTI = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OTI"]);
      job.SetFOC = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FOC"]);
      job.SetHeadline = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Headline"]);
      job.SetSalesRepUserID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SalesRepUserID"]));
      if (dataTable.Columns.Contains("JobCreationType"))
        job.SetJobCreationType = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobCreationType"]));
      this.JobQualificationsLevels_Get(job.JobID);
      job.JobSheets = this.JobSheets_Get(job.JobID);
      return job;
    }

    public Job Job_Get_For_An_EngineerVisit_ID(int engineerVisitID, SqlTransaction trans)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand()
      {
        CommandText = nameof (Job_Get_For_An_EngineerVisit_ID),
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@engineerVisitID", (object) engineerVisitID)
        }
      });
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      if (table.Rows.Count <= 0)
        return (Job) null;
      Job job = new Job()
      {
        IgnoreExceptionsOnSetMethods = true,
        Exists = true,
        SetJobID = RuntimeHelpers.GetObjectValue(table.Rows[0]["JobID"]),
        SetPropertyID = RuntimeHelpers.GetObjectValue(table.Rows[0]["SiteID"]),
        SetJobDefinitionEnumID = RuntimeHelpers.GetObjectValue(table.Rows[0]["JobDefinitionEnumID"]),
        SetJobTypeID = RuntimeHelpers.GetObjectValue(table.Rows[0]["JobTypeID"]),
        SetStatusEnumID = RuntimeHelpers.GetObjectValue(table.Rows[0]["StatusEnumID"]),
        DateCreated = Conversions.ToDate(table.Rows[0]["DateCreated"]),
        SetCreatedByUserID = RuntimeHelpers.GetObjectValue(table.Rows[0]["CreatedByUserID"]),
        SetJobNumber = RuntimeHelpers.GetObjectValue(table.Rows[0]["JobNumber"]),
        SetPONumber = (object) "",
        SetQuoteID = RuntimeHelpers.GetObjectValue(table.Rows[0]["QuoteID"]),
        SetContractID = RuntimeHelpers.GetObjectValue(table.Rows[0]["ContractID"]),
        SetToBePartPaid = RuntimeHelpers.GetObjectValue(table.Rows[0]["ToBePartPaid"]),
        SetRetention = RuntimeHelpers.GetObjectValue(table.Rows[0]["Retention"]),
        SetCollectPayment = RuntimeHelpers.GetObjectValue(table.Rows[0]["CollectPayment"]),
        SetDeleted = Conversions.ToBoolean(table.Rows[0]["Deleted"])
      };
      job.SetCollectPayment = RuntimeHelpers.GetObjectValue(table.Rows[0]["POC"]);
      job.SetOTI = RuntimeHelpers.GetObjectValue(table.Rows[0]["OTI"]);
      job.SetFOC = RuntimeHelpers.GetObjectValue(table.Rows[0]["FOC"]);
      job.SetSalesRepUserID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["SalesRepUserID"]));
      if (table.Columns.Contains("JobCreationType"))
        job.SetJobCreationType = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table.Rows[0]["JobCreationType"]));
      job.SetHeadline = RuntimeHelpers.GetObjectValue(table.Rows[0]["Headline"]);
      return job;
    }

    public Job Job_Get_For_An_EngineerVisit_ID(int engineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@engineerVisitID", (object) engineerVisitID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Job_Get_For_An_EngineerVisit_ID), true);
      if (dataTable.Rows.Count <= 0)
        return (Job) null;
      Job job = new Job()
      {
        IgnoreExceptionsOnSetMethods = true,
        Exists = true,
        SetJobID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobID"]),
        SetPropertyID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SiteID"]),
        SetJobDefinitionEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobDefinitionEnumID"]),
        SetJobTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeID"]),
        SetStatusEnumID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusEnumID"]),
        DateCreated = Conversions.ToDate(dataTable.Rows[0]["DateCreated"]),
        SetCreatedByUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CreatedByUserID"]),
        SetJobNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobNumber"]),
        SetPONumber = (object) "",
        SetQuoteID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["QuoteID"]),
        SetContractID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ContractID"]),
        SetToBePartPaid = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ToBePartPaid"]),
        SetRetention = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Retention"]),
        SetCollectPayment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CollectPayment"]),
        SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"])
      };
      job.SetCollectPayment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["POC"]);
      job.SetOTI = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OTI"]);
      job.SetFOC = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FOC"]);
      job.SetHeadline = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Headline"]);
      job.SetSalesRepUserID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SalesRepUserID"]));
      if (dataTable.Columns.Contains("JobCreationType"))
        job.SetJobCreationType = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobCreationType"]));
      job.Assets = this._database.JobAsset.JobAsset_Get_For_Job_As_Objects(job.JobID);
      job.JobOfWorks = this._database.JobOfWorks.JobOfWork_Get_For_Job_As_Objects(job.JobID);
      this.JobQualificationsLevels_Get(job.JobID);
      job.JobSheets = this.JobSheets_Get(job.JobID);
      return job;
    }

    public bool Job_Check_Before_Delete(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Job_Check_Before_Delete), true);
      IEnumerator enumerator;
      try
      {
        enumerator = dataTable.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Conversions.ToInteger(current["StatusEnumID"]) >= 5 || App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(Conversions.ToInteger(current["EngineerVisitID"])).Count > 0)
            return false;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return true;
    }

    public void Job_Delete(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      this._database.ExecuteSP_NO_Return(nameof (Job_Delete), true);
    }

    public void Job_Delete_BySite(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      this._database.ExecuteSP_NO_Return(nameof (Job_Delete_BySite), true);
    }

    public bool Job_MoveSite(int jobId, int oldSiteId, int newSiteId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) jobId, true);
      this._database.AddParameter("@OldSiteID", (object) oldSiteId, true);
      this._database.AddParameter("@NewSiteID", (object) newSiteId, true);
      return Helper.MakeBooleanValid((object) (this._database.ExecuteSP_ReturnRowsAffected(nameof (Job_MoveSite)) == 1));
    }

    public DataView JobQualificationsLevels_Get(int JobID)
    {
      SqlCommand Command = new SqlCommand(nameof (JobQualificationsLevels_Get), new SqlConnection(this._database.ServerConnectionString));
      Command.CommandType = CommandType.StoredProcedure;
      Command.Parameters.AddWithValue("@JobID", (object) JobID);
      DataTable table = this._database.ExecuteCommand_DataTable(Command);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public DataView JobQualificationsLevels_Get(int JobID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (JobQualificationsLevels_Get);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@JobID", (object) JobID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public bool JobQualificationsLevels_EngineerCheck(int jobID, int engineerID)
    {
      SqlCommand sqlCommand = new SqlCommand(nameof (JobQualificationsLevels_EngineerCheck), new SqlConnection(this._database.ServerConnectionString));
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Parameters.AddWithValue("@JobID", (object) jobID);
      sqlCommand.Parameters.AddWithValue("@EngineerID", (object) engineerID);
      return Conversions.ToBoolean(sqlCommand.ExecuteScalar());
    }

    private void JobQualificationsLevels_Insert(Job oJob)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) oJob.JobID, true);
      this._database.ExecuteSP_NO_Return("JobQualificationsLevels_Delete", true);
      if (oJob.JobQualificationsLevels.Table == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = oJob.JobQualificationsLevels.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
          {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object) oJob.JobID, true);
            this._database.AddParameter("@QualificationLevelID", RuntimeHelpers.GetObjectValue(current["ManagerID"]), false);
            this._database.ExecuteSP_NO_Return(nameof (JobQualificationsLevels_Insert), true);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void JobQualificationsLevels_Insert(Job oJob, SqlTransaction trans)
    {
      SqlCommand sqlCommand1 = new SqlCommand();
      sqlCommand1.CommandText = "JobQualificationsLevels_Delete";
      sqlCommand1.CommandType = CommandType.StoredProcedure;
      sqlCommand1.Transaction = trans;
      sqlCommand1.Connection = trans.Connection;
      sqlCommand1.Parameters.AddWithValue("@JobID", (object) oJob.JobID);
      sqlCommand1.ExecuteNonQuery();
      if (oJob.JobQualificationsLevels.Table == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = oJob.JobQualificationsLevels.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
          {
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.CommandText = nameof (JobQualificationsLevels_Insert);
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlCommand2.Transaction = trans;
            sqlCommand2.Connection = trans.Connection;
            sqlCommand2.Parameters.AddWithValue("@JobID", (object) oJob.JobID);
            sqlCommand2.Parameters.AddWithValue("@QualificationLevelID", RuntimeHelpers.GetObjectValue(current["ManagerID"]));
            sqlCommand2.ExecuteNonQuery();
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public DataView JobSheets_Get(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      DataTable table = this._database.ExecuteSP_DataTable("JobSheet_Get_JobID", true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public DataView JobSheets_Get(int JobID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = "JobSheet_Get_JobID";
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@JobID", (object) JobID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    private void JobSheets_Insert(Job oJob, SqlTransaction trans)
    {
      SqlCommand sqlCommand1 = new SqlCommand();
      sqlCommand1.CommandText = "JobSheet_Delete";
      sqlCommand1.CommandType = CommandType.StoredProcedure;
      sqlCommand1.Transaction = trans;
      sqlCommand1.Connection = trans.Connection;
      sqlCommand1.Parameters.AddWithValue("@JobID", (object) oJob.JobID);
      sqlCommand1.ExecuteNonQuery();
      if (oJob.JobSheets.Table == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = oJob.JobSheets.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
          {
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand2.CommandText = "JobSheet_Insert";
            sqlCommand2.CommandType = CommandType.StoredProcedure;
            sqlCommand2.Transaction = trans;
            sqlCommand2.Connection = trans.Connection;
            sqlCommand2.Parameters.AddWithValue("@JobID", (object) oJob.JobID);
            sqlCommand2.Parameters.AddWithValue("@JobSheetID", RuntimeHelpers.GetObjectValue(current["JobSheetID"]));
            sqlCommand2.ExecuteNonQuery();
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void JobSheets_Insert(Job oJob)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) oJob.JobID, true);
      this._database.ExecuteSP_NO_Return("JobSheet_Delete", true);
      if (oJob.JobSheets.Table == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = oJob.JobSheets.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["Tick"], (object) true, false))
          {
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object) oJob.JobID, true);
            this._database.AddParameter("@JobSheetID", RuntimeHelpers.GetObjectValue(current["JobSheetID"]), false);
            this._database.ExecuteSP_NO_Return("JobSheet_Insert", true);
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public void CompleteJob(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      this._database.AddParameter("@StatusID", (object) 2, true);
      this._database.ExecuteSP_NO_Return("Job_Complete", true);
    }

    public void UnlockTimed(int UserID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) UserID, true);
      this._database.ExecuteSP_NO_Return("JobLock_DeleteAll_After_Time", true);
    }

    public void UnlockAll(int UserID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) UserID, true);
      this._database.ExecuteSP_NO_Return("JobLock_DeleteAll", true);
    }

    public DataView Job_Get_All_WithNumberOfVisits(string WhereFilter)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@InvoiceTypeIDEnum", (object) Enums.InvoiceType.Visit, true);
      this._database.AddParameter("@WhereFilter", (object) WhereFilter, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Job_Get_All_WithNumberOfVisits), true);
      table.TableName = Enums.TableNames.tblJob.ToString();
      return new DataView(table);
    }

    public bool JobOfWork_Required_Priority(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      return Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof (JobOfWork_Required_Priority), true)));
    }

    public string GetEngineerTabletOrderRef(int EngineerVisitID, int EngineerID)
    {
      string str1;
      try
      {
        Conversions.ToString(0);
        this._database.ClearParameter();
        this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
        string Left = Conversions.ToString(this._database.ExecuteScalar("SELECT EngNextOrder FROM tblEngineerVisit WHERE EngineerVisitID = " + Conversions.ToString(EngineerVisitID), true, false));
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "0", false) == 0)
        {
          if (EngineerID == 0)
          {
            int num = (int) App.ShowMessage("An error has occurred:\r\nThere is no engineer assigned to this visit, process cannot continue", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            str1 = "False";
          }
          else
          {
            DataSet dataSet1 = new DataSet();
            DataTable dataTable1 = new DataTable();
            string EngineerName = "";
            string str2 = "";
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object) EngineerID, true);
            DataTable table1 = this._database.ExecuteSP_DataTable("Engineer_Get", true);
            dataSet1.Tables.Add(table1);
            if (dataSet1.Tables[0].Rows.Count > 0)
            {
              DataRow row = dataSet1.Tables[0].Rows[0];
              EngineerName = Conversions.ToString(row["Name"]);
              str2 = Conversions.ToString(row["Department"]);
            }
            DataSet dataSet2 = new DataSet();
            DataTable dataTable2 = new DataTable();
            string str3 = "";
            this._database.ClearParameter();
            this._database.AddParameter("@engineerVisitID", (object) EngineerVisitID, true);
            DataTable table2 = this._database.ExecuteSP_DataTable("Job_Get_For_An_EngineerVisit_ID", true);
            dataSet2.Tables.Add(table2);
            int integer1;
            int integer2;
            if (dataSet2.Tables[0].Rows.Count > 0)
            {
              DataRow row = dataSet2.Tables[0].Rows[0];
              str3 = Conversions.ToString(row["JobID"]);
              integer1 = Conversions.ToInteger(Conversions.ToString(row["JobTypeID"]));
              integer2 = Conversions.ToInteger(Conversions.ToString(row["SiteID"]));
            }
            if (integer1 != 4703)
            {
              DataSet dataSet3 = new DataSet();
              DataTable dataTable3 = new DataTable();
              this._database.ClearParameter();
              this._database.AddParameter("@JobDefinition", (object) Enums.JobDefinition.Callout, true);
              DataTable table3 = this._database.ExecuteSP_DataTable("JobNumber_Get", true);
              dataSet3.Tables.Add(table3);
              if (dataSet3.Tables[0].Rows.Count > 0)
              {
                DataRow row = dataSet3.Tables[0].Rows[0];
                string str4 = Conversions.ToString(row["JobNumber"]);
                string str5 = Conversions.ToString(row["Prefix"]) + str4;
                this._database.ClearParameter();
                this._database.AddParameter("@SiteID", (object) integer2, true);
                this._database.AddParameter("@JobDefinitionEnumID", (object) Enums.JobDefinition.Callout, true);
                this._database.AddParameter("@JobTypeID", (object) 4703, true);
                this._database.AddParameter("@CreatedByUserID", (object) 2, true);
                this._database.AddParameter("@JobNumber", (object) str5, true);
                this._database.AddParameter("@PONumber", (object) DBNull.Value, true);
                this._database.AddParameter("@QuoteID", (object) 0, true);
                this._database.AddParameter("@ContractID", (object) 0, true);
                this._database.AddParameter("@ToBePartPaid", (object) false, true);
                this._database.AddParameter("@Retention", (object) 0, true);
                this._database.AddParameter("@CollectPayment", (object) false, true);
                this._database.AddParameter("@POC", (object) false, true);
                this._database.AddParameter("@OTI", (object) false, true);
                this._database.AddParameter("@FOC", (object) false, true);
                this._database.AddParameter("@Deleted", (object) 0, true);
                str3 = Conversions.ToString(this._database.SP_ExecuteScalar("Job_Insert", true));
                string str6 = "New Job Inserted (From Tablet - Engineer " + EngineerName + ") - JobNumber: " + str5 + " (Unique Job ID: " + str3 + ")";
                this._database.ClearParameter();
                this._database.AddParameter("@JobID", (object) str3, true);
                this._database.AddParameter("@ActionChange", (object) str6, true);
                this._database.AddParameter("@ActionDateTime", (object) DateAndTime.Now, true);
                this._database.AddParameter("@UserID", (object) "2", true);
                this._database.SP_ExecuteScalar("JobAudit_Insert", true);
              }
            }
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object) str3, true);
            this._database.AddParameter("@Deleted", (object) "0", true);
            this._database.AddParameter("@PONumber", (object) DBNull.Value, true);
            this._database.AddParameter("@Status", (object) "1", true);
            this._database.AddParameter("@Priority", (object) DBNull.Value, true);
            this._database.AddParameter("@PriorityDateSet", (object) DBNull.Value, true);
            int integer3 = Conversions.ToInteger(this._database.SP_ExecuteScalar("JobOfWork_Insert", true));
            this._database.ClearParameter();
            this._database.AddParameter("@JobOfWorkID", (object) integer3, true);
            this._database.AddParameter("@EngineerID", (object) "0", true);
            this._database.AddParameter("@StartDateTime", (object) DBNull.Value, true);
            this._database.AddParameter("@EndDateTime", (object) DBNull.Value, true);
            this._database.AddParameter("@StatusEnumID", (object) "0", true);
            this._database.AddParameter("@NotesToEngineer", (object) "Created from Tablet", true);
            this._database.AddParameter("@PartsToFit", (object) "1", true);
            this._database.AddParameter("@ExpectedEngineerID", (object) "0", true);
            this._database.AddParameter("@DueDate", (object) DBNull.Value, true);
            this._database.AddParameter("@Recharge", (object) "0", true);
            this._database.AddParameter("@Deleted", (object) "0", true);
            this._database.AddParameter("@AMPM", (object) DBNull.Value, true);
            string str7 = Conversions.ToString(this._database.SP_ExecuteScalar("EngineerVisit_Insert", true));
            string str8 = "New Visit Inserted (From Tablet - Engineer " + EngineerName + ") - Status: " + Strings.Replace(Enums.VisitStatus.NOT_SET.ToString(), "_", " ", 1, -1, CompareMethod.Binary) + " (Unique Visit ID: " + str7 + ")";
            this._database.ClearParameter();
            this._database.AddParameter("@JobID", (object) str3, true);
            this._database.AddParameter("@ActionChange", (object) str8, true);
            this._database.AddParameter("@ActionDateTime", (object) DateAndTime.Now, true);
            this._database.AddParameter("@UserID", (object) "2", true);
            this._database.SP_ExecuteScalar("JobAudit_Insert", true);
            DataSet dataSet4 = new DataSet();
            DataTable dataTable4 = new DataTable();
            string JobNumberIn = "";
            this._database.ClearParameter();
            this._database.AddParameter("@JobDefinition", (object) Enums.JobDefinition.ORDER, true);
            DataTable table4 = this._database.ExecuteSP_DataTable("JobNumber_Get", true);
            dataSet4.Tables.Add(table4);
            if (dataSet4.Tables[0].Rows.Count > 0)
              JobNumberIn = Conversions.ToString(dataSet4.Tables[0].Rows[0]["JobNumber"]);
            string orderReference = JobSQL.GetOrderReference(Enums.OrderType.Job, EngineerName, JobNumberIn);
            this._database.ClearParameter();
            this._database.AddParameter("@DatePlaced", (object) DateAndTime.Now, true);
            this._database.AddParameter("@OrderTypeID", (object) Enums.OrderType.Job, true);
            this._database.AddParameter("@OrderReference", (object) orderReference, true);
            this._database.AddParameter("@UserID", (object) "2", true);
            this._database.AddParameter("@OrderStatusID", (object) Enums.OrderStatus.AwaitingConfirmation, true);
            this._database.AddParameter("@ReasonForReject", (object) DBNull.Value, true);
            this._database.AddParameter("@DeliveryDeadline", (object) DBNull.Value, true);
            this._database.AddParameter("@SpecialInstructions", (object) DBNull.Value, true);
            this._database.AddParameter("@ContactID", (object) "0", true);
            this._database.AddParameter("@InvoiceAddressID", (object) "0", true);
            this._database.AddParameter("@AllocatedToUser", (object) "0", true);
            this._database.AddParameter("@DepartmentRef", (object) str2, true);
            this._database.AddParameter("@DoNotConsolidated", (object) "1", true);
            int integer4 = Conversions.ToInteger(this._database.SP_ExecuteScalar("Order_Insert", true));
            this._database.ClearParameter();
            this._database.AddParameter("@OrderID", (object) integer4, true);
            this._database.AddParameter("@EngineerVisitID", (object) str7, true);
            this._database.AddParameter("@WarehouseID", (object) "0", true);
            this._database.SP_ExecuteScalar("EngineerVisitOrder_Insert", true);
            this._database.ClearParameter();
            this._database.ExecuteScalar("UPDATE tblEngineerVisit SET EngNextOrder = '" + orderReference + "' WHERE EngineerVisitID = '" + Conversions.ToString(EngineerVisitID) + "'", true, false);
            str1 = orderReference;
          }
        }
        else
          str1 = Left;
      }
      catch (SqlException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        str1 = ex.Message;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        str1 = ex.Message;
        ProjectData.ClearProjectError();
      }
      return str1;
    }

    public static string GetOrderReference(
      Enums.OrderType oOrderType,
      string EngineerName,
      string JobNumberIn)
    {
      JobNumber jobNumber = new JobNumber();
      jobNumber.OrderNumber = JobNumberIn;
      while (jobNumber.OrderNumber.Length < 5)
        jobNumber.OrderNumber = "0" + jobNumber.OrderNumber;
      string str1 = "";
      switch (oOrderType)
      {
        case Enums.OrderType.Customer:
          str1 = "W";
          break;
        case Enums.OrderType.StockProfile:
          str1 = "V";
          break;
        case Enums.OrderType.Warehouse:
          str1 = "W";
          break;
      }
      string str2 = "";
      string[] strArray = EngineerName.Split(' ');
      int index = 0;
      while (index < strArray.Length)
      {
        str2 = strArray[index].Substring(0, 1);
        checked { ++index; }
      }
      return str2 + str1 + jobNumber.OrderNumber;
    }

    public Job CreateJobImportAdHocVisit(DataRow r, bool scheduleJobs)
    {
      JobImportType jobImportType = App.DB.JobImports.JobImportType_Get(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["JobImportTypeID"])));
      if (jobImportType == null)
        return (Job) null;
      DataTable table = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_Get_ByEngineerQual(jobImportType.EngineerQualID).Table;
      int num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["SiteID"]));
      Site site = App.DB.Sites.Get((object) num1, SiteSQL.GetBy.SiteId, (object) null);
      int num2 = 0;
      int JobID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["JobID"]));
      JobOfWork jobOfWork = new JobOfWork();
      Job oJob;
      DateTime dateTime1;
      if (JobID == 0)
      {
        oJob = new Job();
        oJob.SetPropertyID = (object) num1;
        oJob.SetJobDefinitionEnumID = (object) 3;
        oJob.SetJobTypeID = (object) jobImportType.JobTypeID;
        oJob.SetStatusEnumID = (object) 1;
        oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
        oJob.SetFOC = (object) true;
        oJob.SetJobCreationType = (object) 2;
        JobNumber jobNumber = new JobNumber();
        JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Callout);
        oJob.SetJobNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
        oJob.SetPONumber = (object) "";
        oJob.SetQuoteID = (object) 0;
        oJob.SetContractID = (object) 0;
        Array array = (Array) App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority, false).Table.Select("Name = 'Dayworks'");
        int num3;
        if (array.Length == 0)
          num3 = App.DB.Picklists.Insert(new PickList()
          {
            SetName = (object) "Dayworks",
            SetEnumTypeID = (object) 45
          });
        else
          num3 = Conversions.ToInteger(((DataRow) NewLateBinding.LateIndexGet((object) array, new object[1]
          {
            (object) 0
          }, (string[]) null))["ManagerID"]);
        jobOfWork.SetPONumber = (object) "";
        jobOfWork.SetPriority = (object) num3;
        if ((uint) jobOfWork.Priority > 0U)
          jobOfWork.PriorityDateSet = DateAndTime.Now;
        jobOfWork.IgnoreExceptionsOnSetMethods = true;
        IEnumerator enumerator;
        try
        {
          enumerator = table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            DataTable dataTable = App.DB.CustomerScheduleOfRate.Exists(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"])), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Description"])), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Code"])), site.CustomerID);
            int CustomerScheduleOfRateID = 0;
            if (dataTable.Rows.Count > 0)
              CustomerScheduleOfRateID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
            if (CustomerScheduleOfRateID <= 0)
            {
              CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
              {
                SetCode = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Code"])),
                SetDescription = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Description"])),
                SetPrice = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Price"])),
                SetScheduleOfRatesCategoryID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["ScheduleOfRatesCategoryID"])),
                SetTimeInMins = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["TimeInMins"])),
                SetCustomerID = (object) site.CustomerID
              };
              CustomerScheduleOfRateID = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
              App.DB.CustomerScheduleOfRate.Delete(CustomerScheduleOfRateID);
            }
            jobOfWork.JobItems.Add((object) new JobItem()
            {
              IgnoreExceptionsOnSetMethods = true,
              SetSummary = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Description"])),
              SetQty = (object) 1,
              SetRateID = (object) CustomerScheduleOfRateID,
              SetSystemLinkID = (object) 95
            });
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      else
      {
        oJob = this.Job_Get(JobID);
        oJob.SetJobCreationType = (object) 2;
        jobOfWork = (JobOfWork) oJob.JobOfWorks[0];
        EngineerVisit engineerVisit = (EngineerVisit) jobOfWork.EngineerVisits[0];
        dateTime1 = engineerVisit.EndDateTime;
        num2 = checked ((int) Math.Round(dateTime1.Subtract(engineerVisit.StartDateTime).TotalMinutes));
      }
      EngineerVisit engineerVisit1 = new EngineerVisit();
      engineerVisit1.IgnoreExceptionsOnSetMethods = true;
      engineerVisit1.SetEngineerID = (object) 0;
      if (scheduleJobs)
      {
        engineerVisit1.SetEngineerID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["EngineerID"]));
        engineerVisit1.SetNotesToEngineer = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "(", r["AMPM"]), (object) ") "), (object) jobImportType.Name);
        if (site.CustomerID == 5872)
        {
          if (JobID > 0)
            engineerVisit1.SetNotesToEngineer = (object) (engineerVisit1.NotesToEngineer + "\r\n\r\nCollect overdue letter from office first!");
          engineerVisit1.SetNotesToEngineer = (object) (engineerVisit1.NotesToEngineer + "\r\n\r\nWe are looking for ‘satisfactory’ certificates so we must under take essential remedial works whilst onsite – C1s & C2s.\r\n\r\nWe don’t want CU upgraded to current Regs unless it is in a particularly high risk location.\r\n\r\nIf a property doesn't have a hardwired smoke detector on each floor then record this on the test cert.");
        }
        DataTable theGap = App.DB.EngineerVisits.Find_The_Gap(Strings.Format((object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(r["NextVisitDate"])), "yyyy-MM-dd"), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["EngineerID"])), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["AMPM"])));
        string str1;
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (theGap.Rows.Count == 0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(r["AMPM"], (object) "AM", false))))
        {
          str1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["NextVisitDate"])).Substring(0, 10) + " 08:05:00";
          str1.Replace("/", "-");
        }
        else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (theGap.Rows.Count == 0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(r["AMPM"], (object) "PM", false))))
        {
          str1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["NextVisitDate"])).Substring(0, 10) + " 12:05:00";
          str1.Replace("/", "-");
        }
        else
          str1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(theGap.Rows[0]["EndDateTime"]));
        dateTime1 = Helper.MakeDateTimeValid((object) str1);
        string str2 = Conversions.ToString(dateTime1.AddMinutes((double) num2));
        string str3 = Strings.Format((object) Helper.MakeDateTimeValid((object) str1), "yyyy-MM-dd HH:mm:ss");
        string str4 = Strings.Format((object) Helper.MakeDateTimeValid((object) str2), "yyyy-MM-dd HH:mm:ss");
        engineerVisit1.StartDateTime = Conversions.ToDate(str3);
        engineerVisit1.EndDateTime = Conversions.ToDate(str4);
        engineerVisit1.SetStatusEnumID = (object) 5;
        DateTime dateTime2;
        engineerVisit1.DueDate = dateTime2;
        engineerVisit1.SetAMPM = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["AMPM"]));
      }
      else
      {
        engineerVisit1.SetNotesToEngineer = (object) "";
        engineerVisit1.SetStatusEnumID = (object) 4;
      }
      engineerVisit1.SetVisitNumber = JobID != 0 ? (object) checked (App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(Conversions.ToInteger(r["JobID"])).Count + 1) : (object) 1;
      jobOfWork.EngineerVisits.Add((object) engineerVisit1);
      Job job;
      if (JobID == 0)
      {
        oJob.JobOfWorks.Add((object) jobOfWork);
        job = App.DB.Job.Insert(oJob);
      }
      else
        job = App.DB.Job.Update(oJob);
      return job;
    }

    public Job GenerateServiceLetterJob(DataRow r, int customerID, string AMPM, int fuelId = 0)
    {
      DataTable table = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll().Table;
      Site site = App.DB.Sites.Get((object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["SiteID"])), SiteSQL.GetBy.SiteId, (object) null);
      int num1 = 0;
      DataRow[] dataRowArray1 = table.Select("Code='EA7008' OR Code = 'PATCH'");
      DataRow[] dataRowArray2 = table.Select("Code='EA7001'");
      DataRow[] dataRowArray3 = table.Select("Code='EA7007'");
      DataRow[] dataRowArray4 = table.Select("Code='EA7008*' OR Code = 'PATCH'");
      DataRow[] dataRowArray5 = table.Select("Code='EA7001*'");
      DataRow[] dataRowArray6 = table.Select("Code='EA7007*'");
      DataRow[] dataRowArray7 = table.Select("Code='EA7008^' OR Code = 'PATCH'");
      DataRow[] dataRowArray8 = table.Select("Code='EA7001^'");
      DataRow[] dataRowArray9 = table.Select("Code='EA7007^'");
      JobOfWork jobOfWork = new JobOfWork();
      DataTable jobFromSiteAndDate = App.DB.LetterManager.LetterManager_GetJob_FromSiteAndDate(site.SiteID, Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(r["BookedDateTime"])).Date);
      Job oJob;
      if (jobFromSiteAndDate.Rows.Count > 0)
      {
        oJob = App.DB.Job.Job_Get(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(jobFromSiteAndDate.Rows[0]["JobID"])));
        jobOfWork = (JobOfWork) oJob.JobOfWorks[0];
      }
      else
      {
        JobNumber jobNumber1 = new JobNumber();
        JobNumber jobNumber2 = customerID == 2846 ? this.GetNextJobNumber(Enums.JobDefinition.SERVICE_LETTER_JOB) : this.GetNextJobNumber(Enums.JobDefinition.Callout);
        Array array = (Array) App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority, false).Table.Select("Name = 'Service'");
        int num2;
        if (array.Length == 0)
          num2 = App.DB.Picklists.Insert(new PickList()
          {
            SetName = (object) "Service",
            SetEnumTypeID = (object) 45
          });
        else
          num2 = Conversions.ToInteger(((DataRow) NewLateBinding.LateIndexGet((object) array, new object[1]
          {
            (object) 0
          }, (string[]) null))["ManagerID"]);
        oJob = new Job();
        oJob.SetPropertyID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["SiteID"]));
        oJob.SetJobCreationType = (object) 1;
        oJob.SetJobDefinitionEnumID = (object) 3;
        oJob.SetJobTypeID = (object) 4702;
        oJob.SetStatusEnumID = (object) 1;
        oJob.SetCreatedByUserID = (object) App.loggedInUser.UserID;
        oJob.SetFOC = (object) true;
        oJob.SetJobNumber = (object) (jobNumber2.Prefix + Conversions.ToString(jobNumber2.JobNumber));
        oJob.SetPONumber = (object) "";
        oJob.SetQuoteID = (object) 0;
        oJob.SetContractID = (object) 0;
        jobOfWork.SetPONumber = (object) "";
        jobOfWork.SetPriority = (object) num2;
        if ((uint) jobOfWork.Priority > 0U)
          jobOfWork.PriorityDateSet = DateAndTime.Now;
        jobOfWork.IgnoreExceptionsOnSetMethods = true;
      }
      string Left1 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["SiteFuel"]));
      string Left2 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["Type"]));
      bool boolean = Conversions.ToBoolean((object) (bool) (!r.Table.Columns.Contains("PatchCheck") ? 0 : (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(r["PatchCheck"], (object) true, false)) ? 1 : 0)));
      DataRow[] dataRowArray10 = (DataRow[]) null;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) == 0)
      {
        if (site.CommercialDistrict | boolean)
        {
          dataRowArray10 = dataRowArray1;
          num1 = 15;
        }
        else if (site.SolidFuel | Left1.Contains("Solid"))
        {
          dataRowArray10 = dataRowArray2;
          num1 = 75;
        }
        else if (Left1.Contains("Oil"))
        {
          dataRowArray10 = dataRowArray3;
          num1 = 60;
        }
        else
        {
          dataRowArray10 = dataRowArray3;
          num1 = 40;
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 2", false) == 0)
      {
        if (site.CommercialDistrict | boolean)
        {
          dataRowArray10 = dataRowArray4;
          num1 = 15;
        }
        else if (site.SolidFuel | Left1.Contains("Solid"))
        {
          dataRowArray10 = dataRowArray5;
          num1 = 75;
        }
        else if (Left1.Contains("Oil"))
        {
          dataRowArray10 = dataRowArray6;
          num1 = 60;
        }
        else
        {
          dataRowArray10 = dataRowArray6;
          num1 = 40;
        }
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 3", false) == 0)
      {
        if (site.CommercialDistrict | boolean)
        {
          dataRowArray10 = dataRowArray7;
          num1 = 15;
        }
        else if (site.SolidFuel | Left1.Contains("Solid"))
        {
          dataRowArray10 = dataRowArray8;
          num1 = 75;
        }
        else if (Left1.Contains("Oil"))
        {
          dataRowArray10 = dataRowArray9;
          num1 = 60;
        }
        else
        {
          dataRowArray10 = dataRowArray9;
          num1 = 40;
        }
      }
      if (dataRowArray10.Length > 0)
      {
        DataRow[] dataRowArray11 = dataRowArray10;
        int index = 0;
        while (index < dataRowArray11.Length)
        {
          DataRow dataRow = dataRowArray11[index];
          DataTable dataTable = App.DB.CustomerScheduleOfRate.Exists(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["ScheduleOfRatesCategoryID"])), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Description"])), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Code"])), site.CustomerID);
          int CustomerScheduleOfRateID = 0;
          if (dataTable.Rows.Count > 0)
            CustomerScheduleOfRateID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
          if (CustomerScheduleOfRateID <= 0)
          {
            CustomerScheduleOfRate oCustomerScheduleOfRate = new CustomerScheduleOfRate()
            {
              SetCode = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Code"])),
              SetDescription = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Description"])),
              SetPrice = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["Price"])),
              SetScheduleOfRatesCategoryID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["ScheduleOfRatesCategoryID"])),
              SetTimeInMins = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["TimeInMins"])),
              SetCustomerID = (object) site.CustomerID
            };
            CustomerScheduleOfRateID = App.DB.CustomerScheduleOfRate.Insert(oCustomerScheduleOfRate).CustomerScheduleOfRateID;
            App.DB.CustomerScheduleOfRate.Delete(CustomerScheduleOfRateID);
          }
          jobOfWork.JobItems.Add((object) new JobItem()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetSummary = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Description"])),
            SetQty = (object) 1,
            SetRateID = (object) CustomerScheduleOfRateID,
            SetSystemLinkID = (object) 95
          });
          checked { ++index; }
        }
      }
      EngineerVisit engineerVisit = new EngineerVisit()
      {
        IgnoreExceptionsOnSetMethods = true,
        SetEngineerID = (object) 0
      };
      engineerVisit.SetEngineerID = RuntimeHelpers.GetObjectValue(r["EngineerID"]);
      if (boolean)
      {
        engineerVisit.SetNotesToEngineer = (object) ("(" + AMPM + ") - Patch Check");
      }
      else
      {
        string str1 = !Helper.IsStringEmpty((object) Left1) ? (!(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Gas", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "0", false) == 0) ? Left1 : "") : "";
        if (fuelId == 0 && (r.Table.Columns.Contains("FuelID") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(r["FuelID"]))))
          fuelId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["FuelID"]));
        if (r.Table.Columns.Contains("MultipleFuelSite") && Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(r["MultipleFuelSite"])))
          str1 += " - Multiple Fuel Site";
        string str2 = string.Empty;
        if (!string.IsNullOrEmpty(site.ContactAlerts))
          str2 = str2 + site.ContactAlerts + " ";
        string str3 = str2 + "(" + AMPM + ") - " + str1 + " - Carry out safety inspection";
        engineerVisit.SetNotesToEngineer = (object) str3;
        engineerVisit.SetFuelID = (object) fuelId;
        switch (customerID)
        {
          case 2846:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 2", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ", Take hand delivered letter and red sticker. ");
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 3", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape.");
            if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) > 0U)
            {
              engineerVisit.SetPartsToFit = (object) true;
              break;
            }
            break;
          case 5155:
            DateTime sourceDate = Conversions.ToDate(r["LastServiceDate"]).AddYears(1);
            sourceDate = sourceDate.AddDays(-7.0);
            DateTime dateTime = DateHelper.CheckBankHolidaySatOrSun(sourceDate, false);
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 2", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ", Second Visit, Take hand delivered letter and Red Sticker. Final Visit: " + Conversions.ToString(dateTime));
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 3", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ", Yellow tape visit, take hand delivered letter, camera and yellow tape.");
            if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) > 0U)
            {
              engineerVisit.SetPartsToFit = (object) true;
              break;
            }
            break;
          case 5338:
          case 8306:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 2", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ", *PLEASE ADVISE IF METER IS INTERNAL*");
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 3", false) == 0)
            {
              if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["CustomerID"])) == 2846)
                engineerVisit.SetNotesToEngineer = (object) engineerVisit.NotesToEngineer;
              else if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["CustomerID"])) == 6561)
                engineerVisit.SetNotesToEngineer = (object) engineerVisit.NotesToEngineer;
            }
            if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) > 0U)
            {
              engineerVisit.SetPartsToFit = (object) false;
              break;
            }
            break;
          case 5872:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ", Please ensure service timer is re-set and record that this has been done. Set to 11 months from visit and code - 8727");
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 2", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ", Second Visit, Take hand delivered letter and Yellow Sticker. Service Expires: " + Conversions.ToString(Conversions.ToDate(r["LastServiceDate"]).AddYears(1)) + ", Please ensure service timer is re-set and record that this has been done. Set to 11 months from visit and code - 8727");
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 3", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ", Two to attend  -  Yellow tape visit, take hand delivered letter, camera and yellow tape.");
            if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) > 0U)
            {
              engineerVisit.SetPartsToFit = (object) true;
              break;
            }
            break;
          case 6526:
            engineerVisit.SetNotesToEngineer = (object) (engineerVisit.NotesToEngineer + ". *Please ensure service timer is re-set and record that this has been done*");
            break;
          default:
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 2", false) == 0)
              engineerVisit.SetNotesToEngineer = (object) engineerVisit.NotesToEngineer;
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 3", false) == 0)
            {
              if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["CustomerID"])) == 2846)
                engineerVisit.SetNotesToEngineer = (object) engineerVisit.NotesToEngineer;
              else if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["CustomerID"])) == 6561)
                engineerVisit.SetNotesToEngineer = (object) engineerVisit.NotesToEngineer;
            }
            if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "Letter 1", false) > 0U)
            {
              engineerVisit.SetPartsToFit = (object) false;
              break;
            }
            break;
        }
      }
      DataTable theGap = App.DB.EngineerVisits.Find_The_Gap(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(r["BookedDateTime"])).ToString("yyyy-MM-dd"), Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(r["EngineerID"])), Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r[nameof (AMPM)])));
      string str4;
      if (theGap.Rows.Count == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r[nameof (AMPM)])), "AM", false) == 0)
      {
        str4 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["BookedDateTime"])).Substring(0, 10) + " 08:05:00";
        str4.Replace("/", "-");
      }
      else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) (theGap.Rows.Count == 0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(r[nameof (AMPM)], (object) "PM", false))))
      {
        str4 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["BookedDateTime"])).Substring(0, 10) + " 12:05:00";
        str4.Replace("/", "-");
      }
      else
        str4 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(theGap.Rows[0]["EndDateTime"]));
      string str5 = Conversions.ToString(Helper.MakeDateTimeValid((object) str4).AddMinutes((double) num1));
      string str6 = Strings.Format((object) Helper.MakeDateTimeValid((object) str4), "yyyy-MM-dd HH:mm:ss");
      string str7 = Strings.Format((object) Helper.MakeDateTimeValid((object) str5), "yyyy-MM-dd HH:mm:ss");
      engineerVisit.StartDateTime = Conversions.ToDate(str6);
      engineerVisit.EndDateTime = Conversions.ToDate(str7);
      engineerVisit.SetStatusEnumID = (object) 5;
      DateTime dateTime1;
      engineerVisit.DueDate = dateTime1;
      engineerVisit.SetAMPM = (object) AMPM;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["Type"])), "Letter 1", false) == 0)
        engineerVisit.SetVisitNumber = (object) 1;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["Type"])), "Letter 2", false) == 0)
        engineerVisit.SetVisitNumber = (object) 2;
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(r["Type"])), "Letter 3", false) == 0)
        engineerVisit.SetVisitNumber = (object) 3;
      jobOfWork.EngineerVisits.Add((object) engineerVisit);
      Job job;
      if (jobFromSiteAndDate.Rows.Count > 0)
      {
        job = App.DB.Job.Update(oJob);
      }
      else
      {
        oJob.JobOfWorks.Add((object) jobOfWork);
        job = App.DB.Job.Insert(oJob);
      }
      return job;
    }

    public DataView GetJobNotes(int jobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) jobID, true);
      DataTable table = this._database.ExecuteSP_DataTable("JobNote_Get_For_Job", true);
      table.TableName = Enums.TableNames.tblJobNotes.ToString();
      return new DataView(table);
    }

    public DataTable GetAllJobNotes(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable("JobNotes_Get_For_site", true);
      dataTable.TableName = Enums.TableNames.tblJobNotes.ToString();
      return dataTable;
    }

    public DataView SaveJobNotes(
      int JobNoteID,
      string Note,
      int EditedByUserID,
      int JobID,
      int CreatedByUserID)
    {
      this._database.ClearParameter();
      if (JobNoteID > 0)
      {
        this._database.AddParameter("@JobNoteID", (object) JobNoteID, true);
        this._database.AddParameter("@Note", (object) Note, true);
        this._database.AddParameter("@EditedByUserID", (object) EditedByUserID, true);
        this._database.ExecuteSP_NO_Return("JobNote_Update", true);
      }
      else
      {
        this._database.AddParameter("@JobID", (object) JobID, true);
        this._database.AddParameter("@Note", (object) Note, true);
        this._database.AddParameter("@CreatedByUserID", (object) CreatedByUserID, true);
        this._database.ExecuteSP_NO_Return("JobNote_Insert", true);
      }
      return this.GetJobNotes(JobID);
    }

    public void DeleteJobNote(int jobNoteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobNoteID", (object) jobNoteID, true);
      this._database.ExecuteSP_NO_Return("JobNote_Delete", true);
    }
  }
}
