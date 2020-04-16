// Decompiled with JetBrains decompiler
// Type: FSM.UCContacts
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Contacts;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
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
  public class UCContacts : UCBase, IUserControl
  {
    private IContainer components;
    private FSM.Entity.Sites.Site _osite;
    private Contact _oContact;
    private DataView _dvSiteContacts;

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
      this.grpSiteContacts = new GroupBox();
      this.grpContacts = new GroupBox();
      this.dgSiteContacts = new DataGrid();
      this.grpContact = new GroupBox();
      this.lblPostcode = new Label();
      this.txtPostcode = new TextBox();
      this.lblAddress3 = new Label();
      this.txtAddress3 = new TextBox();
      this.lblAddress2 = new Label();
      this.txtAddress2 = new TextBox();
      this.lblAddress1 = new Label();
      this.txtAddress1 = new TextBox();
      this.lblRelationship = new Label();
      this.cboRelationship = new ComboBox();
      this.chkIsPOC = new CheckBox();
      this.chkOnContract = new CheckBox();
      this.btnNewContact = new Button();
      this.btnDeleteContact = new Button();
      this.btnSaveContact = new Button();
      this.chkNoMarketing = new CheckBox();
      this.lblEmailAddress = new Label();
      this.txtEmailAddress = new TextBox();
      this.lblMobileNumber = new Label();
      this.lblLastName = new Label();
      this.lblFirstname = new Label();
      this.txtMobileNumber = new TextBox();
      this.txtLastname = new TextBox();
      this.txtFirstName = new TextBox();
      this.lblTitle = new Label();
      this.cboTitle = new ComboBox();
      this.grpSiteContacts.SuspendLayout();
      this.grpContacts.SuspendLayout();
      this.dgSiteContacts.BeginInit();
      this.grpContact.SuspendLayout();
      this.SuspendLayout();
      this.grpSiteContacts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpSiteContacts.AutoSize = true;
      this.grpSiteContacts.Controls.Add((Control) this.grpContacts);
      this.grpSiteContacts.Controls.Add((Control) this.grpContact);
      this.grpSiteContacts.Location = new System.Drawing.Point(0, 0);
      this.grpSiteContacts.Margin = new Padding(0);
      this.grpSiteContacts.Name = "grpSiteContacts";
      this.grpSiteContacts.Padding = new Padding(0);
      this.grpSiteContacts.Size = new Size(1401, 670);
      this.grpSiteContacts.TabIndex = 15;
      this.grpSiteContacts.TabStop = false;
      this.grpSiteContacts.Text = "Site Contacts";
      this.grpContacts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContacts.Controls.Add((Control) this.dgSiteContacts);
      this.grpContacts.Location = new System.Drawing.Point(13, 183);
      this.grpContacts.Name = "grpContacts";
      this.grpContacts.Size = new Size(1381, 471);
      this.grpContacts.TabIndex = 149;
      this.grpContacts.TabStop = false;
      this.grpContacts.Text = "Contacts";
      this.dgSiteContacts.DataMember = "";
      this.dgSiteContacts.Dock = DockStyle.Fill;
      this.dgSiteContacts.HeaderForeColor = SystemColors.ControlText;
      this.dgSiteContacts.Location = new System.Drawing.Point(3, 17);
      this.dgSiteContacts.Name = "dgSiteContacts";
      this.dgSiteContacts.Size = new Size(1375, 451);
      this.dgSiteContacts.TabIndex = 11;
      this.grpContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.grpContact.Controls.Add((Control) this.lblPostcode);
      this.grpContact.Controls.Add((Control) this.txtPostcode);
      this.grpContact.Controls.Add((Control) this.lblAddress3);
      this.grpContact.Controls.Add((Control) this.txtAddress3);
      this.grpContact.Controls.Add((Control) this.lblAddress2);
      this.grpContact.Controls.Add((Control) this.txtAddress2);
      this.grpContact.Controls.Add((Control) this.lblAddress1);
      this.grpContact.Controls.Add((Control) this.txtAddress1);
      this.grpContact.Controls.Add((Control) this.lblRelationship);
      this.grpContact.Controls.Add((Control) this.cboRelationship);
      this.grpContact.Controls.Add((Control) this.chkIsPOC);
      this.grpContact.Controls.Add((Control) this.chkOnContract);
      this.grpContact.Controls.Add((Control) this.btnNewContact);
      this.grpContact.Controls.Add((Control) this.btnDeleteContact);
      this.grpContact.Controls.Add((Control) this.btnSaveContact);
      this.grpContact.Controls.Add((Control) this.chkNoMarketing);
      this.grpContact.Controls.Add((Control) this.lblEmailAddress);
      this.grpContact.Controls.Add((Control) this.txtEmailAddress);
      this.grpContact.Controls.Add((Control) this.lblMobileNumber);
      this.grpContact.Controls.Add((Control) this.lblLastName);
      this.grpContact.Controls.Add((Control) this.lblFirstname);
      this.grpContact.Controls.Add((Control) this.txtMobileNumber);
      this.grpContact.Controls.Add((Control) this.txtLastname);
      this.grpContact.Controls.Add((Control) this.txtFirstName);
      this.grpContact.Controls.Add((Control) this.lblTitle);
      this.grpContact.Controls.Add((Control) this.cboTitle);
      this.grpContact.Location = new System.Drawing.Point(13, 17);
      this.grpContact.Name = "grpContact";
      this.grpContact.Size = new Size(1381, 160);
      this.grpContact.TabIndex = 115;
      this.grpContact.TabStop = false;
      this.grpContact.Text = "Contact";
      this.lblPostcode.Location = new System.Drawing.Point(545, 93);
      this.lblPostcode.Name = "lblPostcode";
      this.lblPostcode.Size = new Size(82, 21);
      this.lblPostcode.TabIndex = 161;
      this.lblPostcode.Text = "Postcode";
      this.lblPostcode.TextAlign = ContentAlignment.MiddleRight;
      this.txtPostcode.Location = new System.Drawing.Point(633, 93);
      this.txtPostcode.MaxLength = (int) byte.MaxValue;
      this.txtPostcode.Name = "txtPostcode";
      this.txtPostcode.Size = new Size(170, 21);
      this.txtPostcode.TabIndex = 148;
      this.txtPostcode.Tag = (object) "";
      this.lblAddress3.Location = new System.Drawing.Point(545, 58);
      this.lblAddress3.Name = "lblAddress3";
      this.lblAddress3.Size = new Size(82, 21);
      this.lblAddress3.TabIndex = 159;
      this.lblAddress3.Text = "Address 3";
      this.lblAddress3.TextAlign = ContentAlignment.MiddleRight;
      this.txtAddress3.Location = new System.Drawing.Point(633, 58);
      this.txtAddress3.MaxLength = (int) byte.MaxValue;
      this.txtAddress3.Name = "txtAddress3";
      this.txtAddress3.Size = new Size(170, 21);
      this.txtAddress3.TabIndex = 147;
      this.txtAddress3.Tag = (object) "";
      this.lblAddress2.Location = new System.Drawing.Point(545, 22);
      this.lblAddress2.Name = "lblAddress2";
      this.lblAddress2.Size = new Size(82, 21);
      this.lblAddress2.TabIndex = 157;
      this.lblAddress2.Text = "Address 2";
      this.lblAddress2.TextAlign = ContentAlignment.MiddleRight;
      this.txtAddress2.Location = new System.Drawing.Point(633, 22);
      this.txtAddress2.MaxLength = (int) byte.MaxValue;
      this.txtAddress2.Name = "txtAddress2";
      this.txtAddress2.Size = new Size(170, 21);
      this.txtAddress2.TabIndex = 146;
      this.txtAddress2.Tag = (object) "";
      this.lblAddress1.Location = new System.Drawing.Point(265, 93);
      this.lblAddress1.Name = "lblAddress1";
      this.lblAddress1.Size = new Size(82, 21);
      this.lblAddress1.TabIndex = 155;
      this.lblAddress1.Text = "Address 1";
      this.lblAddress1.TextAlign = ContentAlignment.MiddleRight;
      this.txtAddress1.Location = new System.Drawing.Point(353, 93);
      this.txtAddress1.MaxLength = (int) byte.MaxValue;
      this.txtAddress1.Name = "txtAddress1";
      this.txtAddress1.Size = new Size(170, 21);
      this.txtAddress1.TabIndex = 145;
      this.txtAddress1.Tag = (object) "";
      this.lblRelationship.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblRelationship.Location = new System.Drawing.Point(823, 23);
      this.lblRelationship.Name = "lblRelationship";
      this.lblRelationship.Size = new Size(152, 21);
      this.lblRelationship.TabIndex = 153;
      this.lblRelationship.Text = "Relationship To Tennent";
      this.lblRelationship.TextAlign = ContentAlignment.MiddleRight;
      this.cboRelationship.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.cboRelationship.FormattingEnabled = true;
      this.cboRelationship.Location = new System.Drawing.Point(981, 23);
      this.cboRelationship.Name = "cboRelationship";
      this.cboRelationship.Size = new Size(170, 21);
      this.cboRelationship.TabIndex = 149;
      this.chkIsPOC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkIsPOC.Location = new System.Drawing.Point(1179, 88);
      this.chkIsPOC.Name = "chkIsPOC";
      this.chkIsPOC.Size = new Size(120, 24);
      this.chkIsPOC.TabIndex = 152;
      this.chkIsPOC.Text = "Point Of Contact";
      this.chkOnContract.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkOnContract.Location = new System.Drawing.Point(1179, 54);
      this.chkOnContract.Name = "chkOnContract";
      this.chkOnContract.Size = new Size(120, 24);
      this.chkOnContract.TabIndex = 151;
      this.chkOnContract.Text = "On Contract";
      this.btnNewContact.Location = new System.Drawing.Point(15, 131);
      this.btnNewContact.Name = "btnNewContact";
      this.btnNewContact.Size = new Size(75, 23);
      this.btnNewContact.TabIndex = 149;
      this.btnNewContact.Text = "Clear";
      this.btnNewContact.UseVisualStyleBackColor = true;
      this.btnDeleteContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnDeleteContact.Location = new System.Drawing.Point(1179, 131);
      this.btnDeleteContact.Name = "btnDeleteContact";
      this.btnDeleteContact.Size = new Size(75, 23);
      this.btnDeleteContact.TabIndex = 148;
      this.btnDeleteContact.Text = "Delete";
      this.btnSaveContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnSaveContact.Location = new System.Drawing.Point(1300, 131);
      this.btnSaveContact.Name = "btnSaveContact";
      this.btnSaveContact.Size = new Size(75, 23);
      this.btnSaveContact.TabIndex = 147;
      this.btnSaveContact.Text = "Save";
      this.chkNoMarketing.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.chkNoMarketing.Location = new System.Drawing.Point(1179, 20);
      this.chkNoMarketing.Name = "chkNoMarketing";
      this.chkNoMarketing.Size = new Size(120, 24);
      this.chkNoMarketing.TabIndex = 150;
      this.chkNoMarketing.Text = "No Marketing";
      this.lblEmailAddress.Location = new System.Drawing.Point(297, 58);
      this.lblEmailAddress.Name = "lblEmailAddress";
      this.lblEmailAddress.Size = new Size(50, 21);
      this.lblEmailAddress.TabIndex = 145;
      this.lblEmailAddress.Text = "Email";
      this.lblEmailAddress.TextAlign = ContentAlignment.MiddleRight;
      this.txtEmailAddress.Location = new System.Drawing.Point(353, 58);
      this.txtEmailAddress.MaxLength = (int) byte.MaxValue;
      this.txtEmailAddress.Name = "txtEmailAddress";
      this.txtEmailAddress.Size = new Size(170, 21);
      this.txtEmailAddress.TabIndex = 144;
      this.txtEmailAddress.Tag = (object) "";
      this.lblMobileNumber.Location = new System.Drawing.Point(297, 19);
      this.lblMobileNumber.Name = "lblMobileNumber";
      this.lblMobileNumber.Size = new Size(50, 21);
      this.lblMobileNumber.TabIndex = 141;
      this.lblMobileNumber.Text = "Mobile";
      this.lblMobileNumber.TextAlign = ContentAlignment.MiddleRight;
      this.lblLastName.Location = new System.Drawing.Point(15, 92);
      this.lblLastName.Name = "lblLastName";
      this.lblLastName.Size = new Size(68, 21);
      this.lblLastName.TabIndex = 140;
      this.lblLastName.Text = "Last Name";
      this.lblLastName.TextAlign = ContentAlignment.MiddleRight;
      this.lblFirstname.Location = new System.Drawing.Point(15, 57);
      this.lblFirstname.Name = "lblFirstname";
      this.lblFirstname.Size = new Size(68, 21);
      this.lblFirstname.TabIndex = 139;
      this.lblFirstname.Text = "First Name";
      this.lblFirstname.TextAlign = ContentAlignment.MiddleRight;
      this.txtMobileNumber.Location = new System.Drawing.Point(353, 20);
      this.txtMobileNumber.MaxLength = (int) byte.MaxValue;
      this.txtMobileNumber.Name = "txtMobileNumber";
      this.txtMobileNumber.Size = new Size(170, 21);
      this.txtMobileNumber.TabIndex = 138;
      this.txtMobileNumber.Tag = (object) "";
      this.txtLastname.Location = new System.Drawing.Point(89, 92);
      this.txtLastname.MaxLength = (int) byte.MaxValue;
      this.txtLastname.Name = "txtLastname";
      this.txtLastname.Size = new Size(170, 21);
      this.txtLastname.TabIndex = 137;
      this.txtLastname.Tag = (object) "";
      this.txtFirstName.Location = new System.Drawing.Point(89, 58);
      this.txtFirstName.MaxLength = (int) byte.MaxValue;
      this.txtFirstName.Name = "txtFirstName";
      this.txtFirstName.Size = new Size(170, 21);
      this.txtFirstName.TabIndex = 136;
      this.txtFirstName.Tag = (object) "";
      this.lblTitle.Location = new System.Drawing.Point(15, 21);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new Size(68, 20);
      this.lblTitle.TabIndex = 135;
      this.lblTitle.Text = "Title";
      this.lblTitle.TextAlign = ContentAlignment.MiddleRight;
      this.cboTitle.FormattingEnabled = true;
      this.cboTitle.Location = new System.Drawing.Point(89, 20);
      this.cboTitle.Name = "cboTitle";
      this.cboTitle.Size = new Size(170, 21);
      this.cboTitle.TabIndex = 134;
      this.AutoScaleDimensions = new SizeF(7f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add((Control) this.grpSiteContacts);
      this.Name = nameof (UCContacts);
      this.Size = new Size(1403, 672);
      this.grpSiteContacts.ResumeLayout(false);
      this.grpContacts.ResumeLayout(false);
      this.dgSiteContacts.EndInit();
      this.grpContact.ResumeLayout(false);
      this.grpContact.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual GroupBox grpSiteContacts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpContacts { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgSiteContacts
    {
      get
      {
        return this._dgSiteContacts;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.dgSiteContacts_Click);
        DataGrid dgSiteContacts1 = this._dgSiteContacts;
        if (dgSiteContacts1 != null)
          dgSiteContacts1.Click -= eventHandler;
        this._dgSiteContacts = value;
        DataGrid dgSiteContacts2 = this._dgSiteContacts;
        if (dgSiteContacts2 == null)
          return;
        dgSiteContacts2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkOnContract { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnNewContact
    {
      get
      {
        return this._btnNewContact;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnNewContact_Click);
        Button btnNewContact1 = this._btnNewContact;
        if (btnNewContact1 != null)
          btnNewContact1.Click -= eventHandler;
        this._btnNewContact = value;
        Button btnNewContact2 = this._btnNewContact;
        if (btnNewContact2 == null)
          return;
        btnNewContact2.Click += eventHandler;
      }
    }

    internal virtual Button btnDeleteContact
    {
      get
      {
        return this._btnDeleteContact;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnDeleteContact_Click);
        Button btnDeleteContact1 = this._btnDeleteContact;
        if (btnDeleteContact1 != null)
          btnDeleteContact1.Click -= eventHandler;
        this._btnDeleteContact = value;
        Button btnDeleteContact2 = this._btnDeleteContact;
        if (btnDeleteContact2 == null)
          return;
        btnDeleteContact2.Click += eventHandler;
      }
    }

    internal virtual Button btnSaveContact
    {
      get
      {
        return this._btnSaveContact;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnSaveContact_Click);
        Button btnSaveContact1 = this._btnSaveContact;
        if (btnSaveContact1 != null)
          btnSaveContact1.Click -= eventHandler;
        this._btnSaveContact = value;
        Button btnSaveContact2 = this._btnSaveContact;
        if (btnSaveContact2 == null)
          return;
        btnSaveContact2.Click += eventHandler;
      }
    }

    internal virtual CheckBox chkNoMarketing { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtEmailAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblMobileNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblLastName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblFirstname { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtMobileNumber { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtLastname { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtFirstName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboTitle { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkIsPOC { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblRelationship { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboRelationship { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtPostcode { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtAddress1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public UCContacts(FSM.Entity.Sites.Site oSite)
    {
      this.Load += new EventHandler(this.UCSite_Load);
      this._dvSiteContacts = (DataView) null;
      this.InitializeComponent();
      this.CurrentSite = oSite;
      ComboBox cboTitle = this.cboTitle;
      Combo.SetUpCombo(ref cboTitle, DynamicDataTables.Salutation, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
      this.cboTitle = cboTitle;
      ComboBox cboRelationship = this.cboRelationship;
      Combo.SetUpCombo(ref cboRelationship, App.DB.Picklists.GetAll(Enums.PickListTypes.Relationship, false).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
      this.cboRelationship = cboRelationship;
    }

    ~UCContacts()
    {
      // ISSUE: explicit finalizer call
      base.Finalize();
    }

    private void UCSite_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    public void LoadForm(object sender, EventArgs e)
    {
      this.SetupSiteContactsDataGrid();
      this.PopulateSiteContactsDataGrid();
    }

    public void Populate(int ID = 0)
    {
      throw new NotImplementedException();
    }

    public bool Save()
    {
      throw new NotImplementedException();
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
      }
    }

    public Contact CurrentContact
    {
      get
      {
        return this._oContact;
      }
      set
      {
        this._oContact = value;
        if (this.CurrentContact == null)
        {
          this.CurrentContact = new Contact();
          this.CurrentContact.Exists = false;
        }
        if (!this.CurrentContact.Exists)
          return;
        ComboBox combo = this.cboTitle;
        Combo.SetSelectedComboItem_By_Value(ref combo, this.CurrentContact.Salutation);
        this.cboTitle = combo;
        this.txtFirstName.Text = this.CurrentContact.FirstName;
        this.txtLastname.Text = this.CurrentContact.Surname;
        this.txtMobileNumber.Text = this.CurrentContact.MobileNo;
        this.txtEmailAddress.Text = this.CurrentContact.EmailAddress;
        this.txtAddress1.Text = this.CurrentContact.Address1;
        this.txtAddress2.Text = this.CurrentContact.Address2;
        this.txtAddress3.Text = this.CurrentContact.Address3;
        this.txtPostcode.Text = this.CurrentContact.Postcode;
        this.chkNoMarketing.Checked = Helper.MakeBooleanValid((object) this.CurrentContact.NoMarketing);
        this.chkOnContract.Checked = Helper.MakeBooleanValid((object) this.CurrentContact.OnContract);
        combo = this.cboRelationship;
        Combo.SetSelectedComboItem_By_Value(ref combo, Conversions.ToString(this.CurrentContact.RelationshipID));
        this.cboRelationship = combo;
        this.chkIsPOC.Checked = Helper.MakeBooleanValid((object) this.CurrentContact.PointOfContact);
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public DataView SiteContactsDataView
    {
      get
      {
        return this._dvSiteContacts;
      }
      set
      {
        this._dvSiteContacts = value;
        this._dvSiteContacts.AllowNew = false;
        this._dvSiteContacts.AllowEdit = false;
        this._dvSiteContacts.AllowDelete = false;
        this._dvSiteContacts.Table.TableName = Enums.TableNames.tblContact.ToString();
        this.dgSiteContacts.DataSource = (object) this.SiteContactsDataView;
      }
    }

    private DataRow SelectedSiteContactDataRow
    {
      get
      {
        return this.dgSiteContacts.CurrentRowIndex != -1 ? this.SiteContactsDataView[this.dgSiteContacts.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public object LoadedItem
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public void SetupSiteContactsDataGrid()
    {
      Helper.SetUpDataGrid(this.dgSiteContacts, false);
      DataGridTableStyle tableStyle = this.dgSiteContacts.TableStyles[0];
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Title";
      dataGridLabelColumn1.MappingName = "Title";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 60;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "First Name";
      dataGridLabelColumn2.MappingName = "FirstName";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Last Name";
      dataGridLabelColumn3.MappingName = "LastName";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Email";
      dataGridLabelColumn4.MappingName = "EmailAddress";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 180;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Mobile";
      dataGridLabelColumn5.MappingName = "mobileNo";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Address1";
      dataGridLabelColumn6.MappingName = "Address1";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 100;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      DataGridLabelColumn dataGridLabelColumn7 = new DataGridLabelColumn();
      dataGridLabelColumn7.Format = "";
      dataGridLabelColumn7.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn7.HeaderText = "Address2";
      dataGridLabelColumn7.MappingName = "Address2";
      dataGridLabelColumn7.ReadOnly = true;
      dataGridLabelColumn7.Width = 100;
      dataGridLabelColumn7.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn7);
      DataGridLabelColumn dataGridLabelColumn8 = new DataGridLabelColumn();
      dataGridLabelColumn8.Format = "";
      dataGridLabelColumn8.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn8.HeaderText = "Address3";
      dataGridLabelColumn8.MappingName = "Address3";
      dataGridLabelColumn8.ReadOnly = true;
      dataGridLabelColumn8.Width = 100;
      dataGridLabelColumn8.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn8);
      DataGridLabelColumn dataGridLabelColumn9 = new DataGridLabelColumn();
      dataGridLabelColumn9.Format = "";
      dataGridLabelColumn9.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn9.HeaderText = "Postcode";
      dataGridLabelColumn9.MappingName = "Postcode";
      dataGridLabelColumn9.ReadOnly = true;
      dataGridLabelColumn9.Width = 100;
      dataGridLabelColumn9.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn9);
      DataGridLabelColumn dataGridLabelColumn10 = new DataGridLabelColumn();
      dataGridLabelColumn10.Format = "";
      dataGridLabelColumn10.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn10.HeaderText = "Relationship To Tennent";
      dataGridLabelColumn10.MappingName = "Relationship";
      dataGridLabelColumn10.ReadOnly = true;
      dataGridLabelColumn10.Width = 150;
      dataGridLabelColumn10.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn10);
      DataGridLabelColumn dataGridLabelColumn11 = new DataGridLabelColumn();
      dataGridLabelColumn11.Format = "";
      dataGridLabelColumn11.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn11.HeaderText = "No Marketing";
      dataGridLabelColumn11.MappingName = "NoMarketing";
      dataGridLabelColumn11.ReadOnly = true;
      dataGridLabelColumn11.Width = 90;
      dataGridLabelColumn11.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn11);
      DataGridLabelColumn dataGridLabelColumn12 = new DataGridLabelColumn();
      dataGridLabelColumn12.Format = "";
      dataGridLabelColumn12.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn12.HeaderText = "On Contract";
      dataGridLabelColumn12.MappingName = "OnContract";
      dataGridLabelColumn12.ReadOnly = true;
      dataGridLabelColumn12.Width = 80;
      dataGridLabelColumn12.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn12);
      DataGridLabelColumn dataGridLabelColumn13 = new DataGridLabelColumn();
      dataGridLabelColumn13.Format = "";
      dataGridLabelColumn13.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn13.HeaderText = "Point Of Contact";
      dataGridLabelColumn13.MappingName = "POC";
      dataGridLabelColumn13.ReadOnly = true;
      dataGridLabelColumn13.Width = 105;
      dataGridLabelColumn13.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn13);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblContact.ToString();
      this.dgSiteContacts.TableStyles.Add(tableStyle);
    }

    private void PopulateSiteContactsDataGrid()
    {
      try
      {
        this.SiteContactsDataView = App.DB.Contact.Contacts_GetAll_ForLink(Helper.MakeIntegerValid((object) Enums.TableNames.tblSite), this.CurrentSite.SiteID, false);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Form cannot setup : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void Clear()
    {
      this.CurrentContact = (Contact) null;
      ComboBox cboTitle = this.cboTitle;
      Combo.SetSelectedComboItem_By_Value(ref cboTitle, Conversions.ToString(0));
      this.cboTitle = cboTitle;
      this.txtFirstName.Text = string.Empty;
      this.txtLastname.Text = string.Empty;
      this.txtMobileNumber.Text = string.Empty;
      this.txtEmailAddress.Text = string.Empty;
      this.txtAddress1.Text = string.Empty;
      this.txtAddress2.Text = string.Empty;
      this.txtAddress3.Text = string.Empty;
      this.txtPostcode.Text = string.Empty;
      this.chkNoMarketing.Checked = false;
      this.chkOnContract.Checked = false;
      ComboBox cboRelationship = this.cboRelationship;
      Combo.SetSelectedComboItem_By_Value(ref cboRelationship, Conversions.ToString(0));
      this.cboRelationship = cboRelationship;
      this.chkIsPOC.Checked = false;
      this.btnSaveContact.Text = "Save";
    }

    private void btnSaveContact_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        if (this.CurrentContact == null)
          this.CurrentContact = new Contact();
        IEnumerator enumerator;
        if (this.chkIsPOC.Checked)
        {
          try
          {
            enumerator = this.SiteContactsDataView.GetEnumerator();
            while (enumerator.MoveNext())
            {
              DataRowView current = (DataRowView) enumerator.Current;
              if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current["POC"], (object) true, false) && Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(current["ContactID"], (object) this.CurrentContact.ContactID, false))
              {
                if (App.ShowMessage("Another contact is currently set as point of contact, do you wish to change it to this contact?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                  Contact oContact = App.DB.Contact.Contacts_Get(Conversions.ToInteger(current["ContactID"]));
                  oContact.SetPointOfContact = false;
                  App.DB.Contact.Contacts_Update(oContact);
                }
                else
                  this.chkIsPOC.Checked = false;
              }
            }
          }
          finally
          {
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
        }
        Contact currentContact = this.CurrentContact;
        currentContact.SetSalutation = (object) Combo.get_GetSelectedItemDescription(this.cboTitle);
        currentContact.SetFirstName = (object) Helper.MakeStringValid((object) this.txtFirstName.Text);
        currentContact.SetSurname = (object) Helper.MakeStringValid((object) this.txtLastname.Text);
        currentContact.SetMobileNo = (object) Helper.MakeStringValid((object) this.txtMobileNumber.Text);
        currentContact.SetEmailAddress = (object) Helper.MakeStringValid((object) this.txtEmailAddress.Text);
        currentContact.SetAddress1 = (object) Helper.MakeStringValid((object) this.txtAddress1.Text);
        currentContact.SetAddress2 = (object) Helper.MakeStringValid((object) this.txtAddress2.Text);
        currentContact.SetAddress3 = (object) Helper.MakeStringValid((object) this.txtAddress3.Text);
        currentContact.SetPostcode = (object) Helper.FormatPostcode((object) this.txtPostcode.Text);
        currentContact.SetNoMarketing = this.chkNoMarketing.Checked;
        currentContact.SetLinkID = (object) Helper.MakeIntegerValid((object) Enums.TableNames.tblSite);
        currentContact.SetLinkRef = (object) this.CurrentSite.SiteID;
        currentContact.SetOnContract = this.chkOnContract.Checked;
        currentContact.SetRelationshipID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(this.cboRelationship));
        currentContact.SetPointOfContact = this.chkIsPOC.Checked;
        new ContactValidator().Validate(this.CurrentContact);
        App.DB.Contact.Contacts_Update(this.CurrentContact);
        this.PopulateSiteContactsDataGrid();
        this.Clear();
      }
      catch (ValidationException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        int num = (int) App.ShowMessage(string.Format("Please correct the following errors: \r\n{0}{1}", (object) "\r\n", (object) ex.Validator.CriticalMessagesString()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage("Data cannot save : \r\n" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
      finally
      {
        this.Cursor = Cursors.Default;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void btnDeleteContact_Click(object sender, EventArgs e)
    {
      if (App.ShowMessage(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) "Remove ", this.SelectedSiteContactDataRow["FirstName"]), (object) "?"), (object) "\r\n"), (object) "\r\n"), (object) "Are you sure?")), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        return;
      int contactId = Helper.MakeIntegerValid(RuntimeHelpers.GetObjectValue(this.SelectedSiteContactDataRow["ContactID"]));
      try
      {
        App.DB.Contact.Contacts_Delete(contactId);
        this.PopulateSiteContactsDataGrid();
        FileSystem.Reset();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) App.ShowMessage(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        ProjectData.ClearProjectError();
      }
    }

    private void dgSiteContacts_Click(object sender, EventArgs e)
    {
      if (this.SelectedSiteContactDataRow == null)
        return;
      this.CurrentContact = App.DB.Contact.Contacts_Get(Conversions.ToInteger(this.SelectedSiteContactDataRow["ContactID"]));
      this.btnSaveContact.Text = "Update";
    }

    private void btnNewContact_Click(object sender, EventArgs e)
    {
      this.Clear();
    }
  }
}
