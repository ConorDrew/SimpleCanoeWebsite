// Decompiled with JetBrains decompiler
// Type: FSM.Entity.JobLock.JobLockSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.JobLock
{
  public class JobLockSQL
  {
    private Database _database;

    public JobLockSQL(Database databaseIn)
    {
      this._database = databaseIn;
    }

    public FSM.Entity.JobLock.JobLock Check(int JobID)
    {
      FSM.Entity.JobLock.JobLock jobLock = new FSM.Entity.JobLock.JobLock();
      jobLock.JobID = JobID;
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable("JobLock_IsRecordLocked", true);
      if (dataTable.Rows.Count <= 0)
        return (FSM.Entity.JobLock.JobLock) null;
      DataRow row = dataTable.Rows[0];
      jobLock.JobLockID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["JobLockID"]));
      jobLock.UserID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["UserID"]));
      jobLock.DateLock = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["DateLock"]));
      jobLock.NameOfUserWhoLocked = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["FullName"]));
      return jobLock;
    }

    public FSM.Entity.JobLock.JobLock JobLock(int JobID)
    {
      FSM.Entity.JobLock.JobLock jobLock = new FSM.Entity.JobLock.JobLock();
      jobLock.JobID = JobID;
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) JobID, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable("JobLock_IsRecordLocked", true);
      if (dataTable.Rows.Count > 0)
      {
        DataRow row = dataTable.Rows[0];
        jobLock.JobLockID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["JobLockID"]));
        jobLock.UserID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(row["UserID"]));
        jobLock.DateLock = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(row["DateLock"]));
        jobLock.NameOfUserWhoLocked = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(row["FullName"]));
        if (jobLock.UserID == App.loggedInUser.UserID)
        {
          this._database.ClearParameter();
          this._database.AddParameter("@JobID", (object) JobID, true);
          this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
          jobLock.JobLockID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobLock_Insert", true)));
        }
      }
      else
      {
        jobLock.UserID = App.loggedInUser.UserID;
        jobLock.DateLock = DateAndTime.Now;
        jobLock.NameOfUserWhoLocked = App.loggedInUser.Fullname;
        this._database.ClearParameter();
        this._database.AddParameter("@JobID", (object) JobID, true);
        this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
        jobLock.JobLockID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("JobLock_Insert", true)));
      }
      return jobLock;
    }

    public DataView GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("JobLock_GetAll", true);
      table.TableName = Enums.TableNames.tblJobLock.ToString();
      return new DataView(table);
    }

    public void Delete(int JobLockID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobLockID", (object) JobLockID, true);
      this._database.ExecuteSP_NO_Return("JobLock_Delete", true);
    }

    public void DeleteAll()
    {
      this._database.ClearParameter();
      this._database.AddParameter("@UserID", (object) App.loggedInUser?.UserID, true);
      this._database.ExecuteSP_NO_Return("JobLock_DeleteAll", true);
    }
  }
}
