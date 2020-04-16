// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitAdditionals.EngineerVisitAdditionalSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitAdditionals
{
    public class EngineerVisitAdditionalSQL
    {
        private Database _database;

        public EngineerVisitAdditionalSQL(Database database)
        {
            this._database = database;
        }

        public void Delete(int EngineerVisitAdditionalID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitAdditionalID", (object)EngineerVisitAdditionalID, true);
            this._database.ExecuteSP_NO_Return("EngineerVisitAdditional_Delete", true);
        }

        public EngineerVisitAdditional EngineerVisitAdditional_Get(
          int EngineerVisitAdditionalID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitAdditionalID", (object)EngineerVisitAdditionalID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(EngineerVisitAdditional_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (EngineerVisitAdditional)null;
            EngineerVisitAdditional engineerVisitAdditional1 = new EngineerVisitAdditional();
            EngineerVisitAdditional engineerVisitAdditional2 = engineerVisitAdditional1;
            engineerVisitAdditional2.IgnoreExceptionsOnSetMethods = true;
            engineerVisitAdditional2.SetTestTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TestType"]);
            engineerVisitAdditional2.SetEngineerVisitAdditionalID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(EngineerVisitAdditionalID)]);
            engineerVisitAdditional2.SetTest1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test1"]);
            engineerVisitAdditional2.SetTest2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test2"]);
            engineerVisitAdditional2.SetTest3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test3"]);
            engineerVisitAdditional2.SetTest4 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test4"]);
            engineerVisitAdditional2.SetTest5 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test5"]);
            engineerVisitAdditional2.SetTest6 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test6"]);
            engineerVisitAdditional2.SetTest7 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test7"]);
            engineerVisitAdditional2.SetTest8 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test8"]);
            engineerVisitAdditional2.SetTest9 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test9"]);
            engineerVisitAdditional2.SetTest10 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test10"]);
            engineerVisitAdditional2.SetTest111 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test111"]);
            engineerVisitAdditional2.SetTest112 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test112"]);
            engineerVisitAdditional2.SetTest113 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test113"]);
            engineerVisitAdditional2.SetTest114 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test114"]);
            engineerVisitAdditional2.SetTest115 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test115"]);
            engineerVisitAdditional2.SetTest116 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test116"]);
            engineerVisitAdditional2.SetTest117 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test117"]);
            engineerVisitAdditional2.SetTest118 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test118"]);
            engineerVisitAdditional2.SetTest119 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test119"]);
            engineerVisitAdditional2.SetTest120 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test120"]);
            engineerVisitAdditional2.SetTest121 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test121"]);
            engineerVisitAdditional2.SetTest122 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test122"]);
            engineerVisitAdditional2.SetTest123 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test123"]);
            engineerVisitAdditional2.SetTest124 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test124"]);
            engineerVisitAdditional2.SetTest125 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test125"]);
            engineerVisitAdditional2.SetTest11 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test11"]);
            engineerVisitAdditional2.SetTest12 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test12"]);
            engineerVisitAdditional2.SetTest13 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test13"]);
            engineerVisitAdditional2.SetTest14 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test14"]);
            engineerVisitAdditional2.SetTest15 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test15"]);
            engineerVisitAdditional2.SetTest216 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test216"]);
            engineerVisitAdditional2.SetTest217 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test217"]);
            engineerVisitAdditional2.SetTest218 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test218"]);
            engineerVisitAdditional2.SetTest219 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test219"]);
            engineerVisitAdditional2.SetTest220 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test220"]);
            engineerVisitAdditional2.SetTest221 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test221"]);
            engineerVisitAdditional2.SetTest222 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test222"]);
            engineerVisitAdditional2.SetTest223 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test223"]);
            engineerVisitAdditional2.SetTest224 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test224"]);
            engineerVisitAdditional2.SetTest225 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test225"]);
            engineerVisitAdditional2.SetTest226 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test226"]);
            engineerVisitAdditional2.SetTest227 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test227"]);
            engineerVisitAdditional2.SetTest228 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test228"]);
            engineerVisitAdditional2.SetTest229 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test229"]);
            engineerVisitAdditional2.SetTest230 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test230"]);
            engineerVisitAdditional2.SetTest231 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test231"]);
            engineerVisitAdditional2.SetTest232 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test232"]);
            engineerVisitAdditional2.SetTest233 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test233"]);
            engineerVisitAdditional2.SetTest234 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test234"]);
            engineerVisitAdditional2.SetTest235 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test235"]);
            engineerVisitAdditional2.SetTest236 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test236"]);
            engineerVisitAdditional2.SetTest237 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test237"]);
            engineerVisitAdditional2.SetTest238 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test238"]);
            engineerVisitAdditional2.SetTest239 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test239"]);
            engineerVisitAdditional2.SetTest240 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test240"]);
            engineerVisitAdditional2.SetTest16 = EngineerVisitAdditionalSQL.MakeDateSafe(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test16"]));
            engineerVisitAdditional2.SetTest17 = EngineerVisitAdditionalSQL.MakeDateSafe(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test17"]));
            engineerVisitAdditional2.SetTest18 = EngineerVisitAdditionalSQL.MakeDateSafe(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test18"]));
            engineerVisitAdditional2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitID"]);
            engineerVisitAdditional1.Exists = true;
            return engineerVisitAdditional1;
        }

        public EngineerVisitAdditional EngineerVisitAdditional_GetForEngineerVisit(
          int EngineerVisitID,
          int Type)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, false);
            this._database.AddParameter("@TestType", (object)Type, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(EngineerVisitAdditional_GetForEngineerVisit), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (EngineerVisitAdditional)null;
            EngineerVisitAdditional engineerVisitAdditional1 = new EngineerVisitAdditional();
            EngineerVisitAdditional engineerVisitAdditional2 = engineerVisitAdditional1;
            engineerVisitAdditional2.IgnoreExceptionsOnSetMethods = true;
            engineerVisitAdditional2.SetTestTypeID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TestType"]);
            engineerVisitAdditional2.SetEngineerVisitAdditionalID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitAdditionalID"]);
            engineerVisitAdditional2.SetTest1 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test1"]);
            engineerVisitAdditional2.SetTest2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test2"]);
            engineerVisitAdditional2.SetTest3 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test3"]);
            engineerVisitAdditional2.SetTest4 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test4"]);
            engineerVisitAdditional2.SetTest5 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test5"]);
            engineerVisitAdditional2.SetTest6 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test6"]);
            engineerVisitAdditional2.SetTest7 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test7"]);
            engineerVisitAdditional2.SetTest8 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test8"]);
            engineerVisitAdditional2.SetTest9 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test9"]);
            engineerVisitAdditional2.SetTest10 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test10"]);
            engineerVisitAdditional2.SetTest111 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test111"]);
            engineerVisitAdditional2.SetTest112 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test112"]);
            engineerVisitAdditional2.SetTest113 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test113"]);
            engineerVisitAdditional2.SetTest114 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test114"]);
            engineerVisitAdditional2.SetTest115 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test115"]);
            engineerVisitAdditional2.SetTest116 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test116"]);
            engineerVisitAdditional2.SetTest117 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test117"]);
            engineerVisitAdditional2.SetTest118 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test118"]);
            engineerVisitAdditional2.SetTest119 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test119"]);
            engineerVisitAdditional2.SetTest120 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test120"]);
            engineerVisitAdditional2.SetTest121 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test121"]);
            engineerVisitAdditional2.SetTest122 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test122"]);
            engineerVisitAdditional2.SetTest123 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test123"]);
            engineerVisitAdditional2.SetTest124 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test124"]);
            engineerVisitAdditional2.SetTest125 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test125"]);
            engineerVisitAdditional2.SetTest126 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test126"]);
            engineerVisitAdditional2.SetTest127 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test127"]);
            engineerVisitAdditional2.SetTest128 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test128"]);
            engineerVisitAdditional2.SetTest129 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test129"]);
            engineerVisitAdditional2.SetTest130 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test130"]);
            engineerVisitAdditional2.SetTest131 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test131"]);
            engineerVisitAdditional2.SetTest132 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test132"]);
            engineerVisitAdditional2.SetTest133 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test133"]);
            engineerVisitAdditional2.SetTest134 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test134"]);
            engineerVisitAdditional2.SetTest135 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test135"]);
            engineerVisitAdditional2.SetTest136 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test136"]);
            engineerVisitAdditional2.SetTest137 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test137"]);
            engineerVisitAdditional2.SetTest138 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test138"]);
            engineerVisitAdditional2.SetTest139 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test139"]);
            engineerVisitAdditional2.SetTest140 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test140"]);
            engineerVisitAdditional2.SetTest11 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test11"]);
            engineerVisitAdditional2.SetTest12 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test12"]);
            engineerVisitAdditional2.SetTest13 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test13"]);
            engineerVisitAdditional2.SetTest14 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test14"]);
            engineerVisitAdditional2.SetTest15 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test15"]);
            engineerVisitAdditional2.SetTest216 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test216"]);
            engineerVisitAdditional2.SetTest217 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test217"]);
            engineerVisitAdditional2.SetTest218 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test218"]);
            engineerVisitAdditional2.SetTest219 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test219"]);
            engineerVisitAdditional2.SetTest220 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test220"]);
            engineerVisitAdditional2.SetTest221 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test221"]);
            engineerVisitAdditional2.SetTest222 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test222"]);
            engineerVisitAdditional2.SetTest223 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test223"]);
            engineerVisitAdditional2.SetTest224 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test224"]);
            engineerVisitAdditional2.SetTest225 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test225"]);
            engineerVisitAdditional2.SetTest226 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test226"]);
            engineerVisitAdditional2.SetTest227 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test227"]);
            engineerVisitAdditional2.SetTest228 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test228"]);
            engineerVisitAdditional2.SetTest229 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test229"]);
            engineerVisitAdditional2.SetTest230 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test230"]);
            engineerVisitAdditional2.SetTest231 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test231"]);
            engineerVisitAdditional2.SetTest232 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test232"]);
            engineerVisitAdditional2.SetTest233 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test233"]);
            engineerVisitAdditional2.SetTest234 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test234"]);
            engineerVisitAdditional2.SetTest235 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test235"]);
            engineerVisitAdditional2.SetTest236 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test236"]);
            engineerVisitAdditional2.SetTest237 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test237"]);
            engineerVisitAdditional2.SetTest238 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test238"]);
            engineerVisitAdditional2.SetTest239 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test239"]);
            engineerVisitAdditional2.SetTest240 = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test240"]);
            engineerVisitAdditional2.SetTest16 = EngineerVisitAdditionalSQL.MakeDateSafe(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test16"]));
            engineerVisitAdditional2.SetTest17 = EngineerVisitAdditionalSQL.MakeDateSafe(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test17"]));
            engineerVisitAdditional2.SetTest18 = EngineerVisitAdditionalSQL.MakeDateSafe(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Test18"]));
            engineerVisitAdditional2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(EngineerVisitID)]);
            engineerVisitAdditional1.Exists = true;
            return engineerVisitAdditional1;
        }

        public DataView EngineerVisitAdditional_GetAll()
        {
            this._database.ClearParameter();
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVisitAdditional_GetAll), true);
            table.TableName = Enums.TableNames.tblEngineerVisitNCCGSR.ToString();
            return new DataView(table);
        }

        public EngineerVisitAdditional Insert(
          EngineerVisitAdditional oEngineerVisitAdditional)
        {
            this._database.ClearParameter();
            this.AddEngineerVisitAdditionalParametersToCommand(ref oEngineerVisitAdditional);
            oEngineerVisitAdditional.SetEngineerVisitAdditionalID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitAdditional_Insert", true)));
            oEngineerVisitAdditional.Exists = true;
            return oEngineerVisitAdditional;
        }

        public void Update(EngineerVisitAdditional oEngineerVisitAdditional)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitAdditionalID", (object)oEngineerVisitAdditional.EngineerVisitAdditionalID, true);
            this.AddEngineerVisitAdditionalParametersToCommand(ref oEngineerVisitAdditional);
            this._database.ExecuteSP_NO_Return("EngineerVisitAdditional_Update", true);
        }

        private void AddEngineerVisitAdditionalParametersToCommand(
          ref EngineerVisitAdditional oEngineerVisitAdditional)
        {
            Database database = this._database;
            DateTime test16 = oEngineerVisitAdditional.Test16;
            DateTime test17 = oEngineerVisitAdditional.Test17;
            DateTime test18 = oEngineerVisitAdditional.Test18;
            database.AddParameter("@EngineerVisitID", (object)oEngineerVisitAdditional.EngineerVisitID, true);
            database.AddParameter("@TestType", (object)oEngineerVisitAdditional.TestTypeID, true);
            database.AddParameter("@Test1", (object)oEngineerVisitAdditional.Test1, true);
            database.AddParameter("@Test2", (object)oEngineerVisitAdditional.Test2, true);
            database.AddParameter("@Test3", (object)oEngineerVisitAdditional.Test3, true);
            database.AddParameter("@Test4", (object)oEngineerVisitAdditional.Test4, true);
            database.AddParameter("@Test5", (object)oEngineerVisitAdditional.Test5, true);
            database.AddParameter("@Test6", (object)oEngineerVisitAdditional.Test6, true);
            database.AddParameter("@Test7", (object)oEngineerVisitAdditional.Test7, true);
            database.AddParameter("@Test8", (object)oEngineerVisitAdditional.Test8, true);
            database.AddParameter("@Test9", (object)oEngineerVisitAdditional.Test9, true);
            database.AddParameter("@Test10", (object)oEngineerVisitAdditional.Test10, true);
            database.AddParameter("@Test111", (object)oEngineerVisitAdditional.Test111, true);
            database.AddParameter("@Test112", (object)oEngineerVisitAdditional.Test112, true);
            database.AddParameter("@Test113", (object)oEngineerVisitAdditional.Test113, true);
            database.AddParameter("@Test114", (object)oEngineerVisitAdditional.Test114, true);
            database.AddParameter("@Test115", (object)oEngineerVisitAdditional.Test115, true);
            database.AddParameter("@Test116", (object)oEngineerVisitAdditional.Test116, true);
            database.AddParameter("@Test117", (object)oEngineerVisitAdditional.Test117, true);
            database.AddParameter("@Test118", (object)oEngineerVisitAdditional.Test118, true);
            database.AddParameter("@Test119", (object)oEngineerVisitAdditional.Test119, true);
            database.AddParameter("@Test120", (object)oEngineerVisitAdditional.Test120, true);
            database.AddParameter("@Test11", (object)oEngineerVisitAdditional.Test11, true);
            database.AddParameter("@Test12", (object)oEngineerVisitAdditional.Test12, true);
            database.AddParameter("@Test13", (object)oEngineerVisitAdditional.Test13, true);
            database.AddParameter("@Test14", (object)oEngineerVisitAdditional.Test14, true);
            database.AddParameter("@Test15", (object)oEngineerVisitAdditional.Test15, true);
            database.AddParameter("@Test216", (object)oEngineerVisitAdditional.Test216, true);
            database.AddParameter("@Test217", (object)oEngineerVisitAdditional.Test217, true);
            database.AddParameter("@Test218", (object)oEngineerVisitAdditional.Test218, true);
            database.AddParameter("@Test219", (object)oEngineerVisitAdditional.Test219, true);
            database.AddParameter("@Test220", (object)oEngineerVisitAdditional.Test220, true);
            database.AddParameter("@Test221", (object)oEngineerVisitAdditional.Test221, true);
            database.AddParameter("@Test222", (object)oEngineerVisitAdditional.Test222, true);
            database.AddParameter("@Test223", (object)oEngineerVisitAdditional.Test223, true);
            database.AddParameter("@Test224", (object)oEngineerVisitAdditional.Test224, true);
            database.AddParameter("@Test225", (object)oEngineerVisitAdditional.Test225, true);
            database.AddParameter("@Test226", (object)oEngineerVisitAdditional.Test226, true);
            database.AddParameter("@Test227", (object)oEngineerVisitAdditional.Test227, true);
            database.AddParameter("@Test228", (object)oEngineerVisitAdditional.Test228, true);
            database.AddParameter("@Test229", (object)oEngineerVisitAdditional.Test229, true);
            database.AddParameter("@Test230", (object)oEngineerVisitAdditional.Test230, true);
            database.AddParameter("@Test231", (object)oEngineerVisitAdditional.Test231, true);
            database.AddParameter("@Test232", (object)oEngineerVisitAdditional.Test232, true);
            database.AddParameter("@Test233", (object)oEngineerVisitAdditional.Test233, true);
            database.AddParameter("@Test234", (object)oEngineerVisitAdditional.Test234, true);
            database.AddParameter("@Test235", (object)oEngineerVisitAdditional.Test235, true);
            database.AddParameter("@Test236", (object)oEngineerVisitAdditional.Test236, true);
            database.AddParameter("@Test237", (object)oEngineerVisitAdditional.Test237, true);
            database.AddParameter("@Test238", (object)oEngineerVisitAdditional.Test238, true);
            database.AddParameter("@Test239", (object)oEngineerVisitAdditional.Test239, true);
            database.AddParameter("@Test240", (object)oEngineerVisitAdditional.Test240, true);
            if (DateTime.Compare(oEngineerVisitAdditional.Test16, DateTime.MinValue) == 0)
                database.AddParameter("@Test16", (object)DBNull.Value, true);
            else
                database.AddParameter("@Test16", (object)Helper.MakeDateTimeValid((object)oEngineerVisitAdditional.Test16), true);
            if (DateTime.Compare(oEngineerVisitAdditional.Test17, DateTime.MinValue) == 0)
                database.AddParameter("@Test17", (object)DBNull.Value, true);
            else
                database.AddParameter("@Test17", (object)Helper.MakeDateTimeValid((object)oEngineerVisitAdditional.Test17), true);
            if (DateTime.Compare(oEngineerVisitAdditional.Test18, DateTime.MinValue) == 0)
                database.AddParameter("@Test18", (object)DBNull.Value, true);
            else
                database.AddParameter("@Test18", (object)Helper.MakeDateTimeValid((object)oEngineerVisitAdditional.Test18), true);
        }

        public DataView EngineerVisitAdditionalWorkSheet_GetForVisitDV(
          int EngineerVisitID,
          int Oil = -1)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@TestType", (object)0, false);
            DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitAdditional_GetForEngineerVisit", true);
            table.TableName = Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
            return new DataView(table);
        }

        public DataView EngineerVisitSmokeComo_GetForVisitDV(int EngineerVisitID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitAlarms_GetForEngineerVisit", true);
            table.TableName = "Alarms";
            return new DataView(table);
        }

        public DataView EngineerVisitAdditionalWorkSheet_GetForVisitDVProper(
          int EngineerVisitID,
          int test = -1)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVisitID", (object)EngineerVisitID, true);
            this._database.AddParameter("@TestType", (object)test, false);
            DataTable table = this._database.ExecuteSP_DataTable("EngineerVisitAdditional_GetForEngineerVisit", true);
            table.TableName = Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
            return new DataView(table);
        }

        public static DateTime MakeDateSafe(object myDate)
        {
            return Microsoft.VisualBasic.CompilerServices.Operators.CompareString(myDate.ToString(), "", false) == 0 ? Conversions.ToDate("01/01/1900") : Conversions.ToDate(myDate);
        }

        public DataTable EngineerVisitAdditionalWorkSheet_ElectricalZsMatrix_Get()
        {
            this._database.ClearParameter();
            DataTable dataTable = this._database.ExecuteSP_DataTable("ElectricalZsMatrix_Get", true);
            dataTable.TableName = Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
            return dataTable;
        }
    }
}