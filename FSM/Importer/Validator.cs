// Decompiled with JetBrains decompiler
// Type: FSM.Importer.Validator
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace FSM.Importer
{
  public class Validator
  {
    private ArrayList _DataToValidate;
    private ArrayList _arrayList;
    private FRMPartsImport _fRMImportNew;
    private ArrayList _Errors;
    private FRMImport _ImportForm;

    public Validator(ArrayList arrayList, FRMPartsImport fRMImportNew)
    {
      this._arrayList = arrayList;
      this._fRMImportNew = fRMImportNew;
    }

    public ArrayList DataToValidate
    {
      get
      {
        return this._DataToValidate;
      }
      set
      {
        this._DataToValidate = value;
      }
    }

    public ArrayList Errors
    {
      get
      {
        return this._Errors;
      }
      set
      {
        this._Errors = value;
      }
    }

    public FRMImport ImportForm
    {
      get
      {
        return this._ImportForm;
      }
      set
      {
        this._ImportForm = value;
      }
    }

    public Validator(ArrayList DataToValidateIn, ref FRMImport ImportFormIn)
    {
      this.DataToValidate = DataToValidateIn;
      this.Errors = new ArrayList();
      this.ImportForm = ImportFormIn;
      this.ImportForm.MoveProgressOn(false);
    }

    public ArrayList Validate(int SupplierID)
    {
      ArrayList arrayList = (ArrayList) null;
      this.ResetCells();
      int num1 = checked (this.DataToValidate.Count - 1);
      int index1 = 0;
      while (index1 <= num1)
      {
        DataView dataView = (DataView) this.DataToValidate[index1];
        if (index1 == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.TableName, "Parts", false) == 0)
        {
          string[] strArray = new string[8]
          {
            "Part Code",
            "Name/Description",
            "Category",
            "Notes",
            "Sell Price",
            "Supplier Part Code",
            "Supplier Qty",
            "Supplier Price"
          };
          int num2 = checked (strArray.Length - 1);
          int index2 = 0;
          while (index2 <= num2)
          {
            string Right = strArray[index2];
            if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.Columns[index2].ColumnName, Right, false) > 0U)
              this.Errors.Add((object) string.Format("{0} Column is Missing at position {1}", (object) Right, (object) index2));
            checked { ++index2; }
          }
          if (this.Errors.Count == 0)
            arrayList = this.ValidateParts(dataView, SupplierID);
        }
        else if (index1 == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataView.Table.TableName, "Sites", false) == 0)
          arrayList = this.ValidateSites(dataView);
        else
          this.Errors.Add((object) "The first worksheet must be titled \"Parts\"Or \"Sites\"");
        this.ImportForm.MoveProgressOn(false);
        checked { ++index1; }
      }
      return arrayList;
    }

    public void ResetCells()
    {
    }

    public void ErrorInCell(int SheetNumber, int RowNumber, string ColumnName, string Message)
    {
      this.Errors.Add((object) string.Format("Error in {0} at row {1}: {2} - {3}", (object) ((DataView) this.DataToValidate[SheetNumber]).Table.TableName, (object) checked (RowNumber + 1), (object) ColumnName, (object) Message));
    }

    private ArrayList ValidateParts(DataView dvParts, int SupplierID)
    {
      int num1 = 0;
      int num2 = 0;
      ArrayList arrayList;
      try
      {
        int num3 = checked (dvParts.Count - 1);
        int RowNumber = 0;
        while (RowNumber <= num3)
        {
          DataRowView dvPart = dvParts[RowNumber];
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Part Code"])) || Conversions.ToString(dvPart["Part Code"]).Length <= 0)
          {
            this.ErrorInCell(0, RowNumber, "Part Code (MPN)", "Required field");
          }
          else
          {
            int num4 = App.DB.Part.Part_Exists(Conversions.ToString(dvPart["Part Code"]), Conversions.ToString(dvPart["Supplier Part Code"]), (SqlTransaction) null);
            if (num4 == 0)
            {
              checked { ++num1; }
              if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Name/Description"])) || Conversions.ToString(dvPart["Name/Description"]).Length <= 0)
                this.ErrorInCell(0, RowNumber, "Name/Description", "Required field for an insert");
              if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Category"])) || Conversions.ToString(dvPart["Category"]).Length <= 0)
                this.ErrorInCell(0, RowNumber, "Category", "Required field for an insert");
              else if (!App.DB.ImportValidation.CategoryExists(Conversions.ToString(dvPart["Category"])))
                this.ErrorInCell(0, RowNumber, "Category", Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "'", dvPart["Category"]), (object) "' does not exist")));
              if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Sell Price"])) && (object) dvPart["Sell Price"].GetType() != (object) typeof (Decimal))
                this.ErrorInCell(0, RowNumber, "Sell Price", "Required Decimal field for an insert - e.g 1.23");
              if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Part Code"])) || Conversions.ToString(dvPart["Supplier Part Code"]).Length <= 0)
                this.ErrorInCell(0, RowNumber, "Supplier Part Code (SPN)", "Required for an insert");
              if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Qty"])) || (object) dvPart["Supplier Qty"].GetType() != (object) typeof (double))
                this.ErrorInCell(0, RowNumber, "Supplier Qty", "Required Double field for an insert - e.g 1.23");
              if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Price"])) || (object) dvPart["Supplier Price"].GetType() != (object) typeof (Decimal))
                this.ErrorInCell(0, RowNumber, "Supplier Price", "Reqired Decimal field for an insert - e.g £1.23");
            }
            else
            {
              checked { ++num2; }
              int PartID = num4;
              if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Category"])) && Conversions.ToString(dvPart["Category"]).Length > 0 && !App.DB.ImportValidation.CategoryExists(Conversions.ToString(dvPart["Category"])))
                this.ErrorInCell(0, RowNumber, "Category", Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "'", dvPart["Category"]), (object) "' does not exist")));
              if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Sell Price"])) && (object) dvPart["Sell Price"].GetType() != (object) typeof (Decimal))
                this.ErrorInCell(0, RowNumber, "Sell Price", "Required Decimal field for an update - e.g 1.23");
              if (App.DB.PartSupplier.Get_ByPartID(PartID).Table.Select("SupplierID = " + Conversions.ToString(SupplierID)).Length == 0)
              {
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Part Code"])) || Conversions.ToString(dvPart["Supplier Part Code"]).Length <= 0)
                  this.ErrorInCell(0, RowNumber, "Supplier Part Code (SPN)", "Required field for an update when new part supplier");
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Qty"])) || (object) dvPart["Supplier Qty"].GetType() != (object) typeof (double))
                  this.ErrorInCell(0, RowNumber, "Supplier Qty", "Required Double field for an update when new part supplier - e.g 1.23");
                if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Price"])) || (object) dvPart["Supplier Price"].GetType() != (object) typeof (Decimal))
                  this.ErrorInCell(0, RowNumber, "Supplier Price", "Reqired Decimal field for an update when new part supplier - e.g £1.23");
              }
              else
              {
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Qty"])) && (object) dvPart["Supplier Qty"].GetType() != (object) typeof (double))
                  this.ErrorInCell(0, RowNumber, "Supplier Qty", "Required Double field for an update when updating part supplier - e.g 1.23");
                if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvPart["Supplier Price"])) && (object) dvPart["Supplier Price"].GetType() != (object) typeof (Decimal))
                  this.ErrorInCell(0, RowNumber, "Supplier Price", "Reqired Decimal field for an update when updating part supplier - e.g £1.23");
              }
            }
          }
          this.ImportForm.MoveProgressOn(false);
          checked { ++RowNumber; }
        }
        arrayList = new ArrayList()
        {
          (object) num1,
          (object) num2
        };
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Errors.Add((object) ("Error occured while validating\r\n" + ex.Message));
        arrayList = (ArrayList) null;
        ProjectData.ClearProjectError();
      }
      return arrayList;
    }

    private ArrayList ValidateSites(DataView dvSites)
    {
      int num1 = 0;
      ArrayList arrayList;
      try
      {
        int num2 = checked (dvSites.Count - 1);
        int RowNumber = 0;
        while (RowNumber <= num2)
        {
          DataRowView dvSite = dvSites[RowNumber];
          if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dvSite["PolicyNumber"])) || Conversions.ToString(dvSite["PolicyNumber"]).Length <= 0)
            this.ErrorInCell(0, RowNumber, "URPN", "Required field");
          else if (Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dvSite["Address1"])).Trim().Length == 0)
            this.ErrorInCell(0, RowNumber, "Address1", "Required field for an insert");
          checked { ++num1; }
          this.ImportForm.MoveProgressOn(false);
          checked { ++RowNumber; }
        }
        arrayList = new ArrayList() { (object) num1 };
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        this.Errors.Add((object) ("Error occured while validating\r\n" + ex.Message));
        arrayList = (ArrayList) null;
        ProjectData.ClearProjectError();
      }
      return arrayList;
    }
  }
}
