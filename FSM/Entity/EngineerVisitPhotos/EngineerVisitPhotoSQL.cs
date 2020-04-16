// Decompiled with JetBrains decompiler
// Type: FSM.Entity.EngineerVisitPhotos.EngineerVisitPhotoSQL
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using System.Runtime.CompilerServices;

namespace FSM.Entity.EngineerVisitPhotos
{
  public class EngineerVisitPhotoSQL
  {
    private Database _database;

    public EngineerVisitPhotoSQL(Database database)
    {
      this._database = database;
    }

    public void Delete(int EngineerVisitPhotoID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitPhotoID", (object) EngineerVisitPhotoID, true);
      this._database.ExecuteSP_NO_Return("EngineerVisitPhoto_Delete", true);
    }

    public EngineerVisitPhoto EngineerVisitPhoto_Get(int EngineerVisitPhotoID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitPhotoID", (object) EngineerVisitPhotoID, false);
      DataTable dataTable = this._database.ExecuteSP_DataTable(nameof (EngineerVisitPhoto_Get), true);
      if (dataTable == null || dataTable.Rows.Count <= 0)
        return (EngineerVisitPhoto) null;
      EngineerVisitPhoto engineerVisitPhoto1 = new EngineerVisitPhoto();
      EngineerVisitPhoto engineerVisitPhoto2 = engineerVisitPhoto1;
      engineerVisitPhoto2.IgnoreExceptionsOnSetMethods = true;
      engineerVisitPhoto2.SetEngineerVisitPhotoID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0][nameof (EngineerVisitPhotoID)]);
      engineerVisitPhoto2.SetEngineerVisitID = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["EngineerVisitID"]);
      engineerVisitPhoto2.SetPhoto = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Photo"]);
      engineerVisitPhoto2.SetCaption = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Caption"]);
      engineerVisitPhoto2.SetDeleted = Conversions.ToBoolean(dataTable.Rows[0]["Deleted"]);
      engineerVisitPhoto1.Exists = true;
      return engineerVisitPhoto1;
    }

    public DataView EngineerVisitPhoto_GetForVisit(int EngineerVisitID)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitID", (object) EngineerVisitID, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitPhoto_GetForVisit), true);
      table.TableName = Enums.TableNames.tblEngineerVisitPhoto.ToString();
      return new DataView(table);
    }

    public DataView EngineerVisitPhoto_GetAll()
    {
      this._database.ClearParameter();
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitPhoto_GetAll), true);
      table.TableName = Enums.TableNames.tblEngineerVisitPhoto.ToString();
      return new DataView(table);
    }

    public EngineerVisitPhoto Insert(EngineerVisitPhoto oEngineerVisitPhoto)
    {
      this._database.ClearParameter();
      this.AddEngineerVisitPhotoParametersToCommand(ref oEngineerVisitPhoto);
      oEngineerVisitPhoto.SetEngineerVisitPhotoID = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this._database.ExecuteSP_OBJECT("EngineerVisitPhoto_Insert", true)));
      oEngineerVisitPhoto.Exists = true;
      return oEngineerVisitPhoto;
    }

    public DataView EngineerVisitPhoto_Search(string criteria)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@Criteria", (object) criteria, true);
      DataTable table = this._database.ExecuteSP_DataTable(nameof (EngineerVisitPhoto_Search), true);
      table.TableName = Enums.TableNames.tblEngineerVisitPhoto.ToString();
      return new DataView(table);
    }

    public void Update(EngineerVisitPhoto oEngineerVisitPhoto)
    {
      this._database.ClearParameter();
      this._database.AddParameter("@EngineerVisitPhotoID", (object) oEngineerVisitPhoto.EngineerVisitPhotoID, true);
      this.AddEngineerVisitPhotoParametersToCommand(ref oEngineerVisitPhoto);
      this._database.ExecuteSP_NO_Return("EngineerVisitPhoto_Update", true);
    }

    private void AddEngineerVisitPhotoParametersToCommand(ref EngineerVisitPhoto oEngineerVisitPhoto)
    {
      Database database = this._database;
      database.AddParameter("@EngineerVisitID", (object) oEngineerVisitPhoto.EngineerVisitID, true);
      database.AddParameter("@Photo", (object) oEngineerVisitPhoto.Photo, true);
      database.AddParameter("@Caption", (object) oEngineerVisitPhoto.Caption, true);
    }
  }
}
