using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity.Skills
{
    public class SkillsSQL
    {
        private Sys.Database _database;

        public SkillsSQL(Sys.Database database)
        {
            _database = database;
        }

        public SkillType SkillType_Insert(SkillType oSkillType)
        {
            _database.ClearParameter();
            _database.AddParameter("@Name", oSkillType.Name);
            _database.AddParameter("@AddedBy", App.loggedInUser.UserID);
            oSkillType.SetSkillTypeID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SkillType_Insert"));
            oSkillType.Exists = true;
            return oSkillType;
        }

        public bool SkillType_Update(SkillType oSkillType)
        {
            _database.ClearParameter();
            _database.AddParameter("@SkillTypeID", oSkillType.SkillTypeID);
            _database.AddParameter("@Name", oSkillType.Name);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("SkillType_Update") == 1);
        }

        public DataView SkillType_Get_BySkill(int skillId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SkillID", skillId);
            return new DataView(_database.ExecuteSP_DataTable("SkillType_Get_BySkill"));
        }

        public DataView SkillType_GetAll()
        {
            _database.ClearParameter();
            return new DataView(_database.ExecuteSP_DataTable("SkillType_GetAll"));
        }

        public int SkillMatrix_Insert(int skillId, int skillTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SkillTypeId", skillTypeId);
            _database.AddParameter("@SkillId", skillId);
            return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SkillMatrix_Insert"));
        }

        public DataView SkillMatrix_GetAll()
        {
            _database.ClearParameter();
            return new DataView(_database.ExecuteSP_DataTable("SkillMatrix_GetAll"));
        }

        public DataView Skills_GetAllNotAssignedType()
        {
            _database.ClearParameter();
            return new DataView(_database.ExecuteSP_DataTable("Skills_GetAllNotAssignedType"));
        }

        public DataView SkillMatrix_GetAll_ByType(int skillTypeId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SkillTypeId", skillTypeId);
            return new DataView(_database.ExecuteSP_DataTable("SkillMatrix_GetAll_ByType"));
        }

        public bool SkillMatrix_Delete(int skillMatrixId)
        {
            _database.ClearParameter();
            _database.AddParameter("@SkillMatrixId", skillMatrixId);
            return Conversions.ToBoolean(_database.ExecuteSP_ReturnRowsAffected("SkillMatrix_Delete") == 1);
        }
    }
}