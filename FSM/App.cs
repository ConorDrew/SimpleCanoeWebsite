// Decompiled with JetBrains decompiler
// Type: FSM.App
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Management;
using FSM.Entity.Sys;
using FSM.Entity.Users;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;

namespace FSM
{
  [StandardModule]
  public sealed class App
  {
    public static SystemData TheSystem = new SystemData();
    public static FRMLogin LoginForm;
    public static FRMMain MainForm;
    public static Database DB;
    public static User loggedInUser;
    public static bool IsLowResolution;
    public static bool IsGasway;
    public static bool IsRFT;
    public static bool IsBlueflame;
    private static int _CurrentCustomerID;
    private static bool _ViewingAllSites;
    private static int _CurrentPropertyID;
    private static bool _ViewingAllAssets;
    private static DataTable _dtVisit;
    private static string _releaseNoteTextFile;
    public static bool ControlLoading;
    public static bool ControlChanged;

    static App()
    {
      App.MouseHanlderEvent = new MouseHandler();
      App._CurrentCustomerID = 0;
      App._ViewingAllSites = true;
      App._CurrentPropertyID = 0;
      App._ViewingAllAssets = true;
      App._dtVisit = new DataTable();
      App.ControlLoading = false;
      App.ControlChanged = false;
    }

    public static MouseHandler MouseHanlderEvent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public static int CurrentCustomerID
    {
      get
      {
        return App._CurrentCustomerID;
      }
      set
      {
        App._CurrentCustomerID = value;
        if (App.MainForm.MenuBar.pnlSubMenu.Controls.Count == 0)
          return;
        if (App.CurrentCustomerID == 0)
        {
          if (App.MainForm.SelectedMenu != Enums.MenuTypes.Customers)
            return;
          App.MainForm.MenuBar.pnlSubMenu.Controls[1].Text = "Show All Properties";
          App.MainForm.MenuBar.pnlSubMenu.Controls[2].Text = "Show All Appliances";
          App.ViewingAllSites = true;
        }
        else if (App.MainForm.SelectedMenu == Enums.MenuTypes.Customers)
        {
          App.MainForm.MenuBar.pnlSubMenu.Controls[1].Text = "Properties For Customer";
          App.MainForm.MenuBar.pnlSubMenu.Controls[2].Text = "Show All Appliances";
          App.ViewingAllSites = false;
        }
      }
    }

    public static bool ViewingAllSites
    {
      get
      {
        return App._ViewingAllSites;
      }
      set
      {
        App._ViewingAllSites = value;
      }
    }

    public static int CurrentPropertyID
    {
      get
      {
        return App._CurrentPropertyID;
      }
      set
      {
        App._CurrentPropertyID = value;
        if (App.MainForm.MenuBar.pnlSubMenu.Controls.Count == 0)
          return;
        if (App.CurrentPropertyID == 0)
        {
          if (App.MainForm.SelectedMenu != Enums.MenuTypes.Customers)
            return;
          App.MainForm.MenuBar.pnlSubMenu.Controls[2].Text = "Show All Appliances";
          App.ViewingAllAssets = true;
        }
        else if (App.MainForm.SelectedMenu == Enums.MenuTypes.Customers)
        {
          App.MainForm.MenuBar.pnlSubMenu.Controls[2].Text = "Appliances For Property";
          App.ViewingAllAssets = false;
        }
      }
    }

    public static bool ViewingAllAssets
    {
      get
      {
        return App._ViewingAllAssets;
      }
      set
      {
        App._ViewingAllAssets = value;
      }
    }

    public static DataTable dtVisitFilters
    {
      get
      {
        if (App._dtVisit.Columns.Count == 0)
        {
          App._dtVisit.Columns.Add("Field");
          App._dtVisit.Columns.Add("Value");
          App._dtVisit.Columns.Add("Type");
        }
        return App._dtVisit;
      }
      set
      {
        App._dtVisit = value;
      }
    }

    public static string ReleaseNoteTextFile
    {
      get
      {
        return App._releaseNoteTextFile;
      }
    }

    [STAThread]
    public static void Main()
    {
      try
      {
        Application.EnableVisualStyles();
        Application.ThreadException += new ThreadExceptionEventHandler(App.AppErrorOccurred);
        Cursor.Current = Cursors.AppStarting;
        switch (App.TheSystem.Configuration.DBName)
        {
          case Enums.DataBaseName.GaswayServicesFSM:
          case Enums.DataBaseName.GaswayServicesFSM_Beta:
            App.IsGasway = true;
            break;
          case Enums.DataBaseName.RftServicesFsm:
          case Enums.DataBaseName.RftFsm_Beta:
            App.IsRFT = true;
            break;
          case Enums.DataBaseName.BlueflameServicesFsm:
          case Enums.DataBaseName.BlueflameServicesFsm_Beta:
            App.IsBlueflame = true;
            break;
        }
        if (App.ShowAppearanceMessage())
        {
          App.DB = new Database();
          App._releaseNoteTextFile = "18.09.25_RN.txt";
          if (App.LoginForm == null)
            App.LoginForm = (FRMLogin) Activator.CreateInstance(typeof (FRMLogin));
          App.LoginForm.ShowInTaskbar = true;
          App.LoginForm.Show();
          Application.Run((Form) App.LoginForm);
        }
        else
          Application.Exit();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        EventLog eventLog = new EventLog();
        string errorMsg = exception.Message;
        if (exception.InnerException != null)
          errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
        App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
        int num = (int) App.ShowMessage("Application error : \r\n\r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }

    private static void AppErrorOccurred(object sender, ThreadExceptionEventArgs t)
    {
      if (t.Exception is SecurityException)
      {
        int num1 = (int) App.ShowMessage(t.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        int num2 = (int) App.ShowMessage("An error has occured in the application. Please contact support with the following exception : \r\n" + t.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        App.LogError(t.GetType().Name, t.Exception.Message, t.Exception.StackTrace);
      }
    }

    private static bool ShowAppearanceMessage()
    {
      string str = "Unknown_Width x Unknown_Height".Replace("Unknown_Height", Screen.PrimaryScreen.Bounds.Height.ToString()).Replace("Unknown_Width", Screen.PrimaryScreen.Bounds.Width.ToString());
      Rectangle bounds1 = Screen.PrimaryScreen.Bounds;
      int num1 = bounds1.Height <= 864 ? 1 : 0;
      bounds1 = Screen.PrimaryScreen.Bounds;
      int num2 = bounds1.Width <= 1536 ? 1 : 0;
      if ((num1 | num2) != 0)
        App.IsLowResolution = true;
      Rectangle bounds2 = Screen.PrimaryScreen.Bounds;
      int num3 = bounds2.Height < 720 ? 1 : 0;
      bounds2 = Screen.PrimaryScreen.Bounds;
      int num4 = bounds2.Width < 1024 ? 1 : 0;
      if ((num3 | num4) != 0)
      {
        int num5 = (int) App.ShowMessage("It has been detected that your screen resolution is " + str + ".\r\n\r\n" + "This application has been designed to run with a minimum screen resolution of 1024 x 730.\r\n\r\n" + "Therefore the application will not function correctly.\r\n\r\n" + "Gabriel will now exit, please contact IT support to change device resolution?", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      Rectangle bounds3 = Screen.PrimaryScreen.Bounds;
      int num6 = bounds3.Height < 768 ? 1 : 0;
      bounds3 = Screen.PrimaryScreen.Bounds;
      int num7 = bounds3.Width < 1024 ? 1 : 0;
      return (num6 | num7) == 0 || App.ShowMessage("It has been detected that your screen resolution is " + str + ".\r\n\r\n" + "This application has been designed to run with a screen resolution of at least 1024 x 768.\r\n\r\n" + "Therefore the application may not function correctly.\r\n\r\n" + "Would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    public static Form ShowForm(
      System.Type frm,
      bool asDialgue,
      object[] parameters,
      bool IgnoreIfOpen = false)
    {
      Form form1;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        Form form2 = (Form) null;
        if (!IgnoreIfOpen)
          form2 = App.checkIfExists(frm.Name, true);
        if (form2 == null)
        {
          Form instance = (Form) Activator.CreateInstance(frm);
          ((IBaseForm) instance).SetFormParameters = (Array) parameters;
          instance.ShowInTaskbar = false;
          instance.StartPosition = FormStartPosition.CenterScreen;
          instance.SizeGripStyle = SizeGripStyle.Hide;
          if (asDialgue)
          {
            if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMAnswers".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMEngineerVisit".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMPostcodeManager".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMStockReplenishment".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMReceiveStock".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMPartsToOrders".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMAddToQuote".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMAddToOrder".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMOrderCharges".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMEnterEmailAddress".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChooseSupplierPacks".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMPickDespatchDetails".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMEngineerHistory".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMVanHistory".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMViewContractAlternativeChargeDetails".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMAvailableContractNos".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChooseAsset".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMJobAudit".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMRaiseInvoiceDetails".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMConvertToAnOrder".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FrmInvoicedPayment".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMContractRenewal".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMSiteCustomerAudit".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMSitePopup".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMConsolidation".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMConsolidation_Location".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMConvertToPDF".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMSiteVisitManager".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMSiteLetterList".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMSelectLocation".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMCreditReceived".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMEngineerTimesheet".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMLastServiceDate".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChangeInvoicedTotal".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChangePaymentTerms".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMAmendServiceDate".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChangeSageDate".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMJobWizard".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMAddInvoiceAddress".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChangeInvoiceLine".ToUpper(), false) > 0U & (uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMViewEngineer".ToUpper(), false) > 0U)
            {
              ((IForm) instance).LoadedControl.RecordsChanged += new IUserControl.RecordsChangedEventHandler(App.MainForm.SetSearchResults);
              ((IForm) instance).LoadedControl.StateChanged += new IUserControl.StateChangedEventHandler(((IForm) instance).ResetMe);
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMQuoteRejection".ToUpper(), false) == 0)
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(((Control) parameters[0]).Name, "UCQuoteContractAlternative", false) == 0)
                ((FRMQuoteRejection) instance).ReasonEdited += new FRMQuoteRejection.ReasonEditedEventHandler(((UCQuoteContractAlternative) parameters[0]).RejectReasonChanged);
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(((Control) parameters[0]).Name, "UCGenerateQuote", false) == 0)
                ((FRMQuoteRejection) instance).ReasonEdited += new FRMQuoteRejection.ReasonEditedEventHandler(((UCGenerateQuote) parameters[0]).RejectReasonChanged);
              else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(((Control) parameters[0]).Name, "UCQuoteContractOption3", false) == 0)
                ((FRMQuoteRejection) instance).ReasonEdited += new FRMQuoteRejection.ReasonEditedEventHandler(((UCQuoteContractOption3) parameters[0]).RejectReasonChanged);
              else
                ((FRMQuoteRejection) instance).ReasonEdited += new FRMQuoteRejection.ReasonEditedEventHandler(((UCQuoteJob) parameters[0]).RejectReasonChanged);
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMOrderRejection".ToUpper(), false) == 0)
              ((FRMOrderRejection) instance).ReasonEdited += new FRMOrderRejection.ReasonEditedEventHandler(((UCOrder) parameters[0]).ReasonChanged);
            int num = (int) instance.ShowDialog();
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChooseSupplierPacks".ToUpper(), false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMSelectLocation".ToUpper(), false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMLastServiceDate".ToUpper(), false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChangeInvoicedTotal".ToUpper(), false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChangeInvoiceLine".ToUpper(), false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChangePaymentTerms".ToUpper(), false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMChangeSageDate".ToUpper(), false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(frm.Name.ToUpper(), "FRMSiteLetterList".ToUpper(), false) == 0)
            {
              form1 = instance;
            }
            else
            {
              instance.Dispose();
              form1 = (Form) null;
            }
          }
          else
          {
            ((IBaseForm) instance).SetFormParameters = (Array) parameters;
            instance.MdiParent = (Form) App.MainForm;
            App.MainForm.pnlRight.Visible = false;
            App.MainForm.pnlContent.Controls.Clear();
            App.MainForm.pnlMiddle.Visible = false;
            instance.Show();
            form1 = instance;
          }
        }
        else
        {
          ((IBaseForm) form2).SetFormParameters = (Array) parameters;
          string upper = frm.Name.ToUpper();
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(upper, "FRMVisitManager".ToUpper(), false) == 0)
            ((FRMVisitManager) form2).PopulateDatagrid(true);
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(upper, "FRMOrderManager".ToUpper(), false) == 0)
            ((FRMOrderManager) form2).PopulateDatagrid();
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(upper, "FRMQuoteManager".ToUpper(), false) == 0)
            ((FRMQuoteManager) form2).PopulateDatagrid();
          form1 = form2;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        int num = (int) App.ShowMessage("Cannot open form : \r\n\r\n" + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        string errorMsg = exception.Message;
        if (exception.InnerException != null)
          errorMsg = errorMsg + "\r\nInner Exception:\r\n" + exception.InnerException.Message;
        App.LogError(exception.GetType().Name, errorMsg, exception.StackTrace);
        form1 = (Form) null;
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
      return form1;
    }

    public static bool EnterOverridePassword()
    {
      return true;
    }

    public static bool EnterOverridePasswordINV()
    {
      return true;
    }

    public static bool EnterOverridePassword_Service()
    {
      DLGPasswordOverride passwordOverride = (DLGPasswordOverride) App.checkIfExists(typeof (DLGPasswordOverride_Service).Name, true) ?? (DLGPasswordOverride) Activator.CreateInstance(typeof (DLGPasswordOverride_Service));
      passwordOverride.ShowInTaskbar = false;
      int num1 = (int) passwordOverride.ShowDialog();
      if (passwordOverride.DialogResult == DialogResult.OK)
        return true;
      int num2 = (int) App.ShowMessage("Incorrect password or operation cancelled by user", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      return false;
    }

    public static object FindRecord(
      Enums.TableNames tableToSearchIn,
      int ForeignKeyFilter = 0,
      string PartNumber = "",
      bool ForMassPartEntry = false)
    {
      DLGFindRecord dlgFindRecord = (DLGFindRecord) App.checkIfExists(typeof (DLGFindRecord).Name, true) ?? (DLGFindRecord) Activator.CreateInstance(typeof (DLGFindRecord));
      dlgFindRecord.ShowInTaskbar = false;
      dlgFindRecord.ForMassPartEntry = ForMassPartEntry;
      dlgFindRecord.ForeignKeyFilter = ForeignKeyFilter;
      dlgFindRecord.PartNumber = PartNumber;
      dlgFindRecord.TableToSearch = tableToSearchIn;
      int num = (int) dlgFindRecord.ShowDialog();
      return dlgFindRecord.DialogResult == DialogResult.OK ? (ForMassPartEntry ? (object) dlgFindRecord.PartsToAdd : (object) dlgFindRecord.ID) : (ForMassPartEntry ? (object) null : (object) 0);
    }

    public static int FindRecord(
      Enums.TableNames tableToSearchIn,
      SqlTransaction trans,
      int ForeignKeyFilter = 0,
      string PartNumber = "")
    {
      DLGFindRecord dlgFindRecord = (DLGFindRecord) App.checkIfExists(typeof (DLGFindRecord).Name, true) ?? new DLGFindRecord(trans);
      dlgFindRecord.ShowInTaskbar = false;
      dlgFindRecord.ForeignKeyFilter = ForeignKeyFilter;
      dlgFindRecord.PartNumber = PartNumber;
      dlgFindRecord.TableToSearch = tableToSearchIn;
      int num = (int) dlgFindRecord.ShowDialog();
      return dlgFindRecord.DialogResult == DialogResult.OK ? dlgFindRecord.ID : 0;
    }

    public static int PickPartProductSupplier(Enums.TableNames tableToSearchIn, int PartOrProductID)
    {
      DLGPickPartProductSupplier partProductSupplier = (DLGPickPartProductSupplier) App.checkIfExists(typeof (DLGPickPartProductSupplier).Name, true) ?? (DLGPickPartProductSupplier) Activator.CreateInstance(typeof (DLGPickPartProductSupplier));
      partProductSupplier.ShowInTaskbar = false;
      partProductSupplier.ID = PartOrProductID;
      partProductSupplier.TableToSearch = tableToSearchIn;
      int num = (int) partProductSupplier.ShowDialog();
      return partProductSupplier.DialogResult == DialogResult.OK ? partProductSupplier.ID : 0;
    }

    public static int FindRecordMultiId(
      Enums.TableNames tableToSearchIn,
      List<int> foreignKeyFilter)
    {
      DLGFindRecord dlgFindRecord = (DLGFindRecord) App.checkIfExists(typeof (DLGFindRecord).Name, true) ?? (DLGFindRecord) Activator.CreateInstance(typeof (DLGFindRecord));
      dlgFindRecord.ShowInTaskbar = false;
      dlgFindRecord.ForeignKeyFilters = foreignKeyFilter;
      dlgFindRecord.TableToSearch = tableToSearchIn;
      int num = (int) dlgFindRecord.ShowDialog();
      return dlgFindRecord.DialogResult == DialogResult.OK ? dlgFindRecord.ID : 0;
    }

    public static Form checkIfExists(string formIn, bool giveFocus)
    {
      Form[] mdiChildren = App.MainForm.MdiChildren;
      int index = 0;
      while (index < mdiChildren.Length)
      {
        Form form = mdiChildren[index];
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Strings.LCase(form.Name), Strings.LCase(formIn), false) == 0)
        {
          if (giveFocus)
            form.Focus();
          return form;
        }
        checked { ++index; }
      }
      return (Form) null;
    }

    public static void Login()
    {
      if (App.MainForm == null)
        App.MainForm = (FRMMain) Activator.CreateInstance(typeof (FRMMain));
      App.MainForm.ShowInTaskbar = true;
      App.MainForm.Show();
      App.LoginForm.Hide();
      try
      {
        Settings settings = App.DB.Manager.Get();
        DateTime now = DateAndTime.Now;
        int year1 = now.Year;
        now = DateAndTime.Now;
        int month1 = now.Month;
        now = DateAndTime.Now;
        int day1 = now.Day;
        int integer1 = Conversions.ToInteger(settings.WorkingHoursStart.Split(':')[0]);
        int integer2 = Conversions.ToInteger(settings.WorkingHoursStart.Split(':')[1]);
        DateTime t2_1 = new DateTime(year1, month1, day1, integer1, integer2, 0);
        now = DateAndTime.Now;
        int year2 = now.Year;
        now = DateAndTime.Now;
        int month2 = now.Month;
        now = DateAndTime.Now;
        int day2 = now.Day;
        int integer3 = Conversions.ToInteger(settings.WorkingHoursEnd.Split(':')[0]);
        int integer4 = Conversions.ToInteger(settings.WorkingHoursEnd.Split(':')[1]);
        DateTime t2_2 = new DateTime(year2, month2, day2, integer3, integer4, 0);
        string str = Conversions.ToString(Interaction.IIf(DateTime.Compare(DateAndTime.Now, t2_1) > 0 & DateTime.Compare(DateAndTime.Now, t2_2) < 0, (object) "0", (object) "1"));
        switch (App.TheSystem.DataBaseServerType)
        {
          case Enums.DatabaseSystems.MySQL:
            App.DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES (Now(), " + Conversions.ToString(App.loggedInUser.UserID) + ", 'LOGON', 'HIDDEN', 'Authenticate'," + str + ")", false);
            break;
          case Enums.DatabaseSystems.Microsoft_SQL_Server:
            App.DB.ExecuteWithOutReturn("INSERT INTO tblhistory (AccessDate, UserID, AccessType, Statement, FormTitle, OutOfHours) VALUES (GETDATE(), " + Conversions.ToString(App.loggedInUser.UserID) + ", 'LOGON', 'HIDDEN', 'Authenticate'," + str + ")", false);
            break;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static void Logout()
    {
      if (App.ShowMessage("Are you sure you want to logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      List<Form> formList = new List<Form>();
      IEnumerator enumerator;
      try
      {
        enumerator = Application.OpenForms.GetEnumerator();
        while (enumerator.MoveNext())
        {
          Form current = (Form) enumerator.Current;
          formList.Add(current);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      int num = checked (formList.Count - 1);
      int index = 0;
      while (index <= num)
      {
        Form form = formList[index];
        string name = form.Name;
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, App.MainForm.Name, false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, App.LoginForm.Name, false) != 0)
          form.Dispose();
        checked { ++index; }
      }
      if (App.DB != null)
        App.DB.JobLock.DeleteAll();
      App.loggedInUser = (User) null;
      App.MainForm.Hide();
      App.MainForm = (FRMMain) null;
      App.LoginForm.Show();
    }

    public static void CloseApplication()
    {
      if (App.ShowMessage("Are you sure you want to exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      Application.Exit();
    }

    public static DialogResult ShowMessage(
      string MessageText,
      MessageBoxButtons MessageBoxButton,
      MessageBoxIcon MessagesBoxIcon)
    {
      return MessageBox.Show(MessageText, App.TheSystem.Title, MessageBoxButton, MessagesBoxIcon);
    }

    public static DialogResult ShowMessageWithDetails(
      string title,
      string messageText,
      List<string> details)
    {
      string str = string.Join(Environment.NewLine, details.ToArray());
      System.Type type = typeof (Form).Assembly.GetType("System.Windows.Forms.PropertyGridInternal.GridErrorDlg");
      Form instance = (Form) Activator.CreateInstance(type, (object) new PropertyGrid());
      instance.Text = title;
      type.GetProperty("Message").SetValue((object) instance, (object) messageText, (object[]) null);
      type.GetProperty("Details").SetValue((object) instance, (object) str, (object[]) null);
      return instance.ShowDialog();
    }

    public static void ShowSecurityError()
    {
      throw new SecurityException("You do not have the necessary security permissions.\r\n\r\nContact your administrator if you think this is wrong or you need the permissions changing.");
    }

    public static void LogError(string errorType, string errorMsg, string stackTrace)
    {
      if (App.loggedInUser != null && !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.BetaFeatures))
        ;
    }

    public static void AddChangeHandlers(Control controlToLoop)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = controlToLoop.Controls.GetEnumerator();
        while (enumerator.MoveNext())
        {
          Control current = (Control) enumerator.Current;
          string name = current.GetType().Name;
          // ISSUE: reference to a compiler-generated method
          switch (\u003CPrivateImplementationDetails\u003E.ComputeStringHash(name))
          {
            case 186607719:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "TabPage", false) == 0)
                break;
              goto default;
            case 496722843:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "TextBox", false) == 0)
              {
                current.TextChanged += new EventHandler(App.AnythingChanges);
                goto default;
              }
              else
                goto default;
            case 1225040048:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "RadioButton", false) == 0)
              {
                ((RadioButton) current).CheckedChanged += new EventHandler(App.AnythingChanges);
                goto default;
              }
              else
                goto default;
            case 1301148785:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "TabControl", false) == 0)
                break;
              goto default;
            case 1595554146:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "DateTimePicker", false) == 0)
              {
                ((DateTimePicker) current).ValueChanged += new EventHandler(App.AnythingChanges);
                goto default;
              }
              else
                goto default;
            case 1933324558:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "ComboBox", false) == 0)
              {
                ((ComboBox) current).SelectedIndexChanged += new EventHandler(App.AnythingChanges);
                goto default;
              }
              else
                goto default;
            case 2642369432:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "CheckBox", false) == 0)
              {
                ((CheckBox) current).CheckedChanged += new EventHandler(App.AnythingChanges);
                goto default;
              }
              else
                goto default;
            case 2708682725:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "Panel", false) == 0)
                break;
              goto default;
            case 2709102469:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "NumericUpDown", false) == 0)
              {
                current.Click += new EventHandler(App.AnythingChanges);
                goto default;
              }
              else
                goto default;
            case 3409613989:
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "GroupBox", false) == 0)
                break;
              goto default;
            default:
label_20:
              continue;
          }
          App.AddChangeHandlers(current);
          goto label_20;
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    public static void AnythingChanges(object sender, EventArgs e)
    {
      if (App.ControlLoading)
        return;
      App.ControlChanged = true;
    }
  }
}
