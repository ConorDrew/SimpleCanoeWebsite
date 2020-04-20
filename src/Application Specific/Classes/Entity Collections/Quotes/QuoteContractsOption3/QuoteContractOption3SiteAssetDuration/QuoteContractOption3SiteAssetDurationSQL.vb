Imports System.Data.SqlClient

Namespace Entity

    Namespace QuoteContractOption3SiteAssetDurations

        Public Class QuoteContractOption3SiteAssetDurationSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function QuoteContractOption3SiteAssetDuration_GetAll_ForQuoteContractSiteID(ByVal QuoteContractSiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("QuoteContractOption3SiteAssetDuration_GetAll_ForSiteID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblQuoteContractOption3SiteAsset.ToString
                Return New DataView(dt)
            End Function

            Public Sub QuoteContractOption3SiteAssetDuration_Delete(ByVal QuoteContractSiteID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@QuoteContractSiteID", QuoteContractSiteID)
                _database.ExecuteSP_NO_Return("QuoteContractOption3SiteAssetDuration_Delete")
            End Sub

            Public Function [Insert](ByVal oQuoteContractOption3SiteAsset As QuoteContractOption3SiteAssetDuration) As QuoteContractOption3SiteAssetDuration
                _database.ClearParameter()
                AddQuoteContractOption3SiteAssetParametersToCommand(oQuoteContractOption3SiteAsset)

                oQuoteContractOption3SiteAsset.SetQuoteContractSiteAssetDurationID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("QuoteContractOption3SiteAssetDuration_Insert"))
                oQuoteContractOption3SiteAsset.Exists = True
                Return oQuoteContractOption3SiteAsset
            End Function

            Private Sub AddQuoteContractOption3SiteAssetParametersToCommand(ByRef oQuoteContractOption3SiteAsset As QuoteContractOption3SiteAssetDuration)
                With _database
                    .AddParameter("@QuoteContractSiteID", oQuoteContractOption3SiteAsset.QuoteContractSiteID, True)
                    .AddParameter("@AssetID", oQuoteContractOption3SiteAsset.AssetID, True)
                    .AddParameter("@ScheduledMonth", oQuoteContractOption3SiteAsset.ScheduledMonth, True)
                    .AddParameter("@VisitDuration", oQuoteContractOption3SiteAsset.VisitDuration, True)

                End With
            End Sub

#End Region

        End Class

    End Namespace

End Namespace


