// Decompiled with JetBrains decompiler
// Type: FSM.DLGSetupVisit
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
  public class DLGSetupVisit : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _ID;
    private string _2ndID;
    private string _FrequencyID;
    private DateTime _EffDate;

    public DLGSetupVisit()
    {
      this.Load += new EventHandler(this.DLGFindRecord_Load);
      this._ID = 0;
      this._2ndID = Conversions.ToString(0);
      this._FrequencyID = Conversions.ToString(0);
      this._EffDate = DateTime.MinValue;
      this.InitializeComponent();
      ComboBox cboFrequency = this.cboFrequency;
      Combo.SetUpCombo(ref cboFrequency, DynamicDataTables.VisitFrequencyNoWeekly, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboFrequency = cboFrequency;
      ComboBox cboType = this.cboType;
      Combo.SetUpCombo(ref cboType, DynamicDataTables.ContractVisitType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboType = cboType;
      ComboBox preferredEngineer = this.cboPreferredEngineer;
      Combo.SetUpCombo(ref preferredEngineer, App.DB.Engineer.Engineer_GetAll().Table, "EngineerID", "Name", Enums.ComboValues.Not_Applicable);
      this.cboPreferredEngineer = preferredEngineer;
      ComboBox cboSubContractor = this.cboSubContractor;
      Combo.SetUpCombo(ref cboSubContractor, App.DB.SubContractor.Subcontractor_GetAll().Table, "EngineerID", "Name", Enums.ComboValues.Not_Applicable);
      this.cboSubContractor = cboSubContractor;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

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

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DateTimePicker dtpTargetDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboFrequency
    {
      get
      {
        return this._cboFrequency;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.cboFrequency_SelectedIndexChanged);
        ComboBox cboFrequency1 = this._cboFrequency;
        if (cboFrequency1 != null)
          cboFrequency1.SelectedIndexChanged -= eventHandler;
        this._cboFrequency = value;
        ComboBox cboFrequency2 = this._cboFrequency;
        if (cboFrequency2 == null)
          return;
        cboFrequency2.SelectedIndexChanged += eventHandler;
      }
    }

    internal virtual Label Label5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboPreferredEngineer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label6 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboSubContractor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox CheckBox1
    {
      get
      {
        return this._CheckBox1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckBox1_CheckedChanged);
        CheckBox checkBox1_1 = this._CheckBox1;
        if (checkBox1_1 != null)
          checkBox1_1.CheckedChanged -= eventHandler;
        this._CheckBox1 = value;
        CheckBox checkBox1_2 = this._CheckBox1;
        if (checkBox1_2 == null)
          return;
        checkBox1_2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFilter { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox TextBox1
    {
      get
      {
        return this._TextBox1;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.TextBox1_TextChanged);
        TextBox textBox1_1 = this._TextBox1;
        if (textBox1_1 != null)
          textBox1_1.TextChanged -= eventHandler;
        this._TextBox1 = value;
        TextBox textBox1_2 = this._TextBox1;
        if (textBox1_2 == null)
          return;
        textBox1_2.TextChanged += eventHandler;
      }
    }

    internal virtual Label Label7 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAdditional { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label8 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnCancel = new Button();
      this.Label4 = new Label();
      this.dtpTargetDate = new DateTimePicker();
      this.Label3 = new Label();
      this.cboType = new ComboBox();
      this.btnOK = new Button();
      this.Label2 = new Label();
      this.cboFrequency = new ComboBox();
      this.Label5 = new Label();
      this.cboPreferredEngineer = new ComboBox();
      this.Label6 = new Label();
      this.cboSubContractor = new ComboBox();
      this.CheckBox1 = new CheckBox();
      this.Label1 = new Label();
      this.txtFilter = new TextBox();
      this.TextBox1 = new TextBox();
      this.Label7 = new Label();
      this.txtAdditional = new TextBox();
      this.Label8 = new Label();
      this.SuspendLayout();
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 451);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(56, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.Label4.Location = new System.Drawing.Point(8, 144);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(95, 24);
      this.Label4.TabIndex = 12;
      this.Label4.Text = "Target Date";
      this.dtpTargetDate.Location = new System.Drawing.Point(122, 140);
      this.dtpTargetDate.Name = "dtpTargetDate";
      this.dtpTargetDate.Size = new Size(298, 21);
      this.dtpTargetDate.TabIndex = 3;
      this.Label3.Location = new System.Drawing.Point(10, 76);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(93, 15);
      this.Label3.TabIndex = 10;
      this.Label3.Text = "Visit Type";
      this.cboType.FormattingEnabled = true;
      this.cboType.Location = new System.Drawing.Point(122, 73);
      this.cboType.Name = "cboType";
      this.cboType.Size = new Size(298, 21);
      this.cboType.TabIndex = 1;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(364, 454);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(56, 23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.Label2.Location = new System.Drawing.Point(10, 109);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(93, 15);
      this.Label2.TabIndex = 14;
      this.Label2.Text = "Frequency";
      this.cboFrequency.FormattingEnabled = true;
      this.cboFrequency.Location = new System.Drawing.Point(122, 106);
      this.cboFrequency.Name = "cboFrequency";
      this.cboFrequency.Size = new Size(298, 21);
      this.cboFrequency.TabIndex = 2;
      this.Label5.Location = new System.Drawing.Point(8, 177);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(112, 18);
      this.Label5.TabIndex = 16;
      this.Label5.Text = "Prefered Engineer";
      this.cboPreferredEngineer.FormattingEnabled = true;
      this.cboPreferredEngineer.Location = new System.Drawing.Point(122, 173);
      this.cboPreferredEngineer.Name = "cboPreferredEngineer";
      this.cboPreferredEngineer.Size = new Size(298, 21);
      this.cboPreferredEngineer.TabIndex = 5;
      this.Label6.Location = new System.Drawing.Point(10, 214);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(106, 15);
      this.Label6.TabIndex = 18;
      this.Label6.Text = "Sub Contractor";
      this.cboSubContractor.FormattingEnabled = true;
      this.cboSubContractor.Location = new System.Drawing.Point(122, 211);
      this.cboSubContractor.Name = "cboSubContractor";
      this.cboSubContractor.Size = new Size(298, 21);
      this.cboSubContractor.TabIndex = 6;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Location = new System.Drawing.Point(13, 369);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.Size = new Size(133, 17);
      this.CheckBox1.TabIndex = 19;
      this.CheckBox1.Text = "System Generated";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.CheckBox1.Visible = false;
      this.Label1.Location = new System.Drawing.Point(8, 283);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 24);
      this.Label1.TabIndex = 2;
      this.Label1.Text = "Expected Cost";
      this.txtFilter.Location = new System.Drawing.Point(122, 281);
      this.txtFilter.Name = "txtFilter";
      this.txtFilter.Size = new Size(298, 21);
      this.txtFilter.TabIndex = 25;
      this.TextBox1.Location = new System.Drawing.Point(122, 246);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(298, 21);
      this.TextBox1.TabIndex = 20;
      this.Label7.Location = new System.Drawing.Point(8, 248);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(100, 24);
      this.Label7.TabIndex = 21;
      this.Label7.Text = "Hours Required";
      this.txtAdditional.Location = new System.Drawing.Point(122, 314);
      this.txtAdditional.Multiline = true;
      this.txtAdditional.Name = "txtAdditional";
      this.txtAdditional.Size = new Size(298, 125);
      this.txtAdditional.TabIndex = 30;
      this.Label8.Location = new System.Drawing.Point(8, 316);
      this.Label8.Name = "Label8";
      this.Label8.Size = new Size(100, 24);
      this.Label8.TabIndex = 23;
      this.Label8.Text = "Additional Notes";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(432, 481);
      this.ControlBox = false;
      this.Controls.Add((Control) this.txtAdditional);
      this.Controls.Add((Control) this.Label8);
      this.Controls.Add((Control) this.TextBox1);
      this.Controls.Add((Control) this.Label7);
      this.Controls.Add((Control) this.CheckBox1);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.cboSubContractor);
      this.Controls.Add((Control) this.Label5);
      this.Controls.Add((Control) this.cboPreferredEngineer);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.cboFrequency);
      this.Controls.Add((Control) this.Label4);
      this.Controls.Add((Control) this.dtpTargetDate);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.cboType);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.txtFilter);
      this.Controls.Add((Control) this.Label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(350, 392);
      this.Name = nameof (DLGSetupVisit);
      this.Text = "Find {0}";
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.txtFilter, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.cboType, 0);
      this.Controls.SetChildIndex((Control) this.Label3, 0);
      this.Controls.SetChildIndex((Control) this.dtpTargetDate, 0);
      this.Controls.SetChildIndex((Control) this.Label4, 0);
      this.Controls.SetChildIndex((Control) this.cboFrequency, 0);
      this.Controls.SetChildIndex((Control) this.Label2, 0);
      this.Controls.SetChildIndex((Control) this.cboPreferredEngineer, 0);
      this.Controls.SetChildIndex((Control) this.Label5, 0);
      this.Controls.SetChildIndex((Control) this.cboSubContractor, 0);
      this.Controls.SetChildIndex((Control) this.Label6, 0);
      this.Controls.SetChildIndex((Control) this.CheckBox1, 0);
      this.Controls.SetChildIndex((Control) this.Label7, 0);
      this.Controls.SetChildIndex((Control) this.TextBox1, 0);
      this.Controls.SetChildIndex((Control) this.Label8, 0);
      this.Controls.SetChildIndex((Control) this.txtAdditional, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.ActiveControl = (Control) this.txtFilter;
      this.txtFilter.Focus();
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

    public string SecondID
    {
      get
      {
        return this._2ndID;
      }
      set
      {
        this._2ndID = value;
      }
    }

    public string FrequencyID
    {
      get
      {
        return this._FrequencyID;
      }
      set
      {
        this._FrequencyID = value;
      }
    }

    public DateTime EffDate
    {
      get
      {
        return this._EffDate;
      }
      set
      {
        this._EffDate = value;
      }
    }

    private void cboFrequency_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboFrequency)) == 7.0)
      {
        this.CheckBox1.Enabled = true;
        this.dtpTargetDate.Enabled = true;
      }
      else
      {
        this.CheckBox1.Checked = true;
        this.CheckBox1.Enabled = false;
        this.dtpTargetDate.Enabled = false;
      }
    }

    private void DLGFindRecord_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (Operators.CompareString(Combo.get_GetSelectedItemValue(this.cboType), "0", false) == 0)
      {
        int num1 = (int) App.ShowMessage("No type selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboFrequency)) == 0)
      {
        int num2 = (int) App.ShowMessage("No Frequency selected", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (!Versioned.IsNumeric((object) this.txtFilter.Text))
      {
        int num3 = (int) App.ShowMessage("Please only input numbers into the cost box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (!Versioned.IsNumeric((object) this.TextBox1.Text) || Conversions.ToInteger(this.TextBox1.Text) == 0)
      {
        int num4 = (int) App.ShowMessage("Please enter a valid number into the Hours Required box", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
        this.DialogResult = DialogResult.OK;
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.CheckBox1.Checked)
        this.dtpTargetDate.Enabled = false;
      else
        this.dtpTargetDate.Enabled = true;
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }
  }
}
