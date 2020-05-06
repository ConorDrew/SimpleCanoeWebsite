using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class UCCustomer : UCBase, IUserControl
    {
        public UCCustomer() : base()
        {
            base.Load += UCCustomer_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();
            var argc = cboRegionID;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.Regions).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = cboStatus;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.CustomerStatus, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc2 = cboType;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.CustomerTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboTerms;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll((Enums.PickListTypes)70).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboAlertType;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Enums.PickListTypes.AlertTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc5 = cboDepartment;
                        Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc6 = cboDepartment;
                        Combo.SetUpCombo(ref argc6, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }

            SetupDG();
        }

        // UserControl overrides dispose to clean up the component list.
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

        private GroupBox _grpCustomer;

        private TabControl _TabControl1;

        internal TabControl TabControl1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TabControl1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TabControl1 != null)
                {
                }

                _TabControl1 = value;
                if (_TabControl1 != null)
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

        private Label _lblName;

        internal Label lblName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblName != null)
                {
                }

                _lblName = value;
                if (_lblName != null)
                {
                }
            }
        }

        private ComboBox _cboRegionID;

        internal ComboBox cboRegionID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRegionID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRegionID != null)
                {
                }

                _cboRegionID = value;
                if (_cboRegionID != null)
                {
                }
            }
        }

        private Label _lblRegionID;

        private TextBox _txtNotes;

        internal TextBox txtNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotes != null)
                {
                }

                _txtNotes = value;
                if (_txtNotes != null)
                {
                }
            }
        }

        private Label _lblNotes;

        private TextBox _txtAccountNumber;

        internal TextBox txtAccountNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccountNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccountNumber != null)
                {
                }

                _txtAccountNumber = value;
                if (_txtAccountNumber != null)
                {
                }
            }
        }

        private Label _lblAccountNumber;

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
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                }
            }
        }

        private Label _lblStatus;

        private TabPage _tabMainDetails;

        internal TabPage tabMainDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabMainDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabMainDetails != null)
                {
                }

                _tabMainDetails = value;
                if (_tabMainDetails != null)
                {
                }
            }
        }

        private TabPage _tabDocuments;

        private Panel _pnlDocuments;

        internal Panel pnlDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlDocuments != null)
                {
                }

                _pnlDocuments = value;
                if (_pnlDocuments != null)
                {
                }
            }
        }

        private TabPage _tabContracts;

        private Panel _pnlContracts;

        private TabPage _tabQuotes;

        internal TabPage tabQuotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabQuotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabQuotes != null)
                {
                }

                _tabQuotes = value;
                if (_tabQuotes != null)
                {
                }
            }
        }

        private Panel _pnlQuotes;

        internal Panel pnlQuotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlQuotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlQuotes != null)
                {
                }

                _pnlQuotes = value;
                if (_pnlQuotes != null)
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
                }

                _cboType = value;
                if (_cboType != null)
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

        private Panel _pnlCharges;

        internal Panel pnlCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlCharges != null)
                {
                }

                _pnlCharges = value;
                if (_pnlCharges != null)
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

        private GroupBox _grbCharges;

        private GroupBox _gpbContracts;

        internal GroupBox gpbContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbContracts != null)
                {
                }

                _gpbContracts = value;
                if (_gpbContracts != null)
                {
                }
            }
        }

        private DataGrid _dgContracts;

        internal DataGrid dgContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgContracts != null)
                {
                    _dgContracts.DoubleClick -= dgContracts_DoubleClick;
                }

                _dgContracts = value;
                if (_dgContracts != null)
                {
                    _dgContracts.DoubleClick += dgContracts_DoubleClick;
                }
            }
        }

        private Button _btnAddContract;

        internal Button btnAddContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddContract != null)
                {
                    _btnAddContract.Click -= btnAddContract_Click;
                }

                _btnAddContract = value;
                if (_btnAddContract != null)
                {
                    _btnAddContract.Click += btnAddContract_Click;
                }
            }
        }

        private Button _btnDeleteContract;

        private CheckBox _chbAcceptChargeChanges;

        internal CheckBox chbAcceptChargeChanges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chbAcceptChargeChanges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chbAcceptChargeChanges != null)
                {
                }

                _chbAcceptChargeChanges = value;
                if (_chbAcceptChargeChanges != null)
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

        private PictureBox _picLogo;

        internal PictureBox picLogo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _picLogo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_picLogo != null)
                {
                }

                _picLogo = value;
                if (_picLogo != null)
                {
                }
            }
        }

        private Button _btnSelectLogoImage;

        private CheckBox _chkPONumReq;

        internal CheckBox chkPONumReq
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPONumReq;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPONumReq != null)
                {
                }

                _chkPONumReq = value;
                if (_chkPONumReq != null)
                {
                }
            }
        }

        private CheckBox _chkJobPriorityRequired;

        internal CheckBox chkJobPriorityRequired
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkJobPriorityRequired;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkJobPriorityRequired != null)
                {
                }

                _chkJobPriorityRequired = value;
                if (_chkJobPriorityRequired != null)
                {
                }
            }
        }

        private TextBox _txtNominal;

        internal TextBox txtNominal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominal != null)
                {
                }

                _txtNominal = value;
                if (_txtNominal != null)
                {
                }
            }
        }

        private Label _Label7;

        private TabPage _tabPriority;

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

        private Label _Label8;

        private ComboBox _cboTerms;

        internal ComboBox cboTerms
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTerms;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTerms != null)
                {
                }

                _cboTerms = value;
                if (_cboTerms != null)
                {
                }
            }
        }

        private Label _Label9;

        private Label _Label11;

        private DataGrid _dgRequirements;

        internal DataGrid dgRequirements
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgRequirements;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgRequirements != null)
                {
                    _dgRequirements.MouseUp -= dgRequirement_MouseUp;
                }

                _dgRequirements = value;
                if (_dgRequirements != null)
                {
                    _dgRequirements.MouseUp += dgRequirement_MouseUp;
                }
            }
        }

        private Label _Label10;

        private CheckBox _chkSuperBooking;

        internal CheckBox chkSuperBooking
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSuperBooking;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSuperBooking != null)
                {
                }

                _chkSuperBooking = value;
                if (_chkSuperBooking != null)
                {
                }
            }
        }

        private TextBox _txtServWinter;

        internal TextBox txtServWinter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtServWinter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtServWinter != null)
                {
                }

                _txtServWinter = value;
                if (_txtServWinter != null)
                {
                }
            }
        }

        private TextBox _txtServSummer;

        internal TextBox txtServSummer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtServSummer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtServSummer != null)
                {
                }

                _txtServSummer = value;
                if (_txtServSummer != null)
                {
                }
            }
        }

        private Label _Label12;

        private TabPage _tabParts;

        internal TabPage tabParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabParts != null)
                {
                }

                _tabParts = value;
                if (_tabParts != null)
                {
                }
            }
        }

        private DataGridView _dgvParts;

        internal DataGridView dgvParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvParts != null)
                {
                }

                _dgvParts = value;
                if (_dgvParts != null)
                {
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

        private Button _btnAdd;

        internal Button btnAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdd != null)
                {
                    _btnAdd.Click -= btnAdd_Click;
                }

                _btnAdd = value;
                if (_btnAdd != null)
                {
                    _btnAdd.Click += btnAdd_Click;
                }
            }
        }

        private DataGridView _dgvPriority;

        internal DataGridView dgvPriority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgvPriority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgvPriority != null)
                {
                }

                _dgvPriority = value;
                if (_dgvPriority != null)
                {
                }
            }
        }

        private TextBox _txtAlertEmail;

        internal TextBox txtAlertEmail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAlertEmail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAlertEmail != null)
                {
                }

                _txtAlertEmail = value;
                if (_txtAlertEmail != null)
                {
                }
            }
        }

        private Label _Label13;

        private TabPage _tabServiceDates;

        internal TabPage tabServiceDates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabServiceDates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabServiceDates != null)
                {
                }

                _tabServiceDates = value;
                if (_tabServiceDates != null)
                {
                }
            }
        }

        private TabPage _tabCreation;

        internal TabPage tabCreation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabCreation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabCreation != null)
                {
                }

                _tabCreation = value;
                if (_tabCreation != null)
                {
                }
            }
        }

        private Button _btnEngDelete;

        internal Button btnEngDelete
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEngDelete;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEngDelete != null)
                {
                    _btnEngDelete.Click -= btnEngDelete_Click;
                }

                _btnEngDelete = value;
                if (_btnEngDelete != null)
                {
                    _btnEngDelete.Click += btnEngDelete_Click;
                }
            }
        }

        private Button _btnEngAdd;

        private DataGridView _dgRaiseEng;

        internal DataGridView dgRaiseEng
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgRaiseEng;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgRaiseEng != null)
                {
                    _dgRaiseEng.CellDoubleClick -= dgRaiseEng_CellContentClick;
                }

                _dgRaiseEng = value;
                if (_dgRaiseEng != null)
                {
                    _dgRaiseEng.CellDoubleClick += dgRaiseEng_CellContentClick;
                }
            }
        }

        private CheckBox _chkMOTService;

        internal CheckBox chkMOTService
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkMOTService;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkMOTService != null)
                {
                }

                _chkMOTService = value;
                if (_chkMOTService != null)
                {
                }
            }
        }

        private TabPage _tabAuthority;

        private GroupBox _gpCustAuth;

        private TextBox _txtCustAuthority;

        internal TextBox txtCustAuthority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustAuthority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustAuthority != null)
                {
                }

                _txtCustAuthority = value;
                if (_txtCustAuthority != null)
                {
                }
            }
        }

        private Button _btnSaveAuth;

        private GroupBox _grpAudit;

        private DataGrid _dgAuthorityAudit;

        internal DataGrid dgAuthorityAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAuthorityAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAuthorityAudit != null)
                {
                }

                _dgAuthorityAudit = value;
                if (_dgAuthorityAudit != null)
                {
                }
            }
        }

        private Label _Label14;

        private TextBox _txtPartSearch;

        internal TextBox txtPartSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartSearch != null)
                {
                    _txtPartSearch.TextChanged -= txtPartSearch_Change;
                }

                _txtPartSearch = value;
                if (_txtPartSearch != null)
                {
                    _txtPartSearch.TextChanged += txtPartSearch_Change;
                }
            }
        }

        private Button _btnExportSites;

        private CheckBox _cbIsOutOfScope;

        internal CheckBox cbIsOutOfScope
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbIsOutOfScope;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbIsOutOfScope != null)
                {
                }

                _cbIsOutOfScope = value;
                if (_cbIsOutOfScope != null)
                {
                }
            }
        }

        private TextBox _txtSpendLimit;

        internal TextBox txtSpendLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSpendLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSpendLimit != null)
                {
                }

                _txtSpendLimit = value;
                if (_txtSpendLimit != null)
                {
                }
            }
        }

        private Label _lblJobSpendLimit;

        private CheckBox _chkIsPFH;

        internal CheckBox chkIsPFH
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkIsPFH;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkIsPFH != null)
                {
                }

                _chkIsPFH = value;
                if (_chkIsPFH != null)
                {
                }
            }
        }

        private TabPage _tabAlerts;

        private GroupBox _grpCustomerAlerts;

        private DataGrid _dgCustomerAlerts;

        internal DataGrid dgCustomerAlerts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgCustomerAlerts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgCustomerAlerts != null)
                {
                    _dgCustomerAlerts.Click -= dgCustomerAlerts_Click;
                }

                _dgCustomerAlerts = value;
                if (_dgCustomerAlerts != null)
                {
                    _dgCustomerAlerts.Click += dgCustomerAlerts_Click;
                }
            }
        }

        private GroupBox _grpSite;

        private Button _btnSaveCustomerAlert;

        private ComboBox _cboAlertType;

        internal ComboBox cboAlertType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboAlertType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboAlertType != null)
                {
                }

                _cboAlertType = value;
                if (_cboAlertType != null)
                {
                }
            }
        }

        private Label _lblCustomerAlertEmailAddress;

        private Label _lblAlertType;

        private TextBox _txtCustomerAlertEmailAddress;

        internal TextBox txtCustomerAlertEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustomerAlertEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustomerAlertEmailAddress != null)
                {
                }

                _txtCustomerAlertEmailAddress = value;
                if (_txtCustomerAlertEmailAddress != null)
                {
                }
            }
        }

        private Label _lblEmailAddressMsg;

        private Button _btnDeleteCustomerAlert;

        internal Button btnDeleteCustomerAlert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteCustomerAlert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteCustomerAlert != null)
                {
                    _btnDeleteCustomerAlert.Click -= btnDeleteCustomerAlert_Click;
                }

                _btnDeleteCustomerAlert = value;
                if (_btnDeleteCustomerAlert != null)
                {
                    _btnDeleteCustomerAlert.Click += btnDeleteCustomerAlert_Click;
                }
            }
        }

        private Button _btnAddCustomerAlert;

        private ToolTip _tt;

        internal ToolTip tt
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tt;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tt != null)
                {
                }

                _tt = value;
                if (_tt != null)
                {
                }
            }
        }

        private Panel _pnlServiceProcess;

        internal Panel pnlServiceProcess
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlServiceProcess;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlServiceProcess != null)
                {
                }

                _pnlServiceProcess = value;
                if (_pnlServiceProcess != null)
                {
                }
            }
        }

        private TextBox _txtMainContractorDiscount;

        internal TextBox txtMainContractorDiscount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMainContractorDiscount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMainContractorDiscount != null)
                {
                }

                _txtMainContractorDiscount = value;
                if (_txtMainContractorDiscount != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._grpCustomer = new System.Windows.Forms.GroupBox();
            this._chkIsPFH = new System.Windows.Forms.CheckBox();
            this._cbIsOutOfScope = new System.Windows.Forms.CheckBox();
            this._btnExportSites = new System.Windows.Forms.Button();
            this._chkMOTService = new System.Windows.Forms.CheckBox();
            this._txtAlertEmail = new System.Windows.Forms.TextBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._txtServWinter = new System.Windows.Forms.TextBox();
            this._txtServSummer = new System.Windows.Forms.TextBox();
            this._Label12 = new System.Windows.Forms.Label();
            this._chkSuperBooking = new System.Windows.Forms.CheckBox();
            this._cboTerms = new System.Windows.Forms.ComboBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._cboDepartment = new System.Windows.Forms.ComboBox();
            this._Label8 = new System.Windows.Forms.Label();
            this._txtNominal = new System.Windows.Forms.TextBox();
            this._Label7 = new System.Windows.Forms.Label();
            this._chkJobPriorityRequired = new System.Windows.Forms.CheckBox();
            this._chkPONumReq = new System.Windows.Forms.CheckBox();
            this._btnSelectLogoImage = new System.Windows.Forms.Button();
            this._picLogo = new System.Windows.Forms.PictureBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._cboType = new System.Windows.Forms.ComboBox();
            this._Label2 = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._lblName = new System.Windows.Forms.Label();
            this._cboRegionID = new System.Windows.Forms.ComboBox();
            this._lblRegionID = new System.Windows.Forms.Label();
            this._txtNotes = new System.Windows.Forms.TextBox();
            this._lblNotes = new System.Windows.Forms.Label();
            this._txtAccountNumber = new System.Windows.Forms.TextBox();
            this._lblAccountNumber = new System.Windows.Forms.Label();
            this._cboStatus = new System.Windows.Forms.ComboBox();
            this._lblStatus = new System.Windows.Forms.Label();
            this._TabControl1 = new System.Windows.Forms.TabControl();
            this._tabMainDetails = new System.Windows.Forms.TabPage();
            this._tabContracts = new System.Windows.Forms.TabPage();
            this._pnlContracts = new System.Windows.Forms.Panel();
            this._gpbContracts = new System.Windows.Forms.GroupBox();
            this._btnDeleteContract = new System.Windows.Forms.Button();
            this._dgContracts = new System.Windows.Forms.DataGrid();
            this._btnAddContract = new System.Windows.Forms.Button();
            this._tabCharges = new System.Windows.Forms.TabPage();
            this._grbCharges = new System.Windows.Forms.GroupBox();
            this._txtSpendLimit = new System.Windows.Forms.TextBox();
            this._lblJobSpendLimit = new System.Windows.Forms.Label();
            this._txtMainContractorDiscount = new System.Windows.Forms.TextBox();
            this._Label5 = new System.Windows.Forms.Label();
            this._chbAcceptChargeChanges = new System.Windows.Forms.CheckBox();
            this._Label3 = new System.Windows.Forms.Label();
            this._txtRatesMarkup = new System.Windows.Forms.TextBox();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._txtMileageRate = new System.Windows.Forms.TextBox();
            this._txtPartsMarkup = new System.Windows.Forms.TextBox();
            this._pnlCharges = new System.Windows.Forms.Panel();
            this._tabDocuments = new System.Windows.Forms.TabPage();
            this._pnlDocuments = new System.Windows.Forms.Panel();
            this._tabQuotes = new System.Windows.Forms.TabPage();
            this._pnlQuotes = new System.Windows.Forms.Panel();
            this._tabPriority = new System.Windows.Forms.TabPage();
            this._dgvPriority = new System.Windows.Forms.DataGridView();
            this._Label11 = new System.Windows.Forms.Label();
            this._dgRequirements = new System.Windows.Forms.DataGrid();
            this._Label10 = new System.Windows.Forms.Label();
            this._tabParts = new System.Windows.Forms.TabPage();
            this._Label14 = new System.Windows.Forms.Label();
            this._txtPartSearch = new System.Windows.Forms.TextBox();
            this._btnDelete = new System.Windows.Forms.Button();
            this._btnAdd = new System.Windows.Forms.Button();
            this._dgvParts = new System.Windows.Forms.DataGridView();
            this._tabServiceDates = new System.Windows.Forms.TabPage();
            this._pnlServiceProcess = new System.Windows.Forms.Panel();
            this._tabCreation = new System.Windows.Forms.TabPage();
            this._btnEngDelete = new System.Windows.Forms.Button();
            this._btnEngAdd = new System.Windows.Forms.Button();
            this._dgRaiseEng = new System.Windows.Forms.DataGridView();
            this._tabAuthority = new System.Windows.Forms.TabPage();
            this._grpAudit = new System.Windows.Forms.GroupBox();
            this._dgAuthorityAudit = new System.Windows.Forms.DataGrid();
            this._gpCustAuth = new System.Windows.Forms.GroupBox();
            this._btnSaveAuth = new System.Windows.Forms.Button();
            this._txtCustAuthority = new System.Windows.Forms.TextBox();
            this._tabAlerts = new System.Windows.Forms.TabPage();
            this._grpCustomerAlerts = new System.Windows.Forms.GroupBox();
            this._grpSite = new System.Windows.Forms.GroupBox();
            this._btnAddCustomerAlert = new System.Windows.Forms.Button();
            this._btnDeleteCustomerAlert = new System.Windows.Forms.Button();
            this._txtCustomerAlertEmailAddress = new System.Windows.Forms.TextBox();
            this._lblEmailAddressMsg = new System.Windows.Forms.Label();
            this._btnSaveCustomerAlert = new System.Windows.Forms.Button();
            this._cboAlertType = new System.Windows.Forms.ComboBox();
            this._lblCustomerAlertEmailAddress = new System.Windows.Forms.Label();
            this._lblAlertType = new System.Windows.Forms.Label();
            this._dgCustomerAlerts = new System.Windows.Forms.DataGrid();
            this._tt = new System.Windows.Forms.ToolTip(this.components);
            this._grpCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picLogo)).BeginInit();
            this._TabControl1.SuspendLayout();
            this._tabMainDetails.SuspendLayout();
            this._tabContracts.SuspendLayout();
            this._pnlContracts.SuspendLayout();
            this._gpbContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgContracts)).BeginInit();
            this._tabCharges.SuspendLayout();
            this._grbCharges.SuspendLayout();
            this._tabDocuments.SuspendLayout();
            this._tabQuotes.SuspendLayout();
            this._tabPriority.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgRequirements)).BeginInit();
            this._tabParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvParts)).BeginInit();
            this._tabServiceDates.SuspendLayout();
            this._tabCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgRaiseEng)).BeginInit();
            this._tabAuthority.SuspendLayout();
            this._grpAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgAuthorityAudit)).BeginInit();
            this._gpCustAuth.SuspendLayout();
            this._tabAlerts.SuspendLayout();
            this._grpCustomerAlerts.SuspendLayout();
            this._grpSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCustomerAlerts)).BeginInit();
            this.SuspendLayout();
            //
            // _grpCustomer
            //
            this._grpCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCustomer.Controls.Add(this._chkIsPFH);
            this._grpCustomer.Controls.Add(this._cbIsOutOfScope);
            this._grpCustomer.Controls.Add(this._btnExportSites);
            this._grpCustomer.Controls.Add(this._chkMOTService);
            this._grpCustomer.Controls.Add(this._txtAlertEmail);
            this._grpCustomer.Controls.Add(this._Label13);
            this._grpCustomer.Controls.Add(this._txtServWinter);
            this._grpCustomer.Controls.Add(this._txtServSummer);
            this._grpCustomer.Controls.Add(this._Label12);
            this._grpCustomer.Controls.Add(this._chkSuperBooking);
            this._grpCustomer.Controls.Add(this._cboTerms);
            this._grpCustomer.Controls.Add(this._Label9);
            this._grpCustomer.Controls.Add(this._cboDepartment);
            this._grpCustomer.Controls.Add(this._Label8);
            this._grpCustomer.Controls.Add(this._txtNominal);
            this._grpCustomer.Controls.Add(this._Label7);
            this._grpCustomer.Controls.Add(this._chkJobPriorityRequired);
            this._grpCustomer.Controls.Add(this._chkPONumReq);
            this._grpCustomer.Controls.Add(this._btnSelectLogoImage);
            this._grpCustomer.Controls.Add(this._picLogo);
            this._grpCustomer.Controls.Add(this._Label6);
            this._grpCustomer.Controls.Add(this._cboType);
            this._grpCustomer.Controls.Add(this._Label2);
            this._grpCustomer.Controls.Add(this._txtName);
            this._grpCustomer.Controls.Add(this._lblName);
            this._grpCustomer.Controls.Add(this._cboRegionID);
            this._grpCustomer.Controls.Add(this._lblRegionID);
            this._grpCustomer.Controls.Add(this._txtNotes);
            this._grpCustomer.Controls.Add(this._lblNotes);
            this._grpCustomer.Controls.Add(this._txtAccountNumber);
            this._grpCustomer.Controls.Add(this._lblAccountNumber);
            this._grpCustomer.Controls.Add(this._cboStatus);
            this._grpCustomer.Controls.Add(this._lblStatus);
            this._grpCustomer.Location = new System.Drawing.Point(9, 8);
            this._grpCustomer.Name = "_grpCustomer";
            this._grpCustomer.Size = new System.Drawing.Size(629, 558);
            this._grpCustomer.TabIndex = 0;
            this._grpCustomer.TabStop = false;
            this._grpCustomer.Text = "Details";
            //
            // _chkIsPFH
            //
            this._chkIsPFH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._chkIsPFH.AutoSize = true;
            this._chkIsPFH.Location = new System.Drawing.Point(555, 353);
            this._chkIsPFH.Name = "_chkIsPFH";
            this._chkIsPFH.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._chkIsPFH.Size = new System.Drawing.Size(62, 17);
            this._chkIsPFH.TabIndex = 58;
            this._chkIsPFH.Text = "Is PFH";
            this._chkIsPFH.UseVisualStyleBackColor = true;
            //
            // _cbIsOutOfScope
            //
            this._cbIsOutOfScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cbIsOutOfScope.AutoSize = true;
            this._cbIsOutOfScope.Location = new System.Drawing.Point(516, 376);
            this._cbIsOutOfScope.Name = "_cbIsOutOfScope";
            this._cbIsOutOfScope.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._cbIsOutOfScope.Size = new System.Drawing.Size(102, 17);
            this._cbIsOutOfScope.TabIndex = 57;
            this._cbIsOutOfScope.Text = "Out Of Scope";
            this._cbIsOutOfScope.UseVisualStyleBackColor = true;
            //
            // _btnExportSites
            //
            this._btnExportSites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnExportSites.Location = new System.Drawing.Point(6, 527);
            this._btnExportSites.Name = "_btnExportSites";
            this._btnExportSites.Size = new System.Drawing.Size(103, 25);
            this._btnExportSites.TabIndex = 56;
            this._btnExportSites.Text = "Export Sites";
            this._btnExportSites.Click += new System.EventHandler(this.btnExportSites_Click);
            //
            // _chkMOTService
            //
            this._chkMOTService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._chkMOTService.AutoSize = true;
            this._chkMOTService.Location = new System.Drawing.Point(479, 398);
            this._chkMOTService.Name = "_chkMOTService";
            this._chkMOTService.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._chkMOTService.Size = new System.Drawing.Size(139, 17);
            this._chkMOTService.TabIndex = 55;
            this._chkMOTService.Text = "M.O.T Style Service";
            this._chkMOTService.UseVisualStyleBackColor = true;
            //
            // _txtAlertEmail
            //
            this._txtAlertEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAlertEmail.Location = new System.Drawing.Point(120, 261);
            this._txtAlertEmail.MaxLength = 255;
            this._txtAlertEmail.Name = "_txtAlertEmail";
            this._txtAlertEmail.Size = new System.Drawing.Size(498, 21);
            this._txtAlertEmail.TabIndex = 54;
            this._txtAlertEmail.Tag = "Customer.Name";
            //
            // _Label13
            //
            this._Label13.Location = new System.Drawing.Point(8, 264);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(89, 20);
            this._Label13.TabIndex = 53;
            this._Label13.Text = "Alert Email";
            //
            // _txtServWinter
            //
            this._txtServWinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtServWinter.Location = new System.Drawing.Point(540, 520);
            this._txtServWinter.MaxLength = 50;
            this._txtServWinter.Name = "_txtServWinter";
            this._txtServWinter.Size = new System.Drawing.Size(77, 21);
            this._txtServWinter.TabIndex = 52;
            this._txtServWinter.Tag = " ";
            //
            // _txtServSummer
            //
            this._txtServSummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._txtServSummer.Location = new System.Drawing.Point(415, 520);
            this._txtServSummer.MaxLength = 50;
            this._txtServSummer.Name = "_txtServSummer";
            this._txtServSummer.Size = new System.Drawing.Size(77, 21);
            this._txtServSummer.TabIndex = 51;
            this._txtServSummer.Tag = " ";
            //
            // _Label12
            //
            this._Label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label12.Location = new System.Drawing.Point(270, 514);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(113, 27);
            this._Label12.TabIndex = 50;
            this._Label12.Text = "Summer/Winter Servicing P/Month";
            //
            // _chkSuperBooking
            //
            this._chkSuperBooking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._chkSuperBooking.AutoSize = true;
            this._chkSuperBooking.Location = new System.Drawing.Point(444, 464);
            this._chkSuperBooking.Name = "_chkSuperBooking";
            this._chkSuperBooking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._chkSuperBooking.Size = new System.Drawing.Size(174, 17);
            this._chkSuperBooking.TabIndex = 49;
            this._chkSuperBooking.Text = "Coordinator Booking Only";
            this._chkSuperBooking.UseVisualStyleBackColor = true;
            //
            // _cboTerms
            //
            this._cboTerms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboTerms.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboTerms.Location = new System.Drawing.Point(120, 227);
            this._cboTerms.Name = "_cboTerms";
            this._cboTerms.Size = new System.Drawing.Size(498, 21);
            this._cboTerms.TabIndex = 48;
            this._cboTerms.Tag = "Customer.Status";
            //
            // _Label9
            //
            this._Label9.Location = new System.Drawing.Point(8, 226);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(103, 20);
            this._Label9.TabIndex = 47;
            this._Label9.Text = "Terms";
            //
            // _cboDepartment
            //
            this._cboDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cboDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboDepartment.Location = new System.Drawing.Point(415, 488);
            this._cboDepartment.Name = "_cboDepartment";
            this._cboDepartment.Size = new System.Drawing.Size(203, 21);
            this._cboDepartment.TabIndex = 46;
            this._cboDepartment.Tag = "Customer.TypeID";
            //
            // _Label8
            //
            this._Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Label8.Location = new System.Drawing.Point(270, 491);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(139, 23);
            this._Label8.TabIndex = 45;
            this._Label8.Text = "Override Department";
            //
            // _txtNominal
            //
            this._txtNominal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNominal.Location = new System.Drawing.Point(120, 193);
            this._txtNominal.MaxLength = 50;
            this._txtNominal.Name = "_txtNominal";
            this._txtNominal.Size = new System.Drawing.Size(498, 21);
            this._txtNominal.TabIndex = 11;
            this._txtNominal.Tag = " ";
            //
            // _Label7
            //
            this._Label7.Location = new System.Drawing.Point(8, 196);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(103, 20);
            this._Label7.TabIndex = 10;
            this._Label7.Text = "Nominal Code";
            //
            // _chkJobPriorityRequired
            //
            this._chkJobPriorityRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._chkJobPriorityRequired.AutoSize = true;
            this._chkJobPriorityRequired.Location = new System.Drawing.Point(473, 442);
            this._chkJobPriorityRequired.Name = "_chkJobPriorityRequired";
            this._chkJobPriorityRequired.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._chkJobPriorityRequired.Size = new System.Drawing.Size(145, 17);
            this._chkJobPriorityRequired.TabIndex = 17;
            this._chkJobPriorityRequired.Text = "Job Priority Required";
            this._chkJobPriorityRequired.UseVisualStyleBackColor = true;
            //
            // _chkPONumReq
            //
            this._chkPONumReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._chkPONumReq.AutoSize = true;
            this._chkPONumReq.Location = new System.Drawing.Point(472, 420);
            this._chkPONumReq.Name = "_chkPONumReq";
            this._chkPONumReq.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._chkPONumReq.Size = new System.Drawing.Size(146, 17);
            this._chkPONumReq.TabIndex = 16;
            this._chkPONumReq.Text = "PO Number Required";
            this._chkPONumReq.UseVisualStyleBackColor = true;
            //
            // _btnSelectLogoImage
            //
            this._btnSelectLogoImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnSelectLogoImage.Location = new System.Drawing.Point(263, 416);
            this._btnSelectLogoImage.Name = "_btnSelectLogoImage";
            this._btnSelectLogoImage.Size = new System.Drawing.Size(31, 23);
            this._btnSelectLogoImage.TabIndex = 15;
            this._btnSelectLogoImage.Text = "...";
            this._btnSelectLogoImage.UseVisualStyleBackColor = true;
            this._btnSelectLogoImage.Click += new System.EventHandler(this.btnSelectLogoImage_Click);
            //
            // _picLogo
            //
            this._picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._picLogo.BackColor = System.Drawing.Color.White;
            this._picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._picLogo.Location = new System.Drawing.Point(120, 417);
            this._picLogo.Name = "_picLogo";
            this._picLogo.Size = new System.Drawing.Size(135, 135);
            this._picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picLogo.TabIndex = 44;
            this._picLogo.TabStop = false;
            //
            // _Label6
            //
            this._Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._Label6.Location = new System.Drawing.Point(8, 423);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(62, 20);
            this._Label6.TabIndex = 14;
            this._Label6.Text = "Logo";
            //
            // _cboType
            //
            this._cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboType.Location = new System.Drawing.Point(120, 57);
            this._cboType.Name = "_cboType";
            this._cboType.Size = new System.Drawing.Size(498, 21);
            this._cboType.TabIndex = 3;
            this._cboType.Tag = "Customer.TypeID";
            //
            // _Label2
            //
            this._Label2.Location = new System.Drawing.Point(8, 60);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(66, 23);
            this._Label2.TabIndex = 2;
            this._Label2.Text = "Type";
            //
            // _txtName
            //
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Location = new System.Drawing.Point(120, 23);
            this._txtName.MaxLength = 255;
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(498, 21);
            this._txtName.TabIndex = 1;
            this._txtName.Tag = "Customer.Name";
            //
            // _lblName
            //
            this._lblName.Location = new System.Drawing.Point(8, 26);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(53, 20);
            this._lblName.TabIndex = 0;
            this._lblName.Text = "Name";
            //
            // _cboRegionID
            //
            this._cboRegionID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboRegionID.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboRegionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboRegionID.Location = new System.Drawing.Point(120, 91);
            this._cboRegionID.Name = "_cboRegionID";
            this._cboRegionID.Size = new System.Drawing.Size(498, 21);
            this._cboRegionID.TabIndex = 5;
            this._cboRegionID.Tag = "Customer.RegionID";
            //
            // _lblRegionID
            //
            this._lblRegionID.Location = new System.Drawing.Point(8, 94);
            this._lblRegionID.Name = "_lblRegionID";
            this._lblRegionID.Size = new System.Drawing.Size(55, 20);
            this._lblRegionID.TabIndex = 4;
            this._lblRegionID.Text = "Region ";
            //
            // _txtNotes
            //
            this._txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtNotes.Location = new System.Drawing.Point(120, 295);
            this._txtNotes.Multiline = true;
            this._txtNotes.Name = "_txtNotes";
            this._txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtNotes.Size = new System.Drawing.Size(497, 50);
            this._txtNotes.TabIndex = 13;
            this._txtNotes.Tag = "Customer.Notes";
            //
            // _lblNotes
            //
            this._lblNotes.Location = new System.Drawing.Point(8, 298);
            this._lblNotes.Name = "_lblNotes";
            this._lblNotes.Size = new System.Drawing.Size(62, 20);
            this._lblNotes.TabIndex = 12;
            this._lblNotes.Text = "Notes";
            //
            // _txtAccountNumber
            //
            this._txtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAccountNumber.Location = new System.Drawing.Point(120, 125);
            this._txtAccountNumber.MaxLength = 50;
            this._txtAccountNumber.Name = "_txtAccountNumber";
            this._txtAccountNumber.Size = new System.Drawing.Size(498, 21);
            this._txtAccountNumber.TabIndex = 7;
            this._txtAccountNumber.Tag = "Customer.AccountNumber";
            //
            // _lblAccountNumber
            //
            this._lblAccountNumber.Location = new System.Drawing.Point(8, 128);
            this._lblAccountNumber.Name = "_lblAccountNumber";
            this._lblAccountNumber.Size = new System.Drawing.Size(103, 20);
            this._lblAccountNumber.TabIndex = 6;
            this._lblAccountNumber.Text = "Account Number";
            //
            // _cboStatus
            //
            this._cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cboStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStatus.Location = new System.Drawing.Point(120, 159);
            this._cboStatus.Name = "_cboStatus";
            this._cboStatus.Size = new System.Drawing.Size(498, 21);
            this._cboStatus.TabIndex = 9;
            this._cboStatus.Tag = "Customer.Status";
            //
            // _lblStatus
            //
            this._lblStatus.Location = new System.Drawing.Point(8, 162);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(65, 20);
            this._lblStatus.TabIndex = 8;
            this._lblStatus.Text = "Status";
            //
            // _TabControl1
            //
            this._TabControl1.Controls.Add(this._tabMainDetails);
            this._TabControl1.Controls.Add(this._tabContracts);
            this._TabControl1.Controls.Add(this._tabCharges);
            this._TabControl1.Controls.Add(this._tabDocuments);
            this._TabControl1.Controls.Add(this._tabQuotes);
            this._TabControl1.Controls.Add(this._tabPriority);
            this._TabControl1.Controls.Add(this._tabParts);
            this._TabControl1.Controls.Add(this._tabServiceDates);
            this._TabControl1.Controls.Add(this._tabCreation);
            this._TabControl1.Controls.Add(this._tabAuthority);
            this._TabControl1.Controls.Add(this._tabAlerts);
            this._TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TabControl1.Location = new System.Drawing.Point(0, 0);
            this._TabControl1.Name = "_TabControl1";
            this._TabControl1.SelectedIndex = 0;
            this._TabControl1.Size = new System.Drawing.Size(653, 600);
            this._TabControl1.TabIndex = 0;
            //
            // _tabMainDetails
            //
            this._tabMainDetails.Controls.Add(this._grpCustomer);
            this._tabMainDetails.Location = new System.Drawing.Point(4, 22);
            this._tabMainDetails.Name = "_tabMainDetails";
            this._tabMainDetails.Size = new System.Drawing.Size(645, 574);
            this._tabMainDetails.TabIndex = 0;
            this._tabMainDetails.Text = "Main Details";
            //
            // _tabContracts
            //
            this._tabContracts.Controls.Add(this._pnlContracts);
            this._tabContracts.Location = new System.Drawing.Point(4, 22);
            this._tabContracts.Name = "_tabContracts";
            this._tabContracts.Size = new System.Drawing.Size(645, 574);
            this._tabContracts.TabIndex = 4;
            this._tabContracts.Text = "Contracts";
            //
            // _pnlContracts
            //
            this._pnlContracts.Controls.Add(this._gpbContracts);
            this._pnlContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlContracts.Location = new System.Drawing.Point(0, 0);
            this._pnlContracts.Name = "_pnlContracts";
            this._pnlContracts.Size = new System.Drawing.Size(645, 574);
            this._pnlContracts.TabIndex = 1;
            //
            // _gpbContracts
            //
            this._gpbContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gpbContracts.Controls.Add(this._btnDeleteContract);
            this._gpbContracts.Controls.Add(this._dgContracts);
            this._gpbContracts.Controls.Add(this._btnAddContract);
            this._gpbContracts.Location = new System.Drawing.Point(8, 8);
            this._gpbContracts.Name = "_gpbContracts";
            this._gpbContracts.Size = new System.Drawing.Size(632, 555);
            this._gpbContracts.TabIndex = 0;
            this._gpbContracts.TabStop = false;
            this._gpbContracts.Text = "Contract - Double click to view";
            //
            // _btnDeleteContract
            //
            this._btnDeleteContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnDeleteContract.Location = new System.Drawing.Point(549, 523);
            this._btnDeleteContract.Name = "_btnDeleteContract";
            this._btnDeleteContract.Size = new System.Drawing.Size(75, 23);
            this._btnDeleteContract.TabIndex = 2;
            this._btnDeleteContract.Text = "Delete";
            this._btnDeleteContract.Click += new System.EventHandler(this.btnDeleteContract_Click);
            //
            // _dgContracts
            //
            this._dgContracts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgContracts.DataMember = "";
            this._dgContracts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgContracts.Location = new System.Drawing.Point(8, 16);
            this._dgContracts.Name = "_dgContracts";
            this._dgContracts.Size = new System.Drawing.Size(616, 499);
            this._dgContracts.TabIndex = 1;
            this._dgContracts.DoubleClick += new System.EventHandler(this.dgContracts_DoubleClick);
            //
            // _btnAddContract
            //
            this._btnAddContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddContract.Location = new System.Drawing.Point(8, 523);
            this._btnAddContract.Name = "_btnAddContract";
            this._btnAddContract.Size = new System.Drawing.Size(75, 23);
            this._btnAddContract.TabIndex = 0;
            this._btnAddContract.Text = "Add";
            this._btnAddContract.UseVisualStyleBackColor = true;
            this._btnAddContract.Click += new System.EventHandler(this.btnAddContract_Click);
            //
            // _tabCharges
            //
            this._tabCharges.Controls.Add(this._grbCharges);
            this._tabCharges.Location = new System.Drawing.Point(4, 22);
            this._tabCharges.Name = "_tabCharges";
            this._tabCharges.Size = new System.Drawing.Size(645, 574);
            this._tabCharges.TabIndex = 7;
            this._tabCharges.Text = "Charges";
            //
            // _grbCharges
            //
            this._grbCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grbCharges.Controls.Add(this._txtSpendLimit);
            this._grbCharges.Controls.Add(this._lblJobSpendLimit);
            this._grbCharges.Controls.Add(this._txtMainContractorDiscount);
            this._grbCharges.Controls.Add(this._Label5);
            this._grbCharges.Controls.Add(this._chbAcceptChargeChanges);
            this._grbCharges.Controls.Add(this._Label3);
            this._grbCharges.Controls.Add(this._txtRatesMarkup);
            this._grbCharges.Controls.Add(this._Label4);
            this._grbCharges.Controls.Add(this._Label1);
            this._grbCharges.Controls.Add(this._txtMileageRate);
            this._grbCharges.Controls.Add(this._txtPartsMarkup);
            this._grbCharges.Controls.Add(this._pnlCharges);
            this._grbCharges.Location = new System.Drawing.Point(8, 0);
            this._grbCharges.Name = "_grbCharges";
            this._grbCharges.Size = new System.Drawing.Size(633, 571);
            this._grbCharges.TabIndex = 0;
            this._grbCharges.TabStop = false;
            this._grbCharges.Text = "Charges";
            //
            // _txtSpendLimit
            //
            this._txtSpendLimit.Location = new System.Drawing.Point(122, 70);
            this._txtSpendLimit.Name = "_txtSpendLimit";
            this._txtSpendLimit.Size = new System.Drawing.Size(64, 21);
            this._txtSpendLimit.TabIndex = 78;
            //
            // _lblJobSpendLimit
            //
            this._lblJobSpendLimit.AutoSize = true;
            this._lblJobSpendLimit.Location = new System.Drawing.Point(8, 73);
            this._lblJobSpendLimit.Name = "_lblJobSpendLimit";
            this._lblJobSpendLimit.Size = new System.Drawing.Size(108, 13);
            this._lblJobSpendLimit.TabIndex = 77;
            this._lblJobSpendLimit.Text = "Job Spend Limit £";
            //
            // _txtMainContractorDiscount
            //
            this._txtMainContractorDiscount.Location = new System.Drawing.Point(461, 72);
            this._txtMainContractorDiscount.Name = "_txtMainContractorDiscount";
            this._txtMainContractorDiscount.Size = new System.Drawing.Size(64, 21);
            this._txtMainContractorDiscount.TabIndex = 8;
            //
            // _Label5
            //
            this._Label5.Location = new System.Drawing.Point(278, 73);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(176, 21);
            this._Label5.TabIndex = 7;
            this._Label5.Text = "Main Contractor Discount %";
            //
            // _chbAcceptChargeChanges
            //
            this._chbAcceptChargeChanges.BackColor = System.Drawing.SystemColors.Info;
            this._chbAcceptChargeChanges.Location = new System.Drawing.Point(8, 16);
            this._chbAcceptChargeChanges.Name = "_chbAcceptChargeChanges";
            this._chbAcceptChargeChanges.Size = new System.Drawing.Size(480, 24);
            this._chbAcceptChargeChanges.TabIndex = 0;
            this._chbAcceptChargeChanges.Text = "Always accept changes to default charges made at system level";
            this._chbAcceptChargeChanges.UseVisualStyleBackColor = false;
            //
            // _Label3
            //
            this._Label3.Location = new System.Drawing.Point(368, 48);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(93, 21);
            this._Label3.TabIndex = 5;
            this._Label3.Text = "Rates Markup";
            //
            // _txtRatesMarkup
            //
            this._txtRatesMarkup.Location = new System.Drawing.Point(461, 48);
            this._txtRatesMarkup.Name = "_txtRatesMarkup";
            this._txtRatesMarkup.Size = new System.Drawing.Size(64, 21);
            this._txtRatesMarkup.TabIndex = 6;
            //
            // _Label4
            //
            this._Label4.Location = new System.Drawing.Point(8, 48);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(97, 21);
            this._Label4.TabIndex = 1;
            this._Label4.Text = "Labour Markup";
            //
            // _Label1
            //
            this._Label1.Location = new System.Drawing.Point(210, 48);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(90, 21);
            this._Label1.TabIndex = 3;
            this._Label1.Text = "Parts Markup";
            //
            // _txtMileageRate
            //
            this._txtMileageRate.Location = new System.Drawing.Point(122, 48);
            this._txtMileageRate.Name = "_txtMileageRate";
            this._txtMileageRate.Size = new System.Drawing.Size(64, 21);
            this._txtMileageRate.TabIndex = 2;
            //
            // _txtPartsMarkup
            //
            this._txtPartsMarkup.Location = new System.Drawing.Point(301, 48);
            this._txtPartsMarkup.Name = "_txtPartsMarkup";
            this._txtPartsMarkup.Size = new System.Drawing.Size(62, 21);
            this._txtPartsMarkup.TabIndex = 4;
            //
            // _pnlCharges
            //
            this._pnlCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pnlCharges.Location = new System.Drawing.Point(8, 97);
            this._pnlCharges.Name = "_pnlCharges";
            this._pnlCharges.Size = new System.Drawing.Size(617, 466);
            this._pnlCharges.TabIndex = 9;
            //
            // _tabDocuments
            //
            this._tabDocuments.Controls.Add(this._pnlDocuments);
            this._tabDocuments.Location = new System.Drawing.Point(4, 22);
            this._tabDocuments.Name = "_tabDocuments";
            this._tabDocuments.Size = new System.Drawing.Size(645, 574);
            this._tabDocuments.TabIndex = 2;
            this._tabDocuments.Text = "Documents";
            //
            // _pnlDocuments
            //
            this._pnlDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlDocuments.Location = new System.Drawing.Point(0, 0);
            this._pnlDocuments.Name = "_pnlDocuments";
            this._pnlDocuments.Size = new System.Drawing.Size(645, 574);
            this._pnlDocuments.TabIndex = 1;
            //
            // _tabQuotes
            //
            this._tabQuotes.Controls.Add(this._pnlQuotes);
            this._tabQuotes.Location = new System.Drawing.Point(4, 22);
            this._tabQuotes.Name = "_tabQuotes";
            this._tabQuotes.Size = new System.Drawing.Size(645, 574);
            this._tabQuotes.TabIndex = 5;
            this._tabQuotes.Text = "Quotes";
            //
            // _pnlQuotes
            //
            this._pnlQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlQuotes.Location = new System.Drawing.Point(0, 0);
            this._pnlQuotes.Name = "_pnlQuotes";
            this._pnlQuotes.Size = new System.Drawing.Size(645, 574);
            this._pnlQuotes.TabIndex = 1;
            //
            // _tabPriority
            //
            this._tabPriority.Controls.Add(this._dgvPriority);
            this._tabPriority.Controls.Add(this._Label11);
            this._tabPriority.Controls.Add(this._dgRequirements);
            this._tabPriority.Controls.Add(this._Label10);
            this._tabPriority.Location = new System.Drawing.Point(4, 22);
            this._tabPriority.Name = "_tabPriority";
            this._tabPriority.Size = new System.Drawing.Size(645, 574);
            this._tabPriority.TabIndex = 8;
            this._tabPriority.Text = "Priorities / Requirements";
            this._tabPriority.UseVisualStyleBackColor = true;
            //
            // _dgvPriority
            //
            this._dgvPriority.AllowUserToAddRows = false;
            this._dgvPriority.AllowUserToDeleteRows = false;
            this._dgvPriority.AllowUserToResizeColumns = false;
            this._dgvPriority.AllowUserToResizeRows = false;
            this._dgvPriority.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvPriority.Location = new System.Drawing.Point(37, 70);
            this._dgvPriority.MultiSelect = false;
            this._dgvPriority.Name = "_dgvPriority";
            this._dgvPriority.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvPriority.Size = new System.Drawing.Size(456, 170);
            this._dgvPriority.TabIndex = 10;
            //
            // _Label11
            //
            this._Label11.Location = new System.Drawing.Point(34, 294);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(103, 20);
            this._Label11.TabIndex = 9;
            this._Label11.Text = "Requirements";
            //
            // _dgRequirements
            //
            this._dgRequirements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgRequirements.DataMember = "";
            this._dgRequirements.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgRequirements.Location = new System.Drawing.Point(37, 317);
            this._dgRequirements.Name = "_dgRequirements";
            this._dgRequirements.Size = new System.Drawing.Size(592, 196);
            this._dgRequirements.TabIndex = 8;
            this._dgRequirements.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgRequirement_MouseUp);
            //
            // _Label10
            //
            this._Label10.Location = new System.Drawing.Point(34, 47);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(103, 20);
            this._Label10.TabIndex = 7;
            this._Label10.Text = "Priorities";
            //
            // _tabParts
            //
            this._tabParts.Controls.Add(this._Label14);
            this._tabParts.Controls.Add(this._txtPartSearch);
            this._tabParts.Controls.Add(this._btnDelete);
            this._tabParts.Controls.Add(this._btnAdd);
            this._tabParts.Controls.Add(this._dgvParts);
            this._tabParts.Location = new System.Drawing.Point(4, 22);
            this._tabParts.Name = "_tabParts";
            this._tabParts.Size = new System.Drawing.Size(645, 574);
            this._tabParts.TabIndex = 9;
            this._tabParts.Text = "Associated Supplier Parts";
            this._tabParts.UseVisualStyleBackColor = true;
            //
            // _Label14
            //
            this._Label14.AutoSize = true;
            this._Label14.Location = new System.Drawing.Point(3, 34);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(47, 13);
            this._Label14.TabIndex = 4;
            this._Label14.Text = "Search";
            //
            // _txtPartSearch
            //
            this._txtPartSearch.Location = new System.Drawing.Point(82, 31);
            this._txtPartSearch.Name = "_txtPartSearch";
            this._txtPartSearch.Size = new System.Drawing.Size(560, 21);
            this._txtPartSearch.TabIndex = 3;
            this._txtPartSearch.TextChanged += new System.EventHandler(this.txtPartSearch_Change);
            //
            // _btnDelete
            //
            this._btnDelete.Location = new System.Drawing.Point(58, 408);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(61, 23);
            this._btnDelete.TabIndex = 2;
            this._btnDelete.Text = "Delete";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // _btnAdd
            //
            this._btnAdd.Location = new System.Drawing.Point(532, 406);
            this._btnAdd.Name = "_btnAdd";
            this._btnAdd.Size = new System.Drawing.Size(65, 25);
            this._btnAdd.TabIndex = 1;
            this._btnAdd.Text = "Add";
            this._btnAdd.UseVisualStyleBackColor = true;
            this._btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // _dgvParts
            //
            this._dgvParts.AllowUserToAddRows = false;
            this._dgvParts.AllowUserToDeleteRows = false;
            this._dgvParts.AllowUserToOrderColumns = true;
            this._dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvParts.Location = new System.Drawing.Point(3, 62);
            this._dgvParts.Name = "_dgvParts";
            this._dgvParts.ReadOnly = true;
            this._dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgvParts.ShowCellErrors = false;
            this._dgvParts.Size = new System.Drawing.Size(639, 340);
            this._dgvParts.TabIndex = 0;
            //
            // _tabServiceDates
            //
            this._tabServiceDates.BackColor = System.Drawing.SystemColors.Control;
            this._tabServiceDates.Controls.Add(this._pnlServiceProcess);
            this._tabServiceDates.Location = new System.Drawing.Point(4, 22);
            this._tabServiceDates.Name = "_tabServiceDates";
            this._tabServiceDates.Size = new System.Drawing.Size(645, 574);
            this._tabServiceDates.TabIndex = 10;
            this._tabServiceDates.Text = "Service Dates";
            //
            // _pnlServiceProcess
            //
            this._pnlServiceProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlServiceProcess.Location = new System.Drawing.Point(0, 0);
            this._pnlServiceProcess.Name = "_pnlServiceProcess";
            this._pnlServiceProcess.Size = new System.Drawing.Size(645, 574);
            this._pnlServiceProcess.TabIndex = 2;
            //
            // _tabCreation
            //
            this._tabCreation.Controls.Add(this._btnEngDelete);
            this._tabCreation.Controls.Add(this._btnEngAdd);
            this._tabCreation.Controls.Add(this._dgRaiseEng);
            this._tabCreation.Location = new System.Drawing.Point(4, 22);
            this._tabCreation.Name = "_tabCreation";
            this._tabCreation.Size = new System.Drawing.Size(645, 574);
            this._tabCreation.TabIndex = 10;
            this._tabCreation.Text = "Engineer Job Creation";
            this._tabCreation.UseVisualStyleBackColor = true;
            //
            // _btnEngDelete
            //
            this._btnEngDelete.Location = new System.Drawing.Point(58, 429);
            this._btnEngDelete.Name = "_btnEngDelete";
            this._btnEngDelete.Size = new System.Drawing.Size(61, 23);
            this._btnEngDelete.TabIndex = 5;
            this._btnEngDelete.Text = "Delete";
            this._btnEngDelete.UseVisualStyleBackColor = true;
            this._btnEngDelete.Click += new System.EventHandler(this.btnEngDelete_Click);
            //
            // _btnEngAdd
            //
            this._btnEngAdd.Location = new System.Drawing.Point(384, 429);
            this._btnEngAdd.Name = "_btnEngAdd";
            this._btnEngAdd.Size = new System.Drawing.Size(65, 25);
            this._btnEngAdd.TabIndex = 4;
            this._btnEngAdd.Text = "Add";
            this._btnEngAdd.UseVisualStyleBackColor = true;
            this._btnEngAdd.Click += new System.EventHandler(this.btnEngAdd_Click);
            //
            // _dgRaiseEng
            //
            this._dgRaiseEng.AllowUserToAddRows = false;
            this._dgRaiseEng.AllowUserToDeleteRows = false;
            this._dgRaiseEng.AllowUserToOrderColumns = true;
            this._dgRaiseEng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgRaiseEng.Location = new System.Drawing.Point(3, 83);
            this._dgRaiseEng.Name = "_dgRaiseEng";
            this._dgRaiseEng.ReadOnly = true;
            this._dgRaiseEng.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dgRaiseEng.ShowCellErrors = false;
            this._dgRaiseEng.Size = new System.Drawing.Size(503, 340);
            this._dgRaiseEng.TabIndex = 3;
            this._dgRaiseEng.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRaiseEng_CellContentClick);
            //
            // _tabAuthority
            //
            this._tabAuthority.Controls.Add(this._grpAudit);
            this._tabAuthority.Controls.Add(this._gpCustAuth);
            this._tabAuthority.Location = new System.Drawing.Point(4, 22);
            this._tabAuthority.Name = "_tabAuthority";
            this._tabAuthority.Size = new System.Drawing.Size(645, 574);
            this._tabAuthority.TabIndex = 11;
            this._tabAuthority.Text = "Authority";
            this._tabAuthority.UseVisualStyleBackColor = true;
            //
            // _grpAudit
            //
            this._grpAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpAudit.Controls.Add(this._dgAuthorityAudit);
            this._grpAudit.Location = new System.Drawing.Point(3, 236);
            this._grpAudit.Name = "_grpAudit";
            this._grpAudit.Size = new System.Drawing.Size(639, 335);
            this._grpAudit.TabIndex = 38;
            this._grpAudit.TabStop = false;
            this._grpAudit.Text = "Audit";
            //
            // _dgAuthorityAudit
            //
            this._dgAuthorityAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgAuthorityAudit.DataMember = "";
            this._dgAuthorityAudit.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgAuthorityAudit.Location = new System.Drawing.Point(6, 20);
            this._dgAuthorityAudit.Name = "_dgAuthorityAudit";
            this._dgAuthorityAudit.Size = new System.Drawing.Size(627, 309);
            this._dgAuthorityAudit.TabIndex = 1;
            //
            // _gpCustAuth
            //
            this._gpCustAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._gpCustAuth.Controls.Add(this._btnSaveAuth);
            this._gpCustAuth.Controls.Add(this._txtCustAuthority);
            this._gpCustAuth.Location = new System.Drawing.Point(3, 3);
            this._gpCustAuth.Name = "_gpCustAuth";
            this._gpCustAuth.Size = new System.Drawing.Size(639, 227);
            this._gpCustAuth.TabIndex = 37;
            this._gpCustAuth.TabStop = false;
            this._gpCustAuth.Text = "Customer";
            //
            // _btnSaveAuth
            //
            this._btnSaveAuth.AccessibleDescription = "";
            this._btnSaveAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveAuth.Location = new System.Drawing.Point(548, 191);
            this._btnSaveAuth.Name = "_btnSaveAuth";
            this._btnSaveAuth.Size = new System.Drawing.Size(85, 23);
            this._btnSaveAuth.TabIndex = 4;
            this._btnSaveAuth.Text = "Save";
            this._btnSaveAuth.Click += new System.EventHandler(this.btnSaveAuth_Click);
            //
            // _txtCustAuthority
            //
            this._txtCustAuthority.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustAuthority.Location = new System.Drawing.Point(6, 20);
            this._txtCustAuthority.Multiline = true;
            this._txtCustAuthority.Name = "_txtCustAuthority";
            this._txtCustAuthority.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtCustAuthority.Size = new System.Drawing.Size(627, 156);
            this._txtCustAuthority.TabIndex = 0;
            //
            // _tabAlerts
            //
            this._tabAlerts.Controls.Add(this._grpCustomerAlerts);
            this._tabAlerts.Location = new System.Drawing.Point(4, 22);
            this._tabAlerts.Name = "_tabAlerts";
            this._tabAlerts.Size = new System.Drawing.Size(645, 574);
            this._tabAlerts.TabIndex = 12;
            this._tabAlerts.Text = "Alerts";
            this._tabAlerts.UseVisualStyleBackColor = true;
            //
            // _grpCustomerAlerts
            //
            this._grpCustomerAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpCustomerAlerts.Controls.Add(this._grpSite);
            this._grpCustomerAlerts.Controls.Add(this._dgCustomerAlerts);
            this._grpCustomerAlerts.Location = new System.Drawing.Point(13, 14);
            this._grpCustomerAlerts.Margin = new System.Windows.Forms.Padding(0);
            this._grpCustomerAlerts.Name = "_grpCustomerAlerts";
            this._grpCustomerAlerts.Padding = new System.Windows.Forms.Padding(0);
            this._grpCustomerAlerts.Size = new System.Drawing.Size(620, 547);
            this._grpCustomerAlerts.TabIndex = 15;
            this._grpCustomerAlerts.TabStop = false;
            this._grpCustomerAlerts.Text = "Alerts";
            //
            // _grpSite
            //
            this._grpSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._grpSite.Controls.Add(this._btnAddCustomerAlert);
            this._grpSite.Controls.Add(this._btnDeleteCustomerAlert);
            this._grpSite.Controls.Add(this._txtCustomerAlertEmailAddress);
            this._grpSite.Controls.Add(this._lblEmailAddressMsg);
            this._grpSite.Controls.Add(this._btnSaveCustomerAlert);
            this._grpSite.Controls.Add(this._cboAlertType);
            this._grpSite.Controls.Add(this._lblCustomerAlertEmailAddress);
            this._grpSite.Controls.Add(this._lblAlertType);
            this._grpSite.Location = new System.Drawing.Point(14, 287);
            this._grpSite.Name = "_grpSite";
            this._grpSite.Size = new System.Drawing.Size(592, 248);
            this._grpSite.TabIndex = 115;
            this._grpSite.TabStop = false;
            this._grpSite.Text = "Alert";
            //
            // _btnAddCustomerAlert
            //
            this._btnAddCustomerAlert.AccessibleDescription = "";
            this._btnAddCustomerAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnAddCustomerAlert.Location = new System.Drawing.Point(555, 18);
            this._btnAddCustomerAlert.Name = "_btnAddCustomerAlert";
            this._btnAddCustomerAlert.Size = new System.Drawing.Size(31, 28);
            this._btnAddCustomerAlert.TabIndex = 131;
            this._btnAddCustomerAlert.Text = "+";
            this._tt.SetToolTip(this._btnAddCustomerAlert, "Add new alert");
            this._btnAddCustomerAlert.Click += new System.EventHandler(this.btnAddCustomerAlert_Click);
            //
            // _btnDeleteCustomerAlert
            //
            this._btnDeleteCustomerAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnDeleteCustomerAlert.Location = new System.Drawing.Point(9, 210);
            this._btnDeleteCustomerAlert.Name = "_btnDeleteCustomerAlert";
            this._btnDeleteCustomerAlert.Size = new System.Drawing.Size(81, 23);
            this._btnDeleteCustomerAlert.TabIndex = 130;
            this._btnDeleteCustomerAlert.Text = "Delete";
            this._btnDeleteCustomerAlert.Visible = false;
            this._btnDeleteCustomerAlert.Click += new System.EventHandler(this.btnDeleteCustomerAlert_Click);
            //
            // _txtCustomerAlertEmailAddress
            //
            this._txtCustomerAlertEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCustomerAlertEmailAddress.Location = new System.Drawing.Point(9, 131);
            this._txtCustomerAlertEmailAddress.Multiline = true;
            this._txtCustomerAlertEmailAddress.Name = "_txtCustomerAlertEmailAddress";
            this._txtCustomerAlertEmailAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtCustomerAlertEmailAddress.Size = new System.Drawing.Size(577, 62);
            this._txtCustomerAlertEmailAddress.TabIndex = 129;
            this._txtCustomerAlertEmailAddress.Tag = "Customer.Notes";
            //
            // _lblEmailAddressMsg
            //
            this._lblEmailAddressMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmailAddressMsg.Location = new System.Drawing.Point(6, 63);
            this._lblEmailAddressMsg.Name = "_lblEmailAddressMsg";
            this._lblEmailAddressMsg.Size = new System.Drawing.Size(566, 29);
            this._lblEmailAddressMsg.TabIndex = 128;
            this._lblEmailAddressMsg.Text = "Please seperate each email address with a semi-colon;";
            //
            // _btnSaveCustomerAlert
            //
            this._btnSaveCustomerAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSaveCustomerAlert.Location = new System.Drawing.Point(505, 210);
            this._btnSaveCustomerAlert.Name = "_btnSaveCustomerAlert";
            this._btnSaveCustomerAlert.Size = new System.Drawing.Size(81, 23);
            this._btnSaveCustomerAlert.TabIndex = 127;
            this._btnSaveCustomerAlert.Text = "Save";
            this._btnSaveCustomerAlert.Click += new System.EventHandler(this.btnSaveCustomerAlert_Click);
            //
            // _cboAlertType
            //
            this._cboAlertType.Cursor = System.Windows.Forms.Cursors.Hand;
            this._cboAlertType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboAlertType.Location = new System.Drawing.Point(117, 20);
            this._cboAlertType.Name = "_cboAlertType";
            this._cboAlertType.Size = new System.Drawing.Size(161, 21);
            this._cboAlertType.TabIndex = 126;
            this._cboAlertType.Tag = "";
            //
            // _lblCustomerAlertEmailAddress
            //
            this._lblCustomerAlertEmailAddress.Location = new System.Drawing.Point(6, 105);
            this._lblCustomerAlertEmailAddress.Name = "_lblCustomerAlertEmailAddress";
            this._lblCustomerAlertEmailAddress.Size = new System.Drawing.Size(112, 23);
            this._lblCustomerAlertEmailAddress.TabIndex = 125;
            this._lblCustomerAlertEmailAddress.Text = "Email Address(s):";
            //
            // _lblAlertType
            //
            this._lblAlertType.Location = new System.Drawing.Point(6, 23);
            this._lblAlertType.Name = "_lblAlertType";
            this._lblAlertType.Size = new System.Drawing.Size(80, 23);
            this._lblAlertType.TabIndex = 123;
            this._lblAlertType.Text = "Alert Type:";
            //
            // _dgCustomerAlerts
            //
            this._dgCustomerAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dgCustomerAlerts.DataMember = "";
            this._dgCustomerAlerts.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgCustomerAlerts.Location = new System.Drawing.Point(14, 19);
            this._dgCustomerAlerts.Name = "_dgCustomerAlerts";
            this._dgCustomerAlerts.Size = new System.Drawing.Size(592, 262);
            this._dgCustomerAlerts.TabIndex = 11;
            this._dgCustomerAlerts.Click += new System.EventHandler(this.dgCustomerAlerts_Click);

            //
            // UCCustomer
            //
            this.Controls.Add(this._TabControl1);
            this.Name = "UCCustomer";
            this.Size = new System.Drawing.Size(653, 600);
            this._grpCustomer.ResumeLayout(false);
            this._grpCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._picLogo)).EndInit();
            this._TabControl1.ResumeLayout(false);
            this._tabMainDetails.ResumeLayout(false);
            this._tabContracts.ResumeLayout(false);
            this._pnlContracts.ResumeLayout(false);
            this._gpbContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgContracts)).EndInit();
            this._tabCharges.ResumeLayout(false);
            this._grbCharges.ResumeLayout(false);
            this._grbCharges.PerformLayout();
            this._tabDocuments.ResumeLayout(false);
            this._tabQuotes.ResumeLayout(false);
            this._tabPriority.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dgRequirements)).EndInit();
            this._tabParts.ResumeLayout(false);
            this._tabParts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvParts)).EndInit();
            this._tabServiceDates.ResumeLayout(false);
            this._tabCreation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgRaiseEng)).EndInit();
            this._tabAuthority.ResumeLayout(false);
            this._grpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgAuthorityAudit)).EndInit();
            this._gpCustAuth.ResumeLayout(false);
            this._gpCustAuth.PerformLayout();
            this._tabAlerts.ResumeLayout(false);
            this._grpCustomerAlerts.ResumeLayout(false);
            this._grpSite.ResumeLayout(false);
            this._grpSite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgCustomerAlerts)).EndInit();
            this.ResumeLayout(false);
        }

        public void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentCustomer;
            }
        }

        private UCDocumentsList DocumentsControl;
        private UCQuotesList QuotesControl;
        private UCCustomerScheduleOfRate CustomerScheduleOfRateControl;
        private UCCustomerServiceProcess UcServiceProcess;

        public event IUserControl.RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event IUserControl.StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.Customers.Customer _currentCustomer;

        public Entity.Customers.Customer CurrentCustomer
        {
            get
            {
                return _currentCustomer;
            }

            set
            {
                _currentCustomer = value;
                if (App.IsRFT) // RFT dont want these
                {
                    TabControl1.TabPages.Remove(tabParts);
                    TabControl1.TabPages.Remove(tabQuotes);
                }
                else
                {
                }

                if (_currentCustomer is null)
                {
                    _currentCustomer = new Entity.Customers.Customer();
                    _currentCustomer.Exists = false;
                    chbAcceptChargeChanges.Checked = true;
                }

                if (_currentCustomer.Exists)
                {
                    Populate();
                    pnlDocuments.Controls.Clear();
                    DocumentsControl = new UCDocumentsList(Enums.TableNames.tblCustomer, _currentCustomer.CustomerID);
                    pnlDocuments.Controls.Add(DocumentsControl);
                    Contracts = App.DB.Customer.Customer_Contracts_GetAll(_currentCustomer.CustomerID);
                    gpbContracts.Enabled = true;
                    pnlQuotes.Controls.Clear();
                    QuotesControl = new UCQuotesList(Enums.TableNames.tblCustomer, _currentCustomer.CustomerID, 0);
                    QuotesControl.RefreshContracts += RefreshContractList;
                    pnlQuotes.Controls.Add(QuotesControl);
                    pnlCharges.Controls.Clear();
                    CustomerScheduleOfRateControl = new UCCustomerScheduleOfRate(Enums.TableNames.tblCustomer, _currentCustomer.CustomerID);
                    pnlCharges.Controls.Add(CustomerScheduleOfRateControl);
                    pnlServiceProcess.Controls.Clear();
                    UcServiceProcess = new UCCustomerServiceProcess(_currentCustomer.CustomerID);
                    pnlServiceProcess.Controls.Add(UcServiceProcess);
                }
                else
                {
                    gpbContracts.Enabled = false;
                }
            }
        }

        private DataView _Data;

        public DataView Data
        {
            get
            {
                return _Data;
            }

            set
            {
                _Data = value;
                _Data.AllowNew = false;
                _Data.AllowEdit = true;
                _Data.AllowDelete = false;
                dgvPriority.AutoGenerateColumns = false;
                dgvPriority.EditMode = DataGridViewEditMode.EditOnEnter;
                dgvPriority.DataSource = Data;
            }
        }

        private Entity.Authority.Authority _oCustomerAuthority;

        public Entity.Authority.Authority CustomerAuthority
        {
            get
            {
                return _oCustomerAuthority;
            }

            set
            {
                _oCustomerAuthority = value;
            }
        }

        private DataView _PartsDataView = null;

        public DataView PartsDataView
        {
            get
            {
                return _PartsDataView;
            }

            set
            {
                _PartsDataView = value;
                _PartsDataView.Table.TableName = Enums.TableNames.tblWarehouse.ToString();
                _PartsDataView.AllowNew = false;
                _PartsDataView.AllowEdit = false;
                _PartsDataView.AllowDelete = false;
                dgvParts.DataSource = PartsDataView;
            }
        }

        private DataView _EngRaiseView = null;

        public DataView EngRaiseView
        {
            get
            {
                return _EngRaiseView;
            }

            set
            {
                _EngRaiseView = value;
                _EngRaiseView.Table.TableName = Enums.TableNames.tblWarehouse.ToString();
                _EngRaiseView.AllowNew = false;
                _EngRaiseView.AllowEdit = false;
                _EngRaiseView.AllowDelete = false;
                dgRaiseEng.DataSource = EngRaiseView;
            }
        }

        private DataView _RequirementDataView = null;

        public DataView RequirementDataView
        {
            get
            {
                return _RequirementDataView;
            }

            set
            {
                _RequirementDataView = value;
                _RequirementDataView.Table.TableName = Enums.TableNames.tblWarehouse.ToString();
                _RequirementDataView.AllowNew = false;
                _RequirementDataView.AllowEdit = false;
                _RequirementDataView.AllowDelete = false;
                dgRequirements.DataSource = RequirementDataView;
            }
        }

        private DataRow SelectedRequirmentDataRow
        {
            get
            {
                if (!(dgRequirements.CurrentRowIndex == -1))
                {
                    return RequirementDataView[dgRequirements.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _dvContracts;

        public DataView Contracts
        {
            get
            {
                return _dvContracts;
            }

            set
            {
                _dvContracts = value;
                _dvContracts.Table.TableName = Enums.TableNames.tblContract.ToString();
                _dvContracts.AllowNew = false;
                _dvContracts.AllowEdit = false;
                _dvContracts.AllowDelete = false;
                dgContracts.DataSource = Contracts;
            }
        }

        private DataRow SelectedContractDataRow
        {
            get
            {
                if (!(dgContracts.CurrentRowIndex == -1))
                {
                    return Contracts[dgContracts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupDG()
        {
            Helper.SetUpDataGridView(dgvParts);
            dgvParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParts.AutoGenerateColumns = false;
            dgvParts.Columns.Clear();
            dgvParts.EditMode = DataGridViewEditMode.EditOnEnter;
            var PartSupplierID = new DataGridViewTextBoxColumn();
            PartSupplierID.HeaderText = "";
            PartSupplierID.DataPropertyName = "PartSupplierID";
            PartSupplierID.FillWeight = 1;
            PartSupplierID.ReadOnly = true;
            PartSupplierID.SortMode = DataGridViewColumnSortMode.Programmatic;
            PartSupplierID.Visible = true;
            dgvParts.Columns.Add(PartSupplierID);
            var PartName = new DataGridViewTextBoxColumn();
            PartName.FillWeight = 120;
            PartName.HeaderText = "Part Name";
            PartName.DataPropertyName = "PartName";
            PartName.ReadOnly = true;
            PartName.Visible = true;
            PartName.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(PartName);
            var PartNumber = new DataGridViewTextBoxColumn();
            PartNumber.HeaderText = "Part Number";
            PartNumber.DataPropertyName = "PartNumber";
            PartNumber.FillWeight = 50;
            PartNumber.ReadOnly = true;
            PartNumber.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(PartNumber);
            var SPN = new DataGridViewTextBoxColumn();
            SPN.HeaderText = "SPN";
            SPN.DataPropertyName = "PartCode";
            SPN.FillWeight = 40;
            SPN.ReadOnly = true;
            SPN.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvParts.Columns.Add(SPN);
            var Supplier = new DataGridViewTextBoxColumn();
            Supplier.HeaderText = "Supplier Name";
            Supplier.DataPropertyName = "SupplierName";
            Supplier.FillWeight = 55;
            Supplier.ReadOnly = true;
            Supplier.SortMode = DataGridViewColumnSortMode.Programmatic;
            Supplier.Visible = true;
            dgvParts.Columns.Add(Supplier);
            //dgvParts.Sort(Supplier, System.ComponentModel.ListSortDirection.Descending);
        }

        public void SetupPrioritiesDGV()
        {
            var Include = new DataGridViewCheckBoxColumn();
            Include.FillWeight = 5;
            Include.HeaderText = "Tick";
            Include.DataPropertyName = "Tick";
            Include.Name = "Tick";
            Include.ReadOnly = false;
            Include.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPriority.Columns.Add(Include);
            var ID = new DataGridViewTextBoxColumn();
            ID.HeaderText = "ManagerID";
            ID.DataPropertyName = "ManagerID";
            ID.Name = "ManagerID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPriority.Columns.Add(ID);
            var InvoiceNo = new DataGridViewTextBoxColumn();
            InvoiceNo.HeaderText = "Name";
            InvoiceNo.DataPropertyName = "Name";
            InvoiceNo.FillWeight = 20;
            InvoiceNo.ReadOnly = true;
            InvoiceNo.Visible = true;
            InvoiceNo.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPriority.Columns.Add(InvoiceNo);
            var Location = new DataGridViewTextBoxColumn();
            Location.HeaderText = "TargetHours";
            Location.FillWeight = 15;
            Location.DataPropertyName = "TargetHours";
            Location.Name = "TargetHours";
            Location.Visible = true;
            Location.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPriority.Columns.Add(Location);
            var Include1 = new DataGridViewCheckBoxColumn();
            Include1.FillWeight = 5;
            Include1.HeaderText = "Include OOH";
            Include1.DataPropertyName = "IncludeOOH";
            Include1.Name = "IncludeOOH";
            Include1.ReadOnly = false;
            Include1.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPriority.Columns.Add(Include1);
            var Include2 = new DataGridViewCheckBoxColumn();
            Include2.FillWeight = 5;
            Include2.HeaderText = "Include Weekends";
            Include2.DataPropertyName = "IncludeWeekends";
            Include2.Name = "IncludeWeekends";
            Include2.ReadOnly = false;
            Include2.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPriority.Columns.Add(Include2);
            var Include3 = new DataGridViewCheckBoxColumn();
            Include3.FillWeight = 5;
            Include3.HeaderText = "Include Bank Holidays";
            Include3.DataPropertyName = "IncludeBH";
            Include3.Name = "IncludeBH";
            Include3.ReadOnly = false;
            Include3.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgvPriority.Columns.Add(Include3);
        }

        public void SetupRaiseEngDGV()
        {
            Helper.SetUpDataGridView(dgRaiseEng);
            dgRaiseEng.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgRaiseEng.AutoGenerateColumns = false;
            dgRaiseEng.Columns.Clear();
            var ID = new DataGridViewTextBoxColumn();
            ID.HeaderText = "EngineerID";
            ID.DataPropertyName = "EngineerID";
            ID.Name = "EngineerID";
            ID.ReadOnly = true;
            ID.Visible = false;
            ID.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgRaiseEng.Columns.Add(ID);
            var ID2 = new DataGridViewTextBoxColumn();
            ID2.HeaderText = "RaiseJobCustomerEngineerID";
            ID2.DataPropertyName = "RaiseJobCustomerEngineerID";
            ID2.Name = "RaiseJobCustomerEngineerID";
            ID2.ReadOnly = true;
            ID2.Visible = false;
            ID2.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgRaiseEng.Columns.Add(ID2);
            var Location = new DataGridViewTextBoxColumn();
            Location.HeaderText = "EngineerName";
            Location.FillWeight = 70;
            Location.DataPropertyName = "EngineerName";
            Location.Name = "EngineerName";
            Location.Visible = true;
            Location.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgRaiseEng.Columns.Add(Location);
            var Include = new DataGridViewCheckBoxColumn();
            Include.FillWeight = 5;
            Include.HeaderText = "Super";
            Include.DataPropertyName = "Super";
            Include.Name = "Super";
            Include.ReadOnly = false;
            Include.SortMode = DataGridViewColumnSortMode.Programmatic;
            dgRaiseEng.Columns.Add(Include);
        }

        public void SetupRequirements()
        {
            Helper.SetUpDataGrid(dgRequirements);
            var tStyle = dgRequirements.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.ReadOnly = false;
            tStyle.AllowSorting = false;
            dgRequirements.ReadOnly = false;
            dgRequirements.AllowSorting = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 300;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var Name2 = new DataGridLabelColumn();
            Name2.Format = "";
            Name2.FormatInfo = null;
            Name2.HeaderText = "";
            Name2.MappingName = "ManagerID";
            Name2.ReadOnly = true;
            Name2.Width = 1;
            Name2.NullText = "";
            tStyle.GridColumnStyles.Add(Name2);
            tStyle.MappingName = Enums.TableNames.tblWarehouse.ToString();
            dgRequirements.TableStyles.Add(tStyle);
        }

        public void SetupContractsDataGrid()
        {
            var tStyle = dgContracts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var ContractType = new DataGridLabelColumn();
            ContractType.Format = "";
            ContractType.FormatInfo = null;
            ContractType.HeaderText = "Contract Type";
            ContractType.MappingName = "Type";
            ContractType.ReadOnly = true;
            ContractType.Width = 100;
            ContractType.NullText = "";
            tStyle.GridColumnStyles.Add(ContractType);
            var ContractReference = new DataGridLabelColumn();
            ContractReference.Format = "";
            ContractReference.FormatInfo = null;
            ContractReference.HeaderText = "Contract Reference";
            ContractReference.MappingName = "ContractReference";
            ContractReference.ReadOnly = true;
            ContractReference.Width = 150;
            ContractReference.NullText = "";
            tStyle.GridColumnStyles.Add(ContractReference);
            var ContractStatus = new DataGridLabelColumn();
            ContractStatus.Format = "";
            ContractStatus.FormatInfo = null;
            ContractStatus.HeaderText = "Contract Status";
            ContractStatus.MappingName = "ContractStatus";
            ContractStatus.ReadOnly = true;
            ContractStatus.Width = 180;
            ContractStatus.NullText = "";
            tStyle.GridColumnStyles.Add(ContractStatus);
            var ContractStartDate = new DataGridLabelColumn();
            ContractStartDate.Format = "dd/MM/yyyy";
            ContractStartDate.FormatInfo = null;
            ContractStartDate.HeaderText = "Start Date";
            ContractStartDate.MappingName = "ContractStartDate";
            ContractStartDate.ReadOnly = true;
            ContractStartDate.Width = 100;
            ContractStartDate.NullText = "N/A";
            tStyle.GridColumnStyles.Add(ContractStartDate);
            var ContractEndDate = new DataGridLabelColumn();
            ContractEndDate.Format = "dd/MM/yyyy";
            ContractEndDate.FormatInfo = null;
            ContractEndDate.HeaderText = "End Date";
            ContractEndDate.MappingName = "ContractEndDate";
            ContractEndDate.ReadOnly = true;
            ContractEndDate.Width = 100;
            ContractEndDate.NullText = "N/A";
            tStyle.GridColumnStyles.Add(ContractEndDate);
            var ContractPrice = new DataGridLabelColumn();
            ContractPrice.Format = "C";
            ContractPrice.FormatInfo = null;
            ContractPrice.HeaderText = "Contract Price";
            ContractPrice.MappingName = "ContractPrice";
            ContractPrice.ReadOnly = true;
            ContractPrice.Width = 100;
            ContractPrice.NullText = "";
            tStyle.GridColumnStyles.Add(ContractPrice);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblContract.ToString();
            dgContracts.TableStyles.Add(tStyle);
        }

        private void UCCustomer_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            SetupContractsDataGrid();
            SetupPrioritiesDGV();
            SetupRequirements();
            SetupRaiseEngDGV();
            SetupCustomerAuthorityAuditDataGrid();
            SetupCustomerAlertsDataGrid();
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMContractOriginal), true, new object[] { 0, Helper.MakeIntegerValid(CurrentCustomer.CustomerID) });
            Contracts = App.DB.Customer.Customer_Contracts_GetAll(CurrentCustomer.CustomerID);
        }

        private void btnDeleteContract_Click(object sender, EventArgs e)
        {
            if (SelectedContractDataRow is null)
            {
                return;
            }

            if (App.ShowMessage("Are you sure you want to delete this contract - any contract jobs not yet downloaded will be remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            bool deleteContract = true;
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedContractDataRow["ContractType"], Enums.QuoteType.Contract_Opt_1.ToString(), false)))
            {
                deleteContract = DeleteOption1();
            }

            if (deleteContract)
            {
                Contracts = App.DB.Customer.Customer_Contracts_GetAll(CurrentCustomer.CustomerID);
            }
            else
            {
                App.ShowMessage("Cannot delete the contract - there are active jobs on properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgContracts_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedContractDataRow is null)
            {
                return;
            }

            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedContractDataRow["ContractType"], Enums.QuoteType.Contract_Opt_1.ToString(), false)))
            {
                App.ShowForm(typeof(FRMContractOriginal), true, new object[] { Helper.MakeIntegerValid(SelectedContractDataRow["ContractID"]), Helper.MakeIntegerValid(CurrentCustomer.CustomerID) });
            }

            Contracts = App.DB.Customer.Customer_Contracts_GetAll(CurrentCustomer.CustomerID);
        }

        private bool DeleteOption1()
        {
            // DELETE Visit, Jobs - not sync, Job Assets, PPM Visits, Contract Site Assets, Contract Sites
            var sites = new DataView();
            sites = App.DB.ContractOriginalSite.GetAll_ContractID(Conversions.ToInteger(SelectedContractDataRow["ContractID"]), CurrentCustomer.CustomerID);
            bool DeleteContract = true;
            foreach (DataRow r in sites.Table.Rows)
            {
                if (App.DB.ContractOriginalSite.Delete(Conversions.ToInteger(r["ContractSiteID"])) > 0)
                {
                    DeleteContract = false;
                }
            }

            if (DeleteContract)
            {
                App.DB.ContractOriginal.Delete(Helper.MakeIntegerValid(SelectedContractDataRow["ContractID"]));
            }

            return DeleteContract;
        }

        public void RefreshContractList()
        {
            Contracts = App.DB.Customer.Customer_Contracts_GetAll(CurrentCustomer.CustomerID);
        }

        private void PopulateCharges()
        {
            var CustomerCharges = new Entity.CustomerCharges.CustomerCharge();
            CustomerCharges = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(CurrentCustomer.CustomerID);
            if (CustomerCharges is object)
            {
                txtMileageRate.Text = CustomerCharges.MileageRate.ToString();
                txtPartsMarkup.Text = CustomerCharges.PartsMarkup.ToString();
                txtRatesMarkup.Text = CustomerCharges.RatesMarkup.ToString();
            }
            else
            {
                var settings = App.DB.Manager.Get();
                txtMileageRate.Text = Helper.MakeDoubleValid(settings?.MileageRate).ToString();
                txtPartsMarkup.Text = Helper.MakeDoubleValid(settings?.PartsMarkup).ToString();
                txtRatesMarkup.Text = Helper.MakeDoubleValid(settings?.RatesMarkup).ToString();
            }
        }

        public void Populate(int ID = 0)
        {
            App.ControlLoading = true;
            if (!(ID == 0))
            {
                CurrentCustomer = App.DB.Customer.Customer_Get(ID);
            }

            PopulateCharges();
            if (!App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.CustomerCharges))
            {
                TabControl1.TabPages.Remove(tabCharges);
            }

            Data = App.DB.Customer.Priorities_Get_For_CustomerID(CurrentCustomer.CustomerID);
            RequirementDataView = App.DB.Customer.Requirements_Get_For_CustomerID(CurrentCustomer.CustomerID);
            PartsDataView = App.DB.Part.Customer_Parts_GetAll(CurrentCustomer.CustomerID);
            EngRaiseView = App.DB.Customer.Customer_EngineerRaise_Get(CurrentCustomer.CustomerID);
            txtName.Text = CurrentCustomer.Name;
            var argcombo = cboRegionID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentCustomer.RegionID.ToString());
            if (!CurrentCustomer.Exists | !App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
            {
                cboRegionID.Enabled = false;
            }

            var argcombo1 = cboType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, CurrentCustomer.CustomerTypeID.ToString());
            if (CurrentCustomer.CustomerTypeID == Conversions.ToInteger(Enums.CustomerType.SocialHousing))
            {
                cboType.Enabled = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor);
            }

            txtAlertEmail.Text = CurrentCustomer.AlertEmail;
            txtNotes.Text = CurrentCustomer.Notes;
            txtAccountNumber.Text = CurrentCustomer.AccountNumber;
            var argcombo2 = cboStatus;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentCustomer.Status.ToString());
            Enums.SecuritySystemModules ssm;
            ssm = Enums.SecuritySystemModules.Finance;
            if (CurrentCustomer.Status == Conversions.ToInteger(Enums.CustomerStatus.OnHold) & !App.loggedInUser.HasAccessToModule(ssm))
            {
                cboStatus.Enabled = false;
            }

            PopulateCustomerAuthority();
            PopulateCustomerAlerts();
            chbAcceptChargeChanges.Checked = CurrentCustomer.AcceptChargesChanges;
            chkMOTService.Checked = CurrentCustomer.MOTStyleService;
            cbIsOutOfScope.Checked = CurrentCustomer.IsOutOfScope;
            txtMainContractorDiscount.Text = CurrentCustomer.MainContractorDiscount.ToString();
            chkPONumReq.Checked = CurrentCustomer.PoNumReqd;
            chkJobPriorityRequired.Checked = CurrentCustomer.JobPriorityMandatory;
            txtNominal.Text = CurrentCustomer.Nominal;
            var argcombo3 = cboDepartment;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentCustomer.OverrideDept.Trim());
            var argcombo4 = cboTerms;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, CurrentCustomer.Terms.ToString());
            chkSuperBooking.Checked = CurrentCustomer.SuperBook;
            if (CurrentCustomer.Logo is object)
            {
                var logoStream = new MemoryStream(CurrentCustomer.Logo);
                picLogo.Image = Image.FromStream(logoStream);
            }

            txtServSummer.Text = CurrentCustomer.SummerServ.ToString();
            txtServWinter.Text = CurrentCustomer.WinterServ.ToString();
            txtSpendLimit.Text = CurrentCustomer.JobSpendLimit.ToString();
            chkIsPFH.Checked = CurrentCustomer.IsPFH;
            App.AddChangeHandlers(this);
            App.ControlChanged = false;
            App.ControlLoading = false;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentCustomer.IgnoreExceptionsOnSetMethods = true;
                CurrentCustomer.SetName = txtName.Text.Trim();
                if (!CurrentCustomer.Exists | App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Region))
                {
                    CurrentCustomer.SetRegionID = Combo.get_GetSelectedItemValue(cboRegionID);
                }

                CurrentCustomer.SetCustomerTypeID = Combo.get_GetSelectedItemValue(cboType);
                CurrentCustomer.SetNotes = txtNotes.Text.Trim();
                CurrentCustomer.SetAccountNumber = txtAccountNumber.Text.Trim();
                CurrentCustomer.SetStatus = Combo.get_GetSelectedItemValue(cboStatus);
                CurrentCustomer.SetAcceptChargesChanges = chbAcceptChargeChanges.Checked;
                CurrentCustomer.SetMOTStyleService = chkMOTService.Checked;
                CurrentCustomer.SetIsOutOfScope = cbIsOutOfScope.Checked;
                CurrentCustomer.SetSuperBook = chkSuperBooking.Checked;
                CurrentCustomer.SetAlertEmail = txtAlertEmail.Text;
                if (txtMainContractorDiscount.Text.Trim().Length == 0)
                {
                    CurrentCustomer.SetMainContractorDiscount = 0;
                }
                else
                {
                    CurrentCustomer.SetMainContractorDiscount = txtMainContractorDiscount.Text;
                }

                CurrentCustomer.SetPoNumReqd = chkPONumReq.Checked;
                CurrentCustomer.SetJobPriorityMandatory = chkJobPriorityRequired.Checked;
                CurrentCustomer.SetNominal = txtNominal.Text;
                CurrentCustomer.SetSummerServ = txtServSummer.Text;
                CurrentCustomer.SetWinterServ = txtServWinter.Text;
                CurrentCustomer.SetIsPFH = chkIsPFH.Checked;
                string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDepartment));
                if (Helper.IsValidInteger(department) && !(Helper.MakeIntegerValid(department) <= 0))
                {
                    CurrentCustomer.SetOverrideDept = department;
                }
                else if (!Information.IsNumeric(department))
                {
                    CurrentCustomer.SetOverrideDept = department;
                }

                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboTerms)) > 0)
                {
                    CurrentCustomer.SetTerms = Combo.get_GetSelectedItemValue(cboTerms);
                }

                if (txtSpendLimit.Text.Trim().Length > 0)
                    CurrentCustomer.SetJobSpendLimit = Helper.MakeDoubleValid(txtSpendLimit.Text.Trim());
                var cV = new Entity.Customers.CustomerValidator();
                cV.Validate(CurrentCustomer);
                if (CurrentCustomer.Exists)
                {
                    App.DB.Customer.Update(CurrentCustomer);
                }
                else
                {
                    CurrentCustomer = App.DB.Customer.Insert(CurrentCustomer);
                }

                var customerCharges = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(CurrentCustomer.CustomerID);
                if (customerCharges is null)
                    customerCharges = new Entity.CustomerCharges.CustomerCharge();
                customerCharges.SetMileageRate = txtMileageRate.Text.Trim();
                customerCharges.SetPartsMarkup = txtPartsMarkup.Text.Trim();
                customerCharges.SetRatesMarkup = txtRatesMarkup.Text.Trim();
                customerCharges.SetCustomerID = CurrentCustomer.CustomerID;
                var ccV = new Entity.CustomerCharges.CustomerChargeValidator();
                ccV.Validate(customerCharges);
                if (customerCharges.Exists)
                {
                    App.DB.CustomerCharge.Update(customerCharges);
                }
                else
                {
                    customerCharges = App.DB.CustomerCharge.Insert(customerCharges);
                }

                App.CurrentCustomerID = CurrentCustomer.CustomerID;
                App.DB.Customer.Priorities_Delete_For_Customer(CurrentCustomer.CustomerID);
                foreach (DataGridViewRow dr in dgvPriority.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr.Cells["Tick"].Value, true, false)))
                    {
                        App.DB.Customer.Priorities_Insert_For_Customer(CurrentCustomer.CustomerID, Conversions.ToInteger(dr.Cells["ManagerID"].Value), Conversions.ToInteger(dr.Cells["TargetHours"].Value), Conversions.ToInteger(dr.Cells["IncludeWeekends"].Value), Conversions.ToInteger(dr.Cells["IncludeBH"].Value), Conversions.ToInteger(dr.Cells["IncludeOOH"].Value));
                    }
                }

                App.DB.Customer.Requirements_Delete_For_Customer(CurrentCustomer.CustomerID);
                foreach (DataRow dr in RequirementDataView.Table.Rows)
                {
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["Tick"], true, false)))
                    {
                        App.DB.Customer.Requirements_Insert_For_Customer(CurrentCustomer.CustomerID, Conversions.ToInteger(dr["ManagerID"]));
                    }
                }

                RecordsChanged?.Invoke(App.DB.Customer.Customer_GetAll_Light(App.loggedInUser.UserID), Enums.PageViewing.Customer, true, false, "");
                StateChanged?.Invoke(CurrentCustomer.CustomerID);
                App.MainForm.RefreshEntity(CurrentCustomer.CustomerID, "CustomerID");
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Constants.vbNewLine + "{0}{1}";
                msg = string.Format(msg, Constants.vbNewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSelectLogoImage_Click(object sender, EventArgs e)
        {
            try
            {
                var open = new OpenFileDialog();
                Image rawImage;
                open.Title = "Set Image File";
                open.Filter = "Image Files|*.bmp;*.Jpg;*.Gif";
                open.FileName = "";
                if (open.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                rawImage = Image.FromFile(open.FileName.ToString());
                var scaledImage = new Bitmap(226, 226, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                var gfxScaledImage = Graphics.FromImage(scaledImage);
                if (rawImage.Height > rawImage.Width)
                {
                    // Portrait
                    double scale = rawImage.Width / (double)rawImage.Height;
                    int width = (int)(rawImage.Width * scale);
                    int height = 226;
                    gfxScaledImage.Clear(Color.White);
                    gfxScaledImage.DrawImage(rawImage, 113 - width / 2, 0, width, height);
                }
                else if (rawImage.Height <= rawImage.Width)
                {
                    // Landscape

                    double scale = rawImage.Width / (double)rawImage.Height;
                    int width = 226;
                    int height = (int)(rawImage.Height * scale);
                    gfxScaledImage.Clear(Color.White);
                    gfxScaledImage.DrawImage(rawImage, 0, 113 - height / 2, width, height);
                }

                var memStreamPhoto = new MemoryStream();
                scaledImage.Save(memStreamPhoto, System.Drawing.Imaging.ImageFormat.Jpeg);
                picLogo.Image = scaledImage;
                CurrentCustomer.Logo = memStreamPhoto.GetBuffer();
                App.AnythingChanges(sender, e);
            }
            catch (Exception ex)
            {
                App.ShowMessage(ErrorMsg.ErrorOccured("Reading logo image"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgRequirement_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgRequirements.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgRequirements.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedRequirmentDataRow is null)
                {
                    return;
                }

                bool selected = !Helper.MakeBooleanValid(dgRequirements[dgRequirements.CurrentRowIndex, 0]);
                dgRequirements[dgRequirements.CurrentRowIndex, 0] = selected;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer.CustomerID == 0)
            {
                App.ShowMessage("You need to save the customer first!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FRMFindPart dialogue1;
            dialogue1 = (FRMFindPart)App.checkIfExists(typeof(FRMFindPart).Name, true);
            if (dialogue1 is null)
            {
                dialogue1 = (FRMFindPart)Activator.CreateInstance(typeof(FRMFindPart));
            }
            // dialogue1.Icon = New Icon(dialogue1.GetType(), "Logo.ico")
            dialogue1.ShowInTaskbar = false;
            dialogue1.TableToSearch = Enums.TableNames.tblPartSupplier;
            dialogue1.ShowDialog();
            DataRow[] datarows = null;
            if (dialogue1.DialogResult == DialogResult.OK)
            {
                datarows = dialogue1.Datarows;
            }
            else
            {
                return;
            }

            foreach (DataRow dr in datarows)
                App.DB.Customer.Part_Insert_For_Customer(CurrentCustomer.CustomerID, Conversions.ToInteger(dr["PartSupplierID"]));
            PartsDataView = App.DB.Part.Customer_Parts_GetAll(CurrentCustomer.CustomerID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvParts.SelectedRows[0].Index > -1)
            {
                foreach (DataGridViewRow dr in dgvParts.SelectedRows)
                    App.DB.Customer.Part_Delete_For_Customer(CurrentCustomer.CustomerID, Conversions.ToInteger(dr.Cells[0].Value));
                PartsDataView = App.DB.Part.Customer_Parts_GetAll(CurrentCustomer.CustomerID);
            }
        }

        private void dgRaiseEng_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRaiseEng.SelectedRows[0].Index > -1)
            {
                using (var dialogue1 = new FRMEngineerRaiseJob())
                {
                    var argcombo = dialogue1.cboEngineer;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(dgRaiseEng.SelectedRows[0].Cells["EngineerID"].Value));
                    dialogue1.chkSuper.Checked = Conversions.ToBoolean(dgRaiseEng.SelectedRows[0].Cells["Super"].Value);
                    dialogue1.ShowDialog();
                    if (dialogue1.DialogResult == DialogResult.OK)
                    {
                        App.DB.Customer.Customer_EngineerRaise_Update(CurrentCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(dialogue1.cboEngineer)), dialogue1.chkSuper.Checked, Conversions.ToInteger(dgRaiseEng.SelectedRows[0].Cells["RaiseJobCustomerEngineerID"].Value));
                    }
                }

                EngRaiseView = App.DB.Customer.Customer_EngineerRaise_Get(CurrentCustomer.CustomerID);
            }
        }

        private void btnEngAdd_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer.CustomerID == 0)
            {
                App.ShowMessage("You need to save the customer first!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var dialogue1 = new FRMEngineerRaiseJob())
            {
                dialogue1.ShowDialog();
                if (dialogue1.DialogResult == DialogResult.OK)
                {
                    App.DB.Customer.Customer_EngineerRaise_Insert(CurrentCustomer.CustomerID, Conversions.ToInteger(Combo.get_GetSelectedItemValue(dialogue1.cboEngineer)), dialogue1.chkSuper.Checked);
                }
            }

            EngRaiseView = App.DB.Customer.Customer_EngineerRaise_Get(CurrentCustomer.CustomerID);
        }

        private void btnEngDelete_Click(object sender, EventArgs e)
        {
            if (dgRaiseEng.SelectedRows[0].Index > -1)
            {
                foreach (DataGridViewRow dr in dgRaiseEng.SelectedRows)
                    App.DB.Customer.Customer_EngineerRaise_Delete(Conversions.ToInteger(dgRaiseEng.SelectedRows[0].Cells["RaiseJobCustomerEngineerID"].Value));
                EngRaiseView = App.DB.Customer.Customer_EngineerRaise_Get(CurrentCustomer.CustomerID);
            }
        }

        public void SetupCustomerAuthorityAuditDataGrid()
        {
            var tStyle = dgAuthorityAudit.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Action";
            Name.MappingName = "ActionChange";
            Name.ReadOnly = true;
            Name.Width = 350;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Date";
            Site.MappingName = "ActionDateTime";
            Site.ReadOnly = true;
            Site.Width = 100;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "User";
            Type.MappingName = "Fullname";
            Type.ReadOnly = true;
            Type.Width = 200;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblAuthority.ToString();
            dgAuthorityAudit.TableStyles.Add(tStyle);
        }

        private DataView _dvCustomerAuthorityAudit;

        private DataView CustomerAuthorityAuditDataView
        {
            get
            {
                return _dvCustomerAuthorityAudit;
            }

            set
            {
                _dvCustomerAuthorityAudit = value;
                _dvCustomerAuthorityAudit.AllowNew = false;
                _dvCustomerAuthorityAudit.AllowEdit = false;
                _dvCustomerAuthorityAudit.AllowDelete = false;
                _dvCustomerAuthorityAudit.Table.TableName = Enums.TableNames.tblAuthority.ToString();
                dgAuthorityAudit.DataSource = CustomerAuthorityAuditDataView;
            }
        }

        private void PopulateCustomerAuthority()
        {
            try
            {
                CustomerAuthority = App.DB.Authority.Get(CurrentCustomer.CustomerID, Entity.Authority.AuthoritySQL.GetBy.CustomerId);
                if (CustomerAuthority is object)
                {
                    txtCustAuthority.Text = CustomerAuthority.Notes;
                }

                CustomerAuthorityAuditDataView = App.DB.Authority.Audit_Get(CurrentCustomer.CustomerID, Entity.Authority.AuthoritySQL.GetBy.CustomerId);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveAuth_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustAuthority.Text))
                return;
            if (CustomerAuthority is null)
            {
                CustomerAuthority = new Entity.Authority.Authority();
                CustomerAuthority.SetNotes = txtCustAuthority.Text;
                App.DB.Authority.Insert_Customer(CurrentCustomer.CustomerID, CustomerAuthority);
            }
            else
            {
                string changes = string.Empty;
                if ((CustomerAuthority.Notes ?? "") != (txtCustAuthority.Text ?? ""))
                {
                    changes += "Changed: " + CustomerAuthority.Notes.Replace(Constants.vbCr, " ").Replace(Constants.vbLf, " ");
                }

                CustomerAuthority.SetNotes = txtCustAuthority.Text;
                App.DB.Authority.Update(CustomerAuthority, changes);
            }

            PopulateCustomerAuthority();
        }

        private void txtPartSearch_Change(object sender, EventArgs e)
        {
            RunFilter();
        }

        private void RunFilter()
        {
            string whereClause = "0 = 0";
            if (!(txtPartSearch.Text.Trim().Length == 0))
            {
                whereClause += " AND PartName LIKE '%" + txtPartSearch.Text.Trim() + "%' OR PartNumber LIKE '%" + txtPartSearch.Text.Trim() + "%' OR PartCode LIKE '%" + txtPartSearch.Text.Trim() + "%'";
            }

            PartsDataView.RowFilter = whereClause;
        }

        private void btnExportSites_Click(object sender, EventArgs e)
        {
            var dvSites = App.DB.Customer.Customer_GetAll_Sites(Helper.MakeIntegerValid(CurrentCustomer?.CustomerID));
            if (dvSites.Count > 0)
            {
                ExportHelper.Export(dvSites.Table, "Sites", Enums.ExportType.XLS);
            }
        }

        public List<Entity.Customers.CustomerAlert> CustomerAlerts { get; set; }
        public Entity.Customers.CustomerAlert CustomerAlert { get; set; }

        private DataView _dvCustomerAlerts = null;

        public DataView DvCustomerAlerts
        {
            get
            {
                return _dvCustomerAlerts;
            }

            set
            {
                _dvCustomerAlerts = value;
                if (_dvCustomerAlerts is object)
                {
                    _dvCustomerAlerts.Table.TableName = Enums.TableNames.tblContact.ToString();
                    _dvCustomerAlerts.AllowNew = false;
                    _dvCustomerAlerts.AllowEdit = false;
                    _dvCustomerAlerts.AllowDelete = false;
                }

                dgCustomerAlerts.DataSource = _dvCustomerAlerts;
            }
        }

        private DataRow DrSelectedCustomerAlert
        {
            get
            {
                if (dgCustomerAlerts.DataSource is object && !(dgCustomerAlerts.CurrentRowIndex == -1))
                {
                    return DvCustomerAlerts[dgCustomerAlerts.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        public void SetupCustomerAlertsDataGrid()
        {
            Helper.SetUpDataGrid(dgCustomerAlerts);
            var tStyle = dgCustomerAlerts.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgCustomerAlerts.ReadOnly = true;
            var alertType = new DataGridLabelColumn();
            alertType.Format = "";
            alertType.FormatInfo = null;
            alertType.HeaderText = "Alert Type";
            alertType.MappingName = "AlertType";
            alertType.ReadOnly = true;
            alertType.Width = 150;
            alertType.NullText = "";
            tStyle.GridColumnStyles.Add(alertType);
            var emailaddress = new DataGridLabelColumn();
            emailaddress.Format = "";
            emailaddress.FormatInfo = null;
            emailaddress.HeaderText = "Email Address(s)";
            emailaddress.MappingName = "EmailAddress";
            emailaddress.ReadOnly = true;
            emailaddress.Width = 400;
            emailaddress.NullText = "";
            tStyle.GridColumnStyles.Add(emailaddress);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblContact.ToString();
            dgCustomerAlerts.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgCustomerAlerts);
        }

        public void PopulateCustomerAlerts()
        {
            CustomerAlerts = App.DB.CustomerAlert.Get_ForCustomer((int)CurrentCustomer?.CustomerID);
            if (CustomerAlerts?.Count > 0 == true)
            {
                DvCustomerAlerts = new DataView(Helper.ToDataTable(CustomerAlerts));
            }
            else
            {
                DvCustomerAlerts = null;
            }
        }

        private void ResetCustomerAlerts()
        {
            CustomerAlert = null;
            btnDeleteCustomerAlert.Visible = false;
            cboAlertType.Enabled = true;
            txtCustomerAlertEmailAddress.Text = string.Empty;
            var argcombo = cboAlertType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
            PopulateCustomerAlerts();
        }

        private void btnSaveCustomerAlert_Click(object sender, EventArgs e)
        {
            if (CurrentCustomer?.CustomerID > 0 == true)
            {
                try
                {
                    if (CustomerAlert?.Id > 0 == true)
                    {
                        CustomerAlert.EmailAddress = txtCustomerAlertEmailAddress.Text.Trim();
                        App.DB.CustomerAlert.Update(CustomerAlert);
                        ResetCustomerAlerts();
                    }
                    else
                    {
                        CustomerAlert = new Entity.Customers.CustomerAlert();
                        {
                            var withBlock = CustomerAlert;
                            withBlock.CustomerId = CurrentCustomer.CustomerID;
                            withBlock.AlertTypeId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboAlertType));
                            withBlock.EmailAddress = txtCustomerAlertEmailAddress.Text.Trim();
                        }

                        if (CustomerAlerts?.Where(X => X.AlertTypeId == CustomerAlert.AlertTypeId).ToList().Count > 0 == true)
                        {
                            App.ShowMessage("Alert type already exists!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            CustomerAlert = App.DB.CustomerAlert.Insert(CustomerAlert);
                            ResetCustomerAlerts();
                        }
                    }

                    App.ShowMessage("Alert saved!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    App.ShowMessage(ex.Message + " - " + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCustomerAlert_Click(object sender, EventArgs e)
        {
            CustomerAlert = null;
            ResetCustomerAlerts();
        }

        private void dgCustomerAlerts_Click(object sender, EventArgs e)
        {
            if (DrSelectedCustomerAlert is null)
            {
                return;
            }
            else
            {
                CustomerAlert = App.DB.CustomerAlert.Get(Conversions.ToInteger(DrSelectedCustomerAlert["Id"]))?.FirstOrDefault();
                if (CustomerAlert?.Id > 0 == true)
                {
                    btnDeleteCustomerAlert.Visible = true;
                    cboAlertType.Enabled = false;
                    var argcombo = cboAlertType;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, CustomerAlert.AlertTypeId.ToString());
                    txtCustomerAlertEmailAddress.Text = CustomerAlert.EmailAddress.Trim();
                }
            }
        }

        private void btnDeleteCustomerAlert_Click(object sender, EventArgs e)
        {
            if (CustomerAlert?.Id > 0 == true)
            {
                App.DB.CustomerAlert.Delete(CustomerAlert);
                CustomerAlert = null;
                ResetCustomerAlerts();
                App.ShowMessage("Alert removed!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}