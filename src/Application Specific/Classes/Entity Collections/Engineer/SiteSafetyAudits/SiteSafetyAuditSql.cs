using System.Collections.Generic;
using System.Data;
using FSM.Entity.Engineers.SiteSafetyAudits.Enums;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.Engineers.SiteSafetyAudits
{
    public class SiteSafetyAuditSql
    {
        private Database _database;

        public SiteSafetyAuditSql(Database database)
        {
            _database = database;
        }

        public List<SiteSafetyAudit> Get_As_Entity(object @ref, GetBy getBy)
        {
            _database.ClearParameter();

            // Get the datatable from the database store in dt
            DataTable dt = null;
            switch (getBy)
            {
                case GetBy.Id:
                    {
                        _database.AddParameter("@Id", @ref, true);
                        dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById");
                        break;
                    }

                case GetBy.EngineerId:
                    {
                        _database.AddParameter("@EngineerId", @ref, true);
                        dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ByEngineerId");
                        break;
                    }

                default:
                    {
                        _database.AddParameter("@Id", @ref, true);
                        dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById");
                        break;
                    }
            }

            if (dt is object && dt.Rows.Count > 0)
            {
                var siteSafetyAudits = ObjectMap.DataTableToList<SiteSafetyAudit>(dt);
                return siteSafetyAudits;
            }
            else
            {
                return null;
            }
        }

        public DataView Get_As_DataView(object @ref, GetBy getBy)
        {
            _database.ClearParameter();

            // Get the datatable from the database store in dt
            DataTable dt = null;
            switch (getBy)
            {
                case GetBy.Id:
                    {
                        _database.AddParameter("@Id", @ref, true);
                        dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ById");
                        break;
                    }

                case GetBy.EngineerId:
                    {
                        _database.AddParameter("@EngineerId", @ref, true);
                        dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_ByEngineerId");
                        break;
                    }

                default:
                    {
                        dt = _database.ExecuteSP_DataTable("EngineerSiteSafetyAudit_Get_All");
                        break;
                    }
            }

            return new DataView(dt);
        }

        public SiteSafetyAudit Insert(SiteSafetyAudit siteSafetyAudit)
        {
            _database.ClearParameter();
            AddParameters(siteSafetyAudit);
            siteSafetyAudit.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerSiteSafetyAudit_Insert"));
            return siteSafetyAudit;
        }

        public void Update(SiteSafetyAudit siteSafetyAudit)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", siteSafetyAudit.Id);
            AddParameters(siteSafetyAudit);
            _database.ExecuteSP_NO_Return("EngineerSiteSafetyAudit_Update");
        }

        private void AddParameters(SiteSafetyAudit siteSafetyAudit)
        {
            _database.AddParameter("@AuditDate", siteSafetyAudit.AuditDate, true);
            _database.AddParameter("@EngineerId", siteSafetyAudit.EngineerId, true);
            _database.AddParameter("@Department", siteSafetyAudit.Department, true);
            _database.AddParameter("@Question1", siteSafetyAudit.Question1, true);
            _database.AddParameter("@Question2", siteSafetyAudit.Question2, true);
            _database.AddParameter("@Question3", siteSafetyAudit.Question3, true);
            _database.AddParameter("@Question4", siteSafetyAudit.Question4, true);
            _database.AddParameter("@Question5", siteSafetyAudit.Question5, true);
            _database.AddParameter("@Question6", siteSafetyAudit.Question6, true);
            _database.AddParameter("@Question7", siteSafetyAudit.Question7, true);
            _database.AddParameter("@Question8", siteSafetyAudit.Question8, true);
            _database.AddParameter("@Question9", siteSafetyAudit.Question9, true);
            _database.AddParameter("@Question10", siteSafetyAudit.Question10, true);
            _database.AddParameter("@Question11", siteSafetyAudit.Question11, true);
            _database.AddParameter("@Result", siteSafetyAudit.Result);
            _database.AddParameter("@AuditorId", siteSafetyAudit.AuditorId);
        }

        public bool Delete(int id)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", id);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("EngineerSiteSafetyAudit_Delete") == 1);
        }
    }
}