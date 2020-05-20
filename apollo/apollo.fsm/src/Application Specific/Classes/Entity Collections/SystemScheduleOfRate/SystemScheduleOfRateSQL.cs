using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace SystemScheduleOfRates
    {
        public class SystemScheduleOfRateSQL
        {
            private Sys.Database _database;

            public SystemScheduleOfRateSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int SystemScheduleOfRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SystemScheduleOfRateID", SystemScheduleOfRateID, true);
                _database.ExecuteSP_NO_Return("SystemScheduleOfRate_Delete");
            }

            public SystemScheduleOfRate SystemScheduleOfRate_Get(int SystemScheduleOfRateID)
            {
                _database.ClearParameter();
                _database.AddParameter("@SystemScheduleOfRateID", SystemScheduleOfRateID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("SystemScheduleOfRate_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oSystemScheduleOfRate = new SystemScheduleOfRate();
                        oSystemScheduleOfRate.IgnoreExceptionsOnSetMethods = true;
                        oSystemScheduleOfRate.SetSystemScheduleOfRateID = dt.Rows[0]["SystemScheduleOfRateID"];
                        oSystemScheduleOfRate.SetScheduleOfRatesCategoryID = dt.Rows[0]["ScheduleOfRatesCategoryID"];
                        oSystemScheduleOfRate.SetCode = dt.Rows[0]["Code"];
                        oSystemScheduleOfRate.SetDescription = dt.Rows[0]["Description"];
                        oSystemScheduleOfRate.SetPrice = dt.Rows[0]["Price"];
                        oSystemScheduleOfRate.SetTimeInMins = Sys.Helper.MakeIntegerValid(dt.Rows[0]["TimeInMins"]);
                        oSystemScheduleOfRate.SetJobTypeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["JobTypeID"]);
                        oSystemScheduleOfRate.SetAllowDeleted = dt.Rows[0]["AllowDeleted"];
                        oSystemScheduleOfRate.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oSystemScheduleOfRate.Exists = true;
                        return oSystemScheduleOfRate;
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

            public DataView SystemScheduleOfRate_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("SystemScheduleOfRate_GetAll");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataView SystemScheduleOfRate_Get_ByEngineerQual(int engQualID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngQualID", engQualID, true);
                var dt = _database.ExecuteSP_DataTable("SystemScheduleOfRate_Get_ByEngineerQual");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public DataView SystemScheduleOfRate_GetAll_WithoutDefaults()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("SystemScheduleOfRate_GetAll_WithoutDefaults");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public SystemScheduleOfRate Insert(SystemScheduleOfRate oSystemScheduleOfRate)
            {
                _database.ClearParameter();
                AddParametersToCommand(ref oSystemScheduleOfRate);
                oSystemScheduleOfRate.SetSystemScheduleOfRateID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SystemScheduleOfRate_Insert"));
                oSystemScheduleOfRate.Exists = true;
                return oSystemScheduleOfRate;
            }

            public void Update(SystemScheduleOfRate oSystemScheduleOfRate)
            {
                _database.ClearParameter();
                _database.AddParameter("@SystemScheduleOfRateID", oSystemScheduleOfRate.SystemScheduleOfRateID, true);
                AddParametersToCommand(ref oSystemScheduleOfRate);
                _database.ExecuteSP_NO_Return("SystemScheduleOfRate_Update");
            }

            private void AddParametersToCommand(ref SystemScheduleOfRate oSystemScheduleOfRate)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@ScheduleOfRatesCategoryID", oSystemScheduleOfRate.ScheduleOfRatesCategoryID, true);
                    withBlock.AddParameter("@Code", oSystemScheduleOfRate.Code, true);
                    withBlock.AddParameter("@Description", oSystemScheduleOfRate.Description, true);
                    withBlock.AddParameter("@Price", oSystemScheduleOfRate.Price, true);
                    withBlock.AddParameter("@TimeInMins", oSystemScheduleOfRate.TimeInMins, true);
                    withBlock.AddParameter("@JobTypeID", oSystemScheduleOfRate.JobTypeID, true);
                    withBlock.AddParameter("@AllowDeleted", oSystemScheduleOfRate.AllowDeleted, true);
                }
            }

            public DataView SOREnginerQual_Get_ForSOR(int sorId)
            {
                _database.ClearParameter();
                _database.AddParameter("@SORID", sorId, true);
                var dt = _database.ExecuteSP_DataTable("SOREnginerQual_Get_ForSOR");
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                return new DataView(dt);
            }

            public void SOREnginerQual_Insert(int sorId, int engQualId)
            {
                _database.ClearParameter();
                _database.AddParameter("@SystemScheduleOfRateID", sorId, true);
                _database.AddParameter("@EngineerQualID", engQualId, true);
                _database.ExecuteSP_OBJECT("SOREnginerQual_Insert");
            }

            public void SOREnginerQual_Delete(int sorId)
            {
                _database.ClearParameter();
                App.DB.ExecuteScalar("DELETE FROM [tblSOREnginerQual] Where [SystemScheduleOfRateID] = " + sorId);
            }
        }
    }
}