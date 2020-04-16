// Decompiled with JetBrains decompiler
// Type: FSM.FRMMain
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Assets;
using FSM.Entity.Contacts;
using FSM.Entity.Engineers;
using FSM.Entity.FleetVans;
using FSM.Entity.Parts;
using FSM.Entity.Products;
using FSM.Entity.Sites;
using FSM.Entity.Subcontractors;
using FSM.Entity.Suppliers;
using FSM.Entity.Sys;
using FSM.Entity.Users;
using FSM.Entity.Vans;
using FSM.Entity.Warehouses;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class FRMMain : Form, IForm
  {
    private IContainer components;
    private ArrayList _FormButtons;
    private Enums.MenuTypes _SelectedMenu;
    private Enums.PageViewing _Page;
    private DataView _dvSearchResults;
    private bool _Exporting;
    private string _SearchText;

    public FRMMain()
    {
      this.Load += new EventHandler(this.FRMMenu_Load);
      this.Closing += new CancelEventHandler(this.FRMMenu_Closing);
      this.KeyDown += new KeyEventHandler(this.FRMMenu_KeyDown);
      this._FormButtons = (ArrayList) null;
      this._SelectedMenu = Enums.MenuTypes.NONE;
      this._Page = Enums.PageViewing.NONE;
      this._Exporting = false;
      this._SearchText = string.Empty;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual MainMenu MnuMainNav { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuFile { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuChangeLogin
    {
      get
      {
        return this._mnuChangeLogin;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuChangeLogin_Click);
        MenuItem mnuChangeLogin1 = this._mnuChangeLogin;
        if (mnuChangeLogin1 != null)
          mnuChangeLogin1.Click -= eventHandler;
        this._mnuChangeLogin = value;
        MenuItem mnuChangeLogin2 = this._mnuChangeLogin;
        if (mnuChangeLogin2 == null)
          return;
        mnuChangeLogin2.Click += eventHandler;
      }
    }

    internal virtual MenuItem MenuItem3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuLogout
    {
      get
      {
        return this._mnuLogout;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuLogout_Click);
        MenuItem mnuLogout1 = this._mnuLogout;
        if (mnuLogout1 != null)
          mnuLogout1.Click -= eventHandler;
        this._mnuLogout = value;
        MenuItem mnuLogout2 = this._mnuLogout;
        if (mnuLogout2 == null)
          return;
        mnuLogout2.Click += eventHandler;
      }
    }

    internal virtual MenuItem MenuItem15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuAbout
    {
      get
      {
        return this._mnuAbout;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuAbout_Click);
        MenuItem mnuAbout1 = this._mnuAbout;
        if (mnuAbout1 != null)
          mnuAbout1.Click -= eventHandler;
        this._mnuAbout = value;
        MenuItem mnuAbout2 = this._mnuAbout;
        if (mnuAbout2 == null)
          return;
        mnuAbout2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuContactSheet
    {
      get
      {
        return this._mnuContactSheet;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuContactSheet_Click);
        MenuItem mnuContactSheet1 = this._mnuContactSheet;
        if (mnuContactSheet1 != null)
          mnuContactSheet1.Click -= eventHandler;
        this._mnuContactSheet = value;
        MenuItem mnuContactSheet2 = this._mnuContactSheet;
        if (mnuContactSheet2 == null)
          return;
        mnuContactSheet2.Click += eventHandler;
      }
    }

    internal virtual StatusBar infoBar { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuSystemHelp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuSetup
    {
      get
      {
        return this._mnuSetup;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuSetup_Click);
        MenuItem mnuSetup1 = this._mnuSetup;
        if (mnuSetup1 != null)
          mnuSetup1.Click -= eventHandler;
        this._mnuSetup = value;
        MenuItem mnuSetup2 = this._mnuSetup;
        if (mnuSetup2 == null)
          return;
        mnuSetup2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuReports
    {
      get
      {
        return this._mnuReports;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuReports_Click);
        MenuItem mnuReports1 = this._mnuReports;
        if (mnuReports1 != null)
          mnuReports1.Click -= eventHandler;
        this._mnuReports = value;
        MenuItem mnuReports2 = this._mnuReports;
        if (mnuReports2 == null)
          return;
        mnuReports2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlMiddle
    {
      get
      {
        return this._pnlMiddle;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.pnlMiddle_Resize);
        Panel pnlMiddle1 = this._pnlMiddle;
        if (pnlMiddle1 != null)
          pnlMiddle1.Resize -= eventHandler;
        this._pnlMiddle = value;
        Panel pnlMiddle2 = this._pnlMiddle;
        if (pnlMiddle2 == null)
          return;
        pnlMiddle2.Resize += eventHandler;
      }
    }

    internal virtual Panel pnlButtons { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlMiddleTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCloseMiddle
    {
      get
      {
        return this._btnCloseMiddle;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCloseMiddle_Click);
        Button btnCloseMiddle1 = this._btnCloseMiddle;
        if (btnCloseMiddle1 != null)
          btnCloseMiddle1.Click -= eventHandler;
        this._btnCloseMiddle = value;
        Button btnCloseMiddle2 = this._btnCloseMiddle;
        if (btnCloseMiddle2 == null)
          return;
        btnCloseMiddle2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgSearchResults
    {
      get
      {
        return this._dgSearchResults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgSearchResults_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgSearchResults_Click);
        EventHandler eventHandler3 = new EventHandler(this.dgSearchResults_DoubleClick);
        DataGrid dgSearchResults1 = this._dgSearchResults;
        if (dgSearchResults1 != null)
        {
          dgSearchResults1.Click -= eventHandler1;
          dgSearchResults1.CurrentCellChanged -= eventHandler2;
          dgSearchResults1.DoubleClick -= eventHandler3;
        }
        this._dgSearchResults = value;
        DataGrid dgSearchResults2 = this._dgSearchResults;
        if (dgSearchResults2 == null)
          return;
        dgSearchResults2.Click += eventHandler1;
        dgSearchResults2.CurrentCellChanged += eventHandler2;
        dgSearchResults2.DoubleClick += eventHandler3;
      }
    }

    internal virtual Splitter splitLeftAndMiddle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Splitter splitMiddleTop { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Splitter splitMiddleBottom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlLeft { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMiddleTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDelete
    {
      get
      {
        return this._btnDelete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDelete_Click);
        Button btnDelete1 = this._btnDelete;
        if (btnDelete1 != null)
          btnDelete1.Click -= eventHandler;
        this._btnDelete = value;
        Button btnDelete2 = this._btnDelete;
        if (btnDelete2 == null)
          return;
        btnDelete2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddNew
    {
      get
      {
        return this._btnAddNew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNew_Click);
        Button btnAddNew1 = this._btnAddNew;
        if (btnAddNew1 != null)
          btnAddNew1.Click -= eventHandler;
        this._btnAddNew = value;
        Button btnAddNew2 = this._btnAddNew;
        if (btnAddNew2 == null)
          return;
        btnAddNew2.Click += eventHandler;
      }
    }

    internal virtual Panel pnlRight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnleHeaderRight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRightTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCloseRight
    {
      get
      {
        return this._btnCloseRight;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCloseRight_Click);
        Button btnCloseRight1 = this._btnCloseRight;
        if (btnCloseRight1 != null)
          btnCloseRight1.Click -= eventHandler;
        this._btnCloseRight = value;
        Button btnCloseRight2 = this._btnCloseRight;
        if (btnCloseRight2 == null)
          return;
        btnCloseRight2.Click += eventHandler;
      }
    }

    internal virtual Splitter Splitter1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlContent { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlButtonsRight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual Splitter Splitter2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuCustomers
    {
      get
      {
        return this._mnuCustomers;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuCustomers_Click);
        MenuItem mnuCustomers1 = this._mnuCustomers;
        if (mnuCustomers1 != null)
          mnuCustomers1.Click -= eventHandler;
        this._mnuCustomers = value;
        MenuItem mnuCustomers2 = this._mnuCustomers;
        if (mnuCustomers2 == null)
          return;
        mnuCustomers2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuSpares
    {
      get
      {
        return this._mnuSpares;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuSpares_Click);
        MenuItem mnuSpares1 = this._mnuSpares;
        if (mnuSpares1 != null)
          mnuSpares1.Click -= eventHandler;
        this._mnuSpares = value;
        MenuItem mnuSpares2 = this._mnuSpares;
        if (mnuSpares2 == null)
          return;
        mnuSpares2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuStaff
    {
      get
      {
        return this._mnuStaff;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuStaff_Click);
        MenuItem mnuStaff1 = this._mnuStaff;
        if (mnuStaff1 != null)
          mnuStaff1.Click -= eventHandler;
        this._mnuStaff = value;
        MenuItem mnuStaff2 = this._mnuStaff;
        if (mnuStaff2 == null)
          return;
        mnuStaff2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuJobs
    {
      get
      {
        return this._mnuJobs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuJobs_Click);
        MenuItem mnuJobs1 = this._mnuJobs;
        if (mnuJobs1 != null)
          mnuJobs1.Click -= eventHandler;
        this._mnuJobs = value;
        MenuItem mnuJobs2 = this._mnuJobs;
        if (mnuJobs2 == null)
          return;
        mnuJobs2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuInvoicing
    {
      get
      {
        return this._mnuInvoicing;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuInvoicing_Click);
        MenuItem mnuInvoicing1 = this._mnuInvoicing;
        if (mnuInvoicing1 != null)
          mnuInvoicing1.Click -= eventHandler;
        this._mnuInvoicing = value;
        MenuItem mnuInvoicing2 = this._mnuInvoicing;
        if (mnuInvoicing2 == null)
          return;
        mnuInvoicing2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuScheduler
    {
      get
      {
        return this._mnuScheduler;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuScheduler_Click);
        MenuItem mnuScheduler1 = this._mnuScheduler;
        if (mnuScheduler1 != null)
          mnuScheduler1.Click -= eventHandler;
        this._mnuScheduler = value;
        MenuItem mnuScheduler2 = this._mnuScheduler;
        if (mnuScheduler2 == null)
          return;
        mnuScheduler2.Click += eventHandler;
      }
    }

    internal virtual Button btnHQ
    {
      get
      {
        return this._btnHQ;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnHQ_Click);
        Button btnHq1 = this._btnHQ;
        if (btnHq1 != null)
          btnHq1.Click -= eventHandler;
        this._btnHQ = value;
        Button btnHq2 = this._btnHQ;
        if (btnHq2 == null)
          return;
        btnHq2.Click += eventHandler;
      }
    }

    internal virtual Button btnExport
    {
      get
      {
        return this._btnExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExport_Click);
        Button btnExport1 = this._btnExport;
        if (btnExport1 != null)
          btnExport1.Click -= eventHandler;
        this._btnExport = value;
        Button btnExport2 = this._btnExport;
        if (btnExport2 == null)
          return;
        btnExport2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuVan
    {
      get
      {
        return this._mnuVan;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuVan_Click);
        MenuItem mnuVan1 = this._mnuVan;
        if (mnuVan1 != null)
          mnuVan1.Click -= eventHandler;
        this._mnuVan = value;
        MenuItem mnuVan2 = this._mnuVan;
        if (mnuVan2 == null)
          return;
        mnuVan2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuNpPrint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual MenuItem mnuUpstairs
    {
      get
      {
        return this._mnuUpstairs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuUpstairs_Click);
        MenuItem mnuUpstairs1 = this._mnuUpstairs;
        if (mnuUpstairs1 != null)
          mnuUpstairs1.Click -= eventHandler;
        this._mnuUpstairs = value;
        MenuItem mnuUpstairs2 = this._mnuUpstairs;
        if (mnuUpstairs2 == null)
          return;
        mnuUpstairs2.Click += eventHandler;
      }
    }

    internal virtual MenuItem mnuDownstairs
    {
      get
      {
        return this._mnuDownstairs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.mnuDownstairs_Click);
        MenuItem mnuDownstairs1 = this._mnuDownstairs;
        if (mnuDownstairs1 != null)
          mnuDownstairs1.Click -= eventHandler;
        this._mnuDownstairs = value;
        MenuItem mnuDownstairs2 = this._mnuDownstairs;
        if (mnuDownstairs2 == null)
          return;
        mnuDownstairs2.Click += eventHandler;
      }
    }

    internal virtual TableLayoutPanel ContainerMiddlePanelBtns { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Splitter splitMiddleAndRight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnGoBack
    {
      get
      {
        return this._btnGoBack;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGoBack_Click);
        Button btnGoBack1 = this._btnGoBack;
        if (btnGoBack1 != null)
          btnGoBack1.Click -= eventHandler;
        this._btnGoBack = value;
        Button btnGoBack2 = this._btnGoBack;
        if (btnGoBack2 == null)
          return;
        btnGoBack2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMMain));
      this.MnuMainNav = new MainMenu(this.components);
      this.mnuFile = new MenuItem();
      this.mnuChangeLogin = new MenuItem();
      this.MenuItem3 = new MenuItem();
      this.mnuLogout = new MenuItem();
      this.mnuCustomers = new MenuItem();
      this.mnuSpares = new MenuItem();
      this.mnuStaff = new MenuItem();
      this.mnuJobs = new MenuItem();
      this.mnuScheduler = new MenuItem();
      this.mnuInvoicing = new MenuItem();
      this.mnuReports = new MenuItem();
      this.mnuVan = new MenuItem();
      this.mnuSetup = new MenuItem();
      this.mnuSystemHelp = new MenuItem();
      this.mnuContactSheet = new MenuItem();
      this.MenuItem15 = new MenuItem();
      this.mnuAbout = new MenuItem();
      this.mnuNpPrint = new MenuItem();
      this.mnuUpstairs = new MenuItem();
      this.mnuDownstairs = new MenuItem();
      this.infoBar = new StatusBar();
      this.pnlLeft = new Panel();
      this.splitLeftAndMiddle = new Splitter();
      this.pnlMiddle = new Panel();
      this.dgSearchResults = new DataGrid();
      this.splitMiddleTop = new Splitter();
      this.pnlMiddleTitle = new Panel();
      this.btnCloseMiddle = new Button();
      this.lblMiddleTitle = new Label();
      this.splitMiddleBottom = new Splitter();
      this.pnlButtons = new Panel();
      this.ContainerMiddlePanelBtns = new TableLayoutPanel();
      this.btnExport = new Button();
      this.btnAddNew = new Button();
      this.btnDelete = new Button();
      this.pnlRight = new Panel();
      this.Splitter2 = new Splitter();
      this.pnlContent = new Panel();
      this.Splitter1 = new Splitter();
      this.pnleHeaderRight = new Panel();
      this.btnHQ = new Button();
      this.btnCloseRight = new Button();
      this.lblRightTitle = new Label();
      this.pnlButtonsRight = new Panel();
      this.btnGoBack = new Button();
      this.btnSave = new Button();
      this.splitMiddleAndRight = new Splitter();
      this.pnlMiddle.SuspendLayout();
      this.dgSearchResults.BeginInit();
      this.pnlMiddleTitle.SuspendLayout();
      this.pnlButtons.SuspendLayout();
      this.ContainerMiddlePanelBtns.SuspendLayout();
      this.pnlRight.SuspendLayout();
      this.pnleHeaderRight.SuspendLayout();
      this.pnlButtonsRight.SuspendLayout();
      this.SuspendLayout();
      this.MnuMainNav.MenuItems.AddRange(new MenuItem[12]
      {
        this.mnuFile,
        this.mnuCustomers,
        this.mnuSpares,
        this.mnuStaff,
        this.mnuJobs,
        this.mnuScheduler,
        this.mnuInvoicing,
        this.mnuReports,
        this.mnuVan,
        this.mnuSetup,
        this.mnuSystemHelp,
        this.mnuNpPrint
      });
      this.mnuFile.Index = 0;
      this.mnuFile.MenuItems.AddRange(new MenuItem[3]
      {
        this.mnuChangeLogin,
        this.MenuItem3,
        this.mnuLogout
      });
      componentResourceManager.ApplyResources((object) this.mnuFile, "mnuFile");
      this.mnuChangeLogin.Index = 0;
      componentResourceManager.ApplyResources((object) this.mnuChangeLogin, "mnuChangeLogin");
      this.MenuItem3.Index = 1;
      componentResourceManager.ApplyResources((object) this.MenuItem3, "MenuItem3");
      this.mnuLogout.Index = 2;
      componentResourceManager.ApplyResources((object) this.mnuLogout, "mnuLogout");
      this.mnuCustomers.Index = 1;
      componentResourceManager.ApplyResources((object) this.mnuCustomers, "mnuCustomers");
      this.mnuSpares.Index = 2;
      componentResourceManager.ApplyResources((object) this.mnuSpares, "mnuSpares");
      this.mnuStaff.Index = 3;
      componentResourceManager.ApplyResources((object) this.mnuStaff, "mnuStaff");
      this.mnuJobs.Index = 4;
      componentResourceManager.ApplyResources((object) this.mnuJobs, "mnuJobs");
      this.mnuScheduler.Index = 5;
      componentResourceManager.ApplyResources((object) this.mnuScheduler, "mnuScheduler");
      this.mnuInvoicing.Index = 6;
      componentResourceManager.ApplyResources((object) this.mnuInvoicing, "mnuInvoicing");
      this.mnuReports.Index = 7;
      componentResourceManager.ApplyResources((object) this.mnuReports, "mnuReports");
      this.mnuVan.Index = 8;
      componentResourceManager.ApplyResources((object) this.mnuVan, "mnuVan");
      this.mnuSetup.Index = 9;
      componentResourceManager.ApplyResources((object) this.mnuSetup, "mnuSetup");
      this.mnuSystemHelp.Index = 10;
      this.mnuSystemHelp.MenuItems.AddRange(new MenuItem[3]
      {
        this.mnuContactSheet,
        this.MenuItem15,
        this.mnuAbout
      });
      componentResourceManager.ApplyResources((object) this.mnuSystemHelp, "mnuSystemHelp");
      this.mnuContactSheet.Index = 0;
      componentResourceManager.ApplyResources((object) this.mnuContactSheet, "mnuContactSheet");
      this.MenuItem15.Index = 1;
      componentResourceManager.ApplyResources((object) this.MenuItem15, "MenuItem15");
      this.mnuAbout.Index = 2;
      componentResourceManager.ApplyResources((object) this.mnuAbout, "mnuAbout");
      this.mnuNpPrint.Index = 11;
      this.mnuNpPrint.MenuItems.AddRange(new MenuItem[2]
      {
        this.mnuUpstairs,
        this.mnuDownstairs
      });
      componentResourceManager.ApplyResources((object) this.mnuNpPrint, "mnuNpPrint");
      this.mnuUpstairs.Index = 0;
      componentResourceManager.ApplyResources((object) this.mnuUpstairs, "mnuUpstairs");
      this.mnuDownstairs.Index = 1;
      componentResourceManager.ApplyResources((object) this.mnuDownstairs, "mnuDownstairs");
      componentResourceManager.ApplyResources((object) this.infoBar, "infoBar");
      this.infoBar.Name = "infoBar";
      this.infoBar.SizingGrip = false;
      this.pnlLeft.BackColor = Color.White;
      componentResourceManager.ApplyResources((object) this.pnlLeft, "pnlLeft");
      this.pnlLeft.Name = "pnlLeft";
      this.splitLeftAndMiddle.BackColor = Color.FromArgb(244, 244, 244);
      componentResourceManager.ApplyResources((object) this.splitLeftAndMiddle, "splitLeftAndMiddle");
      this.splitLeftAndMiddle.Name = "splitLeftAndMiddle";
      this.splitLeftAndMiddle.TabStop = false;
      this.pnlMiddle.BackColor = Color.FromArgb(224, 224, 224);
      this.pnlMiddle.Controls.Add((Control) this.dgSearchResults);
      this.pnlMiddle.Controls.Add((Control) this.splitMiddleTop);
      this.pnlMiddle.Controls.Add((Control) this.pnlMiddleTitle);
      this.pnlMiddle.Controls.Add((Control) this.splitMiddleBottom);
      this.pnlMiddle.Controls.Add((Control) this.pnlButtons);
      componentResourceManager.ApplyResources((object) this.pnlMiddle, "pnlMiddle");
      this.pnlMiddle.Name = "pnlMiddle";
      this.dgSearchResults.DataMember = "";
      componentResourceManager.ApplyResources((object) this.dgSearchResults, "dgSearchResults");
      this.dgSearchResults.HeaderForeColor = SystemColors.ControlText;
      this.dgSearchResults.Name = "dgSearchResults";
      this.splitMiddleTop.BackColor = Color.Silver;
      componentResourceManager.ApplyResources((object) this.splitMiddleTop, "splitMiddleTop");
      this.splitMiddleTop.Name = "splitMiddleTop";
      this.splitMiddleTop.TabStop = false;
      componentResourceManager.ApplyResources((object) this.pnlMiddleTitle, "pnlMiddleTitle");
      this.pnlMiddleTitle.Controls.Add((Control) this.btnCloseMiddle);
      this.pnlMiddleTitle.Controls.Add((Control) this.lblMiddleTitle);
      this.pnlMiddleTitle.Name = "pnlMiddleTitle";
      componentResourceManager.ApplyResources((object) this.btnCloseMiddle, "btnCloseMiddle");
      this.btnCloseMiddle.Cursor = Cursors.Hand;
      this.btnCloseMiddle.Name = "btnCloseMiddle";
      this.lblMiddleTitle.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.lblMiddleTitle, "lblMiddleTitle");
      this.lblMiddleTitle.ForeColor = Color.White;
      this.lblMiddleTitle.Name = "lblMiddleTitle";
      this.splitMiddleBottom.BackColor = Color.Silver;
      componentResourceManager.ApplyResources((object) this.splitMiddleBottom, "splitMiddleBottom");
      this.splitMiddleBottom.Name = "splitMiddleBottom";
      this.splitMiddleBottom.TabStop = false;
      this.pnlButtons.BackColor = Color.White;
      this.pnlButtons.Controls.Add((Control) this.ContainerMiddlePanelBtns);
      componentResourceManager.ApplyResources((object) this.pnlButtons, "pnlButtons");
      this.pnlButtons.Name = "pnlButtons";
      componentResourceManager.ApplyResources((object) this.ContainerMiddlePanelBtns, "ContainerMiddlePanelBtns");
      this.ContainerMiddlePanelBtns.Controls.Add((Control) this.btnExport, 2, 0);
      this.ContainerMiddlePanelBtns.Controls.Add((Control) this.btnAddNew, 0, 0);
      this.ContainerMiddlePanelBtns.Controls.Add((Control) this.btnDelete, 1, 0);
      this.ContainerMiddlePanelBtns.Name = "ContainerMiddlePanelBtns";
      componentResourceManager.ApplyResources((object) this.btnExport, "btnExport");
      this.btnExport.BackColor = SystemColors.Control;
      this.btnExport.Cursor = Cursors.Hand;
      this.btnExport.Name = "btnExport";
      this.btnExport.UseVisualStyleBackColor = false;
      componentResourceManager.ApplyResources((object) this.btnAddNew, "btnAddNew");
      this.btnAddNew.BackColor = SystemColors.Control;
      this.btnAddNew.Cursor = Cursors.Hand;
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.UseVisualStyleBackColor = false;
      componentResourceManager.ApplyResources((object) this.btnDelete, "btnDelete");
      this.btnDelete.BackColor = SystemColors.Control;
      this.btnDelete.Cursor = Cursors.Hand;
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.UseVisualStyleBackColor = false;
      componentResourceManager.ApplyResources((object) this.pnlRight, "pnlRight");
      this.pnlRight.BackColor = Color.White;
      this.pnlRight.Controls.Add((Control) this.Splitter2);
      this.pnlRight.Controls.Add((Control) this.pnlContent);
      this.pnlRight.Controls.Add((Control) this.Splitter1);
      this.pnlRight.Controls.Add((Control) this.pnleHeaderRight);
      this.pnlRight.Controls.Add((Control) this.pnlButtonsRight);
      this.pnlRight.Name = "pnlRight";
      this.Splitter2.BackColor = Color.Silver;
      componentResourceManager.ApplyResources((object) this.Splitter2, "Splitter2");
      this.Splitter2.Name = "Splitter2";
      this.Splitter2.TabStop = false;
      this.pnlContent.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.pnlContent, "pnlContent");
      this.pnlContent.Name = "pnlContent";
      this.Splitter1.BackColor = Color.Silver;
      componentResourceManager.ApplyResources((object) this.Splitter1, "Splitter1");
      this.Splitter1.Name = "Splitter1";
      this.Splitter1.TabStop = false;
      componentResourceManager.ApplyResources((object) this.pnleHeaderRight, "pnleHeaderRight");
      this.pnleHeaderRight.Controls.Add((Control) this.btnHQ);
      this.pnleHeaderRight.Controls.Add((Control) this.btnCloseRight);
      this.pnleHeaderRight.Controls.Add((Control) this.lblRightTitle);
      this.pnleHeaderRight.Name = "pnleHeaderRight";
      componentResourceManager.ApplyResources((object) this.btnHQ, "btnHQ");
      this.btnHQ.Cursor = Cursors.Hand;
      this.btnHQ.Name = "btnHQ";
      componentResourceManager.ApplyResources((object) this.btnCloseRight, "btnCloseRight");
      this.btnCloseRight.Cursor = Cursors.Hand;
      this.btnCloseRight.Name = "btnCloseRight";
      this.lblRightTitle.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.lblRightTitle, "lblRightTitle");
      this.lblRightTitle.ForeColor = Color.White;
      this.lblRightTitle.Name = "lblRightTitle";
      this.pnlButtonsRight.BackColor = Color.White;
      this.pnlButtonsRight.Controls.Add((Control) this.btnGoBack);
      this.pnlButtonsRight.Controls.Add((Control) this.btnSave);
      componentResourceManager.ApplyResources((object) this.pnlButtonsRight, "pnlButtonsRight");
      this.pnlButtonsRight.Name = "pnlButtonsRight";
      this.btnGoBack.BackColor = SystemColors.Control;
      componentResourceManager.ApplyResources((object) this.btnGoBack, "btnGoBack");
      this.btnGoBack.Name = "btnGoBack";
      this.btnGoBack.UseVisualStyleBackColor = false;
      componentResourceManager.ApplyResources((object) this.btnSave, "btnSave");
      this.btnSave.BackColor = SystemColors.Control;
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.Name = "btnSave";
      this.btnSave.UseVisualStyleBackColor = false;
      componentResourceManager.ApplyResources((object) this.splitMiddleAndRight, "splitMiddleAndRight");
      this.splitMiddleAndRight.Name = "splitMiddleAndRight";
      this.splitMiddleAndRight.TabStop = false;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.BackColor = Color.Gainsboro;
      this.Controls.Add((Control) this.splitMiddleAndRight);
      this.Controls.Add((Control) this.pnlRight);
      this.Controls.Add((Control) this.pnlMiddle);
      this.Controls.Add((Control) this.splitLeftAndMiddle);
      this.Controls.Add((Control) this.pnlLeft);
      this.Controls.Add((Control) this.infoBar);
      this.IsMdiContainer = true;
      this.Menu = this.MnuMainNav;
      this.Name = nameof (FRMMain);
      this.ShowIcon = false;
      this.WindowState = FormWindowState.Maximized;
      this.pnlMiddle.ResumeLayout(false);
      this.dgSearchResults.EndInit();
      this.pnlMiddleTitle.ResumeLayout(false);
      this.pnlButtons.ResumeLayout(false);
      this.ContainerMiddlePanelBtns.ResumeLayout(false);
      this.pnlRight.ResumeLayout(false);
      this.pnleHeaderRight.ResumeLayout(false);
      this.pnlButtonsRight.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      UCSideBar ucSideBar = new UCSideBar();
      ucSideBar.Dock = DockStyle.Fill;
      this.pnlLeft.Controls.Add((Control) ucSideBar);
      this._FormButtons = new ArrayList();
      this.LoopControls((Control) this);
      this.SetupButtonMouseOvers();
      this.UpdateMessage();
      this.mnuNpPrint.Visible = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.NeopostPrint);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    public ArrayList FormButtons
    {
      get
      {
        return this._FormButtons;
      }
      set
      {
        this._FormButtons = value;
      }
    }

    public UCSideBar MenuBar
    {
      get
      {
        return (UCSideBar) this.pnlLeft.Controls[0];
      }
    }

    public Enums.MenuTypes SelectedMenu
    {
      get
      {
        return this._SelectedMenu;
      }
      set
      {
        this._SelectedMenu = value;
      }
    }

    public Enums.PageViewing Page
    {
      get
      {
        return this._Page;
      }
      set
      {
        this._Page = value;
      }
    }

    private DataView SearchResults
    {
      get
      {
        return this._dvSearchResults;
      }
      set
      {
        this._dvSearchResults = value;
        this._dvSearchResults.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
        this._dvSearchResults.AllowNew = false;
        this._dvSearchResults.AllowEdit = false;
        this._dvSearchResults.AllowDelete = false;
        this.dgSearchResults.DataSource = (object) this.SearchResults;
      }
    }

    private DataRow SelectedSearchResultDataRow
    {
      get
      {
        return this.dgSearchResults.CurrentRowIndex != -1 ? this.SearchResults[this.dgSearchResults.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private bool Exporting
    {
      get
      {
        return this._Exporting;
      }
      set
      {
        this._Exporting = value;
      }
    }

    public string SearchText
    {
      get
      {
        return this._SearchText;
      }
      set
      {
        this._SearchText = value;
      }
    }

    private void FRMMenu_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void FRMMenu_Closing(object sender, CancelEventArgs e)
    {
      e.Cancel = true;
      App.Logout();
    }

    private void FRMMenu_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        if (e.KeyCode != Keys.Escape)
          return;
        App.Logout();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Action cannot be completed : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void mnuChangeLogin_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.NONE);
      App.ShowForm(typeof (FRMChangePassword), false, (object[]) null, false);
    }

    private void mnuLogout_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.NONE);
      App.Logout();
    }

    private void mnuCustomers_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.Customers);
    }

    private void mnuSpares_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.Spares);
    }

    private void mnuStaff_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.Staff);
    }

    private void mnuJobs_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.Jobs);
    }

    private void mnuScheduler_Click(object sender, EventArgs e)
    {
      new frmSchedulerMain().Show();
    }

    private void mnuInvoicing_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.Invoicing);
    }

    private void mnuReports_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.Reports);
    }

    private void mnuVan_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.FleetVan);
    }

    private void mnuSetup_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.Setup);
    }

    private void mnuAbout_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.NONE);
      App.ShowForm(typeof (FRMAbout), false, (object[]) null, false);
    }

    private void mnuContactSheet_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.NONE);
      App.ShowForm(typeof (FRMContactDetails), false, (object[]) null, false);
    }

    private void btnCloseMiddle_Click(object sender, EventArgs e)
    {
      Navigation.Close_Middle();
      App.CurrentCustomerID = 0;
      App.CurrentPropertyID = 0;
    }

    private void btnCloseRight_Click(object sender, EventArgs e)
    {
      Navigation.Close_Right();
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      this.Add();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      this.Delete();
    }

    private void dgSearchResults_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      this.View();
      this.Cursor = Cursors.Default;
    }

    private void dgSearchResults_DoubleClick(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      this.Open();
      this.Cursor = Cursors.Default;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnGoBack_Click(object sender, EventArgs e)
    {
      if (this.Page == Enums.PageViewing.Asset)
      {
        int propertyId = ((Asset) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).PropertyID;
        this.SetSearchResults(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, false, false, "");
        this.SearchResults.RowFilter = "SiteID =" + Conversions.ToString(propertyId);
        this.dgSearchResults.Select(0);
        this.dgSearchResults_Click(RuntimeHelpers.GetObjectValue(sender), e);
      }
      else if (this.Page == Enums.PageViewing.Property)
      {
        int customerId = ((FSM.Entity.Sites.Site) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).CustomerID;
        this.SetSearchResults(App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID), Enums.PageViewing.Customer, false, false, "");
        this.SearchResults.RowFilter = "CustomerID =" + Conversions.ToString(customerId);
        this.dgSearchResults.Select(0);
        this.dgSearchResults_Click(RuntimeHelpers.GetObjectValue(sender), e);
      }
      else
        this.btnGoBack.Visible = false;
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      switch (this.Page)
      {
        case Enums.PageViewing.Property:
          this.Exporting = true;
          DataTable dtData1 = new DataTable();
          dtData1.Columns.Add("Customer");
          dtData1.Columns.Add("Name");
          dtData1.Columns.Add("Address 1");
          dtData1.Columns.Add("Address 2");
          dtData1.Columns.Add("Address 3");
          dtData1.Columns.Add("Postcode");
          dtData1.Columns.Add("Telephone");
          dtData1.Columns.Add("Mobile");
          dtData1.Columns.Add("Email");
          dtData1.Columns.Add("Date added to system", System.Type.GetType("System.DateTime"));
          dtData1.Columns.Add("SiteFuel");
          dtData1.Columns.Add("PolicyNumber");
          dtData1.Columns.Add("LastServiceDate");
          IEnumerator enumerator1;
          try
          {
            enumerator1 = ((DataView) this.dgSearchResults.DataSource).GetEnumerator();
            while (enumerator1.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator1.Current;
              DataRow row = dtData1.NewRow();
              row["Customer"] = RuntimeHelpers.GetObjectValue(current["CustomerName"]);
              row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
              row["Address 1"] = RuntimeHelpers.GetObjectValue(current["Address1"]);
              row["Address 2"] = RuntimeHelpers.GetObjectValue(current["Address2"]);
              row["Address 3"] = RuntimeHelpers.GetObjectValue(current["Address3"]);
              row["Postcode"] = RuntimeHelpers.GetObjectValue(current["Postcode"]);
              row["Telephone"] = RuntimeHelpers.GetObjectValue(current["TelephoneNum"]);
              row["Mobile"] = RuntimeHelpers.GetObjectValue(current["FaxNum"]);
              row["Email"] = RuntimeHelpers.GetObjectValue(current["EmailAddress"]);
              row["Date added to system"] = (object) Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(current["SiteAddedOnDateTime"]), "dd/MM/yyyy"));
              row["SiteFuel"] = RuntimeHelpers.GetObjectValue(current["SiteFuel"]);
              row["PolicyNumber"] = RuntimeHelpers.GetObjectValue(current["PolicyNumber"]);
              row["LastServiceDate"] = RuntimeHelpers.GetObjectValue(current["LastServiceDate"]);
              dtData1.Rows.Add(row);
            }
          }
          finally
          {
            if (enumerator1 is IDisposable)
              (enumerator1 as IDisposable).Dispose();
          }
          ExportHelper.Export(dtData1, "Properties", Enums.ExportType.XLS);
          this.Exporting = false;
          break;
        case Enums.PageViewing.Engineer:
          DataTable dtData2 = new DataTable();
          dtData2.Columns.Add("Name");
          dtData2.Columns.Add("Department");
          dtData2.Columns.Add("EngineerID");
          dtData2.Columns.Add("Region");
          dtData2.Columns.Add("TelephoneNum");
          dtData2.Columns.Add("Technician");
          dtData2.Columns.Add("Supervisor");
          IEnumerator enumerator2;
          try
          {
            enumerator2 = ((DataView) this.dgSearchResults.DataSource).GetEnumerator();
            while (enumerator2.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator2.Current;
              DataRow row = dtData2.NewRow();
              row["Name"] = RuntimeHelpers.GetObjectValue(current["Name"]);
              row["Department"] = RuntimeHelpers.GetObjectValue(current["Department"]);
              row["EngineerID"] = RuntimeHelpers.GetObjectValue(current["EngineerID"]);
              row["Region"] = RuntimeHelpers.GetObjectValue(current["Region"]);
              row["TelephoneNum"] = RuntimeHelpers.GetObjectValue(current["TelephoneNum"]);
              row["Technician"] = RuntimeHelpers.GetObjectValue(current["Technician"]);
              row["Supervisor"] = RuntimeHelpers.GetObjectValue(current["Supervisor"]);
              dtData2.Rows.Add(row);
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
          ExportHelper.Export(dtData2, "Engineers", Enums.ExportType.XLS);
          break;
        case Enums.PageViewing.FleetVan:
          ExportHelper.Export(App.DB.FleetVan.GetAll().Table, "Fleet Vans", Enums.ExportType.XLS);
          break;
      }
    }

    private void LoopControls(Control controlToLoop)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = controlToLoop.Controls.GetEnumerator();
        while (enumerator.MoveNext())
        {
          Control current = (Control) enumerator.Current;
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "TabControl", false) == 0)
            this.LoopControls(current);
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "TabPage", false) == 0)
          {
            ((TabPage) current).BackColor = Color.White;
            this.LoopControls(current);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "GroupBox", false) == 0)
          {
            ((GroupBox) current).FlatStyle = FlatStyle.System;
            this.LoopControls(current);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "Panel", false) == 0)
            this.LoopControls(current);
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "Button", false) == 0)
          {
            ((ButtonBase) current).FlatStyle = FlatStyle.Standard;
            current.Cursor = Cursors.Hand;
            ((ButtonBase) current).UseVisualStyleBackColor = false;
            ((ButtonBase) current).BackColor = SystemColors.Control;
            current.AccessibleDescription = ((ButtonBase) current).Text;
            this.FormButtons.Add((object) current);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "ComboBox", false) == 0)
          {
            ((ComboBox) current).DropDownStyle = ComboBoxStyle.DropDownList;
            current.Cursor = Cursors.Hand;
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "CheckBox", false) == 0)
          {
            ((ButtonBase) current).FlatStyle = FlatStyle.System;
            current.Cursor = Cursors.Hand;
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "NumericUpDown", false) == 0)
            current.Cursor = Cursors.Hand;
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "DataGrid", false) == 0)
          {
            Helper.SetUpDataGrid((DataGrid) current, false);
            DataGridTableStyle tableStyle = ((DataGrid) current).TableStyles[0];
            tableStyle.ReadOnly = true;
            tableStyle.MappingName = Enums.TableNames.NO_TABLE.ToString();
            ((DataGrid) current).TableStyles.Add(tableStyle);
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(current.GetType().Name, "UCButton", false) == 0)
          {
            ((ButtonBase) current).FlatStyle = FlatStyle.Standard;
            current.Cursor = Cursors.Hand;
            ((ButtonBase) current).UseVisualStyleBackColor = false;
            ((ButtonBase) current).BackColor = SystemColors.Control;
            current.AccessibleDescription = ((ButtonBase) current).Text;
            this.FormButtons.Add((object) current);
          }
          else if (current.GetType().IsSubclassOf(typeof (UCBase)))
            this.LoopControls(current);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void SetupButtonMouseOvers()
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.FormButtons.GetEnumerator();
        while (enumerator.MoveNext())
          ((Control) RuntimeHelpers.GetObjectValue(enumerator.Current)).MouseHover += new EventHandler(this.CreateHover);
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void CreateHover(object sender, EventArgs e)
    {
      Button btn = (Button) sender;
      Helper.Setup_Button(ref btn, ((Control) sender).AccessibleDescription);
      sender = (object) btn;
    }

    public void SetSearchResults(
      DataView dv,
      Enums.PageViewing pageIn,
      bool FromASave,
      bool FromADelete = false,
      string ExtraText = "")
    {
      this.SetupSearchResultsDataGrid(dv, pageIn, FromASave, FromADelete, ExtraText);
    }

    public void UpdateMessage()
    {
      this.Text = App.TheSystem.Configuration.CompanyName + " " + this.Text + " v." + App.TheSystem.Configuration.SystemVersion;
      this.infoBar.Text = "Welcome " + App.loggedInUser.Fullname + ". " + App.DB.User.LastLogon(App.loggedInUser.UserID);
      switch (App.TheSystem.Configuration.DBName)
      {
        case Enums.DataBaseName.GaswayServicesFSM_Beta:
        case Enums.DataBaseName.RftFsm_Beta:
        case Enums.DataBaseName.BlueflameServicesFsm_Beta:
          StatusBar infoBar;
          string str = (infoBar = this.infoBar).Text + " THIS IS THE BETA DATABASE";
          infoBar.Text = str;
          if (this.pnlLeft.Controls.Count <= 0)
            break;
          IEnumerator enumerator;
          try
          {
            enumerator = this.pnlLeft.Controls.GetEnumerator();
            while (enumerator.MoveNext())
              ((Control) enumerator.Current).BackColor = Color.LightGoldenrodYellow;
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          break;
      }
    }

    private void SetupSearchResultsDataGrid(
      DataView dv,
      Enums.PageViewing pageIn,
      bool FromASave = true,
      bool FromADelete = false,
      string ExtraText = "")
    {
      if (FromASave)
        this.pnlRight.Visible = true;
      else if (FromADelete)
      {
        App.MainForm.pnlRight.Visible = false;
        App.MainForm.pnlContent.Controls.Clear();
      }
      else if (!Navigation.Close_Right())
        return;
      this.Page = pageIn;
      DataGridTableStyle tableStyle = this.dgSearchResults.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.btnAddNew.Enabled = true;
      this.btnDelete.Visible = true;
      this.btnAddNew.Visible = true;
      this.btnGoBack.Visible = false;
      this.btnExport.Visible = false;
      this.btnHQ.Visible = false;
      switch (this.Page)
      {
        case Enums.PageViewing.Supplier:
          DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
          dataGridLabelColumn1.Format = "";
          dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn1.HeaderText = "Name";
          dataGridLabelColumn1.MappingName = "Name";
          dataGridLabelColumn1.ReadOnly = true;
          dataGridLabelColumn1.Width = 120;
          dataGridLabelColumn1.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
          DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
          dataGridLabelColumn2.Format = "";
          dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn2.HeaderText = "Address 1";
          dataGridLabelColumn2.MappingName = "Address1";
          dataGridLabelColumn2.ReadOnly = true;
          dataGridLabelColumn2.Width = 100;
          dataGridLabelColumn2.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
          DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
          dataGridLabelColumn3.Format = "";
          dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn3.HeaderText = "Postcode";
          dataGridLabelColumn3.MappingName = "Postcode";
          dataGridLabelColumn3.ReadOnly = true;
          dataGridLabelColumn3.Width = 100;
          dataGridLabelColumn3.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
          DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
          dataGridLabelColumn4.Format = "";
          dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn4.HeaderText = "Tel";
          dataGridLabelColumn4.MappingName = "TelephoneNum";
          dataGridLabelColumn4.ReadOnly = true;
          dataGridLabelColumn4.Width = 100;
          dataGridLabelColumn4.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
          this.lblMiddleTitle.Text = "Suppliers";
          break;
        case Enums.PageViewing.Customer:
          DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
          dataGridLabelColumn5.Format = "";
          dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn5.HeaderText = "Name";
          dataGridLabelColumn5.MappingName = "Name";
          dataGridLabelColumn5.ReadOnly = true;
          dataGridLabelColumn5.Width = 200;
          dataGridLabelColumn5.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
          DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
          dataGridLabelColumn6.Format = "";
          dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn6.HeaderText = "Account Number";
          dataGridLabelColumn6.MappingName = "AccountNumber";
          dataGridLabelColumn6.ReadOnly = true;
          dataGridLabelColumn6.Width = 140;
          dataGridLabelColumn6.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
          DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
          dataGridLabelColumn7.Format = "";
          dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn7.HeaderText = "Region";
          dataGridLabelColumn7.MappingName = "Region";
          dataGridLabelColumn7.ReadOnly = true;
          dataGridLabelColumn7.Width = 140;
          dataGridLabelColumn7.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
          this.lblMiddleTitle.Text = "Customers";
          break;
        case Enums.PageViewing.Product:
          DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
          dataGridLabelColumn8.Format = "";
          dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn8.HeaderText = "Description";
          dataGridLabelColumn8.MappingName = "typemakemodel";
          dataGridLabelColumn8.ReadOnly = true;
          dataGridLabelColumn8.Width = 200;
          dataGridLabelColumn8.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
          DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
          dataGridLabelColumn9.Format = "";
          dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn9.HeaderText = "GC Number";
          dataGridLabelColumn9.MappingName = "Number";
          dataGridLabelColumn9.ReadOnly = true;
          dataGridLabelColumn9.Width = 120;
          dataGridLabelColumn9.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
          DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
          dataGridLabelColumn10.Format = "";
          dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn10.HeaderText = "Reference";
          dataGridLabelColumn10.MappingName = "Reference";
          dataGridLabelColumn10.ReadOnly = true;
          dataGridLabelColumn10.Width = 120;
          dataGridLabelColumn10.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
          this.lblMiddleTitle.Text = "Products";
          break;
        case Enums.PageViewing.Part:
          DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
          dataGridLabelColumn11.Format = "";
          dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn11.HeaderText = "Name";
          dataGridLabelColumn11.MappingName = "Name";
          dataGridLabelColumn11.ReadOnly = true;
          dataGridLabelColumn11.Width = 130;
          dataGridLabelColumn11.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
          DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
          dataGridLabelColumn12.Format = "";
          dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn12.HeaderText = "Number (MPN)";
          dataGridLabelColumn12.MappingName = "Number";
          dataGridLabelColumn12.ReadOnly = true;
          dataGridLabelColumn12.Width = 130;
          dataGridLabelColumn12.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
          DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
          dataGridLabelColumn13.Format = "";
          dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn13.HeaderText = "Reference";
          dataGridLabelColumn13.MappingName = "Reference";
          dataGridLabelColumn13.ReadOnly = true;
          dataGridLabelColumn13.Width = 130;
          dataGridLabelColumn13.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
          DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
          dataGridLabelColumn14.Format = "";
          dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn14.HeaderText = "Qty";
          dataGridLabelColumn14.MappingName = "WarehouseQuantity";
          dataGridLabelColumn14.ReadOnly = true;
          dataGridLabelColumn14.Width = 50;
          dataGridLabelColumn14.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
          DataGridLabelColumn dataGridLabelColumn15 = new DataGridLabelColumn();
          dataGridLabelColumn15.Format = "";
          dataGridLabelColumn15.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn15.HeaderText = "Unit Type";
          dataGridLabelColumn15.MappingName = "UnitType";
          dataGridLabelColumn15.ReadOnly = true;
          dataGridLabelColumn15.Width = 130;
          dataGridLabelColumn15.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn15);
          DataGridLabelColumn dataGridLabelColumn16 = new DataGridLabelColumn();
          dataGridLabelColumn16.Format = "C";
          dataGridLabelColumn16.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn16.HeaderText = "Sell Price";
          dataGridLabelColumn16.MappingName = "SellPrice";
          dataGridLabelColumn16.ReadOnly = true;
          dataGridLabelColumn16.Width = 120;
          dataGridLabelColumn16.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn16);
          this.lblMiddleTitle.Text = "Parts";
          break;
        case Enums.PageViewing.Property:
          this.btnHQ.Visible = true;
          this.btnGoBack.Text = "Go to Customer";
          this.btnGoBack.Visible = true;
          this.btnExport.Visible = false;
          DataGridLabelColumn dataGridLabelColumn17 = new DataGridLabelColumn();
          dataGridLabelColumn17.Format = "";
          dataGridLabelColumn17.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn17.HeaderText = "Name";
          dataGridLabelColumn17.MappingName = "Name";
          dataGridLabelColumn17.ReadOnly = true;
          dataGridLabelColumn17.Width = 100;
          dataGridLabelColumn17.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn17);
          DataGridLabelColumn dataGridLabelColumn18 = new DataGridLabelColumn();
          dataGridLabelColumn18.Format = "";
          dataGridLabelColumn18.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn18.HeaderText = "Address 1";
          dataGridLabelColumn18.MappingName = "Address1";
          dataGridLabelColumn18.ReadOnly = true;
          dataGridLabelColumn18.Width = 100;
          dataGridLabelColumn18.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn18);
          DataGridLabelColumn dataGridLabelColumn19 = new DataGridLabelColumn();
          dataGridLabelColumn19.Format = "";
          dataGridLabelColumn19.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn19.HeaderText = "Address 2";
          dataGridLabelColumn19.MappingName = "Address2";
          dataGridLabelColumn19.ReadOnly = true;
          dataGridLabelColumn19.Width = 100;
          dataGridLabelColumn19.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn19);
          DataGridLabelColumn dataGridLabelColumn20 = new DataGridLabelColumn();
          dataGridLabelColumn20.Format = "";
          dataGridLabelColumn20.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn20.HeaderText = "Postcode";
          dataGridLabelColumn20.MappingName = "Postcode";
          dataGridLabelColumn20.ReadOnly = true;
          dataGridLabelColumn20.Width = 75;
          dataGridLabelColumn20.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn20);
          DataGridLabelColumn dataGridLabelColumn21 = new DataGridLabelColumn();
          dataGridLabelColumn21.Format = "";
          dataGridLabelColumn21.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn21.HeaderText = "HO";
          dataGridLabelColumn21.MappingName = "HeadOfficeResult";
          dataGridLabelColumn21.ReadOnly = true;
          dataGridLabelColumn21.Width = 75;
          dataGridLabelColumn21.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn21);
          DataGridLabelColumn dataGridLabelColumn22 = new DataGridLabelColumn();
          dataGridLabelColumn22.Format = "";
          dataGridLabelColumn22.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn22.HeaderText = "Region";
          dataGridLabelColumn22.MappingName = "Region";
          dataGridLabelColumn22.ReadOnly = true;
          dataGridLabelColumn22.Width = 100;
          dataGridLabelColumn22.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn22);
          DataGridLabelColumn dataGridLabelColumn23 = new DataGridLabelColumn();
          dataGridLabelColumn23.Format = "";
          dataGridLabelColumn23.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn23.HeaderText = "SiteFuel";
          dataGridLabelColumn23.MappingName = "SiteFuel";
          dataGridLabelColumn23.ReadOnly = true;
          dataGridLabelColumn23.Width = 100;
          dataGridLabelColumn23.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn23);
          DataGridLabelColumn dataGridLabelColumn24 = new DataGridLabelColumn();
          dataGridLabelColumn24.Format = "";
          dataGridLabelColumn24.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn24.HeaderText = "PolicyNumber";
          dataGridLabelColumn24.MappingName = "PolicyNumber";
          dataGridLabelColumn24.ReadOnly = true;
          dataGridLabelColumn24.Width = 100;
          dataGridLabelColumn24.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn24);
          DataGridLabelColumn dataGridLabelColumn25 = new DataGridLabelColumn();
          dataGridLabelColumn25.Format = "";
          dataGridLabelColumn25.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn25.HeaderText = "Last Service Date";
          dataGridLabelColumn25.MappingName = "LastServiceDate";
          dataGridLabelColumn25.ReadOnly = true;
          dataGridLabelColumn25.Width = 100;
          dataGridLabelColumn25.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn25);
          this.lblMiddleTitle.Text = ExtraText.Trim().Length <= 0 ? "Properties" : "Properties For " + ExtraText;
          break;
        case Enums.PageViewing.Engineer:
          DataGridLabelColumn dataGridLabelColumn26 = new DataGridLabelColumn();
          dataGridLabelColumn26.Format = "";
          dataGridLabelColumn26.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn26.HeaderText = "Name";
          dataGridLabelColumn26.MappingName = "Name";
          dataGridLabelColumn26.ReadOnly = true;
          dataGridLabelColumn26.Width = 160;
          dataGridLabelColumn26.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn26);
          DataGridLabelColumn dataGridLabelColumn27 = new DataGridLabelColumn();
          dataGridLabelColumn27.Format = "";
          dataGridLabelColumn27.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn27.HeaderText = "Engineer ID";
          dataGridLabelColumn27.MappingName = "EngineerID";
          dataGridLabelColumn27.ReadOnly = true;
          dataGridLabelColumn27.Width = 80;
          dataGridLabelColumn27.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn27);
          DataGridLabelColumn dataGridLabelColumn28 = new DataGridLabelColumn();
          dataGridLabelColumn28.Format = "";
          dataGridLabelColumn28.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn28.HeaderText = "Region";
          dataGridLabelColumn28.MappingName = "Region";
          dataGridLabelColumn28.ReadOnly = true;
          dataGridLabelColumn28.Width = 120;
          dataGridLabelColumn28.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn28);
          DataGridLabelColumn dataGridLabelColumn29 = new DataGridLabelColumn();
          dataGridLabelColumn29.Format = "";
          dataGridLabelColumn29.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn29.HeaderText = "Telephone Number";
          dataGridLabelColumn29.MappingName = "TelephoneNum";
          dataGridLabelColumn29.ReadOnly = true;
          dataGridLabelColumn29.Width = 120;
          dataGridLabelColumn29.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn29);
          DataGridLabelColumn dataGridLabelColumn30 = new DataGridLabelColumn();
          dataGridLabelColumn30.Format = "";
          dataGridLabelColumn30.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn30.HeaderText = "Technician";
          dataGridLabelColumn30.MappingName = "Technician";
          dataGridLabelColumn30.ReadOnly = true;
          dataGridLabelColumn30.Width = 100;
          dataGridLabelColumn30.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn30);
          DataGridLabelColumn dataGridLabelColumn31 = new DataGridLabelColumn();
          dataGridLabelColumn31.Format = "";
          dataGridLabelColumn31.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn31.HeaderText = "Supervisor";
          dataGridLabelColumn31.MappingName = "Supervisor";
          dataGridLabelColumn31.ReadOnly = true;
          dataGridLabelColumn31.Width = 100;
          dataGridLabelColumn31.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn31);
          this.lblMiddleTitle.Text = "Engineers";
          this.btnExport.Visible = true;
          break;
        case Enums.PageViewing.Asset:
          this.btnGoBack.Text = "Go to Property";
          this.btnGoBack.Visible = true;
          DataGridLabelColumn dataGridLabelColumn32 = new DataGridLabelColumn();
          dataGridLabelColumn32.Format = "";
          dataGridLabelColumn32.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn32.HeaderText = "Product";
          dataGridLabelColumn32.MappingName = "Product";
          dataGridLabelColumn32.ReadOnly = true;
          dataGridLabelColumn32.Width = 150;
          dataGridLabelColumn32.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn32);
          DataGridLabelColumn dataGridLabelColumn33 = new DataGridLabelColumn();
          dataGridLabelColumn33.Format = "";
          dataGridLabelColumn33.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn33.HeaderText = "Location";
          dataGridLabelColumn33.MappingName = "Location";
          dataGridLabelColumn33.ReadOnly = true;
          dataGridLabelColumn33.Width = 100;
          dataGridLabelColumn33.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn33);
          DataGridLabelColumn dataGridLabelColumn34 = new DataGridLabelColumn();
          dataGridLabelColumn34.Format = "";
          dataGridLabelColumn34.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn34.HeaderText = "Serial";
          dataGridLabelColumn34.MappingName = "SerialNum";
          dataGridLabelColumn34.ReadOnly = true;
          dataGridLabelColumn34.Width = 150;
          dataGridLabelColumn34.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn34);
          this.lblMiddleTitle.Text = ExtraText.Trim().Length <= 0 ? "Appliances" : "Appliances For " + ExtraText;
          if (App.ViewingAllAssets)
          {
            this.btnAddNew.Enabled = false;
            break;
          }
          break;
        case Enums.PageViewing.Subcontractor:
          DataGridLabelColumn dataGridLabelColumn35 = new DataGridLabelColumn();
          dataGridLabelColumn35.Format = "";
          dataGridLabelColumn35.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn35.HeaderText = "Name";
          dataGridLabelColumn35.MappingName = "Name";
          dataGridLabelColumn35.ReadOnly = true;
          dataGridLabelColumn35.Width = 160;
          dataGridLabelColumn35.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn35);
          DataGridLabelColumn dataGridLabelColumn36 = new DataGridLabelColumn();
          dataGridLabelColumn36.Format = "";
          dataGridLabelColumn36.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn36.HeaderText = "Region";
          dataGridLabelColumn36.MappingName = "Region";
          dataGridLabelColumn36.ReadOnly = true;
          dataGridLabelColumn36.Width = 120;
          dataGridLabelColumn36.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn36);
          DataGridLabelColumn dataGridLabelColumn37 = new DataGridLabelColumn();
          dataGridLabelColumn37.Format = "";
          dataGridLabelColumn37.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn37.HeaderText = "Address1";
          dataGridLabelColumn37.MappingName = "Address1";
          dataGridLabelColumn37.ReadOnly = true;
          dataGridLabelColumn37.Width = 80;
          dataGridLabelColumn37.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn37);
          DataGridLabelColumn dataGridLabelColumn38 = new DataGridLabelColumn();
          dataGridLabelColumn38.Format = "";
          dataGridLabelColumn38.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn38.HeaderText = "Postcode";
          dataGridLabelColumn38.MappingName = "Postcode";
          dataGridLabelColumn38.ReadOnly = true;
          dataGridLabelColumn38.Width = 80;
          dataGridLabelColumn38.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn38);
          DataGridLabelColumn dataGridLabelColumn39 = new DataGridLabelColumn();
          dataGridLabelColumn39.Format = "";
          dataGridLabelColumn39.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn39.HeaderText = "Telephone Number";
          dataGridLabelColumn39.MappingName = "TelephoneNum";
          dataGridLabelColumn39.ReadOnly = true;
          dataGridLabelColumn39.Width = 120;
          dataGridLabelColumn39.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn39);
          this.lblMiddleTitle.Text = "Subcontractors";
          break;
        case Enums.PageViewing.Warehouse:
          DataGridLabelColumn dataGridLabelColumn40 = new DataGridLabelColumn();
          dataGridLabelColumn40.Format = "";
          dataGridLabelColumn40.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn40.HeaderText = "Name";
          dataGridLabelColumn40.MappingName = "Name";
          dataGridLabelColumn40.ReadOnly = true;
          dataGridLabelColumn40.Width = 100;
          dataGridLabelColumn40.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn40);
          DataGridLabelColumn dataGridLabelColumn41 = new DataGridLabelColumn();
          dataGridLabelColumn41.Format = "";
          dataGridLabelColumn41.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn41.HeaderText = "Size";
          dataGridLabelColumn41.MappingName = "Size";
          dataGridLabelColumn41.ReadOnly = true;
          dataGridLabelColumn41.Width = 80;
          dataGridLabelColumn41.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn41);
          DataGridLabelColumn dataGridLabelColumn42 = new DataGridLabelColumn();
          dataGridLabelColumn42.Format = "";
          dataGridLabelColumn42.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn42.HeaderText = "Address 1";
          dataGridLabelColumn42.MappingName = "Address1";
          dataGridLabelColumn42.ReadOnly = true;
          dataGridLabelColumn42.Width = 100;
          dataGridLabelColumn42.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn42);
          DataGridLabelColumn dataGridLabelColumn43 = new DataGridLabelColumn();
          dataGridLabelColumn43.Format = "";
          dataGridLabelColumn43.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn43.HeaderText = "Address 2";
          dataGridLabelColumn43.MappingName = "Address2";
          dataGridLabelColumn43.ReadOnly = true;
          dataGridLabelColumn43.Width = 100;
          dataGridLabelColumn43.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn43);
          DataGridLabelColumn dataGridLabelColumn44 = new DataGridLabelColumn();
          dataGridLabelColumn44.Format = "";
          dataGridLabelColumn44.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn44.HeaderText = "Postcode";
          dataGridLabelColumn44.MappingName = "Postcode";
          dataGridLabelColumn44.ReadOnly = true;
          dataGridLabelColumn44.Width = 75;
          dataGridLabelColumn44.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn44);
          this.lblMiddleTitle.Text = "Warehouses";
          break;
        case Enums.PageViewing.StockProfile:
          DataGridLabelColumn dataGridLabelColumn45 = new DataGridLabelColumn();
          dataGridLabelColumn45.Format = "";
          dataGridLabelColumn45.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn45.HeaderText = "Profile Name";
          dataGridLabelColumn45.MappingName = "Registration";
          dataGridLabelColumn45.ReadOnly = true;
          dataGridLabelColumn45.Width = 200;
          dataGridLabelColumn45.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn45);
          DataGridLabelColumn dataGridLabelColumn46 = new DataGridLabelColumn();
          dataGridLabelColumn46.Format = "";
          dataGridLabelColumn46.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn46.HeaderText = "Department";
          dataGridLabelColumn46.MappingName = "Department";
          dataGridLabelColumn46.ReadOnly = true;
          dataGridLabelColumn46.Width = 100;
          dataGridLabelColumn46.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn46);
          this.lblMiddleTitle.Text = "Stock Profiles";
          this.btnExport.Visible = true;
          this.btnDelete.Visible = true;
          break;
        case Enums.PageViewing.Equipment:
          DataGridLabelColumn dataGridLabelColumn47 = new DataGridLabelColumn();
          dataGridLabelColumn47.Format = "";
          dataGridLabelColumn47.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn47.HeaderText = "Equipment";
          dataGridLabelColumn47.MappingName = "Name";
          dataGridLabelColumn47.ReadOnly = true;
          dataGridLabelColumn47.Width = 160;
          dataGridLabelColumn47.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn47);
          DataGridLabelColumn dataGridLabelColumn48 = new DataGridLabelColumn();
          dataGridLabelColumn48.Format = "";
          dataGridLabelColumn48.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn48.HeaderText = "Serial";
          dataGridLabelColumn48.MappingName = "SerialNumber";
          dataGridLabelColumn48.ReadOnly = true;
          dataGridLabelColumn48.Width = 120;
          dataGridLabelColumn48.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn48);
          DataGridLabelColumn dataGridLabelColumn49 = new DataGridLabelColumn();
          dataGridLabelColumn49.Format = "";
          dataGridLabelColumn49.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn49.HeaderText = "Warranty";
          dataGridLabelColumn49.MappingName = "WarrantyEndDate";
          dataGridLabelColumn49.ReadOnly = true;
          dataGridLabelColumn49.Width = 120;
          dataGridLabelColumn49.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn49);
          this.lblMiddleTitle.Text = "Equipment";
          this.btnExport.Visible = true;
          break;
        case Enums.PageViewing.PartPack:
          DataGridLabelColumn dataGridLabelColumn50 = new DataGridLabelColumn();
          dataGridLabelColumn50.Format = "";
          dataGridLabelColumn50.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn50.HeaderText = "Pack Name";
          dataGridLabelColumn50.MappingName = "PackName";
          dataGridLabelColumn50.ReadOnly = true;
          dataGridLabelColumn50.Width = 250;
          dataGridLabelColumn50.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn50);
          this.lblMiddleTitle.Text = "Part Packs";
          break;
        case Enums.PageViewing.FleetVan:
          DataGridLabelColumn dataGridLabelColumn51 = new DataGridLabelColumn();
          dataGridLabelColumn51.Format = "";
          dataGridLabelColumn51.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn51.HeaderText = "Registration";
          dataGridLabelColumn51.MappingName = "Registration";
          dataGridLabelColumn51.ReadOnly = true;
          dataGridLabelColumn51.Width = 100;
          dataGridLabelColumn51.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn51);
          DataGridLabelColumn dataGridLabelColumn52 = new DataGridLabelColumn();
          dataGridLabelColumn52.Format = "";
          dataGridLabelColumn52.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn52.HeaderText = "Engineer";
          dataGridLabelColumn52.MappingName = "Name";
          dataGridLabelColumn52.ReadOnly = true;
          dataGridLabelColumn52.Width = 200;
          dataGridLabelColumn52.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn52);
          this.lblMiddleTitle.Text = "Fleet Vans";
          this.btnExport.Visible = true;
          break;
        case Enums.PageViewing.FleetVanType:
          DataGridLabelColumn dataGridLabelColumn53 = new DataGridLabelColumn();
          dataGridLabelColumn53.Format = "";
          dataGridLabelColumn53.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn53.HeaderText = "Make";
          dataGridLabelColumn53.MappingName = "Make";
          dataGridLabelColumn53.ReadOnly = true;
          dataGridLabelColumn53.Width = 140;
          dataGridLabelColumn53.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn53);
          DataGridLabelColumn dataGridLabelColumn54 = new DataGridLabelColumn();
          dataGridLabelColumn54.Format = "";
          dataGridLabelColumn54.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn54.HeaderText = "Model";
          dataGridLabelColumn54.MappingName = "Model";
          dataGridLabelColumn54.ReadOnly = true;
          dataGridLabelColumn54.Width = 210;
          dataGridLabelColumn54.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn54);
          this.lblMiddleTitle.Text = "Van Types";
          break;
        case Enums.PageViewing.FleetEquipment:
          DataGridLabelColumn dataGridLabelColumn55 = new DataGridLabelColumn();
          dataGridLabelColumn55.Format = "";
          dataGridLabelColumn55.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn55.HeaderText = "Name";
          dataGridLabelColumn55.MappingName = "Name";
          dataGridLabelColumn55.ReadOnly = true;
          dataGridLabelColumn55.Width = 140;
          dataGridLabelColumn55.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn55);
          DataGridLabelColumn dataGridLabelColumn56 = new DataGridLabelColumn();
          dataGridLabelColumn56.Format = "C";
          dataGridLabelColumn56.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn56.HeaderText = "Cost";
          dataGridLabelColumn56.MappingName = "Cost";
          dataGridLabelColumn56.ReadOnly = true;
          dataGridLabelColumn56.Width = 210;
          dataGridLabelColumn56.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn56);
          this.lblMiddleTitle.Text = "Fleet Equipment";
          break;
        case Enums.PageViewing.UserQuals:
          DataGridLabelColumn dataGridLabelColumn57 = new DataGridLabelColumn();
          dataGridLabelColumn57.Format = "";
          dataGridLabelColumn57.FormatInfo = (IFormatProvider) null;
          dataGridLabelColumn57.HeaderText = "Name";
          dataGridLabelColumn57.MappingName = "FullName";
          dataGridLabelColumn57.ReadOnly = true;
          dataGridLabelColumn57.Width = 125;
          dataGridLabelColumn57.NullText = "";
          tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn57);
          this.lblMiddleTitle.Text = "Users";
          this.btnAddNew.Visible = false;
          this.btnDelete.Visible = false;
          this.btnExport.Visible = false;
          break;
      }
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_TBLSearchResults.ToString();
      this.pnlMiddle.Visible = true;
      this.SearchResults = dv;
      if (this.Page == Enums.PageViewing.Property && !FromADelete && (uint) App.CurrentPropertyID > 0U)
      {
        int num = 0;
        IEnumerator enumerator;
        try
        {
          enumerator = this.SearchResults.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((DataRow) enumerator.Current)["SiteID"], (object) App.CurrentPropertyID, false))
              checked { ++num; }
            else
              break;
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.dgSearchResults.CurrentRowIndex = num;
      }
    }

    private void btnHQ_Click(object sender, EventArgs e)
    {
      FSM.Entity.Sites.Site site = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["CustomerID"]), SiteSQL.GetBy.CustomerHq, (object) null);
      if (site == null || !site.Exists)
      {
        int num1 = (int) App.ShowMessage("No head office has been assigned", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (site.SiteID == Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SiteID"])))
      {
        int num2 = (int) App.ShowMessage("This site is the head office", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        App.ShowForm(typeof (FRMSitePopup), true, new object[1]
        {
          (object) site.SiteID
        }, false);
    }

    private void Add()
    {
      switch (this.Page)
      {
        case Enums.PageViewing.Supplier:
          if (!App.loggedInUser.HasAccessToMulitpleModules(new List<Enums.SecuritySystemModules>()
          {
            Enums.SecuritySystemModules.Finance,
            Enums.SecuritySystemModules.Compliance
          }))
            throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMSupplier), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Customer:
          App.ShowForm(typeof (FRMCustomer), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Product:
          App.ShowForm(typeof (FRMProduct), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Part:
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CreateParts))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMPart), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Property:
          FSM.Entity.Customers.Customer customer = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
          if (customer != null && customer.Status == 3)
          {
            int num = (int) App.ShowMessage("Customer On Hold.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          }
          App.ShowForm(typeof (FRMSite), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Engineer:
          App.ShowForm(typeof (FRMEngineer), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Asset:
          App.ShowForm(typeof (FRMAsset), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Subcontractor:
          App.ShowForm(typeof (FRMSubcontractor), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Warehouse:
          App.ShowForm(typeof (FRMWarehouse), true, (object[]) null, false);
          break;
        case Enums.PageViewing.StockProfile:
          App.ShowForm(typeof (FRMVan), true, (object[]) null, false);
          break;
        case Enums.PageViewing.Equipment:
          App.ShowForm(typeof (FRMEquipment), true, (object[]) null, false);
          break;
        case Enums.PageViewing.PartPack:
          Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.CreateParts;
          if (!App.loggedInUser.HasAccessToModule(ssm))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          App.ShowForm(typeof (FRMPartPack), true, (object[]) null, false);
          break;
        case Enums.PageViewing.FleetVan:
          App.ShowForm(typeof (FRMFleetVan), true, (object[]) null, false);
          break;
        case Enums.PageViewing.FleetVanType:
          App.ShowForm(typeof (FRMFleetVanType), true, (object[]) null, false);
          break;
        case Enums.PageViewing.FleetEquipment:
          App.ShowForm(typeof (FRMFleetEquipment), true, (object[]) null, false);
          break;
      }
    }

    private void Delete()
    {
      if (this.SelectedSearchResultDataRow == null || App.ShowMessage("You are about to delete an item.\r\n\r\nDo you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.IT))
        throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      switch (this.Page)
      {
        case Enums.PageViewing.Supplier:
          App.DB.Supplier.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SupplierID"])));
          this.SetSearchResults(App.DB.Supplier.Supplier_GetAll(), Enums.PageViewing.Supplier, false, true, "");
          break;
        case Enums.PageViewing.Customer:
          int CustomerID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["CustomerID"]));
          if (App.DB.Customer.Customer_GetActiveSiteCount(CustomerID) == 0)
          {
            App.DB.Customer.Delete(CustomerID);
            this.SetSearchResults(App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID), Enums.PageViewing.Customer, false, true, "");
            break;
          }
          int num1 = (int) App.ShowMessage("This customer has active sites so cannot be deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        case Enums.PageViewing.Product:
          App.DB.Product.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["ProductID"])));
          this.SetSearchResults(App.DB.Product.Product_GetAll(), Enums.PageViewing.Product, false, true, "");
          break;
        case Enums.PageViewing.Part:
          int PartID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["PartID"]));
          if (App.DB.PartSupplier.Get_ByPartID(PartID).Table.Rows.Count > 0 & App.DB.Part.Stock_Get_Locations(PartID, 0).Table.Rows.Count > 0)
          {
            int num2 = (int) App.ShowMessage("This part has active suppliers and stock so cannot be deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          }
          App.DB.Part.Delete(PartID);
          ISearchControl control = (ISearchControl) this.MenuBar.pnlSearch.Controls[0];
          if (control != null)
          {
            control.Search();
            break;
          }
          break;
        case Enums.PageViewing.Property:
          if (App.DB.Sites.Site_CanItBeDeleted(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SiteID"]))).Table.Rows.Count > 0 && App.ShowMessage("This site has active jobs or orders\r\n\r\nDo you wish to continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            break;
          App.DB.Job.Job_Delete_BySite(Conversions.ToInteger(this.SelectedSearchResultDataRow["SiteID"]));
          App.DB.Sites.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SiteID"])));
          if (App.CurrentCustomerID == 0)
          {
            this.SetSearchResults(App.DB.Sites.GetAll_Light_New(App.loggedInUser.UserID), Enums.PageViewing.Property, false, true, "");
            break;
          }
          FSM.Entity.Customers.Customer customer1 = new FSM.Entity.Customers.Customer();
          FSM.Entity.Customers.Customer customer2 = App.DB.Customer.Customer_Get(App.CurrentCustomerID);
          this.SetSearchResults(App.DB.Sites.GetForCustomer_Light(App.CurrentCustomerID, App.loggedInUser.UserID), Enums.PageViewing.Property, false, true, customer2.Name + " (" + customer2.AccountNumber + ")");
          break;
        case Enums.PageViewing.Engineer:
          int num3 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EngineerID"]));
          DataView idAndStatusEnumId = App.DB.EngineerVisits.Get_ByEngineerIdAndStatusEnumId(num3, 5);
          idAndStatusEnumId.Table.Merge(App.DB.EngineerVisits.Get_ByEngineerIdAndStatusEnumId(num3, 6).Table);
          if (idAndStatusEnumId.Count > 1)
          {
            int num2 = (int) App.ShowMessage("This engineer has jobs that are scheduled/downloaded so cannot be deleted!\r\n\r\nAn export of their jobs will follow!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ExportHelper.Export(idAndStatusEnumId.Table, "Jobs", Enums.ExportType.XLS);
            break;
          }
          App.DB.Engineer.Delete(num3);
          this.SetSearchResults(App.DB.Engineer.Engineer_GetAll_NoSub(), Enums.PageViewing.Engineer, false, true, "");
          break;
        case Enums.PageViewing.Asset:
          App.DB.Asset.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["AssetID"])));
          if (App.CurrentPropertyID == 0)
          {
            this.SetSearchResults(App.DB.Asset.Asset_GetAll(App.loggedInUser.UserID), Enums.PageViewing.Asset, false, true, "");
            break;
          }
          FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
          FSM.Entity.Sites.Site site2 = App.DB.Sites.Get((object) App.CurrentPropertyID, SiteSQL.GetBy.SiteId, (object) null);
          FSM.Entity.Customers.Customer customer3 = new FSM.Entity.Customers.Customer();
          FSM.Entity.Customers.Customer customer4 = App.DB.Customer.Customer_Get(site2.CustomerID);
          this.SetSearchResults(App.DB.Asset.Asset_GetForSite(App.CurrentPropertyID), Enums.PageViewing.Asset, false, true, site2.Address1 + ", " + site2.Postcode + " (" + customer4.AccountNumber + ")");
          break;
        case Enums.PageViewing.Subcontractor:
          App.DB.SubContractor.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SubcontractorID"])));
          this.SetSearchResults(App.DB.SubContractor.Subcontractor_GetAll(), Enums.PageViewing.Subcontractor, false, true, "");
          break;
        case Enums.PageViewing.Warehouse:
          App.DB.Warehouse.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["WarehouseID"])));
          this.SetSearchResults(App.DB.Warehouse.Warehouse_GetAll(), Enums.PageViewing.Warehouse, false, true, "");
          break;
        case Enums.PageViewing.StockProfile:
          App.DB.Van.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanID"])), false);
          this.SetSearchResults(App.DB.Van.Van_GetAll(true), Enums.PageViewing.StockProfile, false, true, "");
          break;
        case Enums.PageViewing.Equipment:
          App.DB.Engineer.DeleteEquipment(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EquipmentID"])));
          this.SetSearchResults(App.DB.Engineer.Equipment_GetAll(), Enums.PageViewing.Equipment, false, true, "");
          break;
        case Enums.PageViewing.PartPack:
          App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE FROM tblPartPack WHERE PackID = ", this.SelectedSearchResultDataRow["PackID"])), true, false);
          this.SetSearchResults(App.DB.Part.PartPack_GetAll(), Enums.PageViewing.PartPack, false, true, "");
          break;
        case Enums.PageViewing.FleetVan:
          int num4 = (int) App.ShowMessage("Vans cannot be deleted, only returned", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        case Enums.PageViewing.FleetVanType:
          App.DB.FleetVanType.Delete(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanTypeID"])));
          this.SetSearchResults(App.DB.FleetVanType.GetAll(), Enums.PageViewing.FleetVanType, false, true, "");
          break;
        case Enums.PageViewing.FleetEquipment:
          int equipmentId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EquipmentID"]));
          if (App.DB.FleetEquipment.GetActiveCount(equipmentId) == 0)
          {
            App.DB.FleetEquipment.Delete(equipmentId);
            this.SetSearchResults(App.DB.FleetEquipment.GetAll(), Enums.PageViewing.FleetEquipment, false, true, "");
            break;
          }
          int num5 = (int) App.ShowMessage("This equipment is still in use by vans", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
      }
    }

    public void View()
    {
      if (this.Exporting || this.SelectedSearchResultDataRow == null)
        return;
      IUserControl userControl = (IUserControl) null;
      if (this.Page != Enums.PageViewing.Property)
        this.SearchText = "";
      switch (this.Page)
      {
        case Enums.PageViewing.Supplier:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SupplierID"])) == ((Supplier) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).SupplierID)
            return;
          this.lblRightTitle.Text = "Manage Supplier";
          userControl = (IUserControl) new UCSupplier();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SupplierID"])));
          break;
        case Enums.PageViewing.Customer:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["CustomerID"])) == ((FSM.Entity.Customers.Customer) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).CustomerID)
            return;
          this.lblRightTitle.Text = "Manage Customer";
          userControl = (IUserControl) new UCCustomer();
          App.CurrentCustomerID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["CustomerID"]));
          userControl.Populate(App.CurrentCustomerID);
          break;
        case Enums.PageViewing.Product:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["ProductID"])) == ((Product) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).ProductID)
            return;
          this.lblRightTitle.Text = "Manage Product";
          userControl = (IUserControl) new UCProduct();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["ProductID"])));
          break;
        case Enums.PageViewing.Part:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["PartID"])) == ((Part) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).PartID)
            return;
          this.lblRightTitle.Text = "Manage Part";
          userControl = (IUserControl) new UCPart();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["PartID"])));
          break;
        case Enums.PageViewing.Property:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SiteID"])) == ((FSM.Entity.Sites.Site) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).SiteID)
            return;
          FSM.Entity.Customers.Customer customer1 = new FSM.Entity.Customers.Customer();
          FSM.Entity.Customers.Customer forSiteId1 = App.DB.Customer.Customer_Get_ForSiteID(Conversions.ToInteger(this.SelectedSearchResultDataRow["SiteID"]));
          this.lblRightTitle.Text = "Manage Property for Customer: " + forSiteId1.Name + ", Acc: " + forSiteId1.AccountNumber;
          userControl = (IUserControl) new UCSite();
          App.CurrentPropertyID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SiteID"]));
          userControl.Populate(App.CurrentPropertyID);
          break;
        case Enums.PageViewing.Engineer:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EngineerID"])) == ((Engineer) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).EngineerID)
            return;
          this.lblRightTitle.Text = "Manage Engineer";
          userControl = (IUserControl) new UCEngineer();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EngineerID"])));
          break;
        case Enums.PageViewing.Asset:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["AssetID"])) == ((Asset) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).AssetID)
            return;
          FSM.Entity.Sites.Site site1 = new FSM.Entity.Sites.Site();
          FSM.Entity.Sites.Site site2 = App.DB.Sites.Get(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["AssetID"]), SiteSQL.GetBy.Asset, (object) null);
          FSM.Entity.Customers.Customer customer2 = new FSM.Entity.Customers.Customer();
          FSM.Entity.Customers.Customer forSiteId2 = App.DB.Customer.Customer_Get_ForSiteID(site2.SiteID);
          this.lblRightTitle.Text = "Manage Appliance for Property: " + site2.Name + ", " + site2.Postcode + ", Customer: " + forSiteId2.Name + ", Acc: " + forSiteId2.AccountNumber;
          userControl = (IUserControl) new UCAsset();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["AssetID"])));
          break;
        case Enums.PageViewing.Contact:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["ContactID"])) == ((Contact) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).ContactID)
            return;
          this.lblRightTitle.Text = "Manage Contact";
          userControl = (IUserControl) new UCContact();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["ContactID"])));
          break;
        case Enums.PageViewing.Subcontractor:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SubcontractorID"])) == ((Subcontractor) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).SubcontractorID)
            return;
          this.lblRightTitle.Text = "Manage Subcontractor";
          userControl = (IUserControl) new UCSubcontractor();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SubcontractorID"])));
          break;
        case Enums.PageViewing.Warehouse:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["WarehouseID"])) == ((Warehouse) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).WarehouseID)
            return;
          this.lblRightTitle.Text = "Manage Warehouse";
          userControl = (IUserControl) new UCWarehouse();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["WarehouseID"])));
          break;
        case Enums.PageViewing.StockProfile:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanID"])) == ((Van) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).VanID)
            return;
          this.lblRightTitle.Text = "Manage Van Stock Profiles";
          userControl = (IUserControl) new UCVan();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanID"])));
          break;
        case Enums.PageViewing.Equipment:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EquipmentID"])) == ((Equipment) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).EquipmentID)
            return;
          this.lblRightTitle.Text = "Manage Equipment";
          userControl = (IUserControl) new UCEquipment();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EquipmentID"])));
          break;
        case Enums.PageViewing.PartPack:
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["PackID"])) == ((UCPartPack) this.pnlContent.Controls[0]).PackID)
            return;
          this.lblRightTitle.Text = "Manage Part Pack";
          userControl = (IUserControl) new UCPartPack();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["PackID"])));
          break;
        case Enums.PageViewing.FleetVan:
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Fleet))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanID"])) == ((FleetVan) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).VanID)
            return;
          this.lblRightTitle.Text = "Manage Van";
          userControl = (IUserControl) new UCFleetVan();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanID"])));
          break;
        case Enums.PageViewing.FleetVanType:
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Fleet))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanTypeID"])) == ((FleetVanType) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).VanTypeID)
            return;
          this.lblRightTitle.Text = "Manage Van Type";
          userControl = (IUserControl) new UCFleetVanType();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanTypeID"])));
          break;
        case Enums.PageViewing.FleetEquipment:
          if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Fleet))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EquipmentID"])) == ((FleetEquipment) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).EquipmentID)
            return;
          this.lblRightTitle.Text = "Manage Equipment";
          userControl = (IUserControl) new UCFleetEquipment();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EquipmentID"])));
          break;
        case Enums.PageViewing.UserQuals:
          List<Enums.SecuritySystemModules> ssm = new List<Enums.SecuritySystemModules>()
          {
            Enums.SecuritySystemModules.Compliance,
            Enums.SecuritySystemModules.IT
          };
          if (!App.loggedInUser.HasAccessToMulitpleModules(ssm))
            throw new SecurityException("You do not have the necessary security permissions to access this feature.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
          if (this.pnlRight.Visible && this.pnlContent.Controls.Count > 0 && Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["UserID"])) == ((User) ((IUserControl) this.pnlContent.Controls[0]).LoadedItem).UserID)
            return;
          this.lblRightTitle.Text = "Manage User";
          userControl = (IUserControl) new UCUserQualification();
          userControl.Populate(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["UserID"])));
          break;
      }
      userControl.RecordsChanged += new IUserControl.RecordsChangedEventHandler(App.MainForm.SetSearchResults);
      this.pnlContent.Controls.Clear();
      this.pnlContent.Controls.Add((Control) userControl);
      Navigation.Show_Right();
    }

    private void Open()
    {
      if (this.SelectedSearchResultDataRow == null)
        return;
      switch (this.Page)
      {
        case Enums.PageViewing.Supplier:
          App.ShowForm(typeof (FRMSupplier), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SupplierID"]))
          }, false);
          break;
        case Enums.PageViewing.Customer:
          App.ShowForm(typeof (FRMCustomer), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["CustomerID"]))
          }, false);
          break;
        case Enums.PageViewing.Product:
          App.ShowForm(typeof (FRMProduct), true, new object[2]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["ProductID"])),
            (object) false
          }, false);
          break;
        case Enums.PageViewing.Part:
          App.ShowForm(typeof (FRMPart), true, new object[2]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["PartID"])),
            (object) false
          }, false);
          break;
        case Enums.PageViewing.Property:
          App.ShowForm(typeof (FRMSite), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SiteID"]))
          }, false);
          break;
        case Enums.PageViewing.Engineer:
          App.ShowForm(typeof (FRMEngineer), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["EngineerID"]))
          }, false);
          break;
        case Enums.PageViewing.Asset:
          App.ShowForm(typeof (FRMAsset), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["AssetID"]))
          }, false);
          break;
        case Enums.PageViewing.Subcontractor:
          App.ShowForm(typeof (FRMSubcontractor), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["SubcontractorID"]))
          }, false);
          break;
        case Enums.PageViewing.Warehouse:
          App.ShowForm(typeof (FRMWarehouse), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["WarehouseID"]))
          }, false);
          break;
        case Enums.PageViewing.StockProfile:
          App.ShowForm(typeof (FRMVan), true, new object[1]
          {
            (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSearchResultDataRow["VanID"]))
          }, false);
          break;
      }
    }

    private void Save()
    {
      ((IUserControl) this.pnlContent.Controls[0]).Save();
    }

    public void RefreshEntity(int id, string IDColumnName = "")
    {
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(IDColumnName, "", false) == 0)
      {
        if (this.SearchResults != null && this.SearchResults.Table.Rows.Count == 1)
          this.dgSearchResults.Select(0);
      }
      else
      {
        int num = 0;
        IEnumerator enumerator;
        try
        {
          enumerator = ((DataView) this.dgSearchResults.DataSource).Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            if (Conversions.ToInteger(((DataRow) enumerator.Current)[IDColumnName]) == id)
            {
              this.dgSearchResults.CurrentRowIndex = num;
              break;
            }
            checked { ++num; }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      this.View();
      if (this.pnlContent.Controls.Count <= 0)
        return;
      ((IUserControl) this.pnlContent.Controls[0]).Populate(id);
    }

    private void mnuUpstairs_Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        Cursor.Current = Cursors.WaitCursor;
        FileInfo fileInfo1 = new FileInfo(openFileDialog.FileName);
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(fileInfo1.Name), ".docx", false) > 0U)
          throw new Exception("Incorrect File Format");
        FileInfo fileInfo2 = new FileInfo(PrintHelper.ToPdf(fileInfo1.FullName, false, false));
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(fileInfo2.Name), ".pdf", false) > 0U)
          throw new Exception("Error converting to pdf");
        string str = "\\\\PHOCAS.gasway.co.uk\\Aggregator_IO\\Inputs\\Upstairs Documents\\";
        string extension = Path.GetExtension(fileInfo2.Name);
        File.Copy(fileInfo2.FullName, str + fileInfo2.Name.Replace(extension, "_" + DateAndTime.Now.ToString("ddMMyyHHmmss") + extension));
        File.Delete(fileInfo2.FullName);
        int num = (int) App.ShowMessage("File successfully copy to Upstairs Printer! ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        Cursor.Current = Cursors.Default;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("File data could not be printed : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        Cursor.Current = Cursors.Default;
        ProjectData.ClearProjectError();
      }
    }

    private void mnuDownstairs_Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        FileInfo fileInfo1 = new FileInfo(openFileDialog.FileName);
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(fileInfo1.Name), ".docx", false) > 0U)
          throw new Exception("Incorrect File Format");
        FileInfo fileInfo2 = new FileInfo(PrintHelper.ToPdf(fileInfo1.FullName, false, false));
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(fileInfo2.Name), ".pdf", false) > 0U)
          throw new Exception("Error converting to pdf");
        string str = "\\\\PHOCAS.gasway.co.uk\\Aggregator_IO\\Inputs\\Downstairs Documents\\";
        string extension = Path.GetExtension(fileInfo2.Name);
        File.Copy(fileInfo2.FullName, str + fileInfo2.Name.Replace(extension, "_" + DateAndTime.Now.ToString("ddMMyyHHmmss") + extension));
        File.Delete(fileInfo2.FullName);
        int num = (int) App.ShowMessage("File successfully copy to Downstairs Printer! ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("File data could not be printed : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void pnlMiddle_Resize(object sender, EventArgs e)
    {
      int width = this.pnlMiddle.Width;
      if (App.MainForm != null)
        Navigation.ResponsiveUI();
      Navigation.Show_Right();
    }
  }
}
