Imports System.Data.SqlClient

Namespace Entity

    Namespace ContractOption3SiteAsset

        Public Class ContractOption3AssetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function ContractOption3SiteAssetDuration_GetAll_ForContractSiteID(ByVal ContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("ContractOption3SiteAssetDuration_GetAll_ForSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractOption3SiteAsset.ToString
                Return New DataView(dt)
            End Function

            Public Sub ContractOption3SiteAssetDuration_Delete(ByVal ContractSiteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContractSiteID", ContractSiteID)
                _database.ExecuteSP_NO_Return("ContractOption3SiteAssetDuration_Delete")
            End Sub

            Public Function [Insert](ByVal oContractOption3SiteAsset As ContractOption3SiteAsset) As ContractOption3SiteAsset
                _database.ClearParameter()
                AddContractOption3SiteAssetParametersToCommand(oContractOption3SiteAsset)

                oContractOption3SiteAsset.SetContractSiteAssetDurationID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("ContractOption3SiteAssetDuration_Insert"))
                oContractOption3SiteAsset.Exists = True
                Return oContractOption3SiteAsset
            End Function

            Private Sub AddContractOption3SiteAssetParametersToCommand(ByRef oContractOption3SiteAsset As ContractOption3SiteAsset)
                With _database
                    .AddParameter("@ContractSiteID", oContractOption3SiteAsset.ContractSiteID, True)
                    .AddParameter("@AssetID", oContractOption3SiteAsset.AssetID, True)
                    .AddParameter("@ScheduledMonth", oContractOption3SiteAsset.ScheduledMonth, True)
                    .AddParameter("@VisitDuration", oContractOption3SiteAsset.VisitDuration, True)

                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace
