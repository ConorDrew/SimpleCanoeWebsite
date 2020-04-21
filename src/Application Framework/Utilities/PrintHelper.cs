using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using X = Xceed.Words.NET;

namespace FSM.Entity
{
    namespace Sys
    {
        public class PrintHelper
        {
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            private static Run ParseText(string textualData)
            {
                var newLineArray = new[] { Constants.vbCrLf };
                var textArray = textualData.Split(newLineArray, StringSplitOptions.None);
                var run = new Run();
                bool first = true;
                foreach (string line in textArray)
                {
                    if (!first)
                    {
                        run.Append(new Break());
                    }

                    first = false;
                    var txt = new Text();
                    txt.Text = line;
                    run.Append(txt);
                }

                return run;
            }

            public static void ReplaceText(WordprocessingDocument doc, string textRef, string text)
            {
                text = RemoveSpecialCharacters(Helper.MakeStringValid(text));
                var document = doc.MainDocumentPart.Document;
                foreach (Text txt in document.Descendants<Text>())
                {
                    if (txt.Text.Contains(textRef))
                    {
                        txt.Text = txt.Text.Replace(textRef, text);
                    }
                }
            }

            private static string RemoveSpecialCharacters(string text)
            {
                if (text.Contains("&amp;"))
                    text = text.Replace("&amp;", "&");
                if (text.Contains("<"))
                    text = text.Replace("<", "&lt;");
                if (text.Contains(">"))
                    text = text.Replace(">", "&gt");
                return text;
            }

            public static void DeleteBookmark(WordprocessingDocument doc, string bookmark)
            {
                // 'Find all Paragraph with 'BookmarkStart'
                var bookmarkStart = (from el in doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>()
                                     where el.Name == bookmark && el.NextSibling<Run>() is object
                                     select el).FirstOrDefault();
                if (bookmarkStart is null)
                {
                    return;
                }

                var elem = bookmarkStart.NextSibling();
                while (elem is object & !(elem is BookmarkEnd))
                {
                    var nextElem = elem.NextSibling();
                    elem.Remove();
                    elem = nextElem;
                }

                Paragraph para = (Paragraph)bookmarkStart.Parent;
                if (para is object)
                {
                    para.RemoveAllChildren();
                    para.Remove();
                }
            }

            public static void DeleteTableBookmark(WordprocessingDocument doc, string bookmark)
            {
                var t = (from el in doc.MainDocumentPart.RootElement.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>()
                         where el.InnerText.ToLower().Contains(bookmark.ToLower())
                         select el).FirstOrDefault();
                if (t is object)
                {
                    t.RemoveAllChildren();
                    t.Remove();
                }
            }

            public static void ReplaceGSRBookmark(WordprocessingDocument doc, string bookmark, string text, string fontSize = "7", bool bold = false)
            {
                // 'Find all Paragraph with 'BookmarkStart'
                var bookmarkStart = (from el in doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>()
                                     where el.Name == bookmark && el.NextSibling<Run>() is object
                                     select el).FirstOrDefault();
                if (bookmarkStart is null)
                {
                    return;
                }

                var elem = bookmarkStart.NextSibling();
                while (elem is object & !(elem is BookmarkEnd))
                {
                    var nextElem = elem.NextSibling();
                    elem.Remove();
                    elem = nextElem;
                }

                int _fSize = Helper.MakeIntegerValid(fontSize) * 2;
                var rPr = new RunProperties(new SpacingBetweenLines() { Before = "0", After = "0" });
                var rFonts = new RunFonts() { Ascii = "Arial" };
                var fSize = new FontSize() { Val = new StringValue(_fSize.ToString()) };
                var fBold = new Bold() { Val = bold };
                rPr.Append(rFonts);
                rPr.Append(fSize);
                rPr.Append(fBold);
                var run = new Run(new Text(text.Trim()));
                run.PrependChild(rPr);
                bookmarkStart.Parent.InsertAfter(run, bookmarkStart);
            }

            public static void ReplaceBookmarkWithImage(WordprocessingDocument doc, string bookmark, Bitmap img, string savePath, int index, bool centreAlign = false)
            {
                // 'Find all Paragraph with 'BookmarkStart'
                var bookmarkStart = (from el in doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>()
                                     where el.Name == bookmark && el.NextSibling<Run>() is object
                                     select el).FirstOrDefault();
                if (bookmarkStart is null)
                {
                    return;
                }

                var elem = bookmarkStart.NextSibling();
                while (elem is object & !(elem is BookmarkEnd))
                {
                    var nextElem = elem.NextSibling();
                    elem.Remove();
                    elem = nextElem;
                }

                int imgWidth = img.Width;
                int imgHeight = img.Height;
                img.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                var tImage = new ImageHelper.ImageDetails(savePath);
                var imagePart = doc.MainDocumentPart.AddImagePart(ImagePartType.Jpeg);
                using (var stream = new FileStream(savePath, FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }

                var parent = bookmarkStart.Parent;
                while (!(parent?.Parent is DocumentFormat.OpenXml.Wordprocessing.TableCell))
                {
                    if (parent is object)
                    {
                        parent = parent.Parent;
                    }
                    else
                    {
                        break;
                    }
                }

                if (parent is null)
                {
                    return;
                }

                DocumentFormat.OpenXml.Wordprocessing.TableCell cell = (DocumentFormat.OpenXml.Wordprocessing.TableCell)parent.Parent;
                var cProp = cell.GetFirstChild<TableCellProperties>();
                var cWth = cProp.GetFirstChild<TableCellWidth>();
                int cellWidth = (int)(Conversions.ToInteger(cWth.Width) / (double)21); // width in pixels
                tImage.ResizeImage(cellWidth);
                AddImageToCell(doc.MainDocumentPart.GetIdOfPart(imagePart), cell, index, tImage, centreAlign);
            }

            private static void AddImageToCell(string relationshipId, DocumentFormat.OpenXml.Wordprocessing.TableCell cell, int index, ImageHelper.ImageDetails image, bool centreAlign)
            {
                OpenXmlElement element = new Drawing(new DW.Inline(new DW.Extent() { Cx = image.cx, Cy = image.cy }, new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L }, new DW.DocProperties() { Id = (UInt32Value)(index + 1U), Name = "Picture " + index + DateTime.Now.ToString("HHmmssfff") }, new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks() { NoChangeAspect = true }), new A.Graphic(new A.GraphicData(new PIC.Picture(new PIC.NonVisualPictureProperties(new PIC.NonVisualDrawingProperties() { Id = (UInt32Value)(index + 0U), Name = "New Bitmap Image" + index + DateTime.Now.ToString("HHmmssfff") + ".jpg" }, new PIC.NonVisualPictureDrawingProperties()), new PIC.BlipFill(new A.Blip(new A.BlipExtensionList(new A.BlipExtension() { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" })) { Embed = relationshipId, CompressionState = A.BlipCompressionValues.Print }, new A.Stretch(new A.FillRectangle())), new PIC.ShapeProperties(new A.Transform2D(new A.Offset() { X = 0L, Y = 0L }, new A.Extents() { Cx = image.cx, Cy = image.cy }), new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle }))) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }))
                {
                    DistanceFromTop = 0U,
                    DistanceFromBottom = 0U,
                    DistanceFromLeft = 0U,
                    DistanceFromRight = 0U
                });
                ParagraphProperties pProp = null;
                if (centreAlign)
                {
                    var justification = new Justification() { Val = JustificationValues.Center };
                    pProp = new ParagraphProperties();
                    pProp.Append(justification);
                }

                var para = cell.ChildElements.First<Paragraph>();
                if (para is object)
                {
                    para.RemoveAllChildren();
                    para.Remove();
                }

                if (pProp is object)
                {
                    var paragraph = new Paragraph(pProp);
                    paragraph.Append(new Run(element));
                    cell.Append(paragraph);
                }
                else
                {
                    cell.Append(new Paragraph(new Run(element)));
                }
            }

            public static void ReplaceBookmarkWithTable(WordprocessingDocument doc, string bookmark, DataTable dt, bool displayBorderOutline = false)
            {
                // 'Find all Paragraph with 'BookmarkStart'
                var bookmarkStart = (from el in doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>()
                                     where el.Name == bookmark && el.NextSibling<Run>() is object
                                     select el).FirstOrDefault();
                if (bookmarkStart is null)
                {
                    return;
                }

                var elem = bookmarkStart.NextSibling();
                while (elem is object & !(elem is BookmarkEnd))
                {
                    var nextElem = elem.NextSibling();
                    elem.Remove();
                    elem = nextElem;
                }

                // Create an empty table.
                var table = new DocumentFormat.OpenXml.Wordprocessing.Table();
                var borderOultine = displayBorderOutline ? BorderValues.BasicThinLines : BorderValues.None;

                // Create a TableProperties object and specify its border information.
                var tblProp = new TableProperties(new TableBorders(new TopBorder() { Val = new EnumValue<BorderValues>(borderOultine), Size = 10 }, new BottomBorder() { Val = new EnumValue<BorderValues>(borderOultine), Size = 10 }, new LeftBorder() { Val = new EnumValue<BorderValues>(borderOultine), Size = 10 }, new RightBorder() { Val = new EnumValue<BorderValues>(borderOultine), Size = 10 }, new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(borderOultine), Size = 10 }, new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(borderOultine), Size = 10 }));

                // Append the TableProperties object to the empty table.
                table.AppendChild(tblProp);
                var tr = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                for (int i = 0, loopTo = dt.Columns.Count - 1; i <= loopTo; i++)
                {
                    // Create a cell.
                    var tc = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                    // Specify the table cell content.
                    var rPr = new RunProperties();
                    var rFonts = new RunFonts() { Ascii = "Arial" };
                    var fSize = new FontSize() { Val = new StringValue("20") };
                    var fBold = new Bold() { Val = OnOffValue.FromBoolean(true) };
                    rPr.Append(rFonts);
                    rPr.Append(fSize);
                    rPr.Append(fBold);
                    var runCell = new Run(new Text(dt.Columns[i].ColumnName.ToString()));
                    runCell.PrependChild(rPr);
                    tc.Append(new Paragraph(runCell));
                    // Specify the width property of the table cell.
                    tc.Append(new TableCellProperties(new TableCellWidth() { Width = "10000" }));
                    // Append the table cell to the table row.
                    tr.Append(tc);
                }

                table.Append(tr);
                for (int i = 0, loopTo1 = dt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    // Create a row.
                    var trContent = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    for (int j = 0, loopTo2 = dt.Columns.Count - 1; j <= loopTo2; j++)
                    {
                        // Create a cell.
                        var tc = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                        // Specify the table cell content.
                        var rPr = new RunProperties();
                        var rFonts = new RunFonts() { Ascii = "Arial" };
                        var fSize = new FontSize() { Val = new StringValue("20") };
                        rPr.Append(rFonts);
                        rPr.Append(fSize);
                        var runCell = new Run(new Text(dt.Rows[i][j].ToString()));
                        runCell.PrependChild(rPr);
                        tc.Append(new Paragraph(runCell));
                        // Specify the width property of the table cell.
                        tc.Append(new TableCellProperties(new TableCellWidth() { Width = "10000" }));
                        // Append the table cell to the table row.
                        trContent.Append(tc);
                    }

                    table.Append(trContent);
                }

                var run = new Run(new DocumentFormat.OpenXml.Wordprocessing.Table(table));
                bookmarkStart.Parent.InsertAfter(run, bookmarkStart);
            }

            public static void ReplaceBookmarkWithTable(WordprocessingDocument doc, string bookmark, DataTable dt, bool useColumnHeaders, Enums.TableCellProperties tableCellProperties)
            {
                var bookmarkStart = (from el in doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>()
                                     where el.Name == bookmark && el.NextSibling<Run>() is object
                                     select el).FirstOrDefault();
                if (bookmarkStart is null)
                    return;
                var elem = bookmarkStart.NextSibling();
                while (elem is object & !(elem is BookmarkEnd))
                {
                    var nextElem = elem.NextSibling();
                    elem.Remove();
                    elem = nextElem;
                }

                var table = new DocumentFormat.OpenXml.Wordprocessing.Table();
                var tblProp = new TableProperties(new TableBorders(new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Size = 10 }, new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Size = 10 }, new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Size = 10 }, new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Size = 10 }, new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Size = 10 }, new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.None), Size = 10 }));
                table.AppendChild(tblProp);
                if (useColumnHeaders)
                {
                    var tr = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    for (int i = 0, loopTo = dt.Columns.Count - 1; i <= loopTo; i++)
                    {
                        var tc = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                        var rPr = new RunProperties();
                        var rFonts = new RunFonts() { Ascii = "Arial" };
                        var fSize = new FontSize() { Val = new StringValue("20") };
                        var fBold = new Bold() { Val = OnOffValue.FromBoolean(true) };
                        rPr.Append(rFonts);
                        rPr.Append(fSize);
                        rPr.Append(fBold);
                        var runCell = new Run(new Text(dt.Columns[i].ColumnName.ToString()));
                        runCell.PrependChild(rPr);
                        tc.Append(new Paragraph(runCell));
                        tc.Append(new TableCellProperties(new TableCellWidth() { Width = "10000" }));
                        tr.Append(tc);
                    }

                    table.Append(tr);
                }

                for (int i = 0, loopTo1 = dt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    var trContent = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    for (int j = 0, loopTo2 = dt.Columns.Count - 1; j <= loopTo2; j++)
                    {
                        var tcp = GetCellProperties(tableCellProperties, j, false);
                        var tc = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                        var rPr = new RunProperties();
                        var rFonts = new RunFonts() { Ascii = tcp.Item1 };
                        var fSize = new FontSize() { Val = new StringValue(tcp.Item2) };
                        var fBold = new Bold() { Val = OnOffValue.FromBoolean(tcp.Item3) };
                        rPr.Append(rFonts);
                        rPr.Append(fSize);
                        rPr.Append(fBold);
                        var runCell = new Run(new Text(dt.Rows[i][j].ToString()));
                        runCell.PrependChild(rPr);
                        tc.Append(new Paragraph(runCell, new Run(new Break())));
                        tc.Append(new TableCellProperties(new TableCellWidth() { Width = tcp.Item4 }));
                        trContent.Append(tc);
                    }

                    table.Append(trContent);
                }

                var run = new Run(new DocumentFormat.OpenXml.Wordprocessing.Table(table));
                bookmarkStart.Parent.InsertAfter(run, bookmarkStart);
            }

            public static void AddRowsToTable(WordprocessingDocument doc, string tableRef, DataTable dt, string font = "", string fontSize = "", int postion = 0)
            {
                var body = doc.MainDocumentPart.Document.Body;
                var tables = (from el in doc.MainDocumentPart.RootElement.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>()
                              where el.InnerText.ToLower().Contains(tableRef.ToLower())
                              select el).ToList();
                var t = postion == 0 ? tables.FirstOrDefault() : tables[postion];
                if (t is null)
                    return;
                for (int i = 0, loopTo = dt.Rows.Count - 1; i <= loopTo; i++)
                {
                    var trContent = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
                    for (int j = 0, loopTo1 = dt.Columns.Count - 1; j <= loopTo1; j++)
                    {
                        var tc = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                        RunProperties rPr = null;
                        if (!Helper.IsStringEmpty(font))
                        {
                            rPr = new RunProperties();
                            var rFonts = new RunFonts() { Ascii = font };
                            rPr.Append(rFonts);
                            if (!string.IsNullOrEmpty(fontSize))
                                rPr.Append(new FontSize() { Val = new StringValue(fontSize) });
                        }

                        var runCell = ParseText(dt.Rows[i][j].ToString());
                        if (rPr is object)
                            runCell.PrependChild(rPr);
                        tc.Append(new Paragraph(runCell, new Run(new Break())));
                        trContent.Append(tc);
                    }

                    t.Append(trContent);
                }
            }

            private static Tuple<string, string, bool, string> GetCellProperties(Enums.TableCellProperties tcp, int columnCount, bool header)
            {
                string font = "Arial";
                string fontSize = "20";
                bool fontBold = false;
                string cellWidth = "10000";
                if (tcp == Enums.TableCellProperties.ContractAppliance)
                {
                    switch (columnCount)
                    {
                        case 0:
                            {
                                cellWidth = "3300";
                                break;
                            }

                        case 1:
                            {
                                fontSize = "22";
                                fontBold = true;
                                break;
                            }
                    }
                }

                return Tuple.Create(font, fontSize, fontBold, cellWidth);
            }

            public static byte[] CombineDocs(List<MemoryStream> docs)
            {
                var sources = new List<Source>();
                foreach (MemoryStream doc in docs)
                    sources.Add(new Source(new WmlDocument(doc.Length.ToString(), doc), true));
                var mergedDoc = DocumentBuilder.BuildDocument(sources);
                return mergedDoc.DocumentByteArray;
            }

            public static byte[] CombineDocs(List<byte[]> docs)
            {
                var sources = new List<Source>();
                foreach (byte[] doc in docs)
                    sources.Add(new Source(new WmlDocument(doc.Length.ToString(), doc), true));
                var mergedDoc = DocumentBuilder.BuildDocument(sources);
                return mergedDoc.DocumentByteArray;
            }

            public static string ToPdf(string filePath, bool openFile = false, bool deleteFile = false)
            {
                try
                {
                    var pdf = new Microsoft.Office.Interop.Word.Application();
                    pdf.Visible = false;
                    object argFileName = filePath;
                    var doc = pdf.Documents.Open(ref argFileName);
                    string pdfFilePath = Path.ChangeExtension(filePath, ".pdf");
                    doc.Activate();
                    try
                    {
                        doc.PageSetup.LeftMargin = Conversions.ToSingle(CentimetersToPoints(1.8));
                        doc.PageSetup.RightMargin = Conversions.ToSingle(CentimetersToPoints(2.31));
                    }
                    catch (Exception ex)
                    {
                    }

                    object argFileName1 = pdfFilePath;
                    object argFileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                    doc.SaveAs2(ref argFileName1, ref argFileFormat);
                    doc.Close();
                    pdf.Quit();
                    return pdfFilePath;
                }
                catch (Exception ex)
                {
                    return filePath;
                }
            }

            public static string LockFile(string filePath, bool deleteFile = false)
            {
                string ext = Path.GetExtension(filePath);
                if ((ext ?? "") != ".docx")
                    return Conversions.ToString(false);
                try
                {
                    string pass = Helper.CreateRandomPassword(8);
                    string readOnlyFilePath = filePath.Replace(ext, "_Protected" + ext);
                    using (var doc = X.DocX.Load(filePath))
                    {
                        var erReadOnly = X.EditRestrictions.readOnly;
                        doc.AddPasswordProtection(erReadOnly, pass);
                        doc.SaveAs(readOnlyFilePath);
                    }

                    if (deleteFile)
                    {
                        File.Delete(filePath);
                    }

                    return readOnlyFilePath;
                }
                catch (Exception ex)
                {
                    return filePath;
                }
            }

            public static void RemoveSpacingInDoc(string filePath)
            {
                var byteArray = File.ReadAllBytes(filePath);
                var mm = new MemoryStream();
                using (mm)
                {
                    mm.Write(byteArray, 0, byteArray.Length);
                    var doc = WordprocessingDocument.Open(mm, true);
                    using (doc)
                    {
                        var paragraphs = doc.MainDocumentPart.Document.Body.Descendants<Paragraph>().ToList();
                        foreach (Paragraph paragraph in paragraphs)
                        {
                            var pProps = paragraph.Elements<ParagraphProperties>().ToList();
                            foreach (ParagraphProperties pProp in pProps)
                            {
                                pProp.SpacingBetweenLines = new SpacingBetweenLines() { Before = "0", After = "0", LineRule = LineSpacingRuleValues.Auto };
                                pProp.ParagraphStyleId = new ParagraphStyleId() { Val = "No Spacing" };
                            }

                            var runs = paragraph.Elements<Run>().ToList();
                            foreach (Run run in runs)
                            {
                                var rProps = run.Elements<RunProperties>().ToList();
                                foreach (RunProperties rProp in rProps)
                                    rProp.Spacing = new Spacing() { Val = (Int32Value)Convert.ToInt32("0") };
                            }
                        }

                        doc.MainDocumentPart.Document.Save();
                    }

                    filePath = FileCheck(filePath);
                    var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    mm.Position = 0;
                    using (fileStream)
                        mm.WriteTo(fileStream);
                }
            }

            private static string FileCheck(string filePath)
            {
                // check if file exists first
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
                catch (Exception ex)
                {
                    // can't delete because another process is using
                    string ext = Path.GetExtension(filePath);
                    filePath = filePath.Replace(ext, "_New" + ext);
                }

                return filePath;
            }

            private static double CentimetersToPoints(double cm)
            {
                return cm * 28.34;
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}