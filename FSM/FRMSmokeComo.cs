// Decompiled with JetBrains decompiler
// Type: FSM.FRMSmokeComo
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisitAdditionals;
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
  public class FRMSmokeComo : Form
  {
    private IContainer components;
    public int AdditionalID;
    public int EngineerVisitID;

    public FRMSmokeComo()
    {
      this.Load += new EventHandler(this.FRMChangePriority_Load);
      this.AdditionalID = 0;
      this.EngineerVisitID = 0;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMSmokeComo));
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.Label4 = new Label();
      this.dtpDate = new DateTimePicker();
      this.txtLocation = new TextBox();
      this.Label3 = new Label();
      this.cboDateType = new ComboBox();
      this.Label2 = new Label();
      this.cboPower = new ComboBox();
      this.Label1 = new Label();
      this.lbltype = new Label();
      this.btnOK = new Button();
      this.cboDetType = new ComboBox();
      this.chkNA = new CheckBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.chkNA);
      this.GroupBox1.Controls.Add((Control) this.Button1);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.dtpDate);
      this.GroupBox1.Controls.Add((Control) this.txtLocation);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.cboDateType);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.cboPower);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.lbltype);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Controls.Add((Control) this.cboDetType);
      this.GroupBox1.Location = new System.Drawing.Point(5, 1);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(422, 206);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Add/ Amend";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button1.Location = new System.Drawing.Point(6, 177);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 12;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(54, 115);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(36, 13);
      this.Label4.TabIndex = 11;
      this.Label4.Text = "Dated";
      this.dtpDate.Location = new System.Drawing.Point(122, 111);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.Size = new Size(136, 20);
      this.dtpDate.TabIndex = 10;
      this.txtLocation.Location = new System.Drawing.Point(122, 57);
      this.txtLocation.Name = "txtLocation";
      this.txtLocation.Size = new Size(243, 20);
      this.txtLocation.TabIndex = 9;
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(54, 140);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(57, 13);
      this.Label3.TabIndex = 8;
      this.Label3.Text = "Date Type";
      this.cboDateType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDateType.FormattingEnabled = true;
      this.cboDateType.Location = new System.Drawing.Point(122, 137);
      this.cboDateType.Name = "cboDateType";
      this.cboDateType.Size = new Size(243, 21);
      this.cboDateType.TabIndex = 7;
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(54, 87);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(64, 13);
      this.Label2.TabIndex = 6;
      this.Label2.Text = "Power Type";
      this.cboPower.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboPower.FormattingEnabled = true;
      this.cboPower.Location = new System.Drawing.Point(122, 84);
      this.cboPower.Name = "cboPower";
      this.cboPower.Size = new Size(243, 21);
      this.cboPower.TabIndex = 5;
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(54, 60);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(48, 13);
      this.Label1.TabIndex = 4;
      this.Label1.Text = "Location";
      this.lbltype.AutoSize = true;
      this.lbltype.Location = new System.Drawing.Point(54, 33);
      this.lbltype.Name = "lbltype";
      this.lbltype.Size = new Size(31, 13);
      this.lbltype.TabIndex = 2;
      this.lbltype.Text = "Type";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Location = new System.Drawing.Point(341, 177);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "Save";
      this.btnOK.UseVisualStyleBackColor = true;
      this.cboDetType.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboDetType.FormattingEnabled = true;
      this.cboDetType.Location = new System.Drawing.Point(122, 30);
      this.cboDetType.Name = "cboDetType";
      this.cboDetType.Size = new Size(243, 21);
      this.cboDetType.TabIndex = 0;
      this.chkNA.AutoSize = true;
      this.chkNA.Location = new System.Drawing.Point(280, 113);
      this.chkNA.Name = "chkNA";
      this.chkNA.Size = new Size(79, 17);
      this.chkNA.TabIndex = 13;
      this.chkNA.Text = "Not Known";
      this.chkNA.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(439, 215);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMSmokeComo);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Add/Amend";
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

    internal virtual ComboBox cboDetType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLocation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDateType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPower { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltype { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual CheckBox chkNA
    {
      get
      {
        return this._chkNA;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkNA_CheckedChanged);
        CheckBox chkNa1 = this._chkNA;
        if (chkNa1 != null)
          chkNa1.CheckedChanged -= eventHandler;
        this._chkNA = value;
        CheckBox chkNa2 = this._chkNA;
        if (chkNa2 == null)
          return;
        chkNa2.CheckedChanged += eventHandler;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboPower)) == 0.0)
      {
        int num1 = (int) App.ShowMessage("Please select a Power Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboDateType)) == 0.0)
      {
        int num2 = (int) App.ShowMessage("Please select a Date Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboDetType)) == 0.0)
      {
        int num3 = (int) App.ShowMessage("Please select a Detector Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.txtLocation.Text.Length == 0)
      {
        int num4 = (int) App.ShowMessage("Please enter a Location", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        EngineerVisitAdditional oEngineerVisitAdditional = new EngineerVisitAdditional();
        oEngineerVisitAdditional.SetTest11 = !this.chkNA.Checked ? (object) this.dtpDate.Value.ToString("d MMM yyyy") : (object) "Not Known";
        oEngineerVisitAdditional.SetEngineerVisitID = (object) this.EngineerVisitID;
        oEngineerVisitAdditional.SetTest1 = (object) 386;
        oEngineerVisitAdditional.SetTestTypeID = (object) Combo.get_GetSelectedItemValue(this.cboDetType);
        oEngineerVisitAdditional.SetTest2 = (object) Combo.get_GetSelectedItemValue(this.cboPower);
        oEngineerVisitAdditional.SetTest12 = (object) Combo.get_GetSelectedItemDescription(this.cboDateType);
        oEngineerVisitAdditional.SetTest13 = (object) this.txtLocation.Text;
        oEngineerVisitAdditional.SetEngineerVisitAdditionalID = (object) this.AdditionalID;
        if (this.AdditionalID == 0)
          App.DB.EngineerVisitAdditional.Insert(oEngineerVisitAdditional);
        else
          App.DB.EngineerVisitAdditional.Update(oEngineerVisitAdditional);
        this.DialogResult = DialogResult.OK;
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
    }

    private void FRMChangePriority_Load(object sender, EventArgs e)
    {
    }

    private void chkNA_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkNA.Checked)
        this.dtpDate.Enabled = false;
      else
        this.dtpDate.Enabled = true;
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }
  }
}
