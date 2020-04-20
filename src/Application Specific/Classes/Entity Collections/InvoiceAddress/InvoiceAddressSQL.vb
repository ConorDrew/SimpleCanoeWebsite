Imports System.Data.SqlClient

Namespace Entity

    Namespace InvoiceAddresss

        Public Class InvoiceAddressSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Sub Delete(ByVal InvoiceAddressID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@InvoiceAddressID", InvoiceAddressID, True)
                _database.ExecuteSP_NO_Return("InvoiceAddress_Delete")
            End Sub

            Public Function [InvoiceAddress_Get](ByVal InvoiceAddressID As Integer) As InvoiceAddress
                _database.ClearParameter()
                _database.AddParameter("@InvoiceAddressID", InvoiceAddressID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceAddress_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oInvoiceAddress As New InvoiceAddress
                        With oInvoiceAddress
                            .IgnoreExceptionsOnSetMethods = True
                            .SetInvoiceAddressID = dt.Rows(0).Item("InvoiceAddressID")
                            .SetAddress1 = dt.Rows(0).Item("Address1")
                            .SetAddress2 = dt.Rows(0).Item("Address2")
                            .SetAddress3 = dt.Rows(0).Item("Address3")
                            .SetAddress4 = dt.Rows(0).Item("Address4")
                            .SetAddress5 = dt.Rows(0).Item("Address5")
                            .SetPostcode = dt.Rows(0).Item("Postcode")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetSiteID = dt.Rows(0).Item("SiteID")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oInvoiceAddress.Exists = True
                        Return oInvoiceAddress
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [InvoiceAddress_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceAddress_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
                Return New DataView(dt)
            End Function

            Public Function InvoiceAddress_Get_EngineerVisitID(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@SiteEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Site), True)
                _database.AddParameter("@HQEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.HQ), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceAddress_Get_EngineerVisitID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
                Return New DataView(dt)
            End Function

            Public Function InvoiceAddress_Get_CustomerID(ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@SiteEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Site), True)
                _database.AddParameter("@HQEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.HQ), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceAddress_Get_CustomerID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
                Return New DataView(dt)
            End Function

            Public Function InvoiceAddress_Get_SiteID(ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@SiteEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Site), True)
                _database.AddParameter("@HQEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.HQ), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceAddress_Get_SiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
                Return New DataView(dt)
            End Function

            Public Function InvoiceAddress_Get_OrderID(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                _database.AddParameter("@InvoiceEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Invoice), True)
                _database.AddParameter("@SiteEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.Site), True)
                _database.AddParameter("@HQEnumVal", CInt(Entity.Sys.Enums.InvoiceAddressType.HQ), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceAddress_Get_OrderID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oInvoiceAddress As InvoiceAddress) As InvoiceAddress
                _database.ClearParameter()
                AddInvoiceAddressParametersToCommand(oInvoiceAddress)

                oInvoiceAddress.SetInvoiceAddressID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("InvoiceAddress_Insert"))
                oInvoiceAddress.Exists = True
                Return oInvoiceAddress
            End Function

            Public Function InvoiceAddress_GetForSite(ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceAddress_GetForSite")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
                Return New DataView(dt)
            End Function

            Public Function [InvoiceAddress_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoiceAddress_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString
                Return New DataView(dt)
            End Function


            Public Sub [Update](ByVal oInvoiceAddress As InvoiceAddress)
                _database.ClearParameter()
                _database.AddParameter("@InvoiceAddressID", oInvoiceAddress.InvoiceAddressID, True)
                AddInvoiceAddressParametersToCommand(oInvoiceAddress)
                _database.ExecuteSP_NO_Return("InvoiceAddress_Update")
            End Sub



            Private Sub AddInvoiceAddressParametersToCommand(ByRef oInvoiceAddress As InvoiceAddress)
                With _database
                    .AddParameter("@Address1", oInvoiceAddress.Address1, True)
                    .AddParameter("@Address2", oInvoiceAddress.Address2, True)
                    .AddParameter("@Address3", oInvoiceAddress.Address3, True)
                    .AddParameter("@Address4", oInvoiceAddress.Address4, True)
                    .AddParameter("@Address5", oInvoiceAddress.Address5, True)
                    .AddParameter("@Postcode", oInvoiceAddress.Postcode, True)
                    .AddParameter("@TelephoneNum", oInvoiceAddress.TelephoneNum, True)
                    .AddParameter("@FaxNum", oInvoiceAddress.FaxNum, True)
                    .AddParameter("@EmailAddress", oInvoiceAddress.EmailAddress, True)
                    .AddParameter("@SiteID", oInvoiceAddress.SiteID, True)
                End With
            End Sub


#End Region

        End Class

    End Namespace

End Namespace


