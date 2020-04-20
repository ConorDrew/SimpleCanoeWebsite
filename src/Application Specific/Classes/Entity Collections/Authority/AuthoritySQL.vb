Imports System.Data.SqlClient

Namespace Entity

    Namespace Authority

        Public Class AuthoritySQL

            Public Enum GetBy
                SiteId = 1
                CustomerId = 2
            End Enum

            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Site"

            Public Sub Delete(ByVal authorityId As Integer)
                _database.ClearParameter()
                _database.AddParameter("@AuthorityId", authorityId, True)
                _database.ExecuteSP_NO_Return("Authority_Delete")
            End Sub

            Public Function [Get](ByVal ref As Object, Optional ByVal getBy As GetBy = GetBy.SiteId) As Authority
                _database.ClearParameter()

                'Get the datatable from the database store in dt
                Dim dt As DataTable = Nothing
                Select Case getBy
                    Case GetBy.CustomerId
                        _database.AddParameter("@CustomerId", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                        dt = _database.ExecuteSP_DataTable("Authority_Get_ByCustomerId")

                    Case GetBy.SiteId
                        _database.AddParameter("@SiteId", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                        dt = _database.ExecuteSP_DataTable("Authority_Get_BySiteId")

                    Case Else
                        _database.AddParameter("@AuthorityId", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                        dt = _database.ExecuteSP_DataTable("Authority_Get")
                End Select

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oAuthority As New Authority
                        With oAuthority
                            .IgnoreExceptionsOnSetMethods = True
                            If dt.Columns.Contains("AuthorityId") Then .SetAuthorityId = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("AuthorityId"))
                            If dt.Columns.Contains("Notes") Then .SetNotes = Entity.Sys.Helper.MakeStringValid(dt.Rows(0)("Notes"))
                            If dt.Columns.Contains("DateAdded") Then .DateAdded = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0)("DateAdded"))
                            If dt.Columns.Contains("AddedById") Then .SetAddedById = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("AddedById"))
                            If dt.Columns.Contains("LastChanged") Then .LastChanged = Entity.Sys.Helper.MakeDateTimeValid(dt.Rows(0)("LastChanged"))
                            If dt.Columns.Contains("LastChangedById") Then .SetLastChangedById = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0)("LastChangedById"))
                        End With
                        oAuthority.Exists = True
                        Return oAuthority
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Insert](ByVal oAuthority As Authority) As Authority
                _database.ClearParameter()
                _database.AddParameter("@Notes", oAuthority.Notes, True)
                _database.AddParameter("@DateAdded", DateTime.Now, True)
                _database.AddParameter("@AddedById", loggedInUser.UserID, True)
                _database.AddParameter("@LastChanged", DateTime.Now, True)
                _database.AddParameter("@LastChangedById", loggedInUser.UserID, True)
                oAuthority.SetAuthorityId = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Authority_Insert"))
                oAuthority.Exists = True

                'INSERT AUDIT RECORD
                Dim change As String = "Added: " & oAuthority.Notes
                Audit_Insert(oAuthority.AuthorityId, change)
                Return oAuthority
            End Function

            Public Function [Insert_Site](ByVal siteId As Integer, ByVal oAuthority As Authority) As Boolean
                Try
                    Dim auth As Authority = Insert(oAuthority)
                    _database.ClearParameter()
                    _database.AddParameter("@SiteId", siteId, True)
                    _database.AddParameter("@AuthorityId", auth.AuthorityId, True)
                    _database.ExecuteSP_OBJECT("SiteAuthority_Insert")
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Function [Insert_Customer](ByVal customerId As Integer, ByVal oAuthority As Authority) As Boolean
                Try
                    Dim auth As Authority = Insert(oAuthority)
                    _database.ClearParameter()
                    _database.AddParameter("@CustomerId", customerId, True)
                    _database.AddParameter("@AuthorityId", auth.AuthorityId, True)
                    _database.ExecuteSP_OBJECT("CustomerAuthority_Insert")
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            End Function

            Public Sub [Update](ByVal oAuthority As Authority, ByVal change As String)
                _database.ClearParameter()
                _database.AddParameter("@AuthorityId", oAuthority.AuthorityId, True)
                _database.AddParameter("@Notes", oAuthority.Notes, True)
                _database.AddParameter("@LastChanged", DateTime.Now, True)
                _database.AddParameter("@LastChangedById", loggedInUser.UserID, True)
                _database.ExecuteSP_NO_Return("Authority_Update")

                'INSERT AUDIT RECORD
                If String.IsNullOrEmpty(change) Then Exit Sub
                Audit_Insert(oAuthority.AuthorityId, change)
            End Sub

            Public Sub [Audit_Insert](ByVal authorityId As Integer, ByVal actionChange As String)
                _database.ClearParameter()

                _database.AddParameter("@AuthorityId", authorityId, True)
                _database.AddParameter("@ActionChange", actionChange, True)
                _database.AddParameter("@ActionDateTime", DateTime.Now, True)
                _database.AddParameter("@UserId", loggedInUser.UserID, True)

                _database.ExecuteSP_NO_Return("AuthorityAudit_Insert")
            End Sub

            Public Function [Audit_Get](ByVal ref As Object, Optional ByVal getBy As GetBy = GetBy.SiteId) As DataView
                _database.ClearParameter()
                Dim dt As DataTable = Nothing
                Select Case getBy
                    Case GetBy.CustomerId
                        _database.AddParameter("@CustomerId", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                        dt = _database.ExecuteSP_DataTable("AuthorityAudit_Get_ByCustomerId")

                    Case GetBy.SiteId
                        _database.AddParameter("@SiteId", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                        dt = _database.ExecuteSP_DataTable("AuthorityAudit_Get_BySiteId")

                    Case Else
                        _database.AddParameter("@AuthorityId", Entity.Sys.Helper.MakeIntegerValid(ref), True)
                        dt = _database.ExecuteSP_DataTable("AuthorityAudit_Get")
                End Select

                dt.TableName = Sys.Enums.TableNames.tblAuthority.ToString
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace

