using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class FRMLastGSRReport : FRMBaseForm, IForm
    {
        public FRMLastGSRReport() : base()
        {
            base.Load += FRMEngineerTimesheetReport_Load;

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
                }

                _dtpTo = value;
                if (_dtpTo != null)
                {
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
                }

                _dtpFrom = value;
                if (_dtpFrom != null)
                {
                }
            }
        }

        private Label _Label9;

        private Label _Label8;

        private Button _btnExport;

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

        private Button _btnPrintGSRReminders;

        private ProgressBar _pbStatus;

        internal ProgressBar pbStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbStatus != null)
                {
                }

                _pbStatus = value;
                if (_pbStatus != null)
                {
                }
            }
        }

        private Button _btnFindCustomer;

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

        private CheckBox _chkNotPrinted;

        internal CheckBox chkNotPrinted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkNotPrinted;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkNotPrinted != null)
                {
                }

                _chkNotPrinted = value;
                if (_chkNotPrinted != null)
                {
                }
            }
        }

        private ComboBox _cboContract;

        internal ComboBox cboContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboContract != null)
                {
                }

                _cboContract = value;
                if (_cboContract != null)
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

        private CheckBox _chkIncludeTenantsAssets;

        internal CheckBox chkIncludeTenantsAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkIncludeTenantsAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkIncludeTenantsAssets != null)
                {
                }

                _chkIncludeTenantsAssets = value;
                if (_chkIncludeTenantsAssets != null)
                {
                }
            }
        }

        private ComboBox _cboRegion;

        internal ComboBox cboRegion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRegion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRegion != null)
                {
                }

                _cboRegion = value;
                if (_cboRegion != null)
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

        private Button _btnFilter;

        private Button _btnUnselect;

        private Button _btnSelectAll;

        private Button _btnEmailNone;

        private Button _btnEmailAll;

        private DataGrid _dgProductsLastGSR;

        internal DataGrid dgProductsLastGSR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgProductsLastGSR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgProductsLastGSR != null)
                {
                    _dgProductsLastGSR.MouseUp -= dg_MouseUp;
                }

                _dgProductsLastGSR = value;
                if (_dgProductsLastGSR != null)
                {
                    _dgProductsLastGSR.MouseUp += dg_MouseUp;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgProductsLastGSR = new System.Windows.Forms.DataGrid();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._btnFilter = new System.Windows.Forms.Button();
            this._cboRegion = new System.Windows.Forms.ComboBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._cboContract = new System.Windows.Forms.ComboBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._chkIncludeTenantsAssets = new System.Windows.Forms.CheckBox();
            this._chkNotPrinted = new System.Windows.Forms.CheckBox();
            this._btnFindCustomer = new System.Windows.Forms.Button();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnPrintGSRReminders = new System.Windows.Forms.Button();
            this._pbStatus = new System.Windows.Forms.ProgressBar();
            this._btnUnselect = new System.Windows.Forms.Button();
            this._btnSelectAll = new System.Windows.Forms.Button();
            this._btnEmailNone = new System.Windows.Forms.Button();
            this._btnEmailAll = new System.Windows.Forms.Button();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgProductsLastGSR)).BeginInit();
            this._grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgProductsLastGSR);
            this._grpJobs.Location = new System.Drawing.Point(8, 165);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(1172, 291);
            this._grpJobs.TabIndex = 1;
            this._grpJobs.TabStop = false;
            this._grpJobs.Text = "Service Reminders";
            // 
            // _dgProductsLastGSR
            // 
            this._dgProductsLastGSR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgProductsLastGSR.DataMember = "";
            this._dgProductsLastGSR.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgProductsLastGSR.Location = new System.Drawing.Point(8, 19);
            this._dgProductsLastGSR.Name = "_dgProductsLastGSR";
            this._dgProductsLastGSR.Size = new System.Drawing.Size(1156, 264);
            this._dgProductsLastGSR.TabIndex = 0;
            this._dgProductsLastGSR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dg_MouseUp);
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 464);
            this._btnExport.Name = "_btnExport";
            this._btnExport.Size = new System.Drawing.Size(56, 23);
            this._btnExport.TabIndex = 2;
            this._btnExport.Text = "Export";
            this._btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // _grpFilter
            // 
            this._grpFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpFilter.Controls.Add(this._btnFilter);
            this._grpFilter.Controls.Add(this._cboRegion);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._cboContract);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._chkIncludeTenantsAssets);
            this._grpFilter.Controls.Add(this._chkNotPrinted);
            this._grpFilter.Controls.Add(this._btnFindCustomer);
            this._grpFilter.Controls.Add(this._txtCustomer);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Location = new System.Drawing.Point(8, 12);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(1172, 115);
            this._grpFilter.TabIndex = 0;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _btnFilter
            // 
            this._btnFilter.AccessibleDescription = "";
            this._btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFilter.Location = new System.Drawing.Point(1031, 75);
            this._btnFilter.Name = "_btnFilter";
            this._btnFilter.Size = new System.Drawing.Size(126, 23);
            this._btnFilter.TabIndex = 15;
            this._btnFilter.Text = "Run Filter";
            this._btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // _cboRegion
            // 
            this._cboRegion.FormattingEnabled = true;
            this._cboRegion.Location = new System.Drawing.Point(310, 73);
            this._cboRegion.Name = "_cboRegion";
            this._cboRegion.Size = new System.Drawing.Size(144, 21);
            this._cboRegion.TabIndex = 14;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(248, 75);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(57, 17);
            this._Label2.TabIndex = 13;
            this._Label2.Text = "Region";
            // 
            // _cboContract
            // 
            this._cboContract.FormattingEnabled = true;
            this._cboContract.Location = new System.Drawing.Point(85, 71);
            this._cboContract.Name = "_cboContract";
            this._cboContract.Size = new System.Drawing.Size(144, 21);
            this._cboContract.TabIndex = 9;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 73);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(64, 16);
            this._Label1.TabIndex = 8;
            this._Label1.Text = "Contract";
            // 
            // _chkIncludeTenantsAssets
            // 
            this._chkIncludeTenantsAssets.AutoSize = true;
            this._chkIncludeTenantsAssets.Location = new System.Drawing.Point(487, 21);
            this._chkIncludeTenantsAssets.Name = "_chkIncludeTenantsAssets";
            this._chkIncludeTenantsAssets.Size = new System.Drawing.Size(157, 17);
            this._chkIncludeTenantsAssets.TabIndex = 11;
            this._chkIncludeTenantsAssets.Text = "Include Tenants Assets";
            this._chkIncludeTenantsAssets.UseVisualStyleBackColor = true;
            // 
            // _chkNotPrinted
            // 
            this._chkNotPrinted.AutoSize = true;
            this._chkNotPrinted.Location = new System.Drawing.Point(664, 23);
            this._chkNotPrinted.Name = "_chkNotPrinted";
            this._chkNotPrinted.Size = new System.Drawing.Size(66, 17);
            this._chkNotPrinted.TabIndex = 12;
            this._chkNotPrinted.Text = "Printed";
            this._chkNotPrinted.UseVisualStyleBackColor = true;
            // 
            // _btnFindCustomer
            // 
            this._btnFindCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindCustomer.BackColor = System.Drawing.Color.White;
            this._btnFindCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindCustomer.Location = new System.Drawing.Point(1125, 44);
            this._btnFindCustomer.Name = "_btnFindCustomer";
            this._btnFindCustomer.Size = new System.Drawing.Size(32, 23);
            this._btnFindCustomer.TabIndex = 7;
            this._btnFindCustomer.Text = "...";
            this._btnFindCustomer.UseVisualStyleBackColor = false;
            this._btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
            // 
            // _txtCustomer
            // 
            this._txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtCustomer.Location = new System.Drawing.Point(85, 46);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.ReadOnly = true;
            this._txtCustomer.Size = new System.Drawing.Size(1034, 21);
            this._txtCustomer.TabIndex = 6;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(8, 49);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(64, 16);
            this._Label4.TabIndex = 5;
            this._Label4.Text = "Customer";
            // 
            // _dtpTo
            // 
            this._dtpTo.Location = new System.Drawing.Point(310, 20);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(144, 21);
            this._dtpTo.TabIndex = 3;
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Location = new System.Drawing.Point(85, 20);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(144, 21);
            this._dtpFrom.TabIndex = 1;
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(273, 21);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(24, 16);
            this._Label9.TabIndex = 2;
            this._Label9.Text = "To";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(8, 22);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(88, 16);
            this._Label8.TabIndex = 0;
            this._Label8.Text = "Date From";
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 464);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 3;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // _btnPrintGSRReminders
            // 
            this._btnPrintGSRReminders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrintGSRReminders.Location = new System.Drawing.Point(1039, 464);
            this._btnPrintGSRReminders.Name = "_btnPrintGSRReminders";
            this._btnPrintGSRReminders.Size = new System.Drawing.Size(141, 23);
            this._btnPrintGSRReminders.TabIndex = 5;
            this._btnPrintGSRReminders.Text = "Print GSR Reminders";
            this._btnPrintGSRReminders.UseVisualStyleBackColor = true;
            this._btnPrintGSRReminders.Click += new System.EventHandler(this.btnPrintGSRReminders_Click);
            // 
            // _pbStatus
            // 
            this._pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pbStatus.Location = new System.Drawing.Point(134, 464);
            this._pbStatus.Name = "_pbStatus";
            this._pbStatus.Size = new System.Drawing.Size(899, 23);
            this._pbStatus.TabIndex = 4;
            // 
            // _btnUnselect
            // 
            this._btnUnselect.Location = new System.Drawing.Point(137, 136);
            this._btnUnselect.Name = "_btnUnselect";
            this._btnUnselect.Size = new System.Drawing.Size(96, 23);
            this._btnUnselect.TabIndex = 9;
            this._btnUnselect.Text = "Unselect All";
            this._btnUnselect.UseVisualStyleBackColor = true;
            this._btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // _btnSelectAll
            // 
            this._btnSelectAll.Location = new System.Drawing.Point(12, 136);
            this._btnSelectAll.Name = "_btnSelectAll";
            this._btnSelectAll.Size = new System.Drawing.Size(119, 23);
            this._btnSelectAll.TabIndex = 8;
            this._btnSelectAll.Text = "Select All";
            this._btnSelectAll.UseVisualStyleBackColor = true;
            this._btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // _btnEmailNone
            // 
            this._btnEmailNone.Location = new System.Drawing.Point(373, 136);
            this._btnEmailNone.Name = "_btnEmailNone";
            this._btnEmailNone.Size = new System.Drawing.Size(96, 23);
            this._btnEmailNone.TabIndex = 11;
            this._btnEmailNone.Text = "Email None";
            this._btnEmailNone.UseVisualStyleBackColor = true;
            this._btnEmailNone.Click += new System.EventHandler(this.btnEmailNone_Click);
            // 
            // _btnEmailAll
            // 
            this._btnEmailAll.Location = new System.Drawing.Point(248, 136);
            this._btnEmailAll.Name = "_btnEmailAll";
            this._btnEmailAll.Size = new System.Drawing.Size(119, 23);
            this._btnEmailAll.TabIndex = 10;
            this._btnEmailAll.Text = "Email All";
            this._btnEmailAll.UseVisualStyleBackColor = true;
            this._btnEmailAll.Click += new System.EventHandler(this.btnEmailAll_Click);
            // 
            // FRMLastGSRReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1188, 494);
            this.Controls.Add(this._btnEmailNone);
            this.Controls.Add(this._btnEmailAll);
            this.Controls.Add(this._btnUnselect);
            this.Controls.Add(this._btnSelectAll);
            this.Controls.Add(this._pbStatus);
            this.Controls.Add(this._btnPrintGSRReminders);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpJobs);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(808, 528);
            this.Name = "FRMLastGSRReport";
            this.Text = "Product Last GSR Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgProductsLastGSR)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            var argc = cboContract;
            Combo.SetUpCombo(ref argc, DynamicDataTables.ContractOnOrNone, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.No_Filter);
            var argc1 = cboRegion;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.No_Filter);
            SetupTimesheetsDataGrid();
            dtpFrom.Value = DateAndTime.Today.AddYears(-1);
            dtpTo.Value = DateAndTime.Today.AddYears(-1).AddMonths(1);
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

        private DataView _ProductsDataview;

        private DataView ProductsDataview
        {
            get
            {
                return _ProductsDataview;
            }

            set
            {
                _ProductsDataview = value;
                _ProductsDataview.AllowNew = false;
                _ProductsDataview.AllowEdit = false;
                _ProductsDataview.AllowDelete = false;
                _ProductsDataview.Table.TableName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
                dgProductsLastGSR.DataSource = ProductsDataview;
            }
        }

        private DataRow SelectedProductDataRow
        {
            get
            {
                if (!(dgProductsLastGSR.CurrentRowIndex == -1))
                {
                    return ProductsDataview[dgProductsLastGSR.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Customers.Customer _theCustomer;

        public Entity.Customers.Customer theCustomer
        {
            get
            {
                return _theCustomer;
            }

            set
            {
                _theCustomer = value;
                if (_theCustomer is object)
                {
                    txtCustomer.Text = theCustomer.Name + " (A/C No : " + theCustomer.AccountNumber + ")";
                }
                else
                {
                    txtCustomer.Text = "";
                }
            }
        }

        private void SetupTimesheetsDataGrid()
        {
            var tbStyle = dgProductsLastGSR.TableStyles[0];
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tbStyle.GridColumnStyles.Add(Tick);
            var Email = new DataGridBoolColumn();
            Email.HeaderText = "Email?";
            Email.MappingName = "Email";
            Email.ReadOnly = true;
            Email.Width = 75;
            Email.NullText = "";
            tbStyle.GridColumnStyles.Add(Email);
            var VisitDate = new DataGridLabelColumn();
            VisitDate.Format = "dd/MM/yyyy";
            VisitDate.FormatInfo = null;
            VisitDate.HeaderText = "Last GSR Date";
            VisitDate.MappingName = "VisitDate";
            VisitDate.ReadOnly = true;
            VisitDate.Width = 75;
            VisitDate.NullText = "Not Done";
            tbStyle.GridColumnStyles.Add(VisitDate);
            var DueDate = new DataGridLabelColumn();
            DueDate.Format = "dd/MM/yyyy";
            DueDate.FormatInfo = null;
            DueDate.HeaderText = "Due Date";
            DueDate.MappingName = "DueDate";
            DueDate.ReadOnly = true;
            DueDate.Width = 75;
            DueDate.NullText = "Not Done";
            tbStyle.GridColumnStyles.Add(DueDate);
            var Appliance = new DataGridLabelColumn();
            Appliance.Format = "";
            Appliance.FormatInfo = null;
            Appliance.HeaderText = "Appliance";
            Appliance.MappingName = "Appliance";
            Appliance.ReadOnly = true;
            Appliance.Width = 200;
            Appliance.NullText = "";
            tbStyle.GridColumnStyles.Add(Appliance);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 200;
            Site.NullText = "";
            tbStyle.GridColumnStyles.Add(Site);
            var Tenant = new DataGridLabelColumn();
            Tenant.Format = "";
            Tenant.FormatInfo = null;
            Tenant.HeaderText = "Tenant";
            Tenant.MappingName = "Tenant";
            Tenant.ReadOnly = true;
            Tenant.Width = 100;
            Tenant.NullText = "";
            tbStyle.GridColumnStyles.Add(Tenant);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 70;
            SerialNum.NullText = "";
            tbStyle.GridColumnStyles.Add(SerialNum);
            var GaswayRef = new DataGridLabelColumn();
            GaswayRef.Format = "";
            GaswayRef.FormatInfo = null;
            GaswayRef.HeaderText = "Gasway Ref";
            GaswayRef.MappingName = "BoughtFrom";
            GaswayRef.ReadOnly = true;
            GaswayRef.Width = 70;
            GaswayRef.NullText = "";
            tbStyle.GridColumnStyles.Add(GaswayRef);
            var Active = new BitToStringDescriptionColumn();
            Active.Format = "";
            Active.FormatInfo = null;
            Active.HeaderText = "Active";
            Active.MappingName = "Active";
            Active.ReadOnly = true;
            Active.Width = 70;
            Active.NullText = "";
            tbStyle.GridColumnStyles.Add(Active);
            var TenantsAppliance = new BitToStringDescriptionColumn();
            TenantsAppliance.Format = "";
            TenantsAppliance.FormatInfo = null;
            TenantsAppliance.HeaderText = "Tenants Appliance";
            TenantsAppliance.MappingName = "TenantsAppliance";
            TenantsAppliance.ReadOnly = true;
            TenantsAppliance.Width = 100;
            TenantsAppliance.NullText = "";
            tbStyle.GridColumnStyles.Add(TenantsAppliance);
            var OnContract = new BitToStringDescriptionColumn();
            OnContract.Format = "";
            OnContract.FormatInfo = null;
            OnContract.HeaderText = "On Contract";
            OnContract.MappingName = "OnContract";
            OnContract.ReadOnly = true;
            OnContract.Width = 75;
            OnContract.NullText = "";
            tbStyle.GridColumnStyles.Add(OnContract);
            var Printed = new BitToStringDescriptionColumn();
            Printed.Format = "";
            Printed.FormatInfo = null;
            Printed.HeaderText = "Printed";
            Printed.MappingName = "Printed";
            Printed.ReadOnly = true;
            Printed.Width = 75;
            Printed.NullText = "";
            tbStyle.GridColumnStyles.Add(Printed);
            var CustomerName = new DataGridLabelColumn();
            CustomerName.Format = "";
            CustomerName.FormatInfo = null;
            CustomerName.HeaderText = "Customer";
            CustomerName.MappingName = "CustomerName";
            CustomerName.ReadOnly = true;
            CustomerName.Width = 75;
            CustomerName.NullText = "";
            tbStyle.GridColumnStyles.Add(CustomerName);
            var ContactNumbers = new DataGridLabelColumn();
            CustomerName.Format = "";
            CustomerName.FormatInfo = null;
            ContactNumbers.HeaderText = "Contact Numbers";
            ContactNumbers.MappingName = "ContactNumbers";
            ContactNumbers.ReadOnly = true;
            ContactNumbers.Width = 75;
            ContactNumbers.NullText = "";
            tbStyle.GridColumnStyles.Add(ContactNumbers);
            var EmailAddress = new DataGridLabelColumn();
            EmailAddress.Format = "";
            EmailAddress.FormatInfo = null;
            EmailAddress.HeaderText = "EmailAddress";
            EmailAddress.MappingName = "EmailAddress";
            EmailAddress.ReadOnly = true;
            EmailAddress.Width = 75;
            EmailAddress.NullText = "";
            tbStyle.GridColumnStyles.Add(EmailAddress);
            var ContactMade = new DataGridBoolColumn();
            ContactMade.HeaderText = "Contact Made";
            ContactMade.MappingName = "OtherContactMade";
            ContactMade.ReadOnly = true;
            ContactMade.Width = 75;
            ContactMade.NullText = "";
            tbStyle.GridColumnStyles.Add(ContactMade);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
            dgProductsLastGSR.TableStyles.Add(tbStyle);
        }

        private void FRMEngineerTimesheetReport_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PopulateDatagrid();
            Cursor.Current = Cursors.Default;
        }

        private void btnPrintGSRReminders_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            pbStatus.Value = 0;
            pbStatus.Maximum = ((DataView)dgProductsLastGSR.DataSource).Count + 5;
            var dvSelectedServiceReminders = new DataView();
            dvSelectedServiceReminders.Table = ProductsDataview.Table;
            dvSelectedServiceReminders.RowFilter = "tick = 1";
            var dt = new DataTable();
            dt = ProductsDataview.Table.Clone();
            foreach (DataRowView dr in dvSelectedServiceReminders)
            {
                DataRow nr;
                nr = dt.NewRow();
                nr["AssetID"] = dr["AssetID"];
                nr["VisitDate"] = dr["VisitDate"];
                nr["Appliance"] = dr["Appliance"];
                nr["Site"] = dr["Site"];
                nr["Tenant"] = dr["Tenant"];
                nr["Address1"] = dr["Address1"];
                nr["Address2"] = dr["Address2"];
                nr["Address3"] = dr["Address3"];
                nr["Postcode"] = dr["Postcode"];
                nr["SerialNum"] = dr["SerialNum"];
                nr["CustomerName"] = dr["CustomerName"];
                nr["Active"] = dr["Active"];
                nr["TenantsAppliance"] = dr["TenantsAppliance"];
                nr["BoughtFrom"] = dr["BoughtFrom"];
                nr["SiteID"] = dr["SiteID"];
                nr["CustomerID"] = dr["CustomerID"];
                nr["DueDate"] = dr["DueDate"];
                nr["Email"] = dr["Email"];
                nr["EmailAddress"] = dr["EmailAddress"];
                dt.Rows.Add(nr);
            }

            var details = new ArrayList();
            details.Add(new DataView(dt));
            details.Add(this);
            var oPrint = new Entity.Sys.Printing(details, "GSR Reminder Letter", Entity.Sys.Enums.SystemDocumentType.GSRDue, true);
            MoveProgressOn(true);
            pbStatus.Value = 0;
            PopulateDatagrid();
            Cursor.Current = Cursors.Default;
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            int ID = Conversions.ToInteger(App.FindRecord(Entity.Sys.Enums.TableNames.tblCustomer));
            if (!(ID == 0))
            {
                theCustomer = App.DB.Customer.Customer_Get(ID);
            }
        }

        private void dg_MouseUp(object sender, MouseEventArgs e)
        {
            DataGrid.HitTestInfo HitTestInfo;
            HitTestInfo = dgProductsLastGSR.HitTest(e.X, e.Y);
            if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
            {
                if (HitTestInfo.Column == 0)
                {
                    if (SelectedProductDataRow is null)
                    {
                        return;
                    }

                    bool selected = !Conversions.ToBoolean(dgProductsLastGSR[dgProductsLastGSR.CurrentRowIndex, 0]);
                    dgProductsLastGSR[dgProductsLastGSR.CurrentRowIndex, 0] = selected;
                }

                if (HitTestInfo.Column == 1)
                {
                    if (SelectedProductDataRow is null)
                    {
                        return;
                    }

                    bool selected = !Conversions.ToBoolean(dgProductsLastGSR[dgProductsLastGSR.CurrentRowIndex, 1]);
                    dgProductsLastGSR[dgProductsLastGSR.CurrentRowIndex, 1] = selected;
                }

                if (HitTestInfo.Column == 14)
                {
                    bool selected = !Entity.Sys.Helper.MakeBooleanValid(SelectedProductDataRow["OtherContactMade"]);
                    SelectedProductDataRow["OtherContactMade"] = selected;
                    int exists = Conversions.ToInteger(App.DB.ExecuteScalar("Select Count(*) from tblPrintedGSRLetters where CONVERT(DATE,DateDue) = CONVERT(DATE,'" + Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow["DueDate"]).ToString("yyyy-MM-dd") + "') AND AssetID = " + Entity.Sys.Helper.MakeIntegerValid(SelectedProductDataRow["AssetID"])));
                    int i = 0;
                    if (selected == true)
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                    }

                    if (exists == 0)
                    {
                        // insert
                        App.DB.EngineerVisitAssetWorkSheet.PrintedGSRLettersInsert(Entity.Sys.Helper.MakeIntegerValid(SelectedProductDataRow["AssetID"]), Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow["DueDate"]), true);
                    }
                    else
                    {
                        // update
                        App.DB.ExecuteScalar("UPDATE tblprintedGSRLetters set OtherContactMade = " + i + " where CONVERT(DATE,DateDue) = CONVERT(DATE,'" + Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow["DueDate"]).ToString("yyyy-MM-dd") + "') AND AssetID = " + Entity.Sys.Helper.MakeIntegerValid(SelectedProductDataRow["AssetID"]));
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            ProductsDataview.AllowEdit = true;
            foreach (DataRowView r in ProductsDataview)
                r["tick"] = true;
            ProductsDataview.AllowEdit = false;
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            ProductsDataview.AllowEdit = true;
            foreach (DataRowView r in ProductsDataview)
                r["tick"] = false;
            ProductsDataview.AllowEdit = false;
        }

        private void btnEmailAll_Click(object sender, EventArgs e)
        {
            ProductsDataview.AllowEdit = true;
            foreach (DataRowView r in ProductsDataview)
                r["email"] = true;
            ProductsDataview.AllowEdit = false;
        }

        private void btnEmailNone_Click(object sender, EventArgs e)
        {
            ProductsDataview.AllowEdit = true;
            foreach (DataRowView r in ProductsDataview)
                r["email"] = false;
            ProductsDataview.AllowEdit = false;
        }

        public void PopulateDatagrid()
        {
            try
            {
                int regionId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboRegion));
                int customerId = 0;
                if (theCustomer is object)
                    customerId = theCustomer.CustomerID;
                int onContract = 0;
                var switchExpr = Combo.get_GetSelectedItemValue(cboContract);
                switch (switchExpr)
                {
                    case "On Contract":
                        {
                            onContract = 1;
                            break;
                        }

                    case "Not On Contract":
                        {
                            onContract = 2;
                            break;
                        }
                }

                ProductsDataview = App.DB.EngineerVisitAssetWorkSheet.Products_LastGSRDone(dtpFrom.Value, dtpTo.Value, Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboRegion)), customerId, onContract, chkIncludeTenantsAssets.Checked, chkNotPrinted.Checked);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            theCustomer = null;
            dtpFrom.Value = DateAndTime.Today.AddYears(-1);
            dtpTo.Value = DateAndTime.Today.AddYears(-1).AddMonths(1);
            grpFilter.Enabled = true;
            var argcombo = cboContract;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            chkIncludeTenantsAssets.Checked = false;
            chkNotPrinted.Checked = true;
        }

        public void Export()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Visit Date"));
            dt.Columns.Add(new DataColumn("Appliance"));
            dt.Columns.Add(new DataColumn("Customer"));
            dt.Columns.Add(new DataColumn("Tenant"));
            dt.Columns.Add(new DataColumn("Address1"));
            dt.Columns.Add(new DataColumn("Address2"));
            dt.Columns.Add(new DataColumn("Address3"));
            dt.Columns.Add(new DataColumn("Address4"));
            dt.Columns.Add(new DataColumn("Postcode"));
            dt.Columns.Add(new DataColumn("Serial"));
            dt.Columns.Add(new DataColumn("GaswayRef"));
            dt.Columns.Add(new DataColumn("Active"));
            dt.Columns.Add(new DataColumn("TenantsAppliance"));
            dt.Columns.Add(new DataColumn("OnContract"));
            dt.Columns.Add(new DataColumn("Printed"));
            for (int itm = 0, loopTo = ((DataView)dgProductsLastGSR.DataSource).Count - 1; itm <= loopTo; itm++)
            {
                dgProductsLastGSR.CurrentRowIndex = itm;
                var r = dt.NewRow();
                if (Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow["VisitDate"]) == default)
                {
                    r["Visit Date"] = "Not Done";
                }
                else
                {
                    r["Visit Date"] = Strings.Format(Entity.Sys.Helper.MakeDateTimeValid(SelectedProductDataRow["VisitDate"]), "dd/MM/yyyy");
                }

                r["Appliance"] = SelectedProductDataRow["Appliance"];
                r["Customer"] = SelectedProductDataRow["CustomerName"];
                r["Address1"] = SelectedProductDataRow["Address1"];
                r["Address2"] = SelectedProductDataRow["Address2"];
                r["Address3"] = SelectedProductDataRow["Address3"];
                r["Address4"] = SelectedProductDataRow["Address4"];
                r["Postcode"] = SelectedProductDataRow["Postcode"];
                r["Tenant"] = SelectedProductDataRow["Tenant"];
                r["Serial"] = SelectedProductDataRow["SerialNum"];
                r["Active"] = SelectedProductDataRow["Active"];
                r["TenantsAppliance"] = SelectedProductDataRow["TenantsAppliance"];
                r["GaswayRef"] = SelectedProductDataRow["BoughtFrom"];
                r["OnContract"] = SelectedProductDataRow["OnContract"];
                r["Printed"] = SelectedProductDataRow["Printed"];
                dt.Rows.Add(r);
                dgProductsLastGSR.UnSelect(itm);
            }

            Entity.Sys.ExportHelper.Export(dt, "Appliance GSR Report", Entity.Sys.Enums.ExportType.CSV);
        }

        public void MoveProgressOn(bool toMaximum = false)
        {
            if (toMaximum)
            {
                pbStatus.Value = pbStatus.Maximum;
            }
            else
            {
                pbStatus.Value += 1;
            }

            Application.DoEvents();
        }
    }
}