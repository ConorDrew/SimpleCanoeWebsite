using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace EngineerVisitPhotos
    {
        public class EngineerVisitPhotoSQL
        {
            private Sys.Database _database;

            public EngineerVisitPhotoSQL(Sys.Database database)
            {
                _database = database;
            }

            public void Delete(int EngineerVisitPhotoID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitPhotoID", EngineerVisitPhotoID, true);
                _database.ExecuteSP_NO_Return("EngineerVisitPhoto_Delete");
            }

            public EngineerVisitPhoto EngineerVisitPhoto_Get(int EngineerVisitPhotoID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitPhotoID", EngineerVisitPhotoID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPhoto_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oEngineerVisitPhoto = new EngineerVisitPhoto();
                        oEngineerVisitPhoto.IgnoreExceptionsOnSetMethods = true;
                        oEngineerVisitPhoto.SetEngineerVisitPhotoID = dt.Rows[0]["EngineerVisitPhotoID"];
                        oEngineerVisitPhoto.SetEngineerVisitID = dt.Rows[0]["EngineerVisitID"];
                        oEngineerVisitPhoto.SetPhoto = dt.Rows[0]["Photo"];
                        oEngineerVisitPhoto.SetCaption = dt.Rows[0]["Caption"];
                        oEngineerVisitPhoto.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oEngineerVisitPhoto.Exists = true;
                        return oEngineerVisitPhoto;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            public DataView EngineerVisitPhoto_GetForVisit(int EngineerVisitID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, true);
                var dt = _database.ExecuteSP_DataTable("EngineerVisitPhoto_GetForVisit");
                dt.TableName = Sys.Enums.TableNames.tblEngineerVisitPhoto.ToString();
                return new DataView(dt);
            }

            public EngineerVisitPhoto Insert(EngineerVisitPhoto oEngineerVisitPhoto)
            {
                _database.ClearParameter();
                AddEngineerVisitPhotoParametersToCommand(ref oEngineerVisitPhoto);
                oEngineerVisitPhoto.SetEngineerVisitPhotoID = Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitPhoto_Insert"));
                oEngineerVisitPhoto.Exists = true;
                return oEngineerVisitPhoto;
            }

            public void Update(EngineerVisitPhoto oEngineerVisitPhoto)
            {
                _database.ClearParameter();
                _database.AddParameter("@EngineerVisitPhotoID", oEngineerVisitPhoto.EngineerVisitPhotoID, true);
                AddEngineerVisitPhotoParametersToCommand(ref oEngineerVisitPhoto);
                _database.ExecuteSP_NO_Return("EngineerVisitPhoto_Update");
            }

            private void AddEngineerVisitPhotoParametersToCommand(ref EngineerVisitPhoto oEngineerVisitPhoto)
            {
                {
                    var withBlock = _database;
                    withBlock.AddParameter("@EngineerVisitID", oEngineerVisitPhoto.EngineerVisitID, true);
                    withBlock.AddParameter("@Photo", oEngineerVisitPhoto.Photo, true);
                    withBlock.AddParameter("@Caption", oEngineerVisitPhoto.Caption, true);
                }
            }
        }
    }
}