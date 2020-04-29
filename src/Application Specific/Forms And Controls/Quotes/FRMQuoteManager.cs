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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMQuoteManager() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal Label Label11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label11 != null)
                {
                }

                _Label11 = value;
                if (_Label11 != null)
                {
                }
            }
        }

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

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
                {
                }
            }
        }

        private Label _Label9;

        internal Label Label9
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label9;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label9 != null)
                {
                }

                _Label9 = value;
                if (_Label9 != null)
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
            _grpJobs = new GroupBox();
            _dgQuotes = new DataGrid();
            _dgQuotes.DoubleClick += new EventHandler(dgQuotes_DoubleClick);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _btnFindSite = new Button();
            _btnFindSite.Click += new EventHandler(btnFindSite_Click);
            _txtSite = new TextBox();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label1 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpTo.ValueChanged += new EventHandler(dtpTo_ValueChanged);
            _dtpFrom = new DateTimePicker();
            _dtpFrom.ValueChanged += new EventHandler(dtpFrom_ValueChanged);
            _txtReference = new TextBox();
            _txtReference.TextChanged += new EventHandler(txtReference_TextChanged);
            _Label9 = new Label();
            _Label8 = new Label();
            _chkQuoteDate = new CheckBox();
            _chkQuoteDate.CheckedChanged += new EventHandler(chkQuoteDate_CheckedChanged);
            _Label6 = new Label();
            _Label2 = new Label();
            _Label10 = new Label();
            _cboType = new ComboBox();
            _cboType.SelectedIndexChanged += new EventHandler(cboType_SelectedIndexChanged);
            _Label11 = new Label();
            _cboStatus = new ComboBox();
            _cboStatus.SelectedIndexChanged += new EventHandler(cboStatus_SelectedIndexChanged);
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgQuotes).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpJobs
            //
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgQuotes);
            _grpJobs.Location = new Point(8, 232);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(784, 224);
            _grpJobs.TabIndex = 2;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Double Click To View / Edit";
            //
            // dgQuotes
            //
            _dgQuotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgQuotes.DataMember = "";
            _dgQuotes.HeaderForeColor = SystemColors.ControlText;
            _dgQuotes.Location = new Point(8, 27);
            _dgQuotes.Name = "dgQuotes";
            _dgQuotes.Size = new Size(768, 189);
            _dgQuotes.TabIndex = 9;
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 464);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 10;
            _btnExport.Text = "Export";
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_btnFindSite);
            _grpFilter.Controls.Add(_txtSite);
            _grpFilter.Controls.Add(_btnFindCustomer);
            _grpFilter.Controls.Add(_txtCustomer);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_txtReference);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Controls.Add(_chkQuoteDate);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_Label10);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Controls.Add(_Label11);
            _grpFilter.Controls.Add(_cboStatus);
            _grpFilter.Location = new Point(8, 40);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(784, 184);
            _grpFilter.TabIndex = 1;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // btnFindSite
            //
            _btnFindSite.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindSite.BackColor = Color.White;
            _btnFindSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindSite.Location = new Point(736, 88);
            _btnFindSite.Name = "btnFindSite";
            _btnFindSite.Size = new Size(32, 23);
            _btnFindSite.TabIndex = 15;
            _btnFindSite.Text = "...";
            _btnFindSite.UseVisualStyleBackColor = false;
            //
            // txtSite
            //
            _txtSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSite.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSite.Location = new Point(104, 88);
            _txtSite.Name = "txtSite";
            _txtSite.ReadOnly = true;
            _txtSite.Size = new Size(624, 21);
            _txtSite.TabIndex = 14;
            //
            // btnFindCustomer
            //
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(736, 56);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 13;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            //
            // txtCustomer
            //
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(104, 56);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(624, 21);
            _txtCustomer.TabIndex = 12;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 56);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 16);
            _Label1.TabIndex = 11;
            _Label1.Text = "Customer";
            //
            // dtpTo
            //
            _dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpTo.Location = new Point(592, 152);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(184, 21);
            _dtpTo.TabIndex = 8;
            //
            // dtpFrom
            //
            _dtpFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _dtpFrom.Location = new Point(592, 121);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(184, 21);
            _dtpFrom.TabIndex = 7;
            //
            // txtReference
            //
            _txtReference.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtReference.Location = new Point(104, 121);
            _txtReference.Name = "txtReference";
            _txtReference.Size = new Size(312, 21);
            _txtReference.TabIndex = 4;
            //
            // Label9
            //
            _Label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label9.Location = new Point(536, 153);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "To";
            //
            // Label8
            //
            _Label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label8.Location = new Point(536, 121);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(48, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "From";
            //
            // chkQuoteDate
            //
            _chkQuoteDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _chkQuoteDate.Cursor = Cursors.Hand;
            _chkQuoteDate.UseVisualStyleBackColor = true;
            _chkQuoteDate.Location = new Point(424, 121);
            _chkQuoteDate.Name = "chkQuoteDate";
            _chkQuoteDate.Size = new Size(104, 24);
            _chkQuoteDate.TabIndex = 6;
            _chkQuoteDate.Text = "Quote Date";
            //
            // Label6
            //
            _Label6.Location = new Point(8, 120);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(88, 16);
            _Label6.TabIndex = 6;
            _Label6.Text = "Reference";
            //
            // Label2
            //
            _Label2.Location = new Point(8, 88);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(64, 16);
            _Label2.TabIndex = 2;
            _Label2.Text = "Property";
            //
            // Label10
            //
            _Label10.Location = new Point(8, 24);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(48, 16);
            _Label10.TabIndex = 4;
            _Label10.Text = "Type";
            //
            // cboType
            //
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(104, 25);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(312, 21);
            _cboType.TabIndex = 1;
            //
            // Label11
            //
            _Label11.Location = new Point(8, 152);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(48, 16);
            _Label11.TabIndex = 5;
            _Label11.Text = "Status";
            //
            // cboStatus
            //
            _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(104, 153);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(312, 21);
            _cboStatus.TabIndex = 5;
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 464);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 11;
            _btnReset.Text = "Reset";
            //
            // FRMQuoteManager
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(800, 494);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpJobs);
            Controls.Add(_btnReset);
            MinimumSize = new Size(808, 528);
            Name = "FRMQuoteManager";
            Text = "Quote Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgQuotes).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}