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
    public class FrmRaiseInvoiceDetails : FRMBaseForm, IForm
    {
        

        public FrmRaiseInvoiceDetails() : base()
        {
            
            
            base.Load += FrmRaiseInvoiceDetails_Load;

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
                    _dgInvoiceAddresses.Click -= dgInvoiceAddresses_Click;
                }

                _dgInvoiceAddresses = value;
                if (_dgInvoiceAddresses != null)
                {
                    _dgInvoiceAddresses.Click += dgInvoiceAddresses_Click;
                }
            }
        }

        private DateTimePicker _dtpRaiseInvoiceOn;

        internal DateTimePicker dtpRaiseInvoiceOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpRaiseInvoiceOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpRaiseInvoiceOn != null)
                {
                }

                _dtpRaiseInvoiceOn = value;
                if (_dtpRaiseInvoiceOn != null)
                {
                }
            }
        }

        private Label _lblRaiseInvoiceOn;

        internal Label lblRaiseInvoiceOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRaiseInvoiceOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRaiseInvoiceOn != null)
                {
                }

                _lblRaiseInvoiceOn = value;
                if (_lblRaiseInvoiceOn != null)
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

        private GroupBox _gpbRaiseInvoice;

        internal GroupBox gpbRaiseInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbRaiseInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbRaiseInvoice != null)
                {
                }

                _gpbRaiseInvoice = value;
                if (_gpbRaiseInvoice != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _gpbRaiseInvoice = new GroupBox();
            _dgInvoiceAddresses = new DataGrid();
            _dgInvoiceAddresses.Click += new EventHandler(dgInvoiceAddresses_Click);
            _dtpRaiseInvoiceOn = new DateTimePicker();
            _lblRaiseInvoiceOn = new Label();
            _lblInvoiceAddress = new Label();
            _btnOK = new Button();
            _btnOK.Click += new EventHandler(btnOK_Click);
            _gpbRaiseInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddresses).BeginInit();
            SuspendLayout();
            //
            // gpbRaiseInvoice
            //
            _gpbRaiseInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbRaiseInvoice.Controls.Add(_dgInvoiceAddresses);
            _gpbRaiseInvoice.Controls.Add(_dtpRaiseInvoiceOn);
            _gpbRaiseInvoice.Controls.Add(_lblRaiseInvoiceOn);
            _gpbRaiseInvoice.Controls.Add(_lblInvoiceAddress);
            _gpbRaiseInvoice.Controls.Add(_btnOK);
            _gpbRaiseInvoice.Location = new Point(8, 32);
            _gpbRaiseInvoice.Name = "gpbRaiseInvoice";
            _gpbRaiseInvoice.Size = new Size(512, 240);
            _gpbRaiseInvoice.TabIndex = 2;
            _gpbRaiseInvoice.TabStop = false;
            _gpbRaiseInvoice.Text = "Raise Invoice";
            //
            // dgInvoiceAddresses
            //
            _dgInvoiceAddresses.DataMember = "";
            _dgInvoiceAddresses.HeaderForeColor = SystemColors.ControlText;
            _dgInvoiceAddresses.Location = new Point(16, 64);
            _dgInvoiceAddresses.Name = "dgInvoiceAddresses";
            _dgInvoiceAddresses.Size = new Size(488, 136);
            _dgInvoiceAddresses.TabIndex = 7;
            //
            // dtpRaiseInvoiceOn
            //
            _dtpRaiseInvoiceOn.Format = DateTimePickerFormat.Short;
            _dtpRaiseInvoiceOn.Location = new Point(136, 24);
            _dtpRaiseInvoiceOn.Name = "dtpRaiseInvoiceOn";
            _dtpRaiseInvoiceOn.Size = new Size(120, 21);
            _dtpRaiseInvoiceOn.TabIndex = 6;
            //
            // lblRaiseInvoiceOn
            //
            _lblRaiseInvoiceOn.Location = new Point(16, 24);
            _lblRaiseInvoiceOn.Name = "lblRaiseInvoiceOn";
            _lblRaiseInvoiceOn.Size = new Size(112, 23);
            _lblRaiseInvoiceOn.TabIndex = 5;
            _lblRaiseInvoiceOn.Text = "Raise Invoice On:";
            _lblRaiseInvoiceOn.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblInvoiceAddress
            //
            _lblInvoiceAddress.Location = new Point(16, 48);
            _lblInvoiceAddress.Name = "lblInvoiceAddress";
            _lblInvoiceAddress.TabIndex = 8;
            _lblInvoiceAddress.Text = "Invoice Address";
            //
            // btnOK
            //
            _btnOK.UseVisualStyleBackColor = true;
            _btnOK.Location = new Point(216, 208);
            _btnOK.Name = "btnOK";
            _btnOK.TabIndex = 3;
            _btnOK.Text = "OK";
            //
            // FrmRaiseInvoiceDetails
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(528, 278);
            ControlBox = false;
            Controls.Add(_gpbRaiseInvoice);
            Name = "FrmRaiseInvoiceDetails";
            Text = "Raise Invoice";
            Controls.SetChildIndex(_gpbRaiseInvoice, 0);
            _gpbRaiseInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddresses).EndInit();
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            OrderID = Conversions.ToInteger(get_GetParameter(0));
            LoadForm(sender, e, this);
            int orderInvoiceAddressID = 0;
            try
            {
                orderInvoiceAddressID = Conversions.ToInteger(get_GetParameter(1));
            }
            catch (Exception ex)
            {
                // AMY PUT EMPTY TRY
            }

            SetupInvoiceAddressDataGrid();
            // Set raise date to today
            dtpRaiseInvoiceOn.Value = DateAndTime.Now;

            // Load Invoice Addresses
            InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_OrderID(OrderID);
            if (InvoiceAddresses.Table.Rows.Count > 0)
            {
                dgInvoiceAddresses.CurrentRowIndex = 0;
                dgInvoiceAddresses.Select(dgInvoiceAddresses.CurrentRowIndex);
            }

            if (orderInvoiceAddressID > 0)
            {
                int rwCnt = 0;
                foreach (DataRow dr in InvoiceAddresses.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["AddressType"], Entity.Sys.Enums.InvoiceAddressType.Invoice.ToString(), false) & Operators.ConditionalCompareObjectEqual(dr["AddressID"], orderInvoiceAddressID, false)))
                    {
                        if (InvoiceAddresses.Table.Rows.Count > 0)
                        {
                            dgInvoiceAddresses.UnSelect(dgInvoiceAddresses.CurrentRowIndex);
                        }

                        dgInvoiceAddresses.CurrentRowIndex = rwCnt;
                        dgInvoiceAddresses.Select(dgInvoiceAddresses.CurrentRowIndex);
                        break;
                    }
                    else
                    {
                        rwCnt += 1;
                    }
                }
            }
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void ResetMe(int newID)
        {
        }

        
        

        public void SetupInvoiceAddressDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgInvoiceAddresses);
            var tStyle = dgInvoiceAddresses.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgInvoiceAddresses.ReadOnly = false;

            // Dim Tick As New DataGridBoolColumn
            // Tick.HeaderText = ""
            // Tick.MappingName = "Tick"
            // Tick.ReadOnly = True
            // Tick.Width = 25
            // Tick.NullText = ""
            // tStyle.GridColumnStyles.Add(Tick)

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

        private void FrmRaiseInvoiceDetails_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SelectedInvoiceAddressesDataRow is null & InvoiceAddresses.Table.Rows.Count > 0)
            {
                return;
            }
            else
            {
                var Invoice2BRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                Invoice2BRaised.RaiseDate = dtpRaiseInvoiceOn.Value;
                Invoice2BRaised.SetInvoiceTypeID = Conversions.ToInteger(Entity.Sys.Enums.InvoiceType.Order);
                Invoice2BRaised.SetLinkID = OrderID;
                if (SelectedInvoiceAddressesDataRow is null & InvoiceAddresses.Table.Rows.Count == 0)
                {
                    MessageBox.Show("There is no invoice addresses to select. You will need to select an address at invoice generation", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Invoice2BRaised.SetAddressLinkID = SelectedInvoiceAddressesDataRow["AddressID"];
                    Invoice2BRaised.SetAddressTypeID = SelectedInvoiceAddressesDataRow["AddressTypeID"];
                }

                App.DB.InvoiceToBeRaised.Insert(Invoice2BRaised);
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

        private void dgInvoiceAddresses_Click(object sender, EventArgs e)
        {
            if (InvoiceAddresses.Table.Rows.Count > 0)
            {
                dgInvoiceAddresses.Select(dgInvoiceAddresses.CurrentRowIndex);
            }
        }

        
    }
}