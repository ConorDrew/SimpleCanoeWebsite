// Decompiled with JetBrains decompiler
// Type: FSM.UCHIUWorksheet
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
  public class UCHIUWorksheet : UCBase, IUserControl
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

    public UCHIUWorksheet(
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

    internal virtual TextBox txtResults { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSafety { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboServiced { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label19 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSystemOperation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInspectPumps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCleanStrainers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboCleanPortValue { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLeaksPressure { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboLLAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboAppliance { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested10 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotTested18 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.txtResults = new TextBox();
      this.cboSafety = new ComboBox();
      this.Label18 = new Label();
      this.cboServiced = new ComboBox();
      this.Label19 = new Label();
      this.Label15 = new Label();
      this.cboSystemOperation = new ComboBox();
      this.Label8 = new Label();
      this.cboInspectPumps = new ComboBox();
      this.Label9 = new Label();
      this.cboCleanStrainers = new ComboBox();
      this.Label10 = new Label();
      this.cboCleanPortValue = new ComboBox();
      this.Label3 = new Label();
      this.cboLeaksPressure = new ComboBox();
      this.Label4 = new Label();
      this.cboLLAppliance = new ComboBox();
      this.Label2 = new Label();
      this.cboAppliance = new ComboBox();
      this.Label1 = new Label();
      this.lblNotTested1 = new Label();
      this.lblNotTested2 = new Label();
      this.lblNotTested3 = new Label();
      this.lblNotTested5 = new Label();
      this.lblNotTested4 = new Label();
      this.lblNotTested10 = new Label();
      this.lblNotTested18 = new Label();
      this.SuspendLayout();
      this.txtResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.txtResults.Location = new System.Drawing.Point(601, 259);
      this.txtResults.Name = "txtResults";
      this.txtResults.Size = new Size(188, 21);
      this.txtResults.TabIndex = 13;
      this.cboSafety.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSafety.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSafety.Location = new System.Drawing.Point(601, 330);
      this.cboSafety.Name = "cboSafety";
      this.cboSafety.Size = new Size(188, 21);
      this.cboSafety.TabIndex = 22;
      this.Label18.AutoSize = true;
      this.Label18.Location = new System.Drawing.Point(3, 333);
      this.Label18.Name = "Label18";
      this.Label18.Size = new Size(101, 13);
      this.Label18.TabIndex = 365;
      this.Label18.Text = "Appliance safety";
      this.cboServiced.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboServiced.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboServiced.Location = new System.Drawing.Point(601, 294);
      this.cboServiced.Name = "cboServiced";
      this.cboServiced.Size = new Size(188, 21);
      this.cboServiced.TabIndex = 21;
      this.Label19.AutoSize = true;
      this.Label19.Location = new System.Drawing.Point(3, 297);
      this.Label19.Name = "Label19";
      this.Label19.Size = new Size(181, 13);
      this.Label19.TabIndex = 363;
      this.Label19.Text = "Appliance service or inspected";
      this.Label15.AutoSize = true;
      this.Label15.Location = new System.Drawing.Point(3, 263);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(103, 13);
      this.Label15.TabIndex = 354;
      this.Label15.Text = "Recorded results";
      this.cboSystemOperation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboSystemOperation.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboSystemOperation.Location = new System.Drawing.Point(601, 222);
      this.cboSystemOperation.Name = "cboSystemOperation";
      this.cboSystemOperation.Size = new Size(188, 21);
      this.cboSystemOperation.TabIndex = 8;
      this.Label8.AutoSize = true;
      this.Label8.Location = new System.Drawing.Point(3, 225);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(376, 13);
      this.Label8.TabIndex = 348;
      this.Label8.Text = "Check the system operation parameters and record your results";
      this.cboInspectPumps.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboInspectPumps.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInspectPumps.Location = new System.Drawing.Point(601, 187);
      this.cboInspectPumps.Name = "cboInspectPumps";
      this.cboInspectPumps.Size = new Size(188, 21);
      this.cboInspectPumps.TabIndex = 7;
      this.Label9.AutoSize = true;
      this.Label9.Location = new System.Drawing.Point(3, 190);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(223, 13);
      this.Label9.TabIndex = 346;
      this.Label9.Text = "Inspect the functionality of the pumps";
      this.cboCleanStrainers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboCleanStrainers.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCleanStrainers.Location = new System.Drawing.Point(601, 152);
      this.cboCleanStrainers.Name = "cboCleanStrainers";
      this.cboCleanStrainers.Size = new Size(188, 21);
      this.cboCleanStrainers.TabIndex = 6;
      this.Label10.AutoSize = true;
      this.Label10.Location = new System.Drawing.Point(3, 155);
      this.Label10.Name = "Label10";
      this.Label10.Size = new Size(178, 13);
      this.Label10.TabIndex = 344;
      this.Label10.Text = "Check and clean the strainers";
      this.cboCleanPortValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboCleanPortValue.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboCleanPortValue.Location = new System.Drawing.Point(601, 117);
      this.cboCleanPortValue.Name = "cboCleanPortValue";
      this.cboCleanPortValue.Size = new Size(188, 21);
      this.cboCleanPortValue.TabIndex = 5;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(3, 120);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(192, 13);
      this.Label3.TabIndex = 342;
      this.Label3.Text = "Check and clean the port valves";
      this.cboLeaksPressure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboLeaksPressure.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLeaksPressure.Location = new System.Drawing.Point(601, 82);
      this.cboLeaksPressure.Name = "cboLeaksPressure";
      this.cboLeaksPressure.Size = new Size(188, 21);
      this.cboLeaksPressure.TabIndex = 4;
      this.Label4.Location = new System.Drawing.Point(3, 85);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(492, 30);
      this.Label4.TabIndex = 340;
      this.Label4.Text = "Check for leaks and pressure drops in both the primary and secondary sides of the heading exchanger";
      this.cboLLAppliance.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboLLAppliance.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboLLAppliance.Location = new System.Drawing.Point(601, 45);
      this.cboLLAppliance.Name = "cboLLAppliance";
      this.cboLLAppliance.Size = new Size(188, 21);
      this.cboLLAppliance.TabIndex = 2;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(3, 48);
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
      this.lblNotTested1.Location = new System.Drawing.Point(661, 85);
      this.lblNotTested1.Name = "lblNotTested1";
      this.lblNotTested1.Size = new Size(67, 13);
      this.lblNotTested1.TabIndex = 379;
      this.lblNotTested1.Text = "Not Tested";
      this.lblNotTested2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested2.AutoSize = true;
      this.lblNotTested2.Location = new System.Drawing.Point(661, 120);
      this.lblNotTested2.Name = "lblNotTested2";
      this.lblNotTested2.Size = new Size(67, 13);
      this.lblNotTested2.TabIndex = 380;
      this.lblNotTested2.Text = "Not Tested";
      this.lblNotTested3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested3.AutoSize = true;
      this.lblNotTested3.Location = new System.Drawing.Point(661, 155);
      this.lblNotTested3.Name = "lblNotTested3";
      this.lblNotTested3.Size = new Size(67, 13);
      this.lblNotTested3.TabIndex = 381;
      this.lblNotTested3.Text = "Not Tested";
      this.lblNotTested5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested5.AutoSize = true;
      this.lblNotTested5.Location = new System.Drawing.Point(661, 226);
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
      this.lblNotTested10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested10.AutoSize = true;
      this.lblNotTested10.Location = new System.Drawing.Point(661, 262);
      this.lblNotTested10.Name = "lblNotTested10";
      this.lblNotTested10.Size = new Size(67, 13);
      this.lblNotTested10.TabIndex = 388;
      this.lblNotTested10.Text = "Not Tested";
      this.lblNotTested18.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblNotTested18.AutoSize = true;
      this.lblNotTested18.Location = new System.Drawing.Point(661, 297);
      this.lblNotTested18.Name = "lblNotTested18";
      this.lblNotTested18.Size = new Size(67, 13);
      this.lblNotTested18.TabIndex = 396;
      this.lblNotTested18.Text = "Not Tested";
      this.Controls.Add((Control) this.txtResults);
      this.Controls.Add((Control) this.cboSafety);
      this.Controls.Add((Control) this.Label18);
      this.Controls.Add((Control) this.cboServiced);
      this.Controls.Add((Control) this.Label19);
      this.Controls.Add((Control) this.Label15);
      this.Controls.Add((Control) this.cboSystemOperation);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.cboInspectPumps);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.cboCleanStrainers);
      this.Controls.Add((Control) this.Label10);
      this.Controls.Add((Control) this.cboCleanPortValue);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cboLeaksPressure);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.cboLLAppliance);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.cboAppliance);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.lblNotTested18);
      this.Controls.Add((Control) this.lblNotTested10);
      this.Controls.Add((Control) this.lblNotTested5);
      this.Controls.Add((Control) this.lblNotTested4);
      this.Controls.Add((Control) this.lblNotTested3);
      this.Controls.Add((Control) this.lblNotTested2);
      this.Controls.Add((Control) this.lblNotTested1);
      this.Name = nameof (UCHIUWorksheet);
      this.Size = new Size(789, 382);
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
      ComboBox cboLeaksPressure = this.cboLeaksPressure;
      Combo.SetUpCombo(ref cboLeaksPressure, this.DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboLeaksPressure = cboLeaksPressure;
      ComboBox cboCleanPortValue = this.cboCleanPortValue;
      Combo.SetUpCombo(ref cboCleanPortValue, this.DtNotTestedPassFail, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCleanPortValue = cboCleanPortValue;
      ComboBox cboCleanStrainers = this.cboCleanStrainers;
      Combo.SetUpCombo(ref cboCleanStrainers, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboCleanStrainers = cboCleanStrainers;
      ComboBox cboInspectPumps = this.cboInspectPumps;
      Combo.SetUpCombo(ref cboInspectPumps, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboInspectPumps = cboInspectPumps;
      ComboBox cboSystemOperation = this.cboSystemOperation;
      Combo.SetUpCombo(ref cboSystemOperation, this.DtPassFailNa, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboSystemOperation = cboSystemOperation;
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
      ComboBox cboAppliance = this.cboAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboAppliance, Conversions.ToString(this.Worksheet.AssetID));
      this.cboAppliance = cboAppliance;
      ComboBox cboLlAppliance = this.cboLLAppliance;
      Combo.SetSelectedComboItem_By_Value(ref cboLlAppliance, Conversions.ToString(this.Worksheet.LandlordsApplianceID));
      this.cboLLAppliance = cboLlAppliance;
      ComboBox cboLeaksPressure = this.cboLeaksPressure;
      Combo.SetSelectedComboItem_By_Value(ref cboLeaksPressure, Conversions.ToString(this.Worksheet.FlueFlowTestID));
      this.cboLeaksPressure = cboLeaksPressure;
      ComboBox cboCleanPortValue = this.cboCleanPortValue;
      Combo.SetSelectedComboItem_By_Value(ref cboCleanPortValue, Conversions.ToString(this.Worksheet.SpillageTestID));
      this.cboCleanPortValue = cboCleanPortValue;
      ComboBox cboCleanStrainers = this.cboCleanStrainers;
      Combo.SetSelectedComboItem_By_Value(ref cboCleanStrainers, Conversions.ToString(this.Worksheet.FlueTerminationSatisfactoryID));
      this.cboCleanStrainers = cboCleanStrainers;
      ComboBox cboInspectPumps = this.cboInspectPumps;
      Combo.SetSelectedComboItem_By_Value(ref cboInspectPumps, Conversions.ToString(this.Worksheet.VisualConditionOfFlueSatisfactoryID));
      this.cboInspectPumps = cboInspectPumps;
      ComboBox cboSystemOperation = this.cboSystemOperation;
      Combo.SetSelectedComboItem_By_Value(ref cboSystemOperation, Conversions.ToString(this.Worksheet.VentilationProvisionSatisfactoryID));
      this.cboSystemOperation = cboSystemOperation;
      this.txtResults.Text = this.Worksheet.Nozzle;
      ComboBox cboServiced = this.cboServiced;
      Combo.SetSelectedComboItem_By_Value(ref cboServiced, Conversions.ToString(this.Worksheet.ApplianceServiceOrInspectedID));
      this.cboServiced = cboServiced;
      ComboBox cboSafety = this.cboSafety;
      Combo.SetSelectedComboItem_By_Value(ref cboSafety, Conversions.ToString(this.Worksheet.ApplianceSafeID));
      this.cboSafety = cboSafety;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.Worksheet.SetReading = (object) 9;
        this.Worksheet.SetAssetID = (object) Combo.get_GetSelectedItemValue(this.cboAppliance);
        this.Worksheet.SetLandlordsApplianceID = (object) Combo.get_GetSelectedItemValue(this.cboLLAppliance);
        this.Worksheet.SetFlueFlowTestID = (object) Combo.get_GetSelectedItemValue(this.cboLeaksPressure);
        this.Worksheet.SetSpillageTestID = (object) Combo.get_GetSelectedItemValue(this.cboCleanPortValue);
        this.Worksheet.SetFlueTerminationSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboCleanStrainers);
        this.Worksheet.SetVisualConditionOfFlueSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboInspectPumps);
        this.Worksheet.SetVentilationProvisionSatisfactoryID = (object) Combo.get_GetSelectedItemValue(this.cboSystemOperation);
        this.Worksheet.SetNozzle = (object) this.txtResults.Text;
        this.Worksheet.SetApplianceServiceOrInspectedID = (object) Combo.get_GetSelectedItemValue(this.cboServiced);
        this.Worksheet.SetApplianceSafeID = (object) Combo.get_GetSelectedItemValue(this.cboSafety);
        this.Worksheet.SetEngineerVisitID = (object) this.EngineerVisit.EngineerVisitID;
        new EngineerVisitAssetWorkSheetValidatorHIU().Validate(this.Worksheet);
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
