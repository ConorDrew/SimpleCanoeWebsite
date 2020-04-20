using System.Data;
using System.Linq;
using FSM.Entity.EngineerVisits.EngineerVisitEngineers.Enums;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.EngineerVisits.EngineerVisitEngineers
{
    public class EngineerVisitEngineerSql
    {
        private Database _database;

        public EngineerVisitEngineerSql(Database database)
        {
            _database = database;
        }

        public EngineerVisitEngineer Get(object key, GetBy getBy)
        {
            _database.ClearParameter();
            DataTable dt = null;
            switch (getBy)
            {
                case GetBy.Id:
                    {
                        _database.AddParameter("@Id", Helper.MakeIntegerValid(key), true);
                        dt = _database.ExecuteSP_DataTable("EngineerVisitEngineer_Get");
                        break;
                    }

                case GetBy.EngineerVisitId:
                    {
                        _database.AddParameter("@EngineerVisitId", Helper.MakeIntegerValid(key), true);
                        dt = _database.ExecuteSP_DataTable("EngineerVisitEngineer_Get_ByEngineerVisitId");
                        break;
                    }

                default:
                    {
                        return null;
                    }
            }

            if (dt is object && dt.Rows.Count > 0)
            {
                var engineerVisitEngineer = ObjectMap.DataTableToList<EngineerVisitEngineer>(dt);
                return engineerVisitEngineer?.First();
            }
            else
            {
                return null;
            }
        }

        public EngineerVisitEngineer Insert(EngineerVisitEngineer eve)
        {
            _database.ClearParameter();
            _database.AddParameter("@EngineerVisitId", eve.EngineerVisitId);
            _database.AddParameter("@EngineerId", eve.EngineerId);
            _database.AddParameter("@Department", eve.Department);
            _database.AddParameter("@OftecNo", eve.OftecNo);
            _database.AddParameter("@GasSafeNo", eve.GasSafeNo);
            _database.AddParameter("@ManagerID", eve.ManagerId);
            _database.AddParameter("@CostToCompany", eve.CostToCompany);
            eve.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitEngineer_Insert"));
            return eve;
        }

        public bool Delete(object key, DeleteBy deleteBy)
        {
            _database.ClearParameter();
            string spName = string.Empty;
            switch (deleteBy)
            {
                case DeleteBy.Id:
                    {
                        _database.AddParameter("@Id", Helper.MakeIntegerValid(key), true);
                        spName = "EngineerVisitEngineer_Delete";
                        break;
                    }

                case DeleteBy.EngineerVisitId:
                    {
                        _database.AddParameter("@EngineerVisitId", Helper.MakeIntegerValid(key), true);
                        spName = "EngineerVisitEngineer_Delete_ByEngineerVisitId";
                        break;
                    }

                default:
                    {
                        return default;
                    }
            }

            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected(spName) == 1);
        }
    }
}