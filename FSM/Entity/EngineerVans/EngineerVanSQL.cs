// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVans.EngineerVanSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVans
{
    public class EngineerVanSQL
    {
        private Database _database;

        public EngineerVanSQL(Database database)
        {
            this._database = database;
        }

        public DataView EngineerVan_GetAll_For_Van(int VanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@VanID", (object)VanID, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVan_GetAll_For_Van), true);
            table.TableName = Enums.TableNames.tblEngineerVan.ToString();
            return new DataView(table);
        }

        public DataView EngineerVan_GetAll_For_Engineer(int EngineerID, bool Grouped)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerID", (object)EngineerID, false);
            if (Grouped)
                this._database.AddParameter("@Grouped", (object)1, false);
            else
                this._database.AddParameter("@Grouped", (object)0, false);
            DataTable table = this._database.ExecuteSP_DataTable(nameof(EngineerVan_GetAll_For_Engineer), true);
            table.TableName = Enums.TableNames.tblEngineerVan.ToString();
            return new DataView(table);
        }

        public EngineerVan EngineerVan_Get(int EngineerVanID)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@EngineerVanID", (object)EngineerVanID, false);
            DataTable dataTable = this._database.ExecuteSP_DataTable(nameof(EngineerVan_Get), true);
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return (EngineerVan)null;
            EngineerVan engineerVan1 = new EngineerVan();
            EngineerVan engineerVan2 = engineerVan1;
            engineerVan2.IgnoreExceptionsOnSetMethods = true;
            engineerVan2.SetEngineerVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof(EngineerVanID)]);
            engineerVan2.SetEngineerID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerID"]);
            engineerVan2.SetVanID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VanID"]);
            engineerVan2.StartDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StartDateTime"]));
            engineerVan2.EndDateTime = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EndDateTime"]));
            engineerVan2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
            engineerVan1.Exists = true;
            return engineerVan1;
        }

        public EngineerVan Insert(EngineerVan oEngineerVan)
        {
            EngineerVan engineerVan = (EngineerVan)null;
            string Right = App.DB.Van.Van_Get(oEngineerVan.VanID).Registration.Split('*')[0].Trim();

            foreach (DataRow dr in App.DB.Van.Van_GetAll(false).Table.Rows)
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Registration"])).Split('*')[0].Trim(), Right, false) == 0)
                {
                    this._database.ClearParameter();
                    this._database.AddParameter("@EngineerID", (object)oEngineerVan.EngineerID, true);
                    this._database.AddParameter("@VanID", RuntimeHelpers.GetObjectValue(dr["VanID"]), true);
                    this._database.AddParameter("@StartDateTime", (object)oEngineerVan.StartDateTime, true);
                    if ((uint)DateTime.Compare(oEngineerVan.EndDateTime, DateTime.MinValue) > 0U)
                        this._database.AddParameter("@EndDateTime", (object)oEngineerVan.EndDateTime, true);
                    else
                        this._database.AddParameter("@EndDateTime", (object)DBNull.Value, true);
                    oEngineerVan.SetEngineerVanID = (object)Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVan_Insert", true)));
                    oEngineerVan.Exists = true;
                    if (engineerVan == null)
                        engineerVan = oEngineerVan;
                }
            }

            return engineerVan;
        }

        public void Update(EngineerVan oEngineerVan)
        {
            string Right = App.DB.Van.Van_Get(oEngineerVan.VanID).Registration.Split('*')[0].Trim();
            DataTable table = this.EngineerVan_GetAll_For_Engineer(oEngineerVan.EngineerID, false).Table;

            foreach (DataRow dr1 in App.DB.Van.Van_GetAll(false).Table.Rows)
            {
                foreach (DataRow dr2 in table.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr2["VanID"], dr1["VanID"], false))
                    {
                        this._database.ClearParameter();
                        this._database.AddParameter("@EngineerID", (object)oEngineerVan.EngineerID, true);
                        this._database.AddParameter("@StartDateTime", (object)oEngineerVan.StartDateTime, true);
                        if ((uint)DateTime.Compare(oEngineerVan.EndDateTime, DateTime.MinValue) > 0U)
                            this._database.AddParameter("@EndDateTime", (object)oEngineerVan.EndDateTime, true);
                        else
                            this._database.AddParameter("@EndDateTime", (object)DBNull.Value, true);
                        this._database.AddParameter("@EngineerVanID", RuntimeHelpers.GetObjectValue(dr2["EngineerVanID"]), true);
                        this._database.ExecuteSP_NO_Return("EngineerVan_Update", true);
                    }
                }
            }
        }

        public void Delete(int EngineerVanID)
        {
            EngineerVan engineerVan = this.EngineerVan_Get(EngineerVanID);
            string Right = App.DB.Van.Van_Get(engineerVan.VanID).Registration.Split('*')[0].Trim();
            DataTable table = this.EngineerVan_GetAll_For_Engineer(engineerVan.EngineerID, false).Table;
            foreach (DataRow dr in App.DB.Van.Van_GetAll_incDeleted(false).Table.Rows)
            {
                foreach (DataRow dr2 in table.Rows)
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dr["Registration"])).Split('*')[0].Trim(), Right, false) == 0)
                    {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dr2["VanID"], dr["VanID"], false))
                        {
                            this._database.ClearParameter();
                            this._database.AddParameter("@EngineerVanID", RuntimeHelpers.GetObjectValue(dr2[nameof(EngineerVanID)]), true);
                            this._database.ExecuteSP_NO_Return("EngineerVan_Delete", true);
                        }
                    }
                }
            }
        }
    }
}