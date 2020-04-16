// Decompiled with JetBrains decompiler
// Type: FSM.Entity.Sys.Exporting
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FSM.Entity.Sys
{
  public class Exporting
  {
    private DataTable _Data;
    private Microsoft.Office.Interop.Excel.Application _excelApplication;
    private Workbook _excelWorkBook;
    private Worksheet _excelWorkSheet;
    private string _workSheetName;
    private string _FilePathToBeUsed;
    private string _folderPath;
    private DataSet _DataSet;

    public DataTable Data
    {
      get
      {
        return this._Data;
      }
      set
      {
        this._Data = value;
      }
    }

    private Microsoft.Office.Interop.Excel.Application ExcelApplication
    {
      get
      {
        Microsoft.Office.Interop.Excel.Application excelApplication = this._excelApplication;
        return excelApplication;
      }
      set
      {
        this._excelApplication = value;
      }
    }

    private Workbook ExcelWorkBook
    {
      get
      {
        Workbook excelWorkBook = this._excelWorkBook;
        return excelWorkBook;
      }
      set
      {
        this._excelWorkBook = value;
      }
    }

    private Worksheet ExcelWorkSheet
    {
      get
      {
        Worksheet excelWorkSheet = this._excelWorkSheet;
        return excelWorkSheet;
      }
      set
      {
        this._excelWorkSheet = value;
      }
    }

    private string WorkSheetName
    {
      get
      {
        return this._workSheetName;
      }
      set
      {
        this._workSheetName = value;
      }
    }

    private string FilePathToBeUsed
    {
      get
      {
        return this._FilePathToBeUsed;
      }
      set
      {
        this._FilePathToBeUsed = value;
      }
    }

    private string FolderPath
    {
      get
      {
        return this._folderPath;
      }
      set
      {
        this._folderPath = value;
      }
    }

    public DataSet DataSet
    {
      get
      {
        return this._DataSet;
      }
      set
      {
        this._DataSet = value;
      }
    }

    public Exporting(
      DataTable datatableIn,
      string workSheetNameIn,
      string folderPathIn = "",
      string filenameIn = "",
      DataSet DataSetin = null)
    {
      this._Data = (DataTable) null;
      this._excelApplication = (Microsoft.Office.Interop.Excel.Application) null;
      this._excelWorkBook = (Workbook) null;
      this._excelWorkSheet = (Worksheet) null;
      this._workSheetName = string.Empty;
      this._FilePathToBeUsed = string.Empty;
      this._folderPath = string.Empty;
      this._DataSet = (DataSet) null;
      this.Data = datatableIn;
      this.WorkSheetName = workSheetNameIn;
      this.FolderPath = folderPathIn;
      this.FilePathToBeUsed = filenameIn;
      this.DataSet = DataSetin;
      this.Export();
    }

    private void Export()
    {
      string filePath = "";
      try
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.WorkSheetName, "3rd Visits", false) == 0)
          filePath = this.FolderPath + "3rdVisits.xls";
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.WorkSheetName, "Servicing Statistics Report", false) == 0)
        {
          filePath = this.FolderPath;
        }
        else
        {
          FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
          int num1 = (int) folderBrowserDialog.ShowDialog();
          if (folderBrowserDialog.SelectedPath.Trim().Length == 0)
          {
            int num2 = (int) App.ShowMessage("Operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return;
          }
          string str;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.WorkSheetName, "Stock Take", false) == 0)
          {
            string Right = "";
            IEnumerator enumerator;
            try
            {
              enumerator = this.Data.Rows.GetEnumerator();
              while (enumerator.MoveNext())
              {
                DataRow current = (DataRow) enumerator.Current;
                if (Right.Trim().Length == 0)
                  Right = Strings.Replace(Conversions.ToString(current["Location"]), "*", "", 1, -1, CompareMethod.Binary);
                else if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.Replace(Conversions.ToString(current["Location"]), "*", "", 1, -1, CompareMethod.Binary), Right, false) > 0U)
                {
                  Right = "Multiple_Locations";
                  break;
                }
              }
            }
            finally
            {
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
            if (Right.Trim().Length == 0)
              Right = "No_Locations";
            str = Right.Replace("WAREHOUSE : ", "").Replace("VAN : ", "").Trim() + "_" + Strings.Format((object) DateAndTime.Now, "ddMMMyyyy");
          }
          else
            str = (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.FilePathToBeUsed, "", false) <= 0U ? nameof (Export) + Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss") : this.FilePathToBeUsed + Strings.Format((object) DateAndTime.Now, "ddMMMyyyyHHmmss");
          filePath = folderBrowserDialog.SelectedPath + "\\" + str + ".xls";
        }
        Cursor.Current = Cursors.WaitCursor;
        this.ExcelApplication = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
        this.ExcelApplication.DisplayAlerts = false;
        // ISSUE: reference to a compiler-generated method
        this.ExcelWorkBook = this.ExcelApplication.Workbooks.Add(RuntimeHelpers.GetObjectValue((object) Missing.Value));
        this.ExcelWorkSheet = (Worksheet) this.ExcelApplication.Worksheets[(object) 1];
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.WorkSheetName, "Servicing Statistics Report", false) == 0)
        {
          this.ServicingStatisticsReport(this.DataSet, filePath);
        }
        else
        {
          this.DropToExcel();
          this.SpecialCase();
          this.ExcelWorkSheet.Name = this.WorkSheetName;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Exporting : \r\n\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.SaveAndDestroyExcel(filePath);
        Cursor.Current = Cursors.Default;
      }
    }

    private void DropToExcel()
    {
      int count1 = this.Data.Columns.Count;
      int count2 = this.Data.Rows.Count;
      object[,] objArray = new object[checked (count2 + 1 + 1), checked (count1 + 1)];
      int num1 = checked (count1 - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        objArray[0, index1] = (object) this.Data.Columns[index1].ColumnName;
        checked { ++index1; }
      }
      int num2 = count2;
      int index2 = 1;
      while (index2 <= num2)
      {
        int num3 = checked (count1 - 1);
        int index3 = 0;
        while (index3 <= num3)
        {
          string name = this.Data.Columns[index3].DataType.Name;
          // ISSUE: reference to a compiler-generated method
          switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(name))
          {
            case 423635464:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "SByte", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 679076413:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Char", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3])).Trim();
                break;
              }
              goto default;
            case 697196164:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Int64", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 765439473:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Int16", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 995259257:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Date", false) == 0)
              {
                objArray[index2, index3] = DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3])), DateTime.MinValue) != 0 ? (object) Conversions.ToDate(Strings.Format((object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3])), "dd/MM/yyyy")) : (object) "";
                break;
              }
              goto default;
            case 1283547685:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Float", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 1615808600:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "String", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3])).Trim();
                break;
              }
              goto default;
            case 2386971688:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Double", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 2576877872:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Int24", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 2615964816:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "DateTime", false) == 0)
              {
                objArray[index2, index3] = DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3])), DateTime.MinValue) != 0 ? (object) Conversions.ToDate(Strings.Format((object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3])), "dd/MM/yyyy")) : (object) "";
                break;
              }
              goto default;
            case 2642490659:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Byte[]", false) == 0)
              {
                objArray[index2, index3] = (object) this.Data.Rows[checked (index2 - 1)][index3].ToString();
                break;
              }
              goto default;
            case 2711245919:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Int32", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 2779444460:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Decimal", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 3651752933:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Integer", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            case 3969205087:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Boolean", false) == 0)
              {
                objArray[index2, index3] = (object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]));
                break;
              }
              goto default;
            default:
              objArray[index2, index3] = RuntimeHelpers.GetObjectValue(this.Data.Rows[checked (index2 - 1)][index3]);
              break;
          }
          checked { ++index3; }
        }
        checked { ++index2; }
      }
      object obj = (object) objArray;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      this.ExcelWorkSheet.get_Range(RuntimeHelpers.GetObjectValue(this.ExcelWorkSheet.Cells[(object) 1, (object) 1]), RuntimeHelpers.GetObjectValue(this.ExcelWorkSheet.Cells[(object) checked (count2 + 2), (object) checked (count1 + 1)])).set_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue(obj));
      int num4 = checked (this.Data.Columns.Count - 1);
      int num5 = 0;
      while (num5 <= num4)
      {
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Excel.Range cell = (Microsoft.Office.Interop.Excel.Range) this.ExcelWorkSheet.Cells[(object) 1, (object) checked (num5 + 1)];
        cell.Font.Bold = (object) true;
        cell.Font.ColorIndex = (object) 2;
        cell.NumberFormat = (object) "@";
        cell.Interior.ColorIndex = (object) 11;
        // ISSUE: reference to a compiler-generated method
        cell.EntireColumn.AutoFit();
        checked { ++num5; }
      }
      int count3 = this.ExcelWorkBook.Worksheets.Count;
      while (count3 >= 1)
      {
        // ISSUE: reference to a compiler-generated method
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(((_Worksheet) this.ExcelWorkBook.Worksheets.get_Item((object) count3)).Name, this.ExcelWorkSheet.Name, false) > 0U)
        {
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          ((_Worksheet) this.ExcelWorkBook.Worksheets.get_Item((object) count3)).Delete();
        }
        checked { count3 += -1; }
      }
    }

    private void SaveAndDestroyExcel(string filePath)
    {
      try
      {
        if (filePath.Trim().Length > 0 & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.WorkSheetName, "Servicing Statistics Report", false) > 0U)
        {
          File.Delete(filePath);
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkBook.SaveAs((object) filePath, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), XlSaveAsAccessMode.xlNoChange, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), (object) true);
        }
        this.KillInstances();
        if (!(filePath.Trim().Length > 0 & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.WorkSheetName, "3rd Visits", false) > 0U))
          return;
        Helper.StartProcess(filePath);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Exporting : \r\n\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void KillInstances()
    {
      int num1;
      int num2;
      try
      {
label_2:
        ProjectData.ClearProjectError();
        num1 = -2;
label_3:
        int num3 = 2;
        Marshal.ReleaseComObject((object) this.ExcelWorkSheet);
label_4:
        num3 = 3;
        this.ExcelWorkSheet = (Worksheet) null;
label_5:
        num3 = 4;
        Marshal.ReleaseComObject((object) this.ExcelWorkBook);
label_6:
        num3 = 5;
        this.ExcelWorkBook = (Workbook) null;
label_7:
        num3 = 6;
        // ISSUE: reference to a compiler-generated method
        this.ExcelApplication.Quit();
label_8:
        num3 = 7;
        Marshal.ReleaseComObject((object) this.ExcelApplication);
label_9:
        num3 = 8;
        this.ExcelApplication = (Microsoft.Office.Interop.Excel.Application) null;
label_10:
        num3 = 9;
        GC.Collect();
label_11:
        num3 = 10;
        Process[] processesByName = Process.GetProcessesByName("EXCEL");
label_12:
        num3 = 11;
        Process[] processArray = processesByName;
        int index = 0;
        goto label_22;
label_14:
        num3 = 12;
        Process process;
        if (!process.Responding)
          goto label_19;
label_15:
        num3 = 13;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(process.MainWindowTitle, "", false) != 0)
          goto label_18;
label_16:
        num3 = 14;
        process.Kill();
label_17:
label_18:
        goto label_21;
label_19:
        num3 = 17;
        process.Kill();
label_20:
label_21:
        num3 = 19;
        checked { ++index; }
label_22:
        if (index < processArray.Length)
        {
          process = processArray[index];
          goto label_14;
        }
label_23:
        ProjectData.ClearProjectError();
        num2 = 0;
        goto label_30;
label_25:
        num2 = num3;
        switch (num1 > -2 ? num1 : 1)
        {
          case 1:
            int num4 = num2 + 1;
            num2 = 0;
            switch (num4)
            {
              case 1:
                goto label_2;
              case 2:
                goto label_3;
              case 3:
                goto label_4;
              case 4:
                goto label_5;
              case 5:
                goto label_6;
              case 6:
                goto label_7;
              case 7:
                goto label_8;
              case 8:
                goto label_9;
              case 9:
                goto label_10;
              case 10:
                goto label_11;
              case 11:
                goto label_12;
              case 12:
                goto label_14;
              case 13:
                goto label_15;
              case 14:
                goto label_16;
              case 15:
                goto label_17;
              case 16:
              case 19:
                goto label_21;
              case 17:
                goto label_19;
              case 18:
                goto label_20;
              case 20:
                goto label_23;
              case 21:
                goto label_30;
            }
            break;
        }
      }
      catch (Exception ex) when (ex is Exception & (uint) num1 > 0U & num2 == 0)
      {
        ProjectData.SetProjectError(ex);
        goto label_25;
      }
      throw ProjectData.CreateProjectError(-2146828237);
label_30:
      if (num2 == 0)
        return;
      ProjectData.ClearProjectError();
    }

    private void SpecialCase()
    {
      if (this.WorkSheetName.Contains("Timesheet"))
        this.Timesheets();
      if (this.WorkSheetName.Contains("TS Summary"))
      {
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Style style1 = this.ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFBad", RuntimeHelpers.GetObjectValue((object) Missing.Value));
        style1.Font.Bold = (object) true;
        style1.Interior.Color = (object) ColorTranslator.ToOle(Color.LightPink);
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Style style2 = this.ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFWarn", RuntimeHelpers.GetObjectValue((object) Missing.Value));
        style2.Font.Bold = (object) true;
        style2.Interior.Color = (object) ColorTranslator.ToOle(Color.Yellow);
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Style style3 = this.ExcelWorkSheet.Application.ActiveWorkbook.Styles.Add("CFGood", RuntimeHelpers.GetObjectValue((object) Missing.Value));
        style3.Font.Bold = (object) true;
        style3.Interior.Color = (object) ColorTranslator.ToOle(Color.LightGreen);
        NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "B:B", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
        {
          (object) 15
        }, (string[]) null, (System.Type[]) null, false, true);
        NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "C:C", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
        {
          (object) 15
        }, (string[]) null, (System.Type[]) null, false, true);
        NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "D:D", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
        {
          (object) 15
        }, (string[]) null, (System.Type[]) null, false, true);
        NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "E:E", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
        {
          (object) 15
        }, (string[]) null, (System.Type[]) null, false, true);
        NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "F:F", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
        {
          (object) 15
        }, (string[]) null, (System.Type[]) null, false, true);
        NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "G:G", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
        {
          (object) 20
        }, (string[]) null, (System.Type[]) null, false, true);
        int num1 = checked (this.Data.Rows.Count - 1);
        int num2 = 1;
        while (num2 <= num1)
        {
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlHairline, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlHairline, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlHairline, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlHairline, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlHairline, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlHairline, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlHairline, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
          if (num2 == 1)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) "A1:G1", RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
          }
          else
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) null, false))))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) 120, false))
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Style = (object) "CFBad";
              }
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value), (object) this.formatTime(Conversions.ToInteger(this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)))));
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) null, false))))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectLessEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) 300, false))
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Style = (object) "CFBad";
              }
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value), (object) this.formatTime(Conversions.ToInteger(this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)))));
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) null, false))))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) 0, false))
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Style = (object) "CFBad";
              }
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value), (object) this.formatTime(Conversions.ToInteger(this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)))));
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) null, false))))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) 60, false))
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Style = (object) "CFBad";
              }
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value), (object) this.formatTime(Conversions.ToInteger(this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)))));
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) null, false))))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreaterEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) 20, false))
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Style = (object) "CFBad";
              }
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value), (object) this.formatTime(Conversions.ToInteger(this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)))));
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) null, false))))
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)), (object) 0, false))
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Style = (object) "CFWarn";
              }
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value), (object) this.formatTime(Conversions.ToInteger(this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value)))));
            }
          }
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num2)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
          checked { ++num2; }
        }
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.ExcelWorkSheet.Cells.get_Range((object) ("A2:G" + Conversions.ToString(checked (this.Data.Rows.Count - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.ExcelWorkSheet.Cells.get_Range((object) ("A1:A" + Conversions.ToString(checked (this.Data.Rows.Count - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(checked (this.Data.Rows.Count - 1)) + ":G" + Conversions.ToString(checked (this.Data.Rows.Count - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).BorderAround(RuntimeHelpers.GetObjectValue((object) Missing.Value), XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, RuntimeHelpers.GetObjectValue((object) Missing.Value));
      }
      string workSheetName = this.WorkSheetName;
      // ISSUE: reference to a compiler-generated method
      switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(workSheetName))
      {
        case 112061148:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Invoiced List", false) != 0)
            break;
          int num3 = checked (this.Data.Rows.Count + 1);
          int num4 = 1;
          while (num4 <= num3)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "dd/MM/yyyy";
            checked { ++num4; }
          }
          break;
        case 354789832:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Stock Used Report", false) != 0)
            break;
          int num5 = checked (this.Data.Rows.Count + 1);
          int num6 = 1;
          while (num6 <= num5)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "#,##0";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "#,##0";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("I" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("I" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("I" + Conversions.ToString(num6)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "#,##0";
            checked { ++num6; }
          }
          break;
        case 366680694:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Stock Quantities", false) != 0)
            break;
          int num7 = checked (this.Data.Rows.Count + 1);
          int num8 = 1;
          while (num8 <= num7)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num8)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "#,##0.00";
            checked { ++num8; }
          }
          break;
        case 378424284:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Stock Take", false) != 0)
            break;
          int num9 = checked (this.Data.Rows.Count + 1);
          int num10 = 1;
          while (num10 <= num9)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("J" + Conversions.ToString(num10)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("J" + Conversions.ToString(num10)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("J" + Conversions.ToString(num10)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "#,##0";
            checked { ++num10; }
          }
          break;
        case 385843784:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Stock Category Value Report", false) != 0)
            break;
          int num11 = checked (this.Data.Rows.Count + 1);
          int num12 = 1;
          while (num12 <= num11)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num12)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num12)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num12)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num12)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num12)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num12)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            checked { ++num12; }
          }
          break;
        case 684542161:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Quote List", false) != 0)
            break;
          int num13 = checked (this.Data.Rows.Count + 1);
          int num14 = 1;
          while (num14 <= num13)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num14)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num14)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num14)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            checked { ++num14; }
          }
          break;
        case 1224424472:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Invoice List", false) != 0)
            break;
          int num15 = checked (this.Data.Rows.Count + 1);
          int num16 = 1;
          while (num16 <= num15)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num16)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num16)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("H" + Conversions.ToString(num16)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            checked { ++num16; }
          }
          break;
        case 2203336540:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Visit List", false) != 0)
            break;
          int num17 = checked (this.Data.Rows.Count + 1);
          int num18 = 1;
          while (num18 <= num17)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("J" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("J" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("J" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("K" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("K" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("K" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("L" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("L" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("L" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("O" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("O" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("O" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("P" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("P" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("P" + Conversions.ToString(num18)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            checked { ++num18; }
          }
          break;
        case 3093477592:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Contracts List", false) != 0)
            break;
          int num19 = checked (this.Data.Rows.Count + 1);
          int num20 = 1;
          while (num20 <= num19)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num20)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num20)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("G" + Conversions.ToString(num20)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            checked { ++num20; }
          }
          break;
        case 3579259998:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Stock Value Report", false) != 0)
            break;
          int num21 = checked (this.Data.Rows.Count + 1);
          int num22 = 1;
          while (num22 <= num21)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num22)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num22)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("E" + Conversions.ToString(num22)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num22)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num22)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("F" + Conversions.ToString(num22)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            checked { ++num22; }
          }
          break;
        case 3711761180:
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(workSheetName, "Job List", false) != 0)
            break;
          int num23 = checked (this.Data.Rows.Count + 1);
          int num24 = 1;
          while (num24 <= num23)
          {
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("L" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("L" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("L" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("M" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("N" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("N" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("N" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("O" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("O" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("O" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("P" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.ExcelWorkSheet.Cells.get_Range((object) ("P" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) " ");
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("P" + Conversions.ToString(num24)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "£#,##0.00";
            checked { ++num24; }
          }
          break;
      }
    }

    private void Timesheets()
    {
      NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "B:B", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "wrapText", new object[1]
      {
        (object) true
      }, (string[]) null, (System.Type[]) null, false, true);
      NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "C:C", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "wrapText", new object[1]
      {
        (object) true
      }, (string[]) null, (System.Type[]) null, false, true);
      NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "A:A", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
      {
        (object) 27.71
      }, (string[]) null, (System.Type[]) null, false, true);
      NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "B:B", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
      {
        (object) 37.29
      }, (string[]) null, (System.Type[]) null, false, true);
      NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "C:C", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
      {
        (object) 31.43
      }, (string[]) null, (System.Type[]) null, false, true);
      NewLateBinding.LateSetComplex(this.ExcelWorkSheet.Columns[(object) "D:D", RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, "ColumnWidth", new object[1]
      {
        (object) 42.86
      }, (string[]) null, (System.Type[]) null, false, true);
      DataTable table1 = App.DB.Engineer.Engineer_GetAll().Table;
      string str1 = "Monday Tuesday Wednesday Thursday Friday Saturday Sunday";
      this.ExcelWorkSheet.PageSetup.LeftHeader = this.WorkSheetName;
      this.ExcelWorkSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
      this.ExcelWorkSheet.PageSetup.FitToPagesWide = (object) 1;
      this.ExcelWorkSheet.PageSetup.FitToPagesTall = (object) 25;
      this.ExcelWorkSheet.PageSetup.Zoom = (object) false;
      string str2 = "";
      string str3 = "";
      string str4 = "H";
      DataTable table2 = App.DB.Picklists.GetAll(Enums.PickListTypes.TimeSheetTypes, false).Table;
      // ISSUE: reference to a compiler-generated method
      string Left = Conversions.ToString(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(1)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1);
      int CharCode1 = 65;
      int CharCode2 = 65;
      int num1 = 0;
      while ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "", false) > 0U)
      {
        if (CharCode1 > 90)
        {
          checked { ++num1; }
          // ISSUE: reference to a compiler-generated method
          Left = Conversions.ToString(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(Strings.Chr(CharCode2)) + Conversions.ToString(1)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1);
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(Strings.Chr(CharCode2)) + Conversions.ToString(1)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = (object) "";
          checked { ++CharCode2; }
        }
        else
        {
          checked { ++num1; }
          // ISSUE: reference to a compiler-generated method
          Left = Conversions.ToString(this.ExcelWorkSheet.Cells.get_Range((object) (Conversions.ToString(Strings.Chr(CharCode1)) + Conversions.ToString(1)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1);
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) (Conversions.ToString(Strings.Chr(CharCode1)) + Conversions.ToString(1)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1 = (object) "";
        }
        checked { ++CharCode1; }
      }
      if (num1 > 26)
      {
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Excel.Range range = this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(1) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(1)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
        range.Interior.ColorIndex = (object) XlColorIndex.xlColorIndexNone;
        range.Font.ColorIndex = (object) XlColorIndex.xlColorIndexAutomatic;
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        Microsoft.Office.Interop.Excel.Range range = this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(1) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(1)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
        range.Interior.ColorIndex = (object) XlColorIndex.xlColorIndexNone;
        range.Font.ColorIndex = (object) XlColorIndex.xlColorIndexAutomatic;
      }
      bool flag1 = false;
      bool flag2 = false;
      int num2 = checked (this.Data.Rows.Count + 1);
      int num3 = 2;
      while (num3 <= num2)
      {
        // ISSUE: reference to a compiler-generated method
        if (this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1.ToString().Length > 0)
        {
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":h" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).RowHeight = (object) 25.5;
          str4 = "H";
        }
        else
        {
          int CharCode3 = 72;
          // ISSUE: reference to a compiler-generated method
          while (this.ExcelWorkSheet.Cells.get_Range((object) (Conversions.ToString(Strings.Chr(CharCode3)) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1.ToString().Length != 0)
          {
            checked { ++CharCode3; }
            if (CharCode3 > 82)
              goto label_16;
          }
          str4 = Conversions.ToString(Strings.Chr(checked (CharCode3 - 1)));
label_16:;
        }
        bool flag3 = false;
        // ISSUE: reference to a compiler-generated method
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) "", false), (object) flag1)))
        {
          flag1 = false;
          int num4 = num3;
          IEnumerator enumerator;
          try
          {
            enumerator = table2.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (num1 > 26)
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Formula = (object) ("=SUM(D" + Conversions.ToString(num4) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num4) + ")");
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "[h]:mm";
              }
              else
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Formula = (object) ("=SUM(D" + Conversions.ToString(num4) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num4) + ")");
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).NumberFormat = (object) "[h]:mm";
              }
              checked { ++num4; }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          // ISSUE: reference to a compiler-generated method
          // ISSUE: reference to a compiler-generated method
          object obj = this.ExcelWorkSheet.Cells.get_Range((object) (str2 + ":" + str4 + Conversions.ToString(checked (num4 - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Select();
          NewLateBinding.LateSetComplex(NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
          {
            (object) XlBordersIndex.xlDiagonalDown
          }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "LineStyle", new object[1]
          {
            (object) XlLineStyle.xlLineStyleNone
          }, (string[]) null, (System.Type[]) null, false, true);
          NewLateBinding.LateSetComplex(NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
          {
            (object) XlBordersIndex.xlDiagonalUp
          }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "LineStyle", new object[1]
          {
            (object) XlLineStyle.xlLineStyleNone
          }, (string[]) null, (System.Type[]) null, false, true);
          object Instance1 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
          {
            (object) XlBordersIndex.xlEdgeLeft
          }, (string[]) null, (System.Type[]) null, (bool[]) null);
          NewLateBinding.LateSetComplex(Instance1, (System.Type) null, "LineStyle", new object[1]
          {
            (object) XlLineStyle.xlContinuous
          }, (string[]) null, (System.Type[]) null, false, true);
          NewLateBinding.LateSetComplex(Instance1, (System.Type) null, "Weight", new object[1]
          {
            (object) XlBorderWeight.xlMedium
          }, (string[]) null, (System.Type[]) null, false, true);
          object Instance2 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
          {
            (object) XlBordersIndex.xlEdgeTop
          }, (string[]) null, (System.Type[]) null, (bool[]) null);
          NewLateBinding.LateSetComplex(Instance2, (System.Type) null, "LineStyle", new object[1]
          {
            (object) XlLineStyle.xlContinuous
          }, (string[]) null, (System.Type[]) null, false, true);
          NewLateBinding.LateSetComplex(Instance2, (System.Type) null, "Weight", new object[1]
          {
            (object) XlBorderWeight.xlMedium
          }, (string[]) null, (System.Type[]) null, false, true);
          object Instance3 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
          {
            (object) XlBordersIndex.xlEdgeBottom
          }, (string[]) null, (System.Type[]) null, (bool[]) null);
          NewLateBinding.LateSetComplex(Instance3, (System.Type) null, "LineStyle", new object[1]
          {
            (object) XlLineStyle.xlContinuous
          }, (string[]) null, (System.Type[]) null, false, true);
          NewLateBinding.LateSetComplex(Instance3, (System.Type) null, "Weight", new object[1]
          {
            (object) XlBorderWeight.xlMedium
          }, (string[]) null, (System.Type[]) null, false, true);
          object Instance4 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
          {
            (object) XlBordersIndex.xlEdgeRight
          }, (string[]) null, (System.Type[]) null, (bool[]) null);
          NewLateBinding.LateSetComplex(Instance4, (System.Type) null, "LineStyle", new object[1]
          {
            (object) XlLineStyle.xlContinuous
          }, (string[]) null, (System.Type[]) null, false, true);
          NewLateBinding.LateSetComplex(Instance4, (System.Type) null, "Weight", new object[1]
          {
            (object) XlBorderWeight.xlMedium
          }, (string[]) null, (System.Type[]) null, false, true);
          NewLateBinding.LateSetComplex(NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
          {
            (object) XlBordersIndex.xlInsideVertical
          }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "LineStyle", new object[1]
          {
            (object) XlLineStyle.xlLineStyleNone
          }, (string[]) null, (System.Type[]) null, false, true);
          NewLateBinding.LateSetComplex(NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
          {
            (object) XlBordersIndex.xlInsideHorizontal
          }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "LineStyle", new object[1]
          {
            (object) XlLineStyle.xlLineStyleNone
          }, (string[]) null, (System.Type[]) null, false, true);
          obj = (object) null;
        }
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) "SUMMARY", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) "MASTER SUMMARY", false))))
        {
          flag2 = false;
          flag1 = true;
          str2 = "A" + Conversions.ToString(checked (num3 + 1));
          if (num1 > 26)
          {
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
          }
          else
          {
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
          }
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Size = (object) 14;
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlLeft;
          // ISSUE: reference to a compiler-generated method
          this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Formula = (object) "Total";
        }
        // ISSUE: reference to a compiler-generated method
        if (table1.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Name='", this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1), (object) "'"))).Length > 0)
        {
          flag3 = true;
          if (num1 > 26)
          {
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Size = (object) 18;
          }
          else
          {
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Size = (object) 18;
          }
        }
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) str1.Contains(Conversions.ToString(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) "", false))))
        {
          flag3 = true;
          if (num1 > 26)
          {
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Size = (object) 14;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Size = (object) 10;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).VerticalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
          }
          else
          {
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Size = (object) 14;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Size = (object) 10;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
            // ISSUE: reference to a compiler-generated method
            this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).VerticalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
          }
          str3 = "A" + Conversions.ToString(checked (num3 + 1));
        }
        if (num3 > 1)
        {
          // ISSUE: reference to a compiler-generated method
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) "", false))
          {
            if (str3.Length > 0)
            {
              // ISSUE: reference to a compiler-generated method
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) (str3 + ":H" + Conversions.ToString(checked (num3 - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Select();
              NewLateBinding.LateSetComplex(NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
              {
                (object) XlBordersIndex.xlDiagonalDown
              }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "LineStyle", new object[1]
              {
                (object) XlLineStyle.xlLineStyleNone
              }, (string[]) null, (System.Type[]) null, false, true);
              NewLateBinding.LateSetComplex(NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
              {
                (object) XlBordersIndex.xlDiagonalUp
              }, (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "LineStyle", new object[1]
              {
                (object) XlLineStyle.xlLineStyleNone
              }, (string[]) null, (System.Type[]) null, false, true);
              object Instance1 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
              {
                (object) XlBordersIndex.xlEdgeLeft
              }, (string[]) null, (System.Type[]) null, (bool[]) null);
              NewLateBinding.LateSetComplex(Instance1, (System.Type) null, "LineStyle", new object[1]
              {
                (object) XlLineStyle.xlContinuous
              }, (string[]) null, (System.Type[]) null, false, true);
              NewLateBinding.LateSetComplex(Instance1, (System.Type) null, "Weight", new object[1]
              {
                (object) XlBorderWeight.xlMedium
              }, (string[]) null, (System.Type[]) null, false, true);
              object Instance2 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
              {
                (object) XlBordersIndex.xlEdgeTop
              }, (string[]) null, (System.Type[]) null, (bool[]) null);
              NewLateBinding.LateSetComplex(Instance2, (System.Type) null, "LineStyle", new object[1]
              {
                (object) XlLineStyle.xlContinuous
              }, (string[]) null, (System.Type[]) null, false, true);
              NewLateBinding.LateSetComplex(Instance2, (System.Type) null, "Weight", new object[1]
              {
                (object) XlBorderWeight.xlMedium
              }, (string[]) null, (System.Type[]) null, false, true);
              object Instance3 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
              {
                (object) XlBordersIndex.xlEdgeBottom
              }, (string[]) null, (System.Type[]) null, (bool[]) null);
              NewLateBinding.LateSetComplex(Instance3, (System.Type) null, "LineStyle", new object[1]
              {
                (object) XlLineStyle.xlContinuous
              }, (string[]) null, (System.Type[]) null, false, true);
              NewLateBinding.LateSetComplex(Instance3, (System.Type) null, "Weight", new object[1]
              {
                (object) XlBorderWeight.xlMedium
              }, (string[]) null, (System.Type[]) null, false, true);
              object Instance4 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
              {
                (object) XlBordersIndex.xlEdgeRight
              }, (string[]) null, (System.Type[]) null, (bool[]) null);
              NewLateBinding.LateSetComplex(Instance4, (System.Type) null, "LineStyle", new object[1]
              {
                (object) XlLineStyle.xlContinuous
              }, (string[]) null, (System.Type[]) null, false, true);
              NewLateBinding.LateSetComplex(Instance4, (System.Type) null, "Weight", new object[1]
              {
                (object) XlBorderWeight.xlMedium
              }, (string[]) null, (System.Type[]) null, false, true);
              object Instance5 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
              {
                (object) XlBordersIndex.xlInsideVertical
              }, (string[]) null, (System.Type[]) null, (bool[]) null);
              NewLateBinding.LateSetComplex(Instance5, (System.Type) null, "LineStyle", new object[1]
              {
                (object) XlLineStyle.xlContinuous
              }, (string[]) null, (System.Type[]) null, false, true);
              NewLateBinding.LateSetComplex(Instance5, (System.Type) null, "Weight", new object[1]
              {
                (object) XlBorderWeight.xlThin
              }, (string[]) null, (System.Type[]) null, false, true);
              // ISSUE: reference to a compiler-generated method
              if (this.ExcelWorkSheet.Cells.get_Range((object) (str3 + ":" + str4 + Conversions.ToString(checked (num3 - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Rows.Count > 1)
              {
                object Instance6 = NewLateBinding.LateGet(this.ExcelApplication.Selection, (System.Type) null, "Borders", new object[1]
                {
                  (object) XlBordersIndex.xlInsideHorizontal
                }, (string[]) null, (System.Type[]) null, (bool[]) null);
                NewLateBinding.LateSetComplex(Instance6, (System.Type) null, "LineStyle", new object[1]
                {
                  (object) XlLineStyle.xlContinuous
                }, (string[]) null, (System.Type[]) null, false, true);
                NewLateBinding.LateSetComplex(Instance6, (System.Type) null, "Weight", new object[1]
                {
                  (object) XlBorderWeight.xlThin
                }, (string[]) null, (System.Type[]) null, false, true);
              }
            }
            str3 = "";
          }
          else if (!flag3)
          {
            if (num1 > 26)
            {
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":A" + Conversions.ToString(Strings.Chr(checked (CharCode2 - 1))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).VerticalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
            }
            else
            {
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":" + Conversions.ToString(Strings.Chr(checked (num1 + 64))) + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).VerticalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlCenter;
            }
            // ISSUE: reference to a compiler-generated method
            if (table2.Select("Name='" + this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1.ToString().ToUpper() + "'").Length > 0)
            {
              // ISSUE: reference to a compiler-generated method
              if (this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1.ToString().Length > 0)
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3) + ":h" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Interior.ColorIndex = (object) 44;
              }
              else
              {
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlLeft;
                // ISSUE: reference to a compiler-generated method
                this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
              }
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1.ToString().ToUpper(), "NON-CHARGEABLE", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1.ToString().ToUpper(), "UNACCOUNTED", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1.ToString().ToUpper(), "TOTAL HOURS > 17:00", false) == 0)
            {
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).HorizontalAlignment = (object) Microsoft.Office.Interop.Excel.Constants.xlLeft;
              // ISSUE: reference to a compiler-generated method
              this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).Font.Bold = (object) true;
            }
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            // ISSUE: reference to a compiler-generated method
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(checked (num3 - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(checked (num3 - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(checked (num3 - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(checked (num3 - 1))), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, false))))
            {
              flag2 = true;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Excel.Range range1 = this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(checked (num3 - 1)) + ":A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
              range1.WrapText = (object) true;
              range1.MergeCells = (object) true;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Excel.Range range2 = this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(checked (num3 - 1)) + ":B" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
              range2.WrapText = (object) true;
              range2.MergeCells = (object) true;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Excel.Range range3 = this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(checked (num3 - 1)) + ":C" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
              range3.WrapText = (object) true;
              range3.MergeCells = (object) true;
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Microsoft.Office.Interop.Excel.Range range4 = this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(checked (num3 - 1)) + ":D" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
              range4.WrapText = (object) true;
              range4.MergeCells = (object) true;
            }
            else if (flag2)
            {
              int num4 = checked (num3 - 2);
              while (num4 >= 2)
              {
                // ISSUE: reference to a compiler-generated method
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, (object) "", false))
                {
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: reference to a compiler-generated method
                  // ISSUE: reference to a compiler-generated method
                  if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, false)), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num4)), RuntimeHelpers.GetObjectValue((object) Missing.Value)).FormulaR1C1, false))))
                  {
                    // ISSUE: reference to a compiler-generated method
                    // ISSUE: variable of a compiler-generated type
                    Microsoft.Office.Interop.Excel.Range range1 = this.ExcelWorkSheet.Cells.get_Range((object) ("A" + Conversions.ToString(num4) + ":A" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
                    range1.WrapText = (object) true;
                    range1.MergeCells = (object) true;
                    // ISSUE: reference to a compiler-generated method
                    // ISSUE: variable of a compiler-generated type
                    Microsoft.Office.Interop.Excel.Range range2 = this.ExcelWorkSheet.Cells.get_Range((object) ("B" + Conversions.ToString(num4) + ":B" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
                    range2.WrapText = (object) true;
                    range2.MergeCells = (object) true;
                    // ISSUE: reference to a compiler-generated method
                    // ISSUE: variable of a compiler-generated type
                    Microsoft.Office.Interop.Excel.Range range3 = this.ExcelWorkSheet.Cells.get_Range((object) ("C" + Conversions.ToString(num4) + ":C" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
                    range3.WrapText = (object) true;
                    range3.MergeCells = (object) true;
                    // ISSUE: reference to a compiler-generated method
                    // ISSUE: variable of a compiler-generated type
                    Microsoft.Office.Interop.Excel.Range range4 = this.ExcelWorkSheet.Cells.get_Range((object) ("D" + Conversions.ToString(num4) + ":D" + Conversions.ToString(num3)), RuntimeHelpers.GetObjectValue((object) Missing.Value));
                    range4.WrapText = (object) true;
                    range4.MergeCells = (object) true;
                    checked { num4 += -1; }
                  }
                  else
                  {
                    flag2 = false;
                    break;
                  }
                }
                else
                {
                  flag2 = false;
                  break;
                }
              }
            }
          }
        }
        checked { ++num3; }
      }
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      this.ExcelWorkSheet.Cells.get_Range((object) "A1", RuntimeHelpers.GetObjectValue((object) Missing.Value)).Select();
    }

    private string formatTime(int Minutes)
    {
      if (Minutes < 0)
        return "00:00";
      return Minutes % 60 < 10 ? Conversions.ToString(Math.Floor((double) Minutes / 60.0)) + ":0" + Conversions.ToString(Minutes % 60) : Conversions.ToString(Math.Floor((double) Minutes / 60.0)) + ":" + Conversions.ToString(Minutes % 60);
    }

    public void ServicingStatisticsReport(DataSet Data, string filePath)
    {
      string str1 = filePath;
      object obj1 = (object) 1;
      object obj2 = (object) 0;
      object obj3 = (object) 0;
      bool flag1 = true;
      string str2 = "";
      string str3 = "";
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Application instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
      instance.DisplayAlerts = false;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Workbook workbook = instance.Workbooks.Add(RuntimeHelpers.GetObjectValue((object) Missing.Value));
      int num1 = checked (this.DataSet.Tables.Count - 1);
      int index = 0;
      while (index <= num1)
      {
        DataTable table = this.DataSet.Tables[index];
        if (table.Rows.Count > 0)
        {
          // ISSUE: variable of a compiler-generated type
          Worksheet worksheet1 = (Worksheet) workbook.Worksheets[(object) checked (index + 1)];
          worksheet1.Name = table.TableName;
          DateTime dateTime = DateTime.MinValue;
          DateTime minValue = DateTime.MinValue;
          int RowNumber = 1;
          int num2 = 1;
          int count = table.Rows.Count;
          bool flag2 = false;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(table.TableName, "Visits Eng Breakdown (Actual)", false) == 0)
          {
            DataView defaultView = table.DefaultView;
            defaultView.Sort = "Weekdate ASC, EngineerName ASC";
            table = defaultView.ToTable();
          }
          IEnumerator enumerator;
          string ColumnNumber1;
          int num3;
          try
          {
            enumerator = table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              string tableName = table.TableName;
              // ISSUE: reference to a compiler-generated method
              switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(tableName))
              {
                case 484200899:
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName, "Weekly Stats Engineers (FC)", false) == 0)
                  {
                    if (RowNumber == 1 & !flag2)
                    {
                      ref Worksheet local1 = ref worksheet1;
                      ColumnNumber1 = "A" + RowNumber.ToString();
                      ref string local2 = ref ColumnNumber1;
                      object obj4 = (object) "";
                      ref object local3 = ref obj4;
                      this.SetCellValue(ref local1, ref local2, ref local3);
                      ref Worksheet local4 = ref worksheet1;
                      ColumnNumber1 = "B" + RowNumber.ToString();
                      ref string local5 = ref ColumnNumber1;
                      object obj5 = (object) "No of Engineers (Servicing)";
                      ref object local6 = ref obj5;
                      this.SetCellValue(ref local4, ref local5, ref local6);
                      ref Worksheet local7 = ref worksheet1;
                      ColumnNumber1 = "C" + RowNumber.ToString();
                      ref string local8 = ref ColumnNumber1;
                      object obj6 = (object) "No of Engineers (Safety Inspections)";
                      ref object local9 = ref obj6;
                      this.SetCellValue(ref local7, ref local8, ref local9);
                      ref Worksheet local10 = ref worksheet1;
                      ColumnNumber1 = "D" + RowNumber.ToString();
                      ref string local11 = ref ColumnNumber1;
                      object obj7 = (object) "Total No of Engineers";
                      ref object local12 = ref obj7;
                      this.SetCellValue(ref local10, ref local11, ref local12);
                      flag2 = true;
                      ref Worksheet local13 = ref worksheet1;
                      double num4 = (double) RowNumber;
                      num3 = 1;
                      double num5 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "A" + Conversions.ToString(num4 + num5);
                      ref string local14 = ref ColumnNumber1;
                      object obj8 = (object) current[0].ToString();
                      ref object local15 = ref obj8;
                      this.SetCellValue(ref local13, ref local14, ref local15);
                      ref Worksheet local16 = ref worksheet1;
                      double num6 = (double) RowNumber;
                      num3 = 1;
                      double num7 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "B" + Conversions.ToString(num6 + num7);
                      ref string local17 = ref ColumnNumber1;
                      object obj9 = (object) current[1].ToString();
                      ref object local18 = ref obj9;
                      this.SetCellValue(ref local16, ref local17, ref local18);
                      ref Worksheet local19 = ref worksheet1;
                      double num8 = (double) RowNumber;
                      num3 = 1;
                      double num9 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "C" + Conversions.ToString(num8 + num9);
                      ref string local20 = ref ColumnNumber1;
                      obj9 = (object) current[2].ToString();
                      ref object local21 = ref obj9;
                      this.SetCellValue(ref local19, ref local20, ref local21);
                      ref Worksheet local22 = ref worksheet1;
                      double num10 = (double) RowNumber;
                      num3 = 1;
                      double num11 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "D" + Conversions.ToString(num10 + num11);
                      ref string local23 = ref ColumnNumber1;
                      obj9 = (object) current[3].ToString();
                      ref object local24 = ref obj9;
                      this.SetCellValue(ref local22, ref local23, ref local24);
                      checked { ++RowNumber; }
                      goto default;
                    }
                    else
                    {
                      ref Worksheet local1 = ref worksheet1;
                      double num4 = (double) RowNumber;
                      num3 = 1;
                      double num5 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "A" + Conversions.ToString(num4 + num5);
                      ref string local2 = ref ColumnNumber1;
                      object obj4 = (object) current[0].ToString();
                      ref object local3 = ref obj4;
                      this.SetCellValue(ref local1, ref local2, ref local3);
                      ref Worksheet local4 = ref worksheet1;
                      double num6 = (double) RowNumber;
                      num3 = 1;
                      double num7 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "B" + Conversions.ToString(num6 + num7);
                      ref string local5 = ref ColumnNumber1;
                      object obj5 = (object) current[1].ToString();
                      ref object local6 = ref obj5;
                      this.SetCellValue(ref local4, ref local5, ref local6);
                      ref Worksheet local7 = ref worksheet1;
                      double num8 = (double) RowNumber;
                      num3 = 1;
                      double num9 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "C" + Conversions.ToString(num8 + num9);
                      ref string local8 = ref ColumnNumber1;
                      obj5 = (object) current[2].ToString();
                      ref object local9 = ref obj5;
                      this.SetCellValue(ref local7, ref local8, ref local9);
                      ref Worksheet local10 = ref worksheet1;
                      double num10 = (double) RowNumber;
                      num3 = 1;
                      double num11 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "D" + Conversions.ToString(num10 + num11);
                      ref string local11 = ref ColumnNumber1;
                      obj5 = (object) current[3].ToString();
                      ref object local12 = ref obj5;
                      this.SetCellValue(ref local10, ref local11, ref local12);
                      checked { ++RowNumber; }
                      goto default;
                    }
                  }
                  else
                    goto default;
                case 2049544289:
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName, "Second Letter Stage Sites", false) == 0)
                    break;
                  goto default;
                case 2853702136:
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName, "Visits Booked (Actual)", false) == 0)
                  {
                    if (RowNumber == 1 & !flag2)
                    {
                      ref Worksheet local1 = ref worksheet1;
                      ColumnNumber1 = "A" + RowNumber.ToString();
                      ref string local2 = ref ColumnNumber1;
                      object obj4 = (object) "Visit Start Date";
                      ref object local3 = ref obj4;
                      this.SetCellValue(ref local1, ref local2, ref local3);
                      ref Worksheet local4 = ref worksheet1;
                      ColumnNumber1 = "B" + RowNumber.ToString();
                      ref string local5 = ref ColumnNumber1;
                      object obj5 = (object) "Visit End Date";
                      ref object local6 = ref obj5;
                      this.SetCellValue(ref local4, ref local5, ref local6);
                      ref Worksheet local7 = ref worksheet1;
                      ColumnNumber1 = "C" + RowNumber.ToString();
                      ref string local8 = ref ColumnNumber1;
                      object obj6 = (object) "Site";
                      ref object local9 = ref obj6;
                      this.SetCellValue(ref local7, ref local8, ref local9);
                      ref Worksheet local10 = ref worksheet1;
                      ColumnNumber1 = "D" + RowNumber.ToString();
                      ref string local11 = ref ColumnNumber1;
                      object obj7 = (object) "Engineer";
                      ref object local12 = ref obj7;
                      this.SetCellValue(ref local10, ref local11, ref local12);
                      ref Worksheet local13 = ref worksheet1;
                      ColumnNumber1 = "E" + RowNumber.ToString();
                      ref string local14 = ref ColumnNumber1;
                      object obj8 = (object) "Letter Type";
                      ref object local15 = ref obj8;
                      this.SetCellValue(ref local13, ref local14, ref local15);
                      ref Worksheet local16 = ref worksheet1;
                      ColumnNumber1 = "E" + RowNumber.ToString();
                      ref string local17 = ref ColumnNumber1;
                      object obj9 = (object) "Job Number";
                      ref object local18 = ref obj9;
                      this.SetCellValue(ref local16, ref local17, ref local18);
                      flag2 = true;
                      ref Worksheet local19 = ref worksheet1;
                      double num4 = (double) RowNumber;
                      num3 = 1;
                      double num5 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "A" + Conversions.ToString(num4 + num5);
                      ref string local20 = ref ColumnNumber1;
                      obj9 = (object) current[0].ToString();
                      ref object local21 = ref obj9;
                      this.SetCellValue(ref local19, ref local20, ref local21);
                      ref Worksheet local22 = ref worksheet1;
                      double num6 = (double) RowNumber;
                      num3 = 1;
                      double num7 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "B" + Conversions.ToString(num6 + num7);
                      ref string local23 = ref ColumnNumber1;
                      obj9 = (object) current[1].ToString();
                      ref object local24 = ref obj9;
                      this.SetCellValue(ref local22, ref local23, ref local24);
                      ref Worksheet local25 = ref worksheet1;
                      double num8 = (double) RowNumber;
                      num3 = 1;
                      double num9 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "C" + Conversions.ToString(num8 + num9);
                      ref string local26 = ref ColumnNumber1;
                      obj9 = (object) current[2].ToString();
                      ref object local27 = ref obj9;
                      this.SetCellValue(ref local25, ref local26, ref local27);
                      ref Worksheet local28 = ref worksheet1;
                      double num10 = (double) RowNumber;
                      num3 = 1;
                      double num11 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "D" + Conversions.ToString(num10 + num11);
                      ref string local29 = ref ColumnNumber1;
                      obj9 = (object) current[3].ToString();
                      ref object local30 = ref obj9;
                      this.SetCellValue(ref local28, ref local29, ref local30);
                      ref Worksheet local31 = ref worksheet1;
                      double num12 = (double) RowNumber;
                      num3 = 1;
                      double num13 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "E" + Conversions.ToString(num12 + num13);
                      ref string local32 = ref ColumnNumber1;
                      obj9 = (object) current[4].ToString();
                      ref object local33 = ref obj9;
                      this.SetCellValue(ref local31, ref local32, ref local33);
                      ref Worksheet local34 = ref worksheet1;
                      double num14 = (double) RowNumber;
                      num3 = 1;
                      double num15 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "E" + Conversions.ToString(num14 + num15);
                      ref string local35 = ref ColumnNumber1;
                      obj9 = (object) current[5].ToString();
                      ref object local36 = ref obj9;
                      this.SetCellValue(ref local34, ref local35, ref local36);
                      checked { ++RowNumber; }
                      goto default;
                    }
                    else
                    {
                      ref Worksheet local1 = ref worksheet1;
                      double num4 = (double) RowNumber;
                      num3 = 1;
                      double num5 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "A" + Conversions.ToString(num4 + num5);
                      ref string local2 = ref ColumnNumber1;
                      object obj4 = (object) current[0].ToString();
                      ref object local3 = ref obj4;
                      this.SetCellValue(ref local1, ref local2, ref local3);
                      ref Worksheet local4 = ref worksheet1;
                      double num6 = (double) RowNumber;
                      num3 = 1;
                      double num7 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "B" + Conversions.ToString(num6 + num7);
                      ref string local5 = ref ColumnNumber1;
                      object obj5 = (object) current[1].ToString();
                      ref object local6 = ref obj5;
                      this.SetCellValue(ref local4, ref local5, ref local6);
                      ref Worksheet local7 = ref worksheet1;
                      double num8 = (double) RowNumber;
                      num3 = 1;
                      double num9 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "C" + Conversions.ToString(num8 + num9);
                      ref string local8 = ref ColumnNumber1;
                      obj5 = (object) current[2].ToString();
                      ref object local9 = ref obj5;
                      this.SetCellValue(ref local7, ref local8, ref local9);
                      ref Worksheet local10 = ref worksheet1;
                      double num10 = (double) RowNumber;
                      num3 = 1;
                      double num11 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "D" + Conversions.ToString(num10 + num11);
                      ref string local11 = ref ColumnNumber1;
                      obj5 = (object) current[3].ToString();
                      ref object local12 = ref obj5;
                      this.SetCellValue(ref local10, ref local11, ref local12);
                      ref Worksheet local13 = ref worksheet1;
                      double num12 = (double) RowNumber;
                      num3 = 1;
                      double num13 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "E" + Conversions.ToString(num12 + num13);
                      ref string local14 = ref ColumnNumber1;
                      obj5 = (object) current[4].ToString();
                      ref object local15 = ref obj5;
                      this.SetCellValue(ref local13, ref local14, ref local15);
                      ref Worksheet local16 = ref worksheet1;
                      double num14 = (double) RowNumber;
                      num3 = 1;
                      double num15 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "E" + Conversions.ToString(num14 + num15);
                      ref string local17 = ref ColumnNumber1;
                      obj5 = (object) current[5].ToString();
                      ref object local18 = ref obj5;
                      this.SetCellValue(ref local16, ref local17, ref local18);
                      checked { ++RowNumber; }
                      goto default;
                    }
                  }
                  else
                    goto default;
                case 3498234447:
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName, "Visits Eng Breakdown (Actual)", false) == 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current[0].ToString(), "", false) != 0)
                  {
                    if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
                    {
                      dateTime = Conversions.ToDate(current[0].ToString());
                      ref Worksheet local1 = ref worksheet1;
                      string str4 = "1";
                      ref string local2 = ref str4;
                      num3 = 1;
                      ref int local3 = ref num3;
                      ColumnNumber1 = this.GetCellRef(ref local2, ref local3);
                      ref string local4 = ref ColumnNumber1;
                      object obj4 = (object) "";
                      ref object local5 = ref obj4;
                      this.SetCellValue(ref local1, ref local4, ref local5);
                      ref Worksheet local6 = ref worksheet1;
                      str4 = "2";
                      ref string local7 = ref str4;
                      num3 = 1;
                      ref int local8 = ref num3;
                      ColumnNumber1 = this.GetCellRef(ref local7, ref local8);
                      ref string local9 = ref ColumnNumber1;
                      object obj5 = (object) current[1].ToString();
                      ref object local10 = ref obj5;
                      this.SetCellValue(ref local6, ref local9, ref local10);
                      ref Worksheet local11 = ref worksheet1;
                      str4 = "1";
                      ref string local12 = ref str4;
                      num3 = 2;
                      ref int local13 = ref num3;
                      ColumnNumber1 = this.GetCellRef(ref local12, ref local13);
                      ref string local14 = ref ColumnNumber1;
                      object obj6 = (object) current[0].ToString();
                      ref object local15 = ref obj6;
                      this.SetCellValue(ref local11, ref local14, ref local15);
                      ref Worksheet local16 = ref worksheet1;
                      str4 = "2";
                      ref string local17 = ref str4;
                      num3 = 2;
                      ref int local18 = ref num3;
                      ColumnNumber1 = this.GetCellRef(ref local17, ref local18);
                      ref string local19 = ref ColumnNumber1;
                      object obj7 = (object) current[2].ToString();
                      ref object local20 = ref obj7;
                      this.SetCellValue(ref local16, ref local19, ref local20);
                      num2 = 3;
                      RowNumber = 2;
                      goto default;
                    }
                    else
                    {
                      DateTime date = Conversions.ToDate(current[0].ToString());
                      if (DateTime.Compare(date, dateTime) == 0)
                      {
                        if (RowNumber == 2)
                        {
                          ref Worksheet local1 = ref worksheet1;
                          string str4 = Conversions.ToString(num2);
                          ref string local2 = ref str4;
                          num3 = checked (RowNumber - 1);
                          ref int local3 = ref num3;
                          ColumnNumber1 = this.GetCellRef(ref local2, ref local3);
                          ref string local4 = ref ColumnNumber1;
                          object obj4 = (object) current[1].ToString();
                          ref object local5 = ref obj4;
                          this.SetCellValue(ref local1, ref local4, ref local5);
                        }
                        ref Worksheet local6 = ref worksheet1;
                        string ColumnNumber2 = Conversions.ToString(num2);
                        ColumnNumber1 = this.GetCellRef(ref ColumnNumber2, ref RowNumber);
                        ref string local7 = ref ColumnNumber1;
                        object obj5 = (object) current[2].ToString();
                        ref object local8 = ref obj5;
                        this.SetCellValue(ref local6, ref local7, ref local8);
                        checked { ++num2; }
                      }
                      else
                      {
                        checked { ++RowNumber; }
                        num2 = 2;
                        ref Worksheet local1 = ref worksheet1;
                        string ColumnNumber2 = "1";
                        ColumnNumber1 = this.GetCellRef(ref ColumnNumber2, ref RowNumber);
                        ref string local2 = ref ColumnNumber1;
                        object obj4 = (object) current[0].ToString();
                        ref object local3 = ref obj4;
                        this.SetCellValue(ref local1, ref local2, ref local3);
                        ref Worksheet local4 = ref worksheet1;
                        string ColumnNumber3 = Conversions.ToString(num2);
                        ColumnNumber1 = this.GetCellRef(ref ColumnNumber3, ref RowNumber);
                        ref string local5 = ref ColumnNumber1;
                        object obj5 = (object) current[2].ToString();
                        ref object local6 = ref obj5;
                        this.SetCellValue(ref local4, ref local5, ref local6);
                        dateTime = date;
                        checked { ++num2; }
                      }
                      goto default;
                    }
                  }
                  else
                    goto default;
                case 3565247129:
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName, "Weekly Stats (FC)", false) == 0)
                  {
                    if (RowNumber == 1 & !flag2)
                    {
                      ref Worksheet local1 = ref worksheet1;
                      ColumnNumber1 = "A" + RowNumber.ToString();
                      ref string local2 = ref ColumnNumber1;
                      object obj4 = (object) "";
                      ref object local3 = ref obj4;
                      this.SetCellValue(ref local1, ref local2, ref local3);
                      ref Worksheet local4 = ref worksheet1;
                      ColumnNumber1 = "B" + RowNumber.ToString();
                      ref string local5 = ref ColumnNumber1;
                      object obj5 = (object) "No of Services";
                      ref object local6 = ref obj5;
                      this.SetCellValue(ref local4, ref local5, ref local6);
                      ref Worksheet local7 = ref worksheet1;
                      ColumnNumber1 = "C" + RowNumber.ToString();
                      ref string local8 = ref ColumnNumber1;
                      object obj6 = (object) "1st Letter Stage";
                      ref object local9 = ref obj6;
                      this.SetCellValue(ref local7, ref local8, ref local9);
                      ref Worksheet local10 = ref worksheet1;
                      ColumnNumber1 = "D" + RowNumber.ToString();
                      ref string local11 = ref ColumnNumber1;
                      object obj7 = (object) "2nd Letter Stage";
                      ref object local12 = ref obj7;
                      this.SetCellValue(ref local10, ref local11, ref local12);
                      ref Worksheet local13 = ref worksheet1;
                      ColumnNumber1 = "E" + RowNumber.ToString();
                      ref string local14 = ref ColumnNumber1;
                      object obj8 = (object) "3rd Letter Stage";
                      ref object local15 = ref obj8;
                      this.SetCellValue(ref local13, ref local14, ref local15);
                      ref Worksheet local16 = ref worksheet1;
                      ColumnNumber1 = "F" + RowNumber.ToString();
                      ref string local17 = ref ColumnNumber1;
                      object obj9 = (object) "No of Safety Inspections";
                      ref object local18 = ref obj9;
                      this.SetCellValue(ref local16, ref local17, ref local18);
                      ref Worksheet local19 = ref worksheet1;
                      ColumnNumber1 = "G" + RowNumber.ToString();
                      ref string local20 = ref ColumnNumber1;
                      obj9 = (object) "Predicted 1st Visit Access Level";
                      ref object local21 = ref obj9;
                      this.SetCellValue(ref local19, ref local20, ref local21);
                      ref Worksheet local22 = ref worksheet1;
                      ColumnNumber1 = "H" + RowNumber.ToString();
                      ref string local23 = ref ColumnNumber1;
                      obj9 = (object) "Predicted 2nd Visit Access Level";
                      ref object local24 = ref obj9;
                      this.SetCellValue(ref local22, ref local23, ref local24);
                      ref Worksheet local25 = ref worksheet1;
                      ColumnNumber1 = "I" + RowNumber.ToString();
                      ref string local26 = ref ColumnNumber1;
                      obj9 = (object) "Predicted 3rd Visit Access Level";
                      ref object local27 = ref obj9;
                      this.SetCellValue(ref local25, ref local26, ref local27);
                      flag2 = true;
                      ref Worksheet local28 = ref worksheet1;
                      double num4 = (double) RowNumber;
                      num3 = 1;
                      double num5 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "A" + Conversions.ToString(num4 + num5);
                      ref string local29 = ref ColumnNumber1;
                      obj9 = (object) current[0].ToString();
                      ref object local30 = ref obj9;
                      this.SetCellValue(ref local28, ref local29, ref local30);
                      ref Worksheet local31 = ref worksheet1;
                      double num6 = (double) RowNumber;
                      num3 = 1;
                      double num7 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "B" + Conversions.ToString(num6 + num7);
                      ref string local32 = ref ColumnNumber1;
                      obj9 = (object) current[1].ToString();
                      ref object local33 = ref obj9;
                      this.SetCellValue(ref local31, ref local32, ref local33);
                      ref Worksheet local34 = ref worksheet1;
                      double num8 = (double) RowNumber;
                      num3 = 1;
                      double num9 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "C" + Conversions.ToString(num8 + num9);
                      ref string local35 = ref ColumnNumber1;
                      obj9 = (object) current[2].ToString();
                      ref object local36 = ref obj9;
                      this.SetCellValue(ref local34, ref local35, ref local36);
                      ref Worksheet local37 = ref worksheet1;
                      double num10 = (double) RowNumber;
                      num3 = 1;
                      double num11 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "D" + Conversions.ToString(num10 + num11);
                      ref string local38 = ref ColumnNumber1;
                      obj9 = (object) current[3].ToString();
                      ref object local39 = ref obj9;
                      this.SetCellValue(ref local37, ref local38, ref local39);
                      ref Worksheet local40 = ref worksheet1;
                      double num12 = (double) RowNumber;
                      num3 = 1;
                      double num13 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "E" + Conversions.ToString(num12 + num13);
                      ref string local41 = ref ColumnNumber1;
                      obj9 = (object) current[4].ToString();
                      ref object local42 = ref obj9;
                      this.SetCellValue(ref local40, ref local41, ref local42);
                      ref Worksheet local43 = ref worksheet1;
                      double num14 = (double) RowNumber;
                      num3 = 1;
                      double num15 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "F" + Conversions.ToString(num14 + num15);
                      ref string local44 = ref ColumnNumber1;
                      obj9 = (object) current[5].ToString();
                      ref object local45 = ref obj9;
                      this.SetCellValue(ref local43, ref local44, ref local45);
                      ref Worksheet local46 = ref worksheet1;
                      double num16 = (double) RowNumber;
                      num3 = 1;
                      double num17 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "G" + Conversions.ToString(num16 + num17);
                      ref string local47 = ref ColumnNumber1;
                      obj9 = (object) current[6].ToString();
                      ref object local48 = ref obj9;
                      this.SetCellValue(ref local46, ref local47, ref local48);
                      ref Worksheet local49 = ref worksheet1;
                      double num18 = (double) RowNumber;
                      num3 = 1;
                      double num19 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "H" + Conversions.ToString(num18 + num19);
                      ref string local50 = ref ColumnNumber1;
                      obj9 = (object) current[7].ToString();
                      ref object local51 = ref obj9;
                      this.SetCellValue(ref local49, ref local50, ref local51);
                      ref Worksheet local52 = ref worksheet1;
                      double num20 = (double) RowNumber;
                      num3 = 1;
                      double num21 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "I" + Conversions.ToString(num20 + num21);
                      ref string local53 = ref ColumnNumber1;
                      obj9 = (object) current[8].ToString();
                      ref object local54 = ref obj9;
                      this.SetCellValue(ref local52, ref local53, ref local54);
                      checked { ++RowNumber; }
                      goto default;
                    }
                    else
                    {
                      ref Worksheet local1 = ref worksheet1;
                      double num4 = (double) RowNumber;
                      num3 = 1;
                      double num5 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "A" + Conversions.ToString(num4 + num5);
                      ref string local2 = ref ColumnNumber1;
                      object date = (object) Conversions.ToDate(current[0].ToString());
                      ref object local3 = ref date;
                      this.SetCellValue(ref local1, ref local2, ref local3);
                      ref Worksheet local4 = ref worksheet1;
                      double num6 = (double) RowNumber;
                      num3 = 1;
                      double num7 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "B" + Conversions.ToString(num6 + num7);
                      ref string local5 = ref ColumnNumber1;
                      object obj4 = (object) current[1].ToString();
                      ref object local6 = ref obj4;
                      this.SetCellValue(ref local4, ref local5, ref local6);
                      ref Worksheet local7 = ref worksheet1;
                      double num8 = (double) RowNumber;
                      num3 = 1;
                      double num9 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "C" + Conversions.ToString(num8 + num9);
                      ref string local8 = ref ColumnNumber1;
                      object obj5 = (object) current[2].ToString();
                      ref object local9 = ref obj5;
                      this.SetCellValue(ref local7, ref local8, ref local9);
                      ref Worksheet local10 = ref worksheet1;
                      double num10 = (double) RowNumber;
                      num3 = 1;
                      double num11 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "D" + Conversions.ToString(num10 + num11);
                      ref string local11 = ref ColumnNumber1;
                      object obj6 = (object) current[3].ToString();
                      ref object local12 = ref obj6;
                      this.SetCellValue(ref local10, ref local11, ref local12);
                      ref Worksheet local13 = ref worksheet1;
                      double num12 = (double) RowNumber;
                      num3 = 1;
                      double num13 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "E" + Conversions.ToString(num12 + num13);
                      ref string local14 = ref ColumnNumber1;
                      object obj7 = (object) current[4].ToString();
                      ref object local15 = ref obj7;
                      this.SetCellValue(ref local13, ref local14, ref local15);
                      ref Worksheet local16 = ref worksheet1;
                      double num14 = (double) RowNumber;
                      num3 = 1;
                      double num15 = Conversions.ToDouble(num3.ToString());
                      ColumnNumber1 = "F" + Conversions.ToString(num14 + num15);
                      ref string local17 = ref ColumnNumber1;
                      object obj8 = (object) current[5].ToString();
                      ref object local18 = ref obj8;
                      this.SetCellValue(ref local16, ref local17, ref local18);
                      checked { ++RowNumber; }
                      goto default;
                    }
                  }
                  else
                    goto default;
                case 3657835165:
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName, "First Letter Stage Sites", false) == 0)
                    break;
                  goto default;
                case 4166119486:
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName, "Overall Servicing", false) == 0)
                  {
                    ref Worksheet local1 = ref worksheet1;
                    ColumnNumber1 = "A" + RowNumber.ToString();
                    ref string local2 = ref ColumnNumber1;
                    object obj4 = (object) current[0].ToString();
                    ref object local3 = ref obj4;
                    this.SetCellValue(ref local1, ref local2, ref local3);
                    ref Worksheet local4 = ref worksheet1;
                    ColumnNumber1 = "B" + RowNumber.ToString();
                    ref string local5 = ref ColumnNumber1;
                    object obj5 = (object) current[1].ToString();
                    ref object local6 = ref obj5;
                    this.SetCellValue(ref local4, ref local5, ref local6);
                    checked { ++RowNumber; }
                    goto default;
                  }
                  else
                    goto default;
                case 4272013044:
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName, "Third Letter Stage Sites", false) == 0)
                    break;
                  goto default;
                default:
label_36:
                  continue;
              }
              if (RowNumber == 1 & !flag2)
              {
                ref Worksheet local1 = ref worksheet1;
                ColumnNumber1 = "A" + RowNumber.ToString();
                ref string local2 = ref ColumnNumber1;
                object obj4 = (object) "UPRN";
                ref object local3 = ref obj4;
                this.SetCellValue(ref local1, ref local2, ref local3);
                ref Worksheet local4 = ref worksheet1;
                ColumnNumber1 = "B" + RowNumber.ToString();
                ref string local5 = ref ColumnNumber1;
                object obj5 = (object) "Address1";
                ref object local6 = ref obj5;
                this.SetCellValue(ref local4, ref local5, ref local6);
                ref Worksheet local7 = ref worksheet1;
                ColumnNumber1 = "C" + RowNumber.ToString();
                ref string local8 = ref ColumnNumber1;
                object obj6 = (object) "Postcode";
                ref object local9 = ref obj6;
                this.SetCellValue(ref local7, ref local8, ref local9);
                ref Worksheet local10 = ref worksheet1;
                ColumnNumber1 = "D" + RowNumber.ToString();
                ref string local11 = ref ColumnNumber1;
                object obj7 = (object) "Site Fuel";
                ref object local12 = ref obj7;
                this.SetCellValue(ref local10, ref local11, ref local12);
                ref Worksheet local13 = ref worksheet1;
                ColumnNumber1 = "E" + RowNumber.ToString();
                ref string local14 = ref ColumnNumber1;
                object obj8 = (object) "Last Service Date";
                ref object local15 = ref obj8;
                this.SetCellValue(ref local13, ref local14, ref local15);
                flag2 = true;
                ref Worksheet local16 = ref worksheet1;
                double num4 = (double) RowNumber;
                num3 = 1;
                double num5 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "A" + Conversions.ToString(num4 + num5);
                ref string local17 = ref ColumnNumber1;
                object obj9 = (object) current[2].ToString();
                ref object local18 = ref obj9;
                this.SetCellValue(ref local16, ref local17, ref local18);
                ref Worksheet local19 = ref worksheet1;
                double num6 = (double) RowNumber;
                num3 = 1;
                double num7 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "B" + Conversions.ToString(num6 + num7);
                ref string local20 = ref ColumnNumber1;
                obj9 = (object) current[5].ToString();
                ref object local21 = ref obj9;
                this.SetCellValue(ref local19, ref local20, ref local21);
                ref Worksheet local22 = ref worksheet1;
                double num8 = (double) RowNumber;
                num3 = 1;
                double num9 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "C" + Conversions.ToString(num8 + num9);
                ref string local23 = ref ColumnNumber1;
                obj9 = (object) current[6].ToString();
                ref object local24 = ref obj9;
                this.SetCellValue(ref local22, ref local23, ref local24);
                ref Worksheet local25 = ref worksheet1;
                double num10 = (double) RowNumber;
                num3 = 1;
                double num11 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "D" + Conversions.ToString(num10 + num11);
                ref string local26 = ref ColumnNumber1;
                obj9 = (object) current[7].ToString();
                ref object local27 = ref obj9;
                this.SetCellValue(ref local25, ref local26, ref local27);
                ref Worksheet local28 = ref worksheet1;
                double num12 = (double) RowNumber;
                num3 = 1;
                double num13 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "E" + Conversions.ToString(num12 + num13);
                ref string local29 = ref ColumnNumber1;
                obj9 = (object) Strings.FormatDateTime(Conversions.ToDate(current[8].ToString()), DateFormat.ShortDate);
                ref object local30 = ref obj9;
                this.SetCellValue(ref local28, ref local29, ref local30);
                checked { ++RowNumber; }
                goto label_36;
              }
              else
              {
                ref Worksheet local1 = ref worksheet1;
                double num4 = (double) RowNumber;
                num3 = 1;
                double num5 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "A" + Conversions.ToString(num4 + num5);
                ref string local2 = ref ColumnNumber1;
                object obj4 = (object) current[2].ToString();
                ref object local3 = ref obj4;
                this.SetCellValue(ref local1, ref local2, ref local3);
                ref Worksheet local4 = ref worksheet1;
                double num6 = (double) RowNumber;
                num3 = 1;
                double num7 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "B" + Conversions.ToString(num6 + num7);
                ref string local5 = ref ColumnNumber1;
                object obj5 = (object) current[5].ToString();
                ref object local6 = ref obj5;
                this.SetCellValue(ref local4, ref local5, ref local6);
                ref Worksheet local7 = ref worksheet1;
                double num8 = (double) RowNumber;
                num3 = 1;
                double num9 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "C" + Conversions.ToString(num8 + num9);
                ref string local8 = ref ColumnNumber1;
                obj5 = (object) current[6].ToString();
                ref object local9 = ref obj5;
                this.SetCellValue(ref local7, ref local8, ref local9);
                ref Worksheet local10 = ref worksheet1;
                double num10 = (double) RowNumber;
                num3 = 1;
                double num11 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "D" + Conversions.ToString(num10 + num11);
                ref string local11 = ref ColumnNumber1;
                obj5 = (object) current[7].ToString();
                ref object local12 = ref obj5;
                this.SetCellValue(ref local10, ref local11, ref local12);
                ref Worksheet local13 = ref worksheet1;
                double num12 = (double) RowNumber;
                num3 = 1;
                double num13 = Conversions.ToDouble(num3.ToString());
                ColumnNumber1 = "E" + Conversions.ToString(num12 + num13);
                ref string local14 = ref ColumnNumber1;
                obj5 = (object) Strings.FormatDateTime(Conversions.ToDate(current[8].ToString()), DateFormat.ShortDate);
                ref object local15 = ref obj5;
                this.SetCellValue(ref local13, ref local14, ref local15);
                checked { ++RowNumber; }
                goto label_36;
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          string tableName1 = table.TableName;
          // ISSUE: variable of a compiler-generated type
          Microsoft.Office.Interop.Excel.Range Source;
          // ISSUE: variable of a compiler-generated type
          Microsoft.Office.Interop.Excel.Range range;
          // ISSUE: reference to a compiler-generated method
          switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(tableName1))
          {
            case 484200899:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName1, "Weekly Stats Engineers (FC)", false) == 0)
              {
                // ISSUE: reference to a compiler-generated method
                Source = worksheet1.get_Range((object) "A1", (object) ("D" + RowNumber.ToString()));
                // ISSUE: reference to a compiler-generated method
                range = worksheet1.get_Range((object) "A1", (object) ("A" + RowNumber.ToString()));
                goto default;
              }
              else
                goto default;
            case 2049544289:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName1, "Second Letter Stage Sites", false) == 0)
                break;
              goto default;
            case 2853702136:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName1, "Visits Booked (Actual)", false) == 0)
                break;
              goto default;
            case 3498234447:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName1, "Visits Eng Breakdown (Actual)", false) == 0)
              {
                // ISSUE: variable of a compiler-generated type
                Worksheet worksheet2 = worksheet1;
                num3 = checked (num2 - 1);
                ColumnNumber1 = num3.ToString();
                string cellRef = this.GetCellRef(ref ColumnNumber1, ref RowNumber);
                // ISSUE: reference to a compiler-generated method
                Source = worksheet2.get_Range((object) "A1", (object) cellRef);
                // ISSUE: reference to a compiler-generated method
                range = worksheet1.get_Range((object) "A1", (object) ("A" + RowNumber.ToString()));
                goto default;
              }
              else
                goto default;
            case 3565247129:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName1, "Weekly Stats (FC)", false) == 0)
              {
                // ISSUE: reference to a compiler-generated method
                Source = worksheet1.get_Range((object) "A1", (object) ("F" + RowNumber.ToString()));
                // ISSUE: reference to a compiler-generated method
                range = worksheet1.get_Range((object) "A1", (object) ("A" + RowNumber.ToString()));
                goto default;
              }
              else
                goto default;
            case 3657835165:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName1, "First Letter Stage Sites", false) == 0)
                break;
              goto default;
            case 4166119486:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName1, "Overall Servicing", false) == 0)
              {
                // ISSUE: variable of a compiler-generated type
                Worksheet worksheet2 = worksheet1;
                double num4 = (double) RowNumber;
                num3 = 1;
                double num5 = Conversions.ToDouble(num3.ToString());
                string str4 = "B" + Conversions.ToString(num4 - num5);
                // ISSUE: reference to a compiler-generated method
                Source = worksheet2.get_Range((object) "A1", (object) str4);
                // ISSUE: variable of a compiler-generated type
                Worksheet worksheet3 = worksheet1;
                double num6 = (double) RowNumber;
                num3 = 1;
                double num7 = Conversions.ToDouble(num3.ToString());
                string str5 = "A" + Conversions.ToString(num6 - num7);
                // ISSUE: reference to a compiler-generated method
                range = worksheet3.get_Range((object) "A1", (object) str5);
                goto default;
              }
              else
                goto default;
            case 4272013044:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName1, "Third Letter Stage Sites", false) == 0)
                break;
              goto default;
            default:
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              ChartObjects chartObjects = (ChartObjects) worksheet1.ChartObjects(RuntimeHelpers.GetObjectValue((object) Missing.Value));
              string tableName2 = table.TableName;
              // ISSUE: variable of a compiler-generated type
              ChartObject chartObject;
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName2, "Overall Servicing", false) != 0)
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName2, "Weekly Stats (FC)", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName2, "Weekly Stats Engineers (FC)", false) != 0)
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(tableName2, "Visits Eng Breakdown (Actual)", false) == 0)
                    {
                      // ISSUE: reference to a compiler-generated method
                      chartObject = chartObjects.Add(50.0, 175.0, 800.0, 300.0);
                      string str4 = "Engineers Visits Booked";
                      // ISSUE: reference to a compiler-generated method
                      chartObject.Chart.ChartWizard((object) Source, (object) XlChartType.xlLineMarkers, RuntimeHelpers.GetObjectValue(obj1), (object) XlRowCol.xlRows, RuntimeHelpers.GetObjectValue(obj3), (object) range, (object) flag1, (object) str4, (object) str2, (object) str3, RuntimeHelpers.GetObjectValue((object) Missing.Value));
                    }
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated method
                    chartObject = chartObjects.Add(450.0, 30.0, 300.0, 300.0);
                    string str4 = "Engineers Required per week Forecast";
                    // ISSUE: reference to a compiler-generated method
                    chartObject.Chart.ChartWizard((object) Source, (object) XlChartType.xlLineMarkers, RuntimeHelpers.GetObjectValue(obj1), (object) XlRowCol.xlRows, RuntimeHelpers.GetObjectValue(obj3), (object) range, (object) flag1, (object) str4, (object) str2, (object) str3, RuntimeHelpers.GetObjectValue((object) Missing.Value));
                  }
                }
                else
                {
                  // ISSUE: reference to a compiler-generated method
                  chartObject = chartObjects.Add(450.0, 30.0, 1000.0, 600.0);
                  string str4 = "Servicing per Week Forecast";
                  // ISSUE: reference to a compiler-generated method
                  chartObject.Chart.ChartWizard((object) Source, (object) XlChartType.xlLineMarkers, RuntimeHelpers.GetObjectValue(obj1), (object) XlRowCol.xlRows, RuntimeHelpers.GetObjectValue(obj3), (object) range, (object) flag1, (object) str4, (object) str2, (object) str3, RuntimeHelpers.GetObjectValue((object) Missing.Value));
                  // ISSUE: reference to a compiler-generated method
                  Source.EntireColumn.AutoFit();
                }
              }
              else
              {
                // ISSUE: reference to a compiler-generated method
                chartObject = chartObjects.Add(450.0, 30.0, 300.0, 300.0);
                string str4 = "Overall Servicing";
                // ISSUE: reference to a compiler-generated method
                chartObject.Chart.ChartWizard((object) Source, (object) XlChartType.xl3DColumn, RuntimeHelpers.GetObjectValue(obj1), (object) XlRowCol.xlRows, (object) range, RuntimeHelpers.GetObjectValue(obj3), (object) flag1, (object) str4, (object) str2, (object) str3, RuntimeHelpers.GetObjectValue((object) Missing.Value));
              }
              // ISSUE: reference to a compiler-generated method
              chartObject.Chart.SetSourceData(Source, RuntimeHelpers.GetObjectValue((object) Missing.Value));
              // ISSUE: reference to a compiler-generated method
              chartObject.Chart.SeriesCollection(RuntimeHelpers.GetObjectValue((object) Missing.Value));
              // ISSUE: reference to a compiler-generated method
              // ISSUE: variable of a compiler-generated type
              Axis axis = (Axis) chartObject.Chart.Axes((object) XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
              axis.HasMajorGridlines = true;
              axis.MajorGridlines.Border.Color = (object) Color.Gray.ToArgb();
              axis.MajorGridlines.Border.LineStyle = (object) XlLineStyle.xlContinuous;
              axis.CategoryType = XlCategoryType.xlCategoryScale;
              break;
          }
          // ISSUE: reference to a compiler-generated method
          workbook.Worksheets.Add(RuntimeHelpers.GetObjectValue((object) Missing.Value), (object) worksheet1, (object) 1, RuntimeHelpers.GetObjectValue((object) Missing.Value));
        }
        checked { ++index; }
      }
      // ISSUE: variable of a compiler-generated type
      Worksheet worksheet = (Worksheet) workbook.Worksheets[(object) 1];
      // ISSUE: reference to a compiler-generated method
      worksheet.Activate();
      // ISSUE: reference to a compiler-generated method
      workbook.SaveAs((object) str1, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), XlSaveAsAccessMode.xlNoChange, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      workbook?.Close((object) false, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      instance?.Quit();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    public void ServicingStatisticsReportWorking()
    {
      string str1 = "C:\\Temp\\Test.xlsx";
      object obj1 = (object) 1;
      object obj2 = (object) 0;
      object obj3 = (object) 0;
      bool flag = true;
      string str2 = "Servicing per week";
      string str3 = "";
      string str4 = "";
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Application instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
      instance.DisplayAlerts = false;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Workbook workbook = instance.Workbooks.Add(RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: variable of a compiler-generated type
      Worksheet worksheet = (Worksheet) workbook.Worksheets[(object) 1];
      worksheet.Name = "Quarterly Sales";
      ref Worksheet local1 = ref worksheet;
      string str5 = "A2";
      ref string local2 = ref str5;
      object obj4 = (object) "Week 1";
      ref object local3 = ref obj4;
      this.SetCellValue(ref local1, ref local2, ref local3);
      ref Worksheet local4 = ref worksheet;
      string str6 = "A3";
      ref string local5 = ref str6;
      object obj5 = (object) "Week 2";
      ref object local6 = ref obj5;
      this.SetCellValue(ref local4, ref local5, ref local6);
      ref Worksheet local7 = ref worksheet;
      string str7 = "A4";
      ref string local8 = ref str7;
      object obj6 = (object) "Week 3";
      ref object local9 = ref obj6;
      this.SetCellValue(ref local7, ref local8, ref local9);
      ref Worksheet local10 = ref worksheet;
      string str8 = "A5";
      ref string local11 = ref str8;
      object obj7 = (object) "Week 4";
      ref object local12 = ref obj7;
      this.SetCellValue(ref local10, ref local11, ref local12);
      ref Worksheet local13 = ref worksheet;
      string str9 = "B1";
      ref string local14 = ref str9;
      object obj8 = (object) "# of services";
      ref object local15 = ref obj8;
      this.SetCellValue(ref local13, ref local14, ref local15);
      ref Worksheet local16 = ref worksheet;
      string str10 = "B2";
      ref string local17 = ref str10;
      object obj9 = (object) 1.5;
      ref object local18 = ref obj9;
      this.SetCellValue(ref local16, ref local17, ref local18);
      ref Worksheet local19 = ref worksheet;
      string str11 = "B3";
      ref string local20 = ref str11;
      object obj10 = (object) 2;
      ref object local21 = ref obj10;
      this.SetCellValue(ref local19, ref local20, ref local21);
      ref Worksheet local22 = ref worksheet;
      string str12 = "B4";
      ref string local23 = ref str12;
      object obj11 = (object) 2.25;
      ref object local24 = ref obj11;
      this.SetCellValue(ref local22, ref local23, ref local24);
      ref Worksheet local25 = ref worksheet;
      string str13 = "B5";
      ref string local26 = ref str13;
      object obj12 = (object) 2.5;
      ref object local27 = ref obj12;
      this.SetCellValue(ref local25, ref local26, ref local27);
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Range Source = worksheet.get_Range((object) "A1", (object) "B5");
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range((object) "A2", (object) "A5");
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      ChartObjects chartObjects = (ChartObjects) worksheet.ChartObjects(RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      ChartObject chartObject = chartObjects.Add(185.0, 30.0, 300.0, 300.0);
      // ISSUE: reference to a compiler-generated method
      chartObject.Chart.ChartWizard((object) Source, (object) XlChartType.xlLineMarkers, RuntimeHelpers.GetObjectValue(obj1), (object) XlRowCol.xlRows, (object) range, RuntimeHelpers.GetObjectValue(obj3), (object) flag, (object) str2, (object) str3, (object) str4, RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      chartObject.Chart.SetSourceData(Source, RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      chartObject.Chart.SeriesCollection(RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Axis axis = (Axis) chartObject.Chart.Axes((object) XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
      axis.HasMajorGridlines = true;
      axis.MajorGridlines.Border.Color = (object) Color.Gray.ToArgb();
      axis.MajorGridlines.Border.LineStyle = (object) XlLineStyle.xlContinuous;
      // ISSUE: reference to a compiler-generated method
      workbook.SaveAs((object) str1, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), XlSaveAsAccessMode.xlNoChange, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      workbook?.Close((object) false, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      instance?.Quit();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    public void ServicingStatisticsReportOriginal()
    {
      string str1 = "C:\\Temp\\Test.xlsx";
      object obj1 = (object) 1;
      object obj2 = (object) 0;
      object obj3 = (object) 0;
      bool flag = true;
      string str2 = "Sales by Quarter";
      string str3 = "Fiscal Quarter";
      string str4 = "Billions";
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Application instance = (Microsoft.Office.Interop.Excel.Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
      instance.DisplayAlerts = false;
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Workbook workbook = instance.Workbooks.Add(RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: variable of a compiler-generated type
      Worksheet worksheet = (Worksheet) workbook.Worksheets[(object) 1];
      worksheet.Name = "Quarterly Sales";
      ref Worksheet local1 = ref worksheet;
      string str5 = "A2";
      ref string local2 = ref str5;
      object obj4 = (object) "N. America";
      ref object local3 = ref obj4;
      this.SetCellValue(ref local1, ref local2, ref local3);
      ref Worksheet local4 = ref worksheet;
      string str6 = "A3";
      ref string local5 = ref str6;
      object obj5 = (object) "S. America";
      ref object local6 = ref obj5;
      this.SetCellValue(ref local4, ref local5, ref local6);
      ref Worksheet local7 = ref worksheet;
      string str7 = "A4";
      ref string local8 = ref str7;
      object obj6 = (object) "Europe";
      ref object local9 = ref obj6;
      this.SetCellValue(ref local7, ref local8, ref local9);
      ref Worksheet local10 = ref worksheet;
      string str8 = "A5";
      ref string local11 = ref str8;
      object obj7 = (object) "Asia";
      ref object local12 = ref obj7;
      this.SetCellValue(ref local10, ref local11, ref local12);
      ref Worksheet local13 = ref worksheet;
      string str9 = "B1";
      ref string local14 = ref str9;
      object obj8 = (object) "Q1";
      ref object local15 = ref obj8;
      this.SetCellValue(ref local13, ref local14, ref local15);
      ref Worksheet local16 = ref worksheet;
      string str10 = "B2";
      ref string local17 = ref str10;
      object obj9 = (object) 1.5;
      ref object local18 = ref obj9;
      this.SetCellValue(ref local16, ref local17, ref local18);
      ref Worksheet local19 = ref worksheet;
      string str11 = "B3";
      ref string local20 = ref str11;
      object obj10 = (object) 2;
      ref object local21 = ref obj10;
      this.SetCellValue(ref local19, ref local20, ref local21);
      ref Worksheet local22 = ref worksheet;
      string str12 = "B4";
      ref string local23 = ref str12;
      object obj11 = (object) 2.25;
      ref object local24 = ref obj11;
      this.SetCellValue(ref local22, ref local23, ref local24);
      ref Worksheet local25 = ref worksheet;
      string str13 = "B5";
      ref string local26 = ref str13;
      object obj12 = (object) 2.5;
      ref object local27 = ref obj12;
      this.SetCellValue(ref local25, ref local26, ref local27);
      ref Worksheet local28 = ref worksheet;
      string str14 = "C1";
      ref string local29 = ref str14;
      object obj13 = (object) "Q2";
      ref object local30 = ref obj13;
      this.SetCellValue(ref local28, ref local29, ref local30);
      ref Worksheet local31 = ref worksheet;
      string str15 = "C2";
      ref string local32 = ref str15;
      object obj14 = (object) 2;
      ref object local33 = ref obj14;
      this.SetCellValue(ref local31, ref local32, ref local33);
      ref Worksheet local34 = ref worksheet;
      string str16 = "C3";
      ref string local35 = ref str16;
      object obj15 = (object) 1.75;
      ref object local36 = ref obj15;
      this.SetCellValue(ref local34, ref local35, ref local36);
      ref Worksheet local37 = ref worksheet;
      string str17 = "C4";
      ref string local38 = ref str17;
      object obj16 = (object) 2;
      ref object local39 = ref obj16;
      this.SetCellValue(ref local37, ref local38, ref local39);
      ref Worksheet local40 = ref worksheet;
      string str18 = "C5";
      ref string local41 = ref str18;
      object obj17 = (object) 2.5;
      ref object local42 = ref obj17;
      this.SetCellValue(ref local40, ref local41, ref local42);
      ref Worksheet local43 = ref worksheet;
      string str19 = "D1";
      ref string local44 = ref str19;
      object obj18 = (object) "Q3";
      ref object local45 = ref obj18;
      this.SetCellValue(ref local43, ref local44, ref local45);
      ref Worksheet local46 = ref worksheet;
      string str20 = "D2";
      ref string local47 = ref str20;
      object obj19 = (object) 1.5;
      ref object local48 = ref obj19;
      this.SetCellValue(ref local46, ref local47, ref local48);
      ref Worksheet local49 = ref worksheet;
      string str21 = "D3";
      ref string local50 = ref str21;
      object obj20 = (object) 2;
      ref object local51 = ref obj20;
      this.SetCellValue(ref local49, ref local50, ref local51);
      ref Worksheet local52 = ref worksheet;
      string str22 = "D4";
      ref string local53 = ref str22;
      object obj21 = (object) 2.5;
      ref object local54 = ref obj21;
      this.SetCellValue(ref local52, ref local53, ref local54);
      ref Worksheet local55 = ref worksheet;
      string str23 = "D5";
      ref string local56 = ref str23;
      object obj22 = (object) 2;
      ref object local57 = ref obj22;
      this.SetCellValue(ref local55, ref local56, ref local57);
      ref Worksheet local58 = ref worksheet;
      string str24 = "E1";
      ref string local59 = ref str24;
      object obj23 = (object) "Q4";
      ref object local60 = ref obj23;
      this.SetCellValue(ref local58, ref local59, ref local60);
      ref Worksheet local61 = ref worksheet;
      string str25 = "E2";
      ref string local62 = ref str25;
      object obj24 = (object) 2.5;
      ref object local63 = ref obj24;
      this.SetCellValue(ref local61, ref local62, ref local63);
      ref Worksheet local64 = ref worksheet;
      string str26 = "E3";
      ref string local65 = ref str26;
      object obj25 = (object) 2;
      ref object local66 = ref obj25;
      this.SetCellValue(ref local64, ref local65, ref local66);
      ref Worksheet local67 = ref worksheet;
      string str27 = "E4";
      ref string local68 = ref str27;
      object obj26 = (object) 2;
      ref object local69 = ref obj26;
      this.SetCellValue(ref local67, ref local68, ref local69);
      ref Worksheet local70 = ref worksheet;
      string str28 = "E5";
      ref string local71 = ref str28;
      object obj27 = (object) 2.75;
      ref object local72 = ref obj27;
      this.SetCellValue(ref local70, ref local71, ref local72);
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      Microsoft.Office.Interop.Excel.Range range = worksheet.get_Range((object) "A1", (object) "E5");
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      ChartObjects chartObjects = (ChartObjects) worksheet.ChartObjects(RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      ChartObject chartObject = chartObjects.Add(0.0, 100.0, 300.0, 300.0);
      // ISSUE: reference to a compiler-generated method
      chartObject.Chart.ChartWizard((object) range, (object) XlChartType.xlLine, RuntimeHelpers.GetObjectValue(obj1), (object) XlRowCol.xlRows, RuntimeHelpers.GetObjectValue(obj2), RuntimeHelpers.GetObjectValue(obj3), (object) flag, (object) str2, (object) str3, (object) str4, RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      workbook.SaveAs((object) str1, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), XlSaveAsAccessMode.xlNoChange, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      workbook?.Close((object) false, RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue((object) Missing.Value));
      // ISSUE: reference to a compiler-generated method
      instance?.Quit();
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    public void SetCellValue(ref Worksheet targetSheet, ref string Cell, ref object Value)
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      targetSheet.get_Range((object) Cell, RuntimeHelpers.GetObjectValue((object) Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue((object) Missing.Value), RuntimeHelpers.GetObjectValue(Value));
    }

    public void SetCellValueNoRange(ref Worksheet targetSheet, ref string Cell, ref object Value)
    {
      NewLateBinding.LateSetComplex(targetSheet.Cells[(object) Cell, RuntimeHelpers.GetObjectValue((object) Missing.Value)], (System.Type) null, nameof (Value), new object[1]
      {
        Value
      }, (string[]) null, (System.Type[]) null, false, true);
    }

    public string GetCellRef(ref string ColumnNumber, ref int RowNumber)
    {
      string Left = ColumnNumber;
      string str;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "1", false) == 0)
        str = "A";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "2", false) == 0)
        str = "B";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "3", false) == 0)
        str = "C";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "4", false) == 0)
        str = "D";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "5", false) == 0)
        str = "E";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "6", false) == 0)
        str = "F";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "7", false) == 0)
        str = "G";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "8", false) == 0)
        str = "H";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "9", false) == 0)
        str = "I";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "10", false) == 0)
        str = "J";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "11", false) == 0)
        str = "K";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "12", false) == 0)
        str = "L";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "13", false) == 0)
        str = "M";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "14", false) == 0)
        str = "N";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "15", false) == 0)
        str = "O";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "16", false) == 0)
        str = "P";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "17", false) == 0)
        str = "Q";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "18", false) == 0)
        str = "R";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "19", false) == 0)
        str = "S";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "20", false) == 0)
        str = "T";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "21", false) == 0)
        str = "U";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "22", false) == 0)
        str = "V";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "23", false) == 0)
        str = "W";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "24", false) == 0)
        str = "X";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "25", false) == 0)
        str = "Y";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "26", false) == 0)
        str = "Z";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "27", false) == 0)
        str = "AA";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "28", false) == 0)
        str = "AB";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "29", false) == 0)
        str = "AC";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "30", false) == 0)
        str = "AD";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "31", false) == 0)
        str = "AE";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "32", false) == 0)
        str = "AF";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "33", false) == 0)
        str = "AG";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "34", false) == 0)
        str = "AH";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "35", false) == 0)
        str = "AI";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "36", false) == 0)
        str = "AJ";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "37", false) == 0)
        str = "AK";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "38", false) == 0)
        str = "AL";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "39", false) == 0)
        str = "AM";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "40", false) == 0)
        str = "AN";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "41", false) == 0)
        str = "AO";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "42", false) == 0)
        str = "AP";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "43", false) == 0)
        str = "AQ";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "44", false) == 0)
        str = "AR";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "45", false) == 0)
        str = "AS";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "46", false) == 0)
        str = "AT";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "47", false) == 0)
        str = "AU";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "48", false) == 0)
        str = "AV";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "49", false) == 0)
        str = "AW";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "50", false) == 0)
        str = "AX";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "51", false) == 0)
        str = "AY";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "52", false) == 0)
        str = "AZ";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "53", false) == 0)
        str = "BA";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "54", false) == 0)
        str = "BB";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "55", false) == 0)
        str = "BC";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "56", false) == 0)
        str = "BD";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "57", false) == 0)
        str = "BE";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "58", false) == 0)
        str = "BF";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "59", false) == 0)
        str = "BG";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "60", false) == 0)
        str = "BH";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "61", false) == 0)
        str = "BI";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "62", false) == 0)
        str = "BJ";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "63", false) == 0)
        str = "BK";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "64", false) == 0)
        str = "BL";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "65", false) == 0)
        str = "BM";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "66", false) == 0)
        str = "BN";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "67", false) == 0)
        str = "BO";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "68", false) == 0)
        str = "BP";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "69", false) == 0)
        str = "BQ";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "70", false) == 0)
        str = "BR";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "71", false) == 0)
        str = "BS";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "72", false) == 0)
        str = "BT";
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(Conversions.ToDouble(ColumnNumber) > 75.0), false) == 0)
        str = "BU";
      return str + Conversions.ToString(RowNumber);
    }
  }
}
