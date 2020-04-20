Imports System.Data.SqlClient
Imports FSM.Entity.Sys

Namespace Entity

    Namespace EngineerTimeSheets

        Public Class EngineerTimeSheetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal EngineerTimeSheetID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerTimeSheetID", EngineerTimeSheetID, True)
                _database.ExecuteSP_NO_Return("EngineerTimeSheet_Delete")
            End Sub

            Public Function [Insert](ByVal oEngineerTimeSheet As EngineerTimeSheet) As EngineerTimeSheet
                _database.ClearParameter()
                AddEngineerVisitTimeSheetParametersToCommand(oEngineerTimeSheet)

                oEngineerTimeSheet.SetEngineerTimeSheetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerTimeSheet_Insert"))
                oEngineerTimeSheet.Exists = True
                Return oEngineerTimeSheet
            End Function

            Public Sub [Update](ByVal oEngineerTimeSheet As EngineerTimeSheet)
                _database.ClearParameter()
                AddEngineerVisitTimeSheetParametersToCommand(oEngineerTimeSheet)
                _database.AddParameter("@EngineerTimeSheetID", oEngineerTimeSheet.EngineerTimeSheetID, True)
                _database.ExecuteSP_NO_Return("EngineerTimeSheet_Update")

            End Sub

            Private Sub AddEngineerVisitTimeSheetParametersToCommand(ByRef oEngineerTimeSheet As EngineerTimeSheet)
                With _database
                    .AddParameter("@EngineerID", oEngineerTimeSheet.EngineerID, True)
                    .AddParameter("@StartDateTime", oEngineerTimeSheet.StartDateTime, True)
                    .AddParameter("@EndDateTime", oEngineerTimeSheet.EndDateTime, True)
                    .AddParameter("@Comments", oEngineerTimeSheet.Comments, True)
                    .AddParameter("@TimesheetTypeID", oEngineerTimeSheet.TimeSheetTypeID, True)
                End With
            End Sub

            Public Function GetAll(ByVal Where As String, ByVal Where2 As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Where", Where, True)
                _database.AddParameter("@Where2", Where2, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitTimeSheet_GetAll_RD")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerTimesheet.ToString
                Return New DataView(dt)
            End Function

            Public Sub [UpdateVisit](ByVal oEngineerTimeSheet As EngineerTimeSheet)

                _database.ClearParameter()
                _database.AddParameter("@EngineerTimesheetID", oEngineerTimeSheet.EngineerTimeSheetID, True)
                _database.AddParameter("@StartDateTime", oEngineerTimeSheet.StartDateTime, True)
                _database.AddParameter("@EndDateTime", oEngineerTimeSheet.EndDateTime, True)
                _database.AddParameter("@Comments", oEngineerTimeSheet.Comments, True)
                _database.ExecuteSP_NO_Return("EngineerTimeSheet_UpdateVisit")

            End Sub

            Public Function [Get](ByVal EngineerTimeSheetID As Integer) As EngineerTimeSheet
                _database.ClearParameter()
                _database.AddParameter("@EngineerTimeSheetID", EngineerTimeSheetID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerTimeSheet_Get_RD")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerTimeSheet As New EngineerTimeSheet
                        With oEngineerTimeSheet
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerTimeSheetID = dt.Rows(0).Item("EngineerTimeSheetID")
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .StartDateTime = Helper.MakeDateTimeValid(dt.Rows(0).Item("StartDateTime"))
                            .EndDateTime = Helper.MakeDateTimeValid(dt.Rows(0).Item("EndDateTime"))
                            .SetComments = dt.Rows(0).Item("Comments")
                            .SetTimeSheetTypeID = dt.Rows(0).Item("TimeSheetTypeID")
                            .SetEngineerVisitID = dt.Rows(0).Item("EngineerVisitID")

                        End With
                        oEngineerTimeSheet.Exists = True
                        Return oEngineerTimeSheet
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