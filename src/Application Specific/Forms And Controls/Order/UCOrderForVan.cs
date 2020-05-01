using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCOrderForVan : UCBase, IUserControl
    {
        public UCOrderForVan() : base()
        {
            base.Load += UCOrderForVan_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
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
        private GroupBox _grpVanDetails;

        private Button _btnFindVan;

        private TextBox _txtVan;

        internal TextBox txtVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVan != null)
                {
                }

                _txtVan = value;
                if (_txtVan != null)
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

        private Button _btnDeliveryAddress;

        private TextBox _txtDeliveryAddress;

        internal TextBox txtDeliveryAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDeliveryAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDeliveryAddress != null)
                {
                }

                _txtDeliveryAddress = value;
                if (_txtDeliveryAddress != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpVanDetails = new GroupBox();
            _btnDeliveryAddress = new Button();
            _btnDeliveryAddress.Click += new EventHandler(btnDeliveryAddress_Click);
            _txtDeliveryAddress = new TextBox();
            _Label1 = new Label();
            _btnFindVan = new Button();
            _btnFindVan.Click += new EventHandler(btnFindVan_Click);
            _txtVan = new TextBox();
            _grpVanDetails.SuspendLayout();
            SuspendLayout();
            //
            // grpVanDetails
            //
            _grpVanDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVanDetails.Controls.Add(_btnDeliveryAddress);
            _grpVanDetails.Controls.Add(_txtDeliveryAddress);
            _grpVanDetails.Controls.Add(_Label1);
            _grpVanDetails.Controls.Add(_btnFindVan);
            _grpVanDetails.Controls.Add(_txtVan);
            _grpVanDetails.ForeColor = SystemColors.ControlText;
            _grpVanDetails.Location = new Point(8, 8);
            _grpVanDetails.Name = "grpVanDetails";
            _grpVanDetails.Size = new Size(576, 272);
            _grpVanDetails.TabIndex = 2;
            _grpVanDetails.TabStop = false;
            _grpVanDetails.Text = "Stock Profile Details";
            //
            // btnDeliveryAddress
            //
            _btnDeliveryAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnDeliveryAddress.BackColor = Color.White;
            _btnDeliveryAddress.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnDeliveryAddress.Location = new Point(536, 105);
            _btnDeliveryAddress.Name = "btnDeliveryAddress";
            _btnDeliveryAddress.Size = new Size(32, 23);
            _btnDeliveryAddress.TabIndex = 5;
            _btnDeliveryAddress.Text = "...";
            _btnDeliveryAddress.UseVisualStyleBackColor = false;
            //
            // txtDeliveryAddress
            //
            _txtDeliveryAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtDeliveryAddress.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtDeliveryAddress.Location = new Point(8, 105);
            _txtDeliveryAddress.Name = "txtDeliveryAddress";
            _txtDeliveryAddress.ReadOnly = true;
            _txtDeliveryAddress.Size = new Size(520, 21);
            _txtDeliveryAddress.TabIndex = 4;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 88);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(216, 23);
            _Label1.TabIndex = 3;
            _Label1.Text = "Delivery Address for Supplier";
            //
            // btnFindVan
            //
            _btnFindVan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindVan.BackColor = Color.White;
            _btnFindVan.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindVan.Location = new Point(536, 28);
            _btnFindVan.Name = "btnFindVan";
            _btnFindVan.Size = new Size(32, 23);
            _btnFindVan.TabIndex = 2;
            _btnFindVan.Text = "...";
            _btnFindVan.UseVisualStyleBackColor = false;
            //
            // txtVan
            //
            _txtVan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtVan.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtVan.Location = new Point(8, 28);
            _txtVan.Name = "txtVan";
            _txtVan.ReadOnly = true;
            _txtVan.Size = new Size(520, 21);
            _txtVan.TabIndex = 1;
            //
            // UCOrderForVan
            //
            Controls.Add(_grpVanDetails);
            Name = "UCOrderForVan";
            Size = new Size(592, 288);
            _grpVanDetails.ResumeLayout(false);
            _grpVanDetails.PerformLayout();
            ResumeLayout(false);
        }

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
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

        private Entity.Vans.Van _oVan;

        public Entity.Vans.Van Van
        {
            get
            {
                return _oVan;
            }

            set
            {
                _oVan = value;
                txtVan.Text = _oVan.Registration;
            }
        }

        private Entity.Warehouses.Warehouse _oDeliveryAddress;

        public Entity.Warehouses.Warehouse DeliveryAddress
        {
            get
            {
                return _oDeliveryAddress;
            }

            set
            {
                _oDeliveryAddress = value;
                txtDeliveryAddress.Text = _oDeliveryAddress.Name;
                DeliveryAddressID = _oDeliveryAddress.WarehouseID;
            }
        }

        private int _deliveryAddressID = 0;

        public int DeliveryAddressID
        {
            get
            {
                return _deliveryAddressID;
            }

            set
            {
                _deliveryAddressID = value;
            }
        }

        private void UCOrderForVan_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void btnFindVan_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblVan));
            if (!(ID == 0))
            {
                Van = App.DB.Van.Van_Get(ID);
            }
        }

        private void btnDeliveryAddress_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse));
            if (!(ID == 0))
            {
                DeliveryAddress = App.DB.Warehouse.Warehouse_Get(ID);
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