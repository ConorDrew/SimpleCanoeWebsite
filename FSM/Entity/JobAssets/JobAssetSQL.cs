// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobAssets.JobAssetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobAssets
{
  public class JobAssetSQL
  {
    private Database _database;

    public JobAssetSQL(Database database)
    {
      this._database = database;
    }

    public JobAsset Insert(JobAsset oJobAsset, SqlTransaction trans)
    {
      oJobAsset.SetJobAssetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(new SqlCommand()
      {
        CommandText = "JobAsset_Insert",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@JobID", (object) oJobAsset.JobID),
          new SqlParameter("@AssetID", (object) oJobAsset.AssetID)
        }
      }.ExecuteScalar()));
      return oJobAsset;
    }

    public JobAsset Insert(JobAsset oJobAsset)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) oJobAsset.JobID, true);
      this._database.AddParameter("@AssetID", (object) oJobAsset.AssetID, true);
      oJobAsset.SetJobAssetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobAsset_Insert", true)));
      return oJobAsset;
    }

    public void Delete(int JobID, SqlTransaction trans)
    {
      new SqlCommand()
      {
        CommandText = "JobAsset_Delete",
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@JobID", (object) JobID)
        }
      }.ExecuteNonQuery();
    }

    public void Delete(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      this._database.ExecuteSP_OBJECT("JobAsset_Delete", true);
    }

    public DataView JobAsset_Get_For_Job(int JobID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (JobAsset_Get_For_Job), true);
      table.TableName = Enums.TableNames.tblJobAsset.ToString();
      return new DataView(table);
    }

    public DataView JobAsset_Get_For_Job(int JobID, SqlTransaction trans)
    {
      SqlCommand selectCommand = new SqlCommand();
      selectCommand.CommandText = nameof (JobAsset_Get_For_Job);
      selectCommand.CommandType = CommandType.StoredProcedure;
      selectCommand.Transaction = trans;
      selectCommand.Connection = trans.Connection;
      selectCommand.Parameters.AddWithValue("@JobID", (object) JobID);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable table = dataSet.Tables[0];
      table.TableName = Enums.TableNames.tblJobAsset.ToString();
      return new DataView(table);
    }

    public ArrayList JobAsset_Get_For_Job_As_Objects(int JobID)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.JobAsset_Get_For_Job(JobID).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          arrayList.Add((object) new JobAsset()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetJobAssetID = RuntimeHelpers.GetObjectValue(current["JobAssetID"]),
            SetJobID = RuntimeHelpers.GetObjectValue(current[nameof (JobID)]),
            SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
          });
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }

    public ArrayList JobAsset_Get_For_Job_As_Objects(int JobID, SqlTransaction trans)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator;
      try
      {
        enumerator = this.JobAsset_Get_For_Job(JobID, trans).Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          arrayList.Add((object) new JobAsset()
          {
            IgnoreExceptionsOnSetMethods = true,
            SetJobAssetID = RuntimeHelpers.GetObjectValue(current["JobAssetID"]),
            SetJobID = RuntimeHelpers.GetObjectValue(current[nameof (JobID)]),
            SetAssetID = RuntimeHelpers.GetObjectValue(current["AssetID"])
          });
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return arrayList;
    }
  }
}
