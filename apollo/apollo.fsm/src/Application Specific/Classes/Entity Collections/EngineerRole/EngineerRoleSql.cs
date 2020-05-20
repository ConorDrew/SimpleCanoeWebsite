using System.Collections.Generic;
using System.Data;

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.EngineerRoles
{
    public class EngineerRoleSql
    {
        private Database _database;

        public EngineerRoleSql(Database database)
        {
            _database = database;
        }

        public List<EngineerRole> GetAll()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("EngineerRole_GetAll");
            if (dt is object && dt.Rows.Count > 0)
            {
                var engineerRoles = ObjectMap.DataTableToList<EngineerRole>(dt);
                return engineerRoles;
            }
            else
            {
                return null;
            }
        }

        public List<EngineerAssignedToRole> GetEngineersAssignedToRole()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("EngineerRole_GetEngineersAssignedToRole");
            if (dt is object && dt.Rows.Count > 0)
            {
                var engineerToRoleList = ObjectMap.DataTableToList<EngineerAssignedToRole>(dt);
                return engineerToRoleList;
            }
            else
            {
                return null;
            }
        }

        public DataView GetLookupData()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("EngineerRole_GetAll");
            dt.TableName = Enums.TableNames.tblEngineerRole.ToString();
            return new DataView(dt);
        }

        public DataView GetEngineersNotAssignedToRole()
        {
            _database.ClearParameter();
            var dt = _database.ExecuteSP_DataTable("EngineerRole_GetEngineersNotAssignedToRole");
            dt.TableName = Enums.TableNames.tblEngineerRole.ToString();
            return new DataView(dt);
        }

        public EngineerRole Insert(EngineerRole engineerRole)
        {
            _database.ClearParameter();
            _database.AddParameter("@Name", engineerRole.Name);
            _database.AddParameter("@Description", engineerRole.Description);
            _database.AddParameter("@HourlyCostToCompany", engineerRole.HourlyCostToCompany);
            engineerRole.Id = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerRole_Insert"));
            return engineerRole;
        }

        public int Update(EngineerRole engineerRole)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", engineerRole.Id, true);
            _database.AddParameter("@Name", engineerRole.Name);
            _database.AddParameter("@Description", engineerRole.Description);
            _database.AddParameter("@HourlyCostToCompany", engineerRole.HourlyCostToCompany);
            return Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerRole_Update"));
        }

        public int Delete(int Id)
        {
            _database.ClearParameter();
            _database.AddParameter("@Id", Id);
            return Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerRole_Delete"));
        }

        public bool AssignEngineerToRole(int engineerId, int engineerRoleId)
        {
            _database.ClearParameter();
            _database.AddParameter("@EngineerID", engineerId);
            _database.AddParameter("@EngineerRoleId", engineerRoleId);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("EngineerRole_AssignEngineer") == 1);
        }

        public EngineerRole GetEngineerRoleId(int engineerId)
        {
            var engineerRole = new EngineerRole();
            engineerRole.Id = -1;
            _database.ClearParameter();
            _database.AddParameter("@EngineerID", engineerId);
            var dt = _database.ExecuteSP_DataTable("EngineerRole_GetEngineerRoleId");
            if (!Information.IsNothing(dt) & dt.Rows.Count > 0)
            {
                engineerRole.Id = Conversions.ToInteger(dt.Rows[0]["EngineerRoleId"]);
                engineerRole.Name = Conversions.ToString(dt.Rows[0]["Name"]);
            }

            return engineerRole;
        }
    }
}