// Decompiled with JetBrains decompiler
// Type: FSM.FRMSelectInvoiceAddress
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.InvoiceAddresss;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
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
  public class FRMSelectInvoiceAddress : FRMBaseForm, IForm
  {
    private IContainer components;
    private int _SiteID;
    private FSM.Entity.Sites.Site _Site;
    private FSM.Entity.Sites.Site _TheHQ;
    private DataView _InvoiceAddresses;
    private int _AddressLinkID;
    private int _AddressTypeID;

    public FRMSelectInvoiceAddress(int SiteIDIn)
    {
      this.Load += new EventHandler(this.FRMSelectInvoiceAddress_Load);
      this._SiteID = 0;
      this._Site = (FSM.Entity.Sites.Site) null;
      this._TheHQ = (FSM.Entity.Sites.Site) null;
      this._InvoiceAddresses = (DataView) null;
      this._AddressLinkID = 0;
      this._AddressTypeID = 0;
      this.InitializeComponent();
      this.SiteID = SiteIDIn;
      if (true == App.IsGasway)
      {
        ComboBox cboDept = this.cboDept;
        Combo.SetUpCombo(ref cboDept, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
        this.cboDept = cboDept;
      }
      else
      {
        ComboBox cboDept = this.cboDept;
        Combo.SetUpCombo(ref cboDept, App.DB.Picklists.GetAll(Enums.PickListTypes.Department, false).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
        this.cboDept = cboDept;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual Button btnOK
    {
      get
      {
        return this._btnOK;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnOK_Click);
        Button btnOk1 = this._btnOK;
        if (btnOk1 != null)
          btnOk1.Click -= eventHandler;
        this._btnOK = value;
        Button btnOk2 = this._btnOK;
        if (btnOk2 == null)
          return;
        btnOk2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpHO { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkHO { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtHO { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpProperty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkProperty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtProperty { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual GroupBox grpInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual DataGrid dgInvoiceAddresses { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnAdd
    {
      get
      {
        return this._btnAdd;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnAdd_Click);
        Button btnAdd1 = this._btnAdd;
        if (btnAdd1 != null)
          btnAdd1.Click -= eventHandler;
        this._btnAdd = value;
        Button btnAdd2 = this._btnAdd;
        if (btnAdd2 == null)
          return;
        btnAdd2.Click += eventHandler;
      }
    }

    internal virtual GroupBox grpDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual CheckBox chkDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboDept { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnCancel
    {
      get
      {
        return this._btnCancel;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnCancel_Click);
        Button btnCancel1 = this._btnCancel;
        if (btnCancel1 != null)
          btnCancel1.Click -= eventHandler;
        this._btnCancel = value;
        Button btnCancel2 = this._btnCancel;
        if (btnCancel2 == null)
          return;
        btnCancel2.Click += eventHandler;
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.grpHO = new GroupBox();
      this.chkHO = new CheckBox();
      this.txtHO = new TextBox();
      this.grpProperty = new GroupBox();
      this.chkProperty = new CheckBox();
      this.txtProperty = new TextBox();
      this.grpInvoiceAddress = new GroupBox();
      this.btnAdd = new Button();
      this.dgInvoiceAddresses = new DataGrid();
      this.chkInvoiceAddress = new CheckBox();
      this.grpDept = new GroupBox();
      this.chkDept = new CheckBox();
      this.cboDept = new ComboBox();
      this.grpHO.SuspendLayout();
      this.grpProperty.SuspendLayout();
      this.grpInvoiceAddress.SuspendLayout();
      this.dgInvoiceAddresses.BeginInit();
      this.grpDept.SuspendLayout();
      this.SuspendLayout();
      this.btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.btnOK.Location = new System.Drawing.Point(1185, 515);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btnCancel.Location = new System.Drawing.Point(8, 515);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.grpHO.Controls.Add((Control) this.chkHO);
      this.grpHO.Controls.Add((Control) this.txtHO);
      this.grpHO.Location = new System.Drawing.Point(8, 38);
      this.grpHO.Name = "grpHO";
      this.grpHO.Size = new Size(411, 232);
      this.grpHO.TabIndex = 7;
      this.grpHO.TabStop = false;
      this.grpHO.Text = "Head Office";
      this.chkHO.AutoSize = true;
      this.chkHO.Location = new System.Drawing.Point(6, 20);
      this.chkHO.Name = "chkHO";
      this.chkHO.Size = new Size(61, 17);
      this.chkHO.TabIndex = 1;
      this.chkHO.Text = "Select";
      this.chkHO.UseVisualStyleBackColor = true;
      this.txtHO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtHO.Location = new System.Drawing.Point(6, 43);
      this.txtHO.Multiline = true;
      this.txtHO.Name = "txtHO";
      this.txtHO.ReadOnly = true;
      this.txtHO.ScrollBars = ScrollBars.Both;
      this.txtHO.Size = new Size(399, 183);
      this.txtHO.TabIndex = 0;
      this.grpProperty.Controls.Add((Control) this.chkProperty);
      this.grpProperty.Controls.Add((Control) this.txtProperty);
      this.grpProperty.Location = new System.Drawing.Point(425, 38);
      this.grpProperty.Name = "grpProperty";
      this.grpProperty.Size = new Size(411, 232);
      this.grpProperty.TabIndex = 8;
      this.grpProperty.TabStop = false;
      this.grpProperty.Text = "Property";
      this.chkProperty.AutoSize = true;
      this.chkProperty.Location = new System.Drawing.Point(6, 20);
      this.chkProperty.Name = "chkProperty";
      this.chkProperty.Size = new Size(61, 17);
      this.chkProperty.TabIndex = 1;
      this.chkProperty.Text = "Select";
      this.chkProperty.UseVisualStyleBackColor = true;
      this.txtProperty.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtProperty.Location = new System.Drawing.Point(6, 43);
      this.txtProperty.Multiline = true;
      this.txtProperty.Name = "txtProperty";
      this.txtProperty.ReadOnly = true;
      this.txtProperty.ScrollBars = ScrollBars.Both;
      this.txtProperty.Size = new Size(399, 183);
      this.txtProperty.TabIndex = 0;
      this.grpInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.grpInvoiceAddress.Controls.Add((Control) this.btnAdd);
      this.grpInvoiceAddress.Controls.Add((Control) this.dgInvoiceAddresses);
      this.grpInvoiceAddress.Controls.Add((Control) this.chkInvoiceAddress);
      this.grpInvoiceAddress.Location = new System.Drawing.Point(8, 276);
      this.grpInvoiceAddress.Name = "grpInvoiceAddress";
      this.grpInvoiceAddress.Size = new Size(1248, 233);
      this.grpInvoiceAddress.TabIndex = 9;
      this.grpInvoiceAddress.TabStop = false;
      this.grpInvoiceAddress.Text = "Invoice Address";
      this.btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnAdd.Location = new System.Drawing.Point(1167, 16);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new Size(75, 23);
      this.btnAdd.TabIndex = 11;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.dgInvoiceAddresses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dgInvoiceAddresses.DataMember = "";
      this.dgInvoiceAddresses.HeaderForeColor = SystemColors.ControlText;
      this.dgInvoiceAddresses.Location = new System.Drawing.Point(6, 43);
      this.dgInvoiceAddresses.Name = "dgInvoiceAddresses";
      this.dgInvoiceAddresses.Size = new Size(1236, 184);
      this.dgInvoiceAddresses.TabIndex = 10;
      this.chkInvoiceAddress.AutoSize = true;
      this.chkInvoiceAddress.Location = new System.Drawing.Point(6, 20);
      this.chkInvoiceAddress.Name = "chkInvoiceAddress";
      this.chkInvoiceAddress.Size = new Size(61, 17);
      this.chkInvoiceAddress.TabIndex = 1;
      this.chkInvoiceAddress.Text = "Select";
      this.chkInvoiceAddress.UseVisualStyleBackColor = true;
      this.grpDept.Controls.Add((Control) this.cboDept);
      this.grpDept.Controls.Add((Control) this.chkDept);
      this.grpDept.Location = new System.Drawing.Point(842, 38);
      this.grpDept.Name = "grpDept";
      this.grpDept.Size = new Size(408, 232);
      this.grpDept.TabIndex = 9;
      this.grpDept.TabStop = false;
      this.grpDept.Text = "Department";
      this.chkDept.AutoSize = true;
      this.chkDept.Location = new System.Drawing.Point(6, 20);
      this.chkDept.Name = "chkDept";
      this.chkDept.Size = new Size(61, 17);
      this.chkDept.TabIndex = 1;
      this.chkDept.Text = "Select";
      this.chkDept.UseVisualStyleBackColor = true;
      this.cboDept.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboDept.FormattingEnabled = true;
      this.cboDept.Location = new System.Drawing.Point(93, 18);
      this.cboDept.Name = "cboDept";
      this.cboDept.Size = new Size(309, 21);
      this.cboDept.TabIndex = 33;
      this.AutoScaleBaseSize = new Size(6, 14);
      this.ClientSize = new Size(1265, 545);
      this.ControlBox = false;
      this.Controls.Add((Control) this.grpDept);
      this.Controls.Add((Control) this.grpInvoiceAddress);
      this.Controls.Add((Control) this.grpProperty);
      this.Controls.Add((Control) this.grpHO);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.MinimumSize = new Size(853, 530);
      this.Name = nameof (FRMSelectInvoiceAddress);
      this.Text = "Select an address for the invoice";
      this.Controls.SetChildIndex((Control) this.btnOK, 0);
      this.Controls.SetChildIndex((Control) this.btnCancel, 0);
      this.Controls.SetChildIndex((Control) this.grpHO, 0);
      this.Controls.SetChildIndex((Control) this.grpProperty, 0);
      this.Controls.SetChildIndex((Control) this.grpInvoiceAddress, 0);
      this.Controls.SetChildIndex((Control) this.grpDept, 0);
      this.grpHO.ResumeLayout(false);
      this.grpHO.PerformLayout();
      this.grpProperty.ResumeLayout(false);
      this.grpProperty.PerformLayout();
      this.grpInvoiceAddress.ResumeLayout(false);
      this.grpInvoiceAddress.PerformLayout();
      this.dgInvoiceAddresses.EndInit();
      this.grpDept.ResumeLayout(false);
      this.grpDept.PerformLayout();
      this.ResumeLayout(false);
    }

    void IForm.LoadMe(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e, (IForm) this);
      this.SetupDG();
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

    public int SiteID
    {
      get
      {
        return this._SiteID;
      }
      set
      {
        this._SiteID = value;
        this.TheSite = App.DB.Sites.Get((object) this.SiteID, SiteSQL.GetBy.SiteId, (object) null);
        this.TheHQ = App.DB.Sites.Get((object) this.TheSite.CustomerID, SiteSQL.GetBy.CustomerHq, (object) null);
        if (this.TheHQ == null)
        {
          this.txtHO.Text = "No Head Office Assigned";
          this.chkHO.Enabled = false;
        }
        this.InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_GetForSite(this.SiteID);
      }
    }

    public FSM.Entity.Sites.Site TheSite
    {
      get
      {
        return this._Site;
      }
      set
      {
        this._Site = value;
        string str = "";
        if (this.TheSite.Name.Trim().Length > 0)
          str = str + this.TheSite.Name + "\r\n";
        if (this.TheSite.Address1.Trim().Length > 0)
          str = str + this.TheSite.Address1 + "\r\n";
        if (this.TheSite.Address2.Trim().Length > 0)
          str = str + this.TheSite.Address2 + "\r\n";
        if (this.TheSite.Address3.Trim().Length > 0)
          str = str + this.TheSite.Address3 + "\r\n";
        if (this.TheSite.Address4.Trim().Length > 0)
          str = str + this.TheSite.Address4 + "\r\n";
        if (this.TheSite.Address5.Trim().Length > 0)
          str = str + this.TheSite.Address5 + "\r\n";
        if (this.TheSite.Postcode.Trim().Length > 0)
          str = str + this.TheSite.Postcode + "\r\n";
        this.txtProperty.Text = str;
      }
    }

    public FSM.Entity.Sites.Site TheHQ
    {
      get
      {
        return this._TheHQ;
      }
      set
      {
        this._TheHQ = value;
        if (this.TheHQ == null || !this.TheHQ.Exists)
          return;
        string str = "";
        if (this.TheHQ.Name.Trim().Length > 0)
          str = str + this.TheHQ.Name + "\r\n";
        if (this.TheHQ.Address1.Trim().Length > 0)
          str = str + this.TheHQ.Address1 + "\r\n";
        if (this.TheHQ.Address2.Trim().Length > 0)
          str = str + this.TheHQ.Address2 + "\r\n";
        if (this.TheHQ.Address3.Trim().Length > 0)
          str = str + this.TheHQ.Address3 + "\r\n";
        if (this.TheHQ.Address4.Trim().Length > 0)
          str = str + this.TheHQ.Address4 + "\r\n";
        if (this.TheHQ.Address5.Trim().Length > 0)
          str = str + this.TheHQ.Address5 + "\r\n";
        if (this.TheHQ.Postcode.Trim().Length > 0)
          str = str + this.TheHQ.Postcode + "\r\n";
        this.txtHO.Text = str;
      }
    }

    public DataView InvoiceAddresses
    {
      get
      {
        return this._InvoiceAddresses;
      }
      set
      {
        this._InvoiceAddresses = value;
        this._InvoiceAddresses.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
        this._InvoiceAddresses.AllowNew = false;
        this._InvoiceAddresses.AllowEdit = false;
        this._InvoiceAddresses.AllowDelete = false;
        this.dgInvoiceAddresses.DataSource = (object) this.InvoiceAddresses;
      }
    }

    private DataRow SelectedInvoiceAddress
    {
      get
      {
        return this.dgInvoiceAddresses.CurrentRowIndex != -1 ? this.InvoiceAddresses[this.dgInvoiceAddresses.CurrentRowIndex].Row : (DataRow) null;
      }
    }

    public int AddressLinkID
    {
      get
      {
        return this._AddressLinkID;
      }
      set
      {
        this._AddressLinkID = value;
      }
    }

    public int AddressTypeID
    {
      get
      {
        return this._AddressTypeID;
      }
      set
      {
        this._AddressTypeID = value;
      }
    }

    private void SetupDG()
    {
      Helper.SetUpDataGrid(this.dgInvoiceAddresses, false);
      DataGridTableStyle tableStyle = this.dgInvoiceAddresses.TableStyles[0];
      tableStyle.GridColumnStyles.Clear();
      DataGridLabelColumn dataGridLabelColumn1 = new DataGridLabelColumn();
      dataGridLabelColumn1.Format = "";
      dataGridLabelColumn1.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn1.HeaderText = "Address 1";
      dataGridLabelColumn1.MappingName = "Address1";
      dataGridLabelColumn1.ReadOnly = true;
      dataGridLabelColumn1.Width = 100;
      dataGridLabelColumn1.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn1);
      DataGridLabelColumn dataGridLabelColumn2 = new DataGridLabelColumn();
      dataGridLabelColumn2.Format = "";
      dataGridLabelColumn2.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn2.HeaderText = "Address 2";
      dataGridLabelColumn2.MappingName = "Address2";
      dataGridLabelColumn2.ReadOnly = true;
      dataGridLabelColumn2.Width = 100;
      dataGridLabelColumn2.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn2);
      DataGridLabelColumn dataGridLabelColumn3 = new DataGridLabelColumn();
      dataGridLabelColumn3.Format = "";
      dataGridLabelColumn3.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn3.HeaderText = "Address 3";
      dataGridLabelColumn3.MappingName = "Address3";
      dataGridLabelColumn3.ReadOnly = true;
      dataGridLabelColumn3.Width = 100;
      dataGridLabelColumn3.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn3);
      DataGridLabelColumn dataGridLabelColumn4 = new DataGridLabelColumn();
      dataGridLabelColumn4.Format = "";
      dataGridLabelColumn4.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn4.HeaderText = "Address 4";
      dataGridLabelColumn4.MappingName = "Address4";
      dataGridLabelColumn4.ReadOnly = true;
      dataGridLabelColumn4.Width = 100;
      dataGridLabelColumn4.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn4);
      DataGridLabelColumn dataGridLabelColumn5 = new DataGridLabelColumn();
      dataGridLabelColumn5.Format = "";
      dataGridLabelColumn5.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn5.HeaderText = "Address5";
      dataGridLabelColumn5.MappingName = "Address5";
      dataGridLabelColumn5.ReadOnly = true;
      dataGridLabelColumn5.Width = 100;
      dataGridLabelColumn5.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn5);
      DataGridLabelColumn dataGridLabelColumn6 = new DataGridLabelColumn();
      dataGridLabelColumn6.Format = "";
      dataGridLabelColumn6.FormatInfo = (IFormatProvider) null;
      dataGridLabelColumn6.HeaderText = "Postcode";
      dataGridLabelColumn6.MappingName = "Postcode";
      dataGridLabelColumn6.ReadOnly = true;
      dataGridLabelColumn6.Width = 75;
      dataGridLabelColumn6.NullText = "";
      tableStyle.GridColumnStyles.Add((DataGridColumnStyle) dataGridLabelColumn6);
      tableStyle.ReadOnly = true;
      tableStyle.MappingName = Enums.TableNames.tblInvoiceAddress.ToString();
      this.dgInvoiceAddresses.TableStyles.Add(tableStyle);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      int num1 = 0;
      if (this.chkHO.Checked)
        checked { ++num1; }
      if (this.chkProperty.Checked)
        checked { ++num1; }
      if (this.chkInvoiceAddress.Checked)
        checked { ++num1; }
      if (this.chkDept.Checked)
        checked { ++num1; }
      switch (num1)
      {
        case 0:
          int num2 = (int) App.ShowMessage("You have not selected an address", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
        case 1:
          if (this.chkInvoiceAddress.Checked && this.SelectedInvoiceAddress == null)
          {
            int num3 = (int) App.ShowMessage("You have not selected an address", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            break;
          }
          if (this.chkHO.Checked)
          {
            this.AddressLinkID = this.TheHQ.SiteID;
            this.AddressTypeID = 254;
          }
          if (this.chkProperty.Checked)
          {
            this.AddressLinkID = this.SiteID;
            this.AddressTypeID = 253;
          }
          if (this.chkInvoiceAddress.Checked)
          {
            this.AddressLinkID = Conversions.ToInteger(this.SelectedInvoiceAddress["InvoiceAddressID"]);
            this.AddressTypeID = 258;
          }
          if (this.chkDept.Checked)
          {
            InvoiceAddress oInvoiceAddress = new InvoiceAddress();
            InvoiceAddress invoiceAddress = oInvoiceAddress;
            invoiceAddress.SetAddress1 = (object) ("DEPT " + Combo.get_GetSelectedItemValue(this.cboDept));
            invoiceAddress.SetAddress2 = (object) App.TheSystem.Configuration.CompanyName;
            invoiceAddress.SetAddress3 = (object) App.TheSystem.Configuration.CompanyAddres1;
            invoiceAddress.SetAddress4 = (object) App.TheSystem.Configuration.CompanyAddres3;
            invoiceAddress.SetAddress5 = (object) string.Empty;
            invoiceAddress.SetPostcode = (object) App.TheSystem.Configuration.CompanyPostcode;
            invoiceAddress.SetSiteID = (object) this.SiteID;
            this.AddressLinkID = App.DB.InvoiceAddress.Insert(oInvoiceAddress)?.InvoiceAddressID.Value;
            this.AddressTypeID = 258;
          }
          this.DialogResult = DialogResult.OK;
          break;
        default:
          int num4 = (int) App.ShowMessage("You can only select a single address for the invoice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
          break;
      }
    }

    private void FRMSelectInvoiceAddress_Load(object sender, EventArgs e)
    {
      this.LoadMe(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      App.ShowForm(typeof (FRMInvoiceAddress), true, new object[3]
      {
        (object) 0,
        (object) this.SiteID,
        (object) this
      }, false);
      this.SiteID = this.SiteID;
    }
  }
}
