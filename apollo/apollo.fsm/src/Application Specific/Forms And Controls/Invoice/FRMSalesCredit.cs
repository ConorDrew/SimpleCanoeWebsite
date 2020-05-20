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
            base.Load += FRMSystemScheduleOfRate_Load;
        }

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
            this._grpSystemScheduleOfRate = new System.Windows.Forms.GroupBox();
            this._txtDept = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._txtNominal = new System.Windows.Forms.TextBox();
            this._Label8 = new System.Windows.Forms.Label();
            this._Label7 = new System.Windows.Forms.Label();
            this._DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this._dgRates = new System.Windows.Forms.DataGridView();
            this._txtAfter = new System.Windows.Forms.TextBox();
            this._txtCredit = new System.Windows.Forms.TextBox();
            this._txtInvoiced = new System.Windows.Forms.TextBox();
            this._txtExRef = new System.Windows.Forms.TextBox();
            this._cboUser = new System.Windows.Forms.ComboBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtReason = new System.Windows.Forms.TextBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label5 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label6 = new System.Windows.Forms.Label();
            this._grpSystemScheduleOfRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgRates)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpSystemScheduleOfRate
            // 
            this._grpSystemScheduleOfRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSystemScheduleOfRate.Controls.Add(this._txtDept);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label9);
            this._grpSystemScheduleOfRate.Controls.Add(this._txtNominal);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label8);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label7);
            this._grpSystemScheduleOfRate.Controls.Add(this._DateTimePicker1);
            this._grpSystemScheduleOfRate.Controls.Add(this._dgRates);
            this._grpSystemScheduleOfRate.Controls.Add(this._txtAfter);
            this._grpSystemScheduleOfRate.Controls.Add(this._txtCredit);
            this._grpSystemScheduleOfRate.Controls.Add(this._txtInvoiced);
            this._grpSystemScheduleOfRate.Controls.Add(this._txtExRef);
            this._grpSystemScheduleOfRate.Controls.Add(this._cboUser);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label1);
            this._grpSystemScheduleOfRate.Controls.Add(this._txtReason);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnCancel);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnAdd);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label3);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label2);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label5);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label4);
            this._grpSystemScheduleOfRate.Controls.Add(this._Label6);
            this._grpSystemScheduleOfRate.Location = new System.Drawing.Point(8, 12);
            this._grpSystemScheduleOfRate.Name = "_grpSystemScheduleOfRate";
            this._grpSystemScheduleOfRate.Size = new System.Drawing.Size(632, 452);
            this._grpSystemScheduleOfRate.TabIndex = 2;
            this._grpSystemScheduleOfRate.TabStop = false;
            this._grpSystemScheduleOfRate.Text = "Credit Details";
            this._grpSystemScheduleOfRate.Enter += new System.EventHandler(this.grpSystemScheduleOfRate_Enter);
            // 
            // _txtDept
            // 
            this._txtDept.Location = new System.Drawing.Point(121, 263);
            this._txtDept.Name = "_txtDept";
            this._txtDept.Size = new System.Drawing.Size(100, 21);
            this._txtDept.TabIndex = 52;
            // 
            // _Label9
            // 
            this._Label9.AutoSize = true;
            this._Label9.Location = new System.Drawing.Point(119, 247);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(34, 13);
            this._Label9.TabIndex = 53;
            this._Label9.Text = "Dept";
            // 
            // _txtNominal
            // 
            this._txtNominal.Location = new System.Drawing.Point(9, 263);
            this._txtNominal.Name = "_txtNominal";
            this._txtNominal.Size = new System.Drawing.Size(100, 21);
            this._txtNominal.TabIndex = 50;
            // 
            // _Label8
            // 
            this._Label8.AutoSize = true;
            this._Label8.Location = new System.Drawing.Point(7, 247);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(53, 13);
            this._Label8.TabIndex = 51;
            this._Label8.Text = "Nominal";
            // 
            // _Label7
            // 
            this._Label7.AutoSize = true;
            this._Label7.Location = new System.Drawing.Point(6, 287);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(88, 13);
            this._Label7.TabIndex = 49;
            this._Label7.Text = "Date of Credit";
            // 
            // _DateTimePicker1
            // 
            this._DateTimePicker1.Location = new System.Drawing.Point(9, 303);
            this._DateTimePicker1.Name = "_DateTimePicker1";
            this._DateTimePicker1.Size = new System.Drawing.Size(324, 21);
            this._DateTimePicker1.TabIndex = 48;
            // 
            // _dgRates
            // 
            this._dgRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgRates.Location = new System.Drawing.Point(6, 20);
            this._dgRates.Name = "_dgRates";
            this._dgRates.Size = new System.Drawing.Size(620, 170);
            this._dgRates.TabIndex = 47;
            this._dgRates.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellEndEdit);
            // 
            // _txtAfter
            // 
            this._txtAfter.Location = new System.Drawing.Point(495, 306);
            this._txtAfter.Name = "_txtAfter";
            this._txtAfter.ReadOnly = true;
            this._txtAfter.Size = new System.Drawing.Size(112, 21);
            this._txtAfter.TabIndex = 45;
            // 
            // _txtCredit
            // 
            this._txtCredit.Location = new System.Drawing.Point(495, 262);
            this._txtCredit.Name = "_txtCredit";
            this._txtCredit.ReadOnly = true;
            this._txtCredit.Size = new System.Drawing.Size(112, 21);
            this._txtCredit.TabIndex = 43;
            // 
            // _txtInvoiced
            // 
            this._txtInvoiced.Location = new System.Drawing.Point(495, 221);
            this._txtInvoiced.Name = "_txtInvoiced";
            this._txtInvoiced.ReadOnly = true;
            this._txtInvoiced.Size = new System.Drawing.Size(112, 21);
            this._txtInvoiced.TabIndex = 41;
            // 
            // _txtExRef
            // 
            this._txtExRef.Location = new System.Drawing.Point(233, 262);
            this._txtExRef.Name = "_txtExRef";
            this._txtExRef.Size = new System.Drawing.Size(100, 21);
            this._txtExRef.TabIndex = 39;
            // 
            // _cboUser
            // 
            this._cboUser.FormattingEnabled = true;
            this._cboUser.Location = new System.Drawing.Point(9, 221);
            this._cboUser.Name = "_cboUser";
            this._cboUser.Size = new System.Drawing.Size(324, 21);
            this._cboUser.TabIndex = 37;
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(6, 332);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(110, 13);
            this._Label1.TabIndex = 36;
            this._Label1.Text = "Reason For Credit";
            // 
            // _txtReason
            // 
            this._txtReason.Location = new System.Drawing.Point(8, 350);
            this._txtReason.Multiline = true;
            this._txtReason.Name = "_txtReason";
            this._txtReason.Size = new System.Drawing.Size(611, 40);
            this._txtReason.TabIndex = 35;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(8, 400);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 34;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _btnAdd
            // 
            this._btnAdd.Location = new System.Drawing.Point(518, 400);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(101, 23);
            this._btnAdd.TabIndex = 33;
            this._btnAdd.Text = "Create Credit";
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // _Label3
            // 
            this._Label3.AutoSize = true;
            this._Label3.Location = new System.Drawing.Point(231, 246);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(44, 13);
            this._Label3.TabIndex = 40;
            this._Label3.Text = "Ex Ref";
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(6, 203);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(86, 13);
            this._Label2.TabIndex = 38;
            this._Label2.Text = "Requested By";
            // 
            // _Label5
            // 
            this._Label5.AutoSize = true;
            this._Label5.Location = new System.Drawing.Point(505, 247);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(87, 13);
            this._Label5.TabIndex = 44;
            this._Label5.Text = "Total Credited";
            // 
            // _Label4
            // 
            this._Label4.AutoSize = true;
            this._Label4.Location = new System.Drawing.Point(479, 203);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(145, 13);
            this._Label4.TabIndex = 42;
            this._Label4.Text = "Total Originally Invoiced";
            // 
            // _Label6
            // 
            this._Label6.AutoSize = true;
            this._Label6.Location = new System.Drawing.Point(474, 287);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(150, 13);
            this._Label6.TabIndex = 46;
            this._Label6.Text = "Total Invoice after Credit";
            // 
            // FRMSalesCredit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(648, 470);
            this.Controls.Add(this._grpSystemScheduleOfRate);
            this.MinimumSize = new System.Drawing.Size(656, 504);
            this.Name = "FRMSalesCredit";
            this.Text = "Property Schedule Of Rates List";
            this._grpSystemScheduleOfRate.ResumeLayout(false);
            this._grpSystemScheduleOfRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgRates)).EndInit();
            this.ResumeLayout(false);

        }

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