// Decompiled with JetBrains decompiler
// Type: FSM.Entity.LetterManager.LetterManagerSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity.LetterManager
{
  public class LetterManagerSQL
  {
    private Database _database;

    public LetterManagerSQL(Database database)
    {
      this._database = database;
    }

    public DataView GetBucketsL1(DateTime LetterManagerFilterDate, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (GetBucketsL1), true));
    }

    public DataView MakeServiceLetter(int engineervisitid)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) engineervisitid, true);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (MakeServiceLetter), true));
    }

    public DataView ClearStuckSite(DateTime Lastservicedate, int SiteID, string Type)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LastServiceDate", (object) Lastservicedate.ToString("yyyy-MM-dd"), true);
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      this._database.AddParameter("@Type", (object) Type, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_ClearStuckSites", true));
    }

    public DataView GetLetterScheduledAppointments(
      DateTime LetterManagerFilterDate,
      int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Date", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (GetLetterScheduledAppointments), true));
    }

    public DataView Letter1ManagerMK2Profile(
      DateTime LetterManagerFilterDate,
      int CustomerID,
      int top = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      this._database.AddParameter("@top", (object) top, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_1_MK2_Profile_New", true));
    }

    public DataView Letter1ManagerMK2(DateTime LetterManagerFilterDate, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_1_MK2_New", true));
    }

    public DataView Letter1Manager(
      DateTime LetterManagerFilterDate,
      int CustomerID,
      int Days = -309)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      this._database.AddParameter("@Days", (object) Days, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager", true));
    }

    public DataTable Letter2Manager(
      DateTime LetterManagerFilterDate,
      int CustomerID,
      int Days = -330)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      this._database.AddParameter("@Days", (object) Days, true);
      return this._database.ExecuteSP_DataTable(nameof (Letter2Manager), true);
    }

    public DataView Letter2ManagerMK2(DateTime LetterManagerFilterDate, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_2_MK2_New", true));
    }

    public DataView Letter3ManagerMK2(DateTime LetterManagerFilterDate, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_3_MK2_New", true));
    }

    public DataTable Letter3Manager(DateTime LetterManagerFilterDate, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return this._database.ExecuteSP_DataTable(nameof (Letter3Manager), true);
    }

    public void LetterGenerated(
      int SiteID,
      string LetterType,
      DateTime LastServiceDate,
      int JobID,
      string FolderPath,
      SqlTransaction trans)
    {
      new SqlCommand()
      {
        CommandText = nameof (LetterGenerated),
        CommandType = CommandType.StoredProcedure,
        Transaction = trans,
        Connection = trans.Connection,
        Parameters = {
          new SqlParameter("@SiteID", (object) SiteID),
          new SqlParameter("@LetterType", (object) LetterType),
          new SqlParameter("@LastServiceDate", (object) LastServiceDate),
          new SqlParameter("@JobID", (object) JobID),
          new SqlParameter("@FolderPath", (object) FolderPath)
        }
      }.ExecuteNonQuery();
    }

    public void LetterGeneratedMK2(
      int SiteID,
      string LetterType,
      DateTime LastServiceDate,
      int JobID,
      string FolderPath,
      int fuelId = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      this._database.AddParameter("@LetterType", (object) LetterType, true);
      this._database.AddParameter("@LastServiceDate", (object) LastServiceDate, true);
      this._database.AddParameter("@JobID", (object) JobID, true);
      this._database.AddParameter("@FolderPath", (object) FolderPath, true);
      this._database.AddParameter("@FuelID", (object) fuelId, true);
      this._database.ExecuteSP_NO_Return("LetterGenerated", true);
    }

    public DataTable LetterReport(int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      return this._database.ExecuteSP_DataTable(nameof (LetterReport), true);
    }

    public DataTable Letter3_TomorrowsVisit(DateTime tomorrow)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@TomorrowStart", (object) Conversions.ToDate(Strings.Format((object) tomorrow, "dd-MMM-yyyy") + " 00:00:00"), true);
      this._database.AddParameter("@TomorrowEnd", (object) Conversions.ToDate(Strings.Format((object) tomorrow, "dd-MMM-yyyy") + " 23:59:59"), true);
      return this._database.ExecuteSP_DataTable(nameof (Letter3_TomorrowsVisit), true);
    }

    public void Clear_LetterDays_Table()
    {
      this._database.ExecuteWithOutReturn("DELETE FROM tblLetterDays", false);
    }

    public void Update_LetterDays_Table(
      DateTime MondayDate,
      DateTime TheDate,
      int ApptCount,
      int AM,
      int PM,
      int MinsTally,
      int LoopNumber)
    {
      if (PM == 0)
        this._database.ExecuteWithOutReturn("UPDATE tblLetterDays SET ApptCount = '" + Conversions.ToString(ApptCount) + "', AM = '" + Conversions.ToString(AM) + "', MinsTally = '" + Conversions.ToString(MinsTally) + "' WHERE MondayDate = '" + Strings.Format((object) MondayDate, "yyyy-MM-dd") + "' AND TheDate = '" + Strings.Format((object) TheDate, "yyyy-MM-dd") + "' AND LoopNumber = '" + Conversions.ToString(LoopNumber) + "'", false);
      else
        this._database.ExecuteWithOutReturn("UPDATE tblLetterDays SET ApptCount = '" + Conversions.ToString(ApptCount) + "', PM = '" + Conversions.ToString(PM) + "', MinsTally = '" + Conversions.ToString(MinsTally) + "' WHERE MondayDate = '" + Strings.Format((object) MondayDate, "yyyy-MM-dd") + "' AND TheDate = '" + Strings.Format((object) TheDate, "yyyy-MM-dd") + "' AND LoopNumber = '" + Conversions.ToString(LoopNumber) + "'", false);
    }

    public void Insert_LetterDays_Table(
      DateTime MondayDate,
      DateTime TheDate,
      int MinsTally,
      int LoopNumber)
    {
      this._database.ExecuteWithOutReturn("INSERT INTO tblLetterDays (MondayDate, TheDate, ApptCount, AM, PM, MinsTally, LoopNumber) VALUES ('" + Strings.Format((object) MondayDate, "yyyy-MM-dd") + "','" + Strings.Format((object) TheDate, "yyyy-MM-dd") + "',1,1,1,'" + Conversions.ToString(MinsTally) + "','" + Conversions.ToString(LoopNumber) + "')", false);
    }

    public DataView Get_Letter1Jobs(
      DateTime LetterManagerFilterDate,
      int CustomerID,
      bool profile,
      int top = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      this._database.AddParameter("@Profile", (object) profile, true);
      this._database.AddParameter("@Top", (object) top, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_1_Mk4", true));
    }

    public DataView Get_Letter1Jobs_MultipleFuel(
      DateTime LetterManagerFilterDate,
      int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_1_Mk4_MultipleFuel", true));
    }

    public DataView Get_Letter2Jobs(DateTime LetterManagerFilterDate, int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_2_Mk4", true));
    }

    public DataView Get_Letter3Jobs(
      DateTime LetterManagerFilterDate,
      int CustomerID,
      int fuelId = 0)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_3_Mk4", true));
    }

    public DataView GetLetterScheduledAppointmentsMK3(
      DateTime LetterManagerFilterDate,
      int CustomerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Date", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@CustomerID", (object) CustomerID, true);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (GetLetterScheduledAppointmentsMK3), true));
    }

    public DataTable Get_Appointments_Main_MK3(
      DateTime StartDate,
      int TimeReq,
      int days = 14,
      int TimeLimit = 240)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@StartDate", (object) StartDate, true);
      this._database.AddParameter("@timereq", (object) TimeReq, true);
      this._database.AddParameter("@Days", (object) days, true);
      this._database.AddParameter("@TimeLimit", (object) TimeLimit, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable("Get_Appointments_Main", true);
      dataTable.TableName = Enums.TableNames.tblJobItem.ToString();
      return dataTable;
    }

    public DataTable LetterManager_GetJob_FromSiteAndDate(int siteId, DateTime bookedDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SiteID", (object) siteId, true);
      this._database.AddParameter("@VisitDate", (object) bookedDate, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (LetterManager_GetJob_FromSiteAndDate), true);
      dataTable.TableName = Enums.TableNames.tblJob.ToString();
      return dataTable;
    }

    public DataTable LetterGenerated_CheckToday(
      string letterType,
      int jobId,
      DateTime genDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterType", (object) letterType, true);
      this._database.AddParameter("@JobID", (object) jobId, true);
      this._database.AddParameter("@GenDate", (object) genDate, true);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (LetterGenerated_CheckToday), true);
      dataTable.TableName = Enums.TableNames.tblJob.ToString();
      return dataTable;
    }

    public DataView LetterManagerAddSiteMK3(DateTime LetterManagerFilterDate, int SiteID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@LetterManagerFilterDate", (object) LetterManagerFilterDate, true);
      this._database.AddParameter("@SiteID", (object) SiteID, true);
      return new DataView(this._database.ExecuteSP_DataTable("LetterManager_AddSite_MK3", true));
    }
  }
}
