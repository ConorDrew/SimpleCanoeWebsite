using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace MaxEngineerTimes
    {
        public class MaxEngineerTimeSQL
        {
            private Sys.Database _database;

            public MaxEngineerTimeSQL(Sys.Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            public void Delete(int MaxEngineerTimeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@MaxEngineerTimeID", MaxEngineerTimeID, true);
                _database.ExecuteSP_NO_Return("MaxEngineerTime_Delete");
            }

            public MaxEngineerTime MaxEngineerTime_Get(int MaxEngineerTimeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@MaxEngineerTimeID", MaxEngineerTimeID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("MaxEngineerTime_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oMaxEngineerTime = new MaxEngineerTime();
                        oMaxEngineerTime.IgnoreExceptionsOnSetMethods = true;
                        oMaxEngineerTime.SetMaxEngineerTimeID = dt.Rows[0]["MaxEngineerTimeID"];
                        oMaxEngineerTime.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oMaxEngineerTime.SetMondayValue = dt.Rows[0]["MondayValue"];
                        oMaxEngineerTime.SetTuesdayValue = dt.Rows[0]["TuesdayValue"];
                        oMaxEngineerTime.SetWednesdayValue = dt.Rows[0]["WednesdayValue"];
                        oMaxEngineerTime.SetThursdayValue = dt.Rows[0]["ThursdayValue"];
                        oMaxEngineerTime.SetFridayValue = dt.Rows[0]["FridayValue"];
                        oMaxEngineerTime.SetSaturdayValue = dt.Rows[0]["SaturdayValue"];
                        oMaxEngineerTime.SetSundayValue = dt.Rows[0]["SundayValue"];
                        oMaxEngineerTime.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oMaxEngineerTime.Exists = true;
                        return oMaxEngineerTime;
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

            public DataView MaxEngineerTime_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("MaxEngineerTime_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblMaxEngineerTime.ToString();
                return new DataView(dt);
            }

            public MaxEngineerTime MaxEngineerTime_GetForEngineer(int EngineerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerID", EngineerID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("MaxEngineerTime_GetForEngineer");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oMaxEngineerTime = new MaxEngineerTime();
                        oMaxEngineerTime.IgnoreExceptionsOnSetMethods = true;
                        oMaxEngineerTime.SetMaxEngineerTimeID = dt.Rows[0]["MaxEngineerTimeID"];
                        oMaxEngineerTime.SetEngineerID = dt.Rows[0]["EngineerID"];
                        oMaxEngineerTime.SetMondayValue = dt.Rows[0]["MondayValue"];
                        oMaxEngineerTime.SetTuesdayValue = dt.Rows[0]["TuesdayValue"];
                        oMaxEngineerTime.SetWednesdayValue = dt.Rows[0]["WednesdayValue"];
                        oMaxEngineerTime.SetThursdayValue = dt.Rows[0]["ThursdayValue"];
                        oMaxEngineerTime.SetFridayValue = dt.Rows[0]["FridayValue"];
                        oMaxEngineerTime.SetSaturdayValue = dt.Rows[0]["SaturdayValue"];
                        oMaxEngineerTime.SetSundayValue = dt.Rows[0]["SundayValue"];
                        oMaxEngineerTime.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oMaxEngineerTime.Exists = true;
                        return oMaxEngineerTime;
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

            public MaxEngineerTime Insert(MaxEngineerTime oMaxEngineerTime)
            {
                _database.ClearParameter();
                AddMaxEngineerTimeParametersToCommand(ref oMaxEngineerTime);
                oMaxEngineerTime.SetMaxEngineerTimeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("MaxEngineerTime_Insert"));
                oMaxEngineerTime.Exists = true;
                return oMaxEngineerTime;
            }

            public void Update(MaxEngineerTime oMaxEngineerTime)
            {
                _database.ClearParameter();
                _database.AddParameter("@MaxEngineerTimeID", oMaxEngineerTime.MaxEngineerTimeID, true);
                AddMaxEngineerTimeParametersToCommand(ref oMaxEngineerTime);
                _database.ExecuteSP_NO_Return("MaxEngineerTime_Update");
            }

            private void AddMaxEngineerTimeParametersToCommand(ref MaxEngineerTime oMaxEngineerTime)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@EngineerID", oMaxEngineerTime.EngineerID, true);
                    withBlock.AddParameter("@MondayValue", oMaxEngineerTime.MondayValue, true);
                    withBlock.AddParameter("@TuesdayValue", oMaxEngineerTime.TuesdayValue, true);
                    withBlock.AddParameter("@WednesdayValue", oMaxEngineerTime.WednesdayValue, true);
                    withBlock.AddParameter("@ThursdayValue", oMaxEngineerTime.ThursdayValue, true);
                    withBlock.AddParameter("@FridayValue", oMaxEngineerTime.FridayValue, true);
                    withBlock.AddParameter("@SaturdayValue", oMaxEngineerTime.SaturdayValue, true);
                    withBlock.AddParameter("@SundayValue", oMaxEngineerTime.SundayValue, true);
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}