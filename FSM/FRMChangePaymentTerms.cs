// Decompiled with JetBrains decompiler
// Type: FSM.FRMChangePaymentTerms
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
  public class FRMChangePaymentTerms : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ID;

    public FRMChangePaymentTerms()
    {
      this.Load += new EventHandler(this.FRMChangeInvoicedTotal_Load);
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
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.txtPassword = new TextBox();
      this.Label1 = new Label();
      this.cboPaymentTerm = new ComboBox();
      this.cboPaidBy = new ComboBox();
      this.lblPaidBy = new Label();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.cboPaidBy);
      this.GroupBox1.Controls.Add((Control) this.lblPaidBy);
      this.GroupBox1.Controls.Add((Control) this.cboPaymentTerm);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.btnSave);
      this.GroupBox1.Controls.Add((Control) this.txtPassword);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(502, 189);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Change Invoiced Total";
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 61);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(90, 13);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Payment Term";
      this.btnSave.Enabled = false;
      this.btnSave.Location = new System.Drawing.Point(410, 160);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.TabIndex = 4;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.txtPassword.Location = new System.Drawing.Point(194, 27);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new Size(291, 21);
      this.txtPassword.TabIndex = 1;
      this.txtPassword.UseSystemPasswordChar = true;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(6, 30);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(169, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Enter the override password";
      this.cboPaymentTerm.Enabled = false;
      this.cboPaymentTerm.FormattingEnabled = true;
      this.cboPaymentTerm.Location = new System.Drawing.Point(194, 58);
      this.cboPaymentTerm.Name = "cboPaymentTerm";
      this.cboPaymentTerm.Size = new Size(291, 21);
      this.cboPaymentTerm.TabIndex = 5;
      this.cboPaidBy.FormattingEnabled = true;
      this.cboPaidBy.Location = new System.Drawing.Point(194, 90);
      this.cboPaidBy.Name = "cboPaidBy";
      this.cboPaidBy.Size = new Size(291, 21);
      this.cboPaidBy.TabIndex = 7;
      this.cboPaidBy.Visible = false;
      this.lblPaidBy.AutoSize = true;
      this.lblPaidBy.Location = new System.Drawing.Point(6, 93);
      this.lblPaidBy.Name = "lblPaidBy";
      this.lblPaidBy.Size = new Size(50, 13);
      this.lblPaidBy.TabIndex = 6;
      this.lblPaidBy.Text = "Paid By";
      this.lblPaidBy.Visible = false;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(526, 239);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMChangePaymentTerms);
      this.Text = "Change Invoiced Total";
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

    internal virtual TextBox txtPassword
    {
      get
      {
        return this._txtPassword;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.txtPassword_TextChanged);
        TextBox txtPassword1 = this._txtPassword;
        if (txtPassword1 != null)
          txtPassword1.TextChanged -= eventHandler;
        this._txtPassword = value;
        TextBox txtPassword2 = this._txtPassword;
        if (txtPassword2 == null)
          return;
        txtPassword2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaidBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPaidBy { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPaymentTerm
    {
      get
      {
        return this._cboPaymentTerm;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboPaymentTerm_SelectedIndexChanged);
        ComboBox cboPaymentTerm1 = this._cboPaymentTerm;
        if (cboPaymentTerm1 != null)
          cboPaymentTerm1.SelectedIndexChanged -= eventHandler;
        this._cboPaymentTerm = value;
        ComboBox cboPaymentTerm2 = this._cboPaymentTerm;
        if (cboPaymentTerm2 == null)
          return;
        cboPaymentTerm2.SelectedIndexChanged += eventHandler;
      }
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      ComboBox cboPaymentTerm = this.cboPaymentTerm;
      Combo.SetUpCombo(ref cboPaymentTerm, App.DB.Picklists.GetAll(Enums.PickListTypes.InvoiceTerms, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPaymentTerm = cboPaymentTerm;
      ComboBox cboPaidBy = this.cboPaidBy;
      Combo.SetUpCombo(ref cboPaidBy, App.DB.Picklists.GetAll(Enums.PickListTypes.Locations | Enums.PickListTypes.Symptoms, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboPaidBy = cboPaidBy;
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

    private void FRMChangeInvoicedTotal_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaymentTerm)) > 0.0)
      {
        int PaidBy = 0;
        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaidBy)) > 0.0 & Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaymentTerm)) == 69491.0)
          PaidBy = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPaidBy));
        App.DB.InvoicedLines.Invoiced_ChangeTerm(this.ID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboPaymentTerm)), PaidBy);
        this.DialogResult = DialogResult.OK;
      }
      else
      {
        int num = (int) App.ShowMessage("Please Select a Term", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
      if (Operators.CompareString(Helper.HashPassword(this.txtPassword.Text.Trim()), App.DB.Manager.Get().OverridePassword_Service, false) == 0)
      {
        this.cboPaymentTerm.Enabled = true;
        this.btnSave.Enabled = true;
      }
      else
      {
        this.cboPaymentTerm.Enabled = false;
        this.btnSave.Enabled = false;
      }
    }

    private void cboPaymentTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPaymentTerm)) == 69491.0)
      {
        this.lblPaidBy.Visible = true;
        this.cboPaidBy.Visible = true;
      }
      else
      {
        this.lblPaidBy.Visible = false;
        this.cboPaidBy.Visible = false;
      }
    }
  }
}
