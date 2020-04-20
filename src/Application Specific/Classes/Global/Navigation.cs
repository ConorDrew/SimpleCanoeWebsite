using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class Navigation
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static bool Navigate(Entity.Sys.Enums.MenuTypes MenuType)
        {
            if (App.IsLowResolution)
            {
                App.MainForm.pnlMiddle.Size = new Size(Entity.Sys.Consts.MidPanelSmallSize, App.MainForm.Height);
                App.MainForm.btnAddNew.Text = "Add";
            }
            else
            {
                App.MainForm.pnlMiddle.Size = new Size(Entity.Sys.Consts.MidPanelLargeSize, App.MainForm.Height);
                App.MainForm.splitMiddleAndRight.Visible = false;
                App.MainForm.splitMiddleAndRight.Enabled = false;
                App.MainForm.btnAddNew.Width = App.MainForm.btnAddNew.MaximumSize.Width;
                App.MainForm.btnDelete.Width = App.MainForm.btnDelete.MaximumSize.Width;
                App.MainForm.btnExport.Width = App.MainForm.btnExport.MaximumSize.Width;
            }

            if (!Close_Middle())
            {
                return false;
            }

            foreach (Form form in App.MainForm.MdiChildren)
                form.Dispose();
            var ssm = Entity.Sys.Enums.SecuritySystemModules.None;
            switch (MenuType)
            {
                case Entity.Sys.Enums.MenuTypes.NONE:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.None;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Customers:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.Customers;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Spares:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.Spares;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Staff:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.Staff;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Jobs:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.Jobs;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Invoicing:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.Invoicing;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Reports:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.Reports;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Setup:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.Setup;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.FleetVan:
                    {
                        ssm = Entity.Sys.Enums.SecuritySystemModules.None;
                        break;
                    }
            }

            if (App.loggedInUser.HasAccessToModule(ssm) == false)
            {
                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            App.MainForm.SelectedMenu = MenuType;
            switch (MenuType)
            {
                case Entity.Sys.Enums.MenuTypes.NONE:
                    {
                        App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
                        App.MainForm.MenuBar.btnSpares.IAmSelected = false;
                        App.MainForm.MenuBar.btnStaff.IAmSelected = false;
                        App.MainForm.MenuBar.btnJobs.IAmSelected = false;
                        App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
                        App.MainForm.MenuBar.btnReports.IAmSelected = false;
                        App.MainForm.MenuBar.btnVan.IAmSelected = false;
                        App.MainForm.MenuBar.lblTitle.Text = "HOME";
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Customers:
                    {
                        App.MainForm.MenuBar.btnCustomer.IAmSelected = true;
                        App.MainForm.MenuBar.btnSpares.IAmSelected = false;
                        App.MainForm.MenuBar.btnStaff.IAmSelected = false;
                        App.MainForm.MenuBar.btnJobs.IAmSelected = false;
                        App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
                        App.MainForm.MenuBar.btnReports.IAmSelected = false;
                        App.MainForm.MenuBar.btnVan.IAmSelected = false;
                        App.MainForm.MenuBar.lblTitle.Text = "CUSTOMERS";
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Spares:
                    {
                        App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
                        App.MainForm.MenuBar.btnSpares.IAmSelected = true;
                        App.MainForm.MenuBar.btnStaff.IAmSelected = false;
                        App.MainForm.MenuBar.btnJobs.IAmSelected = false;
                        App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
                        App.MainForm.MenuBar.btnReports.IAmSelected = false;
                        App.MainForm.MenuBar.btnVan.IAmSelected = false;
                        App.MainForm.MenuBar.lblTitle.Text = "SPARES";
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Staff:
                    {
                        App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
                        App.MainForm.MenuBar.btnSpares.IAmSelected = false;
                        App.MainForm.MenuBar.btnStaff.IAmSelected = true;
                        App.MainForm.MenuBar.btnJobs.IAmSelected = false;
                        App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
                        App.MainForm.MenuBar.btnReports.IAmSelected = false;
                        App.MainForm.MenuBar.btnVan.IAmSelected = false;
                        App.MainForm.MenuBar.lblTitle.Text = "STAFF";
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Jobs:
                    {
                        App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
                        App.MainForm.MenuBar.btnSpares.IAmSelected = false;
                        App.MainForm.MenuBar.btnStaff.IAmSelected = false;
                        App.MainForm.MenuBar.btnJobs.IAmSelected = true;
                        App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
                        App.MainForm.MenuBar.btnReports.IAmSelected = false;
                        App.MainForm.MenuBar.btnVan.IAmSelected = false;
                        App.MainForm.MenuBar.lblTitle.Text = "JOBS";
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Invoicing:
                    {
                        App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
                        App.MainForm.MenuBar.btnSpares.IAmSelected = false;
                        App.MainForm.MenuBar.btnStaff.IAmSelected = false;
                        App.MainForm.MenuBar.btnJobs.IAmSelected = false;
                        App.MainForm.MenuBar.btnInvoicing.IAmSelected = true;
                        App.MainForm.MenuBar.btnReports.IAmSelected = false;
                        App.MainForm.MenuBar.btnVan.IAmSelected = false;
                        App.MainForm.MenuBar.lblTitle.Text = "INVOICING";
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Reports:
                    {
                        App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
                        App.MainForm.MenuBar.btnSpares.IAmSelected = false;
                        App.MainForm.MenuBar.btnStaff.IAmSelected = false;
                        App.MainForm.MenuBar.btnJobs.IAmSelected = false;
                        App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
                        App.MainForm.MenuBar.btnReports.IAmSelected = true;
                        App.MainForm.MenuBar.btnVan.IAmSelected = false;
                        App.MainForm.MenuBar.lblTitle.Text = "REPORTS";
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.FleetVan:
                    {
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

                case Entity.Sys.Enums.MenuTypes.Setup:
                    {
                        App.MainForm.MenuBar.btnCustomer.IAmSelected = false;
                        App.MainForm.MenuBar.btnSpares.IAmSelected = false;
                        App.MainForm.MenuBar.btnStaff.IAmSelected = false;
                        App.MainForm.MenuBar.btnJobs.IAmSelected = false;
                        App.MainForm.MenuBar.btnInvoicing.IAmSelected = false;
                        App.MainForm.MenuBar.btnReports.IAmSelected = false;
                        App.MainForm.MenuBar.btnVan.IAmSelected = false;
                        App.MainForm.MenuBar.lblTitle.Text = "SETUP";
                        break;
                    }
            }

            Set_Search_Control(MenuType);
            Set_Sub_Menu_Control(MenuType);
            App.CurrentCustomerID = 0;
            App.CurrentPropertyID = 0;
            return true;
        }

        private static void Set_Search_Control(Entity.Sys.Enums.MenuTypes MenuType)
        {
            App.MainForm.MenuBar.pnlSearch.Controls.Clear();
            ISearchControl ctrl = null;
            switch (MenuType)
            {
                case Entity.Sys.Enums.MenuTypes.NONE:
                    {
                        App.MainForm.MenuBar.pnlSearch.Height = 1;
                        return;
                    }

                case Entity.Sys.Enums.MenuTypes.Customers:
                    {
                        ctrl = new UCSearchCustomers();
                        App.MainForm.MenuBar.pnlSearch.Height = ((UCSearchCustomers)ctrl).Height;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Spares:
                    {
                        ctrl = new UCSearchSpares();
                        App.MainForm.MenuBar.pnlSearch.Height = ((UCSearchSpares)ctrl).Height;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Staff:
                    {
                        ctrl = new UCSearchStaff();
                        App.MainForm.MenuBar.pnlSearch.Height = ((UCSearchStaff)ctrl).Height;
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Setup:
                    {
                        // ADD NO CONTROL
                        App.MainForm.MenuBar.pnlSearch.Height = 1;
                        return;
                    }

                case Entity.Sys.Enums.MenuTypes.Jobs:
                    {
                        break;
                    }
                // ctrl = New UCSearchJobs
                // MainForm.MenuBar.pnlSearch.Height = CType(ctrl, UCSearchJobs).Height
                case Entity.Sys.Enums.MenuTypes.FleetVan:
                    {
                        ctrl = new UCSearchFleetVan();
                        App.MainForm.MenuBar.pnlSearch.Height = ((UCSearchFleetVan)ctrl).Height;
                        break;
                    }

                default:
                    {
                        App.MainForm.MenuBar.pnlSearch.Height = 1;
                        return;
                    }
            }

            App.MainForm.MenuBar.pnlSearch.Controls.Add((Control)ctrl);
        }

        private static void Set_Sub_Menu_Control(Entity.Sys.Enums.MenuTypes MenuType)
        {
            App.MainForm.MenuBar.pnlSubMenu.Controls.Clear();
            switch (MenuType)
            {
                case Entity.Sys.Enums.MenuTypes.NONE:
                    {
                        break;
                    }
                // DO NOTHING
                case Entity.Sys.Enums.MenuTypes.Customers:
                    {
                        // CUSTOMERS / SITES / ASSETS MUST BE ADDED 1st, 2nd and 3rd - IF NOT, TELL TONY BENNETT
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Customers", Entity.Sys.Enums.TableNames.tblCustomer));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Sites", Entity.Sys.Enums.TableNames.tblSite));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Appliances", Entity.Sys.Enums.TableNames.tblAsset));
                        if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.JobWizard))
                        {
                            App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Job Wizard", "FRMJobWizard"));
                        }

                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Spares:
                    {
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Warehouses", Entity.Sys.Enums.TableNames.tblWarehouse));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Suppliers", Entity.Sys.Enums.TableNames.tblSupplier));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Products", Entity.Sys.Enums.TableNames.tblProduct));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Part Packs", Entity.Sys.Enums.TableNames.tblPartPack));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Place Order", "FRMOrder"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Orders", "FRMOrderManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Stock Take", "FRMStockTake"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("I.P.T", "FRMStockMove"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Parts To Be Credited", "FRMPartsToBeCreditedManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("PO Invoice Authorisation", "FRMPOInvoiceAuthorisation"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Add Types, Makes or Models", "FRMTypeMakeModel"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Stock Profiles", Entity.Sys.Enums.TableNames.tblvan2));
                        if (App.IsGasway)
                            App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("PO Invoice Importer", "FRMPartsInvoiceImport"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("PO Invoice Importer Mk2", "FRMSupplierInvoiceImporter"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Equipment Used Report", "FRMEquipmentUsed"));
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Staff:
                    {
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Users", "FRMUsers"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Equipment", Entity.Sys.Enums.TableNames.tblEquipment));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Engineers", Entity.Sys.Enums.TableNames.tblEngineer));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Subcontractors", Entity.Sys.Enums.TableNames.tblSubcontractor));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All User Quals", Entity.Sys.Enums.TableNames.tblUserQualification));
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Setup:
                    {
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Picklists / Settings", "FRMManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Checklist Manager", "FRMCheckListManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("System History", "FRMHistory"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Override Password", "FRMChangeOverridePassword"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Override Password_Service", "FRMChangeOverridePassword_Service"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Schedule Of Rates", "FRMSystemScheduleOfRate"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Engineer Roles", "FRMEngineerRoles"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Part Categories", "FRMPartCategories"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("VAT Rates", "FRMVATRates"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Standard Sentences", "FRMStandardSentences"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Job Locks", "FRMJobLocks"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Parts Importer", "FRMPartsImport"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Job Skills", "FRMJobSkills"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Customer SOR Job Type Default", "FRMCustomerSORJobType"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Sites Importer", "FRMSitesImport"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Scheduler Settings", "FRMSchedulerSettings"));
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Jobs:
                    {
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Job Manager", "FRMJobManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Visit Manager", "FRMVM"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Quote Manager", "FRMQuoteManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Contract Manager", "FRMContractManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Engineer Timesheets", "FRMEngineerTimesheets"));
                        if (App.IsGasway)
                            App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Letter Manager", "FRMLetterManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Letter Manager MK3", "FRMLetterManagerMK3"));
                        if (App.IsGasway)
                            App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Batch GSR Print", "FRMBatchGSRPrint"));
                        if (App.IsGasway)
                            App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("EICR Job Importer", "FRMJobImport"));
                        if (App.IsGasway)
                            App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("EICR Job Import Manager", "FRMJobImportManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Bulk Job Creator", "FRMBulkJobCreation"));
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Reports:
                    {
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Engineer Timesheet Rep.", "FRMEngineerTimesheetReport"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Products Last GSR Rep.", "FRMLastGSRReport"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Stock Used", "FRMStockUsed"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Parts Used Report", "FRMPartsUsed"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("I.P.T Audit", "FRMStockMoved"));
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.Invoicing:
                    {
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Ready To Be Invoiced", "FRMInvoiceManager"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Invoiced Manager", "FRMInvoicedManager"));
                        break;
                    }

                case Entity.Sys.Enums.MenuTypes.FleetVan:
                    {
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Vans", Entity.Sys.Enums.TableNames.tblFleetVan));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Returned Vans", Entity.Sys.Enums.TableNames.tblFleetReturnedVans));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Van Types", Entity.Sys.Enums.TableNames.tblFleetVanType));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Equipments", Entity.Sys.Enums.TableNames.tblFleetEquipment));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Show All Service Centres", Entity.Sys.Enums.TableNames.tblFleetGarage));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Van Mileage Importer", "FRMFleetVanImporter"));
                        App.MainForm.MenuBar.pnlSubMenu.Controls.Add(new SubMenuNode("Van Manager", "FRMFleetVanManager"));
                        break;
                    }
            }
        }

        public static void Sub_Menu(SubMenuNode butttonClicked)
        {
            if (butttonClicked is null)
            {
                return;
            }

            ResponsiveUI();
            if (!(butttonClicked.FormToOpen.Trim().Length == 0))
            {
                if (!Close_Middle())
                {
                    return;
                }

                foreach (Form form in App.MainForm.MdiChildren)
                    form.Dispose();
                var switchExpr = butttonClicked.FormToOpen.Trim().ToLower();
                switch (switchExpr)
                {
                    case var @case when @case == "FRMBatchGSRPrint".ToLower():
                        {
                            App.ShowForm(typeof(FRMBatchGSRPrint), false, null);
                            break;
                        }

                    case var case1 when case1 == "FRMPartsToBeCreditedManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMPartsToBeCreditedManager), false, null);
                            break;
                        }

                    case var case2 when case2 == "FRMManager".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance))
                            {
                                App.ShowForm(typeof(FRMManager), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case3 when case3 == "FRMJobManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMJobManager), false, null);
                            break;
                        }

                    case var case4 when case4 == "FRMUsers".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.IT))
                            {
                                App.ShowForm(typeof(FRMUsers), false, new object[] { string.Empty });
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case5 when case5 == "FRMChangeOverridePassword".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule())
                            {
                                App.ShowForm(typeof(FRMChangeOverridePassword), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case6 when case6 == "FRMChangeOverridePassword_Service".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule())
                            {
                                App.ShowForm(typeof(FRMChangeOverridePassword_Service), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case7 when case7 == "FRMHistory".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule())
                            {
                                App.ShowForm(typeof(FRMHistory), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case8 when case8 == "FRMStockTake".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.StockTake))
                            {
                                App.ShowForm(typeof(FRMStockTake), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case9 when case9 == "FRMCheckListManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMCheckListManager), false, null);
                            break;
                        }

                    case var case10 when case10 == "FRMTypeMakeModel".ToLower():
                        {
                            App.ShowForm(typeof(FRMTypeMakeModel), false, null);
                            break;
                        }

                    case var case11 when case11 == "FRMOrder".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.CreatePO) == false)
                            {
                                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }
                            else
                            {
                                App.ShowForm(typeof(FRMOrder), false, null);
                            }

                            break;
                        }

                    case var case12 when case12 == "FRMOrderManager".ToLower():
                        {
                            var _ssmList = new List<Entity.Sys.Enums.SecuritySystemModules>() { Entity.Sys.Enums.SecuritySystemModules.CreatePO, Entity.Sys.Enums.SecuritySystemModules.EditPO };
                            if (App.loggedInUser.HasAccessToMulitpleModules(_ssmList))
                            {
                                App.ShowForm(typeof(FRMOrderManager), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case13 when case13 == "FRMJobManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMJobManager), false, null);
                            break;
                        }

                    case var case14 when case14 == "FRMJobImport".ToLower():
                        {
                            App.ShowForm(typeof(FRMJobImport), false, null);
                            break;
                        }

                    case var case15 when case15 == "FRMJobImportManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMJobImportManager), false, null);
                            break;
                        }

                    case var case16 when case16 == "FRMBulkJobCreation".ToLower():
                        {
                            App.ShowForm(typeof(FRMBulkJobCreation), false, null);
                            break;
                        }

                    case var case17 when case17 == "FRMJobLocks".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule())
                            {
                                App.ShowForm(typeof(FRMJobLocks), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case18 when case18 == "FRMVM".ToLower():
                        {
                            App.ShowForm(typeof(FRMVisitManager), false, null);
                            break;
                        }

                    case var case19 when case19 == "FRMQuoteManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMQuoteManager), false, null);
                            break;
                        }

                    case var case20 when case20 == "FRMContractManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMContractManager), false, null);
                            break;
                        }

                    case var case21 when case21 == "FRMSystemScheduleOfRate".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance))
                            {
                                App.ShowForm(typeof(FRMSystemScheduleOfRate), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }
                    // Case "FRMTimeSlotRates".ToLower
                    // If loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance) Then
                    // ShowForm(GetType(FRMTimeSlotRates), False, Nothing)
                    // Else
                    // Dim msg As String = "You do not have the necessary security permissions."
                    // Throw New Security.SecurityException(msg)
                    // End If
                    case var case22 when case22 == "FRMEngineerRoles".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Finance))
                            {
                                App.ShowForm(typeof(FRMEngineerRole), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case23 when case23 == "FRMInvoiceManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMInvoiceManager), false, null);
                            break;
                        }

                    case var case24 when case24 == "FRMInvoicedManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMInvoicedManager), false, null);
                            break;
                        }

                    case var case25 when case25 == "FRMJobSkills".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance))
                            {
                                App.ShowForm(typeof(FRMJobSkills), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case26 when case26 == "FRMCustomerSORJobType".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Compliance))
                            {
                                App.ShowForm(typeof(FRMCustomerSORJobType), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case27 when case27 == "FRMPartCategories".ToLower():
                        {
                            App.ShowForm(typeof(FRMPartCategories), false, null);
                            break;
                        }

                    case var case28 when case28 == "FRMEngineerTimesheetReport".ToLower():
                        {
                            App.ShowForm(typeof(FRMEngineerTimesheetReport), false, null);
                            break;
                        }

                    case var case29 when case29 == "FRMDirectDebitReport".ToLower():
                        {
                            App.ShowForm(typeof(FRMDirectDebitReport), false, null);
                            break;
                        }

                    case var case30 when case30 == "FRMVATRates".ToLower():
                        {
                            App.ShowForm(typeof(FRMVATRates), false, null);
                            break;
                        }

                    case var case31 when case31 == "FRMLastGSRReport".ToLower():
                        {
                            App.ShowForm(typeof(FRMLastGSRReport), false, null);
                            break;
                        }

                    case var case32 when case32 == "FRMStandardSentences".ToLower():
                        {
                            App.ShowForm(typeof(FRMStandardSentences), false, null);
                            break;
                        }

                    case var case33 when case33 == "FRMStockValuation".ToLower():
                        {
                            App.ShowForm(typeof(FRMStockValuation), false, null);
                            break;
                        }

                    case var case34 when case34 == "FRMStockCategoryValuation".ToLower():
                        {
                            App.ShowForm(typeof(FRMStockCategoryValuation), false, null);
                            break;
                        }

                    case var case35 when case35 == "FRMStockUsed".ToLower():
                        {
                            App.ShowForm(typeof(FRMStockUsed), false, null);
                            break;
                        }

                    case var case36 when case36 == "FRMStockMove".ToLower():
                        {
                            App.ShowForm(typeof(FRMStockMove), false, null);
                            break;
                        }

                    case var case37 when case37 == "FRMStockReplenishment".ToLower():
                        {
                            App.ShowForm(typeof(FRMStockReplenishment), false, new object[] { true });
                            break;
                        }

                    case var case38 when case38 == "FRMPartsUsed".ToLower():
                        {
                            App.ShowForm(typeof(FRMPartsUsed), false, null);
                            break;
                        }

                    case var case39 when case39 == "FRMStockMoved".ToLower():
                        {
                            App.ShowForm(typeof(FRMStockMoved), false, null);
                            break;
                        }

                    case var case40 when case40 == "FRMEngineerTimesheets".ToLower():
                        {
                            App.ShowForm(typeof(FRMEngineerTimesheets), false, null);
                            break;
                        }

                    case var case41 when case41 == "FRMPartsImport".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.EditParts))
                            {
                                App.ShowForm(typeof(FRMPartsImport), false, null);
                            }
                            else
                            {
                                string msg = "You do not have the necessary security permissions.";
                                throw new System.Security.SecurityException(msg);
                            }

                            break;
                        }

                    case var case42 when case42 == "FRMPartsInvoiceImport".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.POImporter) == false)
                            {
                                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }
                            else
                            {
                                App.ShowForm(typeof(FRMPartsInvoiceImport), false, null);
                            }

                            break;
                        }

                    case var case43 when case43 == "FRMSupplierInvoiceImporter".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.POImporter) == false)
                            {
                                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }
                            else
                            {
                                App.ShowForm(typeof(FRMSupplierInvoiceImporter), false, null);
                            }

                            break;
                        }

                    case var case44 when case44 == "FRMPOInvoiceAuthorisation".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.POAuthorisation) == false)
                            {
                                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }
                            else
                            {
                                App.ShowForm(typeof(FRMPOInvoiceAuthorisation), false, null);
                            }

                            break;
                        }

                    case var case45 when case45 == "FRMSitesImport".ToLower():
                        {
                            App.ShowForm(typeof(FRMImport), false, new object[] { "Sites" });
                            break;
                        }

                    case var case46 when case46 == "FRMLetterManager".ToLower():
                        {
                            App.ShowForm(typeof(FRMLetterManager), false, null);
                            break;
                        }

                    case var case47 when case47 == "FRMLetterManagerMK3".ToLower():
                        {
                            App.ShowForm(typeof(FRMLetterManagerMK3), false, null);
                            break;
                        }

                    case var case48 when case48 == "FRMFleetVanImporter".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Fleet) == false)
                            {
                                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }
                            else
                            {
                                App.ShowForm(typeof(FRMFleetVanImporter), false, null);
                            }

                            break;
                        }

                    case var case49 when case49 == "FRMFleetVanManager".ToLower():
                        {
                            if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Fleet) == false)
                            {
                                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                throw new System.Security.SecurityException(msg);
                            }
                            else
                            {
                                App.ShowForm(typeof(FRMFleetVanManager), false, null);
                            }

                            break;
                        }

                    case var case50 when case50 == "UsePanels".ToLower():
                        {
                            var switchExpr1 = butttonClicked.TableToSearch;
                            switch (switchExpr1)
                            {
                                case Entity.Sys.Enums.TableNames.tblSupplier:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Supplier.Supplier_GetAll(), Entity.Sys.Enums.PageViewing.Supplier, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblCustomer:
                                    {
                                        App.CurrentCustomerID = 0;
                                        App.MainForm.SetSearchResults(App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Customer, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblProduct:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Product.Product_GetAll(), Entity.Sys.Enums.PageViewing.Product, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblPart:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Part.Part_GetAll(), Entity.Sys.Enums.PageViewing.Part, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblPartPack:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Part.PartPack_GetAll(), Entity.Sys.Enums.PageViewing.PartPack, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblEngineer:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Engineer.Engineer_GetAll_NoSub(), Entity.Sys.Enums.PageViewing.Engineer, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblEquipment:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Engineer.Equipment_GetAll(), Entity.Sys.Enums.PageViewing.Equipment, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblWarehouse:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Warehouse.Warehouse_GetAll(), Entity.Sys.Enums.PageViewing.Warehouse, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblSubcontractor:
                                    {
                                        if (App.loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.Subcontractor) == false)
                                        {
                                            string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                                            msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                                            throw new System.Security.SecurityException(msg);
                                        }
                                        else
                                        {
                                            App.MainForm.SetSearchResults(App.DB.SubContractor.Subcontractor_GetAll(), Entity.Sys.Enums.PageViewing.Subcontractor, false, false);
                                        }

                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblSite:
                                    {
                                        App.CurrentPropertyID = 0;
                                        if (App.CurrentCustomerID == 0)
                                        {
                                            App.MainForm.SetSearchResults(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, false, false);
                                        }
                                        else
                                        {
                                            var cust = new Entity.Customers.Customer();
                                            cust = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
                                            App.MainForm.SetSearchResults(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, false, false, cust.Name + " (" + cust.AccountNumber + ")");
                                        }

                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblAsset:
                                    {
                                        if (App.CurrentPropertyID == 0)
                                        {
                                            App.MainForm.SetSearchResults(App.DB.Asset.Asset_GetAll(App.loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Asset, false, false);
                                        }
                                        else
                                        {
                                            var site = new Entity.Sites.Site();
                                            site = App.DB.Sites.Get(App.CurrentPropertyID);
                                            var cust = new Entity.Customers.Customer();
                                            cust = App.DB.Customer.Customer_Get(site.CustomerID);
                                            App.MainForm.SetSearchResults(App.DB.Asset.Asset_GetForSite(App.CurrentPropertyID), Entity.Sys.Enums.PageViewing.Asset, false, false, site.Address1 + ", " + site.Postcode + " (" + cust.AccountNumber + ")");
                                        }

                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblVan:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Van.Van_GetAll(true), Entity.Sys.Enums.PageViewing.Van, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblvan2:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Van.Van_GetAll(true), Entity.Sys.Enums.PageViewing.StockProfile, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblFleetVan:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.FleetVan.GetAll(), Entity.Sys.Enums.PageViewing.FleetVan, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblFleetReturnedVans:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.FleetVan.GetAll_Returned(), Entity.Sys.Enums.PageViewing.FleetVan, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblFleetVanType:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.FleetVanType.GetAll(), Entity.Sys.Enums.PageViewing.FleetVanType, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblFleetEquipment:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.FleetEquipment.GetAll(), Entity.Sys.Enums.PageViewing.FleetEquipment, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblFleetGarage:
                                    {
                                        App.MainForm.SetSearchResults(App.DB.Sites.GetAll_FleetGarage(App.loggedInUser.UserID), Entity.Sys.Enums.PageViewing.Property, false, false);
                                        break;
                                    }

                                case Entity.Sys.Enums.TableNames.tblUserQualification:
                                    {
                                        var _ssmList = new List<Entity.Sys.Enums.SecuritySystemModules>() { Entity.Sys.Enums.SecuritySystemModules.Compliance, Entity.Sys.Enums.SecuritySystemModules.IT };
                                        App.MainForm.SetSearchResults(App.DB.User.GetAll_NoEngineers(), Entity.Sys.Enums.PageViewing.UserQuals, false, false);
                                        break;
                                    }
                            }

                            break;
                        }

                    case var case51 when case51 == "FRMBatchVisitCosts".ToLower():
                        {
                            App.ShowForm(typeof(FRMBatchVisitCosts), false, null);
                            break;
                        }

                    case var case52 when case52 == "FRMJobWizard".ToLower():
                        {
                            App.ShowForm(typeof(FRMJobWizard), false, null);
                            break;
                        }

                    case var case53 when case53 == "FRMEquipmentUsed".ToLower():
                        {
                            App.ShowForm(typeof(FRMEquipmentUsed), false, null);
                            break;
                        }

                    case var case54 when case54 == "FRMSchedulerSettings".ToLower():
                        {
                            App.ShowForm(typeof(FRMSchedulerSettings), false, null);
                            break;
                        }
                }
            }
        }

        public static bool Close_Middle()
        {
            if (Close_Right())
            {
                App.MainForm.pnlMiddle.Visible = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Close_Right()
        {
            if (App.MainForm.pnlRight.Visible)
            {
                if (App.ControlChanged == true)
                {
                    if (App.ShowMessage("Would you like to save before data pane closes? (Any changes made will be lost)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (((IUserControl)App.MainForm.pnlContent.Controls[0]).Save())
                        {
                            App.MainForm.pnlRight.Visible = false;
                            App.MainForm.pnlContent.Controls.Clear();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        App.MainForm.pnlRight.Visible = false;
                        App.MainForm.pnlContent.Controls.Clear();
                        return true;
                    }
                }
                else
                {
                    App.MainForm.pnlRight.Visible = false;
                    App.MainForm.pnlContent.Controls.Clear();
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public static void Show_Right()
        {
            if (Entity.Sys.Helper.MakeIntegerValid(App.MainForm?.pnlContent.Controls.Count) == 0)
            {
                return;
            }

            App.MainForm.pnlRight.Visible = false;
            int locationX = App.MainForm.pnlLeft.Width + App.MainForm.pnlMiddle.Width + 7;
            int locationY = App.MainForm.pnlMiddle.Location.Y;
            App.MainForm.pnlRight.Location = new Point(locationX, locationY);
            App.MainForm.pnlRight.Size = new Size(App.MainForm.Width - locationX - 10, App.MainForm.pnlMiddle.Height);
            App.MainForm.pnlRight.Visible = true;
        }

        public static void ResponsiveUI()
        {
            if (App.MainForm.pnlMiddle.Width < Entity.Sys.Consts.MidPanelResizeTrigger)
            {
                App.MainForm.btnDelete.Text = "Del";
            }
            else
            {
                App.MainForm.btnDelete.Text = "Delete";
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}