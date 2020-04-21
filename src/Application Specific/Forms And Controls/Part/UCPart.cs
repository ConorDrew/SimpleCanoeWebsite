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
    public class UCPart : UCBase, IUserControl
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCPart() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCPart_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboUnitType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.UnitTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboCategory;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartCategories).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc2 = cboFuel;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)25).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable);
            var argc3 = cboManufacturer;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Makes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable);
            // Combo.SetUpCombo(Me.cboWarehouse, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
            // Combo.SetUpCombo(Me.choShelf, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartShelfReferences).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
            // 'Combo.SetUpCombo(Me.cboBinID, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartBinReferences).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
            // Combo.SetUpCombo(Me.cboWarehouseAlternative, DB.Warehouse.Warehouse_GetAll().Table, "WarehouseID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
            // Combo.SetUpCombo(Me.cboShelfAlternatuve, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartShelfReferences).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)
            // Combo.SetUpCombo(Me.cboBinAlternatuve, DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.PartBinReferences).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Not_Applicable)

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
        private TabControl _TabControl1;

        internal TabControl TabControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControl1 != null)
                {
                }

                _TabControl1 = value;
                if (_TabControl1 != null)
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

        private TabPage _tabSuppliers;

        internal TabPage tabSuppliers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabSuppliers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabSuppliers != null)
                {
                }

                _tabSuppliers = value;
                if (_tabSuppliers != null)
                {
                }
            }
        }

        private GroupBox _grpPart;

        internal GroupBox grpPart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPart != null)
                {
                }

                _grpPart = value;
                if (_grpPart != null)
                {
                }
            }
        }

        private TextBox _txtSellPrice;

        internal TextBox txtSellPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSellPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSellPrice != null)
                {
                }

                _txtSellPrice = value;
                if (_txtSellPrice != null)
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

        private ComboBox _cboUnitType;

        internal ComboBox cboUnitType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUnitType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUnitType != null)
                {
                }

                _cboUnitType = value;
                if (_cboUnitType != null)
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

        private Label _Label2;

        internal Label Label2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
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

        private TextBox _txtNumber;

        internal TextBox txtNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNumber != null)
                {
                }

                _txtNumber = value;
                if (_txtNumber != null)
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

        private DataGrid _dgPartSuppliers;

        internal DataGrid dgPartSuppliers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartSuppliers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartSuppliers != null)
                {
                    _dgPartSuppliers.MouseUp -= dgPartSuppliers_MouseUp;
                    _dgPartSuppliers.DoubleClick -= dgPartSuppliers_DoubleClick;
                }

                _dgPartSuppliers = value;
                if (_dgPartSuppliers != null)
                {
                    _dgPartSuppliers.MouseUp += dgPartSuppliers_MouseUp;
                    _dgPartSuppliers.DoubleClick += dgPartSuppliers_DoubleClick;
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

        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
                }
            }
        }

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
                }
            }
        }

        private TextBox _txtReference;

        internal TextBox txtReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtReference != null)
                {
                }

                _txtReference = value;
                if (_txtReference != null)
                {
                }
            }
        }

        private ComboBox _cboCategory;

        internal ComboBox cboCategory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCategory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCategory != null)
                {
                }

                _cboCategory = value;
                if (_cboCategory != null)
                {
                }
            }
        }

        private TabPage _tpStock;

        internal TabPage tpStock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpStock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpStock != null)
                {
                }

                _tpStock = value;
                if (_tpStock != null)
                {
                }
            }
        }

        private GroupBox _grpStock;

        internal GroupBox grpStock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpStock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpStock != null)
                {
                }

                _grpStock = value;
                if (_grpStock != null)
                {
                }
            }
        }

        private DataGrid _dgStock;

        internal DataGrid dgStock
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgStock;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgStock != null)
                {
                }

                _dgStock = value;
                if (_dgStock != null)
                {
                }
            }
        }

        private CheckBox _chkEndFlagged;

        internal CheckBox chkEndFlagged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkEndFlagged;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkEndFlagged != null)
                {
                }

                _chkEndFlagged = value;
                if (_chkEndFlagged != null)
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

        private TabPage _tpQuantities;

        internal TabPage tpQuantities
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpQuantities;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpQuantities != null)
                {
                }

                _tpQuantities = value;
                if (_tpQuantities != null)
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

        private DataGrid _dgQuantities;

        internal DataGrid dgQuantities
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgQuantities;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgQuantities != null)
                {
                }

                _dgQuantities = value;
                if (_dgQuantities != null)
                {
                }
            }
        }

        private ComboBox _cboFuel;

        internal ComboBox cboFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFuel != null)
                {
                }

                _cboFuel = value;
                if (_cboFuel != null)
                {
                }
            }
        }

        private Label _Label5;

        internal Label Label5
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label5;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label5 != null)
                {
                }

                _Label5 = value;
                if (_Label5 != null)
                {
                }
            }
        }

        private ComboBox _cboManufacturer;

        internal ComboBox cboManufacturer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboManufacturer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboManufacturer != null)
                {
                }

                _cboManufacturer = value;
                if (_cboManufacturer != null)
                {
                }
            }
        }

        private Label _Label6;

        internal Label Label6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label6 != null)
                {
                }

                _Label6 = value;
                if (_Label6 != null)
                {
                }
            }
        }

        private Label _Label8;

        internal Label Label8
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label8;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label8 != null)
                {
                }

                _Label8 = value;
                if (_Label8 != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _TabControl1 = new TabControl();
            _tabDetails = new TabPage();
            _grpPart = new GroupBox();
            _cboFuel = new ComboBox();
            _Label5 = new Label();
            _chkEndFlagged = new CheckBox();
            _Label14 = new Label();
            _Label8 = new Label();
            _cboCategory = new ComboBox();
            _Label7 = new Label();
            _txtReference = new TextBox();
            _txtSellPrice = new TextBox();
            _Label4 = new Label();
            _cboUnitType = new ComboBox();
            _Label3 = new Label();
            _Label2 = new Label();
            _Label1 = new Label();
            _txtName = new TextBox();
            _txtNumber = new TextBox();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _tabSuppliers = new TabPage();
            _GroupBox1 = new GroupBox();
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgPartSuppliers = new DataGrid();
            _dgPartSuppliers.MouseUp += new MouseEventHandler(dgPartSuppliers_MouseUp);
            _dgPartSuppliers.DoubleClick += new EventHandler(dgPartSuppliers_DoubleClick);
            _tpQuantities = new TabPage();
            _GroupBox2 = new GroupBox();
            _dgQuantities = new DataGrid();
            _tpStock = new TabPage();
            _grpStock = new GroupBox();
            _dgStock = new DataGrid();
            _Label6 = new Label();
            _cboManufacturer = new ComboBox();
            _TabControl1.SuspendLayout();
            _tabDetails.SuspendLayout();
            _grpPart.SuspendLayout();
            _tabSuppliers.SuspendLayout();
            _GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgPartSuppliers).BeginInit();
            _tpQuantities.SuspendLayout();
            _GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgQuantities).BeginInit();
            _tpStock.SuspendLayout();
            _grpStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgStock).BeginInit();
            SuspendLayout();
            //
            // TabControl1
            //
            _TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _TabControl1.Controls.Add(_tabDetails);
            _TabControl1.Controls.Add(_tabSuppliers);
            _TabControl1.Controls.Add(_tpQuantities);
            _TabControl1.Controls.Add(_tpStock);
            _TabControl1.Location = new Point(1, 5);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(632, 638);
            _TabControl1.TabIndex = 0;
            //
            // tabDetails
            //
            _tabDetails.Controls.Add(_grpPart);
            _tabDetails.Location = new Point(4, 22);
            _tabDetails.Name = "tabDetails";
            _tabDetails.Size = new Size(624, 612);
            _tabDetails.TabIndex = 0;
            _tabDetails.Text = "Main Details";
            //
            // grpPart
            //
            _grpPart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpPart.Controls.Add(_cboManufacturer);
            _grpPart.Controls.Add(_Label6);
            _grpPart.Controls.Add(_cboFuel);
            _grpPart.Controls.Add(_Label5);
            _grpPart.Controls.Add(_chkEndFlagged);
            _grpPart.Controls.Add(_Label14);
            _grpPart.Controls.Add(_Label8);
            _grpPart.Controls.Add(_cboCategory);
            _grpPart.Controls.Add(_Label7);
            _grpPart.Controls.Add(_txtReference);
            _grpPart.Controls.Add(_txtSellPrice);
            _grpPart.Controls.Add(_Label4);
            _grpPart.Controls.Add(_cboUnitType);
            _grpPart.Controls.Add(_Label3);
            _grpPart.Controls.Add(_Label2);
            _grpPart.Controls.Add(_Label1);
            _grpPart.Controls.Add(_txtName);
            _grpPart.Controls.Add(_txtNumber);
            _grpPart.Controls.Add(_txtNotes);
            _grpPart.Controls.Add(_lblNotes);
            _grpPart.Location = new Point(8, 8);
            _grpPart.Name = "grpPart";
            _grpPart.Size = new Size(609, 595);
            _grpPart.TabIndex = 0;
            _grpPart.TabStop = false;
            _grpPart.Text = "Main Details";
            //
            // cboFuel
            //
            _cboFuel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboFuel.Location = new Point(160, 213);
            _cboFuel.Name = "cboFuel";
            _cboFuel.Size = new Size(436, 21);
            _cboFuel.TabIndex = 57;
            //
            // Label5
            //
            _Label5.Location = new Point(8, 212);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(62, 23);
            _Label5.TabIndex = 58;
            _Label5.Text = "Fuel";
            //
            // chkEndFlagged
            //
            _chkEndFlagged.Location = new Point(160, 356);
            _chkEndFlagged.Name = "chkEndFlagged";
            _chkEndFlagged.Size = new Size(92, 24);
            _chkEndFlagged.TabIndex = 17;
            _chkEndFlagged.UseVisualStyleBackColor = true;
            //
            // Label14
            //
            _Label14.Location = new Point(8, 356);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(152, 24);
            _Label14.TabIndex = 56;
            _Label14.Text = "End Flagged";
            //
            // Label8
            //
            _Label8.Location = new Point(8, 56);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(64, 21);
            _Label8.TabIndex = 44;
            _Label8.Text = "Category";
            //
            // cboCategory
            //
            _cboCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboCategory.Location = new Point(160, 57);
            _cboCategory.Name = "cboCategory";
            _cboCategory.Size = new Size(436, 21);
            _cboCategory.TabIndex = 1;
            //
            // Label7
            //
            _Label7.Location = new Point(8, 120);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(109, 21);
            _Label7.TabIndex = 42;
            _Label7.Text = "Reference (GPN)";
            //
            // txtReference
            //
            _txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtReference.Location = new Point(160, 120);
            _txtReference.MaxLength = 100;
            _txtReference.Name = "txtReference";
            _txtReference.Size = new Size(436, 21);
            _txtReference.TabIndex = 3;
            _txtReference.Tag = "Part.Reference";
            //
            // txtSellPrice
            //
            _txtSellPrice.Location = new Point(160, 324);
            _txtSellPrice.Name = "txtSellPrice";
            _txtSellPrice.Size = new Size(104, 21);
            _txtSellPrice.TabIndex = 13;
            //
            // Label4
            //
            _Label4.Location = new Point(8, 323);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(63, 23);
            _Label4.TabIndex = 36;
            _Label4.Text = "Sell Price";
            //
            // cboUnitType
            //
            _cboUnitType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboUnitType.Location = new Point(160, 153);
            _cboUnitType.Name = "cboUnitType";
            _cboUnitType.Size = new Size(436, 21);
            _cboUnitType.TabIndex = 4;
            //
            // Label3
            //
            _Label3.Location = new Point(8, 152);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(62, 23);
            _Label3.TabIndex = 34;
            _Label3.Text = "Unit Type";
            //
            // Label2
            //
            _Label2.Location = new Point(8, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(57, 21);
            _Label2.TabIndex = 33;
            _Label2.Text = "Name";
            //
            // Label1
            //
            _Label1.Location = new Point(8, 88);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(100, 21);
            _Label1.TabIndex = 32;
            _Label1.Text = "Number (MPN)";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(160, 26);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(436, 21);
            _txtName.TabIndex = 0;
            _txtName.Tag = "Part.Name";
            //
            // txtNumber
            //
            _txtNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNumber.Location = new Point(160, 89);
            _txtNumber.MaxLength = 100;
            _txtNumber.Name = "txtNumber";
            _txtNumber.Size = new Size(436, 21);
            _txtNumber.TabIndex = 2;
            _txtNumber.Tag = "Part.Number";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(160, 413);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(436, 176);
            _txtNotes.TabIndex = 19;
            _txtNotes.Tag = "Part.Notes";
            //
            // lblNotes
            //
            _lblNotes.Location = new Point(8, 413);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(57, 21);
            _lblNotes.TabIndex = 31;
            _lblNotes.Text = "Notes";
            //
            // tabSuppliers
            //
            _tabSuppliers.Controls.Add(_GroupBox1);
            _tabSuppliers.Location = new Point(4, 22);
            _tabSuppliers.Name = "tabSuppliers";
            _tabSuppliers.Size = new Size(624, 612);
            _tabSuppliers.TabIndex = 1;
            _tabSuppliers.Text = "Suppliers";
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_btnDelete);
            _GroupBox1.Controls.Add(_btnAdd);
            _GroupBox1.Controls.Add(_dgPartSuppliers);
            _GroupBox1.Location = new Point(8, 8);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(609, 595);
            _GroupBox1.TabIndex = 1;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Suppliers of this part";
            //
            // btnDelete
            //
            _btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDelete.Location = new Point(537, 563);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(64, 23);
            _btnDelete.TabIndex = 3;
            _btnDelete.Text = "Remove";
            //
            // btnAdd
            //
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAdd.Location = new Point(8, 563);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(64, 23);
            _btnAdd.TabIndex = 2;
            _btnAdd.Text = "Add";
            //
            // dgPartSuppliers
            //
            _dgPartSuppliers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dgPartSuppliers.DataMember = "";
            _dgPartSuppliers.HeaderForeColor = SystemColors.ControlText;
            _dgPartSuppliers.Location = new Point(8, 27);
            _dgPartSuppliers.Name = "dgPartSuppliers";
            _dgPartSuppliers.Size = new Size(593, 530);
            _dgPartSuppliers.TabIndex = 1;
            //
            // tpQuantities
            //
            _tpQuantities.Controls.Add(_GroupBox2);
            _tpQuantities.Location = new Point(4, 22);
            _tpQuantities.Name = "tpQuantities";
            _tpQuantities.Padding = new Padding(3);
            _tpQuantities.Size = new Size(624, 612);
            _tpQuantities.TabIndex = 3;
            _tpQuantities.Text = "Min / Max Quantities";
            _tpQuantities.UseVisualStyleBackColor = true;
            //
            // GroupBox2
            //
            _GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox2.Controls.Add(_dgQuantities);
            _GroupBox2.Location = new Point(8, 9);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(609, 595);
            _GroupBox2.TabIndex = 3;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Min /Max quantities held per location";
            //
            // dgQuantities
            //
            _dgQuantities.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgQuantities.DataMember = "";
            _dgQuantities.HeaderForeColor = SystemColors.ControlText;
            _dgQuantities.Location = new Point(8, 20);
            _dgQuantities.Name = "dgQuantities";
            _dgQuantities.Size = new Size(593, 569);
            _dgQuantities.TabIndex = 1;
            //
            // tpStock
            //
            _tpStock.Controls.Add(_grpStock);
            _tpStock.Location = new Point(4, 22);
            _tpStock.Name = "tpStock";
            _tpStock.Padding = new Padding(3);
            _tpStock.Size = new Size(624, 612);
            _tpStock.TabIndex = 2;
            _tpStock.Text = "Stock Locations";
            _tpStock.UseVisualStyleBackColor = true;
            //
            // grpStock
            //
            _grpStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpStock.Controls.Add(_dgStock);
            _grpStock.Location = new Point(8, 9);
            _grpStock.Name = "grpStock";
            _grpStock.Size = new Size(609, 595);
            _grpStock.TabIndex = 2;
            _grpStock.TabStop = false;
            _grpStock.Text = "Locations of this part";
            //
            // dgStock
            //
            _dgStock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgStock.DataMember = "";
            _dgStock.HeaderForeColor = SystemColors.ControlText;
            _dgStock.Location = new Point(8, 20);
            _dgStock.Name = "dgStock";
            _dgStock.Size = new Size(593, 569);
            _dgStock.TabIndex = 1;
            //
            // Label6
            //
            _Label6.Location = new Point(8, 181);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(121, 21);
            _Label6.TabIndex = 60;
            _Label6.Text = "Manufacturer";
            //
            // cboManufacturer
            //
            _cboManufacturer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboManufacturer.Location = new Point(160, 183);
            _cboManufacturer.Name = "cboManufacturer";
            _cboManufacturer.Size = new Size(436, 21);
            _cboManufacturer.TabIndex = 61;
            //
            // UCPart
            //
            Controls.Add(_TabControl1);
            Name = "UCPart";
            Size = new Size(640, 648);
            _TabControl1.ResumeLayout(false);
            _tabDetails.ResumeLayout(false);
            _grpPart.ResumeLayout(false);
            _grpPart.PerformLayout();
            _tabSuppliers.ResumeLayout(false);
            _GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgPartSuppliers).EndInit();
            _tpQuantities.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgQuantities).EndInit();
            _tpStock.ResumeLayout(false);
            _grpStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgStock).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
            SetupSuppliersDatagrid();
            SetupStockDatagrid();
            SetupQuantityDatagrid();
        }

        public object LoadedItem
        {
            get
            {
                return CurrentPart;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private bool _FromOrder;

        public bool FromOrder
        {
            get
            {
                return _FromOrder;
            }

            set
            {
                _FromOrder = value;
            }
        }

        private DataView _partSupplierDataview = null;

        public DataView PartSuppliersDataView
        {
            get
            {
                return _partSupplierDataview;
            }

            set
            {
                _partSupplierDataview = value;
                _partSupplierDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString();
                _partSupplierDataview.AllowNew = false;
                _partSupplierDataview.AllowEdit = true;
                _partSupplierDataview.AllowDelete = false;
                dgPartSuppliers.DataSource = PartSuppliersDataView;
            }
        }

        private DataRow SelectedPartSupplierDataRow
        {
            get
            {
                if (!(dgPartSuppliers.CurrentRowIndex == -1))
                {
                    return PartSuppliersDataView[dgPartSuppliers.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _StockDataview = null;

        public DataView StockDataview
        {
            get
            {
                return _StockDataview;
            }

            set
            {
                _StockDataview = value;
                _StockDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblStock.ToString();
                _StockDataview.AllowNew = false;
                _StockDataview.AllowEdit = true;
                _StockDataview.AllowDelete = false;
                dgStock.DataSource = StockDataview;
            }
        }

        private Entity.Parts.Part _currentPart;

        public Entity.Parts.Part CurrentPart
        {
            get
            {
                return _currentPart;
            }

            set
            {
                _currentPart = value;
                if (CurrentPart is null)
                {
                    CurrentPart = new Entity.Parts.Part();
                    CurrentPart.Exists = false;
                    btnAdd.Enabled = false;
                    btnDelete.Enabled = false;
                }

                if (CurrentPart.Exists)
                {
                    Populate();
                    btnAdd.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    // Bin = Nothing
                    // BinAlternative = Nothing
                    // Me.txtMinimumQuantity.Text = "0"
                    // Me.txtRecommendedQuantity.Text = "0"
                }

                PopulateSuppliers();
                PopulateStock();
                PopulateQuantities();
            }
        }

        private DataView _partQuantitiesDataview = null;

        public DataView PartQuantitiesDataview
        {
            get
            {
                return _partQuantitiesDataview;
            }

            set
            {
                _partQuantitiesDataview = value;
                _partQuantitiesDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString();
                _partQuantitiesDataview.AllowNew = false;
                _partQuantitiesDataview.AllowEdit = true;
                _partQuantitiesDataview.AllowDelete = false;
                dgQuantities.DataSource = PartQuantitiesDataview;
            }
        }

        private DataRow SelectedPartQuantityDataRow
        {
            get
            {
                if (!(dgQuantities.CurrentRowIndex == -1))
                {
                    return PartQuantitiesDataview[dgQuantities.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        // Private _Bin As Entity.PickLists.PickList
        // Public Property Bin() As Entity.PickLists.PickList
        // Get
        // Return _Bin
        // End Get
        // Set(ByVal Value As Entity.PickLists.PickList)
        // _Bin = Value

        // If Bin Is Nothing Then
        // Me.txtBin.Text = "Not Applicable"
        // Else
        // Me.txtBin.Text = Bin.Name
        // End If
        // End Set
        // End Property

        // Private _BinAlternative As Entity.PickLists.PickList
        // Public Property BinAlternative() As Entity.PickLists.PickList
        // Get
        // Return _BinAlternative
        // End Get
        // Set(ByVal Value As Entity.PickLists.PickList)
        // _BinAlternative = Value

        // If BinAlternative Is Nothing Then
        // Me.txtBinAlternative.Text = "Not Applicable"
        // Else
        // Me.txtBinAlternative.Text = BinAlternative.Name
        // End If
        // End Set
        // End Property

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupSuppliersDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgPartSuppliers);
            var tStyle = dgPartSuppliers.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgPartSuppliers.ReadOnly = false;
            dgPartSuppliers.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Preferred = new DataGridBoolColumn();
            Preferred.HeaderText = "Preferred";
            Preferred.MappingName = "Preferred";
            Preferred.ReadOnly = false;
            Preferred.Width = 25;
            Preferred.NullText = "";
            tStyle.GridColumnStyles.Add(Preferred);
            var SupplierName = new DataGridLabelColumn();
            SupplierName.Format = "";
            SupplierName.FormatInfo = null;
            SupplierName.HeaderText = "Supplier";
            SupplierName.MappingName = "SupplierName";
            SupplierName.ReadOnly = true;
            SupplierName.Width = 130;
            SupplierName.NullText = "";
            tStyle.GridColumnStyles.Add(SupplierName);
            var PartCode = new DataGridLabelColumn();
            PartCode.Format = "";
            PartCode.FormatInfo = null;
            PartCode.HeaderText = "Supplier Part Code (SPN)";
            PartCode.MappingName = "PartCode";
            PartCode.ReadOnly = true;
            PartCode.Width = 130;
            PartCode.NullText = "";
            tStyle.GridColumnStyles.Add(PartCode);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Supplier Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 85;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var QuantityInPack = new DataGridLabelColumn();
            QuantityInPack.Format = "";
            QuantityInPack.FormatInfo = null;
            QuantityInPack.HeaderText = "Quantity In Pack";
            QuantityInPack.MappingName = "QuantityInPack";
            QuantityInPack.ReadOnly = true;
            QuantityInPack.Width = 110;
            QuantityInPack.NullText = "";
            tStyle.GridColumnStyles.Add(QuantityInPack);
            var UpdatedBy = new DataGridLabelColumn();
            UpdatedBy.Format = "";
            UpdatedBy.FormatInfo = null;
            UpdatedBy.HeaderText = "Updated By";
            UpdatedBy.MappingName = "UpdatedBy";
            UpdatedBy.ReadOnly = true;
            UpdatedBy.Width = 150;
            UpdatedBy.NullText = "";
            tStyle.GridColumnStyles.Add(UpdatedBy);
            var UpdatedOn = new DataGridLabelColumn();
            UpdatedOn.Format = "dd/MM/yyyy HH:mm:ss";
            UpdatedOn.FormatInfo = null;
            UpdatedOn.HeaderText = "Updated On";
            UpdatedOn.MappingName = "UpdatedOn";
            UpdatedOn.ReadOnly = true;
            UpdatedOn.Width = 150;
            UpdatedOn.NullText = "";
            tStyle.GridColumnStyles.Add(UpdatedOn);
            var primaryPriceUpdated = new DataGridLabelColumn();
            primaryPriceUpdated.Format = "dd/MM/yyyy";
            primaryPriceUpdated.FormatInfo = null;
            primaryPriceUpdated.HeaderText = "Primary Price Updated On";
            primaryPriceUpdated.MappingName = "PrimaryPriceUpdateDateTime";
            primaryPriceUpdated.ReadOnly = true;
            primaryPriceUpdated.Width = 150;
            primaryPriceUpdated.NullText = "";
            tStyle.GridColumnStyles.Add(primaryPriceUpdated);
            var secondaryPriceUpdated = new DataGridLabelColumn();
            secondaryPriceUpdated.Format = "dd/MM/yyyy";
            secondaryPriceUpdated.FormatInfo = null;
            secondaryPriceUpdated.HeaderText = "Secondary Price Updated On";
            secondaryPriceUpdated.MappingName = "SecondaryPriceUpdateDateTime";
            secondaryPriceUpdated.ReadOnly = true;
            secondaryPriceUpdated.Width = 150;
            secondaryPriceUpdated.NullText = "";
            tStyle.GridColumnStyles.Add(secondaryPriceUpdated);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartSupplier.ToString();
            dgPartSuppliers.TableStyles.Add(tStyle);
        }

        public void SetupStockDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgStock);
            var tStyle = dgStock.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 100;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 200;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var Qty = new DataGridLabelColumn();
            Qty.Format = "";
            Qty.FormatInfo = null;
            Qty.HeaderText = "Qty";
            Qty.MappingName = "Quantity";
            Qty.ReadOnly = true;
            Qty.Width = 100;
            Qty.NullText = "";
            tStyle.GridColumnStyles.Add(Qty);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblStock.ToString();
            dgStock.TableStyles.Add(tStyle);
        }

        public void SetupQuantityDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgQuantities);
            var tStyle = dgQuantities.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.ReadOnly = false;
            tStyle.AllowSorting = false;
            dgQuantities.AllowSorting = false;
            dgQuantities.ReadOnly = false;
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 250;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var MinQty = new DataGridEditableTextBoxColumn();
            MinQty.Format = "";
            MinQty.FormatInfo = null;
            MinQty.HeaderText = "Minimum";
            MinQty.MappingName = "MinQty";
            MinQty.ReadOnly = false;
            MinQty.Width = 75;
            MinQty.NullText = "";
            MinQty.BackColourBrush = Brushes.LightYellow;
            tStyle.GridColumnStyles.Add(MinQty);
            var RecQty = new DataGridEditableTextBoxColumn();
            RecQty.Format = "";
            RecQty.FormatInfo = null;
            RecQty.HeaderText = "Maximum";
            RecQty.MappingName = "RecQty";
            RecQty.ReadOnly = false;
            RecQty.Width = 75;
            RecQty.NullText = "";
            RecQty.BackColourBrush = Brushes.LightYellow;
            tStyle.GridColumnStyles.Add(RecQty);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblPartLocations.ToString();
            dgQuantities.TableStyles.Add(tStyle);
        }

        private void UCPart_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgPartSuppliers_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgPartSuppliers.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgPartSuppliers.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedPartSupplierDataRow is null)
                {
                    return;
                }

                bool selected = !Entity.Sys.Helper.MakeBooleanValid(dgPartSuppliers[dgPartSuppliers.CurrentRowIndex, 0]);
                App.DB.PartSupplier.Update_Preferred(Conversions.ToInteger(SelectedPartSupplierDataRow["PartSupplierID"]), selected);
                PartSuppliersDataView = App.DB.PartSupplier.Get_ByPartID(CurrentPart.PartID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgPartSuppliers_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedPartSupplierDataRow is null)
            {
                return;
            }

            App.ShowForm(typeof(FRMPartSupplier), true, new object[] { Entity.Sys.Helper.MakeIntegerValid(SelectedPartSupplierDataRow["PartSupplierID"]), CurrentPart.PartID, this });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Entity.Sys.Enums.SecuritySystemModules ssm;
            ssm = Entity.Sys.Enums.SecuritySystemModules.EditParts;
            Entity.Sys.Enums.SecuritySystemModules ssm2;
            ssm2 = Entity.Sys.Enums.SecuritySystemModules.CreateParts;
            if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
                App.ShowForm(typeof(FRMPartSupplier), true, new object[] { 0, CurrentPart.PartID, this });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedPartSupplierDataRow is null)
            {
                App.ShowMessage("Please select a supplier to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Entity.Sys.Enums.SecuritySystemModules ssm;
            ssm = Entity.Sys.Enums.SecuritySystemModules.EditParts;
            Entity.Sys.Enums.SecuritySystemModules ssm2;
            ssm2 = Entity.Sys.Enums.SecuritySystemModules.CreateParts;
            if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
            {
                // If EnterOverridePassword() = True Then
                // Check if part is on an order i.e in tblOrderPart
                int OrderedCount = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("SELECT COUNT(*) AS Expr1 FROM tblOrderPart WHERE (PartSupplierID = " + SelectedPartSupplierDataRow["PartSupplierID"] + ") AND (EngineerReceivedOn IS NULL) AND (Deleted = 0)")));
                // If OrderedCount > 0 Then
                // If ShowMessage("This part has been ordered and not received by an engineer and therefore cannot be deleted", MessageBoxButtons.OK, MessageBoxIcon.Information) = DialogResult.OK Then
                // Exit Sub
                // Else
                // Exit Sub
                // End If
                // End If
                if (App.ShowMessage("Are you sure you want to delete the selected record?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                App.DB.PartSupplier.Delete(Entity.Sys.Helper.MakeIntegerValid(SelectedPartSupplierDataRow["PartSupplierID"]));
                PartSuppliersDataView = App.DB.PartSupplier.Get_ByPartID(CurrentPart.PartID);
            }
            // End If
            else
            {
                string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
                return;
            }
        }

        // Private Sub btnBin_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        // Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN)
        // If ID = 0 Then
        // Bin = Nothing
        // Else
        // Bin = DB.Picklists.Get_One_As_Object(ID)
        // End If
        // End Sub

        // Private Sub btnBinAlternative_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        // Dim ID As Integer = FindRecord(Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_tblPicklists_BIN)
        // If ID = 0 Then
        // BinAlternative = Nothing
        // Else
        // BinAlternative = DB.Picklists.Get_One_As_Object(ID)
        // End If
        // End Sub

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void PopulateSuppliers()
        {
            PartSuppliersDataView = App.DB.PartSupplier.Get_ByPartID(CurrentPart.PartID);
        }

        public void PopulateStock()
        {
            StockDataview = App.DB.Part.Stock_Get_Locations(CurrentPart.PartID);
        }

        public void PopulateQuantities()
        {
            PartQuantitiesDataview = App.DB.Part.Part_Locations_Get(CurrentPart.PartID);
        }

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentPart = App.DB.Part.Part_Get(ID);
            }

            txtName.Text = CurrentPart.Name;
            txtNumber.Text = CurrentPart.Number;
            txtReference.Text = CurrentPart.Reference;
            txtNotes.Text = CurrentPart.Notes;
            // Me.txtMinimumQuantity.Text = CurrentPart.MinimumQuantity
            // Me.txtRecommendedQuantity.Text = CurrentPart.RecommendedQuantity
            // Me.txtWarehouseQuantity.Text = CurrentPart.WarehouseQuantity
            txtSellPrice.Text = CurrentPart.SellPrice.ToString();
            var argcombo = cboUnitType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentPart.UnitTypeID.ToString());
            var argcombo1 = cboCategory;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentPart.CategoryID.ToString());
            var argcombo2 = cboFuel;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentPart.FuelID.ToString());
            var argcombo3 = cboManufacturer;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentPart.MakeID.ToString());
            // Combo.SetSel  Combo.SetSelectedComboItem_By_Value(Me.cboCategory, CurrentPart.CategoryID)ectedComboItem_By_Value(Me.cboWarehouse, CurrentPart.WarehouseID)
            // Combo.SetSelectedComboItem_By_Value(Me.choShelf, CurrentPart.ShelfID)
            // If CurrentPart.BinID = 0 Then
            // Bin = Nothing
            // Else
            // Bin = DB.Picklists.Get_One_As_Object(CurrentPart.BinID)
            // End If
            // Combo.SetSelectedComboItem_By_Value(Me.cboBinID, CurrentPart.BinID)
            // Combo.SetSelectedComboItem_By_Value(Me.cboWarehouseAlternative, CurrentPart.WarehouseIDAlternative)
            // Combo.SetSelectedComboItem_By_Value(Me.cboShelfAlternatuve, CurrentPart.ShelfIDAlternative)
            // If CurrentPart.BinIDAlternative = 0 Then
            // BinAlternative = Nothing
            // Else
            // BinAlternative = DB.Picklists.Get_One_As_Object(CurrentPart.BinIDAlternative)
            // End If
            // Combo.SetSelectedComboItem_By_Value(Me.cboBinAlternatuve, CurrentPart.BinIDAlternative)
            chkEndFlagged.Checked = CurrentPart.EndFlagged;
            // Me.chkEquipment.Checked = CurrentPart.Equipment
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                bool PerformSave = false;
                Entity.Sys.Enums.SecuritySystemModules ssm;
                ssm = Entity.Sys.Enums.SecuritySystemModules.EditParts;
                Entity.Sys.Enums.SecuritySystemModules ssm2;
                ssm2 = Entity.Sys.Enums.SecuritySystemModules.CreateParts;
                if (App.loggedInUser.HasAccessToModule(ssm) == true | App.loggedInUser.HasAccessToModule(ssm2) == true)
                {
                    PerformSave = true;
                }
                else
                {
                    string msg = "You do not have the necessary security permissions to access this feature." + Constants.vbCrLf;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                    return false;
                }

                if (PerformSave)
                {
                    Cursor = Cursors.WaitCursor;
                    CurrentPart.IgnoreExceptionsOnSetMethods = true;
                    CurrentPart.SetName = txtName.Text.Trim();
                    CurrentPart.SetNumber = txtNumber.Text.Trim();
                    CurrentPart.SetReference = txtReference.Text.Trim();
                    CurrentPart.SetNotes = txtNotes.Text.Trim();
                    CurrentPart.SetUnitTypeID = Combo.get_GetSelectedItemValue(cboUnitType);
                    CurrentPart.SetSellPrice = txtSellPrice.Text.Trim();
                    // CurrentPart.SetMinimumQuantity = Me.txtMinimumQuantity.Text.Trim
                    // CurrentPart.SetRecommendedQuantity = Me.txtRecommendedQuantity.Text.Trim
                    CurrentPart.SetCategoryID = Combo.get_GetSelectedItemValue(cboCategory);
                    CurrentPart.SetMakeID = Combo.get_GetSelectedItemValue(cboManufacturer);
                    CurrentPart.SetFuelID = Combo.get_GetSelectedItemValue(cboFuel);
                    // CurrentPart.SetWarehouseID = Combo.GetSelectedItemValue(Me.cboWarehouse)
                    // CurrentPart.SetShelfID = Combo.GetSelectedItemValue(Me.choShelf)
                    // If Bin Is Nothing Then
                    // CurrentPart.SetBinID = 0
                    // Else
                    // CurrentPart.SetBinID = Bin.ManagerID
                    // End If
                    // CurrentPart.SetBinID = Combo.GetSelectedItemValue(Me.cboBinID)
                    // CurrentPart.SetWarehouseIDAlternative = Combo.GetSelectedItemValue(Me.cboWarehouseAlternative)
                    // CurrentPart.SetShelfIDAlternative = Combo.GetSelectedItemValue(Me.cboShelfAlternatuve)
                    // If BinAlternative Is Nothing Then
                    // CurrentPart.SetBinIDAlternative = 0
                    // Else
                    // CurrentPart.SetBinIDAlternative = BinAlternative.ManagerID
                    // End If
                    // CurrentPart.SetBinIDAlternative = Combo.GetSelectedItemValue(Me.cboBinAlternatuve)
                    CurrentPart.SetEndFlagged = chkEndFlagged.Checked;

                    // CurrentPart.SetEquipment = Me.chkEquipment.Checked

                    var cV = new Entity.Parts.PartValidator();
                    cV.Validate(CurrentPart);
                    if (CurrentPart.Exists)
                    {
                        App.DB.Part.Update(CurrentPart);
                        App.DB.Part.Part_Locations_Update(CurrentPart.PartID, PartQuantitiesDataview);
                        App.DB.Picklists.UpdateSellPricesByPart(CurrentPart.CategoryID, CurrentPart.PartID);
                    }
                    else
                    {
                        CurrentPart = App.DB.Part.Insert(CurrentPart);
                    }

                    if (FromOrder == false)
                    {
                        // RaiseEvent RecordsChanged(DB.Part.Part_GetAll(), Entity.Sys.Enums.PageViewing.Part, True, False, "")    --- RD
                        // MainForm.RefreshEntity(CurrentPart.PartID)
                    }

                    StateChanged?.Invoke(CurrentPart.PartID);
                    return true;
                }
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

            return default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}