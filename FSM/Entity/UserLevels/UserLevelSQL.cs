// Decompiled with JetBrains decompiler
// Type: FSM.Entity.UserLevels.UserLevelSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.UserLevels
{
  public class UserLevelSQL
  {
    private Database _database;

    public UserLevelSQL(Database database)
    {
      this._database = database;
    }

    public void Insert(int UserID, DataTable t)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) UserID, true);
      this._database.ExecuteSP_NO_Return("UserLevel_Delete", true);
      if (t == null)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = t.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          this._database.ClearParameter();
          this._database.AddParameter("@UserID", (object) UserID, true);
          this._database.AddParameter("@LevelID", RuntimeHelpers.GetObjectValue(current["LevelID"]), true);
          this._database.AddParameter("@Notes", (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Notes"])), true);
          this._database.AddParameter("@DatePassed", RuntimeHelpers.GetObjectValue(current["DatePassed"]), true);
          this._database.AddParameter("@DateExpires", RuntimeHelpers.GetObjectValue(current["DateExpires"]), true);
          this._database.AddParameter("@DateBooked", RuntimeHelpers.GetObjectValue(current["DateBooked"]), true);
          this._database.ExecuteSP_NO_Return("UserLevel_Insert", true);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public DataView Get(int UserID)
    {
      SqlCommand Command = new SqlCommand("UserLevels_Get", new SqlConnection(this._database.ServerConnectionString));
      Command.CommandType = CommandType.StoredProcedure;
      Command.Parameters.AddWithValue("@UserID", (object) UserID);
      DataTable table = this._database.ExecuteCommand_DataTable(Command);
      table.TableName = Enums.TableNames.tblUserQualification.ToString();
      return new DataView(table);
    }

    public DataView GetForSetup(int UserID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) UserID, true);
      DataTable table = this._database.ExecuteSP_DataTable("UserLevels_Setup_Get", true);
      table.TableName = Enums.TableNames.tblUserQualification.ToString();
      return new DataView(table);
    }
  }
}
