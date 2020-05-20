using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMConvertToAnOrder : FRMBaseForm, IForm
    {
        public FRMConvertToAnOrder(System.Data.SqlClient.SqlTransaction trans) : base()
        {
            base.Load += FRMConvertToAnOrder_Load;
            Trans = trans;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
        }

        public FRMConvertToAnOrder() : base()
        {
            base.Load += FRMConvertToAnOrder_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboChargeType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.OrderChargeTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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
        private GroupBox _grpJob;

        internal GroupBox grpJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJob != null)
                {
                }

                _grpJob = value;
                if (_grpJob != null)
                {
                }
            }
        }

        private DataGrid _dgEngineerVisits;

        internal DataGrid dgEngineerVisits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgEngineerVisits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgEngineerVisits != null)
                {
                }

                _dgEngineerVisits = value;
                if (_dgEngineerVisits != null)
                {
                }
            }
        }

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
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

        private GroupBox _grpPartsAndProducts;

        internal GroupBox grpPartsAndProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPartsAndProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPartsAndProducts != null)
                {
                }

                _grpPartsAndProducts = value;
                if (_grpPartsAndProducts != null)
                {
                }
            }
        }

        private DataGrid _dgPartsAndProducts;

        internal DataGrid dgPartsAndProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartsAndProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartsAndProducts != null)
                {
                    _dgPartsAndProducts.CurrentCellChanged -= dgPartsAndProducts_CurrentCellChanged;
                }

                _dgPartsAndProducts = value;
                if (_dgPartsAndProducts != null)
                {
                    _dgPartsAndProducts.CurrentCellChanged += dgPartsAndProducts_CurrentCellChanged;
                }
            }
        }

        private Button _btnAddProduct;

        private Button _btnAddPart;

        private Label _lblinformation;

        internal Label lblinformation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblinformation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblinformation != null)
                {
                }

                _lblinformation = value;
                if (_lblinformation != null)
                {
                }
            }
        }

        private CheckBox _chkAwaiting;

        internal CheckBox chkAwaiting
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkAwaiting;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkAwaiting != null)
                {
                    _chkAwaiting.CheckedChanged -= chkAwaiting_CheckedChanged;
                }

                _chkAwaiting = value;
                if (_chkAwaiting != null)
                {
                    _chkAwaiting.CheckedChanged += chkAwaiting_CheckedChanged;
                }
            }
        }

        private CheckBox _chkConfirmed;

        internal CheckBox chkConfirmed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkConfirmed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkConfirmed != null)
                {
                    _chkConfirmed.CheckedChanged -= chkConfirmed_CheckedChanged;
                }

                _chkConfirmed = value;
                if (_chkConfirmed != null)
                {
                    _chkConfirmed.CheckedChanged += chkConfirmed_CheckedChanged;
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

        private DateTimePicker _dtpDeadline;

        internal DateTimePicker dtpDeadline
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDeadline;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDeadline != null)
                {
                }

                _dtpDeadline = value;
                if (_dtpDeadline != null)
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

        private TabControl _TabControl1;

        private TabPage _TabPage1;

        private TabPage _TabPage2;

        private GroupBox _grpCharges;

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

        private Button _btnChargesSave;

        private TextBox _txtAmount;

        internal TextBox txtAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAmount != null)
                {
                }

                _txtAmount = value;
                if (_txtAmount != null)
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

        private ComboBox _cboChargeType;

        internal ComboBox cboChargeType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboChargeType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboChargeType != null)
                {
                }

                _cboChargeType = value;
                if (_cboChargeType != null)
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

        private DataGrid _dgCharges;

        internal DataGrid dgCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCharges != null)
                {
                    _dgCharges.Click -= dgCharges_Click;
                    _dgCharges.CurrentCellChanged -= dgCharges_Click;
                }

                _dgCharges = value;
                if (_dgCharges != null)
                {
                    _dgCharges.Click += dgCharges_Click;
                    _dgCharges.CurrentCellChanged += dgCharges_Click;
                }
            }
        }

        private Button _btnExport;

        private Label _Label17;

        private TextBox _txtDepartment;

        internal TextBox txtDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDepartment != null)
                {
                }

                _txtDepartment = value;
                if (_txtDepartment != null)
                {
                }
            }
        }

        private CheckBox _chkDoNotConsolidate;

        internal CheckBox chkDoNotConsolidate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDoNotConsolidate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDoNotConsolidate != null)
                {
                }

                _chkDoNotConsolidate = value;
                if (_chkDoNotConsolidate != null)
                {
                }
            }
        }

        private Button _btnRemove;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpJob = new System.Windows.Forms.GroupBox();
            this._dgEngineerVisits = new System.Windows.Forms.DataGrid();
            this._grpPartsAndProducts = new System.Windows.Forms.GroupBox();
            this._btnExport = new System.Windows.Forms.Button();
            this._btnRemove = new System.Windows.Forms.Button();
            this._dgPartsAndProducts = new System.Windows.Forms.DataGrid();
            this._btnAddProduct = new System.Windows.Forms.Button();
            this._btnAddPart = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._lblinformation = new System.Windows.Forms.Label();
            this._chkAwaiting = new System.Windows.Forms.CheckBox();
            this._chkConfirmed = new System.Windows.Forms.CheckBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._dtpDeadline = new System.Windows.Forms.DateTimePicker();
            this._Label2 = new System.Windows.Forms.Label();
            this._TabControl1 = new System.Windows.Forms.TabControl();
            this._TabPage1 = new System.Windows.Forms.TabPage();
            this._TabPage2 = new System.Windows.Forms.TabPage();
            this._grpCharges = new System.Windows.Forms.GroupBox();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnChargesSave = new System.Windows.Forms.Button();
            this._txtAmount = new System.Windows.Forms.TextBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._cboChargeType = new System.Windows.Forms.ComboBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._dgCharges = new System.Windows.Forms.DataGrid();
            this._Label17 = new System.Windows.Forms.Label();
            this._txtDepartment = new System.Windows.Forms.TextBox();
            this._chkDoNotConsolidate = new System.Windows.Forms.CheckBox();
            this._grpJob.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineerVisits)).BeginInit();
            this._grpPartsAndProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgPartsAndProducts)).BeginInit();
            this._TabControl1.SuspendLayout();
            this._TabPage1.SuspendLayout();
            this._TabPage2.SuspendLayout();
            this._grpCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpJob
            // 
            this._grpJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJob.Controls.Add(this._dgEngineerVisits);
            this._grpJob.Location = new System.Drawing.Point(8, 12);
            this._grpJob.Name = "_grpJob";
            this._grpJob.Size = new System.Drawing.Size(976, 152);
            this._grpJob.TabIndex = 1;
            this._grpJob.TabStop = false;
            this._grpJob.Text = "More than one engineer visit exists for this job, please select the visit to assi" +
    "gn this order to and click OK";
            // 
            // _dgEngineerVisits
            // 
            this._dgEngineerVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgEngineerVisits.DataMember = "";
            this._dgEngineerVisits.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgEngineerVisits.Location = new System.Drawing.Point(8, 30);
            this._dgEngineerVisits.Name = "_dgEngineerVisits";
            this._dgEngineerVisits.Size = new System.Drawing.Size(960, 114);
            this._dgEngineerVisits.TabIndex = 1;
            // 
            // _grpPartsAndProducts
            // 
            this._grpPartsAndProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpPartsAndProducts.Controls.Add(this._btnExport);
            this._grpPartsAndProducts.Controls.Add(this._btnRemove);
            this._grpPartsAndProducts.Controls.Add(this._dgPartsAndProducts);
            this._grpPartsAndProducts.Controls.Add(this._btnAddProduct);
            this._grpPartsAndProducts.Controls.Add(this._btnAddPart);
            this._grpPartsAndProducts.Location = new System.Drawing.Point(0, 6);
            this._grpPartsAndProducts.Name = "_grpPartsAndProducts";
            this._grpPartsAndProducts.Size = new System.Drawing.Size(968, 297);
            this._grpPartsAndProducts.TabIndex = 2;
            this._grpPartsAndProducts.TabStop = false;
            this._grpPartsAndProducts.Text = "Parts && Products";
            // 
            // _btnExport
            // 
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(198, 265);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(88, 23);
            this._btnExport.TabIndex = 9;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _btnRemove
            // 
            this._btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRemove.Location = new System.Drawing.Point(788, 263);
            this._btnRemove.Name = "_btnRemove";
            this._btnRemove.Size = new System.Drawing.Size(164, 23);
            this._btnRemove.TabIndex = 8;
            this._btnRemove.Text = "Remove Part / Product";
            this._btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // _dgPartsAndProducts
            // 
            this._dgPartsAndProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgPartsAndProducts.DataMember = "";
            this._dgPartsAndProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgPartsAndProducts.Location = new System.Drawing.Point(8, 20);
            this._dgPartsAndProducts.Name = "_dgPartsAndProducts";
            this._dgPartsAndProducts.Size = new System.Drawing.Size(952, 237);
            this._dgPartsAndProducts.TabIndex = 3;
            this._dgPartsAndProducts.CurrentCellChanged += new System.EventHandler(this.dgPartsAndProducts_CurrentCellChanged);
            // 
            // _btnAddProduct
            // 
            this._btnAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddProduct.Location = new System.Drawing.Point(104, 265);
            this._btnAddProduct.Name = "_btnAddProduct";
            this._btnAddProduct.Size = new System.Drawing.Size(88, 23);
            this._btnAddProduct.TabIndex = 6;
            this._btnAddProduct.Text = "Add Product";
            this._btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // _btnAddPart
            // 
            this._btnAddPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddPart.Location = new System.Drawing.Point(8, 265);
            this._btnAddPart.Name = "_btnAddPart";
            this._btnAddPart.Size = new System.Drawing.Size(88, 23);
            this._btnAddPart.TabIndex = 7;
            this._btnAddPart.Text = "Add Part";
            this._btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(928, 536);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(56, 23);
            this._btnSave.TabIndex = 4;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(8, 536);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(56, 23);
            this._btnCancel.TabIndex = 5;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _lblinformation
            // 
            this._lblinformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lblinformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this._lblinformation.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblinformation.Location = new System.Drawing.Point(328, 536);
            this._lblinformation.Name = "_lblinformation";
            this._lblinformation.Size = new System.Drawing.Size(600, 24);
            this._lblinformation.TabIndex = 8;
            this._lblinformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _chkAwaiting
            // 
            this._chkAwaiting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._chkAwaiting.AutoSize = true;
            this._chkAwaiting.Location = new System.Drawing.Point(91, 508);
            this._chkAwaiting.Name = "_chkAwaiting";
            this._chkAwaiting.Size = new System.Drawing.Size(152, 17);
            this._chkAwaiting.TabIndex = 9;
            this._chkAwaiting.Text = "Awaiting Confirmation";
            this._chkAwaiting.UseVisualStyleBackColor = true;
            this._chkAwaiting.CheckedChanged += new System.EventHandler(this.chkAwaiting_CheckedChanged);
            // 
            // _chkConfirmed
            // 
            this._chkConfirmed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._chkConfirmed.AutoSize = true;
            this._chkConfirmed.Location = new System.Drawing.Point(249, 508);
            this._chkConfirmed.Name = "_chkConfirmed";
            this._chkConfirmed.Size = new System.Drawing.Size(86, 17);
            this._chkConfirmed.TabIndex = 10;
            this._chkConfirmed.Text = "Confirmed";
            this._chkConfirmed.UseVisualStyleBackColor = true;
            this._chkConfirmed.CheckedChanged += new System.EventHandler(this.chkConfirmed_CheckedChanged);
            // 
            // _Label1
            // 
            this._Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(5, 508);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(80, 13);
            this._Label1.TabIndex = 11;
            this._Label1.Text = "Order Status";
            // 
            // _dtpDeadline
            // 
            this._dtpDeadline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dtpDeadline.CustomFormat = "dddd dd MMMM yyyy";
            this._dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpDeadline.Location = new System.Drawing.Point(456, 508);
            this._dtpDeadline.Name = "_dtpDeadline";
            this._dtpDeadline.Size = new System.Drawing.Size(244, 21);
            this._dtpDeadline.TabIndex = 12;
            // 
            // _Label2
            // 
            this._Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(341, 509);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(109, 13);
            this._Label2.TabIndex = 13;
            this._Label2.Text = "Delivery Deadline";
            // 
            // _TabControl1
            // 
            this._TabControl1.Controls.Add(this._TabPage1);
            this._TabControl1.Controls.Add(this._TabPage2);
            this._TabControl1.Location = new System.Drawing.Point(8, 170);
            this._TabControl1.Name = "_TabControl1";
            this._TabControl1.SelectedIndex = 0;
            this._TabControl1.Size = new System.Drawing.Size(976, 332);
            this._TabControl1.TabIndex = 14;
            // 
            // _TabPage1
            // 
            this._TabPage1.Controls.Add(this._grpPartsAndProducts);
            this._TabPage1.Location = new System.Drawing.Point(4, 22);
            this._TabPage1.Name = "_TabPage1";
            this._TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this._TabPage1.Size = new System.Drawing.Size(968, 306);
            this._TabPage1.TabIndex = 0;
            this._TabPage1.Text = "Parts & Products";
            this._TabPage1.UseVisualStyleBackColor = true;
            // 
            // _TabPage2
            // 
            this._TabPage2.Controls.Add(this._grpCharges);
            this._TabPage2.Location = new System.Drawing.Point(4, 22);
            this._TabPage2.Name = "_TabPage2";
            this._TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this._TabPage2.Size = new System.Drawing.Size(968, 278);
            this._TabPage2.TabIndex = 1;
            this._TabPage2.Text = "Charges";
            this._TabPage2.UseVisualStyleBackColor = true;
            // 
            // _grpCharges
            // 
            this._grpCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCharges.Controls.Add(this._btnDelete);
            this._grpCharges.Controls.Add(this._btnChargesSave);
            this._grpCharges.Controls.Add(this._txtAmount);
            this._grpCharges.Controls.Add(this._Label3);
            this._grpCharges.Controls.Add(this._cboChargeType);
            this._grpCharges.Controls.Add(this._Label4);
            this._grpCharges.Controls.Add(this._dgCharges);
            this._grpCharges.Location = new System.Drawing.Point(6, 0);
            this._grpCharges.Name = "_grpCharges";
            this._grpCharges.Size = new System.Drawing.Size(956, 272);
            this._grpCharges.TabIndex = 3;
            this._grpCharges.TabStop = false;
            this._grpCharges.Text = "Charges";
            // 
            // _btnDelete
            // 
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDelete.Location = new System.Drawing.Point(884, 208);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(64, 23);
            this._btnDelete.TabIndex = 5;
            this._btnDelete.Text = "Remove";
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // _btnChargesSave
            // 
            this._btnChargesSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnChargesSave.Location = new System.Drawing.Point(884, 240);
            this._btnChargesSave.Name = "_btnChargesSave";
            this._btnChargesSave.Size = new System.Drawing.Size(64, 23);
            this._btnChargesSave.TabIndex = 4;
            this._btnChargesSave.Text = "Add";
            this._btnChargesSave.Click += new System.EventHandler(this.btnChargesSave_Click);
            // 
            // _txtAmount
            // 
            this._txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAmount.Location = new System.Drawing.Point(804, 240);
            this._txtAmount.Name = "_txtAmount";
            this._txtAmount.Size = new System.Drawing.Size(72, 21);
            this._txtAmount.TabIndex = 3;
            // 
            // _Label3
            // 
            this._Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label3.Location = new System.Drawing.Point(740, 240);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(56, 23);
            this._Label3.TabIndex = 3;
            this._Label3.Text = "Amount:";
            // 
            // _cboChargeType
            // 
            this._cboChargeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboChargeType.Location = new System.Drawing.Point(96, 240);
            this._cboChargeType.Name = "_cboChargeType";
            this._cboChargeType.Size = new System.Drawing.Size(636, 21);
            this._cboChargeType.TabIndex = 2;
            // 
            // _Label4
            // 
            this._Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label4.Location = new System.Drawing.Point(8, 240);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(88, 23);
            this._Label4.TabIndex = 1;
            this._Label4.Text = "Charge Type:";
            // 
            // _dgCharges
            // 
            this._dgCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgCharges.DataMember = "";
            this._dgCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgCharges.Location = new System.Drawing.Point(8, 25);
            this._dgCharges.Name = "_dgCharges";
            this._dgCharges.Size = new System.Drawing.Size(940, 175);
            this._dgCharges.TabIndex = 1;
            this._dgCharges.CurrentCellChanged += new System.EventHandler(this.dgCharges_Click);
            this._dgCharges.Click += new System.EventHandler(this.dgCharges_Click);
            // 
            // _Label17
            // 
            this._Label17.Location = new System.Drawing.Point(705, 508);
            this._Label17.Name = "_Label17";
            this._Label17.Size = new System.Drawing.Size(38, 20);
            this._Label17.TabIndex = 70;
            this._Label17.Text = "Dept";
            // 
            // _txtDepartment
            // 
            this._txtDepartment.Location = new System.Drawing.Point(749, 511);
            this._txtDepartment.MaxLength = 100;
            this._txtDepartment.Name = "_txtDepartment";
            this._txtDepartment.Size = new System.Drawing.Size(131, 21);
            this._txtDepartment.TabIndex = 69;
            this._txtDepartment.Tag = "";
            // 
            // _chkDoNotConsolidate
            // 
            this._chkDoNotConsolidate.AutoSize = true;
            this._chkDoNotConsolidate.Location = new System.Drawing.Point(91, 540);
            this._chkDoNotConsolidate.Name = "_chkDoNotConsolidate";
            this._chkDoNotConsolidate.Size = new System.Drawing.Size(136, 17);
            this._chkDoNotConsolidate.TabIndex = 71;
            this._chkDoNotConsolidate.Text = "Do Not Consolidate";
            this._chkDoNotConsolidate.UseVisualStyleBackColor = true;
            // 
            // FRMConvertToAnOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.ControlBox = false;
            this.Controls.Add(this._chkDoNotConsolidate);
            this.Controls.Add(this._Label17);
            this.Controls.Add(this._txtDepartment);
            this.Controls.Add(this._TabControl1);
            this.Controls.Add(this._Label2);
            this.Controls.Add(this._dtpDeadline);
            this.Controls.Add(this._Label1);
            this.Controls.Add(this._chkConfirmed);
            this.Controls.Add(this._chkAwaiting);
            this.Controls.Add(this._lblinformation);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._grpJob);
            this.Name = "FRMConvertToAnOrder";
            this.Text = "Convert to an order";
            this._grpJob.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgEngineerVisits)).EndInit();
            this._grpPartsAndProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgPartsAndProducts)).EndInit();
            this._TabControl1.ResumeLayout(false);
            this._TabPage1.ResumeLayout(false);
            this._TabPage2.ResumeLayout(false);
            this._grpCharges.ResumeLayout(false);
            this._grpCharges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCharges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LoadMe(object sender, EventArgs e)
        {
            chkAwaiting.Checked = true;
            dtpDeadline.Value = DateAndTime.Now;
            OrderType = (Entity.Sys.Enums.OrderType)get_GetParameter(0);
            var switchExpr = OrderType;
            switch (switchExpr)
            {
                case Entity.Sys.Enums.OrderType.Job:
                    {
                        Size = new Size(1000, 600);
                        MinimumSize = new Size(1000, 600);
                        Height = 608;
                        grpPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                        EngineerVisitID = Conversions.ToInteger(get_GetParameter(4));
                        NeedsTransaction = Conversions.ToBoolean(get_GetParameter(5));
                        if (EngineerVisitID > 0)
                        {
                            if (Trans is object)
                            {
                                EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get(EngineerVisitID, Trans);
                            }
                            else
                            {
                                EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get(EngineerVisitID);
                            }

                            PartsAndProducts = (DataView)get_GetParameter(2);
                            grpJob.Text = "Visit Information";
                        }
                        else
                        {
                            ID = Conversions.ToInteger(get_GetParameter(1));
                            if (Trans is object)
                            {
                                EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(ID, Trans);
                            }
                            else
                            {
                                EngineerVisitsDataView = App.DB.EngineerVisits.EngineerVisits_Get_All_JobID(ID);
                            }

                            PartsAndProducts = (DataView)get_GetParameter(2);
                        }

                        RefreshDatagrid();
                        break;
                    }

                case Entity.Sys.Enums.OrderType.Customer:
                    {
                        Size = new Size(1000, 448);
                        MinimumSize = new Size(1000, 448);
                        Height = 448;
                        grpPartsAndProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                        PartsAndProducts = (DataView)get_GetParameter(2);
                        QuoteOrder = (Entity.QuoteOrders.QuoteOrder)get_GetParameter(3);
                        break;
                    }
            }

            Application.DoEvents();
            LoadForm(sender, e, this);
            SetupVisitsDataGrid();
            SetupPartsAndProductsDataGrid();
            SetupChargesDatagrid();
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
            ID = newID;
        }

        private System.Data.SqlClient.SqlTransaction _Trans;

        public System.Data.SqlClient.SqlTransaction Trans
        {
            get
            {
                return _Trans;
            }

            set
            {
                _Trans = value;
            }
        }

        private DataView m_dTable2 = null;

        public DataView PriceRequestItemsDataView
        {
            get
            {
                return m_dTable2;
            }

            set
            {
                m_dTable2 = value;
            }
        }

        private Entity.QuoteOrders.QuoteOrder _QuoteOrder;

        public Entity.QuoteOrders.QuoteOrder QuoteOrder
        {
            get
            {
                return _QuoteOrder;
            }

            set
            {
                _QuoteOrder = value;
                if (QuoteOrder is object)
                {
                    dtpDeadline.Value = QuoteOrder.DeliveryDeadline;
                }
            }
        }

        private Entity.Sys.Enums.OrderType _OrderType;

        public Entity.Sys.Enums.OrderType OrderType
        {
            get
            {
                return _OrderType;
            }

            set
            {
                _OrderType = value;
            }
        }

        private int _ID = 0;

        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        private int _EngineerVisitID = 0;

        public int EngineerVisitID
        {
            get
            {
                return _EngineerVisitID;
            }

            set
            {
                _EngineerVisitID = value;
            }
        }

        private DataView _EngineerVisitsDataView = null;

        public DataView EngineerVisitsDataView
        {
            get
            {
                return _EngineerVisitsDataView;
            }

            set
            {
                value.Table.AcceptChanges();
                value.Table.Columns.Add(new DataColumn("VisitCount"));
                int i = 1;
                foreach (DataRow row in value.Table.Rows)
                {
                    row["VisitCount"] = i;
                    i += 1;
                }

                _EngineerVisitsDataView = value;
                _EngineerVisitsDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
                _EngineerVisitsDataView.AllowNew = false;
                _EngineerVisitsDataView.AllowEdit = false;
                _EngineerVisitsDataView.AllowDelete = false;
                dgEngineerVisits.DataSource = EngineerVisitsDataView;
            }
        }

        private DataView _PartsAndProducts = null;

        public DataView PartsAndProducts
        {
            get
            {
                return _PartsAndProducts;
            }

            set
            {
                value.Table.AcceptChanges();
                value.Table.Columns.Add(new DataColumn("SupplierID"));
                value.Table.Columns.Add(new DataColumn("QuantityToOrder"));
                value.Table.Columns.Add(new DataColumn("GetFrom"));
                value.Table.Columns.Add(new DataColumn("GetFromText"));
                value.Table.Columns.Add(new DataColumn("GetID"));
                value.Table.Columns.Add(new DataColumn("BuyPrice", Type.GetType("System.Double")));
                value.Table.Columns.Add(new DataColumn("VisitCount"));
                value.Table.Columns.Add(new DataColumn("Shelf"));
                value.Table.Columns.Add(new DataColumn("Bin"));
                // If EngineerVisitID > 0 Then
                // Value.Table.Columns.Add(New DataColumn("SellPrice"))
                // End If

                value.Table.AcceptChanges();
                foreach (DataRow row in value.Table.Rows)
                {
                    DataTable dt;
                    if ((Conversions.ToString(row["type"]).ToUpper() ?? "") == "PART")
                    {
                        if (Trans is object)
                        {
                            dt = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(row["PartProductID"]), Trans).Table;
                        }
                        else
                        {
                            dt = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(row["PartProductID"])).Table;
                        }
                    }
                    else if (Trans is object)
                    {
                        dt = App.DB.Product.Stock_Get_Locations(Conversions.ToInteger(row["PartProductID"]), Trans).Table;
                    }
                    else
                    {
                        dt = App.DB.Product.Stock_Get_Locations(Conversions.ToInteger(row["PartProductID"])).Table;
                    }

                    int warehouseID = 0;
                    int locationID = 0;
                    string shelf = "";
                    string bin = "";
                    foreach (DataRow partProductRow in dt.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(partProductRow["Type"], "WAREHOUSE", false)))
                        {
                            if (Conversions.ToBoolean(Helper.MakeDoubleValid(partProductRow["Quantity"]) >= Helper.MakeDoubleValid(row["quantity"])))
                            {
                                warehouseID = Conversions.ToInteger(partProductRow["WarehouseID"]);
                                locationID = Conversions.ToInteger(partProductRow["LocationID"]);
                                shelf = Conversions.ToString(partProductRow["Shelf"]);
                                bin = Conversions.ToString(partProductRow["Bin"]);
                                break;
                            }
                        }
                    }

                    if (!(warehouseID == 0))
                    {
                        row["QuantityToOrder"] = row["quantity"];
                        row["GetFrom"] = 3;
                        if (Trans is object)
                        {
                            row["GetFromText"] = App.DB.Warehouse.Warehouse_Get(warehouseID, Trans).Name;
                        }
                        else
                        {
                            row["GetFromText"] = App.DB.Warehouse.Warehouse_Get(warehouseID).Name;
                        }

                        row["GetID"] = locationID;
                        row["BuyPrice"] = 0;
                        row["Shelf"] = shelf;
                        row["Bin"] = bin;
                    }
                }

                _PartsAndProducts = value;
                _PartsAndProducts.Table.TableName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
                _PartsAndProducts.AllowNew = false;
                _PartsAndProducts.AllowEdit = true;
                _PartsAndProducts.AllowDelete = false;
                dgPartsAndProducts.DataSource = PartsAndProducts;
            }
        }

        public DataRow SelectedPartProductDataRow
        {
            get
            {
                if (!(dgPartsAndProducts.CurrentRowIndex == -1))
                {
                    return PartsAndProducts[dgPartsAndProducts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool _NeedsTransaction = false;

        public bool NeedsTransaction
        {
            get
            {
                return _NeedsTransaction;
            }

            set
            {
                _NeedsTransaction = value;
            }
        }

        private DataView _ChargesDataView = null;

        public DataView ChargesDataView
        {
            get
            {
                return _ChargesDataView;
            }

            set
            {
                _ChargesDataView = value;
                _ChargesDataView.Table.TableName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString();
                _ChargesDataView.AllowNew = false;
                _ChargesDataView.AllowEdit = false;
                _ChargesDataView.AllowDelete = false;
                dgCharges.DataSource = ChargesDataView;
            }
        }

        private DataRow SelectedChargeDataRow
        {
            get
            {
                if (!(dgCharges.CurrentRowIndex == -1))
                {
                    return ChargesDataView[dgCharges.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Sys.Enums.FormState _PageState = Entity.Sys.Enums.FormState.Insert;

        public Entity.Sys.Enums.FormState PageState
        {
            get
            {
                return _PageState;
            }

            set
            {
                _PageState = value;
                var switchExpr = PageState;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            btnSave.Text = "Add";
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            btnSave.Text = "Update";
                            break;
                        }
                }

                txtAmount.Text = "";
                var argcombo = cboChargeType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            }
        }

        public void SetupVisitsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgEngineerVisits);
            var tbStyle = dgEngineerVisits.TableStyles[0];
            tbStyle.GridColumnStyles.Clear();
            var VisitCount = new DataGridLabelColumn();
            VisitCount.Format = "";
            VisitCount.FormatInfo = null;
            VisitCount.HeaderText = "#";
            VisitCount.MappingName = "VisitCount";
            VisitCount.ReadOnly = true;
            VisitCount.Width = 50;
            VisitCount.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitCount);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 150;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 150;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 75;
            JobNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var PONumber = new DataGridLabelColumn();
            PONumber.Format = "";
            PONumber.FormatInfo = null;
            PONumber.HeaderText = "PO Number";
            PONumber.MappingName = "PONumber";
            PONumber.ReadOnly = true;
            PONumber.Width = 75;
            PONumber.NullText = "";
            tbStyle.GridColumnStyles.Add(PONumber);
            var JobDefinition = new DataGridLabelColumn();
            JobDefinition.Format = "";
            JobDefinition.FormatInfo = null;
            JobDefinition.HeaderText = "Definition";
            JobDefinition.MappingName = "JobDefinition";
            JobDefinition.ReadOnly = true;
            JobDefinition.Width = 75;
            JobDefinition.NullText = "";
            tbStyle.GridColumnStyles.Add(JobDefinition);
            var NotesToEngineer = new DataGridLabelColumn();
            NotesToEngineer.Format = "";
            NotesToEngineer.FormatInfo = null;
            NotesToEngineer.HeaderText = "Notes To Engineer";
            NotesToEngineer.MappingName = "NotesToEngineer";
            NotesToEngineer.ReadOnly = true;
            NotesToEngineer.Width = 75;
            NotesToEngineer.NullText = "";
            tbStyle.GridColumnStyles.Add(NotesToEngineer);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = Entity.Sys.Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tbStyle.GridColumnStyles.Add(Type);
            var VisitStatus = new DataGridLabelColumn();
            VisitStatus.Format = "";
            VisitStatus.FormatInfo = null;
            VisitStatus.HeaderText = "Status";
            VisitStatus.MappingName = "VisitStatus";
            VisitStatus.ReadOnly = true;
            VisitStatus.Width = 75;
            VisitStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(VisitStatus);
            var VisitDate = new DataGridLabelColumn();
            VisitDate.Format = "dd/MMM/yyyy";
            VisitDate.FormatInfo = null;
            VisitDate.HeaderText = "Date";
            VisitDate.MappingName = "startdatetime";
            VisitDate.ReadOnly = true;
            VisitDate.Width = 100;
            VisitDate.NullText = "Not Set";
            tbStyle.GridColumnStyles.Add(VisitDate);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisit.ToString();
            dgEngineerVisits.TableStyles.Add(tbStyle);
        }

        public void SetupPartsAndProductsDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgPartsAndProducts);
            var tStyle = dgPartsAndProducts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgPartsAndProducts.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "type";
            type.ReadOnly = true;
            type.Width = 75;
            type.NullText = "";
            tStyle.GridColumnStyles.Add(type);
            var number = new DataGridLabelColumn();
            number.Format = "";
            number.FormatInfo = null;
            number.HeaderText = "Number";
            number.MappingName = "number";
            number.ReadOnly = true;
            number.Width = 120;
            number.NullText = "";
            tStyle.GridColumnStyles.Add(number);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 130;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            if (Trans is object)
            {
                var GetFrom = new DataGridComboBoxColumn(Trans, true);
                GetFrom.HeaderText = "Get From (Select)";
                GetFrom.MappingName = "GetFrom";
                GetFrom.ReadOnly = false;
                GetFrom.Width = 150;
                // no actual DB call so doesnt need tran
                GetFrom.ComboBox.DataSource = App.DB.Order.Get_All_Places_Item_Can_Be_Got_From().Table;
                GetFrom.ComboBox.DisplayMember = "DisplayMember";
                GetFrom.ComboBox.ValueMember = "ValueMember";
                GetFrom.itemSelected += ItemSelected;
                tStyle.GridColumnStyles.Add(GetFrom);
            }
            else
            {
                var GetFrom = new DataGridComboBoxColumn(true);
                GetFrom.HeaderText = "Get From (Select)";
                GetFrom.MappingName = "GetFrom";
                GetFrom.ReadOnly = false;
                GetFrom.Width = 150;
                // no actual DB call so doesnt need tran
                GetFrom.ComboBox.DataSource = App.DB.Order.Get_All_Places_Item_Can_Be_Got_From().Table;
                GetFrom.ComboBox.DisplayMember = "DisplayMember";
                GetFrom.ComboBox.ValueMember = "ValueMember";
                GetFrom.itemSelected += ItemSelected;
                tStyle.GridColumnStyles.Add(GetFrom);
            }

            var GetFromText = new DataGridLabelColumn();
            GetFromText.Format = "";
            GetFromText.FormatInfo = null;
            GetFromText.HeaderText = "From";
            GetFromText.MappingName = "GetFromText";
            GetFromText.ReadOnly = true;
            GetFromText.Width = 130;
            GetFromText.NullText = "";
            tStyle.GridColumnStyles.Add(GetFromText);
            var Shelf = new DataGridLabelColumn();
            Shelf.Format = "";
            Shelf.FormatInfo = null;
            Shelf.HeaderText = "Shelf";
            Shelf.MappingName = "Shelf";
            Shelf.ReadOnly = true;
            Shelf.Width = 75;
            Shelf.NullText = "";
            tStyle.GridColumnStyles.Add(Shelf);
            var Bin = new DataGridLabelColumn();
            Bin.Format = "";
            Bin.FormatInfo = null;
            Bin.HeaderText = "Bin";
            Bin.MappingName = "Bin";
            Bin.ReadOnly = true;
            Bin.Width = 100;
            Bin.NullText = "";
            tStyle.GridColumnStyles.Add(Bin);
            var BuyPrice = new DataGridEditableTextBoxColumn();
            BuyPrice.Format = "C";
            BuyPrice.FormatInfo = null;
            BuyPrice.HeaderText = "Pack/Unit Buy Price";
            BuyPrice.MappingName = "BuyPrice";
            BuyPrice.ReadOnly = false;
            BuyPrice.Width = 105;
            BuyPrice.NullText = "";
            tStyle.GridColumnStyles.Add(BuyPrice);
            var Sellprice = new DataGridEditableTextBoxColumn();
            Sellprice.Format = "C";
            Sellprice.FormatInfo = null;
            Sellprice.HeaderText = "Unit Sell Price";
            Sellprice.MappingName = "Sellprice";
            Sellprice.ReadOnly = false;
            Sellprice.Width = 100;
            Sellprice.NullText = "";
            tStyle.GridColumnStyles.Add(Sellprice);
            var quantity = new DataGridLabelColumn();
            quantity.Format = "";
            quantity.FormatInfo = null;
            quantity.HeaderText = "Qty Needed";
            quantity.MappingName = "quantity";
            quantity.ReadOnly = false;
            quantity.Width = 100;
            quantity.NullText = "";
            tStyle.GridColumnStyles.Add(quantity);
            var quantityToOrder = new DataGridEditableTextBoxColumn();
            quantityToOrder.Format = "";
            quantityToOrder.FormatInfo = null;
            quantityToOrder.HeaderText = "Qty Packs/Units to Order";
            quantityToOrder.MappingName = "QuantityToOrder";
            if (EngineerVisitID > 0)
            {
                quantityToOrder.ReadOnly = true;
            }
            else
            {
                quantityToOrder.ReadOnly = false;
            }

            quantityToOrder.Width = 120;
            quantityToOrder.NullText = "";
            tStyle.GridColumnStyles.Add(quantityToOrder);
            if (OrderType == Entity.Sys.Enums.OrderType.Job & EngineerVisitID == 0)
            {
                var VisitCount = new DataGridComboBoxColumn();
                VisitCount.HeaderText = "Visit # (Select)";
                VisitCount.MappingName = "VisitCount";
                VisitCount.ReadOnly = false;
                VisitCount.Width = 90;
                VisitCount.ComboBox.DataSource = EngineerVisitsDataView.Table;
                VisitCount.ComboBox.DisplayMember = "VisitCount";
                VisitCount.ComboBox.ValueMember = "VisitCount";
                VisitCount.ComboBox.SelectedValue = 1;
                tStyle.GridColumnStyles.Add(VisitCount);
            }

            tStyle.MappingName = Entity.Sys.Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
            dgPartsAndProducts.TableStyles.Add(tStyle);
        }

        public void SetupChargesDatagrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgCharges);
            var tStyle = dgCharges.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var ChargeType = new DataGridLabelColumn();
            ChargeType.Format = "";
            ChargeType.FormatInfo = null;
            ChargeType.HeaderText = "ChargeType";
            ChargeType.MappingName = "ChargeType";
            ChargeType.ReadOnly = true;
            ChargeType.Width = 130;
            ChargeType.NullText = "N/A";
            tStyle.GridColumnStyles.Add(ChargeType);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "C";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 130;
            Amount.NullText = "N/A";
            tStyle.GridColumnStyles.Add(Amount);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblOrderCharge.ToString();
            dgCharges.TableStyles.Add(tStyle);
        }

        public void ItemSelected()
        {
            if (!(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID == 0))
            {
                SelectedPartProductDataRow["GetID"] = ((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID;
                var switchExpr = ((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).SearchingFor;
                switch (switchExpr)
                {
                    case "Supplier":
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPartProductDataRow["Type"], "Product", false)))
                            {
                                Entity.ProductSuppliers.ProductSupplier oProductSupplier;
                                if (Trans is object)
                                {
                                    oProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID, Trans);
                                }
                                else
                                {
                                    oProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID);
                                }

                                Entity.Suppliers.Supplier oSupplier;
                                if (Trans is object)
                                {
                                    oSupplier = App.DB.Supplier.Supplier_Get(oProductSupplier.SupplierID, Trans);
                                }
                                else
                                {
                                    oSupplier = App.DB.Supplier.Supplier_Get(oProductSupplier.SupplierID);
                                }

                                SelectedPartProductDataRow["BuyPrice"] = oProductSupplier.Price;
                                SelectedPartProductDataRow["GetFromText"] = oSupplier.Name;
                                SelectedPartProductDataRow["SupplierID"] = oSupplier.SupplierID;
                                if (Entity.Sys.Helper.MakeIntegerValid(SelectedPartProductDataRow["Quantity"]) == 0)
                                {
                                    SelectedPartProductDataRow["Quantity"] = 1;
                                }

                                SelectedPartProductDataRow["QuantityToOrder"] = Math.Ceiling(Helper.MakeDoubleValid(SelectedPartProductDataRow["Quantity"]) / Helper.MakeDoubleValid(oProductSupplier.QuantityInPack));
                                SelectedPartProductDataRow["GetFrom"] = 1;
                                SelectedPartProductDataRow["Shelf"] = "";
                                SelectedPartProductDataRow["Bin"] = "";
                            }
                            else
                            {
                                Entity.PartSuppliers.PartSupplier oPartSupplier;
                                if (Trans is object)
                                {
                                    oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID, Trans);
                                }
                                else
                                {
                                    oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID);
                                }

                                Entity.Suppliers.Supplier oSupplier;
                                if (Trans is object)
                                {
                                    oSupplier = App.DB.Supplier.Supplier_Get(oPartSupplier.SupplierID, Trans);
                                }
                                else
                                {
                                    oSupplier = App.DB.Supplier.Supplier_Get(oPartSupplier.SupplierID);
                                }

                                SelectedPartProductDataRow["BuyPrice"] = oPartSupplier.Price;
                                SelectedPartProductDataRow["GetFromText"] = oSupplier.Name;
                                SelectedPartProductDataRow["SupplierID"] = oSupplier.SupplierID;
                                if (Entity.Sys.Helper.MakeIntegerValid(SelectedPartProductDataRow["Quantity"]) == 0)
                                {
                                    SelectedPartProductDataRow["Quantity"] = 1;
                                }

                                SelectedPartProductDataRow["QuantityToOrder"] = Math.Ceiling(Helper.MakeDoubleValid(SelectedPartProductDataRow["Quantity"]) / Helper.MakeDoubleValid(oPartSupplier.QuantityInPack));
                                SelectedPartProductDataRow["GetFrom"] = 1;
                                SelectedPartProductDataRow["Shelf"] = "";
                                SelectedPartProductDataRow["Bin"] = "";
                            }

                            break;
                        }

                    case "Van":
                        {
                            if (Trans is object)
                            {
                                SelectedPartProductDataRow["GetFromText"] = App.DB.Van.Van_GetByLocationID(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID, Trans).Registration;
                            }
                            else
                            {
                                SelectedPartProductDataRow["GetFromText"] = App.DB.Van.Van_GetByLocationID(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID).Registration;
                            }

                            SelectedPartProductDataRow["BuyPrice"] = 0;
                            SelectedPartProductDataRow["GetFrom"] = 2;
                            SelectedPartProductDataRow["QuantityToOrder"] = SelectedPartProductDataRow["Quantity"];
                            SelectedPartProductDataRow["Shelf"] = "";
                            SelectedPartProductDataRow["Bin"] = "";
                            break;
                        }

                    case "Warehouse":
                        {
                            DataTable dt = null;
                            if (Trans is object)
                            {
                                var w = App.DB.Warehouse.Warehouse_GetByLocationID(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID, Trans);
                                SelectedPartProductDataRow["GetFromText"] = w.Name;
                                if ((Conversions.ToString(SelectedPartProductDataRow["type"]).ToUpper() ?? "") == "PART")
                                {
                                    dt = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(SelectedPartProductDataRow["PartProductID"]), Trans).Table;
                                }
                            }
                            else
                            {
                                var w = App.DB.Warehouse.Warehouse_GetByLocationID(((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ReturnID);
                                SelectedPartProductDataRow["GetFromText"] = w.Name;
                                if ((Conversions.ToString(SelectedPartProductDataRow["type"]).ToUpper() ?? "") == "PART")
                                {
                                    dt = App.DB.Part.Stock_Get_Locations(Conversions.ToInteger(SelectedPartProductDataRow["PartProductID"])).Table;
                                }
                            }

                            string shelf = "";
                            string bin = "";
                            if (dt is object)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedPartProductDataRow["GetID"], row["LocationID"], false)))
                                    {
                                        shelf = Conversions.ToString(row["Shelf"]);
                                        bin = Conversions.ToString(row["Bin"]);
                                        break;
                                    }
                                }
                            }

                            SelectedPartProductDataRow["BuyPrice"] = 0;
                            SelectedPartProductDataRow["GetFrom"] = 3;
                            SelectedPartProductDataRow["QuantityToOrder"] = SelectedPartProductDataRow["Quantity"];
                            SelectedPartProductDataRow["Shelf"] = shelf;
                            SelectedPartProductDataRow["Bin"] = bin;
                            break;
                        }
                }
            }
            else
            {
                ((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).ComboBox.SelectedValue = 0;
                SelectedPartProductDataRow["GetID"] = "0";
                SelectedPartProductDataRow["QuantityToOrder"] = "0";
                SelectedPartProductDataRow["BuyPrice"] = "0";
                SelectedPartProductDataRow["QuantityToOrder"] = 1;
                SelectedPartProductDataRow["GetFromText"] = "";
                SelectedPartProductDataRow["Shelf"] = "";
                SelectedPartProductDataRow["Bin"] = "";
            }

            SelectedPartProductDataRow.AcceptChanges();
            SelectedPartProductDataRow.Table.AcceptChanges();
            Application.DoEvents();
        }

        public bool validatePartsAndProducts()
        {
            string validationString = string.Empty;
            foreach (DataRow row in PartsAndProducts.Table.Rows)
            {
                if (Information.IsDBNull(row["GetFrom"]))
                {
                    validationString += Conversions.ToString("You must select where to get Item : " + row["Name"] + " : ") + row["Number"] + " from " + Constants.vbCrLf;
                }
                else if (Conversions.ToBoolean(!Information.IsNumeric(row["GetFrom"]) | Operators.ConditionalCompareObjectEqual(row["GetFrom"], 0, false)))
                {
                    validationString += Conversions.ToString("You must select where to get Item : " + row["Name"] + " : ") + row["Number"] + " from " + Constants.vbCrLf;
                }

                if (EngineerVisitID == 0 & OrderType == Entity.Sys.Enums.OrderType.Job)
                {
                    if (Information.IsDBNull(row["VisitCount"]))
                    {
                        validationString += Conversions.ToString("You must select a visit for item : " + row["Name"] + " : ") + row["Number"] + Constants.vbCrLf;
                    }
                    else if (Conversions.ToBoolean(!Information.IsNumeric(row["VisitCount"]) | Operators.ConditionalCompareObjectEqual(row["VisitCount"], 0, false)))
                    {
                        validationString += Conversions.ToString("You must select a visit for item : " + row["Name"] + " : ") + row["Number"] + Constants.vbCrLf;
                    }
                }

                if (Information.IsDBNull(row["SellPrice"]))
                {
                    validationString += Conversions.ToString("You must set a sell price for item : " + row["Name"] + " : ") + row["Number"] + Constants.vbCrLf;
                }
                else if (Conversions.ToBoolean(!Information.IsNumeric(row["SellPrice"]) | Operators.ConditionalCompareObjectEqual(row["SellPrice"], 0, false)))
                {
                    validationString += Conversions.ToString("You must set a sell price for item : " + row["Name"] + " : ") + row["Number"] + Constants.vbCrLf;
                }

                if (validationString.Length > 0)
                {
                    App.ShowMessage(validationString, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                var switchExpr = row["GetFrom"];
                switch (switchExpr)
                {
                    case var @case when @case == "1":
                        {
                            // supplier
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "Product", false)))
                            {
                                var oOrderProduct = new Entity.OrderProducts.OrderProduct();
                                oOrderProduct.SetBuyPrice = row["BuyPrice"];
                                oOrderProduct.SetSellPrice = row["SellPrice"];
                                oOrderProduct.SetQuantity = row["QuantityToOrder"];
                                oOrderProduct.SetProductSupplierID = row["GetID"];
                                var oOrderProductValidator = new Entity.OrderProducts.OrderProductValidator();
                                oOrderProductValidator.Validate(oOrderProduct);
                            }
                            else
                            {
                                var oOrderPart = new Entity.OrderParts.OrderPart();
                                oOrderPart.SetBuyPrice = row["BuyPrice"];
                                oOrderPart.SetSellPrice = row["SellPrice"];
                                oOrderPart.SetQuantity = row["QuantityToOrder"];
                                oOrderPart.SetPartSupplierID = row["GetID"];
                                var oOrderPartValidator = new Entity.OrderParts.OrderPartValidator();
                                oOrderPartValidator.Validate(oOrderPart);
                            }

                            break;
                        }

                    case var case1 when case1 == "2":
                    case var case2 when case2 == "3":
                        {
                            // warehouse/van
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(row["Type"], "Product", false)))
                            {
                                var oOrderLocationProduct = new Entity.OrderLocationProduct.OrderLocationProduct();
                                oOrderLocationProduct.SetProductID = row["PartProductID"];
                                oOrderLocationProduct.SetSellPrice = row["SellPrice"];
                                oOrderLocationProduct.SetQuantity = row["QuantityToOrder"];
                                oOrderLocationProduct.SetLocationID = row["GetID"];
                                var oOrderLocationProductValidator = new Entity.OrderLocationProduct.OrderLocationProductValidator();
                                if (Trans is object)
                                {
                                    oOrderLocationProductValidator.Validate(oOrderLocationProduct, Trans);
                                }
                                else
                                {
                                    oOrderLocationProductValidator.Validate(oOrderLocationProduct);
                                }
                            }
                            else
                            {
                                var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                                oOrderLocationPart.SetPartID = row["PartProductID"];
                                oOrderLocationPart.SetSellPrice = row["SellPrice"];
                                oOrderLocationPart.SetQuantity = row["QuantityToOrder"];
                                oOrderLocationPart.SetLocationID = row["GetID"];
                                var oOrderLocationPartValidator = new Entity.OrderLocationPart.OrderLocationPartValidator();
                                if (Trans is object)
                                {
                                    oOrderLocationPartValidator.Validate(oOrderLocationPart, Trans);
                                }
                                else
                                {
                                    oOrderLocationPartValidator.Validate(oOrderLocationPart);
                                }
                            }

                            break;
                        }
                }
            }

            return true;
        }

        private void FRMConvertToAnOrder_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
            lblinformation.Text = "Please Select where to get each item from by clicking in the Grid";
        }

        private void dgPartsAndProducts_CurrentCellChanged(object sender, EventArgs e)
        {
            ((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).TheID = Conversions.ToInteger(SelectedPartProductDataRow["PartProductID"]);
            ((DataGridComboBoxColumn)dgPartsAndProducts.TableStyles[0].GridColumnStyles["GetFrom"]).Type = Conversions.ToString(SelectedPartProductDataRow["Type"]);
        }

        private void chkAwaiting_CheckedChanged(object sender, EventArgs e)
        {
            chkConfirmed.Checked = !chkAwaiting.Checked;
        }

        private void chkConfirmed_CheckedChanged(object sender, EventArgs e)
        {
            chkAwaiting.Checked = !chkConfirmed.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("Are you sure you wish to cancel the auto creation of this order? You will need to manually create the order at a later date.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var con = default(System.Data.SqlClient.SqlConnection);
            if (NeedsTransaction == true)
            {
                con = new System.Data.SqlClient.SqlConnection(App.DB.ServerConnectionString);
                con.Open();
                Trans = con.BeginTransaction(IsolationLevel.ReadUncommitted);
            }

            var orders = new ArrayList();
            var errorOccured = default(bool);
            try
            {
                if (validatePartsAndProducts() == false)
                {
                    return;
                }

                if (txtDepartment.Text.Trim().Length == 0 & chkConfirmed.Checked == true)
                {
                    App.ShowMessage("Department Reference missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string userPrefix = "";
                var username = App.loggedInUser.Fullname.Split(' ');
                foreach (string s in username)
                    userPrefix += s.Substring(0, 1);
                if (OrderType == Entity.Sys.Enums.OrderType.Job)
                {
                    // JOB ORDER
                    Cursor.Current = Cursors.WaitCursor;
                    if (EngineerVisitID > 0)
                    {
                        var SupplierList = new Hashtable();
                        foreach (DataRow supplierRow in PartsAndProducts.Table.Select("GetFrom = 1"))
                        {
                            if (!SupplierList.Contains(supplierRow["SupplierID"]))
                            {
                                var oEngineerVisitOrder = new Entity.EngineerVisitOrders.EngineerVisitOrder();
                                Entity.Jobs.Job jb;
                                if (Trans is object)
                                {
                                    jb = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID, Trans);
                                }
                                else
                                {
                                    jb = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID);
                                }

                                var oOrder = new Entity.Orders.Order();
                                if (Trans is object)
                                {
                                    oOrder.SetOrderReference = userPrefix + jb.JobNumber + "_V" + EngineerVisitID + "-" + (App.DB.Order.Order_Get_ByRef(userPrefix + jb.JobNumber + "_V" + EngineerVisitID + "-", Trans).Table.Rows.Count + 1);
                                }
                                else
                                {
                                    oOrder.SetOrderReference = userPrefix + jb.JobNumber + "_V" + EngineerVisitID + "-" + (App.DB.Order.Order_Get_ByRef(userPrefix + jb.JobNumber + "_V" + EngineerVisitID + "-").Table.Rows.Count + 1);
                                }

                                oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.Job);
                                oOrder.SetUserID = App.loggedInUser.UserID;
                                oOrder.DeliveryDeadline = dtpDeadline.Value.Date;
                                oOrder.DatePlaced = DateAndTime.Now;
                                if (chkAwaiting.Checked)
                                {
                                    oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                                }
                                else
                                {
                                    oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed);
                                    chkDoNotConsolidate.Checked = true;
                                }

                                oOrder.SetDepartmentRef = txtDepartment.Text;
                                if (Trans is object)
                                {
                                    oOrder = App.DB.Order.Insert(oOrder, Trans);
                                }
                                else
                                {
                                    oOrder = App.DB.Order.Insert(oOrder);
                                }

                                foreach (DataRow drCharge in ChargesDataView.Table.Rows)
                                {
                                    var oOrderCharge = new Entity.OrderCharges.OrderCharge();
                                    oOrderCharge.SetAmount = drCharge["Amount"];
                                    oOrderCharge.SetOrderChargeTypeID = drCharge["OrderChargeTypeID"];
                                    oOrderCharge.SetOrderID = oOrder.OrderID;
                                    oOrderCharge.SetReference = drCharge["Reference"];
                                    App.DB.OrderCharge.Insert(oOrderCharge);
                                }

                                if (App.ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int warehouseID = App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse, Trans);
                                    if (warehouseID > 0)
                                    {
                                        oEngineerVisitOrder.SetWarehouseID = warehouseID;
                                    }
                                }

                                oEngineerVisitOrder.SetEngineerVisitID = EngineerVisitID;
                                oEngineerVisitOrder.SetOrderID = oOrder.OrderID;
                                if (Trans is object)
                                {
                                    oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, Trans);
                                }
                                else
                                {
                                    oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder);
                                }

                                Entity.EngineerVisits.EngineerVisit oEngineerVisit;
                                if (Trans is object)
                                {
                                    oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID, Trans);
                                }
                                else
                                {
                                    oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID);
                                }

                                if (oEngineerVisit.StatusEnumID < Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled))
                                {
                                    oEngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts);
                                    if (Trans is object)
                                    {
                                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true, Trans);
                                    }
                                    else
                                    {
                                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                                    }
                                }

                                orders.Add(new object[] { oOrder.OrderID, EngineerVisitID });
                                SupplierList.Add(supplierRow["SupplierID"], oOrder);
                            }

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(supplierRow["Type"], "Product", false)))
                            {
                                var oOrderProduct = new Entity.OrderProducts.OrderProduct();
                                oOrderProduct.SetOrderID = ((Entity.Orders.Order)SupplierList[supplierRow["SupplierID"]]).OrderID;
                                oOrderProduct.SetBuyPrice = supplierRow["BuyPrice"];
                                oOrderProduct.SetSellPrice = supplierRow["SellPrice"];
                                oOrderProduct.SetQuantity = supplierRow["QuantityToOrder"];
                                oOrderProduct.SetProductSupplierID = supplierRow["GetID"];
                                if (Trans is object)
                                {
                                    oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, !chkDoNotConsolidate.Checked, Trans);
                                }
                                else
                                {
                                    oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, !chkDoNotConsolidate.Checked);
                                }

                                try
                                {
                                    supplierRow["OrderItemID"] = oOrderProduct.OrderProductID;
                                    supplierRow["OrderLocationTypeID"] = Conversions.ToInteger(Entity.Sys.Enums.LocationType.Supplier);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                            else
                            {
                                var oOrderPart = new Entity.OrderParts.OrderPart();
                                oOrderPart.SetOrderID = ((Entity.Orders.Order)SupplierList[supplierRow["SupplierID"]]).OrderID;
                                oOrderPart.SetBuyPrice = supplierRow["BuyPrice"];
                                oOrderPart.SetSellPrice = supplierRow["SellPrice"];
                                oOrderPart.SetQuantity = supplierRow["QuantityToOrder"];
                                oOrderPart.SetPartSupplierID = supplierRow["GetID"];
                                if (Trans is object)
                                {
                                    oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !chkDoNotConsolidate.Checked, Trans);
                                }
                                else
                                {
                                    oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !chkDoNotConsolidate.Checked);
                                }

                                try
                                {
                                    supplierRow["OrderItemID"] = oOrderPart.OrderPartID;
                                    supplierRow["OrderLocationTypeID"] = Conversions.ToInteger(Entity.Sys.Enums.LocationType.Supplier);
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        var LocationList = new Hashtable();
                        foreach (DataRow locationRow in PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3"))
                        {
                            if (!LocationList.Contains(locationRow["GetID"]))
                            {
                                var oEngineerVisitOrder = new Entity.EngineerVisitOrders.EngineerVisitOrder();
                                Entity.Jobs.Job jb;
                                if (Trans is object)
                                {
                                    jb = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID, Trans);
                                }
                                else
                                {
                                    jb = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisitID);
                                }

                                var oOrder = new Entity.Orders.Order();
                                if (Trans is object)
                                {
                                    oOrder.SetOrderReference = userPrefix + jb.JobNumber + "_V" + EngineerVisitID + "-" + (App.DB.Order.Order_Get_ByRef(userPrefix + jb.JobNumber + "_V" + EngineerVisitID + "-", Trans).Table.Rows.Count + 1);
                                }
                                else
                                {
                                    oOrder.SetOrderReference = userPrefix + jb.JobNumber + "_V" + EngineerVisitID + "-" + (App.DB.Order.Order_Get_ByRef(userPrefix + jb.JobNumber + "_V" + EngineerVisitID + "-").Table.Rows.Count + 1);
                                }

                                oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.Job);
                                oOrder.SetUserID = App.loggedInUser.UserID;
                                oOrder.DeliveryDeadline = dtpDeadline.Value.Date;
                                oOrder.DatePlaced = DateAndTime.Now;
                                if (chkAwaiting.Checked)
                                {
                                    oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                                }
                                else
                                {
                                    oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed);
                                    chkDoNotConsolidate.Checked = true;
                                }

                                if (Trans is object)
                                {
                                    oOrder = App.DB.Order.Insert(oOrder, Trans);
                                }
                                else
                                {
                                    oOrder = App.DB.Order.Insert(oOrder);
                                }

                                if (App.ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int warehouseID;
                                    if (Trans is object)
                                    {
                                        warehouseID = App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse, Trans);
                                    }
                                    else
                                    {
                                        warehouseID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse));
                                    }

                                    if (warehouseID > 0)
                                    {
                                        oEngineerVisitOrder.SetWarehouseID = warehouseID;
                                    }
                                }

                                oEngineerVisitOrder.SetEngineerVisitID = EngineerVisitID;
                                oEngineerVisitOrder.SetOrderID = oOrder.OrderID;
                                if (Trans is object)
                                {
                                    oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, Trans);
                                }
                                else
                                {
                                    oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder);
                                }

                                Entity.EngineerVisits.EngineerVisit oEngineerVisit;
                                if (Trans is object)
                                {
                                    oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID, Trans);
                                }
                                else
                                {
                                    oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(EngineerVisitID);
                                }

                                if (oEngineerVisit.StatusEnumID < Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled))
                                {
                                    oEngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts);
                                    if (Trans is object)
                                    {
                                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true, Trans);
                                    }
                                    else
                                    {
                                        App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                                    }
                                }

                                orders.Add(new object[] { oOrder.OrderID, EngineerVisitID });
                                LocationList.Add(locationRow["GetID"], oOrder);
                            }

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(locationRow["Type"], "Product", false)))
                            {
                                var oOrderLocationProduct = new Entity.OrderLocationProduct.OrderLocationProduct();
                                oOrderLocationProduct.SetProductID = locationRow["PartProductID"];
                                oOrderLocationProduct.SetSellPrice = locationRow["SellPrice"];
                                oOrderLocationProduct.SetQuantity = locationRow["QuantityToOrder"];
                                oOrderLocationProduct.SetLocationID = locationRow["GetID"];
                                oOrderLocationProduct.SetOrderID = ((Entity.Orders.Order)LocationList[locationRow["GetID"]]).OrderID;
                                if (Trans is object)
                                {
                                    oOrderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !chkDoNotConsolidate.Checked, Trans);
                                }
                                else
                                {
                                    oOrderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !chkDoNotConsolidate.Checked);
                                }

                                locationRow["OrderItemID"] = oOrderLocationProduct.OrderLocationProductID;
                                locationRow["OrderLocationTypeID"] = Conversions.ToInteger(Entity.Sys.Enums.LocationType.Warehouse);
                                var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                oProductTransaction.IgnoreExceptionsOnSetMethods = true;
                                oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID;
                                oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockReserve);
                                oProductTransaction.SetProductID = oOrderLocationProduct.ProductID;
                                oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity;
                                oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID;
                                if (Trans is object)
                                {
                                    oProductTransaction = App.DB.ProductTransaction.Insert(oProductTransaction, Trans);
                                }
                                else
                                {
                                    oProductTransaction = App.DB.ProductTransaction.Insert(oProductTransaction);
                                }
                            }
                            else
                            {
                                var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                                oOrderLocationPart.SetPartID = locationRow["PartProductID"];
                                oOrderLocationPart.SetSellPrice = locationRow["SellPrice"];
                                oOrderLocationPart.SetQuantity = locationRow["QuantityToOrder"];
                                oOrderLocationPart.SetLocationID = locationRow["GetID"];
                                oOrderLocationPart.SetOrderID = ((Entity.Orders.Order)LocationList[locationRow["GetID"]]).OrderID;
                                if (Trans is object)
                                {
                                    oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, !chkDoNotConsolidate.Checked, Trans);
                                }
                                else
                                {
                                    oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, !chkDoNotConsolidate.Checked);
                                }

                                locationRow["OrderItemID"] = oOrderLocationPart.OrderLocationPartID;
                                locationRow["OrderLocationTypeID"] = Conversions.ToInteger(Entity.Sys.Enums.LocationType.Warehouse);
                                var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                                oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID;
                                oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockReserve);
                                oPartTransaction.SetPartID = oOrderLocationPart.PartID;
                                oPartTransaction.SetAmount = -oOrderLocationPart.Quantity;
                                oPartTransaction.SetLocationID = oOrderLocationPart.LocationID;
                                oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction, Trans);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow row in EngineerVisitsDataView.Table.Rows)
                        {
                            var SupplierList = new Hashtable();
                            foreach (DataRow supplierRow in PartsAndProducts.Table.Select("GetFrom = 1"))
                            {
                                if (!SupplierList.Contains(supplierRow["SupplierID"]))
                                {
                                    if (PartsAndProducts.Table.Select(Conversions.ToString("VisitCount = " + row["VisitCount"])).Length > 0)
                                    {
                                        var oOrder = new Entity.Orders.Order();
                                        oOrder.SetOrderReference = Conversions.ToString(userPrefix + "ENG-" + row["EngineerVisitID"] + "-") + (SupplierList.Count + 1);
                                        oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.Job);
                                        oOrder.SetUserID = App.loggedInUser.UserID;
                                        oOrder.DeliveryDeadline = dtpDeadline.Value.Date;
                                        oOrder.DatePlaced = DateAndTime.Now;
                                        if (chkAwaiting.Checked)
                                        {
                                            oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                                        }
                                        else
                                        {
                                            oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed);
                                            chkDoNotConsolidate.Checked = true;
                                        }

                                        oOrder.SetDepartmentRef = txtDepartment.Text;
                                        if (Trans is object)
                                        {
                                            oOrder = App.DB.Order.Insert(oOrder, Trans);
                                        }
                                        else
                                        {
                                            oOrder = App.DB.Order.Insert(oOrder);
                                        }

                                        var oEngineerVisitOrder = new Entity.EngineerVisitOrders.EngineerVisitOrder();
                                        if (App.ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            int warehouseID;
                                            if (Trans is object)
                                            {
                                                warehouseID = App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse, Trans);
                                            }
                                            else
                                            {
                                                warehouseID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse));
                                            }

                                            if (warehouseID > 0)
                                            {
                                                oEngineerVisitOrder.SetWarehouseID = warehouseID;
                                            }
                                        }

                                        oEngineerVisitOrder.SetEngineerVisitID = row["EngineerVisitID"];
                                        oEngineerVisitOrder.SetOrderID = oOrder.OrderID;
                                        if (Trans is object)
                                        {
                                            oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, Trans);
                                        }
                                        else
                                        {
                                            oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder);
                                        }

                                        Entity.EngineerVisits.EngineerVisit oEngineerVisit;
                                        if (Trans is object)
                                        {
                                            oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(row["EngineerVisitID"]), Trans);
                                        }
                                        else
                                        {
                                            oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(row["EngineerVisitID"]));
                                        }

                                        if (oEngineerVisit.StatusEnumID < Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled))
                                        {
                                            oEngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts);
                                            if (Trans is object)
                                            {
                                                App.DB.EngineerVisits.Update(oEngineerVisit, 0, true, Trans);
                                            }
                                            else
                                            {
                                                App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                                            }
                                        }

                                        SupplierList.Add(supplierRow["SupplierID"], oOrder);
                                        orders.Add(new object[] { oOrder.OrderID, row["EngineerVisitID"] });
                                    }
                                }

                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(supplierRow["VisitCount"], row["VisitCount"], false)))
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(supplierRow["Type"], "Product", false)))
                                    {
                                        var oOrderProduct = new Entity.OrderProducts.OrderProduct();
                                        oOrderProduct.SetOrderID = ((Entity.Orders.Order)SupplierList[supplierRow["SupplierID"]]).OrderID;
                                        oOrderProduct.SetBuyPrice = supplierRow["BuyPrice"];
                                        oOrderProduct.SetSellPrice = supplierRow["SellPrice"];
                                        oOrderProduct.SetQuantity = supplierRow["QuantityToOrder"];
                                        oOrderProduct.SetProductSupplierID = supplierRow["GetID"];
                                        if (Trans is object)
                                        {
                                            oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, !chkDoNotConsolidate.Checked, Trans);
                                        }
                                        else
                                        {
                                            oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, !chkDoNotConsolidate.Checked);
                                        }

                                        supplierRow["OrderItemID"] = oOrderProduct.OrderProductID;
                                    }
                                    else
                                    {
                                        var oOrderPart = new Entity.OrderParts.OrderPart();
                                        oOrderPart.SetOrderID = ((Entity.Orders.Order)SupplierList[supplierRow["SupplierID"]]).OrderID;
                                        oOrderPart.SetBuyPrice = supplierRow["BuyPrice"];
                                        oOrderPart.SetSellPrice = supplierRow["SellPrice"];
                                        oOrderPart.SetQuantity = supplierRow["QuantityToOrder"];
                                        oOrderPart.SetPartSupplierID = supplierRow["GetID"];
                                        if (Trans is object)
                                        {
                                            oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !chkDoNotConsolidate.Checked, Trans);
                                        }
                                        else
                                        {
                                            oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !chkDoNotConsolidate.Checked);
                                        }

                                        supplierRow["OrderItemID"] = oOrderPart.OrderPartID;
                                    }
                                }
                            }

                            var LocationList = new Hashtable();
                            foreach (DataRow locationRow in PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3"))
                            {
                                if (!LocationList.Contains(locationRow["GetID"]))
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(locationRow["VisitCount"], row["VisitCount"], false)))
                                    {
                                        var oOrder = new Entity.Orders.Order();
                                        oOrder.SetOrderReference = Conversions.ToString(userPrefix + "ENG-" + row["EngineerVisitID"] + "-") + (LocationList.Count + 1);
                                        oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.Job);
                                        oOrder.SetUserID = App.loggedInUser.UserID;
                                        oOrder.DeliveryDeadline = dtpDeadline.Value.Date;
                                        oOrder.DatePlaced = DateAndTime.Now;
                                        if (chkAwaiting.Checked)
                                        {
                                            oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                                        }
                                        else
                                        {
                                            oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed);
                                            chkDoNotConsolidate.Checked = true;
                                        }

                                        oOrder.SetDepartmentRef = txtDepartment.Text;
                                        if (Trans is object)
                                        {
                                            oOrder = App.DB.Order.Insert(oOrder, Trans);
                                        }
                                        else
                                        {
                                            oOrder = App.DB.Order.Insert(oOrder);
                                        }

                                        var oEngineerVisitOrder = new Entity.EngineerVisitOrders.EngineerVisitOrder();
                                        if (App.ShowMessage("Deliver items to warehouse?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            int warehouseID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblWarehouse));
                                            if (warehouseID > 0)
                                            {
                                                oEngineerVisitOrder.SetWarehouseID = warehouseID;
                                            }
                                        }

                                        oEngineerVisitOrder.SetEngineerVisitID = row["EngineerVisitID"];
                                        oEngineerVisitOrder.SetOrderID = oOrder.OrderID;
                                        if (Trans is object)
                                        {
                                            oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder, Trans);
                                        }
                                        else
                                        {
                                            oEngineerVisitOrder = App.DB.EngineerVisitOrder.Insert(oEngineerVisitOrder);
                                        }

                                        Entity.EngineerVisits.EngineerVisit oEngineerVisit;
                                        if (Trans is object)
                                        {
                                            oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(row["EngineerVisitID"]), Trans);
                                        }
                                        else
                                        {
                                            oEngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(Conversions.ToInteger(row["EngineerVisitID"]));
                                        }

                                        if (oEngineerVisit.StatusEnumID < Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Scheduled))
                                        {
                                            oEngineerVisit.SetStatusEnumID = Conversions.ToInteger(Entity.Sys.Enums.VisitStatus.Waiting_For_Parts);
                                            if (Trans is object)
                                            {
                                                App.DB.EngineerVisits.Update(oEngineerVisit, 0, true, Trans);
                                            }
                                            else
                                            {
                                                App.DB.EngineerVisits.Update(oEngineerVisit, 0, true);
                                            }
                                        }

                                        LocationList.Add(locationRow["GetID"], oOrder);
                                        orders.Add(new object[] { oOrder.OrderID, row["EngineerVisitID"] });
                                    }
                                }

                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(locationRow["VisitCount"], row["VisitCount"], false)))
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(locationRow["Type"], "Product", false)))
                                    {
                                        var oOrderLocationProduct = new Entity.OrderLocationProduct.OrderLocationProduct();
                                        oOrderLocationProduct.SetProductID = locationRow["PartProductID"];
                                        oOrderLocationProduct.SetSellPrice = locationRow["SellPrice"];
                                        oOrderLocationProduct.SetQuantity = locationRow["QuantityToOrder"];
                                        oOrderLocationProduct.SetLocationID = locationRow["GetID"];
                                        oOrderLocationProduct.SetOrderID = ((Entity.Orders.Order)LocationList[locationRow["GetID"]]).OrderID;
                                        if (Trans is object)
                                        {
                                            oOrderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !chkDoNotConsolidate.Checked, Trans);
                                        }
                                        else
                                        {
                                            oOrderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !chkDoNotConsolidate.Checked);
                                        }

                                        locationRow["OrderItemID"] = oOrderLocationProduct.OrderLocationProductID;
                                        var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                        oProductTransaction.IgnoreExceptionsOnSetMethods = true;
                                        oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID;
                                        oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockReserve);
                                        oProductTransaction.SetProductID = oOrderLocationProduct.ProductID;
                                        oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity;
                                        oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID;
                                    }
                                    else
                                    {
                                        var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                                        oOrderLocationPart.SetPartID = locationRow["PartProductID"];
                                        oOrderLocationPart.SetSellPrice = locationRow["SellPrice"];
                                        oOrderLocationPart.SetQuantity = locationRow["QuantityToOrder"];
                                        oOrderLocationPart.SetLocationID = locationRow["GetID"];
                                        oOrderLocationPart.SetOrderID = ((Entity.Orders.Order)LocationList[locationRow["GetID"]]).OrderID;
                                        if (Trans is object)
                                        {
                                            oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, !chkDoNotConsolidate.Checked, Trans);
                                        }
                                        else
                                        {
                                            oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, !chkDoNotConsolidate.Checked);
                                        }

                                        locationRow["OrderItemID"] = oOrderLocationPart.OrderLocationPartID;
                                        var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                        oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                                        oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID;
                                        oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockReserve);
                                        oPartTransaction.SetPartID = oOrderLocationPart.PartID;
                                        oPartTransaction.SetAmount = -oOrderLocationPart.Quantity;
                                        oPartTransaction.SetLocationID = oOrderLocationPart.LocationID;
                                        if (Trans is object)
                                        {
                                            oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction, Trans);
                                        }
                                        else
                                        {
                                            oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (NeedsTransaction == true)
                    {
                        // CYCLE THROUGH ORDERS

                        foreach (DataRow row in PartsAndProducts.Table.Rows)
                        {
                            row.AcceptChanges();
                            if (Information.IsDBNull(row["Quantity"]))
                            {
                                row["Quantity"] = row["QuantityToOrder"];
                            }

                            App.DB.EngineerVisitPartProductAllocated.UpdateOne(Conversions.ToInteger(row["ID"]), EngineerVisitID, Conversions.ToString(row["Type"]), Conversions.ToInteger(row["Quantity"]), Conversions.ToInteger(row["OrderItemID"]), Conversions.ToInteger(row["PartProductID"]), Entity.Sys.Helper.MakeIntegerValid(row["OrderLocationTypeID"]), Trans);
                        }

                        Trans.Commit();
                    }
                }
                else
                {
                    // CUSTOMER
                    var SupplierList = new Hashtable();
                    foreach (DataRow supplierRow in PartsAndProducts.Table.Select("GetFrom = 1"))
                    {
                        if (!SupplierList.Contains(supplierRow["SupplierID"]))
                        {
                            var oOrder = new Entity.Orders.Order();
                            var oCustomerOrder = new Entity.CustomerOrders.CustomerOrder();
                            Entity.SiteOrders.SiteOrder oSiteOrder;
                            Entity.OrderLocations.OrderLocation oOrderLocation;
                            oOrder.SetOrderReference = userPrefix + QuoteOrder.CustomerRef + "-" + (SupplierList.Count + 1);
                            oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.Customer);
                            oOrder.SetUserID = App.loggedInUser.UserID;
                            oOrder.DeliveryDeadline = dtpDeadline.Value.Date;
                            oOrder.DatePlaced = DateAndTime.Now;
                            if (chkAwaiting.Checked)
                            {
                                oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                            }
                            else
                            {
                                oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed);
                                chkDoNotConsolidate.Checked = true;
                            }

                            oOrder.SetSpecialInstructions = QuoteOrder.SpecialInstructions;
                            oOrder.SetContactID = QuoteOrder.ContactID;
                            oOrder.SetInvoiceAddressID = QuoteOrder.InvoiceAddressID;
                            oOrder.SetAllocatedToUser = QuoteOrder.AllocatedToUser;
                            if (Trans is object)
                            {
                                oOrder = App.DB.Order.Insert(oOrder, Trans);
                            }
                            else
                            {
                                oOrder = App.DB.Order.Insert(oOrder);
                            }

                            oCustomerOrder.SetCustomerID = QuoteOrder.CustomerID;
                            oCustomerOrder.SetOrderID = oOrder.OrderID;
                            if (Trans is object)
                            {
                                oCustomerOrder = App.DB.CustomerOrder.Insert(oCustomerOrder, Trans);
                            }
                            else
                            {
                                oCustomerOrder = App.DB.CustomerOrder.Insert(oCustomerOrder);
                            }

                            if (QuoteOrder is object)
                            {
                                if (QuoteOrder.PropertyID > 0)
                                {
                                    oSiteOrder = new Entity.SiteOrders.SiteOrder();
                                    oSiteOrder.SetOrderID = oOrder.OrderID;
                                    oSiteOrder.SetSiteID = QuoteOrder.PropertyID;
                                    if (Trans is object)
                                    {
                                        oSiteOrder = App.DB.SiteOrder.Insert(oSiteOrder, Trans);
                                    }
                                    else
                                    {
                                        oSiteOrder = App.DB.SiteOrder.Insert(oSiteOrder);
                                    }
                                }
                                else
                                {
                                    oOrderLocation = new Entity.OrderLocations.OrderLocation();
                                    if (Trans is object)
                                    {
                                        oOrderLocation.SetLocationID = App.DB.Warehouse.Warehouse_GetDV(QuoteOrder.WarehouseID, Trans).Table.Rows[0]["LocationID"];
                                    }
                                    else
                                    {
                                        oOrderLocation.SetLocationID = App.DB.Warehouse.Warehouse_GetDV(QuoteOrder.WarehouseID).Table.Rows[0]["LocationID"];
                                    }

                                    oOrderLocation.SetOrderID = oOrder.OrderID;
                                    if (Trans is object)
                                    {
                                        oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation, Trans);
                                    }
                                    else
                                    {
                                        oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                                    }
                                }
                            }

                            SupplierList.Add(supplierRow["SupplierID"], oOrder);
                            orders.Add(new object[] { oOrder.OrderID, QuoteOrder.PropertyID });
                        }

                        foreach (DataRow pricerequestRow in PriceRequestItemsDataView.Table.Rows)
                        {
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(pricerequestRow["SupplierID"], supplierRow["SupplierID"], false)))
                            {
                                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(pricerequestRow["Included"], "1", false)))
                                {
                                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(pricerequestRow["Type"], "Product", false)))
                                    {
                                        var oOrderProduct = new Entity.OrderProducts.OrderProduct();
                                        oOrderProduct.SetOrderID = ((Entity.Orders.Order)SupplierList[supplierRow["SupplierID"]]).OrderID;
                                        oOrderProduct.SetBuyPrice = pricerequestRow["BuyPrice"];
                                        oOrderProduct.SetSellPrice = pricerequestRow["SellPrice"];
                                        oOrderProduct.SetQuantity = 1;
                                        oOrderProduct.SetProductSupplierID = pricerequestRow["ProductSupplierID"];
                                        if (Trans is object)
                                        {
                                            oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, !chkDoNotConsolidate.Checked, Trans);
                                        }
                                        else
                                        {
                                            oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, !chkDoNotConsolidate.Checked);
                                        }
                                    }
                                    else
                                    {
                                        var oOrderPart = new Entity.OrderParts.OrderPart();
                                        oOrderPart.SetOrderID = ((Entity.Orders.Order)SupplierList[supplierRow["SupplierID"]]).OrderID;
                                        oOrderPart.SetBuyPrice = pricerequestRow["BuyPrice"];
                                        oOrderPart.SetSellPrice = pricerequestRow["SellPrice"];
                                        oOrderPart.SetQuantity = 1;
                                        oOrderPart.SetPartSupplierID = pricerequestRow["PartSupplierID"];
                                        if (Trans is object)
                                        {
                                            oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !chkDoNotConsolidate.Checked, Trans);
                                        }
                                        else
                                        {
                                            oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !chkDoNotConsolidate.Checked);
                                        }
                                    }
                                }
                            }
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(supplierRow["Type"], "Product", false)))
                        {
                            var oOrderProduct = new Entity.OrderProducts.OrderProduct();
                            oOrderProduct.SetOrderID = ((Entity.Orders.Order)SupplierList[supplierRow["SupplierID"]]).OrderID;
                            oOrderProduct.SetBuyPrice = supplierRow["BuyPrice"];
                            oOrderProduct.SetSellPrice = supplierRow["SellPrice"];
                            oOrderProduct.SetQuantity = supplierRow["QuantityToOrder"];
                            oOrderProduct.SetProductSupplierID = supplierRow["GetID"];
                            if (Trans is object)
                            {
                                oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, !chkDoNotConsolidate.Checked, Trans);
                            }
                            else
                            {
                                oOrderProduct = App.DB.OrderProduct.Insert(oOrderProduct, !chkDoNotConsolidate.Checked);
                            }
                        }
                        else
                        {
                            var oOrderPart = new Entity.OrderParts.OrderPart();
                            oOrderPart.SetOrderID = ((Entity.Orders.Order)SupplierList[supplierRow["SupplierID"]]).OrderID;
                            oOrderPart.SetBuyPrice = supplierRow["BuyPrice"];
                            oOrderPart.SetSellPrice = supplierRow["SellPrice"];
                            oOrderPart.SetQuantity = supplierRow["QuantityToOrder"];
                            oOrderPart.SetPartSupplierID = supplierRow["GetID"];
                            if (Trans is object)
                            {
                                oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !chkDoNotConsolidate.Checked, Trans);
                            }
                            else
                            {
                                oOrderPart = App.DB.OrderPart.Insert(oOrderPart, !chkDoNotConsolidate.Checked);
                            }
                        }
                    }

                    var LocationList = new Hashtable();
                    foreach (DataRow locationRow in PartsAndProducts.Table.Select("GetFrom = 2 OR GetFrom = 3"))
                    {
                        if (!LocationList.Contains(locationRow["GetID"]))
                        {
                            var oOrder = new Entity.Orders.Order();
                            var oCustomerOrder = new Entity.CustomerOrders.CustomerOrder();
                            Entity.SiteOrders.SiteOrder oSiteOrder;
                            Entity.OrderLocations.OrderLocation oOrderLocation;
                            oOrder.SetOrderReference = QuoteOrder.CustomerRef + "-" + (LocationList.Count + 1);
                            oOrder.SetOrderTypeID = Conversions.ToInteger(Entity.Sys.Enums.OrderType.Customer);
                            oOrder.SetUserID = App.loggedInUser.UserID;
                            oOrder.DeliveryDeadline = dtpDeadline.Value.Date;
                            oOrder.DatePlaced = DateAndTime.Now;
                            if (chkAwaiting.Checked)
                            {
                                oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.AwaitingConfirmation);
                            }
                            else
                            {
                                oOrder.SetOrderStatusID = Conversions.ToInteger(Entity.Sys.Enums.OrderStatus.Confirmed);
                                chkDoNotConsolidate.Checked = true;
                            }

                            oOrder.SetSpecialInstructions = QuoteOrder.SpecialInstructions;
                            oOrder.SetContactID = QuoteOrder.ContactID;
                            oOrder.SetInvoiceAddressID = QuoteOrder.InvoiceAddressID;
                            oOrder.SetAllocatedToUser = QuoteOrder.AllocatedToUser;
                            if (Trans is object)
                            {
                                oOrder = App.DB.Order.Insert(oOrder, Trans);
                            }
                            else
                            {
                                oOrder = App.DB.Order.Insert(oOrder);
                            }

                            oCustomerOrder.SetCustomerID = QuoteOrder.CustomerID;
                            oCustomerOrder.SetOrderID = oOrder.OrderID;
                            if (Trans is object)
                            {
                                oCustomerOrder = App.DB.CustomerOrder.Insert(oCustomerOrder, Trans);
                            }
                            else
                            {
                                oCustomerOrder = App.DB.CustomerOrder.Insert(oCustomerOrder);
                            }

                            if (QuoteOrder is object)
                            {
                                if (QuoteOrder.PropertyID > 0)
                                {
                                    oSiteOrder = new Entity.SiteOrders.SiteOrder();
                                    oSiteOrder.SetOrderID = oOrder.OrderID;
                                    oSiteOrder.SetSiteID = QuoteOrder.PropertyID;
                                    if (Trans is object)
                                    {
                                        oSiteOrder = App.DB.SiteOrder.Insert(oSiteOrder, Trans);
                                    }
                                    else
                                    {
                                        oSiteOrder = App.DB.SiteOrder.Insert(oSiteOrder);
                                    }
                                }
                                else
                                {
                                    oOrderLocation = new Entity.OrderLocations.OrderLocation();
                                    if (Trans is object)
                                    {
                                        oOrderLocation.SetLocationID = App.DB.Warehouse.Warehouse_GetDV(QuoteOrder.WarehouseID, Trans).Table.Rows[0]["LocationID"];
                                    }
                                    else
                                    {
                                        oOrderLocation.SetLocationID = App.DB.Warehouse.Warehouse_GetDV(QuoteOrder.WarehouseID).Table.Rows[0]["LocationID"];
                                    }

                                    oOrderLocation.SetOrderID = oOrder.OrderID;
                                    if (Trans is object)
                                    {
                                        oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation, Trans);
                                    }
                                    else
                                    {
                                        oOrderLocation = App.DB.OrderLocation.Insert(oOrderLocation);
                                    }
                                }
                            }

                            LocationList.Add(locationRow["GetID"], oOrder);
                            orders.Add(new object[] { oOrder.OrderID, QuoteOrder.PropertyID });
                        }

                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(locationRow["Type"], "Product", false)))
                        {
                            var oOrderLocationProduct = new Entity.OrderLocationProduct.OrderLocationProduct();
                            oOrderLocationProduct.SetProductID = locationRow["PartProductID"];
                            oOrderLocationProduct.SetSellPrice = locationRow["SellPrice"];
                            oOrderLocationProduct.SetQuantity = locationRow["QuantityToOrder"];
                            oOrderLocationProduct.SetLocationID = locationRow["GetID"];
                            oOrderLocationProduct.SetOrderID = ((Entity.Orders.Order)LocationList[locationRow["GetID"]]).OrderID;
                            if (Trans is object)
                            {
                                oOrderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !chkDoNotConsolidate.Checked, Trans);
                            }
                            else
                            {
                                oOrderLocationProduct = App.DB.OrderLocationProduct.Insert(oOrderLocationProduct, !chkDoNotConsolidate.Checked);
                            }

                            var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                            oProductTransaction.IgnoreExceptionsOnSetMethods = true;
                            oProductTransaction.SetOrderLocationProductID = oOrderLocationProduct.OrderLocationProductID;
                            oProductTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockReserve);
                            oProductTransaction.SetProductID = oOrderLocationProduct.ProductID;
                            oProductTransaction.SetAmount = -oOrderLocationProduct.Quantity;
                            oProductTransaction.SetLocationID = oOrderLocationProduct.LocationID;
                        }
                        else
                        {
                            var oOrderLocationPart = new Entity.OrderLocationPart.OrderLocationPart();
                            oOrderLocationPart.SetPartID = locationRow["PartProductID"];
                            oOrderLocationPart.SetSellPrice = locationRow["SellPrice"];
                            oOrderLocationPart.SetQuantity = locationRow["QuantityToOrder"];
                            oOrderLocationPart.SetLocationID = locationRow["GetID"];
                            oOrderLocationPart.SetOrderID = ((Entity.Orders.Order)LocationList[locationRow["GetID"]]).OrderID;
                            if (Trans is object)
                            {
                                oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, !chkDoNotConsolidate.Checked, Trans);
                            }
                            else
                            {
                                oOrderLocationPart = App.DB.OrderLocationPart.Insert(oOrderLocationPart, !chkDoNotConsolidate.Checked);
                            }

                            var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                            oPartTransaction.IgnoreExceptionsOnSetMethods = true;
                            oPartTransaction.SetOrderLocationPartID = oOrderLocationPart.OrderLocationPartID;
                            oPartTransaction.SetTransactionTypeID = Conversions.ToInteger(Entity.Sys.Enums.Transaction.StockReserve);
                            oPartTransaction.SetPartID = oOrderLocationPart.PartID;
                            oPartTransaction.SetAmount = -oOrderLocationPart.Quantity;
                            oPartTransaction.SetLocationID = oOrderLocationPart.LocationID;
                            if (Trans is object)
                            {
                                oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction, Trans);
                            }
                            else
                            {
                                oPartTransaction = App.DB.PartTransaction.Insert(oPartTransaction);
                            }
                        }
                    }
                }
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                errorOccured = true;
            }
            catch (Exception ex)
            {
                if (Trans is object)
                {
                    Trans.Rollback();
                }

                if (con is object)
                {
                    con.Close();
                }

                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorOccured = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (!(OrderType == Entity.Sys.Enums.OrderType.Job))
            {
                if (orders.Count == 1)
                {
                    App.ShowForm(typeof(FRMOrder), false, new object[] { ((object[])orders[0])[0], ((object[])orders[0])[1], 0, this }, true);
                }
                else if (orders.Count > 1)
                {
                    var orderIDs = new ArrayList();
                    foreach (ArrayList order in orders)
                        orderIDs.Add(order[0]);
                    App.ShowForm(typeof(FRMOrderManager), false, new object[] { null, orderIDs });
                }
            }

            if (!(errorOccured == true))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            int partID;
            if (Trans is object)
            {
                partID = App.FindRecord(Entity.Sys.Enums.TableNames.tblPart, Trans);
            }
            else
            {
                partID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblPart));
            }

            if (partID > 0)
            {
                Entity.Parts.Part oPart;
                if (Trans is object)
                {
                    oPart = App.DB.Part.Part_Get(partID, Trans);
                }
                else
                {
                    oPart = App.DB.Part.Part_Get(partID);
                }

                var newRow = PartsAndProducts.Table.NewRow();
                newRow["PartProductID"] = oPart.PartID;
                newRow["Number"] = oPart.Number;
                newRow["Name"] = oPart.Name;
                newRow["Type"] = "Part";
                PartsAndProducts.Table.Rows.Add(newRow);
                PartsAndProducts.Table.AcceptChanges();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to remove this item from the order?";
            if (OrderType == Entity.Sys.Enums.OrderType.Job)
            {
                msg += Constants.vbCrLf + "Removing this item will remove it from the job";
            }

            if (App.ShowMessage(msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SelectedPartProductDataRow is object)
                {
                    PartsAndProducts.Table.Rows.Remove(SelectedPartProductDataRow);
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            int productID;
            if (Trans is object)
            {
                productID = App.FindRecord(Entity.Sys.Enums.TableNames.tblProduct, Trans);
            }
            else
            {
                productID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblProduct));
            }

            if (productID > 0)
            {
                Entity.Products.Product oProduct;
                if (Trans is object)
                {
                    oProduct = App.DB.Product.Product_Get(productID, Trans);
                }
                else
                {
                    oProduct = App.DB.Product.Product_Get(productID);
                }

                var newRow = PartsAndProducts.Table.NewRow();
                newRow["PartProductID"] = oProduct.ProductID;
                newRow["Name"] = oProduct.Name;
                newRow["Number"] = oProduct.Number;
                newRow["Type"] = "Product";
                PartsAndProducts.Table.Rows.Add(newRow);
                PartsAndProducts.Table.AcceptChanges();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Type"));
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("Number"));
            dt.Columns.Add(new DataColumn("Quantity"));
            dt.Columns.Add(new DataColumn("Location"));
            dt.Columns.Add(new DataColumn("Shelf"));
            dt.Columns.Add(new DataColumn("Bin"));
            foreach (DataRow row in PartsAndProducts.Table.Rows)
            {
                var r = dt.NewRow();
                r["Type"] = row["Type"];
                r["Name"] = row["Name"];
                r["Number"] = row["Number"];
                r["Quantity"] = row["Quantity"];
                r["Location"] = row["GetFromText"];
                r["Shelf"] = row["Shelf"];
                r["Bin"] = row["Bin"];
                dt.Rows.Add(r);
            }

            ExportHelper.Export(dt, "Job Order Pick List", Enums.ExportType.XLS);
        }

        public void RefreshDatagrid()
        {
            ChargesDataView = App.DB.OrderCharge.OrderCharge_GetForOrder(0);
            PageState = Entity.Sys.Enums.FormState.Insert;
        }

        private void dgCharges_Click(object sender, EventArgs e)
        {
            if (SelectedChargeDataRow is null)
            {
                PageState = Entity.Sys.Enums.FormState.Insert;
                return;
            }

            PageState = Entity.Sys.Enums.FormState.Update;
            txtAmount.Text = Conversions.ToString(SelectedChargeDataRow["Amount"]);
            var argcombo = cboChargeType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(SelectedChargeDataRow["OrderChargeTypeID"]));
        }

        private void btnChargesSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var oOrderCharge = new Entity.OrderCharges.OrderCharge();
                oOrderCharge.IgnoreExceptionsOnSetMethods = true;
                oOrderCharge.SetAmount = txtAmount.Text.Trim();
                oOrderCharge.SetOrderChargeTypeID = Combo.get_GetSelectedItemValue(cboChargeType);
                oOrderCharge.SetOrderID = 0;
                var oValidator = new Entity.OrderCharges.OrderChargeValidator();
                oValidator.Validate(oOrderCharge);
                var switchExpr = PageState;
                switch (switchExpr)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            DataRow drNew;
                            drNew = ChargesDataView.Table.NewRow();
                            drNew["Amount"] = oOrderCharge.Amount;
                            drNew["Reference"] = oOrderCharge.Reference;
                            drNew["ChargeType"] = Combo.get_GetSelectedItemDescription(cboChargeType);
                            drNew["OrderChargeTypeID"] = Combo.get_GetSelectedItemValue(cboChargeType);
                            ChargesDataView.Table.Rows.Add(drNew);
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            SelectedChargeDataRow["Amount"] = oOrderCharge.Amount;
                            SelectedChargeDataRow["Reference"] = oOrderCharge.Reference;
                            SelectedChargeDataRow["ChargeType"] = Combo.get_GetSelectedItemDescription(cboChargeType);
                            SelectedChargeDataRow["OrderChargeTypeID"] = Combo.get_GetSelectedItemValue(cboChargeType);
                            break;
                        }
                }

                PageState = Entity.Sys.Enums.FormState.Insert;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedChargeDataRow is null)
            {
                App.ShowMessage("Please select a charge to remove", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PageState = Entity.Sys.Enums.FormState.Insert;
                return;
            }

            if (App.ShowMessage("Are you sure you want to remove this charge?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            ChargesDataView.Table.Rows.Remove(SelectedChargeDataRow);
        }

        void IForm.LoadMe(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}