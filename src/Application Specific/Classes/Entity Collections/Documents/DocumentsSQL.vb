Imports System.IO
Imports FSM.Entity.Sys

Namespace Entity

    Namespace Documentss

        Public Class DocumentsSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal DocumentID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@DocumentID", DocumentID, True)
                _database.ExecuteSP_NO_Return("Documents_Delete")
            End Sub

            Public Function [Documents_Get](ByVal DocumentID As Integer) As Documents
                _database.ClearParameter()
                _database.AddParameter("@DocumentID", DocumentID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Documents_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oDocuments As New Documents
                        With oDocuments
                            .IgnoreExceptionsOnSetMethods = True
                            .SetDocumentID = dt.Rows(0).Item("DocumentID")
                            .SetTableEnumID = dt.Rows(0).Item("TableEnumID")
                            .SetRecordID = dt.Rows(0).Item("RecordID")
                            .SetDocumentTypeID = dt.Rows(0).Item("DocumentTypeID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetLocation = dt.Rows(0).Item("Location")
                            .AddedOn = CDate(dt.Rows(0).Item("AddedOn"))
                            .SetAddedByUserID = dt.Rows(0).Item("AddedByUserID")
                            .LastUpdatedOn = CDate(dt.Rows(0).Item("LastUpdatedOn"))
                            .SetLastUpdatedByUserID = dt.Rows(0).Item("LastUpdatedByUserID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .Type = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Type"))
                            .AddedByUserName = dt.Rows(0).Item("AddedByUserName")
                            .LastUpdatedByUserName = dt.Rows(0).Item("LastUpdatedByUserName")
                        End With
                        oDocuments.Exists = True
                        Return oDocuments
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Documents_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Documents_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString
                Return New DataView(dt)
            End Function

            Public Function [Documents_GetAll_For_Customer_ID](ByVal EntityToSearchBy As Entity.Sys.Enums.TableNames, ByVal RecordID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@TableEnumID", CInt(EntityToSearchBy), True)
                _database.AddParameter("@RecordID", RecordID, True)
                _database.AddParameter("@SiteTableEnumID", CInt(Entity.Sys.Enums.TableNames.tblSite), True)
                _database.AddParameter("@DomesticCustomerID", Entity.Sys.Enums.Customer.Domestic, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Documents_GetAll_For_Customer_ID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString
                Return New DataView(dt)
            End Function

            Public Function [Documents_GetAll_For_Site_ID](ByVal EntityToSearchBy As Entity.Sys.Enums.TableNames, ByVal RecordID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@TableEnumID", CInt(EntityToSearchBy), True)
                _database.AddParameter("@RecordID", RecordID, True)
                _database.AddParameter("@CustomerTableEnumID", CInt(Entity.Sys.Enums.TableNames.tblCustomer), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Documents_GetAll_For_Site_ID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString
                Return New DataView(dt)
            End Function

            Public Function [Documents_GetAll_For_Entity_ID](ByVal EntityToSearchBy As Entity.Sys.Enums.TableNames, ByVal RecordID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@TableEnumID", CInt(EntityToSearchBy), True)
                _database.AddParameter("@RecordID", RecordID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Documents_GetAll_For_Entity_ID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString
                Return New DataView(dt)
            End Function

            'Public Function [Insert](ByVal oDocuments As Documents) As Documents
            '    _database.ClearParameter()
            '    _database.AddParameter("@TableEnumID", oDocuments.TableEnumID, True)
            '    _database.AddParameter("@RecordID", oDocuments.RecordID, True)
            '    _database.AddParameter("@DocumentTypeID", oDocuments.DocumentTypeID, True)
            '    _database.AddParameter("@Name", oDocuments.Name, True)
            '    _database.AddParameter("@Notes", oDocuments.Notes, True)

            '    Dim documentLocation As String = TheSystem.Configuration.DocumentsLocation & oDocuments.TableEnumID & "\"
            '    If Not System.IO.Directory.Exists(documentLocation) Then
            '        System.IO.Directory.CreateDirectory(documentLocation)
            '    End If
            '    documentLocation += oDocuments.RecordID & "\"
            '    If Not System.IO.Directory.Exists(documentLocation) Then
            '        System.IO.Directory.CreateDirectory(documentLocation)
            '    End If
            '    documentLocation += New System.IO.FileInfo(oDocuments.Location).Name

            '    _database.AddParameter("@Location", documentLocation, True)
            '    _database.AddParameter("@AddedByUserID", loggedInUser.UserID, True)

            '    oDocuments.SetDocumentID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Documents_Insert"))
            '    oDocuments.Exists = True

            '    If System.IO.File.Exists(documentLocation) Then
            '        System.IO.File.Delete(documentLocation)
            '    End If
            '    System.IO.File.Copy(oDocuments.Location, documentLocation)

            '    Return oDocuments
            'End Function

            Public Function [Insert](ByVal oDocuments As Documents, Optional ByVal buildLocationAndSave As Boolean = True) As Documents
                Dim folderTableDir As String = ""
                Dim folderFileDir As String = ""

                Select Case oDocuments.TableEnumID
                    Case Entity.Sys.Enums.TableNames.tblFleetVan
                        folderTableDir = "Fleet\"
                        Dim van As Entity.FleetVans.FleetVan = DB.FleetVan.Get(oDocuments.RecordID)
                        If van IsNot Nothing Then
                            folderFileDir = van.Registration & "\"
                        Else
                            folderFileDir = oDocuments.RecordID & "\"
                        End If
                    Case Else
                        folderTableDir = oDocuments.TableEnumID & "\"
                        folderFileDir = oDocuments.RecordID & "\"
                End Select

                _database.ClearParameter()
                _database.AddParameter("@TableEnumID", oDocuments.TableEnumID, True)
                _database.AddParameter("@RecordID", oDocuments.RecordID, True)
                _database.AddParameter("@DocumentTypeID", oDocuments.DocumentTypeID, True)
                _database.AddParameter("@Name", oDocuments.Name, True)
                _database.AddParameter("@Notes", oDocuments.Notes, True)

                Dim documentLocation As String = ""

                If buildLocationAndSave Then

                    If oDocuments.Location.Length > 0 Then

                        documentLocation = TheSystem.Configuration.DocumentsLocation & folderTableDir
                        If Not System.IO.Directory.Exists(documentLocation) Then
                            System.IO.Directory.CreateDirectory(documentLocation)
                        End If

                        documentLocation += folderFileDir
                        If Not System.IO.Directory.Exists(documentLocation) Then
                            System.IO.Directory.CreateDirectory(documentLocation)
                        End If

                        Dim location As String = Path.GetFileName(oDocuments.Location)
                        location = location.Replace(Path.GetFileNameWithoutExtension(location), Helper.RemoveSpecialCharacters(Path.GetFileNameWithoutExtension(location)))
                        documentLocation += location
                    Else
                        documentLocation = ""
                    End If

                    _database.AddParameter("@Location", documentLocation, True)
                Else
                    _database.AddParameter("@Location", oDocuments.Location, True)
                End If

                _database.AddParameter("@AddedByUserID", loggedInUser.UserID, True)

                oDocuments.SetDocumentID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Documents_Insert"))
                oDocuments.Exists = True

                If buildLocationAndSave Then
                    If documentLocation.Length > 0 Then
                        If System.IO.File.Exists(documentLocation) Then
                            System.IO.File.Delete(documentLocation)
                        End If
                        System.IO.File.Copy(oDocuments.Location, documentLocation)
                    End If
                End If

                Return oDocuments
            End Function

            Public Function [Documents_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Documents_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblDocuments.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oDocuments As Documents)
                _database.ClearParameter()
                _database.AddParameter("@DocumentID", oDocuments.DocumentID, True)
                _database.AddParameter("@DocumentTypeID", oDocuments.DocumentTypeID, True)
                _database.AddParameter("@Name", oDocuments.Name, True)
                _database.AddParameter("@Notes", oDocuments.Notes, True)
                _database.AddParameter("@LastUpdatedByUserID", loggedInUser.UserID, True)

                _database.ExecuteSP_NO_Return("Documents_Update")
            End Sub

            Public Sub [Opened](ByVal documentID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@DocumentID", documentID, True)
                _database.AddParameter("@LastUpdatedByUserID", loggedInUser.UserID, True)

                _database.ExecuteSP_NO_Return("Documents_Opened")
            End Sub

            Public Function [Documents_Get_ByFilePath](ByVal Location As String) As Documents
                _database.ClearParameter()
                _database.AddParameter("@Location", Location)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Documents_Get_ByFilePath")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oDocuments As New Documents
                        With oDocuments
                            .IgnoreExceptionsOnSetMethods = True
                            .SetDocumentID = dt.Rows(0).Item("DocumentID")
                            .SetTableEnumID = dt.Rows(0).Item("TableEnumID")
                            .SetRecordID = dt.Rows(0).Item("RecordID")
                            .SetDocumentTypeID = dt.Rows(0).Item("DocumentTypeID")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetLocation = dt.Rows(0).Item("Location")
                            .AddedOn = CDate(dt.Rows(0).Item("AddedOn"))
                            .SetAddedByUserID = dt.Rows(0).Item("AddedByUserID")
                            .LastUpdatedOn = CDate(dt.Rows(0).Item("LastUpdatedOn"))
                            .SetLastUpdatedByUserID = dt.Rows(0).Item("LastUpdatedByUserID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .Type = dt.Rows(0).Item("Type")
                            .AddedByUserName = dt.Rows(0).Item("AddedByUserName")
                            .LastUpdatedByUserName = dt.Rows(0).Item("LastUpdatedByUserName")
                        End With
                        oDocuments.Exists = True
                        Return oDocuments
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

#End Region

        End Class

    End Namespace

End Namespace