// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Tasks.TaskSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Tasks
{
  public class TaskSQL
  {
    private Database _database;

    public TaskSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int TaskID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@TaskID", (object) TaskID, true);
      this._database.ExecuteSP_NO_Return("Task_Delete", true);
    }

    public Task Task_Get(int TaskID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@TaskID", (object) TaskID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Task_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Task) null;
      Task task1 = new Task();
      Task task2 = task1;
      task2.IgnoreExceptionsOnSetMethods = true;
      task2.SetTaskID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (TaskID)]);
      task2.SetAreaID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AreaID"]);
      task2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
      task2.SetOrderNumber = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["OrderNumber"]);
      task2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      task1.Exists = true;
      return task1;
    }

    public DataView Task_Get_For_Area(object AreaID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@AreaID", RuntimeHelpers.GetObjectValue(AreaID), true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Task_Get_For_Area), true);
      table.TableName = Enums.TableNames.tblTask.ToString();
      return new DataView(table);
    }

    public DataView Task_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Task_GetAll), true);
      table.TableName = Enums.TableNames.tblTask.ToString();
      return new DataView(table);
    }

    public Task Insert(Task oTask)
    {
      this._database.ClearParameter();
      if (oTask.OrderNumber == 0)
        oTask.SetOrderNumber = (object) this.Task_getNextOrderNumber(oTask.AreaID);
      this._database.ClearParameter();
      this.AddTaskParametersToCommand(ref oTask);
      oTask.SetTaskID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Task_Insert", true)));
      oTask.Exists = true;
      return oTask;
    }

    public void Task_AdjustOrderNumber(
      int TaskID,
      int OldOrderNumber,
      int NewOrderNumber,
      int AreaID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@AreaID", (object) AreaID, true);
      this._database.AddParameter("@oldOrderNumber", (object) OldOrderNumber, true);
      this._database.AddParameter("@NewOrderNumber", (object) NewOrderNumber, true);
      this._database.AddParameter("@TaskID", (object) TaskID, true);
      this._database.ExecuteSP_NO_Return(nameof (Task_AdjustOrderNumber), true);
    }

    public void Update(Task oTask)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@TaskID", (object) oTask.TaskID, true);
      this.AddTaskParametersToCommand(ref oTask);
      this._database.ExecuteSP_NO_Return("Task_Update", true);
    }

    private void AddTaskParametersToCommand(ref Task oTask)
    {
      Database database = this._database;
      database.AddParameter("@AreaID", (object) oTask.AreaID, true);
      database.AddParameter("@Description", (object) oTask.Description, true);
      database.AddParameter("@OrderNumber", (object) oTask.OrderNumber, true);
    }

    private int Task_getNextOrderNumber(int AreaID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@AreaID", (object) AreaID, true);
      int num = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof (Task_getNextOrderNumber), true)));
      return num == 0 ? 1 : checked (num + 1);
    }
  }
}
