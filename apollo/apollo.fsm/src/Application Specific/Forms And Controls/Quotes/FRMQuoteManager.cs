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
    public class FRMQuoteManager : FRMBaseForm, IForm
    {
        public FRMQuoteManager() : base()
        {
            base.Load += FRMQuoteManager_Load;

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

        private GroupBox _grpJobs;

        internal GroupBox grpJobs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpJobs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpJobs != null)
                {
                }

                _grpJobs = value;
                if (_grpJobs != null)
                {
                }
            }
        }

        private DateTimePicker _dtpTo;

        internal DateTimePicker dtpTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpTo != null)
                {
                    _dtpTo.ValueChanged -= dtpTo_ValueChanged;
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
                    _dtpTo.ValueChanged += dtpTo_ValueChanged;
                }
            }
        }

        private DateTimePicker _dtpFrom;

        internal DateTimePicker dtpFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFrom != null)
                {
                    _dtpFrom.ValueChanged -= dtpFrom_ValueChanged;
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                    _dtpFrom.ValueChanged += dtpFrom_ValueChanged;
                }
            }
        }

        private ComboBox _cboStatus;

        internal ComboBox cboStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged -= cboStatus_SelectedIndexChanged;
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
                }
            }
        }

        private Label _Label11;

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged -= cboType_SelectedIndexChanged;
                }

                _cboType = value;
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
                }
            }
        }

        private Label _Label10;

        private Label _Label9;

        private Label _Label8;

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

        private Button _btnExport;

        private Button _btnReset;

        internal Button btnReset
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnReset;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnReset != null)
                {
                    _btnReset.Click -= btnReset_Click;
                }

                _btnReset = value;
                if (_btnReset != null)
                {
                    _btnReset.Click += btnReset_Click;
                }
            }
        }

        private DataGrid _dgQuotes;

        internal DataGrid dgQuotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgQuotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgQuotes != null)
                {
                    _dgQuotes.DoubleClick -= dgQuotes_DoubleClick;
                }

                _dgQuotes = value;
                if (_dgQuotes != null)
                {
                    _dgQuotes.DoubleClick += dgQuotes_DoubleClick;
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
                    _txtReference.TextChanged -= txtReference_TextChanged;
                }

                _txtReference = value;
                if (_txtReference != null)
                {
                    _txtReference.TextChanged += txtReference_TextChanged;
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

        private CheckBox _chkQuoteDate;

        internal CheckBox chkQuoteDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkQuoteDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkQuoteDate != null)
                {
                    _chkQuoteDate.CheckedChanged -= chkQuoteDate_CheckedChanged;
                }

                _chkQuoteDate = value;
                if (_chkQuoteDate != null)
                {
                    _chkQuoteDate.CheckedChanged += chkQuoteDate_CheckedChanged;
                }
            }
        }

        private Button _btnFindCustomer;

        internal Button btnFindCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click -= btnFindCustomer_Click;
                }

                _btnFindCustomer = value;
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click += btnFindCustomer_Click;
                }
            }
        }

        private TextBox _txtCustomer;

        internal TextBox txtCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomer != null)
                {
                }

                _txtCustomer = value;
                if (_txtCustomer != null)
                {
                }
            }
        }

        private Button _btnFindSite;

        internal Button btnFindSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click -= btnFindSite_Click;
                }

                _btnFindSite = value;
                if (_btnFindSite != null)
                {
                    _btnFindSite.Click += btnFindSite_Click;
                }
            }
        }

        private TextBox _txtSite;

        internal TextBox txtSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSite != null)
                {
                }

                _txtSite = value;
                if (_txtSite != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgQuotes = new System.Windows.Forms.DataGrid();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._btnFindSite = new System.Windows.Forms.Button();
            this._txtSite = new System.Windows.Forms.TextBox();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._txtReference = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._chkQuoteDate = new System.Windows.Forms.CheckBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._Label11 = new System.Windows.Forms.Label();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._btnReset = new System.Windows.Forms.Button();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgQuotes)).BeginInit();
            this._grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgQuotes);
            this._grpJobs.Location = new System.Drawing.Point(8, 202);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(784, 254);
            this._grpJobs.TabIndex = 2;
            this._grpJobs.TabStop = false;
            this._grpJobs.Text = "Double Click To View / Edit";
            // 
            // _dgQuotes
            // 
            this._dgQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgQuotes.DataMember = "";
            this._dgQuotes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgQuotes.Location = new System.Drawing.Point(8, 27);
            this._dgQuotes.Name = "_dgQuotes";
            this._dgQuotes.Size = new System.Drawing.Size(768, 219);
            this._dgQuotes.TabIndex = 9;
            this._dgQuotes.DoubleClick += new System.EventHandler(this.dgQuotes_DoubleClick);
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 464);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 10;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._btnFindSite);
            this._grpFilter.Controls.Add(this._txtSite);
            this._grpFilter.Controls.Add(this._btnFindCustomer);
            this._grpFilter.Controls.Add(this._txtCustomer);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._txtReference);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Controls.Add(this._chkQuoteDate);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._Label10);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Controls.Add(this._Label11);
            this._grpFilter.Controls.Add(this._cboStatus);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(784, 184);
            this._grpFilter.TabIndex = 1;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _btnFindSite
            // 
            this._btnFindSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindSite.BackColor = System.Drawing.Color.White;
            this._btnFindSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindSite.Location = new System.Drawing.Point(736, 88);
            this._btnFindSite.Name = "_btnFindSite";
            this._btnFindSite.Size = new System.Drawing.Size(32, 23);
            this._btnFindSite.TabIndex = 15;
            this._btnFindSite.Text = "...";
            this._btnFindSite.UseVisualStyleBackColor = false;
            this._btnFindSite.Click += new System.EventHandler(this.btnFindSite_Click);
            // 
            // _txtSite
            // 
            this._txtSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSite.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSite.Location = new System.Drawing.Point(104, 88);
            this._txtSite.Name = "_txtSite";
            this._txtSite.ReadOnly = true;
            this._txtSite.Size = new System.Drawing.Size(624, 21);
            this._txtSite.TabIndex = 14;
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(736, 56);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 13;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = false;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(104, 56);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(624, 21);
            this._txtCustomer.TabIndex = 12;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 56);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(64, 16);
            this._Label1.TabIndex = 11;
            this._Label1.Text = "Customer";
            // 
            // _dtpTo
            // 
            this._dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpTo.Location = new System.Drawing.Point(592, 152);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(184, 21);
            this._dtpTo.TabIndex = 8;
            this._dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._dtpFrom.Location = new System.Drawing.Point(592, 121);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(184, 21);
            this._dtpFrom.TabIndex = 7;
            this._dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // _txtReference
            // 
            this._txtReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtReference.Location = new System.Drawing.Point(104, 121);
            this._txtReference.Name = "_txtReference";
            this._txtReference.Size = new System.Drawing.Size(312, 21);
            this._txtReference.TabIndex = 4;
            this._txtReference.TextChanged += new System.EventHandler(this.txtReference_TextChanged);
            // 
            // _Label9
            // 
            this._Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label9.Location = new System.Drawing.Point(536, 153);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(48, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "To";
            // 
            // _Label8
            // 
            this._Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label8.Location = new System.Drawing.Point(536, 121);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(48, 16);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "From";
            // 
            // _chkQuoteDate
            // 
            this._chkQuoteDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkQuoteDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkQuoteDate.Location = new System.Drawing.Point(424, 121);
            this._chkQuoteDate.Name = "_chkQuoteDate";
            this._chkQuoteDate.Size = new System.Drawing.Size(104, 24);
            this._chkQuoteDate.TabIndex = 6;
            this._chkQuoteDate.Text = "Quote Date";
            this._chkQuoteDate.UseVisualStyleBackColor = true;
            this._chkQuoteDate.CheckedChanged += new System.EventHandler(this.chkQuoteDate_CheckedChanged);
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(8, 120);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(88, 16);
            this._Label6.TabIndex = 6;
            this._Label6.Text = "Reference";
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 88);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(64, 16);
            this._Label2.TabIndex = 2;
            this._Label2.Text = "Property";
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(8, 24);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(48, 16);
            this._Label10.TabIndex = 4;
            this._Label10.Text = "Type";
            // 
            // _cboType
            // 
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(104, 25);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(312, 21);
            this._cboType.TabIndex = 1;
            this._cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // _Label11
            // 
            this._Label11.Location = new System.Drawing.Point(8, 152);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(48, 16);
            this._Label11.TabIndex = 5;
            this._Label11.Text = "Status";
            // 
            // _cboStatus
            // 
            this._cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.Location = new System.Drawing.Point(104, 153);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(312, 21);
            this._cboStatus.TabIndex = 5;
            this._cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 464);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 11;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FRMQuoteManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpJobs);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(808, 528);
            this.Name = "FRMQuoteManager";
            this.Text = "Quote Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgQuotes)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupQuotesDataGrid();
            PopulateDatagrid();
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

        private DataView _dvQuotes;

        private DataView QuotesDataview
        {
            get
            {
                return _dvQuotes;
            }

            set
            {
                _dvQuotes = value;
                _dvQuotes.AllowNew = false;
                _dvQuotes.AllowEdit = false;
                _dvQuotes.AllowDelete = false;
                _dvQuotes.Table.TableName = Entity.Sys.Enums.TableNames.tblQuotes.ToString();
                dgQuotes.DataSource = QuotesDataview;
            }
        }

        private DataRow SelectedQuoteDataRow
        {
            get
            {
                if (!(dgQuotes.CurrentRowIndex == -1))
                {
                    return QuotesDataview[dgQuotes.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Customers.Customer _oCustomer;

        public Entity.Customers.Customer Customer
        {
            get
            {
                return _oCustomer;
            }

            set
            {
                _oCustomer = value;
                if (_oCustomer is object)
                {
                    txtCustomer.Text = Customer.Name + " ( " + Customer.AccountNumber + ") ";
                }
                else
                {
                    txtCustomer.Text = "";
                }
            }
        }

        private Entity.Sites.Site _oSite;

        public Entity.Sites.Site theSite
        {
            get
            {
                return _oSite;
            }

            set
            {
                _oSite = value;
                if (_oSite is object)
                {
                    txtSite.Text = theSite.Address1 + ", " + theSite.Address2 + ", " + theSite.Postcode;
                }
                else
                {
                    txtSite.Text = "";
                }
            }
        }

        private void SetupQuotesDataGrid()
        {
            var tbStyle = dgQuotes.TableStyles[0];
            var QuoteType = new DataGridLabelColumn();
            QuoteType.Format = "";
            QuoteType.FormatInfo = null;
            QuoteType.HeaderText = "Quote Type";
            QuoteType.MappingName = "QuoteType";
            QuoteType.ReadOnly = true;
            QuoteType.Width = 80;
            QuoteType.NullText = "";
            tbStyle.GridColumnStyles.Add(QuoteType);
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
            var SitePostcode = new DataGridLabelColumn();
            SitePostcode.Format = "";
            SitePostcode.FormatInfo = null;
            SitePostcode.HeaderText = "Postcode";
            SitePostcode.MappingName = "SitePostcode";
            SitePostcode.ReadOnly = true;
            SitePostcode.Width = 100;
            SitePostcode.NullText = "";
            tbStyle.GridColumnStyles.Add(SitePostcode);
            var QuoteReference = new DataGridLabelColumn();
            QuoteReference.Format = "";
            QuoteReference.FormatInfo = null;
            QuoteReference.HeaderText = "Reference";
            QuoteReference.MappingName = "Reference";
            QuoteReference.ReadOnly = true;
            QuoteReference.Width = 120;
            QuoteReference.NullText = "";
            tbStyle.GridColumnStyles.Add(QuoteReference);
            var QuoteDate = new DataGridLabelColumn();
            QuoteDate.Format = "dd/MM/yyyy";
            QuoteDate.FormatInfo = null;
            QuoteDate.HeaderText = "Quote Date";
            QuoteDate.MappingName = "QuoteDate";
            QuoteDate.ReadOnly = true;
            QuoteDate.Width = 80;
            QuoteDate.NullText = "";
            tbStyle.GridColumnStyles.Add(QuoteDate);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 85;
            Price.NullText = "";
            tbStyle.GridColumnStyles.Add(Price);
            var QuoteStatus = new DataGridLabelColumn();
            QuoteStatus.Format = "";
            QuoteStatus.FormatInfo = null;
            QuoteStatus.HeaderText = "Status";
            QuoteStatus.MappingName = "Status";
            QuoteStatus.ReadOnly = true;
            QuoteStatus.Width = 100;
            QuoteStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(QuoteStatus);
            var RejectedReason = new DataGridLabelColumn();
            RejectedReason.Format = "";
            RejectedReason.FormatInfo = null;
            RejectedReason.HeaderText = "Rejected Reason";
            RejectedReason.MappingName = "RejectedReason";
            RejectedReason.ReadOnly = true;
            RejectedReason.Width = 150;
            RejectedReason.NullText = "";
            tbStyle.GridColumnStyles.Add(RejectedReason);
            var Converted = new DataGridLabelColumn();
            Converted.Format = "";
            Converted.FormatInfo = null;
            Converted.HeaderText = "Converted";
            Converted.MappingName = "Converted";
            Converted.ReadOnly = true;
            Converted.Width = 50;
            Converted.NullText = "";
            tbStyle.GridColumnStyles.Add(Converted);
            var ConvertedJN = new DataGridLabelColumn();
            ConvertedJN.Format = "";
            ConvertedJN.FormatInfo = null;
            ConvertedJN.HeaderText = "Converted JobNumber";
            ConvertedJN.MappingName = "ConvertedJN";
            ConvertedJN.ReadOnly = true;
            ConvertedJN.Width = 100;
            ConvertedJN.NullText = "";
            tbStyle.GridColumnStyles.Add(ConvertedJN);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblQuotes.ToString();
            dgQuotes.TableStyles.Add(tbStyle);
        }

        private void FRMQuoteManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void chkQuoteDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuoteDate.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Value = DateAndTime.Today;
                dtpTo.Value = DateAndTime.Today;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }

            RunFilter();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Contract_Opt_1))
            {
                btnFindCustomer.Enabled = true;
                btnFindSite.Enabled = false;
            }
            else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Job))
            {
                btnFindSite.Enabled = true;
                btnFindCustomer.Enabled = false;
            }

            RunFilter();
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                Customer = App.DB.Customer.Customer_Get(ID);
                RunFilter();
            }
        }

        private void btnFindSite_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblSite));
            if (!(ID == 0))
            {
                theSite = App.DB.Sites.Get(ID);
                RunFilter();
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void txtReference_TextChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void dgQuotes_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedQuoteDataRow is null)
            {
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedQuoteDataRow["QuoteType"], Entity.Sys.Enums.QuoteType.Job.ToString(), false)))
            {
                App.ShowForm(typeof(FRMQuoteJob), true, new object[] { Entity.Sys.Helper.MakeIntegerValid(SelectedQuoteDataRow["QuoteID"]), SelectedQuoteDataRow["IDToLinkTo"] });
            }
        }

        public void PopulateDatagrid()
        {
            try
            {
                ResetFilters();
                if (get_GetParameter(0) is null)
                {
                    ResetFilters();
                }
                else
                {
                    QuotesDataview = (DataView)get_GetParameter(0);
                    grpFilter.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            QuotesDataview = App.DB.Quotes.QuotesGet_All();
            theSite = null;
            Customer = null;
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("ValueMember"));
            dt.Columns.Add(new DataColumn("DisplayMember"));
            DataRow newRow;
            newRow = dt.NewRow();
            newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Job);
            newRow["DisplayMember"] = "Jobs";
            dt.Rows.Add(newRow);
            newRow = dt.NewRow();
            newRow["ValueMember"] = Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Contract_Opt_1);
            newRow["DisplayMember"] = "Contracts";
            dt.Rows.Add(newRow);
            var argc = cboType;
            Combo.SetUpCombo(ref argc, dt, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Job).ToString());
            var argc1 = cboStatus;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Quote_Status).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argcombo1 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            txtReference.Text = "";
            chkQuoteDate.Checked = false;
            dtpFrom.Value = DateAndTime.Today;
            dtpTo.Value = DateAndTime.Today;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            grpFilter.Enabled = true;
        }

        private void RunFilter()
        {
            string whereClause = "";
            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Contract_Opt_1))
            {
                whereClause += " QuoteType <> 'Job'";
                if (Customer is object)
                {
                    whereClause += " AND CustomerID = " + Customer.CustomerID + "";
                }
            }
            else if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.QuoteType.Job))
            {
                whereClause += " QuoteType = 'Job'";
                if (theSite is object)
                {
                    whereClause += " AND SiteID = " + theSite.SiteID + "";
                }
            }

            if (!(txtReference.Text.Trim().Length == 0))
            {
                whereClause += " AND Reference LIKE '" + txtReference.Text.Trim() + "%'";
            }

            if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0))
            {
                whereClause += " AND StatusID = " + Combo.get_GetSelectedItemValue(cboStatus) + "";
            }

            if (chkQuoteDate.Checked)
            {
                whereClause += " AND QuoteDate >= '" + Strings.Format(dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND QuoteDate <= '" + Strings.Format(dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
            }

            QuotesDataview.RowFilter = whereClause;
            grpJobs.Text = string.Format("Results ({0}) - Double Click To View / Edit", QuotesDataview.Count);
        }

        public void Export()
        {
            var exportData = new DataTable();
            exportData.Columns.Add("QuoteType");
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("Site");
            exportData.Columns.Add("SitePostcode");
            exportData.Columns.Add("Reference");
            exportData.Columns.Add("QuoteDate");
            exportData.Columns.Add("Price", typeof(decimal));
            exportData.Columns.Add("Status");
            exportData.Columns.Add("RejectedReason");
            for (int itm = 0, loopTo = ((DataView)dgQuotes.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgQuotes.CurrentRowIndex = itm;
                DataRow newRw;
                newRw = exportData.NewRow();
                newRw["QuoteType"] = SelectedQuoteDataRow["QuoteType"];
                newRw["Customer"] = SelectedQuoteDataRow["Customer"];
                newRw["Site"] = SelectedQuoteDataRow["Site"];
                newRw["SitePostcode"] = SelectedQuoteDataRow["SitePostcode"];
                newRw["Reference"] = SelectedQuoteDataRow["Reference"];
                newRw["QuoteDate"] = SelectedQuoteDataRow["QuoteDate"];
                newRw["Price"] = SelectedQuoteDataRow["Price"];
                newRw["Status"] = SelectedQuoteDataRow["Status"];
                newRw["RejectedReason"] = SelectedQuoteDataRow["RejectedReason"];
                exportData.Rows.Add(newRw);
                dgQuotes.UnSelect(itm);
            }

            Entity.Sys.ExportHelper.Export(exportData, "Quote List", Entity.Sys.Enums.ExportType.CSV);
        }
    }
}