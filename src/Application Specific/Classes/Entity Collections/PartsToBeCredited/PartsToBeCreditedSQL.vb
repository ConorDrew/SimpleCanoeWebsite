Imports System.Data.SqlClient

Namespace Entity

    Namespace PartsToBeCrediteds

        Public Class PartsToBeCreditedSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Function [PartsToBeCredited_Get](ByVal PartsToBeCreditedID As Integer) As PartsToBeCredited
                _database.ClearParameter()
                _database.AddParameter("@PartsToBeCreditedID", PartsToBeCreditedID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oPartsToBeCredited As New PartsToBeCredited
                        With oPartsToBeCredited
                            .IgnoreExceptionsOnSetMethods = True
                            .SetPartsToBeCreditedID = dt.Rows(0).Item("PartsToBeCreditedID")
                            .SetOrderID = dt.Rows(0).Item("OrderID")
                            .SetSupplierID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("SupplierID"))
                            .SetPartID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("PartID"))
                            .SetQty = dt.Rows(0).Item("Qty")
                            .SetManuallyAdded = Entity.Sys.Helper.MakeBooleanValid(dt.Rows(0).Item("ManuallyAdded"))
                            .SetStatusID = Entity.Sys.Helper.MakeIntegerValid(dt.Rows(0).Item("StatusID"))
                            .SetCreditReceived = Entity.Sys.Helper.MakeDoubleValid(dt.Rows(0).Item("CreditReceived"))
                            .SetOrderReference = Entity.Sys.Helper.MakeStringValid(dt.Rows(0).Item("OrderReference"))

                        End With
                        oPartsToBeCredited.Exists = True
                        Return oPartsToBeCredited
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [PartsToBeCredited_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function

            Public Function PartsToBeCredited_Get_PartsCreditID(ByVal PartCreditID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@PartCreditID", PartCreditID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_PartsCreditID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function

            Public Function PartsToBeCredited_Get_OrderID(ByVal OrderID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderID", OrderID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_Order")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function

            Public Function PartsToBeCredited_Get_OrderPartID(ByVal OrderPartID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@OrderPartID", OrderPartID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_OrderPart")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function


            Public Function [Insert](ByVal oPartsToBeCredited As PartsToBeCredited) As PartsToBeCredited
                _database.ClearParameter()
                AddPartsToBeCreditedParametersToCommand(oPartsToBeCredited)
                _database.AddParameter("@AddedByUserID", loggedInUser.UserID, True)
                _database.AddParameter("@OrderPartID", oPartsToBeCredited.PartOrderID, True)
                oPartsToBeCredited.SetPartsToBeCreditedID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartsToBeCredited_Insert"))
                oPartsToBeCredited.Exists = True
                Return oPartsToBeCredited
            End Function

            Public Sub [Update](ByVal oPartsToBeCredited As PartsToBeCredited)
                _database.ClearParameter()
                _database.AddParameter("@PartsToBeCreditedID", oPartsToBeCredited.PartsToBeCreditedID, True)
                AddPartsToBeCreditedParametersToCommand(oPartsToBeCredited)
                _database.ExecuteSP_NO_Return("PartsToBeCredited_Update")
            End Sub

            Private Sub AddPartsToBeCreditedParametersToCommand(ByRef oPartsToBeCredited As PartsToBeCredited)
                With _database
                    .AddParameter("@OrderID", oPartsToBeCredited.OrderID, True)
                    .AddParameter("@SupplierID", oPartsToBeCredited.SupplierID, True)
                    .AddParameter("@PartID", oPartsToBeCredited.PartID, True)
                    .AddParameter("@Qty", oPartsToBeCredited.Qty, True)
                    .AddParameter("@ManuallyAdded", oPartsToBeCredited.ManuallyAdded, True)
                    .AddParameter("@StatusID", oPartsToBeCredited.StatusID, True)
                    .AddParameter("@CreditReceived", oPartsToBeCredited.CreditReceived, True)
                    .AddParameter("@OrderReference", oPartsToBeCredited.OrderReference, True)
                End With
            End Sub

            Public Function PartCredits_Insert(ByVal AmountReceived As Double, _
                                            ByVal Notes As String, _
                                            ByVal DateReceived As DateTime, _
                                            ByVal DateExportedToSage As DateTime, _
                                             ByVal TaxCodeID As Integer, _
                                            ByVal NominalCode As String, _
                                           ByVal DepartmentRef As String, _
                                           ByVal ExtraRef As String, ByVal SupplierCreditRef As String) As Integer
                _database.ClearParameter()

                _database.AddParameter("@AmountReceived", AmountReceived, True)
                _database.AddParameter("@Notes", Notes, True)
                _database.AddParameter("@DateReceived", DateReceived, True)
                If DateExportedToSage = Date.MinValue Then
                    _database.AddParameter("@DateExportedToSage", DBNull.Value, True)
                Else
                    _database.AddParameter("@DateExportedToSage", DateExportedToSage, True)
                End If
                _database.AddParameter("@TaxCodeID", TaxCodeID, True)
                _database.AddParameter("@NominalCode", NominalCode, True)
                _database.AddParameter("@DepartmentRef", DepartmentRef, True)
                _database.AddParameter("@ExtraRef", ExtraRef, True)
                _database.AddParameter("@SupplierCreditRef", SupplierCreditRef, True)
                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartCredits_Insert"))
            End Function

            Public Function PartCredits_Update(ByVal PartCreditsID As Integer, _
                                              ByVal AmountReceived As Double, _
                                            ByVal Notes As String, _
                                            ByVal DateReceived As DateTime, _
                                            ByVal DateExportedToSage As DateTime, _
                                             ByVal TaxCodeID As Integer, _
                                            ByVal NominalCode As String, _
                                           ByVal DepartmentRef As String, _
                                           ByVal ExtraRef As String, ByVal SupplierCreditRef As String) As Integer
                _database.ClearParameter()
                _database.AddParameter("@PartCreditsID", PartCreditsID, True)
                _database.AddParameter("@AmountReceived", AmountReceived, True)
                _database.AddParameter("@Notes", Notes, True)
                _database.AddParameter("@DateReceived", DateReceived, True)
                If DateExportedToSage = Date.MinValue Then
                    _database.AddParameter("@DateExportedToSage", DBNull.Value, True)
                Else
                    _database.AddParameter("@DateExportedToSage", DateExportedToSage, True)
                End If
                _database.AddParameter("@TaxCodeID", TaxCodeID, True)
                _database.AddParameter("@NominalCode", NominalCode, True)
                _database.AddParameter("@DepartmentRef", DepartmentRef, True)
                _database.AddParameter("@ExtraRef", ExtraRef, True)
                _database.AddParameter("@SupplierCreditRef", SupplierCreditRef, True)

                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartCredits_Update"))
            End Function

            Public Function PartCredits_Update_SageDate(ByVal PartCreditsID As Integer, _
                                                         ByVal DateExportedToSage As DateTime) As Integer
                _database.ClearParameter()
                _database.AddParameter("@PartCreditsID", PartCreditsID, True)

                If DateExportedToSage = Date.MinValue Then
                    _database.AddParameter("@DateExportedToSage", DBNull.Value, True)
                Else
                    _database.AddParameter("@DateExportedToSage", DateExportedToSage, True)
                End If
                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartCredits_Update_SageDate"))
            End Function

            Public Sub PartCreditParts_Insert(ByVal PartCreditID As Integer, ByVal PartsToBeCreditedID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@PartCreditID", PartCreditID, True)
                _database.AddParameter("@PartsToBeCreditedID", PartsToBeCreditedID, True)
                _database.ExecuteSP_NO_Return("PartCreditParts_Insert")
            End Sub


            Public Function Order_GetCredit(ByVal PartCreditID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CreditID", PartCreditID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_CreditID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function

            Public Sub [Delete](ByVal CreditID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@CreditID", CreditID, True)

                _database.ExecuteSP_NO_Return("PartsToBeCredited_Delete")
            End Sub


            Public Function PartsToBeCredited_Get_Parts_For_CreditID(ByVal PartCreditID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@CreditID", PartCreditID, True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("PartsToBeCredited_Get_For_CreditID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblPartsToBeCredited.ToString
                Return New DataView(dt)
            End Function


            Public Function PartsToBeCredited_Insert(ByVal SupplierID As Integer, ByVal OrderID As Integer, ByVal PartID As Integer, ByVal Quantity As Integer, ByVal OrderRef As String, ByVal EngineerID As Integer, ByVal OrderPArtID As Integer) As Integer

                _database.ClearParameter()

                _database.AddParameter("@SupplierID", SupplierID, True)
                _database.AddParameter("@OrderID", OrderID, True)
                _database.AddParameter("@PartID", PartID, True)
                _database.AddParameter("@Qty", Quantity, True)
                _database.AddParameter("@ManuallyAdded", 0, True)
                _database.AddParameter("@StatusID", 1, True)
                _database.AddParameter("@CreditReceived", 0.0, True)
                _database.AddParameter("@AddedByUserID", 2, True)
                _database.AddParameter("@OrderReference", OrderRef, True)
                _database.AddParameter("@EngineerID", EngineerID, True)
                _database.AddParameter("@DatePartReturned", DBNull.Value, True)
                _database.AddParameter("@OrderPartID", OrderPArtID, True)

                Return Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("PartsToBeCredited_Insert"))

            End Function






#End Region

        End Class

    End Namespace

End Namespace


