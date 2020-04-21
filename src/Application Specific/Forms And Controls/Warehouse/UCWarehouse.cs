using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCWarehouse : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCWarehouse() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCWarehouse_Load;

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
        private TabControl _tcWarehouse;

        internal TabControl tcWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcWarehouse != null)
                {
                }

                _tcWarehouse = value;
                if (_tcWarehouse != null)
                {
                }
            }
        }

        private TabPage _tabDetails;

        internal TabPage tabDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDetails != null)
                {
                }

                _tabDetails = value;
                if (_tabDetails != null)
                {
                }
            }
        }

        private TabPage _tabStock;

        internal TabPage tabStock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabStock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabStock != null)
                {
                }

                _tabStock = value;
                if (_tabStock != null)
                {
                }
            }
        }

        private GroupBox _grpWarehouse;

        internal GroupBox grpWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpWarehouse != null)
                {
                }

                _grpWarehouse = value;
                if (_grpWarehouse != null)
                {
                }
            }
        }

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private Label _lblName;

        internal Label lblName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblName != null)
                {
                }

                _lblName = value;
                if (_lblName != null)
                {
                }
            }
        }

        private TextBox _txtSize;

        internal TextBox txtSize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSize != null)
                {
                }

                _txtSize = value;
                if (_txtSize != null)
                {
                }
            }
        }

        private Label _lblSize;

        internal Label lblSize
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSize;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSize != null)
                {
                }

                _lblSize = value;
                if (_lblSize != null)
                {
                }
            }
        }

        private TextBox _txtNotes;

        internal TextBox txtNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotes != null)
                {
                }

                _txtNotes = value;
                if (_txtNotes != null)
                {
                }
            }
        }

        private Label _lblNotes;

        internal Label lblNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNotes != null)
                {
                }

                _lblNotes = value;
                if (_lblNotes != null)
                {
                }
            }
        }

        private TextBox _txtAddress1;

        internal TextBox txtAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress1 != null)
                {
                }

                _txtAddress1 = value;
                if (_txtAddress1 != null)
                {
                }
            }
        }

        private Label _lblAddress1;

        internal Label lblAddress1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress1 != null)
                {
                }

                _lblAddress1 = value;
                if (_lblAddress1 != null)
                {
                }
            }
        }

        private TextBox _txtAddress2;

        internal TextBox txtAddress2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress2 != null)
                {
                }

                _txtAddress2 = value;
                if (_txtAddress2 != null)
                {
                }
            }
        }

        private Label _lblAddress2;

        internal Label lblAddress2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress2 != null)
                {
                }

                _lblAddress2 = value;
                if (_lblAddress2 != null)
                {
                }
            }
        }

        private TextBox _txtAddress3;

        internal TextBox txtAddress3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress3 != null)
                {
                }

                _txtAddress3 = value;
                if (_txtAddress3 != null)
                {
                }
            }
        }

        private Label _lblAddress3;

        internal Label lblAddress3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress3 != null)
                {
                }

                _lblAddress3 = value;
                if (_lblAddress3 != null)
                {
                }
            }
        }

        private TextBox _txtAddress4;

        internal TextBox txtAddress4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress4 != null)
                {
                }

                _txtAddress4 = value;
                if (_txtAddress4 != null)
                {
                }
            }
        }

        private Label _lblAddress4;

        internal Label lblAddress4
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress4;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress4 != null)
                {
                }

                _lblAddress4 = value;
                if (_lblAddress4 != null)
                {
                }
            }
        }

        private TextBox _txtAddress5;

        internal TextBox txtAddress5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAddress5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAddress5 != null)
                {
                }

                _txtAddress5 = value;
                if (_txtAddress5 != null)
                {
                }
            }
        }

        private Label _lblAddress5;

        internal Label lblAddress5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddress5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddress5 != null)
                {
                }

                _lblAddress5 = value;
                if (_lblAddress5 != null)
                {
                }
            }
        }

        private TextBox _txtPostcode;

        internal TextBox txtPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPostcode != null)
                {
                }

                _txtPostcode = value;
                if (_txtPostcode != null)
                {
                }
            }
        }

        private Label _lblPostcode;

        internal Label lblPostcode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPostcode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPostcode != null)
                {
                }

                _lblPostcode = value;
                if (_lblPostcode != null)
                {
                }
            }
        }

        private TextBox _txtTelephoneNum;

        internal TextBox txtTelephoneNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTelephoneNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTelephoneNum != null)
                {
                }

                _txtTelephoneNum = value;
                if (_txtTelephoneNum != null)
                {
                }
            }
        }

        private Label _lblTelephoneNum;

        internal Label lblTelephoneNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTelephoneNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTelephoneNum != null)
                {
                }

                _lblTelephoneNum = value;
                if (_lblTelephoneNum != null)
                {
                }
            }
        }

        private TextBox _txtFaxNum;

        internal TextBox txtFaxNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFaxNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFaxNum != null)
                {
                }

                _txtFaxNum = value;
                if (_txtFaxNum != null)
                {
                }
            }
        }

        private Label _lblFaxNum;

        internal Label lblFaxNum
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFaxNum;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFaxNum != null)
                {
                }

                _lblFaxNum = value;
                if (_lblFaxNum != null)
                {
                }
            }
        }

        private TextBox _txtEmailAddress;

        internal TextBox txtEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEmailAddress != null)
                {
                }

                _txtEmailAddress = value;
                if (_txtEmailAddress != null)
                {
                }
            }
        }

        private Label _lblEmailAddress;

        internal Label lblEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEmailAddress != null)
                {
                }

                _lblEmailAddress = value;
                if (_lblEmailAddress != null)
                {
                }
            }
        }

        private CheckBox _chkActive;

        internal CheckBox chkActive
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkActive;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkActive != null)
                {
                }

                _chkActive = value;
                if (_chkActive != null)
                {
                }
            }
        }

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

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private DataGrid _dgProducts;

        internal DataGrid dgProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgProducts != null)
                {
                }

                _dgProducts = value;
                if (_dgProducts != null)
                {
                }
            }
        }

        private TabPage _tpVans;

        internal TabPage tpVans
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpVans;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpVans != null)
                {
                }

                _tpVans = value;
                if (_tpVans != null)
                {
                }
            }
        }

        private GroupBox _grpVans;

        internal GroupBox grpVans
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVans;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVans != null)
                {
                }

                _grpVans = value;
                if (_grpVans != null)
                {
                }
            }
        }

        private DataGrid _dgVans;

        internal DataGrid dgVans
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVans;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVans != null)
                {
                    _dgVans.MouseUp -= dgVans_MouseUp;
                }

                _dgVans = value;
                if (_dgVans != null)
                {
                    _dgVans.MouseUp += dgVans_MouseUp;
                }
            }
        }

        private DataGrid _dgParts;

        internal DataGrid dgParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgParts != null)
                {
                    _dgParts.DoubleClick -= dgParts_DoubleClick;
                }

                _dgParts = value;
                if (_dgParts != null)
                {
                    _dgParts.DoubleClick += dgParts_DoubleClick;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _tcWarehouse = new TabControl();
            _tabDetails = new TabPage();
            _grpWarehouse = new GroupBox();
            _txtName = new TextBox();
            _lblName = new Label();
            _txtSize = new TextBox();
            _lblSize = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _txtAddress1 = new TextBox();
            _lblAddress1 = new Label();
            _txtAddress2 = new TextBox();
            _lblAddress2 = new Label();
            _txtAddress3 = new TextBox();
            _lblAddress3 = new Label();
            _txtAddress4 = new TextBox();
            _lblAddress4 = new Label();
            _txtAddress5 = new TextBox();
            _lblAddress5 = new Label();
            _txtPostcode = new TextBox();
            _lblPostcode = new Label();
            _txtTelephoneNum = new TextBox();
            _lblTelephoneNum = new Label();
            _txtFaxNum = new TextBox();
            _lblFaxNum = new Label();
            _txtEmailAddress = new TextBox();
            _lblEmailAddress = new Label();
            _chkActive = new CheckBox();
            _tabStock = new TabPage();
            _GroupBox2 = new GroupBox();
            _dgParts = new DataGrid();
            _dgParts.DoubleClick += new EventHandler(dgParts_DoubleClick);
            _GroupBox1 = new GroupBox();
            _dgProducts = new DataGrid();
            _tpVans = new TabPage();
            _grpVans = new GroupBox();
            _dgVans = new DataGrid();
            _dgVans.MouseUp += new MouseEventHandler(dgVans_MouseUp);
            _tcWarehouse.SuspendLayout();
            _tabDetails.SuspendLayout();
            _grpWarehouse.SuspendLayout();
            _tabStock.SuspendLayout();
            _GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgParts).BeginInit();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgProducts).BeginInit();
            _tpVans.SuspendLayout();
            _grpVans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgVans).BeginInit();
            SuspendLayout();
            //
            // tcWarehouse
            //
            _tcWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _tcWarehouse.Controls.Add(_tabDetails);
            _tcWarehouse.Controls.Add(_tabStock);
            _tcWarehouse.Controls.Add(_tpVans);
            _tcWarehouse.Location = new Point(3, 8);
            _tcWarehouse.Name = "tcWarehouse";
            _tcWarehouse.SelectedIndex = 0;
            _tcWarehouse.Size = new Size(710, 591);
            _tcWarehouse.TabIndex = 0;
            //
            // tabDetails
            //
            _tabDetails.Controls.Add(_grpWarehouse);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(702, 565);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Main Details";
            //
            // grpWarehouse
            //
            _grpWarehouse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpWarehouse.Controls.Add(_txtName);
            _grpWarehouse.Controls.Add(_lblName);
            _grpWarehouse.Controls.Add(_txtSize);
            _grpWarehouse.Controls.Add(_lblSize);
            _grpWarehouse.Controls.Add(_txtNotes);
            _grpWarehouse.Controls.Add(_lblNotes);
            _grpWarehouse.Controls.Add(_txtAddress1);
            _grpWarehouse.Controls.Add(_lblAddress1);
            _grpWarehouse.Controls.Add(_txtAddress2);
            _grpWarehouse.Controls.Add(_lblAddress2);
            _grpWarehouse.Controls.Add(_txtAddress3);
            _grpWarehouse.Controls.Add(_lblAddress3);
            _grpWarehouse.Controls.Add(_txtAddress4);
            _grpWarehouse.Controls.Add(_lblAddress4);
            _grpWarehouse.Controls.Add(_txtAddress5);
            _grpWarehouse.Controls.Add(_lblAddress5);
            _grpWarehouse.Controls.Add(_txtPostcode);
            _grpWarehouse.Controls.Add(_lblPostcode);
            _grpWarehouse.Controls.Add(_txtTelephoneNum);
            _grpWarehouse.Controls.Add(_lblTelephoneNum);
            _grpWarehouse.Controls.Add(_txtFaxNum);
            _grpWarehouse.Controls.Add(_lblFaxNum);
            _grpWarehouse.Controls.Add(_txtEmailAddress);
            _grpWarehouse.Controls.Add(_lblEmailAddress);
            _grpWarehouse.Controls.Add(_chkActive);
            _grpWarehouse.Location = new Point(8, 8);
            _grpWarehouse.Name = "grpWarehouse";
            _grpWarehouse.Size = new Size(683, 553);
            _grpWarehouse.TabIndex = 2;
            _grpWarehouse.TabStop = false;
            _grpWarehouse.Text = "Main Details";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(120, 24);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(482, 21);
            _txtName.TabIndex = 1;
            _txtName.Tag = "Warehouse.Name";
            //
            // lblName
            //
            _lblName.Location = new Point(8, 24);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(104, 20);
            _lblName.TabIndex = 31;
            _lblName.Text = "Name";
            //
            // txtSize
            //
            _txtSize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSize.Location = new Point(120, 58);
            _txtSize.MaxLength = 255;
            _txtSize.Name = "txtSize";
            _txtSize.Size = new Size(554, 21);
            _txtSize.TabIndex = 3;
            _txtSize.Tag = "Warehouse.Size";
            //
            // lblSize
            //
            _lblSize.Location = new Point(8, 56);
            _lblSize.Name = "lblSize";
            _lblSize.Size = new Size(104, 20);
            _lblSize.TabIndex = 31;
            _lblSize.Text = "Size";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(120, 378);
            _txtNotes.MaxLength = 0;
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(554, 168);
            _txtNotes.TabIndex = 13;
            _txtNotes.Tag = "Warehouse.Notes";
            //
            // lblNotes
            //
            _lblNotes.Location = new Point(8, 376);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(104, 20);
            _lblNotes.TabIndex = 31;
            _lblNotes.Text = "Notes";
            //
            // txtAddress1
            //
            _txtAddress1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress1.Location = new Point(120, 90);
            _txtAddress1.MaxLength = 255;
            _txtAddress1.Name = "txtAddress1";
            _txtAddress1.Size = new Size(554, 21);
            _txtAddress1.TabIndex = 4;
            _txtAddress1.Tag = "Warehouse.Address1";
            //
            // lblAddress1
            //
            _lblAddress1.Location = new Point(8, 88);
            _lblAddress1.Name = "lblAddress1";
            _lblAddress1.Size = new Size(104, 20);
            _lblAddress1.TabIndex = 31;
            _lblAddress1.Text = "Address 1";
            //
            // txtAddress2
            //
            _txtAddress2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress2.Location = new Point(120, 122);
            _txtAddress2.MaxLength = 255;
            _txtAddress2.Name = "txtAddress2";
            _txtAddress2.Size = new Size(554, 21);
            _txtAddress2.TabIndex = 5;
            _txtAddress2.Tag = "Warehouse.Address2";
            //
            // lblAddress2
            //
            _lblAddress2.Location = new Point(8, 120);
            _lblAddress2.Name = "lblAddress2";
            _lblAddress2.Size = new Size(104, 20);
            _lblAddress2.TabIndex = 31;
            _lblAddress2.Text = "Address 2";
            //
            // txtAddress3
            //
            _txtAddress3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress3.Location = new Point(120, 154);
            _txtAddress3.MaxLength = 255;
            _txtAddress3.Name = "txtAddress3";
            _txtAddress3.Size = new Size(554, 21);
            _txtAddress3.TabIndex = 6;
            _txtAddress3.Tag = "Warehouse.Address3";
            //
            // lblAddress3
            //
            _lblAddress3.Location = new Point(8, 152);
            _lblAddress3.Name = "lblAddress3";
            _lblAddress3.Size = new Size(104, 20);
            _lblAddress3.TabIndex = 31;
            _lblAddress3.Text = "Address 3";
            //
            // txtAddress4
            //
            _txtAddress4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress4.Location = new Point(120, 186);
            _txtAddress4.MaxLength = 255;
            _txtAddress4.Name = "txtAddress4";
            _txtAddress4.Size = new Size(554, 21);
            _txtAddress4.TabIndex = 7;
            _txtAddress4.Tag = "Warehouse.Address4";
            //
            // lblAddress4
            //
            _lblAddress4.Location = new Point(8, 184);
            _lblAddress4.Name = "lblAddress4";
            _lblAddress4.Size = new Size(104, 20);
            _lblAddress4.TabIndex = 31;
            _lblAddress4.Text = "Address 4";
            //
            // txtAddress5
            //
            _txtAddress5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAddress5.Location = new Point(120, 218);
            _txtAddress5.MaxLength = 255;
            _txtAddress5.Name = "txtAddress5";
            _txtAddress5.Size = new Size(554, 21);
            _txtAddress5.TabIndex = 8;
            _txtAddress5.Tag = "Warehouse.Address5";
            //
            // lblAddress5
            //
            _lblAddress5.Location = new Point(8, 216);
            _lblAddress5.Name = "lblAddress5";
            _lblAddress5.Size = new Size(104, 20);
            _lblAddress5.TabIndex = 31;
            _lblAddress5.Text = "Address 5";
            //
            // txtPostcode
            //
            _txtPostcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPostcode.Location = new Point(120, 250);
            _txtPostcode.MaxLength = 10;
            _txtPostcode.Name = "txtPostcode";
            _txtPostcode.Size = new Size(554, 21);
            _txtPostcode.TabIndex = 9;
            _txtPostcode.Tag = "Warehouse.Postcode";
            //
            // lblPostcode
            //
            _lblPostcode.Location = new Point(8, 248);
            _lblPostcode.Name = "lblPostcode";
            _lblPostcode.Size = new Size(104, 20);
            _lblPostcode.TabIndex = 31;
            _lblPostcode.Text = "Postcode";
            //
            // txtTelephoneNum
            //
            _txtTelephoneNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtTelephoneNum.Location = new Point(120, 282);
            _txtTelephoneNum.MaxLength = 20;
            _txtTelephoneNum.Name = "txtTelephoneNum";
            _txtTelephoneNum.Size = new Size(554, 21);
            _txtTelephoneNum.TabIndex = 10;
            _txtTelephoneNum.Tag = "Warehouse.TelephoneNum";
            //
            // lblTelephoneNum
            //
            _lblTelephoneNum.Location = new Point(8, 280);
            _lblTelephoneNum.Name = "lblTelephoneNum";
            _lblTelephoneNum.Size = new Size(104, 20);
            _lblTelephoneNum.TabIndex = 31;
            _lblTelephoneNum.Text = "Telephone";
            //
            // txtFaxNum
            //
            _txtFaxNum.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFaxNum.Location = new Point(120, 314);
            _txtFaxNum.MaxLength = 20;
            _txtFaxNum.Name = "txtFaxNum";
            _txtFaxNum.Size = new Size(554, 21);
            _txtFaxNum.TabIndex = 11;
            _txtFaxNum.Tag = "Warehouse.FaxNum";
            //
            // lblFaxNum
            //
            _lblFaxNum.Location = new Point(8, 312);
            _lblFaxNum.Name = "lblFaxNum";
            _lblFaxNum.Size = new Size(104, 20);
            _lblFaxNum.TabIndex = 31;
            _lblFaxNum.Text = "Fax";
            //
            // txtEmailAddress
            //
            _txtEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtEmailAddress.Location = new Point(120, 346);
            _txtEmailAddress.MaxLength = 255;
            _txtEmailAddress.Name = "txtEmailAddress";
            _txtEmailAddress.Size = new Size(554, 21);
            _txtEmailAddress.TabIndex = 12;
            _txtEmailAddress.Tag = "Warehouse.EmailAddress";
            //
            // lblEmailAddress
            //
            _lblEmailAddress.Location = new Point(8, 344);
            _lblEmailAddress.Name = "lblEmailAddress";
            _lblEmailAddress.Size = new Size(104, 20);
            _lblEmailAddress.TabIndex = 31;
            _lblEmailAddress.Text = "Email Address";
            //
            // chkActive
            //
            _chkActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkActive.Font = new Font("Verdana", 8.0F);
            _chkActive.Location = new Point(610, 26);
            _chkActive.Name = "chkActive";
            _chkActive.Size = new Size(64, 18);
            _chkActive.TabIndex = 2;
            _chkActive.Tag = "Warehouse.Active";
            _chkActive.Text = "Active";
            //
            // tabStock
            //
            _tabStock.Controls.Add(_GroupBox2);
            _tabStock.Controls.Add(_GroupBox1);
            _tabStock.Location = new Point(4, 22);
            _tabStock.Name = "tabStock";
            _tabStock.Size = new Size(702, 565);
            _tabStock.TabIndex = 1;
            _tabStock.Text = "Stock";
            //
            // GroupBox2
            //
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox2.Controls.Add(_dgParts);
            _GroupBox2.Location = new Point(8, 216);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(683, 338);
            _GroupBox2.TabIndex = 1;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Parts held in warehouse";
            //
            // dgParts
            //
            _dgParts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgParts.DataMember = "";
            _dgParts.HeaderForeColor = SystemColors.ControlText;
            _dgParts.Location = new Point(8, 26);
            _dgParts.Name = "dgParts";
            _dgParts.Size = new Size(667, 304);
            _dgParts.TabIndex = 2;
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _GroupBox1.Controls.Add(_dgProducts);
            _GroupBox1.Location = new Point(8, 8);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(683, 200);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Products held in warehouse";
            //
            // dgProducts
            //
            _dgProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgProducts.DataMember = "";
            _dgProducts.HeaderForeColor = SystemColors.ControlText;
            _dgProducts.Location = new Point(8, 26);
            _dgProducts.Name = "dgProducts";
            _dgProducts.Size = new Size(667, 166);
            _dgProducts.TabIndex = 1;
            //
            // tpVans
            //
            _tpVans.Controls.Add(_grpVans);
            _tpVans.Location = new Point(4, 22);
            _tpVans.Name = "tpVans";
            _tpVans.Padding = new Padding(3);
            _tpVans.Size = new Size(702, 565);
            _tpVans.TabIndex = 2;
            _tpVans.Text = "Vans";
            _tpVans.UseVisualStyleBackColor = true;
            //
            // grpVans
            //
            _grpVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpVans.Controls.Add(_dgVans);
            _grpVans.Location = new Point(6, 3);
            _grpVans.Name = "grpVans";
            _grpVans.Size = new Size(690, 549);
            _grpVans.TabIndex = 4;
            _grpVans.TabStop = false;
            _grpVans.Text = "Tick those vans for this warehouse";
            //
            // dgVans
            //
            _dgVans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgVans.DataMember = "";
            _dgVans.HeaderForeColor = SystemColors.ControlText;
            _dgVans.Location = new Point(6, 20);
            _dgVans.Name = "dgVans";
            _dgVans.Size = new Size(678, 523);
            _dgVans.TabIndex = 2;
            //
            // UCWarehouse
            //
            Controls.Add(_tcWarehouse);
            Name = "UCWarehouse";
            Size = new Size(723, 604);
            _tcWarehouse.ResumeLayout(false);
            _tabDetails.ResumeLayout(false);
            _grpWarehouse.ResumeLayout(false);
            _grpWarehouse.PerformLayout();
            _tabStock.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgParts).EndInit();
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgProducts).EndInit();
            _tpVans.ResumeLayout(false);
            _grpVans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgVans).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupPartsDatagrid();
            SetupProductsDatagrid();
            SetupVansDatagrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentWarehouse;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView m_dTable = null;

        public DataView ProductsDataView
        {
            get
            {
                return m_dTable;
            }

            set
            {
                m_dTable = value;
                m_dTable.Table.TableName = Entity.Sys.Enums.TableNames.tblProduct.ToString();
                m_dTable.AllowNew = false;
                m_dTable.AllowEdit = false;
                m_dTable.AllowDelete = false;
                dgProducts.DataSource = ProductsDataView;
            }
        }

        private DataRow SelectedProductDataRow
        {
            get
            {
                if (!(dgProducts.CurrentRowIndex == -1))
                {
                    return ProductsDataView[dgProducts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView m_dTable2 = null;

        public DataView PartsDataView
        {
            get
            {
                return m_dTable2;
            }

            set
            {
                m_dTable2 = value;
                m_dTable2.Table.TableName = Entity.Sys.Enums.TableNames.tblPart.ToString();
                m_dTable2.AllowNew = false;
                m_dTable2.AllowEdit = false;
                m_dTable2.AllowDelete = false;
                dgParts.DataSource = PartsDataView;
            }
        }

        private DataRow SelectedPartDataRow
        {
            get
            {
                if (!(dgParts.CurrentRowIndex == -1))
                {
                    return PartsDataView[dgParts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Warehouses.Warehouse _currentWarehouse;

        public Entity.Warehouses.Warehouse CurrentWarehouse
        {
            get
            {
                return _currentWarehouse;
            }

            set
            {
                _currentWarehouse = value;
                if (CurrentWarehouse is null)
                {
                    CurrentWarehouse = new Entity.Warehouses.Warehouse();
                    CurrentWarehouse.Exists = false;
                }

                if (CurrentWarehouse.Exists)
                {
                    Populate();
                }
                else
                {
                    VansDataView = App.DB.Van.Van_GetAll_For_Warehouse(0);
                }
            }
        }

        private DataView _VansDataView = null;

        public DataView VansDataView
        {
            get
            {
                return _VansDataView;
            }

            set
            {
                _VansDataView = value;
                _VansDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblVan.ToString();
                _VansDataView.AllowNew = false;
                _VansDataView.AllowEdit = false;
                _VansDataView.AllowDelete = false;
                dgVans.DataSource = VansDataView;
            }
        }

        private DataRow SelectedVanDataRow
        {
            get
            {
                if (!(dgVans.CurrentRowIndex == -1))
                {
                    return VansDataView[dgVans.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupProductsDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgProducts);
            var tStyle = dgProducts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var ProductName = new DataGridLabelColumn();
            ProductName.Format = "";
            ProductName.FormatInfo = null;
            ProductName.HeaderText = "Description";
            ProductName.MappingName = "typemakemodel";
            ProductName.ReadOnly = true;
            ProductName.Width = 180;
            ProductName.NullText = "";
            tStyle.GridColumnStyles.Add(ProductName);
            var ProductNumber = new DataGridLabelColumn();
            ProductNumber.Format = "";
            ProductNumber.FormatInfo = null;
            ProductNumber.HeaderText = "GC Number";
            ProductNumber.MappingName = "ProductNumber";
            ProductNumber.ReadOnly = true;
            ProductNumber.Width = 140;
            ProductNumber.NullText = "";
            tStyle.GridColumnStyles.Add(ProductNumber);
            var ProductReference = new DataGridLabelColumn();
            ProductReference.Format = "";
            ProductReference.FormatInfo = null;
            ProductReference.HeaderText = "Product Reference";
            ProductReference.MappingName = "Reference";
            ProductReference.ReadOnly = true;
            ProductReference.Width = 200;
            ProductReference.NullText = "";
            tStyle.GridColumnStyles.Add(ProductReference);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 120;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblProduct.ToString();
            dgProducts.TableStyles.Add(tStyle);
        }

        public void SetupPartsDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgParts);
            var tStyle = dgParts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var PartName = new DataGridLabelColumn();
            PartName.Format = "";
            PartName.FormatInfo = null;
            PartName.HeaderText = "Part Name";
            PartName.MappingName = "PartName";
            PartName.ReadOnly = true;
            PartName.Width = 180;
            PartName.NullText = "";
            tStyle.GridColumnStyles.Add(PartName);
            var PartNumber = new DataGridLabelColumn();
            PartNumber.Format = "";
            PartNumber.FormatInfo = null;
            PartNumber.HeaderText = "Part Number";
            PartNumber.MappingName = "PartNumber";
            PartNumber.ReadOnly = true;
            PartNumber.Width = 70;
            PartNumber.NullText = "";
            tStyle.GridColumnStyles.Add(PartNumber);
            var PartReference = new DataGridLabelColumn();
            PartReference.Format = "";
            PartReference.FormatInfo = null;
            PartReference.HeaderText = "Part Reference";
            PartReference.MappingName = "Reference";
            PartReference.ReadOnly = true;
            PartReference.Width = 100;
            PartReference.NullText = "";
            tStyle.GridColumnStyles.Add(PartReference);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 120;
            Amount.NullText = "";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPart.ToString();
            dgParts.TableStyles.Add(tStyle);
        }

        public void SetupVansDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgVans);
            var tStyle = dgVans.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.ReadOnly = false;
            tStyle.AllowSorting = false;
            dgVans.ReadOnly = false;
            dgVans.AllowSorting = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Registration = new DataGridLabelColumn();
            Registration.Format = "";
            Registration.FormatInfo = null;
            Registration.HeaderText = "Registration";
            Registration.MappingName = "Registration";
            Registration.ReadOnly = true;
            Registration.Width = 300;
            Registration.NullText = "";
            tStyle.GridColumnStyles.Add(Registration);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblVan.ToString();
            dgVans.TableStyles.Add(tStyle);
        }

        private void UCWarehouse_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgParts_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedPartDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMPart), true, new object[] { SelectedPartDataRow["PartID"], true });
            PartsDataView = App.DB.PartTransaction.GetByWarehouse(CurrentWarehouse.WarehouseID);
        }

        private void dgVans_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgVans.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgVans.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedVanDataRow is null)
                {
                    return;
                }

                bool selected = !Entity.Sys.Helper.MakeBooleanValid(dgVans[dgVans.CurrentRowIndex, 0]);
                if (!selected)
                {
                    if (Conversions.ToBoolean(SelectedVanDataRow["HasStock"]))
                    {
                        App.ShowMessage(Conversions.ToString("'" + SelectedVanDataRow["Name"] + "' on this van has stock so cannot be unselected"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                dgVans[dgVans.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentWarehouse = App.DB.Warehouse.Warehouse_Get(ID);
            }

            ProductsDataView = App.DB.ProductTransaction.GetByWarehouse(CurrentWarehouse.WarehouseID);
            PartsDataView = App.DB.PartTransaction.GetByWarehouse(CurrentWarehouse.WarehouseID);
            VansDataView = App.DB.Van.Van_GetAll_For_Warehouse(CurrentWarehouse.WarehouseID);
            txtName.Text = CurrentWarehouse.Name;
            txtSize.Text = CurrentWarehouse.Size;
            txtNotes.Text = CurrentWarehouse.Notes;
            txtAddress1.Text = CurrentWarehouse.Address1;
            txtAddress2.Text = CurrentWarehouse.Address2;
            txtAddress3.Text = CurrentWarehouse.Address3;
            txtAddress4.Text = CurrentWarehouse.Address4;
            txtAddress5.Text = CurrentWarehouse.Address5;
            txtPostcode.Text = CurrentWarehouse.Postcode;
            txtTelephoneNum.Text = CurrentWarehouse.TelephoneNum;
            txtFaxNum.Text = CurrentWarehouse.FaxNum;
            txtEmailAddress.Text = CurrentWarehouse.EmailAddress;
            chkActive.Checked = CurrentWarehouse.Active;
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentWarehouse.IgnoreExceptionsOnSetMethods = true;
                CurrentWarehouse.SetName = txtName.Text.Trim();
                CurrentWarehouse.SetSize = txtSize.Text.Trim();
                CurrentWarehouse.SetNotes = txtNotes.Text.Trim();
                CurrentWarehouse.SetAddress1 = txtAddress1.Text.Trim();
                CurrentWarehouse.SetAddress2 = txtAddress2.Text.Trim();
                CurrentWarehouse.SetAddress3 = txtAddress3.Text.Trim();
                CurrentWarehouse.SetAddress4 = txtAddress4.Text.Trim();
                CurrentWarehouse.SetAddress5 = txtAddress5.Text.Trim();
                CurrentWarehouse.SetPostcode = txtPostcode.Text.Trim();
                CurrentWarehouse.SetTelephoneNum = txtTelephoneNum.Text.Trim();
                CurrentWarehouse.SetFaxNum = txtFaxNum.Text.Trim();
                CurrentWarehouse.SetEmailAddress = txtEmailAddress.Text.Trim();
                CurrentWarehouse.SetActive = chkActive.Checked;
                var cV = new Entity.Warehouses.WarehouseValidator();
                cV.Validate(CurrentWarehouse);
                if (CurrentWarehouse.Exists)
                {
                    App.DB.Warehouse.Update(CurrentWarehouse, VansDataView);
                }
                else
                {
                    CurrentWarehouse = App.DB.Warehouse.Insert(CurrentWarehouse, VansDataView);
                }

                RecordsChanged?.Invoke(App.DB.Warehouse.Warehouse_GetAll(), Entity.Sys.Enums.PageViewing.Warehouse, true, false, "");
                StateChanged?.Invoke(CurrentWarehouse.WarehouseID);
                App.MainForm.RefreshEntity(CurrentWarehouse.WarehouseID);
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}