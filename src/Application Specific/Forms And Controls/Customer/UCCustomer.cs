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
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

        public UCCustomer() : base()
        {
            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        internal GroupBox grpCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCustomer != null)
                {
                }

                _grpCustomer = value;
                if (_grpCustomer != null)
                {
                }
            }
        }

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

        internal Label lblRegionID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRegionID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRegionID != null)
                {
                }

                _lblRegionID = value;
                if (_lblRegionID != null)
                {
                }
            }
        }

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

        internal Label lblNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblNotes != null)
                {
                }

                _lblNotes = value;
                if (_lblNotes != null)
                {
                }
            }
        }

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

        internal Label lblAccountNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccountNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccountNumber != null)
                {
                }

                _lblAccountNumber = value;
                if (_lblAccountNumber != null)
                {
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
                }

                _cboStatus = value;
                if (_cboStatus != null)
                {
                }
            }
        }

        private Label _lblStatus;

        internal Label lblStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStatus != null)
                {
                }

                _lblStatus = value;
                if (_lblStatus != null)
                {
                }
            }
        }

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

        internal TabPage tabDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabDocuments != null)
                {
                }

                _tabDocuments = value;
                if (_tabDocuments != null)
                {
                }
            }
        }

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

        internal TabPage tabContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabContracts != null)
                {
                }

                _tabContracts = value;
                if (_tabContracts != null)
                {
                }
            }
        }

        private Panel _pnlContracts;

        internal Panel pnlContracts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pnlContracts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pnlContracts != null)
                {
                }

                _pnlContracts = value;
                if (_pnlContracts != null)
                {
                }
            }
        }

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

        internal GroupBox grbCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grbCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grbCharges != null)
                {
                }

                _grbCharges = value;
                if (_grbCharges != null)
                {
                }
            }
        }

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

        internal Button btnDeleteContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnDeleteContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnDeleteContract != null)
                {
                    _btnDeleteContract.Click -= btnDeleteContract_Click;
                }

                _btnDeleteContract = value;
                if (_btnDeleteContract != null)
                {
                    _btnDeleteContract.Click += btnDeleteContract_Click;
                }
            }
        }

        private ContextMenu _cmnuContractOptions;

        internal ContextMenu cmnuContractOptions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmnuContractOptions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmnuContractOptions != null)
                {
                }

                _cmnuContractOptions = value;
                if (_cmnuContractOptions != null)
                {
                }
            }
        }

        private MenuItem _mnuContractOpt1;

        internal MenuItem mnuContractOpt1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuContractOpt1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuContractOpt1 != null)
                {
                    _mnuContractOpt1.Click -= mnuContractOpt1_Click;
                }

                _mnuContractOpt1 = value;
                if (_mnuContractOpt1 != null)
                {
                    _mnuContractOpt1.Click += mnuContractOpt1_Click;
                }
            }
        }

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

        internal Button btnSelectLogoImage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSelectLogoImage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSelectLogoImage != null)
                {
                    _btnSelectLogoImage.Click -= btnSelectLogoImage_Click;
                }

                _btnSelectLogoImage = value;
                if (_btnSelectLogoImage != null)
                {
                    _btnSelectLogoImage.Click += btnSelectLogoImage_Click;
                }
            }
        }

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

        private TabPage _tabPriority;

        internal TabPage tabPriority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabPriority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabPriority != null)
                {
                }

                _tabPriority = value;
                if (_tabPriority != null)
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
                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
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

        internal Button btnEngAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEngAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEngAdd != null)
                {
                    _btnEngAdd.Click -= btnEngAdd_Click;
                }

                _btnEngAdd = value;
                if (_btnEngAdd != null)
                {
                    _btnEngAdd.Click += btnEngAdd_Click;
                }
            }
        }

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

        internal TabPage tabAuthority
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabAuthority;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabAuthority != null)
                {
                }

                _tabAuthority = value;
                if (_tabAuthority != null)
                {
                }
            }
        }

        private GroupBox _gpCustAuth;

        internal GroupBox gpCustAuth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpCustAuth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpCustAuth != null)
                {
                }

                _gpCustAuth = value;
                if (_gpCustAuth != null)
                {
                }
            }
        }

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

        internal Button btnSaveAuth
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveAuth;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveAuth != null)
                {
                    _btnSaveAuth.Click -= btnSaveAuth_Click;
                }

                _btnSaveAuth = value;
                if (_btnSaveAuth != null)
                {
                    _btnSaveAuth.Click += btnSaveAuth_Click;
                }
            }
        }

        private GroupBox _grpAudit;

        internal GroupBox grpAudit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAudit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAudit != null)
                {
                }

                _grpAudit = value;
                if (_grpAudit != null)
                {
                }
            }
        }

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

        internal Button btnExportSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExportSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExportSites != null)
                {
                    _btnExportSites.Click -= btnExportSites_Click;
                }

                _btnExportSites = value;
                if (_btnExportSites != null)
                {
                    _btnExportSites.Click += btnExportSites_Click;
                }
            }
        }

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

        internal Label lblJobSpendLimit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblJobSpendLimit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblJobSpendLimit != null)
                {
                }

                _lblJobSpendLimit = value;
                if (_lblJobSpendLimit != null)
                {
                }
            }
        }

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

        internal TabPage tabAlerts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabAlerts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabAlerts != null)
                {
                }

                _tabAlerts = value;
                if (_tabAlerts != null)
                {
                }
            }
        }

        private GroupBox _grpCustomerAlerts;

        internal GroupBox grpCustomerAlerts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpCustomerAlerts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpCustomerAlerts != null)
                {
                }

                _grpCustomerAlerts = value;
                if (_grpCustomerAlerts != null)
                {
                }
            }
        }

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

        internal GroupBox grpSite
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSite;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSite != null)
                {
                }

                _grpSite = value;
                if (_grpSite != null)
                {
                }
            }
        }

        private Button _btnSaveCustomerAlert;

        internal Button btnSaveCustomerAlert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSaveCustomerAlert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSaveCustomerAlert != null)
                {
                    _btnSaveCustomerAlert.Click -= btnSaveCustomerAlert_Click;
                }

                _btnSaveCustomerAlert = value;
                if (_btnSaveCustomerAlert != null)
                {
                    _btnSaveCustomerAlert.Click += btnSaveCustomerAlert_Click;
                }
            }
        }

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

        internal Label lblCustomerAlertEmailAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCustomerAlertEmailAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCustomerAlertEmailAddress != null)
                {
                }

                _lblCustomerAlertEmailAddress = value;
                if (_lblCustomerAlertEmailAddress != null)
                {
                }
            }
        }

        private Label _lblAlertType;

        internal Label lblAlertType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAlertType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAlertType != null)
                {
                }

                _lblAlertType = value;
                if (_lblAlertType != null)
                {
                }
            }
        }

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

        internal Label lblEmailAddressMsg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEmailAddressMsg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEmailAddressMsg != null)
                {
                }

                _lblEmailAddressMsg = value;
                if (_lblEmailAddressMsg != null)
                {
                }
            }
        }

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

        internal Button btnAddCustomerAlert
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddCustomerAlert;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddCustomerAlert != null)
                {
                    _btnAddCustomerAlert.Click -= btnAddCustomerAlert_Click;
                }

                _btnAddCustomerAlert = value;
                if (_btnAddCustomerAlert != null)
                {
                    _btnAddCustomerAlert.Click += btnAddCustomerAlert_Click;
                }
            }
        }

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
            components = new System.ComponentModel.Container();
            _grpCustomer = new GroupBox();
            _chkIsPFH = new CheckBox();
            _cbIsOutOfScope = new CheckBox();
            _btnExportSites = new Button();
            _btnExportSites.Click += new EventHandler(btnExportSites_Click);
            _chkMOTService = new CheckBox();
            _txtAlertEmail = new TextBox();
            _Label13 = new Label();
            _txtServWinter = new TextBox();
            _txtServSummer = new TextBox();
            _Label12 = new Label();
            _chkSuperBooking = new CheckBox();
            _cboTerms = new ComboBox();
            _Label9 = new Label();
            _cboDepartment = new ComboBox();
            _Label8 = new Label();
            _txtNominal = new TextBox();
            _Label7 = new Label();
            _chkJobPriorityRequired = new CheckBox();
            _chkPONumReq = new CheckBox();
            _btnSelectLogoImage = new Button();
            _btnSelectLogoImage.Click += new EventHandler(btnSelectLogoImage_Click);
            _picLogo = new PictureBox();
            _Label6 = new Label();
            _cboType = new ComboBox();
            _Label2 = new Label();
            _txtName = new TextBox();
            _lblName = new Label();
            _cboRegionID = new ComboBox();
            _lblRegionID = new Label();
            _txtNotes = new TextBox();
            _lblNotes = new Label();
            _txtAccountNumber = new TextBox();
            _lblAccountNumber = new Label();
            _cboStatus = new ComboBox();
            _lblStatus = new Label();
            _TabControl1 = new TabControl();
            _tabMainDetails = new TabPage();
            _tabContracts = new TabPage();
            _pnlContracts = new Panel();
            _gpbContracts = new GroupBox();
            _btnDeleteContract = new Button();
            _btnDeleteContract.Click += new EventHandler(btnDeleteContract_Click);
            _dgContracts = new DataGrid();
            _dgContracts.DoubleClick += new EventHandler(dgContracts_DoubleClick);
            _btnAddContract = new Button();
            _btnAddContract.Click += new EventHandler(btnAddContract_Click);
            _tabCharges = new TabPage();
            _grbCharges = new GroupBox();
            _txtSpendLimit = new TextBox();
            _lblJobSpendLimit = new Label();
            _txtMainContractorDiscount = new TextBox();
            _Label5 = new Label();
            _chbAcceptChargeChanges = new CheckBox();
            _Label3 = new Label();
            _txtRatesMarkup = new TextBox();
            _Label4 = new Label();
            _Label1 = new Label();
            _txtMileageRate = new TextBox();
            _txtPartsMarkup = new TextBox();
            _pnlCharges = new Panel();
            _tabDocuments = new TabPage();
            _pnlDocuments = new Panel();
            _tabQuotes = new TabPage();
            _pnlQuotes = new Panel();
            _tabPriority = new TabPage();
            _dgvPriority = new DataGridView();
            _Label11 = new Label();
            _dgRequirements = new DataGrid();
            _dgRequirements.MouseUp += new MouseEventHandler(dgRequirement_MouseUp);
            _Label10 = new Label();
            _tabParts = new TabPage();
            _Label14 = new Label();
            _txtPartSearch = new TextBox();
            _txtPartSearch.TextChanged += new EventHandler(txtPartSearch_Change);
            _btnDelete = new Button();
            _btnDelete.Click += new EventHandler(btnDelete_Click);
            _btnAdd = new Button();
            _btnAdd.Click += new EventHandler(btnAdd_Click);
            _dgvParts = new DataGridView();
            _tabServiceDates = new TabPage();
            _tabCreation = new TabPage();
            _btnEngDelete = new Button();
            _btnEngDelete.Click += new EventHandler(btnEngDelete_Click);
            _btnEngAdd = new Button();
            _btnEngAdd.Click += new EventHandler(btnEngAdd_Click);
            _dgRaiseEng = new DataGridView();
            _dgRaiseEng.CellDoubleClick += new DataGridViewCellEventHandler(dgRaiseEng_CellContentClick);
            _tabAuthority = new TabPage();
            _grpAudit = new GroupBox();
            _dgAuthorityAudit = new DataGrid();
            _gpCustAuth = new GroupBox();
            _btnSaveAuth = new Button();
            _btnSaveAuth.Click += new EventHandler(btnSaveAuth_Click);
            _txtCustAuthority = new TextBox();
            _tabAlerts = new TabPage();
            _grpCustomerAlerts = new GroupBox();
            _grpSite = new GroupBox();
            _btnAddCustomerAlert = new Button();
            _btnAddCustomerAlert.Click += new EventHandler(btnAddCustomerAlert_Click);
            _btnDeleteCustomerAlert = new Button();
            _btnDeleteCustomerAlert.Click += new EventHandler(btnDeleteCustomerAlert_Click);
            _txtCustomerAlertEmailAddress = new TextBox();
            _lblEmailAddressMsg = new Label();
            _btnSaveCustomerAlert = new Button();
            _btnSaveCustomerAlert.Click += new EventHandler(btnSaveCustomerAlert_Click);
            _cboAlertType = new ComboBox();
            _lblCustomerAlertEmailAddress = new Label();
            _lblAlertType = new Label();
            _dgCustomerAlerts = new DataGrid();
            _dgCustomerAlerts.Click += new EventHandler(dgCustomerAlerts_Click);
            _cmnuContractOptions = new ContextMenu();
            _mnuContractOpt1 = new MenuItem();
            _mnuContractOpt1.Click += new EventHandler(mnuContractOpt1_Click);
            _tt = new ToolTip(components);
            _pnlServiceProcess = new Panel();
            _grpCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_picLogo).BeginInit();
            _TabControl1.SuspendLayout();
            _tabMainDetails.SuspendLayout();
            _tabContracts.SuspendLayout();
            _pnlContracts.SuspendLayout();
            _gpbContracts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgContracts).BeginInit();
            _tabCharges.SuspendLayout();
            _grbCharges.SuspendLayout();
            _tabDocuments.SuspendLayout();
            _tabQuotes.SuspendLayout();
            _tabPriority.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvPriority).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_dgRequirements).BeginInit();
            _tabParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvParts).BeginInit();
            _tabServiceDates.SuspendLayout();
            _tabCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgRaiseEng).BeginInit();
            _tabAuthority.SuspendLayout();
            _grpAudit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgAuthorityAudit).BeginInit();
            _gpCustAuth.SuspendLayout();
            _tabAlerts.SuspendLayout();
            _grpCustomerAlerts.SuspendLayout();
            _grpSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCustomerAlerts).BeginInit();
            SuspendLayout();
            //
            // grpCustomer
            //
            _grpCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpCustomer.Controls.Add(_chkIsPFH);
            _grpCustomer.Controls.Add(_cbIsOutOfScope);
            _grpCustomer.Controls.Add(_btnExportSites);
            _grpCustomer.Controls.Add(_chkMOTService);
            _grpCustomer.Controls.Add(_txtAlertEmail);
            _grpCustomer.Controls.Add(_Label13);
            _grpCustomer.Controls.Add(_txtServWinter);
            _grpCustomer.Controls.Add(_txtServSummer);
            _grpCustomer.Controls.Add(_Label12);
            _grpCustomer.Controls.Add(_chkSuperBooking);
            _grpCustomer.Controls.Add(_cboTerms);
            _grpCustomer.Controls.Add(_Label9);
            _grpCustomer.Controls.Add(_cboDepartment);
            _grpCustomer.Controls.Add(_Label8);
            _grpCustomer.Controls.Add(_txtNominal);
            _grpCustomer.Controls.Add(_Label7);
            _grpCustomer.Controls.Add(_chkJobPriorityRequired);
            _grpCustomer.Controls.Add(_chkPONumReq);
            _grpCustomer.Controls.Add(_btnSelectLogoImage);
            _grpCustomer.Controls.Add(_picLogo);
            _grpCustomer.Controls.Add(_Label6);
            _grpCustomer.Controls.Add(_cboType);
            _grpCustomer.Controls.Add(_Label2);
            _grpCustomer.Controls.Add(_txtName);
            _grpCustomer.Controls.Add(_lblName);
            _grpCustomer.Controls.Add(_cboRegionID);
            _grpCustomer.Controls.Add(_lblRegionID);
            _grpCustomer.Controls.Add(_txtNotes);
            _grpCustomer.Controls.Add(_lblNotes);
            _grpCustomer.Controls.Add(_txtAccountNumber);
            _grpCustomer.Controls.Add(_lblAccountNumber);
            _grpCustomer.Controls.Add(_cboStatus);
            _grpCustomer.Controls.Add(_lblStatus);
            _grpCustomer.Location = new Point(9, 8);
            _grpCustomer.Name = "grpCustomer";
            _grpCustomer.Size = new Size(629, 558);
            _grpCustomer.TabIndex = 0;
            _grpCustomer.TabStop = false;
            _grpCustomer.Text = "Details";
            //
            // chkIsPFH
            //
            _chkIsPFH.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _chkIsPFH.AutoSize = true;
            _chkIsPFH.Location = new Point(555, 353);
            _chkIsPFH.Name = "chkIsPFH";
            _chkIsPFH.RightToLeft = RightToLeft.Yes;
            _chkIsPFH.Size = new Size(62, 17);
            _chkIsPFH.TabIndex = 58;
            _chkIsPFH.Text = "Is PFH";
            _chkIsPFH.UseVisualStyleBackColor = true;
            //
            // cbIsOutOfScope
            //
            _cbIsOutOfScope.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _cbIsOutOfScope.AutoSize = true;
            _cbIsOutOfScope.Location = new Point(516, 376);
            _cbIsOutOfScope.Name = "cbIsOutOfScope";
            _cbIsOutOfScope.RightToLeft = RightToLeft.Yes;
            _cbIsOutOfScope.Size = new Size(102, 17);
            _cbIsOutOfScope.TabIndex = 57;
            _cbIsOutOfScope.Text = "Out Of Scope";
            _cbIsOutOfScope.UseVisualStyleBackColor = true;
            //
            // btnExportSites
            //
            _btnExportSites.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnExportSites.Location = new Point(6, 527);
            _btnExportSites.Name = "btnExportSites";
            _btnExportSites.Size = new Size(103, 25);
            _btnExportSites.TabIndex = 56;
            _btnExportSites.Text = "Export Sites";
            //
            // chkMOTService
            //
            _chkMOTService.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _chkMOTService.AutoSize = true;
            _chkMOTService.Location = new Point(479, 398);
            _chkMOTService.Name = "chkMOTService";
            _chkMOTService.RightToLeft = RightToLeft.Yes;
            _chkMOTService.Size = new Size(139, 17);
            _chkMOTService.TabIndex = 55;
            _chkMOTService.Text = "M.O.T Style Service";
            _chkMOTService.UseVisualStyleBackColor = true;
            //
            // txtAlertEmail
            //
            _txtAlertEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAlertEmail.Location = new Point(120, 261);
            _txtAlertEmail.MaxLength = 255;
            _txtAlertEmail.Name = "txtAlertEmail";
            _txtAlertEmail.Size = new Size(498, 21);
            _txtAlertEmail.TabIndex = 54;
            _txtAlertEmail.Tag = "Customer.Name";
            //
            // Label13
            //
            _Label13.Location = new Point(8, 264);
            _Label13.Name = "Label13";
            _Label13.Size = new Size(89, 20);
            _Label13.TabIndex = 53;
            _Label13.Text = "Alert Email";
            //
            // txtServWinter
            //
            _txtServWinter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtServWinter.Location = new Point(540, 520);
            _txtServWinter.MaxLength = 50;
            _txtServWinter.Name = "txtServWinter";
            _txtServWinter.Size = new Size(77, 21);
            _txtServWinter.TabIndex = 52;
            _txtServWinter.Tag = " ";
            //
            // txtServSummer
            //
            _txtServSummer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _txtServSummer.Location = new Point(415, 520);
            _txtServSummer.MaxLength = 50;
            _txtServSummer.Name = "txtServSummer";
            _txtServSummer.Size = new Size(77, 21);
            _txtServSummer.TabIndex = 51;
            _txtServSummer.Tag = " ";
            //
            // Label12
            //
            _Label12.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label12.Location = new Point(270, 514);
            _Label12.Name = "Label12";
            _Label12.Size = new Size(113, 27);
            _Label12.TabIndex = 50;
            _Label12.Text = "Summer/Winter Servicing P/Month";
            //
            // chkSuperBooking
            //
            _chkSuperBooking.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _chkSuperBooking.AutoSize = true;
            _chkSuperBooking.Location = new Point(444, 464);
            _chkSuperBooking.Name = "chkSuperBooking";
            _chkSuperBooking.RightToLeft = RightToLeft.Yes;
            _chkSuperBooking.Size = new Size(174, 17);
            _chkSuperBooking.TabIndex = 49;
            _chkSuperBooking.Text = "Coordinator Booking Only";
            _chkSuperBooking.UseVisualStyleBackColor = true;
            //
            // cboTerms
            //
            _cboTerms.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboTerms.Cursor = Cursors.Hand;
            _cboTerms.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboTerms.Location = new Point(120, 227);
            _cboTerms.Name = "cboTerms";
            _cboTerms.Size = new Size(498, 21);
            _cboTerms.TabIndex = 48;
            _cboTerms.Tag = "Customer.Status";
            //
            // Label9
            //
            _Label9.Location = new Point(8, 226);
            _Label9.Name = "Label9";
            _Label9.Size = new Size(103, 20);
            _Label9.TabIndex = 47;
            _Label9.Text = "Terms";
            //
            // cboDepartment
            //
            _cboDepartment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _cboDepartment.Cursor = Cursors.Hand;
            _cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDepartment.Location = new Point(415, 488);
            _cboDepartment.Name = "cboDepartment";
            _cboDepartment.Size = new Size(203, 21);
            _cboDepartment.TabIndex = 46;
            _cboDepartment.Tag = "Customer.TypeID";
            //
            // Label8
            //
            _Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _Label8.Location = new Point(270, 491);
            _Label8.Name = "Label8";
            _Label8.Size = new Size(139, 23);
            _Label8.TabIndex = 45;
            _Label8.Text = "Override Department";
            //
            // txtNominal
            //
            _txtNominal.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtNominal.Location = new Point(120, 193);
            _txtNominal.MaxLength = 50;
            _txtNominal.Name = "txtNominal";
            _txtNominal.Size = new Size(498, 21);
            _txtNominal.TabIndex = 11;
            _txtNominal.Tag = " ";
            //
            // Label7
            //
            _Label7.Location = new Point(8, 196);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(103, 20);
            _Label7.TabIndex = 10;
            _Label7.Text = "Nominal Code";
            //
            // chkJobPriorityRequired
            //
            _chkJobPriorityRequired.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _chkJobPriorityRequired.AutoSize = true;
            _chkJobPriorityRequired.Location = new Point(473, 442);
            _chkJobPriorityRequired.Name = "chkJobPriorityRequired";
            _chkJobPriorityRequired.RightToLeft = RightToLeft.Yes;
            _chkJobPriorityRequired.Size = new Size(145, 17);
            _chkJobPriorityRequired.TabIndex = 17;
            _chkJobPriorityRequired.Text = "Job Priority Required";
            _chkJobPriorityRequired.UseVisualStyleBackColor = true;
            //
            // chkPONumReq
            //
            _chkPONumReq.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _chkPONumReq.AutoSize = true;
            _chkPONumReq.Location = new Point(472, 420);
            _chkPONumReq.Name = "chkPONumReq";
            _chkPONumReq.RightToLeft = RightToLeft.Yes;
            _chkPONumReq.Size = new Size(146, 17);
            _chkPONumReq.TabIndex = 16;
            _chkPONumReq.Text = "PO Number Required";
            _chkPONumReq.UseVisualStyleBackColor = true;
            //
            // btnSelectLogoImage
            //
            _btnSelectLogoImage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnSelectLogoImage.Location = new Point(263, 416);
            _btnSelectLogoImage.Name = "btnSelectLogoImage";
            _btnSelectLogoImage.Size = new Size(31, 23);
            _btnSelectLogoImage.TabIndex = 15;
            _btnSelectLogoImage.Text = "...";
            _btnSelectLogoImage.UseVisualStyleBackColor = true;
            //
            // picLogo
            //
            _picLogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _picLogo.BackColor = Color.White;
            _picLogo.BorderStyle = BorderStyle.FixedSingle;
            _picLogo.Location = new Point(120, 417);
            _picLogo.Name = "picLogo";
            _picLogo.Size = new Size(135, 135);
            _picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            _picLogo.TabIndex = 44;
            _picLogo.TabStop = false;
            //
            // Label6
            //
            _Label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _Label6.Location = new Point(8, 423);
            _Label6.Name = "Label6";
            _Label6.Size = new Size(62, 20);
            _Label6.TabIndex = 14;
            _Label6.Text = "Logo";
            //
            // cboType
            //
            _cboType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboType.Cursor = Cursors.Hand;
            _cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboType.Location = new Point(120, 57);
            _cboType.Name = "cboType";
            _cboType.Size = new Size(498, 21);
            _cboType.TabIndex = 3;
            _cboType.Tag = "Customer.TypeID";
            //
            // Label2
            //
            _Label2.Location = new Point(8, 60);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(66, 23);
            _Label2.TabIndex = 2;
            _Label2.Text = "Type";
            //
            // txtName
            //
            _txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtName.Location = new Point(120, 23);
            _txtName.MaxLength = 255;
            _txtName.Name = "txtName";
            _txtName.Size = new Size(498, 21);
            _txtName.TabIndex = 1;
            _txtName.Tag = "Customer.Name";
            //
            // lblName
            //
            _lblName.Location = new Point(8, 26);
            _lblName.Name = "lblName";
            _lblName.Size = new Size(53, 20);
            _lblName.TabIndex = 0;
            _lblName.Text = "Name";
            //
            // cboRegionID
            //
            _cboRegionID.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboRegionID.Cursor = Cursors.Hand;
            _cboRegionID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboRegionID.Location = new Point(120, 91);
            _cboRegionID.Name = "cboRegionID";
            _cboRegionID.Size = new Size(498, 21);
            _cboRegionID.TabIndex = 5;
            _cboRegionID.Tag = "Customer.RegionID";
            //
            // lblRegionID
            //
            _lblRegionID.Location = new Point(8, 94);
            _lblRegionID.Name = "lblRegionID";
            _lblRegionID.Size = new Size(55, 20);
            _lblRegionID.TabIndex = 4;
            _lblRegionID.Text = "Region ";
            //
            // txtNotes
            //
            _txtNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtNotes.Location = new Point(120, 295);
            _txtNotes.Multiline = true;
            _txtNotes.Name = "txtNotes";
            _txtNotes.ScrollBars = ScrollBars.Vertical;
            _txtNotes.Size = new Size(497, 50);
            _txtNotes.TabIndex = 13;
            _txtNotes.Tag = "Customer.Notes";
            //
            // lblNotes
            //
            _lblNotes.Location = new Point(8, 298);
            _lblNotes.Name = "lblNotes";
            _lblNotes.Size = new Size(62, 20);
            _lblNotes.TabIndex = 12;
            _lblNotes.Text = "Notes";
            //
            // txtAccountNumber
            //
            _txtAccountNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _txtAccountNumber.Location = new Point(120, 125);
            _txtAccountNumber.MaxLength = 50;
            _txtAccountNumber.Name = "txtAccountNumber";
            _txtAccountNumber.Size = new Size(498, 21);
            _txtAccountNumber.TabIndex = 7;
            _txtAccountNumber.Tag = "Customer.AccountNumber";
            //
            // lblAccountNumber
            //
            _lblAccountNumber.Location = new Point(8, 128);
            _lblAccountNumber.Name = "lblAccountNumber";
            _lblAccountNumber.Size = new Size(103, 20);
            _lblAccountNumber.TabIndex = 6;
            _lblAccountNumber.Text = "Account Number";
            //
            // cboStatus
            //
            _cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _cboStatus.Cursor = Cursors.Hand;
            _cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboStatus.Location = new Point(120, 159);
            _cboStatus.Name = "cboStatus";
            _cboStatus.Size = new Size(498, 21);
            _cboStatus.TabIndex = 9;
            _cboStatus.Tag = "Customer.Status";
            //
            // lblStatus
            //
            _lblStatus.Location = new Point(8, 162);
            _lblStatus.Name = "lblStatus";
            _lblStatus.Size = new Size(65, 20);
            _lblStatus.TabIndex = 8;
            _lblStatus.Text = "Status";
            //
            // TabControl1
            //
            _TabControl1.Controls.Add(_tabMainDetails);
            _TabControl1.Controls.Add(_tabContracts);
            _TabControl1.Controls.Add(_tabCharges);
            _TabControl1.Controls.Add(_tabDocuments);
            _TabControl1.Controls.Add(_tabQuotes);
            _TabControl1.Controls.Add(_tabPriority);
            _TabControl1.Controls.Add(_tabParts);
            _TabControl1.Controls.Add(_tabServiceDates);
            _TabControl1.Controls.Add(_tabCreation);
            _TabControl1.Controls.Add(_tabAuthority);
            _TabControl1.Controls.Add(_tabAlerts);
            _TabControl1.Dock = DockStyle.Fill;
            _TabControl1.Location = new Point(0, 0);
            _TabControl1.Name = "TabControl1";
            _TabControl1.SelectedIndex = 0;
            _TabControl1.Size = new Size(653, 600);
            _TabControl1.TabIndex = 0;
            //
            // tabMainDetails
            //
            _tabMainDetails.Controls.Add(_grpCustomer);
            _tabMainDetails.Location = new Point(4, 22);
            _tabMainDetails.Name = "tabMainDetails";
            _tabMainDetails.Size = new Size(645, 574);
            _tabMainDetails.TabIndex = 0;
            _tabMainDetails.Text = "Main Details";
            //
            // tabContracts
            //
            _tabContracts.Controls.Add(_pnlContracts);
            _tabContracts.Location = new Point(4, 22);
            _tabContracts.Name = "tabContracts";
            _tabContracts.Size = new Size(645, 574);
            _tabContracts.TabIndex = 4;
            _tabContracts.Text = "Contracts";
            //
            // pnlContracts
            //
            _pnlContracts.Controls.Add(_gpbContracts);
            _pnlContracts.Dock = DockStyle.Fill;
            _pnlContracts.Location = new Point(0, 0);
            _pnlContracts.Name = "pnlContracts";
            _pnlContracts.Size = new Size(645, 574);
            _pnlContracts.TabIndex = 1;
            //
            // gpbContracts
            //
            _gpbContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _gpbContracts.Controls.Add(_btnDeleteContract);
            _gpbContracts.Controls.Add(_dgContracts);
            _gpbContracts.Controls.Add(_btnAddContract);
            _gpbContracts.Location = new Point(8, 8);
            _gpbContracts.Name = "gpbContracts";
            _gpbContracts.Size = new Size(632, 555);
            _gpbContracts.TabIndex = 0;
            _gpbContracts.TabStop = false;
            _gpbContracts.Text = "Contract - Double click to view";
            //
            // btnDeleteContract
            //
            _btnDeleteContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnDeleteContract.Location = new Point(549, 523);
            _btnDeleteContract.Name = "btnDeleteContract";
            _btnDeleteContract.Size = new Size(75, 23);
            _btnDeleteContract.TabIndex = 2;
            _btnDeleteContract.Text = "Delete";
            //
            // dgContracts
            //
            _dgContracts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgContracts.DataMember = "";
            _dgContracts.HeaderForeColor = SystemColors.ControlText;
            _dgContracts.Location = new Point(8, 16);
            _dgContracts.Name = "dgContracts";
            _dgContracts.Size = new Size(616, 499);
            _dgContracts.TabIndex = 1;
            //
            // btnAddContract
            //
            _btnAddContract.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnAddContract.Location = new Point(8, 523);
            _btnAddContract.Name = "btnAddContract";
            _btnAddContract.Size = new Size(75, 23);
            _btnAddContract.TabIndex = 0;
            _btnAddContract.Text = "Add";
            _btnAddContract.UseVisualStyleBackColor = true;
            //
            // tabCharges
            //
            _tabCharges.Controls.Add(_grbCharges);
            _tabCharges.Location = new Point(4, 22);
            _tabCharges.Name = "tabCharges";
            _tabCharges.Size = new Size(645, 574);
            _tabCharges.TabIndex = 7;
            _tabCharges.Text = "Charges";
            //
            // grbCharges
            //
            _grbCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grbCharges.Controls.Add(_txtSpendLimit);
            _grbCharges.Controls.Add(_lblJobSpendLimit);
            _grbCharges.Controls.Add(_txtMainContractorDiscount);
            _grbCharges.Controls.Add(_Label5);
            _grbCharges.Controls.Add(_chbAcceptChargeChanges);
            _grbCharges.Controls.Add(_Label3);
            _grbCharges.Controls.Add(_txtRatesMarkup);
            _grbCharges.Controls.Add(_Label4);
            _grbCharges.Controls.Add(_Label1);
            _grbCharges.Controls.Add(_txtMileageRate);
            _grbCharges.Controls.Add(_txtPartsMarkup);
            _grbCharges.Controls.Add(_pnlCharges);
            _grbCharges.Location = new Point(8, 0);
            _grbCharges.Name = "grbCharges";
            _grbCharges.Size = new Size(633, 571);
            _grbCharges.TabIndex = 0;
            _grbCharges.TabStop = false;
            _grbCharges.Text = "Charges";
            //
            // txtSpendLimit
            //
            _txtSpendLimit.Location = new Point(122, 70);
            _txtSpendLimit.Name = "txtSpendLimit";
            _txtSpendLimit.Size = new Size(64, 21);
            _txtSpendLimit.TabIndex = 78;
            //
            // lblJobSpendLimit
            //
            _lblJobSpendLimit.AutoSize = true;
            _lblJobSpendLimit.Location = new Point(8, 73);
            _lblJobSpendLimit.Name = "lblJobSpendLimit";
            _lblJobSpendLimit.Size = new Size(108, 13);
            _lblJobSpendLimit.TabIndex = 77;
            _lblJobSpendLimit.Text = "Job Spend Limit £";
            //
            // txtMainContractorDiscount
            //
            _txtMainContractorDiscount.Location = new Point(461, 72);
            _txtMainContractorDiscount.Name = "txtMainContractorDiscount";
            _txtMainContractorDiscount.Size = new Size(64, 21);
            _txtMainContractorDiscount.TabIndex = 8;
            //
            // Label5
            //
            _Label5.Location = new Point(278, 73);
            _Label5.Name = "Label5";
            _Label5.Size = new Size(176, 21);
            _Label5.TabIndex = 7;
            _Label5.Text = "Main Contractor Discount %";
            //
            // chbAcceptChargeChanges
            //
            _chbAcceptChargeChanges.BackColor = SystemColors.Info;
            _chbAcceptChargeChanges.Location = new Point(8, 16);
            _chbAcceptChargeChanges.Name = "chbAcceptChargeChanges";
            _chbAcceptChargeChanges.Size = new Size(480, 24);
            _chbAcceptChargeChanges.TabIndex = 0;
            _chbAcceptChargeChanges.Text = "Always accept changes to default charges made at system level";
            _chbAcceptChargeChanges.UseVisualStyleBackColor = false;
            //
            // Label3
            //
            _Label3.Location = new Point(368, 48);
            _Label3.Name = "Label3";
            _Label3.Size = new Size(93, 21);
            _Label3.TabIndex = 5;
            _Label3.Text = "Rates Markup";
            //
            // txtRatesMarkup
            //
            _txtRatesMarkup.Location = new Point(461, 48);
            _txtRatesMarkup.Name = "txtRatesMarkup";
            _txtRatesMarkup.Size = new Size(64, 21);
            _txtRatesMarkup.TabIndex = 6;
            //
            // Label4
            //
            _Label4.Location = new Point(8, 48);
            _Label4.Name = "Label4";
            _Label4.Size = new Size(97, 21);
            _Label4.TabIndex = 1;
            _Label4.Text = "Labour Markup";
            //
            // Label1
            //
            _Label1.Location = new Point(210, 48);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(90, 21);
            _Label1.TabIndex = 3;
            _Label1.Text = "Parts Markup";
            //
            // txtMileageRate
            //
            _txtMileageRate.Location = new Point(122, 48);
            _txtMileageRate.Name = "txtMileageRate";
            _txtMileageRate.Size = new Size(64, 21);
            _txtMileageRate.TabIndex = 2;
            //
            // txtPartsMarkup
            //
            _txtPartsMarkup.Location = new Point(301, 48);
            _txtPartsMarkup.Name = "txtPartsMarkup";
            _txtPartsMarkup.Size = new Size(62, 21);
            _txtPartsMarkup.TabIndex = 4;
            //
            // pnlCharges
            //
            _pnlCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _pnlCharges.Location = new Point(8, 97);
            _pnlCharges.Name = "pnlCharges";
            _pnlCharges.Size = new Size(617, 466);
            _pnlCharges.TabIndex = 9;
            //
            // tabDocuments
            //
            _tabDocuments.Controls.Add(_pnlDocuments);
            _tabDocuments.Location = new Point(4, 22);
            _tabDocuments.Name = "tabDocuments";
            _tabDocuments.Size = new Size(645, 574);
            _tabDocuments.TabIndex = 2;
            _tabDocuments.Text = "Documents";
            //
            // pnlDocuments
            //
            _pnlDocuments.Dock = DockStyle.Fill;
            _pnlDocuments.Location = new Point(0, 0);
            _pnlDocuments.Name = "pnlDocuments";
            _pnlDocuments.Size = new Size(645, 574);
            _pnlDocuments.TabIndex = 1;
            //
            // tabQuotes
            //
            _tabQuotes.Controls.Add(_pnlQuotes);
            _tabQuotes.Location = new Point(4, 22);
            _tabQuotes.Name = "tabQuotes";
            _tabQuotes.Size = new Size(645, 574);
            _tabQuotes.TabIndex = 5;
            _tabQuotes.Text = "Quotes";
            //
            // pnlQuotes
            //
            _pnlQuotes.Dock = DockStyle.Fill;
            _pnlQuotes.Location = new Point(0, 0);
            _pnlQuotes.Name = "pnlQuotes";
            _pnlQuotes.Size = new Size(645, 574);
            _pnlQuotes.TabIndex = 1;
            //
            // tabPriority
            //
            _tabPriority.Controls.Add(_dgvPriority);
            _tabPriority.Controls.Add(_Label11);
            _tabPriority.Controls.Add(_dgRequirements);
            _tabPriority.Controls.Add(_Label10);
            _tabPriority.Location = new Point(4, 22);
            _tabPriority.Name = "tabPriority";
            _tabPriority.Size = new Size(645, 574);
            _tabPriority.TabIndex = 8;
            _tabPriority.Text = "Priorities / Requirements";
            _tabPriority.UseVisualStyleBackColor = true;
            //
            // dgvPriority
            //
            _dgvPriority.AllowUserToAddRows = false;
            _dgvPriority.AllowUserToDeleteRows = false;
            _dgvPriority.AllowUserToResizeColumns = false;
            _dgvPriority.AllowUserToResizeRows = false;
            _dgvPriority.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvPriority.Location = new Point(37, 70);
            _dgvPriority.MultiSelect = false;
            _dgvPriority.Name = "dgvPriority";
            _dgvPriority.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvPriority.Size = new Size(456, 170);
            _dgvPriority.TabIndex = 10;
            //
            // Label11
            //
            _Label11.Location = new Point(34, 294);
            _Label11.Name = "Label11";
            _Label11.Size = new Size(103, 20);
            _Label11.TabIndex = 9;
            _Label11.Text = "Requirements";
            //
            // dgRequirements
            //
            _dgRequirements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgRequirements.DataMember = "";
            _dgRequirements.HeaderForeColor = SystemColors.ControlText;
            _dgRequirements.Location = new Point(37, 317);
            _dgRequirements.Name = "dgRequirements";
            _dgRequirements.Size = new Size(592, 196);
            _dgRequirements.TabIndex = 8;
            //
            // Label10
            //
            _Label10.Location = new Point(34, 47);
            _Label10.Name = "Label10";
            _Label10.Size = new Size(103, 20);
            _Label10.TabIndex = 7;
            _Label10.Text = "Priorities";
            //
            // tabParts
            //
            _tabParts.Controls.Add(_Label14);
            _tabParts.Controls.Add(_txtPartSearch);
            _tabParts.Controls.Add(_btnDelete);
            _tabParts.Controls.Add(_btnAdd);
            _tabParts.Controls.Add(_dgvParts);
            _tabParts.Location = new Point(4, 22);
            _tabParts.Name = "tabParts";
            _tabParts.Size = new Size(645, 574);
            _tabParts.TabIndex = 9;
            _tabParts.Text = "Associated Supplier Parts";
            _tabParts.UseVisualStyleBackColor = true;
            //
            // Label14
            //
            _Label14.AutoSize = true;
            _Label14.Location = new Point(3, 34);
            _Label14.Name = "Label14";
            _Label14.Size = new Size(47, 13);
            _Label14.TabIndex = 4;
            _Label14.Text = "Search";
            //
            // txtPartSearch
            //
            _txtPartSearch.Location = new Point(82, 31);
            _txtPartSearch.Name = "txtPartSearch";
            _txtPartSearch.Size = new Size(560, 21);
            _txtPartSearch.TabIndex = 3;
            //
            // btnDelete
            //
            _btnDelete.Location = new Point(58, 408);
            _btnDelete.Name = "btnDelete";
            _btnDelete.Size = new Size(61, 23);
            _btnDelete.TabIndex = 2;
            _btnDelete.Text = "Delete";
            _btnDelete.UseVisualStyleBackColor = true;
            //
            // btnAdd
            //
            _btnAdd.Location = new Point(532, 406);
            _btnAdd.Name = "btnAdd";
            _btnAdd.Size = new Size(65, 25);
            _btnAdd.TabIndex = 1;
            _btnAdd.Text = "Add";
            _btnAdd.UseVisualStyleBackColor = true;
            //
            // dgvParts
            //
            _dgvParts.AllowUserToAddRows = false;
            _dgvParts.AllowUserToDeleteRows = false;
            _dgvParts.AllowUserToOrderColumns = true;
            _dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgvParts.Location = new Point(3, 62);
            _dgvParts.Name = "dgvParts";
            _dgvParts.ReadOnly = true;
            _dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvParts.ShowCellErrors = false;
            _dgvParts.Size = new Size(639, 340);
            _dgvParts.TabIndex = 0;
            //
            // tabServiceDates
            //
            _tabServiceDates.BackColor = SystemColors.Control;
            _tabServiceDates.Controls.Add(_pnlServiceProcess);
            _tabServiceDates.Location = new Point(4, 22);
            _tabServiceDates.Name = "tabServiceDates";
            _tabServiceDates.Size = new Size(645, 574);
            _tabServiceDates.TabIndex = 10;
            _tabServiceDates.Text = "Service Dates";
            //
            // tabCreation
            //
            _tabCreation.Controls.Add(_btnEngDelete);
            _tabCreation.Controls.Add(_btnEngAdd);
            _tabCreation.Controls.Add(_dgRaiseEng);
            _tabCreation.Location = new Point(4, 22);
            _tabCreation.Name = "tabCreation";
            _tabCreation.Size = new Size(645, 574);
            _tabCreation.TabIndex = 10;
            _tabCreation.Text = "Engineer Job Creation";
            _tabCreation.UseVisualStyleBackColor = true;
            //
            // btnEngDelete
            //
            _btnEngDelete.Location = new Point(58, 429);
            _btnEngDelete.Name = "btnEngDelete";
            _btnEngDelete.Size = new Size(61, 23);
            _btnEngDelete.TabIndex = 5;
            _btnEngDelete.Text = "Delete";
            _btnEngDelete.UseVisualStyleBackColor = true;
            //
            // btnEngAdd
            //
            _btnEngAdd.Location = new Point(384, 429);
            _btnEngAdd.Name = "btnEngAdd";
            _btnEngAdd.Size = new Size(65, 25);
            _btnEngAdd.TabIndex = 4;
            _btnEngAdd.Text = "Add";
            _btnEngAdd.UseVisualStyleBackColor = true;
            //
            // dgRaiseEng
            //
            _dgRaiseEng.AllowUserToAddRows = false;
            _dgRaiseEng.AllowUserToDeleteRows = false;
            _dgRaiseEng.AllowUserToOrderColumns = true;
            _dgRaiseEng.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgRaiseEng.Location = new Point(3, 83);
            _dgRaiseEng.Name = "dgRaiseEng";
            _dgRaiseEng.ReadOnly = true;
            _dgRaiseEng.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgRaiseEng.ShowCellErrors = false;
            _dgRaiseEng.Size = new Size(503, 340);
            _dgRaiseEng.TabIndex = 3;
            //
            // tabAuthority
            //
            _tabAuthority.Controls.Add(_grpAudit);
            _tabAuthority.Controls.Add(_gpCustAuth);
            _tabAuthority.Location = new Point(4, 22);
            _tabAuthority.Name = "tabAuthority";
            _tabAuthority.Size = new Size(645, 574);
            _tabAuthority.TabIndex = 11;
            _tabAuthority.Text = "Authority";
            _tabAuthority.UseVisualStyleBackColor = true;
            //
            // grpAudit
            //
            _grpAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpAudit.Controls.Add(_dgAuthorityAudit);
            _grpAudit.Location = new Point(3, 236);
            _grpAudit.Name = "grpAudit";
            _grpAudit.Size = new Size(639, 335);
            _grpAudit.TabIndex = 38;
            _grpAudit.TabStop = false;
            _grpAudit.Text = "Audit";
            //
            // dgAuthorityAudit
            //
            _dgAuthorityAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgAuthorityAudit.DataMember = "";
            _dgAuthorityAudit.HeaderForeColor = SystemColors.ControlText;
            _dgAuthorityAudit.Location = new Point(6, 20);
            _dgAuthorityAudit.Name = "dgAuthorityAudit";
            _dgAuthorityAudit.Size = new Size(627, 309);
            _dgAuthorityAudit.TabIndex = 1;
            //
            // gpCustAuth
            //
            _gpCustAuth.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpCustAuth.Controls.Add(_btnSaveAuth);
            _gpCustAuth.Controls.Add(_txtCustAuthority);
            _gpCustAuth.Location = new Point(3, 3);
            _gpCustAuth.Name = "gpCustAuth";
            _gpCustAuth.Size = new Size(639, 227);
            _gpCustAuth.TabIndex = 37;
            _gpCustAuth.TabStop = false;
            _gpCustAuth.Text = "Customer";
            //
            // btnSaveAuth
            //
            _btnSaveAuth.AccessibleDescription = "";
            _btnSaveAuth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveAuth.Location = new Point(548, 191);
            _btnSaveAuth.Name = "btnSaveAuth";
            _btnSaveAuth.Size = new Size(85, 23);
            _btnSaveAuth.TabIndex = 4;
            _btnSaveAuth.Text = "Save";
            //
            // txtCustAuthority
            //
            _txtCustAuthority.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtCustAuthority.Location = new Point(6, 20);
            _txtCustAuthority.Multiline = true;
            _txtCustAuthority.Name = "txtCustAuthority";
            _txtCustAuthority.ScrollBars = ScrollBars.Both;
            _txtCustAuthority.Size = new Size(627, 156);
            _txtCustAuthority.TabIndex = 0;
            //
            // tabAlerts
            //
            _tabAlerts.Controls.Add(_grpCustomerAlerts);
            _tabAlerts.Location = new Point(4, 22);
            _tabAlerts.Name = "tabAlerts";
            _tabAlerts.Size = new Size(645, 574);
            _tabAlerts.TabIndex = 12;
            _tabAlerts.Text = "Alerts";
            _tabAlerts.UseVisualStyleBackColor = true;
            //
            // grpCustomerAlerts
            //
            _grpCustomerAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpCustomerAlerts.Controls.Add(_grpSite);
            _grpCustomerAlerts.Controls.Add(_dgCustomerAlerts);
            _grpCustomerAlerts.Location = new Point(13, 14);
            _grpCustomerAlerts.Margin = new Padding(0);
            _grpCustomerAlerts.Name = "grpCustomerAlerts";
            _grpCustomerAlerts.Padding = new Padding(0);
            _grpCustomerAlerts.Size = new Size(620, 547);
            _grpCustomerAlerts.TabIndex = 15;
            _grpCustomerAlerts.TabStop = false;
            _grpCustomerAlerts.Text = "Alerts";
            //
            // grpSite
            //
            _grpSite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _grpSite.Controls.Add(_btnAddCustomerAlert);
            _grpSite.Controls.Add(_btnDeleteCustomerAlert);
            _grpSite.Controls.Add(_txtCustomerAlertEmailAddress);
            _grpSite.Controls.Add(_lblEmailAddressMsg);
            _grpSite.Controls.Add(_btnSaveCustomerAlert);
            _grpSite.Controls.Add(_cboAlertType);
            _grpSite.Controls.Add(_lblCustomerAlertEmailAddress);
            _grpSite.Controls.Add(_lblAlertType);
            _grpSite.Location = new Point(14, 287);
            _grpSite.Name = "grpSite";
            _grpSite.Size = new Size(592, 248);
            _grpSite.TabIndex = 115;
            _grpSite.TabStop = false;
            _grpSite.Text = "Alert";
            //
            // btnAddCustomerAlert
            //
            _btnAddCustomerAlert.AccessibleDescription = "";
            _btnAddCustomerAlert.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddCustomerAlert.Location = new Point(555, 18);
            _btnAddCustomerAlert.Name = "btnAddCustomerAlert";
            _btnAddCustomerAlert.Size = new Size(31, 28);
            _btnAddCustomerAlert.TabIndex = 131;
            _btnAddCustomerAlert.Text = "+";
            _tt.SetToolTip(_btnAddCustomerAlert, "Add new alert");
            //
            // btnDeleteCustomerAlert
            //
            _btnDeleteCustomerAlert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            _btnDeleteCustomerAlert.Location = new Point(9, 210);
            _btnDeleteCustomerAlert.Name = "btnDeleteCustomerAlert";
            _btnDeleteCustomerAlert.Size = new Size(81, 23);
            _btnDeleteCustomerAlert.TabIndex = 130;
            _btnDeleteCustomerAlert.Text = "Delete";
            _btnDeleteCustomerAlert.Visible = false;
            //
            // txtCustomerAlertEmailAddress
            //
            _txtCustomerAlertEmailAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _txtCustomerAlertEmailAddress.Location = new Point(9, 131);
            _txtCustomerAlertEmailAddress.Multiline = true;
            _txtCustomerAlertEmailAddress.Name = "txtCustomerAlertEmailAddress";
            _txtCustomerAlertEmailAddress.ScrollBars = ScrollBars.Vertical;
            _txtCustomerAlertEmailAddress.Size = new Size(577, 62);
            _txtCustomerAlertEmailAddress.TabIndex = 129;
            _txtCustomerAlertEmailAddress.Tag = "Customer.Notes";
            //
            // lblEmailAddressMsg
            //
            _lblEmailAddressMsg.Font = new Font("Verdana", 8.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblEmailAddressMsg.Location = new Point(6, 63);
            _lblEmailAddressMsg.Name = "lblEmailAddressMsg";
            _lblEmailAddressMsg.Size = new Size(566, 29);
            _lblEmailAddressMsg.TabIndex = 128;
            _lblEmailAddressMsg.Text = "Please seperate each email address with a semi-colon;";
            //
            // btnSaveCustomerAlert
            //
            _btnSaveCustomerAlert.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _btnSaveCustomerAlert.Location = new Point(505, 210);
            _btnSaveCustomerAlert.Name = "btnSaveCustomerAlert";
            _btnSaveCustomerAlert.Size = new Size(81, 23);
            _btnSaveCustomerAlert.TabIndex = 127;
            _btnSaveCustomerAlert.Text = "Save";
            //
            // cboAlertType
            //
            _cboAlertType.Cursor = Cursors.Hand;
            _cboAlertType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboAlertType.Location = new Point(117, 20);
            _cboAlertType.Name = "cboAlertType";
            _cboAlertType.Size = new Size(161, 21);
            _cboAlertType.TabIndex = 126;
            _cboAlertType.Tag = "";
            //
            // lblCustomerAlertEmailAddress
            //
            _lblCustomerAlertEmailAddress.Location = new Point(6, 105);
            _lblCustomerAlertEmailAddress.Name = "lblCustomerAlertEmailAddress";
            _lblCustomerAlertEmailAddress.Size = new Size(112, 23);
            _lblCustomerAlertEmailAddress.TabIndex = 125;
            _lblCustomerAlertEmailAddress.Text = "Email Address(s):";
            //
            // lblAlertType
            //
            _lblAlertType.Location = new Point(6, 23);
            _lblAlertType.Name = "lblAlertType";
            _lblAlertType.Size = new Size(80, 23);
            _lblAlertType.TabIndex = 123;
            _lblAlertType.Text = "Alert Type:";
            //
            // dgCustomerAlerts
            //
            _dgCustomerAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgCustomerAlerts.DataMember = "";
            _dgCustomerAlerts.HeaderForeColor = SystemColors.ControlText;
            _dgCustomerAlerts.Location = new Point(14, 19);
            _dgCustomerAlerts.Name = "dgCustomerAlerts";
            _dgCustomerAlerts.Size = new Size(592, 262);
            _dgCustomerAlerts.TabIndex = 11;
            //
            // cmnuContractOptions
            //
            _cmnuContractOptions.MenuItems.AddRange(new MenuItem[] { _mnuContractOpt1 });
            //
            // mnuContractOpt1
            //
            _mnuContractOpt1.Index = 0;
            _mnuContractOpt1.Text = "Contract Opt. 1";
            //
            // pnlServiceProcess
            //
            _pnlServiceProcess.Dock = DockStyle.Fill;
            _pnlServiceProcess.Location = new Point(0, 0);
            _pnlServiceProcess.Name = "pnlServiceProcess";
            _pnlServiceProcess.Size = new Size(645, 574);
            _pnlServiceProcess.TabIndex = 2;
            //
            // UCCustomer
            //
            Controls.Add(_TabControl1);
            Name = "UCCustomer";
            Size = new Size(653, 600);
            _grpCustomer.ResumeLayout(false);
            _grpCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_picLogo).EndInit();
            _TabControl1.ResumeLayout(false);
            _tabMainDetails.ResumeLayout(false);
            _tabContracts.ResumeLayout(false);
            _pnlContracts.ResumeLayout(false);
            _gpbContracts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgContracts).EndInit();
            _tabCharges.ResumeLayout(false);
            _grbCharges.ResumeLayout(false);
            _grbCharges.PerformLayout();
            _tabDocuments.ResumeLayout(false);
            _tabQuotes.ResumeLayout(false);
            _tabPriority.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgvPriority).EndInit();
            ((System.ComponentModel.ISupportInitialize)_dgRequirements).EndInit();
            _tabParts.ResumeLayout(false);
            _tabParts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgvParts).EndInit();
            _tabServiceDates.ResumeLayout(false);
            _tabCreation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgRaiseEng).EndInit();
            _tabAuthority.ResumeLayout(false);
            _grpAudit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgAuthorityAudit).EndInit();
            _gpCustAuth.ResumeLayout(false);
            _gpCustAuth.PerformLayout();
            _tabAlerts.ResumeLayout(false);
            _grpCustomerAlerts.ResumeLayout(false);
            _grpSite.ResumeLayout(false);
            _grpSite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgCustomerAlerts).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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
            dgvParts.Sort(Supplier, System.ComponentModel.ListSortDirection.Descending);
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
            cmnuContractOptions.Show(btnAddContract, new Point(0, -30));
        }

        private void mnuContractOpt1_Click(object sender, EventArgs e)
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
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedContractDataRow["ContractType"], Enums.QuoteType.Contract_Opt_2.ToString(), false)))
            {
                deleteContract = DeleteOption2();
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(SelectedContractDataRow["ContractType"], Enums.QuoteType.Contract_Opt_3.ToString(), false)))
            {
                deleteContract = DeleteOption3();
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */

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

        private bool DeleteOption2()
        {
            // DELETE Visit, Jobs - not sync, Job Assets, PPM Visits, Contract Site Assets, Contract Sites
            var sites = new DataView();
            sites = App.DB.ContractAlternativeSite.GetAll_ContractID(Conversions.ToInteger(SelectedContractDataRow["ContractID"]), CurrentCustomer.CustomerID);
            bool DeleteContract = true;
            foreach (DataRow r in sites.Table.Rows)
            {
                if (App.DB.ContractAlternativeSite.Delete(Conversions.ToInteger(r["ContractSiteID"])) > 0)
                {
                    DeleteContract = false;
                }
            }

            if (DeleteContract)
            {
                App.DB.ContractAlternative.Delete(Helper.MakeIntegerValid(SelectedContractDataRow["ContractID"]));
            }

            return DeleteContract;
        }

        private bool DeleteOption3()
        {
            // DELETE Visit, Jobs - not sync, Job Assets, PPM Visits, Contract Site Assets, Contract Sites
            var sites = new DataView();
            sites = App.DB.ContractOption3Site.ContractOption3Site_GetAll_ForContract(Conversions.ToInteger(SelectedContractDataRow["ContractID"]), CurrentCustomer.CustomerID);
            bool DeleteContract = true;
            foreach (DataRow r in sites.Table.Rows)
            {
                if (App.DB.ContractOption3Site.Delete(Conversions.ToInteger(r["ContractSiteID"])) > 0)
                {
                    DeleteContract = false;
                }
            }

            if (DeleteContract)
            {
                App.DB.ContractOption3.Delete(Helper.MakeIntegerValid(SelectedContractDataRow["ContractID"]));
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