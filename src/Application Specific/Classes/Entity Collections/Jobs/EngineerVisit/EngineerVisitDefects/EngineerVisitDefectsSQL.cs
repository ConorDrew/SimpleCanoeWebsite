using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitDefectss
    {
        public class EngineerVisitDefectsSQL
        {
            private Sys.Database _database;

            public EngineerVisitDefectsSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int EngineerVisitDefectID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitDefectID", EngineerVisitDefectID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitDefects_Delete");
            }

            public EngineerVisitDefects EngineerVisitDefects_Get(int EngineerVisitDefectID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitDefectID", EngineerVisitDefectID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitDefects_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitDefects = new EngineerVisitDefects();
                        oEngineerVisitDefects.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitDefects.SetEngineerVisitDefectID = dt.Rows[0]["EngineerVisitDefectID"];
                        oEngineerVisitDefects.SetCategoryID = dt.Rows[0]["CategoryID"];
                        oEngineerVisitDefects.SetReason = dt.Rows[0]["Reason"];
                        oEngineerVisitDefects.SetActionTaken = dt.Rows[0]["ActionTaken"];
                        oEngineerVisitDefects.SetWarningNoticeIssued = dt.Rows[0]["WarningNoticeIssued"];
                        oEngineerVisitDefects.SetDisconnected = dt.Rows[0]["Disconnected"];
                        oEngineerVisitDefects.SetComments = dt.Rows[0]["Comments"];
                        oEngineerVisitDefects.SetAssetID = dt.Rows[0]["AssetID"];
                        oEngineerVisitDefects.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitDefects.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oEngineerVisitDefects.Exists = true;
                        return oEngineerVisitDefects;
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

            public DataView EngineerVisitDefects_GetForEngineerVisit(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitDefects_GetForEngineerVisit");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitDefects.ToString();
                return new DataView(dt);
            }

            public EngineerVisitDefects Insert(EngineerVisitDefects oEngineerVisitDefects)
            {
                _database.ClearParameter();
                AddEngineerVisitDefectsParametersToCommand(ref oEngineerVisitDefects);
                oEngineerVisitDefects.SetEngineerVisitDefectID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitDefects_Insert"));
                oEngineerVisitDefects.Exists = true;
                return oEngineerVisitDefects;
            }

            public void Update(EngineerVisitDefects oEngineerVisitDefects)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitDefectID", oEngineerVisitDefects.EngineerVisitDefectID, true);
                AddEngineerVisitDefectsParametersToCommand(ref oEngineerVisitDefects);
                _database.ExecuteSP_NO_Return("EngineerVisitDefects_Update");
            }

            private void AddEngineerVisitDefectsParametersToCommand(ref EngineerVisitDefects oEngineerVisitDefects)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@CategoryID", oEngineerVisitDefects.CategoryID, true);
                    withBlock.AddParameter("@Reason", oEngineerVisitDefects.Reason, true);
                    withBlock.AddParameter("@ActionTaken", oEngineerVisitDefects.ActionTaken, true);
                    withBlock.AddParameter("@WarningNoticeIssued", oEngineerVisitDefects.WarningNoticeIssued, true);
                    withBlock.AddParameter("@Disconnected", oEngineerVisitDefects.Disconnected, true);
                    withBlock.AddParameter("@Comments", oEngineerVisitDefects.Comments, true);
                    withBlock.AddParameter("@AssetID", oEngineerVisitDefects.AssetID, true);
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitDefects.EngineerVisitID, true);
                }
            }
        }
    }
}