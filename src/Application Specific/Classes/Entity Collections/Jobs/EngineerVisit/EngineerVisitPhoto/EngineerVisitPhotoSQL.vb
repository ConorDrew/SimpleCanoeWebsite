Imports System.Data.SqlClient

Namespace Entity

Namespace EngineerVisitPhotos

Public Class EngineerVisitPhotoSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Sub Delete(ByVal EngineerVisitPhotoID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitPhotoID", EngineerVisitPhotoID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitPhoto_Delete")
            End Sub

            Public Function [EngineerVisitPhoto_Get](ByVal EngineerVisitPhotoID As Integer) As EngineerVisitPhoto
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitPhotoID", EngineerVisitPhotoID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPhoto_Get")

                If Not dt Is Nothing Then
                    If dt.rows.count > 0 Then
                        Dim oEngineerVisitPhoto As New EngineerVisitPhoto
                        With oEngineerVisitPhoto
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerVisitPhotoID = dt.Rows(0).Item("EngineerVisitPhotoID")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")
                            .SetPhoto = dt.Rows(0).Item("Photo")
                            .SetCaption = dt.Rows(0).Item("Caption")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oEngineerVisitPhoto.Exists = True
                        Return oEngineerVisitPhoto
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function EngineerVisitPhoto_GetForVisit(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()

                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPhoto_GetForVisit")

                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitPhoto.ToString
                Return New DataView(dt)
            End Function

            Public Function [EngineerVisitPhoto_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPhoto_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitPhoto.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oEngineerVisitPhoto As EngineerVisitPhoto) As EngineerVisitPhoto
                _database.ClearParameter()
                AddEngineerVisitPhotoParametersToCommand(oEngineerVisitPhoto)

                oEngineerVisitPhoto.SetEngineerVisitPhotoID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitPhoto_Insert"))
                oEngineerVisitPhoto.Exists = True
                Return oEngineerVisitPhoto
            End Function

            Public Function [EngineerVisitPhoto_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPhoto_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitPhoto.ToString
                Return New DataView(dt)
            End Function


            Public Sub [Update](ByVal oEngineerVisitPhoto As EngineerVisitPhoto)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitPhotoID", oEngineerVisitPhoto.EngineerVisitPhotoID, True)
                AddEngineerVisitPhotoParametersToCommand(oEngineerVisitPhoto)
                _database.ExecuteSP_NO_Return("EngineerVisitPhoto_Update")
            End Sub



            Private Sub AddEngineerVisitPhotoParametersToCommand(ByRef oEngineerVisitPhoto As EngineerVisitPhoto)
                With _database
                    .AddParameter("@EngineerVisitID", oEngineerVisitPhoto.EngineerVisitID, True)
                    .AddParameter("@Photo", oEngineerVisitPhoto.Photo, True)
                    .AddParameter("@Caption", oEngineerVisitPhoto.Caption, True)



                End With
            End Sub


#End Region

End Class

End Namespace

End Namespace


