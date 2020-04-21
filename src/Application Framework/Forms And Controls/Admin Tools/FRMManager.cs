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
    public class FRMManager : FRMBaseForm, IForm
    {
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public FRMManager() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += FRMManager_Load;

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
        private GroupBox _grpItems;

        internal GroupBox grpItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpItems != null)
                {
                }

                _grpItems = value;
                if (_grpItems != null)
                {
                }
            }
        }

        private DataGrid _dgManager;

        internal DataGrid dgManager
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgManager;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgManager != null)
                {
                    _dgManager.Click -= dgManager_Click;
                    _dgManager.CurrentCellChanged -= dgManager_Click;
                }

                _dgManager = value;
                if (_dgManager != null)
                {
                    _dgManager.Click += dgManager_Click;
                    _dgManager.CurrentCellChanged += dgManager_Click;
                }
            }
        }

        private Button _btnAddNew;

        internal Button btnAddNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddNew != null)
                {
                    _btnAddNew.Click -= btnAddNew_Click;
                }

                _btnAddNew = value;
                if (_btnAddNew != null)
                {
                    _btnAddNew.Click += btnAddNew_Click;
                }
            }
        }

        private Button _btnDelete;

        internal Button btnDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDelete != null)
                {
                    _btnDelete.Click -= btnDelete_Click;
                }

                _btnDelete = value;
                if (_btnDelete != null)
                {
                    _btnDelete.Click += btnDelete_Click;
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

        private GroupBox _grpDetails;

        internal GroupBox grpDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDetails != null)
                {
                }

                _grpDetails = value;
                if (_grpDetails != null)
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

        private TextBox _txtName;

        internal TextBox txtName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private TextBox _txtDescription;

        internal TextBox txtDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDescription != null)
                {
                }

                _txtDescription = value;
                if (_txtDescription != null)
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

        private Button _btnSave;

        internal Button btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        private GroupBox _grpSettings;

        internal GroupBox grpSettings
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSettings;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSettings != null)
                {
                }

                _grpSettings = value;
                if (_grpSettings != null)
                {
                }
            }
        }

        private TabControl _tabSystemSettings;

        internal TabControl tabSystemSettings
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabSystemSettings;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabSystemSettings != null)
                {
                }

                _tabSystemSettings = value;
                if (_tabSystemSettings != null)
                {
                }
            }
        }

        private TabPage _tabPrefix;

        internal TabPage tabPrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabPrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabPrefix != null)
                {
                }

                _tabPrefix = value;
                if (_tabPrefix != null)
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

        private TextBox _txtCalloutPrefix;

        internal TextBox txtCalloutPrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCalloutPrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCalloutPrefix != null)
                {
                }

                _txtCalloutPrefix = value;
                if (_txtCalloutPrefix != null)
                {
                }
            }
        }

        private TextBox _txtMiscPrefix;

        internal TextBox txtMiscPrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMiscPrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMiscPrefix != null)
                {
                }

                _txtMiscPrefix = value;
                if (_txtMiscPrefix != null)
                {
                }
            }
        }

        private TextBox _txtPPMPrefix;

        internal TextBox txtPPMPrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPPMPrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPPMPrefix != null)
                {
                }

                _txtPPMPrefix = value;
                if (_txtPPMPrefix != null)
                {
                }
            }
        }

        private TextBox _txtQuotePrefix;

        internal TextBox txtQuotePrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQuotePrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQuotePrefix != null)
                {
                }

                _txtQuotePrefix = value;
                if (_txtQuotePrefix != null)
                {
                }
            }
        }

        private Button _btnSaveSettings;

        internal Button btnSaveSettings
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveSettings;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveSettings != null)
                {
                    _btnSaveSettings.Click -= btnSaveSettings_Click;
                }

                _btnSaveSettings = value;
                if (_btnSaveSettings != null)
                {
                    _btnSaveSettings.Click += btnSaveSettings_Click;
                }
            }
        }

        private TabPage _TabPage1;

        internal TabPage TabPage1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPage1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPage1 != null)
                {
                }

                _TabPage1 = value;
                if (_TabPage1 != null)
                {
                }
            }
        }

        private ComboBox _cboWorkingHoursEnd;

        internal ComboBox cboWorkingHoursEnd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboWorkingHoursEnd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboWorkingHoursEnd != null)
                {
                }

                _cboWorkingHoursEnd = value;
                if (_cboWorkingHoursEnd != null)
                {
                }
            }
        }

        private ComboBox _cboWorkingHoursStart;

        internal ComboBox cboWorkingHoursStart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboWorkingHoursStart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboWorkingHoursStart != null)
                {
                }

                _cboWorkingHoursStart = value;
                if (_cboWorkingHoursStart != null)
                {
                }
            }
        }

        private Label _Label16;

        internal Label Label16
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label16;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label16 != null)
                {
                }

                _Label16 = value;
                if (_Label16 != null)
                {
                }
            }
        }

        private Label _Label15;

        internal Label Label15
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label15;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label15 != null)
                {
                }

                _Label15 = value;
                if (_Label15 != null)
                {
                }
            }
        }

        private Label _lblTimeSlot;

        internal Label lblTimeSlot
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTimeSlot;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTimeSlot != null)
                {
                }

                _lblTimeSlot = value;
                if (_lblTimeSlot != null)
                {
                }
            }
        }

        private Label _Label14;

        internal Label Label14
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label14;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label14 != null)
                {
                }

                _Label14 = value;
                if (_Label14 != null)
                {
                }
            }
        }

        private TextBox _txtRatesMarkup;

        internal TextBox txtRatesMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRatesMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRatesMarkup != null)
                {
                }

                _txtRatesMarkup = value;
                if (_txtRatesMarkup != null)
                {
                }
            }
        }

        private Label _Label13;

        internal Label Label13
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Label13;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Label13 != null)
                {
                }

                _Label13 = value;
                if (_Label13 != null)
                {
                }
            }
        }

        private TextBox _txtPartsMarkup;

        internal TextBox txtPartsMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartsMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartsMarkup != null)
                {
                }

                _txtPartsMarkup = value;
                if (_txtPartsMarkup != null)
                {
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

        private TextBox _txtMileageRate;

        internal TextBox txtMileageRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMileageRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMileageRate != null)
                {
                }

                _txtMileageRate = value;
                if (_txtMileageRate != null)
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

        private TabPage _tabCharges;

        internal TabPage tabCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabCharges != null)
                {
                }

                _tabCharges = value;
                if (_tabCharges != null)
                {
                }
            }
        }

        private TabPage _tabInvoicePrefix;

        internal TabPage tabInvoicePrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabInvoicePrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabInvoicePrefix != null)
                {
                }

                _tabInvoicePrefix = value;
                if (_tabInvoicePrefix != null)
                {
                }
            }
        }

        private TextBox _txtInvoicePrefix;

        internal TextBox txtInvoicePrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvoicePrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvoicePrefix != null)
                {
                }

                _txtInvoicePrefix = value;
                if (_txtInvoicePrefix != null)
                {
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

        private TextBox _txtPercentageRate;

        internal TextBox txtPercentageRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPercentageRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPercentageRate != null)
                {
                }

                _txtPercentageRate = value;
                if (_txtPercentageRate != null)
                {
                }
            }
        }

        private Label _lblPercentageRate;

        internal Label lblPercentageRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPercentageRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPercentageRate != null)
                {
                }

                _lblPercentageRate = value;
                if (_lblPercentageRate != null)
                {
                }
            }
        }

        private TabPage _TabPage2;

        internal TabPage TabPage2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabPage2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabPage2 != null)
                {
                }

                _TabPage2 = value;
                if (_TabPage2 != null)
                {
                }
            }
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private TextBox _txtRecallVariable;

        internal TextBox txtRecallVariable
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRecallVariable;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRecallVariable != null)
                {
                }

                _txtRecallVariable = value;
                if (_txtRecallVariable != null)
                {
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

        private TabPage _tabImportSettings;

        internal TabPage tabImportSettings
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabImportSettings;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabImportSettings != null)
                {
                }

                _tabImportSettings = value;
                if (_tabImportSettings != null)
                {
                }
            }
        }

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _GroupBox2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private TextBox _txtPartsImportMarkup;

        internal TextBox txtPartsImportMarkup
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartsImportMarkup;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartsImportMarkup != null)
                {
                }

                _txtPartsImportMarkup = value;
                if (_txtPartsImportMarkup != null)
                {
                }
            }
        }

        private TextBox _txtServiceFromLetterPrefix;

        internal TextBox txtServiceFromLetterPrefix
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtServiceFromLetterPrefix;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtServiceFromLetterPrefix != null)
                {
                }

                _txtServiceFromLetterPrefix = value;
                if (_txtServiceFromLetterPrefix != null)
                {
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

        private CheckBox _chkMandatory;

        internal CheckBox chkMandatory
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkMandatory;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkMandatory != null)
                {
                }

                _chkMandatory = value;
                if (_chkMandatory != null)
                {
                }
            }
        }

        private ComboBox _cboTimeSlot;

        internal ComboBox cboTimeSlot
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTimeSlot;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTimeSlot != null)
                {
                    _cboTimeSlot.SelectedValueChanged -= cboTimeSlot_SelectedValueChanged;
                }

                _cboTimeSlot = value;
                if (_cboTimeSlot != null)
                {
                    _cboTimeSlot.SelectedValueChanged += cboTimeSlot_SelectedValueChanged;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpItems = new GroupBox();
            _dgManager = new DataGrid();
            _dgManager.Click += new EventHandler(dgManager_Click);
            _dgManager.CurrentCellChanged += new EventHandler(dgManager_Click);
            _dgManager.Click += new EventHandler(dgManager_Click);
            _dgManager.CurrentCellChanged += new EventHandler(dgManager_Click);
            _btnAddNew = new Button();
            _btnAddNew.Click += new EventHandler(btnAddNew_Click);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _Label1 = new Label();
            _cboType = new ComboBox();
            _cboType.SelectedIndexChanged += new EventHandler(cboType_SelectedIndexChanged);
            _grpDetails = new GroupBox();
            _chkMandatory = new CheckBox();
            _txtPercentageRate = new TextBox();
            _lblPercentageRate = new Label();
            _Label3 = new Label();
            _txtName = new TextBox();
            _txtDescription = new TextBox();
            _Label2 = new Label();
            _btnSave = new Button();
            _btnSave.Click += new EventHandler(btnSave_Click);
            _grpSettings = new GroupBox();
            _btnSaveSettings = new Button();
            _btnSaveSettings.Click += new EventHandler(btnSaveSettings_Click);
            _tabSystemSettings = new TabControl();
            _tabImportSettings = new TabPage();
            _GroupBox2 = new GroupBox();
            _txtPartsImportMarkup = new TextBox();
            _tabCharges = new TabPage();
            _txtRatesMarkup = new TextBox();
            _Label13 = new Label();
            _txtPartsMarkup = new TextBox();
            _Label12 = new Label();
            _txtMileageRate = new TextBox();
            _Label4 = new Label();
            _tabPrefix = new TabPage();
            _txtServiceFromLetterPrefix = new TextBox();
            _Label7 = new Label();
            _txtQuotePrefix = new TextBox();
            _txtPPMPrefix = new TextBox();
            _txtMiscPrefix = new TextBox();
            _txtCalloutPrefix = new TextBox();
            _Label11 = new Label();
            _Label10 = new Label();
            _Label9 = new Label();
            _Label8 = new Label();
            _TabPage1 = new TabPage();
            _cboTimeSlot = new ComboBox();
            _cboTimeSlot.SelectedValueChanged += new EventHandler(cboTimeSlot_SelectedValueChanged);
            _Label14 = new Label();
            _lblTimeSlot = new Label();
            _cboWorkingHoursEnd = new ComboBox();
            _cboWorkingHoursStart = new ComboBox();
            _Label16 = new Label();
            _Label15 = new Label();
            _tabInvoicePrefix = new TabPage();
            _txtInvoicePrefix = new TextBox();
            _Label5 = new Label();
            _TabPage2 = new TabPage();
            _GroupBox1 = new GroupBox();
            _txtRecallVariable = new TextBox();
            _Label6 = new Label();
            _grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgManager).BeginInit();
            _grpDetails.SuspendLayout();
            _grpSettings.SuspendLayout();
            _tabSystemSettings.SuspendLayout();
            _tabImportSettings.SuspendLayout();
            _GroupBox2.SuspendLayout();
            _tabCharges.SuspendLayout();
            _tabPrefix.SuspendLayout();
            _TabPage1.SuspendLayout();
            _tabInvoicePrefix.SuspendLayout();
            _TabPage2.SuspendLayout();
            _GroupBox1.SuspendLayout();
            SuspendLayout();
            //
            // grpItems
            //
            _grpItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpItems.Controls.Add(_dgManager);
            _grpItems.Controls.Add(_btnAddNew);
            _grpItems.Controls.Add(_btnDelete);
            _grpItems.FlatStyle = FlatStyle.System;
            _grpItems.Location = new Point(8, 72);
            _grpItems.Name = "grpItems";
            _grpItems.Size = new Size(368, 416);
            _grpItems.TabIndex = 5;
            _grpItems.TabStop = false;
            _grpItems.Text = "Items";
            //
            // dgManager
            //
            _dgManager.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgManager.DataMember = "";
            _dgManager.HeaderForeColor = SystemColors.ControlText;
            _dgManager.Location = new Point(8, 53);
            _dgManager.Name = "dgManager";
            _dgManager.Size = new Size(352, 355);
            _dgManager.TabIndex = 3;
            //
            // btnAddNew
            //
            _btnAddNew.AccessibleDescription = "Add new item";
            _btnAddNew.Cursor = Cursors.Hand;
            _btnAddNew.Location = new Point(8, 24);
            _btnAddNew.Name = "btnAddNew";
            _btnAddNew.Size = new Size(48, 23);
            _btnAddNew.TabIndex = 2;
            _btnAddNew.Text = "New";
            _btnAddNew.UseVisualStyleBackColor = true;
            //
            // btnDelete
            //
            _btnDelete.AccessibleDescription = "Delete item";
            _btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnDelete.Cursor = Cursors.Hand;
            _btnDelete.Location = new Point(312, 24);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(48, 23);
            _btnDelete.TabIndex = 4;
            _btnDelete.Text = "Delete";
            _btnDelete.UseVisualStyleBackColor = true;
            //
            // Label1
            //
            _Label1.Location = new Point(8, 45);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(72, 23);
            _Label1.TabIndex = 4;
            _Label1.Text = "Select Type";
            //
            // cboType
            //
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.Cursor = Cursors.Hand;
            _cboType.DisplayMember = "Description";
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(88, 45);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(288, 21);
            _cboType.TabIndex = 1;
            _cboType.ValueMember = "Value";
            //
            // grpDetails
            //
            _grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _grpDetails.Controls.Add(_chkMandatory);
            _grpDetails.Controls.Add(_txtPercentageRate);
            _grpDetails.Controls.Add(_lblPercentageRate);
            _grpDetails.Controls.Add(_Label3);
            _grpDetails.Controls.Add(_txtName);
            _grpDetails.Controls.Add(_txtDescription);
            _grpDetails.Controls.Add(_Label2);
            _grpDetails.Controls.Add(_btnSave);
            _grpDetails.FlatStyle = FlatStyle.System;
            _grpDetails.Location = new Point(384, 40);
            _grpDetails.Name = "grpDetails";
            _grpDetails.Size = new Size(392, 216);
            _grpDetails.TabIndex = 7;
            _grpDetails.TabStop = false;
            _grpDetails.Text = "Details";
            //
            // chkMandatory
            //
            _chkMandatory.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _chkMandatory.AutoSize = true;
            _chkMandatory.Location = new Point(208, 188);
            _chkMandatory.Name = "chkMandatory";
            _chkMandatory.Size = new Size(86, 17);
            _chkMandatory.TabIndex = 10;
            _chkMandatory.Text = "Mandatory";
            _chkMandatory.TextAlign = ContentAlignment.MiddleRight;
            _chkMandatory.UseVisualStyleBackColor = true;
            //
            // txtPercentageRate
            //
            _txtPercentageRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _txtPercentageRate.Location = new Point(104, 184);
            _txtPercentageRate.MaxLength = 255;
            _txtPercentageRate.Name = "txtPercentageRate";
            _txtPercentageRate.Size = new Size(87, 21);
            _txtPercentageRate.TabIndex = 9;
            _txtPercentageRate.Visible = false;
            //
            // lblPercentageRate
            //
            _lblPercentageRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _lblPercentageRate.Location = new Point(6, 184);
            _lblPercentageRate.Name = "lblPercentageRate";
            _lblPercentageRate.Size = new Size(72, 21);
            _lblPercentageRate.TabIndex = 8;
            _lblPercentageRate.Text = "Rate (%)";
            _lblPercentageRate.Visible = false;
            //
            // Label3
            //
            _Label3.Location = new Point(8, 56);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(72, 23);
            _Label3.TabIndex = 6;
            _Label3.Text = "Description";
            //
            // txtName
            //
            _txtName.Location = new Point(104, 24);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(280, 21);
            _txtName.TabIndex = 5;
            //
            // txtDescription
            //
            _txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            _txtDescription.Location = new Point(104, 56);
            _txtDescription.Multiline = true;
            _txtDescription.Name = "txtDescription";
            _txtDescription.ScrollBars = ScrollBars.Vertical;
            _txtDescription.Size = new Size(280, 120);
            _txtDescription.TabIndex = 6;
            //
            // Label2
            //
            _Label2.Location = new Point(8, 24);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(48, 23);
            _Label2.TabIndex = 5;
            _Label2.Text = "Name";
            //
            // btnSave
            //
            _btnSave.AccessibleDescription = "Save item";
            _btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSave.Cursor = Cursors.Hand;
            _btnSave.ImageIndex = 1;
            _btnSave.Location = new Point(336, 184);
            _btnSave.Name = "btnSave";
            _btnSave.Size = new Size(48, 23);
            _btnSave.TabIndex = 7;
            _btnSave.Text = "Save";
            _btnSave.UseVisualStyleBackColor = true;
            //
            // grpSettings
            //
            _grpSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _grpSettings.Controls.Add(_btnSaveSettings);
            _grpSettings.Controls.Add(_tabSystemSettings);
            _grpSettings.FlatStyle = FlatStyle.System;
            _grpSettings.Location = new Point(384, 256);
            _grpSettings.Name = "grpSettings";
            _grpSettings.Size = new Size(392, 232);
            _grpSettings.TabIndex = 11;
            _grpSettings.TabStop = false;
            _grpSettings.Text = "System Settings";
            //
            // btnSaveSettings
            //
            _btnSaveSettings.AccessibleDescription = "Save system settings";
            _btnSaveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveSettings.Cursor = Cursors.Hand;
            _btnSaveSettings.ImageIndex = 1;
            _btnSaveSettings.Location = new Point(336, 200);
            _btnSaveSettings.Name = "btnSaveSettings";
            _btnSaveSettings.Size = new Size(48, 23);
            _btnSaveSettings.TabIndex = 20;
            _btnSaveSettings.Text = "Save";
            _btnSaveSettings.UseVisualStyleBackColor = true;
            //
            // tabSystemSettings
            //
            _tabSystemSettings.Controls.Add(_tabImportSettings);
            _tabSystemSettings.Controls.Add(_tabCharges);
            _tabSystemSettings.Controls.Add(_tabPrefix);
            _tabSystemSettings.Controls.Add(_TabPage1);
            _tabSystemSettings.Controls.Add(_tabInvoicePrefix);
            _tabSystemSettings.Controls.Add(_TabPage2);
            _tabSystemSettings.Location = new Point(8, 24);
            _tabSystemSettings.Name = "tabSystemSettings";
            _tabSystemSettings.SelectedIndex = 0;
            _tabSystemSettings.Size = new Size(376, 170);
            _tabSystemSettings.TabIndex = 0;
            //
            // tabImportSettings
            //
            _tabImportSettings.Controls.Add(_GroupBox2);
            _tabImportSettings.Location = new Point(4, 22);
            _tabImportSettings.Name = "tabImportSettings";
            _tabImportSettings.Padding = new Padding(3);
            _tabImportSettings.Size = new Size(368, 144);
            _tabImportSettings.TabIndex = 5;
            _tabImportSettings.Text = "Import Settings";
            _tabImportSettings.UseVisualStyleBackColor = true;
            //
            // GroupBox2
            //
            _GroupBox2.Controls.Add(_txtPartsImportMarkup);
            _GroupBox2.Location = new Point(5, -1);
            _GroupBox2.Name = "GroupBox2";
            _GroupBox2.Size = new Size(360, 132);
            _GroupBox2.TabIndex = 0;
            _GroupBox2.TabStop = false;
            _GroupBox2.Text = "Part Import Markup";
            //
            // txtPartsImportMarkup
            //
            _txtPartsImportMarkup.Location = new Point(6, 20);
            _txtPartsImportMarkup.Name = "txtPartsImportMarkup";
            _txtPartsImportMarkup.Size = new Size(119, 21);
            _txtPartsImportMarkup.TabIndex = 0;
            //
            // tabCharges
            //
            _tabCharges.Controls.Add(_txtRatesMarkup);
            _tabCharges.Controls.Add(_Label13);
            _tabCharges.Controls.Add(_txtPartsMarkup);
            _tabCharges.Controls.Add(_Label12);
            _tabCharges.Controls.Add(_txtMileageRate);
            _tabCharges.Controls.Add(_Label4);
            _tabCharges.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _tabCharges.Location = new Point(4, 22);
            _tabCharges.Name = "tabCharges";
            _tabCharges.Size = new Size(368, 144);
            _tabCharges.TabIndex = 0;
            _tabCharges.Text = "Charges";
            _tabCharges.UseVisualStyleBackColor = true;
            //
            // txtRatesMarkup
            //
            _txtRatesMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtRatesMarkup.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtRatesMarkup.Location = new Point(152, 72);
            _txtRatesMarkup.Name = "txtRatesMarkup";
            _txtRatesMarkup.Size = new Size(208, 21);
            _txtRatesMarkup.TabIndex = 5;
            //
            // Label13
            //
            _Label13.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label13.Location = new Point(8, 72);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(144, 23);
            _Label13.TabIndex = 53;
            _Label13.Text = "Rates Markup";
            //
            // txtPartsMarkup
            //
            _txtPartsMarkup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPartsMarkup.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtPartsMarkup.Location = new Point(152, 40);
            _txtPartsMarkup.Name = "txtPartsMarkup";
            _txtPartsMarkup.Size = new Size(208, 21);
            _txtPartsMarkup.TabIndex = 4;
            //
            // Label12
            //
            _Label12.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label12.Location = new Point(8, 40);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(144, 23);
            _Label12.TabIndex = 51;
            _Label12.Text = "Parts Markup";
            //
            // txtMileageRate
            //
            _txtMileageRate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtMileageRate.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _txtMileageRate.Location = new Point(152, 8);
            _txtMileageRate.Name = "txtMileageRate";
            _txtMileageRate.Size = new Size(208, 21);
            _txtMileageRate.TabIndex = 0;
            //
            // Label4
            //
            _Label4.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label4.Location = new Point(8, 8);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(88, 23);
            _Label4.TabIndex = 43;
            _Label4.Text = "Mileage Rate:";
            //
            // tabPrefix
            //
            _tabPrefix.Controls.Add(_txtServiceFromLetterPrefix);
            _tabPrefix.Controls.Add(_Label7);
            _tabPrefix.Controls.Add(_txtQuotePrefix);
            _tabPrefix.Controls.Add(_txtPPMPrefix);
            _tabPrefix.Controls.Add(_txtMiscPrefix);
            _tabPrefix.Controls.Add(_txtCalloutPrefix);
            _tabPrefix.Controls.Add(_Label11);
            _tabPrefix.Controls.Add(_Label10);
            _tabPrefix.Controls.Add(_Label9);
            _tabPrefix.Controls.Add(_Label8);
            _tabPrefix.Location = new Point(4, 22);
            _tabPrefix.Name = "tabPrefix";
            _tabPrefix.Size = new Size(368, 144);
            _tabPrefix.TabIndex = 1;
            _tabPrefix.Text = "Job Prefixes";
            _tabPrefix.UseVisualStyleBackColor = true;
            //
            // txtServiceFromLetterPrefix
            //
            _txtServiceFromLetterPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtServiceFromLetterPrefix.Location = new Point(174, 116);
            _txtServiceFromLetterPrefix.MaxLength = 4;
            _txtServiceFromLetterPrefix.Name = "txtServiceFromLetterPrefix";
            _txtServiceFromLetterPrefix.Size = new Size(186, 21);
            _txtServiceFromLetterPrefix.TabIndex = 18;
            //
            // Label7
            //
            _Label7.Location = new Point(8, 116);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(182, 23);
            _Label7.TabIndex = 17;
            _Label7.Text = "Service From Letter Prefix:";
            //
            // txtQuotePrefix
            //
            _txtQuotePrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtQuotePrefix.Location = new Point(174, 89);
            _txtQuotePrefix.MaxLength = 4;
            _txtQuotePrefix.Name = "txtQuotePrefix";
            _txtQuotePrefix.Size = new Size(186, 21);
            _txtQuotePrefix.TabIndex = 16;
            //
            // txtPPMPrefix
            //
            _txtPPMPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtPPMPrefix.Location = new Point(174, 62);
            _txtPPMPrefix.MaxLength = 4;
            _txtPPMPrefix.Name = "txtPPMPrefix";
            _txtPPMPrefix.Size = new Size(186, 21);
            _txtPPMPrefix.TabIndex = 15;
            //
            // txtMiscPrefix
            //
            _txtMiscPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtMiscPrefix.Location = new Point(174, 35);
            _txtMiscPrefix.MaxLength = 4;
            _txtMiscPrefix.Name = "txtMiscPrefix";
            _txtMiscPrefix.Size = new Size(186, 21);
            _txtMiscPrefix.TabIndex = 14;
            //
            // txtCalloutPrefix
            //
            _txtCalloutPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtCalloutPrefix.Location = new Point(174, 8);
            _txtCalloutPrefix.MaxLength = 4;
            _txtCalloutPrefix.Name = "txtCalloutPrefix";
            _txtCalloutPrefix.Size = new Size(186, 21);
            _txtCalloutPrefix.TabIndex = 13;
            //
            // Label11
            //
            _Label11.Location = new Point(8, 89);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(80, 23);
            _Label11.TabIndex = 3;
            _Label11.Text = "Quote Prefix:";
            //
            // Label10
            //
            _Label10.Location = new Point(8, 62);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(80, 23);
            _Label10.TabIndex = 2;
            _Label10.Text = "PPM Prefix:";
            //
            // Label9
            //
            _Label9.Location = new Point(8, 35);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(136, 23);
            _Label9.TabIndex = 1;
            _Label9.Text = "Miscellaneous Prefix:";
            //
            // Label8
            //
            _Label8.Location = new Point(8, 8);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(96, 23);
            _Label8.TabIndex = 0;
            _Label8.Text = "Callout Prefix:";
            //
            // TabPage1
            //
            _TabPage1.Controls.Add(_cboTimeSlot);
            _TabPage1.Controls.Add(_Label14);
            _TabPage1.Controls.Add(_lblTimeSlot);
            _TabPage1.Controls.Add(_cboWorkingHoursEnd);
            _TabPage1.Controls.Add(_cboWorkingHoursStart);
            _TabPage1.Controls.Add(_Label16);
            _TabPage1.Controls.Add(_Label15);
            _TabPage1.Location = new Point(4, 22);
            _TabPage1.Name = "TabPage1";
            _TabPage1.Size = new Size(368, 144);
            _TabPage1.TabIndex = 2;
            _TabPage1.Text = "Working Day";
            _TabPage1.UseVisualStyleBackColor = true;
            //
            // cboTimeSlot
            //
            _cboTimeSlot.Items.AddRange(new object[] { "15", "30", "45", "60" });
            _cboTimeSlot.Location = new Point(152, 8);
            _cboTimeSlot.Name = "cboTimeSlot";
            _cboTimeSlot.Size = new Size(80, 21);
            _cboTimeSlot.TabIndex = 53;
            //
            // Label14
            //
            _Label14.Location = new Point(240, 8);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(48, 16);
            _Label14.TabIndex = 51;
            _Label14.Text = "Minutes";
            //
            // lblTimeSlot
            //
            _lblTimeSlot.Location = new Point(8, 8);
            _lblTimeSlot.Name = "lblTimeSlot";
            _lblTimeSlot.Size = new Size(128, 23);
            _lblTimeSlot.TabIndex = 47;
            _lblTimeSlot.Text = "Time Slot Duration";
            //
            // cboWorkingHoursEnd
            //
            _cboWorkingHoursEnd.Cursor = Cursors.Hand;
            _cboWorkingHoursEnd.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboWorkingHoursEnd.Location = new Point(152, 72);
            _cboWorkingHoursEnd.Name = "cboWorkingHoursEnd";
            _cboWorkingHoursEnd.Size = new Size(80, 21);
            _cboWorkingHoursEnd.TabIndex = 18;
            //
            // cboWorkingHoursStart
            //
            _cboWorkingHoursStart.Cursor = Cursors.Hand;
            _cboWorkingHoursStart.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboWorkingHoursStart.Location = new Point(152, 40);
            _cboWorkingHoursStart.Name = "cboWorkingHoursStart";
            _cboWorkingHoursStart.Size = new Size(80, 21);
            _cboWorkingHoursStart.TabIndex = 17;
            //
            // Label16
            //
            _Label16.Location = new Point(8, 72);
            _Label16.Name = "Label16";
            _Label16.Size = new Size(120, 16);
            _Label16.TabIndex = 46;
            _Label16.Text = "Working Hours End";
            //
            // Label15
            //
            _Label15.Location = new Point(8, 40);
            _Label15.Name = "Label15";
            _Label15.Size = new Size(128, 23);
            _Label15.TabIndex = 45;
            _Label15.Text = "Working Hours Start";
            //
            // tabInvoicePrefix
            //
            _tabInvoicePrefix.Controls.Add(_txtInvoicePrefix);
            _tabInvoicePrefix.Controls.Add(_Label5);
            _tabInvoicePrefix.Location = new Point(4, 22);
            _tabInvoicePrefix.Name = "tabInvoicePrefix";
            _tabInvoicePrefix.Size = new Size(368, 144);
            _tabInvoicePrefix.TabIndex = 3;
            _tabInvoicePrefix.Text = "Invoice Prefix";
            _tabInvoicePrefix.UseVisualStyleBackColor = true;
            //
            // txtInvoicePrefix
            //
            _txtInvoicePrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtInvoicePrefix.Location = new Point(144, 16);
            _txtInvoicePrefix.MaxLength = 4;
            _txtInvoicePrefix.Name = "txtInvoicePrefix";
            _txtInvoicePrefix.Size = new Size(208, 21);
            _txtInvoicePrefix.TabIndex = 15;
            //
            // Label5
            //
            _Label5.Location = new Point(8, 16);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(96, 23);
            _Label5.TabIndex = 14;
            _Label5.Text = "Invoice Prefix:";
            //
            // TabPage2
            //
            _TabPage2.Controls.Add(_GroupBox1);
            _TabPage2.Location = new Point(4, 22);
            _TabPage2.Name = "TabPage2";
            _TabPage2.Padding = new Padding(3);
            _TabPage2.Size = new Size(368, 144);
            _TabPage2.TabIndex = 4;
            _TabPage2.Text = "Engineers Performance";
            _TabPage2.UseVisualStyleBackColor = true;
            //
            // GroupBox1
            //
            _GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _GroupBox1.Controls.Add(_txtRecallVariable);
            _GroupBox1.Controls.Add(_Label6);
            _GroupBox1.Location = new Point(6, 6);
            _GroupBox1.Name = "GroupBox1";
            _GroupBox1.Size = new Size(359, 132);
            _GroupBox1.TabIndex = 0;
            _GroupBox1.TabStop = false;
            _GroupBox1.Text = "Engineer Performance Report";
            //
            // txtRecallVariable
            //
            _txtRecallVariable.Location = new Point(9, 54);
            _txtRecallVariable.Name = "txtRecallVariable";
            _txtRecallVariable.Size = new Size(100, 21);
            _txtRecallVariable.TabIndex = 1;
            //
            // Label6
            //
            _Label6.Location = new Point(6, 17);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(288, 44);
            _Label6.TabIndex = 0;
            _Label6.Text = "Engineer Performance - No Of Days to see if a recall has been carried out at site" + ".";
            //
            // FRMManager
            //
            AutoScaleBaseSize = new Size(6, 14);
            ClientSize = new Size(784, 494);
            Controls.Add(_grpSettings);
            Controls.Add(_grpDetails);
            Controls.Add(_grpItems);
            Controls.Add(_Label1);
            Controls.Add(_cboType);
            MinimumSize = new Size(792, 528);
            Name = "FRMManager";
            Text = "Picklists / Settings";
            WindowState = FormWindowState.Maximized;
            Controls.SetChildIndex(_cboType, 0);
            Controls.SetChildIndex(_Label1, 0);
            Controls.SetChildIndex(_grpItems, 0);
            Controls.SetChildIndex(_grpDetails, 0);
            Controls.SetChildIndex(_grpSettings, 0);
            _grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgManager).EndInit();
            _grpDetails.ResumeLayout(false);
            _grpDetails.PerformLayout();
            _grpSettings.ResumeLayout(false);
            _tabSystemSettings.ResumeLayout(false);
            _tabImportSettings.ResumeLayout(false);
            _GroupBox2.ResumeLayout(false);
            _GroupBox2.PerformLayout();
            _tabCharges.ResumeLayout(false);
            _tabCharges.PerformLayout();
            _tabPrefix.ResumeLayout(false);
            _tabPrefix.PerformLayout();
            _TabPage1.ResumeLayout(false);
            _tabInvoicePrefix.ResumeLayout(false);
            _tabInvoicePrefix.PerformLayout();
            _TabPage2.ResumeLayout(false);
            _GroupBox1.ResumeLayout(false);
            _GroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupManagerDataGrid();
            Settings = App.DB.Manager.Get();
            var argc = cboType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.PickListTypes().Table, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            cboTimeSlot.SelectedItem = Settings.TimeSlot.ToString();
            var argc1 = cboWorkingHoursStart;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.Times(Conversions.ToInteger(cboTimeSlot.SelectedItem)), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argc2 = cboWorkingHoursEnd;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.Times(Conversions.ToInteger(cboTimeSlot.SelectedItem)), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            PopulateDatagrid(Entity.Sys.Enums.FormState.Load);
            var argcombo = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            var argcombo1 = cboWorkingHoursStart;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Settings.WorkingHoursStart);
            var argcombo2 = cboWorkingHoursEnd;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, Settings.WorkingHoursEnd);
            txtMileageRate.Text = Settings.MileageRate.ToString();
            txtPartsMarkup.Text = Settings.PartsMarkup.ToString();
            txtRatesMarkup.Text = Settings.RatesMarkup.ToString();
            txtCalloutPrefix.Text = Settings.CalloutPrefix;
            txtMiscPrefix.Text = Settings.MiscPrefix;
            txtQuotePrefix.Text = Settings.QuotePrefix;
            txtPPMPrefix.Text = Settings.PPMPrefix;
            txtRecallVariable.Text = Settings.RecallVariable.ToString();
            txtInvoicePrefix.Text = Settings.InvoicePrefix;
            txtPartsImportMarkup.Text = Settings.PartsImportMarkup.ToString();
            txtServiceFromLetterPrefix.Text = Settings.ServiceFromLetterPrefix;
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
        private Entity.Sys.Enums.FormState _pageState;

        private Entity.Sys.Enums.FormState PageState
        {
            get
            {
                return _pageState;
            }

            set
            {
                _pageState = value;
            }
        }

        private DataView _dvManager;

        private DataView ManagerDataview
        {
            get
            {
                return _dvManager;
            }

            set
            {
                _dvManager = value;
                _dvManager.AllowNew = false;
                _dvManager.AllowEdit = false;
                _dvManager.AllowDelete = false;
                _dvManager.Table.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString();
                dgManager.DataSource = ManagerDataview;
            }
        }

        private DataRow SelectedManagerDataRow
        {
            get
            {
                if (!(dgManager.CurrentRowIndex == -1))
                {
                    return ManagerDataview[dgManager.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Management.Settings _settings = null;

        public Entity.Management.Settings Settings
        {
            get
            {
                return _settings;
            }

            set
            {
                _settings = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void SetupManagerDataGrid()
        {
            var tbStyle = dgManager.TableStyles[0];
            var name = new DataGridLabelColumn();
            name.Format = "";
            name.FormatInfo = null;
            name.HeaderText = "Name";
            name.MappingName = "Name";
            name.ReadOnly = true;
            name.Width = 177;
            name.NullText = "";
            tbStyle.GridColumnStyles.Add(name);
            var description = new DataGridLabelColumn();
            description.Format = "";
            description.FormatInfo = null;
            description.HeaderText = "Description";
            description.MappingName = "Description";
            description.ReadOnly = true;
            description.Width = 177;
            description.NullText = "";
            tbStyle.GridColumnStyles.Add(description);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Entity.Sys.Enums.TableNames.tblPickLists.ToString();
            dgManager.TableStyles.Add(tbStyle);
        }

        private void SetUpPageState(Entity.Sys.Enums.FormState state)
        {
            Entity.Sys.Helper.ClearGroupBox(grpDetails);
            switch (state)
            {
                case Entity.Sys.Enums.FormState.Load:
                    {
                        grpDetails.Enabled = false;
                        btnAddNew.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Insert:
                    {
                        grpDetails.Enabled = true;
                        btnAddNew.Enabled = true;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        break;
                    }

                case Entity.Sys.Enums.FormState.Update:
                    {
                        btnAddNew.Enabled = true;
                        grpDetails.Enabled = true;
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        break;
                    }
            }

            PageState = state;
        }

        private void FRMManager_Load(object sender, EventArgs e)
        {
            LoadMe(sender, e);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 0)
            {
                PopulateDatagrid(Entity.Sys.Enums.FormState.Load);
            }
            else
            {
                PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
            }
            // If CInt(Combo.GetSelectedItemValue(Me.cboType)) = CInt(Entity.Sys.Enums.PickListTypes.Engineer_Levels) Then
            // cbxShowOnJob.Visible = True
            // Else
            // cbxShowOnJob.Visible = False

            // End If
        }

        private void dgManager_Click(object sender, EventArgs e)
        {
            try
            {
                SetUpPageState(Entity.Sys.Enums.FormState.Update);
                if (SelectedManagerDataRow is object)
                {
                    if ((Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow["Name"]) ?? "") == "RC - Recall")
                    {
                        App.ShowMessage("This item cannont be edited", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetUpPageState(Entity.Sys.Enums.FormState.Insert);
                        return;
                    }

                    txtName.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow["Name"]);
                    txtDescription.Text = Entity.Sys.Helper.MakeStringValid(SelectedManagerDataRow["Description"]);
                    txtPercentageRate.Text = Conversions.ToDouble(Entity.Sys.Helper.MakeDoubleValid(SelectedManagerDataRow["PercentageRate"])).ToString();
                    chkMandatory.Checked = Entity.Sys.Helper.MakeBooleanValid(SelectedManagerDataRow["Mandatory"]);
                }
                // If (CDbl(Entity.Sys.Helper.MakeDoubleValid(SelectedManagerDataRow("PercentageRate"))) = 0.0) Then
                // cbxShowOnJob.Checked = 0
                // Else
                // cbxShowOnJob.Checked = 1
                // End If
                else if (cboType.SelectedIndex == 0)
                {
                    SetUpPageState(Entity.Sys.Enums.FormState.Load);
                }
                else
                {
                    SetUpPageState(Entity.Sys.Enums.FormState.Insert);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Item data cannot load : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SetUpPageState(Entity.Sys.Enums.FormState.Insert);
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void cboTimeSlot_SelectedValueChanged(object sender, EventArgs e)
        {
            var argc = cboWorkingHoursStart;
            Combo.SetUpCombo(ref argc, DynamicDataTables.Times(Conversions.ToInteger(cboTimeSlot.SelectedItem)), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argc1 = cboWorkingHoursEnd;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.Times(Conversions.ToInteger(cboTimeSlot.SelectedItem)), "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.None);
            var argcombo = cboWorkingHoursStart;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, Settings.WorkingHoursStart);
            if ((Combo.get_GetSelectedItemValue(cboWorkingHoursStart) ?? "") == "0")
            {
                cboWorkingHoursStart.SelectedIndex = 0;
            }

            var argcombo1 = cboWorkingHoursEnd;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, Settings.WorkingHoursEnd);
            if ((Combo.get_GetSelectedItemValue(cboWorkingHoursEnd) ?? "") == "0")
            {
                cboWorkingHoursEnd.SelectedIndex = cboWorkingHoursEnd.Items.Count - 1;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        private void PopulateDatagrid(Entity.Sys.Enums.FormState state)
        {
            try
            {
                lblPercentageRate.Visible = false;
                txtPercentageRate.Visible = false;
                if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == 0)
                {
                    var dt = new DataTable();
                    dt.TableName = Entity.Sys.Enums.TableNames.tblPickLists.ToString();
                    ManagerDataview = new DataView(dt);
                }
                else
                {
                    ManagerDataview = App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)));
                    var switchExpr = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType));
                    switch (switchExpr)
                    {
                        case (int)(Entity.Sys.Enums.PickListTypes.VATCodes):
                        case (int)(Entity.Sys.Enums.PickListTypes.PartCategories):
                        case (int)(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts):
                            {
                                lblPercentageRate.Text = "Perc Rate";
                                lblPercentageRate.Visible = true;
                                txtPercentageRate.Visible = true;
                                break;
                            }

                        case (int)(Entity.Sys.Enums.PickListTypes.Engineer_Levels):
                            {
                                lblPercentageRate.Text = "Rate";
                                lblPercentageRate.Visible = true;
                                txtPercentageRate.Visible = true;
                                break;
                            }
                    }
                }

                SetUpPageState(state);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            try
            {
                Settings.IgnoreExceptionsOnSetMethods = true;
                Settings.SetWorkingHoursStart = Combo.get_GetSelectedItemValue(cboWorkingHoursStart);
                Settings.SetWorkingHoursEnd = Combo.get_GetSelectedItemValue(cboWorkingHoursEnd);
                Settings.SetMileageRate = txtMileageRate.Text.Trim();
                Settings.SetPartsMarkup = txtPartsMarkup.Text.Trim();
                Settings.SetRatesMarkup = txtRatesMarkup.Text.Trim();
                Settings.SetCalloutPrefix = txtCalloutPrefix.Text.Trim();
                Settings.SetMiscPrefix = txtMiscPrefix.Text.Trim();
                Settings.SetPPMPrefix = txtPPMPrefix.Text.Trim();
                Settings.SetQuotePrefix = txtQuotePrefix.Text.Trim();
                Settings.SetTimeSlot = cboTimeSlot.SelectedItem;
                Settings.SetInvoicePrefix = txtInvoicePrefix.Text.Trim();
                Settings.SetRecallVariable = txtRecallVariable.Text.Trim();
                Settings.SetPartsImportMarkup = txtPartsImportMarkup.Text.Trim();
                Settings.SetServiceFromLetterPrefix = txtServiceFromLetterPrefix.Text.Trim();
                var sV = new Entity.Management.SettingsValidator();
                sV.Validate(Settings);
                App.DB.Manager.UpdateSettings(Settings);

                // UPDATE ALL CUSTOMERS WHO ACCEPT CHANGES
                App.DB.CustomerCharge.UpdateALL(Settings.MileageRate, Settings.PartsMarkup, Settings.RatesMarkup);
                App.ShowMessage("Settings updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error Saving : " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save()
        {
            var picklist = new Entity.PickLists.PickList();
            picklist.IgnoreExceptionsOnSetMethods = true;
            picklist.SetName = txtName.Text.Trim();
            picklist.SetDescription = txtDescription.Text.Trim();
            picklist.SetEnumTypeID = Combo.get_GetSelectedItemValue(cboType);
            picklist.SetMandatory = chkMandatory.Checked;
            var switchExpr = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType));
            switch (switchExpr)
            {
                case (int)(Entity.Sys.Enums.PickListTypes.VATCodes):
                case (int)(Entity.Sys.Enums.PickListTypes.PartCategories):
                case (int)(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts):
                    {
                        picklist.SetPercentageRate = txtPercentageRate.Text.Trim();
                        break;
                    }

                default:
                    {
                        picklist.SetPercentageRate = 0.0;
                        if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.Engineer_Levels))
                        {
                            picklist.SetPercentageRate = txtPercentageRate.Text.Trim();
                        }

                        break;
                    }
            }

            if (PageState == Entity.Sys.Enums.FormState.Update)
            {
                picklist.SetManagerID = SelectedManagerDataRow["ManagerID"];
            }

            var validator = new Entity.PickLists.PickListValidator();
            try
            {
                validator.Validate(picklist);
                var switchExpr1 = PageState;
                switch (switchExpr1)
                {
                    case Entity.Sys.Enums.FormState.Insert:
                        {
                            App.DB.Picklists.Insert(picklist);
                            break;
                        }

                    case Entity.Sys.Enums.FormState.Update:
                        {
                            App.DB.Picklists.Update(picklist);
                            if (Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType)) == Conversions.ToInteger(Entity.Sys.Enums.PickListTypes.PartCategories))
                                App.DB.Picklists.UpdateSellPrices(picklist);
                            break;
                        }
                }

                PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
            }
            catch (ValidationException ex)
            {
                App.ShowMessage(validator.CriticalMessagesString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error Saving : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                if (SelectedManagerDataRow is object)
                {
                    if ((int)App.ShowMessage(Conversions.ToString("Are you sure you want to delete \"" + SelectedManagerDataRow["Name"] + "\" from \"" + Combo.get_GetSelectedItemDescription(cboType) + "\"?"), MessageBoxButtons.YesNo, (MessageBoxIcon)MsgBoxStyle.Question) == (int)MsgBoxResult.Yes)
                    {
                        if ((Entity.Sys.Enums.PickListTypes)Conversions.ToInteger(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboType))) == Entity.Sys.Enums.PickListTypes.Regions)
                        {
                            var dv = App.DB.Picklists.Region_Usage(Conversions.ToInteger(SelectedManagerDataRow["ManagerID"]));
                            if (dv.Table.Rows.Count > 0)
                            {
                                string str = "The region you are trying to delete is still allocated to the following records:" + Constants.vbCrLf;
                                foreach (DataRow dr in dv.Table.Rows)
                                    str += Conversions.ToString("* " + dr["type"] + " - ") + dr["Name"] + Constants.vbCrLf;
                                MessageBox.Show(str, "Region Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        App.DB.Picklists.Delete(Conversions.ToInteger(SelectedManagerDataRow["ManagerID"]));
                        PopulateDatagrid(Entity.Sys.Enums.FormState.Insert);
                    }
                }
                else
                {
                    App.ShowMessage("Please select an item to delete.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error deleting : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}