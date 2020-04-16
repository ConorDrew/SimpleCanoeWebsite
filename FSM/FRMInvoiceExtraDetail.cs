// Decompiled with JetBrains decompiler
// Type: FSM.FRMInvoiceExtraDetail
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
  public class FRMInvoiceExtraDetail : Form
  {
    private IContainer components;

    public FRMInvoiceExtraDetail()
    {
      this.Load += new EventHandler(this.FRMChangePriority_Load);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMInvoiceExtraDetail));
      this.GroupBox1 = new GroupBox();
      this.cbo = new ComboBox();
      this.Button1 = new Button();
      this.Label3 = new Label();
      this.btnOK = new Button();
      this.txtNotes = new TextBox();
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.txtCharge = new TextBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.txtCharge);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.txtNotes);
      this.GroupBox1.Controls.Add((Control) this.cbo);
      this.GroupBox1.Controls.Add((Control) this.Button1);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Location = new System.Drawing.Point(5, 1);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(505, 258);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.cbo.FormattingEnabled = true;
      this.cbo.Location = new System.Drawing.Point(150, 195);
      this.cbo.Name = "cbo";
      this.cbo.Size = new Size(298, 21);
      this.cbo.TabIndex = 8;
      this.Button1.UseVisualStyleBackColor = true;
      this.Button1.Location = new System.Drawing.Point(9, 230);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 7;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.ForeColor = SystemColors.ActiveCaptionText;
      this.Label3.Location = new System.Drawing.Point(52, 196);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(67, 16);
      this.Label3.TabIndex = 6;
      this.Label3.Text = "VAT Rate";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Location = new System.Drawing.Point(423, 230);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Proceed";
      this.btnOK.UseVisualStyleBackColor = true;
      this.txtNotes.Location = new System.Drawing.Point(150, 19);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.Size = new Size(298, (int) sbyte.MaxValue);
      this.txtNotes.TabIndex = 9;
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = SystemColors.ActiveCaptionText;
      this.Label1.Location = new System.Drawing.Point(52, 20);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(44, 16);
      this.Label1.TabIndex = 10;
      this.Label1.Text = "Notes";
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.ForeColor = SystemColors.ActiveCaptionText;
      this.Label2.Location = new System.Drawing.Point(52, 164);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(100, 16);
      this.Label2.TabIndex = 11;
      this.Label2.Text = "Charge Ex VAT";
      this.txtCharge.Location = new System.Drawing.Point(150, 163);
      this.txtCharge.Name = "txtCharge";
      this.txtCharge.Size = new Size(298, 20);
      this.txtCharge.TabIndex = 12;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(513, 271);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMInvoiceExtraDetail);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Take Payment";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1
    {
      get
      {
        return this._Button1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual ComboBox cbo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCharge { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cbo)) == 0.0)
      {
        int num = (int) App.ShowMessage("Please enter a valid VAT Amount", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
      ComboBox cbo = this.cbo;
      Combo.SetUpCombo(ref cbo, App.DB.VATRatesSQL.VATRates_GetAll_Valid().Table, "VATRATEID", "Description", Enums.ComboValues.Please_Select);
      this.cbo = cbo;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      ComboBox cbo = this.cbo;
      Combo.SetSelectedComboItem_By_Value(ref cbo, "0");
      this.cbo = cbo;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
