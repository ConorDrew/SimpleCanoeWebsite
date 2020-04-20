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
            paragraph1.AddFormattedText("Site History Report", TextFormat.Bold).Size = (Unit)18;
            paragraph1.AddLineBreak();
            paragraph1.AddLineBreak();
            paragraph1.AddFormattedText(site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode((object)site.Postcode)).Size = (Unit)12;
            paragraph1.AddLineBreak();
            paragraph1.AddLineBreak();
            Table table = document.LastSection.AddTable();
            table.Borders.Visible = false;
            table.TopPadding = (Unit)5;
            table.BottomPadding = (Unit)5;
            table.AddColumn(Unit.FromCentimeter(4.0)).Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn(Unit.FromCentimeter(7.0)).Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn(Unit.FromCentimeter(7.0)).Format.Alignment = ParagraphAlignment.Left;

            foreach (DataRowView current in siteHistory)
            {
                Row row1 = table.AddRow();
                Paragraph paragraph2 = row1.Cells[0].AddParagraph();
                row1.Cells[0].MergeRight = 2;
                paragraph2.AddFormattedText(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(current["VisitDate"])).ToLongDateString() + " - " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["JobType"])), TextFormat.Bold).Size = (Unit)11;
                row1.Borders.Bottom.Width = (Unit)1;
                row1.Borders.Bottom.Color = Colors.Black;
                Row row2 = table.AddRow();
                Paragraph paragraph3 = row2.Cells[0].AddParagraph();
                paragraph3.AddFormattedText("Job Number: ", TextFormat.Bold).Size = (Unit)9;
                paragraph3.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["JobNumber"]))).Size = (Unit)9;
                paragraph3.AddLineBreak();
                paragraph3.AddFormattedText("Engineer: ", TextFormat.Bold).Size = (Unit)9;
                paragraph3.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Engineer"]))).Size = (Unit)9;
                paragraph3.AddLineBreak();
                paragraph3.AddFormattedText("Outcome: ", TextFormat.Bold).Size = (Unit)9;
                paragraph3.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Outcome"]))).Size = (Unit)9;
                Paragraph paragraph4 = row2.Cells[1].AddParagraph();
                paragraph4.AddFormattedText("Job Notes: ", TextFormat.Bold).Size = (Unit)9;
                paragraph4.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["JobNotes"]))).Size = (Unit)9;
                Paragraph paragraph5 = row2.Cells[2].AddParagraph();
                paragraph5.AddFormattedText("Outcome Details: ", TextFormat.Bold).Size = (Unit)9;
                paragraph5.AddFormattedText(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["OutcomeDetails"]))).Size = (Unit)9;
                table.AddRow();
            }
            DdlWriter.WriteToFile((DocumentObject)document, "MigraDoc.mdddl");
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
            Site site = App.DB.Sites.Get((object)job.JobID, SiteSQL.GetBy.JobId, (object)null);
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
            paragraph2.AddFormattedText("Job Costing", TextFormat.Bold).Size = (Unit)18;
            paragraph2.Format.SpaceAfter = (Unit)"2.5mm";
            Paragraph paragraph3 = section.AddParagraph();
            paragraph3.Format.SpaceBefore = (Unit)"2.5mm";
            paragraph3.AddFormattedText(job.JobNumber + ": ", TextFormat.Bold).Size = (Unit)14;
            paragraph3.AddFormattedText(site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode((object)site.Postcode)).Size = (Unit)12;
            paragraph3.Format.SpaceAfter = (Unit)"2.5mm";
            double jobCost1 = PdfFactory.AddPartsToJobCost(job, doc);
            double jobCost2 = PdfFactory.AddLabourToJobCost(job, doc);
            if (jobCost2 + jobCost1 == 0.0)
                return;
            section.AddParagraph();
            Table table = doc.LastSection.AddTable();
            table.Borders.Width = (Unit)0.25;
            table.Borders.Left.Width = (Unit)0;
            table.Borders.Right.Width = (Unit)0;
            table.Rows.LeftIndent = (Unit)0;
            table.TopPadding = (Unit)2.5;
            table.BottomPadding = (Unit)2.5;
            table.AddColumn(Unit.FromCentimeter(9.0)).Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn(Unit.FromCentimeter(6.0)).Format.Alignment = ParagraphAlignment.Right;
            table.AddColumn(Unit.FromCentimeter(3.0)).Format.Alignment = ParagraphAlignment.Right;
            Row row1 = table.AddRow();
            row1.Cells[0].MergeRight = 2;
            row1.Cells[0].Borders.Top.Width = (Unit)1;
            row1.Cells[0].Borders.Bottom.Width = (Unit)1;
            row1.Cells[0].Borders.Top.Color = Colors.Black;
            row1.Cells[0].Borders.Bottom.Color = Colors.Black;
            row1.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row1.Cells[0].AddParagraph().AddFormattedText("Totals", TextFormat.Bold).Size = (Unit)12;
            table.AddRow().Borders.Visible = false;
            FormattedText formattedText;
            if (jobCost1 > 0.0)
            {
                Row row2 = table.AddRow();
                row2.Borders.Visible = false;
                row2.Cells[1].Borders.Right.Width = (Unit)0.25;
                row2.Cells[1].Borders.Right.Color = Colors.Black;
                row2.Cells[1].Borders.Right.Visible = true;
                row2.Cells[1].AddParagraph("Parts Total");
                formattedText = row2.Cells[2].AddParagraph().AddFormattedText(jobCost1.ToString("C"), TextFormat.Bold);
            }
            if (jobCost2 > 0.0)
            {
                Row row2 = table.AddRow();
                row2.Borders.Visible = false;
                row2.Cells[1].Borders.Right.Width = (Unit)0.25;
                row2.Cells[1].Borders.Right.Color = Colors.Black;
                row2.Cells[1].Borders.Right.Visible = true;
                row2.Cells[1].AddParagraph("Labour Total");
                formattedText = row2.Cells[2].AddParagraph().AddFormattedText(jobCost2.ToString("C"), TextFormat.Bold);
            }
            table.AddRow().Borders.Visible = false;
            Row row3 = table.AddRow();
            row3.Borders.Visible = false;
            row3.Cells[1].Borders.Right.Width = (Unit)0.25;
            row3.Cells[1].Borders.Right.Color = Colors.Black;
            row3.Cells[1].Borders.Right.Visible = true;
            formattedText = row3.Cells[1].AddParagraph().AddFormattedText("Grand Total", TextFormat.Bold);
            formattedText = row3.Cells[2].AddParagraph().AddFormattedText((jobCost2 + jobCost1).ToString("C"), TextFormat.Bold);
            DdlWriter.WriteToFile((DocumentObject)doc, "MigraDoc.mdddl");
            PdfDocumentRenderer documentRenderer = new PdfDocumentRenderer(true);
            documentRenderer.Document = doc;
            documentRenderer.RenderDocument();
            string str = "JobCostingReport.pdf";
            documentRenderer.PdfDocument.Save(str);
            Process.Start(str);
        }

        private static double AddPartsToJobCost(Job job, Document doc)
        {
            double total = 0.0;

            DataView dvPartsCost = App.DB.EngineerVisitsPartsAndProducts.Get_CurrentCost_ByJobID(job.JobID);
            if (dvPartsCost.Count > 0)
            {
                Section section = doc.LastSection;
                Paragraph paragraph = section.AddParagraph();
                Table tableHeader = doc.LastSection.AddTable();
                tableHeader.Borders.Width = 0.25;
                tableHeader.Borders.Left.Width = 0;
                tableHeader.Borders.Right.Width = 0;
                tableHeader.Rows.LeftIndent = 0;
                tableHeader.TopPadding = 2.5;
                tableHeader.BottomPadding = 2.5;

                Column columnHeader = tableHeader.AddColumn(Unit.FromCentimeter(18));
                columnHeader.Format.Alignment = ParagraphAlignment.Center;

                Row rowHedaer = tableHeader.AddRow();
                paragraph = rowHedaer.Cells[0].AddParagraph();
                FormattedText formattedText = paragraph.AddFormattedText("Parts", TextFormat.Bold);
                formattedText.Size = 12;
                rowHedaer.Borders.Top.Width = 1;
                rowHedaer.Borders.Bottom.Width = 1;
                rowHedaer.Borders.Top.Color = Colors.Black;
                rowHedaer.Borders.Bottom.Color = Colors.Black;

                paragraph = section.AddParagraph();

                Table table = doc.LastSection.AddTable();
                DefineJobCostingTable(doc);
                table.Style = "Table";
                table.Borders.Color = Colors.DarkGray;
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.5;
                table.Borders.Right.Width = 0.5;
                table.Rows.LeftIndent = 0;

                Column column = table.AddColumn(Unit.FromCentimeter(5)); // part
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(5)); // mpn / spn
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(2)); // quantity
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(2)); // status
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(2)); // unit cost
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(2)); // total cost
                column.Format.Alignment = ParagraphAlignment.Right;

                Row row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.LightGray;
                row.Cells[0].AddParagraph("Visit Date / Engineer / J.O.W / Visit No.");
                row.Cells[0].Format.Font.Bold = false;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                row.Cells[0].MergeRight = 5;

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.LightBlue;
                row.Cells[0].AddParagraph("Part");
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].AddParagraph("MPN / SPN");
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[2].AddParagraph("Status");
                row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[3].AddParagraph("Quantity");
                row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].AddParagraph("Unit Cost");
                row.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[5].AddParagraph("Total Cost");
                row.Cells[5].Format.Alignment = ParagraphAlignment.Right;

                List<int> visitIds = (from x in dvPartsCost.Table.AsEnumerable()
                                      select x.Field<int>("EngineerVisitID")).Distinct().ToList();
                foreach (int visitId in visitIds)
                {
                    DataRow[] drVisitParts = dvPartsCost.Table.Select("EngineerVisitID = " + visitId);

                    Row row1 = table.AddRow();
                    row1.TopPadding = 1.5;
                    row1.Cells[0].Shading.Color = Colors.LightGray;
                    row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                    row1.Cells[0].MergeRight = 5;
                    paragraph = row1.Cells[0].AddParagraph(Helper.MakeDateTimeValid(drVisitParts[0]["VisitDate"]).ToLongDateString() + " / " + Helper.MakeStringValid(drVisitParts[0]["Engineer"]) + " / " + Helper.MakeStringValid(drVisitParts[0]["JOWNo"]) + " / " + Helper.MakeStringValid(drVisitParts[0]["VisitNo"]));

                    foreach (DataRow drVisitPart in drVisitParts)
                    {
                        Row row2 = table.AddRow();
                        row2.Cells[0].AddParagraph(Helper.MakeStringValid(drVisitPart["Part"]));
                        row2.Cells[1].AddParagraph(Helper.MakeStringValid(drVisitPart["MPN"]) + " / " + Helper.MakeStringValid(drVisitPart["SPN"]));
                        row2.Cells[2].AddParagraph(Helper.MakeStringValid(drVisitPart["Status"]));
                        row2.Cells[3].AddParagraph(Helper.MakeStringValid(drVisitPart["Quantity"]));
                        row2.Cells[4].AddParagraph(Helper.MakeDoubleValid(drVisitPart["Rate"]).ToString("C"));
                        paragraph = row2.Cells[5].AddParagraph();
                        formattedText = paragraph.AddFormattedText(Helper.MakeDoubleValid(drVisitPart["Cost"]).ToString("C"), TextFormat.Bold);

                        total += Helper.MakeDoubleValid(drVisitPart["Cost"]);
                    }
                }

                row = table.AddRow();
                row.Borders.Visible = false;

                row = table.AddRow();
                row.Cells[0].Borders.Visible = false;
                paragraph = row.Cells[0].AddParagraph();
                formattedText = paragraph.AddFormattedText("Total", TextFormat.Bold);
                formattedText.Size = 10;
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[0].MergeRight = 4;
                row.Cells[5].Borders.Visible = false;
                paragraph = row.Cells[5].AddParagraph();
                formattedText = paragraph.AddFormattedText(total.ToString("C"), TextFormat.Bold);
                formattedText.Size = 10;
            }
            return total;
        }

        private static double AddLabourToJobCost(Job job, Document doc)
        {
            double total = 0.0;

            DataView dvLabourCost = App.DB.EngineerVisitsTimeSheet.Get_CurrentCost_ByJobID(job.JobID);
            if (dvLabourCost.Count > 0)
            {
                Section section = doc.LastSection;
                Paragraph paragraph = section.AddParagraph();
                Table tableHeader = doc.LastSection.AddTable();
                tableHeader.Borders.Width = 0.25;
                tableHeader.Borders.Left.Width = 0;
                tableHeader.Borders.Right.Width = 0;
                tableHeader.Rows.LeftIndent = 0;
                tableHeader.TopPadding = 2.5;
                tableHeader.BottomPadding = 2.5;

                Column columnHeader = tableHeader.AddColumn(Unit.FromCentimeter(18));
                columnHeader.Format.Alignment = ParagraphAlignment.Center;

                Row rowHedaer = tableHeader.AddRow();
                paragraph = rowHedaer.Cells[0].AddParagraph();
                FormattedText formattedText = paragraph.AddFormattedText("Labour", TextFormat.Bold);
                formattedText.Size = 12;
                rowHedaer.Borders.Top.Width = 1;
                rowHedaer.Borders.Bottom.Width = 1;
                rowHedaer.Borders.Top.Color = Colors.Black;
                rowHedaer.Borders.Bottom.Color = Colors.Black;

                paragraph = section.AddParagraph();

                Table table = doc.LastSection.AddTable();
                DefineJobCostingTable(doc);
                table.Style = "Table";
                table.Borders.Color = Colors.DarkGray;
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.5;
                table.Borders.Right.Width = 0.5;
                table.Rows.LeftIndent = 0;

                Column column = table.AddColumn(Unit.FromCentimeter(5)); // part
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(5)); // mpn / spn
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(3)); // quantity
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(2)); // status
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(3)); // unit cost
                column.Format.Alignment = ParagraphAlignment.Right;

                Row row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.LightGray;
                row.Cells[0].AddParagraph("Visit Date / Engineer / J.O.W / Visit No.");
                row.Cells[0].Format.Font.Bold = false;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                row.Cells[0].MergeRight = 4;

                row = table.AddRow();
                row.HeadingFormat = true;
                row.Format.Alignment = ParagraphAlignment.Center;
                row.Format.Font.Bold = true;
                row.Shading.Color = Colors.LightBlue;
                row.Cells[0].AddParagraph("Start");
                row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[1].AddParagraph("End");
                row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[2].AddParagraph("Difference");
                row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[3].AddParagraph("Type");
                row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[4].AddParagraph("Cost");
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;

                List<int> visitIds = (from x in dvLabourCost.Table.AsEnumerable()
                                      select x.Field<int>("EngineerVisitID")).Distinct().ToList();
                foreach (int visitId in visitIds)
                {
                    DataRow[] drLabour = dvLabourCost.Table.Select("EngineerVisitID = " + visitId);

                    Row row1 = table.AddRow();
                    row1.TopPadding = 1.5;
                    row1.Cells[0].Shading.Color = Colors.LightGray;
                    row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                    row1.Cells[0].MergeRight = 4;
                    paragraph = row1.Cells[0].AddParagraph(Helper.MakeDateTimeValid(drLabour[0]["VisitDate"]).ToLongDateString() + " / " + Helper.MakeStringValid(drLabour[0]["Engineer"]) + " / " + Helper.MakeStringValid(drLabour[0]["JOWNo"]) + " / " + Helper.MakeStringValid(drLabour[0]["VisitNo"]));

                    foreach (DataRow dr in drLabour)
                    {
                        Row row2 = table.AddRow();
                        row2.Cells[0].AddParagraph(Conversions.ToString(Helper.MakeDateTimeValid(dr["TimesheetStart"])));
                        row2.Cells[1].AddParagraph(Conversions.ToString(Helper.MakeDateTimeValid(dr["TimesheetEnd"])));
                        row2.Cells[2].AddParagraph(Helper.MakeStringValid(dr["DifferenceInMins"]));
                        row2.Cells[3].AddParagraph(Helper.MakeStringValid(dr["TimesheetType"]));
                        paragraph = row2.Cells[4].AddParagraph();
                        formattedText = paragraph.AddFormattedText(Helper.MakeDoubleValid(dr["LabourCost"]).ToString("C"), TextFormat.Bold);

                        total += Helper.MakeDoubleValid(dr["LabourCost"]);
                    }
                }

                row = table.AddRow();
                row.Borders.Visible = false;

                row = table.AddRow();
                row.Cells[0].Borders.Visible = false;
                paragraph = row.Cells[0].AddParagraph();
                formattedText = paragraph.AddFormattedText("Total", TextFormat.Bold);
                formattedText.Size = 10;
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[0].MergeRight = 3;
                row.Cells[4].Borders.Visible = false;
                paragraph = row.Cells[4].AddParagraph();
                formattedText = paragraph.AddFormattedText(total.ToString("C"), TextFormat.Bold);
                formattedText.Size = 10;
            }
            return total;
        }

        private static Style DefineJobCostingTable(Document doc)
        {
            Style style = doc.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = (Unit)9;
            return style;
        }
    }
}