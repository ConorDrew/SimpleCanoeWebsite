using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace CheckLists
    {
        public class CheckListSQL
        {
            private Sys.Database _database;

            public CheckListSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public DataView GetAll_For_Engineer_Visit(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("CheckLists_GetAll_For_Engineer_Visit");
                dt.TableName = Sys.Enums.TableNames.tblChecklists.ToString();
                return new DataView(dt);
            }

            public DataView Get_Questions_And_Answers_For_Section(int SectionID, int CheckListID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SectionID", SectionID, true);
                _database.AddParameter("@DateAdded", DateAndTime.Now, true);
                var dt = _database.ExecuteSP_DataTable("Checklists_Get_Questions_For_Section");
                dt.TableName = Sys.Enums.TableNames.tblCheckListAnswers.ToString();
                if (!(CheckListID == 0))
                {
                    dt.AcceptChanges();
                    var answers = Get_Answers(CheckListID).Table;
                    foreach (DataRow question in dt.Rows)
                    {
                        DataRow dr;
                        if (!(Sys.Helper.MakeIntegerValid(question["SubTaskID"]) == 0))
                        {
                            if (answers.Select(Conversions.ToString("EnumTableID = " + Conversions.ToInteger(Sys.Enums.TableNames.tblSubTask) + " AND QuestionID = " + question["SubTaskID"])).Length > 0)
                            {
                                dr = answers.Select(Conversions.ToString("EnumTableID = " + Conversions.ToInteger(Sys.Enums.TableNames.tblSubTask) + " AND QuestionID = " + question["SubTaskID"]))[0];
                                question["Result"] = dr["ResultID"];
                                question["Comments"] = dr["Comments"];
                            }
                        }
                        else if (!(Sys.Helper.MakeIntegerValid(question["TaskID"]) == 0))
                        {
                            if (answers.Select(Conversions.ToString("EnumTableID = " + Conversions.ToInteger(Sys.Enums.TableNames.tblTask) + " AND QuestionID = " + question["TaskID"])).Length > 0)
                            {
                                dr = answers.Select(Conversions.ToString("EnumTableID = " + Conversions.ToInteger(Sys.Enums.TableNames.tblTask) + " AND QuestionID = " + question["TaskID"]))[0];
                                question["Result"] = dr["ResultID"];
                                question["Comments"] = dr["Comments"];
                            }
                        }
                        else if (!(Sys.Helper.MakeIntegerValid(question["AreaID"]) == 0))
                        {
                            if (answers.Select(Conversions.ToString("EnumTableID = " + Conversions.ToInteger(Sys.Enums.TableNames.tblArea) + " AND QuestionID = " + question["AreaID"])).Length > 0)
                            {
                                dr = answers.Select(Conversions.ToString("EnumTableID = " + Conversions.ToInteger(Sys.Enums.TableNames.tblArea) + " AND QuestionID = " + question["AreaID"]))[0];
                                question["Result"] = dr["ResultID"];
                                question["Comments"] = dr["Comments"];
                            }
                        }
                        else if (answers.Select(Conversions.ToString("EnumTableID = " + Conversions.ToInteger(Sys.Enums.TableNames.tblSection) + " AND QuestionID = " + question["SectionID"])).Length > 0)
                        {
                            dr = answers.Select(Conversions.ToString("EnumTableID = " + Conversions.ToInteger(Sys.Enums.TableNames.tblSection) + " AND QuestionID = " + question["SectionID"]))[0];
                            question["Result"] = dr["ResultID"];
                            question["Comments"] = dr["Comments"];
                        }
                    }
                }

                return new DataView(dt);
            }

            private DataView Get_Answers(int CheckListID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CheckListID", CheckListID, true);
                var dt = _database.ExecuteSP_DataTable("Checklists_Get_Answers");
                dt.TableName = Sys.Enums.TableNames.tblCheckListAnswers.ToString();
                return new DataView(dt);
            }

            public CheckList Get(int CheckListID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CheckListID", CheckListID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("CheckLists_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oCheckList = new CheckList();
                        oCheckList.IgnoreExceptionsOnSetMethods = true;
                        oCheckList.SetCheckListID = dt.Rows[0]["CheckListID"];
                        oCheckList.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oCheckList.SetSectionID = dt.Rows[0]["SectionID"];
                        oCheckList.AddedOn = Sys.Helper.MakeDateTimeValid(dt.Rows[0]["AddedOn"]);
                        oCheckList.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oCheckList.Exists = true;
                        return oCheckList;
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

            public void Delete(int CheckListID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CheckListID", CheckListID, true);
                _database.ExecuteSP_NO_Return("CheckLists_Delete");
            }

            public CheckList Insert(CheckList oCheckList)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", oCheckList.EngineerVisitID, true);
                _database.AddParameter("@SectionID", oCheckList.SectionID, true);
                oCheckList.SetCheckListID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CheckLists_Insert"));
                oCheckList.Exists = true;
                return oCheckList;
            }

            public void DeleteAnswers(int CheckListID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CheckListID", CheckListID, true);
                _database.ExecuteSP_NO_Return("CheckLists_Delete_Answers");
            }

            public void InsertAnswer(CheckListAnswer oCheckListAnswer)
            {
                _database.ClearParameter();
                _database.AddParameter("@CheckListID", oCheckListAnswer.CheckListID, true);
                _database.AddParameter("@EnumTableID", oCheckListAnswer.EnumTableID, true);
                _database.AddParameter("@QuestionID", oCheckListAnswer.QuestionID, true);
                _database.AddParameter("@ResultID", oCheckListAnswer.ResultID, true);
                _database.AddParameter("@Comments", oCheckListAnswer.Comments, true);
                _database.ExecuteSP_NO_Return("CheckLists_Insert_Answer");
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}