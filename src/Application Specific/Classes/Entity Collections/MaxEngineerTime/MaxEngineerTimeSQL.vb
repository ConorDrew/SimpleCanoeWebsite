Imports System.Data.SqlClient

Namespace Entity

Namespace MaxEngineerTimes

Public Class MaxEngineerTimeSQL
    Private _database As Sys.Database

    Public Sub New(ByVal database As Sys.Database)
        _database = database
    End Sub

#Region "Functions"

	
    Public Sub Delete(ByVal MaxEngineerTimeID As Integer)
    		_database.ClearParameter()
            _database.AddParameter("@MaxEngineerTimeID", MaxEngineerTimeID, True)
            _database.ExecuteSP_NO_Return("MaxEngineerTime_Delete")
    End Sub

    Public Function [MaxEngineerTime_Get](ByVal MaxEngineerTimeID As Integer) As MaxEngineerTime
        _database.ClearParameter()
        _database.AddParameter("@MaxEngineerTimeID", MaxEngineerTimeID)
        
        'Get the datatable from the database store in dt
        Dim dt As DataTable = _database.ExecuteSP_DataTable("MaxEngineerTime_Get")
        
        If Not dt Is Nothing Then			
			if dt.rows.count > 0 then
				Dim oMaxEngineerTime As New MaxEngineerTime
				With oMaxEngineerTime
				    .IgnoreExceptionsOnSetMethods = True
						.SetMaxEngineerTimeID= dt.Rows(0).Item("MaxEngineerTimeID")
				.SetEngineerID= dt.Rows(0).Item("EngineerID")
				.SetMondayValue= dt.Rows(0).Item("MondayValue")
				.SetTuesdayValue= dt.Rows(0).Item("TuesdayValue")
				.SetWednesdayValue= dt.Rows(0).Item("WednesdayValue")
				.SetThursdayValue= dt.Rows(0).Item("ThursdayValue")
				.SetFridayValue= dt.Rows(0).Item("FridayValue")
				.SetSaturdayValue= dt.Rows(0).Item("SaturdayValue")
				.SetSundayValue= dt.Rows(0).Item("SundayValue")

					.SetDeleted = dt.Rows(0).Item("Deleted")               
				End With		
				oMaxEngineerTime.Exists = true				
			Return oMaxEngineerTime
			else
					Return Nothing
			end if 
			       Else
            Return Nothing
        End If
    End Function

    Public Function [MaxEngineerTime_GetAll]() As DataView
       _database.ClearParameter()
        Dim dt As DataTable = _database.ExecuteSP_DataTable("MaxEngineerTime_GetAll")
        dt.TableName = Entity.Sys.Enums.TableNames.tblMaxEngineerTime.ToString
        Return New DataView(dt)
            End Function

            Public Function MaxEngineerTime_GetForEngineer(ByVal EngineerID As Integer) As MaxEngineerTime
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", EngineerID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("MaxEngineerTime_GetForEngineer")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oMaxEngineerTime As New MaxEngineerTime
                        With oMaxEngineerTime
                            .IgnoreExceptionsOnSetMethods = True
                            .SetMaxEngineerTimeID = dt.Rows(0).Item("MaxEngineerTimeID")
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .SetMondayValue = dt.Rows(0).Item("MondayValue")
                            .SetTuesdayValue = dt.Rows(0).Item("TuesdayValue")
                            .SetWednesdayValue = dt.Rows(0).Item("WednesdayValue")
                            .SetThursdayValue = dt.Rows(0).Item("ThursdayValue")
                            .SetFridayValue = dt.Rows(0).Item("FridayValue")
                            .SetSaturdayValue = dt.Rows(0).Item("SaturdayValue")
                            .SetSundayValue = dt.Rows(0).Item("SundayValue")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oMaxEngineerTime.Exists = True
                        Return oMaxEngineerTime
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If

            End Function
   
    Public Function [Insert](ByVal oMaxEngineerTime As MaxEngineerTime) As MaxEngineerTime
		 _database.ClearParameter()			
	     AddMaxEngineerTimeParametersToCommand(oMaxEngineerTime)	
						
		oMaxEngineerTime.SetMaxEngineerTimeID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("MaxEngineerTime_Insert"))				
        oMaxEngineerTime.Exists = True
        Return oMaxEngineerTime
    End Function   
    

    Public Sub [Update](ByVal oMaxEngineerTime As MaxEngineerTime)
		_database.ClearParameter()
		_database.AddParameter("@MaxEngineerTimeID", oMaxEngineerTime.MaxEngineerTimeID, True)  
		AddMaxEngineerTimeParametersToCommand(oMaxEngineerTime)
		_database.ExecuteSP_NO_Return("MaxEngineerTime_Update")
    End Sub



    Private Sub AddMaxEngineerTimeParametersToCommand(ByRef oMaxEngineerTime As MaxEngineerTime)    
        With _database
			.AddParameter("@EngineerID", oMaxEngineerTime.EngineerID, True)
			.AddParameter("@MondayValue", oMaxEngineerTime.MondayValue, True)
			.AddParameter("@TuesdayValue", oMaxEngineerTime.TuesdayValue, True)
			.AddParameter("@WednesdayValue", oMaxEngineerTime.WednesdayValue, True)
			.AddParameter("@ThursdayValue", oMaxEngineerTime.ThursdayValue, True)
			.AddParameter("@FridayValue", oMaxEngineerTime.FridayValue, True)
			.AddParameter("@SaturdayValue", oMaxEngineerTime.SaturdayValue, True)
			.AddParameter("@SundayValue", oMaxEngineerTime.SundayValue, True)

		
            
        End With        
    End Sub      
    

#End Region

End Class

End Namespace

End Namespace


