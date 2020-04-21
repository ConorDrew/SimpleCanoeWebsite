using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCContractOriginal : UCBase, IUserControl
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public UCContractOriginal() : base()
        {

            /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            base.Load += UCContract_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            SetupSitesDataGrid();
            var argc = cboInvoiceFrequencyID;
            Combo.SetUpCombo(ref argc, DynamicDataTables.InvoiceFrequency_NoWeekly, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc1 = cboContractStatusID;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.ContractStatus, "ValueMember", "DisplayMember", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc2 = cboContractType;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.ContractTypes).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc3 = cboReasonID;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.CancellationReasons).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc4 = cboDiscount;
            Combo.SetUpCombo(ref argc4, App.DB.Picklists.GetAll(Entity.Sys.Enums.PickListTypes.CoverPlanDiscounts).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc5 = cboInvType;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)65).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
            var argc6 = cboPaidBy;
            Combo.SetUpCombo(ref argc6, App.DB.Picklists.GetAll((Entity.Sys.Enums.PickListTypes)66).Table, "ManagerID", "Name", Entity.Sys.Enums.ComboValues.Please_Select);
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

        private GroupBox _grpContract;

        internal GroupBox grpContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContract != null)
                {
                }

                _grpContract = value;
                if (_grpContract != null)
                {
                }
            }
        }

        private DateTimePicker _dtpContractStartDate;

        internal DateTimePicker dtpContractStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpContractStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpContractStartDate != null)
                {
                }

                _dtpContractStartDate = value;
                if (_dtpContractStartDate != null)
                {
                }
            }
        }

        private Label _lblContractStartDate;

        internal Label lblContractStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractStartDate != null)
                {
                }

                _lblContractStartDate = value;
                if (_lblContractStartDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpContractEndDate;

        internal DateTimePicker dtpContractEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpContractEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpContractEndDate != null)
                {
                }

                _dtpContractEndDate = value;
                if (_dtpContractEndDate != null)
                {
                }
            }
        }

        private Label _lblContractEndDate;

        internal Label lblContractEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractEndDate != null)
                {
                }

                _lblContractEndDate = value;
                if (_lblContractEndDate != null)
                {
                }
            }
        }

        private ComboBox _cboContractStatusID;

        internal ComboBox cboContractStatusID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboContractStatusID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboContractStatusID != null)
                {
                    _cboContractStatusID.SelectedIndexChanged -= cboContractStatusID_SelectedIndexChanged;
                }

                _cboContractStatusID = value;
                if (_cboContractStatusID != null)
                {
                    _cboContractStatusID.SelectedIndexChanged += cboContractStatusID_SelectedIndexChanged;
                }
            }
        }

        private Label _lblContractStatusID;

        internal Label lblContractStatusID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractStatusID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractStatusID != null)
                {
                }

                _lblContractStatusID = value;
                if (_lblContractStatusID != null)
                {
                }
            }
        }

        private TextBox _txtContractPrice;

        internal TextBox txtContractPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractPrice != null)
                {
                    _txtContractPrice.LostFocus -= txtContractPrice_LostFocus;
                }

                _txtContractPrice = value;
                if (_txtContractPrice != null)
                {
                    _txtContractPrice.LostFocus += txtContractPrice_LostFocus;
                }
            }
        }

        private Label _lblContractPrice;

        internal Label lblContractPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractPrice != null)
                {
                }

                _lblContractPrice = value;
                if (_lblContractPrice != null)
                {
                }
            }
        }

        private ComboBox _cboInvoiceFrequencyID;

        internal ComboBox cboInvoiceFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInvoiceFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInvoiceFrequencyID != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    _cboInvoiceFrequencyID.SelectedIndexChanged -= cboInvoiceFrequencyID_SelectedIndexChanged;
                }

                _cboInvoiceFrequencyID = value;
                if (_cboInvoiceFrequencyID != null)
                {
                    _cboInvoiceFrequencyID.SelectedIndexChanged += cboInvoiceFrequencyID_SelectedIndexChanged;
                }
            }
        }

        private Label _lblInvoiceFrequencyID;

        internal Label lblInvoiceFrequencyID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceFrequencyID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceFrequencyID != null)
                {
                }

                _lblInvoiceFrequencyID = value;
                if (_lblInvoiceFrequencyID != null)
                {
                }
            }
        }

        private GroupBox _grpSites;

        internal GroupBox grpSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpSites != null)
                {
                }

                _grpSites = value;
                if (_grpSites != null)
                {
                }
            }
        }

        private DataGrid _dgSites;

        internal DataGrid dgSites
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSites;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSites != null)
                {
                    _dgSites.MouseUp -= dgSites_MouseUp;
                    _dgSites.DoubleClick -= dgSites_DoubleClick;
                    _dgSites.Navigate -= dgSites_Navigate;
                }

                _dgSites = value;
                if (_dgSites != null)
                {
                    _dgSites.MouseUp += dgSites_MouseUp;
                    _dgSites.DoubleClick += dgSites_DoubleClick;
                    _dgSites.Navigate += dgSites_Navigate;
                }
            }
        }

        private Label _lblMsg;

        internal Label lblMsg
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMsg;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMsg != null)
                {
                }

                _lblMsg = value;
                if (_lblMsg != null)
                {
                }
            }
        }

        private Label _lblFirstInvoiceDate;

        internal Label lblFirstInvoiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFirstInvoiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFirstInvoiceDate != null)
                {
                }

                _lblFirstInvoiceDate = value;
                if (_lblFirstInvoiceDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpFirstInvoiceDate;

        internal DateTimePicker dtpFirstInvoiceDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpFirstInvoiceDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpFirstInvoiceDate != null)
                {
                }

                _dtpFirstInvoiceDate = value;
                if (_dtpFirstInvoiceDate != null)
                {
                }
            }
        }

        private GroupBox _gpbInvoiceAddress;

        internal GroupBox gpbInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbInvoiceAddress != null)
                {
                }

                _gpbInvoiceAddress = value;
                if (_gpbInvoiceAddress != null)
                {
                }
            }
        }

        private DataGrid _dgInvoiceAddress;

        internal DataGrid dgInvoiceAddress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgInvoiceAddress;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgInvoiceAddress != null)
                {
                    _dgInvoiceAddress.Click -= dgInvoiceAddress_Click;
                }

                _dgInvoiceAddress = value;
                if (_dgInvoiceAddress != null)
                {
                    _dgInvoiceAddress.Click += dgInvoiceAddress_Click;
                }
            }
        }

        private Label _lblContractType;

        internal Label lblContractType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractType != null)
                {
                }

                _lblContractType = value;
                if (_lblContractType != null)
                {
                }
            }
        }

        private ComboBox _cboContractType;

        internal ComboBox cboContractType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboContractType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboContractType != null)
                {
                    _cboContractType.SelectedIndexChanged -= cboContractType_SelectedIndexChanged;
                }

                _cboContractType = value;
                if (_cboContractType != null)
                {
                    _cboContractType.SelectedIndexChanged += cboContractType_SelectedIndexChanged;
                }
            }
        }

        private TabControl _tcBottomSection;

        internal TabControl tcBottomSection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcBottomSection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcBottomSection != null)
                {
                }

                _tcBottomSection = value;
                if (_tcBottomSection != null)
                {
                }
            }
        }

        private TabPage _tabProperties;

        internal TabPage tabProperties
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabProperties;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabProperties != null)
                {
                }

                _tabProperties = value;
                if (_tabProperties != null)
                {
                }
            }
        }

        private TabPage _tabChargeDetails;

        internal TabPage tabChargeDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabChargeDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabChargeDetails != null)
                {
                }

                _tabChargeDetails = value;
                if (_tabChargeDetails != null)
                {
                }
            }
        }

        private GroupBox _gpbChargeDetails;

        internal GroupBox gpbChargeDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbChargeDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbChargeDetails != null)
                {
                }

                _gpbChargeDetails = value;
                if (_gpbChargeDetails != null)
                {
                }
            }
        }

        private RadioButton _rdoCheque;

        internal RadioButton rdoCheque
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoCheque;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoCheque != null)
                {
                }

                _rdoCheque = value;
                if (_rdoCheque != null)
                {
                }
            }
        }

        private RadioButton _rdoCreditCard;

        internal RadioButton rdoCreditCard
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoCreditCard;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoCreditCard != null)
                {
                }

                _rdoCreditCard = value;
                if (_rdoCreditCard != null)
                {
                }
            }
        }

        private RadioButton _rdoDirectDebit;

        internal RadioButton rdoDirectDebit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoDirectDebit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoDirectDebit != null)
                {
                }

                _rdoDirectDebit = value;
                if (_rdoDirectDebit != null)
                {
                }
            }
        }

        private TextBox _txtBankName;

        internal TextBox txtBankName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtBankName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtBankName != null)
                {
                }

                _txtBankName = value;
                if (_txtBankName != null)
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

        private TextBox _txtSortCode;

        internal TextBox txtSortCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSortCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSortCode != null)
                {
                }

                _txtSortCode = value;
                if (_txtSortCode != null)
                {
                }
            }
        }

        private Label _lblBankName;

        internal Label lblBankName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblBankName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblBankName != null)
                {
                }

                _lblBankName = value;
                if (_lblBankName != null)
                {
                }
            }
        }

        private Label _lblAccount;

        internal Label lblAccount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccount != null)
                {
                }

                _lblAccount = value;
                if (_lblAccount != null)
                {
                }
            }
        }

        private CheckBox _chkGasSupplyPipework;

        internal CheckBox chkGasSupplyPipework
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkGasSupplyPipework;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkGasSupplyPipework != null)
                {
                }

                _chkGasSupplyPipework = value;
                if (_chkGasSupplyPipework != null)
                {
                }
            }
        }

        private Label _lblCancelledDate;

        internal Label lblCancelledDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCancelledDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCancelledDate != null)
                {
                }

                _lblCancelledDate = value;
                if (_lblCancelledDate != null)
                {
                }
            }
        }

        private DateTimePicker _dtpCancelledDate;

        internal DateTimePicker dtpCancelledDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpCancelledDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpCancelledDate != null)
                {
                }

                _dtpCancelledDate = value;
                if (_dtpCancelledDate != null)
                {
                }
            }
        }

        private CheckBox _chkPlumbingDrainage;

        internal CheckBox chkPlumbingDrainage
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPlumbingDrainage;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPlumbingDrainage != null)
                {
                }

                _chkPlumbingDrainage = value;
                if (_chkPlumbingDrainage != null)
                {
                }
            }
        }

        private CheckBox _chkWindowLockPest;

        internal CheckBox chkWindowLockPest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkWindowLockPest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkWindowLockPest != null)
                {
                }

                _chkWindowLockPest = value;
                if (_chkWindowLockPest != null)
                {
                }
            }
        }

        private TextBox _txtPONumber;

        internal TextBox txtPONumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPONumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPONumber != null)
                {
                }

                _txtPONumber = value;
                if (_txtPONumber != null)
                {
                }
            }
        }

        private Label _lblPONumber;

        internal Label lblPONumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPONumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPONumber != null)
                {
                }

                _lblPONumber = value;
                if (_lblPONumber != null)
                {
                }
            }
        }

        private TextBox _txtContractReference;

        internal TextBox txtContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtContractReference != null)
                {
                }

                _txtContractReference = value;
                if (_txtContractReference != null)
                {
                }
            }
        }

        private Label _lblContractReference;

        internal Label lblContractReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractReference != null)
                {
                }

                _lblContractReference = value;
                if (_lblContractReference != null)
                {
                }
            }
        }

        private CheckBox _cboDoNotRenew;

        internal CheckBox cboDoNotRenew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDoNotRenew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDoNotRenew != null)
                {
                }

                _cboDoNotRenew = value;
                if (_cboDoNotRenew != null)
                {
                }
            }
        }

        private TextBox _txtDDMSRef;

        internal TextBox txtDDMSRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDDMSRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDDMSRef != null)
                {
                }

                _txtDDMSRef = value;
                if (_txtDDMSRef != null)
                {
                }
            }
        }

        private Label _lblDDMSRef;

        internal Label lblDDMSRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDDMSRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDDMSRef != null)
                {
                }

                _lblDDMSRef = value;
                if (_lblDDMSRef != null)
                {
                }
            }
        }

        private Label _lblDiscount;

        internal Label lblDiscount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblDiscount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblDiscount != null)
                {
                }

                _lblDiscount = value;
                if (_lblDiscount != null)
                {
                }
            }
        }

        private ComboBox _cboDiscount;

        internal ComboBox cboDiscount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDiscount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDiscount != null)
                {
                }

                _cboDiscount = value;
                if (_cboDiscount != null)
                {
                }
            }
        }

        private ComboBox _cboReasonID;

        internal ComboBox cboReasonID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboReasonID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboReasonID != null)
                {
                    _cboReasonID.SelectedIndexChanged -= cboReasonID_SelectedIndexChanged_1;
                }

                _cboReasonID = value;
                if (_cboReasonID != null)
                {
                    _cboReasonID.SelectedIndexChanged += cboReasonID_SelectedIndexChanged_1;
                }
            }
        }

        private Label _lblReason;

        internal Label lblReason
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblReason;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblReason != null)
                {
                }

                _lblReason = value;
                if (_lblReason != null)
                {
                }
            }
        }

        private TabPage _tabAdditionalNotes;

        internal TabPage tabAdditionalNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tabAdditionalNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tabAdditionalNotes != null)
                {
                }

                _tabAdditionalNotes = value;
                if (_tabAdditionalNotes != null)
                {
                }
            }
        }

        private GroupBox _gpbInvoiceInformation;

        internal GroupBox gpbInvoiceInformation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbInvoiceInformation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbInvoiceInformation != null)
                {
                }

                _gpbInvoiceInformation = value;
                if (_gpbInvoiceInformation != null)
                {
                }
            }
        }

        private RichTextBox _txtAdditionalInvoiceNotes;

        internal RichTextBox txtAdditionalInvoiceNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAdditionalInvoiceNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAdditionalInvoiceNotes != null)
                {
                }

                _txtAdditionalInvoiceNotes = value;
                if (_txtAdditionalInvoiceNotes != null)
                {
                }
            }
        }

        private ComboBox _cboInvType;

        internal ComboBox cboInvType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInvType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInvType != null)
                {
                    _cboInvType.SelectedIndexChanged -= cboInvType_SelectedIndexChanged;
                }

                _cboInvType = value;
                if (_cboInvType != null)
                {
                    _cboInvType.SelectedIndexChanged += cboInvType_SelectedIndexChanged;
                }
            }
        }

        private Label _lblInvType;

        internal Label lblInvType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvType != null)
                {
                }

                _lblInvType = value;
                if (_lblInvType != null)
                {
                }
            }
        }

        private ComboBox _cboPaidBy;

        internal ComboBox cboPaidBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPaidBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPaidBy != null)
                {
                }

                _cboPaidBy = value;
                if (_cboPaidBy != null)
                {
                }
            }
        }

        private Label _lblPaidBy;

        internal Label lblPaidBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPaidBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPaidBy != null)
                {
                }

                _lblPaidBy = value;
                if (_lblPaidBy != null)
                {
                }
            }
        }

        private TextBox _txtSearchFilter;

        internal TextBox txtSearchFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSearchFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSearchFilter != null)
                {
                    _txtSearchFilter.TextChanged -= filterChange;
                }

                _txtSearchFilter = value;
                if (_txtSearchFilter != null)
                {
                    _txtSearchFilter.TextChanged += filterChange;
                }
            }
        }

        private Label _lblSearchFilter;

        internal Label lblSearchFilter
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSearchFilter;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSearchFilter != null)
                {
                }

                _lblSearchFilter = value;
                if (_lblSearchFilter != null)
                {
                }
            }
        }

        private Label _lblSortCode;

        internal Label lblSortCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSortCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSortCode != null)
                {
                }

                _lblSortCode = value;
                if (_lblSortCode != null)
                {
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContract = new GroupBox();
            _txtSearchFilter = new TextBox();
            _txtSearchFilter.TextChanged += new EventHandler(filterChange);
            _lblSearchFilter = new Label();
            _cboPaidBy = new ComboBox();
            _lblPaidBy = new Label();
            _lblMsg = new Label();
            _lblInvType = new Label();
            _cboInvType = new ComboBox();
            _cboInvType.SelectedIndexChanged += new EventHandler(cboInvType_SelectedIndexChanged);
            _cboReasonID = new ComboBox();
            _cboReasonID.SelectedIndexChanged += new EventHandler(cboReasonID_SelectedIndexChanged_1);
            _lblReason = new Label();
            _lblDiscount = new Label();
            _cboDiscount = new ComboBox();
            _txtDDMSRef = new TextBox();
            _lblDDMSRef = new Label();
            _cboDoNotRenew = new CheckBox();
            _txtContractReference = new TextBox();
            _lblContractReference = new Label();
            _txtPONumber = new TextBox();
            _lblPONumber = new Label();
            _chkPlumbingDrainage = new CheckBox();
            _chkWindowLockPest = new CheckBox();
            _lblCancelledDate = new Label();
            _dtpCancelledDate = new DateTimePicker();
            _chkGasSupplyPipework = new CheckBox();
            _tcBottomSection = new TabControl();
            _tabProperties = new TabPage();
            _grpSites = new GroupBox();
            _dgSites = new DataGrid();
            _dgSites.MouseUp += new MouseEventHandler(dgSites_MouseUp);
            _dgSites.DoubleClick += new EventHandler(dgSites_DoubleClick);
            _dgSites.Navigate += new NavigateEventHandler(dgSites_Navigate);
            _tabChargeDetails = new TabPage();
            _gpbChargeDetails = new GroupBox();
            _lblSortCode = new Label();
            _lblAccount = new Label();
            _lblBankName = new Label();
            _txtSortCode = new TextBox();
            _txtAccountNumber = new TextBox();
            _txtBankName = new TextBox();
            _rdoDirectDebit = new RadioButton();
            _rdoCreditCard = new RadioButton();
            _rdoCheque = new RadioButton();
            _tabAdditionalNotes = new TabPage();
            _gpbInvoiceInformation = new GroupBox();
            _txtAdditionalInvoiceNotes = new RichTextBox();
            _cboContractType = new ComboBox();
            _cboContractType.SelectedIndexChanged += new EventHandler(cboContractType_SelectedIndexChanged);
            _lblContractType = new Label();
            _gpbInvoiceAddress = new GroupBox();
            _dgInvoiceAddress = new DataGrid();
            _dgInvoiceAddress.Click += new EventHandler(dgInvoiceAddress_Click);
            _dtpFirstInvoiceDate = new DateTimePicker();
            _lblFirstInvoiceDate = new Label();
            _dtpContractStartDate = new DateTimePicker();
            _lblContractStartDate = new Label();
            _dtpContractEndDate = new DateTimePicker();
            _lblContractEndDate = new Label();
            _cboContractStatusID = new ComboBox();
            _cboContractStatusID.SelectedIndexChanged += new EventHandler(cboContractStatusID_SelectedIndexChanged);
            _lblContractStatusID = new Label();
            _txtContractPrice = new TextBox();
            _txtContractPrice.LostFocus += new EventHandler(txtContractPrice_LostFocus);
            _lblContractPrice = new Label();
            _cboInvoiceFrequencyID = new ComboBox();
            _cboInvoiceFrequencyID.SelectedIndexChanged += new EventHandler(cboInvoiceFrequencyID_SelectedIndexChanged);
            _lblInvoiceFrequencyID = new Label();
            _grpContract.SuspendLayout();
            _tcBottomSection.SuspendLayout();
            _tabProperties.SuspendLayout();
            _grpSites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSites).BeginInit();
            _tabChargeDetails.SuspendLayout();
            _gpbChargeDetails.SuspendLayout();
            _tabAdditionalNotes.SuspendLayout();
            _gpbInvoiceInformation.SuspendLayout();
            _gpbInvoiceAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddress).BeginInit();
            SuspendLayout();
            // 
            // grpContract
            // 
            _grpContract.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContract.Controls.Add(_txtSearchFilter);
            _grpContract.Controls.Add(_lblSearchFilter);
            _grpContract.Controls.Add(_cboPaidBy);
            _grpContract.Controls.Add(_lblPaidBy);
            _grpContract.Controls.Add(_lblMsg);
            _grpContract.Controls.Add(_lblInvType);
            _grpContract.Controls.Add(_cboInvType);
            _grpContract.Controls.Add(_cboReasonID);
            _grpContract.Controls.Add(_lblReason);
            _grpContract.Controls.Add(_lblDiscount);
            _grpContract.Controls.Add(_cboDiscount);
            _grpContract.Controls.Add(_txtDDMSRef);
            _grpContract.Controls.Add(_lblDDMSRef);
            _grpContract.Controls.Add(_cboDoNotRenew);
            _grpContract.Controls.Add(_txtContractReference);
            _grpContract.Controls.Add(_lblContractReference);
            _grpContract.Controls.Add(_txtPONumber);
            _grpContract.Controls.Add(_lblPONumber);
            _grpContract.Controls.Add(_chkPlumbingDrainage);
            _grpContract.Controls.Add(_chkWindowLockPest);
            _grpContract.Controls.Add(_lblCancelledDate);
            _grpContract.Controls.Add(_dtpCancelledDate);
            _grpContract.Controls.Add(_chkGasSupplyPipework);
            _grpContract.Controls.Add(_tcBottomSection);
            _grpContract.Controls.Add(_cboContractType);
            _grpContract.Controls.Add(_lblContractType);
            _grpContract.Controls.Add(_gpbInvoiceAddress);
            _grpContract.Controls.Add(_dtpFirstInvoiceDate);
            _grpContract.Controls.Add(_lblFirstInvoiceDate);
            _grpContract.Controls.Add(_dtpContractStartDate);
            _grpContract.Controls.Add(_lblContractStartDate);
            _grpContract.Controls.Add(_dtpContractEndDate);
            _grpContract.Controls.Add(_lblContractEndDate);
            _grpContract.Controls.Add(_cboContractStatusID);
            _grpContract.Controls.Add(_lblContractStatusID);
            _grpContract.Controls.Add(_txtContractPrice);
            _grpContract.Controls.Add(_lblContractPrice);
            _grpContract.Controls.Add(_cboInvoiceFrequencyID);
            _grpContract.Controls.Add(_lblInvoiceFrequencyID);
            _grpContract.Location = new Point(8, 8);
            _grpContract.Name = "grpContract";
            _grpContract.Size = new Size(769, 627);
            _grpContract.TabIndex = 0;
            _grpContract.TabStop = false;
            _grpContract.Text = "Main Details";
            // 
            // txtSearchFilter
            // 
            _txtSearchFilter.Location = new Point(496, 133);
            _txtSearchFilter.MaxLength = 100;
            _txtSearchFilter.Name = "txtSearchFilter";
            _txtSearchFilter.Size = new Size(248, 21);
            _txtSearchFilter.TabIndex = 44;
            _txtSearchFilter.Tag = "";
            // 
            // lblSearchFilter
            // 
            _lblSearchFilter.Location = new Point(360, 137);
            _lblSearchFilter.Name = "lblSearchFilter";
            _lblSearchFilter.Size = new Size(132, 20);
            _lblSearchFilter.TabIndex = 43;
            _lblSearchFilter.Text = "Search Filter";
            // 
            // cboPaidBy
            // 
            _cboPaidBy.FormattingEnabled = true;
            _cboPaidBy.Location = new Point(496, 105);
            _cboPaidBy.Name = "cboPaidBy";
            _cboPaidBy.Size = new Size(248, 21);
            _cboPaidBy.TabIndex = 41;
            _cboPaidBy.Visible = false;
            // 
            // lblPaidBy
            // 
            _lblPaidBy.Location = new Point(360, 106);
            _lblPaidBy.Name = "lblPaidBy";
            _lblPaidBy.Size = new Size(130, 17);
            _lblPaidBy.TabIndex = 42;
            _lblPaidBy.Text = "Paid By";
            _lblPaidBy.TextAlign = ContentAlignment.MiddleLeft;
            _lblPaidBy.Visible = false;
            // 
            // lblMsg
            // 
            _lblMsg.BackColor = Color.LightGoldenrodYellow;
            _lblMsg.BorderStyle = BorderStyle.FixedSingle;
            _lblMsg.Location = new Point(366, 366);
            _lblMsg.Name = "lblMsg";
            _lblMsg.Size = new Size(376, 23);
            _lblMsg.TabIndex = 25;
            _lblMsg.Text = "Please save before adding properties";
            _lblMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInvType
            // 
            _lblInvType.Location = new Point(360, 79);
            _lblInvType.Name = "lblInvType";
            _lblInvType.Size = new Size(130, 17);
            _lblInvType.TabIndex = 40;
            _lblInvType.Text = "Invoice Type";
            _lblInvType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cboInvType
            // 
            _cboInvType.FormattingEnabled = true;
            _cboInvType.Location = new Point(496, 78);
            _cboInvType.Name = "cboInvType";
            _cboInvType.Size = new Size(248, 21);
            _cboInvType.TabIndex = 39;
            // 
            // cboReasonID
            // 
            _cboReasonID.Cursor = Cursors.Hand;
            _cboReasonID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboReasonID.Location = new Point(144, 242);
            _cboReasonID.Name = "cboReasonID";
            _cboReasonID.Size = new Size(195, 21);
            _cboReasonID.TabIndex = 38;
            _cboReasonID.Tag = "Contract.ContractStatusID";
            // 
            // lblReason
            // 
            _lblReason.Location = new Point(17, 245);
            _lblReason.Name = "lblReason";
            _lblReason.Size = new Size(132, 20);
            _lblReason.TabIndex = 37;
            _lblReason.Text = "Reason";
            // 
            // lblDiscount
            // 
            _lblDiscount.Location = new Point(17, 321);
            _lblDiscount.Name = "lblDiscount";
            _lblDiscount.Size = new Size(121, 20);
            _lblDiscount.TabIndex = 36;
            _lblDiscount.Text = "Discount";
            // 
            // cboDiscount
            // 
            _cboDiscount.Cursor = Cursors.Hand;
            _cboDiscount.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboDiscount.Location = new Point(144, 318);
            _cboDiscount.Name = "cboDiscount";
            _cboDiscount.Size = new Size(195, 21);
            _cboDiscount.TabIndex = 35;
            _cboDiscount.Tag = "";
            // 
            // txtDDMSRef
            // 
            _txtDDMSRef.Location = new Point(494, 310);
            _txtDDMSRef.MaxLength = 100;
            _txtDDMSRef.Name = "txtDDMSRef";
            _txtDDMSRef.Size = new Size(248, 21);
            _txtDDMSRef.TabIndex = 34;
            _txtDDMSRef.Tag = "";
            // 
            // lblDDMSRef
            // 
            _lblDDMSRef.Location = new Point(367, 313);
            _lblDDMSRef.Name = "lblDDMSRef";
            _lblDDMSRef.Size = new Size(132, 20);
            _lblDDMSRef.TabIndex = 33;
            _lblDDMSRef.Text = "DDMS Ref";
            // 
            // cboDoNotRenew
            // 
            _cboDoNotRenew.AutoSize = true;
            _cboDoNotRenew.Location = new Point(20, 296);
            _cboDoNotRenew.Name = "cboDoNotRenew";
            _cboDoNotRenew.Size = new Size(107, 17);
            _cboDoNotRenew.TabIndex = 32;
            _cboDoNotRenew.Text = "Do Not Renew";
            _cboDoNotRenew.UseVisualStyleBackColor = true;
            // 
            // txtContractReference
            // 
            _txtContractReference.Location = new Point(144, 45);
            _txtContractReference.MaxLength = 100;
            _txtContractReference.Name = "txtContractReference";
            _txtContractReference.Size = new Size(195, 21);
            _txtContractReference.TabIndex = 31;
            _txtContractReference.Tag = "Contract.ContractReference";
            // 
            // lblContractReference
            // 
            _lblContractReference.Location = new Point(16, 47);
            _lblContractReference.Name = "lblContractReference";
            _lblContractReference.Size = new Size(132, 20);
            _lblContractReference.TabIndex = 30;
            _lblContractReference.Text = "Contract Reference";
            // 
            // txtPONumber
            // 
            _txtPONumber.Location = new Point(494, 337);
            _txtPONumber.MaxLength = 100;
            _txtPONumber.Name = "txtPONumber";
            _txtPONumber.Size = new Size(248, 21);
            _txtPONumber.TabIndex = 29;
            _txtPONumber.Tag = "";
            // 
            // lblPONumber
            // 
            _lblPONumber.Location = new Point(367, 340);
            _lblPONumber.Name = "lblPONumber";
            _lblPONumber.Size = new Size(132, 20);
            _lblPONumber.TabIndex = 28;
            _lblPONumber.Text = "PO Number";
            // 
            // chkPlumbingDrainage
            // 
            _chkPlumbingDrainage.AutoSize = true;
            _chkPlumbingDrainage.Location = new Point(20, 201);
            _chkPlumbingDrainage.Name = "chkPlumbingDrainage";
            _chkPlumbingDrainage.Size = new Size(252, 17);
            _chkPlumbingDrainage.TabIndex = 27;
            _chkPlumbingDrainage.Text = "Plumbing, drainage and electrical cover";
            _chkPlumbingDrainage.UseVisualStyleBackColor = true;
            // 
            // chkWindowLockPest
            // 
            _chkWindowLockPest.AutoSize = true;
            _chkWindowLockPest.Location = new Point(20, 221);
            _chkWindowLockPest.Name = "chkWindowLockPest";
            _chkWindowLockPest.Size = new Size(190, 17);
            _chkWindowLockPest.TabIndex = 26;
            _chkWindowLockPest.Text = "Window, lock and pest cover";
            _chkWindowLockPest.UseVisualStyleBackColor = true;
            // 
            // lblCancelledDate
            // 
            _lblCancelledDate.Location = new Point(17, 275);
            _lblCancelledDate.Name = "lblCancelledDate";
            _lblCancelledDate.Size = new Size(121, 20);
            _lblCancelledDate.TabIndex = 15;
            _lblCancelledDate.Text = "Cancelled Date";
            // 
            // dtpCancelledDate
            // 
            _dtpCancelledDate.Location = new Point(144, 271);
            _dtpCancelledDate.Name = "dtpCancelledDate";
            _dtpCancelledDate.Size = new Size(195, 21);
            _dtpCancelledDate.TabIndex = 16;
            // 
            // chkGasSupplyPipework
            // 
            _chkGasSupplyPipework.AutoSize = true;
            _chkGasSupplyPipework.Location = new Point(20, 180);
            _chkGasSupplyPipework.Name = "chkGasSupplyPipework";
            _chkGasSupplyPipework.Size = new Size(147, 17);
            _chkGasSupplyPipework.TabIndex = 14;
            _chkGasSupplyPipework.Text = "Gas Supply Pipework";
            _chkGasSupplyPipework.UseVisualStyleBackColor = true;
            // 
            // tcBottomSection
            // 
            _tcBottomSection.Controls.Add(_tabProperties);
            _tcBottomSection.Controls.Add(_tabChargeDetails);
            _tcBottomSection.Controls.Add(_tabAdditionalNotes);
            _tcBottomSection.Location = new Point(19, 374);
            _tcBottomSection.Name = "tcBottomSection";
            _tcBottomSection.SelectedIndex = 0;
            _tcBottomSection.Size = new Size(736, 249);
            _tcBottomSection.TabIndex = 24;
            // 
            // tabProperties
            // 
            _tabProperties.Controls.Add(_grpSites);
            _tabProperties.Location = new Point(4, 22);
            _tabProperties.Name = "tabProperties";
            _tabProperties.Size = new Size(728, 223);
            _tabProperties.TabIndex = 0;
            _tabProperties.Text = "Properties";
            // 
            // grpSites
            // 
            _grpSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpSites.Controls.Add(_dgSites);
            _grpSites.Location = new Point(8, 3);
            _grpSites.Name = "grpSites";
            _grpSites.RightToLeft = RightToLeft.No;
            _grpSites.Size = new Size(720, 214);
            _grpSites.TabIndex = 0;
            _grpSites.TabStop = false;
            _grpSites.Text = "Properties - Double click to view/edit";
            // 
            // dgSites
            // 
            _dgSites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgSites.DataMember = "";
            _dgSites.HeaderForeColor = SystemColors.ControlText;
            _dgSites.Location = new Point(11, 22);
            _dgSites.Name = "dgSites";
            _dgSites.Size = new Size(700, 185);
            _dgSites.TabIndex = 0;
            // 
            // tabChargeDetails
            // 
            _tabChargeDetails.Controls.Add(_gpbChargeDetails);
            _tabChargeDetails.Location = new Point(4, 22);
            _tabChargeDetails.Name = "tabChargeDetails";
            _tabChargeDetails.Size = new Size(728, 223);
            _tabChargeDetails.TabIndex = 1;
            _tabChargeDetails.Text = "Charge Details";
            // 
            // gpbChargeDetails
            // 
            _gpbChargeDetails.Controls.Add(_lblSortCode);
            _gpbChargeDetails.Controls.Add(_lblAccount);
            _gpbChargeDetails.Controls.Add(_lblBankName);
            _gpbChargeDetails.Controls.Add(_txtSortCode);
            _gpbChargeDetails.Controls.Add(_txtAccountNumber);
            _gpbChargeDetails.Controls.Add(_txtBankName);
            _gpbChargeDetails.Controls.Add(_rdoDirectDebit);
            _gpbChargeDetails.Controls.Add(_rdoCreditCard);
            _gpbChargeDetails.Controls.Add(_rdoCheque);
            _gpbChargeDetails.Location = new Point(8, 0);
            _gpbChargeDetails.Name = "gpbChargeDetails";
            _gpbChargeDetails.Size = new Size(712, 320);
            _gpbChargeDetails.TabIndex = 0;
            _gpbChargeDetails.TabStop = false;
            _gpbChargeDetails.Text = "Charge Details";
            // 
            // lblSortCode
            // 
            _lblSortCode.Location = new Point(128, 152);
            _lblSortCode.Name = "lblSortCode";
            _lblSortCode.Size = new Size(100, 23);
            _lblSortCode.TabIndex = 8;
            _lblSortCode.Text = "Sort Code";
            // 
            // lblAccount
            // 
            _lblAccount.Location = new Point(128, 120);
            _lblAccount.Name = "lblAccount";
            _lblAccount.Size = new Size(100, 23);
            _lblAccount.TabIndex = 7;
            _lblAccount.Text = "Account Number";
            // 
            // lblBankName
            // 
            _lblBankName.Location = new Point(128, 88);
            _lblBankName.Name = "lblBankName";
            _lblBankName.Size = new Size(100, 23);
            _lblBankName.TabIndex = 6;
            _lblBankName.Text = "Bank Name";
            // 
            // txtSortCode
            // 
            _txtSortCode.Location = new Point(232, 152);
            _txtSortCode.Name = "txtSortCode";
            _txtSortCode.Size = new Size(360, 21);
            _txtSortCode.TabIndex = 5;
            // 
            // txtAccountNumber
            // 
            _txtAccountNumber.Location = new Point(232, 120);
            _txtAccountNumber.Name = "txtAccountNumber";
            _txtAccountNumber.Size = new Size(360, 21);
            _txtAccountNumber.TabIndex = 4;
            // 
            // txtBankName
            // 
            _txtBankName.Location = new Point(232, 88);
            _txtBankName.Name = "txtBankName";
            _txtBankName.Size = new Size(360, 21);
            _txtBankName.TabIndex = 3;
            // 
            // rdoDirectDebit
            // 
            _rdoDirectDebit.Location = new Point(16, 88);
            _rdoDirectDebit.Name = "rdoDirectDebit";
            _rdoDirectDebit.Size = new Size(104, 24);
            _rdoDirectDebit.TabIndex = 2;
            _rdoDirectDebit.Text = "Direct Debit";
            // 
            // rdoCreditCard
            // 
            _rdoCreditCard.Location = new Point(16, 56);
            _rdoCreditCard.Name = "rdoCreditCard";
            _rdoCreditCard.Size = new Size(104, 24);
            _rdoCreditCard.TabIndex = 1;
            _rdoCreditCard.Text = "Credit Card";
            // 
            // rdoCheque
            // 
            _rdoCheque.Location = new Point(16, 24);
            _rdoCheque.Name = "rdoCheque";
            _rdoCheque.Size = new Size(104, 24);
            _rdoCheque.TabIndex = 0;
            _rdoCheque.Text = "Cheque";
            // 
            // tabAdditionalNotes
            // 
            _tabAdditionalNotes.Controls.Add(_gpbInvoiceInformation);
            _tabAdditionalNotes.Location = new Point(4, 22);
            _tabAdditionalNotes.Name = "tabAdditionalNotes";
            _tabAdditionalNotes.Size = new Size(728, 223);
            _tabAdditionalNotes.TabIndex = 2;
            _tabAdditionalNotes.Text = "Additional Notes";
            _tabAdditionalNotes.UseVisualStyleBackColor = true;
            // 
            // gpbInvoiceInformation
            // 
            _gpbInvoiceInformation.BackColor = SystemColors.Control;
            _gpbInvoiceInformation.Controls.Add(_txtAdditionalInvoiceNotes);
            _gpbInvoiceInformation.Dock = DockStyle.Fill;
            _gpbInvoiceInformation.Location = new Point(0, 0);
            _gpbInvoiceInformation.Name = "gpbInvoiceInformation";
            _gpbInvoiceInformation.Size = new Size(728, 223);
            _gpbInvoiceInformation.TabIndex = 3;
            _gpbInvoiceInformation.TabStop = false;
            _gpbInvoiceInformation.Text = "Additional Notes";
            // 
            // txtAdditionalInvoiceNotes
            // 
            _txtAdditionalInvoiceNotes.Location = new Point(6, 20);
            _txtAdditionalInvoiceNotes.Name = "txtAdditionalInvoiceNotes";
            _txtAdditionalInvoiceNotes.Size = new Size(499, 130);
            _txtAdditionalInvoiceNotes.TabIndex = 13;
            _txtAdditionalInvoiceNotes.Text = "";
            // 
            // cboContractType
            // 
            _cboContractType.Cursor = Cursors.Hand;
            _cboContractType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboContractType.Location = new Point(144, 20);
            _cboContractType.Name = "cboContractType";
            _cboContractType.Size = new Size(195, 21);
            _cboContractType.TabIndex = 4;
            _cboContractType.Tag = "";
            // 
            // lblContractType
            // 
            _lblContractType.Location = new Point(16, 22);
            _lblContractType.Name = "lblContractType";
            _lblContractType.Size = new Size(132, 20);
            _lblContractType.TabIndex = 3;
            _lblContractType.Text = "Contract Type";
            // 
            // gpbInvoiceAddress
            // 
            _gpbInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _gpbInvoiceAddress.Controls.Add(_dgInvoiceAddress);
            _gpbInvoiceAddress.Location = new Point(363, 160);
            _gpbInvoiceAddress.Name = "gpbInvoiceAddress";
            _gpbInvoiceAddress.Size = new Size(392, 140);
            _gpbInvoiceAddress.TabIndex = 23;
            _gpbInvoiceAddress.TabStop = false;
            _gpbInvoiceAddress.Text = "Invoice Address";
            // 
            // dgInvoiceAddress
            // 
            _dgInvoiceAddress.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _dgInvoiceAddress.DataMember = "";
            _dgInvoiceAddress.HeaderForeColor = SystemColors.ControlText;
            _dgInvoiceAddress.Location = new Point(8, 20);
            _dgInvoiceAddress.Name = "dgInvoiceAddress";
            _dgInvoiceAddress.Size = new Size(376, 112);
            _dgInvoiceAddress.TabIndex = 0;
            // 
            // dtpFirstInvoiceDate
            // 
            _dtpFirstInvoiceDate.Location = new Point(496, 51);
            _dtpFirstInvoiceDate.Name = "dtpFirstInvoiceDate";
            _dtpFirstInvoiceDate.Size = new Size(248, 21);
            _dtpFirstInvoiceDate.TabIndex = 22;
            _dtpFirstInvoiceDate.Tag = "";
            // 
            // lblFirstInvoiceDate
            // 
            _lblFirstInvoiceDate.Location = new Point(360, 57);
            _lblFirstInvoiceDate.Name = "lblFirstInvoiceDate";
            _lblFirstInvoiceDate.Size = new Size(132, 20);
            _lblFirstInvoiceDate.TabIndex = 21;
            _lblFirstInvoiceDate.Text = "First Invoice Date";
            // 
            // dtpContractStartDate
            // 
            _dtpContractStartDate.Location = new Point(144, 96);
            _dtpContractStartDate.Name = "dtpContractStartDate";
            _dtpContractStartDate.Size = new Size(195, 21);
            _dtpContractStartDate.TabIndex = 8;
            _dtpContractStartDate.Tag = "Contract.ContractStartDate";
            // 
            // lblContractStartDate
            // 
            _lblContractStartDate.Location = new Point(17, 96);
            _lblContractStartDate.Name = "lblContractStartDate";
            _lblContractStartDate.Size = new Size(132, 20);
            _lblContractStartDate.TabIndex = 7;
            _lblContractStartDate.Text = "Contract Start Date";
            // 
            // dtpContractEndDate
            // 
            _dtpContractEndDate.Location = new Point(144, 120);
            _dtpContractEndDate.Name = "dtpContractEndDate";
            _dtpContractEndDate.Size = new Size(195, 21);
            _dtpContractEndDate.TabIndex = 10;
            _dtpContractEndDate.Tag = "Contract.ContractEndDate";
            // 
            // lblContractEndDate
            // 
            _lblContractEndDate.Location = new Point(17, 120);
            _lblContractEndDate.Name = "lblContractEndDate";
            _lblContractEndDate.Size = new Size(132, 20);
            _lblContractEndDate.TabIndex = 9;
            _lblContractEndDate.Text = "Contract End Date";
            // 
            // cboContractStatusID
            // 
            _cboContractStatusID.Cursor = Cursors.Hand;
            _cboContractStatusID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboContractStatusID.Location = new Point(144, 72);
            _cboContractStatusID.Name = "cboContractStatusID";
            _cboContractStatusID.Size = new Size(195, 21);
            _cboContractStatusID.TabIndex = 6;
            _cboContractStatusID.Tag = "Contract.ContractStatusID";
            // 
            // lblContractStatusID
            // 
            _lblContractStatusID.Location = new Point(17, 72);
            _lblContractStatusID.Name = "lblContractStatusID";
            _lblContractStatusID.Size = new Size(132, 20);
            _lblContractStatusID.TabIndex = 5;
            _lblContractStatusID.Text = "Contract Status";
            _lblContractStatusID.Visible = false;
            // 
            // txtContractPrice
            // 
            _txtContractPrice.Location = new Point(144, 144);
            _txtContractPrice.MaxLength = 9;
            _txtContractPrice.Name = "txtContractPrice";
            _txtContractPrice.Size = new Size(195, 21);
            _txtContractPrice.TabIndex = 12;
            _txtContractPrice.Tag = "Contract.ContractPrice";
            // 
            // lblContractPrice
            // 
            _lblContractPrice.Location = new Point(16, 144);
            _lblContractPrice.Name = "lblContractPrice";
            _lblContractPrice.Size = new Size(132, 20);
            _lblContractPrice.TabIndex = 11;
            _lblContractPrice.Text = "Total Contract Price";
            // 
            // cboInvoiceFrequencyID
            // 
            _cboInvoiceFrequencyID.Cursor = Cursors.Hand;
            _cboInvoiceFrequencyID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInvoiceFrequencyID.Location = new Point(496, 24);
            _cboInvoiceFrequencyID.Name = "cboInvoiceFrequencyID";
            _cboInvoiceFrequencyID.Size = new Size(248, 21);
            _cboInvoiceFrequencyID.TabIndex = 20;
            _cboInvoiceFrequencyID.Tag = "Contract.InvoiceFrequencyID";
            // 
            // lblInvoiceFrequencyID
            // 
            _lblInvoiceFrequencyID.Location = new Point(360, 27);
            _lblInvoiceFrequencyID.Name = "lblInvoiceFrequencyID";
            _lblInvoiceFrequencyID.Size = new Size(132, 20);
            _lblInvoiceFrequencyID.TabIndex = 19;
            _lblInvoiceFrequencyID.Text = "Invoice Frequency";
            // 
            // UCContractOriginal
            // 
            Controls.Add(_grpContract);
            Name = "UCContractOriginal";
            Size = new Size(784, 638);
            _grpContract.ResumeLayout(false);
            _grpContract.PerformLayout();
            _tcBottomSection.ResumeLayout(false);
            _tabProperties.ResumeLayout(false);
            _grpSites.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgSites).EndInit();
            _tabChargeDetails.ResumeLayout(false);
            _gpbChargeDetails.ResumeLayout(false);
            _gpbChargeDetails.PerformLayout();
            _tabAdditionalNotes.ResumeLayout(false);
            _gpbInvoiceInformation.ResumeLayout(false);
            _gpbInvoiceAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)_dgInvoiceAddress).EndInit();
            ResumeLayout(false);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void LoadForm(object sender, EventArgs e)
        {
            LoadBaseControl(this);
        }

        public object LoadedItem
        {
            get
            {
                return CurrentContract;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Entity.Sys.Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

        public event StateChangedEventHandler StateChanged;

        public delegate void StateChangedEventHandler(int newID);

        private Entity.ContractsOriginal.ContractOriginal _currentContract;

        public Entity.ContractsOriginal.ContractOriginal CurrentContract
        {
            get
            {
                return _currentContract;
            }

            set
            {
                _currentContract = value;
                if (_currentContract is null)
                {
                    _currentContract = new Entity.ContractsOriginal.ContractOriginal();
                    _currentContract.Exists = false;
                    var argcombo = cboContractStatusID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, 3.ToString());
                }

                if (_currentContract.Exists)
                {
                    Populate();
                    grpSites.Enabled = true;
                    lblMsg.Visible = false;
                    dtpContractEndDate.Enabled = false;
                    dtpContractStartDate.Enabled = false;
                    dtpFirstInvoiceDate.Enabled = false;
                    cboInvoiceFrequencyID.Enabled = false;
                    gpbInvoiceAddress.Enabled = false;
                }
                else
                {
                    grpSites.Enabled = false;
                    lblMsg.Visible = true;
                    txtContractPrice.Text = Strings.Format(Conversions.ToDouble(0.0), "C");
                }
            }
        }

        private Entity.InvoiceToBeRaiseds.InvoiceToBeRaised _InvoiceToBeRaised;

        public Entity.InvoiceToBeRaiseds.InvoiceToBeRaised InvoiceToBeRaised
        {
            get
            {
                return _InvoiceToBeRaised;
            }

            set
            {
                _InvoiceToBeRaised = value;
                if (InvoiceToBeRaised is null)
                {
                    InvoiceToBeRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                    InvoiceToBeRaised.Exists = false;
                    var argcombo = cboInvType;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, 1.ToString());
                }
                else
                {
                    var argcombo1 = cboInvType;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo1, InvoiceToBeRaised.PaymentTermID.ToString());
                }
            }
        }

        private int _IDToLinkTo = 0;

        public int IDToLinkTo
        {
            get
            {
                return _IDToLinkTo;
            }

            set
            {
                _IDToLinkTo = value;
                if (!CurrentContract.Exists)
                {
                    var currentContracts = App.DB.Customer.Customer_Contracts_GetAll(IDToLinkTo).Table;
                    if (currentContracts.Rows.Count > 0)
                    {
                        int length = currentContracts.Select("ContractType = 'Contract_Opt_1'").Length;
                        if (length > 0)
                        {
                            txtContractReference.Text = Conversions.ToString(currentContracts.Select("ContractType = 'Contract_Opt_1'")[length - 1]["ContractReference"]);
                            txtContractReference.Text = "";
                        }
                    }
                }

                Sites = App.DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, IDToLinkTo);

                // Load Invoice Addresses
                InvoiceAddresses = App.DB.InvoiceAddress.InvoiceAddress_Get_CustomerID(IDToLinkTo);
                if (CurrentContract.InvoiceAddressID > 0)
                {
                    int c = 0;
                    foreach (DataRow dr in InvoiceAddresses.Table.Rows)
                    {
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(dr["AddressID"], CurrentContract.InvoiceAddressID, false) & Operators.ConditionalCompareObjectEqual(dr["AddressTypeID"], CurrentContract.InvoiceAddressTypeID, false)))
                        {
                            dgInvoiceAddress.CurrentRowIndex = c;
                            break;
                        }

                        c += 1;
                    }
                }
                else
                {
                    dgInvoiceAddress.CurrentRowIndex = 0;
                }

                dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex);
            }
        }

        private DataView _Sites;

        public DataView Sites
        {
            get
            {
                return _Sites;
            }

            set
            {
                _Sites = value;
                _Sites.Table.TableName = Entity.Sys.Enums.TableNames.tblContractSite.ToString();
                _Sites.AllowNew = false;
                _Sites.AllowEdit = false;
                _Sites.AllowDelete = false;
                SiteID = SiteID;
                dgSites.DataSource = Sites;
            }
        }

        private DataRow SelectedSiteDataRow
        {
            get
            {
                if (!(dgSites.CurrentRowIndex == -1))
                {
                    return Sites[dgSites.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _InvoiceAddresses;

        private DataView InvoiceAddresses
        {
            get
            {
                return _InvoiceAddresses;
            }

            set
            {
                _InvoiceAddresses = value;
                _InvoiceAddresses.AllowDelete = false;
                _InvoiceAddresses.AllowEdit = false;
                _InvoiceAddresses.AllowNew = false;
                _InvoiceAddresses.Table.TableName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString();
                dgInvoiceAddress.DataSource = InvoiceAddresses;
            }
        }

        private DataRow SelectedInvoiceAddressesDataRow
        {
            get
            {
                if (!(dgInvoiceAddress.CurrentRowIndex == -1))
                {
                    return InvoiceAddresses[dgInvoiceAddress.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private int _SiteID = 0;

        public int SiteID
        {
            get
            {
                return _SiteID;
            }

            set
            {
                _SiteID = value;
                // IF IT A DOMESTIC CUSTOMER WE ONLY WANT TO SHOW ONE SITE
                if (SiteID > 0 & IDToLinkTo == (int)Entity.Sys.Enums.Customer.Domestic)
                {
                    _Sites.RowFilter = "SiteID=" + SiteID;
                    _InvoiceAddresses.RowFilter = "(AddressType ='Customer HQ') OR (AddressType ='Invoice') OR (AddressID=" + SiteID + ")";
                }
            }
        }

        private bool _NumberUsed = false;

        public bool NumberUsed
        {
            get
            {
                return _NumberUsed;
            }

            set
            {
                _NumberUsed = value;
            }
        }

        public JobNumber Number = null;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void SetupSitesDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgSites);
            var tStyle = dgSites.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgSites.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 50;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Site = new DataGridLabelColumn();
            Site.Format = "";
            Site.FormatInfo = null;
            Site.HeaderText = "Property";
            Site.MappingName = "Site";
            Site.ReadOnly = true;
            Site.Width = 200;
            Site.NullText = "";
            tStyle.GridColumnStyles.Add(Site);
            var FirstVisitDate = new DataGridLabelColumn();
            FirstVisitDate.Format = "dd/MM/yyyy";
            FirstVisitDate.FormatInfo = null;
            FirstVisitDate.HeaderText = "First Visit Date";
            FirstVisitDate.MappingName = "FirstVisitDate";
            FirstVisitDate.ReadOnly = true;
            FirstVisitDate.Width = 100;
            FirstVisitDate.NullText = "";
            tStyle.GridColumnStyles.Add(FirstVisitDate);
            var PricePerVisit = new DataGridLabelColumn();
            PricePerVisit.Format = "C";
            PricePerVisit.FormatInfo = null;
            PricePerVisit.HeaderText = "Price Per Visit";
            PricePerVisit.MappingName = "PricePerVisit";
            PricePerVisit.ReadOnly = true;
            PricePerVisit.Width = 100;
            PricePerVisit.NullText = "";
            tStyle.GridColumnStyles.Add(PricePerVisit);
            var VisitFrequency = new DataGridLabelColumn();
            VisitFrequency.Format = "C";
            VisitFrequency.FormatInfo = null;
            VisitFrequency.HeaderText = "Visit Frequency";
            VisitFrequency.MappingName = "VisitFrequency";
            VisitFrequency.ReadOnly = true;
            VisitFrequency.Width = 100;
            VisitFrequency.NullText = "";
            tStyle.GridColumnStyles.Add(VisitFrequency);
            var TotalSitePrice = new DataGridLabelColumn();
            TotalSitePrice.Format = "C";
            TotalSitePrice.FormatInfo = null;
            TotalSitePrice.HeaderText = "Total Property Price";
            TotalSitePrice.MappingName = "TotalSitePrice";
            TotalSitePrice.ReadOnly = true;
            TotalSitePrice.Width = 100;
            TotalSitePrice.NullText = "";
            tStyle.GridColumnStyles.Add(TotalSitePrice);
            var VisitDuration = new DataGridLabelColumn();
            VisitDuration.Format = "";
            VisitDuration.Alignment = HorizontalAlignment.Center;
            VisitDuration.FormatInfo = null;
            VisitDuration.HeaderText = "Visit Duration (Mins)";
            VisitDuration.MappingName = "VisitDuration";
            VisitDuration.ReadOnly = true;
            VisitDuration.Width = 120;
            VisitDuration.NullText = "";
            tStyle.GridColumnStyles.Add(VisitDuration);
            var SitePrice = new DataGridLabelColumn();
            SitePrice.Format = "C";
            SitePrice.FormatInfo = null;
            SitePrice.HeaderText = "Property Price";
            SitePrice.MappingName = "SitePrice";
            SitePrice.ReadOnly = true;
            SitePrice.Width = 100;
            SitePrice.NullText = "";
            tStyle.GridColumnStyles.Add(SitePrice);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblContractSite.ToString();
            dgSites.TableStyles.Add(tStyle);
            Entity.Sys.Helper.RemoveEventHandlers(dgSites);
        }

        public void SetupInvoiceAddressDataGrid()
        {
            Entity.Sys.Helper.SetUpDataGrid(dgInvoiceAddress);
            var tStyle = dgInvoiceAddress.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgInvoiceAddress.ReadOnly = false;
            var AddressType = new DataGridLabelColumn();
            AddressType.Format = "";
            AddressType.FormatInfo = null;
            AddressType.HeaderText = "Address Type";
            AddressType.MappingName = "AddressType";
            AddressType.ReadOnly = true;
            AddressType.Width = 95;
            AddressType.NullText = "";
            tStyle.GridColumnStyles.Add(AddressType);
            var Address1 = new DataGridLabelColumn();
            Address1.Format = "";
            Address1.FormatInfo = null;
            Address1.HeaderText = "Address 1";
            Address1.MappingName = "Address1";
            Address1.ReadOnly = true;
            Address1.Width = 75;
            Address1.NullText = "";
            tStyle.GridColumnStyles.Add(Address1);
            var Address2 = new DataGridLabelColumn();
            Address2.Format = "";
            Address2.FormatInfo = null;
            Address2.HeaderText = "Address 2";
            Address2.MappingName = "Address2";
            Address2.ReadOnly = true;
            Address2.Width = 75;
            Address2.NullText = "";
            tStyle.GridColumnStyles.Add(Address2);
            var Address3 = new DataGridLabelColumn();
            Address3.Format = "";
            Address3.FormatInfo = null;
            Address3.HeaderText = "Address 3";
            Address3.MappingName = "Address3";
            Address3.ReadOnly = true;
            Address3.Width = 75;
            Address3.NullText = "";
            tStyle.GridColumnStyles.Add(Address3);
            var Address4 = new DataGridLabelColumn();
            Address4.Format = "";
            Address4.FormatInfo = null;
            Address4.HeaderText = "Address 4";
            Address4.MappingName = "Address4";
            Address4.ReadOnly = true;
            Address4.Width = 75;
            Address4.NullText = "";
            tStyle.GridColumnStyles.Add(Address4);
            var Address5 = new DataGridLabelColumn();
            Address5.Format = "";
            Address5.FormatInfo = null;
            Address5.HeaderText = "Address 5";
            Address5.MappingName = "Address5";
            Address5.ReadOnly = true;
            Address5.Width = 75;
            Address5.NullText = "";
            tStyle.GridColumnStyles.Add(Address5);
            var Postcode = new DataGridLabelColumn();
            Postcode.Format = "";
            Postcode.FormatInfo = null;
            Postcode.HeaderText = "Postcode";
            Postcode.MappingName = "Postcode";
            Postcode.ReadOnly = true;
            Postcode.Width = 75;
            Postcode.NullText = "";
            tStyle.GridColumnStyles.Add(Postcode);
            tStyle.MappingName = Entity.Sys.Enums.TableNames.tblInvoiceAddress.ToString();
            dgInvoiceAddress.TableStyles.Add(tStyle);
        }

        private void UCContract_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
        }

        private void dgSites_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgSites.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgSites.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedSiteDataRow is null)
                {
                    return;
                }

                bool selected = !Entity.Sys.Helper.MakeBooleanValid(dgSites[dgSites.CurrentRowIndex, 0]);
                if (selected == true)
                {
                    Save();
                    App.ShowForm(typeof(FRMContractOriginalSite), true, new object[] { 0, SelectedSiteDataRow["SiteID"], CurrentContract, this });
                }
                else if (App.ShowMessage("You are about to remove this property from the contract." + Constants.vbCrLf + "This will remove all contract property jobs and visits not yet downloaded by the engineer" + Constants.vbCrLf + "Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (App.DB.ContractOriginalSite.Delete(Conversions.ToInteger(SelectedSiteDataRow["ContractSiteID"])) > 0)
                    {
                        App.ShowMessage("Could not remove property from contract as there are active visits", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                Sites = App.DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, IDToLinkTo);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgSites_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (SelectedSiteDataRow is null)
                {
                    return;
                }

                bool Ticked = Entity.Sys.Helper.MakeBooleanValid(dgSites[dgSites.CurrentRowIndex, 0]);
                if (Ticked == true)
                {
                    App.ShowForm(typeof(FRMContractOriginalSite), true, new object[] { SelectedSiteDataRow["ContractSiteID"], SelectedSiteDataRow["SiteID"], CurrentContract, this });
                }
                else
                {
                    Save();
                    App.ShowForm(typeof(FRMContractOriginalSite), true, new object[] { 0, SelectedSiteDataRow["SiteID"], CurrentContract, this });
                }

                Sites = App.DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, IDToLinkTo);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContractPrice_LostFocus(object sender, EventArgs e)
        {
            string price = "";
            if (txtContractPrice.Text.Trim().Length == 0)
            {
                price = Strings.Format(0.0, "C");
            }
            else if (!Information.IsNumeric(txtContractPrice.Text.Replace("£", "")))
            {
                price = Strings.Format(0.0, "C");
            }
            else
            {
                price = Strings.Format(Conversions.ToDouble(txtContractPrice.Text.Replace("£", "")), "C");
            }

            txtContractPrice.Text = price;
        }

        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            if (CurrentContract.ContractID > 0)
            {
                txtContractPrice.Text = Strings.Format(App.DB.ContractOriginal.ContractCalculatedTotal(CurrentContract.ContractID), "C");
            }
        }

        private void btnContractNumber_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMAvailableContractNos), true, new object[] { txtContractReference, this });
        }

        private void dgInvoiceAddress_Click(object sender, EventArgs e)
        {
            dgInvoiceAddress.Select(dgInvoiceAddress.CurrentRowIndex);
        }

        private void cboContractStatusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboContractStatusID)) == (double)Entity.Sys.Enums.ContractStatus.Cancelled)
            {
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboReasonID)) == 0 | dtpCancelledDate.Value.Date > DateAndTime.Today.Date)
                {
                    Interaction.MsgBox("You can not mark this contract as 'Cancelled' as you have not entered a cancelled reason or the cancelled date is in the future");
                    var argcombo = cboContractStatusID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentContract.ContractStatusID.ToString());
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private void Populate(int ID = 0)
        {
            if (CurrentContract.Exists)
            {
                // CurrentContract = DB.ContractOriginal.Get(ID)
                txtContractReference.Text = CurrentContract.ContractReference;
            }
            else
            {
            }

            var argcombo = cboReasonID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentContract.ReasonID.ToString());
            if (CurrentContract.ContractStatusID == 0)
            {
                var argcombo1 = cboContractStatusID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, 3.ToString());
            }
            else
            {
                var argcombo2 = cboContractStatusID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentContract.ContractStatusID.ToString());
            }

            dtpContractStartDate.Value = CurrentContract.ContractStartDate;
            dtpContractEndDate.Value = CurrentContract.ContractEndDate;
            txtContractPrice.Text = Strings.Format(CurrentContract.ContractPrice, "C");
            var argcombo3 = cboInvoiceFrequencyID;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentContract.InvoiceFrequencyID.ToString());
            dtpFirstInvoiceDate.Value = CurrentContract.FirstInvoiceDate;
            var argcombo4 = cboContractType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo4, CurrentContract.ContractTypeID.ToString());
            txtPONumber.Text = CurrentContract.PoNumber;
            rdoCheque.Checked = CurrentContract.Cheque;
            rdoCreditCard.Checked = CurrentContract.CreditCard;
            rdoDirectDebit.Checked = CurrentContract.DirectDebit;
            txtBankName.Text = CurrentContract.BankName;
            txtAccountNumber.Text = CurrentContract.AccountNumber;
            txtSortCode.Text = CurrentContract.SortCode;
            chkGasSupplyPipework.Checked = CurrentContract.GasSupplyPipework;
            chkPlumbingDrainage.Checked = CurrentContract.PlumbingDrainage;
            chkWindowLockPest.Checked = CurrentContract.WindowLockPest;
            cboDoNotRenew.Checked = CurrentContract.DoNotRenew;
            txtAdditionalInvoiceNotes.Text = CurrentContract.Notes;
            var argcombo5 = cboDiscount;
            Combo.SetSelectedComboItem_By_Value(ref argcombo5, CurrentContract.DiscountID.ToString());
            if (CurrentContract.ReasonID > 0 & CurrentContract.CancelledDate != default)
            {
                dtpCancelledDate.Value = CurrentContract.CancelledDate;
                dtpCancelledDate.Visible = true;
                lblCancelledDate.Visible = true;
            }
            else
            {
                dtpCancelledDate.Visible = false;
                lblCancelledDate.Visible = false;
            }

            cboReasonID.Visible = true;
            lblReason.Visible = true;
            if (CurrentContract.ContractStatusID == (int)Entity.Sys.Enums.ContractStatus.Cancelled)
            {
                cboDoNotRenew.Checked = true;
            }

            // Else

            // dtpCancelledDate.Visible = False
            // cboReasonID.Visible = False
            // lblCancelledDate.Visible = False
            // lblReason.Visible = False
            // cboDoNotRenew.Checked = CurrentContract.DoNotRenew
            // End If

            txtDDMSRef.Text = CurrentContract.DDMSRef;
        }

        public bool Save()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CurrentContract.IgnoreExceptionsOnSetMethods = true;

                // CHECK TO SEE IF ANY FLAG HAVE CHANGED
                ChangeStatus();
                CurrentContract.SetContractReference = txtContractReference.Text.Trim();
                CurrentContract.ContractStartDate = dtpContractStartDate.Value;
                CurrentContract.ContractEndDate = dtpContractEndDate.Value;
                CurrentContract.SetContractStatusID = Combo.get_GetSelectedItemValue(cboContractStatusID);
                CurrentContract.SetContractPrice = txtContractPrice.Text.Trim().Replace("£", "");
                CurrentContract.SetInvoiceFrequencyID = Combo.get_GetSelectedItemValue(cboInvoiceFrequencyID);
                CurrentContract.FirstInvoiceDate = dtpFirstInvoiceDate.Value;
                CurrentContract.SetContractTypeID = Combo.get_GetSelectedItemValue(cboContractType);
                CurrentContract.SetCheque = rdoCheque.Checked;
                CurrentContract.SetCreditCard = rdoCreditCard.Checked;
                CurrentContract.SetDirectDebit = rdoDirectDebit.Checked;
                CurrentContract.SetBankName = txtBankName.Text;
                CurrentContract.SetAccountNumber = txtAccountNumber.Text;
                CurrentContract.SetSortCode = txtSortCode.Text;
                CurrentContract.SetPoNumber = txtPONumber.Text;
                CurrentContract.SetGasSupplyPipework = chkGasSupplyPipework.Checked;
                CurrentContract.SetPlumbingDrainage = chkPlumbingDrainage.Checked;
                CurrentContract.SetWindowLockPest = chkWindowLockPest.Checked;
                CurrentContract.SetDoNotRenew = cboDoNotRenew.Checked;
                CurrentContract.SetDDMSRef = txtDDMSRef.Text;
                CurrentContract.SetNotes = txtAdditionalInvoiceNotes.Text;
                CurrentContract.SetDiscountID = Combo.get_GetSelectedItemValue(cboDiscount);
                if (SelectedInvoiceAddressesDataRow is object)
                {
                    CurrentContract.SetInvoiceAddressID = SelectedInvoiceAddressesDataRow["AddressID"];
                    CurrentContract.SetInvoiceAddressTypeID = SelectedInvoiceAddressesDataRow["AddressTypeID"];
                }

                if (CurrentContract.Exists)
                {
                    CurrentContract.SetReasonID = Combo.get_GetSelectedItemValue(cboReasonID);
                    CurrentContract.CancelledDate = dtpCancelledDate.Value;
                    var cV = new Entity.ContractsOriginal.ContractOriginalValidator();
                    cV.Validate(CurrentContract);
                    App.DB.ContractOriginal.Update(CurrentContract);
                    NumberUsed = true;
                }
                else
                {
                    CurrentContract.SetCustomerID = IDToLinkTo;
                    var cV = new Entity.ContractsOriginal.ContractOriginalValidator();
                    cV.Validate(CurrentContract);
                    CurrentContract = App.DB.ContractOriginal.Insert(CurrentContract);
                    NumberUsed = true;
                    InsertInvoiceToBeRaiseLines();
                }

                if (InvoiceToBeRaised.Exists)
                {
                    InvoiceToBeRaised.SetPaymentTermID = Combo.get_GetSelectedItemValue(cboInvType);
                    InvoiceToBeRaised.SetPaidByID = Combo.get_GetSelectedItemValue(cboPaidBy);
                    App.DB.InvoiceToBeRaised.Update(InvoiceToBeRaised);
                }

                StateChanged?.Invoke(CurrentContract.ContractID);
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

        public void ChangeStatus()
        {
            if (CurrentContract is object)
            {
                // IF UPDATING
                if (CurrentContract.Exists == true)
                {

                    // IF CHANGING TO INACTIVE
                    if (CurrentContract.ContractStatusID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboContractStatusID)) & (Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContractStatusID)) == Entity.Sys.Enums.ContractStatus.Inactive)
                    {

                        // Or CType(Combo.GetSelectedItemValue(cboContractStatusID), Entity.Sys.Enums.ContractStatus) = Entity.Sys.Enums.ContractStatus.Cancelled

                        // ARE YOU SURE - YES NO OR CANCEL
                        var msgResult = new MsgBoxResult();
                        msgResult = (MsgBoxResult)App.ShowMessage("You are setting this contract to inactive" + Constants.vbCrLf + "Do you want to remove any contract job/visits scheduled but not downloaded?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        // SET STATUS BACK TO ACTIVE
                        if ((int)msgResult == (int)DialogResult.Cancel)
                        {
                            var argcombo = cboContractStatusID;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToInteger(Entity.Sys.Enums.ContractStatus.Active).ToString());
                        }
                        else if (msgResult == MsgBoxResult.Yes) // "DEACTIVATE EACH SITES JOBS - WHERE NOT DOWNLOADED
                        {
                            foreach (DataRow site in Sites.Table.Rows)
                            {
                                if (Conversions.ToBoolean(site["ContractSiteID"] > 0))
                                {
                                    App.DB.ContractOriginalSite.ActiveInactive(Conversions.ToInteger(site["ContractSiteID"]), true);
                                }
                            }
                        }
                    }
                    else if (CurrentContract.ContractStatusID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboContractStatusID)) & (Entity.Sys.Enums.ContractStatus)Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContractStatusID)) == Entity.Sys.Enums.ContractStatus.Active)
                    {
                        // IF CHANGING BACK TO ACTIVE

                        // REACTIVE ANY SITE JOBS PREVIOUSLY DEACTIVATED
                        foreach (DataRow site in Sites.Table.Rows)
                        {
                            if (Conversions.ToBoolean(site["ContractSiteID"] > 0))
                            {
                                App.DB.ContractOriginalSite.ActiveInactive(Conversions.ToInteger(site["ContractSiteID"]), false);
                            }
                        }
                    }
                }
            }
        }

        private void InsertInvoiceToBeRaiseLines()
        {
            // Dim numberOfMonths As Double = DateDiff(DateInterval.Month, _
            // CDate(Format(CurrentContract.ContractStartDate, "dd/MMM/yyyy") & " 00:00:00"), _
            // CDate(Format(CurrentContract.ContractEndDate, "dd/MMM/yyyy") & " 23:59:59"))

            // New Way
            DateTime startDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
            DateTime endDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") + " 00:00:00");
            int M = Math.Abs(startDate.Year - endDate.Year);
            int Numberofmonths = M * 12 + Math.Abs(startDate.Month - endDate.Month);
            int days = endDate.Subtract(startDate).Days;
            int numberOfInvoicesToRaise = 0;
            var switchExpr = (Entity.Sys.Enums.InvoiceFrequency_NoWeeK)Conversions.ToInteger(CurrentContract.InvoiceFrequencyID);
            switch (switchExpr)
            {
                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)12);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)6);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)1);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Per_Visit:
                    {
                        break;
                    }
                // Invoice the visit
                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)3);
                        break;
                    }

                case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits:
                    {
                        numberOfInvoicesToRaise = (int)(Numberofmonths / (double)4);
                        break;
                    }
            }

            if (numberOfInvoicesToRaise == 0)
            {
                numberOfInvoicesToRaise = 1;
            }

            var raiseDate = CurrentContract.FirstInvoiceDate;
            for (int i = 1, loopTo = numberOfInvoicesToRaise; i <= loopTo; i++)
            {
                var invToBeRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                invToBeRaised.SetAddressLinkID = CurrentContract.InvoiceAddressID;
                invToBeRaised.SetAddressTypeID = CurrentContract.InvoiceAddressTypeID;
                invToBeRaised.SetInvoiceTypeID = Conversions.ToInteger(Entity.Sys.Enums.InvoiceType.Contract_Option1);
                invToBeRaised.SetLinkID = CurrentContract.ContractID;
                invToBeRaised.RaiseDate = raiseDate;
                App.DB.InvoiceToBeRaised.Insert(invToBeRaised);
                var switchExpr1 = (Entity.Sys.Enums.InvoiceFrequency_NoWeeK)Conversions.ToInteger(CurrentContract.InvoiceFrequencyID);
                switch (switchExpr1)
                {
                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Annually:
                        {
                            raiseDate = raiseDate.AddYears(1);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Bi_Annually:
                        {
                            raiseDate = raiseDate.AddMonths(6);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Monthly:
                        {
                            raiseDate = raiseDate.AddMonths(1);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.Quarterly:
                        {
                            raiseDate = raiseDate.AddMonths(3);
                            break;
                        }

                    case Entity.Sys.Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits:
                        {
                            raiseDate = raiseDate.AddMonths(4);
                            break;
                        }
                }
            }
        }

        private void cboInvoiceFrequencyID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboContractType)) > 0 && CurrentContract.Exists == false)
            {
                if (Number is object)
                {
                    App.DB.Job.DeleteReservedOrderNumber(Number.Number, Number.Prefix);
                }

                Number = App.DB.Job.GetNextJobNumber((Entity.Sys.Enums.JobDefinition)Combo.get_GetSelectedItemValue(cboContractType));
                if (Number.Number.ToString().Length < 3)
                {
                    txtContractReference.Text = Number.Prefix + "00" + Number.Number;
                }
                else if (Number.Number.ToString().Length < 4)
                {
                    txtContractReference.Text = Number.Prefix + "0" + Number.Number;
                }
                else
                {
                    txtContractReference.Text = Number.Prefix + Number.Number;
                }

                txtContractReference.Text = Number.Prefix + Number.Number;
            }
        }

        public void CloseForm()
        {
            if (Number is object & NumberUsed == false)
            {
                App.DB.Job.DeleteReservedOrderNumber(Number.Number, Number.Prefix);
            }

            Dispose();
        }

        private void cboReasonID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboReasonID)) > 0)
            {
                if (CurrentContract.CancelledDate != default)
                {
                    dtpCancelledDate.Value = CurrentContract.CancelledDate;
                    dtpCancelledDate.Visible = true;
                    lblCancelledDate.Visible = true;
                }
            }
            else
            {
                dtpCancelledDate.Visible = false;
                lblCancelledDate.Visible = false;
            }
        }

        private void dgSites_Navigate(object sender, NavigateEventArgs ne)
        {
        }

        private void cboInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboInvType)) == (double)Entity.Sys.Enums.QuoteJobOfWorkTypes.Reciept)
            {
                lblPaidBy.Visible = true;
                cboPaidBy.Visible = true;
            }
            else
            {
                lblPaidBy.Visible = false;
                cboPaidBy.Visible = false;
            }
        }

        private void filterChange(object sender, EventArgs e)
        {
            string filter = "Address1 LIKE '%" + Entity.Sys.Helper.RemoveSpecialCharacters(txtSearchFilter.Text) + "%' OR Postcode LIKE '%" + Entity.Sys.Helper.RemoveSpecialCharacters(txtSearchFilter.Text) + "%'";
            InvoiceAddresses.RowFilter = filter;
        }
    }
}