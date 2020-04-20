Imports System.Data.SqlClient

Namespace Entity

    Namespace InvoicedLiness

        Public Class InvoicedLinesSQL
            Private _database As Sys.Database

            Public Sub New(ByVal database As Sys.Database)
                _database = database
            End Sub

#Region "Functions"

            Public Sub Delete(ByVal InvoicedLineID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@InvoicedLineID", InvoicedLineID, True)
                _database.ExecuteSP_NO_Return("InvoicedLines_Delete")
            End Sub

            Public Function [InvoicedLines_Get](ByVal InvoicedLineID As Integer) As InvoicedLines
                _database.ClearParameter()
                _database.AddParameter("@InvoicedLineID", InvoicedLineID)

                'Get the datatable from the database store in dt
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedLines_Get")

                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        Dim oInvoicedLines As New InvoicedLines
                        With oInvoicedLines
                            .IgnoreExceptionsOnSetMethods = True
                            .SetInvoicedLineID = dt.Rows(0).Item("InvoicedLineID")
                            .SetInvoicedID = dt.Rows(0).Item("InvoicedID")
                            .SetInvoiceToBeRaisedID = dt.Rows(0).Item("InvoiceToBeRaisedID")
                            .SetAmount = dt.Rows(0).Item("Amount")

                        End With
                        oInvoicedLines.Exists = True
                        Return oInvoicedLines
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End Function

            Public Function [InvoicedLines_GetAll]() As DataView
                _database.ClearParameter()
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedLines_GetAll")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoicedLines.ToString
                Return New DataView(dt)
            End Function

            Public Function [InvoicedLines_GetAll_ByInvoiceToBeRaisedID](ByVal InvoiceToBeRaisedID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoiceToBeRaisedID", InvoiceToBeRaisedID, True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoiceToBeRaisedID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoicedLines.ToString
                Return New DataView(dt)
            End Function

            Public Function [InvoicedLines_GetAll_ByInvoicedID](ByVal InvoicedID As Integer) As DataView
                _database.ClearParameter()
                _database.AddParameter("@InvoicedID", InvoicedID, True)
                _database.AddParameter("@JobInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Visit), True)
                _database.AddParameter("@OrderInvTypeEnum", CInt(Entity.Sys.Enums.InvoiceType.Order), True)
                _database.AddParameter("@Contract_Option1Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option1), True)
                _database.AddParameter("@Contract_Option2Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option2), True)
                _database.AddParameter("@Contract_Option3Enum", CInt(Entity.Sys.Enums.InvoiceType.Contract_Option3), True)

                Dim dt As DataTable = _database.ExecuteSP_DataTable("InvoicedLines_GetAll_ByInvoicedID")
                dt.TableName = Entity.Sys.Enums.TableNames.tblInvoicedLines.ToString
                Return New DataView(dt)
            End Function

            Public Function [Insert](ByVal oInvoicedLines As InvoicedLines) As InvoicedLines
                _database.ClearParameter()
                AddInvoicedLinesParametersToCommand(oInvoicedLines)

                oInvoicedLines.SetInvoicedLineID = Entity.Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("InvoicedLines_Insert"))
                oInvoicedLines.Exists = True
                Return oInvoicedLines
            End Function

            Public Sub [Update](ByVal oInvoicedLines As InvoicedLines)
                _database.ClearParameter()
                _database.AddParameter("@InvoicedLineID", oInvoicedLines.InvoicedLineID, True)
                AddInvoicedLinesParametersToCommand(oInvoicedLines)
                _database.ExecuteSP_NO_Return("InvoicedLines_Update")
            End Sub

            Private Sub AddInvoicedLinesParametersToCommand(ByRef oInvoicedLines As InvoicedLines)
                With _database
                    .AddParameter("@InvoicedID", oInvoicedLines.InvoicedID, True)
                    .AddParameter("@InvoiceToBeRaisedID", oInvoicedLines.InvoiceToBeRaisedID, True)
                    .AddParameter("@Amount", oInvoicedLines.Amount, True)
                End With
            End Sub

            Public Sub InvoicedLinesTotal_Change(ByVal InvoicedLineID As Integer, ByVal Amount As Double)
                _database.ClearParameter()
                _database.AddParameter("@InvoicedLineID", InvoicedLineID, True)
                _database.AddParameter("@Amount", Amount, True)
                _database.AddParameter("@UserID", loggedInUser.UserID, True)
                _database.ExecuteSP_NO_Return("InvoicedLinesTotal_Change")
            End Sub

            Public Sub InvoicedLinesTotal_ChangeInvoiceDetails(ByVal InvoicedLineID As Integer, ByVal AccountCode As String, ByVal Department As String, ByVal NominalCode As String, ByVal TaxDate As Date, ByVal InvoiceTypeID As Integer)
                _database.ClearParameter()
                _database.AddParameter("@InvoicedLineID", InvoicedLineID, True)
                _database.AddParameter("@AccountCode", AccountCode, True)
                _database.AddParameter("@Department", Department, True)
                _database.AddParameter("@NominalCode", NominalCode, True)
                _database.AddParameter("@TaxDate", TaxDate, True)
                _database.AddParameter("@InvoiceTypeID", InvoiceTypeID, True)
                _database.ExecuteSP_NO_Return("InvoicedLinesTotal_ChangeDetails")
            End Sub

            Public Sub Invoiced_ChangeTerm(ByVal InvoicedID As Integer, ByVal Term As Integer, ByVal PaidBy As Integer)
                _database.ClearParameter()
                _database.AddParameter("@InvoicedID", InvoicedID, True)
                _database.AddParameter("@TermID", Term, True)
                If PaidBy > 0 Then
                    _database.AddParameter("@PaidByID", PaidBy, True)
                End If

                _database.AddParameter("@UserID", loggedInUser.UserID, True)
                _database.ExecuteSP_NO_Return("Invoiced_ChangeTerm")
            End Sub

#End Region

        End Class

    End Namespace

End Namespace