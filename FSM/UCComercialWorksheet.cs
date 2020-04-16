// Decompiled with JetBrains decompiler
// Type: FSM.UCComercialWorksheet
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
  public class UCComercialWorksheet : UCBase, IUserControl
  {
    private IContainer components;
    private DataTable DtPassFailNa;
    private DataTable DtNotTestedPassFail;
    private DataTable DtApplianceServiced;
    private DataTable DtYesNo;
    private DataTable DtYesNoNa;
    private DataTable DtPassFail;
    private EngineerVisitAssetWorkSheet _Worksheet;
    private EngineerVisit _EngineerVisit;
    private int _jobID;

    public UCComercialWorksheet(
      EngineerVisitAssetWorkSheet worksheet,
      int jobID,
      EngineerVisit EngineerVisit)
    {
      this.DtPassFailNa = (DataTable) null;
      this.DtNotTestedPassFail = (DataTable) null;
      this.DtApplianceServiced = (DataTable) null;
      this.DtYesNo = (DataTable) null;
      this.DtYesNoNa = (DataTable) null;
      this.DtPassFail = (DataTable) null;
      this.InitializeComponent();
      this.DtPassFailNa = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA, false).Table;
      this.DtNotTestedPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.NotTestedPassFailNA, false).Table;
      this.DtApplianceServiced = App.DB.Picklists.GetAll(Enums.PickListTypes.ApplianceServiced, false).Table;
      this.DtYesNo = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo, false).Table;
      this.DtYesNoNa = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA, false).Table;
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

    internal virtual TextBox txtMaxCO { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMaxCO2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHeatInput { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtOperatingPressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSafety { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboServiced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboGastight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFSPFitted { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboGasIsolation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboManufactureInfo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboElectricalIsolator { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboGasHose { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLLAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.txtMaxCO = new TextBox();
      this.txtMaxCO2 = new TextBox();
      this.txtHeatInput = new TextBox();
      this.txtOperatingPressure = new TextBox();
      this.cboSafety = new ComboBox();
      this.Label18 = new Label();
      this.cboServiced = new ComboBox();
      this.Label19 = new Label();
      this.Label15 = new Label();
      this.Label16 = new Label();
      this.Label17 = new Label();
      this.Label6 = new Label();
      this.cboGastight = new ComboBox();
      this.Label7 = new Label();
      this.cboFSPFitted = new ComboBox();
      this.Label8 = new Label();
      this.cboGasIsolation = new ComboBox();
      this.Label9 = new Label();
      this.cboManufactureInfo = new ComboBox();
      this.Label10 = new Label();
      this.cboElectricalIsolator = new ComboBox();
      this.Label3 = new Label();
      this.cboGasHose = new ComboBox();
      this.Label4 = new Label();
      this.cboTested = new ComboBox();
      this.Label5 = new Label();
      this.cboLLAppliance = new ComboBox();
      this.Label2 = new Label();
      this.cboAppliance = new ComboBox();
      this.Label1 = new Label();
      this.lblNotTested1 = new Label();
      this.lblNotTested2 = new Label();
      this.lblNotTested3 = new Label();
      this.lblNotTested6 = new Label();
      this.lblNotTested5 = new Label();
      this.lblNotTested4 = new Label();
      this.lblNotTested10 = new Label();
      this.lblNotTested9 = new Label();
      this.lblNotTested8 = new Label();
      this.lblNotTested7 = new Label();
      this.lblNotTested18 = new Label();
      this.SuspendLayout();
      this.txtMaxCO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtMaxCO.Location = new System.Drawing.Point(601, 278);
      this.txtMaxCO.Name = "txtMaxCO";
      this.txtMaxCO.Size = new Size(188, 21);
      this.txtMaxCO.TabIndex = 10;
      this.txtMaxCO2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtMaxCO2.Location = new System.Drawing.Point(601, 309);
      this.txtMaxCO2.Name = "txtMaxCO2";
      this.txtMaxCO2.Size = new Size(188, 21);
      this.txtMaxCO2.TabIndex = 11;
      this.txtHeatInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtHeatInput.Location = new System.Drawing.Point(601, 339);
      this.txtHeatInput.Name = "txtHeatInput";
      this.txtHeatInput.Size = new Size(188, 21);
      this.txtHeatInput.TabIndex = 12;
      this.txtOperatingPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtOperatingPressure.Location = new System.Drawing.Point(601, 368);
      this.txtOperatingPressure.Name = "txtOperatingPressure";
      this.txtOperatingPressure.Size = new Size(188, 21);
      this.txtOperatingPressure.TabIndex = 13;
      this.cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSafety.Location = new System.Drawing.Point(601, 428);
      this.cboSafety.Name = "cboSafety";
      this.cboSafety.Size = new Size(188, 21);
      this.cboSafety.TabIndex = 22;
      this.Label18.AutoSize = true;
      this.Label18.Location = new System.Drawing.Point(3, 431);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(101, 13);
      this.Label18.TabIndex = 365;
      this.Label18.Text = "Appliance safety";
      this.cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboServiced.Location = new System.Drawing.Point(601, 398);
      this.cboServiced.Name = "cboServiced";
      this.cboServiced.Size = new Size(188, 21);
      this.cboServiced.TabIndex = 21;
      this.Label19.AutoSize = true;
      this.Label19.Location = new System.Drawing.Point(3, 401);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(181, 13);
      this.Label19.TabIndex = 363;
      this.Label19.Text = "Appliance service or inspected";
      this.Label15.AutoSize = true;
      this.Label15.Location = new System.Drawing.Point(3, 372);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(161, 13);
      this.Label15.TabIndex = 354;
      this.Label15.Text = "Operating pressure (mbar)";
      this.Label16.AutoSize = true;
      this.Label16.Location = new System.Drawing.Point(3, 342);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(98, 13);
      this.Label16.TabIndex = 353;
      this.Label16.Text = "Heat input (KW)";
      this.Label17.AutoSize = true;
      this.Label17.Location = new System.Drawing.Point(3, 312);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(209, 13);
      this.Label17.TabIndex = 352;
      this.Label17.Text = "Max CO2 reading around Appliance";
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(3, 281);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(202, 13);
      this.Label6.TabIndex = 351;
      this.Label6.Text = "Max CO reading around Appliance";
      this.cboGastight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboGastight.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboGastight.Location = new System.Drawing.Point(601, 248);
      this.cboGastight.Name = "cboGastight";
      this.cboGastight.Size = new Size(188, 21);
      this.cboGastight.TabIndex = 9;
      this.Label7.AutoSize = true;
      this.Label7.Location = new System.Drawing.Point(3, 251);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(108, 13);
      this.Label7.TabIndex = 350;
      this.Label7.Text = "Pipework gastight";
      this.cboFSPFitted.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFSPFitted.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFSPFitted.Location = new System.Drawing.Point(601, 218);
      this.cboFSPFitted.Name = "cboFSPFitted";
      this.cboFSPFitted.Size = new Size(188, 21);
      this.cboFSPFitted.TabIndex = 8;
      this.Label8.AutoSize = true;
      this.Label8.Location = new System.Drawing.Point(3, 221);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(141, 13);
      this.Label8.TabIndex = 348;
      this.Label8.Text = "FSP fitted to all burners";
      this.cboGasIsolation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboGasIsolation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboGasIsolation.Location = new System.Drawing.Point(601, 189);
      this.cboGasIsolation.Name = "cboGasIsolation";
      this.cboGasIsolation.Size = new Size(188, 21);
      this.cboGasIsolation.TabIndex = 7;
      this.Label9.AutoSize = true;
      this.Label9.Location = new System.Drawing.Point(3, 192);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(148, 13);
      this.Label9.TabIndex = 346;
      this.Label9.Text = "Gas isolation value fitted";
      this.cboManufactureInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboManufactureInfo.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboManufactureInfo.Location = new System.Drawing.Point(601, 159);
      this.cboManufactureInfo.Name = "cboManufactureInfo";
      this.cboManufactureInfo.Size = new Size(188, 21);
      this.cboManufactureInfo.TabIndex = 6;
      this.Label10.AutoSize = true;
      this.Label10.Location = new System.Drawing.Point(3, 162);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(208, 13);
      this.Label10.TabIndex = 344;
      this.Label10.Text = "Manufactures inforamtion Available";
      this.cboElectricalIsolator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboElectricalIsolator.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboElectricalIsolator.Location = new System.Drawing.Point(601, 129);
      this.cboElectricalIsolator.Name = "cboElectricalIsolator";
      this.cboElectricalIsolator.Size = new Size(188, 21);
      this.cboElectricalIsolator.TabIndex = 5;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(3, 132);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(251, 13);
      this.Label3.TabIndex = 342;
      this.Label3.Text = "Electrical isolator fitten and correctly fused";
      this.cboGasHose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboGasHose.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboGasHose.Location = new System.Drawing.Point(601, 99);
      this.cboGasHose.Name = "cboGasHose";
      this.cboGasHose.Size = new Size(188, 21);
      this.cboGasHose.TabIndex = 4;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(3, 102);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(276, 13);
      this.Label4.TabIndex = 340;
      this.Label4.Text = "Gas hose and required restraint fitted correctly";
      this.cboTested.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboTested.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTested.Location = new System.Drawing.Point(601, 69);
      this.cboTested.Name = "cboTested";
      this.cboTested.Size = new Size(188, 21);
      this.cboTested.TabIndex = 3;
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(3, 72);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(101, 13);
      this.Label5.TabIndex = 338;
      this.Label5.Text = "Appliance tested";
      this.cboLLAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboLLAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLLAppliance.Location = new System.Drawing.Point(601, 40);
      this.cboLLAppliance.Name = "cboLLAppliance";
      this.cboLLAppliance.Size = new Size(188, 21);
      this.cboLLAppliance.TabIndex = 2;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(3, 43);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(125, 13);
      this.Label2.TabIndex = 336;
      this.Label2.Text = "Landlords Appliance ";
      this.cboAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAppliance.Location = new System.Drawing.Point(601, 10);
      this.cboAppliance.Name = "cboAppliance";
      this.cboAppliance.Size = new Size(188, 21);
      this.cboAppliance.TabIndex = 1;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(3, 13);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(62, 13);
      this.Label1.TabIndex = 334;
      this.Label1.Text = "Appliance";
      this.lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested1.AutoSize = true;
      this.lblNotTested1.Location = new System.Drawing.Point(661, 102);
      this.lblNotTested1.Name = "lblNotTested1";
      this.lblNotTested1.Size = new Size(67, 13);
      this.lblNotTested1.TabIndex = 379;
      this.lblNotTested1.Text = "Not Tested";
      this.lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested2.AutoSize = true;
      this.lblNotTested2.Location = new System.Drawing.Point(661, 132);
      this.lblNotTested2.Name = "lblNotTested2";
      this.lblNotTested2.Size = new Size(67, 13);
      this.lblNotTested2.TabIndex = 380;
      this.lblNotTested2.Text = "Not Tested";
      this.lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested3.AutoSize = true;
      this.lblNotTested3.Location = new System.Drawing.Point(661, 162);
      this.lblNotTested3.Name = "lblNotTested3";
      this.lblNotTested3.Size = new Size(67, 13);
      this.lblNotTested3.TabIndex = 381;
      this.lblNotTested3.Text = "Not Tested";
      this.lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested6.AutoSize = true;
      this.lblNotTested6.Location = new System.Drawing.Point(661, 252);
      this.lblNotTested6.Name = "lblNotTested6";
      this.lblNotTested6.Size = new Size(67, 13);
      this.lblNotTested6.TabIndex = 384;
      this.lblNotTested6.Text = "Not Tested";
      this.lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested5.AutoSize = true;
      this.lblNotTested5.Location = new System.Drawing.Point(661, 222);
      this.lblNotTested5.Name = "lblNotTested5";
      this.lblNotTested5.Size = new Size(67, 13);
      this.lblNotTested5.TabIndex = 383;
      this.lblNotTested5.Text = "Not Tested";
      this.lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested4.AutoSize = true;
      this.lblNotTested4.Location = new System.Drawing.Point(661, 192);
      this.lblNotTested4.Name = "lblNotTested4";
      this.lblNotTested4.Size = new Size(67, 13);
      this.lblNotTested4.TabIndex = 382;
      this.lblNotTested4.Text = "Not Tested";
      this.lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested10.AutoSize = true;
      this.lblNotTested10.Location = new System.Drawing.Point(661, 371);
      this.lblNotTested10.Name = "lblNotTested10";
      this.lblNotTested10.Size = new Size(67, 13);
      this.lblNotTested10.TabIndex = 388;
      this.lblNotTested10.Text = "Not Tested";
      this.lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested9.AutoSize = true;
      this.lblNotTested9.Location = new System.Drawing.Point(661, 341);
      this.lblNotTested9.Name = "lblNotTested9";
      this.lblNotTested9.Size = new Size(67, 13);
      this.lblNotTested9.TabIndex = 387;
      this.lblNotTested9.Text = "Not Tested";
      this.lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested8.AutoSize = true;
      this.lblNotTested8.Location = new System.Drawing.Point(661, 311);
      this.lblNotTested8.Name = "lblNotTested8";
      this.lblNotTested8.Size = new Size(67, 13);
      this.lblNotTested8.TabIndex = 386;
      this.lblNotTested8.Text = "Not Tested";
      this.lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested7.AutoSize = true;
      this.lblNotTested7.Location = new System.Drawing.Point(661, 281);
      this.lblNotTested7.Name = "lblNotTested7";
      this.lblNotTested7.Size = new Size(67, 13);
      this.lblNotTested7.TabIndex = 385;
      this.lblNotTested7.Text = "Not Tested";
      this.lblNotTested18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested18.AutoSize = true;
      this.lblNotTested18.Location = new System.Drawing.Point(661, 401);
      this.lblNotTested18.Name = "lblNotTested18";
      this.lblNotTested18.Size = new Size(67, 13);
      this.lblNotTested18.TabIndex = 396;
      this.lblNotTested18.Text = "Not Tested";
      this.Controls.Add((Control) this.txtMaxCO);
      this.Controls.Add((Control) this.txtMaxCO2);
      this.Controls.Add((Control) this.txtHeatInput);
      this.Controls.Add((Control) this.txtOperatingPressure);
      this.Controls.Add((Control) this.cboSafety);
      this.Controls.Add((Control) this.Label18);
      this.Controls.Add((Control) this.cboServiced);
      this.Controls.Add((Control) this.Label19);
      this.Controls.Add((Control) this.Label15);
      this.Controls.Add((Control) this.Label16);
      this.Controls.Add((Control) this.Label17);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.cboGastight);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.cboFSPFitted);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.cboGasIsolation);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.cboManufactureInfo);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.cboElectricalIsolator);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cboGasHose);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.cboTested);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.cboLLAppliance);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.cboAppliance);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.lblNotTested18);
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
      this.Name = nameof (UCComercialWorksheet);
      this.Size = new Size(789, 462);
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
      Combo.SetUpCombo(ref cboTested, this.DtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTested = cboTested;
      ComboBox cboGasHose = this.cboGasHose;
      Combo.SetUpCombo(ref cboGasHose, this.DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboGasHose = cboGasHose;
      ComboBox electricalIsolator = this.cboElectricalIsolator;
      Combo.SetUpCombo(ref electricalIsolator, this.DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboElectricalIsolator = electricalIsolator;
      ComboBox cboManufactureInfo = this.cboManufactureInfo;
      Combo.SetUpCombo(ref cboManufactureInfo, this.DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboManufactureInfo = cboManufactureInfo;
      ComboBox cboGasIsolation = this.cboGasIsolation;
      Combo.SetUpCombo(ref cboGasIsolation, this.DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboGasIsolation = cboGasIsolation;
      ComboBox cboFspFitted = this.cboFSPFitted;
      Combo.SetUpCombo(ref cboFspFitted, this.DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFSPFitted = cboFspFitted;
      ComboBox cboGastight = this.cboGastight;
      Combo.SetUpCombo(ref cboGastight, this.DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboGastight = cboGastight;
      ComboBox cboServiced = this.cboServiced;
      Combo.SetUpCombo(ref cboServiced, this.DtApplianceServiced, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboServiced = cboServiced;
      ComboBox cboSafety = this.cboSafety;
      Combo.SetUpCombo(ref cboSafety, this.DtYesNoNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSafety = cboSafety;
      this.cboSafety.Items.Add((object) new Combo("Visually Passed", "999999999", (object) null));
    }

    public void Populate(int ID = 0)
    {
      this.txtMaxCO.Text = Conversions.ToString(this.Worksheet.DHWFlowRate);
      this.txtMaxCO2.Text = Conversions.ToString(this.Worksheet.ColdWaterTemp);
      this.txtHeatInput.Text = Conversions.ToString(this.Worksheet.InletStaticPressure);
      this.txtOperatingPressure.Text = Conversions.ToString(this.Worksheet.MaxBurnerPressure);
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboAppliance, Conversions.ToString(this.Worksheet.AssetID));
      this.cboAppliance = cboAppliance;
      ComboBox cboGasHose = this.cboGasHose;
      Combo.SetSelectedComboItem_By_Value(ref cboGasHose, Conversions.ToString(this.Worksheet.FlueFlowTestID));
      this.cboGasHose = cboGasHose;
      ComboBox electricalIsolator = this.cboElectricalIsolator;
      Combo.SetSelectedComboItem_By_Value(ref electricalIsolator, Conversions.ToString(this.Worksheet.SpillageTestID));
      this.cboElectricalIsolator = electricalIsolator;
      ComboBox cboManufactureInfo = this.cboManufactureInfo;
      Combo.SetSelectedComboItem_By_Value(ref cboManufactureInfo, Conversions.ToString(this.Worksheet.FlueTerminationSatisfactoryID));
      this.cboManufactureInfo = cboManufactureInfo;
      ComboBox cboGasIsolation = this.cboGasIsolation;
      Combo.SetSelectedComboItem_By_Value(ref cboGasIsolation, Conversions.ToString(this.Worksheet.VisualConditionOfFlueSatisfactoryID));
      this.cboGasIsolation = cboGasIsolation;
      ComboBox cboFspFitted = this.cboFSPFitted;
      Combo.SetSelectedComboItem_By_Value(ref cboFspFitted, Conversions.ToString(this.Worksheet.VentilationProvisionSatisfactoryID));
      this.cboFSPFitted = cboFspFitted;
      ComboBox cboGastight = this.cboGastight;
      Combo.SetSelectedComboItem_By_Value(ref cboGastight, Conversions.ToString(this.Worksheet.SafetyDeviceOperationID));
      this.cboGastight = cboGastight;
      ComboBox cboServiced = this.cboServiced;
      Combo.SetSelectedComboItem_By_Value(ref cboServiced, Conversions.ToString(this.Worksheet.ApplianceServiceOrInspectedID));
      this.cboServiced = cboServiced;
      ComboBox cboSafety = this.cboSafety;
      Combo.SetSelectedComboItem_By_Value(ref cboSafety, Conversions.ToString(this.Worksheet.ApplianceSafeID));
      this.cboSafety = cboSafety;
      ComboBox cboLlAppliance = this.cboLLAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboLlAppliance, Conversions.ToString(this.Worksheet.LandlordsApplianceID));
      this.cboLLAppliance = cboLlAppliance;
      ComboBox cboTested = this.cboTested;
      Combo.SetSelectedComboItem_By_Value(ref cboTested, Conversions.ToString(this.Worksheet.ApplianceTestedID));
      this.cboTested = cboTested;
      if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboTested), "No", false) > 0U)
        return;
      this.NotTested();
    }

    private void NotTested()
    {
      this.cboGasHose.Visible = false;
      this.cboElectricalIsolator.Visible = false;
      this.cboManufactureInfo.Visible = false;
      this.cboGasIsolation.Visible = false;
      this.cboFSPFitted.Visible = false;
      this.cboGastight.Visible = false;
      this.cboServiced.Visible = false;
      this.txtMaxCO.Visible = false;
      this.txtMaxCO2.Visible = false;
      this.txtHeatInput.Visible = false;
      this.txtOperatingPressure.Visible = false;
    }

    private void Tested()
    {
      this.cboGasHose.Visible = true;
      this.cboElectricalIsolator.Visible = true;
      this.cboManufactureInfo.Visible = true;
      this.cboGasIsolation.Visible = true;
      this.cboFSPFitted.Visible = true;
      this.cboGastight.Visible = true;
      this.cboServiced.Visible = true;
      this.txtMaxCO.Visible = true;
      this.txtMaxCO2.Visible = true;
      this.txtHeatInput.Visible = true;
      this.txtOperatingPressure.Visible = true;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.Worksheet.SetReading = (object) 8;
        this.Worksheet.SetAssetID = (object) Combo.get_GetSelectedItemValue(this.cboAppliance);
        this.Worksheet.SetLandlordsApplianceID = (object) Combo.get_GetSelectedItemValue(this.cboLLAppliance);
        this.Worksheet.SetApplianceTestedID = (object) Combo.get_GetSelectedItemValue(this.cboTested);
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboTested), "No", false) > 0U)
        {
          this.Worksheet.SetFlueFlowTestID = (object) Combo.get_GetSelectedItemValue(this.cboGasHose);
          this.Worksheet.SetSpillageTestID = (object) Combo.get_GetSelectedItemValue(this.cboElectricalIsolator);
          this.Worksheet.SetFlueTerminationSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboManufactureInfo);
          this.Worksheet.SetVisualConditionOfFlueSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboGasIsolation);
          this.Worksheet.SetVentilationProvisionSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboFSPFitted);
          this.Worksheet.SetSafetyDeviceOperationID = (object) Combo.get_GetSelectedItemValue(this.cboGastight);
          this.Worksheet.SetDHWFlowRate = (object) this.txtMaxCO.Text;
          this.Worksheet.SetColdWaterTemp = (object) this.txtMaxCO2.Text;
          this.Worksheet.SetInletStaticPressure = (object) this.txtHeatInput.Text;
          this.Worksheet.SetMaxBurnerPressure = (object) this.txtOperatingPressure.Text;
          this.Worksheet.SetApplianceServiceOrInspectedID = (object) Combo.get_GetSelectedItemValue(this.cboServiced);
        }
        this.Worksheet.SetApplianceSafeID = (object) Combo.get_GetSelectedItemValue(this.cboSafety);
        this.Worksheet.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        new EngineerVisitAssetWorkSheetValidatorComCat().Validate(this.Worksheet, Combo.get_GetSelectedItemDescription(this.cboTested));
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
