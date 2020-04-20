Imports System.Data.SqlClient

Namespace Entity

Namespace EngineerVisitDefectss

Public Class EngineerVisitDefectsSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal EngineerVisitDefectID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@EngineerVisitDefectID", EngineerVisitDefectID, True)
            _database.ExecuteSP_NO_Return("EngineerVisitDefects_Delete")
    End Sub

    Public Function [EngineerVisitDefects_Get](ByVal EngineerVisitDefectID As Integer) As EngineerVisitDefects
        _database.ClearParameter()
        _database.AddParameter("@EngineerVisitDefectID", EngineerVisitDefectID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitDefects_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oEngineerVisitDefects As New EngineerVisitDefects
				With oEngineerVisitDefects
				    .IgnoreExceptionsOnSetMethods = True
						.SetEngineerVisitDefectID= dt.Rows(0).Item("EngineerVisitDefectID")
				.SetCategoryID= dt.Rows(0).Item("CategoryID")
				.SetReason= dt.Rows(0).Item("Reason")
				.SetActionTaken= dt.Rows(0).Item("ActionTaken")
				.SetWarningNoticeIssued= dt.Rows(0).Item("WarningNoticeIssued")
				.SetDisconnected= dt.Rows(0).Item("Disconnected")
				.SetComments= dt.Rows(0).Item("Comments")
				.SetAssetID= dt.Rows(0).Item("AssetID")
				.SetEngineerVisitID= dt.Rows(0).Item("EngineerVisitID")

					.SetDeleted = dt.Rows(0).Item("Deleted")               
				End With		
				oEngineerVisitDefects.Exists = true				
			Return oEngineerVisitDefects
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
            End Function

            Public Function EngineerVisitDefects_GetForEngineerVisit(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitDefects_GetForEngineerVisit")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitDefects.ToString
                Return New DataView(dt)
            End Function

            Public Function [EngineerVisitDefects_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitDefects_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitDefects.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oEngineerVisitDefects As EngineerVisitDefects) As EngineerVisitDefects
                _database.ClearParameter()
                AddEngineerVisitDefectsParametersToCommand(oEngineerVisitDefects)

                oEngineerVisitDefects.SetEngineerVisitDefectID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitDefects_Insert"))
                oEngineerVisitDefects.Exists = True
                Return oEngineerVisitDefects
            End Function


            Public Sub [Update](ByVal oEngineerVisitDefects As EngineerVisitDefects)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitDefectID", oEngineerVisitDefects.EngineerVisitDefectID, True)
                AddEngineerVisitDefectsParametersToCommand(oEngineerVisitDefects)
                _database.ExecuteSP_NO_Return("EngineerVisitDefects_Update")
            End Sub



            Private Sub AddEngineerVisitDefectsParametersToCommand(ByRef oEngineerVisitDefects As EngineerVisitDefects)
                With _database
                    .AddParameter("@CategoryID", oEngineerVisitDefects.CategoryID, True)
                    .AddParameter("@Reason", oEngineerVisitDefects.Reason, True)
                    .AddParameter("@ActionTaken", oEngineerVisitDefects.ActionTaken, True)
                    .AddParameter("@WarningNoticeIssued", oEngineerVisitDefects.WarningNoticeIssued, True)
                    .AddParameter("@Disconnected", oEngineerVisitDefects.Disconnected, True)
                    .AddParameter("@Comments", oEngineerVisitDefects.Comments, True)
                    .AddParameter("@AssetID", oEngineerVisitDefects.AssetID, True)
                    .AddParameter("@EngineerVisitID", oEngineerVisitDefects.EngineerVisitID, True)



                End With
            End Sub


#End Region

End Class

End Namespace

End Namespace


