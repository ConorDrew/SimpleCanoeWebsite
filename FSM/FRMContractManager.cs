// Decompiled with JetBrains decompiler
// Type: FSM.FRMContractManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContactAttempts;
using FSM.Entity.ContractsOriginal;
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
  public class FRMContractManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private DataView _Contracts;
    private FSM.Entity.Customers.Customer _theCustomer;
    private bool _Loading;

    public FRMContractManager()
    {
      this.Load += new EventHandler(this.FRMContractManager_Load);
      this._Loading = true;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
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

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtContractReference { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpContracts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgContracts
    {
      get
      {
        return this._dgContracts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgContracts_DoubleClick);
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgContracts_MouseUp);
        DataGrid dgContracts1 = this._dgContracts;
        if (dgContracts1 != null)
        {
          dgContracts1.DoubleClick -= eventHandler;
          dgContracts1.MouseUp -= mouseEventHandler;
        }
        this._dgContracts = value;
        DataGrid dgContracts2 = this._dgContracts;
        if (dgContracts2 == null)
          return;
        dgContracts2.DoubleClick += eventHandler;
        dgContracts2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual CheckBox cbxContractExpiryDate
    {
      get
      {
        return this._cbxContractExpiryDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbxContractExpiryDate_CheckedChanged);
        CheckBox contractExpiryDate1 = this._cbxContractExpiryDate;
        if (contractExpiryDate1 != null)
          contractExpiryDate1.CheckedChanged -= eventHandler;
        this._cbxContractExpiryDate = value;
        CheckBox contractExpiryDate2 = this._cbxContractExpiryDate;
        if (contractExpiryDate2 == null)
          return;
        contractExpiryDate2.CheckedChanged += eventHandler;
      }
    }

    internal virtual CheckBox cbxAllVisitsComplete
    {
      get
      {
        return this._cbxAllVisitsComplete;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbxAllVisitsComplete_CheckedChanged);
        CheckBox allVisitsComplete1 = this._cbxAllVisitsComplete;
        if (allVisitsComplete1 != null)
          allVisitsComplete1.CheckedChanged -= eventHandler;
        this._cbxAllVisitsComplete = value;
        CheckBox allVisitsComplete2 = this._cbxAllVisitsComplete;
        if (allVisitsComplete2 == null)
          return;
        allVisitsComplete2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Button btnRenew
    {
      get
      {
        return this._btnRenew;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRenew_Click);
        Button btnRenew1 = this._btnRenew;
        if (btnRenew1 != null)
          btnRenew1.Click -= eventHandler;
        this._btnRenew = value;
        Button btnRenew2 = this._btnRenew;
        if (btnRenew2 == null)
          return;
        btnRenew2.Click += eventHandler;
      }
    }

    internal virtual Button btnPrintExpiryLetter
    {
      get
      {
        return this._btnPrintExpiryLetter;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnPrintExpiryLetter_Click);
        Button printExpiryLetter1 = this._btnPrintExpiryLetter;
        if (printExpiryLetter1 != null)
          printExpiryLetter1.Click -= eventHandler;
        this._btnPrintExpiryLetter = value;
        Button printExpiryLetter2 = this._btnPrintExpiryLetter;
        if (printExpiryLetter2 == null)
          return;
        printExpiryLetter2.Click += eventHandler;
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

    internal virtual Button btnActivate
    {
      get
      {
        return this._btnActivate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnActivate_Click);
        Button btnActivate1 = this._btnActivate;
        if (btnActivate1 != null)
          btnActivate1.Click -= eventHandler;
        this._btnActivate = value;
        Button btnActivate2 = this._btnActivate;
        if (btnActivate2 == null)
          return;
        btnActivate2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeActive
    {
      get
      {
        return this._btnDeActive;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeActive_Click);
        Button btnDeActive1 = this._btnDeActive;
        if (btnDeActive1 != null)
          btnDeActive1.Click -= eventHandler;
        this._btnDeActive = value;
        Button btnDeActive2 = this._btnDeActive;
        if (btnDeActive2 == null)
          return;
        btnDeActive2.Click += eventHandler;
      }
    }

    internal virtual CheckBox cbxCancelledDate
    {
      get
      {
        return this._cbxCancelledDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cbxCancelledDate_CheckedChanged);
        CheckBox cbxCancelledDate1 = this._cbxCancelledDate;
        if (cbxCancelledDate1 != null)
          cbxCancelledDate1.CheckedChanged -= eventHandler;
        this._cbxCancelledDate = value;
        CheckBox cbxCancelledDate2 = this._cbxCancelledDate;
        if (cbxCancelledDate2 == null)
          return;
        cbxCancelledDate2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInvoiceFrequency { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chxStartedBetween
    {
      get
      {
        return this._chxStartedBetween;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chxStartedBetween_CheckedChanged);
        CheckBox chxStartedBetween1 = this._chxStartedBetween;
        if (chxStartedBetween1 != null)
          chxStartedBetween1.CheckedChanged -= eventHandler;
        this._chxStartedBetween = value;
        CheckBox chxStartedBetween2 = this._chxStartedBetween;
        if (chxStartedBetween2 == null)
          return;
        chxStartedBetween2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Button btnResetFilters { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRegion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox CboRenewal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox cbxDoNotRenew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ProgressBar pbStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpFilter = new GroupBox();
      this.cbxDoNotRenew = new CheckBox();
      this.Label2 = new Label();
      this.CboRenewal = new ComboBox();
      this.Label13 = new Label();
      this.cboRegion = new ComboBox();
      this.btnResetFilters = new Button();
      this.btnSearch = new Button();
      this.Label1 = new Label();
      this.cboInvoiceFrequency = new ComboBox();
      this.chxStartedBetween = new CheckBox();
      this.cbxCancelledDate = new CheckBox();
      this.cbxAllVisitsComplete = new CheckBox();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label4 = new Label();
      this.dtpTo = new DateTimePicker();
      this.dtpFrom = new DateTimePicker();
      this.txtContractReference = new TextBox();
      this.Label9 = new Label();
      this.cbxContractExpiryDate = new CheckBox();
      this.Label6 = new Label();
      this.cboType = new ComboBox();
      this.Label11 = new Label();
      this.cboStatus = new ComboBox();
      this.Label10 = new Label();
      this.btnExport = new Button();
      this.grpContracts = new GroupBox();
      this.btnSelectAll = new Button();
      this.btnDeselectAll = new Button();
      this.dgContracts = new DataGrid();
      this.btnReset = new Button();
      this.btnRenew = new Button();
      this.btnPrintExpiryLetter = new Button();
      this.pbStatus = new ProgressBar();
      this.btnActivate = new Button();
      this.btnDeActive = new Button();
      this.grpFilter.SuspendLayout();
      this.grpContracts.SuspendLayout();
      this.dgContracts.BeginInit();
      this.SuspendLayout();
      this.grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpFilter.Controls.Add((Control) this.cbxDoNotRenew);
      this.grpFilter.Controls.Add((Control) this.Label2);
      this.grpFilter.Controls.Add((Control) this.CboRenewal);
      this.grpFilter.Controls.Add((Control) this.Label13);
      this.grpFilter.Controls.Add((Control) this.cboRegion);
      this.grpFilter.Controls.Add((Control) this.btnResetFilters);
      this.grpFilter.Controls.Add((Control) this.btnSearch);
      this.grpFilter.Controls.Add((Control) this.Label1);
      this.grpFilter.Controls.Add((Control) this.cboInvoiceFrequency);
      this.grpFilter.Controls.Add((Control) this.chxStartedBetween);
      this.grpFilter.Controls.Add((Control) this.cbxCancelledDate);
      this.grpFilter.Controls.Add((Control) this.cbxAllVisitsComplete);
      this.grpFilter.Controls.Add((Control) this.btnFindCustomer);
      this.grpFilter.Controls.Add((Control) this.txtCustomer);
      this.grpFilter.Controls.Add((Control) this.Label4);
      this.grpFilter.Controls.Add((Control) this.dtpTo);
      this.grpFilter.Controls.Add((Control) this.dtpFrom);
      this.grpFilter.Controls.Add((Control) this.txtContractReference);
      this.grpFilter.Controls.Add((Control) this.Label9);
      this.grpFilter.Controls.Add((Control) this.cbxContractExpiryDate);
      this.grpFilter.Controls.Add((Control) this.Label6);
      this.grpFilter.Controls.Add((Control) this.cboType);
      this.grpFilter.Controls.Add((Control) this.Label11);
      this.grpFilter.Controls.Add((Control) this.cboStatus);
      this.grpFilter.Controls.Add((Control) this.Label10);
      this.grpFilter.Location = new System.Drawing.Point(8, 32);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(882, 206);
      this.grpFilter.TabIndex = 17;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.cbxDoNotRenew.BackColor = Color.White;
      this.cbxDoNotRenew.Cursor = Cursors.Hand;
      this.cbxDoNotRenew.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbxDoNotRenew.Location = new System.Drawing.Point(104, 149);
      this.cbxDoNotRenew.Name = "cbxDoNotRenew";
      this.cbxDoNotRenew.Size = new Size(192, 24);
      this.cbxDoNotRenew.TabIndex = 40;
      this.cbxDoNotRenew.Text = "Also Show Do Not renew ";
      this.cbxDoNotRenew.UseVisualStyleBackColor = false;
      this.Label2.Location = new System.Drawing.Point(532, 148);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(74, 16);
      this.Label2.TabIndex = 39;
      this.Label2.Text = "Renewed";
      this.CboRenewal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.CboRenewal.DropDownStyle = ComboBoxStyle.DropDownList;
      this.CboRenewal.Location = new System.Drawing.Point(659, 145);
      this.CboRenewal.Name = "CboRenewal";
      this.CboRenewal.Size = new Size(167, 21);
      this.CboRenewal.TabIndex = 38;
      this.Label13.Location = new System.Drawing.Point(532, 121);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(49, 16);
      this.Label13.TabIndex = 37;
      this.Label13.Text = "Region";
      this.cboRegion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboRegion.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboRegion.Location = new System.Drawing.Point(659, 118);
      this.cboRegion.Name = "cboRegion";
      this.cboRegion.Size = new Size(167, 21);
      this.cboRegion.TabIndex = 36;
      this.btnResetFilters.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnResetFilters.Location = new System.Drawing.Point(651, 171);
      this.btnResetFilters.Name = "btnResetFilters";
      this.btnResetFilters.Size = new Size(96, 23);
      this.btnResetFilters.TabIndex = 31;
      this.btnResetFilters.Text = "Reset Filters";
      this.btnResetFilters.UseVisualStyleBackColor = true;
      this.btnSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSearch.Location = new System.Drawing.Point(753, 171);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new Size(75, 23);
      this.btnSearch.TabIndex = 30;
      this.btnSearch.Text = "Search";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.Label1.Location = new System.Drawing.Point(532, 94);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(120, 19);
      this.Label1.TabIndex = 29;
      this.Label1.Text = "Invoice Frequency";
      this.cboInvoiceFrequency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboInvoiceFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInvoiceFrequency.Location = new System.Drawing.Point(659, 91);
      this.cboInvoiceFrequency.Name = "cboInvoiceFrequency";
      this.cboInvoiceFrequency.Size = new Size(167, 21);
      this.cboInvoiceFrequency.TabIndex = 28;
      this.chxStartedBetween.BackColor = Color.White;
      this.chxStartedBetween.Cursor = Cursors.Hand;
      this.chxStartedBetween.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.chxStartedBetween.Location = new System.Drawing.Point(104, 86);
      this.chxStartedBetween.Name = "chxStartedBetween";
      this.chxStartedBetween.Size = new Size(192, 24);
      this.chxStartedBetween.TabIndex = 27;
      this.chxStartedBetween.Text = "Contract Started between";
      this.chxStartedBetween.UseVisualStyleBackColor = false;
      this.cbxCancelledDate.BackColor = Color.White;
      this.cbxCancelledDate.Cursor = Cursors.Hand;
      this.cbxCancelledDate.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbxCancelledDate.Location = new System.Drawing.Point(104, 128);
      this.cbxCancelledDate.Name = "cbxCancelledDate";
      this.cbxCancelledDate.Size = new Size(192, 24);
      this.cbxCancelledDate.TabIndex = 26;
      this.cbxCancelledDate.Text = "Contract Cancelled between";
      this.cbxCancelledDate.UseVisualStyleBackColor = false;
      this.cbxAllVisitsComplete.Location = new System.Drawing.Point(104, 111);
      this.cbxAllVisitsComplete.Name = "cbxAllVisitsComplete";
      this.cbxAllVisitsComplete.Size = new Size(192, 16);
      this.cbxAllVisitsComplete.TabIndex = 25;
      this.cbxAllVisitsComplete.Text = "All Visits Complete";
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(834, 16);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 2;
      this.btnFindCustomer.Text = "...";
      this.btnFindCustomer.UseVisualStyleBackColor = false;
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(104, 16);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(722, 21);
      this.txtCustomer.TabIndex = 1;
      this.Label4.Location = new System.Drawing.Point(8, 19);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(64, 16);
      this.Label4.TabIndex = 24;
      this.Label4.Text = "Customer";
      this.dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.dtpTo.Location = new System.Drawing.Point(576, 64);
      this.dtpTo.Name = "dtpTo";
      this.dtpTo.Size = new Size(250, 21);
      this.dtpTo.TabIndex = 13;
      this.dtpFrom.Location = new System.Drawing.Point(328, 64);
      this.dtpFrom.Name = "dtpFrom";
      this.dtpFrom.Size = new Size(184, 21);
      this.dtpFrom.TabIndex = 12;
      this.txtContractReference.Location = new System.Drawing.Point(104, 40);
      this.txtContractReference.Name = "txtContractReference";
      this.txtContractReference.Size = new Size(184, 21);
      this.txtContractReference.TabIndex = 9;
      this.Label9.Location = new System.Drawing.Point(520, 64);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(48, 16);
      this.Label9.TabIndex = 10;
      this.Label9.Text = "And";
      this.cbxContractExpiryDate.BackColor = Color.White;
      this.cbxContractExpiryDate.Cursor = Cursors.Hand;
      this.cbxContractExpiryDate.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cbxContractExpiryDate.Location = new System.Drawing.Point(104, 64);
      this.cbxContractExpiryDate.Name = "cbxContractExpiryDate";
      this.cbxContractExpiryDate.Size = new Size(176, 24);
      this.cbxContractExpiryDate.TabIndex = 11;
      this.cbxContractExpiryDate.Text = "Contract Expiries between";
      this.cbxContractExpiryDate.UseVisualStyleBackColor = false;
      this.Label6.Location = new System.Drawing.Point(8, 40);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(88, 16);
      this.Label6.TabIndex = 6;
      this.Label6.Text = "Contract Ref.";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(328, 40);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(184, 21);
      this.cboType.TabIndex = 7;
      this.Label11.Location = new System.Drawing.Point(520, 40);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(48, 16);
      this.Label11.TabIndex = 5;
      this.Label11.Text = "Status";
      this.cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.Location = new System.Drawing.Point(576, 40);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(250, 21);
      this.cboStatus.TabIndex = 8;
      this.Label10.BackColor = Color.White;
      this.Label10.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label10.Location = new System.Drawing.Point(292, 40);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(48, 16);
      this.Label10.TabIndex = 4;
      this.Label10.Text = "Type";
      this.btnExport.AccessibleDescription = "Export Job List To Excel";
      this.btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnExport.Location = new System.Drawing.Point(8, 544);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new Size(56, 23);
      this.btnExport.TabIndex = 19;
      this.btnExport.Text = "Export";
      this.grpContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContracts.Controls.Add((Control) this.btnSelectAll);
      this.grpContracts.Controls.Add((Control) this.btnDeselectAll);
      this.grpContracts.Controls.Add((Control) this.dgContracts);
      this.grpContracts.Location = new System.Drawing.Point(8, 244);
      this.grpContracts.Name = "grpContracts";
      this.grpContracts.Size = new Size(882, 294);
      this.grpContracts.TabIndex = 18;
      this.grpContracts.TabStop = false;
      this.grpContracts.Text = "Double Click To View / Edit";
      this.btnSelectAll.AccessibleDescription = "Export Job List To Excel";
      this.btnSelectAll.Location = new System.Drawing.Point(8, 13);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Size = new Size(88, 23);
      this.btnSelectAll.TabIndex = 21;
      this.btnSelectAll.Text = "Select All";
      this.btnDeselectAll.Location = new System.Drawing.Point(104, 13);
      this.btnDeselectAll.Name = "btnDeselectAll";
      this.btnDeselectAll.Size = new Size(88, 23);
      this.btnDeselectAll.TabIndex = 22;
      this.btnDeselectAll.Text = "Deselect All";
      this.dgContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgContracts.DataMember = "";
      this.dgContracts.HeaderForeColor = SystemColors.ControlText;
      this.dgContracts.Location = new System.Drawing.Point(8, 42);
      this.dgContracts.Name = "dgContracts";
      this.dgContracts.Size = new Size(866, 244);
      this.dgContracts.TabIndex = 14;
      this.btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnReset.Location = new System.Drawing.Point(72, 544);
      this.btnReset.Name = "btnReset";
      this.btnReset.Size = new Size(56, 23);
      this.btnReset.TabIndex = 20;
      this.btnReset.Text = "Reset";
      this.btnRenew.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnRenew.Location = new System.Drawing.Point(136, 544);
      this.btnRenew.Name = "btnRenew";
      this.btnRenew.Size = new Size(56, 23);
      this.btnRenew.TabIndex = 21;
      this.btnRenew.Text = "Renew";
      this.btnPrintExpiryLetter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnPrintExpiryLetter.Location = new System.Drawing.Point(746, 544);
      this.btnPrintExpiryLetter.Name = "btnPrintExpiryLetter";
      this.btnPrintExpiryLetter.Size = new Size(136, 23);
      this.btnPrintExpiryLetter.TabIndex = 22;
      this.btnPrintExpiryLetter.Text = "Print Expiry Letters";
      this.pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pbStatus.Location = new System.Drawing.Point(373, 544);
      this.pbStatus.Name = "pbStatus";
      this.pbStatus.Size = new Size(365, 23);
      this.pbStatus.TabIndex = 23;
      this.btnActivate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnActivate.Location = new System.Drawing.Point(198, 544);
      this.btnActivate.Name = "btnActivate";
      this.btnActivate.Size = new Size(74, 23);
      this.btnActivate.TabIndex = 24;
      this.btnActivate.Text = "Activate";
      this.btnDeActive.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnDeActive.Location = new System.Drawing.Point(278, 544);
      this.btnDeActive.Name = "btnDeActive";
      this.btnDeActive.Size = new Size(89, 23);
      this.btnDeActive.TabIndex = 25;
      this.btnDeActive.Text = "Deactivate";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(898, 574);
      this.Controls.Add((Control) this.btnDeActive);
      this.Controls.Add((Control) this.btnActivate);
      this.Controls.Add((Control) this.pbStatus);
      this.Controls.Add((Control) this.btnPrintExpiryLetter);
      this.Controls.Add((Control) this.btnRenew);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.btnExport);
      this.Controls.Add((Control) this.grpContracts);
      this.Controls.Add((Control) this.btnReset);
      this.MinimumSize = new Size(808, 528);
      this.Name = nameof (FRMContractManager);
      this.Text = "Contract Manager";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.btnReset, 0);
      this.Controls.SetChildIndex((Control) this.grpContracts, 0);
      this.Controls.SetChildIndex((Control) this.btnExport, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnRenew, 0);
      this.Controls.SetChildIndex((Control) this.btnPrintExpiryLetter, 0);
      this.Controls.SetChildIndex((Control) this.pbStatus, 0);
      this.Controls.SetChildIndex((Control) this.btnActivate, 0);
      this.Controls.SetChildIndex((Control) this.btnDeActive, 0);
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.grpContracts.ResumeLayout(false);
      this.dgContracts.EndInit();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.Loading = true;
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupContractsDataGrid();
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, App.DB.Picklists.GetAll(Enums.PickListTypes.ContractTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboStatus = cboStatus;
      ComboBox invoiceFrequency = this.cboInvoiceFrequency;
      Combo.SetUpCombo(ref invoiceFrequency, DynamicDataTables.InvoiceFrequency, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.cboInvoiceFrequency = invoiceFrequency;
      ComboBox cboRegion = this.cboRegion;
      Combo.SetUpCombo(ref cboRegion, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions, false).Table, "ManagerID", "Name", Enums.ComboValues.No_Filter);
      this.cboRegion = cboRegion;
      ComboBox cboRenewal = this.CboRenewal;
      Combo.SetUpCombo(ref cboRenewal, DynamicDataTables.ContractRenewal, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
      this.CboRenewal = cboRenewal;
      this.ResetFilters();
      this.Loading = false;
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

    private DataView Contracts
    {
      get
      {
        return this._Contracts;
      }
      set
      {
        this._Contracts = value;
        this._Contracts.AllowNew = false;
        this._Contracts.AllowEdit = false;
        this._Contracts.AllowDelete = false;
        this._Contracts.Table.TableName = Enums.TableNames.tblContract.ToString();
        this.dgContracts.DataSource = (object) this.Contracts;
      }
    }

    private DataRow SelectedContractDataRow
    {
      get
      {
        return this.dgContracts.CurrentRowIndex != -1 ? this.Contracts[this.dgContracts.CurrentRowIndex].Row : (DataRow) null;
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
        if (this._theCustomer != null)
          this.txtCustomer.Text = this.theCustomer.Name + " (A/C No : " + this.theCustomer.AccountNumber + ")";
        else
          this.txtCustomer.Text = "";
      }
    }

    public bool Loading
    {
      get
      {
        return this._Loading;
      }
      set
      {
        this._Loading = value;
      }
    }

    private void SetupContractsDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgContracts.TableStyles[0];
      DataGridBoolColumn dataGridBoolColumn1 = new DataGridBoolColumn();
      dataGridBoolColumn1.HeaderText = "";
      dataGridBoolColumn1.MappingName = "tick";
      dataGridBoolColumn1.ReadOnly = true;
      dataGridBoolColumn1.Width = 25;
      dataGridBoolColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn1);
      DataGridBoolColumn dataGridBoolColumn2 = new DataGridBoolColumn();
      dataGridBoolColumn2.HeaderText = "Contact Made";
      dataGridBoolColumn2.MappingName = "ContactMade";
      dataGridBoolColumn2.ReadOnly = true;
      dataGridBoolColumn2.Width = 100;
      dataGridBoolColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridBoolColumn2);
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Property";
      dataGridLabelColumn1.MappingName = "Property";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Contract Reference";
      dataGridLabelColumn2.MappingName = "ContractReference";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 120;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Type";
      dataGridLabelColumn3.MappingName = "Type";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Contract Status";
      dataGridLabelColumn4.MappingName = "ContractStatus";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MMM/yyyy";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Start Date";
      dataGridLabelColumn5.MappingName = "ContractStartDate";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 80;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "dd/MMM/yyyy";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "End Date";
      dataGridLabelColumn6.MappingName = "ContractEndDate";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 80;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "C";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Contract Price";
      dataGridLabelColumn7.MappingName = "ContractPrice";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 90;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridContractColumn gridContractColumn = new DataGridContractColumn();
      gridContractColumn.Format = "";
      gridContractColumn.FormatInfo = (IFormatProvider) null;
      gridContractColumn.HeaderText = "Renewed";
      gridContractColumn.MappingName = "Renewed";
      gridContractColumn.ReadOnly = true;
      gridContractColumn.Width = 100;
      gridContractColumn.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) gridContractColumn);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Customer";
      dataGridLabelColumn8.MappingName = "Customer";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 150;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.HeaderText = "Cancelled Date";
      dataGridLabelColumn9.MappingName = "CancelledDate";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "n/a";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Cancelled Reason";
      dataGridLabelColumn10.MappingName = "CancelledReason";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 150;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "AHE";
      dataGridLabelColumn11.MappingName = "AHE";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 80;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "Invoice Frequency";
      dataGridLabelColumn12.MappingName = "InvoiceFrequency";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 100;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.HeaderText = "Date Contact Made";
      dataGridLabelColumn13.MappingName = "DateContactMade";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 120;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContract.ToString();
      this.dgContracts.TableStyles.Add(tableStyle);
    }

    private void FRMContractManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.theCustomer = App.DB.Customer.Customer_Get(integer);
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      this.Export();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      this.ResetFilters();
    }

    private void cbxContractExpiryDate_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cbxContractExpiryDate.Checked)
      {
        this.dtpFrom.Enabled = true;
        this.dtpTo.Enabled = true;
      }
      else
      {
        this.dtpFrom.Enabled = false;
        this.dtpTo.Enabled = false;
      }
    }

    private void cbxCancelledDate_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cbxCancelledDate.Checked)
      {
        this.dtpFrom.Enabled = true;
        this.dtpTo.Enabled = true;
      }
      else
      {
        this.dtpFrom.Enabled = false;
        this.dtpTo.Enabled = false;
      }
    }

    private void chxStartedBetween_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chxStartedBetween.Checked)
      {
        this.dtpFrom.Enabled = true;
        this.dtpTo.Enabled = true;
      }
      else
      {
        this.dtpFrom.Enabled = false;
        this.dtpTo.Enabled = false;
      }
    }

    private void cbxAllVisitsComplete_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.cbxAllVisitsComplete.Checked)
        return;
      this.cbxContractExpiryDate.Checked = false;
      this.cbxCancelledDate.Checked = false;
      this.chxStartedBetween.Checked = false;
    }

    private void dgContracts_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedContractDataRow == null || !Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedContractDataRow["ContractType"], (object) Enums.QuoteType.Contract_Opt_1.ToString(), false))
        return;
      App.ShowForm(typeof (FRMContractOriginal), true, new object[4]
      {
        (object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"])),
        this.SelectedContractDataRow["CustomerID"],
        (object) 0,
        (object) this
      }, false);
    }

    private void btnRenew_Click(object sender, EventArgs e)
    {
      if (this.SelectedContractDataRow != null)
      {
        if ((uint) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["NewContractID"])) > 0U)
        {
          if (App.ShowMessage("This contract has already been renewed. Would you like to reprint the renewal document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractType"])), Enums.QuoteType.Contract_Opt_1.ToString(), false) == 0)
          {
            int newIdByOldId = App.DB.ContractManager.ContractRenewals_GetNewID_ByOldID(Conversions.ToInteger(this.SelectedContractDataRow["ContractID"]), 1);
            DataTable dataTable = App.DB.ContractOriginal.ProcessContract(newIdByOldId);
            if (dataTable == null)
              return;
            Printing printing = new Printing((object) new ArrayList()
            {
              (object) dataTable
            }, "", Enums.SystemDocumentType.ContractOption1, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
          }
        }
        else
          App.ShowForm(typeof (FRMContractRenewal), true, new object[3]
          {
            this.SelectedContractDataRow["ContractType"],
            this.SelectedContractDataRow["ContractID"],
            (object) this
          }, false);
      }
    }

    private void btnPrintExpiryLetter_Click(object sender, EventArgs e)
    {
      this.pbStatus.Value = 0;
      this.pbStatus.Maximum = checked (((DataView) this.dgContracts.DataSource).Count + ((DataView) this.dgContracts.DataSource).Count + 5);
      string ContractIDs = "";
      int num1 = checked (((DataView) this.dgContracts.DataSource).Count - 1);
      int num2 = 0;
      while (num2 <= num1)
      {
        this.dgContracts.CurrentRowIndex = num2;
        ContractIDs = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) ContractIDs, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(this.SelectedContractDataRow["ContractID"], (object) ",")));
        checked { ++num2; }
      }
      if (ContractIDs.Length > 0)
        ContractIDs = ContractIDs.Substring(0, checked (ContractIDs.Length - 1));
      DataView addresses = App.DB.ContractManager.Contracts_GetAddresses(ContractIDs);
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add("ContractID");
      dataTable.Columns.Add("ContractReference");
      dataTable.Columns.Add("Name");
      dataTable.Columns.Add("Address1");
      dataTable.Columns.Add("Address2");
      dataTable.Columns.Add("Address3");
      dataTable.Columns.Add("Address4");
      dataTable.Columns.Add("Address5");
      dataTable.Columns.Add("Postcode");
      dataTable.Columns.Add("ContractEndDate");
      dataTable.Columns.Add("Cheque");
      dataTable.Columns.Add("CreditCard");
      dataTable.Columns.Add("DirectDebit");
      dataTable.Columns.Add("ContractType");
      dataTable.Columns.Add("SiteAddress1");
      int num3 = checked (((DataView) this.dgContracts.DataSource).Count - 1);
      int row1 = 0;
      while (row1 <= num3)
      {
        this.dgContracts.CurrentRowIndex = row1;
        DataRow row2 = dataTable.NewRow();
        row2["ContractID"] = RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"]);
        row2["ContractReference"] = RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractReference"]);
        row2["ContractEndDate"] = RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractEndDate"]);
        row2["Cheque"] = RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["Cheque"]);
        row2["CreditCard"] = RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["CreditCard"]);
        row2["DirectDebit"] = RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["DirectDebit"]);
        row2["ContractType"] = RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["Type"]);
        row2["SiteAddress1"] = RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["SiteAddress1"]);
        if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(this.SelectedContractDataRow["CustomerID"], (object) Enums.Customer.Domestic, false))
        {
          row2["Name"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["SiteName"]));
          row2["Address1"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["SiteAddress1"]));
          row2["Address2"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["SiteAddress2"]));
          row2["Address3"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["SiteAddress3"]));
          row2["Address4"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["SiteAddress4"]));
          row2["Address5"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["SiteAddress5"]));
          row2["Postcode"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["SitePostcode"]));
        }
        else
        {
          DataRow[] dataRowArray = addresses.Table.Select(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Type='HQ' AND ContractID=", this.SelectedContractDataRow["ContractID"])));
          if (dataRowArray.Length > 0)
          {
            row2["Name"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["Name"]));
            row2["Address1"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["Address1"]));
            row2["Address2"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["Address2"]));
            row2["Address3"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["Address3"]));
            row2["Address4"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["Address4"]));
            row2["Address5"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["Address5"]));
            row2["Postcode"] = (object) Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(dataRowArray[0]["Postcode"]));
          }
          else
          {
            row2["Name"] = (object) "";
            row2["Address1"] = (object) "";
            row2["Address2"] = (object) "";
            row2["Address3"] = (object) "";
            row2["Address4"] = (object) "";
            row2["Address5"] = (object) "";
            row2["Postcode"] = (object) "";
          }
        }
        dataTable.Rows.Add(row2);
        this.dgContracts.UnSelect(row1);
        this.MoveProgressOn(false);
        checked { ++row1; }
      }
      Printing printing = new Printing((object) new ArrayList()
      {
        (object) dataTable,
        (object) this
      }, "Contract_Expiry_Letter", Enums.SystemDocumentType.ContractExpiry, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      int num4 = checked (((DataView) this.dgContracts.DataSource).Count - 1);
      int num5 = 0;
      while (num5 <= num4)
      {
        this.dgContracts.CurrentRowIndex = num5;
        App.DB.ExecuteScalar("UPDATE tblContractOriginal SET Printed = 1 WHERE ContractID = " + Conversions.ToString(Conversions.ToInteger(this.SelectedContractDataRow["ContractID"])), true, false);
        checked { ++num5; }
      }
      this.MoveProgressOn(true);
    }

    private void dgContracts_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgContracts.HitTest(e.X, e.Y);
      if (hitTestInfo.Type == DataGrid.HitTestType.Cell)
      {
        if (hitTestInfo.Column == 0)
          this.SelectedContractDataRow["Tick"] = (object) !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["tick"]));
        if (hitTestInfo.Column == 1 && !Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContactMade"])))
        {
          FRMGenDropBox frmGenDropBox1 = new FRMGenDropBox();
          DataTable table = App.DB.ContactAttempts.ContactMethod_GetAll().Table;
          frmGenDropBox1.cbo2.Items.Clear();
          DataTable DT = new DataTable();
          DT.Columns.Add(new DataColumn("ValueMember"));
          DT.Columns.Add(new DataColumn("DisplayMember"));
          DT.Columns.Add(new DataColumn("Deleted"));
          IEnumerator enumerator;
          try
          {
            enumerator = table.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRow current = (DataRow) enumerator.Current;
              DT.Rows.Add((object[]) new string[3]
              {
                Conversions.ToString(current["ContactMethodID"]),
                Conversions.ToString(current["Name"]),
                "0"
              });
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          FRMGenDropBox frmGenDropBox2 = frmGenDropBox1;
          ComboBox cbo2 = frmGenDropBox2.cbo2;
          Combo.SetUpCombo(ref cbo2, DT, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
          frmGenDropBox2.cbo2 = cbo2;
          frmGenDropBox1.cbo1.Visible = false;
          frmGenDropBox1.cbo2.Visible = true;
          frmGenDropBox1.lblTop.Text = "Please select method of contact";
          frmGenDropBox1.lblMiddle.Text = "";
          frmGenDropBox1.lblref.Text = "";
          frmGenDropBox1.txtref.Visible = false;
          int num = (int) frmGenDropBox1.ShowDialog();
          if (frmGenDropBox1.DialogResult == DialogResult.Cancel)
            return;
          ContactAttempt contactAttempt1 = new ContactAttempt();
          ContactAttempt contactAttempt2 = contactAttempt1;
          contactAttempt2.ContactMethedID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(frmGenDropBox1.cbo2));
          contactAttempt2.LinkID = 37;
          contactAttempt2.LinkRef = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedContractDataRow["ContractID"]));
          contactAttempt2.ContactMade = DateAndTime.Now;
          contactAttempt2.Notes = "";
          contactAttempt2.ContactMadeByUserId = App.loggedInUser.UserID;
          if (App.DB.ContactAttempts.Insert(contactAttempt1).ContactAttemptID > 0)
          {
            this.SelectedContractDataRow["ContactMade"] = (object) true;
            this.SelectedContractDataRow["DateContactMade"] = (object) DateAndTime.Now;
          }
        }
      }
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
      if (this.Contracts == null || this.Contracts.Count <= 0)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.Contracts.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) 1;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnDeselectAll_Click(object sender, EventArgs e)
    {
      if (this.Contracts == null || this.Contracts.Count <= 0)
        return;
      IEnumerator enumerator;
      try
      {
        enumerator = this.Contracts.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
          ((DataRow) enumerator.Current)["tick"] = (object) 0;
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void btnActivate_Click(object sender, EventArgs e)
    {
      List<int> intList = new List<int>();
      if (App.ShowMessage("This will set the status of the selected contracts to active. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.Contracts.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRowView current1 = (DataRowView) enumerator1.Current;
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current1["tick"])))
          {
            ContractOriginal oContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(current1["ContractID"]));
            DataView allContractId = App.DB.ContractOriginalSite.GetAll_ContractID(oContract.ContractID, oContract.CustomerID);
            if (oContract != null)
            {
              if (oContract.Exists)
              {
                IEnumerator enumerator2;
                try
                {
                  enumerator2 = allContractId.Table.Rows.GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRow current2 = (DataRow) enumerator2.Current;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current2["ContractSiteID"], (object) 0, false))
                      App.DB.ContractOriginalSite.ActiveInactive(Conversions.ToInteger(current2["ContractSiteID"]), false);
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
                intList.Add(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(current1["ContractID"])));
              }
            }
            oContract.SetContractStatusID = (object) 3;
            App.DB.ContractOriginal.Update(oContract);
          }
        }
      }
      finally
      {
        if (enumerator1 is IDisposable)
          (enumerator1 as IDisposable).Dispose();
      }
      if (intList.Count > 0)
      {
        Printing printing = new Printing((object) intList, "Certificates", Enums.SystemDocumentType.ContractOption1, true, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
      }
      this.PopulateDatagrid();
    }

    private void btnDeActive_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage("This will set the status of the selected contracts to inactive. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      IEnumerator enumerator1;
      try
      {
        enumerator1 = this.Contracts.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          DataRowView current1 = (DataRowView) enumerator1.Current;
          if (Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(current1["tick"])))
          {
            ContractOriginal oContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(current1["ContractID"]));
            DataView allContractId = App.DB.ContractOriginalSite.GetAll_ContractID(oContract.ContractID, oContract.CustomerID);
            IEnumerator enumerator2;
            if (oContract != null)
            {
              if (oContract.Exists)
              {
                try
                {
                  enumerator2 = allContractId.Table.Rows.GetEnumerator();
                  while (enumerator2.MoveNext())
                  {
                    DataRow current2 = (DataRow) enumerator2.Current;
                    if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectGreater(current2["ContractSiteID"], (object) 0, false))
                      App.DB.ContractOriginalSite.ActiveInactive(Conversions.ToInteger(current2["ContractSiteID"]), true);
                  }
                }
                finally
                {
                  if (enumerator2 is IDisposable)
                    (enumerator2 as IDisposable).Dispose();
                }
              }
            }
            oContract.SetContractStatusID = (object) 4;
            oContract.CancelledDate = DateAndTime.Now;
            App.DB.ContractOriginal.Update(oContract);
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

    public void PopulateDatagrid()
    {
      try
      {
        if (this.get_GetParameter(0) == null)
        {
          DateTime date = Conversions.ToDate("1900-01-01");
          if (!this.cbxAllVisitsComplete.Checked && (uint) DateTime.Compare(this.dtpFrom.Value, DateTime.MinValue) > 0U)
            date = this.dtpFrom.Value;
          this.Contracts = App.DB.ContractManager.Contracts_GetAll(date);
          this.RunFilter();
          this.grpContracts.Text = "(" + Conversions.ToString(this.Contracts.Count) + " records) Double Click To View / Edit";
        }
        else
        {
          this.Contracts = (DataView) this.get_GetParameter(0);
          this.grpFilter.Enabled = false;
        }
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
      this.theCustomer = (FSM.Entity.Customers.Customer) null;
      ComboBox cboType = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType, Conversions.ToString(0));
      this.cboType = cboType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(0));
      this.cboStatus = cboStatus;
      this.txtContractReference.Text = "";
      this.cbxContractExpiryDate.Checked = true;
      this.dtpFrom.Value = DateAndTime.Today;
      this.dtpTo.Value = DateAndTime.Today.AddMonths(1);
      this.dtpFrom.Enabled = true;
      this.dtpTo.Enabled = true;
      this.grpFilter.Enabled = true;
      this.cbxAllVisitsComplete.Checked = false;
      this.cbxCancelledDate.Checked = false;
    }

    private void RunFilter()
    {
      if (this.Contracts == null)
        return;
      string str = "Deleted = 0 ";
      if (this.theCustomer != null)
        str += " AND CustomerID = " + Conversions.ToString(this.theCustomer.CustomerID);
      if ((uint) this.txtContractReference.Text.Trim().Length > 0U)
        str = str + " AND ContractReference LIKE '" + this.txtContractReference.Text.Trim() + "%'";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboType)) != 0.0)
        str = str + " AND ContractTypeID = " + Combo.get_GetSelectedItemValue(this.cboType);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboRegion)) != 0.0)
        str = str + " AND RegionID = " + Combo.get_GetSelectedItemValue(this.cboRegion);
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) != 0.0)
        str += " AND ContractStatusID = " + Combo.get_GetSelectedItemValue(this.cboStatus);
      if (!this.cbxDoNotRenew.Checked)
        str += " AND DoNotRenew = 0";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.CboRenewal)) != 0.0)
      {
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.CboRenewal)) == 3.0)
          str += " AND Renewed = 'Renewed'";
        else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.CboRenewal)) == 4.0)
          str += " AND Renewed = 'Not Renewed'";
      }
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboInvoiceFrequency)) != 0.0)
        str += " AND InvoiceFrequencyID = " + Combo.get_GetSelectedItemValue(this.cboInvoiceFrequency);
      if (this.cbxContractExpiryDate.Checked)
        str = str + " AND ContractEndDate >= '" + Strings.Format((object) this.dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND ContractEndDate <= '" + Strings.Format((object) this.dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
      if (this.chxStartedBetween.Checked)
        str = str + " AND ContractStartDate >= '" + Strings.Format((object) this.dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND ContractStartDate <= '" + Strings.Format((object) this.dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
      if (this.cbxCancelledDate.Checked)
        str = str + " AND CancelledDate >= '" + Strings.Format((object) this.dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND CancelledDate <= '" + Strings.Format((object) this.dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
      if (this.cbxAllVisitsComplete.Checked)
        str += " AND VisitsNotUploaded= 0";
      this.Contracts.RowFilter = str;
    }

    public void Export()
    {
      DataTable dtData = new DataTable();
      dtData.Columns.Add("Property");
      dtData.Columns.Add("SitePostcode");
      dtData.Columns.Add("ContractReference");
      dtData.Columns.Add("ContractType");
      dtData.Columns.Add("ContractStatus");
      dtData.Columns.Add("ContractStartDate", typeof (DateTime));
      dtData.Columns.Add("ContractEndDate", typeof (DateTime));
      dtData.Columns.Add("ContractPrice", typeof (double));
      dtData.Columns.Add("VisitsNotUploaded");
      dtData.Columns.Add("Renewed");
      dtData.Columns.Add("Customer");
      dtData.Columns.Add("SiteEmail");
      dtData.Columns.Add("CancelledDate", typeof (DateTime));
      dtData.Columns.Add("CancelledReason");
      dtData.Columns.Add("InvoiceFrequencyID");
      dtData.Columns.Add("GasSupplyPipework");
      dtData.Columns.Add("PlumbingDrainage");
      dtData.Columns.Add("WindowLockPest");
      dtData.Columns.Add("NoOfAppliancesCovered");
      dtData.Columns.Add("NoOfPrimaryAppliancesCovered");
      dtData.Columns.Add("NoOfAdditionalAppliancesCovered");
      dtData.Columns.Add("InvoiceFrequency");
      dtData.Columns.Add("CustomerType");
      dtData.Columns.Add("NoMarketing");
      IEnumerator enumerator;
      try
      {
        enumerator = ((DataView) this.dgContracts.DataSource).GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRowView current = (DataRowView) enumerator.Current;
          DataRow row = dtData.NewRow();
          row["Customer"] = RuntimeHelpers.GetObjectValue(current["Customer"]);
          row["ContractReference"] = RuntimeHelpers.GetObjectValue(current["ContractReference"]);
          row["ContractType"] = RuntimeHelpers.GetObjectValue(current["ContractType"]);
          row["ContractStatus"] = RuntimeHelpers.GetObjectValue(current["ContractStatus"]);
          row["ContractStartDate"] = RuntimeHelpers.GetObjectValue(current["ContractStartDate"]);
          row["ContractEndDate"] = RuntimeHelpers.GetObjectValue(current["ContractEndDate"]);
          row["ContractPrice"] = RuntimeHelpers.GetObjectValue(current["ContractPrice"]);
          row["VisitsNotUploaded"] = RuntimeHelpers.GetObjectValue(current["VisitsNotUploaded"]);
          row["Renewed"] = RuntimeHelpers.GetObjectValue(current["Renewed"]);
          row["Property"] = RuntimeHelpers.GetObjectValue(current["Property"]);
          row["SitePostcode"] = RuntimeHelpers.GetObjectValue(current["SitePostcode"]);
          row["SiteEmail"] = RuntimeHelpers.GetObjectValue(current["SiteEmail"]);
          row["CancelledDate"] = RuntimeHelpers.GetObjectValue(current["CancelledDate"]);
          row["CancelledReason"] = RuntimeHelpers.GetObjectValue(current["CancelledReason"]);
          row["InvoiceFrequencyID"] = RuntimeHelpers.GetObjectValue(current["InvoiceFrequencyID"]);
          row["GasSupplyPipework"] = RuntimeHelpers.GetObjectValue(current["GasSupplyPipework"]);
          row["PlumbingDrainage"] = RuntimeHelpers.GetObjectValue(current["PlumbingDrainage"]);
          row["WindowLockPest"] = RuntimeHelpers.GetObjectValue(current["WindowLockPest"]);
          row["NoOfAppliancesCovered"] = RuntimeHelpers.GetObjectValue(current["NoOfAppliancesCovered"]);
          row["NoOfPrimaryAppliancesCovered"] = RuntimeHelpers.GetObjectValue(current["NoOfPrimaryAppliancesCovered"]);
          row["NoOfAdditionalAppliancesCovered"] = RuntimeHelpers.GetObjectValue(current["NoOfAdditionalAppliancesCovered"]);
          row["InvoiceFrequency"] = RuntimeHelpers.GetObjectValue(current["InvoiceFrequency"]);
          row["CustomerType"] = RuntimeHelpers.GetObjectValue(current["NoOfContracts"]);
          row["NoMarketing"] = RuntimeHelpers.GetObjectValue(current["SiteNoMarketing"]);
          dtData.Rows.Add(row);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      ExportHelper.Export(dtData, "Contracts List", Enums.ExportType.XLS);
    }

    public void MoveProgressOn(bool toMaximum = false)
    {
      if (toMaximum)
      {
        this.pbStatus.Value = this.pbStatus.Maximum;
      }
      else
      {
        ProgressBar pbStatus;
        int num = checked ((pbStatus = this.pbStatus).Value + 1);
        pbStatus.Value = num;
      }
      Application.DoEvents();
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      this.PopulateDatagrid();
      Cursor.Current = Cursors.Default;
    }
  }
}
