using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using FSM.Entity.Sys;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace FSM
{
    public class UCContractWiz : UCBase, IUserControl
    {
        public UCContractWiz() : base()
        {
            base.Load += UCContract_Load;

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call
            var argc = cboPaymentType;
            Combo.SetUpCombo(ref argc, DynamicDataTables.ContractPaymentTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc1 = cboPeriod;
            Combo.SetUpCombo(ref argc1, DynamicDataTables.ContractPeriod, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc2 = cboContractType;
            Combo.SetUpCombo(ref argc2, App.DB.Picklists.GetAll(Enums.PickListTypes.ContractTypes).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc3 = cboReasonID;
            Combo.SetUpCombo(ref argc3, App.DB.Picklists.GetAll(Enums.PickListTypes.CancellationReasons).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc4 = cboInitialPaymentType;
            Combo.SetUpCombo(ref argc4, DynamicDataTables.ContractInitialPaymentTypes, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc5 = cboPromotion;
            Combo.SetUpCombo(ref argc5, App.DB.Picklists.GetAll(Enums.PickListTypes.CoverPlanDiscounts).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            SetUpSoldByCombo();
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
        private Button _btnAmend;

        internal Button btnAmend
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAmend;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAmend != null)
                {
                    _btnAmend.Click -= btnAmend_Click;
                }

                _btnAmend = value;
                if (_btnAmend != null)
                {
                    _btnAmend.Click += btnAmend_Click;
                }
            }
        }

        private Button _btnNew;

        internal Button btnNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNew != null)
                {
                    _btnNew.Click -= Button1_Click;
                }

                _btnNew = value;
                if (_btnNew != null)
                {
                    _btnNew.Click += Button1_Click;
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

        private Button _BtnCancel;

        internal Button BtnCancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BtnCancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BtnCancel != null)
                {
                }

                _BtnCancel = value;
                if (_BtnCancel != null)
                {
                }
            }
        }

        private Label _lblReference;

        internal Label lblReference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblReference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblReference != null)
                {
                }

                _lblReference = value;
                if (_lblReference != null)
                {
                }
            }
        }

        private Label _lblMonthly;

        internal Label lblMonthly
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMonthly;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMonthly != null)
                {
                }

                _lblMonthly = value;
                if (_lblMonthly != null)
                {
                }
            }
        }

        private Panel _grpPromo;

        internal Panel grpPromo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPromo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPromo != null)
                {
                }

                _grpPromo = value;
                if (_grpPromo != null)
                {
                }
            }
        }

        private Button _btnPromoOK;

        internal Button btnPromoOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPromoOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPromoOK != null)
                {
                    _btnPromoOK.Click -= btnPromoOK_Click;
                }

                _btnPromoOK = value;
                if (_btnPromoOK != null)
                {
                    _btnPromoOK.Click += btnPromoOK_Click;
                }
            }
        }

        private ComboBox _cboPromotion;

        internal ComboBox cboPromotion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPromotion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPromotion != null)
                {
                    _cboPromotion.SelectedIndexChanged -= cboPromotion_SelectedIndexChanged;
                }

                _cboPromotion = value;
                if (_cboPromotion != null)
                {
                    _cboPromotion.SelectedIndexChanged += cboPromotion_SelectedIndexChanged;
                }
            }
        }

        private Label _lblPromotionalOffer;

        internal Label lblPromotionalOffer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPromotionalOffer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPromotionalOffer != null)
                {
                }

                _lblPromotionalOffer = value;
                if (_lblPromotionalOffer != null)
                {
                }
            }
        }

        private Panel _grpContractType;

        internal Panel grpContractType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContractType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContractType != null)
                {
                }

                _grpContractType = value;
                if (_grpContractType != null)
                {
                }
            }
        }

        private Label _lblcancel;

        internal Label lblcancel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcancel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcancel != null)
                {
                }

                _lblcancel = value;
                if (_lblcancel != null)
                {
                }
            }
        }

        private Label _lblCancelReason;

        internal Label lblCancelReason
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblCancelReason;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblCancelReason != null)
                {
                }

                _lblCancelReason = value;
                if (_lblCancelReason != null)
                {
                }
            }
        }

        private Button _btnTypeOk;

        internal Button btnTypeOk
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTypeOk;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTypeOk != null)
                {
                    _btnTypeOk.Click -= btnTypeOk_Click_1;
                }

                _btnTypeOk = value;
                if (_btnTypeOk != null)
                {
                    _btnTypeOk.Click += btnTypeOk_Click_1;
                }
            }
        }

        private Label _lblConType;

        internal Label lblConType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblConType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblConType != null)
                {
                }

                _lblConType = value;
                if (_lblConType != null)
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
                }

                _cboReasonID = value;
                if (_cboReasonID != null)
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

        private Panel _grpAppliancesCovered;

        internal Panel grpAppliancesCovered
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAppliancesCovered;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAppliancesCovered != null)
                {
                }

                _grpAppliancesCovered = value;
                if (_grpAppliancesCovered != null)
                {
                }
            }
        }

        private Button _btnMinusSecond;

        internal Button btnMinusSecond
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMinusSecond;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMinusSecond != null)
                {
                    _btnMinusSecond.Click -= btnMinusSecond_Click;
                }

                _btnMinusSecond = value;
                if (_btnMinusSecond != null)
                {
                    _btnMinusSecond.Click += btnMinusSecond_Click;
                }
            }
        }

        private Button _btnMinusMain;

        internal Button btnMinusMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnMinusMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnMinusMain != null)
                {
                    _btnMinusMain.Click -= btnMinusMain_Click;
                }

                _btnMinusMain = value;
                if (_btnMinusMain != null)
                {
                    _btnMinusMain.Click += btnMinusMain_Click;
                }
            }
        }

        private Button _btnAddSecond;

        internal Button btnAddSecond
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddSecond;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddSecond != null)
                {
                    _btnAddSecond.Click -= btnAddSecond_Click;
                }

                _btnAddSecond = value;
                if (_btnAddSecond != null)
                {
                    _btnAddSecond.Click += btnAddSecond_Click;
                }
            }
        }

        private Button _btnAddMain;

        internal Button btnAddMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddMain != null)
                {
                    _btnAddMain.Click -= btnAddMain_Click;
                }

                _btnAddMain = value;
                if (_btnAddMain != null)
                {
                    _btnAddMain.Click += btnAddMain_Click;
                }
            }
        }

        private Label _LblSecondApps2;

        internal Label LblSecondApps2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _LblSecondApps2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_LblSecondApps2 != null)
                {
                }

                _LblSecondApps2 = value;
                if (_LblSecondApps2 != null)
                {
                }
            }
        }

        private TextBox _txtSecondryCount;

        internal TextBox txtSecondryCount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSecondryCount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSecondryCount != null)
                {
                    _txtSecondryCount.TextAlignChanged -= txtMainAppCount_TextChanged;
                }

                _txtSecondryCount = value;
                if (_txtSecondryCount != null)
                {
                    _txtSecondryCount.TextAlignChanged += txtMainAppCount_TextChanged;
                }
            }
        }

        private ComboBox _cboSecondryApps;

        internal ComboBox cboSecondryApps
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSecondryApps;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSecondryApps != null)
                {
                }

                _cboSecondryApps = value;
                if (_cboSecondryApps != null)
                {
                }
            }
        }

        private Label _lblSecondOR;

        internal Label lblSecondOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSecondOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSecondOR != null)
                {
                }

                _lblSecondOR = value;
                if (_lblSecondOR != null)
                {
                }
            }
        }

        private Button _btnAppsOK;

        internal Button btnAppsOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAppsOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAppsOK != null)
                {
                    _btnAppsOK.Click -= btnAppsOK_Click;
                }

                _btnAppsOK = value;
                if (_btnAppsOK != null)
                {
                    _btnAppsOK.Click += btnAppsOK_Click;
                }
            }
        }

        private Label _lblAdditionalApps;

        internal Label lblAdditionalApps
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAdditionalApps;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAdditionalApps != null)
                {
                }

                _lblAdditionalApps = value;
                if (_lblAdditionalApps != null)
                {
                }
            }
        }

        private Label _lblMainApps2;

        internal Label lblMainApps2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMainApps2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMainApps2 != null)
                {
                }

                _lblMainApps2 = value;
                if (_lblMainApps2 != null)
                {
                }
            }
        }

        private TextBox _txtMainAppCount;

        internal TextBox txtMainAppCount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtMainAppCount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtMainAppCount != null)
                {
                    _txtMainAppCount.TextChanged -= txtMainAppCount_TextChanged;
                }

                _txtMainAppCount = value;
                if (_txtMainAppCount != null)
                {
                    _txtMainAppCount.TextChanged += txtMainAppCount_TextChanged;
                }
            }
        }

        private ComboBox _cboMainApps;

        internal ComboBox cboMainApps
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboMainApps;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboMainApps != null)
                {
                }

                _cboMainApps = value;
                if (_cboMainApps != null)
                {
                }
            }
        }

        private Label _lblMainOR;

        internal Label lblMainOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMainOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMainOR != null)
                {
                }

                _lblMainOR = value;
                if (_lblMainOR != null)
                {
                }
            }
        }

        private Label _lblMainApps;

        internal Label lblMainApps
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMainApps;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMainApps != null)
                {
                }

                _lblMainApps = value;
                if (_lblMainApps != null)
                {
                }
            }
        }

        private Label _lblAppsCovered;

        internal Label lblAppsCovered
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAppsCovered;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAppsCovered != null)
                {
                }

                _lblAppsCovered = value;
                if (_lblAppsCovered != null)
                {
                }
            }
        }

        private Panel _grpContractPeriod;

        internal Panel grpContractPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpContractPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpContractPeriod != null)
                {
                }

                _grpContractPeriod = value;
                if (_grpContractPeriod != null)
                {
                }
            }
        }

        private Button _btnPeriodOK;

        internal Button btnPeriodOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPeriodOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPeriodOK != null)
                {
                    _btnPeriodOK.Click -= btnPeriodOK_Click_1;
                }

                _btnPeriodOK = value;
                if (_btnPeriodOK != null)
                {
                    _btnPeriodOK.Click += btnPeriodOK_Click_1;
                }
            }
        }

        private Label _lblPeriod;

        internal Label lblPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPeriod != null)
                {
                }

                _lblPeriod = value;
                if (_lblPeriod != null)
                {
                }
            }
        }

        private ComboBox _cboPeriod;

        internal ComboBox cboPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPeriod != null)
                {
                    _cboPeriod.SelectedIndexChanged -= cboPeriod_SelectedIndexChanged;
                }

                _cboPeriod = value;
                if (_cboPeriod != null)
                {
                    _cboPeriod.SelectedIndexChanged += cboPeriod_SelectedIndexChanged;
                }
            }
        }

        private Label _lblConPeriod;

        internal Label lblConPeriod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblConPeriod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblConPeriod != null)
                {
                }

                _lblConPeriod = value;
                if (_lblConPeriod != null)
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

        private Panel _grpAdditionalOptions;

        internal Panel grpAdditionalOptions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAdditionalOptions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAdditionalOptions != null)
                {
                }

                _grpAdditionalOptions = value;
                if (_grpAdditionalOptions != null)
                {
                }
            }
        }

        private Button _btnAdditionalOK;

        internal Button btnAdditionalOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAdditionalOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAdditionalOK != null)
                {
                    _btnAdditionalOK.Click -= btnAdditionalOK_Click;
                }

                _btnAdditionalOK = value;
                if (_btnAdditionalOK != null)
                {
                    _btnAdditionalOK.Click += btnAdditionalOK_Click;
                }
            }
        }

        private Label _lblAdditionalOptions;

        internal Label lblAdditionalOptions
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAdditionalOptions;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAdditionalOptions != null)
                {
                }

                _lblAdditionalOptions = value;
                if (_lblAdditionalOptions != null)
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
                    _chkPlumbingDrainage.CheckedChanged -= chkWindowLockPest_CheckedChanged;
                }

                _chkPlumbingDrainage = value;
                if (_chkPlumbingDrainage != null)
                {
                    _chkPlumbingDrainage.CheckedChanged += chkWindowLockPest_CheckedChanged;
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
                    _chkWindowLockPest.CheckedChanged -= chkWindowLockPest_CheckedChanged;
                }

                _chkWindowLockPest = value;
                if (_chkWindowLockPest != null)
                {
                    _chkWindowLockPest.CheckedChanged += chkWindowLockPest_CheckedChanged;
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
                    _chkGasSupplyPipework.CheckedChanged -= chkWindowLockPest_CheckedChanged;
                }

                _chkGasSupplyPipework = value;
                if (_chkGasSupplyPipework != null)
                {
                    _chkGasSupplyPipework.CheckedChanged += chkWindowLockPest_CheckedChanged;
                }
            }
        }

        private Panel _grpPayers;

        internal Panel grpPayers
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpPayers;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpPayers != null)
                {
                }

                _grpPayers = value;
                if (_grpPayers != null)
                {
                }
            }
        }

        private Button _btnPaymentOK;

        internal Button btnPaymentOK
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPaymentOK;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPaymentOK != null)
                {
                    _btnPaymentOK.Click -= btnPaymentOK_Click;
                }

                _btnPaymentOK = value;
                if (_btnPaymentOK != null)
                {
                    _btnPaymentOK.Click += btnPaymentOK_Click;
                }
            }
        }

        private Label _lblPaymentMethod;

        internal Label lblPaymentMethod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPaymentMethod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPaymentMethod != null)
                {
                }

                _lblPaymentMethod = value;
                if (_lblPaymentMethod != null)
                {
                }
            }
        }

        private ComboBox _cboPaymentType;

        internal ComboBox cboPaymentType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPaymentType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPaymentType != null)
                {
                    _cboPaymentType.SelectedIndexChanged -= cboPaymentType_SelectedIndexChanged;
                }

                _cboPaymentType = value;
                if (_cboPaymentType != null)
                {
                    _cboPaymentType.SelectedIndexChanged += cboPaymentType_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboPAyer;

        internal ComboBox cboPAyer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPAyer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPAyer != null)
                {
                }

                _cboPAyer = value;
                if (_cboPAyer != null)
                {
                }
            }
        }

        private Label _lblPayer;

        internal Label lblPayer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPayer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPayer != null)
                {
                }

                _lblPayer = value;
                if (_lblPayer != null)
                {
                }
            }
        }

        private Label _lblPayersDetail;

        internal Label lblPayersDetail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPayersDetail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPayersDetail != null)
                {
                }

                _lblPayersDetail = value;
                if (_lblPayersDetail != null)
                {
                }
            }
        }

        private Panel _grpAdditionalDetails;

        internal Panel grpAdditionalDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAdditionalDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAdditionalDetails != null)
                {
                }

                _grpAdditionalDetails = value;
                if (_grpAdditionalDetails != null)
                {
                }
            }
        }

        private TextBox _txtNotesToEngineer;

        internal TextBox txtNotesToEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotesToEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotesToEngineer != null)
                {
                }

                _txtNotesToEngineer = value;
                if (_txtNotesToEngineer != null)
                {
                }
            }
        }

        private Label _lblServiceNotes;

        internal Label lblServiceNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblServiceNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblServiceNotes != null)
                {
                }

                _lblServiceNotes = value;
                if (_lblServiceNotes != null)
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

        private Label _lblPO;

        internal Label lblPO
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPO;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPO != null)
                {
                }

                _lblPO = value;
                if (_lblPO != null)
                {
                }
            }
        }

        private Label _lblAddDetails;

        internal Label lblAddDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAddDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAddDetails != null)
                {
                }

                _lblAddDetails = value;
                if (_lblAddDetails != null)
                {
                }
            }
        }

        private DataGridView _DgMain;

        internal DataGridView DgMain
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DgMain;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DgMain != null)
                {
                }

                _DgMain = value;
                if (_DgMain != null)
                {
                }
            }
        }

        private DataGridView _dgSecondAssets;

        internal DataGridView dgSecondAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSecondAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSecondAssets != null)
                {
                }

                _dgSecondAssets = value;
                if (_dgSecondAssets != null)
                {
                }
            }
        }

        private Label _lblMonthlyEst;

        internal Label lblMonthlyEst
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblMonthlyEst;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblMonthlyEst != null)
                {
                }

                _lblMonthlyEst = value;
                if (_lblMonthlyEst != null)
                {
                }
            }
        }

        private Label _lblContractRef;

        internal Label lblContractRef
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractRef;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractRef != null)
                {
                }

                _lblContractRef = value;
                if (_lblContractRef != null)
                {
                }
            }
        }

        private Label _lblTotalEst;

        internal Label lblTotalEst
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblTotalEst;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblTotalEst != null)
                {
                }

                _lblTotalEst = value;
                if (_lblTotalEst != null)
                {
                }
            }
        }

        private Label _lblFollowedBy;

        internal Label lblFollowedBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblFollowedBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblFollowedBy != null)
                {
                }

                _lblFollowedBy = value;
                if (_lblFollowedBy != null)
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

        private CheckBox _chkLandlord;

        internal CheckBox chkLandlord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkLandlord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkLandlord != null)
                {
                }

                _chkLandlord = value;
                if (_chkLandlord != null)
                {
                }
            }
        }

        private CheckBox _chkCommercial;

        internal CheckBox chkCommercial
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkCommercial;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkCommercial != null)
                {
                }

                _chkCommercial = value;
                if (_chkCommercial != null)
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
                    _cboContract.SelectedIndexChanged -= cboContract_SelectedIndexChanged;
                }

                _cboContract = value;
                if (_cboContract != null)
                {
                    _cboContract.SelectedIndexChanged += cboContract_SelectedIndexChanged;
                }
            }
        }

        private ComboBox _cboInitialPaymentType;

        internal ComboBox cboInitialPaymentType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInitialPaymentType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInitialPaymentType != null)
                {
                }

                _cboInitialPaymentType = value;
                if (_cboInitialPaymentType != null)
                {
                }
            }
        }

        private Panel _Panel1;

        internal Panel Panel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel1 != null)
                {
                }

                _Panel1 = value;
                if (_Panel1 != null)
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

        private Panel _grpDD;

        internal Panel grpDD
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpDD;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpDD != null)
                {
                }

                _grpDD = value;
                if (_grpDD != null)
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

        private TextBox _txtAccNumber;

        internal TextBox txtAccNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccNumber != null)
                {
                }

                _txtAccNumber = value;
                if (_txtAccNumber != null)
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

        private Label _lblAccNumber;

        internal Label lblAccNumber
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccNumber;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccNumber != null)
                {
                }

                _lblAccNumber = value;
                if (_lblAccNumber != null)
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

        private Panel _Panel2;

        internal Panel Panel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Panel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Panel2 != null)
                {
                }

                _Panel2 = value;
                if (_Panel2 != null)
                {
                }
            }
        }

        private Button _btnRenew;

        internal Button btnRenew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRenew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRenew != null)
                {
                    _btnRenew.Click -= btnRenew_Click;
                }

                _btnRenew = value;
                if (_btnRenew != null)
                {
                    _btnRenew.Click += btnRenew_Click;
                }
            }
        }

        private TextBox _txtAccName;

        internal TextBox txtAccName
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccName;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccName != null)
                {
                }

                _txtAccName = value;
                if (_txtAccName != null)
                {
                }
            }
        }

        private Label _lbl3;

        internal Label lbl3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lbl3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lbl3 != null)
                {
                }

                _lbl3 = value;
                if (_lbl3 != null)
                {
                }
            }
        }

        private Label _lblRenewed;

        internal Label lblRenewed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRenewed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRenewed != null)
                {
                }

                _lblRenewed = value;
                if (_lblRenewed != null)
                {
                }
            }
        }

        private ComboBox _cboSoldBy;

        internal ComboBox cboSoldBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSoldBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSoldBy != null)
                {
                    _cboSoldBy.SelectedIndexChanged -= cboSoldBy_SelectedIndexChanged;
                }

                _cboSoldBy = value;
                if (_cboSoldBy != null)
                {
                    _cboSoldBy.SelectedIndexChanged += cboSoldBy_SelectedIndexChanged;
                }
            }
        }

        private Label _lblsold;

        internal Label lblsold
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblsold;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblsold != null)
                {
                }

                _lblsold = value;
                if (_lblsold != null)
                {
                }
            }
        }

        private Button _btnTransfer;

        internal Button btnTransfer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnTransfer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnTransfer != null)
                {
                    _btnTransfer.Click -= btnTransfer_Click;
                }

                _btnTransfer = value;
                if (_btnTransfer != null)
                {
                    _btnTransfer.Click += btnTransfer_Click;
                }
            }
        }

        private Label _lblchanging;

        internal Label lblchanging
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblchanging;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblchanging != null)
                {
                }

                _lblchanging = value;
                if (_lblchanging != null)
                {
                }
            }
        }

        private Label _lblIsLandlord;

        internal Label lblIsLandlord
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblIsLandlord;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblIsLandlord != null)
                {
                }

                _lblIsLandlord = value;
                if (_lblIsLandlord != null)
                {
                }
            }
        }

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

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _grpContract = new GroupBox();
            _btnTransfer = new Button();
            _btnTransfer.Click += new EventHandler(btnTransfer_Click);
            _lblsold = new Label();
            _btnRenew = new Button();
            _btnRenew.Click += new EventHandler(btnRenew_Click);
            _Label2 = new Label();
            _lblFollowedBy = new Label();
            _Label1 = new Label();
            _lblMonthlyEst = new Label();
            _lblContractRef = new Label();
            _lblTotalEst = new Label();
            _grpPromo = new Panel();
            _btnPromoOK = new Button();
            _btnPromoOK.Click += new EventHandler(btnPromoOK_Click);
            _cboPromotion = new ComboBox();
            _cboPromotion.SelectedIndexChanged += new EventHandler(cboPromotion_SelectedIndexChanged);
            _lblPromotionalOffer = new Label();
            _grpContractType = new Panel();
            _cboContract = new ComboBox();
            _cboContract.SelectedIndexChanged += new EventHandler(cboContract_SelectedIndexChanged);
            _lblcancel = new Label();
            _lblCancelReason = new Label();
            _btnTypeOk = new Button();
            _btnTypeOk.Click += new EventHandler(btnTypeOk_Click_1);
            _lblConType = new Label();
            _cboReasonID = new ComboBox();
            _dtpCancelledDate = new DateTimePicker();
            _cboContractType = new ComboBox();
            _cboContractType.SelectedIndexChanged += new EventHandler(cboContractType_SelectedIndexChanged);
            _lblIsLandlord = new Label();
            _grpAppliancesCovered = new Panel();
            _dgSecondAssets = new DataGridView();
            _DgMain = new DataGridView();
            _btnMinusSecond = new Button();
            _btnMinusSecond.Click += new EventHandler(btnMinusSecond_Click);
            _btnMinusMain = new Button();
            _btnMinusMain.Click += new EventHandler(btnMinusMain_Click);
            _btnAddSecond = new Button();
            _btnAddSecond.Click += new EventHandler(btnAddSecond_Click);
            _btnAddMain = new Button();
            _btnAddMain.Click += new EventHandler(btnAddMain_Click);
            _LblSecondApps2 = new Label();
            _txtSecondryCount = new TextBox();
            _txtSecondryCount.TextAlignChanged += new EventHandler(txtMainAppCount_TextChanged);
            _cboSecondryApps = new ComboBox();
            _lblSecondOR = new Label();
            _btnAppsOK = new Button();
            _btnAppsOK.Click += new EventHandler(btnAppsOK_Click);
            _lblAdditionalApps = new Label();
            _lblMainApps2 = new Label();
            _txtMainAppCount = new TextBox();
            _txtMainAppCount.TextChanged += new EventHandler(txtMainAppCount_TextChanged);
            _cboMainApps = new ComboBox();
            _lblMainOR = new Label();
            _lblMainApps = new Label();
            _lblAppsCovered = new Label();
            _lblReference = new Label();
            _lblMonthly = new Label();
            _BtnCancel = new Button();
            _btnAmend = new Button();
            _btnAmend.Click += new EventHandler(btnAmend_Click);
            _btnNew = new Button();
            _btnNew.Click += new EventHandler(Button1_Click);
            _Label7 = new Label();
            _cboSoldBy = new ComboBox();
            _cboSoldBy.SelectedIndexChanged += new EventHandler(cboSoldBy_SelectedIndexChanged);
            _lblRenewed = new Label();
            _grpContractPeriod = new Panel();
            _btnPeriodOK = new Button();
            _btnPeriodOK.Click += new EventHandler(btnPeriodOK_Click_1);
            _lblPeriod = new Label();
            _cboPeriod = new ComboBox();
            _cboPeriod.SelectedIndexChanged += new EventHandler(cboPeriod_SelectedIndexChanged);
            _lblConPeriod = new Label();
            _dtpContractStartDate = new DateTimePicker();
            _lblContractStartDate = new Label();
            _grpAdditionalOptions = new Panel();
            _btnAdditionalOK = new Button();
            _btnAdditionalOK.Click += new EventHandler(btnAdditionalOK_Click);
            _lblAdditionalOptions = new Label();
            _chkPlumbingDrainage = new CheckBox();
            _chkPlumbingDrainage.CheckedChanged += new EventHandler(chkWindowLockPest_CheckedChanged);
            _chkWindowLockPest = new CheckBox();
            _chkWindowLockPest.CheckedChanged += new EventHandler(chkWindowLockPest_CheckedChanged);
            _chkGasSupplyPipework = new CheckBox();
            _chkGasSupplyPipework.CheckedChanged += new EventHandler(chkWindowLockPest_CheckedChanged);
            _grpPayers = new Panel();
            _grpDD = new Panel();
            _lblchanging = new Label();
            _txtAccName = new TextBox();
            _lbl3 = new Label();
            _txtBankName = new TextBox();
            _txtAccNumber = new TextBox();
            _lblBankName = new Label();
            _lblAccNumber = new Label();
            _txtSortCode = new TextBox();
            _lblSortCode = new Label();
            _Panel2 = new Panel();
            _Panel1 = new Panel();
            _lblPaidBy = new Label();
            _cboInitialPaymentType = new ComboBox();
            _btnPaymentOK = new Button();
            _btnPaymentOK.Click += new EventHandler(btnPaymentOK_Click);
            _lblPaymentMethod = new Label();
            _cboPaymentType = new ComboBox();
            _cboPaymentType.SelectedIndexChanged += new EventHandler(cboPaymentType_SelectedIndexChanged);
            _cboPAyer = new ComboBox();
            _lblPayer = new Label();
            _lblPayersDetail = new Label();
            _grpAdditionalDetails = new Panel();
            _chkCommercial = new CheckBox();
            _chkLandlord = new CheckBox();
            _txtNotesToEngineer = new TextBox();
            _lblServiceNotes = new Label();
            _txtPONumber = new TextBox();
            _lblPO = new Label();
            _lblAddDetails = new Label();
            _grpContract.SuspendLayout();
            _grpPromo.SuspendLayout();
            _grpContractType.SuspendLayout();
            _grpAppliancesCovered.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSecondAssets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_DgMain).BeginInit();
            _grpContractPeriod.SuspendLayout();
            _grpAdditionalOptions.SuspendLayout();
            _grpPayers.SuspendLayout();
            _grpDD.SuspendLayout();
            _Panel1.SuspendLayout();
            _grpAdditionalDetails.SuspendLayout();
            SuspendLayout();
            // 
            // grpContract
            // 
            _grpContract.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            _grpContract.Controls.Add(_btnTransfer);
            _grpContract.Controls.Add(_lblsold);
            _grpContract.Controls.Add(_btnRenew);
            _grpContract.Controls.Add(_Label2);
            _grpContract.Controls.Add(_lblFollowedBy);
            _grpContract.Controls.Add(_Label1);
            _grpContract.Controls.Add(_lblMonthlyEst);
            _grpContract.Controls.Add(_lblContractRef);
            _grpContract.Controls.Add(_lblTotalEst);
            _grpContract.Controls.Add(_grpPromo);
            _grpContract.Controls.Add(_grpContractType);
            _grpContract.Controls.Add(_grpAppliancesCovered);
            _grpContract.Controls.Add(_lblReference);
            _grpContract.Controls.Add(_lblMonthly);
            _grpContract.Controls.Add(_BtnCancel);
            _grpContract.Controls.Add(_btnAmend);
            _grpContract.Controls.Add(_btnNew);
            _grpContract.Controls.Add(_Label7);
            _grpContract.Controls.Add(_cboSoldBy);
            _grpContract.Controls.Add(_lblRenewed);
            _grpContract.Location = new Point(8, 8);
            _grpContract.Name = "grpContract";
            _grpContract.Size = new Size(1080, 690);
            _grpContract.TabIndex = 0;
            _grpContract.TabStop = false;
            _grpContract.Text = "Contract Wizard";
            // 
            // btnTransfer
            // 
            _btnTransfer.Location = new Point(593, 28);
            _btnTransfer.Name = "btnTransfer";
            _btnTransfer.Size = new Size(146, 23);
            _btnTransfer.TabIndex = 155;
            _btnTransfer.Text = "TRANSFER CONTRACT";
            _btnTransfer.UseVisualStyleBackColor = true;
            _btnTransfer.Visible = false;
            // 
            // lblsold
            // 
            _lblsold.Location = new Point(667, 33);
            _lblsold.Name = "lblsold";
            _lblsold.Size = new Size(79, 20);
            _lblsold.TabIndex = 154;
            _lblsold.Text = "Sold By";
            _lblsold.Visible = false;
            // 
            // btnRenew
            // 
            _btnRenew.Location = new Point(748, 28);
            _btnRenew.Name = "btnRenew";
            _btnRenew.Size = new Size(146, 23);
            _btnRenew.TabIndex = 151;
            _btnRenew.Text = "RENEW CONTRACT";
            _btnRenew.UseVisualStyleBackColor = true;
            _btnRenew.Visible = false;
            // 
            // Label2
            // 
            _Label2.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label2.Location = new Point(346, 625);
            _Label2.Name = "Label2";
            _Label2.Size = new Size(191, 25);
            _Label2.TabIndex = 90;
            _Label2.Text = "Annual Amount: ";
            // 
            // lblFollowedBy
            // 
            _lblFollowedBy.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblFollowedBy.Location = new Point(242, 658);
            _lblFollowedBy.Name = "lblFollowedBy";
            _lblFollowedBy.Size = new Size(97, 25);
            _lblFollowedBy.TabIndex = 150;
            // 
            // Label1
            // 
            _Label1.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label1.Location = new Point(5, 658);
            _Label1.Name = "Label1";
            _Label1.Size = new Size(230, 25);
            _Label1.TabIndex = 149;
            _Label1.Text = "Followed By:";
            // 
            // lblMonthlyEst
            // 
            _lblMonthlyEst.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMonthlyEst.Location = new Point(238, 625);
            _lblMonthlyEst.Name = "lblMonthlyEst";
            _lblMonthlyEst.Size = new Size(108, 25);
            _lblMonthlyEst.TabIndex = 148;
            // 
            // lblContractRef
            // 
            _lblContractRef.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblContractRef.Location = new Point(898, 625);
            _lblContractRef.Name = "lblContractRef";
            _lblContractRef.Size = new Size(137, 25);
            _lblContractRef.TabIndex = 148;
            // 
            // lblTotalEst
            // 
            _lblTotalEst.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblTotalEst.Location = new Point(538, 625);
            _lblTotalEst.Name = "lblTotalEst";
            _lblTotalEst.Size = new Size(118, 25);
            _lblTotalEst.TabIndex = 147;
            // 
            // grpPromo
            // 
            _grpPromo.Controls.Add(_btnPromoOK);
            _grpPromo.Controls.Add(_cboPromotion);
            _grpPromo.Controls.Add(_lblPromotionalOffer);
            _grpPromo.Location = new Point(0, 377);
            _grpPromo.Name = "grpPromo";
            _grpPromo.Size = new Size(1040, 36);
            _grpPromo.TabIndex = 95;
            // 
            // btnPromoOK
            // 
            _btnPromoOK.Location = new Point(998, 7);
            _btnPromoOK.Name = "btnPromoOK";
            _btnPromoOK.Size = new Size(36, 23);
            _btnPromoOK.TabIndex = 79;
            _btnPromoOK.Text = "OK";
            _btnPromoOK.UseVisualStyleBackColor = true;
            // 
            // cboPromotion
            // 
            _cboPromotion.Cursor = Cursors.Hand;
            _cboPromotion.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPromotion.Location = new Point(409, 8);
            _cboPromotion.Name = "cboPromotion";
            _cboPromotion.Size = new Size(581, 21);
            _cboPromotion.TabIndex = 78;
            _cboPromotion.Tag = "Contract.ContractStatusID";
            // 
            // lblPromotionalOffer
            // 
            _lblPromotionalOffer.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblPromotionalOffer.Location = new Point(9, 4);
            _lblPromotionalOffer.Name = "lblPromotionalOffer";
            _lblPromotionalOffer.Size = new Size(345, 25);
            _lblPromotionalOffer.TabIndex = 77;
            _lblPromotionalOffer.Text = "Promotional Offer / Discounts";
            // 
            // grpContractType
            // 
            _grpContractType.Controls.Add(_cboContract);
            _grpContractType.Controls.Add(_lblcancel);
            _grpContractType.Controls.Add(_lblCancelReason);
            _grpContractType.Controls.Add(_btnTypeOk);
            _grpContractType.Controls.Add(_lblConType);
            _grpContractType.Controls.Add(_cboReasonID);
            _grpContractType.Controls.Add(_dtpCancelledDate);
            _grpContractType.Controls.Add(_cboContractType);
            _grpContractType.Controls.Add(_lblIsLandlord);
            _grpContractType.Location = new Point(1, 57);
            _grpContractType.Name = "grpContractType";
            _grpContractType.Size = new Size(1039, 51);
            _grpContractType.TabIndex = 94;
            // 
            // cboContract
            // 
            _cboContract.Cursor = Cursors.Hand;
            _cboContract.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboContract.Location = new Point(257, 14);
            _cboContract.Name = "cboContract";
            _cboContract.Size = new Size(379, 21);
            _cboContract.TabIndex = 69;
            _cboContract.Tag = "";
            // 
            // lblcancel
            // 
            _lblcancel.Location = new Point(254, 17);
            _lblcancel.Name = "lblcancel";
            _lblcancel.Size = new Size(79, 20);
            _lblcancel.TabIndex = 74;
            _lblcancel.Text = "Cancel Date";
            // 
            // lblCancelReason
            // 
            _lblCancelReason.Location = new Point(665, 20);
            _lblCancelReason.Name = "lblCancelReason";
            _lblCancelReason.Size = new Size(50, 20);
            _lblCancelReason.TabIndex = 73;
            _lblCancelReason.Text = "Reason";
            // 
            // btnTypeOk
            // 
            _btnTypeOk.Location = new Point(996, 15);
            _btnTypeOk.Name = "btnTypeOk";
            _btnTypeOk.Size = new Size(36, 23);
            _btnTypeOk.TabIndex = 72;
            _btnTypeOk.Text = "OK";
            _btnTypeOk.UseVisualStyleBackColor = true;
            // 
            // lblConType
            // 
            _lblConType.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblConType.Location = new Point(6, 12);
            _lblConType.Name = "lblConType";
            _lblConType.Size = new Size(207, 25);
            _lblConType.TabIndex = 71;
            _lblConType.Text = "Contract Type";
            // 
            // cboReasonID
            // 
            _cboReasonID.Cursor = Cursors.Hand;
            _cboReasonID.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboReasonID.Location = new Point(775, 15);
            _cboReasonID.Name = "cboReasonID";
            _cboReasonID.Size = new Size(215, 21);
            _cboReasonID.TabIndex = 70;
            _cboReasonID.Tag = "Contract.ContractStatusID";
            // 
            // dtpCancelledDate
            // 
            _dtpCancelledDate.Location = new Point(408, 14);
            _dtpCancelledDate.Name = "dtpCancelledDate";
            _dtpCancelledDate.Size = new Size(229, 21);
            _dtpCancelledDate.TabIndex = 69;
            // 
            // cboContractType
            // 
            _cboContractType.Cursor = Cursors.Hand;
            _cboContractType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboContractType.Location = new Point(644, 15);
            _cboContractType.Name = "cboContractType";
            _cboContractType.Size = new Size(346, 21);
            _cboContractType.TabIndex = 68;
            _cboContractType.Tag = "";
            // 
            // lblIsLandlord
            // 
            _lblIsLandlord.Location = new Point(254, 8);
            _lblIsLandlord.Name = "lblIsLandlord";
            _lblIsLandlord.Size = new Size(384, 36);
            _lblIsLandlord.TabIndex = 75;
            _lblIsLandlord.Text = "Reason";
            _lblIsLandlord.Visible = false;
            // 
            // grpAppliancesCovered
            // 
            _grpAppliancesCovered.Controls.Add(_dgSecondAssets);
            _grpAppliancesCovered.Controls.Add(_DgMain);
            _grpAppliancesCovered.Controls.Add(_btnMinusSecond);
            _grpAppliancesCovered.Controls.Add(_btnMinusMain);
            _grpAppliancesCovered.Controls.Add(_btnAddSecond);
            _grpAppliancesCovered.Controls.Add(_btnAddMain);
            _grpAppliancesCovered.Controls.Add(_LblSecondApps2);
            _grpAppliancesCovered.Controls.Add(_txtSecondryCount);
            _grpAppliancesCovered.Controls.Add(_cboSecondryApps);
            _grpAppliancesCovered.Controls.Add(_lblSecondOR);
            _grpAppliancesCovered.Controls.Add(_btnAppsOK);
            _grpAppliancesCovered.Controls.Add(_lblAdditionalApps);
            _grpAppliancesCovered.Controls.Add(_lblMainApps2);
            _grpAppliancesCovered.Controls.Add(_txtMainAppCount);
            _grpAppliancesCovered.Controls.Add(_cboMainApps);
            _grpAppliancesCovered.Controls.Add(_lblMainOR);
            _grpAppliancesCovered.Controls.Add(_lblMainApps);
            _grpAppliancesCovered.Controls.Add(_lblAppsCovered);
            _grpAppliancesCovered.Location = new Point(0, 154);
            _grpAppliancesCovered.Name = "grpAppliancesCovered";
            _grpAppliancesCovered.Size = new Size(1040, 183);
            _grpAppliancesCovered.TabIndex = 93;
            // 
            // dgSecondAssets
            // 
            _dgSecondAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dgSecondAssets.Location = new Point(645, 99);
            _dgSecondAssets.MultiSelect = false;
            _dgSecondAssets.Name = "dgSecondAssets";
            _dgSecondAssets.ReadOnly = true;
            _dgSecondAssets.RowHeadersVisible = false;
            _dgSecondAssets.ShowCellErrors = false;
            _dgSecondAssets.ShowEditingIcon = false;
            _dgSecondAssets.ShowRowErrors = false;
            _dgSecondAssets.Size = new Size(293, 70);
            _dgSecondAssets.TabIndex = 146;
            // 
            // DgMain
            // 
            _DgMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _DgMain.Location = new Point(645, 13);
            _DgMain.MultiSelect = false;
            _DgMain.Name = "DgMain";
            _DgMain.ReadOnly = true;
            _DgMain.RowHeadersVisible = false;
            _DgMain.ShowCellErrors = false;
            _DgMain.ShowEditingIcon = false;
            _DgMain.ShowRowErrors = false;
            _DgMain.Size = new Size(293, 70);
            _DgMain.TabIndex = 145;
            // 
            // btnMinusSecond
            // 
            _btnMinusSecond.Location = new Point(599, 146);
            _btnMinusSecond.Name = "btnMinusSecond";
            _btnMinusSecond.Size = new Size(39, 23);
            _btnMinusSecond.TabIndex = 144;
            _btnMinusSecond.Text = "-";
            _btnMinusSecond.UseVisualStyleBackColor = true;
            // 
            // btnMinusMain
            // 
            _btnMinusMain.Location = new Point(599, 60);
            _btnMinusMain.Name = "btnMinusMain";
            _btnMinusMain.Size = new Size(39, 23);
            _btnMinusMain.TabIndex = 143;
            _btnMinusMain.Text = "-";
            _btnMinusMain.UseVisualStyleBackColor = true;
            // 
            // btnAddSecond
            // 
            _btnAddSecond.Location = new Point(599, 122);
            _btnAddSecond.Name = "btnAddSecond";
            _btnAddSecond.Size = new Size(39, 23);
            _btnAddSecond.TabIndex = 142;
            _btnAddSecond.Text = "+";
            _btnAddSecond.UseVisualStyleBackColor = true;
            // 
            // btnAddMain
            // 
            _btnAddMain.Location = new Point(599, 36);
            _btnAddMain.Name = "btnAddMain";
            _btnAddMain.Size = new Size(39, 23);
            _btnAddMain.TabIndex = 141;
            _btnAddMain.Text = "+";
            _btnAddMain.UseVisualStyleBackColor = true;
            // 
            // LblSecondApps2
            // 
            _LblSecondApps2.Location = new Point(940, 123);
            _LblSecondApps2.Name = "LblSecondApps2";
            _LblSecondApps2.Size = new Size(87, 20);
            _LblSecondApps2.TabIndex = 140;
            _LblSecondApps2.Text = "APPLIANCES";
            // 
            // txtSecondryCount
            // 
            _txtSecondryCount.Location = new Point(973, 96);
            _txtSecondryCount.MaxLength = 100;
            _txtSecondryCount.Name = "txtSecondryCount";
            _txtSecondryCount.Size = new Size(36, 21);
            _txtSecondryCount.TabIndex = 139;
            _txtSecondryCount.Tag = "";
            // 
            // cboSecondryApps
            // 
            _cboSecondryApps.Cursor = Cursors.Hand;
            _cboSecondryApps.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSecondryApps.Location = new Point(409, 99);
            _cboSecondryApps.Name = "cboSecondryApps";
            _cboSecondryApps.Size = new Size(229, 21);
            _cboSecondryApps.TabIndex = 138;
            _cboSecondryApps.Tag = "";
            // 
            // lblSecondOR
            // 
            _lblSecondOR.Location = new Point(942, 99);
            _lblSecondOR.Name = "lblSecondOR";
            _lblSecondOR.Size = new Size(25, 20);
            _lblSecondOR.TabIndex = 137;
            _lblSecondOR.Text = "OR";
            // 
            // btnAppsOK
            // 
            _btnAppsOK.Location = new Point(995, 146);
            _btnAppsOK.Name = "btnAppsOK";
            _btnAppsOK.Size = new Size(39, 23);
            _btnAppsOK.TabIndex = 136;
            _btnAppsOK.Text = "OK";
            _btnAppsOK.UseVisualStyleBackColor = true;
            // 
            // lblAdditionalApps
            // 
            _lblAdditionalApps.Location = new Point(254, 104);
            _lblAdditionalApps.Name = "lblAdditionalApps";
            _lblAdditionalApps.Size = new Size(144, 20);
            _lblAdditionalApps.TabIndex = 134;
            _lblAdditionalApps.Text = "Additional Appliance(s)";
            // 
            // lblMainApps2
            // 
            _lblMainApps2.Location = new Point(940, 54);
            _lblMainApps2.Name = "lblMainApps2";
            _lblMainApps2.Size = new Size(87, 20);
            _lblMainApps2.TabIndex = 133;
            _lblMainApps2.Text = "APPLIANCES";
            // 
            // txtMainAppCount
            // 
            _txtMainAppCount.Location = new Point(973, 27);
            _txtMainAppCount.MaxLength = 100;
            _txtMainAppCount.Name = "txtMainAppCount";
            _txtMainAppCount.Size = new Size(36, 21);
            _txtMainAppCount.TabIndex = 132;
            _txtMainAppCount.Tag = "";
            // 
            // cboMainApps
            // 
            _cboMainApps.Cursor = Cursors.Hand;
            _cboMainApps.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboMainApps.Location = new Point(409, 13);
            _cboMainApps.Name = "cboMainApps";
            _cboMainApps.Size = new Size(229, 21);
            _cboMainApps.TabIndex = 131;
            _cboMainApps.Tag = "";
            // 
            // lblMainOR
            // 
            _lblMainOR.Location = new Point(942, 30);
            _lblMainOR.Name = "lblMainOR";
            _lblMainOR.Size = new Size(25, 20);
            _lblMainOR.TabIndex = 130;
            _lblMainOR.Text = "OR";
            // 
            // lblMainApps
            // 
            _lblMainApps.Location = new Point(254, 18);
            _lblMainApps.Name = "lblMainApps";
            _lblMainApps.Size = new Size(125, 20);
            _lblMainApps.TabIndex = 128;
            _lblMainApps.Text = "Main Appliance(s)";
            // 
            // lblAppsCovered
            // 
            _lblAppsCovered.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAppsCovered.Location = new Point(5, 13);
            _lblAppsCovered.Name = "lblAppsCovered";
            _lblAppsCovered.Size = new Size(230, 25);
            _lblAppsCovered.TabIndex = 127;
            _lblAppsCovered.Text = "Appliances Covered";
            // 
            // lblReference
            // 
            _lblReference.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblReference.Location = new Point(666, 625);
            _lblReference.Name = "lblReference";
            _lblReference.Size = new Size(228, 25);
            _lblReference.TabIndex = 79;
            _lblReference.Text = "Contract Reference: ";
            // 
            // lblMonthly
            // 
            _lblMonthly.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblMonthly.Location = new Point(5, 625);
            _lblMonthly.Name = "lblMonthly";
            _lblMonthly.Size = new Size(230, 25);
            _lblMonthly.TabIndex = 77;
            _lblMonthly.Text = "First Month Amount";
            // 
            // BtnCancel
            // 
            _BtnCancel.Enabled = false;
            _BtnCancel.Location = new Point(902, 28);
            _BtnCancel.Name = "BtnCancel";
            _BtnCancel.Size = new Size(138, 23);
            _BtnCancel.TabIndex = 38;
            _BtnCancel.Text = "CANCEL CURRENT";
            _BtnCancel.UseVisualStyleBackColor = true;
            _BtnCancel.Visible = false;
            // 
            // btnAmend
            // 
            _btnAmend.Location = new Point(427, 28);
            _btnAmend.Name = "btnAmend";
            _btnAmend.Size = new Size(146, 23);
            _btnAmend.TabIndex = 33;
            _btnAmend.Text = "AMEND CURRENT";
            _btnAmend.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            _btnNew.Location = new Point(271, 28);
            _btnNew.Name = "btnNew";
            _btnNew.Size = new Size(150, 23);
            _btnNew.TabIndex = 32;
            _btnNew.Text = "ADD NEW";
            _btnNew.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            _Label7.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _Label7.Location = new Point(2, 28);
            _Label7.Name = "Label7";
            _Label7.Size = new Size(263, 25);
            _Label7.TabIndex = 30;
            _Label7.Text = "Add, Amend or Cancel?";
            // 
            // cboSoldBy
            // 
            _cboSoldBy.Cursor = Cursors.Hand;
            _cboSoldBy.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboSoldBy.Location = new Point(776, 30);
            _cboSoldBy.Name = "cboSoldBy";
            _cboSoldBy.Size = new Size(257, 21);
            _cboSoldBy.TabIndex = 153;
            _cboSoldBy.Tag = "";
            _cboSoldBy.Visible = false;
            // 
            // lblRenewed
            // 
            _lblRenewed.AutoSize = true;
            _lblRenewed.ForeColor = Color.DarkRed;
            _lblRenewed.Location = new Point(700, 33);
            _lblRenewed.Name = "lblRenewed";
            _lblRenewed.Size = new Size(196, 13);
            _lblRenewed.TabIndex = 152;
            _lblRenewed.Text = "This Contract Has been Renewed";
            _lblRenewed.Visible = false;
            // 
            // grpContractPeriod
            // 
            _grpContractPeriod.Controls.Add(_btnPeriodOK);
            _grpContractPeriod.Controls.Add(_lblPeriod);
            _grpContractPeriod.Controls.Add(_cboPeriod);
            _grpContractPeriod.Controls.Add(_lblConPeriod);
            _grpContractPeriod.Controls.Add(_dtpContractStartDate);
            _grpContractPeriod.Controls.Add(_lblContractStartDate);
            _grpContractPeriod.Location = new Point(8, 112);
            _grpContractPeriod.Name = "grpContractPeriod";
            _grpContractPeriod.Size = new Size(1040, 48);
            _grpContractPeriod.TabIndex = 94;
            // 
            // btnPeriodOK
            // 
            _btnPeriodOK.Location = new Point(997, 11);
            _btnPeriodOK.Name = "btnPeriodOK";
            _btnPeriodOK.Size = new Size(36, 23);
            _btnPeriodOK.TabIndex = 53;
            _btnPeriodOK.Text = "OK";
            _btnPeriodOK.UseVisualStyleBackColor = true;
            // 
            // lblPeriod
            // 
            _lblPeriod.Location = new Point(667, 16);
            _lblPeriod.Name = "lblPeriod";
            _lblPeriod.Size = new Size(50, 20);
            _lblPeriod.TabIndex = 52;
            _lblPeriod.Text = "Period";
            // 
            // cboPeriod
            // 
            _cboPeriod.Cursor = Cursors.Hand;
            _cboPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPeriod.Location = new Point(776, 12);
            _cboPeriod.Name = "cboPeriod";
            _cboPeriod.Size = new Size(214, 21);
            _cboPeriod.TabIndex = 51;
            _cboPeriod.Tag = "Contract.ContractStatusID";
            // 
            // lblConPeriod
            // 
            _lblConPeriod.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblConPeriod.Location = new Point(5, 13);
            _lblConPeriod.Name = "lblConPeriod";
            _lblConPeriod.Size = new Size(207, 25);
            _lblConPeriod.TabIndex = 50;
            _lblConPeriod.Text = "Contract Period";
            // 
            // dtpContractStartDate
            // 
            _dtpContractStartDate.Location = new Point(406, 10);
            _dtpContractStartDate.Name = "dtpContractStartDate";
            _dtpContractStartDate.Size = new Size(230, 21);
            _dtpContractStartDate.TabIndex = 49;
            _dtpContractStartDate.Tag = "Contract.ContractStartDate";
            // 
            // lblContractStartDate
            // 
            _lblContractStartDate.Location = new Point(252, 13);
            _lblContractStartDate.Name = "lblContractStartDate";
            _lblContractStartDate.Size = new Size(148, 20);
            _lblContractStartDate.TabIndex = 48;
            _lblContractStartDate.Text = "Starting From";
            // 
            // grpAdditionalOptions
            // 
            _grpAdditionalOptions.Controls.Add(_btnAdditionalOK);
            _grpAdditionalOptions.Controls.Add(_lblAdditionalOptions);
            _grpAdditionalOptions.Controls.Add(_chkPlumbingDrainage);
            _grpAdditionalOptions.Controls.Add(_chkWindowLockPest);
            _grpAdditionalOptions.Controls.Add(_chkGasSupplyPipework);
            _grpAdditionalOptions.Location = new Point(8, 348);
            _grpAdditionalOptions.Name = "grpAdditionalOptions";
            _grpAdditionalOptions.Size = new Size(1040, 31);
            _grpAdditionalOptions.TabIndex = 95;
            // 
            // btnAdditionalOK
            // 
            _btnAdditionalOK.Location = new Point(996, 4);
            _btnAdditionalOK.Name = "btnAdditionalOK";
            _btnAdditionalOK.Size = new Size(39, 23);
            _btnAdditionalOK.TabIndex = 68;
            _btnAdditionalOK.Text = "OK";
            _btnAdditionalOK.UseVisualStyleBackColor = true;
            // 
            // lblAdditionalOptions
            // 
            _lblAdditionalOptions.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAdditionalOptions.Location = new Point(8, 2);
            _lblAdditionalOptions.Name = "lblAdditionalOptions";
            _lblAdditionalOptions.Size = new Size(230, 25);
            _lblAdditionalOptions.TabIndex = 67;
            _lblAdditionalOptions.Text = "Additional Options";
            // 
            // chkPlumbingDrainage
            // 
            _chkPlumbingDrainage.AutoSize = true;
            _chkPlumbingDrainage.Location = new Point(487, 9);
            _chkPlumbingDrainage.Name = "chkPlumbingDrainage";
            _chkPlumbingDrainage.Size = new Size(252, 17);
            _chkPlumbingDrainage.TabIndex = 66;
            _chkPlumbingDrainage.Text = "Plumbing, drainage and electrical cover";
            _chkPlumbingDrainage.UseVisualStyleBackColor = true;
            // 
            // chkWindowLockPest
            // 
            _chkWindowLockPest.AutoSize = true;
            _chkWindowLockPest.Location = new Point(257, 9);
            _chkWindowLockPest.Name = "chkWindowLockPest";
            _chkWindowLockPest.Size = new Size(190, 17);
            _chkWindowLockPest.TabIndex = 65;
            _chkWindowLockPest.Text = "Window, lock and pest cover";
            _chkWindowLockPest.UseVisualStyleBackColor = true;
            // 
            // chkGasSupplyPipework
            // 
            _chkGasSupplyPipework.AutoSize = true;
            _chkGasSupplyPipework.Location = new Point(775, 9);
            _chkGasSupplyPipework.Name = "chkGasSupplyPipework";
            _chkGasSupplyPipework.Size = new Size(147, 17);
            _chkGasSupplyPipework.TabIndex = 64;
            _chkGasSupplyPipework.Text = "Gas Supply Pipework";
            _chkGasSupplyPipework.UseVisualStyleBackColor = true;
            // 
            // grpPayers
            // 
            _grpPayers.Controls.Add(_grpDD);
            _grpPayers.Controls.Add(_Panel2);
            _grpPayers.Controls.Add(_Panel1);
            _grpPayers.Controls.Add(_cboInitialPaymentType);
            _grpPayers.Controls.Add(_btnPaymentOK);
            _grpPayers.Controls.Add(_lblPaymentMethod);
            _grpPayers.Controls.Add(_cboPaymentType);
            _grpPayers.Controls.Add(_cboPAyer);
            _grpPayers.Controls.Add(_lblPayer);
            _grpPayers.Controls.Add(_lblPayersDetail);
            _grpPayers.Location = new Point(8, 430);
            _grpPayers.Name = "grpPayers";
            _grpPayers.Size = new Size(1040, 69);
            _grpPayers.TabIndex = 96;
            // 
            // grpDD
            // 
            _grpDD.Controls.Add(_lblchanging);
            _grpDD.Controls.Add(_txtAccName);
            _grpDD.Controls.Add(_lbl3);
            _grpDD.Controls.Add(_txtBankName);
            _grpDD.Controls.Add(_txtAccNumber);
            _grpDD.Controls.Add(_lblBankName);
            _grpDD.Controls.Add(_lblAccNumber);
            _grpDD.Controls.Add(_txtSortCode);
            _grpDD.Controls.Add(_lblSortCode);
            _grpDD.Location = new Point(3, 31);
            _grpDD.Name = "grpDD";
            _grpDD.Size = new Size(991, 38);
            _grpDD.TabIndex = 117;
            _grpDD.Visible = false;
            // 
            // lblchanging
            // 
            _lblchanging.ForeColor = Color.Red;
            _lblchanging.Location = new Point(7, 5);
            _lblchanging.Name = "lblchanging";
            _lblchanging.Size = new Size(236, 28);
            _lblchanging.TabIndex = 129;
            _lblchanging.Text = "Changing D/D details will create a new D/D (even if original details are blank)";
            _lblchanging.Visible = false;
            // 
            // txtAccName
            // 
            _txtAccName.Location = new Point(340, 8);
            _txtAccName.Name = "txtAccName";
            _txtAccName.Size = new Size(137, 21);
            _txtAccName.TabIndex = 1;
            // 
            // lbl3
            // 
            _lbl3.Location = new Point(249, 12);
            _lbl3.Name = "lbl3";
            _lbl3.Size = new Size(89, 20);
            _lbl3.TabIndex = 110;
            _lbl3.Text = "Account Name";
            // 
            // txtBankName
            // 
            _txtBankName.Location = new Point(883, 8);
            _txtBankName.Name = "txtBankName";
            _txtBankName.Size = new Size(104, 21);
            _txtBankName.TabIndex = 4;
            // 
            // txtAccNumber
            // 
            _txtAccNumber.Location = new Point(726, 8);
            _txtAccNumber.Name = "txtAccNumber";
            _txtAccNumber.Size = new Size(84, 21);
            _txtAccNumber.TabIndex = 3;
            // 
            // lblBankName
            // 
            _lblBankName.Location = new Point(811, 11);
            _lblBankName.Name = "lblBankName";
            _lblBankName.Size = new Size(78, 20);
            _lblBankName.TabIndex = 107;
            _lblBankName.Text = "Bank Name";
            // 
            // lblAccNumber
            // 
            _lblAccNumber.Location = new Point(625, 11);
            _lblAccNumber.Name = "lblAccNumber";
            _lblAccNumber.Size = new Size(108, 20);
            _lblAccNumber.TabIndex = 106;
            _lblAccNumber.Text = "Account Number";
            // 
            // txtSortCode
            // 
            _txtSortCode.Location = new Point(544, 8);
            _txtSortCode.Name = "txtSortCode";
            _txtSortCode.Size = new Size(77, 21);
            _txtSortCode.TabIndex = 2;
            // 
            // lblSortCode
            // 
            _lblSortCode.Location = new Point(480, 12);
            _lblSortCode.Name = "lblSortCode";
            _lblSortCode.Size = new Size(73, 20);
            _lblSortCode.TabIndex = 104;
            _lblSortCode.Text = "Sort Code";
            // 
            // Panel2
            // 
            _Panel2.Location = new Point(634, 33);
            _Panel2.Name = "Panel2";
            _Panel2.Size = new Size(357, 33);
            _Panel2.TabIndex = 117;
            // 
            // Panel1
            // 
            _Panel1.Controls.Add(_lblPaidBy);
            _Panel1.Location = new Point(645, 38);
            _Panel1.Name = "Panel1";
            _Panel1.Size = new Size(110, 22);
            _Panel1.TabIndex = 116;
            // 
            // lblPaidBy
            // 
            _lblPaidBy.Location = new Point(6, 1);
            _lblPaidBy.Name = "lblPaidBy";
            _lblPaidBy.Size = new Size(106, 20);
            _lblPaidBy.TabIndex = 115;
            _lblPaidBy.Text = "Paid By:";
            // 
            // cboInitialPaymentType
            // 
            _cboInitialPaymentType.Cursor = Cursors.Hand;
            _cboInitialPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboInitialPaymentType.Location = new Point(773, 38);
            _cboInitialPaymentType.Name = "cboInitialPaymentType";
            _cboInitialPaymentType.Size = new Size(216, 21);
            _cboInitialPaymentType.TabIndex = 113;
            _cboInitialPaymentType.Tag = "Contract.ContractStatusID";
            // 
            // btnPaymentOK
            // 
            _btnPaymentOK.Location = new Point(998, 37);
            _btnPaymentOK.Name = "btnPaymentOK";
            _btnPaymentOK.Size = new Size(36, 23);
            _btnPaymentOK.TabIndex = 98;
            _btnPaymentOK.Text = "OK";
            _btnPaymentOK.UseVisualStyleBackColor = true;
            // 
            // lblPaymentMethod
            // 
            _lblPaymentMethod.Location = new Point(722, 10);
            _lblPaymentMethod.Name = "lblPaymentMethod";
            _lblPaymentMethod.Size = new Size(106, 20);
            _lblPaymentMethod.TabIndex = 93;
            _lblPaymentMethod.Text = "Payment Method";
            // 
            // cboPaymentType
            // 
            _cboPaymentType.Cursor = Cursors.Hand;
            _cboPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPaymentType.Location = new Point(834, 6);
            _cboPaymentType.Name = "cboPaymentType";
            _cboPaymentType.Size = new Size(154, 21);
            _cboPaymentType.TabIndex = 92;
            _cboPaymentType.Tag = "Contract.ContractStatusID";
            // 
            // cboPAyer
            // 
            _cboPAyer.Cursor = Cursors.Hand;
            _cboPAyer.DropDownStyle = ComboBoxStyle.DropDownList;
            _cboPAyer.Location = new Point(407, 5);
            _cboPAyer.Name = "cboPAyer";
            _cboPAyer.Size = new Size(309, 21);
            _cboPAyer.TabIndex = 91;
            _cboPAyer.Tag = "";
            // 
            // lblPayer
            // 
            _lblPayer.Location = new Point(252, 10);
            _lblPayer.Name = "lblPayer";
            _lblPayer.Size = new Size(59, 20);
            _lblPayer.TabIndex = 90;
            _lblPayer.Text = "Payer";
            // 
            // lblPayersDetail
            // 
            _lblPayersDetail.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblPayersDetail.Location = new Point(9, 5);
            _lblPayersDetail.Name = "lblPayersDetail";
            _lblPayersDetail.Size = new Size(230, 25);
            _lblPayersDetail.TabIndex = 89;
            _lblPayersDetail.Text = "Payers Detail";
            // 
            // grpAdditionalDetails
            // 
            _grpAdditionalDetails.Controls.Add(_chkCommercial);
            _grpAdditionalDetails.Controls.Add(_chkLandlord);
            _grpAdditionalDetails.Controls.Add(_txtNotesToEngineer);
            _grpAdditionalDetails.Controls.Add(_lblServiceNotes);
            _grpAdditionalDetails.Controls.Add(_txtPONumber);
            _grpAdditionalDetails.Controls.Add(_lblPO);
            _grpAdditionalDetails.Controls.Add(_lblAddDetails);
            _grpAdditionalDetails.Location = new Point(8, 509);
            _grpAdditionalDetails.Name = "grpAdditionalDetails";
            _grpAdditionalDetails.Size = new Size(1040, 87);
            _grpAdditionalDetails.TabIndex = 96;
            // 
            // chkCommercial
            // 
            _chkCommercial.AutoSize = true;
            _chkCommercial.Location = new Point(487, 55);
            _chkCommercial.Name = "chkCommercial";
            _chkCommercial.Size = new Size(123, 17);
            _chkCommercial.TabIndex = 8;
            _chkCommercial.Text = "Commercial Plan";
            _chkCommercial.UseVisualStyleBackColor = true;
            // 
            // chkLandlord
            // 
            _chkLandlord.AutoSize = true;
            _chkLandlord.Location = new Point(256, 55);
            _chkLandlord.Name = "chkLandlord";
            _chkLandlord.Size = new Size(159, 17);
            _chkLandlord.TabIndex = 7;
            _chkLandlord.Text = "Landlord Cert Required";
            _chkLandlord.UseVisualStyleBackColor = true;
            // 
            // txtNotesToEngineer
            // 
            _txtNotesToEngineer.Location = new Point(773, 8);
            _txtNotesToEngineer.Multiline = true;
            _txtNotesToEngineer.Name = "txtNotesToEngineer";
            _txtNotesToEngineer.Size = new Size(216, 71);
            _txtNotesToEngineer.TabIndex = 6;
            // 
            // lblServiceNotes
            // 
            _lblServiceNotes.Location = new Point(650, 8);
            _lblServiceNotes.Name = "lblServiceNotes";
            _lblServiceNotes.Size = new Size(114, 20);
            _lblServiceNotes.TabIndex = 89;
            _lblServiceNotes.Text = "Service Visit Notes";
            // 
            // txtPONumber
            // 
            _txtPONumber.Location = new Point(408, 8);
            _txtPONumber.Name = "txtPONumber";
            _txtPONumber.Size = new Size(229, 21);
            _txtPONumber.TabIndex = 5;
            // 
            // lblPO
            // 
            _lblPO.Location = new Point(254, 11);
            _lblPO.Name = "lblPO";
            _lblPO.Size = new Size(159, 20);
            _lblPO.TabIndex = 86;
            _lblPO.Text = "PO Number";
            // 
            // lblAddDetails
            // 
            _lblAddDetails.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point, Conversions.ToByte(0));
            _lblAddDetails.Location = new Point(6, 8);
            _lblAddDetails.Name = "lblAddDetails";
            _lblAddDetails.Size = new Size(230, 25);
            _lblAddDetails.TabIndex = 85;
            _lblAddDetails.Text = "Additional Details";
            // 
            // UCContractWiz
            // 
            Controls.Add(_grpAdditionalDetails);
            Controls.Add(_grpPayers);
            Controls.Add(_grpAdditionalOptions);
            Controls.Add(_grpContractPeriod);
            Controls.Add(_grpContract);
            Name = "UCContractWiz";
            Size = new Size(1095, 701);
            _grpContract.ResumeLayout(false);
            _grpContract.PerformLayout();
            _grpPromo.ResumeLayout(false);
            _grpContractType.ResumeLayout(false);
            _grpAppliancesCovered.ResumeLayout(false);
            _grpAppliancesCovered.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dgSecondAssets).EndInit();
            ((System.ComponentModel.ISupportInitialize)_DgMain).EndInit();
            _grpContractPeriod.ResumeLayout(false);
            _grpAdditionalOptions.ResumeLayout(false);
            _grpAdditionalOptions.PerformLayout();
            _grpPayers.ResumeLayout(false);
            _grpDD.ResumeLayout(false);
            _grpDD.PerformLayout();
            _Panel1.ResumeLayout(false);
            _grpAdditionalDetails.ResumeLayout(false);
            _grpAdditionalDetails.PerformLayout();
            ResumeLayout(false);
        }

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

        public event RecordsChangedEventHandler RecordsChanged;

        public delegate void RecordsChangedEventHandler(DataView dv, Enums.PageViewing pageIn, bool FromASave, bool FromADelete, string extraText);

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
                }

                if (_currentContract.Exists)
                {
                    dtpContractStartDate.Enabled = false;
                }
                else
                {
                    lblTotalEst.Text = Strings.Format(Conversions.ToDouble(0.0), "C");
                }

                if (CurrentContractSite is null)
                {
                    CurrentContractSite = new Entity.ContractOriginalSites.ContractOriginalSite();
                    CurrentContractSite.Exists = false;
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
                Sites = App.DB.ContractOriginalSite.GetAll_ContractID(CurrentContract.ContractID, IDToLinkTo);
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
                _Sites.Table.TableName = Enums.TableNames.tblContractSite.ToString();
                _Sites.AllowNew = false;
                _Sites.AllowEdit = false;
                _Sites.AllowDelete = false;
                SiteID = SiteID;
            }
        }

        private DataView _MainDataView = null;

        public DataView MainDataView
        {
            get
            {
                return _MainDataView;
            }

            set
            {
                _MainDataView = value;
                _MainDataView.Table.TableName = "MainApps";
                _MainDataView.AllowNew = false;
                _MainDataView.AllowEdit = true;
                _MainDataView.AllowDelete = false;
                DgMain.DataSource = MainDataView;
            }
        }

        private DataGridViewRow SelectedMainDataRow
        {
            get
            {
                if (DgMain.CurrentRow is object && !(DgMain.CurrentRow.Index == -1))
                {
                    return DgMain.CurrentRow;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _SecondAppliances;

        private DataView SecondAppliances
        {
            get
            {
                return _SecondAppliances;
            }

            set
            {
                _SecondAppliances = value;
                _SecondAppliances.AllowDelete = false;
                _SecondAppliances.AllowEdit = false;
                _SecondAppliances.AllowNew = false;
                _SecondAppliances.Table.TableName = Enums.TableNames.tblInvoiceAddress.ToString();
                dgSecondAssets.DataSource = SecondAppliances;
            }
        }

        private DataGridViewRow SelectedSecondAppDataRow
        {
            get
            {
                if (dgSecondAssets.CurrentRow is object && !(dgSecondAssets.CurrentRow.Index == -1))
                {
                    return dgSecondAssets.CurrentRow;
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
                if (App.DB.ContractOriginal.GetAll_ForSite_Active(SiteID).Table.Rows.Count == 0)
                {
                    btnAmend.Enabled = false;
                }
                else
                {
                    btnAmend.Enabled = true;
                }

                if (SiteID > 0 & IDToLinkTo == (int)Enums.Customer.Domestic)
                {
                    _Sites.RowFilter = "SiteID=" + SiteID;
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

        private double _Price = 0.0;

        public double Price
        {
            get
            {
                return _Price;
            }

            set
            {
                _Price = value;
            }
        }

        private JobNumber _jobNumber = null;

        public JobNumber Number
        {
            get
            {
                return _jobNumber;
            }

            set
            {
                _jobNumber = value;
            }
        }

        private Entity.ContractOriginalSites.ContractOriginalSite _currentContractSite;

        public Entity.ContractOriginalSites.ContractOriginalSite CurrentContractSite
        {
            get
            {
                return _currentContractSite;
            }

            set
            {
                _currentContractSite = value;
                if (_currentContractSite is null)
                {
                    _currentContractSite = new Entity.ContractOriginalSites.ContractOriginalSite();
                    _currentContractSite.Exists = false;
                }
            }
        }

        private string p = "Gasway100";
        private DateTime newdate;
        private Control[] c;
        private Button b;
        private double discount = 0.0;
        private bool needDD = true;
        private DateTime EffDate = DateTime.MinValue;
        private DateTime OldEndDate;
        private int NewSiteID = 0;
        private string NewPayer = "";
        private string ddsort = "";
        private string ddAcc = "";
        private bool Offset = true;
        private string ManualApp = "";
        private string SecondApp = "";
        private JobNumber Jn;
        private string PreviousRef = "";
        private double previousFirst = 0;
        private double previousSecond = 0;
        private double previousTotal = 0;
        private bool OverridePrice = false;

        public void SetupMainDataGrid()
        {
            DgMain.Columns[0].Visible = false;
            DgMain.ColumnHeadersVisible = false;
            DgMain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DgMain.AllowUserToAddRows = false;
        }

        public void SetupSecondryDataGrid()
        {
            dgSecondAssets.Columns[0].Visible = false;
            dgSecondAssets.ColumnHeadersVisible = false;
            dgSecondAssets.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgSecondAssets.AllowUserToAddRows = false;
        }

        private void UCContract_Load(object sender, EventArgs e)
        {
            LoadForm(sender, e);
            grpAppliancesCovered.Visible = false;
            grpContractType.Visible = false;
            grpContractPeriod.Visible = false;
            grpAdditionalDetails.Visible = false;
            grpAdditionalOptions.Visible = false;
            grpPayers.Visible = false;
            grpPromo.Visible = false;
        }

        private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboContractType)) > 0)
            {
                if (CurrentContractSite.Exists)
                {
                    lblContractRef.Text = CurrentContract.ContractReference;
                    if (((b.Text ?? "") == "Amend Contract" | (b.Text ?? "") == "Renew Contract") & CurrentContract.ContractTypeID != Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboContractType)))
                    {
                        OverridePrice = false;
                        if (Number is object)
                        {
                            App.DB.Job.DeleteReservedOrderNumber(Number.Number, Number.Prefix);
                        }

                        Number = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)Combo.get_GetSelectedItemValue(cboContractType));
                        if (Number.Number.ToString().Length < 3)
                        {
                            lblContractRef.Text = Number.Prefix + "00" + Number.Number;
                        }
                        else if (Number.Number.ToString().Length < 4)
                        {
                            lblContractRef.Text = Number.Prefix + "0" + Number.Number;
                        }
                        else
                        {
                            lblContractRef.Text = Number.Prefix + Number.Number;
                        }
                    }
                }
                else
                {
                    if (Number is object)
                    {
                        App.DB.Job.DeleteReservedOrderNumber(Number.Number, Number.Prefix);
                    }

                    Number = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)Combo.get_GetSelectedItemValue(cboContractType));
                    if (Number.Number.ToString().Length < 3)
                    {
                        lblContractRef.Text = Number.Prefix + "00" + Number.Number;
                    }
                    else if (Number.Number.ToString().Length < 4)
                    {
                        lblContractRef.Text = Number.Prefix + "0" + Number.Number;
                    }
                    else
                    {
                        lblContractRef.Text = Number.Prefix + Number.Number;
                    }
                }

                if (!CurrentContract.Exists)
                {
                    if ((Combo.get_GetSelectedItemDescription(cboContractType) ?? "") == "Totally Assured")
                    {
                        var argc = cboPeriod;
                        Combo.SetUpCombo(ref argc, DynamicDataTables.ContractPeriod, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
                    }
                    else
                    {
                        cboPeriod.Items.Clear();
                        cboPeriod.Items.Add(new Combo("-- Please Select --", "0"));
                        cboPeriod.Items.Add(new Combo("1 Year", "1"));
                        cboPeriod.DisplayMember = "Description";
                        cboPeriod.ValueMember = "Value";
                        var argcombo = cboPeriod;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
                        if ((b.Text ?? "") == "Amend Contract" | (b.Text ?? "") == "Renew Contract")
                        {
                            var argcombo1 = cboPeriod;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo1, "1");
                        }
                    }
                }

                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)) > 1 & (chkGasSupplyPipework.Checked | chkPlumbingDrainage.Checked | chkWindowLockPest.Checked))
                {
                    App.ShowMessage("Additional Options can not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    chkWindowLockPest.Checked = false;
                    chkPlumbingDrainage.Checked = false;
                    chkGasSupplyPipework.Checked = false;
                    return;
                }
                else
                {
                    DoTotals();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            btnTypeOk.Visible = true;
            var dt = App.DB.ContractOriginal.GetAll_ForSite_Active(SiteID).Table;
            if (dt.Rows.Count > 0)
            {
                if (App.ShowMessage("Contracts already exist for this site are you sure you wish to add a new contract?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            c = ParentForm.Controls.Find("btnSave", true);
            b = (Button)c[0];
            b.Text = "Create Contract";
            b.Visible = false;
            cboSoldBy.SelectedValue = App.loggedInUser.UserID;
            lblsold.Visible = true;
            cboSoldBy.Visible = true;
            btnTransfer.Visible = false;
            lblIsLandlord.Visible = true;
            lblIsLandlord.Text = "Is this a Landlords property? - Please attached L/L before continuing";
            cboContract.Visible = false;
            grpAppliancesCovered.Visible = false;
            grpContractPeriod.Visible = false;
            grpAdditionalDetails.Visible = false;
            grpAdditionalOptions.Visible = false;
            grpPayers.Visible = false;
            grpPromo.Visible = false;
            var argc = cboMainApps;
            Combo.SetUpCombo(ref argc, App.DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
            var argc1 = cboSecondryApps;
            Combo.SetUpCombo(ref argc1, App.DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
            PayerDrop();
            MainDataView = App.DB.ContractOriginal.GetAssetsForContract(0, true);
            SecondAppliances = App.DB.ContractOriginal.GetAssetsForContract(0, false);
            SetupMainDataGrid();
            SetupSecondryDataGrid();
            grpContractType.Visible = true;
            lblcancel.Visible = false;
            lblCancelReason.Visible = false;
            dtpCancelledDate.Visible = false;
            cboReasonID.Visible = false;
            needDD = true;
            lblchanging.Visible = false;
        }

        private void btnAmend_Click(object sender, EventArgs e)
        {
            lblsold.Visible = false;
            cboSoldBy.Visible = false;
            c = ParentForm.Controls.Find("btnSave", true);
            b = (Button)c[0];
            b.Text = "Amend Contract";
            b.Enabled = false;
            grpContractType.Visible = true;
            cboContract.Visible = true;
            lblcancel.Visible = false;
            lblCancelReason.Visible = false;
            dtpCancelledDate.Visible = false;
            cboReasonID.Visible = false;
            cboPaymentType.Enabled = false;
            lblIsLandlord.Visible = false;
            ContractDrop();
            var argc = cboMainApps;
            Combo.SetUpCombo(ref argc, App.DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
            var argc1 = cboSecondryApps;
            Combo.SetUpCombo(ref argc1, App.DB.Asset.Asset_GetForSite(SiteID).Table, "AssetID", "Product", Enums.ComboValues.Please_Select);
            lblchanging.Visible = true;
            needDD = false;
            b.Enabled = false;
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            var f = new DLGFindSite();
            f.TableToSearch = Enums.TableNames.tblSite;
            f.AddressID = CurrentContract.InvoiceAddressID.ToString();
            f.InvoiceFrequencyID = CurrentContract.InvoiceFrequencyID.ToString();
            f.ShowDialog();
            NewSiteID = f.ID;
            NewPayer = f.SecondID; // amigination
            EffDate = f.EffDate;
            if (CurrentContract.InvoiceFrequencyID == (int)Enums.InvoiceFrequency.Bi_Annually & (Conversions.ToDouble(NewPayer.Split('`')[0]) != CurrentContract.InvoiceAddressID | Conversions.ToDouble(NewPayer.Split('`')[1]) != CurrentContract.InvoiceAddressTypeID))
            {
                // D/D details are changing
                txtAccName.Text = "";
                txtAccNumber.Text = "";
                txtBankName.Text = "";
                txtSortCode.Text = "";
                grpAdditionalDetails.Visible = false;
                b.Text = "Transfer Contract";
                b.Enabled = false;
            }
            else
            {
                grpAdditionalDetails.Visible = false;
                b.Text = "Transfer Contract";
                b.Enabled = false;
            }

            // '''' redo payer dropdown
            var dt = App.DB.InvoiceAddress.InvoiceAddress_Get_SiteID(NewSiteID).Table;
            cboPAyer.Items.Clear();
            foreach (DataRow dr in dt.Rows)
                cboPAyer.Items.Add(new Combo(Conversions.ToString(Conversions.ToString(Conversions.ToString(dr["Address1"] + ",") + dr["Address2"] + ",") + dr["Postcode"]), Conversions.ToString(Conversions.ToString(dr["AddressID"] + "`") + dr["AddressTypeID"])));
            cboPAyer.Items.Add(new Combo("-- Please Select --", 0.ToString()));
            cboPAyer.DisplayMember = "Description";
            cboPAyer.ValueMember = "Value";
            var argcombo = cboPAyer;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, NewPayer);
            lblchanging.Visible = true;
        }

        private void btnAddMain_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboMainApps)) > 0)
            {
                MainDataView.AllowNew = true;
                var newrow = MainDataView.AddNew();
                newrow["AssetID"] = Combo.get_GetSelectedItemValue(cboMainApps);
                newrow["Product"] = Combo.get_GetSelectedItemDescription(cboMainApps);
                newrow.EndEdit();
                DgMain.DataSource = MainDataView;
            }

            txtMainAppCount.Text = DgMain.Rows.Count.ToString();
            DoTotals();
        }

        private void btnAddSecond_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboSecondryApps)) > 0)
            {
                SecondAppliances.AllowNew = true;
                var newrow = SecondAppliances.AddNew();
                newrow["AssetID"] = Combo.get_GetSelectedItemValue(cboSecondryApps);
                newrow["Product"] = Combo.get_GetSelectedItemDescription(cboSecondryApps);
                newrow.EndEdit();
                dgSecondAssets.DataSource = SecondAppliances;
            }

            txtSecondryCount.Text = dgSecondAssets.Rows.Count.ToString();
            DoTotals();
        }

        private void btnTypeOk_Click_1(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboContractType)) > 0)
            {
                grpContractPeriod.Visible = true;
                DoTotals();
            }
            else
            {
                App.ShowMessage("You Must Select a contract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPeriodOK_Click_1(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)) > 0)
            {
                grpAppliancesCovered.Visible = true;
                DoTotals();
            }
            else
            {
                App.ShowMessage("You Must Select a Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAppsOK_Click(object sender, EventArgs e)
        {
            if (DgMain.RowCount == 0 & Conversions.ToDouble(CBT(txtMainAppCount.Text)) > 0)
            {
                var f = new FRMManualApp();
                f.lblMsg.Text = "As you haven't identified the main applaince, please provide one below.";
                f.ShowDialog();
                ManualApp = Combo.get_GetSelectedItemDescription(f.cboInitialPaymentType);
            }

            if (dgSecondAssets.RowCount == 0 & Conversions.ToDouble(CBT(txtSecondryCount.Text)) > 0)
            {
                var f = new FRMManualApp();
                f.lblMsg.Text = "As you haven't identified the second applaince, please provide one below.";
                f.ShowDialog();
                SecondApp = Combo.get_GetSelectedItemDescription(f.cboInitialPaymentType);
            }

            if (Conversions.ToDouble(CBT(txtMainAppCount.Text) + CBT(txtSecondryCount.Text)) > 0)
            {
                grpAdditionalOptions.Visible = true;
                DoTotals();
            }
            else
            {
                App.ShowMessage("You Must add at least one appliance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPromoOK_Click(object sender, EventArgs e)
        {
            grpPayers.Visible = true;
            DoTotals();
            App.ShowMessage("Please be aware that all levels of cover exclude damage caused by scale, shale and sludge, plus the removal of such debris. " + Constants.vbNewLine + "The repair or replacement of flues or their components is also excluded, as is pipework located inside the fabric of the building." + Constants.vbNewLine + "All cover plans are twelve month contracts, and cancellation during the cover period may not entitle you to a refund." + Constants.vbNewLine + "During our first visit under cover, if we find that the appliance is in a seriously degraded state, then we may cancel your plan and return any policy payments made to that point", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnPaymentOK_Click(object sender, EventArgs e)
        {
            int paymentType = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPaymentType));
            if (paymentType == (int)Enums.ContractPaymentType.Direct_Debit & (txtAccNumber.Text ?? "") == (ddAcc ?? "") & (b.Text ?? "") != "Create Contract") // ddAcc  is used in amending to record original data if there is none it will still spot the change
            {
                grpAdditionalDetails.Visible = true;
                DoTotals();
                if (Conversions.ToDouble(lblTotalEst.Text) == 0 & discount != 100)
                {
                    var f = new FRMNewPrice();
                    f.ShowDialog();
                    if (Information.IsNumeric(f.txtPrice.Text) && Conversions.ToDouble(f.txtPrice.Text) > 0)
                    {
                        lblTotalEst.Text = Strings.Format(Conversions.ToDouble(f.txtPrice.Text), "C");
                        lblMonthlyEst.Text = Strings.Format(Conversions.ToDouble(lblTotalEst.Text) / 12, "C");
                        lblFollowedBy.Text = Strings.Format(Conversions.ToDouble(lblTotalEst.Text) / 12, "C");
                        OverridePrice = true;
                    }
                }

                b.Visible = true;
                b.Enabled = true;
            }
            else
            {
                discount = (double)App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPromotion)))?.PercentageRate;
                int contractType = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContractType));
                if (contractType == (int)Enums.ContractTypes.EmployeeFree | contractType == (int)Enums.ContractTypes.FamilyFree)
                {
                    discount = 100;
                }

                if (Conversions.ToDouble(lblTotalEst.Text) == 0 & discount != 100)
                {
                    var f = new FRMNewPrice();
                    f.ShowDialog();
                    if (Information.IsNumeric(f.txtPrice.Text) && Conversions.ToDouble(f.txtPrice.Text) > 0)
                    {
                        lblTotalEst.Text = Strings.Format(Conversions.ToDouble(f.txtPrice.Text), "C");
                        lblMonthlyEst.Text = Strings.Format(Conversions.ToDouble(lblTotalEst.Text) / 12, "C");
                        lblFollowedBy.Text = Strings.Format(Conversions.ToDouble(lblTotalEst.Text) / 12, "C");
                        OverridePrice = true;
                    }
                }

                if (Conversions.ToDouble(lblTotalEst.Text) > 0)
                {
                    if ((Combo.get_GetSelectedItemValue(cboPAyer) ?? "") != "0" & paymentType > 0)
                    {
                        if (paymentType == (int)Enums.ContractPaymentType.Direct_Debit & txtBankName.Text.Length > 0 & txtAccName.Text.Length > 2 & txtAccNumber.Text.Length < 9 & txtAccNumber.Text.Length > 2 & txtSortCode.Text.Length > 5 & txtSortCode.Text.Length < 7 | paymentType != (int)Enums.ContractPaymentType.Direct_Debit)
                        {
                            if ((b.Text ?? "") == "Create Contract" | (b.Text ?? "") == "Renew Contract")
                            {
                                var f = new FRMGenDropBox();
                                var switchExpr = Combo.get_GetSelectedItemValue(cboPaymentType);
                                switch (switchExpr)
                                {
                                    case var @case when @case == Conversions.ToString(Enums.ContractPaymentType.Annual):
                                        {
                                            f.lblTop.Text = "You Must Take Full Payment Now In order to set up this Contract.";
                                            break;
                                        }

                                    default:
                                        {
                                            App.ShowMessage("All Direct Debits are protected by a guarantee. Would you like me to read the guarantee to you, or you can read it in the confirmation letter? " + Constants.vbNewLine + Constants.vbNewLine + "This guarantee is offered by all banks and building societies that take part in the Direct Debit scheme.If the amounts to be paid or the payment dates change, " + "Gasway Services Ltd will notify you 10 working days in advance of your account being debited Or as otherwise agreed. " + "If an error Is made by Gasway Services Ltd Or your bank Or building society, you are guaranteed a full And immediate refund from your branch of the amount paid. " + "You can cancel a Direct Debit at any time by writing to your bank Or building society.  Please also send a copy of your letter to us.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            f.lblTop.Text = "You Must Take the first Payment Now, In order to set up this Contract.";
                                            break;
                                        }
                                }

                                f.ShowDialog();
                                var argcombo = cboInitialPaymentType;
                                Combo.SetSelectedComboItem_By_Value(ref argcombo, Combo.get_GetSelectedItemValue(f.cbo1));
                                if ((Combo.get_GetSelectedItemValue(cboInitialPaymentType) ?? "") == "0")
                                {
                                    return;
                                }
                                else
                                {
                                    ShowAdditionalDetails();
                                }
                            }

                            ShowAdditionalDetails();
                        }
                        else
                        {
                            App.ShowMessage("You must enter Bank name, Account name, sortcode (6 Digits) And account code (8 digits) correctly for Direct Debit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        App.ShowMessage("You must select a payer And payment method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else if (discount == 100)
                {
                    ShowAdditionalDetails();
                }
                else
                {
                    App.ShowMessage("You cannot create a contract of Zero Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ShowAdditionalDetails()
        {
            grpAdditionalDetails.Visible = true;
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboContractType)) != (double)Enums.ContractTypes.PreventativeMaintenance)
            {
                DoTotals();
            }

            b.Visible = true;
            b.Enabled = true;
            dtpContractStartDate.Enabled = false;
        }

        private void cboPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPaymentType = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPaymentType));
            if ((b?.Text ?? "") == "Create Contract")
            {
                b.Visible = false;
                grpAdditionalDetails.Visible = false;
            }

            if (selectedPaymentType == (int)Enums.ContractPaymentType.Annual | selectedPaymentType == 0)
            {
                // annual
                grpDD.Visible = false;
            }
            else
            {
                // DirectDebit
                grpDD.Visible = true;
            }
        }

        private void btnAdditionalOK_Click(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)) > 1 & (chkGasSupplyPipework.Checked | chkPlumbingDrainage.Checked | chkWindowLockPest.Checked))
            {
                App.ShowMessage("Additional Options can Not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                grpPromo.Visible = true;
                DoTotals();
            }
        }

        private void btnMinusMain_Click(object sender, EventArgs e)
        {
            if (DgMain.CurrentRow is object)
            {
                MainDataView.AllowDelete = true;
                MainDataView.Table.Rows.RemoveAt(SelectedMainDataRow.Index);
                txtMainAppCount.Text = DgMain.Rows.Count.ToString();
                DoTotals();
            }
        }

        private void btnMinusSecond_Click(object sender, EventArgs e)
        {
            if (dgSecondAssets.CurrentRow is object)
            {
                SecondAppliances.AllowDelete = true;
                SecondAppliances.Table.Rows.RemoveAt(SelectedSecondAppDataRow.Index);
                txtSecondryCount.Text = dgSecondAssets.Rows.Count.ToString();
                DoTotals();
            }
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)) > 0)
            {
                if (b is object)
                {
                    b.Enabled = true;
                }

                DoTotals();
            }
            else if (b is object)
            {
                b.Enabled = false;
            }
        }

        private void cboPromotion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPromotion)) > 0)
            {
                discount = App.DB.Picklists.Get_One_As_Object(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPromotion))).PercentageRate;
            }
            else
            {
                var argcombo = cboPromotion;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
                discount = 0;
            }

            DoTotals();
        }

        private void cboContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Combo.get_GetSelectedItemValue(cboContract) ?? "") != "0")
            {
                CurrentContract = App.DB.ContractOriginal.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContract).Split('`')[0]));
                CurrentContractSite = App.DB.ContractOriginalSite.Get(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContract).Split('`')[1]));
                if ((b.Text ?? "") == "Amend Contract")
                {
                    lblContractStartDate.Text = "Change Effective from";
                    var argcombo = cboPeriod;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, "1");
                    cboPeriod.Enabled = false;
                    btnPeriodOK.Enabled = true;
                }
                else
                {
                    lblContractStartDate.Text = "Starting From";
                    lblPeriod.Visible = true;
                    cboPeriod.Visible = true;
                }

                grpContractPeriod.Visible = true;
                grpContractPeriod.Enabled = true;
                PayerDrop();
                lblcancel.Visible = false;
                lblCancelReason.Visible = false;
                dtpCancelledDate.Visible = false;
                cboReasonID.Visible = false;
                MainDataView = App.DB.ContractOriginal.GetAssetsForContract(0, true);
                SecondAppliances = App.DB.ContractOriginal.GetAssetsForContract(0, false);
                SetupMainDataGrid();
                SetupSecondryDataGrid();
                Populate();
                btnTypeOk.Visible = true;
                cboContractType.Enabled = true;
                BtnCancel.Visible = true;
                int renewed = Conversions.ToInteger(App.DB.ExecuteScalar("Select Count(*) FROM tblContractRenewals WHERE OldContractID = " + CurrentContract.ContractID));
                if (renewed > 0)
                {
                    btnTransfer.Visible = true;
                    btnRenew.Visible = false;
                    lblRenewed.Visible = true;
                }
                else
                {
                    btnTransfer.Visible = true;
                    btnRenew.Visible = true;
                    lblRenewed.Visible = false;
                }
            }
            else if ((b.Text ?? "") == "Amend Contract")
            {
                btnTypeOk.Visible = false;
                cboContractType.Enabled = false;
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            c = ParentForm.Controls.Find("btnSave", true);
            b = (Button)c[0];
            b.Text = "Renew Contract";
            b.Enabled = false;
            btnRenew.BackColor = Color.Blue;
            grpAppliancesCovered.Enabled = true;
            grpContractPeriod.Enabled = true;
            grpAppliancesCovered.Visible = true;
            grpAdditionalOptions.Visible = true;
            grpPromo.Enabled = true;
            grpPayers.Visible = true;
            cboPaymentType.Enabled = true;
            DoTotals();
            dtpContractStartDate.Value = CurrentContract.ContractEndDate.AddDays(1);
            grpAdditionalDetails.Visible = false;
            btnPaymentOK.ForeColor = Color.OrangeRed;
            if ((CurrentContract.ContractType ?? "") == "68032")   // '''swap to PLAT STAR
            {
                CurrentContract.SetContractType = Enums.ContractTypes.PlatinumStar;
                var argcombo = cboContractType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, Conversions.ToString(Enums.ContractTypes.PlatinumStar));
                if (Number is object)
                {
                    App.DB.Job.DeleteReservedOrderNumber(Number.Number, Number.Prefix);
                }

                Number = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)Enums.ContractTypes.PlatinumStar);
                if (Number.Number.ToString().Length < 3)
                {
                    lblContractRef.Text = Number.Prefix + "00" + Number.Number;
                }
                else if (Number.Number.ToString().Length < 4)
                {
                    lblContractRef.Text = Number.Prefix + "0" + Number.Number;
                }
                else
                {
                    lblContractRef.Text = Number.Prefix + Number.Number;
                }

                CurrentContract.SetContractReference = lblContractRef.Text;
                DoTotals();
            }
        }

        private void cboSoldBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoldBy.Visible == false)
            {
                return;
            }

            if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Invoicing))
            {
            }
            else
            {
                App.ShowMessage("You can not authorise discounts on this plan", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cboSoldBy.SelectedValue = App.loggedInUser.UserID;
                return;
            }
        }

        private void chkWindowLockPest_CheckedChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)) > 1 & (chkGasSupplyPipework.Checked | chkPlumbingDrainage.Checked | chkWindowLockPest.Checked))
            {
                App.ShowMessage("Additional Options can not be added to a plan which runs for more than one year.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chkWindowLockPest.Checked = false;
                chkPlumbingDrainage.Checked = false;
                chkGasSupplyPipework.Checked = false;
                return;
            }
            else
            {
                DoTotals();
            }
        }

        private void txtMainAppCount_TextChanged(object sender, EventArgs e)
        {
            if (Conversions.ToDouble(CBT(txtMainAppCount.Text) + CBT(txtSecondryCount.Text)) > 0)
            {
                DoTotals();
                if (b is object)
                {
                    b.Enabled = true;
                }
            }
            else
            {
                DoTotals();
                if (b is object)
                {
                    b.Enabled = false;
                }
            }
        }

        private void Populate(int ID = 0)
        {
            MainDataView = App.DB.ContractOriginal.GetAssetsForContract(CurrentContractSite.ContractSiteID, true);
            SecondAppliances = App.DB.ContractOriginal.GetAssetsForContract(CurrentContractSite.ContractSiteID, false);
            txtMainAppCount.Text = MainDataView.Table.Rows.Count.ToString();
            txtSecondryCount.Text = SecondAppliances.Table.Rows.Count.ToString();
            var argcombo = cboContractType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, CurrentContract.ContractTypeID.ToString());
            dtpContractStartDate.Value = CurrentContract.ContractStartDate;
            int dd1 = Conversions.ToInteger(DateHelper.GetYearsBetween(CurrentContract.ContractStartDate, CurrentContract.ContractEndDate.AddDays(10)));
            if (dd1 == 0)
                dd1 = 1;
            var argcombo1 = cboPeriod;
            Combo.SetSelectedComboItem_By_Value(ref argcombo1, dd1.ToString());
            if (CurrentContract.ContractPriceAfterVAT > 0)
            {
                lblTotalEst.Text = Strings.Format(CurrentContract.ContractPriceAfterVAT, "C");
            }
            else
            {
                lblTotalEst.Text = Strings.Format(Conversions.ToDouble(CurrentContract.ContractPrice) * 1.2, "C");
            }

            previousTotal = Conversions.ToDouble(lblTotalEst.Text);
            double theRounded = Math.Round(Conversions.ToDouble(lblTotalEst.Text) / 12, 2);
            previousFirst = Conversions.ToDouble(Strings.Format(theRounded + (Conversions.ToDouble(lblTotalEst.Text) - theRounded * 12), "C"));
            previousSecond = Conversions.ToDouble(Strings.Format(theRounded, "C"));
            txtPONumber.Text = CurrentContract.PoNumber;

            // TODO sortcode and account numbers
            var argcombo2 = cboPromotion;
            Combo.SetSelectedComboItem_By_Value(ref argcombo2, CurrentContract.DiscountID.ToString());
            txtBankName.Text = CurrentContract.BankName;
            txtAccNumber.Text = CurrentContract.AccountNumber;
            txtSortCode.Text = CurrentContract.SortCode;
            chkGasSupplyPipework.Checked = CurrentContract.GasSupplyPipework;
            chkPlumbingDrainage.Checked = CurrentContract.PlumbingDrainage;
            chkWindowLockPest.Checked = CurrentContract.WindowLockPest;
            chkLandlord.Checked = CurrentContractSite.LLCertReqd;
            chkCommercial.Checked = CurrentContractSite.Commercial;
            txtNotesToEngineer.Text = CurrentContractSite.AdditionalNotes;
            var argcombo3 = cboPAyer;
            Combo.SetSelectedComboItem_By_Value(ref argcombo3, CurrentContract.InvoiceAddressID + "`" + CurrentContract.InvoiceAddressTypeID);
            if (CurrentContract.InvoiceFrequencyID == (int)Enums.InvoiceFrequency.Monthly)
            {
                var argcombo4 = cboPaymentType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo4, Conversions.ToInteger(Enums.ContractPaymentType.Direct_Debit).ToString());
            } // dd

            if (CurrentContract.InvoiceFrequencyID == (int)Enums.InvoiceFrequency.Annually)
            {
                var argcombo5 = cboPaymentType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo5, Conversions.ToInteger(Enums.ContractPaymentType.Annual).ToString());
            } // Ann

            if (CurrentContract.InvoiceFrequencyID == (int)Enums.InvoiceFrequency.AnnuallyDD)
            {
                var argcombo6 = cboPaymentType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo6, Conversions.ToInteger(Enums.ContractPaymentType.AnnualDirectDebit).ToString());
            } // AnnDD

            var dd = App.DB.ExecuteWithReturn("Select  SC, AC, InitialPaymentType,FirstAmount,SecondPayment,AccName FROM tblContractP where ContractSiteID = " + CurrentContractSite.ContractSiteID);
            if ((txtMainAppCount.Text ?? "") == "0")
                txtMainAppCount.Text = CurrentContractSite.MainAppliances.ToString();
            if ((txtSecondryCount.Text ?? "") == "0")
                txtSecondryCount.Text = CurrentContractSite.SecondryAppliances.ToString();

            // decrypt
            var wrapper = new Simple3Des(p);

            // DecryptData throws if the wrong password is used.
            if (dd.Rows.Count > 0)
            {
                try
                {
                    ddsort = wrapper.DecryptData(Conversions.ToString(dd.Rows[0]["sc"]));
                    ddAcc = wrapper.DecryptData(Conversions.ToString(dd.Rows[0]["Ac"]));
                }
                catch (CryptographicException ex)
                {
                    Interaction.MsgBox("The Account data could not be decrypted");
                }

                var argcombo7 = cboInitialPaymentType;
                Combo.SetSelectedComboItem_By_Description(ref argcombo7, dd.Rows[0]["InitialPaymentType"].ToString());
                txtSortCode.Text = ddsort;
                txtAccNumber.Text = ddAcc;
                txtAccName.Text = Conversions.ToString(dd.Rows[0]["AccName"]);
                lblFollowedBy.Text = Strings.Format(dd.Rows[0]["SecondPayment"], "C");
            }

            if (CurrentContract.ContractStatusID == (int)Enums.ContractStatus.Cancelled)
            {
                dtpCancelledDate.Value = CurrentContract.CancelledDate;
                dtpCancelledDate.Visible = true;
                cboReasonID.Visible = true;
                var argcombo8 = cboReasonID;
                Combo.SetSelectedComboItem_By_Value(ref argcombo8, CurrentContract.ReasonID.ToString());
            }
            else
            {
                dtpCancelledDate.Visible = false;
                cboReasonID.Visible = false;
            }

            PreviousRef = CurrentContract.ContractReference;
            lblContractRef.Text = CurrentContract.ContractReference;
        }

        public int workingdays(DateTime Startdate, DateTime EndDate)
        {
            int count = 0;
            int totalDays = (EndDate - Startdate).Days;
            var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
            for (int i = 0, loopTo = totalDays; i <= loopTo; i++)
            {
                var weekday = Startdate.AddDays(i).DayOfWeek;
                if (dvBankHolidays.Table.Select("BankHolidayDate='" + Conversions.ToDate(Strings.Format(Startdate.AddDays(i), "dd/MM/yyyy")) + "'").Length > 0)
                {
                }
                else if (weekday != DayOfWeek.Saturday && weekday != DayOfWeek.Sunday)
                {
                    count += 1;
                }
            }

            return count;
        }

        public DateTime ProcessingDateSub()
        {
            DateTime dateout;
            var contractStart = CurrentContract.ContractStartDate;
            if (workingdays(DateAndTime.Today.AddDays(1), new DateTime(DateAndTime.Year(contractStart), DateAndTime.Month(contractStart), contractStart.Day)) < 11)
            {
                dateout = new DateTime(DateAndTime.Today.Year, DateAndTime.Today.Month, 1).AddMonths(2);
            }
            else
            {
                dateout = new DateTime(contractStart.Year, contractStart.Month, 1).AddMonths(1);
            }

            var dvBankHolidays = App.DB.TimeSlotRates.BankHolidays_GetAll();
            int c = 0;
            int i = 0;
            while (i < 11)
            {
                var weekday = dateout.AddDays(-c).DayOfWeek;
                if (dvBankHolidays.Table.Select("BankHolidayDate='" + Conversions.ToDate(Strings.Format(dateout.AddDays(-c), "dd/MM/yyyy")) + "'").Length > 0)
                {
                }
                else if (weekday != DayOfWeek.Saturday && weekday != DayOfWeek.Sunday)
                {
                    i = i + 1;
                }

                c = c - 1;
            }

            return dateout.AddDays(c);
        }

        public void SetContract()
        {
            try
            {
                int paymentType = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPaymentType));
                CurrentContract.SetContractReference = lblContractRef.Text;
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboReasonID)) > 0)
                {
                    CurrentContract.SetContractStatusID = Conversions.ToInteger(Enums.ContractStatus.Cancelled);
                }
                else
                {
                    CurrentContract.SetContractStatusID = Conversions.ToInteger(Enums.ContractStatus.Active);
                }

                var VAT = App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(CurrentContract.ContractStartDate));
                CurrentContract.SetContractPrice = Price / (1 + VAT.VATRate / 100);
                CurrentContract.SetContractPriceAfterVAT = Price;
                CurrentContract.FirstInvoiceDate = CurrentContract.ContractStartDate;
                switch (paymentType)
                {
                    case (int)Enums.ContractPaymentType.Annual:
                        {
                            CurrentContract.SetDirectDebit = false;
                            CurrentContract.SetAnnual = true;
                            CurrentContract.SetInvoiceFrequencyID = Conversions.ToInteger(Enums.InvoiceFrequency.Annually);
                            break;
                        }

                    case (int)Enums.ContractPaymentType.AnnualDirectDebit:
                        {
                            CurrentContract.SetDirectDebit = true;
                            CurrentContract.SetAnnual = true;
                            CurrentContract.SetInvoiceFrequencyID = Conversions.ToInteger(Enums.InvoiceFrequency.AnnuallyDD);
                            break;
                        }

                    default:
                        {
                            CurrentContract.SetDirectDebit = true;
                            CurrentContract.SetAnnual = false;
                            CurrentContract.SetInvoiceFrequencyID = Conversions.ToInteger(Enums.InvoiceFrequency.Monthly);
                            break;
                        }
                }

                CurrentContract.SetContractTypeID = Combo.get_GetSelectedItemValue(cboContractType);
                CurrentContract.SetDiscountID = Combo.get_GetSelectedItemValue(cboPromotion);
                CurrentContract.SetBankName = txtBankName.Text;
                CurrentContract.SetPoNumber = txtPONumber.Text;
                CurrentContract.SetGasSupplyPipework = chkGasSupplyPipework.Checked;
                CurrentContract.SetPlumbingDrainage = chkPlumbingDrainage.Checked;
                CurrentContract.SetWindowLockPest = chkWindowLockPest.Checked;
                if ((Combo.get_GetSelectedItemValue(cboPAyer) ?? "") != "0")
                {
                    CurrentContract.SetInvoiceAddressID = Combo.get_GetSelectedItemValue(cboPAyer).Split('`')[0];
                    CurrentContract.SetInvoiceAddressTypeID = Combo.get_GetSelectedItemValue(cboPAyer).Split('`')[1];
                }

                CurrentContract.SetCustomerID = IDToLinkTo;
                var cV = new Entity.ContractsOriginal.ContractOriginalValidator();
                cV.Validate(CurrentContract);
            }
            catch (Exception ex)
            {
            }
        }

        public void SetContractSite()
        {
            try
            {
                CurrentContractSite.IgnoreExceptionsOnSetMethods = true;
                CurrentContractSite.SetPropertyID = SiteID;
                CurrentContractSite.SetContractID = CurrentContract.ContractID;
                CurrentContractSite.SetPricePerVisit = 25;
                NextVisit();   // '''''  get the next visit
                CurrentContractSite.FirstVisitDate = newdate;
                CurrentContractSite.SetVisitFrequencyID = 7; // Annually
                CurrentContractSite.SetVisitDuration = Conversions.ToDouble(CBT(txtMainAppCount.Text)) * 50 + Conversions.ToDouble(CBT(txtSecondryCount.Text)) * 30;
                CurrentContractSite.SetAverageMileage = 0; // :removed at Robs request
                CurrentContractSite.SetIncludeAssetPrice = false;
                CurrentContractSite.SetIncludeMileagePrice = false;
                CurrentContractSite.SetTotalSitePrice = 100;
                CurrentContractSite.SetPricePerMile = 0; // :removed at Robs request
                CurrentContractSite.SetIncludeRates = true;
                CurrentContractSite.SetLLCertReqd = chkLandlord.Checked;
                CurrentContractSite.SetAdditionalNotes = txtNotesToEngineer.Text;
                CurrentContractSite.SetCommercial = chkCommercial.Checked;
                CurrentContractSite.SetMainAppliances = CBT(txtMainAppCount.Text);
                CurrentContractSite.SetSecondryAppliances = CBT(txtSecondryCount.Text);
                var cVo = new Entity.ContractOriginalSites.ContractOriginalSiteValidator();
                cVo.Validate(CurrentContractSite, CurrentContract);
            }
            catch (Exception ex)
            {
            }
        }

        public void SetContractSiteAsset()
        {
            try
            {
                // DELETE AND RE INSERT ASSET
                App.DB.ContractOriginalSiteAsset.Delete(CurrentContractSite.ContractSiteID);
                foreach (DataRow drAsset in MainDataView.Table.Rows)
                {
                    var ContractSiteAsset = new Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset();
                    ContractSiteAsset.SetAssetID = drAsset["AssetID"];
                    ContractSiteAsset.SetContractSiteID = CurrentContractSite.ContractSiteID;
                    ContractSiteAsset.SetPricePerVisit = 25;
                    ContractSiteAsset.SetType = drAsset["Product"].ToString().Split('-')[0].Trim(' ');
                    ContractSiteAsset.SetPrimaryAsset = true;
                    ContractSiteAsset.SetProduct = drAsset["Product"];
                    ContractSiteAsset = App.DB.ContractOriginalSiteAsset.Insert(ContractSiteAsset);
                }

                foreach (DataRow drAsset2 in SecondAppliances.Table.Rows)
                {
                    var ContractSiteAsset = new Entity.ContractOriginalSiteAssets.ContractOriginalSiteAsset();
                    ContractSiteAsset.SetAssetID = drAsset2["AssetID"];
                    ContractSiteAsset.SetContractSiteID = CurrentContractSite.ContractSiteID;
                    ContractSiteAsset.SetPricePerVisit = 25;
                    ContractSiteAsset.SetPrimaryAsset = false;
                    ContractSiteAsset.SetType = drAsset2["Product"].ToString().Split('-')[0].Trim(' ');
                    ContractSiteAsset.SetProduct = drAsset2["Product"];
                    ContractSiteAsset = App.DB.ContractOriginalSiteAsset.Insert(ContractSiteAsset);
                }

                if (Conversions.ToDouble(CBT(txtMainAppCount.Text)) > 0)
                {
                    var contractSOR = new Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates();
                    contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID;
                    contractSOR.SetQty = CBT(txtMainAppCount.Text);
                    contractSOR.SetRateID = 244;
                    App.DB.ContractOriginalSiteRates.Insert(contractSOR);
                }

                if (Conversions.ToDouble(CBT(txtSecondryCount.Text)) > 0)
                {
                    var contractSOR = new Entity.ContractOriginalSiteRatess.ContractOriginalSiteRates();
                    contractSOR.SetContractSiteID = CurrentContractSite.ContractSiteID;
                    contractSOR.SetQty = CBT(txtSecondryCount.Text);
                    contractSOR.SetRateID = 245;
                    App.DB.ContractOriginalSiteRates.Insert(contractSOR);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public bool Save()
        {
            if (Conversions.ToDouble(CBT(txtMainAppCount.Text)) > 0 | Conversions.ToDouble(CBT(txtSecondryCount.Text)) > 0)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    CurrentContract.IgnoreExceptionsOnSetMethods = true;
                    if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)) == 0)
                    {
                        App.ShowMessage("Period missing! Please correct!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    int installments = (int)(12 * Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)));
                    Price = Conversions.ToDouble(lblTotalEst.Text);
                    double fMonthlyEst = 0; // first monthly payment
                    double sMonthlyEst = 0; // second monthly payment
                    int paymentType = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPaymentType));
                    var wrapper = new Simple3Des(p);
                    string cipherSort = wrapper.EncryptData(txtSortCode.Text.Replace("-", ""));
                    var wrapper2 = new Simple3Des(p);
                    string cipherAccount = wrapper.EncryptData(txtAccNumber.Text);
                    if ((b.Text ?? "") == "Create Contract")  // new contract
                    {

                        /* TODO ERROR: Skipped RegionDirectiveTrivia */
                        if (App.ShowMessage("Are you sure you want to save?" + Constants.vbCrLf + "Information cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return default;
                        }

                        CurrentContract.ContractStartDate = dtpContractStartDate.Value;
                        CurrentContract.ContractEndDate = dtpContractStartDate.Value.AddYears(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPeriod))).AddDays(-1);
                        SetContract();
                        CurrentContract = App.DB.ContractOriginal.Insert(CurrentContract);
                        NumberUsed = true;
                        InsertInvoiceToBeRaiseLines();
                        SetContractSite();
                        CurrentContractSite = App.DB.ContractOriginalSite.Insert(CurrentContractSite);   // insert site contract
                        switch (paymentType)
                        {
                            case (int)Enums.ContractPaymentType.Annual:
                            case (int)Enums.ContractPaymentType.AnnualDirectDebit:
                                {
                                    fMonthlyEst = Helper.MakeDoubleValid(lblTotalEst.Text);
                                    installments = 0;
                                    break;
                                }

                            default:
                                {
                                    fMonthlyEst = Helper.MakeDoubleValid(lblMonthlyEst.Text);
                                    sMonthlyEst = Helper.MakeDoubleValid(lblFollowedBy.Text);
                                    installments -= 1;
                                    break;
                                }
                        }

                        App.DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp) VALUES (" + CurrentContractSite.ContractSiteID + ",'" + cipherSort + "','" + cipherAccount + "',17," + fMonthlyEst + ",'" + Strings.Format(ProcessingDateSub(), "yyyy-MM-dd") + "',0," + sMonthlyEst + " ," + installments + ",'" + Combo.get_GetSelectedItemDescription(cboInitialPaymentType) + "','" + txtAccName.Text.Replace("'", "") + "'," + Conversions.ToInteger(cboSoldBy.SelectedValue) + ",'NEW','" + ManualApp + "')");
                        SetContractSiteAsset();

                        // START SCHEDULING JOBS************************
                        ScheduleJob();
                        // **************************
                        NumberUsed = true;
                        StateChanged?.Invoke(CurrentContract.ContractID);
                        b.Enabled = false;
                        App.ShowMessage("Contract " + lblContractRef.Text + " has been created.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    else if ((b.Text ?? "") == "Amend Contract") // amending old
                    {

                        /* TODO ERROR: Skipped RegionDirectiveTrivia */
                        if (App.ShowMessage("Are you sure you want to save?" + Constants.vbCrLf + "Information cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return default;
                        }

                        bool hasContractChanged = false;
                        int contractTypeId = Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboContractType));

                        // check if user has changed the contract type if so ...
                        if (CurrentContract.ContractTypeID != contractTypeId)
                        {
                            // distingush if contract is being upgraded or downgraded
                            switch (contractTypeId)
                            {
                                case (int)Enums.ContractTypes.SilverStar:
                                    {
                                        hasContractChanged = ChangeContract(false, contractTypeId);
                                        break;
                                    }

                                case (int)Enums.ContractTypes.GoldStar:
                                    {
                                        hasContractChanged = ChangeContract(CurrentContract.ContractTypeID > Conversions.ToInteger(Enums.ContractTypes.GoldStar), contractTypeId);
                                        break;
                                    }

                                case (int)Enums.ContractTypes.PlatinumStar:
                                    {
                                        hasContractChanged = ChangeContract(CurrentContract.ContractTypeID > Conversions.ToInteger(Enums.ContractTypes.PlatinumStar), contractTypeId);
                                        break;
                                    }

                                case (int)Enums.ContractTypes.PlatinumImmediate:
                                    {
                                        hasContractChanged = ChangeContract(true, contractTypeId);
                                        break;
                                    }

                                case (int)Enums.ContractTypes.TotallyAssured:
                                    {
                                        hasContractChanged = ChangeContract(CurrentContract.ContractTypeID != Conversions.ToInteger(Enums.ContractTypes.PlatinumImmediate), contractTypeId);
                                        break;
                                    }
                            }
                        }

                        var ContractsDT = App.DB.ContractOriginal.Get_NotProcessed(CurrentContract.ContractID).Table;
                        if (ContractsDT.Rows.Count > 0 && Conversions.ToBoolean(ContractsDT.Rows[0]["InvoiceToBeRaisedID"] > 0))
                            installments -= 1;
                        string type = "AMEND";
                        if ((txtAccNumber.Text ?? "") != (ddAcc ?? "") | hasContractChanged & contractTypeId == (int)Enums.ContractTypes.TotallyAssured)
                        {
                            type = "AMENDD";
                            CurrentContract.FirstInvoiceDate = DateAndTime.Today;
                        }
                        else
                        {
                            CurrentContract.FirstInvoiceDate = new DateTime(DateAndTime.Today.Year, DateAndTime.Today.Month, 1).AddMonths(1);
                            Offset = false;
                        }

                        int invoicecount = 0;
                        if (CurrentContract.InvoiceFrequencyID == (int)Enums.InvoiceFrequency.Monthly | CurrentContract.InvoiceFrequencyID == (int)Enums.InvoiceFrequency.AnnuallyDD)
                        {
                            // delete the old invoices
                            App.DB.ExecuteScalar("DELETE FROM tblInvoiceToBeRaised WHERE InvoiceToBeRaisedID IN ( " + "Select tblInvoiceToBeRaised.InvoiceToBeRaisedID FROM tblInvoiceToBeRaised " + " LEFT JOIN tblInvoicedLines ON tblInvoicedLines.InvoiceToBeRaisedID = tblInvoiceToBeRaised.InvoiceToBeRaisedID WHERE tblInvoicedLines.InvoicedLineID is null AND LinkID = " + CurrentContract.ContractID + " AND InvoiceTypeID = 327 and tblInvoiceToBeRaised.RaiseDate > GETDATE())");
                            // insert some new ones.
                            EffDate = DateAndTime.Today;
                            if (!(hasContractChanged && contractTypeId == (int)Enums.ContractTypes.TotallyAssured))
                            {
                                invoicecount = InsertInvoiceToBeRaiseLines(true, hasContractChanged);
                            }
                        }

                        var VAT = App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(CurrentContract.ContractStartDate));
                        if (hasContractChanged)
                        {
                            CurrentContract.SetDDMSRef = PreviousRef;
                        }

                        SetContract();
                        SetContractSiteAsset();
                        SetContractSite();
                        if (CurrentContract.Exists)
                        {
                            if (hasContractChanged)
                            {
                                var cV = new Entity.ContractsOriginal.ContractOriginalValidator();
                                cV.Validate(CurrentContract);
                                App.DB.ContractOriginal.Insert(CurrentContract);
                                CurrentContractSite.SetContractID = CurrentContract.ContractID;
                                App.DB.ContractOriginalSite.Insert(CurrentContractSite);
                                SetContractSiteAsset();
                                invoicecount = InsertInvoiceToBeRaiseLines(true, hasContractChanged);
                                App.DB.ContractOriginal.Insert_UpgradedFrom(CurrentContract.ContractID, PreviousRef);
                            }
                            else
                            {
                                CurrentContract.SetReasonID = Combo.get_GetSelectedItemValue(cboReasonID);
                                CurrentContract.CancelledDate = dtpCancelledDate.Value;
                                var cV = new Entity.ContractsOriginal.ContractOriginalValidator();
                                cV.Validate(CurrentContract);
                                App.DB.ContractOriginal.Update(CurrentContract);
                                App.DB.ContractOriginalSite.Update(CurrentContractSite);
                            }

                            NumberUsed = true;
                        }
                        else
                        {
                            CurrentContract.SetCustomerID = IDToLinkTo;
                            var cV = new Entity.ContractsOriginal.ContractOriginalValidator();
                            cV.Validate(CurrentContract);
                            CurrentContract = App.DB.ContractOriginal.Insert(CurrentContract);
                            NumberUsed = true;
                        }

                        switch (paymentType)
                        {
                            case (int)Enums.ContractPaymentType.Annual:
                            case (int)Enums.ContractPaymentType.AnnualDirectDebit:
                                {
                                    fMonthlyEst = Helper.MakeDoubleValid(lblTotalEst.Text);
                                    installments = 0;
                                    break;
                                }

                            default:
                                {
                                    fMonthlyEst = Helper.MakeDoubleValid(lblMonthlyEst.Text);
                                    sMonthlyEst = Helper.MakeDoubleValid(lblFollowedBy.Text);
                                    if (hasContractChanged & CurrentContract.ContractTypeID == (int)Enums.ContractTypes.TotallyAssured)
                                    {
                                        installments = 1;
                                    }

                                    break;
                                }
                        }

                        int c = Conversions.ToInteger(App.DB.ExecuteScalar("Select Count(*) from tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " + CurrentContractSite.ContractSiteID));
                        if (c > 0)
                        {
                            App.DB.ExecuteScalar("Delete from tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " + CurrentContractSite.ContractSiteID);
                            if ((type ?? "") == "AMEND")
                            {
                                type = "NEW";
                            }

                            App.DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp,SecondApp) VALUES (" + CurrentContractSite.ContractSiteID + ",'" + cipherSort + "','" + cipherAccount + "',17," + fMonthlyEst + ",'" + Strings.Format(ProcessingDateSub(), "yyyy-MM-dd") + "',0," + sMonthlyEst + " ," + installments + ",'" + Combo.get_GetSelectedItemDescription(cboInitialPaymentType) + "','" + txtAccName.Text + "'," + App.loggedInUser.UserID + ",'" + type + "','" + ManualApp + "','" + SecondApp + "')");
                        }
                        else if ((type ?? "") == "AMENDD")
                        {
                            App.DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type,ManualApp,SecondApp) VALUES (" + CurrentContractSite.ContractSiteID + ",'" + cipherSort + "','" + cipherAccount + "',17," + sMonthlyEst + ",'" + Strings.Format(ProcessingDateSub(), "yyyy-MM-dd") + "',0," + sMonthlyEst + " ," + invoicecount + ",'" + Combo.get_GetSelectedItemDescription(cboInitialPaymentType) + "','" + txtAccName.Text + "'," + App.loggedInUser.UserID + ",'" + type + "','" + ManualApp + "','" + SecondApp + "')");
                            var FeedbackEmail = new Emails();
                            FeedbackEmail.From = EmailAddress.FSM;
                            FeedbackEmail.To = EmailAddress.Coverplan;
                            FeedbackEmail.Subject = "A DDMS Record Requires Manually Changing";
                            string ddmsref = "";
                            if (CurrentContract.DDMSRef.Length > 0)
                                ddmsref = CurrentContract.DDMSRef;
                            else
                                ddmsref = CurrentContract.ContractReference;
                            FeedbackEmail.Body = "Please amend record " + ddmsref + ", a new direct debit instruction will be added to DDMS tonight But the existing dd instructions should be removed or cancelled.";
                            FeedbackEmail.SendMe = true;
                            FeedbackEmail.Send();
                        }
                        else if ((type ?? "") == "AMEND")
                        {
                            var contractPDataTable = App.DB.ExecuteWithReturn("SELECT DirectDebitID, ManualApp, SecondApp, FirstAmount, SecondPayment, Installments FROM tblContractP WHERE ContractSiteID = " + CurrentContractSite.ContractSiteID);
                            foreach (DataRow row in contractPDataTable.Rows)
                            {
                                if (!string.IsNullOrEmpty(ManualApp) && (Helper.MakeStringValid(row["ManualApp"]) ?? "") != (ManualApp ?? ""))
                                {
                                    App.DB.ExecuteScalar(Conversions.ToString("UPDATE tblContractP SET ManualApp = '" + ManualApp + "' WHERE DirectDebitID = " + row["DirectDebitID"]));
                                }

                                if (!string.IsNullOrEmpty(SecondApp) && (Helper.MakeStringValid(row["SecondApp"]) ?? "") != (SecondApp ?? ""))
                                {
                                    App.DB.ExecuteScalar(Conversions.ToString("UPDATE tblContractP SET SecondApp = '" + SecondApp + "' WHERE DirectDebitID = " + row["DirectDebitID"]));
                                }

                                if (Helper.MakeDoubleValid(row["FirstAmount"]) != fMonthlyEst | Helper.MakeDoubleValid(row["FirstAmount"]) != sMonthlyEst)
                                {
                                    App.DB.ExecuteScalar(Conversions.ToString("UPDATE tblContractP SET FirstAmount = " + fMonthlyEst + " WHERE DirectDebitID = " + row["DirectDebitID"]));
                                }

                                if (Helper.MakeDoubleValid(row["SecondPayment"]) != sMonthlyEst)
                                {
                                    App.DB.ExecuteScalar(Conversions.ToString("UPDATE tblContractP SET SecondPayment = " + sMonthlyEst + " WHERE DirectDebitID = " + row["DirectDebitID"]));
                                }

                                if (Helper.MakeIntegerValid(row["Installments"]) != invoicecount)
                                {
                                    App.DB.ExecuteScalar(Conversions.ToString("UPDATE tblContractP SET Installments = " + invoicecount + " WHERE DirectDebitID = " + row["DirectDebitID"]));
                                }
                            }
                        }

                        NumberUsed = true;
                        StateChanged?.Invoke(CurrentContract.ContractID);
                        b.Enabled = false;
                        App.ShowMessage("Contract " + lblContractRef.Text + " has been Amended.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (hasContractChanged && CurrentContract.ContractTypeID == (int)Enums.ContractTypes.TotallyAssured)
                        {
                            ScheduleJob();
                        }

                        return true;
                    }

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    else if ((b.Text ?? "") == "Transfer Contract")
                    {

                        /* TODO ERROR: Skipped RegionDirectiveTrivia */
                        if (App.ShowMessage("Are you sure you want to save?" + Constants.vbCrLf + "Information cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return default;
                        }

                        SetContract();
                        CurrentContractSite.SetPropertyID = NewSiteID;
                        if (NewPayer.Length > 1)
                        {
                            OldEndDate = CurrentContract.ContractEndDate;
                            CurrentContract.ContractEndDate = EffDate.AddDays(-1);
                            CurrentContract.SetReasonID = Conversions.ToInteger(Enums.ContractInactiveReason.Transferred);
                            App.DB.ContractOriginal.Update(CurrentContract); // update old contract
                            CurrentContract.SetInvoiceAddressID = NewPayer.Split('`')[0];  // build new contract
                            CurrentContract.SetInvoiceAddressTypeID = NewPayer.Split('`')[1];
                        }
                        else
                        {
                            return default;
                        }

                        CurrentContract.SetReasonID = 0;
                        CurrentContract.ContractEndDate = OldEndDate;
                        if (EffDate > OldEndDate)
                            return default;
                        if (EffDate < CurrentContract.ContractStartDate)
                        {
                        }
                        else
                        {
                            CurrentContract.ContractStartDate = EffDate;
                        }

                        CurrentContract.SetPreviousInvoiceFrequencyID = CurrentContract.InvoiceFrequencyID;
                        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboReasonID)) > 0)
                        {
                            CurrentContract.SetContractStatusID = Conversions.ToInteger(Enums.ContractStatus.Cancelled);
                        }
                        else
                        {
                            CurrentContract.SetContractStatusID = Conversions.ToInteger(Enums.ContractStatus.Active);
                        }

                        var VAT = App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(CurrentContract.ContractStartDate));
                        CurrentContract.SetContractPrice = Price / (1 + VAT.VATRate / 100);
                        CurrentContract.SetContractPriceAfterVAT = Price;
                        var cV = new Entity.ContractsOriginal.ContractOriginalValidator();
                        newdate = Conversions.ToDate(App.DB.ContractOriginal.Transfer(CurrentContract.ContractID, CurrentContractSite.ContractSiteID, EffDate)); // before its replaced with new contract
                        int oldcontractid = CurrentContract.ContractID;  // part 1
                        CurrentContract = App.DB.ContractOriginal.Insert(CurrentContract);
                        NumberUsed = true;

                        // Add the New reference to the old contract ' part 2
                        App.DB.ExecuteScalar("UPDATE tblContractOriginal SET MigratedToContractID = " + CurrentContract.ContractID + " WHERE ContractID = " + oldcontractid);

                        // ' Important dont miss this :)
                        CurrentContractSite.SetContractID = CurrentContract.ContractID;
                        if (newdate == DateTime.MinValue)
                        {
                        }
                        else
                        {
                            CurrentContractSite.FirstVisitDate = newdate;
                        }

                        // delete incomplete invoices
                        string type = "TRANS";
                        if ((txtAccNumber.Text ?? "") != (ddAcc ?? ""))
                        {
                            type = "TRANSD";
                            CurrentContract.FirstInvoiceDate = EffDate;
                        }
                        else
                        {
                            CurrentContract.FirstInvoiceDate = new DateTime(CurrentContract.ContractStartDate.Year, CurrentContract.ContractStartDate.Month, 1).AddMonths(1);
                            Offset = false;
                        } // dont jump the next month

                        if (CurrentContract.InvoiceFrequencyID == (int)Enums.InvoiceFrequency.Monthly | CurrentContract.InvoiceFrequencyID == (int)Enums.InvoiceFrequency.AnnuallyDD)
                        {
                            InsertInvoiceToBeRaiseLines(true);
                        }

                        CurrentContractSite.IgnoreExceptionsOnSetMethods = true;
                        CurrentContractSite.SetLLCertReqd = chkLandlord.Checked;
                        CurrentContractSite.SetAdditionalNotes = txtNotesToEngineer.Text;
                        CurrentContractSite.SetCommercial = chkCommercial.Checked;
                        var cVo = new Entity.ContractOriginalSites.ContractOriginalSiteValidator();
                        App.DB.ExecuteScalar("DELETE tblcontractp where Processed = 0 AND Installments > 0 AND contractsiteID = " + CurrentContractSite.ContractSiteID + "");
                        switch (paymentType)
                        {
                            case (int)Enums.ContractPaymentType.Annual:
                            case (int)Enums.ContractPaymentType.AnnualDirectDebit:
                                {
                                    fMonthlyEst = Helper.MakeDoubleValid(lblTotalEst.Text);
                                    break;
                                }

                            default:
                                {
                                    fMonthlyEst = Helper.MakeDoubleValid(lblMonthlyEst.Text);
                                    sMonthlyEst = Helper.MakeDoubleValid(lblFollowedBy.Text);
                                    break;
                                }
                        }

                        CurrentContractSite = App.DB.ContractOriginalSite.Insert(CurrentContractSite);   // insert site contract
                        if ((type ?? "") == "TRANSD")
                        {
                            App.DB.ExecuteScalar("INSERT INTO tblContractP (ContractSiteID,Sc,Ac,TransactionType,FirstAmount,DDProcessingDate,Processed,SecondPayment,Installments,InitialPaymentType,AccName,UserID,Type) VALUES (" + CurrentContractSite.ContractSiteID + ",'" + cipherSort + "','" + cipherAccount + "',17," + fMonthlyEst + ",'" + Strings.Format(ProcessingDateSub(), "yyyy-MM-dd") + "',0," + sMonthlyEst + " ," + installments + ",'" + Combo.get_GetSelectedItemDescription(cboInitialPaymentType) + "','" + txtAccName.Text + "'," + App.loggedInUser.UserID + ",'" + type + "')");
                        }

                        if (newdate == DateTime.MinValue)
                        {
                        }
                        else
                        {
                            ScheduleJob();
                        }
                        // **************************
                        NumberUsed = true;

                        // DB.ContractManager.ContractRenewalsInsert(oldContract,
                        // CurrentContract.ContractID, CInt(Enums.QuoteType.Contract_Opt_1))
                        StateChanged?.Invoke(CurrentContract.ContractID);
                        b.Enabled = false;
                        App.ShowMessage("Contract " + lblContractRef.Text + " has been Transfered.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    else if ((b.Text ?? "") == "Renew Contract")
                    {

                        /* TODO ERROR: Skipped RegionDirectiveTrivia */
                        // INSERT
                        if (App.ShowMessage("Are you sure you want to save?" + Constants.vbCrLf + "Information cannot be altered after save and jobs will be created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return default;
                        }

                        SetContract();
                        string oldContract = CurrentContract.ContractID.ToString();
                        CurrentContract.SetContractReference = lblContractRef.Text;
                        CurrentContract.ContractStartDate = CurrentContract.ContractEndDate.AddDays(1);
                        CurrentContract.ContractEndDate = CurrentContract.ContractStartDate.AddYears(Conversions.ToInteger(Combo.get_GetSelectedItemValue(cboPeriod))).AddDays(-1);
                        CurrentContract.SetDiscountID = Combo.get_GetSelectedItemValue(cboPromotion);
                        CurrentContract.SetPreviousInvoiceFrequencyID = CurrentContract.InvoiceFrequencyID;
                        if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboReasonID)) > 0)
                        {
                            CurrentContract.SetContractStatusID = Conversions.ToInteger(Enums.ContractStatus.Cancelled);
                        }
                        else
                        {
                            CurrentContract.SetContractStatusID = Conversions.ToInteger(Enums.ContractStatus.Active);
                        }

                        var VAT = App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(CurrentContract.ContractStartDate));
                        CurrentContract.SetContractPrice = Price / (1 + VAT.VATRate / 100);
                        CurrentContract.SetContractPriceAfterVAT = Price;
                        string type = "RENEWAL";
                        if ((txtAccNumber.Text ?? "") != (ddAcc ?? ""))
                        {
                            type = "RENEWALD";
                            CurrentContract.FirstInvoiceDate = CurrentContract.ContractStartDate;
                        }
                        else if (paymentType == (int)Enums.ContractPaymentType.Annual) // ANNUAL
                        {
                            CurrentContract.FirstInvoiceDate = CurrentContract.ContractStartDate;
                        }
                        else // Standard Renewal Monthly no change
                        {
                            Offset = false;
                            CurrentContract.FirstInvoiceDate = new DateTime(CurrentContract.ContractStartDate.Year, CurrentContract.ContractStartDate.Month, 1); // .AddMonths(1)
                            Offset = false;
                        } // dont jump the next month

                        CurrentContract.SetCustomerID = IDToLinkTo;
                        CurrentContract = App.DB.ContractOriginal.Insert(CurrentContract);
                        NumberUsed = true;
                        InsertInvoiceToBeRaiseLines();
                        SetContractSite();
                        CurrentContractSite.FirstVisitDate = newdate;
                        CurrentContractSite = App.DB.ContractOriginalSite.Insert(CurrentContractSite);   // insert site contract
                        string ip = "";
                        if (paymentType == (int)Enums.ContractPaymentType.Annual)
                        {
                            ip = Combo.get_GetSelectedItemDescription(cboInitialPaymentType);
                        }
                        else
                        {
                            ip = "RENEWAL";
                        }

                        switch (paymentType)
                        {
                            case (int)Enums.ContractPaymentType.Annual:
                            case (int)Enums.ContractPaymentType.AnnualDirectDebit:
                                {
                                    fMonthlyEst = Helper.MakeDoubleValid(lblTotalEst.Text);
                                    installments = 0;
                                    break;
                                }

                            default:
                                {
                                    fMonthlyEst = Helper.MakeDoubleValid(lblMonthlyEst.Text);
                                    sMonthlyEst = Helper.MakeDoubleValid(lblFollowedBy.Text);
                                    break;
                                }
                        }

                        App.DB.ExecuteScalar("INSERT INTO tblContractP(ContractSiteID, Sc, Ac, TransactionType, FirstAmount, DDProcessingDate, Processed, SecondPayment, Installments, InitialPaymentType, AccName, UserID, Type) VALUES (" + CurrentContractSite.ContractSiteID + ",'" + cipherSort + "','" + cipherAccount + "', 17," + fMonthlyEst + ",'" + Strings.Format(ProcessingDateSub(), "yyyy-MM-dd") + "',0," + sMonthlyEst + " ," + installments + ",'" + ip + "','" + txtAccName.Text + "'," + App.loggedInUser.UserID + ",'" + type + "')");
                        SetContractSiteAsset();

                        // START SCHEDULING JOBS************************
                        ScheduleJob();
                        // **************************
                        NumberUsed = true;
                        App.DB.ContractManager.ContractRenewalsInsert(Conversions.ToInteger(oldContract), CurrentContract.ContractID, Conversions.ToInteger(Enums.QuoteType.Contract_Opt_1));
                        StateChanged?.Invoke(CurrentContract.ContractID);
                        b.Enabled = false;
                        App.ShowMessage("Contract " + lblContractRef.Text + " has been Renewed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;

                        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    }
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

            return default;
        }

        public bool ChangeContract(bool upgrade, int contractypeId)
        {
            string currentContractName = App.DB.Picklists.Get_One_As_Object(CurrentContract.ContractTypeID).Name;
            string newContractName = App.DB.Picklists.Get_One_As_Object(contractypeId).Name;
            string text = "";

            // Determnine which text to use
            if (upgrade)
            {
                text = "Upgrade";
            }
            else
            {
                text = "Downgrade";
            }

            // Check with user
            if (App.ShowMessage(text + " contract, Contract - " + CurrentContract.ContractReference + " will be " + text.ToLower() + "d from " + currentContractName + " to " + newContractName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
            {
                return false;
            }

            // Get effective date and give user second chance to change their mind
            var f = new FRMContractUpgradeDowngrade();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                EffDate = f.EffDate;
            }
            else
            {
                return false;
            }

            // check if contract has started

            if (EffDate.Date > CurrentContract.ContractStartDate.Date)
            {
                OldEndDate = CurrentContract.ContractEndDate;
                CurrentContract.ContractEndDate = EffDate.AddDays(-1);

                // Set the reason for the contract change
                if (upgrade)
                {
                    CurrentContract.SetReasonID = Conversions.ToInteger(Enums.ContractInactiveReason.Upgraded);
                }
                else
                {
                    CurrentContract.SetReasonID = Conversions.ToInteger(Enums.ContractInactiveReason.Downgraded);
                }

                CurrentContract.SetDoNotRenew = true;

                // Validate and update old contract
                var cV = new Entity.ContractsOriginal.ContractOriginalValidator();
                cV.Validate(CurrentContract);
                App.DB.ContractOriginal.Update(CurrentContract);
                CurrentContract.SetDoNotRenew = false;
                // Set contract start and end date for new contract
                // End date should be from previous contract and start from date of effect

                CurrentContract.ContractStartDate = EffDate;
                if (contractypeId == (int)Enums.ContractTypes.TotallyAssured)
                {
                    CurrentContract.ContractEndDate = EffDate.AddYears(1).AddDays(-1);
                    CurrentContract.FirstInvoiceDate = DateAndTime.Today;
                }
                else
                {
                    CurrentContract.ContractEndDate = OldEndDate;
                }

                return true;
            }
            else
            {
                throw new Exception("Effective date less than contract start date");
            }

            return false;
        }

        private void NextVisit()
        {
            var RandomClass = new Random();
            var d = App.DB.ExecuteScalar("select MAX(Startdatetime) from tblEngineerVisit ev inner join tblJobOfWork jow on jow.JobOfWorkID = ev.JobOfWorkID inner join tblJob j on j.JobID = jow.JobID where j.JobTypeID in (4702,519) and OutcomeEnumID in (1) and SiteID = " + SiteID);
            DateTime enddate;
            if (DateAndTime.DateDiff(DateInterval.Day, CurrentContract.ContractStartDate, CurrentContract.ContractEndDate) > 366)
            {
                enddate = CurrentContract.ContractStartDate.AddYears(1);
            }
            else
            {
                enddate = CurrentContract.ContractEndDate;
            }

            if (Information.IsDBNull(d))
            {
                d = new DateTime(DateAndTime.Today.AddYears(-1).Year, 6, 15);
                if (Conversions.ToBoolean(d.AddYears(1) < CurrentContract.ContractStartDate))
                {
                    if (CurrentContract.ContractStartDate.DayOfYear < 91) // does contract end in the excluded months
                    {
                        newdate = new DateTime(CurrentContract.ContractStartDate.Year, 1, 1).AddDays(91 + RandomClass.Next(0, 30));
                    }
                    else if (enddate.DayOfYear > 275)
                    {
                        newdate = new DateTime(enddate.Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30));
                    }
                    else
                    {
                        newdate = CurrentContract.ContractStartDate.AddDays(5 + RandomClass.Next(0, 20));
                    }
                }
                else if (Conversions.ToBoolean(d.AddYears(1) > enddate))
                {
                    if (enddate.DayOfYear > 275)
                    {
                        newdate = new DateTime(enddate.Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30));
                    }
                    else
                    {
                        newdate = new DateTime(enddate.Year, 1, 1).AddDays(-RandomClass.Next(0, 10));
                    }
                }
                else if (Conversions.ToBoolean(d.AddYears(1).DayOfYear < 91)) // in march or less
                {
                    newdate = new DateTime(Conversions.ToInteger(d.AddYears(1).Year), 1, 1).AddDays(91 + RandomClass.Next(0, 30));
                    if (newdate > enddate)
                    {
                        newdate = Conversions.ToDate(d.AddYears(1).AddDays(-180));
                    }
                }
                else if (Conversions.ToBoolean(d.AddYears(1).DayOfYear > 275)) // in october or more
                {
                    newdate = new DateTime(Conversions.ToInteger(d.AddYears(1).Year), 1, 1).AddDays(275 - RandomClass.Next(0, 30));
                    if (newdate < CurrentContract.ContractStartDate)
                    {
                        newdate = Conversions.ToDate(d.AddYears(1).AddDays(180));
                    }
                }
                else
                {
                    newdate = Conversions.ToDate(d).AddYears(1);
                }
            }

            if (chkLandlord.Checked == true)
            {
                newdate = Conversions.ToDate(d).AddYears(1);
                if (newdate > enddate)
                {
                    newdate = enddate.AddDays(-3);
                }
                else if (newdate < CurrentContract.ContractStartDate)
                {
                    newdate = CurrentContract.ContractStartDate.AddDays(3);
                }
            }
            else if (Conversions.ToBoolean(d.AddYears(1) < CurrentContract.ContractStartDate))
            {
                if (CurrentContract.ContractStartDate.DayOfYear < 91) // does contract end in the excluded months
                {
                    newdate = new DateTime(CurrentContract.ContractStartDate.Year, 1, 1).AddDays(91 + RandomClass.Next(0, 30));
                }
                else if (enddate.DayOfYear > 275)
                {
                    newdate = new DateTime(enddate.Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30));
                }
                else
                {
                    newdate = CurrentContract.ContractStartDate.AddDays(5 + RandomClass.Next(0, 20));
                }
            }
            else if (Conversions.ToBoolean(d.AddYears(1) > enddate))
            {
                if (enddate.DayOfYear > 275)
                {
                    newdate = new DateTime(enddate.Year, 1, 1).AddDays(275 - RandomClass.Next(0, 30));
                }
                else
                {
                    newdate = new DateTime(enddate.Year, 1, 1).AddDays(-RandomClass.Next(0, 10));
                }
            }
            else if (Conversions.ToBoolean(d.AddYears(1).DayOfYear < 91)) // in march or less
            {
                newdate = new DateTime(Conversions.ToInteger(d.AddYears(1).Year), 1, 1).AddDays(91 + RandomClass.Next(0, 30));
                if (newdate > enddate)
                {
                    newdate = Conversions.ToDate(d.AddYears(1).AddDays(-180));
                }
            }
            else if (Conversions.ToBoolean(d.AddYears(1).DayOfYear > 275)) // in october or more
            {
                newdate = new DateTime(Conversions.ToInteger(d.AddYears(1).Year), 1, 1).AddDays(275 - RandomClass.Next(0, 30));
                if (newdate < CurrentContract.ContractStartDate)
                {
                    newdate = Conversions.ToDate(d.AddYears(1).AddDays(180));
                }
            }
            else
            {
                newdate = Conversions.ToDate(d).AddYears(1).AddDays(-1);
            }

            if (newdate < CurrentContract.ContractStartDate.Date | newdate >= CurrentContract.ContractEndDate.Date)
            {
                newdate = CurrentContract.ContractEndDate.AddMonths(-6);
            }
        }

        private void ScheduleJob()
        {
            try
            {
                // Duration OF Contract In Days
                int contractDuration;
                // contractDuration = CurrentContract.ContractEndDate.Subtract(CurrentContract.ContractStartDate).Days

                // 'New Way
                var startDate = DateHelper.GetDateZeroTime(CurrentContract.ContractStartDate);
                var endDate = DateHelper.GetDateZeroTime(CurrentContract.ContractEndDate.AddDays(1));
                contractDuration = endDate.Subtract(startDate).Days;
                int M = Math.Abs(startDate.Year - endDate.Year);
                int months = M * 12 + Math.Abs(startDate.Month - endDate.Month);
                // months = months * Combo.GetSelectedItemValue(cboPeriod)
                int days = endDate.Subtract(startDate).Days;

                // How Visit Should happen in days ' NOOOOOOO
                int numOfVisits = 0;
                int visitFreqInMonths = 0;
                int visitFreqIndays = 0;
                var switchExpr = (Enums.VisitFrequency)Conversions.ToInteger(CurrentContractSite.VisitFrequencyID);
                switch (switchExpr)
                {
                    case Enums.VisitFrequency.Annually:
                        {
                            visitFreqInMonths = 12;
                            break;
                        }

                    case Enums.VisitFrequency.Bi_Annually:
                        {
                            visitFreqInMonths = 6;
                            break;
                        }

                    case Enums.VisitFrequency.Monthly:
                        {
                            visitFreqInMonths = 1;
                            break;
                        }

                    case Enums.VisitFrequency.Quarterly:
                        {
                            visitFreqInMonths = 3;
                            break;
                        }

                    case Enums.VisitFrequency.GBS_4_Month_Visits:
                        {
                            visitFreqInMonths = 4;
                            break;
                        }

                    case Enums.VisitFrequency.Fortnightly:
                        {
                            visitFreqIndays = 14;
                            break;
                        }
                }

                if (visitFreqIndays == 0)
                {
                    numOfVisits = Conversions.ToInteger(Math.Floor(months / (double)visitFreqInMonths));
                    if (numOfVisits == 0)
                    {
                        numOfVisits = 1;
                    }
                }
                else if (visitFreqIndays > 0)
                {
                    numOfVisits = Conversions.ToInteger(Math.Floor(days / (double)visitFreqIndays));
                    if (numOfVisits == 0)
                    {
                        numOfVisits = 1;
                    }
                }

                if (newdate == default)
                {
                    NextVisit();
                }

                DateTime estVisitDate = Conversions.ToDate(newdate.Date + " 09:00:00");  // TODO
                string jobSummary = string.Empty;
                int rateCount = 0;
                if (Conversions.ToDouble(CBT(txtMainAppCount.Text)) > 0)
                {
                    if (rateCount > 0)
                    {
                        jobSummary += " And ";
                    }

                    if (Conversions.ToDouble(CBT(txtMainAppCount.Text)) > 1)
                    {
                        jobSummary += CBT(txtMainAppCount.Text) + " x " + "Service Primary Coverplan Appliances";
                    }
                    else
                    {
                        jobSummary += "Service Primary Coverplan Appliance";
                    }

                    rateCount += 1;
                }

                if (Conversions.ToDouble(CBT(txtSecondryCount.Text)) > 0)
                {
                    if (rateCount > 0)
                    {
                        jobSummary += " And ";
                    }

                    if (Conversions.ToDouble(CBT(txtSecondryCount.Text)) > 1)
                    {
                        jobSummary += CBT(txtSecondryCount.Text) + " x " + "Service Additional Coverplan Appliances";
                    }
                    else
                    {
                        jobSummary += "Service Additional Coverplan Appliance";
                    }

                    rateCount += 1;
                }

                if (CurrentContractSite.LLCertReqd == true)
                {
                    if (jobSummary.Length > 0)
                    {
                        jobSummary += ". ";
                    }

                    jobSummary += "Landlord Certificate Required";
                }

                if (jobSummary.Length > 0)
                {
                    jobSummary += ". ";
                }

                jobSummary += CurrentContractSite.AdditionalNotes;
                for (int i = 1, loopTo = numOfVisits; i <= loopTo; i++)
                {
                    if (DateHelper.GetDateZeroTime(estVisitDate) >= DateHelper.GetDateZeroTime(CurrentContract.ContractStartDate) & DateHelper.GetDateZeroTime(estVisitDate) <= DateHelper.GetDateZeroTime(CurrentContract.ContractEndDate))
                    {

                        // MAKE SURE WE DON'T BOOK A SATURADY OR SUNDAY
                        if (estVisitDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            estVisitDate = estVisitDate.AddDays(2);
                        }
                        else if (estVisitDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            estVisitDate = estVisitDate.AddDays(1);
                        }

                        // CREATE JOB
                        var job = new Entity.Jobs.Job();
                        job.SetPropertyID = CurrentContractSite.PropertyID;
                        job.SetJobDefinitionEnumID = Conversions.ToInteger(Enums.JobDefinition.Contract);
                        if (chkCommercial.Checked)
                        {
                            job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Commercial'")[0]["ManagerID"];
                        }
                        else if (chkLandlord.Checked)
                        {
                            job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service and Certificate'")[0]["ManagerID"];
                        }
                        else
                        {
                            job.SetJobTypeID = App.DB.Picklists.GetAll(Enums.PickListTypes.JobTypes).Table.Select("NAME = 'Service'")[0]["ManagerID"];
                        }

                        job.SetStatusEnumID = Conversions.ToInteger(Enums.JobStatus.Open);
                        job.SetCreatedByUserID = App.loggedInUser.UserID;
                        job.SetFOC = true;
                        var JobNumber = new JobNumber();
                        JobNumber = App.DB.Job.GetNextJobNumber(Enums.JobDefinition.Contract);
                        job.SetJobNumber = JobNumber.Prefix + JobNumber.Number;
                        job.SetPONumber = "";
                        job.SetQuoteID = 0;
                        job.SetContractID = CurrentContract.ContractID;
                        if ((Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Enums.ContractStatus.Inactive)
                        {
                            job.SetDeleted = true;
                        }

                        // INSERT ANY ASSETS
                        foreach (DataRow dr in MainDataView.Table.Rows)
                        {
                            var JobAsset = new Entity.JobAssets.JobAsset();
                            JobAsset.SetAssetID = dr["AssetID"];
                            job.Assets.Add(JobAsset);
                        }

                        foreach (DataRow dr in SecondAppliances.Table.Rows)
                        {
                            var JobAsset = new Entity.JobAssets.JobAsset();
                            JobAsset.SetAssetID = dr["AssetID"];
                            job.Assets.Add(JobAsset);
                        }

                        // INSERT JOB ITEM
                        var jobOfWork = new Entity.JobOfWorks.JobOfWork();
                        jobOfWork.SetPONumber = "";
                        jobOfWork.IgnoreExceptionsOnSetMethods = true;
                        if ((Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Enums.ContractStatus.Inactive)
                        {
                            jobOfWork.SetDeleted = true;
                        }

                        var site = App.DB.Sites.Get(CurrentContractSite.PropertyID);
                        if (Conversions.ToDouble(CBT(txtMainAppCount.Text)) > 0)
                        {
                            var customerSors = App.DB.CustomerScheduleOfRate.Exists(4700, "Service Primary Coverplan Appliance", "CS1", site.CustomerID);
                            int customerSorId = 0;
                            if (customerSors.Rows.Count > 0)
                                customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                            if (!(customerSorId > 0))
                            {
                                var customerSor = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate()
                                {
                                    SetCode = "CS1",
                                    SetDescription = "Service Primary Coverplan Appliance",
                                    SetPrice = 0.0,
                                    SetScheduleOfRatesCategoryID = 4700,
                                    SetTimeInMins = 50,
                                    SetCustomerID = site.CustomerID
                                };
                                customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                                App.DB.CustomerScheduleOfRate.Delete(customerSorId);
                            }

                            var jobItem = new Entity.JobItems.JobItem();
                            jobItem.IgnoreExceptionsOnSetMethods = true;
                            jobItem.SetSummary = "Service Primary Coverplan Appliance";
                            jobItem.SetQty = txtMainAppCount.Text;
                            jobItem.SetRateID = customerSorId;
                            jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                            jobOfWork.JobItems.Add(jobItem);
                        }

                        if (Conversions.ToDouble(CBT(txtSecondryCount.Text)) > 0)
                        {
                            var customerSors = App.DB.CustomerScheduleOfRate.Exists(4700, "Service Additional Coverplan Appliance", "CS2", site.CustomerID);
                            int customerSorId = 0;
                            if (customerSors.Rows.Count > 0)
                                customerSorId = Helper.MakeIntegerValid(customerSors.Rows[0][0]);
                            if (!(customerSorId > 0))
                            {
                                var customerSor = new Entity.CustomerScheduleOfRates.CustomerScheduleOfRate()
                                {
                                    SetCode = "CS2",
                                    SetDescription = "Service Additional Coverplan Appliance",
                                    SetPrice = 0.0,
                                    SetScheduleOfRatesCategoryID = 4700,
                                    SetTimeInMins = 30,
                                    SetCustomerID = site.CustomerID
                                };
                                customerSorId = App.DB.CustomerScheduleOfRate.Insert(customerSor).CustomerScheduleOfRateID;
                                App.DB.CustomerScheduleOfRate.Delete(customerSorId);
                            }

                            var jobItem = new Entity.JobItems.JobItem();
                            jobItem.IgnoreExceptionsOnSetMethods = true;
                            jobItem.SetSummary = "Service Additional Coverplan Appliance";
                            jobItem.SetQty = txtSecondryCount.Text;
                            jobItem.SetRateID = customerSorId;
                            jobItem.SetSystemLinkID = Conversions.ToInteger(Enums.TableNames.tblCustomerScheduleOfRate);
                            jobOfWork.JobItems.Add(jobItem);
                        }

                        if (jobOfWork.JobItems.Count == 0)
                        {
                            var jobItem = new Entity.JobItems.JobItem();
                            jobItem.IgnoreExceptionsOnSetMethods = true;
                            jobItem.SetSummary = jobSummary;
                            jobOfWork.JobItems.Add(jobItem);
                        }

                        // NOW SEE IF WE CAN FIND A MATCHING ENGINEER
                        // IF WE FIND A MATCHING ENGINEER INSERT ENGINEER VISIT
                        var engineerVisit = new Entity.EngineerVisits.EngineerVisit();
                        engineerVisit.IgnoreExceptionsOnSetMethods = true;
                        engineerVisit.SetEngineerID = 0; // engineerID
                        engineerVisit.SetNotesToEngineer = jobSummary;
                        if (chkLandlord.Checked == true)
                        {
                            engineerVisit.SetNotesToEngineer = "DUE " + Strings.Format(estVisitDate, "dd/MM/yyyy") + " " + engineerVisit.NotesToEngineer;
                        }

                        engineerVisit.SetNotesToEngineer = engineerVisit.NotesToEngineer + " Covered by " + Combo.get_GetSelectedItemDescription(cboContractType);
                        engineerVisit.StartDateTime = DateTime.MinValue;
                        engineerVisit.EndDateTime = DateTime.MinValue;
                        engineerVisit.SetStatusEnumID = Conversions.ToInteger(Enums.VisitStatus.Ready_For_Schedule);
                        if ((Enums.ContractStatus)Conversions.ToInteger(CurrentContract.ContractStatusID) == Enums.ContractStatus.Inactive)
                        {
                            engineerVisit.SetDeleted = true;
                        }

                        jobOfWork.EngineerVisits.Add(engineerVisit);
                        job.JobOfWorks.Add(jobOfWork);
                        job = App.DB.Job.Insert(job);

                        // CREATE PPM VISIT RECORD
                        var PPM = new Entity.ContractOriginalPPMVisits.ContractOriginalPPMVisit();
                        PPM.SetContractSiteID = CurrentContractSite.ContractSiteID;
                        PPM.EstimatedVisitDate = estVisitDate;
                        PPM.SetJobID = job.JobID;
                        App.DB.ContractOriginalPPMVisit.Insert(PPM);
                        if (visitFreqIndays == 0)
                        {
                            estVisitDate = estVisitDate.AddMonths(visitFreqInMonths);
                        }
                        else if (visitFreqIndays > 0)
                        {
                            estVisitDate = estVisitDate.AddDays(visitFreqIndays);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.ShowMessage("Data cannot save : " + Constants.vbCrLf + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int InsertInvoiceToBeRaiseLines(bool part = false, bool contractChanged = false)
        {
            DateTime startDate;
            DateTime endDate;
            if (part == false)
            {
                startDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractStartDate, "dd/MM/yyyy") + " 00:00:00");
                endDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") + " 00:00:00");
            }
            else
            {
                startDate = Conversions.ToDate(Strings.Format(new DateTime(EffDate.Year, EffDate.Month, 1).AddMonths(1), "dd/MM/yyy") + " 00:00:00");
                endDate = Conversions.ToDate(Strings.Format(CurrentContract.ContractEndDate.AddDays(1), "dd/MM/yyyy") + " 00:00:00");
            }

            int days = endDate.Subtract(startDate).Days;
            int numberOfMonths = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Month, startDate, endDate));
            int numberOfInvoicesToRaise = 0;
            var switchExpr = (Enums.InvoiceFrequency_NoWeeK)Conversions.ToInteger(CurrentContract.InvoiceFrequencyID);
            switch (switchExpr)
            {
                case Enums.InvoiceFrequency_NoWeeK.Annually:
                case Enums.InvoiceFrequency_NoWeeK.AnnuallyDD:
                    {
                        numberOfInvoicesToRaise = 1;
                        break;
                    }

                case Enums.InvoiceFrequency_NoWeeK.Bi_Annually:
                    {
                        numberOfInvoicesToRaise = (int)(numberOfMonths / (double)6);
                        break;
                    }

                case Enums.InvoiceFrequency_NoWeeK.Monthly:
                    {
                        numberOfInvoicesToRaise = (int)(numberOfMonths / (double)1);
                        break;
                    }

                case Enums.InvoiceFrequency_NoWeeK.Per_Visit:
                    {
                        break;
                    }
                // Invoice the visit
                case Enums.InvoiceFrequency_NoWeeK.Quarterly:
                    {
                        numberOfInvoicesToRaise = (int)(numberOfMonths / (double)3);
                        break;
                    }

                case Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits:
                    {
                        numberOfInvoicesToRaise = (int)(numberOfMonths / (double)4);
                        break;
                    }
            }

            if (numberOfInvoicesToRaise < 1)
            {
                numberOfInvoicesToRaise = 1;
            }

            if ((contractChanged && CurrentContract.ContractTypeID == (int)Enums.ContractTypes.TotallyAssured) | CurrentContract.ContractTypeID == (int)Enums.ContractTypes.EmployeeFree | CurrentContract.ContractTypeID == (int)Enums.ContractTypes.FamilyFree)
            {
                return 0;
            }

            var raiseDate = CurrentContract.FirstInvoiceDate; // same as contract
            for (int i = 1, loopTo = numberOfInvoicesToRaise; i <= loopTo; i++)
            {
                var invToBeRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                invToBeRaised.SetAddressLinkID = CurrentContract.InvoiceAddressID;
                invToBeRaised.SetAddressTypeID = CurrentContract.InvoiceAddressTypeID;
                invToBeRaised.SetInvoiceTypeID = Conversions.ToInteger(Enums.InvoiceType.Contract_Option1);
                invToBeRaised.SetLinkID = CurrentContract.ContractID;
                invToBeRaised.RaiseDate = raiseDate;
                App.DB.InvoiceToBeRaised.Insert(invToBeRaised);
                if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaymentType)) == (double)Enums.ContractPaymentType.Direct_Debit & i == 1 & Offset) // D/D paid upfront so next D/D will skip a month
                {
                    raiseDate = new DateTime(raiseDate.Year, raiseDate.Month, 1).AddMonths(1);
                }

                var switchExpr1 = (Enums.InvoiceFrequency_NoWeeK)Conversions.ToInteger(CurrentContract.InvoiceFrequencyID);
                switch (switchExpr1)
                {
                    case Enums.InvoiceFrequency_NoWeeK.Annually:
                    case Enums.InvoiceFrequency_NoWeeK.AnnuallyDD:
                        {
                            raiseDate = raiseDate.AddYears(1);
                            break;
                        }

                    case Enums.InvoiceFrequency_NoWeeK.Bi_Annually:
                        {
                            raiseDate = raiseDate.AddMonths(6);
                            break;
                        }

                    case Enums.InvoiceFrequency_NoWeeK.Monthly:
                        {
                            raiseDate = raiseDate.AddMonths(1);
                            break;
                        }

                    case Enums.InvoiceFrequency_NoWeeK.Quarterly:
                        {
                            raiseDate = raiseDate.AddMonths(3);
                            break;
                        }

                    case Enums.InvoiceFrequency_NoWeeK.GBS_4_Month_Visits:
                        {
                            raiseDate = raiseDate.AddMonths(4);
                            break;
                        }
                }
            }

            return numberOfInvoicesToRaise;
        }

        private void DoTotals()
        {
            double total = 0.0;
            double inititalMultiplyer = 1;
            double AnnualMutliplier = 1;
            if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaymentType)) == (double)Enums.ContractPaymentType.Direct_Debit & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboInitialPaymentType)) == Conversions.ToInteger(Enums.ContractInitialPaymentType.CreditCard)) // direct debit initially paid by credit card 2.5% on first payment
            {
                inititalMultiplyer = 1;
            }
            else if (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPaymentType)) == (double)Enums.ContractPaymentType.Annual & Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboInitialPaymentType)) == Conversions.ToInteger(Enums.ContractInitialPaymentType.CreditCard)) // annual payment with credit card 2.5% on total
            {
                AnnualMutliplier = 1;
            }

            var switchExpr = Combo.get_GetSelectedItemDescription(cboContractType);
            switch (switchExpr)
            {
                case "Platinum Star":
                    {
                        total = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star", (Enums.PickListTypes)52));
                        total = total * Conversions.ToInteger(CBT(txtMainAppCount.Text));
                        total = total + Conversions.ToInteger(CBT(txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52));
                        if (chkWindowLockPest.Checked & chkPlumbingDrainage.Checked & chkGasSupplyPipework.Checked)
                        {
                            total = total + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            total = total - Conversions.ToInteger(chkGasSupplyPipework.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkPlumbingDrainage.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkWindowLockPest.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        total = total - total / 100 * discount;
                        total = total * AnnualMutliplier;
                        lblTotalEst.Text = Strings.Format(total, "C");
                        double theRounded = Math.Round(total / 12, 2);
                        lblMonthlyEst.Text = Strings.Format((theRounded + (total - theRounded * 12)) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                        break;
                    }

                case "Platinum Star System":
                    {
                        total = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star System", (Enums.PickListTypes)52));
                        total = total * Conversions.ToInteger(CBT(txtMainAppCount.Text));
                        total = total + Conversions.ToInteger(CBT(txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52));
                        if (chkWindowLockPest.Checked & chkPlumbingDrainage.Checked & chkGasSupplyPipework.Checked)
                        {
                            total = total + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            total = total - Conversions.ToInteger(chkGasSupplyPipework.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkPlumbingDrainage.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkWindowLockPest.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        total = total - total / 100 * discount;
                        total = total * AnnualMutliplier;
                        lblTotalEst.Text = Strings.Format(total, "C");
                        double theRounded = Math.Round(total / 12, 2);
                        lblMonthlyEst.Text = Strings.Format((theRounded + (total - theRounded * 12)) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                        break;
                    }

                case "Silver Star":
                    {
                        total = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Silver Star", (Enums.PickListTypes)52));
                        total = total * Conversions.ToInteger(CBT(txtMainAppCount.Text));
                        total = total + Conversions.ToInteger(CBT(txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", (Enums.PickListTypes)52));
                        if (chkWindowLockPest.Checked & chkPlumbingDrainage.Checked & chkGasSupplyPipework.Checked)
                        {
                            total = total + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            total = total - Conversions.ToInteger(chkGasSupplyPipework.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkPlumbingDrainage.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkWindowLockPest.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        total = total - total / 100 * discount;
                        total = total * AnnualMutliplier;
                        lblTotalEst.Text = Strings.Format(total, "C");
                        double theRounded = Math.Round(total / 12, 2);
                        lblMonthlyEst.Text = Strings.Format((theRounded + (total - theRounded * 12)) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                        break;
                    }

                case "Platinum Immediate":
                    {
                        total = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Immediate", (Enums.PickListTypes)52));
                        total = total * Conversions.ToInteger(CBT(txtMainAppCount.Text));
                        total = total + Conversions.ToInteger(CBT(txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52));
                        if (chkWindowLockPest.Checked & chkPlumbingDrainage.Checked & chkGasSupplyPipework.Checked)
                        {
                            total = total + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            total = total - Conversions.ToInteger(chkGasSupplyPipework.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkPlumbingDrainage.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkWindowLockPest.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        total = total - total / 100 * discount;
                        total = total * AnnualMutliplier;
                        lblTotalEst.Text = Strings.Format(total, "C");
                        double theRounded = Math.Round(total / 12, 2);
                        lblMonthlyEst.Text = Strings.Format((theRounded + (total - theRounded * 12)) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                        break;
                    }

                case "Platinum Star Agency":
                    {
                        total = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star Agency", (Enums.PickListTypes)52));
                        total = total / (1 + discount / 100);
                        total = total * AnnualMutliplier;
                        lblTotalEst.Text = Strings.Format(total, "C");
                        double theRounded = Math.Round(total / 12, 2);
                        lblMonthlyEst.Text = Strings.Format((theRounded + (total - theRounded * 12)) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                        break;
                    }

                case "Gold Star":
                    {
                        total = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gold Star", (Enums.PickListTypes)52));
                        total = total * Conversions.ToInteger(CBT(txtMainAppCount.Text));
                        total = total + Conversions.ToInteger(CBT(txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", (Enums.PickListTypes)52));
                        if (chkWindowLockPest.Checked & chkPlumbingDrainage.Checked & chkGasSupplyPipework.Checked)
                        {
                            total = total + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            total = total - Conversions.ToInteger(chkGasSupplyPipework.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkPlumbingDrainage.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkWindowLockPest.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        total = total - total / 100 * discount;
                        total = total * AnnualMutliplier;
                        lblTotalEst.Text = Strings.Format(total, "C");
                        double theRounded = Math.Round(total / 12, 2);
                        lblMonthlyEst.Text = Strings.Format((theRounded + (total - theRounded * 12)) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                        break;
                    }

                case "Gold Star Agency":
                    {
                        total = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gold Star Agency", (Enums.PickListTypes)52));
                        total = total - total / 100 * discount;
                        total = total * AnnualMutliplier;
                        lblTotalEst.Text = Strings.Format(total, "C");
                        double theRounded = Math.Round(total / 12, 2);
                        lblMonthlyEst.Text = Strings.Format((theRounded + (total - theRounded * 12)) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                        break;
                    }

                case "Totally Assured":
                    {
                        total = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("TA", (Enums.PickListTypes)52)) * Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod));
                        total = total + Conversions.ToInteger(CBT(txtSecondryCount.Text)) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52));
                        if (chkWindowLockPest.Checked & chkPlumbingDrainage.Checked & chkGasSupplyPipework.Checked)
                        {
                            total = total + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            total = total - Conversions.ToInteger(chkGasSupplyPipework.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkPlumbingDrainage.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            total = total - Conversions.ToInteger(chkWindowLockPest.Checked) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        total = total - total / 100 * discount;
                        total = total * AnnualMutliplier;
                        lblTotalEst.Text = Strings.Format(total, "C");
                        double theRounded = Math.Round(total / (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)) * 12), 2);
                        double offset = total - theRounded * (Conversions.ToDouble(Combo.get_GetSelectedItemValue(cboPeriod)) * 12);
                        lblMonthlyEst.Text = Strings.Format((theRounded + offset) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                        break;
                    }

                case "Preventative Maintenance Contract":
                case "Employee Free":
                case "Family Free Give Away":
                    {
                        total = 0;
                        discount = 0;
                        lblMonthlyEst.Text = Strings.Format(0, "C");
                        lblFollowedBy.Text = Strings.Format(0, "C");
                        lblTotalEst.Text = Strings.Format(total, "C");
                        break;
                    }

                default:
                    {
                        if ((b?.Text ?? "") == "Renew Contract" & !OverridePrice)
                        {
                            var f = new FRMNewPrice();
                            f.ShowDialog();
                            if (Information.IsNumeric(f.txtPrice.Text) && Conversions.ToDouble(f.txtPrice.Text) > 0)
                            {
                                lblTotalEst.Text = Strings.Format(Conversions.ToDouble(f.txtPrice.Text), "C");
                                lblMonthlyEst.Text = Strings.Format(Conversions.ToDouble(lblTotalEst.Text) / 12, "C");
                                lblFollowedBy.Text = Strings.Format(Conversions.ToDouble(lblTotalEst.Text) / 12, "C");
                                OverridePrice = true;
                                total = Conversions.ToDouble(f.txtPrice.Text);
                                discount = 0;
                            }
                        }

                        break;
                    }
            }

            if (b is object && (b.Text ?? "") == "Amend Contract" && !string.IsNullOrEmpty(lblMonthlyEst.Text))
            {
                double CurrentRemainMonth = 0;
                double FutureRemainMonth = 0;
                if (workingdays(CurrentContract.ContractStartDate, new DateTime(DateAndTime.Today.Year, DateAndTime.Today.Month, DateAndTime.Today.Day).AddMonths(1)) < 11)  // have we already taken the first payment?
                {
                }
                else
                {
                    CurrentRemainMonth = Conversions.ToDouble(previousSecond);
                    FutureRemainMonth = Conversions.ToDouble(lblFollowedBy.Text);
                    double totalamount = Conversions.ToDouble(lblTotalEst.Text) / 12 * DateAndTime.DateDiff(DateInterval.Month, DateAndTime.Today, CurrentContract.ContractEndDate);
                    decimal futurechange = Conversions.ToDecimal(Math.Round(totalamount - CurrentRemainMonth, 2));
                    if (totalamount != CurrentRemainMonth * DateAndTime.DateDiff(DateInterval.Month, DateAndTime.Today, CurrentContract.ContractEndDate))
                    {
                        double theRounded = Math.Round(totalamount / DateAndTime.DateDiff(DateInterval.Month, DateAndTime.Today, CurrentContract.ContractEndDate), 2);
                        double offset = totalamount - theRounded * DateAndTime.DateDiff(DateInterval.Month, DateAndTime.Today, CurrentContract.ContractEndDate);
                        lblMonthlyEst.Text = Strings.Format((theRounded + offset) * inititalMultiplyer, "C");
                        lblFollowedBy.Text = Strings.Format(theRounded, "C");
                    }
                }
            }
        }

        public string CBT(string s)
        {
            if (Information.IsNumeric(s))
                s = s;
            else
                s = "0";
            return s;
        }

        public void ContractDrop()
        {
            var dt = App.DB.ContractOriginal.GetAll_ForSite_Active(SiteID).Table;
            cboContract.Items.Clear();
            foreach (DataRow dr in dt.Rows)
                cboContract.Items.Add(new Combo(Conversions.ToString(Conversions.ToString(Conversions.ToString(dr["ContractReference"] + " : ") + dr["ContractStartDate"] + " to ") + dr["ContractEndDate"]), Conversions.ToString(Conversions.ToString(dr["ContractID"] + "`") + dr["ContractSiteID"])));
            cboContract.Items.Add(new Combo("-- Please Select --", 0.ToString()));
            cboContract.DisplayMember = "Description";
            cboContract.ValueMember = "Value";
            var argcombo = cboContract;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
        }

        public void CloseForm()
        {
            if (Number is object & NumberUsed == false)
            {
                App.DB.Job.DeleteReservedOrderNumber(Number.Number, Number.Prefix);
            }

            Dispose();
        }

        public void PayerDrop()
        {
            var dt = App.DB.InvoiceAddress.InvoiceAddress_Get_SiteID(SiteID).Table;
            cboPAyer.Items.Clear();
            foreach (DataRow dr in dt.Rows)
                cboPAyer.Items.Add(new Combo(Conversions.ToString(Conversions.ToString(Conversions.ToString(dr["Address1"] + ",") + dr["Address2"] + ",") + dr["Postcode"]), Conversions.ToString(Conversions.ToString(dr["AddressID"] + "`") + dr["AddressTypeID"])));
            cboPAyer.Items.Add(new Combo("-- Please Select --", 0.ToString()));
            cboPAyer.DisplayMember = "Description";
            cboPAyer.ValueMember = "Value";
            var argcombo = cboPAyer;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
        }

        public void ProcessContracts()
        {
            if (CurrentContract is object && CurrentContract.ContractID > 0)
            {
                var dtContracts = App.DB.ContractOriginal.ProcessContract(CurrentContract.ContractID);
                if (dtContracts is null)
                    return;
                try
                {
                    var details = new ArrayList();
                    var oPrint = new Printing(details, "ContractBatch", Enums.SystemDocumentType.ContractBatch, true, 0, true, dt: dtContracts);
                    var ar = oPrint.MultiEmail();
                    Process.Start(ar[0]);
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void ProcessExpiry()
        {
            bool failed = false;
            DataTable ContractsDT;
            if (CurrentContract.ContractID > 0)
            {
                try
                {
                    ContractsDT = App.DB.ContractOriginal.Contract_Get_Renewal(CurrentContract.ContractID).Table;
                    ContractsDT.Columns.Add("RenewalPrice");
                    if (ContractsDT.Select("InvoiceFrequencyID = 6").Length > 0)
                    {

                        // calculate and if sucsessfull add it as new to database the next main function will raise the renewal details
                        if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ContractsDT.Rows[0]["ContractTypeID"], Enums.ContractTypes.PreventativeMaintenance, false)))
                        {
                            var f = new FRMNewPrice();
                            f.ShowDialog();
                            if (Information.IsNumeric(f.txtPrice.Text) && Conversions.ToDouble(f.txtPrice.Text) > 0)
                            {
                                ContractsDT.Rows[0]["RenewalPrice"] = Conversions.ToDouble(f.txtPrice.Text);
                                OverridePrice = true;
                            }
                            else
                            {
                                App.ShowMessage("Please enter amount without commas or pound sign", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            double newprice = CalculateNewRateAndRenew(ContractsDT.Rows[0]);
                            ContractsDT.Rows[0]["RenewalPrice"] = newprice;
                        }

                        var details = new ArrayList();
                        var oPrint = new Printing(details, "ContractExpiry", Enums.SystemDocumentType.ContractExpiry, true, 0, true, dt: ContractsDT);
                        var ar = oPrint.MultiEmail();
                        Process.Start(ar[0]);
                    }
                }
                catch (Exception ex)
                {
                    failed = true;
                }
            }
        }

        public double CalculateNewRateAndRenew(DataRow dr)
        {
            decimal divider = DateAndTime.DateDiff(DateInterval.Year, Conversions.ToDate(dr["ContractStartDate"]), Conversions.ToDate(dr["ContractEndDate"]).AddDays(+10));
            if (divider == 0)
                divider = 1;
            double OldPrice = Conversions.ToDouble(dr["ContractPrice"] / divider * 1.2); // inc vat
            int MainApps = 0;
            int SecondryApps = 0;
            var dt = App.DB.ContractOriginalSiteAsset.GetAll_ContractSiteID(Conversions.ToInteger(dr["ContractSiteID"]), Conversions.ToInteger(dr["siteid"])).Table;
            dt.Columns.Add("PrimaryAsset");
            if (Information.IsDBNull(dr["MainAppliances"]) && Information.IsDBNull(dr["SecondryAppliances"]))
            {
                // code to determin how many appliances

                string Backboiler = "";
                int count = 0;
                foreach (DataRow r in dt.Select("Tick = 1"))
                {
                    if ((r["product"].ToString().Split('-')[0].Trim() ?? "") == "Back Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Warm Air unit")
                    {
                        Backboiler = r["product"].ToString().Split('-')[1].Trim();
                    }

                    if ((r["product"].ToString().Split('-')[0].Trim() ?? "") == "Back Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Oil Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Air Source Heat Pump" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Cond Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Cond Boiler Store" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Cond Combi" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Std Eff Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Std Eff Boiler Store" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Std Eff Combi" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Warn Air Unit")
                    {
                        MainApps += 1;
                        dt.Rows[count]["PrimaryAsset"] = true;
                    }
                    else
                    {
                        SecondryApps += 1;
                        dt.Rows[count]["PrimaryAsset"] = false;
                    }

                    count += 1;
                }

                foreach (DataRow r in dt.Select("Tick = 1"))
                {
                    if ((Backboiler ?? "") == (r["product"].ToString().Split('-')[1].Trim() ?? "") && (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Gas Fire" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Circulator")
                    {
                        SecondryApps += -1;
                        break;
                    }
                }
            }
            else
            {
                MainApps = Conversions.ToInteger(dr["MainAppliances"]);
                SecondryApps = Conversions.ToInteger(dr["SecondryAppliances"]);
                int m2 = 0;
                int s2 = 0;
                string Backboiler = "";
                int count = 0;
                foreach (DataRow r in dt.Select("Tick = 1"))
                {
                    if ((r["product"].ToString().Split('-')[0].Trim() ?? "") == "Back Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Warm Air unit")
                    {
                        Backboiler = r["product"].ToString().Split('-')[1].Trim();
                    }

                    if ((r["product"].ToString().Split('-')[0].Trim() ?? "") == "Back Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Oil Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Air Source Heat Pump" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Cond Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Cond Boiler Store" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Cond Combi" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Std Eff Boiler" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Std Eff Boiler Store" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Std Eff Combi" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Warn Air Unit")
                    {
                        m2 += 1;
                        dt.Rows[count]["PrimaryAsset"] = true;
                    }
                    else
                    {
                        s2 += 1;
                        dt.Rows[count]["PrimaryAsset"] = false;
                    }

                    count += 1;
                }

                foreach (DataRow r in dt.Select("Tick = 1"))
                {
                    if ((Backboiler ?? "") == (r["product"].ToString().Split('-')[1].Trim() ?? "") && (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Gas Fire" | (r["product"].ToString().Split('-')[0].Trim() ?? "") == "Circulator")
                    {
                        s2 += -1;
                        break;
                    }
                }

                if (MainApps + SecondryApps < 1)
                {
                    MainApps = m2;
                    SecondryApps = s2;
                }
            }

            int DiscountID = 0;
            if (!Information.IsDBNull(dr["DiscountID"]))
            {
                DiscountID = Conversions.ToInteger(dr["DiscountID"]);
            }

            int diff = Conversions.ToInteger(DateAndTime.DateDiff(DateInterval.Year, Conversions.ToDate(dr["ContractStartDate"]), Conversions.ToDate(dr["ContractEndDate"]).AddDays(10)));
            if (diff == 0)
                diff = 1;
            int conttype = Conversions.ToInteger(dr["ContractTypeID"]);
            if (conttype == 68032)
                conttype = (int)Enums.ContractTypes.PlatinumStar; // (convert a PI to a PS it will fail price check sooo...)
            var newtotal = Gettotal(conttype, MainApps, SecondryApps, Conversions.ToBoolean(dr["WindowLockPest"]), Conversions.ToBoolean(dr["PlumbingDrainage"]), Conversions.ToBoolean(dr["GasSupplyPipework"]), DiscountID, diff);
            if (Conversions.ToBoolean(newtotal[0] / OldPrice > 1.1 & !Operators.ConditionalCompareObjectEqual(dr["ContractTypeID"], 68032, false) | newtotal[0] / OldPrice < 0.9 & !Operators.ConditionalCompareObjectEqual(dr["ContractTypeID"], 68032, false)))  // Added failure (create) if PI
            {
                // the price has swung too much something is wrong
                newtotal[0] = 0;
            }

            return newtotal[0];
        }

        public double[] Gettotal(int ContractTypeID, int Main, int Add, bool WindowsLocks, bool PlumbingDrainage, bool GasSupply, int DiscountID, int Years)
        {
            var newprice = new[] { 0.01, 0.01, 0.01 };
            double Discount = 0;
            if (!Information.IsDBNull(DiscountID) && DiscountID > 0)
            {
                Discount = App.DB.Picklists.Get_One_As_Object(DiscountID).PercentageRate;
            }

            if (Main == 0 & Add > 1)   // sort out primary applaince
            {
                Main = 1;
                Add = Add - 1;
            }

            if (Main == 0 & Add == 0)
            {
                Main = 1;
            }

            switch (ContractTypeID)
            {
                case (int)Enums.ContractTypes.PlatinumStar:
                    {
                        newprice[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star", (Enums.PickListTypes)52));
                        newprice[0] = newprice[0] * Main;
                        newprice[0] = newprice[0] + Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52));
                        if (WindowsLocks & PlumbingDrainage & GasSupply)
                        {
                            newprice[0] = newprice[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            newprice[0] = newprice[0] - Conversions.ToDouble(GasSupply) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(PlumbingDrainage) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(WindowsLocks) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        newprice[0] = newprice[0] - newprice[0] / 100 * Discount;
                        double theRounded = Math.Round(newprice[0] / 12, 2);
                        newprice[1] = Conversions.ToDouble(Strings.Format(theRounded + (newprice[0] - theRounded * 12), "C")); // First Month
                        newprice[2] = Conversions.ToDouble(Strings.Format(theRounded, "C"));  // followed by
                        break;
                    }

                case (int)Enums.ContractTypes.PlatinumImmediate:
                    {
                        newprice[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Immediate", (Enums.PickListTypes)52));
                        newprice[0] = newprice[0] * Main;
                        newprice[0] = newprice[0] + Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52));
                        if (WindowsLocks & PlumbingDrainage & GasSupply)
                        {
                            newprice[0] = newprice[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            newprice[0] = newprice[0] - Conversions.ToDouble(GasSupply) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(PlumbingDrainage) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(WindowsLocks) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        newprice[0] = newprice[0] - newprice[0] / 100 * Discount;
                        double theRounded = Math.Round(newprice[0] / 12, 2);
                        newprice[1] = Conversions.ToDouble(Strings.Format(theRounded + (newprice[0] - theRounded * 12), "C"));
                        newprice[2] = Conversions.ToDouble(Strings.Format(theRounded, "C"));
                        break;
                    }

                case 67353: // TODO old possible drop
                    {
                        newprice[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Platinum Star Agency", (Enums.PickListTypes)52));
                        newprice[0] = newprice[0] - newprice[0] / 100 * Discount;
                        double theRounded = Math.Round(newprice[0] / 12, 2);
                        newprice[1] = Conversions.ToDouble(Strings.Format(theRounded + (newprice[0] - theRounded * 12), "C"));
                        newprice[2] = Conversions.ToDouble(Strings.Format(theRounded, "C"));
                        break;
                    }

                case (int)Enums.ContractTypes.GoldStar:
                    {
                        newprice[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gold Star", (Enums.PickListTypes)52));
                        newprice[0] = newprice[0] * Main;
                        newprice[0] = newprice[0] + Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", (Enums.PickListTypes)52));
                        if (WindowsLocks & PlumbingDrainage & GasSupply)
                        {
                            newprice[0] = newprice[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            newprice[0] = newprice[0] - Conversions.ToDouble(GasSupply) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(PlumbingDrainage) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(WindowsLocks) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        newprice[0] = newprice[0] - newprice[0] / 100 * Discount;
                        double theRounded = Math.Round(newprice[0] / 12, 2);
                        newprice[1] = Conversions.ToDouble(Strings.Format(theRounded + (newprice[0] - theRounded * 12), "C"));
                        newprice[2] = Conversions.ToDouble(Strings.Format(theRounded, "C"));
                        break;
                    }

                case 67247: // TODO old possible drop
                    {
                        newprice[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gold Star Agency", (Enums.PickListTypes)52));
                        // newprice(0) = newprice(0) / (1 + (Discount / 100))
                        double theRounded = Math.Round(newprice[0] / 12, 2);
                        newprice[1] = Conversions.ToDouble(Strings.Format(theRounded + (newprice[0] - theRounded * 12), "C"));
                        newprice[2] = Conversions.ToDouble(Strings.Format(theRounded, "C"));
                        break;
                    }

                case 68294: // TODO old possible drop
                    {
                        newprice[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("TA", (Enums.PickListTypes)52)) * Years;
                        newprice[0] = newprice[0] - newprice[0] / 100 * Discount;
                        newprice[0] = newprice[0] + Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance PLAT", (Enums.PickListTypes)52));
                        if (WindowsLocks & PlumbingDrainage & GasSupply)
                        {
                            newprice[0] = newprice[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            newprice[0] = newprice[0] - Conversions.ToDouble(GasSupply) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(PlumbingDrainage) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(WindowsLocks) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        double theRounded = Math.Round(newprice[0] / (Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("TA", (Enums.PickListTypes)52)) / 12), 2);
                        newprice[1] = Conversions.ToDouble(Strings.Format(theRounded + (newprice[0] - theRounded * (Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("TA", (Enums.PickListTypes)52)) / 12)), "C"));
                        newprice[2] = Conversions.ToDouble(Strings.Format(theRounded, "C"));
                        break;
                    }

                case (int)Enums.ContractTypes.SilverStar:
                    {
                        newprice[0] = Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Silver Star", (Enums.PickListTypes)52));
                        newprice[0] = newprice[0] * Main;
                        newprice[0] = newprice[0] + Add * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Additional Appliance", (Enums.PickListTypes)52));
                        if (WindowsLocks & PlumbingDrainage & GasSupply)
                        {
                            newprice[0] = newprice[0] + Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("AHE", (Enums.PickListTypes)52));
                        }
                        else
                        {
                            newprice[0] = newprice[0] - Conversions.ToDouble(GasSupply) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("Gas Supply Pipework", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(PlumbingDrainage) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("PDE", (Enums.PickListTypes)52));
                            newprice[0] = newprice[0] - Conversions.ToDouble(WindowsLocks) * Conversions.ToDouble(App.DB.Picklists.Get_Single_Description("WLP", (Enums.PickListTypes)52));
                        }

                        newprice[0] = newprice[0] - newprice[0] / 100 * Discount;
                        double theRounded = Math.Round(newprice[0] / 12, 2);
                        newprice[1] = Conversions.ToDouble(Strings.Format(theRounded + (newprice[0] - theRounded * 12), "C"));
                        newprice[2] = Conversions.ToDouble(Strings.Format(theRounded, "C"));
                        break;
                    }
            }

            return newprice;
        }

        public void SetUpSoldByCombo()
        {
            cboSoldBy.Items.Clear();
            cboSoldBy.Items.Add("-- Not Applicable --");
            cboSoldBy.DataSource = App.DB.Engineer.User_And_Engineer_GetAll();
            cboSoldBy.DisplayMember = "Name";
            cboSoldBy.ValueMember = "UID";
            cboSoldBy.SelectedIndex = 0;
        }
    }

    public sealed class Simple3Des
    {
        private TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();

        public Simple3Des(string key)
        {
            // Initialize the crypto provider.
            TripleDes.Key = TruncateHash(key, TripleDes.KeySize / 8);
            TripleDes.IV = TruncateHash("", TripleDes.BlockSize / 8);
        }

        private byte[] TruncateHash(string key, int length)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            // Hash the key.
            var keyBytes = System.Text.Encoding.Unicode.GetBytes(key);
            var hash = sha1.ComputeHash(keyBytes);

            // Truncate or pad the hash.
            var oldHash = hash;
            hash = new byte[length];
            if (oldHash is object)
                Array.Copy(oldHash, hash, Math.Min(length, oldHash.Length));
            return hash;
        }

        public string EncryptData(string plaintext)
        {

            // Convert the plaintext string to a byte array.
            var plaintextBytes = System.Text.Encoding.Unicode.GetBytes(plaintext);

            // Create the stream.
            var ms = new System.IO.MemoryStream();
            // Create the encoder to write to the stream.
            var encStream = new CryptoStream(ms, TripleDes.CreateEncryptor(), CryptoStreamMode.Write);

            // Use the crypto stream to write the byte array to the stream.
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length);
            encStream.FlushFinalBlock();

            // Convert the encrypted stream to a printable string.
            return Convert.ToBase64String(ms.ToArray());
        }

        public string DecryptData(string encryptedtext)
        {

            // Convert the encrypted text string to a byte array.
            var encryptedBytes = Convert.FromBase64String(encryptedtext);

            // Create the stream.
            var ms = new System.IO.MemoryStream();
            // Create the decoder to write to the stream.
            var decStream = new CryptoStream(ms, TripleDes.CreateDecryptor(), CryptoStreamMode.Write);

            // Use the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            decStream.FlushFinalBlock();

            // Convert the plaintext stream to a string.
            return System.Text.Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}