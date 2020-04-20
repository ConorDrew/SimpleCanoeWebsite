using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMSelectInvoiceAddress : FRMBaseForm, IForm
    {
        public FRMSelectInvoiceAddress()
        {
            base.Load += FRMSelectInvoiceAddress_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal GroupBox grpHO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpHO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpHO != null)
                {
                }

                _grpHO = value;
                if (_grpHO != null)
                {
                }
            }
        }

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

        internal GroupBox grpProperty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpProperty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpProperty != null)
                {
                }

                _grpProperty = value;
                if (_grpProperty != null)
                {
                }
            }
        }

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

        internal GroupBox grpInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpInvoiceAddress != null)
                {
                }

                _grpInvoiceAddress = value;
                if (_grpInvoiceAddress != null)
                {
                }
            }
        }

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

        internal GroupBox grpDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDept != null)
                {
                }

                _grpDept = value;
                if (_grpDept != null)
                {
                }
            }
        }

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
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _grpHO = new GroupBox();
            _chkHO = new CheckBox();
            _txtHO = new TextBox();
            _grpProperty = new GroupBox();
            _chkProperty = new CheckBox();
            _txtProperty = new TextBox();
            _grpInvoiceAddress = new GroupBox();
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgInvoiceAddresses = new DataGrid();
            _chkInvoiceAddress = new CheckBox();
            _grpDept = new GroupBox();
            _chkDept = new CheckBox();
            _cboDept = new ComboBox();
            _grpHO.SuspendLayout();
            _grpProperty.SuspendLayout();
            _grpInvoiceAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddresses).BeginInit();
            _grpDept.SuspendLayout();
            SuspendLayout();
            // 
            // btnOK
            // 
            _btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOK.Location = new Point(1185, 515);
            _btnOK.Name = "btnOK";
            _btnOK.Size = new Size(75, 23);
            _btnOK.TabIndex = 4;
            _btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 515);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 6;
            _btnCancel.Text = "Cancel";
            // 
            // grpHO
            // 
            _grpHO.Controls.Add(_chkHO);
            _grpHO.Controls.Add(_txtHO);
            _grpHO.Location = new Point(8, 38);
            _grpHO.Name = "grpHO";
            _grpHO.Size = new Size(411, 232);
            _grpHO.TabIndex = 7;
            _grpHO.TabStop = false;
            _grpHO.Text = "Head Office";
            // 
            // chkHO
            // 
            _chkHO.AutoSize = true;
            _chkHO.Location = new Point(6, 20);
            _chkHO.Name = "chkHO";
            _chkHO.Size = new Size(61, 17);
            _chkHO.TabIndex = 1;
            _chkHO.Text = "Select";
            _chkHO.UseVisualStyleBackColor = true;
            // 
            // txtHO
            // 
            _txtHO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtHO.Location = new Point(6, 43);
            _txtHO.Multiline = true;
            _txtHO.Name = "txtHO";
            _txtHO.ReadOnly = true;
            _txtHO.ScrollBars = ScrollBars.Both;
            _txtHO.Size = new Size(399, 183);
            _txtHO.TabIndex = 0;
            // 
            // grpProperty
            // 
            _grpProperty.Controls.Add(_chkProperty);
            _grpProperty.Controls.Add(_txtProperty);
            _grpProperty.Location = new Point(425, 38);
            _grpProperty.Name = "grpProperty";
            _grpProperty.Size = new Size(411, 232);
            _grpProperty.TabIndex = 8;
            _grpProperty.TabStop = false;
            _grpProperty.Text = "Property";
            // 
            // chkProperty
            // 
            _chkProperty.AutoSize = true;
            _chkProperty.Location = new Point(6, 20);
            _chkProperty.Name = "chkProperty";
            _chkProperty.Size = new Size(61, 17);
            _chkProperty.TabIndex = 1;
            _chkProperty.Text = "Select";
            _chkProperty.UseVisualStyleBackColor = true;
            // 
            // txtProperty
            // 
            _txtProperty.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtProperty.Location = new Point(6, 43);
            _txtProperty.Multiline = true;
            _txtProperty.Name = "txtProperty";
            _txtProperty.ReadOnly = true;
            _txtProperty.ScrollBars = ScrollBars.Both;
            _txtProperty.Size = new Size(399, 183);
            _txtProperty.TabIndex = 0;
            // 
            // grpInvoiceAddress
            // 
            _grpInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpInvoiceAddress.Controls.Add(_btnAdd);
            _grpInvoiceAddress.Controls.Add(_dgInvoiceAddresses);
            _grpInvoiceAddress.Controls.Add(_chkInvoiceAddress);
            _grpInvoiceAddress.Location = new Point(8, 276);
            _grpInvoiceAddress.Name = "grpInvoiceAddress";
            _grpInvoiceAddress.Size = new Size(1248, 233);
            _grpInvoiceAddress.TabIndex = 9;
            _grpInvoiceAddress.TabStop = false;
            _grpInvoiceAddress.Text = "Invoice Address";
            // 
            // btnAdd
            // 
            _btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAdd.Location = new Point(1167, 16);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(75, 23);
            _btnAdd.TabIndex = 11;
            _btnAdd.Text = "Add";
            _btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgInvoiceAddresses
            // 
            _dgInvoiceAddresses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgInvoiceAddresses.DataMember = "";
            _dgInvoiceAddresses.HeaderForeColor = SystemColors.ControlText;
            _dgInvoiceAddresses.Location = new Point(6, 43);
            _dgInvoiceAddresses.Name = "dgInvoiceAddresses";
            _dgInvoiceAddresses.Size = new Size(1236, 184);
            _dgInvoiceAddresses.TabIndex = 10;
            // 
            // chkInvoiceAddress
            // 
            _chkInvoiceAddress.AutoSize = true;
            _chkInvoiceAddress.Location = new Point(6, 20);
            _chkInvoiceAddress.Name = "chkInvoiceAddress";
            _chkInvoiceAddress.Size = new Size(61, 17);
            _chkInvoiceAddress.TabIndex = 1;
            _chkInvoiceAddress.Text = "Select";
            _chkInvoiceAddress.UseVisualStyleBackColor = true;
            // 
            // grpDept
            // 
            _grpDept.Controls.Add(_cboDept);
            _grpDept.Controls.Add(_chkDept);
            _grpDept.Location = new Point(842, 38);
            _grpDept.Name = "grpDept";
            _grpDept.Size = new Size(408, 232);
            _grpDept.TabIndex = 9;
            _grpDept.TabStop = false;
            _grpDept.Text = "Department";
            // 
            // chkDept
            // 
            _chkDept.AutoSize = true;
            _chkDept.Location = new Point(6, 20);
            _chkDept.Name = "chkDept";
            _chkDept.Size = new Size(61, 17);
            _chkDept.TabIndex = 1;
            _chkDept.Text = "Select";
            _chkDept.UseVisualStyleBackColor = true;
            // 
            // cboDept
            // 
            _cboDept.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboDept.FormattingEnabled = true;
            _cboDept.Location = new Point(93, 18);
            _cboDept.Name = "cboDept";
            _cboDept.Size = new Size(309, 21);
            _cboDept.TabIndex = 33;
            // 
            // FRMSelectInvoiceAddress
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1265, 545);
            ControlBox = false;
            Controls.Add(_grpDept);
            Controls.Add(_grpInvoiceAddress);
            Controls.Add(_grpProperty);
            Controls.Add(_grpHO);
            Controls.Add(_btnCancel);
            Controls.Add(_btnOK);
            MinimumSize = new Size(853, 530);
            Name = "FRMSelectInvoiceAddress";
            Text = "Select an address for the invoice";
            Controls.SetChildIndex(_btnOK, 0);
            Controls.SetChildIndex(_btnCancel, 0);
            Controls.SetChildIndex(_grpHO, 0);
            Controls.SetChildIndex(_grpProperty, 0);
            Controls.SetChildIndex(_grpInvoiceAddress, 0);
            Controls.SetChildIndex(_grpDept, 0);
            _grpHO.ResumeLayout(false);
            _grpHO.PerformLayout();
            _grpProperty.ResumeLayout(false);
            _grpProperty.PerformLayout();
            _grpInvoiceAddress.ResumeLayout(false);
            _grpInvoiceAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddresses).EndInit();
            _grpDept.ResumeLayout(false);
            _grpDept.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
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

        private void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}