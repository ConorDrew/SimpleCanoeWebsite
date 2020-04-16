// Decompiled with JetBrains decompiler
// Type: FSM.UCSupplier
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Suppliers;
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
  public class UCSupplier : UCBase, IUserControl
  {
    private IContainer components;
    private Supplier _currentSupplier;

    public UCSupplier()
    {
      this.Load += new EventHandler(this.UCSupplier_Load);
      this.InitializeComponent();
      ComboBox cboMainSupplier = this.cboMainSupplier;
      Combo.SetUpCombo(ref cboMainSupplier, App.DB.Supplier.Supplier_GetAll().Table, "SupplierID", "Name", Enums.ComboValues.Please_Select);
      this.cboMainSupplier = cboMainSupplier;
      this.cboMainSupplier.Visible = false;
      this.Label4.Visible = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox grpSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

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

    internal virtual TextBox txtNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblNotes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtGaswayAccount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkSupplierBranch
    {
      get
      {
        return this._chkSupplierBranch;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkSupplierBranch_CheckedChanged);
        CheckBox chkSupplierBranch1 = this._chkSupplierBranch;
        if (chkSupplierBranch1 != null)
          chkSupplierBranch1.CheckedChanged -= eventHandler;
        this._chkSupplierBranch = value;
        CheckBox chkSupplierBranch2 = this._chkSupplierBranch;
        if (chkSupplierBranch2 == null)
          return;
        chkSupplierBranch2.CheckedChanged += eventHandler;
      }
    }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboMainSupplier { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkReleaseToTablets { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkSubContractor { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkSecondaryPrice
    {
      get
      {
        return this._chkSecondaryPrice;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.chkSecondaryPrice_CheckedChanged);
        CheckBox chkSecondaryPrice1 = this._chkSecondaryPrice;
        if (chkSecondaryPrice1 != null)
          chkSecondaryPrice1.CheckedChanged -= eventHandler;
        this._chkSecondaryPrice = value;
        CheckBox chkSecondaryPrice2 = this._chkSecondaryPrice;
        if (chkSecondaryPrice2 == null)
          return;
        chkSecondaryPrice2.CheckedChanged += eventHandler;
      }
    }

    internal virtual TextBox txtNominal { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSecondAccountNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSecondAccount { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAccountNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.grpSupplier = new GroupBox();
      this.txtNominal = new TextBox();
      this.Label3 = new Label();
      this.txtSecondAccountNumber = new TextBox();
      this.lblSecondAccount = new Label();
      this.chkSecondaryPrice = new CheckBox();
      this.chkSubContractor = new CheckBox();
      this.chkReleaseToTablets = new CheckBox();
      this.chkSupplierBranch = new CheckBox();
      this.Label4 = new Label();
      this.cboMainSupplier = new ComboBox();
      this.txtGaswayAccount = new TextBox();
      this.txtAccountNumber = new TextBox();
      this.txtName = new TextBox();
      this.lblName = new Label();
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
      this.txtNotes = new TextBox();
      this.lblNotes = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.grpSupplier.SuspendLayout();
      this.SuspendLayout();
      this.grpSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSupplier.Controls.Add((Control) this.txtNominal);
      this.grpSupplier.Controls.Add((Control) this.Label3);
      this.grpSupplier.Controls.Add((Control) this.txtSecondAccountNumber);
      this.grpSupplier.Controls.Add((Control) this.lblSecondAccount);
      this.grpSupplier.Controls.Add((Control) this.chkSecondaryPrice);
      this.grpSupplier.Controls.Add((Control) this.chkSubContractor);
      this.grpSupplier.Controls.Add((Control) this.chkReleaseToTablets);
      this.grpSupplier.Controls.Add((Control) this.chkSupplierBranch);
      this.grpSupplier.Controls.Add((Control) this.Label4);
      this.grpSupplier.Controls.Add((Control) this.cboMainSupplier);
      this.grpSupplier.Controls.Add((Control) this.txtGaswayAccount);
      this.grpSupplier.Controls.Add((Control) this.txtAccountNumber);
      this.grpSupplier.Controls.Add((Control) this.txtName);
      this.grpSupplier.Controls.Add((Control) this.lblName);
      this.grpSupplier.Controls.Add((Control) this.txtAddress1);
      this.grpSupplier.Controls.Add((Control) this.lblAddress1);
      this.grpSupplier.Controls.Add((Control) this.txtAddress2);
      this.grpSupplier.Controls.Add((Control) this.lblAddress2);
      this.grpSupplier.Controls.Add((Control) this.txtAddress3);
      this.grpSupplier.Controls.Add((Control) this.lblAddress3);
      this.grpSupplier.Controls.Add((Control) this.txtAddress4);
      this.grpSupplier.Controls.Add((Control) this.lblTown);
      this.grpSupplier.Controls.Add((Control) this.txtAddress5);
      this.grpSupplier.Controls.Add((Control) this.lblCounty);
      this.grpSupplier.Controls.Add((Control) this.txtPostcode);
      this.grpSupplier.Controls.Add((Control) this.lblPostcode);
      this.grpSupplier.Controls.Add((Control) this.txtTelephoneNum);
      this.grpSupplier.Controls.Add((Control) this.lblTelephoneNum);
      this.grpSupplier.Controls.Add((Control) this.txtFaxNum);
      this.grpSupplier.Controls.Add((Control) this.lblFaxNum);
      this.grpSupplier.Controls.Add((Control) this.txtEmailAddress);
      this.grpSupplier.Controls.Add((Control) this.lblEmailAddress);
      this.grpSupplier.Controls.Add((Control) this.txtNotes);
      this.grpSupplier.Controls.Add((Control) this.lblNotes);
      this.grpSupplier.Controls.Add((Control) this.Label2);
      this.grpSupplier.Controls.Add((Control) this.Label1);
      this.grpSupplier.Location = new System.Drawing.Point(8, 8);
      this.grpSupplier.Name = "grpSupplier";
      this.grpSupplier.Size = new Size(567, 665);
      this.grpSupplier.TabIndex = 1;
      this.grpSupplier.TabStop = false;
      this.grpSupplier.Text = "Main Details";
      this.txtNominal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNominal.Location = new System.Drawing.Point(235, 125);
      this.txtNominal.MaxLength = 25;
      this.txtNominal.Name = "txtNominal";
      this.txtNominal.Size = new Size(317, 21);
      this.txtNominal.TabIndex = 43;
      this.txtNominal.Tag = (object) "Supplier.AccountNumber";
      this.Label3.Location = new System.Drawing.Point(10, 129);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(112, 20);
      this.Label3.TabIndex = 44;
      this.Label3.Text = "Default Nominal";
      this.txtSecondAccountNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSecondAccountNumber.Location = new System.Drawing.Point(235, 537);
      this.txtSecondAccountNumber.MaxLength = 25;
      this.txtSecondAccountNumber.Name = "txtSecondAccountNumber";
      this.txtSecondAccountNumber.Size = new Size(317, 21);
      this.txtSecondAccountNumber.TabIndex = 43;
      this.txtSecondAccountNumber.Tag = (object) "Supplier.AccountNumber";
      this.txtSecondAccountNumber.Visible = false;
      this.lblSecondAccount.Location = new System.Drawing.Point(10, 541);
      this.lblSecondAccount.Name = "lblSecondAccount";
      this.lblSecondAccount.Size = new Size(190, 20);
      this.lblSecondAccount.TabIndex = 44;
      this.lblSecondAccount.Text = "Second Account Number";
      this.lblSecondAccount.Visible = false;
      this.chkSecondaryPrice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkSecondaryPrice.AutoSize = true;
      this.chkSecondaryPrice.Location = new System.Drawing.Point(13, 573);
      this.chkSecondaryPrice.Name = "chkSecondaryPrice";
      this.chkSecondaryPrice.Size = new Size(119, 17);
      this.chkSecondaryPrice.TabIndex = 42;
      this.chkSecondaryPrice.Text = "Secondary Price";
      this.chkSecondaryPrice.UseVisualStyleBackColor = true;
      this.chkSubContractor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkSubContractor.AutoSize = true;
      this.chkSubContractor.Location = new System.Drawing.Point(13, 606);
      this.chkSubContractor.Name = "chkSubContractor";
      this.chkSubContractor.Size = new Size(119, 17);
      this.chkSubContractor.TabIndex = 41;
      this.chkSubContractor.Text = "Sub Contractor?";
      this.chkSubContractor.UseVisualStyleBackColor = true;
      this.chkReleaseToTablets.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.chkReleaseToTablets.AutoSize = true;
      this.chkReleaseToTablets.Location = new System.Drawing.Point(13, 640);
      this.chkReleaseToTablets.Name = "chkReleaseToTablets";
      this.chkReleaseToTablets.Size = new Size(187, 17);
      this.chkReleaseToTablets.TabIndex = 40;
      this.chkReleaseToTablets.Text = "Release Supplier to Tablets?";
      this.chkReleaseToTablets.UseVisualStyleBackColor = true;
      this.chkSupplierBranch.AutoSize = true;
      this.chkSupplierBranch.Location = new System.Drawing.Point(13, 22);
      this.chkSupplierBranch.Name = "chkSupplierBranch";
      this.chkSupplierBranch.Size = new Size(173, 17);
      this.chkSupplierBranch.TabIndex = 39;
      this.chkSupplierBranch.Text = "Is this a Supplier Branch?";
      this.chkSupplierBranch.UseVisualStyleBackColor = true;
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(10, 50);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(84, 13);
      this.Label4.TabIndex = 38;
      this.Label4.Text = "Main Supplier";
      this.cboMainSupplier.FormattingEnabled = true;
      this.cboMainSupplier.Location = new System.Drawing.Point(235, 45);
      this.cboMainSupplier.Name = "cboMainSupplier";
      this.cboMainSupplier.Size = new Size(317, 21);
      this.cboMainSupplier.TabIndex = 37;
      this.txtGaswayAccount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtGaswayAccount.Location = new System.Drawing.Point(235, 395);
      this.txtGaswayAccount.MaxLength = 25;
      this.txtGaswayAccount.Name = "txtGaswayAccount";
      this.txtGaswayAccount.Size = new Size(317, 21);
      this.txtGaswayAccount.TabIndex = 34;
      this.txtGaswayAccount.Tag = (object) "";
      this.txtAccountNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAccountNumber.Location = new System.Drawing.Point(235, 99);
      this.txtAccountNumber.MaxLength = 25;
      this.txtAccountNumber.Name = "txtAccountNumber";
      this.txtAccountNumber.Size = new Size(317, 21);
      this.txtAccountNumber.TabIndex = 3;
      this.txtAccountNumber.Tag = (object) "Supplier.AccountNumber";
      this.txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtName.Location = new System.Drawing.Point(235, 72);
      this.txtName.MaxLength = (int) byte.MaxValue;
      this.txtName.Name = "txtName";
      this.txtName.Size = new Size(317, 21);
      this.txtName.TabIndex = 2;
      this.txtName.Tag = (object) "Supplier.Name";
      this.lblName.Location = new System.Drawing.Point(10, 75);
      this.lblName.Name = "lblName";
      this.lblName.Size = new Size(96, 20);
      this.lblName.TabIndex = 31;
      this.lblName.Text = "Name";
      this.txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress1.Location = new System.Drawing.Point(235, 152);
      this.txtAddress1.MaxLength = (int) byte.MaxValue;
      this.txtAddress1.Name = "txtAddress1";
      this.txtAddress1.Size = new Size(317, 21);
      this.txtAddress1.TabIndex = 4;
      this.txtAddress1.Tag = (object) "Supplier.Address1";
      this.lblAddress1.Location = new System.Drawing.Point(10, 155);
      this.lblAddress1.Name = "lblAddress1";
      this.lblAddress1.Size = new Size(96, 20);
      this.lblAddress1.TabIndex = 31;
      this.lblAddress1.Text = "Address 1";
      this.txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress2.Location = new System.Drawing.Point(235, 179);
      this.txtAddress2.MaxLength = (int) byte.MaxValue;
      this.txtAddress2.Name = "txtAddress2";
      this.txtAddress2.Size = new Size(317, 21);
      this.txtAddress2.TabIndex = 5;
      this.txtAddress2.Tag = (object) "Supplier.Address2";
      this.lblAddress2.Location = new System.Drawing.Point(10, 182);
      this.lblAddress2.Name = "lblAddress2";
      this.lblAddress2.Size = new Size(96, 20);
      this.lblAddress2.TabIndex = 31;
      this.lblAddress2.Text = "Address 2";
      this.txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress3.Location = new System.Drawing.Point(235, 206);
      this.txtAddress3.MaxLength = (int) byte.MaxValue;
      this.txtAddress3.Name = "txtAddress3";
      this.txtAddress3.Size = new Size(317, 21);
      this.txtAddress3.TabIndex = 6;
      this.txtAddress3.Tag = (object) "Supplier.Address3";
      this.lblAddress3.Location = new System.Drawing.Point(10, 209);
      this.lblAddress3.Name = "lblAddress3";
      this.lblAddress3.Size = new Size(96, 20);
      this.lblAddress3.TabIndex = 31;
      this.lblAddress3.Text = "Address 3";
      this.txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress4.Location = new System.Drawing.Point(235, 233);
      this.txtAddress4.MaxLength = (int) byte.MaxValue;
      this.txtAddress4.Name = "txtAddress4";
      this.txtAddress4.Size = new Size(317, 21);
      this.txtAddress4.TabIndex = 7;
      this.txtAddress4.Tag = (object) "Supplier.Town";
      this.lblTown.Location = new System.Drawing.Point(10, 236);
      this.lblTown.Name = "lblTown";
      this.lblTown.Size = new Size(96, 20);
      this.lblTown.TabIndex = 31;
      this.lblTown.Text = "Address 4";
      this.txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAddress5.Location = new System.Drawing.Point(235, 260);
      this.txtAddress5.MaxLength = (int) byte.MaxValue;
      this.txtAddress5.Name = "txtAddress5";
      this.txtAddress5.Size = new Size(317, 21);
      this.txtAddress5.TabIndex = 8;
      this.txtAddress5.Tag = (object) "Supplier.County";
      this.lblCounty.Location = new System.Drawing.Point(10, 263);
      this.lblCounty.Name = "lblCounty";
      this.lblCounty.Size = new Size(96, 20);
      this.lblCounty.TabIndex = 31;
      this.lblCounty.Text = "Address 5";
      this.txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPostcode.Location = new System.Drawing.Point(235, 287);
      this.txtPostcode.MaxLength = 20;
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(317, 21);
      this.txtPostcode.TabIndex = 9;
      this.txtPostcode.Tag = (object) "Supplier.Postcode";
      this.lblPostcode.Location = new System.Drawing.Point(10, 290);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(96, 20);
      this.lblPostcode.TabIndex = 31;
      this.lblPostcode.Text = "Postcode";
      this.txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtTelephoneNum.Location = new System.Drawing.Point(235, 314);
      this.txtTelephoneNum.MaxLength = 50;
      this.txtTelephoneNum.Name = "txtTelephoneNum";
      this.txtTelephoneNum.Size = new Size(317, 21);
      this.txtTelephoneNum.TabIndex = 10;
      this.txtTelephoneNum.Tag = (object) "Supplier.TelephoneNum";
      this.lblTelephoneNum.Location = new System.Drawing.Point(10, 317);
      this.lblTelephoneNum.Name = "lblTelephoneNum";
      this.lblTelephoneNum.Size = new Size(96, 20);
      this.lblTelephoneNum.TabIndex = 31;
      this.lblTelephoneNum.Text = "Tel";
      this.txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtFaxNum.Location = new System.Drawing.Point(235, 341);
      this.txtFaxNum.MaxLength = 50;
      this.txtFaxNum.Name = "txtFaxNum";
      this.txtFaxNum.Size = new Size(317, 21);
      this.txtFaxNum.TabIndex = 11;
      this.txtFaxNum.Tag = (object) "Supplier.FaxNum";
      this.lblFaxNum.Location = new System.Drawing.Point(10, 344);
      this.lblFaxNum.Name = "lblFaxNum";
      this.lblFaxNum.Size = new Size(96, 20);
      this.lblFaxNum.TabIndex = 31;
      this.lblFaxNum.Text = "Fax";
      this.txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtEmailAddress.Location = new System.Drawing.Point(235, 368);
      this.txtEmailAddress.MaxLength = 500;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(317, 21);
      this.txtEmailAddress.TabIndex = 12;
      this.txtEmailAddress.Tag = (object) "Supplier.EmailAddress";
      this.lblEmailAddress.Location = new System.Drawing.Point(10, 371);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(210, 20);
      this.lblEmailAddress.TabIndex = 31;
      this.lblEmailAddress.Text = "Email Address (comma seperated)";
      this.txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtNotes.Location = new System.Drawing.Point(235, 422);
      this.txtNotes.Multiline = true;
      this.txtNotes.Name = "txtNotes";
      this.txtNotes.ScrollBars = ScrollBars.Vertical;
      this.txtNotes.Size = new Size(317, 109);
      this.txtNotes.TabIndex = 13;
      this.txtNotes.Tag = (object) "Supplier.Notes";
      this.lblNotes.Location = new System.Drawing.Point(10, 425);
      this.lblNotes.Name = "lblNotes";
      this.lblNotes.Size = new Size(96, 20);
      this.lblNotes.TabIndex = 31;
      this.lblNotes.Text = "Notes";
      this.Label2.Location = new System.Drawing.Point(10, 398);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(112, 20);
      this.Label2.TabIndex = 35;
      this.Label2.Text = "Gasway Account";
      this.Label1.Location = new System.Drawing.Point(10, 103);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(112, 20);
      this.Label1.TabIndex = 33;
      this.Label1.Text = "Account Number";
      this.Controls.Add((Control) this.grpSupplier);
      this.Name = nameof (UCSupplier);
      this.Size = new Size(582, 676);
      this.grpSupplier.ResumeLayout(false);
      this.grpSupplier.PerformLayout();
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
        return (object) this.CurrentSupplier;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public Supplier CurrentSupplier
    {
      get
      {
        return this._currentSupplier;
      }
      set
      {
        this._currentSupplier = value;
        if (this.CurrentSupplier == null)
        {
          this.CurrentSupplier = new Supplier();
          this.CurrentSupplier.Exists = false;
        }
        if (!this.CurrentSupplier.Exists)
          return;
        this.Populate(0);
      }
    }

    private void UCSupplier_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    void IUserControl.Populate(int ID = 0)
    {
      App.ControlLoading = true;
      if ((uint) ID > 0U)
        this.CurrentSupplier = App.DB.Supplier.Supplier_Get(ID);
      this.txtAccountNumber.Text = this.CurrentSupplier.AccountNumber;
      this.txtSecondAccountNumber.Text = this.CurrentSupplier.SecondAccountNumber;
      this.txtName.Text = this.CurrentSupplier.Name;
      this.txtAddress1.Text = this.CurrentSupplier.Address1;
      this.txtAddress2.Text = this.CurrentSupplier.Address2;
      this.txtAddress3.Text = this.CurrentSupplier.Address3;
      this.txtAddress4.Text = this.CurrentSupplier.Address4;
      this.txtAddress5.Text = this.CurrentSupplier.Address5;
      this.txtPostcode.Text = this.CurrentSupplier.Postcode;
      this.txtTelephoneNum.Text = this.CurrentSupplier.TelephoneNum;
      this.txtFaxNum.Text = this.CurrentSupplier.FaxNum;
      this.txtEmailAddress.Text = this.CurrentSupplier.EmailAddress;
      this.txtGaswayAccount.Text = this.CurrentSupplier.GaswayAccount;
      this.txtNotes.Text = this.CurrentSupplier.Notes;
      this.txtNominal.Text = this.CurrentSupplier.DefaultNominal;
      if (Conversions.ToDouble(this.CurrentSupplier.MasterSupplierID) != 0.0)
      {
        this.Label4.Visible = true;
        this.chkSupplierBranch.Checked = true;
        ComboBox cboMainSupplier = this.cboMainSupplier;
        Combo.SetSelectedComboItem_By_Value(ref cboMainSupplier, this.CurrentSupplier.MasterSupplierID);
        this.cboMainSupplier = cboMainSupplier;
      }
      this.chkReleaseToTablets.Checked = Conversions.ToBoolean(this.CurrentSupplier.ReleaseToTablets);
      this.chkSecondaryPrice.Checked = this.CurrentSupplier.SecondaryPrice;
      this.chkSubContractor.Checked = this.CurrentSupplier.SubContractor;
      this.txtNominal.Text = this.CurrentSupplier.DefaultNominal;
      App.AddChangeHandlers((Control) this);
      App.ControlChanged = false;
      App.ControlLoading = false;
    }

    public bool Save()
    {
      bool flag;
      try
      {
        this.Cursor = Cursors.WaitCursor;
        this.CurrentSupplier.IgnoreExceptionsOnSetMethods = true;
        this.CurrentSupplier.SetAccountNumber = (object) this.txtAccountNumber.Text.Trim();
        this.CurrentSupplier.SetSecondAccountNumber = (object) this.txtSecondAccountNumber.Text.Trim();
        this.CurrentSupplier.SetName = (object) this.txtName.Text.Trim();
        this.CurrentSupplier.SetAddress1 = (object) this.txtAddress1.Text.Trim();
        this.CurrentSupplier.SetAddress2 = (object) this.txtAddress2.Text.Trim();
        this.CurrentSupplier.SetAddress3 = (object) this.txtAddress3.Text.Trim();
        this.CurrentSupplier.SetAddress4 = (object) this.txtAddress4.Text.Trim();
        this.CurrentSupplier.SetAddress5 = (object) this.txtAddress5.Text.Trim();
        this.CurrentSupplier.SetPostcode = (object) this.txtPostcode.Text.Trim();
        this.CurrentSupplier.SetTelephoneNum = (object) this.txtTelephoneNum.Text.Trim();
        this.CurrentSupplier.SetFaxNum = (object) this.txtFaxNum.Text.Trim();
        this.CurrentSupplier.SetEmailAddress = (object) this.txtEmailAddress.Text.Trim();
        this.CurrentSupplier.SetGaswayAccount = (object) this.txtGaswayAccount.Text;
        this.CurrentSupplier.SetNotes = (object) this.txtNotes.Text.Trim();
        this.CurrentSupplier.SetDefaultNominal = (object) this.txtNominal.Text.Trim();
        this.CurrentSupplier.SetMasterSupplierID = this.chkSupplierBranch.Checked ? (object) Combo.get_GetSelectedItemValue(this.cboMainSupplier) : (object) 0;
        this.CurrentSupplier.SetReleaseToTablets = !this.chkReleaseToTablets.Checked ? (object) false : (object) true;
        this.CurrentSupplier.SecondaryPrice = this.chkSecondaryPrice.Checked;
        this.CurrentSupplier.SetSubContractor = (object) this.chkSubContractor.Checked;
        new SupplierValidator().Validate(this.CurrentSupplier);
        if (this.CurrentSupplier.Exists)
          App.DB.Supplier.Update(this.CurrentSupplier);
        else
          this.CurrentSupplier = App.DB.Supplier.Insert(this.CurrentSupplier);
        this.Populate(this.CurrentSupplier.SupplierID);
        // ISSUE: reference to a compiler-generated field
        IUserControl.RecordsChangedEventHandler recordsChangedEvent = this.RecordsChangedEvent;
        if (recordsChangedEvent != null)
          recordsChangedEvent(App.DB.Supplier.Supplier_GetAll(), Enums.PageViewing.Supplier, true, false, "");
        // ISSUE: reference to a compiler-generated field
        IUserControl.StateChangedEventHandler stateChangedEvent = this.StateChangedEvent;
        if (stateChangedEvent != null)
          stateChangedEvent(this.CurrentSupplier.SupplierID);
        App.MainForm.RefreshEntity(this.CurrentSupplier.SupplierID, "");
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

    private void chkSupplierBranch_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkSupplierBranch.Checked)
      {
        this.cboMainSupplier.Visible = true;
        this.Label4.Visible = true;
      }
      else
      {
        this.cboMainSupplier.Visible = false;
        this.Label4.Visible = false;
      }
    }

    private void chkSecondaryPrice_CheckedChanged(object sender, EventArgs e)
    {
      this.txtSecondAccountNumber.Visible = this.chkSecondaryPrice.Checked;
      this.lblSecondAccount.Visible = this.chkSecondaryPrice.Checked;
    }
  }
}
