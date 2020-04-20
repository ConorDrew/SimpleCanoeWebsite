Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOriginalSiteAssets

        Public Class ContractOriginalSiteAssetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_ContractSiteID(ByVal ContractSiteID As Integer, ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.AddParameter("@SiteID", SiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOriginalSiteAsset_GetAll_ContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oContractSiteAsset As ContractOriginalSiteAsset) As ContractOriginalSiteAsset
                _database.ClearParameter()
                AddContractSiteAssetParametersToCommand(oContractSiteAsset)

                oContractSiteAsset.SetContractSiteAssetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOriginalSiteAsset_Insert"))
                oContractSiteAsset.Exists = True
                Return oContractSiteAsset
            End Function

            Public Sub Delete(ByVal ContractSiteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID, True)
                _database.ExecuteSP_NO_Return("ContractOriginalSiteAsset_Delete")
            End Sub

            Private Sub AddContractSiteAssetParametersToCommand(ByRef oContractSiteAsset As ContractOriginalSiteAsset)
                With _database
                    .AddParameter("@ContractSiteID", oContractSiteAsset.ContractSiteID, True)
                    .AddParameter("@AssetID", oContractSiteAsset.AssetID, True)
                    .AddParameter("@PricePerVisit", oContractSiteAsset.PricePerVisit, True)
                    .AddParameter("@PrimaryAsset", oContractSiteAsset.PrimaryAsset, True)
                    .AddParameter("@Type", oContractSiteAsset.Type, True)
                    .AddParameter("@Product", oContractSiteAsset.Product, True)

                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


