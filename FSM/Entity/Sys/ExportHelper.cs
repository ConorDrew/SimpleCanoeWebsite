// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.ExportHelper
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
  public class ExportHelper
  {
    public static void Export(DataTable dtData, string exportFileName, Enums.ExportType exportType)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Export))
        App.ShowSecurityError();
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      int num1 = (int) folderBrowserDialog.ShowDialog();
      if (folderBrowserDialog.SelectedPath.Trim().Length == 0)
      {
        int num2 = (int) App.ShowMessage("Operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        Process.Start(exportType == Enums.ExportType.CSV ? ExportHelper.ExportCSV(dtData, exportFileName, folderBrowserDialog.SelectedPath) : ExportHelper.ExportXLS(dtData, exportFileName, folderBrowserDialog.SelectedPath));
    }

    private static string ExportCSV(DataTable dtData, string exportFileName, string savePath)
    {
      string csv = ExportHelper.DataTableToCSV(dtData, ',');
      string str = Helper.MakeFileNameValid(exportFileName + "Export_" + DateAndTime.Now.ToString("ddMMMyyyyHHmmss") + ".csv");
      string path = savePath + "\\" + str;
      FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
      using (fileStream)
      {
        byte[] bytes = new UTF8Encoding(true).GetBytes(csv);
        fileStream.Write(bytes, 0, bytes.Length);
      }
      fileStream.Close();
      return path;
    }

    private static string ExportXLS(DataTable dtData, string exportFileName, string savePath)
    {
      string str1 = Helper.MakeFileNameValid(exportFileName + " Export_" + DateAndTime.Now.ToString("ddMMMyyyyHHmmss") + ".xlsx");
      string fileName = savePath + "\\" + str1;
      string str2;
      try
      {
        ExcelPackage excelPackage = new ExcelPackage(new FileInfo(fileName));
        using (excelPackage)
        {
          if (string.IsNullOrEmpty(dtData.TableName))
            dtData.TableName = exportFileName;
          ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(dtData.TableName);
          excelWorksheet.Cells["A1"].LoadFromDataTable(dtData, true);
          int row = excelWorksheet.Dimension.End.Row;
          int column1 = excelWorksheet.Dimension.End.Column;
          ExcelRange cell1 = excelWorksheet.Cells[1, 1, 1, column1];
          ExcelFont font = cell1.Style.Font;
          cell1.AutoFilter = true;
          font.Bold = true;
          font.Color.SetColor(Color.White);
          ExcelFill fill = cell1.Style.Fill;
          fill.PatternType = ExcelFillStyle.Solid;
          fill.BackgroundColor.SetColor(Color.Blue);
          ExcelRange cell2 = excelWorksheet.Cells[1, 1, row, column1];
          cell2.AutoFitColumns();
          Border border = cell2.Style.Border;
          border.Top.Style = (ExcelBorderStyle) -(-((ExcelBorderStyle) -(border.Left.Style == border.Bottom.Style ? 1 : 0) == border.Right.Style ? 1 : 0) == 4 ? 1 : 0);
          int count = dtData.Columns.Count;
          int column2 = excelWorksheet.Dimension.End.Column;
          int col = 1;
          while (col <= column2)
          {
            if (col <= count & dtData.Columns[checked (col - 1)].DataType == typeof (DateTime))
              excelWorksheet.Column(col).Style.Numberformat.Format = "dd/MM/yyyy hh:mm";
            checked { ++col; }
          }
          cell2.Style.WrapText = true;
          excelPackage.Save();
        }
        str2 = fileName;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Could not generate document : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        str2 = string.Empty;
        ProjectData.ClearProjectError();
      }
      return str2;
    }

    private static string DataTableToCSV(DataTable datatable, char seperator)
    {
      StringBuilder stringBuilder = new StringBuilder();
      int num1 = checked (datatable.Columns.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        stringBuilder.Append((object) datatable.Columns[index1]);
        if (index1 < checked (datatable.Columns.Count - 1))
          stringBuilder.Append(seperator);
        checked { ++index1; }
      }
      string pattern = "[`~!@#\\$%\\^&\\*\\(\\)_\\-\\+=\\{\\}\\[\\]\\\\\\|:;\"'<>,\\.\\?/]";
      stringBuilder.AppendLine();
      IEnumerator enumerator;
      try
      {
        enumerator = datatable.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          int num2 = checked (datatable.Columns.Count - 1);
          int index2 = 0;
          while (index2 <= num2)
          {
            string input = current[index2].ToString();
            Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(input);
            if (match.Success)
              input = "\"" + string.Join("\"" + match.Value + "\"", input) + "\"";
            stringBuilder.Append(input);
            if (index2 < checked (datatable.Columns.Count - 1))
              stringBuilder.Append(seperator);
            checked { ++index2; }
          }
          stringBuilder.AppendLine();
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return stringBuilder.ToString();
    }

    public static string DataTableToCSVNoHeaders(DataTable dt)
    {
      StringBuilder stringBuilder = new StringBuilder();
      IEnumerator enumerator;
      try
      {
        enumerator = dt.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          object[] itemArray = ((DataRow) enumerator.Current).ItemArray;
          Func<object, string> selector;
          // ISSUE: reference to a compiler-generated field
          if (ExportHelper._Closure\u0024__.\u0024I5\u002D0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            selector = ExportHelper._Closure\u0024__.\u0024I5\u002D0;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            ExportHelper._Closure\u0024__.\u0024I5\u002D0 = selector = (Func<object, string>) (field => field.ToString());
          }
          IEnumerable<string> values = ((IEnumerable<object>) itemArray).Select<object, string>(selector);
          stringBuilder.AppendLine(string.Join(",", values));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return stringBuilder.ToString();
    }
  }
}
