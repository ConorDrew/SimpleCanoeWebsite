using FSM.Entity.Sys;
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
    public class FRMStockMoved : FRMBaseForm, IForm
    {
        

        public FRMStockMoved() : base()
        {
            
            
            base.Load += FRMStockMoved_Load;

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
        private GroupBox _grpFilter;

        internal GroupBox grpFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpFilter != null)
                {
                }

                _grpFilter = value;
                if (_grpFilter != null)
                {
                }
            }
        }

        private GroupBox _grpAudit;

        internal GroupBox grpAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAudit != null)
                {
                }

                _grpAudit = value;
                if (_grpAudit != null)
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

        private Button _btnExport;

        internal Button btnExport
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExport;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExport != null)
                {
                    _btnExport.Click -= btnExport_Click;
                }

                _btnExport = value;
                if (_btnExport != null)
                {
                    _btnExport.Click += btnExport_Click;
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

        private RadioButton _radBoth;

        internal RadioButton radBoth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radBoth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radBoth != null)
                {
                }

                _radBoth = value;
                if (_radBoth != null)
                {
                }
            }
        }

        private RadioButton _radProducts;

        internal RadioButton radProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radProducts != null)
                {
                }

                _radProducts = value;
                if (_radProducts != null)
                {
                }
            }
        }

        private RadioButton _radParts;

        internal RadioButton radParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radParts != null)
                {
                }

                _radParts = value;
                if (_radParts != null)
                {
                }
            }
        }

        private RadioButton _radFromVan;

        internal RadioButton radFromVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radFromVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radFromVan != null)
                {
                    _radFromVan.CheckedChanged -= radFromVan_CheckedChanged;
                }

                _radFromVan = value;
                if (_radFromVan != null)
                {
                    _radFromVan.CheckedChanged += radFromVan_CheckedChanged;
                }
            }
        }

        private RadioButton _radFromWarehouse;

        internal RadioButton radFromWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radFromWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radFromWarehouse != null)
                {
                    _radFromWarehouse.CheckedChanged -= radFromWarehouse_CheckedChanged;
                }

                _radFromWarehouse = value;
                if (_radFromWarehouse != null)
                {
                    _radFromWarehouse.CheckedChanged += radFromWarehouse_CheckedChanged;
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

        private Button _btnRun;

        internal Button btnRun
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRun;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRun != null)
                {
                    _btnRun.Click -= btnRun_Click;
                }

                _btnRun = value;
                if (_btnRun != null)
                {
                    _btnRun.Click += btnRun_Click;
                }
            }
        }

        private ComboBox _cboTo;

        internal ComboBox cboTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTo != null)
                {
                }

                _cboTo = value;
                if (_cboTo != null)
                {
                }
            }
        }

        private RadioButton _radToVan;

        internal RadioButton radToVan
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radToVan;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radToVan != null)
                {
                    _radToVan.CheckedChanged -= radToVan_CheckedChanged;
                }

                _radToVan = value;
                if (_radToVan != null)
                {
                    _radToVan.CheckedChanged += radToVan_CheckedChanged;
                }
            }
        }

        private RadioButton _radToWarehouse;

        internal RadioButton radToWarehouse
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _radToWarehouse;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_radToWarehouse != null)
                {
                    _radToWarehouse.CheckedChanged -= radToWarehouse_CheckedChanged;
                }

                _radToWarehouse = value;
                if (_radToWarehouse != null)
                {
                    _radToWarehouse.CheckedChanged += radToWarehouse_CheckedChanged;
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

        private ComboBox _cboFrom;

        internal ComboBox cboFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFrom != null)
                {
                }

                _cboFrom = value;
                if (_cboFrom != null)
                {
                }
            }
        }

        private Panel _Panel3;

        internal Panel Panel3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel3 != null)
                {
                }

                _Panel3 = value;
                if (_Panel3 != null)
                {
                }
            }
        }

        private Panel _Panel2;

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
                {
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
                {
                }
            }
        }

        private DataGrid _dgIPTAudit;

        internal DataGrid dgIPTAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgIPTAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgIPTAudit != null)
                {
                }

                _dgIPTAudit = value;
                if (_dgIPTAudit != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpAudit = new GroupBox();
            _dgIPTAudit = new DataGrid();
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _Panel3 = new Panel();
            _radToWarehouse = new RadioButton();
            _radToWarehouse.CheckedChanged += new EventHandler(radToWarehouse_CheckedChanged);
            _radToVan = new RadioButton();
            _radToVan.CheckedChanged += new EventHandler(radToVan_CheckedChanged);
            _Panel2 = new Panel();
            _radFromWarehouse = new RadioButton();
            _radFromWarehouse.CheckedChanged += new EventHandler(radFromWarehouse_CheckedChanged);
            _radFromVan = new RadioButton();
            _radFromVan.CheckedChanged += new EventHandler(radFromVan_CheckedChanged);
            _Panel1 = new Panel();
            _radParts = new RadioButton();
            _radProducts = new RadioButton();
            _radBoth = new RadioButton();
            _btnRun = new Button();
            _btnRun.Click += new EventHandler(btnRun_Click);
            _cboTo = new ComboBox();
            _Label4 = new Label();
            _cboFrom = new ComboBox();
            _Label3 = new Label();
            _txtName = new TextBox();
            _txtNumber = new TextBox();
            _Label2 = new Label();
            _Label1 = new Label();
            _txtReference = new TextBox();
            _Label6 = new Label();
            _grpAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgIPTAudit).BeginInit();
            _grpFilter.SuspendLayout();
            _Panel3.SuspendLayout();
            _Panel2.SuspendLayout();
            _Panel1.SuspendLayout();
            SuspendLayout();
            //
            // grpAudit
            //
            _grpAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAudit.Controls.Add(_dgIPTAudit);
            _grpAudit.Location = new Point(8, 152);
            _grpAudit.Name = "grpAudit";
            _grpAudit.Size = new Size(841, 278);
            _grpAudit.TabIndex = 1;
            _grpAudit.TabStop = false;
            _grpAudit.Text = "IPT Audit";
            //
            // dgIPTAudit
            //
            _dgIPTAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgIPTAudit.DataMember = "";
            _dgIPTAudit.HeaderForeColor = SystemColors.ControlText;
            _dgIPTAudit.Location = new Point(8, 19);
            _dgIPTAudit.Name = "dgIPTAudit";
            _dgIPTAudit.Size = new Size(825, 251);
            _dgIPTAudit.TabIndex = 0;
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 438);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 2;
            _btnExport.Text = "Export";
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_Panel3);
            _grpFilter.Controls.Add(_Panel2);
            _grpFilter.Controls.Add(_Panel1);
            _grpFilter.Controls.Add(_btnRun);
            _grpFilter.Controls.Add(_cboTo);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_cboFrom);
            _grpFilter.Controls.Add(_Label3);
            _grpFilter.Controls.Add(_txtName);
            _grpFilter.Controls.Add(_txtNumber);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_txtReference);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Location = new Point(8, 38);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(841, 108);
            _grpFilter.TabIndex = 0;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // Panel3
            //
            _Panel3.Controls.Add(_radToWarehouse);
            _Panel3.Controls.Add(_radToVan);
            _Panel3.Location = new Point(442, 50);
            _Panel3.Name = "Panel3";
            _Panel3.Size = new Size(196, 28);
            _Panel3.TabIndex = 27;
            //
            // radToWarehouse
            //
            _radToWarehouse.AutoSize = true;
            _radToWarehouse.Checked = true;
            _radToWarehouse.Location = new Point(3, 3);
            _radToWarehouse.Name = "radToWarehouse";
            _radToWarehouse.Size = new Size(88, 17);
            _radToWarehouse.TabIndex = 9;
            _radToWarehouse.TabStop = true;
            _radToWarehouse.Text = "Warehouse";
            _radToWarehouse.UseVisualStyleBackColor = true;
            //
            // radToVan
            //
            _radToVan.AutoSize = true;
            _radToVan.Location = new Point(98, 3);
            _radToVan.Name = "radToVan";
            _radToVan.Size = new Size(97, 17);
            _radToVan.TabIndex = 10;
            _radToVan.Text = "Stock Profile";
            _radToVan.UseVisualStyleBackColor = true;
            //
            // Panel2
            //
            _Panel2.Controls.Add(_radFromWarehouse);
            _Panel2.Controls.Add(_radFromVan);
            _Panel2.Location = new Point(441, 19);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(197, 26);
            _Panel2.TabIndex = 26;
            //
            // radFromWarehouse
            //
            _radFromWarehouse.AutoSize = true;
            _radFromWarehouse.Checked = true;
            _radFromWarehouse.Location = new Point(3, 3);
            _radFromWarehouse.Name = "radFromWarehouse";
            _radFromWarehouse.Size = new Size(88, 17);
            _radFromWarehouse.TabIndex = 6;
            _radFromWarehouse.TabStop = true;
            _radFromWarehouse.Text = "Warehouse";
            _radFromWarehouse.UseVisualStyleBackColor = true;
            //
            // radFromVan
            //
            _radFromVan.AutoSize = true;
            _radFromVan.Location = new Point(100, 3);
            _radFromVan.Name = "radFromVan";
            _radFromVan.Size = new Size(97, 17);
            _radFromVan.TabIndex = 7;
            _radFromVan.Text = "Stock Profile";
            _radFromVan.UseVisualStyleBackColor = true;
            //
            // Panel1
            //
            _Panel1.Controls.Add(_radParts);
            _Panel1.Controls.Add(_radProducts);
            _Panel1.Controls.Add(_radBoth);
            _Panel1.Location = new Point(5, 17);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(82, 82);
            _Panel1.TabIndex = 25;
            //
            // radParts
            //
            _radParts.AutoSize = true;
            _radParts.Location = new Point(3, 3);
            _radParts.Name = "radParts";
            _radParts.Size = new Size(54, 17);
            _radParts.TabIndex = 0;
            _radParts.Text = "Parts";
            _radParts.UseVisualStyleBackColor = true;
            //
            // radProducts
            //
            _radProducts.AutoSize = true;
            _radProducts.Location = new Point(3, 33);
            _radProducts.Name = "radProducts";
            _radProducts.Size = new Size(74, 17);
            _radProducts.TabIndex = 1;
            _radProducts.Text = "Products";
            _radProducts.UseVisualStyleBackColor = true;
            //
            // radBoth
            //
            _radBoth.AutoSize = true;
            _radBoth.Checked = true;
            _radBoth.Location = new Point(3, 60);
            _radBoth.Name = "radBoth";
            _radBoth.Size = new Size(51, 17);
            _radBoth.TabIndex = 2;
            _radBoth.TabStop = true;
            _radBoth.Text = "Both";
            _radBoth.UseVisualStyleBackColor = true;
            //
            // btnRun
            //
            _btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnRun.Location = new Point(781, 78);
            _btnRun.Name = "btnRun";
            _btnRun.Size = new Size(52, 23);
            _btnRun.TabIndex = 12;
            _btnRun.Text = "Run";
            _btnRun.UseVisualStyleBackColor = true;
            //
            // cboTo
            //
            _cboTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboTo.FormattingEnabled = true;
            _cboTo.Location = new Point(644, 49);
            _cboTo.Name = "cboTo";
            _cboTo.Size = new Size(189, 21);
            _cboTo.TabIndex = 11;
            //
            // Label4
            //
            _Label4.Location = new Point(358, 52);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(84, 18);
            _Label4.TabIndex = 24;
            _Label4.Text = "Moved To";
            //
            // cboFrom
            //
            _cboFrom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboFrom.FormattingEnabled = true;
            _cboFrom.Location = new Point(644, 22);
            _cboFrom.Name = "cboFrom";
            _cboFrom.Size = new Size(189, 21);
            _cboFrom.TabIndex = 8;
            //
            // Label3
            //
            _Label3.Location = new Point(358, 25);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(84, 18);
            _Label3.TabIndex = 20;
            _Label3.Text = "Moved From";
            //
            // txtName
            //
            _txtName.Location = new Point(158, 49);
            _txtName.Name = "txtName";
            _txtName.Size = new Size(194, 21);
            _txtName.TabIndex = 4;
            //
            // txtNumber
            //
            _txtNumber.Location = new Point(158, 22);
            _txtNumber.Name = "txtNumber";
            _txtNumber.Size = new Size(194, 21);
            _txtNumber.TabIndex = 3;
            //
            // Label2
            //
            _Label2.Location = new Point(87, 79);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(67, 18);
            _Label2.TabIndex = 11;
            _Label2.Text = "Reference";
            //
            // Label1
            //
            _Label1.Location = new Point(87, 52);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(88, 16);
            _Label1.TabIndex = 10;
            _Label1.Text = "Name";
            //
            // txtReference
            //
            _txtReference.Location = new Point(158, 76);
            _txtReference.Name = "txtReference";
            _txtReference.Size = new Size(194, 21);
            _txtReference.TabIndex = 5;
            //
            // Label6
            //
            _Label6.Location = new Point(87, 22);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Number";
            //
            // FRMStockMoved
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(857, 468);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpAudit);
            MinimumSize = new Size(873, 506);
            Name = "FRMStockMoved";
            Text = "Stock Moved Report";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_grpAudit, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            _grpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgIPTAudit).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            _Panel3.ResumeLayout(false);
            _Panel3.PerformLayout();
            _Panel2.ResumeLayout(false);
            _Panel2.PerformLayout();
            _Panel1.ResumeLayout(false);
            _Panel1.PerformLayout();
            ResumeLayout(false);
        }

        
        

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDataGrid();
            var argc = cboFrom;
            Combo.SetUpCombo(ref argc, App.DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            cboFrom.SelectedIndex = 0;
            var argc1 = cboTo;
            Combo.SetUpCombo(ref argc1, App.DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            cboTo.SelectedIndex = 0;
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

        
        
        private DataView _AuditDataview;

        private DataView AuditDataview
        {
            get
            {
                return _AuditDataview;
            }

            set
            {
                _AuditDataview = value;
                _AuditDataview.AllowNew = false;
                _AuditDataview.AllowEdit = false;
                _AuditDataview.AllowDelete = false;
                _AuditDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblIPTAudit.ToString();
                dgIPTAudit.DataSource = AuditDataview;
            }
        }

        private DataRow SelectedDataRow
        {
            get
            {
                if (!(dgIPTAudit.CurrentRowIndex == -1))
                {
                    return AuditDataview[dgIPTAudit.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        
        

        private void SetupDataGrid()
        {
            var tbStyle = dgIPTAudit.TableStyles[0];
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 50;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 150;
            Name.NullText = "";
            tbStyle.GridColumnStyles.Add(Name);
            var Number = new DataGridLabelColumn();
            Number.Format = "";
            Number.FormatInfo = null;
            Number.HeaderText = "Number";
            Number.MappingName = "Number";
            Number.ReadOnly = true;
            Number.Width = 75;
            Number.NullText = "";
            tbStyle.GridColumnStyles.Add(Number);
            var Reference = new DataGridLabelColumn();
            Reference.Format = "";
            Reference.FormatInfo = null;
            Reference.HeaderText = "Reference";
            Reference.MappingName = "Reference";
            Reference.ReadOnly = true;
            Reference.Width = 75;
            Reference.NullText = "";
            tbStyle.GridColumnStyles.Add(Reference);
            var Quantity = new DataGridLabelColumn();
            Quantity.Format = "";
            Quantity.FormatInfo = null;
            Quantity.HeaderText = "Moved";
            Quantity.MappingName = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 50;
            Quantity.NullText = "";
            tbStyle.GridColumnStyles.Add(Quantity);
            var MovedFrom = new DataGridLabelColumn();
            MovedFrom.Format = "";
            MovedFrom.FormatInfo = null;
            MovedFrom.HeaderText = "From";
            MovedFrom.MappingName = "MovedFrom";
            MovedFrom.ReadOnly = true;
            MovedFrom.Width = 100;
            MovedFrom.NullText = "";
            tbStyle.GridColumnStyles.Add(MovedFrom);
            var MovedTo = new DataGridLabelColumn();
            MovedTo.Format = "";
            MovedTo.FormatInfo = null;
            MovedTo.HeaderText = "To";
            MovedTo.MappingName = "MovedTo";
            MovedTo.ReadOnly = true;
            MovedTo.Width = 100;
            MovedTo.NullText = "";
            tbStyle.GridColumnStyles.Add(MovedTo);
            var MovedBy = new DataGridLabelColumn();
            MovedBy.Format = "";
            MovedBy.FormatInfo = null;
            MovedBy.HeaderText = "By";
            MovedBy.MappingName = "MovedBy";
            MovedBy.ReadOnly = true;
            MovedBy.Width = 100;
            MovedBy.NullText = "";
            tbStyle.GridColumnStyles.Add(MovedBy);
            var MovedOn = new DataGridLabelColumn();
            MovedOn.Format = "";
            MovedOn.FormatInfo = null;
            MovedOn.HeaderText = "On";
            MovedOn.MappingName = "MovedOn";
            MovedOn.ReadOnly = true;
            MovedOn.Width = 100;
            MovedOn.NullText = "";
            tbStyle.GridColumnStyles.Add(MovedOn);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblIPTAudit.ToString();
            dgIPTAudit.TableStyles.Add(tbStyle);
        }

        private void FRMStockMoved_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void radFromWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            if (radFromWarehouse.Checked)
            {
                var argc = cboFrom;
                Combo.SetUpCombo(ref argc, App.DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
                cboFrom.SelectedIndex = 0;
            }
        }

        private void radFromVan_CheckedChanged(object sender, EventArgs e)
        {
            if (radFromVan.Checked)
            {
                var argc = cboFrom;
                Combo.SetUpCombo(ref argc, App.DB.Van.Van_GetAll(false).Table, "LocationID", "Registration", Entity.Sys.Enums.ComboValues.No_Filter);
                cboFrom.SelectedIndex = 0;
            }
        }

        private void radToWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            if (radToWarehouse.Checked)
            {
                var argc = cboTo;
                Combo.SetUpCombo(ref argc, App.DB.Warehouse.Warehouse_GetAll().Table, "LocationID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
                cboTo.SelectedIndex = 0;
            }
        }

        private void radToVan_CheckedChanged(object sender, EventArgs e)
        {
            if (radToVan.Checked)
            {
                var argc = cboTo;
                Combo.SetUpCombo(ref argc, App.DB.Van.Van_GetAll(false).Table, "LocationID", "Registration", Entity.Sys.Enums.ComboValues.No_Filter);
                cboTo.SelectedIndex = 0;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            PopulateDatagrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        
        

        private void PopulateDatagrid()
        {
            try
            {
                string type = "Both";
                if (radParts.Checked)
                {
                    type = "Part";
                }
                else if (radProducts.Checked)
                {
                    type = "Product";
                }

                AuditDataview = App.DB.Location.IPT_Audit_Get(type, txtName.Text.Trim(), txtNumber.Text.Trim(), txtReference.Text.Trim(), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboFrom)), Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboTo)));
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Export()
        {
            if (AuditDataview is null)
            {
                App.ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (AuditDataview.Table is null)
            {
                App.ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (AuditDataview.Table.Rows.Count == 0)
            {
                App.ShowMessage("No data to export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var exportData = new DataTable();
            exportData.Columns.Add("Type");
            exportData.Columns.Add("Name");
            exportData.Columns.Add("Number");
            exportData.Columns.Add("Reference");
            exportData.Columns.Add("Moved");
            exportData.Columns.Add("From");
            exportData.Columns.Add("To");
            exportData.Columns.Add("By");
            exportData.Columns.Add("On");
            for (int itm = 0, loopTo = ((DataView)dgIPTAudit.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgIPTAudit.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["Type"] = SelectedDataRow["Type"];
                newRw["Name"] = SelectedDataRow["Name"];
                newRw["Number"] = SelectedDataRow["Number"];
                newRw["Reference"] = SelectedDataRow["Reference"];
                newRw["Moved"] = SelectedDataRow["Quantity"];
                newRw["From"] = SelectedDataRow["MovedFrom"];
                newRw["To"] = SelectedDataRow["MovedTo"];
                newRw["By"] = SelectedDataRow["MovedBy"];
                newRw["On"] = SelectedDataRow["MovedOn"];
                exportData.Rows.Add(newRw);
                dgIPTAudit.UnSelect(itm);
            }

            ExportHelper.Export(exportData, "Stock Moved Report", Enums.ExportType.XLS);
        }

        
    }
}