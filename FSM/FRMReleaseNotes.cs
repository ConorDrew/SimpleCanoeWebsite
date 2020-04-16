// Decompiled with JetBrains decompiler
// Type: FSM.FRMReleaseNotes
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sys;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMReleaseNotes : FRMBaseForm, IForm
  {
    private IContainer components;
    public Process process;

    public FRMReleaseNotes()
    {
      this.Load += new EventHandler(this.FRMReleaseNotes_Load);
      this.process = new Process();
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual RichTextBox rtbReleaseNotes
    {
      get
      {
        return this._rtbReleaseNotes;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        LinkClickedEventHandler clickedEventHandler = new LinkClickedEventHandler(this.rtbReleaseNotes_LinkClicked);
        RichTextBox rtbReleaseNotes1 = this._rtbReleaseNotes;
        if (rtbReleaseNotes1 != null)
          rtbReleaseNotes1.LinkClicked -= clickedEventHandler;
        this._rtbReleaseNotes = value;
        RichTextBox rtbReleaseNotes2 = this._rtbReleaseNotes;
        if (rtbReleaseNotes2 == null)
          return;
        rtbReleaseNotes2.LinkClicked += clickedEventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.rtbReleaseNotes = new RichTextBox();
      this.SuspendLayout();
      this.rtbReleaseNotes.Dock = DockStyle.Fill;
      this.rtbReleaseNotes.Location = new System.Drawing.Point(0, 32);
      this.rtbReleaseNotes.Name = "rtbReleaseNotes";
      this.rtbReleaseNotes.Size = new Size(478, 300);
      this.rtbReleaseNotes.TabIndex = 2;
      this.rtbReleaseNotes.Text = "";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(478, 332);
      this.Controls.Add((Control) this.rtbReleaseNotes);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(1000, 1000);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(416, 208);
      this.Name = nameof (FRMReleaseNotes);
      this.Controls.SetChildIndex((Control) this.rtbReleaseNotes, 0);
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.FillReleaseNotes();
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

    private void FRMReleaseNotes_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void FillReleaseNotes()
    {
      this.rtbReleaseNotes.Text = Helper.GetTextResource(App.ReleaseNoteTextFile);
    }

    private void rtbReleaseNotes_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      this.process = Process.Start(e.LinkText);
    }
  }
}
