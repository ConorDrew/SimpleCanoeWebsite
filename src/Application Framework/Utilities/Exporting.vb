
Namespace Entity

    Namespace Sys

        Public Class Exporting

#Region "Properties"

            Private _Data As DataTable = Nothing
            Public Property Data() As DataTable
                Get
                    Return _Data
                End Get
                Set(ByVal Value As DataTable)
                    _Data = Value
                End Set
            End Property

            Private _excelApplication As Excel.Application = Nothing
            Private Property ExcelApplication() As Excel.Application
                Get
                    Return _excelApplication
                End Get
                Set(ByVal Value As Excel.Application)
                    _excelApplication = Value
                End Set
            End Property

            Private _excelWorkBook As Excel.Workbook = Nothing
            Private Property ExcelWorkBook() As Excel.Workbook
                Get
                    Return _excelWorkBook
                End Get
                Set(ByVal Value As Excel.Workbook)
                    _excelWorkBook = Value
                End Set
            End Property

            Private _excelWorkSheet As Excel.Worksheet = Nothing
            Private Property ExcelWorkSheet() As Excel.Worksheet
                Get
                    Return _excelWorkSheet
                End Get
                Set(ByVal Value As Excel.Worksheet)
                    _excelWorkSheet = Value
                End Set
            End Property

            Private _workSheetName As String = String.Empty
            Private Property WorkSheetName() As String
                Get
                    Return _workSheetName
                End Get
                Set(ByVal Value As String)
                    _workSheetName = Value
                End Set
            End Property

            Private _FilePathToBeUsed As String = String.Empty
            Private Property FilePathToBeUsed() As String
                Get
                    Return _FilePathToBeUsed
                End Get
                Set(ByVal Value As String)
                    _FilePathToBeUsed = Value
                End Set
            End Property

            Private _folderPath As String = String.Empty
            Private Property FolderPath() As String
                Get
                    Return _folderPath
                End Get
                Set(ByVal Value As String)
                    _folderPath = Value
                End Set
            End Property

            Private _DataSet As DataSet = Nothing
            Public Property DataSet() As DataSet
                Get
                    Return _DataSet
                End Get
                Set(ByVal Value As DataSet)
                    _DataSet = Value
                End Set
            End Property


#End Region

#Region "Functions"

            Public Sub New(ByVal datatableIn As DataTable, ByVal workSheetNameIn As String,
                           Optional ByVal folderPathIn As String = "",
                           Optional ByVal filenameIn As String = "",
                           Optional ByVal DataSetin As DataSet = Nothing)

                Data = datatableIn
                WorkSheetName = workSheetNameIn
                FolderPath = folderPathIn
                FilePathToBeUsed = filenameIn
                DataSet = DataSetin
                Export()

            End Sub

            Private Sub Export()
                Dim filePath As String = ""

                Try
                    If WorkSheetName = "3rd Visits" Then

                        filePath = FolderPath & "3rdVisits.xls"
                    ElseIf WorkSheetName = "Servicing Statistics Report" Then
                        filePath = FolderPath
                    Else
                        Dim folderToSaveTo As New FolderBrowserDialog
                        folderToSaveTo.ShowDialog()
                        If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                            ShowMessage("Operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        Else
                            Dim fileName As String = ""

                            If WorkSheetName = "Stock Take" Then
                                Dim title As String = ""

                                For Each row As DataRow In Data.Rows
                                    If title.Trim.Length = 0 Then
                                        title = Replace(row.Item("Location"), "*", "")
                                        ' title = row.Item("Location")
                                    Else
                                        If Not Replace(row.Item("Location"), "*", "") = title Then
                                            title = "Multiple_Locations"
                                            Exit For
                                        End If
                                    End If
                                Next

                                If title.Trim.Length = 0 Then
                                    title = "No_Locations"
                                End If

                                title = title.Replace("WAREHOUSE : ", "").Replace("VAN : ", "").Trim

                                fileName = title & "_" & Format(Now, "ddMMMyyyy")
                            Else
                                If Not FilePathToBeUsed = "" Then
                                    fileName = FilePathToBeUsed & Format(Now, "ddMMMyyyyHHmmss")
                                Else
                                    fileName = "Export" & Format(Now, "ddMMMyyyyHHmmss")
                                End If

                            End If

                            filePath = folderToSaveTo.SelectedPath & "\" & fileName & ".xls"
                        End If
                    End If

                    Cursor.Current = Cursors.WaitCursor

                    ExcelApplication = New Excel.Application

                    ExcelApplication.DisplayAlerts = False
                    ExcelWorkBook = ExcelApplication.Workbooks.Add
                    ExcelWorkSheet = DirectCast(ExcelApplication.Worksheets(1), Excel.Worksheet)

                    If WorkSheetName = "Servicing Statistics Report" Then
                        ServicingStatisticsReport(DataSet, filePath)
                    Else
                        DropToExcel()
                        SpecialCase()
                        ExcelWorkSheet.Name = WorkSheetName
                    End If
                    


                Catch ex As Exception
                    ShowMessage("Error Exporting : " & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    SaveAndDestroyExcel(filePath)
                    Cursor.Current = Cursors.Default
                End Try
            End Sub

            Private Sub DropToExcel()

                'System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-GB")
                Dim colCnt As Integer = Data.Columns.Count
                Dim rowCnt As Integer = Data.Rows.Count

                Dim a_dblNew(rowCnt + 1, colCnt) As Object
                For i As Integer = 0 To colCnt - 1
                    a_dblNew(0, i) = Data.Columns(i).ColumnName
                Next i

                For rn As Integer = 1 To rowCnt
                    For cn As Integer = 0 To colCnt - 1

                        Select Case Data.Columns(cn).DataType.Name
                            Case "String"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeStringValid(Data.Rows(rn - 1).Item(cn)).Trim
                            Case "Char"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeStringValid(Data.Rows(rn - 1).Item(cn)).Trim
                            Case "Integer"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeIntegerValid(Data.Rows(rn - 1).Item(cn))
                            Case "Int16"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeIntegerValid(Data.Rows(rn - 1).Item(cn))
                            Case "Int24"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeIntegerValid(Data.Rows(rn - 1).Item(cn))
                            Case "Int32"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeIntegerValid(Data.Rows(rn - 1).Item(cn))
                            Case "Int64"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeIntegerValid(Data.Rows(rn - 1).Item(cn))
                            Case "Double"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeDoubleValid(Data.Rows(rn - 1).Item(cn))
                            Case "Decimal"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeDoubleValid(Data.Rows(rn - 1).Item(cn))
                            Case "Float"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeDoubleValid(Data.Rows(rn - 1).Item(cn))
                            Case "DateTime"
                                If Entity.Sys.Helper.MakeDateTimeValid(Data.Rows(rn - 1).Item(cn)) = Nothing Then
                                    a_dblNew(rn, cn) = ""
                                Else
                                    a_dblNew(rn, cn) = CDate(Format(Entity.Sys.Helper.MakeDateTimeValid(Data.Rows(rn - 1).Item(cn)), "dd/MM/yyyy"))
                                End If
                            Case "Date"
                                If Entity.Sys.Helper.MakeDateTimeValid(Data.Rows(rn - 1).Item(cn)) = Nothing Then
                                    a_dblNew(rn, cn) = ""
                                Else
                                    'a_dblNew(rn, cn) = CDate(Data.Rows(rn - 1).Item(cn))
                                    a_dblNew(rn, cn) = CDate(Format(Entity.Sys.Helper.MakeDateTimeValid(Data.Rows(rn - 1).Item(cn)), "dd/MM/yyyy"))
                                End If
                            Case "Boolean"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeBooleanValid(Data.Rows(rn - 1).Item(cn))
                            Case "SByte"
                                a_dblNew(rn, cn) = Entity.Sys.Helper.MakeBooleanValid(Data.Rows(rn - 1).Item(cn))
                            Case "Byte[]"
                                a_dblNew(rn, cn) = Data.Rows(rn - 1).Item(cn).ToString
                            Case Else
                                a_dblNew(rn, cn) = Data.Rows(rn - 1).Item(cn)
                        End Select
                    Next cn
                Next rn

                Dim objVals As Object = CType(a_dblNew, Object)
                ExcelWorkSheet.Range(ExcelWorkSheet.Cells(1, 1), ExcelWorkSheet.Cells(rowCnt + 2, colCnt + 1)).Value = objVals

                For col As Integer = 0 To (Data.Columns.Count - 1)
                    With CType(ExcelWorkSheet.Cells(1, col + 1), Excel.Range)
                        .Font.Bold = True
                        .Font.ColorIndex = 2
                        .NumberFormat = "@"
                        .Interior.ColorIndex = 11
                        .EntireColumn.AutoFit()
                    End With
                Next

                For i As Integer = ExcelWorkBook.Worksheets.Count To 1 Step -1
                    If CType(ExcelWorkBook.Worksheets.Item(i), Excel.Worksheet).Name <> ExcelWorkSheet.Name Then
                        CType(ExcelWorkBook.Worksheets.Item(i), Excel.Worksheet).Delete()
                    End If
                Next
            End Sub

            Private Sub SaveAndDestroyExcel(ByVal filePath As String)
                Try

                    If filePath.Trim.Length > 0 And WorkSheetName <> "Servicing Statistics Report" Then
                        System.IO.File.Delete(filePath)
                        ExcelWorkBook.SaveAs(filePath, Local:=True)
                    End If

                    KillInstances()

                    If filePath.Trim.Length > 0 And (WorkSheetName <> "3rd Visits") Then
                        Entity.Sys.Helper.StartProcess(filePath)
                    End If

                Catch ex As Exception
                    ShowMessage("Error Exporting : " & vbCrLf & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub

            Private Sub KillInstances()
                On Error Resume Next

                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelWorkSheet)
                ExcelWorkSheet = Nothing
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelWorkBook)
                ExcelWorkBook = Nothing
                ExcelApplication.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApplication)
                ExcelApplication = Nothing
                GC.Collect()

                Dim mp As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName("EXCEL")
                Dim p As System.Diagnostics.Process
                For Each p In mp
                    If p.Responding Then
                        If p.MainWindowTitle = "" Then
                            p.Kill()
                        End If
                    Else
                        p.Kill()
                    End If
                Next p

                On Error GoTo -1
            End Sub

            Private Sub SpecialCase()

                If WorkSheetName.Contains("Timesheet") Then
                    Timesheets()
                End If

                If WorkSheetName.Contains("TS Summary") Then
                    Dim BadStyle As Excel.Style = ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFBad")
                    BadStyle.Font.Bold = True
                    BadStyle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightPink)
                    Dim WarnStyle As Excel.Style = ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFWarn")
                    WarnStyle.Font.Bold = True
                    WarnStyle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
                    Dim GoodStyle As Excel.Style = ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFGood")
                    GoodStyle.Font.Bold = True
                    GoodStyle.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen)

                    ExcelWorkSheet.Columns("B:B").ColumnWidth = 15
                    ExcelWorkSheet.Columns("C:C").ColumnWidth = 15
                    ExcelWorkSheet.Columns("D:D").ColumnWidth = 15
                    ExcelWorkSheet.Columns("E:E").ColumnWidth = 15
                    ExcelWorkSheet.Columns("F:F").ColumnWidth = 15
                    ExcelWorkSheet.Columns("G:G").ColumnWidth = 20

                    For i As Integer = 1 To Data.Rows.Count - 1

                        ExcelWorkSheet.Cells.Range("A" & i).BorderAround(, Excel.XlBorderWeight.xlHairline)
                        ExcelWorkSheet.Cells.Range("B" & i).BorderAround(, Excel.XlBorderWeight.xlHairline)
                        ExcelWorkSheet.Cells.Range("C" & i).BorderAround(, Excel.XlBorderWeight.xlHairline)
                        ExcelWorkSheet.Cells.Range("D" & i).BorderAround(, Excel.XlBorderWeight.xlHairline)
                        ExcelWorkSheet.Cells.Range("E" & i).BorderAround(, Excel.XlBorderWeight.xlHairline)
                        ExcelWorkSheet.Cells.Range("F" & i).BorderAround(, Excel.XlBorderWeight.xlHairline)
                        ExcelWorkSheet.Cells.Range("G" & i).BorderAround(, Excel.XlBorderWeight.xlHairline)

                        If i = 1 Then
                            ExcelWorkSheet.Cells.Range("A1:G1").BorderAround(, Excel.XlBorderWeight.xlMedium)
                        Else
                            If Not ExcelWorkSheet.Cells.Range("A" & i).Value = Nothing Then
                                If ExcelWorkSheet.Cells.Range("B" & i).Value >= 120 Then
                                    ExcelWorkSheet.Cells.Range("B" & i).Style = "CFBad"
                                End If
                                ExcelWorkSheet.Cells.Range("B" & i).Value = formatTime(ExcelWorkSheet.Cells.Range("B" & i).Value)

                            End If
                            If Not ExcelWorkSheet.Cells.Range("A" & i).Value = Nothing Then
                                If ExcelWorkSheet.Cells.Range("C" & i).Value <= 300 Then
                                    ExcelWorkSheet.Cells.Range("C" & i).Style = "CFBad"
                                End If
                                ExcelWorkSheet.Cells.Range("C" & i).Value = formatTime(ExcelWorkSheet.Cells.Range("C" & i).Value)

                            End If
                            If Not ExcelWorkSheet.Cells.Range("A" & i).Value = Nothing Then
                                If ExcelWorkSheet.Cells.Range("D" & i).Value = 0 Then
                                    ExcelWorkSheet.Cells.Range("D" & i).Style = "CFBad"
                                End If
                                ExcelWorkSheet.Cells.Range("D" & i).Value = formatTime(ExcelWorkSheet.Cells.Range("D" & i).Value)

                            End If
                            If Not ExcelWorkSheet.Cells.Range("A" & i).Value = Nothing Then
                                If ExcelWorkSheet.Cells.Range("E" & i).Value >= 60 Then
                                    ExcelWorkSheet.Cells.Range("E" & i).Style = "CFBad"
                                End If
                                ExcelWorkSheet.Cells.Range("E" & i).Value = formatTime(ExcelWorkSheet.Cells.Range("E" & i).Value)

                            End If
                            If Not ExcelWorkSheet.Cells.Range("A" & i).Value = Nothing Then
                                If ExcelWorkSheet.Cells.Range("F" & i).Value >= 20 Then
                                    ExcelWorkSheet.Cells.Range("F" & i).Style = "CFBad"
                                End If
                                ExcelWorkSheet.Cells.Range("F" & i).Value = formatTime(ExcelWorkSheet.Cells.Range("F" & i).Value)

                            End If
                            If Not ExcelWorkSheet.Cells.Range("A" & i).Value = Nothing Then
                                If ExcelWorkSheet.Cells.Range("G" & i).Value > 0 Then
                                    ExcelWorkSheet.Cells.Range("G" & i).Style = "CFWarn"
                                End If
                                ExcelWorkSheet.Cells.Range("G" & i).Value = formatTime(ExcelWorkSheet.Cells.Range("G" & i).Value)

                            End If
                        End If

                        ExcelWorkSheet.Cells.Range("B" & i).HorizontalAlignment = Excel.Constants.xlCenter
                        ExcelWorkSheet.Cells.Range("C" & i).HorizontalAlignment = Excel.Constants.xlCenter
                        ExcelWorkSheet.Cells.Range("D" & i).HorizontalAlignment = Excel.Constants.xlCenter
                        ExcelWorkSheet.Cells.Range("E" & i).HorizontalAlignment = Excel.Constants.xlCenter
                        ExcelWorkSheet.Cells.Range("F" & i).HorizontalAlignment = Excel.Constants.xlCenter
                        ExcelWorkSheet.Cells.Range("G" & i).HorizontalAlignment = Excel.Constants.xlCenter
                    Next
                    ExcelWorkSheet.Cells.Range("A2:G" & Data.Rows.Count - 1).BorderAround(, Excel.XlBorderWeight.xlMedium)
                    ExcelWorkSheet.Cells.Range("A1:A" & Data.Rows.Count - 1).BorderAround(, Excel.XlBorderWeight.xlMedium)
                    ExcelWorkSheet.Cells.Range("A" & Data.Rows.Count - 1 & ":G" & Data.Rows.Count - 1).BorderAround(, Excel.XlBorderWeight.xlMedium)
                End If

                Select Case WorkSheetName
                    Case "Visit List"
                        For i As Integer = 1 To Data.Rows.Count + 1

                            ExcelWorkSheet.Cells.Range("J" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("J" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("J" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("K" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("K" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("K" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("L" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("L" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("L" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("M" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("M" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("M" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("O" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("O" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("O" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("P" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("P" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("P" & i).NumberFormat = "£#,##0.00"

                        Next



                    Case "Job List"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("L" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("L" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("L" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("M" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("M" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("M" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("N" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("N" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("N" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("O" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("O" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("O" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("P" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("P" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("P" & i).NumberFormat = "£#,##0.00"
                        Next
                    Case "Quote List"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("F" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("F" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("F" & i).NumberFormat = "£#,##0.00"
                        Next
                    Case "Contracts List"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("G" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("G" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("G" & i).NumberFormat = "£#,##0.00"
                        Next
                    Case "Invoice List"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("H" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("H" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("H" & i).NumberFormat = "£#,##0.00"
                        Next
                    Case "Invoiced List"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("H" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("H" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("H" & i).NumberFormat = "£#,##0.00"
                            ExcelWorkSheet.Cells.Range("M" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("M" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("M" & i).NumberFormat = "dd/MM/yyyy"
                        Next
                    Case "Stock Value Report"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("E" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("E" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("E" & i).NumberFormat = "£#,##0.00"

                            ExcelWorkSheet.Cells.Range("F" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("F" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("F" & i).NumberFormat = "£#,##0.00"
                        Next
                    Case "Stock Category Value Report"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("C" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("C" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("C" & i).NumberFormat = "£#,##0.00"

                            ExcelWorkSheet.Cells.Range("D" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("D" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("D" & i).NumberFormat = "£#,##0.00"
                        Next
                    Case "Stock Used Report"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("A" & i).NumberFormat = "#,##0.00"

                            ExcelWorkSheet.Cells.Range("F" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("F" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("F" & i).NumberFormat = "£#,##0.00"

                            ExcelWorkSheet.Cells.Range("G" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("G" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("G" & i).NumberFormat = "#,##0"

                            ExcelWorkSheet.Cells.Range("H" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("H" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("H" & i).NumberFormat = "#,##0"

                            ExcelWorkSheet.Cells.Range("I" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("I" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("I" & i).NumberFormat = "#,##0"
                        Next
                    Case "Stock Quantities"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("D" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("D" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("D" & i).NumberFormat = "#,##0.00"

                            ExcelWorkSheet.Cells.Range("E" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("E" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("E" & i).NumberFormat = "#,##0.00"

                            ExcelWorkSheet.Cells.Range("F" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("F" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("F" & i).NumberFormat = "#,##0.00"
                        Next
                    Case "Stock Take"
                        For i As Integer = 1 To Data.Rows.Count + 1
                            ExcelWorkSheet.Cells.Range("J" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("J" & i).FormulaR1C1 & " "
                            ExcelWorkSheet.Cells.Range("J" & i).NumberFormat = "#,##0"
                        Next

                End Select
            End Sub

            Private Sub Timesheets()
                ExcelWorkSheet.Columns("B:B").wrapText = True
                ExcelWorkSheet.Columns("C:C").wrapText = True

                ExcelWorkSheet.Columns("A:A").ColumnWidth = 27.71
                ExcelWorkSheet.Columns("B:B").ColumnWidth = 37.29
                ExcelWorkSheet.Columns("C:C").ColumnWidth = 31.43
                ExcelWorkSheet.Columns("D:D").ColumnWidth = 42.86

                Dim dtEngineers As DataTable = DB.Engineer.Engineer_GetAll.Table
                Dim days As String = "Monday Tuesday Wednesday Thursday Friday Saturday Sunday"
                ExcelWorkSheet.PageSetup.LeftHeader = WorkSheetName
                ExcelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                ExcelWorkSheet.PageSetup.FitToPagesWide = 1
                ExcelWorkSheet.PageSetup.FitToPagesTall = 25
                ExcelWorkSheet.PageSetup.Zoom = False

                Dim summaryStart As String = ""
                Dim dayStart As String = ""
                Dim BorderLetter As String = "H"

                Dim dt As DataTable = DB.Picklists.GetAll(Enums.PickListTypes.TimeSheetTypes).Table
                'HOW FAR DOES THE TABLE STRETCH
                Dim theCell As String = ExcelWorkSheet.Cells.Range("A" & 1).FormulaR1C1
                Dim a As Integer = 65
                Dim b As Integer = 65
                Dim colcnt As Integer = 0
                While theCell <> ""
                    If a > 90 Then
                        colcnt += 1
                        theCell = ExcelWorkSheet.Cells.Range(Chr(65) & Chr(b) & 1).FormulaR1C1
                        ' If Chr(a) > "I" Then
                        ExcelWorkSheet.Cells.Range(Chr(65) & Chr(b) & 1).FormulaR1C1 = ""
                        'End If
                        b += 1
                    Else
                        colcnt += 1
                        theCell = ExcelWorkSheet.Cells.Range(Chr(a) & 1).FormulaR1C1
                        ' If Chr(a) > "I" Then
                        ExcelWorkSheet.Cells.Range(Chr(a) & 1).FormulaR1C1 = ""
                        'End If
                    End If

                    a += 1
                End While

                ''--top line
                If colcnt > 26 Then
                    With ExcelWorkSheet.Cells.Range("A" & 1 & ":" & Chr(65) & Chr(b - 1) & 1)
                        .Interior.ColorIndex = Excel.XlColorIndex.xlColorIndexNone
                        .Font.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With
                Else
                    With ExcelWorkSheet.Cells.Range("A" & 1 & ":" & Chr(colcnt + 64) & 1)
                        .Interior.ColorIndex = Excel.XlColorIndex.xlColorIndexNone
                        .Font.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    End With
                End If

                

                Dim found As Boolean = False
                Dim merged As Boolean = False
                Dim NameOrDay As Boolean = False

                For i As Integer = 2 To Data.Rows.Count + 1
                    If ExcelWorkSheet.Cells.Range("B" & i).FormulaR1C1.ToString.Length > 0 Then
                        ExcelWorkSheet.Cells.Range("A" & i & ":h" & i).RowHeight = 25.5
                        BorderLetter = "H"
                    Else
                        For c As Integer = 72 To 82
                            If ExcelWorkSheet.Cells.Range(Chr(c) & i).FormulaR1C1.ToString.Length = 0 Then
                                BorderLetter = Chr(c - 1)
                                Exit For
                            End If

                        Next

                    End If
                    NameOrDay = False
                    '--------------SUMMARY BORDERS

                    If ExcelWorkSheet.Cells.Range("B" & i).FormulaR1C1 = "" And found = True Then
                        found = False
                        

                        Dim j As Integer = i
                        For Each tst As DataRow In dt.Rows
                            If colcnt > 26 Then
                                ExcelWorkSheet.Cells.Range("C" & j).Formula = "=SUM(D" & j & ":" & Chr(65) & Chr(b - 1) & j & ")"
                                ExcelWorkSheet.Cells.Range("C" & j).NumberFormat = "[h]:mm" '"dd:hh:mm" '"[$-F400]h:mm:ss AM/PM"
                            Else
                                ExcelWorkSheet.Cells.Range("C" & j).Formula = "=SUM(D" & j & ":" & Chr(colcnt + 64) & j & ")"
                                ExcelWorkSheet.Cells.Range("C" & j).NumberFormat = "[h]:mm" '"dd:hh:mm" '"[$-F400]h:mm:ss AM/PM"
                            End If
                            j += 1
                        Next tst

                        With ExcelWorkSheet.Cells.Range(summarystart & ":" & BorderLetter & j - 1).Select
                            ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                            ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                            With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlMedium
                            End With
                            With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlMedium
                            End With
                            With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlMedium
                            End With
                            With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlMedium
                            End With
                            ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                            ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlLineStyleNone



                        End With
                    End If

                    If ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 = "SUMMARY" Or ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 = "MASTER SUMMARY" Then
                        merged = False
                        found = True
                        summarystart = ("A" & i + 1)

                        If colcnt > 26 Then
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(65) & Chr(b - 1) & i).Font.Bold = True
                        Else
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).Font.Bold = True
                        End If

                        'ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).Font.Bold = True
                        ExcelWorkSheet.Cells.Range("A" & i & ":A" & i).Font.Size = 14
                        ExcelWorkSheet.Cells.Range("A" & i & ":A" & i).HorizontalAlignment = Excel.Constants.xlLeft
                        ExcelWorkSheet.Cells.Range("C" & i).Formula = "Total"
                    End If

                    'ENGINEER FONT 
                    If dtEngineers.Select("Name='" & ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 & "'").Length > 0 Then
                        NameOrDay = True
                        If colcnt > 26 Then
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(65) & Chr(b - 1) & i).Font.Bold = True
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(65) & Chr(b - 1) & i).Font.Size = 18
                        Else
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).Font.Bold = True
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).Font.Size = 18
                        End If
                        
                    End If

                    'DAY FONT
                    If days.Contains(ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1) And ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 <> "" Then
                        NameOrDay = True

                        If colcnt > 26 Then
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(65) & Chr(b - 1) & i).Font.Bold = True
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(65) & Chr(b - 1) & i).Font.Bold = True
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(65) & Chr(b - 1) & i).Font.Size = 14
                            ExcelWorkSheet.Cells.Range("B" & i & ":" & Chr(65) & Chr(b - 1) & i).Font.Bold = True
                            ExcelWorkSheet.Cells.Range("B" & i & ":" & Chr(65) & Chr(b - 1) & i).Font.Size = 10
                            ExcelWorkSheet.Cells.Range("B" & i & ":" & Chr(65) & Chr(b - 1) & i).HorizontalAlignment = Excel.Constants.xlCenter
                            ExcelWorkSheet.Cells.Range("B" & i & ":" & Chr(65) & Chr(b - 1) & i).VerticalAlignment = Excel.Constants.xlCenter
                        Else
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).Font.Bold = True
                            ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).Font.Size = 14
                            ExcelWorkSheet.Cells.Range("B" & i & ":" & Chr(colcnt + 64) & i).Font.Bold = True
                            ExcelWorkSheet.Cells.Range("B" & i & ":" & Chr(colcnt + 64) & i).Font.Size = 10
                            ExcelWorkSheet.Cells.Range("B" & i & ":" & Chr(colcnt + 64) & i).HorizontalAlignment = Excel.Constants.xlCenter
                            ExcelWorkSheet.Cells.Range("B" & i & ":" & Chr(colcnt + 64) & i).VerticalAlignment = Excel.Constants.xlCenter
                        End If

                        dayStart = "A" & i + 1
                    End If


                    If i > 1 Then
                        If ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 = "" Then
                            If dayStart.Length > 0 Then
                                ExcelWorkSheet.Cells.Range(dayStart & ":H" & i - 1).Select()
                                ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                                ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                                With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Weight = Excel.XlBorderWeight.xlMedium
                                End With
                                With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Weight = Excel.XlBorderWeight.xlMedium
                                End With
                                With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Weight = Excel.XlBorderWeight.xlMedium
                                End With
                                With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Weight = Excel.XlBorderWeight.xlMedium
                                End With
                                With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                                    .LineStyle = Excel.XlLineStyle.xlContinuous
                                    .Weight = Excel.XlBorderWeight.xlThin
                                End With
                                If ExcelWorkSheet.Cells.Range(dayStart & ":" & BorderLetter & i - 1).Rows.Count > 1 Then
                                    With ExcelApplication.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                                        .LineStyle = Excel.XlLineStyle.xlContinuous
                                        .Weight = Excel.XlBorderWeight.xlThin
                                    End With
                                End If
                               
                            End If
                            dayStart = ""
                        Else
                            If NameOrDay = False Then

                                If colcnt > 26 Then
                                    ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(65) & Chr(b - 1) & i).HorizontalAlignment = Excel.Constants.xlCenter
                                    ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(65) & Chr(b - 1) & i).VerticalAlignment = Excel.Constants.xlCenter
                                Else
                                    ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).HorizontalAlignment = Excel.Constants.xlCenter
                                    ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).VerticalAlignment = Excel.Constants.xlCenter
                                End If
                                'ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).HorizontalAlignment = Excel.Constants.xlCenter
                                'ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).VerticalAlignment = Excel.Constants.xlCenter

                                'COLOUR
                                If dt.Select("Name='" & ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1.ToString.ToUpper & "'").Length > 0 Then
                                    If ExcelWorkSheet.Cells.Range("B" & i).FormulaR1C1.ToString.Length > 0 Then
                                        ExcelWorkSheet.Cells.Range("A" & i & ":h" & i).Interior.ColorIndex = 44
                                    Else
                                        ExcelWorkSheet.Cells.Range("A" & i).HorizontalAlignment = Excel.Constants.xlLeft
                                        ExcelWorkSheet.Cells.Range("A" & i).Font.Bold = True
                                    End If
                                End If
                                If ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1.ToString.ToUpper = "NON-CHARGEABLE" Or _
                                    ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1.ToString.ToUpper = "UNACCOUNTED" Or _
                                    ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1.ToString.ToUpper = "TOTAL HOURS > 17:00" Then

                                    ExcelWorkSheet.Cells.Range("A" & i).HorizontalAlignment = Excel.Constants.xlLeft
                                    ExcelWorkSheet.Cells.Range("A" & i).Font.Bold = True
                                End If

                                '----------------CELL MERGING 
                                If ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("A" & i - 1).FormulaR1C1 And _
                                ExcelWorkSheet.Cells.Range("B" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("B" & i - 1).FormulaR1C1 And _
                                ExcelWorkSheet.Cells.Range("C" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("C" & i - 1).FormulaR1C1 And _
                                ExcelWorkSheet.Cells.Range("D" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("D" & i - 1).FormulaR1C1 Then
                                    merged = True

                                    With ExcelWorkSheet.Cells.Range("A" & i - 1 & ":A" & i)
                                        .WrapText = True
                                        .MergeCells = True
                                    End With
                                    With ExcelWorkSheet.Cells.Range("B" & i - 1 & ":B" & i)
                                        .WrapText = True
                                        .MergeCells = True
                                    End With
                                    With ExcelWorkSheet.Cells.Range("C" & i - 1 & ":C" & i)
                                        .WrapText = True
                                        .MergeCells = True
                                    End With
                                    With ExcelWorkSheet.Cells.Range("D" & i - 1 & ":D" & i)
                                        .WrapText = True
                                        .MergeCells = True
                                    End With



                                ElseIf merged Then
                                    'CHECK FURTHER BACK
                                    For j As Integer = i - 2 To 2 Step -1
                                        If ExcelWorkSheet.Cells.Range("A" & j).FormulaR1C1 <> "" Then
                                            If ExcelWorkSheet.Cells.Range("A" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("A" & j).FormulaR1C1 And _
                                                                              ExcelWorkSheet.Cells.Range("B" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("B" & j).FormulaR1C1 And _
                                                                              ExcelWorkSheet.Cells.Range("C" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("C" & j).FormulaR1C1 And _
                                                                              ExcelWorkSheet.Cells.Range("D" & i).FormulaR1C1 = ExcelWorkSheet.Cells.Range("D" & j).FormulaR1C1 Then
                                                'MERGE WITH HIGHER UP
                                                With ExcelWorkSheet.Cells.Range("A" & j & ":A" & i)
                                                    .WrapText = True
                                                    .MergeCells = True
                                                End With
                                                With ExcelWorkSheet.Cells.Range("B" & j & ":B" & i)
                                                    .WrapText = True
                                                    .MergeCells = True
                                                End With
                                                With ExcelWorkSheet.Cells.Range("C" & j & ":C" & i)
                                                    .WrapText = True
                                                    .MergeCells = True
                                                End With
                                                With ExcelWorkSheet.Cells.Range("D" & j & ":D" & i)
                                                    .WrapText = True
                                                    .MergeCells = True
                                                End With
                                            Else
                                                merged = False
                                                Exit For
                                            End If
                                        Else
                                            merged = False
                                            Exit For
                                        End If


                                    Next j
                                End If
                            End If
                            End If
                    End If

                Next
                ExcelWorkSheet.Cells.Range("A1").Select()
            End Sub

            Private Function formatTime(ByVal Minutes As Integer) As String
                If Minutes < 0 Then
                    Return "00:00"
                End If

                If Minutes Mod 60 < 10 Then
                    Return Math.Floor(Minutes / 60) & ":0" & Minutes Mod 60

                Else
                    Return Math.Floor(Minutes / 60) & ":" & Minutes Mod 60
                End If



            End Function

            Sub ServicingStatisticsReport(ByVal Data As DataSet, ByVal filePath As String)
                Dim excelApplication As Excel.Application
                Dim newWorkbook As Excel.Workbook
                Dim targetSheet As Excel.Worksheet
                Dim dataRange As Excel.Range
                Dim Categorylabelsrange As Excel.Range
                Dim Serieslabelsrange As Excel.Range
                Dim chartObjects As Excel.ChartObjects
                Dim newChartObject As Excel.ChartObject
                Dim paramWorkbookPath As String = filePath
                Dim paramChartFormat As Object = 1
                Dim paramCategoryLabels As Object = 0
                Dim paramSeriesLabels As Object = 0
                Dim paramHasLegend As Boolean = True
                Dim paramTitle As String = "Servicing per week"
                Dim paramCategoryTitle As String = ""
                Dim paramValueTitle As String = ""
                Dim dt As DataTable

                excelApplication = New Excel.Application
                excelApplication.DisplayAlerts = False
                newWorkbook = excelApplication.Workbooks.Add()
                For i As Integer = 0 To DataSet.Tables.Count - 1

                    dt = DataSet.Tables(i)
                    If dt.Rows.Count > 0 Then
                        targetSheet = newWorkbook.Worksheets(i + 1)
                        targetSheet.Name = dt.TableName
                        Dim Weekdate As DateTime = Nothing
                        Dim Comparedate As DateTime = Nothing
                        Dim rowcount As Integer = 1
                        Dim columncount As Integer = 1
                        Dim totalrows As Integer = dt.Rows.Count
                        Dim HeaderAdded As Boolean = False
                        If dt.TableName = "Visits Eng Breakdown (Actual)" Then
                            Dim dview As DataView = dt.DefaultView
                            dview.Sort = "Weekdate ASC, EngineerName ASC"
                            dt = dview.ToTable
                            '                        dt.DefaultView.Sort = "Weekdate ASC, EngineerName ASC"
                        End If
                        For Each row As DataRow In dt.Rows
                            Select Case dt.TableName
                                Case "Overall Servicing"
                                    SetCellValue(targetSheet, "A" & rowcount.ToString, row.Item(0).ToString)
                                    SetCellValue(targetSheet, "B" & rowcount.ToString, row.Item(1).ToString)
                                    rowcount += 1
                                Case "Weekly Stats (FC)"
                                    If rowcount = 1 And HeaderAdded = False Then
                                        SetCellValue(targetSheet, "A" & rowcount.ToString, "")
                                        SetCellValue(targetSheet, "B" & rowcount.ToString, "No of Services")
                                        SetCellValue(targetSheet, "C" & rowcount.ToString, "1st Letter Stage")
                                        SetCellValue(targetSheet, "D" & rowcount.ToString, "2nd Letter Stage")
                                        SetCellValue(targetSheet, "E" & rowcount.ToString, "3rd Letter Stage")
                                        SetCellValue(targetSheet, "F" & rowcount.ToString, "No of Safety Inspections")
                                        'SetCellValue(targetSheet, "F" & rowcount.ToString, "Predicted 1st Visit Access Level")
                                        'SetCellValue(targetSheet, "G" & rowcount.ToString, "Predicted 2nd Visit Access Level")
                                        'SetCellValue(targetSheet, "H" & rowcount.ToString, "Predicted 3rd Visit Access Level")
                                        SetCellValue(targetSheet, "G" & rowcount.ToString, "Predicted 1st Visit Access Level")
                                        SetCellValue(targetSheet, "H" & rowcount.ToString, "Predicted 2nd Visit Access Level")
                                        SetCellValue(targetSheet, "I" & rowcount.ToString, "Predicted 3rd Visit Access Level")

                                        HeaderAdded = True
                                        SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                        SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                        SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                        SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                        SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(4).ToString)
                                        SetCellValue(targetSheet, "F" & rowcount + 1.ToString, row.Item(5).ToString)
                                        'SetCellValue(targetSheet, "F" & rowcount + 1.ToString, row.Item(6).ToString)
                                        'SetCellValue(targetSheet, "G" & rowcount + 1.ToString, row.Item(7).ToString)
                                        'SetCellValue(targetSheet, "H" & rowcount + 1.ToString, row.Item(8).ToString)
                                        SetCellValue(targetSheet, "G" & rowcount + 1.ToString, row.Item(6).ToString)
                                        SetCellValue(targetSheet, "H" & rowcount + 1.ToString, row.Item(7).ToString)
                                        SetCellValue(targetSheet, "I" & rowcount + 1.ToString, row.Item(8).ToString)
                                        rowcount += 1
                                    Else
                                        SetCellValue(targetSheet, "A" & rowcount + 1.ToString, CDate(row.Item(0).ToString))
                                        SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                        SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                        SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                        SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(4).ToString)
                                        SetCellValue(targetSheet, "F" & rowcount + 1.ToString, row.Item(5).ToString)
                                        rowcount += 1
                                    End If
                                Case "Weekly Stats Engineers (FC)"
                                    If rowcount = 1 And HeaderAdded = False Then
                                        SetCellValue(targetSheet, "A" & rowcount.ToString, "")
                                        SetCellValue(targetSheet, "B" & rowcount.ToString, "No of Engineers (Servicing)")
                                        SetCellValue(targetSheet, "C" & rowcount.ToString, "No of Engineers (Safety Inspections)")
                                        SetCellValue(targetSheet, "D" & rowcount.ToString, "Total No of Engineers")
                                        HeaderAdded = True
                                        SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                        SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                        SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                        SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                        rowcount += 1
                                    Else
                                        SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                        SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                        SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                        SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                        rowcount += 1
                                    End If
                                Case "Visits Booked (Actual)"
                                    If rowcount = 1 And HeaderAdded = False Then
                                        SetCellValue(targetSheet, "A" & rowcount.ToString, "Visit Start Date")
                                        SetCellValue(targetSheet, "B" & rowcount.ToString, "Visit End Date")
                                        SetCellValue(targetSheet, "C" & rowcount.ToString, "Site")
                                        SetCellValue(targetSheet, "D" & rowcount.ToString, "Engineer")
                                        SetCellValue(targetSheet, "E" & rowcount.ToString, "Letter Type")
                                        SetCellValue(targetSheet, "E" & rowcount.ToString, "Job Number")
                                        HeaderAdded = True
                                        SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                        SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                        SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                        SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                        SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(4).ToString)
                                        SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(5).ToString)
                                        rowcount += 1
                                    Else
                                        SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                        SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                        SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                        SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                        SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(4).ToString)
                                        SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(5).ToString)
                                        rowcount += 1
                                    End If
                                Case "Visits Eng Breakdown (Actual)"
                                    'If rowcount = 1 And HeaderAdded = False Then
                                    '    SetCellValue(targetSheet, "A" & rowcount.ToString, "Weekdate")
                                    '    SetCellValue(targetSheet, "B" & rowcount.ToString, "Engineer")
                                    '    SetCellValue(targetSheet, "C" & rowcount.ToString, "Count")
                                    '    HeaderAdded = True
                                    '    SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                    '    SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                    '    SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                    '    rowcount += 1
                                    'Else
                                    '    SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                    '    SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                    '    SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                    '    rowcount += 1
                                    'End If
                                    '                            Case "Visits Eng Breakdown (Actual)"
                                    If row.Item(0).ToString = "" Then
                                        GoTo nextrow
                                    End If
                                    If Weekdate = Nothing Then 'create a new line
                                        Weekdate = row.Item(0).ToString
                                        SetCellValue(targetSheet, GetCellRef("1", 1), "") 'blank top left
                                        SetCellValue(targetSheet, GetCellRef("2", 1), row.Item(1).ToString) 'Engineer
                                        SetCellValue(targetSheet, GetCellRef("1", 2), row.Item(0).ToString) 'Date
                                        SetCellValue(targetSheet, GetCellRef("2", 2), row.Item(2).ToString) 'No of Visits
                                        columncount = 3
                                        rowcount = 2
                                    Else 'check against the rows date to see if changed
                                        Comparedate = row.Item(0).ToString
                                        If Comparedate = Weekdate Then ' it matches stay on this line
                                            If rowcount = 2 Then
                                                SetCellValue(targetSheet, GetCellRef(CStr(columncount), rowcount - 1), row.Item(1).ToString) 'Engineer
                                            End If
                                            SetCellValue(targetSheet, GetCellRef(CStr(columncount), rowcount), row.Item(2).ToString) 'No of Visits
                                            columncount += 1
                                        Else 'create a new line
                                            rowcount += 1
                                            columncount = 2
                                            SetCellValue(targetSheet, GetCellRef("1", rowcount), row.Item(0).ToString) 'Date
                                            'SetCellValue(targetSheet, GetCellRef(CStr(columncount), rowcount), row.Item(1).ToString) 'Engineer
                                            SetCellValue(targetSheet, GetCellRef(CStr(columncount), rowcount), row.Item(2).ToString) 'No of Visits
                                            Weekdate = Comparedate
                                            columncount += 1
                                        End If
                                    End If
                                    'If rowcount = 3 Then
                                    '    GoTo skipchart
                                    'End If

                                    'If rowcount = 1 And HeaderAdded = False Then
                                    '    SetCellValue(targetSheet, "A" & rowcount.ToString, "VisitDate")
                                    '    SetCellValue(targetSheet, "B" & rowcount.ToString, "Engineer")
                                    '    SetCellValue(targetSheet, "C" & rowcount.ToString, "EngineerTotal")
                                    '    'SetCellValue(targetSheet, "D" & rowcount.ToString, "Engineer")
                                    '    'SetCellValue(targetSheet, "E" & rowcount.ToString, "Letter Type")
                                    '    HeaderAdded = True
                                    '    SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                    '    SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                    '    SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                    '    'SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                    '    'SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(4).ToString)
                                    '    rowcount += 1
                                    'Else
                                    '    SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                    '    SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                    '    SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                    '    'SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                    '    'SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(4).ToString)
                                    '    rowcount += 1
                                    'End If
nextrow:
                                Case "First Letter Stage Sites", "Second Letter Stage Sites", "Third Letter Stage Sites"
                                    'For j As Integer = 0 To row.Table.Columns.Count - 1
                                    '    SetCellValueNoRange(targetSheet, j + 1.ToString & "," & rowcount.ToString, row.Item(j).ToString)
                                    'Next
                                    If rowcount = 1 And HeaderAdded = False Then
                                        SetCellValue(targetSheet, "A" & rowcount.ToString, "UPRN")
                                        SetCellValue(targetSheet, "B" & rowcount.ToString, "Address1")
                                        SetCellValue(targetSheet, "C" & rowcount.ToString, "Postcode")
                                        SetCellValue(targetSheet, "D" & rowcount.ToString, "Site Fuel")
                                        SetCellValue(targetSheet, "E" & rowcount.ToString, "Last Service Date")
                                        HeaderAdded = True
                                        SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(2).ToString)
                                        SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(5).ToString)
                                        SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(6).ToString)
                                        SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(7).ToString)
                                        SetCellValue(targetSheet, "E" & rowcount + 1.ToString, FormatDateTime(row.Item(8).ToString, DateFormat.ShortDate))
                                        rowcount += 1
                                    Else
                                        SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(2).ToString)
                                        SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(5).ToString)
                                        SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(6).ToString)
                                        SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(7).ToString)
                                        SetCellValue(targetSheet, "E" & rowcount + 1.ToString, FormatDateTime(row.Item(8).ToString, DateFormat.ShortDate))
                                        rowcount += 1
                                    End If
                                    'SetCellValue(targetSheet, "D" & rowcount.ToString, row.Item(3).ToString)
                                    'SetCellValue(targetSheet, "E" & rowcount.ToString, row.Item(4).ToString)
                                    'SetCellValue(targetSheet, "F" & rowcount.ToString, row.Item(5).ToString)
                                    'SetCellValue(targetSheet, "G" & rowcount.ToString, row.Item(6).ToString)
                                    'SetCellValue(targetSheet, "H" & rowcount.ToString, row.Item(7).ToString)
                                    'SetCellValue(targetSheet, "I" & rowcount.ToString, row.Item(8).ToString)
                                    'SetCellValue(targetSheet, "J" & rowcount.ToString, row.Item(9).ToString)
                                    ' rowcount += 1
                            End Select


                        Next
                        HeaderAdded = False
                        Select Case dt.TableName
                            Case "Overall Servicing"
                                dataRange = targetSheet.Range("A1", "B" & rowcount - 1.ToString)
                                Categorylabelsrange = targetSheet.Range("A1", "A" & rowcount - 1.ToString)
                            Case "Weekly Stats (FC)"
                                'dataRange = targetSheet.Range("A1", "E" & rowcount.ToString)
                                'Categorylabelsrange = targetSheet.Range("A1", "A" & rowcount.ToString)
                                dataRange = targetSheet.Range("A1", "F" & rowcount.ToString)
                                Categorylabelsrange = targetSheet.Range("A1", "A" & rowcount.ToString)
                                'Serieslabelsrange = targetSheet.Range("A1", "E1")
                            Case "Weekly Stats Engineers (FC)"
                                dataRange = targetSheet.Range("A1", "D" & rowcount.ToString)
                                Categorylabelsrange = targetSheet.Range("A1", "A" & rowcount.ToString)
                            Case "Visits Eng Breakdown (Actual)"
                                dataRange = targetSheet.Range("A1", GetCellRef((columncount - 1).ToString, rowcount))
                                Categorylabelsrange = targetSheet.Range("A1", "A" & rowcount.ToString)
                            Case "First Letter Stage Sites", "Second Letter Stage Sites", "Third Letter Stage Sites", "Visits Booked (Actual)"
                                GoTo skipchart
                        End Select

                        chartObjects = targetSheet.ChartObjects()

                        Select Case dt.TableName
                            Case "Overall Servicing"
                                newChartObject = chartObjects.Add(450, 30, 300, 300)
                                paramTitle = "Overall Servicing"
                                newChartObject.Chart.ChartWizard(dataRange, Excel.XlChartType.xl3DColumn,
                                paramChartFormat, Excel.XlRowCol.xlRows, Categorylabelsrange,
                                paramSeriesLabels, paramHasLegend, paramTitle,
                                paramCategoryTitle, paramValueTitle)
                            Case "Weekly Stats (FC)"
                                newChartObject = chartObjects.Add(450, 30, 1000, 600)
                                paramTitle = "Servicing per Week Forecast"
                                newChartObject.Chart.ChartWizard(dataRange, Excel.XlChartType.xlLineMarkers,
                                paramChartFormat, Excel.XlRowCol.xlRows, paramSeriesLabels,
                                Categorylabelsrange, paramHasLegend, paramTitle,
                                paramCategoryTitle, paramValueTitle)
                                dataRange.EntireColumn.AutoFit()
                                'Chart1.Series(0).Color = Color.Red
                                'newChartObject.Plot.SeriesCollection(5).DataPoints(1).Brush.FillColor.Set(234, 30, 224)

                                'newChartObject.Chart.Plot.SeriesCollection(5).DataPoints(1).Brush.FillColor.Set(234, 30, 224)
                                'Dim legend As Excel.LegendEntry = newChartObject.Chart.Legend.LegendEntries(4)
                                'Dim series As Excel.Series = newChartObject.Chart.FullSeriesCollection(5)
                                'newChartObject.Chart.SeriesCollection(5)
                                'series.color = Color.HotPink

                                'newChartObject.Chart.FullSeriesCollection(5).border.color = New Integer(Color.HotPink)
                                ' newChartObject.Chart.FullSeriesCollection(5).Interior.Color = Color.HotPink.ToArgb
                                'series.Interior.Color = Color.HotPink
                               ' legend.LegendKey.Interior.Color = 15343328
                                'series.Border.Color = 15343328
                                ''series.Fill.ForeColor = RGB(234, 30, 224)
                                'series.MarkerForegroundColor = Color.HotPink.ToArgb
                                'series.MarkerBackgroundColor = Color.HotPink.ToArgb
                                ''series.MarkerForegroundColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                            Case "Weekly Stats Engineers (FC)"
                                newChartObject = chartObjects.Add(450, 30, 300, 300)
                                paramTitle = "Engineers Required per week Forecast"
                                newChartObject.Chart.ChartWizard(dataRange, Excel.XlChartType.xlLineMarkers,
                                paramChartFormat, Excel.XlRowCol.xlRows, paramSeriesLabels,
                                Categorylabelsrange, paramHasLegend, paramTitle,
                                paramCategoryTitle, paramValueTitle)
                            Case "Visits Eng Breakdown (Actual)"
                                newChartObject = chartObjects.Add(50, 175, 800, 300)
                                paramTitle = "Engineers Visits Booked"
                                newChartObject.Chart.ChartWizard(dataRange, Excel.XlChartType.xlLineMarkers,
                                paramChartFormat, Excel.XlRowCol.xlRows, paramSeriesLabels,
                                Categorylabelsrange, paramHasLegend, paramTitle,
                                paramCategoryTitle, paramValueTitle)
                        End Select

                        newChartObject.Chart.SetSourceData(dataRange)
                        newChartObject.Chart.SeriesCollection()

                        Dim axis As Excel.Axis = newChartObject.Chart.Axes(Excel.XlAxisType.xlCategory)
                        axis.HasMajorGridlines = True
                        axis.MajorGridlines.Border.Color = Color.Gray.ToArgb
                        axis.MajorGridlines.Border.LineStyle = Excel.XlLineStyle.xlContinuous
                        'axis.MajorGridlines.Format.Line.Transparency = 0.8
                        axis.CategoryType = Excel.XlCategoryType.xlCategoryScale

skipchart:
                        newWorkbook.Worksheets.Add(, targetSheet, 1)
                    End If
                Next
                targetSheet = newWorkbook.Worksheets(1)
                targetSheet.Activate()
                newWorkbook.SaveAs(paramWorkbookPath)

                ' Release the references to the Excel objects.
                newChartObject = Nothing
                chartObjects = Nothing
                dataRange = Nothing
                targetSheet = Nothing

                ' Close and release the Workbook object.
                If Not newWorkbook Is Nothing Then
                    newWorkbook.Close(False)
                    newWorkbook = Nothing
                End If

                ' Quit Excel and release the ApplicationClass object.
                If Not excelApplication Is Nothing Then
                    excelApplication.Quit()
                    excelApplication = Nothing
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Sub

            Sub ServicingStatisticsReportWorking()
                Dim excelApplication As Excel.Application
                Dim newWorkbook As Excel.Workbook
                Dim targetSheet As Excel.Worksheet
                Dim dataRange As Excel.Range
                Dim Categorylabelsrange As Excel.Range
                Dim chartObjects As Excel.ChartObjects
                Dim newChartObject As Excel.ChartObject
                Dim paramWorkbookPath As String = "C:\Temp\Test.xlsx"
                Dim paramChartFormat As Object = 1
                Dim paramCategoryLabels As Object = 0
                Dim paramSeriesLabels As Object = 0
                Dim paramHasLegend As Boolean = True
                Dim paramTitle As String = "Servicing per week"
                Dim paramCategoryTitle As String = ""
                Dim paramValueTitle As String = ""

                excelApplication = New Excel.Application

                excelApplication.DisplayAlerts = False
                'ExcelWorkBook = excelApplication.Workbooks.Add
                'ExcelWorkSheet = DirectCast(excelApplication.Worksheets(1), Excel.Worksheet)


                newWorkbook = excelApplication.Workbooks.Add()
                targetSheet = newWorkbook.Worksheets(1)
                targetSheet.Name = "Quarterly Sales"
                SetCellValue(targetSheet, "A2", "Week 1")
                SetCellValue(targetSheet, "A3", "Week 2")
                SetCellValue(targetSheet, "A4", "Week 3")
                SetCellValue(targetSheet, "A5", "Week 4")
                SetCellValue(targetSheet, "B1", "# of services")
                SetCellValue(targetSheet, "B2", 1.5)
                SetCellValue(targetSheet, "B3", 2)
                SetCellValue(targetSheet, "B4", 2.25)
                SetCellValue(targetSheet, "B5", 2.5)
                'SetCellValue(targetSheet, "C1", "Q2")
                'SetCellValue(targetSheet, "C2", 2)
                'SetCellValue(targetSheet, "C3", 1.75)
                'SetCellValue(targetSheet, "C4", 2)
                'SetCellValue(targetSheet, "C5", 2.5)
                'SetCellValue(targetSheet, "D1", "Q3")
                'SetCellValue(targetSheet, "D2", 1.5)
                'SetCellValue(targetSheet, "D3", 2)
                'SetCellValue(targetSheet, "D4", 2.5)
                'SetCellValue(targetSheet, "D5", 2)
                'SetCellValue(targetSheet, "E1", "Q4")
                'SetCellValue(targetSheet, "E2", 2.5)
                'SetCellValue(targetSheet, "E3", 2)
                'SetCellValue(targetSheet, "E4", 2)
                'SetCellValue(targetSheet, "E5", 2.75)
                dataRange = targetSheet.Range("A1", "B5")
                Categorylabelsrange = targetSheet.Range("A2", "A5")
                chartObjects = targetSheet.ChartObjects()
                newChartObject = chartObjects.Add(185, 30, 300, 300)
                newChartObject.Chart.ChartWizard(dataRange, Excel.XlChartType.xlLineMarkers, _
            paramChartFormat, Excel.XlRowCol.xlRows, Categorylabelsrange, _
            paramSeriesLabels, paramHasLegend, paramTitle, _
            paramCategoryTitle, paramValueTitle)


                newChartObject.Chart.SetSourceData(dataRange)
                newChartObject.Chart.SeriesCollection()

                Dim axis As Excel.Axis = newChartObject.Chart.Axes(Excel.XlAxisType.xlCategory)
                axis.HasMajorGridlines = True
                axis.MajorGridlines.Border.Color = Color.Gray.ToArgb
                axis.MajorGridlines.Border.LineStyle = Excel.XlLineStyle.xlContinuous
                'axis.MajorGridlines.Format.Line.Transparency = 0.8

                'newChartObject.Shapes.AddChart2(227, Excel.XlChartType.xlLine).Select()
                'newChartObject.SetSourceData(Source:=dataRange)
                'newChartObject.FullSeriesCollection(1).Select()
                'newChartObject.ChartArea.Select()
                'newChartObject.ChartType = Excel.XlChartType.xlLineMarkers



                newWorkbook.SaveAs(paramWorkbookPath)
                'paramCategoryLabels
                ' Release the references to the Excel objects.
                newChartObject = Nothing
                chartObjects = Nothing
                dataRange = Nothing
                targetSheet = Nothing

                ' Close and release the Workbook object.
                If Not newWorkbook Is Nothing Then
                    newWorkbook.Close(False)
                    newWorkbook = Nothing
                End If

                ' Quit Excel and release the ApplicationClass object.
                If Not excelApplication Is Nothing Then
                    excelApplication.Quit()
                    excelApplication = Nothing
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Sub

            Sub ServicingStatisticsReportOriginal()
                Dim excelApplication As Excel.Application
                Dim newWorkbook As Excel.Workbook
                Dim targetSheet As Excel.Worksheet
                Dim dataRange As Excel.Range
                Dim chartObjects As Excel.ChartObjects
                Dim newChartObject As Excel.ChartObject
                Dim paramWorkbookPath As String = "C:\Temp\Test.xlsx"
                Dim paramChartFormat As Object = 1
                Dim paramCategoryLabels As Object = 0
                Dim paramSeriesLabels As Object = 0
                Dim paramHasLegend As Boolean = True
                Dim paramTitle As String = "Sales by Quarter"
                Dim paramCategoryTitle As String = "Fiscal Quarter"
                Dim paramValueTitle As String = "Billions"

                excelApplication = New Excel.Application

                excelApplication.DisplayAlerts = False
                'ExcelWorkBook = excelApplication.Workbooks.Add
                'ExcelWorkSheet = DirectCast(excelApplication.Worksheets(1), Excel.Worksheet)


                newWorkbook = excelApplication.Workbooks.Add()
                targetSheet = newWorkbook.Worksheets(1)
                targetSheet.Name = "Quarterly Sales"
                SetCellValue(targetSheet, "A2", "N. America")
                SetCellValue(targetSheet, "A3", "S. America")
                SetCellValue(targetSheet, "A4", "Europe")
                SetCellValue(targetSheet, "A5", "Asia")
                SetCellValue(targetSheet, "B1", "Q1")
                SetCellValue(targetSheet, "B2", 1.5)
                SetCellValue(targetSheet, "B3", 2)
                SetCellValue(targetSheet, "B4", 2.25)
                SetCellValue(targetSheet, "B5", 2.5)
                SetCellValue(targetSheet, "C1", "Q2")
                SetCellValue(targetSheet, "C2", 2)
                SetCellValue(targetSheet, "C3", 1.75)
                SetCellValue(targetSheet, "C4", 2)
                SetCellValue(targetSheet, "C5", 2.5)
                SetCellValue(targetSheet, "D1", "Q3")
                SetCellValue(targetSheet, "D2", 1.5)
                SetCellValue(targetSheet, "D3", 2)
                SetCellValue(targetSheet, "D4", 2.5)
                SetCellValue(targetSheet, "D5", 2)
                SetCellValue(targetSheet, "E1", "Q4")
                SetCellValue(targetSheet, "E2", 2.5)
                SetCellValue(targetSheet, "E3", 2)
                SetCellValue(targetSheet, "E4", 2)
                SetCellValue(targetSheet, "E5", 2.75)
                dataRange = targetSheet.Range("A1", "E5")
                chartObjects = targetSheet.ChartObjects()
                newChartObject = chartObjects.Add(0, 100, 300, 300)
                newChartObject.Chart.ChartWizard(dataRange, Excel.XlChartType.xlLine, _
            paramChartFormat, Excel.XlRowCol.xlRows, paramCategoryLabels, _
            paramSeriesLabels, paramHasLegend, paramTitle, _
            paramCategoryTitle, paramValueTitle)
                newWorkbook.SaveAs(paramWorkbookPath)

                ' Release the references to the Excel objects.
                newChartObject = Nothing
                chartObjects = Nothing
                dataRange = Nothing
                targetSheet = Nothing

                ' Close and release the Workbook object.
                If Not newWorkbook Is Nothing Then
                    newWorkbook.Close(False)
                    newWorkbook = Nothing
                End If

                ' Quit Excel and release the ApplicationClass object.
                If Not excelApplication Is Nothing Then
                    excelApplication.Quit()
                    excelApplication = Nothing
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Sub

            Sub SetCellValue(ByRef targetSheet As Excel.Worksheet, _
    ByRef Cell As String, ByRef Value As Object)
                targetSheet.Range(Cell).Value = Value
            End Sub

            Sub SetCellValueNoRange(ByRef targetSheet As Excel.Worksheet, _
    ByRef Cell As String, ByRef Value As Object)
                targetSheet.Cells(Cell).Value = Value
            End Sub
            'oSheet.Cells(1, 2).Value = "Last Name"
            Function GetCellRef(ByRef ColumnNumber As String, ByRef RowNumber As Integer) As String
                Dim ColRef As String
                Select Case ColumnNumber
                    Case "1"
                        ColRef = "A"
                    Case "2"
                        ColRef = "B"
                    Case "3"
                        ColRef = "C"
                    Case "4"
                        ColRef = "D"
                    Case "5"
                        ColRef = "E"
                    Case "6"
                        ColRef = "F"
                    Case "7"
                        ColRef = "G"
                    Case "8"
                        ColRef = "H"
                    Case "9"
                        ColRef = "I"
                    Case "10"
                        ColRef = "J"
                    Case "11"
                        ColRef = "K"
                    Case "12"
                        ColRef = "L"
                    Case "13"
                        ColRef = "M"
                    Case "14"
                        ColRef = "N"
                    Case "15"
                        ColRef = "O"
                    Case "16"
                        ColRef = "P"
                    Case "17"
                        ColRef = "Q"
                    Case "18"
                        ColRef = "R"
                    Case "19"
                        ColRef = "S"
                    Case "20"
                        ColRef = "T"
                    Case "21"
                        ColRef = "U"
                    Case "22"
                        ColRef = "V"
                    Case "23"
                        ColRef = "W"
                    Case "24"
                        ColRef = "X"
                    Case "25"
                        ColRef = "Y"
                    Case "26"
                        ColRef = "Z"
                    Case "27"
                        ColRef = "AA"
                    Case "28"
                        ColRef = "AB"
                    Case "29"
                        ColRef = "AC"
                    Case "30"
                        ColRef = "AD"
                    Case "31"
                        ColRef = "AE"
                    Case "32"
                        ColRef = "AF"
                    Case "33"
                        ColRef = "AG"
                    Case "34"
                        ColRef = "AH"
                    Case "35"
                        ColRef = "AI"
                    Case "36"
                        ColRef = "AJ"
                    Case "37"
                        ColRef = "AK"
                    Case "38"
                        ColRef = "AL"
                    Case "39"
                        ColRef = "AM"
                    Case "40"
                        ColRef = "AN"
                    Case "41"
                        ColRef = "AO"
                    Case "42"
                        ColRef = "AP"
                    Case "43"
                        ColRef = "AQ"
                    Case "44"
                        ColRef = "AR"
                    Case "45"
                        ColRef = "AS"
                    Case "46"
                        ColRef = "AT"
                    Case "47"
                        ColRef = "AU"
                    Case "48"
                        ColRef = "AV"
                    Case "49"
                        ColRef = "AW"
                    Case "50"
                        ColRef = "AX"
                    Case "51"
                        ColRef = "AY"
                    Case "52"
                        ColRef = "AZ"
                    Case "53"
                        ColRef = "BA"
                    Case "54"
                        ColRef = "BB"
                    Case "55"
                        ColRef = "BC"
                    Case "56"
                        ColRef = "BD"
                    Case "57"
                        ColRef = "BE"
                    Case "58"
                        ColRef = "BF"
                    Case "59"
                        ColRef = "BG"
                    Case "60"
                        ColRef = "BH"
                    Case "61"
                        ColRef = "BI"
                    Case "62"
                        ColRef = "BJ"
                    Case "63"
                        ColRef = "BK"
                    Case "64"
                        ColRef = "BL"
                    Case "65"
                        ColRef = "BM"
                    Case "66"
                        ColRef = "BN"
                    Case "67"
                        ColRef = "BO"
                    Case "68"
                        ColRef = "BP"
                    Case "69"
                        ColRef = "BQ"
                    Case "70"
                        ColRef = "BR"
                    Case "71"
                        ColRef = "BS"
                    Case "72"
                        ColRef = "BT"
                    Case ColumnNumber > 75
                        ColRef = "BU"
                End Select
                Return ColRef & CStr(RowNumber)
            End Function
#End Region

        End Class

    End Namespace

End Namespace