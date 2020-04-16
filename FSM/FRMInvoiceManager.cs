// Decompiled with JetBrains decompiler
// Type: FSM.FRMInvoiceManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.InvoicedLiness;
using FSM.Entity.Invoiceds;
using FSM.Entity.Sites;
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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMInvoiceManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataTable _dtVisit;
    private DataView _dvInvoices;
    private List<FSM.Entity.Customers.Customer> _customers;
    private FSM.Entity.Sites.Site _oSite;
    private ArrayList _invoicesToPrint;
    private bool _IsLoading;
    public string DDpaidBy;

    public FRMInvoiceManager()
    {
      this.Load += new EventHandler(this.FRMInvoiceManager_Load);
      this._dtVisit = new DataTable();
      this._customers = new List<FSM.Entity.Customers.Customer>();
      this._invoicesToPrint = new ArrayList();
      this._IsLoading = true;
      this.DDpaidBy = "";
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpInvoices { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgInvoices
    {
      get
      {
        return this._dgInvoices;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgInvoices_DoubleClick);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgInvoices_MouseUp);
        DataGrid dgInvoices1 = this._dgInvoices;
        if (dgInvoices1 != null)
        {
          dgInvoices1.DoubleClick -= eventHandler;
          dgInvoices1.MouseUp -= mouseEventHandler;
        }
        this._dgInvoices = value;
        DataGrid dgInvoices2 = this._dgInvoices;
        if (dgInvoices2 == null)
          return;
        dgInvoices2.DoubleClick += eventHandler;
        dgInvoices2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindCustomer
    {
      get
      {
        return this._btnFindCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindCustomer_Click);
        Button btnFindCustomer1 = this._btnFindCustomer;
        if (btnFindCustomer1 != null)
          btnFindCustomer1.Click -= eventHandler;
        this._btnFindCustomer = value;
        Button btnFindCustomer2 = this._btnFindCustomer;
        if (btnFindCustomer2 == null)
          return;
        btnFindCustomer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCustomers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode
    {
      get
      {
        return this._txtPostcode;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtJobNumber_TextChanged);
        TextBox txtPostcode1 = this._txtPostcode;
        if (txtPostcode1 != null)
          txtPostcode1.KeyDown -= keyEventHandler;
        this._txtPostcode = value;
        TextBox txtPostcode2 = this._txtPostcode;
        if (txtPostcode2 == null)
          return;
        txtPostcode2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindSite
    {
      get
      {
        return this._btnFindSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSite_Click);
        Button btnFindSite1 = this._btnFindSite;
        if (btnFindSite1 != null)
          btnFindSite1.Click -= eventHandler;
        this._btnFindSite = value;
        Button btnFindSite2 = this._btnFindSite;
        if (btnFindSite2 == null)
          return;
        btnFindSite2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtJobNumber
    {
      get
      {
        return this._txtJobNumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtJobNumber_TextChanged);
        TextBox txtJobNumber1 = this._txtJobNumber;
        if (txtJobNumber1 != null)
          txtJobNumber1.KeyDown -= keyEventHandler;
        this._txtJobNumber = value;
        TextBox txtJobNumber2 = this._txtJobNumber;
        if (txtJobNumber2 == null)
          return;
        txtJobNumber2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnSelectAll
    {
      get
      {
        return this._btnSelectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSelectAll_Click);
        Button btnSelectAll1 = this._btnSelectAll;
        if (btnSelectAll1 != null)
          btnSelectAll1.Click -= eventHandler;
        this._btnSelectAll = value;
        Button btnSelectAll2 = this._btnSelectAll;
        if (btnSelectAll2 == null)
          return;
        btnSelectAll2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeselectAll
    {
      get
      {
        return this._btnDeselectAll;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeselectAll_Click);
        Button btnDeselectAll1 = this._btnDeselectAll;
        if (btnDeselectAll1 != null)
          btnDeselectAll1.Click -= eventHandler;
        this._btnDeselectAll = value;
        Button btnDeselectAll2 = this._btnDeselectAll;
        if (btnDeselectAll2 == null)
          return;
        btnDeselectAll2.Click += eventHandler;
      }
    }

    internal virtual Button btnPrintOneItemOneInvoice
    {
      get
      {
        return this._btnPrintOneItemOneInvoice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintOneItemOneInvoice_Click);
        Button oneItemOneInvoice1 = this._btnPrintOneItemOneInvoice;
        if (oneItemOneInvoice1 != null)
          oneItemOneInvoice1.Click -= eventHandler;
        this._btnPrintOneItemOneInvoice = value;
        Button oneItemOneInvoice2 = this._btnPrintOneItemOneInvoice;
        if (oneItemOneInvoice2 == null)
          return;
        oneItemOneInvoice2.Click += eventHandler;
      }
    }

    internal virtual Button btnPrintManyItemsOnOneInvoice
    {
      get
      {
        return this._btnPrintManyItemsOnOneInvoice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintManyItemsOnOneInvoice_Click);
        Button itemsOnOneInvoice1 = this._btnPrintManyItemsOnOneInvoice;
        if (itemsOnOneInvoice1 != null)
          itemsOnOneInvoice1.Click -= eventHandler;
        this._btnPrintManyItemsOnOneInvoice = value;
        Button itemsOnOneInvoice2 = this._btnPrintManyItemsOnOneInvoice;
        if (itemsOnOneInvoice2 == null)
          return;
        itemsOnOneInvoice2.Click += eventHandler;
      }
    }

    internal virtual Button btnAddInvoiceAddress
    {
      get
      {
        return this._btnAddInvoiceAddress;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddInvoiceAddress_Click);
        Button addInvoiceAddress1 = this._btnAddInvoiceAddress;
        if (addInvoiceAddress1 != null)
          addInvoiceAddress1.Click -= eventHandler;
        this._btnAddInvoiceAddress = value;
        Button addInvoiceAddress2 = this._btnAddInvoiceAddress;
        if (addInvoiceAddress2 == null)
          return;
        addInvoiceAddress2.Click += eventHandler;
      }
    }

    internal virtual Button btnSearch
    {
      get
      {
        return this._btnSearch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSearch_Click);
        Button btnSearch1 = this._btnSearch;
        if (btnSearch1 != null)
          btnSearch1.Click -= eventHandler;
        this._btnSearch = value;
        Button btnSearch2 = this._btnSearch;
        if (btnSearch2 == null)
          return;
        btnSearch2.Click += eventHandler;
      }
    }

    internal virtual Button btnBackToVisitManager
    {
      get
      {
        return this._btnBackToVisitManager;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnBackToVisitManager_Click);
        Button backToVisitManager1 = this._btnBackToVisitManager;
        if (backToVisitManager1 != null)
          backToVisitManager1.Click -= eventHandler;
        this._btnBackToVisitManager = value;
        Button backToVisitManager2 = this._btnBackToVisitManager;
        if (backToVisitManager2 == null)
          return;
        backToVisitManager2.Click += eventHandler;
      }
    }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual ContextMenuStrip ContextMenuStrip1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem ts1
    {
      get
      {
        return this._ts1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ts1_Click);
        ToolStripMenuItem ts1_1 = this._ts1;
        if (ts1_1 != null)
          ts1_1.Click -= eventHandler;
        this._ts1 = value;
        ToolStripMenuItem ts1_2 = this._ts1;
        if (ts1_2 == null)
          return;
        ts1_2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem ts2
    {
      get
      {
        return this._ts2;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ts2_Click);
        ToolStripMenuItem ts2_1 = this._ts2;
        if (ts2_1 != null)
          ts2_1.Click -= eventHandler;
        this._ts2 = value;
        ToolStripMenuItem ts2_2 = this._ts2;
        if (ts2_2 == null)
          return;
        ts2_2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem RaiseProFormaToolStripMenuItem
    {
      get
      {
        return this._RaiseProFormaToolStripMenuItem;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.RaiseProFormaToolStripMenuItem_Click);
        ToolStripMenuItem toolStripMenuItem1 = this._RaiseProFormaToolStripMenuItem;
        if (toolStripMenuItem1 != null)
          toolStripMenuItem1.Click -= eventHandler;
        this._RaiseProFormaToolStripMenuItem = value;
        ToolStripMenuItem toolStripMenuItem2 = this._RaiseProFormaToolStripMenuItem;
        if (toolStripMenuItem2 == null)
          return;
        toolStripMenuItem2.Click += eventHandler;
      }
    }

    internal virtual Button btnChangeLine
    {
      get
      {
        return this._btnChangeLine;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnChangeLine_Click);
        Button btnChangeLine1 = this._btnChangeLine;
        if (btnChangeLine1 != null)
          btnChangeLine1.Click -= eventHandler;
        this._btnChangeLine = value;
        Button btnChangeLine2 = this._btnChangeLine;
        if (btnChangeLine2 == null)
          return;
        btnChangeLine2.Click += eventHandler;
      }
    }

    internal virtual Label lblDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAccNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.grpInvoices = new GroupBox();
      this.btnChangeLine = new Button();
      this.btnBackToVisitManager = new Button();
      this.dgInvoices = new DataGrid();
      this.btnSelectAll = new Button();
      this.btnDeselectAll = new Button();
      this.grpFilter = new GroupBox();
      this.txtAccNo = new TextBox();
      this.lblAccNo = new Label();
      this.lblDept = new Label();
      this.cboDept = new ComboBox();
      this.Label13 = new Label();
      this.cboRegion = new ComboBox();
      this.btnSearch = new Button();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.lblCustomers = new Label();
      this.txtPostcode = new TextBox();
      this.Label1 = new Label();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.txtJobNumber = new TextBox();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.Label6 = new Label();
      this.Label2 = new Label();
      this.Label10 = new Label();
      this.cboType = new ComboBox();
      this.btnExport = new Button();
      this.btnReset = new Button();
      this.btnPrintOneItemOneInvoice = new Button();
      this.btnPrintManyItemsOnOneInvoice = new Button();
      this.btnAddInvoiceAddress = new Button();
      this.btnView = new Button();
      this.Button1 = new Button();
      this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
      this.ts1 = new ToolStripMenuItem();
      this.ts2 = new ToolStripMenuItem();
      this.RaiseProFormaToolStripMenuItem = new ToolStripMenuItem();
      this.grpInvoices.SuspendLayout();
      this.dgInvoices.BeginInit();
      this.grpFilter.SuspendLayout();
      this.ContextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      this.grpInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpInvoices.Controls.Add((Control) this.btnChangeLine);
      this.grpInvoices.Controls.Add((Control) this.btnBackToVisitManager);
      this.grpInvoices.Controls.Add((Control) this.dgInvoices);
      this.grpInvoices.Controls.Add((Control) this.btnSelectAll);
      this.grpInvoices.Controls.Add((Control) this.btnDeselectAll);
      this.grpInvoices.Location = new System.Drawing.Point(8, 186);
      this.grpInvoices.Name = "grpInvoices";
      this.grpInvoices.Size = new Size(1182, 324);
      this.grpInvoices.TabIndex = 3;
      this.grpInvoices.TabStop = false;
      this.grpInvoices.Text = "Items Ready To Be Invoiced";
      this.btnChangeLine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnChangeLine.Location = new System.Drawing.Point(848, 20);
      this.btnChangeLine.Name = "btnChangeLine";
      this.btnChangeLine.Size = new Size(160, 23);
      this.btnChangeLine.TabIndex = 22;
      this.btnChangeLine.Text = "Change Line";
      this.btnBackToVisitManager.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnBackToVisitManager.Location = new System.Drawing.Point(1014, 20);
      this.btnBackToVisitManager.Name = "btnBackToVisitManager";
      this.btnBackToVisitManager.Size = new Size(160, 23);
      this.btnBackToVisitManager.TabIndex = 21;
      this.btnBackToVisitManager.Text = "Back To Visit Manager";
      this.dgInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgInvoices.DataMember = "";
      this.dgInvoices.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoices.Location = new System.Drawing.Point(8, 49);
      this.dgInvoices.Name = "dgInvoices";
      this.dgInvoices.Size = new Size(1166, 267);
      this.dgInvoices.TabIndex = 14;
      this.btnSelectAll.AccessibleDescription = "Export Job List To Excel";
      this.btnSelectAll.Location = new System.Drawing.Point(7, 20);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(88, 23);
      this.btnSelectAll.TabIndex = 19;
      this.btnSelectAll.Text = "Select All";
      this.btnDeselectAll.Location = new System.Drawing.Point(103, 20);
      this.btnDeselectAll.Name = "btnDeselectAll";
      this.btnDeselectAll.Size = new Size(88, 23);
      this.btnDeselectAll.TabIndex = 20;
      this.btnDeselectAll.Text = "Deselect All";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.txtAccNo);
      this.grpFilter.Controls.Add((Control) this.lblAccNo);
      this.grpFilter.Controls.Add((Control) this.lblDept);
      this.grpFilter.Controls.Add((Control) this.cboDept);
      this.grpFilter.Controls.Add((Control) this.Label13);
      this.grpFilter.Controls.Add((Control) this.cboRegion);
      this.grpFilter.Controls.Add((Control) this.btnSearch);
      this.grpFilter.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilter.Controls.Add((Control) this.txtCustomer);
      this.grpFilter.Controls.Add((Control) this.lblCustomers);
      this.grpFilter.Controls.Add((Control) this.txtPostcode);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.btnFindSite);
      this.grpFilter.Controls.Add((Control) this.txtSite);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.txtJobNumber);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.Label10);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(1182, 155);
      this.grpFilter.TabIndex = 4;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.txtAccNo.Location = new System.Drawing.Point(742, 123);
      this.txtAccNo.Name = "txtAccNo";
      this.txtAccNo.Size = new Size(160, 21);
      this.txtAccNo.TabIndex = 41;
      this.lblAccNo.Location = new System.Drawing.Point(606, 126);
      this.lblAccNo.Name = "lblAccNo";
      this.lblAccNo.Size = new Size(84, 16);
      this.lblAccNo.TabIndex = 40;
      this.lblAccNo.Text = "Acc No";
      this.lblDept.Location = new System.Drawing.Point(328, 123);
      this.lblDept.Name = "lblDept";
      this.lblDept.Size = new Size(84, 16);
      this.lblDept.TabIndex = 38;
      this.lblDept.Text = "Cost Centre";
      this.cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDept.Location = new System.Drawing.Point(418, 123);
      this.cboDept.Name = "cboDept";
      this.cboDept.Size = new Size(160, 21);
      this.cboDept.TabIndex = 39;
      this.Label13.Location = new System.Drawing.Point(8, 123);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(72, 16);
      this.Label13.TabIndex = 37;
      this.Label13.Text = "Region";
      this.cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegion.Location = new System.Drawing.Point(160, 120);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(160, 21);
      this.cboRegion.TabIndex = 36;
      this.btnSearch.AccessibleDescription = "Export Job List To Excel";
      this.btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSearch.Location = new System.Drawing.Point(1014, 123);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(120, 23);
      this.btnSearch.TabIndex = 28;
      this.btnSearch.Text = "Run Filter";
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(1142, 48);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 2;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(160, 48);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(974, 21);
      this.txtCustomer.TabIndex = 1;
      this.lblCustomers.Location = new System.Drawing.Point(8, 48);
      this.lblCustomers.Name = "lblCustomers";
      this.lblCustomers.Size = new Size(72, 21);
      this.lblCustomers.TabIndex = 27;
      this.lblCustomers.Text = "Customers";
      this.txtPostcode.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPostcode.Location = new System.Drawing.Point(160, 96);
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(160, 21);
      this.txtPostcode.TabIndex = 5;
      this.Label1.Location = new System.Drawing.Point(8, 96);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 20;
      this.Label1.Text = "Postcode";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(1142, 72);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 4;
      this.btnFindSite.Text = "...";
      this.btnFindSite.UseVisualStyleBackColor = false;
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(160, 72);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(974, 21);
      this.txtSite.TabIndex = 3;
      this.dtpTo.Location = new System.Drawing.Point(376, 24);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(160, 21);
      this.dtpTo.TabIndex = 13;
      this.dtpFrom.Location = new System.Drawing.Point(160, 24);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(160, 21);
      this.dtpFrom.TabIndex = 12;
      this.txtJobNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtJobNumber.Location = new System.Drawing.Point(742, 96);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(392, 21);
      this.txtJobNumber.TabIndex = 9;
      this.Label9.Location = new System.Drawing.Point(336, 24);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "and";
      this.Label8.Location = new System.Drawing.Point(8, 24);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(144, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "To Raise Date Between : ";
      this.Label6.Location = new System.Drawing.Point(606, 99);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(136, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Job/Order/Contract No";
      this.Label2.Location = new System.Drawing.Point(8, 72);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 16);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Property";
      this.Label10.Location = new System.Drawing.Point(328, 96);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(48, 16);
      this.Label10.TabIndex = 4;
      this.Label10.Text = "Type";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(418, 96);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(160, 21);
      this.cboType.TabIndex = 7;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 518);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 17;
      this.btnExport.Text = "Export";
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 518);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 18;
      this.btnReset.Text = "Reset";
      this.btnPrintOneItemOneInvoice.AccessibleDescription = "Export Job List To Excel";
      this.btnPrintOneItemOneInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnPrintOneItemOneInvoice.Location = new System.Drawing.Point(136, 518);
      this.btnPrintOneItemOneInvoice.Name = "btnPrintOneItemOneInvoice";
      this.btnPrintOneItemOneInvoice.Size = new Size(216, 23);
      this.btnPrintOneItemOneInvoice.TabIndex = 21;
      this.btnPrintOneItemOneInvoice.Text = "Print One Item One Invoice";
      this.btnPrintManyItemsOnOneInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnPrintManyItemsOnOneInvoice.Location = new System.Drawing.Point(360, 518);
      this.btnPrintManyItemsOnOneInvoice.Name = "btnPrintManyItemsOnOneInvoice";
      this.btnPrintManyItemsOnOneInvoice.Size = new Size(216, 23);
      this.btnPrintManyItemsOnOneInvoice.TabIndex = 22;
      this.btnPrintManyItemsOnOneInvoice.Text = "Print Many Items on One Invoice";
      this.btnAddInvoiceAddress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddInvoiceAddress.Location = new System.Drawing.Point(584, 518);
      this.btnAddInvoiceAddress.Name = "btnAddInvoiceAddress";
      this.btnAddInvoiceAddress.Size = new Size(160, 23);
      this.btnAddInvoiceAddress.TabIndex = 23;
      this.btnAddInvoiceAddress.Text = "Add Invoice Address";
      this.btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnView.Location = new System.Drawing.Point(1060, 518);
      this.btnView.Name = "btnView";
      this.btnView.Size = new Size(130, 23);
      this.btnView.TabIndex = 24;
      this.btnView.Text = "View";
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button1.ContextMenuStrip = this.ContextMenuStrip1;
      this.Button1.Location = new System.Drawing.Point(750, 518);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(169, 23);
      this.Button1.TabIndex = 26;
      this.Button1.Text = "Raise Alternative Doc";
      this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.ts1,
        (ToolStripItem) this.ts2,
        (ToolStripItem) this.RaiseProFormaToolStripMenuItem
      });
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new Size(173, 70);
      this.ts1.Name = "ts1";
      this.ts1.Size = new Size(172, 22);
      this.ts1.Text = "Missed DD Invoice";
      this.ts2.Name = "ts2";
      this.ts2.Size = new Size(172, 22);
      this.ts2.Text = "Missed DD Receipt";
      this.RaiseProFormaToolStripMenuItem.Name = "RaiseProFormaToolStripMenuItem";
      this.RaiseProFormaToolStripMenuItem.Size = new Size(172, 22);
      this.RaiseProFormaToolStripMenuItem.Text = "Raise Pro-Forma";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1198, 548);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.btnView);
      this.Controls.Add((Control) this.btnAddInvoiceAddress);
      this.Controls.Add((Control) this.btnPrintOneItemOneInvoice);
      this.Controls.Add((Control) this.btnPrintManyItemsOnOneInvoice);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.btnReset);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.grpInvoices);
      this.Name = nameof (FRMInvoiceManager);
      this.Text = "Ready To Be Invoice Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpInvoices, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintManyItemsOnOneInvoice, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintOneItemOneInvoice, 0);
      this.Controls.SetChildIndex((Control) this.btnAddInvoiceAddress, 0);
      this.Controls.SetChildIndex((Control) this.btnView, 0);
      this.Controls.SetChildIndex((Control) this.Button1, 0);
      this.grpInvoices.ResumeLayout(false);
      this.dgInvoices.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ContextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupInvoiceDataGrid();
      this.ResetFilters();
      try
      {
        if (this.get_GetParameter(2) != null && this.get_GetParameter(2).GetType().Equals(typeof (DataTable)))
          this.dtVisitFilters = (DataTable) this.get_GetParameter(2);
        if (this.get_GetParameter(0) == null)
          return;
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(this.get_GetParameter(0), (System.Type) null, "Table", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "rows", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "count", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (object) 0, false))
        {
          this.dtpFrom.Value = Conversions.ToDate(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(NewLateBinding.LateGet(NewLateBinding.LateGet(this.get_GetParameter(0), (System.Type) null, "Table", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Select", new object[1]
          {
            (object) "RaiseDate = MIN(RaiseDate)"
          }, (string[]) null, (System.Type[]) null, (bool[]) null), new object[1]
          {
            (object) 0
          }, (string[]) null), (System.Type) null, "Item", new object[1]
          {
            (object) "RaiseDate"
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
          this.dtpTo.Value = Conversions.ToDate(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(NewLateBinding.LateGet(NewLateBinding.LateGet(this.get_GetParameter(0), (System.Type) null, "Table", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "Select", new object[1]
          {
            (object) "RaiseDate = MAX(RaiseDate)"
          }, (string[]) null, (System.Type[]) null, (bool[]) null), new object[1]
          {
            (object) 0
          }, (string[]) null), (System.Type) null, "Item", new object[1]
          {
            (object) "RaiseDate"
          }, (string[]) null, (System.Type[]) null, (bool[]) null));
        }
        this.InvoicesDataview = (DataView) this.get_GetParameter(0);
        ((IBaseForm) this).SetFormParameters = (Array) null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
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

    public DataTable dtVisitFilters
    {
      get
      {
        if (this._dtVisit.Columns.Count == 0)
        {
          this._dtVisit.Columns.Add("Field");
          this._dtVisit.Columns.Add("Value");
          this._dtVisit.Columns.Add("Type");
        }
        return this._dtVisit;
      }
      set
      {
        this._dtVisit = value;
      }
    }

    private DataView InvoicesDataview
    {
      get
      {
        return this._dvInvoices;
      }
      set
      {
        this._dvInvoices = value;
        this._dvInvoices.AllowNew = false;
        this._dvInvoices.AllowEdit = false;
        this._dvInvoices.AllowDelete = false;
        this._dvInvoices.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
        this.dgInvoices.DataSource = (object) this.InvoicesDataview;
      }
    }

    private DataRow SelectedInvoiceDataRow
    {
      get
      {
        return this.dgInvoices.CurrentRowIndex != -1 ? this.InvoicesDataview[this.dgInvoices.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public List<FSM.Entity.Customers.Customer> Customers
    {
      get
      {
        return this._customers;
      }
      set
      {
        this._customers = value;
        this.theSite = (FSM.Entity.Sites.Site) null;
        if (this._customers.Count > 0)
        {
          string str = string.Empty;
          bool flag = false;
          try
          {
            foreach (FSM.Entity.Customers.Customer customer in this._customers)
            {
              if (flag)
                str += ", ";
              str = str + customer.Name + " (A/C No : " + customer.AccountNumber + ")";
              flag = true;
            }
          }
          finally
          {
            List<FSM.Entity.Customers.Customer>.Enumerator enumerator;
            enumerator.Dispose();
          }
          this.txtCustomer.Text = str;
        }
        else
          this.txtCustomer.Text = "";
      }
    }

    public FSM.Entity.Sites.Site theSite
    {
      get
      {
        return this._oSite;
      }
      set
      {
        this._oSite = value;
        if (this._oSite != null)
          this.txtSite.Text = this.theSite.Address1 + ", " + this.theSite.Address2 + ", " + this.theSite.Postcode;
        else
          this.txtSite.Text = "";
      }
    }

    private ArrayList InvoicesToPrint
    {
      get
      {
        return this._invoicesToPrint;
      }
      set
      {
        this._invoicesToPrint = value;
      }
    }

    private bool IsLoading
    {
      get
      {
        return this._IsLoading;
      }
      set
      {
        this._IsLoading = value;
      }
    }

    private void SetupInvoiceDataGrid()
    {
      Helper.SetUpDataGrid(this.dgInvoices, false);
      DataGridTableStyle tableStyle = this.dgInvoices.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridBoolColumn dataGridBoolColumn = new DataGridBoolColumn();
      dataGridBoolColumn.HeaderText = "";
      dataGridBoolColumn.MappingName = "Tick";
      dataGridBoolColumn.ReadOnly = true;
      dataGridBoolColumn.Width = 25;
      dataGridBoolColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Customer";
      dataGridLabelColumn1.MappingName = "Customer";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Property";
      dataGridLabelColumn2.MappingName = "Site";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Inv. Type";
      dataGridLabelColumn3.MappingName = "InvoiceType";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 70;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Job/Order/Contract No.";
      dataGridLabelColumn4.MappingName = "JobNumber";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 140;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MMM/yyyy";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Raise Date";
      dataGridLabelColumn5.MappingName = "RaiseDate";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 85;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Inv. Addr. Type";
      dataGridLabelColumn6.MappingName = "InvoiceAddressType";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Invoice Address";
      dataGridLabelColumn7.MappingName = "InvoiceAddress";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Department";
      dataGridLabelColumn8.MappingName = "Department";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "C";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Amount";
      dataGridLabelColumn9.MappingName = "Amount";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 75;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "VAT Code";
      dataGridLabelColumn10.MappingName = "VatCode";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 75;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "VAT %";
      dataGridLabelColumn11.MappingName = "VAT";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 75;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
      this.dgInvoices.TableStyles.Add(tableStyle);
    }

    private void dgInvoices_DoubleClick(object sender, EventArgs e)
    {
      this.view();
    }

    private void btnView_Click(object sender, EventArgs e)
    {
      this.view();
    }

    private void FRMInvoiceManager_Load(object sender, EventArgs e)
    {
      this.IsLoading = true;
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.IsLoading = false;
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      FRMFindCustomers frmFindCustomers = new FRMFindCustomers();
      int num = (int) frmFindCustomers.ShowDialog();
      this.Customers = new List<FSM.Entity.Customers.Customer>();
      EnumerableRowCollection<DataRow> source1 = frmFindCustomers.CustomerDataView.Table.AsEnumerable();
      Func<DataRow, bool> predicate;
      // ISSUE: reference to a compiler-generated field
      if (FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        predicate = FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D0;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D0 = predicate = (Func<DataRow, bool>) (row => row.Field<bool>("Include"));
      }
      EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
      Func<DataRow, DataRow> selector1;
      // ISSUE: reference to a compiler-generated field
      if (FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector1 = FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D1 = selector1 = (Func<DataRow, DataRow>) (row => row);
      }
      DataRow[] array = source2.Select<DataRow, DataRow>(selector1).ToArray<DataRow>();
      Func<DataRow, int> selector2;
      // ISSUE: reference to a compiler-generated field
      if (FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D2 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector2 = FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D2;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMInvoiceManager._Closure\u0024__.\u0024I205\u002D2 = selector2 = (Func<DataRow, int>) (dr => Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dr["CustomerID"])));
      }
      List<int> list = ((IEnumerable<DataRow>) array).Select<DataRow, int>(selector2).ToList<int>();
      try
      {
        foreach (int CustomerID in list)
          this.Customers.Add(App.DB.Customer.Customer_Get(CustomerID));
      }
      finally
      {
        List<int>.Enumerator enumerator;
        enumerator.Dispose();
      }
      this.Customers = this.Customers;
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int num;
      if (this.Customers.Count > 0)
      {
        List<FSM.Entity.Customers.Customer> customers = this.Customers;
        Func<FSM.Entity.Customers.Customer, int> selector;
        // ISSUE: reference to a compiler-generated field
        if (FRMInvoiceManager._Closure\u0024__.\u0024I206\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector = FRMInvoiceManager._Closure\u0024__.\u0024I206\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMInvoiceManager._Closure\u0024__.\u0024I206\u002D0 = selector = (Func<FSM.Entity.Customers.Customer, int>) (x => x.CustomerID);
        }
        num = App.FindRecordMultiId(Enums.TableNames.tblSite, customers.Select<FSM.Entity.Customers.Customer, int>(selector).Distinct<int>().ToList<int>());
      }
      else
        num = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
      if ((uint) num <= 0U)
        return;
      this.theSite = App.DB.Sites.Get((object) num, SiteSQL.GetBy.SiteId, (object) null);
    }

    private void dgInvoices_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgInvoices.HitTest(e.X, e.Y);
      if (hitTestInfo.Type != DataGrid.HitTestType.Cell || hitTestInfo.Column != 0)
        return;
      this.SelectedInvoiceDataRow["Tick"] = (object) !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["tick"]));
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      DataRow[] dataRowArray = this.InvoicesDataview.Table.Select(this.InvoicesDataview.RowFilter);
      int index = 0;
      while (index < dataRowArray.Length)
      {
        dataRowArray[index]["tick"] = (object) 1;
        checked { ++index; }
      }
    }

    private void btnDeselectAll_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      try
      {
        enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) 0;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnPrintOneItemOneInvoice_Click(object sender, EventArgs e)
    {
      try
      {
        bool flag = false;
        if (!this.ValidateInvoiceAddress())
          return;
        this.FindPartPayJobs(false);
        IEnumerator enumerator;
        try
        {
          enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["tick"])), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(current["PaymentTermID"], (object) 69817, false))))
            {
              if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Amount"])) > 0.0)
              {
                if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(current["InvoiceToBeRaisedID"])).Count == 0)
                {
                  Invoiced oInvoiced = new Invoiced();
                  JobNumber jobNumber = new JobNumber();
                  JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Quoted | Enums.JobDefinition.Misc);
                  oInvoiced.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
                  oInvoiced.SetRaisedByUserID = (object) App.loggedInUser.UserID;
                  oInvoiced.RaisedDate = Conversions.ToDate(current["RaiseDate"]);
                  oInvoiced.SetVATRateID = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["TAXRateID"], (object) 0, false) ? (object) App.DB.VATRatesSQL.VATRates_Get_ByDate(DateAndTime.Now) : RuntimeHelpers.GetObjectValue(current["TAXRateID"]);
                  oInvoiced.SetPaymentTermID = RuntimeHelpers.GetObjectValue(current["PaymentTermID"]);
                  oInvoiced.SetPaidByID = RuntimeHelpers.GetObjectValue(current["PaidByID"]);
                  Invoiced invoiced = App.DB.Invoiced.Insert(oInvoiced);
                  App.DB.InvoicedLines.Insert(new InvoicedLines()
                  {
                    SetAmount = RuntimeHelpers.GetObjectValue(current["Amount"]),
                    SetInvoicedID = (object) invoiced.InvoicedID,
                    SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(current["InvoiceToBeRaisedID"])
                  });
                  this.InvoicesToPrint.Add((object) new ArrayList()
                  {
                    (object) invoiced.InvoicedID,
                    RuntimeHelpers.GetObjectValue(current["RegionID"])
                  });
                }
              }
              else
                flag = true;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (flag)
        {
          int num = (int) App.ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        this.Print();
        this.PopulateDatagrid();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }

    private void btnPrintManyItemsOnOneInvoice_Click(object sender, EventArgs e)
    {
      try
      {
        bool flag = false;
        if (this.ValidateInvoiceAddress())
        {
          this.FindPartPayJobs(true);
          DataTable dataTable = new DataTable();
          dataTable.Columns.Add("AddressTypeID");
          dataTable.Columns.Add("AddressID");
          int num1 = -1;
          DataRow[] dataRowArray1 = this.InvoicesDataview.Table.Select("tick = 1");
          int index1 = 0;
          while (index1 < dataRowArray1.Length)
          {
            DataRow dataRow = dataRowArray1[index1];
            if (num1 > -1 && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual((object) num1, dataRow["TAXRateID"], false))
            {
              int num2 = (int) Interaction.MsgBox((object) "Different VAT rates cannot be batched", MsgBoxStyle.OkOnly, (object) "Ooops");
              return;
            }
            num1 = Conversions.ToInteger(dataRow["TAXRateID"]);
            checked { ++index1; }
          }
          DateTime now = DateAndTime.Now;
          FRMChangeRaiseDate frmChangeRaiseDate = new FRMChangeRaiseDate();
          frmChangeRaiseDate.dtpTaxDate.Value = now.Date;
          int num3 = (int) frmChangeRaiseDate.ShowDialog();
          if (frmChangeRaiseDate.DialogResult != DialogResult.OK)
            return;
          now = frmChangeRaiseDate.dtpTaxDate.Value;
          IEnumerator enumerator;
          try
          {
            enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["tick"])), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(current["PAYMENTTERMID"], (object) 69817, false))))
              {
                if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Amount"])) > 0.0)
                {
                  if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(current["InvoiceToBeRaisedID"])).Count == 0 && dataTable.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AddressTypeID=", current["AddressTypeID"]), (object) " AND AddressID="), current["AddressID"]))).Length == 0)
                  {
                    DataRow[] dataRowArray2 = this.InvoicesDataview.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AddressTypeID=", current["AddressTypeID"]), (object) " AND AddressID="), current["AddressID"]), (object) " AND Tick = 1")));
                    Invoiced oInvoiced = new Invoiced();
                    JobNumber jobNumber = new JobNumber();
                    JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Quoted | Enums.JobDefinition.Misc);
                    oInvoiced.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
                    oInvoiced.SetRaisedByUserID = (object) App.loggedInUser.UserID;
                    oInvoiced.RaisedDate = now;
                    oInvoiced.SetVATRateID = (object) num1;
                    Invoiced invoiced = App.DB.Invoiced.Insert(oInvoiced);
                    int num2 = checked (dataRowArray2.Length - 1);
                    int index2 = 0;
                    while (index2 <= num2)
                    {
                      App.DB.InvoicedLines.Insert(new InvoicedLines()
                      {
                        SetAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRowArray2[index2]["Amount"])),
                        SetInvoicedID = (object) invoiced.InvoicedID,
                        SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(dataRowArray2[index2]["InvoiceToBeRaisedID"])
                      });
                      checked { ++index2; }
                    }
                    this.InvoicesToPrint.Add((object) new ArrayList()
                    {
                      (object) invoiced.InvoicedID,
                      RuntimeHelpers.GetObjectValue(current["RegionID"])
                    });
                    DataRow row = dataTable.NewRow();
                    row["AddressTypeID"] = RuntimeHelpers.GetObjectValue(current["AddressTypeID"]);
                    row["AddressID"] = RuntimeHelpers.GetObjectValue(current["AddressID"]);
                    dataTable.Rows.Add(row);
                  }
                }
                else
                  flag = true;
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          if (flag)
          {
            int num4 = (int) App.ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          this.Print();
          this.PopulateDatagrid();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddInvoiceAddress_Click(object sender, EventArgs e)
    {
      if (this.SelectedInvoiceDataRow == null)
        return;
      if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["AddressLinkID"])) == 0)
      {
        App.ShowForm(typeof (FRMAddInvoiceAddress), true, new object[3]
        {
          this.SelectedInvoiceDataRow["LinkID"],
          this.SelectedInvoiceDataRow["InvoiceToBeRaisedID"],
          (object) this
        }, false);
      }
      else
      {
        int num = (int) MessageBox.Show("This line has an Invoice Address", "Invoice Address", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      this.PopulateDatagrid();
    }

    private void btnBackToVisitManager_Click(object sender, EventArgs e)
    {
      Navigation.Navigate(Enums.MenuTypes.Jobs);
      App.ShowForm(typeof (FRMVisitManager), false, new object[3]
      {
        null,
        (object) this.dtVisitFilters,
        (object) "From Invoice Manager"
      }, false);
    }

    private void view()
    {
      if (this.SelectedInvoiceDataRow != null)
      {
        switch (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["InvoiceTypeID"])))
        {
          case 260:
            App.ShowForm(typeof (FRMEngineerVisit), true, new object[1]
            {
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["EngineerVisitID"]))
            }, false);
            break;
          case 261:
            switch (Conversions.ToInteger(this.SelectedInvoiceDataRow["OrderTypeID"]))
            {
              case 1:
                App.ShowForm(typeof (FRMOrder), false, new object[4]
                {
                  this.SelectedInvoiceDataRow["OrderID"],
                  (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["OrderSiteID"])),
                  (object) 0,
                  (object) this
                }, false);
                break;
              case 2:
                App.ShowForm(typeof (FRMOrder), false, new object[4]
                {
                  this.SelectedInvoiceDataRow["OrderID"],
                  this.SelectedInvoiceDataRow["VanID"],
                  (object) 0,
                  (object) this
                }, false);
                break;
              case 3:
                App.ShowForm(typeof (FRMOrder), false, new object[4]
                {
                  this.SelectedInvoiceDataRow["OrderID"],
                  this.SelectedInvoiceDataRow["WarehouseID"],
                  (object) 0,
                  (object) this
                }, false);
                break;
              case 4:
                App.ShowForm(typeof (FRMOrder), false, new object[4]
                {
                  this.SelectedInvoiceDataRow["OrderID"],
                  this.SelectedInvoiceDataRow["EngineerVisitID"],
                  (object) 0,
                  (object) this
                }, false);
                break;
            }
            break;
          case 327:
            App.ShowForm(typeof (FRMContractOriginal), true, new object[3]
            {
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["ContractID"])),
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["CustomerID"])),
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["InvoiceToBeRaisedID"]))
            }, false);
            break;
        }
        this.PopulateDatagrid();
      }
      else
      {
        int num = (int) App.ShowMessage("Please select an invoice.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void PopulateDatagrid()
    {
      Cursor.Current = Cursors.WaitCursor;
      this.InvoicesDataview = App.DB.InvoiceToBeRaised.Invoices_GetAll_Manager(this.dtpFrom.Value, this.dtpTo.Value);
      this.RunFilter();
      Cursor.Current = Cursors.Default;
    }

    private void ResetFilters()
    {
      this.Customers = new List<FSM.Entity.Customers.Customer>();
      DateTime dateTime;
      switch (DateAndTime.Today.DayOfWeek)
      {
        case DayOfWeek.Sunday:
          dateTime = DateAndTime.Now.AddDays(-6.0);
          break;
        case DayOfWeek.Monday:
          dateTime = DateAndTime.Now;
          break;
        case DayOfWeek.Tuesday:
          dateTime = DateAndTime.Now.AddDays(-1.0);
          break;
        case DayOfWeek.Wednesday:
          dateTime = DateAndTime.Now.AddDays(-2.0);
          break;
        case DayOfWeek.Thursday:
          dateTime = DateAndTime.Now.AddDays(-3.0);
          break;
        case DayOfWeek.Friday:
          dateTime = DateAndTime.Now.AddDays(-4.0);
          break;
        case DayOfWeek.Saturday:
          dateTime = DateAndTime.Now.AddDays(-5.0);
          break;
      }
      this.dtpFrom.Value = dateTime;
      this.dtpTo.Value = dateTime.AddDays(7.0);
      ComboBox comboBox = this.cboType;
      Combo.SetUpCombo(ref comboBox, App.DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = comboBox;
      comboBox = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(0));
      this.cboType = comboBox;
      comboBox = this.cboRegion;
      Combo.SetUpCombo(ref comboBox, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboRegion = comboBox;
      if (true == App.IsGasway)
      {
        comboBox = this.cboDept;
        Combo.SetUpCombo(ref comboBox, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboDept = comboBox;
      }
      else
      {
        comboBox = this.cboDept;
        Combo.SetUpCombo(ref comboBox, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboDept = comboBox;
      }
      this.txtJobNumber.Text = "";
      this.txtPostcode.Text = "";
    }

    private void RunFilter()
    {
      if (this.InvoicesDataview == null)
        return;
      string str1 = "1 = 1 ";
      if (this.Customers.Count > 0)
      {
        string str2 = str1;
        List<FSM.Entity.Customers.Customer> customers = this.Customers;
        Func<FSM.Entity.Customers.Customer, int> selector;
        // ISSUE: reference to a compiler-generated field
        if (FRMInvoiceManager._Closure\u0024__.\u0024I218\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector = FRMInvoiceManager._Closure\u0024__.\u0024I218\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMInvoiceManager._Closure\u0024__.\u0024I218\u002D0 = selector = (Func<FSM.Entity.Customers.Customer, int>) (x => x.CustomerID);
        }
        string str3 = string.Join<int>(", ", customers.Select<FSM.Entity.Customers.Customer, int>(selector).Distinct<int>());
        str1 = str2 + " AND CustomerID IN (" + str3 + ")";
      }
      if (this.theSite != null)
        str1 += " AND SiteID = " + Conversions.ToString(this.theSite.SiteID);
      if ((uint) this.txtPostcode.Text.Trim().Length > 0U)
        str1 = str1 + " AND Postcode LIKE '" + this.txtPostcode.Text.Trim() + "%'";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboType)) != 0.0)
        str1 += " AND InvoiceTypeID = " + Combo.get_GetSelectedItemValue(this.cboType);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboRegion)) != 0.0)
        str1 += " AND RegionID = " + Combo.get_GetSelectedItemValue(this.cboRegion);
      string str4 = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDept));
      if (Helper.IsValidInteger((object) str4) && Helper.MakeIntegerValid((object) str4) > 0)
        str1 = str1 + " AND Department = '" + str4 + "'";
      else if (!Versioned.IsNumeric((object) str4))
        str1 = str1 + " AND Department = '" + str4 + "'";
      if ((uint) this.txtJobNumber.Text.Trim().Length > 0U)
        str1 = str1 + " AND JobNumber LIKE '" + this.txtJobNumber.Text.Trim() + "%'";
      if ((uint) this.txtAccNo.Text.Trim().Length > 0U)
        str1 = str1 + " AND AccountNumber LIKE '" + this.txtAccNo.Text.Trim() + "%'";
      this.InvoicesDataview.RowFilter = str1;
    }

    public void Export()
    {
      Cursor.Current = Cursors.WaitCursor;
      DataTable dtData = new DataTable();
      dtData.Columns.Add("Customer");
      dtData.Columns.Add("Site");
      dtData.Columns.Add("InvoiceType");
      dtData.Columns.Add("JobNumber");
      dtData.Columns.Add("RaiseDate");
      dtData.Columns.Add("InvoiceAddressType");
      dtData.Columns.Add("InvoiceAddress");
      dtData.Columns.Add("SorDescription");
      dtData.Columns.Add("DDMSRef");
      dtData.Columns.Add("CostCentre");
      dtData.Columns.Add("VatCode");
      dtData.Columns.Add("Amount", typeof (double));
      IEnumerator enumerator;
      try
      {
        enumerator = ((DataView) this.dgInvoices.DataSource).GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          DataRow row1 = dtData.NewRow();
          row1["Customer"] = RuntimeHelpers.GetObjectValue(current["Customer"]);
          row1["Site"] = RuntimeHelpers.GetObjectValue(current["Site"]);
          row1["InvoiceType"] = RuntimeHelpers.GetObjectValue(current["InvoiceType"]);
          row1["JobNumber"] = RuntimeHelpers.GetObjectValue(current["JobNumber"]);
          row1["RaiseDate"] = (object) Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(current["RaiseDate"]), "dd/MM/yyyy");
          row1["InvoiceAddressType"] = RuntimeHelpers.GetObjectValue(current["InvoiceAddressType"]);
          row1["InvoiceAddress"] = RuntimeHelpers.GetObjectValue(current["InvoiceAddress"]);
          row1["CostCentre"] = RuntimeHelpers.GetObjectValue(current["Department"]);
          row1["VatCode"] = RuntimeHelpers.GetObjectValue(current["VatCode"]);
          row1["DDMSRef"] = RuntimeHelpers.GetObjectValue(current["DDMSRef"]);
          int EngineerVisitID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["EngineerVisitID"]));
          if (EngineerVisitID > 0)
          {
            EnumerableRowCollection<DataRow> source1 = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get_ChargedBreakDown(EngineerVisitID).Table.AsEnumerable();
            Func<DataRow, bool> predicate;
            // ISSUE: reference to a compiler-generated field
            if (FRMInvoiceManager._Closure\u0024__.\u0024I219\u002D0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              predicate = FRMInvoiceManager._Closure\u0024__.\u0024I219\u002D0;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              FRMInvoiceManager._Closure\u0024__.\u0024I219\u002D0 = predicate = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "SOR", false) == 0);
            }
            EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
            Func<DataRow, string> selector;
            // ISSUE: reference to a compiler-generated field
            if (FRMInvoiceManager._Closure\u0024__.\u0024I219\u002D1 != null)
            {
              // ISSUE: reference to a compiler-generated field
              selector = FRMInvoiceManager._Closure\u0024__.\u0024I219\u002D1;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              FRMInvoiceManager._Closure\u0024__.\u0024I219\u002D1 = selector = (Func<DataRow, string>) (row => row.Field<string>("Description"));
            }
            string str = string.Join(" / ", source2.Select<DataRow, string>(selector).ToArray<string>());
            row1["SorDescription"] = (object) str;
          }
          else
            row1["SorDescription"] = (object) string.Empty;
          row1["Amount"] = RuntimeHelpers.GetObjectValue(current["Amount"]);
          dtData.Rows.Add(row1);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      ExportHelper.Export(dtData, "Invoice List", Enums.ExportType.XLS);
      Cursor.Current = Cursors.Default;
    }

    public bool ValidateInvoiceAddress()
    {
      string text = "The following lines are missing invoice addresses: \r\n";
      bool flag = true;
      IEnumerator enumerator;
      try
      {
        enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["tick"])) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["AddressLinkID"], (object) 0, false))
          {
            text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) text, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "* ", current["JobNumber"]), (object) "\r\n")));
            flag = false;
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      if (!flag)
      {
        int num = (int) MessageBox.Show(text, "Invoice Addresses", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      return flag;
    }

    public void Print()
    {
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.InvoicesToPrint
      }, "Invoice", Enums.SystemDocumentType.Invoice, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.InvoicesToPrint.Clear();
    }

    public void FindPartPayJobs(bool Multi)
    {
      try
      {
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.InvoicesDataview.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator1.Current;
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current1["tick"])) && Conversions.ToInteger(current1["InvoiceTypeID"]) == 260 && App.DB.Job.Job_Get(Conversions.ToInteger(current1["JobID"])).ToBePartPaid)
            {
              current1["tick"] = (object) 0;
              if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current1["invoicedID"])) == 0)
              {
                DataTable table1 = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(Conversions.ToInteger(current1["JobID"])).Table;
                if (table1.Rows.Count > 0)
                {
                  this.InsertInvoiceLines(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current1["Amount"])), Conversions.ToInteger(table1.Rows[0]["InvoicedID"]), Conversions.ToInteger(current1["InvoiceToBeRaisedID"]));
                  bool flag = false;
                  IEnumerator enumerator2;
                  try
                  {
                    enumerator2 = this.InvoicesToPrint.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((ArrayList) enumerator2.Current)[0], table1.Rows[0]["InvoicedID"], false))
                        flag = true;
                    }
                  }
                  finally
                  {
                    if (enumerator2 is IDisposable)
                      (enumerator2 as IDisposable).Dispose();
                  }
                  if (!flag)
                    this.InvoicesToPrint.Add((object) new ArrayList()
                    {
                      RuntimeHelpers.GetObjectValue(table1.Rows[0]["InvoicedID"]),
                      RuntimeHelpers.GetObjectValue(current1["RegionID"])
                    });
                }
                else
                {
                  Invoiced oInvoiced = new Invoiced();
                  JobNumber jobNumber = new JobNumber();
                  JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Quoted | Enums.JobDefinition.Misc);
                  oInvoiced.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
                  oInvoiced.SetRaisedByUserID = (object) App.loggedInUser.UserID;
                  oInvoiced.RaisedDate = DateAndTime.Now;
                  Invoiced inv = App.DB.Invoiced.Insert(oInvoiced);
                  DataTable table2 = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(Conversions.ToInteger(current1["JobID"])).Table;
                  IEnumerator enumerator2;
                  try
                  {
                    enumerator2 = table2.Rows.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                      DataRow current2 = (DataRow) enumerator2.Current;
                      this.InsertInvoiceLines(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current2["Amount"])), inv.InvoicedID, Conversions.ToInteger(current2["InvoiceToBeRaisedID"]));
                    }
                  }
                  finally
                  {
                    if (enumerator2 is IDisposable)
                      (enumerator2 as IDisposable).Dispose();
                  }
                  if (Multi)
                    this.MultiInvoicePPJob(current1, inv, table2);
                  bool flag = false;
                  IEnumerator enumerator3;
                  try
                  {
                    enumerator3 = this.InvoicesToPrint.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((ArrayList) enumerator3.Current)[0], (object) inv.InvoicedID, false))
                        flag = true;
                    }
                  }
                  finally
                  {
                    if (enumerator3 is IDisposable)
                      (enumerator3 as IDisposable).Dispose();
                  }
                  if (!flag)
                    this.InvoicesToPrint.Add((object) new ArrayList()
                    {
                      (object) inv.InvoicedID,
                      RuntimeHelpers.GetObjectValue(current1["RegionID"])
                    });
                }
              }
              else
              {
                IEnumerator enumerator2;
                try
                {
                  enumerator2 = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsNotInvoice_ByJobID(Conversions.ToInteger(current1["JobID"])).GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRow current2 = (DataRow) enumerator2.Current;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(current1["InvoiceToBeRaisedID"], current2["InvoiceToBeRaisedID"], false))
                      this.InsertInvoiceLines(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current2["Amount"])), Conversions.ToInteger(current1["invoicedID"]), Conversions.ToInteger(current2["InvoiceToBeRaisedID"]));
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
                bool flag = false;
                IEnumerator enumerator3;
                try
                {
                  enumerator3 = this.InvoicesToPrint.GetEnumerator();
                  while (enumerator3.MoveNext())
                  {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((ArrayList) enumerator3.Current)[0], current1["InvoicedID"], false))
                      flag = true;
                  }
                }
                finally
                {
                  if (enumerator3 is IDisposable)
                    (enumerator3 as IDisposable).Dispose();
                }
                if (!flag)
                  this.InvoicesToPrint.Add((object) new ArrayList()
                  {
                    RuntimeHelpers.GetObjectValue(current1["InvoicedID"]),
                    RuntimeHelpers.GetObjectValue(current1["RegionID"])
                  });
              }
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }

    private void MultiInvoicePPJob(DataRow dr, Invoiced inv, DataTable dtVisits)
    {
      try
      {
        DataRow[] dataRowArray = this.InvoicesDataview.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AddressTypeID=", dr["AddressTypeID"]), (object) " AND AddressID="), dr["AddressID"])));
        int num = checked (dataRowArray.Length - 1);
        int index = 0;
        while (index <= num)
        {
          if (Conversions.ToInteger(dataRowArray[index]["InvoiceTypeID"]) == 261)
          {
            dataRowArray[index]["tick"] = (object) 0;
            this.InsertInvoiceLines(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRowArray[index]["Amount"])), inv.InvoicedID, Conversions.ToInteger(dataRowArray[index]["InvoiceToBeRaisedID"]));
          }
          else if (dtVisits.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "InvoiceToBeRaisedID=", dataRowArray[index]["InvoiceToBeRaisedID"]))).Length > 0)
            dataRowArray[index]["tick"] = (object) 0;
          else if (App.DB.Job.Job_Get(Conversions.ToInteger(dataRowArray[index]["JobID"])).ToBePartPaid)
          {
            bool flag = false;
            DataTable table = App.DB.InvoiceToBeRaised.InvoicesToBeRaised_GetAllVisitsInvoice_ByJobID(Conversions.ToInteger(dataRowArray[index]["JobID"])).Table;
            if (table.Rows.Count > 0)
            {
              IEnumerator enumerator;
              try
              {
                enumerator = table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRowArray[index]["InvoicedID"])) == Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["InvoicedID"])))
                    flag = true;
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
              if (!flag)
              {
                dataRowArray[index]["tick"] = (object) 0;
                this.InsertInvoiceLines(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRowArray[index]["Amount"])), inv.InvoicedID, Conversions.ToInteger(dataRowArray[index]["InvoiceToBeRaisedID"]));
              }
            }
            else
            {
              dataRowArray[index]["tick"] = (object) 0;
              this.InsertInvoiceLines(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRowArray[index]["Amount"])), inv.InvoicedID, Conversions.ToInteger(dataRowArray[index]["InvoiceToBeRaisedID"]));
            }
          }
          else
          {
            dataRowArray[index]["tick"] = (object) 0;
            this.InsertInvoiceLines(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRowArray[index]["Amount"])), inv.InvoicedID, Conversions.ToInteger(dataRowArray[index]["InvoiceToBeRaisedID"]));
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }

    private void InsertInvoiceLines(double amount, int invoicedID, int InvoiceToBeRaisedID)
    {
      App.DB.InvoicedLines.Insert(new InvoicedLines()
      {
        SetAmount = (object) amount,
        SetInvoicedID = (object) invoicedID,
        SetInvoiceToBeRaisedID = (object) InvoiceToBeRaisedID
      });
    }

    private void txtJobNumber_TextChanged(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.PopulateDatagrid();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      this.ContextMenuStrip1.Show((Control) this.Button1, new System.Drawing.Point(0, 0));
    }

    private void ts1_Click(object sender, EventArgs e)
    {
      try
      {
        bool flag = false;
        if (!this.ValidateInvoiceAddress())
          return;
        this.FindPartPayJobs(false);
        IEnumerator enumerator;
        try
        {
          enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["tick"])), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(current["PAYMENTTERMID"], (object) 69817, false))))
            {
              if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Amount"])) > 0.0)
              {
                if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(current["InvoiceToBeRaisedID"])).Count == 0)
                {
                  Invoiced oInvoiced = new Invoiced();
                  JobNumber jobNumber = new JobNumber();
                  JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Quoted | Enums.JobDefinition.Misc);
                  oInvoiced.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
                  oInvoiced.SetRaisedByUserID = (object) App.loggedInUser.UserID;
                  oInvoiced.RaisedDate = Conversions.ToDate(current["RaiseDate"]);
                  oInvoiced.SetVATRateID = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["TAXRateID"], (object) 0, false) ? (object) App.DB.VATRatesSQL.VATRates_Get_ByDate(DateAndTime.Now) : RuntimeHelpers.GetObjectValue(current["TAXRateID"]);
                  oInvoiced.SetPaymentTermID = RuntimeHelpers.GetObjectValue(current["PaymentTermID"]);
                  oInvoiced.SetPaidByID = RuntimeHelpers.GetObjectValue(current["PaidByID"]);
                  oInvoiced.SetAdhocInvoiceType = (object) "DDINVOICE";
                  Invoiced invoiced = App.DB.Invoiced.Insert(oInvoiced);
                  App.DB.InvoicedLines.Insert(new InvoicedLines()
                  {
                    SetAmount = RuntimeHelpers.GetObjectValue(current["Amount"]),
                    SetInvoicedID = (object) invoiced.InvoicedID,
                    SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(current["InvoiceToBeRaisedID"])
                  });
                  this.InvoicesToPrint.Add((object) new ArrayList()
                  {
                    (object) invoiced.InvoicedID,
                    RuntimeHelpers.GetObjectValue(current["RegionID"])
                  });
                }
              }
              else
                flag = true;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (flag)
        {
          int num = (int) App.ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        this.PrintAdhocInvoice("DDINVOICE");
        this.PopulateDatagrid();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }

    private void ts2_Click(object sender, EventArgs e)
    {
      try
      {
        bool flag = false;
        if (this.ValidateInvoiceAddress())
        {
          this.FindPartPayJobs(false);
          FRMPaidBy frmPaidBy = new FRMPaidBy();
          int num1 = (int) frmPaidBy.ShowDialog();
          if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(frmPaidBy.cboDDPaid)) == 0.0)
            return;
          this.DDpaidBy = Combo.get_GetSelectedItemDescription(frmPaidBy.cboDDPaid);
          IEnumerator enumerator;
          try
          {
            enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject((object) Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["tick"])), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectNotEqual(current["PAYMENTTERMID"], (object) 69817, false))))
              {
                if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Amount"])) > 0.0)
                {
                  if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(Conversions.ToInteger(current["InvoiceToBeRaisedID"])).Count == 0)
                  {
                    Invoiced oInvoiced = new Invoiced();
                    JobNumber jobNumber = new JobNumber();
                    JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Quoted | Enums.JobDefinition.Misc);
                    oInvoiced.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
                    oInvoiced.SetRaisedByUserID = (object) App.loggedInUser.UserID;
                    oInvoiced.RaisedDate = Conversions.ToDate(current["RaiseDate"]);
                    oInvoiced.SetVATRateID = !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current["TAXRateID"], (object) 0, false) ? (object) App.DB.VATRatesSQL.VATRates_Get_ByDate(DateAndTime.Now) : RuntimeHelpers.GetObjectValue(current["TAXRateID"]);
                    oInvoiced.SetPaymentTermID = RuntimeHelpers.GetObjectValue(current["PaymentTermID"]);
                    oInvoiced.SetPaidByID = (object) Combo.get_GetSelectedItemValue(frmPaidBy.cboDDPaid);
                    oInvoiced.SetAdhocInvoiceType = (object) "DDRECEIPT";
                    Invoiced invoiced = App.DB.Invoiced.Insert(oInvoiced);
                    App.DB.InvoicedLines.Insert(new InvoicedLines()
                    {
                      SetAmount = RuntimeHelpers.GetObjectValue(current["Amount"]),
                      SetInvoicedID = (object) invoiced.InvoicedID,
                      SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(current["InvoiceToBeRaisedID"])
                    });
                    this.InvoicesToPrint.Add((object) new ArrayList()
                    {
                      (object) invoiced.InvoicedID,
                      RuntimeHelpers.GetObjectValue(current["RegionID"])
                    });
                  }
                }
                else
                  flag = true;
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          if (flag)
          {
            int num2 = (int) App.ShowMessage("1 or more invoice could not be generated because they have a zero amount.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          }
          this.PrintAdhocInvoice("DDRECEIPT");
          this.PopulateDatagrid();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }

    public void PrintAdhocInvoice(string type)
    {
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) this.InvoicesToPrint,
        (object) type,
        (object) this.DDpaidBy
      }, "Invoice", Enums.SystemDocumentType.Invoice, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      this.InvoicesToPrint.Clear();
    }

    private void RaiseProFormaToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ArrayList arrayList = new ArrayList();
      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.InvoicesDataview.Table.Select("TICK = 1")[0]["InvoiceTypeID"], (object) 327, false))
      {
        arrayList.Add((object) "CONTRACT");
        arrayList.Add((object) App.DB.ContractOriginalSite.Get(Conversions.ToInteger(this.InvoicesDataview.Table.Select("TICK = 1")[0]["cos"])));
      }
      else
      {
        arrayList.Add((object) "JOB");
        arrayList.Add((object) App.DB.Job.Job_Get(Conversions.ToInteger(this.InvoicesDataview.Table.Select("TICK = 1")[0]["JobID"])));
      }
      FRMInvoiceExtraDetail invoiceExtraDetail = new FRMInvoiceExtraDetail();
      int num = (int) invoiceExtraDetail.ShowDialog();
      arrayList.Add((object) invoiceExtraDetail.txtNotes.Text);
      arrayList.Add((object) Conversions.ToDouble(invoiceExtraDetail.txtCharge.Text));
      arrayList.Add((object) App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(invoiceExtraDetail.cbo))).VATRate);
      arrayList.Add(RuntimeHelpers.GetObjectValue(this.InvoicesDataview.Table.Select("TICK = 1")[0]["InvoiceToBeRaisedID"]));
      Printing printing = new Printing((object) arrayList, "ProForma", Enums.SystemDocumentType.ProForma, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }

    private void btnChangeLine_Click(object sender, EventArgs e)
    {
      if (this.InvoicesDataview == null || !App.EnterOverridePasswordINV())
        return;
      EnumerableRowCollection<DataRow> source1 = this.InvoicesDataview.Table.AsEnumerable();
      Func<DataRow, bool> predicate;
      // ISSUE: reference to a compiler-generated field
      if (FRMInvoiceManager._Closure\u0024__.\u0024I231\u002D0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        predicate = FRMInvoiceManager._Closure\u0024__.\u0024I231\u002D0;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMInvoiceManager._Closure\u0024__.\u0024I231\u002D0 = predicate = (Func<DataRow, bool>) (sf => sf.Field<bool>("Tick"));
      }
      EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
      Func<DataRow, DataRow> selector;
      // ISSUE: reference to a compiler-generated field
      if (FRMInvoiceManager._Closure\u0024__.\u0024I231\u002D1 != null)
      {
        // ISSUE: reference to a compiler-generated field
        selector = FRMInvoiceManager._Closure\u0024__.\u0024I231\u002D1;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        FRMInvoiceManager._Closure\u0024__.\u0024I231\u002D1 = selector = (Func<DataRow, DataRow>) (sf => sf);
      }
      DataRow[] array = source2.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
      int index = 0;
      while (index < array.Length)
      {
        DataRow dataRow = array[index];
        FRMChangeInvoiceLine changeInvoiceLine = (FRMChangeInvoiceLine) App.ShowForm(typeof (FRMChangeInvoiceLine), true, new object[2]
        {
          dataRow["Amount"],
          dataRow["TAXRateID"]
        }, false);
        if (changeInvoiceLine.DialogResult == DialogResult.OK)
        {
          dataRow["Amount"] = (object) Conversions.ToDouble(changeInvoiceLine.txtAmount.Text);
          dataRow["TAXRateID"] = (object) Combo.get_GetSelectedItemValue(changeInvoiceLine.cboInvoiceTaxCodeNew);
          dataRow["VAT"] = (object) App.DB.VATRatesSQL.VATRates_Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(changeInvoiceLine.cboInvoiceTaxCodeNew))).VATRate;
        }
        checked { ++index; }
      }
    }
  }
}
