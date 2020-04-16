// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobItems.JobItemSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobItems
{
  public class JobItemSQL
  {
    private Database _database;

    public JobItemSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(string JobItemIDs, int JobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobItemIDs", (object) JobItemIDs, true);
      this._database.AddParameter("@JobOfWorkID", (object) JobOfWorkID, true);
      this._database.ExecuteSP_NO_Return("JobItem_Delete", true);
    }

    public void DeleteAll_ForJOW(int JobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) JobOfWorkID, true);
      this._database.ExecuteSP_NO_Return("JobItem_DeleteALL_ForJOW", true);
    }

    public void Delete(string JobItemIDs, int JobOfWorkID, SqlTransaction trans)
    {
      new SqlCommand()
      {
        CommandText = "JobItem_Delete",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@JobOfWorkID", (object) JobOfWorkID),
          new SqlParameter("@JobItemIDs", (object) JobItemIDs)
        }
      }.ExecuteNonQuery();
    }

    public JobItem Insert(JobItem oJobItem, SqlTransaction trans)
    {
      SqlCommand sqlCommand = new SqlCommand();
      if (oJobItem.JobItemID > 0)
      {
        sqlCommand.CommandText = "JobItem_Update";
        sqlCommand.Parameters.Add(new SqlParameter("@JobItemID", (object) oJobItem.JobItemID));
      }
      else
        sqlCommand.CommandText = "JobItem_Insert";
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = trans;
      sqlCommand.Connection = trans.Connection;
      sqlCommand.Parameters.Add(new SqlParameter("@JobOfWorkID", (object) oJobItem.JobOfWorkID));
      sqlCommand.Parameters.Add(new SqlParameter("@Summary", (object) oJobItem.Summary));
      sqlCommand.Parameters.Add(new SqlParameter("@RateID", (object) oJobItem.RateID));
      sqlCommand.Parameters.Add(new SqlParameter("@Qty", (object) oJobItem.Qty));
      sqlCommand.Parameters.Add(new SqlParameter("@SystemLinkID", (object) oJobItem.SystemLinkID));
      if (oJobItem.JobItemID > 0)
        sqlCommand.ExecuteNonQuery();
      else
        oJobItem.SetJobItemID = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar());
      return oJobItem;
    }

    public JobItem Insert(JobItem oJobItem)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) oJobItem.JobOfWorkID, true);
      this._database.AddParameter("@Summary", (object) oJobItem.Summary, true);
      this._database.AddParameter("@RateID", (object) oJobItem.RateID, true);
      this._database.AddParameter("@Qty", (object) oJobItem.Qty, true);
      this._database.AddParameter("@SystemLinkID", (object) oJobItem.SystemLinkID, true);
      if (oJobItem.JobItemID > 0)
      {
        this._database.AddParameter("@JobItemID", (object) oJobItem.JobItemID, true);
        this._database.ExecuteSP_NO_Return("JobItem_Update", true);
      }
      else
        oJobItem.SetJobItemID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobItem_Insert", true)));
      return oJobItem;
    }

    public DataView JobItems_Get_For_Job_Of_Work(int JobOfWorkID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobOfWorkID", (object) JobOfWorkID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (JobItems_Get_For_Job_Of_Work), true);
      table.TableName = Enums.TableNames.tblJobItem.ToString();
      return new DataView(table);
    }

    public DataView JobItems_Get_For_Job_Of_Work(int JobOfWorkID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (JobItems_Get_For_Job_Of_Work);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@JobOfWorkID", (object) JobOfWorkID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblJobItem.ToString();
      return new DataView(table);
    }

    public ArrayList JobOfWork_Get_For_Job_Of_Work_As_Objects(int JobOfWorkID)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.JobItems_Get_For_Job_Of_Work(JobOfWorkID).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          JobItem jobItem = new JobItem();
          jobItem.IgnoreExceptionsOnSetMethods = true;
          jobItem.SetJobItemID = RuntimeHelpers.GetObjectValue(current["JobItemID"]);
          jobItem.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(current[nameof (JobOfWorkID)]);
          jobItem.SetSummary = RuntimeHelpers.GetObjectValue(current["Summary"]);
          jobItem.SetRateID = RuntimeHelpers.GetObjectValue(current["RateID"]);
          jobItem.SetQty = RuntimeHelpers.GetObjectValue(current["Qty"]);
          if (current.Table.Columns.Contains("SystemLinkID"))
            jobItem.SetSystemLinkID = RuntimeHelpers.GetObjectValue(current["SystemLinkID"]);
          arrayList.Add((object) jobItem);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }

    public ArrayList JobOfWork_Get_For_Job_Of_Work_As_Objects(
      int JobOfWorkID,
      SqlTransaction trans)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.JobItems_Get_For_Job_Of_Work(JobOfWorkID, trans).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          JobItem jobItem = new JobItem();
          jobItem.IgnoreExceptionsOnSetMethods = true;
          jobItem.SetJobItemID = RuntimeHelpers.GetObjectValue(current["JobItemID"]);
          jobItem.SetJobOfWorkID = RuntimeHelpers.GetObjectValue(current[nameof (JobOfWorkID)]);
          jobItem.SetSummary = RuntimeHelpers.GetObjectValue(current["Summary"]);
          jobItem.SetRateID = RuntimeHelpers.GetObjectValue(current["RateID"]);
          jobItem.SetQty = RuntimeHelpers.GetObjectValue(current["Qty"]);
          if (current.Table.Columns.Contains("SystemLinkID"))
            jobItem.SetSystemLinkID = RuntimeHelpers.GetObjectValue(current["SystemLinkID"]);
          arrayList.Add((object) jobItem);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }

    public DataView JobItems_Get_For_Job(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (JobItems_Get_For_Job), true);
      table.TableName = Enums.TableNames.tblJobItem.ToString();
      return new DataView(table);
    }
  }
}
