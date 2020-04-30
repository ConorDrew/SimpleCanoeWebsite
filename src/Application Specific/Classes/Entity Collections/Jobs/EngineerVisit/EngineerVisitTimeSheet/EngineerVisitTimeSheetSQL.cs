using System.Data;

namespace FSM.Entity
{
    namespace EngineerVisitTimeSheets
    {
        public class EngineerVisitTimeSheetSQL
        {
            private Sys.Database _database;

            public EngineerVisitTimeSheetSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public void Delete(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheet_Delete");
            }

            public DataView EngineerVisitTimeSheet_Get_For_EngineerVisitID(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitTimeSheet_Get_For_EngineerVisitID");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString();
                return new DataView(dt);
            }

            public EngineerVisitTimeSheet Insert(EngineerVisitTimeSheet oEngineerVisitTimeSheet)
            {
                _database.ClearParameter();
                AddEngineerVisitTimeSheetParametersToCommand(ref oEngineerVisitTimeSheet);
                oEngineerVisitTimeSheet.SetEngineerVisitTimeSheetID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitTimeSheet_Insert"));
                oEngineerVisitTimeSheet.Exists = true;
                return oEngineerVisitTimeSheet;
            }

            private void AddEngineerVisitTimeSheetParametersToCommand(ref EngineerVisitTimeSheet oEngineerVisitTimeSheet)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitTimeSheet.EngineerVisitID, true);
                    withBlock.AddParameter("@StartDateTime", oEngineerVisitTimeSheet.StartDateTime, true);
                    withBlock.AddParameter("@EndDateTime", oEngineerVisitTimeSheet.EndDateTime, true);
                    withBlock.AddParameter("@Comments", oEngineerVisitTimeSheet.Comments, true);
                    withBlock.AddParameter("@TimesheetTypeID", oEngineerVisitTimeSheet.TimeSheetTypeID, true);
                }
            }

            public DataView GetAll(string Where)
            {
                _database.ClearParameter();
                _database.AddParameter("@WHERE", Where, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitTimeSheet_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString();
                return new DataView(dt);
            }

            public DataView Get_CurrentCost_ByJobID(int jobId)
            {
                _database.ClearParameter();
                _database.AddParameter("@JobID", jobId, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitTimesheet_Get_CurrentCost_ByJobID");
                return new DataView(dt);
            }

            
        }
    }
}