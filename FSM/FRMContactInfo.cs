// Decompiled with JetBrains decompiler
// Type: FSM.FRMContactInfo
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Customers;
using FSM.Entity.Sites;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class FRMContactInfo : FRMBaseForm, IForm
  {
    private IContainer components;
    private FSM.Entity.Sites.Site _osite;

    public FRMContactInfo(FSM.Entity.Sites.Site oSite)
    {
      this.Load += new EventHandler(this.FRMContactInfo_Load);
      this.FormClosing += new FormClosingEventHandler(this.FRMContactInfo_FormClosing);
      this.InitializeComponent();
      this.CurrentSite = oSite;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHeadOffice { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label9 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtCustomerName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSiteName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnSave
    {
      get
      {
        return this._btnSave;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSave_Click);
        Button btnSave1 = this._btnSave;
        if (btnSave1 != null)
          btnSave1.Click -= eventHandler;
        this._btnSave = value;
        Button btnSave2 = this._btnSave;
        if (btnSave2 == null)
          return;
        btnSave2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnOK { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnOK = new Button();
      this.txtTelephoneNum = new TextBox();
      this.lblTelephoneNum = new Label();
      this.txtEmailAddress = new TextBox();
      this.lblEmailAddress = new Label();
      this.txtFaxNum = new TextBox();
      this.lblFaxNum = new Label();
      this.txtHeadOffice = new TextBox();
      this.Label9 = new Label();
      this.txtCustomerName = new TextBox();
      this.Label2 = new Label();
      this.txtSiteName = new TextBox();
      this.Label1 = new Label();
      this.btnSave = new Button();
      this.grpSite = new GroupBox();
      this.SuspendLayout();
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(595, 236);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.txtTelephoneNum.Location = new System.Drawing.Point(125, 152);
      this.txtTelephoneNum.MaxLength = 50;
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.Size = new Size(132, 21);
      this.txtTelephoneNum.TabIndex = 101;
      this.txtTelephoneNum.Tag = (object) "Site.TelephoneNum";
      this.lblTelephoneNum.Location = new System.Drawing.Point(24, 155);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(48, 20);
      this.lblTelephoneNum.TabIndex = 107;
      this.lblTelephoneNum.Text = "Tel";
      this.txtEmailAddress.Location = new System.Drawing.Point(125, 182);
      this.txtEmailAddress.MaxLength = 100;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(223, 21);
      this.txtEmailAddress.TabIndex = 103;
      this.txtEmailAddress.Tag = (object) "Site.EmailAddress";
      this.lblEmailAddress.Location = new System.Drawing.Point(24, 185);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(98, 20);
      this.lblEmailAddress.TabIndex = 106;
      this.lblEmailAddress.Text = "Email Address";
      this.txtFaxNum.Location = new System.Drawing.Point(362, 154);
      this.txtFaxNum.MaxLength = 50;
      this.txtFaxNum.Name = "txtFaxNum";
      this.txtFaxNum.Size = new Size(145, 21);
      this.txtFaxNum.TabIndex = 102;
      this.txtFaxNum.Tag = (object) "Site.FaxNum";
      this.lblFaxNum.Location = new System.Drawing.Point(288, 155);
      this.lblFaxNum.Name = "lblFaxNum";
      this.lblFaxNum.Size = new Size(50, 20);
      this.lblFaxNum.TabIndex = 104;
      this.lblFaxNum.Text = "Mobile";
      this.txtHeadOffice.Location = new System.Drawing.Point(125, 91);
      this.txtHeadOffice.Name = "txtHeadOffice";
      this.txtHeadOffice.ReadOnly = true;
      this.txtHeadOffice.Size = new Size(382, 21);
      this.txtHeadOffice.TabIndex = 109;
      this.Label9.Location = new System.Drawing.Point(24, 89);
      this.Label9.Name = "Label9";
      this.Label9.Size = new Size(80, 23);
      this.Label9.TabIndex = 113;
      this.Label9.Text = "Head Office:";
      this.txtCustomerName.Location = new System.Drawing.Point(125, 62);
      this.txtCustomerName.Name = "txtCustomerName";
      this.txtCustomerName.ReadOnly = true;
      this.txtCustomerName.Size = new Size(382, 21);
      this.txtCustomerName.TabIndex = 108;
      this.Label2.Location = new System.Drawing.Point(24, 122);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(80, 23);
      this.Label2.TabIndex = 112;
      this.Label2.Text = "Property:";
      this.txtSiteName.Location = new System.Drawing.Point(125, 120);
      this.txtSiteName.Name = "txtSiteName";
      this.txtSiteName.ReadOnly = true;
      this.txtSiteName.Size = new Size(382, 21);
      this.txtSiteName.TabIndex = 110;
      this.Label1.Location = new System.Drawing.Point(24, 62);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(80, 23);
      this.Label1.TabIndex = 111;
      this.Label1.Text = "Customer:";
      this.btnSave.Location = new System.Drawing.Point(426, 243);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new Size(109, 30);
      this.btnSave.TabIndex = 105;
      this.btnSave.Text = "Save";
      this.grpSite.Location = new System.Drawing.Point(6, 38);
      this.grpSite.Name = "grpSite";
      this.grpSite.Size = new Size(529, 188);
      this.grpSite.TabIndex = 114;
      this.grpSite.TabStop = false;
      this.grpSite.Text = "Site ";
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(547, 288);
      this.Controls.Add((Control) this.txtHeadOffice);
      this.Controls.Add((Control) this.Label9);
      this.Controls.Add((Control) this.txtCustomerName);
      this.Controls.Add((Control) this.Label2);
      this.Controls.Add((Control) this.txtSiteName);
      this.Controls.Add((Control) this.Label1);
      this.Controls.Add((Control) this.txtTelephoneNum);
      this.Controls.Add((Control) this.lblTelephoneNum);
      this.Controls.Add((Control) this.txtEmailAddress);
      this.Controls.Add((Control) this.lblEmailAddress);
      this.Controls.Add((Control) this.btnSave);
      this.Controls.Add((Control) this.txtFaxNum);
      this.Controls.Add((Control) this.lblFaxNum);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.grpSite);
      this.MinimumSize = new Size(1, 1);
      this.Name = nameof (FRMContactInfo);
      this.Text = "Site Contact Information";
      this.Controls.SetChildIndex((Control) this.grpSite, 0);
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.lblFaxNum, 0);
      this.Controls.SetChildIndex((Control) this.txtFaxNum, 0);
      this.Controls.SetChildIndex((Control) this.btnSave, 0);
      this.Controls.SetChildIndex((Control) this.lblEmailAddress, 0);
      this.Controls.SetChildIndex((Control) this.txtEmailAddress, 0);
      this.Controls.SetChildIndex((Control) this.lblTelephoneNum, 0);
      this.Controls.SetChildIndex((Control) this.txtTelephoneNum, 0);
      this.Controls.SetChildIndex((Control) this.Label1, 0);
      this.Controls.SetChildIndex((Control) this.txtSiteName, 0);
      this.Controls.SetChildIndex((Control) this.Label2, 0);
      this.Controls.SetChildIndex((Control) this.txtCustomerName, 0);
      this.Controls.SetChildIndex((Control) this.Label9, 0);
      this.Controls.SetChildIndex((Control) this.txtHeadOffice, 0);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
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

    public FSM.Entity.Sites.Site CurrentSite
    {
      get
      {
        return this._osite;
      }
      set
      {
        this._osite = value;
        this.txtSiteName.Text = this.CurrentSite.Address1 + " " + this.CurrentSite.Address2 + ", " + this.CurrentSite.Postcode;
        Customer customer = new Customer();
        this.txtCustomerName.Text = App.DB.Customer.Customer_Get_Light(this.CurrentSite.CustomerID).Name;
        FSM.Entity.Sites.Site site1 = App.DB.Sites.Get((object) this.CurrentSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        if (site1 != null)
        {
          FSM.Entity.Sites.Site site2 = site1;
          this.txtHeadOffice.Text = site2.Address1 + ", " + site2.Address2;
        }
        else
          this.txtHeadOffice.Text = "Not Allocated";
        this.txtTelephoneNum.Text = this.CurrentSite.TelephoneNum;
        this.txtFaxNum.Text = this.CurrentSite.FaxNum;
        this.txtEmailAddress.Text = this.CurrentSite.EmailAddress;
      }
    }

    private void FRMContactInfo_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      FSM.Entity.Sites.Site currentSite = this.CurrentSite;
      currentSite.SetTelephoneNum = (object) this.txtTelephoneNum.Text;
      currentSite.SetFaxNum = (object) this.txtFaxNum.Text;
      currentSite.SetEmailAddress = (object) this.txtEmailAddress.Text;
      App.DB.Sites.Update(this.CurrentSite);
      this.DialogResult = DialogResult.Yes;
      if (this.Modal)
        this.Close();
      else
        this.Dispose();
    }

    private void FRMContactInfo_FormClosing(object sender, FormClosingEventArgs e)
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
