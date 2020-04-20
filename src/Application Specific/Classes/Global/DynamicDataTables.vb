Public Class DynamicDataTables

    Public Shared Function Setup_Search_On_Options(ByVal MenuType As Entity.Sys.Enums.MenuTypes, ByVal tableName As Entity.Sys.Enums.TableNames) As DataTable

        Dim dt As New DataTable
        dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchOn.ToString

        dt.Columns.Add(New DataColumn("ValueMember"))
        dt.Columns.Add(New DataColumn("DisplayMember"))
        dt.Columns.Add(New DataColumn("Deleted", System.Type.GetType("System.Boolean")))

        Dim newRow As DataRow

        Select Case MenuType
            Case Entity.Sys.Enums.MenuTypes.Spares
                Select Case tableName
                    Case Entity.Sys.Enums.TableNames.tblSupplier
                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = ""
                        newRow.Item("DisplayMember") = "All"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "Name"
                        newRow.Item("DisplayMember") = "Name"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "AccountNumber"
                        newRow.Item("DisplayMember") = "Account Number"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "Address1"
                        newRow.Item("DisplayMember") = "Address1"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tblSupplier.Postcode"
                        newRow.Item("DisplayMember") = "Postcode"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                    Case Entity.Sys.Enums.TableNames.tblPart
                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = ""
                        newRow.Item("DisplayMember") = "All"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tp.Name"
                        newRow.Item("DisplayMember") = "Name"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "Category.Name"
                        newRow.Item("DisplayMember") = "Category"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tp.Number"
                        newRow.Item("DisplayMember") = "Number"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tp.Reference"
                        newRow.Item("DisplayMember") = "Reference"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                    Case Entity.Sys.Enums.TableNames.tblProduct
                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = ""
                        newRow.Item("DisplayMember") = "All"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tblProduct.Reference"
                        newRow.Item("DisplayMember") = "Reference"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tblProduct.Number"
                        newRow.Item("DisplayMember") = "GC Number"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "type.[Name]"
                        newRow.Item("DisplayMember") = "Type"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "make.[Name]"
                        newRow.Item("DisplayMember") = "Make"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "model.[Name]"
                        newRow.Item("DisplayMember") = "Model"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tblSupplier.name"
                        newRow.Item("DisplayMember") = "Supplier"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                    Case Entity.Sys.Enums.TableNames.tblWarehouse

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = ""
                        newRow.Item("DisplayMember") = "All"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tblWarehouse.Name"
                        newRow.Item("DisplayMember") = "Name"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tblWarehouse.Address1"
                        newRow.Item("DisplayMember") = "Address1"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)

                        newRow = dt.NewRow()
                        newRow.Item("ValueMember") = "tblWarehouse.Postcode"
                        newRow.Item("DisplayMember") = "Postcode"
                        newRow.Item("Deleted") = False
                        dt.Rows.Add(newRow)
                End Select
            Case Else

        End Select
        Return dt
    End Function

    Public Shared Function Setup_Advanced_Search_Options(ByVal MenuType As Entity.Sys.Enums.MenuTypes) As DataTable
        Dim dt As New DataTable
        dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchFor.ToString

        dt.Columns.Add(New DataColumn("ValueMember"))
        dt.Columns.Add(New DataColumn("DisplayMember"))
        dt.Columns.Add(New DataColumn("Deleted", System.Type.GetType("System.Boolean")))

        Dim newRow As DataRow

        Select Case MenuType
            Case Entity.Sys.Enums.MenuTypes.Spares
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblPart)
                newRow.Item("DisplayMember") = "Part"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblProduct)
                newRow.Item("DisplayMember") = "Product"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
        End Select
        Return dt
    End Function

    Public Shared Function Setup_Search_Options(ByVal MenuType As Entity.Sys.Enums.MenuTypes) As DataTable
        Dim dt As New DataTable
        dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchFor.ToString

        dt.Columns.Add(New DataColumn("ValueMember"))
        dt.Columns.Add(New DataColumn("DisplayMember"))
        dt.Columns.Add(New DataColumn("Deleted", System.Type.GetType("System.Boolean")))

        Dim newRow As DataRow

        Select Case MenuType
            Case Entity.Sys.Enums.MenuTypes.Customers
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblCustomer)
                newRow.Item("DisplayMember") = "Customer"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblSite)
                newRow.Item("DisplayMember") = "Property"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblAsset)
                newRow.Item("DisplayMember") = "Appliances"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
            Case Entity.Sys.Enums.MenuTypes.Spares
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblSupplier)
                newRow.Item("DisplayMember") = "Supplier"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblProduct)
                newRow.Item("DisplayMember") = "Product"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblPart)
                newRow.Item("DisplayMember") = "Part"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblWarehouse)
                newRow.Item("DisplayMember") = "Warehouse"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
            Case Entity.Sys.Enums.MenuTypes.Staff
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblEngineer)
                newRow.Item("DisplayMember") = "Engineer"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblVan)
                newRow.Item("DisplayMember") = "Stock Profile"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblSubcontractor)
                newRow.Item("DisplayMember") = "Subcontractor"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblUser)
                newRow.Item("DisplayMember") = "User"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblEquipment)
                newRow.Item("DisplayMember") = "Equipment"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)
            Case Entity.Sys.Enums.MenuTypes.Jobs
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblEngineerVisit)
                newRow.Item("DisplayMember") = "Visit"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblQuotes)
                newRow.Item("DisplayMember") = "Quote"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)

            Case Entity.Sys.Enums.MenuTypes.FleetVan
                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblFleetVan)
                newRow.Item("DisplayMember") = "Vans"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblFleetVanType)
                newRow.Item("DisplayMember") = "Van Type"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblFleetEquipment)
                newRow.Item("DisplayMember") = "Equipment"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)

                newRow = dt.NewRow()
                newRow.Item("ValueMember") = CInt(Entity.Sys.Enums.TableNames.tblFleetGarage)
                newRow.Item("DisplayMember") = "Service Centres"
                newRow.Item("Deleted") = False
                dt.Rows.Add(newRow)

        End Select

        Return dt
    End Function

    Public Shared Function Times(Optional ByVal TimeSlot As Integer = 15) As DataTable

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("ValueMember"))
        dt.Columns.Add(New DataColumn("DisplayMember"))
        dt.Columns.Add(New DataColumn("Deleted"))

        For hour As Integer = 0 To 23
            For minute As Integer = 0 To 45 Step TimeSlot
                Dim time As String = ""

                If hour.ToString.Length = 1 Then
                    time = time & "0"
                End If
                time = time & hour.ToString & ":"

                If minute.ToString.Length = 1 Then
                    time = time & "0"
                End If
                time = time & minute.ToString

                Dim row As DataRow
                row = dt.NewRow
                row.Item("DisplayMember") = time
                row.Item("ValueMember") = time
                row.Item("Deleted") = False
                dt.Rows.Add(row)
            Next
        Next

        Return dt
    End Function

    Public Shared ReadOnly Property CustomerStatus() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {Entity.Sys.Enums.CustomerStatus.Active, "Active", "0"})
            dt.Rows.Add(New String() {Entity.Sys.Enums.CustomerStatus.InActive, "InActive", "0"})
            dt.Rows.Add(New String() {Entity.Sys.Enums.CustomerStatus.OnHold, "On Hold", "0"})
            dt.Rows.Add(New String() {Entity.Sys.Enums.CustomerStatus.Prospect, "Prospect", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property PartValidationTypes() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.Unverified), "Unverified", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.CategoryNotFound), "Category Missing", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.MatchNoChange), "Matched - No Change", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.MatchPriceUp), "Matched - Price INCREASE", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.MatchPriceDown), "Matched - Price DECREASE", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.DuplicatesFound), "Duplicate SPN Found", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.MPNDuplicate), "Duplicate MPN Found", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.NewForThisSupplier), "Matched MPN New SPN", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.NewPart), "New Part MPN and SPN", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartValidationResults.MissingExistingForSupplier), "Parts for supplier not in import", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property PartsInvoiceImportValidationResults() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            'dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.Unverified), "Unverified", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.Replenishment), "(PII) Replenishment", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.UnableToLocatePO), "(PII) Unable to Locate Purchase Order", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceCorrect), "(PII) Matched Purchase Order - Supplier Invoice Price Correct", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceAbove), "(PII) Matched Purchase Order - Supplier Invoice Price Above", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceBelow), "(PII) Matched Purchase Order - Supplier Invoice Price Below", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncluded), "(PII) Matched Purchase Order - No Parts Included on PO", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncludedUnableToMatchParts), "(PII) Matched Purchase Order - No Parts, Unable to Match Parts", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOSentToSage), "(PII) Matched Purchase Order - PO Sent To Sage", "0"})
            'dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.AwaitingAuthorisation), "Supplier Invoice Created - Awaiting Authorisation", "0"})
            'dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.Authorised), "Supplier Invoice Created - Authorised", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.SupplierInvoiceCreated), "(PII) Supplier Invoice Created", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.PurchaseCredit), "(PII) Purchase Credits", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.JobIncomplete), "(PII) Job Incomplete", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.SuppliersDoNotMatch), "(PII) Supplier Do Not Match", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property POInvoiceAuthorisation() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceCorrect), "Matched Purchase Order - Supplier Invoice Price Correct", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceAbove), "Matched Purchase Order - Supplier Invoice Price Above", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceBelow), "Matched Purchase Order - Supplier Invoice Price Below", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property ReplenishmentStatusTypes() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReplenishmentStatusResults.AmountBelowMinQuantitiesStockOnOrder), "Below Min Quantities - Quantity On Order To Replenish Stock", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReplenishmentStatusResults.AmountBelowMinQuantitiesStockRequired), "Below Min Quantities - Order Required To Replenish Stock", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReplenishmentStatusResults.NoPreferredSupplierFound), "No Preferred Supplier Found", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property Yes_No() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {"Yes", "Yes", "0"})
            dt.Rows.Add(New String() {"No", "No", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property OrderTypeForSearch() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {"1", "Customer, Property (Select Property from Property list)", "0"})
            dt.Rows.Add(New String() {"2", "Customer, Warehouse (Select Warehouse from Warehouse locations)", "0"})
            dt.Rows.Add(New String() {"3", "Stock Profile (Select Profile from Stock list)", "0"})
            dt.Rows.Add(New String() {"4", "Warehouse (Select Warehouse from Warehouse locations)", "0"})
            dt.Rows.Add(New String() {"5", "Job (Search for Job to pick Engineer Visit)", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property OrderType() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {"1", "Customer (Select Delivery Location)", "0"})
            dt.Rows.Add(New String() {"2", "Stock Profile (Select Profile from Stock list)", "0"})
            dt.Rows.Add(New String() {"3", "Warehouse (Select Warehouse from Warehouse locations)", "0"})
            dt.Rows.Add(New String() {"4", "Job (Search for Job to pick Engineer Visit)", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property LocationType() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {"1", "Supplier", "0"})
            dt.Rows.Add(New String() {"2", "Stock Profile", "0"})
            dt.Rows.Add(New String() {"3", "Warehouse", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property InvoiceFrequency() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency.Weekly), Entity.Sys.Enums.InvoiceFrequency.Weekly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency.Monthly), Entity.Sys.Enums.InvoiceFrequency.Monthly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency.Quarterly), Entity.Sys.Enums.InvoiceFrequency.Quarterly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency.Bi_Annually), Entity.Sys.Enums.InvoiceFrequency.Bi_Annually.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency.Annually), Entity.Sys.Enums.InvoiceFrequency.Annually.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency.Per_Visit), Entity.Sys.Enums.InvoiceFrequency.Per_Visit.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency.AnnuallyDD), "Annual Direct Debit", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property InvoiceFrequency_NoWeekly() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Per_Visit), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Per_Visit.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.AnnuallyDD), "Annual Direct Debit", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property VisitFrequencyNoWeekly() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Monthly), Entity.Sys.Enums.VisitFrequency.Monthly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.GBS_4_Month_Visits), Entity.Sys.Enums.VisitFrequency.GBS_4_Month_Visits.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Quarterly), Entity.Sys.Enums.VisitFrequency.Quarterly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Bi_Annually), Entity.Sys.Enums.VisitFrequency.Bi_Annually.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Annually), Entity.Sys.Enums.VisitFrequency.Annually.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Fortnightly), Entity.Sys.Enums.VisitFrequency.Fortnightly.ToString, "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property ContractVisitType() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractVisitType.Commercial), Entity.Sys.Enums.ContractVisitType.Commercial.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractVisitType.Domestic), Entity.Sys.Enums.ContractVisitType.Domestic.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractVisitType.Electrical), Entity.Sys.Enums.ContractVisitType.Electrical.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractVisitType.SubContractor), Entity.Sys.Enums.ContractVisitType.SubContractor.ToString, "0"})
            '  dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractVisitType.Electrical), Entity.Sys.Enums.ContractVisitType.Electrical.ToString, "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property VisitFrequency() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Weekly), Entity.Sys.Enums.VisitFrequency.Weekly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Monthly), Entity.Sys.Enums.VisitFrequency.Monthly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Quarterly), Entity.Sys.Enums.VisitFrequency.Quarterly.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Bi_Annually), Entity.Sys.Enums.VisitFrequency.Bi_Annually.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitFrequency.Annually), Entity.Sys.Enums.VisitFrequency.Annually.ToString, "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property ContractStatus() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractStatus.Active),
                        Entity.Sys.Enums.ContractStatus.Active.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractStatus.Inactive),
                        Entity.Sys.Enums.ContractStatus.Inactive.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractStatus.Cancelled),
                        Entity.Sys.Enums.ContractStatus.Cancelled.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractStatus.InactiveUpgrade),
                        "Inactive - Upgraded", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractStatus.InactiveDowngrade),
                        "Inactive - Downgraded", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractStatus.InactiveTransferred),
                        "Inactive - Transferred to new property", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property ContractPaymentTypes() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractPaymentType.Annual), Entity.Sys.Enums.ContractPaymentType.Annual.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractPaymentType.Direct_Debit), Entity.Sys.Enums.ContractPaymentType.Direct_Debit.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractPaymentType.AnnualDirectDebit), "Annual Direct Debit", "0"})
            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property ContractInitialPaymentTypes() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractInitialPaymentType.DebitCard), "Debit Card", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractInitialPaymentType.CreditCard), "Credit Card", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractInitialPaymentType.Cash), "Cash", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractInitialPaymentType.Cheque), "Cheque", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractInitialPaymentType.Invoice), "Invoice", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractInitialPaymentType.BACS), "BACS", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractInitialPaymentType.FOC), "FOC", "0"})
            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property Appointments() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {CInt(1), "AM", "0"})
            dt.Rows.Add(New String() {CInt(2), "PM", "0"})
            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property ManualApp() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {CInt(1), "Boiler", "0"})
            dt.Rows.Add(New String() {CInt(2), "Gas Fire", "0"})
            dt.Rows.Add(New String() {CInt(3), "Cooker", "0"})
            dt.Rows.Add(New String() {CInt(4), "Unvented Cylinder", "0"})
            dt.Rows.Add(New String() {CInt(5), "Thermal Store Cylinder", "0"})
            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property ContractPeriod() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {1, "1 Year", "0"})
            dt.Rows.Add(New String() {2, "2 Years", "0"})
            dt.Rows.Add(New String() {3, "3 Years", "0"})
            dt.Rows.Add(New String() {4, "4 Years", "0"})
            dt.Rows.Add(New String() {5, "5 Years", "0"})
            dt.Rows.Add(New String() {6, "6 Years", "0"})
            dt.Rows.Add(New String() {7, "7 Years", "0"})
            dt.Rows.Add(New String() {8, "8 Years", "0"})
            dt.Rows.Add(New String() {9, "9 Years", "0"})
            dt.Rows.Add(New String() {10, "10 Years", "0"})
            dt.Rows.Add(New String() {11, "11 Years", "0"})
            dt.Rows.Add(New String() {12, "12 Years", "0"})

            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property ContractTypes2() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {367, "Silver Star", "0"})
            dt.Rows.Add(New String() {368, "Gold Star", "0"})
            dt.Rows.Add(New String() {369, "Platinum Star", "0"})
            dt.Rows.Add(New String() {68032, "Platinum Immediate", "0"})
            dt.Rows.Add(New String() {68294, "Totally Assured", "0"})
            dt.Rows.Add(New String() {69420, "Preventative Maintenance Contract", "0"})
            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property ReadingType() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {0, "Gas", "0"})
            dt.Rows.Add(New String() {1, "Oil", "0"})
            dt.Rows.Add(New String() {2, "Solid Fuel", "0"})
            dt.Rows.Add(New String() {3, "Unvented", "0"})
            dt.Rows.Add(New String() {4, "Solar", "0"})
            dt.Rows.Add(New String() {5, "ASHP", "0"})
            dt.Rows.Add(New String() {6, "GSHP", "0"})
            dt.Rows.Add(New String() {7, "Other", "0"})
            dt.Rows.Add(New String() {8, "Comercial Catering", "0"})
            dt.Rows.Add(New String() {9, "HIU", "0"})
            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property TankType() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))
            dt.Rows.Add(New String() {1, "Plastic", "0"})
            dt.Rows.Add(New String() {2, "Bunded", "0"})
            dt.Rows.Add(New String() {3, "Metal", "0"})
            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property ContractRenewal() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractRenewal.Renewed), Entity.Sys.Enums.ContractRenewal.Renewed.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractRenewal.NotRenewed), "Not Renewed", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property Quote_ElectricianPack() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {"1", "Pack A", "0"})
            dt.Rows.Add(New String() {"2", "Pack B", "0"})
            dt.Rows.Add(New String() {"3", "Pack C", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property QuoteContractStatus() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.QuoteContractStatus.Generated), Entity.Sys.Enums.QuoteContractStatus.Generated.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.QuoteContractStatus.Accepted), Entity.Sys.Enums.QuoteContractStatus.Accepted.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.QuoteContractStatus.Rejected), Entity.Sys.Enums.QuoteContractStatus.Rejected.ToString, "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property VisitStatus_For_Selection() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Parts_Need_Ordering), "Quote/Action Required", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts), "Waiting For Parts", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Parts_Despatched), "Parts Despatched", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule), "Ready For Schedule", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property VisitStatus_For_Viewing() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Parts_Need_Ordering), "Quote/Action Required", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts), "Waiting For Parts", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Parts_Despatched), "Parts Despatched", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule), "Ready For Schedule", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Scheduled), "Scheduled", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Downloaded), "Downloaded", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Uploaded), "Uploaded", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Not_To_Be_Invoiced), "Non Chargable", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Ready_To_Be_Invoiced), "Ready To Be Invoiced", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.VisitStatus.Invoiced), "Invoiced", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property JobStatuses() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobStatus.Open), "Open", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobStatus.Complete), "Complete", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property QuoteStatuses() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.QuoteContractStatus.Generated), "Generated", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.QuoteContractStatus.Accepted), "Accepted", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.QuoteContractStatus.Rejected), "Rejected", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property JobDefinitions() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobDefinition.Callout), "Callout", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobDefinition.Contract), "Contract", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobDefinition.Quoted), "Quoted", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobDefinition.Misc), "Misc", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property VisitDuration() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("VisitDuration"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            Dim settings As Entity.Management.Settings = DB.Manager.Get

            Dim sd As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursStart.Trim.Substring(0, 2), settings.WorkingHoursStart.Trim.Substring(3, 2), 0)
            Dim ed As DateTime = New DateTime(Now.Year, Now.Month, Now.Day, settings.WorkingHoursEnd.Trim.Substring(0, 2), settings.WorkingHoursEnd.Trim.Substring(3, 2), 0)

            Dim minutesAdded As Integer = 0

            While Not sd >= ed
                minutesAdded += settings.TimeSlot

                Dim numberOfHoursToAdd As Integer = CInt(Math.Floor((minutesAdded / 60)))
                Dim numberOfMinutesToAdd As Integer = CInt(minutesAdded - (numberOfHoursToAdd * 60))

                Dim str As String = ""
                Select Case numberOfHoursToAdd
                    Case 0
                        str += ""
                    Case 1
                        str += numberOfHoursToAdd & " hr "
                    Case Else
                        str += numberOfHoursToAdd & " hrs "
                End Select
                Select Case numberOfMinutesToAdd
                    Case 0
                        str += ""
                    Case 1
                        str += numberOfMinutesToAdd & " min"
                    Case Else
                        str += numberOfMinutesToAdd & " mins"
                End Select

                dt.Rows.Add(New String() {minutesAdded, str, 0})

                sd = sd.AddMinutes(settings.TimeSlot)
            End While

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property SystemDocumentTypes(ByVal OrderType As Entity.Sys.Enums.OrderType) As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder), "Supplier Purchase Order", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property Hours() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            For hour As Integer = 0 To 23
                Dim row As DataRow
                row = dt.NewRow
                If hour.ToString.Length = 1 Then
                    row.Item("DisplayMember") = "0" & hour.ToString
                Else
                    row.Item("DisplayMember") = hour.ToString
                End If
                row.Item("ValueMember") = hour
                row.Item("Deleted") = False
                dt.Rows.Add(row)
            Next

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property Minutes() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            For minute As Integer = 0 To 59
                Dim row As DataRow
                row = dt.NewRow
                If minute.ToString.Length = 1 Then
                    row.Item("DisplayMember") = "0" & minute.ToString
                Else
                    row.Item("DisplayMember") = minute.ToString
                End If
                row.Item("ValueMember") = minute
                row.Item("Deleted") = False
                dt.Rows.Add(row)
            Next

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property ReminderFrequency() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReminderFrequencies.Minutes), "Minutes", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReminderFrequencies.Hours), "Hours", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReminderFrequencies.Days), "Days", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReminderFrequencies.Weeks), "Weeks", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReminderFrequencies.Months), "Months", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ReminderFrequencies.Years), "Years", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property NumberSelector() As DataTable ' 1 to 60
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            For i As Integer = 1 To 60
                Dim row As DataRow
                row = dt.NewRow
                row.Item("DisplayMember") = i.ToString
                row.Item("ValueMember") = i
                row.Item("Deleted") = False
                dt.Rows.Add(row)
            Next

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property OutcomeStatuses() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Complete), "Complete", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Carded), "Carded", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Could_Not_Start), "Could Not Start", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Declined), "Declined", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Further_Works), "Further Works", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.EngineerVisitOutcomes.Visit_Not_Required), "Visit Not Required", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property ChecklistResults() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ChecklistResults.NOT_SET), "Choose...", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ChecklistResults.Yes), "Yes", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ChecklistResults.No), "No", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ChecklistResults.NA), "N / A", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property PeriodTypes() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PeriodType.Days), "Days", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PeriodType.Weeks), "Weeks", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PeriodType.Months), "Months", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PeriodType.Years), "Years", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property InvoiceStatus() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(-3), "---Show All---", "0"})
            ' dt.Rows.Add(New String() {CInt(-2), "Not Invoiced", "0"})
            dt.Rows.Add(New String() {CInt(-1), "Invoiced-Not Paid", "0"})
            dt.Rows.Add(New String() {CInt(0), "Invoiced-Payments Received", "0"})
            dt.Rows.Add(New String() {CInt(1), "Invoiced and Paid", "0"})

            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property ContractOnOrNone() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {"On Contract", "On Contract", "0"})
            dt.Rows.Add(New String() {"Not On Contract", "Not On Contract", "0"})

            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property Count(ByVal From As Integer, ByVal [To] As Integer) As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            For i As Integer = From To [To]
                dt.Rows.Add(New String() {i, i, 0})
            Next

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property CreditStatus() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return), "Awaiting Part Return", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Part_Returned_To_Supplier), "Part Returned to Supplier", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Sent_To_Supplier), "Credit Req Sent to Supplier", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Received), "Credit Received", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Sent_To_Sage), "Sent To Sage", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Cancelled_By_Engineer), "Credit Req Cancelled By Engineer", "0"})

            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property JOWStatus() As DataTable
        Get

            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobOfWorkStatus.Open), Entity.Sys.Enums.JobOfWorkStatus.Open.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobOfWorkStatus.Closed), Entity.Sys.Enums.JobOfWorkStatus.Closed.ToString, "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.JobOfWorkStatus.Complete), Entity.Sys.Enums.JobOfWorkStatus.Complete.ToString, "0"})

            Return dt

        End Get
    End Property

    Public Shared ReadOnly Property LetterType() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {"1", "Letter 1", "0"})
            dt.Rows.Add(New String() {"2", "Letter 2", "0"})
            dt.Rows.Add(New String() {"3", "Letter 3", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property Salutation() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {"Mr", "Mr", "0"})
            dt.Rows.Add(New String() {"Mrs", "Mrs", "0"})
            dt.Rows.Add(New String() {"Miss", "Miss", "0"})
            dt.Rows.Add(New String() {"Ms", "Ms", "0"})
            dt.Rows.Add(New String() {"Dr", "Dr", "0"})
            dt.Rows.Add(New String() {"Lord", "Lord", "0"})
            dt.Rows.Add(New String() {"Lady", "Lady", "0"})
            dt.Rows.Add(New String() {"Prof.", "Prof.", "0"})
            dt.Rows.Add(New String() {"Sir", "Sir", "0"})
            dt.Rows.Add(New String() {"Rev.", "Rev.", "0"})
            dt.Rows.Add(New String() {"Void", "Void", "0"})
            dt.Rows.Add(New String() {"Mx", "Mx", "0"})
            dt.Rows.Add(New String() {"Company Name", "Company Name", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property ServExpiry() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {-1, "Expired", "0"})
            dt.Rows.Add(New String() {7, "1 Week", "0"})
            dt.Rows.Add(New String() {14, "2 Weeks", "0"})
            dt.Rows.Add(New String() {21, "3 Weeks", "0"})
            dt.Rows.Add(New String() {28, "4 Weeks", "0"})
            'dt.Rows.Add(New String() {"Gas Fire Only", "Gas Fire Only", "0"})
            'dt.Rows.Add(New String() {"Gas Full System", "Gas Full System", "0"})
            'dt.Rows.Add(New String() {"Gas Warm Air", "Gas Warm Air", "0"})
            'dt.Rows.Add(New String() {"Oil Fired Heating", "Oil Fired Heating", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property Surveyor() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {1, "Install Surveyor", "0"})
            dt.Rows.Add(New String() {2, "Breakdown Engineer", "0"})
            dt.Rows.Add(New String() {3, "None", "0"})
            'dt.Rows.Add(New String() {3, "3 Weeks", "0"})
            'dt.Rows.Add(New String() {4, "4 Weeks", "0"})
            'dt.Rows.Add(New String() {"Gas Fire Only", "Gas Fire Only", "0"})
            'dt.Rows.Add(New String() {"Gas Full System", "Gas Full System", "0"})
            'dt.Rows.Add(New String() {"Gas Warm Air", "Gas Warm Air", "0"})
            'dt.Rows.Add(New String() {"Oil Fired Heating", "Oil Fired Heating", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property JobWizTerms() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {1, "Contract", "0"})
            dt.Rows.Add(New String() {2, "OTI", "0"})
            dt.Rows.Add(New String() {3, "POC", "0"})
            dt.Rows.Add(New String() {4, "FOC", "0"})
            'dt.Rows.Add(New String() {3, "3 Weeks", "0"})
            'dt.Rows.Add(New String() {4, "4 Weeks", "0"})
            'dt.Rows.Add(New String() {"Gas Fire Only", "Gas Fire Only", "0"})
            'dt.Rows.Add(New String() {"Gas Full System", "Gas Full System", "0"})
            'dt.Rows.Add(New String() {"Gas Warm Air", "Gas Warm Air", "0"})
            'dt.Rows.Add(New String() {"Oil Fired Heating", "Oil Fired Heating", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property ComoDateType() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {1, "Expiry", "0"})
            dt.Rows.Add(New String() {2, "Manufactured", "0"})
            dt.Rows.Add(New String() {3, "N/A", "0"})
            'dt.Rows.Add(New String() {3, "3 Weeks", "0"})
            'dt.Rows.Add(New String() {4, "4 Weeks", "0"})
            'dt.Rows.Add(New String() {"Gas Fire Only", "Gas Fire Only", "0"})
            'dt.Rows.Add(New String() {"Gas Full System", "Gas Full System", "0"})
            'dt.Rows.Add(New String() {"Gas Warm Air", "Gas Warm Air", "0"})
            'dt.Rows.Add(New String() {"Oil Fired Heating", "Oil Fired Heating", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property JobWizAdditional() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            '    dt.Rows.Add(New String() {1, "Breakdown At Same Time As Service", "0"})
            dt.Rows.Add(New String() {1, "Service At Same Time As Breakdown", "0"})

            'dt.Rows.Add(New String() {3, "3 Weeks", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property JobWizTypesOfWork() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            '    dt.Rows.Add(New String() {1, "Breakdown At Same Time As Service", "0"})
            dt.Rows.Add(New String() {1, "Heating", "0"})
            dt.Rows.Add(New String() {2, "Commercial", "0"})
            dt.Rows.Add(New String() {3, "Plumbing", "0"})
            dt.Rows.Add(New String() {4, "Electrical", "0"})
            dt.Rows.Add(New String() {5, "Building Maintenance / Pest", "0"})
            'dt.Rows.Add(New String() {3, "3 Weeks", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property JobWizServTypesOfWork() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            '    dt.Rows.Add(New String() {1, "Breakdown At Same Time As Service", "0"})
            dt.Rows.Add(New String() {1, "Standard Service", "0"})
            dt.Rows.Add(New String() {2, "Mutual Exchange", "0"})
            dt.Rows.Add(New String() {3, "Reinstate", "0"})
            dt.Rows.Add(New String() {4, "Void Check", "0"})
            'dt.Rows.Add(New String() {3, "3 Weeks", "0"})

            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property FleetVanContractProcurementMethod() As DataTable
        Get
            Dim dt As New DataTable
            dt.Columns.Add(New DataColumn("ValueMember"))
            dt.Columns.Add(New DataColumn("DisplayMember"))
            dt.Columns.Add(New DataColumn("Deleted"))

            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.FleetVanContractProcurementMethod.ContractHire),
                        "Contract Hire", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.FleetVanContractProcurementMethod.HPDepn),
                        "HP/.Depn", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.FleetVanContractProcurementMethod.Hire),
                        "Hire", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.FleetVanContractProcurementMethod.Owned),
                        "Owned", "0"})
            dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.FleetVanContractProcurementMethod.Leased),
                        "Leased", "0"})
            Return dt
        End Get
    End Property

    Public Shared ReadOnly Property SupplierIDList() As DataTable
        Get

            Dim dt As New DataTable
            dt = DB.Supplier.Supplier_GetAll.ToTable
            Return dt
        End Get
    End Property

End Class