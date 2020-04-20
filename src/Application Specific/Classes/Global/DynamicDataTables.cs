using System;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class DynamicDataTables
    {
        public static DataTable Setup_Search_On_Options(Entity.Sys.Enums.MenuTypes MenuType, Entity.Sys.Enums.TableNames tableName)
        {
            var dt = new DataTable();
            dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchOn.ToString();
            dt.Columns.Add(new DataColumn("ValueMember"));
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("Deleted", Type.GetType("System.Boolean")));
            DataRow newRow;
            switch (MenuType)
            {
                case Entity.Sys.Enums.MenuTypes.Spares:
                    {
                        switch (tableName)
                        {
                            case Entity.Sys.Enums.TableNames.tblSupplier:
                                {
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "";
                                    newRow["DisplayMember"] = "All";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "Name";
                                    newRow["DisplayMember"] = "Name";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "AccountNumber";
                                    newRow["DisplayMember"] = "Account Number";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "Address1";
                                    newRow["DisplayMember"] = "Address1";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tblSupplier.Postcode";
                                    newRow["DisplayMember"] = "Postcode";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    break;
                                }

                            case Entity.Sys.Enums.TableNames.tblPart:
                                {
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "";
                                    newRow["DisplayMember"] = "All";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tp.Name";
                                    newRow["DisplayMember"] = "Name";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "Category.Name";
                                    newRow["DisplayMember"] = "Category";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tp.Number";
                                    newRow["DisplayMember"] = "Number";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tp.Reference";
                                    newRow["DisplayMember"] = "Reference";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    break;
                                }

                            case Entity.Sys.Enums.TableNames.tblProduct:
                                {
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "";
                                    newRow["DisplayMember"] = "All";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tblProduct.Reference";
                                    newRow["DisplayMember"] = "Reference";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tblProduct.Number";
                                    newRow["DisplayMember"] = "GC Number";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "type.[Name]";
                                    newRow["DisplayMember"] = "Type";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "make.[Name]";
                                    newRow["DisplayMember"] = "Make";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "model.[Name]";
                                    newRow["DisplayMember"] = "Model";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tblSupplier.name";
                                    newRow["DisplayMember"] = "Supplier";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    break;
                                }

                            case Entity.Sys.Enums.TableNames.tblWarehouse:
                                {
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "";
                                    newRow["DisplayMember"] = "All";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tblWarehouse.Name";
                                    newRow["DisplayMember"] = "Name";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tblWarehouse.Address1";
                                    newRow["DisplayMember"] = "Address1";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    newRow = dt.NewRow();
                                    newRow["ValueMember"] = "tblWarehouse.Postcode";
                                    newRow["DisplayMember"] = "Postcode";
                                    newRow["Deleted"] = false;
                                    dt.Rows.Add(newRow);
                                    break;
                                }
                        }

                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            return dt;
        }

        public static DataTable Setup_Advanced_Search_Options(Entity.Sys.Enums.MenuTypes MenuType)
        {
            var dt = new DataTable();
            dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchFor.ToString();
            dt.Columns.Add(new DataColumn("ValueMember"));
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("Deleted", Type.GetType("System.Boolean")));
            DataRow newRow;
            switch (MenuType)
            {
                case Entity.Sys.Enums.MenuTypes.Spares:
                    {
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblPart);
                        newRow["DisplayMember"] = "Part";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblProduct);
                        newRow["DisplayMember"] = "Product";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        break;
                    }
            }

            return dt;
        }

        public static DataTable Setup_Search_Options(Entity.Sys.Enums.MenuTypes MenuType)
        {
            var dt = new DataTable();
            dt.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_TBLSearchFor.ToString();
            dt.Columns.Add(new DataColumn("ValueMember"));
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("Deleted", Type.GetType("System.Boolean")));
            DataRow newRow;
            switch (MenuType)
            {
                case Entity.Sys.Enums.MenuTypes.Customers:
                    {
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblCustomer);
                        newRow["DisplayMember"] = "Customer";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblSite);
                        newRow["DisplayMember"] = "Property";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblAsset);
                        newRow["DisplayMember"] = "Appliances";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Spares:
                    {
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblSupplier);
                        newRow["DisplayMember"] = "Supplier";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblProduct);
                        newRow["DisplayMember"] = "Product";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblPart);
                        newRow["DisplayMember"] = "Part";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblWarehouse);
                        newRow["DisplayMember"] = "Warehouse";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Staff:
                    {
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblEngineer);
                        newRow["DisplayMember"] = "Engineer";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblVan);
                        newRow["DisplayMember"] = "Stock Profile";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblSubcontractor);
                        newRow["DisplayMember"] = "Subcontractor";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblUser);
                        newRow["DisplayMember"] = "User";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblEquipment);
                        newRow["DisplayMember"] = "Equipment";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Jobs:
                    {
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblEngineerVisit);
                        newRow["DisplayMember"] = "Visit";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblQuotes);
                        newRow["DisplayMember"] = "Quote";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.FleetVan:
                    {
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblFleetVan);
                        newRow["DisplayMember"] = "Vans";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblFleetVanType);
                        newRow["DisplayMember"] = "Van Type";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblFleetEquipment);
                        newRow["DisplayMember"] = "Equipment";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.TableNames.tblFleetGarage);
                        newRow["DisplayMember"] = "Service Centres";
                        newRow["Deleted"] = false;
                        dt.Rows.Add(newRow);
                        break;
                    }
            }

            return dt;
        }

        public static DataTable Times(int TimeSlot = 15)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("ValueMember"));
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("Deleted"));
            for (int hour = 0; hour <= 23; hour++)
            {
                for (int minute = 0; TimeSlot >= 0 ? minute <= 45 : minute >= 45; minute += TimeSlot)
                {
                    string time = "";
                    if (hour.ToString().Length == 1)
                    {
                        time = time + "0";
                    }

                    time = time + hour.ToString() + ":";
                    if (minute.ToString().Length == 1)
                    {
                        time = time + "0";
                    }

                    time = time + minute.ToString();
                    DataRow row;
                    row = dt.NewRow();
                    row["DisplayMember"] = time;
                    row["ValueMember"] = time;
                    row["Deleted"] = false;
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }

        public static DataTable CustomerStatus
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Entity.Sys.Enums.CustomerStatus.Active, "Active", "0" });
                dt.Rows.Add(new string[] { Entity.Sys.Enums.CustomerStatus.InActive, "InActive", "0" });
                dt.Rows.Add(new string[] { Entity.Sys.Enums.CustomerStatus.OnHold, "On Hold", "0" });
                dt.Rows.Add(new string[] { Entity.Sys.Enums.CustomerStatus.Prospect, "Prospect", "0" });
                return dt;
            }
        }

        public static DataTable PartValidationTypes
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.Unverified), "Unverified", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.CategoryNotFound), "Category Missing", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.MatchNoChange), "Matched - No Change", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.MatchPriceUp), "Matched - Price INCREASE", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.MatchPriceDown), "Matched - Price DECREASE", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.DuplicatesFound), "Duplicate SPN Found", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.MPNDuplicate), "Duplicate MPN Found", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.NewForThisSupplier), "Matched MPN New SPN", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.NewPart), "New Part MPN and SPN", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartValidationResults.MissingExistingForSupplier), "Parts for supplier not in import", "0" });
                return dt;
            }
        }

        public static DataTable PartsInvoiceImportValidationResults
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));

                // dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.Unverified), "Unverified", "0"})
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.Replenishment), "(PII) Replenishment", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.UnableToLocatePO), "(PII) Unable to Locate Purchase Order", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceCorrect), "(PII) Matched Purchase Order - Supplier Invoice Price Correct", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceAbove), "(PII) Matched Purchase Order - Supplier Invoice Price Above", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceBelow), "(PII) Matched Purchase Order - Supplier Invoice Price Below", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncluded), "(PII) Matched Purchase Order - No Parts Included on PO", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPONoPartsIncludedUnableToMatchParts), "(PII) Matched Purchase Order - No Parts, Unable to Match Parts", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOSentToSage), "(PII) Matched Purchase Order - PO Sent To Sage", "0" });
                // dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.AwaitingAuthorisation), "Supplier Invoice Created - Awaiting Authorisation", "0"})
                // dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.PartsInvoiceImportValidationResults.Authorised), "Supplier Invoice Created - Authorised", "0"})
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.SupplierInvoiceCreated), "(PII) Supplier Invoice Created", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.PurchaseCredit), "(PII) Purchase Credits", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.JobIncomplete), "(PII) Job Incomplete", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.SuppliersDoNotMatch), "(PII) Supplier Do Not Match", "0" });
                return dt;
            }
        }

        public static DataTable POInvoiceAuthorisation
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceCorrect), "Matched Purchase Order - Supplier Invoice Price Correct", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceAbove), "Matched Purchase Order - Supplier Invoice Price Above", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsInvoiceImportValidationResults.MatchedPOPriceBelow), "Matched Purchase Order - Supplier Invoice Price Below", "0" });
                return dt;
            }
        }

        public static DataTable ReplenishmentStatusTypes
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReplenishmentStatusResults.AmountBelowMinQuantitiesStockOnOrder), "Below Min Quantities - Quantity On Order To Replenish Stock", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReplenishmentStatusResults.AmountBelowMinQuantitiesStockRequired), "Below Min Quantities - Order Required To Replenish Stock", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReplenishmentStatusResults.NoPreferredSupplierFound), "No Preferred Supplier Found", "0" });
                return dt;
            }
        }

        public static DataTable Yes_No
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { "Yes", "Yes", "0" });
                dt.Rows.Add(new string[] { "No", "No", "0" });
                return dt;
            }
        }

        public static DataTable OrderTypeForSearch
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { "1", "Customer, Property (Select Property from Property list)", "0" });
                dt.Rows.Add(new string[] { "2", "Customer, Warehouse (Select Warehouse from Warehouse locations)", "0" });
                dt.Rows.Add(new string[] { "3", "Stock Profile (Select Profile from Stock list)", "0" });
                dt.Rows.Add(new string[] { "4", "Warehouse (Select Warehouse from Warehouse locations)", "0" });
                dt.Rows.Add(new string[] { "5", "Job (Search for Job to pick Engineer Visit)", "0" });
                return dt;
            }
        }

        public static DataTable OrderType
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { "1", "Customer (Select Delivery Location)", "0" });
                dt.Rows.Add(new string[] { "2", "Stock Profile (Select Profile from Stock list)", "0" });
                dt.Rows.Add(new string[] { "3", "Warehouse (Select Warehouse from Warehouse locations)", "0" });
                dt.Rows.Add(new string[] { "4", "Job (Search for Job to pick Engineer Visit)", "0" });
                return dt;
            }
        }

        public static DataTable LocationType
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { "1", "Supplier", "0" });
                dt.Rows.Add(new string[] { "2", "Stock Profile", "0" });
                dt.Rows.Add(new string[] { "3", "Warehouse", "0" });
                return dt;
            }
        }

        public static DataTable InvoiceFrequency
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency.Weekly), Entity.Sys.Enums.InvoiceFrequency.Weekly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency.Monthly), Entity.Sys.Enums.InvoiceFrequency.Monthly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency.Quarterly), Entity.Sys.Enums.InvoiceFrequency.Quarterly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency.Bi_Annually), Entity.Sys.Enums.InvoiceFrequency.Bi_Annually.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency.Annually), Entity.Sys.Enums.InvoiceFrequency.Annually.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency.Per_Visit), Entity.Sys.Enums.InvoiceFrequency.Per_Visit.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency.AnnuallyDD), "Annual Direct Debit", "0" });
                return dt;
            }
        }

        public static DataTable InvoiceFrequency_NoWeekly
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Per_Visit), Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Per_Visit.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.InvoiceFrequency_NoWeeK.AnnuallyDD), "Annual Direct Debit", "0" });
                return dt;
            }
        }

        public static DataTable VisitFrequencyNoWeekly
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Monthly), Entity.Sys.Enums.VisitFrequency.Monthly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.GBS_4_Month_Visits), Entity.Sys.Enums.VisitFrequency.GBS_4_Month_Visits.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Quarterly), Entity.Sys.Enums.VisitFrequency.Quarterly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Bi_Annually), Entity.Sys.Enums.VisitFrequency.Bi_Annually.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Annually), Entity.Sys.Enums.VisitFrequency.Annually.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Fortnightly), Entity.Sys.Enums.VisitFrequency.Fortnightly.ToString(), "0" });
                return dt;
            }
        }

        public static DataTable ContractVisitType
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractVisitType.Commercial), Entity.Sys.Enums.ContractVisitType.Commercial.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractVisitType.Domestic), Entity.Sys.Enums.ContractVisitType.Domestic.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractVisitType.Electrical), Entity.Sys.Enums.ContractVisitType.Electrical.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractVisitType.SubContractor), Entity.Sys.Enums.ContractVisitType.SubContractor.ToString(), "0" });
                // dt.Rows.Add(New String() {CInt(Entity.Sys.Enums.ContractVisitType.Electrical), Entity.Sys.Enums.ContractVisitType.Electrical.ToString, "0"})

                return dt;
            }
        }

        public static DataTable VisitFrequency
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Weekly), Entity.Sys.Enums.VisitFrequency.Weekly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Monthly), Entity.Sys.Enums.VisitFrequency.Monthly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Quarterly), Entity.Sys.Enums.VisitFrequency.Quarterly.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Bi_Annually), Entity.Sys.Enums.VisitFrequency.Bi_Annually.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitFrequency.Annually), Entity.Sys.Enums.VisitFrequency.Annually.ToString(), "0" });
                return dt;
            }
        }

        public static DataTable ContractStatus
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractStatus.Active), Entity.Sys.Enums.ContractStatus.Active.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractStatus.Inactive), Entity.Sys.Enums.ContractStatus.Inactive.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractStatus.Cancelled), Entity.Sys.Enums.ContractStatus.Cancelled.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractStatus.InactiveUpgrade), "Inactive - Upgraded", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractStatus.InactiveDowngrade), "Inactive - Downgraded", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractStatus.InactiveTransferred), "Inactive - Transferred to new property", "0" });
                return dt;
            }
        }

        public static DataTable ContractPaymentTypes
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractPaymentType.Annual), Entity.Sys.Enums.ContractPaymentType.Annual.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractPaymentType.Direct_Debit), Entity.Sys.Enums.ContractPaymentType.Direct_Debit.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractPaymentType.AnnualDirectDebit), "Annual Direct Debit", "0" });
                return dt;
            }
        }

        public static DataTable ContractInitialPaymentTypes
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractInitialPaymentType.DebitCard), "Debit Card", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractInitialPaymentType.CreditCard), "Credit Card", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractInitialPaymentType.Cash), "Cash", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractInitialPaymentType.Cheque), "Cheque", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractInitialPaymentType.Invoice), "Invoice", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractInitialPaymentType.BACS), "BACS", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractInitialPaymentType.FOC), "FOC", "0" });
                return dt;
            }
        }

        public static DataTable Appointments
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(1), "AM", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(2), "PM", "0" });
                return dt;
            }
        }

        public static DataTable ManualApp
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(1), "Boiler", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(2), "Gas Fire", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(3), "Cooker", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(4), "Unvented Cylinder", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(5), "Thermal Store Cylinder", "0" });
                return dt;
            }
        }

        public static DataTable ContractPeriod
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { 1, "1 Year", "0" });
                dt.Rows.Add(new string[] { 2, "2 Years", "0" });
                dt.Rows.Add(new string[] { 3, "3 Years", "0" });
                dt.Rows.Add(new string[] { 4, "4 Years", "0" });
                dt.Rows.Add(new string[] { 5, "5 Years", "0" });
                dt.Rows.Add(new string[] { 6, "6 Years", "0" });
                dt.Rows.Add(new string[] { 7, "7 Years", "0" });
                dt.Rows.Add(new string[] { 8, "8 Years", "0" });
                dt.Rows.Add(new string[] { 9, "9 Years", "0" });
                dt.Rows.Add(new string[] { 10, "10 Years", "0" });
                dt.Rows.Add(new string[] { 11, "11 Years", "0" });
                dt.Rows.Add(new string[] { 12, "12 Years", "0" });
                return dt;
            }
        }

        public static DataTable ContractTypes2
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { 367, "Silver Star", "0" });
                dt.Rows.Add(new string[] { 368, "Gold Star", "0" });
                dt.Rows.Add(new string[] { 369, "Platinum Star", "0" });
                dt.Rows.Add(new string[] { 68032, "Platinum Immediate", "0" });
                dt.Rows.Add(new string[] { 68294, "Totally Assured", "0" });
                dt.Rows.Add(new string[] { 69420, "Preventative Maintenance Contract", "0" });
                return dt;
            }
        }

        public static DataTable ReadingType
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { 0, "Gas", "0" });
                dt.Rows.Add(new string[] { 1, "Oil", "0" });
                dt.Rows.Add(new string[] { 2, "Solid Fuel", "0" });
                dt.Rows.Add(new string[] { 3, "Unvented", "0" });
                dt.Rows.Add(new string[] { 4, "Solar", "0" });
                dt.Rows.Add(new string[] { 5, "ASHP", "0" });
                dt.Rows.Add(new string[] { 6, "GSHP", "0" });
                dt.Rows.Add(new string[] { 7, "Other", "0" });
                dt.Rows.Add(new string[] { 8, "Comercial Catering", "0" });
                dt.Rows.Add(new string[] { 9, "HIU", "0" });
                return dt;
            }
        }

        public static DataTable TankType
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { 1, "Plastic", "0" });
                dt.Rows.Add(new string[] { 2, "Bunded", "0" });
                dt.Rows.Add(new string[] { 3, "Metal", "0" });
                return dt;
            }
        }

        public static DataTable ContractRenewal
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractRenewal.Renewed), Entity.Sys.Enums.ContractRenewal.Renewed.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ContractRenewal.NotRenewed), "Not Renewed", "0" });
                return dt;
            }
        }

        public static DataTable Quote_ElectricianPack
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { "1", "Pack A", "0" });
                dt.Rows.Add(new string[] { "2", "Pack B", "0" });
                dt.Rows.Add(new string[] { "3", "Pack C", "0" });
                return dt;
            }
        }

        public static DataTable QuoteContractStatus
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated), Entity.Sys.Enums.QuoteContractStatus.Generated.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Accepted), Entity.Sys.Enums.QuoteContractStatus.Accepted.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Rejected), Entity.Sys.Enums.QuoteContractStatus.Rejected.ToString(), "0" });
                return dt;
            }
        }

        public static DataTable VisitStatus_For_Selection
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Parts_Need_Ordering), "Quote/Action Required", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts), "Waiting For Parts", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Parts_Despatched), "Parts Despatched", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule), "Ready For Schedule", "0" });
                return dt;
            }
        }

        public static DataTable VisitStatus_For_Viewing
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Parts_Need_Ordering), "Quote/Action Required", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts), "Waiting For Parts", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Parts_Despatched), "Parts Despatched", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_For_Schedule), "Ready For Schedule", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled), "Scheduled", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Downloaded), "Downloaded", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Uploaded), "Uploaded", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Not_To_Be_Invoiced), "Non Chargable", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Ready_To_Be_Invoiced), "Ready To Be Invoiced", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Invoiced), "Invoiced", "0" });
                return dt;
            }
        }

        public static DataTable JobStatuses
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobStatus.Open), "Open", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobStatus.Complete), "Complete", "0" });
                return dt;
            }
        }

        public static DataTable QuoteStatuses
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Generated), "Generated", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Accepted), "Accepted", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.QuoteContractStatus.Rejected), "Rejected", "0" });
                return dt;
            }
        }

        public static DataTable JobDefinitions
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobDefinition.Callout), "Callout", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobDefinition.Contract), "Contract", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobDefinition.Quoted), "Quoted", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobDefinition.Misc), "Misc", "0" });
                return dt;
            }
        }

        public static DataTable VisitDuration
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("VisitDuration"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                var settings = App.DB.Manager.Get();
                var sd = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, Conversions.ToInteger(settings.WorkingHoursStart.Trim().Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursStart.Trim().Substring(3, 2)), 0);
                var ed = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, Conversions.ToInteger(settings.WorkingHoursEnd.Trim().Substring(0, 2)), Conversions.ToInteger(settings.WorkingHoursEnd.Trim().Substring(3, 2)), 0);
                int minutesAdded = 0;
                while (!(sd >= ed))
                {
                    minutesAdded += settings.TimeSlot;
                    int numberOfHoursToAdd = Conversions.ToInteger(Math.Floor(minutesAdded / (double)60));
                    int numberOfMinutesToAdd = Conversions.ToInteger(minutesAdded - numberOfHoursToAdd * 60);
                    string str = "";
                    switch (numberOfHoursToAdd)
                    {
                        case 0:
                            {
                                str += "";
                                break;
                            }

                        case 1:
                            {
                                str += numberOfHoursToAdd + " hr ";
                                break;
                            }

                        default:
                            {
                                str += numberOfHoursToAdd + " hrs ";
                                break;
                            }
                    }

                    switch (numberOfMinutesToAdd)
                    {
                        case 0:
                            {
                                str += "";
                                break;
                            }

                        case 1:
                            {
                                str += numberOfMinutesToAdd + " min";
                                break;
                            }

                        default:
                            {
                                str += numberOfMinutesToAdd + " mins";
                                break;
                            }
                    }

                    dt.Rows.Add(new string[] { minutesAdded, str, 0 });
                    sd = sd.AddMinutes(settings.TimeSlot);
                }

                return dt;
            }
        }

        public static DataTable get_SystemDocumentTypes(Entity.Sys.Enums.OrderType OrderType)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("ValueMember"));
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("Deleted"));
            dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.SystemDocumentType.SupplierPurchaseOrder), "Supplier Purchase Order", "0" });
            return dt;
        }

        public static DataTable Hours
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                for (int hour = 0; hour <= 23; hour++)
                {
                    DataRow row;
                    row = dt.NewRow();
                    if (hour.ToString().Length == 1)
                    {
                        row["DisplayMember"] = "0" + hour.ToString();
                    }
                    else
                    {
                        row["DisplayMember"] = hour.ToString();
                    }

                    row["ValueMember"] = hour;
                    row["Deleted"] = false;
                    dt.Rows.Add(row);
                }

                return dt;
            }
        }

        public static DataTable Minutes
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                for (int minute = 0; minute <= 59; minute++)
                {
                    DataRow row;
                    row = dt.NewRow();
                    if (minute.ToString().Length == 1)
                    {
                        row["DisplayMember"] = "0" + minute.ToString();
                    }
                    else
                    {
                        row["DisplayMember"] = minute.ToString();
                    }

                    row["ValueMember"] = minute;
                    row["Deleted"] = false;
                    dt.Rows.Add(row);
                }

                return dt;
            }
        }

        public static DataTable ReminderFrequency
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReminderFrequencies.Minutes), "Minutes", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReminderFrequencies.Hours), "Hours", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReminderFrequencies.Days), "Days", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReminderFrequencies.Weeks), "Weeks", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReminderFrequencies.Months), "Months", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ReminderFrequencies.Years), "Years", "0" });
                return dt;
            }
        }

        public static DataTable NumberSelector // 1 to 60
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                for (int i = 1; i <= 60; i++)
                {
                    DataRow row;
                    row = dt.NewRow();
                    row["DisplayMember"] = i.ToString();
                    row["ValueMember"] = i;
                    row["Deleted"] = false;
                    dt.Rows.Add(row);
                }

                return dt;
            }
        }

        public static DataTable OutcomeStatuses
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.EngineerVisitOutcomes.Complete), "Complete", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.EngineerVisitOutcomes.Carded), "Carded", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.EngineerVisitOutcomes.Could_Not_Start), "Could Not Start", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.EngineerVisitOutcomes.Declined), "Declined", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.EngineerVisitOutcomes.Further_Works), "Further Works", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.EngineerVisitOutcomes.Visit_Not_Required), "Visit Not Required", "0" });
                return dt;
            }
        }

        public static DataTable ChecklistResults
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ChecklistResults.NOT_SET), "Choose...", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ChecklistResults.Yes), "Yes", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ChecklistResults.No), "No", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.ChecklistResults.NA), "N / A", "0" });
                return dt;
            }
        }

        public static DataTable PeriodTypes
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PeriodType.Days), "Days", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PeriodType.Weeks), "Weeks", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PeriodType.Months), "Months", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PeriodType.Years), "Years", "0" });
                return dt;
            }
        }

        public static DataTable InvoiceStatus
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(-3), "---Show All---", "0" });
                // dt.Rows.Add(New String() {CInt(-2), "Not Invoiced", "0"})
                dt.Rows.Add(new string[] { Conversions.ToInteger(-1), "Invoiced-Not Paid", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(0), "Invoiced-Payments Received", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(1), "Invoiced and Paid", "0" });
                return dt;
            }
        }

        public static DataTable ContractOnOrNone
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { "On Contract", "On Contract", "0" });
                dt.Rows.Add(new string[] { "Not On Contract", "Not On Contract", "0" });
                return dt;
            }
        }

        public static DataTable get_Count(int From, int To)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("ValueMember"));
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("Deleted"));
            for (int i = From, loopTo = To; i <= loopTo; i++)
                dt.Rows.Add(new string[] { i, i, 0 });
            return dt;
        }

        public static DataTable CreditStatus
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Awaiting_Part_Return), "Awaiting Part Return", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Part_Returned_To_Supplier), "Part Returned to Supplier", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Sent_To_Supplier), "Credit Req Sent to Supplier", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Received), "Credit Received", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Sent_To_Sage), "Sent To Sage", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.PartsToBeCreditedStatus.Credit_Req_Cancelled_By_Engineer), "Credit Req Cancelled By Engineer", "0" });
                return dt;
            }
        }

        public static DataTable JOWStatus
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobOfWorkStatus.Open), Entity.Sys.Enums.JobOfWorkStatus.Open.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobOfWorkStatus.Closed), Entity.Sys.Enums.JobOfWorkStatus.Closed.ToString(), "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.JobOfWorkStatus.Complete), Entity.Sys.Enums.JobOfWorkStatus.Complete.ToString(), "0" });
                return dt;
            }
        }

        public static DataTable LetterType
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { "1", "Letter 1", "0" });
                dt.Rows.Add(new string[] { "2", "Letter 2", "0" });
                dt.Rows.Add(new string[] { "3", "Letter 3", "0" });
                return dt;
            }
        }

        public static DataTable Salutation
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { "Mr", "Mr", "0" });
                dt.Rows.Add(new string[] { "Mrs", "Mrs", "0" });
                dt.Rows.Add(new string[] { "Miss", "Miss", "0" });
                dt.Rows.Add(new string[] { "Ms", "Ms", "0" });
                dt.Rows.Add(new string[] { "Dr", "Dr", "0" });
                dt.Rows.Add(new string[] { "Lord", "Lord", "0" });
                dt.Rows.Add(new string[] { "Lady", "Lady", "0" });
                dt.Rows.Add(new string[] { "Prof.", "Prof.", "0" });
                dt.Rows.Add(new string[] { "Sir", "Sir", "0" });
                dt.Rows.Add(new string[] { "Rev.", "Rev.", "0" });
                dt.Rows.Add(new string[] { "Void", "Void", "0" });
                dt.Rows.Add(new string[] { "Mx", "Mx", "0" });
                dt.Rows.Add(new string[] { "Company Name", "Company Name", "0" });
                return dt;
            }
        }

        public static DataTable ServExpiry
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { -1, "Expired", "0" });
                dt.Rows.Add(new string[] { 7, "1 Week", "0" });
                dt.Rows.Add(new string[] { 14, "2 Weeks", "0" });
                dt.Rows.Add(new string[] { 21, "3 Weeks", "0" });
                dt.Rows.Add(new string[] { 28, "4 Weeks", "0" });
                // dt.Rows.Add(New String() {"Gas Fire Only", "Gas Fire Only", "0"})
                // dt.Rows.Add(New String() {"Gas Full System", "Gas Full System", "0"})
                // dt.Rows.Add(New String() {"Gas Warm Air", "Gas Warm Air", "0"})
                // dt.Rows.Add(New String() {"Oil Fired Heating", "Oil Fired Heating", "0"})
                return dt;
            }
        }

        public static DataTable Surveyor
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { 1, "Install Surveyor", "0" });
                dt.Rows.Add(new string[] { 2, "Breakdown Engineer", "0" });
                dt.Rows.Add(new string[] { 3, "None", "0" });
                // dt.Rows.Add(New String() {3, "3 Weeks", "0"})
                // dt.Rows.Add(New String() {4, "4 Weeks", "0"})
                // dt.Rows.Add(New String() {"Gas Fire Only", "Gas Fire Only", "0"})
                // dt.Rows.Add(New String() {"Gas Full System", "Gas Full System", "0"})
                // dt.Rows.Add(New String() {"Gas Warm Air", "Gas Warm Air", "0"})
                // dt.Rows.Add(New String() {"Oil Fired Heating", "Oil Fired Heating", "0"})
                return dt;
            }
        }

        public static DataTable JobWizTerms
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { 1, "Contract", "0" });
                dt.Rows.Add(new string[] { 2, "OTI", "0" });
                dt.Rows.Add(new string[] { 3, "POC", "0" });
                dt.Rows.Add(new string[] { 4, "FOC", "0" });
                // dt.Rows.Add(New String() {3, "3 Weeks", "0"})
                // dt.Rows.Add(New String() {4, "4 Weeks", "0"})
                // dt.Rows.Add(New String() {"Gas Fire Only", "Gas Fire Only", "0"})
                // dt.Rows.Add(New String() {"Gas Full System", "Gas Full System", "0"})
                // dt.Rows.Add(New String() {"Gas Warm Air", "Gas Warm Air", "0"})
                // dt.Rows.Add(New String() {"Oil Fired Heating", "Oil Fired Heating", "0"})
                return dt;
            }
        }

        public static DataTable ComoDateType
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { 1, "Expiry", "0" });
                dt.Rows.Add(new string[] { 2, "Manufactured", "0" });
                dt.Rows.Add(new string[] { 3, "N/A", "0" });
                // dt.Rows.Add(New String() {3, "3 Weeks", "0"})
                // dt.Rows.Add(New String() {4, "4 Weeks", "0"})
                // dt.Rows.Add(New String() {"Gas Fire Only", "Gas Fire Only", "0"})
                // dt.Rows.Add(New String() {"Gas Full System", "Gas Full System", "0"})
                // dt.Rows.Add(New String() {"Gas Warm Air", "Gas Warm Air", "0"})
                // dt.Rows.Add(New String() {"Oil Fired Heating", "Oil Fired Heating", "0"})
                return dt;
            }
        }

        public static DataTable JobWizAdditional
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));

                // dt.Rows.Add(New String() {1, "Breakdown At Same Time As Service", "0"})
                dt.Rows.Add(new string[] { 1, "Service At Same Time As Breakdown", "0" });

                // dt.Rows.Add(New String() {3, "3 Weeks", "0"})

                return dt;
            }
        }

        public static DataTable JobWizTypesOfWork
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));

                // dt.Rows.Add(New String() {1, "Breakdown At Same Time As Service", "0"})
                dt.Rows.Add(new string[] { 1, "Heating", "0" });
                dt.Rows.Add(new string[] { 2, "Commercial", "0" });
                dt.Rows.Add(new string[] { 3, "Plumbing", "0" });
                dt.Rows.Add(new string[] { 4, "Electrical", "0" });
                dt.Rows.Add(new string[] { 5, "Building Maintenance / Pest", "0" });
                // dt.Rows.Add(New String() {3, "3 Weeks", "0"})

                return dt;
            }
        }

        public static DataTable JobWizServTypesOfWork
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));

                // dt.Rows.Add(New String() {1, "Breakdown At Same Time As Service", "0"})
                dt.Rows.Add(new string[] { 1, "Standard Service", "0" });
                dt.Rows.Add(new string[] { 2, "Mutual Exchange", "0" });
                dt.Rows.Add(new string[] { 3, "Reinstate", "0" });
                dt.Rows.Add(new string[] { 4, "Void Check", "0" });
                // dt.Rows.Add(New String() {3, "3 Weeks", "0"})

                return dt;
            }
        }

        public static DataTable FleetVanContractProcurementMethod
        {
            get
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.FleetVanContractProcurementMethod.ContractHire), "Contract Hire", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.FleetVanContractProcurementMethod.HPDepn), "HP/.Depn", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.FleetVanContractProcurementMethod.Hire), "Hire", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.FleetVanContractProcurementMethod.Owned), "Owned", "0" });
                dt.Rows.Add(new string[] { Conversions.ToInteger(Entity.Sys.Enums.FleetVanContractProcurementMethod.Leased), "Leased", "0" });
                return dt;
            }
        }

        public static DataTable SupplierIDList
        {
            get
            {
                var dt = new DataTable();
                dt = App.DB.Supplier.Supplier_GetAll().ToTable();
                return dt;
            }
        }
    }
}