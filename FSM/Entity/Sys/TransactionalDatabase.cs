// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.TransactionalDatabase
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Sys
{
  public class TransactionalDatabase
  {
    public SqlTransaction Transaction_Get()
    {
      SqlConnection sqlConnection = new SqlConnection(App.TheSystem.Configuration.ConnectionString);
      try
      {
        sqlConnection.Open();
        return sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        if ((uint) sqlConnection.State > 0U)
          sqlConnection.Close();
        sqlConnection.Dispose();
        throw;
      }
    }

    public SqlCommand CreateStoredProcedure(string spName, SqlTransaction Trans)
    {
      return new SqlCommand()
      {
        CommandText = spName,
        CommandType = CommandType.StoredProcedure,
        Transaction = Trans
      };
    }

    public void ExecuteNonQuerySPTrans(SqlCommand cmd)
    {
      cmd.Connection = cmd.Transaction.Connection;
      try
      {
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        throw;
      }
    }

    public DataTable ExecuteTableSPTrans(SqlCommand cmd)
    {
      cmd.Connection = cmd.Transaction.Connection;
      try
      {
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        return dataSet.Tables[0];
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        throw;
      }
    }

    public int ExecuteScalarSPTrans(SqlCommand cmd)
    {
      cmd.Connection = cmd.Transaction.Connection;
      try
      {
        return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(cmd.ExecuteScalar()));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        throw;
      }
    }

    public void Transaction_Commit(SqlTransaction trans)
    {
      SqlConnection connection = trans.Connection;
      trans.Commit();
      connection.Close();
    }

    public void Transaction_Rollback(SqlTransaction trans)
    {
      SqlConnection connection = trans.Connection;
      trans.Rollback();
      connection.Close();
    }
  }
}
