using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitAdditionals
    {
        public class EngineerVisitAdditionalSQL
        {
            private Sys.Database _database;

            public EngineerVisitAdditionalSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int EngineerVisitAdditionalID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitAdditionalID", EngineerVisitAdditionalID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitAdditional_Delete");
            }

            public EngineerVisitAdditional EngineerVisitAdditional_Get(int EngineerVisitAdditionalID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitAdditionalID", EngineerVisitAdditionalID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAdditional_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitAdditional = new EngineerVisitAdditional();
                        oEngineerVisitAdditional.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitAdditional.SetTestTypeID = dt.Rows[0]["TestType"];
                        oEngineerVisitAdditional.SetEngineerVisitAdditionalID = dt.Rows[0]["EngineerVisitAdditionalID"];
                        oEngineerVisitAdditional.SetTest1 = dt.Rows[0]["Test1"];
                        oEngineerVisitAdditional.SetTest2 = dt.Rows[0]["Test2"];
                        oEngineerVisitAdditional.SetTest3 = dt.Rows[0]["Test3"];
                        oEngineerVisitAdditional.SetTest4 = dt.Rows[0]["Test4"];
                        oEngineerVisitAdditional.SetTest5 = dt.Rows[0]["Test5"];
                        oEngineerVisitAdditional.SetTest6 = dt.Rows[0]["Test6"];
                        oEngineerVisitAdditional.SetTest7 = dt.Rows[0]["Test7"];
                        oEngineerVisitAdditional.SetTest8 = dt.Rows[0]["Test8"];
                        oEngineerVisitAdditional.SetTest9 = dt.Rows[0]["Test9"];
                        oEngineerVisitAdditional.SetTest10 = dt.Rows[0]["Test10"];
                        oEngineerVisitAdditional.SetTest111 = dt.Rows[0]["Test111"];
                        oEngineerVisitAdditional.SetTest112 = dt.Rows[0]["Test112"];
                        oEngineerVisitAdditional.SetTest113 = dt.Rows[0]["Test113"];
                        oEngineerVisitAdditional.SetTest114 = dt.Rows[0]["Test114"];
                        oEngineerVisitAdditional.SetTest115 = dt.Rows[0]["Test115"];
                        oEngineerVisitAdditional.SetTest116 = dt.Rows[0]["Test116"];
                        oEngineerVisitAdditional.SetTest117 = dt.Rows[0]["Test117"];
                        oEngineerVisitAdditional.SetTest118 = dt.Rows[0]["Test118"];
                        oEngineerVisitAdditional.SetTest119 = dt.Rows[0]["Test119"];
                        oEngineerVisitAdditional.SetTest120 = dt.Rows[0]["Test120"];
                        oEngineerVisitAdditional.SetTest121 = dt.Rows[0]["Test121"];
                        oEngineerVisitAdditional.SetTest122 = dt.Rows[0]["Test122"];
                        oEngineerVisitAdditional.SetTest123 = dt.Rows[0]["Test123"];
                        oEngineerVisitAdditional.SetTest124 = dt.Rows[0]["Test124"];
                        oEngineerVisitAdditional.SetTest125 = dt.Rows[0]["Test125"];
                        oEngineerVisitAdditional.SetTest11 = dt.Rows[0]["Test11"];
                        oEngineerVisitAdditional.SetTest12 = dt.Rows[0]["Test12"];
                        oEngineerVisitAdditional.SetTest13 = dt.Rows[0]["Test13"];
                        oEngineerVisitAdditional.SetTest14 = dt.Rows[0]["Test14"];
                        oEngineerVisitAdditional.SetTest15 = dt.Rows[0]["Test15"];
                        oEngineerVisitAdditional.SetTest216 = dt.Rows[0]["Test216"];
                        oEngineerVisitAdditional.SetTest217 = dt.Rows[0]["Test217"];
                        oEngineerVisitAdditional.SetTest218 = dt.Rows[0]["Test218"];
                        oEngineerVisitAdditional.SetTest219 = dt.Rows[0]["Test219"];
                        oEngineerVisitAdditional.SetTest220 = dt.Rows[0]["Test220"];
                        oEngineerVisitAdditional.SetTest221 = dt.Rows[0]["Test221"];
                        oEngineerVisitAdditional.SetTest222 = dt.Rows[0]["Test222"];
                        oEngineerVisitAdditional.SetTest223 = dt.Rows[0]["Test223"];
                        oEngineerVisitAdditional.SetTest224 = dt.Rows[0]["Test224"];
                        oEngineerVisitAdditional.SetTest225 = dt.Rows[0]["Test225"];
                        oEngineerVisitAdditional.SetTest226 = dt.Rows[0]["Test226"];
                        oEngineerVisitAdditional.SetTest227 = dt.Rows[0]["Test227"];
                        oEngineerVisitAdditional.SetTest228 = dt.Rows[0]["Test228"];
                        oEngineerVisitAdditional.SetTest229 = dt.Rows[0]["Test229"];
                        oEngineerVisitAdditional.SetTest230 = dt.Rows[0]["Test230"];
                        oEngineerVisitAdditional.SetTest231 = dt.Rows[0]["Test231"];
                        oEngineerVisitAdditional.SetTest232 = dt.Rows[0]["Test232"];
                        oEngineerVisitAdditional.SetTest233 = dt.Rows[0]["Test233"];
                        oEngineerVisitAdditional.SetTest234 = dt.Rows[0]["Test234"];
                        oEngineerVisitAdditional.SetTest235 = dt.Rows[0]["Test235"];
                        oEngineerVisitAdditional.SetTest236 = dt.Rows[0]["Test236"];
                        oEngineerVisitAdditional.SetTest237 = dt.Rows[0]["Test237"];
                        oEngineerVisitAdditional.SetTest238 = dt.Rows[0]["Test238"];
                        oEngineerVisitAdditional.SetTest239 = dt.Rows[0]["Test239"];
                        oEngineerVisitAdditional.SetTest240 = dt.Rows[0]["Test240"];
                        oEngineerVisitAdditional.SetTest16 = MakeDateSafe(dt.Rows[0]["Test16"]);
                        oEngineerVisitAdditional.SetTest17 = MakeDateSafe(dt.Rows[0]["Test17"]);
                        oEngineerVisitAdditional.SetTest18 = MakeDateSafe(dt.Rows[0]["Test18"]);
                        oEngineerVisitAdditional.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitAdditional.Exists = true;
                        return oEngineerVisitAdditional;
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

            public EngineerVisitAdditional EngineerVisitAdditional_GetForEngineerVisit(int EngineerVisitID, int Type)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID);
                _database.AddParameter("@TestType", Type);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAdditional_GetForEngineerVisit");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitAdditional = new EngineerVisitAdditional();
                        oEngineerVisitAdditional.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitAdditional.SetTestTypeID = dt.Rows[0]["TestType"];
                        oEngineerVisitAdditional.SetEngineerVisitAdditionalID = dt.Rows[0]["EngineerVisitAdditionalID"];
                        oEngineerVisitAdditional.SetTest1 = dt.Rows[0]["Test1"];
                        oEngineerVisitAdditional.SetTest2 = dt.Rows[0]["Test2"];
                        oEngineerVisitAdditional.SetTest3 = dt.Rows[0]["Test3"];
                        oEngineerVisitAdditional.SetTest4 = dt.Rows[0]["Test4"];
                        oEngineerVisitAdditional.SetTest5 = dt.Rows[0]["Test5"];
                        oEngineerVisitAdditional.SetTest6 = dt.Rows[0]["Test6"];
                        oEngineerVisitAdditional.SetTest7 = dt.Rows[0]["Test7"];
                        oEngineerVisitAdditional.SetTest8 = dt.Rows[0]["Test8"];
                        oEngineerVisitAdditional.SetTest9 = dt.Rows[0]["Test9"];
                        oEngineerVisitAdditional.SetTest10 = dt.Rows[0]["Test10"];
                        oEngineerVisitAdditional.SetTest111 = dt.Rows[0]["Test111"];
                        oEngineerVisitAdditional.SetTest112 = dt.Rows[0]["Test112"];
                        oEngineerVisitAdditional.SetTest113 = dt.Rows[0]["Test113"];
                        oEngineerVisitAdditional.SetTest114 = dt.Rows[0]["Test114"];
                        oEngineerVisitAdditional.SetTest115 = dt.Rows[0]["Test115"];
                        oEngineerVisitAdditional.SetTest116 = dt.Rows[0]["Test116"];
                        oEngineerVisitAdditional.SetTest117 = dt.Rows[0]["Test117"];
                        oEngineerVisitAdditional.SetTest118 = dt.Rows[0]["Test118"];
                        oEngineerVisitAdditional.SetTest119 = dt.Rows[0]["Test119"];
                        oEngineerVisitAdditional.SetTest120 = dt.Rows[0]["Test120"];
                        oEngineerVisitAdditional.SetTest121 = dt.Rows[0]["Test121"];
                        oEngineerVisitAdditional.SetTest122 = dt.Rows[0]["Test122"];
                        oEngineerVisitAdditional.SetTest123 = dt.Rows[0]["Test123"];
                        oEngineerVisitAdditional.SetTest124 = dt.Rows[0]["Test124"];
                        oEngineerVisitAdditional.SetTest125 = dt.Rows[0]["Test125"];
                        oEngineerVisitAdditional.SetTest126 = dt.Rows[0]["Test126"];
                        oEngineerVisitAdditional.SetTest127 = dt.Rows[0]["Test127"];
                        oEngineerVisitAdditional.SetTest128 = dt.Rows[0]["Test128"];
                        oEngineerVisitAdditional.SetTest129 = dt.Rows[0]["Test129"];
                        oEngineerVisitAdditional.SetTest130 = dt.Rows[0]["Test130"];
                        oEngineerVisitAdditional.SetTest131 = dt.Rows[0]["Test131"];
                        oEngineerVisitAdditional.SetTest132 = dt.Rows[0]["Test132"];
                        oEngineerVisitAdditional.SetTest133 = dt.Rows[0]["Test133"];
                        oEngineerVisitAdditional.SetTest134 = dt.Rows[0]["Test134"];
                        oEngineerVisitAdditional.SetTest135 = dt.Rows[0]["Test135"];
                        oEngineerVisitAdditional.SetTest136 = dt.Rows[0]["Test136"];
                        oEngineerVisitAdditional.SetTest137 = dt.Rows[0]["Test137"];
                        oEngineerVisitAdditional.SetTest138 = dt.Rows[0]["Test138"];
                        oEngineerVisitAdditional.SetTest139 = dt.Rows[0]["Test139"];
                        oEngineerVisitAdditional.SetTest140 = dt.Rows[0]["Test140"];
                        oEngineerVisitAdditional.SetTest11 = dt.Rows[0]["Test11"];
                        oEngineerVisitAdditional.SetTest12 = dt.Rows[0]["Test12"];
                        oEngineerVisitAdditional.SetTest13 = dt.Rows[0]["Test13"];
                        oEngineerVisitAdditional.SetTest14 = dt.Rows[0]["Test14"];
                        oEngineerVisitAdditional.SetTest15 = dt.Rows[0]["Test15"];
                        oEngineerVisitAdditional.SetTest216 = dt.Rows[0]["Test216"];
                        oEngineerVisitAdditional.SetTest217 = dt.Rows[0]["Test217"];
                        oEngineerVisitAdditional.SetTest218 = dt.Rows[0]["Test218"];
                        oEngineerVisitAdditional.SetTest219 = dt.Rows[0]["Test219"];
                        oEngineerVisitAdditional.SetTest220 = dt.Rows[0]["Test220"];
                        oEngineerVisitAdditional.SetTest221 = dt.Rows[0]["Test221"];
                        oEngineerVisitAdditional.SetTest222 = dt.Rows[0]["Test222"];
                        oEngineerVisitAdditional.SetTest223 = dt.Rows[0]["Test223"];
                        oEngineerVisitAdditional.SetTest224 = dt.Rows[0]["Test224"];
                        oEngineerVisitAdditional.SetTest225 = dt.Rows[0]["Test225"];
                        oEngineerVisitAdditional.SetTest226 = dt.Rows[0]["Test226"];
                        oEngineerVisitAdditional.SetTest227 = dt.Rows[0]["Test227"];
                        oEngineerVisitAdditional.SetTest228 = dt.Rows[0]["Test228"];
                        oEngineerVisitAdditional.SetTest229 = dt.Rows[0]["Test229"];
                        oEngineerVisitAdditional.SetTest230 = dt.Rows[0]["Test230"];
                        oEngineerVisitAdditional.SetTest231 = dt.Rows[0]["Test231"];
                        oEngineerVisitAdditional.SetTest232 = dt.Rows[0]["Test232"];
                        oEngineerVisitAdditional.SetTest233 = dt.Rows[0]["Test233"];
                        oEngineerVisitAdditional.SetTest234 = dt.Rows[0]["Test234"];
                        oEngineerVisitAdditional.SetTest235 = dt.Rows[0]["Test235"];
                        oEngineerVisitAdditional.SetTest236 = dt.Rows[0]["Test236"];
                        oEngineerVisitAdditional.SetTest237 = dt.Rows[0]["Test237"];
                        oEngineerVisitAdditional.SetTest238 = dt.Rows[0]["Test238"];
                        oEngineerVisitAdditional.SetTest239 = dt.Rows[0]["Test239"];
                        oEngineerVisitAdditional.SetTest240 = dt.Rows[0]["Test240"];
                        oEngineerVisitAdditional.SetTest16 = MakeDateSafe(dt.Rows[0]["Test16"]);
                        oEngineerVisitAdditional.SetTest17 = MakeDateSafe(dt.Rows[0]["Test17"]);
                        oEngineerVisitAdditional.SetTest18 = MakeDateSafe(dt.Rows[0]["Test18"]);
                        oEngineerVisitAdditional.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitAdditional.Exists = true;
                        return oEngineerVisitAdditional;
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

            public EngineerVisitAdditional Insert(EngineerVisitAdditional oEngineerVisitAdditional)
            {
                _database.ClearParameter();
                AddEngineerVisitAdditionalParametersToCommand(ref oEngineerVisitAdditional);
                oEngineerVisitAdditional.SetEngineerVisitAdditionalID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitAdditional_Insert"));
                oEngineerVisitAdditional.Exists = true;
                return oEngineerVisitAdditional;
            }

            public void Update(EngineerVisitAdditional oEngineerVisitAdditional)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitAdditionalID", oEngineerVisitAdditional.EngineerVisitAdditionalID, true);
                AddEngineerVisitAdditionalParametersToCommand(ref oEngineerVisitAdditional);
                _database.ExecuteSP_NO_Return("EngineerVisitAdditional_Update");
            }

            private void AddEngineerVisitAdditionalParametersToCommand(ref EngineerVisitAdditional oEngineerVisitAdditional)
            {
                {
                    var withBlock = _database;
                    var date1 = oEngineerVisitAdditional.Test16;
                    var date2 = oEngineerVisitAdditional.Test17;
                    var date3 = oEngineerVisitAdditional.Test18;
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitAdditional.EngineerVisitID, true);
                    withBlock.AddParameter("@TestType", oEngineerVisitAdditional.TestTypeID, true);
                    withBlock.AddParameter("@Test1", oEngineerVisitAdditional.Test1, true);
                    withBlock.AddParameter("@Test2", oEngineerVisitAdditional.Test2, true);
                    withBlock.AddParameter("@Test3", oEngineerVisitAdditional.Test3, true);
                    withBlock.AddParameter("@Test4", oEngineerVisitAdditional.Test4, true);
                    withBlock.AddParameter("@Test5", oEngineerVisitAdditional.Test5, true);
                    withBlock.AddParameter("@Test6", oEngineerVisitAdditional.Test6, true);
                    withBlock.AddParameter("@Test7", oEngineerVisitAdditional.Test7, true);
                    withBlock.AddParameter("@Test8", oEngineerVisitAdditional.Test8, true);
                    withBlock.AddParameter("@Test9", oEngineerVisitAdditional.Test9, true);
                    withBlock.AddParameter("@Test10", oEngineerVisitAdditional.Test10, true);
                    withBlock.AddParameter("@Test111", oEngineerVisitAdditional.Test111, true);
                    withBlock.AddParameter("@Test112", oEngineerVisitAdditional.Test112, true);
                    withBlock.AddParameter("@Test113", oEngineerVisitAdditional.Test113, true);
                    withBlock.AddParameter("@Test114", oEngineerVisitAdditional.Test114, true);
                    withBlock.AddParameter("@Test115", oEngineerVisitAdditional.Test115, true);
                    withBlock.AddParameter("@Test116", oEngineerVisitAdditional.Test116, true);
                    withBlock.AddParameter("@Test117", oEngineerVisitAdditional.Test117, true);
                    withBlock.AddParameter("@Test118", oEngineerVisitAdditional.Test118, true);
                    withBlock.AddParameter("@Test119", oEngineerVisitAdditional.Test119, true);
                    withBlock.AddParameter("@Test120", oEngineerVisitAdditional.Test120, true);
                    withBlock.AddParameter("@Test11", oEngineerVisitAdditional.Test11, true);
                    withBlock.AddParameter("@Test12", oEngineerVisitAdditional.Test12, true);
                    withBlock.AddParameter("@Test13", oEngineerVisitAdditional.Test13, true);
                    withBlock.AddParameter("@Test14", oEngineerVisitAdditional.Test14, true);
                    withBlock.AddParameter("@Test15", oEngineerVisitAdditional.Test15, true);
                    withBlock.AddParameter("@Test216", oEngineerVisitAdditional.Test216, true);
                    withBlock.AddParameter("@Test217", oEngineerVisitAdditional.Test217, true);
                    withBlock.AddParameter("@Test218", oEngineerVisitAdditional.Test218, true);
                    withBlock.AddParameter("@Test219", oEngineerVisitAdditional.Test219, true);
                    withBlock.AddParameter("@Test220", oEngineerVisitAdditional.Test220, true);
                    withBlock.AddParameter("@Test221", oEngineerVisitAdditional.Test221, true);
                    withBlock.AddParameter("@Test222", oEngineerVisitAdditional.Test222, true);
                    withBlock.AddParameter("@Test223", oEngineerVisitAdditional.Test223, true);
                    withBlock.AddParameter("@Test224", oEngineerVisitAdditional.Test224, true);
                    withBlock.AddParameter("@Test225", oEngineerVisitAdditional.Test225, true);
                    withBlock.AddParameter("@Test226", oEngineerVisitAdditional.Test226, true);
                    withBlock.AddParameter("@Test227", oEngineerVisitAdditional.Test227, true);
                    withBlock.AddParameter("@Test228", oEngineerVisitAdditional.Test228, true);
                    withBlock.AddParameter("@Test229", oEngineerVisitAdditional.Test229, true);
                    withBlock.AddParameter("@Test230", oEngineerVisitAdditional.Test230, true);
                    withBlock.AddParameter("@Test231", oEngineerVisitAdditional.Test231, true);
                    withBlock.AddParameter("@Test232", oEngineerVisitAdditional.Test232, true);
                    withBlock.AddParameter("@Test233", oEngineerVisitAdditional.Test233, true);
                    withBlock.AddParameter("@Test234", oEngineerVisitAdditional.Test234, true);
                    withBlock.AddParameter("@Test235", oEngineerVisitAdditional.Test235, true);
                    withBlock.AddParameter("@Test236", oEngineerVisitAdditional.Test236, true);
                    withBlock.AddParameter("@Test237", oEngineerVisitAdditional.Test237, true);
                    withBlock.AddParameter("@Test238", oEngineerVisitAdditional.Test238, true);
                    withBlock.AddParameter("@Test239", oEngineerVisitAdditional.Test239, true);
                    withBlock.AddParameter("@Test240", oEngineerVisitAdditional.Test240, true);
                    if (oEngineerVisitAdditional.Test16 == DateTime.MinValue)
                    {
                        withBlock.AddParameter("@Test16", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@Test16", Sys.Helper.MakeDateTimeValid(oEngineerVisitAdditional.Test16), true);
                    }

                    if (oEngineerVisitAdditional.Test17 == DateTime.MinValue)
                    {
                        withBlock.AddParameter("@Test17", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@Test17", Sys.Helper.MakeDateTimeValid(oEngineerVisitAdditional.Test17), true);
                    }

                    if (oEngineerVisitAdditional.Test18 == DateTime.MinValue)
                    {
                        withBlock.AddParameter("@Test18", DBNull.Value, true);
                    }
                    else
                    {
                        withBlock.AddParameter("@Test18", Sys.Helper.MakeDateTimeValid(oEngineerVisitAdditional.Test18), true);
                    }
                }
            }

            public DataView EngineerVisitAdditionalWorkSheet_GetForVisitDV(int EngineerVisitID, int Oil = -1)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@TestType", 0);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAdditional_GetForEngineerVisit");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
                return new DataView(dt);
            }

            public DataView EngineerVisitSmokeComo_GetForVisitDV(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAlarms_GetForEngineerVisit");
                dt.TableName = "Alarms";
                return new DataView(dt);
            }

            public DataView EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(int EngineerVisitID, int test = -1)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                _database.AddParameter("@TestType", test);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitAdditional_GetForEngineerVisit");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
                return new DataView(dt);
            }

            public static DateTime MakeDateSafe(object myDate)
            {
                if (string.IsNullOrEmpty(myDate.ToString()))
                {
                    // myDate.ToString("yyyy/MM/dd hh:mm:ss") = "0001/01/01 12:00:00" Or
                    return Conversions.ToDate("01/01/1900");
                }
                else
                {
                    return Conversions.ToDate(myDate);
                }
            }

            public DataTable EngineerVisitAdditionalWorkSheet_ElectricalZsMatrix_Get()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("ElectricalZsMatrix_Get");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
                return dt;
            }
        }
    }
}