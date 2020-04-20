Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractAlternativeSiteAssets

        Public Class QuoteContractAlternativeSiteAssetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function GetAll_SiteID(ByVal SiteID As Integer) As DataView
                _database.ClearParameter()

                _database.AddParameter("@SiteID", SiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteAsset_GetAll_SiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAll_JobItemID(ByVal QuoteContractSiteJobItemID As Integer) As DataView
                _database.ClearParameter()

                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractAlternativeSiteAsset_GetAll_JobItemID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContractSiteAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function Insert(ByVal oQuoteContractSiteAsset As QuoteContractAlternativeSiteAsset) As QuoteContractAlternativeSiteAsset
                _database.ClearParameter()
                AddContractSiteAssetParametersToCommand(oQuoteContractSiteAsset)

                oQuoteContractSiteAsset.SetQuoteContractSiteAssetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractAlternativeSiteAsset_Insert"))
                oQuoteContractSiteAsset.Exists = True
                Return oQuoteContractSiteAsset
            End Function

            Public Sub Delete(ByVal QuoteContractSiteJobItemID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteJobItemID", QuoteContractSiteJobItemID, True)
                _database.ExecuteSP_NO_Return("QuoteContractAlternativeSiteAsset_Delete")
            End Sub

            Private Sub AddContractSiteAssetParametersToCommand(ByRef oQuoteContractSiteAsset As QuoteContractAlternativeSiteAsset)
                With _database
                    .AddParameter("@QuoteContractSiteJobItemID", oQuoteContractSiteAsset.QuoteContractSiteJobItemID, True)
                    .AddParameter("@AssetID", oQuoteContractSiteAsset.AssetID, True)
                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


