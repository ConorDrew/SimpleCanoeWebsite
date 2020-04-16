// Decompiled with JetBrains decompiler
// Type: FSM.FRMAbout
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
  public class FRMAbout : FRMBaseForm, IForm
  {
    private IContainer components;

    public FRMAbout()
    {
      this.Load += new EventHandler(this.FRMAbout_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpVersionInformation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpAssemblyInformation { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVersion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txttrademark { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCopyright { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtproduct { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtcompany { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtdescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltrademark { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCopyright { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblproduct { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblcompany { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbldescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lbltitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpVersion { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual RichTextBox rtbLatestRelease { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtVersionHistory { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpVersionInformation = new GroupBox();
      this.grpAssemblyInformation = new GroupBox();
      this.Label1 = new Label();
      this.txtVersion = new TextBox();
      this.txttrademark = new TextBox();
      this.txtCopyright = new TextBox();
      this.txtproduct = new TextBox();
      this.txtcompany = new TextBox();
      this.txtdescription = new TextBox();
      this.txtTitle = new TextBox();
      this.lbltrademark = new Label();
      this.lblCopyright = new Label();
      this.lblproduct = new Label();
      this.lblcompany = new Label();
      this.lbldescription = new Label();
      this.lbltitle = new Label();
      this.grpVersion = new GroupBox();
      this.txtVersionHistory = new TextBox();
      this.rtbLatestRelease = new RichTextBox();
      this.grpVersionInformation.SuspendLayout();
      this.grpAssemblyInformation.SuspendLayout();
      this.grpVersion.SuspendLayout();
      this.SuspendLayout();
      this.grpVersionInformation.Controls.Add((Control) this.rtbLatestRelease);
      this.grpVersionInformation.Location = new System.Drawing.Point(8, 40);
      this.grpVersionInformation.Name = "grpVersionInformation";
      this.grpVersionInformation.Size = new Size(392, 184);
      this.grpVersionInformation.TabIndex = 2;
      this.grpVersionInformation.TabStop = false;
      this.grpVersionInformation.Text = "Latest Release Notes";
      this.grpAssemblyInformation.Controls.Add((Control) this.Label1);
      this.grpAssemblyInformation.Controls.Add((Control) this.txtVersion);
      this.grpAssemblyInformation.Controls.Add((Control) this.txttrademark);
      this.grpAssemblyInformation.Controls.Add((Control) this.txtCopyright);
      this.grpAssemblyInformation.Controls.Add((Control) this.txtproduct);
      this.grpAssemblyInformation.Controls.Add((Control) this.txtcompany);
      this.grpAssemblyInformation.Controls.Add((Control) this.txtdescription);
      this.grpAssemblyInformation.Controls.Add((Control) this.txtTitle);
      this.grpAssemblyInformation.Controls.Add((Control) this.lbltrademark);
      this.grpAssemblyInformation.Controls.Add((Control) this.lblCopyright);
      this.grpAssemblyInformation.Controls.Add((Control) this.lblproduct);
      this.grpAssemblyInformation.Controls.Add((Control) this.lblcompany);
      this.grpAssemblyInformation.Controls.Add((Control) this.lbldescription);
      this.grpAssemblyInformation.Controls.Add((Control) this.lbltitle);
      this.grpAssemblyInformation.Location = new System.Drawing.Point(8, 232);
      this.grpAssemblyInformation.Name = "grpAssemblyInformation";
      this.grpAssemblyInformation.Size = new Size(392, 200);
      this.grpAssemblyInformation.TabIndex = 3;
      this.grpAssemblyInformation.TabStop = false;
      this.grpAssemblyInformation.Text = "Assembly Information";
      this.Label1.Location = new System.Drawing.Point(8, 24);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(64, 16);
      this.Label1.TabIndex = 10;
      this.Label1.Text = "Version:";
      this.txtVersion.Location = new System.Drawing.Point(104, 24);
      this.txtVersion.Name = "txtVersion";
      this.txtVersion.ReadOnly = true;
      this.txtVersion.Size = new Size(280, 21);
      this.txtVersion.TabIndex = 2;
      this.txttrademark.Location = new System.Drawing.Point(104, 168);
      this.txttrademark.Name = "txttrademark";
      this.txttrademark.ReadOnly = true;
      this.txttrademark.Size = new Size(280, 21);
      this.txttrademark.TabIndex = 8;
      this.txtCopyright.Location = new System.Drawing.Point(104, 144);
      this.txtCopyright.Name = "txtCopyright";
      this.txtCopyright.ReadOnly = true;
      this.txtCopyright.Size = new Size(280, 21);
      this.txtCopyright.TabIndex = 7;
      this.txtproduct.Location = new System.Drawing.Point(104, 120);
      this.txtproduct.Name = "txtproduct";
      this.txtproduct.ReadOnly = true;
      this.txtproduct.Size = new Size(280, 21);
      this.txtproduct.TabIndex = 6;
      this.txtcompany.Location = new System.Drawing.Point(104, 96);
      this.txtcompany.Name = "txtcompany";
      this.txtcompany.ReadOnly = true;
      this.txtcompany.Size = new Size(280, 21);
      this.txtcompany.TabIndex = 5;
      this.txtdescription.Location = new System.Drawing.Point(104, 72);
      this.txtdescription.Name = "txtdescription";
      this.txtdescription.ReadOnly = true;
      this.txtdescription.Size = new Size(280, 21);
      this.txtdescription.TabIndex = 4;
      this.txtTitle.Location = new System.Drawing.Point(104, 48);
      this.txtTitle.Name = "txtTitle";
      this.txtTitle.ReadOnly = true;
      this.txtTitle.Size = new Size(280, 21);
      this.txtTitle.TabIndex = 3;
      this.lbltrademark.Location = new System.Drawing.Point(8, 168);
      this.lbltrademark.Name = "lbltrademark";
      this.lbltrademark.Size = new Size(72, 16);
      this.lbltrademark.TabIndex = 5;
      this.lbltrademark.Text = "Trademark:";
      this.lblCopyright.Location = new System.Drawing.Point(8, 144);
      this.lblCopyright.Name = "lblCopyright";
      this.lblCopyright.Size = new Size(64, 16);
      this.lblCopyright.TabIndex = 4;
      this.lblCopyright.Text = "Copyright:";
      this.lblproduct.Location = new System.Drawing.Point(8, 120);
      this.lblproduct.Name = "lblproduct";
      this.lblproduct.Size = new Size(56, 16);
      this.lblproduct.TabIndex = 3;
      this.lblproduct.Text = "Product:";
      this.lblcompany.Location = new System.Drawing.Point(8, 96);
      this.lblcompany.Name = "lblcompany";
      this.lblcompany.Size = new Size(64, 16);
      this.lblcompany.TabIndex = 2;
      this.lblcompany.Text = "Company:";
      this.lbldescription.Location = new System.Drawing.Point(8, 72);
      this.lbldescription.Name = "lbldescription";
      this.lbldescription.Size = new Size(80, 16);
      this.lbldescription.TabIndex = 1;
      this.lbldescription.Text = "Description:";
      this.lbltitle.Location = new System.Drawing.Point(8, 48);
      this.lbltitle.Name = "lbltitle";
      this.lbltitle.Size = new Size(40, 16);
      this.lbltitle.TabIndex = 0;
      this.lbltitle.Text = "Title:";
      this.grpVersion.Controls.Add((Control) this.txtVersionHistory);
      this.grpVersion.Font = new Font("Verdana", 8.25f);
      this.grpVersion.Location = new System.Drawing.Point(408, 40);
      this.grpVersion.Name = "grpVersion";
      this.grpVersion.Size = new Size(409, 392);
      this.grpVersion.TabIndex = 4;
      this.grpVersion.TabStop = false;
      this.grpVersion.Text = "Version History";
      this.txtVersionHistory.Location = new System.Drawing.Point(8, 16);
      this.txtVersionHistory.Multiline = true;
      this.txtVersionHistory.Name = "txtVersionHistory";
      this.txtVersionHistory.ReadOnly = true;
      this.txtVersionHistory.ScrollBars = ScrollBars.Both;
      this.txtVersionHistory.Size = new Size(392, 368);
      this.txtVersionHistory.TabIndex = 9;
      this.rtbLatestRelease.Dock = DockStyle.Fill;
      this.rtbLatestRelease.Location = new System.Drawing.Point(3, 17);
      this.rtbLatestRelease.Name = "rtbLatestRelease";
      this.rtbLatestRelease.Size = new Size(386, 164);
      this.rtbLatestRelease.TabIndex = 0;
      this.rtbLatestRelease.Text = "";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(826, 433);
      this.Controls.Add((Control) this.grpVersion);
      this.Controls.Add((Control) this.grpAssemblyInformation);
      this.Controls.Add((Control) this.grpVersionInformation);
      this.MaximizeBox = false;
      this.MaximumSize = new Size(842, 500);
      this.MinimizeBox = false;
      this.MinimumSize = new Size(832, 472);
      this.Name = nameof (FRMAbout);
      this.Text = "About";
      this.Controls.SetChildIndex((Control) this.grpVersionInformation, 0);
      this.Controls.SetChildIndex((Control) this.grpAssemblyInformation, 0);
      this.Controls.SetChildIndex((Control) this.grpVersion, 0);
      this.grpVersionInformation.ResumeLayout(false);
      this.grpAssemblyInformation.ResumeLayout(false);
      this.grpAssemblyInformation.PerformLayout();
      this.grpVersion.ResumeLayout(false);
      this.grpVersion.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.Populate();
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

    private void FRMAbout_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    public void Populate()
    {
      this.txtVersion.Text = App.TheSystem.Configuration.SystemVersion;
      this.txtTitle.Text = App.TheSystem.Title;
      this.txtdescription.Text = App.TheSystem.Description;
      this.txtcompany.Text = App.TheSystem.Company;
      this.txtproduct.Text = App.TheSystem.Product;
      this.txtCopyright.Text = App.TheSystem.Copyright;
      this.txttrademark.Text = App.TheSystem.Trademark;
      this.txtVersionHistory.Text = Helper.GetTextResource("Versions.txt");
      this.rtbLatestRelease.Text = Helper.GetTextResource(App.ReleaseNoteTextFile);
    }
  }
}
