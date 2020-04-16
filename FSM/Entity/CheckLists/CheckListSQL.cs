// Decompiled with JetBrains decompiler
// Type: FSM.Entity.CheckLists.CheckListSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.CheckLists
{
    public class CheckListSQL
    {
        private Database _database;

        public CheckListSQL(Database database)
        {
            this._database = database;
        }

        public DataView GetAll_For_Engineer_Visit(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable("CheckLists_GetAll_For_Engineer_Visit", true);
            table.TableName = Enums.TableNames.tblChecklists.ToString();
            return new DataView(table);
        }

        public DataView Get_Questions_And_Answers_For_Section(int SectionID, int CheckListID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@SectionID", (object)SectionID, true);
            this._database.AddParameter("@DateAdded", (object)DateAndTime.Now, true);
            DataTable table1 = this._database.ExecuteSP_DataTable("Checklists_Get_Questions_For_Section", true);
            table1.TableName = Enums.TableNames.tblCheckListAnswers.ToString();
            if ((uint)CheckListID > 0U)
            {
                table1.AcceptChanges();
                DataTable table2 = this.Get_Answers(CheckListID).Table;

                foreach (DataRow dr in table1.Rows)
                {
                    if ((uint)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["SubTaskID"])) > 0U)
                    {
                        if (table2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)("EnumTableID = " + Conversions.ToString(45) + " AND QuestionID = "), dr["SubTaskID"]))).Length > 0)
                        {
                            DataRow dataRow = table2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)("EnumTableID = " + Conversions.ToString(45) + " AND QuestionID = "), dr["SubTaskID"])))[0];
                            dr["Result"] = RuntimeHelpers.GetObjectValue(dataRow["ResultID"]);
                            dr["Comments"] = RuntimeHelpers.GetObjectValue(dataRow["Comments"]);
                        }
                    }
                    else if ((uint)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["TaskID"])) > 0U)
                    {
                        if (table2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)("EnumTableID = " + Conversions.ToString(46) + " AND QuestionID = "), dr["TaskID"]))).Length > 0)
                        {
                            DataRow dataRow = table2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)("EnumTableID = " + Conversions.ToString(46) + " AND QuestionID = "), dr["TaskID"])))[0];
                            dr["Result"] = RuntimeHelpers.GetObjectValue(dataRow["ResultID"]);
                            dr["Comments"] = RuntimeHelpers.GetObjectValue(dataRow["Comments"]);
                        }
                    }
                    else if ((uint)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["AreaID"])) > 0U)
                    {
                        if (table2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)("EnumTableID = " + Conversions.ToString(43) + " AND QuestionID = "), dr["AreaID"]))).Length > 0)
                        {
                            DataRow dataRow = table2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)("EnumTableID = " + Conversions.ToString(43) + " AND QuestionID = "), dr["AreaID"])))[0];
                            dr["Result"] = RuntimeHelpers.GetObjectValue(dataRow["ResultID"]);
                            dr["Comments"] = RuntimeHelpers.GetObjectValue(dataRow["Comments"]);
                        }
                    }
                    else if (table2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)("EnumTableID = " + Conversions.ToString(44) + " AND QuestionID = "), dr[nameof(SectionID)]))).Length > 0)
                    {
                        DataRow dataRow = table2.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object)("EnumTableID = " + Conversions.ToString(44) + " AND QuestionID = "), dr[nameof(SectionID)])))[0];
                        dr["Result"] = RuntimeHelpers.GetObjectValue(dataRow["ResultID"]);
                        dr["Comments"] = RuntimeHelpers.GetObjectValue(dataRow["Comments"]);
                    }
                }
            }
            return new DataView(table1);
        }

        private DataView Get_Answers(int CheckListID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CheckListID", (object)CheckListID, true);
            DataTable table = this._database.ExecuteSP_DataTable("Checklists_Get_Answers", true);
            table.TableName = Enums.TableNames.tblCheckListAnswers.ToString();
            return new DataView(table);
        }

        public CheckList Get(int CheckListID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CheckListID", (object)CheckListID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable("CheckLists_Get", true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (CheckList)null;
            CheckList checkList1 = new CheckList();
            CheckList checkList2 = checkList1;
            checkList2.IgnoreExceptionsOnSetMethods = true;
            checkList2.SetCheckListID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(CheckListID)]);
            checkList2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitID"]);
            checkList2.SetSectionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SectionID"]);
            checkList2.AddedOn = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AddedOn"]));
            checkList2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            checkList1.Exists = true;
            return checkList1;
        }

        public void Delete(int CheckListID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CheckListID", (object)CheckListID, true);
            this._database.ExecuteSP_NO_Return("CheckLists_Delete", true);
        }

        public CheckList Insert(CheckList oCheckList)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)oCheckList.EngineerVisitID, true);
            this._database.AddParameter("@SectionID", (object)oCheckList.SectionID, true);
            oCheckList.SetCheckListID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("CheckLists_Insert", true)));
            oCheckList.Exists = true;
            return oCheckList;
        }

        public void DeleteAnswers(int CheckListID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CheckListID", (object)CheckListID, true);
            this._database.ExecuteSP_NO_Return("CheckLists_Delete_Answers", true);
        }

        public void InsertAnswer(CheckListAnswer oCheckListAnswer)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@CheckListID", (object)oCheckListAnswer.CheckListID, true);
            this._database.AddParameter("@EnumTableID", (object)oCheckListAnswer.EnumTableID, true);
            this._database.AddParameter("@QuestionID", (object)oCheckListAnswer.QuestionID, true);
            this._database.AddParameter("@ResultID", (object)oCheckListAnswer.ResultID, true);
            this._database.AddParameter("@Comments", (object)oCheckListAnswer.Comments, true);
            this._database.ExecuteSP_NO_Return("CheckLists_Insert_Answer", true);
        }
    }
}