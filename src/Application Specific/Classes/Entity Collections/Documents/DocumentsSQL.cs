using System.Data;
using System.IO;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Documentss
    {
        public class DocumentsSQL
        {
            private Database _database;

            public DocumentsSQL(Database database)
            {
                _database = database;
            }

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public void Delete(int DocumentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@DocumentID", DocumentID, true);
                _database.ExecuteSP_NO_Return("Documents_Delete");
            }

            public Documents Documents_Get(int DocumentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@DocumentID", DocumentID);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Documents_Get");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oDocuments = new Documents();
                        oDocuments.IgnoreExceptionsOnSetMethods = true;
                        oDocuments.SetDocumentID = dt.Rows[0]["DocumentID"];
                        oDocuments.SetTableEnumID = dt.Rows[0]["TableEnumID"];
                        oDocuments.SetRecordID = dt.Rows[0]["RecordID"];
                        oDocuments.SetDocumentTypeID = dt.Rows[0]["DocumentTypeID"];
                        oDocuments.SetName = dt.Rows[0]["Name"];
                        oDocuments.SetNotes = dt.Rows[0]["Notes"];
                        oDocuments.SetLocation = dt.Rows[0]["Location"];
                        oDocuments.AddedOn = Conversions.ToDate(dt.Rows[0]["AddedOn"]);
                        oDocuments.SetAddedByUserID = dt.Rows[0]["AddedByUserID"];
                        oDocuments.LastUpdatedOn = Conversions.ToDate(dt.Rows[0]["LastUpdatedOn"]);
                        oDocuments.SetLastUpdatedByUserID = dt.Rows[0]["LastUpdatedByUserID"];
                        oDocuments.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oDocuments.Type = Helper.MakeStringValid(dt.Rows[0]["Type"]);
                        oDocuments.AddedByUserName = Conversions.ToString(dt.Rows[0]["AddedByUserName"]);
                        oDocuments.LastUpdatedByUserName = Conversions.ToString(dt.Rows[0]["LastUpdatedByUserName"]);
                        oDocuments.Exists = true;
                        return oDocuments;
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

            public DataView Documents_GetAll()
            {
                _database.ClearParameter();
                var dt = _database.ExecuteSP_DataTable("Documents_GetAll");
                dt.TableName = Enums.TableNames.tblDocuments.ToString();
                return new DataView(dt);
            }

            public DataView Documents_GetAll_For_Customer_ID(Enums.TableNames EntityToSearchBy, int RecordID)
            {
                _database.ClearParameter();
                _database.AddParameter("@TableEnumID", Conversions.ToInteger(EntityToSearchBy), true);
                _database.AddParameter("@RecordID", RecordID, true);
                _database.AddParameter("@SiteTableEnumID", Conversions.ToInteger(Enums.TableNames.tblSite), true);
                _database.AddParameter("@DomesticCustomerID", Enums.Customer.Domestic, true);
                var dt = _database.ExecuteSP_DataTable("Documents_GetAll_For_Customer_ID");
                dt.TableName = Enums.TableNames.tblDocuments.ToString();
                return new DataView(dt);
            }

            public DataView Documents_GetAll_For_Site_ID(Enums.TableNames EntityToSearchBy, int RecordID)
            {
                _database.ClearParameter();
                _database.AddParameter("@TableEnumID", Conversions.ToInteger(EntityToSearchBy), true);
                _database.AddParameter("@RecordID", RecordID, true);
                _database.AddParameter("@CustomerTableEnumID", Conversions.ToInteger(Enums.TableNames.tblCustomer), true);
                var dt = _database.ExecuteSP_DataTable("Documents_GetAll_For_Site_ID");
                dt.TableName = Enums.TableNames.tblDocuments.ToString();
                return new DataView(dt);
            }

            public DataView Documents_GetAll_For_Entity_ID(Enums.TableNames EntityToSearchBy, int RecordID)
            {
                _database.ClearParameter();
                _database.AddParameter("@TableEnumID", Conversions.ToInteger(EntityToSearchBy), true);
                _database.AddParameter("@RecordID", RecordID, true);
                var dt = _database.ExecuteSP_DataTable("Documents_GetAll_For_Entity_ID");
                dt.TableName = Enums.TableNames.tblDocuments.ToString();
                return new DataView(dt);
            }

            // Public Function [Insert](ByVal oDocuments As Documents) As Documents
            // _database.ClearParameter()
            // _database.AddParameter("@TableEnumID", oDocuments.TableEnumID, True)
            // _database.AddParameter("@RecordID", oDocuments.RecordID, True)
            // _database.AddParameter("@DocumentTypeID", oDocuments.DocumentTypeID, True)
            // _database.AddParameter("@Name", oDocuments.Name, True)
            // _database.AddParameter("@Notes", oDocuments.Notes, True)

            // Dim documentLocation As String = TheSystem.Configuration.DocumentsLocation & oDocuments.TableEnumID & "\"
            // If Not System.IO.Directory.Exists(documentLocation) Then
            // System.IO.Directory.CreateDirectory(documentLocation)
            // End If
            // documentLocation += oDocuments.RecordID & "\"
            // If Not System.IO.Directory.Exists(documentLocation) Then
            // System.IO.Directory.CreateDirectory(documentLocation)
            // End If
            // documentLocation += New System.IO.FileInfo(oDocuments.Location).Name

            // _database.AddParameter("@Location", documentLocation, True)
            // _database.AddParameter("@AddedByUserID", loggedInUser.UserID, True)

            // oDocuments.SetDocumentID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Documents_Insert"))
            // oDocuments.Exists = True

            // If System.IO.File.Exists(documentLocation) Then
            // System.IO.File.Delete(documentLocation)
            // End If
            // System.IO.File.Copy(oDocuments.Location, documentLocation)

            // Return oDocuments
            // End Function

            public Documents Insert(Documents oDocuments, bool buildLocationAndSave = true)
            {
                string folderTableDir = "";
                string folderFileDir = "";
                var switchExpr = oDocuments.TableEnumID;
                switch (switchExpr)
                {
                    case (int)Enums.TableNames.tblFleetVan:
                        {
                            folderTableDir = @"Fleet\";
                            var van = App.DB.FleetVan.Get(oDocuments.RecordID);
                            if (van is object)
                            {
                                folderFileDir = van.Registration + @"\";
                            }
                            else
                            {
                                folderFileDir = oDocuments.RecordID + @"\";
                            }

                            break;
                        }

                    default:
                        {
                            folderTableDir = oDocuments.TableEnumID + @"\";
                            folderFileDir = oDocuments.RecordID + @"\";
                            break;
                        }
                }

                _database.ClearParameter();
                _database.AddParameter("@TableEnumID", oDocuments.TableEnumID, true);
                _database.AddParameter("@RecordID", oDocuments.RecordID, true);
                _database.AddParameter("@DocumentTypeID", oDocuments.DocumentTypeID, true);
                _database.AddParameter("@Name", oDocuments.Name, true);
                _database.AddParameter("@Notes", oDocuments.Notes, true);
                string documentLocation = "";
                if (buildLocationAndSave)
                {
                    if (oDocuments.Location.Length > 0)
                    {
                        documentLocation = App.TheSystem.Configuration.DocumentsLocation + folderTableDir;
                        if (!Directory.Exists(documentLocation))
                        {
                            Directory.CreateDirectory(documentLocation);
                        }

                        documentLocation += folderFileDir;
                        if (!Directory.Exists(documentLocation))
                        {
                            Directory.CreateDirectory(documentLocation);
                        }

                        string location = Path.GetFileName(oDocuments.Location);
                        location = location.Replace(Path.GetFileNameWithoutExtension(location), Helper.RemoveSpecialCharacters(Path.GetFileNameWithoutExtension(location)));
                        documentLocation += location;
                    }
                    else
                    {
                        documentLocation = "";
                    }

                    _database.AddParameter("@Location", documentLocation, true);
                }
                else
                {
                    _database.AddParameter("@Location", oDocuments.Location, true);
                }

                _database.AddParameter("@AddedByUserID", App.loggedInUser.UserID, true);
                oDocuments.SetDocumentID = Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Documents_Insert"));
                oDocuments.Exists = true;
                if (buildLocationAndSave)
                {
                    if (documentLocation.Length > 0)
                    {
                        if (File.Exists(documentLocation))
                        {
                            File.Delete(documentLocation);
                        }

                        File.Copy(oDocuments.Location, documentLocation);
                    }
                }

                return oDocuments;
            }

            public DataView Documents_Search(string criteria)
            {
                _database.ClearParameter();
                _database.AddParameter("@Criteria", criteria, true);
                var dt = _database.ExecuteSP_DataTable("Documents_Search");
                dt.TableName = Enums.TableNames.tblDocuments.ToString();
                return new DataView(dt);
            }

            public void Update(Documents oDocuments)
            {
                _database.ClearParameter();
                _database.AddParameter("@DocumentID", oDocuments.DocumentID, true);
                _database.AddParameter("@DocumentTypeID", oDocuments.DocumentTypeID, true);
                _database.AddParameter("@Name", oDocuments.Name, true);
                _database.AddParameter("@Notes", oDocuments.Notes, true);
                _database.AddParameter("@LastUpdatedByUserID", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("Documents_Update");
            }

            public void Opened(int documentID)
            {
                _database.ClearParameter();
                _database.AddParameter("@DocumentID", documentID, true);
                _database.AddParameter("@LastUpdatedByUserID", App.loggedInUser.UserID, true);
                _database.ExecuteSP_NO_Return("Documents_Opened");
            }

            public Documents Documents_Get_ByFilePath(string Location)
            {
                _database.ClearParameter();
                _database.AddParameter("@Location", Location);

                // Get the datatable from the database store in dt
                var dt = _database.ExecuteSP_DataTable("Documents_Get_ByFilePath");
                if (dt is object)
                {
                    if (dt.Rows.Count > 0)
                    {
                        var oDocuments = new Documents();
                        oDocuments.IgnoreExceptionsOnSetMethods = true;
                        oDocuments.SetDocumentID = dt.Rows[0]["DocumentID"];
                        oDocuments.SetTableEnumID = dt.Rows[0]["TableEnumID"];
                        oDocuments.SetRecordID = dt.Rows[0]["RecordID"];
                        oDocuments.SetDocumentTypeID = dt.Rows[0]["DocumentTypeID"];
                        oDocuments.SetName = dt.Rows[0]["Name"];
                        oDocuments.SetNotes = dt.Rows[0]["Notes"];
                        oDocuments.SetLocation = dt.Rows[0]["Location"];
                        oDocuments.AddedOn = Conversions.ToDate(dt.Rows[0]["AddedOn"]);
                        oDocuments.SetAddedByUserID = dt.Rows[0]["AddedByUserID"];
                        oDocuments.LastUpdatedOn = Conversions.ToDate(dt.Rows[0]["LastUpdatedOn"]);
                        oDocuments.SetLastUpdatedByUserID = dt.Rows[0]["LastUpdatedByUserID"];
                        oDocuments.SetDeleted = Conversions.ToBoolean(dt.Rows[0]["Deleted"]);
                        oDocuments.Type = Conversions.ToString(dt.Rows[0]["Type"]);
                        oDocuments.AddedByUserName = Conversions.ToString(dt.Rows[0]["AddedByUserName"]);
                        oDocuments.LastUpdatedByUserName = Conversions.ToString(dt.Rows[0]["LastUpdatedByUserName"]);
                        oDocuments.Exists = true;
                        return oDocuments;
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

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}