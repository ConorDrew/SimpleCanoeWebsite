using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Areas
    {
        public class AreaSQL
        {
            private Sys.Database _database;

            public AreaSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int AreaID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AreaID", AreaID, true);
                _database.ExecuteSP_NO_Return("Area_Delete");
            }

            public Area Area_Get(int AreaID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AreaID", AreaID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Area_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oArea = new Area();
                        oArea.IgnoreExceptionsOnSetMethods = true;
                        oArea.SetAreaID = dt.Rows[0]["AreaID"];
                        oArea.SetDescription = dt.Rows[0]["Description"];
                        oArea.SetSectionID = dt.Rows[0]["SectionID"];
                        oArea.SetOrderNumber = dt.Rows[0]["OrderNumber"];
                        oArea.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oArea.Exists = true;
                        return oArea;
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

            public DataView Area_Get_For_Section(int SectionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SectionID", SectionID, true);
                var dt = _database.ExecuteSP_DataTable("Area_Get_For_Section");
                dt.TableName = Sys.Enums.TableNames.tblArea.ToString();
                return new DataView(dt);
            }

            public DataView Area_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Area_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblArea.ToString();
                return new DataView(dt);
            }

            public Area Insert(Area oArea)
            {
                _database.ClearParameter();
                if (oArea.OrderNumber == 0)
                {
                    oArea.SetOrderNumber = Area_getNextOrderNumber(oArea.SectionID);
                }

                _database.ClearParameter();
                AddAreaParametersToCommand(ref oArea);
                oArea.SetAreaID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Area_Insert"));
                oArea.Exists = true;
                return oArea;
            }

            public void Area_AdjustOrderNumber(int AreaID, int OldOrderNumber, int NewOrderNumber, int SectionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@AreaID", AreaID, true);
                _database.AddParameter("@oldOrderNumber", OldOrderNumber, true);
                _database.AddParameter("@NewOrderNumber", NewOrderNumber, true);
                _database.AddParameter("@SectionID", SectionID, true);
                _database.ExecuteSP_NO_Return("Area_AdjustOrderNumber");
            }

            public void Update(Area oArea)
            {
                _database.ClearParameter();
                _database.AddParameter("@AreaID", oArea.AreaID, true);
                AddAreaParametersToCommand(ref oArea);
                _database.ExecuteSP_NO_Return("Area_Update");
            }

            private void AddAreaParametersToCommand(ref Area oArea)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@Description", oArea.Description, true);
                    withBlock.AddParameter("@SectionID", oArea.SectionID, true);
                    withBlock.AddParameter("@OrderNumber", oArea.OrderNumber, true);
                }
            }

            private int Area_getNextOrderNumber(int SectionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SectionID", SectionID, true);
                int nextID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Area_getNextOrderNumber"));
                if (nextID == 0)
                {
                    return 1;
                }
                else
                {
                    return nextID + 1;
                }
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}