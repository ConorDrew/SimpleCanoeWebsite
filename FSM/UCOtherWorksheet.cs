// Decompiled with JetBrains decompiler
// Type: FSM.UCOtherWorksheet
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Assets;
using FSM.Entity.EngineerVisitAssetWorkSheets;
using FSM.Entity.EngineerVisits;
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
  public class UCOtherWorksheet : UCBase, IUserControl
  {
    private IContainer components;
    private DataTable DtPassFailNa;
    private DataTable DtNotTestedPassFail;
    private DataTable DtApplianceServiced;
    private DataTable DtYesNo;
    private DataTable DtPassFail;
    private DataTable DtYesNoNa;
    private DataTable DtYesNoNATab;
    private EngineerVisitAssetWorkSheet _Worksheet;
    private EngineerVisit _EngineerVisit;
    private int _jobID;

    public UCOtherWorksheet(
      EngineerVisitAssetWorkSheet worksheet,
      int jobID,
      EngineerVisit EngineerVisit)
    {
      this.DtPassFailNa = (DataTable) null;
      this.DtNotTestedPassFail = (DataTable) null;
      this.DtApplianceServiced = (DataTable) null;
      this.DtYesNo = (DataTable) null;
      this.DtPassFail = (DataTable) null;
      this.DtYesNoNa = (DataTable) null;
      this.DtYesNoNATab = (DataTable) null;
      this.InitializeComponent();
      this.DtPassFailNa = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA, false).Table;
      this.DtNotTestedPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.NotTestedPassFailNA, false).Table;
      this.DtApplianceServiced = App.DB.Picklists.GetAll(Enums.PickListTypes.ApplianceServiced, false).Table;
      this.DtYesNoNa = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table;
      this.DtYesNoNATab = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNATab, false).Table;
      this.DtYesNo = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table;
      this.DtPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFail, false).Table;
      this._Worksheet = worksheet;
      this._jobID = jobID;
      this._EngineerVisit = EngineerVisit;
      this.SetUpCombos();
      this.Populate(0);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual ComboBox cboSafety { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboServiced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSafetyDeviceOperation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVentilation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboStability { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSafetyDevices { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboOperation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLeaksPressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTested
    {
      get
      {
        return this._cboTested;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboTested_SelectionChangeCommitted);
        ComboBox cboTested1 = this._cboTested;
        if (cboTested1 != null)
          cboTested1.SelectionChangeCommitted -= eventHandler;
        this._cboTested = value;
        ComboBox cboTested2 = this._cboTested;
        if (cboTested2 == null)
          return;
        cboTested2.SelectionChangeCommitted += eventHandler;
      }
    }

    internal virtual ComboBox cboLLAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label46 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label47 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label55 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label56 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label57 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label58 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label59 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label60 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label61 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label62 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label63 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label64 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label65 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label66 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDischarge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCondition { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSweep { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.cboSafety = new ComboBox();
      this.cboServiced = new ComboBox();
      this.cboSafetyDeviceOperation = new ComboBox();
      this.cboVentilation = new ComboBox();
      this.cboStability = new ComboBox();
      this.cboSafetyDevices = new ComboBox();
      this.cboOperation = new ComboBox();
      this.cboLeaksPressure = new ComboBox();
      this.cboTested = new ComboBox();
      this.cboLLAppliance = new ComboBox();
      this.cboAppliance = new ComboBox();
      this.Label46 = new Label();
      this.Label47 = new Label();
      this.Label55 = new Label();
      this.Label56 = new Label();
      this.Label57 = new Label();
      this.Label58 = new Label();
      this.Label59 = new Label();
      this.Label60 = new Label();
      this.Label61 = new Label();
      this.Label62 = new Label();
      this.Label63 = new Label();
      this.Label64 = new Label();
      this.Label65 = new Label();
      this.Label66 = new Label();
      this.cboDischarge = new ComboBox();
      this.cboCondition = new ComboBox();
      this.cboSweep = new ComboBox();
      this.lblNotTested10 = new Label();
      this.lblNotTested9 = new Label();
      this.lblNotTested8 = new Label();
      this.lblNotTested7 = new Label();
      this.lblNotTested6 = new Label();
      this.lblNotTested5 = new Label();
      this.lblNotTested4 = new Label();
      this.lblNotTested3 = new Label();
      this.lblNotTested2 = new Label();
      this.lblNotTested1 = new Label();
      this.SuspendLayout();
      this.cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSafety.Location = new System.Drawing.Point(601, 399);
      this.cboSafety.Name = "cboSafety";
      this.cboSafety.Size = new Size(188, 21);
      this.cboSafety.TabIndex = 14;
      this.cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboServiced.Location = new System.Drawing.Point(601, 369);
      this.cboServiced.Name = "cboServiced";
      this.cboServiced.Size = new Size(188, 21);
      this.cboServiced.TabIndex = 13;
      this.cboSafetyDeviceOperation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSafetyDeviceOperation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSafetyDeviceOperation.Location = new System.Drawing.Point(601, 248);
      this.cboSafetyDeviceOperation.Name = "cboSafetyDeviceOperation";
      this.cboSafetyDeviceOperation.Size = new Size(188, 21);
      this.cboSafetyDeviceOperation.TabIndex = 9;
      this.cboVentilation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboVentilation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVentilation.Location = new System.Drawing.Point(601, 218);
      this.cboVentilation.Name = "cboVentilation";
      this.cboVentilation.Size = new Size(188, 21);
      this.cboVentilation.TabIndex = 8;
      this.cboStability.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboStability.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboStability.Location = new System.Drawing.Point(601, 189);
      this.cboStability.Name = "cboStability";
      this.cboStability.Size = new Size(188, 21);
      this.cboStability.TabIndex = 7;
      this.cboSafetyDevices.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSafetyDevices.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSafetyDevices.Location = new System.Drawing.Point(601, 159);
      this.cboSafetyDevices.Name = "cboSafetyDevices";
      this.cboSafetyDevices.Size = new Size(188, 21);
      this.cboSafetyDevices.TabIndex = 6;
      this.cboOperation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboOperation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboOperation.Location = new System.Drawing.Point(601, 129);
      this.cboOperation.Name = "cboOperation";
      this.cboOperation.Size = new Size(188, 21);
      this.cboOperation.TabIndex = 5;
      this.cboLeaksPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboLeaksPressure.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLeaksPressure.Location = new System.Drawing.Point(601, 99);
      this.cboLeaksPressure.Name = "cboLeaksPressure";
      this.cboLeaksPressure.Size = new Size(188, 21);
      this.cboLeaksPressure.TabIndex = 4;
      this.cboTested.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboTested.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTested.Location = new System.Drawing.Point(601, 69);
      this.cboTested.Name = "cboTested";
      this.cboTested.Size = new Size(188, 21);
      this.cboTested.TabIndex = 3;
      this.cboLLAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboLLAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLLAppliance.Location = new System.Drawing.Point(601, 40);
      this.cboLLAppliance.Name = "cboLLAppliance";
      this.cboLLAppliance.Size = new Size(188, 21);
      this.cboLLAppliance.TabIndex = 2;
      this.cboAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAppliance.Location = new System.Drawing.Point(601, 10);
      this.cboAppliance.Name = "cboAppliance";
      this.cboAppliance.Size = new Size(188, 21);
      this.cboAppliance.TabIndex = 1;
      this.Label46.AutoSize = true;
      this.Label46.Location = new System.Drawing.Point(3, 402);
      this.Label46.Name = "Label46";
      this.Label46.Size = new Size(101, 13);
      this.Label46.TabIndex = 348;
      this.Label46.Text = "Appliance safety";
      this.Label47.AutoSize = true;
      this.Label47.Location = new System.Drawing.Point(3, 372);
      this.Label47.Name = "Label47";
      this.Label47.Size = new Size(181, 13);
      this.Label47.TabIndex = 347;
      this.Label47.Text = "Appliance service or inspected";
      this.Label55.AutoSize = true;
      this.Label55.Location = new System.Drawing.Point(3, 342);
      this.Label55.Name = "Label55";
      this.Label55.Size = new Size(64, 13);
      this.Label55.TabIndex = 346;
      this.Label55.Text = "Discharge";
      this.Label56.AutoSize = true;
      this.Label56.Location = new System.Drawing.Point(3, 312);
      this.Label56.Name = "Label56";
      this.Label56.Size = new Size(106, 13);
      this.Label56.TabIndex = 345;
      this.Label56.Text = "Overall Condition";
      this.Label57.AutoSize = true;
      this.Label57.Location = new System.Drawing.Point(3, 281);
      this.Label57.Name = "Label57";
      this.Label57.Size = new Size(98, 13);
      this.Label57.TabIndex = 344;
      this.Label57.Text = "Sweep outcome";
      this.Label58.AutoSize = true;
      this.Label58.Location = new System.Drawing.Point(3, 251);
      this.Label58.Name = "Label58";
      this.Label58.Size = new Size(143, 13);
      this.Label58.TabIndex = 343;
      this.Label58.Text = "Safety device operation";
      this.Label59.AutoSize = true;
      this.Label59.Location = new System.Drawing.Point(3, 221);
      this.Label59.Name = "Label59";
      this.Label59.Size = new Size(66, 13);
      this.Label59.TabIndex = 342;
      this.Label59.Text = "Ventilation";
      this.Label60.AutoSize = true;
      this.Label60.Location = new System.Drawing.Point(3, 192);
      this.Label60.Name = "Label60";
      this.Label60.Size = new Size(53, 13);
      this.Label60.TabIndex = 341;
      this.Label60.Text = "Stability";
      this.Label61.AutoSize = true;
      this.Label61.Location = new System.Drawing.Point(3, 162);
      this.Label61.Name = "Label61";
      this.Label61.Size = new Size(91, 13);
      this.Label61.TabIndex = 340;
      this.Label61.Text = "Safety devices";
      this.Label62.AutoSize = true;
      this.Label62.Location = new System.Drawing.Point(3, 132);
      this.Label62.Name = "Label62";
      this.Label62.Size = new Size(63, 13);
      this.Label62.TabIndex = 339;
      this.Label62.Text = "Operation";
      this.Label63.AutoSize = true;
      this.Label63.Location = new System.Drawing.Point(3, 102);
      this.Label63.Name = "Label63";
      this.Label63.Size = new Size(103, 13);
      this.Label63.TabIndex = 338;
      this.Label63.Text = "Leaks / pressure";
      this.Label64.AutoSize = true;
      this.Label64.Location = new System.Drawing.Point(3, 72);
      this.Label64.Name = "Label64";
      this.Label64.Size = new Size(101, 13);
      this.Label64.TabIndex = 337;
      this.Label64.Text = "Appliance tested";
      this.Label65.AutoSize = true;
      this.Label65.Location = new System.Drawing.Point(3, 43);
      this.Label65.Name = "Label65";
      this.Label65.Size = new Size(125, 13);
      this.Label65.TabIndex = 336;
      this.Label65.Text = "Landlords Appliance ";
      this.Label66.AutoSize = true;
      this.Label66.Location = new System.Drawing.Point(3, 13);
      this.Label66.Name = "Label66";
      this.Label66.Size = new Size(62, 13);
      this.Label66.TabIndex = 335;
      this.Label66.Text = "Appliance";
      this.cboDischarge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboDischarge.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDischarge.Location = new System.Drawing.Point(601, 337);
      this.cboDischarge.Name = "cboDischarge";
      this.cboDischarge.Size = new Size(188, 21);
      this.cboDischarge.TabIndex = 12;
      this.cboCondition.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboCondition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCondition.Location = new System.Drawing.Point(601, 307);
      this.cboCondition.Name = "cboCondition";
      this.cboCondition.Size = new Size(188, 21);
      this.cboCondition.TabIndex = 11;
      this.cboSweep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSweep.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSweep.Location = new System.Drawing.Point(601, 278);
      this.cboSweep.Name = "cboSweep";
      this.cboSweep.Size = new Size(188, 21);
      this.cboSweep.TabIndex = 10;
      this.lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested10.AutoSize = true;
      this.lblNotTested10.Location = new System.Drawing.Point(660, 371);
      this.lblNotTested10.Name = "lblNotTested10";
      this.lblNotTested10.Size = new Size(67, 13);
      this.lblNotTested10.TabIndex = 406;
      this.lblNotTested10.Text = "Not Tested";
      this.lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested9.AutoSize = true;
      this.lblNotTested9.Location = new System.Drawing.Point(660, 341);
      this.lblNotTested9.Name = "lblNotTested9";
      this.lblNotTested9.Size = new Size(67, 13);
      this.lblNotTested9.TabIndex = 405;
      this.lblNotTested9.Text = "Not Tested";
      this.lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested8.AutoSize = true;
      this.lblNotTested8.Location = new System.Drawing.Point(660, 311);
      this.lblNotTested8.Name = "lblNotTested8";
      this.lblNotTested8.Size = new Size(67, 13);
      this.lblNotTested8.TabIndex = 404;
      this.lblNotTested8.Text = "Not Tested";
      this.lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested7.AutoSize = true;
      this.lblNotTested7.Location = new System.Drawing.Point(660, 281);
      this.lblNotTested7.Name = "lblNotTested7";
      this.lblNotTested7.Size = new Size(67, 13);
      this.lblNotTested7.TabIndex = 403;
      this.lblNotTested7.Text = "Not Tested";
      this.lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested6.AutoSize = true;
      this.lblNotTested6.Location = new System.Drawing.Point(660, 252);
      this.lblNotTested6.Name = "lblNotTested6";
      this.lblNotTested6.Size = new Size(67, 13);
      this.lblNotTested6.TabIndex = 402;
      this.lblNotTested6.Text = "Not Tested";
      this.lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested5.AutoSize = true;
      this.lblNotTested5.Location = new System.Drawing.Point(660, 222);
      this.lblNotTested5.Name = "lblNotTested5";
      this.lblNotTested5.Size = new Size(67, 13);
      this.lblNotTested5.TabIndex = 401;
      this.lblNotTested5.Text = "Not Tested";
      this.lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested4.AutoSize = true;
      this.lblNotTested4.Location = new System.Drawing.Point(660, 192);
      this.lblNotTested4.Name = "lblNotTested4";
      this.lblNotTested4.Size = new Size(67, 13);
      this.lblNotTested4.TabIndex = 400;
      this.lblNotTested4.Text = "Not Tested";
      this.lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested3.AutoSize = true;
      this.lblNotTested3.Location = new System.Drawing.Point(660, 162);
      this.lblNotTested3.Name = "lblNotTested3";
      this.lblNotTested3.Size = new Size(67, 13);
      this.lblNotTested3.TabIndex = 399;
      this.lblNotTested3.Text = "Not Tested";
      this.lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested2.AutoSize = true;
      this.lblNotTested2.Location = new System.Drawing.Point(660, 132);
      this.lblNotTested2.Name = "lblNotTested2";
      this.lblNotTested2.Size = new Size(67, 13);
      this.lblNotTested2.TabIndex = 398;
      this.lblNotTested2.Text = "Not Tested";
      this.lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested1.AutoSize = true;
      this.lblNotTested1.Location = new System.Drawing.Point(660, 102);
      this.lblNotTested1.Name = "lblNotTested1";
      this.lblNotTested1.Size = new Size(67, 13);
      this.lblNotTested1.TabIndex = 397;
      this.lblNotTested1.Text = "Not Tested";
      this.Controls.Add((Control) this.cboDischarge);
      this.Controls.Add((Control) this.cboCondition);
      this.Controls.Add((Control) this.cboSweep);
      this.Controls.Add((Control) this.Label46);
      this.Controls.Add((Control) this.Label47);
      this.Controls.Add((Control) this.Label55);
      this.Controls.Add((Control) this.Label56);
      this.Controls.Add((Control) this.Label57);
      this.Controls.Add((Control) this.Label58);
      this.Controls.Add((Control) this.Label59);
      this.Controls.Add((Control) this.Label60);
      this.Controls.Add((Control) this.Label61);
      this.Controls.Add((Control) this.Label62);
      this.Controls.Add((Control) this.Label63);
      this.Controls.Add((Control) this.Label64);
      this.Controls.Add((Control) this.Label65);
      this.Controls.Add((Control) this.Label66);
      this.Controls.Add((Control) this.cboSafety);
      this.Controls.Add((Control) this.cboServiced);
      this.Controls.Add((Control) this.cboSafetyDeviceOperation);
      this.Controls.Add((Control) this.cboVentilation);
      this.Controls.Add((Control) this.cboStability);
      this.Controls.Add((Control) this.cboSafetyDevices);
      this.Controls.Add((Control) this.cboOperation);
      this.Controls.Add((Control) this.cboLeaksPressure);
      this.Controls.Add((Control) this.cboTested);
      this.Controls.Add((Control) this.cboLLAppliance);
      this.Controls.Add((Control) this.cboAppliance);
      this.Controls.Add((Control) this.lblNotTested10);
      this.Controls.Add((Control) this.lblNotTested9);
      this.Controls.Add((Control) this.lblNotTested8);
      this.Controls.Add((Control) this.lblNotTested7);
      this.Controls.Add((Control) this.lblNotTested6);
      this.Controls.Add((Control) this.lblNotTested5);
      this.Controls.Add((Control) this.lblNotTested4);
      this.Controls.Add((Control) this.lblNotTested3);
      this.Controls.Add((Control) this.lblNotTested2);
      this.Controls.Add((Control) this.lblNotTested1);
      this.Name = nameof (UCOtherWorksheet);
      this.Size = new Size(789, 433);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public EngineerVisitAssetWorkSheet Worksheet
    {
      get
      {
        return this._Worksheet;
      }
      set
      {
        this._Worksheet = value;
      }
    }

    public EngineerVisit EngineerVisit
    {
      get
      {
        return this._EngineerVisit;
      }
      set
      {
        this._EngineerVisit = value;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public int JobID
    {
      get
      {
        return this._jobID;
      }
      set
      {
        this._jobID = value;
      }
    }

    public object LoadedItem
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public void LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public void SetUpCombos()
    {
      ComboBox cboLlAppliance = this.cboLLAppliance;
      Combo.SetUpCombo(ref cboLlAppliance, App.DB.Picklists.GetAll(Enums.PickListTypes.LLTenPriv, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboLLAppliance = cboLlAppliance;
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetUpCombo(ref cboAppliance, App.DB.JobAsset.JobAsset_Get_For_Job(this.JobID).Table, "AssetID", "AssetDescriptionWithLocation", Enums.ComboValues.Please_Select);
      this.cboAppliance = cboAppliance;
      ComboBox cboTested = this.cboTested;
      Combo.SetUpCombo(ref cboTested, this.DtYesNoNATab, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTested = cboTested;
      ComboBox cboLeaksPressure = this.cboLeaksPressure;
      Combo.SetUpCombo(ref cboLeaksPressure, this.DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboLeaksPressure = cboLeaksPressure;
      ComboBox cboOperation = this.cboOperation;
      Combo.SetUpCombo(ref cboOperation, this.DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboOperation = cboOperation;
      ComboBox cboSafetyDevices = this.cboSafetyDevices;
      Combo.SetUpCombo(ref cboSafetyDevices, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSafetyDevices = cboSafetyDevices;
      ComboBox cboStability = this.cboStability;
      Combo.SetUpCombo(ref cboStability, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboStability = cboStability;
      ComboBox cboVentilation = this.cboVentilation;
      Combo.SetUpCombo(ref cboVentilation, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboVentilation = cboVentilation;
      ComboBox safetyDeviceOperation = this.cboSafetyDeviceOperation;
      Combo.SetUpCombo(ref safetyDeviceOperation, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSafetyDeviceOperation = safetyDeviceOperation;
      ComboBox cboServiced = this.cboServiced;
      Combo.SetUpCombo(ref cboServiced, this.DtApplianceServiced, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboServiced = cboServiced;
      ComboBox cboSafety = this.cboSafety;
      Combo.SetUpCombo(ref cboSafety, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSafety = cboSafety;
      this.cboSafety.Items.Add((object) new Combo("Visually Passed", "999999999", (object) null));
      ComboBox cboDischarge = this.cboDischarge;
      Combo.SetUpCombo(ref cboDischarge, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboDischarge = cboDischarge;
      ComboBox cboSweep = this.cboSweep;
      Combo.SetUpCombo(ref cboSweep, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSweep = cboSweep;
      ComboBox cboCondition = this.cboCondition;
      Combo.SetUpCombo(ref cboCondition, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCondition = cboCondition;
    }

    public void Populate(int ID = 0)
    {
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboAppliance, Conversions.ToString(this.Worksheet.AssetID));
      this.cboAppliance = cboAppliance;
      ComboBox cboLlAppliance = this.cboLLAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboLlAppliance, Conversions.ToString(this.Worksheet.LandlordsApplianceID));
      this.cboLLAppliance = cboLlAppliance;
      ComboBox cboTested = this.cboTested;
      Combo.SetSelectedComboItem_By_Value(ref cboTested, Conversions.ToString(this.Worksheet.ApplianceTestedID));
      this.cboTested = cboTested;
      ComboBox cboLeaksPressure = this.cboLeaksPressure;
      Combo.SetSelectedComboItem_By_Value(ref cboLeaksPressure, Conversions.ToString(this.Worksheet.FlueFlowTestID));
      this.cboLeaksPressure = cboLeaksPressure;
      ComboBox cboOperation = this.cboOperation;
      Combo.SetSelectedComboItem_By_Value(ref cboOperation, Conversions.ToString(this.Worksheet.SpillageTestID));
      this.cboOperation = cboOperation;
      ComboBox cboSafetyDevices = this.cboSafetyDevices;
      Combo.SetSelectedComboItem_By_Value(ref cboSafetyDevices, Conversions.ToString(this.Worksheet.FlueTerminationSatisfactoryID));
      this.cboSafetyDevices = cboSafetyDevices;
      ComboBox cboStability = this.cboStability;
      Combo.SetSelectedComboItem_By_Value(ref cboStability, Conversions.ToString(this.Worksheet.VisualConditionOfFlueSatisfactoryID));
      this.cboStability = cboStability;
      ComboBox cboVentilation = this.cboVentilation;
      Combo.SetSelectedComboItem_By_Value(ref cboVentilation, Conversions.ToString(this.Worksheet.VentilationProvisionSatisfactoryID));
      this.cboVentilation = cboVentilation;
      ComboBox safetyDeviceOperation = this.cboSafetyDeviceOperation;
      Combo.SetSelectedComboItem_By_Value(ref safetyDeviceOperation, Conversions.ToString(this.Worksheet.SafetyDeviceOperationID));
      this.cboSafetyDeviceOperation = safetyDeviceOperation;
      ComboBox cboSweep = this.cboSweep;
      Combo.SetSelectedComboItem_By_Value(ref cboSweep, Conversions.ToString(this.Worksheet.SweepOutcomeID));
      this.cboSweep = cboSweep;
      ComboBox cboCondition = this.cboCondition;
      Combo.SetSelectedComboItem_By_Value(ref cboCondition, Conversions.ToString(this.Worksheet.OverallID));
      this.cboCondition = cboCondition;
      ComboBox cboDischarge = this.cboDischarge;
      Combo.SetSelectedComboItem_By_Value(ref cboDischarge, Conversions.ToString(this.Worksheet.DischargeID));
      this.cboDischarge = cboDischarge;
      ComboBox cboServiced = this.cboServiced;
      Combo.SetSelectedComboItem_By_Value(ref cboServiced, Conversions.ToString(this.Worksheet.ApplianceServiceOrInspectedID));
      this.cboServiced = cboServiced;
      ComboBox cboSafety = this.cboSafety;
      Combo.SetSelectedComboItem_By_Value(ref cboSafety, Conversions.ToString(this.Worksheet.ApplianceSafeID));
      this.cboSafety = cboSafety;
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboTested), "No", false) > 0U)
        return;
      this.NotTested();
    }

    private void NotTested()
    {
      this.cboLeaksPressure.Visible = false;
      this.cboOperation.Visible = false;
      this.cboSafetyDevices.Visible = false;
      this.cboStability.Visible = false;
      this.cboVentilation.Visible = false;
      this.cboSafetyDeviceOperation.Visible = false;
      this.cboServiced.Visible = false;
      this.cboSweep.Visible = false;
      this.cboCondition.Visible = false;
      this.cboDischarge.Visible = false;
    }

    private void Tested()
    {
      this.cboLeaksPressure.Visible = true;
      this.cboOperation.Visible = true;
      this.cboSafetyDevices.Visible = true;
      this.cboStability.Visible = true;
      this.cboVentilation.Visible = true;
      this.cboSafetyDeviceOperation.Visible = true;
      this.cboServiced.Visible = true;
      this.cboSweep.Visible = true;
      this.cboCondition.Visible = true;
      this.cboDischarge.Visible = true;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.Worksheet.SetReading = (object) 7;
        this.Worksheet.SetAssetID = (object) Combo.get_GetSelectedItemValue(this.cboAppliance);
        this.Worksheet.SetLandlordsApplianceID = (object) Combo.get_GetSelectedItemValue(this.cboLLAppliance);
        this.Worksheet.SetApplianceTestedID = (object) Combo.get_GetSelectedItemValue(this.cboTested);
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboTested), "No", false) > 0U)
        {
          this.Worksheet.SetFlueFlowTestID = (object) Combo.get_GetSelectedItemValue(this.cboLeaksPressure);
          this.Worksheet.SetSpillageTestID = (object) Combo.get_GetSelectedItemValue(this.cboOperation);
          this.Worksheet.SetFlueTerminationSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboSafetyDevices);
          this.Worksheet.SetVisualConditionOfFlueSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboStability);
          this.Worksheet.SetVentilationProvisionSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboVentilation);
          this.Worksheet.SetSafetyDeviceOperationID = (object) Combo.get_GetSelectedItemValue(this.cboSafetyDeviceOperation);
          this.Worksheet.SetSweepOutcomeID = (object) Combo.get_GetSelectedItemValue(this.cboSweep);
          this.Worksheet.SetOverallID = (object) Combo.get_GetSelectedItemValue(this.cboCondition);
          this.Worksheet.SetDischargeID = (object) Combo.get_GetSelectedItemValue(this.cboDischarge);
          this.Worksheet.SetApplianceServiceOrInspectedID = (object) Combo.get_GetSelectedItemValue(this.cboServiced);
        }
        this.Worksheet.SetApplianceSafeID = (object) Combo.get_GetSelectedItemValue(this.cboSafety);
        this.Worksheet.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        new EngineerVisitAssetWorkSheetValidatorOther().Validate(this.Worksheet, Combo.get_GetSelectedItemDescription(this.cboTested));
        EngineerVisitAssetWorkSheet worksheet = this.Worksheet;
        if (worksheet != null && worksheet.EngineerVisitAssetWorkSheetID > 0)
          App.DB.EngineerVisitAssetWorkSheet.Update(this.Worksheet);
        else
          App.DB.EngineerVisitAssetWorkSheet.Insert(this.Worksheet);
        if (this.Worksheet.LandlordsApplianceID == 391)
        {
          Asset oAsset = App.DB.Asset.Asset_Get(this.Worksheet.AssetID);
          oAsset.SetTenantsAppliance = (object) true;
          App.DB.Asset.Update(oAsset);
        }
        else
        {
          Asset oAsset = App.DB.Asset.Asset_Get(this.Worksheet.AssetID);
          oAsset.SetTenantsAppliance = (object) false;
          App.DB.Asset.Update(oAsset);
        }
        int num = (int) App.ShowMessage("Your worksheet has been saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        flag = true;
        goto label_14;
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
        int num = (int) App.ShowMessage("Error saving details : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
label_14:
      return flag;
    }

    private void cboTested_SelectionChangeCommitted(object sender, EventArgs e)
    {
      EngineerVisitAssetWorkSheet worksheet = this.Worksheet;
      this.Worksheet = new EngineerVisitAssetWorkSheet();
      if (worksheet != null && worksheet.EngineerVisitAssetWorkSheetID > 0)
        this.Worksheet.SetEngineerVisitAssetWorkSheetID = (object) worksheet.EngineerVisitAssetWorkSheetID;
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboTested), "No", false) > 0U)
        this.Tested();
      else
        this.NotTested();
    }
  }
}
