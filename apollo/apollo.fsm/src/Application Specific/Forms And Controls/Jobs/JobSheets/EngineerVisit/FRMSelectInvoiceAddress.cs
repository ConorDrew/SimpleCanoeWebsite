﻿using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMSelectInvoiceAddress : FRMBaseForm, IForm
    {
        public FRMSelectInvoiceAddress()
        {
            base.Load += FRMSelectInvoiceAddress_Load;
        }

        public FRMSelectInvoiceAddress(int SiteIDIn) : base()
        {
            base.Load += FRMSelectInvoiceAddress_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call

            SiteID = SiteIDIn;
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc = cboDept;
                        Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc1 = cboDept;
                        Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }
        }

        // Form overrides dispose to clean up the component list.
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
        private Button _btnOK;

        internal Button btnOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOK != null)
                {
                    _btnOK.Click -= btnOK_Click;
                }

                _btnOK = value;
                if (_btnOK != null)
                {
                    _btnOK.Click += btnOK_Click;
                }
            }
        }

        private GroupBox _grpHO;

        private CheckBox _chkHO;

        internal CheckBox chkHO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkHO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkHO != null)
                {
                }

                _chkHO = value;
                if (_chkHO != null)
                {
                }
            }
        }

        private TextBox _txtHO;

        internal TextBox txtHO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtHO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtHO != null)
                {
                }

                _txtHO = value;
                if (_txtHO != null)
                {
                }
            }
        }

        private GroupBox _grpProperty;

        private CheckBox _chkProperty;

        internal CheckBox chkProperty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkProperty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkProperty != null)
                {
                }

                _chkProperty = value;
                if (_chkProperty != null)
                {
                }
            }
        }

        private TextBox _txtProperty;

        internal TextBox txtProperty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProperty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProperty != null)
                {
                }

                _txtProperty = value;
                if (_txtProperty != null)
                {
                }
            }
        }

        private GroupBox _grpInvoiceAddress;

        private CheckBox _chkInvoiceAddress;

        internal CheckBox chkInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkInvoiceAddress != null)
                {
                }

                _chkInvoiceAddress = value;
                if (_chkInvoiceAddress != null)
                {
                }
            }
        }

        private DataGrid _dgInvoiceAddresses;

        internal DataGrid dgInvoiceAddresses
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgInvoiceAddresses;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgInvoiceAddresses != null)
                {
                }

                _dgInvoiceAddresses = value;
                if (_dgInvoiceAddresses != null)
                {
                }
            }
        }

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private GroupBox _grpDept;

        private CheckBox _chkDept;

        internal CheckBox chkDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDept != null)
                {
                }

                _chkDept = value;
                if (_chkDept != null)
                {
                }
            }
        }

        private ComboBox _cboDept;

        internal ComboBox cboDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDept != null)
                {
                }

                _cboDept = value;
                if (_cboDept != null)
                {
                }
            }
        }

        private Button _btnCancel;

        internal Button btnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancel != null)
                {
                    _btnCancel.Click -= btnCancel_Click;
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                    _btnCancel.Click += btnCancel_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._grpHO = new System.Windows.Forms.GroupBox();
            this._chkHO = new System.Windows.Forms.CheckBox();
            this._txtHO = new System.Windows.Forms.TextBox();
            this._grpProperty = new System.Windows.Forms.GroupBox();
            this._chkProperty = new System.Windows.Forms.CheckBox();
            this._txtProperty = new System.Windows.Forms.TextBox();
            this._grpInvoiceAddress = new System.Windows.Forms.GroupBox();
            this._btnAdd = new System.Windows.Forms.Button();
            this._dgInvoiceAddresses = new System.Windows.Forms.DataGrid();
            this._chkInvoiceAddress = new System.Windows.Forms.CheckBox();
            this._grpDept = new System.Windows.Forms.GroupBox();
            this._cboDept = new System.Windows.Forms.ComboBox();
            this._chkDept = new System.Windows.Forms.CheckBox();
            this._grpHO.SuspendLayout();
            this._grpProperty.SuspendLayout();
            this._grpInvoiceAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgInvoiceAddresses)).BeginInit();
            this._grpDept.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(1185, 515);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(75, 23);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(8, 515);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _grpHO
            // 
            this._grpHO.Controls.Add(this._chkHO);
            this._grpHO.Controls.Add(this._txtHO);
            this._grpHO.Location = new System.Drawing.Point(8, 12);
            this._grpHO.Name = "_grpHO";
            this._grpHO.Size = new System.Drawing.Size(411, 258);
            this._grpHO.TabIndex = 7;
            this._grpHO.TabStop = false;
            this._grpHO.Text = "Head Office";
            // 
            // _chkHO
            // 
            this._chkHO.AutoSize = true;
            this._chkHO.Location = new System.Drawing.Point(6, 20);
            this._chkHO.Name = "_chkHO";
            this._chkHO.Size = new System.Drawing.Size(61, 17);
            this._chkHO.TabIndex = 1;
            this._chkHO.Text = "Select";
            this._chkHO.UseVisualStyleBackColor = true;
            // 
            // _txtHO
            // 
            this._txtHO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtHO.Location = new System.Drawing.Point(6, 43);
            this._txtHO.Multiline = true;
            this._txtHO.Name = "_txtHO";
            this._txtHO.ReadOnly = true;
            this._txtHO.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtHO.Size = new System.Drawing.Size(399, 209);
            this._txtHO.TabIndex = 0;
            // 
            // _grpProperty
            // 
            this._grpProperty.Controls.Add(this._chkProperty);
            this._grpProperty.Controls.Add(this._txtProperty);
            this._grpProperty.Location = new System.Drawing.Point(425, 12);
            this._grpProperty.Name = "_grpProperty";
            this._grpProperty.Size = new System.Drawing.Size(411, 258);
            this._grpProperty.TabIndex = 8;
            this._grpProperty.TabStop = false;
            this._grpProperty.Text = "Property";
            // 
            // _chkProperty
            // 
            this._chkProperty.AutoSize = true;
            this._chkProperty.Location = new System.Drawing.Point(6, 20);
            this._chkProperty.Name = "_chkProperty";
            this._chkProperty.Size = new System.Drawing.Size(61, 17);
            this._chkProperty.TabIndex = 1;
            this._chkProperty.Text = "Select";
            this._chkProperty.UseVisualStyleBackColor = true;
            // 
            // _txtProperty
            // 
            this._txtProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtProperty.Location = new System.Drawing.Point(6, 43);
            this._txtProperty.Multiline = true;
            this._txtProperty.Name = "_txtProperty";
            this._txtProperty.ReadOnly = true;
            this._txtProperty.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtProperty.Size = new System.Drawing.Size(399, 209);
            this._txtProperty.TabIndex = 0;
            // 
            // _grpInvoiceAddress
            // 
            this._grpInvoiceAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpInvoiceAddress.Controls.Add(this._btnAdd);
            this._grpInvoiceAddress.Controls.Add(this._dgInvoiceAddresses);
            this._grpInvoiceAddress.Controls.Add(this._chkInvoiceAddress);
            this._grpInvoiceAddress.Location = new System.Drawing.Point(8, 276);
            this._grpInvoiceAddress.Name = "_grpInvoiceAddress";
            this._grpInvoiceAddress.Size = new System.Drawing.Size(1248, 233);
            this._grpInvoiceAddress.TabIndex = 9;
            this._grpInvoiceAddress.TabStop = false;
            this._grpInvoiceAddress.Text = "Invoice Address";
            // 
            // _btnAdd
            // 
            this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAdd.Location = new System.Drawing.Point(1167, 16);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(75, 23);
            this._btnAdd.TabIndex = 11;
            this._btnAdd.Text = "Add";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // _dgInvoiceAddresses
            // 
            this._dgInvoiceAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgInvoiceAddresses.DataMember = "";
            this._dgInvoiceAddresses.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgInvoiceAddresses.Location = new System.Drawing.Point(6, 43);
            this._dgInvoiceAddresses.Name = "_dgInvoiceAddresses";
            this._dgInvoiceAddresses.Size = new System.Drawing.Size(1236, 184);
            this._dgInvoiceAddresses.TabIndex = 10;
            // 
            // _chkInvoiceAddress
            // 
            this._chkInvoiceAddress.AutoSize = true;
            this._chkInvoiceAddress.Location = new System.Drawing.Point(6, 20);
            this._chkInvoiceAddress.Name = "_chkInvoiceAddress";
            this._chkInvoiceAddress.Size = new System.Drawing.Size(61, 17);
            this._chkInvoiceAddress.TabIndex = 1;
            this._chkInvoiceAddress.Text = "Select";
            this._chkInvoiceAddress.UseVisualStyleBackColor = true;
            // 
            // _grpDept
            // 
            this._grpDept.Controls.Add(this._cboDept);
            this._grpDept.Controls.Add(this._chkDept);
            this._grpDept.Location = new System.Drawing.Point(842, 12);
            this._grpDept.Name = "_grpDept";
            this._grpDept.Size = new System.Drawing.Size(408, 258);
            this._grpDept.TabIndex = 9;
            this._grpDept.TabStop = false;
            this._grpDept.Text = "Department";
            // 
            // _cboDept
            // 
            this._cboDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboDept.FormattingEnabled = true;
            this._cboDept.Location = new System.Drawing.Point(93, 18);
            this._cboDept.Name = "_cboDept";
            this._cboDept.Size = new System.Drawing.Size(309, 21);
            this._cboDept.TabIndex = 33;
            // 
            // _chkDept
            // 
            this._chkDept.AutoSize = true;
            this._chkDept.Location = new System.Drawing.Point(6, 20);
            this._chkDept.Name = "_chkDept";
            this._chkDept.Size = new System.Drawing.Size(61, 17);
            this._chkDept.TabIndex = 1;
            this._chkDept.Text = "Select";
            this._chkDept.UseVisualStyleBackColor = true;
            // 
            // FRMSelectInvoiceAddress
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1265, 545);
            this.ControlBox = false;
            this.Controls.Add(this._grpDept);
            this.Controls.Add(this._grpInvoiceAddress);
            this.Controls.Add(this._grpProperty);
            this.Controls.Add(this._grpHO);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.MinimumSize = new System.Drawing.Size(853, 530);
            this.Name = "FRMSelectInvoiceAddress";
            this.Text = "Select an address for the invoice";
            this._grpHO.ResumeLayout(false);
            this._grpHO.PerformLayout();
            this._grpProperty.ResumeLayout(false);
            this._grpProperty.PerformLayout();
            this._grpInvoiceAddress.ResumeLayout(false);
            this._grpInvoiceAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgInvoiceAddresses)).EndInit();
            this._grpDept.ResumeLayout(false);
            this._grpDept.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDG();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return null;
            }
        }

        public void ResetMe(int newID)
        {
        }

        private int _SiteID = 0;

        public int SiteID
        {
            get
            {
                return _SiteID;
            }

            set
            {
                _SiteID = value;
                TheSite = App.DB.Sites.Get(SiteID);
                TheHQ = App.DB.Sites.Get(TheSite.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq);
                if (TheHQ is null)
                {
                    txtHO.Text = "No Head Office Assigned";
                    chkHO.Enabled = false;
                }

                InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_GetForSite(SiteID);
            }
        }

        private Entity.Sites.Site _Site = null;

        public Entity.Sites.Site TheSite
        {
            get
            {
                return _Site;
            }

            set
            {
                _Site = value;
                string address = "";
                if (TheSite.Name.Trim().Length > 0)
                {
                    address += TheSite.Name + Constants.vbCrLf;
                }

                if (TheSite.Address1.Trim().Length > 0)
                {
                    address += TheSite.Address1 + Constants.vbCrLf;
                }

                if (TheSite.Address2.Trim().Length > 0)
                {
                    address += TheSite.Address2 + Constants.vbCrLf;
                }

                if (TheSite.Address3.Trim().Length > 0)
                {
                    address += TheSite.Address3 + Constants.vbCrLf;
                }

                if (TheSite.Address4.Trim().Length > 0)
                {
                    address += TheSite.Address4 + Constants.vbCrLf;
                }

                if (TheSite.Address5.Trim().Length > 0)
                {
                    address += TheSite.Address5 + Constants.vbCrLf;
                }

                if (TheSite.Postcode.Trim().Length > 0)
                {
                    address += TheSite.Postcode + Constants.vbCrLf;
                }

                txtProperty.Text = address;
            }
        }

        private Entity.Sites.Site _TheHQ = null;

        public Entity.Sites.Site TheHQ
        {
            get
            {
                return _TheHQ;
            }

            set
            {
                _TheHQ = value;
                if (TheHQ is object && TheHQ.Exists)
                {
                    string address = "";
                    if (TheHQ.Name.Trim().Length > 0)
                    {
                        address += TheHQ.Name + Constants.vbCrLf;
                    }

                    if (TheHQ.Address1.Trim().Length > 0)
                    {
                        address += TheHQ.Address1 + Constants.vbCrLf;
                    }

                    if (TheHQ.Address2.Trim().Length > 0)
                    {
                        address += TheHQ.Address2 + Constants.vbCrLf;
                    }

                    if (TheHQ.Address3.Trim().Length > 0)
                    {
                        address += TheHQ.Address3 + Constants.vbCrLf;
                    }

                    if (TheHQ.Address4.Trim().Length > 0)
                    {
                        address += TheHQ.Address4 + Constants.vbCrLf;
                    }

                    if (TheHQ.Address5.Trim().Length > 0)
                    {
                        address += TheHQ.Address5 + Constants.vbCrLf;
                    }

                    if (TheHQ.Postcode.Trim().Length > 0)
                    {
                        address += TheHQ.Postcode + Constants.vbCrLf;
                    }

                    txtHO.Text = address;
                }
            }
        }

        private DataView _InvoiceAddresses = null;

        public DataView InvoiceAddresses
        {
            get
            {
                return _InvoiceAddresses;
            }

            set
            {
                _InvoiceAddresses = value;
                _InvoiceAddresses.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
                _InvoiceAddresses.AllowNew = false;
                _InvoiceAddresses.AllowEdit = false;
                _InvoiceAddresses.AllowDelete = false;
                dgInvoiceAddresses.DataSource = InvoiceAddresses;
            }
        }

        private DataRow SelectedInvoiceAddress
        {
            get
            {
                if (!(dgInvoiceAddresses.CurrentRowIndex == -1))
                {
                    return InvoiceAddresses[dgInvoiceAddresses.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private int _AddressLinkID = 0;

        public int AddressLinkID
        {
            get
            {
                return _AddressLinkID;
            }

            set
            {
                _AddressLinkID = value;
            }
        }

        private int _AddressTypeID = 0;

        public int AddressTypeID
        {
            get
            {
                return _AddressTypeID;
            }

            set
            {
                _AddressTypeID = value;
            }
        }

        private void SetupDG()
        {
            Helper.SetUpDataGrid(dgInvoiceAddresses);
            var tStyle = dgInvoiceAddresses.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 100;
            Address1.NullText = "";
            tStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 100;
            Address2.NullText = "";
            tStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address 3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 100;
            Address3.NullText = "";
            tStyle.GridColumnStyles.Add(Address3);
            var Address4 = new DataGridLabelColumn();
            Address4.Format = "";
            Address4.FormatInfo = null;
            Address4.HeaderText = "Address 4";
            Address4.MappingName = "Address4";
            Address4.ReadOnly = true;
            Address4.Width = 100;
            Address4.NullText = "";
            tStyle.GridColumnStyles.Add(Address4);
            var Address5 = new DataGridLabelColumn();
            Address5.Format = "";
            Address5.FormatInfo = null;
            Address5.HeaderText = "Address5";
            Address5.MappingName = "Address5";
            Address5.ReadOnly = true;
            Address5.Width = 100;
            Address5.NullText = "";
            tStyle.GridColumnStyles.Add(Address5);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 75;
            Postcode.NullText = "";
            tStyle.GridColumnStyles.Add(Postcode);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblInvoiceAddress.ToString();
            dgInvoiceAddresses.TableStyles.Add(tStyle);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (chkHO.Checked)
            {
                count += 1;
            }

            if (chkProperty.Checked)
            {
                count += 1;
            }

            if (chkInvoiceAddress.Checked)
            {
                count += 1;
            }

            if (chkDept.Checked)
            {
                count += 1;
            }

            switch (count)
            {
                case 0:
                    {
                        App.ShowMessage("You have not selected an address", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                case 1:
                    {
                        if (chkInvoiceAddress.Checked)
                        {
                            if (SelectedInvoiceAddress is null)
                            {
                                App.ShowMessage("You have not selected an address", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        break;
                    }

                default:
                    {
                        App.ShowMessage("You can only select a single address for the invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
            }

            if (chkHO.Checked)
            {
                AddressLinkID = TheHQ.SiteID;
                AddressTypeID = Conversions.ToInteger(Enums.InvoiceAddressType.HQ);
            }

            if (chkProperty.Checked)
            {
                AddressLinkID = SiteID;
                AddressTypeID = Conversions.ToInteger(Enums.InvoiceAddressType.Site);
            }

            if (chkInvoiceAddress.Checked)
            {
                AddressLinkID = Conversions.ToInteger(SelectedInvoiceAddress["InvoiceAddressID"]);
                AddressTypeID = Conversions.ToInteger(Enums.InvoiceAddressType.Invoice);
            }

            if (chkDept.Checked)
            {
                var invoiceAddress = new Entity.InvoiceAddresss.InvoiceAddress();
                invoiceAddress.SetAddress1 = "DEPT " + Combo.get_GetSelectedItemValue(cboDept);
                invoiceAddress.SetAddress2 = App.TheSystem.Configuration.CompanyName;
                invoiceAddress.SetAddress3 = App.TheSystem.Configuration.CompanyAddres1;
                invoiceAddress.SetAddress4 = App.TheSystem.Configuration.CompanyAddres3;
                invoiceAddress.SetAddress5 = string.Empty;
                invoiceAddress.SetPostcode = App.TheSystem.Configuration.CompanyPostcode;
                invoiceAddress.SetSiteID = SiteID;
                AddressLinkID = (int)App.DB.InvoiceAddress.Insert(invoiceAddress)?.InvoiceAddressID;
                AddressTypeID = Conversions.ToInteger(Enums.InvoiceAddressType.Invoice);
            }

            DialogResult = DialogResult.OK;
        }

        private void FRMSelectInvoiceAddress_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMInvoiceAddress), true, new object[] { 0, SiteID, this });
            SiteID = SiteID;
        }
    }
}