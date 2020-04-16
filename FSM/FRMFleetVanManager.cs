// Decompiled with JetBrains decompiler
// Type: FSM.FRMFleetVanManager
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Engineers;
using FSM.Entity.FleetVans;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
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
  public class FRMFleetVanManager : FRMBaseForm
  {
    private IContainer components;
    private FleetVan _currentVan;
    private Engineer _engineer;
    private DataView _dvFaults;
    private DataView _dvEngineerHistory;

    public FRMFleetVanManager()
    {
      this.Load += new EventHandler(this.FRMImport_Load);
      this._dvFaults = (DataView) null;
      this.InitializeComponent();
      ComboBox cboFaultType = this.cboFaultType;
      Combo.SetUpCombo(ref cboFaultType, App.DB.FleetVanFault.FaultTypes_GetAll().Table, "VanFaultTypeID", "Name", Enums.ComboValues.Please_Select);
      this.cboFaultType = cboFaultType;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpFaultsFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpFaultDG { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgFaults
    {
      get
      {
        return this._dgFaults;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgFaults_DoubleClick);
        DataGrid dgFaults1 = this._dgFaults;
        if (dgFaults1 != null)
          dgFaults1.DoubleClick -= eventHandler;
        this._dgFaults = value;
        DataGrid dgFaults2 = this._dgFaults;
        if (dgFaults2 == null)
          return;
        dgFaults2.DoubleClick += eventHandler;
      }
    }

    internal virtual GroupBox grpEngineerFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpEngineerHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRegistration { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnfindVan
    {
      get
      {
        return this._btnfindVan;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnfindVan_Click);
        Button btnfindVan1 = this._btnfindVan;
        if (btnfindVan1 != null)
          btnfindVan1.Click -= eventHandler;
        this._btnfindVan = value;
        Button btnfindVan2 = this._btnfindVan;
        if (btnfindVan2 == null)
          return;
        btnfindVan2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtVanReg { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFaultType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaultType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpResolvedTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpResolvedFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblResolvedTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblResolvedFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkResolved { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFaultTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpFaultFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaultTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaultFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkFaultDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpEngineerTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpEngineerFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineerTo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEngineerFrom { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSearchFault
    {
      get
      {
        return this._btnSearchFault;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSearchFault_Click);
        Button btnSearchFault1 = this._btnSearchFault;
        if (btnSearchFault1 != null)
          btnSearchFault1.Click -= eventHandler;
        this._btnSearchFault = value;
        Button btnSearchFault2 = this._btnSearchFault;
        if (btnSearchFault2 == null)
          return;
        btnSearchFault2.Click += eventHandler;
      }
    }

    internal virtual Button btnSearchEngineer
    {
      get
      {
        return this._btnSearchEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSearchEngineer_Click);
        Button btnSearchEngineer1 = this._btnSearchEngineer;
        if (btnSearchEngineer1 != null)
          btnSearchEngineer1.Click -= eventHandler;
        this._btnSearchEngineer = value;
        Button btnSearchEngineer2 = this._btnSearchEngineer;
        if (btnSearchEngineer2 == null)
          return;
        btnSearchEngineer2.Click += eventHandler;
      }
    }

    internal virtual Button btnfindEngineer
    {
      get
      {
        return this._btnfindEngineer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnfindEngineer_Click);
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

    internal virtual Label lblEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClear
    {
      get
      {
        return this._btnClear;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClear_Click);
        Button btnClear1 = this._btnClear;
        if (btnClear1 != null)
          btnClear1.Click -= eventHandler;
        this._btnClear = value;
        Button btnClear2 = this._btnClear;
        if (btnClear2 == null)
          return;
        btnClear2.Click += eventHandler;
      }
    }

    internal virtual DataGrid dgEngineerHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpFaultsFilter = new GroupBox();
      this.btnSearchFault = new Button();
      this.dtpResolvedTo = new DateTimePicker();
      this.dtpResolvedFrom = new DateTimePicker();
      this.lblResolvedTo = new Label();
      this.lblResolvedFrom = new Label();
      this.chkResolved = new CheckBox();
      this.dtpFaultTo = new DateTimePicker();
      this.dtpFaultFrom = new DateTimePicker();
      this.lblFaultTo = new Label();
      this.lblFaultFrom = new Label();
      this.chkFaultDate = new CheckBox();
      this.cboFaultType = new ComboBox();
      this.lblFaultType = new Label();
      this.grpFaultDG = new GroupBox();
      this.dgFaults = new DataGrid();
      this.grpEngineerFilter = new GroupBox();
      this.btnfindEngineer = new Button();
      this.txtEngineer = new TextBox();
      this.lblEngineer = new Label();
      this.btnSearchEngineer = new Button();
      this.dtpEngineerTo = new DateTimePicker();
      this.dtpEngineerFrom = new DateTimePicker();
      this.lblEngineerTo = new Label();
      this.lblEngineerFrom = new Label();
      this.grpEngineerHistory = new GroupBox();
      this.dgEngineerHistory = new DataGrid();
      this.grpFilter = new GroupBox();
      this.lblRegistration = new Label();
      this.btnfindVan = new Button();
      this.txtVanReg = new TextBox();
      this.btnClear = new Button();
      this.grpFaultsFilter.SuspendLayout();
      this.grpFaultDG.SuspendLayout();
      this.dgFaults.BeginInit();
      this.grpEngineerFilter.SuspendLayout();
      this.grpEngineerHistory.SuspendLayout();
      this.dgEngineerHistory.BeginInit();
      this.grpFilter.SuspendLayout();
      this.SuspendLayout();
      this.grpFaultsFilter.Controls.Add((Control) this.btnSearchFault);
      this.grpFaultsFilter.Controls.Add((Control) this.dtpResolvedTo);
      this.grpFaultsFilter.Controls.Add((Control) this.dtpResolvedFrom);
      this.grpFaultsFilter.Controls.Add((Control) this.lblResolvedTo);
      this.grpFaultsFilter.Controls.Add((Control) this.lblResolvedFrom);
      this.grpFaultsFilter.Controls.Add((Control) this.chkResolved);
      this.grpFaultsFilter.Controls.Add((Control) this.dtpFaultTo);
      this.grpFaultsFilter.Controls.Add((Control) this.dtpFaultFrom);
      this.grpFaultsFilter.Controls.Add((Control) this.lblFaultTo);
      this.grpFaultsFilter.Controls.Add((Control) this.lblFaultFrom);
      this.grpFaultsFilter.Controls.Add((Control) this.chkFaultDate);
      this.grpFaultsFilter.Controls.Add((Control) this.cboFaultType);
      this.grpFaultsFilter.Controls.Add((Control) this.lblFaultType);
      this.grpFaultsFilter.FlatStyle = FlatStyle.System;
      this.grpFaultsFilter.Location = new System.Drawing.Point(8, 107);
      this.grpFaultsFilter.Name = "grpFaultsFilter";
      this.grpFaultsFilter.Size = new Size(842, 169);
      this.grpFaultsFilter.TabIndex = 3;
      this.grpFaultsFilter.TabStop = false;
      this.grpFaultsFilter.Text = "Filter Faults";
      this.btnSearchFault.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSearchFault.Location = new System.Drawing.Point(766, 140);
      this.btnSearchFault.Name = "btnSearchFault";
      this.btnSearchFault.Size = new Size(70, 23);
      this.btnSearchFault.TabIndex = 78;
      this.btnSearchFault.Text = "Run Filter";
      this.dtpResolvedTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpResolvedTo.Location = new System.Drawing.Point(325, 103);
      this.dtpResolvedTo.Name = "dtpResolvedTo";
      this.dtpResolvedTo.Size = new Size(156, 21);
      this.dtpResolvedTo.TabIndex = 77;
      this.dtpResolvedFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpResolvedFrom.Location = new System.Drawing.Point(325, 72);
      this.dtpResolvedFrom.Name = "dtpResolvedFrom";
      this.dtpResolvedFrom.Size = new Size(156, 21);
      this.dtpResolvedFrom.TabIndex = 76;
      this.lblResolvedTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblResolvedTo.Location = new System.Drawing.Point(271, 108);
      this.lblResolvedTo.Name = "lblResolvedTo";
      this.lblResolvedTo.Size = new Size(48, 16);
      this.lblResolvedTo.TabIndex = 74;
      this.lblResolvedTo.Text = "To";
      this.lblResolvedFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblResolvedFrom.Location = new System.Drawing.Point(271, 77);
      this.lblResolvedFrom.Name = "lblResolvedFrom";
      this.lblResolvedFrom.Size = new Size(48, 16);
      this.lblResolvedFrom.TabIndex = 73;
      this.lblResolvedFrom.Text = "From";
      this.chkResolved.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkResolved.Cursor = Cursors.Hand;
      this.chkResolved.FlatStyle = FlatStyle.System;
      this.chkResolved.Location = new System.Drawing.Point(274, 48);
      this.chkResolved.Name = "chkResolved";
      this.chkResolved.Size = new Size(112, 24);
      this.chkResolved.TabIndex = 75;
      this.chkResolved.Text = "Resolved Date";
      this.dtpFaultTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFaultTo.Location = new System.Drawing.Point(61, 104);
      this.dtpFaultTo.Name = "dtpFaultTo";
      this.dtpFaultTo.Size = new Size(156, 21);
      this.dtpFaultTo.TabIndex = 72;
      this.dtpFaultFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpFaultFrom.Location = new System.Drawing.Point(61, 73);
      this.dtpFaultFrom.Name = "dtpFaultFrom";
      this.dtpFaultFrom.Size = new Size(156, 21);
      this.dtpFaultFrom.TabIndex = 71;
      this.lblFaultTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblFaultTo.Location = new System.Drawing.Point(7, 109);
      this.lblFaultTo.Name = "lblFaultTo";
      this.lblFaultTo.Size = new Size(48, 16);
      this.lblFaultTo.TabIndex = 69;
      this.lblFaultTo.Text = "To";
      this.lblFaultFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblFaultFrom.Location = new System.Drawing.Point(7, 78);
      this.lblFaultFrom.Name = "lblFaultFrom";
      this.lblFaultFrom.Size = new Size(48, 16);
      this.lblFaultFrom.TabIndex = 68;
      this.lblFaultFrom.Text = "From";
      this.chkFaultDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkFaultDate.Cursor = Cursors.Hand;
      this.chkFaultDate.FlatStyle = FlatStyle.System;
      this.chkFaultDate.Location = new System.Drawing.Point(10, 48);
      this.chkFaultDate.Name = "chkFaultDate";
      this.chkFaultDate.Size = new Size(80, 24);
      this.chkFaultDate.TabIndex = 70;
      this.chkFaultDate.Text = "Fault Date";
      this.cboFaultType.Cursor = Cursors.Hand;
      this.cboFaultType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFaultType.Location = new System.Drawing.Point(108, 20);
      this.cboFaultType.Name = "cboFaultType";
      this.cboFaultType.Size = new Size(171, 21);
      this.cboFaultType.TabIndex = 32;
      this.cboFaultType.Tag = (object) "";
      this.lblFaultType.Location = new System.Drawing.Point(6, 23);
      this.lblFaultType.Name = "lblFaultType";
      this.lblFaultType.Size = new Size(96, 20);
      this.lblFaultType.TabIndex = 33;
      this.lblFaultType.Text = "Fault Type";
      this.grpFaultDG.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpFaultDG.Controls.Add((Control) this.dgFaults);
      this.grpFaultDG.FlatStyle = FlatStyle.System;
      this.grpFaultDG.Location = new System.Drawing.Point(8, 282);
      this.grpFaultDG.Name = "grpFaultDG";
      this.grpFaultDG.Size = new Size(842, 420);
      this.grpFaultDG.TabIndex = 14;
      this.grpFaultDG.TabStop = false;
      this.grpFaultDG.Text = "Faults";
      this.dgFaults.DataMember = "";
      this.dgFaults.Dock = DockStyle.Fill;
      this.dgFaults.HeaderForeColor = SystemColors.ControlText;
      this.dgFaults.Location = new System.Drawing.Point(3, 17);
      this.dgFaults.Name = "dgFaults";
      this.dgFaults.Size = new Size(836, 400);
      this.dgFaults.TabIndex = 45;
      this.grpEngineerFilter.Controls.Add((Control) this.btnfindEngineer);
      this.grpEngineerFilter.Controls.Add((Control) this.txtEngineer);
      this.grpEngineerFilter.Controls.Add((Control) this.lblEngineer);
      this.grpEngineerFilter.Controls.Add((Control) this.btnSearchEngineer);
      this.grpEngineerFilter.Controls.Add((Control) this.dtpEngineerTo);
      this.grpEngineerFilter.Controls.Add((Control) this.dtpEngineerFrom);
      this.grpEngineerFilter.Controls.Add((Control) this.lblEngineerTo);
      this.grpEngineerFilter.Controls.Add((Control) this.lblEngineerFrom);
      this.grpEngineerFilter.FlatStyle = FlatStyle.System;
      this.grpEngineerFilter.Location = new System.Drawing.Point(856, 107);
      this.grpEngineerFilter.Name = "grpEngineerFilter";
      this.grpEngineerFilter.Size = new Size(639, 169);
      this.grpEngineerFilter.TabIndex = 14;
      this.grpEngineerFilter.TabStop = false;
      this.grpEngineerFilter.Text = "Filter Engineer";
      this.btnfindEngineer.BackColor = Color.White;
      this.btnfindEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindEngineer.Location = new System.Drawing.Point(316, 18);
      this.btnfindEngineer.Name = "btnfindEngineer";
      this.btnfindEngineer.Size = new Size(32, 23);
      this.btnfindEngineer.TabIndex = 84;
      this.btnfindEngineer.Text = "...";
      this.btnfindEngineer.UseVisualStyleBackColor = false;
      this.txtEngineer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtEngineer.Location = new System.Drawing.Point(100, 20);
      this.txtEngineer.Name = "txtEngineer";
      this.txtEngineer.ReadOnly = true;
      this.txtEngineer.Size = new Size(201, 21);
      this.txtEngineer.TabIndex = 83;
      this.lblEngineer.Location = new System.Drawing.Point(6, 23);
      this.lblEngineer.Name = "lblEngineer";
      this.lblEngineer.Size = new Size(85, 20);
      this.lblEngineer.TabIndex = 85;
      this.lblEngineer.Text = "Engineer";
      this.btnSearchEngineer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnSearchEngineer.Location = new System.Drawing.Point(563, 140);
      this.btnSearchEngineer.Name = "btnSearchEngineer";
      this.btnSearchEngineer.Size = new Size(70, 23);
      this.btnSearchEngineer.TabIndex = 79;
      this.btnSearchEngineer.Text = "Run Filter";
      this.dtpEngineerTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpEngineerTo.Location = new System.Drawing.Point(66, 99);
      this.dtpEngineerTo.Name = "dtpEngineerTo";
      this.dtpEngineerTo.Size = new Size(156, 21);
      this.dtpEngineerTo.TabIndex = 82;
      this.dtpEngineerFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.dtpEngineerFrom.Location = new System.Drawing.Point(66, 63);
      this.dtpEngineerFrom.Name = "dtpEngineerFrom";
      this.dtpEngineerFrom.Size = new Size(156, 21);
      this.dtpEngineerFrom.TabIndex = 81;
      this.lblEngineerTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblEngineerTo.Location = new System.Drawing.Point(12, 104);
      this.lblEngineerTo.Name = "lblEngineerTo";
      this.lblEngineerTo.Size = new Size(48, 16);
      this.lblEngineerTo.TabIndex = 79;
      this.lblEngineerTo.Text = "To";
      this.lblEngineerFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblEngineerFrom.Location = new System.Drawing.Point(12, 68);
      this.lblEngineerFrom.Name = "lblEngineerFrom";
      this.lblEngineerFrom.Size = new Size(48, 16);
      this.lblEngineerFrom.TabIndex = 78;
      this.lblEngineerFrom.Text = "From";
      this.grpEngineerHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.grpEngineerHistory.Controls.Add((Control) this.dgEngineerHistory);
      this.grpEngineerHistory.FlatStyle = FlatStyle.System;
      this.grpEngineerHistory.Location = new System.Drawing.Point(856, 282);
      this.grpEngineerHistory.Name = "grpEngineerHistory";
      this.grpEngineerHistory.Size = new Size(639, 420);
      this.grpEngineerHistory.TabIndex = 46;
      this.grpEngineerHistory.TabStop = false;
      this.grpEngineerHistory.Text = "Engineers";
      this.dgEngineerHistory.DataMember = "";
      this.dgEngineerHistory.Dock = DockStyle.Fill;
      this.dgEngineerHistory.HeaderForeColor = SystemColors.ControlText;
      this.dgEngineerHistory.Location = new System.Drawing.Point(3, 17);
      this.dgEngineerHistory.Name = "dgEngineerHistory";
      this.dgEngineerHistory.Size = new Size(633, 400);
      this.dgEngineerHistory.TabIndex = 45;
      this.grpFilter.Controls.Add((Control) this.btnClear);
      this.grpFilter.Controls.Add((Control) this.lblRegistration);
      this.grpFilter.Controls.Add((Control) this.btnfindVan);
      this.grpFilter.Controls.Add((Control) this.txtVanReg);
      this.grpFilter.FlatStyle = FlatStyle.System;
      this.grpFilter.Location = new System.Drawing.Point(8, 38);
      this.grpFilter.Name = "grpFilter";
      this.grpFilter.Size = new Size(1484, 63);
      this.grpFilter.TabIndex = 40;
      this.grpFilter.TabStop = false;
      this.grpFilter.Text = "Filter";
      this.lblRegistration.AutoSize = true;
      this.lblRegistration.Location = new System.Drawing.Point(6, 22);
      this.lblRegistration.Name = "lblRegistration";
      this.lblRegistration.Size = new Size(80, 13);
      this.lblRegistration.TabIndex = 42;
      this.lblRegistration.Text = "Registration:";
      this.btnfindVan.BackColor = Color.White;
      this.btnfindVan.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnfindVan.Location = new System.Drawing.Point(324, 17);
      this.btnfindVan.Name = "btnfindVan";
      this.btnfindVan.Size = new Size(32, 23);
      this.btnfindVan.TabIndex = 41;
      this.btnfindVan.Text = "...";
      this.btnfindVan.UseVisualStyleBackColor = false;
      this.txtVanReg.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtVanReg.Location = new System.Drawing.Point(108, 19);
      this.txtVanReg.Name = "txtVanReg";
      this.txtVanReg.ReadOnly = true;
      this.txtVanReg.Size = new Size(201, 21);
      this.txtVanReg.TabIndex = 40;
      this.btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnClear.Location = new System.Drawing.Point(1408, 17);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new Size(70, 23);
      this.btnClear.TabIndex = 79;
      this.btnClear.Text = "Clear";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1502, 714);
      this.Controls.Add((Control) this.grpFilter);
      this.Controls.Add((Control) this.grpEngineerHistory);
      this.Controls.Add((Control) this.grpEngineerFilter);
      this.Controls.Add((Control) this.grpFaultDG);
      this.Controls.Add((Control) this.grpFaultsFilter);
      this.Name = nameof (FRMFleetVanManager);
      this.Text = "Fleet Van Mileage Import";
      this.WindowState = FormWindowState.Maximized;
      this.Controls.SetChildIndex((Control) this.grpFaultsFilter, 0);
      this.Controls.SetChildIndex((Control) this.grpFaultDG, 0);
      this.Controls.SetChildIndex((Control) this.grpEngineerFilter, 0);
      this.Controls.SetChildIndex((Control) this.grpEngineerHistory, 0);
      this.Controls.SetChildIndex((Control) this.grpFilter, 0);
      this.grpFaultsFilter.ResumeLayout(false);
      this.grpFaultDG.ResumeLayout(false);
      this.dgFaults.EndInit();
      this.grpEngineerFilter.ResumeLayout(false);
      this.grpEngineerFilter.PerformLayout();
      this.grpEngineerHistory.ResumeLayout(false);
      this.dgEngineerHistory.EndInit();
      this.grpFilter.ResumeLayout(false);
      this.grpFilter.PerformLayout();
      this.ResumeLayout(false);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public FleetVan CurrentVan
    {
      get
      {
        return this._currentVan;
      }
      set
      {
        this._currentVan = value;
        if (this.CurrentVan == null)
        {
          this.CurrentVan = new FleetVan();
          this.CurrentVan.Exists = false;
          this.txtVanReg.Text = "";
        }
        else
          this.txtVanReg.Text = this.CurrentVan.Registration;
      }
    }

    public Engineer Engineer
    {
      get
      {
        return this._engineer;
      }
      set
      {
        this._engineer = value;
        if (this.Engineer == null)
        {
          this.Engineer = new Engineer();
          this.CurrentVan.Exists = false;
          this.txtEngineer.Text = "";
        }
        else
          this.txtEngineer.Text = this.Engineer.Name;
      }
    }

    public DataView FaultsDataView
    {
      get
      {
        return this._dvFaults;
      }
      set
      {
        this._dvFaults = value;
        if (this.FaultsDataView != null)
        {
          this._dvFaults.Table.TableName = Enums.TableNames.tblFleetVanMaintenance.ToString();
          this._dvFaults.AllowNew = false;
          this._dvFaults.AllowEdit = false;
          this._dvFaults.AllowDelete = false;
        }
        this.dgFaults.DataSource = (object) this.FaultsDataView;
      }
    }

    private DataRow SelectedFaultDataRow
    {
      get
      {
        return this.dgFaults.CurrentRowIndex != -1 ? this.FaultsDataView[this.dgFaults.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    private DataView EngineerHistoryDataview
    {
      get
      {
        return this._dvEngineerHistory;
      }
      set
      {
        this._dvEngineerHistory = value;
        if (this.EngineerHistoryDataview != null)
        {
          this._dvEngineerHistory.AllowNew = false;
          this._dvEngineerHistory.AllowEdit = false;
          this._dvEngineerHistory.AllowDelete = false;
          this._dvEngineerHistory.Table.TableName = Enums.TableNames.tblFleetVanEngineer.ToString();
        }
        this.dgEngineerHistory.DataSource = (object) this.EngineerHistoryDataview;
      }
    }

    private DataRow SelectedEngineerDataRow
    {
      get
      {
        return this.dgEngineerHistory.CurrentRowIndex != -1 ? this.EngineerHistoryDataview[this.dgEngineerHistory.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public void SetupDGFault()
    {
      Helper.SetUpDataGrid(this.dgFaults, false);
      DataGridTableStyle tableStyle = this.dgFaults.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Registration";
      dataGridLabelColumn1.MappingName = "Registration";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Fault";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Fault Date";
      dataGridLabelColumn3.MappingName = "FaultDate";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 105;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "dd/MM/yyyy";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Resolved Date";
      dataGridLabelColumn4.MappingName = "ResolvedDate";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 105;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "dd/MM/yyyy";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Engineer Notes";
      dataGridLabelColumn5.MappingName = "EngineerNotes";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 200;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "dd/MM/yyyy";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Last Changed";
      dataGridLabelColumn6.MappingName = "LastChanged";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 105;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblFleetVanMaintenance.ToString();
      this.dgFaults.TableStyles.Add(tableStyle);
    }

    public void SetupDGEngineerHistory()
    {
      Helper.SetUpDataGrid(this.dgEngineerHistory, false);
      DataGridTableStyle tableStyle = this.dgEngineerHistory.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Registration";
      dataGridLabelColumn1.MappingName = "Registration";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 130;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Name";
      dataGridLabelColumn2.MappingName = "Name";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 130;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "dd/MM/yyyy";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "From";
      dataGridLabelColumn3.MappingName = "StartDateTime";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 150;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "dd/MM/yyyy";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "To";
      dataGridLabelColumn4.MappingName = "EndDateTime";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 150;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblFleetVanEngineer.ToString();
      this.dgEngineerHistory.TableStyles.Add(tableStyle);
    }

    private void FRMImport_Load(object sender, EventArgs e)
    {
      this.SetupDGFault();
      this.SetupDGEngineerHistory();
    }

    private void btnfindVan_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblFleetVan, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.CurrentVan = App.DB.FleetVan.Get(integer);
    }

    private void btnfindEngineer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblEngineer, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Engineer = App.DB.Engineer.Engineer_Get(integer);
    }

    private void btnSearchFault_Click(object sender, EventArgs e)
    {
      this.PopulateFaultsDatagrid();
    }

    private void btnSearchEngineer_Click(object sender, EventArgs e)
    {
      this.PopulateEngineerDatagrid();
    }

    private void dgFaults_DoubleClick(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblFleetVan, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      FleetVan fleetVan = App.DB.FleetVan.Get(integer);
      if (fleetVan != null && App.ShowMessage("Move fault? The fault will now be assigned to: " + fleetVan.Registration + ", Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        FleetVanFault oVan = App.DB.FleetVanFault.Get(Conversions.ToInteger(this.SelectedFaultDataRow["VanFaultID"]));
        oVan.SetVanID = (object) fleetVan.VanID;
        App.DB.FleetVanFault.Update(oVan);
        int num = (int) App.ShowMessage("Fault has been moved to " + fleetVan.Registration, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      this.FaultsDataView = (DataView) null;
      this.EngineerHistoryDataview = (DataView) null;
      this.CurrentVan = (FleetVan) null;
      this.Engineer = (Engineer) null;
    }

    public void PopulateFaultsDatagrid()
    {
      try
      {
        string str = "(1 = 1";
        if (this.CurrentVan != null)
          str += " AND tblFleetVan.VanID = " + Conversions.ToString(this.CurrentVan.VanID);
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboFaultType)) != 0.0)
          str += " AND tblFleetVanFault.FaultType = " + Combo.get_GetSelectedItemValue(this.cboFaultType);
        if (this.chkFaultDate.Checked)
          str = str + " AND tblFleetVanFault.FaultDate >= '" + Strings.Format((object) this.dtpFaultFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblFleetVanFault.FaultDate <= '" + Strings.Format((object) this.dtpFaultTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
        if (this.chkResolved.Checked)
          str = str + " AND tblFleetVanFault.ResolvedDate >= '" + Strings.Format((object) this.dtpResolvedFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblFleetVanFault.ResolvedDate <= '" + Strings.Format((object) this.dtpResolvedTo.Value, "dd-MMM-yyyy 23:59:59") + "'";
        string where = str + ")";
        this.FaultsDataView = App.DB.FleetVanFault.GetAll_Trans(where);
        this.grpFaultDG.Text = "Double Click To Move Fault (" + Conversions.ToString(this.FaultsDataView.Count) + ")";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    public void PopulateEngineerDatagrid()
    {
      try
      {
        string str = "(1 = 1";
        if (this.CurrentVan != null)
          str += " AND tblFleetVan.VanID = " + Conversions.ToString(this.CurrentVan.VanID);
        if (this.Engineer != null)
          str += " AND tblFleetVanEngineer.EngineerID = " + Conversions.ToString(this.Engineer.EngineerID);
        string where = str + " AND tblFleetVanEngineer.StartDateTime >= '" + Strings.Format((object) this.dtpEngineerFrom.Value, "dd-MMM-yyyy 00:00:00") + "' And tblFleetVanEngineer.StartDateTime <= '" + Strings.Format((object) this.dtpEngineerTo.Value, "dd-MMM-yyyy 23:59:59") + "' AND ((tblFleetVanEngineer.EndDateTime >= '" + Strings.Format((object) this.dtpEngineerFrom.Value, "dd-MMM-yyyy 00:00:00") + "' AND tblFleetVanEngineer.EndDateTime <= '" + Strings.Format((object) this.dtpEngineerTo.Value, "dd-MMM-yyyy 23:59:59") + "')Or tblFleetVanEngineer.EndDateTime Is NULL)" + ")";
        this.EngineerHistoryDataview = App.DB.FleetVanEngineer.GetAll_Trans(where);
        this.grpEngineerHistory.Text = "Vehicles (" + Conversions.ToString(this.EngineerHistoryDataview.Count) + ")";
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }
  }
}
