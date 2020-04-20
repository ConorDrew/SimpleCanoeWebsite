Namespace Entity

    Namespace PickLists

        Public Class PickListSQL

            Private _database As Sys.Database
            Public Sub New(ByVal databaseIn As Sys.Database)
                _database = databaseIn
            End Sub

#Region "Functions"

            Public Function PickListTypes() As DataView
                Dim dt As New DataTable
                dt.Columns.Add(New DataColumn("ValueMember"))
                dt.Columns.Add(New DataColumn("DisplayMember"))
                dt.Columns.Add(New DataColumn("Deleted"))
                Dim row As DataRow

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Regions)
                row("DisplayMember") = "Regions"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.CustomerTypes)
                row("DisplayMember") = "Customer Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.JobTypes)
                row("DisplayMember") = "Job Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Types)
                row("DisplayMember") = "Product Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Makes)
                row("DisplayMember") = "Product Makes"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Models)
                row("DisplayMember") = "Product Models"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.PartCategories)
                row("DisplayMember") = "Part Categories"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.UnitTypes)
                row("DisplayMember") = "Unit Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.OrderChargeTypes)
                row("DisplayMember") = "Charge Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Engineer_Levels)
                row("DisplayMember") = "Engineer Levels/Qualifications"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.EngineerGroup)
                row("DisplayMember") = "Engineer Groups"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.NoteCategory)
                row("DisplayMember") = "Note Categories"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.DocumentTypes)
                row("DisplayMember") = "Document Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.QuoteRejectionReasons)
                row("DisplayMember") = "Rejection Reasons"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.TimeSheetTypes)
                row("DisplayMember") = "Timesheet Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.ScheduleRatesCategories)
                row("DisplayMember") = "Scheduled Rates Categories"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.PayGrades)
                row("DisplayMember") = "Pay Grades"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.DisciplinaryStatus)
                row("DisplayMember") = "Disciplinary Statuses"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.PartShelfReferences)
                row("DisplayMember") = "Part Shelf References"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.PartBinReferences)
                row("DisplayMember") = "Part Bin References"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.SourceOfCustomer)
                row("DisplayMember") = "Source Of Customer"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.VATCodes)
                row("DisplayMember") = "VAT Codes"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.ContractTypes)
                row("DisplayMember") = "Contract Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.ReasonsForContact)
                row("DisplayMember") = "Reasons For Contact"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.JOWPriority)
                row("DisplayMember") = "Job Of Work Priorities"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.HeatingSystemType)
                row("DisplayMember") = "Heating System Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.CylinderType)
                row("DisplayMember") = "Cylinder Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Jacket)
                row("DisplayMember") = "Jackets"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.CertificateType)
                row("DisplayMember") = "Certificate Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.CancellationReasons)
                row("DisplayMember") = "Cancellation Reasons"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.ContractPricing)
                row("DisplayMember") = "Renewal Prices"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.FTFCodes)
                row("DisplayMember") = "FTFCodes"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts)
                row("DisplayMember") = "CoverPlan Discounts"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.EquipmentType)
                row("DisplayMember") = "Equipment Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.EquipmentStatus)
                row("DisplayMember") = "Equipment Status"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.SalesNominal)
                row("DisplayMember") = "Sales Nominal For Region"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.PurchaseNominal)
                row("DisplayMember") = "Purchase Nominal For Region"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Department)
                row("DisplayMember") = "Departments"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.InvoiceTerms)
                row("DisplayMember") = "Invoice Terms"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.PriceList)
                row("DisplayMember") = "Price List"
                row("Deleted") = False
                dt.Rows.Add(row)

                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLPickListTypes.ToString

                Return New DataView(dt)
            End Function

            Public Function PickListTypesLimited() As DataView
                Dim dt As New DataTable
                dt.Columns.Add(New DataColumn("ValueMember"))
                dt.Columns.Add(New DataColumn("DisplayMember"))
                dt.Columns.Add(New DataColumn("Deleted"))
                Dim row As DataRow

             

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Types)
                row("DisplayMember") = "Product Types"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Makes)
                row("DisplayMember") = "Product Makes"
                row("Deleted") = False
                dt.Rows.Add(row)

                row = dt.NewRow()
                row("ValueMember") = CInt(Entity.Sys.Enums.PickListTypes.Models)
                row("DisplayMember") = "Product Models"
                row("Deleted") = False
                dt.Rows.Add(row)

          

                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLPickListTypes.ToString

                Return New DataView(dt)
            End Function


            Public Function GetAll(ByVal enumTypeID As Entity.Sys.Enums.PickListTypes, Optional ByVal async As Boolean = False) As DataView
                Dim dt As DataTable = Nothing
                If async Then
                    Dim sqlEnumTypeId As New SqlClient.SqlParameter("@EnumTypeId", CInt(enumTypeID))

                    dt = _database.ExecuteSP_DataTable("Picklists_GetAll_ForEnumType", sqlEnumTypeId)
                Else
                    _database.ClearParameter()
                    _database.AddParameter("?EnumTypeID", CInt(enumTypeID))

                    dt = _database.ExecuteCommand_DataTable("Picklists_Get.sql")

                End If


                dt.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString
                Return New DataView(dt)
            End Function

            Public Function GetAllPartMappings(ByVal enumTypeID As Entity.Sys.Enums.PickListTypes) As DataView
                _database.ClearParameter()
                _database.AddParameter("?EnumTypeID", CInt(enumTypeID))

                Dim dt As DataTable = _database.ExecuteCommand_DataTable("Picklists_Get_PartMapping.sql")


                dt.TableName = Entity.Sys.Enums.TableNames.tblPartCategoryMapping.ToString
                Return New DataView(dt)
            End Function

            Public Function Get_One_As_Object(ByVal ManagerID As Integer) As Entity.PickLists.PickList
                _database.ClearParameter()
                _database.AddParameter("?ManagerID", ManagerID)
                Dim dt As DataTable = _database.ExecuteCommand_DataTable("Picklists_GetOne.sql")

                If dt.Rows.Count > 0 Then
                    Dim picklist As New Entity.PickLists.PickList
                    picklist.SetManagerID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("ManagerID"))
                    picklist.SetEnumTypeID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("EnumTypeID"))
                    picklist.SetName = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Name"))
                    picklist.SetDescription = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("Description"))
                    picklist.SetDeleted = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Deleted"))
                    picklist.SetPercentageRate = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("PercentageRate"))
                    If dt.Columns.Contains("Mandatory") Then picklist.SetMandatory = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("Mandatory"))
                    Return picklist
                    Else
                        Return New PickList
                End If
            End Function

            Public Function Insert(ByVal pickList As Entity.PickLists.PickList) As Integer
                _database.ClearParameter()
                _database.AddParameter("?EnumTypeID", pickList.EnumTypeID)
                _database.AddParameter("?Name", pickList.Name)
                _database.AddParameter("?Description", pickList.Description)
                _database.AddParameter("?Mandatory", pickList.Mandatory)
                Select Case pickList.EnumTypeID
                    Case Entity.Sys.Enums.PickListTypes.VATCodes, Entity.Sys.Enums.PickListTypes.PartCategories, Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts
                        _database.AddParameter("?PercentageRate", pickList.PercentageRate)
                    Case Entity.Sys.Enums.PickListTypes.Engineer_Levels
                        _database.AddParameter("?PercentageRate", pickList.PercentageRate)
                    Case Else
                        _database.AddParameter("?PercentageRate", 0)
                End Select

                Return _database.ExecuteCommand_Object("Picklists_Insert.sql")
            End Function

            Public Function InsertPartCategory(ByVal ManagerID As Integer, ByVal PartMapMatch As String) As Integer
                _database.ClearParameter()
                _database.AddParameter("?ManagerID", ManagerID)
                _database.AddParameter("?PartMapMatch", PartMapMatch)

                Return _database.ExecuteCommand_Object("Picklists_InsertPartMapping.sql")
            End Function

            Public Sub Update(ByVal pickList As Entity.PickLists.PickList)
                _database.ClearParameter()
                _database.AddParameter("?Name", pickList.Name)
                _database.AddParameter("?Description", pickList.Description)
                _database.AddParameter("?Mandatory", pickList.Mandatory)
                _database.AddParameter("?ManagerID", pickList.ManagerID)
                Select Case pickList.EnumTypeID
                    Case Entity.Sys.Enums.PickListTypes.VATCodes, Entity.Sys.Enums.PickListTypes.PartCategories, Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts
                        _database.AddParameter("?PercentageRate", pickList.PercentageRate)
                    Case Entity.Sys.Enums.PickListTypes.Engineer_Levels
                        _database.AddParameter("?PercentageRate", pickList.PercentageRate)
                    Case Else
                        _database.AddParameter("?PercentageRate", 0)
                End Select
                _database.ExecuteCommand_NO_Return("Picklists_Update.sql")
            End Sub

            Public Sub UpdatePartMapping(ByVal PartMapID As Integer, ByVal ManagerID As Integer, ByVal PartMapMatch As String)
                _database.ClearParameter()
                _database.AddParameter("?PartMapID", PartMapID)
                _database.AddParameter("?ManagerID", ManagerID)
                _database.AddParameter("?PartMapMatch", PartMapMatch)

                _database.ExecuteCommand_NO_Return("Picklists_UpdatePartMapping.sql")
            End Sub

            Public Sub UpdateSellPrices(ByVal pickList As Entity.PickLists.PickList)
                _database.ClearParameter()
                _database.AddParameter("@CategoryID", pickList.ManagerID)
                _database.ExecuteSP_NO_Return("Picklists_UpdatePartsMargins")
            End Sub

            Public Sub UpdateSellPricesByPart(ByVal CategoryID As Integer, ByVal PartID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CategoryID", CategoryID)
                _database.AddParameter("@PartID", PartID)
                _database.ExecuteSP_NO_Return("Picklists_UpdatePartsMarginsByPart")
            End Sub

            Public Sub Delete(ByVal ManagerID As Integer)
                _database.ClearParameter()
                _database.AddParameter("?ManagerID", ManagerID)
                _database.ExecuteCommand_NO_Return("Picklists_Delete.sql")
            End Sub

            Public Sub DeletePartMapping(ByVal PartMapID As Integer)
                _database.ClearParameter()
                _database.AddParameter("?PartMapID", PartMapID)
                _database.ExecuteCommand_NO_Return("Picklists_DeletePartMapping.sql")
            End Sub

            Public Function Region_Usage(ByVal RegionID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@RegionID", RegionID)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Region_Usage")

                dt.TableName = Entity.Sys.Enums.TableNames.tblRegion.ToString
                Return New DataView(dt)
            End Function

            Public Function Check_Unique_Name(ByVal Name As String, ByVal ID As Integer, ByVal type As Entity.Sys.Enums.PickListTypes) As Boolean
                Dim NumberOfRows As Integer = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(ManagerID) as 'NumberOfRows' " & _
                "FROM tblpicklists WHERE EnumTypeID = " & CInt(type) & " AND Name = '" & Name & "' AND ManagerID <> " & ID, False))

                If NumberOfRows = 0 Then
                    Return True
                Else
                    Return False
                End If
            End Function


            Public Function Get_Single_Description(ByVal Name As String, ByVal type As Entity.Sys.Enums.PickListTypes) As String
                Dim Description As String = Entity.Sys.Helper.MakeStringValid(_database.ExecuteScalar("SELECT Description " & _
                "FROM tblpicklists WHERE EnumTypeID = " & CInt(type) & " AND Name = '" & Name & "'", False))

                Return Description
            End Function

#End Region

        End Class

    End Namespace

End Namespace