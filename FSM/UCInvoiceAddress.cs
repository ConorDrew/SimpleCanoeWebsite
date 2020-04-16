// Decompiled with JetBrains decompiler
// Type: FSM.UCInvoiceAddress
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.InvoiceAddresss;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCInvoiceAddress : UCBase, IUserControl
  {
    private IContainer components;
    private int _SiteID;
    private InvoiceAddress _currentInvoiceAddress;

    public UCInvoiceAddress()
    {
      this.Load += new EventHandler(this.UCInvoiceAddress_Load);
      this._SiteID = 0;
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTown { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblCounty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTelephoneNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFaxNum { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpInvoiceAddress = new GroupBox();
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
      this.grpInvoiceAddress.SuspendLayout();
      this.SuspendLayout();
      this.grpInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpInvoiceAddress.Controls.Add((Control) this.txtAddress1);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblAddress1);
      this.grpInvoiceAddress.Controls.Add((Control) this.txtAddress2);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblAddress2);
      this.grpInvoiceAddress.Controls.Add((Control) this.txtAddress3);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblAddress3);
      this.grpInvoiceAddress.Controls.Add((Control) this.txtAddress4);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblTown);
      this.grpInvoiceAddress.Controls.Add((Control) this.txtAddress5);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblCounty);
      this.grpInvoiceAddress.Controls.Add((Control) this.txtPostcode);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblPostcode);
      this.grpInvoiceAddress.Controls.Add((Control) this.txtTelephoneNum);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblTelephoneNum);
      this.grpInvoiceAddress.Controls.Add((Control) this.txtFaxNum);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblFaxNum);
      this.grpInvoiceAddress.Controls.Add((Control) this.txtEmailAddress);
      this.grpInvoiceAddress.Controls.Add((Control) this.lblEmailAddress);
      this.grpInvoiceAddress.Location = new System.Drawing.Point(8, 8);
      this.grpInvoiceAddress.Name = "grpInvoiceAddress";
      this.grpInvoiceAddress.Size = new Size(625, 313);
      this.grpInvoiceAddress.TabIndex = 1;
      this.grpInvoiceAddress.TabStop = false;
      this.grpInvoiceAddress.Text = "Main Details";
      this.txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress1.Location = new System.Drawing.Point(141, 24);
      this.txtAddress1.MaxLength = (int) byte.MaxValue;
      this.txtAddress1.Name = "txtAddress1";
      this.txtAddress1.Size = new Size(474, 21);
      this.txtAddress1.TabIndex = 2;
      this.txtAddress1.Tag = (object) "InvoiceAddress.Address1";
      this.txtAddress1.Text = "";
      this.lblAddress1.Location = new System.Drawing.Point(14, 24);
      this.lblAddress1.Name = "lblAddress1";
      this.lblAddress1.Size = new Size(73, 20);
      this.lblAddress1.TabIndex = 31;
      this.lblAddress1.Text = "Address 1";
      this.txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress2.Location = new System.Drawing.Point(141, 56);
      this.txtAddress2.MaxLength = (int) byte.MaxValue;
      this.txtAddress2.Name = "txtAddress2";
      this.txtAddress2.Size = new Size(474, 21);
      this.txtAddress2.TabIndex = 3;
      this.txtAddress2.Tag = (object) "InvoiceAddress.Address2";
      this.txtAddress2.Text = "";
      this.lblAddress2.Location = new System.Drawing.Point(14, 56);
      this.lblAddress2.Name = "lblAddress2";
      this.lblAddress2.Size = new Size(71, 20);
      this.lblAddress2.TabIndex = 31;
      this.lblAddress2.Text = "Address 2";
      this.txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress3.Location = new System.Drawing.Point(141, 88);
      this.txtAddress3.MaxLength = (int) byte.MaxValue;
      this.txtAddress3.Name = "txtAddress3";
      this.txtAddress3.Size = new Size(473, 21);
      this.txtAddress3.TabIndex = 4;
      this.txtAddress3.Tag = (object) "InvoiceAddress.Address3";
      this.txtAddress3.Text = "";
      this.lblAddress3.Location = new System.Drawing.Point(14, 88);
      this.lblAddress3.Name = "lblAddress3";
      this.lblAddress3.Size = new Size(73, 20);
      this.lblAddress3.TabIndex = 31;
      this.lblAddress3.Text = "Address 3";
      this.txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress4.Location = new System.Drawing.Point(141, 120);
      this.txtAddress4.MaxLength = (int) byte.MaxValue;
      this.txtAddress4.Name = "txtAddress4";
      this.txtAddress4.Size = new Size(472, 21);
      this.txtAddress4.TabIndex = 5;
      this.txtAddress4.Tag = (object) "InvoiceAddress.Town";
      this.txtAddress4.Text = "";
      this.lblTown.Location = new System.Drawing.Point(14, 120);
      this.lblTown.Name = "lblTown";
      this.lblTown.Size = new Size(64, 20);
      this.lblTown.TabIndex = 31;
      this.lblTown.Text = "Address 4";
      this.txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress5.Location = new System.Drawing.Point(141, 152);
      this.txtAddress5.MaxLength = (int) byte.MaxValue;
      this.txtAddress5.Name = "txtAddress5";
      this.txtAddress5.Size = new Size(473, 21);
      this.txtAddress5.TabIndex = 6;
      this.txtAddress5.Tag = (object) "InvoiceAddress.County";
      this.txtAddress5.Text = "";
      this.lblCounty.Location = new System.Drawing.Point(14, 152);
      this.lblCounty.Name = "lblCounty";
      this.lblCounty.Size = new Size(61, 20);
      this.lblCounty.TabIndex = 31;
      this.lblCounty.Text = "Address 5";
      this.txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPostcode.Location = new System.Drawing.Point(141, 184);
      this.txtPostcode.MaxLength = (int) byte.MaxValue;
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(473, 21);
      this.txtPostcode.TabIndex = 7;
      this.txtPostcode.Tag = (object) "InvoiceAddress.Postcode";
      this.txtPostcode.Text = "";
      this.lblPostcode.Location = new System.Drawing.Point(14, 184);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(66, 20);
      this.lblPostcode.TabIndex = 31;
      this.lblPostcode.Text = "Postcode";
      this.txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTelephoneNum.Location = new System.Drawing.Point(141, 216);
      this.txtTelephoneNum.MaxLength = (int) byte.MaxValue;
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.Size = new Size(473, 21);
      this.txtTelephoneNum.TabIndex = 8;
      this.txtTelephoneNum.Tag = (object) "InvoiceAddress.TelephoneNum";
      this.txtTelephoneNum.Text = "";
      this.lblTelephoneNum.Location = new System.Drawing.Point(14, 216);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(108, 20);
      this.lblTelephoneNum.TabIndex = 31;
      this.lblTelephoneNum.Text = "Telephone";
      this.txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFaxNum.Location = new System.Drawing.Point(141, 248);
      this.txtFaxNum.MaxLength = (int) byte.MaxValue;
      this.txtFaxNum.Name = "txtFaxNum";
      this.txtFaxNum.Size = new Size(473, 21);
      this.txtFaxNum.TabIndex = 9;
      this.txtFaxNum.Tag = (object) "InvoiceAddress.FaxNum";
      this.txtFaxNum.Text = "";
      this.lblFaxNum.Location = new System.Drawing.Point(14, 248);
      this.lblFaxNum.Name = "lblFaxNum";
      this.lblFaxNum.Size = new Size(70, 20);
      this.lblFaxNum.TabIndex = 31;
      this.lblFaxNum.Text = "Fax";
      this.txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEmailAddress.Location = new System.Drawing.Point(141, 280);
      this.txtEmailAddress.MaxLength = (int) byte.MaxValue;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(473, 21);
      this.txtEmailAddress.TabIndex = 10;
      this.txtEmailAddress.Tag = (object) "InvoiceAddress.EmailAddress";
      this.txtEmailAddress.Text = "";
      this.lblEmailAddress.Location = new System.Drawing.Point(14, 280);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(97, 20);
      this.lblEmailAddress.TabIndex = 31;
      this.lblEmailAddress.Text = "Email Address";
      this.Controls.Add((Control) this.grpInvoiceAddress);
      this.Name = nameof (UCInvoiceAddress);
      this.Size = new Size(640, 329);
      this.grpInvoiceAddress.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
    }

    public object LoadedItem
    {
      get
      {
        return (object) this.CurrentInvoiceAddress;
      }
    }

    public int SiteID
    {
      get
      {
        return this._SiteID;
      }
      set
      {
        this._SiteID = value;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public InvoiceAddress CurrentInvoiceAddress
    {
      get
      {
        return this._currentInvoiceAddress;
      }
      set
      {
        this._currentInvoiceAddress = value;
        if (this.CurrentInvoiceAddress == null)
        {
          this.CurrentInvoiceAddress = new InvoiceAddress();
          this.CurrentInvoiceAddress.Exists = false;
        }
        if (!this.CurrentInvoiceAddress.Exists)
          return;
        this.Populate(0);
      }
    }

    private void UCInvoiceAddress_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    void IUserControl.Populate(int ID = 0)
    {
      if ((uint) ID > 0U)
        this.CurrentInvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(ID);
      this.txtAddress1.Text = this.CurrentInvoiceAddress.Address1;
      this.txtAddress2.Text = this.CurrentInvoiceAddress.Address2;
      this.txtAddress3.Text = this.CurrentInvoiceAddress.Address3;
      this.txtAddress4.Text = this.CurrentInvoiceAddress.Address4;
      this.txtAddress5.Text = this.CurrentInvoiceAddress.Address5;
      this.txtPostcode.Text = this.CurrentInvoiceAddress.Postcode;
      this.txtTelephoneNum.Text = this.CurrentInvoiceAddress.TelephoneNum;
      this.txtFaxNum.Text = this.CurrentInvoiceAddress.FaxNum;
      this.txtEmailAddress.Text = this.CurrentInvoiceAddress.EmailAddress;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentInvoiceAddress.IgnoreExceptionsOnSetMethods = true;
        this.CurrentInvoiceAddress.SetAddress1 = (object) this.txtAddress1.Text.Trim();
        this.CurrentInvoiceAddress.SetAddress2 = (object) this.txtAddress2.Text.Trim();
        this.CurrentInvoiceAddress.SetAddress3 = (object) this.txtAddress3.Text.Trim();
        this.CurrentInvoiceAddress.SetAddress4 = (object) this.txtAddress4.Text.Trim();
        this.CurrentInvoiceAddress.SetAddress5 = (object) this.txtAddress5.Text.Trim();
        this.CurrentInvoiceAddress.SetPostcode = (object) this.txtPostcode.Text.Trim();
        this.CurrentInvoiceAddress.SetTelephoneNum = (object) this.txtTelephoneNum.Text.Trim();
        this.CurrentInvoiceAddress.SetFaxNum = (object) this.txtFaxNum.Text.Trim();
        this.CurrentInvoiceAddress.SetEmailAddress = (object) this.txtEmailAddress.Text.Trim();
        this.CurrentInvoiceAddress.SetSiteID = (object) this.SiteID;
        new InvoiceAddressValidator().Validate(this.CurrentInvoiceAddress);
        if (this.CurrentInvoiceAddress.Exists)
          App.DB.InvoiceAddress.Update(this.CurrentInvoiceAddress);
        else
          this.CurrentInvoiceAddress = App.DB.InvoiceAddress.Insert(this.CurrentInvoiceAddress);
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentInvoiceAddress.InvoiceAddressID);
        flag = true;
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = false;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        flag = false;
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
      return flag;
    }
  }
}
