Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitTimeSheets

        Public Class EngineerVisitTimeSheetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitTimeSheet_Delete")
            End Sub

            Public Function [EngineerVisitTimeSheet_Get_For_EngineerVisitID](ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitTimeSheet_Get_For_EngineerVisitID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString
                Return New DataView(dt)

            End Function

            Public Function [Insert](ByVal oEngineerVisitTimeSheet As EngineerVisitTimeSheet) As EngineerVisitTimeSheet
                _database.ClearParameter()
                AddEngineerVisitTimeSheetParametersToCommand(oEngineerVisitTimeSheet)

                oEngineerVisitTimeSheet.SetEngineerVisitTimeSheetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVisitTimeSheet_Insert"))
                oEngineerVisitTimeSheet.Exists = True
                Return oEngineerVisitTimeSheet
            End Function

            Private Sub AddEngineerVisitTimeSheetParametersToCommand(ByRef oEngineerVisitTimeSheet As EngineerVisitTimeSheet)
                With _database
                    .AddParameter("@EngineerVisitID", oEngineerVisitTimeSheet.EngineerVisitID, True)
                    .AddParameter("@StartDateTime", oEngineerVisitTimeSheet.StartDateTime, True)
                    .AddParameter("@EndDateTime", oEngineerVisitTimeSheet.EndDateTime, True)
                    .AddParameter("@Comments", oEngineerVisitTimeSheet.Comments, True)
                    .AddParameter("@TimesheetTypeID", oEngineerVisitTimeSheet.TimeSheetTypeID, True)
                End With
            End Sub

            Public Function GetAll(ByVal Where As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@WHERE", Where, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitTimeSheet_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitTimesheet.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_CurrentCost_ByJobID(ByVal jobId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitTimesheet_Get_CurrentCost_ByJobID")
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace