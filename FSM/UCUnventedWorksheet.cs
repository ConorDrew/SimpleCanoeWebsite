// Decompiled with JetBrains decompiler
// Type: FSM.UCUnventedWorksheet
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
  public class UCUnventedWorksheet : UCBase, IUserControl
  {
    private IContainer components;
    private DataTable DtPassFailNa;
    private DataTable DtNotTestedPassFail;
    private DataTable DtApplianceServiced;
    private DataTable DtYesNo;
    private DataTable DtPassFail;
    private DataTable DtYesNoNa;
    private EngineerVisitAssetWorkSheet _Worksheet;
    private EngineerVisit _EngineerVisit;
    private int _jobID;

    public UCUnventedWorksheet(
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
      this.InitializeComponent();
      this.DtPassFailNa = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA, false).Table;
      this.DtNotTestedPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.NotTestedPassFailNA, false).Table;
      this.DtApplianceServiced = App.DB.Picklists.GetAll(Enums.PickListTypes.ApplianceServiced, false).Table;
      this.DtYesNoNa = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table;
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

    internal virtual ComboBox cboServiceRecord { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboWaterPressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboScaledUp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTundish { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboExpansionGap { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSacrificialAnode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFilterStrainerCheck { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPrechargePressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboIntegrity { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPressureDownstream { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboExpansionReliefValve { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPressureReliefValve { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDischargePipes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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
      this.cboServiceRecord = new ComboBox();
      this.cboWaterPressure = new ComboBox();
      this.cboScaledUp = new ComboBox();
      this.cboTundish = new ComboBox();
      this.cboExpansionGap = new ComboBox();
      this.cboSacrificialAnode = new ComboBox();
      this.cboFilterStrainerCheck = new ComboBox();
      this.cboPrechargePressure = new ComboBox();
      this.cboIntegrity = new ComboBox();
      this.cboPressureDownstream = new ComboBox();
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
      this.cboExpansionReliefValve = new ComboBox();
      this.cboPressureReliefValve = new ComboBox();
      this.cboDischargePipes = new ComboBox();
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
      this.cboServiceRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboServiceRecord.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboServiceRecord.Location = new System.Drawing.Point(601, 463);
      this.cboServiceRecord.Name = "cboServiceRecord";
      this.cboServiceRecord.Size = new Size(188, 21);
      this.cboServiceRecord.TabIndex = 14;
      this.cboWaterPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboWaterPressure.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboWaterPressure.Location = new System.Drawing.Point(601, 428);
      this.cboWaterPressure.Name = "cboWaterPressure";
      this.cboWaterPressure.Size = new Size(188, 21);
      this.cboWaterPressure.TabIndex = 13;
      this.cboScaledUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboScaledUp.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboScaledUp.Location = new System.Drawing.Point(601, 287);
      this.cboScaledUp.Name = "cboScaledUp";
      this.cboScaledUp.Size = new Size(188, 21);
      this.cboScaledUp.TabIndex = 9;
      this.cboTundish.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboTundish.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTundish.Location = new System.Drawing.Point(601, 252);
      this.cboTundish.Name = "cboTundish";
      this.cboTundish.Size = new Size(188, 21);
      this.cboTundish.TabIndex = 8;
      this.cboExpansionGap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboExpansionGap.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboExpansionGap.Location = new System.Drawing.Point(601, 218);
      this.cboExpansionGap.Name = "cboExpansionGap";
      this.cboExpansionGap.Size = new Size(188, 21);
      this.cboExpansionGap.TabIndex = 7;
      this.cboSacrificialAnode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSacrificialAnode.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSacrificialAnode.Location = new System.Drawing.Point(601, 183);
      this.cboSacrificialAnode.Name = "cboSacrificialAnode";
      this.cboSacrificialAnode.Size = new Size(188, 21);
      this.cboSacrificialAnode.TabIndex = 6;
      this.cboFilterStrainerCheck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFilterStrainerCheck.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFilterStrainerCheck.Location = new System.Drawing.Point(601, 148);
      this.cboFilterStrainerCheck.Name = "cboFilterStrainerCheck";
      this.cboFilterStrainerCheck.Size = new Size(188, 21);
      this.cboFilterStrainerCheck.TabIndex = 5;
      this.cboPrechargePressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboPrechargePressure.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPrechargePressure.Location = new System.Drawing.Point(601, 113);
      this.cboPrechargePressure.Name = "cboPrechargePressure";
      this.cboPrechargePressure.Size = new Size(188, 21);
      this.cboPrechargePressure.TabIndex = 4;
      this.cboIntegrity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboIntegrity.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboIntegrity.Location = new System.Drawing.Point(601, 79);
      this.cboIntegrity.Name = "cboIntegrity";
      this.cboIntegrity.Size = new Size(188, 21);
      this.cboIntegrity.TabIndex = 3;
      this.cboPressureDownstream.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboPressureDownstream.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPressureDownstream.Location = new System.Drawing.Point(601, 45);
      this.cboPressureDownstream.Name = "cboPressureDownstream";
      this.cboPressureDownstream.Size = new Size(188, 21);
      this.cboPressureDownstream.TabIndex = 2;
      this.cboAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAppliance.Location = new System.Drawing.Point(601, 10);
      this.cboAppliance.Name = "cboAppliance";
      this.cboAppliance.Size = new Size(188, 21);
      this.cboAppliance.TabIndex = 1;
      this.Label46.AutoSize = true;
      this.Label46.Location = new System.Drawing.Point(3, 466);
      this.Label46.Name = "Label46";
      this.Label46.Size = new Size(306, 13);
      this.Label46.TabIndex = 348;
      this.Label46.Text = "Complete service record/Benchmark log if Available";
      this.Label47.AutoSize = true;
      this.Label47.Location = new System.Drawing.Point(3, 431);
      this.Label47.Name = "Label47";
      this.Label47.Size = new Size(326, 13);
      this.Label47.TabIndex = 347;
      this.Label47.Text = "Check water pressure and flow rates at terminal fittings";
      this.Label55.Location = new System.Drawing.Point(3, 396);
      this.Label55.Name = "Label55";
      this.Label55.Size = new Size(568, 30);
      this.Label55.TabIndex = 346;
      this.Label55.Text = "Manually lift the lever to operate the expansion relief valve. Check that it opens, water discharges satisfactorily then closes and reseals correctly. If there is any doubt, replace the valve";
      this.Label56.Location = new System.Drawing.Point(3, 361);
      this.Label56.Name = "Label56";
      this.Label56.Size = new Size(546, 30);
      this.Label56.TabIndex = 345;
      this.Label56.Text = "Manually Lift the lever to operate the temperature and pressure relief valve. Check that it opens, water discharges satisfactory then close and reseals correctly. if there is any doubt replace valves";
      this.Label57.Location = new System.Drawing.Point(3, 325);
      this.Label57.Name = "Label57";
      this.Label57.Size = new Size(546, 31);
      this.Label57.TabIndex = 344;
      this.Label57.Text = "Check discharge pipes D1 and D2 for blockages or obstructions. Check water discharges from termination point and the termination is correctly positioned";
      this.Label58.AutoSize = true;
      this.Label58.Location = new System.Drawing.Point(3, 290);
      this.Label58.Name = "Label58";
      this.Label58.Size = new Size(226, 13);
      this.Label58.TabIndex = 343;
      this.Label58.Text = "Ensure the connection is not scaled up";
      this.Label59.AutoSize = true;
      this.Label59.Location = new System.Drawing.Point(3, (int) byte.MaxValue);
      this.Label59.Name = "Label59";
      this.Label59.Size = new Size(408, 13);
      this.Label59.TabIndex = 342;
      this.Label59.Text = "Check tundish is visible and no water passing from the safety controls";
      this.Label60.Location = new System.Drawing.Point(3, 221);
      this.Label60.Name = "Label60";
      this.Label60.Size = new Size(546, 29);
      this.Label60.TabIndex = 341;
      this.Label60.Text = "If system has internal type expansion facility, re-set expansion gap whilst testing the temperature/pressure relief valve";
      this.Label61.AutoSize = true;
      this.Label61.Location = new System.Drawing.Point(3, 186);
      this.Label61.Name = "Label61";
      this.Label61.Size = new Size(400, 13);
      this.Label61.TabIndex = 340;
      this.Label61.Text = "Visually inspect sacrificial anode if applicable and renew if necessary";
      this.Label62.AutoSize = true;
      this.Label62.Location = new System.Drawing.Point(3, 151);
      this.Label62.Name = "Label62";
      this.Label62.Size = new Size(458, 13);
      this.Label62.TabIndex = 339;
      this.Label62.Text = "Remove and Visibly inspect the filter/strainer and thoroughly clean as required";
      this.Label63.Location = new System.Drawing.Point(3, 116);
      this.Label63.Name = "Label63";
      this.Label63.Size = new Size(546, 30);
      this.Label63.TabIndex = 338;
      this.Label63.Text = "Check pre-charge pressure in expansion vessel and top up as necessary or if water is leaking from schrader valve, replace expansion vessel";
      this.Label64.AutoSize = true;
      this.Label64.Location = new System.Drawing.Point(3, 82);
      this.Label64.Name = "Label64";
      this.Label64.Size = new Size(303, 13);
      this.Label64.TabIndex = 337;
      this.Label64.Text = "Check integrity of cylinder for leaks or damage etc.";
      this.Label65.Location = new System.Drawing.Point(3, 48);
      this.Label65.Name = "Label65";
      this.Label65.Size = new Size(546, 29);
      this.Label65.TabIndex = 336;
      this.Label65.Text = "Check water pressure downstream of pressure reducing/limiting valve, adjust or repalace the valve if pressure is too high";
      this.Label66.AutoSize = true;
      this.Label66.Location = new System.Drawing.Point(3, 13);
      this.Label66.Name = "Label66";
      this.Label66.Size = new Size(62, 13);
      this.Label66.TabIndex = 335;
      this.Label66.Text = "Appliance";
      this.cboExpansionReliefValve.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboExpansionReliefValve.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboExpansionReliefValve.Location = new System.Drawing.Point(601, 391);
      this.cboExpansionReliefValve.Name = "cboExpansionReliefValve";
      this.cboExpansionReliefValve.Size = new Size(188, 21);
      this.cboExpansionReliefValve.TabIndex = 12;
      this.cboPressureReliefValve.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboPressureReliefValve.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPressureReliefValve.Location = new System.Drawing.Point(601, 356);
      this.cboPressureReliefValve.Name = "cboPressureReliefValve";
      this.cboPressureReliefValve.Size = new Size(188, 21);
      this.cboPressureReliefValve.TabIndex = 11;
      this.cboDischargePipes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboDischargePipes.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDischargePipes.Location = new System.Drawing.Point(601, 322);
      this.cboDischargePipes.Name = "cboDischargePipes";
      this.cboDischargePipes.Size = new Size(188, 21);
      this.cboDischargePipes.TabIndex = 10;
      this.lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested10.AutoSize = true;
      this.lblNotTested10.Location = new System.Drawing.Point(656, 430);
      this.lblNotTested10.Name = "lblNotTested10";
      this.lblNotTested10.Size = new Size(67, 13);
      this.lblNotTested10.TabIndex = 416;
      this.lblNotTested10.Text = "Not Tested";
      this.lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested9.AutoSize = true;
      this.lblNotTested9.Location = new System.Drawing.Point(656, 395);
      this.lblNotTested9.Name = "lblNotTested9";
      this.lblNotTested9.Size = new Size(67, 13);
      this.lblNotTested9.TabIndex = 415;
      this.lblNotTested9.Text = "Not Tested";
      this.lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested8.AutoSize = true;
      this.lblNotTested8.Location = new System.Drawing.Point(656, 360);
      this.lblNotTested8.Name = "lblNotTested8";
      this.lblNotTested8.Size = new Size(67, 13);
      this.lblNotTested8.TabIndex = 414;
      this.lblNotTested8.Text = "Not Tested";
      this.lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested7.AutoSize = true;
      this.lblNotTested7.Location = new System.Drawing.Point(656, 325);
      this.lblNotTested7.Name = "lblNotTested7";
      this.lblNotTested7.Size = new Size(67, 13);
      this.lblNotTested7.TabIndex = 413;
      this.lblNotTested7.Text = "Not Tested";
      this.lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested6.AutoSize = true;
      this.lblNotTested6.Location = new System.Drawing.Point(656, 291);
      this.lblNotTested6.Name = "lblNotTested6";
      this.lblNotTested6.Size = new Size(67, 13);
      this.lblNotTested6.TabIndex = 412;
      this.lblNotTested6.Text = "Not Tested";
      this.lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested5.AutoSize = true;
      this.lblNotTested5.Location = new System.Drawing.Point(656, 256);
      this.lblNotTested5.Name = "lblNotTested5";
      this.lblNotTested5.Size = new Size(67, 13);
      this.lblNotTested5.TabIndex = 411;
      this.lblNotTested5.Text = "Not Tested";
      this.lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested4.AutoSize = true;
      this.lblNotTested4.Location = new System.Drawing.Point(656, 221);
      this.lblNotTested4.Name = "lblNotTested4";
      this.lblNotTested4.Size = new Size(67, 13);
      this.lblNotTested4.TabIndex = 410;
      this.lblNotTested4.Text = "Not Tested";
      this.lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested3.AutoSize = true;
      this.lblNotTested3.Location = new System.Drawing.Point(656, 186);
      this.lblNotTested3.Name = "lblNotTested3";
      this.lblNotTested3.Size = new Size(67, 13);
      this.lblNotTested3.TabIndex = 409;
      this.lblNotTested3.Text = "Not Tested";
      this.lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested2.AutoSize = true;
      this.lblNotTested2.Location = new System.Drawing.Point(656, 151);
      this.lblNotTested2.Name = "lblNotTested2";
      this.lblNotTested2.Size = new Size(67, 13);
      this.lblNotTested2.TabIndex = 408;
      this.lblNotTested2.Text = "Not Tested";
      this.lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested1.AutoSize = true;
      this.lblNotTested1.Location = new System.Drawing.Point(656, 116);
      this.lblNotTested1.Name = "lblNotTested1";
      this.lblNotTested1.Size = new Size(67, 13);
      this.lblNotTested1.TabIndex = 407;
      this.lblNotTested1.Text = "Not Tested";
      this.Controls.Add((Control) this.cboExpansionReliefValve);
      this.Controls.Add((Control) this.cboPressureReliefValve);
      this.Controls.Add((Control) this.cboDischargePipes);
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
      this.Controls.Add((Control) this.cboServiceRecord);
      this.Controls.Add((Control) this.cboWaterPressure);
      this.Controls.Add((Control) this.cboScaledUp);
      this.Controls.Add((Control) this.cboTundish);
      this.Controls.Add((Control) this.cboExpansionGap);
      this.Controls.Add((Control) this.cboSacrificialAnode);
      this.Controls.Add((Control) this.cboFilterStrainerCheck);
      this.Controls.Add((Control) this.cboPrechargePressure);
      this.Controls.Add((Control) this.cboIntegrity);
      this.Controls.Add((Control) this.cboPressureDownstream);
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
      this.Name = nameof (UCUnventedWorksheet);
      this.Size = new Size(789, 511);
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
      ComboBox expansionReliefValve = this.cboExpansionReliefValve;
      Combo.SetUpCombo(ref expansionReliefValve, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboExpansionReliefValve = expansionReliefValve;
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetUpCombo(ref cboAppliance, App.DB.JobAsset.JobAsset_Get_For_Job(this.JobID).Table, "AssetID", "AssetDescriptionWithLocation", Enums.ComboValues.Please_Select);
      this.cboAppliance = cboAppliance;
      ComboBox pressureDownstream = this.cboPressureDownstream;
      Combo.SetUpCombo(ref pressureDownstream, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPressureDownstream = pressureDownstream;
      ComboBox cboIntegrity = this.cboIntegrity;
      Combo.SetUpCombo(ref cboIntegrity, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboIntegrity = cboIntegrity;
      ComboBox prechargePressure = this.cboPrechargePressure;
      Combo.SetUpCombo(ref prechargePressure, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPrechargePressure = prechargePressure;
      ComboBox filterStrainerCheck = this.cboFilterStrainerCheck;
      Combo.SetUpCombo(ref filterStrainerCheck, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFilterStrainerCheck = filterStrainerCheck;
      ComboBox sacrificialAnode = this.cboSacrificialAnode;
      Combo.SetUpCombo(ref sacrificialAnode, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSacrificialAnode = sacrificialAnode;
      ComboBox cboExpansionGap = this.cboExpansionGap;
      Combo.SetUpCombo(ref cboExpansionGap, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboExpansionGap = cboExpansionGap;
      ComboBox cboTundish = this.cboTundish;
      Combo.SetUpCombo(ref cboTundish, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTundish = cboTundish;
      ComboBox cboScaledUp = this.cboScaledUp;
      Combo.SetUpCombo(ref cboScaledUp, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboScaledUp = cboScaledUp;
      ComboBox cboWaterPressure = this.cboWaterPressure;
      Combo.SetUpCombo(ref cboWaterPressure, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboWaterPressure = cboWaterPressure;
      ComboBox cboServiceRecord = this.cboServiceRecord;
      Combo.SetUpCombo(ref cboServiceRecord, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboServiceRecord = cboServiceRecord;
      this.cboServiceRecord.Items.Add((object) new Combo("Visually Passed", "999999999", (object) null));
      ComboBox cboDischargePipes = this.cboDischargePipes;
      Combo.SetUpCombo(ref cboDischargePipes, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboDischargePipes = cboDischargePipes;
      ComboBox pressureReliefValve = this.cboPressureReliefValve;
      Combo.SetUpCombo(ref pressureReliefValve, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPressureReliefValve = pressureReliefValve;
    }

    public void Populate(int ID = 0)
    {
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboAppliance, Conversions.ToString(this.Worksheet.AssetID));
      this.cboAppliance = cboAppliance;
      ComboBox prechargePressure = this.cboPrechargePressure;
      Combo.SetSelectedComboItem_By_Value(ref prechargePressure, Conversions.ToString(this.Worksheet.SpillageTestID));
      this.cboPrechargePressure = prechargePressure;
      ComboBox filterStrainerCheck = this.cboFilterStrainerCheck;
      Combo.SetSelectedComboItem_By_Value(ref filterStrainerCheck, Conversions.ToString(this.Worksheet.FlueTerminationSatisfactoryID));
      this.cboFilterStrainerCheck = filterStrainerCheck;
      ComboBox sacrificialAnode = this.cboSacrificialAnode;
      Combo.SetSelectedComboItem_By_Value(ref sacrificialAnode, Conversions.ToString(this.Worksheet.VisualConditionOfFlueSatisfactoryID));
      this.cboSacrificialAnode = sacrificialAnode;
      ComboBox cboExpansionGap = this.cboExpansionGap;
      Combo.SetSelectedComboItem_By_Value(ref cboExpansionGap, Conversions.ToString(this.Worksheet.VentilationProvisionSatisfactoryID));
      this.cboExpansionGap = cboExpansionGap;
      ComboBox cboTundish = this.cboTundish;
      Combo.SetSelectedComboItem_By_Value(ref cboTundish, Conversions.ToString(this.Worksheet.SafetyDeviceOperationID));
      this.cboTundish = cboTundish;
      ComboBox cboScaledUp = this.cboScaledUp;
      Combo.SetSelectedComboItem_By_Value(ref cboScaledUp, Conversions.ToString(this.Worksheet.SweepOutcomeID));
      this.cboScaledUp = cboScaledUp;
      ComboBox cboWaterPressure = this.cboWaterPressure;
      Combo.SetSelectedComboItem_By_Value(ref cboWaterPressure, Conversions.ToString(this.Worksheet.ApplianceServiceOrInspectedID));
      this.cboWaterPressure = cboWaterPressure;
      ComboBox cboServiceRecord = this.cboServiceRecord;
      Combo.SetSelectedComboItem_By_Value(ref cboServiceRecord, Conversions.ToString(this.Worksheet.ApplianceSafeID));
      this.cboServiceRecord = cboServiceRecord;
      ComboBox pressureDownstream = this.cboPressureDownstream;
      Combo.SetSelectedComboItem_By_Value(ref pressureDownstream, Conversions.ToString(this.Worksheet.LandlordsApplianceID));
      this.cboPressureDownstream = pressureDownstream;
      ComboBox cboIntegrity = this.cboIntegrity;
      Combo.SetSelectedComboItem_By_Value(ref cboIntegrity, Conversions.ToString(this.Worksheet.FlueFlowTestID));
      this.cboIntegrity = cboIntegrity;
      ComboBox expansionReliefValve = this.cboExpansionReliefValve;
      Combo.SetSelectedComboItem_By_Value(ref expansionReliefValve, Conversions.ToString(this.Worksheet.TankID));
      this.cboExpansionReliefValve = expansionReliefValve;
      ComboBox cboDischargePipes = this.cboDischargePipes;
      Combo.SetSelectedComboItem_By_Value(ref cboDischargePipes, Conversions.ToString(this.Worksheet.OverallID));
      this.cboDischargePipes = cboDischargePipes;
      ComboBox pressureReliefValve = this.cboPressureReliefValve;
      Combo.SetSelectedComboItem_By_Value(ref pressureReliefValve, Conversions.ToString(this.Worksheet.DischargeID));
      this.cboPressureReliefValve = pressureReliefValve;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.Worksheet.SetReading = (object) 3;
        this.Worksheet.SetAssetID = (object) Combo.get_GetSelectedItemValue(this.cboAppliance);
        this.Worksheet.SetLandlordsApplianceID = (object) Combo.get_GetSelectedItemValue(this.cboPressureDownstream);
        this.Worksheet.SetFlueFlowTestID = (object) Combo.get_GetSelectedItemValue(this.cboIntegrity);
        this.Worksheet.SetSpillageTestID = (object) Combo.get_GetSelectedItemValue(this.cboPrechargePressure);
        this.Worksheet.SetFlueTerminationSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboFilterStrainerCheck);
        this.Worksheet.SetVisualConditionOfFlueSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboSacrificialAnode);
        this.Worksheet.SetVentilationProvisionSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboExpansionGap);
        this.Worksheet.SetSafetyDeviceOperationID = (object) Combo.get_GetSelectedItemValue(this.cboTundish);
        this.Worksheet.SetSweepOutcomeID = (object) Combo.get_GetSelectedItemValue(this.cboScaledUp);
        this.Worksheet.SetOverallID = (object) Combo.get_GetSelectedItemValue(this.cboDischargePipes);
        this.Worksheet.SetDischargeID = (object) Combo.get_GetSelectedItemValue(this.cboPressureReliefValve);
        this.Worksheet.SetTankID = (object) Combo.get_GetSelectedItemValue(this.cboExpansionReliefValve);
        this.Worksheet.SetApplianceServiceOrInspectedID = (object) Combo.get_GetSelectedItemValue(this.cboWaterPressure);
        this.Worksheet.SetApplianceSafeID = (object) Combo.get_GetSelectedItemValue(this.cboServiceRecord);
        this.Worksheet.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        new EngineerVisitAssetWorkSheetValidatorUnvented().Validate(this.Worksheet);
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
        goto label_12;
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
label_12:
      return flag;
    }
  }
}
