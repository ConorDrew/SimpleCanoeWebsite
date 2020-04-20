Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOption3s

        Public Class ContractOption3SQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal ContractID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)
                _database.ExecuteSP_NO_Return("ContractOption3_Delete")
            End Sub

            Public Function [ContractOption3_Get](ByVal ContractID As Integer) As ContractOption3
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOption3_Get")

                If Not dt Is Nothing Then
                    If dt.rows.count > 0 Then
                        Dim oContractOption3 As New ContractOption3
                        With oContractOption3
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractID = dt.Rows(0).Item("ContractID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetContractReference = dt.Rows(0).Item("ContractReference")
                            .SetContractStatusID = dt.Rows(0).Item("ContractStatusID")
                            .SetContractPrice = dt.Rows(0).Item("ContractPrice")
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                        End With
                        oContractOption3.Exists = True
                        Return oContractOption3
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function ContractCalculatedTotal(ByVal ContractID As Integer) As Double
                _database.ClearParameter()
                _database.AddParameter("@ContractID", ContractID, True)

                Return Entity.Sys.Helper.MakeDoubleValid(_database.ExecuteSP_OBJECT("ContractOptionCalculatedTotal"))
            End Function

            Public Function [ContractOption3_Get_For_Quote_ID](ByVal QuoteContractID As Integer) As ContractOption3
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractID", QuoteContractID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOption3_Get_For_Quote_ID")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContractOption3 As New ContractOption3
                        With oContractOption3
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContractID = dt.Rows(0).Item("ContractID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetContractReference = dt.Rows(0).Item("ContractReference")
                            .SetContractStatusID = dt.Rows(0).Item("ContractStatusID")
                            .SetContractPrice = dt.Rows(0).Item("ContractPrice")
                            .SetQuoteContractID = dt.Rows(0).Item("QuoteContractID")
                        End With
                        oContractOption3.Exists = True
                        Return oContractOption3
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [ContractOption3_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOption3_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractOption3.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oContractOption3 As ContractOption3) As ContractOption3
                _database.ClearParameter()
                AddContractOption3ParametersToCommand(oContractOption3)

                oContractOption3.SetContractID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOption3_Insert"))
                oContractOption3.Exists = True
                Return oContractOption3
            End Function

            Public Sub [Update](ByVal oContractOption3 As ContractOption3)
                _database.ClearParameter()
                _database.AddParameter("@ContractID", oContractOption3.ContractID, True)
                AddContractOption3ParametersToCommand(oContractOption3)
                _database.ExecuteSP_NO_Return("ContractOption3_Update")
            End Sub

            Private Sub AddContractOption3ParametersToCommand(ByRef oContractOption3 As ContractOption3)
                With _database
                    .AddParameter("@CustomerID", oContractOption3.CustomerID, True)
                    .AddParameter("@ContractReference", oContractOption3.ContractReference, True)
                    .AddParameter("@ContractStatusID", oContractOption3.ContractStatusID, True)
                    .AddParameter("@ContractPrice", oContractOption3.ContractPrice, True)
                    .AddParameter("@QuoteContractID", oContractOption3.QuoteContractID, True)

                End With
            End Sub

            Public Function ContractReference_Get(ByVal prefix As String, ByVal postfix As String) As DataTable
                Dim maxNumRef As Integer = 0
                Dim dtReturn As New DataTable
                dtReturn.Columns.Add("REF")

                _database.ClearParameter()
                _database.AddParameter("@PREFIX", prefix, True)
                _database.AddParameter("@POSTFIX", postfix, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractReference_Get")

                If dt.Rows.Count > 0 Then
                    maxNumRef = dt.Rows(0).Item("Numpart")
                End If

                Dim cnt As Integer = 0
                For i As Integer = 1 To maxNumRef - 1
                    If dt.Select("Numpart=" & i).Length = 0 Then
                        Dim nr As DataRow
                        nr = dtReturn.NewRow
                        nr("REF") = i
                        dtReturn.Rows.Add(nr)
                        cnt += 1
                        If cnt >= 10 Then
                            Exit For
                        End If
                    End If
                Next i

                Dim extraRw As DataRow
                extraRw = dtReturn.NewRow
                extraRw("REF") = maxNumRef + 1
                dtReturn.Rows.Add(extraRw)
                dtReturn.TableName = Entity.Sys.Enums.TableNames.tblContractOption3.ToString
                Return dtReturn
            End Function

            Public Function ContractReference_CheckUnique(ByVal ContractReference As String, ByVal customerID As Integer) As Boolean

                _database.ClearParameter()
                _database.AddParameter("@ContractReference", ContractReference, True)
                _database.AddParameter("@customerID", customerID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractReference_CheckUnique")
                If dt.Rows.Count > 0 Then
                    Return False ' Not unique
                Else
                    Return True
                End If
            End Function

#End Region

        End Class

    End Namespace

End Namespace


