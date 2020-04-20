using System.Data;
using System.Diagnostics;
using System.Linq;
using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using Microsoft.VisualBasic.CompilerServices;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace FSM.Entity.Sys
{
    public class PdfFactory
    {
        public static void GenerateSiteHistoryReport(Site site)
        {
            if (site is null)
                return;
            var dvSiteHistory = App.DB.EngineerVisits.Get_SiteHistory(site.SiteID);
            if (dvSiteHistory.Count == 0)
                return;
            var doc = new Document();
            doc.Info.Title = "Site History Report";
            doc.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            doc.DefaultPageSetup.RightMargin = Unit.FromCentimeter(1.5);
            doc.DefaultPageSetup.TopMargin = Unit.FromCentimeter(1);
            doc.DefaultPageSetup.BottomMargin = Unit.FromCentimeter(1);
            var section = doc.AddSection();
            var paragraph = section.AddParagraph();
            var formattedText = paragraph.AddFormattedText("Site History Report", TextFormat.Bold);
            formattedText.Size = 18;
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
            formattedText = paragraph.AddFormattedText(site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode(site.Postcode));
            formattedText.Size = 12;
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
            var table = doc.LastSection.AddTable();
            table.Borders.Visible = false;
            table.TopPadding = 5;
            table.BottomPadding = 5;
            var column = table.AddColumn(Unit.FromCentimeter(4));
            column.Format.Alignment = ParagraphAlignment.Left;
            column = table.AddColumn(Unit.FromCentimeter(7));
            column.Format.Alignment = ParagraphAlignment.Left;
            column = table.AddColumn(Unit.FromCentimeter(7));
            column.Format.Alignment = ParagraphAlignment.Left;
            foreach (DataRowView dr in dvSiteHistory)
            {
                var row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                row.Cells[0].MergeRight = 2;
                formattedText = paragraph.AddFormattedText(Helper.MakeDateTimeValid(dr["VisitDate"]).ToLongDateString() + " - " + Helper.MakeStringValid(dr["JobType"]), TextFormat.Bold);
                formattedText.Size = 11;
                row.Borders.Bottom.Width = 1;
                row.Borders.Bottom.Color = Colors.Black;
                row = table.AddRow();
                paragraph = row.Cells[0].AddParagraph();
                formattedText = paragraph.AddFormattedText("Job Number: ", TextFormat.Bold);
                formattedText.Size = 9;
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr["JobNumber"]));
                formattedText.Size = 9;
                paragraph.AddLineBreak();
                formattedText = paragraph.AddFormattedText("Engineer: ", TextFormat.Bold);
                formattedText.Size = 9;
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr["Engineer"]));
                formattedText.Size = 9;
                paragraph.AddLineBreak();
                formattedText = paragraph.AddFormattedText("Outcome: ", TextFormat.Bold);
                formattedText.Size = 9;
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr["Outcome"]));
                formattedText.Size = 9;
                paragraph = row.Cells[1].AddParagraph();
                formattedText = paragraph.AddFormattedText("Job Notes: ", TextFormat.Bold);
                formattedText.Size = 9;
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr["JobNotes"]));
                formattedText.Size = 9;
                paragraph = row.Cells[2].AddParagraph();
                formattedText = paragraph.AddFormattedText("Outcome Details: ", TextFormat.Bold);
                formattedText.Size = 9;
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr["OutcomeDetails"]));
                formattedText.Size = 9;
                table.AddRow();
            }

            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(doc, "MigraDoc.mdddl");
            var render = new PdfDocumentRenderer(true);
            render.Document = doc;
            render.RenderDocument();
            string filename = "SiteHistoryReport.pdf";
            render.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        public static void GenerateJobCostings(Job job)
        {
            if (job is null)
                return;
            var site = App.DB.Sites.Get(job.JobID, SiteSQL.GetBy.JobId);
            if (site is null)
                return;
            var doc = new Document();
            doc.Info.Title = "Job Costing Report";
            doc.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(1.5);
            doc.DefaultPageSetup.RightMargin = Unit.FromCentimeter(1.5);
            doc.DefaultPageSetup.TopMargin = Unit.FromCentimeter(1);
            doc.DefaultPageSetup.BottomMargin = Unit.FromCentimeter(1);
            var section = doc.AddSection();
            var paragraph = section.AddParagraph();
            paragraph.AddDateField("dd/MM/yyyy");
            paragraph.Format.Alignment = ParagraphAlignment.Right;
            paragraph = section.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            var formattedText = paragraph.AddFormattedText("Job Costing", TextFormat.Bold);
            formattedText.Size = 18;
            paragraph.Format.SpaceAfter = "2.5mm";
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "2.5mm";
            formattedText = paragraph.AddFormattedText(job.JobNumber + ": ", TextFormat.Bold);
            formattedText.Size = 14;
            formattedText = paragraph.AddFormattedText(site.Address1 + ", " + site.Address2 + ", " + Helper.FormatPostcode(site.Postcode));
            formattedText.Size = 12;
            paragraph.Format.SpaceAfter = "2.5mm";
            double partsTotal = AddPartsToJobCost(job, doc);
            double labourTotal = AddLabourToJobCost(job, doc);
            if (labourTotal + partsTotal == 0)
                return;
            paragraph = section.AddParagraph();
            var table = doc.LastSection.AddTable();
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;
            table.TopPadding = 2.5;
            table.BottomPadding = 2.5;
            var column = table.AddColumn(Unit.FromCentimeter(9));
            column.Format.Alignment = ParagraphAlignment.Left;
            column = table.AddColumn(Unit.FromCentimeter(6));
            column.Format.Alignment = ParagraphAlignment.Right;
            column = table.AddColumn(Unit.FromCentimeter(3));
            column.Format.Alignment = ParagraphAlignment.Right;
            var row = table.AddRow();
            row.Cells[0].MergeRight = 2;
            row.Cells[0].Borders.Top.Width = 1;
            row.Cells[0].Borders.Bottom.Width = 1;
            row.Cells[0].Borders.Top.Color = Colors.Black;
            row.Cells[0].Borders.Bottom.Color = Colors.Black;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            paragraph = row.Cells[0].AddParagraph();
            formattedText = paragraph.AddFormattedText("Totals", TextFormat.Bold);
            formattedText.Size = 12;
            row = table.AddRow();
            row.Borders.Visible = false;
            if (partsTotal > 0)
            {
                row = table.AddRow();
                row.Borders.Visible = false;
                row.Cells[1].Borders.Right.Width = 0.25;
                row.Cells[1].Borders.Right.Color = Colors.Black;
                row.Cells[1].Borders.Right.Visible = true;
                row.Cells[1].AddParagraph("Parts Total");
                paragraph = row.Cells[2].AddParagraph();
                formattedText = paragraph.AddFormattedText(partsTotal.ToString("C"), TextFormat.Bold);
            }

            if (labourTotal > 0)
            {
                row = table.AddRow();
                row.Borders.Visible = false;
                row.Cells[1].Borders.Right.Width = 0.25;
                row.Cells[1].Borders.Right.Color = Colors.Black;
                row.Cells[1].Borders.Right.Visible = true;
                row.Cells[1].AddParagraph("Labour Total");
                paragraph = row.Cells[2].AddParagraph();
                formattedText = paragraph.AddFormattedText(labourTotal.ToString("C"), TextFormat.Bold);
            }

            row = table.AddRow();
            row.Borders.Visible = false;
            row = table.AddRow();
            row.Borders.Visible = false;
            row.Cells[1].Borders.Right.Width = 0.25;
            row.Cells[1].Borders.Right.Color = Colors.Black;
            row.Cells[1].Borders.Right.Visible = true;
            paragraph = row.Cells[1].AddParagraph();
            formattedText = paragraph.AddFormattedText("Grand Total", TextFormat.Bold);
            paragraph = row.Cells[2].AddParagraph();
            formattedText = paragraph.AddFormattedText((labourTotal + partsTotal).ToString("C"), TextFormat.Bold);
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(doc, "MigraDoc.mdddl");
            var render = new PdfDocumentRenderer(true);
            render.Document = doc;
            render.RenderDocument();
            string filename = "JobCostingReport.pdf";
            render.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        private static double AddPartsToJobCost(Job job, Document doc)
        {
            double total = 0.0;
            var dvPartsCost = App.DB.EngineerVisitsPartsAndProducts.Get_CurrentCost_ByJobID(job.JobID);
            if (dvPartsCost.Count > 0)
            {
                var section = doc.LastSection;
                var paragraph = section.AddParagraph();
                var tableHeader = doc.LastSection.AddTable();
                tableHeader.Borders.Width = 0.25;
                tableHeader.Borders.Left.Width = 0;
                tableHeader.Borders.Right.Width = 0;
                tableHeader.Rows.LeftIndent = 0;
                tableHeader.TopPadding = 2.5;
                tableHeader.BottomPadding = 2.5;
                var columnHeader = tableHeader.AddColumn(Unit.FromCentimeter(18));
                columnHeader.Format.Alignment = ParagraphAlignment.Center;
                var rowHedaer = tableHeader.AddRow();
                paragraph = rowHedaer.Cells[0].AddParagraph();
                var formattedText = paragraph.AddFormattedText("Parts", TextFormat.Bold);
                formattedText.Size = 12;
                rowHedaer.Borders.Top.Width = 1;
                rowHedaer.Borders.Bottom.Width = 1;
                rowHedaer.Borders.Top.Color = Colors.Black;
                rowHedaer.Borders.Bottom.Color = Colors.Black;
                paragraph = section.AddParagraph();
                var table = doc.LastSection.AddTable();
                DefineJobCostingTable(doc);
                table.Style = "Table";
                table.Borders.Color = Colors.DarkGray;
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.5;
                table.Borders.Right.Width = 0.5;
                table.Rows.LeftIndent = 0;
                var column = table.AddColumn(Unit.FromCentimeter(5)); // part
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
                var row = table.AddRow();
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
                var visitIds = (from x in dvPartsCost.Table.AsEnumerable()
                                select x.Field<int>("EngineerVisitID")).Distinct().ToList();
                foreach (int visitId in visitIds)
                {
                    var drVisitParts = dvPartsCost.Table.Select("EngineerVisitID = " + visitId);
                    var row1 = table.AddRow();
                    row1.TopPadding = 1.5;
                    row1.Cells[0].Shading.Color = Colors.LightGray;
                    row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                    row1.Cells[0].MergeRight = 5;
                    paragraph = row1.Cells[0].AddParagraph(Helper.MakeDateTimeValid(drVisitParts[0]["VisitDate"]).ToLongDateString() + " / " + Helper.MakeStringValid(drVisitParts[0]["Engineer"]) + " / " + Helper.MakeStringValid(drVisitParts[0]["JOWNo"]) + " / " + Helper.MakeStringValid(drVisitParts[0]["VisitNo"]));
                    foreach (DataRow drVisitPart in drVisitParts)
                    {
                        var row2 = table.AddRow();
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
            var dvLabourCost = App.DB.EngineerVisitsTimeSheet.Get_CurrentCost_ByJobID(job.JobID);
            if (dvLabourCost.Count > 0)
            {
                var section = doc.LastSection;
                var paragraph = section.AddParagraph();
                var tableHeader = doc.LastSection.AddTable();
                tableHeader.Borders.Width = 0.25;
                tableHeader.Borders.Left.Width = 0;
                tableHeader.Borders.Right.Width = 0;
                tableHeader.Rows.LeftIndent = 0;
                tableHeader.TopPadding = 2.5;
                tableHeader.BottomPadding = 2.5;
                var columnHeader = tableHeader.AddColumn(Unit.FromCentimeter(18));
                columnHeader.Format.Alignment = ParagraphAlignment.Center;
                var rowHedaer = tableHeader.AddRow();
                paragraph = rowHedaer.Cells[0].AddParagraph();
                var formattedText = paragraph.AddFormattedText("Labour", TextFormat.Bold);
                formattedText.Size = 12;
                rowHedaer.Borders.Top.Width = 1;
                rowHedaer.Borders.Bottom.Width = 1;
                rowHedaer.Borders.Top.Color = Colors.Black;
                rowHedaer.Borders.Bottom.Color = Colors.Black;
                paragraph = section.AddParagraph();
                var table = doc.LastSection.AddTable();
                DefineJobCostingTable(doc);
                table.Style = "Table";
                table.Borders.Color = Colors.DarkGray;
                table.Borders.Width = 0.25;
                table.Borders.Left.Width = 0.5;
                table.Borders.Right.Width = 0.5;
                table.Rows.LeftIndent = 0;
                var column = table.AddColumn(Unit.FromCentimeter(5)); // part
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(5)); // mpn / spn
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(3)); // quantity
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(2)); // status
                column.Format.Alignment = ParagraphAlignment.Left;
                column = table.AddColumn(Unit.FromCentimeter(3)); // unit cost
                column.Format.Alignment = ParagraphAlignment.Right;
                var row = table.AddRow();
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
                var visitIds = (from x in dvLabourCost.Table.AsEnumerable()
                                select x.Field<int>("EngineerVisitID")).Distinct().ToList();
                foreach (int visitId in visitIds)
                {
                    var drLabour = dvLabourCost.Table.Select("EngineerVisitID = " + visitId);
                    var row1 = table.AddRow();
                    row1.TopPadding = 1.5;
                    row1.Cells[0].Shading.Color = Colors.LightGray;
                    row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                    row1.Cells[0].MergeRight = 4;
                    paragraph = row1.Cells[0].AddParagraph(Helper.MakeDateTimeValid(drLabour[0]["VisitDate"]).ToLongDateString() + " / " + Helper.MakeStringValid(drLabour[0]["Engineer"]) + " / " + Helper.MakeStringValid(drLabour[0]["JOWNo"]) + " / " + Helper.MakeStringValid(drLabour[0]["VisitNo"]));
                    foreach (DataRow dr in drLabour)
                    {
                        var row2 = table.AddRow();
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
            var style = doc.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;
            return style;
        }
    }
}