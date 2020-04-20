Imports System.Data.SqlClient

Namespace Entity

Namespace Tasks

Public Class TaskSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal TaskID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@TaskID", TaskID, True)
            _database.ExecuteSP_NO_Return("Task_Delete")
    End Sub

    Public Function [Task_Get](ByVal TaskID As Integer) As Task
        _database.ClearParameter()
        _database.AddParameter("@TaskID", TaskID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("Task_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oTask As New Task
				With oTask
				    .IgnoreExceptionsOnSetMethods = True
						.SetTaskID= dt.Rows(0).Item("TaskID")
				.SetAreaID= dt.Rows(0).Item("AreaID")
				.SetDescription= dt.Rows(0).Item("Description")
				.SetOrderNumber= dt.Rows(0).Item("OrderNumber")

					.SetDeleted = dt.Rows(0).Item("Deleted")               
				End With		
				oTask.Exists = true				
			Return oTask
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
            End Function

            Public Function Task_Get_For_Area(ByVal AreaID) As DataView
                _database.ClearParameter()
                _database.AddParameter("@AreaID", AreaID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Task_Get_For_Area")
                dt.TableName = Entity.Sys.Enums.TableNames.tblTask.ToString
                Return New DataView(dt)
            End Function


            Public Function [Task_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Task_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblTask.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oTask As Task) As Task
                _database.ClearParameter()

                If oTask.OrderNumber = 0 Then
                    oTask.SetOrderNumber = Task_getNextOrderNumber(oTask.AreaID)
                End If

                _database.ClearParameter()

                AddTaskParametersToCommand(oTask)

                oTask.SetTaskID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Task_Insert"))
                oTask.Exists = True
                Return oTask
            End Function

            Public Sub Task_AdjustOrderNumber(ByVal TaskID As Integer, ByVal OldOrderNumber As Integer, ByVal NewOrderNumber As Integer, ByVal AreaID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@AreaID", AreaID, True)
                _database.AddParameter("@oldOrderNumber", OldOrderNumber, True)
                _database.AddParameter("@NewOrderNumber", NewOrderNumber, True)
                _database.AddParameter("@TaskID", TaskID, True)
                _database.ExecuteSP_NO_Return("Task_AdjustOrderNumber")
            End Sub

            Public Sub [Update](ByVal oTask As Task)
                _database.ClearParameter()
                _database.AddParameter("@TaskID", oTask.TaskID, True)
                AddTaskParametersToCommand(oTask)
                _database.ExecuteSP_NO_Return("Task_Update")
            End Sub



            Private Sub AddTaskParametersToCommand(ByRef oTask As Task)
                With _database
                    .AddParameter("@AreaID", oTask.AreaID, True)
                    .AddParameter("@Description", oTask.Description, True)
                    .AddParameter("@OrderNumber", oTask.OrderNumber, True)



                End With
            End Sub

            Private Function Task_getNextOrderNumber(ByVal AreaID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@AreaID", AreaID, True)

                Dim nextID As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Task_getNextOrderNumber"))

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


