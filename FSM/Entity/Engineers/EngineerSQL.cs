// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Engineers.EngineerSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Engineers
{
  public class EngineerSQL
  {
    private Database _database;

    public EngineerSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int EngineerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) EngineerID, true);
      this._database.ExecuteSP_NO_Return("Engineer_Delete", true);
    }

    public void DeleteEquipment(int EngineerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EquipmentID", (object) EngineerID, true);
      this._database.ExecuteSP_NO_Return("Equipment_Delete", true);
    }

    public Engineer Engineer_Get(int EngineerID)
    {
      SqlCommand Command = new SqlCommand(nameof (Engineer_Get), new SqlConnection(this._database.ServerConnectionString));
      Command.CommandType = CommandType.StoredProcedure;
      Command.Parameters.AddWithValue("@EngineerID", (object) EngineerID);
      DataTable dataTable = this._database.ExecuteCommand_DataTable(Command);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Engineer) null;
      Engineer engineer1 = new Engineer();
      Engineer engineer2 = engineer1;
      engineer2.IgnoreExceptionsOnSetMethods = true;
      engineer2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (EngineerID)]);
      engineer2.SetRegionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RegionID"]);
      engineer2.SetEngineerGroupID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerGroupID"]);
      engineer2.SetGasSafeNo = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GasSafeNo"]);
      engineer2.SetOftecNo = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OftecNo"]);
      engineer2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
      engineer2.SetTelephoneNum = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TelephoneNum"]);
      engineer2.SetPDAID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PDAID"]);
      engineer2.SetApprentice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Apprentice"]);
      engineer2.SetCostToCompanyNormal = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CostToCompanyNormal"]);
      engineer2.SetCostToCompanyTimeAndHalf = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CostToCompanyTimeAndHalf"]);
      engineer2.SetCostToCompanyDouble = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CostToCompanyDouble"]);
      engineer2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      engineer2.SetTechnician = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Technician"]);
      engineer2.SetSupervisor = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Supervisor"]);
      engineer2.SetNextOfKinName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NextOfKinName"]);
      engineer2.SetNextOfKinContact = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NextOfKinContact"]);
      engineer2.SetStartingDetails = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartingDetails"]);
      engineer2.SetDrivingLicenceNo = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrivingLicenceNo"]);
      if (dataTable.Rows[0]["DrivingLicenceIssueDate"] != DBNull.Value)
        engineer2.DrivingLicenceIssueDate = Conversions.ToDate(dataTable.Rows[0]["DrivingLicenceIssueDate"]);
      engineer2.SetPayGradeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PayGradeID"]);
      engineer2.SetAnnualSalary = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AnnualSalary"]);
      engineer2.SetNINumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NINumber"]);
      engineer2.SetHolidayYearStart = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HolidayYearStart"]);
      engineer2.SetHolidayYearEnd = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HolidayYearEnd"]);
      engineer2.SetDaysHolidayAllowed = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DaysHolidayAllowed"]);
      engineer2.SetDepartment = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Department"]);
      engineer2.SetBreakPri = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BreakPri"]);
      engineer2.SetServPri = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ServPri"]);
      engineer2.SetDailyServiceLimit = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DailyServiceLimit"]);
      engineer2.SetHomePostcode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["HomePostcode"]);
      engineer2.SetLongitude = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Longitude"]);
      engineer2.SetLatitude = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Latitude"]);
      engineer2.SetManagerUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ManagerUserID"]);
      engineer2.SetRagRating = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RagRating"]);
      engineer2.RagDate = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["RagDate"]));
      engineer2.SetUserID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["UserID"]);
      engineer2.SetVisitSpendLimit = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VisitSpendLimit"]));
      engineer2.SetEngineerRoleId = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerRoleId"]);
      engineer2.SetEmailAddress = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EmailAddress"]);
      engineer1.Exists = true;
      return engineer1;
    }

    public DataView Engineer_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Engineer_GetAll), true);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public DataView Engineer_GetAll_IncludeDeleted()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("Engineer_GetAll_IncludingDeleted", true);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public DataView Engineer_GetAll_NoSub()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Engineer_GetAll_NoSub), true);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public void EquipmentAudit_Insert(int equipmentID, string actionChange)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EquipmentID", (object) equipmentID, true);
      this._database.AddParameter("@ActionChange", (object) actionChange, true);
      this._database.AddParameter("@ActionDateTime", (object) DateTime.Now, true);
      this._database.AddParameter("@UserID", (object) App.loggedInUser.UserID, true);
      this._database.ExecuteSP_NO_Return(nameof (EquipmentAudit_Insert), true);
    }

    public DataView EquipmentAudit_Get(int equipmentID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EquipmentID", (object) equipmentID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EquipmentAudit_Get), true);
      table.TableName = Enums.TableNames.tblEquipmentAudit.ToString();
      return new DataView(table);
    }

    public Equipment Equipment_Get(int EquipmentID)
    {
      SqlCommand Command = new SqlCommand(nameof (Equipment_Get), new SqlConnection(this._database.ServerConnectionString));
      Command.CommandType = CommandType.StoredProcedure;
      Command.Parameters.AddWithValue("@EquipmentID", (object) EquipmentID);
      DataTable dataTable = this._database.ExecuteCommand_DataTable(Command);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Equipment) null;
      Equipment equipment1 = new Equipment();
      Equipment equipment2 = equipment1;
      equipment2.IgnoreExceptionsOnSetMethods = true;
      equipment2.SetEquipmentID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (EquipmentID)]);
      equipment2.SetEquipmentTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EquipmentTypeID"]);
      equipment2.SetSerialNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SerialNumber"]);
      equipment2.SetName = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Name"]);
      equipment2.SetCertificateNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CertificateNumber"]);
      equipment2.CalibrationDate = Conversions.ToDate(dataTable.Rows[0]["CalibrationDate"]);
      equipment2.SetCalibrationMonths = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CalibrationMonths"]);
      equipment2.WarrantyEndDate = Conversions.ToDate(dataTable.Rows[0]["WarrantyEndDate"]);
      equipment2.SetNotes = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Notes"]);
      equipment2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]);
      equipment2.SetStatusID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StatusID"]);
      equipment2.SetAssetNo = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AssetNo"]);
      equipment2.StatusChangeDate = Conversions.ToDate(dataTable.Rows[0]["StatusChangeDate"]);
      equipment1.Exists = true;
      return equipment1;
    }

    public DataView Equipment_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Equipment_GetAll), true);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public DataView Equipment_GetForEngineer(int EngineerID)
    {
      SqlCommand Command = new SqlCommand(nameof (Equipment_GetForEngineer), new SqlConnection(this._database.ServerConnectionString));
      Command.CommandType = CommandType.StoredProcedure;
      Command.Parameters.AddWithValue("@EngineerID", (object) EngineerID);
      DataTable table = this._database.ExecuteCommand_DataTable(Command);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public DataView Engineer_GetAll_Scheduler()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Engineer_GetAll_Scheduler), true);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public DataView Equipment_Search(string criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Equipment_Search), true);
      table.TableName = Enums.TableNames.tblSubcontractor.ToString();
      return new DataView(table);
    }

    public DataView User_And_Engineer_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable("User_Engineer_GetAll", true);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public DataView Engineer_GetAllbyDept(string Dept = "0")
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Department", (object) Dept, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Engineer_GetAllbyDept), true);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public bool Check_Unique_Name(string Name, int ID)
    {
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(EngineerID) as 'NumberOfEngineers' FROM tblEngineer WHERE name = '" + Name + "' AND (Deleted = 0) AND engineerid <> " + Conversions.ToString(ID), false, false))) == 0;
    }

    public bool UserIsLinkedToEngineer(int UserID)
    {
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(EngineerID) as 'Num' FROM tblEngineer WHERE UserID = " + Conversions.ToString(UserID), false, false))) != 0;
    }

    public bool Check_Unique_PDAID(int PDAID, int ID)
    {
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteScalar("SELECT COUNT(EngineerID) as 'NumberOfEngineers' FROM tblEngineer WHERE PDAID = " + Conversions.ToString(PDAID) + " AND PDAID IS NOT NULL AND engineerid <> " + Conversions.ToString(ID), false, false))) == 0;
    }

    public DataView Engineer_Search(string Criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SearchString", (object) Criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable("Engineer_SearchList", true);
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public Engineer Insert(Engineer oEngineer)
    {
      this._database.ClearParameter();
      this.AddEngineerParametersToCommand(ref oEngineer);
      oEngineer.SetEngineerID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Engineer_Insert", true)));
      oEngineer.Exists = true;
      return oEngineer;
    }

    public void Update(Engineer oEngineer)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) oEngineer.EngineerID, true);
      this.AddEngineerParametersToCommand(ref oEngineer);
      this._database.ExecuteSP_NO_Return("Engineer_Update", true);
    }

    public Equipment EquipmentInsert(Equipment oEquipment)
    {
      this._database.ClearParameter();
      this.AddEquipmentParametersToCommand(ref oEquipment);
      oEquipment.SetEquipmentID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Equipment_Insert", true)));
      oEquipment.Exists = true;
      return oEquipment;
    }

    public void EquipmentUpdate(Equipment oEquipment)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EquipmentID", (object) oEquipment.EquipmentID, true);
      this.AddEquipmentParametersToCommand(ref oEquipment);
      this._database.ExecuteSP_NO_Return("Equipment_Update", true);
    }

    private void AddEquipmentParametersToCommand(ref Equipment oEquipment)
    {
      Database database = this._database;
      database.AddParameter("@Name", (object) oEquipment.Name, true);
      database.AddParameter("@EquipmentTypeID", (object) oEquipment.EquipmentTypeID, true);
      database.AddParameter("@SerialNumber", (object) oEquipment.SerialNumber, true);
      database.AddParameter("@CertificateNumber", (object) oEquipment.CertificateNumber, true);
      database.AddParameter("@StatusID", (object) oEquipment.StatusID, true);
      database.AddParameter("@AssetNo", (object) oEquipment.AssetNo, true);
      database.AddParameter("@CalibrationDate", (object) Helper.MakeDateTimeValid((object) oEquipment.CalibrationDate), true);
      database.AddParameter("@CalibrationMonths", (object) oEquipment.CalibrationMonths, true);
      database.AddParameter("@WarrantyEndDate", (object) Helper.MakeDateTimeValid((object) oEquipment.WarrantyEndDate), true);
      database.AddParameter("@EngineerID", (object) oEquipment.EngineerID, true);
      database.AddParameter("@Notes", (object) oEquipment.Notes, true);
      database.AddParameter("@StatusChangeDate", (object) oEquipment.StatusChangeDate, true);
    }

    private void AddEngineerParametersToCommand(ref Engineer oEngineer)
    {
      Database database = this._database;
      database.AddParameter("@RegionID", (object) oEngineer.RegionID, true);
      database.AddParameter("@Name", (object) oEngineer.Name, true);
      database.AddParameter("@EngineerGroupID", (object) oEngineer.EngineerGroupID, true);
      database.AddParameter("@GasSafeNo", (object) oEngineer.GasSafeNo, true);
      database.AddParameter("@OftecNo", (object) oEngineer.OftecNo, true);
      database.AddParameter("@TelephoneNum", (object) oEngineer.TelephoneNum, true);
      if (oEngineer.PDAID == 0)
        database.AddParameter("@PDAID", (object) DBNull.Value, true);
      else
        database.AddParameter("@PDAID", (object) oEngineer.PDAID, true);
      database.AddParameter("@Apprentice", (object) oEngineer.Apprentice, true);
      database.AddParameter("@CostToCompanyNormal", (object) oEngineer.CostToCompanyNormal, true);
      database.AddParameter("@CostToCompanyTimeAndHalf", (object) oEngineer.CostToCompanyTimeAndHalf, true);
      database.AddParameter("@CostToCompanyDouble", (object) oEngineer.CostToCompanyDouble, true);
      database.AddParameter("@NextOfKinName", (object) oEngineer.NextOfKinName, true);
      database.AddParameter("@NextOfKinContact", (object) oEngineer.NextOfKinContact, true);
      database.AddParameter("@StartingDetails", (object) oEngineer.StartingDetails, true);
      database.AddParameter("@DrivingLicenceNo", (object) oEngineer.DrivingLicenceNo, true);
      if (DateTime.Compare(oEngineer.DrivingLicenceIssueDate, DateTime.MinValue) == 0)
        database.AddParameter("@DrivingLicenceIssueDate", (object) DBNull.Value, true);
      else
        database.AddParameter("@DrivingLicenceIssueDate", (object) oEngineer.DrivingLicenceIssueDate, true);
      database.AddParameter("@PayGradeID", (object) oEngineer.PayGradeID, true);
      database.AddParameter("@AnnualSalary", (object) oEngineer.AnnualSalary, true);
      database.AddParameter("@NINumber", (object) oEngineer.NINumber, true);
      database.AddParameter("@HolidayYearStart", (object) oEngineer.HolidayYearStart, true);
      database.AddParameter("@HolidayYearEnd", (object) oEngineer.HolidayYearEnd, true);
      database.AddParameter("@DaysHolidayAllowed", (object) oEngineer.DaysHolidayAllowed, true);
      database.AddParameter("@Technician", (object) oEngineer.Technician, true);
      database.AddParameter("@Supervisor", (object) oEngineer.Supervisor, true);
      database.AddParameter("@Department", (object) oEngineer.Department, true);
      database.AddParameter("@ServPri", (object) oEngineer.ServPri, true);
      database.AddParameter("@BreakPri", (object) oEngineer.BreakPri, true);
      database.AddParameter("@DailyServiceLimit", (object) oEngineer.DailyServiceLimit, true);
      database.AddParameter("@HomePostcode", (object) oEngineer.HomePostcode, true);
      database.AddParameter("@Longitude", (object) oEngineer.Longitude, true);
      database.AddParameter("@Latitude", (object) oEngineer.Latitude, true);
      database.AddParameter("@ManagerUserID", (object) oEngineer.ManagerUserID, true);
      database.AddParameter("@WebAppPassword", (object) oEngineer.WebAppPassword, true);
      database.AddParameter("@RagRating", (object) oEngineer.RagRating, true);
      SqlBoolean sqlBoolean;
      if (((sqlBoolean = (SqlBoolean) ((uint) DateTime.Compare(oEngineer.RagDate, DateTime.MinValue) > 0U)) ? false : true) ? sqlBoolean : sqlBoolean & (SqlDateTime) oEngineer.RagDate > SqlDateTime.MinValue)
        database.AddParameter("@RagDate", (object) oEngineer.RagDate, true);
      if (oEngineer.UserID == 0)
        database.AddParameter("@UserID", (object) DBNull.Value, true);
      else
        database.AddParameter("@UserID", (object) oEngineer.UserID, true);
      object objectValue = RuntimeHelpers.GetObjectValue(Decimal.Compare(oEngineer.VisitSpendLimit, Decimal.Zero) > 0 ? (object) oEngineer.VisitSpendLimit : (object) DBNull.Value);
      database.AddParameter("@VisitSpendLimit", RuntimeHelpers.GetObjectValue(objectValue), true);
      database.AddParameter("@EngineerRoleId", (object) oEngineer.EngineerRoleId, true);
      database.AddParameter("@EmailAddress", (object) oEngineer.EmailAddress, true);
    }

    public DataView Performance_Report(
      int EngineerID,
      ArrayList Months,
      DateTime StartDate,
      DateTime EndDate)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) EngineerID, true);
      this._database.AddParameter("@Start", (object) Conversions.ToDate(Strings.Format((object) StartDate, "dd-MMM-yyyy") + " 00:00:00"), true);
      this._database.AddParameter("@End", (object) Conversions.ToDate(Strings.Format((object) EndDate, "dd-MMM-yyyy") + " 23:59:59"), true);
      string str1 = "";
      IEnumerator enumerator;
      try
      {
        enumerator = Months.GetEnumerator();
        while (enumerator.MoveNext())
        {
          string str2 = Conversions.ToString(enumerator.Current);
          str1 = str1 + str2 + ";";
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this._database.AddParameter("@Months", (object) str1, true);
      DataTable table = this._database.ExecuteSP_DataTable("Engineer_Performance_Report", true);
      table.Columns.Remove(nameof (EngineerID));
      table.TableName = Enums.TableNames.tblEngineer.ToString();
      return new DataView(table);
    }

    public DataView EngineerSkills_Get(int engineerId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerId, true);
      DataTable table = this._database.ExecuteSP_DataTable("EngineerJobSkill_Get_ForEngineerID", true);
      table.TableName = Enums.TableNames.tblEngineerSkills.ToString();
      return new DataView(table);
    }

    public void EngineerSkills_Insert(int engineerID, int jobTypeID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerID, true);
      this._database.AddParameter("@JobTypeID", (object) jobTypeID, true);
      this._database.ExecuteSP_OBJECT("EngineerJobSkill_Insert", true);
    }

    public void EngineerSkills_Delete(int engineerID)
    {
      this._database.ClearParameter();
      App.DB.ExecuteScalar("DELETE FROM tblEngineerJobSkill Where EngineerID = " + Conversions.ToString(engineerID), true, false);
    }

    public void SaveDisciplinaryRecords(int engineerID, DataTable t)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerID, true);
      this._database.ExecuteSP_NO_Return("Engineer_Disciplinary_Delete_All", true);
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
          this._database.AddParameter("@EngineerID", (object) engineerID, true);
          this._database.AddParameter("@Disciplinary", (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Disciplinary"])), true);
          this._database.AddParameter("@DateIssued", RuntimeHelpers.GetObjectValue(current["DateIssued"]), true);
          this._database.AddParameter("@DisciplinaryStatusID", RuntimeHelpers.GetObjectValue(current["DisciplinaryStatusID"]), true);
          this._database.ExecuteSP_NO_Return("Engineer_Disciplinary_Insert", true);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public DataTable GetDisciplinaryRecords(int engineerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerID, true);
      return this._database.ExecuteSP_DataTable("Engineer_Disciplinary_Get", true);
    }

    public void SaveEquipmentRecords(int engineerID, DataTable t)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerID, true);
      this._database.ExecuteSP_NO_Return("Engineer_Equipment_Delete_All", true);
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
          this._database.AddParameter("@EngineerID", (object) engineerID, true);
          this._database.AddParameter("@Equipment", (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Equipment"])), true);
          this._database.ExecuteSP_NO_Return("Engineer_Equipment_Insert", true);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public DataTable GetEquipmentRecords(int engineerID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerID", (object) engineerID, true);
      return this._database.ExecuteSP_DataTable("Engineer_Equipment_Get", true);
    }
  }
}
