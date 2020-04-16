// Decompiled with JetBrains decompiler
// Type: FSM.FRMSelectDatabase
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  [DesignerGenerated]
  public class FRMSelectDatabase : FRMBaseForm
  {
    private DataTable _dbs;
    private IContainer components;
    private int _selectdDb;

    private DataTable Databases
    {
      get
      {
        return this._dbs;
      }
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    public FRMSelectDatabase(DataTable dbs)
    {
      this.Load += new EventHandler(this.FRMSelectDatabase_Load);
      this._selectdDb = 0;
      this._dbs = dbs;
      this.InitializeComponent();
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.cboDatabase = new ComboBox();
      this.btnOk = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.btnOk);
      this.GroupBox1.Controls.Add((Control) this.cboDatabase);
      this.GroupBox1.Location = new System.Drawing.Point(12, 38);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(356, 95);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Please Select The Database.";
      this.cboDatabase.FormattingEnabled = true;
      this.cboDatabase.Location = new System.Drawing.Point(6, 29);
      this.cboDatabase.Name = "cboDatabase";
      this.cboDatabase.Size = new Size(340, 21);
      this.cboDatabase.TabIndex = 0;
      this.btnOk.Location = new System.Drawing.Point(271, 66);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new Size(75, 23);
      this.btnOk.TabIndex = 15;
      this.btnOk.Text = "OK";
      this.ClientSize = new Size(380, 145);
      this.ControlBox = false;
      this.Controls.Add((Control) this.GroupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = nameof (FRMSelectDatabase);
      this.ShowInTaskbar = true;
      this.Controls.SetChildIndex((Control) this.GroupBox1, 0);
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDatabase { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOk
    {
      get
      {
        return this._btnOk;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOk_Click);
        Button btnOk1 = this._btnOk;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOk = value;
        Button btnOk2 = this._btnOk;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    public int SelectedDb
    {
      get
      {
        return this._selectdDb;
      }
      set
      {
        this._selectdDb = value;
      }
    }

    private void FRMSelectDatabase_Load(object sender, EventArgs e)
    {
      ComboBox cboDatabase = this.cboDatabase;
      Combo.SetUpCombo(ref cboDatabase, this.Databases, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboDatabase = cboDatabase;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboDatabase)) == 0.0)
      {
        int num = (int) Interaction.MsgBox((object) "Please a database to use", MsgBoxStyle.OkOnly, (object) MessageBoxIcon.Hand);
      }
      else
      {
        this.SelectedDb = checked ((int) Math.Round(unchecked (Conversions.ToDouble(Combo.get_GetSelectedItemValue(this.cboDatabase)) - 1.0)));
        if (this.Modal)
          this.Close();
        else
          this.Dispose();
      }
    }
  }
}
