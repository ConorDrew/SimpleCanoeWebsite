// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerTimeSheets.EngineerTimeSheetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerTimeSheets
{
  public class EngineerTimeSheetSQL
  {
    private Database _database;

    public EngineerTimeSheetSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int EngineerTimeSheetID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerTimeSheetID", (object) EngineerTimeSheetID, true);
      this._database.ExecuteSP_NO_Return("EngineerTimeSheet_Delete", true);
    }

    public EngineerTimeSheet Insert(EngineerTimeSheet oEngineerTimeSheet)
    {
      this._database.ClearParameter();
      this.AddEngineerVisitTimeSheetParametersToCommand(ref oEngineerTimeSheet);
      oEngineerTimeSheet.SetEngineerTimeSheetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerTimeSheet_Insert", true)));
      oEngineerTimeSheet.Exists = true;
      return oEngineerTimeSheet;
    }

    public void Update(EngineerTimeSheet oEngineerTimeSheet)
    {
      this._database.ClearParameter();
      this.AddEngineerVisitTimeSheetParametersToCommand(ref oEngineerTimeSheet);
      this._database.AddParameter("@EngineerTimeSheetID", (object) oEngineerTimeSheet.EngineerTimeSheetID, true);
      this._database.ExecuteSP_NO_Return("EngineerTimeSheet_Update", true);
    }

    private void AddEngineerVisitTimeSheetParametersToCommand(
      ref EngineerTimeSheet oEngineerTimeSheet)
    {
      Database database = this._database;
      database.AddParameter("@EngineerID", (object) oEngineerTimeSheet.EngineerID, true);
      database.AddParameter("@StartDateTime", (object) oEngineerTimeSheet.StartDateTime, true);
      database.AddParameter("@EndDateTime", (object) oEngineerTimeSheet.EndDateTime, true);
      database.AddParameter("@Comments", (object) oEngineerTimeSheet.Comments, true);
      database.AddParameter("@TimesheetTypeID", (object) oEngineerTimeSheet.TimeSheetTypeID, true);
    }

    public DataView GetAll(string Where, string Where2)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Where", (object) Where, true);
      this._database.AddParameter("@Where2", (object) Where2, true);
      DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitTimeSheet_GetAll_RD", true);
      table.TableName = Enums.TableNames.tblEngineerTimesheet.ToString();
      return new DataView(table);
    }

    public void UpdateVisit(EngineerTimeSheet oEngineerTimeSheet)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerTimesheetID", (object) oEngineerTimeSheet.EngineerTimeSheetID, true);
      this._database.AddParameter("@StartDateTime", (object) oEngineerTimeSheet.StartDateTime, true);
      this._database.AddParameter("@EndDateTime", (object) oEngineerTimeSheet.EndDateTime, true);
      this._database.AddParameter("@Comments", (object) oEngineerTimeSheet.Comments, true);
      this._database.ExecuteSP_NO_Return("EngineerTimeSheet_UpdateVisit", true);
    }

    public EngineerTimeSheet Get(int EngineerTimeSheetID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerTimeSheetID", (object) EngineerTimeSheetID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable("EngineerTimeSheet_Get_RD", true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (EngineerTimeSheet) null;
      EngineerTimeSheet engineerTimeSheet1 = new EngineerTimeSheet();
      EngineerTimeSheet engineerTimeSheet2 = engineerTimeSheet1;
      engineerTimeSheet2.IgnoreExceptionsOnSetMethods = true;
      engineerTimeSheet2.SetEngineerTimeSheetID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (EngineerTimeSheetID)]);
      engineerTimeSheet2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]);
      engineerTimeSheet2.StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartDateTime"]));
      engineerTimeSheet2.EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndDateTime"]));
      engineerTimeSheet2.SetComments = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Comments"]);
      engineerTimeSheet2.SetTimeSheetTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TimeSheetTypeID"]);
      engineerTimeSheet2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitID"]);
      engineerTimeSheet1.Exists = true;
      return engineerTimeSheet1;
    }
  }
}
