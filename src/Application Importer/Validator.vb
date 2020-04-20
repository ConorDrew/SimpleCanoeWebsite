Imports System.Data.SqlClient

Namespace Importer

    Public Class Validator

#Region "Properties"

        Private _DataToValidate As ArrayList
        Private _arrayList As ArrayList
        Private _fRMImportNew As FRMPartsImport

        Sub New(arrayList As ArrayList, fRMImportNew As FRMPartsImport)
            ' TODO: Complete member initialization
            _arrayList = arrayList
            _fRMImportNew = fRMImportNew
        End Sub

        Public Property DataToValidate() As ArrayList
            Get
                Return _DataToValidate
            End Get
            Set(ByVal Value As ArrayList)
                _DataToValidate = Value
            End Set
        End Property

        Private _Errors As ArrayList

        Public Property Errors() As ArrayList
            Get
                Return _Errors
            End Get
            Set(ByVal Value As ArrayList)
                _Errors = Value
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

        Public Sub New(ByVal DataToValidateIn As ArrayList, ByRef ImportFormIn As FRMImport)
            DataToValidate = DataToValidateIn
            Errors = New ArrayList
            ImportForm = ImportFormIn

            ImportForm.MoveProgressOn()
        End Sub

        Public Function Validate(ByVal SupplierID As Integer) As ArrayList
            Dim returnArr As ArrayList = Nothing

            ResetCells()

            For dvIndex As Integer = 0 To DataToValidate.Count - 1
                Dim dv As DataView = CType(DataToValidate(dvIndex), DataView)

                If dvIndex = 0 And dv.Table.TableName = "Parts" Then

                    'Check Columns
                    Dim ExpectedColumns() As String = New String() {"Part Code", "Name/Description", "Category", "Notes", "Sell Price", "Supplier Part Code", "Supplier Qty", "Supplier Price"}
                    For ExpectedColumnIndex As Integer = 0 To ExpectedColumns.Length - 1
                        Dim ExpectedColumn As String = ExpectedColumns(ExpectedColumnIndex)

                        If Not dv.Table.Columns(ExpectedColumnIndex).ColumnName = ExpectedColumn Then
                            Errors.Add(String.Format("{0} Column is Missing at position {1}", ExpectedColumn, ExpectedColumnIndex))
                        End If
                    Next

                    If Errors.Count = 0 Then
                        'Check Data
                        returnArr = ValidateParts(dv, SupplierID)
                    End If
                ElseIf dvIndex = 0 And dv.Table.TableName = "Sites" Then

                    'Check Data
                    returnArr = ValidateSites(dv)
                Else
                    Errors.Add("The first worksheet must be titled ""Parts""" & "Or ""Sites""")
                End If

                ImportForm.MoveProgressOn()
            Next

            Return returnArr
        End Function

        Public Sub ResetCells()
            'For Each tp As TabPage In ImportForm.tcData.TabPages
            '    For Each row As DataRow In CType(tp.Controls(0), UCData).Data.Table.Rows
            '        For Each col As DataColumn In CType(tp.Controls(0), UCData).Data.Table.Columns
            '            If col.ColumnName.EndsWith("COLOURBOOLEANCOLUMN") Then
            '                row.Item(col.ColumnName) = False
            '            End If
            '        Next
            '    Next
            'Next
        End Sub

        Public Sub ErrorInCell(ByVal SheetNumber As Integer, ByVal RowNumber As Integer, ByVal ColumnName As String, ByVal Message As String)
            'CType(ImportForm.tcData.TabPages(SheetNumber).Controls(0), UCData).Data.Table.Rows(RowNumber).Item(ColumnName & "COLOURBOOLEANCOLUMN") = True

            Errors.Add(String.Format("Error in {0} at row {1}: {2} - {3}", CType(DataToValidate(SheetNumber), DataView).Table.TableName, RowNumber + 1, ColumnName, Message))
        End Sub

#End Region

#Region "Private Functions"

        Private Function ValidateParts(ByVal dvParts As DataView, ByVal SupplierID As Integer) As ArrayList
            Dim insertCount As Integer = 0
            Dim updateCount As Integer = 0

            Try
                For partIndex As Integer = 0 To dvParts.Count - 1
                    Dim part As DataRowView = dvParts(partIndex)

                    'ImportForm.SetLastPartAttempted(part("Part Code"))

                    'Part Code
                    If IsDBNull(part("Part Code")) OrElse CStr(part("Part Code")).Length <= 0 Then
                        ErrorInCell(0, partIndex, "Part Code (MPN)", "Required field")
                    Else

                        Dim partsFound As Integer = DB.Part.Part_Exists(part("Part Code"), part("Supplier Part Code"))

                        If partsFound = 0 Then
                            insertCount += 1

                            'Name/Description
                            If IsDBNull(part("Name/Description")) OrElse CStr(part("Name/Description")).Length <= 0 Then
                                ErrorInCell(0, partIndex, "Name/Description", "Required field for an insert")
                            End If

                            'Category
                            If IsDBNull(part("Category")) OrElse CStr(part("Category")).Length <= 0 Then
                                ErrorInCell(0, partIndex, "Category", "Required field for an insert")
                            ElseIf DB.ImportValidation.CategoryExists(part("Category")) = False Then
                                ErrorInCell(0, partIndex, "Category", "'" & part("Category") & "' does not exist")
                            End If

                            If Not IsDBNull(part("Sell Price")) Then
                                If Not part("Sell Price").GetType() Is GetType(Decimal) Then
                                    ErrorInCell(0, partIndex, "Sell Price", "Required Decimal field for an insert - e.g 1.23")
                                End If
                            End If

                            'part code (S1)
                            If IsDBNull(part("Supplier Part Code")) OrElse CStr(part("Supplier Part Code")).Length <= 0 Then
                                ErrorInCell(0, partIndex, "Supplier Part Code (SPN)", "Required for an insert")
                            End If

                            'qty (S1)
                            If IsDBNull(part("Supplier Qty")) OrElse Not part("Supplier Qty").GetType() Is GetType(Double) Then
                                ErrorInCell(0, partIndex, "Supplier Qty", "Required Double field for an insert - e.g 1.23")
                            End If

                            'Price (S1)
                            If IsDBNull(part("Supplier Price")) OrElse Not part("Supplier Price").GetType() Is GetType(Decimal) Then
                                ErrorInCell(0, partIndex, "Supplier Price", "Reqired Decimal field for an insert - e.g £1.23")
                            End If
                        Else
                            updateCount += 1

                            Dim partID As Integer = partsFound

                            'Category
                            If Not IsDBNull(part("Category")) AndAlso CStr(part("Category")).Length > 0 Then
                                If DB.ImportValidation.CategoryExists(part("Category")) = False Then
                                    ErrorInCell(0, partIndex, "Category", "'" & part("Category") & "' does not exist")
                                End If
                            End If

                            If Not IsDBNull(part("Sell Price")) Then
                                If Not part("Sell Price").GetType() Is GetType(Decimal) Then
                                    ErrorInCell(0, partIndex, "Sell Price", "Required Decimal field for an update - e.g 1.23")
                                End If
                            End If

                            Dim suppliersFound As Array = DB.PartSupplier.Get_ByPartID(partID).Table.Select("SupplierID = " & SupplierID)

                            If suppliersFound.Length = 0 Then
                                'part code (S1)
                                If IsDBNull(part("Supplier Part Code")) OrElse CStr(part("Supplier Part Code")).Length <= 0 Then
                                    ErrorInCell(0, partIndex, "Supplier Part Code (SPN)", "Required field for an update when new part supplier")
                                End If

                                'qty (S1)
                                If IsDBNull(part("Supplier Qty")) OrElse Not part("Supplier Qty").GetType() Is GetType(Double) Then
                                    ErrorInCell(0, partIndex, "Supplier Qty", "Required Double field for an update when new part supplier - e.g 1.23")
                                End If

                                'Price (S1)
                                If IsDBNull(part("Supplier Price")) OrElse Not part("Supplier Price").GetType() Is GetType(Decimal) Then
                                    ErrorInCell(0, partIndex, "Supplier Price", "Reqired Decimal field for an update when new part supplier - e.g £1.23")
                                End If
                            Else
                                'qty (S1)
                                If Not IsDBNull(part("Supplier Qty")) Then
                                    If Not part("Supplier Qty").GetType() Is GetType(Double) Then
                                        ErrorInCell(0, partIndex, "Supplier Qty", "Required Double field for an update when updating part supplier - e.g 1.23")
                                    End If
                                End If

                                'Price (S1)
                                If Not IsDBNull(part("Supplier Price")) Then
                                    If Not part("Supplier Price").GetType() Is GetType(Decimal) Then
                                        ErrorInCell(0, partIndex, "Supplier Price", "Reqired Decimal field for an update when updating part supplier - e.g £1.23")
                                    End If
                                End If
                            End If
                        End If
                    End If

                    ImportForm.MoveProgressOn()
                Next

                Dim returnArr As New ArrayList
                returnArr.Add(insertCount)
                returnArr.Add(updateCount)
                Return returnArr
            Catch ex As Exception
                Errors.Add("Error occured while validating" & vbCrLf & ex.Message)

                Return Nothing
            End Try
        End Function

        Private Function ValidateSites(ByVal dvSites As DataView) As ArrayList
            Dim cnt As Integer = 0

            Try

                For siteIndex As Integer = 0 To dvSites.Count - 1
                    Dim site As DataRowView = dvSites(siteIndex)

                    'URPN
                    If IsDBNull(site("PolicyNumber")) OrElse CStr(site("PolicyNumber")).Length <= 0 Then
                        ErrorInCell(0, siteIndex, "URPN", "Required field")
                    Else

                        If Entity.Sys.Helper.MakeStringValid(site("Address1")).Trim.Length = 0 Then
                            ErrorInCell(0, siteIndex, "Address1", "Required field for an insert")
                        End If
                        'If Entity.Sys.Helper.MakeStringValid(site("Postcode")).Trim.Length = 0 Then
                        '    ErrorInCell(0, siteIndex, "Postcode", "Required field for an insert")
                        'End If

                    End If
                    cnt += 1
                    ImportForm.MoveProgressOn()
                Next

                Dim returnArr As New ArrayList
                returnArr.Add(cnt)
                Return returnArr
            Catch ex As Exception
                Errors.Add("Error occured while validating" & vbCrLf & ex.Message)

                Return Nothing
            End Try
        End Function

#End Region

    End Class

End Namespace