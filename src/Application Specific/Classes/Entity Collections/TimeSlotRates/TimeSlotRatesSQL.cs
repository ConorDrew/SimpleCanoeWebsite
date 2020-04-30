using System;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity
{
    namespace TimeSlotRates
    {
        public class TimeSlotRatesSQL
        {
            private Sys.Database _database;

            public TimeSlotRatesSQL(Sys.Database database)
            {
                _database = database;
            }

            
            public DataView GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("TimeSlotRates_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblTimeslotRates.ToString();
                return new DataView(dt);
            }

            public void Update(int UniqueID, int Monday, int Tuesday, int Wednesday, int Thursday, int Friday, int Saturday, int Sunday)
            {
                _database.ClearParameter();
                _database.AddParameter("@UniqueID", UniqueID);
                _database.AddParameter("@Monday", Monday);
                _database.AddParameter("@Tuesday", Tuesday);
                _database.AddParameter("@Wednesday", Wednesday);
                _database.AddParameter("@Thursday", Thursday);
                _database.AddParameter("@Friday", Friday);
                _database.AddParameter("@Saturday", Saturday);
                _database.AddParameter("@Sunday", Sunday);
                App.DB.ExecuteSP_NO_Return("TimeSlotRates_Update");
            }

            public DataView BankHolidays_GetAllAsync()
            {
                var dt = new DataTable();
                var command = new SqlCommand("BankHolidays_GetAll", new SqlConnection(_database.ServerConnectionString));
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    dt = _database.ExecuteCommand_DataTable(command);
                    dt.TableName = Sys.Enums.TableNames.tblBankHolidays.ToString();
                    return new DataView(dt);
                }
                catch (Exception ex)
                {
                    return new DataView(dt);
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            public DataView BankHolidays_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("BankHolidays_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblBankHolidays.ToString();
                return new DataView(dt);
            }

            public object BankHolidays_Insert(DateTime BankHolidayDate, int LabourRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@BankHolidayDate", BankHolidayDate, true);
                _database.AddParameter("@LabourRateID", LabourRateID, true);
                App.DB.ExecuteSP_NO_Return("BankHolidays_Insert");
                return default;
            }

            public object BankHolidays_Update(DateTime BankHolidayDate, int LabourRateID, int BankHolidayID)
            {
                _database.ClearParameter();
                _database.AddParameter("@BankHolidayDate", BankHolidayDate, true);
                _database.AddParameter("@LabourRateID", LabourRateID, true);
                _database.AddParameter("@BankHolidayID", BankHolidayID, true);
                App.DB.ExecuteSP_NO_Return("BankHolidays_Update");
                return default;
            }

            public DataView LabourTypes_Get()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("LabourTypes_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblTimeslotRates.ToString();
                return new DataView(dt);
            }

            
        }
    }
}