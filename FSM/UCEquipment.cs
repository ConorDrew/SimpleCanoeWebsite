// Decompiled with JetBrains decompiler
// Type: FSM.UCEquipment
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCEquipment : UCBase, IUserControl
  {
    private IContainer components;
    private UCDocumentsList DocumentsControl;
    private int CurrentStatus;
    private Equipment _currentEquipment;
    private Engineer _theEngineer;
    private DataView _dvEquipmentAudits;

    public UCEquipment()
    {
      this.Load += new EventHandler(this.UCEqupment_Load);
      this.CurrentStatus = 0;
      this.InitializeComponent();
      ComboBox cboEquipmentType = this.cboEquipmentType;
      Combo.SetUpCombo(ref cboEquipmentType, App.DB.Picklists.GetAll(Enums.PickListTypes.EquipmentType, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboEquipmentType = cboEquipmentType;
      ComboBox cboStatus = this.cboStatus;
      Combo.SetUpCombo(ref cboStatus, App.DB.Picklists.GetAll(Enums.PickListTypes.EquipmentStatus, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboStatus = cboStatus;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl tcVans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDecription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRegistration { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpCalibrationDate
    {
      get
      {
        return this._dtpCalibrationDate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dtpCalibrationDate_ValueChanged);
        DateTimePicker dtpCalibrationDate1 = this._dtpCalibrationDate;
        if (dtpCalibrationDate1 != null)
          dtpCalibrationDate1.ValueChanged -= eventHandler;
        this._dtpCalibrationDate = value;
        DateTimePicker dtpCalibrationDate2 = this._dtpCalibrationDate;
        if (dtpCalibrationDate2 == null)
          return;
        dtpCalibrationDate2.ValueChanged += eventHandler;
      }
    }

    internal virtual Label lblInsuranceDue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpWarrantyExpires { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMOTDue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTaxDue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAssetId { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCallibrationPeriod { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnfindEngineer
    {
      get
      {
        return this._btnfindEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnfindEngineer_Click_1);
        Button btnfindEngineer1 = this._btnfindEngineer;
        if (btnfindEngineer1 != null)
          btnfindEngineer1.Click -= eventHandler;
        this._btnfindEngineer = value;
        Button btnfindEngineer2 = this._btnfindEngineer;
        if (btnfindEngineer2 == null)
          return;
        btnfindEngineer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCalibrationCert { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboEquipmentType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSerialNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAssetNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgEquipmentAudits { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCalibrationStatus { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabDocuments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnUnassign
    {
      get
      {
        return this._btnUnassign;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnUnassign_Click);
        Button btnUnassign1 = this._btnUnassign;
        if (btnUnassign1 != null)
          btnUnassign1.Click -= eventHandler;
        this._btnUnassign = value;
        Button btnUnassign2 = this._btnUnassign;
        if (btnUnassign2 == null)
          return;
        btnUnassign2.Click += eventHandler;
      }
    }

    internal virtual TabPage tabGenerateWO { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpWorkOrder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFaults { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaults { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnGenerate
    {
      get
      {
        return this._btnGenerate;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGenerate_Click);
        Button btnGenerate1 = this._btnGenerate;
        if (btnGenerate1 != null)
          btnGenerate1.Click -= eventHandler;
        this._btnGenerate = value;
        Button btnGenerate2 = this._btnGenerate;
        if (btnGenerate2 == null)
          return;
        btnGenerate2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmail { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnGenerateAndEmail
    {
      get
      {
        return this._btnGenerateAndEmail;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnGenerateAndEmail_Click);
        Button generateAndEmail1 = this._btnGenerateAndEmail;
        if (generateAndEmail1 != null)
          generateAndEmail1.Click -= eventHandler;
        this._btnGenerateAndEmail = value;
        Button generateAndEmail2 = this._btnGenerateAndEmail;
        if (generateAndEmail2 == null)
          return;
        generateAndEmail2.Click += eventHandler;
      }
    }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.tcVans = new TabControl();
      this.tabDetails = new TabPage();
      this.grpVan = new GroupBox();
      this.btnUnassign = new Button();
      this.lblCalibrationStatus = new Label();
      this.txtAssetNumber = new TextBox();
      this.txtSerialNo = new TextBox();
      this.Label6 = new Label();
      this.cboEquipmentType = new ComboBox();
      this.Label4 = new Label();
      this.txtCalibrationCert = new TextBox();
      this.Label3 = new Label();
      this.btnfindEngineer = new Button();
      this.txtEngineer = new TextBox();
      this.Label5 = new Label();
      this.cboStatus = new ComboBox();
      this.Label1 = new Label();
      this.txtCallibrationPeriod = new TextBox();
      this.Label2 = new Label();
      this.txtDecription = new TextBox();
      this.lblRegistration = new Label();
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.dtpCalibrationDate = new DateTimePicker();
      this.lblInsuranceDue = new Label();
      this.dtpWarrantyExpires = new DateTimePicker();
      this.lblMOTDue = new Label();
      this.lblTaxDue = new Label();
      this.lblAssetId = new Label();
      this.tabHistory = new TabPage();
      this.GroupBox1 = new GroupBox();
      this.dgEquipmentAudits = new DataGrid();
      this.tabDocuments = new TabPage();
      this.tabGenerateWO = new TabPage();
      this.grpWorkOrder = new GroupBox();
      this.txtEmail = new TextBox();
      this.lblEmail = new Label();
      this.btnGenerateAndEmail = new Button();
      this.btnGenerate = new Button();
      this.txtFaults = new TextBox();
      this.lblFaults = new Label();
      this.tcVans.SuspendLayout();
      this.tabDetails.SuspendLayout();
      this.grpVan.SuspendLayout();
      this.tabHistory.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.dgEquipmentAudits.BeginInit();
      this.tabGenerateWO.SuspendLayout();
      this.grpWorkOrder.SuspendLayout();
      this.SuspendLayout();
      this.tcVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tcVans.Controls.Add((Control) this.tabDetails);
      this.tcVans.Controls.Add((Control) this.tabHistory);
      this.tcVans.Controls.Add((Control) this.tabDocuments);
      this.tcVans.Controls.Add((Control) this.tabGenerateWO);
      this.tcVans.Location = new System.Drawing.Point(3, 7);
      this.tcVans.Name = "tcVans";
      this.tcVans.SelectedIndex = 0;
      this.tcVans.Size = new Size(683, 670);
      this.tcVans.TabIndex = 14;
      this.tabDetails.Controls.Add((Control) this.grpVan);
      this.tabDetails.Location = new System.Drawing.Point(4, 22);
      this.tabDetails.Name = "tabDetails";
      this.tabDetails.Size = new Size(675, 644);
      this.tabDetails.TabIndex = 0;
      this.tabDetails.Text = "Main Details";
      this.grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVan.Controls.Add((Control) this.btnUnassign);
      this.grpVan.Controls.Add((Control) this.lblCalibrationStatus);
      this.grpVan.Controls.Add((Control) this.txtAssetNumber);
      this.grpVan.Controls.Add((Control) this.txtSerialNo);
      this.grpVan.Controls.Add((Control) this.Label6);
      this.grpVan.Controls.Add((Control) this.cboEquipmentType);
      this.grpVan.Controls.Add((Control) this.Label4);
      this.grpVan.Controls.Add((Control) this.txtCalibrationCert);
      this.grpVan.Controls.Add((Control) this.Label3);
      this.grpVan.Controls.Add((Control) this.btnfindEngineer);
      this.grpVan.Controls.Add((Control) this.txtEngineer);
      this.grpVan.Controls.Add((Control) this.Label5);
      this.grpVan.Controls.Add((Control) this.cboStatus);
      this.grpVan.Controls.Add((Control) this.Label1);
      this.grpVan.Controls.Add((Control) this.txtCallibrationPeriod);
      this.grpVan.Controls.Add((Control) this.Label2);
      this.grpVan.Controls.Add((Control) this.txtDecription);
      this.grpVan.Controls.Add((Control) this.lblRegistration);
      this.grpVan.Controls.Add((Control) this.txtNotes);
      this.grpVan.Controls.Add((Control) this.lblNotes);
      this.grpVan.Controls.Add((Control) this.dtpCalibrationDate);
      this.grpVan.Controls.Add((Control) this.lblInsuranceDue);
      this.grpVan.Controls.Add((Control) this.dtpWarrantyExpires);
      this.grpVan.Controls.Add((Control) this.lblMOTDue);
      this.grpVan.Controls.Add((Control) this.lblTaxDue);
      this.grpVan.Controls.Add((Control) this.lblAssetId);
      this.grpVan.Location = new System.Drawing.Point(8, 8);
      this.grpVan.Name = "grpVan";
      this.grpVan.Size = new Size(664, 631);
      this.grpVan.TabIndex = 200;
      this.grpVan.TabStop = false;
      this.grpVan.Text = "Details";
      this.btnUnassign.BackColor = Color.White;
      this.btnUnassign.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnUnassign.Location = new System.Drawing.Point(447, 278);
      this.btnUnassign.Name = "btnUnassign";
      this.btnUnassign.Size = new Size(82, 23);
      this.btnUnassign.TabIndex = 472;
      this.btnUnassign.Text = "Un-assign";
      this.btnUnassign.UseVisualStyleBackColor = false;
      this.lblCalibrationStatus.Location = new System.Drawing.Point(382, 118);
      this.lblCalibrationStatus.Name = "lblCalibrationStatus";
      this.lblCalibrationStatus.Size = new Size(136, 20);
      this.lblCalibrationStatus.TabIndex = 471;
      this.lblCalibrationStatus.Text = "[Calibration Status]";
      this.txtAssetNumber.Location = new System.Drawing.Point(175, 252);
      this.txtAssetNumber.MaxLength = 9;
      this.txtAssetNumber.Name = "txtAssetNumber";
      this.txtAssetNumber.Size = new Size(201, 21);
      this.txtAssetNumber.TabIndex = 9;
      this.txtSerialNo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSerialNo.Location = new System.Drawing.Point(175, 88);
      this.txtSerialNo.MaxLength = 20;
      this.txtSerialNo.Name = "txtSerialNo";
      this.txtSerialNo.Size = new Size(373, 21);
      this.txtSerialNo.TabIndex = 3;
      this.txtSerialNo.Tag = (object) "Van.Registration";
      this.Label6.Location = new System.Drawing.Point(8, 90);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(144, 20);
      this.Label6.TabIndex = 470;
      this.Label6.Text = "Serial No.";
      this.cboEquipmentType.Cursor = Cursors.Hand;
      this.cboEquipmentType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEquipmentType.FormattingEnabled = true;
      this.cboEquipmentType.Location = new System.Drawing.Point(175, 33);
      this.cboEquipmentType.Name = "cboEquipmentType";
      this.cboEquipmentType.Size = new Size(201, 21);
      this.cboEquipmentType.TabIndex = 1;
      this.Label4.Location = new System.Drawing.Point(8, 35);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(136, 20);
      this.Label4.TabIndex = 440;
      this.Label4.Text = "Type of Equipment";
      this.txtCalibrationCert.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCalibrationCert.Location = new System.Drawing.Point(175, 170);
      this.txtCalibrationCert.MaxLength = 20;
      this.txtCalibrationCert.Name = "txtCalibrationCert";
      this.txtCalibrationCert.Size = new Size(373, 21);
      this.txtCalibrationCert.TabIndex = 6;
      this.txtCalibrationCert.Tag = (object) "Van.Registration";
      this.Label3.Location = new System.Drawing.Point(8, 173);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(161, 20);
      this.Label3.TabIndex = 43;
      this.Label3.Text = "Calibration Certificate";
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(409, 278);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 11;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEngineer.Location = new System.Drawing.Point(175, 279);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(228, 21);
      this.txtEngineer.TabIndex = 10;
      this.Label5.Location = new System.Drawing.Point(8, 282);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(70, 16);
      this.Label5.TabIndex = 410;
      this.Label5.Text = "Engineer";
      this.cboStatus.Cursor = Cursors.Hand;
      this.cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStatus.FormattingEnabled = true;
      this.cboStatus.Location = new System.Drawing.Point(175, 226);
      this.cboStatus.Name = "cboStatus";
      this.cboStatus.Size = new Size(201, 21);
      this.cboStatus.TabIndex = 8;
      this.Label1.Location = new System.Drawing.Point(8, 146);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(163, 20);
      this.Label1.TabIndex = 370;
      this.Label1.Text = "Calibration Period (Months)";
      this.txtCallibrationPeriod.Location = new System.Drawing.Point(175, 142);
      this.txtCallibrationPeriod.MaxLength = 9;
      this.txtCallibrationPeriod.Name = "txtCallibrationPeriod";
      this.txtCallibrationPeriod.Size = new Size(43, 21);
      this.txtCallibrationPeriod.TabIndex = 5;
      this.txtCallibrationPeriod.Text = "12";
      this.Label2.Location = new System.Drawing.Point(8, 278);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(136, 20);
      this.Label2.TabIndex = 340;
      this.txtDecription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtDecription.Location = new System.Drawing.Point(175, 61);
      this.txtDecription.MaxLength = 20;
      this.txtDecription.Name = "txtDecription";
      this.txtDecription.Size = new Size(373, 21);
      this.txtDecription.TabIndex = 2;
      this.txtDecription.Tag = (object) "Van.Registration";
      this.lblRegistration.Location = new System.Drawing.Point(8, 64);
      this.lblRegistration.Name = "lblRegistration";
      this.lblRegistration.Size = new Size(144, 20);
      this.lblRegistration.TabIndex = 310;
      this.lblRegistration.Text = "Description";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(175, 321);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(467, 259);
      this.txtNotes.TabIndex = 12;
      this.txtNotes.Tag = (object) "Van.Notes";
      this.lblNotes.Location = new System.Drawing.Point(8, 324);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(53, 20);
      this.lblNotes.TabIndex = 310;
      this.lblNotes.Text = "Notes";
      this.dtpCalibrationDate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtpCalibrationDate.Location = new System.Drawing.Point(175, 115);
      this.dtpCalibrationDate.Name = "dtpCalibrationDate";
      this.dtpCalibrationDate.Size = new Size(201, 21);
      this.dtpCalibrationDate.TabIndex = 4;
      this.dtpCalibrationDate.Tag = (object) "Van.InsuranceDue";
      this.lblInsuranceDue.Location = new System.Drawing.Point(8, 121);
      this.lblInsuranceDue.Name = "lblInsuranceDue";
      this.lblInsuranceDue.Size = new Size(136, 20);
      this.lblInsuranceDue.TabIndex = 31;
      this.lblInsuranceDue.Text = "Calibration Date";
      this.dtpWarrantyExpires.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.dtpWarrantyExpires.Location = new System.Drawing.Point(175, 200);
      this.dtpWarrantyExpires.Name = "dtpWarrantyExpires";
      this.dtpWarrantyExpires.Size = new Size(201, 21);
      this.dtpWarrantyExpires.TabIndex = 7;
      this.dtpWarrantyExpires.Tag = (object) "Van.MOTDue";
      this.lblMOTDue.Location = new System.Drawing.Point(8, 201);
      this.lblMOTDue.Name = "lblMOTDue";
      this.lblMOTDue.Size = new Size(114, 20);
      this.lblMOTDue.TabIndex = 310;
      this.lblMOTDue.Text = "Warranty Expires";
      this.lblTaxDue.Location = new System.Drawing.Point(8, 228);
      this.lblTaxDue.Name = "lblTaxDue";
      this.lblTaxDue.Size = new Size(64, 20);
      this.lblTaxDue.TabIndex = 31;
      this.lblTaxDue.Text = "Status";
      this.lblAssetId.Location = new System.Drawing.Point(8, (int) byte.MaxValue);
      this.lblAssetId.Name = "lblAssetId";
      this.lblAssetId.Size = new Size(123, 20);
      this.lblAssetId.TabIndex = 310;
      this.lblAssetId.Text = "Asset Number";
      this.tabHistory.BackColor = SystemColors.Control;
      this.tabHistory.Controls.Add((Control) this.GroupBox1);
      this.tabHistory.Location = new System.Drawing.Point(4, 22);
      this.tabHistory.Name = "tabHistory";
      this.tabHistory.Size = new Size(675, 644);
      this.tabHistory.TabIndex = 10;
      this.tabHistory.Text = "History";
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dgEquipmentAudits);
      this.GroupBox1.Location = new System.Drawing.Point(8, 8);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(664, 631);
      this.GroupBox1.TabIndex = 3;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Equipment Audit";
      this.dgEquipmentAudits.DataMember = "";
      this.dgEquipmentAudits.Dock = DockStyle.Fill;
      this.dgEquipmentAudits.HeaderForeColor = SystemColors.ControlText;
      this.dgEquipmentAudits.Location = new System.Drawing.Point(3, 17);
      this.dgEquipmentAudits.Name = "dgEquipmentAudits";
      this.dgEquipmentAudits.Size = new Size(658, 611);
      this.dgEquipmentAudits.TabIndex = 15;
      this.tabDocuments.Location = new System.Drawing.Point(4, 22);
      this.tabDocuments.Name = "tabDocuments";
      this.tabDocuments.Size = new Size(675, 644);
      this.tabDocuments.TabIndex = 11;
      this.tabDocuments.Text = "Documents";
      this.tabDocuments.UseVisualStyleBackColor = true;
      this.tabGenerateWO.Controls.Add((Control) this.grpWorkOrder);
      this.tabGenerateWO.Location = new System.Drawing.Point(4, 22);
      this.tabGenerateWO.Name = "tabGenerateWO";
      this.tabGenerateWO.Size = new Size(675, 644);
      this.tabGenerateWO.TabIndex = 12;
      this.tabGenerateWO.Text = "Generate WO";
      this.tabGenerateWO.UseVisualStyleBackColor = true;
      this.grpWorkOrder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpWorkOrder.BackColor = SystemColors.Control;
      this.grpWorkOrder.Controls.Add((Control) this.txtEmail);
      this.grpWorkOrder.Controls.Add((Control) this.lblEmail);
      this.grpWorkOrder.Controls.Add((Control) this.btnGenerateAndEmail);
      this.grpWorkOrder.Controls.Add((Control) this.btnGenerate);
      this.grpWorkOrder.Controls.Add((Control) this.txtFaults);
      this.grpWorkOrder.Controls.Add((Control) this.lblFaults);
      this.grpWorkOrder.Location = new System.Drawing.Point(5, 7);
      this.grpWorkOrder.Name = "grpWorkOrder";
      this.grpWorkOrder.Size = new Size(664, 262);
      this.grpWorkOrder.TabIndex = 4;
      this.grpWorkOrder.TabStop = false;
      this.grpWorkOrder.Text = "Equipment Work Order";
      this.txtEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEmail.Location = new System.Drawing.Point(105, 164);
      this.txtEmail.MaxLength = 256;
      this.txtEmail.Name = "txtEmail";
      this.txtEmail.Size = new Size(542, 21);
      this.txtEmail.TabIndex = 475;
      this.txtEmail.Tag = (object) "Van.Registration";
      this.lblEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblEmail.Location = new System.Drawing.Point(6, 167);
      this.lblEmail.Name = "lblEmail";
      this.lblEmail.Size = new Size(85, 20);
      this.lblEmail.TabIndex = 476;
      this.lblEmail.Text = "Email";
      this.btnGenerateAndEmail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnGenerateAndEmail.BackColor = Color.White;
      this.btnGenerateAndEmail.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnGenerateAndEmail.Location = new System.Drawing.Point(495, 213);
      this.btnGenerateAndEmail.Name = "btnGenerateAndEmail";
      this.btnGenerateAndEmail.Size = new Size(152, 33);
      this.btnGenerateAndEmail.TabIndex = 474;
      this.btnGenerateAndEmail.Text = "Generate And Email";
      this.btnGenerateAndEmail.UseVisualStyleBackColor = false;
      this.btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnGenerate.BackColor = Color.White;
      this.btnGenerate.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnGenerate.Location = new System.Drawing.Point(6, 213);
      this.btnGenerate.Name = "btnGenerate";
      this.btnGenerate.Size = new Size(152, 33);
      this.btnGenerate.TabIndex = 473;
      this.btnGenerate.Text = "Generate";
      this.btnGenerate.UseVisualStyleBackColor = false;
      this.txtFaults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFaults.Location = new System.Drawing.Point(105, 25);
      this.txtFaults.Multiline = true;
      this.txtFaults.Name = "txtFaults";
      this.txtFaults.ScrollBars = ScrollBars.Vertical;
      this.txtFaults.Size = new Size(542, 105);
      this.txtFaults.TabIndex = 311;
      this.txtFaults.Tag = (object) "";
      this.lblFaults.Location = new System.Drawing.Point(6, 28);
      this.lblFaults.Name = "lblFaults";
      this.lblFaults.Size = new Size(53, 20);
      this.lblFaults.TabIndex = 312;
      this.lblFaults.Text = "Faults";
      this.Controls.Add((Control) this.tcVans);
      this.Name = nameof (UCEquipment);
      this.Size = new Size(693, 680);
      this.tcVans.ResumeLayout(false);
      this.tabDetails.ResumeLayout(false);
      this.grpVan.ResumeLayout(false);
      this.grpVan.PerformLayout();
      this.tabHistory.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.dgEquipmentAudits.EndInit();
      this.tabGenerateWO.ResumeLayout(false);
      this.grpWorkOrder.ResumeLayout(false);
      this.grpWorkOrder.PerformLayout();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.SetupDataGrid();
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentEquipment;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Equipment CurrentEquipment
    {
      get
      {
        return this._currentEquipment;
      }
      set
      {
        this._currentEquipment = value;
        if (this.CurrentEquipment == null)
        {
          this.CurrentEquipment = new Equipment();
          this.CurrentEquipment.Exists = false;
        }
        if (!this.CurrentEquipment.Exists)
          return;
        this.Populate(0);
        this.tabDocuments.Controls.Clear();
        this.DocumentsControl = new UCDocumentsList(Enums.TableNames.tblEquipment, this.CurrentEquipment.EquipmentID);
        this.tabDocuments.Controls.Add((Control) this.DocumentsControl);
      }
    }

    public Engineer theEngineer
    {
      get
      {
        return this._theEngineer;
      }
      set
      {
        this._theEngineer = value;
        if (this._theEngineer != null)
          this.txtEngineer.Text = this.theEngineer.Name;
        else
          this.txtEngineer.Text = "";
      }
    }

    private DataView EquipmentAuditsDataview
    {
      get
      {
        return this._dvEquipmentAudits;
      }
      set
      {
        this._dvEquipmentAudits = value;
        this._dvEquipmentAudits.AllowNew = false;
        this._dvEquipmentAudits.AllowEdit = false;
        this._dvEquipmentAudits.AllowDelete = false;
        this._dvEquipmentAudits.Table.TableName = Enums.TableNames.tblEquipmentAudit.ToString();
        this.dgEquipmentAudits.DataSource = (object) this.EquipmentAuditsDataview;
      }
    }

    private void SetupDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgEquipmentAudits.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Action";
      dataGridLabelColumn1.MappingName = "ActionChange";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 300;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Date";
      dataGridLabelColumn2.MappingName = "ActionDateTime";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 200;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "User";
      dataGridLabelColumn3.MappingName = "Fullname";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 200;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblEquipmentAudit.ToString();
      this.dgEquipmentAudits.TableStyles.Add(tableStyle);
    }

    private void UCEqupment_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID <= 0U)
        return;
      this.DisableControls();
      this.CurrentEquipment = App.DB.Engineer.Equipment_Get(ID);
      this.theEngineer = App.DB.Engineer.Engineer_Get(this.CurrentEquipment.EngineerID);
      this.txtEngineer.Text = this.theEngineer != null ? (this.theEngineer.EngineerID != 0 ? this.theEngineer.Name : "<Not Set>") : "<Not Set>";
      if (!this.IsEquipmentCalibrationValid(this.CurrentEquipment.CalibrationDate, checked ((int) Math.Round(this.CurrentEquipment.CalibrationMonths))) & this.CurrentEquipment.StatusID != 70985)
      {
        this.lblCalibrationStatus.Text = "Out of calibration";
        this.lblCalibrationStatus.ForeColor = Color.Red;
      }
      else
      {
        this.lblCalibrationStatus.Text = "Still in Calibration";
        this.lblCalibrationStatus.ForeColor = Color.Green;
      }
      this.txtNotes.Text = this.CurrentEquipment.Notes;
      this.txtAssetNumber.Text = this.CurrentEquipment.AssetNo;
      this.txtCallibrationPeriod.Text = Conversions.ToString(this.CurrentEquipment.CalibrationMonths);
      this.txtCalibrationCert.Text = this.CurrentEquipment.CertificateNumber;
      ComboBox combo = this.cboEquipmentType;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentEquipment.EquipmentTypeID));
      this.cboEquipmentType = combo;
      this.dtpCalibrationDate.Value = this.CurrentEquipment.CalibrationDate;
      this.dtpWarrantyExpires.Value = this.CurrentEquipment.WarrantyEndDate;
      this.txtDecription.Text = this.CurrentEquipment.Name;
      this.txtSerialNo.Text = this.CurrentEquipment.SerialNumber;
      combo = this.cboStatus;
      Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentEquipment.StatusID));
      this.cboStatus = combo;
      this.CurrentStatus = this.CurrentEquipment.StatusID;
      this.PopulateEquipmentAuditDatagrid();
    }

    private void PopulateEquipmentAuditDatagrid()
    {
      try
      {
        this.EquipmentAuditsDataview = App.DB.Engineer.EquipmentAudit_Get(this.CurrentEquipment.EquipmentID);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void DisableControls()
    {
      Enums.SecuritySystemModules ssm = Enums.SecuritySystemModules.Equipment;
      if (App.loggedInUser.HasAccessToModule(ssm))
        return;
      this.cboEquipmentType.Enabled = false;
      this.txtDecription.Enabled = false;
      this.txtSerialNo.Enabled = false;
      this.dtpCalibrationDate.Enabled = false;
      this.txtCallibrationPeriod.Enabled = false;
      this.txtCalibrationCert.Enabled = false;
      this.dtpWarrantyExpires.Enabled = false;
      this.txtAssetNumber.Enabled = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        if (this.txtCallibrationPeriod.Text.Length == 0)
        {
          int num1 = (int) App.ShowMessage("Please enter a calibration period", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else if (!Versioned.IsNumeric((object) this.txtCallibrationPeriod.Text))
        {
          int num2 = (int) App.ShowMessage("The Calibration Period Must be a Number", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else if (this.txtDecription.Text.Length == 0)
        {
          int num3 = (int) App.ShowMessage("You Must give this Equipment a Name", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) == 0.0 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboEquipmentType)) == 0.0)
        {
          int num4 = (int) App.ShowMessage("Please select a Staus and Equipment Type", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
          this.Cursor = Cursors.WaitCursor;
          this.CurrentEquipment.IgnoreExceptionsOnSetMethods = true;
          string actionChange = this.UpdateAudit();
          this.CurrentEquipment.SetEngineerID = this.theEngineer != null ? (this.theEngineer.EngineerID != 0 ? (object) this.theEngineer.EngineerID : (object) 0) : (object) 0;
          Equipment currentEquipment = this.CurrentEquipment;
          currentEquipment.StatusChangeDate = DateTime.Now;
          currentEquipment.SetNotes = (object) this.txtNotes.Text.Trim();
          currentEquipment.SetCalibrationMonths = (object) this.txtCallibrationPeriod.Text;
          currentEquipment.SetCertificateNumber = (object) this.txtCalibrationCert.Text;
          currentEquipment.SetEquipmentTypeID = (object) Combo.get_GetSelectedItemValue(this.cboEquipmentType);
          currentEquipment.CalibrationDate = this.dtpCalibrationDate.Value;
          currentEquipment.SetAssetNo = (object) this.txtAssetNumber.Text;
          currentEquipment.WarrantyEndDate = this.dtpWarrantyExpires.Value;
          currentEquipment.SetName = (object) this.txtDecription.Text;
          currentEquipment.SetSerialNumber = (object) this.txtSerialNo.Text;
          currentEquipment.SetStatusID = (object) Combo.get_GetSelectedItemValue(this.cboStatus);
          if (this.CurrentEquipment.Exists)
            App.DB.Engineer.EquipmentUpdate(this.CurrentEquipment);
          else
            this.CurrentEquipment = App.DB.Engineer.EquipmentInsert(this.CurrentEquipment);
          if (!string.IsNullOrEmpty(actionChange))
            App.DB.Engineer.EquipmentAudit_Insert(this.CurrentEquipment.EquipmentID, actionChange);
          // ISSUE: reference to a compiler-generated field
          IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
          if (recordsChangedEvent != null)
            recordsChangedEvent(App.DB.Engineer.Equipment_GetAll(), Enums.PageViewing.Equipment, true, false, "");
          // ISSUE: reference to a compiler-generated field
          IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
          if (stateChangedEvent != null)
            stateChangedEvent(this.CurrentEquipment.EquipmentID);
          App.MainForm.RefreshEntity(this.CurrentEquipment.EquipmentID, "");
          flag = true;
        }
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

    private string UpdateAudit()
    {
      bool flag = false;
      string str = "";
      Equipment currentEquipment = this.CurrentEquipment;
      if (currentEquipment.EquipmentID > 0)
      {
        if ((double) currentEquipment.EquipmentTypeID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboEquipmentType)))
        {
          flag = true;
          str = str + "Equipment type changed from: " + App.DB.Picklists.Get_One_As_Object(currentEquipment.EquipmentTypeID).Name + " to: " + App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboEquipmentType))).Name;
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentEquipment.Name, this.txtDecription.Text, false) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Name changed from: " + currentEquipment.Name + " to: " + this.txtDecription.Text;
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentEquipment.SerialNumber, this.txtSerialNo.Text, false) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Serial number changed from: " + currentEquipment.SerialNumber + " to: " + this.txtSerialNo.Text;
        }
        if ((uint) DateTime.Compare(currentEquipment.CalibrationDate, this.dtpCalibrationDate.Value) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Calibration date changed from: " + Conversions.ToString(currentEquipment.EquipmentTypeID) + " to: " + Conversions.ToString(this.dtpCalibrationDate.Value);
        }
        if (currentEquipment.CalibrationMonths != Conversions.ToDouble(this.txtCallibrationPeriod.Text))
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Calibration period changed from: " + Conversions.ToString(currentEquipment.CalibrationMonths) + " to: " + this.txtCallibrationPeriod.Text;
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentEquipment.CertificateNumber, this.txtCalibrationCert.Text, false) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Certifcate changed from: " + currentEquipment.CertificateNumber + " to: " + this.txtCalibrationCert.Text;
        }
        if ((uint) DateTime.Compare(currentEquipment.WarrantyEndDate, this.dtpWarrantyExpires.Value) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Warranty end date changed from: " + Conversions.ToString(currentEquipment.WarrantyEndDate) + " to: " + Conversions.ToString(this.dtpWarrantyExpires.Value);
        }
        if ((double) currentEquipment.StatusID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)))
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Status changed from: " + App.DB.Picklists.Get_One_As_Object(currentEquipment.StatusID).Name + " to: " + App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboStatus))).Name;
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentEquipment.AssetNo, this.txtAssetNumber.Text, false) > 0U)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Asset number changed from: " + currentEquipment.AssetNo + " to: " + this.txtAssetNumber.Text;
        }
        if (this.theEngineer == null & currentEquipment.EngineerID > 0)
        {
          if (flag)
            str += ", ";
          flag = true;
          str = str + "Equipment un-assigned from: " + App.DB.Engineer.Engineer_Get(currentEquipment.EngineerID).Name;
        }
        else if (this.theEngineer != null && currentEquipment.EngineerID != this.theEngineer.EngineerID)
        {
          if (flag)
            str += ", ";
          flag = true;
          if (currentEquipment.EngineerID == 0)
            str = str + "Engineer added: " + this.theEngineer.Name;
          else
            str = str + "Engineer changed from: " + App.DB.Engineer.Engineer_Get(currentEquipment.EngineerID).Name + " to: " + this.theEngineer.Name;
        }
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(currentEquipment.Notes, this.txtNotes.Text, false) > 0U)
        {
          if (flag)
            str += ", ";
          str += "Notes were updated";
        }
      }
      return str;
    }

    private void btnfindEngineer_Click_1(object sender, EventArgs e)
    {
      if (this.IsEquipmentCalibrationValid(this.dtpCalibrationDate.Value, Conversions.ToInteger(this.txtCallibrationPeriod.Text)))
      {
        int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
        if ((uint) integer <= 0U)
          return;
        this.theEngineer = App.DB.Engineer.Engineer_Get(integer);
        ComboBox cboStatus = this.cboStatus;
        Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(70873));
        this.cboStatus = cboStatus;
      }
      else
      {
        int num = (int) App.ShowMessage("Equipment is out calibration, please update date before assigning to engineer", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public bool IsEquipmentCalibrationValid(DateTime caliDate, int caliMonths)
    {
      if (caliMonths == 0)
        caliMonths = 12;
      return DateTime.Compare(caliDate.AddMonths(caliMonths), DateTime.Now) > 0;
    }

    private void dtpCalibrationDate_ValueChanged(object sender, EventArgs e)
    {
      if (this.IsEquipmentCalibrationValid(this.dtpCalibrationDate.Value, checked ((int) Math.Round(this.CurrentEquipment.CalibrationMonths))))
      {
        this.lblCalibrationStatus.Text = "Still in Calibration";
        this.lblCalibrationStatus.ForeColor = Color.Green;
      }
      else
      {
        this.lblCalibrationStatus.Text = "Out of calibration";
        this.lblCalibrationStatus.ForeColor = Color.Red;
      }
    }

    private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.IsEquipmentCalibrationValid(this.dtpCalibrationDate.Value, Conversions.ToInteger(this.txtCallibrationPeriod.Text)))
      {
        if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) == 70940.0 | Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) == 70873.0))
          return;
        int num = (int) App.ShowMessage("Equipment is out calibration, please update date before assigning to engineer", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        this.CurrentEquipment.SetStatusID = (object) 70985;
        ComboBox cboStatus = this.cboStatus;
        Combo.SetSelectedComboItem_By_Value(ref cboStatus, Conversions.ToString(this.CurrentEquipment.StatusID));
        this.cboStatus = cboStatus;
      }
      else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboStatus)) == 70940.0)
      {
        if (this.theEngineer != null)
          this.theEngineer = (Engineer) null;
        this.txtEngineer.Text = "<Not Set>";
      }
    }

    private void btnUnassign_Click(object sender, EventArgs e)
    {
      if (this.theEngineer != null)
        this.theEngineer = (Engineer) null;
      this.txtEngineer.Text = "<Not Set>";
    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
      if (this.CurrentEquipment == null)
        return;
      if (this.txtFaults.Text.Length <= 0)
      {
        int num = (int) App.ShowMessage("Please add faults!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.GenerateWorkOrder(false);
    }

    private void btnGenerateAndEmail_Click(object sender, EventArgs e)
    {
      if (this.CurrentEquipment == null)
        return;
      if (this.txtFaults.Text.Length <= 0)
      {
        int num1 = (int) App.ShowMessage("Please add faults!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.txtEmail.Text.Length <= 0)
      {
        int num2 = (int) App.ShowMessage("Please add email address!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        this.GenerateWorkOrder(true);
    }

    public void GenerateWorkOrder(bool email = false)
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add(new DataColumn("EquipmentID"));
      dataTable.Columns.Add(new DataColumn("SerialNumber"));
      dataTable.Columns.Add(new DataColumn("Faults"));
      dataTable.Columns.Add(new DataColumn("EmailAddress"));
      dataTable.Columns.Add(new DataColumn("SendEmail"));
      DataRow row = dataTable.NewRow();
      row["EquipmentID"] = (object) this.CurrentEquipment.EquipmentID;
      row["SerialNumber"] = (object) this.CurrentEquipment.SerialNumber;
      row["Faults"] = (object) this.txtFaults.Text;
      row["EmailAddress"] = (object) this.txtEmail.Text.Trim();
      row["SendEmail"] = (object) email;
      dataTable.Rows.Add(row);
      Printing printing = new Printing((object) dataTable, "Analyser ", Enums.SystemDocumentType.Analyser, false, 0, false, 13, 0, DateTime.MinValue, (DataTable) null);
    }
  }
}
