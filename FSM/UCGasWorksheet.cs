// Decompiled with JetBrains decompiler
// Type: FSM.UCGasWorksheet
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
  public class UCGasWorksheet : UCBase, IUserControl
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

    public UCGasWorksheet(
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

    internal virtual TextBox txtDHWFlow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtColdTemp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDHWTemp { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHeadInput { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtInletPressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMinBurnerPressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMaxBurnerPressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCO2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCO2Ration { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCO2Min { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCO2Max { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSafety { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboServiced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboDevice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboProvisions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboVisualCondition { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFlueTermination { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFlueSpil { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFlueFlow { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.txtDHWFlow = new TextBox();
      this.txtColdTemp = new TextBox();
      this.txtDHWTemp = new TextBox();
      this.txtHeadInput = new TextBox();
      this.txtInletPressure = new TextBox();
      this.txtMinBurnerPressure = new TextBox();
      this.txtMaxBurnerPressure = new TextBox();
      this.txtCO2 = new TextBox();
      this.txtCO2Ration = new TextBox();
      this.txtCO2Min = new TextBox();
      this.txtCO2Max = new TextBox();
      this.cboSafety = new ComboBox();
      this.Label18 = new Label();
      this.cboServiced = new ComboBox();
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
      this.cboDevice = new ComboBox();
      this.Label7 = new Label();
      this.cboProvisions = new ComboBox();
      this.Label8 = new Label();
      this.cboVisualCondition = new ComboBox();
      this.Label9 = new Label();
      this.cboFlueTermination = new ComboBox();
      this.Label10 = new Label();
      this.cboFlueSpil = new ComboBox();
      this.Label3 = new Label();
      this.cboFlueFlow = new ComboBox();
      this.Label4 = new Label();
      this.cboTested = new ComboBox();
      this.Label5 = new Label();
      this.cboLLAppliance = new ComboBox();
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
      this.SuspendLayout();
      this.txtDHWFlow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtDHWFlow.Location = new System.Drawing.Point(601, 278);
      this.txtDHWFlow.Name = "txtDHWFlow";
      this.txtDHWFlow.Size = new Size(188, 21);
      this.txtDHWFlow.TabIndex = 10;
      this.txtColdTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtColdTemp.Location = new System.Drawing.Point(601, 309);
      this.txtColdTemp.Name = "txtColdTemp";
      this.txtColdTemp.Size = new Size(188, 21);
      this.txtColdTemp.TabIndex = 11;
      this.txtDHWTemp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtDHWTemp.Location = new System.Drawing.Point(601, 339);
      this.txtDHWTemp.Name = "txtDHWTemp";
      this.txtDHWTemp.Size = new Size(188, 21);
      this.txtDHWTemp.TabIndex = 12;
      this.txtHeadInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtHeadInput.Location = new System.Drawing.Point(601, 368);
      this.txtHeadInput.Name = "txtHeadInput";
      this.txtHeadInput.Size = new Size(188, 21);
      this.txtHeadInput.TabIndex = 13;
      this.txtInletPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtInletPressure.Location = new System.Drawing.Point(601, 399);
      this.txtInletPressure.Name = "txtInletPressure";
      this.txtInletPressure.Size = new Size(188, 21);
      this.txtInletPressure.TabIndex = 14;
      this.txtMinBurnerPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtMinBurnerPressure.Location = new System.Drawing.Point(601, 429);
      this.txtMinBurnerPressure.Name = "txtMinBurnerPressure";
      this.txtMinBurnerPressure.Size = new Size(188, 21);
      this.txtMinBurnerPressure.TabIndex = 15;
      this.txtMaxBurnerPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtMaxBurnerPressure.Location = new System.Drawing.Point(601, 458);
      this.txtMaxBurnerPressure.Name = "txtMaxBurnerPressure";
      this.txtMaxBurnerPressure.Size = new Size(188, 21);
      this.txtMaxBurnerPressure.TabIndex = 16;
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
      this.Label18.AutoSize = true;
      this.Label18.Location = new System.Drawing.Point(3, 641);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(101, 13);
      this.Label18.TabIndex = 365;
      this.Label18.Text = "Appliance safety";
      this.cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboServiced.Location = new System.Drawing.Point(601, 608);
      this.cboServiced.Name = "cboServiced";
      this.cboServiced.Size = new Size(188, 21);
      this.cboServiced.TabIndex = 21;
      this.Label19.AutoSize = true;
      this.Label19.Location = new System.Drawing.Point(3, 611);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(181, 13);
      this.Label19.TabIndex = 363;
      this.Label19.Text = "Appliance service or inspected";
      this.Label20.AutoSize = true;
      this.Label20.Location = new System.Drawing.Point(3, 581);
      this.Label20.Name = "Label20";
      this.Label20.Size = new Size(61, 13);
      this.Label20.TabIndex = 361;
      this.Label20.Text = "CO2 max";
      this.Label21.AutoSize = true;
      this.Label21.Location = new System.Drawing.Point(3, 552);
      this.Label21.Name = "Label21";
      this.Label21.Size = new Size(57, 13);
      this.Label21.TabIndex = 360;
      this.Label21.Text = "CO2 min";
      this.Label22.AutoSize = true;
      this.Label22.Location = new System.Drawing.Point(3, 522);
      this.Label22.Name = "Label22";
      this.Label22.Size = new Size(123, 13);
      this.Label22.TabIndex = 359;
      this.Label22.Text = "CO2 / co ration high";
      this.Label11.AutoSize = true;
      this.Label11.Location = new System.Drawing.Point(30, 608);
      this.Label11.Name = "Label11";
      this.Label11.Size = new Size(32, 13);
      this.Label11.TabIndex = 358;
      this.Label11.Text = "CO2";
      this.Label12.AutoSize = true;
      this.Label12.Location = new System.Drawing.Point(3, 461);
      this.Label12.Name = "Label12";
      this.Label12.Size = new Size(126, 13);
      this.Label12.TabIndex = 357;
      this.Label12.Text = "Max burner pressure";
      this.Label13.AutoSize = true;
      this.Label13.Location = new System.Drawing.Point(3, 431);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(122, 13);
      this.Label13.TabIndex = 356;
      this.Label13.Text = "Min burner pressure";
      this.Label14.AutoSize = true;
      this.Label14.Location = new System.Drawing.Point(3, 402);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(136, 13);
      this.Label14.TabIndex = 355;
      this.Label14.Text = "Inlet working pressure";
      this.Label15.AutoSize = true;
      this.Label15.Location = new System.Drawing.Point(3, 372);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(68, 13);
      this.Label15.TabIndex = 354;
      this.Label15.Text = "Head input";
      this.Label16.AutoSize = true;
      this.Label16.Location = new System.Drawing.Point(3, 342);
      this.Label16.Name = "Label16";
      this.Label16.Size = new Size(68, 13);
      this.Label16.TabIndex = 353;
      this.Label16.Text = "DHW temp";
      this.Label17.AutoSize = true;
      this.Label17.Location = new System.Drawing.Point(3, 312);
      this.Label17.Name = "Label17";
      this.Label17.Size = new Size(102, 13);
      this.Label17.TabIndex = 352;
      this.Label17.Text = "Cold water temp";
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(3, 281);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(89, 13);
      this.Label6.TabIndex = 351;
      this.Label6.Text = "DHW flow rate";
      this.cboDevice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboDevice.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDevice.Location = new System.Drawing.Point(601, 248);
      this.cboDevice.Name = "cboDevice";
      this.cboDevice.Size = new Size(188, 21);
      this.cboDevice.TabIndex = 9;
      this.Label7.AutoSize = true;
      this.Label7.Location = new System.Drawing.Point(3, 251);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(143, 13);
      this.Label7.TabIndex = 350;
      this.Label7.Text = "Safety device operation";
      this.cboProvisions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboProvisions.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboProvisions.Location = new System.Drawing.Point(601, 218);
      this.cboProvisions.Name = "cboProvisions";
      this.cboProvisions.Size = new Size(188, 21);
      this.cboProvisions.TabIndex = 8;
      this.Label8.AutoSize = true;
      this.Label8.Location = new System.Drawing.Point(3, 221);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(192, 13);
      this.Label8.TabIndex = 348;
      this.Label8.Text = "Ventilation provision satisfactory";
      this.cboVisualCondition.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboVisualCondition.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisualCondition.Location = new System.Drawing.Point(601, 189);
      this.cboVisualCondition.Name = "cboVisualCondition";
      this.cboVisualCondition.Size = new Size(188, 21);
      this.cboVisualCondition.TabIndex = 7;
      this.Label9.AutoSize = true;
      this.Label9.Location = new System.Drawing.Point(3, 192);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(141, 13);
      this.Label9.TabIndex = 346;
      this.Label9.Text = "Visual Condition of Flue";
      this.cboFlueTermination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFlueTermination.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFlueTermination.Location = new System.Drawing.Point(601, 159);
      this.cboFlueTermination.Name = "cboFlueTermination";
      this.cboFlueTermination.Size = new Size(188, 21);
      this.cboFlueTermination.TabIndex = 6;
      this.Label10.AutoSize = true;
      this.Label10.Location = new System.Drawing.Point(3, 162);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(171, 13);
      this.Label10.TabIndex = 344;
      this.Label10.Text = "Flue Termination satisfactory";
      this.cboFlueSpil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFlueSpil.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFlueSpil.Location = new System.Drawing.Point(601, 129);
      this.cboFlueSpil.Name = "cboFlueSpil";
      this.cboFlueSpil.Size = new Size(188, 21);
      this.cboFlueSpil.TabIndex = 5;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(3, 132);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(99, 13);
      this.Label3.TabIndex = 342;
      this.Label3.Text = "Flue spilage test";
      this.cboFlueFlow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboFlueFlow.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboFlueFlow.Location = new System.Drawing.Point(601, 99);
      this.cboFlueFlow.Name = "cboFlueFlow";
      this.cboFlueFlow.Size = new Size(188, 21);
      this.cboFlueFlow.TabIndex = 4;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(3, 102);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(84, 13);
      this.Label4.TabIndex = 340;
      this.Label4.Text = "Flue Flow test";
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
      this.Label23.AutoSize = true;
      this.Label23.Location = new System.Drawing.Point(3, 491);
      this.Label23.Name = "Label23";
      this.Label23.Size = new Size(32, 13);
      this.Label23.TabIndex = 378;
      this.Label23.Text = "CO2";
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
      this.lblNotTested12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested12.AutoSize = true;
      this.lblNotTested12.Location = new System.Drawing.Point(661, 431);
      this.lblNotTested12.Name = "lblNotTested12";
      this.lblNotTested12.Size = new Size(67, 13);
      this.lblNotTested12.TabIndex = 390;
      this.lblNotTested12.Text = "Not Tested";
      this.lblNotTested11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested11.AutoSize = true;
      this.lblNotTested11.Location = new System.Drawing.Point(661, 401);
      this.lblNotTested11.Name = "lblNotTested11";
      this.lblNotTested11.Size = new Size(67, 13);
      this.lblNotTested11.TabIndex = 389;
      this.lblNotTested11.Text = "Not Tested";
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
      this.lblNotTested18.Location = new System.Drawing.Point(661, 611);
      this.lblNotTested18.Name = "lblNotTested18";
      this.lblNotTested18.Size = new Size(67, 13);
      this.lblNotTested18.TabIndex = 396;
      this.lblNotTested18.Text = "Not Tested";
      this.lblNotTested17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested17.AutoSize = true;
      this.lblNotTested17.Location = new System.Drawing.Point(661, 581);
      this.lblNotTested17.Name = "lblNotTested17";
      this.lblNotTested17.Size = new Size(67, 13);
      this.lblNotTested17.TabIndex = 395;
      this.lblNotTested17.Text = "Not Tested";
      this.lblNotTested16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested16.AutoSize = true;
      this.lblNotTested16.Location = new System.Drawing.Point(661, 551);
      this.lblNotTested16.Name = "lblNotTested16";
      this.lblNotTested16.Size = new Size(67, 13);
      this.lblNotTested16.TabIndex = 394;
      this.lblNotTested16.Text = "Not Tested";
      this.lblNotTested15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested15.AutoSize = true;
      this.lblNotTested15.Location = new System.Drawing.Point(661, 521);
      this.lblNotTested15.Name = "lblNotTested15";
      this.lblNotTested15.Size = new Size(67, 13);
      this.lblNotTested15.TabIndex = 393;
      this.lblNotTested15.Text = "Not Tested";
      this.lblNotTested14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested14.AutoSize = true;
      this.lblNotTested14.Location = new System.Drawing.Point(661, 491);
      this.lblNotTested14.Name = "lblNotTested14";
      this.lblNotTested14.Size = new Size(67, 13);
      this.lblNotTested14.TabIndex = 392;
      this.lblNotTested14.Text = "Not Tested";
      this.lblNotTested13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested13.AutoSize = true;
      this.lblNotTested13.Location = new System.Drawing.Point(661, 461);
      this.lblNotTested13.Name = "lblNotTested13";
      this.lblNotTested13.Size = new Size(67, 13);
      this.lblNotTested13.TabIndex = 391;
      this.lblNotTested13.Text = "Not Tested";
      this.Controls.Add((Control) this.Label23);
      this.Controls.Add((Control) this.txtDHWFlow);
      this.Controls.Add((Control) this.txtColdTemp);
      this.Controls.Add((Control) this.txtDHWTemp);
      this.Controls.Add((Control) this.txtHeadInput);
      this.Controls.Add((Control) this.txtInletPressure);
      this.Controls.Add((Control) this.txtMinBurnerPressure);
      this.Controls.Add((Control) this.txtMaxBurnerPressure);
      this.Controls.Add((Control) this.txtCO2);
      this.Controls.Add((Control) this.txtCO2Ration);
      this.Controls.Add((Control) this.txtCO2Min);
      this.Controls.Add((Control) this.txtCO2Max);
      this.Controls.Add((Control) this.cboSafety);
      this.Controls.Add((Control) this.Label18);
      this.Controls.Add((Control) this.cboServiced);
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
      this.Controls.Add((Control) this.cboDevice);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.cboProvisions);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.cboVisualCondition);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.cboFlueTermination);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.cboFlueSpil);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cboFlueFlow);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.cboTested);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.cboLLAppliance);
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
      this.Name = nameof (UCGasWorksheet);
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
      ComboBox cboFlueSpil = this.cboFlueSpil;
      Combo.SetUpCombo(ref cboFlueSpil, this.DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFlueSpil = cboFlueSpil;
      ComboBox cboFlueTermination = this.cboFlueTermination;
      Combo.SetUpCombo(ref cboFlueTermination, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboFlueTermination = cboFlueTermination;
      ComboBox cboVisualCondition = this.cboVisualCondition;
      Combo.SetUpCombo(ref cboVisualCondition, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboVisualCondition = cboVisualCondition;
      ComboBox cboProvisions = this.cboProvisions;
      Combo.SetUpCombo(ref cboProvisions, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboProvisions = cboProvisions;
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
    }

    public void Populate(int ID = 0)
    {
      this.txtDHWFlow.Text = Conversions.ToString(this.Worksheet.DHWFlowRate);
      this.txtColdTemp.Text = Conversions.ToString(this.Worksheet.ColdWaterTemp);
      this.txtDHWTemp.Text = Conversions.ToString(this.Worksheet.DHWTemp);
      this.txtHeadInput.Text = Conversions.ToString(this.Worksheet.InletStaticPressure);
      this.txtInletPressure.Text = Conversions.ToString(this.Worksheet.InletWorkingPressure);
      this.txtMinBurnerPressure.Text = Conversions.ToString(this.Worksheet.MinBurnerPressure);
      this.txtMaxBurnerPressure.Text = Conversions.ToString(this.Worksheet.MaxBurnerPressure);
      this.txtCO2.Text = Conversions.ToString(this.Worksheet.CO2);
      this.txtCO2Ration.Text = Conversions.ToString(this.Worksheet.CO2CORatio);
      this.txtCO2Min.Text = this.Worksheet.BMake;
      this.txtCO2Max.Text = this.Worksheet.BModel;
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboAppliance, Conversions.ToString(this.Worksheet.AssetID));
      this.cboAppliance = cboAppliance;
      ComboBox cboFlueFlow = this.cboFlueFlow;
      Combo.SetSelectedComboItem_By_Value(ref cboFlueFlow, Conversions.ToString(this.Worksheet.FlueFlowTestID));
      this.cboFlueFlow = cboFlueFlow;
      ComboBox cboFlueSpil = this.cboFlueSpil;
      Combo.SetSelectedComboItem_By_Value(ref cboFlueSpil, Conversions.ToString(this.Worksheet.SpillageTestID));
      this.cboFlueSpil = cboFlueSpil;
      ComboBox cboFlueTermination = this.cboFlueTermination;
      Combo.SetSelectedComboItem_By_Value(ref cboFlueTermination, Conversions.ToString(this.Worksheet.FlueTerminationSatisfactoryID));
      this.cboFlueTermination = cboFlueTermination;
      ComboBox cboVisualCondition = this.cboVisualCondition;
      Combo.SetSelectedComboItem_By_Value(ref cboVisualCondition, Conversions.ToString(this.Worksheet.VisualConditionOfFlueSatisfactoryID));
      this.cboVisualCondition = cboVisualCondition;
      ComboBox cboProvisions = this.cboProvisions;
      Combo.SetSelectedComboItem_By_Value(ref cboProvisions, Conversions.ToString(this.Worksheet.VentilationProvisionSatisfactoryID));
      this.cboProvisions = cboProvisions;
      ComboBox cboDevice = this.cboDevice;
      Combo.SetSelectedComboItem_By_Value(ref cboDevice, Conversions.ToString(this.Worksheet.SafetyDeviceOperationID));
      this.cboDevice = cboDevice;
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
      this.cboFlueFlow.Visible = false;
      this.cboFlueSpil.Visible = false;
      this.cboFlueTermination.Visible = false;
      this.cboVisualCondition.Visible = false;
      this.cboProvisions.Visible = false;
      this.cboDevice.Visible = false;
      this.cboServiced.Visible = false;
      this.txtDHWFlow.Visible = false;
      this.txtColdTemp.Visible = false;
      this.txtDHWTemp.Visible = false;
      this.txtHeadInput.Visible = false;
      this.txtInletPressure.Visible = false;
      this.txtMinBurnerPressure.Visible = false;
      this.txtMaxBurnerPressure.Visible = false;
      this.txtCO2.Visible = false;
      this.txtCO2Ration.Visible = false;
      this.txtCO2Min.Visible = false;
      this.txtCO2Max.Visible = false;
    }

    private void Tested()
    {
      this.cboFlueFlow.Visible = true;
      this.cboFlueSpil.Visible = true;
      this.cboFlueTermination.Visible = true;
      this.cboVisualCondition.Visible = true;
      this.cboProvisions.Visible = true;
      this.cboDevice.Visible = true;
      this.cboServiced.Visible = true;
      this.txtDHWFlow.Visible = true;
      this.txtColdTemp.Visible = true;
      this.txtDHWTemp.Visible = true;
      this.txtHeadInput.Visible = true;
      this.txtInletPressure.Visible = true;
      this.txtMinBurnerPressure.Visible = true;
      this.txtMaxBurnerPressure.Visible = true;
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
        this.Worksheet.SetReading = (object) 0;
        this.Worksheet.SetAssetID = (object) Combo.get_GetSelectedItemValue(this.cboAppliance);
        this.Worksheet.SetLandlordsApplianceID = (object) Combo.get_GetSelectedItemValue(this.cboLLAppliance);
        this.Worksheet.SetApplianceTestedID = (object) Combo.get_GetSelectedItemValue(this.cboTested);
        if ((uint) Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Combo.get_GetSelectedItemDescription(this.cboTested), "No", false) > 0U)
        {
          this.Worksheet.SetFlueFlowTestID = (object) Combo.get_GetSelectedItemValue(this.cboFlueFlow);
          this.Worksheet.SetSpillageTestID = (object) Combo.get_GetSelectedItemValue(this.cboFlueSpil);
          this.Worksheet.SetFlueTerminationSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboFlueTermination);
          this.Worksheet.SetVisualConditionOfFlueSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboVisualCondition);
          this.Worksheet.SetVentilationProvisionSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboProvisions);
          this.Worksheet.SetSafetyDeviceOperationID = (object) Combo.get_GetSelectedItemValue(this.cboDevice);
          this.Worksheet.SetDHWFlowRate = (object) this.txtDHWFlow.Text;
          this.Worksheet.SetColdWaterTemp = (object) this.txtColdTemp.Text;
          this.Worksheet.SetDHWTemp = (object) this.txtDHWTemp.Text;
          this.Worksheet.SetInletStaticPressure = (object) this.txtHeadInput.Text;
          this.Worksheet.SetInletWorkingPressure = (object) this.txtInletPressure.Text;
          this.Worksheet.SetMinBurnerPressure = (object) this.txtMinBurnerPressure.Text;
          this.Worksheet.SetMaxBurnerPressure = (object) this.txtMaxBurnerPressure.Text;
          this.Worksheet.SetCO2 = (object) this.txtCO2.Text;
          this.Worksheet.SetCO2CORatio = (object) this.txtCO2Ration.Text;
          this.Worksheet.SetBMake = (object) this.txtCO2Min.Text;
          this.Worksheet.SetBModel = (object) this.txtCO2Max.Text;
          this.Worksheet.SetApplianceServiceOrInspectedID = (object) Combo.get_GetSelectedItemValue(this.cboServiced);
        }
        this.Worksheet.SetApplianceSafeID = (object) Combo.get_GetSelectedItemValue(this.cboSafety);
        this.Worksheet.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        new EngineerVisitAssetWorkSheetValidatorGas().Validate(this.Worksheet, Combo.get_GetSelectedItemDescription(this.cboTested));
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
