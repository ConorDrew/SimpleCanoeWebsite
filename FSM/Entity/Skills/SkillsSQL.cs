// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Skills.SkillsSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Skills
{
  public class SkillsSQL
  {
    private Database _database;

    public SkillsSQL(Database database)
    {
      this._database = database;
    }

    public SkillType SkillType_Insert(SkillType oSkillType)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Name", (object) oSkillType.Name, false);
      this._database.AddParameter("@AddedBy", (object) App.loggedInUser.UserID, false);
      oSkillType.SetSkillTypeID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof (SkillType_Insert), true)));
      oSkillType.Exists = true;
      return oSkillType;
    }

    public bool SkillType_Update(SkillType oSkillType)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SkillTypeID", (object) oSkillType.SkillTypeID, false);
      this._database.AddParameter("@Name", (object) oSkillType.Name, false);
      return this._database.ExecuteSP_ReturnRowsAffected(nameof (SkillType_Update)) == 1;
    }

    public DataView SkillType_Get_BySkill(int skillId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SkillID", (object) skillId, false);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (SkillType_Get_BySkill), true));
    }

    public DataView SkillType_GetAll()
    {
      this._database.ClearParameter();
      return new DataView(this._database.ExecuteSP_DataTable(nameof (SkillType_GetAll), true));
    }

    public int SkillMatrix_Insert(int skillId, int skillTypeId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SkillTypeId", (object) skillTypeId, false);
      this._database.AddParameter("@SkillId", (object) skillId, false);
      return Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT(nameof (SkillMatrix_Insert), true)));
    }

    public DataView SkillMatrix_GetAll()
    {
      this._database.ClearParameter();
      return new DataView(this._database.ExecuteSP_DataTable(nameof (SkillMatrix_GetAll), true));
    }

    public DataView Skills_GetAllNotAssignedType()
    {
      this._database.ClearParameter();
      return new DataView(this._database.ExecuteSP_DataTable(nameof (Skills_GetAllNotAssignedType), true));
    }

    public DataView SkillMatrix_GetAll_ByType(int skillTypeId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SkillTypeId", (object) skillTypeId, false);
      return new DataView(this._database.ExecuteSP_DataTable(nameof (SkillMatrix_GetAll_ByType), true));
    }

    public bool SkillMatrix_Delete(int skillMatrixId)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SkillMatrixId", (object) skillMatrixId, false);
      return this._database.ExecuteSP_ReturnRowsAffected(nameof (SkillMatrix_Delete)) == 1;
    }
  }
}
