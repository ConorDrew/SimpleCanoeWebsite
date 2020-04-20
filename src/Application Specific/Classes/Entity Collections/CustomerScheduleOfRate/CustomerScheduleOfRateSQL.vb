Imports System.Data.SqlClient

Namespace Entity

    Namespace CustomerScheduleOfRates

        Public Class CustomerScheduleOfRateSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal CustomerScheduleOfRateID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CustomerScheduleOfRateID", CustomerScheduleOfRateID, True)
                _database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Delete")
            End Sub

            Public Function [Get](ByVal CustomerScheduleOfRateID As Integer) As CustomerScheduleOfRate
                _database.ClearParameter()
                _database.AddParameter("@CustomerScheduleOfRateID", CustomerScheduleOfRateID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oCustomerScheduleOfRate As New CustomerScheduleOfRate
                        With oCustomerScheduleOfRate
                            .IgnoreExceptionsOnSetMethods = True
                            .SetCustomerScheduleOfRateID = dt.Rows(0).Item("CustomerScheduleOfRateID")
                            .SetCustomerID = dt.Rows(0).Item("CustomerID")
                            .SetScheduleOfRatesCategoryID = dt.Rows(0).Item("ScheduleOfRatesCategoryID")
                            .SetCode = dt.Rows(0).Item("Code")
                            .SetDescription = dt.Rows(0).Item("Description")
                            .SetPrice = dt.Rows(0).Item("Price")
                            .SetTimeInMins = Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("TimeInMins"))
                            .SetAllowDeleted = dt.Rows(0).Item("AllowDeleted")

                            .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oCustomerScheduleOfRate.Exists = True
                        Return oCustomerScheduleOfRate
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [GetAll_For_CustomerID](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_For_CustomerID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [GetAll_For_SiteID](ByVal siteId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", siteId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_For_SiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [GetAll_WithoutDefaults](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_GetAll_WithoutDefaults")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [Customer_Jobtype_Sor_Get](ByVal CustomerID As Integer, ByVal JobTypeID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@JobTypeID", JobTypeID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_JobType_Sor_Get")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [Customer_Jobtype_Sor_GetAll]() As DataView
                _database.ClearParameter()

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_JobType_Sor_GetALL")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [Customer_Jobtype_Sor_Insert](ByVal CustomerID As Integer, ByVal JobTypeID As Integer, ByVal CustomerScheduleOfRateID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.AddParameter("@JobTypeID", JobTypeID, True)
                _database.AddParameter("@CustomerScheduleOfRateID", CustomerScheduleOfRateID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_JobType_Sor_Insert")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [Customer_Jobtype_Sor_Delete](ByVal CustomerJobTypeSORID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerJobTypeSORID", CustomerJobTypeSORID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Customer_JobType_Sor_Delete")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oCustomerScheduleOfRate As CustomerScheduleOfRate) As CustomerScheduleOfRate
                _database.ClearParameter()
                AddCustomerScheduleOfRateParametersToCommand(oCustomerScheduleOfRate)

                oCustomerScheduleOfRate.SetCustomerScheduleOfRateID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("CustomerScheduleOfRate_Insert"))
                oCustomerScheduleOfRate.Exists = True
                Return oCustomerScheduleOfRate
            End Function

            Public Sub [Update](ByVal oCustomerScheduleOfRate As CustomerScheduleOfRate)
                _database.ClearParameter()
                _database.AddParameter("@CustomerScheduleOfRateID", oCustomerScheduleOfRate.CustomerScheduleOfRateID, True)
                AddCustomerScheduleOfRateParametersToCommand(oCustomerScheduleOfRate)
                _database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Update")
            End Sub

            Private Sub AddCustomerScheduleOfRateParametersToCommand(ByRef oCustomerScheduleOfRate As CustomerScheduleOfRate)
                With _database
                    .AddParameter("@CustomerID", oCustomerScheduleOfRate.CustomerID, True)
                    .AddParameter("@ScheduleOfRatesCategoryID", oCustomerScheduleOfRate.ScheduleOfRatesCategoryID, True)
                    .AddParameter("@Code", oCustomerScheduleOfRate.Code, True)
                    .AddParameter("@Description", oCustomerScheduleOfRate.Description, True)
                    .AddParameter("@Price", oCustomerScheduleOfRate.Price, True)
                    .AddParameter("@TimeInMins", oCustomerScheduleOfRate.TimeInMins, True)
                    .AddParameter("@AllowDeleted", oCustomerScheduleOfRate.AllowDeleted, True)
                End With
            End Sub

            Public Sub Insert_Defaults(ByVal CustomerID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)
                _database.ExecuteSP_NO_Return("CustomerScheduleOfRate_Insert_Defaults")
            End Sub

            Public Sub CustomerScheduleOfRates_UpdateForALL(ByVal Price As Decimal,
                                                                         ByVal Description As String,
                                                                         ByVal Code As String,
                                                                         ByVal ScheduleOfRatesCategoryID As Integer,
                                                                         ByVal TimeInMins As Integer)

                _database.ClearParameter()

                _database.AddParameter("@Price", Price, True)
                _database.AddParameter("@Description", Description, True)
                _database.AddParameter("@Code", Code, True)
                _database.AddParameter("@ScheduleOfRatesCategoryID", ScheduleOfRatesCategoryID, True)
                _database.AddParameter("@TimeInMins", TimeInMins, True)

                _database.ExecuteSP_NO_Return("CustomerScheduleOfRates_UpdateForALL")
            End Sub

            Public Function CustomerScheduleOfRates_GetALL_Labour(ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerScheduleOfRates_GetALL_Labour")
                dt.TableName = Entity.Sys.Enums.TableNames.tblCustomerScheduleOfRate.ToString
                Return New DataView(dt)
            End Function

            Public Function Exists(ByVal ScheduleOfRatesCategoryID As Integer, ByVal Description As String, ByVal Code As String, ByVal customerId As Integer) As DataTable
                _database.ClearParameter()
                _database.AddParameter("@ScheduleOfRatesCategoryID", ScheduleOfRatesCategoryID, True)
                _database.AddParameter("@Description", Description, True)
                _database.AddParameter("@Code", Code, True)
                _database.AddParameter("@CustomerID", customerId, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("CustomerScheduleOfRate_Exists")
                Return dt
            End Function

#End Region

        End Class

    End Namespace

End Namespace