// Decompiled with JetBrains decompiler
// Type: FSM.UCFleetEquipment
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.FleetVans;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCFleetEquipment : UCBase, IUserControl
  {
    private IContainer components;
    private FleetEquipment _currentEquipment;

    public UCFleetEquipment()
    {
      this.Load += new EventHandler(this.UCVan_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpVan { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCost { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RichTextBox txtDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpVan = new GroupBox();
      this.lblName = new Label();
      this.txtCost = new TextBox();
      this.lblCost = new Label();
      this.txtName = new TextBox();
      this.lblDescription = new Label();
      this.txtDescription = new RichTextBox();
      this.grpVan.SuspendLayout();
      this.SuspendLayout();
      this.grpVan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpVan.Controls.Add((Control) this.txtDescription);
      this.grpVan.Controls.Add((Control) this.lblDescription);
      this.grpVan.Controls.Add((Control) this.txtName);
      this.grpVan.Controls.Add((Control) this.lblName);
      this.grpVan.Controls.Add((Control) this.txtCost);
      this.grpVan.Controls.Add((Control) this.lblCost);
      this.grpVan.Location = new System.Drawing.Point(12, 13);
      this.grpVan.Name = "grpVan";
      this.grpVan.Size = new Size(415, 151);
      this.grpVan.TabIndex = 3;
      this.grpVan.TabStop = false;
      this.grpVan.Text = "Details";
      this.lblName.Location = new System.Drawing.Point(12, 33);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(58, 20);
      this.lblName.TabIndex = 47;
      this.lblName.Text = "Name";
      this.txtCost.Location = new System.Drawing.Point(299, 30);
      this.txtCost.MaxLength = 10;
      this.txtCost.Name = "txtCost";
      this.txtCost.Size = new Size(77, 21);
      this.txtCost.TabIndex = 3;
      this.lblCost.Location = new System.Drawing.Point(241, 33);
      this.lblCost.Name = "lblCost";
      this.lblCost.Size = new Size(73, 20);
      this.lblCost.TabIndex = 45;
      this.lblCost.Text = "Cost";
      this.txtName.Location = new System.Drawing.Point(95, 30);
      this.txtName.MaxLength = 20;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(131, 21);
      this.txtName.TabIndex = 1;
      this.lblDescription.Location = new System.Drawing.Point(12, 69);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new Size(84, 20);
      this.lblDescription.TabIndex = 49;
      this.lblDescription.Text = "Description";
      this.txtDescription.Location = new System.Drawing.Point(95, 69);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new Size(281, 62);
      this.txtDescription.TabIndex = 50;
      this.txtDescription.Text = "";
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.grpVan);
      this.Name = nameof (UCFleetEquipment);
      this.Size = new Size(439, 179);
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
        return (object) this.CurrentEquipment;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public FleetEquipment CurrentEquipment
    {
      get
      {
        return this._currentEquipment;
      }
      set
      {
        this._currentEquipment = value;
        if (this._currentEquipment != null)
          return;
        this._currentEquipment = new FleetEquipment();
        this._currentEquipment.Exists = false;
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
        this.CurrentEquipment = App.DB.FleetEquipment.Get(ID);
      this.txtName.Text = this.CurrentEquipment.Name;
      this.txtCost.Text = Conversions.ToString(this.CurrentEquipment.Cost);
      this.txtDescription.Text = this.CurrentEquipment.Description;
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
        this.CurrentEquipment.IgnoreExceptionsOnSetMethods = true;
        this.CurrentEquipment.SetName = (object) this.txtName.Text.Trim();
        this.CurrentEquipment.SetCost = (object) this.txtCost.Text.Trim();
        this.CurrentEquipment.SetDescription = (object) this.txtDescription.Text.Trim();
        new FleetEquipmentValidator().Validate(this.CurrentEquipment);
        if (this.CurrentEquipment.Exists)
          App.DB.FleetEquipment.Update(this.CurrentEquipment);
        else
          this.CurrentEquipment = App.DB.FleetEquipment.Insert(this.CurrentEquipment);
        App.MainForm.RefreshEntity(this.CurrentEquipment.EquipmentID, "");
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
