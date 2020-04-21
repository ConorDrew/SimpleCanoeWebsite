using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMFindCustomers : FRMBaseForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMFindCustomers() : base()
        {
            base.Load += FrmDisplayEngineers_Load;

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
        private GroupBox _grpCustomers;

        internal GroupBox grpCustomers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCustomers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCustomers != null)
                {
                }

                _grpCustomers = value;
                if (_grpCustomers != null)
                {
                }
            }
        }

        private DataGrid _dgCustomers;

        internal DataGrid dgCustomers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCustomers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCustomers != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    _dgCustomers.Click -= DgCustomers_Click;
                    _dgCustomers.DoubleClick -= DgCustomers_Click;
                }

                _dgCustomers = value;
                if (_dgCustomers != null)
                {
                    _dgCustomers.Click += DgCustomers_Click;
                    _dgCustomers.DoubleClick += DgCustomers_Click;
                }
            }
        }

        private Button _btnClearAll;

        internal Button btnClearAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClearAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClearAll != null)
                {
                    _btnClearAll.Click -= BtnClearAll_Click;
                }

                _btnClearAll = value;
                if (_btnClearAll != null)
                {
                    _btnClearAll.Click += BtnClearAll_Click;
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
                    _btnSelectAll.Click -= BtnSelectAll_Click;
                }

                _btnSelectAll = value;
                if (_btnSelectAll != null)
                {
                    _btnSelectAll.Click += BtnSelectAll_Click;
                }
            }
        }

        private Label _lblCustomerName;

        internal Label lblCustomerName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomerName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomerName != null)
                {
                }

                _lblCustomerName = value;
                if (_lblCustomerName != null)
                {
                }
            }
        }

        private TextBox _txtFilter;

        internal TextBox txtFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFilter != null)
                {
                    _txtFilter.TextChanged -= TxtFilter_TextChanged;
                }

                _txtFilter = value;
                if (_txtFilter != null)
                {
                    _txtFilter.TextChanged += TxtFilter_TextChanged;
                }
            }
        }

        private Button _btnOk;

        internal Button btnOk
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOk;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOk != null)
                {
                    _btnOk.Click -= BtnOk_Click;
                }

                _btnOk = value;
                if (_btnOk != null)
                {
                    _btnOk.Click += BtnOk_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpCustomers = new GroupBox();
            _txtFilter = new TextBox();
            _txtFilter.TextChanged += new EventHandler(TxtFilter_TextChanged);
            _lblCustomerName = new Label();
            _btnOk = new Button();
            _btnOk.Click += new EventHandler(BtnOk_Click);
            _btnClearAll = new Button();
            _btnClearAll.Click += new EventHandler(BtnClearAll_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(BtnSelectAll_Click);
            _dgCustomers = new DataGrid();
            _dgCustomers.Click += new EventHandler(DgCustomers_Click);
            _dgCustomers.DoubleClick += new EventHandler(DgCustomers_Click);
            _dgCustomers.Click += new EventHandler(DgCustomers_Click);
            _dgCustomers.DoubleClick += new EventHandler(DgCustomers_Click);
            _grpCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCustomers).BeginInit();
            SuspendLayout();
            //
            // grpCustomers
            //
            _grpCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpCustomers.Controls.Add(_txtFilter);
            _grpCustomers.Controls.Add(_lblCustomerName);
            _grpCustomers.Controls.Add(_btnOk);
            _grpCustomers.Controls.Add(_btnClearAll);
            _grpCustomers.Controls.Add(_btnSelectAll);
            _grpCustomers.Controls.Add(_dgCustomers);
            _grpCustomers.Font = new Font("Verdana", 8.0F);
            _grpCustomers.Location = new Point(8, 32);
            _grpCustomers.Name = "grpCustomers";
            _grpCustomers.Size = new Size(661, 428);
            _grpCustomers.TabIndex = 10;
            _grpCustomers.TabStop = false;
            _grpCustomers.Text = "Customer to Add";
            //
            // txtFilter
            //
            _txtFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtFilter.Location = new Point(118, 31);
            _txtFilter.Name = "txtFilter";
            _txtFilter.Size = new Size(219, 20);
            _txtFilter.TabIndex = 49;
            //
            // lblCustomerName
            //
            _lblCustomerName.Location = new Point(7, 34);
            _lblCustomerName.Name = "lblCustomerName";
            _lblCustomerName.Size = new Size(105, 20);
            _lblCustomerName.TabIndex = 48;
            _lblCustomerName.Text = "Customer Name";
            //
            // btnOk
            //
            _btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnOk.Font = new Font("Verdana", 8.0F);
            _btnOk.Location = new Point(588, 394);
            _btnOk.Name = "btnOk";
            _btnOk.Size = new Size(64, 23);
            _btnOk.TabIndex = 4;
            _btnOk.Text = "Ok";
            _btnOk.UseVisualStyleBackColor = true;
            //
            // btnClearAll
            //
            _btnClearAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnClearAll.Font = new Font("Verdana", 8.0F);
            _btnClearAll.Location = new Point(80, 394);
            _btnClearAll.Name = "btnClearAll";
            _btnClearAll.Size = new Size(64, 23);
            _btnClearAll.TabIndex = 3;
            _btnClearAll.Text = "Clear All";
            _btnClearAll.UseVisualStyleBackColor = true;
            //
            // btnSelectAll
            //
            _btnSelectAll.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectAll.Font = new Font("Verdana", 8.0F);
            _btnSelectAll.Location = new Point(10, 394);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(64, 23);
            _btnSelectAll.TabIndex = 2;
            _btnSelectAll.Text = "Select All";
            _btnSelectAll.UseVisualStyleBackColor = true;
            //
            // dgCustomers
            //
            _dgCustomers.AllowNavigation = false;
            _dgCustomers.AlternatingBackColor = Color.GhostWhite;
            _dgCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgCustomers.BackgroundColor = Color.White;
            _dgCustomers.BorderStyle = BorderStyle.FixedSingle;
            _dgCustomers.CaptionBackColor = Color.RoyalBlue;
            _dgCustomers.CaptionForeColor = Color.White;
            _dgCustomers.CaptionText = "Engineers";
            _dgCustomers.CaptionVisible = false;
            _dgCustomers.DataMember = "";
            _dgCustomers.Font = new Font("Verdana", 8.0F);
            _dgCustomers.ForeColor = Color.MidnightBlue;
            _dgCustomers.GridLineColor = Color.RoyalBlue;
            _dgCustomers.HeaderBackColor = Color.MidnightBlue;
            _dgCustomers.HeaderFont = new Font("Tahoma", 8.0F, FontStyle.Bold);
            _dgCustomers.HeaderForeColor = Color.Lavender;
            _dgCustomers.LinkColor = Color.Teal;
            _dgCustomers.Location = new Point(10, 72);
            _dgCustomers.Name = "dgCustomers";
            _dgCustomers.ParentRowsBackColor = Color.Lavender;
            _dgCustomers.ParentRowsForeColor = Color.MidnightBlue;
            _dgCustomers.ParentRowsVisible = false;
            _dgCustomers.RowHeadersVisible = false;
            _dgCustomers.SelectionBackColor = Color.Teal;
            _dgCustomers.SelectionForeColor = Color.PaleGreen;
            _dgCustomers.Size = new Size(642, 313);
            _dgCustomers.TabIndex = 1;
            //
            // FRMFindCustomers
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(672, 461);
            Controls.Add(_grpCustomers);
            MaximizeBox = false;
            MaximumSize = new Size(688, 500);
            MinimizeBox = false;
            MinimumSize = new Size(688, 400);
            Name = "FRMFindCustomers";
            Text = "Customers";
            Controls.SetChildIndex(_grpCustomers, 0);
            _grpCustomers.ResumeLayout(false);
            _grpCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCustomers).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private DataView _dvCustomers;

        public DataView CustomerDataView
        {
            get
            {
                return _dvCustomers;
            }

            set
            {
                _dvCustomers = value;
                if (CustomerDataView is object)
                {
                    if (CustomerDataView.Table is object)
                    {
                        _dvCustomers.Table.TableName = Conversions.ToString(Entity.Sys.Enums.TableNames.tblCustomer);
                        _dvCustomers.AllowNew = false;
                    }
                }

                dgCustomers.DataSource = CustomerDataView;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetUpDataGrid()
        {
            SuspendLayout();
            Entity.Sys.Helper.SetUpDataGrid(dgCustomers);
            var tStyle = dgCustomers.TableStyles[0];

            // Set up columns
            tStyle.ReadOnly = false;
            dgCustomers.ReadOnly = false;
            var include = new DataGridBoolColumn();
            include.HeaderText = "Include";
            include.MappingName = "Include";
            include.ReadOnly = false;
            include.Width = 50;
            // turn off tristate
            include.AllowNull = false;
            tStyle.GridColumnStyles.Add(include);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 170;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var AccountNumber = new DataGridLabelColumn();
            AccountNumber.Format = "";
            AccountNumber.FormatInfo = null;
            AccountNumber.HeaderText = "Account Number";
            AccountNumber.MappingName = "AccountNumber";
            AccountNumber.ReadOnly = true;
            AccountNumber.Width = 100;
            AccountNumber.NullText = "";
            tStyle.GridColumnStyles.Add(AccountNumber);
            var Region = new DataGridLabelColumn();
            Region.Format = "";
            Region.FormatInfo = null;
            Region.HeaderText = "Region";
            Region.MappingName = "Region";
            Region.ReadOnly = true;
            Region.Width = 100;
            Region.NullText = "";
            tStyle.GridColumnStyles.Add(Region);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 140;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var HO = new DataGridLabelColumn();
            HO.Format = "";
            HO.FormatInfo = null;
            HO.HeaderText = "Head Office";
            HO.MappingName = "ho";
            HO.ReadOnly = true;
            HO.Width = 250;
            HO.NullText = "";
            tStyle.GridColumnStyles.Add(HO);
            tStyle.MappingName = Conversions.ToString(Entity.Sys.Enums.TableNames.tblCustomer);
            dgCustomers.TableStyles.Add(tStyle);
            ResumeLayout(true);
        }

        private void DgCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                // this code mainly facilitates single clicks to change the state of a checkbox
                int includeColumn = 0;
                var pt = dgCustomers.PointToClient(MousePosition);
                var hti = dgCustomers.HitTest(pt);
                var bmb = BindingContext[dgCustomers.DataSource,
dgCustomers.DataMember];
                if (hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell && hti.Column == includeColumn)
                {
                    bool selected = !Conversions.ToBoolean(dgCustomers[hti.Row, includeColumn]);
                    dgCustomers[hti.Row, includeColumn] = selected;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            if (CustomerDataView is object)
            {
                if (CustomerDataView.Table is object)
                {
                    foreach (DataRow r in CustomerDataView.Table.Rows)
                        r["Include"] = true;
                }
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            if (CustomerDataView is object)
            {
                if (CustomerDataView.Table is object)
                {
                    foreach (DataRow r in CustomerDataView.Table.Rows)
                        r["Include"] = false;
                }

                txtFilter.Text = string.Empty;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDisplayEngineers_Load(object sender, EventArgs e)
        {
            LoadForm(this);
            SetUpDataGrid();
            Populate();
        }

        private void Populate()
        {
            CustomerDataView = App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID);
            if (CustomerDataView is null)
                return;
            var dtCustomers = CustomerDataView.Table;
            dtCustomers.Columns.Add("Include", typeof(bool));
            foreach (DataRow dr in dtCustomers.Rows)
                dr["Include"] = false;
            CustomerDataView = new DataView(dtCustomers);
        }

        private void TxtFilter_TextChanged(object sender, EventArgs e)
        {
            if (CustomerDataView is object)
            {
                if (CustomerDataView.Table is object)
                {
                    CustomerDataView.RowFilter = "Name LIKE '%" + txtFilter.Text + "%'";
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}