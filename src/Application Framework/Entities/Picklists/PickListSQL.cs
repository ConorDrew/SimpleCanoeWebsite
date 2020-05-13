using Microsoft.VisualBasic.CompilerServices;
using System.Data;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace FSM.Entity
{
    namespace PickLists
    {
        public class PickListSQL
        {
            private Sys.Database _database;

            public PickListSQL(Sys.Database databaseIn)
            {
                _database = databaseIn;
            }

            public DataView PickListTypes()
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                DataRow row;
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Regions);
                row["DisplayMember"] = "Regions";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.CustomerTypes);
                row["DisplayMember"] = "Customer Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.JobTypes);
                row["DisplayMember"] = "Job Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Types);
                row["DisplayMember"] = "Product Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Makes);
                row["DisplayMember"] = "Product Makes";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Models);
                row["DisplayMember"] = "Product Models";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.PartCategories);
                row["DisplayMember"] = "Part Categories";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.UnitTypes);
                row["DisplayMember"] = "Unit Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.OrderChargeTypes);
                row["DisplayMember"] = "Charge Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Engineer_Levels);
                row["DisplayMember"] = "Engineer Levels/Qualifications";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.EngineerGroup);
                row["DisplayMember"] = "Engineer Groups";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.NoteCategory);
                row["DisplayMember"] = "Note Categories";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.DocumentTypes);
                row["DisplayMember"] = "Document Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.QuoteRejectionReasons);
                row["DisplayMember"] = "Rejection Reasons";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.TimeSheetTypes);
                row["DisplayMember"] = "Timesheet Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.ScheduleRatesCategories);
                row["DisplayMember"] = "Scheduled Rates Categories";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.PayGrades);
                row["DisplayMember"] = "Pay Grades";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.DisciplinaryStatus);
                row["DisplayMember"] = "Disciplinary Statuses";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.PartShelfReferences);
                row["DisplayMember"] = "Part Shelf References";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.PartBinReferences);
                row["DisplayMember"] = "Part Bin References";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.SourceOfCustomer);
                row["DisplayMember"] = "Source Of Customer";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.VATCodes);
                row["DisplayMember"] = "VAT Codes";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.ContractTypes);
                row["DisplayMember"] = "Contract Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.ReasonsForContact);
                row["DisplayMember"] = "Reasons For Contact";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.JOWPriority);
                row["DisplayMember"] = "Job Of Work Priorities";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.HeatingSystemType);
                row["DisplayMember"] = "Heating System Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.CylinderType);
                row["DisplayMember"] = "Cylinder Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Jacket);
                row["DisplayMember"] = "Jackets";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.CertificateType);
                row["DisplayMember"] = "Certificate Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.CancellationReasons);
                row["DisplayMember"] = "Cancellation Reasons";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.ContractPricing);
                row["DisplayMember"] = "Renewal Prices";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.FTFCodes);
                row["DisplayMember"] = "FTFCodes";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.CoverPlanDiscounts);
                row["DisplayMember"] = "CoverPlan Discounts";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.EquipmentType);
                row["DisplayMember"] = "Equipment Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.EquipmentStatus);
                row["DisplayMember"] = "Equipment Status";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.SalesNominal);
                row["DisplayMember"] = "Sales Nominal For Region";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.PurchaseNominal);
                row["DisplayMember"] = "Purchase Nominal For Region";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Department);
                row["DisplayMember"] = "Departments";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.InvoiceTerms);
                row["DisplayMember"] = "Invoice Terms";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.PriceList);
                row["DisplayMember"] = "Price List";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_TBLPickListTypes.ToString();
                return new DataView(dt);
            }

            public DataView PickListTypesLimited()
            {
                var dt = new DataTable();
                dt.Columns.Add(new DataColumn("ValueMember"));
                dt.Columns.Add(new DataColumn("DisplayMember"));
                dt.Columns.Add(new DataColumn("Deleted"));
                DataRow row;
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Types);
                row["DisplayMember"] = "Product Types";
                row["Deleted"] = false;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Makes);
                row["DisplayMember"] = "Product Makes";
                row["Deleted"] = false;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Sys.Enums.PickListTypes.Models);
                row["DisplayMember"] = "Product Models";
                row["Deleted"] = false;
                dt.Rows.Add(row);

                row = dt.NewRow();
                row["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.NominalCodes);
                row["DisplayMember"] = "Nominal Codes";
                row["Deleted"] = false;
                dt.Rows.Add(row);

                dt.TableName = Sys.Enums.TableNames.NOT_IN_DATABASE_TBLPickListTypes.ToString();
                return new DataView(dt);
            }

            public DataView GetAll(Sys.Enums.PickListTypes enumTypeID, bool async = false)
            {
                DataTable dt = null;
                if (async)
                {
                    var sqlEnumTypeId = new System.Data.SqlClient.SqlParameter("@EnumTypeId", Conversions.ToInteger(enumTypeID));
                    dt = _database.ExecuteSP_DataTable("Picklists_GetAll_ForEnumType", sqlEnumTypeId);
                }
                else
                {
                    _database.ClearParameter();
                    _database.AddParameter("@EnumTypeID", (int)enumTypeID);
                    dt = _database.ExecuteSP_DataTable("Picklists_GetByEnumTypeId");
                }

                dt.TableName = Sys.Enums.TableNames.tblPickLists.ToString();
                return new DataView(dt);
            }

            public DataView GetAllPartMappings(Sys.Enums.PickListTypes enumTypeID)
            {
                _database.ClearParameter();
                _database.AddParameter("@EnumTypeID", (int)enumTypeID);
                var dt = _database.ExecuteSP_DataTable("Picklists_Get_PartMapping");
                dt.TableName = Sys.Enums.TableNames.tblPartCategoryMapping.ToString();
                return new DataView(dt);
            }

            public PickList Get_One_As_Object(int ManagerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ManagerID", ManagerID);
                var dt = _database.ExecuteSP_DataTable("Picklists_Get");
                if (dt.Rows.Count > 0)
                {
                    var picklist = new PickList();
                    picklist.SetManagerID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["ManagerID"]);
                    picklist.SetEnumTypeID = Sys.Helper.MakeIntegerValid(dt.Rows[0]["EnumTypeID"]);
                    picklist.SetName = Sys.Helper.MakeStringValid(dt.Rows[0]["Name"]);
                    picklist.SetDescription = Sys.Helper.MakeStringValid(dt.Rows[0]["Description"]);
                    picklist.SetDeleted = Sys.Helper.MakeBooleanValid(dt.Rows[0]["Deleted"]);
                    picklist.SetPercentageRate = Sys.Helper.MakeDoubleValid(dt.Rows[0]["PercentageRate"]);
                    if (dt.Columns.Contains("Mandatory"))
                        picklist.SetMandatory = Sys.Helper.MakeBooleanValid(dt.Rows[0]["Mandatory"]);
                    return picklist;
                }
                else
                {
                    return new PickList();
                }
            }

            public int Insert(PickList pickList)
            {
                _database.ClearParameter();
                _database.AddParameter("@EnumTypeID", pickList.EnumTypeID);
                _database.AddParameter("@Name", pickList.Name);
                _database.AddParameter("@Description", pickList.Description);
                _database.AddParameter("@Mandatory", pickList.Mandatory);
                var switchExpr = pickList.EnumTypeID;
                switch (switchExpr)
                {
                    case (int)Sys.Enums.PickListTypes.VATCodes:
                    case (int)Sys.Enums.PickListTypes.PartCategories:
                    case (int)Sys.Enums.PickListTypes.CoverPlanDiscounts:
                        {
                            _database.AddParameter("@PercentageRate", pickList.PercentageRate);
                            break;
                        }

                    case (int)Sys.Enums.PickListTypes.Engineer_Levels:
                        {
                            _database.AddParameter("@PercentageRate", pickList.PercentageRate);
                            break;
                        }

                    default:
                        {
                            _database.AddParameter("@PercentageRate", 0);
                            break;
                        }
                }

                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Picklists_Insert"));
            }

            public int InsertPartCategory(int ManagerID, string PartMapMatch)
            {
                _database.ClearParameter();
                _database.AddParameter("@ManagerID", ManagerID);
                _database.AddParameter("@PartMapMatch", PartMapMatch);
                return Sys.Helper.MakeIntegerValid(_database.ExecuteSP_OBJECT("Picklists_InsertPartMapping"));
            }

            public void Update(PickList pickList)
            {
                _database.ClearParameter();
                _database.AddParameter("@Name", pickList.Name);
                _database.AddParameter("@Description", pickList.Description);
                _database.AddParameter("@Mandatory", pickList.Mandatory);
                _database.AddParameter("@ManagerID", pickList.ManagerID);
                var switchExpr = pickList.EnumTypeID;
                switch (switchExpr)
                {
                    case (int)Sys.Enums.PickListTypes.VATCodes:
                    case (int)Sys.Enums.PickListTypes.PartCategories:
                    case (int)Sys.Enums.PickListTypes.CoverPlanDiscounts:
                        {
                            _database.AddParameter("@PercentageRate", pickList.PercentageRate);
                            break;
                        }

                    case (int)Sys.Enums.PickListTypes.Engineer_Levels:
                        {
                            _database.AddParameter("@PercentageRate", pickList.PercentageRate);
                            break;
                        }

                    default:
                        {
                            _database.AddParameter("@PercentageRate", 0);
                            break;
                        }
                }

                _database.ExecuteSP_OBJECT("Picklists_Update");
            }

            public void UpdatePartMapping(int PartMapID, int ManagerID, string PartMapMatch)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartMapID", PartMapID);
                _database.AddParameter("@ManagerID", ManagerID);
                _database.AddParameter("@PartMapMatch", PartMapMatch);
                _database.ExecuteSP_OBJECT("Picklists_UpdatePartMapping");
            }

            public void UpdateSellPrices(PickList pickList)
            {
                _database.ClearParameter();
                _database.AddParameter("@CategoryID", pickList.ManagerID);
                _database.ExecuteSP_NO_Return("Picklists_UpdatePartsMargins");
            }

            public void UpdateSellPricesByPart(int CategoryID, int PartID)
            {
                _database.ClearParameter();
                _database.AddParameter("@CategoryID", CategoryID);
                _database.AddParameter("@PartID", PartID);
                _database.ExecuteSP_NO_Return("Picklists_UpdatePartsMarginsByPart");
            }

            public void Delete(int ManagerID)
            {
                _database.ClearParameter();
                _database.AddParameter("@ManagerID", ManagerID);
                _database.ExecuteSP_OBJECT("Picklists_Delete");
            }

            public void DeletePartMapping(int PartMapID)
            {
                _database.ClearParameter();
                _database.AddParameter("@PartMapID", PartMapID);
                _database.ExecuteSP_OBJECT("Picklists_DeletePartMapping");
            }

            public DataView Region_Usage(int RegionID)
            {
                _database.ClearParameter();
                _database.AddParameter("@RegionID", RegionID);
                var dt = _database.ExecuteSP_DataTable("Region_Usage");
                dt.TableName = Sys.Enums.TableNames.tblRegion.ToString();
                return new DataView(dt);
            }

            public bool Check_Unique_Name(string Name, int ID, Sys.Enums.PickListTypes type)
            {
                int NumberOfRows = Sys.Helper.MakeIntegerValid(_database.ExecuteScalar("SELECT COUNT(ManagerID) as 'NumberOfRows' " + "FROM tblpicklists WHERE EnumTypeID = " + Conversions.ToInteger(type) + " AND Name = '" + Name + "' AND ManagerID <> " + ID, false));
                if (NumberOfRows == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public string Get_Single_Description(string Name, Sys.Enums.PickListTypes type)
            {
                string Description = Sys.Helper.MakeStringValid(_database.ExecuteScalar("SELECT Description " + "FROM tblpicklists WHERE EnumTypeID = " + Conversions.ToInteger(type) + " AND Name = '" + Name + "'", false));
                return Description;
            }
        }
    }
}