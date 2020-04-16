// Decompiled with JetBrains decompiler
// Type: FSM.Navigation
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Drawing;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class Navigation
  {
    public static bool Navigate(Enums.MenuTypes MenuType)
    {
      if (App.IsLowResolution)
      {
        App.MainForm.pnlMiddle.Size = new Size(173, App.MainForm.Height);
        App.MainForm.btnAddNew.Text = "Add";
      }
      else
      {
        App.MainForm.pnlMiddle.Size = new Size(347, App.MainForm.Height);
        App.MainForm.splitMiddleAndRight.Visible = false;
        App.MainForm.splitMiddleAndRight.Enabled = false;
        App.MainForm.btnAddNew.Width = App.MainForm.btnAddNew.MaximumSize.Width;
        App.MainForm.btnDelete.Width = App.MainForm.btnDelete.MaximumSize.Width;
        App.MainForm.btnExport.Width = App.MainForm.btnExport.MaximumSize.Width;
      }
      if (!Navigation.Close_Middle())
        return false;
      Form[] mdiChildren = App.MainForm.MdiChildren;
      int index = 0;
      while (index < mdiChildren.Length)
      {
        mdiChildren[index].Dispose();
        checked { ++index; }
      }
      Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.None;
      switch (MenuType)
      {
        case Enums.MenuTypes.NONE:
          ssm = Enums.SecuritySystemModules.None;
          break;
        case Enums.MenuTypes.Customers:
          ssm = Enums.SecuritySystemModules.Customers;
          break;
        case Enums.MenuTypes.Spares:
          ssm = Enums.SecuritySystemModules.Spares;
          break;
        case Enums.MenuTypes.Staff:
          ssm = Enums.SecuritySystemModules.Staff;
          break;
        case Enums.MenuTypes.Jobs:
          ssm = Enums.SecuritySystemModules.Jobs;
          break;
        case Enums.MenuTypes.Invoicing:
          ssm = Enums.SecuritySystemModules.Invoicing;
          break;
        case Enums.MenuTypes.Reports:
          ssm = Enums.SecuritySystemModules.Reports;
          break;
        case Enums.MenuTypes.Setup:
          ssm = Enums.SecuritySystemModules.Setup;
          break;
        case Enums.MenuTypes.FleetVan:
          ssm = Enums.SecuritySystemModules.None;
          break;
      }
      if (!App.loggedInUser.HasAccessToModule(ssm))
        throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      App.MainForm.SelectedMenu = MenuType;
      switch (MenuType)
      {
        case Enums.MenuTypes.NONE:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
          App.MainForm.MenuBar.btnSpares.IAmSelected = false;
          App.MainForm.MenuBar.btnStaff.IAmSelected = false;
          App.MainForm.MenuBar.btnJobs.IAmSelected = false;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
          App.MainForm.MenuBar.btnReports.IAmSelected = false;
          App.MainForm.MenuBar.btnVan.IAmSelected = false;
          App.MainForm.MenuBar.lblTitle.Text = "HOME";
          break;
        case Enums.MenuTypes.Customers:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = true;
          App.MainForm.MenuBar.btnSpares.IAmSelected = false;
          App.MainForm.MenuBar.btnStaff.IAmSelected = false;
          App.MainForm.MenuBar.btnJobs.IAmSelected = false;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
          App.MainForm.MenuBar.btnReports.IAmSelected = false;
          App.MainForm.MenuBar.btnVan.IAmSelected = false;
          App.MainForm.MenuBar.lblTitle.Text = "CUSTOMERS";
          break;
        case Enums.MenuTypes.Spares:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
          App.MainForm.MenuBar.btnSpares.IAmSelected = true;
          App.MainForm.MenuBar.btnStaff.IAmSelected = false;
          App.MainForm.MenuBar.btnJobs.IAmSelected = false;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
          App.MainForm.MenuBar.btnReports.IAmSelected = false;
          App.MainForm.MenuBar.btnVan.IAmSelected = false;
          App.MainForm.MenuBar.lblTitle.Text = "SPARES";
          break;
        case Enums.MenuTypes.Staff:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
          App.MainForm.MenuBar.btnSpares.IAmSelected = false;
          App.MainForm.MenuBar.btnStaff.IAmSelected = true;
          App.MainForm.MenuBar.btnJobs.IAmSelected = false;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
          App.MainForm.MenuBar.btnReports.IAmSelected = false;
          App.MainForm.MenuBar.btnVan.IAmSelected = false;
          App.MainForm.MenuBar.lblTitle.Text = "STAFF";
          break;
        case Enums.MenuTypes.Jobs:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
          App.MainForm.MenuBar.btnSpares.IAmSelected = false;
          App.MainForm.MenuBar.btnStaff.IAmSelected = false;
          App.MainForm.MenuBar.btnJobs.IAmSelected = true;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
          App.MainForm.MenuBar.btnReports.IAmSelected = false;
          App.MainForm.MenuBar.btnVan.IAmSelected = false;
          App.MainForm.MenuBar.lblTitle.Text = "JOBS";
          break;
        case Enums.MenuTypes.Invoicing:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
          App.MainForm.MenuBar.btnSpares.IAmSelected = false;
          App.MainForm.MenuBar.btnStaff.IAmSelected = false;
          App.MainForm.MenuBar.btnJobs.IAmSelected = false;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = true;
          App.MainForm.MenuBar.btnReports.IAmSelected = false;
          App.MainForm.MenuBar.btnVan.IAmSelected = false;
          App.MainForm.MenuBar.lblTitle.Text = "INVOICING";
          break;
        case Enums.MenuTypes.Reports:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
          App.MainForm.MenuBar.btnSpares.IAmSelected = false;
          App.MainForm.MenuBar.btnStaff.IAmSelected = false;
          App.MainForm.MenuBar.btnJobs.IAmSelected = false;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
          App.MainForm.MenuBar.btnReports.IAmSelected = true;
          App.MainForm.MenuBar.btnVan.IAmSelected = false;
          App.MainForm.MenuBar.lblTitle.Text = "REPORTS";
          break;
        case Enums.MenuTypes.Setup:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
          App.MainForm.MenuBar.btnSpares.IAmSelected = false;
          App.MainForm.MenuBar.btnStaff.IAmSelected = false;
          App.MainForm.MenuBar.btnJobs.IAmSelected = false;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
          App.MainForm.MenuBar.btnReports.IAmSelected = false;
          App.MainForm.MenuBar.btnVan.IAmSelected = false;
          App.MainForm.MenuBar.lblTitle.Text = "SETUP";
          break;
        case Enums.MenuTypes.FleetVan:
          App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
          App.MainForm.MenuBar.btnSpares.IAmSelected = false;
          App.MainForm.MenuBar.btnStaff.IAmSelected = false;
          App.MainForm.MenuBar.btnJobs.IAmSelected = false;
          App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
          App.MainForm.MenuBar.btnReports.IAmSelected = false;
          App.MainForm.MenuBar.btnVan.IAmSelected = true;
          App.MainForm.MenuBar.lblTitle.Text = "FLEET";
          break;
      }
      Navigation.Set_Search_Control(MenuType);
      Navigation.Set_Sub_Menu_Control(MenuType);
      App.CurrentCustomerID = 0;
      App.CurrentPropertyID = 0;
      return true;
    }

    private static void Set_Search_Control(Enums.MenuTypes MenuType)
    {
      App.MainForm.MenuBar.pnlSearch.Controls.Clear();
      ISearchControl searchControl = (ISearchControl) null;
      switch (MenuType)
      {
        case Enums.MenuTypes.NONE:
          App.MainForm.MenuBar.pnlSearch.Height = 1;
          break;
        case Enums.MenuTypes.Customers:
          searchControl = (ISearchControl) new UCSearchCustomers();
          App.MainForm.MenuBar.pnlSearch.Height = ((Control) searchControl).Height;
          goto case Enums.MenuTypes.Jobs;
        case Enums.MenuTypes.Spares:
          searchControl = (ISearchControl) new UCSearchSpares();
          App.MainForm.MenuBar.pnlSearch.Height = ((Control) searchControl).Height;
          goto case Enums.MenuTypes.Jobs;
        case Enums.MenuTypes.Staff:
          searchControl = (ISearchControl) new UCSearchStaff();
          App.MainForm.MenuBar.pnlSearch.Height = ((Control) searchControl).Height;
          goto case Enums.MenuTypes.Jobs;
        case Enums.MenuTypes.Jobs:
          App.MainForm.MenuBar.pnlSearch.Controls.Add((Control) searchControl);
          break;
        case Enums.MenuTypes.Setup:
          App.MainForm.MenuBar.pnlSearch.Height = 1;
          break;
        case Enums.MenuTypes.FleetVan:
          searchControl = (ISearchControl) new UCSearchFleetVan();
          App.MainForm.MenuBar.pnlSearch.Height = ((Control) searchControl).Height;
          goto case Enums.MenuTypes.Jobs;
        default:
          App.MainForm.MenuBar.pnlSearch.Height = 1;
          break;
      }
    }

    private static void Set_Sub_Menu_Control(Enums.MenuTypes MenuType)
    {
      App.MainForm.MenuBar.pnlSubMenu.Controls.Clear();
      switch (MenuType)
      {
        case Enums.MenuTypes.Customers:
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Customers", Enums.TableNames.tblCustomer));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Sites", Enums.TableNames.tblSite));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Appliances", Enums.TableNames.tblAsset));
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.JobWizard))
            break;
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Job Wizard", "FRMJobWizard"));
          break;
        case Enums.MenuTypes.Spares:
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Warehouses", Enums.TableNames.tblWarehouse));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Suppliers", Enums.TableNames.tblSupplier));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Products", Enums.TableNames.tblProduct));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Part Packs", Enums.TableNames.tblPartPack));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Place Order", "FRMOrder"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Orders", "FRMOrderManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Stock Take", "FRMStockTake"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("I.P.T", "FRMStockMove"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Parts To Be Credited", "FRMPartsToBeCreditedManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("PO Invoice Authorisation", "FRMPOInvoiceAuthorisation"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Add Types, Makes or Models", "FRMTypeMakeModel"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Stock Profiles", Enums.TableNames.tblvan2));
          if (App.IsGasway)
            App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("PO Invoice Importer", "FRMPartsInvoiceImport"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("PO Invoice Importer Mk2", "FRMSupplierInvoiceImporter"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Equipment Used Report", "FRMEquipmentUsed"));
          break;
        case Enums.MenuTypes.Staff:
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Users", "FRMUsers"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Equipment", Enums.TableNames.tblEquipment));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Engineers", Enums.TableNames.tblEngineer));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Subcontractors", Enums.TableNames.tblSubcontractor));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All User Quals", Enums.TableNames.tblUserQualification));
          break;
        case Enums.MenuTypes.Jobs:
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Job Manager", "FRMJobManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Visit Manager", "FRMVM"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Quote Manager", "FRMQuoteManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Contract Manager", "FRMContractManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Engineer Timesheets", "FRMEngineerTimesheets"));
          if (App.IsGasway)
            App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Letter Manager", "FRMLetterManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Letter Manager MK3", "FRMLetterManagerMK3"));
          if (App.IsGasway)
            App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Batch GSR Print", "FRMBatchGSRPrint"));
          if (App.IsGasway)
            App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("EICR Job Importer", "FRMJobImport"));
          if (App.IsGasway)
            App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("EICR Job Import Manager", "FRMJobImportManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Bulk Job Creator", "FRMBulkJobCreation"));
          break;
        case Enums.MenuTypes.Invoicing:
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Ready To Be Invoiced", "FRMInvoiceManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Invoiced Manager", "FRMInvoicedManager"));
          break;
        case Enums.MenuTypes.Reports:
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Engineer Timesheet Rep.", "FRMEngineerTimesheetReport"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Products Last GSR Rep.", "FRMLastGSRReport"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Stock Used", "FRMStockUsed"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Parts Used Report", "FRMPartsUsed"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("I.P.T Audit", "FRMStockMoved"));
          break;
        case Enums.MenuTypes.Setup:
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Picklists / Settings", "FRMManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Checklist Manager", "FRMCheckListManager"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("System History", "FRMHistory"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Override Password", "FRMChangeOverridePassword"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Override Password_Service", "FRMChangeOverridePassword_Service"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Schedule Of Rates", "FRMSystemScheduleOfRate"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Engineer Roles", "FRMEngineerRoles"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Part Categories", "FRMPartCategories"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("VAT Rates", "FRMVATRates"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Standard Sentences", "FRMStandardSentences"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Job Locks", "FRMJobLocks"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Parts Importer", "FRMPartsImport"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Job Skills", "FRMJobSkills"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Customer SOR Job Type Default", "FRMCustomerSORJobType"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Sites Importer", "FRMSitesImport"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Scheduler Settings", "FRMSchedulerSettings"));
          break;
        case Enums.MenuTypes.FleetVan:
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Vans", Enums.TableNames.tblFleetVan));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Returned Vans", Enums.TableNames.tblFleetReturnedVans));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Van Types", Enums.TableNames.tblFleetVanType));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Equipments", Enums.TableNames.tblFleetEquipment));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Show All Service Centres", Enums.TableNames.tblFleetGarage));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Van Mileage Importer", "FRMFleetVanImporter"));
          App.MainForm.MenuBar.pnlSubMenu.Controls.Add((Control) new SubMenuNode("Van Manager", "FRMFleetVanManager"));
          break;
      }
    }

    public static void Sub_Menu(SubMenuNode butttonClicked)
    {
      if (butttonClicked == null)
        return;
      Navigation.ResponsiveUI();
      if ((uint) butttonClicked.FormToOpen.Trim().Length > 0U && Navigation.Close_Middle())
      {
        Form[] mdiChildren = App.MainForm.MdiChildren;
        int index = 0;
        while (index < mdiChildren.Length)
        {
          mdiChildren[index].Dispose();
          checked { ++index; }
        }
        string lower = butttonClicked.FormToOpen.Trim().ToLower();
        if (Operators.CompareString(lower, "FRMBatchGSRPrint".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMBatchGSRPrint), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMPartsToBeCreditedManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMPartsToBeCreditedManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMManager".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Compliance))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMManager), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMJobManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMJobManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMUsers".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMUsers), false, new object[1]
          {
            (object) string.Empty
          }, false);
        }
        else if (Operators.CompareString(lower, "FRMChangeOverridePassword".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMChangeOverridePassword), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMChangeOverridePassword_Service".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMChangeOverridePassword_Service), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMHistory".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMHistory), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMStockTake".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.StockTake))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMStockTake), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMCheckListManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMCheckListManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMTypeMakeModel".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMTypeMakeModel), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMOrder".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CreatePO))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMOrder), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMOrderManager".ToLower(), false) == 0)
        {
          List<Enums.SecuritySystemModules> ssm = new List<Enums.SecuritySystemModules>()
          {
            Enums.SecuritySystemModules.CreatePO,
            Enums.SecuritySystemModules.EditPO
          };
          if (!App.loggedInUser.HasAccessToMulitpleModules(ssm))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMOrderManager), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMJobManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMJobManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMJobImport".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMJobImport), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMJobImportManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMJobImportManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMBulkJobCreation".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMBulkJobCreation), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMJobLocks".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.FSMAdmin))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMJobLocks), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMVM".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMVisitManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMQuoteManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMQuoteManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMContractManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMContractManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMSystemScheduleOfRate".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Compliance))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMSystemScheduleOfRate), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMEngineerRoles".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMEngineerRole), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMInvoiceManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMInvoiceManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMInvoicedManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMInvoicedManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMJobSkills".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Compliance))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMJobSkills), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMCustomerSORJobType".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Compliance))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMCustomerSORJobType), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMPartCategories".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMPartCategories), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMEngineerTimesheetReport".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMEngineerTimesheetReport), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMDirectDebitReport".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMDirectDebitReport), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMVATRates".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMVATRates), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMLastGSRReport".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMLastGSRReport), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMStandardSentences".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMStandardSentences), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMStockValuation".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMStockValuation), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMStockCategoryValuation".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMStockCategoryValuation), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMStockUsed".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMStockUsed), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMStockMove".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMStockMove), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMStockReplenishment".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMStockReplenishment), false, new object[1]
          {
            (object) true
          }, false);
        else if (Operators.CompareString(lower, "FRMPartsUsed".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMPartsUsed), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMStockMoved".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMStockMoved), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMEngineerTimesheets".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMEngineerTimesheets), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMPartsImport".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.EditParts))
            throw new SecurityException("You do not have the necessary security permissions.");
          App.ShowForm(typeof (FRMPartsImport), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMPartsInvoiceImport".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POImporter))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMPartsInvoiceImport), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMSupplierInvoiceImporter".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POImporter))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMSupplierInvoiceImporter), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMPOInvoiceAuthorisation".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.POAuthorisation))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMPOInvoiceAuthorisation), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMSitesImport".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMImport), false, new object[1]
          {
            (object) "Sites"
          }, false);
        else if (Operators.CompareString(lower, "FRMLetterManager".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMLetterManager), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMLetterManagerMK3".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMLetterManagerMK3), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMFleetVanImporter".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Fleet))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMFleetVanImporter), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "FRMFleetVanManager".ToLower(), false) == 0)
        {
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Fleet))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMFleetVanManager), false, (object[]) null, false);
        }
        else if (Operators.CompareString(lower, "UsePanels".ToLower(), false) == 0)
        {
          switch (butttonClicked.TableToSearch)
          {
            case Enums.TableNames.tblCustomer:
              App.CurrentCustomerID = 0;
              App.MainForm.SetSearchResults(App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID), Enums.PageViewing.Customer, false, false, "");
              break;
            case Enums.TableNames.tblPart:
              App.MainForm.SetSearchResults(App.DB.Part.Part_GetAll(false), Enums.PageViewing.Part, false, false, "");
              break;
            case Enums.TableNames.tblProduct:
              App.MainForm.SetSearchResults(App.DB.Product.Product_GetAll(), Enums.PageViewing.Product, false, false, "");
              break;
            case Enums.TableNames.tblSupplier:
              App.MainForm.SetSearchResults(App.DB.Supplier.Supplier_GetAll(), Enums.PageViewing.Supplier, false, false, "");
              break;
            case Enums.TableNames.tblAsset:
              if (App.CurrentPropertyID == 0)
              {
                App.MainForm.SetSearchResults(App.DB.Asset.Asset_GetAll(App.loggedInUser.UserID), Enums.PageViewing.Asset, false, false, "");
                break;
              }
              Site site1 = new Site();
              Site site2 = App.DB.Sites.Get((object) App.CurrentPropertyID, SiteSQL.GetBy.SiteId, (object) null);
              FSM.Entity.Customers.Customer customer1 = new FSM.Entity.Customers.Customer();
              FSM.Entity.Customers.Customer customer2 = App.DB.Customer.Customer_Get(site2.CustomerID);
              App.MainForm.SetSearchResults(App.DB.Asset.Asset_GetForSite(App.CurrentPropertyID), Enums.PageViewing.Asset, false, false, site2.Address1 + ", " + site2.Postcode + " (" + customer2.AccountNumber + ")");
              break;
            case Enums.TableNames.tblEngineer:
              App.MainForm.SetSearchResults(App.DB.Engineer.Engineer_GetAll_NoSub(), Enums.PageViewing.Engineer, false, false, "");
              break;
            case Enums.TableNames.tblVan:
              App.MainForm.SetSearchResults(App.DB.Van.Van_GetAll(true), Enums.PageViewing.Van, false, false, "");
              break;
            case Enums.TableNames.tblSite:
              App.CurrentPropertyID = 0;
              if (App.CurrentCustomerID == 0)
              {
                App.MainForm.SetSearchResults(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, false, false, "");
                break;
              }
              FSM.Entity.Customers.Customer customer3 = new FSM.Entity.Customers.Customer();
              FSM.Entity.Customers.Customer customer4 = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
              App.MainForm.SetSearchResults(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, false, false, customer4.Name + " (" + customer4.AccountNumber + ")");
              break;
            case Enums.TableNames.tblSubcontractor:
              if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Subcontractor))
                throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
              App.MainForm.SetSearchResults(App.DB.SubContractor.Subcontractor_GetAll(), Enums.PageViewing.Subcontractor, false, false, "");
              break;
            case Enums.TableNames.tblWarehouse:
              App.MainForm.SetSearchResults(App.DB.Warehouse.Warehouse_GetAll(), Enums.PageViewing.Warehouse, false, false, "");
              break;
            case Enums.TableNames.tblvan2:
              App.MainForm.SetSearchResults(App.DB.Van.Van_GetAll(true), Enums.PageViewing.StockProfile, false, false, "");
              break;
            case Enums.TableNames.tblEquipment:
              App.MainForm.SetSearchResults(App.DB.Engineer.Equipment_GetAll(), Enums.PageViewing.Equipment, false, false, "");
              break;
            case Enums.TableNames.tblPartPack:
              App.MainForm.SetSearchResults(App.DB.Part.PartPack_GetAll(), Enums.PageViewing.PartPack, false, false, "");
              break;
            case Enums.TableNames.tblFleetVan:
              App.MainForm.SetSearchResults(App.DB.FleetVan.GetAll(), Enums.PageViewing.FleetVan, false, false, "");
              break;
            case Enums.TableNames.tblFleetVanType:
              App.MainForm.SetSearchResults(App.DB.FleetVanType.GetAll(), Enums.PageViewing.FleetVanType, false, false, "");
              break;
            case Enums.TableNames.tblFleetEquipment:
              App.MainForm.SetSearchResults(App.DB.FleetEquipment.GetAll(), Enums.PageViewing.FleetEquipment, false, false, "");
              break;
            case Enums.TableNames.tblFleetGarage:
              App.MainForm.SetSearchResults(App.DB.Sites.GetAll_FleetGarage(App.loggedInUser.UserID), Enums.PageViewing.Property, false, false, "");
              break;
            case Enums.TableNames.tblFleetReturnedVans:
              App.MainForm.SetSearchResults(App.DB.FleetVan.GetAll_Returned(), Enums.PageViewing.FleetVan, false, false, "");
              break;
            case Enums.TableNames.tblUserQualification:
              List<Enums.SecuritySystemModules> securitySystemModulesList = new List<Enums.SecuritySystemModules>()
              {
                Enums.SecuritySystemModules.Compliance,
                Enums.SecuritySystemModules.IT
              };
              App.MainForm.SetSearchResults(App.DB.User.GetAll_NoEngineers(), Enums.PageViewing.UserQuals, false, false, "");
              break;
          }
        }
        else if (Operators.CompareString(lower, "FRMBatchVisitCosts".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMBatchVisitCosts), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMJobWizard".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMJobWizard), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMEquipmentUsed".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMEquipmentUsed), false, (object[]) null, false);
        else if (Operators.CompareString(lower, "FRMSchedulerSettings".ToLower(), false) == 0)
          App.ShowForm(typeof (FRMSchedulerSettings), false, (object[]) null, false);
      }
    }

    public static bool Close_Middle()
    {
      if (!Navigation.Close_Right())
        return false;
      App.MainForm.pnlMiddle.Visible = false;
      return true;
    }

    public static bool Close_Right()
    {
      if (!App.MainForm.pnlRight.Visible)
        return true;
      if (App.ControlChanged)
      {
        if (App.ShowMessage("Would you like to save before data pane closes? (Any changes made will be lost)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          if (!((IUserControl) App.MainForm.pnlContent.Controls[0]).Save())
            return false;
          App.MainForm.pnlRight.Visible = false;
          App.MainForm.pnlContent.Controls.Clear();
          return true;
        }
        App.MainForm.pnlRight.Visible = false;
        App.MainForm.pnlContent.Controls.Clear();
        return true;
      }
      App.MainForm.pnlRight.Visible = false;
      App.MainForm.pnlContent.Controls.Clear();
      return true;
    }

    public static void Show_Right()
    {
      if (Helper.MakeIntegerValid((object) App.MainForm?.pnlContent.Controls.Count) == 0)
        return;
      App.MainForm.pnlRight.Visible = false;
      int x = checked (App.MainForm.pnlLeft.Width + App.MainForm.pnlMiddle.Width + 7);
      int y = App.MainForm.pnlMiddle.Location.Y;
      App.MainForm.pnlRight.Location = new System.Drawing.Point(x, y);
      App.MainForm.pnlRight.Size = new Size(checked (App.MainForm.Width - x - 10), App.MainForm.pnlMiddle.Height);
      App.MainForm.pnlRight.Visible = true;
    }

    public static void ResponsiveUI()
    {
      if (App.MainForm.pnlMiddle.Width < 200)
        App.MainForm.btnDelete.Text = "Del";
      else
        App.MainForm.btnDelete.Text = "Delete";
    }
  }
}
