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

        private GroupBox _grpAudit;

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

        private Panel _Panel2;

        private Panel _Panel1;

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
            this._grpAudit = new System.Windows.Forms.GroupBox();
            this._dgIPTAudit = new System.Windows.Forms.DataGrid();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._Panel3 = new System.Windows.Forms.Panel();
            this._radToWarehouse = new System.Windows.Forms.RadioButton();
            this._radToVan = new System.Windows.Forms.RadioButton();
            this._Panel2 = new System.Windows.Forms.Panel();
            this._radFromWarehouse = new System.Windows.Forms.RadioButton();
            this._radFromVan = new System.Windows.Forms.RadioButton();
            this._Panel1 = new System.Windows.Forms.Panel();
            this._radParts = new System.Windows.Forms.RadioButton();
            this._radProducts = new System.Windows.Forms.RadioButton();
            this._radBoth = new System.Windows.Forms.RadioButton();
            this._btnRun = new System.Windows.Forms.Button();
            this._cboTo = new System.Windows.Forms.ComboBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._cboFrom = new System.Windows.Forms.ComboBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtNumber = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtReference = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._grpAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgIPTAudit)).BeginInit();
            this._grpFilter.SuspendLayout();
            this._Panel3.SuspendLayout();
            this._Panel2.SuspendLayout();
            this._Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpAudit
            // 
            this._grpAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpAudit.Controls.Add(this._dgIPTAudit);
            this._grpAudit.Location = new System.Drawing.Point(8, 126);
            this._grpAudit.Name = "_grpAudit";
            this._grpAudit.Size = new System.Drawing.Size(841, 304);
            this._grpAudit.TabIndex = 1;
            this._grpAudit.TabStop = false;
            this._grpAudit.Text = "IPT Audit";
            // 
            // _dgIPTAudit
            // 
            this._dgIPTAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgIPTAudit.DataMember = "";
            this._dgIPTAudit.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgIPTAudit.Location = new System.Drawing.Point(8, 19);
            this._dgIPTAudit.Name = "_dgIPTAudit";
            this._dgIPTAudit.Size = new System.Drawing.Size(825, 277);
            this._dgIPTAudit.TabIndex = 0;
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 438);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 2;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._Panel3);
            this._grpFilter.Controls.Add(this._Panel2);
            this._grpFilter.Controls.Add(this._Panel1);
            this._grpFilter.Controls.Add(this._btnRun);
            this._grpFilter.Controls.Add(this._cboTo);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._cboFrom);
            this._grpFilter.Controls.Add(this._Label3);
            this._grpFilter.Controls.Add(this._txtName);
            this._grpFilter.Controls.Add(this._txtNumber);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._txtReference);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(841, 108);
            this._grpFilter.TabIndex = 0;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _Panel3
            // 
            this._Panel3.Controls.Add(this._radToWarehouse);
            this._Panel3.Controls.Add(this._radToVan);
            this._Panel3.Location = new System.Drawing.Point(442, 50);
            this._Panel3.Name = "_Panel3";
            this._Panel3.Size = new System.Drawing.Size(196, 28);
            this._Panel3.TabIndex = 27;
            // 
            // _radToWarehouse
            // 
            this._radToWarehouse.AutoSize = true;
            this._radToWarehouse.Checked = true;
            this._radToWarehouse.Location = new System.Drawing.Point(3, 3);
            this._radToWarehouse.Name = "_radToWarehouse";
            this._radToWarehouse.Size = new System.Drawing.Size(88, 17);
            this._radToWarehouse.TabIndex = 9;
            this._radToWarehouse.TabStop = true;
            this._radToWarehouse.Text = "Warehouse";
            this._radToWarehouse.UseVisualStyleBackColor = true;
            this._radToWarehouse.CheckedChanged += new System.EventHandler(this.radToWarehouse_CheckedChanged);
            // 
            // _radToVan
            // 
            this._radToVan.AutoSize = true;
            this._radToVan.Location = new System.Drawing.Point(98, 3);
            this._radToVan.Name = "_radToVan";
            this._radToVan.Size = new System.Drawing.Size(97, 17);
            this._radToVan.TabIndex = 10;
            this._radToVan.Text = "Stock Profile";
            this._radToVan.UseVisualStyleBackColor = true;
            this._radToVan.CheckedChanged += new System.EventHandler(this.radToVan_CheckedChanged);
            // 
            // _Panel2
            // 
            this._Panel2.Controls.Add(this._radFromWarehouse);
            this._Panel2.Controls.Add(this._radFromVan);
            this._Panel2.Location = new System.Drawing.Point(441, 19);
            this._Panel2.Name = "_Panel2";
            this._Panel2.Size = new System.Drawing.Size(197, 26);
            this._Panel2.TabIndex = 26;
            // 
            // _radFromWarehouse
            // 
            this._radFromWarehouse.AutoSize = true;
            this._radFromWarehouse.Checked = true;
            this._radFromWarehouse.Location = new System.Drawing.Point(3, 3);
            this._radFromWarehouse.Name = "_radFromWarehouse";
            this._radFromWarehouse.Size = new System.Drawing.Size(88, 17);
            this._radFromWarehouse.TabIndex = 6;
            this._radFromWarehouse.TabStop = true;
            this._radFromWarehouse.Text = "Warehouse";
            this._radFromWarehouse.UseVisualStyleBackColor = true;
            this._radFromWarehouse.CheckedChanged += new System.EventHandler(this.radFromWarehouse_CheckedChanged);
            // 
            // _radFromVan
            // 
            this._radFromVan.AutoSize = true;
            this._radFromVan.Location = new System.Drawing.Point(100, 3);
            this._radFromVan.Name = "_radFromVan";
            this._radFromVan.Size = new System.Drawing.Size(97, 17);
            this._radFromVan.TabIndex = 7;
            this._radFromVan.Text = "Stock Profile";
            this._radFromVan.UseVisualStyleBackColor = true;
            this._radFromVan.CheckedChanged += new System.EventHandler(this.radFromVan_CheckedChanged);
            // 
            // _Panel1
            // 
            this._Panel1.Controls.Add(this._radParts);
            this._Panel1.Controls.Add(this._radProducts);
            this._Panel1.Controls.Add(this._radBoth);
            this._Panel1.Location = new System.Drawing.Point(5, 17);
            this._Panel1.Name = "_Panel1";
            this._Panel1.Size = new System.Drawing.Size(82, 82);
            this._Panel1.TabIndex = 25;
            // 
            // _radParts
            // 
            this._radParts.AutoSize = true;
            this._radParts.Location = new System.Drawing.Point(3, 3);
            this._radParts.Name = "_radParts";
            this._radParts.Size = new System.Drawing.Size(54, 17);
            this._radParts.TabIndex = 0;
            this._radParts.Text = "Parts";
            this._radParts.UseVisualStyleBackColor = true;
            // 
            // _radProducts
            // 
            this._radProducts.AutoSize = true;
            this._radProducts.Location = new System.Drawing.Point(3, 33);
            this._radProducts.Name = "_radProducts";
            this._radProducts.Size = new System.Drawing.Size(74, 17);
            this._radProducts.TabIndex = 1;
            this._radProducts.Text = "Products";
            this._radProducts.UseVisualStyleBackColor = true;
            // 
            // _radBoth
            // 
            this._radBoth.AutoSize = true;
            this._radBoth.Checked = true;
            this._radBoth.Location = new System.Drawing.Point(3, 60);
            this._radBoth.Name = "_radBoth";
            this._radBoth.Size = new System.Drawing.Size(51, 17);
            this._radBoth.TabIndex = 2;
            this._radBoth.TabStop = true;
            this._radBoth.Text = "Both";
            this._radBoth.UseVisualStyleBackColor = true;
            // 
            // _btnRun
            // 
            this._btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnRun.Location = new System.Drawing.Point(781, 78);
            this._btnRun.Name = "_btnRun";
            this._btnRun.Size = new System.Drawing.Size(52, 23);
            this._btnRun.TabIndex = 12;
            this._btnRun.Text = "Run";
            this._btnRun.UseVisualStyleBackColor = true;
            this._btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // _cboTo
            // 
            this._cboTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboTo.FormattingEnabled = true;
            this._cboTo.Location = new System.Drawing.Point(644, 49);
            this._cboTo.Name = "_cboTo";
            this._cboTo.Size = new System.Drawing.Size(189, 21);
            this._cboTo.TabIndex = 11;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(358, 52);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(84, 18);
            this._Label4.TabIndex = 24;
            this._Label4.Text = "Moved To";
            // 
            // _cboFrom
            // 
            this._cboFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboFrom.FormattingEnabled = true;
            this._cboFrom.Location = new System.Drawing.Point(644, 22);
            this._cboFrom.Name = "_cboFrom";
            this._cboFrom.Size = new System.Drawing.Size(189, 21);
            this._cboFrom.TabIndex = 8;
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(358, 25);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(84, 18);
            this._Label3.TabIndex = 20;
            this._Label3.Text = "Moved From";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(158, 49);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(194, 21);
            this._txtName.TabIndex = 4;
            // 
            // _txtNumber
            // 
            this._txtNumber.Location = new System.Drawing.Point(158, 22);
            this._txtNumber.Name = "_txtNumber";
            this._txtNumber.Size = new System.Drawing.Size(194, 21);
            this._txtNumber.TabIndex = 3;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(87, 79);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(67, 18);
            this._Label2.TabIndex = 11;
            this._Label2.Text = "Reference";
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(87, 52);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(88, 16);
            this._Label1.TabIndex = 10;
            this._Label1.Text = "Name";
            // 
            // _txtReference
            // 
            this._txtReference.Location = new System.Drawing.Point(158, 76);
            this._txtReference.Name = "_txtReference";
            this._txtReference.Size = new System.Drawing.Size(194, 21);
            this._txtReference.TabIndex = 5;
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(87, 22);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Number";
            // 
            // FRMStockMoved
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(857, 468);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpAudit);
            this.MinimumSize = new System.Drawing.Size(873, 506);
            this.Name = "FRMStockMoved";
            this.Text = "Stock Moved Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgIPTAudit)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this._Panel3.ResumeLayout(false);
            this._Panel3.PerformLayout();
            this._Panel2.ResumeLayout(false);
            this._Panel2.PerformLayout();
            this._Panel1.ResumeLayout(false);
            this._Panel1.PerformLayout();
            this.ResumeLayout(false);

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