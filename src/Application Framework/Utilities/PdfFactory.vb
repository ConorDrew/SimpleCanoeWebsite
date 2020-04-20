Imports System.Collections.Generic
Imports System.Linq
Imports FSM.Entity.Jobs
Imports FSM.Entity.Sites
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Namespace Entity.Sys

    Public Class PdfFactory

        Public Shared Sub GenerateSiteHistoryReport(ByVal site As Site)
            If site Is Nothing Then Exit Sub
            Dim dvSiteHistory As DataView = DB.EngineerVisits.Get_SiteHistory(site.SiteID)
            If dvSiteHistory.Count = 0 Then Exit Sub

            Dim doc As New Document
            doc.Info.Title = "Site History Report"
            doc.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(1.5)
            doc.DefaultPageSetup.RightMargin = Unit.FromCentimeter(1.5)
            doc.DefaultPageSetup.TopMargin = Unit.FromCentimeter(1)
            doc.DefaultPageSetup.BottomMargin = Unit.FromCentimeter(1)

            Dim section As Section = doc.AddSection()
            Dim paragraph As Paragraph = section.AddParagraph()
            Dim formattedText As FormattedText = paragraph.AddFormattedText("Site History Report", TextFormat.Bold)
            formattedText.Size = 18
            paragraph.AddLineBreak()
            paragraph.AddLineBreak()

            formattedText = paragraph.AddFormattedText(site.Address1 & ", " & site.Address2 & ", " & Helper.FormatPostcode(site.Postcode))
            formattedText.Size = 12
            paragraph.AddLineBreak()
            paragraph.AddLineBreak()

            Dim table As Table = doc.LastSection.AddTable()
            table.Borders.Visible = False
            table.TopPadding = 5
            table.BottomPadding = 5

            Dim column As Column = table.AddColumn(Unit.FromCentimeter(4))
            column.Format.Alignment = ParagraphAlignment.Left
            column = table.AddColumn(Unit.FromCentimeter(7))
            column.Format.Alignment = ParagraphAlignment.Left
            column = table.AddColumn(Unit.FromCentimeter(7))
            column.Format.Alignment = ParagraphAlignment.Left

            For Each dr As DataRowView In dvSiteHistory
                Dim row As Row = table.AddRow()

                paragraph = row.Cells(0).AddParagraph()
                row.Cells(0).MergeRight = 2
                formattedText = paragraph.AddFormattedText(Helper.MakeDateTimeValid(dr("VisitDate")).ToLongDateString() &
                                                           " - " & Helper.MakeStringValid(dr("JobType")), TextFormat.Bold)
                formattedText.Size = 11
                row.Borders.Bottom.Width = 1
                row.Borders.Bottom.Color = Colors.Black

                row = table.AddRow()
                paragraph = row.Cells(0).AddParagraph()
                formattedText = paragraph.AddFormattedText("Job Number: ", TextFormat.Bold)
                formattedText.Size = 9
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr("JobNumber")))
                formattedText.Size = 9
                paragraph.AddLineBreak()
                formattedText = paragraph.AddFormattedText("Engineer: ", TextFormat.Bold)
                formattedText.Size = 9
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr("Engineer")))
                formattedText.Size = 9
                paragraph.AddLineBreak()
                formattedText = paragraph.AddFormattedText("Outcome: ", TextFormat.Bold)
                formattedText.Size = 9
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr("Outcome")))
                formattedText.Size = 9

                paragraph = row.Cells(1).AddParagraph()
                formattedText = paragraph.AddFormattedText("Job Notes: ", TextFormat.Bold)
                formattedText.Size = 9
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr("JobNotes")))
                formattedText.Size = 9

                paragraph = row.Cells(2).AddParagraph()
                formattedText = paragraph.AddFormattedText("Outcome Details: ", TextFormat.Bold)
                formattedText.Size = 9
                formattedText = paragraph.AddFormattedText(Helper.MakeStringValid(dr("OutcomeDetails")))
                formattedText.Size = 9
                table.AddRow()
            Next

            IO.DdlWriter.WriteToFile(doc, "MigraDoc.mdddl")

            Dim render As PdfDocumentRenderer = New PdfDocumentRenderer(True)
            render.Document = doc
            render.RenderDocument()
            Dim filename As String = "SiteHistoryReport.pdf"
            render.PdfDocument.Save(filename)
            Process.Start(filename)

        End Sub

        Public Shared Sub GenerateJobCostings(ByVal job As Job)
            If job Is Nothing Then Exit Sub

            Dim site As Site = DB.Sites.Get(job.JobID, SiteSQL.GetBy.JobId)
            If site Is Nothing Then Exit Sub

            Dim doc As New Document
            doc.Info.Title = "Job Costing Report"
            doc.DefaultPageSetup.LeftMargin = Unit.FromCentimeter(1.5)
            doc.DefaultPageSetup.RightMargin = Unit.FromCentimeter(1.5)
            doc.DefaultPageSetup.TopMargin = Unit.FromCentimeter(1)
            doc.DefaultPageSetup.BottomMargin = Unit.FromCentimeter(1)

            Dim section As Section = doc.AddSection()

            Dim paragraph As Paragraph = section.AddParagraph()
            paragraph.AddDateField("dd/MM/yyyy")
            paragraph.Format.Alignment = ParagraphAlignment.Right

            paragraph = section.AddParagraph
            paragraph.Format.Alignment = ParagraphAlignment.Left
            Dim formattedText As FormattedText = paragraph.AddFormattedText("Job Costing", TextFormat.Bold)
            formattedText.Size = 18
            paragraph.Format.SpaceAfter = "2.5mm"

            paragraph = section.AddParagraph()
            paragraph.Format.SpaceBefore = "2.5mm"
            formattedText = paragraph.AddFormattedText(job.JobNumber & ": ", TextFormat.Bold)
            formattedText.Size = 14
            formattedText = paragraph.AddFormattedText(site.Address1 & ", " & site.Address2 & ", " & Helper.FormatPostcode(site.Postcode))
            formattedText.Size = 12
            paragraph.Format.SpaceAfter = "2.5mm"

            Dim partsTotal As Double = AddPartsToJobCost(job, doc)
            Dim labourTotal As Double = AddLabourToJobCost(job, doc)

            If (labourTotal + partsTotal) = 0 Then Exit Sub

            paragraph = section.AddParagraph()
            Dim table As Table = doc.LastSection.AddTable()
            table.Borders.Width = 0.25
            table.Borders.Left.Width = 0
            table.Borders.Right.Width = 0
            table.Rows.LeftIndent = 0
            table.TopPadding = 2.5
            table.BottomPadding = 2.5

            Dim column As Column = table.AddColumn(Unit.FromCentimeter(9))
            column.Format.Alignment = ParagraphAlignment.Left
            column = table.AddColumn(Unit.FromCentimeter(6))
            column.Format.Alignment = ParagraphAlignment.Right
            column = table.AddColumn(Unit.FromCentimeter(3))
            column.Format.Alignment = ParagraphAlignment.Right

            Dim row As Row = table.AddRow()
            row.Cells(0).MergeRight = 2
            row.Cells(0).Borders.Top.Width = 1
            row.Cells(0).Borders.Bottom.Width = 1
            row.Cells(0).Borders.Top.Color = Colors.Black
            row.Cells(0).Borders.Bottom.Color = Colors.Black
            row.Cells(0).Format.Alignment = ParagraphAlignment.Center
            paragraph = row.Cells(0).AddParagraph()
            formattedText = paragraph.AddFormattedText("Totals", TextFormat.Bold)
            formattedText.Size = 12

            row = table.AddRow()
            row.Borders.Visible = False

            If partsTotal > 0 Then
                row = table.AddRow()
                row.Borders.Visible = False
                row.Cells(1).Borders.Right.Width = 0.25
                row.Cells(1).Borders.Right.Color = Colors.Black
                row.Cells(1).Borders.Right.Visible = True
                row.Cells(1).AddParagraph("Parts Total")
                paragraph = row.Cells(2).AddParagraph()
                formattedText = paragraph.AddFormattedText(partsTotal.ToString("C"), TextFormat.Bold)
            End If

            If labourTotal > 0 Then
                row = table.AddRow()
                row.Borders.Visible = False
                row.Cells(1).Borders.Right.Width = 0.25
                row.Cells(1).Borders.Right.Color = Colors.Black
                row.Cells(1).Borders.Right.Visible = True
                row.Cells(1).AddParagraph("Labour Total")
                paragraph = row.Cells(2).AddParagraph()
                formattedText = paragraph.AddFormattedText(labourTotal.ToString("C"), TextFormat.Bold)
            End If

            row = table.AddRow()
            row.Borders.Visible = False

            row = table.AddRow()
            row.Borders.Visible = False
            row.Cells(1).Borders.Right.Width = 0.25
            row.Cells(1).Borders.Right.Color = Colors.Black
            row.Cells(1).Borders.Right.Visible = True
            paragraph = row.Cells(1).AddParagraph()
            formattedText = paragraph.AddFormattedText("Grand Total", TextFormat.Bold)
            paragraph = row.Cells(2).AddParagraph()
            formattedText = paragraph.AddFormattedText((labourTotal + partsTotal).ToString("C"), TextFormat.Bold)

            IO.DdlWriter.WriteToFile(doc, "MigraDoc.mdddl")

            Dim render As PdfDocumentRenderer = New PdfDocumentRenderer(True)
            render.Document = doc
            render.RenderDocument()
            Dim filename As String = "JobCostingReport.pdf"
            render.PdfDocument.Save(filename)
            Process.Start(filename)
        End Sub

        Private Shared Function AddPartsToJobCost(job As Job, doc As Document) As Double
            Dim total As Double = 0.0

            Dim dvPartsCost As DataView = DB.EngineerVisitsPartsAndProducts.Get_CurrentCost_ByJobID(job.JobID)
            If dvPartsCost.Count > 0 Then
                Dim section As Section = doc.LastSection()
                Dim paragraph As Paragraph = section.AddParagraph()
                Dim tableHeader As Table = doc.LastSection.AddTable()
                tableHeader.Borders.Width = 0.25
                tableHeader.Borders.Left.Width = 0
                tableHeader.Borders.Right.Width = 0
                tableHeader.Rows.LeftIndent = 0
                tableHeader.TopPadding = 2.5
                tableHeader.BottomPadding = 2.5

                Dim columnHeader As Column = tableHeader.AddColumn(Unit.FromCentimeter(18))
                columnHeader.Format.Alignment = ParagraphAlignment.Center

                Dim rowHedaer As Row = tableHeader.AddRow()
                paragraph = rowHedaer.Cells(0).AddParagraph()
                Dim formattedText As FormattedText = paragraph.AddFormattedText("Parts", TextFormat.Bold)
                formattedText.Size = 12
                rowHedaer.Borders.Top.Width = 1
                rowHedaer.Borders.Bottom.Width = 1
                rowHedaer.Borders.Top.Color = Colors.Black
                rowHedaer.Borders.Bottom.Color = Colors.Black

                paragraph = section.AddParagraph()

                Dim table As Table = doc.LastSection.AddTable()
                DefineJobCostingTable(doc)
                table.Style = "Table"
                table.Borders.Color = Colors.DarkGray
                table.Borders.Width = 0.25
                table.Borders.Left.Width = 0.5
                table.Borders.Right.Width = 0.5
                table.Rows.LeftIndent = 0

                Dim column As Column = table.AddColumn(Unit.FromCentimeter(5)) 'part
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(5)) 'mpn / spn
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(2)) 'quantity
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(2)) 'status
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(2)) 'unit cost
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(2)) 'total cost
                column.Format.Alignment = ParagraphAlignment.Right

                Dim row As Row = table.AddRow()
                row.HeadingFormat = True
                row.Format.Alignment = ParagraphAlignment.Center
                row.Format.Font.Bold = True
                row.Shading.Color = Colors.LightGray
                row.Cells(0).AddParagraph("Visit Date / Engineer / J.O.W / Visit No.")
                row.Cells(0).Format.Font.Bold = False
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(0).VerticalAlignment = VerticalAlignment.Bottom
                row.Cells(0).MergeRight = 5

                row = table.AddRow()
                row.HeadingFormat = True
                row.Format.Alignment = ParagraphAlignment.Center
                row.Format.Font.Bold = True
                row.Shading.Color = Colors.LightBlue
                row.Cells(0).AddParagraph("Part")
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(1).AddParagraph("MPN / SPN")
                row.Cells(1).Format.Alignment = ParagraphAlignment.Left
                row.Cells(2).AddParagraph("Status")
                row.Cells(2).Format.Alignment = ParagraphAlignment.Left
                row.Cells(3).AddParagraph("Quantity")
                row.Cells(3).Format.Alignment = ParagraphAlignment.Left
                row.Cells(4).AddParagraph("Unit Cost")
                row.Cells(4).Format.Alignment = ParagraphAlignment.Left
                row.Cells(5).AddParagraph("Total Cost")
                row.Cells(5).Format.Alignment = ParagraphAlignment.Right

                Dim visitIds As List(Of Integer) = (From x In dvPartsCost.Table.AsEnumerable() Select x.Field(Of Integer)("EngineerVisitID")).Distinct().ToList()
                For Each visitId As Integer In visitIds
                    Dim drVisitParts As DataRow() = dvPartsCost.Table.Select("EngineerVisitID = " & visitId)

                    Dim row1 As Row = table.AddRow()
                    row1.TopPadding = 1.5
                    row1.Cells(0).Shading.Color = Colors.LightGray
                    row1.Cells(0).VerticalAlignment = VerticalAlignment.Center
                    row1.Cells(0).MergeRight = 5
                    paragraph = row1.Cells(0).AddParagraph(Helper.MakeDateTimeValid(drVisitParts(0)("VisitDate")).ToLongDateString() & " / " &
                                                               Helper.MakeStringValid(drVisitParts(0)("Engineer")) & " / " &
                                                               Helper.MakeStringValid(drVisitParts(0)("JOWNo")) & " / " &
                                                               Helper.MakeStringValid(drVisitParts(0)("VisitNo")))

                    For Each drVisitPart As DataRow In drVisitParts
                        Dim row2 As Row = table.AddRow()
                        row2.Cells(0).AddParagraph(Helper.MakeStringValid(drVisitPart("Part")))
                        row2.Cells(1).AddParagraph(Helper.MakeStringValid(drVisitPart("MPN")) & " / " & Helper.MakeStringValid(drVisitPart("SPN")))
                        row2.Cells(2).AddParagraph(Helper.MakeStringValid(drVisitPart("Status")))
                        row2.Cells(3).AddParagraph(Helper.MakeStringValid(drVisitPart("Quantity")))
                        row2.Cells(4).AddParagraph(Helper.MakeDoubleValid(drVisitPart("Rate")).ToString("C"))
                        paragraph = row2.Cells(5).AddParagraph()
                        formattedText = paragraph.AddFormattedText(Helper.MakeDoubleValid(drVisitPart("Cost")).ToString("C"), TextFormat.Bold)

                        total += Helper.MakeDoubleValid(drVisitPart("Cost"))
                    Next
                Next

                row = table.AddRow()
                row.Borders.Visible = False

                row = table.AddRow()
                row.Cells(0).Borders.Visible = False
                paragraph = row.Cells(0).AddParagraph()
                formattedText = paragraph.AddFormattedText("Total", TextFormat.Bold)
                formattedText.Size = 10
                row.Cells(0).Format.Font.Bold = True
                row.Cells(0).Format.Alignment = ParagraphAlignment.Right
                row.Cells(0).MergeRight = 4
                row.Cells(5).Borders.Visible = False
                paragraph = row.Cells(5).AddParagraph()
                formattedText = paragraph.AddFormattedText(total.ToString("C"), TextFormat.Bold)
                formattedText.Size = 10
            End If
            Return total
        End Function

        Private Shared Function AddLabourToJobCost(job As Job, doc As Document) As Double
            Dim total As Double = 0.0

            Dim dvLabourCost As DataView = DB.EngineerVisitsTimeSheet.Get_CurrentCost_ByJobID(job.JobID)
            If dvLabourCost.Count > 0 Then
                Dim section As Section = doc.LastSection()
                Dim paragraph As Paragraph = section.AddParagraph()
                Dim tableHeader As Table = doc.LastSection.AddTable()
                tableHeader.Borders.Width = 0.25
                tableHeader.Borders.Left.Width = 0
                tableHeader.Borders.Right.Width = 0
                tableHeader.Rows.LeftIndent = 0
                tableHeader.TopPadding = 2.5
                tableHeader.BottomPadding = 2.5

                Dim columnHeader As Column = tableHeader.AddColumn(Unit.FromCentimeter(18))
                columnHeader.Format.Alignment = ParagraphAlignment.Center

                Dim rowHedaer As Row = tableHeader.AddRow()
                paragraph = rowHedaer.Cells(0).AddParagraph()
                Dim formattedText As FormattedText = paragraph.AddFormattedText("Labour", TextFormat.Bold)
                formattedText.Size = 12
                rowHedaer.Borders.Top.Width = 1
                rowHedaer.Borders.Bottom.Width = 1
                rowHedaer.Borders.Top.Color = Colors.Black
                rowHedaer.Borders.Bottom.Color = Colors.Black

                paragraph = section.AddParagraph()

                Dim table As Table = doc.LastSection.AddTable()
                DefineJobCostingTable(doc)
                table.Style = "Table"
                table.Borders.Color = Colors.DarkGray
                table.Borders.Width = 0.25
                table.Borders.Left.Width = 0.5
                table.Borders.Right.Width = 0.5
                table.Rows.LeftIndent = 0

                Dim column As Column = table.AddColumn(Unit.FromCentimeter(5)) 'part
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(5)) 'mpn / spn
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(3)) 'quantity
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(2)) 'status
                column.Format.Alignment = ParagraphAlignment.Left
                column = table.AddColumn(Unit.FromCentimeter(3)) 'unit cost
                column.Format.Alignment = ParagraphAlignment.Right

                Dim row As Row = table.AddRow()
                row.HeadingFormat = True
                row.Format.Alignment = ParagraphAlignment.Center
                row.Format.Font.Bold = True
                row.Shading.Color = Colors.LightGray
                row.Cells(0).AddParagraph("Visit Date / Engineer / J.O.W / Visit No.")
                row.Cells(0).Format.Font.Bold = False
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(0).VerticalAlignment = VerticalAlignment.Bottom
                row.Cells(0).MergeRight = 4

                row = table.AddRow()
                row.HeadingFormat = True
                row.Format.Alignment = ParagraphAlignment.Center
                row.Format.Font.Bold = True
                row.Shading.Color = Colors.LightBlue
                row.Cells(0).AddParagraph("Start")
                row.Cells(0).Format.Alignment = ParagraphAlignment.Left
                row.Cells(1).AddParagraph("End")
                row.Cells(1).Format.Alignment = ParagraphAlignment.Left
                row.Cells(2).AddParagraph("Difference")
                row.Cells(2).Format.Alignment = ParagraphAlignment.Left
                row.Cells(3).AddParagraph("Type")
                row.Cells(3).Format.Alignment = ParagraphAlignment.Left
                row.Cells(4).AddParagraph("Cost")
                row.Cells(4).Format.Alignment = ParagraphAlignment.Right

                Dim visitIds As List(Of Integer) = (From x In dvLabourCost.Table.AsEnumerable() Select x.Field(Of Integer)("EngineerVisitID")).Distinct().ToList()
                For Each visitId As Integer In visitIds
                    Dim drLabour As DataRow() = dvLabourCost.Table.Select("EngineerVisitID = " & visitId)

                    Dim row1 As Row = table.AddRow()
                    row1.TopPadding = 1.5
                    row1.Cells(0).Shading.Color = Colors.LightGray
                    row1.Cells(0).VerticalAlignment = VerticalAlignment.Center
                    row1.Cells(0).MergeRight = 4
                    paragraph = row1.Cells(0).AddParagraph(Helper.MakeDateTimeValid(drLabour(0)("VisitDate")).ToLongDateString() & " / " &
                                                               Helper.MakeStringValid(drLabour(0)("Engineer")) & " / " &
                                                               Helper.MakeStringValid(drLabour(0)("JOWNo")) & " / " &
                                                               Helper.MakeStringValid(drLabour(0)("VisitNo")))

                    For Each dr As DataRow In drLabour
                        Dim row2 As Row = table.AddRow()
                        row2.Cells(0).AddParagraph(Helper.MakeDateTimeValid(dr("TimesheetStart")))
                        row2.Cells(1).AddParagraph(Helper.MakeDateTimeValid(dr("TimesheetEnd")))
                        row2.Cells(2).AddParagraph(Helper.MakeStringValid(dr("DifferenceInMins")))
                        row2.Cells(3).AddParagraph(Helper.MakeStringValid(dr("TimesheetType")))
                        paragraph = row2.Cells(4).AddParagraph()
                        formattedText = paragraph.AddFormattedText(Helper.MakeDoubleValid(dr("LabourCost")).ToString("C"), TextFormat.Bold)

                        total += Helper.MakeDoubleValid(dr("LabourCost"))
                    Next
                Next

                row = table.AddRow()
                row.Borders.Visible = False

                row = table.AddRow()
                row.Cells(0).Borders.Visible = False
                paragraph = row.Cells(0).AddParagraph()
                formattedText = paragraph.AddFormattedText("Total", TextFormat.Bold)
                formattedText.Size = 10
                row.Cells(0).Format.Font.Bold = True
                row.Cells(0).Format.Alignment = ParagraphAlignment.Right
                row.Cells(0).MergeRight = 3
                row.Cells(4).Borders.Visible = False
                paragraph = row.Cells(4).AddParagraph()
                formattedText = paragraph.AddFormattedText(total.ToString("C"), TextFormat.Bold)
                formattedText.Size = 10
            End If
            Return total
        End Function

        Private Shared Function DefineJobCostingTable(doc As Document) As Style
            Dim style As Style = doc.Styles.AddStyle("Table", "Normal")
            style.Font.Name = "Verdana"
            style.Font.Name = "Times New Roman"
            style.Font.Size = 9
            Return style
        End Function

    End Class

End Namespace