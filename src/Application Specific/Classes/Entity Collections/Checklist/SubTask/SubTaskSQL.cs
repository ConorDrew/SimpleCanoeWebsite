using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace SubTasks
    {
        public class SubTaskSQL
        {
            private Sys.Database _database;

            public SubTaskSQL(Sys.Database database)
            {
                _database = database;
            }

            

            public void Delete(int SubTaskID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SubTaskID", SubTaskID, true);
                _database.ExecuteSP_NO_Return("SubTask_Delete");
            }

            public SubTask SubTask_Get(int SubTaskID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SubTaskID", SubTaskID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("SubTask_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSubTask = new SubTask();
                        oSubTask.IgnoreExceptionsOnSetMethods = true;
                        oSubTask.SetSubTaskID = dt.Rows[0]["SubTaskID"];
                        oSubTask.SetTaskID = dt.Rows[0]["TaskID"];
                        oSubTask.SetDescription = dt.Rows[0]["Description"];
                        oSubTask.SetOrderNumber = dt.Rows[0]["OrderNumber"];
                        oSubTask.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oSubTask.Exists = true;
                        return oSubTask;
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

            public DataView SubTask_Get_For_Task(int TaskID)
            {
                _database.ClearParameter();
                _database.AddParameter("@TaskID", TaskID, true);
                var dt = _database.ExecuteSP_DataTable("SubTask_Get_For_Task");
                dt.TableName = Sys.Enums.TableNames.tblSubTask.ToString();
                return new DataView(dt);
            }

            public DataView SubTask_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("SubTask_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblSubTask.ToString();
                return new DataView(dt);
            }

            public SubTask Insert(SubTask oSubTask)
            {
                _database.ClearParameter();
                if (oSubTask.OrderNumber == 0)
                {
                    oSubTask.SetOrderNumber = SubTask_getNextOrderNumber(oSubTask.TaskID);
                }

                _database.ClearParameter();
                AddSubTaskParametersToCommand(ref oSubTask);
                oSubTask.SetSubTaskID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SubTask_Insert"));
                oSubTask.Exists = true;
                return oSubTask;
            }

            public void SubTask_AdjustOrderNumber(int SubTaskID, int OldOrderNumber, int NewOrderNumber, int TaskID)
            {
                _database.ClearParameter();
                _database.AddParameter("@TaskID", TaskID, true);
                _database.AddParameter("@oldOrderNumber", OldOrderNumber, true);
                _database.AddParameter("@NewOrderNumber", NewOrderNumber, true);
                _database.AddParameter("@SubTaskID", SubTaskID, true);
                _database.ExecuteSP_NO_Return("SubTask_AdjustOrderNumber");
            }

            public void Update(SubTask oSubTask)
            {
                _database.ClearParameter();
                _database.AddParameter("@SubTaskID", oSubTask.SubTaskID, true);
                AddSubTaskParametersToCommand(ref oSubTask);
                _database.ExecuteSP_NO_Return("SubTask_Update");
            }

            private void AddSubTaskParametersToCommand(ref SubTask oSubTask)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@TaskID", oSubTask.TaskID, true);
                    withBlock.AddParameter("@Description", oSubTask.Description, true);
                    withBlock.AddParameter("@OrderNumber", oSubTask.OrderNumber, true);
                }
            }

            private int SubTask_getNextOrderNumber(int TaskID)
            {
                _database.ClearParameter();
                _database.AddParameter("@TaskID", TaskID, true);
                int nextID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SubTask_getNextOrderNumber"));
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