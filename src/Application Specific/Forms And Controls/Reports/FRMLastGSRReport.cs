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

        private Button _btnPrintGSRReminders;

        internal Button btnPrintGSRReminders
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintGSRReminders;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintGSRReminders != null)
                {
                    _btnPrintGSRReminders.Click -= btnPrintGSRReminders_Click;
                }

                _btnPrintGSRReminders = value;
                if (_btnPrintGSRReminders != null)
                {
                    _btnPrintGSRReminders.Click += btnPrintGSRReminders_Click;
                }
            }
        }

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

        internal Button btnFindCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click -= btnFindCustomer_Click;
                }

                _btnFindCustomer = value;
                if (_btnFindCustomer != null)
                {
                    _btnFindCustomer.Click += btnFindCustomer_Click;
                }
            }
        }

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

        internal Button btnFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFilter != null)
                {
                    _btnFilter.Click -= btnFilter_Click;
                }

                _btnFilter = value;
                if (_btnFilter != null)
                {
                    _btnFilter.Click += btnFilter_Click;
                }
            }
        }

        private Button _btnUnselect;

        internal Button btnUnselect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnUnselect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnUnselect != null)
                {
                    _btnUnselect.Click -= btnUnselect_Click;
                }

                _btnUnselect = value;
                if (_btnUnselect != null)
                {
                    _btnUnselect.Click += btnUnselect_Click;
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

        private Button _btnEmailNone;

        internal Button btnEmailNone
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEmailNone;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEmailNone != null)
                {
                    _btnEmailNone.Click -= btnEmailNone_Click;
                }

                _btnEmailNone = value;
                if (_btnEmailNone != null)
                {
                    _btnEmailNone.Click += btnEmailNone_Click;
                }
            }
        }

        private Button _btnEmailAll;

        internal Button btnEmailAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEmailAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEmailAll != null)
                {
                    _btnEmailAll.Click -= btnEmailAll_Click;
                }

                _btnEmailAll = value;
                if (_btnEmailAll != null)
                {
                    _btnEmailAll.Click += btnEmailAll_Click;
                }
            }
        }

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
            _grpJobs = new GroupBox();
            _dgProductsLastGSR = new DataGrid();
            _dgProductsLastGSR.MouseUp += new MouseEventHandler(dg_MouseUp);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _btnFilter = new Button();
            _btnFilter.Click += new EventHandler(btnFilter_Click);
            _cboRegion = new ComboBox();
            _Label2 = new Label();
            _cboContract = new ComboBox();
            _Label1 = new Label();
            _chkIncludeTenantsAssets = new CheckBox();
            _chkNotPrinted = new CheckBox();
            _btnFindCustomer = new Button();
            _btnFindCustomer.Click += new EventHandler(btnFindCustomer_Click);
            _txtCustomer = new TextBox();
            _Label4 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpFrom = new DateTimePicker();
            _Label9 = new Label();
            _Label8 = new Label();
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _btnPrintGSRReminders = new Button();
            _btnPrintGSRReminders.Click += new EventHandler(btnPrintGSRReminders_Click);
            _pbStatus = new ProgressBar();
            _btnUnselect = new Button();
            _btnUnselect.Click += new EventHandler(btnUnselect_Click);
            _btnSelectAll = new Button();
            _btnSelectAll.Click += new EventHandler(btnSelectAll_Click);
            _btnEmailNone = new Button();
            _btnEmailNone.Click += new EventHandler(btnEmailNone_Click);
            _btnEmailAll = new Button();
            _btnEmailAll.Click += new EventHandler(btnEmailAll_Click);
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgProductsLastGSR).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpJobs
            //
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgProductsLastGSR);
            _grpJobs.Location = new Point(8, 185);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(1172, 271);
            _grpJobs.TabIndex = 1;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Service Reminders";
            //
            // dgProductsLastGSR
            //
            _dgProductsLastGSR.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgProductsLastGSR.DataMember = "";
            _dgProductsLastGSR.HeaderForeColor = SystemColors.ControlText;
            _dgProductsLastGSR.Location = new Point(8, 19);
            _dgProductsLastGSR.Name = "dgProductsLastGSR";
            _dgProductsLastGSR.Size = new Size(1156, 244);
            _dgProductsLastGSR.TabIndex = 0;
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
            _grpFilter.Controls.Add(_btnFilter);
            _grpFilter.Controls.Add(_cboRegion);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_cboContract);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_chkIncludeTenantsAssets);
            _grpFilter.Controls.Add(_chkNotPrinted);
            _grpFilter.Controls.Add(_btnFindCustomer);
            _grpFilter.Controls.Add(_txtCustomer);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Location = new Point(8, 32);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(1172, 115);
            _grpFilter.TabIndex = 0;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // btnFilter
            //
            _btnFilter.AccessibleDescription = "";
            _btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFilter.Location = new Point(1031, 75);
            _btnFilter.Name = "btnFilter";
            _btnFilter.Size = new Size(126, 23);
            _btnFilter.TabIndex = 15;
            _btnFilter.Text = "Run Filter";
            //
            // cboRegion
            //
            _cboRegion.FormattingEnabled = true;
            _cboRegion.Location = new Point(310, 73);
            _cboRegion.Name = "cboRegion";
            _cboRegion.Size = new Size(144, 21);
            _cboRegion.TabIndex = 14;
            //
            // Label2
            //
            _Label2.Location = new Point(248, 75);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(57, 17);
            _Label2.TabIndex = 13;
            _Label2.Text = "Region";
            //
            // cboContract
            //
            _cboContract.FormattingEnabled = true;
            _cboContract.Location = new Point(85, 71);
            _cboContract.Name = "cboContract";
            _cboContract.Size = new Size(144, 21);
            _cboContract.TabIndex = 9;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 73);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(64, 16);
            _Label1.TabIndex = 8;
            _Label1.Text = "Contract";
            //
            // chkIncludeTenantsAssets
            //
            _chkIncludeTenantsAssets.AutoSize = true;
            _chkIncludeTenantsAssets.Location = new Point(487, 21);
            _chkIncludeTenantsAssets.Name = "chkIncludeTenantsAssets";
            _chkIncludeTenantsAssets.Size = new Size(157, 17);
            _chkIncludeTenantsAssets.TabIndex = 11;
            _chkIncludeTenantsAssets.Text = "Include Tenants Assets";
            _chkIncludeTenantsAssets.UseVisualStyleBackColor = true;
            //
            // chkNotPrinted
            //
            _chkNotPrinted.AutoSize = true;
            _chkNotPrinted.Location = new Point(664, 23);
            _chkNotPrinted.Name = "chkNotPrinted";
            _chkNotPrinted.Size = new Size(66, 17);
            _chkNotPrinted.TabIndex = 12;
            _chkNotPrinted.Text = "Printed";
            _chkNotPrinted.UseVisualStyleBackColor = true;
            //
            // btnFindCustomer
            //
            _btnFindCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindCustomer.BackColor = Color.White;
            _btnFindCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindCustomer.Location = new Point(1125, 44);
            _btnFindCustomer.Name = "btnFindCustomer";
            _btnFindCustomer.Size = new Size(32, 23);
            _btnFindCustomer.TabIndex = 7;
            _btnFindCustomer.Text = "...";
            _btnFindCustomer.UseVisualStyleBackColor = false;
            //
            // txtCustomer
            //
            _txtCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCustomer.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtCustomer.Location = new Point(85, 46);
            _txtCustomer.Name = "txtCustomer";
            _txtCustomer.ReadOnly = true;
            _txtCustomer.Size = new Size(1034, 21);
            _txtCustomer.TabIndex = 6;
            //
            // Label4
            //
            _Label4.Location = new Point(8, 49);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(64, 16);
            _Label4.TabIndex = 5;
            _Label4.Text = "Customer";
            //
            // dtpTo
            //
            _dtpTo.Location = new Point(310, 20);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(144, 21);
            _dtpTo.TabIndex = 3;
            //
            // dtpFrom
            //
            _dtpFrom.Location = new Point(85, 20);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(144, 21);
            _dtpFrom.TabIndex = 1;
            //
            // Label9
            //
            _Label9.Location = new Point(273, 21);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(24, 16);
            _Label9.TabIndex = 2;
            _Label9.Text = "To";
            //
            // Label8
            //
            _Label8.Location = new Point(8, 22);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(88, 16);
            _Label8.TabIndex = 0;
            _Label8.Text = "Date From";
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
            // btnPrintGSRReminders
            //
            _btnPrintGSRReminders.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnPrintGSRReminders.Location = new Point(1039, 464);
            _btnPrintGSRReminders.Name = "btnPrintGSRReminders";
            _btnPrintGSRReminders.Size = new Size(141, 23);
            _btnPrintGSRReminders.TabIndex = 5;
            _btnPrintGSRReminders.Text = "Print GSR Reminders";
            _btnPrintGSRReminders.UseVisualStyleBackColor = true;
            //
            // pbStatus
            //
            _pbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _pbStatus.Location = new Point(134, 464);
            _pbStatus.Name = "pbStatus";
            _pbStatus.Size = new Size(899, 23);
            _pbStatus.TabIndex = 4;
            //
            // btnUnselect
            //
            _btnUnselect.Location = new Point(137, 156);
            _btnUnselect.Name = "btnUnselect";
            _btnUnselect.Size = new Size(96, 23);
            _btnUnselect.TabIndex = 9;
            _btnUnselect.Text = "Unselect All";
            _btnUnselect.UseVisualStyleBackColor = true;
            //
            // btnSelectAll
            //
            _btnSelectAll.Location = new Point(12, 156);
            _btnSelectAll.Name = "btnSelectAll";
            _btnSelectAll.Size = new Size(119, 23);
            _btnSelectAll.TabIndex = 8;
            _btnSelectAll.Text = "Select All";
            _btnSelectAll.UseVisualStyleBackColor = true;
            //
            // btnEmailNone
            //
            _btnEmailNone.Location = new Point(373, 156);
            _btnEmailNone.Name = "btnEmailNone";
            _btnEmailNone.Size = new Size(96, 23);
            _btnEmailNone.TabIndex = 11;
            _btnEmailNone.Text = "Email None";
            _btnEmailNone.UseVisualStyleBackColor = true;
            //
            // btnEmailAll
            //
            _btnEmailAll.Location = new Point(248, 156);
            _btnEmailAll.Name = "btnEmailAll";
            _btnEmailAll.Size = new Size(119, 23);
            _btnEmailAll.TabIndex = 10;
            _btnEmailAll.Text = "Email All";
            _btnEmailAll.UseVisualStyleBackColor = true;
            //
            // FRMLastGSRReport
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1188, 494);
            Controls.Add(_btnEmailNone);
            Controls.Add(_btnEmailAll);
            Controls.Add(_btnUnselect);
            Controls.Add(_btnSelectAll);
            Controls.Add(_pbStatus);
            Controls.Add(_btnPrintGSRReminders);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpJobs);
            Controls.Add(_btnReset);
            MinimumSize = new Size(808, 528);
            Name = "FRMLastGSRReport";
            Text = "Product Last GSR Report";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            Controls.SetChildIndex(_btnPrintGSRReminders, 0);
            Controls.SetChildIndex(_pbStatus, 0);
            Controls.SetChildIndex(_btnSelectAll, 0);
            Controls.SetChildIndex(_btnUnselect, 0);
            Controls.SetChildIndex(_btnEmailAll, 0);
            Controls.SetChildIndex(_btnEmailNone, 0);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgProductsLastGSR).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
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