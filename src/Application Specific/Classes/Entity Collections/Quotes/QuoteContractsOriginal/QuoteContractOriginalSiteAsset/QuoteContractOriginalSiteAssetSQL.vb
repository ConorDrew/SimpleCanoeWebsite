Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOriginalSiteAssets

        Public Class QuoteContractOriginalSiteAssetSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Sub Delete(ByVal QuoteContractSiteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)
                _database.ExecuteSP_NO_Return("QuoteContractOriginalSiteAsset_Delete")
            End Sub

            Public Function QuoteContractSiteAsset_GetAll_QuoteContractSiteID(ByVal QuoteContractSiteID As Integer, _
                                                                            ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID, True)
                _database.AddParameter("@SiteID", SiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOriginalSiteAsset_GetAll_QuoteContractSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractSiteAsset.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oQuoteContractSiteAsset As QuoteContractOriginalSiteAsset) As QuoteContractOriginalSiteAsset
                _database.ClearParameter()
                AddQuoteContractSiteAssetParametersToCommand(oQuoteContractSiteAsset)

                oQuoteContractSiteAsset.SetQuoteContractSiteAssetID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOriginalSiteAsset_Insert"))
                oQuoteContractSiteAsset.Exists = True
                Return oQuoteContractSiteAsset
            End Function

            Private Sub AddQuoteContractSiteAssetParametersToCommand(ByRef oQuoteContractSiteAsset As QuoteContractOriginalSiteAsset)
                With _database
                    .AddParameter("@QuoteContractSiteID", oQuoteContractSiteAsset.QuoteContractSiteID, True)
                    .AddParameter("@AssetID", oQuoteContractSiteAsset.AssetID, True)
                    .AddParameter("@PricePerVisit", oQuoteContractSiteAsset.PricePerVisit, True)



                End With
            End Sub


#End Region

        End Class

    End Namespace

End Namespace


