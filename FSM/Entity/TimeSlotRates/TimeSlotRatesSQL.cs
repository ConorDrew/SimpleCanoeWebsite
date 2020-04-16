// Decompiled with JetBrains decompiler
// Type: FSM.Entity.TimeSlotRates.TimeSlotRatesSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FSM.Entity.TimeSlotRates
{
    public class TimeSlotRatesSQL
    {
        private Database _database;

        public TimeSlotRatesSQL(Database database)
        {
            this._database = database;
        }

        public DataView GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("TimeSlotRates_GetAll", true);
            table.TableName = Enums.TableNames.tblTimeslotRates.ToString();
            return new DataView(table);
        }

        public void Update(
          int UniqueID,
          int Monday,
          int Tuesday,
          int Wednesday,
          int Thursday,
          int Friday,
          int Saturday,
          int Sunday)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@UniqueID", (object)UniqueID, false);
            this._database.AddParameter("@Monday", (object)Monday, false);
            this._database.AddParameter("@Tuesday", (object)Tuesday, false);
            this._database.AddParameter("@Wednesday", (object)Wednesday, false);
            this._database.AddParameter("@Thursday", (object)Thursday, false);
            this._database.AddParameter("@Friday", (object)Friday, false);
            this._database.AddParameter("@Saturday", (object)Saturday, false);
            this._database.AddParameter("@Sunday", (object)Sunday, false);
            App.DB.ExecuteSP_NO_Return("TimeSlotRates_Update", true);
        }

        public DataView BankHolidays_GetAllAsync()
        {
            DataTable table = new DataTable();
            SqlCommand Command = new SqlCommand("BankHolidays_GetAll", new SqlConnection(this._database.ServerConnectionString));
            DataView dataView;
            try
            {
                Command.CommandType = CommandType.StoredProcedure;
                table = this._database.ExecuteCommand_DataTable(Command);
                table.TableName = Enums.TableNames.tblBankHolidays.ToString();
                dataView = new DataView(table);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                dataView = new DataView(table);
                ProjectData.ClearProjectError();
            }
            finally
            {
                Command.Connection.Close();
            }
            return dataView;
        }

        public DataView BankHolidays_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(BankHolidays_GetAll), true);
            table.TableName = Enums.TableNames.tblBankHolidays.ToString();
            return new DataView(table);
        }

        public object BankHolidays_Insert(DateTime BankHolidayDate, int LabourRateID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@BankHolidayDate", (object)BankHolidayDate, true);
            this._database.AddParameter("@LabourRateID", (object)LabourRateID, true);
            App.DB.ExecuteSP_NO_Return(nameof(BankHolidays_Insert), true);
            object obj = null;
            return obj;
        }

        public object BankHolidays_Update(
          DateTime BankHolidayDate,
          int LabourRateID,
          int BankHolidayID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@BankHolidayDate", (object)BankHolidayDate, true);
            this._database.AddParameter("@LabourRateID", (object)LabourRateID, true);
            this._database.AddParameter("@BankHolidayID", (object)BankHolidayID, true);
            App.DB.ExecuteSP_NO_Return(nameof(BankHolidays_Update), true);
            object obj = null;
            return obj;
        }

        public DataView LabourTypes_Get()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable("LabourTypes_GetAll", true);
            table.TableName = Enums.TableNames.tblTimeslotRates.ToString();
            return new DataView(table);
        }
    }
}