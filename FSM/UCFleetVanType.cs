// Decompiled with JetBrains decompiler
// Type: FSM.UCFleetVanType
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.FleetVans;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCFleetVanType : UCBase, IUserControl
  {
    private IContainer components;
    private int oldDepartment;
    private FleetVanType _currentVanType;

    public UCFleetVanType()
    {
      this.Load += new EventHandler(this.UCVan_Load);
      this.oldDepartment = 0;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDateIntervals { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDateIntervals { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtModel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblModel { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMake { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMake { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMileageIntervals { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMileageService { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPayload { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPayLoad { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtGrossVehicleWeight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblGrossVehicleWeight { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpVan = new GroupBox();
      this.txtDateIntervals = new TextBox();
      this.lblDateIntervals = new Label();
      this.txtModel = new TextBox();
      this.lblModel = new Label();
      this.txtMake = new TextBox();
      this.lblMake = new Label();
      this.txtMileageIntervals = new TextBox();
      this.lblMileageService = new Label();
      this.txtPayload = new TextBox();
      this.lblPayLoad = new Label();
      this.txtGrossVehicleWeight = new TextBox();
      this.lblGrossVehicleWeight = new Label();
      this.grpVan.SuspendLayout();
      this.SuspendLayout();
      this.grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVan.Controls.Add((Control) this.txtPayload);
      this.grpVan.Controls.Add((Control) this.lblPayLoad);
      this.grpVan.Controls.Add((Control) this.txtGrossVehicleWeight);
      this.grpVan.Controls.Add((Control) this.lblGrossVehicleWeight);
      this.grpVan.Controls.Add((Control) this.txtDateIntervals);
      this.grpVan.Controls.Add((Control) this.lblDateIntervals);
      this.grpVan.Controls.Add((Control) this.txtModel);
      this.grpVan.Controls.Add((Control) this.lblModel);
      this.grpVan.Controls.Add((Control) this.txtMake);
      this.grpVan.Controls.Add((Control) this.lblMake);
      this.grpVan.Controls.Add((Control) this.txtMileageIntervals);
      this.grpVan.Controls.Add((Control) this.lblMileageService);
      this.grpVan.Location = new System.Drawing.Point(12, 13);
      this.grpVan.Name = "grpVan";
      this.grpVan.Size = new Size(554, 146);
      this.grpVan.TabIndex = 3;
      this.grpVan.TabStop = false;
      this.grpVan.Text = "Details";
      this.txtDateIntervals.Location = new System.Drawing.Point(457, 68);
      this.txtDateIntervals.MaxLength = 10;
      this.txtDateIntervals.Name = "txtDateIntervals";
      this.txtDateIntervals.Size = new Size(77, 21);
      this.txtDateIntervals.TabIndex = 4;
      this.lblDateIntervals.Location = new System.Drawing.Point(260, 68);
      this.lblDateIntervals.Name = "lblDateIntervals";
      this.lblDateIntervals.Size = new Size(191, 20);
      this.lblDateIntervals.TabIndex = 51;
      this.lblDateIntervals.Text = "Date Service Intervals (Months)";
      this.txtModel.Location = new System.Drawing.Point(76, 68);
      this.txtModel.MaxLength = 20;
      this.txtModel.Name = "txtModel";
      this.txtModel.Size = new Size(167, 21);
      this.txtModel.TabIndex = 2;
      this.lblModel.Location = new System.Drawing.Point(12, 71);
      this.lblModel.Name = "lblModel";
      this.lblModel.Size = new Size(58, 20);
      this.lblModel.TabIndex = 49;
      this.lblModel.Text = "Model";
      this.txtMake.Location = new System.Drawing.Point(76, 30);
      this.txtMake.MaxLength = 20;
      this.txtMake.Name = "txtMake";
      this.txtMake.Size = new Size(167, 21);
      this.txtMake.TabIndex = 1;
      this.lblMake.Location = new System.Drawing.Point(12, 33);
      this.lblMake.Name = "lblMake";
      this.lblMake.Size = new Size(58, 20);
      this.lblMake.TabIndex = 47;
      this.lblMake.Text = "Make";
      this.txtMileageIntervals.Location = new System.Drawing.Point(457, 30);
      this.txtMileageIntervals.MaxLength = 10;
      this.txtMileageIntervals.Name = "txtMileageIntervals";
      this.txtMileageIntervals.Size = new Size(77, 21);
      this.txtMileageIntervals.TabIndex = 3;
      this.lblMileageService.Location = new System.Drawing.Point(260, 33);
      this.lblMileageService.Name = "lblMileageService";
      this.lblMileageService.Size = new Size(160, 20);
      this.lblMileageService.TabIndex = 45;
      this.lblMileageService.Text = "Mileage Service Intervals";
      this.txtPayload.Location = new System.Drawing.Point(457, 106);
      this.txtPayload.MaxLength = 10;
      this.txtPayload.Name = "txtPayload";
      this.txtPayload.Size = new Size(77, 21);
      this.txtPayload.TabIndex = 53;
      this.lblPayLoad.Location = new System.Drawing.Point(387, 106);
      this.lblPayLoad.Name = "lblPayLoad";
      this.lblPayLoad.Size = new Size(55, 20);
      this.lblPayLoad.TabIndex = 55;
      this.lblPayLoad.Text = "Payload";
      this.txtGrossVehicleWeight.Location = new System.Drawing.Point(158, 106);
      this.txtGrossVehicleWeight.MaxLength = 20;
      this.txtGrossVehicleWeight.Name = "txtGrossVehicleWeight";
      this.txtGrossVehicleWeight.Size = new Size(85, 21);
      this.txtGrossVehicleWeight.TabIndex = 52;
      this.lblGrossVehicleWeight.Location = new System.Drawing.Point(12, 109);
      this.lblGrossVehicleWeight.Name = "lblGrossVehicleWeight";
      this.lblGrossVehicleWeight.Size = new Size(140, 20);
      this.lblGrossVehicleWeight.TabIndex = 54;
      this.lblGrossVehicleWeight.Text = "Gross Vehicle Weight";
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.grpVan);
      this.Name = nameof (UCFleetVanType);
      this.Size = new Size(580, 171);
      this.grpVan.ResumeLayout(false);
      this.grpVan.PerformLayout();
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentVanType;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public FleetVanType CurrentVanType
    {
      get
      {
        return this._currentVanType;
      }
      set
      {
        this._currentVanType = value;
        if (this._currentVanType != null)
          return;
        this._currentVanType = new FleetVanType();
        this._currentVanType.Exists = false;
      }
    }

    private void UCVan_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentVanType = App.DB.FleetVanType.Get(ID);
      this.txtMake.Text = this.CurrentVanType.Make;
      this.txtModel.Text = this.CurrentVanType.Model;
      this.txtMileageIntervals.Text = Conversions.ToString(this.CurrentVanType.MileageServiceInterval);
      this.txtDateIntervals.Text = Conversions.ToString(this.CurrentVanType.DateServiceInterval);
      this.txtGrossVehicleWeight.Text = Conversions.ToString(this.CurrentVanType.GrossVehicleWeight);
      this.txtPayload.Text = Conversions.ToString(this.CurrentVanType.Payload);
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentVanType.IgnoreExceptionsOnSetMethods = true;
        this.CurrentVanType.SetMake = (object) this.txtMake.Text.Trim();
        this.CurrentVanType.SetModel = (object) this.txtModel.Text.Trim();
        this.CurrentVanType.SetMileageServiceInterval = (object) this.txtMileageIntervals.Text.Trim();
        this.CurrentVanType.SetDateServiceInterval = (object) this.txtDateIntervals.Text.Trim();
        this.CurrentVanType.SetGrossVehicleWeight = (object) Math.Round(Helper.MakeDoubleValid((object) this.txtGrossVehicleWeight.Text), 2);
        this.CurrentVanType.SetPayload = (object) Math.Round(Helper.MakeDoubleValid((object) this.txtPayload.Text), 2);
        new FleetVanTypeValidator().Validate(this.CurrentVanType);
        if (this.CurrentVanType.Exists)
          App.DB.FleetVanType.Update(this.CurrentVanType);
        else
          this.CurrentVanType = App.DB.FleetVanType.Insert(this.CurrentVanType);
        App.MainForm.RefreshEntity(this.CurrentVanType.VanTypeID, "");
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }
  }
}
