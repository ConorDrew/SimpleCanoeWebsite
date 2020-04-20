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
    public class FRMPartsForCreditList : FRMBaseForm, IForm
    {
        public FRMPartsForCreditList()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMSystemScheduleOfRate_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public FRMPartsForCreditList(int IDToLinkToIn, bool FromQuoteJobIn = false, bool FromJobIn = false) : base()
        {
            base.Load += FRMSystemScheduleOfRate_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            FromQuoteJob = FromQuoteJobIn;
            FromJob = FromJobIn;
            IDToLinkTo = IDToLinkToIn;
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
                }

                _grpSystemScheduleOfRate = value;
                if (_grpSystemScheduleOfRate != null)
                {
                }
            }
        }

        private DataGrid _dgRates;

        internal DataGrid dgRates
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
                    _dgRates.Click -= dgRates_Click;
                }

                _dgRates = value;
                if (_dgRates != null)
                {
                    _dgRates.Click += dgRates_Click;
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

        private Button _btnSelectAll;

        internal Button btnSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click -= btnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += btnSelectAll_Click;
                }
            }
        }

        private Button _btnDeselectAll;

        internal Button btnDeselectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeselectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click -= btnDeselectAll_Click;
                }

                _btnDeselectAll = value;
                if (_btnDeselectAll != null)
                {
                    _btnDeselectAll.Click += btnDeselectAll_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpSystemScheduleOfRate = new GroupBox();
            _btnDeselectAll = new Button();
            _btnDeselectAll.Click += new EventHandler(btnDeselectAll_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnCancel = new Button();
            _btnCancel.Click += new EventHandler(btnCancel_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgRates = new DataGrid();
            _dgRates.Click += new EventHandler(dgRates_Click);
            _grpSystemScheduleOfRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRates).BeginInit();
            SuspendLayout();
            // 
            // grpSystemScheduleOfRate
            // 
            _grpSystemScheduleOfRate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSystemScheduleOfRate.Controls.Add(_btnDeselectAll);
            _grpSystemScheduleOfRate.Controls.Add(_btnSelectAll);
            _grpSystemScheduleOfRate.Controls.Add(_btnCancel);
            _grpSystemScheduleOfRate.Controls.Add(_btnAdd);
            _grpSystemScheduleOfRate.Controls.Add(_dgRates);
            _grpSystemScheduleOfRate.Location = new Point(8, 32);
            _grpSystemScheduleOfRate.Name = "grpSystemScheduleOfRate";
            _grpSystemScheduleOfRate.Size = new Size(632, 432);
            _grpSystemScheduleOfRate.TabIndex = 2;
            _grpSystemScheduleOfRate.TabStop = false;
            _grpSystemScheduleOfRate.Text = "Main Details";
            // 
            // btnDeselectAll
            // 
            _btnDeselectAll.Location = new Point(112, 360);
            _btnDeselectAll.Name = "btnDeselectAll";
            _btnDeselectAll.Size = new Size(96, 23);
            _btnDeselectAll.TabIndex = 36;
            _btnDeselectAll.Text = "Deselect All";
            // 
            // btnSelectAll
            // 
            _btnSelectAll.Location = new Point(8, 360);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(96, 23);
            _btnSelectAll.TabIndex = 35;
            _btnSelectAll.Text = "Select All";
            // 
            // btnCancel
            // 
            _btnCancel.Location = new Point(8, 400);
            _btnCancel.Name = "btnCancel";
            _btnCancel.TabIndex = 34;
            _btnCancel.Text = "Cancel";
            // 
            // btnAdd
            // 
            _btnAdd.Location = new Point(544, 400);
            _btnAdd.Name = "btnAdd";
            _btnAdd.TabIndex = 33;
            _btnAdd.Text = "Add";
            // 
            // dgRates
            // 
            _dgRates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgRates.DataMember = "";
            _dgRates.HeaderForeColor = SystemColors.ControlText;
            _dgRates.Location = new Point(8, 19);
            _dgRates.Name = "dgRates";
            _dgRates.Size = new Size(618, 333);
            _dgRates.TabIndex = 32;
            // 
            // FRMSiteScheduleOfRateList
            // 
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(648, 470);
            Controls.Add(_grpSystemScheduleOfRate);
            MinimumSize = new Size(656, 504);
            Name = "FRMSiteScheduleOfRateList";
            Text = "Property Schedule Of Rates List";
            Controls.SetChildIndex(_grpSystemScheduleOfRate, 0);
            _grpSystemScheduleOfRate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgRates).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadMe(object sender, EventArgs e)
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

        private int _IDToLinkTo = 0;

        public int IDToLinkTo
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

        private DataRow SelectedRatesDataRow
        {
            get
            {
                if (!(dgRates.CurrentRowIndex == -1))
                {
                    return RatesDataview[dgRates.CurrentRowIndex].Row;
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
            Entity.Sys.Helper.SetUpDataGrid(dgRates);
            var tbStyle = dgRates.TableStyles[0];
            dgRates.ReadOnly = false;
            tbStyle.AllowSorting = false;
            tbStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Part Number";
            Code.MappingName = "Number";
            Code.ReadOnly = true;
            Code.Width = 65;
            Code.NullText = "";
            tbStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Name";
            Description.ReadOnly = true;
            Description.Width = 170;
            Description.NullText = "";
            tbStyle.GridColumnStyles.Add(Description);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Unit Price";
            Price.MappingName = "BuyPrice";
            Price.ReadOnly = true;
            Price.Width = 75;
            Price.NullText = "";
            tbStyle.GridColumnStyles.Add(Price);
            var QtyPerVisit = new DataGridLabelColumn();
            QtyPerVisit.Format = "";
            QtyPerVisit.FormatInfo = null;
            QtyPerVisit.HeaderText = "Qty Received";
            QtyPerVisit.MappingName = "QuantityReceived";
            QtyPerVisit.ReadOnly = true;
            QtyPerVisit.Width = 100;
            QtyPerVisit.NullText = "";
            tbStyle.GridColumnStyles.Add(QtyPerVisit);
            var QtyPerVisit2 = new DataGridEditableTextBoxColumn();
            QtyPerVisit2.Format = "";
            QtyPerVisit2.FormatInfo = null;
            QtyPerVisit2.HeaderText = "Qty to credit";
            QtyPerVisit2.MappingName = "QtyToCredit";
            QtyPerVisit2.ReadOnly = false;
            QtyPerVisit2.Width = 100;
            QtyPerVisit2.NullText = "";
            tbStyle.GridColumnStyles.Add(QtyPerVisit2);
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblSystemScheduleOfRate.ToString();
            dgRates.TableStyles.Add(tbStyle);
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in RatesDataview.Table.Rows)
                dr["tick"] = true;
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in RatesDataview.Table.Rows)
                dr["tick"] = false;
        }

        private void dgRates_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedRatesDataRow is null)
                {
                    return;
                }

                bool selected = !Conversions.ToBoolean(dgRates[dgRates.CurrentRowIndex, 0]);
                dgRates[dgRates.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate()
        {
            RatesDataview = App.DB.Order.Order_ItemsGetAll(IDToLinkTo);
        }

        private void Add()
        {
            bool sucsess = false;
            foreach (DataRow dr in RatesDataview.Table.Rows)
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["tick"], true, false) & dr["QtyToCredit"] > 0))
                {
                    sucsess = true;
                    break;
                }
            }

            if (sucsess == false)
            {
                App.ShowMessage("You need to select at least 1 qty of a Part", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RatesDataview.Table.Clear();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}