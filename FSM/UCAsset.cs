// Decompiled with JetBrains decompiler
// Type: FSM.UCAsset
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Assets;
using FSM.Entity.PickLists;
using FSM.Entity.Products;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;

namespace FSM
{
  public class UCAsset : UCBase, IUserControl
  {
    private IContainer components;
    private UCDocumentsList DocumentsControl;
    private Asset _currentAsset;
    private int _LoadProductID;
    private int _LoadSiteID;
    private DataView _jobsTable;
    private int _selectedProductID;

    public UCAsset()
    {
      this.Load += new EventHandler(this.UCAsset_Load);
      this._selectedProductID = 0;
      this.InitializeComponent();
      ComboBox cboGasType = this.cboGasType;
      Combo.SetUpCombo(ref cboGasType, App.DB.Picklists.GetAll(Enums.PickListTypes.GasTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboGasType = cboGasType;
      ComboBox cboFlueType = this.cboFlueType;
      Combo.SetUpCombo(ref cboFlueType, App.DB.Picklists.GetAll(Enums.PickListTypes.FlueTypes, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFlueType = cboFlueType;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl TabControl1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAsset { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDateUnknown
    {
      get
      {
        return this._chkDateUnknown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkDateUnknown_CheckedChanged);
        CheckBox chkDateUnknown1 = this._chkDateUnknown;
        if (chkDateUnknown1 != null)
          chkDateUnknown1.CheckedChanged -= eventHandler;
        this._chkDateUnknown = value;
        CheckBox chkDateUnknown2 = this._chkDateUnknown;
        if (chkDateUnknown2 == null)
          return;
        chkDateUnknown2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label lblProductID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSerialNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSerialNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDateFitted { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLocationID { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLocation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkCertificateLastIssuedUnknown
    {
      get
      {
        return this._chkCertificateLastIssuedUnknown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkCertificateLastIssuedUnknown_CheckedChanged);
        CheckBox lastIssuedUnknown1 = this._chkCertificateLastIssuedUnknown;
        if (lastIssuedUnknown1 != null)
          lastIssuedUnknown1.CheckedChanged -= eventHandler;
        this._chkCertificateLastIssuedUnknown = value;
        CheckBox lastIssuedUnknown2 = this._chkCertificateLastIssuedUnknown;
        if (lastIssuedUnknown2 == null)
          return;
        lastIssuedUnknown2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpCertificateLastIssued { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtBoughtFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSupplierBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDateFitted { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkLastServicedDateUnknown
    {
      get
      {
        return this._chkLastServicedDateUnknown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkLastServiceDateUnknown_CheckedChanged);
        CheckBox servicedDateUnknown1 = this._chkLastServicedDateUnknown;
        if (servicedDateUnknown1 != null)
          servicedDateUnknown1.CheckedChanged -= eventHandler;
        this._chkLastServicedDateUnknown = value;
        CheckBox servicedDateUnknown2 = this._chkLastServicedDateUnknown;
        if (servicedDateUnknown2 == null)
          return;
        servicedDateUnknown2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpLastServicedDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgJobs
    {
      get
      {
        return this._dgJobs;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgJobs_DoubleClick);
        DataGrid dgJobs1 = this._dgJobs;
        if (dgJobs1 != null)
          dgJobs1.DoubleClick -= eventHandler;
        this._dgJobs = value;
        DataGrid dgJobs2 = this._dgJobs;
        if (dgJobs2 == null)
          return;
        dgJobs2.DoubleClick += eventHandler;
      }
    }

    internal virtual Button btnAddJob
    {
      get
      {
        return this._btnAddJob;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAddJob_Click);
        Button btnAddJob1 = this._btnAddJob;
        if (btnAddJob1 != null)
          btnAddJob1.Click -= eventHandler;
        this._btnAddJob = value;
        Button btnAddJob2 = this._btnAddJob;
        if (btnAddJob2 == null)
          return;
        btnAddJob2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpJobs { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpWarrantyEndDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkWarrantyStartDateUnknown
    {
      get
      {
        return this._chkWarrantyStartDateUnknown;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkWarrantyStartDateUnknown_CheckedChanged);
        CheckBox startDateUnknown1 = this._chkWarrantyStartDateUnknown;
        if (startDateUnknown1 != null)
          startDateUnknown1.CheckedChanged -= eventHandler;
        this._chkWarrantyStartDateUnknown = value;
        CheckBox startDateUnknown2 = this._chkWarrantyStartDateUnknown;
        if (startDateUnknown2 == null)
          return;
        startDateUnknown2.CheckedChanged += eventHandler;
      }
    }

    internal virtual DateTimePicker dtpWarrantyStartDate
    {
      get
      {
        return this._dtpWarrantyStartDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpWarrantyStartDate_ValueChanged);
        DateTimePicker warrantyStartDate1 = this._dtpWarrantyStartDate;
        if (warrantyStartDate1 != null)
          warrantyStartDate1.ValueChanged -= eventHandler;
        this._dtpWarrantyStartDate = value;
        DateTimePicker warrantyStartDate2 = this._dtpWarrantyStartDate;
        if (warrantyStartDate2 == null)
          return;
        warrantyStartDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtGCNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtYearOfManufacture { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtApproximateValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboGasType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFlueType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindProduct
    {
      get
      {
        return this._btnFindProduct;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindProduct_Click);
        Button btnFindProduct1 = this._btnFindProduct;
        if (btnFindProduct1 != null)
          btnFindProduct1.Click -= eventHandler;
        this._btnFindProduct = value;
        Button btnFindProduct2 = this._btnFindProduct;
        if (btnFindProduct2 == null)
          return;
        btnFindProduct2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtProduct { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkTenantsAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkActive { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.TabControl1 = new TabControl();
      this.tabDetails = new TabPage();
      this.grpAsset = new GroupBox();
      this.chkTenantsAppliance = new CheckBox();
      this.chkActive = new CheckBox();
      this.btnFindProduct = new Button();
      this.txtProduct = new TextBox();
      this.cboFlueType = new ComboBox();
      this.Label11 = new Label();
      this.cboGasType = new ComboBox();
      this.Label10 = new Label();
      this.txtApproximateValue = new TextBox();
      this.Label9 = new Label();
      this.txtYearOfManufacture = new TextBox();
      this.Label8 = new Label();
      this.txtGCNumber = new TextBox();
      this.Label7 = new Label();
      this.dtpWarrantyEndDate = new DateTimePicker();
      this.Label5 = new Label();
      this.chkWarrantyStartDateUnknown = new CheckBox();
      this.dtpWarrantyStartDate = new DateTimePicker();
      this.Label6 = new Label();
      this.chkLastServicedDateUnknown = new CheckBox();
      this.dtpLastServicedDate = new DateTimePicker();
      this.Label4 = new Label();
      this.chkCertificateLastIssuedUnknown = new CheckBox();
      this.dtpCertificateLastIssued = new DateTimePicker();
      this.Label3 = new Label();
      this.txtBoughtFrom = new TextBox();
      this.Label2 = new Label();
      this.txtSupplierBy = new TextBox();
      this.Label1 = new Label();
      this.txtLocation = new TextBox();
      this.chkDateUnknown = new CheckBox();
      this.lblProductID = new Label();
      this.txtSerialNum = new TextBox();
      this.lblSerialNum = new Label();
      this.dtpDateFitted = new DateTimePicker();
      this.lblDateFitted = new Label();
      this.lblLocationID = new Label();
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.tabDocuments = new TabPage();
      this.pnlDocuments = new Panel();
      this.tabJobs = new TabPage();
      this.grpJobs = new GroupBox();
      this.btnAddJob = new Button();
      this.dgJobs = new DataGrid();
      this.TabControl1.SuspendLayout();
      this.tabDetails.SuspendLayout();
      this.grpAsset.SuspendLayout();
      this.tabDocuments.SuspendLayout();
      this.tabJobs.SuspendLayout();
      this.grpJobs.SuspendLayout();
      this.dgJobs.BeginInit();
      this.SuspendLayout();
      this.TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.TabControl1.Controls.Add((Control) this.tabDetails);
      this.TabControl1.Controls.Add((Control) this.tabDocuments);
      this.TabControl1.Controls.Add((Control) this.tabJobs);
      this.TabControl1.Location = new System.Drawing.Point(1, 4);
      this.TabControl1.Name = "TabControl1";
      this.TabControl1.SelectedIndex = 0;
      this.TabControl1.Size = new Size(788, 582);
      this.TabControl1.TabIndex = 0;
      this.tabDetails.Controls.Add((Control) this.grpAsset);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(780, 556);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Main Details";
      this.grpAsset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpAsset.Controls.Add((Control) this.chkTenantsAppliance);
      this.grpAsset.Controls.Add((Control) this.chkActive);
      this.grpAsset.Controls.Add((Control) this.btnFindProduct);
      this.grpAsset.Controls.Add((Control) this.txtProduct);
      this.grpAsset.Controls.Add((Control) this.cboFlueType);
      this.grpAsset.Controls.Add((Control) this.Label11);
      this.grpAsset.Controls.Add((Control) this.cboGasType);
      this.grpAsset.Controls.Add((Control) this.Label10);
      this.grpAsset.Controls.Add((Control) this.txtApproximateValue);
      this.grpAsset.Controls.Add((Control) this.Label9);
      this.grpAsset.Controls.Add((Control) this.txtYearOfManufacture);
      this.grpAsset.Controls.Add((Control) this.Label8);
      this.grpAsset.Controls.Add((Control) this.txtGCNumber);
      this.grpAsset.Controls.Add((Control) this.Label7);
      this.grpAsset.Controls.Add((Control) this.dtpWarrantyEndDate);
      this.grpAsset.Controls.Add((Control) this.Label5);
      this.grpAsset.Controls.Add((Control) this.chkWarrantyStartDateUnknown);
      this.grpAsset.Controls.Add((Control) this.dtpWarrantyStartDate);
      this.grpAsset.Controls.Add((Control) this.Label6);
      this.grpAsset.Controls.Add((Control) this.chkLastServicedDateUnknown);
      this.grpAsset.Controls.Add((Control) this.dtpLastServicedDate);
      this.grpAsset.Controls.Add((Control) this.Label4);
      this.grpAsset.Controls.Add((Control) this.chkCertificateLastIssuedUnknown);
      this.grpAsset.Controls.Add((Control) this.dtpCertificateLastIssued);
      this.grpAsset.Controls.Add((Control) this.Label3);
      this.grpAsset.Controls.Add((Control) this.txtBoughtFrom);
      this.grpAsset.Controls.Add((Control) this.Label2);
      this.grpAsset.Controls.Add((Control) this.txtSupplierBy);
      this.grpAsset.Controls.Add((Control) this.Label1);
      this.grpAsset.Controls.Add((Control) this.txtLocation);
      this.grpAsset.Controls.Add((Control) this.chkDateUnknown);
      this.grpAsset.Controls.Add((Control) this.lblProductID);
      this.grpAsset.Controls.Add((Control) this.txtSerialNum);
      this.grpAsset.Controls.Add((Control) this.lblSerialNum);
      this.grpAsset.Controls.Add((Control) this.dtpDateFitted);
      this.grpAsset.Controls.Add((Control) this.lblDateFitted);
      this.grpAsset.Controls.Add((Control) this.lblLocationID);
      this.grpAsset.Controls.Add((Control) this.txtNotes);
      this.grpAsset.Controls.Add((Control) this.lblNotes);
      this.grpAsset.Location = new System.Drawing.Point(11, 6);
      this.grpAsset.Name = "grpAsset";
      this.grpAsset.Size = new Size(762, 542);
      this.grpAsset.TabIndex = 0;
      this.grpAsset.TabStop = false;
      this.grpAsset.Text = "Details";
      this.chkTenantsAppliance.Location = new System.Drawing.Point(217, 426);
      this.chkTenantsAppliance.Name = "chkTenantsAppliance";
      this.chkTenantsAppliance.Size = new Size(140, 24);
      this.chkTenantsAppliance.TabIndex = 39;
      this.chkTenantsAppliance.Text = "Tenants Appliance";
      this.chkActive.Checked = true;
      this.chkActive.CheckState = CheckState.Checked;
      this.chkActive.Location = new System.Drawing.Point(152, 426);
      this.chkActive.Name = "chkActive";
      this.chkActive.Size = new Size(88, 24);
      this.chkActive.TabIndex = 38;
      this.chkActive.Text = "Active";
      this.btnFindProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindProduct.Location = new System.Drawing.Point(727, 18);
      this.btnFindProduct.Name = "btnFindProduct";
      this.btnFindProduct.Size = new Size(29, 23);
      this.btnFindProduct.TabIndex = 37;
      this.btnFindProduct.Text = "...";
      this.btnFindProduct.UseVisualStyleBackColor = true;
      this.txtProduct.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtProduct.Location = new System.Drawing.Point(152, 20);
      this.txtProduct.Name = "txtProduct";
      this.txtProduct.ReadOnly = true;
      this.txtProduct.Size = new Size(569, 21);
      this.txtProduct.TabIndex = 36;
      this.cboFlueType.Cursor = Cursors.Hand;
      this.cboFlueType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFlueType.Location = new System.Drawing.Point(152, 128);
      this.cboFlueType.Name = "cboFlueType";
      this.cboFlueType.Size = new Size(174, 21);
      this.cboFlueType.TabIndex = 9;
      this.cboFlueType.Tag = (object) "";
      this.Label11.Location = new System.Drawing.Point(9, 129);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(128, 20);
      this.Label11.TabIndex = 8;
      this.Label11.Text = "Flue Type";
      this.cboGasType.Cursor = Cursors.Hand;
      this.cboGasType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboGasType.Location = new System.Drawing.Point(152, 155);
      this.cboGasType.Name = "cboGasType";
      this.cboGasType.Size = new Size(174, 21);
      this.cboGasType.TabIndex = 11;
      this.cboGasType.Tag = (object) "";
      this.Label10.Location = new System.Drawing.Point(9, 158);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(128, 20);
      this.Label10.TabIndex = 10;
      this.Label10.Text = "Fuel Type";
      this.txtApproximateValue.Location = new System.Drawing.Point(152, 399);
      this.txtApproximateValue.MaxLength = 100;
      this.txtApproximateValue.Name = "txtApproximateValue";
      this.txtApproximateValue.Size = new Size(174, 21);
      this.txtApproximateValue.TabIndex = 33;
      this.Label9.Location = new System.Drawing.Point(9, 402);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(128, 20);
      this.Label9.TabIndex = 32;
      this.Label9.Text = "Approximate Value";
      this.txtYearOfManufacture.Location = new System.Drawing.Point(152, 372);
      this.txtYearOfManufacture.MaxLength = 100;
      this.txtYearOfManufacture.Name = "txtYearOfManufacture";
      this.txtYearOfManufacture.Size = new Size(174, 21);
      this.txtYearOfManufacture.TabIndex = 31;
      this.Label8.Location = new System.Drawing.Point(9, 375);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(133, 20);
      this.Label8.TabIndex = 30;
      this.Label8.Text = "Year Of Manufacture";
      this.txtGCNumber.Location = new System.Drawing.Point(152, 74);
      this.txtGCNumber.MaxLength = 100;
      this.txtGCNumber.Name = "txtGCNumber";
      this.txtGCNumber.ReadOnly = true;
      this.txtGCNumber.Size = new Size(174, 21);
      this.txtGCNumber.TabIndex = 5;
      this.Label7.Location = new System.Drawing.Point(9, 77);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(117, 20);
      this.Label7.TabIndex = 4;
      this.Label7.Text = "GC Number";
      this.dtpWarrantyEndDate.Location = new System.Drawing.Point(152, 291);
      this.dtpWarrantyEndDate.Name = "dtpWarrantyEndDate";
      this.dtpWarrantyEndDate.Size = new Size(174, 21);
      this.dtpWarrantyEndDate.TabIndex = 25;
      this.dtpWarrantyEndDate.Tag = (object) "Asset.WarrantyEndDate";
      this.Label5.Location = new System.Drawing.Point(9, 295);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(125, 20);
      this.Label5.TabIndex = 24;
      this.Label5.Text = "Warranty End Date";
      this.chkWarrantyStartDateUnknown.Location = new System.Drawing.Point(343, 268);
      this.chkWarrantyStartDateUnknown.Name = "chkWarrantyStartDateUnknown";
      this.chkWarrantyStartDateUnknown.Size = new Size(88, 24);
      this.chkWarrantyStartDateUnknown.TabIndex = 23;
      this.chkWarrantyStartDateUnknown.Text = "Unknown";
      this.dtpWarrantyStartDate.Location = new System.Drawing.Point(152, 264);
      this.dtpWarrantyStartDate.Name = "dtpWarrantyStartDate";
      this.dtpWarrantyStartDate.Size = new Size(174, 21);
      this.dtpWarrantyStartDate.TabIndex = 22;
      this.dtpWarrantyStartDate.Tag = (object) "Asset.WarrantyStartDate";
      this.Label6.Location = new System.Drawing.Point(9, 268);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(141, 20);
      this.Label6.TabIndex = 21;
      this.Label6.Text = "Warranty Start Date";
      this.chkLastServicedDateUnknown.Location = new System.Drawing.Point(343, 209);
      this.chkLastServicedDateUnknown.Name = "chkLastServicedDateUnknown";
      this.chkLastServicedDateUnknown.Size = new Size(88, 24);
      this.chkLastServicedDateUnknown.TabIndex = 17;
      this.chkLastServicedDateUnknown.Text = "Unknown";
      this.dtpLastServicedDate.Location = new System.Drawing.Point(152, 210);
      this.dtpLastServicedDate.Name = "dtpLastServicedDate";
      this.dtpLastServicedDate.Size = new Size(174, 21);
      this.dtpLastServicedDate.TabIndex = 16;
      this.dtpLastServicedDate.Tag = (object) "Asset.LastServicedDate";
      this.Label4.Location = new System.Drawing.Point(9, 214);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(125, 20);
      this.Label4.TabIndex = 15;
      this.Label4.Text = "Last Serviced Date";
      this.chkCertificateLastIssuedUnknown.Location = new System.Drawing.Point(343, 182);
      this.chkCertificateLastIssuedUnknown.Name = "chkCertificateLastIssuedUnknown";
      this.chkCertificateLastIssuedUnknown.Size = new Size(88, 24);
      this.chkCertificateLastIssuedUnknown.TabIndex = 14;
      this.chkCertificateLastIssuedUnknown.Text = "Unknown";
      this.dtpCertificateLastIssued.Location = new System.Drawing.Point(152, 183);
      this.dtpCertificateLastIssued.Name = "dtpCertificateLastIssued";
      this.dtpCertificateLastIssued.Size = new Size(174, 21);
      this.dtpCertificateLastIssued.TabIndex = 13;
      this.dtpCertificateLastIssued.Tag = (object) "Asset.CertificateLastIssued";
      this.Label3.Location = new System.Drawing.Point(9, 187);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(141, 20);
      this.Label3.TabIndex = 12;
      this.Label3.Text = "Certificate Last Issued";
      this.txtBoughtFrom.Location = new System.Drawing.Point(152, 318);
      this.txtBoughtFrom.MaxLength = 100;
      this.txtBoughtFrom.Name = "txtBoughtFrom";
      this.txtBoughtFrom.Size = new Size(174, 21);
      this.txtBoughtFrom.TabIndex = 27;
      this.Label2.Location = new System.Drawing.Point(9, 321);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(117, 20);
      this.Label2.TabIndex = 26;
      this.Label2.Text = "Gasway Ref";
      this.txtSupplierBy.Location = new System.Drawing.Point(152, 345);
      this.txtSupplierBy.MaxLength = 100;
      this.txtSupplierBy.Name = "txtSupplierBy";
      this.txtSupplierBy.Size = new Size(174, 21);
      this.txtSupplierBy.TabIndex = 29;
      this.Label1.Location = new System.Drawing.Point(9, 348);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(117, 20);
      this.Label1.TabIndex = 28;
      this.Label1.Text = "Supplied By";
      this.txtLocation.Location = new System.Drawing.Point(152, 47);
      this.txtLocation.Name = "txtLocation";
      this.txtLocation.Size = new Size(174, 21);
      this.txtLocation.TabIndex = 3;
      this.chkDateUnknown.Location = new System.Drawing.Point(343, 235);
      this.chkDateUnknown.Name = "chkDateUnknown";
      this.chkDateUnknown.Size = new Size(88, 24);
      this.chkDateUnknown.TabIndex = 20;
      this.chkDateUnknown.Text = "Unknown";
      this.lblProductID.Location = new System.Drawing.Point(9, 23);
      this.lblProductID.Name = "lblProductID";
      this.lblProductID.Size = new Size(109, 20);
      this.lblProductID.TabIndex = 0;
      this.lblProductID.Text = "Product";
      this.txtSerialNum.Location = new System.Drawing.Point(152, 101);
      this.txtSerialNum.MaxLength = 50;
      this.txtSerialNum.Name = "txtSerialNum";
      this.txtSerialNum.Size = new Size(174, 21);
      this.txtSerialNum.TabIndex = 7;
      this.txtSerialNum.Tag = (object) "Asset.SerialNum";
      this.lblSerialNum.Location = new System.Drawing.Point(9, 101);
      this.lblSerialNum.Name = "lblSerialNum";
      this.lblSerialNum.Size = new Size(133, 20);
      this.lblSerialNum.TabIndex = 6;
      this.lblSerialNum.Text = "Serial";
      this.dtpDateFitted.Location = new System.Drawing.Point(152, 237);
      this.dtpDateFitted.Name = "dtpDateFitted";
      this.dtpDateFitted.Size = new Size(174, 21);
      this.dtpDateFitted.TabIndex = 19;
      this.dtpDateFitted.Tag = (object) "Asset.DateFitted";
      this.lblDateFitted.Location = new System.Drawing.Point(9, 239);
      this.lblDateFitted.Name = "lblDateFitted";
      this.lblDateFitted.Size = new Size(125, 20);
      this.lblDateFitted.TabIndex = 18;
      this.lblDateFitted.Text = "Date Fitted";
      this.lblLocationID.Location = new System.Drawing.Point(9, 50);
      this.lblLocationID.Name = "lblLocationID";
      this.lblLocationID.Size = new Size(117, 20);
      this.lblLocationID.TabIndex = 2;
      this.lblLocationID.Text = "Location";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(152, 456);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(600, 77);
      this.txtNotes.TabIndex = 35;
      this.txtNotes.Tag = (object) "Asset.Notes";
      this.lblNotes.Location = new System.Drawing.Point(9, 456);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(101, 20);
      this.lblNotes.TabIndex = 34;
      this.lblNotes.Text = "Notes";
      this.tabDocuments.Controls.Add((Control) this.pnlDocuments);
      this.tabDocuments.Location = new System.Drawing.Point(4, 22);
      this.tabDocuments.Name = "tabDocuments";
      this.tabDocuments.Size = new Size(780, 556);
      this.tabDocuments.TabIndex = 1;
      this.tabDocuments.Text = "Documents";
      this.pnlDocuments.Dock = DockStyle.Fill;
      this.pnlDocuments.Location = new System.Drawing.Point(0, 0);
      this.pnlDocuments.Name = "pnlDocuments";
      this.pnlDocuments.Size = new Size(780, 556);
      this.pnlDocuments.TabIndex = 0;
      this.tabJobs.Controls.Add((Control) this.grpJobs);
      this.tabJobs.Location = new System.Drawing.Point(4, 22);
      this.tabJobs.Name = "tabJobs";
      this.tabJobs.Size = new Size(780, 556);
      this.tabJobs.TabIndex = 2;
      this.tabJobs.Text = "Jobs";
      this.grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpJobs.Controls.Add((Control) this.btnAddJob);
      this.grpJobs.Controls.Add((Control) this.dgJobs);
      this.grpJobs.Location = new System.Drawing.Point(7, 9);
      this.grpJobs.Name = "grpJobs";
      this.grpJobs.Size = new Size(768, 542);
      this.grpJobs.TabIndex = 1;
      this.grpJobs.TabStop = false;
      this.grpJobs.Text = "Jobs";
      this.btnAddJob.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnAddJob.Location = new System.Drawing.Point(8, 514);
      this.btnAddJob.Name = "btnAddJob";
      this.btnAddJob.Size = new Size(75, 23);
      this.btnAddJob.TabIndex = 2;
      this.btnAddJob.Text = "Add Job";
      this.dgJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgJobs.DataMember = "";
      this.dgJobs.HeaderForeColor = SystemColors.ControlText;
      this.dgJobs.Location = new System.Drawing.Point(8, 20);
      this.dgJobs.Name = "dgJobs";
      this.dgJobs.Size = new Size(752, 488);
      this.dgJobs.TabIndex = 1;
      this.Controls.Add((Control) this.TabControl1);
      this.Name = nameof (UCAsset);
      this.Size = new Size(795, 594);
      this.TabControl1.ResumeLayout(false);
      this.tabDetails.ResumeLayout(false);
      this.grpAsset.ResumeLayout(false);
      this.grpAsset.PerformLayout();
      this.tabDocuments.ResumeLayout(false);
      this.tabJobs.ResumeLayout(false);
      this.grpJobs.ResumeLayout(false);
      this.dgJobs.EndInit();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupJobsDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentAsset;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Asset CurrentAsset
    {
      get
      {
        return this._currentAsset;
      }
      set
      {
        this._currentAsset = value;
        if (this.CurrentAsset == null)
        {
          this.CurrentAsset = new Asset();
          this.CurrentAsset.Exists = false;
        }
        if (this.CurrentAsset.Exists)
        {
          this.Populate(0);
          this.pnlDocuments.Controls.Clear();
          this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblAsset, this.CurrentAsset.AssetID);
          this.pnlDocuments.Controls.Add((Control) this.DocumentsControl);
          this.grpJobs.Enabled = true;
          this.PopulateJobs();
        }
        else
          this.grpJobs.Enabled = false;
      }
    }

    public int LoadProductID
    {
      get
      {
        return this._LoadProductID;
      }
      set
      {
        this._LoadProductID = value;
        if (value <= 0)
          return;
        this.selectedProductID = this._LoadProductID;
        this.btnFindProduct.Enabled = false;
      }
    }

    public int LoadSiteID
    {
      get
      {
        return this._LoadSiteID;
      }
      set
      {
        this._LoadSiteID = value;
      }
    }

    public DataView JobsDataView
    {
      get
      {
        return this._jobsTable;
      }
      set
      {
        this._jobsTable = value;
        this._jobsTable.Table.TableName = Enums.TableNames.tblJob.ToString();
        this._jobsTable.AllowNew = false;
        this._jobsTable.AllowEdit = false;
        this._jobsTable.AllowDelete = false;
        this.dgJobs.DataSource = (object) this.JobsDataView;
      }
    }

    private DataRow SelectedJobDataRow
    {
      get
      {
        return this.dgJobs.CurrentRowIndex != -1 ? this.JobsDataView[this.dgJobs.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private int selectedProductID
    {
      get
      {
        return this._selectedProductID;
      }
      set
      {
        this._selectedProductID = value;
        if (this._selectedProductID > 0)
        {
          Product product = App.DB.Product.Product_Get(this._selectedProductID);
          if (product != null)
          {
            this.txtGCNumber.Text = product.Number;
            PickList oneAsObject1 = App.DB.Picklists.Get_One_As_Object(product.TypeID);
            if (oneAsObject1 != null)
              this.txtProduct.Text = oneAsObject1.Name + "-";
            PickList oneAsObject2 = App.DB.Picklists.Get_One_As_Object(product.MakeID);
            if (oneAsObject2 != null)
            {
              TextBox txtProduct;
              string str = (txtProduct = this.txtProduct).Text + oneAsObject2.Name + "-";
              txtProduct.Text = str;
            }
            PickList oneAsObject3 = App.DB.Picklists.Get_One_As_Object(product.ModelID);
            if (oneAsObject3 == null)
              return;
            TextBox txtProduct1;
            string str1 = (txtProduct1 = this.txtProduct).Text + oneAsObject3.Name;
            txtProduct1.Text = str1;
          }
          else
            this.selectedProductID = 0;
        }
        else
        {
          this.txtGCNumber.Text = "";
          this.txtProduct.Text = "";
        }
      }
    }

    public void SetupJobsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgJobs, false);
      DataGridTableStyle tableStyle = this.dgJobs.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Job Number";
      dataGridLabelColumn1.MappingName = "JobNumber";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "PO Number";
      dataGridLabelColumn2.MappingName = "PONumber";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MMM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Date Created";
      dataGridLabelColumn3.MappingName = "DateCreated";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Definition";
      dataGridLabelColumn4.MappingName = "JobDefinition";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Type";
      dataGridLabelColumn5.MappingName = "Type";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Status";
      dataGridLabelColumn6.MappingName = "JobStatus";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Created By";
      dataGridLabelColumn7.MappingName = "CreatedBy";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblJob.ToString();
      this.dgJobs.TableStyles.Add(tableStyle);
    }

    private void UCAsset_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void chkDateUnknown_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.chkDateUnknown.Checked)
        this.dtpDateFitted.Enabled = true;
      else
        this.dtpDateFitted.Enabled = false;
    }

    private void chkCertificateLastIssuedUnknown_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.chkCertificateLastIssuedUnknown.Checked)
        this.dtpCertificateLastIssued.Enabled = true;
      else
        this.dtpCertificateLastIssued.Enabled = false;
    }

    private void chkLastServiceDateUnknown_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.chkLastServicedDateUnknown.Checked)
        this.dtpLastServicedDate.Enabled = true;
      else
        this.dtpLastServicedDate.Enabled = false;
    }

    private void chkWarrantyStartDateUnknown_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.chkWarrantyStartDateUnknown.Checked)
      {
        this.dtpWarrantyStartDate.Enabled = true;
        this.dtpWarrantyEndDate.Enabled = true;
      }
      else
      {
        this.dtpWarrantyStartDate.Enabled = false;
        this.dtpWarrantyEndDate.Enabled = false;
      }
    }

    private void dgJobs_DoubleClick(object sender, EventArgs e)
    {
      if (this.SelectedJobDataRow == null)
        return;
      App.ShowForm(typeof (FRMLogCallout), true, new object[3]
      {
        this.SelectedJobDataRow["JobID"],
        (object) this.CurrentAsset.PropertyID,
        (object) this
      }, false);
    }

    private void btnAddJob_Click(object sender, EventArgs e)
    {
      FSM.Entity.Sites.Site site = App.DB.Sites.Get((object) this.CurrentAsset.PropertyID, SiteSQL.GetBy.SiteId, (object) null);
      int status = App.DB.Customer.Customer_Get(site.CustomerID).Status;
      if (site.OnStop & !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (status == 3 & !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Finance))
        throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (site.OnStop)
      {
        if (App.ShowMessage("This property is on stop. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
      }
      else if (status == 3 && App.ShowMessage("The customer is on hold. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      if (App.loggedInUser.UserRegions.Count <= 0)
        throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + Conversions.ToString(site.RegionID)).Length < 1)
        throw new SecurityException("You do not have the necessary security permissions.\r\n" + "Contact your administrator if you think this is wrong or you need the permissions changing.");
      if (string.IsNullOrEmpty(site.TelephoneNum) & string.IsNullOrEmpty(site.FaxNum) | string.IsNullOrEmpty(site.EmailAddress) && App.ShowMessage("The phone number/email address is missing from site. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      App.ShowForm(typeof (FRMLogCallout), true, new object[4]
      {
        (object) 0,
        (object) this.CurrentAsset.PropertyID,
        (object) this,
        (object) this.CurrentAsset.AssetID
      }, false);
    }

    private void dtpWarrantyStartDate_ValueChanged(object sender, EventArgs e)
    {
      DateTimePicker dtpWarrantyEndDate = this.dtpWarrantyEndDate;
      DateTime dateTime1 = this.dtpWarrantyStartDate.Value;
      dateTime1 = dateTime1.AddYears(1);
      DateTime dateTime2 = dateTime1.AddDays(-1.0);
      dtpWarrantyEndDate.Value = dateTime2;
    }

    private void btnFindProduct_Click(object sender, EventArgs e)
    {
      this.selectedProductID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblProduct, 0, "", false));
    }

    public void PopulateJobs()
    {
      this.JobsDataView = App.DB.Job.Job_GetAll_For_Asset(this.CurrentAsset.AssetID);
    }

    public void DisableControls()
    {
      if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Compliance))
        return;
      this.txtLocation.Enabled = false;
      this.txtSerialNum.Enabled = false;
      this.dtpDateFitted.Enabled = false;
      this.chkDateUnknown.Enabled = false;
      this.dtpCertificateLastIssued.Enabled = false;
      this.chkCertificateLastIssuedUnknown.Enabled = false;
      this.dtpLastServicedDate.Enabled = false;
      this.chkLastServicedDateUnknown.Enabled = false;
      this.dtpWarrantyStartDate.Enabled = false;
      this.chkWarrantyStartDateUnknown.Enabled = false;
      this.dtpWarrantyEndDate.Enabled = false;
      this.chkWarrantyStartDateUnknown.Enabled = false;
    }

    void IUserControl.Populate(int ID = 0)
    {
      if (App.ControlLoading)
        return;
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentAsset = App.DB.Asset.Asset_Get(ID);
      this.selectedProductID = this.CurrentAsset.ProductID;
      this.btnFindProduct.Enabled = false;
      this.txtSerialNum.Text = this.CurrentAsset.SerialNum;
      if (DateTime.Compare(this.CurrentAsset.DateFitted, DateTime.MinValue) == 0)
        this.chkDateUnknown.Checked = true;
      else
        this.dtpDateFitted.Value = this.CurrentAsset.DateFitted;
      if (DateTime.Compare(this.CurrentAsset.CertificateLastIssued, DateTime.MinValue) == 0)
        this.chkCertificateLastIssuedUnknown.Checked = true;
      else
        this.dtpCertificateLastIssued.Value = this.CurrentAsset.CertificateLastIssued;
      if (DateTime.Compare(this.CurrentAsset.LastServicedDate, DateTime.MinValue) == 0)
        this.chkLastServicedDateUnknown.Checked = true;
      else
        this.dtpLastServicedDate.Value = this.CurrentAsset.LastServicedDate;
      if (DateTime.Compare(this.CurrentAsset.WarrantyStartDate, DateTime.MinValue) == 0)
        this.chkWarrantyStartDateUnknown.Checked = true;
      else
        this.dtpWarrantyStartDate.Value = this.CurrentAsset.WarrantyStartDate;
      if (DateTime.Compare(this.CurrentAsset.WarrantyEndDate, DateTime.MinValue) == 0)
        this.chkWarrantyStartDateUnknown.Checked = true;
      else
        this.dtpWarrantyEndDate.Value = this.CurrentAsset.WarrantyEndDate;
      this.txtBoughtFrom.Text = this.CurrentAsset.BoughtFrom;
      this.txtSupplierBy.Text = this.CurrentAsset.SuppliedBy;
      this.txtLocation.Text = this.CurrentAsset.Location;
      this.txtNotes.Text = this.CurrentAsset.Notes;
      this.txtGCNumber.Text = this.CurrentAsset.GCNumber;
      this.txtYearOfManufacture.Text = this.CurrentAsset.YearOfManufacture;
      this.txtApproximateValue.Text = Conversions.ToString(this.CurrentAsset.ApproximateValue);
      this.chkActive.Checked = this.CurrentAsset.Active;
      this.chkTenantsAppliance.Checked = this.CurrentAsset.TenantsAppliance;
      ComboBox combo = this.cboGasType;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentAsset.GasTypeID));
      this.cboGasType = combo;
      combo = this.cboFlueType;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentAsset.FlueTypeID));
      this.cboFlueType = combo;
      this.txtBoughtFrom.Enabled = false;
      this.txtSupplierBy.Enabled = false;
      this.txtYearOfManufacture.Enabled = false;
      this.txtApproximateValue.Enabled = false;
      this.cboFlueType.Enabled = false;
      this.cboGasType.Enabled = false;
      this.DisableControls();
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentAsset.IgnoreExceptionsOnSetMethods = true;
        this.CurrentAsset.SetProductID = (object) this.selectedProductID;
        this.CurrentAsset.SetSerialNum = (object) this.txtSerialNum.Text.Trim();
        this.CurrentAsset.DateFitted = !this.chkDateUnknown.Checked ? this.dtpDateFitted.Value : DateTime.MinValue;
        this.CurrentAsset.CertificateLastIssued = !this.chkCertificateLastIssuedUnknown.Checked ? this.dtpCertificateLastIssued.Value : DateTime.MinValue;
        this.CurrentAsset.LastServicedDate = !this.chkLastServicedDateUnknown.Checked ? this.dtpLastServicedDate.Value : DateTime.MinValue;
        if (this.chkWarrantyStartDateUnknown.Checked)
        {
          this.CurrentAsset.WarrantyStartDate = DateTime.MinValue;
          this.CurrentAsset.WarrantyEndDate = DateTime.MinValue;
        }
        else
        {
          this.CurrentAsset.WarrantyStartDate = this.dtpWarrantyStartDate.Value;
          this.CurrentAsset.WarrantyEndDate = this.dtpWarrantyEndDate.Value;
        }
        this.CurrentAsset.SetBoughtFrom = (object) this.txtBoughtFrom.Text.Trim();
        this.CurrentAsset.SetSuppliedBy = (object) this.txtSupplierBy.Text.Trim();
        this.CurrentAsset.SetLocation = (object) this.txtLocation.Text.Trim();
        this.CurrentAsset.SetNotes = (object) this.txtNotes.Text.Trim();
        this.CurrentAsset.SetGCNumber = (object) this.txtGCNumber.Text.Trim();
        this.CurrentAsset.SetYearOfManufacture = (object) this.txtYearOfManufacture.Text.Trim();
        this.CurrentAsset.SetApproximateValue = this.txtApproximateValue.Text.Trim().Length != 0 ? (object) this.txtApproximateValue.Text.Trim() : (object) 0;
        this.CurrentAsset.SetGasTypeID = (object) Combo.get_GetSelectedItemValue(this.cboGasType);
        this.CurrentAsset.SetFlueTypeID = (object) Combo.get_GetSelectedItemValue(this.cboFlueType);
        this.CurrentAsset.SetActive = (object) this.chkActive.Checked;
        this.CurrentAsset.SetTenantsAppliance = (object) this.chkTenantsAppliance.Checked;
        new AssetValidator().Validate(this.CurrentAsset);
        if (this.CurrentAsset.Exists)
        {
          App.DB.Asset.Update(this.CurrentAsset);
        }
        else
        {
          this.CurrentAsset.SetPropertyID = this.LoadSiteID <= 0 ? (object) App.CurrentPropertyID : (object) this.LoadSiteID;
          this.CurrentAsset = App.DB.Asset.Insert(this.CurrentAsset);
        }
        if (this.LoadSiteID <= 0)
        {
          if (App.CurrentPropertyID == 0)
          {
            // ISSUE: reference to a compiler-generated field
            IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
            if (recordsChangedEvent != null)
              recordsChangedEvent(App.DB.Asset.Asset_GetAll(App.loggedInUser.UserID), Enums.PageViewing.Asset, true, false, "");
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
            if (recordsChangedEvent != null)
              recordsChangedEvent(App.DB.Asset.Asset_GetForSite(App.CurrentPropertyID), Enums.PageViewing.Asset, true, false, "");
          }
          // ISSUE: reference to a compiler-generated field
          IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
          if (stateChangedEvent != null)
            stateChangedEvent(this.CurrentAsset.AssetID);
          App.MainForm.RefreshEntity(this.CurrentAsset.AssetID, "");
        }
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
  }
}
