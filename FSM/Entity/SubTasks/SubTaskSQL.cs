// Decompiled with JetBrains decompiler
// Type: FSM.Entity.SubTasks.SubTaskSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.SubTasks
{
    public class SubTaskSQL
    {
        private Database _database;

        public SubTaskSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int SubTaskID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SubTaskID", (object)SubTaskID, true);
            this._database.ExecuteSP_NO_Return("SubTask_Delete", true);
        }

        public SubTask SubTask_Get(int SubTaskID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SubTaskID", (object)SubTaskID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(SubTask_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (SubTask)null;
            SubTask subTask1 = new SubTask();
            SubTask subTask2 = subTask1;
            subTask2.IgnoreExceptionsOnSetMethods = true;
            subTask2.SetSubTaskID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(SubTaskID)]);
            subTask2.SetTaskID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TaskID"]);
            subTask2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
            subTask2.SetOrderNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderNumber"]);
            subTask2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            subTask1.Exists = true;
            return subTask1;
        }

        public DataView SubTask_Get_For_Task(int TaskID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@TaskID", (object)TaskID, true);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SubTask_Get_For_Task), true);
            table.TableName = Enums.TableNames.tblSubTask.ToString();
            return new DataView(table);
        }

        public DataView SubTask_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(SubTask_GetAll), true);
            table.TableName = Enums.TableNames.tblSubTask.ToString();
            return new DataView(table);
        }

        public SubTask Insert(SubTask oSubTask)
        {
            this._database.ClearParameter();
            if (oSubTask.OrderNumber == 0)
                oSubTask.SetOrderNumber = (object)this.SubTask_getNextOrderNumber(oSubTask.TaskID);
            this._database.ClearParameter();
            this.AddSubTaskParametersToCommand(ref oSubTask);
            oSubTask.SetSubTaskID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("SubTask_Insert", true)));
            oSubTask.Exists = true;
            return oSubTask;
        }

        public void SubTask_AdjustOrderNumber(
          int SubTaskID,
          int OldOrderNumber,
          int NewOrderNumber,
          int TaskID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@TaskID", (object)TaskID, true);
            this._database.AddParameter("@oldOrderNumber", (object)OldOrderNumber, true);
            this._database.AddParameter("@NewOrderNumber", (object)NewOrderNumber, true);
            this._database.AddParameter("@SubTaskID", (object)SubTaskID, true);
            this._database.ExecuteSP_NO_Return(nameof(SubTask_AdjustOrderNumber), true);
        }

        public void Update(SubTask oSubTask)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SubTaskID", (object)oSubTask.SubTaskID, true);
            this.AddSubTaskParametersToCommand(ref oSubTask);
            this._database.ExecuteSP_NO_Return("SubTask_Update", true);
        }

        private void AddSubTaskParametersToCommand(ref SubTask oSubTask)
        {
            Database database = this._database;
            database.AddParameter("@TaskID", (object)oSubTask.TaskID, true);
            database.AddParameter("@Description", (object)oSubTask.Description, true);
            database.AddParameter("@OrderNumber", (object)oSubTask.OrderNumber, true);
        }

        private int SubTask_getNextOrderNumber(int TaskID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@TaskID", (object)TaskID, true);
            int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof(SubTask_getNextOrderNumber), true)));
            return num == 0 ? 1 : checked(num + 1);
        }
    }
}