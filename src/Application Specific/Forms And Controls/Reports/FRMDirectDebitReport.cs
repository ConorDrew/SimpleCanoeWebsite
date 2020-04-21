using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FSM
{
    public class FRMDirectDebitReport : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMDirectDebitReport() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMJobManager_Load;

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

        private DataGrid _dgDirectDebits;

        internal DataGrid dgDirectDebits
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgDirectDebits;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgDirectDebits != null)
                {
                }

                _dgDirectDebits = value;
                if (_dgDirectDebits != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpJobs = new GroupBox();
            _dgDirectDebits = new DataGrid();
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _Label1 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpTo.ValueChanged += new EventHandler(dtpTo_ValueChanged);
            _dtpFrom = new DateTimePicker();
            _dtpFrom.ValueChanged += new EventHandler(dtpFrom_ValueChanged);
            _Label9 = new Label();
            _Label8 = new Label();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgDirectDebits).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpJobs
            //
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgDirectDebits);
            _grpJobs.Location = new Point(8, 88);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(784, 368);
            _grpJobs.TabIndex = 1;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Results";
            //
            // dgDirectDebits
            //
            _dgDirectDebits.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgDirectDebits.DataMember = "";
            _dgDirectDebits.HeaderForeColor = SystemColors.ControlText;
            _dgDirectDebits.Location = new Point(8, 21);
            _dgDirectDebits.Name = "dgDirectDebits";
            _dgDirectDebits.Size = new Size(768, 339);
            _dgDirectDebits.TabIndex = 0;
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 464);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 2;
            _btnExport.Text = "Export";
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(784, 56);
            _grpFilter.TabIndex = 0;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // Label1
            //
            _Label1.Location = new Point(8, 25);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(120, 16);
            _Label1.TabIndex = 5;
            _Label1.Text = "Invoice Raise Date";
            //
            // dtpTo
            //
            _dtpTo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _dtpTo.Location = new Point(488, 24);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(248, 21);
            _dtpTo.TabIndex = 4;
            //
            // dtpFrom
            //
            _dtpFrom.Location = new Point(176, 24);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(248, 21);
            _dtpFrom.TabIndex = 2;
            //
            // Label9
            //
            _Label9.Location = new Point(440, 24);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 3;
            _Label9.Text = "To";
            //
            // Label8
            //
            _Label8.Location = new Point(136, 25);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(48, 16);
            _Label8.TabIndex = 1;
            _Label8.Text = "From";
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 464);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 3;
            _btnReset.Text = "Reset";
            //
            // FRMDirectDebitReport
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(800, 494);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpJobs);
            Controls.Add(_btnReset);
            MinimumSize = new Size(808, 528);
            Name = "FRMDirectDebitReport";
            Text = "Direct Debits Due";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgDirectDebits).EndInit();
            _grpFilter.ResumeLayout(false);
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupDirectDebitsDataGrid();
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
        private DataView _dvDD;

        private DataView dvDD
        {
            get
            {
                return _dvDD;
            }

            set
            {
                _dvDD = value;
                _dvDD.AllowNew = false;
                _dvDD.AllowEdit = false;
                _dvDD.AllowDelete = false;
                _dvDD.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString();
                dgDirectDebits.DataSource = dvDD;
            }
        }

        private DataRow SelectedDirectDebitDataRow
        {
            get
            {
                if (!(dgDirectDebits.CurrentRowIndex == -1))
                {
                    return dvDD[dgDirectDebits.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupDirectDebitsDataGrid()
        {
            var tbStyle = dgDirectDebits.TableStyles[0];
            var ContractReference = new DataGridLabelColumn();
            ContractReference.Format = "";
            ContractReference.FormatInfo = null;
            ContractReference.HeaderText = "Contract Ref";
            ContractReference.MappingName = "ContractReference";
            ContractReference.ReadOnly = true;
            ContractReference.Width = 100;
            ContractReference.NullText = "";
            tbStyle.GridColumnStyles.Add(ContractReference);
            var RaiseDate = new DataGridLabelColumn();
            RaiseDate.Format = "dd/MMM/yyyy";
            RaiseDate.FormatInfo = null;
            RaiseDate.HeaderText = "Raise Date";
            RaiseDate.MappingName = "RaiseDate";
            RaiseDate.ReadOnly = true;
            RaiseDate.Width = 100;
            RaiseDate.NullText = "";
            tbStyle.GridColumnStyles.Add(RaiseDate);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 200;
            Customer.NullText = "";
            tbStyle.GridColumnStyles.Add(Customer);
            var Amount = new DataGridLabelColumn();
            Amount.Format = "C";
            Amount.FormatInfo = null;
            Amount.HeaderText = "Amount";
            Amount.MappingName = "Amount";
            Amount.ReadOnly = true;
            Amount.Width = 75;
            Amount.NullText = "";
            tbStyle.GridColumnStyles.Add(Amount);
            var BankName = new DataGridLabelColumn();
            BankName.Format = "";
            BankName.FormatInfo = null;
            BankName.HeaderText = "Bank Name";
            BankName.MappingName = "BankName";
            BankName.ReadOnly = true;
            BankName.Width = 100;
            BankName.NullText = "";
            tbStyle.GridColumnStyles.Add(BankName);
            var SortCode = new DataGridLabelColumn();
            SortCode.Format = "";
            SortCode.FormatInfo = null;
            SortCode.HeaderText = "Sort Code";
            SortCode.MappingName = "SortCode";
            SortCode.ReadOnly = true;
            SortCode.Width = 100;
            SortCode.NullText = "";
            tbStyle.GridColumnStyles.Add(SortCode);
            var AccountNumber = new DataGridLabelColumn();
            AccountNumber.Format = "";
            AccountNumber.FormatInfo = null;
            AccountNumber.HeaderText = "Account Number";
            AccountNumber.MappingName = "AccountNumber";
            AccountNumber.ReadOnly = true;
            AccountNumber.Width = 100;
            AccountNumber.NullText = "";
            tbStyle.GridColumnStyles.Add(AccountNumber);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceToBeRaised.ToString();
            dgDirectDebits.TableStyles.Add(tbStyle);
        }

        private void FRMJobManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
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
                    dvDD = (DataView)get_GetParameter(0);
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
            dtpFrom.Value = DateAndTime.Now;
            dtpTo.Value = DateAndTime.Now.AddDays(7);
            grpFilter.Enabled = true;
        }

        private void RunFilter()
        {
            dvDD = App.DB.InvoiceToBeRaised.Invoices_GetAll_ForDirectDebitRpt(dtpFrom.Value, dtpTo.Value);
        }

        public void Export()
        {
            Entity.Sys.ExportHelper.Export(dvDD.Table, "Direct Debit List", Entity.Sys.Enums.ExportType.CSV);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}