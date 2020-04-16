// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerAbsence.EngineerAbsenceSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerAbsence
{
  public class EngineerAbsenceSQL
  {
    private Database _database;

    public EngineerAbsenceSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int EngineerAbsenceID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerAbsenceID", (object) EngineerAbsenceID, false);
      this._database.ExecuteSP_NO_Return("EngineerAbsence_Delete", true);
    }

    public FSM.Entity.EngineerAbsence.EngineerAbsence EngineerAbsence_Get(
      int EngineerAbsenceID)
    {
      DataTable dataTable1 = new DataTable();
      FSM.Entity.EngineerAbsence.EngineerAbsence engineerAbsence1 = new FSM.Entity.EngineerAbsence.EngineerAbsence();
      DataTable dataTable2 = this._database.ExecuteSP_DataTable(nameof (EngineerAbsence_Get), new SqlParameter("@EngineerAbsenceID", (object) EngineerAbsenceID));
      if (dataTable2 == null || dataTable2.Rows.Count <= 0)
        return (FSM.Entity.EngineerAbsence.EngineerAbsence) null;
      FSM.Entity.EngineerAbsence.EngineerAbsence engineerAbsence2 = engineerAbsence1;
      engineerAbsence2.SetEngineerAbsenceID = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0][nameof (EngineerAbsenceID)]);
      engineerAbsence2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["EngineerID"]);
      engineerAbsence2.SetAbsenceTypeID = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["AbsenceTypeID"]);
      engineerAbsence2.DateFrom = Conversions.ToDate(dataTable2.Rows[0]["DateFrom"]);
      engineerAbsence2.DateTo = Conversions.ToDate(dataTable2.Rows[0]["DateTo"]);
      engineerAbsence2.SetComments = RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["Comments"]);
      engineerAbsence1.Exists = true;
      return engineerAbsence1;
    }

    public DataTable EngineerAbsence_GetAll()
    {
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (EngineerAbsence_GetAll), true);
      dataTable.TableName = "tblEngineerAbsence";
      return dataTable;
    }

    public FSM.Entity.EngineerAbsence.EngineerAbsence Insert(
      FSM.Entity.EngineerAbsence.EngineerAbsence oEngineerAbsence)
    {
      this.AddEngineerAbsenceParameters(ref oEngineerAbsence);
      oEngineerAbsence.Exists = true;
      oEngineerAbsence.SetEngineerAbsenceID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerAbsence_Insert", true)));
      return oEngineerAbsence;
    }

    public void Update(FSM.Entity.EngineerAbsence.EngineerAbsence oEngineerAbsence)
    {
      this._database.ClearParameter();
      this.AddEngineerAbsenceParameters(ref oEngineerAbsence);
      this._database.AddParameter("@EngineerAbsenceID", (object) oEngineerAbsence.EngineerAbsenceID, true);
      this._database.ExecuteSP_NO_Return("EngineerAbsence_Update", true);
    }

    private void AddEngineerAbsenceParameters(ref FSM.Entity.EngineerAbsence.EngineerAbsence oEngineerAbsence)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) oEngineerAbsence.EngineerID, false);
      this._database.AddParameter("@AbsenceTypeID", (object) oEngineerAbsence.AbsenceTypeID, false);
      this._database.AddParameter("@DateFrom", (object) Strings.Format((object) oEngineerAbsence.DateFrom, "yyyy-MM-dd HH:mm"), false);
      this._database.AddParameter("@DateTo", (object) Strings.Format((object) oEngineerAbsence.DateTo, "yyyy-MM-dd HH:mm"), false);
      this._database.AddParameter("@Comments", (object) oEngineerAbsence.Comments, false);
    }

    public DataTable EngineerAbsenceTypes_GetAll()
    {
      DataTable dataTable1 = new DataTable();
      this._database.ClearParameter();
      DataTable dataTable2 = this._database.ExecuteSP_DataTable(nameof (EngineerAbsenceTypes_GetAll), true);
      dataTable2.TableName = "tblEngineerAbsenceTypes";
      return dataTable2;
    }

    public DataTable AbsenceSearch(string sql)
    {
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = this._database.ExecuteWithReturn(sql, true);
      dataTable2.TableName = "tblEngineerAbsence";
      return dataTable2;
    }

    public DataTable GetAbsencesForEngineer(int engineerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerID, false);
      return this._database.ExecuteSP_DataTable("Engineer_Absences_Get", true);
    }
  }
}
