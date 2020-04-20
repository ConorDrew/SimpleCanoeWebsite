using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Entity
{
    namespace Sys
    {
        public class Exporting
        {

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            private DataTable _Data = null;

            public DataTable Data
            {
                get
                {
                    return _Data;
                }

                set
                {
                    _Data = value;
                }
            }

            private Microsoft.Office.Interop.Excel.Application _excelApplication = null;

            private Microsoft.Office.Interop.Excel.Application ExcelApplication
            {
                get
                {
                    return _excelApplication;
                }

                set
                {
                    _excelApplication = value;
                }
            }

            private Microsoft.Office.Interop.Excel.Workbook _excelWorkBook = null;

            private Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook
            {
                get
                {
                    return _excelWorkBook;
                }

                set
                {
                    _excelWorkBook = value;
                }
            }

            private Microsoft.Office.Interop.Excel.Worksheet _excelWorkSheet = null;

            private Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet
            {
                get
                {
                    return _excelWorkSheet;
                }

                set
                {
                    _excelWorkSheet = value;
                }
            }

            private string _workSheetName = string.Empty;

            private string WorkSheetName
            {
                get
                {
                    return _workSheetName;
                }

                set
                {
                    _workSheetName = value;
                }
            }

            private string _FilePathToBeUsed = string.Empty;

            private string FilePathToBeUsed
            {
                get
                {
                    return _FilePathToBeUsed;
                }

                set
                {
                    _FilePathToBeUsed = value;
                }
            }

            private string _folderPath = string.Empty;

            private string FolderPath
            {
                get
                {
                    return _folderPath;
                }

                set
                {
                    _folderPath = value;
                }
            }

            private DataSet _DataSet = null;

            public DataSet DataSet
            {
                get
                {
                    return _DataSet;
                }

                set
                {
                    _DataSet = value;
                }
            }


            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            public Exporting(DataTable datatableIn, string workSheetNameIn, string folderPathIn = "", string filenameIn = "", DataSet DataSetin = null)
            {
                Data = datatableIn;
                WorkSheetName = workSheetNameIn;
                FolderPath = folderPathIn;
                FilePathToBeUsed = filenameIn;
                DataSet = DataSetin;
                Export();
            }

            private void Export()
            {
                string filePath = "";
                try
                {
                    if ((WorkSheetName ?? "") == "3rd Visits")
                    {
                        filePath = FolderPath + "3rdVisits.xls";
                    }
                    else if ((WorkSheetName ?? "") == "Servicing Statistics Report")
                    {
                        filePath = FolderPath;
                    }
                    else
                    {
                        var folderToSaveTo = new FolderBrowserDialog();
                        folderToSaveTo.ShowDialog();
                        if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                        {
                            App.ShowMessage("Operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            string fileName = "";
                            if ((WorkSheetName ?? "") == "Stock Take")
                            {
                                string title = "";
                                foreach (DataRow row in Data.Rows)
                                {
                                    if (title.Trim().Length == 0)
                                    {
                                        title = Strings.Replace(Conversions.ToString(row["Location"]), "*", "");
                                    }
                                    // title = row.Item("Location")
                                    else if (!((Strings.Replace(Conversions.ToString(row["Location"]), "*", "") ?? "") == (title ?? "")))
                                    {
                                        title = "Multiple_Locations";
                                        break;
                                    }
                                }

                                if (title.Trim().Length == 0)
                                {
                                    title = "No_Locations";
                                }

                                title = title.Replace("WAREHOUSE : ", "").Replace("VAN : ", "").Trim();
                                fileName = title + "_" + Strings.Format(DateAndTime.Now, "ddMMMyyyy");
                            }
                            else if (!string.IsNullOrEmpty(FilePathToBeUsed))
                            {
                                fileName = FilePathToBeUsed + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss");
                            }
                            else
                            {
                                fileName = "Export" + Strings.Format(DateAndTime.Now, "ddMMMyyyyHHmmss");
                            }

                            filePath = folderToSaveTo.SelectedPath + @"\" + fileName + ".xls";
                        }
                    }

                    Cursor.Current = Cursors.WaitCursor;
                    ExcelApplication = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApplication.DisplayAlerts = false;
                    ExcelWorkBook = ExcelApplication.Workbooks.Add();
                    ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelApplication.Worksheets[1];
                    if ((WorkSheetName ?? "") == "Servicing Statistics Report")
                    {
                        ServicingStatisticsReport(DataSet, filePath);
                    }
                    else
                    {
                        DropToExcel();
                        SpecialCase();
                        ExcelWorkSheet.Name = WorkSheetName;
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Error Exporting : " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    SaveAndDestroyExcel(filePath);
                    Cursor.Current = Cursors.Default;
                }
            }

            private void DropToExcel()
            {

                // System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-GB")
                int colCnt = Data.Columns.Count;
                int rowCnt = Data.Rows.Count;
                var a_dblNew = new object[rowCnt + 1 + 1, colCnt + 1];
                for (int i = 0, loopTo = colCnt - 1; i <= loopTo; i++)
                    a_dblNew[0, i] = Data.Columns[i].ColumnName;
                for (int rn = 1, loopTo1 = rowCnt; rn <= loopTo1; rn++)
                {
                    for (int cn = 0, loopTo2 = colCnt - 1; cn <= loopTo2; cn++)
                    {
                        var switchExpr = Data.Columns[cn].DataType.Name;
                        switch (switchExpr)
                        {
                            case "String":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeStringValid(Data.Rows[rn - 1][cn]).Trim();
                                    break;
                                }

                            case "Char":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeStringValid(Data.Rows[rn - 1][cn]).Trim();
                                    break;
                                }

                            case "Integer":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeIntegerValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "Int16":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeIntegerValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "Int24":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeIntegerValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "Int32":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeIntegerValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "Int64":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeIntegerValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "Double":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeDoubleValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "Decimal":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeDoubleValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "Float":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeDoubleValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "DateTime":
                                {
                                    if (Helper.MakeDateTimeValid(Data.Rows[rn - 1][cn]) == default)
                                    {
                                        a_dblNew[rn, cn] = "";
                                    }
                                    else
                                    {
                                        a_dblNew[rn, cn] = Conversions.ToDate(Strings.Format(Helper.MakeDateTimeValid(Data.Rows[rn - 1][cn]), "dd/MM/yyyy"));
                                    }

                                    break;
                                }

                            case "Date":
                                {
                                    if (Helper.MakeDateTimeValid(Data.Rows[rn - 1][cn]) == default)
                                    {
                                        a_dblNew[rn, cn] = "";
                                    }
                                    else
                                    {
                                        // a_dblNew(rn, cn) = CDate(Data.Rows(rn - 1).Item(cn))
                                        a_dblNew[rn, cn] = Conversions.ToDate(Strings.Format(Helper.MakeDateTimeValid(Data.Rows[rn - 1][cn]), "dd/MM/yyyy"));
                                    }

                                    break;
                                }

                            case "Boolean":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeBooleanValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "SByte":
                                {
                                    a_dblNew[rn, cn] = Helper.MakeBooleanValid(Data.Rows[rn - 1][cn]);
                                    break;
                                }

                            case "Byte[]":
                                {
                                    a_dblNew[rn, cn] = Data.Rows[rn - 1][cn].ToString();
                                    break;
                                }

                            default:
                                {
                                    a_dblNew[rn, cn] = Data.Rows[rn - 1][cn];
                                    break;
                                }
                        }
                    }
                }

                object objVals = a_dblNew;
                this.ExcelWorkSheet.get_Range(ExcelWorkSheet.Cells[1, 1], ExcelWorkSheet.Cells[rowCnt + 2, colCnt + 1]).Value;
                for (int col = 0, loopTo3 = Data.Columns.Count - 1; col <= loopTo3; col++)
                {
                    {
                        var withBlock = (Microsoft.Office.Interop.Excel.Range)ExcelWorkSheet.Cells[1, col + 1];
                        withBlock.Font.Bold = true;
                        withBlock.Font.ColorIndex = 2;
                        withBlock.NumberFormat = "@";
                        withBlock.Interior.ColorIndex = 11;
                        withBlock.EntireColumn.AutoFit();
                    }
                }

                for (int i = ExcelWorkBook.Worksheets.Count; i >= 1; i -= 1)
                {
                    if ((((Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(i)).Name ?? "") != (ExcelWorkSheet.Name ?? ""))
                    {
                        ((Microsoft.Office.Interop.Excel.Worksheet)this.ExcelWorkBook.Worksheets.get_Item(i)).Delete();
                    }
                }
            }

            private void SaveAndDestroyExcel(string filePath)
            {
                try
                {
                    if (filePath.Trim().Length > 0 & (WorkSheetName ?? "") != "Servicing Statistics Report")
                    {
                        System.IO.File.Delete(filePath);
                        ExcelWorkBook.SaveAs(filePath, Local: true);
                    }

                    KillInstances();
                    if (filePath.Trim().Length > 0 & (WorkSheetName ?? "") != "3rd Visits")
                    {
                        Helper.StartProcess(filePath);
                    }
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Error Exporting : " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void KillInstances()
            {
                ;
#error Cannot convert OnErrorResumeNextStatementSyntax - see comment for details
                /* Cannot convert OnErrorResumeNextStatementSyntax, CONVERSION ERROR: Conversion for OnErrorResumeNextStatement not implemented, please report this issue in 'On Error Resume Next' at character 14783


                Input:
                                On Error Resume Next

                 */
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelWorkSheet);
                ExcelWorkSheet = null;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelWorkBook);
                ExcelWorkBook = null;
                ExcelApplication.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApplication);
                ExcelApplication = null;
                GC.Collect();
                var mp = Process.GetProcessesByName("EXCEL");
                Process p;
                foreach (var p in mp)
                {
                    if (p.Responding)
                    {
                        if (string.IsNullOrEmpty(p.MainWindowTitle))
                        {
                            p.Kill();
                        }
                    }
                    else
                    {
                        p.Kill();
                    }
                };
#error Cannot convert OnErrorGoToStatementSyntax - see comment for details
                /* Cannot convert OnErrorGoToStatementSyntax, CONVERSION ERROR: Conversion for OnErrorGoToMinusOneStatement not implemented, please report this issue in 'On Error GoTo -1' at character 15850


                Input:

                                On Error GoTo -1

                 */
            }

            private void SpecialCase()
            {
                if (WorkSheetName.Contains("Timesheet"))
                {
                    Timesheets();
                }

                if (WorkSheetName.Contains("TS Summary"))
                {
                    var BadStyle = ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFBad");
                    BadStyle.Font.Bold = true;
                    BadStyle.Interior.Color = ColorTranslator.ToOle(Color.LightPink);
                    var WarnStyle = ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFWarn");
                    WarnStyle.Font.Bold = true;
                    WarnStyle.Interior.Color = ColorTranslator.ToOle(Color.Yellow);
                    var GoodStyle = ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFGood");
                    GoodStyle.Font.Bold = true;
                    GoodStyle.Interior.Color = ColorTranslator.ToOle(Color.LightGreen);
                    ExcelWorkSheet.Columns["B:B"].ColumnWidth = 15;
                    ExcelWorkSheet.Columns["C:C"].ColumnWidth = 15;
                    ExcelWorkSheet.Columns["D:D"].ColumnWidth = 15;
                    ExcelWorkSheet.Columns["E:E"].ColumnWidth = 15;
                    ExcelWorkSheet.Columns["F:F"].ColumnWidth = 15;
                    ExcelWorkSheet.Columns["G:G"].ColumnWidth = 20;
                    for (int i = 1, loopTo = Data.Rows.Count - 1; i <= loopTo; i++)
                    {
                        ExcelWorkSheet.Cells.get_Range("A" + i).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline);
                        ExcelWorkSheet.Cells.get_Range("B" + i).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline);
                        ExcelWorkSheet.Cells.get_Range("C" + i).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline);
                        ExcelWorkSheet.Cells.get_Range("D" + i).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline);
                        ExcelWorkSheet.Cells.get_Range("E" + i).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline);
                        ExcelWorkSheet.Cells.get_Range("F" + i).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline);
                        ExcelWorkSheet.Cells.get_Range("G" + i).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlHairline);
                        if (i == 1)
                        {
                            ExcelWorkSheet.Cells.get_Range("A1:G1").BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
                        }
                        else
                        {
                            if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("A" + i).Value != default))
                            {
                                if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("B" + i).Value >= 120))
                                {
                                    ExcelWorkSheet.Cells.get_Range("B" + i).Style = "CFBad";
                                }

                                ExcelWorkSheet.Cells.get_Range("B" + i).Value;
                            }

                            if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("A" + i).Value != default))
                            {
                                if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("C" + i).Value <= 300))
                                {
                                    ExcelWorkSheet.Cells.get_Range("C" + i).Style = "CFBad";
                                }

                                ExcelWorkSheet.Cells.get_Range("C" + i).Value;
                            }

                            if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("A" + i).Value != default))
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("D" + i).Value, 0, false)))
                                {
                                    ExcelWorkSheet.Cells.get_Range("D" + i).Style = "CFBad";
                                }

                                ExcelWorkSheet.Cells.get_Range("D" + i).Value;
                            }

                            if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("A" + i).Value != default))
                            {
                                if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("E" + i).Value >= 60))
                                {
                                    ExcelWorkSheet.Cells.get_Range("E" + i).Style = "CFBad";
                                }

                                ExcelWorkSheet.Cells.get_Range("E" + i).Value;
                            }

                            if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("A" + i).Value != default))
                            {
                                if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("F" + i).Value >= 20))
                                {
                                    ExcelWorkSheet.Cells.get_Range("F" + i).Style = "CFBad";
                                }

                                ExcelWorkSheet.Cells.get_Range("F" + i).Value;
                            }

                            if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("A" + i).Value != default))
                            {
                                if (Conversions.ToBoolean(ExcelWorkSheet.Cells.get_Range("G" + i).Value > 0))
                                {
                                    ExcelWorkSheet.Cells.get_Range("G" + i).Style = "CFWarn";
                                }

                                ExcelWorkSheet.Cells.get_Range("G" + i).Value;
                            }
                        }

                        ExcelWorkSheet.Cells.get_Range("B" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        ExcelWorkSheet.Cells.get_Range("C" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        ExcelWorkSheet.Cells.get_Range("D" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        ExcelWorkSheet.Cells.get_Range("E" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        ExcelWorkSheet.Cells.get_Range("F" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        ExcelWorkSheet.Cells.get_Range("G" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                    }

                    ExcelWorkSheet.Cells.get_Range("A2:G" + (Data.Rows.Count - 1)).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
                    ExcelWorkSheet.Cells.get_Range("A1:A" + (Data.Rows.Count - 1)).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
                    ExcelWorkSheet.Cells.get_Range("A" + (Data.Rows.Count - 1) + ":G" + (Data.Rows.Count - 1)).BorderAround(Weight: Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
                }

                var switchExpr = WorkSheetName;
                switch (switchExpr)
                {
                    case "Visit List":
                        {
                            for (int i = 1, loopTo1 = Data.Rows.Count + 1; i <= loopTo1; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("J" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("J" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("J" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("K" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("K" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("K" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("L" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("L" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("L" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("M" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("M" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("M" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("O" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("O" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("O" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("P" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("P" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("P" + i).NumberFormat = "£#,##0.00";
                            }

                            break;
                        }

                    case "Job List":
                        {
                            for (int i = 1, loopTo2 = Data.Rows.Count + 1; i <= loopTo2; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("L" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("L" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("L" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("M" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("M" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("M" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("N" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("N" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("N" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("O" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("O" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("O" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("P" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("P" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("P" + i).NumberFormat = "£#,##0.00";
                            }

                            break;
                        }

                    case "Quote List":
                        {
                            for (int i = 1, loopTo3 = Data.Rows.Count + 1; i <= loopTo3; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("F" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("F" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("F" + i).NumberFormat = "£#,##0.00";
                            }

                            break;
                        }

                    case "Contracts List":
                        {
                            for (int i = 1, loopTo4 = Data.Rows.Count + 1; i <= loopTo4; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("G" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("G" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("G" + i).NumberFormat = "£#,##0.00";
                            }

                            break;
                        }

                    case "Invoice List":
                        {
                            for (int i = 1, loopTo5 = Data.Rows.Count + 1; i <= loopTo5; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("H" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("H" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("H" + i).NumberFormat = "£#,##0.00";
                            }

                            break;
                        }

                    case "Invoiced List":
                        {
                            for (int i = 1, loopTo6 = Data.Rows.Count + 1; i <= loopTo6; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("H" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("H" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("H" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("M" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("M" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("M" + i).NumberFormat = "dd/MM/yyyy";
                            }

                            break;
                        }

                    case "Stock Value Report":
                        {
                            for (int i = 1, loopTo7 = Data.Rows.Count + 1; i <= loopTo7; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("E" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("E" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("E" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("F" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("F" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("F" + i).NumberFormat = "£#,##0.00";
                            }

                            break;
                        }

                    case "Stock Category Value Report":
                        {
                            for (int i = 1, loopTo8 = Data.Rows.Count + 1; i <= loopTo8; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("C" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("C" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("C" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("D" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("D" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("D" + i).NumberFormat = "£#,##0.00";
                            }

                            break;
                        }

                    case "Stock Used Report":
                        {
                            for (int i = 1, loopTo9 = Data.Rows.Count + 1; i <= loopTo9; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("A" + i).NumberFormat = "#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("F" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("F" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("F" + i).NumberFormat = "£#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("G" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("G" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("G" + i).NumberFormat = "#,##0";
                                ExcelWorkSheet.Cells.get_Range("H" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("H" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("H" + i).NumberFormat = "#,##0";
                                ExcelWorkSheet.Cells.get_Range("I" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("I" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("I" + i).NumberFormat = "#,##0";
                            }

                            break;
                        }

                    case "Stock Quantities":
                        {
                            for (int i = 1, loopTo10 = Data.Rows.Count + 1; i <= loopTo10; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("D" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("D" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("D" + i).NumberFormat = "#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("E" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("E" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("E" + i).NumberFormat = "#,##0.00";
                                ExcelWorkSheet.Cells.get_Range("F" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("F" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("F" + i).NumberFormat = "#,##0.00";
                            }

                            break;
                        }

                    case "Stock Take":
                        {
                            for (int i = 1, loopTo11 = Data.Rows.Count + 1; i <= loopTo11; i++)
                            {
                                ExcelWorkSheet.Cells.get_Range("J" + i).FormulaR1C1 = ExcelWorkSheet.Cells.get_Range("J" + i).FormulaR1C1 + " ";
                                ExcelWorkSheet.Cells.get_Range("J" + i).NumberFormat = "#,##0";
                            }

                            break;
                        }
                }
            }

            private void Timesheets()
            {
                ExcelWorkSheet.Columns["B:B"].wrapText = true;
                ExcelWorkSheet.Columns["C:C"].wrapText = true;
                ExcelWorkSheet.Columns["A:A"].ColumnWidth = 27.71;
                ExcelWorkSheet.Columns["B:B"].ColumnWidth = 37.29;
                ExcelWorkSheet.Columns["C:C"].ColumnWidth = 31.43;
                ExcelWorkSheet.Columns["D:D"].ColumnWidth = 42.86;
                var dtEngineers = App.DB.Engineer.Engineer_GetAll().Table;
                string days = "Monday Tuesday Wednesday Thursday Friday Saturday Sunday";
                ExcelWorkSheet.PageSetup.LeftHeader = WorkSheetName;
                ExcelWorkSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
                ExcelWorkSheet.PageSetup.FitToPagesWide = 1;
                ExcelWorkSheet.PageSetup.FitToPagesTall = 25;
                ExcelWorkSheet.PageSetup.Zoom = false;
                string summaryStart = "";
                string dayStart = "";
                string BorderLetter = "H";
                var dt = App.DB.Picklists.GetAll(Enums.PickListTypes.TimeSheetTypes).Table;
                // HOW FAR DOES THE TABLE STRETCH
                string theCell = Conversions.ToString(ExcelWorkSheet.Cells.get_Range("A" + 1).FormulaR1C1);
                int a = 65;
                int b = 65;
                int colcnt = 0;
                while (!string.IsNullOrEmpty(theCell))
                {
                    if (a > 90)
                    {
                        colcnt += 1;
                        theCell = Conversions.ToString(ExcelWorkSheet.Cells.get_Range(Conversions.ToString((char)65) + (char)b + 1).FormulaR1C1);
                        // If Chr(a) > "I" Then
                        ExcelWorkSheet.Cells.get_Range(Conversions.ToString((char)65) + (char)b + 1).FormulaR1C1 = "";
                        // End If
                        b += 1;
                    }
                    else
                    {
                        colcnt += 1;
                        theCell = Conversions.ToString(ExcelWorkSheet.Cells.get_Range(Conversions.ToString((char)a) + 1).FormulaR1C1);
                        // If Chr(a) > "I" Then
                        ExcelWorkSheet.Cells.get_Range(Conversions.ToString((char)a) + 1).FormulaR1C1 = "";
                        // End If
                    }

                    a += 1;
                }

                // '--top line
                if (colcnt > 26)
                {
                    {
                        var withBlock = ExcelWorkSheet.Cells.get_Range("A" + 1 + ":" + (char)65 + (char)(b - 1) + 1);
                        withBlock.Interior.ColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexNone;
                        withBlock.Font.ColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic;
                    }
                }
                else
                {
                    {
                        var withBlock1 = ExcelWorkSheet.Cells.get_Range("A" + 1 + ":" + (char)(colcnt + 64) + 1);
                        withBlock1.Interior.ColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexNone;
                        withBlock1.Font.ColorIndex = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic;
                    }
                }

                bool found = false;
                bool merged = false;
                bool NameOrDay = false;
                for (int i = 2, loopTo = Data.Rows.Count + 1; i <= loopTo; i++)
                {
                    if (ExcelWorkSheet.Cells.get_Range("B" + i).FormulaR1C1.ToString().Length > 0)
                    {
                        ExcelWorkSheet.Cells.get_Range("A" + i + ":h" + i).RowHeight = 25.5;
                        BorderLetter = "H";
                    }
                    else
                    {
                        for (int c = 72; c <= 82; c++)
                        {
                            if (ExcelWorkSheet.Cells.get_Range(Conversions.ToString((char)c) + i).FormulaR1C1.ToString().Length == 0)
                            {
                                BorderLetter = Conversions.ToString((char)(c - 1));
                                break;
                            }
                        }
                    }

                    NameOrDay = false;
                    // --------------SUMMARY BORDERS

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("B" + i).FormulaR1C1, "", false) & found == true))
                    {
                        found = false;
                        int j = i;
                        foreach (DataRow tst in dt.Rows)
                        {
                            if (colcnt > 26)
                            {
                                ExcelWorkSheet.Cells.get_Range("C" + j).Formula = "=SUM(D" + j + ":" + (char)65 + (char)(b - 1) + j + ")";
                                ExcelWorkSheet.Cells.get_Range("C" + j).NumberFormat = "[h]:mm"; // "dd:hh:mm" '"[$-F400]h:mm:ss AM/PM"
                            }
                            else
                            {
                                ExcelWorkSheet.Cells.get_Range("C" + j).Formula = "=SUM(D" + j + ":" + (char)(colcnt + 64) + j + ")";
                                ExcelWorkSheet.Cells.get_Range("C" + j).NumberFormat = "[h]:mm";
                            } // "dd:hh:mm" '"[$-F400]h:mm:ss AM/PM"

                            j += 1;
                        }

                        {
                            var withBlock2 = ExcelWorkSheet.Cells.get_Range(summaryStart + ":" + BorderLetter + (j - 1)).Select();
                            ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                            ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                            {
                                var withBlock3 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft);
                                withBlock3.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                withBlock3.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                            }

                            {
                                var withBlock4 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop);
                                withBlock4.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                withBlock4.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                            }

                            {
                                var withBlock5 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom);
                                withBlock5.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                withBlock5.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                            }

                            {
                                var withBlock6 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight);
                                withBlock6.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                withBlock6.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                            }

                            ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                            ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                        }
                    }

                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1, "SUMMARY", false) | Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1, "MASTER SUMMARY", false)))
                    {
                        merged = false;
                        found = true;
                        summaryStart = "A" + (i + 1);
                        if (colcnt > 26)
                        {
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)65 + (char)(b - 1) + i).Font.Bold = true;
                        }
                        else
                        {
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)(colcnt + 64) + i).Font.Bold = true;
                        }

                        // ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).Font.Bold = True
                        ExcelWorkSheet.Cells.get_Range("A" + i + ":A" + i).Font.Size = 14;
                        ExcelWorkSheet.Cells.get_Range("A" + i + ":A" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                        ExcelWorkSheet.Cells.get_Range("C" + i).Formula = "Total";
                    }

                    // ENGINEER FONT 
                    if (dtEngineers.Select(Conversions.ToString("Name='" + ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1 + "'")).Length > 0)
                    {
                        NameOrDay = true;
                        if (colcnt > 26)
                        {
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)65 + (char)(b - 1) + i).Font.Bold = true;
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)65 + (char)(b - 1) + i).Font.Size = 18;
                        }
                        else
                        {
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)(colcnt + 64) + i).Font.Bold = true;
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)(colcnt + 64) + i).Font.Size = 18;
                        }
                    }

                    // DAY FONT
                    if (Conversions.ToBoolean(days.Contains(Conversions.ToString(ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1)) & !Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1, "", false)))
                    {
                        NameOrDay = true;
                        if (colcnt > 26)
                        {
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)65 + (char)(b - 1) + i).Font.Bold = true;
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)65 + (char)(b - 1) + i).Font.Bold = true;
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)65 + (char)(b - 1) + i).Font.Size = 14;
                            ExcelWorkSheet.Cells.get_Range("B" + i + ":" + (char)65 + (char)(b - 1) + i).Font.Bold = true;
                            ExcelWorkSheet.Cells.get_Range("B" + i + ":" + (char)65 + (char)(b - 1) + i).Font.Size = 10;
                            ExcelWorkSheet.Cells.get_Range("B" + i + ":" + (char)65 + (char)(b - 1) + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                            ExcelWorkSheet.Cells.get_Range("B" + i + ":" + (char)65 + (char)(b - 1) + i).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        }
                        else
                        {
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)(colcnt + 64) + i).Font.Bold = true;
                            ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)(colcnt + 64) + i).Font.Size = 14;
                            ExcelWorkSheet.Cells.get_Range("B" + i + ":" + (char)(colcnt + 64) + i).Font.Bold = true;
                            ExcelWorkSheet.Cells.get_Range("B" + i + ":" + (char)(colcnt + 64) + i).Font.Size = 10;
                            ExcelWorkSheet.Cells.get_Range("B" + i + ":" + (char)(colcnt + 64) + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                            ExcelWorkSheet.Cells.get_Range("B" + i + ":" + (char)(colcnt + 64) + i).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        }

                        dayStart = "A" + (i + 1);
                    }

                    if (i > 1)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1, "", false)))
                        {
                            if (dayStart.Length > 0)
                            {
                                ExcelWorkSheet.Cells.get_Range(dayStart + ":H" + (i - 1)).Select();
                                ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                                ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone;
                                {
                                    var withBlock7 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft);
                                    withBlock7.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                    withBlock7.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                                }

                                {
                                    var withBlock8 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop);
                                    withBlock8.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                    withBlock8.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                                }

                                {
                                    var withBlock9 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom);
                                    withBlock9.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                    withBlock9.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                                }

                                {
                                    var withBlock10 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight);
                                    withBlock10.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                    withBlock10.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                                }

                                {
                                    var withBlock11 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical);
                                    withBlock11.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                    withBlock11.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                                }

                                if (ExcelWorkSheet.Cells.get_Range(dayStart + ":" + BorderLetter + (i - 1)).Rows.Count > 1)
                                {
                                    {
                                        var withBlock12 = ExcelApplication.Selection.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal);
                                        withBlock12.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                                        withBlock12.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                                    }
                                }
                            }

                            dayStart = "";
                        }
                        else if (NameOrDay == false)
                        {
                            if (colcnt > 26)
                            {
                                ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)65 + (char)(b - 1) + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                                ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)65 + (char)(b - 1) + i).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                            }
                            else
                            {
                                ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)(colcnt + 64) + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                                ExcelWorkSheet.Cells.get_Range("A" + i + ":" + (char)(colcnt + 64) + i).VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                            }
                            // ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).HorizontalAlignment = Excel.Constants.xlCenter
                            // ExcelWorkSheet.Cells.Range("A" & i & ":" & Chr(colcnt + 64) & i).VerticalAlignment = Excel.Constants.xlCenter

                            // COLOUR
                            if (dt.Select("Name='" + ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1.ToString().ToUpper() + "'").Length > 0)
                            {
                                if (ExcelWorkSheet.Cells.get_Range("B" + i).FormulaR1C1.ToString().Length > 0)
                                {
                                    ExcelWorkSheet.Cells.get_Range("A" + i + ":h" + i).Interior.ColorIndex = 44;
                                }
                                else
                                {
                                    ExcelWorkSheet.Cells.get_Range("A" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                                    ExcelWorkSheet.Cells.get_Range("A" + i).Font.Bold = true;
                                }
                            }

                            if ((ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1.ToString().ToUpper() ?? "") == "NON-CHARGEABLE" | (ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1.ToString().ToUpper() ?? "") == "UNACCOUNTED" | (ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1.ToString().ToUpper() ?? "") == "TOTAL HOURS > 17:00")

                            {
                                ExcelWorkSheet.Cells.get_Range("A" + i).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                                ExcelWorkSheet.Cells.get_Range("A" + i).Font.Bold = true;
                            }

                            // ----------------CELL MERGING 
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1, ExcelWorkSheet.Cells.get_Range("A" + (i - 1)).FormulaR1C1, false) & Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("B" + i).FormulaR1C1, ExcelWorkSheet.Cells.get_Range("B" + (i - 1)).FormulaR1C1, false) & Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("C" + i).FormulaR1C1, ExcelWorkSheet.Cells.get_Range("C" + (i - 1)).FormulaR1C1, false) & Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("D" + i).FormulaR1C1, ExcelWorkSheet.Cells.get_Range("D" + (i - 1)).FormulaR1C1, false)))


                            {
                                merged = true;
                                {
                                    var withBlock13 = ExcelWorkSheet.Cells.get_Range("A" + (i - 1) + ":A" + i);
                                    withBlock13.WrapText = true;
                                    withBlock13.MergeCells = true;
                                }

                                {
                                    var withBlock14 = ExcelWorkSheet.Cells.get_Range("B" + (i - 1) + ":B" + i);
                                    withBlock14.WrapText = true;
                                    withBlock14.MergeCells = true;
                                }

                                {
                                    var withBlock15 = ExcelWorkSheet.Cells.get_Range("C" + (i - 1) + ":C" + i);
                                    withBlock15.WrapText = true;
                                    withBlock15.MergeCells = true;
                                }

                                {
                                    var withBlock16 = ExcelWorkSheet.Cells.get_Range("D" + (i - 1) + ":D" + i);
                                    withBlock16.WrapText = true;
                                    withBlock16.MergeCells = true;
                                }
                            }
                            else if (merged)
                            {
                                // CHECK FURTHER BACK
                                for (int j = i - 2; j >= 2; j -= 1)
                                {
                                    if (Conversions.ToBoolean(!Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("A" + j).FormulaR1C1, "", false)))
                                    {
                                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("A" + i).FormulaR1C1, ExcelWorkSheet.Cells.get_Range("A" + j).FormulaR1C1, false) & Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("B" + i).FormulaR1C1, ExcelWorkSheet.Cells.get_Range("B" + j).FormulaR1C1, false) & Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("C" + i).FormulaR1C1, ExcelWorkSheet.Cells.get_Range("C" + j).FormulaR1C1, false) & Operators.ConditionalCompareObjectEqual(ExcelWorkSheet.Cells.get_Range("D" + i).FormulaR1C1, ExcelWorkSheet.Cells.get_Range("D" + j).FormulaR1C1, false)))


                                        {
                                            // MERGE WITH HIGHER UP
                                            {
                                                var withBlock17 = ExcelWorkSheet.Cells.get_Range("A" + j + ":A" + i);
                                                withBlock17.WrapText = true;
                                                withBlock17.MergeCells = true;
                                            }

                                            {
                                                var withBlock18 = ExcelWorkSheet.Cells.get_Range("B" + j + ":B" + i);
                                                withBlock18.WrapText = true;
                                                withBlock18.MergeCells = true;
                                            }

                                            {
                                                var withBlock19 = ExcelWorkSheet.Cells.get_Range("C" + j + ":C" + i);
                                                withBlock19.WrapText = true;
                                                withBlock19.MergeCells = true;
                                            }

                                            {
                                                var withBlock20 = ExcelWorkSheet.Cells.get_Range("D" + j + ":D" + i);
                                                withBlock20.WrapText = true;
                                                withBlock20.MergeCells = true;
                                            }
                                        }
                                        else
                                        {
                                            merged = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        merged = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                ExcelWorkSheet.Cells.get_Range("A1").Select();
            }

            private string formatTime(int Minutes)
            {
                if (Minutes < 0)
                {
                    return "00:00";
                }

                if (Minutes % 60 < 10)
                {
                    return Math.Floor(Minutes / (double)60) + ":0" + Minutes % 60;
                }
                else
                {
                    return Math.Floor(Minutes / (double)60) + ":" + Minutes % 60;
                }
            }

            public void ServicingStatisticsReport(DataSet Data, string filePath)
            {
                Microsoft.Office.Interop.Excel.Application excelApplication;
                Microsoft.Office.Interop.Excel.Workbook newWorkbook;
                Microsoft.Office.Interop.Excel.Worksheet targetSheet;
                var dataRange = default(Microsoft.Office.Interop.Excel.Range);
                var Categorylabelsrange = default(Microsoft.Office.Interop.Excel.Range);
                Microsoft.Office.Interop.Excel.Range Serieslabelsrange;
                Microsoft.Office.Interop.Excel.ChartObjects chartObjects;
                var newChartObject = default(Microsoft.Office.Interop.Excel.ChartObject);
                string paramWorkbookPath = filePath;
                object paramChartFormat = 1;
                object paramCategoryLabels = 0;
                object paramSeriesLabels = 0;
                bool paramHasLegend = true;
                string paramTitle = "Servicing per week";
                string paramCategoryTitle = "";
                string paramValueTitle = "";
                DataTable dt;
                excelApplication = new Microsoft.Office.Interop.Excel.Application();
                excelApplication.DisplayAlerts = false;
                newWorkbook = excelApplication.Workbooks.Add();
                for (int i = 0, loopTo = DataSet.Tables.Count - 1; i <= loopTo; i++)
                {
                    dt = DataSet.Tables[i];
                    if (dt.Rows.Count > 0)
                    {
                        targetSheet = (Microsoft.Office.Interop.Excel.Worksheet)newWorkbook.Worksheets[i + 1];
                        targetSheet.Name = dt.TableName;
                        DateTime Weekdate = default;
                        DateTime Comparedate = default;
                        int rowcount = 1;
                        int columncount = 1;
                        int totalrows = dt.Rows.Count;
                        bool HeaderAdded = false;
                        if ((dt.TableName ?? "") == "Visits Eng Breakdown (Actual)")
                        {
                            var dview = dt.DefaultView;
                            dview.Sort = "Weekdate ASC, EngineerName ASC";
                            dt = dview.ToTable();
                            // dt.DefaultView.Sort = "Weekdate ASC, EngineerName ASC"
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            var switchExpr = dt.TableName;
                            switch (switchExpr)
                            {
                                case "Overall Servicing":
                                    {
                                        string argCell = "A" + rowcount.ToString();
                                        object argValue = (object)row[0].ToString();
                                        SetCellValue(ref targetSheet, ref argCell, ref argValue);
                                        string argCell1 = "B" + rowcount.ToString();
                                        object argValue1 = (object)row[1].ToString();
                                        SetCellValue(ref targetSheet, ref argCell1, ref argValue1);
                                        rowcount += 1;
                                        break;
                                    }

                                case "Weekly Stats (FC)":
                                    {
                                        if (rowcount == 1 & HeaderAdded == false)
                                        {
                                            string argCell2 = "A" + rowcount.ToString();
                                            object argValue2 = (object)"";
                                            SetCellValue(ref targetSheet, ref argCell2, ref argValue2);
                                            string argCell3 = "B" + rowcount.ToString();
                                            object argValue3 = (object)"No of Services";
                                            SetCellValue(ref targetSheet, ref argCell3, ref argValue3);
                                            string argCell4 = "C" + rowcount.ToString();
                                            object argValue4 = (object)"1st Letter Stage";
                                            SetCellValue(ref targetSheet, ref argCell4, ref argValue4);
                                            string argCell5 = "D" + rowcount.ToString();
                                            object argValue5 = (object)"2nd Letter Stage";
                                            SetCellValue(ref targetSheet, ref argCell5, ref argValue5);
                                            string argCell6 = "E" + rowcount.ToString();
                                            object argValue6 = (object)"3rd Letter Stage";
                                            SetCellValue(ref targetSheet, ref argCell6, ref argValue6);
                                            string argCell7 = "F" + rowcount.ToString();
                                            object argValue7 = (object)"No of Safety Inspections";
                                            SetCellValue(ref targetSheet, ref argCell7, ref argValue7);
                                            // SetCellValue(targetSheet, "F" & rowcount.ToString, "Predicted 1st Visit Access Level")
                                            // SetCellValue(targetSheet, "G" & rowcount.ToString, "Predicted 2nd Visit Access Level")
                                            // SetCellValue(targetSheet, "H" & rowcount.ToString, "Predicted 3rd Visit Access Level")
                                            string argCell8 = "G" + rowcount.ToString();
                                            object argValue8 = (object)"Predicted 1st Visit Access Level";
                                            SetCellValue(ref targetSheet, ref argCell8, ref argValue8);
                                            string argCell9 = "H" + rowcount.ToString();
                                            object argValue9 = (object)"Predicted 2nd Visit Access Level";
                                            SetCellValue(ref targetSheet, ref argCell9, ref argValue9);
                                            string argCell10 = "I" + rowcount.ToString();
                                            object argValue10 = (object)"Predicted 3rd Visit Access Level";
                                            SetCellValue(ref targetSheet, ref argCell10, ref argValue10);
                                            HeaderAdded = true;
                                            string argCell11 = "A" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue11 = (object)row[0].ToString();
                                            SetCellValue(ref targetSheet, ref argCell11, ref argValue11);
                                            string argCell12 = "B" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue12 = (object)row[1].ToString();
                                            SetCellValue(ref targetSheet, ref argCell12, ref argValue12);
                                            string argCell13 = "C" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue13 = (object)row[2].ToString();
                                            SetCellValue(ref targetSheet, ref argCell13, ref argValue13);
                                            string argCell14 = "D" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue14 = (object)row[3].ToString();
                                            SetCellValue(ref targetSheet, ref argCell14, ref argValue14);
                                            string argCell15 = "E" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue15 = (object)row[4].ToString();
                                            SetCellValue(ref targetSheet, ref argCell15, ref argValue15);
                                            string argCell16 = "F" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue16 = (object)row[5].ToString();
                                            SetCellValue(ref targetSheet, ref argCell16, ref argValue16);
                                            // SetCellValue(targetSheet, "F" & rowcount + 1.ToString, row.Item(6).ToString)
                                            // SetCellValue(targetSheet, "G" & rowcount + 1.ToString, row.Item(7).ToString)
                                            // SetCellValue(targetSheet, "H" & rowcount + 1.ToString, row.Item(8).ToString)
                                            string argCell17 = "G" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue17 = (object)row[6].ToString();
                                            SetCellValue(ref targetSheet, ref argCell17, ref argValue17);
                                            string argCell18 = "H" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue18 = (object)row[7].ToString();
                                            SetCellValue(ref targetSheet, ref argCell18, ref argValue18);
                                            string argCell19 = "I" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue19 = (object)row[8].ToString();
                                            SetCellValue(ref targetSheet, ref argCell19, ref argValue19);
                                            rowcount += 1;
                                        }
                                        else
                                        {
                                            string argCell20 = "A" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue20 = (object)Conversions.ToDate(row[0].ToString());
                                            SetCellValue(ref targetSheet, ref argCell20, ref argValue20);
                                            string argCell21 = "B" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue21 = (object)row[1].ToString();
                                            SetCellValue(ref targetSheet, ref argCell21, ref argValue21);
                                            string argCell22 = "C" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue22 = (object)row[2].ToString();
                                            SetCellValue(ref targetSheet, ref argCell22, ref argValue22);
                                            string argCell23 = "D" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue23 = (object)row[3].ToString();
                                            SetCellValue(ref targetSheet, ref argCell23, ref argValue23);
                                            string argCell24 = "E" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue24 = (object)row[4].ToString();
                                            SetCellValue(ref targetSheet, ref argCell24, ref argValue24);
                                            string argCell25 = "F" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue25 = (object)row[5].ToString();
                                            SetCellValue(ref targetSheet, ref argCell25, ref argValue25);
                                            rowcount += 1;
                                        }

                                        break;
                                    }

                                case "Weekly Stats Engineers (FC)":
                                    {
                                        if (rowcount == 1 & HeaderAdded == false)
                                        {
                                            string argCell26 = "A" + rowcount.ToString();
                                            object argValue26 = (object)"";
                                            SetCellValue(ref targetSheet, ref argCell26, ref argValue26);
                                            string argCell27 = "B" + rowcount.ToString();
                                            object argValue27 = (object)"No of Engineers (Servicing)";
                                            SetCellValue(ref targetSheet, ref argCell27, ref argValue27);
                                            string argCell28 = "C" + rowcount.ToString();
                                            object argValue28 = (object)"No of Engineers (Safety Inspections)";
                                            SetCellValue(ref targetSheet, ref argCell28, ref argValue28);
                                            string argCell29 = "D" + rowcount.ToString();
                                            object argValue29 = (object)"Total No of Engineers";
                                            SetCellValue(ref targetSheet, ref argCell29, ref argValue29);
                                            HeaderAdded = true;
                                            string argCell30 = "A" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue30 = (object)row[0].ToString();
                                            SetCellValue(ref targetSheet, ref argCell30, ref argValue30);
                                            string argCell31 = "B" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue31 = (object)row[1].ToString();
                                            SetCellValue(ref targetSheet, ref argCell31, ref argValue31);
                                            string argCell32 = "C" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue32 = (object)row[2].ToString();
                                            SetCellValue(ref targetSheet, ref argCell32, ref argValue32);
                                            string argCell33 = "D" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue33 = (object)row[3].ToString();
                                            SetCellValue(ref targetSheet, ref argCell33, ref argValue33);
                                            rowcount += 1;
                                        }
                                        else
                                        {
                                            string argCell34 = "A" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue34 = (object)row[0].ToString();
                                            SetCellValue(ref targetSheet, ref argCell34, ref argValue34);
                                            string argCell35 = "B" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue35 = (object)row[1].ToString();
                                            SetCellValue(ref targetSheet, ref argCell35, ref argValue35);
                                            string argCell36 = "C" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue36 = (object)row[2].ToString();
                                            SetCellValue(ref targetSheet, ref argCell36, ref argValue36);
                                            string argCell37 = "D" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue37 = (object)row[3].ToString();
                                            SetCellValue(ref targetSheet, ref argCell37, ref argValue37);
                                            rowcount += 1;
                                        }

                                        break;
                                    }

                                case "Visits Booked (Actual)":
                                    {
                                        if (rowcount == 1 & HeaderAdded == false)
                                        {
                                            string argCell38 = "A" + rowcount.ToString();
                                            object argValue38 = (object)"Visit Start Date";
                                            SetCellValue(ref targetSheet, ref argCell38, ref argValue38);
                                            string argCell39 = "B" + rowcount.ToString();
                                            object argValue39 = (object)"Visit End Date";
                                            SetCellValue(ref targetSheet, ref argCell39, ref argValue39);
                                            string argCell40 = "C" + rowcount.ToString();
                                            object argValue40 = (object)"Site";
                                            SetCellValue(ref targetSheet, ref argCell40, ref argValue40);
                                            string argCell41 = "D" + rowcount.ToString();
                                            object argValue41 = (object)"Engineer";
                                            SetCellValue(ref targetSheet, ref argCell41, ref argValue41);
                                            string argCell42 = "E" + rowcount.ToString();
                                            object argValue42 = (object)"Letter Type";
                                            SetCellValue(ref targetSheet, ref argCell42, ref argValue42);
                                            string argCell43 = "E" + rowcount.ToString();
                                            object argValue43 = (object)"Job Number";
                                            SetCellValue(ref targetSheet, ref argCell43, ref argValue43);
                                            HeaderAdded = true;
                                            string argCell44 = "A" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue44 = (object)row[0].ToString();
                                            SetCellValue(ref targetSheet, ref argCell44, ref argValue44);
                                            string argCell45 = "B" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue45 = (object)row[1].ToString();
                                            SetCellValue(ref targetSheet, ref argCell45, ref argValue45);
                                            string argCell46 = "C" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue46 = (object)row[2].ToString();
                                            SetCellValue(ref targetSheet, ref argCell46, ref argValue46);
                                            string argCell47 = "D" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue47 = (object)row[3].ToString();
                                            SetCellValue(ref targetSheet, ref argCell47, ref argValue47);
                                            string argCell48 = "E" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue48 = (object)row[4].ToString();
                                            SetCellValue(ref targetSheet, ref argCell48, ref argValue48);
                                            string argCell49 = "E" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue49 = (object)row[5].ToString();
                                            SetCellValue(ref targetSheet, ref argCell49, ref argValue49);
                                            rowcount += 1;
                                        }
                                        else
                                        {
                                            string argCell50 = "A" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue50 = (object)row[0].ToString();
                                            SetCellValue(ref targetSheet, ref argCell50, ref argValue50);
                                            string argCell51 = "B" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue51 = (object)row[1].ToString();
                                            SetCellValue(ref targetSheet, ref argCell51, ref argValue51);
                                            string argCell52 = "C" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue52 = (object)row[2].ToString();
                                            SetCellValue(ref targetSheet, ref argCell52, ref argValue52);
                                            string argCell53 = "D" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue53 = (object)row[3].ToString();
                                            SetCellValue(ref targetSheet, ref argCell53, ref argValue53);
                                            string argCell54 = "E" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue54 = (object)row[4].ToString();
                                            SetCellValue(ref targetSheet, ref argCell54, ref argValue54);
                                            string argCell55 = "E" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue55 = (object)row[5].ToString();
                                            SetCellValue(ref targetSheet, ref argCell55, ref argValue55);
                                            rowcount += 1;
                                        }

                                        break;
                                    }

                                case "Visits Eng Breakdown (Actual)":
                                    {
                                        // If rowcount = 1 And HeaderAdded = False Then
                                        // SetCellValue(targetSheet, "A" & rowcount.ToString, "Weekdate")
                                        // SetCellValue(targetSheet, "B" & rowcount.ToString, "Engineer")
                                        // SetCellValue(targetSheet, "C" & rowcount.ToString, "Count")
                                        // HeaderAdded = True
                                        // SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                        // SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                        // SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                        // rowcount += 1
                                        // Else
                                        // SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                        // SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                        // SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                        // rowcount += 1
                                        // End If
                                        // Case "Visits Eng Breakdown (Actual)"
                                        if (string.IsNullOrEmpty(row[0].ToString()))
                                        {
                                            goto nextrow;
                                        }

                                        if (Weekdate == default) // create a new line
                                        {
                                            Weekdate = Conversions.ToDate(row[0].ToString()); // blank top left
                                                                                              // Engineer
                                                                                              // Date
                                                                                              // No of Visits
                                            ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
                                            /* Cannot convert ExpressionStatementSyntax, System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
                                               at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
                                               at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
                                            --- End of stack trace from previous location where exception was thrown ---
                                               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                               at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
                                            --- End of stack trace from previous location where exception was thrown ---
                                               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

                                            Input:
                                                                                    Me.SetCellValue(targetSheet, Me.GetCellRef("1", 1), "") 'blank top left

                                             */
                                            ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
                                            /* Cannot convert ExpressionStatementSyntax, System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
                                               at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
                                               at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
                                            --- End of stack trace from previous location where exception was thrown ---
                                               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                               at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
                                            --- End of stack trace from previous location where exception was thrown ---
                                               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

                                            Input:
                                                                                    Me.SetCellValue(targetSheet, Me.GetCellRef("2", 1), row.Item(1).ToString) 'Engineer

                                             */
                                            ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
                                            /* Cannot convert ExpressionStatementSyntax, System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
                                               at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
                                               at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
                                            --- End of stack trace from previous location where exception was thrown ---
                                               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                               at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
                                            --- End of stack trace from previous location where exception was thrown ---
                                               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

                                            Input:
                                                                                    Me.SetCellValue(targetSheet, Me.GetCellRef("1", 2), row.Item(0).ToString) 'Date

                                             */
                                            ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
                                            /* Cannot convert ExpressionStatementSyntax, System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
                                               at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
                                               at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
                                            --- End of stack trace from previous location where exception was thrown ---
                                               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                               at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
                                            --- End of stack trace from previous location where exception was thrown ---
                                               at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                               at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                               at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

                                            Input:
                                                                                    Me.SetCellValue(targetSheet, Me.GetCellRef("2", 2), row.Item(2).ToString) 'No of Visits

                                             */
                                            columncount = 3;
                                            rowcount = 2;
                                        }
                                        else // check against the rows date to see if changed
                                        {
                                            Comparedate = Conversions.ToDate(row[0].ToString());
                                            if (Comparedate == Weekdate) // it matches stay on this line
                                            {
                                                if (rowcount == 2) // Engineer
                                                {
                                                    ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
                                                    /* Cannot convert ExpressionStatementSyntax, System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
                                                       at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
                                                       at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
                                                    --- End of stack trace from previous location where exception was thrown ---
                                                       at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                                       at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                                       at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
                                                    --- End of stack trace from previous location where exception was thrown ---
                                                       at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                                       at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                                       at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

                                                    Input:
                                                                                                    Me.SetCellValue(targetSheet, Me.GetCellRef(CStr(columncount), rowcount - 1), row.Item(1).ToString) 'Engineer

                                                     */
                                                }; // No of Visits
#error Cannot convert ExpressionStatementSyntax - see comment for details
                                                /* Cannot convert ExpressionStatementSyntax, System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
                                                   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
                                                   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
                                                --- End of stack trace from previous location where exception was thrown ---
                                                   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                                   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
                                                --- End of stack trace from previous location where exception was thrown ---
                                                   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                                   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

                                                Input:
                                                                                            Me.SetCellValue(targetSheet, Me.GetCellRef(CStr(columncount), rowcount), row.Item(2).ToString) 'No of Visits

                                                 */
                                                columncount += 1;
                                            }
                                            else // create a new line
                                            {
                                                rowcount += 1;
                                                // SetCellValue(targetSheet, GetCellRef(CStr(columncount), rowcount), row.Item(1).ToString) 'Engineer
                                                columncount = 2; // Date
                                                                 // No of Visits
                                                ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
                                                /* Cannot convert ExpressionStatementSyntax, System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
                                                   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
                                                   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
                                                --- End of stack trace from previous location where exception was thrown ---
                                                   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                                   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
                                                --- End of stack trace from previous location where exception was thrown ---
                                                   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                                   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

                                                Input:
                                                                                            Me.SetCellValue(targetSheet, Me.GetCellRef("1", rowcount), row.Item(0).ToString) 'Date

                                                 */
                                                ;
#error Cannot convert ExpressionStatementSyntax - see comment for details
                                                /* Cannot convert ExpressionStatementSyntax, System.Collections.Generic.KeyNotFoundException: The given key was not present in the dictionary.
                                                   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
                                                   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<CreateLocals>d__7.MoveNext()
                                                --- End of stack trace from previous location where exception was thrown ---
                                                   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                                   at ICSharpCode.CodeConverter.CSharp.ByRefParameterVisitor.<AddLocalVariables>d__6.MoveNext()
                                                --- End of stack trace from previous location where exception was thrown ---
                                                   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
                                                   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
                                                   at ICSharpCode.CodeConverter.CSharp.CommentConvertingMethodBodyVisitor.<DefaultVisitInnerAsync>d__3.MoveNext()

                                                Input:
                                                                                            'SetCellValue(targetSheet, GetCellRef(CStr(columncount), rowcount), row.Item(1).ToString) 'Engineer
                                                                                            Me.SetCellValue(targetSheet, Me.GetCellRef(CStr(columncount), rowcount), row.Item(2).ToString) 'No of Visits

                                                 */
                                                Weekdate = Comparedate;
                                                columncount += 1;
                                            }
                                        }
                                    // If rowcount = 3 Then
                                    // GoTo skipchart
                                    // End If

                                    // If rowcount = 1 And HeaderAdded = False Then
                                    // SetCellValue(targetSheet, "A" & rowcount.ToString, "VisitDate")
                                    // SetCellValue(targetSheet, "B" & rowcount.ToString, "Engineer")
                                    // SetCellValue(targetSheet, "C" & rowcount.ToString, "EngineerTotal")
                                    // 'SetCellValue(targetSheet, "D" & rowcount.ToString, "Engineer")
                                    // 'SetCellValue(targetSheet, "E" & rowcount.ToString, "Letter Type")
                                    // HeaderAdded = True
                                    // SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                    // SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                    // SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                    // 'SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                    // 'SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(4).ToString)
                                    // rowcount += 1
                                    // Else
                                    // SetCellValue(targetSheet, "A" & rowcount + 1.ToString, row.Item(0).ToString)
                                    // SetCellValue(targetSheet, "B" & rowcount + 1.ToString, row.Item(1).ToString)
                                    // SetCellValue(targetSheet, "C" & rowcount + 1.ToString, row.Item(2).ToString)
                                    // 'SetCellValue(targetSheet, "D" & rowcount + 1.ToString, row.Item(3).ToString)
                                    // 'SetCellValue(targetSheet, "E" & rowcount + 1.ToString, row.Item(4).ToString)
                                    // rowcount += 1
                                    // End If
                                    nextrow:
                                        ;
                                        break;
                                    }

                                case "First Letter Stage Sites":
                                case "Second Letter Stage Sites":
                                case "Third Letter Stage Sites":
                                    {
                                        // For j As Integer = 0 To row.Table.Columns.Count - 1
                                        // SetCellValueNoRange(targetSheet, j + 1.ToString & "," & rowcount.ToString, row.Item(j).ToString)
                                        // Next
                                        if (rowcount == 1 & HeaderAdded == false)
                                        {
                                            string argCell64 = "A" + rowcount.ToString();
                                            object argValue64 = (object)"UPRN";
                                            SetCellValue(ref targetSheet, ref argCell64, ref argValue64);
                                            string argCell65 = "B" + rowcount.ToString();
                                            object argValue65 = (object)"Address1";
                                            SetCellValue(ref targetSheet, ref argCell65, ref argValue65);
                                            string argCell66 = "C" + rowcount.ToString();
                                            object argValue66 = (object)"Postcode";
                                            SetCellValue(ref targetSheet, ref argCell66, ref argValue66);
                                            string argCell67 = "D" + rowcount.ToString();
                                            object argValue67 = (object)"Site Fuel";
                                            SetCellValue(ref targetSheet, ref argCell67, ref argValue67);
                                            string argCell68 = "E" + rowcount.ToString();
                                            object argValue68 = (object)"Last Service Date";
                                            SetCellValue(ref targetSheet, ref argCell68, ref argValue68);
                                            HeaderAdded = true;
                                            string argCell69 = "A" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue69 = (object)row[2].ToString();
                                            SetCellValue(ref targetSheet, ref argCell69, ref argValue69);
                                            string argCell70 = "B" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue70 = (object)row[5].ToString();
                                            SetCellValue(ref targetSheet, ref argCell70, ref argValue70);
                                            string argCell71 = "C" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue71 = (object)row[6].ToString();
                                            SetCellValue(ref targetSheet, ref argCell71, ref argValue71);
                                            string argCell72 = "D" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue72 = (object)row[7].ToString();
                                            SetCellValue(ref targetSheet, ref argCell72, ref argValue72);
                                            string argCell73 = "E" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue73 = (object)Strings.FormatDateTime(Conversions.ToDate(row[8].ToString()), DateFormat.ShortDate);
                                            SetCellValue(ref targetSheet, ref argCell73, ref argValue73);
                                            rowcount += 1;
                                        }
                                        else
                                        {
                                            string argCell74 = "A" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue74 = (object)row[2].ToString();
                                            SetCellValue(ref targetSheet, ref argCell74, ref argValue74);
                                            string argCell75 = "B" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue75 = (object)row[5].ToString();
                                            SetCellValue(ref targetSheet, ref argCell75, ref argValue75);
                                            string argCell76 = "C" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue76 = (object)row[6].ToString();
                                            SetCellValue(ref targetSheet, ref argCell76, ref argValue76);
                                            string argCell77 = "D" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue77 = (object)row[7].ToString();
                                            SetCellValue(ref targetSheet, ref argCell77, ref argValue77);
                                            string argCell78 = "E" + ((double)rowcount + Conversions.ToDouble(1.ToString()));
                                            object argValue78 = (object)Strings.FormatDateTime(Conversions.ToDate(row[8].ToString()), DateFormat.ShortDate);
                                            SetCellValue(ref targetSheet, ref argCell78, ref argValue78);
                                            rowcount += 1;
                                        }

                                        break;
                                    }
                                    // SetCellValue(targetSheet, "D" & rowcount.ToString, row.Item(3).ToString)
                                    // SetCellValue(targetSheet, "E" & rowcount.ToString, row.Item(4).ToString)
                                    // SetCellValue(targetSheet, "F" & rowcount.ToString, row.Item(5).ToString)
                                    // SetCellValue(targetSheet, "G" & rowcount.ToString, row.Item(6).ToString)
                                    // SetCellValue(targetSheet, "H" & rowcount.ToString, row.Item(7).ToString)
                                    // SetCellValue(targetSheet, "I" & rowcount.ToString, row.Item(8).ToString)
                                    // SetCellValue(targetSheet, "J" & rowcount.ToString, row.Item(9).ToString)
                                    // rowcount += 1
                            }
                        }

                        HeaderAdded = false;
                        var switchExpr1 = dt.TableName;
                        switch (switchExpr1)
                        {
                            case "Overall Servicing":
                                {
                                    dataRange = targetSheet.get_Range("A1", "B" + ((double)rowcount - Conversions.ToDouble(1.ToString())));
                                    Categorylabelsrange = targetSheet.get_Range("A1", "A" + ((double)rowcount - Conversions.ToDouble(1.ToString())));
                                    break;
                                }

                            case "Weekly Stats (FC)":
                                {
                                    // dataRange = targetSheet.Range("A1", "E" & rowcount.ToString)
                                    // Categorylabelsrange = targetSheet.Range("A1", "A" & rowcount.ToString)
                                    dataRange = targetSheet.get_Range("A1", "F" + rowcount.ToString());
                                    Categorylabelsrange = targetSheet.get_Range("A1", "A" + rowcount.ToString());
                                    break;
                                }
                            // Serieslabelsrange = targetSheet.Range("A1", "E1")
                            case "Weekly Stats Engineers (FC)":
                                {
                                    dataRange = targetSheet.get_Range("A1", "D" + rowcount.ToString());
                                    Categorylabelsrange = targetSheet.get_Range("A1", "A" + rowcount.ToString());
                                    break;
                                }

                            case "Visits Eng Breakdown (Actual)":
                                {
                                    dataRange = targetSheet.get_Range("A1", GetCellRef(ref (columncount - 1).ToString(), ref rowcount));
                                    Categorylabelsrange = targetSheet.get_Range("A1", "A" + rowcount.ToString());
                                    break;
                                }

                            case "First Letter Stage Sites":
                            case "Second Letter Stage Sites":
                            case "Third Letter Stage Sites":
                            case "Visits Booked (Actual)":
                                {
                                    goto skipchart;
                                    break;
                                }
                        }

                        chartObjects = (Microsoft.Office.Interop.Excel.ChartObjects)targetSheet.ChartObjects();
                        var switchExpr2 = dt.TableName;
                        switch (switchExpr2)
                        {
                            case "Overall Servicing":
                                {
                                    newChartObject = chartObjects.Add((double)450, (double)30, (double)300, (double)300);
                                    paramTitle = "Overall Servicing";
                                    newChartObject.Chart.ChartWizard(dataRange, Microsoft.Office.Interop.Excel.XlChartType.xl3DColumn, paramChartFormat, Microsoft.Office.Interop.Excel.XlRowCol.xlRows, Categorylabelsrange, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle);
                                    break;
                                }

                            case "Weekly Stats (FC)":
                                {
                                    newChartObject = chartObjects.Add((double)450, (double)30, (double)1000, (double)600);
                                    paramTitle = "Servicing per Week Forecast";
                                    newChartObject.Chart.ChartWizard(dataRange, Microsoft.Office.Interop.Excel.XlChartType.xlLineMarkers, paramChartFormat, Microsoft.Office.Interop.Excel.XlRowCol.xlRows, paramSeriesLabels, Categorylabelsrange, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle);
                                    dataRange.EntireColumn.AutoFit();
                                    break;
                                }
                            // Chart1.Series(0).Color = Color.Red
                            // newChartObject.Plot.SeriesCollection(5).DataPoints(1).Brush.FillColor.Set(234, 30, 224)

                            // newChartObject.Chart.Plot.SeriesCollection(5).DataPoints(1).Brush.FillColor.Set(234, 30, 224)
                            // Dim legend As Excel.LegendEntry = newChartObject.Chart.Legend.LegendEntries(4)
                            // Dim series As Excel.Series = newChartObject.Chart.FullSeriesCollection(5)
                            // newChartObject.Chart.SeriesCollection(5)
                            // series.color = Color.HotPink

                            // newChartObject.Chart.FullSeriesCollection(5).border.color = New Integer(Color.HotPink)
                            // newChartObject.Chart.FullSeriesCollection(5).Interior.Color = Color.HotPink.ToArgb
                            // series.Interior.Color = Color.HotPink
                            // legend.LegendKey.Interior.Color = 15343328
                            // series.Border.Color = 15343328
                            // 'series.Fill.ForeColor = RGB(234, 30, 224)
                            // series.MarkerForegroundColor = Color.HotPink.ToArgb
                            // series.MarkerBackgroundColor = Color.HotPink.ToArgb
                            // 'series.MarkerForegroundColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                            case "Weekly Stats Engineers (FC)":
                                {
                                    newChartObject = chartObjects.Add((double)450, (double)30, (double)300, (double)300);
                                    paramTitle = "Engineers Required per week Forecast";
                                    newChartObject.Chart.ChartWizard(dataRange, Microsoft.Office.Interop.Excel.XlChartType.xlLineMarkers, paramChartFormat, Microsoft.Office.Interop.Excel.XlRowCol.xlRows, paramSeriesLabels, Categorylabelsrange, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle);
                                    break;
                                }

                            case "Visits Eng Breakdown (Actual)":
                                {
                                    newChartObject = chartObjects.Add((double)50, (double)175, (double)800, (double)300);
                                    paramTitle = "Engineers Visits Booked";
                                    newChartObject.Chart.ChartWizard(dataRange, Microsoft.Office.Interop.Excel.XlChartType.xlLineMarkers, paramChartFormat, Microsoft.Office.Interop.Excel.XlRowCol.xlRows, paramSeriesLabels, Categorylabelsrange, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle);
                                    break;
                                }
                        }

                        newChartObject.Chart.SetSourceData(dataRange);
                        newChartObject.Chart.SeriesCollection();
                        Microsoft.Office.Interop.Excel.Axis axis = (Microsoft.Office.Interop.Excel.Axis)newChartObject.Chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory);
                        axis.HasMajorGridlines = true;
                        axis.MajorGridlines.Border.Color = Color.Gray.ToArgb();
                        axis.MajorGridlines.Border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        // axis.MajorGridlines.Format.Line.Transparency = 0.8
                        axis.CategoryType = Microsoft.Office.Interop.Excel.XlCategoryType.xlCategoryScale;
                    skipchart:
                        ;
                        newWorkbook.Worksheets.Add(After: targetSheet, Count: 1);
                    }
                }

                targetSheet = (Microsoft.Office.Interop.Excel.Worksheet)newWorkbook.Worksheets[1];
                targetSheet.Activate();
                newWorkbook.SaveAs(paramWorkbookPath);

                // Release the references to the Excel objects.
                newChartObject = null;
                chartObjects = null;
                dataRange = null;
                targetSheet = null;

                // Close and release the Workbook object.
                if (newWorkbook is object)
                {
                    newWorkbook.Close(false);
                    newWorkbook = null;
                }

                // Quit Excel and release the ApplicationClass object.
                if (excelApplication is object)
                {
                    excelApplication.Quit();
                    excelApplication = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            public void ServicingStatisticsReportWorking()
            {
                Microsoft.Office.Interop.Excel.Application excelApplication;
                Microsoft.Office.Interop.Excel.Workbook newWorkbook;
                Microsoft.Office.Interop.Excel.Worksheet targetSheet;
                Microsoft.Office.Interop.Excel.Range dataRange;
                Microsoft.Office.Interop.Excel.Range Categorylabelsrange;
                Microsoft.Office.Interop.Excel.ChartObjects chartObjects;
                Microsoft.Office.Interop.Excel.ChartObject newChartObject;
                string paramWorkbookPath = @"C:\Temp\Test.xlsx";
                object paramChartFormat = 1;
                object paramCategoryLabels = 0;
                object paramSeriesLabels = 0;
                bool paramHasLegend = true;
                string paramTitle = "Servicing per week";
                string paramCategoryTitle = "";
                string paramValueTitle = "";
                excelApplication = new Microsoft.Office.Interop.Excel.Application();
                excelApplication.DisplayAlerts = false;
                // ExcelWorkBook = excelApplication.Workbooks.Add
                // ExcelWorkSheet = DirectCast(excelApplication.Worksheets(1), Excel.Worksheet)


                newWorkbook = excelApplication.Workbooks.Add();
                targetSheet = (Microsoft.Office.Interop.Excel.Worksheet)newWorkbook.Worksheets[1];
                targetSheet.Name = "Quarterly Sales";
                string argCell = "A2";
                object argValue = "Week 1";
                SetCellValue(ref targetSheet, ref argCell, ref argValue);
                string argCell1 = "A3";
                object argValue1 = "Week 2";
                SetCellValue(ref targetSheet, ref argCell1, ref argValue1);
                string argCell2 = "A4";
                object argValue2 = "Week 3";
                SetCellValue(ref targetSheet, ref argCell2, ref argValue2);
                string argCell3 = "A5";
                object argValue3 = "Week 4";
                SetCellValue(ref targetSheet, ref argCell3, ref argValue3);
                string argCell4 = "B1";
                object argValue4 = "# of services";
                SetCellValue(ref targetSheet, ref argCell4, ref argValue4);
                string argCell5 = "B2";
                object argValue5 = 1.5;
                SetCellValue(ref targetSheet, ref argCell5, ref argValue5);
                string argCell6 = "B3";
                object argValue6 = 2;
                SetCellValue(ref targetSheet, ref argCell6, ref argValue6);
                string argCell7 = "B4";
                object argValue7 = 2.25;
                SetCellValue(ref targetSheet, ref argCell7, ref argValue7);
                string argCell8 = "B5";
                object argValue8 = 2.5;
                SetCellValue(ref targetSheet, ref argCell8, ref argValue8);
                // SetCellValue(targetSheet, "C1", "Q2")
                // SetCellValue(targetSheet, "C2", 2)
                // SetCellValue(targetSheet, "C3", 1.75)
                // SetCellValue(targetSheet, "C4", 2)
                // SetCellValue(targetSheet, "C5", 2.5)
                // SetCellValue(targetSheet, "D1", "Q3")
                // SetCellValue(targetSheet, "D2", 1.5)
                // SetCellValue(targetSheet, "D3", 2)
                // SetCellValue(targetSheet, "D4", 2.5)
                // SetCellValue(targetSheet, "D5", 2)
                // SetCellValue(targetSheet, "E1", "Q4")
                // SetCellValue(targetSheet, "E2", 2.5)
                // SetCellValue(targetSheet, "E3", 2)
                // SetCellValue(targetSheet, "E4", 2)
                // SetCellValue(targetSheet, "E5", 2.75)
                dataRange = targetSheet.get_Range("A1", "B5");
                Categorylabelsrange = targetSheet.get_Range("A2", "A5");
                chartObjects = (Microsoft.Office.Interop.Excel.ChartObjects)targetSheet.ChartObjects();
                newChartObject = chartObjects.Add(185, 30, 300, 300);
                newChartObject.Chart.ChartWizard(dataRange, Microsoft.Office.Interop.Excel.XlChartType.xlLineMarkers, paramChartFormat, Microsoft.Office.Interop.Excel.XlRowCol.xlRows, Categorylabelsrange, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle);


                newChartObject.Chart.SetSourceData(dataRange);
                newChartObject.Chart.SeriesCollection();
                Microsoft.Office.Interop.Excel.Axis axis = (Microsoft.Office.Interop.Excel.Axis)newChartObject.Chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory);
                axis.HasMajorGridlines = true;
                axis.MajorGridlines.Border.Color = Color.Gray.ToArgb();
                axis.MajorGridlines.Border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                // axis.MajorGridlines.Format.Line.Transparency = 0.8

                // newChartObject.Shapes.AddChart2(227, Excel.XlChartType.xlLine).Select()
                // newChartObject.SetSourceData(Source:=dataRange)
                // newChartObject.FullSeriesCollection(1).Select()
                // newChartObject.ChartArea.Select()
                // newChartObject.ChartType = Excel.XlChartType.xlLineMarkers



                newWorkbook.SaveAs(paramWorkbookPath);
                // paramCategoryLabels
                // Release the references to the Excel objects.
                newChartObject = null;
                chartObjects = null;
                dataRange = null;
                targetSheet = null;

                // Close and release the Workbook object.
                if (newWorkbook is object)
                {
                    newWorkbook.Close(false);
                    newWorkbook = null;
                }

                // Quit Excel and release the ApplicationClass object.
                if (excelApplication is object)
                {
                    excelApplication.Quit();
                    excelApplication = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            public void ServicingStatisticsReportOriginal()
            {
                Microsoft.Office.Interop.Excel.Application excelApplication;
                Microsoft.Office.Interop.Excel.Workbook newWorkbook;
                Microsoft.Office.Interop.Excel.Worksheet targetSheet;
                Microsoft.Office.Interop.Excel.Range dataRange;
                Microsoft.Office.Interop.Excel.ChartObjects chartObjects;
                Microsoft.Office.Interop.Excel.ChartObject newChartObject;
                string paramWorkbookPath = @"C:\Temp\Test.xlsx";
                object paramChartFormat = 1;
                object paramCategoryLabels = 0;
                object paramSeriesLabels = 0;
                bool paramHasLegend = true;
                string paramTitle = "Sales by Quarter";
                string paramCategoryTitle = "Fiscal Quarter";
                string paramValueTitle = "Billions";
                excelApplication = new Microsoft.Office.Interop.Excel.Application();
                excelApplication.DisplayAlerts = false;
                // ExcelWorkBook = excelApplication.Workbooks.Add
                // ExcelWorkSheet = DirectCast(excelApplication.Worksheets(1), Excel.Worksheet)


                newWorkbook = excelApplication.Workbooks.Add();
                targetSheet = (Microsoft.Office.Interop.Excel.Worksheet)newWorkbook.Worksheets[1];
                targetSheet.Name = "Quarterly Sales";
                string argCell = "A2";
                object argValue = "N. America";
                SetCellValue(ref targetSheet, ref argCell, ref argValue);
                string argCell1 = "A3";
                object argValue1 = "S. America";
                SetCellValue(ref targetSheet, ref argCell1, ref argValue1);
                string argCell2 = "A4";
                object argValue2 = "Europe";
                SetCellValue(ref targetSheet, ref argCell2, ref argValue2);
                string argCell3 = "A5";
                object argValue3 = "Asia";
                SetCellValue(ref targetSheet, ref argCell3, ref argValue3);
                string argCell4 = "B1";
                object argValue4 = "Q1";
                SetCellValue(ref targetSheet, ref argCell4, ref argValue4);
                string argCell5 = "B2";
                object argValue5 = 1.5;
                SetCellValue(ref targetSheet, ref argCell5, ref argValue5);
                string argCell6 = "B3";
                object argValue6 = 2;
                SetCellValue(ref targetSheet, ref argCell6, ref argValue6);
                string argCell7 = "B4";
                object argValue7 = 2.25;
                SetCellValue(ref targetSheet, ref argCell7, ref argValue7);
                string argCell8 = "B5";
                object argValue8 = 2.5;
                SetCellValue(ref targetSheet, ref argCell8, ref argValue8);
                string argCell9 = "C1";
                object argValue9 = "Q2";
                SetCellValue(ref targetSheet, ref argCell9, ref argValue9);
                string argCell10 = "C2";
                object argValue10 = 2;
                SetCellValue(ref targetSheet, ref argCell10, ref argValue10);
                string argCell11 = "C3";
                object argValue11 = 1.75;
                SetCellValue(ref targetSheet, ref argCell11, ref argValue11);
                string argCell12 = "C4";
                object argValue12 = 2;
                SetCellValue(ref targetSheet, ref argCell12, ref argValue12);
                string argCell13 = "C5";
                object argValue13 = 2.5;
                SetCellValue(ref targetSheet, ref argCell13, ref argValue13);
                string argCell14 = "D1";
                object argValue14 = "Q3";
                SetCellValue(ref targetSheet, ref argCell14, ref argValue14);
                string argCell15 = "D2";
                object argValue15 = 1.5;
                SetCellValue(ref targetSheet, ref argCell15, ref argValue15);
                string argCell16 = "D3";
                object argValue16 = 2;
                SetCellValue(ref targetSheet, ref argCell16, ref argValue16);
                string argCell17 = "D4";
                object argValue17 = 2.5;
                SetCellValue(ref targetSheet, ref argCell17, ref argValue17);
                string argCell18 = "D5";
                object argValue18 = 2;
                SetCellValue(ref targetSheet, ref argCell18, ref argValue18);
                string argCell19 = "E1";
                object argValue19 = "Q4";
                SetCellValue(ref targetSheet, ref argCell19, ref argValue19);
                string argCell20 = "E2";
                object argValue20 = 2.5;
                SetCellValue(ref targetSheet, ref argCell20, ref argValue20);
                string argCell21 = "E3";
                object argValue21 = 2;
                SetCellValue(ref targetSheet, ref argCell21, ref argValue21);
                string argCell22 = "E4";
                object argValue22 = 2;
                SetCellValue(ref targetSheet, ref argCell22, ref argValue22);
                string argCell23 = "E5";
                object argValue23 = 2.75;
                SetCellValue(ref targetSheet, ref argCell23, ref argValue23);
                dataRange = targetSheet.get_Range("A1", "E5");
                chartObjects = (Microsoft.Office.Interop.Excel.ChartObjects)targetSheet.ChartObjects();
                newChartObject = chartObjects.Add(0, 100, 300, 300);
                newChartObject.Chart.ChartWizard(dataRange, Microsoft.Office.Interop.Excel.XlChartType.xlLine, paramChartFormat, Microsoft.Office.Interop.Excel.XlRowCol.xlRows, paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle);


                newWorkbook.SaveAs(paramWorkbookPath);

                // Release the references to the Excel objects.
                newChartObject = null;
                chartObjects = null;
                dataRange = null;
                targetSheet = null;

                // Close and release the Workbook object.
                if (newWorkbook is object)
                {
                    newWorkbook.Close(false);
                    newWorkbook = null;
                }

                // Quit Excel and release the ApplicationClass object.
                if (excelApplication is object)
                {
                    excelApplication.Quit();
                    excelApplication = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            public void SetCellValue(ref Microsoft.Office.Interop.Excel.Worksheet targetSheet, ref string Cell, ref object Value)
            {
                targetSheet.get_Range(Cell).Value;
            }

            public void SetCellValueNoRange(ref Microsoft.Office.Interop.Excel.Worksheet targetSheet, ref string Cell, ref object Value)
            {
                targetSheet.Cells[Cell].Value = Value;
            }
            // oSheet.Cells(1, 2).Value = "Last Name"
            public string GetCellRef(ref string ColumnNumber, ref int RowNumber)
            {
                var ColRef = default(string);
                switch (ColumnNumber)
                {
                    case "1":
                        {
                            ColRef = "A";
                            break;
                        }

                    case "2":
                        {
                            ColRef = "B";
                            break;
                        }

                    case "3":
                        {
                            ColRef = "C";
                            break;
                        }

                    case "4":
                        {
                            ColRef = "D";
                            break;
                        }

                    case "5":
                        {
                            ColRef = "E";
                            break;
                        }

                    case "6":
                        {
                            ColRef = "F";
                            break;
                        }

                    case "7":
                        {
                            ColRef = "G";
                            break;
                        }

                    case "8":
                        {
                            ColRef = "H";
                            break;
                        }

                    case "9":
                        {
                            ColRef = "I";
                            break;
                        }

                    case "10":
                        {
                            ColRef = "J";
                            break;
                        }

                    case "11":
                        {
                            ColRef = "K";
                            break;
                        }

                    case "12":
                        {
                            ColRef = "L";
                            break;
                        }

                    case "13":
                        {
                            ColRef = "M";
                            break;
                        }

                    case "14":
                        {
                            ColRef = "N";
                            break;
                        }

                    case "15":
                        {
                            ColRef = "O";
                            break;
                        }

                    case "16":
                        {
                            ColRef = "P";
                            break;
                        }

                    case "17":
                        {
                            ColRef = "Q";
                            break;
                        }

                    case "18":
                        {
                            ColRef = "R";
                            break;
                        }

                    case "19":
                        {
                            ColRef = "S";
                            break;
                        }

                    case "20":
                        {
                            ColRef = "T";
                            break;
                        }

                    case "21":
                        {
                            ColRef = "U";
                            break;
                        }

                    case "22":
                        {
                            ColRef = "V";
                            break;
                        }

                    case "23":
                        {
                            ColRef = "W";
                            break;
                        }

                    case "24":
                        {
                            ColRef = "X";
                            break;
                        }

                    case "25":
                        {
                            ColRef = "Y";
                            break;
                        }

                    case "26":
                        {
                            ColRef = "Z";
                            break;
                        }

                    case "27":
                        {
                            ColRef = "AA";
                            break;
                        }

                    case "28":
                        {
                            ColRef = "AB";
                            break;
                        }

                    case "29":
                        {
                            ColRef = "AC";
                            break;
                        }

                    case "30":
                        {
                            ColRef = "AD";
                            break;
                        }

                    case "31":
                        {
                            ColRef = "AE";
                            break;
                        }

                    case "32":
                        {
                            ColRef = "AF";
                            break;
                        }

                    case "33":
                        {
                            ColRef = "AG";
                            break;
                        }

                    case "34":
                        {
                            ColRef = "AH";
                            break;
                        }

                    case "35":
                        {
                            ColRef = "AI";
                            break;
                        }

                    case "36":
                        {
                            ColRef = "AJ";
                            break;
                        }

                    case "37":
                        {
                            ColRef = "AK";
                            break;
                        }

                    case "38":
                        {
                            ColRef = "AL";
                            break;
                        }

                    case "39":
                        {
                            ColRef = "AM";
                            break;
                        }

                    case "40":
                        {
                            ColRef = "AN";
                            break;
                        }

                    case "41":
                        {
                            ColRef = "AO";
                            break;
                        }

                    case "42":
                        {
                            ColRef = "AP";
                            break;
                        }

                    case "43":
                        {
                            ColRef = "AQ";
                            break;
                        }

                    case "44":
                        {
                            ColRef = "AR";
                            break;
                        }

                    case "45":
                        {
                            ColRef = "AS";
                            break;
                        }

                    case "46":
                        {
                            ColRef = "AT";
                            break;
                        }

                    case "47":
                        {
                            ColRef = "AU";
                            break;
                        }

                    case "48":
                        {
                            ColRef = "AV";
                            break;
                        }

                    case "49":
                        {
                            ColRef = "AW";
                            break;
                        }

                    case "50":
                        {
                            ColRef = "AX";
                            break;
                        }

                    case "51":
                        {
                            ColRef = "AY";
                            break;
                        }

                    case "52":
                        {
                            ColRef = "AZ";
                            break;
                        }

                    case "53":
                        {
                            ColRef = "BA";
                            break;
                        }

                    case "54":
                        {
                            ColRef = "BB";
                            break;
                        }

                    case "55":
                        {
                            ColRef = "BC";
                            break;
                        }

                    case "56":
                        {
                            ColRef = "BD";
                            break;
                        }

                    case "57":
                        {
                            ColRef = "BE";
                            break;
                        }

                    case "58":
                        {
                            ColRef = "BF";
                            break;
                        }

                    case "59":
                        {
                            ColRef = "BG";
                            break;
                        }

                    case "60":
                        {
                            ColRef = "BH";
                            break;
                        }

                    case "61":
                        {
                            ColRef = "BI";
                            break;
                        }

                    case "62":
                        {
                            ColRef = "BJ";
                            break;
                        }

                    case "63":
                        {
                            ColRef = "BK";
                            break;
                        }

                    case "64":
                        {
                            ColRef = "BL";
                            break;
                        }

                    case "65":
                        {
                            ColRef = "BM";
                            break;
                        }

                    case "66":
                        {
                            ColRef = "BN";
                            break;
                        }

                    case "67":
                        {
                            ColRef = "BO";
                            break;
                        }

                    case "68":
                        {
                            ColRef = "BP";
                            break;
                        }

                    case "69":
                        {
                            ColRef = "BQ";
                            break;
                        }

                    case "70":
                        {
                            ColRef = "BR";
                            break;
                        }

                    case "71":
                        {
                            ColRef = "BS";
                            break;
                        }

                    case "72":
                        {
                            ColRef = "BT";
                            break;
                        }

                    case var @case when @case == Conversions.ToString(Conversions.ToDouble(ColumnNumber) > 75):
                        {
                            ColRef = "BU";
                            break;
                        }
                }

                return ColRef + Conversions.ToString(RowNumber);
            }
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }
    }
}