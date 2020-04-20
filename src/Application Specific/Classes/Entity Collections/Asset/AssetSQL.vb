Imports System.Data.SqlClient

Namespace Entity

    Namespace Assets

        Public Class AssetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal AssetID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@AssetID", AssetID, True)
                _database.ExecuteSP_NO_Return("Asset_Delete")
            End Sub

            Public Function [Asset_Get](ByVal AssetID As Integer) As Asset
                _database.ClearParameter()
                _database.AddParameter("@AssetID", AssetID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Asset_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oAsset As New Asset
                        With oAsset
                            .IgnoreExceptionsOnSetMethods = True
                            .SetAssetID = dt.Rows(0).Item("AssetID")
                            .SetPropertyID = dt.Rows(0).Item("SiteID")
                            .SetGasTypeID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("GasTypeID"))
                            .SetFlueTypeID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("FlueTypeID"))
                            .SetProductID = dt.Rows(0).Item("ProductID")
                            .SetSerialNum = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("SerialNum"))
                            If IsDBNull(dt.Rows(0).Item("DateFitted")) Then
                                .DateFitted = Date.MinValue
                            Else
                                .DateFitted = CDate(dt.Rows(0).Item("DateFitted"))
                            End If
                            If IsDBNull(dt.Rows(0).Item("CertificateLastIssued")) Then
                                .CertificateLastIssued = Date.MinValue
                            Else
                                .CertificateLastIssued = CDate(dt.Rows(0).Item("CertificateLastIssued"))
                            End If

                            If IsDBNull(dt.Rows(0).Item("LastServicedDate")) Then
                                .LastServicedDate = Date.MinValue
                            Else
                                .LastServicedDate = CDate(dt.Rows(0).Item("LastServicedDate"))
                            End If

                            If IsDBNull(dt.Rows(0).Item("WarrantyStartDate")) Then
                                .WarrantyStartDate = Date.MinValue
                            Else
                                .WarrantyStartDate = CDate(dt.Rows(0).Item("WarrantyStartDate"))
                            End If

                            If IsDBNull(dt.Rows(0).Item("WarrantyEndDate")) Then
                                .WarrantyEndDate = Date.MinValue
                            Else
                                .WarrantyEndDate = CDate(dt.Rows(0).Item("WarrantyEndDate"))
                            End If

                            .SetBoughtFrom = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("BoughtFrom"))
                            .SetSuppliedBy = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("SuppliedBy"))
                            .SetLocation = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Location"))
                            .SetNotes = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Notes"))
                            .SetGCNumber = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("GCNumber"))
                            .SetYearOfManufacture = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("YearOfManufacture"))
                            .SetApproximateValue = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("ApproximateValue"))
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetActive = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Active"))
                            .SetTenantsAppliance = Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("TenantsAppliance"))
                        End With
                        oAsset.Exists = True
                        Return oAsset
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Check_Unique_Serial(ByVal Serial As String, ByVal ID As Integer) As Boolean
                Dim NumberOfAssets As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(AssetID) as 'NumberOfAssets' " &
                "FROM tblasset WHERE SerialNum = '" & Serial & "' AND AssetID <> " & ID, False))

                If NumberOfAssets = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Public Function [Asset_GetAll](ByVal userID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@UserID", userID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Asset_GetAll_Mk1")
                dt.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function [Asset_GetForCustomer](ByVal CustomerID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CustomerID", CustomerID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("[Asset_GetForCustomer]")
                dt.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function [Asset_GetForSite](ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("[Asset_GetForSite]")
                dt.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function [Asset_Search](ByVal Criteria As String, Optional ByVal RegionID As Integer = 0) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SearchString", Criteria, True)
                _database.AddParameter("@RegionID", RegionID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("[Asset_SearchList]")
                dt.TableName = Entity.Sys.Enums.TableNames.tblAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oAsset As Asset) As Asset
                _database.ClearParameter()
                AddAssetParametersToCommand(oAsset)

                oAsset.SetAssetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Asset_Insert"))
                oAsset.Exists = True
                Return oAsset
            End Function

            Public Sub [Update](ByVal oAsset As Asset)
                _database.ClearParameter()
                _database.AddParameter("@AssetID", oAsset.AssetID, True)
                AddAssetParametersToCommand(oAsset)
                _database.ExecuteSP_NO_Return("Asset_Update")
            End Sub

            Private Sub AddAssetParametersToCommand(ByRef oAsset As Asset)
                With _database
                    .AddParameter("@SiteID", oAsset.PropertyID, True)
                    .AddParameter("@ProductID", oAsset.ProductID, True)
                    .AddParameter("@SerialNum", oAsset.SerialNum, True)
                    If oAsset.DateFitted = Date.MinValue Or oAsset.DateFitted = Nothing Then
                        .AddParameter("@DateFitted", DBNull.Value, True)
                    Else
                        .AddParameter("@DateFitted", oAsset.DateFitted, True)
                    End If

                    .AddParameter("@Location", oAsset.Location, True)

                    If oAsset.CertificateLastIssued = Date.MinValue Or oAsset.CertificateLastIssued = Nothing Then
                        .AddParameter("@CertificateLastIssued", DBNull.Value, True)
                    Else
                        .AddParameter("@CertificateLastIssued", oAsset.CertificateLastIssued, True)
                    End If

                    If oAsset.LastServicedDate = Date.MinValue Or oAsset.LastServicedDate = Nothing Then
                        .AddParameter("@LastServicedDate", DBNull.Value, True)
                    Else
                        .AddParameter("@LastServicedDate", oAsset.LastServicedDate, True)
                    End If

                    If oAsset.WarrantyStartDate = Date.MinValue Or oAsset.WarrantyStartDate = Nothing Then
                        .AddParameter("@WarrantyStartDate", DBNull.Value, True)
                    Else
                        .AddParameter("@WarrantyStartDate", oAsset.WarrantyStartDate, True)
                    End If

                    If oAsset.WarrantyEndDate = Date.MinValue Or oAsset.WarrantyEndDate = Nothing Then
                        .AddParameter("@WarrantyEndDate", DBNull.Value, True)
                    Else
                        .AddParameter("@WarrantyEndDate", oAsset.WarrantyEndDate, True)
                    End If

                    .AddParameter("@BoughtFrom", oAsset.BoughtFrom, True)
                    .AddParameter("@SuppliedBy", oAsset.SuppliedBy, True)

                    .AddParameter("@Notes", oAsset.Notes, True)

                    .AddParameter("@GCNumber", oAsset.GCNumber, True)
                    .AddParameter("@YearOfManufacture", oAsset.YearOfManufacture, True)
                    .AddParameter("@ApproximateValue", oAsset.ApproximateValue, True)
                    .AddParameter("@GasTypeID", oAsset.GasTypeID, True)
                    .AddParameter("@FlueTypeID", oAsset.FlueTypeID, True)
                    .AddParameter("@Active", oAsset.Active, True)
                    .AddParameter("@TenantsAppliance", oAsset.TenantsAppliance, True)

                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace