using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMAddInvoiceAddress : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMAddInvoiceAddress() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMAddInvoiceAddress_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
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
        private GroupBox _gpbSelectInvoiceAddress;

        internal GroupBox gpbSelectInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbSelectInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbSelectInvoiceAddress != null)
                {
                }

                _gpbSelectInvoiceAddress = value;
                if (_gpbSelectInvoiceAddress != null)
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

        private Label _lblInvoiceAddress;

        internal Label lblInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceAddress != null)
                {
                }

                _lblInvoiceAddress = value;
                if (_lblInvoiceAddress != null)
                {
                }
            }
        }

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
            _gpbSelectInvoiceAddress = new GroupBox();
            _dgInvoiceAddresses = new DataGrid();
            _lblInvoiceAddress = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _gpbSelectInvoiceAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddresses).BeginInit();
            SuspendLayout();
            //
            // gpbSelectInvoiceAddress
            //
            _gpbSelectInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbSelectInvoiceAddress.Controls.Add(_btnCancel);
            _gpbSelectInvoiceAddress.Controls.Add(_dgInvoiceAddresses);
            _gpbSelectInvoiceAddress.Controls.Add(_lblInvoiceAddress);
            _gpbSelectInvoiceAddress.Controls.Add(_btnOK);
            _gpbSelectInvoiceAddress.Location = new Point(8, 40);
            _gpbSelectInvoiceAddress.Name = "gpbSelectInvoiceAddress";
            _gpbSelectInvoiceAddress.Size = new Size(512, 328);
            _gpbSelectInvoiceAddress.TabIndex = 3;
            _gpbSelectInvoiceAddress.TabStop = false;
            _gpbSelectInvoiceAddress.Text = "Select Invoice Address";
            //
            // dgInvoiceAddresses
            //
            _dgInvoiceAddresses.DataMember = "";
            _dgInvoiceAddresses.HeaderForeColor = SystemColors.ControlText;
            _dgInvoiceAddresses.Location = new Point(16, 48);
            _dgInvoiceAddresses.Name = "dgInvoiceAddresses";
            _dgInvoiceAddresses.Size = new Size(488, 240);
            _dgInvoiceAddresses.TabIndex = 7;
            //
            // lblInvoiceAddress
            //
            _lblInvoiceAddress.Location = new Point(16, 24);
            _lblInvoiceAddress.Name = "lblInvoiceAddress";
            _lblInvoiceAddress.TabIndex = 8;
            _lblInvoiceAddress.Text = "Invoice Address";
            //
            // btnOK
            //
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(424, 296);
            _btnOK.Name = "btnOK";
            _btnOK.TabIndex = 3;
            _btnOK.Text = "OK";
            //
            // btnCancel
            //
            _btnCancel.UseVisualStyleBackColor = true;
            _btnCancel.Location = new Point(16, 296);
            _btnCancel.Name = "btnCancel";
            _btnCancel.TabIndex = 9;
            _btnCancel.Text = "Cancel";
            //
            // FRMAddInvoiceAddress
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(528, 382);
            ControlBox = false;
            Controls.Add(_gpbSelectInvoiceAddress);
            MaximumSize = new Size(536, 416);
            MinimumSize = new Size(536, 416);
            Name = "FRMAddInvoiceAddress";
            Text = "Select Invoice Address";
            Controls.SetChildIndex(_gpbSelectInvoiceAddress, 0);
            _gpbSelectInvoiceAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddresses).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            OrderID = Conversions.ToInteger(get_GetParameter(0));
            SetupInvoiceAddressDataGrid();
            // Load Invoice Addresses
            InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_OrderID(OrderID);
            if (InvoiceAddresses.Table.Rows.Count > 0)
            {
                dgInvoiceAddresses.CurrentRowIndex = 0;
                dgInvoiceAddresses.Select(dgInvoiceAddresses.CurrentRowIndex);
            }

            InvoiceToBeRaised = App.DB.InvoiceToBeRaised.InvoiceToBeRaised_Get(Conversions.ToInteger(get_GetParameter(1)));
            AddressSelected += ((FRMInvoiceManager)get_GetParameter(2)).PopulateDatagrid;
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupInvoiceAddressDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgInvoiceAddresses);
            var tStyle = dgInvoiceAddresses.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgInvoiceAddresses.ReadOnly = false;
            var AddressType = new DataGridLabelColumn();
            AddressType.Format = "";
            AddressType.FormatInfo = null;
            AddressType.HeaderText = "Address Type";
            AddressType.MappingName = "AddressType";
            AddressType.ReadOnly = true;
            AddressType.Width = 95;
            AddressType.NullText = "";
            tStyle.GridColumnStyles.Add(AddressType);
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 75;
            Address1.NullText = "";
            tStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 75;
            Address2.NullText = "";
            tStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address 3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 75;
            Address3.NullText = "";
            tStyle.GridColumnStyles.Add(Address3);
            var Address4 = new DataGridLabelColumn();
            Address4.Format = "";
            Address4.FormatInfo = null;
            Address4.HeaderText = "Address 4";
            Address4.MappingName = "Address4";
            Address4.ReadOnly = true;
            Address4.Width = 75;
            Address4.NullText = "";
            tStyle.GridColumnStyles.Add(Address4);
            var Address5 = new DataGridLabelColumn();
            Address5.Format = "";
            Address5.FormatInfo = null;
            Address5.HeaderText = "Address 5";
            Address5.MappingName = "Address5";
            Address5.ReadOnly = true;
            Address5.Width = 75;
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
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString();
            dgInvoiceAddresses.TableStyles.Add(tStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _InvoiceAddresses;

        private DataView InvoiceAddresses
        {
            get
            {
                return _InvoiceAddresses;
            }

            set
            {
                _InvoiceAddresses = value;
                _InvoiceAddresses.AllowDelete = false;
                _InvoiceAddresses.AllowEdit = false;
                _InvoiceAddresses.AllowNew = false;
                _InvoiceAddresses.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                dgInvoiceAddresses.DataSource = InvoiceAddresses;
            }
        }

        private DataRow SelectedInvoiceAddressesDataRow
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

        private int _OrderID;

        private int OrderID
        {
            get
            {
                return _OrderID;
            }

            set
            {
                _OrderID = value;
            }
        }

        private Entity.InvoiceToBeRaiseds.InvoiceToBeRaised _InvoiceToBeRaised;

        private Entity.InvoiceToBeRaiseds.InvoiceToBeRaised InvoiceToBeRaised
        {
            get
            {
                return _InvoiceToBeRaised;
            }

            set
            {
                _InvoiceToBeRaised = value;
            }
        }

        private event AddressSelectedEventHandler AddressSelected;

        private delegate void AddressSelectedEventHandler();

        private void FRMAddInvoiceAddress_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedInvoiceAddressesDataRow is object)
            {
                InvoiceToBeRaised.SetAddressLinkID = SelectedInvoiceAddressesDataRow["AddressID"];
                InvoiceToBeRaised.SetAddressTypeID = SelectedInvoiceAddressesDataRow["AddressTypeID"];
                App.DB.InvoiceToBeRaised.Update(InvoiceToBeRaised);
                AddressSelected?.Invoke();
                if (Modal)
                {
                    Close();
                }
                else
                {
                    Dispose();
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}