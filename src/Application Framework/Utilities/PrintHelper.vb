Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Wordprocessing
Imports OpenXmlPowerTools
Imports A = DocumentFormat.OpenXml.Drawing
Imports DW = DocumentFormat.OpenXml.Drawing.Wordprocessing
Imports PIC = DocumentFormat.OpenXml.Drawing.Pictures
Imports X = Xceed.Words.NET

Namespace Entity

    Namespace Sys

        Public Class PrintHelper

#Region "Functions"

            Private Shared Function ParseText(ByVal textualData As String) As Run
                Dim newLineArray As String() = {vbCrLf}
                Dim textArray As String() = textualData.Split(newLineArray, StringSplitOptions.None)
                Dim run As Run = New Run()
                Dim first As Boolean = True

                For Each line As String In textArray

                    If Not first Then
                        run.Append(New Break())
                    End If

                    first = False
                    Dim txt As Text = New Text()
                    txt.Text = line
                    run.Append(txt)
                Next

                Return run
            End Function

            Public Shared Sub ReplaceText(ByVal doc As WordprocessingDocument, ByVal textRef As String, ByVal text As String)
                text = RemoveSpecialCharacters(Helper.MakeStringValid(text))
                Dim document As Document = doc.MainDocumentPart.Document
                For Each txt As Text In document.Descendants(Of Text)
                    If txt.Text.Contains(textRef) Then
                        txt.Text = txt.Text.Replace(textRef, text)
                    End If
                Next
            End Sub

            Private Shared Function RemoveSpecialCharacters(ByVal text As String) As String
                If text.Contains("&amp;") Then text = text.Replace("&amp;", "&")
                If text.Contains("<") Then text = text.Replace("<", "&lt;")
                If text.Contains(">") Then text = text.Replace(">", "&gt")
                Return text
            End Function

            Public Shared Sub DeleteBookmark(ByVal doc As WordprocessingDocument, ByVal bookmark As String)
                ''Find all Paragraph with 'BookmarkStart'
                Dim bookmarkStart As BookmarkStart = (From el In doc.MainDocumentPart.RootElement.Descendants(Of BookmarkStart)()
                                                      Where (el.Name = bookmark) AndAlso
                             (el.NextSibling(Of Run)() IsNot Nothing) Select el).FirstOrDefault()
                If bookmarkStart Is Nothing Then
                    Exit Sub
                End If

                Dim elem As OpenXmlElement = bookmarkStart.NextSibling()
                While (elem IsNot Nothing And (Not (TypeOf elem Is BookmarkEnd)))
                    Dim nextElem As OpenXmlElement = elem.NextSibling
                    elem.Remove()
                    elem = nextElem
                End While

                Dim para As Paragraph = bookmarkStart.Parent
                If para IsNot Nothing Then
                    para.RemoveAllChildren()
                    para.Remove()
                End If
            End Sub

            Public Shared Sub DeleteTableBookmark(ByVal doc As WordprocessingDocument, ByVal bookmark As String)
                Dim t As Wordprocessing.Table = (From el In doc.MainDocumentPart.RootElement.Descendants(Of Wordprocessing.Table)()
                                                 Where (el.InnerText.ToLower.Contains(bookmark.ToLower)) Select el).FirstOrDefault()
                If t IsNot Nothing Then
                    t.RemoveAllChildren()
                    t.Remove()
                End If
            End Sub

            Public Shared Sub ReplaceGSRBookmark(ByVal doc As WordprocessingDocument, ByVal bookmark As String, ByVal text As String,
                                                 Optional ByVal fontSize As String = "7", Optional ByVal bold As Boolean = False)
                ''Find all Paragraph with 'BookmarkStart'
                Dim bookmarkStart As BookmarkStart = (From el In doc.MainDocumentPart.RootElement.Descendants(Of BookmarkStart)()
                                                      Where (el.Name = bookmark) AndAlso
                             (el.NextSibling(Of Run)() IsNot Nothing) Select el).FirstOrDefault()
                If bookmarkStart Is Nothing Then
                    Exit Sub
                End If

                Dim elem As OpenXmlElement = bookmarkStart.NextSibling()
                While (elem IsNot Nothing And (Not (TypeOf elem Is BookmarkEnd)))
                    Dim nextElem As OpenXmlElement = elem.NextSibling
                    elem.Remove()
                    elem = nextElem
                End While

                Dim _fSize As Integer = Helper.MakeIntegerValid(fontSize) * 2

                Dim rPr As RunProperties = New RunProperties(New SpacingBetweenLines() With {.Before = "0", .After = "0"})
                Dim rFonts As RunFonts = New RunFonts With {.Ascii = "Arial"}
                Dim fSize As FontSize = New FontSize With {.Val = New StringValue(_fSize.ToString())}
                Dim fBold As Bold = New Bold With {.Val = bold}
                rPr.Append(rFonts)
                rPr.Append(fSize)
                rPr.Append(fBold)

                Dim run As Run = New Run(New Text(text.Trim()))
                run.PrependChild(Of RunProperties)(rPr)
                bookmarkStart.Parent.InsertAfter(Of Run)(run, bookmarkStart)
            End Sub

            Public Shared Sub ReplaceBookmarkWithImage(ByVal doc As WordprocessingDocument, ByVal bookmark As String, ByVal img As Bitmap, ByVal savePath As String, ByVal index As Integer,
                                                       Optional ByVal centreAlign As Boolean = False)
                ''Find all Paragraph with 'BookmarkStart'
                Dim bookmarkStart As BookmarkStart = (From el In doc.MainDocumentPart.RootElement.Descendants(Of BookmarkStart)()
                                                      Where (el.Name = bookmark) AndAlso
                             (el.NextSibling(Of Run)() IsNot Nothing) Select el).FirstOrDefault()
                If bookmarkStart Is Nothing Then
                    Exit Sub
                End If

                Dim elem As OpenXmlElement = bookmarkStart.NextSibling()
                While (elem IsNot Nothing And (Not (TypeOf elem Is BookmarkEnd)))
                    Dim nextElem As OpenXmlElement = elem.NextSibling
                    elem.Remove()
                    elem = nextElem
                End While

                Dim imgWidth As Integer = img.Width
                Dim imgHeight As Integer = img.Height

                img.Save(savePath, Imaging.ImageFormat.Jpeg)

                Dim tImage As ImageHelper.ImageDetails = New ImageHelper.ImageDetails(savePath)
                Dim imagePart As ImagePart = doc.MainDocumentPart.AddImagePart(ImagePartType.Jpeg)
                Using stream As New FileStream(savePath, FileMode.Open)
                    imagePart.FeedData(stream)
                End Using

                Dim parent As OpenXmlElement = bookmarkStart.Parent
                While (Not (TypeOf parent?.Parent Is Wordprocessing.TableCell))
                    If parent IsNot Nothing Then
                        parent = parent.Parent
                    Else
                        Exit While
                    End If
                End While

                If parent Is Nothing Then
                    Exit Sub
                End If

                Dim cell As Wordprocessing.TableCell = parent.Parent

                Dim cProp As TableCellProperties = cell.GetFirstChild(Of TableCellProperties)
                Dim cWth As TableCellWidth = cProp.GetFirstChild(Of TableCellWidth)
                Dim cellWidth As Integer = CInt(cWth.Width) / 21 'width in pixels
                tImage.ResizeImage(cellWidth)
                AddImageToCell(doc.MainDocumentPart.GetIdOfPart(imagePart), cell, index, tImage, centreAlign)
            End Sub

            Private Shared Sub AddImageToCell(ByVal relationshipId As String, ByVal cell As Wordprocessing.TableCell, ByVal index As Integer, ByVal image As ImageHelper.ImageDetails,
                                              ByVal centreAlign As Boolean)

                Dim element As OpenXmlElement =
                    New Drawing(
                        New DW.Inline(
                            New DW.Extent() With {.Cx = image.cx, .Cy = image.cy},
                            New DW.EffectExtent() With {.LeftEdge = 0L, .TopEdge = 0L, .RightEdge = 0L, .BottomEdge = 0L},
                            New DW.DocProperties() With {.Id = CType(index + 1UI, UInt32Value), .Name = "Picture " & index & Date.Now.ToString("HHmmssfff")},
                            New DW.NonVisualGraphicFrameDrawingProperties(
                                New A.GraphicFrameLocks() With {.NoChangeAspect = True}
                            ),
                            New A.Graphic(
                                New A.GraphicData(
                                    New PIC.Picture(
                                        New PIC.NonVisualPictureProperties(
                                            New PIC.NonVisualDrawingProperties() With {.Id = CType(index + 0UI, UInt32Value), .Name = "New Bitmap Image" & index & Date.Now.ToString("HHmmssfff") & ".jpg"},
                                            New PIC.NonVisualPictureDrawingProperties()
                                        ),
                                        New PIC.BlipFill(
                                            New A.Blip(
                                                New A.BlipExtensionList(
                                                    New A.BlipExtension() With {.Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"})
                                            ) With {.Embed = relationshipId, .CompressionState = A.BlipCompressionValues.Print},
                                            New A.Stretch(
                                                New A.FillRectangle()
                                            )
                                        ),
                                        New PIC.ShapeProperties(
                                            New A.Transform2D(
                                                New A.Offset() With {.X = 0L, .Y = 0L},
                                                New A.Extents() With {.Cx = image.cx, .Cy = image.cy}
                                            ),
                                            New A.PresetGeometry(
                                                New A.AdjustValueList()
                                            ) With {.Preset = A.ShapeTypeValues.Rectangle}
                                        )
                                    )
                                ) With {.Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture"}
                            )
                        ) With {.DistanceFromTop = CType(0UI, UInt32Value),
                                .DistanceFromBottom = CType(0UI, UInt32Value),
                                .DistanceFromLeft = CType(0UI, UInt32Value),
                                .DistanceFromRight = CType(0UI, UInt32Value)})

                Dim pProp As ParagraphProperties = Nothing
                If centreAlign Then
                    Dim justification As New Justification() With {.Val = JustificationValues.Center}
                    pProp = New ParagraphProperties
                    pProp.Append(justification)
                End If

                Dim para As Paragraph = cell.ChildElements.First(Of Paragraph)()
                If para IsNot Nothing Then
                    para.RemoveAllChildren()
                    para.Remove()
                End If

                If pProp IsNot Nothing Then
                    Dim paragraph As New Paragraph(pProp)
                    paragraph.Append(New Run(element))
                    cell.Append(paragraph)
                Else
                    cell.Append(New Paragraph(New Run(element)))
                End If
            End Sub

            Public Shared Sub ReplaceBookmarkWithTable(ByVal doc As WordprocessingDocument, ByVal bookmark As String, ByVal dt As DataTable, Optional displayBorderOutline As Boolean = False)
                ''Find all Paragraph with 'BookmarkStart'
                Dim bookmarkStart As BookmarkStart = (From el In doc.MainDocumentPart.RootElement.Descendants(Of BookmarkStart)()
                                                      Where (el.Name = bookmark) AndAlso
                             (el.NextSibling(Of Run)() IsNot Nothing) Select el).FirstOrDefault()
                If bookmarkStart Is Nothing Then
                    Exit Sub
                End If

                Dim elem As OpenXmlElement = bookmarkStart.NextSibling()
                While (elem IsNot Nothing And (Not (TypeOf elem Is BookmarkEnd)))
                    Dim nextElem As OpenXmlElement = elem.NextSibling
                    elem.Remove()
                    elem = nextElem
                End While

                ' Create an empty table.
                Dim table As New Wordprocessing.Table()
                Dim borderOultine As BorderValues = If(displayBorderOutline, BorderValues.BasicThinLines, BorderValues.None)

                ' Create a TableProperties object and specify its border information.
                Dim tblProp As New TableProperties(New TableBorders(
                    New TopBorder() With {.Val = New EnumValue(Of BorderValues)(borderOultine), .Size = 10},
                    New BottomBorder() With {.Val = New EnumValue(Of BorderValues)(borderOultine), .Size = 10},
                    New LeftBorder() With {.Val = New EnumValue(Of BorderValues)(borderOultine), .Size = 10},
                    New RightBorder() With {.Val = New EnumValue(Of BorderValues)(borderOultine), .Size = 10},
                    New InsideHorizontalBorder() With {.Val = New EnumValue(Of BorderValues)(borderOultine), .Size = 10},
                    New InsideVerticalBorder() With {.Val = New EnumValue(Of BorderValues)(borderOultine), .Size = 10}))

                ' Append the TableProperties object to the empty table.
                table.AppendChild(Of TableProperties)(tblProp)

                Dim tr As New Wordprocessing.TableRow()
                For i As Integer = 0 To dt.Columns.Count - 1
                    ' Create a cell.
                    Dim tc As New Wordprocessing.TableCell()
                    ' Specify the table cell content.
                    Dim rPr As RunProperties = New RunProperties()
                    Dim rFonts As RunFonts = New RunFonts With {.Ascii = "Arial"}
                    Dim fSize As FontSize = New FontSize With {.Val = New StringValue("20")}
                    Dim fBold As Bold = New Bold With {.Val = OnOffValue.FromBoolean(True)}
                    rPr.Append(rFonts)
                    rPr.Append(fSize)
                    rPr.Append(fBold)

                    Dim runCell As Run = New Run(New Text(dt.Columns(i).ColumnName.ToString()))
                    runCell.PrependChild(Of RunProperties)(rPr)
                    tc.Append(New Paragraph(runCell))
                    ' Specify the width property of the table cell.
                    tc.Append(New TableCellProperties(New TableCellWidth() With {.Width = "10000"}))
                    ' Append the table cell to the table row.
                    tr.Append(tc)
                Next
                table.Append(tr)

                For i As Integer = 0 To dt.Rows.Count - 1
                    ' Create a row.
                    Dim trContent As New Wordprocessing.TableRow()

                    For j As Integer = 0 To dt.Columns.Count - 1
                        ' Create a cell.
                        Dim tc As New Wordprocessing.TableCell()
                        ' Specify the table cell content.
                        Dim rPr As RunProperties = New RunProperties()
                        Dim rFonts As RunFonts = New RunFonts With {.Ascii = "Arial"}
                        Dim fSize As FontSize = New FontSize With {.Val = New StringValue("20")}
                        rPr.Append(rFonts)
                        rPr.Append(fSize)

                        Dim runCell As Run = New Run(New Text(dt.Rows(i)(j).ToString()))
                        runCell.PrependChild(Of RunProperties)(rPr)
                        tc.Append(New Paragraph(runCell))
                        ' Specify the width property of the table cell.
                        tc.Append(New TableCellProperties(New TableCellWidth() With {.Width = "10000"}))
                        ' Append the table cell to the table row.
                        trContent.Append(tc)
                    Next
                    table.Append(trContent)
                Next
                Dim run As Run = New Run(New Wordprocessing.Table(table))
                bookmarkStart.Parent.InsertAfter(Of Run)(run, bookmarkStart)
            End Sub

            Public Shared Sub ReplaceBookmarkWithTable(ByVal doc As WordprocessingDocument, ByVal bookmark As String, ByVal dt As DataTable, ByVal useColumnHeaders As Boolean, ByVal tableCellProperties As Enums.TableCellProperties)
                Dim bookmarkStart As BookmarkStart = (From el In doc.MainDocumentPart.RootElement.Descendants(Of BookmarkStart)() Where (el.Name = bookmark) AndAlso (el.NextSibling(Of Run)() IsNot Nothing) Select el).FirstOrDefault()
                If bookmarkStart Is Nothing Then Return
                Dim elem As OpenXmlElement = bookmarkStart.NextSibling()

                While (elem IsNot Nothing And (Not (TypeOf elem Is BookmarkEnd)))
                    Dim nextElem As OpenXmlElement = elem.NextSibling()
                    elem.Remove()
                    elem = nextElem
                End While

                Dim table As Wordprocessing.Table = New Wordprocessing.Table()
                Dim tblProp As TableProperties =
                    New TableProperties(
                    New TableBorders(
                    New TopBorder() With {.Val = New EnumValue(Of BorderValues)(BorderValues.None), .Size = 10},
                    New BottomBorder() With {.Val = New EnumValue(Of BorderValues)(BorderValues.None), .Size = 10},
                    New LeftBorder() With {.Val = New EnumValue(Of BorderValues)(BorderValues.None), .Size = 10},
                    New RightBorder() With {.Val = New EnumValue(Of BorderValues)(BorderValues.None), .Size = 10},
                    New InsideHorizontalBorder() With {.Val = New EnumValue(Of BorderValues)(BorderValues.None), .Size = 10},
                    New InsideVerticalBorder() With {.Val = New EnumValue(Of BorderValues)(BorderValues.None), .Size = 10}))
                table.AppendChild(Of TableProperties)(tblProp)

                If useColumnHeaders Then
                    Dim tr As Wordprocessing.TableRow = New Wordprocessing.TableRow()

                    For i As Integer = 0 To dt.Columns.Count - 1
                        Dim tc As Wordprocessing.TableCell = New Wordprocessing.TableCell()
                        Dim rPr As RunProperties = New RunProperties()
                        Dim rFonts As RunFonts = New RunFonts() With {.Ascii = "Arial"}
                        Dim fSize As FontSize = New FontSize() With {.Val = New StringValue("20")}
                        Dim fBold As Bold = New Bold() With {.Val = OnOffValue.FromBoolean(True)}
                        rPr.Append(rFonts)
                        rPr.Append(fSize)
                        rPr.Append(fBold)
                        Dim runCell As Run = New Run(New Text(dt.Columns(i).ColumnName.ToString()))
                        runCell.PrependChild(Of RunProperties)(rPr)
                        tc.Append(New Paragraph(runCell))
                        tc.Append(New TableCellProperties(New TableCellWidth() With {.Width = "10000"}))
                        tr.Append(tc)
                    Next
                    table.Append(tr)
                End If

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim trContent As Wordprocessing.TableRow = New Wordprocessing.TableRow()

                    For j As Integer = 0 To dt.Columns.Count - 1
                        Dim tcp As Tuple(Of String, String, Boolean, String) = GetCellProperties(tableCellProperties, j, False)
                        Dim tc As Wordprocessing.TableCell = New Wordprocessing.TableCell()
                        Dim rPr As RunProperties = New RunProperties()
                        Dim rFonts As RunFonts = New RunFonts() With {.Ascii = tcp.Item1}
                        Dim fSize As FontSize = New FontSize() With {.Val = New StringValue(tcp.Item2)}
                        Dim fBold As Bold = New Bold() With {.Val = OnOffValue.FromBoolean(tcp.Item3)}
                        rPr.Append(rFonts)
                        rPr.Append(fSize)
                        rPr.Append(fBold)
                        Dim runCell As Run = New Run(New Text(dt.Rows(i)(j).ToString()))
                        runCell.PrependChild(Of RunProperties)(rPr)
                        tc.Append(New Paragraph(runCell, New Run(New Break())))
                        tc.Append(New TableCellProperties(New TableCellWidth() With {.Width = tcp.Item4}))
                        trContent.Append(tc)
                    Next
                    table.Append(trContent)
                Next

                Dim run As Run = New Run(New Wordprocessing.Table(table))
                bookmarkStart.Parent.InsertAfter(Of Run)(run, bookmarkStart)
            End Sub

            Public Shared Sub AddRowsToTable(ByVal doc As WordprocessingDocument, ByVal tableRef As String, ByVal dt As DataTable, Optional ByVal font As String = "", Optional ByVal fontSize As String = "", Optional postion As Integer = 0)
                Dim body As Body = doc.MainDocumentPart.Document.Body
                Dim tables As List(Of Wordprocessing.Table) = (From el In doc.MainDocumentPart.RootElement.Descendants(Of Wordprocessing.Table)() Where (el.InnerText.ToLower.Contains(tableRef.ToLower)) Select el).ToList()
                Dim t As Wordprocessing.Table = If(postion = 0, tables.FirstOrDefault(), tables(postion))

                If t Is Nothing Then Exit Sub
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim trContent As Wordprocessing.TableRow = New Wordprocessing.TableRow()

                    For j As Integer = 0 To dt.Columns.Count - 1
                        Dim tc As Wordprocessing.TableCell = New Wordprocessing.TableCell()
                        Dim rPr As RunProperties = Nothing
                        If Not Helper.IsStringEmpty(font) Then
                            rPr = New RunProperties()
                            Dim rFonts As RunFonts = New RunFonts() With {.Ascii = font}
                            rPr.Append(rFonts)
                            If Not String.IsNullOrEmpty(fontSize) Then rPr.Append(New FontSize() With {.Val = New StringValue(fontSize)})
                        End If
                        Dim runCell As Run = ParseText(dt.Rows(i)(j).ToString())
                        If rPr IsNot Nothing Then runCell.PrependChild(Of RunProperties)(rPr)
                        tc.Append(New Paragraph(runCell, New Run(New Break())))
                        trContent.Append(tc)
                    Next
                    t.Append(trContent)
                Next
            End Sub

            Private Shared Function GetCellProperties(ByVal tcp As Enums.TableCellProperties, ByVal columnCount As Integer, ByVal header As Boolean) As Tuple(Of String, String, Boolean, String)
                Dim font As String = "Arial"
                Dim fontSize As String = "20"
                Dim fontBold As Boolean = False
                Dim cellWidth As String = "10000"

                If tcp = Enums.TableCellProperties.ContractAppliance Then

                    Select Case columnCount
                        Case 0
                            cellWidth = "3300"
                        Case 1
                            fontSize = "22"
                            fontBold = True
                    End Select
                End If

                Return Tuple.Create(font, fontSize, fontBold, cellWidth)
            End Function

            Public Shared Function CombineDocs(ByVal docs As List(Of MemoryStream)) As Byte()
                Dim sources As New List(Of Source)

                For Each doc As MemoryStream In docs
                    sources.Add(New Source(New WmlDocument(doc.Length.ToString(), doc), True))
                Next

                Dim mergedDoc As WmlDocument = DocumentBuilder.BuildDocument(sources)
                Return mergedDoc.DocumentByteArray
            End Function

            Public Shared Function CombineDocs(ByVal docs As List(Of Byte())) As Byte()
                Dim sources As New List(Of Source)

                For Each doc As Byte() In docs
                    sources.Add(New Source(New WmlDocument(doc.Length.ToString(), doc), True))
                Next

                Dim mergedDoc As WmlDocument = DocumentBuilder.BuildDocument(sources)
                Return mergedDoc.DocumentByteArray
            End Function

            Public Shared Function ToPdf(ByVal filePath As String, Optional ByVal openFile As Boolean = False, Optional ByVal deleteFile As Boolean = False) As String
                Try
                    Dim pdf As Word.Application = New Word.Application()
                    pdf.Visible = False
                    Dim doc As Word.Document = pdf.Documents.Open(CObj(filePath))
                    Dim pdfFilePath As String = Path.ChangeExtension(filePath, ".pdf")
                    doc.Activate()
                    Try
                        doc.PageSetup.LeftMargin = CentimetersToPoints(1.8)
                        doc.PageSetup.RightMargin = CentimetersToPoints(2.31)
                    Catch ex As Exception

                    End Try
                    doc.SaveAs2(CObj(pdfFilePath), Word.WdSaveFormat.wdFormatPDF)
                    doc.Close()
                    pdf.Quit()

                    Return pdfFilePath
                Catch ex As Exception
                    Return filePath
                End Try
            End Function

            Public Shared Function LockFile(ByVal filePath As String, Optional ByVal deleteFile As Boolean = False) As String
                Dim ext As String = Path.GetExtension(filePath)
                If ext <> ".docx" Then Return False

                Try
                    Dim pass As String = Helper.CreateRandomPassword(8)
                    Dim readOnlyFilePath As String = filePath.Replace(ext, "_Protected" & ext)
                    Using doc As X.DocX = X.DocX.Load(filePath)
                        Dim erReadOnly As X.EditRestrictions = X.EditRestrictions.readOnly
                        doc.AddPasswordProtection(erReadOnly, pass)
                        doc.SaveAs(readOnlyFilePath)
                    End Using
                    If deleteFile Then
                        File.Delete(filePath)
                    End If
                    Return readOnlyFilePath
                Catch ex As Exception
                    Return filePath
                End Try
            End Function

            Public Shared Sub RemoveSpacingInDoc(ByVal filePath As String)

                Dim byteArray As Byte() = File.ReadAllBytes(filePath)
                Dim mm As MemoryStream = New MemoryStream
                Using (mm)
                    mm.Write(byteArray, 0, byteArray.Length)
                    Dim doc As WordprocessingDocument = WordprocessingDocument.Open(mm, True)
                    Using (doc)

                        Dim paragraphs As List(Of Paragraph) = (From el In doc.MainDocumentPart.Document.Body.Descendants(Of Paragraph)).ToList()
                        For Each paragraph As Paragraph In paragraphs
                            Dim pProps As List(Of ParagraphProperties) = paragraph.Elements(Of ParagraphProperties).ToList()
                            For Each pProp As ParagraphProperties In pProps
                                pProp.SpacingBetweenLines = New SpacingBetweenLines() With {.Before = "0", .After = "0", .LineRule = LineSpacingRuleValues.Auto}
                                pProp.ParagraphStyleId = New ParagraphStyleId() With {.Val = "No Spacing"}
                            Next
                            Dim runs As List(Of Run) = paragraph.Elements(Of Run).ToList()
                            For Each run As Run In runs
                                Dim rProps As List(Of RunProperties) = run.Elements(Of RunProperties).ToList()
                                For Each rProp As RunProperties In rProps
                                    rProp.Spacing = New Spacing() With {.Val = "0"}
                                Next
                            Next
                        Next
                        doc.MainDocumentPart.Document.Save()
                    End Using
                    filePath = FileCheck(filePath)

                    Dim fileStream As FileStream = New FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                    mm.Position = 0
                    Using (fileStream)
                        mm.WriteTo(fileStream)
                    End Using
                End Using
            End Sub

            Private Shared Function FileCheck(ByVal filePath As String) As String
                'check if file exists first
                Try
                    If File.Exists(filePath) Then
                        File.Delete(filePath)
                    End If
                Catch ex As Exception
                    'can't delete because another process is using
                    Dim ext As String = Path.GetExtension(filePath)
                    filePath = filePath.Replace(ext, "_New" & ext)
                End Try

                Return filePath
            End Function

            Private Shared Function CentimetersToPoints(ByVal cm As Double) As Double
                Return cm * 28.34
            End Function

#End Region

        End Class

    End Namespace

End Namespace