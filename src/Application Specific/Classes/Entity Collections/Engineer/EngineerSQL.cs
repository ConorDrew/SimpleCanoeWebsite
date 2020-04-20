using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Engineers
    {
        public class EngineerSQL
        {
            private Database _database;

            public EngineerSQL(Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int EngineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.ExecuteSP_NO_Return("Engineer_Delete");
            }

            public void DeleteEquipment(int EngineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EquipmentID", EngineerID, true);
                _database.ExecuteSP_NO_Return("Equipment_Delete");
            }

            public Engineer Engineer_Get(int EngineerID)
            {
                var command = new SqlCommand("Engineer_Get", new SqlConnection(_database.ServerConnectionString));
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EngineerID", EngineerID);
                var dt = _database.ExecuteCommand_DataTable(command);
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineer = new Engineer();
                        oEngineer.IgnoreExceptionsOnSetMethods = true;
                        oEngineer.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oEngineer.SetRegionID = dt.Rows[0]["RegionID"];
                        oEngineer.SetEngineerGroupID = dt.Rows[0]["EngineerGroupID"];
                        oEngineer.SetGasSafeNo = dt.Rows[0]["GasSafeNo"];
                        oEngineer.SetOftecNo = dt.Rows[0]["OftecNo"];
                        oEngineer.SetName = dt.Rows[0]["Name"];
                        oEngineer.SetTelephoneNum = dt.Rows[0]["TelephoneNum"];
                        oEngineer.SetPDAID = dt.Rows[0]["PDAID"];
                        oEngineer.SetApprentice = dt.Rows[0]["Apprentice"];
                        oEngineer.SetCostToCompanyNormal = dt.Rows[0]["CostToCompanyNormal"];
                        oEngineer.SetCostToCompanyTimeAndHalf = dt.Rows[0]["CostToCompanyTimeAndHalf"];
                        oEngineer.SetCostToCompanyDouble = dt.Rows[0]["CostToCompanyDouble"];
                        oEngineer.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oEngineer.SetTechnician = dt.Rows[0]["Technician"];
                        oEngineer.SetSupervisor = dt.Rows[0]["Supervisor"];
                        oEngineer.SetNextOfKinName = dt.Rows[0]["NextOfKinName"];
                        oEngineer.SetNextOfKinContact = dt.Rows[0]["NextOfKinContact"];
                        oEngineer.SetStartingDetails = dt.Rows[0]["StartingDetails"];
                        oEngineer.SetDrivingLicenceNo = dt.Rows[0]["DrivingLicenceNo"];
                        if (!(dt.Rows[0]["DrivingLicenceIssueDate"] == DBNull.Value))
                        {
                            oEngineer.DrivingLicenceIssueDate = Conversions.ToDate(dt.Rows[0]["DrivingLicenceIssueDate"]);
                        }

                        oEngineer.SetPayGradeID = dt.Rows[0]["PayGradeID"];
                        oEngineer.SetAnnualSalary = dt.Rows[0]["AnnualSalary"];
                        oEngineer.SetNINumber = dt.Rows[0]["NINumber"];
                        oEngineer.SetHolidayYearStart = dt.Rows[0]["HolidayYearStart"];
                        oEngineer.SetHolidayYearEnd = dt.Rows[0]["HolidayYearEnd"];
                        oEngineer.SetDaysHolidayAllowed = dt.Rows[0]["DaysHolidayAllowed"];
                        oEngineer.SetDepartment = dt.Rows[0]["Department"];
                        oEngineer.SetBreakPri = dt.Rows[0]["BreakPri"];
                        oEngineer.SetServPri = dt.Rows[0]["ServPri"];
                        oEngineer.SetDailyServiceLimit = dt.Rows[0]["DailyServiceLimit"];
                        oEngineer.SetHomePostcode = dt.Rows[0]["HomePostcode"];
                        oEngineer.SetLongitude = dt.Rows[0]["Longitude"];
                        oEngineer.SetLatitude = dt.Rows[0]["Latitude"];
                        oEngineer.SetManagerUserID = dt.Rows[0]["ManagerUserID"];
                        oEngineer.SetRagRating = dt.Rows[0]["RagRating"];
                        oEngineer.RagDate = Helper.MakeDateTimeValid(dt.Rows[0]["RagDate"]);
                        oEngineer.SetUserID = dt.Rows[0]["UserID"];
                        oEngineer.SetVisitSpendLimit = Helper.MakeDoubleValid(dt.Rows[0]["VisitSpendLimit"]);
                        oEngineer.SetEngineerRoleId = dt.Rows[0]["EngineerRoleId"];
                        oEngineer.SetEmailAddress = dt.Rows[0]["EmailAddress"];
                        oEngineer.Exists = true;
                        return oEngineer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView Engineer_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Engineer_GetAll");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public DataView Engineer_GetAll_IncludeDeleted()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Engineer_GetAll_IncludingDeleted");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public DataView Engineer_GetAll_NoSub()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Engineer_GetAll_NoSub");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public void EquipmentAudit_Insert(int equipmentID, string actionChange)
            {
                _database.ClearParameter();
                _database.AddParameter("@EquipmentID", equipmentID, true);
                _database.AddParameter("@ActionChange", actionChange, true);
                _database.AddParameter("@ActionDateTime", DateTime.Now, true);
                _database.AddParameter("@UserID", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("EquipmentAudit_Insert");
            }

            public DataView EquipmentAudit_Get(int equipmentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EquipmentID", equipmentID, true);
                var dt = _database.ExecuteSP_DataTable("EquipmentAudit_Get");
                dt.TableName = Enums.TableNames.tblEquipmentAudit.ToString();
                return new DataView(dt);
            }

            public Equipment Equipment_Get(int EquipmentID)
            {
                var command = new SqlCommand("Equipment_Get", new SqlConnection(_database.ServerConnectionString));
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EquipmentID", EquipmentID);
                var dt = _database.ExecuteCommand_DataTable(command);
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEquipment = new Equipment();
                        oEquipment.IgnoreExceptionsOnSetMethods = true;
                        oEquipment.SetEquipmentID = dt.Rows[0]["EquipmentID"];
                        oEquipment.SetEquipmentTypeID = dt.Rows[0]["EquipmentTypeID"];
                        oEquipment.SetSerialNumber = dt.Rows[0]["SerialNumber"];
                        oEquipment.SetName = dt.Rows[0]["Name"];
                        oEquipment.SetCertificateNumber = dt.Rows[0]["CertificateNumber"];
                        oEquipment.CalibrationDate = Conversions.ToDate(dt.Rows[0]["CalibrationDate"]);
                        oEquipment.SetCalibrationMonths = dt.Rows[0]["CalibrationMonths"];
                        oEquipment.WarrantyEndDate = Conversions.ToDate(dt.Rows[0]["WarrantyEndDate"]);
                        oEquipment.SetNotes = dt.Rows[0]["Notes"];
                        oEquipment.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oEquipment.SetStatusID = dt.Rows[0]["StatusID"];
                        oEquipment.SetAssetNo = dt.Rows[0]["AssetNo"];
                        oEquipment.StatusChangeDate = Conversions.ToDate(dt.Rows[0]["StatusChangeDate"]);
                        oEquipment.Exists = true;
                        return oEquipment;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView Equipment_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Equipment_GetAll");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public DataView Equipment_GetForEngineer(int EngineerID)
            {
                var command = new SqlCommand("Equipment_GetForEngineer", new SqlConnection(_database.ServerConnectionString));
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EngineerID", EngineerID);
                var dt = _database.ExecuteCommand_DataTable(command);
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public DataView Engineer_GetAll_Scheduler()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Engineer_GetAll_Scheduler");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public DataView Equipment_Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", criteria, true);
                var dt = _database.ExecuteSP_DataTable("Equipment_Search");
                dt.TableName = Enums.TableNames.tblSubcontractor.ToString();
                return new DataView(dt);
            }

            public DataView User_And_Engineer_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("User_Engineer_GetAll");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public DataView Engineer_GetAllbyDept(string Dept = "0")
            {
                _database.ClearParameter();
                _database.AddParameter("@Department", Dept, true);
                var dt = _database.ExecuteSP_DataTable("Engineer_GetAllbyDept");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public bool Check_Unique_Name(string Name, int ID)
            {
                int NumberOfEngineers = Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(EngineerID) as 'NumberOfEngineers' " + "FROM tblEngineer WHERE name = '" + Name + "' AND (Deleted = 0) AND engineerid <> " + ID, false));
                if (NumberOfEngineers == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool UserIsLinkedToEngineer(int UserID)
            {
                int engineerCount = Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(EngineerID) as 'Num' FROM tblEngineer WHERE UserID = " + UserID, false));
                if (engineerCount == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public bool Check_Unique_PDAID(int PDAID, int ID)
            {
                int NumberOfEngineers = Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(EngineerID) as 'NumberOfEngineers' " + "FROM tblEngineer WHERE PDAID = " + PDAID + " AND PDAID IS NOT NULL AND engineerid <> " + ID, false));
                if (NumberOfEngineers == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public DataView Engineer_Search(string Criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@SearchString", Criteria, true);
                var dt = _database.ExecuteSP_DataTable("Engineer_SearchList");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public Engineer Insert(Engineer oEngineer)
            {
                _database.ClearParameter();
                AddEngineerParametersToCommand(ref oEngineer);
                oEngineer.SetEngineerID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Engineer_Insert"));
                oEngineer.Exists = true;
                return oEngineer;
            }

            public void Update(Engineer oEngineer)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", oEngineer.EngineerID, true);
                AddEngineerParametersToCommand(ref oEngineer);
                _database.ExecuteSP_NO_Return("Engineer_Update");
            }

            public Equipment EquipmentInsert(Equipment oEquipment)
            {
                _database.ClearParameter();
                AddEquipmentParametersToCommand(ref oEquipment);
                oEquipment.SetEquipmentID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Equipment_Insert"));
                oEquipment.Exists = true;
                return oEquipment;
            }

            public void EquipmentUpdate(Equipment oEquipment)
            {
                _database.ClearParameter();
                _database.AddParameter("@EquipmentID", oEquipment.EquipmentID, true);
                AddEquipmentParametersToCommand(ref oEquipment);
                _database.ExecuteSP_NO_Return("Equipment_Update");
            }

            private void AddEquipmentParametersToCommand(ref Equipment oEquipment)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Name", oEquipment.Name, true);
                    withBlock.AddParameter("@EquipmentTypeID", oEquipment.EquipmentTypeID, true);
                    withBlock.AddParameter("@SerialNumber", oEquipment.SerialNumber, true);
                    withBlock.AddParameter("@CertificateNumber", oEquipment.CertificateNumber, true);
                    withBlock.AddParameter("@StatusID", oEquipment.StatusID, true);
                    withBlock.AddParameter("@AssetNo", oEquipment.AssetNo, true);
                    withBlock.AddParameter("@CalibrationDate", Helper.MakeDateTimeValid(oEquipment.CalibrationDate), true);
                    withBlock.AddParameter("@CalibrationMonths", oEquipment.CalibrationMonths, true);
                    withBlock.AddParameter("@WarrantyEndDate", Helper.MakeDateTimeValid(oEquipment.WarrantyEndDate), true);
                    withBlock.AddParameter("@EngineerID", oEquipment.EngineerID, true);
                    withBlock.AddParameter("@Notes", oEquipment.Notes, true);
                    withBlock.AddParameter("@StatusChangeDate", oEquipment.StatusChangeDate, true);
                }
            }

            private void AddEngineerParametersToCommand(ref Engineer oEngineer)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@RegionID", oEngineer.RegionID, true);
                    withBlock.AddParameter("@Name", oEngineer.Name, true);
                    withBlock.AddParameter("@EngineerGroupID", oEngineer.EngineerGroupID, true);
                    withBlock.AddParameter("@GasSafeNo", oEngineer.GasSafeNo, true);
                    withBlock.AddParameter("@OftecNo", oEngineer.OftecNo, true);
                    withBlock.AddParameter("@TelephoneNum", oEngineer.TelephoneNum, true);
                    if (oEngineer.PDAID == 0)
                    {
                        withBlock.AddParameter("@PDAID", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@PDAID", oEngineer.PDAID, true);
                    }

                    withBlock.AddParameter("@Apprentice", oEngineer.Apprentice, true);
                    withBlock.AddParameter("@CostToCompanyNormal", oEngineer.CostToCompanyNormal, true);
                    withBlock.AddParameter("@CostToCompanyTimeAndHalf", oEngineer.CostToCompanyTimeAndHalf, true);
                    withBlock.AddParameter("@CostToCompanyDouble", oEngineer.CostToCompanyDouble, true);
                    withBlock.AddParameter("@NextOfKinName", oEngineer.NextOfKinName, true);
                    withBlock.AddParameter("@NextOfKinContact", oEngineer.NextOfKinContact, true);
                    withBlock.AddParameter("@StartingDetails", oEngineer.StartingDetails, true);
                    withBlock.AddParameter("@DrivingLicenceNo", oEngineer.DrivingLicenceNo, true);
                    if (oEngineer.DrivingLicenceIssueDate == default)
                    {
                        withBlock.AddParameter("@DrivingLicenceIssueDate", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@DrivingLicenceIssueDate", oEngineer.DrivingLicenceIssueDate, true);
                    }

                    withBlock.AddParameter("@PayGradeID", oEngineer.PayGradeID, true);
                    withBlock.AddParameter("@AnnualSalary", oEngineer.AnnualSalary, true);
                    withBlock.AddParameter("@NINumber", oEngineer.NINumber, true);
                    withBlock.AddParameter("@HolidayYearStart", oEngineer.HolidayYearStart, true);
                    withBlock.AddParameter("@HolidayYearEnd", oEngineer.HolidayYearEnd, true);
                    withBlock.AddParameter("@DaysHolidayAllowed", oEngineer.DaysHolidayAllowed, true);
                    withBlock.AddParameter("@Technician", oEngineer.Technician, true);
                    withBlock.AddParameter("@Supervisor", oEngineer.Supervisor, true);
                    withBlock.AddParameter("@Department", oEngineer.Department, true);
                    withBlock.AddParameter("@ServPri", oEngineer.ServPri, true);
                    withBlock.AddParameter("@BreakPri", oEngineer.BreakPri, true);
                    withBlock.AddParameter("@DailyServiceLimit", oEngineer.DailyServiceLimit, true);
                    withBlock.AddParameter("@HomePostcode", oEngineer.HomePostcode, true);
                    withBlock.AddParameter("@Longitude", oEngineer.Longitude, true);
                    withBlock.AddParameter("@Latitude", oEngineer.Latitude, true);
                    withBlock.AddParameter("@ManagerUserID", oEngineer.ManagerUserID, true);
                    withBlock.AddParameter("@WebAppPassword", oEngineer.WebAppPassword, true);
                    withBlock.AddParameter("@RagRating", oEngineer.RagRating, true);
                    if ((bool)(oEngineer.RagDate != default && oEngineer.RagDate > System.Data.SqlTypes.SqlDateTime.MinValue))
                    {
                        withBlock.AddParameter("@RagDate", oEngineer.RagDate, true);
                    }

                    if (oEngineer.UserID == default)
                    {
                        withBlock.AddParameter("@UserID", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@UserID", oEngineer.UserID, true);
                    }

                    var spendLimit = oEngineer.VisitSpendLimit > 0 ? (object)oEngineer.VisitSpendLimit : DBNull.Value;
                    withBlock.AddParameter("@VisitSpendLimit", spendLimit, true);
                    withBlock.AddParameter("@EngineerRoleId", oEngineer.EngineerRoleId, true);
                    withBlock.AddParameter("@EmailAddress", oEngineer.EmailAddress, true);
                }
            }

            public DataView Performance_Report(int EngineerID, ArrayList Months, DateTime StartDate, DateTime EndDate)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", EngineerID, true);
                _database.AddParameter("@Start", Conversions.ToDate(Strings.Format(StartDate, "dd-MMM-yyyy") + " 00:00:00"), true);
                _database.AddParameter("@End", Conversions.ToDate(Strings.Format(EndDate, "dd-MMM-yyyy") + " 23:59:59"), true);
                string monthStr = "";
                foreach (string item in Months)
                    monthStr += item + ";";
                _database.AddParameter("@Months", monthStr, true);
                var dt = _database.ExecuteSP_DataTable("Engineer_Performance_Report");
                dt.Columns.Remove("EngineerID");
                dt.TableName = Enums.TableNames.tblEngineer.ToString();
                return new DataView(dt);
            }

            public DataView EngineerSkills_Get(int engineerId)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", engineerId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerJobSkill_Get_ForEngineerID");
                dt.TableName = Enums.TableNames.tblEngineerSkills.ToString();
                return new DataView(dt);
            }

            public void EngineerSkills_Insert(int engineerID, int jobTypeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", engineerID, true);
                _database.AddParameter("@JobTypeID", jobTypeID, true);
                _database.ExecuteSP_OBJECT("EngineerJobSkill_Insert");
            }

            public void EngineerSkills_Delete(int engineerID)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("DELETE FROM tblEngineerJobSkill Where EngineerID = " + engineerID);
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void SaveDisciplinaryRecords(int engineerID, DataTable t)
            {
                // delete all first
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", engineerID, true);
                _database.ExecuteSP_NO_Return("Engineer_Disciplinary_Delete_All");
                if (t is object)
                {
                    foreach (DataRow r in t.Rows)
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@EngineerID", engineerID, true);
                        _database.AddParameter("@Disciplinary", Helper.MakeStringValid(r["Disciplinary"]), true);
                        _database.AddParameter("@DateIssued", r["DateIssued"], true);
                        _database.AddParameter("@DisciplinaryStatusID", r["DisciplinaryStatusID"], true);
                        _database.ExecuteSP_NO_Return("Engineer_Disciplinary_Insert");
                    }
                }
            }

            public DataTable GetDisciplinaryRecords(int engineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", engineerID, true);
                return _database.ExecuteSP_DataTable("Engineer_Disciplinary_Get");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void SaveEquipmentRecords(int engineerID, DataTable t)
            {

                // delete all first
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", engineerID, true);
                _database.ExecuteSP_NO_Return("Engineer_Equipment_Delete_All");
                if (t is object)
                {
                    foreach (DataRow r in t.Rows)
                    {
                        _database.ClearParameter();
                        _database.AddParameter("@EngineerID", engineerID, true);
                        _database.AddParameter("@Equipment", Helper.MakeStringValid(r["Equipment"]), true);
                        _database.ExecuteSP_NO_Return("Engineer_Equipment_Insert");
                    }
                }
            }

            public DataTable GetEquipmentRecords(int engineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", engineerID, true);
                return _database.ExecuteSP_DataTable("Engineer_Equipment_Get");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}