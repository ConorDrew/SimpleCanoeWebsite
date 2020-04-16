// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.PdfFactory
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using Microsoft.VisualBasic.CompilerServices;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FSM.Entity.Sys
{
  public class PdfFactory
  {
    public static void GenerateSiteHistoryReport(Site site)
    {
      if (site == null)
        return;
      DataView siteHistory = App.DB.EngineerVisits.Get_SiteHistory(site.SiteID);
      if (siteHistory.Count == 0)
        return;
      Document document = new Document();
      document.Info.Title = "Site History Report";
      document.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(1.5);
      document.DefaultPageSetup.RightMargin = Unit.FromCentimeter(1.5);
      document.DefaultPageSetup.TopMargin = Unit.FromCentimeter(1.0);
      document.DefaultPageSetup.BottomMargin = Unit.FromCentimeter(1.0);
      Paragraph paragraph1 = document.AddSection().AddParagraph();
      paragraph1.AddFormattedText("Site History Report", TextFormat.Bold).Size = (Unit) 18;
      paragraph1.AddLineBreak();
      paragraph1.AddLineBreak();
      paragraph1.AddFormattedText(site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode((object) site.Postcode)).Size = (Unit) 12;
      paragraph1.AddLineBreak();
      paragraph1.AddLineBreak();
      Table table = document.LastSection.AddTable();
      table.Borders.Visible = false;
      table.TopPadding = (Unit) 5;
      table.BottomPadding = (Unit) 5;
      table.AddColumn(Unit.FromCentimeter(4.0)).Format.Alignment = ParagraphAlignment.Left;
      table.AddColumn(Unit.FromCentimeter(7.0)).Format.Alignment = ParagraphAlignment.Left;
      table.AddColumn(Unit.FromCentimeter(7.0)).Format.Alignment = ParagraphAlignment.Left;
      IEnumerator enumerator;
      try
      {
        enumerator = siteHistory.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          Row row1 = table.AddRow();
          Paragraph paragraph2 = row1.Cells[0].AddParagraph();
          row1.Cells[0].MergeRight = 2;
          paragraph2.AddFormattedText(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["VisitDate"])).ToLongDateString() + " - " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["JobType"])), TextFormat.Bold).Size = (Unit) 11;
          row1.Borders.Bottom.Width = (Unit) 1;
          row1.Borders.Bottom.Color = Colors.Black;
          Row row2 = table.AddRow();
          Paragraph paragraph3 = row2.Cells[0].AddParagraph();
          paragraph3.AddFormattedText("Job Number: ", TextFormat.Bold).Size = (Unit) 9;
          paragraph3.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["JobNumber"]))).Size = (Unit) 9;
          paragraph3.AddLineBreak();
          paragraph3.AddFormattedText("Engineer: ", TextFormat.Bold).Size = (Unit) 9;
          paragraph3.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Engineer"]))).Size = (Unit) 9;
          paragraph3.AddLineBreak();
          paragraph3.AddFormattedText("Outcome: ", TextFormat.Bold).Size = (Unit) 9;
          paragraph3.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Outcome"]))).Size = (Unit) 9;
          Paragraph paragraph4 = row2.Cells[1].AddParagraph();
          paragraph4.AddFormattedText("Job Notes: ", TextFormat.Bold).Size = (Unit) 9;
          paragraph4.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["JobNotes"]))).Size = (Unit) 9;
          Paragraph paragraph5 = row2.Cells[2].AddParagraph();
          paragraph5.AddFormattedText("Outcome Details: ", TextFormat.Bold).Size = (Unit) 9;
          paragraph5.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["OutcomeDetails"]))).Size = (Unit) 9;
          table.AddRow();
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      DdlWriter.WriteToFile((DocumentObject) document, "MigraDoc.mdddl");
      PdfDocumentRenderer documentRenderer = new PdfDocumentRenderer(true);
      documentRenderer.Document = document;
      documentRenderer.RenderDocument();
      string str = "SiteHistoryReport.pdf";
      documentRenderer.PdfDocument.Save(str);
      Process.Start(str);
    }

    public static void GenerateJobCostings(Job job)
    {
      if (job == null)
        return;
      Site site = App.DB.Sites.Get((object) job.JobID, SiteSQL.GetBy.JobId, (object) null);
      if (site == null)
        return;
      Document doc = new Document();
      doc.Info.Title = "Job Costing Report";
      doc.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(1.5);
      doc.DefaultPageSetup.RightMargin = Unit.FromCentimeter(1.5);
      doc.DefaultPageSetup.TopMargin = Unit.FromCentimeter(1.0);
      doc.DefaultPageSetup.BottomMargin = Unit.FromCentimeter(1.0);
      Section section = doc.AddSection();
      Paragraph paragraph1 = section.AddParagraph();
      paragraph1.AddDateField("dd/MM/yyyy");
      paragraph1.Format.Alignment = ParagraphAlignment.Right;
      Paragraph paragraph2 = section.AddParagraph();
      paragraph2.Format.Alignment = ParagraphAlignment.Left;
      paragraph2.AddFormattedText("Job Costing", TextFormat.Bold).Size = (Unit) 18;
      paragraph2.Format.SpaceAfter = (Unit) "2.5mm";
      Paragraph paragraph3 = section.AddParagraph();
      paragraph3.Format.SpaceBefore = (Unit) "2.5mm";
      paragraph3.AddFormattedText(job.JobNumber + ": ", TextFormat.Bold).Size = (Unit) 14;
      paragraph3.AddFormattedText(site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode((object) site.Postcode)).Size = (Unit) 12;
      paragraph3.Format.SpaceAfter = (Unit) "2.5mm";
      double jobCost1 = PdfFactory.AddPartsToJobCost(job, doc);
      double jobCost2 = PdfFactory.AddLabourToJobCost(job, doc);
      if (jobCost2 + jobCost1 == 0.0)
        return;
      section.AddParagraph();
      Table table = doc.LastSection.AddTable();
      table.Borders.Width = (Unit) 0.25;
      table.Borders.Left.Width = (Unit) 0;
      table.Borders.Right.Width = (Unit) 0;
      table.Rows.LeftIndent = (Unit) 0;
      table.TopPadding = (Unit) 2.5;
      table.BottomPadding = (Unit) 2.5;
      table.AddColumn(Unit.FromCentimeter(9.0)).Format.Alignment = ParagraphAlignment.Left;
      table.AddColumn(Unit.FromCentimeter(6.0)).Format.Alignment = ParagraphAlignment.Right;
      table.AddColumn(Unit.FromCentimeter(3.0)).Format.Alignment = ParagraphAlignment.Right;
      Row row1 = table.AddRow();
      row1.Cells[0].MergeRight = 2;
      row1.Cells[0].Borders.Top.Width = (Unit) 1;
      row1.Cells[0].Borders.Bottom.Width = (Unit) 1;
      row1.Cells[0].Borders.Top.Color = Colors.Black;
      row1.Cells[0].Borders.Bottom.Color = Colors.Black;
      row1.Cells[0].Format.Alignment = ParagraphAlignment.Center;
      row1.Cells[0].AddParagraph().AddFormattedText("Totals", TextFormat.Bold).Size = (Unit) 12;
      table.AddRow().Borders.Visible = false;
      FormattedText formattedText;
      if (jobCost1 > 0.0)
      {
        Row row2 = table.AddRow();
        row2.Borders.Visible = false;
        row2.Cells[1].Borders.Right.Width = (Unit) 0.25;
        row2.Cells[1].Borders.Right.Color = Colors.Black;
        row2.Cells[1].Borders.Right.Visible = true;
        row2.Cells[1].AddParagraph("Parts Total");
        formattedText = row2.Cells[2].AddParagraph().AddFormattedText(jobCost1.ToString("C"), TextFormat.Bold);
      }
      if (jobCost2 > 0.0)
      {
        Row row2 = table.AddRow();
        row2.Borders.Visible = false;
        row2.Cells[1].Borders.Right.Width = (Unit) 0.25;
        row2.Cells[1].Borders.Right.Color = Colors.Black;
        row2.Cells[1].Borders.Right.Visible = true;
        row2.Cells[1].AddParagraph("Labour Total");
        formattedText = row2.Cells[2].AddParagraph().AddFormattedText(jobCost2.ToString("C"), TextFormat.Bold);
      }
      table.AddRow().Borders.Visible = false;
      Row row3 = table.AddRow();
      row3.Borders.Visible = false;
      row3.Cells[1].Borders.Right.Width = (Unit) 0.25;
      row3.Cells[1].Borders.Right.Color = Colors.Black;
      row3.Cells[1].Borders.Right.Visible = true;
      formattedText = row3.Cells[1].AddParagraph().AddFormattedText("Grand Total", TextFormat.Bold);
      formattedText = row3.Cells[2].AddParagraph().AddFormattedText((jobCost2 + jobCost1).ToString("C"), TextFormat.Bold);
      DdlWriter.WriteToFile((DocumentObject) doc, "MigraDoc.mdddl");
      PdfDocumentRenderer documentRenderer = new PdfDocumentRenderer(true);
      documentRenderer.Document = doc;
      documentRenderer.RenderDocument();
      string str = "JobCostingReport.pdf";
      documentRenderer.PdfDocument.Save(str);
      Process.Start(str);
    }

    private static double AddPartsToJobCost(Job job, Document doc)
    {
      double num1 = 0.0;
      DataView currentCostByJobId = App.DB.EngineerVisitsPartsAndProducts.Get_CurrentCost_ByJobID(job.JobID);
      if (currentCostByJobId.Count > 0)
      {
        Section lastSection = doc.LastSection;
        Paragraph paragraph = lastSection.AddParagraph();
        Table table1 = doc.LastSection.AddTable();
        table1.Borders.Width = (Unit) 0.25;
        table1.Borders.Left.Width = (Unit) 0;
        table1.Borders.Right.Width = (Unit) 0;
        table1.Rows.LeftIndent = (Unit) 0;
        table1.TopPadding = (Unit) 2.5;
        table1.BottomPadding = (Unit) 2.5;
        table1.AddColumn(Unit.FromCentimeter(18.0)).Format.Alignment = ParagraphAlignment.Center;
        Row row1 = table1.AddRow();
        row1.Cells[0].AddParagraph().AddFormattedText("Parts", TextFormat.Bold).Size = (Unit) 12;
        row1.Borders.Top.Width = (Unit) 1;
        row1.Borders.Bottom.Width = (Unit) 1;
        row1.Borders.Top.Color = Colors.Black;
        row1.Borders.Bottom.Color = Colors.Black;
        paragraph = lastSection.AddParagraph();
        Table table2 = doc.LastSection.AddTable();
        PdfFactory.DefineJobCostingTable(doc);
        table2.Style = "Table";
        table2.Borders.Color = Colors.DarkGray;
        table2.Borders.Width = (Unit) 0.25;
        table2.Borders.Left.Width = (Unit) 0.5;
        table2.Borders.Right.Width = (Unit) 0.5;
        table2.Rows.LeftIndent = (Unit) 0;
        table2.AddColumn(Unit.FromCentimeter(5.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(5.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(2.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(2.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(2.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(2.0)).Format.Alignment = ParagraphAlignment.Right;
        Row row2 = table2.AddRow();
        row2.HeadingFormat = true;
        row2.Format.Alignment = ParagraphAlignment.Center;
        row2.Format.Font.Bold = true;
        row2.Shading.Color = Colors.LightGray;
        row2.Cells[0].AddParagraph("Visit Date / Engineer / J.O.W / Visit No.");
        row2.Cells[0].Format.Font.Bold = false;
        row2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
        row2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
        row2.Cells[0].MergeRight = 5;
        Row row3 = table2.AddRow();
        row3.HeadingFormat = true;
        row3.Format.Alignment = ParagraphAlignment.Center;
        row3.Format.Font.Bold = true;
        row3.Shading.Color = Colors.LightBlue;
        row3.Cells[0].AddParagraph("Part");
        row3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[1].AddParagraph("MPN / SPN");
        row3.Cells[1].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[2].AddParagraph("Status");
        row3.Cells[2].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[3].AddParagraph("Quantity");
        row3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[4].AddParagraph("Unit Cost");
        row3.Cells[4].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[5].AddParagraph("Total Cost");
        row3.Cells[5].Format.Alignment = ParagraphAlignment.Right;
        EnumerableRowCollection<DataRow> source = currentCostByJobId.Table.AsEnumerable();
        Func<DataRow, int> selector;
        // ISSUE: reference to a compiler-generated field
        if (PdfFactory._Closure\u0024__.\u0024I3\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector = PdfFactory._Closure\u0024__.\u0024I3\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          PdfFactory._Closure\u0024__.\u0024I3\u002D0 = selector = (Func<DataRow, int>) (x => x.Field<int>("EngineerVisitID"));
        }
        List<int> list = source.Select<DataRow, int>(selector).Distinct<int>().ToList<int>();
        try
        {
          foreach (int num2 in list)
          {
            DataRow[] dataRowArray1 = currentCostByJobId.Table.Select("EngineerVisitID = " + Conversions.ToString(num2));
            Row row4 = table2.AddRow();
            row4.TopPadding = (Unit) 1.5;
            row4.Cells[0].Shading.Color = Colors.LightGray;
            row4.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row4.Cells[0].MergeRight = 5;
            paragraph = row4.Cells[0].AddParagraph(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["VisitDate"])).ToLongDateString() + " / " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["Engineer"])) + " / " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["JOWNo"])) + " / " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["VisitNo"])));
            DataRow[] dataRowArray2 = dataRowArray1;
            int index = 0;
            while (index < dataRowArray2.Length)
            {
              DataRow dataRow = dataRowArray2[index];
              Row row5 = table2.AddRow();
              row5.Cells[0].AddParagraph(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Part"])));
              row5.Cells[1].AddParagraph(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["MPN"])) + " / " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["SPN"])));
              row5.Cells[2].AddParagraph(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Status"])));
              row5.Cells[3].AddParagraph(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["Quantity"])));
              row5.Cells[4].AddParagraph(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["Rate"])).ToString("C"));
              row5.Cells[5].AddParagraph().AddFormattedText(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["Cost"])).ToString("C"), TextFormat.Bold);
              num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["Cost"]));
              checked { ++index; }
            }
          }
        }
        finally
        {
          List<int>.Enumerator enumerator;
          enumerator.Dispose();
        }
        table2.AddRow().Borders.Visible = false;
        Row row6 = table2.AddRow();
        row6.Cells[0].Borders.Visible = false;
        row6.Cells[0].AddParagraph().AddFormattedText("Total", TextFormat.Bold).Size = (Unit) 10;
        row6.Cells[0].Format.Font.Bold = true;
        row6.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        row6.Cells[0].MergeRight = 4;
        row6.Cells[5].Borders.Visible = false;
        row6.Cells[5].AddParagraph().AddFormattedText(num1.ToString("C"), TextFormat.Bold).Size = (Unit) 10;
      }
      return num1;
    }

    private static double AddLabourToJobCost(Job job, Document doc)
    {
      double num1 = 0.0;
      DataView currentCostByJobId = App.DB.EngineerVisitsTimeSheet.Get_CurrentCost_ByJobID(job.JobID);
      if (currentCostByJobId.Count > 0)
      {
        Section lastSection = doc.LastSection;
        Paragraph paragraph = lastSection.AddParagraph();
        Table table1 = doc.LastSection.AddTable();
        table1.Borders.Width = (Unit) 0.25;
        table1.Borders.Left.Width = (Unit) 0;
        table1.Borders.Right.Width = (Unit) 0;
        table1.Rows.LeftIndent = (Unit) 0;
        table1.TopPadding = (Unit) 2.5;
        table1.BottomPadding = (Unit) 2.5;
        table1.AddColumn(Unit.FromCentimeter(18.0)).Format.Alignment = ParagraphAlignment.Center;
        Row row1 = table1.AddRow();
        row1.Cells[0].AddParagraph().AddFormattedText("Labour", TextFormat.Bold).Size = (Unit) 12;
        row1.Borders.Top.Width = (Unit) 1;
        row1.Borders.Bottom.Width = (Unit) 1;
        row1.Borders.Top.Color = Colors.Black;
        row1.Borders.Bottom.Color = Colors.Black;
        paragraph = lastSection.AddParagraph();
        Table table2 = doc.LastSection.AddTable();
        PdfFactory.DefineJobCostingTable(doc);
        table2.Style = "Table";
        table2.Borders.Color = Colors.DarkGray;
        table2.Borders.Width = (Unit) 0.25;
        table2.Borders.Left.Width = (Unit) 0.5;
        table2.Borders.Right.Width = (Unit) 0.5;
        table2.Rows.LeftIndent = (Unit) 0;
        table2.AddColumn(Unit.FromCentimeter(5.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(5.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(3.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(2.0)).Format.Alignment = ParagraphAlignment.Left;
        table2.AddColumn(Unit.FromCentimeter(3.0)).Format.Alignment = ParagraphAlignment.Right;
        Row row2 = table2.AddRow();
        row2.HeadingFormat = true;
        row2.Format.Alignment = ParagraphAlignment.Center;
        row2.Format.Font.Bold = true;
        row2.Shading.Color = Colors.LightGray;
        row2.Cells[0].AddParagraph("Visit Date / Engineer / J.O.W / Visit No.");
        row2.Cells[0].Format.Font.Bold = false;
        row2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
        row2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
        row2.Cells[0].MergeRight = 4;
        Row row3 = table2.AddRow();
        row3.HeadingFormat = true;
        row3.Format.Alignment = ParagraphAlignment.Center;
        row3.Format.Font.Bold = true;
        row3.Shading.Color = Colors.LightBlue;
        row3.Cells[0].AddParagraph("Start");
        row3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[1].AddParagraph("End");
        row3.Cells[1].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[2].AddParagraph("Difference");
        row3.Cells[2].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[3].AddParagraph("Type");
        row3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
        row3.Cells[4].AddParagraph("Cost");
        row3.Cells[4].Format.Alignment = ParagraphAlignment.Right;
        EnumerableRowCollection<DataRow> source = currentCostByJobId.Table.AsEnumerable();
        Func<DataRow, int> selector;
        // ISSUE: reference to a compiler-generated field
        if (PdfFactory._Closure\u0024__.\u0024I4\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector = PdfFactory._Closure\u0024__.\u0024I4\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          PdfFactory._Closure\u0024__.\u0024I4\u002D0 = selector = (Func<DataRow, int>) (x => x.Field<int>("EngineerVisitID"));
        }
        List<int> list = source.Select<DataRow, int>(selector).Distinct<int>().ToList<int>();
        try
        {
          foreach (int num2 in list)
          {
            DataRow[] dataRowArray1 = currentCostByJobId.Table.Select("EngineerVisitID = " + Conversions.ToString(num2));
            Row row4 = table2.AddRow();
            row4.TopPadding = (Unit) 1.5;
            row4.Cells[0].Shading.Color = Colors.LightGray;
            row4.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row4.Cells[0].MergeRight = 4;
            paragraph = row4.Cells[0].AddParagraph(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["VisitDate"])).ToLongDateString() + " / " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["Engineer"])) + " / " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["JOWNo"])) + " / " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray1[0]["VisitNo"])));
            DataRow[] dataRowArray2 = dataRowArray1;
            int index = 0;
            while (index < dataRowArray2.Length)
            {
              DataRow dataRow = dataRowArray2[index];
              Row row5 = table2.AddRow();
              row5.Cells[0].AddParagraph(Conversions.ToString(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["TimesheetStart"]))));
              row5.Cells[1].AddParagraph(Conversions.ToString(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(dataRow["TimesheetEnd"]))));
              row5.Cells[2].AddParagraph(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["DifferenceInMins"])));
              row5.Cells[3].AddParagraph(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["TimesheetType"])));
              row5.Cells[4].AddParagraph().AddFormattedText(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["LabourCost"])).ToString("C"), TextFormat.Bold);
              num1 += Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["LabourCost"]));
              checked { ++index; }
            }
          }
        }
        finally
        {
          List<int>.Enumerator enumerator;
          enumerator.Dispose();
        }
        table2.AddRow().Borders.Visible = false;
        Row row6 = table2.AddRow();
        row6.Cells[0].Borders.Visible = false;
        row6.Cells[0].AddParagraph().AddFormattedText("Total", TextFormat.Bold).Size = (Unit) 10;
        row6.Cells[0].Format.Font.Bold = true;
        row6.Cells[0].Format.Alignment = ParagraphAlignment.Right;
        row6.Cells[0].MergeRight = 3;
        row6.Cells[4].Borders.Visible = false;
        row6.Cells[4].AddParagraph().AddFormattedText(num1.ToString("C"), TextFormat.Bold).Size = (Unit) 10;
      }
      return num1;
    }

    private static Style DefineJobCostingTable(Document doc)
    {
      Style style = doc.Styles.AddStyle("Table", "Normal");
      style.Font.Name = "Verdana";
      style.Font.Name = "Times New Roman";
      style.Font.Size = (Unit) 9;
      return style;
    }
  }
}
