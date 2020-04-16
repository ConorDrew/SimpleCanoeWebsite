// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.PrintHelper
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic.CompilerServices;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Xceed.Words.NET;

namespace FSM.Entity.Sys
{
  public class PrintHelper
  {
    private static DocumentFormat.OpenXml.Wordprocessing.Run ParseText(string textualData)
    {
      string[] separator = new string[1]{ "\r\n" };
      string[] strArray1 = textualData.Split(separator, StringSplitOptions.None);
      DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run();
      bool flag = true;
      string[] strArray2 = strArray1;
      int index = 0;
      while (index < strArray2.Length)
      {
        string str = strArray2[index];
        if (!flag)
          run.Append((OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Break());
        flag = false;
        DocumentFormat.OpenXml.Wordprocessing.Text text = new DocumentFormat.OpenXml.Wordprocessing.Text();
        text.Text = str;
        run.Append((OpenXmlElement) text);
        checked { ++index; }
      }
      return run;
    }

    public static void ReplaceText(WordprocessingDocument doc, string textRef, string text)
    {
      text = PrintHelper.RemoveSpecialCharacters(Helper.MakeStringValid((object) text));
      DocumentFormat.OpenXml.Wordprocessing.Document document = doc.MainDocumentPart.Document;
      try
      {
        foreach (DocumentFormat.OpenXml.Wordprocessing.Text descendant in document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>())
        {
          if (descendant.Text.Contains(textRef))
            descendant.Text = descendant.Text.Replace(textRef, text);
        }
      }
      finally
      {
        IEnumerator<DocumentFormat.OpenXml.Wordprocessing.Text> enumerator;
        enumerator?.Dispose();
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
      // ISSUE: variable of a compiler-generated type
      PrintHelper._Closure\u0024__4\u002D0 closure40;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      IEnumerable<BookmarkStart> source = doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>().Where<BookmarkStart>(new Func<BookmarkStart, bool>(new PrintHelper._Closure\u0024__4\u002D0(closure40)
      {
        \u0024VB\u0024Local_bookmark = bookmark
      }._Lambda\u0024__0));
      Func<BookmarkStart, BookmarkStart> selector;
      // ISSUE: reference to a compiler-generated field
      if (PrintHelper._Closure\u0024__.\u0024I4\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = PrintHelper._Closure\u0024__.\u0024I4\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        PrintHelper._Closure\u0024__.\u0024I4\u002D1 = selector = (Func<BookmarkStart, BookmarkStart>) (el => el);
      }
      BookmarkStart bookmarkStart = source.Select<BookmarkStart, BookmarkStart>(selector).FirstOrDefault<BookmarkStart>();
      if (bookmarkStart == null)
        return;
      OpenXmlElement openXmlElement1;
      for (OpenXmlElement openXmlElement2 = bookmarkStart.NextSibling(); openXmlElement2 != null & !(openXmlElement2 is BookmarkEnd); openXmlElement2 = openXmlElement1)
      {
        openXmlElement1 = openXmlElement2.NextSibling();
        openXmlElement2.Remove();
      }
      DocumentFormat.OpenXml.Wordprocessing.Paragraph parent = (DocumentFormat.OpenXml.Wordprocessing.Paragraph) bookmarkStart.Parent;
      if (parent != null)
      {
        parent.RemoveAllChildren();
        parent.Remove();
      }
    }

    public static void DeleteTableBookmark(WordprocessingDocument doc, string bookmark)
    {
      IEnumerable<DocumentFormat.OpenXml.Wordprocessing.Table> source = doc.MainDocumentPart.RootElement.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>().Where<DocumentFormat.OpenXml.Wordprocessing.Table>((Func<DocumentFormat.OpenXml.Wordprocessing.Table, bool>) (el => el.InnerText.ToLower().Contains(bookmark.ToLower())));
      Func<DocumentFormat.OpenXml.Wordprocessing.Table, DocumentFormat.OpenXml.Wordprocessing.Table> selector;
      // ISSUE: reference to a compiler-generated field
      if (PrintHelper._Closure\u0024__.\u0024I5\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = PrintHelper._Closure\u0024__.\u0024I5\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        PrintHelper._Closure\u0024__.\u0024I5\u002D1 = selector = (Func<DocumentFormat.OpenXml.Wordprocessing.Table, DocumentFormat.OpenXml.Wordprocessing.Table>) (el => el);
      }
      DocumentFormat.OpenXml.Wordprocessing.Table table = source.Select<DocumentFormat.OpenXml.Wordprocessing.Table, DocumentFormat.OpenXml.Wordprocessing.Table>(selector).FirstOrDefault<DocumentFormat.OpenXml.Wordprocessing.Table>();
      if (table == null)
        return;
      table.RemoveAllChildren();
      table.Remove();
    }

    public static void ReplaceGSRBookmark(
      WordprocessingDocument doc,
      string bookmark,
      string text,
      string fontSize = "7",
      bool bold = false)
    {
      // ISSUE: variable of a compiler-generated type
      PrintHelper._Closure\u0024__6\u002D0 closure60;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      IEnumerable<BookmarkStart> source = doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>().Where<BookmarkStart>(new Func<BookmarkStart, bool>(new PrintHelper._Closure\u0024__6\u002D0(closure60)
      {
        \u0024VB\u0024Local_bookmark = bookmark
      }._Lambda\u0024__0));
      Func<BookmarkStart, BookmarkStart> selector;
      // ISSUE: reference to a compiler-generated field
      if (PrintHelper._Closure\u0024__.\u0024I6\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = PrintHelper._Closure\u0024__.\u0024I6\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        PrintHelper._Closure\u0024__.\u0024I6\u002D1 = selector = (Func<BookmarkStart, BookmarkStart>) (el => el);
      }
      BookmarkStart bookmarkStart = source.Select<BookmarkStart, BookmarkStart>(selector).FirstOrDefault<BookmarkStart>();
      if (bookmarkStart == null)
        return;
      OpenXmlElement openXmlElement1;
      for (OpenXmlElement openXmlElement2 = bookmarkStart.NextSibling(); openXmlElement2 != null & !(openXmlElement2 is BookmarkEnd); openXmlElement2 = openXmlElement1)
      {
        openXmlElement1 = openXmlElement2.NextSibling();
        openXmlElement2.Remove();
      }
      int num = checked (Helper.MakeIntegerValid((object) fontSize) * 2);
      DocumentFormat.OpenXml.Wordprocessing.RunProperties newChild1 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new OpenXmlElement[1]
      {
        (OpenXmlElement) new SpacingBetweenLines()
        {
          Before = (StringValue) "0",
          After = (StringValue) "0"
        }
      });
      RunFonts runFonts = new RunFonts()
      {
        Ascii = (StringValue) "Arial"
      };
      FontSize fontSize1 = new FontSize();
      fontSize1.Val = new StringValue(num.ToString());
      FontSize fontSize2 = fontSize1;
      Bold bold1 = new Bold();
      bold1.Val = (OnOffValue) bold;
      Bold bold2 = bold1;
      newChild1.Append((OpenXmlElement) runFonts);
      newChild1.Append((OpenXmlElement) fontSize2);
      newChild1.Append((OpenXmlElement) bold2);
      DocumentFormat.OpenXml.Wordprocessing.Run newChild2 = new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
      {
        (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Text(text.Trim())
      });
      newChild2.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(newChild1);
      bookmarkStart.Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(newChild2, (OpenXmlElement) bookmarkStart);
    }

    public static void ReplaceBookmarkWithImage(
      WordprocessingDocument doc,
      string bookmark,
      Bitmap img,
      string savePath,
      int index,
      bool centreAlign = false)
    {
      // ISSUE: variable of a compiler-generated type
      PrintHelper._Closure\u0024__7\u002D0 closure70;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      IEnumerable<BookmarkStart> source = doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>().Where<BookmarkStart>(new Func<BookmarkStart, bool>(new PrintHelper._Closure\u0024__7\u002D0(closure70)
      {
        \u0024VB\u0024Local_bookmark = bookmark
      }._Lambda\u0024__0));
      Func<BookmarkStart, BookmarkStart> selector;
      // ISSUE: reference to a compiler-generated field
      if (PrintHelper._Closure\u0024__.\u0024I7\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = PrintHelper._Closure\u0024__.\u0024I7\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        PrintHelper._Closure\u0024__.\u0024I7\u002D1 = selector = (Func<BookmarkStart, BookmarkStart>) (el => el);
      }
      BookmarkStart bookmarkStart = source.Select<BookmarkStart, BookmarkStart>(selector).FirstOrDefault<BookmarkStart>();
      if (bookmarkStart == null)
        return;
      OpenXmlElement openXmlElement1;
      for (OpenXmlElement openXmlElement2 = bookmarkStart.NextSibling(); openXmlElement2 != null & !(openXmlElement2 is BookmarkEnd); openXmlElement2 = openXmlElement1)
      {
        openXmlElement1 = openXmlElement2.NextSibling();
        openXmlElement2.Remove();
      }
      int width = img.Width;
      int height = img.Height;
      img.Save(savePath, ImageFormat.Jpeg);
      ImageHelper.ImageDetails image = new ImageHelper.ImageDetails(savePath);
      ImagePart imagePart = doc.MainDocumentPart.AddImagePart(ImagePartType.Jpeg);
      using (FileStream fileStream = new FileStream(savePath, FileMode.Open))
        imagePart.FeedData((Stream) fileStream);
      OpenXmlElement parent1 = bookmarkStart.Parent;
      while (!(parent1?.Parent is DocumentFormat.OpenXml.Wordprocessing.TableCell) && parent1 != null)
        parent1 = parent1.Parent;
      if (parent1 == null)
        return;
      DocumentFormat.OpenXml.Wordprocessing.TableCell parent2 = (DocumentFormat.OpenXml.Wordprocessing.TableCell) parent1.Parent;
      int targetWidth = checked ((int) Math.Round(unchecked ((double) Conversions.ToInteger((string) parent2.GetFirstChild<DocumentFormat.OpenXml.Wordprocessing.TableCellProperties>().GetFirstChild<TableCellWidth>().Width) / 21.0)));
      image.ResizeImage(targetWidth);
      PrintHelper.AddImageToCell(doc.MainDocumentPart.GetIdOfPart((OpenXmlPart) imagePart), parent2, index, image, centreAlign);
    }

    private static void AddImageToCell(
      string relationshipId,
      DocumentFormat.OpenXml.Wordprocessing.TableCell cell,
      int index,
      ImageHelper.ImageDetails image,
      bool centreAlign)
    {
      OpenXmlElement[] openXmlElementArray1 = new OpenXmlElement[1];
      OpenXmlElement[] openXmlElementArray2 = new OpenXmlElement[5]
      {
        (OpenXmlElement) new Extent()
        {
          Cx = (Int64Value) image.cx,
          Cy = (Int64Value) image.cy
        },
        (OpenXmlElement) new EffectExtent()
        {
          LeftEdge = (Int64Value) 0L,
          TopEdge = (Int64Value) 0L,
          RightEdge = (Int64Value) 0L,
          BottomEdge = (Int64Value) 0L
        },
        (OpenXmlElement) new DocProperties()
        {
          Id = (UInt32Value) checked ((uint) ((long) index + 1L)),
          Name = (StringValue) ("Picture " + Conversions.ToString(index) + DateTime.Now.ToString("HHmmssfff"))
        },
        (OpenXmlElement) new DocumentFormat.OpenXml.Drawing.Wordprocessing.NonVisualGraphicFrameDrawingProperties(new OpenXmlElement[1]
        {
          (OpenXmlElement) new GraphicFrameLocks()
          {
            NoChangeAspect = (BooleanValue) true
          }
        }),
        null
      };
      OpenXmlElement[] openXmlElementArray3 = new OpenXmlElement[1];
      OpenXmlElement[] openXmlElementArray4 = new OpenXmlElement[1];
      OpenXmlElement[] openXmlElementArray5 = new OpenXmlElement[3]
      {
        (OpenXmlElement) new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(new OpenXmlElement[2]
        {
          (OpenXmlElement) new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties()
          {
            Id = (UInt32Value) checked ((uint) ((long) index + 0L)),
            Name = (StringValue) ("New Bitmap Image" + Conversions.ToString(index) + DateTime.Now.ToString("HHmmssfff") + ".jpg")
          },
          (OpenXmlElement) new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties()
        }),
        (OpenXmlElement) new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(new OpenXmlElement[2]
        {
          (OpenXmlElement) new Blip(new OpenXmlElement[1]
          {
            (OpenXmlElement) new BlipExtensionList(new OpenXmlElement[1]
            {
              (OpenXmlElement) new BlipExtension()
              {
                Uri = (StringValue) "{28A0092B-C50C-407E-A947-70E740481C1C}"
              }
            })
          })
          {
            Embed = (StringValue) relationshipId,
            CompressionState = (EnumValue<BlipCompressionValues>) BlipCompressionValues.Print
          },
          (OpenXmlElement) new Stretch(new OpenXmlElement[1]
          {
            (OpenXmlElement) new FillRectangle()
          })
        }),
        null
      };
      OpenXmlElement[] openXmlElementArray6 = new OpenXmlElement[2];
      OpenXmlElement[] openXmlElementArray7 = new OpenXmlElement[2];
      DocumentFormat.OpenXml.Drawing.Offset offset = new DocumentFormat.OpenXml.Drawing.Offset();
      offset.X = (Int64Value) 0L;
      offset.Y = (Int64Value) 0L;
      openXmlElementArray7[0] = (OpenXmlElement) offset;
      Extents extents = new Extents();
      extents.Cx = (Int64Value) image.cx;
      extents.Cy = (Int64Value) image.cy;
      openXmlElementArray7[1] = (OpenXmlElement) extents;
      openXmlElementArray6[0] = (OpenXmlElement) new Transform2D(openXmlElementArray7);
      openXmlElementArray6[1] = (OpenXmlElement) new PresetGeometry(new OpenXmlElement[1]
      {
        (OpenXmlElement) new AdjustValueList()
      })
      {
        Preset = (EnumValue<ShapeTypeValues>) ShapeTypeValues.Rectangle
      };
      openXmlElementArray5[2] = (OpenXmlElement) new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(openXmlElementArray6);
      openXmlElementArray4[0] = (OpenXmlElement) new DocumentFormat.OpenXml.Drawing.Pictures.Picture(openXmlElementArray5);
      openXmlElementArray3[0] = (OpenXmlElement) new GraphicData(openXmlElementArray4)
      {
        Uri = (StringValue) "http://schemas.openxmlformats.org/drawingml/2006/picture"
      };
      openXmlElementArray2[4] = (OpenXmlElement) new Graphic(openXmlElementArray3);
      openXmlElementArray1[0] = (OpenXmlElement) new Inline(openXmlElementArray2)
      {
        DistanceFromTop = (UInt32Value) 0U,
        DistanceFromBottom = (UInt32Value) 0U,
        DistanceFromLeft = (UInt32Value) 0U,
        DistanceFromRight = (UInt32Value) 0U
      };
      OpenXmlElement openXmlElement = (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Drawing(openXmlElementArray1);
      DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties paragraphProperties = (DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties) null;
      if (centreAlign)
      {
        Justification justification = new Justification()
        {
          Val = (EnumValue<JustificationValues>) JustificationValues.Center
        };
        paragraphProperties = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
        paragraphProperties.Append((OpenXmlElement) justification);
      }
      DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph1 = cell.ChildElements.First<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
      if (paragraph1 != null)
      {
        paragraph1.RemoveAllChildren();
        paragraph1.Remove();
      }
      if (paragraphProperties != null)
      {
        DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph2 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
        {
          (OpenXmlElement) paragraphProperties
        });
        paragraph2.Append((OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
        {
          openXmlElement
        }));
        cell.Append((OpenXmlElement) paragraph2);
      }
      else
        cell.Append((OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
        {
          (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
          {
            openXmlElement
          })
        }));
    }

    public static void ReplaceBookmarkWithTable(
      WordprocessingDocument doc,
      string bookmark,
      DataTable dt,
      bool displayBorderOutline = false)
    {
      // ISSUE: variable of a compiler-generated type
      PrintHelper._Closure\u0024__9\u002D0 closure90;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      IEnumerable<BookmarkStart> source = doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>().Where<BookmarkStart>(new Func<BookmarkStart, bool>(new PrintHelper._Closure\u0024__9\u002D0(closure90)
      {
        \u0024VB\u0024Local_bookmark = bookmark
      }._Lambda\u0024__0));
      Func<BookmarkStart, BookmarkStart> selector;
      // ISSUE: reference to a compiler-generated field
      if (PrintHelper._Closure\u0024__.\u0024I9\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = PrintHelper._Closure\u0024__.\u0024I9\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        PrintHelper._Closure\u0024__.\u0024I9\u002D1 = selector = (Func<BookmarkStart, BookmarkStart>) (el => el);
      }
      BookmarkStart bookmarkStart = source.Select<BookmarkStart, BookmarkStart>(selector).FirstOrDefault<BookmarkStart>();
      if (bookmarkStart == null)
        return;
      OpenXmlElement openXmlElement1;
      for (OpenXmlElement openXmlElement2 = bookmarkStart.NextSibling(); openXmlElement2 != null & !(openXmlElement2 is BookmarkEnd); openXmlElement2 = openXmlElement1)
      {
        openXmlElement1 = openXmlElement2.NextSibling();
        openXmlElement2.Remove();
      }
      DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();
      BorderValues borderValues = displayBorderOutline ? BorderValues.BasicThinLines : BorderValues.None;
      OpenXmlElement[] openXmlElementArray1 = new OpenXmlElement[1];
      OpenXmlElement[] openXmlElementArray2 = new OpenXmlElement[6];
      DocumentFormat.OpenXml.Wordprocessing.TopBorder topBorder = new DocumentFormat.OpenXml.Wordprocessing.TopBorder();
      topBorder.Val = new EnumValue<BorderValues>(borderValues);
      topBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[0] = (OpenXmlElement) topBorder;
      DocumentFormat.OpenXml.Wordprocessing.BottomBorder bottomBorder = new DocumentFormat.OpenXml.Wordprocessing.BottomBorder();
      bottomBorder.Val = new EnumValue<BorderValues>(borderValues);
      bottomBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[1] = (OpenXmlElement) bottomBorder;
      DocumentFormat.OpenXml.Wordprocessing.LeftBorder leftBorder = new DocumentFormat.OpenXml.Wordprocessing.LeftBorder();
      leftBorder.Val = new EnumValue<BorderValues>(borderValues);
      leftBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[2] = (OpenXmlElement) leftBorder;
      DocumentFormat.OpenXml.Wordprocessing.RightBorder rightBorder = new DocumentFormat.OpenXml.Wordprocessing.RightBorder();
      rightBorder.Val = new EnumValue<BorderValues>(borderValues);
      rightBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[3] = (OpenXmlElement) rightBorder;
      DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder horizontalBorder = new DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder();
      horizontalBorder.Val = new EnumValue<BorderValues>(borderValues);
      horizontalBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[4] = (OpenXmlElement) horizontalBorder;
      DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder insideVerticalBorder = new DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder();
      insideVerticalBorder.Val = new EnumValue<BorderValues>(borderValues);
      insideVerticalBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[5] = (OpenXmlElement) insideVerticalBorder;
      openXmlElementArray1[0] = (OpenXmlElement) new TableBorders(openXmlElementArray2);
      DocumentFormat.OpenXml.Wordprocessing.TableProperties newChild1 = new DocumentFormat.OpenXml.Wordprocessing.TableProperties(openXmlElementArray1);
      table.AppendChild<DocumentFormat.OpenXml.Wordprocessing.TableProperties>(newChild1);
      DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow1 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
      int num1 = checked (dt.Columns.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
        DocumentFormat.OpenXml.Wordprocessing.RunProperties newChild2 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
        RunFonts runFonts = new RunFonts()
        {
          Ascii = (StringValue) "Arial"
        };
        FontSize fontSize1 = new FontSize();
        fontSize1.Val = new StringValue("20");
        FontSize fontSize2 = fontSize1;
        Bold bold1 = new Bold();
        bold1.Val = OnOffValue.FromBoolean(true);
        Bold bold2 = bold1;
        newChild2.Append((OpenXmlElement) runFonts);
        newChild2.Append((OpenXmlElement) fontSize2);
        newChild2.Append((OpenXmlElement) bold2);
        DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
        {
          (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Text(dt.Columns[index1].ColumnName.ToString())
        });
        run.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(newChild2);
        tableCell1.Append((OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
        {
          (OpenXmlElement) run
        }));
        DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell2 = tableCell1;
        OpenXmlElement[] openXmlElementArray3 = new OpenXmlElement[1];
        OpenXmlElement[] openXmlElementArray4 = new OpenXmlElement[1];
        TableCellWidth tableCellWidth = new TableCellWidth();
        tableCellWidth.Width = (StringValue) "10000";
        openXmlElementArray4[0] = (OpenXmlElement) tableCellWidth;
        openXmlElementArray3[0] = (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(openXmlElementArray4);
        tableCell2.Append(openXmlElementArray3);
        tableRow1.Append((OpenXmlElement) tableCell1);
        checked { ++index1; }
      }
      table.Append((OpenXmlElement) tableRow1);
      int num2 = checked (dt.Rows.Count - 1);
      int index2 = 0;
      while (index2 <= num2)
      {
        DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow2 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
        int num3 = checked (dt.Columns.Count - 1);
        int index3 = 0;
        while (index3 <= num3)
        {
          DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
          DocumentFormat.OpenXml.Wordprocessing.RunProperties newChild2 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
          RunFonts runFonts = new RunFonts()
          {
            Ascii = (StringValue) "Arial"
          };
          FontSize fontSize1 = new FontSize();
          fontSize1.Val = new StringValue("20");
          FontSize fontSize2 = fontSize1;
          newChild2.Append((OpenXmlElement) runFonts);
          newChild2.Append((OpenXmlElement) fontSize2);
          DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
          {
            (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Text(dt.Rows[index2][index3].ToString())
          });
          run.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(newChild2);
          tableCell1.Append((OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
          {
            (OpenXmlElement) run
          }));
          DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell2 = tableCell1;
          OpenXmlElement[] openXmlElementArray3 = new OpenXmlElement[1];
          OpenXmlElement[] openXmlElementArray4 = new OpenXmlElement[1];
          TableCellWidth tableCellWidth = new TableCellWidth();
          tableCellWidth.Width = (StringValue) "10000";
          openXmlElementArray4[0] = (OpenXmlElement) tableCellWidth;
          openXmlElementArray3[0] = (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(openXmlElementArray4);
          tableCell2.Append(openXmlElementArray3);
          tableRow2.Append((OpenXmlElement) tableCell1);
          checked { ++index3; }
        }
        table.Append((OpenXmlElement) tableRow2);
        checked { ++index2; }
      }
      DocumentFormat.OpenXml.Wordprocessing.Run newChild3 = new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
      {
        (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Table(new OpenXmlElement[1]
        {
          (OpenXmlElement) table
        })
      });
      bookmarkStart.Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(newChild3, (OpenXmlElement) bookmarkStart);
    }

    public static void ReplaceBookmarkWithTable(
      WordprocessingDocument doc,
      string bookmark,
      DataTable dt,
      bool useColumnHeaders,
      Enums.TableCellProperties tableCellProperties)
    {
      // ISSUE: variable of a compiler-generated type
      PrintHelper._Closure\u0024__10\u002D0 closure100;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated method
      IEnumerable<BookmarkStart> source = doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>().Where<BookmarkStart>(new Func<BookmarkStart, bool>(new PrintHelper._Closure\u0024__10\u002D0(closure100)
      {
        \u0024VB\u0024Local_bookmark = bookmark
      }._Lambda\u0024__0));
      Func<BookmarkStart, BookmarkStart> selector;
      // ISSUE: reference to a compiler-generated field
      if (PrintHelper._Closure\u0024__.\u0024I10\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = PrintHelper._Closure\u0024__.\u0024I10\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        PrintHelper._Closure\u0024__.\u0024I10\u002D1 = selector = (Func<BookmarkStart, BookmarkStart>) (el => el);
      }
      BookmarkStart bookmarkStart = source.Select<BookmarkStart, BookmarkStart>(selector).FirstOrDefault<BookmarkStart>();
      if (bookmarkStart == null)
        return;
      OpenXmlElement openXmlElement1;
      for (OpenXmlElement openXmlElement2 = bookmarkStart.NextSibling(); openXmlElement2 != null & !(openXmlElement2 is BookmarkEnd); openXmlElement2 = openXmlElement1)
      {
        openXmlElement1 = openXmlElement2.NextSibling();
        openXmlElement2.Remove();
      }
      DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();
      OpenXmlElement[] openXmlElementArray1 = new OpenXmlElement[1];
      OpenXmlElement[] openXmlElementArray2 = new OpenXmlElement[6];
      DocumentFormat.OpenXml.Wordprocessing.TopBorder topBorder = new DocumentFormat.OpenXml.Wordprocessing.TopBorder();
      topBorder.Val = new EnumValue<BorderValues>(BorderValues.None);
      topBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[0] = (OpenXmlElement) topBorder;
      DocumentFormat.OpenXml.Wordprocessing.BottomBorder bottomBorder = new DocumentFormat.OpenXml.Wordprocessing.BottomBorder();
      bottomBorder.Val = new EnumValue<BorderValues>(BorderValues.None);
      bottomBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[1] = (OpenXmlElement) bottomBorder;
      DocumentFormat.OpenXml.Wordprocessing.LeftBorder leftBorder = new DocumentFormat.OpenXml.Wordprocessing.LeftBorder();
      leftBorder.Val = new EnumValue<BorderValues>(BorderValues.None);
      leftBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[2] = (OpenXmlElement) leftBorder;
      DocumentFormat.OpenXml.Wordprocessing.RightBorder rightBorder = new DocumentFormat.OpenXml.Wordprocessing.RightBorder();
      rightBorder.Val = new EnumValue<BorderValues>(BorderValues.None);
      rightBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[3] = (OpenXmlElement) rightBorder;
      DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder horizontalBorder = new DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder();
      horizontalBorder.Val = new EnumValue<BorderValues>(BorderValues.None);
      horizontalBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[4] = (OpenXmlElement) horizontalBorder;
      DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder insideVerticalBorder = new DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder();
      insideVerticalBorder.Val = new EnumValue<BorderValues>(BorderValues.None);
      insideVerticalBorder.Size = (UInt32Value) 10U;
      openXmlElementArray2[5] = (OpenXmlElement) insideVerticalBorder;
      openXmlElementArray1[0] = (OpenXmlElement) new TableBorders(openXmlElementArray2);
      DocumentFormat.OpenXml.Wordprocessing.TableProperties newChild1 = new DocumentFormat.OpenXml.Wordprocessing.TableProperties(openXmlElementArray1);
      table.AppendChild<DocumentFormat.OpenXml.Wordprocessing.TableProperties>(newChild1);
      if (useColumnHeaders)
      {
        DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
        int num = checked (dt.Columns.Count - 1);
        int index = 0;
        while (index <= num)
        {
          DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
          DocumentFormat.OpenXml.Wordprocessing.RunProperties newChild2 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
          RunFonts runFonts = new RunFonts()
          {
            Ascii = (StringValue) "Arial"
          };
          FontSize fontSize1 = new FontSize();
          fontSize1.Val = new StringValue("20");
          FontSize fontSize2 = fontSize1;
          Bold bold1 = new Bold();
          bold1.Val = OnOffValue.FromBoolean(true);
          Bold bold2 = bold1;
          newChild2.Append((OpenXmlElement) runFonts);
          newChild2.Append((OpenXmlElement) fontSize2);
          newChild2.Append((OpenXmlElement) bold2);
          DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
          {
            (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Text(dt.Columns[index].ColumnName.ToString())
          });
          run.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(newChild2);
          tableCell1.Append((OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[1]
          {
            (OpenXmlElement) run
          }));
          DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell2 = tableCell1;
          OpenXmlElement[] openXmlElementArray3 = new OpenXmlElement[1];
          OpenXmlElement[] openXmlElementArray4 = new OpenXmlElement[1];
          TableCellWidth tableCellWidth = new TableCellWidth();
          tableCellWidth.Width = (StringValue) "10000";
          openXmlElementArray4[0] = (OpenXmlElement) tableCellWidth;
          openXmlElementArray3[0] = (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(openXmlElementArray4);
          tableCell2.Append(openXmlElementArray3);
          tableRow.Append((OpenXmlElement) tableCell1);
          checked { ++index; }
        }
        table.Append((OpenXmlElement) tableRow);
      }
      int num1 = checked (dt.Rows.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
        int num2 = checked (dt.Columns.Count - 1);
        int columnCount = 0;
        while (columnCount <= num2)
        {
          Tuple<string, string, bool, string> cellProperties = PrintHelper.GetCellProperties(tableCellProperties, columnCount, false);
          DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
          DocumentFormat.OpenXml.Wordprocessing.RunProperties newChild2 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
          RunFonts runFonts = new RunFonts()
          {
            Ascii = (StringValue) cellProperties.Item1
          };
          FontSize fontSize1 = new FontSize();
          fontSize1.Val = new StringValue(cellProperties.Item2);
          FontSize fontSize2 = fontSize1;
          Bold bold1 = new Bold();
          bold1.Val = OnOffValue.FromBoolean(cellProperties.Item3);
          Bold bold2 = bold1;
          newChild2.Append((OpenXmlElement) runFonts);
          newChild2.Append((OpenXmlElement) fontSize2);
          newChild2.Append((OpenXmlElement) bold2);
          DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
          {
            (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Text(dt.Rows[index1][columnCount].ToString())
          });
          run.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(newChild2);
          tableCell1.Append((OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[2]
          {
            (OpenXmlElement) run,
            (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
            {
              (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Break()
            })
          }));
          DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell2 = tableCell1;
          OpenXmlElement[] openXmlElementArray3 = new OpenXmlElement[1];
          OpenXmlElement[] openXmlElementArray4 = new OpenXmlElement[1];
          TableCellWidth tableCellWidth = new TableCellWidth();
          tableCellWidth.Width = (StringValue) cellProperties.Item4;
          openXmlElementArray4[0] = (OpenXmlElement) tableCellWidth;
          openXmlElementArray3[0] = (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(openXmlElementArray4);
          tableCell2.Append(openXmlElementArray3);
          tableRow.Append((OpenXmlElement) tableCell1);
          checked { ++columnCount; }
        }
        table.Append((OpenXmlElement) tableRow);
        checked { ++index1; }
      }
      DocumentFormat.OpenXml.Wordprocessing.Run newChild3 = new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
      {
        (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Table(new OpenXmlElement[1]
        {
          (OpenXmlElement) table
        })
      });
      bookmarkStart.Parent.InsertAfter<DocumentFormat.OpenXml.Wordprocessing.Run>(newChild3, (OpenXmlElement) bookmarkStart);
    }

    public static void AddRowsToTable(
      WordprocessingDocument doc,
      string tableRef,
      DataTable dt,
      string font = "",
      string fontSize = "",
      int postion = 0)
    {
      // ISSUE: variable of a compiler-generated type
      PrintHelper._Closure\u0024__11\u002D0 closure110_1;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      PrintHelper._Closure\u0024__11\u002D0 closure110_2 = new PrintHelper._Closure\u0024__11\u002D0(closure110_1);
      // ISSUE: reference to a compiler-generated field
      closure110_2.\u0024VB\u0024Local_tableRef = tableRef;
      Body body = doc.MainDocumentPart.Document.Body;
      // ISSUE: reference to a compiler-generated method
      IEnumerable<DocumentFormat.OpenXml.Wordprocessing.Table> source = doc.MainDocumentPart.RootElement.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>().Where<DocumentFormat.OpenXml.Wordprocessing.Table>(new Func<DocumentFormat.OpenXml.Wordprocessing.Table, bool>(closure110_2._Lambda\u0024__0));
      Func<DocumentFormat.OpenXml.Wordprocessing.Table, DocumentFormat.OpenXml.Wordprocessing.Table> selector;
      // ISSUE: reference to a compiler-generated field
      if (PrintHelper._Closure\u0024__.\u0024I11\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = PrintHelper._Closure\u0024__.\u0024I11\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        PrintHelper._Closure\u0024__.\u0024I11\u002D1 = selector = (Func<DocumentFormat.OpenXml.Wordprocessing.Table, DocumentFormat.OpenXml.Wordprocessing.Table>) (el => el);
      }
      List<DocumentFormat.OpenXml.Wordprocessing.Table> list = source.Select<DocumentFormat.OpenXml.Wordprocessing.Table, DocumentFormat.OpenXml.Wordprocessing.Table>(selector).ToList<DocumentFormat.OpenXml.Wordprocessing.Table>();
      DocumentFormat.OpenXml.Wordprocessing.Table table = postion == 0 ? list.FirstOrDefault<DocumentFormat.OpenXml.Wordprocessing.Table>() : list[postion];
      if (table == null)
        return;
      int num1 = checked (dt.Rows.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
        int num2 = checked (dt.Columns.Count - 1);
        int index2 = 0;
        while (index2 <= num2)
        {
          DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
          DocumentFormat.OpenXml.Wordprocessing.RunProperties newChild = (DocumentFormat.OpenXml.Wordprocessing.RunProperties) null;
          if (!Helper.IsStringEmpty((object) font))
          {
            newChild = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
            RunFonts runFonts = new RunFonts()
            {
              Ascii = (StringValue) font
            };
            newChild.Append((OpenXmlElement) runFonts);
            if (!string.IsNullOrEmpty(fontSize))
            {
              DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties = newChild;
              OpenXmlElement[] openXmlElementArray = new OpenXmlElement[1];
              FontSize fontSize1 = new FontSize();
              fontSize1.Val = new StringValue(fontSize);
              openXmlElementArray[0] = (OpenXmlElement) fontSize1;
              runProperties.Append(openXmlElementArray);
            }
          }
          DocumentFormat.OpenXml.Wordprocessing.Run text = PrintHelper.ParseText(dt.Rows[index1][index2].ToString());
          if (newChild != null)
            text.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(newChild);
          tableCell.Append((OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new OpenXmlElement[2]
          {
            (OpenXmlElement) text,
            (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Run(new OpenXmlElement[1]
            {
              (OpenXmlElement) new DocumentFormat.OpenXml.Wordprocessing.Break()
            })
          }));
          tableRow.Append((OpenXmlElement) tableCell);
          checked { ++index2; }
        }
        table.Append((OpenXmlElement) tableRow);
        checked { ++index1; }
      }
    }

    private static Tuple<string, string, bool, string> GetCellProperties(
      Enums.TableCellProperties tcp,
      int columnCount,
      bool header)
    {
      string str1 = "Arial";
      string str2 = "20";
      bool flag = false;
      string str3 = "10000";
      if (tcp == Enums.TableCellProperties.ContractAppliance)
      {
        switch (columnCount)
        {
          case 0:
            str3 = "3300";
            break;
          case 1:
            str2 = "22";
            flag = true;
            break;
        }
      }
      return Tuple.Create<string, string, bool, string>(str1, str2, flag, str3);
    }

    public static byte[] CombineDocs(List<MemoryStream> docs)
    {
      List<Source> sources = new List<Source>();
      try
      {
        foreach (MemoryStream doc in docs)
          sources.Add(new Source(new WmlDocument(doc.Length.ToString(), doc), true));
      }
      finally
      {
        List<MemoryStream>.Enumerator enumerator;
        enumerator.Dispose();
      }
      return DocumentBuilder.BuildDocument(sources).DocumentByteArray;
    }

    public static byte[] CombineDocs(List<byte[]> docs)
    {
      List<Source> sources = new List<Source>();
      try
      {
        foreach (byte[] doc in docs)
          sources.Add(new Source(new WmlDocument(doc.Length.ToString(), doc), true));
      }
      finally
      {
        List<byte[]>.Enumerator enumerator;
        enumerator.Dispose();
      }
      return DocumentBuilder.BuildDocument(sources).DocumentByteArray;
    }

    public static string ToPdf(string filePath, bool openFile = false, bool deleteFile = false)
    {
      string str1;
      try
      {
        // ISSUE: variable of a compiler-generated type
        Application instance = (Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
        instance.Visible = false;
        // ISSUE: variable of a compiler-generated type
        Documents documents = instance.Documents;
        object obj1 = (object) filePath;
        ref object local1 = ref obj1;
        object objectValue1 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local2 = ref objectValue1;
        object objectValue2 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local3 = ref objectValue2;
        object objectValue3 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local4 = ref objectValue3;
        object objectValue4 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local5 = ref objectValue4;
        object objectValue5 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local6 = ref objectValue5;
        object objectValue6 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local7 = ref objectValue6;
        object objectValue7 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local8 = ref objectValue7;
        object objectValue8 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local9 = ref objectValue8;
        object objectValue9 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local10 = ref objectValue9;
        object objectValue10 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local11 = ref objectValue10;
        object objectValue11 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local12 = ref objectValue11;
        object objectValue12 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local13 = ref objectValue12;
        object objectValue13 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local14 = ref objectValue13;
        object objectValue14 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local15 = ref objectValue14;
        object objectValue15 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local16 = ref objectValue15;
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Document document1 = documents.Open(ref local1, ref local2, ref local3, ref local4, ref local5, ref local6, ref local7, ref local8, ref local9, ref local10, ref local11, ref local12, ref local13, ref local14, ref local15, ref local16);
        string str2 = System.IO.Path.ChangeExtension(filePath, ".pdf");
        // ISSUE: reference to a compiler-generated method
        document1.Activate();
        try
        {
          document1.PageSetup.LeftMargin = (float) PrintHelper.CentimetersToPoints(1.8);
          document1.PageSetup.RightMargin = (float) PrintHelper.CentimetersToPoints(2.31);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          ProjectData.ClearProjectError();
        }
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Document document2 = document1;
        object obj2 = (object) str2;
        ref object local17 = ref obj2;
        object obj3 = (object) WdSaveFormat.wdFormatPDF;
        ref object local18 = ref obj3;
        object objectValue16 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local19 = ref objectValue16;
        object objectValue17 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local20 = ref objectValue17;
        object objectValue18 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local21 = ref objectValue18;
        object objectValue19 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local22 = ref objectValue19;
        object objectValue20 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local23 = ref objectValue20;
        object objectValue21 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local24 = ref objectValue21;
        object objectValue22 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local25 = ref objectValue22;
        object objectValue23 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local26 = ref objectValue23;
        object objectValue24 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local27 = ref objectValue24;
        object objectValue25 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local28 = ref objectValue25;
        object objectValue26 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local29 = ref objectValue26;
        object objectValue27 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local30 = ref objectValue27;
        object objectValue28 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local31 = ref objectValue28;
        object objectValue29 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local32 = ref objectValue29;
        object objectValue30 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local33 = ref objectValue30;
        // ISSUE: reference to a compiler-generated method
        document2.SaveAs2(ref local17, ref local18, ref local19, ref local20, ref local21, ref local22, ref local23, ref local24, ref local25, ref local26, ref local27, ref local28, ref local29, ref local30, ref local31, ref local32, ref local33);
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Word.Document document3 = document1;
        objectValue30 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local34 = ref objectValue30;
        object objectValue31 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local35 = ref objectValue31;
        object objectValue32 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local36 = ref objectValue32;
        // ISSUE: reference to a compiler-generated method
        document3.Close(ref local34, ref local35, ref local36);
        // ISSUE: variable of a compiler-generated type
        Application application = instance;
        object objectValue33 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local37 = ref objectValue33;
        object objectValue34 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local38 = ref objectValue34;
        object objectValue35 = RuntimeHelpers.GetObjectValue((object) Missing.Value);
        ref object local39 = ref objectValue35;
        // ISSUE: reference to a compiler-generated method
        application.Quit(ref local37, ref local38, ref local39);
        str1 = str2;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        str1 = filePath;
        ProjectData.ClearProjectError();
      }
      return str1;
    }

    public static string LockFile(string filePath, bool deleteFile = false)
    {
      string extension = System.IO.Path.GetExtension(filePath);
      string str;
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(extension, ".docx", false) > 0U)
      {
        str = Conversions.ToString(false);
      }
      else
      {
        try
        {
          string randomPassword = Helper.CreateRandomPassword(8);
          string filename = filePath.Replace(extension, "_Protected" + extension);
          using (DocX docX = DocX.Load(filePath))
          {
            EditRestrictions editRestrictions = EditRestrictions.readOnly;
            docX.AddPasswordProtection(editRestrictions, randomPassword);
            docX.SaveAs(filename);
          }
          if (deleteFile)
            File.Delete(filePath);
          str = filename;
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          str = filePath;
          ProjectData.ClearProjectError();
        }
      }
      return str;
    }

    public static void RemoveSpacingInDoc(string filePath)
    {
      byte[] buffer = File.ReadAllBytes(filePath);
      MemoryStream memoryStream = new MemoryStream();
      using (memoryStream)
      {
        memoryStream.Write(buffer, 0, buffer.Length);
        WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Open((Stream) memoryStream, true);
        using (wordprocessingDocument)
        {
          IEnumerable<DocumentFormat.OpenXml.Wordprocessing.Paragraph> source = wordprocessingDocument.MainDocumentPart.Document.Body.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
          Func<DocumentFormat.OpenXml.Wordprocessing.Paragraph, DocumentFormat.OpenXml.Wordprocessing.Paragraph> selector;
          // ISSUE: reference to a compiler-generated field
          if (PrintHelper._Closure\u0024__.\u0024I17\u002D0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            selector = PrintHelper._Closure\u0024__.\u0024I17\u002D0;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            PrintHelper._Closure\u0024__.\u0024I17\u002D0 = selector = (Func<DocumentFormat.OpenXml.Wordprocessing.Paragraph, DocumentFormat.OpenXml.Wordprocessing.Paragraph>) (el => el);
          }
          List<DocumentFormat.OpenXml.Wordprocessing.Paragraph> list1 = source.Select<DocumentFormat.OpenXml.Wordprocessing.Paragraph, DocumentFormat.OpenXml.Wordprocessing.Paragraph>(selector).ToList<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
          try
          {
            foreach (DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph in list1)
            {
              List<DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties> list2 = paragraph.Elements<DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties>().ToList<DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties>();
              try
              {
                foreach (DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties paragraphProperties1 in list2)
                {
                  paragraphProperties1.SpacingBetweenLines = new SpacingBetweenLines()
                  {
                    Before = (StringValue) "0",
                    After = (StringValue) "0",
                    LineRule = (EnumValue<LineSpacingRuleValues>) LineSpacingRuleValues.Auto
                  };
                  DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties paragraphProperties2 = paragraphProperties1;
                  ParagraphStyleId paragraphStyleId = new ParagraphStyleId();
                  paragraphStyleId.Val = (StringValue) "No Spacing";
                  paragraphProperties2.ParagraphStyleId = paragraphStyleId;
                }
              }
              finally
              {
                List<DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties>.Enumerator enumerator;
                enumerator.Dispose();
              }
              List<DocumentFormat.OpenXml.Wordprocessing.Run> list3 = paragraph.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>().ToList<DocumentFormat.OpenXml.Wordprocessing.Run>();
              try
              {
                foreach (OpenXmlElement openXmlElement in list3)
                {
                  List<DocumentFormat.OpenXml.Wordprocessing.RunProperties> list4 = openXmlElement.Elements<DocumentFormat.OpenXml.Wordprocessing.RunProperties>().ToList<DocumentFormat.OpenXml.Wordprocessing.RunProperties>();
                  try
                  {
                    foreach (DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties in list4)
                      runProperties.Spacing = new Spacing()
                      {
                        Val = (Int32Value) Conversions.ToInteger("0")
                      };
                  }
                  finally
                  {
                    List<DocumentFormat.OpenXml.Wordprocessing.RunProperties>.Enumerator enumerator;
                    enumerator.Dispose();
                  }
                }
              }
              finally
              {
                List<DocumentFormat.OpenXml.Wordprocessing.Run>.Enumerator enumerator;
                enumerator.Dispose();
              }
            }
          }
          finally
          {
            List<DocumentFormat.OpenXml.Wordprocessing.Paragraph>.Enumerator enumerator;
            enumerator.Dispose();
          }
          wordprocessingDocument.MainDocumentPart.Document.Save();
        }
        filePath = PrintHelper.FileCheck(filePath);
        FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        memoryStream.Position = 0L;
        using (fileStream)
          memoryStream.WriteTo((Stream) fileStream);
      }
    }

    private static string FileCheck(string filePath)
    {
      try
      {
        if (File.Exists(filePath))
          File.Delete(filePath);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        string extension = System.IO.Path.GetExtension(filePath);
        filePath = filePath.Replace(extension, "_New" + extension);
        ProjectData.ClearProjectError();
      }
      return filePath;
    }

    private static double CentimetersToPoints(double cm)
    {
      return cm * 28.34;
    }
  }
}
