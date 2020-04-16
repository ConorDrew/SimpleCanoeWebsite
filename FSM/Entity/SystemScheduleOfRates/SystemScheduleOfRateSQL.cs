// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SystemScheduleOfRates.SystemScheduleOfRateSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.SystemScheduleOfRates
{
    public class SystemScheduleOfRateSQL
    {
        private Database _database;

        public SystemScheduleOfRateSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int SystemScheduleOfRateID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SystemScheduleOfRateID", (object)SystemScheduleOfRateID, true);
            this._database.ExecuteSP_NO_Return("SystemScheduleOfRate_Delete", true);
        }

        public SystemScheduleOfRate SystemScheduleOfRate_Get(
          int SystemScheduleOfRateID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SystemScheduleOfRateID", (object)SystemScheduleOfRateID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(SystemScheduleOfRate_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (SystemScheduleOfRate)null;
            SystemScheduleOfRate systemScheduleOfRate1 = new SystemScheduleOfRate();
            SystemScheduleOfRate systemScheduleOfRate2 = systemScheduleOfRate1;
            systemScheduleOfRate2.IgnoreExceptionsOnSetMethods = true;
            systemScheduleOfRate2.SetSystemScheduleOfRateID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(SystemScheduleOfRateID)]);
            systemScheduleOfRate2.SetScheduleOfRatesCategoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ScheduleOfRatesCategoryID"]);
            systemScheduleOfRate2.SetCode = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Code"]);
            systemScheduleOfRate2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
            systemScheduleOfRate2.SetPrice = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Price"]);
            systemScheduleOfRate2.SetTimeInMins = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TimeInMins"]));
            systemScheduleOfRate2.SetJobTypeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["JobTypeID"]));
            systemScheduleOfRate2.SetAllowDeleted = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AllowDeleted"]);
            systemScheduleOfRate2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            systemScheduleOfRate1.Exists = true;
            return systemScheduleOfRate1;
        }

        public DataView SystemScheduleOfRate_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SystemScheduleOfRate_GetAll), true);
            table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
            return new DataView(table);
        }

        public DataView SystemScheduleOfRate_Get_ByJobType(int jobTypeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@JobTypeID", (object)jobTypeID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SystemScheduleOfRate_Get_ByJobType), true);
            table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
            return new DataView(table);
        }

        public DataView SystemScheduleOfRate_Get_ByEngineerQual(int engQualID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngQualID", (object)engQualID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SystemScheduleOfRate_Get_ByEngineerQual), true);
            table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
            return new DataView(table);
        }

        public DataView SystemScheduleOfRate_GetAll_WithoutDefaults()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SystemScheduleOfRate_GetAll_WithoutDefaults), true);
            table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
            return new DataView(table);
        }

        public SystemScheduleOfRate Insert(
          SystemScheduleOfRate oSystemScheduleOfRate)
        {
            this._database.ClearParameter();
            this.AddParametersToCommand(ref oSystemScheduleOfRate);
            oSystemScheduleOfRate.SetSystemScheduleOfRateID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("SystemScheduleOfRate_Insert", true)));
            oSystemScheduleOfRate.Exists = true;
            return oSystemScheduleOfRate;
        }

        public DataView SystemScheduleOfRate_Search(string criteria)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Criteria", (object)criteria, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SystemScheduleOfRate_Search), true);
            table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
            return new DataView(table);
        }

        public void Update(SystemScheduleOfRate oSystemScheduleOfRate)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SystemScheduleOfRateID", (object)oSystemScheduleOfRate.SystemScheduleOfRateID, true);
            this.AddParametersToCommand(ref oSystemScheduleOfRate);
            this._database.ExecuteSP_NO_Return("SystemScheduleOfRate_Update", true);
        }

        private void AddParametersToCommand(ref SystemScheduleOfRate oSystemScheduleOfRate)
        {
            Database database = this._database;
            database.AddParameter("@ScheduleOfRatesCategoryID", (object)oSystemScheduleOfRate.ScheduleOfRatesCategoryID, true);
            database.AddParameter("@Code", (object)oSystemScheduleOfRate.Code, true);
            database.AddParameter("@Description", (object)oSystemScheduleOfRate.Description, true);
            database.AddParameter("@Price", (object)oSystemScheduleOfRate.Price, true);
            database.AddParameter("@TimeInMins", (object)oSystemScheduleOfRate.TimeInMins, true);
            database.AddParameter("@JobTypeID", (object)oSystemScheduleOfRate.JobTypeID, true);
            database.AddParameter("@AllowDeleted", (object)oSystemScheduleOfRate.AllowDeleted, true);
        }

        public DataView SOREnginerQual_Get_ForSOR(int sorId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SORID", (object)sorId, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SOREnginerQual_Get_ForSOR), true);
            table.TableName = Enums.TableNames.tblSystemScheduleOfRate.ToString();
            return new DataView(table);
        }

        public void SOREnginerQual_Insert(int sorId, int engQualId)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SystemScheduleOfRateID", (object)sorId, true);
            this._database.AddParameter("@EngineerQualID", (object)engQualId, true);
            this._database.ExecuteSP_OBJECT(nameof(SOREnginerQual_Insert), true);
        }

        public void SOREnginerQual_Delete(int sorId)
        {
            this._database.ClearParameter();
            App.DB.ExecuteScalar("DELETE FROM [tblSOREnginerQual] Where [SystemScheduleOfRateID] = " + Conversions.ToString(sorId), true, false);
        }
    }
}