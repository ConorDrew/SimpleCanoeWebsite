// Decompiled with JetBrains decompiler
// Type: FSM.UCJobCostings
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.JobInstalls;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FSM
{
  public class UCJobCostings : UCBase
  {
    private IContainer components;
    private JobInstall _JI;
    private int _IDToLinkTo;
    private DataView _dvDocuments;

    public UCJobCostings(int IDToLinkToIn)
    {
      this.Load += new EventHandler(this.UCJobCost_Load);
      this._IDToLinkTo = 0;
      this.InitializeComponent();
      this.IDToLinkTo = IDToLinkToIn;
      this.Dock = DockStyle.Fill;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.Name = nameof (UCJobCostings);
      this.Size = new Size(504, 560);
      this.ResumeLayout(false);
    }

    private JobInstall JI
    {
      get
      {
        return this._JI;
      }
      set
      {
        this._JI = value;
      }
    }

    public int IDToLinkTo
    {
      get
      {
        return this._IDToLinkTo;
      }
      set
      {
        this._IDToLinkTo = value;
        if (this.IDToLinkTo == 0)
          ;
      }
    }

    private void SetupDocumentsDataGrid()
    {
    }

    private void UCJobCost_Load(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
    }

    public void Populate()
    {
    }
  }
}
