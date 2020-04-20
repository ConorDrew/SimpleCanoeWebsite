using System;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM.Importer
{
    public class Validator
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private ArrayList _DataToValidate;
        private ArrayList _arrayList;
        private FRMPartsImport _fRMImportNew;

        public Validator(ArrayList arrayList, FRMPartsImport fRMImportNew)
        {
            // TODO: Complete member initialization
            _arrayList = arrayList;
            _fRMImportNew = fRMImportNew;
        }

        public ArrayList DataToValidate
        {
            get
            {
                return _DataToValidate;
            }

            set
            {
                _DataToValidate = value;
            }
        }

        private ArrayList _Errors;

        public ArrayList Errors
        {
            get
            {
                return _Errors;
            }

            set
            {
                _Errors = value;
            }
        }

        private FRMImport _ImportForm;

        public FRMImport ImportForm
        {
            get
            {
                return _ImportForm;
            }

            set
            {
                _ImportForm = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Validator(ArrayList DataToValidateIn, ref FRMImport ImportFormIn)
        {
            DataToValidate = DataToValidateIn;
            Errors = new ArrayList();
            ImportForm = ImportFormIn;
            ImportForm.MoveProgressOn();
        }

        public ArrayList Validate(int SupplierID)
        {
            ArrayList returnArr = null;
            ResetCells();
            for (int dvIndex = 0, loopTo = DataToValidate.Count - 1; dvIndex <= loopTo; dvIndex++)
            {
                DataView dv = (DataView)DataToValidate[dvIndex];
                if (dvIndex == 0 & (dv.Table.TableName ?? "") == "Parts")
                {

                    // Check Columns
                    var ExpectedColumns = new string[] { "Part Code", "Name/Description", "Category", "Notes", "Sell Price", "Supplier Part Code", "Supplier Qty", "Supplier Price" };
                    for (int ExpectedColumnIndex = 0, loopTo1 = ExpectedColumns.Length - 1; ExpectedColumnIndex <= loopTo1; ExpectedColumnIndex++)
                    {
                        string ExpectedColumn = ExpectedColumns[ExpectedColumnIndex];
                        if (!((dv.Table.Columns[ExpectedColumnIndex].ColumnName ?? "") == (ExpectedColumn ?? "")))
                        {
                            Errors.Add(string.Format("{0} Column is Missing at position {1}", ExpectedColumn, ExpectedColumnIndex));
                        }
                    }

                    if (Errors.Count == 0)
                    {
                        // Check Data
                        returnArr = ValidateParts(dv, SupplierID);
                    }
                }
                else if (dvIndex == 0 & (dv.Table.TableName ?? "") == "Sites")
                {

                    // Check Data
                    returnArr = ValidateSites(dv);
                }
                else
                {
                    Errors.Add("The first worksheet must be titled \"Parts\"" + "Or \"Sites\"");
                }

                ImportForm.MoveProgressOn();
            }

            return returnArr;
        }

        public void ResetCells()
        {
            // For Each tp As TabPage In ImportForm.tcData.TabPages
            // For Each row As DataRow In CType(tp.Controls(0), UCData).Data.Table.Rows
            // For Each col As DataColumn In CType(tp.Controls(0), UCData).Data.Table.Columns
            // If col.ColumnName.EndsWith("COLOURBOOLEANCOLUMN") Then
            // row.Item(col.ColumnName) = False
            // End If
            // Next
            // Next
            // Next
        }

        public void ErrorInCell(int SheetNumber, int RowNumber, string ColumnName, string Message)
        {
            // CType(ImportForm.tcData.TabPages(SheetNumber).Controls(0), UCData).Data.Table.Rows(RowNumber).Item(ColumnName & "COLOURBOOLEANCOLUMN") = True

            Errors.Add(string.Format("Error in {0} at row {1}: {2} - {3}", ((DataView)DataToValidate[SheetNumber]).Table.TableName, RowNumber + 1, ColumnName, Message));
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private ArrayList ValidateParts(DataView dvParts, int SupplierID)
        {
            int insertCount = 0;
            int updateCount = 0;
            try
            {
                for (int partIndex = 0, loopTo = dvParts.Count - 1; partIndex <= loopTo; partIndex++)
                {
                    var part = dvParts[partIndex];

                    // ImportForm.SetLastPartAttempted(part("Part Code"))

                    // Part Code
                    if (Information.IsDBNull(part["Part Code"]) || Conversions.ToString(part["Part Code"]).Length <= 0)
                    {
                        ErrorInCell(0, partIndex, "Part Code (MPN)", "Required field");
                    }
                    else
                    {
                        int partsFound = App.DB.Part.Part_Exists(Conversions.ToString(part["Part Code"]), Conversions.ToString(part["Supplier Part Code"]));
                        if (partsFound == 0)
                        {
                            insertCount += 1;

                            // Name/Description
                            if (Information.IsDBNull(part["Name/Description"]) || Conversions.ToString(part["Name/Description"]).Length <= 0)
                            {
                                ErrorInCell(0, partIndex, "Name/Description", "Required field for an insert");
                            }

                            // Category
                            if (Information.IsDBNull(part["Category"]) || Conversions.ToString(part["Category"]).Length <= 0)
                            {
                                ErrorInCell(0, partIndex, "Category", "Required field for an insert");
                            }
                            else if (App.DB.ImportValidation.CategoryExists(Conversions.ToString(part["Category"])) == false)
                            {
                                ErrorInCell(0, partIndex, "Category", Conversions.ToString("'" + part["Category"] + "' does not exist"));
                            }

                            if (!Information.IsDBNull(part["Sell Price"]))
                            {
                                if (!(part["Sell Price"].GetType() == typeof(decimal)))
                                {
                                    ErrorInCell(0, partIndex, "Sell Price", "Required Decimal field for an insert - e.g 1.23");
                                }
                            }

                            // part code (S1)
                            if (Information.IsDBNull(part["Supplier Part Code"]) || Conversions.ToString(part["Supplier Part Code"]).Length <= 0)
                            {
                                ErrorInCell(0, partIndex, "Supplier Part Code (SPN)", "Required for an insert");
                            }

                            // qty (S1)
                            if (Information.IsDBNull(part["Supplier Qty"]) || !(part["Supplier Qty"].GetType() == typeof(double)))
                            {
                                ErrorInCell(0, partIndex, "Supplier Qty", "Required Double field for an insert - e.g 1.23");
                            }

                            // Price (S1)
                            if (Information.IsDBNull(part["Supplier Price"]) || !(part["Supplier Price"].GetType() == typeof(decimal)))
                            {
                                ErrorInCell(0, partIndex, "Supplier Price", "Reqired Decimal field for an insert - e.g £1.23");
                            }
                        }
                        else
                        {
                            updateCount += 1;
                            int partID = partsFound;

                            // Category
                            if (!Information.IsDBNull(part["Category"]) && Conversions.ToString(part["Category"]).Length > 0)
                            {
                                if (App.DB.ImportValidation.CategoryExists(Conversions.ToString(part["Category"])) == false)
                                {
                                    ErrorInCell(0, partIndex, "Category", Conversions.ToString("'" + part["Category"] + "' does not exist"));
                                }
                            }

                            if (!Information.IsDBNull(part["Sell Price"]))
                            {
                                if (!(part["Sell Price"].GetType() == typeof(decimal)))
                                {
                                    ErrorInCell(0, partIndex, "Sell Price", "Required Decimal field for an update - e.g 1.23");
                                }
                            }

                            Array suppliersFound = App.DB.PartSupplier.Get_ByPartID(partID).Table.Select("SupplierID = " + SupplierID);
                            if (suppliersFound.Length == 0)
                            {
                                // part code (S1)
                                if (Information.IsDBNull(part["Supplier Part Code"]) || Conversions.ToString(part["Supplier Part Code"]).Length <= 0)
                                {
                                    ErrorInCell(0, partIndex, "Supplier Part Code (SPN)", "Required field for an update when new part supplier");
                                }

                                // qty (S1)
                                if (Information.IsDBNull(part["Supplier Qty"]) || !(part["Supplier Qty"].GetType() == typeof(double)))
                                {
                                    ErrorInCell(0, partIndex, "Supplier Qty", "Required Double field for an update when new part supplier - e.g 1.23");
                                }

                                // Price (S1)
                                if (Information.IsDBNull(part["Supplier Price"]) || !(part["Supplier Price"].GetType() == typeof(decimal)))
                                {
                                    ErrorInCell(0, partIndex, "Supplier Price", "Reqired Decimal field for an update when new part supplier - e.g £1.23");
                                }
                            }
                            else
                            {
                                // qty (S1)
                                if (!Information.IsDBNull(part["Supplier Qty"]))
                                {
                                    if (!(part["Supplier Qty"].GetType() == typeof(double)))
                                    {
                                        ErrorInCell(0, partIndex, "Supplier Qty", "Required Double field for an update when updating part supplier - e.g 1.23");
                                    }
                                }

                                // Price (S1)
                                if (!Information.IsDBNull(part["Supplier Price"]))
                                {
                                    if (!(part["Supplier Price"].GetType() == typeof(decimal)))
                                    {
                                        ErrorInCell(0, partIndex, "Supplier Price", "Reqired Decimal field for an update when updating part supplier - e.g £1.23");
                                    }
                                }
                            }
                        }
                    }

                    ImportForm.MoveProgressOn();
                }

                var returnArr = new ArrayList();
                returnArr.Add(insertCount);
                returnArr.Add(updateCount);
                return returnArr;
            }
            catch (Exception ex)
            {
                Errors.Add("Error occured while validating" + Constants.vbCrLf + ex.Message);
                return null;
            }
        }

        private ArrayList ValidateSites(DataView dvSites)
        {
            int cnt = 0;
            try
            {
                for (int siteIndex = 0, loopTo = dvSites.Count - 1; siteIndex <= loopTo; siteIndex++)
                {
                    var site = dvSites[siteIndex];

                    // URPN
                    if (Information.IsDBNull(site["PolicyNumber"]) || Conversions.ToString(site["PolicyNumber"]).Length <= 0)
                    {
                        ErrorInCell(0, siteIndex, "URPN", "Required field");
                    }
                    else if (Entity.Sys.Helper.MakeStringValid(site["Address1"]).Trim().Length == 0)
                    {
                        ErrorInCell(0, siteIndex, "Address1", "Required field for an insert");
                        // If Entity.Sys.Helper.MakeStringValid(site("Postcode")).Trim.Length = 0 Then
                        // ErrorInCell(0, siteIndex, "Postcode", "Required field for an insert")
                        // End If

                    }

                    cnt += 1;
                    ImportForm.MoveProgressOn();
                }

                var returnArr = new ArrayList();
                returnArr.Add(cnt);
                return returnArr;
            }
            catch (Exception ex)
            {
                Errors.Add("Error occured while validating" + Constants.vbCrLf + ex.Message);
                return null;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}