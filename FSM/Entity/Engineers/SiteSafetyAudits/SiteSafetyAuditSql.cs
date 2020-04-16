// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Engineers.SiteSafetyAudits.SiteSafetyAuditSql
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers.SiteSafetyAudits.Enums;
using FSM.Entity.Sys;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Engineers.SiteSafetyAudits
{
    public class SiteSafetyAuditSql
    {
        private Database _database;

        public SiteSafetyAuditSql(Database database)
        {
            this._database = database;
        }

        public List<SiteSafetyAudit> Get_As_Entity(object @ref, GetBy getBy)
        {
            this._database.ClearParameter();
            DataTable table;
            switch (getBy)
            {
                case GetBy.Id:
                    this._database.AddParameter("@Id", RuntimeHelpers.GetObjectValue(@ref), true);
                    table = this._database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById", true);
                    break;

                case GetBy.EngineerId:
                    this._database.AddParameter("@EngineerId", RuntimeHelpers.GetObjectValue(@ref), true);
                    table = this._database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ByEngineerId", true);
                    break;

                default:
                    this._database.AddParameter("@Id", RuntimeHelpers.GetObjectValue(@ref), true);
                    table = this._database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById", true);
                    break;
            }
            return table != null && table.Rows.Count > 0 ? ObjectMap.DataTableToList<SiteSafetyAudit>(table) : (List<SiteSafetyAudit>)null;
        }

        public DataView Get_As_DataView(object @ref, GetBy getBy)
        {
            this._database.ClearParameter();
            DataTable table;
            switch (getBy)
            {
                case GetBy.Id:
                    this._database.AddParameter("@Id", RuntimeHelpers.GetObjectValue(@ref), true);
                    table = this._database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById", true);
                    break;

                case GetBy.EngineerId:
                    this._database.AddParameter("@EngineerId", RuntimeHelpers.GetObjectValue(@ref), true);
                    table = this._database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ByEngineerId", true);
                    break;

                default:
                    table = this._database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_All", true);
                    break;
            }
            return new DataView(table);
        }

        public SiteSafetyAudit Insert(SiteSafetyAudit siteSafetyAudit)
        {
            this._database.ClearParameter();
            this.AddParameters(siteSafetyAudit);
            siteSafetyAudit.Id = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerSiteSafetyAudit_Insert", true)));
            return siteSafetyAudit;
        }

        public void Update(SiteSafetyAudit siteSafetyAudit)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Id", (object)siteSafetyAudit.Id, false);
            this.AddParameters(siteSafetyAudit);
            this._database.ExecuteSP_NO_Return("EngineerSiteSafetyAudit_Update", true);
        }

        private void AddParameters(SiteSafetyAudit siteSafetyAudit)
        {
            this._database.AddParameter("@AuditDate", (object)siteSafetyAudit.AuditDate, true);
            this._database.AddParameter("@EngineerId", (object)siteSafetyAudit.EngineerId, true);
            this._database.AddParameter("@Department", (object)siteSafetyAudit.Department, true);
            this._database.AddParameter("@Question1", (object)siteSafetyAudit.Question1, true);
            this._database.AddParameter("@Question2", (object)siteSafetyAudit.Question2, true);
            this._database.AddParameter("@Question3", (object)siteSafetyAudit.Question3, true);
            this._database.AddParameter("@Question4", (object)siteSafetyAudit.Question4, true);
            this._database.AddParameter("@Question5", (object)siteSafetyAudit.Question5, true);
            this._database.AddParameter("@Question6", (object)siteSafetyAudit.Question6, true);
            this._database.AddParameter("@Question7", (object)siteSafetyAudit.Question7, true);
            this._database.AddParameter("@Question8", (object)siteSafetyAudit.Question8, true);
            this._database.AddParameter("@Question9", (object)siteSafetyAudit.Question9, true);
            this._database.AddParameter("@Question10", (object)siteSafetyAudit.Question10, true);
            this._database.AddParameter("@Question11", (object)siteSafetyAudit.Question11, true);
            this._database.AddParameter("@Result", (object)siteSafetyAudit.Result, false);
            this._database.AddParameter("@AuditorId", (object)siteSafetyAudit.AuditorId, false);
        }

        public bool Delete(int id)
        {
            this._database.ClearParameter();
            this._database.AddParameter("@Id", (object)id, false);
            return this._database.ExecuteSP_ReturnRowsAffected("EngineerSiteSafetyAudit_Delete") == 1;
        }
    }
}