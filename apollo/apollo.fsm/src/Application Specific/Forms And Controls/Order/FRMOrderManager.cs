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

            base.Load += FRMOrderManager_Load;
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

        private Label _Label9;

        private Label _Label8;

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

        private Label _Label12;

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
            this._grpJobs = new System.Windows.Forms.GroupBox();
            this._dgOrders = new System.Windows.Forms.DataGrid();
            this._btnExport = new System.Windows.Forms.Button();
            this._grpFilter = new System.Windows.Forms.GroupBox();
            this._chkOutstanding = new System.Windows.Forms.CheckBox();
            this._Label12 = new System.Windows.Forms.Label();
            this._cboDepartment = new System.Windows.Forms.ComboBox();
            this._btnFilterResults = new System.Windows.Forms.Button();
            this._chkEngineerNotReceived = new System.Windows.Forms.CheckBox();
            this._txtContains = new System.Windows.Forms.TextBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._txtConsolidationRef = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._Label5 = new System.Windows.Forms.Label();
            this._cboSupplierInvoiceSent = new System.Windows.Forms.ComboBox();
            this._dtpDeliveryDeadlineTo = new System.Windows.Forms.DateTimePicker();
            this._dtpDeliveryDeadlineFrom = new System.Windows.Forms.DateTimePicker();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._cboSupplier = new System.Windows.Forms.ComboBox();
            this._Label1 = new System.Windows.Forms.Label();
            this._btnFindRecord = new System.Windows.Forms.Button();
            this._txtSearch = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._dtpTo = new System.Windows.Forms.DateTimePicker();
            this._dtpFrom = new System.Windows.Forms.DateTimePicker();
            this._txtOrderRef = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._chkDateCreated = new System.Windows.Forms.CheckBox();
            this._lblSearch = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._Label11 = new System.Windows.Forms.Label();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._chkDeliveryDeadline = new System.Windows.Forms.CheckBox();
            this._btnReset = new System.Windows.Forms.Button();
            this._grpJobs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgOrders)).BeginInit();
            this._grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpJobs
            // 
            this._grpJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpJobs.Controls.Add(this._dgOrders);
            this._grpJobs.Location = new System.Drawing.Point(8, 294);
            this._grpJobs.Name = "_grpJobs";
            this._grpJobs.Size = new System.Drawing.Size(1360, 287);
            this._grpJobs.TabIndex = 1;
            this._grpJobs.TabStop = false;
            this._grpJobs.Text = "Results (awaiting search) - Double Click To View / Edit";
            // 
            // _dgOrders
            // 
            this._dgOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgOrders.DataMember = "";
            this._dgOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgOrders.Location = new System.Drawing.Point(8, 30);
            this._dgOrders.Name = "_dgOrders";
            this._dgOrders.Size = new System.Drawing.Size(1344, 249);
            this._dgOrders.TabIndex = 11;
            this._dgOrders.DoubleClick += new System.EventHandler(this.dgOrders_DoubleClick);
            // 
            // _btnExport
            // 
            this._btnExport.AccessibleDescription = "Export Job List To Excel";
            this._btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExport.Location = new System.Drawing.Point(8, 589);
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
            this._grpFilter.Controls.Add(this._chkOutstanding);
            this._grpFilter.Controls.Add(this._Label12);
            this._grpFilter.Controls.Add(this._cboDepartment);
            this._grpFilter.Controls.Add(this._btnFilterResults);
            this._grpFilter.Controls.Add(this._chkEngineerNotReceived);
            this._grpFilter.Controls.Add(this._txtContains);
            this._grpFilter.Controls.Add(this._Label7);
            this._grpFilter.Controls.Add(this._txtConsolidationRef);
            this._grpFilter.Controls.Add(this._Label6);
            this._grpFilter.Controls.Add(this._Label5);
            this._grpFilter.Controls.Add(this._cboSupplierInvoiceSent);
            this._grpFilter.Controls.Add(this._dtpDeliveryDeadlineTo);
            this._grpFilter.Controls.Add(this._dtpDeliveryDeadlineFrom);
            this._grpFilter.Controls.Add(this._Label2);
            this._grpFilter.Controls.Add(this._Label3);
            this._grpFilter.Controls.Add(this._cboSupplier);
            this._grpFilter.Controls.Add(this._Label1);
            this._grpFilter.Controls.Add(this._btnFindRecord);
            this._grpFilter.Controls.Add(this._txtSearch);
            this._grpFilter.Controls.Add(this._Label4);
            this._grpFilter.Controls.Add(this._dtpTo);
            this._grpFilter.Controls.Add(this._dtpFrom);
            this._grpFilter.Controls.Add(this._txtOrderRef);
            this._grpFilter.Controls.Add(this._Label9);
            this._grpFilter.Controls.Add(this._Label8);
            this._grpFilter.Controls.Add(this._chkDateCreated);
            this._grpFilter.Controls.Add(this._lblSearch);
            this._grpFilter.Controls.Add(this._Label10);
            this._grpFilter.Controls.Add(this._cboType);
            this._grpFilter.Controls.Add(this._Label11);
            this._grpFilter.Controls.Add(this._cboStatus);
            this._grpFilter.Controls.Add(this._chkDeliveryDeadline);
            this._grpFilter.Location = new System.Drawing.Point(8, 13);
            this._grpFilter.Name = "_grpFilter";
            this._grpFilter.Size = new System.Drawing.Size(1360, 275);
            this._grpFilter.TabIndex = 0;
            this._grpFilter.TabStop = false;
            this._grpFilter.Text = "Filter";
            // 
            // _chkOutstanding
            // 
            this._chkOutstanding.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkOutstanding.Location = new System.Drawing.Point(420, 122);
            this._chkOutstanding.Name = "_chkOutstanding";
            this._chkOutstanding.Size = new System.Drawing.Size(221, 24);
            this._chkOutstanding.TabIndex = 34;
            this._chkOutstanding.Text = "PO not reconciled (outstanding)";
            this._chkOutstanding.UseVisualStyleBackColor = true;
            this._chkOutstanding.CheckedChanged += new System.EventHandler(this.chkOutstanding_CheckedChanged);
            // 
            // _Label12
            // 
            this._Label12.Location = new System.Drawing.Point(13, 249);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(117, 20);
            this._Label12.TabIndex = 33;
            this._Label12.Text = "Cost Centre";
            // 
            // _cboDepartment
            // 
            this._cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDepartment.Location = new System.Drawing.Point(136, 247);
            this._cboDepartment.Name = "_cboDepartment";
            this._cboDepartment.Size = new System.Drawing.Size(142, 21);
            this._cboDepartment.TabIndex = 32;
            // 
            // _btnFilterResults
            // 
            this._btnFilterResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFilterResults.Location = new System.Drawing.Point(1243, 244);
            this._btnFilterResults.Name = "_btnFilterResults";
            this._btnFilterResults.Size = new System.Drawing.Size(109, 23);
            this._btnFilterResults.TabIndex = 31;
            this._btnFilterResults.Text = "Filter Results";
            this._btnFilterResults.UseVisualStyleBackColor = true;
            this._btnFilterResults.Click += new System.EventHandler(this.btnFilterResults_Click);
            // 
            // _chkEngineerNotReceived
            // 
            this._chkEngineerNotReceived.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkEngineerNotReceived.Location = new System.Drawing.Point(289, 123);
            this._chkEngineerNotReceived.Name = "_chkEngineerNotReceived";
            this._chkEngineerNotReceived.Size = new System.Drawing.Size(141, 24);
            this._chkEngineerNotReceived.TabIndex = 7;
            this._chkEngineerNotReceived.Text = "Eng Not Received";
            this._chkEngineerNotReceived.UseVisualStyleBackColor = true;
            this._chkEngineerNotReceived.CheckedChanged += new System.EventHandler(this.chkEngineerNotReceived_CheckedChanged);
            // 
            // _txtContains
            // 
            this._txtContains.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtContains.Location = new System.Drawing.Point(624, 92);
            this._txtContains.MaxLength = 100;
            this._txtContains.Name = "_txtContains";
            this._txtContains.Size = new System.Drawing.Size(727, 21);
            this._txtContains.TabIndex = 5;
            this._txtContains.TextChanged += new System.EventHandler(this.txtContains_TextChanged);
            // 
            // _Label7
            // 
            this._Label7.Location = new System.Drawing.Point(523, 92);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(118, 23);
            this._Label7.TabIndex = 30;
            this._Label7.Text = "Order Contains";
            // 
            // _txtConsolidationRef
            // 
            this._txtConsolidationRef.Location = new System.Drawing.Point(395, 92);
            this._txtConsolidationRef.Name = "_txtConsolidationRef";
            this._txtConsolidationRef.Size = new System.Drawing.Size(122, 21);
            this._txtConsolidationRef.TabIndex = 4;
            this._txtConsolidationRef.TextChanged += new System.EventHandler(this.txtConsolidationRef_TextChanged);
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(284, 95);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(124, 20);
            this._Label6.TabIndex = 28;
            this._Label6.Text = "Consolidation Ref";
            // 
            // _Label5
            // 
            this._Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Label5.Location = new System.Drawing.Point(974, 123);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(266, 23);
            this._Label5.TabIndex = 27;
            this._Label5.Text = "Supplier Invoice Sent to Accounts Package";
            // 
            // _cboSupplierInvoiceSent
            // 
            this._cboSupplierInvoiceSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cboSupplierInvoiceSent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboSupplierInvoiceSent.Location = new System.Drawing.Point(1242, 121);
            this._cboSupplierInvoiceSent.Name = "_cboSupplierInvoiceSent";
            this._cboSupplierInvoiceSent.Size = new System.Drawing.Size(110, 21);
            this._cboSupplierInvoiceSent.TabIndex = 8;
            // 
            // _dtpDeliveryDeadlineTo
            // 
            this._dtpDeliveryDeadlineTo.Location = new System.Drawing.Point(596, 216);
            this._dtpDeliveryDeadlineTo.Name = "_dtpDeliveryDeadlineTo";
            this._dtpDeliveryDeadlineTo.Size = new System.Drawing.Size(224, 21);
            this._dtpDeliveryDeadlineTo.TabIndex = 15;
            this._dtpDeliveryDeadlineTo.ValueChanged += new System.EventHandler(this.dtpDeliveryDeadlineTo_ValueChanged);
            // 
            // _dtpDeliveryDeadlineFrom
            // 
            this._dtpDeliveryDeadlineFrom.Location = new System.Drawing.Point(596, 184);
            this._dtpDeliveryDeadlineFrom.Name = "_dtpDeliveryDeadlineFrom";
            this._dtpDeliveryDeadlineFrom.Size = new System.Drawing.Size(224, 21);
            this._dtpDeliveryDeadlineFrom.TabIndex = 14;
            this._dtpDeliveryDeadlineFrom.ValueChanged += new System.EventHandler(this.dtpDeliveryDeadlineFrom_ValueChanged);
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(548, 216);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(48, 16);
            this._Label2.TabIndex = 24;
            this._Label2.Text = "To";
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(548, 184);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(48, 16);
            this._Label3.TabIndex = 21;
            this._Label3.Text = "From";
            // 
            // _cboSupplier
            // 
            this._cboSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboSupplier.Location = new System.Drawing.Point(136, 152);
            this._cboSupplier.Name = "_cboSupplier";
            this._cboSupplier.Size = new System.Drawing.Size(1216, 21);
            this._cboSupplier.TabIndex = 9;
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(16, 152);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(100, 23);
            this._Label1.TabIndex = 18;
            this._Label1.Text = "Supplier";
            // 
            // _btnFindRecord
            // 
            this._btnFindRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFindRecord.BackColor = System.Drawing.Color.White;
            this._btnFindRecord.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnFindRecord.Location = new System.Drawing.Point(1320, 58);
            this._btnFindRecord.Name = "_btnFindRecord";
            this._btnFindRecord.Size = new System.Drawing.Size(32, 23);
            this._btnFindRecord.TabIndex = 2;
            this._btnFindRecord.Text = "...";
            this._btnFindRecord.UseVisualStyleBackColor = false;
            this._btnFindRecord.Click += new System.EventHandler(this.btnFindRecord_Click);
            // 
            // _txtSearch
            // 
            this._txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtSearch.Location = new System.Drawing.Point(136, 60);
            this._txtSearch.Name = "_txtSearch";
            this._txtSearch.ReadOnly = true;
            this._txtSearch.Size = new System.Drawing.Size(1176, 21);
            this._txtSearch.TabIndex = 1;
            // 
            // _Label4
            // 
            this._Label4.Location = new System.Drawing.Point(16, 89);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(72, 20);
            this._Label4.TabIndex = 15;
            this._Label4.Text = "Order Ref";
            // 
            // _dtpTo
            // 
            this._dtpTo.Location = new System.Drawing.Point(183, 216);
            this._dtpTo.Name = "_dtpTo";
            this._dtpTo.Size = new System.Drawing.Size(224, 21);
            this._dtpTo.TabIndex = 12;
            this._dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // _dtpFrom
            // 
            this._dtpFrom.Location = new System.Drawing.Point(183, 184);
            this._dtpFrom.Name = "_dtpFrom";
            this._dtpFrom.Size = new System.Drawing.Size(224, 21);
            this._dtpFrom.TabIndex = 11;
            this._dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // _txtOrderRef
            // 
            this._txtOrderRef.Location = new System.Drawing.Point(136, 92);
            this._txtOrderRef.Name = "_txtOrderRef";
            this._txtOrderRef.Size = new System.Drawing.Size(142, 21);
            this._txtOrderRef.TabIndex = 3;
            this._txtOrderRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrderRef_TextChanged);
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(135, 216);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(48, 16);
            this._Label9.TabIndex = 10;
            this._Label9.Text = "To";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(135, 184);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(48, 16);
            this._Label8.TabIndex = 9;
            this._Label8.Text = "From";
            // 
            // _chkDateCreated
            // 
            this._chkDateCreated.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkDateCreated.Location = new System.Drawing.Point(16, 184);
            this._chkDateCreated.Name = "_chkDateCreated";
            this._chkDateCreated.Size = new System.Drawing.Size(104, 24);
            this._chkDateCreated.TabIndex = 10;
            this._chkDateCreated.Text = "Date Placed";
            this._chkDateCreated.UseVisualStyleBackColor = true;
            this._chkDateCreated.CheckedChanged += new System.EventHandler(this.chkDateCreated_CheckedChanged);
            // 
            // _lblSearch
            // 
            this._lblSearch.Location = new System.Drawing.Point(16, 56);
            this._lblSearch.Name = "_lblSearch";
            this._lblSearch.Size = new System.Drawing.Size(112, 20);
            this._lblSearch.TabIndex = 2;
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(16, 32);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(48, 20);
            this._Label10.TabIndex = 4;
            this._Label10.Text = "Type";
            // 
            // _cboType
            // 
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(136, 29);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(1216, 21);
            this._cboType.TabIndex = 0;
            // 
            // _Label11
            // 
            this._Label11.Location = new System.Drawing.Point(16, 121);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(48, 20);
            this._Label11.TabIndex = 5;
            this._Label11.Text = "Status";
            // 
            // _cboStatus
            // 
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.Location = new System.Drawing.Point(136, 124);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(142, 21);
            this._cboStatus.TabIndex = 6;
            // 
            // _chkDeliveryDeadline
            // 
            this._chkDeliveryDeadline.Cursor = System.Windows.Forms.Cursors.Hand;
            this._chkDeliveryDeadline.Location = new System.Drawing.Point(420, 184);
            this._chkDeliveryDeadline.Name = "_chkDeliveryDeadline";
            this._chkDeliveryDeadline.Size = new System.Drawing.Size(132, 24);
            this._chkDeliveryDeadline.TabIndex = 13;
            this._chkDeliveryDeadline.Text = "Delivery Deadline";
            this._chkDeliveryDeadline.UseVisualStyleBackColor = true;
            this._chkDeliveryDeadline.CheckedChanged += new System.EventHandler(this.chkDeliveryDeadline_CheckedChanged);
            // 
            // _btnReset
            // 
            this._btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnReset.Location = new System.Drawing.Point(72, 589);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(56, 23);
            this._btnReset.TabIndex = 3;
            this._btnReset.Text = "Reset";
            this._btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FRMOrderManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1376, 619);
            this.Controls.Add(this._grpFilter);
            this.Controls.Add(this._btnExport);
            this.Controls.Add(this._grpJobs);
            this.Controls.Add(this._btnReset);
            this.MinimumSize = new System.Drawing.Size(852, 592);
            this.Name = "FRMOrderManager";
            this.Text = "Order Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpJobs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgOrders)).EndInit();
            this._grpFilter.ResumeLayout(false);
            this._grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        public class PartsNotReceivedColourColumn : DataGridLabelColumn
        {
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
        }

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