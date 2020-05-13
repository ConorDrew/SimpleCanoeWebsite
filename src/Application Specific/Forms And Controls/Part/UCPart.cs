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
        public UCPart() : base()
        {
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

        private GroupBox _grpPart;

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

        private GroupBox _grpStock;

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

        private TabPage _tpQuantities;

        private GroupBox _GroupBox2;

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
        internal ComboBox cboNominals;
        internal Label lblNominal;

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._TabControl1 = new System.Windows.Forms.TabControl();
            this._tabDetails = new System.Windows.Forms.TabPage();
            this._grpPart = new System.Windows.Forms.GroupBox();
            this._cboManufacturer = new System.Windows.Forms.ComboBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._cboFuel = new System.Windows.Forms.ComboBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._chkEndFlagged = new System.Windows.Forms.CheckBox();
            this._Label14 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._cboCategory = new System.Windows.Forms.ComboBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._txtReference = new System.Windows.Forms.TextBox();
            this._txtSellPrice = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._cboUnitType = new System.Windows.Forms.ComboBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtNumber = new System.Windows.Forms.TextBox();
            this._txtNotes = new System.Windows.Forms.TextBox();
            this._lblNotes = new System.Windows.Forms.Label();
            this._tabSuppliers = new System.Windows.Forms.TabPage();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._dgPartSuppliers = new System.Windows.Forms.DataGrid();
            this._tpQuantities = new System.Windows.Forms.TabPage();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._dgQuantities = new System.Windows.Forms.DataGrid();
            this._tpStock = new System.Windows.Forms.TabPage();
            this._grpStock = new System.Windows.Forms.GroupBox();
            this._dgStock = new System.Windows.Forms.DataGrid();
            this.cboNominals = new System.Windows.Forms.ComboBox();
            this.lblNominal = new System.Windows.Forms.Label();
            this._TabControl1.SuspendLayout();
            this._tabDetails.SuspendLayout();
            this._grpPart.SuspendLayout();
            this._tabSuppliers.SuspendLayout();
            this._GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgPartSuppliers)).BeginInit();
            this._tpQuantities.SuspendLayout();
            this._GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgQuantities)).BeginInit();
            this._tpStock.SuspendLayout();
            this._grpStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgStock)).BeginInit();
            this.SuspendLayout();
            //
            // _TabControl1
            //
            this._TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TabControl1.Controls.Add(this._tabDetails);
            this._TabControl1.Controls.Add(this._tabSuppliers);
            this._TabControl1.Controls.Add(this._tpQuantities);
            this._TabControl1.Controls.Add(this._tpStock);
            this._TabControl1.Location = new System.Drawing.Point(1, 5);
            this._TabControl1.Name = "_TabControl1";
            this._TabControl1.SelectedIndex = 0;
            this._TabControl1.Size = new System.Drawing.Size(632, 638);
            this._TabControl1.TabIndex = 0;
            //
            // _tabDetails
            //
            this._tabDetails.Controls.Add(this._grpPart);
            this._tabDetails.Location = new System.Drawing.Point(4, 22);
            this._tabDetails.Name = "_tabDetails";
            this._tabDetails.Size = new System.Drawing.Size(624, 612);
            this._tabDetails.TabIndex = 0;
            this._tabDetails.Text = "Main Details";
            //
            // _grpPart
            //
            this._grpPart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpPart.Controls.Add(this.cboNominals);
            this._grpPart.Controls.Add(this.lblNominal);
            this._grpPart.Controls.Add(this._cboManufacturer);
            this._grpPart.Controls.Add(this._Label6);
            this._grpPart.Controls.Add(this._cboFuel);
            this._grpPart.Controls.Add(this._Label5);
            this._grpPart.Controls.Add(this._chkEndFlagged);
            this._grpPart.Controls.Add(this._Label14);
            this._grpPart.Controls.Add(this._Label8);
            this._grpPart.Controls.Add(this._cboCategory);
            this._grpPart.Controls.Add(this._Label7);
            this._grpPart.Controls.Add(this._txtReference);
            this._grpPart.Controls.Add(this._txtSellPrice);
            this._grpPart.Controls.Add(this._Label4);
            this._grpPart.Controls.Add(this._cboUnitType);
            this._grpPart.Controls.Add(this._Label3);
            this._grpPart.Controls.Add(this._Label2);
            this._grpPart.Controls.Add(this._Label1);
            this._grpPart.Controls.Add(this._txtName);
            this._grpPart.Controls.Add(this._txtNumber);
            this._grpPart.Controls.Add(this._txtNotes);
            this._grpPart.Controls.Add(this._lblNotes);
            this._grpPart.Location = new System.Drawing.Point(8, 8);
            this._grpPart.Name = "_grpPart";
            this._grpPart.Size = new System.Drawing.Size(609, 595);
            this._grpPart.TabIndex = 0;
            this._grpPart.TabStop = false;
            this._grpPart.Text = "Main Details";
            //
            // _cboManufacturer
            //
            this._cboManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboManufacturer.Location = new System.Drawing.Point(160, 183);
            this._cboManufacturer.Name = "_cboManufacturer";
            this._cboManufacturer.Size = new System.Drawing.Size(436, 21);
            this._cboManufacturer.TabIndex = 61;
            //
            // _Label6
            //
            this._Label6.Location = new System.Drawing.Point(8, 181);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(121, 21);
            this._Label6.TabIndex = 60;
            this._Label6.Text = "Manufacturer";
            //
            // _cboFuel
            //
            this._cboFuel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboFuel.Location = new System.Drawing.Point(160, 213);
            this._cboFuel.Name = "_cboFuel";
            this._cboFuel.Size = new System.Drawing.Size(436, 21);
            this._cboFuel.TabIndex = 57;
            //
            // _Label5
            //
            this._Label5.Location = new System.Drawing.Point(8, 212);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(62, 23);
            this._Label5.TabIndex = 58;
            this._Label5.Text = "Fuel";
            //
            // _chkEndFlagged
            //
            this._chkEndFlagged.Location = new System.Drawing.Point(160, 356);
            this._chkEndFlagged.Name = "_chkEndFlagged";
            this._chkEndFlagged.Size = new System.Drawing.Size(92, 24);
            this._chkEndFlagged.TabIndex = 17;
            this._chkEndFlagged.UseVisualStyleBackColor = true;
            //
            // _Label14
            //
            this._Label14.Location = new System.Drawing.Point(8, 356);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(152, 24);
            this._Label14.TabIndex = 56;
            this._Label14.Text = "End Flagged";
            //
            // _Label8
            //
            this._Label8.Location = new System.Drawing.Point(8, 56);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(64, 21);
            this._Label8.TabIndex = 44;
            this._Label8.Text = "Category";
            //
            // _cboCategory
            //
            this._cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboCategory.Location = new System.Drawing.Point(160, 57);
            this._cboCategory.Name = "_cboCategory";
            this._cboCategory.Size = new System.Drawing.Size(436, 21);
            this._cboCategory.TabIndex = 1;
            //
            // _Label7
            //
            this._Label7.Location = new System.Drawing.Point(8, 120);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(109, 21);
            this._Label7.TabIndex = 42;
            this._Label7.Text = "Reference (GPN)";
            //
            // _txtReference
            //
            this._txtReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtReference.Location = new System.Drawing.Point(160, 120);
            this._txtReference.MaxLength = 100;
            this._txtReference.Name = "_txtReference";
            this._txtReference.Size = new System.Drawing.Size(436, 21);
            this._txtReference.TabIndex = 3;
            this._txtReference.Tag = "Part.Reference";
            //
            // _txtSellPrice
            //
            this._txtSellPrice.Location = new System.Drawing.Point(160, 324);
            this._txtSellPrice.Name = "_txtSellPrice";
            this._txtSellPrice.Size = new System.Drawing.Size(104, 21);
            this._txtSellPrice.TabIndex = 13;
            //
            // _Label4
            //
            this._Label4.Location = new System.Drawing.Point(8, 323);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(63, 23);
            this._Label4.TabIndex = 36;
            this._Label4.Text = "Sell Price";
            //
            // _cboUnitType
            //
            this._cboUnitType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboUnitType.Location = new System.Drawing.Point(160, 153);
            this._cboUnitType.Name = "_cboUnitType";
            this._cboUnitType.Size = new System.Drawing.Size(436, 21);
            this._cboUnitType.TabIndex = 4;
            //
            // _Label3
            //
            this._Label3.Location = new System.Drawing.Point(8, 152);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(62, 23);
            this._Label3.TabIndex = 34;
            this._Label3.Text = "Unit Type";
            //
            // _Label2
            //
            this._Label2.Location = new System.Drawing.Point(8, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(57, 21);
            this._Label2.TabIndex = 33;
            this._Label2.Text = "Name";
            //
            // _Label1
            //
            this._Label1.Location = new System.Drawing.Point(8, 88);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(100, 21);
            this._Label1.TabIndex = 32;
            this._Label1.Text = "Number (MPN)";
            //
            // _txtName
            //
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Location = new System.Drawing.Point(160, 26);
            this._txtName.MaxLength = 255;
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(436, 21);
            this._txtName.TabIndex = 0;
            this._txtName.Tag = "Part.Name";
            //
            // _txtNumber
            //
            this._txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNumber.Location = new System.Drawing.Point(160, 89);
            this._txtNumber.MaxLength = 100;
            this._txtNumber.Name = "_txtNumber";
            this._txtNumber.Size = new System.Drawing.Size(436, 21);
            this._txtNumber.TabIndex = 2;
            this._txtNumber.Tag = "Part.Number";
            //
            // _txtNotes
            //
            this._txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNotes.Location = new System.Drawing.Point(160, 413);
            this._txtNotes.Multiline = true;
            this._txtNotes.Name = "_txtNotes";
            this._txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtNotes.Size = new System.Drawing.Size(436, 176);
            this._txtNotes.TabIndex = 19;
            this._txtNotes.Tag = "Part.Notes";
            //
            // _lblNotes
            //
            this._lblNotes.Location = new System.Drawing.Point(8, 413);
            this._lblNotes.Name = "_lblNotes";
            this._lblNotes.Size = new System.Drawing.Size(57, 21);
            this._lblNotes.TabIndex = 31;
            this._lblNotes.Text = "Notes";
            //
            // _tabSuppliers
            //
            this._tabSuppliers.Controls.Add(this._GroupBox1);
            this._tabSuppliers.Location = new System.Drawing.Point(4, 22);
            this._tabSuppliers.Name = "_tabSuppliers";
            this._tabSuppliers.Size = new System.Drawing.Size(624, 612);
            this._tabSuppliers.TabIndex = 1;
            this._tabSuppliers.Text = "Suppliers";
            //
            // _GroupBox1
            //
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._btnDelete);
            this._GroupBox1.Controls.Add(this._btnAdd);
            this._GroupBox1.Controls.Add(this._dgPartSuppliers);
            this._GroupBox1.Location = new System.Drawing.Point(8, 8);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(609, 595);
            this._GroupBox1.TabIndex = 1;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Suppliers of this part";
            //
            // _btnDelete
            //
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDelete.Location = new System.Drawing.Point(537, 563);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(64, 23);
            this._btnDelete.TabIndex = 3;
            this._btnDelete.Text = "Remove";
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // _btnAdd
            //
            this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAdd.Location = new System.Drawing.Point(8, 563);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(64, 23);
            this._btnAdd.TabIndex = 2;
            this._btnAdd.Text = "Add";
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // _dgPartSuppliers
            //
            this._dgPartSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgPartSuppliers.DataMember = "";
            this._dgPartSuppliers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgPartSuppliers.Location = new System.Drawing.Point(8, 27);
            this._dgPartSuppliers.Name = "_dgPartSuppliers";
            this._dgPartSuppliers.Size = new System.Drawing.Size(593, 530);
            this._dgPartSuppliers.TabIndex = 1;
            this._dgPartSuppliers.DoubleClick += new System.EventHandler(this.dgPartSuppliers_DoubleClick);
            this._dgPartSuppliers.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgPartSuppliers_MouseUp);
            //
            // _tpQuantities
            //
            this._tpQuantities.Controls.Add(this._GroupBox2);
            this._tpQuantities.Location = new System.Drawing.Point(4, 22);
            this._tpQuantities.Name = "_tpQuantities";
            this._tpQuantities.Padding = new System.Windows.Forms.Padding(3);
            this._tpQuantities.Size = new System.Drawing.Size(624, 612);
            this._tpQuantities.TabIndex = 3;
            this._tpQuantities.Text = "Min / Max Quantities";
            this._tpQuantities.UseVisualStyleBackColor = true;
            //
            // _GroupBox2
            //
            this._GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox2.Controls.Add(this._dgQuantities);
            this._GroupBox2.Location = new System.Drawing.Point(8, 9);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(609, 595);
            this._GroupBox2.TabIndex = 3;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Min /Max quantities held per location";
            //
            // _dgQuantities
            //
            this._dgQuantities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgQuantities.DataMember = "";
            this._dgQuantities.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgQuantities.Location = new System.Drawing.Point(8, 20);
            this._dgQuantities.Name = "_dgQuantities";
            this._dgQuantities.Size = new System.Drawing.Size(593, 569);
            this._dgQuantities.TabIndex = 1;
            //
            // _tpStock
            //
            this._tpStock.Controls.Add(this._grpStock);
            this._tpStock.Location = new System.Drawing.Point(4, 22);
            this._tpStock.Name = "_tpStock";
            this._tpStock.Padding = new System.Windows.Forms.Padding(3);
            this._tpStock.Size = new System.Drawing.Size(624, 612);
            this._tpStock.TabIndex = 2;
            this._tpStock.Text = "Stock Locations";
            this._tpStock.UseVisualStyleBackColor = true;
            //
            // _grpStock
            //
            this._grpStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpStock.Controls.Add(this._dgStock);
            this._grpStock.Location = new System.Drawing.Point(8, 9);
            this._grpStock.Name = "_grpStock";
            this._grpStock.Size = new System.Drawing.Size(609, 595);
            this._grpStock.TabIndex = 2;
            this._grpStock.TabStop = false;
            this._grpStock.Text = "Locations of this part";
            //
            // _dgStock
            //
            this._dgStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgStock.DataMember = "";
            this._dgStock.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgStock.Location = new System.Drawing.Point(8, 20);
            this._dgStock.Name = "_dgStock";
            this._dgStock.Size = new System.Drawing.Size(593, 569);
            this._dgStock.TabIndex = 1;
            //
            // cboNominals
            //
            this.cboNominals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNominals.Location = new System.Drawing.Point(160, 244);
            this.cboNominals.Name = "cboNominals";
            this.cboNominals.Size = new System.Drawing.Size(436, 21);
            this.cboNominals.TabIndex = 66;
            //
            // lblNominal
            //
            this.lblNominal.AutoSize = true;
            this.lblNominal.Location = new System.Drawing.Point(8, 247);
            this.lblNominal.Name = "lblNominal";
            this.lblNominal.Size = new System.Drawing.Size(53, 13);
            this.lblNominal.TabIndex = 65;
            this.lblNominal.Text = "Nominal";
            //
            // UCPart
            //
            this.Controls.Add(this._TabControl1);
            this.Name = "UCPart";
            this.Size = new System.Drawing.Size(640, 648);
            this._TabControl1.ResumeLayout(false);
            this._tabDetails.ResumeLayout(false);
            this._grpPart.ResumeLayout(false);
            this._grpPart.PerformLayout();
            this._tabSuppliers.ResumeLayout(false);
            this._GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgPartSuppliers)).EndInit();
            this._tpQuantities.ResumeLayout(false);
            this._GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgQuantities)).EndInit();
            this._tpStock.ResumeLayout(false);
            this._grpStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgStock)).EndInit();
            this.ResumeLayout(false);
        }

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
                int OrderedCount = Conversions.ToInteger(App.DB.ExecuteScalar(Conversions.ToString("SELECT COUNT(*) AS Expr1 FROM tblOrderPart WHERE (PartSupplierID = " + SelectedPartSupplierDataRow["PartSupplierID"] + ") AND (EngineerReceivedOn IS NULL) AND (Deleted = 0)")));

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

            txtSellPrice.Text = CurrentPart.SellPrice.ToString();
            var argcombo = cboUnitType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentPart.UnitTypeID.ToString());
            var argcombo1 = cboCategory;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentPart.CategoryID.ToString());
            var argcombo2 = cboFuel;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentPart.FuelID.ToString());
            var argcombo3 = cboManufacturer;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentPart.MakeID.ToString());
            var argcombo4 = cboNominals;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, CurrentPart.NominalID.ToString());

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
                    CurrentPart.SetCategoryID = Combo.get_GetSelectedItemValue(cboCategory);
                    CurrentPart.SetMakeID = Combo.get_GetSelectedItemValue(cboManufacturer);
                    CurrentPart.SetFuelID = Combo.get_GetSelectedItemValue(cboFuel);
                    CurrentPart.SetNominalID = FSM.Combo.get_GetSelectedItemValue(cboNominals);
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
    }
}