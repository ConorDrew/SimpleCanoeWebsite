// Decompiled with JetBrains decompiler
// Type: FSM.DynamicDataTables
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Management;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;

namespace FSM
{
  public class DynamicDataTables
  {
    public static DataTable Setup_Search_On_Options(
      Enums.MenuTypes MenuType,
      Enums.TableNames tableName)
    {
      DataTable dataTable = new DataTable();
      dataTable.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchOn.ToString();
      dataTable.Columns.Add(new DataColumn("ValueMember"));
      dataTable.Columns.Add(new DataColumn("DisplayMember"));
      dataTable.Columns.Add(new DataColumn("Deleted", Type.GetType("System.Boolean")));
      if (MenuType == Enums.MenuTypes.Spares)
      {
        switch (tableName)
        {
          case Enums.TableNames.tblPart:
            DataRow row1 = dataTable.NewRow();
            row1["ValueMember"] = (object) "";
            row1["DisplayMember"] = (object) "All";
            row1["Deleted"] = (object) false;
            dataTable.Rows.Add(row1);
            DataRow row2 = dataTable.NewRow();
            row2["ValueMember"] = (object) "tp.Name";
            row2["DisplayMember"] = (object) "Name";
            row2["Deleted"] = (object) false;
            dataTable.Rows.Add(row2);
            DataRow row3 = dataTable.NewRow();
            row3["ValueMember"] = (object) "Category.Name";
            row3["DisplayMember"] = (object) "Category";
            row3["Deleted"] = (object) false;
            dataTable.Rows.Add(row3);
            DataRow row4 = dataTable.NewRow();
            row4["ValueMember"] = (object) "tp.Number";
            row4["DisplayMember"] = (object) "Number";
            row4["Deleted"] = (object) false;
            dataTable.Rows.Add(row4);
            DataRow row5 = dataTable.NewRow();
            row5["ValueMember"] = (object) "tp.Reference";
            row5["DisplayMember"] = (object) "Reference";
            row5["Deleted"] = (object) false;
            dataTable.Rows.Add(row5);
            break;
          case Enums.TableNames.tblProduct:
            DataRow row6 = dataTable.NewRow();
            row6["ValueMember"] = (object) "";
            row6["DisplayMember"] = (object) "All";
            row6["Deleted"] = (object) false;
            dataTable.Rows.Add(row6);
            DataRow row7 = dataTable.NewRow();
            row7["ValueMember"] = (object) "tblProduct.Reference";
            row7["DisplayMember"] = (object) "Reference";
            row7["Deleted"] = (object) false;
            dataTable.Rows.Add(row7);
            DataRow row8 = dataTable.NewRow();
            row8["ValueMember"] = (object) "tblProduct.Number";
            row8["DisplayMember"] = (object) "GC Number";
            row8["Deleted"] = (object) false;
            dataTable.Rows.Add(row8);
            DataRow row9 = dataTable.NewRow();
            row9["ValueMember"] = (object) "type.[Name]";
            row9["DisplayMember"] = (object) "Type";
            row9["Deleted"] = (object) false;
            dataTable.Rows.Add(row9);
            DataRow row10 = dataTable.NewRow();
            row10["ValueMember"] = (object) "make.[Name]";
            row10["DisplayMember"] = (object) "Make";
            row10["Deleted"] = (object) false;
            dataTable.Rows.Add(row10);
            DataRow row11 = dataTable.NewRow();
            row11["ValueMember"] = (object) "model.[Name]";
            row11["DisplayMember"] = (object) "Model";
            row11["Deleted"] = (object) false;
            dataTable.Rows.Add(row11);
            DataRow row12 = dataTable.NewRow();
            row12["ValueMember"] = (object) "tblSupplier.name";
            row12["DisplayMember"] = (object) "Supplier";
            row12["Deleted"] = (object) false;
            dataTable.Rows.Add(row12);
            break;
          case Enums.TableNames.tblSupplier:
            DataRow row13 = dataTable.NewRow();
            row13["ValueMember"] = (object) "";
            row13["DisplayMember"] = (object) "All";
            row13["Deleted"] = (object) false;
            dataTable.Rows.Add(row13);
            DataRow row14 = dataTable.NewRow();
            row14["ValueMember"] = (object) "Name";
            row14["DisplayMember"] = (object) "Name";
            row14["Deleted"] = (object) false;
            dataTable.Rows.Add(row14);
            DataRow row15 = dataTable.NewRow();
            row15["ValueMember"] = (object) "AccountNumber";
            row15["DisplayMember"] = (object) "Account Number";
            row15["Deleted"] = (object) false;
            dataTable.Rows.Add(row15);
            DataRow row16 = dataTable.NewRow();
            row16["ValueMember"] = (object) "Address1";
            row16["DisplayMember"] = (object) "Address1";
            row16["Deleted"] = (object) false;
            dataTable.Rows.Add(row16);
            DataRow row17 = dataTable.NewRow();
            row17["ValueMember"] = (object) "tblSupplier.Postcode";
            row17["DisplayMember"] = (object) "Postcode";
            row17["Deleted"] = (object) false;
            dataTable.Rows.Add(row17);
            break;
          case Enums.TableNames.tblWarehouse:
            DataRow row18 = dataTable.NewRow();
            row18["ValueMember"] = (object) "";
            row18["DisplayMember"] = (object) "All";
            row18["Deleted"] = (object) false;
            dataTable.Rows.Add(row18);
            DataRow row19 = dataTable.NewRow();
            row19["ValueMember"] = (object) "tblWarehouse.Name";
            row19["DisplayMember"] = (object) "Name";
            row19["Deleted"] = (object) false;
            dataTable.Rows.Add(row19);
            DataRow row20 = dataTable.NewRow();
            row20["ValueMember"] = (object) "tblWarehouse.Address1";
            row20["DisplayMember"] = (object) "Address1";
            row20["Deleted"] = (object) false;
            dataTable.Rows.Add(row20);
            DataRow row21 = dataTable.NewRow();
            row21["ValueMember"] = (object) "tblWarehouse.Postcode";
            row21["DisplayMember"] = (object) "Postcode";
            row21["Deleted"] = (object) false;
            dataTable.Rows.Add(row21);
            break;
        }
      }
      return dataTable;
    }

    public static DataTable Setup_Advanced_Search_Options(Enums.MenuTypes MenuType)
    {
      DataTable dataTable = new DataTable();
      dataTable.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchFor.ToString();
      dataTable.Columns.Add(new DataColumn("ValueMember"));
      dataTable.Columns.Add(new DataColumn("DisplayMember"));
      dataTable.Columns.Add(new DataColumn("Deleted", Type.GetType("System.Boolean")));
      if (MenuType == Enums.MenuTypes.Spares)
      {
        DataRow row1 = dataTable.NewRow();
        row1["ValueMember"] = (object) 13;
        row1["DisplayMember"] = (object) "Part";
        row1["Deleted"] = (object) false;
        dataTable.Rows.Add(row1);
        DataRow row2 = dataTable.NewRow();
        row2["ValueMember"] = (object) 14;
        row2["DisplayMember"] = (object) "Product";
        row2["Deleted"] = (object) false;
        dataTable.Rows.Add(row2);
      }
      return dataTable;
    }

    public static DataTable Setup_Search_Options(Enums.MenuTypes MenuType)
    {
      DataTable dataTable = new DataTable();
      dataTable.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchFor.ToString();
      dataTable.Columns.Add(new DataColumn("ValueMember"));
      dataTable.Columns.Add(new DataColumn("DisplayMember"));
      dataTable.Columns.Add(new DataColumn("Deleted", Type.GetType("System.Boolean")));
      switch (MenuType)
      {
        case Enums.MenuTypes.Customers:
          DataRow row1 = dataTable.NewRow();
          row1["ValueMember"] = (object) 12;
          row1["DisplayMember"] = (object) "Customer";
          row1["Deleted"] = (object) false;
          dataTable.Rows.Add(row1);
          DataRow row2 = dataTable.NewRow();
          row2["ValueMember"] = (object) 24;
          row2["DisplayMember"] = (object) "Property";
          row2["Deleted"] = (object) false;
          dataTable.Rows.Add(row2);
          DataRow row3 = dataTable.NewRow();
          row3["ValueMember"] = (object) 16;
          row3["DisplayMember"] = (object) "Appliances";
          row3["Deleted"] = (object) false;
          dataTable.Rows.Add(row3);
          break;
        case Enums.MenuTypes.Spares:
          DataRow row4 = dataTable.NewRow();
          row4["ValueMember"] = (object) 15;
          row4["DisplayMember"] = (object) "Supplier";
          row4["Deleted"] = (object) false;
          dataTable.Rows.Add(row4);
          DataRow row5 = dataTable.NewRow();
          row5["ValueMember"] = (object) 14;
          row5["DisplayMember"] = (object) "Product";
          row5["Deleted"] = (object) false;
          dataTable.Rows.Add(row5);
          DataRow row6 = dataTable.NewRow();
          row6["ValueMember"] = (object) 13;
          row6["DisplayMember"] = (object) "Part";
          row6["Deleted"] = (object) false;
          dataTable.Rows.Add(row6);
          DataRow row7 = dataTable.NewRow();
          row7["ValueMember"] = (object) 58;
          row7["DisplayMember"] = (object) "Warehouse";
          row7["Deleted"] = (object) false;
          dataTable.Rows.Add(row7);
          break;
        case Enums.MenuTypes.Staff:
          DataRow row8 = dataTable.NewRow();
          row8["ValueMember"] = (object) 17;
          row8["DisplayMember"] = (object) "Engineer";
          row8["Deleted"] = (object) false;
          dataTable.Rows.Add(row8);
          DataRow row9 = dataTable.NewRow();
          row9["ValueMember"] = (object) 21;
          row9["DisplayMember"] = (object) "Stock Profile";
          row9["Deleted"] = (object) false;
          dataTable.Rows.Add(row9);
          DataRow row10 = dataTable.NewRow();
          row10["ValueMember"] = (object) 41;
          row10["DisplayMember"] = (object) "Subcontractor";
          row10["Deleted"] = (object) false;
          dataTable.Rows.Add(row10);
          DataRow row11 = dataTable.NewRow();
          row11["ValueMember"] = (object) 6;
          row11["DisplayMember"] = (object) "User";
          row11["Deleted"] = (object) false;
          dataTable.Rows.Add(row11);
          DataRow row12 = dataTable.NewRow();
          row12["ValueMember"] = (object) 146;
          row12["DisplayMember"] = (object) "Equipment";
          row12["Deleted"] = (object) false;
          dataTable.Rows.Add(row12);
          break;
        case Enums.MenuTypes.Jobs:
          DataRow row13 = dataTable.NewRow();
          row13["ValueMember"] = (object) 50;
          row13["DisplayMember"] = (object) "Visit";
          row13["Deleted"] = (object) false;
          dataTable.Rows.Add(row13);
          DataRow row14 = dataTable.NewRow();
          row14["ValueMember"] = (object) 51;
          row14["DisplayMember"] = (object) "Quote";
          row14["Deleted"] = (object) false;
          dataTable.Rows.Add(row14);
          break;
        case Enums.MenuTypes.FleetVan:
          DataRow row15 = dataTable.NewRow();
          row15["ValueMember"] = (object) 150;
          row15["DisplayMember"] = (object) "Vans";
          row15["Deleted"] = (object) false;
          dataTable.Rows.Add(row15);
          DataRow row16 = dataTable.NewRow();
          row16["ValueMember"] = (object) 151;
          row16["DisplayMember"] = (object) "Van Type";
          row16["Deleted"] = (object) false;
          dataTable.Rows.Add(row16);
          DataRow row17 = dataTable.NewRow();
          row17["ValueMember"] = (object) 156;
          row17["DisplayMember"] = (object) "Equipment";
          row17["Deleted"] = (object) false;
          dataTable.Rows.Add(row17);
          DataRow row18 = dataTable.NewRow();
          row18["ValueMember"] = (object) 157;
          row18["DisplayMember"] = (object) "Service Centres";
          row18["Deleted"] = (object) false;
          dataTable.Rows.Add(row18);
          break;
      }
      return dataTable;
    }

    public static DataTable Times(int TimeSlot = 15)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add(new DataColumn("ValueMember"));
      dataTable.Columns.Add(new DataColumn("DisplayMember"));
      dataTable.Columns.Add(new DataColumn("Deleted"));
      int num1 = 0;
      do
      {
        int num2 = TimeSlot;
        int num3 = 0;
        while ((num2 >> 31 ^ num3) <= (num2 >> 31 ^ 45))
        {
          string str1 = "";
          if (num1.ToString().Length == 1)
            str1 += "0";
          string str2 = str1 + num1.ToString() + ":";
          if (num3.ToString().Length == 1)
            str2 += "0";
          string str3 = str2 + num3.ToString();
          DataRow row = dataTable.NewRow();
          row["DisplayMember"] = (object) str3;
          row["ValueMember"] = (object) str3;
          row["Deleted"] = (object) false;
          dataTable.Rows.Add(row);
          checked { num3 += num2; }
        }
        checked { ++num1; }
      }
      while (num1 <= 23);
      return dataTable;
    }

    public static DataTable CustomerStatus
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Active",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "InActive",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "On Hold",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Prospect",
              "0"
            }
          }
        };
      }
    }

    public static DataTable PartValidationTypes
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(14),
              "Unverified",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              "Category Missing",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Matched - No Change",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Matched - Price INCREASE",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Matched - Price DECREASE",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Duplicate SPN Found",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(12),
              "Duplicate MPN Found",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Matched MPN New SPN",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "New Part MPN and SPN",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(15),
              "Parts for supplier not in import",
              "0"
            }
          }
        };
      }
    }

    public static DataTable PartsInvoiceImportValidationResults
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "(PII) Replenishment",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "(PII) Unable to Locate Purchase Order",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "(PII) Matched Purchase Order - Supplier Invoice Price Correct",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "(PII) Matched Purchase Order - Supplier Invoice Price Above",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "(PII) Matched Purchase Order - Supplier Invoice Price Below",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(8),
              "(PII) Matched Purchase Order - No Parts Included on PO",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(12),
              "(PII) Matched Purchase Order - No Parts, Unable to Match Parts",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(9),
              "(PII) Matched Purchase Order - PO Sent To Sage",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              "(PII) Supplier Invoice Created",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "(PII) Purchase Credits",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(10),
              "(PII) Job Incomplete",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(14),
              "(PII) Supplier Do Not Match",
              "0"
            }
          }
        };
      }
    }

    public static DataTable POInvoiceAuthorisation
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Matched Purchase Order - Supplier Invoice Price Correct",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Matched Purchase Order - Supplier Invoice Price Above",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Matched Purchase Order - Supplier Invoice Price Below",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ReplenishmentStatusTypes
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "Below Min Quantities - Quantity On Order To Replenish Stock",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              "Below Min Quantities - Order Required To Replenish Stock",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "No Preferred Supplier Found",
              "0"
            }
          }
        };
      }
    }

    public static DataTable Yes_No
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]{ "Yes", "Yes", "0" },
            (object[]) new string[3]{ "No", "No", "0" }
          }
        };
      }
    }

    public static DataTable OrderTypeForSearch
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              "1",
              "Customer, Property (Select Property from Property list)",
              "0"
            },
            (object[]) new string[3]
            {
              "2",
              "Customer, Warehouse (Select Warehouse from Warehouse locations)",
              "0"
            },
            (object[]) new string[3]
            {
              "3",
              "Stock Profile (Select Profile from Stock list)",
              "0"
            },
            (object[]) new string[3]
            {
              "4",
              "Warehouse (Select Warehouse from Warehouse locations)",
              "0"
            },
            (object[]) new string[3]
            {
              "5",
              "Job (Search for Job to pick Engineer Visit)",
              "0"
            }
          }
        };
      }
    }

    public static DataTable OrderType
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              "1",
              "Customer (Select Delivery Location)",
              "0"
            },
            (object[]) new string[3]
            {
              "2",
              "Stock Profile (Select Profile from Stock list)",
              "0"
            },
            (object[]) new string[3]
            {
              "3",
              "Warehouse (Select Warehouse from Warehouse locations)",
              "0"
            },
            (object[]) new string[3]
            {
              "4",
              "Job (Search for Job to pick Engineer Visit)",
              "0"
            }
          }
        };
      }
    }

    public static DataTable LocationType
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]{ "1", "Supplier", "0" },
            (object[]) new string[3]
            {
              "2",
              "Stock Profile",
              "0"
            },
            (object[]) new string[3]
            {
              "3",
              "Warehouse",
              "0"
            }
          }
        };
      }
    }

    public static DataTable InvoiceFrequency
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              Enums.InvoiceFrequency.Weekly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              Enums.InvoiceFrequency.Monthly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.InvoiceFrequency.Quarterly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              Enums.InvoiceFrequency.Bi_Annually.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              Enums.InvoiceFrequency.Annually.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              Enums.InvoiceFrequency.Per_Visit.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(9),
              "Annual Direct Debit",
              "0"
            }
          }
        };
      }
    }

    public static DataTable InvoiceFrequency_NoWeekly
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              Enums.InvoiceFrequency_NoWeeK.Monthly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(8),
              Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.InvoiceFrequency_NoWeeK.Quarterly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              Enums.InvoiceFrequency_NoWeeK.Bi_Annually.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              Enums.InvoiceFrequency_NoWeeK.Annually.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              Enums.InvoiceFrequency_NoWeeK.Per_Visit.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(9),
              "Annual Direct Debit",
              "0"
            }
          }
        };
      }
    }

    public static DataTable VisitFrequencyNoWeekly
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              Enums.VisitFrequency.Monthly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(8),
              Enums.VisitFrequency.GBS_4_Month_Visits.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              Enums.VisitFrequency.Quarterly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              Enums.VisitFrequency.Bi_Annually.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              Enums.VisitFrequency.Annually.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(9),
              Enums.VisitFrequency.Fortnightly.ToString(),
              "0"
            }
          }
        };
      }
    }

    public static DataTable ContractVisitType
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              Enums.ContractVisitType.Commercial.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.ContractVisitType.Domestic.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              Enums.ContractVisitType.Electrical.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              Enums.ContractVisitType.SubContractor.ToString(),
              "0"
            }
          }
        };
      }
    }

    public static DataTable VisitFrequency
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.VisitFrequency.Weekly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              Enums.VisitFrequency.Monthly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              Enums.VisitFrequency.Quarterly.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              Enums.VisitFrequency.Bi_Annually.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              Enums.VisitFrequency.Annually.ToString(),
              "0"
            }
          }
        };
      }
    }

    public static DataTable ContractStatus
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.ContractStatus.Active.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              Enums.ContractStatus.Inactive.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              Enums.ContractStatus.Cancelled.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(12),
              "Inactive - Upgraded",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(13),
              "Inactive - Downgraded",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(14),
              "Inactive - Transferred to new property",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ContractPaymentTypes
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.ContractPaymentType.Annual.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              Enums.ContractPaymentType.Direct_Debit.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Annual Direct Debit",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ContractInitialPaymentTypes
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Debit Card",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Credit Card",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Cash",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Cheque",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Invoice",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "BACS",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              "FOC",
              "0"
            }
          }
        };
      }
    }

    public static DataTable Appointments
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "AM",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "PM",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ManualApp
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Boiler",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Gas Fire",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Cooker",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Unvented Cylinder",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Thermal Store Cylinder",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ContractPeriod
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "1 Year",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "2 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "3 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "4 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "5 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "6 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              "7 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(8),
              "8 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(9),
              "9 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(10),
              "10 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(11),
              "11 Years",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(12),
              "12 Years",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ContractTypes2
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(367),
              "Silver Star",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(368),
              "Gold Star",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(369),
              "Platinum Star",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(68032),
              "Platinum Immediate",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(68294),
              "Totally Assured",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(69420),
              "Preventative Maintenance Contract",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ReadingType
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(0),
              "Gas",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Oil",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Solid Fuel",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Unvented",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Solar",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "ASHP",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "GSHP",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              "Other",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(8),
              "Comercial Catering",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(9),
              "HIU",
              "0"
            }
          }
        };
      }
    }

    public static DataTable TankType
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Plastic",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Bunded",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Metal",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ContractRenewal
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.ContractRenewal.Renewed.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Not Renewed",
              "0"
            }
          }
        };
      }
    }

    public static DataTable Quote_ElectricianPack
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]{ "1", "Pack A", "0" },
            (object[]) new string[3]{ "2", "Pack B", "0" },
            (object[]) new string[3]{ "3", "Pack C", "0" }
          }
        };
      }
    }

    public static DataTable QuoteContractStatus
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              Enums.QuoteContractStatus.Generated.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              Enums.QuoteContractStatus.Accepted.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.QuoteContractStatus.Rejected.ToString(),
              "0"
            }
          }
        };
      }
    }

    public static DataTable VisitStatus_For_Selection
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Quote/Action Required",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Waiting For Parts",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Parts Despatched",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Ready For Schedule",
              "0"
            }
          }
        };
      }
    }

    public static DataTable VisitStatus_For_Viewing
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Quote/Action Required",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Waiting For Parts",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Parts Despatched",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Ready For Schedule",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Scheduled",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "Downloaded",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              "Uploaded",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(8),
              "Non Chargable",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(9),
              "Ready To Be Invoiced",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(10),
              "Invoiced",
              "0"
            }
          }
        };
      }
    }

    public static DataTable JobStatuses
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Open",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Complete",
              "0"
            }
          }
        };
      }
    }

    public static DataTable QuoteStatuses
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Generated",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Accepted",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Rejected",
              "0"
            }
          }
        };
      }
    }

    public static DataTable JobDefinitions
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Callout",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Contract",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Quoted",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Misc",
              "0"
            }
          }
        };
      }
    }

    public static DataTable VisitDuration
    {
      get
      {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(new DataColumn(nameof (VisitDuration)));
        dataTable.Columns.Add(new DataColumn("DisplayMember"));
        dataTable.Columns.Add(new DataColumn("Deleted"));
        Settings settings = App.DB.Manager.Get();
        DateTime t1;
        ref DateTime local1 = ref t1;
        DateTime now1 = DateAndTime.Now;
        int year1 = now1.Year;
        now1 = DateAndTime.Now;
        int month1 = now1.Month;
        now1 = DateAndTime.Now;
        int day1 = now1.Day;
        int integer1 = Conversions.ToInteger(settings.WorkingHoursStart.Trim().Substring(0, 2));
        int integer2 = Conversions.ToInteger(settings.WorkingHoursStart.Trim().Substring(3, 2));
        local1 = new DateTime(year1, month1, day1, integer1, integer2, 0);
        DateTime t2;
        ref DateTime local2 = ref t2;
        DateTime now2 = DateAndTime.Now;
        int year2 = now2.Year;
        now2 = DateAndTime.Now;
        int month2 = now2.Month;
        now2 = DateAndTime.Now;
        int day2 = now2.Day;
        int integer3 = Conversions.ToInteger(settings.WorkingHoursEnd.Trim().Substring(0, 2));
        int integer4 = Conversions.ToInteger(settings.WorkingHoursEnd.Trim().Substring(3, 2));
        local2 = new DateTime(year2, month2, day2, integer3, integer4, 0);
        int num1 = 0;
        for (; DateTime.Compare(t1, t2) < 0; t1 = t1.AddMinutes((double) settings.TimeSlot))
        {
          checked { num1 += settings.TimeSlot; }
          int num2 = checked ((int) Math.Floor(unchecked ((double) num1 / 60.0)));
          int num3 = checked (num1 - num2 * 60);
          string str1 = "";
          string str2;
          switch (num2)
          {
            case 0:
              str2 = str1 ?? "";
              break;
            case 1:
              str2 = str1 + Conversions.ToString(num2) + " hr ";
              break;
            default:
              str2 = str1 + Conversions.ToString(num2) + " hrs ";
              break;
          }
          string str3;
          switch (num3)
          {
            case 0:
              str3 = str2 ?? "";
              break;
            case 1:
              str3 = str2 + Conversions.ToString(num3) + " min";
              break;
            default:
              str3 = str2 + Conversions.ToString(num3) + " mins";
              break;
          }
          dataTable.Rows.Add((object[]) new string[3]
          {
            Conversions.ToString(num1),
            str3,
            Conversions.ToString(0)
          });
        }
        return dataTable;
      }
    }

    public static DataTable get_SystemDocumentTypes(Enums.OrderType OrderType)
    {
      return new DataTable()
      {
        Columns = {
          new DataColumn("ValueMember"),
          new DataColumn("DisplayMember"),
          new DataColumn("Deleted")
        },
        Rows = {
          (object[]) new string[3]
          {
            Conversions.ToString(5),
            "Supplier Purchase Order",
            "0"
          }
        }
      };
    }

    public static DataTable Hours
    {
      get
      {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(new DataColumn("ValueMember"));
        dataTable.Columns.Add(new DataColumn("DisplayMember"));
        dataTable.Columns.Add(new DataColumn("Deleted"));
        int num = 0;
        do
        {
          DataRow row = dataTable.NewRow();
          row["DisplayMember"] = num.ToString().Length != 1 ? (object) num.ToString() : (object) ("0" + num.ToString());
          row["ValueMember"] = (object) num;
          row["Deleted"] = (object) false;
          dataTable.Rows.Add(row);
          checked { ++num; }
        }
        while (num <= 23);
        return dataTable;
      }
    }

    public static DataTable Minutes
    {
      get
      {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(new DataColumn("ValueMember"));
        dataTable.Columns.Add(new DataColumn("DisplayMember"));
        dataTable.Columns.Add(new DataColumn("Deleted"));
        int num = 0;
        do
        {
          DataRow row = dataTable.NewRow();
          row["DisplayMember"] = num.ToString().Length != 1 ? (object) num.ToString() : (object) ("0" + num.ToString());
          row["ValueMember"] = (object) num;
          row["Deleted"] = (object) false;
          dataTable.Rows.Add(row);
          checked { ++num; }
        }
        while (num <= 59);
        return dataTable;
      }
    }

    public static DataTable ReminderFrequency
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Minutes",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Hours",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Days",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Weeks",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Months",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "Years",
              "0"
            }
          }
        };
      }
    }

    public static DataTable NumberSelector
    {
      get
      {
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add(new DataColumn("ValueMember"));
        dataTable.Columns.Add(new DataColumn("DisplayMember"));
        dataTable.Columns.Add(new DataColumn("Deleted"));
        int num = 1;
        do
        {
          DataRow row = dataTable.NewRow();
          row["DisplayMember"] = (object) num.ToString();
          row["ValueMember"] = (object) num;
          row["Deleted"] = (object) false;
          dataTable.Rows.Add(row);
          checked { ++num; }
        }
        while (num <= 60);
        return dataTable;
      }
    }

    public static DataTable OutcomeStatuses
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Complete",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Carded",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Could Not Start",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Declined",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Further Works",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "Visit Not Required",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ChecklistResults
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(0),
              "Choose...",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Yes",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "No",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "N / A",
              "0"
            }
          }
        };
      }
    }

    public static DataTable PeriodTypes
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Days",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Weeks",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Months",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Years",
              "0"
            }
          }
        };
      }
    }

    public static DataTable InvoiceStatus
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(-3),
              "---Show All---",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(-1),
              "Invoiced-Not Paid",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(0),
              "Invoiced-Payments Received",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Invoiced and Paid",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ContractOnOrNone
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              "On Contract",
              "On Contract",
              "0"
            },
            (object[]) new string[3]
            {
              "Not On Contract",
              "Not On Contract",
              "0"
            }
          }
        };
      }
    }

    public static DataTable get_Count(int From, int To)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add(new DataColumn("ValueMember"));
      dataTable.Columns.Add(new DataColumn("DisplayMember"));
      dataTable.Columns.Add(new DataColumn("Deleted"));
      int num1 = From;
      int num2 = To;
      int num3 = num1;
      while (num3 <= num2)
      {
        dataTable.Rows.Add((object[]) new string[3]
        {
          Conversions.ToString(num3),
          Conversions.ToString(num3),
          Conversions.ToString(0)
        });
        checked { ++num3; }
      }
      return dataTable;
    }

    public static DataTable CreditStatus
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Awaiting Part Return",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Part Returned to Supplier",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Credit Req Sent to Supplier",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Credit Received",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Sent To Sage",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(6),
              "Credit Req Cancelled By Engineer",
              "0"
            }
          }
        };
      }
    }

    public static DataTable JOWStatus
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              Enums.JobOfWorkStatus.Open.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              Enums.JobOfWorkStatus.Closed.ToString(),
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              Enums.JobOfWorkStatus.Complete.ToString(),
              "0"
            }
          }
        };
      }
    }

    public static DataTable LetterType
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]{ "1", "Letter 1", "0" },
            (object[]) new string[3]{ "2", "Letter 2", "0" },
            (object[]) new string[3]{ "3", "Letter 3", "0" }
          }
        };
      }
    }

    public static DataTable Salutation
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]{ "Mr", "Mr", "0" },
            (object[]) new string[3]{ "Mrs", "Mrs", "0" },
            (object[]) new string[3]{ "Miss", "Miss", "0" },
            (object[]) new string[3]{ "Ms", "Ms", "0" },
            (object[]) new string[3]{ "Dr", "Dr", "0" },
            (object[]) new string[3]{ "Lord", "Lord", "0" },
            (object[]) new string[3]{ "Lady", "Lady", "0" },
            (object[]) new string[3]
            {
              "Prof.",
              "Prof.",
              "0"
            },
            (object[]) new string[3]{ "Sir", "Sir", "0" },
            (object[]) new string[3]{ "Rev.", "Rev.", "0" },
            (object[]) new string[3]{ "Void", "Void", "0" },
            (object[]) new string[3]{ "Mx", "Mx", "0" },
            (object[]) new string[3]
            {
              "Company Name",
              "Company Name",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ServExpiry
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(-1),
              "Expired",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(7),
              "1 Week",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(14),
              "2 Weeks",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(21),
              "3 Weeks",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(28),
              "4 Weeks",
              "0"
            }
          }
        };
      }
    }

    public static DataTable Surveyor
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Install Surveyor",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Breakdown Engineer",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "None",
              "0"
            }
          }
        };
      }
    }

    public static DataTable JobWizTerms
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Contract",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "OTI",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "POC",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "FOC",
              "0"
            }
          }
        };
      }
    }

    public static DataTable ComoDateType
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Expiry",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Manufactured",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "N/A",
              "0"
            }
          }
        };
      }
    }

    public static DataTable JobWizAdditional
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Service At Same Time As Breakdown",
              "0"
            }
          }
        };
      }
    }

    public static DataTable JobWizTypesOfWork
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Heating",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Commercial",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Plumbing",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Electrical",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Building Maintenance / Pest",
              "0"
            }
          }
        };
      }
    }

    public static DataTable JobWizServTypesOfWork
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Standard Service",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "Mutual Exchange",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Reinstate",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Void Check",
              "0"
            }
          }
        };
      }
    }

    public static DataTable FleetVanContractProcurementMethod
    {
      get
      {
        return new DataTable()
        {
          Columns = {
            new DataColumn("ValueMember"),
            new DataColumn("DisplayMember"),
            new DataColumn("Deleted")
          },
          Rows = {
            (object[]) new string[3]
            {
              Conversions.ToString(1),
              "Contract Hire",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(2),
              "HP/.Depn",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(3),
              "Hire",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(4),
              "Owned",
              "0"
            },
            (object[]) new string[3]
            {
              Conversions.ToString(5),
              "Leased",
              "0"
            }
          }
        };
      }
    }

    public static DataTable SupplierIDList
    {
      get
      {
        DataTable dataTable = new DataTable();
        return App.DB.Supplier.Supplier_GetAll().ToTable();
      }
    }
  }
}
