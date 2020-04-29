using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public static class App
    {
        static App()
        {
            TheSystem = new Entity.Sys.SystemData();
            MouseHanlderEvent = new MouseHandler();
        }

        public static Entity.Sys.SystemData TheSystem;
        public static FRMLogin LoginForm;
        public static FRMMain MainForm;
        public static Entity.Sys.Database DB;
        public static Entity.Users.User loggedInUser;
        private static MouseHandler _MouseHanlderEvent;

        public static MouseHandler MouseHanlderEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _MouseHanlderEvent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _MouseHanlderEvent = value;
            }
        }

        public static bool IsLowResolution;
        public static bool IsGasway;
        public static bool IsRFT;
        public static bool IsBlueflame;

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private static int _CurrentCustomerID = 0;

        public static int CurrentCustomerID
        {
            get
            {
                return _CurrentCustomerID;
            }

            set
            {
                _CurrentCustomerID = value;
                if (MainForm.MenuBar.pnlSubMenu.Controls.Count == 0)
                {
                    return;
                }

                if (CurrentCustomerID == 0)
                {
                    if (MainForm.SelectedMenu == Entity.Sys.Enums.MenuTypes.Customers)
                    {
                        MainForm.MenuBar.pnlSubMenu.Controls[1].Text = "Show All Properties";
                        MainForm.MenuBar.pnlSubMenu.Controls[2].Text = "Show All Appliances";
                        ViewingAllSites = true;
                    }
                }
                else if (MainForm.SelectedMenu == Entity.Sys.Enums.MenuTypes.Customers)
                {
                    MainForm.MenuBar.pnlSubMenu.Controls[1].Text = "Properties For Customer";
                    MainForm.MenuBar.pnlSubMenu.Controls[2].Text = "Show All Appliances";
                    ViewingAllSites = false;
                }
            }
        }

        private static bool _ViewingAllSites = true;

        public static bool ViewingAllSites
        {
            get
            {
                return _ViewingAllSites;
            }

            set
            {
                _ViewingAllSites = value;
            }
        }

        private static int _CurrentPropertyID = 0;

        public static int CurrentPropertyID
        {
            get
            {
                return _CurrentPropertyID;
            }

            set
            {
                _CurrentPropertyID = value;
                if (MainForm.MenuBar.pnlSubMenu.Controls.Count == 0)
                {
                    return;
                }

                if (CurrentPropertyID == 0)
                {
                    if (MainForm.SelectedMenu == Entity.Sys.Enums.MenuTypes.Customers)
                    {
                        MainForm.MenuBar.pnlSubMenu.Controls[2].Text = "Show All Appliances";
                        ViewingAllAssets = true;
                    }
                }
                else if (MainForm.SelectedMenu == Entity.Sys.Enums.MenuTypes.Customers)
                {
                    MainForm.MenuBar.pnlSubMenu.Controls[2].Text = "Appliances For Property";
                    ViewingAllAssets = false;
                }
            }
        }

        private static bool _ViewingAllAssets = true;

        public static bool ViewingAllAssets
        {
            get
            {
                return _ViewingAllAssets;
            }

            set
            {
                _ViewingAllAssets = value;
            }
        }

        private static DataTable _dtVisit = new DataTable();

        public static DataTable dtVisitFilters
        {
            get
            {
                if (_dtVisit.Columns.Count == 0)
                {
                    _dtVisit.Columns.Add("Field");
                    _dtVisit.Columns.Add("Value");
                    _dtVisit.Columns.Add("Type");
                }

                return _dtVisit;
            }

            set
            {
                _dtVisit = value;
            }
        }

        private static string _releaseNoteTextFile;

        public static string ReleaseNoteTextFile
        {
            get
            {
                return _releaseNoteTextFile;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        // Starting point of the application
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.ThreadException += AppErrorOccurred;
                Cursor.Current = Cursors.AppStarting;
                var switchExpr = TheSystem.Configuration.DBName;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.DataBaseName.GaswayServicesFSM:
                    case Entity.Sys.Enums.DataBaseName.GaswayServicesFSM_Beta:
                        {
                            IsGasway = true;
                            break;
                        }

                    case Entity.Sys.Enums.DataBaseName.RftFsm_Beta:
                    case Entity.Sys.Enums.DataBaseName.RftServicesFsm:
                        {
                            IsRFT = true;
                            break;
                        }

                    case Entity.Sys.Enums.DataBaseName.BlueflameServicesFsm:
                    case Entity.Sys.Enums.DataBaseName.BlueflameServicesFsm_Beta:
                        {
                            IsBlueflame = true;
                            break;
                        }
                }

                if (ShowAppearanceMessage())
                {
                    DB = new Entity.Sys.Database();
                    _releaseNoteTextFile = "18.09.25_RN.txt";
                    if (LoginForm is null)
                    {
                        LoginForm = (FRMLogin)Activator.CreateInstance(typeof(FRMLogin));
                    }

                    LoginForm.ShowInTaskbar = true;
                    LoginForm.Show();
                    Application.Run(LoginForm);
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                var eventLog = new EventLog();
                string errorMsg = ex.Message;
                if (ex.InnerException is object)
                {
                    errorMsg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                }

                LogError(ex.GetType().Name, errorMsg, ex.StackTrace);
                ShowMessage("Application error : " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private static void AppErrorOccurred(object sender, System.Threading.ThreadExceptionEventArgs t)
        {
            if (t.Exception is System.Security.SecurityException)
            {
                ShowMessage(t.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ShowMessage("An error has occured in the application. Please contact support with the following exception : " + Constants.vbCrLf + t.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError(t.GetType().Name, t.Exception.Message, t.Exception.StackTrace);
            }
        }

        // Check the operating system and screen resolution to show message to user about the design
        private static bool ShowAppearanceMessage()
        {
            string screenResolution = "Unknown_Width x Unknown_Height";
            screenResolution = screenResolution.Replace("Unknown_Height", Screen.PrimaryScreen.Bounds.Height.ToString());
            screenResolution = screenResolution.Replace("Unknown_Width", Screen.PrimaryScreen.Bounds.Width.ToString());
            if (Screen.PrimaryScreen.Bounds.Height <= Entity.Sys.Consts.ScreenBestResolutionHeight | Screen.PrimaryScreen.Bounds.Width <= Entity.Sys.Consts.ScreenBestResolutionWidth)
            {
                IsLowResolution = true;
            }

            if (Screen.PrimaryScreen.Bounds.Height < Entity.Sys.Consts.ScreenMinResolutionHeight | Screen.PrimaryScreen.Bounds.Width < Entity.Sys.Consts.ScreenMinResolutionWidth)
            {
                string message = "It has been detected that your screen resolution is " + screenResolution + "." + Constants.vbCrLf + Constants.vbCrLf;
                message += "This application has been designed to run with a minimum screen resolution of 1024 x 730." + Constants.vbCrLf + Constants.vbCrLf;
                message += "Therefore the application will not function correctly." + Constants.vbCrLf + Constants.vbCrLf;
                message += "Gabriel will now exit, please contact IT support to change device resolution?";
                ShowMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (Screen.PrimaryScreen.Bounds.Height < Entity.Sys.Consts.ScreenWarningResolutionHeight | Screen.PrimaryScreen.Bounds.Width < Entity.Sys.Consts.ScreenWarningResolutionWidth)
            {
                string message = "It has been detected that your screen resolution is " + screenResolution + "." + Constants.vbCrLf + Constants.vbCrLf;
                message += "This application has been designed to run with a screen resolution of at least 1024 x 768." + Constants.vbCrLf + Constants.vbCrLf;
                message += "Therefore the application may not function correctly." + Constants.vbCrLf + Constants.vbCrLf;
                message += "Would you like to continue?";
                if (ShowMessage(message, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        // This method is used for the opening of new form such as login, menu and any other top level forms
        public static Form ShowForm(Type frm, bool asDialgue, object[] parameters, bool IgnoreIfOpen = false)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Form newForm = null;
                if (!IgnoreIfOpen)
                {
                    newForm = checkIfExists(frm.Name, true);
                }

                if (newForm is null)
                {
                    newForm = (Form)Activator.CreateInstance(frm);
                    // newForm.Icon = New Icon(newForm.GetType(), "Logo.ico")

                    ((IBaseForm)newForm).SetFormParameters = parameters;
                    newForm.ShowInTaskbar = false;
                    newForm.StartPosition = FormStartPosition.CenterScreen;
                    newForm.SizeGripStyle = SizeGripStyle.Hide;
                    if (asDialgue)
                    {
                        if (!((frm.Name.ToUpper() ?? "") == ("FRMAnswers".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMEngineerVisit".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMPostcodeManager".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMStockReplenishment".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMReceiveStock".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMPartsToOrders".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMAddToQuote".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMAddToOrder".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMOrderCharges".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMEnterEmailAddress".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMChooseSupplierPacks".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMPickDespatchDetails".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMEngineerHistory".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMVanHistory".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMViewContractAlternativeChargeDetails".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMAvailableContractNos".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMChooseAsset".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMJobAudit".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMRaiseInvoiceDetails".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMConvertToAnOrder".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FrmInvoicedPayment".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMContractRenewal".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMSiteCustomerAudit".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMSitePopup".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMConsolidation".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMConsolidation_Location".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMConvertToPDF".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMSiteVisitManager".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMSiteLetterList".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMSelectLocation".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMCreditReceived".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMEngineerTimesheet".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMLastServiceDate".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMChangeInvoicedTotal".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMChangePaymentTerms".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMAmendServiceDate".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMChangeSageDate".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMJobWizard".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMAddInvoiceAddress".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMChangeInvoiceLine".ToUpper() ?? "")) & !((frm.Name.ToUpper() ?? "") == ("FRMViewEngineer".ToUpper() ?? "")))
                        {
                            ((IForm)newForm).LoadedControl.RecordsChanged += MainForm.SetSearchResults;
                            ((IForm)newForm).LoadedControl.StateChanged += ((IForm)newForm).ResetMe;
                        }

                        if ((frm.Name.ToUpper() ?? "") == ("FRMQuoteRejection".ToUpper() ?? ""))
                        {
                            ((FRMQuoteRejection)newForm).ReasonEdited += ((UCQuoteJob)parameters[0]).RejectReasonChanged;
                        }

                        if ((frm.Name.ToUpper() ?? "") == ("FRMOrderRejection".ToUpper() ?? ""))
                        {
                            ((FRMOrderRejection)newForm).ReasonEdited += ((UCOrder)parameters[0]).ReasonChanged;
                        }

                        newForm.ShowDialog();
                        if ((frm.Name.ToUpper() ?? "") == ("FRMChooseSupplierPacks".ToUpper() ?? "") | (frm.Name.ToUpper() ?? "") == ("FRMSelectLocation".ToUpper() ?? "") | (frm.Name.ToUpper() ?? "") == ("FRMLastServiceDate".ToUpper() ?? "") | (frm.Name.ToUpper() ?? "") == ("FRMChangeInvoicedTotal".ToUpper() ?? "") | (frm.Name.ToUpper() ?? "") == ("FRMChangeInvoiceLine".ToUpper() ?? "") | (frm.Name.ToUpper() ?? "") == ("FRMChangePaymentTerms".ToUpper() ?? "") | (frm.Name.ToUpper() ?? "") == ("FRMChangeSageDate".ToUpper() ?? "") | (frm.Name.ToUpper() ?? "") == ("FRMSiteLetterList".ToUpper() ?? ""))
                        {
                            return newForm;
                        }
                        else
                        {
                            newForm.Dispose();
                            return null;
                        }
                    }
                    else
                    {
                        ((IBaseForm)newForm).SetFormParameters = parameters;
                        newForm.MdiParent = MainForm;
                        MainForm.pnlRight.Visible = false;
                        MainForm.pnlContent.Controls.Clear();
                        MainForm.pnlMiddle.Visible = false;
                        newForm.Show();
                        return newForm;
                    }
                }
                else
                {
                    ((IBaseForm)newForm).SetFormParameters = parameters;
                    var switchExpr = frm.Name.ToUpper();
                    switch (switchExpr)
                    {
                        case var @case when @case == "FRMVisitManager".ToUpper():
                            {
                                ((FRMVisitManager)newForm).PopulateDatagrid(true);
                                break;
                            }

                        case var case1 when case1 == "FRMOrderManager".ToUpper():
                            {
                                ((FRMOrderManager)newForm).PopulateDatagrid();
                                break;
                            }

                        case var case2 when case2 == "FRMQuoteManager".ToUpper():
                            {
                                ((FRMQuoteManager)newForm).PopulateDatagrid();
                                break;
                            }
                    }

                    return newForm;
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Cannot open form : " + Constants.vbCrLf + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                string msg = ex.Message;
                if (ex.InnerException is object)
                {
                    msg += Constants.vbCrLf + "Inner Exception:" + Constants.vbCrLf + ex.InnerException.Message;
                }

                LogError(ex.GetType().Name, msg, ex.StackTrace);
                return null;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        // This method is used to return a boolean value for if the override password was entered correctly
        public static bool EnterOverridePassword()
        {
            /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElseDirectiveTrivia */
            return true;
            /* TODO ERROR: Skipped EndIfDirectiveTrivia */
        }

        public static bool EnterOverridePasswordINV()
        {
            /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped ElseDirectiveTrivia */
            return true;
            /* TODO ERROR: Skipped EndIfDirectiveTrivia */
        }

        public static bool EnterOverridePassword_Service()
        {
            DLGPasswordOverride dialogue;
            dialogue = (DLGPasswordOverride)checkIfExists(typeof(DLGPasswordOverride_Service).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGPasswordOverride)Activator.CreateInstance(typeof(DLGPasswordOverride_Service));
            }
            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                return true;
            }
            else
            {
                ShowMessage("Incorrect password or operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            dialogue.Close();
        }

        public static object FindRecord(Entity.Sys.Enums.TableNames tableToSearchIn, int ForeignKeyFilter = 0, string PartNumber = "", bool ForMassPartEntry = false)
        {
            DLGFindRecord dialogue;
            dialogue = (DLGFindRecord)checkIfExists(typeof(DLGFindRecord).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGFindRecord)Activator.CreateInstance(typeof(DLGFindRecord));
            }
            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.ForMassPartEntry = ForMassPartEntry;
            dialogue.ForeignKeyFilter = ForeignKeyFilter;
            dialogue.PartNumber = PartNumber;
            dialogue.TableToSearch = tableToSearchIn;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                if (ForMassPartEntry)
                {
                    return dialogue.PartsToAdd;
                }
                else
                {
                    return dialogue.ID;
                }
            }
            else if (ForMassPartEntry)
            {
                return null;
            }
            else
            {
                return 0;
            }

            dialogue.Close();
        }

        public static int FindRecord(Entity.Sys.Enums.TableNames tableToSearchIn, System.Data.SqlClient.SqlTransaction trans, int ForeignKeyFilter = 0, string PartNumber = "")
        {
            DLGFindRecord dialogue;
            dialogue = (DLGFindRecord)checkIfExists(typeof(DLGFindRecord).Name, true);
            if (dialogue is null)
            {
                // Carl said use constructor
                // dialogue = Activator.CreateInstance(GetType(DLGFindRecord))
                dialogue = new DLGFindRecord(trans);
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.ForeignKeyFilter = ForeignKeyFilter;
            dialogue.PartNumber = PartNumber;
            dialogue.TableToSearch = tableToSearchIn;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                return dialogue.ID;
            }
            else
            {
                return 0;
            }

            dialogue.Close();
        }

        public static int PickPartProductSupplier(Entity.Sys.Enums.TableNames tableToSearchIn, int PartOrProductID)
        {
            DLGPickPartProductSupplier dialogue;
            dialogue = (DLGPickPartProductSupplier)checkIfExists(typeof(DLGPickPartProductSupplier).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGPickPartProductSupplier)Activator.CreateInstance(typeof(DLGPickPartProductSupplier));
            }
            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.ID = PartOrProductID;
            dialogue.TableToSearch = tableToSearchIn;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                return dialogue.ID;
            }
            else
            {
                return 0;
            }

            dialogue.Close();
        }

        public static int FindRecordMultiId(Entity.Sys.Enums.TableNames tableToSearchIn, List<int> foreignKeyFilter)
        {
            DLGFindRecord dialogue;
            dialogue = (DLGFindRecord)checkIfExists(typeof(DLGFindRecord).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGFindRecord)Activator.CreateInstance(typeof(DLGFindRecord));
            }
            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.ForeignKeyFilters = foreignKeyFilter;
            dialogue.TableToSearch = tableToSearchIn;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                return dialogue.ID;
            }
            else
            {
                return 0;
            }

            dialogue.Close();
        }

        // If a form already exists, then use it so give focus
        public static Form checkIfExists(string formIn, bool giveFocus)
        {
            foreach (Form form in MainForm.MdiChildren)
            {
                if ((Strings.LCase(form.Name) ?? "") == (Strings.LCase(formIn) ?? ""))
                {
                    if (giveFocus)
                    {
                        form.Focus();
                    }

                    return form;
                }
            }

            return null;
        }

        // Log the user in
        public static void Login()
        {
            if (MainForm is null)
            {
                MainForm = (FRMMain)Activator.CreateInstance(typeof(FRMMain));
            }

            MainForm.ShowInTaskbar = true;
            MainForm.Show();
            LoginForm.Hide();
            try
            {
                var settings = DB.Manager.Get();
                var WorkingHoursStart = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, Conversions.ToInteger(settings.WorkingHoursStart.Split(':')[0]), Conversions.ToInteger(settings.WorkingHoursStart.Split(':')[1]), 0);
                var WorkingHoursEnd = new DateTime(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day, Conversions.ToInteger(settings.WorkingHoursEnd.Split(':')[0]), Conversions.ToInteger(settings.WorkingHoursEnd.Split(':')[1]), 0);
                string outOfHours = Conversions.ToString(Interaction.IIf(DateAndTime.Now > WorkingHoursStart & DateAndTime.Now < WorkingHoursEnd, "0", "1"));
                var switchExpr = TheSystem.DataBaseServerType;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.DatabaseSystems.Microsoft_SQL_Server:
                        {
                            DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) " + "VALUES (GETDATE(), " + loggedInUser.UserID + ", 'LOGON', 'HIDDEN', 'Authenticate'," + outOfHours + ")", false);
                            break;
                        }

                    case Entity.Sys.Enums.DatabaseSystems.MySQL:
                        {
                            DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) " + "VALUES (Now(), " + loggedInUser.UserID + ", 'LOGON', 'HIDDEN', 'Authenticate'," + outOfHours + ")", false);
                            break;
                        }
                }
            }
            catch
            {
                // DO NOTHING
            }
        }

        // Log the user out of the system
        public static void Logout()
        {
            if (ShowMessage("Are you sure you want to logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var forms = new List<Form>();
                foreach (Form form in Application.OpenForms)
                    forms.Add(form);
                for (int i = 0, loopTo = forms.Count - 1; i <= loopTo; i++)
                {
                    var form = forms[i];
                    var switchExpr = form.Name;
                    switch (switchExpr)
                    {
                        case var @case when @case == MainForm.Name:
                            {
                                break;
                            }

                        case var case1 when case1 == LoginForm.Name:
                            {
                                break;
                            }

                        default:
                            {
                                form.Dispose();
                                break;
                            }
                    }
                }

                if (DB is object)
                    DB.JobLock.DeleteAll();
                loggedInUser = null;
                MainForm.Hide();
                MainForm = null;
                LoginForm.Show();
            }
        }

        // Close the application
        public static void CloseApplication()
        {
            if (ShowMessage("Are you sure you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public static DialogResult ShowMessage(string MessageText, MessageBoxButtons MessageBoxButton, MessageBoxIcon MessagesBoxIcon)
        {
            return MessageBox.Show(MessageText, TheSystem.Title, MessageBoxButton, MessagesBoxIcon);
        }

        public static DialogResult ShowMessageWithDetails(string title, string messageText, List<string> details)
        {
            string detailsStr = string.Join(Environment.NewLine, details.ToArray());
            string dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
            var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);
            Form dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());
            dialog.Text = title;
            dialogType.GetProperty("Message").SetValue(dialog, messageText, null);
            dialogType.GetProperty("Details").SetValue(dialog, detailsStr, null);
            var result = dialog.ShowDialog();
            return result;
        }

        public static void ShowSecurityError()
        {
            string msg = "You do not have the necessary security permissions." + Constants.vbCrLf + Constants.vbCrLf + "Contact your administrator if you think this is wrong or you need the permissions changing.";
            throw new System.Security.SecurityException(msg);
        }

        public static void LogError(string errorType, string errorMsg, string stackTrace)
        {
            if (loggedInUser is object && !loggedInUser.HasAccessToModule(Entity.Sys.Enums.SecuritySystemModules.BetaFeatures))
            {
                return;
            }
            /* TODO ERROR: Skipped IfDirectiveTrivia *//* TODO ERROR: Skipped DisabledTextTrivia *//* TODO ERROR: Skipped EndIfDirectiveTrivia */
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static bool ControlLoading = false;
        public static bool ControlChanged = false;

        public static void AddChangeHandlers(Control controlToLoop)
        {
            foreach (Control cntrl in controlToLoop.Controls)
            {
                var switchExpr = cntrl.GetType().Name;
                switch (switchExpr)
                {
                    case "TabControl":
                    case "TabPage":
                    case "GroupBox":
                    case "Panel":
                        {
                            AddChangeHandlers(cntrl);
                            break;
                        }

                    case "ComboBox":
                        {
                            ((ComboBox)cntrl).SelectedIndexChanged += AnythingChanges;
                            break;
                        }

                    case "CheckBox":
                        {
                            ((CheckBox)cntrl).CheckedChanged += AnythingChanges;
                            break;
                        }

                    case "NumericUpDown":
                        {
                            ((NumericUpDown)cntrl).Click += AnythingChanges;
                            break;
                        }

                    case "DateTimePicker":
                        {
                            ((DateTimePicker)cntrl).ValueChanged += AnythingChanges;
                            break;
                        }

                    case "TextBox":
                        {
                            ((TextBox)cntrl).TextChanged += AnythingChanges;
                            break;
                        }

                    case "RadioButton":
                        {
                            ((RadioButton)cntrl).CheckedChanged += AnythingChanges;
                            break;
                        }
                }
            }
        }

        public static void AnythingChanges(object sender, EventArgs e)
        {
            if (ControlLoading == false)
            {
                ControlChanged = true;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}