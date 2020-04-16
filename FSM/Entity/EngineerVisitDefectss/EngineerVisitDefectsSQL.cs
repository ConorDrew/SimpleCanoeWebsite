// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitDefectss.EngineerVisitDefectsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitDefectss
{
    public class EngineerVisitDefectsSQL
    {
        private Database _database;

        public EngineerVisitDefectsSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int EngineerVisitDefectID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitDefectID", (object)EngineerVisitDefectID, true);
            this._database.ExecuteSP_NO_Return("EngineerVisitDefects_Delete", true);
        }

        public EngineerVisitDefects EngineerVisitDefects_Get(
          int EngineerVisitDefectID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitDefectID", (object)EngineerVisitDefectID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(EngineerVisitDefects_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (EngineerVisitDefects)null;
            EngineerVisitDefects engineerVisitDefects1 = new EngineerVisitDefects();
            EngineerVisitDefects engineerVisitDefects2 = engineerVisitDefects1;
            engineerVisitDefects2.IgnoreExceptionsOnSetMethods = true;
            engineerVisitDefects2.SetEngineerVisitDefectID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(EngineerVisitDefectID)]);
            engineerVisitDefects2.SetCategoryID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CategoryID"]);
            engineerVisitDefects2.SetReason = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Reason"]);
            engineerVisitDefects2.SetActionTaken = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ActionTaken"]);
            engineerVisitDefects2.SetWarningNoticeIssued = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WarningNoticeIssued"]);
            engineerVisitDefects2.SetDisconnected = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Disconnected"]);
            engineerVisitDefects2.SetComments = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Comments"]);
            engineerVisitDefects2.SetAssetID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AssetID"]);
            engineerVisitDefects2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitID"]);
            engineerVisitDefects2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            engineerVisitDefects1.Exists = true;
            return engineerVisitDefects1;
        }

        public DataView EngineerVisitDefects_GetForEngineerVisit(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitDefects_GetForEngineerVisit), true);
            table.TableName = Enums.TableNames.tblEngineerVisitDefects.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisitDefects_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitDefects_GetAll), true);
            table.TableName = Enums.TableNames.tblEngineerVisitDefects.ToString();
            return new DataView(table);
        }

        public EngineerVisitDefects Insert(
          EngineerVisitDefects oEngineerVisitDefects)
        {
            this._database.ClearParameter();
            this.AddEngineerVisitDefectsParametersToCommand(ref oEngineerVisitDefects);
            oEngineerVisitDefects.SetEngineerVisitDefectID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitDefects_Insert", true)));
            oEngineerVisitDefects.Exists = true;
            return oEngineerVisitDefects;
        }

        public void Update(EngineerVisitDefects oEngineerVisitDefects)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitDefectID", (object)oEngineerVisitDefects.EngineerVisitDefectID, true);
            this.AddEngineerVisitDefectsParametersToCommand(ref oEngineerVisitDefects);
            this._database.ExecuteSP_NO_Return("EngineerVisitDefects_Update", true);
        }

        private void AddEngineerVisitDefectsParametersToCommand(
          ref EngineerVisitDefects oEngineerVisitDefects)
        {
            Database database = this._database;
            database.AddParameter("@CategoryID", (object)oEngineerVisitDefects.CategoryID, true);
            database.AddParameter("@Reason", (object)oEngineerVisitDefects.Reason, true);
            database.AddParameter("@ActionTaken", (object)oEngineerVisitDefects.ActionTaken, true);
            database.AddParameter("@WarningNoticeIssued", (object)oEngineerVisitDefects.WarningNoticeIssued, true);
            database.AddParameter("@Disconnected", (object)oEngineerVisitDefects.Disconnected, true);
            database.AddParameter("@Comments", (object)oEngineerVisitDefects.Comments, true);
            database.AddParameter("@AssetID", (object)oEngineerVisitDefects.AssetID, true);
            database.AddParameter("@EngineerVisitID", (object)oEngineerVisitDefects.EngineerVisitID, true);
        }
    }
}