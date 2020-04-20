Imports System.Data.SqlClient

Namespace Entity

Namespace Areas

Public Class AreaSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal AreaID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@AreaID", AreaID, True)
            _database.ExecuteSP_NO_Return("Area_Delete")
    End Sub

    Public Function [Area_Get](ByVal AreaID As Integer) As Area
        _database.ClearParameter()
        _database.AddParameter("@AreaID", AreaID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("Area_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oArea As New Area
				With oArea
				    .IgnoreExceptionsOnSetMethods = True
						.SetAreaID= dt.Rows(0).Item("AreaID")
				.SetDescription= dt.Rows(0).Item("Description")
				.SetSectionID= dt.Rows(0).Item("SectionID")
				.SetOrderNumber= dt.Rows(0).Item("OrderNumber")

					.SetDeleted = dt.Rows(0).Item("Deleted")               
				End With		
				oArea.Exists = true				
			Return oArea
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
    End Function

            Public Function Area_Get_For_Section(ByVal SectionID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SectionID", SectionID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Area_Get_For_Section")
                dt.TableName = Entity.Sys.Enums.TableNames.tblArea.ToString
                Return New DataView(dt)
            End Function

            Public Function [Area_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Area_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblArea.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oArea As Area) As Area
                _database.ClearParameter()

                If oArea.OrderNumber = 0 Then
                    oArea.SetOrderNumber = Area_getNextOrderNumber(oArea.SectionID)
                End If

                _database.ClearParameter()

                AddAreaParametersToCommand(oArea)

                oArea.SetAreaID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Area_Insert"))
                oArea.Exists = True
                Return oArea
            End Function

            Public Sub Area_AdjustOrderNumber(ByVal AreaID As Integer, ByVal OldOrderNumber As Integer, ByVal NewOrderNumber As Integer, ByVal SectionID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@AreaID", AreaID, True)
                _database.AddParameter("@oldOrderNumber", OldOrderNumber, True)
                _database.AddParameter("@NewOrderNumber", NewOrderNumber, True)
                _database.AddParameter("@SectionID", SectionID, True)
                _database.ExecuteSP_NO_Return("Area_AdjustOrderNumber")
            End Sub
            Public Sub [Update](ByVal oArea As Area)
                _database.ClearParameter()
                _database.AddParameter("@AreaID", oArea.AreaID, True)
                AddAreaParametersToCommand(oArea)
                _database.ExecuteSP_NO_Return("Area_Update")
            End Sub


            Private Sub AddAreaParametersToCommand(ByRef oArea As Area)
                With _database
                    .AddParameter("@Description", oArea.Description, True)
                    .AddParameter("@SectionID", oArea.SectionID, True)
                    .AddParameter("@OrderNumber", oArea.OrderNumber, True)
                End With
            End Sub

            Private Function Area_getNextOrderNumber(ByVal SectionID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@SectionID", SectionID, True)

                Dim nextID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Area_getNextOrderNumber"))

                If nextID = 0 Then
                    Return 1
                Else
                    Return nextID + 1
                End If
            End Function

#End Region

End Class

End Namespace

End Namespace


