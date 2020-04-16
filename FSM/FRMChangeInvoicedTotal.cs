// Decompiled with JetBrains decompiler
// Type: FSM.FRMChangeInvoicedTotal
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
  public class FRMChangeInvoicedTotal : FRMBaseForm, IForm
  {
    private IContainer components;
    private int typeID;
    private int _ID;

    public FRMChangeInvoicedTotal()
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
      this.txtInvoicedTotal = new TextBox();
      this.Label2 = new Label();
      this.btnSave = new Button();
      this.txtPassword = new TextBox();
      this.Label1 = new Label();
      this.Label3 = new Label();
      this.txtAccount = new TextBox();
      this.Label4 = new Label();
      this.txtNominal = new TextBox();
      this.Label5 = new Label();
      this.txtDept = new TextBox();
      this.Label6 = new Label();
      this.dtpTaxDate = new DateTimePicker();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.dtpTaxDate);
      this.GroupBox1.Controls.Add((Control) this.txtDept);
      this.GroupBox1.Controls.Add((Control) this.Label6);
      this.GroupBox1.Controls.Add((Control) this.txtNominal);
      this.GroupBox1.Controls.Add((Control) this.Label5);
      this.GroupBox1.Controls.Add((Control) this.txtAccount);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.txtInvoicedTotal);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.btnSave);
      this.GroupBox1.Controls.Add((Control) this.txtPassword);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(502, 263);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Change Invoiced Total";
      this.txtInvoicedTotal.Location = new System.Drawing.Point(194, 195);
      this.txtInvoicedTotal.Name = "txtInvoicedTotal";
      this.txtInvoicedTotal.Size = new Size(291, 21);
      this.txtInvoicedTotal.TabIndex = 3;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(6, 203);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(87, 13);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Invoiced Total";
      this.btnSave.Enabled = false;
      this.btnSave.Location = new System.Drawing.Point(410, 234);
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
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(6, 76);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(58, 13);
      this.Label3.TabIndex = 5;
      this.Label3.Text = "Tax Date";
      this.txtAccount.Location = new System.Drawing.Point(194, 95);
      this.txtAccount.Name = "txtAccount";
      this.txtAccount.Size = new Size(291, 21);
      this.txtAccount.TabIndex = 8;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(6, 103);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(52, 13);
      this.Label4.TabIndex = 7;
      this.Label4.Text = "Account";
      this.txtNominal.Location = new System.Drawing.Point(194, 122);
      this.txtNominal.Name = "txtNominal";
      this.txtNominal.Size = new Size(291, 21);
      this.txtNominal.TabIndex = 10;
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(6, 130);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(53, 13);
      this.Label5.TabIndex = 9;
      this.Label5.Text = "Nominal";
      this.txtDept.Location = new System.Drawing.Point(194, 149);
      this.txtDept.Name = "txtDept";
      this.txtDept.Size = new Size(291, 21);
      this.txtDept.TabIndex = 12;
      this.Label6.AutoSize = true;
      this.Label6.Location = new System.Drawing.Point(6, 152);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(75, 13);
      this.Label6.TabIndex = 11;
      this.Label6.Text = "Department";
      this.dtpTaxDate.Location = new System.Drawing.Point(194, 68);
      this.dtpTaxDate.Name = "dtpTaxDate";
      this.dtpTaxDate.Size = new Size(291, 21);
      this.dtpTaxDate.TabIndex = 13;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(526, 313);
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (FRMChangeInvoicedTotal);
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

    internal virtual TextBox txtInvoicedTotal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNominal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTaxDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.ID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0)));
      this.txtInvoicedTotal.Text = Conversions.ToString(Helper.MakeDoubleValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(1))));
      this.txtAccount.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(2)));
      this.txtDept.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(3)));
      this.txtNominal.Text = Helper.MakeStringValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(4)));
      this.dtpTaxDate.Value = Helper.MakeDateTimeValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(5)));
      this.typeID = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(6)));
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.txtInvoicedTotal.Enabled = false;
      this.txtNominal.Enabled = false;
      this.txtDept.Enabled = false;
      this.txtAccount.Enabled = false;
      this.dtpTaxDate.Enabled = false;
      this.btnSave.Enabled = false;
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
      if (this.txtInvoicedTotal.Text.Replace("£", "").Length > 0 & Versioned.IsNumeric((object) this.txtInvoicedTotal.Text.Replace("£", "")))
      {
        App.DB.InvoicedLines.InvoicedLinesTotal_Change(this.ID, Conversions.ToDouble(this.txtInvoicedTotal.Text.Replace("£", "")));
        App.DB.InvoicedLines.InvoicedLinesTotal_ChangeInvoiceDetails(this.ID, this.txtAccount.Text, this.txtDept.Text, this.txtNominal.Text, this.dtpTaxDate.Value, this.typeID);
        this.DialogResult = DialogResult.OK;
      }
      else
      {
        int num = (int) App.ShowMessage("Enter An Amount", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
      if (Operators.CompareString(Helper.HashPassword(this.txtPassword.Text.Trim()), App.DB.Manager.Get().OverridePassword_Service, false) == 0)
      {
        this.txtInvoicedTotal.Enabled = true;
        this.txtNominal.Enabled = true;
        this.txtDept.Enabled = true;
        this.txtAccount.Enabled = true;
        this.dtpTaxDate.Enabled = true;
        this.btnSave.Enabled = true;
      }
      else
      {
        this.txtInvoicedTotal.Enabled = false;
        this.txtNominal.Enabled = false;
        this.txtDept.Enabled = false;
        this.txtAccount.Enabled = false;
        this.dtpTaxDate.Enabled = false;
        this.btnSave.Enabled = false;
      }
    }
  }
}
