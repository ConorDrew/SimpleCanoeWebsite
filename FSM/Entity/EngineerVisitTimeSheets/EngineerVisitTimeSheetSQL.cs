// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitTimeSheets.EngineerVisitTimeSheetSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitTimeSheets
{
  public class EngineerVisitTimeSheetSQL
  {
    private Database _database;

    public EngineerVisitTimeSheetSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitTimeSheet_Delete", true);
    }

    public DataView EngineerVisitTimeSheet_Get_For_EngineerVisitID(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, false);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitTimeSheet_Get_For_EngineerVisitID), true);
      table.TableName = Enums.TableNames.tblEngineerVisitTimesheet.ToString();
      return new DataView(table);
    }

    public EngineerVisitTimeSheet Insert(
      EngineerVisitTimeSheet oEngineerVisitTimeSheet)
    {
      this._database.ClearParameter();
      this.AddEngineerVisitTimeSheetParametersToCommand(ref oEngineerVisitTimeSheet);
      oEngineerVisitTimeSheet.SetEngineerVisitTimeSheetID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitTimeSheet_Insert", true)));
      oEngineerVisitTimeSheet.Exists = true;
      return oEngineerVisitTimeSheet;
    }

    private void AddEngineerVisitTimeSheetParametersToCommand(
      ref EngineerVisitTimeSheet oEngineerVisitTimeSheet)
    {
      Database database = this._database;
      database.AddParameter("@EngineerVisitID", (object) oEngineerVisitTimeSheet.EngineerVisitID, true);
      database.AddParameter("@StartDateTime", (object) oEngineerVisitTimeSheet.StartDateTime, true);
      database.AddParameter("@EndDateTime", (object) oEngineerVisitTimeSheet.EndDateTime, true);
      database.AddParameter("@Comments", (object) oEngineerVisitTimeSheet.Comments, true);
      database.AddParameter("@TimesheetTypeID", (object) oEngineerVisitTimeSheet.TimeSheetTypeID, true);
    }

    public DataView GetAll(string Where)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@WHERE", (object) Where, true);
      DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitTimeSheet_GetAll", true);
      table.TableName = Enums.TableNames.tblEngineerVisitTimesheet.ToString();
      return new DataView(table);
    }

    public DataView Get_CurrentCost_ByJobID(int jobId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@JobID", (object) jobId, true);
      return new DataView(this._database.ExecuteSP_DataTable("EngineerVisitTimesheet_Get_CurrentCost_ByJobID", true));
    }
  }
}
