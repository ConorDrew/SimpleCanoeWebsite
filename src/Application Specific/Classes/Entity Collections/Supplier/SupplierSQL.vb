Imports System.Data.SqlClient

Namespace Entity

    Namespace Suppliers

        Public Class SupplierSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal SupplierID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@SupplierID", SupplierID, True)
                _database.ExecuteSP_NO_Return("Supplier_Delete")
            End Sub

            Public Function [Supplier_Get](ByVal SupplierID As Integer) As Supplier
                _database.ClearParameter()
                _database.AddParameter("@SupplierID", SupplierID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Supplier_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oSupplier As New Supplier
                        With oSupplier
                            .IgnoreExceptionsOnSetMethods = True
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")
                            .SetAccountNumber = dt.Rows(0).Item("AccountNumber")
                            If dt.Columns.Contains("SecondAccountNumber") Then .SetSecondAccountNumber = dt.Rows(0).Item("SecondAccountNumber")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetAddress1 = dt.Rows(0).Item("Address1")
                            .SetAddress2 = dt.Rows(0).Item("Address2")
                            .SetAddress3 = dt.Rows(0).Item("Address3")
                            .SetAddress4 = dt.Rows(0).Item("Address4")
                            .SetAddress5 = dt.Rows(0).Item("Address5")
                            .SetPostcode = dt.Rows(0).Item("Postcode")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetGaswayAccount = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("GaswayAccount"))
                            .SetMasterSupplierID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("MasterSupplierID"))
                            .SetReleaseToTablets = dt.Rows(0).Item("ReleaseToTablets")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetSubContractor = dt.Rows(0).Item("SubContractor")
                            .SecondaryPrice = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("SecondaryPrice"))
                            .SetDefaultNominal = dt.Rows(0).Item("DefaultNominal")
                        End With
                        oSupplier.Exists = True
                        Return oSupplier
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Supplier_Get](ByVal SupplierID As Integer, ByVal trans As SqlClient.SqlTransaction) As Supplier

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Supplier_Get"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@SupplierID", SupplierID)


                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oSupplier As New Supplier
                        With oSupplier
                            .IgnoreExceptionsOnSetMethods = True
                            .SetSupplierID = dt.Rows(0).Item("SupplierID")
                            .SetAccountNumber = dt.Rows(0).Item("AccountNumber")
                            If dt.Columns.Contains("SecondAccountNumber") Then .SetSecondAccountNumber = dt.Rows(0).Item("SecondAccountNumber")
                            .SetName = dt.Rows(0).Item("Name")
                            .SetAddress1 = dt.Rows(0).Item("Address1")
                            .SetAddress2 = dt.Rows(0).Item("Address2")
                            .SetAddress3 = dt.Rows(0).Item("Address3")
                            .SetAddress4 = dt.Rows(0).Item("Address4")
                            .SetAddress5 = dt.Rows(0).Item("Address5")
                            .SetPostcode = dt.Rows(0).Item("Postcode")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetNotes = dt.Rows(0).Item("Notes")
                            .SetGaswayAccount = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("GaswayAccount"))
                            .SetMasterSupplierID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("MasterSupplierID"))
                            .SetReleaseToTablets = dt.Rows(0).Item("ReleaseToTablets")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetSubContractor = dt.Rows(0).Item("SubContractor")
                        End With
                        oSupplier.Exists = True
                        Return oSupplier
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Supplier_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Supplier_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function [Supplier_GetAll](ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Supplier_GetAll"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                dt.TableName = Entity.Sys.Enums.TableNames.tblSupplier.ToString
                Return New DataView(dt)

            End Function

            Public Function GetChildSupplier(ByVal SupplierID As Integer) As Integer
                _database.ClearParameter()
                _database.AddParameter("@SupplierID", SupplierID, True)
                Dim ChildID As Integer = _database.SP_ExecuteScalar("Supplier_GetChildSupplierID")
                Return ChildID
            End Function

            Public Function [Supplier_Search](ByVal criteria As String, ByVal SearchOnField As String) As DataView

                If SearchOnField.Trim.Length > 0 Then
                    criteria = "'%" & criteria & "%'"
                End If

                _database.ClearParameter()
                _database.AddParameter("@SearchString", criteria, True)
                _database.AddParameter("@SearchOnField", SearchOnField, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Supplier_SearchList")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSupplier.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oSupplier As Supplier) As Supplier
                _database.ClearParameter()
                AddSupplierParametersToCommand(oSupplier)

                oSupplier.SetSupplierID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Supplier_Insert"))
                oSupplier.Exists = True
                Return oSupplier
            End Function

            Public Sub [Update](ByVal oSupplier As Supplier)
                _database.ClearParameter()
                _database.AddParameter("@SupplierID", oSupplier.SupplierID, True)
                AddSupplierParametersToCommand(oSupplier)
                _database.ExecuteSP_NO_Return("Supplier_Update")
            End Sub

            Private Sub AddSupplierParametersToCommand(ByRef oSupplier As Supplier)
                With _database
                    .AddParameter("@AccountNumber", oSupplier.AccountNumber, True)
                    .AddParameter("@SecondAccountNumber", oSupplier.SecondAccountNumber, True)
                    .AddParameter("@Name", oSupplier.Name, True)
                    .AddParameter("@Address1", oSupplier.Address1, True)
                    .AddParameter("@Address2", oSupplier.Address2, True)
                    .AddParameter("@Address3", oSupplier.Address3, True)
                    .AddParameter("@Address4", oSupplier.Address4, True)
                    .AddParameter("@Address5", oSupplier.Address5, True)
                    .AddParameter("@Postcode", oSupplier.Postcode, True)
                    .AddParameter("@TelephoneNum", oSupplier.TelephoneNum, True)
                    .AddParameter("@FaxNum", oSupplier.FaxNum, True)
                    .AddParameter("@EmailAddress", oSupplier.EmailAddress, True)
                    .AddParameter("@Notes", oSupplier.Notes, True)
                    .AddParameter("@GaswayAccount", oSupplier.GaswayAccount, True)
                    .AddParameter("@MasterSupplierID", oSupplier.MasterSupplierID, True)
                    .AddParameter("@ReleaseToTablets", oSupplier.ReleaseToTablets, True)
                    .AddParameter("@SubContractor", oSupplier.SubContractor, True)
                    .AddParameter("@SecondaryPrice", oSupplier.SecondaryPrice, True)
                    .AddParameter("@DefaultNominal", oSupplier.DefaultNominal, True)
                End With
            End Sub

            Public Function Supplier_GetWithProduct(ByVal ProductID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ProductID", ProductID)

                'Get the datatable from the database store in dt
                Return New DataView(_database.ExecuteSP_DataTable("Supplier_GetWithProduct"))
            End Function

            Public Function Supplier_GetWithProduct(ByVal ProductID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Supplier_GetWithProduct"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductID", ProductID))

                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                Return New DataView(dt)

            End Function

            Public Function Supplier_GetWithPart(ByVal PartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", PartID)

                'Get the datatable from the database store in dt
                Return New DataView(_database.ExecuteSP_DataTable("Supplier_GetWithPart"))
            End Function

            Public Function Supplier_GetWithPart(ByVal PartID As Integer, ByVal trans As SqlClient.SqlTransaction) As DataView

                Dim Command As SqlClient.SqlCommand = New SqlClient.SqlCommand

                Command.CommandText = "Supplier_GetWithPart"
                Command.CommandType = CommandType.StoredProcedure
                Command.Transaction = trans
                Command.Connection = trans.Connection

                Command.Parameters.AddWithValue("@PartID", PartID)


                Dim Adapter As New SqlClient.SqlDataAdapter(Command)
                Dim returnDS As New DataSet
                Adapter.Fill(returnDS)

                Dim dt As DataTable = returnDS.Tables(0)

                Return New DataView(dt)

            End Function

            Public Function Supplier_GetSecondaryPrice(ByVal SupplierID As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@SupplierID", SupplierID, True)
                Dim hasSecondaryPrice As Integer = _database.SP_ExecuteScalar("Supplier_HasSecondaryPrice")

                Return CBool(hasSecondaryPrice)
            End Function

#End Region

        End Class

    End Namespace

End Namespace


