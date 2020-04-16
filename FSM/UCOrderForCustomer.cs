// Decompiled with JetBrains decompiler
// Type: FSM.UCOrderForCustomer
// Assembly: FSM, Version=1.12.1.0, Culture=neutral, PublicKeyToken=null
// MVID: FAB6F0E2-B68A-47AB-AF95-A9E31DED7575
// Assembly location: C:\github\gabriel.fieldservicemanager\src\bin\x86\Debug\FSM.exe

using FSM.Entity.Contacts;
using FSM.Entity.InvoiceAddresss;
using FSM.Entity.Sites;
using FSM.Entity.Sys;
using FSM.Entity.Warehouses;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
  public class UCOrderForCustomer : UCBase, IUserControl
  {
    private IContainer components;
    private FSM.Entity.Customers.Customer _oCustomer;
    private FSM.Entity.Sites.Site _oProperty;
    private Warehouse _oWarehouse;
    private InvoiceAddress _invoiceAddress;
    private Contact _contact;

    public UCOrderForCustomer()
    {
      this.Load += new EventHandler(this.UCOrderForCustomer_Load);
      this._invoiceAddress = new InvoiceAddress();
      this._contact = new Contact();
      this.InitializeComponent();
      ComboBox cboUsers = this.cboUsers;
      Combo.SetUpCombo(ref cboUsers, App.DB.User.GetAll().Table, "UserID", "FullName", Enums.ComboValues.Please_Select);
      this.cboUsers = cboUsers;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindSite
    {
      get
      {
        return this._btnFindSite;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindSite_Click);
        Button btnFindSite1 = this._btnFindSite;
        if (btnFindSite1 != null)
          btnFindSite1.Click -= eventHandler;
        this._btnFindSite = value;
        Button btnFindSite2 = this._btnFindSite;
        if (btnFindSite2 == null)
          return;
        btnFindSite2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtSite { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindCustomer
    {
      get
      {
        return this._btnFindCustomer;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindCustomer_Click);
        Button btnFindCustomer1 = this._btnFindCustomer;
        if (btnFindCustomer1 != null)
          btnFindCustomer1.Click -= eventHandler;
        this._btnFindCustomer = value;
        Button btnFindCustomer2 = this._btnFindCustomer;
        if (btnFindCustomer2 == null)
          return;
        btnFindCustomer2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtCustomer { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindWarehouse
    {
      get
      {
        return this._btnFindWarehouse;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindWarehouse_Click);
        Button btnFindWarehouse1 = this._btnFindWarehouse;
        if (btnFindWarehouse1 != null)
          btnFindWarehouse1.Click -= eventHandler;
        this._btnFindWarehouse = value;
        Button btnFindWarehouse2 = this._btnFindWarehouse;
        if (btnFindWarehouse2 == null)
          return;
        btnFindWarehouse2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtWarehouse { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label lblSpecial { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual TextBox txtSpecialInstructions { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox cboUsers { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label13 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindContact
    {
      get
      {
        return this._btnFindContact;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindContact_Click);
        Button btnFindContact1 = this._btnFindContact;
        if (btnFindContact1 != null)
          btnFindContact1.Click -= eventHandler;
        this._btnFindContact = value;
        Button btnFindContact2 = this._btnFindContact;
        if (btnFindContact2 == null)
          return;
        btnFindContact2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtContact { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label14 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button btnFindInvoiceAddress
    {
      get
      {
        return this._btnFindInvoiceAddress;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.btnFindInvoiceAddress_Click);
        Button findInvoiceAddress1 = this._btnFindInvoiceAddress;
        if (findInvoiceAddress1 != null)
          findInvoiceAddress1.Click -= eventHandler;
        this._btnFindInvoiceAddress = value;
        Button findInvoiceAddress2 = this._btnFindInvoiceAddress;
        if (findInvoiceAddress2 == null)
          return;
        findInvoiceAddress2.Click += eventHandler;
      }
    }

    internal virtual TextBox txtInvoiceAddress { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Label Label15 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.btnFindWarehouse = new Button();
      this.txtWarehouse = new TextBox();
      this.Label4 = new Label();
      this.btnFindSite = new Button();
      this.txtSite = new TextBox();
      this.Label1 = new Label();
      this.btnFindCustomer = new Button();
      this.txtCustomer = new TextBox();
      this.Label3 = new Label();
      this.lblSpecial = new Label();
      this.txtSpecialInstructions = new TextBox();
      this.cboUsers = new ComboBox();
      this.Label13 = new Label();
      this.btnFindContact = new Button();
      this.txtContact = new TextBox();
      this.Label14 = new Label();
      this.btnFindInvoiceAddress = new Button();
      this.txtInvoiceAddress = new TextBox();
      this.Label15 = new Label();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add((Control) this.lblSpecial);
      this.GroupBox1.Controls.Add((Control) this.txtSpecialInstructions);
      this.GroupBox1.Controls.Add((Control) this.cboUsers);
      this.GroupBox1.Controls.Add((Control) this.Label13);
      this.GroupBox1.Controls.Add((Control) this.btnFindContact);
      this.GroupBox1.Controls.Add((Control) this.txtContact);
      this.GroupBox1.Controls.Add((Control) this.Label14);
      this.GroupBox1.Controls.Add((Control) this.btnFindInvoiceAddress);
      this.GroupBox1.Controls.Add((Control) this.txtInvoiceAddress);
      this.GroupBox1.Controls.Add((Control) this.Label15);
      this.GroupBox1.Controls.Add((Control) this.btnFindWarehouse);
      this.GroupBox1.Controls.Add((Control) this.txtWarehouse);
      this.GroupBox1.Controls.Add((Control) this.Label4);
      this.GroupBox1.Controls.Add((Control) this.btnFindSite);
      this.GroupBox1.Controls.Add((Control) this.txtSite);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.Controls.Add((Control) this.btnFindCustomer);
      this.GroupBox1.Controls.Add((Control) this.txtCustomer);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Location = new System.Drawing.Point(4, 8);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(576, 392);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Customer Details";
      this.btnFindWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindWarehouse.BackColor = Color.White;
      this.btnFindWarehouse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindWarehouse.Location = new System.Drawing.Point(528, 133);
      this.btnFindWarehouse.Name = "btnFindWarehouse";
      this.btnFindWarehouse.Size = new Size(32, 23);
      this.btnFindWarehouse.TabIndex = 6;
      this.btnFindWarehouse.Text = "...";
      this.txtWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtWarehouse.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtWarehouse.Location = new System.Drawing.Point(128, 133);
      this.txtWarehouse.Name = "txtWarehouse";
      this.txtWarehouse.ReadOnly = true;
      this.txtWarehouse.Size = new Size(392, 21);
      this.txtWarehouse.TabIndex = 5;
      this.txtWarehouse.Text = "";
      this.Label4.BackColor = Color.White;
      this.Label4.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label4.Location = new System.Drawing.Point(8, 128);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(72, 20);
      this.Label4.TabIndex = 51;
      this.Label4.Text = "Warehouse";
      this.btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindSite.BackColor = Color.White;
      this.btnFindSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindSite.Location = new System.Drawing.Point(528, 97);
      this.btnFindSite.Name = "btnFindSite";
      this.btnFindSite.Size = new Size(32, 23);
      this.btnFindSite.TabIndex = 4;
      this.btnFindSite.Text = "...";
      this.txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSite.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtSite.Location = new System.Drawing.Point(128, 97);
      this.txtSite.Name = "txtSite";
      this.txtSite.ReadOnly = true;
      this.txtSite.Size = new Size(392, 21);
      this.txtSite.TabIndex = 3;
      this.txtSite.Text = "";
      this.Label1.BackColor = Color.White;
      this.Label1.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new System.Drawing.Point(8, 96);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(72, 20);
      this.Label1.TabIndex = 47;
      this.Label1.Text = "Property";
      this.btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindCustomer.BackColor = Color.White;
      this.btnFindCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindCustomer.Location = new System.Drawing.Point(528, 25);
      this.btnFindCustomer.Name = "btnFindCustomer";
      this.btnFindCustomer.Size = new Size(32, 23);
      this.btnFindCustomer.TabIndex = 2;
      this.btnFindCustomer.Text = "...";
      this.txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtCustomer.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtCustomer.Location = new System.Drawing.Point(8, 25);
      this.txtCustomer.Name = "txtCustomer";
      this.txtCustomer.ReadOnly = true;
      this.txtCustomer.Size = new Size(512, 21);
      this.txtCustomer.TabIndex = 1;
      this.txtCustomer.Text = "";
      this.Label3.ForeColor = SystemColors.ControlText;
      this.Label3.Location = new System.Drawing.Point(8, 56);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(560, 23);
      this.Label3.TabIndex = 41;
      this.Label3.Text = "Please select a property to deliver to.  If property is currently unknown, select a warehouse to deliver to.";
      this.lblSpecial.Location = new System.Drawing.Point(8, 280);
      this.lblSpecial.Name = "lblSpecial";
      this.lblSpecial.Size = new Size(120, 40);
      this.lblSpecial.TabIndex = 119;
      this.lblSpecial.Text = "Special Instructions";
      this.txtSpecialInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.txtSpecialInstructions.Location = new System.Drawing.Point(128, 280);
      this.txtSpecialInstructions.Multiline = true;
      this.txtSpecialInstructions.Name = "txtSpecialInstructions";
      this.txtSpecialInstructions.ScrollBars = ScrollBars.Vertical;
      this.txtSpecialInstructions.Size = new Size(392, 66);
      this.txtSpecialInstructions.TabIndex = 118;
      this.txtSpecialInstructions.Text = "";
      this.cboUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.cboUsers.Location = new System.Drawing.Point(128, 232);
      this.cboUsers.Name = "cboUsers";
      this.cboUsers.Size = new Size(392, 21);
      this.cboUsers.TabIndex = 114;
      this.Label13.Location = new System.Drawing.Point(8, 230);
      this.Label13.Name = "Label13";
      this.Label13.Size = new Size(112, 24);
      this.Label13.TabIndex = 117;
      this.Label13.Text = "Co-ordinator";
      this.btnFindContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindContact.BackColor = Color.White;
      this.btnFindContact.Enabled = false;
      this.btnFindContact.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindContact.Location = new System.Drawing.Point(528, 206);
      this.btnFindContact.Name = "btnFindContact";
      this.btnFindContact.Size = new Size(32, 24);
      this.btnFindContact.TabIndex = 113;
      this.btnFindContact.Text = "...";
      this.txtContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtContact.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtContact.Location = new System.Drawing.Point(128, 208);
      this.txtContact.Name = "txtContact";
      this.txtContact.ReadOnly = true;
      this.txtContact.Size = new Size(392, 21);
      this.txtContact.TabIndex = 112;
      this.txtContact.Text = "";
      this.Label14.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label14.Location = new System.Drawing.Point(8, 206);
      this.Label14.Name = "Label14";
      this.Label14.Size = new Size(64, 24);
      this.Label14.TabIndex = 116;
      this.Label14.Text = "Contact";
      this.btnFindInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btnFindInvoiceAddress.BackColor = Color.White;
      this.btnFindInvoiceAddress.Enabled = false;
      this.btnFindInvoiceAddress.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btnFindInvoiceAddress.Location = new System.Drawing.Point(528, 254);
      this.btnFindInvoiceAddress.Name = "btnFindInvoiceAddress";
      this.btnFindInvoiceAddress.Size = new Size(32, 24);
      this.btnFindInvoiceAddress.TabIndex = 111;
      this.btnFindInvoiceAddress.Text = "...";
      this.txtInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtInvoiceAddress.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.txtInvoiceAddress.Location = new System.Drawing.Point(128, 256);
      this.txtInvoiceAddress.Name = "txtInvoiceAddress";
      this.txtInvoiceAddress.ReadOnly = true;
      this.txtInvoiceAddress.Size = new Size(392, 21);
      this.txtInvoiceAddress.TabIndex = 110;
      this.txtInvoiceAddress.Text = "";
      this.Label15.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label15.Location = new System.Drawing.Point(8, 254);
      this.Label15.Name = "Label15";
      this.Label15.Size = new Size(104, 24);
      this.Label15.TabIndex = 115;
      this.Label15.Text = "Invoice Address";
      this.Controls.Add((Control) this.GroupBox1);
      this.Name = nameof (UCOrderForCustomer);
      this.Size = new Size(592, 408);
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    void IUserControl.LoadForm(object sender, EventArgs e)
    {
      this.LoadBaseControl((Control) this);
      this.btnFindSite.Enabled = false;
      this.btnFindWarehouse.Enabled = false;
    }

    public object LoadedItem
    {
      get
      {
        return (object) null;
      }
    }

    public event IUserControl.RecordsChangedEventHandler RecordsChanged;

    public event IUserControl.StateChangedEventHandler StateChanged;

    public FSM.Entity.Customers.Customer Customer
    {
      get
      {
        return this._oCustomer;
      }
      set
      {
        this._oCustomer = value;
        this.txtCustomer.Text = this.Customer.Name + " (" + this.Customer.AccountNumber + ")";
      }
    }

    public FSM.Entity.Sites.Site theProperty
    {
      get
      {
        return this._oProperty;
      }
      set
      {
        this._oProperty = value;
        if (this.theProperty == null)
        {
          this.txtSite.Text = "";
          this.btnFindInvoiceAddress.Enabled = false;
          this.btnFindContact.Enabled = false;
        }
        else
        {
          this.txtSite.Text = this.theProperty.Address1 + ", " + this.theProperty.Address2 + ", " + this.theProperty.Postcode;
          this.btnFindInvoiceAddress.Enabled = true;
          this.btnFindContact.Enabled = true;
          this.InvoiceAddress = (InvoiceAddress) null;
          this.Contact = (Contact) null;
          this.Warehouse = (Warehouse) null;
        }
      }
    }

    public Warehouse Warehouse
    {
      get
      {
        return this._oWarehouse;
      }
      set
      {
        this._oWarehouse = value;
        if (this.Warehouse == null)
        {
          this.txtWarehouse.Text = "";
        }
        else
        {
          this.txtWarehouse.Text = this.Warehouse.Name + " (" + this.Warehouse.Address1 + ", " + this.Warehouse.Postcode + ")";
          this.btnFindInvoiceAddress.Enabled = false;
          this.btnFindContact.Enabled = false;
          this.theProperty = (FSM.Entity.Sites.Site) null;
        }
      }
    }

    public InvoiceAddress InvoiceAddress
    {
      get
      {
        return this._invoiceAddress;
      }
      set
      {
        this._invoiceAddress = value;
        if (this.InvoiceAddress != null)
          this.txtInvoiceAddress.Text = this.InvoiceAddress.Address1 + ", " + this.InvoiceAddress.Address2 + ", " + this.InvoiceAddress.Postcode;
        else
          this.txtInvoiceAddress.Text = "";
      }
    }

    public Contact Contact
    {
      get
      {
        return this._contact;
      }
      set
      {
        this._contact = value;
        if (this.Contact != null)
          this.txtContact.Text = this.Contact.FirstName + " " + this.Contact.Surname;
        else
          this.txtContact.Text = "";
      }
    }

    private void UCOrderForCustomer_Load(object sender, EventArgs e)
    {
      this.LoadForm(RuntimeHelpers.GetObjectValue(sender), e);
    }

    private void btnFindCustomer_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblCustomer, 0, "", false));
      if ((uint) integer > 0U)
      {
        this.Customer = App.DB.Customer.Customer_Get(integer);
        this.theProperty = (FSM.Entity.Sites.Site) null;
        this.Warehouse = (Warehouse) null;
        this.btnFindSite.Enabled = true;
        this.btnFindWarehouse.Enabled = true;
      }
      else
      {
        this.btnFindSite.Enabled = false;
        this.btnFindWarehouse.Enabled = false;
      }
    }

    private void btnFindSite_Click(object sender, EventArgs e)
    {
      if (this.Customer == null)
        return;
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite, this.Customer.CustomerID, "", false));
      if ((uint) integer > 0U)
      {
        this.theProperty = App.DB.Sites.Get((object) integer, SiteSQL.GetBy.SiteId, (object) null);
        this.Warehouse = (Warehouse) null;
      }
    }

    private void btnFindWarehouse_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse, 0, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Warehouse = App.DB.Warehouse.Warehouse_Get(integer);
      this.theProperty = (FSM.Entity.Sites.Site) null;
    }

    private void btnFindContact_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblContact, this.theProperty.SiteID, "", false));
      if ((uint) integer <= 0U)
        return;
      this.Contact = App.DB.Contact.Contact_Get(integer);
    }

    private void btnFindInvoiceAddress_Click(object sender, EventArgs e)
    {
      int integer = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblInvoiceAddress, this.theProperty.SiteID, "", false));
      if ((uint) integer <= 0U)
        return;
      this.InvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(integer);
    }

    void IUserControl.Populate(int ID = 0)
    {
    }

    public bool Save()
    {
      bool flag;
      return flag;
    }
  }
}
