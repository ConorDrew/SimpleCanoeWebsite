// Decompiled with JetBrains decompiler
// Type: FSM.FRMDuplicateInvoices
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using FSM.Importer;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMDuplicateInvoices : FRMBaseForm
  {
    private IContainer components;
    private List<DuplicateInvoice> _duplicateInvoices;

    public FRMDuplicateInvoices(List<DuplicateInvoice> duplicateInvoices)
    {
      this.Load += new EventHandler(this.FRMDuplicateInovoices_Load);
      this.FormClosing += new FormClosingEventHandler(this.FRMDuplicateInvoices_FormClosing);
      this._duplicateInvoices = new List<DuplicateInvoice>();
      this.InitializeComponent();
      this._duplicateInvoices = duplicateInvoices;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TabControl tcData { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.tcData = new TabControl();
      this.SuspendLayout();
      this.tcData.Dock = DockStyle.Fill;
      this.tcData.Location = new System.Drawing.Point(0, 32);
      this.tcData.Name = "tcData";
      this.tcData.SelectedIndex = 0;
      this.tcData.Size = new Size(1008, 430);
      this.tcData.TabIndex = 9;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1008, 462);
      this.Controls.Add((Control) this.tcData);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(848, 496);
      this.Name = nameof (FRMDuplicateInvoices);
      this.Text = "Job Portal - Duplicate Imports";
      this.Controls.SetChildIndex((Control) this.tcData, 0);
      this.ResumeLayout(false);
    }

    private List<DuplicateInvoice> DuplicateInvoices
    {
      get
      {
        return this._duplicateInvoices;
      }
    }

    public IUserControl LoadedControl
    {
      get
      {
        return (IUserControl) null;
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMDuplicateInovoices_Load(object sender, EventArgs e)
    {
      this.tcData.TabPages.Clear();
      TabPage tabPage = new TabPage();
      DataView dataView = new DataView(Helper.ToDataTable<DuplicateInvoice>((IList<DuplicateInvoice>) this.DuplicateInvoices));
      UCDataPODuplicateInvoice duplicateInvoice = new UCDataPODuplicateInvoice();
      duplicateInvoice.Dock = DockStyle.Fill;
      duplicateInvoice.Data = dataView;
      tabPage.Controls.Add((Control) duplicateInvoice);
      this.tcData.TabPages.Add(tabPage);
      this.tcData.SelectedIndex = 0;
    }

    private void FRMDuplicateInvoices_FormClosing(object sender, FormClosingEventArgs e)
    {
      try
      {
        if (e.CloseReason != CloseReason.FormOwnerClosing && e.CloseReason != CloseReason.UserClosing || Interaction.MsgBox((object) "Are you sure?", MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Form closing") != MsgBoxResult.No)
          return;
        e.Cancel = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) Interaction.MsgBox((object) ex.Message, MsgBoxStyle.OkOnly, (object) null);
        ProjectData.ClearProjectError();
      }
    }
  }
}
