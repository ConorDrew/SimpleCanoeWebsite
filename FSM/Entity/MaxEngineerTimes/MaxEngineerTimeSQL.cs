// Decompiled with JetBrains decompiler
// Type: FSM.Entity.MaxEngineerTimes.MaxEngineerTimeSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.MaxEngineerTimes
{
    public class MaxEngineerTimeSQL
    {
        private Database _database;

        public MaxEngineerTimeSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int MaxEngineerTimeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@MaxEngineerTimeID", (object)MaxEngineerTimeID, true);
            this._database.ExecuteSP_NO_Return("MaxEngineerTime_Delete", true);
        }

        public MaxEngineerTime MaxEngineerTime_Get(int MaxEngineerTimeID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@MaxEngineerTimeID", (object)MaxEngineerTimeID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(MaxEngineerTime_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (MaxEngineerTime)null;
            MaxEngineerTime maxEngineerTime1 = new MaxEngineerTime();
            MaxEngineerTime maxEngineerTime2 = maxEngineerTime1;
            maxEngineerTime2.IgnoreExceptionsOnSetMethods = true;
            maxEngineerTime2.SetMaxEngineerTimeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(MaxEngineerTimeID)]);
            maxEngineerTime2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]);
            maxEngineerTime2.SetMondayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MondayValue"]);
            maxEngineerTime2.SetTuesdayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TuesdayValue"]);
            maxEngineerTime2.SetWednesdayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WednesdayValue"]);
            maxEngineerTime2.SetThursdayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ThursdayValue"]);
            maxEngineerTime2.SetFridayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FridayValue"]);
            maxEngineerTime2.SetSaturdayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SaturdayValue"]);
            maxEngineerTime2.SetSundayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SundayValue"]);
            maxEngineerTime2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            maxEngineerTime1.Exists = true;
            return maxEngineerTime1;
        }

        public DataView MaxEngineerTime_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(MaxEngineerTime_GetAll), true);
            table.TableName = Enums.TableNames.tblMaxEngineerTime.ToString();
            return new DataView(table);
        }

        public MaxEngineerTime MaxEngineerTime_GetForEngineer(int EngineerID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object)EngineerID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(MaxEngineerTime_GetForEngineer), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (MaxEngineerTime)null;
            MaxEngineerTime maxEngineerTime1 = new MaxEngineerTime();
            MaxEngineerTime maxEngineerTime2 = maxEngineerTime1;
            maxEngineerTime2.IgnoreExceptionsOnSetMethods = true;
            maxEngineerTime2.SetMaxEngineerTimeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MaxEngineerTimeID"]);
            maxEngineerTime2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(EngineerID)]);
            maxEngineerTime2.SetMondayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["MondayValue"]);
            maxEngineerTime2.SetTuesdayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TuesdayValue"]);
            maxEngineerTime2.SetWednesdayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WednesdayValue"]);
            maxEngineerTime2.SetThursdayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ThursdayValue"]);
            maxEngineerTime2.SetFridayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FridayValue"]);
            maxEngineerTime2.SetSaturdayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SaturdayValue"]);
            maxEngineerTime2.SetSundayValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SundayValue"]);
            maxEngineerTime2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            maxEngineerTime1.Exists = true;
            return maxEngineerTime1;
        }

        public MaxEngineerTime Insert(MaxEngineerTime oMaxEngineerTime)
        {
            this._database.ClearParameter();
            this.AddMaxEngineerTimeParametersToCommand(ref oMaxEngineerTime);
            oMaxEngineerTime.SetMaxEngineerTimeID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("MaxEngineerTime_Insert", true)));
            oMaxEngineerTime.Exists = true;
            return oMaxEngineerTime;
        }

        public void Update(MaxEngineerTime oMaxEngineerTime)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@MaxEngineerTimeID", (object)oMaxEngineerTime.MaxEngineerTimeID, true);
            this.AddMaxEngineerTimeParametersToCommand(ref oMaxEngineerTime);
            this._database.ExecuteSP_NO_Return("MaxEngineerTime_Update", true);
        }

        private void AddMaxEngineerTimeParametersToCommand(ref MaxEngineerTime oMaxEngineerTime)
        {
            Database database = this._database;
            database.AddParameter("@EngineerID", (object)oMaxEngineerTime.EngineerID, true);
            database.AddParameter("@MondayValue", (object)oMaxEngineerTime.MondayValue, true);
            database.AddParameter("@TuesdayValue", (object)oMaxEngineerTime.TuesdayValue, true);
            database.AddParameter("@WednesdayValue", (object)oMaxEngineerTime.WednesdayValue, true);
            database.AddParameter("@ThursdayValue", (object)oMaxEngineerTime.ThursdayValue, true);
            database.AddParameter("@FridayValue", (object)oMaxEngineerTime.FridayValue, true);
            database.AddParameter("@SaturdayValue", (object)oMaxEngineerTime.SaturdayValue, true);
            database.AddParameter("@SundayValue", (object)oMaxEngineerTime.SundayValue, true);
        }
    }
}