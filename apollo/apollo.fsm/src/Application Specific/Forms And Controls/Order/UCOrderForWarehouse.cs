using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCOrderForWarehouse : UCBase, IUserControl
    {
        

        public UCOrderForWarehouse() : base()
        {
            base.Load += UCOrderForWarehouse_Load;

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
        private GroupBox _grpWarehouseDetails;

        internal GroupBox grpWarehouseDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpWarehouseDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpWarehouseDetails != null)
                {
                }

                _grpWarehouseDetails = value;
                if (_grpWarehouseDetails != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpWarehouseDetails = new GroupBox();
            _btnFindWarehouse = new Button();
            _btnFindWarehouse.Click += new EventHandler(btnFindWarehouse_Click);
            _txtWarehouse = new TextBox();
            _grpWarehouseDetails.SuspendLayout();
            SuspendLayout();
            //
            // grpWarehouseDetails
            //
            _grpWarehouseDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpWarehouseDetails.Controls.Add(_btnFindWarehouse);
            _grpWarehouseDetails.Controls.Add(_txtWarehouse);
            _grpWarehouseDetails.ForeColor = SystemColors.ControlText;
            _grpWarehouseDetails.Location = new Point(8, 8);
            _grpWarehouseDetails.Name = "grpWarehouseDetails";
            _grpWarehouseDetails.Size = new Size(552, 64);
            _grpWarehouseDetails.TabIndex = 1;
            _grpWarehouseDetails.TabStop = false;
            _grpWarehouseDetails.Text = "Warehouse Details";
            //
            // btnFindWarehouse
            //
            _btnFindWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindWarehouse.BackColor = Color.White;
            _btnFindWarehouse.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindWarehouse.Location = new Point(512, 31);
            _btnFindWarehouse.Name = "btnFindWarehouse";
            _btnFindWarehouse.Size = new Size(32, 23);
            _btnFindWarehouse.TabIndex = 2;
            _btnFindWarehouse.Text = "...";
            //
            // txtWarehouse
            //
            _txtWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtWarehouse.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtWarehouse.Location = new Point(8, 31);
            _txtWarehouse.Name = "txtWarehouse";
            _txtWarehouse.ReadOnly = true;
            _txtWarehouse.Size = new Size(496, 21);
            _txtWarehouse.TabIndex = 1;
            _txtWarehouse.Text = "";
            //
            // UCOrderForWarehouse
            //
            Controls.Add(_grpWarehouseDetails);
            Name = "UCOrderForWarehouse";
            Size = new Size(568, 88);
            _grpWarehouseDetails.ResumeLayout(false);
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
                txtWarehouse.Text = Warehouse.Name + " ( " + Warehouse.Address1 + ", " + Warehouse.Postcode + ") ";
            }
        }

        private void btnFindWarehouse_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse));
            if (!(ID == 0))
            {
                Warehouse = App.DB.Warehouse.Warehouse_Get(ID);
            }
        }

        private void UCOrderForWarehouse_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
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