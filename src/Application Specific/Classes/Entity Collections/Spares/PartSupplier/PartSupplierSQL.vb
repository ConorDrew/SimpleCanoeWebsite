Imports System.Data.SqlClient

Namespace Entity

    Namespace PartSuppliers

        Public Class PartSupplierSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function PartSupplier_FindTabletOrder(ByVal SearchString As String, Optional ByVal SupplierID As Integer = 0)
                _database.ClearParameter()
                _database.AddParameter("@Find", SearchString, True)
                _database.AddParameter("@SupplierID", SupplierID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplier_FindForTabletOrder")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function PartSupplier_Search(ByVal SearchString As String,
                                                Optional ByVal SupplierID As Integer = 0,
                                                Optional ByVal isFlagShip As Boolean = False)
                _database.ClearParameter()
                _database.AddParameter("@SearchString", SearchString, True)
                _database.AddParameter("@SupplierID", SupplierID, True)
                _database.AddParameter("@Flagship", isFlagShip, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplier_Search_2")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function PartSupplierPacks_Get(ByVal PartID As Integer, ByVal SupplierID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@SupplierID", SupplierID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplierPacks_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function PartSupplierPacks_Get(ByVal PartID As Integer, ByVal SupplierID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "PartSupplierPacks_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartID", PartID)
                Command.Parameters.AddWithValue("@SupplierID", SupplierID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString

                Return New DataView(dt)

            End Function

            Public Function [PartSupplier_Get](ByVal PartSupplierID As Integer) As PartSupplier
                _database.ClearParameter()
                _database.AddParameter("@PartSupplierID", PartSupplierID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplier_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPartSupplier As New PartSupplier
                        With oPartSupplier
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetPartSupplierID = dt.Rows(0).Item("PartSupplierID")
                            .SetPartCode = dt.Rows(0).Item("PartCode")
                            .SetPrice = dt.Rows(0).Item("Price")
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")
                            .SetQuantityInPack = dt.Rows(0).Item("QuantityInPack")
                            .SetPreferred = dt.Rows(0).Item("Preferred")
                            If dt.Columns.Contains("SecondaryPrice") Then
                                .SetSecondaryPrice = Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("SecondaryPrice"))
                            End If

                        End With
                        oPartSupplier.Exists = True
                        Return oPartSupplier
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [PartSupplier_Get](ByVal PartSupplierID As Integer, ByVal trans As SqlClient.SqlTransaction) As PartSupplier

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "PartSupplier_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartSupplierID", PartSupplierID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPartSupplier As New PartSupplier
                        With oPartSupplier
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartID = dt.Rows(0).Item("PartID")
                            .SetPartSupplierID = dt.Rows(0).Item("PartSupplierID")
                            .SetPartCode = dt.Rows(0).Item("PartCode")
                            .SetPrice = dt.Rows(0).Item("Price")
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")
                            .SetQuantityInPack = dt.Rows(0).Item("QuantityInPack")
                            .SetPreferred = dt.Rows(0).Item("Preferred")

                            If dt.Columns.Contains("SecondaryPrice") Then
                                .SetSecondaryPrice = Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("SecondaryPrice"))
                            End If
                        End With
                        oPartSupplier.Exists = True
                        Return oPartSupplier
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function PartSupplierGet_All() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplier_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_ByPartID(ByVal PartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplier_GetByPart")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_ByPartID(ByVal PartID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView
                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "PartSupplier_GetByPart"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartID", PartID)

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_ByPartIDAndSupplierID(ByVal PartID As Integer, ByVal SupplierID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@SupplierID", SupplierID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartSupplier_GetByPartAndSupplier")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Sub Delete(ByVal PartSupplierID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartSupplierID", PartSupplierID, True)
                _database.ExecuteSP_NO_Return("PartSupplier_Delete")
            End Sub

            Public Function [Insert](ByVal oPartSupplier As PartSupplier) As PartSupplier
                _database.ClearParameter()
                AddPartSupplierParametersToCommand(oPartSupplier)

                oPartSupplier.SetPartSupplierID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartSupplier_Insert"))
                oPartSupplier.Exists = True
                Return oPartSupplier
            End Function

            Public Sub [Update](ByVal oPartSupplier As PartSupplier, Optional ByVal PrimaryDateUpdate As Boolean = False, Optional SecondaryDateUpdate As Boolean = False)
                _database.ClearParameter()
                _database.AddParameter("@PartSupplierID", oPartSupplier.PartSupplierID, True)
                If PrimaryDateUpdate Then
                    _database.AddParameter("@PrimaryDateUpdate", True, True)
                End If
                If SecondaryDateUpdate Then
                    _database.AddParameter("@SecondaryDateUpdate", True, True)
                End If
                AddPartSupplierParametersToCommand(oPartSupplier)
                    _database.ExecuteSP_NO_Return("PartSupplier_Update")
            End Sub

            Private Sub AddPartSupplierParametersToCommand(ByRef oPartSupplier As PartSupplier)
                With _database
                    .AddParameter("@PartCode", oPartSupplier.PartCode, True)
                    .AddParameter("@PartID", oPartSupplier.PartID, True)
                    .AddParameter("@SupplierID", oPartSupplier.SupplierID, True)
                    .AddParameter("@Price", oPartSupplier.Price, True)
                    .AddParameter("@QuantityInPack", oPartSupplier.QuantityInPack, True)
                    .AddParameter("@UserID", loggedInUser.UserID, True)

                    If oPartSupplier.SecondaryPrice > 0 Then
                        .AddParameter("@SecondaryPrice", oPartSupplier.SecondaryPrice, True)
                    End If
                End With
            End Sub

            Public Sub Update_Preferred(ByVal PartSupplierID As Integer, ByVal Preferred As Boolean)
                _database.ClearParameter()
                _database.AddParameter("@PartSupplierID", PartSupplierID, True)
                If Preferred Then
                    _database.AddParameter("@Preferred", 1, True)
                Else
                    _database.AddParameter("@Preferred", 0, True)
                End If

                _database.ExecuteSP_NO_Return("PartSupplier_Update_Preferred")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace