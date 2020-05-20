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
            
            
            base.Load += FRMSystemScheduleOfRate_Load;
        }

        

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
            this._grpSystemScheduleOfRate = new System.Windows.Forms.GroupBox();
            this._btnDeselectAll = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._dgRates = new System.Windows.Forms.DataGrid();
            this._grpSystemScheduleOfRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgRates)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpSystemScheduleOfRate
            // 
            this._grpSystemScheduleOfRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSystemScheduleOfRate.Controls.Add(this._btnDeselectAll);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnSelectAll);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnCancel);
            this._grpSystemScheduleOfRate.Controls.Add(this._btnAdd);
            this._grpSystemScheduleOfRate.Controls.Add(this._dgRates);
            this._grpSystemScheduleOfRate.Location = new System.Drawing.Point(8, 12);
            this._grpSystemScheduleOfRate.Name = "_grpSystemScheduleOfRate";
            this._grpSystemScheduleOfRate.Size = new System.Drawing.Size(632, 452);
            this._grpSystemScheduleOfRate.TabIndex = 2;
            this._grpSystemScheduleOfRate.TabStop = false;
            this._grpSystemScheduleOfRate.Text = "Main Details";
            // 
            // _btnDeselectAll
            // 
            this._btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDeselectAll.Location = new System.Drawing.Point(112, 380);
            this._btnDeselectAll.Name = "_btnDeselectAll";
            this._btnDeselectAll.Size = new System.Drawing.Size(96, 23);
            this._btnDeselectAll.TabIndex = 36;
            this._btnDeselectAll.Text = "Deselect All";
            this._btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelectAll.Location = new System.Drawing.Point(8, 380);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(96, 23);
            this._btnSelectAll.TabIndex = 35;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnCancel.Location = new System.Drawing.Point(8, 420);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 34;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // _btnAdd
            // 
            this._btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAdd.Location = new System.Drawing.Point(544, 420);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(75, 23);
            this._btnAdd.TabIndex = 33;
            this._btnAdd.Text = "Add";
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // _dgRates
            // 
            this._dgRates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgRates.DataMember = "";
            this._dgRates.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgRates.Location = new System.Drawing.Point(8, 19);
            this._dgRates.Name = "_dgRates";
            this._dgRates.Size = new System.Drawing.Size(618, 353);
            this._dgRates.TabIndex = 32;
            this._dgRates.Click += new System.EventHandler(this.dgRates_Click);
            // 
            // FRMSystemScheduleOfRateList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(648, 470);
            this.Controls.Add(this._grpSystemScheduleOfRate);
            this.MinimumSize = new System.Drawing.Size(656, 504);
            this.Name = "FRMSystemScheduleOfRateList";
            this.Text = "System Schedule Of Rates List";
            this._grpSystemScheduleOfRate.ResumeLayout(false);
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

        
    }
}