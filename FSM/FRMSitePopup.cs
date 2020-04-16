// Decompiled with JetBrains decompiler
// Type: FSM.FRMSitePopup
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Sites;
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
  public class FRMSitePopup : FRMBaseForm, IForm
  {
    private IContainer components;
    private FSM.Entity.Sites.Site _currentSite;

    public FRMSitePopup()
    {
      this.Load += new EventHandler(this.FRMSitePopup_Load);
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnSendEmailToSite
    {
      get
      {
        return this._btnSendEmailToSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSendEmailToSite_Click);
        Button btnSendEmailToSite1 = this._btnSendEmailToSite;
        if (btnSendEmailToSite1 != null)
          btnSendEmailToSite1.Click -= eventHandler;
        this._btnSendEmailToSite = value;
        Button btnSendEmailToSite2 = this._btnSendEmailToSite;
        if (btnSendEmailToSite2 == null)
          return;
        btnSendEmailToSite2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTown { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCounty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnClose
    {
      get
      {
        return this._btnClose;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnClose_Click);
        Button btnClose1 = this._btnClose;
        if (btnClose1 != null)
          btnClose1.Click -= eventHandler;
        this._btnClose = value;
        Button btnClose2 = this._btnClose;
        if (btnClose2 == null)
          return;
        btnClose2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnClose = new Button();
      this.btnSendEmailToSite = new Button();
      this.txtName = new TextBox();
      this.Label3 = new Label();
      this.txtAddress1 = new TextBox();
      this.lblAddress1 = new Label();
      this.txtAddress2 = new TextBox();
      this.lblAddress2 = new Label();
      this.txtAddress3 = new TextBox();
      this.lblAddress3 = new Label();
      this.txtAddress4 = new TextBox();
      this.lblTown = new Label();
      this.txtAddress5 = new TextBox();
      this.lblCounty = new Label();
      this.txtPostcode = new TextBox();
      this.lblPostcode = new Label();
      this.txtTelephoneNum = new TextBox();
      this.lblTelephoneNum = new Label();
      this.txtFaxNum = new TextBox();
      this.lblFaxNum = new Label();
      this.txtEmailAddress = new TextBox();
      this.lblEmailAddress = new Label();
      this.SuspendLayout();
      this.btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnClose.Location = new System.Drawing.Point(10, 290);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new Size(56, 25);
      this.btnClose.TabIndex = 12;
      this.btnClose.Text = "Close";
      this.btnSendEmailToSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSendEmailToSite.Location = new System.Drawing.Point(541, 264);
      this.btnSendEmailToSite.Name = "btnSendEmailToSite";
      this.btnSendEmailToSite.Size = new Size(75, 23);
      this.btnSendEmailToSite.TabIndex = 11;
      this.btnSendEmailToSite.Text = "Email";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(105, 45);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new Size(511, 21);
      this.txtName.TabIndex = 1;
      this.txtName.Tag = (object) "";
      this.Label3.Location = new System.Drawing.Point(7, 45);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(64, 20);
      this.Label3.TabIndex = 23;
      this.Label3.Text = "Name";
      this.txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress1.Location = new System.Drawing.Point(105, 69);
      this.txtAddress1.MaxLength = (int) byte.MaxValue;
      this.txtAddress1.Name = "txtAddress1";
      this.txtAddress1.ReadOnly = true;
      this.txtAddress1.Size = new Size(511, 21);
      this.txtAddress1.TabIndex = 2;
      this.txtAddress1.Tag = (object) "Site.Address1";
      this.lblAddress1.Location = new System.Drawing.Point(7, 69);
      this.lblAddress1.Name = "lblAddress1";
      this.lblAddress1.Size = new Size(67, 20);
      this.lblAddress1.TabIndex = 26;
      this.lblAddress1.Text = "Address 1";
      this.txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress2.Location = new System.Drawing.Point(105, 93);
      this.txtAddress2.MaxLength = (int) byte.MaxValue;
      this.txtAddress2.Name = "txtAddress2";
      this.txtAddress2.ReadOnly = true;
      this.txtAddress2.Size = new Size(511, 21);
      this.txtAddress2.TabIndex = 3;
      this.txtAddress2.Tag = (object) "Site.Address2";
      this.lblAddress2.Location = new System.Drawing.Point(7, 93);
      this.lblAddress2.Name = "lblAddress2";
      this.lblAddress2.Size = new Size(72, 20);
      this.lblAddress2.TabIndex = 28;
      this.lblAddress2.Text = "Address 2";
      this.txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress3.Location = new System.Drawing.Point(105, 117);
      this.txtAddress3.MaxLength = (int) byte.MaxValue;
      this.txtAddress3.Name = "txtAddress3";
      this.txtAddress3.ReadOnly = true;
      this.txtAddress3.Size = new Size(511, 21);
      this.txtAddress3.TabIndex = 4;
      this.txtAddress3.Tag = (object) "Site.Address3";
      this.lblAddress3.Location = new System.Drawing.Point(7, 117);
      this.lblAddress3.Name = "lblAddress3";
      this.lblAddress3.Size = new Size(64, 20);
      this.lblAddress3.TabIndex = 32;
      this.lblAddress3.Text = "Address 3";
      this.txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress4.Location = new System.Drawing.Point(105, 141);
      this.txtAddress4.MaxLength = 100;
      this.txtAddress4.Name = "txtAddress4";
      this.txtAddress4.ReadOnly = true;
      this.txtAddress4.Size = new Size(511, 21);
      this.txtAddress4.TabIndex = 5;
      this.txtAddress4.Tag = (object) "Site.Town";
      this.lblTown.Location = new System.Drawing.Point(7, 141);
      this.lblTown.Name = "lblTown";
      this.lblTown.Size = new Size(67, 20);
      this.lblTown.TabIndex = 35;
      this.lblTown.Text = "Address 4";
      this.txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress5.Location = new System.Drawing.Point(105, 165);
      this.txtAddress5.MaxLength = 100;
      this.txtAddress5.Name = "txtAddress5";
      this.txtAddress5.ReadOnly = true;
      this.txtAddress5.Size = new Size(511, 21);
      this.txtAddress5.TabIndex = 6;
      this.txtAddress5.Tag = (object) "Site.County";
      this.lblCounty.Location = new System.Drawing.Point(7, 165);
      this.lblCounty.Name = "lblCounty";
      this.lblCounty.Size = new Size(64, 20);
      this.lblCounty.TabIndex = 37;
      this.lblCounty.Text = "Address 5";
      this.txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPostcode.Location = new System.Drawing.Point(105, 189);
      this.txtPostcode.MaxLength = 10;
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.ReadOnly = true;
      this.txtPostcode.Size = new Size(511, 21);
      this.txtPostcode.TabIndex = 7;
      this.txtPostcode.Tag = (object) "Site.Postcode";
      this.lblPostcode.Location = new System.Drawing.Point(7, 189);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(67, 20);
      this.lblPostcode.TabIndex = 40;
      this.lblPostcode.Text = "Postcode";
      this.txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTelephoneNum.Location = new System.Drawing.Point(105, 213);
      this.txtTelephoneNum.MaxLength = 50;
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.ReadOnly = true;
      this.txtTelephoneNum.Size = new Size(511, 21);
      this.txtTelephoneNum.TabIndex = 8;
      this.txtTelephoneNum.Tag = (object) "Site.TelephoneNum";
      this.lblTelephoneNum.Location = new System.Drawing.Point(7, 213);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(107, 20);
      this.lblTelephoneNum.TabIndex = 41;
      this.lblTelephoneNum.Text = "Tel";
      this.txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFaxNum.Location = new System.Drawing.Point(105, 237);
      this.txtFaxNum.MaxLength = 50;
      this.txtFaxNum.Name = "txtFaxNum";
      this.txtFaxNum.ReadOnly = true;
      this.txtFaxNum.Size = new Size(511, 21);
      this.txtFaxNum.TabIndex = 9;
      this.txtFaxNum.Tag = (object) "Site.FaxNum";
      this.lblFaxNum.Location = new System.Drawing.Point(7, 237);
      this.lblFaxNum.Name = "lblFaxNum";
      this.lblFaxNum.Size = new Size(72, 20);
      this.lblFaxNum.TabIndex = 42;
      this.lblFaxNum.Text = "Fax";
      this.txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEmailAddress.Location = new System.Drawing.Point(105, 263);
      this.txtEmailAddress.MaxLength = 100;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.ReadOnly = true;
      this.txtEmailAddress.Size = new Size(430, 21);
      this.txtEmailAddress.TabIndex = 10;
      this.txtEmailAddress.Tag = (object) "Site.EmailAddress";
      this.lblEmailAddress.Location = new System.Drawing.Point(7, 261);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(99, 20);
      this.lblEmailAddress.TabIndex = 43;
      this.lblEmailAddress.Text = "Email Address";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(628, 327);
      this.Controls.Add((Control) this.btnSendEmailToSite);
      this.Controls.Add((Control) this.txtName);
      this.Controls.Add((Control) this.Label3);
      this.Controls.Add((Control) this.txtAddress1);
      this.Controls.Add((Control) this.lblAddress1);
      this.Controls.Add((Control) this.txtAddress2);
      this.Controls.Add((Control) this.lblAddress2);
      this.Controls.Add((Control) this.txtAddress3);
      this.Controls.Add((Control) this.lblAddress3);
      this.Controls.Add((Control) this.txtAddress4);
      this.Controls.Add((Control) this.lblTown);
      this.Controls.Add((Control) this.txtAddress5);
      this.Controls.Add((Control) this.lblCounty);
      this.Controls.Add((Control) this.txtPostcode);
      this.Controls.Add((Control) this.lblPostcode);
      this.Controls.Add((Control) this.txtTelephoneNum);
      this.Controls.Add((Control) this.lblTelephoneNum);
      this.Controls.Add((Control) this.txtFaxNum);
      this.Controls.Add((Control) this.lblFaxNum);
      this.Controls.Add((Control) this.txtEmailAddress);
      this.Controls.Add((Control) this.lblEmailAddress);
      this.Controls.Add((Control) this.btnClose);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new Size(636, 361);
      this.Name = "frmCandidateAssessment";
      this.Text = "Property : ID {0}";
      this.Controls.SetChildIndex((Control) this.btnClose, 0);
      this.Controls.SetChildIndex((Control) this.lblEmailAddress, 0);
      this.Controls.SetChildIndex((Control) this.txtEmailAddress, 0);
      this.Controls.SetChildIndex((Control) this.lblFaxNum, 0);
      this.Controls.SetChildIndex((Control) this.txtFaxNum, 0);
      this.Controls.SetChildIndex((Control) this.lblTelephoneNum, 0);
      this.Controls.SetChildIndex((Control) this.txtTelephoneNum, 0);
      this.Controls.SetChildIndex((Control) this.lblPostcode, 0);
      this.Controls.SetChildIndex((Control) this.txtPostcode, 0);
      this.Controls.SetChildIndex((Control) this.lblCounty, 0);
      this.Controls.SetChildIndex((Control) this.txtAddress5, 0);
      this.Controls.SetChildIndex((Control) this.lblTown, 0);
      this.Controls.SetChildIndex((Control) this.txtAddress4, 0);
      this.Controls.SetChildIndex((Control) this.lblAddress3, 0);
      this.Controls.SetChildIndex((Control) this.txtAddress3, 0);
      this.Controls.SetChildIndex((Control) this.lblAddress2, 0);
      this.Controls.SetChildIndex((Control) this.txtAddress2, 0);
      this.Controls.SetChildIndex((Control) this.lblAddress1, 0);
      this.Controls.SetChildIndex((Control) this.txtAddress1, 0);
      this.Controls.SetChildIndex((Control) this.Label3, 0);
      this.Controls.SetChildIndex((Control) this.txtName, 0);
      this.Controls.SetChildIndex((Control) this.btnSendEmailToSite, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.CurrentSite = App.DB.Sites.Get((object) Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.get_GetParameter(0))), SiteSQL.GetBy.SiteId, (object) null);
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
    }

    public FSM.Entity.Sites.Site CurrentSite
    {
      get
      {
        return this._currentSite;
      }
      set
      {
        this._currentSite = value;
        this.Populate();
      }
    }

    private void FRMSitePopup_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSendEmailToSite_Click(object sender, EventArgs e)
    {
      Process process = new Process();
      process.StartInfo.FileName = "mailto:" + this.CurrentSite.EmailAddress;
      process.StartInfo.UseShellExecute = true;
      process.StartInfo.RedirectStandardOutput = false;
      process.Start();
      process.Dispose();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void Populate()
    {
      this.Text = "Property : ID " + Conversions.ToString(this.CurrentSite.SiteID);
      this.txtName.Text = this.CurrentSite.Name;
      this.txtAddress1.Text = this.CurrentSite.Address1;
      this.txtAddress2.Text = this.CurrentSite.Address2;
      this.txtAddress3.Text = this.CurrentSite.Address3;
      this.txtAddress4.Text = this.CurrentSite.Address4;
      this.txtAddress5.Text = this.CurrentSite.Address5;
      this.txtPostcode.Text = this.CurrentSite.Postcode;
      this.txtTelephoneNum.Text = this.CurrentSite.TelephoneNum;
      this.txtFaxNum.Text = this.CurrentSite.FaxNum;
      this.txtEmailAddress.Text = this.CurrentSite.EmailAddress;
    }
  }
}
