// Decompiled with JetBrains decompiler
// Type: FSM.FRMInvoicedManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Accounts;
using FSM.Entity.EngineerVisitCharges;
using FSM.Entity.InvoicedLiness;
using FSM.Entity.Invoiceds;
using FSM.Entity.Jobs;
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
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class FRMInvoicedManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvInvoices;
    private FSM.Entity.Customers.Customer _theCustomer;
    private FSM.Entity.Sites.Site _oSite;
    private ArrayList _invoicesToPrint;
    private bool _IsLoading;

    public FRMInvoicedManager()
    {
      this.Load += new EventHandler(this.FRMInvoicedManager_Load);
      this._invoicesToPrint = new ArrayList();
      this._IsLoading = true;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
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

    internal virtual Label lblCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label lblRefNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblProperty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpRaisedTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpRaisedFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDateBetween { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoiceNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpInvoices { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoicePartPayed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoicePayed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblGreenColour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblGoldColour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblInvoicedNotPayed { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRedColour { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgInvoices
    {
      get
      {
        return this._dgInvoices;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgInvoices_MouseUp);
        EventHandler eventHandler = new EventHandler(this.dgInvoices_DoubleClick);
        DataGrid dgInvoices1 = this._dgInvoices;
        if (dgInvoices1 != null)
        {
          dgInvoices1.MouseUp -= mouseEventHandler;
          dgInvoices1.DoubleClick -= eventHandler;
        }
        this._dgInvoices = value;
        DataGrid dgInvoices2 = this._dgInvoices;
        if (dgInvoices2 == null)
          return;
        dgInvoices2.MouseUp += mouseEventHandler;
        dgInvoices2.DoubleClick += eventHandler;
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

    internal virtual Label lblUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUser { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInvoiceNumber
    {
      get
      {
        return this._txtInvoiceNumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtJobNumber_TextChanged);
        TextBox txtInvoiceNumber1 = this._txtInvoiceNumber;
        if (txtInvoiceNumber1 != null)
          txtInvoiceNumber1.KeyDown -= keyEventHandler;
        this._txtInvoiceNumber = value;
        TextBox txtInvoiceNumber2 = this._txtInvoiceNumber;
        if (txtInvoiceNumber2 == null)
          return;
        txtInvoiceNumber2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Button btnChange
    {
      get
      {
        return this._btnChange;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnChange_Click);
        Button btnChange1 = this._btnChange;
        if (btnChange1 != null)
          btnChange1.Click -= eventHandler;
        this._btnChange = value;
        Button btnChange2 = this._btnChange;
        if (btnChange2 == null)
          return;
        btnChange2.Click += eventHandler;
      }
    }

    internal virtual Button btnMarkAsNotExported
    {
      get
      {
        return this._btnMarkAsNotExported;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnMarkAsNotExported_Click);
        Button markAsNotExported1 = this._btnMarkAsNotExported;
        if (markAsNotExported1 != null)
          markAsNotExported1.Click -= eventHandler;
        this._btnMarkAsNotExported = value;
        Button markAsNotExported2 = this._btnMarkAsNotExported;
        if (markAsNotExported2 == null)
          return;
        markAsNotExported2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboExported
    {
      get
      {
        return this._cboExported;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboExportedToSage_SelectedIndexChanged);
        ComboBox cboExported1 = this._cboExported;
        if (cboExported1 != null)
          cboExported1.SelectedIndexChanged -= eventHandler;
        this._cboExported = value;
        ComboBox cboExported2 = this._cboExported;
        if (cboExported2 == null)
          return;
        cboExported2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblExported { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label lblRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnGenVal
    {
      get
      {
        return this._btnGenVal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGenNCCVal_Click);
        Button btnGenVal1 = this._btnGenVal;
        if (btnGenVal1 != null)
          btnGenVal1.Click -= eventHandler;
        this._btnGenVal = value;
        Button btnGenVal2 = this._btnGenVal;
        if (btnGenVal2 == null)
          return;
        btnGenVal2.Click += eventHandler;
      }
    }

    internal virtual Label lblSageMonth { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSageMonth
    {
      get
      {
        return this._txtSageMonth;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtSageMonth_TextChanged);
        TextBox txtSageMonth1 = this._txtSageMonth;
        if (txtSageMonth1 != null)
          txtSageMonth1.DoubleClick -= eventHandler;
        this._txtSageMonth = value;
        TextBox txtSageMonth2 = this._txtSageMonth;
        if (txtSageMonth2 == null)
          return;
        txtSageMonth2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnSalesCredit
    {
      get
      {
        return this._btnSalesCredit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSalesCredit_Click);
        Button btnSalesCredit1 = this._btnSalesCredit;
        if (btnSalesCredit1 != null)
          btnSalesCredit1.Click -= eventHandler;
        this._btnSalesCredit = value;
        Button btnSalesCredit2 = this._btnSalesCredit;
        if (btnSalesCredit2 == null)
          return;
        btnSalesCredit2.Click += eventHandler;
      }
    }

    internal virtual ContextMenuStrip cmsValType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem tsmiNCCVal
    {
      get
      {
        return this._tsmiNCCVal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiNCCVal_Click);
        ToolStripMenuItem tsmiNccVal1 = this._tsmiNCCVal;
        if (tsmiNccVal1 != null)
          tsmiNccVal1.Click -= eventHandler;
        this._tsmiNCCVal = value;
        ToolStripMenuItem tsmiNccVal2 = this._tsmiNCCVal;
        if (tsmiNccVal2 == null)
          return;
        tsmiNccVal2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiGenericVal
    {
      get
      {
        return this._tsmiGenericVal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiGenericVal_Click);
        ToolStripMenuItem tsmiGenericVal1 = this._tsmiGenericVal;
        if (tsmiGenericVal1 != null)
          tsmiGenericVal1.Click -= eventHandler;
        this._tsmiGenericVal = value;
        ToolStripMenuItem tsmiGenericVal2 = this._tsmiGenericVal;
        if (tsmiGenericVal2 == null)
          return;
        tsmiGenericVal2.Click += eventHandler;
      }
    }

    internal virtual ContextMenuStrip cmsChange { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem tsmiPaymentTerms
    {
      get
      {
        return this._tsmiPaymentTerms;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiPaymentTerms_Click);
        ToolStripMenuItem tsmiPaymentTerms1 = this._tsmiPaymentTerms;
        if (tsmiPaymentTerms1 != null)
          tsmiPaymentTerms1.Click -= eventHandler;
        this._tsmiPaymentTerms = value;
        ToolStripMenuItem tsmiPaymentTerms2 = this._tsmiPaymentTerms;
        if (tsmiPaymentTerms2 == null)
          return;
        tsmiPaymentTerms2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiInvoicedTotal
    {
      get
      {
        return this._tsmiInvoicedTotal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiInvoicedTotal_Click);
        ToolStripMenuItem tsmiInvoicedTotal1 = this._tsmiInvoicedTotal;
        if (tsmiInvoicedTotal1 != null)
          tsmiInvoicedTotal1.Click -= eventHandler;
        this._tsmiInvoicedTotal = value;
        ToolStripMenuItem tsmiInvoicedTotal2 = this._tsmiInvoicedTotal;
        if (tsmiInvoicedTotal2 == null)
          return;
        tsmiInvoicedTotal2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiVatRate
    {
      get
      {
        return this._tsmiVatRate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiVatRate_Click);
        ToolStripMenuItem tsmiVatRate1 = this._tsmiVatRate;
        if (tsmiVatRate1 != null)
          tsmiVatRate1.Click -= eventHandler;
        this._tsmiVatRate = value;
        ToolStripMenuItem tsmiVatRate2 = this._tsmiVatRate;
        if (tsmiVatRate2 == null)
          return;
        tsmiVatRate2.Click += eventHandler;
      }
    }

    internal virtual ContextMenuStrip cmsSalesCredit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem tsmiIssue
    {
      get
      {
        return this._tsmiIssue;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiIssue_Click);
        ToolStripMenuItem tsmiIssue1 = this._tsmiIssue;
        if (tsmiIssue1 != null)
          tsmiIssue1.Click -= eventHandler;
        this._tsmiIssue = value;
        ToolStripMenuItem tsmiIssue2 = this._tsmiIssue;
        if (tsmiIssue2 == null)
          return;
        tsmiIssue2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiRemove
    {
      get
      {
        return this._tsmiRemove;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiRemove_Click);
        ToolStripMenuItem tsmiRemove1 = this._tsmiRemove;
        if (tsmiRemove1 != null)
          tsmiRemove1.Click -= eventHandler;
        this._tsmiRemove = value;
        ToolStripMenuItem tsmiRemove2 = this._tsmiRemove;
        if (tsmiRemove2 == null)
          return;
        tsmiRemove2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiBatchPrint
    {
      get
      {
        return this._tsmiBatchPrint;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiBatchPrint_Click);
        ToolStripMenuItem tsmiBatchPrint1 = this._tsmiBatchPrint;
        if (tsmiBatchPrint1 != null)
          tsmiBatchPrint1.Click -= eventHandler;
        this._tsmiBatchPrint = value;
        ToolStripMenuItem tsmiBatchPrint2 = this._tsmiBatchPrint;
        if (tsmiBatchPrint2 == null)
          return;
        tsmiBatchPrint2.Click += eventHandler;
      }
    }

    internal virtual ContextMenuStrip cmsExportForAccounts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem tsmiSunExport
    {
      get
      {
        return this._tsmiSunExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiSunExport_Click);
        ToolStripMenuItem tsmiSunExport1 = this._tsmiSunExport;
        if (tsmiSunExport1 != null)
          tsmiSunExport1.Click -= eventHandler;
        this._tsmiSunExport = value;
        ToolStripMenuItem tsmiSunExport2 = this._tsmiSunExport;
        if (tsmiSunExport2 == null)
          return;
        tsmiSunExport2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiSageExport
    {
      get
      {
        return this._tsmiSageExport;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiSageExport_Click);
        ToolStripMenuItem tsmiSageExport1 = this._tsmiSageExport;
        if (tsmiSageExport1 != null)
          tsmiSageExport1.Click -= eventHandler;
        this._tsmiSageExport = value;
        ToolStripMenuItem tsmiSageExport2 = this._tsmiSageExport;
        if (tsmiSageExport2 == null)
          return;
        tsmiSageExport2.Click += eventHandler;
      }
    }

    internal virtual Button btnExportToAccounts
    {
      get
      {
        return this._btnExportToAccounts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnExportToAccounts_Click);
        Button exportToAccounts1 = this._btnExportToAccounts;
        if (exportToAccounts1 != null)
          exportToAccounts1.Click -= eventHandler;
        this._btnExportToAccounts = value;
        Button exportToAccounts2 = this._btnExportToAccounts;
        if (exportToAccounts2 == null)
          return;
        exportToAccounts2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiAccountNumber
    {
      get
      {
        return this._tsmiAccountNumber;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiAccountNumber_Click);
        ToolStripMenuItem tsmiAccountNumber1 = this._tsmiAccountNumber;
        if (tsmiAccountNumber1 != null)
          tsmiAccountNumber1.Click -= eventHandler;
        this._tsmiAccountNumber = value;
        ToolStripMenuItem tsmiAccountNumber2 = this._tsmiAccountNumber;
        if (tsmiAccountNumber2 == null)
          return;
        tsmiAccountNumber2.Click += eventHandler;
      }
    }

    internal virtual Label lblDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem tsmiOrderNo
    {
      get
      {
        return this._tsmiOrderNo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiOrderNo_Click);
        ToolStripMenuItem tsmiOrderNo1 = this._tsmiOrderNo;
        if (tsmiOrderNo1 != null)
          tsmiOrderNo1.Click -= eventHandler;
        this._tsmiOrderNo = value;
        ToolStripMenuItem tsmiOrderNo2 = this._tsmiOrderNo;
        if (tsmiOrderNo2 == null)
          return;
        tsmiOrderNo2.Click += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpExportedOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblExportedOn { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkExportedOn
    {
      get
      {
        return this._chkExportedOn;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkExportedOn_Click);
        CheckBox chkExportedOn1 = this._chkExportedOn;
        if (chkExportedOn1 != null)
          chkExportedOn1.Click -= eventHandler;
        this._chkExportedOn = value;
        CheckBox chkExportedOn2 = this._chkExportedOn;
        if (chkExportedOn2 == null)
          return;
        chkExportedOn2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiSorVal
    {
      get
      {
        return this._tsmiSorVal;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiSorVal_Click);
        ToolStripMenuItem tsmiSorVal1 = this._tsmiSorVal;
        if (tsmiSorVal1 != null)
          tsmiSorVal1.Click -= eventHandler;
        this._tsmiSorVal = value;
        ToolStripMenuItem tsmiSorVal2 = this._tsmiSorVal;
        if (tsmiSorVal2 == null)
          return;
        tsmiSorVal2.Click += eventHandler;
      }
    }

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
      this.btnPrintOneItemOneInvoice = new Button();
      this.btnExport = new Button();
      this.btnReset = new Button();
      this.grpFilter = new GroupBox();
      this.dtpExportedOn = new DateTimePicker();
      this.lblExportedOn = new Label();
      this.lblDept = new Label();
      this.cboDept = new ComboBox();
      this.lblSageMonth = new Label();
      this.txtSageMonth = new TextBox();
      this.lblRegion = new Label();
      this.cboRegion = new ComboBox();
      this.btnSearch = new Button();
      this.cboExported = new ComboBox();
      this.lblExported = new Label();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.lblCustomer = new Label();
      this.txtPostcode = new TextBox();
      this.lblPostcode = new Label();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.txtJobNumber = new TextBox();
      this.lblRefNo = new Label();
      this.lblProperty = new Label();
      this.lblType = new Label();
      this.cboType = new ComboBox();
      this.lblDateBetween = new Label();
      this.dtpRaisedFrom = new DateTimePicker();
      this.dtpRaisedTo = new DateTimePicker();
      this.lblDate = new Label();
      this.cboStatus = new ComboBox();
      this.lblStatus = new Label();
      this.lblInvoiceNumber = new Label();
      this.lblUser = new Label();
      this.cboUser = new ComboBox();
      this.txtInvoiceNumber = new TextBox();
      this.chkExportedOn = new CheckBox();
      this.grpInvoices = new GroupBox();
      this.btnSalesCredit = new Button();
      this.btnChange = new Button();
      this.dgInvoices = new DataGrid();
      this.btnSelectAll = new Button();
      this.btnDeselectAll = new Button();
      this.lblInvoicePartPayed = new Label();
      this.lblInvoicePayed = new Label();
      this.lblGreenColour = new Label();
      this.lblGoldColour = new Label();
      this.lblInvoicedNotPayed = new Label();
      this.lblRedColour = new Label();
      this.btnView = new Button();
      this.btnMarkAsNotExported = new Button();
      this.btnGenVal = new Button();
      this.cmsValType = new ContextMenuStrip(this.components);
      this.tsmiNCCVal = new ToolStripMenuItem();
      this.tsmiGenericVal = new ToolStripMenuItem();
      this.tsmiSorVal = new ToolStripMenuItem();
      this.cmsChange = new ContextMenuStrip(this.components);
      this.tsmiPaymentTerms = new ToolStripMenuItem();
      this.tsmiInvoicedTotal = new ToolStripMenuItem();
      this.tsmiVatRate = new ToolStripMenuItem();
      this.tsmiAccountNumber = new ToolStripMenuItem();
      this.tsmiOrderNo = new ToolStripMenuItem();
      this.cmsSalesCredit = new ContextMenuStrip(this.components);
      this.tsmiIssue = new ToolStripMenuItem();
      this.tsmiRemove = new ToolStripMenuItem();
      this.tsmiBatchPrint = new ToolStripMenuItem();
      this.cmsExportForAccounts = new ContextMenuStrip(this.components);
      this.tsmiSunExport = new ToolStripMenuItem();
      this.tsmiSageExport = new ToolStripMenuItem();
      this.btnExportToAccounts = new Button();
      this.grpFilter.SuspendLayout();
      this.grpInvoices.SuspendLayout();
      this.dgInvoices.BeginInit();
      this.cmsValType.SuspendLayout();
      this.cmsChange.SuspendLayout();
      this.cmsSalesCredit.SuspendLayout();
      this.cmsExportForAccounts.SuspendLayout();
      this.SuspendLayout();
      this.btnPrintOneItemOneInvoice.AccessibleDescription = "Export Job List To Excel";
      this.btnPrintOneItemOneInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnPrintOneItemOneInvoice.Location = new System.Drawing.Point(125, 594);
      this.btnPrintOneItemOneInvoice.Name = "btnPrintOneItemOneInvoice";
      this.btnPrintOneItemOneInvoice.Size = new Size(141, 23);
      this.btnPrintOneItemOneInvoice.TabIndex = 27;
      this.btnPrintOneItemOneInvoice.Text = "Regenerate Invoice";
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 594);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 25;
      this.btnExport.Text = "Export";
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(67, 594);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(55, 23);
      this.btnReset.TabIndex = 26;
      this.btnReset.Text = "Reset";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.dtpExportedOn);
      this.grpFilter.Controls.Add((Control) this.lblExportedOn);
      this.grpFilter.Controls.Add((Control) this.lblDept);
      this.grpFilter.Controls.Add((Control) this.cboDept);
      this.grpFilter.Controls.Add((Control) this.lblSageMonth);
      this.grpFilter.Controls.Add((Control) this.txtSageMonth);
      this.grpFilter.Controls.Add((Control) this.lblRegion);
      this.grpFilter.Controls.Add((Control) this.cboRegion);
      this.grpFilter.Controls.Add((Control) this.btnSearch);
      this.grpFilter.Controls.Add((Control) this.cboExported);
      this.grpFilter.Controls.Add((Control) this.lblExported);
      this.grpFilter.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilter.Controls.Add((Control) this.txtCustomer);
      this.grpFilter.Controls.Add((Control) this.lblCustomer);
      this.grpFilter.Controls.Add((Control) this.txtPostcode);
      this.grpFilter.Controls.Add((Control) this.lblPostcode);
      this.grpFilter.Controls.Add((Control) this.btnFindSite);
      this.grpFilter.Controls.Add((Control) this.txtSite);
      this.grpFilter.Controls.Add((Control) this.txtJobNumber);
      this.grpFilter.Controls.Add((Control) this.lblRefNo);
      this.grpFilter.Controls.Add((Control) this.lblProperty);
      this.grpFilter.Controls.Add((Control) this.lblType);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Controls.Add((Control) this.lblDateBetween);
      this.grpFilter.Controls.Add((Control) this.dtpRaisedFrom);
      this.grpFilter.Controls.Add((Control) this.dtpRaisedTo);
      this.grpFilter.Controls.Add((Control) this.lblDate);
      this.grpFilter.Controls.Add((Control) this.cboStatus);
      this.grpFilter.Controls.Add((Control) this.lblStatus);
      this.grpFilter.Controls.Add((Control) this.lblInvoiceNumber);
      this.grpFilter.Controls.Add((Control) this.lblUser);
      this.grpFilter.Controls.Add((Control) this.cboUser);
      this.grpFilter.Controls.Add((Control) this.txtInvoiceNumber);
      this.grpFilter.Controls.Add((Control) this.chkExportedOn);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(1123, 236);
      this.grpFilter.TabIndex = 24;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.dtpExportedOn.Location = new System.Drawing.Point(541, 163);
      this.dtpExportedOn.Name = "dtpExportedOn";
      this.dtpExportedOn.Size = new Size(186, 21);
      this.dtpExportedOn.TabIndex = 44;
      this.lblExportedOn.Location = new System.Drawing.Point(416, 164);
      this.lblExportedOn.Name = "lblExportedOn";
      this.lblExportedOn.Size = new Size(85, 16);
      this.lblExportedOn.TabIndex = 45;
      this.lblExportedOn.Text = "Exported On";
      this.lblDept.AutoSize = true;
      this.lblDept.Location = new System.Drawing.Point(747, 166);
      this.lblDept.Name = "lblDept";
      this.lblDept.Size = new Size(76, 13);
      this.lblDept.TabIndex = 42;
      this.lblDept.Text = "Cost Centre";
      this.cboDept.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDept.Location = new System.Drawing.Point(845, 164);
      this.cboDept.Name = "cboDept";
      this.cboDept.Size = new Size(224, 21);
      this.cboDept.TabIndex = 43;
      this.lblSageMonth.Location = new System.Drawing.Point(416, 197);
      this.lblSageMonth.Name = "lblSageMonth";
      this.lblSageMonth.Size = new Size(98, 19);
      this.lblSageMonth.TabIndex = 40;
      this.lblSageMonth.Text = "Account Month";
      this.txtSageMonth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSageMonth.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSageMonth.Location = new System.Drawing.Point(520, 195);
      this.txtSageMonth.Name = "txtSageMonth";
      this.txtSageMonth.ReadOnly = true;
      this.txtSageMonth.Size = new Size(207, 21);
      this.txtSageMonth.TabIndex = 41;
      this.lblRegion.Location = new System.Drawing.Point(8, 198);
      this.lblRegion.Name = "lblRegion";
      this.lblRegion.Size = new Size(72, 16);
      this.lblRegion.TabIndex = 39;
      this.lblRegion.Text = "Region";
      this.cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegion.Location = new System.Drawing.Point(160, 195);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(248, 21);
      this.cboRegion.TabIndex = 38;
      this.btnSearch.AccessibleDescription = "Export Job List To Excel";
      this.btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSearch.Location = new System.Drawing.Point(981, 198);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(88, 23);
      this.btnSearch.TabIndex = 30;
      this.btnSearch.Text = "Run Filter";
      this.cboExported.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboExported.Items.AddRange(new object[3]
      {
        (object) "Show All",
        (object) "Exported",
        (object) "Not Exported"
      });
      this.cboExported.Location = new System.Drawing.Point(160, 161);
      this.cboExported.Name = "cboExported";
      this.cboExported.Size = new Size(248, 21);
      this.cboExported.TabIndex = 29;
      this.lblExported.Location = new System.Drawing.Point(8, 164);
      this.lblExported.Name = "lblExported";
      this.lblExported.Size = new Size(122, 18);
      this.lblExported.TabIndex = 28;
      this.lblExported.Text = "Exported";
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(1077, 40);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 2;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(160, 40);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(909, 21);
      this.txtCustomer.TabIndex = 1;
      this.lblCustomer.Location = new System.Drawing.Point(8, 40);
      this.lblCustomer.Name = "lblCustomer";
      this.lblCustomer.Size = new Size(64, 16);
      this.lblCustomer.TabIndex = 27;
      this.lblCustomer.Text = "Customer";
      this.txtPostcode.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPostcode.Location = new System.Drawing.Point(160, 88);
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(248, 21);
      this.txtPostcode.TabIndex = 5;
      this.lblPostcode.Location = new System.Drawing.Point(8, 88);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(64, 16);
      this.lblPostcode.TabIndex = 20;
      this.lblPostcode.Text = "Postcode";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(1077, 64);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 4;
      this.btnFindSite.Text = "...";
      this.btnFindSite.UseVisualStyleBackColor = false;
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(160, 64);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(909, 21);
      this.txtSite.TabIndex = 3;
      this.txtJobNumber.Location = new System.Drawing.Point(160, 136);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(248, 21);
      this.txtJobNumber.TabIndex = 9;
      this.lblRefNo.Location = new System.Drawing.Point(8, 136);
      this.lblRefNo.Name = "lblRefNo";
      this.lblRefNo.Size = new Size(136, 16);
      this.lblRefNo.TabIndex = 6;
      this.lblRefNo.Text = "Job/Order/Contract No";
      this.lblProperty.Location = new System.Drawing.Point(8, 64);
      this.lblProperty.Name = "lblProperty";
      this.lblProperty.Size = new Size(64, 16);
      this.lblProperty.TabIndex = 2;
      this.lblProperty.Text = "Property";
      this.lblType.Location = new System.Drawing.Point(8, 112);
      this.lblType.Name = "lblType";
      this.lblType.Size = new Size(48, 16);
      this.lblType.TabIndex = 4;
      this.lblType.Text = "Type";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(160, 112);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(248, 21);
      this.cboType.TabIndex = 7;
      this.lblDateBetween.Location = new System.Drawing.Point(416, 16);
      this.lblDateBetween.Name = "lblDateBetween";
      this.lblDateBetween.Size = new Size(48, 16);
      this.lblDateBetween.TabIndex = 14;
      this.lblDateBetween.Text = "and";
      this.dtpRaisedFrom.Location = new System.Drawing.Point(160, 16);
      this.dtpRaisedFrom.Name = "dtpRaisedFrom";
      this.dtpRaisedFrom.Size = new Size(248, 21);
      this.dtpRaisedFrom.TabIndex = 15;
      this.dtpRaisedTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpRaisedTo.Location = new System.Drawing.Point(520, 16);
      this.dtpRaisedTo.Name = "dtpRaisedTo";
      this.dtpRaisedTo.Size = new Size(549, 21);
      this.dtpRaisedTo.TabIndex = 16;
      this.lblDate.Location = new System.Drawing.Point(8, 16);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new Size(136, 16);
      this.lblDate.TabIndex = 17;
      this.lblDate.Text = "Raised Date Between : ";
      this.cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(520, 88);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(549, 21);
      this.cboStatus.TabIndex = 8;
      this.lblStatus.Location = new System.Drawing.Point(416, 90);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new Size(48, 16);
      this.lblStatus.TabIndex = 5;
      this.lblStatus.Text = "Status";
      this.lblInvoiceNumber.Location = new System.Drawing.Point(416, 114);
      this.lblInvoiceNumber.Name = "lblInvoiceNumber";
      this.lblInvoiceNumber.Size = new Size(104, 16);
      this.lblInvoiceNumber.TabIndex = 10;
      this.lblInvoiceNumber.Text = "Invoice Number";
      this.lblUser.BackColor = Color.White;
      this.lblUser.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblUser.Location = new System.Drawing.Point(416, 138);
      this.lblUser.Name = "lblUser";
      this.lblUser.Size = new Size(40, 16);
      this.lblUser.TabIndex = 12;
      this.lblUser.Text = "User";
      this.cboUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboUser.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboUser.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cboUser.ItemHeight = 13;
      this.cboUser.Location = new System.Drawing.Point(520, 136);
      this.cboUser.Name = "cboUser";
      this.cboUser.Size = new Size(549, 21);
      this.cboUser.TabIndex = 13;
      this.txtInvoiceNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtInvoiceNumber.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInvoiceNumber.Location = new System.Drawing.Point(520, 112);
      this.txtInvoiceNumber.Name = "txtInvoiceNumber";
      this.txtInvoiceNumber.Size = new Size(549, 21);
      this.txtInvoiceNumber.TabIndex = 11;
      this.chkExportedOn.AutoCheck = false;
      this.chkExportedOn.AutoSize = true;
      this.chkExportedOn.Location = new System.Drawing.Point(520, 166);
      this.chkExportedOn.Name = "chkExportedOn";
      this.chkExportedOn.Size = new Size(30, 17);
      this.chkExportedOn.TabIndex = 46;
      this.chkExportedOn.Text = " ";
      this.chkExportedOn.UseVisualStyleBackColor = true;
      this.grpInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpInvoices.Controls.Add((Control) this.btnSalesCredit);
      this.grpInvoices.Controls.Add((Control) this.btnChange);
      this.grpInvoices.Controls.Add((Control) this.dgInvoices);
      this.grpInvoices.Controls.Add((Control) this.btnSelectAll);
      this.grpInvoices.Controls.Add((Control) this.btnDeselectAll);
      this.grpInvoices.Controls.Add((Control) this.lblInvoicePartPayed);
      this.grpInvoices.Controls.Add((Control) this.lblInvoicePayed);
      this.grpInvoices.Controls.Add((Control) this.lblGreenColour);
      this.grpInvoices.Controls.Add((Control) this.lblGoldColour);
      this.grpInvoices.Controls.Add((Control) this.lblInvoicedNotPayed);
      this.grpInvoices.Controls.Add((Control) this.lblRedColour);
      this.grpInvoices.Location = new System.Drawing.Point(8, 274);
      this.grpInvoices.Name = "grpInvoices";
      this.grpInvoices.Size = new Size(1123, 314);
      this.grpInvoices.TabIndex = 23;
      this.grpInvoices.TabStop = false;
      this.grpInvoices.Text = "Double Click To View / Add Payment Information";
      this.btnSalesCredit.AccessibleDescription = "";
      this.btnSalesCredit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSalesCredit.Location = new System.Drawing.Point(827, 24);
      this.btnSalesCredit.Name = "btnSalesCredit";
      this.btnSalesCredit.Size = new Size(148, 23);
      this.btnSalesCredit.TabIndex = 35;
      this.btnSalesCredit.Text = "Sales Credit";
      this.btnChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnChange.Location = new System.Drawing.Point(981, 24);
      this.btnChange.Name = "btnChange";
      this.btnChange.Size = new Size(136, 23);
      this.btnChange.TabIndex = 27;
      this.btnChange.Text = "Change";
      this.dgInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgInvoices.DataMember = "";
      this.dgInvoices.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoices.Location = new System.Drawing.Point(8, 72);
      this.dgInvoices.Name = "dgInvoices";
      this.dgInvoices.Size = new Size(1109, 232);
      this.dgInvoices.TabIndex = 14;
      this.btnSelectAll.AccessibleDescription = "Export Job List To Excel";
      this.btnSelectAll.Location = new System.Drawing.Point(8, 24);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(88, 23);
      this.btnSelectAll.TabIndex = 19;
      this.btnSelectAll.Text = "Select All";
      this.btnDeselectAll.Location = new System.Drawing.Point(104, 24);
      this.btnDeselectAll.Name = "btnDeselectAll";
      this.btnDeselectAll.Size = new Size(88, 23);
      this.btnDeselectAll.TabIndex = 20;
      this.btnDeselectAll.Text = "Deselect All";
      this.lblInvoicePartPayed.Location = new System.Drawing.Point(259, 52);
      this.lblInvoicePartPayed.Name = "lblInvoicePartPayed";
      this.lblInvoicePartPayed.Size = new Size(224, 23);
      this.lblInvoicePartPayed.TabIndex = 26;
      this.lblInvoicePartPayed.Text = "Invoiced - Some Payments Received";
      this.lblInvoicePayed.Location = new System.Drawing.Point(515, 52);
      this.lblInvoicePayed.Name = "lblInvoicePayed";
      this.lblInvoicePayed.Size = new Size(120, 23);
      this.lblInvoicePayed.TabIndex = 25;
      this.lblInvoicePayed.Text = "Invoiced and Paid";
      this.lblGreenColour.BackColor = Color.LightGreen;
      this.lblGreenColour.Location = new System.Drawing.Point(491, 52);
      this.lblGreenColour.Name = "lblGreenColour";
      this.lblGreenColour.Size = new Size(23, 23);
      this.lblGreenColour.TabIndex = 24;
      this.lblGoldColour.BackColor = Color.Gold;
      this.lblGoldColour.Location = new System.Drawing.Point(235, 51);
      this.lblGoldColour.Name = "lblGoldColour";
      this.lblGoldColour.Size = new Size(23, 23);
      this.lblGoldColour.TabIndex = 23;
      this.lblInvoicedNotPayed.Location = new System.Drawing.Point(35, 52);
      this.lblInvoicedNotPayed.Name = "lblInvoicedNotPayed";
      this.lblInvoicedNotPayed.Size = new Size(200, 23);
      this.lblInvoicedNotPayed.TabIndex = 22;
      this.lblInvoicedNotPayed.Text = "Invoiced - No Payments Received";
      this.lblRedColour.BackColor = Color.Red;
      this.lblRedColour.Location = new System.Drawing.Point(11, 51);
      this.lblRedColour.Name = "lblRedColour";
      this.lblRedColour.Size = new Size(23, 23);
      this.lblRedColour.TabIndex = 21;
      this.btnView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnView.Location = new System.Drawing.Point(561, 594);
      this.btnView.Name = "btnView";
      this.btnView.Size = new Size(59, 23);
      this.btnView.TabIndex = 29;
      this.btnView.Text = "View";
      this.btnMarkAsNotExported.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnMarkAsNotExported.CausesValidation = false;
      this.btnMarkAsNotExported.Location = new System.Drawing.Point(813, 594);
      this.btnMarkAsNotExported.Name = "btnMarkAsNotExported";
      this.btnMarkAsNotExported.Size = new Size(146, 23);
      this.btnMarkAsNotExported.TabIndex = 31;
      this.btnMarkAsNotExported.Text = "Unmark Exports";
      this.btnMarkAsNotExported.UseVisualStyleBackColor = true;
      this.btnGenVal.AccessibleDescription = "";
      this.btnGenVal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnGenVal.Location = new System.Drawing.Point(270, 594);
      this.btnGenVal.Name = "btnGenVal";
      this.btnGenVal.Size = new Size(125, 23);
      this.btnGenVal.TabIndex = 32;
      this.btnGenVal.Text = "Generate Val";
      this.cmsValType.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.tsmiNCCVal,
        (ToolStripItem) this.tsmiGenericVal,
        (ToolStripItem) this.tsmiSorVal
      });
      this.cmsValType.Name = "cmsValType";
      this.cmsValType.Size = new Size(115, 70);
      this.tsmiNCCVal.Name = "tsmiNCCVal";
      this.tsmiNCCVal.Size = new Size(114, 22);
      this.tsmiNCCVal.Text = "NCC";
      this.tsmiGenericVal.Name = "tsmiGenericVal";
      this.tsmiGenericVal.Size = new Size(114, 22);
      this.tsmiGenericVal.Text = "Generic";
      this.tsmiSorVal.Name = "tsmiSorVal";
      this.tsmiSorVal.Size = new Size(114, 22);
      this.tsmiSorVal.Text = "SOR";
      this.cmsChange.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.tsmiPaymentTerms,
        (ToolStripItem) this.tsmiInvoicedTotal,
        (ToolStripItem) this.tsmiVatRate,
        (ToolStripItem) this.tsmiAccountNumber,
        (ToolStripItem) this.tsmiOrderNo
      });
      this.cmsChange.Name = "cmsChange";
      this.cmsChange.Size = new Size(167, 114);
      this.tsmiPaymentTerms.Name = "tsmiPaymentTerms";
      this.tsmiPaymentTerms.Size = new Size(166, 22);
      this.tsmiPaymentTerms.Text = "Payment Terms";
      this.tsmiInvoicedTotal.Name = "tsmiInvoicedTotal";
      this.tsmiInvoicedTotal.Size = new Size(166, 22);
      this.tsmiInvoicedTotal.Text = "Invoiced Total";
      this.tsmiVatRate.Name = "tsmiVatRate";
      this.tsmiVatRate.Size = new Size(166, 22);
      this.tsmiVatRate.Text = "Vat Rate";
      this.tsmiAccountNumber.Name = "tsmiAccountNumber";
      this.tsmiAccountNumber.Size = new Size(166, 22);
      this.tsmiAccountNumber.Text = "Account Number";
      this.tsmiOrderNo.Name = "tsmiOrderNo";
      this.tsmiOrderNo.Size = new Size(166, 22);
      this.tsmiOrderNo.Text = "Order No";
      this.cmsSalesCredit.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.tsmiIssue,
        (ToolStripItem) this.tsmiRemove,
        (ToolStripItem) this.tsmiBatchPrint
      });
      this.cmsSalesCredit.Name = "ContextMenuStrip2";
      this.cmsSalesCredit.Size = new Size(197, 70);
      this.tsmiIssue.Name = "tsmiIssue";
      this.tsmiIssue.Size = new Size(196, 22);
      this.tsmiIssue.Text = "Issue Sales Credit";
      this.tsmiRemove.Name = "tsmiRemove";
      this.tsmiRemove.Size = new Size(196, 22);
      this.tsmiRemove.Text = "Remove Sales Credit";
      this.tsmiBatchPrint.Name = "tsmiBatchPrint";
      this.tsmiBatchPrint.Size = new Size(196, 22);
      this.tsmiBatchPrint.Text = "Batch Print Sales Credit";
      this.cmsExportForAccounts.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.tsmiSunExport,
        (ToolStripItem) this.tsmiSageExport
      });
      this.cmsExportForAccounts.Name = "cmsExportForAccounts";
      this.cmsExportForAccounts.Size = new Size(152, 48);
      this.tsmiSunExport.Name = "tsmiSunExport";
      this.tsmiSunExport.Size = new Size(151, 22);
      this.tsmiSunExport.Text = "Export To Sun";
      this.tsmiSageExport.Name = "tsmiSageExport";
      this.tsmiSageExport.Size = new Size(151, 22);
      this.tsmiSageExport.Text = "Export To Sage";
      this.btnExportToAccounts.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnExportToAccounts.Location = new System.Drawing.Point(965, 594);
      this.btnExportToAccounts.Name = "btnExportToAccounts";
      this.btnExportToAccounts.Size = new Size(166, 23);
      this.btnExportToAccounts.TabIndex = 35;
      this.btnExportToAccounts.Text = "Export To Accounts";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1137, 626);
      this.Controls.Add((Control) this.btnExportToAccounts);
      this.Controls.Add((Control) this.btnGenVal);
      this.Controls.Add((Control) this.btnMarkAsNotExported);
      this.Controls.Add((Control) this.btnView);
      this.Controls.Add((Control) this.btnPrintOneItemOneInvoice);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnReset);
      this.Controls.Add((Control) this.grpInvoices);
      this.Name = nameof (FRMInvoicedManager);
      this.Text = "Invoiced Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpInvoices, 0);
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintOneItemOneInvoice, 0);
      this.Controls.SetChildIndex((Control) this.btnView, 0);
      this.Controls.SetChildIndex((Control) this.btnMarkAsNotExported, 0);
      this.Controls.SetChildIndex((Control) this.btnGenVal, 0);
      this.Controls.SetChildIndex((Control) this.btnExportToAccounts, 0);
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.grpInvoices.ResumeLayout(false);
      this.dgInvoices.EndInit();
      this.cmsValType.ResumeLayout(false);
      this.cmsChange.ResumeLayout(false);
      this.cmsSalesCredit.ResumeLayout(false);
      this.cmsExportForAccounts.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupInvoiceDataGrid();
      this.ResetFilters();
      try
      {
        if (this.get_GetParameter(0) == null)
          return;
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
        this._dvInvoices.AllowEdit = true;
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

    public FSM.Entity.Customers.Customer theCustomer
    {
      get
      {
        return this._theCustomer;
      }
      set
      {
        this._theCustomer = value;
        this.theSite = (FSM.Entity.Sites.Site) null;
        if (this._theCustomer != null)
          this.txtCustomer.Text = this.theCustomer.Name + " (A/C No : " + this.theCustomer.AccountNumber + ")";
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
      PaidStatusColourColumn statusColourColumn = new PaidStatusColourColumn();
      statusColourColumn.Format = "";
      statusColourColumn.FormatInfo = (IFormatProvider) null;
      statusColourColumn.HeaderText = "Paid";
      statusColourColumn.MappingName = "PaidStatus";
      statusColourColumn.ReadOnly = true;
      statusColourColumn.Width = 30;
      statusColourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) statusColourColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Customer";
      dataGridLabelColumn1.MappingName = "Customer";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 75;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Property";
      dataGridLabelColumn2.MappingName = "Site";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Inv. Type";
      dataGridLabelColumn3.MappingName = "InvoiceType";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 75;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Job/Ord/Con No.";
      dataGridLabelColumn4.MappingName = "JobNumber";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 85;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Inv. Addr. Type";
      dataGridLabelColumn5.MappingName = "InvoiceAddressType";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Invoice Add.";
      dataGridLabelColumn6.MappingName = "InvoiceAddress";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Amount";
      dataGridLabelColumn7.MappingName = "Amount";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 75;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "VAT Rate";
      dataGridLabelColumn8.MappingName = "VATRate";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 75;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "C";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Invoice No";
      dataGridLabelColumn9.MappingName = "InvoiceNumber";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 75;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "dd/MM/yyyy";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Raised On";
      dataGridLabelColumn10.MappingName = "RaisedDate";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 75;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Raised By";
      dataGridLabelColumn11.MappingName = "Fullname";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 75;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "dd/MM/yyyy";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Exported";
      dataGridLabelColumn12.MappingName = "DateExportedToSage";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 105;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Supplier Invoice ID";
      dataGridLabelColumn13.MappingName = "SupplierInvoiceID";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 105;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
      dataGridLabelColumn14.Format = "C";
      dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn14.HeaderText = "Credited Amount";
      dataGridLabelColumn14.MappingName = "CreditAmount";
      dataGridLabelColumn14.ReadOnly = true;
      dataGridLabelColumn14.Width = 80;
      dataGridLabelColumn14.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
      DataGridLabelColumn dataGridLabelColumn15 = new DataGridLabelColumn();
      dataGridLabelColumn15.Format = "";
      dataGridLabelColumn15.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn15.HeaderText = "Payment Term";
      dataGridLabelColumn15.MappingName = "PaymentTerm";
      dataGridLabelColumn15.ReadOnly = true;
      dataGridLabelColumn15.Width = 120;
      dataGridLabelColumn15.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn15);
      DataGridLabelColumn dataGridLabelColumn16 = new DataGridLabelColumn();
      dataGridLabelColumn16.Format = "";
      dataGridLabelColumn16.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn16.HeaderText = "Payment by";
      dataGridLabelColumn16.MappingName = "PaymentBy";
      dataGridLabelColumn16.ReadOnly = true;
      dataGridLabelColumn16.Width = 100;
      dataGridLabelColumn16.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn16);
      DataGridLabelColumn dataGridLabelColumn17 = new DataGridLabelColumn();
      dataGridLabelColumn17.Format = "";
      dataGridLabelColumn17.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn17.HeaderText = "Acc Number";
      dataGridLabelColumn17.MappingName = "AccountNumber";
      dataGridLabelColumn17.ReadOnly = true;
      dataGridLabelColumn17.Width = 100;
      dataGridLabelColumn17.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn17);
      DataGridEditableTextBoxColumn editableTextBoxColumn = new DataGridEditableTextBoxColumn();
      editableTextBoxColumn.Format = "";
      editableTextBoxColumn.FormatInfo = (IFormatProvider) null;
      editableTextBoxColumn.HeaderText = "Order No";
      editableTextBoxColumn.MappingName = "OrderNo";
      editableTextBoxColumn.ReadOnly = false;
      editableTextBoxColumn.Width = 100;
      editableTextBoxColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) editableTextBoxColumn);
      tableStyle.ReadOnly = false;
      this.dgInvoices.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_tblInvoices.ToString();
      this.dgInvoices.TableStyles.Add(tableStyle);
    }

    private void FRMInvoicedManager_Load(object sender, EventArgs e)
    {
      this.IsLoading = true;
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.IsLoading = false;
    }

    private void btnView_Click(object sender, EventArgs e)
    {
      this.view();
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
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theCustomer = App.DB.Customer.Customer_Get(integer);
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      int num = this.theCustomer != null ? Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, this.theCustomer.CustomerID, "", false)) : Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
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
      int num1 = checked (((DataView) this.dgInvoices.DataSource).Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        this.dgInvoices.CurrentRowIndex = num2;
        this.SelectedInvoiceDataRow["tick"] = (object) 1;
        checked { ++num2; }
      }
    }

    private void btnDeselectAll_Click(object sender, EventArgs e)
    {
      int num1 = checked (((DataView) this.dgInvoices.DataSource).Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        this.dgInvoices.CurrentRowIndex = num2;
        this.SelectedInvoiceDataRow["tick"] = (object) 0;
        checked { ++num2; }
      }
    }

    private void btnPrintOneItemOneInvoice_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Check_Supplier_Invoices_And_Continue())
          return;
        this.FindPartPayJobs(false);
        EnumerableRowCollection<DataRow> source1 = this.InvoicesDataview.Table.AsEnumerable();
        Func<DataRow, bool> predicate;
        // ISSUE: reference to a compiler-generated field
        if (FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          predicate = FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D0 = predicate = (Func<DataRow, bool>) (sf => sf.Field<bool>("Tick"));
        }
        EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
        Func<DataRow, DataRow> selector1;
        // ISSUE: reference to a compiler-generated field
        if (FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D1 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector1 = FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D1;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D1 = selector1 = (Func<DataRow, DataRow>) (sf => sf);
        }
        DataRow[] array = source2.Select<DataRow, DataRow>(selector1).ToArray<DataRow>();
        int index = 0;
        while (index < array.Length)
        {
          // ISSUE: object of a compiler-generated type is created
          // ISSUE: variable of a compiler-generated type
          FRMInvoicedManager._Closure\u0024__324\u002D0 closure3240 = new FRMInvoicedManager._Closure\u0024__324\u002D0(closure3240);
          // ISSUE: reference to a compiler-generated field
          closure3240.\u0024VB\u0024Local_i = array[index];
          // ISSUE: reference to a compiler-generated field
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(closure3240.\u0024VB\u0024Local_i["InvoiceType"], (object) "Sales Credit", false))
          {
            // ISSUE: reference to a compiler-generated method
            EnumerableRowCollection<DataRow> source3 = this.InvoicesDataview.Table.AsEnumerable().Where<DataRow>(new Func<DataRow, bool>(closure3240._Lambda\u0024__2));
            Func<DataRow, DataRow> selector2;
            // ISSUE: reference to a compiler-generated field
            if (FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D3 != null)
            {
              // ISSUE: reference to a compiler-generated field
              selector2 = FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D3;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              FRMInvoicedManager._Closure\u0024__.\u0024I324\u002D3 = selector2 = (Func<DataRow, DataRow>) (sf => sf);
            }
            int num = source3.Select<DataRow, DataRow>(selector2).Count<DataRow>();
            DialogResult dialogResult = DialogResult.None;
            if (num > 1)
            {
              // ISSUE: reference to a compiler-generated field
              dialogResult = App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Invoice No: ", closure3240.\u0024VB\u0024Local_i["InvoiceNumber"]), (object) " has more than one credit."), (object) "\r\n"), (object) "\r\n"), (object) "Do you want merge them together?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            DataTable dataTable = dialogResult == DialogResult.None || dialogResult != DialogResult.Yes ? App.DB.SalesCredit.InvoicedLines_GetAll_ByCreditReference(Conversions.ToString(closure3240.\u0024VB\u0024Local_i["JobNumber"])).Table : App.DB.SalesCredit.InvoicedLines_GetAll_ByInvoicedNumber(Conversions.ToString(closure3240.\u0024VB\u0024Local_i["InvoiceNumber"])).Table;
            dataTable.Columns.Add("SalesCreditID");
            // ISSUE: reference to a compiler-generated field
            dataTable.Rows[0]["SalesCreditID"] = RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["LinkID"]);
            dataTable.Columns.Add("CreditReference");
            // ISSUE: reference to a compiler-generated field
            dataTable.Rows[0]["CreditReference"] = RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["JobNumber"]);
            Printing printing = new Printing((object) dataTable, "Sales Credit", Enums.SystemDocumentType.SalesCredit, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["invoicedID"])) == 0)
            {
              Invoiced oInvoiced = new Invoiced();
              JobNumber jobNumber = new JobNumber();
              JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Quoted | Enums.JobDefinition.Misc);
              oInvoiced.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
              oInvoiced.SetRaisedByUserID = (object) App.loggedInUser.UserID;
              oInvoiced.RaisedDate = DateAndTime.Now;
              Invoiced invoiced = App.DB.Invoiced.Insert(oInvoiced);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              App.DB.InvoicedLines.Insert(new InvoicedLines()
              {
                SetAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["Amount"])),
                SetInvoicedID = (object) invoiced.InvoicedID,
                SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["InvoiceToBeRaisedID"])
              });
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.InvoicesToPrint.Add((object) new ArrayList()
              {
                RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["InvoicedID"]),
                RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["RegionID"])
              });
            }
            else
            {
              bool flag = false;
              IEnumerator enumerator;
              try
              {
                enumerator = this.InvoicesToPrint.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  // ISSUE: reference to a compiler-generated field
                  if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(((ArrayList) enumerator.Current)[0], closure3240.\u0024VB\u0024Local_i["InvoicedID"], false))
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
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                this.InvoicesToPrint.Add((object) new ArrayList()
                {
                  RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["InvoicedID"]),
                  RuntimeHelpers.GetObjectValue(closure3240.\u0024VB\u0024Local_i["RegionID"])
                });
              }
            }
          }
          checked { ++index; }
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
        if (!this.Check_Supplier_Invoices_And_Continue())
          return;
        this.FindPartPayJobs(true);
        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("AddressTypeID");
        dataTable.Columns.Add("AddressID");
        IEnumerator enumerator;
        try
        {
          enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current["tick"])))
            {
              if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["invoicedID"])) == 0)
              {
                if (dataTable.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AddressTypeID=", current["AddressTypeID"]), (object) " AND AddressID="), current["AddressID"]))).Length == 0)
                {
                  DataRow[] dataRowArray = this.InvoicesDataview.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "AddressTypeID=", current["AddressTypeID"]), (object) " AND AddressID="), current["AddressID"]), (object) " AND Tick = 1")));
                  Invoiced oInvoiced = new Invoiced();
                  JobNumber jobNumber = new JobNumber();
                  JobNumber nextJobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Quoted | Enums.JobDefinition.Misc);
                  oInvoiced.SetInvoiceNumber = (object) (nextJobNumber.Prefix + Conversions.ToString(nextJobNumber.JobNumber));
                  oInvoiced.SetRaisedByUserID = (object) App.loggedInUser.UserID;
                  oInvoiced.RaisedDate = DateAndTime.Now;
                  Invoiced invoiced = App.DB.Invoiced.Insert(oInvoiced);
                  int num = checked (dataRowArray.Length - 1);
                  int index = 0;
                  while (index <= num)
                  {
                    App.DB.InvoicedLines.Insert(new InvoicedLines()
                    {
                      SetAmount = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRowArray[index]["Amount"])),
                      SetInvoicedID = (object) invoiced.InvoicedID,
                      SetInvoiceToBeRaisedID = RuntimeHelpers.GetObjectValue(dataRowArray[index]["InvoiceToBeRaisedID"])
                    });
                    checked { ++index; }
                  }
                  this.InvoicesToPrint.Add((object) invoiced.InvoicedID);
                  DataRow row = dataTable.NewRow();
                  row["AddressTypeID"] = RuntimeHelpers.GetObjectValue(current["AddressTypeID"]);
                  row["AddressID"] = RuntimeHelpers.GetObjectValue(current["AddressID"]);
                  dataTable.Rows.Add(row);
                }
              }
              else if (!this.InvoicesToPrint.Contains(RuntimeHelpers.GetObjectValue(current["invoicedID"])))
                this.InvoicesToPrint.Add((object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["invoicedID"])));
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
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

    private void dgInvoices_DoubleClick(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      if (this.SelectedInvoiceDataRow != null)
      {
        if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedInvoiceDataRow["InvoiceType"], (object) "Supplier", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedInvoiceDataRow["InvoiceType"], (object) "Consolidation", false))))
        {
          int num1 = (int) App.ShowMessage("Payments cannot be managed for a supplier invoice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["InvoicedID"])) > 0U)
        {
          DataRow selectedInvoiceDataRow = this.SelectedInvoiceDataRow;
          App.ShowForm(typeof (FrmInvoicedPayment), true, new object[9]
          {
            selectedInvoiceDataRow["InvoicedID"],
            selectedInvoiceDataRow["Customer"],
            selectedInvoiceDataRow["InvoiceAddress"],
            selectedInvoiceDataRow["InvoiceNumber"],
            selectedInvoiceDataRow["RaisedDate"],
            selectedInvoiceDataRow["Fullname"],
            selectedInvoiceDataRow["EngineerVisitID"],
            selectedInvoiceDataRow["VATRate"],
            (object) this
          }, false);
        }
        else
        {
          int num2 = (int) App.ShowMessage("An Invoice must be generated before payments can be applied for or received", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
    }

    private void btnChange_Click(object sender, EventArgs e)
    {
      IEnumerator enumerator;
      if (this.SelectedInvoiceDataRow != null)
      {
        try
        {
          enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRow current = (DataRow) enumerator.Current;
            if (Conversions.ToBoolean(current["tick"]) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Sales Credit", false))
            {
              int num = (int) App.ShowMessage("You can not change credits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              return;
            }
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      this.cmsChange.Show((Control) this.btnChange, new System.Drawing.Point(0, 0));
    }

    private void tsmiPaymentTerms_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      if (this.SelectedInvoiceDataRow == null)
        return;
      FRMChangePaymentTerms changePaymentTerms = (FRMChangePaymentTerms) App.ShowForm(typeof (FRMChangePaymentTerms), true, new object[2]
      {
        this.SelectedInvoiceDataRow["InvoicedID"],
        this.SelectedInvoiceDataRow["Amount"]
      }, false);
      if (changePaymentTerms.DialogResult == DialogResult.OK)
      {
        this.SelectedInvoiceDataRow["PaymentTerm"] = (object) Combo.get_GetSelectedItemDescription(changePaymentTerms.cboPaymentTerm);
        this.SelectedInvoiceDataRow["PaymentBy"] = Conversions.ToDouble(Combo.get_GetSelectedItemValue(changePaymentTerms.cboPaymentTerm)) != 69491.0 ? (object) "" : (object) Combo.get_GetSelectedItemDescription(changePaymentTerms.cboPaidBy);
      }
    }

    private void tsmiInvoicedTotal_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      if (this.SelectedInvoiceDataRow == null)
        return;
      if (!Conversions.ToBoolean(this.SelectedInvoiceDataRow["ExportedToSage"]))
      {
        FRMChangeInvoicedTotal changeInvoicedTotal = (FRMChangeInvoicedTotal) App.ShowForm(typeof (FRMChangeInvoicedTotal), true, new object[7]
        {
          this.SelectedInvoiceDataRow["InvoicedLineID"],
          this.SelectedInvoiceDataRow["Amount"],
          this.SelectedInvoiceDataRow["AccountNumber"],
          this.SelectedInvoiceDataRow["Department"],
          this.SelectedInvoiceDataRow["NominalCode"],
          this.SelectedInvoiceDataRow["RaisedDate"],
          this.SelectedInvoiceDataRow["InvoiceTypeID"]
        }, false);
        if (changeInvoicedTotal.DialogResult == DialogResult.OK)
        {
          this.SelectedInvoiceDataRow["Amount"] = (object) changeInvoicedTotal.txtInvoicedTotal.Text;
          this.SelectedInvoiceDataRow["AccountNumber"] = (object) changeInvoicedTotal.txtAccount.Text;
          this.SelectedInvoiceDataRow["Department"] = (object) changeInvoicedTotal.txtDept.Text;
          this.SelectedInvoiceDataRow["NominalCode"] = (object) changeInvoicedTotal.txtNominal.Text;
          this.SelectedInvoiceDataRow["RaisedDate"] = (object) changeInvoicedTotal.dtpTaxDate.Value;
        }
      }
      else
      {
        int num = (int) App.ShowMessage("This invoice has already been exported", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void tsmiVatRate_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      if (this.SelectedInvoiceDataRow == null)
        return;
      if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedInvoiceDataRow["InvoiceType"], (object) "Supplier", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.SelectedInvoiceDataRow["InvoiceType"], (object) "Consolidation", false))))
      {
        int num1 = (int) App.ShowMessage("VAT Rate cannot be changed for a supplier invoice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        using (FRMChangeVAT frmChangeVat = new FRMChangeVAT(Conversions.ToInteger(this.SelectedInvoiceDataRow["VATRateID"]), Conversions.ToInteger(this.SelectedInvoiceDataRow["InvoicedID"]), Conversions.ToString(this.SelectedInvoiceDataRow["InvoiceNumber"])))
        {
          int num2 = (int) frmChangeVat.ShowDialog();
        }
        this.PopulateDatagrid();
      }
    }

    private void btnSalesCredit_Click(object sender, EventArgs e)
    {
      this.cmsSalesCredit.Show((Control) this.btnSalesCredit, new System.Drawing.Point(0, 0));
    }

    private void tsmiAccountNumber_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      if (this.SelectedInvoiceDataRow == null)
        return;
      FRMGenDropBox frmGenDropBox = new FRMGenDropBox();
      frmGenDropBox.cbo2.Items.Clear();
      frmGenDropBox.cbo1.Visible = false;
      frmGenDropBox.cbo2.Visible = false;
      frmGenDropBox.lblTop.Visible = false;
      frmGenDropBox.lblMiddle.Visible = false;
      frmGenDropBox.lblref.Text = "Account Number";
      frmGenDropBox.txtref.Visible = true;
      int num = (int) frmGenDropBox.ShowDialog();
      frmGenDropBox.btnOK.Text = "Save";
      if (frmGenDropBox.DialogResult == DialogResult.Cancel)
        return;
      EngineerVisitCharge oEngineerVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(Conversions.ToInteger(this.SelectedInvoiceDataRow["EngineerVisitID"]));
      oEngineerVisitCharge.SetForSageAccountCode = (object) frmGenDropBox.txtref.Text.Trim();
      App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(oEngineerVisitCharge, (Job) null);
      this.SelectedInvoiceDataRow["AccountNumber"] = (object) frmGenDropBox.txtref.Text.Trim();
    }

    private void tsmiIssue_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      if (this.InvoicesDataview != null)
      {
        DataRow[] IDToLinkToIn = this.InvoicesDataview.Table.Select("tick = 1");
        int num1 = 0;
        DataRow[] dataRowArray = IDToLinkToIn;
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow dataRow = dataRowArray[index];
          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(IDToLinkToIn[0]["InvoiceType"], (object) "Sales Credit", false))
          {
            int num2 = (int) App.ShowMessage("Credits cannot be raised on credit records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
          }
          if (Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["CreditAmount"])) >= Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["Amount"])))
          {
            int num2 = (int) App.ShowMessage("Credit Amount cannot be greater than Invoice Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
          }
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject((object) (num1 == 0), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual((object) num1, dataRow["CustomerID"], false))))
          {
            num1 = Conversions.ToInteger(dataRow["customerID"]);
            checked { ++index; }
          }
          else
          {
            int num2 = (int) App.ShowMessage("Grouped credits must be against one customer only", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
          }
        }
        if (IDToLinkToIn.Length > 0)
        {
          using (FRMSalesCredit frmSalesCredit = new FRMSalesCredit(IDToLinkToIn, false, true))
          {
            int num2 = (int) frmSalesCredit.ShowDialog();
          }
          this.PopulateDatagrid();
        }
      }
    }

    private void tsmiRemove_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      int num1 = 0;
      if (this.SelectedInvoiceDataRow != null)
      {
        IEnumerator enumerator1;
        try
        {
          enumerator1 = this.InvoicesDataview.Table.Rows.GetEnumerator();
          while (enumerator1.MoveNext())
          {
            DataRow current1 = (DataRow) enumerator1.Current;
            if (Conversions.ToBoolean(current1["tick"]))
            {
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(current1["InvoiceType"], (object) "Sales Credit", false))
              {
                int num2 = (int) App.ShowMessage("You Can only delete credits", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
              }
              if (num1 == 0 | num1 == Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current1["LinkID"])))
              {
                num1 = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current1["LinkID"]));
                if ((uint) num1 > 0U)
                {
                  App.DB.ClearParameter();
                  DataTable dataTable = App.DB.ExecuteWithReturn("Select CreditReference , DateExportedToSage, InvoicedLineID from tblSalesCredit where SalesCreditID = " + Conversions.ToString(num1), true);
                  IEnumerator enumerator2;
                  try
                  {
                    enumerator2 = dataTable.Rows.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                      if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(((DataRow) enumerator2.Current)["DateExportedToSage"])))
                      {
                        int num2 = (int) App.ShowMessage("One or more Credits have already been exported, cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                      }
                    }
                  }
                  finally
                  {
                    if (enumerator2 is IDisposable)
                      (enumerator2 as IDisposable).Dispose();
                  }
                  IEnumerator enumerator3;
                  try
                  {
                    enumerator3 = dataTable.Rows.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                      DataRow current2 = (DataRow) enumerator3.Current;
                      App.DB.ExecuteScalar(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Delete tblInvoicedLinesCredit where invoicedLineID = ", current2["InvoicedLineID"])), true, false);
                    }
                  }
                  finally
                  {
                    if (enumerator3 is IDisposable)
                      (enumerator3 as IDisposable).Dispose();
                  }
                  App.DB.ExecuteScalar("Delete tblSalesCredit Where SalesCreditID = " + Conversions.ToString(num1), true, false);
                  num1 = 0;
                }
              }
              else
              {
                int num2 = (int) App.ShowMessage("You Can not delete more than one group of credits at once", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
              }
            }
          }
        }
        finally
        {
          if (enumerator1 is IDisposable)
            (enumerator1 as IDisposable).Dispose();
        }
        this.PopulateDatagrid();
      }
    }

    private void tsmiBatchPrint_Click(object sender, EventArgs e)
    {
      if (this.InvoicesDataview != null)
      {
        EnumerableRowCollection<DataRow> source1 = this.InvoicesDataview.Table.AsEnumerable();
        Func<DataRow, bool> predicate;
        // ISSUE: reference to a compiler-generated field
        if (FRMInvoicedManager._Closure\u0024__.\u0024I335\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          predicate = FRMInvoicedManager._Closure\u0024__.\u0024I335\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMInvoicedManager._Closure\u0024__.\u0024I335\u002D0 = predicate = (Func<DataRow, bool>) (sf => sf.Field<bool>("Tick") & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sf.Field<string>("InvoiceType"), "Sales Credit", false) == 0);
        }
        EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
        Func<DataRow, DataRow> selector;
        // ISSUE: reference to a compiler-generated field
        if (FRMInvoicedManager._Closure\u0024__.\u0024I335\u002D1 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector = FRMInvoicedManager._Closure\u0024__.\u0024I335\u002D1;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMInvoicedManager._Closure\u0024__.\u0024I335\u002D1 = selector = (Func<DataRow, DataRow>) (sf => sf);
        }
        DataRow[] array = source2.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
        if (((IEnumerable<DataRow>) array).Count<DataRow>() < 1)
        {
          int num = (int) App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          DataTable dataTable = new DataTable();
          Printing printing = new Printing((object) ((IEnumerable<DataRow>) array).CopyToDataTable<DataRow>(), "Sales Credit", Enums.SystemDocumentType.SalesCredit, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
        }
      }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      this.PopulateDatagrid();
    }

    private void btnGenNCCVal_Click(object sender, EventArgs e)
    {
      this.cmsValType.Show((Control) this.btnGenVal, new System.Drawing.Point(0, 0));
    }

    private void tsmiNCCVal_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        EnumerableRowCollection<DataRow> source1 = this.InvoicesDataview.Table.AsEnumerable();
        Func<DataRow, bool> predicate;
        // ISSUE: reference to a compiler-generated field
        if (FRMInvoicedManager._Closure\u0024__.\u0024I338\u002D0 != null)
        {
          // ISSUE: reference to a compiler-generated field
          predicate = FRMInvoicedManager._Closure\u0024__.\u0024I338\u002D0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMInvoicedManager._Closure\u0024__.\u0024I338\u002D0 = predicate = (Func<DataRow, bool>) (x => x.Field<bool>("Tick"));
        }
        EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
        Func<DataRow, int> selector;
        // ISSUE: reference to a compiler-generated field
        if (FRMInvoicedManager._Closure\u0024__.\u0024I338\u002D1 != null)
        {
          // ISSUE: reference to a compiler-generated field
          selector = FRMInvoicedManager._Closure\u0024__.\u0024I338\u002D1;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          FRMInvoicedManager._Closure\u0024__.\u0024I338\u002D1 = selector = (Func<DataRow, int>) (x => x.Field<int>("InvoicedID"));
        }
        List<int> list = source2.Select<DataRow, int>(selector).Distinct<int>().ToList<int>();
        if (list.Count == 0)
        {
          int num = (int) App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          DataTable dtData = new DataTable();
          dtData.Columns.Add("ValNo");
          dtData.Columns.Add("UPRN");
          dtData.Columns.Add("JOB");
          dtData.Columns.Add("ActualCompDate", typeof (DateTime));
          dtData.Columns.Add("Invoice");
          dtData.Columns.Add("Address");
          dtData.Columns.Add("Code");
          dtData.Columns.Add("SORDescription");
          dtData.Columns.Add("Plant");
          dtData.Columns.Add("Materials", typeof (double));
          dtData.Columns.Add("SubContractor", typeof (double));
          dtData.Columns.Add("Labour", typeof (double));
          dtData.Columns.Add("SORCost", typeof (double));
          dtData.Columns.Add("MarginOnMaterials", typeof (double));
          dtData.Columns.Add("MarginOnSubCon", typeof (double));
          dtData.Columns.Add("Total", typeof (double));
          dtData.Columns.Add("VAT", typeof (double));
          dtData.Columns.Add("GrandTotal", typeof (double));
          dtData.Columns.Add("Recharge");
          dtData.Columns.Add("HPSOfficer");
          try
          {
            foreach (int InvoicedID in list)
            {
              DataView dataView = App.DB.Invoiced.NCCValuation(InvoicedID);
              IEnumerator enumerator;
              try
              {
                enumerator = dataView.Table.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                  DataRow current = (DataRow) enumerator.Current;
                  DataRow row = dtData.NewRow();
                  row["ValNo"] = RuntimeHelpers.GetObjectValue(current["ValNum"]);
                  row["UPRN"] = RuntimeHelpers.GetObjectValue(current["UPRN"]);
                  row["JOB"] = RuntimeHelpers.GetObjectValue(current["JOB"]);
                  row["ActualCompDate"] = RuntimeHelpers.GetObjectValue(current["ActualCompletion"]);
                  row["Invoice"] = RuntimeHelpers.GetObjectValue(current["InvoiceNumber"]);
                  row["Address"] = RuntimeHelpers.GetObjectValue(current["Address1"]);
                  row["Code"] = RuntimeHelpers.GetObjectValue(current["CODE"]);
                  row["SORDescription"] = RuntimeHelpers.GetObjectValue(current["Description"]);
                  row["Plant"] = RuntimeHelpers.GetObjectValue(current["Plant"]);
                  row["Materials"] = RuntimeHelpers.GetObjectValue(current["Material"]);
                  row["SubContractor"] = RuntimeHelpers.GetObjectValue(current["SubContractor"]);
                  row["Labour"] = RuntimeHelpers.GetObjectValue(current["labour"]);
                  row["SORCost"] = RuntimeHelpers.GetObjectValue(current["SORCost"]);
                  row["MarginOnMaterials"] = RuntimeHelpers.GetObjectValue(current["MatMark"]);
                  row["MarginOnSubCon"] = RuntimeHelpers.GetObjectValue(current["SubConMark"]);
                  row["Total"] = RuntimeHelpers.GetObjectValue(current["Total"]);
                  row["VAT"] = RuntimeHelpers.GetObjectValue(current["VAT"]);
                  row["GrandTotal"] = RuntimeHelpers.GetObjectValue(current["GrandTotal"]);
                  row["Recharge"] = RuntimeHelpers.GetObjectValue(current["Recharge"]);
                  row["HPSOfficer"] = RuntimeHelpers.GetObjectValue(current["HpsOfficer"]);
                  dtData.Rows.Add(row);
                }
              }
              finally
              {
                if (enumerator is IDisposable)
                  (enumerator as IDisposable).Dispose();
              }
            }
          }
          finally
          {
            List<int>.Enumerator enumerator;
            enumerator.Dispose();
          }
          ExportHelper.Export(dtData, "NCC Valuation", Enums.ExportType.XLS);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error generating document!\r\n\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.Cursor = Cursors.Default;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void tsmiSorVal_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.InvoicesDataview != null)
        {
          EnumerableRowCollection<DataRow> source1 = this.InvoicesDataview.Table.AsEnumerable();
          Func<DataRow, bool> predicate;
          // ISSUE: reference to a compiler-generated field
          if (FRMInvoicedManager._Closure\u0024__.\u0024I339\u002D0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            predicate = FRMInvoicedManager._Closure\u0024__.\u0024I339\u002D0;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            FRMInvoicedManager._Closure\u0024__.\u0024I339\u002D0 = predicate = (Func<DataRow, bool>) (sf => sf.Field<bool>("Tick"));
          }
          EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
          Func<DataRow, DataRow> selector;
          // ISSUE: reference to a compiler-generated field
          if (FRMInvoicedManager._Closure\u0024__.\u0024I339\u002D1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            selector = FRMInvoicedManager._Closure\u0024__.\u0024I339\u002D1;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            FRMInvoicedManager._Closure\u0024__.\u0024I339\u002D1 = selector = (Func<DataRow, DataRow>) (sf => sf);
          }
          DataRow[] array = source2.Select<DataRow, DataRow>(selector).ToArray<DataRow>();
          if (((IEnumerable<DataRow>) array).Count<DataRow>() < 1)
          {
            int num1 = (int) App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          else
          {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("UPRN", typeof (string));
            dtData.Columns.Add("Client Ref", typeof (string));
            dtData.Columns.Add("Gasway Job Number", typeof (string));
            dtData.Columns.Add("Completion Date", typeof (DateTime));
            dtData.Columns.Add("Invoice Number", typeof (string));
            dtData.Columns.Add("Address", typeof (string));
            dtData.Columns.Add("Invoice Description", typeof (string));
            dtData.Columns.Add("SOR Code", typeof (string));
            dtData.Columns.Add("SOR Description", typeof (string));
            dtData.Columns.Add("SOR Price", typeof (string));
            dtData.Columns.Add("SOR Qty", typeof (int));
            dtData.Columns.Add("SOR Total", typeof (string));
            try
            {
              DataRow[] dataRowArray = array;
              int index = 0;
              while (index < dataRowArray.Length)
              {
                DataRow dataRow = dataRowArray[index];
                if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dataRow["InvoiceType"], (object) "Visit", false) && !dataRow["AccountNumber"].ToString().Contains("IBC"))
                {
                  int EngineerVisitID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["EngineerVisitID"]));
                  DataView forVal = App.DB.EngineerVisits.EngineerVisits_Get_ForVal(EngineerVisitID);
                  if (forVal.Count >= 1)
                  {
                    DataView sorBreakdownForVal = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get_SorBreakdownForVal(EngineerVisitID);
                    IEnumerator enumerator;
                    try
                    {
                      enumerator = sorBreakdownForVal.GetEnumerator();
                      while (enumerator.MoveNext())
                      {
                        DataRowView current = (DataRowView) enumerator.Current;
                        DataRow row = dtData.NewRow();
                        row["UPRN"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["UPRN"]));
                        row["Address"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["Site"]));
                        row["Gasway Job Number"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["JobNumber"]));
                        row["Completion Date"] = (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(forVal[0]["CompletedDateTime"]));
                        row["Client Ref"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["ClientRef"]));
                        row["Invoice Number"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["InvoiceNumber"]));
                        row["Invoice Description"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["InvoiceNotes"]));
                        row["SOR Code"] = RuntimeHelpers.GetObjectValue(current["Code"]);
                        row["SOR Description"] = RuntimeHelpers.GetObjectValue(current["Description"]);
                        row["SOR Price"] = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Cost"])).ToString("c");
                        row["SOR Qty"] = (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current["Quantity"]));
                        row["SOR Total"] = (object) Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(current["Charge"])).ToString("c");
                        dtData.Rows.Add(row);
                      }
                    }
                    finally
                    {
                      if (enumerator is IDisposable)
                        (enumerator as IDisposable).Dispose();
                    }
                  }
                }
                checked { ++index; }
              }
              ExportHelper.Export(dtData, "Valuation", Enums.ExportType.XLS);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num2 = (int) App.ShowMessage("Error generating document!\r\n\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              this.Cursor = Cursors.Default;
              ProjectData.ClearProjectError();
            }
            finally
            {
              this.Cursor = Cursors.Default;
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error generating document!\r\n\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.Cursor = Cursors.Default;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void tsmiGenericVal_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.InvoicesDataview != null)
        {
          EnumerableRowCollection<DataRow> source1 = this.InvoicesDataview.Table.AsEnumerable();
          Func<DataRow, bool> predicate1;
          // ISSUE: reference to a compiler-generated field
          if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            predicate1 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D0;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D0 = predicate1 = (Func<DataRow, bool>) (sf => sf.Field<bool>("Tick"));
          }
          EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate1);
          Func<DataRow, DataRow> selector1;
          // ISSUE: reference to a compiler-generated field
          if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            selector1 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D1;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D1 = selector1 = (Func<DataRow, DataRow>) (sf => sf);
          }
          DataRow[] array = source2.Select<DataRow, DataRow>(selector1).ToArray<DataRow>();
          if (((IEnumerable<DataRow>) array).Count<DataRow>() < 1)
          {
            int num1 = (int) App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          else
          {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("UPRN", typeof (string));
            dtData.Columns.Add("Client Ref", typeof (string));
            dtData.Columns.Add("Gasway Job Number", typeof (string));
            dtData.Columns.Add("Completion Date", typeof (DateTime));
            dtData.Columns.Add("Invoice Number", typeof (string));
            dtData.Columns.Add("Address", typeof (string));
            dtData.Columns.Add("Invoice Description", typeof (string));
            dtData.Columns.Add("SOR Description", typeof (string));
            dtData.Columns.Add("SOR Cost", typeof (Decimal));
            dtData.Columns.Add("Labour Cost", typeof (Decimal));
            dtData.Columns.Add("Parts Cost", typeof (Decimal));
            dtData.Columns.Add("Additional Cost", typeof (Decimal));
            dtData.Columns.Add("Total ex VAT", typeof (double));
            dtData.Columns.Add("VAT", typeof (double));
            dtData.Columns.Add("Total", typeof (double));
            try
            {
              DataRow[] dataRowArray = array;
              int index = 0;
              while (index < dataRowArray.Length)
              {
                DataRow dataRow = dataRowArray[index];
                if (!Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(dataRow["InvoiceType"], (object) "Visit", false) && !dataRow["AccountNumber"].ToString().Contains("IBC"))
                {
                  int EngineerVisitID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["EngineerVisitID"]));
                  DataView forVal = App.DB.EngineerVisits.EngineerVisits_Get_ForVal(EngineerVisitID);
                  if (forVal.Count >= 1)
                  {
                    DataView chargedBreakDown = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get_ChargedBreakDown(EngineerVisitID);
                    EnumerableRowCollection<DataRow> source3 = chargedBreakDown.Table.AsEnumerable();
                    Func<DataRow, bool> predicate2;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D2 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      predicate2 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D2;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D2 = predicate2 = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "PARTS", false) == 0);
                    }
                    EnumerableRowCollection<DataRow> source4 = source3.Where<DataRow>(predicate2);
                    Func<DataRow, Decimal> selector2;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D3 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector2 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D3;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D3 = selector2 = (Func<DataRow, Decimal>) (row => row.Field<Decimal>("Charge"));
                    }
                    Decimal num2 = source4.Sum<DataRow>(selector2);
                    EnumerableRowCollection<DataRow> source5 = chargedBreakDown.Table.AsEnumerable();
                    Func<DataRow, bool> predicate3;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D4 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      predicate3 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D4;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D4 = predicate3 = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "SOR", false) == 0);
                    }
                    EnumerableRowCollection<DataRow> source6 = source5.Where<DataRow>(predicate3);
                    Func<DataRow, Decimal> selector3;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D5 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector3 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D5;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D5 = selector3 = (Func<DataRow, Decimal>) (row => row.Field<Decimal>("Charge"));
                    }
                    Decimal num3 = source6.Sum<DataRow>(selector3);
                    EnumerableRowCollection<DataRow> source7 = chargedBreakDown.Table.AsEnumerable();
                    Func<DataRow, bool> predicate4;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D6 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      predicate4 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D6;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D6 = predicate4 = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "LABOUR", false) == 0);
                    }
                    EnumerableRowCollection<DataRow> source8 = source7.Where<DataRow>(predicate4);
                    Func<DataRow, Decimal> selector4;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D7 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector4 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D7;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D7 = selector4 = (Func<DataRow, Decimal>) (row => row.Field<Decimal>("Charge"));
                    }
                    Decimal num4 = source8.Sum<DataRow>(selector4);
                    EnumerableRowCollection<DataRow> source9 = chargedBreakDown.Table.AsEnumerable();
                    Func<DataRow, bool> predicate5;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D8 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      predicate5 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D8;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D8 = predicate5 = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "ADDITIONAL", false) == 0);
                    }
                    EnumerableRowCollection<DataRow> source10 = source9.Where<DataRow>(predicate5);
                    Func<DataRow, Decimal> selector5;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D9 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector5 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D9;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D9 = selector5 = (Func<DataRow, Decimal>) (row => row.Field<Decimal>("Charge"));
                    }
                    Decimal num5 = source10.Sum<DataRow>(selector5);
                    EnumerableRowCollection<DataRow> source11 = chargedBreakDown.Table.AsEnumerable();
                    Func<DataRow, bool> predicate6;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D10 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      predicate6 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D10;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D10 = predicate6 = (Func<DataRow, bool>) (row => Microsoft.VisualBasic.CompilerServices.Operators.CompareString(row.Field<string>("Type"), "SOR", false) == 0);
                    }
                    EnumerableRowCollection<DataRow> source12 = source11.Where<DataRow>(predicate6);
                    Func<DataRow, string> selector6;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D11 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector6 = FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D11;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I340\u002D11 = selector6 = (Func<DataRow, string>) (row => row.Field<string>("Description"));
                    }
                    string str = string.Join(" / ", source12.Select<DataRow, string>(selector6).ToArray<string>());
                    double num6 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["Amount"]));
                    double num7 = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(dataRow["VATRate"])) / 100.0;
                    double num8 = num6 * num7;
                    double num9 = num6 + Math.Round(num8, 2, MidpointRounding.ToEven);
                    DataRow row1 = dtData.NewRow();
                    row1["UPRN"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["UPRN"]));
                    row1["Address"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["Site"]));
                    row1["Gasway Job Number"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["JobNumber"]));
                    row1["Completion Date"] = (object) Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(forVal[0]["CompletedDateTime"]));
                    row1["Client Ref"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["ClientRef"]));
                    row1["Invoice Number"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["InvoiceNumber"]));
                    row1["Invoice Description"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(forVal[0]["InvoiceNotes"]));
                    row1["SOR Description"] = (object) str;
                    row1["SOR Cost"] = (object) num3;
                    row1["Labour Cost"] = (object) num4;
                    row1["Parts Cost"] = (object) num2;
                    row1["Additional Cost"] = (object) num5;
                    row1["Total ex VAT"] = (object) num6;
                    row1["VAT"] = (object) Math.Round(num8, 2, MidpointRounding.ToEven);
                    row1["Total"] = (object) Math.Round(num9, 2, MidpointRounding.ToEven);
                    dtData.Rows.Add(row1);
                  }
                }
                checked { ++index; }
              }
              ExportHelper.Export(dtData, "Valuation", Enums.ExportType.XLS);
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              int num2 = (int) App.ShowMessage("Error generating document!\r\n\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
              this.Cursor = Cursors.Default;
              ProjectData.ClearProjectError();
            }
            finally
            {
              this.Cursor = Cursors.Default;
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error generating document!\r\n\r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.Cursor = Cursors.Default;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    private void txtJobNumber_TextChanged(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.PopulateDatagrid();
    }

    private void txtSageMonth_TextChanged(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.");
      if (App.ShowForm(typeof (FRMChangeSageDate), true, (object[]) null, false).DialogResult != DialogResult.OK)
        return;
      this.txtSageMonth.Text = Conversions.ToDate(App.DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69", true, false)).ToString("MMMM yyyy");
    }

    private void tsmiOrderNo_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you want to update the order numbers?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
        return;
      try
      {
        DataRow[] dataRowArray = this.InvoicesDataview.Table.GetChanges().Select("InvoiceTypeID = " + Conversions.ToString(260));
        int index = 0;
        while (index < dataRowArray.Length)
        {
          DataRow dataRow = dataRowArray[index];
          int jobOfWorkId = dataRow.Table.Columns.Contains("JobOfWorkID") ? Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRow["JobOfWorkID"])) : 0;
          string poNumber = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRow["OrderNo"]));
          if (jobOfWorkId > 0)
            App.DB.JobOfWorks.Update_PONumberByJobOfWorkID(jobOfWorkId, poNumber);
          checked { ++index; }
        }
        int num = (int) App.ShowMessage("Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Unable to save: " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void view()
    {
      if (this.SelectedInvoiceDataRow != null)
      {
        switch ((Enums.InvoiceType) Conversions.ToInteger(this.SelectedInvoiceDataRow["InvoiceTypeID"]))
        {
          case Enums.InvoiceType.Visit:
            App.ShowForm(typeof (FRMEngineerVisit), true, new object[1]
            {
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["EngineerVisitID"]))
            }, false);
            break;
          case Enums.InvoiceType.Order:
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
                return;
              case 2:
                App.ShowForm(typeof (FRMOrder), false, new object[4]
                {
                  this.SelectedInvoiceDataRow["OrderID"],
                  this.SelectedInvoiceDataRow["VanID"],
                  (object) 0,
                  (object) this
                }, false);
                return;
              case 3:
                App.ShowForm(typeof (FRMOrder), false, new object[4]
                {
                  this.SelectedInvoiceDataRow["OrderID"],
                  this.SelectedInvoiceDataRow["WarehouseID"],
                  (object) 0,
                  (object) this
                }, false);
                return;
              case 4:
                App.ShowForm(typeof (FRMOrder), false, new object[4]
                {
                  this.SelectedInvoiceDataRow["OrderID"],
                  this.SelectedInvoiceDataRow["EngineerVisitID"],
                  (object) 0,
                  (object) this
                }, false);
                return;
              default:
                App.ShowForm(typeof (FRMConsolidation), true, new object[1]
                {
                  this.SelectedInvoiceDataRow["OrderID"]
                }, false);
                return;
            }
          case Enums.InvoiceType.Contract_Option1:
            App.ShowForm(typeof (FRMContractOriginal), true, new object[2]
            {
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["ContractID"])),
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["CustomerID"]))
            }, false);
            break;
        }
      }
      else
      {
        int num = (int) App.ShowMessage("Please select an invoice.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public void PopulateDatagrid()
    {
      this.Cursor = Cursors.WaitCursor;
      int customerId = this.theCustomer != null ? this.theCustomer.CustomerID : 0;
      int siteId = this.theSite != null ? this.theSite.SiteID : 0;
      string postcode = this.txtPostcode.Text.Trim().Length > 0 ? this.txtPostcode.Text : (string) null;
      int integer1 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType));
      string jobNumber = this.txtJobNumber.Text.Trim().Length > 0 ? this.txtJobNumber.Text : (string) null;
      string invoiceNumber = this.txtInvoiceNumber.Text.Trim().Length > 0 ? this.txtInvoiceNumber.Text : (string) null;
      int integer2 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboUser));
      int integer3 = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboRegion));
      string department = Combo.get_GetSelectedItemValue(this.cboDept).Trim();
      int exportedToSage = -1;
      if (this.cboExported.SelectedIndex == 1)
        exportedToSage = 1;
      else if (this.cboExported.SelectedIndex == 2)
        exportedToSage = 0;
      this.InvoicesDataview = App.DB.Invoiced.Invoiced_GetAll_Manager(this.dtpRaisedFrom.Value, this.dtpRaisedTo.Value, customerId, siteId, postcode, integer1, jobNumber, invoiceNumber, integer2, integer3, department, exportedToSage);
      if (this.chkExportedOn.Checked)
        this.InvoicesDataview.RowFilter = "ExportedOn = #" + this.dtpExportedOn.Value.ToString("yyyy-MM-dd") + "#";
      this.grpInvoices.Text = "Double Click To View / Add Payment Information - Search Results (" + Conversions.ToString(this.InvoicesDataview.Count) + ")";
      this.Cursor = Cursors.Default;
    }

    private void ResetFilters()
    {
      this.theCustomer = (FSM.Entity.Customers.Customer) null;
      DateTime dateTime1;
      DateTime dateTime2;
      switch (DateAndTime.Today.DayOfWeek)
      {
        case DayOfWeek.Sunday:
          dateTime2 = DateAndTime.Now;
          dateTime1 = dateTime2.AddDays(-6.0);
          break;
        case DayOfWeek.Monday:
          dateTime1 = DateAndTime.Now;
          break;
        case DayOfWeek.Tuesday:
          dateTime2 = DateAndTime.Now;
          dateTime1 = dateTime2.AddDays(-1.0);
          break;
        case DayOfWeek.Wednesday:
          dateTime2 = DateAndTime.Now;
          dateTime1 = dateTime2.AddDays(-2.0);
          break;
        case DayOfWeek.Thursday:
          dateTime2 = DateAndTime.Now;
          dateTime1 = dateTime2.AddDays(-3.0);
          break;
        case DayOfWeek.Friday:
          dateTime2 = DateAndTime.Now;
          dateTime1 = dateTime2.AddDays(-4.0);
          break;
        case DayOfWeek.Saturday:
          dateTime2 = DateAndTime.Now;
          dateTime1 = dateTime2.AddDays(-5.0);
          break;
      }
      ComboBox comboBox = this.cboStatus;
      Combo.SetUpCombo(ref comboBox, DynamicDataTables.InvoiceStatus, "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboStatus = comboBox;
      comboBox = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(-3));
      this.cboStatus = comboBox;
      this.txtInvoiceNumber.Text = "";
      comboBox = this.cboUser;
      Combo.SetUpCombo(ref comboBox, App.DB.User.GetAll().Table, "UserID", "Fullname", Enums.ComboValues.No_Filter);
      this.cboUser = comboBox;
      comboBox = this.cboUser;
      Combo.SetSelectedComboItem_By_Value(ref comboBox, Conversions.ToString(0));
      this.cboUser = comboBox;
      this.dtpRaisedFrom.Value = dateTime1.AddDays(-21.0);
      this.dtpRaisedTo.Value = dateTime1.AddDays(7.0);
      comboBox = this.cboType;
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
      string str1 = Conversions.ToString(App.DB.ExecuteScalar("Select Name from tblpicklists where enumtypeid = 69", true, false));
      if (Information.IsNothing((object) str1))
        return;
      TextBox txtSageMonth = this.txtSageMonth;
      dateTime2 = Conversions.ToDate(str1);
      string str2 = dateTime2.ToString("MMMM yyyy");
      txtSageMonth.Text = str2;
    }

    public void Export()
    {
      if (Helper.MakeIntegerValid((object) this.InvoicesDataview?.Count) <= 0)
      {
        int num = (int) App.ShowMessage("No filter added", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        DataTable dtData = new DataTable();
        dtData.Columns.Add("PaidStatus");
        dtData.Columns.Add("Customer");
        dtData.Columns.Add("Site");
        dtData.Columns.Add("InvoiceType");
        dtData.Columns.Add("JobNumber");
        dtData.Columns.Add("InvoiceAddressType");
        dtData.Columns.Add("InvoiceAddress");
        dtData.Columns.Add("Amount", typeof (double));
        dtData.Columns.Add("InvoiceNumber");
        dtData.Columns.Add("RaisedDate");
        dtData.Columns.Add("Fullname");
        dtData.Columns.Add("Department");
        dtData.Columns.Add("Exported");
        IEnumerator enumerator;
        try
        {
          enumerator = ((DataView) this.dgInvoices.DataSource).GetEnumerator();
          while (enumerator.MoveNext())
          {
            DataRowView current = (DataRowView) enumerator.Current;
            DataRow row = dtData.NewRow();
            row["PaidStatus"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["PaidStatus"]);
            row["Customer"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["Customer"]);
            row["Site"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["Site"]);
            row["InvoiceType"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["InvoiceType"]);
            row["JobNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["JobNumber"]);
            row["InvoiceAddressType"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["InvoiceAddressType"]);
            row["InvoiceAddress"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["InvoiceAddress"]);
            row["Amount"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["Amount"]);
            row["InvoiceNumber"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["InvoiceNumber"]);
            row["RaisedDate"] = (object) Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["RaisedDate"]), "dd/MM/yyyy");
            row["Fullname"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["Fullname"]);
            row["Department"] = RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["Department"]);
            row["Exported"] = DateTime.Compare(Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["DateExportedToSage"])), DateTime.MinValue) != 0 ? (object) Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(this.SelectedInvoiceDataRow["DateExportedToSage"]), "dd/MM/yyyy") : (object) "";
            dtData.Rows.Add(row);
          }
        }
        finally
        {
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        ExportHelper.Export(dtData, "Invoiced List", Enums.ExportType.XLS);
      }
    }

    public void Print()
    {
      if (this.InvoicesToPrint.Count < 1)
        return;
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
                  if (!this.InvoicesToPrint.Contains(RuntimeHelpers.GetObjectValue(table1.Rows[0]["InvoicedID"])))
                    this.InvoicesToPrint.Add((object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(table1.Rows[0]["InvoicedID"])));
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
                  if (!this.InvoicesToPrint.Contains((object) inv.InvoicedID))
                    this.InvoicesToPrint.Add((object) Helper.MakeIntegerValid((object) inv.InvoicedID));
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
                if (!this.InvoicesToPrint.Contains(RuntimeHelpers.GetObjectValue(current1["InvoicedID"])))
                  this.InvoicesToPrint.Add((object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current1["InvoicedID"])));
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
          if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(dataRowArray[index]["invoicedID"])) == 0)
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
          }
          else
            dataRowArray[index]["tick"] = (object) 0;
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

    private bool Check_Supplier_Invoices_And_Continue()
    {
      bool flag = false;
      IEnumerator enumerator;
      try
      {
        enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.OrObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["InvoiceType"], (object) "Supplier", false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(current["InvoiceType"], (object) "Consolidation", false))) && Conversions.ToBoolean(current["Tick"]))
          {
            current["Tick"] = (object) false;
            flag = true;
          }
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      return !flag || App.ShowMessage("Supplier invoices have been removed - would you like to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No;
    }

    private async void btnMarkAsNotExported_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Are you sure you want to mark the selected invoices as not exported?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
        return;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.InvoicesDataview != null)
        {
          DataRow dataRow = (DataRow) null;
          IEnumerator enumerator;
          try
          {
            enumerator = this.InvoicesDataview.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator.Current;
              if (Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(current["tick"])))
              {
                if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Supplier", false))
                  await App.DB.Invoiced.MarkOrderAsNotExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["SupplierInvoiceID"])));
                else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Part Credit", false))
                  await App.DB.Invoiced.MarkPartCreditedAsNotExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["OrderID"])), Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["LinkID"])));
                else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Consolidation", false))
                  await App.DB.Invoiced.MarkConsolidatedOrderAsNotExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["OrderID"])));
                else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Sales Credit", false))
                  await App.DB.Invoiced.MarkSalesCreditAsNotExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["LinkID"])));
                else
                  await App.DB.Invoiced.MarkInvoiceAsNotExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["InvoicedID"])));
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        this.PopulateDatagrid();
        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        int num = (int) MessageBox.Show("An Error has occurred: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.Cursor = Cursors.Default;
        ProjectData.ClearProjectError();
      }
    }

    private void cboExportedToSage_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        this.PopulateDatagrid();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("An Error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        ProjectData.ClearProjectError();
      }
    }

    private void btnExportToAccounts_Click(object sender, EventArgs e)
    {
      this.cmsExportForAccounts.Show((Control) this.btnExportToAccounts, new System.Drawing.Point(0, 0));
    }

    private async void tsmiSunExport_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
      {
        string message = "You do not have the necessary security permissions.";
        throw new SecurityException(message);
      }
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.InvoicesDataview != null)
        {
          EnumerableRowCollection<DataRow> source1 = this.InvoicesDataview.Table.AsEnumerable();
          Func<DataRow, bool> predicate;
          // ISSUE: reference to a compiler-generated field
          if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            predicate = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D0;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D0 = predicate = (Func<DataRow, bool>) (sf => sf.Field<bool>("Tick"));
          }
          EnumerableRowCollection<DataRow> source2 = source1.Where<DataRow>(predicate);
          Func<DataRow, DataRow> selector1;
          // ISSUE: reference to a compiler-generated field
          if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D1 != null)
          {
            // ISSUE: reference to a compiler-generated field
            selector1 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D1;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D1 = selector1 = (Func<DataRow, DataRow>) (sf => sf);
          }
          DataRow[] array = source2.Select<DataRow, DataRow>(selector1).ToArray<DataRow>();
          if (((IEnumerable<DataRow>) array).Count<DataRow>() < 1)
          {
            int num1 = (int) App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          else
          {
            DateTime dateTime1 = Conversions.ToDate(this.txtSageMonth.Text);
            int year = dateTime1.Year;
            dateTime1 = Conversions.ToDate(this.txtSageMonth.Text);
            int month = dateTime1.Month;
            DateTime dateTime = new DateTime(year, month, 1);
            DataTable allMaps = App.DB.SunFinance.GetAllMaps();
            Payload payload = new Payload();
            DataRow[] dataRowArray = array;
            int index = 0;
            while (index < dataRowArray.Length)
            {
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: variable of a compiler-generated type
              FRMInvoicedManager._Closure\u0024__356\u002D0 closure3560 = new FRMInvoicedManager._Closure\u0024__356\u002D0(closure3560);
              // ISSUE: reference to a compiler-generated field
              closure3560.\u0024VB\u0024Local_r = dataRowArray[index];
              // ISSUE: object of a compiler-generated type is created
              // ISSUE: variable of a compiler-generated type
              FRMInvoicedManager._Closure\u0024__356\u002D1 closure3561 = new FRMInvoicedManager._Closure\u0024__356\u002D1(closure3561);
              // ISSUE: reference to a compiler-generated field
              closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2 = closure3560;
              // ISSUE: reference to a compiler-generated field
              closure3561.\u0024VB\u0024Local_custType = string.Empty;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              string Left1 = closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceType"].ToString();
              // ISSUE: reference to a compiler-generated field
              closure3561.\u0024VB\u0024Local_custType = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Supplier", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Part Credit", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Consolidation", false) == 0 ? "Supplier" : "Customer";
              // ISSUE: reference to a compiler-generated field
              bool flag = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(closure3561.\u0024VB\u0024Local_custType, "Supplier", false) == 0;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (!Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["ExportedToSage"])))
              {
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                if (Conversions.ToDouble(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])) > 0.0)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  if (DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Raiseddate"]), "dd/MM/yyyy")), dateTime) < 0 & !flag)
                  {
                    int num2 = (int) App.ShowMessage("A invoice has been stopped in the export as it is for a different month to the current processing month.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                  }
                  else
                  {
                    EnumerableRowCollection<DataRow> source3 = allMaps.AsEnumerable();
                    Func<DataRow, VB\u0024AnonymousType_0<string, string, string, bool>> selector2;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D2 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector2 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D2;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D2 = selector2 = x =>
                      {
                        var data = new
                        {
                          Type = x.Field<string>("Type"),
                          OldVal = x.Field<string>("OldVal"),
                          NewVal = x.Field<string>("NewVal"),
                          Deleted = x.Field<bool>("Deleted")
                        };
                        return data;
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated method
                    EnumerableRowCollection<VB\u0024AnonymousType_0<string, string, string, bool>> source4 = source3.Select(selector2).Where(new Func<VB\u0024AnonymousType_0<string, string, string, bool>, bool>(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2._Lambda\u0024__3));
                    Func<VB\u0024AnonymousType_0<string, string, string, bool>, string> selector3;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D4 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector3 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D4;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D4 = selector3 = h => h.NewVal;
                    }
                    string Left = source4.Select(selector3).FirstOrDefault<string>();
                    if (string.IsNullOrEmpty(Left))
                    {
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      Left = Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["NominalCode"]));
                    }
                    EnumerableRowCollection<DataRow> source5 = allMaps.AsEnumerable();
                    Func<DataRow, VB\u0024AnonymousType_0<string, string, string, bool>> selector4;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D5 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector4 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D5;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D5 = selector4 = x =>
                      {
                        var data = new
                        {
                          Type = x.Field<string>("Type"),
                          OldVal = x.Field<string>("OldVal"),
                          NewVal = x.Field<string>("NewVal"),
                          Deleted = x.Field<bool>("Deleted")
                        };
                        return data;
                      };
                    }
                    // ISSUE: reference to a compiler-generated method
                    EnumerableRowCollection<VB\u0024AnonymousType_0<string, string, string, bool>> source6 = source5.Select(selector4).Where(new Func<VB\u0024AnonymousType_0<string, string, string, bool>, bool>(closure3561._Lambda\u0024__6));
                    Func<VB\u0024AnonymousType_0<string, string, string, bool>, string> selector5;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D7 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector5 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D7;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D7 = selector5 = h => h.NewVal;
                    }
                    string str1 = source6.Select(selector5).FirstOrDefault<string>();
                    if (string.IsNullOrEmpty(str1))
                    {
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      str1 = Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["AccountNumber"]));
                    }
                    EnumerableRowCollection<DataRow> source7 = allMaps.AsEnumerable();
                    Func<DataRow, VB\u0024AnonymousType_0<string, string, string, bool>> selector6;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D8 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector6 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D8;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D8 = selector6 = x =>
                      {
                        var data = new
                        {
                          Type = x.Field<string>("Type"),
                          OldVal = x.Field<string>("OldVal"),
                          NewVal = x.Field<string>("NewVal"),
                          Deleted = x.Field<bool>("Deleted")
                        };
                        return data;
                      };
                    }
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated method
                    EnumerableRowCollection<VB\u0024AnonymousType_0<string, string, string, bool>> source8 = source7.Select(selector6).Where(new Func<VB\u0024AnonymousType_0<string, string, string, bool>, bool>(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2._Lambda\u0024__9));
                    Func<VB\u0024AnonymousType_0<string, string, string, bool>, string> selector7;
                    // ISSUE: reference to a compiler-generated field
                    if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D10 != null)
                    {
                      // ISSUE: reference to a compiler-generated field
                      selector7 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D10;
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D10 = selector7 = h => h.NewVal;
                    }
                    string str2 = source8.Select(selector7).FirstOrDefault<string>();
                    Line line1 = new Line();
                    Line line2 = (Line) null;
                    Line line3 = (Line) null;
                    line1.AccountCode = Left;
                    line1.AccountingPeriod = AccountsHelper.GetAccountPeriod(dateTime);
                    if (!string.IsNullOrEmpty(str2))
                      line1.AnalysisCode1 = str2;
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    line1.AnalysisCode2 = AccountsHelper.FormatSunDepartment(Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Department"])));
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    line1.TransactionDate = Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDate(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["RaisedDate"])), "ddMMyyyy");
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    line1.TransactionReference = Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceNumber"]));
                    Line line = line1;
                    dateTime1 = DateAndTime.Now;
                    string str = dateTime1.ToString("ddMMyyyy");
                    line.EntryDate = str;
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    if (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobID"])) > 0)
                    {
                      // ISSUE: object of a compiler-generated type is created
                      // ISSUE: variable of a compiler-generated type
                      FRMInvoicedManager._Closure\u0024__356\u002D2 closure3562 = new FRMInvoicedManager._Closure\u0024__356\u002D2(closure3562);
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      closure3562.\u0024VB\u0024Local_jobType = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobType"]));
                      EnumerableRowCollection<DataRow> source9 = allMaps.AsEnumerable();
                      Func<DataRow, VB\u0024AnonymousType_0<string, string, string, bool>> selector8;
                      // ISSUE: reference to a compiler-generated field
                      if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D11 != null)
                      {
                        // ISSUE: reference to a compiler-generated field
                        selector8 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D11;
                      }
                      else
                      {
                        // ISSUE: reference to a compiler-generated field
                        FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D11 = selector8 = x =>
                        {
                          var data = new
                          {
                            Type = x.Field<string>("Type"),
                            OldVal = x.Field<string>("OldVal"),
                            NewVal = x.Field<string>("NewVal"),
                            Deleted = x.Field<bool>("Deleted")
                          };
                          return data;
                        };
                      }
                      // ISSUE: reference to a compiler-generated method
                      EnumerableRowCollection<VB\u0024AnonymousType_0<string, string, string, bool>> source10 = source9.Select(selector8).Where(new Func<VB\u0024AnonymousType_0<string, string, string, bool>, bool>(closure3562._Lambda\u0024__12));
                      Func<VB\u0024AnonymousType_0<string, string, string, bool>, string> selector9;
                      // ISSUE: reference to a compiler-generated field
                      if (FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D13 != null)
                      {
                        // ISSUE: reference to a compiler-generated field
                        selector9 = FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D13;
                      }
                      else
                      {
                        // ISSUE: reference to a compiler-generated field
                        FRMInvoicedManager._Closure\u0024__.\u0024I356\u002D13 = selector9 = h => h.NewVal;
                      }
                      string str3 = source10.Select(selector9).FirstOrDefault<string>();
                      if (string.IsNullOrEmpty(str3))
                        str3 = "GENERI";
                      line1.AnalysisCode4 = str3;
                    }
                    else
                      line1.AnalysisCode4 = "GENERI";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    line1.AnalysisCode6 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(line1.AnalysisCode2, "004", false) != 0 ? (Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["CustomerTypeID"])) != 516 ? "GAS" : "GSH") : "COM";
                    line1.AnalysisCode7 = str1;
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    string str4 = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Customer"])).Replace(" ", "");
                    line1.AnalysisCode8 = str4.Substring(0, Math.Min(str4.Length, 15));
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    line1.AnalysisCode9 = Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"]));
                    string str5 = (string) null;
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    string Left2 = closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Tax_Code"].ToString();
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "T0", false) != 0)
                    {
                      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "T1", false) != 0)
                      {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "T2", false) != 0)
                        {
                          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "T5", false) != 0)
                          {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "T9", false) == 0)
                              str5 = "OS";
                          }
                          else
                            str5 = "LR";
                        }
                        else
                          str5 = "ER";
                      }
                      else
                        str5 = "SR";
                    }
                    else
                      str5 = "ZR";
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    string Left3 = closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceType"].ToString();
                    str5 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, "Supplier", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, "Part Credit", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left3, "Consolidation", false) == 0 ? "I" + str5 : "O" + str5;
                    string str6 = "B5850";
                    if (App.IsRFT)
                    {
                      line1.AnalysisCode3 = "NTS";
                      line1.AnalysisCode4 = "ADH001";
                      line1.AnalysisCode6 = "XXX";
                      str6 = "M9999";
                    }
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceType"], (object) "Supplier", false))
                    {
                      line1.AnalysisCode5 = str5;
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      line1.Description = !App.IsRFT ? Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"])) : Conversions.ToString(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceAddress"], (object) " "), closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"])));
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      if (closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r.Table.Columns.Contains("SubTaxRate") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["SubTaxRate"])))
                      {
                        Line line4 = (Line) null;
                        Line line5 = (Line) null;
                        line1.JournalType = "PICIS";
                        line2 = (Line) line1.Clone();
                        line3 = (Line) line1.Clone();
                        line2.AccountCode = str6;
                        line3.AccountCode = str1;
                        line4 = (Line) line1.Clone();
                        line5 = (Line) line1.Clone();
                        line4.AccountCode = "B5710";
                        line5.AccountCode = str1;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "23100", false) == 0)
                        {
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          double num = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["SubTaxRate"]));
                          line4.TransactionAmount = -num;
                          line5.TransactionAmount = num;
                        }
                        else
                        {
                          line4.TransactionAmount = 0.0;
                          line5.TransactionAmount = 0.0;
                        }
                        line4.DebitCredit = "C";
                        line5.DebitCredit = "D";
                        line1.DebitCredit = "D";
                        line2.DebitCredit = "D";
                        line3.DebitCredit = "C";
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        line1.TransactionAmount = !App.IsRFT ? Conversions.ToDouble(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])) : Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"], closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])));
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        line2.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"]));
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        line3.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])))));
                        payload.Ledger.Add(line1);
                        payload.Ledger.Add(line2);
                        payload.Ledger.Add(line3);
                        if (line4 != null)
                          payload.Ledger.Add(line4);
                        if (line4 != null)
                          payload.Ledger.Add(line5);
                      }
                      else
                      {
                        line1.JournalType = "PIGAB";
                        line2 = (Line) line1.Clone();
                        line3 = (Line) line1.Clone();
                        line2.AccountCode = str6;
                        line3.AccountCode = str1;
                        line1.DebitCredit = "D";
                        line2.DebitCredit = "D";
                        line3.DebitCredit = "C";
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        line1.TransactionAmount = !App.IsRFT ? Conversions.ToDouble(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])) : Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"], closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])));
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        line2.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"]));
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        line3.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])))));
                        payload.Ledger.Add(line1);
                        payload.Ledger.Add(line2);
                        payload.Ledger.Add(line3);
                      }
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      await App.DB.Invoiced.MarkOrderAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["SupplierInvoiceID"])));
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceType"], (object) "Part Credit", false))
                      {
                        line1.AnalysisCode5 = str5;
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        line1.Description = !App.IsRFT ? Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"])) : Conversions.ToString(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceAddress"], (object) " "), closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"])));
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        if (closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r.Table.Columns.Contains("SubTaxRate") && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["SubTaxRate"])))
                        {
                          Line line4 = (Line) null;
                          Line line5 = (Line) null;
                          line1.JournalType = "PCCIS";
                          line2 = (Line) line1.Clone();
                          line3 = (Line) line1.Clone();
                          line2.AccountCode = str6;
                          line3.AccountCode = str1;
                          line4 = (Line) line1.Clone();
                          line5 = (Line) line1.Clone();
                          line4.AccountCode = "B5710";
                          line5.AccountCode = str1;
                          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "23100", false) == 0)
                          {
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            double num = Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])) * Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["SubTaxRate"]));
                            line4.TransactionAmount = num;
                            line5.TransactionAmount = -num;
                          }
                          else
                          {
                            line4.TransactionAmount = 0.0;
                            line5.TransactionAmount = 0.0;
                          }
                          line5.DebitCredit = "D";
                          line4.DebitCredit = "C";
                          line1.DebitCredit = "C";
                          line2.DebitCredit = "C";
                          line3.DebitCredit = "D";
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line1.TransactionAmount = !App.IsRFT ? Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])))) : Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])))));
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line2.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"]))));
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line3.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"], closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])));
                          payload.Ledger.Add(line1);
                          payload.Ledger.Add(line2);
                          payload.Ledger.Add(line3);
                          if (line4 != null)
                            payload.Ledger.Add(line4);
                          if (line4 != null)
                            payload.Ledger.Add(line5);
                        }
                        else
                        {
                          line1.JournalType = "PCGAB";
                          line2 = (Line) line1.Clone();
                          line3 = (Line) line1.Clone();
                          line2.AccountCode = str6;
                          line3.AccountCode = str1;
                          line1.DebitCredit = "C";
                          line2.DebitCredit = "C";
                          line3.DebitCredit = "D";
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line1.TransactionAmount = !App.IsRFT ? Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])))) : Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])))));
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line2.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"]))));
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line3.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"], closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])));
                          payload.Ledger.Add(line1);
                          payload.Ledger.Add(line2);
                          payload.Ledger.Add(line3);
                        }
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        await App.DB.Invoiced.MarkPartCreditedAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["OrderID"])), Conversions.ToInteger(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["LinkID"])));
                      }
                      else
                      {
                        // ISSUE: reference to a compiler-generated field
                        // ISSUE: reference to a compiler-generated field
                        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceType"], (object) "Consolidation", false))
                        {
                          line1.AnalysisCode5 = str5;
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line1.Description = !App.IsRFT ? Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"])) : Conversions.ToString(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceAddress"], (object) " "), closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"])));
                          line1.JournalType = "PIGAB";
                          line2 = (Line) line1.Clone();
                          line3 = (Line) line1.Clone();
                          line2.AccountCode = str6;
                          line3.AccountCode = str1;
                          line1.DebitCredit = "D";
                          line2.DebitCredit = "D";
                          line3.DebitCredit = "C";
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line1.TransactionAmount = !App.IsRFT ? Conversions.ToDouble(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])) : Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"], closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])));
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line2.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"]));
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          line3.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATAmount"])))));
                          payload.Ledger.Add(line1);
                          payload.Ledger.Add(line2);
                          payload.Ledger.Add(line3);
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          await App.DB.Invoiced.MarkConsolidatedOrderAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["OrderID"])));
                        }
                        else
                        {
                          // ISSUE: reference to a compiler-generated field
                          // ISSUE: reference to a compiler-generated field
                          if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceType"], (object) "Sales Credit", false))
                          {
                            line1.AnalysisCode5 = str5;
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line1.AnalysisCode9 = Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"]));
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line1.Description = Conversions.ToString(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Credit Against Invoice : ", closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoiceNumber"])));
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line1.TransactionReference = Conversions.ToString(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["JobNumber"]));
                            line1.JournalType = "SCGAB";
                            line2 = (Line) line1.Clone();
                            line3 = (Line) line1.Clone();
                            line2.AccountCode = "B5800";
                            line3.AccountCode = str1;
                            line1.DebitCredit = "D";
                            line2.DebitCredit = "D";
                            line3.DebitCredit = "C";
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            Decimal d1 = Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATRATE"]));
                            Decimal d2 = Decimal.Divide(d1, new Decimal(100L));
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["IsOutOfScope"])))
                              d2 = new Decimal();
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line1.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"]));
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line2.TransactionAmount = Convert.ToDouble(Decimal.Multiply(Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), d2));
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line3.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), (object) Decimal.Negate(Decimal.Multiply(Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), d2)))));
                            payload.Ledger.Add(line1);
                            payload.Ledger.Add(line2);
                            payload.Ledger.Add(line3);
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            await App.DB.Invoiced.MarkSalesCreditAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["LinkID"])));
                          }
                          else
                          {
                            line1.AnalysisCode5 = str5;
                            string str3 = "";
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            str3 += Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Address1"])).Trim().Replace(",", "");
                            str3 += " ";
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            str3 += Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Address2"])).Trim().Replace(",", "");
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            str3 = str3 + "- " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["PolicyNumber"])).Trim().Replace(",", "");
                            if (str3.Trim().Length == 0)
                              str3 = "FSM INVOICE";
                            line1.Description = str3;
                            line1.JournalType = "SIGAB";
                            line2 = (Line) line1.Clone();
                            line3 = (Line) line1.Clone();
                            line2.AccountCode = "B5800";
                            line3.AccountCode = str1;
                            line1.DebitCredit = "C";
                            line2.DebitCredit = "C";
                            line3.DebitCredit = "D";
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            Decimal d1 = Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["VATRATE"]));
                            Decimal d2 = Decimal.Divide(d1, new Decimal(100L));
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["IsOutOfScope"])))
                              d2 = new Decimal();
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line1.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.NegateObject(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"]))));
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line2.TransactionAmount = Convert.ToDouble(Decimal.Negate(Decimal.Multiply(Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), d2)));
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            line3.TransactionAmount = Conversions.ToDouble(RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"], (object) Decimal.Multiply(Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["Amount"])), d2))));
                            payload.Ledger.Add(line1);
                            payload.Ledger.Add(line2);
                            payload.Ledger.Add(line3);
                            // ISSUE: reference to a compiler-generated field
                            // ISSUE: reference to a compiler-generated field
                            await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoicedID"])));
                          }
                        }
                      }
                    }
                  }
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(closure3561.\u0024VB\u0024NonLocal_\u0024VB\u0024Closure_2.\u0024VB\u0024Local_r["InvoicedID"])));
                }
              }
              checked { ++index; }
            }
            if (new SSC() { Payload = payload }.SaveToXml())
            {
              int num3 = (int) MessageBox.Show("Export Completed!", "Completion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.PopulateDatagrid();
            this.Cursor = Cursors.Default;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        int num = (int) MessageBox.Show("An Error has occurred: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.Cursor = Cursors.Default;
        ProjectData.ClearProjectError();
      }
    }

    private async void tsmiSageExport_Click(object sender, EventArgs e)
    {
      if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
      {
        string message = "You do not have the necessary security permissions.";
        throw new SecurityException(message);
      }
      try
      {
        this.Cursor = Cursors.WaitCursor;
        DataTable table = new DataTable();
        table.Columns.Add("Type");
        table.Columns.Add("AccountNumber");
        table.Columns.Add("NominalCode");
        table.Columns.Add("DepartmentCode");
        table.Columns.Add("RaisedDate");
        table.Columns.Add("InvoiceNumber");
        table.Columns.Add("Description");
        table.Columns.Add("Amount");
        table.Columns.Add("VATCode");
        table.Columns.Add("VATAmount");
        table.Columns.Add("ExchangeRate");
        table.Columns.Add("ExtraRef");
        DateTime t2 = new DateTime(Conversions.ToDate(this.txtSageMonth.Text).Year, Conversions.ToDate(this.txtSageMonth.Text).Month, 1);
        if (this.InvoicesDataview != null)
        {
          IEnumerator enumerator;
          try
          {
            enumerator = this.InvoicesDataview.Table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              if (!Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(current["ExportedToSage"])))
              {
                if (Conversions.ToDouble(RuntimeHelpers.GetObjectValue(current["Amount"])) > 0.0)
                {
                  if (Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(current["tick"])))
                  {
                    string Left = string.Empty;
                    string Left1 = current["InvoiceType"].ToString();
                    Left = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Supplier", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Part Credit", false) == 0 || Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left1, "Consolidation", false) == 0 ? "Supplier" : "Customer";
                    bool flag = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Supplier", false) == 0;
                    if (DateTime.Compare(Conversions.ToDate(Microsoft.VisualBasic.Strings.Format(RuntimeHelpers.GetObjectValue(current["Raiseddate"]), "dd/MM/yyyy")), t2) < 0 & !flag)
                    {
                      int num = (int) App.ShowMessage("A invoice has been stopped in the export as it is for a diffent month to the current processing month.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                      DataRow row = table.NewRow();
                      row["AccountNumber"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["AccountNumber"]));
                      row["NominalCode"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["NominalCode"]));
                      row["DepartmentCode"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["Department"]));
                      row["RaisedDate"] = (object) Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDate(RuntimeHelpers.GetObjectValue(current["RaisedDate"])), "dd/MM/yyyy");
                      row["InvoiceNumber"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["InvoiceNumber"]));
                      row["Amount"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["Amount"]));
                      row["ExchangeRate"] = (object) 1;
                      if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Supplier", false))
                      {
                        row["VatAmount"] = (object) Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(current["VATAmount"])), "f");
                        row["Type"] = (object) "PI";
                        row["Description"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["JobNumber"]));
                        row["VATCode"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["Tax_Code"]));
                        row["ExtraRef"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["ExtraRef"]));
                        await App.DB.Invoiced.MarkOrderAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["SupplierInvoiceID"])));
                      }
                      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Part Credit", false))
                      {
                        row["VatAmount"] = (object) Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(current["VATAmount"])), "f");
                        row["Type"] = (object) "PC";
                        row["Description"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["JobNumber"]));
                        row["VATCode"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["Tax_Code"]));
                        row["ExtraRef"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["ExtraRef"]));
                        row["InvoiceNumber"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["SupplierCreditRef"]));
                        await App.DB.Invoiced.MarkPartCreditedAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["OrderID"])), Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["LinkID"])));
                      }
                      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Consolidation", false))
                      {
                        row["VatAmount"] = (object) Microsoft.VisualBasic.Strings.Format((object) Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(current["VATAmount"])), "f");
                        row["Type"] = (object) "PI";
                        row["Description"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["JobNumber"]));
                        row["VATCode"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["Tax_Code"]));
                        row["ExtraRef"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["ExtraRef"]));
                        await App.DB.Invoiced.MarkConsolidatedOrderAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["OrderID"])));
                      }
                      else if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["InvoiceType"], (object) "Sales Credit", false))
                      {
                        Decimal d1 = Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(current["VATRATE"]));
                        Decimal d2 = Decimal.Divide(d1, new Decimal(100L));
                        row["VatAmount"] = (object) Microsoft.VisualBasic.Strings.Format((object) Decimal.Multiply(Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(current["Amount"])), d2), "f");
                        row["Type"] = (object) "SC";
                        row["Description"] = RuntimeHelpers.GetObjectValue(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Credit Against Invoice : ", current["JobNumber"]));
                        row["VATCode"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["Tax_Code"]));
                        row["ExtraRef"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["ExtraRef"]));
                        row["InvoiceNumber"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["SupplierCreditRef"]));
                        await App.DB.Invoiced.MarkSalesCreditAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["LinkID"])));
                      }
                      else
                      {
                        Decimal d1 = Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(current["VATRATE"]));
                        Decimal d2 = Decimal.Divide(d1, new Decimal(100L));
                        row["VatAmount"] = (object) Microsoft.VisualBasic.Strings.Format((object) Decimal.Multiply(Conversions.ToDecimal(RuntimeHelpers.GetObjectValue(current["Amount"])), d2), "f");
                        string str = "";
                        str += Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address1"])).Trim().Replace(",", "");
                        str += " ";
                        str += Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["Address2"])).Trim().Replace(",", "");
                        str = str + "- " + Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(current["PolicyNumber"])).Trim().Replace(",", "");
                        if (str.Trim().Length == 0)
                          str = "FSM INVOICE";
                        row["Type"] = (object) "SI";
                        row["Description"] = (object) str;
                        row["VATCode"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["Tax_Code"]));
                        row["ExtraRef"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(current["JobNumber"]));
                        await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["InvoicedID"])));
                      }
                      table.Rows.Add(row);
                    }
                  }
                }
                else
                  await App.DB.Invoiced.MarkInvoiceAsExportedAsync(Conversions.ToInteger(RuntimeHelpers.GetObjectValue(current["InvoicedID"])));
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          if (table.Rows.Count > 0)
          {
            CSVExporter csvExporter = new CSVExporter();
            csvExporter.CreateCSV(new DataView(table));
            int num = (int) MessageBox.Show("Export complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
          }
          else
          {
            int num1 = (int) MessageBox.Show("Please select invoices to export.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
          }
        }
        this.PopulateDatagrid();
        this.Cursor = Cursors.Default;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        int num = (int) MessageBox.Show("An Error has occurred: " + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.Cursor = Cursors.Default;
        ProjectData.ClearProjectError();
      }
    }

    private void chkExportedOn_Click(object sender, EventArgs e)
    {
      this.chkExportedOn.Checked = !this.chkExportedOn.Checked;
      this.dtpExportedOn.Enabled = this.chkExportedOn.Checked;
    }
  }
}
