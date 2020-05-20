using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FSM.Entity.Sys;

namespace FSM
{
    public class FRMSchedulerFind : FRMBaseForm, IForm
    {
        public FRMSchedulerFind() : base()
        {
            base.Load += FRMSchedulerFind_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
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

        private GroupBox _grpFind;

        private RadioButton _rbtnOrder;

        internal RadioButton rbtnOrder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbtnOrder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbtnOrder != null)
                {
                    _rbtnOrder.CheckedChanged -= rbtn_CheckedChanged;
                }

                _rbtnOrder = value;
                if (_rbtnOrder != null)
                {
                    _rbtnOrder.CheckedChanged += rbtn_CheckedChanged;
                }
            }
        }

        private RadioButton _rbtnJob;

        internal RadioButton rbtnJob
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbtnJob;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbtnJob != null)
                {
                    _rbtnJob.CheckedChanged -= rbtn_CheckedChanged;
                }

                _rbtnJob = value;
                if (_rbtnJob != null)
                {
                    _rbtnJob.CheckedChanged += rbtn_CheckedChanged;
                }
            }
        }

        private RadioButton _rbtnSite;

        internal RadioButton rbtnSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbtnSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbtnSite != null)
                {
                    _rbtnSite.CheckedChanged -= rbtn_CheckedChanged;
                }

                _rbtnSite = value;
                if (_rbtnSite != null)
                {
                    _rbtnSite.CheckedChanged += rbtn_CheckedChanged;
                }
            }
        }

        private Button _btnFind;

        internal Button btnFind
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFind;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFind != null)
                {
                    _btnFind.Click -= btnFind_Click;
                }

                _btnFind = value;
                if (_btnFind != null)
                {
                    _btnFind.Click += btnFind_Click;
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
                    _txtFilter.KeyUp -= txtFilter_KeyUp;
                }

                _txtFilter = value;
                if (_txtFilter != null)
                {
                    _txtFilter.KeyUp += txtFilter_KeyUp;
                }
            }
        }

        private GroupBox _grpResult;

        private DataGrid _dgResults;

        internal DataGrid dgResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgResults != null)
                {
                    _dgResults.DoubleClick -= dgResults_DoubleClick;
                }

                _dgResults = value;
                if (_dgResults != null)
                {
                    _dgResults.DoubleClick += dgResults_DoubleClick;
                }
            }
        }

        private RadioButton _rbtnCustomer;

        internal RadioButton rbtnCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rbtnCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rbtnCustomer != null)
                {
                    _rbtnCustomer.CheckedChanged -= rbtn_CheckedChanged;
                }

                _rbtnCustomer = value;
                if (_rbtnCustomer != null)
                {
                    _rbtnCustomer.CheckedChanged += rbtn_CheckedChanged;
                }
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpFind = new System.Windows.Forms.GroupBox();
            _rbtnCustomer = new System.Windows.Forms.RadioButton();
            _rbtnOrder = new System.Windows.Forms.RadioButton();
            _rbtnJob = new System.Windows.Forms.RadioButton();
            _rbtnSite = new System.Windows.Forms.RadioButton();
            _btnFind = new System.Windows.Forms.Button();
            _txtFilter = new System.Windows.Forms.TextBox();
            _grpResult = new System.Windows.Forms.GroupBox();
            _dgResults = new System.Windows.Forms.DataGrid();
            _grpFind.SuspendLayout();
            _grpResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgResults)).BeginInit();
            SuspendLayout();
            //
            // _grpFind
            //
            _grpFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            _grpFind.Controls.Add(this._rbtnCustomer);
            _grpFind.Controls.Add(this._rbtnOrder);
            _grpFind.Controls.Add(this._rbtnJob);
            _grpFind.Controls.Add(this._rbtnSite);
            _grpFind.Location = new System.Drawing.Point(14, 13);
            _grpFind.Name = "_grpFind";
            _grpFind.Size = new System.Drawing.Size(117, 398);
            _grpFind.TabIndex = 0;
            _grpFind.TabStop = false;
            _grpFind.Text = "Find";
            //
            // _rbtnCustomer
            //
            _rbtnCustomer.AutoSize = true;
            _rbtnCustomer.Location = new System.Drawing.Point(13, 85);
            _rbtnCustomer.Name = "_rbtnCustomer";
            _rbtnCustomer.Size = new System.Drawing.Size(81, 17);
            _rbtnCustomer.TabIndex = 4;
            _rbtnCustomer.Text = "Customer";
            _rbtnCustomer.UseVisualStyleBackColor = true;
            _rbtnCustomer.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            //
            // _rbtnOrder
            //
            _rbtnOrder.AutoSize = true;
            _rbtnOrder.Location = new System.Drawing.Point(13, 117);
            _rbtnOrder.Name = "_rbtnOrder";
            _rbtnOrder.Size = new System.Drawing.Size(58, 17);
            _rbtnOrder.TabIndex = 3;
            _rbtnOrder.Text = "Order";
            _rbtnOrder.UseVisualStyleBackColor = true;
            _rbtnOrder.Visible = false;
            _rbtnOrder.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            //
            // _rbtnJob
            //
            _rbtnJob.AutoSize = true;
            _rbtnJob.Location = new System.Drawing.Point(13, 53);
            _rbtnJob.Name = "_rbtnJob";
            _rbtnJob.Size = new System.Drawing.Size(44, 17);
            _rbtnJob.TabIndex = 2;
            _rbtnJob.Text = "Job";
            _rbtnJob.UseVisualStyleBackColor = true;
            _rbtnJob.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            //
            // _rbtnSite
            //
            _rbtnSite.AutoSize = true;
            _rbtnSite.Checked = true;
            _rbtnSite.Location = new System.Drawing.Point(12, 20);
            _rbtnSite.Name = "_rbtnSite";
            _rbtnSite.Size = new System.Drawing.Size(47, 17);
            _rbtnSite.TabIndex = 1;
            _rbtnSite.TabStop = true;
            _rbtnSite.Text = "Site";
            _rbtnSite.UseVisualStyleBackColor = true;
            _rbtnSite.CheckedChanged += new System.EventHandler(this.rbtn_CheckedChanged);
            //
            // _btnFind
            //
            _btnFind.AccessibleDescription = "";
            _btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            _btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            _btnFind.FlatStyle = System.Windows.Forms.FlatStyle.System;
            _btnFind.Location = new System.Drawing.Point(655, 19);
            _btnFind.Name = "_btnFind";
            _btnFind.Size = new System.Drawing.Size(58, 25);
            _btnFind.TabIndex = 5;
            _btnFind.Text = "Find";
            _btnFind.Click += new System.EventHandler(this.btnFind_Click);
            //
            // _txtFilter
            //
            _txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            _txtFilter.Location = new System.Drawing.Point(138, 22);
            _txtFilter.MaxLength = 25;
            _txtFilter.Name = "_txtFilter";
            _txtFilter.Size = new System.Drawing.Size(510, 21);
            _txtFilter.TabIndex = 4;
            _txtFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyUp);
            //
            // _grpResult
            //
            _grpResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            _grpResult.Controls.Add(this._dgResults);
            _grpResult.Location = new System.Drawing.Point(138, 50);
            _grpResult.Name = "_grpResult";
            _grpResult.Size = new System.Drawing.Size(575, 361);
            _grpResult.TabIndex = 4;
            _grpResult.TabStop = false;
            _grpResult.Text = "Result - Double Click to Open";
            //
            // _dgResults
            //
            this._dgResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            _dgResults.DataMember = "";
            _dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            _dgResults.Location = new System.Drawing.Point(7, 20);
            _dgResults.Name = "_dgResults";
            _dgResults.Size = new System.Drawing.Size(561, 335);
            _dgResults.TabIndex = 12;
            _dgResults.DoubleClick += new System.EventHandler(this.dgResults_DoubleClick);
            //
            // FRMSchedulerFind
            //
            AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(727, 424);
            Controls.Add(this._grpResult);
            Controls.Add(this._btnFind);
            Controls.Add(this._txtFilter);
            Controls.Add(this._grpFind);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(1200, 1077);
            MinimizeBox = false;
            Name = "FRMSchedulerFind";
            Text = "Find";
            _grpFind.ResumeLayout(false);
            _grpFind.PerformLayout();
            _grpResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgResults)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataView _dvResults;

        private DataView DvResults
        {
            get
            {
                return _dvResults;
            }

            set
            {
                _dvResults = value;
                _dvResults.Table.TableName = Enums.TableNames.NO_TABLE.ToString();
                dgResults.DataSource = DvResults;
            }
        }

        private DataRow DrSelectedResult
        {
            get
            {
                if (!(dgResults.CurrentRowIndex == -1))
                {
                    return DvResults[dgResults.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void FRMSchedulerFind_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Find();
            }
        }

        private void dgResults_DoubleClick(object sender, EventArgs e)
        {
            Open();
        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void Find()
        {
            switch (true)
            {
                case object _ when rbtnSite.Checked:
                    {
                        SetupDgSites();
                        DvResults = App.DB.Sites.Search(txtFilter.Text.Trim(), App.loggedInUser.UserID);
                        break;
                    }

                case object _ when rbtnJob.Checked:
                    {
                        SetupDgJobs();
                        DvResults = App.DB.Job.Search(txtFilter.Text.Trim(), App.loggedInUser.UserID);
                        break;
                    }

                case object _ when rbtnCustomer.Checked:
                    {
                        SetupDgCustomers();
                        DvResults = App.DB.Customer.Customer_Search(txtFilter.Text.Trim(), App.loggedInUser.UserID);
                        break;
                    }

                case object _ when rbtnOrder.Checked:
                    {
                        SetupDgOrders();
                        DvResults = App.DB.Order.Search(txtFilter.Text.Trim(), App.loggedInUser.UserID);
                        break;
                    }

                default:
                    {
                        App.ShowMessage("Please select an option!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void Open()
        {
            if (DrSelectedResult is null)
            {
                App.ShowMessage("Nothing selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (true)
            {
                case object _ when rbtnSite.Checked:
                    {
                        App.ShowForm(typeof(FRMSite), true, new object[] { Helper.MakeIntegerValid(DrSelectedResult["SiteID"]) });
                        break;
                    }

                case object _ when rbtnJob.Checked:
                    {
                        App.ShowForm(typeof(FRMLogCallout), true, new object[] { Helper.MakeIntegerValid(DrSelectedResult["JobID"]), Helper.MakeIntegerValid(DrSelectedResult["SiteID"]), this });
                        break;
                    }

                case object _ when rbtnCustomer.Checked:
                    {
                        App.ShowForm(typeof(FRMCustomer), true, new object[] { Helper.MakeIntegerValid(DrSelectedResult["CustomerID"]) });
                        break;
                    }

                case object _ when rbtnOrder.Checked:
                    {
                        var switchExpr = Helper.MakeIntegerValid(DrSelectedResult["OrderTypeID"]);
                        switch (switchExpr)
                        {
                            case (int)Enums.OrderType.Customer:
                                {
                                    App.ShowForm(typeof(FRMOrder), false, new object[] { Helper.MakeIntegerValid(DrSelectedResult["OrderID"]), Helper.MakeIntegerValid(DrSelectedResult["SiteID"]), 0, this });
                                    break;
                                }

                            case (int)Enums.OrderType.StockProfile:
                                {
                                    App.ShowForm(typeof(FRMOrder), false, new object[] { Helper.MakeIntegerValid(DrSelectedResult["OrderID"]), Helper.MakeIntegerValid(DrSelectedResult["VanID"]), 0, this });
                                    break;
                                }

                            case (int)Enums.OrderType.Warehouse:
                                {
                                    App.ShowForm(typeof(FRMOrder), false, new object[] { Helper.MakeIntegerValid(DrSelectedResult["OrderID"]), Helper.MakeIntegerValid(DrSelectedResult["WarehouseID"]), 0, this });
                                    break;
                                }

                            case (int)Enums.OrderType.Job:
                                {
                                    App.ShowForm(typeof(FRMOrder), false, new object[] { Helper.MakeIntegerValid(DrSelectedResult["OrderID"]), Helper.MakeIntegerValid(DrSelectedResult["EngineerVisitID"]), 0, this });
                                    break;
                                }
                        }

                        break;
                    }

                default:
                    {
                        App.ShowMessage("Please select an option!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void ResetForm()
        {
            DvResults = new DataView(new DataTable());
            ClearDg();
        }

        private void SetupDgSites()
        {
            Helper.SetUpDataGrid(dgResults);
            var dgts = dgResults.TableStyles[0];
            var name = new DataGridLabelColumn();
            name.Format = "";
            name.FormatInfo = null;
            name.HeaderText = "Name";
            name.MappingName = "Name";
            name.ReadOnly = true;
            name.Width = 100;
            name.NullText = "";
            dgts.GridColumnStyles.Add(name);
            var address1 = new DataGridLabelColumn();
            address1.Format = "";
            address1.FormatInfo = null;
            address1.HeaderText = "Address 1";
            address1.MappingName = "Address1";
            address1.ReadOnly = true;
            address1.Width = 100;
            address1.NullText = "";
            dgts.GridColumnStyles.Add(address1);
            var address2 = new DataGridLabelColumn();
            address2.Format = "";
            address2.FormatInfo = null;
            address2.HeaderText = "Address 2";
            address2.MappingName = "Address2";
            address2.ReadOnly = true;
            address2.Width = 100;
            address2.NullText = "";
            dgts.GridColumnStyles.Add(address2);
            var postcode = new DataGridLabelColumn();
            postcode.Format = "";
            postcode.FormatInfo = null;
            postcode.HeaderText = "Postcode";
            postcode.MappingName = "Postcode";
            postcode.ReadOnly = true;
            postcode.Width = 75;
            postcode.NullText = "";
            dgts.GridColumnStyles.Add(postcode);
            var customer = new DataGridLabelColumn();
            customer.Format = "";
            customer.FormatInfo = null;
            customer.HeaderText = "Customer";
            customer.MappingName = "CustomerName";
            customer.ReadOnly = true;
            customer.Width = 100;
            customer.NullText = "";
            dgts.GridColumnStyles.Add(customer);
            var policyNumber = new DataGridLabelColumn();
            policyNumber.Format = "";
            policyNumber.FormatInfo = null;
            policyNumber.HeaderText = "Policy Number / UPRN";
            policyNumber.MappingName = "PolicyNumber";
            policyNumber.ReadOnly = true;
            policyNumber.Width = 100;
            policyNumber.NullText = "";
            dgts.GridColumnStyles.Add(policyNumber);
            var lsd = new DataGridLabelColumn();
            lsd.Format = "";
            lsd.FormatInfo = null;
            lsd.HeaderText = "Last Service Date";
            lsd.MappingName = "LastServiceDate";
            lsd.ReadOnly = true;
            lsd.Width = 100;
            lsd.NullText = "";
            dgts.GridColumnStyles.Add(lsd);
            dgts.ReadOnly = true;
            dgts.MappingName = Enums.TableNames.NO_TABLE.ToString();
            dgResults.TableStyles.Add(dgts);
        }

        public void SetupDgJobs()
        {
            Helper.SetUpDataGrid(dgResults);
            var dgts = dgResults.TableStyles[0];
            var dateCreated = new DataGridLabelColumn();
            dateCreated.Format = "dd/MM/yyyy";
            dateCreated.FormatInfo = null;
            dateCreated.HeaderText = "Created";
            dateCreated.MappingName = "DateCreated";
            dateCreated.ReadOnly = true;
            dateCreated.Width = 75;
            dateCreated.NullText = "";
            dgts.GridColumnStyles.Add(dateCreated);
            var jobNumber = new DataGridLabelColumn();
            jobNumber.Format = "";
            jobNumber.FormatInfo = null;
            jobNumber.HeaderText = "Job No";
            jobNumber.MappingName = "JobNumber";
            jobNumber.ReadOnly = true;
            jobNumber.Width = 75;
            jobNumber.NullText = "";
            dgts.GridColumnStyles.Add(jobNumber);
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "Type";
            type.ReadOnly = true;
            type.Width = 100;
            type.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            dgts.GridColumnStyles.Add(type);
            var site = new DataGridLabelColumn();
            site.Format = "";
            site.FormatInfo = null;
            site.HeaderText = "Site";
            site.MappingName = "Site";
            site.ReadOnly = true;
            site.Width = 200;
            site.NullText = "";
            dgts.GridColumnStyles.Add(site);
            var lastVisitDate = new DataGridLabelColumn();
            lastVisitDate.Format = "dd/MM/yyyy";
            lastVisitDate.FormatInfo = null;
            lastVisitDate.HeaderText = "Last Visit's Date";
            lastVisitDate.MappingName = "LastVisitDate";
            lastVisitDate.ReadOnly = true;
            lastVisitDate.Width = 100;
            lastVisitDate.NullText = "";
            dgts.GridColumnStyles.Add(lastVisitDate);
            dgts.ReadOnly = true;
            dgts.MappingName = Enums.TableNames.NO_TABLE.ToString();
            dgResults.TableStyles.Add(dgts);
        }

        public void SetupDgCustomers()
        {
            Helper.SetUpDataGrid(dgResults);
            var dgts = dgResults.TableStyles[0];
            var customer = new DataGridLabelColumn();
            customer.Format = "";
            customer.FormatInfo = null;
            customer.HeaderText = "Name";
            customer.MappingName = "Name";
            customer.ReadOnly = true;
            customer.Width = 200;
            customer.NullText = "";
            dgts.GridColumnStyles.Add(customer);
            var account = new DataGridLabelColumn();
            account.Format = "";
            account.FormatInfo = null;
            account.HeaderText = "Account Number";
            account.MappingName = "AccountNumber";
            account.ReadOnly = true;
            account.Width = 140;
            account.NullText = "";
            dgts.GridColumnStyles.Add(account);
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "Type";
            type.ReadOnly = true;
            type.Width = 140;
            type.NullText = "";
            dgts.GridColumnStyles.Add(type);
            var region = new DataGridLabelColumn();
            region.Format = "";
            region.FormatInfo = null;
            region.HeaderText = "Region";
            region.MappingName = "Region";
            region.ReadOnly = true;
            region.Width = 140;
            region.NullText = "";
            dgts.GridColumnStyles.Add(region);
            dgts.ReadOnly = true;
            dgts.MappingName = Enums.TableNames.NO_TABLE.ToString();
            dgResults.TableStyles.Add(dgts);
        }

        private void SetupDgOrders()
        {
            Helper.SetUpDataGrid(dgResults);
            var dgts = dgResults.TableStyles[0];
            var dateCreated = new DataGridLabelColumn();
            dateCreated.Format = "dd/MMM/yyyy";
            dateCreated.FormatInfo = null;
            dateCreated.HeaderText = "Date Placed";
            dateCreated.MappingName = "DatePlaced";
            dateCreated.ReadOnly = true;
            dateCreated.Width = 90;
            dateCreated.NullText = "";
            dgts.GridColumnStyles.Add(dateCreated);
            var orderReference = new DataGridLabelColumn();
            orderReference.Format = "";
            orderReference.FormatInfo = null;
            orderReference.HeaderText = "Order Reference";
            orderReference.MappingName = "OrderReference";
            orderReference.ReadOnly = true;
            orderReference.Width = 110;
            orderReference.NullText = "";
            dgts.GridColumnStyles.Add(orderReference);
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "Type";
            type.ReadOnly = true;
            type.Width = 75;
            type.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            dgts.GridColumnStyles.Add(type);
            var supplier = new DataGridLabelColumn();
            supplier.Format = "";
            supplier.FormatInfo = null;
            supplier.HeaderText = "Supplier";
            supplier.MappingName = "Supplier";
            supplier.ReadOnly = true;
            supplier.Width = 100;
            supplier.NullText = "N/A";
            dgts.GridColumnStyles.Add(supplier);
            var cost = new DataGridLabelColumn();
            cost.Format = "C";
            cost.FormatInfo = null;
            cost.HeaderText = "Cost";
            cost.MappingName = "BuyPrice";
            cost.ReadOnly = true;
            cost.Width = 75;
            cost.NullText = "0";
            dgts.GridColumnStyles.Add(cost);
            var department = new DataGridLabelColumn();
            department.Format = "";
            department.FormatInfo = null;
            department.HeaderText = "Dept";
            department.MappingName = "DepartmentRef";
            department.ReadOnly = true;
            department.Width = 50;
            department.NullText = "";
            dgts.GridColumnStyles.Add(department);
            var customer = new DataGridLabelColumn();
            customer.Format = "";
            customer.FormatInfo = null;
            customer.HeaderText = "Customer";
            customer.MappingName = "Customer";
            customer.ReadOnly = true;
            customer.Width = 140;
            customer.NullText = "N/A";
            dgts.GridColumnStyles.Add(customer);
            var site = new DataGridLabelColumn();
            site.Format = "";
            site.FormatInfo = null;
            site.HeaderText = "Property";
            site.MappingName = "Site";
            site.ReadOnly = true;
            site.Width = 140;
            site.NullText = "N/A";
            dgts.GridColumnStyles.Add(site);
            var jobNumber = new DataGridLabelColumn();
            jobNumber.Format = "";
            jobNumber.FormatInfo = null;
            jobNumber.HeaderText = "Job Number";
            jobNumber.MappingName = "JobNumber";
            jobNumber.ReadOnly = true;
            jobNumber.Width = 100;
            jobNumber.NullText = "N/A";
            dgts.GridColumnStyles.Add(jobNumber);
            dgts.ReadOnly = true;
            dgts.MappingName = Enums.TableNames.NO_TABLE.ToString();
            dgResults.TableStyles.Add(dgts);
        }

        private void ClearDg()
        {
            Helper.SetUpDataGrid(dgResults);
            var dgts = dgResults.TableStyles[0];
            dgts.ReadOnly = true;
            dgts.MappingName = Enums.TableNames.NO_TABLE.ToString();
            dgResults.TableStyles.Add(dgts);
        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var _ssmList = new List<Enums.SecuritySystemModules>() { Enums.SecuritySystemModules.CreatePO, Enums.SecuritySystemModules.EditPO };
            rbtnOrder.Visible = App.loggedInUser.HasAccessToMulitpleModules(_ssmList);
        }

        public IUserControl LoadedControl { get; }

        public void ResetMe(int newID)
        {
        }
    }
}