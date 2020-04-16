// Decompiled with JetBrains decompiler
// Type: FSM.FRMLogCallout
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContactAttempts;
using FSM.Entity.CustomerCharges;
using FSM.Entity.JobInstalls;
using FSM.Entity.Jobs;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMLogCallout : FRMBaseForm, IForm
  {
    private IContainer components;
    private UCDocumentsList DocumentsControl;
    private IUserControl TheLoadedControl;
    private DataView _Data;
    private int _ID;
    private Enums.FormState _pageState;
    private DataView _AssetsTable;
    private FSM.Entity.JobLock.JobLock _JobLock;
    private JobInstall _JI;
    private DataView _jobNotes;
    public bool quotecreated;
    public string quoteresult;
    private DataView _dvcontactAttempts;

    public FRMLogCallout()
    {
      this.Load += new EventHandler(this.FRMLogCallout_Load);
      this._ID = 0;
      this._AssetsTable = (DataView) null;
      this._jobNotes = (DataView) null;
      this.quotecreated = false;
      this.quoteresult = "";
      this._dvcontactAttempts = (DataView) null;
      this.InitializeComponent();
      this.TheLoadedControl = (IUserControl) new UCLogCallout();
      this.tpMain.Controls.Add((Control) this.TheLoadedControl);
      this.LoadedControl.StateChanged += new IUserControl.StateChangedEventHandler(this.ResetMe);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

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

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpMain { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnView
    {
      get
      {
        return this._btnView;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnView_Click);
        Button btnView1 = this._btnView;
        if (btnView1 != null)
          btnView1.Click -= eventHandler;
        this._btnView = value;
        Button btnView2 = this._btnView;
        if (btnView2 == null)
          return;
        btnView2.Click += eventHandler;
      }
    }

    internal virtual TabPage tpAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgAssets
    {
      get
      {
        return this._dgAssets;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgAssets_Click);
        DataGrid dgAssets1 = this._dgAssets;
        if (dgAssets1 != null)
          dgAssets1.Click -= eventHandler;
        this._dgAssets = value;
        DataGrid dgAssets2 = this._dgAssets;
        if (dgAssets2 == null)
          return;
        dgAssets2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddAppliance
    {
      get
      {
        return this._btnAddAppliance;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddAppliance_Click);
        Button btnAddAppliance1 = this._btnAddAppliance;
        if (btnAddAppliance1 != null)
          btnAddAppliance1.Click -= eventHandler;
        this._btnAddAppliance = value;
        Button btnAddAppliance2 = this._btnAddAppliance;
        if (btnAddAppliance2 == null)
          return;
        btnAddAppliance2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpAssets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox gpbNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgNotes
    {
      get
      {
        return this._dgNotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgNotes_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgNotes_Click);
        DataGrid dgNotes1 = this._dgNotes;
        if (dgNotes1 != null)
        {
          dgNotes1.Click -= eventHandler1;
          dgNotes1.CurrentCellChanged -= eventHandler2;
        }
        this._dgNotes = value;
        DataGrid dgNotes2 = this._dgNotes;
        if (dgNotes2 == null)
          return;
        dgNotes2.Click += eventHandler1;
        dgNotes2.CurrentCellChanged += eventHandler2;
      }
    }

    internal virtual Button btnAddNote
    {
      get
      {
        return this._btnAddNote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddNote_Click);
        Button btnAddNote1 = this._btnAddNote;
        if (btnAddNote1 != null)
          btnAddNote1.Click -= eventHandler;
        this._btnAddNote = value;
        Button btnAddNote2 = this._btnAddNote;
        if (btnAddNote2 == null)
          return;
        btnAddNote2.Click += eventHandler;
      }
    }

    internal virtual GroupBox gpbNotesDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNoteID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveNote
    {
      get
      {
        return this._btnSaveNote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveNote_Click);
        Button btnSaveNote1 = this._btnSaveNote;
        if (btnSaveNote1 != null)
          btnSaveNote1.Click -= eventHandler;
        this._btnSaveNote = value;
        Button btnSaveNote2 = this._btnSaveNote;
        if (btnSaveNote2 == null)
          return;
        btnSaveNote2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnDeleteNote
    {
      get
      {
        return this._btnDeleteNote;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteNote_Click);
        Button btnDeleteNote1 = this._btnDeleteNote;
        if (btnDeleteNote1 != null)
          btnDeleteNote1.Click -= eventHandler;
        this._btnDeleteNote = value;
        Button btnDeleteNote2 = this._btnDeleteNote;
        if (btnDeleteNote2 == null)
          return;
        btnDeleteNote2.Click += eventHandler;
      }
    }

    internal virtual TabPage tbquote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ContextMenuStrip cmsView { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem PropertyToolStripMenuItem
    {
      get
      {
        return this._PropertyToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.PropertyToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._PropertyToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._PropertyToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._PropertyToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem CustomerToolStripMenuItem
    {
      get
      {
        return this._CustomerToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CustomerToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._CustomerToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._CustomerToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._CustomerToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem AuditTrailToolStripMenuItem
    {
      get
      {
        return this._AuditTrailToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.AuditTrailToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._AuditTrailToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._AuditTrailToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._AuditTrailToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem OrdersToolStripMenuItem
    {
      get
      {
        return this._OrdersToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OrdersToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._OrdersToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._OrdersToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._OrdersToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem InvoiceToolStripMenuItem
    {
      get
      {
        return this._InvoiceToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.InvoiceToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._InvoiceToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._InvoiceToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._InvoiceToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem QuoteToolStripMenuItem
    {
      get
      {
        return this._QuoteToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.QuoteToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._QuoteToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._QuoteToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._QuoteToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem CostingsToolStripMenuItem
    {
      get
      {
        return this._CostingsToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CostingsToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._CostingsToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._CostingsToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._CostingsToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem HistoryToolStripMenuItem
    {
      get
      {
        return this._HistoryToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.HistoryToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._HistoryToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._HistoryToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._HistoryToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rdoAXA
    {
      get
      {
        return this._rdoAXA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoCust_CheckedChanged);
        RadioButton rdoAxa1 = this._rdoAXA;
        if (rdoAxa1 != null)
          rdoAxa1.CheckedChanged -= eventHandler;
        this._rdoAXA = value;
        RadioButton rdoAxa2 = this._rdoAXA;
        if (rdoAxa2 == null)
          return;
        rdoAxa2.CheckedChanged += eventHandler;
      }
    }

    internal virtual RadioButton rdoPOC
    {
      get
      {
        return this._rdoPOC;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.rdoCust_CheckedChanged);
        RadioButton rdoPoc1 = this._rdoPOC;
        if (rdoPoc1 != null)
          rdoPoc1.CheckedChanged -= eventHandler;
        this._rdoPOC = value;
        RadioButton rdoPoc2 = this._rdoPOC;
        if (rdoPoc2 == null)
          return;
        rdoPoc2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Panel Panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkExcludeVat { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVATRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVAT { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rbStandard { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton rbSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label46 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGridView dgvQuote { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLabour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnQuoteAdd
    {
      get
      {
        return this._btnQuoteAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnQuoteAdd_Click);
        Button btnQuoteAdd1 = this._btnQuoteAdd;
        if (btnQuoteAdd1 != null)
          btnQuoteAdd1.Click -= eventHandler;
        this._btnQuoteAdd = value;
        Button btnQuoteAdd2 = this._btnQuoteAdd;
        if (btnQuoteAdd2 == null)
          return;
        btnQuoteAdd2.Click += eventHandler;
      }
    }

    internal virtual Label Label45 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLabourQty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label44 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnReset
    {
      get
      {
        return this._btnReset;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnReset_Click);
        Button btnReset1 = this._btnReset;
        if (btnReset1 != null)
          btnReset1.Click -= eventHandler;
        this._btnReset = value;
        Button btnReset2 = this._btnReset;
        if (btnReset2 == null)
          return;
        btnReset2.Click += eventHandler;
      }
    }

    internal virtual Button btnaddtonotes
    {
      get
      {
        return this._btnaddtonotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnaddtonotes_Click);
        Button btnaddtonotes1 = this._btnaddtonotes;
        if (btnaddtonotes1 != null)
          btnaddtonotes1.Click -= eventHandler;
        this._btnaddtonotes = value;
        Button btnaddtonotes2 = this._btnaddtonotes;
        if (btnaddtonotes2 == null)
          return;
        btnaddtonotes2.Click += eventHandler;
      }
    }

    internal virtual Button btnEmail
    {
      get
      {
        return this._btnEmail;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnEmail_Click);
        Button btnEmail1 = this._btnEmail;
        if (btnEmail1 != null)
          btnEmail1.Click -= eventHandler;
        this._btnEmail = value;
        Button btnEmail2 = this._btnEmail;
        if (btnEmail2 == null)
          return;
        btnEmail2.Click += eventHandler;
      }
    }

    internal virtual Button btncalc
    {
      get
      {
        return this._btncalc;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btncalc_Click);
        Button btncalc1 = this._btncalc;
        if (btncalc1 != null)
          btncalc1.Click -= eventHandler;
        this._btncalc = value;
        Button btncalc2 = this._btncalc;
        if (btncalc2 == null)
          return;
        btncalc2.Click += eventHandler;
      }
    }

    internal virtual TextBox tbresult { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltc1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblnumber1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblpart1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtClaimLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tpContactAttempts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpContactAttemptDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContactAttemptDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblContactNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpContactAttempts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgContactAttempts
    {
      get
      {
        return this._dgContactAttempts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgContactAttempts_Click);
        DataGrid dgContactAttempts1 = this._dgContactAttempts;
        if (dgContactAttempts1 != null)
          dgContactAttempts1.Click -= eventHandler;
        this._dgContactAttempts = value;
        DataGrid dgContactAttempts2 = this._dgContactAttempts;
        if (dgContactAttempts2 == null)
          return;
        dgContactAttempts2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddAttempt
    {
      get
      {
        return this._btnAddAttempt;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddAttempt_Click);
        Button btnAddAttempt1 = this._btnAddAttempt;
        if (btnAddAttempt1 != null)
          btnAddAttempt1.Click -= eventHandler;
        this._btnAddAttempt = value;
        Button btnAddAttempt2 = this._btnAddAttempt;
        if (btnAddAttempt2 == null)
          return;
        btnAddAttempt2.Click += eventHandler;
      }
    }

    internal virtual Label lblClaimLimit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.btnClose = new Button();
      this.btnSave = new Button();
      this.TabControl1 = new TabControl();
      this.tpMain = new TabPage();
      this.tpAssets = new TabPage();
      this.grpAssets = new GroupBox();
      this.dgAssets = new DataGrid();
      this.btnAddAppliance = new Button();
      this.tpDocuments = new TabPage();
      this.tbquote = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.GroupBox1 = new GroupBox();
      this.rdoAXA = new RadioButton();
      this.rdoPOC = new RadioButton();
      this.Panel1 = new Panel();
      this.txtClaimLimit = new TextBox();
      this.lblClaimLimit = new Label();
      this.chkExcludeVat = new CheckBox();
      this.cboVATRate = new ComboBox();
      this.lblVAT = new Label();
      this.GroupBox3 = new GroupBox();
      this.rbStandard = new RadioButton();
      this.rbSite = new RadioButton();
      this.txtPartQty = new TextBox();
      this.Label46 = new Label();
      this.dgvQuote = new DataGridView();
      this.cboLabour = new ComboBox();
      this.btnQuoteAdd = new Button();
      this.Label45 = new Label();
      this.txtLabourQty = new TextBox();
      this.Label44 = new Label();
      this.btnReset = new Button();
      this.btnaddtonotes = new Button();
      this.btnEmail = new Button();
      this.btncalc = new Button();
      this.tbresult = new TextBox();
      this.txtPartRate = new TextBox();
      this.lbltc1 = new Label();
      this.txtPartNumber = new TextBox();
      this.lblnumber1 = new Label();
      this.txtPartName = new TextBox();
      this.lblpart1 = new Label();
      this.tpNotes = new TabPage();
      this.gpbNotesDetails = new GroupBox();
      this.txtNoteID = new TextBox();
      this.btnSaveNote = new Button();
      this.txtNotes = new TextBox();
      this.Label1 = new Label();
      this.gpbNotes = new GroupBox();
      this.btnDeleteNote = new Button();
      this.dgNotes = new DataGrid();
      this.btnAddNote = new Button();
      this.tpContactAttempts = new TabPage();
      this.grpContactAttemptDetails = new GroupBox();
      this.txtContactAttemptDetails = new TextBox();
      this.lblContactNotes = new Label();
      this.grpContactAttempts = new GroupBox();
      this.dgContactAttempts = new DataGrid();
      this.btnAddAttempt = new Button();
      this.btnView = new Button();
      this.cmsView = new ContextMenuStrip(this.components);
      this.PropertyToolStripMenuItem = new ToolStripMenuItem();
      this.CustomerToolStripMenuItem = new ToolStripMenuItem();
      this.AuditTrailToolStripMenuItem = new ToolStripMenuItem();
      this.OrdersToolStripMenuItem = new ToolStripMenuItem();
      this.InvoiceToolStripMenuItem = new ToolStripMenuItem();
      this.QuoteToolStripMenuItem = new ToolStripMenuItem();
      this.CostingsToolStripMenuItem = new ToolStripMenuItem();
      this.HistoryToolStripMenuItem = new ToolStripMenuItem();
      this.TabControl1.SuspendLayout();
      this.tpAssets.SuspendLayout();
      this.grpAssets.SuspendLayout();
      this.dgAssets.BeginInit();
      this.tbquote.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.Panel1.SuspendLayout();
      this.GroupBox3.SuspendLayout();
      ((ISupportInitialize) this.dgvQuote).BeginInit();
      this.tpNotes.SuspendLayout();
      this.gpbNotesDetails.SuspendLayout();
      this.gpbNotes.SuspendLayout();
      this.dgNotes.BeginInit();
      this.tpContactAttempts.SuspendLayout();
      this.grpContactAttemptDetails.SuspendLayout();
      this.grpContactAttempts.SuspendLayout();
      this.dgContactAttempts.BeginInit();
      this.cmsView.SuspendLayout();
      this.SuspendLayout();
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(70, 664);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 23);
      this.btnClose.TabIndex = 16;
      this.btnClose.Text = "Close";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Location = new System.Drawing.Point(8, 664);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(56, 23);
      this.btnSave.TabIndex = 15;
      this.btnSave.Text = "Save";
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tpMain);
      this.TabControl1.Controls.Add((Control) this.tpAssets);
      this.TabControl1.Controls.Add((Control) this.tpDocuments);
      this.TabControl1.Controls.Add((Control) this.tbquote);
      this.TabControl1.Controls.Add((Control) this.tpNotes);
      this.TabControl1.Controls.Add((Control) this.tpContactAttempts);
      this.TabControl1.Location = new System.Drawing.Point(0, 31);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(1184, 627);
      this.TabControl1.TabIndex = 23;
      this.tpMain.Location = new System.Drawing.Point(4, 22);
      this.tpMain.Name = "tpMain";
      this.tpMain.Padding = new Padding(3);
      this.tpMain.Size = new Size(1176, 601);
      this.tpMain.TabIndex = 0;
      this.tpMain.Text = "Main Details";
      this.tpMain.UseVisualStyleBackColor = true;
      this.tpAssets.Controls.Add((Control) this.grpAssets);
      this.tpAssets.Location = new System.Drawing.Point(4, 22);
      this.tpAssets.Name = "tpAssets";
      this.tpAssets.Padding = new Padding(3);
      this.tpAssets.Size = new Size(1176, 601);
      this.tpAssets.TabIndex = 2;
      this.tpAssets.Text = "Appliances";
      this.tpAssets.UseVisualStyleBackColor = true;
      this.grpAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAssets.Controls.Add((Control) this.dgAssets);
      this.grpAssets.Controls.Add((Control) this.btnAddAppliance);
      this.grpAssets.Location = new System.Drawing.Point(6, 6);
      this.grpAssets.Name = "grpAssets";
      this.grpAssets.Size = new Size(1162, 596);
      this.grpAssets.TabIndex = 29;
      this.grpAssets.TabStop = false;
      this.grpAssets.Text = "Select those related to the job";
      this.dgAssets.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgAssets.DataMember = "";
      this.dgAssets.HeaderForeColor = SystemColors.ControlText;
      this.dgAssets.Location = new System.Drawing.Point(6, 20);
      this.dgAssets.Name = "dgAssets";
      this.dgAssets.Size = new Size(1150, 541);
      this.dgAssets.TabIndex = 1;
      this.btnAddAppliance.AccessibleDescription = "Add Job Of Work";
      this.btnAddAppliance.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddAppliance.Location = new System.Drawing.Point(6, 567);
      this.btnAddAppliance.Name = "btnAddAppliance";
      this.btnAddAppliance.Size = new Size(155, 23);
      this.btnAddAppliance.TabIndex = 28;
      this.btnAddAppliance.Text = "New Appliance";
      this.tpDocuments.Location = new System.Drawing.Point(4, 22);
      this.tpDocuments.Name = "tpDocuments";
      this.tpDocuments.Padding = new Padding(3);
      this.tpDocuments.Size = new Size(1176, 601);
      this.tpDocuments.TabIndex = 1;
      this.tpDocuments.Text = "Documents";
      this.tpDocuments.UseVisualStyleBackColor = true;
      this.tbquote.Controls.Add((Control) this.GroupBox2);
      this.tbquote.Location = new System.Drawing.Point(4, 22);
      this.tbquote.Name = "tbquote";
      this.tbquote.Padding = new Padding(3);
      this.tbquote.Size = new Size(1176, 601);
      this.tbquote.TabIndex = 7;
      this.tbquote.Text = "Quote Calc";
      this.tbquote.UseVisualStyleBackColor = true;
      this.GroupBox2.Controls.Add((Control) this.GroupBox1);
      this.GroupBox2.Controls.Add((Control) this.Panel1);
      this.GroupBox2.Dock = DockStyle.Fill;
      this.GroupBox2.Location = new System.Drawing.Point(3, 3);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(1170, 595);
      this.GroupBox2.TabIndex = 0;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Quote Calculator";
      this.GroupBox1.Controls.Add((Control) this.rdoAXA);
      this.GroupBox1.Controls.Add((Control) this.rdoPOC);
      this.GroupBox1.Location = new System.Drawing.Point(55, 26);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(121, 45);
      this.GroupBox1.TabIndex = 82;
      this.GroupBox1.TabStop = false;
      this.rdoAXA.AutoSize = true;
      this.rdoAXA.Location = new System.Drawing.Point(65, 17);
      this.rdoAXA.Name = "rdoAXA";
      this.rdoAXA.Size = new Size(49, 17);
      this.rdoAXA.TabIndex = 1;
      this.rdoAXA.Text = "AXA";
      this.rdoAXA.UseVisualStyleBackColor = true;
      this.rdoPOC.AutoSize = true;
      this.rdoPOC.Checked = true;
      this.rdoPOC.Location = new System.Drawing.Point(6, 17);
      this.rdoPOC.Name = "rdoPOC";
      this.rdoPOC.Size = new Size(50, 17);
      this.rdoPOC.TabIndex = 0;
      this.rdoPOC.TabStop = true;
      this.rdoPOC.Text = "POC";
      this.rdoPOC.UseVisualStyleBackColor = true;
      this.Panel1.Controls.Add((Control) this.txtClaimLimit);
      this.Panel1.Controls.Add((Control) this.lblClaimLimit);
      this.Panel1.Controls.Add((Control) this.chkExcludeVat);
      this.Panel1.Controls.Add((Control) this.cboVATRate);
      this.Panel1.Controls.Add((Control) this.lblVAT);
      this.Panel1.Controls.Add((Control) this.GroupBox3);
      this.Panel1.Controls.Add((Control) this.txtPartQty);
      this.Panel1.Controls.Add((Control) this.Label46);
      this.Panel1.Controls.Add((Control) this.dgvQuote);
      this.Panel1.Controls.Add((Control) this.cboLabour);
      this.Panel1.Controls.Add((Control) this.btnQuoteAdd);
      this.Panel1.Controls.Add((Control) this.Label45);
      this.Panel1.Controls.Add((Control) this.txtLabourQty);
      this.Panel1.Controls.Add((Control) this.Label44);
      this.Panel1.Controls.Add((Control) this.btnReset);
      this.Panel1.Controls.Add((Control) this.btnaddtonotes);
      this.Panel1.Controls.Add((Control) this.btnEmail);
      this.Panel1.Controls.Add((Control) this.btncalc);
      this.Panel1.Controls.Add((Control) this.tbresult);
      this.Panel1.Controls.Add((Control) this.txtPartRate);
      this.Panel1.Controls.Add((Control) this.lbltc1);
      this.Panel1.Controls.Add((Control) this.txtPartNumber);
      this.Panel1.Controls.Add((Control) this.lblnumber1);
      this.Panel1.Controls.Add((Control) this.txtPartName);
      this.Panel1.Controls.Add((Control) this.lblpart1);
      this.Panel1.Dock = DockStyle.Fill;
      this.Panel1.Location = new System.Drawing.Point(3, 17);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new Size(1164, 575);
      this.Panel1.TabIndex = 1;
      this.txtClaimLimit.Location = new System.Drawing.Point(585, 62);
      this.txtClaimLimit.Name = "txtClaimLimit";
      this.txtClaimLimit.Size = new Size(121, 21);
      this.txtClaimLimit.TabIndex = 83;
      this.txtClaimLimit.Visible = false;
      this.lblClaimLimit.AutoSize = true;
      this.lblClaimLimit.Location = new System.Drawing.Point(505, 65);
      this.lblClaimLimit.Name = "lblClaimLimit";
      this.lblClaimLimit.Size = new Size(71, 13);
      this.lblClaimLimit.TabIndex = 82;
      this.lblClaimLimit.Text = "Claim Limit";
      this.lblClaimLimit.Visible = false;
      this.chkExcludeVat.AutoSize = true;
      this.chkExcludeVat.Location = new System.Drawing.Point(425, 505);
      this.chkExcludeVat.Name = "chkExcludeVat";
      this.chkExcludeVat.Size = new Size(103, 17);
      this.chkExcludeVat.TabIndex = 81;
      this.chkExcludeVat.Text = "Exclude V.A.T";
      this.chkExcludeVat.UseVisualStyleBackColor = true;
      this.cboVATRate.FormattingEnabled = true;
      this.cboVATRate.Location = new System.Drawing.Point(499, 528);
      this.cboVATRate.Name = "cboVATRate";
      this.cboVATRate.Size = new Size(109, 21);
      this.cboVATRate.TabIndex = 79;
      this.lblVAT.Location = new System.Drawing.Point(422, 529);
      this.lblVAT.Name = "lblVAT";
      this.lblVAT.Size = new Size(68, 17);
      this.lblVAT.TabIndex = 80;
      this.lblVAT.Text = "VAT Rate";
      this.lblVAT.TextAlign = ContentAlignment.MiddleLeft;
      this.GroupBox3.Controls.Add((Control) this.rbStandard);
      this.GroupBox3.Controls.Add((Control) this.rbSite);
      this.GroupBox3.Location = new System.Drawing.Point(48, 491);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(343, 45);
      this.GroupBox3.TabIndex = 77;
      this.GroupBox3.TabStop = false;
      this.rbStandard.AutoSize = true;
      this.rbStandard.Checked = true;
      this.rbStandard.Location = new System.Drawing.Point(207, 16);
      this.rbStandard.Name = "rbStandard";
      this.rbStandard.Size = new Size(121, 17);
      this.rbStandard.TabIndex = 1;
      this.rbStandard.TabStop = true;
      this.rbStandard.Text = "Markup standard";
      this.rbStandard.UseVisualStyleBackColor = true;
      this.rbSite.AutoSize = true;
      this.rbSite.Location = new System.Drawing.Point(6, 17);
      this.rbSite.Name = "rbSite";
      this.rbSite.Size = new Size(185, 17);
      this.rbSite.TabIndex = 0;
      this.rbSite.Text = "Markup parts using site rate";
      this.rbSite.UseVisualStyleBackColor = true;
      this.txtPartQty.Location = new System.Drawing.Point(659, 89);
      this.txtPartQty.Name = "txtPartQty";
      this.txtPartQty.Size = new Size(48, 21);
      this.txtPartQty.TabIndex = 76;
      this.txtPartQty.Text = "0";
      this.Label46.AutoSize = true;
      this.Label46.Location = new System.Drawing.Point(629, 92);
      this.Label46.Name = "Label46";
      this.Label46.Size = new Size(27, 13);
      this.Label46.TabIndex = 75;
      this.Label46.Text = "Qty";
      this.dgvQuote.AllowUserToAddRows = false;
      this.dgvQuote.AllowUserToResizeColumns = false;
      this.dgvQuote.AllowUserToResizeRows = false;
      this.dgvQuote.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvQuote.Location = new System.Drawing.Point(48, 124);
      this.dgvQuote.Name = "dgvQuote";
      this.dgvQuote.Size = new Size(811, 210);
      this.dgvQuote.TabIndex = 74;
      this.cboLabour.FormattingEnabled = true;
      this.cboLabour.Location = new System.Drawing.Point(125, 62);
      this.cboLabour.Name = "cboLabour";
      this.cboLabour.Size = new Size(294, 21);
      this.cboLabour.TabIndex = 73;
      this.btnQuoteAdd.Location = new System.Drawing.Point(820, 65);
      this.btnQuoteAdd.Name = "btnQuoteAdd";
      this.btnQuoteAdd.Size = new Size(39, 47);
      this.btnQuoteAdd.TabIndex = 72;
      this.btnQuoteAdd.Text = "Add";
      this.btnQuoteAdd.UseVisualStyleBackColor = true;
      this.Label45.AutoSize = true;
      this.Label45.Location = new System.Drawing.Point(45, 65);
      this.Label45.Name = "Label45";
      this.Label45.Size = new Size(77, 13);
      this.Label45.TabIndex = 71;
      this.Label45.Text = "Labour Type";
      this.txtLabourQty.Location = new System.Drawing.Point(449, 62);
      this.txtLabourQty.Name = "txtLabourQty";
      this.txtLabourQty.Size = new Size(29, 21);
      this.txtLabourQty.TabIndex = 70;
      this.txtLabourQty.Text = "0";
      this.Label44.AutoSize = true;
      this.Label44.Location = new System.Drawing.Point(427, 65);
      this.Label44.Name = "Label44";
      this.Label44.Size = new Size(15, 13);
      this.Label44.TabIndex = 69;
      this.Label44.Text = "X";
      this.btnReset.Location = new System.Drawing.Point(614, 526);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(110, 23);
      this.btnReset.TabIndex = 68;
      this.btnReset.Text = "Reset";
      this.btnReset.UseVisualStyleBackColor = true;
      this.btnaddtonotes.Enabled = false;
      this.btnaddtonotes.Location = new System.Drawing.Point(730, 499);
      this.btnaddtonotes.Name = "btnaddtonotes";
      this.btnaddtonotes.Size = new Size(130, 23);
      this.btnaddtonotes.TabIndex = 67;
      this.btnaddtonotes.Text = "Add Quote to Notes";
      this.btnaddtonotes.UseVisualStyleBackColor = true;
      this.btnEmail.Enabled = false;
      this.btnEmail.Location = new System.Drawing.Point(730, 526);
      this.btnEmail.Name = "btnEmail";
      this.btnEmail.Size = new Size(130, 23);
      this.btnEmail.TabIndex = 66;
      this.btnEmail.Text = "Email Quote";
      this.btnEmail.UseVisualStyleBackColor = true;
      this.btncalc.Location = new System.Drawing.Point(614, 499);
      this.btncalc.Name = "btncalc";
      this.btncalc.Size = new Size(110, 23);
      this.btncalc.TabIndex = 65;
      this.btncalc.Text = "Generate Quote";
      this.btncalc.UseVisualStyleBackColor = true;
      this.tbresult.Location = new System.Drawing.Point(48, 357);
      this.tbresult.Multiline = true;
      this.tbresult.Name = "tbresult";
      this.tbresult.ReadOnly = true;
      this.tbresult.RightToLeft = RightToLeft.No;
      this.tbresult.Size = new Size(812, 128);
      this.tbresult.TabIndex = 64;
      this.tbresult.Text = "Please enter details above. Quote will appear here";
      this.txtPartRate.Location = new System.Drawing.Point(558, 89);
      this.txtPartRate.Name = "txtPartRate";
      this.txtPartRate.Size = new Size(55, 21);
      this.txtPartRate.TabIndex = 5;
      this.lbltc1.AutoSize = true;
      this.lbltc1.Location = new System.Drawing.Point(456, 92);
      this.lbltc1.Name = "lbltc1";
      this.lbltc1.Size = new Size(96, 13);
      this.lbltc1.TabIndex = 4;
      this.lbltc1.Text = "Part Trade Cost";
      this.txtPartNumber.Location = new System.Drawing.Point(349, 89);
      this.txtPartNumber.Name = "txtPartNumber";
      this.txtPartNumber.Size = new Size(89, 21);
      this.txtPartNumber.TabIndex = 3;
      this.lblnumber1.AutoSize = true;
      this.lblnumber1.Location = new System.Drawing.Point(264, 92);
      this.lblnumber1.Name = "lblnumber1";
      this.lblnumber1.Size = new Size(79, 13);
      this.lblnumber1.TabIndex = 2;
      this.lblnumber1.Text = "Part Number";
      this.txtPartName.Location = new System.Drawing.Point(125, 89);
      this.txtPartName.Name = "txtPartName";
      this.txtPartName.Size = new Size(121, 21);
      this.txtPartName.TabIndex = 1;
      this.lblpart1.AutoSize = true;
      this.lblpart1.Location = new System.Drawing.Point(45, 92);
      this.lblpart1.Name = "lblpart1";
      this.lblpart1.Size = new Size(67, 13);
      this.lblpart1.TabIndex = 0;
      this.lblpart1.Text = "Part Name";
      this.tpNotes.Controls.Add((Control) this.gpbNotesDetails);
      this.tpNotes.Controls.Add((Control) this.gpbNotes);
      this.tpNotes.Location = new System.Drawing.Point(4, 22);
      this.tpNotes.Name = "tpNotes";
      this.tpNotes.Size = new Size(1176, 601);
      this.tpNotes.TabIndex = 4;
      this.tpNotes.Text = "Notes";
      this.tpNotes.UseVisualStyleBackColor = true;
      this.gpbNotesDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.gpbNotesDetails.Controls.Add((Control) this.txtNoteID);
      this.gpbNotesDetails.Controls.Add((Control) this.btnSaveNote);
      this.gpbNotesDetails.Controls.Add((Control) this.txtNotes);
      this.gpbNotesDetails.Controls.Add((Control) this.Label1);
      this.gpbNotesDetails.Location = new System.Drawing.Point(791, 6);
      this.gpbNotesDetails.Name = "gpbNotesDetails";
      this.gpbNotesDetails.Size = new Size(377, 596);
      this.gpbNotesDetails.TabIndex = 33;
      this.gpbNotesDetails.TabStop = false;
      this.gpbNotesDetails.Text = "Details";
      this.txtNoteID.Location = new System.Drawing.Point(66, 14);
      this.txtNoteID.Name = "txtNoteID";
      this.txtNoteID.Size = new Size(100, 21);
      this.txtNoteID.TabIndex = 36;
      this.txtNoteID.TabStop = false;
      this.txtNoteID.Visible = false;
      this.btnSaveNote.AccessibleDescription = "";
      this.btnSaveNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveNote.Location = new System.Drawing.Point(292, 567);
      this.btnSaveNote.Name = "btnSaveNote";
      this.btnSaveNote.Size = new Size(79, 23);
      this.btnSaveNote.TabIndex = 1;
      this.btnSaveNote.Text = "Save";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(6, 37);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.Size = new Size(365, 524);
      this.txtNotes.TabIndex = 0;
      this.Label1.Location = new System.Drawing.Point(3, 20);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(88, 23);
      this.Label1.TabIndex = 34;
      this.Label1.Text = "Notes:";
      this.gpbNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gpbNotes.Controls.Add((Control) this.btnDeleteNote);
      this.gpbNotes.Controls.Add((Control) this.dgNotes);
      this.gpbNotes.Controls.Add((Control) this.btnAddNote);
      this.gpbNotes.Location = new System.Drawing.Point(7, 6);
      this.gpbNotes.Name = "gpbNotes";
      this.gpbNotes.Size = new Size(773, 596);
      this.gpbNotes.TabIndex = 30;
      this.gpbNotes.TabStop = false;
      this.gpbNotes.Text = "Notes";
      this.btnDeleteNote.AccessibleDescription = "";
      this.btnDeleteNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDeleteNote.Location = new System.Drawing.Point(95, 567);
      this.btnDeleteNote.Name = "btnDeleteNote";
      this.btnDeleteNote.Size = new Size(85, 23);
      this.btnDeleteNote.TabIndex = 3;
      this.btnDeleteNote.Text = "Delete";
      this.btnDeleteNote.Visible = false;
      this.dgNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgNotes.DataMember = "";
      this.dgNotes.HeaderForeColor = SystemColors.ControlText;
      this.dgNotes.Location = new System.Drawing.Point(6, 20);
      this.dgNotes.Name = "dgNotes";
      this.dgNotes.Size = new Size(761, 541);
      this.dgNotes.TabIndex = 1;
      this.btnAddNote.AccessibleDescription = "";
      this.btnAddNote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddNote.Location = new System.Drawing.Point(6, 567);
      this.btnAddNote.Name = "btnAddNote";
      this.btnAddNote.Size = new Size(85, 23);
      this.btnAddNote.TabIndex = 2;
      this.btnAddNote.Text = "Add";
      this.tpContactAttempts.Controls.Add((Control) this.grpContactAttemptDetails);
      this.tpContactAttempts.Controls.Add((Control) this.grpContactAttempts);
      this.tpContactAttempts.Location = new System.Drawing.Point(4, 22);
      this.tpContactAttempts.Name = "tpContactAttempts";
      this.tpContactAttempts.Size = new Size(1176, 601);
      this.tpContactAttempts.TabIndex = 8;
      this.tpContactAttempts.Text = "Contact Attempts";
      this.tpContactAttempts.UseVisualStyleBackColor = true;
      this.grpContactAttemptDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.grpContactAttemptDetails.Controls.Add((Control) this.txtContactAttemptDetails);
      this.grpContactAttemptDetails.Controls.Add((Control) this.lblContactNotes);
      this.grpContactAttemptDetails.Location = new System.Drawing.Point(792, 2);
      this.grpContactAttemptDetails.Name = "grpContactAttemptDetails";
      this.grpContactAttemptDetails.Size = new Size(377, 596);
      this.grpContactAttemptDetails.TabIndex = 35;
      this.grpContactAttemptDetails.TabStop = false;
      this.grpContactAttemptDetails.Text = "Details";
      this.txtContactAttemptDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtContactAttemptDetails.Location = new System.Drawing.Point(6, 37);
      this.txtContactAttemptDetails.Multiline = true;
      this.txtContactAttemptDetails.Name = "txtContactAttemptDetails";
      this.txtContactAttemptDetails.ReadOnly = true;
      this.txtContactAttemptDetails.Size = new Size(365, 553);
      this.txtContactAttemptDetails.TabIndex = 0;
      this.lblContactNotes.Location = new System.Drawing.Point(3, 20);
      this.lblContactNotes.Name = "lblContactNotes";
      this.lblContactNotes.Size = new Size(88, 23);
      this.lblContactNotes.TabIndex = 34;
      this.lblContactNotes.Text = "Notes:";
      this.grpContactAttempts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContactAttempts.Controls.Add((Control) this.dgContactAttempts);
      this.grpContactAttempts.Controls.Add((Control) this.btnAddAttempt);
      this.grpContactAttempts.Location = new System.Drawing.Point(8, 2);
      this.grpContactAttempts.Name = "grpContactAttempts";
      this.grpContactAttempts.Size = new Size(773, 596);
      this.grpContactAttempts.TabIndex = 34;
      this.grpContactAttempts.TabStop = false;
      this.grpContactAttempts.Text = "Attempts";
      this.dgContactAttempts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgContactAttempts.DataMember = "";
      this.dgContactAttempts.HeaderForeColor = SystemColors.ControlText;
      this.dgContactAttempts.Location = new System.Drawing.Point(6, 20);
      this.dgContactAttempts.Name = "dgContactAttempts";
      this.dgContactAttempts.Size = new Size(761, 541);
      this.dgContactAttempts.TabIndex = 1;
      this.btnAddAttempt.AccessibleDescription = "";
      this.btnAddAttempt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddAttempt.Location = new System.Drawing.Point(6, 567);
      this.btnAddAttempt.Name = "btnAddAttempt";
      this.btnAddAttempt.Size = new Size(85, 23);
      this.btnAddAttempt.TabIndex = 2;
      this.btnAddAttempt.Text = "Add";
      this.btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnView.Location = new System.Drawing.Point(132, 664);
      this.btnView.Name = "btnView";
      this.btnView.Size = new Size(99, 23);
      this.btnView.TabIndex = 24;
      this.btnView.Text = "View...";
      this.cmsView.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.PropertyToolStripMenuItem,
        (ToolStripItem) this.CustomerToolStripMenuItem,
        (ToolStripItem) this.AuditTrailToolStripMenuItem,
        (ToolStripItem) this.OrdersToolStripMenuItem,
        (ToolStripItem) this.InvoiceToolStripMenuItem,
        (ToolStripItem) this.QuoteToolStripMenuItem,
        (ToolStripItem) this.CostingsToolStripMenuItem,
        (ToolStripItem) this.HistoryToolStripMenuItem
      });
      this.cmsView.Name = "cmsView";
      this.cmsView.Size = new Size(128, 180);
      this.PropertyToolStripMenuItem.Name = "PropertyToolStripMenuItem";
      this.PropertyToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 22);
      this.PropertyToolStripMenuItem.Text = "Property";
      this.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem";
      this.CustomerToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 22);
      this.CustomerToolStripMenuItem.Text = "Customer";
      this.AuditTrailToolStripMenuItem.Name = "AuditTrailToolStripMenuItem";
      this.AuditTrailToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 22);
      this.AuditTrailToolStripMenuItem.Text = "Audit Trail";
      this.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
      this.OrdersToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 22);
      this.OrdersToolStripMenuItem.Text = "Orders";
      this.InvoiceToolStripMenuItem.Name = "InvoiceToolStripMenuItem";
      this.InvoiceToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 22);
      this.InvoiceToolStripMenuItem.Text = "Invoice";
      this.QuoteToolStripMenuItem.Name = "QuoteToolStripMenuItem";
      this.QuoteToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 22);
      this.QuoteToolStripMenuItem.Text = "Quote";
      this.CostingsToolStripMenuItem.Name = "CostingsToolStripMenuItem";
      this.CostingsToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 22);
      this.CostingsToolStripMenuItem.Text = "Costings";
      this.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem";
      this.HistoryToolStripMenuItem.Size = new Size((int) sbyte.MaxValue, 22);
      this.HistoryToolStripMenuItem.Text = "History";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1184, 690);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnView);
      this.Controls.Add((Control) this.TabControl1);
      this.Controls.Add((Control) this.btnClose);
      this.Controls.Add((Control) this.btnSave);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(1200, 724);
      this.Name = nameof (FRMLogCallout);
      this.Text = "Job";
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.TabControl1, 0);
      this.Controls.SetChildIndex((Control) this.btnView, 0);
      this.TabControl1.ResumeLayout(false);
      this.tpAssets.ResumeLayout(false);
      this.grpAssets.ResumeLayout(false);
      this.dgAssets.EndInit();
      this.tbquote.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.Panel1.ResumeLayout(false);
      this.Panel1.PerformLayout();
      this.GroupBox3.ResumeLayout(false);
      this.GroupBox3.PerformLayout();
      ((ISupportInitialize) this.dgvQuote).EndInit();
      this.tpNotes.ResumeLayout(false);
      this.gpbNotesDetails.ResumeLayout(false);
      this.gpbNotesDetails.PerformLayout();
      this.gpbNotes.ResumeLayout(false);
      this.dgNotes.EndInit();
      this.tpContactAttempts.ResumeLayout(false);
      this.grpContactAttemptDetails.ResumeLayout(false);
      this.grpContactAttemptDetails.PerformLayout();
      this.grpContactAttempts.ResumeLayout(false);
      this.dgContactAttempts.EndInit();
      this.cmsView.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      if (App.IsRFT)
        this.TabControl1.Controls.Remove((Control) this.tbquote);
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      ((UCLogCallout) this.LoadedControl).OnForm = this;
      ((UCLogCallout) this.LoadedControl).JobId = this.ID;
      if ((object) this.get_GetParameter(1).GetType() == (object) typeof (Job))
        ((UCLogCallout) this.LoadedControl).SiteId = ((Job) this.get_GetParameter(1)).PropertyID;
      else
        ((UCLogCallout) this.LoadedControl).SiteId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)));
      ((UCLogCallout) this.LoadedControl).Populate(0);
      IEnumerator enumerator1;
      try
      {
        enumerator1 = ((UCLogCallout) this.LoadedControl).tcJobOfWorks.TabPages.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          TabPage current = (TabPage) enumerator1.Current;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = ((UCCalloutBreakdown) current.Controls[0]).tcEngineerVisits.TabPages.GetEnumerator();
            while (enumerator2.MoveNext())
              ((UCVisitBreakdown) ((Control) enumerator2.Current).Controls[0]).SetupDG();
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (((UCLogCallout) this.LoadedControl).Job.QuoteID == 0)
        this.QuoteToolStripMenuItem.Visible = false;
      ComboBox cboLabour1 = this.cboLabour;
      Combo.SetUpCombo(ref cboLabour1, App.DB.CustomerScheduleOfRate.CustomerScheduleOfRates_GetALL_Labour(((UCLogCallout) this.LoadedControl).Site.CustomerID).Table, "Price", "Description", Enums.ComboValues.Not_Applicable);
      this.cboLabour = cboLabour1;
      ComboBox cboLabour2 = this.cboLabour;
      Combo.SetSelectedComboItem_By_Description(ref cboLabour2, "Normal Labour");
      this.cboLabour = cboLabour2;
      ComboBox cboVatRate1 = this.cboVATRate;
      Combo.SetUpCombo(ref cboVatRate1, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Not_Applicable);
      this.cboVATRate = cboVatRate1;
      ComboBox cboVatRate2 = this.cboVATRate;
      Combo.SetSelectedComboItem_By_Value(ref cboVatRate2, Conversions.ToString(6));
      this.cboVATRate = cboVatRate2;
      this.SetupAssetDataGrid();
      this.SetupNotesDataGrid();
      this.SetupContactAttemptDataGrid();
      this.SetupQuoteDGV();
      this.PopulateContactAttempts();
      try
      {
        if (this.GetParameterCount > 4 && (uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(4))) > 0U)
        {
          DataView dataView = App.DB.EngineerVisits.EngineerVisits_Get(Conversions.ToInteger(this.get_GetParameter(4)));
          int integer1 = Conversions.ToInteger(dataView.Table.Rows[0]["JOWNo"]);
          int integer2 = Conversions.ToInteger(dataView.Table.Rows[0]["VisitNo"]);
          ((UCLogCallout) this.LoadedControl).tcJobOfWorks.SelectedIndex = checked (integer1 - 1);
          ((UCCalloutBreakdown) ((UCLogCallout) this.LoadedControl).tcJobOfWorks.SelectedTab.Controls[0]).tcEngineerVisits.SelectedIndex = checked (integer2 - 1);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      if (this.ID <= 0)
        return;
      if (this.JobLock == null)
        this.JobLock = App.DB.JobLock.JobLock(this.ID);
      int? userId1 = this.JobLock?.UserID;
      int userId2 = App.loggedInUser.UserID;
      if ((userId1.HasValue ? new bool?(userId1.GetValueOrDefault() != userId2) : new bool?()).GetValueOrDefault())
      {
        int num = (int) MessageBox.Show("The job is currently being viewed by: " + this.JobLock.NameOfUserWhoLocked, "READ ONLY - JOB LOCKED!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.MakeReadOnly();
        this.Text = this.Text + " Job Locked by: " + this.JobLock.NameOfUserWhoLocked;
      }
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) this.tpMain.Controls[0];
      }
    }

    public void ResetMe(int newID)
    {
      this.ID = newID;
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(this.get_GetParameter(2), (System.Type) null, "Name", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "ToLower", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) typeof (UCSite).Name.ToLower(), false))
      {
        ((UCSite) this.get_GetParameter(2)).PopulateJobs();
        App.MainForm.RefreshEntity(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1))), "");
      }
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(this.get_GetParameter(2), (System.Type) null, "Name", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "ToLower", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) typeof (UCAsset).Name.ToLower(), false))
      {
        ((UCAsset) this.get_GetParameter(2)).PopulateJobs();
        App.MainForm.RefreshEntity(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1))), "");
      }
      if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(this.get_GetParameter(2), (System.Type) null, "Name", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "ToLower", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) typeof (UCQuoteJob).Name.ToLower(), false))
        ;
    }

    public DataView Data
    {
      get
      {
        return this._Data;
      }
      set
      {
        this._Data = value;
        this._Data.AllowNew = false;
        this._Data.AllowEdit = false;
        this._Data.AllowDelete = true;
        this.dgvQuote.AutoGenerateColumns = false;
        this.dgvQuote.DataSource = (object) this.Data;
      }
    }

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
        if (this.ID == 0)
        {
          this.PageState = Enums.FormState.Insert;
          this.Text = "Job : Adding New...";
          this.btnSave.Enabled = true;
          this.AuditTrailToolStripMenuItem.Visible = false;
          this.OrdersToolStripMenuItem.Visible = false;
          this.InvoiceToolStripMenuItem.Visible = false;
          this.gpbNotes.Enabled = false;
          this.gpbNotesDetails.Enabled = false;
          this.btnSaveNote.Enabled = false;
          this.btnAddNote.Enabled = false;
          this.btnDeleteNote.Enabled = false;
          this.CostingsToolStripMenuItem.Visible = false;
          this.btnAddAttempt.Enabled = false;
        }
        else
        {
          this.PageState = Enums.FormState.Update;
          this.Text = "Job : ID " + Conversions.ToString(this.ID);
          this.AuditTrailToolStripMenuItem.Visible = true;
          this.OrdersToolStripMenuItem.Visible = true;
          this.InvoiceToolStripMenuItem.Visible = true;
          this.tpDocuments.Controls.Clear();
          this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblJob, this.ID);
          this.tpDocuments.Controls.Add((Control) this.DocumentsControl);
          this.PopulateJobNotes();
          this.gpbNotes.Enabled = true;
          this.gpbNotesDetails.Enabled = true;
          this.btnSaveNote.Enabled = true;
          this.btnAddNote.Enabled = true;
          this.btnDeleteNote.Enabled = true;
        }
      }
    }

    private Enums.FormState PageState
    {
      get
      {
        return this._pageState;
      }
      set
      {
        this._pageState = value;
      }
    }

    public DataView AssetsDataView
    {
      get
      {
        return this._AssetsTable;
      }
      set
      {
        this._AssetsTable = value;
        this._AssetsTable.Table.TableName = Enums.TableNames.tblAsset.ToString();
        this._AssetsTable.AllowNew = false;
        this._AssetsTable.AllowEdit = false;
        this._AssetsTable.AllowDelete = false;
        this.dgAssets.DataSource = (object) this.AssetsDataView;
      }
    }

    private DataRow SelectedAssetDataRow
    {
      get
      {
        return this.dgAssets.CurrentRowIndex != -1 ? this.AssetsDataView[this.dgAssets.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public FSM.Entity.JobLock.JobLock JobLock
    {
      get
      {
        return this._JobLock;
      }
      set
      {
        this._JobLock = value;
      }
    }

    private JobInstall JI
    {
      get
      {
        return this._JI;
      }
      set
      {
        this._JI = value;
      }
    }

    public int LastViewedEngineerVisitID { get; set; }

    public void SetupQuoteDGV()
    {
      this.Data = new DataView();
      this.Data.Table = new DataTable()
      {
        TableName = "QuoteTable"
      };
      this.Data.Table.Columns.Add("PartName");
      this.Data.Table.Columns.Add("PartNumber");
      this.Data.Table.Columns.Add("PartCost");
      this.Data.Table.Columns.Add("PartQty");
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "CustomerScheduleOfRateID";
      viewTextBoxColumn1.DataPropertyName = "CustomerScheduleOfRateID";
      viewTextBoxColumn1.Name = "CustomerScheduleOfRateID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.Visible = false;
      viewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvQuote.Columns.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Part Name";
      viewTextBoxColumn2.FillWeight = 15f;
      viewTextBoxColumn2.DataPropertyName = "PartName";
      viewTextBoxColumn2.Name = "PartName";
      viewTextBoxColumn2.Visible = true;
      viewTextBoxColumn2.MinimumWidth = 400;
      viewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvQuote.Columns.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Part Number";
      viewTextBoxColumn3.FillWeight = 15f;
      viewTextBoxColumn3.DataPropertyName = "PartNumber";
      viewTextBoxColumn3.Name = "PartNumber";
      viewTextBoxColumn3.Visible = true;
      viewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvQuote.Columns.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Part U.Cost";
      viewTextBoxColumn4.FillWeight = 15f;
      viewTextBoxColumn4.DataPropertyName = "PartCost";
      viewTextBoxColumn4.Name = "PartCost";
      viewTextBoxColumn4.Visible = true;
      viewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvQuote.Columns.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Part Qty";
      viewTextBoxColumn5.FillWeight = 15f;
      viewTextBoxColumn5.DataPropertyName = "PartQty";
      viewTextBoxColumn5.Name = "PartQty";
      viewTextBoxColumn5.Visible = true;
      viewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.Programmatic;
      this.dgvQuote.Columns.Add((DataGridViewColumn) viewTextBoxColumn5);
    }

    public void SetupAssetDataGrid()
    {
      Helper.SetUpDataGrid(this.dgAssets, false);
      DataGridTableStyle tableStyle = this.dgAssets.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgAssets.ReadOnly = false;
      tableStyle.AllowSorting = false;
      tableStyle.ReadOnly = false;
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      BitToStringDescriptionColumn descriptionColumn1 = new BitToStringDescriptionColumn();
      descriptionColumn1.Format = "";
      descriptionColumn1.FormatInfo = (IFormatProvider) null;
      descriptionColumn1.HeaderText = "Active";
      descriptionColumn1.MappingName = "Active";
      descriptionColumn1.ReadOnly = true;
      descriptionColumn1.Width = 50;
      descriptionColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) descriptionColumn1);
      BitToStringDescriptionColumn descriptionColumn2 = new BitToStringDescriptionColumn();
      descriptionColumn2.Format = "";
      descriptionColumn2.FormatInfo = (IFormatProvider) null;
      descriptionColumn2.HeaderText = "Tenants Appliance";
      descriptionColumn2.MappingName = "TenantsAppliance";
      descriptionColumn2.ReadOnly = true;
      descriptionColumn2.Width = 50;
      descriptionColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) descriptionColumn2);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Product";
      dataGridLabelColumn1.MappingName = "Product";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Location";
      dataGridLabelColumn2.MappingName = "Location";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Serial";
      dataGridLabelColumn3.MappingName = "SerialNum";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Gasway Ref";
      dataGridLabelColumn4.MappingName = "BoughtFrom";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 75;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "GC Number";
      dataGridLabelColumn5.MappingName = "GCNumber";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Year Of Manufacture";
      dataGridLabelColumn6.MappingName = "YearOfManufacture";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Approx.Value";
      dataGridLabelColumn7.MappingName = "ApproximateValue";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblAsset.ToString();
      this.dgAssets.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgAssets);
    }

    private void FRMLogCallout_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    public void MakeReadOnly()
    {
      this.btnSave.Enabled = false;
      this.tpAssets.Enabled = false;
      this.tbquote.Enabled = false;
      this.tpDocuments.Enabled = false;
      ((UCLogCallout) this.LoadedControl).gbPaymentType.Enabled = false;
      ((UCLogCallout) this.LoadedControl).btnFindUser.Enabled = false;
      ((UCLogCallout) this.LoadedControl).cboJobType.Enabled = false;
      ((UCLogCallout) this.LoadedControl).btnChange.Enabled = false;
      ((UCLogCallout) this.LoadedControl).btnfindVan.Enabled = false;
      ((UCLogCallout) this.LoadedControl).btnAddJobOfWork.Enabled = false;
      ((UCLogCallout) this.LoadedControl).btnRemoveJobOfWork.Enabled = false;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = ((UCLogCallout) this.LoadedControl)?.tcJobOfWorks?.TabPages.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          TabPage current1 = (TabPage) enumerator1.Current;
          ((UCCalloutBreakdown) current1.Controls[0]).txtPONumber.Enabled = false;
          ((UCCalloutBreakdown) current1.Controls[0]).cboPriority.Enabled = false;
          ((UCCalloutBreakdown) current1.Controls[0]).cboQualification.Enabled = false;
          ((UCCalloutBreakdown) current1.Controls[0]).btnAddEngineerVisit.Enabled = false;
          ((UCCalloutBreakdown) current1.Controls[0]).btnRemoveEngineerVisit.Enabled = false;
          ((UCCalloutBreakdown) current1.Controls[0]).txtJobItemSummary.Enabled = false;
          ((UCCalloutBreakdown) current1.Controls[0]).btnRemoveItem.Enabled = false;
          ((UCCalloutBreakdown) current1.Controls[0]).btnSaveItem.Enabled = false;
          ((UCCalloutBreakdown) current1.Controls[0]).btnAddRate.Enabled = false;
          IEnumerator enumerator2;
          try
          {
            enumerator2 = ((UCCalloutBreakdown) current1.Controls[0])?.tcEngineerVisits?.TabPages.GetEnumerator();
            while (enumerator2.MoveNext())
            {
              TabPage current2 = (TabPage) enumerator2.Current;
              ((UCVisitBreakdown) current2.Controls[0]).tpParts.Enabled = false;
              ((UCVisitBreakdown) current2.Controls[0]).EstVisitDate.Enabled = false;
              ((UCVisitBreakdown) current2.Controls[0]).chkRecharge.Enabled = false;
              ((UCVisitBreakdown) current2.Controls[0]).cbxPartsToFit.Enabled = false;
              ((UCVisitBreakdown) current2.Controls[0]).txtNotesToEngineer.Enabled = false;
            }
          }
          finally
          {
            if (enumerator2 is IDisposable)
              (enumerator2 as IDisposable).Dispose();
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
    }

    private void dgAssets_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.SelectedAssetDataRow == null)
          return;
        this.dgAssets[this.dgAssets.CurrentRowIndex, 0] = (object) !Conversions.ToBoolean(this.dgAssets[this.dgAssets.CurrentRowIndex, 0]);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Cannot change tick state : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddAppliance_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMAsset), true, new object[3]
      {
        (object) 0,
        (object) 0,
        (object) ((UCLogCallout) this.LoadedControl).Site.SiteID
      }, false);
      this.AssetsDataView = App.DB.Asset.Asset_GetForSite(((UCLogCallout) this.LoadedControl).Job.PropertyID);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.LoadedControl.Save())
        ;
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.CloseForm();
    }

    private void btnView_Click(object sender, EventArgs e)
    {
      this.cmsView.Show((Control) this.btnView, new System.Drawing.Point(0, 0));
    }

    public void CloseForm()
    {
      if (((UCLogCallout) this.TheLoadedControl).Job.JobID == 0)
        App.DB.Job.DeleteReservedOrderNumber(((UCLogCallout) this.TheLoadedControl).JobNumber.JobNumber, ((UCLogCallout) this.TheLoadedControl).JobNumber.Prefix);
      if (this.JobLock != null && this.JobLock.UserID == App.loggedInUser.UserID)
        App.DB.JobLock.Delete(this.JobLock.JobLockID);
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    public DataView JobNotesDataView
    {
      get
      {
        return this._jobNotes;
      }
      set
      {
        this._jobNotes = value;
        this._jobNotes.Table.TableName = Enums.TableNames.tblJobNotes.ToString();
        this._jobNotes.AllowNew = false;
        this._jobNotes.AllowEdit = false;
        this._jobNotes.AllowDelete = false;
        this.dgNotes.DataSource = (object) this._jobNotes;
      }
    }

    private DataRow SelectedJobNoteDataRow
    {
      get
      {
        return this.dgNotes.CurrentRowIndex != -1 ? this.JobNotesDataView[this.dgNotes.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupNotesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgNotes, false);
      DataGridTableStyle tableStyle = this.dgNotes.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgNotes.ReadOnly = true;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Note";
      dataGridLabelColumn1.MappingName = "Note";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Created By";
      dataGridLabelColumn2.MappingName = "CreatedBy";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 125;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MMM/yyyy HH:mm:ss";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Created";
      dataGridLabelColumn3.MappingName = "DateCreated";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 135;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Edited By";
      dataGridLabelColumn4.MappingName = "EditedBy";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 125;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MMM/yyyy HH:mm:ss";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Last Edited";
      dataGridLabelColumn5.MappingName = "LastEdited";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 135;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblJobNotes.ToString();
      this.dgNotes.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgNotes);
    }

    private void dgNotes_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobNoteDataRow == null)
        return;
      this.PopulateJobNoteFields();
      this.txtNotes.ReadOnly = true;
      this.btnSaveNote.Enabled = false;
    }

    private void btnAddNote_Click(object sender, EventArgs e)
    {
      this.ClearNotesFields();
    }

    private void btnDeleteNote_Click(object sender, EventArgs e)
    {
      string text = "Are you sure you want to delete this note?\r\n" + "You will not be able to undo the delete if you proceed.";
      DataRow selectedJobNoteDataRow = this.SelectedJobNoteDataRow;
      if (selectedJobNoteDataRow == null || MessageBox.Show(text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
        return;
      App.DB.Job.DeleteJobNote(Conversions.ToInteger(selectedJobNoteDataRow["JobNoteID"]));
      this.JobNotesDataView.Table.Rows.Remove(this.SelectedJobNoteDataRow);
      this.ClearNotesFields();
    }

    private void btnSaveNote_Click(object sender, EventArgs e)
    {
      if (this.txtNotes.Text.Trim().Length > 0)
        this.JobNotesDataView = App.DB.Job.SaveJobNotes(Helper.MakeIntegerValid((object) this.txtNoteID.Text), this.txtNotes.Text.Trim(), App.loggedInUser.UserID, this.ID, App.loggedInUser.UserID);
      this.ClearNotesFields();
    }

    private void ClearNotesFields()
    {
      this.txtNoteID.Text = "";
      this.txtNotes.Text = "";
      this.ActiveControl = (Control) this.txtNotes;
      this.txtNotes.ReadOnly = false;
      this.txtNotes.Focus();
      this.btnSaveNote.Enabled = true;
      this.tpNotes.Text = "Notes (" + Conversions.ToString(this.JobNotesDataView.Table.Rows.Count) + ")";
    }

    private void PopulateJobNoteFields()
    {
      DataRow selectedJobNoteDataRow = this.SelectedJobNoteDataRow;
      if (selectedJobNoteDataRow != null)
      {
        this.txtNoteID.Text = Conversions.ToString(selectedJobNoteDataRow["JobNoteID"]);
        this.txtNotes.Text = Conversions.ToString(selectedJobNoteDataRow["Note"]);
      }
      this.ActiveControl = (Control) this.txtNotes;
      this.txtNotes.Focus();
    }

    private void PopulateJobNotes()
    {
      this.JobNotesDataView = App.DB.Job.GetJobNotes(this.ID);
      this.tpNotes.Text = "Notes (" + Conversions.ToString(this.JobNotesDataView.Table.Rows.Count) + ")";
    }

    private void btncalc_Click(object sender, EventArgs e)
    {
      try
      {
        double num1 = Helper.MakeDoubleValid((object) Combo.get_GetSelectedItemValue(this.cboLabour));
        if (num1 <= 0.0)
          throw new Exception("No Labour Rate selected!");
        double num2 = Helper.MakeDoubleValid((object) this.txtLabourQty.Text);
        if (num2 <= 0.0)
          throw new Exception("Labour Value incorrect!");
        double num3 = Math.Round(num2 * num1, 2);
        Decimal num4 = new Decimal(Helper.MakeDoubleValid((object) this.txtClaimLimit.Text));
        if (this.rdoAXA.Checked & Decimal.Compare(num4, Decimal.Zero) < 0)
          throw new Exception("Invalid claim limit!");
        string str1 = "";
        string str2 = "";
        double num5 = 0.0;
        double num6 = 59.08;
        double num7 = 30.0;
        int num8 = 0;
        CustomerCharge forCustomer = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(((UCLogCallout) this.LoadedControl).Site.CustomerID);
        Decimal num9 = new Decimal(1.0 + Helper.MakeDoubleValid((object) (forCustomer != null ? new double?(forCustomer.PartsMarkup / 100.0) : new double?())));
        string str3 = "Quote for Works:\r\n";
        IEnumerator enumerator;
        try
        {
          enumerator = this.Data.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) this.rbStandard.Checked, Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectGreater(current["PartQty"], (object) 0, false))))
            {
              checked { ++num8; }
              double num10 = Convert.ToDouble(this.Markup(Math.Round(Decimal.Parse(Conversions.ToString(current["PartCost"])), 2, MidpointRounding.AwayFromZero)));
              str1 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str1, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Materials " + Conversions.ToString(num8) + ": Code: "), current["PartNumber"]), (object) " / Name: "), current["PartName"]), (object) " / Cost: £"), (object) num10), (object) " X "), current["PartQty"]), (object) " = £"), NewLateBinding.LateGet((object) null, typeof (Math), "Round", new object[3]
              {
                Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject((object) num10, current["PartQty"]),
                (object) 2,
                (object) MidpointRounding.AwayFromZero
              }, (string[]) null, (System.Type[]) null, (bool[]) null)), (object) "\r\n")));
              num5 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num5, NewLateBinding.LateGet((object) null, typeof (Math), "Round", new object[3]
              {
                Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject((object) num10, current["PartQty"]),
                (object) 2,
                (object) MidpointRounding.AwayFromZero
              }, (string[]) null, (System.Type[]) null, (bool[]) null)));
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["PartQty"], (object) 0, false))
            {
              checked { ++num8; }
              double num10 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Partcost"], (object) num9));
              str1 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) str1, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) ("Materials " + Conversions.ToString(num8) + ": Code: "), current["PartNumber"]), (object) " / Name: "), current["PartName"]), (object) " / Cost: £"), (object) num10), (object) " X "), current["PartQty"]), (object) " = £"), NewLateBinding.LateGet((object) null, typeof (Math), "Round", new object[3]
              {
                Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject((object) num10, current["PartQty"]),
                (object) 2,
                (object) MidpointRounding.AwayFromZero
              }, (string[]) null, (System.Type[]) null, (bool[]) null)), (object) "\r\n")));
              num5 = Conversions.ToDouble(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num5, NewLateBinding.LateGet((object) null, typeof (Math), "Round", new object[3]
              {
                Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject((object) num10, current["PartQty"]),
                (object) 2,
                (object) MidpointRounding.AwayFromZero
              }, (string[]) null, (System.Type[]) null, (bool[]) null)));
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        string str4 = str2 + "Labour @ £" + Conversions.ToString(num1) + " X " + Conversions.ToString(num2) + " = £" + Conversions.ToString(num3) + "\r\n";
        Decimal num11 = new Decimal();
        Decimal d1_1 = !this.rdoPOC.Checked ? new Decimal(Math.Round(num5 + num6 + num3, 2, MidpointRounding.AwayFromZero)) : new Decimal(Math.Round(num5 + num3, 2, MidpointRounding.AwayFromZero));
        Decimal d2 = new Decimal();
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVATRate)) > 0.0)
          d2 = new Decimal(Math.Round(Convert.ToDouble(d1_1) * (1.0 + App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboVATRate))).VATRate / 100.0) - Convert.ToDouble(d1_1), 2, MidpointRounding.AwayFromZero));
        Decimal num12 = Decimal.Add(d1_1, d2);
        string str5 = str3 + str1;
        if (this.rdoAXA.Checked)
          str5 = str5 + "Callout @ £" + Conversions.ToString(num6) + "\r\n";
        string str6 = str5 + str4 + "Sub Total = £" + Conversions.ToString(d1_1);
        string str7;
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVATRate)) > 0.0 & !this.chkExcludeVat.Checked)
        {
          if (this.rdoPOC.Checked)
          {
            str7 = str6 + " + VAT (£" + Conversions.ToString(num12) + " inc VAT) ";
          }
          else
          {
            string str8 = str6 + " + VAT (£" + Conversions.ToString(num12) + " inc VAT) " + " Plus AXA admin fee: £" + Conversions.ToString(num7);
            Decimal d1_2 = new Decimal(Convert.ToDouble(num12) + num7);
            string str9 = str8 + " Grand total: £" + Conversions.ToString(d1_2) + "\r\n" + "Total Price for work: £" + Conversions.ToString(d1_2) + " minus claim limit £" + Conversions.ToString(num4);
            double num10 = Convert.ToDouble(Decimal.Subtract(d1_2, num4));
            str7 = num10 > 0.0 ? str9 + " = Total payable of £" + Conversions.ToString(num10) + " inc VAT" : str9 + " = Underlimit - Please proceed";
          }
        }
        else
          str7 = str6 + " Ex VAT";
        this.quotecreated = true;
        this.quoteresult = str7;
        this.tbresult.Text = str7;
        this.btnaddtonotes.Enabled = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private Decimal Markup(Decimal cost)
    {
      return Math.Round(Decimal.Compare(cost, new Decimal(20L)) > 0 ? (!(Decimal.Compare(cost, new Decimal(20L)) > 0 & Decimal.Compare(cost, new Decimal(50L)) <= 0) ? (!(Decimal.Compare(cost, new Decimal(50L)) > 0 & Decimal.Compare(cost, new Decimal(100L)) <= 0) ? (!(Decimal.Compare(cost, new Decimal(100L)) > 0 & Decimal.Compare(cost, new Decimal(200L)) <= 0) ? (!(Decimal.Compare(cost, new Decimal(200L)) > 0 & Decimal.Compare(cost, new Decimal(300L)) <= 0) ? (!(Decimal.Compare(cost, new Decimal(300L)) > 0 & Decimal.Compare(cost, new Decimal(400L)) <= 0) ? new Decimal(Convert.ToDouble(cost) * 1.4) : new Decimal(Convert.ToDouble(cost) * 1.45)) : new Decimal(Convert.ToDouble(cost) * 1.5)) : new Decimal(Convert.ToDouble(cost) * 1.6)) : new Decimal(Convert.ToDouble(cost) * 1.7)) : new Decimal(Convert.ToDouble(cost) * 1.8)) : Decimal.Multiply(cost, new Decimal(2L)), 2, MidpointRounding.AwayFromZero);
    }

    private double numbertest(string number)
    {
      return !Decimal.TryParse(number, out Decimal _) ? 0.0 : Conversions.ToDouble(number);
    }

    private void btnEmail_Click(object sender, EventArgs e)
    {
      int num = (int) MessageBox.Show("Please manually email this quote to the client. Button not in operation", "Gasway Services: Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private void btnaddtonotes_Click(object sender, EventArgs e)
    {
      if (this.quoteresult.Length <= 1)
        return;
      this.JobNotesDataView = App.DB.Job.SaveJobNotes(0, this.quoteresult, App.loggedInUser.UserID, this.ID, App.loggedInUser.UserID);
      this.PopulateJobNotes();
      this.btnEmail.Enabled = true;
    }

    private void BtnQuoteAdd_Click(object sender, EventArgs e)
    {
      DataRow row = this.Data.Table.NewRow();
      if (this.numbertest(this.txtPartQty.Text) > 0.0 && this.numbertest(this.txtPartRate.Text) > 0.0)
      {
        if (this.numbertest(this.txtPartQty.Text) > 0.0)
        {
          row["PartQty"] = (object) this.numbertest(this.txtPartQty.Text);
          row["PartName"] = (object) this.txtPartName.Text;
          row["PartNumber"] = (object) this.txtPartNumber.Text;
          row["PartCost"] = (object) this.numbertest(this.txtPartRate.Text);
        }
        else
        {
          row["PartQty"] = (object) "0";
          row["PartName"] = (object) "N/A";
          row["PartNumber"] = (object) "N/A";
          row["PartCost"] = (object) "N/A";
        }
        this.Data.Table.Rows.Add(row);
        this.txtPartQty.Text = Conversions.ToString(0);
        this.txtPartName.Text = "";
        this.txtPartNumber.Text = "";
        this.txtPartRate.Text = "";
      }
      else
      {
        int num = (int) Interaction.MsgBox((object) "Nothing to add", MsgBoxStyle.OkOnly, (object) "Error");
      }
    }

    private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMSite), true, new object[2]
      {
        (object) ((UCLogCallout) this.LoadedControl).Site.SiteID,
        (object) this
      }, false);
    }

    private void AuditTrailToolStripMenuItem_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMJobAudit), true, new object[1]
      {
        (object) this.ID
      }, false);
    }

    private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes || !Navigation.Navigate(Enums.MenuTypes.Spares))
        return;
      this.CloseForm();
      App.ShowForm(typeof (FRMOrderManager), false, new object[2]
      {
        (object) App.DB.Order.Orders_GetForJob(this.ID),
        null
      }, false);
    }

    private void InvoiceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes || !Navigation.Navigate(Enums.MenuTypes.Invoicing))
        return;
      this.CloseForm();
      DataView allForJobId = App.DB.InvoiceToBeRaised.Invoices_GetAll_For_JobID(this.ID);
      bool flag = true;
      if (allForJobId.Table.Rows.Count > 0 && App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(allForJobId.Table.Rows[0]["InvoiceToBeRaisedID"])).Table.Rows.Count > 0)
        flag = false;
      App.ShowForm(typeof (FRMInvoiceManager), false, new object[2]
      {
        (object) allForJobId,
        (object) flag
      }, false);
    }

    private void QuoteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMQuoteJob), true, new object[2]
      {
        (object) ((UCLogCallout) this.LoadedControl).Job.QuoteID,
        (object) ((UCLogCallout) this.LoadedControl).Site.SiteID
      }, false);
    }

    private void HistoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMSiteVisitManager), true, new object[1]
      {
        (object) ((UCLogCallout) this.LoadedControl).Site.SiteID
      }, false);
    }

    private void CostingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      PdfFactory.GenerateJobCostings(((UCLogCallout) this.LoadedControl).Job);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.tbresult.Text = "";
      this.Data.Table.Clear();
    }

    private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMCustomer), true, new object[1]
      {
        (object) ((UCLogCallout) this.LoadedControl).Site.CustomerID
      }, false);
    }

    private void rdoCust_CheckedChanged(object sender, EventArgs e)
    {
      this.lblClaimLimit.Visible = this.rdoAXA.Checked;
      this.txtClaimLimit.Visible = this.rdoAXA.Checked;
      this.chkExcludeVat.Visible = this.rdoPOC.Checked;
      if (!this.rdoAXA.Checked)
        return;
      this.chkExcludeVat.Checked = false;
    }

    public DataView DvContactAttempts
    {
      get
      {
        return this._dvcontactAttempts;
      }
      set
      {
        this._dvcontactAttempts = value;
        this._dvcontactAttempts.Table.TableName = Enums.TableNames.tblContact.ToString();
        this._dvcontactAttempts.AllowNew = false;
        this._dvcontactAttempts.AllowEdit = false;
        this._dvcontactAttempts.AllowDelete = false;
        this.dgContactAttempts.DataSource = (object) this._dvcontactAttempts;
      }
    }

    private DataRow DrSelectedContactAttempt
    {
      get
      {
        return this.dgContactAttempts.CurrentRowIndex != -1 ? this.DvContactAttempts[this.dgContactAttempts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupContactAttemptDataGrid()
    {
      Helper.SetUpDataGrid(this.dgContactAttempts, false);
      DataGridTableStyle tableStyle = this.dgContactAttempts.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      this.dgContactAttempts.ReadOnly = true;
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Method";
      dataGridLabelColumn1.MappingName = "ContactMethod";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 250;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MMM/yyyy HH:mm:ss";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Contact Date";
      dataGridLabelColumn2.MappingName = "ContactMade";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 135;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Note";
      dataGridLabelColumn3.MappingName = "Note";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 250;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "By";
      dataGridLabelColumn4.MappingName = "ContactMadeBy";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 125;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContact.ToString();
      this.dgContactAttempts.TableStyles.Add(tableStyle);
      Helper.RemoveEventHandlers(this.dgContactAttempts);
    }

    public void PopulateContactAttempts()
    {
      int num = 0;
      List<ContactAttempt> contactAttempts = ((UCLogCallout) this.LoadedControl).ContactAttempts;
      // ISSUE: explicit non-virtual call
      if (contactAttempts != null && __nonvirtual (contactAttempts.Count) > 0)
      {
        this.DvContactAttempts = new DataView(Helper.ToDataTable<ContactAttempt>((IList<ContactAttempt>) ((UCLogCallout) this.LoadedControl).ContactAttempts));
        num = this.DvContactAttempts.Table.Rows.Count;
      }
      this.tpContactAttempts.Text = "Contact Attempts (" + Conversions.ToString(num) + ")";
    }

    private void btnAddAttempt_Click(object sender, EventArgs e)
    {
      ((UCLogCallout) this.LoadedControl).AddContactAttempt();
    }

    private void dgContactAttempts_Click(object sender, EventArgs e)
    {
      if (this.DrSelectedContactAttempt == null)
        return;
      this.txtContactAttemptDetails.Text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.DrSelectedContactAttempt["ContactMethod"], (object) " on "), (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.DrSelectedContactAttempt["ContactMade"])).ToString("dddd, dd MMMM yyyy HH:mm")));
      TextBox contactAttemptDetails1;
      string str1 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) (contactAttemptDetails1 = this.txtContactAttemptDetails).Text, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "\r\nBy ", this.DrSelectedContactAttempt["ContactMadeBy"])));
      contactAttemptDetails1.Text = str1;
      TextBox contactAttemptDetails2;
      string str2 = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) (contactAttemptDetails2 = this.txtContactAttemptDetails).Text, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "\r\n\r\nNote: ", this.DrSelectedContactAttempt["Notes"])));
      contactAttemptDetails2.Text = str2;
    }
  }
}
