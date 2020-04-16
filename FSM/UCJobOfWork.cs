// Decompiled with JetBrains decompiler
// Type: FSM.UCJobOfWork
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.ContractAlternativeSiteJobOfWorks;
using FSM.Entity.Sys;
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
  public class UCJobOfWork : UCBase, IUserControl
  {
    private IContainer components;
    private UCContractAlternativeSite _onControl;
    private ContractAlternativeSiteJobOfWork _CurrentJobOfWork;
    private DataView _JobItemsAddedDataView;
    private DataView _Visits;
    private DataView _ScheduleOfRatesDataview;
    private bool _isLoading;

    public UCJobOfWork()
    {
      this.Load += new EventHandler(this.UCJobOfWork_Load);
      this._onControl = (UCContractAlternativeSite) null;
      this._isLoading = false;
      this.InitializeComponent();
      this.SetupJobItemsDataGrid();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnRemoveFromJobOfWork
    {
      get
      {
        return this._btnRemoveFromJobOfWork;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveFromJobOfWork_Click);
        Button removeFromJobOfWork1 = this._btnRemoveFromJobOfWork;
        if (removeFromJobOfWork1 != null)
          removeFromJobOfWork1.Click -= eventHandler;
        this._btnRemoveFromJobOfWork = value;
        Button removeFromJobOfWork2 = this._btnRemoveFromJobOfWork;
        if (removeFromJobOfWork2 == null)
          return;
        removeFromJobOfWork2.Click += eventHandler;
      }
    }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgVisits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFirstVisitDate
    {
      get
      {
        return this._dtpFirstVisitDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpFirstVisitDate_LostFocus);
        DateTimePicker dtpFirstVisitDate1 = this._dtpFirstVisitDate;
        if (dtpFirstVisitDate1 != null)
          dtpFirstVisitDate1.LostFocus -= eventHandler;
        this._dtpFirstVisitDate = value;
        DateTimePicker dtpFirstVisitDate2 = this._dtpFirstVisitDate;
        if (dtpFirstVisitDate2 == null)
          return;
        dtpFirstVisitDate2.LostFocus += eventHandler;
      }
    }

    internal virtual Label lblFirstVisitDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgJobItemsAdded
    {
      get
      {
        return this._dgJobItemsAdded;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        MouseEventHandler mouseEventHandler = new MouseEventHandler(this.dgJobItemsAdded_MouseUp);
        DataGrid dgJobItemsAdded1 = this._dgJobItemsAdded;
        if (dgJobItemsAdded1 != null)
          dgJobItemsAdded1.MouseUp -= mouseEventHandler;
        this._dgJobItemsAdded = value;
        DataGrid dgJobItemsAdded2 = this._dgJobItemsAdded;
        if (dgJobItemsAdded2 == null)
          return;
        dgJobItemsAdded2.MouseUp += mouseEventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMileageCostPerVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAverageMileage
    {
      get
      {
        return this._txtAverageMileage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtAverageMileage_LostFocus);
        TextBox txtAverageMileage1 = this._txtAverageMileage;
        if (txtAverageMileage1 != null)
          txtAverageMileage1.LostFocus -= eventHandler;
        this._txtAverageMileage = value;
        TextBox txtAverageMileage2 = this._txtAverageMileage;
        if (txtAverageMileage2 == null)
          return;
        txtAverageMileage2.LostFocus += eventHandler;
      }
    }

    internal virtual TextBox txtCostPerMile
    {
      get
      {
        return this._txtCostPerMile;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtCostPerMile_Focus);
        TextBox txtCostPerMile1 = this._txtCostPerMile;
        if (txtCostPerMile1 != null)
          txtCostPerMile1.LostFocus -= eventHandler;
        this._txtCostPerMile = value;
        TextBox txtCostPerMile2 = this._txtCostPerMile;
        if (txtCostPerMile2 == null)
          return;
        txtCostPerMile2.LostFocus += eventHandler;
      }
    }

    internal virtual CheckBox chkIncludeMileage
    {
      get
      {
        return this._chkIncludeMileage;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkIncludeMileage_CheckedChanged);
        CheckBox chkIncludeMileage1 = this._chkIncludeMileage;
        if (chkIncludeMileage1 != null)
          chkIncludeMileage1.CheckedChanged -= eventHandler;
        this._chkIncludeMileage = value;
        CheckBox chkIncludeMileage2 = this._chkIncludeMileage;
        if (chkIncludeMileage2 == null)
          return;
        chkIncludeMileage2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRatesTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkRates
    {
      get
      {
        return this._chkRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkRates_CheckedChanged);
        CheckBox chkRates1 = this._chkRates;
        if (chkRates1 != null)
          chkRates1.CheckedChanged -= eventHandler;
        this._chkRates = value;
        CheckBox chkRates2 = this._chkRates;
        if (chkRates2 == null)
          return;
        chkRates2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTotalSitePrice
    {
      get
      {
        return this._txtTotalSitePrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtTotalSitePrice_LostFocus);
        TextBox txtTotalSitePrice1 = this._txtTotalSitePrice;
        if (txtTotalSitePrice1 != null)
          txtTotalSitePrice1.LostFocus -= eventHandler;
        this._txtTotalSitePrice = value;
        TextBox txtTotalSitePrice2 = this._txtTotalSitePrice;
        if (txtTotalSitePrice2 == null)
          return;
        txtTotalSitePrice2.LostFocus += eventHandler;
      }
    }

    internal virtual GroupBox grpScheduleOfRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSiteScheduleOfRates
    {
      get
      {
        return this._btnSiteScheduleOfRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSiteScheduleOfRates_Click);
        Button siteScheduleOfRates1 = this._btnSiteScheduleOfRates;
        if (siteScheduleOfRates1 != null)
          siteScheduleOfRates1.Click -= eventHandler;
        this._btnSiteScheduleOfRates = value;
        Button siteScheduleOfRates2 = this._btnSiteScheduleOfRates;
        if (siteScheduleOfRates2 == null)
          return;
        siteScheduleOfRates2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtQuantityPerVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAddRates
    {
      get
      {
        return this._btnAddRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddRates_Click);
        Button btnAddRates1 = this._btnAddRates;
        if (btnAddRates1 != null)
          btnAddRates1.Click -= eventHandler;
        this._btnAddRates = value;
        Button btnAddRates2 = this._btnAddRates;
        if (btnAddRates2 == null)
          return;
        btnAddRates2.Click += eventHandler;
      }
    }

    internal virtual Button btnRemoveRates
    {
      get
      {
        return this._btnRemoveRates;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnRemoveRates_Click);
        Button btnRemoveRates1 = this._btnRemoveRates;
        if (btnRemoveRates1 != null)
          btnRemoveRates1.Click -= eventHandler;
        this._btnRemoveRates = value;
        Button btnRemoveRates2 = this._btnRemoveRates;
        if (btnRemoveRates2 == null)
          return;
        btnRemoveRates2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboScheduleOfRatesCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblScheduleOfRatesCategoryID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDescriptionRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPrice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgScheduleOfRates { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPricePerVisit
    {
      get
      {
        return this._txtPricePerVisit;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPricePerVisit_LostFocus);
        TextBox txtPricePerVisit1 = this._txtPricePerVisit;
        if (txtPricePerVisit1 != null)
          txtPricePerVisit1.LostFocus -= eventHandler;
        this._txtPricePerVisit = value;
        TextBox txtPricePerVisit2 = this._txtPricePerVisit;
        if (txtPricePerVisit2 == null)
          return;
        txtPricePerVisit2.LostFocus += eventHandler;
      }
    }

    internal virtual Label lblPricePerVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtItemTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnRemoveFromJobOfWork = new Button();
      this.Label3 = new Label();
      this.dgVisits = new DataGrid();
      this.dgJobItemsAdded = new DataGrid();
      this.dtpFirstVisitDate = new DateTimePicker();
      this.lblFirstVisitDate = new Label();
      this.Label1 = new Label();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.Label2 = new Label();
      this.txtMileageCostPerVisit = new TextBox();
      this.txtAverageMileage = new TextBox();
      this.txtCostPerMile = new TextBox();
      this.chkIncludeMileage = new CheckBox();
      this.Label8 = new Label();
      this.txtRatesTotal = new TextBox();
      this.chkRates = new CheckBox();
      this.Label6 = new Label();
      this.txtTotalSitePrice = new TextBox();
      this.grpScheduleOfRates = new GroupBox();
      this.btnSiteScheduleOfRates = new Button();
      this.txtQuantityPerVisit = new TextBox();
      this.Label7 = new Label();
      this.btnAddRates = new Button();
      this.btnRemoveRates = new Button();
      this.cboScheduleOfRatesCategoryID = new ComboBox();
      this.lblScheduleOfRatesCategoryID = new Label();
      this.txtCode = new TextBox();
      this.lblCode = new Label();
      this.txtDescriptionRate = new TextBox();
      this.lblDescription = new Label();
      this.txtPrice = new TextBox();
      this.lblPrice = new Label();
      this.dgScheduleOfRates = new DataGrid();
      this.txtPricePerVisit = new TextBox();
      this.lblPricePerVisit = new Label();
      this.Label9 = new Label();
      this.txtItemTotal = new TextBox();
      this.dgVisits.BeginInit();
      this.dgJobItemsAdded.BeginInit();
      this.grpScheduleOfRates.SuspendLayout();
      this.dgScheduleOfRates.BeginInit();
      this.SuspendLayout();
      this.btnRemoveFromJobOfWork.UseVisualStyleBackColor = true;
      this.btnRemoveFromJobOfWork.Location = new System.Drawing.Point(352, 8);
      this.btnRemoveFromJobOfWork.Name = "btnRemoveFromJobOfWork";
      this.btnRemoveFromJobOfWork.Size = new Size(96, 23);
      this.btnRemoveFromJobOfWork.TabIndex = 0;
      this.btnRemoveFromJobOfWork.Text = "Remove";
      this.Label3.Location = new System.Drawing.Point(8, 8);
      this.Label3.Name = "Label3";
      this.Label3.TabIndex = 51;
      this.Label3.Text = "Job Items Added";
      this.dgVisits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgVisits.DataMember = "";
      this.dgVisits.HeaderForeColor = SystemColors.ControlText;
      this.dgVisits.Location = new System.Drawing.Point(424, 224);
      this.dgVisits.Name = "dgVisits";
      this.dgVisits.Size = new Size(456, 88);
      this.dgVisits.TabIndex = 46;
      this.dgJobItemsAdded.DataMember = "";
      this.dgJobItemsAdded.HeaderForeColor = SystemColors.ControlText;
      this.dgJobItemsAdded.Location = new System.Drawing.Point(8, 32);
      this.dgJobItemsAdded.Name = "dgJobItemsAdded";
      this.dgJobItemsAdded.Size = new Size(440, 160);
      this.dgJobItemsAdded.TabIndex = 1;
      this.dtpFirstVisitDate.CalendarFont = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpFirstVisitDate.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dtpFirstVisitDate.Format = DateTimePickerFormat.Short;
      this.dtpFirstVisitDate.Location = new System.Drawing.Point(104, 200);
      this.dtpFirstVisitDate.Name = "dtpFirstVisitDate";
      this.dtpFirstVisitDate.Size = new Size(96, 21);
      this.dtpFirstVisitDate.TabIndex = 3;
      this.dtpFirstVisitDate.Tag = (object) "ContractSite.FirstVisitDate";
      this.dtpFirstVisitDate.Value = new DateTime(2007, 6, 18, 15, 21, 39, 569);
      this.lblFirstVisitDate.BackColor = Color.White;
      this.lblFirstVisitDate.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblFirstVisitDate.Location = new System.Drawing.Point(8, 202);
      this.lblFirstVisitDate.Name = "lblFirstVisitDate";
      this.lblFirstVisitDate.Size = new Size(96, 16);
      this.lblFirstVisitDate.TabIndex = 48;
      this.lblFirstVisitDate.Text = "First Visit Date";
      this.Label1.Location = new System.Drawing.Point(424, 208);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 16);
      this.Label1.TabIndex = 53;
      this.Label1.Text = "PPM Scheduled";
      this.Label5.Location = new System.Drawing.Point(8, 223);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(102, 21);
      this.Label5.TabIndex = 78;
      this.Label5.Text = "Mileage Per Visit";
      this.Label5.TextAlign = ContentAlignment.MiddleLeft;
      this.Label4.Location = new System.Drawing.Point(208, 223);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(82, 21);
      this.Label4.TabIndex = 77;
      this.Label4.Text = "Price Per Mile";
      this.Label4.TextAlign = ContentAlignment.MiddleLeft;
      this.Label2.Location = new System.Drawing.Point(208, 247);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(136, 21);
      this.Label2.TabIndex = 76;
      this.Label2.Text = "Mileage Total Per Visit";
      this.Label2.TextAlign = ContentAlignment.MiddleLeft;
      this.txtMileageCostPerVisit.Enabled = false;
      this.txtMileageCostPerVisit.Location = new System.Drawing.Point(344, 247);
      this.txtMileageCostPerVisit.Name = "txtMileageCostPerVisit";
      this.txtMileageCostPerVisit.Size = new Size(72, 21);
      this.txtMileageCostPerVisit.TabIndex = 8;
      this.txtMileageCostPerVisit.Text = "";
      this.txtAverageMileage.Location = new System.Drawing.Point(128, 223);
      this.txtAverageMileage.Name = "txtAverageMileage";
      this.txtAverageMileage.Size = new Size(72, 21);
      this.txtAverageMileage.TabIndex = 5;
      this.txtAverageMileage.Text = "0";
      this.txtCostPerMile.Location = new System.Drawing.Point(344, 223);
      this.txtCostPerMile.Name = "txtCostPerMile";
      this.txtCostPerMile.Size = new Size(72, 21);
      this.txtCostPerMile.TabIndex = 6;
      this.txtCostPerMile.Text = "£0.00";
      this.chkIncludeMileage.Location = new System.Drawing.Point(8, 247);
      this.chkIncludeMileage.Name = "chkIncludeMileage";
      this.chkIncludeMileage.Size = new Size(193, 21);
      this.chkIncludeMileage.TabIndex = 7;
      this.chkIncludeMileage.Text = "Include Mileage in Visit Total";
      this.Label8.Location = new System.Drawing.Point(208, 270);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(128, 23);
      this.Label8.TabIndex = 71;
      this.Label8.Text = "Rate Total Per Visit";
      this.Label8.TextAlign = ContentAlignment.MiddleLeft;
      this.txtRatesTotal.Enabled = false;
      this.txtRatesTotal.Location = new System.Drawing.Point(344, 271);
      this.txtRatesTotal.MaxLength = 50;
      this.txtRatesTotal.Name = "txtRatesTotal";
      this.txtRatesTotal.Size = new Size(72, 21);
      this.txtRatesTotal.TabIndex = 10;
      this.txtRatesTotal.Tag = (object) "SystemScheduleOfRate.Code";
      this.txtRatesTotal.Text = "";
      this.chkRates.Location = new System.Drawing.Point(8, 270);
      this.chkRates.Name = "chkRates";
      this.chkRates.Size = new Size(176, 23);
      this.chkRates.TabIndex = 9;
      this.chkRates.Text = "Include Rates in Visit Total";
      this.Label6.Location = new System.Drawing.Point(208, 294);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(104, 23);
      this.Label6.TabIndex = 80;
      this.Label6.Text = "Total Work Price";
      this.Label6.TextAlign = ContentAlignment.MiddleLeft;
      this.txtTotalSitePrice.Location = new System.Drawing.Point(344, 295);
      this.txtTotalSitePrice.Name = "txtTotalSitePrice";
      this.txtTotalSitePrice.Size = new Size(72, 21);
      this.txtTotalSitePrice.TabIndex = 12;
      this.txtTotalSitePrice.Text = "";
      this.grpScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpScheduleOfRates.Controls.Add((Control) this.btnSiteScheduleOfRates);
      this.grpScheduleOfRates.Controls.Add((Control) this.txtQuantityPerVisit);
      this.grpScheduleOfRates.Controls.Add((Control) this.Label7);
      this.grpScheduleOfRates.Controls.Add((Control) this.btnAddRates);
      this.grpScheduleOfRates.Controls.Add((Control) this.btnRemoveRates);
      this.grpScheduleOfRates.Controls.Add((Control) this.cboScheduleOfRatesCategoryID);
      this.grpScheduleOfRates.Controls.Add((Control) this.lblScheduleOfRatesCategoryID);
      this.grpScheduleOfRates.Controls.Add((Control) this.txtCode);
      this.grpScheduleOfRates.Controls.Add((Control) this.lblCode);
      this.grpScheduleOfRates.Controls.Add((Control) this.txtDescriptionRate);
      this.grpScheduleOfRates.Controls.Add((Control) this.lblDescription);
      this.grpScheduleOfRates.Controls.Add((Control) this.txtPrice);
      this.grpScheduleOfRates.Controls.Add((Control) this.lblPrice);
      this.grpScheduleOfRates.Controls.Add((Control) this.dgScheduleOfRates);
      this.grpScheduleOfRates.Location = new System.Drawing.Point(456, 0);
      this.grpScheduleOfRates.Name = "grpScheduleOfRates";
      this.grpScheduleOfRates.Size = new Size(432, 208);
      this.grpScheduleOfRates.TabIndex = 2;
      this.grpScheduleOfRates.TabStop = false;
      this.grpScheduleOfRates.Text = "Property Contract Schedule Of Rates";
      this.btnSiteScheduleOfRates.Location = new System.Drawing.Point(96, 178);
      this.btnSiteScheduleOfRates.Name = "btnSiteScheduleOfRates";
      this.btnSiteScheduleOfRates.Size = new Size(240, 23);
      this.btnSiteScheduleOfRates.TabIndex = 7;
      this.btnSiteScheduleOfRates.Text = "Add Property Schedule Of Rates";
      this.txtQuantityPerVisit.Location = new System.Drawing.Point(344, 40);
      this.txtQuantityPerVisit.MaxLength = 9;
      this.txtQuantityPerVisit.Name = "txtQuantityPerVisit";
      this.txtQuantityPerVisit.Size = new Size(80, 21);
      this.txtQuantityPerVisit.TabIndex = 4;
      this.txtQuantityPerVisit.Tag = (object) "SystemScheduleOfRate.Price";
      this.txtQuantityPerVisit.Text = "";
      this.Label7.Location = new System.Drawing.Point(264, 40);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(80, 20);
      this.Label7.TabIndex = 48;
      this.Label7.Text = "Qty Per Visit";
      this.btnAddRates.Location = new System.Drawing.Point(8, 178);
      this.btnAddRates.Name = "btnAddRates";
      this.btnAddRates.Size = new Size(72, 23);
      this.btnAddRates.TabIndex = 6;
      this.btnAddRates.Text = "Add";
      this.btnRemoveRates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnRemoveRates.Location = new System.Drawing.Point(352, 180);
      this.btnRemoveRates.Name = "btnRemoveRates";
      this.btnRemoveRates.Size = new Size(72, 23);
      this.btnRemoveRates.TabIndex = 8;
      this.btnRemoveRates.Text = "Remove";
      this.cboScheduleOfRatesCategoryID.Cursor = Cursors.Hand;
      this.cboScheduleOfRatesCategoryID.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboScheduleOfRatesCategoryID.Location = new System.Drawing.Point(88, 16);
      this.cboScheduleOfRatesCategoryID.Name = "cboScheduleOfRatesCategoryID";
      this.cboScheduleOfRatesCategoryID.Size = new Size(171, 21);
      this.cboScheduleOfRatesCategoryID.TabIndex = 0;
      this.cboScheduleOfRatesCategoryID.Tag = (object) "SystemScheduleOfRate.ScheduleOfRatesCategoryID";
      this.lblScheduleOfRatesCategoryID.Location = new System.Drawing.Point(8, 16);
      this.lblScheduleOfRatesCategoryID.Name = "lblScheduleOfRatesCategoryID";
      this.lblScheduleOfRatesCategoryID.Size = new Size(80, 20);
      this.lblScheduleOfRatesCategoryID.TabIndex = 43;
      this.lblScheduleOfRatesCategoryID.Text = "Category";
      this.txtCode.Location = new System.Drawing.Point(88, 40);
      this.txtCode.MaxLength = 50;
      this.txtCode.Name = "txtCode";
      this.txtCode.Size = new Size(171, 21);
      this.txtCode.TabIndex = 1;
      this.txtCode.Tag = (object) "SystemScheduleOfRate.Code";
      this.txtCode.Text = "";
      this.lblCode.Location = new System.Drawing.Point(8, 40);
      this.lblCode.Name = "lblCode";
      this.lblCode.Size = new Size(80, 20);
      this.lblCode.TabIndex = 42;
      this.lblCode.Text = "Code";
      this.txtDescriptionRate.Location = new System.Drawing.Point(88, 64);
      this.txtDescriptionRate.MaxLength = 0;
      this.txtDescriptionRate.Multiline = true;
      this.txtDescriptionRate.Name = "txtDescriptionRate";
      this.txtDescriptionRate.ScrollBars = ScrollBars.Vertical;
      this.txtDescriptionRate.Size = new Size(336, 24);
      this.txtDescriptionRate.TabIndex = 2;
      this.txtDescriptionRate.Tag = (object) "SystemScheduleOfRate.Description";
      this.txtDescriptionRate.Text = "";
      this.lblDescription.Location = new System.Drawing.Point(8, 64);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new Size(80, 20);
      this.lblDescription.TabIndex = 41;
      this.lblDescription.Text = "Description";
      this.txtPrice.Location = new System.Drawing.Point(344, 16);
      this.txtPrice.MaxLength = 9;
      this.txtPrice.Name = "txtPrice";
      this.txtPrice.Size = new Size(80, 21);
      this.txtPrice.TabIndex = 3;
      this.txtPrice.Tag = (object) "SystemScheduleOfRate.Price";
      this.txtPrice.Text = "";
      this.lblPrice.Location = new System.Drawing.Point(264, 16);
      this.lblPrice.Name = "lblPrice";
      this.lblPrice.Size = new Size(80, 20);
      this.lblPrice.TabIndex = 40;
      this.lblPrice.Text = "Price";
      this.dgScheduleOfRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgScheduleOfRates.DataMember = "";
      this.dgScheduleOfRates.HeaderForeColor = SystemColors.ControlText;
      this.dgScheduleOfRates.Location = new System.Drawing.Point(8, 91);
      this.dgScheduleOfRates.Name = "dgScheduleOfRates";
      this.dgScheduleOfRates.Size = new Size(416, 85);
      this.dgScheduleOfRates.TabIndex = 5;
      this.txtPricePerVisit.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPricePerVisit.Location = new System.Drawing.Point(128, 295);
      this.txtPricePerVisit.MaxLength = 9;
      this.txtPricePerVisit.Name = "txtPricePerVisit";
      this.txtPricePerVisit.Size = new Size(72, 21);
      this.txtPricePerVisit.TabIndex = 11;
      this.txtPricePerVisit.Tag = (object) "ContractSite.PricePerVisit";
      this.txtPricePerVisit.Text = "";
      this.lblPricePerVisit.BackColor = Color.White;
      this.lblPricePerVisit.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblPricePerVisit.Location = new System.Drawing.Point(8, 295);
      this.lblPricePerVisit.Name = "lblPricePerVisit";
      this.lblPricePerVisit.Size = new Size(120, 20);
      this.lblPricePerVisit.TabIndex = 83;
      this.lblPricePerVisit.Text = "Total Price Per Visit";
      this.lblPricePerVisit.TextAlign = ContentAlignment.MiddleLeft;
      this.Label9.Location = new System.Drawing.Point(208, 202);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(96, 16);
      this.Label9.TabIndex = 85;
      this.Label9.Text = "Item Total";
      this.Label9.TextAlign = ContentAlignment.MiddleLeft;
      this.txtItemTotal.Enabled = false;
      this.txtItemTotal.Location = new System.Drawing.Point(344, 200);
      this.txtItemTotal.MaxLength = 50;
      this.txtItemTotal.Name = "txtItemTotal";
      this.txtItemTotal.Size = new Size(72, 21);
      this.txtItemTotal.TabIndex = 4;
      this.txtItemTotal.Tag = (object) "SystemScheduleOfRate.Code";
      this.txtItemTotal.Text = "";
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.txtItemTotal);
      this.Controls.Add((Control) this.txtPricePerVisit);
      this.Controls.Add((Control) this.lblPricePerVisit);
      this.Controls.Add((Control) this.grpScheduleOfRates);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.txtTotalSitePrice);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.txtMileageCostPerVisit);
      this.Controls.Add((Control) this.txtAverageMileage);
      this.Controls.Add((Control) this.txtCostPerMile);
      this.Controls.Add((Control) this.chkIncludeMileage);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.txtRatesTotal);
      this.Controls.Add((Control) this.chkRates);
      this.Controls.Add((Control) this.btnRemoveFromJobOfWork);
      this.Controls.Add((Control) this.dgVisits);
      this.Controls.Add((Control) this.dgJobItemsAdded);
      this.Controls.Add((Control) this.dtpFirstVisitDate);
      this.Controls.Add((Control) this.lblFirstVisitDate);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.Label3);
      this.Name = nameof (UCJobOfWork);
      this.Size = new Size(896, 320);
      this.dgVisits.EndInit();
      this.dgJobItemsAdded.EndInit();
      this.grpScheduleOfRates.ResumeLayout(false);
      this.dgScheduleOfRates.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupJobItemsDataGrid();
      this.SetupVisitDataGrid();
      this.SetupScheduleOfRatesDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        object obj;
        return obj;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public event UCJobOfWork.RemovedItemEventHandler RemovedItem;

    public UCContractAlternativeSite OnControl
    {
      get
      {
        return this._onControl;
      }
      set
      {
        this._onControl = value;
      }
    }

    public ContractAlternativeSiteJobOfWork CurrentJobOfWork
    {
      get
      {
        return this._CurrentJobOfWork;
      }
      set
      {
        this._CurrentJobOfWork = value;
        this.txtCostPerMile.Text = Strings.Format((object) App.DB.CustomerCharge.CustomerCharge_GetForCustomer(this.OnControl.CurrentContractSite.PropertyID).MileageRate, "C");
        this.txtPricePerVisit.Text = "£0.00";
        this.ScheduleOfRatesDataview = this.BuildUpScheduleOfRatesDataview();
        if (this.CurrentJobOfWork == null)
        {
          this.CurrentJobOfWork = new ContractAlternativeSiteJobOfWork();
          this.dtpFirstVisitDate.Value = this.OnControl.CurrentContract.ContractStartDate.AddDays(1.0);
          this.CurrentJobOfWork.FirstVisitDate = this.OnControl.CurrentContract.ContractStartDate.AddDays(1.0);
        }
        this.dtpFirstVisitDate.Value = this.CurrentJobOfWork.FirstVisitDate;
        this.JobItemsAddedDataView = App.DB.ContractAlternativeSiteJobItems.GetAll_For_JobOfWorkID(this.CurrentJobOfWork.ContractSiteJobOfWorkID);
        this.Visits = App.DB.ContractAlternativePPMVisit.GetAll_For_ContractSiteJobOfWorkID(this.CurrentJobOfWork.ContractSiteJobOfWorkID);
        if (this.Visits.Table.Rows.Count > 0)
        {
          this.dtpFirstVisitDate.Enabled = false;
          this.btnRemoveFromJobOfWork.Enabled = false;
        }
        else
        {
          this.dtpFirstVisitDate.Enabled = true;
          this.btnRemoveFromJobOfWork.Enabled = true;
        }
        ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
        Combo.SetUpCombo(ref ofRatesCategoryId, App.DB.Picklists.GetAll(Enums.PickListTypes.ScheduleRatesCategories, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
        this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
        this.Populate(0);
      }
    }

    public DataView JobItemsAddedDataView
    {
      get
      {
        return this._JobItemsAddedDataView;
      }
      set
      {
        this._JobItemsAddedDataView = value;
        this._JobItemsAddedDataView.AllowNew = false;
        this._JobItemsAddedDataView.AllowEdit = false;
        this._JobItemsAddedDataView.AllowDelete = false;
        this._JobItemsAddedDataView.Table.TableName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
        this.dgJobItemsAdded.DataSource = (object) this.JobItemsAddedDataView;
      }
    }

    private DataRow SelectedJobItemsDataRow
    {
      get
      {
        return this.dgJobItemsAdded.CurrentRowIndex != -1 ? this.JobItemsAddedDataView[this.dgJobItemsAdded.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public DataView Visits
    {
      get
      {
        return this._Visits;
      }
      set
      {
        this._Visits = value;
        this._Visits.Table.TableName = Enums.TableNames.tblContractPPMVisit.ToString();
        this._Visits.AllowNew = false;
        this._Visits.AllowEdit = true;
        this._Visits.AllowDelete = false;
        this.dgVisits.DataSource = (object) this.Visits;
      }
    }

    public DataView ScheduleOfRatesDataview
    {
      get
      {
        return this._ScheduleOfRatesDataview;
      }
      set
      {
        this._ScheduleOfRatesDataview = value;
        this._ScheduleOfRatesDataview.Table.TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
        this._ScheduleOfRatesDataview.AllowNew = false;
        this._ScheduleOfRatesDataview.AllowEdit = true;
        this._ScheduleOfRatesDataview.AllowDelete = false;
        this.dgScheduleOfRates.DataSource = (object) this.ScheduleOfRatesDataview;
      }
    }

    private DataRow SelectedRatesDataRow
    {
      get
      {
        return this.dgScheduleOfRates.CurrentRowIndex != -1 ? this.ScheduleOfRatesDataview[this.dgScheduleOfRates.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private bool IsLoading
    {
      get
      {
        return this._isLoading;
      }
      set
      {
        this._isLoading = value;
      }
    }

    public void SetupJobItemsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgJobItemsAdded, false);
      DataGridTableStyle tableStyle = this.dgJobItemsAdded.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Description";
      dataGridLabelColumn1.MappingName = "Description";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "C";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Item Price Per Visit";
      dataGridLabelColumn2.MappingName = "ItemPricePerVisit";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 85;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Visit Frequency";
      dataGridLabelColumn3.MappingName = "VisitFrequency";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Visit Duration";
      dataGridLabelColumn4.MappingName = "VisitDuration";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 90;
      dataGridLabelColumn4.NullText = "";
      dataGridLabelColumn4.Alignment = HorizontalAlignment.Center;
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "C";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Appliances";
      dataGridLabelColumn5.MappingName = "Assets";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 130;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblContractAlternativeSiteJobItems.ToString();
      this.dgJobItemsAdded.TableStyles.Add(tableStyle);
    }

    public void SetupVisitDataGrid()
    {
      Helper.SetUpDataGrid(this.dgVisits, false);
      DataGridTableStyle tableStyle = this.dgVisits.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "dd/MM/yyyy";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Estimated Visit Date";
      dataGridLabelColumn1.MappingName = "EstimatedVisitDate";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 150;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "JobNumber";
      dataGridLabelColumn2.MappingName = "JobNumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Visit Date";
      dataGridLabelColumn3.MappingName = "StartDateTime";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "Not Set";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Engineer";
      dataGridLabelColumn4.MappingName = "Name";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "N/A";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblContractPPMVisit.ToString();
      this.dgVisits.TableStyles.Add(tableStyle);
    }

    public void SetupScheduleOfRatesDataGrid()
    {
      Helper.SetUpDataGrid(this.dgScheduleOfRates, false);
      DataGridTableStyle tableStyle = this.dgScheduleOfRates.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Category";
      dataGridLabelColumn1.MappingName = "Category";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 95;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Code";
      dataGridLabelColumn2.MappingName = "Code";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 75;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Description";
      dataGridLabelColumn3.MappingName = "Description";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 105;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "C";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Unit Price";
      dataGridLabelColumn4.MappingName = "Price";
      dataGridLabelColumn4.ReadOnly = false;
      dataGridLabelColumn4.Width = 60;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Unit Qty Per Visit";
      dataGridLabelColumn5.MappingName = "QtyPerVisit";
      dataGridLabelColumn5.ReadOnly = false;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      tableStyle.ReadOnly = false;
      tableStyle.MappingName = Enums.TableNames.tblSiteScheduleOfRate.ToString();
      this.dgScheduleOfRates.TableStyles.Add(tableStyle);
    }

    private void UCJobOfWork_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnRemoveFromJobOfWork_Click(object sender, EventArgs e)
    {
      if (this.SelectedJobItemsDataRow == null)
        return;
      App.DB.ContractAlternativeSiteJobItems.Update(Conversions.ToInteger(this.SelectedJobItemsDataRow["ContractSiteJobItemID"]), 0);
      this.CalculateItemTotal();
      // ISSUE: reference to a compiler-generated field
      UCJobOfWork.RemovedItemEventHandler removedItemEvent = this.RemovedItemEvent;
      if (removedItemEvent == null)
        return;
      removedItemEvent();
    }

    private void dtpFirstVisitDate_LostFocus(object sender, EventArgs e)
    {
      if (DateTime.Compare(this.dtpFirstVisitDate.Value, this.OnControl.CurrentContract.ContractStartDate) < 0 | DateTime.Compare(this.dtpFirstVisitDate.Value, this.OnControl.CurrentContract.ContractEndDate) > 0)
      {
        int num = (int) App.ShowMessage("First Visit must be inside the contract boundaries", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        this.dtpFirstVisitDate.Value = this.OnControl.CurrentContract.ContractStartDate.AddDays(1.0);
      }
      else
        this.CurrentJobOfWork.FirstVisitDate = this.dtpFirstVisitDate.Value;
    }

    private void dgJobItemsAdded_MouseUp(object sender, MouseEventArgs e)
    {
      DataGrid.HitTestInfo hitTestInfo = this.dgJobItemsAdded.HitTest(e.X, e.Y);
      if (this.SelectedJobItemsDataRow == null || hitTestInfo.Column != 4)
        return;
      App.ShowForm(typeof (FRMJobItemAssets), true, new object[1]
      {
        this.SelectedJobItemsDataRow["ContractSiteJobItemID"]
      }, false);
    }

    private void txtPricePerVisit_LostFocus(object sender, EventArgs e)
    {
      this.txtPricePerVisit.Text = this.txtPricePerVisit.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtPricePerVisit.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtPricePerVisit.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
      this.CalculateSiteTotal();
    }

    private void txtAverageMileage_LostFocus(object sender, EventArgs e)
    {
      this.txtAverageMileage.Text = this.txtAverageMileage.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtAverageMileage.Text) ? Strings.Format((object) Conversions.ToDouble(this.txtAverageMileage.Text), "F") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
      this.CalculateMileageTotal();
      this.CalculateSiteTotal();
      this.CurrentJobOfWork.SetAverageMileage = (object) this.txtAverageMileage.Text.Replace("£", "");
    }

    private void txtCostPerMile_Focus(object sender, EventArgs e)
    {
      this.txtCostPerMile.Text = this.txtCostPerMile.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtCostPerMile.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtCostPerMile.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
      this.CalculateMileageTotal();
      this.CalculateSiteTotal();
      this.CurrentJobOfWork.SetPricePerMile = (object) this.txtCostPerMile.Text.Replace("£", "");
    }

    private void chkIncludeMileage_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkIncludeMileage.Checked)
        this.IncludeMileage();
      else
        this.TakeawayMileage();
      this.CalculateSiteTotal();
      this.CurrentJobOfWork.SetIncludeMileagePrice = (object) this.chkIncludeMileage.Checked;
    }

    private void chkRates_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkRates.Checked)
        this.IncludeRates();
      else
        this.TakeawayRates();
      this.CalculateSiteTotal();
      this.CurrentJobOfWork.SetIncludeRates = (object) this.chkRates.Checked;
    }

    private void btnAddRates_Click(object sender, EventArgs e)
    {
      bool flag = true;
      string str = "";
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboScheduleOfRatesCategoryID)) <= 0.0)
      {
        str = "* Category is missing\r\n";
        flag = false;
      }
      if (this.txtDescriptionRate.Text.Trim().Length == 0)
      {
        str += "* Description is missing\r\n";
        flag = false;
      }
      if (this.txtPrice.Text.Trim().Length == 0)
      {
        str += "* Price is missing\r\n";
        flag = false;
      }
      else if (!Versioned.IsNumeric((object) this.txtPrice.Text))
      {
        str += "* Price must be numeric\r\n";
        flag = false;
      }
      if (this.txtQuantityPerVisit.Text.Trim().Length == 0)
      {
        str += "* Quantity is missing\r\n";
        flag = false;
      }
      else if (!Versioned.IsNumeric((object) this.txtQuantityPerVisit.Text))
      {
        str += "* Qty must be numeric\r\n";
        flag = false;
      }
      if (flag)
      {
        DataRow row = this.ScheduleOfRatesDataview.Table.NewRow();
        row["ScheduleOfRatesCategoryID"] = (object) Combo.get_GetSelectedItemValue(this.cboScheduleOfRatesCategoryID);
        row["Category"] = (object) Combo.get_GetSelectedItemDescription(this.cboScheduleOfRatesCategoryID);
        row["Code"] = (object) this.txtCode.Text;
        row["Description"] = (object) this.txtDescriptionRate.Text;
        row["Price"] = (object) this.txtPrice.Text;
        row["QtyPerVisit"] = (object) this.txtQuantityPerVisit.Text;
        this.ScheduleOfRatesDataview.Table.Rows.Add(row);
        ComboBox ofRatesCategoryId = this.cboScheduleOfRatesCategoryID;
        Combo.SetSelectedComboItem_By_Value(ref ofRatesCategoryId, "0");
        this.cboScheduleOfRatesCategoryID = ofRatesCategoryId;
        this.txtCode.Text = "";
        this.txtDescriptionRate.Text = "";
        this.txtPrice.Text = "";
        this.txtQuantityPerVisit.Text = "";
        this.CalculateRates();
        this.CalculateSiteTotal();
      }
      else
      {
        int num = (int) MessageBox.Show("Please correct the following:\r\n" + str, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnRemoveRates_Click(object sender, EventArgs e)
    {
      if (this.SelectedRatesDataRow == null)
        return;
      if (MessageBox.Show(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "DELETE :", this.SelectedRatesDataRow["Description"])), "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        this.ScheduleOfRatesDataview.Table.Rows.Remove(this.SelectedRatesDataRow);
        this.CalculateRates();
        this.CalculateSiteTotal();
      }
    }

    private void btnSiteScheduleOfRates_Click(object sender, EventArgs e)
    {
      int propertyId = this.OnControl.CurrentContractSite.PropertyID;
      DataView scheduleOfRatesDataview = this.ScheduleOfRatesDataview;
      ref DataView local = ref scheduleOfRatesDataview;
      FRMSiteScheduleOfRateList scheduleOfRateList1 = new FRMSiteScheduleOfRateList(propertyId, ref local, false, false);
      this.ScheduleOfRatesDataview = scheduleOfRatesDataview;
      using (FRMSiteScheduleOfRateList scheduleOfRateList2 = scheduleOfRateList1)
      {
        int num = (int) scheduleOfRateList2.ShowDialog();
      }
      this.dgScheduleOfRates.DataSource = (object) this.ScheduleOfRatesDataview;
      this.CalculateRates();
      this.CalculateSiteTotal();
    }

    private void txtTotalSitePrice_LostFocus(object sender, EventArgs e)
    {
      string str = this.txtTotalSitePrice.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtTotalSitePrice.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtTotalSitePrice.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
      this.txtTotalSitePrice.Text = str;
      this.CurrentJobOfWork.SetTotalSitePrice = (object) str.Replace("£", "");
    }

    private DataView BuildUpScheduleOfRatesDataview()
    {
      return new DataView(new DataTable()
      {
        Columns = {
          "ScheduleOfRatesCategoryID",
          "Category",
          "Code",
          "Description",
          "Price",
          "QtyPerVisit"
        },
        TableName = Enums.TableNames.tblSiteScheduleOfRate.ToString()
      });
    }

    private void IncludeMileage()
    {
      this.txtPricePerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtMileageCostPerVisit.Text.Replace("£", ""))), "C");
    }

    private void TakeawayMileage()
    {
      this.txtPricePerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) - Helper.MakeDoubleValid((object) this.txtMileageCostPerVisit.Text.Replace("£", ""))), "C");
    }

    private void IncludeRates()
    {
      this.txtPricePerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) + Helper.MakeDoubleValid((object) this.txtRatesTotal.Text.Replace("£", ""))), "C");
    }

    private void TakeawayRates()
    {
      this.txtPricePerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) - Helper.MakeDoubleValid((object) this.txtRatesTotal.Text.Replace("£", ""))), "C");
    }

    private void CalculateRates()
    {
      Decimal num1 = new Decimal();
      Decimal num2 = new Decimal();
      if (this.txtRatesTotal.Text.Trim().Length == 0)
        this.txtRatesTotal.Text = "£0.00";
      else
        num1 = Conversions.ToDecimal(this.txtRatesTotal.Text.Replace("£", "0"));
      IEnumerator enumerator;
      try
      {
        enumerator = this.ScheduleOfRatesDataview.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          num2 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, Microsoft.VisualBasic.CompilerServices.Operators.MultiplyObject(current["Price"], current["QtyPerVisit"])));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtRatesTotal.Text = Strings.Format((object) num2, "C");
      if (!this.chkRates.Checked)
        return;
      this.txtPricePerVisit.Text = Conversions.ToString(Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) - Convert.ToDouble(num1));
      this.txtPricePerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) + Convert.ToDouble(num2)), "C");
    }

    private void CalculateMileageTotal()
    {
      Decimal num = new Decimal();
      if (this.txtMileageCostPerVisit.Text.Trim().Length == 0)
        this.txtMileageCostPerVisit.Text = "£0.00";
      else
        num = Conversions.ToDecimal(this.txtMileageCostPerVisit.Text.Replace("£", "0"));
      this.txtMileageCostPerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtAverageMileage.Text) * Helper.MakeDoubleValid((object) this.txtCostPerMile.Text.Replace("£", ""))), "C");
      if (!this.chkIncludeMileage.Checked)
        return;
      this.txtPricePerVisit.Text = Conversions.ToString(Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) - Convert.ToDouble(num));
      this.txtPricePerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) + Conversions.ToDouble(this.txtMileageCostPerVisit.Text.Replace("£", ""))), "C");
    }

    public void CalculateItemTotal()
    {
      Decimal num1 = new Decimal();
      Decimal num2 = new Decimal();
      if (this.txtItemTotal.Text.Trim().Length == 0)
        this.txtItemTotal.Text = "£0.00";
      else
        num1 = Conversions.ToDecimal(this.txtItemTotal.Text.Replace("£", "0"));
      IEnumerator enumerator;
      try
      {
        enumerator = this.JobItemsAddedDataView.Table.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          num2 = Conversions.ToDecimal(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) num2, current["ItemPricePerVisit"]));
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      this.txtItemTotal.Text = Strings.Format((object) num2, "C");
      this.txtPricePerVisit.Text = Conversions.ToString(Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) - Convert.ToDouble(num1));
      this.txtPricePerVisit.Text = Strings.Format((object) (Helper.MakeDoubleValid((object) this.txtPricePerVisit.Text.Replace("£", "")) + Convert.ToDouble(num2)), "C");
      this.CalculateSiteTotal();
    }

    private void CalculateSiteTotal()
    {
      int num = 0;
      string str = this.txtPricePerVisit.Text.Trim().Length != 0 ? (Versioned.IsNumeric((object) this.txtPricePerVisit.Text.Replace("£", "")) ? Strings.Format((object) Conversions.ToDouble(this.txtPricePerVisit.Text.Replace("£", "")), "C") : Strings.Format((object) 0.0, "C")) : Strings.Format((object) 0.0, "C");
      this.txtPricePerVisit.Text = str;
      if (this.SelectedJobItemsDataRow != null)
      {
        switch (Conversions.ToInteger(this.SelectedJobItemsDataRow["VisitFrequencyID"]))
        {
          case 3:
            num = 52;
            break;
          case 4:
            num = 12;
            break;
          case 5:
            num = 4;
            break;
          case 6:
            num = 2;
            break;
          case 7:
            num = 1;
            break;
        }
      }
      this.txtTotalSitePrice.Text = num != 0 ? Strings.Format((object) (Conversions.ToDouble(this.txtPricePerVisit.Text.Replace("£", "")) * (double) num), "C") : "£0.00";
      if (this.IsLoading)
        return;
      this.CurrentJobOfWork.SetPricePerVisit = (object) str.Replace("£", "");
      this.CurrentJobOfWork.SetTotalSitePrice = (object) this.txtTotalSitePrice.Text.Replace("£", "");
    }

    void IUserControl.Populate(int ID = 0)
    {
      this.IsLoading = true;
      this.dtpFirstVisitDate.Value = this.CurrentJobOfWork.FirstVisitDate;
      this.txtAverageMileage.Text = Conversions.ToString(this.CurrentJobOfWork.AverageMileage);
      this.txtCostPerMile.Text = Strings.Format((object) this.CurrentJobOfWork.PricePerMile, "C");
      this.chkIncludeMileage.Checked = this.CurrentJobOfWork.IncludeMileagePrice;
      this.chkRates.Checked = this.CurrentJobOfWork.IncludeRates;
      this.ScheduleOfRatesDataview = App.DB.ContractAlternativeSiteJobOfWork.GetJobOfWorkScheduleOfRates(this.CurrentJobOfWork.ContractSiteJobOfWorkID);
      this.CalculateRates();
      this.CalculateMileageTotal();
      this.CalculateItemTotal();
      this.CalculateSiteTotal();
      this.txtPricePerVisit.Text = Strings.Format((object) this.CurrentJobOfWork.PricePerVisit, "C");
      this.txtTotalSitePrice.Text = Strings.Format((object) this.CurrentJobOfWork.TotalSitePrice, "C");
      this.IsLoading = false;
      this.CurrentJobOfWork.SetPricePerVisit = (object) this.txtPricePerVisit.Text.Replace("£", "");
      this.CurrentJobOfWork.SetTotalSitePrice = (object) this.txtTotalSitePrice.Text.Replace("£", "");
    }

    public bool Save()
    {
      bool flag;
      try
      {
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }

    public delegate void RemovedItemEventHandler();
  }
}
