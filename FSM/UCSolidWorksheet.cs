// Decompiled with JetBrains decompiler
// Type: FSM.UCSolidWorksheet
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
  public class UCSolidWorksheet : UCBase, IUserControl
  {
    private IContainer components;
    private DataTable DtYesNo;
    private DataTable DtPassFail;
    private DataTable DtPassFailNA;
    private EngineerVisitAssetWorkSheet _Worksheet;
    private EngineerVisit _EngineerVisit;
    private int _jobID;

    public UCSolidWorksheet(
      EngineerVisitAssetWorkSheet worksheet,
      int jobID,
      EngineerVisit EngineerVisit)
    {
      this.DtYesNo = (DataTable) null;
      this.DtPassFail = (DataTable) null;
      this.DtPassFailNA = (DataTable) null;
      this.InitializeComponent();
      this.DtYesNo = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table;
      this.DtPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFail, false).Table;
      this.DtPassFailNA = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA, false).Table;
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

    internal virtual TextBox txtFlueDraught { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNominalOutput { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVentilationType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSafety { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboExtractorFans { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label20 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label21 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label22 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSweptBrush { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFlueClear { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFireGuardFixingPoint { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCorrectHearthSize { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboChimneySwept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboChimneyStructureSound { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVisualCondition { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTerminationSatisfactory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label23 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCombustionAir { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFluePerformance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSafetyDevice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboApplianceServiced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTennantKnow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInstuctions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTypeOfCylinder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboImmersionHeater { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSmokeDrawTest { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUsingApprovedFuel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVentilationAirProvision { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSmokePressureTest { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.txtFlueDraught = new TextBox();
      this.txtNominalOutput = new TextBox();
      this.txtVentilationType = new TextBox();
      this.cboSafety = new ComboBox();
      this.Label18 = new Label();
      this.cboExtractorFans = new ComboBox();
      this.Label19 = new Label();
      this.Label20 = new Label();
      this.Label21 = new Label();
      this.Label22 = new Label();
      this.Label11 = new Label();
      this.Label12 = new Label();
      this.Label13 = new Label();
      this.Label14 = new Label();
      this.Label15 = new Label();
      this.Label16 = new Label();
      this.Label17 = new Label();
      this.Label6 = new Label();
      this.cboSweptBrush = new ComboBox();
      this.Label7 = new Label();
      this.cboFlueClear = new ComboBox();
      this.Label8 = new Label();
      this.cboFireGuardFixingPoint = new ComboBox();
      this.Label9 = new Label();
      this.cboCorrectHearthSize = new ComboBox();
      this.Label10 = new Label();
      this.cboChimneySwept = new ComboBox();
      this.Label3 = new Label();
      this.cboChimneyStructureSound = new ComboBox();
      this.Label4 = new Label();
      this.cboVisualCondition = new ComboBox();
      this.Label5 = new Label();
      this.cboTerminationSatisfactory = new ComboBox();
      this.Label2 = new Label();
      this.cboAppliance = new ComboBox();
      this.Label1 = new Label();
      this.Label23 = new Label();
      this.lblNotTested1 = new Label();
      this.lblNotTested2 = new Label();
      this.lblNotTested3 = new Label();
      this.lblNotTested6 = new Label();
      this.lblNotTested5 = new Label();
      this.lblNotTested4 = new Label();
      this.lblNotTested12 = new Label();
      this.lblNotTested11 = new Label();
      this.lblNotTested10 = new Label();
      this.lblNotTested9 = new Label();
      this.lblNotTested8 = new Label();
      this.lblNotTested7 = new Label();
      this.lblNotTested18 = new Label();
      this.lblNotTested17 = new Label();
      this.lblNotTested16 = new Label();
      this.lblNotTested15 = new Label();
      this.lblNotTested14 = new Label();
      this.lblNotTested13 = new Label();
      this.cboCombustionAir = new ComboBox();
      this.cboFluePerformance = new ComboBox();
      this.cboSafetyDevice = new ComboBox();
      this.cboApplianceServiced = new ComboBox();
      this.cboTennantKnow = new ComboBox();
      this.cboInstuctions = new ComboBox();
      this.cboTypeOfCylinder = new ComboBox();
      this.cboImmersionHeater = new ComboBox();
      this.Label24 = new Label();
      this.Label25 = new Label();
      this.Label26 = new Label();
      this.Label27 = new Label();
      this.cboSmokeDrawTest = new ComboBox();
      this.cboUsingApprovedFuel = new ComboBox();
      this.cboVentilationAirProvision = new ComboBox();
      this.cboSmokePressureTest = new ComboBox();
      this.SuspendLayout();
      this.txtFlueDraught.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtFlueDraught.Location = new System.Drawing.Point(601, 276);
      this.txtFlueDraught.Name = "txtFlueDraught";
      this.txtFlueDraught.Size = new Size(188, 21);
      this.txtFlueDraught.TabIndex = 10;
      this.txtNominalOutput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtNominalOutput.Location = new System.Drawing.Point(601, 366);
      this.txtNominalOutput.Name = "txtNominalOutput";
      this.txtNominalOutput.Size = new Size(188, 21);
      this.txtNominalOutput.TabIndex = 11;
      this.txtVentilationType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtVentilationType.Location = new System.Drawing.Point(601, 576);
      this.txtVentilationType.Name = "txtVentilationType";
      this.txtVentilationType.Size = new Size(188, 21);
      this.txtVentilationType.TabIndex = 18;
      this.cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSafety.Location = new System.Drawing.Point(601, 636);
      this.cboSafety.Name = "cboSafety";
      this.cboSafety.Size = new Size(188, 21);
      this.cboSafety.TabIndex = 20;
      this.Label18.AutoSize = true;
      this.Label18.Location = new System.Drawing.Point(3, 641);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(134, 13);
      this.Label18.TabIndex = 365;
      this.Label18.Text = "Appliance Safe To Use";
      this.cboExtractorFans.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboExtractorFans.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboExtractorFans.Location = new System.Drawing.Point(601, 606);
      this.cboExtractorFans.Name = "cboExtractorFans";
      this.cboExtractorFans.Size = new Size(188, 21);
      this.cboExtractorFans.TabIndex = 19;
      this.Label19.AutoSize = true;
      this.Label19.Location = new System.Drawing.Point(3, 611);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(129, 13);
      this.Label19.TabIndex = 363;
      this.Label19.Text = "Extractor Fans In Use";
      this.Label20.AutoSize = true;
      this.Label20.Location = new System.Drawing.Point(3, 581);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(97, 13);
      this.Label20.TabIndex = 361;
      this.Label20.Text = "Ventilation Type";
      this.Label21.AutoSize = true;
      this.Label21.Location = new System.Drawing.Point(3, 552);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(176, 13);
      this.Label21.TabIndex = 360;
      this.Label21.Text = "Type Of Cylinder At Location?";
      this.Label22.AutoSize = true;
      this.Label22.Location = new System.Drawing.Point(3, 522);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(181, 13);
      this.Label22.TabIndex = 359;
      this.Label22.Text = "Operating Instruction Present?";
      this.Label11.AutoSize = true;
      this.Label11.Location = new System.Drawing.Point(30, 608);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(32, 13);
      this.Label11.TabIndex = 358;
      this.Label11.Text = "CO2";
      this.Label12.AutoSize = true;
      this.Label12.Location = new System.Drawing.Point(3, 461);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(164, 13);
      this.Label12.TabIndex = 357;
      this.Label12.Text = "Immersion Heater Present?";
      this.Label13.AutoSize = true;
      this.Label13.Location = new System.Drawing.Point(3, 431);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(116, 13);
      this.Label13.TabIndex = 356;
      this.Label13.Text = "Appliance Serviced";
      this.Label14.AutoSize = true;
      this.Label14.Location = new System.Drawing.Point(3, 402);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(204, 13);
      this.Label14.TabIndex = 355;
      this.Label14.Text = "Safety Device Operating Correctly";
      this.Label15.AutoSize = true;
      this.Label15.Location = new System.Drawing.Point(3, 372);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(95, 13);
      this.Label15.TabIndex = 354;
      this.Label15.Text = "Nominal Output";
      this.Label16.AutoSize = true;
      this.Label16.Location = new System.Drawing.Point(3, 342);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(212, 13);
      this.Label16.TabIndex = 353;
      this.Label16.Text = "Flue Performance Tests Satisfactory";
      this.Label17.AutoSize = true;
      this.Label17.Location = new System.Drawing.Point(3, 312);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(223, 13);
      this.Label17.TabIndex = 352;
      this.Label17.Text = "Combustion Air Provision Satisfactory";
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(3, 281);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(130, 13);
      this.Label6.TabIndex = 351;
      this.Label6.Text = "Flue Draught Reading";
      this.cboSweptBrush.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSweptBrush.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSweptBrush.Location = new System.Drawing.Point(601, 246);
      this.cboSweptBrush.Name = "cboSweptBrush";
      this.cboSweptBrush.Size = new Size(188, 21);
      this.cboSweptBrush.TabIndex = 9;
      this.Label7.AutoSize = true;
      this.Label7.Location = new System.Drawing.Point(3, 251);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(232, 13);
      this.Label7.TabIndex = 350;
      this.Label7.Text = "Swept Brush Visible At Top Of Chimney";
      this.cboFlueClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFlueClear.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFlueClear.Location = new System.Drawing.Point(601, 216);
      this.cboFlueClear.Name = "cboFlueClear";
      this.cboFlueClear.Size = new Size(188, 21);
      this.cboFlueClear.TabIndex = 8;
      this.Label8.AutoSize = true;
      this.Label8.Location = new System.Drawing.Point(3, 221);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(146, 13);
      this.Label8.TabIndex = 348;
      this.Label8.Text = "Flue Clear Of Obstuction";
      this.cboFireGuardFixingPoint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFireGuardFixingPoint.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFireGuardFixingPoint.Location = new System.Drawing.Point(601, 187);
      this.cboFireGuardFixingPoint.Name = "cboFireGuardFixingPoint";
      this.cboFireGuardFixingPoint.Size = new Size(188, 21);
      this.cboFireGuardFixingPoint.TabIndex = 7;
      this.Label9.AutoSize = true;
      this.Label9.Location = new System.Drawing.Point(3, 192);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(136, 13);
      this.Label9.TabIndex = 346;
      this.Label9.Text = "Fire Guard Fixing Point";
      this.cboCorrectHearthSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboCorrectHearthSize.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCorrectHearthSize.Location = new System.Drawing.Point(601, 157);
      this.cboCorrectHearthSize.Name = "cboCorrectHearthSize";
      this.cboCorrectHearthSize.Size = new Size(188, 21);
      this.cboCorrectHearthSize.TabIndex = 6;
      this.Label10.AutoSize = true;
      this.Label10.Location = new System.Drawing.Point(3, 162);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(120, 13);
      this.Label10.TabIndex = 344;
      this.Label10.Text = "Correct Hearth Size";
      this.cboChimneySwept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboChimneySwept.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboChimneySwept.Location = new System.Drawing.Point(601, (int) sbyte.MaxValue);
      this.cboChimneySwept.Name = "cboChimneySwept";
      this.cboChimneySwept.Size = new Size(188, 21);
      this.cboChimneySwept.TabIndex = 5;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(3, 132);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(97, 13);
      this.Label3.TabIndex = 342;
      this.Label3.Text = "Chimney Swept";
      this.cboChimneyStructureSound.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboChimneyStructureSound.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboChimneyStructureSound.Location = new System.Drawing.Point(601, 97);
      this.cboChimneyStructureSound.Name = "cboChimneyStructureSound";
      this.cboChimneyStructureSound.Size = new Size(188, 21);
      this.cboChimneyStructureSound.TabIndex = 4;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(3, 102);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(155, 13);
      this.Label4.TabIndex = 340;
      this.Label4.Text = "Chimney Structure Sound";
      this.cboVisualCondition.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboVisualCondition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisualCondition.Location = new System.Drawing.Point(601, 67);
      this.cboVisualCondition.Name = "cboVisualCondition";
      this.cboVisualCondition.Size = new Size(188, 21);
      this.cboVisualCondition.TabIndex = 3;
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(3, 72);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(99, 13);
      this.Label5.TabIndex = 338;
      this.Label5.Text = "Visual Condition";
      this.cboTerminationSatisfactory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboTerminationSatisfactory.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTerminationSatisfactory.Location = new System.Drawing.Point(601, 38);
      this.cboTerminationSatisfactory.Name = "cboTerminationSatisfactory";
      this.cboTerminationSatisfactory.Size = new Size(188, 21);
      this.cboTerminationSatisfactory.TabIndex = 2;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(3, 43);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(146, 13);
      this.Label2.TabIndex = 336;
      this.Label2.Text = "Termination Satisfactory";
      this.cboAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAppliance.Location = new System.Drawing.Point(601, 8);
      this.cboAppliance.Name = "cboAppliance";
      this.cboAppliance.Size = new Size(188, 21);
      this.cboAppliance.TabIndex = 1;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(3, 13);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(62, 13);
      this.Label1.TabIndex = 334;
      this.Label1.Text = "Appliance";
      this.Label23.AutoSize = true;
      this.Label23.Location = new System.Drawing.Point(3, 491);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(271, 13);
      this.Label23.TabIndex = 378;
      this.Label23.Text = "Does the tenant know how to use the system?";
      this.lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested1.AutoSize = true;
      this.lblNotTested1.Location = new System.Drawing.Point(661, 100);
      this.lblNotTested1.Name = "lblNotTested1";
      this.lblNotTested1.Size = new Size(67, 13);
      this.lblNotTested1.TabIndex = 379;
      this.lblNotTested1.Text = "Not Tested";
      this.lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested2.AutoSize = true;
      this.lblNotTested2.Location = new System.Drawing.Point(661, 130);
      this.lblNotTested2.Name = "lblNotTested2";
      this.lblNotTested2.Size = new Size(67, 13);
      this.lblNotTested2.TabIndex = 380;
      this.lblNotTested2.Text = "Not Tested";
      this.lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested3.AutoSize = true;
      this.lblNotTested3.Location = new System.Drawing.Point(661, 160);
      this.lblNotTested3.Name = "lblNotTested3";
      this.lblNotTested3.Size = new Size(67, 13);
      this.lblNotTested3.TabIndex = 381;
      this.lblNotTested3.Text = "Not Tested";
      this.lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested6.AutoSize = true;
      this.lblNotTested6.Location = new System.Drawing.Point(661, 250);
      this.lblNotTested6.Name = "lblNotTested6";
      this.lblNotTested6.Size = new Size(67, 13);
      this.lblNotTested6.TabIndex = 384;
      this.lblNotTested6.Text = "Not Tested";
      this.lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested5.AutoSize = true;
      this.lblNotTested5.Location = new System.Drawing.Point(661, 220);
      this.lblNotTested5.Name = "lblNotTested5";
      this.lblNotTested5.Size = new Size(67, 13);
      this.lblNotTested5.TabIndex = 383;
      this.lblNotTested5.Text = "Not Tested";
      this.lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested4.AutoSize = true;
      this.lblNotTested4.Location = new System.Drawing.Point(661, 190);
      this.lblNotTested4.Name = "lblNotTested4";
      this.lblNotTested4.Size = new Size(67, 13);
      this.lblNotTested4.TabIndex = 382;
      this.lblNotTested4.Text = "Not Tested";
      this.lblNotTested12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested12.AutoSize = true;
      this.lblNotTested12.Location = new System.Drawing.Point(661, 429);
      this.lblNotTested12.Name = "lblNotTested12";
      this.lblNotTested12.Size = new Size(67, 13);
      this.lblNotTested12.TabIndex = 390;
      this.lblNotTested12.Text = "Not Tested";
      this.lblNotTested11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested11.AutoSize = true;
      this.lblNotTested11.Location = new System.Drawing.Point(661, 399);
      this.lblNotTested11.Name = "lblNotTested11";
      this.lblNotTested11.Size = new Size(67, 13);
      this.lblNotTested11.TabIndex = 389;
      this.lblNotTested11.Text = "Not Tested";
      this.lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested10.AutoSize = true;
      this.lblNotTested10.Location = new System.Drawing.Point(661, 369);
      this.lblNotTested10.Name = "lblNotTested10";
      this.lblNotTested10.Size = new Size(67, 13);
      this.lblNotTested10.TabIndex = 388;
      this.lblNotTested10.Text = "Not Tested";
      this.lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested9.AutoSize = true;
      this.lblNotTested9.Location = new System.Drawing.Point(661, 339);
      this.lblNotTested9.Name = "lblNotTested9";
      this.lblNotTested9.Size = new Size(67, 13);
      this.lblNotTested9.TabIndex = 387;
      this.lblNotTested9.Text = "Not Tested";
      this.lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested8.AutoSize = true;
      this.lblNotTested8.Location = new System.Drawing.Point(661, 309);
      this.lblNotTested8.Name = "lblNotTested8";
      this.lblNotTested8.Size = new Size(67, 13);
      this.lblNotTested8.TabIndex = 386;
      this.lblNotTested8.Text = "Not Tested";
      this.lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested7.AutoSize = true;
      this.lblNotTested7.Location = new System.Drawing.Point(661, 279);
      this.lblNotTested7.Name = "lblNotTested7";
      this.lblNotTested7.Size = new Size(67, 13);
      this.lblNotTested7.TabIndex = 385;
      this.lblNotTested7.Text = "Not Tested";
      this.lblNotTested18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested18.AutoSize = true;
      this.lblNotTested18.Location = new System.Drawing.Point(661, 609);
      this.lblNotTested18.Name = "lblNotTested18";
      this.lblNotTested18.Size = new Size(67, 13);
      this.lblNotTested18.TabIndex = 396;
      this.lblNotTested18.Text = "Not Tested";
      this.lblNotTested17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested17.AutoSize = true;
      this.lblNotTested17.Location = new System.Drawing.Point(661, 579);
      this.lblNotTested17.Name = "lblNotTested17";
      this.lblNotTested17.Size = new Size(67, 13);
      this.lblNotTested17.TabIndex = 395;
      this.lblNotTested17.Text = "Not Tested";
      this.lblNotTested16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested16.AutoSize = true;
      this.lblNotTested16.Location = new System.Drawing.Point(661, 549);
      this.lblNotTested16.Name = "lblNotTested16";
      this.lblNotTested16.Size = new Size(67, 13);
      this.lblNotTested16.TabIndex = 394;
      this.lblNotTested16.Text = "Not Tested";
      this.lblNotTested15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested15.AutoSize = true;
      this.lblNotTested15.Location = new System.Drawing.Point(661, 519);
      this.lblNotTested15.Name = "lblNotTested15";
      this.lblNotTested15.Size = new Size(67, 13);
      this.lblNotTested15.TabIndex = 393;
      this.lblNotTested15.Text = "Not Tested";
      this.lblNotTested14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested14.AutoSize = true;
      this.lblNotTested14.Location = new System.Drawing.Point(661, 489);
      this.lblNotTested14.Name = "lblNotTested14";
      this.lblNotTested14.Size = new Size(67, 13);
      this.lblNotTested14.TabIndex = 392;
      this.lblNotTested14.Text = "Not Tested";
      this.lblNotTested13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested13.AutoSize = true;
      this.lblNotTested13.Location = new System.Drawing.Point(661, 459);
      this.lblNotTested13.Name = "lblNotTested13";
      this.lblNotTested13.Size = new Size(67, 13);
      this.lblNotTested13.TabIndex = 391;
      this.lblNotTested13.Text = "Not Tested";
      this.cboCombustionAir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboCombustionAir.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCombustionAir.Location = new System.Drawing.Point(601, 306);
      this.cboCombustionAir.Name = "cboCombustionAir";
      this.cboCombustionAir.Size = new Size(188, 21);
      this.cboCombustionAir.TabIndex = 397;
      this.cboFluePerformance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFluePerformance.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFluePerformance.Location = new System.Drawing.Point(601, 336);
      this.cboFluePerformance.Name = "cboFluePerformance";
      this.cboFluePerformance.Size = new Size(188, 21);
      this.cboFluePerformance.TabIndex = 398;
      this.cboSafetyDevice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSafetyDevice.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSafetyDevice.ItemHeight = 13;
      this.cboSafetyDevice.Location = new System.Drawing.Point(601, 397);
      this.cboSafetyDevice.Name = "cboSafetyDevice";
      this.cboSafetyDevice.Size = new Size(188, 21);
      this.cboSafetyDevice.TabIndex = 12;
      this.cboApplianceServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboApplianceServiced.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboApplianceServiced.Location = new System.Drawing.Point(601, 426);
      this.cboApplianceServiced.Name = "cboApplianceServiced";
      this.cboApplianceServiced.Size = new Size(188, 21);
      this.cboApplianceServiced.TabIndex = 13;
      this.cboTennantKnow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboTennantKnow.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTennantKnow.Location = new System.Drawing.Point(601, 486);
      this.cboTennantKnow.Name = "cboTennantKnow";
      this.cboTennantKnow.Size = new Size(188, 21);
      this.cboTennantKnow.TabIndex = 15;
      this.cboInstuctions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboInstuctions.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInstuctions.Location = new System.Drawing.Point(601, 517);
      this.cboInstuctions.Name = "cboInstuctions";
      this.cboInstuctions.Size = new Size(188, 21);
      this.cboInstuctions.TabIndex = 16;
      this.cboTypeOfCylinder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboTypeOfCylinder.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTypeOfCylinder.Location = new System.Drawing.Point(601, 547);
      this.cboTypeOfCylinder.Name = "cboTypeOfCylinder";
      this.cboTypeOfCylinder.Size = new Size(188, 21);
      this.cboTypeOfCylinder.TabIndex = 17;
      this.cboImmersionHeater.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboImmersionHeater.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboImmersionHeater.Location = new System.Drawing.Point(601, 456);
      this.cboImmersionHeater.Name = "cboImmersionHeater";
      this.cboImmersionHeater.Size = new Size(188, 21);
      this.cboImmersionHeater.TabIndex = 14;
      this.Label24.AutoSize = true;
      this.Label24.Location = new System.Drawing.Point(3, 760);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(130, 13);
      this.Label24.TabIndex = 409;
      this.Label24.Text = "Using Approved Fuel?";
      this.Label25.AutoSize = true;
      this.Label25.Location = new System.Drawing.Point(3, 730);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(214, 13);
      this.Label25.TabIndex = 408;
      this.Label25.Text = "Ventilation Air Provision Satisfactory";
      this.Label26.AutoSize = true;
      this.Label26.Location = new System.Drawing.Point(3, 700);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(128, 13);
      this.Label26.TabIndex = 407;
      this.Label26.Text = "Smoke Pressure Test";
      this.Label27.AutoSize = true;
      this.Label27.Location = new System.Drawing.Point(3, 671);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(112, 13);
      this.Label27.TabIndex = 406;
      this.Label27.Text = "Smoke Draw Test ";
      this.cboSmokeDrawTest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSmokeDrawTest.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSmokeDrawTest.Location = new System.Drawing.Point(601, 666);
      this.cboSmokeDrawTest.Name = "cboSmokeDrawTest";
      this.cboSmokeDrawTest.Size = new Size(188, 21);
      this.cboSmokeDrawTest.TabIndex = 21;
      this.cboUsingApprovedFuel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboUsingApprovedFuel.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboUsingApprovedFuel.Location = new System.Drawing.Point(601, 757);
      this.cboUsingApprovedFuel.Name = "cboUsingApprovedFuel";
      this.cboUsingApprovedFuel.Size = new Size(188, 21);
      this.cboUsingApprovedFuel.TabIndex = 24;
      this.cboVentilationAirProvision.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboVentilationAirProvision.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVentilationAirProvision.Location = new System.Drawing.Point(601, 727);
      this.cboVentilationAirProvision.Name = "cboVentilationAirProvision";
      this.cboVentilationAirProvision.Size = new Size(188, 21);
      this.cboVentilationAirProvision.TabIndex = 23;
      this.cboSmokePressureTest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSmokePressureTest.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSmokePressureTest.Location = new System.Drawing.Point(601, 696);
      this.cboSmokePressureTest.Name = "cboSmokePressureTest";
      this.cboSmokePressureTest.Size = new Size(188, 21);
      this.cboSmokePressureTest.TabIndex = 22;
      this.Controls.Add((Control) this.cboSmokeDrawTest);
      this.Controls.Add((Control) this.cboUsingApprovedFuel);
      this.Controls.Add((Control) this.cboVentilationAirProvision);
      this.Controls.Add((Control) this.cboSmokePressureTest);
      this.Controls.Add((Control) this.Label24);
      this.Controls.Add((Control) this.Label25);
      this.Controls.Add((Control) this.Label26);
      this.Controls.Add((Control) this.Label27);
      this.Controls.Add((Control) this.cboImmersionHeater);
      this.Controls.Add((Control) this.cboTypeOfCylinder);
      this.Controls.Add((Control) this.cboInstuctions);
      this.Controls.Add((Control) this.cboTennantKnow);
      this.Controls.Add((Control) this.cboApplianceServiced);
      this.Controls.Add((Control) this.cboSafetyDevice);
      this.Controls.Add((Control) this.cboFluePerformance);
      this.Controls.Add((Control) this.cboCombustionAir);
      this.Controls.Add((Control) this.Label23);
      this.Controls.Add((Control) this.txtFlueDraught);
      this.Controls.Add((Control) this.txtNominalOutput);
      this.Controls.Add((Control) this.txtVentilationType);
      this.Controls.Add((Control) this.cboSafety);
      this.Controls.Add((Control) this.Label18);
      this.Controls.Add((Control) this.cboExtractorFans);
      this.Controls.Add((Control) this.Label19);
      this.Controls.Add((Control) this.Label20);
      this.Controls.Add((Control) this.Label21);
      this.Controls.Add((Control) this.Label22);
      this.Controls.Add((Control) this.Label11);
      this.Controls.Add((Control) this.Label12);
      this.Controls.Add((Control) this.Label13);
      this.Controls.Add((Control) this.Label14);
      this.Controls.Add((Control) this.Label15);
      this.Controls.Add((Control) this.Label16);
      this.Controls.Add((Control) this.Label17);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.cboSweptBrush);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.cboFlueClear);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.cboFireGuardFixingPoint);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.cboCorrectHearthSize);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.cboChimneySwept);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cboChimneyStructureSound);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.cboVisualCondition);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.cboTerminationSatisfactory);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.cboAppliance);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.lblNotTested18);
      this.Controls.Add((Control) this.lblNotTested17);
      this.Controls.Add((Control) this.lblNotTested16);
      this.Controls.Add((Control) this.lblNotTested15);
      this.Controls.Add((Control) this.lblNotTested14);
      this.Controls.Add((Control) this.lblNotTested13);
      this.Controls.Add((Control) this.lblNotTested12);
      this.Controls.Add((Control) this.lblNotTested11);
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
      this.Name = nameof (UCSolidWorksheet);
      this.Size = new Size(789, 795);
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
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetUpCombo(ref cboAppliance, App.DB.JobAsset.JobAsset_Get_For_Job(this.JobID).Table, "AssetID", "AssetDescriptionWithLocation", Enums.ComboValues.Please_Select);
      this.cboAppliance = cboAppliance;
      ComboBox correctHearthSize = this.cboCorrectHearthSize;
      Combo.SetUpCombo(ref correctHearthSize, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCorrectHearthSize = correctHearthSize;
      ComboBox guardFixingPoint = this.cboFireGuardFixingPoint;
      Combo.SetUpCombo(ref guardFixingPoint, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFireGuardFixingPoint = guardFixingPoint;
      ComboBox chimneyStructureSound = this.cboChimneyStructureSound;
      Combo.SetUpCombo(ref chimneyStructureSound, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboChimneyStructureSound = chimneyStructureSound;
      ComboBox cboChimneySwept = this.cboChimneySwept;
      Combo.SetUpCombo(ref cboChimneySwept, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboChimneySwept = cboChimneySwept;
      ComboBox cboFlueClear = this.cboFlueClear;
      Combo.SetUpCombo(ref cboFlueClear, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFlueClear = cboFlueClear;
      ComboBox cboSweptBrush = this.cboSweptBrush;
      Combo.SetUpCombo(ref cboSweptBrush, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSweptBrush = cboSweptBrush;
      ComboBox terminationSatisfactory = this.cboTerminationSatisfactory;
      Combo.SetUpCombo(ref terminationSatisfactory, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTerminationSatisfactory = terminationSatisfactory;
      ComboBox cboVisualCondition = this.cboVisualCondition;
      Combo.SetUpCombo(ref cboVisualCondition, this.DtPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboVisualCondition = cboVisualCondition;
      ComboBox cboExtractorFans = this.cboExtractorFans;
      Combo.SetUpCombo(ref cboExtractorFans, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboExtractorFans = cboExtractorFans;
      ComboBox cboSmokeDrawTest = this.cboSmokeDrawTest;
      Combo.SetUpCombo(ref cboSmokeDrawTest, this.DtPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSmokeDrawTest = cboSmokeDrawTest;
      ComboBox smokePressureTest = this.cboSmokePressureTest;
      Combo.SetUpCombo(ref smokePressureTest, this.DtPassFailNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSmokePressureTest = smokePressureTest;
      ComboBox ventilationAirProvision = this.cboVentilationAirProvision;
      Combo.SetUpCombo(ref ventilationAirProvision, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboVentilationAirProvision = ventilationAirProvision;
      ComboBox cboCombustionAir = this.cboCombustionAir;
      Combo.SetUpCombo(ref cboCombustionAir, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCombustionAir = cboCombustionAir;
      ComboBox cboFluePerformance = this.cboFluePerformance;
      Combo.SetUpCombo(ref cboFluePerformance, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFluePerformance = cboFluePerformance;
      ComboBox cboSafetyDevice = this.cboSafetyDevice;
      Combo.SetUpCombo(ref cboSafetyDevice, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSafetyDevice = cboSafetyDevice;
      ComboBox applianceServiced = this.cboApplianceServiced;
      Combo.SetUpCombo(ref applianceServiced, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboApplianceServiced = applianceServiced;
      ComboBox cboSafety = this.cboSafety;
      Combo.SetUpCombo(ref cboSafety, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSafety = cboSafety;
      ComboBox cboTennantKnow = this.cboTennantKnow;
      Combo.SetUpCombo(ref cboTennantKnow, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTennantKnow = cboTennantKnow;
      ComboBox cboInstuctions = this.cboInstuctions;
      Combo.SetUpCombo(ref cboInstuctions, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboInstuctions = cboInstuctions;
      ComboBox cboTypeOfCylinder = this.cboTypeOfCylinder;
      Combo.SetUpCombo(ref cboTypeOfCylinder, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboTypeOfCylinder = cboTypeOfCylinder;
      ComboBox cboImmersionHeater = this.cboImmersionHeater;
      Combo.SetUpCombo(ref cboImmersionHeater, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboImmersionHeater = cboImmersionHeater;
      ComboBox usingApprovedFuel = this.cboUsingApprovedFuel;
      Combo.SetUpCombo(ref usingApprovedFuel, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboUsingApprovedFuel = usingApprovedFuel;
    }

    public void Populate(int ID = 0)
    {
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboAppliance, Conversions.ToString(this.Worksheet.AssetID));
      this.cboAppliance = cboAppliance;
      ComboBox terminationSatisfactory = this.cboTerminationSatisfactory;
      Combo.SetSelectedComboItem_By_Value(ref terminationSatisfactory, Conversions.ToString(this.Worksheet.LandlordsApplianceID));
      this.cboTerminationSatisfactory = terminationSatisfactory;
      ComboBox cboVisualCondition = this.cboVisualCondition;
      Combo.SetSelectedComboItem_By_Value(ref cboVisualCondition, Conversions.ToString(this.Worksheet.ApplianceTestedID));
      this.cboVisualCondition = cboVisualCondition;
      ComboBox cboChimneySwept = this.cboChimneySwept;
      Combo.SetSelectedComboItem_By_Value(ref cboChimneySwept, Conversions.ToString(this.Worksheet.SpillageTestID));
      this.cboChimneySwept = cboChimneySwept;
      ComboBox correctHearthSize = this.cboCorrectHearthSize;
      Combo.SetSelectedComboItem_By_Value(ref correctHearthSize, Conversions.ToString(this.Worksheet.FlueTerminationSatisfactoryID));
      this.cboCorrectHearthSize = correctHearthSize;
      ComboBox guardFixingPoint = this.cboFireGuardFixingPoint;
      Combo.SetSelectedComboItem_By_Value(ref guardFixingPoint, Conversions.ToString(this.Worksheet.VisualConditionOfFlueSatisfactoryID));
      this.cboFireGuardFixingPoint = guardFixingPoint;
      ComboBox chimneyStructureSound = this.cboChimneyStructureSound;
      Combo.SetSelectedComboItem_By_Value(ref chimneyStructureSound, Conversions.ToString(this.Worksheet.FlueFlowTestID));
      this.cboChimneyStructureSound = chimneyStructureSound;
      ComboBox cboFlueClear = this.cboFlueClear;
      Combo.SetSelectedComboItem_By_Value(ref cboFlueClear, Conversions.ToString(this.Worksheet.VentilationProvisionSatisfactoryID));
      this.cboFlueClear = cboFlueClear;
      ComboBox cboSweptBrush = this.cboSweptBrush;
      Combo.SetSelectedComboItem_By_Value(ref cboSweptBrush, Conversions.ToString(this.Worksheet.SafetyDeviceOperationID));
      this.cboSweptBrush = cboSweptBrush;
      this.txtFlueDraught.Text = Conversions.ToString(this.Worksheet.DHWFlowRate);
      ComboBox cboCombustionAir = this.cboCombustionAir;
      Combo.SetSelectedComboItem_By_Value(ref cboCombustionAir, Conversions.ToString(this.Worksheet.ColdWaterTemp));
      this.cboCombustionAir = cboCombustionAir;
      ComboBox cboFluePerformance = this.cboFluePerformance;
      Combo.SetSelectedComboItem_By_Value(ref cboFluePerformance, Conversions.ToString(this.Worksheet.DHWTemp));
      this.cboFluePerformance = cboFluePerformance;
      this.txtNominalOutput.Text = Conversions.ToString(this.Worksheet.InletStaticPressure);
      ComboBox cboSafetyDevice = this.cboSafetyDevice;
      Combo.SetSelectedComboItem_By_Value(ref cboSafetyDevice, Conversions.ToString(this.Worksheet.InletWorkingPressure));
      this.cboSafetyDevice = cboSafetyDevice;
      ComboBox applianceServiced = this.cboApplianceServiced;
      Combo.SetSelectedComboItem_By_Value(ref applianceServiced, Conversions.ToString(this.Worksheet.MinBurnerPressure));
      this.cboApplianceServiced = applianceServiced;
      ComboBox cboImmersionHeater = this.cboImmersionHeater;
      Combo.SetSelectedComboItem_By_Value(ref cboImmersionHeater, this.Worksheet.Nozzle);
      this.cboImmersionHeater = cboImmersionHeater;
      ComboBox cboTennantKnow = this.cboTennantKnow;
      Combo.SetSelectedComboItem_By_Value(ref cboTennantKnow, Conversions.ToString(this.Worksheet.CO2));
      this.cboTennantKnow = cboTennantKnow;
      ComboBox cboInstuctions = this.cboInstuctions;
      Combo.SetSelectedComboItem_By_Value(ref cboInstuctions, Conversions.ToString(this.Worksheet.CO2CORatio));
      this.cboInstuctions = cboInstuctions;
      ComboBox cboTypeOfCylinder = this.cboTypeOfCylinder;
      Combo.SetSelectedComboItem_By_Value(ref cboTypeOfCylinder, this.Worksheet.BMake);
      this.cboTypeOfCylinder = cboTypeOfCylinder;
      this.txtVentilationType.Text = this.Worksheet.BModel;
      ComboBox cboExtractorFans = this.cboExtractorFans;
      Combo.SetSelectedComboItem_By_Value(ref cboExtractorFans, Conversions.ToString(this.Worksheet.ApplianceServiceOrInspectedID));
      this.cboExtractorFans = cboExtractorFans;
      ComboBox cboSafety = this.cboSafety;
      Combo.SetSelectedComboItem_By_Value(ref cboSafety, Conversions.ToString(this.Worksheet.ApplianceSafeID));
      this.cboSafety = cboSafety;
      ComboBox cboSmokeDrawTest = this.cboSmokeDrawTest;
      Combo.SetSelectedComboItem_By_Value(ref cboSmokeDrawTest, Conversions.ToString(this.Worksheet.DischargeID));
      this.cboSmokeDrawTest = cboSmokeDrawTest;
      ComboBox smokePressureTest = this.cboSmokePressureTest;
      Combo.SetSelectedComboItem_By_Value(ref smokePressureTest, Conversions.ToString(this.Worksheet.SweepOutcomeID));
      this.cboSmokePressureTest = smokePressureTest;
      ComboBox ventilationAirProvision = this.cboVentilationAirProvision;
      Combo.SetSelectedComboItem_By_Value(ref ventilationAirProvision, Conversions.ToString(this.Worksheet.OverallID));
      this.cboVentilationAirProvision = ventilationAirProvision;
      ComboBox usingApprovedFuel = this.cboUsingApprovedFuel;
      Combo.SetSelectedComboItem_By_Value(ref usingApprovedFuel, Conversions.ToString(this.Worksheet.TankID));
      this.cboUsingApprovedFuel = usingApprovedFuel;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.Worksheet.SetReading = (object) 2;
        this.Worksheet.SetAssetID = (object) Combo.get_GetSelectedItemValue(this.cboAppliance);
        this.Worksheet.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        this.Worksheet.SetInletStaticPressure = (object) this.txtNominalOutput.Text;
        this.Worksheet.SetFlueTerminationSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboCorrectHearthSize);
        this.Worksheet.SetVisualConditionOfFlueSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboFireGuardFixingPoint);
        this.Worksheet.SetFlueFlowTestID = (object) Combo.get_GetSelectedItemValue(this.cboChimneyStructureSound);
        this.Worksheet.SetSpillageTestID = (object) Combo.get_GetSelectedItemValue(this.cboChimneySwept);
        this.Worksheet.SetVentilationProvisionSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboFlueClear);
        this.Worksheet.SetSafetyDeviceOperationID = (object) Combo.get_GetSelectedItemValue(this.cboSweptBrush);
        this.Worksheet.SetLandlordsApplianceID = (object) Combo.get_GetSelectedItemValue(this.cboTerminationSatisfactory);
        this.Worksheet.SetApplianceTestedID = (object) Combo.get_GetSelectedItemValue(this.cboVisualCondition);
        this.Worksheet.SetApplianceServiceOrInspectedID = (object) Combo.get_GetSelectedItemValue(this.cboExtractorFans);
        this.Worksheet.SetDischargeID = (object) Combo.get_GetSelectedItemValue(this.cboSmokeDrawTest);
        this.Worksheet.SetSweepOutcomeID = (object) Combo.get_GetSelectedItemValue(this.cboSmokePressureTest);
        this.Worksheet.SetDHWFlowRate = (object) this.txtFlueDraught.Text;
        this.Worksheet.SetBModel = (object) this.txtVentilationType.Text;
        this.Worksheet.SetOverallID = (object) Combo.get_GetSelectedItemValue(this.cboVentilationAirProvision);
        this.Worksheet.SetColdWaterTemp = (object) Combo.get_GetSelectedItemValue(this.cboCombustionAir);
        this.Worksheet.SetDHWTemp = (object) Combo.get_GetSelectedItemValue(this.cboFluePerformance);
        this.Worksheet.SetInletWorkingPressure = (object) Combo.get_GetSelectedItemValue(this.cboSafetyDevice);
        this.Worksheet.SetMinBurnerPressure = (object) Combo.get_GetSelectedItemValue(this.cboApplianceServiced);
        this.Worksheet.SetApplianceSafeID = (object) Combo.get_GetSelectedItemValue(this.cboSafety);
        this.Worksheet.SetCO2 = (object) Combo.get_GetSelectedItemValue(this.cboTennantKnow);
        this.Worksheet.SetCO2CORatio = (object) Combo.get_GetSelectedItemValue(this.cboInstuctions);
        this.Worksheet.SetBMake = (object) Combo.get_GetSelectedItemValue(this.cboTypeOfCylinder);
        this.Worksheet.SetNozzle = (object) Combo.get_GetSelectedItemValue(this.cboImmersionHeater);
        this.Worksheet.SetTankID = (object) Combo.get_GetSelectedItemValue(this.cboUsingApprovedFuel);
        new EngineerVisitAssetWorkSheetValidatorSolid().Validate(this.Worksheet);
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
