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
    public class FRMSystemScheduleOfRateList : FRMBaseForm, IForm
    {
        public FRMSystemScheduleOfRateList()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMSystemScheduleOfRate_Load;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMSystemScheduleOfRateList(Entity.Sys.Enums.TableNames EntityToLinkToIn, int IDToLinkToIn, int AdditionalIDIn = 0) : base()
        {
            base.Load += FRMSystemScheduleOfRate_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            EntityToLinkTo = EntityToLinkToIn;
            IDToLinkTo = IDToLinkToIn;
            AdditionalID = AdditionalIDIn;
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
            _btnDeselectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDeselectAll.Location = new Point(112, 360);
            _btnDeselectAll.Name = "btnDeselectAll";
            _btnDeselectAll.Size = new Size(96, 23);
            _btnDeselectAll.TabIndex = 36;
            _btnDeselectAll.Text = "Deselect All";
            //
            // btnSelectAll
            //
            _btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectAll.Location = new Point(8, 360);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(96, 23);
            _btnSelectAll.TabIndex = 35;
            _btnSelectAll.Text = "Select All";
            //
            // btnCancel
            //
            _btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnCancel.Location = new Point(8, 400);
            _btnCancel.Name = "btnCancel";
            _btnCancel.TabIndex = 34;
            _btnCancel.Text = "Cancel";
            //
            // btnAdd
            //
            _btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
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
            // FRMSystemScheduleOfRateList
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(648, 470);
            Controls.Add(_grpSystemScheduleOfRate);
            MinimumSize = new Size(656, 504);
            Name = "FRMSystemScheduleOfRateList";
            Text = "System Schedule Of Rates List";
            Controls.SetChildIndex(_grpSystemScheduleOfRate, 0);
            _grpSystemScheduleOfRate.ResumeLayout(false);
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
        private Entity.Sys.Enums.TableNames _EntityToLinkTo;

        public Entity.Sys.Enums.TableNames EntityToLinkTo
        {
            get
            {
                return _EntityToLinkTo;
            }

            set
            {
                _EntityToLinkTo = value;
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

        private int _AdditionalID = 0;

        public int AdditionalID
        {
            get
            {
                return _AdditionalID;
            }

            set
            {
                _AdditionalID = value;
            }
        }

        private DataView _dvRates;

        private DataView RatesDataview
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
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 100;
            Category.NullText = "";
            tbStyle.GridColumnStyles.Add(Category);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 75;
            Code.NullText = "";
            tbStyle.GridColumnStyles.Add(Code);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Description";
            Description.ReadOnly = true;
            Description.Width = 200;
            Description.NullText = "";
            tbStyle.GridColumnStyles.Add(Description);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Unit Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 75;
            Price.NullText = "";
            tbStyle.GridColumnStyles.Add(Price);
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

        public void Populate()
        {
            if (EntityToLinkTo == Entity.Sys.Enums.TableNames.tblCustomer)
            {
                RatesDataview = App.DB.SystemScheduleOfRate.SystemScheduleOfRate_GetAll_WithoutDefaults();
            }
            else
            {
                RatesDataview = App.DB.CustomerScheduleOfRate.GetAll_WithoutDefaults(AdditionalID);
            }
        }

        private void Add()
        {
            if (EntityToLinkTo == Entity.Sys.Enums.TableNames.tblCustomer)
            {
                foreach (DataRow dr in RatesDataview.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["tick"], true, false)))
                    {
                        var cSoR = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate();
                        cSoR.SetCustomerID = IDToLinkTo;
                        cSoR.SetAllowDeleted = dr["AllowDeleted"];
                        cSoR.SetScheduleOfRatesCategoryID = dr["ScheduleOfRatesCategoryID"];
                        cSoR.SetCode = dr["Code"];
                        cSoR.SetDescription = dr["Description"];
                        cSoR.SetPrice = dr["Price"];
                        cSoR.SetTimeInMins = Entity.Sys.Helper.MakeIntegerValid(dr["TimeInMins"]);
                        App.DB.CustomerScheduleOfRate.Insert(cSoR);
                    }
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}