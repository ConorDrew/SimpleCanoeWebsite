Imports System.Data.SqlClient

Namespace Entity

    Namespace SiteCustomerAudits

        Public Class SiteCustomerAuditSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"


            Public Function [SiteCustomerAudit_GetAll](ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("SiteCustomerAudit_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblSite.ToString
                Return New DataView(dt)

            End Function

            Public Function [Insert](ByVal oSiteCustomerAudit As SiteCustomerAudit) As SiteCustomerAudit
                _database.ClearParameter()
                AddSiteCustomerAuditParametersToCommand(oSiteCustomerAudit)

                oSiteCustomerAudit.SetSiteCustomerAuditID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("SiteCustomerAudit_Insert"))
                oSiteCustomerAudit.Exists = True
                Return oSiteCustomerAudit
            End Function



            Private Sub AddSiteCustomerAuditParametersToCommand(ByRef oSiteCustomerAudit As SiteCustomerAudit)
                With _database
                    .AddParameter("@SiteID", oSiteCustomerAudit.SiteID, True)
                    .AddParameter("@PreviousCustomerID", oSiteCustomerAudit.PreviousCustomerID, True)
                    .AddParameter("@DateChanged", oSiteCustomerAudit.DateChanged, True)
                    .AddParameter("@UserID", oSiteCustomerAudit.UserID, True)
                End With
            End Sub


#End Region

        End Class

    End Namespace

End Namespace


