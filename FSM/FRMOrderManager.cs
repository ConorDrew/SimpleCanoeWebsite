// Decompiled with JetBrains decompiler
// Type: FSM.FRMOrderManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Jobs;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.Entity.Vans;
using FSM.Entity.Warehouses;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMOrderManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _dvOrders;
    private FSM.Entity.Sites.Site _oSite;
    private Van _oVan;
    private Warehouse _oWarehouse;
    private Job _oJob;

    public FRMOrderManager()
    {
      this.Load += new EventHandler(this.FRMOrderManager_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo
    {
      get
      {
        return this._dtpTo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpTo_ValueChanged);
        DateTimePicker dtpTo1 = this._dtpTo;
        if (dtpTo1 != null)
          dtpTo1.ValueChanged -= eventHandler;
        this._dtpTo = value;
        DateTimePicker dtpTo2 = this._dtpTo;
        if (dtpTo2 == null)
          return;
        dtpTo2.ValueChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpFrom
    {
      get
      {
        return this._dtpFrom;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFrom_ValueChanged);
        DateTimePicker dtpFrom1 = this._dtpFrom;
        if (dtpFrom1 != null)
          dtpFrom1.ValueChanged -= eventHandler;
        this._dtpFrom = value;
        DateTimePicker dtpFrom2 = this._dtpFrom;
        if (dtpFrom2 == null)
          return;
        dtpFrom2.ValueChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboStatus
    {
      get
      {
        return this._cboStatus;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboStatus_SelectedIndexChanged);
        ComboBox cboStatus1 = this._cboStatus;
        if (cboStatus1 != null)
          cboStatus1.SelectedIndexChanged -= eventHandler;
        this._cboStatus = value;
        ComboBox cboStatus2 = this._cboStatus;
        if (cboStatus2 == null)
          return;
        cboStatus2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType
    {
      get
      {
        return this._cboType;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboType_SelectedIndexChanged);
        ComboBox cboType1 = this._cboType;
        if (cboType1 != null)
          cboType1.SelectedIndexChanged -= eventHandler;
        this._cboType = value;
        ComboBox cboType2 = this._cboType;
        if (cboType2 == null)
          return;
        cboType2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDateCreated
    {
      get
      {
        return this._chkDateCreated;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkDateCreated_CheckedChanged);
        CheckBox chkDateCreated1 = this._chkDateCreated;
        if (chkDateCreated1 != null)
          chkDateCreated1.CheckedChanged -= eventHandler;
        this._chkDateCreated = value;
        CheckBox chkDateCreated2 = this._chkDateCreated;
        if (chkDateCreated2 == null)
          return;
        chkDateCreated2.CheckedChanged += eventHandler;
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

    internal virtual DataGrid dgOrders
    {
      get
      {
        return this._dgOrders;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgOrders_DoubleClick);
        DataGrid dgOrders1 = this._dgOrders;
        if (dgOrders1 != null)
          dgOrders1.DoubleClick -= eventHandler;
        this._dgOrders = value;
        DataGrid dgOrders2 = this._dgOrders;
        if (dgOrders2 == null)
          return;
        dgOrders2.DoubleClick += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOrderRef
    {
      get
      {
        return this._txtOrderRef;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        KeyEventHandler keyEventHandler = new KeyEventHandler(this.txtOrderRef_TextChanged);
        TextBox txtOrderRef1 = this._txtOrderRef;
        if (txtOrderRef1 != null)
          txtOrderRef1.KeyDown -= keyEventHandler;
        this._txtOrderRef = value;
        TextBox txtOrderRef2 = this._txtOrderRef;
        if (txtOrderRef2 == null)
          return;
        txtOrderRef2.KeyDown += keyEventHandler;
      }
    }

    internal virtual Label lblSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindRecord
    {
      get
      {
        return this._btnFindRecord;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindRecord_Click);
        Button btnFindRecord1 = this._btnFindRecord;
        if (btnFindRecord1 != null)
          btnFindRecord1.Click -= eventHandler;
        this._btnFindRecord = value;
        Button btnFindRecord2 = this._btnFindRecord;
        if (btnFindRecord2 == null)
          return;
        btnFindRecord2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDeliveryDeadlineTo
    {
      get
      {
        return this._dtpDeliveryDeadlineTo;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpDeliveryDeadlineTo_ValueChanged);
        DateTimePicker deliveryDeadlineTo1 = this._dtpDeliveryDeadlineTo;
        if (deliveryDeadlineTo1 != null)
          deliveryDeadlineTo1.ValueChanged -= eventHandler;
        this._dtpDeliveryDeadlineTo = value;
        DateTimePicker deliveryDeadlineTo2 = this._dtpDeliveryDeadlineTo;
        if (deliveryDeadlineTo2 == null)
          return;
        deliveryDeadlineTo2.ValueChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpDeliveryDeadlineFrom
    {
      get
      {
        return this._dtpDeliveryDeadlineFrom;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpDeliveryDeadlineFrom_ValueChanged);
        DateTimePicker deliveryDeadlineFrom1 = this._dtpDeliveryDeadlineFrom;
        if (deliveryDeadlineFrom1 != null)
          deliveryDeadlineFrom1.ValueChanged -= eventHandler;
        this._dtpDeliveryDeadlineFrom = value;
        DateTimePicker deliveryDeadlineFrom2 = this._dtpDeliveryDeadlineFrom;
        if (deliveryDeadlineFrom2 == null)
          return;
        deliveryDeadlineFrom2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDeliveryDeadline
    {
      get
      {
        return this._chkDeliveryDeadline;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkDeliveryDeadline_CheckedChanged);
        CheckBox deliveryDeadline1 = this._chkDeliveryDeadline;
        if (deliveryDeadline1 != null)
          deliveryDeadline1.CheckedChanged -= eventHandler;
        this._chkDeliveryDeadline = value;
        CheckBox deliveryDeadline2 = this._chkDeliveryDeadline;
        if (deliveryDeadline2 == null)
          return;
        deliveryDeadline2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSupplierInvoiceSent
    {
      get
      {
        return this._cboSupplierInvoiceSent;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboSupplierInvoiceSent_SelectedIndexChanged);
        ComboBox supplierInvoiceSent1 = this._cboSupplierInvoiceSent;
        if (supplierInvoiceSent1 != null)
          supplierInvoiceSent1.SelectedIndexChanged -= eventHandler;
        this._cboSupplierInvoiceSent = value;
        ComboBox supplierInvoiceSent2 = this._cboSupplierInvoiceSent;
        if (supplierInvoiceSent2 == null)
          return;
        supplierInvoiceSent2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual TextBox txtConsolidationRef
    {
      get
      {
        return this._txtConsolidationRef;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtConsolidationRef_TextChanged);
        TextBox consolidationRef1 = this._txtConsolidationRef;
        if (consolidationRef1 != null)
          consolidationRef1.TextChanged -= eventHandler;
        this._txtConsolidationRef = value;
        TextBox consolidationRef2 = this._txtConsolidationRef;
        if (consolidationRef2 == null)
          return;
        consolidationRef2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContains
    {
      get
      {
        return this._txtContains;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtContains_TextChanged);
        TextBox txtContains1 = this._txtContains;
        if (txtContains1 != null)
          txtContains1.TextChanged -= eventHandler;
        this._txtContains = value;
        TextBox txtContains2 = this._txtContains;
        if (txtContains2 == null)
          return;
        txtContains2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkEngineerNotReceived
    {
      get
      {
        return this._chkEngineerNotReceived;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkEngineerNotReceived_CheckedChanged);
        CheckBox engineerNotReceived1 = this._chkEngineerNotReceived;
        if (engineerNotReceived1 != null)
          engineerNotReceived1.CheckedChanged -= eventHandler;
        this._chkEngineerNotReceived = value;
        CheckBox engineerNotReceived2 = this._chkEngineerNotReceived;
        if (engineerNotReceived2 == null)
          return;
        engineerNotReceived2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Button btnFilterResults
    {
      get
      {
        return this._btnFilterResults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFilterResults_Click);
        Button btnFilterResults1 = this._btnFilterResults;
        if (btnFilterResults1 != null)
          btnFilterResults1.Click -= eventHandler;
        this._btnFilterResults = value;
        Button btnFilterResults2 = this._btnFilterResults;
        if (btnFilterResults2 == null)
          return;
        btnFilterResults2.Click += eventHandler;
      }
    }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDepartment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkOutstanding
    {
      get
      {
        return this._chkOutstanding;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkOutstanding_CheckedChanged);
        CheckBox chkOutstanding1 = this._chkOutstanding;
        if (chkOutstanding1 != null)
          chkOutstanding1.CheckedChanged -= eventHandler;
        this._chkOutstanding = value;
        CheckBox chkOutstanding2 = this._chkOutstanding;
        if (chkOutstanding2 == null)
          return;
        chkOutstanding2.CheckedChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboSupplier
    {
      get
      {
        return this._cboSupplier;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboSupplier_SelectedIndexChanged);
        ComboBox cboSupplier1 = this._cboSupplier;
        if (cboSupplier1 != null)
          cboSupplier1.SelectedIndexChanged -= eventHandler;
        this._cboSupplier = value;
        ComboBox cboSupplier2 = this._cboSupplier;
        if (cboSupplier2 == null)
          return;
        cboSupplier2.SelectedIndexChanged += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpJobs = new GroupBox();
      this.dgOrders = new DataGrid();
      this.btnExport = new Button();
      this.grpFilter = new GroupBox();
      this.chkOutstanding = new CheckBox();
      this.Label12 = new Label();
      this.cboDepartment = new ComboBox();
      this.btnFilterResults = new Button();
      this.chkEngineerNotReceived = new CheckBox();
      this.txtContains = new TextBox();
      this.Label7 = new Label();
      this.txtConsolidationRef = new TextBox();
      this.Label6 = new Label();
      this.Label5 = new Label();
      this.cboSupplierInvoiceSent = new ComboBox();
      this.dtpDeliveryDeadlineTo = new DateTimePicker();
      this.dtpDeliveryDeadlineFrom = new DateTimePicker();
      this.Label2 = new Label();
      this.Label3 = new Label();
      this.cboSupplier = new ComboBox();
      this.Label1 = new Label();
      this.btnFindRecord = new Button();
      this.txtSearch = new TextBox();
      this.Label4 = new Label();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.txtOrderRef = new TextBox();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.chkDateCreated = new CheckBox();
      this.lblSearch = new Label();
      this.Label10 = new Label();
      this.cboType = new ComboBox();
      this.Label11 = new Label();
      this.cboStatus = new ComboBox();
      this.chkDeliveryDeadline = new CheckBox();
      this.btnReset = new Button();
      this.grpJobs.SuspendLayout();
      this.dgOrders.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.dgOrders);
      this.grpJobs.Location = new System.Drawing.Point(8, 321);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(1360, 260);
      this.grpJobs.TabIndex = 1;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Results (awaiting search) - Double Click To View / Edit";
      this.dgOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgOrders.DataMember = "";
      this.dgOrders.HeaderForeColor = SystemColors.ControlText;
      this.dgOrders.Location = new System.Drawing.Point(8, 30);
      this.dgOrders.Name = "dgOrders";
      this.dgOrders.Size = new Size(1344, 222);
      this.dgOrders.TabIndex = 11;
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 589);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 2;
      this.btnExport.Text = "Export";
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.chkOutstanding);
      this.grpFilter.Controls.Add((Control) this.Label12);
      this.grpFilter.Controls.Add((Control) this.cboDepartment);
      this.grpFilter.Controls.Add((Control) this.btnFilterResults);
      this.grpFilter.Controls.Add((Control) this.chkEngineerNotReceived);
      this.grpFilter.Controls.Add((Control) this.txtContains);
      this.grpFilter.Controls.Add((Control) this.Label7);
      this.grpFilter.Controls.Add((Control) this.txtConsolidationRef);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Controls.Add((Control) this.Label5);
      this.grpFilter.Controls.Add((Control) this.cboSupplierInvoiceSent);
      this.grpFilter.Controls.Add((Control) this.dtpDeliveryDeadlineTo);
      this.grpFilter.Controls.Add((Control) this.dtpDeliveryDeadlineFrom);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.Label3);
      this.grpFilter.Controls.Add((Control) this.cboSupplier);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.btnFindRecord);
      this.grpFilter.Controls.Add((Control) this.txtSearch);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.txtOrderRef);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.Label8);
      this.grpFilter.Controls.Add((Control) this.chkDateCreated);
      this.grpFilter.Controls.Add((Control) this.lblSearch);
      this.grpFilter.Controls.Add((Control) this.Label10);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Controls.Add((Control) this.Label11);
      this.grpFilter.Controls.Add((Control) this.cboStatus);
      this.grpFilter.Controls.Add((Control) this.chkDeliveryDeadline);
      this.grpFilter.Location = new System.Drawing.Point(8, 40);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(1360, 275);
      this.grpFilter.TabIndex = 0;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.chkOutstanding.Cursor = Cursors.Hand;
      this.chkOutstanding.Location = new System.Drawing.Point(420, 122);
      this.chkOutstanding.Name = "chkOutstanding";
      this.chkOutstanding.Size = new Size(221, 24);
      this.chkOutstanding.TabIndex = 34;
      this.chkOutstanding.Text = "PO not reconciled (outstanding)";
      this.chkOutstanding.UseVisualStyleBackColor = true;
      this.Label12.Location = new System.Drawing.Point(13, 249);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(117, 20);
      this.Label12.TabIndex = 33;
      this.Label12.Text = "Cost Centre";
      this.cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDepartment.Location = new System.Drawing.Point(136, 247);
      this.cboDepartment.Name = "cboDepartment";
      this.cboDepartment.Size = new Size(142, 21);
      this.cboDepartment.TabIndex = 32;
      this.btnFilterResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFilterResults.Location = new System.Drawing.Point(1243, 244);
      this.btnFilterResults.Name = "btnFilterResults";
      this.btnFilterResults.Size = new Size(109, 23);
      this.btnFilterResults.TabIndex = 31;
      this.btnFilterResults.Text = "Filter Results";
      this.btnFilterResults.UseVisualStyleBackColor = true;
      this.chkEngineerNotReceived.Cursor = Cursors.Hand;
      this.chkEngineerNotReceived.Location = new System.Drawing.Point(289, 123);
      this.chkEngineerNotReceived.Name = "chkEngineerNotReceived";
      this.chkEngineerNotReceived.Size = new Size(141, 24);
      this.chkEngineerNotReceived.TabIndex = 7;
      this.chkEngineerNotReceived.Text = "Eng Not Received";
      this.chkEngineerNotReceived.UseVisualStyleBackColor = true;
      this.txtContains.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtContains.Location = new System.Drawing.Point(624, 92);
      this.txtContains.MaxLength = 100;
      this.txtContains.Name = "txtContains";
      this.txtContains.Size = new Size(727, 21);
      this.txtContains.TabIndex = 5;
      this.Label7.Location = new System.Drawing.Point(523, 92);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(118, 23);
      this.Label7.TabIndex = 30;
      this.Label7.Text = "Order Contains";
      this.txtConsolidationRef.Location = new System.Drawing.Point(395, 92);
      this.txtConsolidationRef.Name = "txtConsolidationRef";
      this.txtConsolidationRef.Size = new Size(122, 21);
      this.txtConsolidationRef.TabIndex = 4;
      this.Label6.Location = new System.Drawing.Point(284, 95);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(124, 20);
      this.Label6.TabIndex = 28;
      this.Label6.Text = "Consolidation Ref";
      this.Label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.Label5.Location = new System.Drawing.Point(974, 123);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(266, 23);
      this.Label5.TabIndex = 27;
      this.Label5.Text = "Supplier Invoice Sent to Accounts Package";
      this.cboSupplierInvoiceSent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSupplierInvoiceSent.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSupplierInvoiceSent.Location = new System.Drawing.Point(1242, 121);
      this.cboSupplierInvoiceSent.Name = "cboSupplierInvoiceSent";
      this.cboSupplierInvoiceSent.Size = new Size(110, 21);
      this.cboSupplierInvoiceSent.TabIndex = 8;
      this.dtpDeliveryDeadlineTo.Location = new System.Drawing.Point(596, 216);
      this.dtpDeliveryDeadlineTo.Name = "dtpDeliveryDeadlineTo";
      this.dtpDeliveryDeadlineTo.Size = new Size(224, 21);
      this.dtpDeliveryDeadlineTo.TabIndex = 15;
      this.dtpDeliveryDeadlineFrom.Location = new System.Drawing.Point(596, 184);
      this.dtpDeliveryDeadlineFrom.Name = "dtpDeliveryDeadlineFrom";
      this.dtpDeliveryDeadlineFrom.Size = new Size(224, 21);
      this.dtpDeliveryDeadlineFrom.TabIndex = 14;
      this.Label2.Location = new System.Drawing.Point(548, 216);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(48, 16);
      this.Label2.TabIndex = 24;
      this.Label2.Text = "To";
      this.Label3.Location = new System.Drawing.Point(548, 184);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(48, 16);
      this.Label3.TabIndex = 21;
      this.Label3.Text = "From";
      this.cboSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSupplier.Location = new System.Drawing.Point(136, 152);
      this.cboSupplier.Name = "cboSupplier";
      this.cboSupplier.Size = new Size(1216, 21);
      this.cboSupplier.TabIndex = 9;
      this.Label1.Location = new System.Drawing.Point(16, 152);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 23);
      this.Label1.TabIndex = 18;
      this.Label1.Text = "Supplier";
      this.btnFindRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindRecord.BackColor = Color.White;
      this.btnFindRecord.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindRecord.Location = new System.Drawing.Point(1320, 58);
      this.btnFindRecord.Name = "btnFindRecord";
      this.btnFindRecord.Size = new Size(32, 23);
      this.btnFindRecord.TabIndex = 2;
      this.btnFindRecord.Text = "...";
      this.btnFindRecord.UseVisualStyleBackColor = false;
      this.txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSearch.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSearch.Location = new System.Drawing.Point(136, 60);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.ReadOnly = true;
      this.txtSearch.Size = new Size(1176, 21);
      this.txtSearch.TabIndex = 1;
      this.Label4.Location = new System.Drawing.Point(16, 89);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(72, 20);
      this.Label4.TabIndex = 15;
      this.Label4.Text = "Order Ref";
      this.dtpTo.Location = new System.Drawing.Point(183, 216);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(224, 21);
      this.dtpTo.TabIndex = 12;
      this.dtpFrom.Location = new System.Drawing.Point(183, 184);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(224, 21);
      this.dtpFrom.TabIndex = 11;
      this.txtOrderRef.Location = new System.Drawing.Point(136, 92);
      this.txtOrderRef.Name = "txtOrderRef";
      this.txtOrderRef.Size = new Size(142, 21);
      this.txtOrderRef.TabIndex = 3;
      this.Label9.Location = new System.Drawing.Point(135, 216);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "To";
      this.Label8.Location = new System.Drawing.Point(135, 184);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(48, 16);
      this.Label8.TabIndex = 9;
      this.Label8.Text = "From";
      this.chkDateCreated.Cursor = Cursors.Hand;
      this.chkDateCreated.Location = new System.Drawing.Point(16, 184);
      this.chkDateCreated.Name = "chkDateCreated";
      this.chkDateCreated.Size = new Size(104, 24);
      this.chkDateCreated.TabIndex = 10;
      this.chkDateCreated.Text = "Date Placed";
      this.chkDateCreated.UseVisualStyleBackColor = true;
      this.lblSearch.Location = new System.Drawing.Point(16, 56);
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new Size(112, 20);
      this.lblSearch.TabIndex = 2;
      this.Label10.Location = new System.Drawing.Point(16, 32);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(48, 20);
      this.Label10.TabIndex = 4;
      this.Label10.Text = "Type";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(136, 29);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(1216, 21);
      this.cboType.TabIndex = 0;
      this.Label11.Location = new System.Drawing.Point(16, 121);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(48, 20);
      this.Label11.TabIndex = 5;
      this.Label11.Text = "Status";
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(136, 124);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(142, 21);
      this.cboStatus.TabIndex = 6;
      this.chkDeliveryDeadline.Cursor = Cursors.Hand;
      this.chkDeliveryDeadline.Location = new System.Drawing.Point(420, 184);
      this.chkDeliveryDeadline.Name = "chkDeliveryDeadline";
      this.chkDeliveryDeadline.Size = new Size(132, 24);
      this.chkDeliveryDeadline.TabIndex = 13;
      this.chkDeliveryDeadline.Text = "Delivery Deadline";
      this.chkDeliveryDeadline.UseVisualStyleBackColor = true;
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 589);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 3;
      this.btnReset.Text = "Reset";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1376, 619);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpJobs);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(852, 592);
      this.Name = nameof (FRMOrderManager);
      this.Text = "Order Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpJobs, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.grpJobs.ResumeLayout(false);
      this.dgOrders.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupOrdersDataGrid();
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, DynamicDataTables.OrderTypeForSearch, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, App.DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name", Enums.ComboValues.No_Filter);
      this.cboStatus = cboStatus;
      ComboBox supplierInvoiceSent = this.cboSupplierInvoiceSent;
      Combo.SetUpCombo(ref supplierInvoiceSent, DynamicDataTables.Yes_No, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboSupplierInvoiceSent = supplierInvoiceSent;
      ComboBox cboSupplier = this.cboSupplier;
      Combo.SetUpCombo(ref cboSupplier, App.DB.Supplier.Supplier_GetAll().Table, "SupplierID", "Name", Enums.ComboValues.No_Filter);
      this.cboSupplier = cboSupplier;
      if (true == App.IsGasway)
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      else
      {
        ComboBox cboDepartment = this.cboDepartment;
        Combo.SetUpCombo(ref cboDepartment, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboDepartment = cboDepartment;
      }
      this.ResetFilters();
      if (this.get_GetParameter(0) == null)
        return;
      this.PopulateDatagrid();
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

    private DataView OrdersDataview
    {
      get
      {
        return this._dvOrders;
      }
      set
      {
        this._dvOrders = value;
        this._dvOrders.AllowNew = false;
        this._dvOrders.AllowEdit = false;
        this._dvOrders.AllowDelete = false;
        this._dvOrders.Table.TableName = Enums.TableNames.tblOrder.ToString();
        this.dgOrders.DataSource = (object) this.OrdersDataview;
      }
    }

    private DataRow SelectedOrderDataRow
    {
      get
      {
        return this.dgOrders.CurrentRowIndex != -1 ? this.OrdersDataview[this.dgOrders.CurrentRowIndex].Row : (DataRow) null;
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
          this.txtSearch.Text = this.theSite.Address1 + ", " + this.theSite.Address2 + ", " + this.theSite.Postcode;
        else
          this.txtSearch.Text = "";
      }
    }

    public Van Van
    {
      get
      {
        return this._oVan;
      }
      set
      {
        this._oVan = value;
        if (this._oVan != null)
          this.txtSearch.Text = this._oVan.Registration;
        else
          this.txtSearch.Text = "";
      }
    }

    public Warehouse Warehouse
    {
      get
      {
        return this._oWarehouse;
      }
      set
      {
        this._oWarehouse = value;
        if (this._oWarehouse != null)
          this.txtSearch.Text = this._oWarehouse.Name + " (" + this._oWarehouse.Address1 + ", " + this._oWarehouse.Postcode + ")";
        else
          this.txtSearch.Text = "";
      }
    }

    public Job Job
    {
      get
      {
        return this._oJob;
      }
      set
      {
        this._oJob = value;
        if (this._oJob != null)
          this.txtSearch.Text = this._oJob.JobNumber;
        else
          this.txtSearch.Text = "";
      }
    }

    private void SetupOrdersDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgOrders.TableStyles[0];
      FRMOrderManager.PartsNotReceivedColourColumn receivedColourColumn = new FRMOrderManager.PartsNotReceivedColourColumn();
      receivedColourColumn.Format = "";
      receivedColourColumn.FormatInfo = (IFormatProvider) null;
      receivedColourColumn.HeaderText = "";
      receivedColourColumn.MappingName = "PartsNotReceived";
      receivedColourColumn.ReadOnly = true;
      receivedColourColumn.Width = 25;
      receivedColourColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) receivedColourColumn);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MMM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Date Placed";
      dataGridLabelColumn1.MappingName = "DatePlaced";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 90;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "dd/MMM/yyyy";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Delivery Deadline";
      dataGridLabelColumn2.MappingName = "DeliveryDeadline";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 90;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Order Reference";
      dataGridLabelColumn3.MappingName = "OrderReference";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 110;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Consol Ref";
      dataGridLabelColumn4.MappingName = "ConsolidationRef";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 110;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Type";
      dataGridLabelColumn5.MappingName = "Type";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 75;
      dataGridLabelColumn5.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Customer";
      dataGridLabelColumn6.MappingName = "Customer";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 140;
      dataGridLabelColumn6.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Property";
      dataGridLabelColumn7.MappingName = "Site";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 140;
      dataGridLabelColumn7.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Supplier";
      dataGridLabelColumn8.MappingName = "Supplier";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Van";
      dataGridLabelColumn9.MappingName = "Registration";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 90;
      dataGridLabelColumn9.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Warehouse";
      dataGridLabelColumn10.MappingName = "Warehouse";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 100;
      dataGridLabelColumn10.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "Job Number";
      dataGridLabelColumn11.MappingName = "JobNumber";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 100;
      dataGridLabelColumn11.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Status";
      dataGridLabelColumn12.MappingName = "DisplayStatus";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 120;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Sup Inv Sent to Sage";
      dataGridLabelColumn13.MappingName = "SupplierExported";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 50;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      DataGridLabelColumn dataGridLabelColumn14 = new DataGridLabelColumn();
      dataGridLabelColumn14.Format = "C";
      dataGridLabelColumn14.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn14.HeaderText = "Cost";
      dataGridLabelColumn14.MappingName = "BuyPrice";
      dataGridLabelColumn14.ReadOnly = true;
      dataGridLabelColumn14.Width = 75;
      dataGridLabelColumn14.NullText = "0";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn14);
      DataGridLabelColumn dataGridLabelColumn15 = new DataGridLabelColumn();
      dataGridLabelColumn15.Format = "C";
      dataGridLabelColumn15.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn15.HeaderText = "SI Amount";
      dataGridLabelColumn15.MappingName = "SupplierInvoiceAmount";
      dataGridLabelColumn15.ReadOnly = true;
      dataGridLabelColumn15.Width = 75;
      dataGridLabelColumn15.NullText = "£0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn15);
      DataGridLabelColumn dataGridLabelColumn16 = new DataGridLabelColumn();
      dataGridLabelColumn16.Format = "C";
      dataGridLabelColumn16.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn16.HeaderText = "Credited Amount";
      dataGridLabelColumn16.MappingName = "CreditAmount";
      dataGridLabelColumn16.ReadOnly = true;
      dataGridLabelColumn16.Width = 75;
      dataGridLabelColumn16.NullText = "£0.00";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn16);
      DataGridLabelColumn dataGridLabelColumn17 = new DataGridLabelColumn();
      dataGridLabelColumn17.Format = "";
      dataGridLabelColumn17.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn17.HeaderText = "Created By";
      dataGridLabelColumn17.MappingName = "CreatedBy";
      dataGridLabelColumn17.ReadOnly = true;
      dataGridLabelColumn17.Width = 100;
      dataGridLabelColumn17.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn17);
      DataGridLabelColumn dataGridLabelColumn18 = new DataGridLabelColumn();
      dataGridLabelColumn18.Format = "";
      dataGridLabelColumn18.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn18.HeaderText = "Dept";
      dataGridLabelColumn18.MappingName = "DepartmentRef";
      dataGridLabelColumn18.ReadOnly = true;
      dataGridLabelColumn18.Width = 100;
      dataGridLabelColumn18.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn18);
      this.dgOrders.ReadOnly = true;
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblOrder.ToString();
      this.dgOrders.TableStyles.Add(tableStyle);
    }

    private void FRMOrderManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void chkDateCreated_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkDateCreated.Checked)
      {
        this.dtpFrom.Enabled = true;
        this.dtpTo.Enabled = true;
      }
      else
      {
        this.dtpFrom.Value = DateAndTime.Today;
        this.dtpTo.Value = DateAndTime.Today;
        this.dtpFrom.Enabled = false;
        this.dtpTo.Enabled = false;
      }
    }

    private void chkDeliveryDeadline_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkDeliveryDeadline.Checked)
      {
        this.dtpDeliveryDeadlineFrom.Enabled = true;
        this.dtpDeliveryDeadlineTo.Enabled = true;
      }
      else
      {
        this.dtpDeliveryDeadlineFrom.Value = DateAndTime.Today;
        this.dtpDeliveryDeadlineTo.Value = DateAndTime.Today;
        this.dtpDeliveryDeadlineFrom.Enabled = false;
        this.dtpDeliveryDeadlineTo.Enabled = false;
      }
    }

    private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void cboVan_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void cboType_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.theSite = (FSM.Entity.Sites.Site) null;
      this.Van = (Van) null;
      this.Job = (Job) null;
      this.Warehouse = (Warehouse) null;
      string Left = Combo.get_GetSelectedItemValue(this.cboType);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0)
      {
        this.lblSearch.Text = "Select Type";
        this.txtSearch.Text = "";
        this.btnFindRecord.Enabled = false;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
      {
        this.lblSearch.Text = "Select Property";
        this.txtSearch.Text = "";
        this.btnFindRecord.Enabled = true;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        this.lblSearch.Text = "Select Warehouse";
        this.txtSearch.Text = "";
        this.btnFindRecord.Enabled = true;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        this.lblSearch.Text = "Select Van";
        this.txtSearch.Text = "";
        this.btnFindRecord.Enabled = true;
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
      {
        this.lblSearch.Text = "Select Warehouse";
        this.txtSearch.Text = "";
        this.btnFindRecord.Enabled = true;
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) != 0)
          return;
        this.lblSearch.Text = "Select Job";
        this.txtSearch.Text = "";
        this.btnFindRecord.Enabled = true;
      }
    }

    private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void chkEngineerNotReceived_CheckedChanged(object sender, EventArgs e)
    {
      this.RunFilter();
    }

    private void cboSupplierInvoiceSent_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void txtOrderRef_TextChanged(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.Query();
    }

    private void txtConsolidationRef_TextChanged(object sender, EventArgs e)
    {
    }

    private void dtpFrom_ValueChanged(object sender, EventArgs e)
    {
    }

    private void dtpTo_ValueChanged(object sender, EventArgs e)
    {
    }

    private void dtpDeliveryDeadlineFrom_ValueChanged(object sender, EventArgs e)
    {
    }

    private void dtpDeliveryDeadlineTo_ValueChanged(object sender, EventArgs e)
    {
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void txtContains_TextChanged(object sender, EventArgs e)
    {
    }

    private void dgOrders_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedOrderDataRow == null)
      {
        int num = (int) App.ShowMessage("Please select an order to view", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        switch (Conversions.ToInteger(this.SelectedOrderDataRow["OrderTypeID"]))
        {
          case 1:
            App.ShowForm(typeof (FRMOrder), false, new object[4]
            {
              this.SelectedOrderDataRow["OrderID"],
              (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedOrderDataRow["SiteID"])),
              (object) 0,
              (object) this
            }, false);
            break;
          case 2:
            App.ShowForm(typeof (FRMOrder), false, new object[4]
            {
              this.SelectedOrderDataRow["OrderID"],
              this.SelectedOrderDataRow["VanID"],
              (object) 0,
              (object) this
            }, false);
            break;
          case 3:
            App.ShowForm(typeof (FRMOrder), false, new object[4]
            {
              this.SelectedOrderDataRow["OrderID"],
              this.SelectedOrderDataRow["WarehouseID"],
              (object) 0,
              (object) this
            }, false);
            break;
          case 4:
            App.ShowForm(typeof (FRMOrder), false, new object[4]
            {
              this.SelectedOrderDataRow["OrderID"],
              this.SelectedOrderDataRow["EngineerVisitID"],
              (object) 0,
              (object) this
            }, false);
            break;
        }
      }
    }

    private void btnFindRecord_Click(object sender, EventArgs e)
    {
      string Left = Combo.get_GetSelectedItemValue(this.cboType);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) == 0)
        return;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
      {
        int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, 0, "", false));
        if ((uint) integer <= 0U)
          return;
        this.theSite = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
        this.RunFilter();
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
      {
        int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false));
        if ((uint) integer <= 0U)
          return;
        this.Warehouse = App.DB.Warehouse.Warehouse_Get(integer);
        this.RunFilter();
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
      {
        int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblVan, 0, "", false));
        if ((uint) integer <= 0U)
          return;
        this.Van = App.DB.Van.Van_Get(integer);
        this.RunFilter();
      }
      else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
      {
        int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false));
        if ((uint) integer <= 0U)
          return;
        this.Warehouse = App.DB.Warehouse.Warehouse_Get(integer);
        this.RunFilter();
      }
      else
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) != 0)
          return;
        int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblJob, 0, "", false));
        if ((uint) integer > 0U)
        {
          this.Job = App.DB.Job.Job_Get(integer);
          this.RunFilter();
        }
      }
    }

    public void PopulateDatagrid()
    {
      try
      {
        if (this.get_GetParameter(0) == null)
        {
          this.OrdersDataview = App.DB.Order.Order_GetAll(this.txtContains.Text.Trim());
          this.RunFilter();
        }
        else
        {
          this.OrdersDataview = (DataView) this.get_GetParameter(0);
          this.grpFilter.Enabled = false;
        }
        this.grpJobs.Text = string.Format("Results ({0}) - Double Click To View / Edit", (object) this.OrdersDataview.Count);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void ResetFilters()
    {
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(0));
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(0));
      this.cboStatus = cboStatus;
      ComboBox supplierInvoiceSent = this.cboSupplierInvoiceSent;
      Combo.SetSelectedComboItem_By_Value(ref supplierInvoiceSent, Conversions.ToString(0));
      this.cboSupplierInvoiceSent = supplierInvoiceSent;
      ComboBox cboSupplier = this.cboSupplier;
      Combo.SetSelectedComboItem_By_Value(ref cboSupplier, Conversions.ToString(0));
      this.cboSupplier = cboSupplier;
      this.chkDateCreated.Checked = false;
      this.dtpFrom.Value = DateAndTime.Today;
      this.dtpFrom.Enabled = false;
      this.dtpTo.Value = DateAndTime.Today;
      this.dtpTo.Enabled = false;
      this.chkDeliveryDeadline.Checked = false;
      this.dtpDeliveryDeadlineFrom.Value = DateAndTime.Today;
      this.dtpDeliveryDeadlineFrom.Enabled = false;
      this.dtpDeliveryDeadlineTo.Value = DateAndTime.Today;
      this.dtpDeliveryDeadlineTo.Enabled = false;
      this.grpFilter.Enabled = true;
      this.txtSearch.Text = "";
      this.txtConsolidationRef.Text = "";
      this.txtOrderRef.Text = "";
    }

    private void RunFilter()
    {
      if (this.OrdersDataview == null)
        return;
      string str = "Deleted = 0 ";
      if (this.theSite != null)
        str += " AND SiteID = " + Conversions.ToString(this.theSite.SiteID);
      if (this.Van != null)
        str += " AND VanID = " + Conversions.ToString(this.Van.VanID);
      if (this.Warehouse != null)
        str += " AND WarehouseID = " + Conversions.ToString(this.Warehouse.WarehouseID);
      if (this.Job != null)
        str += " AND JobID = " + Conversions.ToString(this.Job.JobID);
      if (this.chkEngineerNotReceived.Checked)
        str += " AND PartsNotReceived = 1 ";
      string Left = Combo.get_GetSelectedItemValue(this.cboType);
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) != 0)
      {
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
          str += " AND OrderTypeID = 1";
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
          str += " AND OrderTypeID = 1";
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
          str += " AND OrderTypeID = 2";
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
          str += " AND OrderTypeID = 3";
        else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) == 0)
          str += " AND OrderTypeID = 4";
      }
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) != 0.0)
        str += " AND DisplayStatusID = " + Combo.get_GetSelectedItemValue(this.cboStatus);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboSupplier)) != 0.0)
        str += " AND SupplierID = " + Combo.get_GetSelectedItemValue(this.cboSupplier);
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboSupplierInvoiceSent), "0", false) > 0U)
        str = str + " AND SupplierExported = '" + Combo.get_GetSelectedItemDescription(this.cboSupplierInvoiceSent) + "'";
      if ((uint) this.txtOrderRef.Text.Trim().Length > 0U)
        str = str + " AND OrderReference LIKE '%" + this.txtOrderRef.Text.Trim() + "%'";
      if ((uint) this.txtConsolidationRef.Text.Trim().Length > 0U)
        str = str + " AND ConsolidationRef LIKE '%" + this.txtConsolidationRef.Text.Trim() + "%'";
      if (this.chkDateCreated.Checked)
        str = str + " AND DatePlaced >= '" + Strings.Format((object) this.dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND DatePlaced <= '" + Strings.Format((object) this.dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
      if (this.chkDeliveryDeadline.Checked)
        str = str + " AND DeliveryDeadline >= '" + Strings.Format((object) this.dtpDeliveryDeadlineFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND DeliveryDeadline <= '" + Strings.Format((object) this.dtpDeliveryDeadlineTo.Value, "dd/MM/yyyy 23:59:59") + "'";
      if (this.chkOutstanding.Checked)
        str += " AND CONVERT(NUMERIC(10,2),SupplierInvoiceAmount) <= CONVERT(NUMERIC(10,2),BuyPrice) ";
      this.OrdersDataview.RowFilter = str;
      this.grpJobs.Text = string.Format("Results ({0}) - Double Click To View / Edit", (object) this.OrdersDataview.Count);
    }

    public void Export()
    {
      DataTable dtData = new DataTable();
      dtData.Columns.Add("DatePlaced");
      dtData.Columns.Add("DeliveryDeadline");
      dtData.Columns.Add("OrderReference");
      dtData.Columns.Add("ConsolidationRef");
      dtData.Columns.Add("Type");
      dtData.Columns.Add("Customer");
      dtData.Columns.Add("Property");
      dtData.Columns.Add("Supplier");
      dtData.Columns.Add("Van");
      dtData.Columns.Add("Warehouse");
      dtData.Columns.Add("JobNumber");
      dtData.Columns.Add("Status");
      dtData.Columns.Add("Supplier Invoice Sent To Sage");
      dtData.Columns.Add("BuyPrice", typeof (double));
      dtData.Columns.Add("SellPrice", typeof (double));
      dtData.Columns.Add("CreatedBy");
      dtData.Columns.Add("DepartmentRef");
      Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.IT;
      if (App.loggedInUser.HasAccessToModule(ssm))
        dtData.Columns.Add("OrderID");
      IEnumerator enumerator;
      try
      {
        enumerator = ((DataView) this.dgOrders.DataSource).GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          DataRow row = dtData.NewRow();
          row["DatePlaced"] = RuntimeHelpers.GetObjectValue(current["DatePlaced"]);
          row["DeliveryDeadline"] = RuntimeHelpers.GetObjectValue(current["DeliveryDeadline"]);
          row["OrderReference"] = RuntimeHelpers.GetObjectValue(current["OrderReference"]);
          row["ConsolidationRef"] = RuntimeHelpers.GetObjectValue(current["ConsolidationRef"]);
          row["Type"] = RuntimeHelpers.GetObjectValue(current["Type"]);
          row["Customer"] = RuntimeHelpers.GetObjectValue(current["Customer"]);
          row["Property"] = RuntimeHelpers.GetObjectValue(current["Site"]);
          row["Supplier"] = RuntimeHelpers.GetObjectValue(current["Supplier"]);
          row["Van"] = RuntimeHelpers.GetObjectValue(current["Registration"]);
          row["Warehouse"] = RuntimeHelpers.GetObjectValue(current["Warehouse"]);
          row["JobNumber"] = RuntimeHelpers.GetObjectValue(current["JobNumber"]);
          row["Status"] = RuntimeHelpers.GetObjectValue(current["DisplayStatus"]);
          row["Supplier Invoice Sent To Sage"] = RuntimeHelpers.GetObjectValue(current["SupplierExported"]);
          row["BuyPrice"] = RuntimeHelpers.GetObjectValue(current["BuyPrice"]);
          row["SellPrice"] = RuntimeHelpers.GetObjectValue(current["SellPrice"]);
          row["CreatedBy"] = RuntimeHelpers.GetObjectValue(current["CreatedBy"]);
          row["DepartmentRef"] = RuntimeHelpers.GetObjectValue(current["DepartmentRef"]);
          if (App.loggedInUser.HasAccessToModule(ssm))
            row["OrderID"] = RuntimeHelpers.GetObjectValue(current["OrderID"]);
          dtData.Rows.Add(row);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      ExportHelper.Export(dtData, "Order List", Enums.ExportType.XLS);
    }

    private void btnFilterResults_Click(object sender, EventArgs e)
    {
      this.Query();
    }

    public void Query()
    {
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        int OrderSiteID = 0;
        if (this.theSite != null)
          OrderSiteID = this.theSite.SiteID;
        int OrderVanID = 0;
        if (this.Van != null)
          OrderVanID = this.Van.VanID;
        int OrderWarehouseID = 0;
        if (this.Warehouse != null)
          OrderWarehouseID = this.Warehouse.WarehouseID;
        int OrderJobID = 0;
        if (this.Job != null)
          OrderJobID = this.Job.JobID;
        int OrderTypeID = 0;
        string Left = Combo.get_GetSelectedItemValue(this.cboType);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(0), false) != 0)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(1), false) == 0)
            OrderTypeID = 1;
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(2), false) == 0)
            OrderTypeID = 1;
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(3), false) == 0)
            OrderTypeID = 2;
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(4), false) == 0)
            OrderTypeID = 3;
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, Conversions.ToString(5), false) == 0)
            OrderTypeID = 4;
        }
        int PartsNotReceived = !this.chkEngineerNotReceived.Checked ? 0 : 1;
        int OrderSupplierID = 0;
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboSupplier), "0", false) > 0U)
          OrderSupplierID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboSupplier));
        int OrderSupplierExported = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboSupplierInvoiceSent), "0", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboSupplierInvoiceSent), "Yes", false) != 0 ? 2 : 1) : 0;
        string OrderReference = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtOrderRef.Text.Trim(), "", false) != 0 ? "%" + this.txtOrderRef.Text.Trim() + "%" : "%";
        string OrderConsolidationRef = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtConsolidationRef.Text.Trim(), "", false) != 0 ? "%" + this.txtConsolidationRef.Text.Trim() + "%" : "%%";
        DateTime? OrderDatePlacedFrom = new DateTime?();
        DateTime? OrderDatePlacedTo = new DateTime?();
        if (this.chkDateCreated.Checked)
        {
          OrderDatePlacedFrom = new DateTime?(Conversions.ToDate(Strings.Format((object) this.dtpFrom.Value, "dd/MM/yyyy 00:00:00")));
          OrderDatePlacedTo = new DateTime?(Conversions.ToDate(Strings.Format((object) this.dtpTo.Value, "dd/MM/yyyy 23:59:59")));
        }
        DateTime? OrderDeliveryDeadlineFrom = new DateTime?();
        DateTime? OrderDeliveryDeadlineTo = new DateTime?();
        if (this.chkDeliveryDeadline.Checked)
        {
          OrderDeliveryDeadlineFrom = new DateTime?(Conversions.ToDate(Strings.Format((object) this.dtpDeliveryDeadlineFrom.Value, "dd/MM/yyyy 00:00:00")));
          OrderDeliveryDeadlineTo = new DateTime?(Conversions.ToDate(Strings.Format((object) this.dtpDeliveryDeadlineTo.Value, "dd/MM/yyyy 23:59:59")));
        }
        int OrderStatus = 0;
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) != 0.0)
          OrderStatus = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboStatus));
        string SearchCriteria = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtContains.Text.Trim(), "", false) != 0 ? this.txtContains.Text.Trim() : "";
        string OrderDepartment = "%%";
        string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboDepartment));
        if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) > 0)
          OrderDepartment = str;
        else if (!Versioned.IsNumeric((object) str))
          OrderDepartment = str;
        this.OrdersDataview = App.DB.Order.Order_GetAll_NEW(SearchCriteria, OrderSiteID, OrderVanID, OrderWarehouseID, OrderJobID, OrderTypeID, OrderReference, OrderConsolidationRef, OrderStatus, PartsNotReceived, OrderSupplierExported, OrderSupplierID, OrderDatePlacedFrom, OrderDatePlacedTo, OrderDeliveryDeadlineFrom, OrderDeliveryDeadlineTo, OrderDepartment);
        if (this.chkOutstanding.Checked)
          this.OrdersDataview.RowFilter = "Isnull(SupplierInvoiceAmount,0) < BuyPrice";
        this.grpJobs.Text = string.Format("Results ({0}) - Double Click To View / Edit", (object) this.OrdersDataview.Count);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
      finally
      {
        Cursor.Current = Cursors.Default;
      }
    }

    private void txtOrderRef_TextChanged(object sender, EventArgs e)
    {
    }

    private void chkOutstanding_CheckedChanged(object sender, EventArgs e)
    {
    }

    public class PartsNotReceivedColourColumn : DataGridLabelColumn
    {
      protected override void Paint(
        Graphics g,
        Rectangle bounds,
        CurrencyManager source,
        int rowNum,
        Brush backBrush,
        Brush foreBrush,
        bool alignToRight)
      {
        base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
        Brush brush = Brushes.White;
        if (((Conversions.ToDouble(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "OrderTypeID"
        }, (string[]) null, (System.Type[]) null, (bool[]) null)))) == 4.0 ? 1 : 0) | (Conversions.ToDouble(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
        {
          (object) "OrderTypeID"
        }, (string[]) null, (System.Type[]) null, (bool[]) null)))) == 2.0 ? 1 : 0)) != 0)
          brush = !Conversions.ToBoolean(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(source.List[rowNum], (System.Type) null, "row", new object[0], (string[]) null, (System.Type[]) null, (bool[]) null), (System.Type) null, "item", new object[1]
          {
            (object) "PartsNotReceived"
          }, (string[]) null, (System.Type[]) null, (bool[]) null)))) ? Brushes.Green : Brushes.Red;
        Rectangle rect = bounds;
        g.FillRectangle(brush, rect);
        g.DrawString("", this.DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB((float) rect.X, (float) rect.Y, (float) rect.Right, (float) rect.Bottom));
      }
    }
  }
}
