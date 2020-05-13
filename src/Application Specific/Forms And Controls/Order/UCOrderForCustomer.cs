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
        internal Button btnFindEngineer;
        internal TextBox txtEngineer;
        internal Label _lblEngineer;

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
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFindEngineer = new System.Windows.Forms.Button();
            this.txtEngineer = new System.Windows.Forms.TextBox();
            this._lblEngineer = new System.Windows.Forms.Label();
            this._lblSpecial = new System.Windows.Forms.Label();
            this._txtSpecialInstructions = new System.Windows.Forms.TextBox();
            this._cboUsers = new System.Windows.Forms.ComboBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._btnFindContact = new System.Windows.Forms.Button();
            this._txtContact = new System.Windows.Forms.TextBox();
            this._Label14 = new System.Windows.Forms.Label();
            this._btnFindInvoiceAddress = new System.Windows.Forms.Button();
            this._txtInvoiceAddress = new System.Windows.Forms.TextBox();
            this._Label15 = new System.Windows.Forms.Label();
            this._btnFindWarehouse = new System.Windows.Forms.Button();
            this._txtWarehouse = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._btnFindSite = new System.Windows.Forms.Button();
            this._txtSite = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            //
            // _GroupBox1
            //
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this.btnFindEngineer);
            this._GroupBox1.Controls.Add(this.txtEngineer);
            this._GroupBox1.Controls.Add(this._lblEngineer);
            this._GroupBox1.Controls.Add(this._lblSpecial);
            this._GroupBox1.Controls.Add(this._txtSpecialInstructions);
            this._GroupBox1.Controls.Add(this._cboUsers);
            this._GroupBox1.Controls.Add(this._Label13);
            this._GroupBox1.Controls.Add(this._btnFindContact);
            this._GroupBox1.Controls.Add(this._txtContact);
            this._GroupBox1.Controls.Add(this._Label14);
            this._GroupBox1.Controls.Add(this._btnFindInvoiceAddress);
            this._GroupBox1.Controls.Add(this._txtInvoiceAddress);
            this._GroupBox1.Controls.Add(this._Label15);
            this._GroupBox1.Controls.Add(this._btnFindWarehouse);
            this._GroupBox1.Controls.Add(this._txtWarehouse);
            this._GroupBox1.Controls.Add(this._Label4);
            this._GroupBox1.Controls.Add(this._btnFindSite);
            this._GroupBox1.Controls.Add(this._txtSite);
            this._GroupBox1.Controls.Add(this._Label1);
            this._GroupBox1.Controls.Add(this._btnFindCustomer);
            this._GroupBox1.Controls.Add(this._txtCustomer);
            this._GroupBox1.Controls.Add(this._Label3);
            this._GroupBox1.Location = new System.Drawing.Point(4, 8);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(576, 392);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Customer Details";
            //
            // btnFindEngineer
            //
            this.btnFindEngineer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindEngineer.BackColor = System.Drawing.Color.White;
            this.btnFindEngineer.Enabled = false;
            this.btnFindEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindEngineer.Location = new System.Drawing.Point(528, 176);
            this.btnFindEngineer.Name = "btnFindEngineer";
            this.btnFindEngineer.Size = new System.Drawing.Size(32, 24);
            this.btnFindEngineer.TabIndex = 123;
            this.btnFindEngineer.Text = "...";
            this.btnFindEngineer.UseVisualStyleBackColor = false;
            this.btnFindEngineer.Click += new System.EventHandler(this.btnFindEngineer_Click);
            //
            // txtEngineer
            //
            this.txtEngineer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEngineer.Location = new System.Drawing.Point(126, 179);
            this.txtEngineer.Name = "txtEngineer";
            this.txtEngineer.ReadOnly = true;
            this.txtEngineer.Size = new System.Drawing.Size(394, 21);
            this.txtEngineer.TabIndex = 122;
            //
            // _lblEngineer
            //
            this._lblEngineer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEngineer.Location = new System.Drawing.Point(8, 182);
            this._lblEngineer.Name = "_lblEngineer";
            this._lblEngineer.Size = new System.Drawing.Size(64, 24);
            this._lblEngineer.TabIndex = 121;
            this._lblEngineer.Text = "Engineer";
            //
            // _lblSpecial
            //
            this._lblSpecial.Location = new System.Drawing.Point(8, 280);
            this._lblSpecial.Name = "_lblSpecial";
            this._lblSpecial.Size = new System.Drawing.Size(120, 40);
            this._lblSpecial.TabIndex = 119;
            this._lblSpecial.Text = "Special Instructions";
            //
            // _txtSpecialInstructions
            //
            this._txtSpecialInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSpecialInstructions.Location = new System.Drawing.Point(128, 280);
            this._txtSpecialInstructions.Multiline = true;
            this._txtSpecialInstructions.Name = "_txtSpecialInstructions";
            this._txtSpecialInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtSpecialInstructions.Size = new System.Drawing.Size(392, 66);
            this._txtSpecialInstructions.TabIndex = 118;
            //
            // _cboUsers
            //
            this._cboUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboUsers.Location = new System.Drawing.Point(128, 232);
            this._cboUsers.Name = "_cboUsers";
            this._cboUsers.Size = new System.Drawing.Size(392, 21);
            this._cboUsers.TabIndex = 114;
            //
            // _Label13
            //
            this._Label13.Location = new System.Drawing.Point(8, 230);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(112, 24);
            this._Label13.TabIndex = 117;
            this._Label13.Text = "Co-ordinator";
            //
            // _btnFindContact
            //
            this._btnFindContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindContact.BackColor = System.Drawing.Color.White;
            this._btnFindContact.Enabled = false;
            this._btnFindContact.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindContact.Location = new System.Drawing.Point(528, 206);
            this._btnFindContact.Name = "_btnFindContact";
            this._btnFindContact.Size = new System.Drawing.Size(32, 24);
            this._btnFindContact.TabIndex = 113;
            this._btnFindContact.Text = "...";
            this._btnFindContact.UseVisualStyleBackColor = false;
            this._btnFindContact.Click += new System.EventHandler(this.btnFindContact_Click);
            //
            // _txtContact
            //
            this._txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtContact.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtContact.Location = new System.Drawing.Point(128, 208);
            this._txtContact.Name = "_txtContact";
            this._txtContact.ReadOnly = true;
            this._txtContact.Size = new System.Drawing.Size(392, 21);
            this._txtContact.TabIndex = 112;
            //
            // _Label14
            //
            this._Label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label14.Location = new System.Drawing.Point(8, 206);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(64, 24);
            this._Label14.TabIndex = 116;
            this._Label14.Text = "Contact";
            //
            // _btnFindInvoiceAddress
            //
            this._btnFindInvoiceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindInvoiceAddress.BackColor = System.Drawing.Color.White;
            this._btnFindInvoiceAddress.Enabled = false;
            this._btnFindInvoiceAddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindInvoiceAddress.Location = new System.Drawing.Point(528, 254);
            this._btnFindInvoiceAddress.Name = "_btnFindInvoiceAddress";
            this._btnFindInvoiceAddress.Size = new System.Drawing.Size(32, 24);
            this._btnFindInvoiceAddress.TabIndex = 111;
            this._btnFindInvoiceAddress.Text = "...";
            this._btnFindInvoiceAddress.UseVisualStyleBackColor = false;
            this._btnFindInvoiceAddress.Click += new System.EventHandler(this.btnFindInvoiceAddress_Click);
            //
            // _txtInvoiceAddress
            //
            this._txtInvoiceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtInvoiceAddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtInvoiceAddress.Location = new System.Drawing.Point(128, 256);
            this._txtInvoiceAddress.Name = "_txtInvoiceAddress";
            this._txtInvoiceAddress.ReadOnly = true;
            this._txtInvoiceAddress.Size = new System.Drawing.Size(392, 21);
            this._txtInvoiceAddress.TabIndex = 110;
            //
            // _Label15
            //
            this._Label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label15.Location = new System.Drawing.Point(8, 254);
            this._Label15.Name = "_Label15";
            this._Label15.Size = new System.Drawing.Size(104, 24);
            this._Label15.TabIndex = 115;
            this._Label15.Text = "Invoice Address";
            //
            // _btnFindWarehouse
            //
            this._btnFindWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindWarehouse.BackColor = System.Drawing.Color.White;
            this._btnFindWarehouse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindWarehouse.Location = new System.Drawing.Point(528, 133);
            this._btnFindWarehouse.Name = "_btnFindWarehouse";
            this._btnFindWarehouse.Size = new System.Drawing.Size(32, 23);
            this._btnFindWarehouse.TabIndex = 6;
            this._btnFindWarehouse.Text = "...";
            this._btnFindWarehouse.UseVisualStyleBackColor = false;
            this._btnFindWarehouse.Click += new System.EventHandler(this.btnFindWarehouse_Click);
            //
            // _txtWarehouse
            //
            this._txtWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtWarehouse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtWarehouse.Location = new System.Drawing.Point(128, 133);
            this._txtWarehouse.Name = "_txtWarehouse";
            this._txtWarehouse.ReadOnly = true;
            this._txtWarehouse.Size = new System.Drawing.Size(392, 21);
            this._txtWarehouse.TabIndex = 5;
            //
            // _Label4
            //
            this._Label4.BackColor = System.Drawing.Color.White;
            this._Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label4.Location = new System.Drawing.Point(8, 128);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(72, 20);
            this._Label4.TabIndex = 51;
            this._Label4.Text = "Warehouse";
            //
            // _btnFindSite
            //
            this._btnFindSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindSite.BackColor = System.Drawing.Color.White;
            this._btnFindSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindSite.Location = new System.Drawing.Point(528, 97);
            this._btnFindSite.Name = "_btnFindSite";
            this._btnFindSite.Size = new System.Drawing.Size(32, 23);
            this._btnFindSite.TabIndex = 4;
            this._btnFindSite.Text = "...";
            this._btnFindSite.UseVisualStyleBackColor = false;
            this._btnFindSite.Click += new System.EventHandler(this.btnFindSite_Click);
            //
            // _txtSite
            //
            this._txtSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSite.Location = new System.Drawing.Point(128, 97);
            this._txtSite.Name = "_txtSite";
            this._txtSite.ReadOnly = true;
            this._txtSite.Size = new System.Drawing.Size(392, 21);
            this._txtSite.TabIndex = 3;
            //
            // _Label1
            //
            this._Label1.BackColor = System.Drawing.Color.White;
            this._Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1.Location = new System.Drawing.Point(8, 96);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(72, 20);
            this._Label1.TabIndex = 47;
            this._Label1.Text = "Property";
            //
            // _btnFindCustomer
            //
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(528, 25);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 2;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = false;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            //
            // _txtCustomer
            //
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(8, 25);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(512, 21);
            this._txtCustomer.TabIndex = 1;
            //
            // _Label3
            //
            this._Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Label3.Location = new System.Drawing.Point(8, 56);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(560, 23);
            this._Label3.TabIndex = 41;
            this._Label3.Text = "Please select a property to deliver to.  If property is currently unknown, select" +
    " a warehouse to deliver to.";
            //
            // UCOrderForCustomer
            //
            this.Controls.Add(this._GroupBox1);
            this.Name = "UCOrderForCustomer";
            this.Size = new System.Drawing.Size(592, 408);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);
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
                    btnFindEngineer.Enabled = true;
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

        private FSM.Entity.Engineers.Engineer _engineer = new FSM.Entity.Engineers.Engineer();

        public FSM.Entity.Engineers.Engineer Engineer
        {
            get
            {
                return _engineer;
            }

            set
            {
                _engineer = value;
                if (Engineer is object)
                {
                    txtEngineer.Text = Engineer.Name;
                }
                else
                {
                    txtEngineer.Text = "";
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

        private void btnFindEngineer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(FSM.App.FindRecord(FSM.Entity.Sys.Enums.TableNames.tblEngineer));
            if (!(ID == 0))
            {
                Engineer = FSM.App.DB.Engineer.Engineer_Get(ID);
            }
        }
    }
}