using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OfficeOpenXml;

namespace FSM.Entity
{
    namespace Sys
    {
        public class ExportHelper
        {
            public static void Export(DataTable dtData, string exportFileName, Enums.ExportType exportType)
            {
                if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Export))
                    App.ShowSecurityError();
                var folderToSaveTo = new FolderBrowserDialog();
                folderToSaveTo.ShowDialog();
                if (folderToSaveTo.SelectedPath.Trim().Length == 0)
                {
                    App.ShowMessage("Operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    string filepath = null;
                    switch (exportType)
                    {
                        case Enums.ExportType.CSV:
                            {
                                filepath = ExportCSV(dtData, exportFileName, folderToSaveTo.SelectedPath);
                                break;
                            }

                        default:
                            {
                                filepath = ExportXLS(dtData, exportFileName, folderToSaveTo.SelectedPath);
                                break;
                            }
                    }

                    Process.Start(filepath);
                }
            }

            private static string ExportCSV(DataTable dtData, string exportFileName, string savePath)
            {
                string data = DataTableToCSV(dtData, ',');
                string fileName = exportFileName + "Export_" + DateAndTime.Now.ToString("ddMMMyyyyHHmmss") + ".csv";
                fileName = Helper.MakeFileNameValid(fileName);
                string filePath = savePath + @"\" + fileName;
                var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                using (fileStream)
                {
                    var info = new UTF8Encoding(true).GetBytes(data);
                    fileStream.Write(info, 0, info.Length);
                }

                fileStream.Close();
                return filePath;
            }

            private static string ExportXLS(DataTable dtData, string exportFileName, string savePath)
            {
                string fileName = exportFileName + " Export_" + DateAndTime.Now.ToString("ddMMMyyyyHHmmss") + ".xlsx";
                fileName = Helper.MakeFileNameValid(fileName);
                string filePath = savePath + @"\" + fileName;
                try
                {
                    var newFile = new FileInfo(filePath);
                    var pck = new ExcelPackage(newFile);
                    using (pck)
                    {
                        if (string.IsNullOrEmpty(dtData.TableName))
                            dtData.TableName = exportFileName;
                        var ws = pck.Workbook.Worksheets.Add(dtData.TableName);
                        ws.Cells["A1"].LoadFromDataTable(dtData, true);

                        // style header
                        int totalRows = ws.Dimension.End.Row;
                        int totalColumns = ws.Dimension.End.Column;
                        var headerCells = ws.Cells[1, 1, 1, totalColumns];
                        var headerFont = headerCells.Style.Font;
                        headerCells.AutoFilter = true;
                        headerFont.Bold = true;
                        headerFont.Color.SetColor(Color.White);
                        var headerFill = headerCells.Style.Fill;
                        headerFill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        headerFill.BackgroundColor.SetColor(Color.Blue);
                        var allCells = ws.Cells[1, 1, totalRows, totalColumns];
                        allCells.AutoFitColumns();
                        var border = allCells.Style.Border;
                        border.Top.Style = (OfficeOpenXml.Style.ExcelBorderStyle)(Conversions.ToInteger(Conversions.ToInteger(border.Left.Style == border.Bottom.Style) == (int)border.Right.Style) == (int)OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        int dtLength = dtData.Columns.Count;
                        for (int i = 1, loopTo = ws.Dimension.End.Column; i <= loopTo; i++)
                        {
                            if (i <= dtLength & dtData.Columns[i - 1].DataType == typeof(DateTime))
                            {
                                ws.Column(i).Style.Numberformat.Format = "dd/MM/yyyy hh:mm";
                            }
                        }

                        allCells.Style.WrapText = true;
                        pck.Save();
                    }

                    return filePath;
                }
                catch (Exception ex)
                {
                    App.ShowMessage("Could not generate document : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }

            private static string DataTableToCSV(DataTable datatable, char seperator)
            {
                var sb = new StringBuilder();
                for (int i = 0, loopTo = datatable.Columns.Count - 1; i <= loopTo; i++)
                {
                    sb.Append(datatable.Columns[i]);
                    if (i < datatable.Columns.Count - 1)
                        sb.Append(seperator);
                }

                string pattern = @"[`~!@#\$%\^&\*\(\)_\-\+=\{\}\[\]\\\|:;""'<>,\.\?/]";
                sb.AppendLine();
                foreach (DataRow dr in datatable.Rows)
                {
                    for (int i = 0, loopTo1 = datatable.Columns.Count - 1; i <= loopTo1; i++)
                    {
                        string info = dr[i].ToString();
                        var r = new Regex(pattern, RegexOptions.IgnoreCase);
                        var m = r.Match(info);
                        if (m.Success)
                        {
                            info = ControlChars.Quote + string.Join(ControlChars.Quote + m.Value + ControlChars.Quote, info) + ControlChars.Quote;
                        }

                        sb.Append(info);
                        if (i < datatable.Columns.Count - 1)
                            sb.Append(seperator);
                    }

                    sb.AppendLine();
                }

                return sb.ToString();
            }

            public static string DataTableToCSVNoHeaders(DataTable dt)
            {
                var sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    var fields = row.ItemArray.Select(field => field.ToString());
                    sb.AppendLine(string.Join(",", fields));
                }

                return sb.ToString();
            }
        }
    }
}