Imports System.Data.SqlClient

Namespace Entity

    Namespace Contacts

        Public Class ContactSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal ContactID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@ContactID", ContactID, True)
                _database.ExecuteSP_NO_Return("Contact_Delete")
            End Sub

            Public Function [Insert](ByVal oContact As Contact) As Contact
                _database.ClearParameter()
                AddContactParametersToCommand(oContact)

                oContact.SetContactID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Contact_Insert"))
                oContact.Exists = True
                Return oContact
            End Function

            Public Function [Contact_Search](ByVal criteria As String) As DataView
                _database.ClearParameter()
                _database.AddParameter("@Criteria", criteria, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contact_Search")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContact.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Update](ByVal oContact As Contact)
                _database.ClearParameter()
                _database.AddParameter("@ContactID", oContact.ContactID, True)
                AddContactParametersToCommand(oContact)
                _database.ExecuteSP_NO_Return("Contact_Update")
            End Sub

            Public Function Contact_GetForSite(ByVal SiteID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@SiteID", SiteID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contact_GetForSite")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContact.ToString
                Return New DataView(dt)
            End Function

            Public Function Contact_GetAll() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contact_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContact.ToString
                Return New DataView(dt)
            End Function

            Public Function Contact_Get(ByVal ContactID As Integer) As Contact
                _database.ClearParameter()
                _database.AddParameter("@ContactID", ContactID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contact_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContact As New Contact
                        With oContact
                            .IgnoreExceptionsOnSetMethods = True
                            .SetContactID = dt.Rows(0).Item("ContactID")
                            .SetSalutation = dt.Rows(0).Item("Salutation")
                            .SetFirstName = dt.Rows(0).Item("FirstName")
                            .SetSurname = dt.Rows(0).Item("Surname")
                            .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            .SetTelephoneNum = dt.Rows(0).Item("TelephoneNum")
                            .SetFaxNum = dt.Rows(0).Item("FaxNum")
                            .SetPropertyID = dt.Rows(0).Item("SiteID")
                            .SetDeleted = dt.Rows(0).Item("Deleted")
                            .SetMobileNo = dt.Rows(0).Item("MobileNo")
                            .SetPortalUserName = dt.Rows(0).Item("PortalUserName")
                            .SetPortalPassword = dt.Rows(0).Item("PortalPassword")
                            .SetPortalGSRPrint = dt.Rows(0).Item("PortalGSRPrint")

                            .SetEID = dt.Rows(0).Item("EID")
                        End With
                        oContact.Exists = True
                        Return oContact
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function Check_Unique_PortalUsername(ByVal username As String, ByVal ID As Integer) As Boolean
                Dim NumberOfUsers As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(Contactid) as 'NumberOfUsers' " &
                "FROM tblContact WHERE portalusername = '" & username & "' AND contactid <> " & ID & " AND PortalUserName IS NOT NULL", False))

                If NumberOfUsers = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function

            Private Sub AddContactParametersToCommand(ByRef oContact As Contact)
                With _database
                    .AddParameter("@FirstName", oContact.FirstName, True)
                    .AddParameter("@Salutation", oContact.Salutation, True)
                    .AddParameter("@Surname", oContact.Surname, True)
                    .AddParameter("@TelephoneNum", oContact.TelephoneNum, True)
                    .AddParameter("@EmailAddress", oContact.EmailAddress, True)
                    .AddParameter("@FaxNum", oContact.FaxNum, True)
                    .AddParameter("@SiteID", oContact.PropertyID, True)
                    .AddParameter("@MobileNo", oContact.MobileNo, True)
                    If Not oContact.PortalUserName.Trim.Length = 0 Then
                        .AddParameter("@PortalUserName", oContact.PortalUserName, True)
                    End If
                    If Not oContact.PortalPassword.Trim.Length = 0 Then
                        .AddParameter("@PortalPassword", oContact.PortalPassword, True)
                    End If
                    .AddParameter("@PortalGSRPrint", oContact.PortalGSRPrint, True)
                    If Not oContact.EID = 0 Then
                        .AddParameter("@EID", oContact.EID, True)
                    End If
                End With
            End Sub

#End Region

#Region "Contacts"

            Public Function [Contacts_GetAll_ForLink](ByVal linkId As Integer, ByVal linkRef As Integer,
                                                      Optional ByVal deleted As Boolean = False) As DataView
                _database.ClearParameter()
                _database.AddParameter("@LinkRef", linkRef, True)
                _database.AddParameter("@LinkID", linkId, True)
                _database.AddParameter("@Deleted", deleted, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contacts_GetAll_ForLink")
                dt.TableName = Entity.Sys.Enums.TableNames.tblContact.ToString
                Return New DataView(dt)
            End Function

            Public Function [Contacts_Get](ByVal contactId As Integer) As Contact
                _database.ClearParameter()
                _database.AddParameter("@ContactID", contactId)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Contacts_Get")
                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oContact As New Contact
                        With oContact
                            .IgnoreExceptionsOnSetMethods = True
                            If dt.Columns.Contains("ContactID") Then .SetContactID = dt.Rows(0).Item("ContactID")
                            If dt.Columns.Contains("Title") Then .SetSalutation = dt.Rows(0).Item("Title")
                            If dt.Columns.Contains("FirstName") Then .SetFirstName = dt.Rows(0).Item("FirstName")
                            If dt.Columns.Contains("LastName") Then .SetSurname = dt.Rows(0).Item("LastName")
                            If dt.Columns.Contains("Address1") Then .SetAddress1 = dt.Rows(0).Item("Address1")
                            If dt.Columns.Contains("Address2") Then .SetAddress2 = dt.Rows(0).Item("Address2")
                            If dt.Columns.Contains("Address3") Then .SetAddress3 = dt.Rows(0).Item("Address3")
                            If dt.Columns.Contains("Postcode") Then .SetPostcode = dt.Rows(0).Item("Postcode")
                            If dt.Columns.Contains("EmailAddress") Then .SetEmailAddress = dt.Rows(0).Item("EmailAddress")
                            If dt.Columns.Contains("TelephoneNo") Then .SetTelephoneNum = dt.Rows(0).Item("TelephoneNo")
                            If dt.Columns.Contains("MobileNo") Then .SetMobileNo = dt.Rows(0).Item("MobileNo")
                            If dt.Columns.Contains("LinkID") Then .SetLinkID = dt.Rows(0).Item("LinkID")
                            If dt.Columns.Contains("LinkRef") Then .SetLinkRef = dt.Rows(0).Item("LinkRef")
                            If dt.Columns.Contains("NoMarketing") Then .SetNoMarketing = dt.Rows(0).Item("NoMarketing")
                            If dt.Columns.Contains("OnContract") Then .SetOnContract = dt.Rows(0).Item("OnContract")
                            If dt.Columns.Contains("RelationshipID") Then .SetRelationshipID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("RelationshipID"))
                            If dt.Columns.Contains("POC") Then .SetPointOfContact = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("POC"))
                            If dt.Columns.Contains("Relationship") Then .SetRelationship = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Relationship"))
                            If dt.Columns.Contains("Deleted") Then .SetDeleted = dt.Rows(0).Item("Deleted")
                        End With
                        oContact.Exists = True
                        Return oContact
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [Contacts_Update](ByVal oContact As Contact) As Integer
                _database.ClearParameter()
                _database.AddParameter("@ContactID", oContact.ContactID, True)
                _database.AddParameter("@Title", oContact.Salutation, True)
                _database.AddParameter("@FirstName", oContact.FirstName, True)
                _database.AddParameter("@LastName", oContact.Surname, True)
                _database.AddParameter("@TelephoneNo", oContact.TelephoneNum, True)
                _database.AddParameter("@MobileNo", oContact.MobileNo, True)
                _database.AddParameter("@Address1", oContact.Address1, True)
                _database.AddParameter("@Address2", oContact.Address2, True)
                _database.AddParameter("@Address3", oContact.Address3, True)
                _database.AddParameter("@Postcode", oContact.Postcode, True)
                _database.AddParameter("@EmailAddress", oContact.EmailAddress, True)
                _database.AddParameter("@NoMarketing", oContact.NoMarketing, True)
                _database.AddParameter("@LinkID", oContact.LinkID, True)
                _database.AddParameter("@LinkRef", oContact.LinkRef, True)
                _database.AddParameter("@OnContract", oContact.OnContract, True)
                _database.AddParameter("@RelationshipID", oContact.RelationshipID, True)
                _database.AddParameter("@POC", oContact.PointOfContact, True)
                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Contacts_Update"))
            End Function

            Public Function [Contacts_Delete](ByVal contactId As Integer) As Boolean
                _database.ClearParameter()
                _database.AddParameter("@ContactID", contactId, True)
                Return CBool(_database.ExecuteSP_ReturnRowsAffected("Contacts_Delete") = 1)

            End Function

#End Region

        End Class

    End Namespace

End Namespace