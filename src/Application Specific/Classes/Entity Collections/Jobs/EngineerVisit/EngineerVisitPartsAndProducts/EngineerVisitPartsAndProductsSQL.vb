Imports System.Data.SqlClient

Namespace Entity

    Namespace EngineerVisitsPartsAndProducts

        Public Class EngineerVisitPartsAndProductsSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID2")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
                Dim c As Integer = dt.Constraints.Count
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitPartsAndProductsNeeded_Get_For_EngineerVisitID(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsNeeded_Get_For_EngineerVisitID")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString
                Return New DataView(dt)
            End Function

            Public Sub PartsUsed_Delete(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Delete")
            End Sub

            Public Sub PartsUsed_Insert(ByVal oEngineerVisitPartsAndProducts As EngineerVisitPartsAndProducts)
                _database.ClearParameter()

                _database.AddParameter("@EngineerVisitID", oEngineerVisitPartsAndProducts.EngineerVisitID, True)
                _database.AddParameter("@PartID", oEngineerVisitPartsAndProducts.PartOrProductID, True)
                _database.AddParameter("@Quantity", oEngineerVisitPartsAndProducts.Quantity, True)
                _database.AddParameter("@AssetID", oEngineerVisitPartsAndProducts.AssetID, True)
                _database.AddParameter("@EngineerVisitPartAllocatedID", oEngineerVisitPartsAndProducts.AllocatedID, True)
                _database.AddParameter("@LocationID", oEngineerVisitPartsAndProducts.LocationID, True)
                If oEngineerVisitPartsAndProducts.SpecialDescription = "" Then  ' dont insert blanks as this will cause the datagrid to show blanks the values need to be Null in DB
                Else
                    _database.AddParameter("@SpecialPrice", oEngineerVisitPartsAndProducts.SpecialPrice, True)
                    _database.AddParameter("@SpecialDescription", oEngineerVisitPartsAndProducts.SpecialDescription, True)
                    _database.AddParameter("@SpecialPartNumber", oEngineerVisitPartsAndProducts.SpecialPartNumber, True)
                End If

                _database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Insert")
            End Sub

            Public Sub ProductsUsed_Delete(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Delete")
            End Sub

            Public Sub ProductsUsed_Insert(ByVal oEngineerVisitPartsAndProducts As EngineerVisitPartsAndProducts)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", oEngineerVisitPartsAndProducts.EngineerVisitID, True)
                _database.AddParameter("@ProductID", oEngineerVisitPartsAndProducts.PartOrProductID, True)
                _database.AddParameter("@Quantity", oEngineerVisitPartsAndProducts.Quantity, True)
                _database.AddParameter("@EngineerVisitProductAllocatedID", oEngineerVisitPartsAndProducts.AllocatedID, True)

                _database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Insert")
            End Sub

            Public Sub PartsNeeded_Delete(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitPartsNeeded_Delete")
            End Sub

            Public Sub PartsNeeded_Insert(ByVal oEngineerVisitPartsAndProducts As EngineerVisitPartsAndProducts)
                _database.ClearParameter()

                _database.AddParameter("@EngineerVisitID", oEngineerVisitPartsAndProducts.EngineerVisitID, True)
                _database.AddParameter("@PartID", oEngineerVisitPartsAndProducts.PartOrProductID, True)
                _database.AddParameter("@Quantity", oEngineerVisitPartsAndProducts.Quantity, True)

                _database.ExecuteSP_NO_Return("EngineerVisitPartsNeeded_Insert")
            End Sub

            Public Sub ProductsNeeded_Delete(ByVal EngineerVisitID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitProductsNeeded_Delete")
            End Sub

            Public Sub ProductsNeeded_Insert(ByVal oEngineerVisitPartsAndProducts As EngineerVisitPartsAndProducts)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", oEngineerVisitPartsAndProducts.EngineerVisitID, True)
                _database.AddParameter("@ProductID", oEngineerVisitPartsAndProducts.PartOrProductID, True)
                _database.AddParameter("@Quantity", oEngineerVisitPartsAndProducts.Quantity, True)

                _database.ExecuteSP_NO_Return("EngineerVisitProductsNeeded_Insert")
            End Sub

            Public Function EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit(ByVal EngineerVisitID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitID", EngineerVisitID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution2(ByVal id As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", id, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString
                Return New DataView(dt)
            End Function

            Public Function EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3(ByVal id As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartID", id, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitPartsAndProductsDistributed_GetAll_For_Distribution3")
                dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsDistributed.ToString
                Return New DataView(dt)
            End Function

            Public Function Parts_Used_Report(ByVal fromDate As DateTime, ByVal toDate As DateTime) As DataView
                _database.ClearParameter()
                _database.AddParameter("@fromDate", fromDate, True)
                _database.AddParameter("@toDate", toDate, True)
                _database.AddParameter("@OrderLocationSupplierEnumValue", CInt(Sys.Enums.LocationType.Supplier), True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("Parts_Used_Report")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Function Equipment_Used_Report(ByVal fromDate As DateTime, ByVal toDate As DateTime) As DataView
                _database.ClearParameter()
                _database.AddParameter("@fromDate", fromDate, True)
                _database.AddParameter("@toDate", toDate, True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("Equipment_Used_Report")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString
                Return New DataView(dt)
            End Function

            Public Sub PartsUsed_DeleteOne(ByVal EngineerVisitPartsUsedID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitPartsUsedID", EngineerVisitPartsUsedID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_Delete_One")
            End Sub

            Public Sub ProductsUsed_DeleteOne(ByVal EngineerVisitProductsUsedID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitProductsUsedID", EngineerVisitProductsUsedID, True)
                _database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_Delete_One")
            End Sub

            Public Sub ProductsUsed_Update(ByVal EngineerVisitProductsUsedID As Integer, ByVal Quantity As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitProductsUsedID", EngineerVisitProductsUsedID, True)
                _database.AddParameter("@Quantity", Quantity, True)

                _database.ExecuteSP_NO_Return("EngineerVisitProductsUsed_UpdateQty")
            End Sub

            Public Sub PartsUsed_Update(ByVal EngineerVisitPartsUsedID As Integer, ByVal Quantity As Integer)
                _database.ClearParameter()
                _database.AddParameter("@EngineerVisitPartsUsedID", EngineerVisitPartsUsedID, True)
                _database.AddParameter("@Quantity", Quantity, True)

                _database.ExecuteSP_NO_Return("EngineerVisitPartsUsed_UpdateQty")
            End Sub

            Public Function Get_CurrentCost_ByJobID(ByVal jobId As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@JobID", jobId, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("EngineerVisitParts_Get_CurrentCost_ByJobID")
                Return New DataView(dt)
            End Function

#End Region

        End Class

    End Namespace

End Namespace