// Decompiled with JetBrains decompiler
// Type: FSM.FRMMoveParts
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.EngineerVisits;
using FSM.Entity.Sys;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMMoveParts : Form
  {
    private IContainer components;
    private int _EngineerVisitId;
    private string _jobNumber;
    private bool changeJob;

    public FRMMoveParts()
    {
      this.Load += new EventHandler(this.FRMMoveParts_Load);
      this.changeJob = false;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FRMMoveParts));
      this.GroupBox1 = new GroupBox();
      this.btnCancel = new Button();
      this.btnOK = new Button();
      this.cboVisit = new ComboBox();
      this.txtJobNumber = new TextBox();
      this.lblJob = new Label();
      this.btnChange = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.btnChange);
      this.GroupBox1.Controls.Add((Control) this.txtJobNumber);
      this.GroupBox1.Controls.Add((Control) this.lblJob);
      this.GroupBox1.Controls.Add((Control) this.btnCancel);
      this.GroupBox1.Controls.Add((Control) this.btnOK);
      this.GroupBox1.Controls.Add((Control) this.cboVisit);
      this.GroupBox1.Dock = DockStyle.Fill;
      this.GroupBox1.Location = new System.Drawing.Point(0, 0);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(414, 112);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Select Visit To Move Parts to";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(7, 82);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(333, 83);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 1;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.cboVisit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboVisit.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cboVisit.FormattingEnabled = true;
      this.cboVisit.Location = new System.Drawing.Point(7, 51);
      this.cboVisit.Name = "cboVisit";
      this.cboVisit.Size = new Size(401, 21);
      this.cboVisit.TabIndex = 0;
      this.txtJobNumber.Location = new System.Drawing.Point(64, 22);
      this.txtJobNumber.Name = "txtJobNumber";
      this.txtJobNumber.Size = new Size(84, 20);
      this.txtJobNumber.TabIndex = 5;
      this.lblJob.Location = new System.Drawing.Point(12, 25);
      this.lblJob.Name = "lblJob";
      this.lblJob.Size = new Size(67, 23);
      this.lblJob.TabIndex = 4;
      this.lblJob.Text = "Job No:";
      this.btnChange.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnChange.Location = new System.Drawing.Point(164, 20);
      this.btnChange.Name = "btnChange";
      this.btnChange.Size = new Size(75, 23);
      this.btnChange.TabIndex = 6;
      this.btnChange.Text = "Change";
      this.btnChange.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(414, 112);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (FRMMoveParts);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Move Parts";
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

    internal virtual ComboBox cboVisit { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual Button btnChange
    {
      get
      {
        return this._btnChange;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnChange_Click);
        Button btnChange1 = this._btnChange;
        if (btnChange1 != null)
          btnChange1.Click -= eventHandler;
        this._btnChange = value;
        Button btnChange2 = this._btnChange;
        if (btnChange2 == null)
          return;
        btnChange2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtJobNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblJob { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public int EngineerVisitId
    {
      get
      {
        return this._EngineerVisitId;
      }
      set
      {
        this._EngineerVisitId = value;
      }
    }

    public string JobNumber
    {
      get
      {
        return this._jobNumber;
      }
      set
      {
        this._jobNumber = value;
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboVisit)) == 0.0)
      {
        int num = (int) App.ShowMessage("Please select a Visit", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      ComboBox cboVisit = this.cboVisit;
      Combo.SetSelectedComboItem_By_Value(ref cboVisit, Conversions.ToString(0));
      this.cboVisit = cboVisit;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMMoveParts_Load(object sender, EventArgs e)
    {
      this.txtJobNumber.Text = this.JobNumber;
      this.UpdateVisitList(this.EngineerVisitId, false);
    }

    private void btnChange_Click(object sender, EventArgs e)
    {
      if (this.changeJob)
      {
        string jobNumber = Helper.MakeStringValid((object) this.txtJobNumber.Text).Trim();
        EngineerVisit lastForJob = App.DB.EngineerVisits.EngineerVisits_Get_LastForJob(0, jobNumber);
        if (lastForJob == null)
        {
          int num = (int) App.ShowMessage("No Job Found!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
          this.UpdateVisitList(lastForJob.EngineerVisitID, true);
      }
      else
      {
        this.changeJob = true;
        this.txtJobNumber.Enabled = true;
        this.btnChange.Text = "Search";
        this.cboVisit.Enabled = false;
      }
    }

    private void UpdateVisitList(int visitId, bool includeCurrentVisit)
    {
      DataTable futureVisits = App.DB.EngineerVisits.GetFutureVisits(visitId, includeCurrentVisit);
      DataTable DT = new DataTable();
      DT.Columns.Add("ManagerID");
      DT.Columns.Add("Name");
      IEnumerator enumerator;
      try
      {
        enumerator = futureVisits.Rows.GetEnumerator();
        while (enumerator.MoveNext())
        {
          DataRow current = (DataRow) enumerator.Current;
          DataRow row = DT.NewRow();
          row["ManagerID"] = RuntimeHelpers.GetObjectValue(current["EngineerVisitID"]);
          row["Name"] = Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(current["EngineerVisitID"], (object) " - "), current["Engineer"]), (object) " - "), current["DateTime"]), (object) " - "), current["Notes"]);
          DT.Rows.Add(row);
        }
      }
      finally
      {
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
      ComboBox cboVisit = this.cboVisit;
      Combo.SetUpCombo(ref cboVisit, DT, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboVisit = cboVisit;
      this.txtJobNumber.Enabled = false;
      this.cboVisit.Enabled = true;
      this.btnChange.Text = "Change";
      this.changeJob = false;
    }
  }
}
