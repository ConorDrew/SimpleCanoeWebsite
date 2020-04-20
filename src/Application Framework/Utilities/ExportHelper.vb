Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports OfficeOpenXml

Namespace Entity

    Namespace Sys

        Public Class ExportHelper

            Public Shared Sub Export(ByVal dtData As DataTable, ByVal exportFileName As String, ByVal exportType As Enums.ExportType)
                If Not loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Export) Then ShowSecurityError()

                Dim folderToSaveTo As New FolderBrowserDialog
                folderToSaveTo.ShowDialog()
                If folderToSaveTo.SelectedPath.Trim.Length = 0 Then
                    ShowMessage("Operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Dim filepath As String = Nothing
                    Select Case exportType
                        Case Enums.ExportType.CSV
                            filepath = ExportCSV(dtData, exportFileName, folderToSaveTo.SelectedPath)
                        Case Else
                            filepath = ExportXLS(dtData, exportFileName, folderToSaveTo.SelectedPath)
                    End Select

                    Process.Start(filepath)
                End If
            End Sub

            Private Shared Function ExportCSV(ByVal dtData As DataTable, ByVal exportFileName As String, ByVal savePath As String) As String
                Dim data As String = DataTableToCSV(dtData, ",")

                Dim fileName As String = exportFileName & "Export_" & Now.ToString("ddMMMyyyyHHmmss") & ".csv"
                fileName = Entity.Sys.Helper.MakeFileNameValid(fileName)
                Dim filePath As String = savePath & "\" & fileName

                Dim fileStream As FileStream = New FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                Using (fileStream)
                    Dim info As Byte() = New UTF8Encoding(True).GetBytes(data)
                    fileStream.Write(info, 0, info.Length)
                End Using
                fileStream.Close()

                Return filePath
            End Function

            Private Shared Function ExportXLS(ByVal dtData As DataTable, ByVal exportFileName As String, ByVal savePath As String) As String
                Dim fileName As String = exportFileName & " Export_" & Now.ToString("ddMMMyyyyHHmmss") & ".xlsx"
                fileName = Entity.Sys.Helper.MakeFileNameValid(fileName)
                Dim filePath As String = savePath & "\" & fileName

                Try
                    Dim newFile As New FileInfo(filePath)
                    Dim pck As New ExcelPackage(newFile)
                    Using (pck)
                        If String.IsNullOrEmpty(dtData.TableName) Then dtData.TableName = exportFileName
                        Dim ws As ExcelWorksheet = pck.Workbook.Worksheets.Add(dtData.TableName)
                        ws.Cells("A1").LoadFromDataTable(dtData, True)

                        'style header
                        Dim totalRows As Integer = ws.Dimension.End.Row
                        Dim totalColumns As Integer = ws.Dimension.End.Column
                        Dim headerCells As ExcelRange = ws.Cells(1, 1, 1, totalColumns)
                        Dim headerFont As Style.ExcelFont = headerCells.Style.Font
                        headerCells.AutoFilter = True
                        headerFont.Bold = True
                        headerFont.Color.SetColor(Color.White)
                        Dim headerFill As Style.ExcelFill = headerCells.Style.Fill
                        headerFill.PatternType = Style.ExcelFillStyle.Solid
                        headerFill.BackgroundColor.SetColor(Color.Blue)
                        Dim allCells As ExcelRange = ws.Cells(1, 1, totalRows, totalColumns)
                        allCells.AutoFitColumns()
                        Dim border As Style.Border = allCells.Style.Border
                        border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = Style.ExcelBorderStyle.Thin
                        Dim dtLength As Integer = dtData.Columns.Count
                        For i As Integer = 1 To ws.Dimension.End.Column
                            If i <= dtLength And dtData.Columns((i - 1)).DataType = GetType(DateTime) Then
                                ws.Column(i).Style.Numberformat.Format = "dd/MM/yyyy hh:mm"
                            End If
                        Next
                        allCells.Style.WrapText = True
                        pck.Save()
                    End Using
                    Return filePath
                Catch ex As Exception
                    ShowMessage("Could not generate document : " & vbCrLf & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return String.Empty
                End Try
            End Function

            Private Shared Function DataTableToCSV(ByVal datatable As DataTable, ByVal seperator As Char) As String
                Dim sb As StringBuilder = New StringBuilder()
                For i As Integer = 0 To datatable.Columns.Count - 1
                    sb.Append(datatable.Columns(i))
                    If i < datatable.Columns.Count - 1 Then sb.Append(seperator)
                Next

                Dim pattern As String = "[`~!@#\$%\^&\*\(\)_\-\+=\{\}\[\]\\\|:;""'<>,\.\?/]"

                sb.AppendLine()
                For Each dr As DataRow In datatable.Rows
                    For i As Integer = 0 To datatable.Columns.Count - 1
                        Dim info As String = dr(i).ToString()
                        Dim r As Regex = New Regex(pattern, RegexOptions.IgnoreCase)
                        Dim m As Match = r.Match(info)
                        If m.Success Then
                            info = ControlChars.Quote & String.Join(ControlChars.Quote & m.Value & ControlChars.Quote, info) & ControlChars.Quote
                        End If
                        sb.Append(info)
                        If i < datatable.Columns.Count - 1 Then sb.Append(seperator)
                    Next

                    sb.AppendLine()
                Next

                Return sb.ToString()
            End Function

            Public Shared Function DataTableToCSVNoHeaders(ByVal dt As DataTable) As String
                Dim sb As StringBuilder = New StringBuilder()

                For Each row As DataRow In dt.Rows
                    Dim fields As IEnumerable(Of String) = row.ItemArray.[Select](Function(field) field.ToString())
                    sb.AppendLine(String.Join(",", fields))
                Next

                Return sb.ToString()
            End Function

        End Class

    End Namespace

End Namespace