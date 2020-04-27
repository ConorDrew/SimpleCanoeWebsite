using FSM.Entity.Sys;
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
    public class FRMOrderManager : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMOrderManager() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            var argc = cboType;
            Combo.SetUpCombo(ref argc, DynamicDataTables.OrderTypeForSearch, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc1 = cboStatus;
            Combo.SetUpCombo(ref argc1, App.DB.Order.OrderStatus_Get_All().Table, "OrderStatusID", "Name", Enums.ComboValues.No_Filter);
            var argc2 = cboSupplierInvoiceSent;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.Yes_No, "ValueMember", "DisplayMember", Enums.ComboValues.No_Filter);
            var argc3 = cboSupplier;
            Combo.SetUpCombo(ref argc3, App.DB.Supplier.Supplier_GetAll().Table, "SupplierID", "Name", Enums.ComboValues.No_Filter);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc4 = cboDepartment;
                        Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc5 = cboDepartment;
                        Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

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

        private ComboBox _cboStatus;

        internal ComboBox cboStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged -= cboStatus_SelectedIndexChanged;
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                    _cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
                }
            }
        }

        private Label _Label11;

        internal Label Label11
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label11;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label11 != null)
                {
                }

                _Label11 = value;
                if (_Label11 != null)
                {
                }
            }
        }

        private ComboBox _cboType;

        internal ComboBox cboType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged -= cboType_SelectedIndexChanged;
                }

                _cboType = value;
                if (_cboType != null)
                {
                    _cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
                }
            }
        }

        private Label _Label10;

        internal Label Label10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label10 != null)
                {
                }

                _Label10 = value;
                if (_Label10 != null)
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

        private CheckBox _chkDateCreated;

        internal CheckBox chkDateCreated
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDateCreated;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDateCreated != null)
                {
                    _chkDateCreated.CheckedChanged -= chkDateCreated_CheckedChanged;
                }

                _chkDateCreated = value;
                if (_chkDateCreated != null)
                {
                    _chkDateCreated.CheckedChanged += chkDateCreated_CheckedChanged;
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

        private DataGrid _dgOrders;

        internal DataGrid dgOrders
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgOrders;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgOrders != null)
                {
                    _dgOrders.DoubleClick -= dgOrders_DoubleClick;
                }

                _dgOrders = value;
                if (_dgOrders != null)
                {
                    _dgOrders.DoubleClick += dgOrders_DoubleClick;
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

        private TextBox _txtOrderRef;

        internal TextBox txtOrderRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOrderRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOrderRef != null)
                {
                    _txtOrderRef.KeyDown -= txtOrderRef_TextChanged;
                }

                _txtOrderRef = value;
                if (_txtOrderRef != null)
                {
                    _txtOrderRef.KeyDown += txtOrderRef_TextChanged;
                }
            }
        }

        private Label _lblSearch;

        internal Label lblSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSearch != null)
                {
                }

                _lblSearch = value;
                if (_lblSearch != null)
                {
                }
            }
        }

        private Button _btnFindRecord;

        internal Button btnFindRecord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFindRecord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFindRecord != null)
                {
                    _btnFindRecord.Click -= btnFindRecord_Click;
                }

                _btnFindRecord = value;
                if (_btnFindRecord != null)
                {
                    _btnFindRecord.Click += btnFindRecord_Click;
                }
            }
        }

        private TextBox _txtSearch;

        internal TextBox txtSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearch != null)
                {
                }

                _txtSearch = value;
                if (_txtSearch != null)
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

        private DateTimePicker _dtpDeliveryDeadlineTo;

        internal DateTimePicker dtpDeliveryDeadlineTo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDeliveryDeadlineTo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDeliveryDeadlineTo != null)
                {
                    _dtpDeliveryDeadlineTo.ValueChanged -= dtpDeliveryDeadlineTo_ValueChanged;
                }

                _dtpDeliveryDeadlineTo = value;
                if (_dtpDeliveryDeadlineTo != null)
                {
                    _dtpDeliveryDeadlineTo.ValueChanged += dtpDeliveryDeadlineTo_ValueChanged;
                }
            }
        }

        private DateTimePicker _dtpDeliveryDeadlineFrom;

        internal DateTimePicker dtpDeliveryDeadlineFrom
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpDeliveryDeadlineFrom;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpDeliveryDeadlineFrom != null)
                {
                    _dtpDeliveryDeadlineFrom.ValueChanged -= dtpDeliveryDeadlineFrom_ValueChanged;
                }

                _dtpDeliveryDeadlineFrom = value;
                if (_dtpDeliveryDeadlineFrom != null)
                {
                    _dtpDeliveryDeadlineFrom.ValueChanged += dtpDeliveryDeadlineFrom_ValueChanged;
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

        private CheckBox _chkDeliveryDeadline;

        internal CheckBox chkDeliveryDeadline
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDeliveryDeadline;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDeliveryDeadline != null)
                {
                    _chkDeliveryDeadline.CheckedChanged -= chkDeliveryDeadline_CheckedChanged;
                }

                _chkDeliveryDeadline = value;
                if (_chkDeliveryDeadline != null)
                {
                    _chkDeliveryDeadline.CheckedChanged += chkDeliveryDeadline_CheckedChanged;
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

        private ComboBox _cboSupplierInvoiceSent;

        internal ComboBox cboSupplierInvoiceSent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSupplierInvoiceSent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSupplierInvoiceSent != null)
                {
                    _cboSupplierInvoiceSent.SelectedIndexChanged -= cboSupplierInvoiceSent_SelectedIndexChanged;
                }

                _cboSupplierInvoiceSent = value;
                if (_cboSupplierInvoiceSent != null)
                {
                    _cboSupplierInvoiceSent.SelectedIndexChanged += cboSupplierInvoiceSent_SelectedIndexChanged;
                }
            }
        }

        private TextBox _txtConsolidationRef;

        internal TextBox txtConsolidationRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtConsolidationRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtConsolidationRef != null)
                {
                    _txtConsolidationRef.TextChanged -= txtConsolidationRef_TextChanged;
                }

                _txtConsolidationRef = value;
                if (_txtConsolidationRef != null)
                {
                    _txtConsolidationRef.TextChanged += txtConsolidationRef_TextChanged;
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

        private TextBox _txtContains;

        internal TextBox txtContains
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContains;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContains != null)
                {
                    _txtContains.TextChanged -= txtContains_TextChanged;
                }

                _txtContains = value;
                if (_txtContains != null)
                {
                    _txtContains.TextChanged += txtContains_TextChanged;
                }
            }
        }

        private Label _Label7;

        internal Label Label7
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label7;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label7 != null)
                {
                }

                _Label7 = value;
                if (_Label7 != null)
                {
                }
            }
        }

        private CheckBox _chkEngineerNotReceived;

        internal CheckBox chkEngineerNotReceived
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkEngineerNotReceived;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkEngineerNotReceived != null)
                {
                    _chkEngineerNotReceived.CheckedChanged -= chkEngineerNotReceived_CheckedChanged;
                }

                _chkEngineerNotReceived = value;
                if (_chkEngineerNotReceived != null)
                {
                    _chkEngineerNotReceived.CheckedChanged += chkEngineerNotReceived_CheckedChanged;
                }
            }
        }

        private Button _btnFilterResults;

        internal Button btnFilterResults
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnFilterResults;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnFilterResults != null)
                {
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _btnFilterResults.Click -= btnFilterResults_Click;
                }

                _btnFilterResults = value;
                if (_btnFilterResults != null)
                {
                    _btnFilterResults.Click += btnFilterResults_Click;
                }
            }
        }

        private Label _Label12;

        internal Label Label12
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label12;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label12 != null)
                {
                }

                _Label12 = value;
                if (_Label12 != null)
                {
                }
            }
        }

        private ComboBox _cboDepartment;

        internal ComboBox cboDepartment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDepartment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDepartment != null)
                {
                }

                _cboDepartment = value;
                if (_cboDepartment != null)
                {
                }
            }
        }

        private CheckBox _chkOutstanding;

        internal CheckBox chkOutstanding
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkOutstanding;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkOutstanding != null)
                {
                    _chkOutstanding.CheckedChanged -= chkOutstanding_CheckedChanged;
                }

                _chkOutstanding = value;
                if (_chkOutstanding != null)
                {
                    _chkOutstanding.CheckedChanged += chkOutstanding_CheckedChanged;
                }
            }
        }

        private ComboBox _cboSupplier;

        internal ComboBox cboSupplier
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSupplier;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSupplier != null)
                {
                    _cboSupplier.SelectedIndexChanged -= cboSupplier_SelectedIndexChanged;
                }

                _cboSupplier = value;
                if (_cboSupplier != null)
                {
                    _cboSupplier.SelectedIndexChanged += cboSupplier_SelectedIndexChanged;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpJobs = new GroupBox();
            _dgOrders = new DataGrid();
            _dgOrders.DoubleClick += new EventHandler(dgOrders_DoubleClick);
            _btnExport = new Button();
            _btnExport.Click += new EventHandler(btnExport_Click);
            _grpFilter = new GroupBox();
            _chkOutstanding = new CheckBox();
            _chkOutstanding.CheckedChanged += new EventHandler(chkOutstanding_CheckedChanged);
            _Label12 = new Label();
            _cboDepartment = new ComboBox();
            _btnFilterResults = new Button();
            _btnFilterResults.Click += new EventHandler(btnFilterResults_Click);
            _chkEngineerNotReceived = new CheckBox();
            _chkEngineerNotReceived.CheckedChanged += new EventHandler(chkEngineerNotReceived_CheckedChanged);
            _txtContains = new TextBox();
            _txtContains.TextChanged += new EventHandler(txtContains_TextChanged);
            _Label7 = new Label();
            _txtConsolidationRef = new TextBox();
            _txtConsolidationRef.TextChanged += new EventHandler(txtConsolidationRef_TextChanged);
            _Label6 = new Label();
            _Label5 = new Label();
            _cboSupplierInvoiceSent = new ComboBox();
            //_cboSupplierInvoiceSent.SelectedIndexChanged += new EventHandler(cboSupplierInvoiceSent_SelectedIndexChanged);
            _dtpDeliveryDeadlineTo = new DateTimePicker();
            _dtpDeliveryDeadlineTo.ValueChanged += new EventHandler(dtpDeliveryDeadlineTo_ValueChanged);
            _dtpDeliveryDeadlineFrom = new DateTimePicker();
            _dtpDeliveryDeadlineFrom.ValueChanged += new EventHandler(dtpDeliveryDeadlineFrom_ValueChanged);
            _Label2 = new Label();
            _Label3 = new Label();
            _cboSupplier = new ComboBox();
            //_cboSupplier.SelectedIndexChanged += new EventHandler(cboSupplier_SelectedIndexChanged);
            _Label1 = new Label();
            _btnFindRecord = new Button();
            _btnFindRecord.Click += new EventHandler(btnFindRecord_Click);
            _txtSearch = new TextBox();
            _Label4 = new Label();
            _dtpTo = new DateTimePicker();
            _dtpTo.ValueChanged += new EventHandler(dtpTo_ValueChanged);
            _dtpFrom = new DateTimePicker();
            _dtpFrom.ValueChanged += new EventHandler(dtpFrom_ValueChanged);
            _txtOrderRef = new TextBox();
            _txtOrderRef.KeyDown += new KeyEventHandler(txtOrderRef_TextChanged);
            _Label9 = new Label();
            _Label8 = new Label();
            _chkDateCreated = new CheckBox();
            _chkDateCreated.CheckedChanged += new EventHandler(chkDateCreated_CheckedChanged);
            _lblSearch = new Label();
            _Label10 = new Label();
            _cboType = new ComboBox();
            //_cboType.SelectedIndexChanged += new EventHandler(cboType_SelectedIndexChanged);
            _Label11 = new Label();
            _cboStatus = new ComboBox();
            //_cboStatus.SelectedIndexChanged += new EventHandler(cboStatus_SelectedIndexChanged);
            _chkDeliveryDeadline = new CheckBox();
            _chkDeliveryDeadline.CheckedChanged += new EventHandler(chkDeliveryDeadline_CheckedChanged);
            _btnReset = new Button();
            _btnReset.Click += new EventHandler(btnReset_Click);
            _grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgOrders).BeginInit();
            _grpFilter.SuspendLayout();
            SuspendLayout();
            //
            // grpJobs
            //
            _grpJobs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpJobs.Controls.Add(_dgOrders);
            _grpJobs.Location = new Point(8, 321);
            _grpJobs.Name = "grpJobs";
            _grpJobs.Size = new Size(1360, 260);
            _grpJobs.TabIndex = 1;
            _grpJobs.TabStop = false;
            _grpJobs.Text = "Results (awaiting search) - Double Click To View / Edit";
            //
            // dgOrders
            //
            _dgOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgOrders.DataMember = "";
            _dgOrders.HeaderForeColor = SystemColors.ControlText;
            _dgOrders.Location = new Point(8, 30);
            _dgOrders.Name = "dgOrders";
            _dgOrders.Size = new Size(1344, 222);
            _dgOrders.TabIndex = 11;
            //
            // btnExport
            //
            _btnExport.AccessibleDescription = "Export Job List To Excel";
            _btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExport.Location = new Point(8, 589);
            _btnExport.Name = "btnExport";
            _btnExport.Size = new Size(56, 23);
            _btnExport.TabIndex = 2;
            _btnExport.Text = "Export";
            //
            // grpFilter
            //
            _grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _grpFilter.Controls.Add(_chkOutstanding);
            _grpFilter.Controls.Add(_Label12);
            _grpFilter.Controls.Add(_cboDepartment);
            _grpFilter.Controls.Add(_btnFilterResults);
            _grpFilter.Controls.Add(_chkEngineerNotReceived);
            _grpFilter.Controls.Add(_txtContains);
            _grpFilter.Controls.Add(_Label7);
            _grpFilter.Controls.Add(_txtConsolidationRef);
            _grpFilter.Controls.Add(_Label6);
            _grpFilter.Controls.Add(_Label5);
            _grpFilter.Controls.Add(_cboSupplierInvoiceSent);
            _grpFilter.Controls.Add(_dtpDeliveryDeadlineTo);
            _grpFilter.Controls.Add(_dtpDeliveryDeadlineFrom);
            _grpFilter.Controls.Add(_Label2);
            _grpFilter.Controls.Add(_Label3);
            _grpFilter.Controls.Add(_cboSupplier);
            _grpFilter.Controls.Add(_Label1);
            _grpFilter.Controls.Add(_btnFindRecord);
            _grpFilter.Controls.Add(_txtSearch);
            _grpFilter.Controls.Add(_Label4);
            _grpFilter.Controls.Add(_dtpTo);
            _grpFilter.Controls.Add(_dtpFrom);
            _grpFilter.Controls.Add(_txtOrderRef);
            _grpFilter.Controls.Add(_Label9);
            _grpFilter.Controls.Add(_Label8);
            _grpFilter.Controls.Add(_chkDateCreated);
            _grpFilter.Controls.Add(_lblSearch);
            _grpFilter.Controls.Add(_Label10);
            _grpFilter.Controls.Add(_cboType);
            _grpFilter.Controls.Add(_Label11);
            _grpFilter.Controls.Add(_cboStatus);
            _grpFilter.Controls.Add(_chkDeliveryDeadline);
            _grpFilter.Location = new Point(8, 40);
            _grpFilter.Name = "grpFilter";
            _grpFilter.Size = new Size(1360, 275);
            _grpFilter.TabIndex = 0;
            _grpFilter.TabStop = false;
            _grpFilter.Text = "Filter";
            //
            // chkOutstanding
            //
            _chkOutstanding.Cursor = Cursors.Hand;
            _chkOutstanding.Location = new Point(420, 122);
            _chkOutstanding.Name = "chkOutstanding";
            _chkOutstanding.Size = new Size(221, 24);
            _chkOutstanding.TabIndex = 34;
            _chkOutstanding.Text = "PO not reconciled (outstanding)";
            _chkOutstanding.UseVisualStyleBackColor = true;
            //
            // Label12
            //
            _Label12.Location = new Point(13, 249);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(117, 20);
            _Label12.TabIndex = 33;
            _Label12.Text = "Cost Centre";
            //
            // cboDepartment
            //
            _cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDepartment.Location = new Point(136, 247);
            _cboDepartment.Name = "cboDepartment";
            _cboDepartment.Size = new Size(142, 21);
            _cboDepartment.TabIndex = 32;
            //
            // btnFilterResults
            //
            _btnFilterResults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFilterResults.Location = new Point(1243, 244);
            _btnFilterResults.Name = "btnFilterResults";
            _btnFilterResults.Size = new Size(109, 23);
            _btnFilterResults.TabIndex = 31;
            _btnFilterResults.Text = "Filter Results";
            _btnFilterResults.UseVisualStyleBackColor = true;
            //
            // chkEngineerNotReceived
            //
            _chkEngineerNotReceived.Cursor = Cursors.Hand;
            _chkEngineerNotReceived.Location = new Point(289, 123);
            _chkEngineerNotReceived.Name = "chkEngineerNotReceived";
            _chkEngineerNotReceived.Size = new Size(141, 24);
            _chkEngineerNotReceived.TabIndex = 7;
            _chkEngineerNotReceived.Text = "Eng Not Received";
            _chkEngineerNotReceived.UseVisualStyleBackColor = true;
            //
            // txtContains
            //
            _txtContains.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtContains.Location = new Point(624, 92);
            _txtContains.MaxLength = 100;
            _txtContains.Name = "txtContains";
            _txtContains.Size = new Size(727, 21);
            _txtContains.TabIndex = 5;
            //
            // Label7
            //
            _Label7.Location = new Point(523, 92);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(118, 23);
            _Label7.TabIndex = 30;
            _Label7.Text = "Order Contains";
            //
            // txtConsolidationRef
            //
            _txtConsolidationRef.Location = new Point(395, 92);
            _txtConsolidationRef.Name = "txtConsolidationRef";
            _txtConsolidationRef.Size = new Size(122, 21);
            _txtConsolidationRef.TabIndex = 4;
            //
            // Label6
            //
            _Label6.Location = new Point(284, 95);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(124, 20);
            _Label6.TabIndex = 28;
            _Label6.Text = "Consolidation Ref";
            //
            // Label5
            //
            _Label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _Label5.Location = new Point(974, 123);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(266, 23);
            _Label5.TabIndex = 27;
            _Label5.Text = "Supplier Invoice Sent to Accounts Package";
            //
            // cboSupplierInvoiceSent
            //
            _cboSupplierInvoiceSent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _cboSupplierInvoiceSent.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSupplierInvoiceSent.Location = new Point(1242, 121);
            _cboSupplierInvoiceSent.Name = "cboSupplierInvoiceSent";
            _cboSupplierInvoiceSent.Size = new Size(110, 21);
            _cboSupplierInvoiceSent.TabIndex = 8;
            //
            // dtpDeliveryDeadlineTo
            //
            _dtpDeliveryDeadlineTo.Location = new Point(596, 216);
            _dtpDeliveryDeadlineTo.Name = "dtpDeliveryDeadlineTo";
            _dtpDeliveryDeadlineTo.Size = new Size(224, 21);
            _dtpDeliveryDeadlineTo.TabIndex = 15;
            //
            // dtpDeliveryDeadlineFrom
            //
            _dtpDeliveryDeadlineFrom.Location = new Point(596, 184);
            _dtpDeliveryDeadlineFrom.Name = "dtpDeliveryDeadlineFrom";
            _dtpDeliveryDeadlineFrom.Size = new Size(224, 21);
            _dtpDeliveryDeadlineFrom.TabIndex = 14;
            //
            // Label2
            //
            _Label2.Location = new Point(548, 216);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(48, 16);
            _Label2.TabIndex = 24;
            _Label2.Text = "To";
            //
            // Label3
            //
            _Label3.Location = new Point(548, 184);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(48, 16);
            _Label3.TabIndex = 21;
            _Label3.Text = "From";
            //
            // cboSupplier
            //
            _cboSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSupplier.Location = new Point(136, 152);
            _cboSupplier.Name = "cboSupplier";
            _cboSupplier.Size = new Size(1216, 21);
            _cboSupplier.TabIndex = 9;
            //
            // Label1
            //
            _Label1.Location = new Point(16, 152);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(100, 23);
            _Label1.TabIndex = 18;
            _Label1.Text = "Supplier";
            //
            // btnFindRecord
            //
            _btnFindRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnFindRecord.BackColor = Color.White;
            _btnFindRecord.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _btnFindRecord.Location = new Point(1320, 58);
            _btnFindRecord.Name = "btnFindRecord";
            _btnFindRecord.Size = new Size(32, 23);
            _btnFindRecord.TabIndex = 2;
            _btnFindRecord.Text = "...";
            _btnFindRecord.UseVisualStyleBackColor = false;
            //
            // txtSearch
            //
            _txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtSearch.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtSearch.Location = new Point(136, 60);
            _txtSearch.Name = "txtSearch";
            _txtSearch.ReadOnly = true;
            _txtSearch.Size = new Size(1176, 21);
            _txtSearch.TabIndex = 1;
            //
            // Label4
            //
            _Label4.Location = new Point(16, 89);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(72, 20);
            _Label4.TabIndex = 15;
            _Label4.Text = "Order Ref";
            //
            // dtpTo
            //
            _dtpTo.Location = new Point(183, 216);
            _dtpTo.Name = "dtpTo";
            _dtpTo.Size = new Size(224, 21);
            _dtpTo.TabIndex = 12;
            //
            // dtpFrom
            //
            _dtpFrom.Location = new Point(183, 184);
            _dtpFrom.Name = "dtpFrom";
            _dtpFrom.Size = new Size(224, 21);
            _dtpFrom.TabIndex = 11;
            //
            // txtOrderRef
            //
            _txtOrderRef.Location = new Point(136, 92);
            _txtOrderRef.Name = "txtOrderRef";
            _txtOrderRef.Size = new Size(142, 21);
            _txtOrderRef.TabIndex = 3;
            //
            // Label9
            //
            _Label9.Location = new Point(135, 216);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(48, 16);
            _Label9.TabIndex = 10;
            _Label9.Text = "To";
            //
            // Label8
            //
            _Label8.Location = new Point(135, 184);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(48, 16);
            _Label8.TabIndex = 9;
            _Label8.Text = "From";
            //
            // chkDateCreated
            //
            _chkDateCreated.Cursor = Cursors.Hand;
            _chkDateCreated.Location = new Point(16, 184);
            _chkDateCreated.Name = "chkDateCreated";
            _chkDateCreated.Size = new Size(104, 24);
            _chkDateCreated.TabIndex = 10;
            _chkDateCreated.Text = "Date Placed";
            _chkDateCreated.UseVisualStyleBackColor = true;
            //
            // lblSearch
            //
            _lblSearch.Location = new Point(16, 56);
            _lblSearch.Name = "lblSearch";
            _lblSearch.Size = new Size(112, 20);
            _lblSearch.TabIndex = 2;
            //
            // Label10
            //
            _Label10.Location = new Point(16, 32);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(48, 20);
            _Label10.TabIndex = 4;
            _Label10.Text = "Type";
            //
            // cboType
            //
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(136, 29);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(1216, 21);
            _cboType.TabIndex = 0;
            //
            // Label11
            //
            _Label11.Location = new Point(16, 121);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(48, 20);
            _Label11.TabIndex = 5;
            _Label11.Text = "Status";
            //
            // cboStatus
            //
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(136, 124);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(142, 21);
            _cboStatus.TabIndex = 6;
            //
            // chkDeliveryDeadline
            //
            _chkDeliveryDeadline.Cursor = Cursors.Hand;
            _chkDeliveryDeadline.Location = new Point(420, 184);
            _chkDeliveryDeadline.Name = "chkDeliveryDeadline";
            _chkDeliveryDeadline.Size = new Size(132, 24);
            _chkDeliveryDeadline.TabIndex = 13;
            _chkDeliveryDeadline.Text = "Delivery Deadline";
            _chkDeliveryDeadline.UseVisualStyleBackColor = true;
            //
            // btnReset
            //
            _btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnReset.Location = new Point(72, 589);
            _btnReset.Name = "btnReset";
            _btnReset.Size = new Size(56, 23);
            _btnReset.TabIndex = 3;
            _btnReset.Text = "Reset";
            //
            // FRMOrderManager
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(1376, 619);
            Controls.Add(_grpFilter);
            Controls.Add(_btnExport);
            Controls.Add(_grpJobs);
            Controls.Add(_btnReset);
            MinimumSize = new Size(852, 592);
            Name = "FRMOrderManager";
            Text = "Order Manager";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_btnReset, 0);
            Controls.SetChildIndex(_grpJobs, 0);
            Controls.SetChildIndex(_btnExport, 0);
            Controls.SetChildIndex(_grpFilter, 0);
            _grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgOrders).EndInit();
            _grpFilter.ResumeLayout(false);
            _grpFilter.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public class PartsNotReceivedColourColumn : DataGridLabelColumn
        {
            /* TODO ERROR: Skipped RegionDirectiveTrivia */

            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                // set the color required dependant on the column value
                var brush = Brushes.White;
                DataRowView dr = (DataRowView)source.List[rowNum];
                if (Conversions.ToDouble(Helper.MakeStringValid(dr["OrderTypeID"])) == Conversions.ToInteger(Enums.OrderType.Job) | Conversions.ToDouble(Helper.MakeStringValid(dr["OrderTypeID"])) == Conversions.ToInteger(Enums.OrderType.StockProfile))
                {
                    if (Conversions.ToBoolean(Helper.MakeStringValid(dr["PartsNotReceived"])))
                    {
                        brush = Brushes.Red;
                    }
                    else
                    {
                        brush = Brushes.Green;
                    }
                }
                // color the row cell
                var rect = bounds;
                g.FillRectangle(brush, rect);
                g.DrawString("", DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
            }

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupOrdersDataGrid();

            ResetFilters();
            if (get_GetParameter(0) is object)
            {
                PopulateDatagrid();
            }
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
        private DataView _dvOrders;

        private DataView OrdersDataview
        {
            get
            {
                return _dvOrders;
            }

            set
            {
                _dvOrders = value;
                _dvOrders.AllowNew = false;
                _dvOrders.AllowEdit = false;
                _dvOrders.AllowDelete = false;
                _dvOrders.Table.TableName = Enums.TableNames.tblOrder.ToString();
                dgOrders.DataSource = OrdersDataview;
            }
        }

        private DataRow SelectedOrderDataRow
        {
            get
            {
                if (!(dgOrders.CurrentRowIndex == -1))
                {
                    return OrdersDataview[dgOrders.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Sites.Site _oSite;

        public Entity.Sites.Site theSite
        {
            get
            {
                return _oSite;
            }

            set
            {
                _oSite = value;
                if (_oSite is object)
                {
                    txtSearch.Text = theSite.Address1 + ", " + theSite.Address2 + ", " + theSite.Postcode;
                }
                else
                {
                    txtSearch.Text = "";
                }
            }
        }

        private Entity.Vans.Van _oVan;

        public Entity.Vans.Van Van
        {
            get
            {
                return _oVan;
            }

            set
            {
                _oVan = value;
                if (_oVan is object)
                {
                    txtSearch.Text = _oVan.Registration;
                }
                else
                {
                    txtSearch.Text = "";
                }
            }
        }

        private Entity.Warehouses.Warehouse _oWarehouse;

        public Entity.Warehouses.Warehouse Warehouse
        {
            get
            {
                return _oWarehouse;
            }

            set
            {
                _oWarehouse = value;
                if (_oWarehouse is object)
                {
                    txtSearch.Text = _oWarehouse.Name + " (" + _oWarehouse.Address1 + ", " + _oWarehouse.Postcode + ")";
                }
                else
                {
                    txtSearch.Text = "";
                }
            }
        }

        private Entity.Jobs.Job _oJob;

        public Entity.Jobs.Job Job
        {
            get
            {
                return _oJob;
            }

            set
            {
                _oJob = value;
                if (_oJob is object)
                {
                    txtSearch.Text = _oJob.JobNumber;
                }
                else
                {
                    txtSearch.Text = "";
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupOrdersDataGrid()
        {
            var tbStyle = dgOrders.TableStyles[0];
            var PartsNotReceived = new PartsNotReceivedColourColumn();
            PartsNotReceived.Format = "";
            PartsNotReceived.FormatInfo = null;
            PartsNotReceived.HeaderText = "";
            PartsNotReceived.MappingName = "PartsNotReceived";
            PartsNotReceived.ReadOnly = true;
            PartsNotReceived.Width = 25;
            PartsNotReceived.NullText = "";
            tbStyle.GridColumnStyles.Add(PartsNotReceived);
            var DateCreated = new DataGridLabelColumn();
            DateCreated.Format = "dd/MMM/yyyy";
            DateCreated.FormatInfo = null;
            DateCreated.HeaderText = "Date Placed";
            DateCreated.MappingName = "DatePlaced";
            DateCreated.ReadOnly = true;
            DateCreated.Width = 90;
            DateCreated.NullText = "";
            tbStyle.GridColumnStyles.Add(DateCreated);
            var DeliveryDeadline = new DataGridLabelColumn();
            DeliveryDeadline.Format = "dd/MMM/yyyy";
            DeliveryDeadline.FormatInfo = null;
            DeliveryDeadline.HeaderText = "Delivery Deadline";
            DeliveryDeadline.MappingName = "DeliveryDeadline";
            DeliveryDeadline.ReadOnly = true;
            DeliveryDeadline.Width = 90;
            DeliveryDeadline.NullText = "";
            tbStyle.GridColumnStyles.Add(DeliveryDeadline);
            var OrderReference = new DataGridLabelColumn();
            OrderReference.Format = "";
            OrderReference.FormatInfo = null;
            OrderReference.HeaderText = "Order Reference";
            OrderReference.MappingName = "OrderReference";
            OrderReference.ReadOnly = true;
            OrderReference.Width = 110;
            OrderReference.NullText = "";
            tbStyle.GridColumnStyles.Add(OrderReference);
            var ConsolidationRef = new DataGridLabelColumn();
            ConsolidationRef.Format = "";
            ConsolidationRef.FormatInfo = null;
            ConsolidationRef.HeaderText = "Consol Ref";
            ConsolidationRef.MappingName = "ConsolidationRef";
            ConsolidationRef.ReadOnly = true;
            ConsolidationRef.Width = 110;
            ConsolidationRef.NullText = "";
            tbStyle.GridColumnStyles.Add(ConsolidationRef);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 75;
            Type.NullText = Enums.ComboValues.Not_Applicable.ToString().Replace("_", " ");
            tbStyle.GridColumnStyles.Add(Type);
            var Customer = new DataGridLabelColumn();
            Customer.Format = "";
            Customer.FormatInfo = null;
            Customer.HeaderText = "Customer";
            Customer.MappingName = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 140;
            Customer.NullText = "N/A";
            tbStyle.GridColumnStyles.Add(Customer);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 140;
            Site.NullText = "N/A";
            tbStyle.GridColumnStyles.Add(Site);
            var Supplier = new DataGridLabelColumn();
            Supplier.Format = "";
            Supplier.FormatInfo = null;
            Supplier.HeaderText = "Supplier";
            Supplier.MappingName = "Supplier";
            Supplier.ReadOnly = true;
            Supplier.Width = 100;
            Supplier.NullText = "N/A";
            tbStyle.GridColumnStyles.Add(Supplier);
            var Van = new DataGridLabelColumn();
            Van.Format = "";
            Van.FormatInfo = null;
            Van.HeaderText = "Van";
            Van.MappingName = "Registration";
            Van.ReadOnly = true;
            Van.Width = 90;
            Van.NullText = "N/A";
            tbStyle.GridColumnStyles.Add(Van);
            var Warehouse = new DataGridLabelColumn();
            Warehouse.Format = "";
            Warehouse.FormatInfo = null;
            Warehouse.HeaderText = "Warehouse";
            Warehouse.MappingName = "Warehouse";
            Warehouse.ReadOnly = true;
            Warehouse.Width = 100;
            Warehouse.NullText = "N/A";
            tbStyle.GridColumnStyles.Add(Warehouse);
            var JobNumber = new DataGridLabelColumn();
            JobNumber.Format = "";
            JobNumber.FormatInfo = null;
            JobNumber.HeaderText = "Job Number";
            JobNumber.MappingName = "JobNumber";
            JobNumber.ReadOnly = true;
            JobNumber.Width = 100;
            JobNumber.NullText = "N/A";
            tbStyle.GridColumnStyles.Add(JobNumber);
            var OrderStatus = new DataGridLabelColumn();
            OrderStatus.Format = "";
            OrderStatus.FormatInfo = null;
            OrderStatus.HeaderText = "Status";
            OrderStatus.MappingName = "DisplayStatus";
            OrderStatus.ReadOnly = true;
            OrderStatus.Width = 120;
            OrderStatus.NullText = "";
            tbStyle.GridColumnStyles.Add(OrderStatus);
            var SupplierExported = new DataGridLabelColumn();
            SupplierExported.Format = "";
            SupplierExported.FormatInfo = null;
            SupplierExported.HeaderText = "Sup Inv Sent to Sage";
            SupplierExported.MappingName = "SupplierExported";
            SupplierExported.ReadOnly = true;
            SupplierExported.Width = 50;
            SupplierExported.NullText = "";
            tbStyle.GridColumnStyles.Add(SupplierExported);
            var BuyPrice = new DataGridLabelColumn();
            BuyPrice.Format = "C";
            BuyPrice.FormatInfo = null;
            BuyPrice.HeaderText = "Cost";
            BuyPrice.MappingName = "BuyPrice";
            BuyPrice.ReadOnly = true;
            BuyPrice.Width = 75;
            BuyPrice.NullText = "0";
            tbStyle.GridColumnStyles.Add(BuyPrice);
            var SellPrice = new DataGridLabelColumn();
            SellPrice.Format = "C";
            SellPrice.FormatInfo = null;
            SellPrice.HeaderText = "SI Amount";
            SellPrice.MappingName = "SupplierInvoiceAmount";
            SellPrice.ReadOnly = true;
            SellPrice.Width = 75;
            SellPrice.NullText = "£0.00";
            tbStyle.GridColumnStyles.Add(SellPrice);
            var Credit = new DataGridLabelColumn();
            Credit.Format = "C";
            Credit.FormatInfo = null;
            Credit.HeaderText = "Credited Amount";
            Credit.MappingName = "CreditAmount";
            Credit.ReadOnly = true;
            Credit.Width = 75;
            Credit.NullText = "£0.00";
            tbStyle.GridColumnStyles.Add(Credit);
            var CreatedBy = new DataGridLabelColumn();
            CreatedBy.Format = "";
            CreatedBy.FormatInfo = null;
            CreatedBy.HeaderText = "Created By";
            CreatedBy.MappingName = "CreatedBy";
            CreatedBy.ReadOnly = true;
            CreatedBy.Width = 100;
            CreatedBy.NullText = "";
            tbStyle.GridColumnStyles.Add(CreatedBy);
            var Department = new DataGridLabelColumn();
            Department.Format = "";
            Department.FormatInfo = null;
            Department.HeaderText = "Dept";
            Department.MappingName = "DepartmentRef";
            Department.ReadOnly = true;
            Department.Width = 100;
            Department.NullText = "";
            tbStyle.GridColumnStyles.Add(Department);
            dgOrders.ReadOnly = true;
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblOrder.ToString();
            dgOrders.TableStyles.Add(tbStyle);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void FRMOrderManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilters();
        }

        private void chkDateCreated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateCreated.Checked)
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
            else
            {
                dtpFrom.Value = DateAndTime.Today;
                dtpTo.Value = DateAndTime.Today;
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
            // RunFilter()
        }

        private void chkDeliveryDeadline_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeliveryDeadline.Checked)
            {
                dtpDeliveryDeadlineFrom.Enabled = true;
                dtpDeliveryDeadlineTo.Enabled = true;
            }
            else
            {
                dtpDeliveryDeadlineFrom.Value = DateAndTime.Today;
                dtpDeliveryDeadlineTo.Value = DateAndTime.Today;
                dtpDeliveryDeadlineFrom.Enabled = false;
                dtpDeliveryDeadlineTo.Enabled = false;
            }
            // RunFilter()
        }

        private void cboSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void cboVan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            theSite = null;
            Van = null;
            Job = null;
            Warehouse = null;
            var switchExpr = Combo.get_GetSelectedItemValue(cboType);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                    {
                        lblSearch.Text = "Select Type";
                        txtSearch.Text = "";
                        btnFindRecord.Enabled = false;
                        break;
                    }

                case var case1 when case1 == 1.ToString():
                    {
                        lblSearch.Text = "Select Property";
                        txtSearch.Text = "";
                        btnFindRecord.Enabled = true;
                        break;
                    }

                case var case2 when case2 == 2.ToString():
                    {
                        lblSearch.Text = "Select Warehouse";
                        txtSearch.Text = "";
                        btnFindRecord.Enabled = true;
                        break;
                    }

                case var case3 when case3 == 3.ToString():
                    {
                        lblSearch.Text = "Select Van";
                        txtSearch.Text = "";
                        btnFindRecord.Enabled = true;
                        break;
                    }

                case var case4 when case4 == 4.ToString():
                    {
                        lblSearch.Text = "Select Warehouse";
                        txtSearch.Text = "";
                        btnFindRecord.Enabled = true;
                        break;
                    }

                case var case5 when case5 == 5.ToString():
                    {
                        lblSearch.Text = "Select Job";
                        txtSearch.Text = "";
                        btnFindRecord.Enabled = true;
                        break;
                    }
            }
            // RunFilter()
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void chkEngineerNotReceived_CheckedChanged(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void cboSupplierInvoiceSent_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void txtOrderRef_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }

        private void txtConsolidationRef_TextChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void dtpDeliveryDeadlineFrom_ValueChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void dtpDeliveryDeadlineTo_ValueChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RunFilter()
        }

        private void txtContains_TextChanged(object sender, EventArgs e)
        {
            // Try
            // If txtContains.Text.Length >= 3 Then

            // Cursor.Current = Cursors.WaitCursor

            // OrdersDataview = DB.Order.Order_GetAll(Me.txtContains.Text.Trim)

            // RunFilter()
            // End If
            // Catch ex As Exception
            // Exit Sub
            // Finally
            // Cursor.Current = Cursors.Default
            // End Try
        }

        private void dgOrders_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedOrderDataRow is null)
            {
                App.ShowMessage("Please select an order to view", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var switchExpr = Conversions.ToInteger(SelectedOrderDataRow["OrderTypeID"]);
            switch (switchExpr)
            {
                case (int)Enums.OrderType.Customer:
                    {
                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedOrderDataRow["OrderID"], Helper.MakeIntegerValid(SelectedOrderDataRow["SiteID"]), 0, this });
                        break;
                    }

                case (int)Enums.OrderType.StockProfile:
                    {
                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedOrderDataRow["OrderID"], SelectedOrderDataRow["VanID"], 0, this });
                        break;
                    }

                case (int)Enums.OrderType.Warehouse:
                    {
                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedOrderDataRow["OrderID"], SelectedOrderDataRow["WarehouseID"], 0, this });
                        break;
                    }

                case (int)Enums.OrderType.Job:
                    {
                        App.ShowForm(typeof(FRMOrder), false, new object[] { SelectedOrderDataRow["OrderID"], SelectedOrderDataRow["EngineerVisitID"], 0, this });
                        break;
                    }
            }
        }

        private void btnFindRecord_Click(object sender, EventArgs e)
        {
            var switchExpr = Combo.get_GetSelectedItemValue(cboType);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                    {
                        break;
                    }

                case var case1 when case1 == 1.ToString():
                    {
                        int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblSite));
                        if (!(ID == 0))
                        {
                            theSite = App.DB.Sites.Get(ID);
                            RunFilter();
                        }

                        break;
                    }

                case var case2 when case2 == 2.ToString():
                    {
                        int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse));
                        if (!(ID == 0))
                        {
                            Warehouse = App.DB.Warehouse.Warehouse_Get(ID);
                            RunFilter();
                        }

                        break;
                    }

                case var case3 when case3 == 3.ToString():
                    {
                        int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblVan));
                        if (!(ID == 0))
                        {
                            Van = App.DB.Van.Van_Get(ID);
                            RunFilter();
                        }

                        break;
                    }

                case var case4 when case4 == 4.ToString():
                    {
                        int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblWarehouse));
                        if (!(ID == 0))
                        {
                            Warehouse = App.DB.Warehouse.Warehouse_Get(ID);
                            RunFilter();
                        }

                        break;
                    }

                case var case5 when case5 == 5.ToString():
                    {
                        int ID = Conversions.ToInteger(App.FindRecord(Enums.TableNames.tblJob));
                        if (!(ID == 0))
                        {
                            Job = App.DB.Job.Job_Get(ID);
                            RunFilter();
                        }

                        break;
                    }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void PopulateDatagrid()
        {
            try
            {
                // If GetParameter(0) = "" ThenElse
                if (get_GetParameter(0) is null)
                {
                    OrdersDataview = App.DB.Order.Order_GetAll(txtContains.Text.Trim());
                    RunFilter();
                }
                else
                {
                    OrdersDataview = (DataView)get_GetParameter(0);
                    grpFilter.Enabled = false;
                }

                // If Not GetParameter(0) = "" Then
                grpJobs.Text = string.Format("Results ({0}) - Double Click To View / Edit", OrdersDataview.Count);
            }
            // End If
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilters()
        {
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, 0.ToString());
            var argcombo2 = cboSupplierInvoiceSent;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, 0.ToString());
            var argcombo3 = cboSupplier;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, 0.ToString());
            chkDateCreated.Checked = false;
            dtpFrom.Value = DateAndTime.Today;
            dtpFrom.Enabled = false;
            dtpTo.Value = DateAndTime.Today;
            dtpTo.Enabled = false;
            chkDeliveryDeadline.Checked = false;
            dtpDeliveryDeadlineFrom.Value = DateAndTime.Today;
            dtpDeliveryDeadlineFrom.Enabled = false;
            dtpDeliveryDeadlineTo.Value = DateAndTime.Today;
            dtpDeliveryDeadlineTo.Enabled = false;
            grpFilter.Enabled = true;
            txtSearch.Text = "";
            txtConsolidationRef.Text = "";
            txtOrderRef.Text = "";
        }

        private void RunFilter()
        {
            if (OrdersDataview is object)
            {
                string whereClause = "Deleted = 0 ";
                if (theSite is object)
                {
                    whereClause += " AND SiteID = " + theSite.SiteID + "";
                }

                if (Van is object)
                {
                    whereClause += " AND VanID = " + Van.VanID + "";
                }

                if (Warehouse is object)
                {
                    whereClause += " AND WarehouseID = " + Warehouse.WarehouseID + "";
                }

                if (Job is object)
                {
                    whereClause += " AND JobID = " + Job.JobID + "";
                }

                if (chkEngineerNotReceived.Checked)
                {
                    whereClause += " AND PartsNotReceived = 1 ";
                }

                var switchExpr = Combo.get_GetSelectedItemValue(cboType);
                switch (switchExpr)
                {
                    case var @case when @case == 0.ToString():
                        {
                            break;
                        }

                    case var case1 when case1 == 1.ToString():
                        {
                            whereClause += " AND OrderTypeID = 1" + "";
                            break;
                        }

                    case var case2 when case2 == 2.ToString():
                        {
                            whereClause += " AND OrderTypeID = 1" + "";
                            break;
                        }

                    case var case3 when case3 == 3.ToString():
                        {
                            whereClause += " AND OrderTypeID = 2" + "";
                            break;
                        }

                    case var case4 when case4 == 4.ToString():
                        {
                            whereClause += " AND OrderTypeID = 3" + "";
                            break;
                        }

                    case var case5 when case5 == 5.ToString():
                        {
                            whereClause += " AND OrderTypeID = 4" + "";
                            break;
                        }
                }

                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0))
                {
                    whereClause += " AND DisplayStatusID = " + Combo.get_GetSelectedItemValue(cboStatus) + "";
                }

                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSupplier)) == 0))
                {
                    whereClause += " AND SupplierID = " + Combo.get_GetSelectedItemValue(cboSupplier) + "";
                }

                if (!((Combo.get_GetSelectedItemValue(cboSupplierInvoiceSent) ?? "") == "0"))
                {
                    whereClause += " AND SupplierExported = '" + Combo.get_GetSelectedItemDescription(cboSupplierInvoiceSent) + "'";
                }

                if (!(txtOrderRef.Text.Trim().Length == 0))
                {
                    whereClause += " AND OrderReference LIKE '%" + txtOrderRef.Text.Trim() + "%'";
                }

                if (!(txtConsolidationRef.Text.Trim().Length == 0))
                {
                    whereClause += " AND ConsolidationRef LIKE '%" + txtConsolidationRef.Text.Trim() + "%'";
                }

                if (chkDateCreated.Checked)
                {
                    whereClause += " AND DatePlaced >= '" + Strings.Format(dtpFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND DatePlaced <= '" + Strings.Format(dtpTo.Value, "dd/MM/yyyy 23:59:59") + "'";
                }

                if (chkDeliveryDeadline.Checked)
                {
                    whereClause += " AND DeliveryDeadline >= '" + Strings.Format(dtpDeliveryDeadlineFrom.Value, "dd/MM/yyyy 00:00:00") + "' AND DeliveryDeadline <= '" + Strings.Format(dtpDeliveryDeadlineTo.Value, "dd/MM/yyyy 23:59:59") + "'";
                }

                if (chkOutstanding.Checked)
                {
                    whereClause += " AND CONVERT(NUMERIC(10,2),SupplierInvoiceAmount) <= CONVERT(NUMERIC(10,2),BuyPrice) ";
                }

                OrdersDataview.RowFilter = whereClause;
                grpJobs.Text = string.Format("Results ({0}) - Double Click To View / Edit", OrdersDataview.Count);
            }
        }

        public void Export()
        {
            var exportData = new DataTable();
            exportData.Columns.Add("DatePlaced");
            exportData.Columns.Add("DeliveryDeadline");
            exportData.Columns.Add("OrderReference");
            exportData.Columns.Add("ConsolidationRef");
            exportData.Columns.Add("Type");
            exportData.Columns.Add("Customer");
            exportData.Columns.Add("Property");
            exportData.Columns.Add("Supplier");
            exportData.Columns.Add("Van");
            exportData.Columns.Add("Warehouse");
            exportData.Columns.Add("JobNumber");
            exportData.Columns.Add("Status");
            exportData.Columns.Add("Supplier Invoice Sent To Sage");
            exportData.Columns.Add("BuyPrice", typeof(decimal));
            exportData.Columns.Add("SellPrice", typeof(decimal));
            exportData.Columns.Add("CreatedBy");
            exportData.Columns.Add("DepartmentRef");
            Enums.SecuritySystemModules ssm;
            ssm = Enums.SecuritySystemModules.IT;
            if (App.loggedInUser.HasAccessToModule(ssm) == true)
            {
                exportData.Columns.Add("OrderID");
            }

            foreach (DataRowView dr in (DataView)dgOrders.DataSource)
            {
                var newRw = exportData.NewRow();
                newRw["DatePlaced"] = dr["DatePlaced"];
                newRw["DeliveryDeadline"] = dr["DeliveryDeadline"];
                newRw["OrderReference"] = dr["OrderReference"];
                newRw["ConsolidationRef"] = dr["ConsolidationRef"];
                newRw["Type"] = dr["Type"];
                newRw["Customer"] = dr["Customer"];
                newRw["Property"] = dr["Site"];
                newRw["Supplier"] = dr["Supplier"];
                newRw["Van"] = dr["Registration"];
                newRw["Warehouse"] = dr["Warehouse"];
                newRw["JobNumber"] = dr["JobNumber"];
                newRw["Status"] = dr["DisplayStatus"];
                newRw["Supplier Invoice Sent To Sage"] = dr["SupplierExported"];
                newRw["BuyPrice"] = dr["BuyPrice"];
                newRw["SellPrice"] = dr["SellPrice"];
                newRw["CreatedBy"] = dr["CreatedBy"];
                newRw["DepartmentRef"] = dr["DepartmentRef"];
                if (App.loggedInUser.HasAccessToModule(ssm) == true)
                {
                    newRw["OrderID"] = dr["OrderID"];
                }

                exportData.Rows.Add(newRw);
            }

            ExportHelper.Export(exportData, "Order List", Enums.ExportType.XLS);
        }

        private void btnFilterResults_Click(object sender, EventArgs e)
        {
            Query();
        }

        public void Query()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int OrderSiteID = 0;
                if (theSite is object)
                {
                    OrderSiteID = theSite.SiteID;
                }

                int OrderVanID = 0;
                if (Van is object)
                {
                    OrderVanID = Van.VanID;
                }

                int OrderWarehouseID = 0;
                if (Warehouse is object)
                {
                    OrderWarehouseID = Warehouse.WarehouseID;
                }

                int OrderJobID = 0;
                if (Job is object)
                {
                    OrderJobID = Job.JobID;
                }

                int OrderTypeID = 0;
                var switchExpr = Combo.get_GetSelectedItemValue(cboType);
                switch (switchExpr)
                {
                    case var @case when @case == 0.ToString():
                        {
                            break;
                        }

                    case var case1 when case1 == 1.ToString():
                        {
                            OrderTypeID = 1;
                            break;
                        }

                    case var case2 when case2 == 2.ToString():
                        {
                            OrderTypeID = 1;
                            break;
                        }

                    case var case3 when case3 == 3.ToString():
                        {
                            OrderTypeID = 2;
                            break;
                        }

                    case var case4 when case4 == 4.ToString():
                        {
                            OrderTypeID = 3;
                            break;
                        }

                    case var case5 when case5 == 5.ToString():
                        {
                            OrderTypeID = 4;
                            break;
                        }
                }

                int PartsNotReceived = default;
                if (chkEngineerNotReceived.Checked)
                {
                    PartsNotReceived = 1;
                }
                else
                {
                    PartsNotReceived = 0;
                }

                int OrderSupplierID = 0;
                if (!((Combo.get_GetSelectedItemValue(cboSupplier) ?? "") == "0"))
                {
                    OrderSupplierID = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboSupplier));
                }

                int OrderSupplierExported = 0;
                if ((Combo.get_GetSelectedItemValue(cboSupplierInvoiceSent) ?? "") == "0")
                {
                    OrderSupplierExported = 0;
                }
                else if ((Combo.get_GetSelectedItemValue(cboSupplierInvoiceSent) ?? "") == "Yes")
                {
                    OrderSupplierExported = 1;
                }
                else
                {
                    OrderSupplierExported = 2;
                }

                string OrderReference = null;
                if (string.IsNullOrEmpty(txtOrderRef.Text.Trim()))
                {
                    OrderReference = "%";
                }
                else
                {
                    OrderReference = "%" + txtOrderRef.Text.Trim() + "%";
                }

                string OrderConsolidationRef = null;
                if (string.IsNullOrEmpty(txtConsolidationRef.Text.Trim()))
                {
                    OrderConsolidationRef = "%%";
                }
                else
                {
                    OrderConsolidationRef = "%" + txtConsolidationRef.Text.Trim() + "%";
                }

                DateTime? OrderDatePlacedFrom = default;
                DateTime? OrderDatePlacedTo = default;
                if (chkDateCreated.Checked)
                {
                    OrderDatePlacedFrom = (DateTime?)dtpFrom.Value;
                    OrderDatePlacedTo = (DateTime?)dtpTo.Value;
                }

                DateTime? OrderDeliveryDeadlineFrom = default;
                DateTime? OrderDeliveryDeadlineTo = default;
                if (chkDeliveryDeadline.Checked)
                {
                    OrderDeliveryDeadlineFrom = (DateTime?)dtpDeliveryDeadlineFrom.Value;
                    OrderDeliveryDeadlineTo = (DateTime?)dtpDeliveryDeadlineTo.Value;
                }

                int OrderStatus = 0;
                if (!(Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboStatus)) == 0))
                {
                    OrderStatus = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboStatus));
                }

                string OrderContains = null;
                if (string.IsNullOrEmpty(txtContains.Text.Trim()))
                {
                    OrderContains = "";
                }
                else
                {
                    OrderContains = txtContains.Text.Trim();
                }

                string OrderDepartment = "%%";
                string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDepartment));
                if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= 0))
                {
                    OrderDepartment = department;
                }
                else if (!Information.IsNumeric(department))
                {
                    OrderDepartment = department;
                }

                OrdersDataview = App.DB.Order.Order_GetAll_NEW(OrderContains, OrderSiteID, OrderVanID, OrderWarehouseID, OrderJobID, OrderTypeID, OrderReference, OrderConsolidationRef, OrderStatus, PartsNotReceived, OrderSupplierExported, OrderSupplierID, OrderDatePlacedFrom, OrderDatePlacedTo, OrderDeliveryDeadlineFrom, OrderDeliveryDeadlineTo, OrderDepartment);
                if (chkOutstanding.Checked)
                {
                    OrdersDataview.RowFilter = "Isnull(SupplierInvoiceAmount,0) < BuyPrice";
                }

                grpJobs.Text = string.Format("Results ({0}) - Double Click To View / Edit", OrdersDataview.Count);
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void txtOrderRef_TextChanged(object sender, EventArgs e)
        {
        }

        private void chkOutstanding_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}