// Decompiled with JetBrains decompiler
// Type: FSM.UCOilWorksheet
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
  public class UCOilWorksheet : UCBase, IUserControl
  {
    private IContainer components;
    private DataTable DtPassFailNa;
    private DataTable DtNotTestedPassFail;
    private DataTable DtApplianceServiced;
    private DataTable DtYesNo;
    private DataTable DtPassFail;
    private EngineerVisitAssetWorkSheet _Worksheet;
    private EngineerVisit _EngineerVisit;
    private int _jobID;

    public UCOilWorksheet(
      EngineerVisitAssetWorkSheet worksheet,
      int jobID,
      EngineerVisit EngineerVisit)
    {
      this.DtPassFailNa = (DataTable) null;
      this.DtNotTestedPassFail = (DataTable) null;
      this.DtApplianceServiced = (DataTable) null;
      this.DtYesNo = (DataTable) null;
      this.DtPassFail = (DataTable) null;
      this.InitializeComponent();
      this.DtPassFailNa = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA, false).Table;
      this.DtNotTestedPassFail = App.DB.Picklists.GetAll(Enums.PickListTypes.NotTestedPassFailNA, false).Table;
      this.DtApplianceServiced = App.DB.Picklists.GetAll(Enums.PickListTypes.ApplianceServiced, false).Table;
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

    internal virtual TextBox txtSmokeNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEFFNet { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtGasTemp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEFFGross { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInletPressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNozzleSize { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCO2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCO2Ration { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCO2Min { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCO2Max { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSafety { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboServiced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDevice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAirSupply { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboOilPipework { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboOilStorage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboBurner { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFlueFlow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label44 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label24 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label25 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label26 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label27 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label28 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label29 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label30 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label31 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label32 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label33 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label34 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label35 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label36 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label37 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label38 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label39 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label40 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label41 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label42 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label43 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTankType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested17 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested16 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested12 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested11 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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
      this.txtSmokeNo = new TextBox();
      this.txtEFFNet = new TextBox();
      this.txtGasTemp = new TextBox();
      this.txtEFFGross = new TextBox();
      this.txtInletPressure = new TextBox();
      this.txtNozzleSize = new TextBox();
      this.txtCO2 = new TextBox();
      this.txtCO2Ration = new TextBox();
      this.txtCO2Min = new TextBox();
      this.txtCO2Max = new TextBox();
      this.cboSafety = new ComboBox();
      this.cboServiced = new ComboBox();
      this.cboDevice = new ComboBox();
      this.cboAirSupply = new ComboBox();
      this.cboOilPipework = new ComboBox();
      this.cboOilStorage = new ComboBox();
      this.cboBurner = new ComboBox();
      this.cboFlueFlow = new ComboBox();
      this.cboTested = new ComboBox();
      this.cboLLAppliance = new ComboBox();
      this.cboAppliance = new ComboBox();
      this.Label44 = new Label();
      this.Label24 = new Label();
      this.Label25 = new Label();
      this.Label26 = new Label();
      this.Label27 = new Label();
      this.Label28 = new Label();
      this.Label29 = new Label();
      this.Label30 = new Label();
      this.Label31 = new Label();
      this.Label32 = new Label();
      this.Label33 = new Label();
      this.Label34 = new Label();
      this.Label35 = new Label();
      this.Label36 = new Label();
      this.Label37 = new Label();
      this.Label38 = new Label();
      this.Label39 = new Label();
      this.Label40 = new Label();
      this.Label41 = new Label();
      this.Label42 = new Label();
      this.Label43 = new Label();
      this.Label2 = new Label();
      this.cboTankType = new ComboBox();
      this.lblNotTested18 = new Label();
      this.lblNotTested17 = new Label();
      this.lblNotTested16 = new Label();
      this.lblNotTested15 = new Label();
      this.lblNotTested14 = new Label();
      this.lblNotTested13 = new Label();
      this.lblNotTested12 = new Label();
      this.lblNotTested11 = new Label();
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
      this.txtSmokeNo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtSmokeNo.Location = new System.Drawing.Point(601, 278);
      this.txtSmokeNo.Name = "txtSmokeNo";
      this.txtSmokeNo.Size = new Size(188, 21);
      this.txtSmokeNo.TabIndex = 10;
      this.txtEFFNet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtEFFNet.Location = new System.Drawing.Point(601, 309);
      this.txtEFFNet.Name = "txtEFFNet";
      this.txtEFFNet.Size = new Size(188, 21);
      this.txtEFFNet.TabIndex = 11;
      this.txtGasTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtGasTemp.Location = new System.Drawing.Point(601, 339);
      this.txtGasTemp.Name = "txtGasTemp";
      this.txtGasTemp.Size = new Size(188, 21);
      this.txtGasTemp.TabIndex = 12;
      this.txtEFFGross.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtEFFGross.Location = new System.Drawing.Point(601, 368);
      this.txtEFFGross.Name = "txtEFFGross";
      this.txtEFFGross.Size = new Size(188, 21);
      this.txtEFFGross.TabIndex = 13;
      this.txtInletPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInletPressure.Location = new System.Drawing.Point(601, 399);
      this.txtInletPressure.Name = "txtInletPressure";
      this.txtInletPressure.Size = new Size(188, 21);
      this.txtInletPressure.TabIndex = 14;
      this.txtNozzleSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtNozzleSize.Location = new System.Drawing.Point(601, 429);
      this.txtNozzleSize.Name = "txtNozzleSize";
      this.txtNozzleSize.Size = new Size(188, 21);
      this.txtNozzleSize.TabIndex = 15;
      this.txtCO2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtCO2.Location = new System.Drawing.Point(601, 488);
      this.txtCO2.Name = "txtCO2";
      this.txtCO2.Size = new Size(188, 21);
      this.txtCO2.TabIndex = 17;
      this.txtCO2Ration.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtCO2Ration.Location = new System.Drawing.Point(601, 519);
      this.txtCO2Ration.Name = "txtCO2Ration";
      this.txtCO2Ration.Size = new Size(188, 21);
      this.txtCO2Ration.TabIndex = 18;
      this.txtCO2Min.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtCO2Min.Location = new System.Drawing.Point(601, 549);
      this.txtCO2Min.Name = "txtCO2Min";
      this.txtCO2Min.Size = new Size(188, 21);
      this.txtCO2Min.TabIndex = 19;
      this.txtCO2Max.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtCO2Max.Location = new System.Drawing.Point(601, 578);
      this.txtCO2Max.Name = "txtCO2Max";
      this.txtCO2Max.Size = new Size(188, 21);
      this.txtCO2Max.TabIndex = 20;
      this.cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSafety.Location = new System.Drawing.Point(601, 638);
      this.cboSafety.Name = "cboSafety";
      this.cboSafety.Size = new Size(188, 21);
      this.cboSafety.TabIndex = 22;
      this.cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboServiced.Location = new System.Drawing.Point(601, 608);
      this.cboServiced.Name = "cboServiced";
      this.cboServiced.Size = new Size(188, 21);
      this.cboServiced.TabIndex = 21;
      this.cboDevice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboDevice.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDevice.Location = new System.Drawing.Point(601, 248);
      this.cboDevice.Name = "cboDevice";
      this.cboDevice.Size = new Size(188, 21);
      this.cboDevice.TabIndex = 9;
      this.cboAirSupply.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboAirSupply.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboAirSupply.Location = new System.Drawing.Point(601, 218);
      this.cboAirSupply.Name = "cboAirSupply";
      this.cboAirSupply.Size = new Size(188, 21);
      this.cboAirSupply.TabIndex = 8;
      this.cboOilPipework.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboOilPipework.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboOilPipework.Location = new System.Drawing.Point(601, 189);
      this.cboOilPipework.Name = "cboOilPipework";
      this.cboOilPipework.Size = new Size(188, 21);
      this.cboOilPipework.TabIndex = 7;
      this.cboOilStorage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboOilStorage.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboOilStorage.Location = new System.Drawing.Point(601, 159);
      this.cboOilStorage.Name = "cboOilStorage";
      this.cboOilStorage.Size = new Size(188, 21);
      this.cboOilStorage.TabIndex = 6;
      this.cboBurner.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboBurner.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboBurner.Location = new System.Drawing.Point(601, 129);
      this.cboBurner.Name = "cboBurner";
      this.cboBurner.Size = new Size(188, 21);
      this.cboBurner.TabIndex = 5;
      this.cboFlueFlow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFlueFlow.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFlueFlow.Location = new System.Drawing.Point(601, 99);
      this.cboFlueFlow.Name = "cboFlueFlow";
      this.cboFlueFlow.Size = new Size(188, 21);
      this.cboFlueFlow.TabIndex = 4;
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
      this.Label44.AutoSize = true;
      this.Label44.Location = new System.Drawing.Point(3, 491);
      this.Label44.Name = "Label44";
      this.Label44.Size = new Size(48, 13);
      this.Label44.TabIndex = 443;
      this.Label44.Text = "CO2 %";
      this.Label24.AutoSize = true;
      this.Label24.Location = new System.Drawing.Point(3, 641);
      this.Label24.Name = "Label24";
      this.Label24.Size = new Size(101, 13);
      this.Label24.TabIndex = 442;
      this.Label24.Text = "Appliance safety";
      this.Label25.AutoSize = true;
      this.Label25.Location = new System.Drawing.Point(3, 611);
      this.Label25.Name = "Label25";
      this.Label25.Size = new Size(181, 13);
      this.Label25.TabIndex = 441;
      this.Label25.Text = "Appliance service or inspected";
      this.Label26.AutoSize = true;
      this.Label26.Location = new System.Drawing.Point(3, 581);
      this.Label26.Name = "Label26";
      this.Label26.Size = new Size(61, 13);
      this.Label26.TabIndex = 440;
      this.Label26.Text = "CO2 max";
      this.Label27.AutoSize = true;
      this.Label27.Location = new System.Drawing.Point(3, 552);
      this.Label27.Name = "Label27";
      this.Label27.Size = new Size(57, 13);
      this.Label27.TabIndex = 439;
      this.Label27.Text = "CO2 min";
      this.Label28.AutoSize = true;
      this.Label28.Location = new System.Drawing.Point(3, 522);
      this.Label28.Name = "Label28";
      this.Label28.Size = new Size(54, 13);
      this.Label28.TabIndex = 438;
      this.Label28.Text = "CO ppm";
      this.Label29.AutoSize = true;
      this.Label29.Location = new System.Drawing.Point(3, 461);
      this.Label29.Name = "Label29";
      this.Label29.Size = new Size(63, 13);
      this.Label29.TabIndex = 437;
      this.Label29.Text = "Tank type";
      this.Label30.AutoSize = true;
      this.Label30.Location = new System.Drawing.Point(3, 431);
      this.Label30.Name = "Label30";
      this.Label30.Size = new Size(70, 13);
      this.Label30.TabIndex = 436;
      this.Label30.Text = "Nozzle size";
      this.Label31.AutoSize = true;
      this.Label31.Location = new System.Drawing.Point(3, 402);
      this.Label31.Name = "Label31";
      this.Label31.Size = new Size(117, 13);
      this.Label31.TabIndex = 435;
      this.Label31.Text = "Pump pressure PSI";
      this.Label32.AutoSize = true;
      this.Label32.Location = new System.Drawing.Point(3, 372);
      this.Label32.Name = "Label32";
      this.Label32.Size = new Size(75, 13);
      this.Label32.TabIndex = 434;
      this.Label32.Text = "Eff Gross %";
      this.Label33.AutoSize = true;
      this.Label33.Location = new System.Drawing.Point(3, 342);
      this.Label33.Name = "Label33";
      this.Label33.Size = new Size(117, 13);
      this.Label33.TabIndex = 433;
      this.Label33.Text = "Flue Gas temp cent";
      this.Label34.AutoSize = true;
      this.Label34.Location = new System.Drawing.Point(3, 312);
      this.Label34.Name = "Label34";
      this.Label34.Size = new Size(65, 13);
      this.Label34.TabIndex = 432;
      this.Label34.Text = "EFF Net %";
      this.Label35.AutoSize = true;
      this.Label35.Location = new System.Drawing.Point(3, 281);
      this.Label35.Name = "Label35";
      this.Label35.Size = new Size(70, 13);
      this.Label35.TabIndex = 431;
      this.Label35.Text = "Smoke No ";
      this.Label36.AutoSize = true;
      this.Label36.Location = new System.Drawing.Point(3, 251);
      this.Label36.Name = "Label36";
      this.Label36.Size = new Size(143, 13);
      this.Label36.TabIndex = 430;
      this.Label36.Text = "Safety device operation";
      this.Label37.AutoSize = true;
      this.Label37.Location = new System.Drawing.Point(3, 221);
      this.Label37.Name = "Label37";
      this.Label37.Size = new Size(64, 13);
      this.Label37.TabIndex = 429;
      this.Label37.Text = "Air supply";
      this.Label38.AutoSize = true;
      this.Label38.Location = new System.Drawing.Point(3, 192);
      this.Label38.Name = "Label38";
      this.Label38.Size = new Size(119, 13);
      this.Label38.TabIndex = 428;
      this.Label38.Text = "Oil supply pipework";
      this.Label39.AutoSize = true;
      this.Label39.Location = new System.Drawing.Point(3, 162);
      this.Label39.Name = "Label39";
      this.Label39.Size = new Size(69, 13);
      this.Label39.TabIndex = 427;
      this.Label39.Text = "Oil storage";
      this.Label40.AutoSize = true;
      this.Label40.Location = new System.Drawing.Point(3, 132);
      this.Label40.Name = "Label40";
      this.Label40.Size = new Size(116, 13);
      this.Label40.TabIndex = 426;
      this.Label40.Text = "Burner satisfactory";
      this.Label41.AutoSize = true;
      this.Label41.Location = new System.Drawing.Point(3, 102);
      this.Label41.Name = "Label41";
      this.Label41.Size = new Size(94, 13);
      this.Label41.TabIndex = 425;
      this.Label41.Text = "Chimney / Flue";
      this.Label42.AutoSize = true;
      this.Label42.Location = new System.Drawing.Point(3, 72);
      this.Label42.Name = "Label42";
      this.Label42.Size = new Size(101, 13);
      this.Label42.TabIndex = 424;
      this.Label42.Text = "Appliance tested";
      this.Label43.AutoSize = true;
      this.Label43.Location = new System.Drawing.Point(3, 43);
      this.Label43.Name = "Label43";
      this.Label43.Size = new Size(125, 13);
      this.Label43.TabIndex = 423;
      this.Label43.Text = "Landlords Appliance ";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(3, 13);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(62, 13);
      this.Label2.TabIndex = 422;
      this.Label2.Text = "Appliance";
      this.cboTankType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboTankType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboTankType.Location = new System.Drawing.Point(601, 458);
      this.cboTankType.Name = "cboTankType";
      this.cboTankType.Size = new Size(188, 21);
      this.cboTankType.TabIndex = 16;
      this.lblNotTested18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested18.AutoSize = true;
      this.lblNotTested18.Location = new System.Drawing.Point(662, 581);
      this.lblNotTested18.Name = "lblNotTested18";
      this.lblNotTested18.Size = new Size(67, 13);
      this.lblNotTested18.TabIndex = 462;
      this.lblNotTested18.Text = "Not Tested";
      this.lblNotTested17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested17.AutoSize = true;
      this.lblNotTested17.Location = new System.Drawing.Point(662, 551);
      this.lblNotTested17.Name = "lblNotTested17";
      this.lblNotTested17.Size = new Size(67, 13);
      this.lblNotTested17.TabIndex = 461;
      this.lblNotTested17.Text = "Not Tested";
      this.lblNotTested16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested16.AutoSize = true;
      this.lblNotTested16.Location = new System.Drawing.Point(662, 521);
      this.lblNotTested16.Name = "lblNotTested16";
      this.lblNotTested16.Size = new Size(67, 13);
      this.lblNotTested16.TabIndex = 460;
      this.lblNotTested16.Text = "Not Tested";
      this.lblNotTested15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested15.AutoSize = true;
      this.lblNotTested15.Location = new System.Drawing.Point(662, 491);
      this.lblNotTested15.Name = "lblNotTested15";
      this.lblNotTested15.Size = new Size(67, 13);
      this.lblNotTested15.TabIndex = 459;
      this.lblNotTested15.Text = "Not Tested";
      this.lblNotTested14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested14.AutoSize = true;
      this.lblNotTested14.Location = new System.Drawing.Point(662, 461);
      this.lblNotTested14.Name = "lblNotTested14";
      this.lblNotTested14.Size = new Size(67, 13);
      this.lblNotTested14.TabIndex = 458;
      this.lblNotTested14.Text = "Not Tested";
      this.lblNotTested13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested13.AutoSize = true;
      this.lblNotTested13.Location = new System.Drawing.Point(662, 431);
      this.lblNotTested13.Name = "lblNotTested13";
      this.lblNotTested13.Size = new Size(67, 13);
      this.lblNotTested13.TabIndex = 457;
      this.lblNotTested13.Text = "Not Tested";
      this.lblNotTested12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested12.AutoSize = true;
      this.lblNotTested12.Location = new System.Drawing.Point(662, 401);
      this.lblNotTested12.Name = "lblNotTested12";
      this.lblNotTested12.Size = new Size(67, 13);
      this.lblNotTested12.TabIndex = 456;
      this.lblNotTested12.Text = "Not Tested";
      this.lblNotTested11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested11.AutoSize = true;
      this.lblNotTested11.Location = new System.Drawing.Point(662, 371);
      this.lblNotTested11.Name = "lblNotTested11";
      this.lblNotTested11.Size = new Size(67, 13);
      this.lblNotTested11.TabIndex = 455;
      this.lblNotTested11.Text = "Not Tested";
      this.lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested10.AutoSize = true;
      this.lblNotTested10.Location = new System.Drawing.Point(662, 341);
      this.lblNotTested10.Name = "lblNotTested10";
      this.lblNotTested10.Size = new Size(67, 13);
      this.lblNotTested10.TabIndex = 454;
      this.lblNotTested10.Text = "Not Tested";
      this.lblNotTested9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested9.AutoSize = true;
      this.lblNotTested9.Location = new System.Drawing.Point(662, 311);
      this.lblNotTested9.Name = "lblNotTested9";
      this.lblNotTested9.Size = new Size(67, 13);
      this.lblNotTested9.TabIndex = 453;
      this.lblNotTested9.Text = "Not Tested";
      this.lblNotTested8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested8.AutoSize = true;
      this.lblNotTested8.Location = new System.Drawing.Point(662, 281);
      this.lblNotTested8.Name = "lblNotTested8";
      this.lblNotTested8.Size = new Size(67, 13);
      this.lblNotTested8.TabIndex = 452;
      this.lblNotTested8.Text = "Not Tested";
      this.lblNotTested7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested7.AutoSize = true;
      this.lblNotTested7.Location = new System.Drawing.Point(662, 251);
      this.lblNotTested7.Name = "lblNotTested7";
      this.lblNotTested7.Size = new Size(67, 13);
      this.lblNotTested7.TabIndex = 451;
      this.lblNotTested7.Text = "Not Tested";
      this.lblNotTested6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested6.AutoSize = true;
      this.lblNotTested6.Location = new System.Drawing.Point(662, 222);
      this.lblNotTested6.Name = "lblNotTested6";
      this.lblNotTested6.Size = new Size(67, 13);
      this.lblNotTested6.TabIndex = 450;
      this.lblNotTested6.Text = "Not Tested";
      this.lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested5.AutoSize = true;
      this.lblNotTested5.Location = new System.Drawing.Point(662, 192);
      this.lblNotTested5.Name = "lblNotTested5";
      this.lblNotTested5.Size = new Size(67, 13);
      this.lblNotTested5.TabIndex = 449;
      this.lblNotTested5.Text = "Not Tested";
      this.lblNotTested4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested4.AutoSize = true;
      this.lblNotTested4.Location = new System.Drawing.Point(662, 162);
      this.lblNotTested4.Name = "lblNotTested4";
      this.lblNotTested4.Size = new Size(67, 13);
      this.lblNotTested4.TabIndex = 448;
      this.lblNotTested4.Text = "Not Tested";
      this.lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested3.AutoSize = true;
      this.lblNotTested3.Location = new System.Drawing.Point(662, 132);
      this.lblNotTested3.Name = "lblNotTested3";
      this.lblNotTested3.Size = new Size(67, 13);
      this.lblNotTested3.TabIndex = 447;
      this.lblNotTested3.Text = "Not Tested";
      this.lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested2.AutoSize = true;
      this.lblNotTested2.Location = new System.Drawing.Point(662, 102);
      this.lblNotTested2.Name = "lblNotTested2";
      this.lblNotTested2.Size = new Size(67, 13);
      this.lblNotTested2.TabIndex = 446;
      this.lblNotTested2.Text = "Not Tested";
      this.lblNotTested1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested1.AutoSize = true;
      this.lblNotTested1.Location = new System.Drawing.Point(662, 72);
      this.lblNotTested1.Name = "lblNotTested1";
      this.lblNotTested1.Size = new Size(67, 13);
      this.lblNotTested1.TabIndex = 445;
      this.lblNotTested1.Text = "Not Tested";
      this.Controls.Add((Control) this.cboTankType);
      this.Controls.Add((Control) this.Label44);
      this.Controls.Add((Control) this.Label24);
      this.Controls.Add((Control) this.Label25);
      this.Controls.Add((Control) this.Label26);
      this.Controls.Add((Control) this.Label27);
      this.Controls.Add((Control) this.Label28);
      this.Controls.Add((Control) this.Label29);
      this.Controls.Add((Control) this.Label30);
      this.Controls.Add((Control) this.Label31);
      this.Controls.Add((Control) this.Label32);
      this.Controls.Add((Control) this.Label33);
      this.Controls.Add((Control) this.Label34);
      this.Controls.Add((Control) this.Label35);
      this.Controls.Add((Control) this.Label36);
      this.Controls.Add((Control) this.Label37);
      this.Controls.Add((Control) this.Label38);
      this.Controls.Add((Control) this.Label39);
      this.Controls.Add((Control) this.Label40);
      this.Controls.Add((Control) this.Label41);
      this.Controls.Add((Control) this.Label42);
      this.Controls.Add((Control) this.Label43);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.txtSmokeNo);
      this.Controls.Add((Control) this.txtEFFNet);
      this.Controls.Add((Control) this.txtGasTemp);
      this.Controls.Add((Control) this.txtEFFGross);
      this.Controls.Add((Control) this.txtInletPressure);
      this.Controls.Add((Control) this.txtNozzleSize);
      this.Controls.Add((Control) this.txtCO2);
      this.Controls.Add((Control) this.txtCO2Ration);
      this.Controls.Add((Control) this.txtCO2Min);
      this.Controls.Add((Control) this.txtCO2Max);
      this.Controls.Add((Control) this.cboSafety);
      this.Controls.Add((Control) this.cboServiced);
      this.Controls.Add((Control) this.cboDevice);
      this.Controls.Add((Control) this.cboAirSupply);
      this.Controls.Add((Control) this.cboOilPipework);
      this.Controls.Add((Control) this.cboOilStorage);
      this.Controls.Add((Control) this.cboBurner);
      this.Controls.Add((Control) this.cboFlueFlow);
      this.Controls.Add((Control) this.cboTested);
      this.Controls.Add((Control) this.cboLLAppliance);
      this.Controls.Add((Control) this.cboAppliance);
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
      this.Name = nameof (UCOilWorksheet);
      this.Size = new Size(789, 666);
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
      Combo.SetUpCombo(ref cboTested, App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNATab, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboTested = cboTested;
      ComboBox cboFlueFlow = this.cboFlueFlow;
      Combo.SetUpCombo(ref cboFlueFlow, this.DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFlueFlow = cboFlueFlow;
      ComboBox cboBurner = this.cboBurner;
      Combo.SetUpCombo(ref cboBurner, this.DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboBurner = cboBurner;
      ComboBox cboOilStorage = this.cboOilStorage;
      Combo.SetUpCombo(ref cboOilStorage, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboOilStorage = cboOilStorage;
      ComboBox cboOilPipework = this.cboOilPipework;
      Combo.SetUpCombo(ref cboOilPipework, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboOilPipework = cboOilPipework;
      ComboBox cboAirSupply = this.cboAirSupply;
      Combo.SetUpCombo(ref cboAirSupply, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboAirSupply = cboAirSupply;
      ComboBox cboDevice = this.cboDevice;
      Combo.SetUpCombo(ref cboDevice, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboDevice = cboDevice;
      ComboBox cboServiced = this.cboServiced;
      Combo.SetUpCombo(ref cboServiced, this.DtApplianceServiced, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboServiced = cboServiced;
      ComboBox cboSafety = this.cboSafety;
      Combo.SetUpCombo(ref cboSafety, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSafety = cboSafety;
      this.cboSafety.Items.Add((object) new Combo("Visually Passed", "999999999", (object) null));
      ComboBox cboTankType = this.cboTankType;
      Combo.SetUpCombo(ref cboTankType, DynamicDataTables.TankType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboTankType = cboTankType;
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
      ComboBox cboFlueFlow = this.cboFlueFlow;
      Combo.SetSelectedComboItem_By_Value(ref cboFlueFlow, Conversions.ToString(this.Worksheet.FlueFlowTestID));
      this.cboFlueFlow = cboFlueFlow;
      ComboBox cboBurner = this.cboBurner;
      Combo.SetSelectedComboItem_By_Value(ref cboBurner, Conversions.ToString(this.Worksheet.SpillageTestID));
      this.cboBurner = cboBurner;
      ComboBox cboOilStorage = this.cboOilStorage;
      Combo.SetSelectedComboItem_By_Value(ref cboOilStorage, Conversions.ToString(this.Worksheet.FlueTerminationSatisfactoryID));
      this.cboOilStorage = cboOilStorage;
      ComboBox cboOilPipework = this.cboOilPipework;
      Combo.SetSelectedComboItem_By_Value(ref cboOilPipework, Conversions.ToString(this.Worksheet.VisualConditionOfFlueSatisfactoryID));
      this.cboOilPipework = cboOilPipework;
      ComboBox cboAirSupply = this.cboAirSupply;
      Combo.SetSelectedComboItem_By_Value(ref cboAirSupply, Conversions.ToString(this.Worksheet.VentilationProvisionSatisfactoryID));
      this.cboAirSupply = cboAirSupply;
      ComboBox cboDevice = this.cboDevice;
      Combo.SetSelectedComboItem_By_Value(ref cboDevice, Conversions.ToString(this.Worksheet.SafetyDeviceOperationID));
      this.cboDevice = cboDevice;
      this.txtSmokeNo.Text = Conversions.ToString(this.Worksheet.DHWFlowRate);
      this.txtEFFNet.Text = Conversions.ToString(this.Worksheet.ColdWaterTemp);
      this.txtGasTemp.Text = Conversions.ToString(this.Worksheet.DHWTemp);
      this.txtEFFGross.Text = Conversions.ToString(this.Worksheet.InletStaticPressure);
      this.txtInletPressure.Text = Conversions.ToString(this.Worksheet.InletWorkingPressure);
      this.txtNozzleSize.Text = this.Worksheet.Nozzle;
      ComboBox cboTankType = this.cboTankType;
      Combo.SetSelectedComboItem_By_Value(ref cboTankType, Conversions.ToString(this.Worksheet.TankID));
      this.cboTankType = cboTankType;
      this.txtCO2.Text = Conversions.ToString(this.Worksheet.CO2);
      this.txtCO2Ration.Text = Conversions.ToString(this.Worksheet.CO2CORatio);
      this.txtCO2Min.Text = this.Worksheet.BMake;
      this.txtCO2Max.Text = this.Worksheet.BModel;
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
      this.cboFlueFlow.Visible = false;
      this.cboBurner.Visible = false;
      this.cboOilStorage.Visible = false;
      this.cboOilPipework.Visible = false;
      this.cboAirSupply.Visible = false;
      this.cboDevice.Visible = false;
      this.cboServiced.Visible = false;
      this.cboTankType.Visible = false;
      this.txtSmokeNo.Visible = false;
      this.txtEFFNet.Visible = false;
      this.txtGasTemp.Visible = false;
      this.txtEFFGross.Visible = false;
      this.txtInletPressure.Visible = false;
      this.txtNozzleSize.Visible = false;
      this.txtCO2.Visible = false;
      this.txtCO2Ration.Visible = false;
      this.txtCO2Min.Visible = false;
      this.txtCO2Max.Visible = false;
    }

    private void Tested()
    {
      this.cboFlueFlow.Visible = true;
      this.cboBurner.Visible = true;
      this.cboOilStorage.Visible = true;
      this.cboOilPipework.Visible = true;
      this.cboAirSupply.Visible = true;
      this.cboDevice.Visible = true;
      this.cboServiced.Visible = true;
      this.cboTankType.Visible = true;
      this.txtSmokeNo.Visible = true;
      this.txtEFFNet.Visible = true;
      this.txtGasTemp.Visible = true;
      this.txtEFFGross.Visible = true;
      this.txtInletPressure.Visible = true;
      this.txtNozzleSize.Visible = true;
      this.txtCO2.Visible = true;
      this.txtCO2Ration.Visible = true;
      this.txtCO2Min.Visible = true;
      this.txtCO2Max.Visible = true;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.Worksheet.SetReading = (object) 1;
        this.Worksheet.SetAssetID = (object) Combo.get_GetSelectedItemValue(this.cboAppliance);
        this.Worksheet.SetLandlordsApplianceID = (object) Combo.get_GetSelectedItemValue(this.cboLLAppliance);
        this.Worksheet.SetApplianceTestedID = (object) Combo.get_GetSelectedItemValue(this.cboTested);
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboTested), "No", false) > 0U)
        {
          this.Worksheet.SetFlueFlowTestID = (object) Combo.get_GetSelectedItemValue(this.cboFlueFlow);
          this.Worksheet.SetSpillageTestID = (object) Combo.get_GetSelectedItemValue(this.cboBurner);
          this.Worksheet.SetFlueTerminationSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboOilStorage);
          this.Worksheet.SetVisualConditionOfFlueSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboOilPipework);
          this.Worksheet.SetVentilationProvisionSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboAirSupply);
          this.Worksheet.SetSafetyDeviceOperationID = (object) Combo.get_GetSelectedItemValue(this.cboDevice);
          this.Worksheet.SetTankID = (object) Combo.get_GetSelectedItemValue(this.cboTankType);
          this.Worksheet.SetNozzle = (object) this.txtNozzleSize.Text;
          this.Worksheet.SetDHWFlowRate = (object) this.txtSmokeNo.Text;
          this.Worksheet.SetColdWaterTemp = (object) this.txtEFFNet.Text;
          this.Worksheet.SetDHWTemp = (object) this.txtGasTemp.Text;
          this.Worksheet.SetInletStaticPressure = (object) this.txtEFFGross.Text;
          this.Worksheet.SetInletWorkingPressure = (object) this.txtInletPressure.Text;
          this.Worksheet.SetCO2 = (object) this.txtCO2.Text;
          this.Worksheet.SetCO2CORatio = (object) this.txtCO2Ration.Text;
          this.Worksheet.SetBMake = (object) this.txtCO2Min.Text;
          this.Worksheet.SetBModel = (object) this.txtCO2Max.Text;
          this.Worksheet.SetApplianceServiceOrInspectedID = (object) Combo.get_GetSelectedItemValue(this.cboServiced);
        }
        this.Worksheet.SetApplianceSafeID = (object) Combo.get_GetSelectedItemValue(this.cboSafety);
        this.Worksheet.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        new EngineerVisitAssetWorkSheetValidatorOil().Validate(this.Worksheet, Combo.get_GetSelectedItemDescription(this.cboTested));
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
