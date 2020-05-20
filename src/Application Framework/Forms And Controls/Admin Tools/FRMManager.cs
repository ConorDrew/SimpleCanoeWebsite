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
        

        public FRMManager() : base()
        {
            
            
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
            this._grpItems = new System.Windows.Forms.GroupBox();
            this._dgManager = new System.Windows.Forms.DataGrid();
            this._btnAddNew = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this._Label1 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._grpDetails = new System.Windows.Forms.GroupBox();
            this._chkMandatory = new System.Windows.Forms.CheckBox();
            this._txtPercentageRate = new System.Windows.Forms.TextBox();
            this._lblPercentageRate = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._btnSave = new System.Windows.Forms.Button();
            this._grpSettings = new System.Windows.Forms.GroupBox();
            this._btnSaveSettings = new System.Windows.Forms.Button();
            this._tabSystemSettings = new System.Windows.Forms.TabControl();
            this._tabImportSettings = new System.Windows.Forms.TabPage();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._txtPartsImportMarkup = new System.Windows.Forms.TextBox();
            this._tabCharges = new System.Windows.Forms.TabPage();
            this._txtRatesMarkup = new System.Windows.Forms.TextBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._txtPartsMarkup = new System.Windows.Forms.TextBox();
            this._Label12 = new System.Windows.Forms.Label();
            this._txtMileageRate = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._tabPrefix = new System.Windows.Forms.TabPage();
            this._txtServiceFromLetterPrefix = new System.Windows.Forms.TextBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._txtQuotePrefix = new System.Windows.Forms.TextBox();
            this._txtPPMPrefix = new System.Windows.Forms.TextBox();
            this._txtMiscPrefix = new System.Windows.Forms.TextBox();
            this._txtCalloutPrefix = new System.Windows.Forms.TextBox();
            this._Label11 = new System.Windows.Forms.Label();
            this._Label10 = new System.Windows.Forms.Label();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._TabPage1 = new System.Windows.Forms.TabPage();
            this._cboTimeSlot = new System.Windows.Forms.ComboBox();
            this._Label14 = new System.Windows.Forms.Label();
            this._lblTimeSlot = new System.Windows.Forms.Label();
            this._cboWorkingHoursEnd = new System.Windows.Forms.ComboBox();
            this._cboWorkingHoursStart = new System.Windows.Forms.ComboBox();
            this._Label16 = new System.Windows.Forms.Label();
            this._Label15 = new System.Windows.Forms.Label();
            this._tabInvoicePrefix = new System.Windows.Forms.TabPage();
            this._txtInvoicePrefix = new System.Windows.Forms.TextBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._TabPage2 = new System.Windows.Forms.TabPage();
            this._GroupBox1 = new System.Windows.Forms.GroupBox();
            this._txtRecallVariable = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._grpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgManager)).BeginInit();
            this._grpDetails.SuspendLayout();
            this._grpSettings.SuspendLayout();
            this._tabSystemSettings.SuspendLayout();
            this._tabImportSettings.SuspendLayout();
            this._GroupBox2.SuspendLayout();
            this._tabCharges.SuspendLayout();
            this._tabPrefix.SuspendLayout();
            this._TabPage1.SuspendLayout();
            this._tabInvoicePrefix.SuspendLayout();
            this._TabPage2.SuspendLayout();
            this._GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpItems
            // 
            this._grpItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpItems.Controls.Add(this._dgManager);
            this._grpItems.Controls.Add(this._btnAddNew);
            this._grpItems.Controls.Add(this._btnDelete);
            this._grpItems.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpItems.Location = new System.Drawing.Point(8, 45);
            this._grpItems.Name = "_grpItems";
            this._grpItems.Size = new System.Drawing.Size(368, 443);
            this._grpItems.TabIndex = 5;
            this._grpItems.TabStop = false;
            this._grpItems.Text = "Items";
            // 
            // _dgManager
            // 
            this._dgManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgManager.DataMember = "";
            this._dgManager.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgManager.Location = new System.Drawing.Point(8, 53);
            this._dgManager.Name = "_dgManager";
            this._dgManager.Size = new System.Drawing.Size(352, 382);
            this._dgManager.TabIndex = 3;
            this._dgManager.CurrentCellChanged += new System.EventHandler(this.dgManager_Click);
            this._dgManager.Click += new System.EventHandler(this.dgManager_Click);
            // 
            // _btnAddNew
            // 
            this._btnAddNew.AccessibleDescription = "Add new item";
            this._btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnAddNew.Location = new System.Drawing.Point(8, 24);
            this._btnAddNew.Name = "_btnAddNew";
            this._btnAddNew.Size = new System.Drawing.Size(48, 23);
            this._btnAddNew.TabIndex = 2;
            this._btnAddNew.Text = "New";
            this._btnAddNew.UseVisualStyleBackColor = true;
            this._btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // _btnDelete
            // 
            this._btnDelete.AccessibleDescription = "Delete item";
            this._btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnDelete.Location = new System.Drawing.Point(312, 24);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(48, 23);
            this._btnDelete.TabIndex = 4;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // _Label1
            // 
            this._Label1.Location = new System.Drawing.Point(8, 18);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(79, 23);
            this._Label1.TabIndex = 4;
            this._Label1.Text = "Select Type";
            // 
            // _cboType
            // 
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboType.DisplayMember = "Description";
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(88, 18);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(288, 21);
            this._cboType.TabIndex = 1;
            this._cboType.ValueMember = "Value";
            this._cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // _grpDetails
            // 
            this._grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpDetails.Controls.Add(this._chkMandatory);
            this._grpDetails.Controls.Add(this._txtPercentageRate);
            this._grpDetails.Controls.Add(this._lblPercentageRate);
            this._grpDetails.Controls.Add(this._Label3);
            this._grpDetails.Controls.Add(this._txtName);
            this._grpDetails.Controls.Add(this._txtDescription);
            this._grpDetails.Controls.Add(this._Label2);
            this._grpDetails.Controls.Add(this._btnSave);
            this._grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpDetails.Location = new System.Drawing.Point(384, 12);
            this._grpDetails.Name = "_grpDetails";
            this._grpDetails.Size = new System.Drawing.Size(392, 244);
            this._grpDetails.TabIndex = 7;
            this._grpDetails.TabStop = false;
            this._grpDetails.Text = "Details";
            // 
            // _chkMandatory
            // 
            this._chkMandatory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._chkMandatory.AutoSize = true;
            this._chkMandatory.Location = new System.Drawing.Point(208, 216);
            this._chkMandatory.Name = "_chkMandatory";
            this._chkMandatory.Size = new System.Drawing.Size(86, 17);
            this._chkMandatory.TabIndex = 10;
            this._chkMandatory.Text = "Mandatory";
            this._chkMandatory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._chkMandatory.UseVisualStyleBackColor = true;
            // 
            // _txtPercentageRate
            // 
            this._txtPercentageRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtPercentageRate.Location = new System.Drawing.Point(104, 212);
            this._txtPercentageRate.MaxLength = 255;
            this._txtPercentageRate.Name = "_txtPercentageRate";
            this._txtPercentageRate.Size = new System.Drawing.Size(87, 21);
            this._txtPercentageRate.TabIndex = 9;
            this._txtPercentageRate.Visible = false;
            // 
            // _lblPercentageRate
            // 
            this._lblPercentageRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblPercentageRate.Location = new System.Drawing.Point(6, 212);
            this._lblPercentageRate.Name = "_lblPercentageRate";
            this._lblPercentageRate.Size = new System.Drawing.Size(72, 21);
            this._lblPercentageRate.TabIndex = 8;
            this._lblPercentageRate.Text = "Rate (%)";
            this._lblPercentageRate.Visible = false;
            // 
            // _Label3
            // 
            this._Label3.Location = new System.Drawing.Point(8, 56);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(72, 23);
            this._Label3.TabIndex = 6;
            this._Label3.Text = "Description";
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(104, 24);
            this._txtName.MaxLength = 255;
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(280, 21);
            this._txtName.TabIndex = 5;
            // 
            // _txtDescription
            // 
            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescription.Location = new System.Drawing.Point(104, 56);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDescription.Size = new System.Drawing.Size(280, 148);
            this._txtDescription.TabIndex = 6;
            // 
            // _Label2
            // 
            this._Label2.Location = new System.Drawing.Point(8, 24);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(48, 23);
            this._Label2.TabIndex = 5;
            this._Label2.Text = "Name";
            // 
            // _btnSave
            // 
            this._btnSave.AccessibleDescription = "Save item";
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSave.ImageIndex = 1;
            this._btnSave.Location = new System.Drawing.Point(336, 212);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(48, 23);
            this._btnSave.TabIndex = 7;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // _grpSettings
            // 
            this._grpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSettings.Controls.Add(this._btnSaveSettings);
            this._grpSettings.Controls.Add(this._tabSystemSettings);
            this._grpSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._grpSettings.Location = new System.Drawing.Point(384, 256);
            this._grpSettings.Name = "_grpSettings";
            this._grpSettings.Size = new System.Drawing.Size(392, 232);
            this._grpSettings.TabIndex = 11;
            this._grpSettings.TabStop = false;
            this._grpSettings.Text = "System Settings";
            // 
            // _btnSaveSettings
            // 
            this._btnSaveSettings.AccessibleDescription = "Save system settings";
            this._btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this._btnSaveSettings.ImageIndex = 1;
            this._btnSaveSettings.Location = new System.Drawing.Point(336, 200);
            this._btnSaveSettings.Name = "_btnSaveSettings";
            this._btnSaveSettings.Size = new System.Drawing.Size(48, 23);
            this._btnSaveSettings.TabIndex = 20;
            this._btnSaveSettings.Text = "Save";
            this._btnSaveSettings.UseVisualStyleBackColor = true;
            this._btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // _tabSystemSettings
            // 
            this._tabSystemSettings.Controls.Add(this._tabImportSettings);
            this._tabSystemSettings.Controls.Add(this._tabCharges);
            this._tabSystemSettings.Controls.Add(this._tabPrefix);
            this._tabSystemSettings.Controls.Add(this._TabPage1);
            this._tabSystemSettings.Controls.Add(this._tabInvoicePrefix);
            this._tabSystemSettings.Controls.Add(this._TabPage2);
            this._tabSystemSettings.Location = new System.Drawing.Point(8, 24);
            this._tabSystemSettings.Name = "_tabSystemSettings";
            this._tabSystemSettings.SelectedIndex = 0;
            this._tabSystemSettings.Size = new System.Drawing.Size(376, 170);
            this._tabSystemSettings.TabIndex = 0;
            // 
            // _tabImportSettings
            // 
            this._tabImportSettings.Controls.Add(this._GroupBox2);
            this._tabImportSettings.Location = new System.Drawing.Point(4, 22);
            this._tabImportSettings.Name = "_tabImportSettings";
            this._tabImportSettings.Padding = new System.Windows.Forms.Padding(3);
            this._tabImportSettings.Size = new System.Drawing.Size(368, 144);
            this._tabImportSettings.TabIndex = 5;
            this._tabImportSettings.Text = "Import Settings";
            this._tabImportSettings.UseVisualStyleBackColor = true;
            // 
            // _GroupBox2
            // 
            this._GroupBox2.Controls.Add(this._txtPartsImportMarkup);
            this._GroupBox2.Location = new System.Drawing.Point(5, -1);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Size = new System.Drawing.Size(360, 132);
            this._GroupBox2.TabIndex = 0;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "Part Import Markup";
            // 
            // _txtPartsImportMarkup
            // 
            this._txtPartsImportMarkup.Location = new System.Drawing.Point(6, 20);
            this._txtPartsImportMarkup.Name = "_txtPartsImportMarkup";
            this._txtPartsImportMarkup.Size = new System.Drawing.Size(119, 21);
            this._txtPartsImportMarkup.TabIndex = 0;
            // 
            // _tabCharges
            // 
            this._tabCharges.Controls.Add(this._txtRatesMarkup);
            this._tabCharges.Controls.Add(this._Label13);
            this._tabCharges.Controls.Add(this._txtPartsMarkup);
            this._tabCharges.Controls.Add(this._Label12);
            this._tabCharges.Controls.Add(this._txtMileageRate);
            this._tabCharges.Controls.Add(this._Label4);
            this._tabCharges.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tabCharges.Location = new System.Drawing.Point(4, 22);
            this._tabCharges.Name = "_tabCharges";
            this._tabCharges.Size = new System.Drawing.Size(368, 144);
            this._tabCharges.TabIndex = 0;
            this._tabCharges.Text = "Charges";
            this._tabCharges.UseVisualStyleBackColor = true;
            // 
            // _txtRatesMarkup
            // 
            this._txtRatesMarkup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtRatesMarkup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtRatesMarkup.Location = new System.Drawing.Point(152, 72);
            this._txtRatesMarkup.Name = "_txtRatesMarkup";
            this._txtRatesMarkup.Size = new System.Drawing.Size(208, 21);
            this._txtRatesMarkup.TabIndex = 5;
            // 
            // _Label13
            // 
            this._Label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label13.Location = new System.Drawing.Point(8, 72);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(144, 23);
            this._Label13.TabIndex = 53;
            this._Label13.Text = "Rates Markup";
            // 
            // _txtPartsMarkup
            // 
            this._txtPartsMarkup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPartsMarkup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtPartsMarkup.Location = new System.Drawing.Point(152, 40);
            this._txtPartsMarkup.Name = "_txtPartsMarkup";
            this._txtPartsMarkup.Size = new System.Drawing.Size(208, 21);
            this._txtPartsMarkup.TabIndex = 4;
            // 
            // _Label12
            // 
            this._Label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label12.Location = new System.Drawing.Point(8, 40);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(144, 23);
            this._Label12.TabIndex = 51;
            this._Label12.Text = "Parts Markup";
            // 
            // _txtMileageRate
            // 
            this._txtMileageRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtMileageRate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtMileageRate.Location = new System.Drawing.Point(152, 8);
            this._txtMileageRate.Name = "_txtMileageRate";
            this._txtMileageRate.Size = new System.Drawing.Size(208, 21);
            this._txtMileageRate.TabIndex = 0;
            // 
            // _Label4
            // 
            this._Label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label4.Location = new System.Drawing.Point(8, 8);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(88, 23);
            this._Label4.TabIndex = 43;
            this._Label4.Text = "Mileage Rate:";
            // 
            // _tabPrefix
            // 
            this._tabPrefix.Controls.Add(this._txtServiceFromLetterPrefix);
            this._tabPrefix.Controls.Add(this._Label7);
            this._tabPrefix.Controls.Add(this._txtQuotePrefix);
            this._tabPrefix.Controls.Add(this._txtPPMPrefix);
            this._tabPrefix.Controls.Add(this._txtMiscPrefix);
            this._tabPrefix.Controls.Add(this._txtCalloutPrefix);
            this._tabPrefix.Controls.Add(this._Label11);
            this._tabPrefix.Controls.Add(this._Label10);
            this._tabPrefix.Controls.Add(this._Label9);
            this._tabPrefix.Controls.Add(this._Label8);
            this._tabPrefix.Location = new System.Drawing.Point(4, 22);
            this._tabPrefix.Name = "_tabPrefix";
            this._tabPrefix.Size = new System.Drawing.Size(368, 144);
            this._tabPrefix.TabIndex = 1;
            this._tabPrefix.Text = "Job Prefixes";
            this._tabPrefix.UseVisualStyleBackColor = true;
            // 
            // _txtServiceFromLetterPrefix
            // 
            this._txtServiceFromLetterPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtServiceFromLetterPrefix.Location = new System.Drawing.Point(174, 116);
            this._txtServiceFromLetterPrefix.MaxLength = 4;
            this._txtServiceFromLetterPrefix.Name = "_txtServiceFromLetterPrefix";
            this._txtServiceFromLetterPrefix.Size = new System.Drawing.Size(186, 21);
            this._txtServiceFromLetterPrefix.TabIndex = 18;
            // 
            // _Label7
            // 
            this._Label7.Location = new System.Drawing.Point(8, 116);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(182, 23);
            this._Label7.TabIndex = 17;
            this._Label7.Text = "Service From Letter Prefix:";
            // 
            // _txtQuotePrefix
            // 
            this._txtQuotePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtQuotePrefix.Location = new System.Drawing.Point(174, 89);
            this._txtQuotePrefix.MaxLength = 4;
            this._txtQuotePrefix.Name = "_txtQuotePrefix";
            this._txtQuotePrefix.Size = new System.Drawing.Size(186, 21);
            this._txtQuotePrefix.TabIndex = 16;
            // 
            // _txtPPMPrefix
            // 
            this._txtPPMPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPPMPrefix.Location = new System.Drawing.Point(174, 62);
            this._txtPPMPrefix.MaxLength = 4;
            this._txtPPMPrefix.Name = "_txtPPMPrefix";
            this._txtPPMPrefix.Size = new System.Drawing.Size(186, 21);
            this._txtPPMPrefix.TabIndex = 15;
            // 
            // _txtMiscPrefix
            // 
            this._txtMiscPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtMiscPrefix.Location = new System.Drawing.Point(174, 35);
            this._txtMiscPrefix.MaxLength = 4;
            this._txtMiscPrefix.Name = "_txtMiscPrefix";
            this._txtMiscPrefix.Size = new System.Drawing.Size(186, 21);
            this._txtMiscPrefix.TabIndex = 14;
            // 
            // _txtCalloutPrefix
            // 
            this._txtCalloutPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCalloutPrefix.Location = new System.Drawing.Point(174, 8);
            this._txtCalloutPrefix.MaxLength = 4;
            this._txtCalloutPrefix.Name = "_txtCalloutPrefix";
            this._txtCalloutPrefix.Size = new System.Drawing.Size(186, 21);
            this._txtCalloutPrefix.TabIndex = 13;
            // 
            // _Label11
            // 
            this._Label11.Location = new System.Drawing.Point(8, 89);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(80, 23);
            this._Label11.TabIndex = 3;
            this._Label11.Text = "Quote Prefix:";
            // 
            // _Label10
            // 
            this._Label10.Location = new System.Drawing.Point(8, 62);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(80, 23);
            this._Label10.TabIndex = 2;
            this._Label10.Text = "PPM Prefix:";
            // 
            // _Label9
            // 
            this._Label9.Location = new System.Drawing.Point(8, 35);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(136, 23);
            this._Label9.TabIndex = 1;
            this._Label9.Text = "Miscellaneous Prefix:";
            // 
            // _Label8
            // 
            this._Label8.Location = new System.Drawing.Point(8, 8);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(96, 23);
            this._Label8.TabIndex = 0;
            this._Label8.Text = "Callout Prefix:";
            // 
            // _TabPage1
            // 
            this._TabPage1.Controls.Add(this._cboTimeSlot);
            this._TabPage1.Controls.Add(this._Label14);
            this._TabPage1.Controls.Add(this._lblTimeSlot);
            this._TabPage1.Controls.Add(this._cboWorkingHoursEnd);
            this._TabPage1.Controls.Add(this._cboWorkingHoursStart);
            this._TabPage1.Controls.Add(this._Label16);
            this._TabPage1.Controls.Add(this._Label15);
            this._TabPage1.Location = new System.Drawing.Point(4, 22);
            this._TabPage1.Name = "_TabPage1";
            this._TabPage1.Size = new System.Drawing.Size(368, 144);
            this._TabPage1.TabIndex = 2;
            this._TabPage1.Text = "Working Day";
            this._TabPage1.UseVisualStyleBackColor = true;
            // 
            // _cboTimeSlot
            // 
            this._cboTimeSlot.Items.AddRange(new object[] {
            "15",
            "30",
            "45",
            "60"});
            this._cboTimeSlot.Location = new System.Drawing.Point(152, 8);
            this._cboTimeSlot.Name = "_cboTimeSlot";
            this._cboTimeSlot.Size = new System.Drawing.Size(80, 21);
            this._cboTimeSlot.TabIndex = 53;
            this._cboTimeSlot.SelectedValueChanged += new System.EventHandler(this.cboTimeSlot_SelectedValueChanged);
            // 
            // _Label14
            // 
            this._Label14.Location = new System.Drawing.Point(240, 8);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(48, 16);
            this._Label14.TabIndex = 51;
            this._Label14.Text = "Minutes";
            // 
            // _lblTimeSlot
            // 
            this._lblTimeSlot.Location = new System.Drawing.Point(8, 8);
            this._lblTimeSlot.Name = "_lblTimeSlot";
            this._lblTimeSlot.Size = new System.Drawing.Size(128, 23);
            this._lblTimeSlot.TabIndex = 47;
            this._lblTimeSlot.Text = "Time Slot Duration";
            // 
            // _cboWorkingHoursEnd
            // 
            this._cboWorkingHoursEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboWorkingHoursEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboWorkingHoursEnd.Location = new System.Drawing.Point(152, 72);
            this._cboWorkingHoursEnd.Name = "_cboWorkingHoursEnd";
            this._cboWorkingHoursEnd.Size = new System.Drawing.Size(80, 21);
            this._cboWorkingHoursEnd.TabIndex = 18;
            // 
            // _cboWorkingHoursStart
            // 
            this._cboWorkingHoursStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboWorkingHoursStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboWorkingHoursStart.Location = new System.Drawing.Point(152, 40);
            this._cboWorkingHoursStart.Name = "_cboWorkingHoursStart";
            this._cboWorkingHoursStart.Size = new System.Drawing.Size(80, 21);
            this._cboWorkingHoursStart.TabIndex = 17;
            // 
            // _Label16
            // 
            this._Label16.Location = new System.Drawing.Point(8, 72);
            this._Label16.Name = "_Label16";
            this._Label16.Size = new System.Drawing.Size(120, 16);
            this._Label16.TabIndex = 46;
            this._Label16.Text = "Working Hours End";
            // 
            // _Label15
            // 
            this._Label15.Location = new System.Drawing.Point(8, 40);
            this._Label15.Name = "_Label15";
            this._Label15.Size = new System.Drawing.Size(128, 23);
            this._Label15.TabIndex = 45;
            this._Label15.Text = "Working Hours Start";
            // 
            // _tabInvoicePrefix
            // 
            this._tabInvoicePrefix.Controls.Add(this._txtInvoicePrefix);
            this._tabInvoicePrefix.Controls.Add(this._Label5);
            this._tabInvoicePrefix.Location = new System.Drawing.Point(4, 22);
            this._tabInvoicePrefix.Name = "_tabInvoicePrefix";
            this._tabInvoicePrefix.Size = new System.Drawing.Size(368, 144);
            this._tabInvoicePrefix.TabIndex = 3;
            this._tabInvoicePrefix.Text = "Invoice Prefix";
            this._tabInvoicePrefix.UseVisualStyleBackColor = true;
            // 
            // _txtInvoicePrefix
            // 
            this._txtInvoicePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtInvoicePrefix.Location = new System.Drawing.Point(144, 16);
            this._txtInvoicePrefix.MaxLength = 4;
            this._txtInvoicePrefix.Name = "_txtInvoicePrefix";
            this._txtInvoicePrefix.Size = new System.Drawing.Size(208, 21);
            this._txtInvoicePrefix.TabIndex = 15;
            // 
            // _Label5
            // 
            this._Label5.Location = new System.Drawing.Point(8, 16);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(96, 23);
            this._Label5.TabIndex = 14;
            this._Label5.Text = "Invoice Prefix:";
            // 
            // _TabPage2
            // 
            this._TabPage2.Controls.Add(this._GroupBox1);
            this._TabPage2.Location = new System.Drawing.Point(4, 22);
            this._TabPage2.Name = "_TabPage2";
            this._TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this._TabPage2.Size = new System.Drawing.Size(368, 144);
            this._TabPage2.TabIndex = 4;
            this._TabPage2.Text = "Engineers Performance";
            this._TabPage2.UseVisualStyleBackColor = true;
            // 
            // _GroupBox1
            // 
            this._GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._GroupBox1.Controls.Add(this._txtRecallVariable);
            this._GroupBox1.Controls.Add(this._Label6);
            this._GroupBox1.Location = new System.Drawing.Point(6, 6);
            this._GroupBox1.Name = "_GroupBox1";
            this._GroupBox1.Size = new System.Drawing.Size(359, 132);
            this._GroupBox1.TabIndex = 0;
            this._GroupBox1.TabStop = false;
            this._GroupBox1.Text = "Engineer Performance Report";
            // 
            // _txtRecallVariable
            // 
            this._txtRecallVariable.Location = new System.Drawing.Point(9, 54);
            this._txtRecallVariable.Name = "_txtRecallVariable";
            this._txtRecallVariable.Size = new System.Drawing.Size(100, 21);
            this._txtRecallVariable.TabIndex = 1;
            // 
            // _Label6
            // 
            this._Label6.Location = new System.Drawing.Point(6, 17);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(288, 44);
            this._Label6.TabIndex = 0;
            this._Label6.Text = "Engineer Performance - No Of Days to see if a recall has been carried out at site" +
    ".";
            // 
            // FRMManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(784, 494);
            this.Controls.Add(this._grpSettings);
            this.Controls.Add(this._grpDetails);
            this.Controls.Add(this._grpItems);
            this.Controls.Add(this._Label1);
            this.Controls.Add(this._cboType);
            this.MinimumSize = new System.Drawing.Size(792, 528);
            this.Name = "FRMManager";
            this.Text = "Picklists / Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this._grpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgManager)).EndInit();
            this._grpDetails.ResumeLayout(false);
            this._grpDetails.PerformLayout();
            this._grpSettings.ResumeLayout(false);
            this._tabSystemSettings.ResumeLayout(false);
            this._tabImportSettings.ResumeLayout(false);
            this._GroupBox2.ResumeLayout(false);
            this._GroupBox2.PerformLayout();
            this._tabCharges.ResumeLayout(false);
            this._tabCharges.PerformLayout();
            this._tabPrefix.ResumeLayout(false);
            this._tabPrefix.PerformLayout();
            this._TabPage1.ResumeLayout(false);
            this._tabInvoicePrefix.ResumeLayout(false);
            this._tabInvoicePrefix.PerformLayout();
            this._TabPage2.ResumeLayout(false);
            this._GroupBox1.ResumeLayout(false);
            this._GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        
        

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

        
    }
}