using System;
using System.Collections.Generic;
using System.Data;
using FSM.Entity.CostCentres.Enums;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.CostCentres
{
    public class CostCentreSql
    {
        private Database _database;

        public CostCentreSql(Database database)
        {
            _database = database;
        }

        public DataView GetAll()
        {
            _database.ClearParameter();
            return new DataView(_database.ExecuteSP_DataTable("CostCentre_GetAll"));
        }

        public List<CostCentre> Get(int @ref, int ref2, GetBy getBy)
        {
            _database.ClearParameter();

            // Get the datatable from the database store in dt
            DataTable dt = null;
            switch (getBy)
            {
                case GetBy.Id:
                    {
                        _database.AddParameter("@Id", @ref, true);
                        dt = _database.ExecuteSP_DataTable("CostCentre_Get_ById");
                        break;
                    }

                case GetBy.JobId:
                    {
                        _database.AddParameter("@JobID", @ref, true);
                        dt = _database.ExecuteSP_DataTable("CostCentre_Get_ByJobId");
                        break;
                    }

                case GetBy.JobTypeId:
                    {
                        _database.AddParameter("@JobTypeId", @ref, true);
                        dt = _database.ExecuteSP_DataTable("CostCentre_Get_ByJobTypeId");
                        break;
                    }

                case GetBy.JobTypeIdAndCutomerId:
                    {
                        _database.AddParameter("@JobTypeId", @ref, true);
                        _database.AddParameter("@CustomerId", ref2, true);
                        dt = _database.ExecuteSP_DataTable("CostCentre_Get_ByJobTypeIdAndCustomerId");
                        break;
                    }

                default:
                    {
                        _database.AddParameter("@Id", @ref, true);
                        dt = _database.ExecuteSP_DataTable("CostCentre_Get_ById");
                        break;
                    }
            }

            if (dt is object && dt.Rows.Count > 0)
            {
                var costCentres = ObjectMap.DataTableToList<CostCentre>(dt);
                return costCentres;
            }
            else
            {
                return null;
            }
        }

        public CostCentre Insert(CostCentre ccm)
        {
            AddParameters(ccm);
            ccm.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CostCentre_Insert"));
            return ccm;
        }

        private void AddParameters(CostCentre ccm)
        {
            _database.ClearParameter();
            _database.AddParameter("@CostCentre", ccm.CostCentreId);
            _database.AddParameter("@JobTypeId", ccm.JobTypeId);
            _database.AddParameter("@LinkId", ccm.LinkId);
            _database.AddParameter("@LinkTypeId", ccm.LinkTypeId);
            var spendLimit = ccm.JobSpendLimit > 0 ? (object)ccm.JobSpendLimit : DBNull.Value;
            _database.AddParameter("@JobSpendLimit", spendLimit, true);
        }

        public CostCentre Update(CostCentre ccm)
        {
            AddParameters(ccm);
            _database.AddParameter("@Id", ccm.Id);
            ccm.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CostCentre_Update"));
            return ccm;
        }

        public bool Delete(int Id)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", Id);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("CostCentre_Delete") == 1);
        }
    }
}