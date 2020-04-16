// Decompiled with JetBrains decompiler
// Type: FSM.DLGVisitAssetWorkSheet
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisitAssetWorkSheets;
using FSM.Entity.EngineerVisits;
using FSM.Entity.Sys;
using FSM.FSMDataSetTableAdapters;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class DLGVisitAssetWorkSheet : FRMBaseForm
  {
    private IContainer components;
    private bool StopChangeTestedDD;
    private object ChildUserInterface;
    private bool _updating;
    private EngineerVisitAssetWorkSheet _Worksheet;
    private EngineerVisit _EngineerVisit;
    private int _jobID;

    public DLGVisitAssetWorkSheet()
    {
      this.Load += new EventHandler(this.DLGVisitAssetWorkSheet_Load);
      this.StopChangeTestedDD = false;
      this.ChildUserInterface = (object) null;
      this._updating = true;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

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

    internal virtual ComboBox ddReading
    {
      get
      {
        return this._ddReading;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ddReading_SelectedIndexChanged);
        ComboBox ddReading1 = this._ddReading;
        if (ddReading1 != null)
          ddReading1.SelectedIndexChanged -= eventHandler;
        this._ddReading = value;
        ComboBox ddReading2 = this._ddReading;
        if (ddReading2 == null)
          return;
        ddReading2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label lblReading { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Panel pnlUCView { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Customer_Get_ForSiteIDTableAdapter Customer_Get_ForSiteIDTableAdapter1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnCancel = new Button();
      this.btnSave = new Button();
      this.Customer_Get_ForSiteIDTableAdapter1 = new Customer_Get_ForSiteIDTableAdapter();
      this.ddReading = new ComboBox();
      this.lblReading = new Label();
      this.pnlUCView = new Panel();
      this.SuspendLayout();
      this.btnCancel.Anchor = AnchorStyles.Bottom;
      this.btnCancel.Location = new System.Drawing.Point(193, 922);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 38;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnSave.Anchor = AnchorStyles.Bottom;
      this.btnSave.Location = new System.Drawing.Point(546, 922);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 39;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.Customer_Get_ForSiteIDTableAdapter1.ClearBeforeFill = true;
      this.ddReading.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.ddReading.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ddReading.Location = new System.Drawing.Point(613, 47);
      this.ddReading.Name = "ddReading";
      this.ddReading.Size = new Size(188, 21);
      this.ddReading.TabIndex = 47;
      this.lblReading.AutoSize = true;
      this.lblReading.Location = new System.Drawing.Point(16, 50);
      this.lblReading.Name = "lblReading";
      this.lblReading.Size = new Size(30, 13);
      this.lblReading.TabIndex = 48;
      this.lblReading.Text = "Fuel";
      this.pnlUCView.AutoSize = true;
      this.pnlUCView.Location = new System.Drawing.Point(12, 77);
      this.pnlUCView.Name = "pnlUCView";
      this.pnlUCView.Size = new Size(789, 100);
      this.pnlUCView.TabIndex = 256;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.AutoSize = true;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.ClientSize = new Size(813, 957);
      this.ControlBox = false;
      this.Controls.Add((Control) this.pnlUCView);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.ddReading);
      this.Controls.Add((Control) this.lblReading);
      this.Name = nameof (DLGVisitAssetWorkSheet);
      this.Text = "Appliance Work Sheet";
      this.Controls.SetChildIndex((Control) this.lblReading, 0);
      this.Controls.SetChildIndex((Control) this.ddReading, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.pnlUCView, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public bool Updating
    {
      get
      {
        return this._updating;
      }
      set
      {
        this._updating = value;
      }
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

    private void DLGVisitAssetWorkSheet_Load(object sender, EventArgs e)
    {
      App.ControlLoading = true;
      ComboBox ddReading1 = this.ddReading;
      Combo.SetUpCombo(ref ddReading1, DynamicDataTables.ReadingType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select_Negative);
      this.ddReading = ddReading1;
      if (!App.loggedInUser.Admin)
      {
        this.btnSave.Enabled = false;
        this.ddReading.Enabled = false;
        this.pnlUCView.Enabled = false;
      }
      if (this.Worksheet != null && (uint) this.Worksheet.EngineerVisitAssetWorkSheetID > 0U)
      {
        ComboBox ddReading2 = this.ddReading;
        Combo.SetSelectedComboItem_By_Value(ref ddReading2, Conversions.ToString(this.Worksheet.Reading));
        this.ddReading = ddReading2;
      }
      this.ShowForm();
      App.ControlLoading = false;
    }

    public void btnSave_Click(object sender, EventArgs e)
    {
      bool flag;
      switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.ddReading)))
      {
        case 0:
          flag = ((UCGasWorksheet) this.ChildUserInterface).Save();
          break;
        case 1:
          flag = ((UCOilWorksheet) this.ChildUserInterface).Save();
          break;
        case 2:
          flag = ((UCSolidWorksheet) this.ChildUserInterface).Save();
          break;
        case 3:
          flag = ((UCUnventedWorksheet) this.ChildUserInterface).Save();
          break;
        case 4:
          flag = ((UCSolarWorksheet) this.ChildUserInterface).Save();
          break;
        case 5:
          flag = ((UCASHPWorksheet) this.ChildUserInterface).Save();
          break;
        case 6:
          flag = ((UCGSHPWorksheet) this.ChildUserInterface).Save();
          break;
        case 7:
          flag = ((UCOtherWorksheet) this.ChildUserInterface).Save();
          break;
        case 8:
          flag = ((UCComercialWorksheet) this.ChildUserInterface).Save();
          break;
        case 9:
          flag = ((UCHIUWorksheet) this.ChildUserInterface).Save();
          break;
      }
      if (!flag)
        return;
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void cboApplianceTested_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ShowForm();
    }

    private void ddReading_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.ShowForm();
    }

    private void ShowForm()
    {
      switch (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.ddReading)))
      {
        case 0:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCGasWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 1:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCOilWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 2:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCSolidWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 3:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCUnventedWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 4:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCSolarWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 5:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCASHPWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 6:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCGSHPWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 7:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCOtherWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 8:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCComercialWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
        case 9:
          this.pnlUCView.Controls.Clear();
          this.ChildUserInterface = (object) new UCHIUWorksheet(this._Worksheet, this._jobID, this._EngineerVisit);
          this.pnlUCView.Controls.Add((Control) this.ChildUserInterface);
          break;
      }
      App.ControlLoading = false;
    }
  }
}
