﻿using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Tasks
    {
        public class TaskSQL
        {
            private Sys.Database _database;

            public TaskSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int TaskID)
            {
                _database.ClearParameter();
                _database.AddParameter("@TaskID", TaskID, true);
                _database.ExecuteSP_NO_Return("Task_Delete");
            }

            public DataView Task_Get_For_Area(object AreaID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AreaID", AreaID, true);
                var dt = _database.ExecuteSP_DataTable("Task_Get_For_Area");
                dt.TableName = Sys.Enums.TableNames.tblTask.ToString();
                return new DataView(dt);
            }

            public Task Insert(Task oTask)
            {
                _database.ClearParameter();
                if (oTask.OrderNumber == 0)
                {
                    oTask.SetOrderNumber = Task_getNextOrderNumber(oTask.AreaID);
                }

                _database.ClearParameter();
                AddTaskParametersToCommand(ref oTask);
                oTask.SetTaskID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Task_Insert"));
                oTask.Exists = true;
                return oTask;
            }

            public void Task_AdjustOrderNumber(int TaskID, int OldOrderNumber, int NewOrderNumber, int AreaID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AreaID", AreaID, true);
                _database.AddParameter("@oldOrderNumber", OldOrderNumber, true);
                _database.AddParameter("@NewOrderNumber", NewOrderNumber, true);
                _database.AddParameter("@TaskID", TaskID, true);
                _database.ExecuteSP_NO_Return("Task_AdjustOrderNumber");
            }

            public void Update(Task oTask)
            {
                _database.ClearParameter();
                _database.AddParameter("@TaskID", oTask.TaskID, true);
                AddTaskParametersToCommand(ref oTask);
                _database.ExecuteSP_NO_Return("Task_Update");
            }

            private void AddTaskParametersToCommand(ref Task oTask)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@AreaID", oTask.AreaID, true);
                    withBlock.AddParameter("@Description", oTask.Description, true);
                    withBlock.AddParameter("@OrderNumber", oTask.OrderNumber, true);
                }
            }

            private int Task_getNextOrderNumber(int AreaID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AreaID", AreaID, true);
                int nextID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Task_getNextOrderNumber"));
                if (nextID == 0)
                {
                    return 1;
                }
                else
                {
                    return nextID + 1;
                }
            }
        }
    }
}