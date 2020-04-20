Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractAlternativeSiteAssets

        Public Class ContractAlternativeSiteAssetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_SiteID(ByVal SiteID As Integer) As DataView
                _database.ClearParameter()

                _database.AddParameter("@SiteID", SiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteAsset_GetAll_SiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_JobItemID(ByVal ContractSiteJobItemID As Integer) As DataView
                _database.ClearParameter()

                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractAlternativeSiteAsset_GetAll_JobItemID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oContractSiteAsset As ContractAlternativeSiteAsset) As ContractAlternativeSiteAsset
                _database.ClearParameter()
                AddContractSiteAssetParametersToCommand(oContractSiteAsset)

                oContractSiteAsset.SetContractSiteAssetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractAlternativeSiteAsset_Insert"))
                oContractSiteAsset.Exists = True
                Return oContractSiteAsset
            End Function

            Public Sub Delete(ByVal ContractSiteJobItemID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteJobItemID", ContractSiteJobItemID, True)
                _database.ExecuteSP_NO_Return("ContractAlternativeSiteAsset_Delete")
            End Sub

            Private Sub AddContractSiteAssetParametersToCommand(ByRef oContractSiteAsset As ContractAlternativeSiteAsset)
                With _database
                    .AddParameter("@ContractSiteJobItemID", oContractSiteAsset.ContractSiteJobItemID, True)
                    .AddParameter("@AssetID", oContractSiteAsset.AssetID, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


