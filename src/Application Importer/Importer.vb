Imports FSM.Entity

Namespace Importer

    Public Class Importer

#Region "Properties"

        Private _database As Sys.Database

        Public Sub New(ByVal database As Sys.Database)
            _database = database
        End Sub

        Private _DataToImport As ArrayList
        Private _arrayList As ArrayList
        Private _fRMImportNew As FRMPartsImport

        Sub New(arrayList As ArrayList, fRMImportNew As FRMPartsImport)
            ' TODO: Complete member initialization
            _arrayList = arrayList
            _fRMImportNew = fRMImportNew
        End Sub

        Public Property DataToImport() As ArrayList
            Get
                Return _DataToImport
            End Get
            Set(ByVal Value As ArrayList)
                _DataToImport = Value
            End Set
        End Property

        Shared _Tdatabase As Entity.Sys.TransactionalDatabase

        Public Property Tdatabase() As Entity.Sys.TransactionalDatabase
            Get
                Return _Tdatabase
            End Get
            Set(ByVal Value As Entity.Sys.TransactionalDatabase)
                _Tdatabase = Value
            End Set
        End Property

        Shared _Trans As System.Data.SqlClient.SqlTransaction

        Public Property Trans() As System.Data.SqlClient.SqlTransaction
            Get
                Return _Trans
            End Get
            Set(ByVal Value As System.Data.SqlClient.SqlTransaction)
                _Trans = Value
            End Set
        End Property

        Private _ImportForm As FRMImport

        Public Property ImportForm() As FRMImport
            Get
                Return _ImportForm
            End Get
            Set(ByVal Value As FRMImport)
                _ImportForm = Value
            End Set
        End Property

#End Region

#Region "Generic Functions"

        Public Sub New(ByVal DataToImportIn As ArrayList, ByRef ImportFormIn As FRMImport)
            DataToImport = DataToImportIn
            _Tdatabase = New Entity.Sys.TransactionalDatabase
            _Trans = Nothing
            ImportForm = ImportFormIn

            ImportForm.MoveProgressOn()
        End Sub

        Public Sub Import(ByVal SupplierID As Integer, ByVal UnitTypeID As Integer, Optional ByVal CustomerID As Integer = 0)
            Dim PartsImportMarkup As Double = DB.Manager.Get.PartsImportMarkup

            Trans = Tdatabase.Transaction_Get()
            Try

                For dvIndex As Integer = 0 To DataToImport.Count - 1
                    Dim dv As DataView = CType(DataToImport(dvIndex), DataView)

                    If dvIndex = 0 And dv.Table.TableName = "Parts" Then
                        ImportParts(dv, SupplierID, PartsImportMarkup, UnitTypeID)
                    ElseIf dvIndex = 0 And dv.Table.TableName = "Sites" Then
                        ' ImportSites(dv, CustomerID, Combo.GetSelectedItemDescription(ImportForm.cboSourceOfCustomer), Combo.GetSelectedItemDescription(ImportForm.cboReasonForContact))
                    End If
                Next

                Tdatabase.Transaction_Commit(Trans)
            Catch ex As Exception
                Tdatabase.Transaction_Rollback(Trans)
                Throw New Exception("Error Importing, all actions have been rolled back." & vbCrLf & ex.Message)
            End Try
        End Sub

        Public Sub PreImport(ByVal SupplierID As Integer, ByVal PartCode As String, ByVal Description As String, ByVal Category As String, ByVal SupplierPartCode As String, ByVal SupplierPrice As Double)
            Part_PreImportInsert(SupplierID, PartCode, Description, Category, SupplierPartCode, SupplierPrice)
        End Sub

#End Region

#Region "Private Functions"

        Private Sub ImportSites(ByVal dvSites As DataView, ByVal CustomerID As Integer, ByVal SourceOfCustomer As String, ByVal ReasonForContact As String)

            Dim oCustomer As Entity.Customers.Customer = DB.Customer.Customer_Get(CustomerID)
            Dim oSettings As Entity.Management.Settings = DB.Manager.Get
            Dim ReasonForContactID As Integer = 0
            Dim ReasonForContacts() As DataRow = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ReasonsForContact).Table.Select("Name ='" & ReasonForContact & "'")
            If ReasonForContacts.Length > 0 Then
                ReasonForContactID = ReasonForContacts(0)("ManagerID")
            End If

            Dim SourceOfCustomerID As Integer = 0
            Dim SourceOfCustomers() As DataRow = DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.SourceOfCustomer).Table.Select("Name ='" & SourceOfCustomer & "'")
            If SourceOfCustomers.Length > 0 Then
                SourceOfCustomerID = SourceOfCustomers(0)("ManagerID")
            End If

            For siteIndex As Integer = 0 To dvSites.Count - 1
                Dim site As DataRowView = dvSites(siteIndex)
                Dim oSite As New Entity.Sites.Site
                'If site("PolicyNumber") = "" Then
                'Else

                'Dim siteFound As DataView = GetByPolicyNumber(site("PolicyNumber"), CustomerID)
                'If siteFound.Table.Rows.Count = 0 Then
                oSite.SetAcceptChargesChanges = 1
                oSite.SetCommercialDistrict = 0
                oSite.SetCustomerID = CustomerID
                oSite.SetEngineerID = 0
                oSite.SetHeadOffice = False
                oSite.SetNoMarketing = False
                oSite.SetNoService = False
                oSite.SetOnStop = False
                oSite.SetPoNumReqd = False
                oSite.SetReasonForContactID = ReasonForContactID
                oSite.SetRegionID = oCustomer.RegionID
                oSite.SetSolidFuel = False
                oSite.SetSourceOfCustomerID = SourceOfCustomerID
                oSite.SetCustomerID = CustomerID
                'Else

                'Dim SiteID As Integer = siteFound.Table.Rows(0).Item("SiteID")
                'oSite = DB.Sites.Get(SiteID)

                'End If

                If Not site("PolicyNumber") Is DBNull.Value Then
                    oSite.SetPolicyNumber = site("PolicyNumber")
                End If

                If Not site("Tenant") Is DBNull.Value Then
                    If Trim(site("Tenant")) = "Void" Or site("Tenant") = "V" Then
                        oSite.SetPropertyVoid = True
                    Else
                        oSite.SetPropertyVoid = False
                    End If

                    If site("Tenant") = "L" Then
                        oSite.SetLeaseHold = True
                    Else
                        oSite.SetLeaseHold = False
                    End If
                End If

                If Not site("Address 1") Is DBNull.Value Then
                    If Len(site("Address 1")) > 0 Then
                        oSite.SetAddress1 = site("Address 1")
                    Else
                        oSite.SetAddress1 = Nothing
                    End If
                End If

                If Not site("Address 2") Is DBNull.Value Then
                    If Len(site("Address 2")) > 0 Then
                        oSite.SetAddress2 = Trim(site("Address 2"))
                    Else
                        oSite.SetAddress2 = Nothing
                    End If
                End If

                If Not site("Address 3") Is DBNull.Value Then
                    If Len(site("Address 3")) > 0 Then
                        oSite.SetAddress3 = Trim(site("Address 3"))
                    Else
                        oSite.SetAddress3 = Nothing
                    End If
                End If

                If Not site("Address 4") Is DBNull.Value Then
                    If Len(site("Address 4")) > 0 Then
                        oSite.SetAddress4 = Trim(site("Address 4"))
                    Else
                        oSite.SetAddress4 = Nothing
                    End If
                End If

                If Not site("PostCode") Is DBNull.Value Then
                    If Len(site("PostCode")) > 0 Then
                        oSite.SetPostcode = Replace(Entity.Sys.Helper.MakeStringValid(site("PostCode")), " ", "-")
                        If oSite.Postcode.Length = 0 Then
                            oSite.SetPostcode = "XXX-XXX"
                        End If
                    Else
                        oSite.SetPostcode = "XXX-XXX"
                    End If
                Else
                    oSite.SetPostcode = "XXX-XXX"
                End If
                Dim siteName As String = Nothing
                If Not site("Tenant") Is DBNull.Value Then
                    siteName = Entity.Sys.Helper.MakeStringValid(site("Tenant"))
                    If Trim(siteName) = "Void" Then
                        If Not site("Address 1") Is DBNull.Value Then
                            siteName = site("Address 1")
                            oSite.SetName = siteName
                        End If
                    Else
                        siteName = Trim(siteName)
                        oSite.SetName = siteName
                    End If
                Else
                    If Not site("Address 1") Is DBNull.Value Then
                        siteName = site("Address 1")
                        oSite.SetName = siteName
                    End If
                End If

                'If InStr(siteName, "T2") > 0 Then
                '    siteName = Trim(siteName.Substring(0, InStr(siteName, "T2") - 1))
                'End If

                'oSite.SetEmailAddress = Nothing
                If Not site("EmailAddress") Is DBNull.Value Then
                    If Len(Trim(site("EmailAddress").ToString)) > 0 Then
                        oSite.SetEmailAddress = CStr(site("EmailAddress"))
                    Else
                        oSite.SetEmailAddress = Nothing
                    End If
                End If

                If Not site("FaxNum") Is DBNull.Value Then    'this is the mobile number
                    If Len(Trim(site("FaxNum").ToString)) > 0 Then
                        oSite.SetFaxNum = CStr(site("FaxNum"))
                    Else
                        oSite.SetFaxNum = Nothing
                    End If
                End If

                'oSite.SetFaxNum = Nothing
                If Not site("TelephoneNum") Is DBNull.Value Then
                    If Len(Trim(site("TelephoneNum").ToString)) > 0 Then
                        oSite.SetTelephoneNum = CStr(site("TelephoneNum"))
                    Else
                        oSite.SetTelephoneNum = 0
                    End If
                End If

                If Not site("heating type") Is DBNull.Value Then
                    Dim sitefuel As String = Trim(site("heating type").ToString)
                    oSite.SetSiteFuel = sitefuel
                End If

                If Not site("Notes") Is DBNull.Value Then
                    Dim tempNotes As String = Entity.Sys.Helper.MakeStringValid(site("Notes").ToString).Trim

                    If Not Entity.Sys.Helper.MakeStringValid(site("Notes").ToString).Trim.Length = 0 Then
                        tempNotes = Entity.Sys.Helper.MakeStringValid(site("Notes").ToString).Trim()
                        oSite.SetNotes = Trim(tempNotes)
                    End If
                End If

                'tempNotes = Replace(tempNotes, "T2ADVI", vbCrLf & "T2ADVI")
                'tempNotes = Replace(tempNotes, "T1WARN", vbCrLf & "T1WARN")
                'tempNotes = Replace(tempNotes, "T2WARN", vbCrLf & "T2WARN")
                If Not site("Last Service Date") Is DBNull.Value Then
                    If site("Last Service Date").ToString = "" Then
                    Else
                        Dim LSDate As DateTime = CStr(site("Last Service Date"))
                        oSite.LastServiceDate = LSDate
                    End If
                End If

                If oSite.Exists Then
                    Update_Site(oSite)
                Else
                    oSite.SetSiteID = Insert_Site(oSite, oSettings)
                End If

                If Not site("Tenant") Is DBNull.Value Then

                    If Trim(site("Tenant")) = "Void" Then
                    Else

                        'CONTACTS
                        Dim oContact As New Entity.Contacts.Contact

                        Dim namestring() As String = Split(site("Tenant"), " ")

                        ''DOES THE CONTACT EXIST
                        'If Entity.Sys.Helper.MakeStringValid(namestring(1)).Length > 0 Then
                        '    Dim contactFound As DataView = Contact_Get_ByFirstName(namestring(1), oSite.SiteID)
                        '    If contactFound.Table.Rows.Count = 0 Then
                        '        oContact.SetFirstName = namestring(1)
                        '        oContact.SetPropertyID = oSite.SiteID
                        '    Else
                        '        Dim contactID As Integer = contactFound.Table.Rows(0).Item("contactID")
                        '        oContact = DB.Contact.Contact_Get(contactID)
                        '    End If

                        '    oContact.SetSurname = namestring(2)
                        '    'oContact.SetTelephoneNum = site("TelephoneNum")
                        '    If Not site("TelephoneNum") Is DBNull.Value Then
                        '        If Len(Trim(site("TelephoneNum").ToString)) > 0 Then
                        '            oContact.SetTelephoneNum = CStr(site("TelephoneNum"))
                        '        Else
                        '            oContact.SetTelephoneNum = 0
                        '        End If
                        '    End If

                        '    If oContact.Exists Then
                        '        InsertUpdate_Contact(oContact, "Update")
                        '    Else
                        '        InsertUpdate_Contact(oContact, "Insert")
                        '    End If
                        'End If
                    End If

                End If
                'End If
                ImportForm.MoveProgressOn()
                'FRMImport.Label3.Text = CStr(siteIndex)

            Next
        End Sub

        Private Sub Part_PreImportInsert(ByVal SupplierID As Integer, ByVal PartCode As String, ByVal Description As String, ByVal Category As String, ByVal SupplierPartCode As String, ByVal SupplierPrice As Double)
            Dim cmdImportPart As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("Part_PreImportInsert", Trans)

            cmdImportPart.Parameters.Clear()
            cmdImportPart.Parameters.AddWithValue("SupplierID", SupplierID)
            cmdImportPart.Parameters.AddWithValue("PartCode", PartCode)
            cmdImportPart.Parameters.AddWithValue("Description", Description)
            cmdImportPart.Parameters.AddWithValue("Category", Category)
            cmdImportPart.Parameters.AddWithValue("SupplierPartCode", SupplierPartCode)
            cmdImportPart.Parameters.AddWithValue("SupplierPrice", SupplierPrice)
        End Sub

        Private Sub ImportParts(ByVal dvParts As DataView, ByVal SupplierID As Integer, ByVal PartsImportMarkup As Double, ByVal UnitTypeID As Integer)

            For partIndex As Integer = 0 To dvParts.Count - 1
                Dim row As DataRowView = dvParts(partIndex)

                Dim CategoryID As Integer = DB.ImportValidation.CategoryID(row("Category"), Trans)

                Dim SupplierPartCode As String = Nothing
                If IsDBNull(row("Supplier Part Code")) OrElse CStr(row("Supplier Part Code")).Length <= 0 Then
                    SupplierPartCode = row("Part Code")
                Else
                    SupplierPartCode = row("Supplier Part Code")
                End If

                'ImportForm.SetLastPartAttempted(row("Part Code"))

                Dim partsFound As Integer = DB.Part.Part_Exists(row("Part Code"), row("Supplier Part Code"), Trans)

                'If partsFound.Length = 0 Then
                If partsFound = 0 Then
                    Dim sellPrice As Double = Entity.Sys.Helper.MakeDoubleValid(Format(Entity.Sys.Helper.MakeDoubleValid(Entity.Sys.Helper.MakeDoubleValid(row("Supplier Price")) * ((PartsImportMarkup / 100) + 1)), "F"))

                    If Not IsDBNull(row("Sell Price")) Then
                        If row("Sell Price").GetType() Is GetType(Decimal) Then
                            sellPrice = Entity.Sys.Helper.MakeDoubleValid(Format(Entity.Sys.Helper.MakeDoubleValid(row("Sell Price")), "F"))
                        End If
                    End If

                    Dim notes As String = ""
                    If Not IsDBNull(row("Notes")) Then
                        If CStr(row("Notes")).Length > 0 Then
                            notes = row("Notes")
                        End If
                    End If

                    Dim PartID As Integer = Insert_Part(row("Part Code"), row("Name/Description"), CategoryID, UnitTypeID, notes, sellPrice)

                    Insert_Part_Supplier(PartID, SupplierPartCode, SupplierID, Entity.Sys.Helper.MakeDoubleValid(Format(Entity.Sys.Helper.MakeDoubleValid(row("Supplier Price")), "F")), Entity.Sys.Helper.MakeIntegerValid(Format(Entity.Sys.Helper.MakeDoubleValid(row("Supplier Qty")), "F")))
                Else
                    Dim doUpdate As Boolean = False

                    Dim oPart As Entity.Parts.Part = DB.Part.Part_Get(partsFound, Trans)

                    'If Not IsDBNull(row("Name/Description")) Then
                    '    If CStr(row("Name/Description")).Length > 0 Then
                    '        oPart.SetName = row("Name/Description")
                    '        doUpdate = True
                    '    End If
                    'End If

                    If Not IsDBNull(row("Category")) Then
                        If CStr(row("Category")).Length > 0 Then
                            oPart.SetCategoryID = CategoryID
                            doUpdate = True
                        End If
                    End If

                    If Not IsDBNull(row("Notes")) Then
                        If CStr(row("Notes")).Length > 0 Then
                            oPart.SetNotes = row("Notes")
                            doUpdate = True
                        End If
                    End If

                    If Not IsDBNull(row("Sell Price")) Then
                        If row("Sell Price").GetType() Is GetType(Decimal) Then
                            oPart.SetSellPrice = Entity.Sys.Helper.MakeDoubleValid(Format(Entity.Sys.Helper.MakeDoubleValid(row("Sell Price")), "F"))
                            doUpdate = True
                        End If
                    End If

                    If doUpdate Then
                        Update_Part(oPart)
                    End If

                    Dim suppliersFound As Array = DB.PartSupplier.Get_ByPartID(oPart.PartID, Trans).Table.Select("SupplierID = " & SupplierID)

                    If suppliersFound.Length = 0 Then
                        Insert_Part_Supplier(oPart.PartID, SupplierPartCode, SupplierID, Entity.Sys.Helper.MakeDoubleValid(Format(Entity.Sys.Helper.MakeDoubleValid(row("Supplier Price")), "F")), Entity.Sys.Helper.MakeIntegerValid(Format(Entity.Sys.Helper.MakeDoubleValid(row("Supplier Qty")), "F")))
                    Else
                        Dim oPartSupplier As Entity.PartSuppliers.PartSupplier = DB.PartSupplier.PartSupplier_Get(CType(suppliersFound(0), DataRow).Item("PartSupplierID"), Trans)

                        Dim doSupplierUpdate As Boolean = False

                        If Not SupplierPartCode = Nothing Then
                            If CStr(SupplierPartCode).Length > 0 Then
                                oPartSupplier.SetPartCode = SupplierPartCode
                                doSupplierUpdate = True
                            End If
                        End If

                        If Not IsDBNull(row("Supplier Qty")) Then
                            If row("Supplier Qty").GetType() Is GetType(Double) Then
                                oPartSupplier.SetQuantityInPack = Entity.Sys.Helper.MakeIntegerValid(Format(Entity.Sys.Helper.MakeDoubleValid(row("Supplier Qty")), "F"))
                                doSupplierUpdate = True
                            End If
                        End If

                        If Not IsDBNull(row("Supplier Price")) Then
                            If row("Supplier Price").GetType() Is GetType(Decimal) Then
                                oPartSupplier.SetPrice = Entity.Sys.Helper.MakeDoubleValid(Format(Entity.Sys.Helper.MakeDoubleValid(row("Supplier Price")), "F"))
                                doSupplierUpdate = True
                            End If
                        End If

                        If doSupplierUpdate Then
                            Update_Part_Supplier(oPartSupplier)
                        End If
                    End If

                End If
                ImportForm.MoveProgressOn()
            Next
        End Sub

        Public Function GetByPolicyNumber(ByVal policyNumber As String, ByVal customerID As Integer) As DataView
            Dim cmdImportSite As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("Site_GetByPolicyNumber", Trans)

            cmdImportSite.Parameters.Clear()
            cmdImportSite.Parameters.AddWithValue("@policyNumber", policyNumber)
            cmdImportSite.Parameters.AddWithValue("@customerID", customerID)
            Return New DataView(_Tdatabase.ExecuteTableSPTrans(cmdImportSite))
        End Function

        Public Function Insert_Site(ByVal oSite As Entity.Sites.Site, ByVal oSettings As Entity.Management.Settings) As Integer
            Dim cmdImportSite As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("Site_Insert", Trans)

            cmdImportSite.Parameters.Clear()
            cmdImportSite.Parameters.AddWithValue("@SiteAddedByUserID", loggedInUser.UserID)
            cmdImportSite.Parameters.AddWithValue("@CustomerID", oSite.CustomerID)
            cmdImportSite.Parameters.AddWithValue("@Name", oSite.Name)
            cmdImportSite.Parameters.AddWithValue("@RegionID", oSite.RegionID)
            cmdImportSite.Parameters.AddWithValue("@HeadOffice", oSite.HeadOffice)
            cmdImportSite.Parameters.AddWithValue("@Notes", oSite.Notes)
            cmdImportSite.Parameters.AddWithValue("@Address1", oSite.Address1)
            cmdImportSite.Parameters.AddWithValue("@Address2", oSite.Address2)
            cmdImportSite.Parameters.AddWithValue("@Address3", oSite.Address3)
            cmdImportSite.Parameters.AddWithValue("@Address4", oSite.Address4)
            cmdImportSite.Parameters.AddWithValue("@Address5", oSite.Address5)
            cmdImportSite.Parameters.AddWithValue("@Postcode", oSite.Postcode)
            cmdImportSite.Parameters.AddWithValue("@TelephoneNum", oSite.TelephoneNum)
            cmdImportSite.Parameters.AddWithValue("@FaxNum", oSite.FaxNum)
            cmdImportSite.Parameters.AddWithValue("@EmailAddress", oSite.EmailAddress)
            cmdImportSite.Parameters.AddWithValue("@EngineerID", oSite.EngineerID)
            cmdImportSite.Parameters.AddWithValue("@PONumReqd", oSite.PoNumReqd)
            cmdImportSite.Parameters.AddWithValue("@PolicyNumber", oSite.PolicyNumber)
            cmdImportSite.Parameters.AddWithValue("@AcceptChargesChanges", oSite.AcceptChargesChanges)
            cmdImportSite.Parameters.AddWithValue("@SourceOfCustomerID", oSite.SourceOfCustomerID)
            cmdImportSite.Parameters.AddWithValue("@NoMarketing", oSite.NoMarketing)
            cmdImportSite.Parameters.AddWithValue("@ReasonForContactID", oSite.ReasonForContactID)
            cmdImportSite.Parameters.AddWithValue("@OnStop", oSite.OnStop)
            cmdImportSite.Parameters.AddWithValue("@LeaseHold", oSite.LeaseHold)
            cmdImportSite.Parameters.AddWithValue("@PropertyVoid", oSite.PropertyVoid)
            cmdImportSite.Parameters.AddWithValue("@SiteFuel", oSite.SiteFuel)
            Dim SiteID As Integer = _Tdatabase.ExecuteScalarSPTrans(cmdImportSite)

            'CHARGES
            Dim cmdImportSiteCharge As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("SiteCharge_Insert", Trans)
            cmdImportSiteCharge.Parameters.Clear()
            cmdImportSiteCharge.Parameters.AddWithValue("@SiteID", SiteID)
            cmdImportSiteCharge.Parameters.AddWithValue("@MileageRate", oSettings.MileageRate)
            cmdImportSiteCharge.Parameters.AddWithValue("@PartsMarkup", oSettings.PartsMarkup)
            cmdImportSiteCharge.Parameters.AddWithValue("@RatesMarkup", oSettings.RatesMarkup)
            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportSiteCharge)

            'SORS
            Dim cmdImportSiteSORs As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("SiteScheduleOfRate_Insert_Defaults", Trans)
            cmdImportSiteSORs.Parameters.Clear()
            cmdImportSiteSORs.Parameters.AddWithValue("@SiteID", SiteID)
            cmdImportSiteSORs.Parameters.AddWithValue("@CustomerID", oSite.CustomerID)
            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportSiteSORs)

            Return SiteID
        End Function

        Public Sub Update_Site(ByVal oSite As Entity.Sites.Site)
            Dim cmdImportSite As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("Site_Update", Trans)

            cmdImportSite.Parameters.Clear()
            cmdImportSite.Parameters.AddWithValue("@SiteID", oSite.SiteID)
            cmdImportSite.Parameters.AddWithValue("@CustomerID", oSite.CustomerID)
            cmdImportSite.Parameters.AddWithValue("@Name", oSite.Name)
            cmdImportSite.Parameters.AddWithValue("@RegionID", oSite.RegionID)
            cmdImportSite.Parameters.AddWithValue("@HeadOffice", oSite.HeadOffice)
            cmdImportSite.Parameters.AddWithValue("@Notes", oSite.Notes)
            cmdImportSite.Parameters.AddWithValue("@Address1", oSite.Address1)
            cmdImportSite.Parameters.AddWithValue("@Address2", oSite.Address2)
            cmdImportSite.Parameters.AddWithValue("@Address3", oSite.Address3)
            cmdImportSite.Parameters.AddWithValue("@Address4", oSite.Address4)
            cmdImportSite.Parameters.AddWithValue("@Address5", oSite.Address5)
            cmdImportSite.Parameters.AddWithValue("@Postcode", oSite.Postcode)
            cmdImportSite.Parameters.AddWithValue("@TelephoneNum", oSite.TelephoneNum)
            cmdImportSite.Parameters.AddWithValue("@FaxNum", oSite.FaxNum)
            cmdImportSite.Parameters.AddWithValue("@EmailAddress", oSite.EmailAddress)
            cmdImportSite.Parameters.AddWithValue("@EngineerID", oSite.EngineerID)
            cmdImportSite.Parameters.AddWithValue("@PONumReqd", oSite.PoNumReqd)
            cmdImportSite.Parameters.AddWithValue("@PolicyNumber", oSite.PolicyNumber)
            cmdImportSite.Parameters.AddWithValue("@AcceptChargesChanges", oSite.AcceptChargesChanges)
            cmdImportSite.Parameters.AddWithValue("@SourceOfCustomerID", oSite.SourceOfCustomerID)
            cmdImportSite.Parameters.AddWithValue("@NoMarketing", oSite.NoMarketing)
            cmdImportSite.Parameters.AddWithValue("@ReasonForContactID", oSite.ReasonForContactID)
            cmdImportSite.Parameters.AddWithValue("@OnStop", oSite.OnStop)
            cmdImportSite.Parameters.AddWithValue("@LeaseHold", oSite.LeaseHold)
            cmdImportSite.Parameters.AddWithValue("@PropertyVoid", oSite.PropertyVoid)
            cmdImportSite.Parameters.AddWithValue("@SiteFuel", oSite.SiteFuel)

            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportSite)
        End Sub

        Public Function Contact_Get_ByFirstName(ByVal FirstName As String, ByVal SiteID As Integer) As DataView

            Dim cmdImportSite As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("Contact_Get_ByFirstName", Trans)

            cmdImportSite.Parameters.Clear()
            cmdImportSite.Parameters.AddWithValue("@FirstName", FirstName)
            cmdImportSite.Parameters.AddWithValue("@SiteID", SiteID)
            Return New DataView(_Tdatabase.ExecuteTableSPTrans(cmdImportSite))
        End Function

        Public Function InsertUpdate_Contact(ByVal oContact As Entity.Contacts.Contact, ByVal InsertUpdate As String) As Integer
            Dim cmdImportContact As SqlClient.SqlCommand

            If InsertUpdate = "Insert" Then
                cmdImportContact = _Tdatabase.CreateStoredProcedure("Contact_Insert", Trans)
            Else
                cmdImportContact = _Tdatabase.CreateStoredProcedure("Contact_Update", Trans)

            End If

            cmdImportContact.Parameters.Clear()
            If InsertUpdate <> "Insert" Then
                cmdImportContact.Parameters.AddWithValue("@ContactID", oContact.ContactID)
            End If

            cmdImportContact.Parameters.AddWithValue("@FirstName", oContact.FirstName)
            cmdImportContact.Parameters.AddWithValue("@Surname", oContact.Surname)
            cmdImportContact.Parameters.AddWithValue("@TelephoneNum", oContact.TelephoneNum)
            cmdImportContact.Parameters.AddWithValue("@EmailAddress", oContact.EmailAddress)
            cmdImportContact.Parameters.AddWithValue("@FaxNum", oContact.FaxNum)
            cmdImportContact.Parameters.AddWithValue("@SiteID", oContact.PropertyID)
            cmdImportContact.Parameters.AddWithValue("@MobileNo", oContact.MobileNo)

            If Not oContact.PortalUserName.Trim.Length = 0 Then
                cmdImportContact.Parameters.AddWithValue("@PortalUserName", oContact.PortalUserName)
            End If
            If Not oContact.PortalPassword.Trim.Length = 0 Then
                cmdImportContact.Parameters.AddWithValue("@PortalPassword", oContact.PortalPassword)
            End If

            Return _Tdatabase.ExecuteScalarSPTrans(cmdImportContact)
        End Function

        Public Function Insert_Part(ByVal Number As String, ByVal Name As String, ByVal CategoryID As Integer, ByVal UnitTypeID As Integer, ByVal Notes As String, ByVal SellPrice As Double) As Integer
            Dim cmdImportPart As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("Part_Insert", Trans)

            cmdImportPart.Parameters.Clear()
            cmdImportPart.Parameters.AddWithValue("@Name", Name)
            cmdImportPart.Parameters.AddWithValue("@Number", Number)
            cmdImportPart.Parameters.AddWithValue("@Reference", "")
            cmdImportPart.Parameters.AddWithValue("@Notes", Notes)
            cmdImportPart.Parameters.AddWithValue("@unitTypeID", UnitTypeID)
            cmdImportPart.Parameters.AddWithValue("@sellPrice", SellPrice)
            cmdImportPart.Parameters.AddWithValue("@recommendedQuantity", 0)
            cmdImportPart.Parameters.AddWithValue("@minimumQuantity", 0)
            cmdImportPart.Parameters.AddWithValue("@CategoryID", CategoryID)
            cmdImportPart.Parameters.AddWithValue("@WarehouseID", 0)
            cmdImportPart.Parameters.AddWithValue("@ShelfID", 0)
            cmdImportPart.Parameters.AddWithValue("@BinID", 0)
            cmdImportPart.Parameters.AddWithValue("@WarehouseIDAlternative", 0)
            cmdImportPart.Parameters.AddWithValue("@ShelfIDAlternative", 0)
            cmdImportPart.Parameters.AddWithValue("@BinIDAlternative", 0)
            cmdImportPart.Parameters.AddWithValue("@EndFlagged", False)
            cmdImportPart.Parameters.AddWithValue("@Equipment", False)

            Return _Tdatabase.ExecuteScalarSPTrans(cmdImportPart)
        End Function

        Public Sub Update_Part(ByVal oPart As Entity.Parts.Part)
            Dim cmdImportPart As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("Part_Update", Trans)

            cmdImportPart.Parameters.Clear()
            cmdImportPart.Parameters.AddWithValue("@PartID", oPart.PartID)
            cmdImportPart.Parameters.AddWithValue("@Name", oPart.Name)
            cmdImportPart.Parameters.AddWithValue("@Number", oPart.Number)
            cmdImportPart.Parameters.AddWithValue("@Reference", oPart.Reference)
            cmdImportPart.Parameters.AddWithValue("@Notes", oPart.Notes)
            cmdImportPart.Parameters.AddWithValue("@unitTypeID", oPart.UnitTypeID)
            cmdImportPart.Parameters.AddWithValue("@sellPrice", oPart.SellPrice)
            cmdImportPart.Parameters.AddWithValue("@recommendedQuantity", oPart.RecommendedQuantity)
            cmdImportPart.Parameters.AddWithValue("@minimumQuantity", oPart.MinimumQuantity)
            cmdImportPart.Parameters.AddWithValue("@CategoryID", oPart.CategoryID)
            cmdImportPart.Parameters.AddWithValue("@WarehouseID", oPart.WarehouseID)
            cmdImportPart.Parameters.AddWithValue("@ShelfID", oPart.ShelfID)
            cmdImportPart.Parameters.AddWithValue("@BinID", oPart.BinID)
            cmdImportPart.Parameters.AddWithValue("@WarehouseIDAlternative", oPart.WarehouseIDAlternative)
            cmdImportPart.Parameters.AddWithValue("@ShelfIDAlternative", oPart.ShelfIDAlternative)
            cmdImportPart.Parameters.AddWithValue("@BinIDAlternative", oPart.BinIDAlternative)
            cmdImportPart.Parameters.AddWithValue("@EndFlagged", oPart.EndFlagged)
            cmdImportPart.Parameters.AddWithValue("@Equipment", oPart.Equipment)

            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportPart)
        End Sub

        Public Sub Insert_Part_Supplier(ByVal PartID As Integer, ByVal Code As String, ByVal SupplierID As Integer, ByVal Price As Double, ByVal Quantity As Integer)
            Dim cmdImportPart As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("PartSupplier_Insert", Trans)

            cmdImportPart.Parameters.Clear()
            cmdImportPart.Parameters.AddWithValue("@PartCode", Code)
            cmdImportPart.Parameters.AddWithValue("@PartID", PartID)
            cmdImportPart.Parameters.AddWithValue("@SupplierID", SupplierID)
            cmdImportPart.Parameters.AddWithValue("@Price", Price)
            cmdImportPart.Parameters.AddWithValue("@quantityInPack", Quantity)
            cmdImportPart.Parameters.AddWithValue("@UserID", loggedInUser.UserID)

            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportPart)
        End Sub

        Public Sub Update_Part_Supplier(ByVal oPartSupplier As Entity.PartSuppliers.PartSupplier)
            Dim cmdImportPart As SqlClient.SqlCommand = _Tdatabase.CreateStoredProcedure("PartSupplier_Update", Trans)

            cmdImportPart.Parameters.Clear()
            cmdImportPart.Parameters.AddWithValue("@PartSupplierID", oPartSupplier.PartSupplierID)
            cmdImportPart.Parameters.AddWithValue("@PartCode", oPartSupplier.PartCode)
            cmdImportPart.Parameters.AddWithValue("@PartID", oPartSupplier.PartID)
            cmdImportPart.Parameters.AddWithValue("@SupplierID", oPartSupplier.SupplierID)
            cmdImportPart.Parameters.AddWithValue("@Price", oPartSupplier.Price)
            cmdImportPart.Parameters.AddWithValue("@quantityInPack", oPartSupplier.QuantityInPack)
            cmdImportPart.Parameters.AddWithValue("@UserID", loggedInUser.UserID)

            _Tdatabase.ExecuteNonQuerySPTrans(cmdImportPart)
        End Sub

#End Region

    End Class

    Public Class DuplicateInvoice
        Public Property SupplierID As Integer
        Public Property InvoiceNo As String
        Public Property InvoiceDate As String
        Public Property PurchaseOrderNo As String
        Public Property SupplierPartCode As String
        Public Property Description As String
        Public Property Quantity As Integer
        Public Property UnitPrice As Double
        Public Property NetAmount As Double
        Public Property VATAmount As Double
        Public Property GrossAmount As Double
        Public Property TotalQtyOfParts As Integer
    End Class

End Namespace