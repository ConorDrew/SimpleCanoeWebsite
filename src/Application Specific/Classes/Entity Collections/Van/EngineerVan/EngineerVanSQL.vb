Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVans

        Public Class EngineerVanSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [EngineerVan_GetAll_For_Van](ByVal VanID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@VanID", VanID)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVan_GetAll_For_Van")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVan.ToString
                Return New DataView(dt)
            End Function

            

            Public Function [EngineerVan_GetAll_For_Engineer](ByVal EngineerID As Integer, ByVal Grouped As Boolean) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerID", EngineerID)
                If Grouped Then
                    _database.AddParameter("@Grouped", 1)
                Else
                    _database.AddParameter("@Grouped", 0)
                End If

                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVan_GetAll_For_Engineer")
                dt.TableName = Entity.Sys.Enums.TableNames.tblEngineerVan.ToString
                Return New DataView(dt)
            End Function

            Public Function [EngineerVan_Get](ByVal EngineerVanID As Integer) As EngineerVan
                _database.ClearParameter()
                _database.AddParameter("@EngineerVanID", EngineerVanID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVan_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oEngineerVan As New EngineerVan
                        With oEngineerVan
                            .IgnoreExceptionsOnSetMethods = True
                            .SetEngineerVanID = dt.Rows(0).Item("EngineerVanID")
                            .SetEngineerID = dt.Rows(0).Item("EngineerID")
                            .SetVanID = dt.Rows(0).Item("VanID")
                            .StartDateTime = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("StartDateTime"))
                            .EndDateTime = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0).Item("EndDateTime"))
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oEngineerVan.Exists = True
                        Return oEngineerVan
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Insert](ByVal oEngineerVan As EngineerVan) As EngineerVan
                Dim returnVan As EngineerVan = Nothing

                Dim registration As String = DB.Van.Van_Get(oEngineerVan.VanID).Registration.Split("*")(0).Trim

                For Each row As DataRow In DB.Van.Van_GetAll(False).Table.Rows
                    If Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim = registration Then
                        _database.ClearParameter()
                        _database.AddParameter("@EngineerID", oEngineerVan.EngineerID, True)
                        _database.AddParameter("@VanID", row.Item("VanID"), True)
                        _database.AddParameter("@StartDateTime", oEngineerVan.StartDateTime, True)
                        If Not oEngineerVan.EndDateTime = Nothing Then
                            _database.AddParameter("@EndDateTime", oEngineerVan.EndDateTime, True)
                        Else
                            _database.AddParameter("@EndDateTime", System.DBNull.Value, True)
                        End If

                        oEngineerVan.SetEngineerVanID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("EngineerVan_Insert"))
                        oEngineerVan.Exists = True

                        If returnVan Is Nothing Then
                            returnVan = oEngineerVan
                        End If
                    End If
                Next

                Return returnVan
            End Function

            Public Sub [Update](ByVal oEngineerVan As EngineerVan)
                Dim registration As String = DB.Van.Van_Get(oEngineerVan.VanID).Registration.Split("*")(0).Trim

                Dim dt As DataTable = EngineerVan_GetAll_For_Engineer(oEngineerVan.EngineerID, False).Table

                For Each row As DataRow In DB.Van.Van_GetAll(False).Table.Rows
                    If Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim = registration Then
                        For Each engineerVanRow As DataRow In dt.Rows
                            If engineerVanRow.Item("VanID") = row.Item("VanID") Then
                                _database.ClearParameter()
                                _database.AddParameter("@EngineerID", oEngineerVan.EngineerID, True)
                                _database.AddParameter("@StartDateTime", oEngineerVan.StartDateTime, True)
                                If Not oEngineerVan.EndDateTime = Nothing Then
                                    _database.AddParameter("@EndDateTime", oEngineerVan.EndDateTime, True)
                                Else
                                    _database.AddParameter("@EndDateTime", System.DBNull.Value, True)
                                End If
                                _database.AddParameter("@EngineerVanID", engineerVanRow.Item("EngineerVanID"), True)

                                _database.ExecuteSP_NO_Return("EngineerVan_Update")
                            End If
                        Next
                    End If
                Next
            End Sub

            Public Sub Delete(ByVal EngineerVanID As Integer)
                Dim oEngineerVan As EngineerVan = EngineerVan_Get(EngineerVanID)

                Dim registration As String = DB.Van.Van_Get(oEngineerVan.VanID).Registration.Split("*")(0).Trim

                Dim dt As DataTable = EngineerVan_GetAll_For_Engineer(oEngineerVan.EngineerID, False).Table

                '    Dim dt2 As DataTable = EngineerVan_GetAll_For_Van(oEngineerVan.VanID).Table

                For Each row As DataRow In DB.Van.Van_GetAll_incDeleted(False).Table.Rows
                    If Sys.Helper.MakeStringValid(row.Item("Registration")).Split("*")(0).Trim = registration Then
                        For Each engineerVanRow As DataRow In dt.Rows
                            If engineerVanRow.Item("VanID") = row.Item("VanID") Then
                                _database.ClearParameter()
                                _database.AddParameter("@EngineerVanID", engineerVanRow.Item("EngineerVanID"), True)
                                _database.ExecuteSP_NO_Return("EngineerVan_Delete")
                            End If
                        Next
                    End If
                Next
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


