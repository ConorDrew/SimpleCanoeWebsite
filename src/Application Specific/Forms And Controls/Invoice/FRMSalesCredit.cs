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
    public class FRMSalesCredit : FRMBaseForm, IForm
    {
        public FRMSalesCredit()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMSystemScheduleOfRate_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        // ("InvoicedID")
        public FRMSalesCredit(DataRow[] IDToLinkToIn, bool FromQuoteJobIn = false, bool FromJobIn = false) : base()
        {
            base.Load += FRMSystemScheduleOfRate_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            FromQuoteJob = FromQuoteJobIn;
            FromJob = FromJobIn;
            IDToLinkTo = IDToLinkToIn;
            var argc = cboUser;
            Combo.SetUpCombo(ref argc, App.DB.User.GetAll().Table, "UserID", "Fullname", Entity.Sys.Enums.ComboValues.No_Filter);
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
        private GroupBox _grpSystemScheduleOfRate;

        internal GroupBox grpSystemScheduleOfRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSystemScheduleOfRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSystemScheduleOfRate != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _grpSystemScheduleOfRate.Enter -= grpSystemScheduleOfRate_Enter;
                }

                _grpSystemScheduleOfRate = value;
                if (_grpSystemScheduleOfRate != null)
                {
                    _grpSystemScheduleOfRate.Enter += grpSystemScheduleOfRate_Enter;
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

        private ComboBox _cboUser;

        internal ComboBox cboUser
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboUser;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboUser != null)
                {
                }

                _cboUser = value;
                if (_cboUser != null)
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

        private TextBox _txtReason;

        internal TextBox txtReason
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtReason;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtReason != null)
                {
                }

                _txtReason = value;
                if (_txtReason != null)
                {
                }
            }
        }

        private TextBox _txtAfter;

        internal TextBox txtAfter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAfter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAfter != null)
                {
                }

                _txtAfter = value;
                if (_txtAfter != null)
                {
                }
            }
        }

        private TextBox _txtCredit;

        internal TextBox txtCredit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCredit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCredit != null)
                {
                }

                _txtCredit = value;
                if (_txtCredit != null)
                {
                }
            }
        }

        private TextBox _txtInvoiced;

        internal TextBox txtInvoiced
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvoiced;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvoiced != null)
                {
                }

                _txtInvoiced = value;
                if (_txtInvoiced != null)
                {
                }
            }
        }

        private TextBox _txtExRef;

        internal TextBox txtExRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtExRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtExRef != null)
                {
                }

                _txtExRef = value;
                if (_txtExRef != null)
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

        private DataGridView _dgRates;

        internal DataGridView dgRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgRates != null)
                {
                    _dgRates.CellEndEdit -= dgvParts_CellEndEdit;
                }

                _dgRates = value;
                if (_dgRates != null)
                {
                    _dgRates.CellEndEdit += dgvParts_CellEndEdit;
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

        private DateTimePicker _DateTimePicker1;

        internal DateTimePicker DateTimePicker1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DateTimePicker1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DateTimePicker1 != null)
                {
                }

                _DateTimePicker1 = value;
                if (_DateTimePicker1 != null)
                {
                }
            }
        }

        private TextBox _txtDept;

        internal TextBox txtDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDept != null)
                {
                }

                _txtDept = value;
                if (_txtDept != null)
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

        private TextBox _txtNominal;

        internal TextBox txtNominal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominal != null)
                {
                }

                _txtNominal = value;
                if (_txtNominal != null)
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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpSystemScheduleOfRate = new GroupBox();
            _grpSystemScheduleOfRate.Enter += new EventHandler(grpSystemScheduleOfRate_Enter);
            _Label7 = new Label();
            _DateTimePicker1 = new DateTimePicker();
            _dgRates = new DataGridView();
            _dgRates.CellEndEdit += new DataGridViewCellEventHandler(dgvParts_CellEndEdit);
            _txtAfter = new TextBox();
            _txtCredit = new TextBox();
            _txtInvoiced = new TextBox();
            _txtExRef = new TextBox();
            _cboUser = new ComboBox();
            _Label1 = new Label();
            _txtReason = new TextBox();
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _Label3 = new Label();
            _Label2 = new Label();
            _Label5 = new Label();
            _Label4 = new Label();
            _Label6 = new Label();
            _txtNominal = new TextBox();
            _Label8 = new Label();
            _txtDept = new TextBox();
            _Label9 = new Label();
            _grpSystemScheduleOfRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).BeginInit();
            SuspendLayout();
            //
            // grpSystemScheduleOfRate
            //
            _grpSystemScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSystemScheduleOfRate.Controls.Add(_txtDept);
            _grpSystemScheduleOfRate.Controls.Add(_Label9);
            _grpSystemScheduleOfRate.Controls.Add(_txtNominal);
            _grpSystemScheduleOfRate.Controls.Add(_Label8);
            _grpSystemScheduleOfRate.Controls.Add(_Label7);
            _grpSystemScheduleOfRate.Controls.Add(_DateTimePicker1);
            _grpSystemScheduleOfRate.Controls.Add(_dgRates);
            _grpSystemScheduleOfRate.Controls.Add(_txtAfter);
            _grpSystemScheduleOfRate.Controls.Add(_txtCredit);
            _grpSystemScheduleOfRate.Controls.Add(_txtInvoiced);
            _grpSystemScheduleOfRate.Controls.Add(_txtExRef);
            _grpSystemScheduleOfRate.Controls.Add(_cboUser);
            _grpSystemScheduleOfRate.Controls.Add(_Label1);
            _grpSystemScheduleOfRate.Controls.Add(_txtReason);
            _grpSystemScheduleOfRate.Controls.Add(_btnCancel);
            _grpSystemScheduleOfRate.Controls.Add(_btnAdd);
            _grpSystemScheduleOfRate.Controls.Add(_Label3);
            _grpSystemScheduleOfRate.Controls.Add(_Label2);
            _grpSystemScheduleOfRate.Controls.Add(_Label5);
            _grpSystemScheduleOfRate.Controls.Add(_Label4);
            _grpSystemScheduleOfRate.Controls.Add(_Label6);
            _grpSystemScheduleOfRate.Location = new Point(8, 32);
            _grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate";
            _grpSystemScheduleOfRate.Size = new Size(632, 432);
            _grpSystemScheduleOfRate.TabIndex = 2;
            _grpSystemScheduleOfRate.TabStop = false;
            _grpSystemScheduleOfRate.Text = "Credit Details";
            //
            // Label7
            //
            _Label7.AutoSize = true;
            _Label7.Location = new Point(6, 287);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(88, 13);
            _Label7.TabIndex = 49;
            _Label7.Text = "Date of Credit";
            //
            // DateTimePicker1
            //
            _DateTimePicker1.Location = new Point(9, 303);
            _DateTimePicker1.Name = "DateTimePicker1";
            _DateTimePicker1.Size = new Size(324, 21);
            _DateTimePicker1.TabIndex = 48;
            //
            // dgRates
            //
            _dgRates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgRates.Location = new Point(6, 20);
            _dgRates.Name = "dgRates";
            _dgRates.Size = new Size(620, 170);
            _dgRates.TabIndex = 47;
            //
            // txtAfter
            //
            _txtAfter.Location = new Point(495, 306);
            _txtAfter.Name = "txtAfter";
            _txtAfter.ReadOnly = true;
            _txtAfter.Size = new Size(112, 21);
            _txtAfter.TabIndex = 45;
            //
            // txtCredit
            //
            _txtCredit.Location = new Point(495, 262);
            _txtCredit.Name = "txtCredit";
            _txtCredit.ReadOnly = true;
            _txtCredit.Size = new Size(112, 21);
            _txtCredit.TabIndex = 43;
            //
            // txtInvoiced
            //
            _txtInvoiced.Location = new Point(495, 221);
            _txtInvoiced.Name = "txtInvoiced";
            _txtInvoiced.ReadOnly = true;
            _txtInvoiced.Size = new Size(112, 21);
            _txtInvoiced.TabIndex = 41;
            //
            // txtExRef
            //
            _txtExRef.Location = new Point(233, 262);
            _txtExRef.Name = "txtExRef";
            _txtExRef.Size = new Size(100, 21);
            _txtExRef.TabIndex = 39;
            //
            // cboUser
            //
            _cboUser.FormattingEnabled = true;
            _cboUser.Location = new Point(9, 221);
            _cboUser.Name = "cboUser";
            _cboUser.Size = new Size(324, 21);
            _cboUser.TabIndex = 37;
            //
            // Label1
            //
            _Label1.AutoSize = true;
            _Label1.Location = new Point(6, 332);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(110, 13);
            _Label1.TabIndex = 36;
            _Label1.Text = "Reason For Credit";
            //
            // txtReason
            //
            _txtReason.Location = new Point(8, 350);
            _txtReason.Multiline = true;
            _txtReason.Name = "txtReason";
            _txtReason.Size = new Size(611, 40);
            _txtReason.TabIndex = 35;
            //
            // btnCancel
            //
            _btnCancel.Location = new Point(8, 400);
            _btnCancel.Name = "btnCancel";
            _btnCancel.Size = new Size(75, 23);
            _btnCancel.TabIndex = 34;
            _btnCancel.Text = "Cancel";
            //
            // btnAdd
            //
            _btnAdd.Location = new Point(518, 400);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(101, 23);
            _btnAdd.TabIndex = 33;
            _btnAdd.Text = "Create Credit";
            //
            // Label3
            //
            _Label3.AutoSize = true;
            _Label3.Location = new Point(231, 246);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(44, 13);
            _Label3.TabIndex = 40;
            _Label3.Text = "Ex Ref";
            //
            // Label2
            //
            _Label2.AutoSize = true;
            _Label2.Location = new Point(6, 203);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(86, 13);
            _Label2.TabIndex = 38;
            _Label2.Text = "Requested By";
            //
            // Label5
            //
            _Label5.AutoSize = true;
            _Label5.Location = new Point(505, 247);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(87, 13);
            _Label5.TabIndex = 44;
            _Label5.Text = "Total Credited";
            //
            // Label4
            //
            _Label4.AutoSize = true;
            _Label4.Location = new Point(479, 203);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(145, 13);
            _Label4.TabIndex = 42;
            _Label4.Text = "Total Originally Invoiced";
            //
            // Label6
            //
            _Label6.AutoSize = true;
            _Label6.Location = new Point(474, 287);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(150, 13);
            _Label6.TabIndex = 46;
            _Label6.Text = "Total Invoice after Credit";
            //
            // txtNominal
            //
            _txtNominal.Location = new Point(9, 263);
            _txtNominal.Name = "txtNominal";
            _txtNominal.Size = new Size(100, 21);
            _txtNominal.TabIndex = 50;
            //
            // Label8
            //
            _Label8.AutoSize = true;
            _Label8.Location = new Point(7, 247);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(53, 13);
            _Label8.TabIndex = 51;
            _Label8.Text = "Nominal";
            //
            // txtDept
            //
            _txtDept.Location = new Point(121, 263);
            _txtDept.Name = "txtDept";
            _txtDept.Size = new Size(100, 21);
            _txtDept.TabIndex = 52;
            //
            // Label9
            //
            _Label9.AutoSize = true;
            _Label9.Location = new Point(119, 247);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(34, 13);
            _Label9.TabIndex = 53;
            _Label9.Text = "Dept";
            //
            // FRMSalesCredit
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(648, 470);
            Controls.Add(_grpSystemScheduleOfRate);
            MinimumSize = new Size(656, 504);
            Name = "FRMSalesCredit";
            Text = "Property Schedule Of Rates List";
            Controls.SetChildIndex(_grpSystemScheduleOfRate, 0);
            _grpSystemScheduleOfRate.ResumeLayout(false);
            _grpSystemScheduleOfRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupRatesDataGrid();
            Populate();
        }

        public IUserControl LoadedControl
        {
            get
            {
                return default;
            }
        }

        public void ResetMe(int newID)
        {
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private bool _fromQuoteJob;

        public bool FromQuoteJob
        {
            get
            {
                return _fromQuoteJob;
            }

            set
            {
                _fromQuoteJob = value;
            }
        }

        private bool _fromJob;

        public bool FromJob
        {
            get
            {
                return _fromJob;
            }

            set
            {
                _fromJob = value;
            }
        }

        private DataView _DataViewToLinkTo;

        public DataView DataviewToLinkTo
        {
            get
            {
                return _DataViewToLinkTo;
            }

            set
            {
                _DataViewToLinkTo = value;
            }
        }

        private DataRow[] _IDToLinkTo = null;

        public DataRow[] IDToLinkTo
        {
            get
            {
                return _IDToLinkTo;
            }

            set
            {
                _IDToLinkTo = value;
            }
        }

        private DataView _dvRates;

        public DataView RatesDataview
        {
            get
            {
                return _dvRates;
            }

            set
            {
                _dvRates = value;
                _dvRates.AllowNew = false;
                _dvRates.AllowEdit = true;
                _dvRates.AllowDelete = false;
                _dvRates.Table.TableName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
                dgRates.DataSource = RatesDataview;
            }
        }

        private DataGridViewRow SelectedRatesDataRow
        {
            get
            {
                if (!(dgRates.CurrentRow.Index == -1))
                {
                    return dgRates.CurrentRow;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void SetupRatesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGridView(dgRates);
            dgRates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgRates.AutoGenerateColumns = false;
            dgRates.Columns.Clear();
            dgRates.EditMode = DataGridViewEditMode.EditOnEnter;
            var PartName = new DataGridViewTextBoxColumn();
            PartName.FillWeight = 300;
            PartName.HeaderText = "Address";
            PartName.DataPropertyName = "Address";
            PartName.ReadOnly = true;
            PartName.Visible = true;
            PartName.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgRates.Columns.Add(PartName);
            var PONetValue = new DataGridViewTextBoxColumn();
            PONetValue.HeaderText = "Invoiced (Nett)";
            PONetValue.DataPropertyName = "Amount";
            // TotalUnitPrice.FillWeight = 10
            PONetValue.ReadOnly = true;
            PONetValue.Visible = true;
            PONetValue.Width = 100;
            PONetValue.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgRates.Columns.Add(PONetValue);
            var creditApplied = new DataGridViewTextBoxColumn();
            creditApplied.HeaderText = "Credit Applied (Nett)";
            creditApplied.DataPropertyName = "CreditApplied";
            // TotalUnitPrice.FillWeight = 10
            creditApplied.ReadOnly = true;
            creditApplied.Visible = true;
            creditApplied.Width = 100;
            creditApplied.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgRates.Columns.Add(creditApplied);
            var PONetValue2 = new DataGridViewTextBoxColumn();
            PONetValue2.HeaderText = "Credit Amount (Nett)";
            PONetValue2.DataPropertyName = "Credit";
            // TotalUnitPrice.FillWeight = 10
            PONetValue2.ReadOnly = false;
            PONetValue2.Visible = true;
            PONetValue2.Width = 100;
            PONetValue2.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgRates.Columns.Add(PONetValue2);
        }

        private void FRMSystemScheduleOfRate_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Add())
            {
                if (Modal)
                {
                    Close();
                }
                else
                {
                    Dispose();
                }
            }
            else
            {
                App.ShowMessage("Please ensure the credit value is greater than zero and equal or less to the original invoice value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnAdd.Enabled = true;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void Populate()
        {
            RatesDataview = App.DB.SalesCredit.InvoicedLines_GetAll_ByInvoicedIDRows(IDToLinkTo);
            RatesDataview.Table.Columns.Add("SalesCreditID", typeof(int));
            RatesDataview.Table.Columns.Add("CreditReference");
            txtNominal.Text = Conversions.ToString(RatesDataview.Table.Rows[0]["NominalCode"]);
            txtDept.Text = Conversions.ToString(RatesDataview.Table.Rows[0]["Department"]);
        }

        private bool Add()
        {
            btnAdd.Enabled = false;
            bool raise = false; // work out if we need to raise doc
            var jobnum = App.DB.Job.GetNextJobNumber((Entity.Sys.Enums.JobDefinition)103);
            if (txtAfter.Text.Trim().Length == 0)
                return false;
            double totalAfterCredit = Entity.Sys.Helper.MakeDoubleValid(txtAfter.Text.Trim());
            foreach (DataRow dr in RatesDataview.Table.Rows)
            {
                if (Conversions.ToBoolean((decimal)dr["Credit"] > 0) && totalAfterCredit >= 0)
                {
                    raise = true; // yup
                    var oSalesCredit = new Entity.SalesCredits.SalesCredit();
                    App.DB.ExecuteScalar(Conversions.ToString(Conversions.ToString("INSERT INTO tblInvoicedLinesCredit (InvoicedLineID,CreditAmount) VALUES (" + dr["InvoicedLineID"] + ",") + dr["Credit"] + ")"));
                    var oInvoice = App.DB.Invoiced.Invoiced_Get(Conversions.ToInteger(dr["InvoicedID"]));
                    var oCredit = new Entity.SalesCredits.SalesCredit();
                    oCredit.SetAmountCredited = dr["Credit"];     // CDbl(txtCredit.Text)
                    oCredit.SetNotes = "";
                    oCredit.SetTaxCodeID = oInvoice.VATRateID;
                    oCredit.SetExtraRef = txtExRef.Text;
                    if (Information.IsDBNull(dr["NominalCode"]) || dr["NominalCode"].ToString().Length == 0)
                    {
                        oCredit.SetNominalCode = 4900;
                        oCredit.SetDepartmentRef = 100;
                    }
                    else
                    {
                        oCredit.SetNominalCode = dr["NominalCode"];
                        oCredit.SetDepartmentRef = dr["Department"];
                    }

                    oCredit.SetNominalCode = txtNominal.Text;
                    oCredit.SetDepartmentRef = txtDept.Text;
                    oCredit.SetInvoicedLineID = dr["InvoicedLineID"];
                    oCredit.SetAddedByUser = App.loggedInUser.UserID;
                    oCredit.SetRequestedBy = Combo.get_GetSelectedItemValue(cboUser);
                    oCredit.SetReasonForCredit = txtReason.Text;
                    oCredit.SetCreditReference = jobnum.Prefix + jobnum.Number;
                    oCredit.SetAccountNumber = dr["AccountNumber"];
                    oCredit.DateCredited = DateTimePicker1.Value;
                    dr["SalesCreditID"] = App.DB.SalesCredit.Insert(oCredit)?.SalesCreditID;
                    dr["CreditReference"] = jobnum.Prefix + jobnum.Number;
                }
            }

            if (raise) // and raise
            {
                if (App.ShowMessage("Do you want to generate the document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var oPrint = new Entity.Sys.Printing(RatesDataview.Table, "Sales Credit", Entity.Sys.Enums.SystemDocumentType.SalesCredit);
                }
            }

            return raise; // so we can throw an error message
        }

        private void dgvParts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedRatesDataRow is null)
            {
                return;
            }

            // update the min max record

            DoTotals();
        }

        private void DoTotals()
        {
            decimal credit = 0.0M;
            decimal invoiced = 0.0M;
            decimal creditApplied = 0.0M;
            foreach (DataGridViewRow dr in dgRates.Rows)
            {
                invoiced += Conversions.ToDecimal(dr.Cells[1].Value);
                credit += Conversions.ToDecimal(dr.Cells[3].Value);
                creditApplied = Conversions.ToDecimal(dr.Cells[2].Value);
            }

            decimal creditTotal = creditApplied + credit;
            txtAfter.Text = (invoiced - creditTotal).ToString("C");
            txtCredit.Text = credit.ToString("C");
            txtInvoiced.Text = invoiced.ToString("C");
        }

        private void grpSystemScheduleOfRate_Enter(object sender, EventArgs e)
        {
        }
    }
}