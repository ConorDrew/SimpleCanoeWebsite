using System.Data;
using FSM.Entity.Sys;

namespace FSM.Entity
{
    namespace EngineerTimeSheets
    {
        public class EngineerTimeSheetSQL
        {
            private Database _database;

            public EngineerTimeSheetSQL(Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int EngineerTimeSheetID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerTimeSheetID", EngineerTimeSheetID, true);
                _database.ExecuteSP_NO_Return("EngineerTimeSheet_Delete");
            }

            public EngineerTimeSheet Insert(EngineerTimeSheet oEngineerTimeSheet)
            {
                _database.ClearParameter();
                AddEngineerVisitTimeSheetParametersToCommand(ref oEngineerTimeSheet);
                oEngineerTimeSheet.SetEngineerTimeSheetID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerTimeSheet_Insert"));
                oEngineerTimeSheet.Exists = true;
                return oEngineerTimeSheet;
            }

            public void Update(EngineerTimeSheet oEngineerTimeSheet)
            {
                _database.ClearParameter();
                AddEngineerVisitTimeSheetParametersToCommand(ref oEngineerTimeSheet);
                _database.AddParameter("@EngineerTimeSheetID", oEngineerTimeSheet.EngineerTimeSheetID, true);
                _database.ExecuteSP_NO_Return("EngineerTimeSheet_Update");
            }

            private void AddEngineerVisitTimeSheetParametersToCommand(ref EngineerTimeSheet oEngineerTimeSheet)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@EngineerID", oEngineerTimeSheet.EngineerID, true);
                    withBlock.AddParameter("@StartDateTime", oEngineerTimeSheet.StartDateTime, true);
                    withBlock.AddParameter("@EndDateTime", oEngineerTimeSheet.EndDateTime, true);
                    withBlock.AddParameter("@Comments", oEngineerTimeSheet.Comments, true);
                    withBlock.AddParameter("@TimesheetTypeID", oEngineerTimeSheet.TimeSheetTypeID, true);
                }
            }

            public DataView GetAll(string Where, string Where2)
            {
                _database.ClearParameter();
                _database.AddParameter("@Where", Where, true);
                _database.AddParameter("@Where2", Where2, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitTimeSheet_GetAll_RD");
                dt.TableName = Enums.TableNames.tblEngineerTimesheet.ToString();
                return new DataView(dt);
            }

            public void UpdateVisit(EngineerTimeSheet oEngineerTimeSheet)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerTimesheetID", oEngineerTimeSheet.EngineerTimeSheetID, true);
                _database.AddParameter("@StartDateTime", oEngineerTimeSheet.StartDateTime, true);
                _database.AddParameter("@EndDateTime", oEngineerTimeSheet.EndDateTime, true);
                _database.AddParameter("@Comments", oEngineerTimeSheet.Comments, true);
                _database.ExecuteSP_NO_Return("EngineerTimeSheet_UpdateVisit");
            }

            public EngineerTimeSheet Get(int EngineerTimeSheetID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerTimeSheetID", EngineerTimeSheetID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerTimeSheet_Get_RD");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerTimeSheet = new EngineerTimeSheet();
                        oEngineerTimeSheet.IgnoreExceptionsOnSetMethods = true;
                        oEngineerTimeSheet.SetEngineerTimeSheetID = dt.Rows[0]["EngineerTimeSheetID"];
                        oEngineerTimeSheet.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oEngineerTimeSheet.StartDateTime = Helper.MakeDateTimeValid(dt.Rows[0]["StartDateTime"]);
                        oEngineerTimeSheet.EndDateTime = Helper.MakeDateTimeValid(dt.Rows[0]["EndDateTime"]);
                        oEngineerTimeSheet.SetComments = dt.Rows[0]["Comments"];
                        oEngineerTimeSheet.SetTimeSheetTypeID = dt.Rows[0]["TimeSheetTypeID"];
                        oEngineerTimeSheet.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerTimeSheet.Exists = true;
                        return oEngineerTimeSheet;
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}