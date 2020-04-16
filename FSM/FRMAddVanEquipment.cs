// Decompiled with JetBrains decompiler
// Type: FSM.FRMAddVanEquipment
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

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
  [DesignerGenerated]
  public class FRMAddVanEquipment : Form
  {
    private IContainer components;

    public FRMAddVanEquipment()
    {
      this.Load += new EventHandler(this.FRMAddVanEquipment_Load);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMAddVanEquipment));
      this.grpEquipment = new GroupBox();
      this.btnAdd = new Button();
      this.cboEquipment = new ComboBox();
      this.grpEquipment.SuspendLayout();
      this.SuspendLayout();
      this.grpEquipment.Controls.Add((Control) this.btnAdd);
      this.grpEquipment.Controls.Add((Control) this.cboEquipment);
      this.grpEquipment.FlatStyle = FlatStyle.System;
      this.grpEquipment.Location = new System.Drawing.Point(5, 1);
      this.grpEquipment.Name = "grpEquipment";
      this.grpEquipment.Size = new Size(277, 76);
      this.grpEquipment.TabIndex = 0;
      this.grpEquipment.TabStop = false;
      this.grpEquipment.Text = "Select Equipment";
      this.btnAdd.FlatStyle = FlatStyle.System;
      this.btnAdd.Location = new System.Drawing.Point(90, 46);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(75, 23);
      this.btnAdd.TabIndex = 1;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.cboEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboEquipment.FlatStyle = FlatStyle.System;
      this.cboEquipment.FormattingEnabled = true;
      this.cboEquipment.Location = new System.Drawing.Point(7, 19);
      this.cboEquipment.Name = "cboEquipment";
      this.cboEquipment.Size = new Size(264, 21);
      this.cboEquipment.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(284, 82);
      this.Controls.Add((Control) this.grpEquipment);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMAddVanEquipment);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Add Van Equipment";
      this.grpEquipment.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal virtual GroupBox grpEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cboEquipment { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboEquipment)) == 0.0)
      {
        int num = (int) App.ShowMessage("Please select equipment", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMAddVanEquipment_Load(object sender, EventArgs e)
    {
      ComboBox cboEquipment = this.cboEquipment;
      Combo.SetUpCombo(ref cboEquipment, App.DB.FleetEquipment.GetAll().Table, "EquipmentID", "Name", Enums.ComboValues.Please_Select);
      this.cboEquipment = cboEquipment;
    }
  }
}
