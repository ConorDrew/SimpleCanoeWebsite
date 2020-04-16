// Decompiled with JetBrains decompiler
// Type: FSM.FRMCostCentre
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMCostCentre : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ID;

    public FRMCostCentre()
    {
      this.Load += new EventHandler(this.FRMLastServiceDate_Load);
      this._ID = 0;
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.cboContractCode = new ComboBox();
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.cboContractCode);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.btnSave);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(504, 118);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Please Select Contract Code";
      this.cboContractCode.FormattingEnabled = true;
      this.cboContractCode.Location = new System.Drawing.Point(130, 43);
      this.cboContractCode.Name = "cboContractCode";
      this.cboContractCode.Size = new Size(355, 21);
      this.cboContractCode.TabIndex = 5;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 46);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(95, 13);
      this.Label2.TabIndex = 4;
      this.Label2.Text = "Contract Code:";
      this.btnSave.Location = new System.Drawing.Point(410, 82);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 3;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(528, 168);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMCostCentre);
      this.Text = "Select Contract Code";
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual ComboBox cboContractCode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      if (true == App.IsGasway)
      {
        ComboBox cboContractCode = this.cboContractCode;
        Combo.SetUpCombo(ref cboContractCode, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboContractCode = cboContractCode;
      }
      else
      {
        ComboBox cboContractCode = this.cboContractCode;
        Combo.SetUpCombo(ref cboContractCode, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboContractCode = cboContractCode;
      }
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
      this.ID = newID;
    }

    public int ID
    {
      get
      {
        return this._ID;
      }
      set
      {
        this._ID = value;
      }
    }

    private void FRMLastServiceDate_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      string str = Helper.MakeStringValid((object) Combo.get_GetSelectedItemValue(this.cboContractCode));
      if (Helper.IsValidInteger((object) str) && Helper.MakeIntegerValid((object) str) <= 0)
      {
        int num = (int) Interaction.MsgBox((object) "Please Select a Contract Code", MsgBoxStyle.OkOnly, (object) null);
      }
      else
      {
        this.DialogResult = DialogResult.OK;
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
    }
  }
}
