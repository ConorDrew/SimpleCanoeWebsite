Imports System.Data.SqlClient

Namespace Entity

Namespace SubTasks

Public Class SubTaskSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal SubTaskID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@SubTaskID", SubTaskID, True)
            _database.ExecuteSP_NO_Return("SubTask_Delete")
    End Sub

    Public Function [SubTask_Get](ByVal SubTaskID As Integer) As SubTask
        _database.ClearParameter()
        _database.AddParameter("@SubTaskID", SubTaskID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("SubTask_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oSubTask As New SubTask
				With oSubTask
				    .IgnoreExceptionsOnSetMethods = True
						.SetSubTaskID= dt.Rows(0).Item("SubTaskID")
				.SetTaskID= dt.Rows(0).Item("TaskID")
				.SetDescription= dt.Rows(0).Item("Description")
				.SetOrderNumber= dt.Rows(0).Item("OrderNumber")

					.SetDeleted = dt.Rows(0).Item("Deleted")               
				End With		
				oSubTask.Exists = true				
			Return oSubTask
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
            End Function

            Public Function [SubTask_Get_For_Task](ByVal TaskID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@TaskID", TaskID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SubTask_Get_For_Task")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSubTask.ToString
                Return New DataView(dt)
            End Function

            Public Function [SubTask_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SubTask_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSubTask.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oSubTask As SubTask) As SubTask
                _database.ClearParameter()

                If oSubTask.OrderNumber = 0 Then
                    oSubTask.SetOrderNumber = SubTask_getNextOrderNumber(oSubTask.TaskID)
                End If

                _database.ClearParameter()

                AddSubTaskParametersToCommand(oSubTask)

                oSubTask.SetSubTaskID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SubTask_Insert"))
                oSubTask.Exists = True
                Return oSubTask
            End Function

            Public Sub SubTask_AdjustOrderNumber(ByVal SubTaskID As Integer, ByVal OldOrderNumber As Integer, ByVal NewOrderNumber As Integer, ByVal TaskID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@TaskID", TaskID, True)
                _database.AddParameter("@oldOrderNumber", OldOrderNumber, True)
                _database.AddParameter("@NewOrderNumber", NewOrderNumber, True)
                _database.AddParameter("@SubTaskID", SubTaskID, True)
                _database.ExecuteSP_NO_Return("SubTask_AdjustOrderNumber")
            End Sub

            Public Sub [Update](ByVal oSubTask As SubTask)
                _database.ClearParameter()
                _database.AddParameter("@SubTaskID", oSubTask.SubTaskID, True)
                AddSubTaskParametersToCommand(oSubTask)
                _database.ExecuteSP_NO_Return("SubTask_Update")
            End Sub

            Private Sub AddSubTaskParametersToCommand(ByRef oSubTask As SubTask)
                With _database
                    .AddParameter("@TaskID", oSubTask.TaskID, True)
                    .AddParameter("@Description", oSubTask.Description, True)
                    .AddParameter("@OrderNumber", oSubTask.OrderNumber, True)
                End With
            End Sub

            Private Function SubTask_getNextOrderNumber(ByVal TaskID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@TaskID", TaskID, True)

                Dim nextID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SubTask_getNextOrderNumber"))

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


