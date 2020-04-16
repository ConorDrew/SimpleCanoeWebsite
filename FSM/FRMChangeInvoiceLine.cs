// Decompiled with JetBrains decompiler
// Type: FSM.FRMChangeInvoiceLine
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
  public class FRMChangeInvoiceLine : FRMBaseForm, IForm
  {
    private IContainer components;

    public FRMChangeInvoiceLine()
    {
      this.Load += new EventHandler(this.FRMChangeInvoiceLine_Load);
      this.InitializeComponent();
      ComboBox invoiceTaxCodeNew = this.cboInvoiceTaxCodeNew;
      Combo.SetUpCombo(ref invoiceTaxCodeNew, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select);
      this.cboInvoiceTaxCodeNew = invoiceTaxCodeNew;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Label lblAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAmount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblVatRate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboInvoiceTaxCodeNew { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click_1);
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
      this.lblAmount = new Label();
      this.txtAmount = new TextBox();
      this.lblVatRate = new Label();
      this.cboInvoiceTaxCodeNew = new ComboBox();
      this.btnSave = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.lblAmount.AutoSize = true;
      this.lblAmount.Location = new System.Drawing.Point(12, 66);
      this.lblAmount.Name = "lblAmount";
      this.lblAmount.Size = new Size(51, 13);
      this.lblAmount.TabIndex = 1;
      this.lblAmount.Text = "Amount";
      this.txtAmount.Location = new System.Drawing.Point(89, 63);
      this.txtAmount.Name = "txtAmount";
      this.txtAmount.Size = new Size(192, 21);
      this.txtAmount.TabIndex = 2;
      this.lblVatRate.AutoSize = true;
      this.lblVatRate.Location = new System.Drawing.Point(12, 108);
      this.lblVatRate.Name = "lblVatRate";
      this.lblVatRate.Size = new Size(55, 13);
      this.lblVatRate.TabIndex = 3;
      this.lblVatRate.Text = "Vat Rate";
      this.cboInvoiceTaxCodeNew.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboInvoiceTaxCodeNew.Location = new System.Drawing.Point(89, 105);
      this.cboInvoiceTaxCodeNew.Name = "cboInvoiceTaxCodeNew";
      this.cboInvoiceTaxCodeNew.Size = new Size(83, 21);
      this.cboInvoiceTaxCodeNew.TabIndex = 108;
      this.btnSave.Location = new System.Drawing.Point(206, 145);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 109;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnCancel.Location = new System.Drawing.Point(15, 145);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 110;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(304, 180);
      this.ControlBox = false;
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.cboInvoiceTaxCodeNew);
      this.Controls.Add((Control) this.lblVatRate);
      this.Controls.Add((Control) this.txtAmount);
      this.Controls.Add((Control) this.lblAmount);
      this.MaximumSize = new Size(1000, 1000);
      this.Name = nameof (FRMChangeInvoiceLine);
      this.Text = "Update";
      this.Controls.SetChildIndex((Control) this.lblAmount, 0);
      this.Controls.SetChildIndex((Control) this.txtAmount, 0);
      this.Controls.SetChildIndex((Control) this.lblVatRate, 0);
      this.Controls.SetChildIndex((Control) this.cboInvoiceTaxCodeNew, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    void IForm.ResetMe(int newID)
    {
    }

    private void FRMChangeInvoiceLine_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
      this.txtAmount.Text = Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0))));
      ComboBox invoiceTaxCodeNew = this.cboInvoiceTaxCodeNew;
      Combo.SetSelectedComboItem_By_Value(ref invoiceTaxCodeNew, Conversions.ToString(Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1)))));
      this.cboInvoiceTaxCodeNew = invoiceTaxCodeNew;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click_1(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }
  }
}
