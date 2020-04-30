using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCOrderForCustomer : UCBase, IUserControl
    {
        

        public UCOrderForCustomer() : base()
        {
            
            
            base.Load += UCOrderForCustomer_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboUsers;
            Combo.SetUpCombo(ref argc, App.DB.User.GetAll().Table, "UserID", "FullName", Entity.Sys.Enums.ComboValues.Please_Select);
        }

        // UserControl overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components is null))
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.
        // Do not modify it using the code editor.
        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private Button _btnFindSite;

        internal Button btnFindSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click -= btnFindSite_Click;
                }

                _btnFindSite = value;
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click += btnFindSite_Click;
                }
            }
        }

        private TextBox _txtSite;

        internal TextBox txtSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSite != null)
                {
                }

                _txtSite = value;
                if (_txtSite != null)
                {
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private Button _btnFindCustomer;

        internal Button btnFindCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click -= btnFindCustomer_Click;
                }

                _btnFindCustomer = value;
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click += btnFindCustomer_Click;
                }
            }
        }

        private TextBox _txtCustomer;

        internal TextBox txtCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomer != null)
                {
                }

                _txtCustomer = value;
                if (_txtCustomer != null)
                {
                }
            }
        }

        private Label _Label3;

        internal Label Label3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label3 != null)
                {
                }

                _Label3 = value;
                if (_Label3 != null)
                {
                }
            }
        }

        private Button _btnFindWarehouse;

        internal Button btnFindWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindWarehouse != null)
                {
                    _btnFindWarehouse.Click -= btnFindWarehouse_Click;
                }

                _btnFindWarehouse = value;
                if (_btnFindWarehouse != null)
                {
                    _btnFindWarehouse.Click += btnFindWarehouse_Click;
                }
            }
        }

        private TextBox _txtWarehouse;

        internal TextBox txtWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtWarehouse != null)
                {
                }

                _txtWarehouse = value;
                if (_txtWarehouse != null)
                {
                }
            }
        }

        private Label _Label4;

        internal Label Label4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label4 != null)
                {
                }

                _Label4 = value;
                if (_Label4 != null)
                {
                }
            }
        }

        private Label _lblSpecial;

        internal Label lblSpecial
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSpecial;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSpecial != null)
                {
                }

                _lblSpecial = value;
                if (_lblSpecial != null)
                {
                }
            }
        }

        private TextBox _txtSpecialInstructions;

        internal TextBox txtSpecialInstructions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSpecialInstructions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSpecialInstructions != null)
                {
                }

                _txtSpecialInstructions = value;
                if (_txtSpecialInstructions != null)
                {
                }
            }
        }

        private ComboBox _cboUsers;

        internal ComboBox cboUsers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUsers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUsers != null)
                {
                }

                _cboUsers = value;
                if (_cboUsers != null)
                {
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

        private Button _btnFindContact;

        internal Button btnFindContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindContact != null)
                {
                    _btnFindContact.Click -= btnFindContact_Click;
                }

                _btnFindContact = value;
                if (_btnFindContact != null)
                {
                    _btnFindContact.Click += btnFindContact_Click;
                }
            }
        }

        private TextBox _txtContact;

        internal TextBox txtContact
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContact;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContact != null)
                {
                }

                _txtContact = value;
                if (_txtContact != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private Button _btnFindInvoiceAddress;

        internal Button btnFindInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindInvoiceAddress != null)
                {
                    _btnFindInvoiceAddress.Click -= btnFindInvoiceAddress_Click;
                }

                _btnFindInvoiceAddress = value;
                if (_btnFindInvoiceAddress != null)
                {
                    _btnFindInvoiceAddress.Click += btnFindInvoiceAddress_Click;
                }
            }
        }

        private TextBox _txtInvoiceAddress;

        internal TextBox txtInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvoiceAddress != null)
                {
                }

                _txtInvoiceAddress = value;
                if (_txtInvoiceAddress != null)
                {
                }
            }
        }

        private Label _Label15;

        internal Label Label15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label15 != null)
                {
                }

                _Label15 = value;
                if (_Label15 != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _GroupBox1 = new GroupBox();
            _btnFindWarehouse = new Button();
            _btnFindWarehouse.Click += new EventHandler(btnFindWarehouse_Click);
            _txtWarehouse = new TextBox();
            _Label4 = new Label();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _Label1 = new Label();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label3 = new Label();
            _lblSpecial = new Label();
            _txtSpecialInstructions = new TextBox();
            _cboUsers = new ComboBox();
            _Label13 = new Label();
            _btnFindContact = new Button();
            _btnFindContact.Click += new EventHandler(btnFindContact_Click);
            _txtContact = new TextBox();
            _Label14 = new Label();
            _btnFindInvoiceAddress = new Button();
            _btnFindInvoiceAddress.Click += new EventHandler(btnFindInvoiceAddress_Click);
            _txtInvoiceAddress = new TextBox();
            _Label15 = new Label();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_lblSpecial);
            _GroupBox1.Controls.Add(_txtSpecialInstructions);
            _GroupBox1.Controls.Add(_cboUsers);
            _GroupBox1.Controls.Add(_Label13);
            _GroupBox1.Controls.Add(_btnFindContact);
            _GroupBox1.Controls.Add(_txtContact);
            _GroupBox1.Controls.Add(_Label14);
            _GroupBox1.Controls.Add(_btnFindInvoiceAddress);
            _GroupBox1.Controls.Add(_txtInvoiceAddress);
            _GroupBox1.Controls.Add(_Label15);
            _GroupBox1.Controls.Add(_btnFindWarehouse);
            _GroupBox1.Controls.Add(_txtWarehouse);
            _GroupBox1.Controls.Add(_Label4);
            _GroupBox1.Controls.Add(_btnFindSite);
            _GroupBox1.Controls.Add(_txtSite);
            _GroupBox1.Controls.Add(_Label1);
            _GroupBox1.Controls.Add(_btnFindCustomer);
            _GroupBox1.Controls.Add(_txtCustomer);
            _GroupBox1.Controls.Add(_Label3);
            _GroupBox1.Location = new Point(4, 8);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(576, 392);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Customer Details";
            //
            // btnFindWarehouse
            //
            _btnFindWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindWarehouse.BackColor = Color.White;
            _btnFindWarehouse.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindWarehouse.Location = new Point(528, 133);
            _btnFindWarehouse.Name = "btnFindWarehouse";
            _btnFindWarehouse.Size = new Size(32, 23);
            _btnFindWarehouse.TabIndex = 6;
            _btnFindWarehouse.Text = "...";
            //
            // txtWarehouse
            //
            _txtWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtWarehouse.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtWarehouse.Location = new Point(128, 133);
            _txtWarehouse.Name = "txtWarehouse";
            _txtWarehouse.ReadOnly = true;
            _txtWarehouse.Size = new Size(392, 21);
            _txtWarehouse.TabIndex = 5;
            _txtWarehouse.Text = "";
            //
            // Label4
            //
            _Label4.BackColor = Color.White;
            _Label4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(8, 128);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(72, 20);
            _Label4.TabIndex = 51;
            _Label4.Text = "Warehouse";
            //
            // btnFindSite
            //
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(528, 97);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(32, 23);
            _btnFindSite.TabIndex = 4;
            _btnFindSite.Text = "...";
            //
            // txtSite
            //
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(128, 97);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(392, 21);
            _txtSite.TabIndex = 3;
            _txtSite.Text = "";
            //
            // Label1
            //
            _Label1.BackColor = Color.White;
            _Label1.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(8, 96);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(72, 20);
            _Label1.TabIndex = 47;
            _Label1.Text = "Property";
            //
            // btnFindCustomer
            //
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(528, 25);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 2;
            _btnFindCustomer.Text = "...";
            //
            // txtCustomer
            //
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(8, 25);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(512, 21);
            _txtCustomer.TabIndex = 1;
            _txtCustomer.Text = "";
            //
            // Label3
            //
            _Label3.ForeColor = SystemColors.ControlText;
            _Label3.Location = new Point(8, 56);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(560, 23);
            _Label3.TabIndex = 41;
            _Label3.Text = "Please select a property to deliver to.  If property is currently unknown, select a wareh" + "ouse to deliver to.";
            //
            // lblSpecial
            //
            _lblSpecial.Location = new Point(8, 280);
            _lblSpecial.Name = "lblSpecial";
            _lblSpecial.Size = new Size(120, 40);
            _lblSpecial.TabIndex = 119;
            _lblSpecial.Text = "Special Instructions";
            //
            // txtSpecialInstructions
            //
            _txtSpecialInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtSpecialInstructions.Location = new Point(128, 280);
            _txtSpecialInstructions.Multiline = true;
            _txtSpecialInstructions.Name = "txtSpecialInstructions";
            _txtSpecialInstructions.ScrollBars = ScrollBars.Vertical;
            _txtSpecialInstructions.Size = new Size(392, 66);
            _txtSpecialInstructions.TabIndex = 118;
            _txtSpecialInstructions.Text = "";
            //
            // cboUsers
            //
            _cboUsers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboUsers.Location = new Point(128, 232);
            _cboUsers.Name = "cboUsers";
            _cboUsers.Size = new Size(392, 21);
            _cboUsers.TabIndex = 114;
            //
            // Label13
            //
            _Label13.Location = new Point(8, 230);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(112, 24);
            _Label13.TabIndex = 117;
            _Label13.Text = "Co-ordinator";
            //
            // btnFindContact
            //
            _btnFindContact.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindContact.BackColor = Color.White;
            _btnFindContact.Enabled = false;
            _btnFindContact.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindContact.Location = new Point(528, 206);
            _btnFindContact.Name = "btnFindContact";
            _btnFindContact.Size = new Size(32, 24);
            _btnFindContact.TabIndex = 113;
            _btnFindContact.Text = "...";
            //
            // txtContact
            //
            _txtContact.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtContact.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtContact.Location = new Point(128, 208);
            _txtContact.Name = "txtContact";
            _txtContact.ReadOnly = true;
            _txtContact.Size = new Size(392, 21);
            _txtContact.TabIndex = 112;
            _txtContact.Text = "";
            //
            // Label14
            //
            _Label14.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label14.Location = new Point(8, 206);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(64, 24);
            _Label14.TabIndex = 116;
            _Label14.Text = "Contact";
            //
            // btnFindInvoiceAddress
            //
            _btnFindInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindInvoiceAddress.BackColor = Color.White;
            _btnFindInvoiceAddress.Enabled = false;
            _btnFindInvoiceAddress.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindInvoiceAddress.Location = new Point(528, 254);
            _btnFindInvoiceAddress.Name = "btnFindInvoiceAddress";
            _btnFindInvoiceAddress.Size = new Size(32, 24);
            _btnFindInvoiceAddress.TabIndex = 111;
            _btnFindInvoiceAddress.Text = "...";
            //
            // txtInvoiceAddress
            //
            _txtInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtInvoiceAddress.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtInvoiceAddress.Location = new Point(128, 256);
            _txtInvoiceAddress.Name = "txtInvoiceAddress";
            _txtInvoiceAddress.ReadOnly = true;
            _txtInvoiceAddress.Size = new Size(392, 21);
            _txtInvoiceAddress.TabIndex = 110;
            _txtInvoiceAddress.Text = "";
            //
            // Label15
            //
            _Label15.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label15.Location = new Point(8, 254);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(104, 24);
            _Label15.TabIndex = 115;
            _Label15.Text = "Invoice Address";
            //
            // UCOrderForCustomer
            //
            Controls.Add(_GroupBox1);
            Name = "UCOrderForCustomer";
            Size = new Size(592, 408);
            _GroupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        
        

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            btnFindSite.Enabled = false;
            btnFindWarehouse.Enabled = false;
        }

        public object LoadedItem
        {
            get
            {
                return null;
            }
        }

        
        

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Customers.Customer _oCustomer;

        public Entity.Customers.Customer Customer
        {
            get
            {
                return _oCustomer;
            }

            set
            {
                _oCustomer = value;
                txtCustomer.Text = Customer.Name + " (" + Customer.AccountNumber + ")";
            }
        }

        private Entity.Sites.Site _oProperty;

        public Entity.Sites.Site theProperty
        {
            get
            {
                return _oProperty;
            }

            set
            {
                _oProperty = value;
                if (theProperty is null)
                {
                    txtSite.Text = "";
                    btnFindInvoiceAddress.Enabled = false;
                    btnFindContact.Enabled = false;
                }
                else
                {
                    txtSite.Text = theProperty.Address1 + ", " + theProperty.Address2 + ", " + theProperty.Postcode;
                    btnFindInvoiceAddress.Enabled = true;
                    btnFindContact.Enabled = true;
                    InvoiceAddress = null;
                    Contact = null;
                    Warehouse = null;
                }
            }
        }

        private Entity.Warehouses.Warehouse _oWarehouse;

        public Entity.Warehouses.Warehouse Warehouse
        {
            get
            {
                return _oWarehouse;
            }

            set
            {
                _oWarehouse = value;
                if (Warehouse is null)
                {
                    txtWarehouse.Text = "";
                }
                else
                {
                    txtWarehouse.Text = Warehouse.Name + " (" + Warehouse.Address1 + ", " + Warehouse.Postcode + ")";
                    btnFindInvoiceAddress.Enabled = false;
                    btnFindContact.Enabled = false;
                    theProperty = null;
                }
            }
        }

        private Entity.InvoiceAddresss.InvoiceAddress _invoiceAddress = new Entity.InvoiceAddresss.InvoiceAddress();

        public Entity.InvoiceAddresss.InvoiceAddress InvoiceAddress
        {
            get
            {
                return _invoiceAddress;
            }

            set
            {
                _invoiceAddress = value;
                if (InvoiceAddress is object)
                {
                    txtInvoiceAddress.Text = InvoiceAddress.Address1 + ", " + InvoiceAddress.Address2 + ", " + InvoiceAddress.Postcode;
                }
                else
                {
                    txtInvoiceAddress.Text = "";
                }
            }
        }

        private Entity.Contacts.Contact _contact = new Entity.Contacts.Contact();

        public Entity.Contacts.Contact Contact
        {
            get
            {
                return _contact;
            }

            set
            {
                _contact = value;
                if (Contact is object)
                {
                    txtContact.Text = Contact.FirstName + " " + Contact.Surname;
                }
                else
                {
                    txtContact.Text = "";
                }
            }
        }

        private void UCOrderForCustomer_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                Customer = App.DB.Customer.Customer_Get(ID);
                theProperty = null;
                Warehouse = null;
                btnFindSite.Enabled = true;
                btnFindWarehouse.Enabled = true;
            }
            else
            {
                btnFindSite.Enabled = false;
                btnFindWarehouse.Enabled = false;
            }
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            if (Customer is object)
            {
                int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSite, Customer.CustomerID));
                if (!(ID == 0))
                {
                    theProperty = App.DB.Sites.Get(ID);
                    Warehouse = null;
                }
            }
        }

        private void btnFindWarehouse_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse));
            if (!(ID == 0))
            {
                Warehouse = App.DB.Warehouse.Warehouse_Get(ID);
                theProperty = null;
            }
        }

        private void btnFindContact_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblContact, theProperty.SiteID));
            if (!(ID == 0))
            {
                Contact = App.DB.Contact.Contact_Get(ID);
            }
        }

        private void btnFindInvoiceAddress_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblInvoiceAddress, theProperty.SiteID));
            if (!(ID == 0))
            {
                InvoiceAddress = App.DB.InvoiceAddress.InvoiceAddress_Get(ID);
            }
        }

        
        

        public void Populate(int ID = 0)
        {
            // DO NOTHING
        }

        public bool Save()
        {
            return default;
            // DO NOTHING
        }

        
    }
}