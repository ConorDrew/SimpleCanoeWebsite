// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sections.SectionSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Sections
{
  public class SectionSQL
  {
    private Database _database;

    public SectionSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int SectionID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SectionID", (object) SectionID, true);
      this._database.ExecuteSP_NO_Return("Section_Delete", true);
    }

    public Section Section_Get(int SectionID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SectionID", (object) SectionID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (Section_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (Section) null;
      Section section1 = new Section();
      Section section2 = section1;
      section2.IgnoreExceptionsOnSetMethods = true;
      section2.SetSectionID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (SectionID)]);
      section2.SetDescription = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Description"]);
      section2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      section1.Exists = true;
      return section1;
    }

    public DataView Section_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (Section_GetAll), true);
      table.TableName = Enums.TableNames.tblSection.ToString();
      return new DataView(table);
    }

    public Section Insert(Section oSection)
    {
      this._database.ClearParameter();
      this.AddSectionParametersToCommand(ref oSection);
      oSection.SetSectionID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("Section_Insert", true)));
      oSection.Exists = true;
      return oSection;
    }

    public void Update(Section oSection)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@SectionID", (object) oSection.SectionID, true);
      this.AddSectionParametersToCommand(ref oSection);
      this._database.ExecuteSP_NO_Return("Section_Update", true);
    }

    private void AddSectionParametersToCommand(ref Section oSection)
    {
      this._database.AddParameter("@Description", (object) oSection.Description, true);
    }
  }
}
