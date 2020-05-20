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
                    _dgCustomers.MouseUp -= _dgCustomers_MouseUp;
                }

                _dgCustomers = value;
                if (_dgCustomers != null)
                {
                    _dgCustomers.MouseUp += _dgCustomers_MouseUp;
                }
            }
        }

        private Button _btnClearAll;

        private Button _btnSelectAll;

        private Label _lblCustomerName;

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
            this._grpCustomers = new System.Windows.Forms.GroupBox();
            this._txtFilter = new System.Windows.Forms.TextBox();
            this._lblCustomerName = new System.Windows.Forms.Label();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnClearAll = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._dgCustomers = new System.Windows.Forms.DataGrid();
            this._grpCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // _grpCustomers
            // 
            this._grpCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCustomers.Controls.Add(this._txtFilter);
            this._grpCustomers.Controls.Add(this._lblCustomerName);
            this._grpCustomers.Controls.Add(this._btnOk);
            this._grpCustomers.Controls.Add(this._btnClearAll);
            this._grpCustomers.Controls.Add(this._btnSelectAll);
            this._grpCustomers.Controls.Add(this._dgCustomers);
            this._grpCustomers.Font = new System.Drawing.Font("Verdana", 8F);
            this._grpCustomers.Location = new System.Drawing.Point(8, 12);
            this._grpCustomers.Name = "_grpCustomers";
            this._grpCustomers.Size = new System.Drawing.Size(661, 448);
            this._grpCustomers.TabIndex = 10;
            this._grpCustomers.TabStop = false;
            this._grpCustomers.Text = "Customer to Add";
            // 
            // _txtFilter
            // 
            this._txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFilter.Location = new System.Drawing.Point(118, 31);
            this._txtFilter.Name = "_txtFilter";
            this._txtFilter.Size = new System.Drawing.Size(219, 20);
            this._txtFilter.TabIndex = 49;
            this._txtFilter.TextChanged += new System.EventHandler(this.TxtFilter_TextChanged);
            // 
            // _lblCustomerName
            // 
            this._lblCustomerName.Location = new System.Drawing.Point(7, 34);
            this._lblCustomerName.Name = "_lblCustomerName";
            this._lblCustomerName.Size = new System.Drawing.Size(105, 20);
            this._lblCustomerName.TabIndex = 48;
            this._lblCustomerName.Text = "Customer Name";
            // 
            // _btnOk
            // 
            this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOk.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnOk.Location = new System.Drawing.Point(588, 414);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(64, 23);
            this._btnOk.TabIndex = 4;
            this._btnOk.Text = "Ok";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // _btnClearAll
            // 
            this._btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnClearAll.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnClearAll.Location = new System.Drawing.Point(80, 414);
            this._btnClearAll.Name = "_btnClearAll";
            this._btnClearAll.Size = new System.Drawing.Size(64, 23);
            this._btnClearAll.TabIndex = 3;
            this._btnClearAll.Text = "Clear All";
            this._btnClearAll.UseVisualStyleBackColor = true;
            this._btnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelectAll.Font = new System.Drawing.Font("Verdana", 8F);
            this._btnSelectAll.Location = new System.Drawing.Point(10, 414);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(64, 23);
            this._btnSelectAll.TabIndex = 2;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.BtnSelectAll_Click);
            // 
            // _dgCustomers
            // 
            this._dgCustomers.AllowNavigation = false;
            this._dgCustomers.AlternatingBackColor = System.Drawing.Color.GhostWhite;
            this._dgCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgCustomers.BackgroundColor = System.Drawing.Color.White;
            this._dgCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._dgCustomers.CaptionBackColor = System.Drawing.Color.RoyalBlue;
            this._dgCustomers.CaptionForeColor = System.Drawing.Color.White;
            this._dgCustomers.CaptionText = "Engineers";
            this._dgCustomers.CaptionVisible = false;
            this._dgCustomers.DataMember = "";
            this._dgCustomers.Font = new System.Drawing.Font("Verdana", 8F);
            this._dgCustomers.ForeColor = System.Drawing.Color.MidnightBlue;
            this._dgCustomers.GridLineColor = System.Drawing.Color.RoyalBlue;
            this._dgCustomers.HeaderBackColor = System.Drawing.Color.MidnightBlue;
            this._dgCustomers.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this._dgCustomers.HeaderForeColor = System.Drawing.Color.Lavender;
            this._dgCustomers.LinkColor = System.Drawing.Color.Teal;
            this._dgCustomers.Location = new System.Drawing.Point(10, 72);
            this._dgCustomers.Name = "_dgCustomers";
            this._dgCustomers.ParentRowsBackColor = System.Drawing.Color.Lavender;
            this._dgCustomers.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this._dgCustomers.ParentRowsVisible = false;
            this._dgCustomers.RowHeadersVisible = false;
            this._dgCustomers.SelectionBackColor = System.Drawing.Color.Teal;
            this._dgCustomers.SelectionForeColor = System.Drawing.Color.PaleGreen;
            this._dgCustomers.Size = new System.Drawing.Size(642, 333);
            this._dgCustomers.TabIndex = 1;
            this._dgCustomers.MouseUp += new System.Windows.Forms.MouseEventHandler(this._dgCustomers_MouseUp);
            // 
            // FRMFindCustomers
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(672, 461);
            this.Controls.Add(this._grpCustomers);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(688, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(688, 400);
            this.Name = "FRMFindCustomers";
            this.Text = "Customers";
            this._grpCustomers.ResumeLayout(false);
            this._grpCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCustomers)).EndInit();
            this.ResumeLayout(false);

        }

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

        private void _dgCustomers_MouseUp(object sender, MouseEventArgs e)
        {
            int includeColumn = 0;
            DataGrid.HitTestInfo hti = dgCustomers.HitTest(e.X, e.Y);
            if (hti.Type == DataGrid.HitTestType.Cell)
            {
                if (hti.Column == includeColumn)
                {
                    bool selected = !Conversions.ToBoolean(dgCustomers[hti.Row, includeColumn]);
                    dgCustomers[hti.Row, includeColumn] = selected;
                }
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
    }
}