Imports System.Data.SqlClient

Namespace Entity

    Namespace CustomerCharges

        Public Class CustomerChargeSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal CustomerChargeID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CustomerChargeID", CustomerChargeID, True)
                _database.ExecuteSP_NO_Return("CustomerCharge_Delete")
            End Sub

            Public Function [CustomerCharge_Get](ByVal CustomerChargeID As Integer) As CustomerCharge
                _database.ClearParameter()
                _database.AddParameter("@CustomerChargeID", CustomerChargeID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerCharge_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomerCharge As New CustomerCharge
                        With oCustomerCharge
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerChargeID = dt.Rows(0).Item("CustomerChargeID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetMileageRate = dt.Rows(0).Item("MileageRate")
                            .SetPartsMarkup = dt.Rows(0).Item("PartsMarkup")
                            .SetRatesMarkup = dt.Rows(0).Item("RatesMarkup")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oCustomerCharge.Exists = True
                        Return oCustomerCharge
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [CustomerCharge_GetForCustomer](ByVal CustomerID As Integer) As CustomerCharge
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerCharge_GetForCustomer")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomerCharge As New CustomerCharge
                        With oCustomerCharge
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerChargeID = dt.Rows(0).Item("CustomerChargeID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetMileageRate = dt.Rows(0).Item("MileageRate")
                            .SetPartsMarkup = dt.Rows(0).Item("PartsMarkup")
                            .SetRatesMarkup = dt.Rows(0).Item("RatesMarkup")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oCustomerCharge.Exists = True
                        Return oCustomerCharge
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [CustomerCharge_GetForSite](ByVal siteId As Integer) As CustomerCharge
                _database.ClearParameter()
                _database.AddParameter("@SiteID", siteId)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerCharge_GetForSite")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomerCharge As New CustomerCharge
                        With oCustomerCharge
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerChargeID = dt.Rows(0).Item("CustomerChargeID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetMileageRate = dt.Rows(0).Item("MileageRate")
                            .SetPartsMarkup = dt.Rows(0).Item("PartsMarkup")
                            .SetRatesMarkup = dt.Rows(0).Item("RatesMarkup")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oCustomerCharge.Exists = True
                        Return oCustomerCharge
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [CustomerCharge_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerCharge_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomerCharge.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oCustomerCharge As CustomerCharge) As CustomerCharge
                _database.ClearParameter()
                AddCustomerChargeParametersToCommand(oCustomerCharge)

                oCustomerCharge.SetCustomerChargeID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CustomerCharge_Insert"))
                oCustomerCharge.Exists = True
                Return oCustomerCharge
            End Function

            Public Sub [Update](ByVal oCustomerCharge As CustomerCharge)
                _database.ClearParameter()
                AddCustomerChargeParametersToCommand(oCustomerCharge)
                _database.ExecuteSP_NO_Return("CustomerCharge_Update")
            End Sub

            Public Sub [UpdateALL](ByVal MileageRate As Double, ByVal PartsMarkup As Double, ByVal RatesMarkup As Double)
                _database.ClearParameter()
                _database.AddParameter("@MileageRate", MileageRate, True)
                _database.AddParameter("@PartsMarkup", PartsMarkup, True)
                _database.AddParameter("@RatesMarkup", RatesMarkup, True)
                _database.ExecuteSP_NO_Return("CustomerCharge_UpdateALL")
            End Sub

            Private Sub AddCustomerChargeParametersToCommand(ByRef oCustomerCharge As CustomerCharge)
                With _database
                    .AddParameter("@CustomerID", oCustomerCharge.CustomerID, True)
                    .AddParameter("@MileageRate", oCustomerCharge.MileageRate, True)
                    .AddParameter("@PartsMarkup", oCustomerCharge.PartsMarkup, True)
                    .AddParameter("@RatesMarkup", oCustomerCharge.RatesMarkup, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace