// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobOfWorks.JobOfWorkSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
using FSM.Entity.JobItems;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobOfWorks
{
  public class JobOfWorkSQL
  {
    private Database _database;

    public JobOfWorkSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int JobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) JobOfWorkID, true);
      this._database.ExecuteSP_NO_Return("JobOfWork_Delete", true);
    }

    public void Delete(int JobOfWorkID, SqlTransaction trans)
    {
      new SqlCommand()
      {
        CommandText = "JobOfWork_Delete",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@JobOfWorkID", (object) JobOfWorkID)
        }
      }.ExecuteNonQuery();
    }

    public JobOfWork Insert(JobOfWork oJobOfWork, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "JobOfWork_Insert";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.Add(new SqlParameter("@JobID", (object) oJobOfWork.JobID));
      sqlCommand.Parameters.Add(new SqlParameter("@Deleted", (object) oJobOfWork.Deleted));
      sqlCommand.Parameters.Add(new SqlParameter("@PONumber", (object) oJobOfWork.PONumber));
      sqlCommand.Parameters.Add(new SqlParameter("@Status", (object) oJobOfWork.Status));
      sqlCommand.Parameters.Add(new SqlParameter("@Priority", (object) oJobOfWork.Priority));
      sqlCommand.Parameters.Add(new SqlParameter("@QualificationID", (object) oJobOfWork.QualificationID));
      if (DateTime.Compare(oJobOfWork.PriorityDateSet, DateTime.MinValue) == 0)
        sqlCommand.Parameters.Add(new SqlParameter("@PriorityDateSet", (object) DBNull.Value));
      else
        sqlCommand.Parameters.Add(new SqlParameter("@PriorityDateSet", (object) oJobOfWork.PriorityDateSet));
      oJobOfWork.SetJobOfWorkID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()));
      oJobOfWork.Exists = true;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = oJobOfWork.JobItems.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          JobItem current = (JobItem) enumerator1.Current;
          current.SetJobOfWorkID = (object) oJobOfWork.JobOfWorkID;
          this._database.JobItems.Insert(current, trans);
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
        enumerator2 = oJobOfWork.EngineerVisits.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          EngineerVisit current = (EngineerVisit) enumerator2.Current;
          current.SetJobOfWorkID = (object) oJobOfWork.JobOfWorkID;
          this._database.EngineerVisits.Insert(current, oJobOfWork.JobID, trans);
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      return oJobOfWork;
    }

    public JobOfWork Insert(JobOfWork oJobOfWork)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) oJobOfWork.JobID, true);
      this._database.AddParameter("@Deleted", (object) oJobOfWork.Deleted, true);
      this._database.AddParameter("@PONumber ", (object) oJobOfWork.PONumber, true);
      this._database.AddParameter("@Status", (object) oJobOfWork.Status, true);
      this._database.AddParameter("@Priority ", (object) oJobOfWork.Priority, true);
      this._database.AddParameter("@QualificationID ", (object) oJobOfWork.QualificationID, true);
      if (DateTime.Compare(oJobOfWork.PriorityDateSet, DateTime.MinValue) == 0 | DateTime.Compare(oJobOfWork.PriorityDateSet, DateTime.MinValue) == 0)
        this._database.AddParameter("@PriorityDateSet ", (object) DBNull.Value, true);
      else
        this._database.AddParameter("@PriorityDateSet ", (object) oJobOfWork.PriorityDateSet, true);
      oJobOfWork.SetJobOfWorkID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobOfWork_Insert", true)));
      oJobOfWork.Exists = true;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = oJobOfWork.JobItems.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          JobItem current = (JobItem) enumerator1.Current;
          current.SetJobOfWorkID = (object) oJobOfWork.JobOfWorkID;
          this._database.JobItems.Insert(current);
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
        enumerator2 = oJobOfWork.EngineerVisits.GetEnumerator();
        while (enumerator2.MoveNext())
        {
          EngineerVisit current = (EngineerVisit) enumerator2.Current;
          current.SetJobOfWorkID = (object) oJobOfWork.JobOfWorkID;
          this._database.EngineerVisits.Insert(current, oJobOfWork.JobID, 0, 0);
        }
      }
      finally
      {
        if (enumerator2 is IDisposable)
          (enumerator2 as IDisposable).Dispose();
      }
      return oJobOfWork;
    }

    public void Update_PONumber(JobOfWork oJobOfWork)
    {
      if (DateTime.Compare(oJobOfWork.PriorityDateSet, DateTime.MinValue) == 0)
        oJobOfWork.PriorityDateSet = DateTime.Now;
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) oJobOfWork.JobOfWorkID, true);
      this._database.AddParameter("@PONumber ", (object) oJobOfWork.PONumber, true);
      this._database.AddParameter("@Priority", (object) oJobOfWork.Priority, true);
      this._database.AddParameter("@PriorityDateSet", (object) oJobOfWork.PriorityDateSet, true);
      this._database.AddParameter("@QualificationID", (object) oJobOfWork.QualificationID, true);
      this._database.ExecuteSP_NO_Return("JobOfWork_Update_PONumber", true);
    }

    public void Update_PONumber(JobOfWork oJobOfWork, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.CommandText = "JobOfWork_Update_PONumber";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.Add(new SqlParameter("@JobOfWorkID", (object) oJobOfWork.JobOfWorkID));
      sqlCommand.Parameters.Add(new SqlParameter("@PONumber", (object) oJobOfWork.PONumber));
      sqlCommand.Parameters.Add(new SqlParameter("@QualificationID", (object) oJobOfWork.QualificationID));
      sqlCommand.Parameters.Add(new SqlParameter("@Priority", (object) oJobOfWork.Priority));
      if (DateTime.Compare(oJobOfWork.PriorityDateSet, DateTime.MinValue) == 0)
        sqlCommand.Parameters.Add(new SqlParameter("@PriorityDateSet", (object) DBNull.Value));
      else
        sqlCommand.Parameters.Add(new SqlParameter("@PriorityDateSet", (object) oJobOfWork.PriorityDateSet));
      sqlCommand.ExecuteNonQuery();
    }

    public void Update_Status(int JobOfWorkID, int Status)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) JobOfWorkID, true);
      this._database.AddParameter("@Status ", (object) Status, true);
      this._database.ExecuteSP_NO_Return("JobOfWork_Update_Status", true);
    }

    public void Update_Priority(JobOfWork Jow)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) Jow.JobOfWorkID, true);
      this._database.AddParameter("@Priority ", (object) Jow.Priority, true);
      this._database.AddParameter("@PriorityDateSet ", (object) Jow.PriorityDateSet, true);
      this._database.AddParameter("@QualificationID ", (object) Jow.QualificationID, true);
      this._database.ExecuteSP_NO_Return("JobOfWork_Update_Priority", true);
    }

    public DataView JobOfWork_Get_For_Job(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (JobOfWork_Get_For_Job), true);
      table.TableName = Enums.TableNames.tblJobOfWork.ToString();
      return new DataView(table);
    }

    public DataView JobOfWork_Get_For_Job(int JobID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (JobOfWork_Get_For_Job);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@JobID", (object) JobID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblJobOfWork.ToString();
      return new DataView(table);
    }

    public DataTable JobOfWork_Get_ForEngineerVisitID(int engineerVisitId)
    {
      DataTable dataTable1 = new DataTable();
      SqlCommand Command = new SqlCommand(nameof (JobOfWork_Get_ForEngineerVisitID), new SqlConnection(this._database.ServerConnectionString));
      DataTable dataTable2;
      try
      {
        Command.CommandType = CommandType.StoredProcedure;
        Command.Parameters.AddWithValue("@EngineerVisitID", (object) engineerVisitId);
        dataTable1 = this._database.ExecuteCommand_DataTable(Command);
        dataTable1.TableName = "tblJobOfWork";
        dataTable2 = dataTable1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        dataTable2 = dataTable1;
        ProjectData.ClearProjectError();
      }
      finally
      {
        Command.Connection.Close();
      }
      return dataTable2;
    }

    public JobOfWork JobOfWork_Get(int JobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) JobOfWorkID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (JobOfWork_Get), true);
      JobOfWork jobOfWork = (JobOfWork) null;
      if (dataTable.Rows.Count > 0)
      {
        jobOfWork = new JobOfWork();
        DataRow row = dataTable.Rows[0];
        jobOfWork.IgnoreExceptionsOnSetMethods = true;
        jobOfWork.Exists = true;
        jobOfWork.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(row["JobOFWorkID"]);
        jobOfWork.SetJobID = RuntimeHelpers.GetObjectValue(row["JobID"]);
        jobOfWork.SetPONumber = RuntimeHelpers.GetObjectValue(row["PONumber"]);
        jobOfWork.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
        jobOfWork.SetStatus = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["Status"]));
        jobOfWork.SetPriority = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["Priority"]));
        jobOfWork.PriorityDateSet = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["PriorityDateSet"]));
        if (dataTable.Rows[0].Table.Columns.Contains("QualificationID"))
          jobOfWork.SetQualificationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["QualificationID"]));
      }
      return jobOfWork;
    }

    public JobOfWork JobOfWork_Get_As_Object(int jobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) jobOfWorkID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable("JobOfWork_Get", true);
      JobOfWork jobOfWork = (JobOfWork) null;
      if (dataTable.Rows.Count > 0)
      {
        jobOfWork = new JobOfWork();
        DataRow row = dataTable.Rows[0];
        jobOfWork.IgnoreExceptionsOnSetMethods = true;
        jobOfWork.Exists = true;
        jobOfWork.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(row["JobOFWorkID"]);
        jobOfWork.SetJobID = RuntimeHelpers.GetObjectValue(row["JobID"]);
        jobOfWork.SetPONumber = RuntimeHelpers.GetObjectValue(row["PONumber"]);
        jobOfWork.SetDeleted = Conversions.ToBoolean(row["Deleted"]);
        jobOfWork.SetStatus = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["Status"]));
        jobOfWork.SetPriority = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["Priority"]));
        jobOfWork.PriorityDateSet = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["PriorityDateSet"]));
        if (dataTable.Rows[0].Table.Columns.Contains("QualificationID"))
          jobOfWork.SetQualificationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["QualificationID"]));
        jobOfWork.JobItems = this._database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID);
        jobOfWork.EngineerVisits = this._database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(jobOfWork.JobOfWorkID);
      }
      return jobOfWork;
    }

    public ArrayList JobOfWork_Get_For_Job_As_Objects(int JobID, SqlTransaction trans)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.JobOfWork_Get_For_Job(JobID, trans).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          JobOfWork jobOfWork = new JobOfWork();
          jobOfWork.IgnoreExceptionsOnSetMethods = true;
          jobOfWork.Exists = true;
          jobOfWork.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(current["JobOFWorkID"]);
          jobOfWork.SetJobID = RuntimeHelpers.GetObjectValue(current[nameof (JobID)]);
          jobOfWork.SetPONumber = RuntimeHelpers.GetObjectValue(current["PONumber"]);
          jobOfWork.SetDeleted = Conversions.ToBoolean(current["Deleted"]);
          jobOfWork.SetStatus = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Status"]));
          jobOfWork.SetPriority = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Priority"]));
          jobOfWork.PriorityDateSet = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["PriorityDateSet"]));
          if (current.Table.Columns.Contains("QualificationID"))
            jobOfWork.SetQualificationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["QualificationID"]));
          jobOfWork.JobItems = this._database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID, trans);
          jobOfWork.EngineerVisits = this._database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID, trans);
          arrayList.Add((object) jobOfWork);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }

    public ArrayList JobOfWork_Get_For_Job_As_Objects(int JobID)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.JobOfWork_Get_For_Job(JobID).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          JobOfWork jobOfWork = new JobOfWork();
          jobOfWork.IgnoreExceptionsOnSetMethods = true;
          jobOfWork.Exists = true;
          jobOfWork.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(current["JobOFWorkID"]);
          jobOfWork.SetJobID = RuntimeHelpers.GetObjectValue(current[nameof (JobID)]);
          jobOfWork.SetPONumber = RuntimeHelpers.GetObjectValue(current["PONumber"]);
          jobOfWork.SetDeleted = Conversions.ToBoolean(current["Deleted"]);
          jobOfWork.SetStatus = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Status"]));
          jobOfWork.SetPriority = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Priority"]));
          jobOfWork.PriorityDateSet = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["PriorityDateSet"]));
          if (current.Table.Columns.Contains("QualificationID"))
            jobOfWork.SetQualificationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["QualificationID"]));
          jobOfWork.JobItems = this._database.JobItems.JobOfWork_Get_For_Job_Of_Work_As_Objects(jobOfWork.JobOfWorkID);
          jobOfWork.EngineerVisits = this._database.EngineerVisits.EngineerVisits_Get_For_Job_Of_Work_As_Objects_Light(jobOfWork.JobOfWorkID);
          arrayList.Add((object) jobOfWork);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }

    public void Update_PONumberByJobOfWorkID(int jobOfWorkId, string poNumber)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID ", (object) jobOfWorkId, true);
      this._database.AddParameter("@PONumber ", (object) poNumber, true);
      this._database.ExecuteSP_NO_Return("JobOfWork_Update_PONumberByJobOfWorkID", true);
    }

    public List<JobOfWork> Get_ByJobId(int jobId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) jobId, true);
      DataTable source1 = this._database.ExecuteSP_DataTable("JobOfWork_Get_For_Job", true);
      if (source1 == null || source1.Rows.Count <= 0)
        return (List<JobOfWork>) null;
      EnumerableRowCollection<DataRow> source2 = source1.AsEnumerable();
      Func<DataRow, JobOfWork> selector;
      // ISSUE: reference to a compiler-generated field
      if (JobOfWorkSQL._Closure\u0024__.\u0024I18\u002D0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = JobOfWorkSQL._Closure\u0024__.\u0024I18\u002D0;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        JobOfWorkSQL._Closure\u0024__.\u0024I18\u002D0 = selector = (Func<DataRow, JobOfWork>) (x => new JobOfWork()
        {
          Exists = true,
          SetJobOfWorkID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["JobOfWorkId"])),
          SetJobID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["JobId"])),
          SetPONumber = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(x["PONumber"])),
          SetPriority = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["Priority"])),
          SetStatus = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["Status"])),
          PriorityDateSet = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(x["PriorityDateSet"])),
          SetQualificationID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(x["QualificationID"]))
        });
      }
      return source2.Select<DataRow, JobOfWork>(selector).ToList<JobOfWork>();
    }
  }
}
