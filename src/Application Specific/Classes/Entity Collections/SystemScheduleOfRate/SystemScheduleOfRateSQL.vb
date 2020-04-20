Imports System.Data.SqlClient

Namespace Entity

    Namespace SystemScheduleOfRates

        Public Class SystemScheduleOfRateSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal SystemScheduleOfRateID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@SystemScheduleOfRateID", SystemScheduleOfRateID, True)
                _database.ExecuteSP_NO_Return("SystemScheduleOfRate_Delete")
            End Sub

            Public Function [SystemScheduleOfRate_Get](ByVal SystemScheduleOfRateID As Integer) As SystemScheduleOfRate
                _database.ClearParameter()
                _database.AddParameter("@SystemScheduleOfRateID", SystemScheduleOfRateID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SystemScheduleOfRate_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oSystemScheduleOfRate As New SystemScheduleOfRate
                        With oSystemScheduleOfRate
                            .IgnoreExceptionsOnSetMethods = True
                            .SetSystemScheduleOfRateID = dt.Rows(0).Item("SystemScheduleOfRateID")
                            .SetScheduleOfRatesCategoryID = dt.Rows(0).Item("ScheduleOfRatesCategoryID")
                            .SetCode = dt.Rows(0).Item("Code")
                            .SetDescription = dt.Rows(0).Item("Description")
                            .SetPrice = dt.Rows(0).Item("Price")
                            .SetTimeInMins = Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("TimeInMins"))
                            .SetJobTypeID = Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("JobTypeID"))
                            .SetAllowDeleted = dt.Rows(0).Item("AllowDeleted")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oSystemScheduleOfRate.Exists = True
                        Return oSystemScheduleOfRate
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [SystemScheduleOfRate_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SystemScheduleOfRate_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function SystemScheduleOfRate_Get_ByJobType(ByVal jobTypeID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobTypeID", jobTypeID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SystemScheduleOfRate_Get_ByJobType")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function SystemScheduleOfRate_Get_ByEngineerQual(ByVal engQualID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngQualID", engQualID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SystemScheduleOfRate_Get_ByEngineerQual")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [SystemScheduleOfRate_GetAll_WithoutDefaults]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SystemScheduleOfRate_GetAll_WithoutDefaults")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oSystemScheduleOfRate As SystemScheduleOfRate) As SystemScheduleOfRate
                _database.ClearParameter()
                AddParametersToCommand(oSystemScheduleOfRate)

                oSystemScheduleOfRate.SetSystemScheduleOfRateID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SystemScheduleOfRate_Insert"))
                oSystemScheduleOfRate.Exists = True
                Return oSystemScheduleOfRate
            End Function

            Public Function [SystemScheduleOfRate_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("SystemScheduleOfRate_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oSystemScheduleOfRate As SystemScheduleOfRate)
                _database.ClearParameter()
                _database.AddParameter("@SystemScheduleOfRateID", oSystemScheduleOfRate.SystemScheduleOfRateID, True)
                AddParametersToCommand(oSystemScheduleOfRate)
                _database.ExecuteSP_NO_Return("SystemScheduleOfRate_Update")
            End Sub

            Private Sub AddParametersToCommand(ByRef oSystemScheduleOfRate As SystemScheduleOfRate)
                With _database
                    .AddParameter("@ScheduleOfRatesCategoryID", oSystemScheduleOfRate.ScheduleOfRatesCategoryID, True)
                    .AddParameter("@Code", oSystemScheduleOfRate.Code, True)
                    .AddParameter("@Description", oSystemScheduleOfRate.Description, True)
                    .AddParameter("@Price", oSystemScheduleOfRate.Price, True)
                    .AddParameter("@TimeInMins", oSystemScheduleOfRate.TimeInMins, True)
                    .AddParameter("@JobTypeID", oSystemScheduleOfRate.JobTypeID, True)
                    .AddParameter("@AllowDeleted", oSystemScheduleOfRate.AllowDeleted, True)
                End With
            End Sub

            Public Function SOREnginerQual_Get_ForSOR(ByVal sorId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SORID", sorId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SOREnginerQual_Get_ForSOR")
                dt.TableName = Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Sub SOREnginerQual_Insert(ByVal sorId As Integer, ByVal engQualId As Integer)
                _database.ClearParameter()
                _database.AddParameter("@SystemScheduleOfRateID", sorId, True)
                _database.AddParameter("@EngineerQualID", engQualId, True)
                _database.ExecuteSP_OBJECT("SOREnginerQual_Insert")
            End Sub

            Public Sub SOREnginerQual_Delete(ByVal sorId As Integer)
                _database.ClearParameter()
                DB.ExecuteScalar("DELETE FROM [tblSOREnginerQual] Where [SystemScheduleOfRateID] = " & sorId)
            End Sub
#End Region

        End Class

    End Namespace

End Namespace


