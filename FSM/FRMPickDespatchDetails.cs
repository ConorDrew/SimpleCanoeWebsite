// Decompiled with JetBrains decompiler
// Type: FSM.FRMPickDespatchDetails
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
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
  public class FRMPickDespatchDetails : FRMBaseForm, IForm
  {
    private IContainer components;
    private EngineerVisit _EngVisit;

    public FRMPickDespatchDetails()
    {
      this.Load += new EventHandler(this.FRMPickDespatchDetails_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label lblHeading { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        Button btnOk1 = this._btnOK;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOK = value;
        Button btnOk2 = this._btnOK;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    internal virtual RadioButton radPartsDespatched
    {
      get
      {
        return this._radPartsDespatched;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.radPartsDespatched_CheckedChanged);
        RadioButton radPartsDespatched1 = this._radPartsDespatched;
        if (radPartsDespatched1 != null)
          radPartsDespatched1.CheckedChanged -= eventHandler;
        this._radPartsDespatched = value;
        RadioButton radPartsDespatched2 = this._radPartsDespatched;
        if (radPartsDespatched2 == null)
          return;
        radPartsDespatched2.CheckedChanged += eventHandler;
      }
    }

    internal virtual ComboBox cboEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RadioButton radReadyToSchedule { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.lblHeading = new Label();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.radPartsDespatched = new RadioButton();
      this.cboEngineer = new ComboBox();
      this.radReadyToSchedule = new RadioButton();
      this.SuspendLayout();
      this.lblHeading.Location = new System.Drawing.Point(8, 40);
      this.lblHeading.Name = "lblHeading";
      this.lblHeading.Size = new Size(410, 36);
      this.lblHeading.TabIndex = 2;
      this.lblHeading.Text = "This order related to the visit '{0}' is waiting for parts. Please select the status and engineer you would be despatching the parts to:";
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(343, 145);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(11, 145);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(101, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Do Not Update";
      this.radPartsDespatched.AutoSize = true;
      this.radPartsDespatched.Location = new System.Drawing.Point(11, 79);
      this.radPartsDespatched.Name = "radPartsDespatched";
      this.radPartsDespatched.Size = new Size(119, 17);
      this.radPartsDespatched.TabIndex = 0;
      this.radPartsDespatched.Text = "Parts Depatched";
      this.radPartsDespatched.UseVisualStyleBackColor = true;
      this.cboEngineer.FormattingEnabled = true;
      this.cboEngineer.Location = new System.Drawing.Point(154, 78);
      this.cboEngineer.Name = "cboEngineer";
      this.cboEngineer.Size = new Size(264, 21);
      this.cboEngineer.TabIndex = 1;
      this.radReadyToSchedule.AutoSize = true;
      this.radReadyToSchedule.Checked = true;
      this.radReadyToSchedule.Location = new System.Drawing.Point(11, 112);
      this.radReadyToSchedule.Name = "radReadyToSchedule";
      this.radReadyToSchedule.Size = new Size(135, 17);
      this.radReadyToSchedule.TabIndex = 2;
      this.radReadyToSchedule.TabStop = true;
      this.radReadyToSchedule.Text = "Ready To Schedule";
      this.radReadyToSchedule.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(422, 174);
      this.ControlBox = false;
      this.Controls.Add((Control) this.radReadyToSchedule);
      this.Controls.Add((Control) this.cboEngineer);
      this.Controls.Add((Control) this.radPartsDespatched);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.lblHeading);
      this.MaximumSize = new Size(438, 212);
      this.MinimumSize = new Size(438, 212);
      this.Name = nameof (FRMPickDespatchDetails);
      this.Text = "Update Visit";
      this.Controls.SetChildIndex((Control) this.lblHeading, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.radPartsDespatched, 0);
      this.Controls.SetChildIndex((Control) this.cboEngineer, 0);
      this.Controls.SetChildIndex((Control) this.radReadyToSchedule, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboEngineer1 = this.cboEngineer;
      Combo.SetUpCombo(ref cboEngineer1, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Enums.ComboValues.Please_Select);
      this.cboEngineer = cboEngineer1;
      ComboBox cboEngineer2 = this.cboEngineer;
      Combo.SetSelectedComboItem_By_Value(ref cboEngineer2, Conversions.ToString(0));
      this.cboEngineer = cboEngineer2;
      this.cboEngineer.Enabled = false;
      this.EngVisit = (EngineerVisit) this.get_GetParameter(0);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    public void ResetMe(int newID)
    {
    }

    public EngineerVisit EngVisit
    {
      get
      {
        return this._EngVisit;
      }
      set
      {
        this._EngVisit = value;
        this.lblHeading.Text = string.Format(this.lblHeading.Text, (object) App.DB.Job.Job_Get_For_An_EngineerVisit_ID(this.EngVisit.EngineerVisitID).JobNumber);
      }
    }

    private void FRMPickDespatchDetails_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void radPartsDespatched_CheckedChanged(object sender, EventArgs e)
    {
      if (this.radPartsDespatched.Checked)
      {
        this.cboEngineer.Enabled = true;
      }
      else
      {
        ComboBox cboEngineer = this.cboEngineer;
        Combo.SetSelectedComboItem_By_Value(ref cboEngineer, Conversions.ToString(0));
        this.cboEngineer = cboEngineer;
        this.cboEngineer.Enabled = false;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.EngVisit.StatusEnumID >= 5)
      {
        int num1 = (int) App.ShowMessage("This visit has already been scheduled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (!this.radPartsDespatched.Checked & !this.radReadyToSchedule.Checked)
      {
        int num2 = (int) App.ShowMessage("Status not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else if (this.radPartsDespatched.Checked & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboEngineer)) == 0.0)
      {
        int num3 = (int) App.ShowMessage("Engineer not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        this.EngVisit.SetPartsToFit = (object) true;
        if (this.radPartsDespatched.Checked)
        {
          this.EngVisit.SetStatusEnumID = (object) 3;
          this.EngVisit.SetExpectedEngineerID = (object) Combo.get_GetSelectedItemValue(this.cboEngineer);
        }
        else if (this.radReadyToSchedule.Checked)
          this.EngVisit.SetStatusEnumID = (object) 4;
        App.DB.EngineerVisits.Update(this.EngVisit, 0, true);
        this.DialogResult = DialogResult.OK;
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }
  }
}
