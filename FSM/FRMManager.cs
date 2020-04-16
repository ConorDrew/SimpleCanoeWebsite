// Decompiled with JetBrains decompiler
// Type: FSM.FRMManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Management;
using FSM.Entity.PickLists;
using FSM.Entity.Sys;
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
  public class FRMManager : FRMBaseForm, IForm
  {
    private IContainer components;
    private Enums.FormState _pageState;
    private DataView _dvManager;
    private Settings _settings;

    public FRMManager()
    {
      this.Load += new EventHandler(this.FRMManager_Load);
      this._settings = (Settings) null;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpItems { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgManager
    {
      get
      {
        return this._dgManager;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler1 = new EventHandler(this.dgManager_Click);
        EventHandler eventHandler2 = new EventHandler(this.dgManager_Click);
        DataGrid dgManager1 = this._dgManager;
        if (dgManager1 != null)
        {
          dgManager1.Click -= eventHandler1;
          dgManager1.CurrentCellChanged -= eventHandler2;
        }
        this._dgManager = value;
        DataGrid dgManager2 = this._dgManager;
        if (dgManager2 == null)
          return;
        dgManager2.Click += eventHandler1;
        dgManager2.CurrentCellChanged += eventHandler2;
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

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual GroupBox grpDetails { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual GroupBox grpSettings { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabControl tabSystemSettings { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabPrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCalloutPrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMiscPrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPPMPrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtQuotePrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSaveSettings
    {
      get
      {
        return this._btnSaveSettings;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveSettings_Click);
        Button btnSaveSettings1 = this._btnSaveSettings;
        if (btnSaveSettings1 != null)
          btnSaveSettings1.Click -= eventHandler;
        this._btnSaveSettings = value;
        Button btnSaveSettings2 = this._btnSaveSettings;
        if (btnSaveSettings2 == null)
          return;
        btnSaveSettings2.Click += eventHandler;
      }
    }

    internal virtual TabPage TabPage1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboWorkingHoursEnd { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboWorkingHoursStart { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTimeSlot { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRatesMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartsMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMileageRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabCharges { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabInvoicePrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInvoicePrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPercentageRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPercentageRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage TabPage2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtRecallVariable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TabPage tabImportSettings { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox GroupBox2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPartsImportMarkup { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtServiceFromLetterPrefix { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkMandatory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTimeSlot
    {
      get
      {
        return this._cboTimeSlot;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboTimeSlot_SelectedValueChanged);
        ComboBox cboTimeSlot1 = this._cboTimeSlot;
        if (cboTimeSlot1 != null)
          cboTimeSlot1.SelectedValueChanged -= eventHandler;
        this._cboTimeSlot = value;
        ComboBox cboTimeSlot2 = this._cboTimeSlot;
        if (cboTimeSlot2 == null)
          return;
        cboTimeSlot2.SelectedValueChanged += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpItems = new GroupBox();
      this.dgManager = new DataGrid();
      this.btnAddNew = new Button();
      this.btnDelete = new Button();
      this.Label1 = new Label();
      this.cboType = new ComboBox();
      this.grpDetails = new GroupBox();
      this.chkMandatory = new CheckBox();
      this.txtPercentageRate = new TextBox();
      this.lblPercentageRate = new Label();
      this.Label3 = new Label();
      this.txtName = new TextBox();
      this.txtDescription = new TextBox();
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.grpSettings = new GroupBox();
      this.btnSaveSettings = new Button();
      this.tabSystemSettings = new TabControl();
      this.tabImportSettings = new TabPage();
      this.GroupBox2 = new GroupBox();
      this.txtPartsImportMarkup = new TextBox();
      this.tabCharges = new TabPage();
      this.txtRatesMarkup = new TextBox();
      this.Label13 = new Label();
      this.txtPartsMarkup = new TextBox();
      this.Label12 = new Label();
      this.txtMileageRate = new TextBox();
      this.Label4 = new Label();
      this.tabPrefix = new TabPage();
      this.txtServiceFromLetterPrefix = new TextBox();
      this.Label7 = new Label();
      this.txtQuotePrefix = new TextBox();
      this.txtPPMPrefix = new TextBox();
      this.txtMiscPrefix = new TextBox();
      this.txtCalloutPrefix = new TextBox();
      this.Label11 = new Label();
      this.Label10 = new Label();
      this.Label9 = new Label();
      this.Label8 = new Label();
      this.TabPage1 = new TabPage();
      this.cboTimeSlot = new ComboBox();
      this.Label14 = new Label();
      this.lblTimeSlot = new Label();
      this.cboWorkingHoursEnd = new ComboBox();
      this.cboWorkingHoursStart = new ComboBox();
      this.Label16 = new Label();
      this.Label15 = new Label();
      this.tabInvoicePrefix = new TabPage();
      this.txtInvoicePrefix = new TextBox();
      this.Label5 = new Label();
      this.TabPage2 = new TabPage();
      this.GroupBox1 = new GroupBox();
      this.txtRecallVariable = new TextBox();
      this.Label6 = new Label();
      this.grpItems.SuspendLayout();
      this.dgManager.BeginInit();
      this.grpDetails.SuspendLayout();
      this.grpSettings.SuspendLayout();
      this.tabSystemSettings.SuspendLayout();
      this.tabImportSettings.SuspendLayout();
      this.GroupBox2.SuspendLayout();
      this.tabCharges.SuspendLayout();
      this.tabPrefix.SuspendLayout();
      this.TabPage1.SuspendLayout();
      this.tabInvoicePrefix.SuspendLayout();
      this.TabPage2.SuspendLayout();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.grpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpItems.Controls.Add((Control) this.dgManager);
      this.grpItems.Controls.Add((Control) this.btnAddNew);
      this.grpItems.Controls.Add((Control) this.btnDelete);
      this.grpItems.FlatStyle = FlatStyle.System;
      this.grpItems.Location = new System.Drawing.Point(8, 72);
      this.grpItems.Name = "grpItems";
      this.grpItems.Size = new Size(368, 416);
      this.grpItems.TabIndex = 5;
      this.grpItems.TabStop = false;
      this.grpItems.Text = "Items";
      this.dgManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgManager.DataMember = "";
      this.dgManager.HeaderForeColor = SystemColors.ControlText;
      this.dgManager.Location = new System.Drawing.Point(8, 53);
      this.dgManager.Name = "dgManager";
      this.dgManager.Size = new Size(352, 355);
      this.dgManager.TabIndex = 3;
      this.btnAddNew.AccessibleDescription = "Add new item";
      this.btnAddNew.Cursor = Cursors.Hand;
      this.btnAddNew.Location = new System.Drawing.Point(8, 24);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new Size(48, 23);
      this.btnAddNew.TabIndex = 2;
      this.btnAddNew.Text = "New";
      this.btnAddNew.UseVisualStyleBackColor = true;
      this.btnDelete.AccessibleDescription = "Delete item";
      this.btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDelete.Cursor = Cursors.Hand;
      this.btnDelete.Location = new System.Drawing.Point(312, 24);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new Size(48, 23);
      this.btnDelete.TabIndex = 4;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = true;
      this.Label1.Location = new System.Drawing.Point(8, 45);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 23);
      this.Label1.TabIndex = 4;
      this.Label1.Text = "Select Type";
      this.cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboType.Cursor = Cursors.Hand;
      this.cboType.DisplayMember = "Description";
      this.cboType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboType.Location = new System.Drawing.Point(88, 45);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(288, 21);
      this.cboType.TabIndex = 1;
      this.cboType.ValueMember = "Value";
      this.grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.grpDetails.Controls.Add((Control) this.chkMandatory);
      this.grpDetails.Controls.Add((Control) this.txtPercentageRate);
      this.grpDetails.Controls.Add((Control) this.lblPercentageRate);
      this.grpDetails.Controls.Add((Control) this.Label3);
      this.grpDetails.Controls.Add((Control) this.txtName);
      this.grpDetails.Controls.Add((Control) this.txtDescription);
      this.grpDetails.Controls.Add((Control) this.Label2);
      this.grpDetails.Controls.Add((Control) this.btnSave);
      this.grpDetails.FlatStyle = FlatStyle.System;
      this.grpDetails.Location = new System.Drawing.Point(384, 40);
      this.grpDetails.Name = "grpDetails";
      this.grpDetails.Size = new Size(392, 216);
      this.grpDetails.TabIndex = 7;
      this.grpDetails.TabStop = false;
      this.grpDetails.Text = "Details";
      this.chkMandatory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.chkMandatory.AutoSize = true;
      this.chkMandatory.Location = new System.Drawing.Point(208, 188);
      this.chkMandatory.Name = "chkMandatory";
      this.chkMandatory.Size = new Size(86, 17);
      this.chkMandatory.TabIndex = 10;
      this.chkMandatory.Text = "Mandatory";
      this.chkMandatory.TextAlign = ContentAlignment.MiddleRight;
      this.chkMandatory.UseVisualStyleBackColor = true;
      this.txtPercentageRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.txtPercentageRate.Location = new System.Drawing.Point(104, 184);
      this.txtPercentageRate.MaxLength = (int) byte.MaxValue;
      this.txtPercentageRate.Name = "txtPercentageRate";
      this.txtPercentageRate.Size = new Size(87, 21);
      this.txtPercentageRate.TabIndex = 9;
      this.txtPercentageRate.Visible = false;
      this.lblPercentageRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.lblPercentageRate.Location = new System.Drawing.Point(6, 184);
      this.lblPercentageRate.Name = "lblPercentageRate";
      this.lblPercentageRate.Size = new Size(72, 21);
      this.lblPercentageRate.TabIndex = 8;
      this.lblPercentageRate.Text = "Rate (%)";
      this.lblPercentageRate.Visible = false;
      this.Label3.Location = new System.Drawing.Point(8, 56);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(72, 23);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "Description";
      this.txtName.Location = new System.Drawing.Point(104, 24);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(280, 21);
      this.txtName.TabIndex = 5;
      this.txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.txtDescription.Location = new System.Drawing.Point(104, 56);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.ScrollBars = ScrollBars.Vertical;
      this.txtDescription.Size = new Size(280, 120);
      this.txtDescription.TabIndex = 6;
      this.Label2.Location = new System.Drawing.Point(8, 24);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(48, 23);
      this.Label2.TabIndex = 5;
      this.Label2.Text = "Name";
      this.btnSave.AccessibleDescription = "Save item";
      this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnSave.Cursor = Cursors.Hand;
      this.btnSave.ImageIndex = 1;
      this.btnSave.Location = new System.Drawing.Point(336, 184);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(48, 23);
      this.btnSave.TabIndex = 7;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.grpSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.grpSettings.Controls.Add((Control) this.btnSaveSettings);
      this.grpSettings.Controls.Add((Control) this.tabSystemSettings);
      this.grpSettings.FlatStyle = FlatStyle.System;
      this.grpSettings.Location = new System.Drawing.Point(384, 256);
      this.grpSettings.Name = "grpSettings";
      this.grpSettings.Size = new Size(392, 232);
      this.grpSettings.TabIndex = 11;
      this.grpSettings.TabStop = false;
      this.grpSettings.Text = "System Settings";
      this.btnSaveSettings.AccessibleDescription = "Save system settings";
      this.btnSaveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSaveSettings.Cursor = Cursors.Hand;
      this.btnSaveSettings.ImageIndex = 1;
      this.btnSaveSettings.Location = new System.Drawing.Point(336, 200);
      this.btnSaveSettings.Name = "btnSaveSettings";
      this.btnSaveSettings.Size = new Size(48, 23);
      this.btnSaveSettings.TabIndex = 20;
      this.btnSaveSettings.Text = "Save";
      this.btnSaveSettings.UseVisualStyleBackColor = true;
      this.tabSystemSettings.Controls.Add((Control) this.tabImportSettings);
      this.tabSystemSettings.Controls.Add((Control) this.tabCharges);
      this.tabSystemSettings.Controls.Add((Control) this.tabPrefix);
      this.tabSystemSettings.Controls.Add((Control) this.TabPage1);
      this.tabSystemSettings.Controls.Add((Control) this.tabInvoicePrefix);
      this.tabSystemSettings.Controls.Add((Control) this.TabPage2);
      this.tabSystemSettings.Location = new System.Drawing.Point(8, 24);
      this.tabSystemSettings.Name = "tabSystemSettings";
      this.tabSystemSettings.SelectedIndex = 0;
      this.tabSystemSettings.Size = new Size(376, 170);
      this.tabSystemSettings.TabIndex = 0;
      this.tabImportSettings.Controls.Add((Control) this.GroupBox2);
      this.tabImportSettings.Location = new System.Drawing.Point(4, 22);
      this.tabImportSettings.Name = "tabImportSettings";
      this.tabImportSettings.Padding = new Padding(3);
      this.tabImportSettings.Size = new Size(368, 144);
      this.tabImportSettings.TabIndex = 5;
      this.tabImportSettings.Text = "Import Settings";
      this.tabImportSettings.UseVisualStyleBackColor = true;
      this.GroupBox2.Controls.Add((Control) this.txtPartsImportMarkup);
      this.GroupBox2.Location = new System.Drawing.Point(5, -1);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(360, 132);
      this.GroupBox2.TabIndex = 0;
      this.GroupBox2.TabStop = false;
      this.GroupBox2.Text = "Part Import Markup";
      this.txtPartsImportMarkup.Location = new System.Drawing.Point(6, 20);
      this.txtPartsImportMarkup.Name = "txtPartsImportMarkup";
      this.txtPartsImportMarkup.Size = new Size(119, 21);
      this.txtPartsImportMarkup.TabIndex = 0;
      this.tabCharges.Controls.Add((Control) this.txtRatesMarkup);
      this.tabCharges.Controls.Add((Control) this.Label13);
      this.tabCharges.Controls.Add((Control) this.txtPartsMarkup);
      this.tabCharges.Controls.Add((Control) this.Label12);
      this.tabCharges.Controls.Add((Control) this.txtMileageRate);
      this.tabCharges.Controls.Add((Control) this.Label4);
      this.tabCharges.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tabCharges.Location = new System.Drawing.Point(4, 22);
      this.tabCharges.Name = "tabCharges";
      this.tabCharges.Size = new Size(368, 144);
      this.tabCharges.TabIndex = 0;
      this.tabCharges.Text = "Charges";
      this.tabCharges.UseVisualStyleBackColor = true;
      this.txtRatesMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtRatesMarkup.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtRatesMarkup.Location = new System.Drawing.Point(152, 72);
      this.txtRatesMarkup.Name = "txtRatesMarkup";
      this.txtRatesMarkup.Size = new Size(208, 21);
      this.txtRatesMarkup.TabIndex = 5;
      this.Label13.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label13.Location = new System.Drawing.Point(8, 72);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(144, 23);
      this.Label13.TabIndex = 53;
      this.Label13.Text = "Rates Markup";
      this.txtPartsMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPartsMarkup.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtPartsMarkup.Location = new System.Drawing.Point(152, 40);
      this.txtPartsMarkup.Name = "txtPartsMarkup";
      this.txtPartsMarkup.Size = new Size(208, 21);
      this.txtPartsMarkup.TabIndex = 4;
      this.Label12.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label12.Location = new System.Drawing.Point(8, 40);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(144, 23);
      this.Label12.TabIndex = 51;
      this.Label12.Text = "Parts Markup";
      this.txtMileageRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtMileageRate.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtMileageRate.Location = new System.Drawing.Point(152, 8);
      this.txtMileageRate.Name = "txtMileageRate";
      this.txtMileageRate.Size = new Size(208, 21);
      this.txtMileageRate.TabIndex = 0;
      this.Label4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(8, 8);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(88, 23);
      this.Label4.TabIndex = 43;
      this.Label4.Text = "Mileage Rate:";
      this.tabPrefix.Controls.Add((Control) this.txtServiceFromLetterPrefix);
      this.tabPrefix.Controls.Add((Control) this.Label7);
      this.tabPrefix.Controls.Add((Control) this.txtQuotePrefix);
      this.tabPrefix.Controls.Add((Control) this.txtPPMPrefix);
      this.tabPrefix.Controls.Add((Control) this.txtMiscPrefix);
      this.tabPrefix.Controls.Add((Control) this.txtCalloutPrefix);
      this.tabPrefix.Controls.Add((Control) this.Label11);
      this.tabPrefix.Controls.Add((Control) this.Label10);
      this.tabPrefix.Controls.Add((Control) this.Label9);
      this.tabPrefix.Controls.Add((Control) this.Label8);
      this.tabPrefix.Location = new System.Drawing.Point(4, 22);
      this.tabPrefix.Name = "tabPrefix";
      this.tabPrefix.Size = new Size(368, 144);
      this.tabPrefix.TabIndex = 1;
      this.tabPrefix.Text = "Job Prefixes";
      this.tabPrefix.UseVisualStyleBackColor = true;
      this.txtServiceFromLetterPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtServiceFromLetterPrefix.Location = new System.Drawing.Point(174, 116);
      this.txtServiceFromLetterPrefix.MaxLength = 4;
      this.txtServiceFromLetterPrefix.Name = "txtServiceFromLetterPrefix";
      this.txtServiceFromLetterPrefix.Size = new Size(186, 21);
      this.txtServiceFromLetterPrefix.TabIndex = 18;
      this.Label7.Location = new System.Drawing.Point(8, 116);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(182, 23);
      this.Label7.TabIndex = 17;
      this.Label7.Text = "Service From Letter Prefix:";
      this.txtQuotePrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtQuotePrefix.Location = new System.Drawing.Point(174, 89);
      this.txtQuotePrefix.MaxLength = 4;
      this.txtQuotePrefix.Name = "txtQuotePrefix";
      this.txtQuotePrefix.Size = new Size(186, 21);
      this.txtQuotePrefix.TabIndex = 16;
      this.txtPPMPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPPMPrefix.Location = new System.Drawing.Point(174, 62);
      this.txtPPMPrefix.MaxLength = 4;
      this.txtPPMPrefix.Name = "txtPPMPrefix";
      this.txtPPMPrefix.Size = new Size(186, 21);
      this.txtPPMPrefix.TabIndex = 15;
      this.txtMiscPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtMiscPrefix.Location = new System.Drawing.Point(174, 35);
      this.txtMiscPrefix.MaxLength = 4;
      this.txtMiscPrefix.Name = "txtMiscPrefix";
      this.txtMiscPrefix.Size = new Size(186, 21);
      this.txtMiscPrefix.TabIndex = 14;
      this.txtCalloutPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCalloutPrefix.Location = new System.Drawing.Point(174, 8);
      this.txtCalloutPrefix.MaxLength = 4;
      this.txtCalloutPrefix.Name = "txtCalloutPrefix";
      this.txtCalloutPrefix.Size = new Size(186, 21);
      this.txtCalloutPrefix.TabIndex = 13;
      this.Label11.Location = new System.Drawing.Point(8, 89);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(80, 23);
      this.Label11.TabIndex = 3;
      this.Label11.Text = "Quote Prefix:";
      this.Label10.Location = new System.Drawing.Point(8, 62);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(80, 23);
      this.Label10.TabIndex = 2;
      this.Label10.Text = "PPM Prefix:";
      this.Label9.Location = new System.Drawing.Point(8, 35);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(136, 23);
      this.Label9.TabIndex = 1;
      this.Label9.Text = "Miscellaneous Prefix:";
      this.Label8.Location = new System.Drawing.Point(8, 8);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(96, 23);
      this.Label8.TabIndex = 0;
      this.Label8.Text = "Callout Prefix:";
      this.TabPage1.Controls.Add((Control) this.cboTimeSlot);
      this.TabPage1.Controls.Add((Control) this.Label14);
      this.TabPage1.Controls.Add((Control) this.lblTimeSlot);
      this.TabPage1.Controls.Add((Control) this.cboWorkingHoursEnd);
      this.TabPage1.Controls.Add((Control) this.cboWorkingHoursStart);
      this.TabPage1.Controls.Add((Control) this.Label16);
      this.TabPage1.Controls.Add((Control) this.Label15);
      this.TabPage1.Location = new System.Drawing.Point(4, 22);
      this.TabPage1.Name = "TabPage1";
      this.TabPage1.Size = new Size(368, 144);
      this.TabPage1.TabIndex = 2;
      this.TabPage1.Text = "Working Day";
      this.TabPage1.UseVisualStyleBackColor = true;
      this.cboTimeSlot.Items.AddRange(new object[4]
      {
        (object) "15",
        (object) "30",
        (object) "45",
        (object) "60"
      });
      this.cboTimeSlot.Location = new System.Drawing.Point(152, 8);
      this.cboTimeSlot.Name = "cboTimeSlot";
      this.cboTimeSlot.Size = new Size(80, 21);
      this.cboTimeSlot.TabIndex = 53;
      this.Label14.Location = new System.Drawing.Point(240, 8);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(48, 16);
      this.Label14.TabIndex = 51;
      this.Label14.Text = "Minutes";
      this.lblTimeSlot.Location = new System.Drawing.Point(8, 8);
      this.lblTimeSlot.Name = "lblTimeSlot";
      this.lblTimeSlot.Size = new Size(128, 23);
      this.lblTimeSlot.TabIndex = 47;
      this.lblTimeSlot.Text = "Time Slot Duration";
      this.cboWorkingHoursEnd.Cursor = Cursors.Hand;
      this.cboWorkingHoursEnd.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboWorkingHoursEnd.Location = new System.Drawing.Point(152, 72);
      this.cboWorkingHoursEnd.Name = "cboWorkingHoursEnd";
      this.cboWorkingHoursEnd.Size = new Size(80, 21);
      this.cboWorkingHoursEnd.TabIndex = 18;
      this.cboWorkingHoursStart.Cursor = Cursors.Hand;
      this.cboWorkingHoursStart.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboWorkingHoursStart.Location = new System.Drawing.Point(152, 40);
      this.cboWorkingHoursStart.Name = "cboWorkingHoursStart";
      this.cboWorkingHoursStart.Size = new Size(80, 21);
      this.cboWorkingHoursStart.TabIndex = 17;
      this.Label16.Location = new System.Drawing.Point(8, 72);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(120, 16);
      this.Label16.TabIndex = 46;
      this.Label16.Text = "Working Hours End";
      this.Label15.Location = new System.Drawing.Point(8, 40);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(128, 23);
      this.Label15.TabIndex = 45;
      this.Label15.Text = "Working Hours Start";
      this.tabInvoicePrefix.Controls.Add((Control) this.txtInvoicePrefix);
      this.tabInvoicePrefix.Controls.Add((Control) this.Label5);
      this.tabInvoicePrefix.Location = new System.Drawing.Point(4, 22);
      this.tabInvoicePrefix.Name = "tabInvoicePrefix";
      this.tabInvoicePrefix.Size = new Size(368, 144);
      this.tabInvoicePrefix.TabIndex = 3;
      this.tabInvoicePrefix.Text = "Invoice Prefix";
      this.tabInvoicePrefix.UseVisualStyleBackColor = true;
      this.txtInvoicePrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtInvoicePrefix.Location = new System.Drawing.Point(144, 16);
      this.txtInvoicePrefix.MaxLength = 4;
      this.txtInvoicePrefix.Name = "txtInvoicePrefix";
      this.txtInvoicePrefix.Size = new Size(208, 21);
      this.txtInvoicePrefix.TabIndex = 15;
      this.Label5.Location = new System.Drawing.Point(8, 16);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(96, 23);
      this.Label5.TabIndex = 14;
      this.Label5.Text = "Invoice Prefix:";
      this.TabPage2.Controls.Add((Control) this.GroupBox1);
      this.TabPage2.Location = new System.Drawing.Point(4, 22);
      this.TabPage2.Name = "TabPage2";
      this.TabPage2.Padding = new Padding(3);
      this.TabPage2.Size = new Size(368, 144);
      this.TabPage2.TabIndex = 4;
      this.TabPage2.Text = "Engineers Performance";
      this.TabPage2.UseVisualStyleBackColor = true;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.txtRecallVariable);
      this.GroupBox1.Controls.Add((Control) this.Label6);
      this.GroupBox1.Location = new System.Drawing.Point(6, 6);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(359, 132);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Engineer Performance Report";
      this.txtRecallVariable.Location = new System.Drawing.Point(9, 54);
      this.txtRecallVariable.Name = "txtRecallVariable";
      this.txtRecallVariable.Size = new Size(100, 21);
      this.txtRecallVariable.TabIndex = 1;
      this.Label6.Location = new System.Drawing.Point(6, 17);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(288, 44);
      this.Label6.TabIndex = 0;
      this.Label6.Text = "Engineer Performance - No Of Days to see if a recall has been carried out at site.";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(784, 494);
      this.Controls.Add((Control) this.grpSettings);
      this.Controls.Add((Control) this.grpDetails);
      this.Controls.Add((Control) this.grpItems);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.cboType);
      this.MinimumSize = new Size(792, 528);
      this.Name = nameof (FRMManager);
      this.Text = "Picklists / Settings";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.cboType, 0);
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.grpItems, 0);
      this.Controls.SetChildIndex((Control) this.grpDetails, 0);
      this.Controls.SetChildIndex((Control) this.grpSettings, 0);
      this.grpItems.ResumeLayout(false);
      this.dgManager.EndInit();
      this.grpDetails.ResumeLayout(false);
      this.grpDetails.PerformLayout();
      this.grpSettings.ResumeLayout(false);
      this.tabSystemSettings.ResumeLayout(false);
      this.tabImportSettings.ResumeLayout(false);
      this.GroupBox2.ResumeLayout(false);
      this.GroupBox2.PerformLayout();
      this.tabCharges.ResumeLayout(false);
      this.tabCharges.PerformLayout();
      this.tabPrefix.ResumeLayout(false);
      this.tabPrefix.PerformLayout();
      this.TabPage1.ResumeLayout(false);
      this.tabInvoicePrefix.ResumeLayout(false);
      this.tabInvoicePrefix.PerformLayout();
      this.TabPage2.ResumeLayout(false);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupManagerDataGrid();
      this.Settings = App.DB.Manager.Get();
      ComboBox cboType1 = this.cboType;
      Combo.SetUpCombo(ref cboType1, App.DB.Picklists.PickListTypes().Table, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboType = cboType1;
      this.cboTimeSlot.SelectedItem = (object) this.Settings.TimeSlot.ToString();
      ComboBox workingHoursStart1 = this.cboWorkingHoursStart;
      Combo.SetUpCombo(ref workingHoursStart1, DynamicDataTables.Times(Conversions.ToInteger(this.cboTimeSlot.SelectedItem)), "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboWorkingHoursStart = workingHoursStart1;
      ComboBox cboWorkingHoursEnd1 = this.cboWorkingHoursEnd;
      Combo.SetUpCombo(ref cboWorkingHoursEnd1, DynamicDataTables.Times(Conversions.ToInteger(this.cboTimeSlot.SelectedItem)), "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboWorkingHoursEnd = cboWorkingHoursEnd1;
      this.PopulateDatagrid(Enums.FormState.Load);
      ComboBox cboType2 = this.cboType;
      Combo.SetSelectedComboItem_By_Value(ref cboType2, Conversions.ToString(0));
      this.cboType = cboType2;
      ComboBox workingHoursStart2 = this.cboWorkingHoursStart;
      Combo.SetSelectedComboItem_By_Value(ref workingHoursStart2, this.Settings.WorkingHoursStart);
      this.cboWorkingHoursStart = workingHoursStart2;
      ComboBox cboWorkingHoursEnd2 = this.cboWorkingHoursEnd;
      Combo.SetSelectedComboItem_By_Value(ref cboWorkingHoursEnd2, this.Settings.WorkingHoursEnd);
      this.cboWorkingHoursEnd = cboWorkingHoursEnd2;
      this.txtMileageRate.Text = Conversions.ToString(this.Settings.MileageRate);
      this.txtPartsMarkup.Text = Conversions.ToString(this.Settings.PartsMarkup);
      this.txtRatesMarkup.Text = Conversions.ToString(this.Settings.RatesMarkup);
      this.txtCalloutPrefix.Text = this.Settings.CalloutPrefix;
      this.txtMiscPrefix.Text = this.Settings.MiscPrefix;
      this.txtQuotePrefix.Text = this.Settings.QuotePrefix;
      this.txtPPMPrefix.Text = this.Settings.PPMPrefix;
      this.txtRecallVariable.Text = Conversions.ToString(this.Settings.RecallVariable);
      this.txtInvoicePrefix.Text = this.Settings.InvoicePrefix;
      this.txtPartsImportMarkup.Text = Conversions.ToString(this.Settings.PartsImportMarkup);
      this.txtServiceFromLetterPrefix.Text = this.Settings.ServiceFromLetterPrefix;
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

    private DataView ManagerDataview
    {
      get
      {
        return this._dvManager;
      }
      set
      {
        this._dvManager = value;
        this._dvManager.AllowNew = false;
        this._dvManager.AllowEdit = false;
        this._dvManager.AllowDelete = false;
        this._dvManager.Table.TableName = Enums.TableNames.tblPickLists.ToString();
        this.dgManager.DataSource = (object) this.ManagerDataview;
      }
    }

    private DataRow SelectedManagerDataRow
    {
      get
      {
        return this.dgManager.CurrentRowIndex != -1 ? this.ManagerDataview[this.dgManager.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public Settings Settings
    {
      get
      {
        return this._settings;
      }
      set
      {
        this._settings = value;
      }
    }

    private void SetupManagerDataGrid()
    {
      DataGridTableStyle tableStyle = this.dgManager.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Name";
      dataGridLabelColumn1.MappingName = "Name";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 177;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Description";
      dataGridLabelColumn2.MappingName = "Description";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 177;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblPickLists.ToString();
      this.dgManager.TableStyles.Add(tableStyle);
    }

    private void SetUpPageState(Enums.FormState state)
    {
      Helper.ClearGroupBox(this.grpDetails);
      switch (state)
      {
        case Enums.FormState.Load:
          this.grpDetails.Enabled = false;
          this.btnAddNew.Enabled = false;
          this.btnDelete.Enabled = false;
          this.btnSave.Enabled = false;
          break;
        case Enums.FormState.Insert:
          this.grpDetails.Enabled = true;
          this.btnAddNew.Enabled = true;
          this.btnDelete.Enabled = false;
          this.btnSave.Enabled = true;
          break;
        case Enums.FormState.Update:
          this.btnAddNew.Enabled = true;
          this.grpDetails.Enabled = true;
          this.btnSave.Enabled = true;
          this.btnDelete.Enabled = true;
          break;
      }
      this.PageState = state;
    }

    private void FRMManager_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void cboType_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.cboType.SelectedIndex == 0)
        this.PopulateDatagrid(Enums.FormState.Load);
      else
        this.PopulateDatagrid(Enums.FormState.Insert);
    }

    private void dgManager_Click(object sender, EventArgs e)
    {
      try
      {
        this.SetUpPageState(Enums.FormState.Update);
        if (this.SelectedManagerDataRow != null)
        {
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["Name"])), "RC - Recall", false) == 0)
          {
            int num = (int) App.ShowMessage("This item cannont be edited", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.SetUpPageState(Enums.FormState.Insert);
          }
          else
          {
            this.txtName.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["Name"]));
            this.txtDescription.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["Description"]));
            this.txtPercentageRate.Text = Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["PercentageRate"])));
            this.chkMandatory.Checked = Helper.MakeBooleanValid(RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["Mandatory"]));
          }
        }
        else if (this.cboType.SelectedIndex == 0)
          this.SetUpPageState(Enums.FormState.Load);
        else
          this.SetUpPageState(Enums.FormState.Insert);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Item data cannot load : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      this.SetUpPageState(Enums.FormState.Insert);
    }

    private void btnSaveSettings_Click(object sender, EventArgs e)
    {
      this.SaveSettings();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      this.Delete();
    }

    private void cboTimeSlot_SelectedValueChanged(object sender, EventArgs e)
    {
      ComboBox workingHoursStart1 = this.cboWorkingHoursStart;
      Combo.SetUpCombo(ref workingHoursStart1, DynamicDataTables.Times(Conversions.ToInteger(this.cboTimeSlot.SelectedItem)), "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboWorkingHoursStart = workingHoursStart1;
      ComboBox cboWorkingHoursEnd1 = this.cboWorkingHoursEnd;
      Combo.SetUpCombo(ref cboWorkingHoursEnd1, DynamicDataTables.Times(Conversions.ToInteger(this.cboTimeSlot.SelectedItem)), "ValueMember", "DisplayMember", Enums.ComboValues.None);
      this.cboWorkingHoursEnd = cboWorkingHoursEnd1;
      ComboBox workingHoursStart2 = this.cboWorkingHoursStart;
      Combo.SetSelectedComboItem_By_Value(ref workingHoursStart2, this.Settings.WorkingHoursStart);
      this.cboWorkingHoursStart = workingHoursStart2;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboWorkingHoursStart), "0", false) == 0)
        this.cboWorkingHoursStart.SelectedIndex = 0;
      ComboBox cboWorkingHoursEnd2 = this.cboWorkingHoursEnd;
      Combo.SetSelectedComboItem_By_Value(ref cboWorkingHoursEnd2, this.Settings.WorkingHoursEnd);
      this.cboWorkingHoursEnd = cboWorkingHoursEnd2;
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboWorkingHoursEnd), "0", false) != 0)
        return;
      this.cboWorkingHoursEnd.SelectedIndex = checked (this.cboWorkingHoursEnd.Items.Count - 1);
    }

    private void PopulateDatagrid(Enums.FormState state)
    {
      try
      {
        this.lblPercentageRate.Visible = false;
        this.txtPercentageRate.Visible = false;
        if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 0)
        {
          this.ManagerDataview = new DataView(new DataTable()
          {
            TableName = Enums.TableNames.tblPickLists.ToString()
          });
        }
        else
        {
          this.ManagerDataview = App.DB.Picklists.GetAll((Enums.PickListTypes) Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)), false);
          switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)))
          {
            case 7:
              this.lblPercentageRate.Text = "Rate";
              this.lblPercentageRate.Visible = true;
              this.txtPercentageRate.Visible = true;
              break;
            case 21:
            case 41:
            case 60:
              this.lblPercentageRate.Text = "Perc Rate";
              this.lblPercentageRate.Visible = true;
              this.txtPercentageRate.Visible = true;
              break;
          }
        }
        this.SetUpPageState(state);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void SaveSettings()
    {
      try
      {
        this.Settings.IgnoreExceptionsOnSetMethods = true;
        this.Settings.SetWorkingHoursStart = (object) Combo.get_GetSelectedItemValue(this.cboWorkingHoursStart);
        this.Settings.SetWorkingHoursEnd = (object) Combo.get_GetSelectedItemValue(this.cboWorkingHoursEnd);
        this.Settings.SetMileageRate = (object) this.txtMileageRate.Text.Trim();
        this.Settings.SetPartsMarkup = (object) this.txtPartsMarkup.Text.Trim();
        this.Settings.SetRatesMarkup = (object) this.txtRatesMarkup.Text.Trim();
        this.Settings.SetCalloutPrefix = (object) this.txtCalloutPrefix.Text.Trim();
        this.Settings.SetMiscPrefix = (object) this.txtMiscPrefix.Text.Trim();
        this.Settings.SetPPMPrefix = (object) this.txtPPMPrefix.Text.Trim();
        this.Settings.SetQuotePrefix = (object) this.txtQuotePrefix.Text.Trim();
        this.Settings.SetTimeSlot = RuntimeHelpers.GetObjectValue(this.cboTimeSlot.SelectedItem);
        this.Settings.SetInvoicePrefix = (object) this.txtInvoicePrefix.Text.Trim();
        this.Settings.SetRecallVariable = (object) this.txtRecallVariable.Text.Trim();
        this.Settings.SetPartsImportMarkup = (object) this.txtPartsImportMarkup.Text.Trim();
        this.Settings.SetServiceFromLetterPrefix = (object) this.txtServiceFromLetterPrefix.Text.Trim();
        new SettingsValidator().Validate(this.Settings);
        App.DB.Manager.UpdateSettings(this.Settings);
        App.DB.CustomerCharge.UpdateALL(this.Settings.MileageRate, this.Settings.PartsMarkup, this.Settings.RatesMarkup);
        int num = (int) App.ShowMessage("Settings updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Saving : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void Save()
    {
      PickList pickList = new PickList();
      pickList.IgnoreExceptionsOnSetMethods = true;
      pickList.SetName = (object) this.txtName.Text.Trim();
      pickList.SetDescription = (object) this.txtDescription.Text.Trim();
      pickList.SetEnumTypeID = (object) Combo.get_GetSelectedItemValue(this.cboType);
      pickList.SetMandatory = this.chkMandatory.Checked;
      switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)))
      {
        case 21:
        case 41:
        case 60:
          pickList.SetPercentageRate = (object) this.txtPercentageRate.Text.Trim();
          break;
        default:
          pickList.SetPercentageRate = (object) 0.0;
          if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 7)
          {
            pickList.SetPercentageRate = (object) this.txtPercentageRate.Text.Trim();
            break;
          }
          break;
      }
      if (this.PageState == Enums.FormState.Update)
        pickList.SetManagerID = RuntimeHelpers.GetObjectValue(this.SelectedManagerDataRow["ManagerID"]);
      PickListValidator pickListValidator = new PickListValidator();
      try
      {
        pickListValidator.Validate(pickList);
        switch (this.PageState)
        {
          case Enums.FormState.Insert:
            App.DB.Picklists.Insert(pickList);
            break;
          case Enums.FormState.Update:
            App.DB.Picklists.Update(pickList);
            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 21)
            {
              App.DB.Picklists.UpdateSellPrices(pickList);
              break;
            }
            break;
        }
        this.PopulateDatagrid(Enums.FormState.Insert);
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(pickListValidator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error Saving : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void Delete()
    {
      try
      {
        if (this.SelectedManagerDataRow != null)
        {
          if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Are you sure you want to delete \"", this.SelectedManagerDataRow["Name"]), (object) "\" from \""), (object) Combo.get_GetSelectedItemDescription(this.cboType)), (object) "\"?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
          {
            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboType)) == 3)
            {
              DataView dataView = App.DB.Picklists.Region_Usage(Conversions.ToInteger(this.SelectedManagerDataRow["ManagerID"]));
              if (dataView.Table.Rows.Count > 0)
              {
                string text = "The region you are trying to delete is still allocated to the following records:\r\n";
                IEnumerator enumerator;
                try
                {
                  enumerator = dataView.Table.Rows.GetEnumerator();
                  while (enumerator.MoveNext())
                  {
                    DataRow current = (DataRow) enumerator.Current;
                    text = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject((object) text, Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "* ", current["type"]), (object) " - "), current["Name"]), (object) "\r\n")));
                  }
                }
                finally
                {
                  if (enumerator is IDisposable)
                    (enumerator as IDisposable).Dispose();
                }
                int num = (int) MessageBox.Show(text, "Region Delete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
              }
            }
            App.DB.Picklists.Delete(Conversions.ToInteger(this.SelectedManagerDataRow["ManagerID"]));
            this.PopulateDatagrid(Enums.FormState.Insert);
          }
        }
        else
        {
          int num1 = (int) App.ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Error deleting : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }
  }
}
