using FSM.Entity.Engineers;
using FSM.Entity.EngineerVisitCharges;
using FSM.Entity.EngineerVisits;
using FSM.Entity.EngineerVisits.EngineerVisitEngineers;
using FSM.Entity.EngineerVisits.EngineerVisitEngineers.Enums;
using FSM.Entity.Sys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace FSM
{
    public class FRMEngineerVisit : FRMBaseForm, IForm
    {
        // SEE LAST REGION FOR ALL CHARGE PAGE CODE - ALP

        public FRMEngineerVisit() : base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            var argc = cboInvType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll((Enums.PickListTypes)65).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = cboPaidBy;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll((Enums.PickListTypes)66).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);

            // Add any initialization after the InitializeComponent() call
            var argc2 = cboEngineer;
            Combo.SetUpCombo(ref argc2, dtEngineerGetAll, "EngineerID", "Name", Enums.ComboValues.Not_Applicable);
            var argc3 = cboOutcome;
            Combo.SetUpCombo(ref argc3, DynamicDataTables.OutcomeStatuses, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            var argc4 = cboGasInstallationTightnessTest;
            Combo.SetUpCombo(ref argc4, dtPassFailNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc5 = cboEmergencyControlAccessible;
            Combo.SetUpCombo(ref argc5, dtPassFailNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc6 = cboBonding;
            Combo.SetUpCombo(ref argc6, dtPassFailNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc7 = cboPropertyRented;
            Combo.SetUpCombo(ref argc7, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc8 = cboPaymentMethod;
            Combo.SetUpCombo(ref argc8, App.DB.Picklists.GetAll(Enums.PickListTypes.PaymentMethods).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc9 = cboSignatureSelected;
            Combo.SetUpCombo(ref argc9, App.DB.Picklists.GetAll(Enums.PickListTypes.Signature).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            //
            // QC Comboboxes
            //
            var argc10 = cboQCAppliance;
            Combo.SetUpCombo(ref argc10, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc11 = cboQCCustSig;
            Combo.SetUpCombo(ref argc11, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc12 = cboQCCustomerDetails;
            Combo.SetUpCombo(ref argc12, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc13 = cboQCEngineerPaymentRecieved;
            Combo.SetUpCombo(ref argc13, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc14 = cboQCJobType;
            Combo.SetUpCombo(ref argc14, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc15 = cboQCJobUploadTimescale;
            Combo.SetUpCombo(ref argc15, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc16 = cboQCLabourTime;
            Combo.SetUpCombo(ref argc16, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc17 = cboQCLGSR;
            Combo.SetUpCombo(ref argc17, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc18 = cboQCOrderNo;
            Combo.SetUpCombo(ref argc18, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc19 = cboQCParts;
            Combo.SetUpCombo(ref argc19, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc20 = cboQCPaymentCollection;
            Combo.SetUpCombo(ref argc20, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc21 = cboQCPaymentMethod;
            Combo.SetUpCombo(ref argc21, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc22 = cboQCPaymentSelection;
            Combo.SetUpCombo(ref argc22, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc23 = cboQCScheduleOfRate;
            Combo.SetUpCombo(ref argc23, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc24 = cboRecall;
            Combo.SetUpCombo(ref argc24, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc25 = cboRecallEngineer;
            Combo.SetUpCombo(ref argc25, dtEngineerGetAll, "EngineerID", "Name", Enums.ComboValues.Please_Select);
            var argc26 = cboFTFCode;
            Combo.SetUpCombo(ref argc26, App.DB.Picklists.GetAll(Enums.PickListTypes.FTFCodes).Table, "ManagerID", "Description", Enums.ComboValues.Please_Select);
            //
            //
            //

            var argc27 = cboVATRate;
            Combo.SetUpCombo(ref argc27, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select);
            var argc28 = cboCorrectMaterialsUsedID;
            Combo.SetUpCombo(ref argc28, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc29 = cboInstallationPipeWorkCorrectID;
            Combo.SetUpCombo(ref argc29, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc30 = cboInstallationSafeToUseID;
            Combo.SetUpCombo(ref argc30, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc31 = cboStrainerFittedID;
            Combo.SetUpCombo(ref argc31, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc32 = cboStrainerInspectedID;
            Combo.SetUpCombo(ref argc32, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc33 = cboHeatingSystemTypeID;
            Combo.SetUpCombo(ref argc33, App.DB.Picklists.GetAll(Enums.PickListTypes.HeatingSystemType).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc34 = cboPartialHeatingID;
            Combo.SetUpCombo(ref argc34, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc35 = cboCylinderTypeID;
            Combo.SetUpCombo(ref argc35, App.DB.Picklists.GetAll(Enums.PickListTypes.CylinderType).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc36 = cboCertificateTypeID;
            Combo.SetUpCombo(ref argc36, App.DB.Picklists.GetAll(Enums.PickListTypes.CertificateType).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc37 = cboJacketID;
            Combo.SetUpCombo(ref argc37, App.DB.Picklists.GetAll(Enums.PickListTypes.Jacket).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc38 = cboImmersionID;
            Combo.SetUpCombo(ref argc38, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc39 = cboCODetectorFittedID;
            Combo.SetUpCombo(ref argc39, dtYesNo, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc40 = cboFillDisc;
            Combo.SetUpCombo(ref argc40, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc41 = cboSITimer;
            Combo.SetUpCombo(ref argc41, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc42 = cboVisualInspectionSatisfactoryID;
            Combo.SetUpCombo(ref argc42, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc43 = cboRecharge;
            Combo.SetUpCombo(ref argc43, App.DB.Picklists.GetAll(Enums.PickListTypes.Recharge).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc44 = cboNccRad;
            Combo.SetUpCombo(ref argc44, App.DB.Picklists.GetAll(Enums.PickListTypes.NccRad).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc45 = cboMeterLocation;
            Combo.SetUpCombo(ref argc45, App.DB.Picklists.GetAll(Enums.PickListTypes.MeterLocation).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc46 = cboMeterCapped;
            Combo.SetUpCombo(ref argc46, dtYesNoNA, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            switch (true)
            {
                case object _ when App.IsGasway:
                    {
                        var argc47 = cboDept;
                        Combo.SetUpCombo(ref argc47, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Name", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }

                default:
                    {
                        var argc48 = cboDept;
                        Combo.SetUpCombo(ref argc48, App.DB.Picklists.GetAll(Enums.PickListTypes.Department).Table, "Name", "Description", Enums.ComboValues.Please_Select_Negative);
                        break;
                    }
            }
            base.Load += FRMEngineerVisit_Load;
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
        private TabControl _tcWorkSheet;

        internal TabControl tcWorkSheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tcWorkSheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tcWorkSheet != null)
                {
                }

                _tcWorkSheet = value;
                if (_tcWorkSheet != null)
                {
                }
            }
        }

        private TabPage _tpMainDetails;

        internal TabPage tpMainDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpMainDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpMainDetails != null)
                {
                }

                _tpMainDetails = value;
                if (_tpMainDetails != null)
                {
                }
            }
        }

        private Button _btnClose;

        internal Button btnClose
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClose;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClose != null)
                {
                    _btnClose.Click -= btnClose_Click;
                }

                _btnClose = value;
                if (_btnClose != null)
                {
                    _btnClose.Click += btnClose_Click;
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

        private TabPage _tpPartsAndProducts;

        internal TabPage tpPartsAndProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpPartsAndProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpPartsAndProducts != null)
                {
                }

                _tpPartsAndProducts = value;
                if (_tpPartsAndProducts != null)
                {
                }
            }
        }

        private TabPage _tpTimesheets;

        internal TabPage tpTimesheets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpTimesheets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpTimesheets != null)
                {
                }

                _tpTimesheets = value;
                if (_tpTimesheets != null)
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

        private Label _Label9;

        private Label _Label10;

        private Label _Label11;

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

        private TextBox _txtScheduledTime;

        internal TextBox txtScheduledTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtScheduledTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtScheduledTime != null)
                {
                }

                _txtScheduledTime = value;
                if (_txtScheduledTime != null)
                {
                }
            }
        }

        private GroupBox _grpTimesheets;

        internal GroupBox grpTimesheets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpTimesheets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpTimesheets != null)
                {
                }

                _grpTimesheets = value;
                if (_grpTimesheets != null)
                {
                }
            }
        }

        private GroupBox _grpUsed;

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

        private ComboBox _cboEngineer;

        internal ComboBox cboEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEngineer != null)
                {
                }

                _cboEngineer = value;
                if (_cboEngineer != null)
                {
                }
            }
        }

        private TextBox _txtNotesFromEngineer;

        internal TextBox txtNotesFromEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNotesFromEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNotesFromEngineer != null)
                {
                }

                _txtNotesFromEngineer = value;
                if (_txtNotesFromEngineer != null)
                {
                }
            }
        }

        private ComboBox _cboOutcome;

        internal ComboBox cboOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboOutcome != null)
                {
                    _cboOutcome.SelectedIndexChanged -= cboOutcome_SelectedIndexChanged;
                }

                _cboOutcome = value;
                if (_cboOutcome != null)
                {
                    _cboOutcome.SelectedIndexChanged += cboOutcome_SelectedIndexChanged;
                }
            }
        }

        private TextBox _txtOutcomeDetails;

        internal TextBox txtOutcomeDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtOutcomeDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtOutcomeDetails != null)
                {
                }

                _txtOutcomeDetails = value;
                if (_txtOutcomeDetails != null)
                {
                }
            }
        }

        private TextBox _txtUploadedBy;

        internal TextBox txtUploadedBy
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtUploadedBy;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtUploadedBy != null)
                {
                }

                _txtUploadedBy = value;
                if (_txtUploadedBy != null)
                {
                }
            }
        }

        private TextBox _txtStatus;

        internal TextBox txtStatus
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtStatus;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtStatus != null)
                {
                }

                _txtStatus = value;
                if (_txtStatus != null)
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

        private ContextMenu _mnuAddChecklist;

        internal ContextMenu mnuAddChecklist
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _mnuAddChecklist;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_mnuAddChecklist != null)
                {
                }

                _mnuAddChecklist = value;
                if (_mnuAddChecklist != null)
                {
                }
            }
        }

        private Label _Label12;

        private DataGrid _dgJobItems;

        internal DataGrid dgJobItems
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgJobItems;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgJobItems != null)
                {
                    _dgJobItems.CurrentCellChanged -= dgJobItems_CurrentCellChanged;
                }

                _dgJobItems = value;
                if (_dgJobItems != null)
                {
                    _dgJobItems.CurrentCellChanged += dgJobItems_CurrentCellChanged;
                }
            }
        }

        private Label _Label13;

        private Label _Label15;

        private Label _Label16;

        private DataGrid _dgPartsAndProductsUsed;

        internal DataGrid dgPartsAndProductsUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartsAndProductsUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartsAndProductsUsed != null)
                {
                }

                _dgPartsAndProductsUsed = value;
                if (_dgPartsAndProductsUsed != null)
                {
                }
            }
        }

        private TextBox _txtNameUsed;

        internal TextBox txtNameUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNameUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNameUsed != null)
                {
                }

                _txtNameUsed = value;
                if (_txtNameUsed != null)
                {
                }
            }
        }

        private Button _btnRemovePartProductUsed;

        private Button _btnFindProductUsed;

        private Button _btnFindPartUsed;

        private Button _btnAddPartProductUsed;

        internal Button btnAddPartProductUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddPartProductUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddPartProductUsed != null)
                {
                    _btnAddPartProductUsed.Click -= btnAddPartProduct_Click;
                }

                _btnAddPartProductUsed = value;
                if (_btnAddPartProductUsed != null)
                {
                    _btnAddPartProductUsed.Click += btnAddPartProduct_Click;
                }
            }
        }

        private NumericUpDown _nudQuantityUsed;

        internal NumericUpDown nudQuantityUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _nudQuantityUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_nudQuantityUsed != null)
                {
                }

                _nudQuantityUsed = value;
                if (_nudQuantityUsed != null)
                {
                }
            }
        }

        private TextBox _txtNumberUsed;

        internal TextBox txtNumberUsed
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNumberUsed;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNumberUsed != null)
                {
                }

                _txtNumberUsed = value;
                if (_txtNumberUsed != null)
                {
                }
            }
        }

        private Button _btnAddTimeSheet;

        private Label _Label20;

        private Label _Label21;

        private Button _btnRemoveTimeSheet;

        private DataGrid _dgTimeSheets;

        internal DataGrid dgTimeSheets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgTimeSheets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgTimeSheets != null)
                {
                }

                _dgTimeSheets = value;
                if (_dgTimeSheets != null)
                {
                }
            }
        }

        private DateTimePicker _dtpStartDate;

        internal DateTimePicker dtpStartDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpStartDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpStartDate != null)
                {
                    _dtpStartDate.ValueChanged -= dtpStartDate_ValueChanged;
                }

                _dtpStartDate = value;
                if (_dtpStartDate != null)
                {
                    _dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
                }
            }
        }

        private DateTimePicker _dtpEndDate;

        internal DateTimePicker dtpEndDate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpEndDate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpEndDate != null)
                {
                }

                _dtpEndDate = value;
                if (_dtpEndDate != null)
                {
                }
            }
        }

        private TextBox _txtComments;

        internal TextBox txtComments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtComments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtComments != null)
                {
                }

                _txtComments = value;
                if (_txtComments != null)
                {
                }
            }
        }

        private Label _Label14;

        private ComboBox _cboTimeSheetType;

        internal ComboBox cboTimeSheetType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboTimeSheetType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboTimeSheetType != null)
                {
                }

                _cboTimeSheetType = value;
                if (_cboTimeSheetType != null)
                {
                }
            }
        }

        private Label _Label22;

        private GroupBox _gpbScheduleOfRates;

        internal GroupBox gpbScheduleOfRates
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbScheduleOfRates;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbScheduleOfRates != null)
                {
                }

                _gpbScheduleOfRates = value;
                if (_gpbScheduleOfRates != null)
                {
                }
            }
        }

        private GroupBox _gpbTimesheets;

        internal GroupBox gpbTimesheets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbTimesheets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbTimesheets != null)
                {
                }

                _gpbTimesheets = value;
                if (_gpbTimesheets != null)
                {
                }
            }
        }

        private GroupBox _gpbAdditionalCharges;

        internal GroupBox gpbAdditionalCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbAdditionalCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbAdditionalCharges != null)
                {
                }

                _gpbAdditionalCharges = value;
                if (_gpbAdditionalCharges != null)
                {
                }
            }
        }

        private GroupBox _gpbPartsAndProducts;

        internal GroupBox gpbPartsAndProducts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbPartsAndProducts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbPartsAndProducts != null)
                {
                }

                _gpbPartsAndProducts = value;
                if (_gpbPartsAndProducts != null)
                {
                }
            }
        }

        private DataGrid _dgScheduleOfRateCharges;

        internal DataGrid dgScheduleOfRateCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgScheduleOfRateCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgScheduleOfRateCharges != null)
                {
                    _dgScheduleOfRateCharges.MouseUp -= dgScheduleOfRateCharges_MouseUp;
                }

                _dgScheduleOfRateCharges = value;
                if (_dgScheduleOfRateCharges != null)
                {
                    _dgScheduleOfRateCharges.MouseUp += dgScheduleOfRateCharges_MouseUp;
                }
            }
        }

        private TextBox _txtScheduleOfRatesTotal;

        internal TextBox txtScheduleOfRatesTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtScheduleOfRatesTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtScheduleOfRatesTotal != null)
                {
                }

                _txtScheduleOfRatesTotal = value;
                if (_txtScheduleOfRatesTotal != null)
                {
                }
            }
        }

        private Label _Label26;

        private TextBox _txtTimesheetTotal;

        internal TextBox txtTimesheetTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtTimesheetTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtTimesheetTotal != null)
                {
                    _txtTimesheetTotal.Leave -= txtTimesheetTotal_Leave;
                }

                _txtTimesheetTotal = value;
                if (_txtTimesheetTotal != null)
                {
                    _txtTimesheetTotal.Leave += txtTimesheetTotal_Leave;
                }
            }
        }

        private Label _Label27;

        private DataGrid _dgTimesheetCharges;

        internal DataGrid dgTimesheetCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgTimesheetCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgTimesheetCharges != null)
                {
                    _dgTimesheetCharges.MouseUp -= dgTimesheetCharges_MouseUp;
                }

                _dgTimesheetCharges = value;
                if (_dgTimesheetCharges != null)
                {
                    _dgTimesheetCharges.MouseUp += dgTimesheetCharges_MouseUp;
                }
            }
        }

        private Label _Label29;

        private Label _lblDescription;

        private TextBox _txtAdditionalChargeDescription;

        internal TextBox txtAdditionalChargeDescription
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAdditionalChargeDescription;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAdditionalChargeDescription != null)
                {
                }

                _txtAdditionalChargeDescription = value;
                if (_txtAdditionalChargeDescription != null)
                {
                }
            }
        }

        private Button _btnRemoveAdditionalCharge;

        private Button _btnAddAdditionalCharge;

        private TabPage _tpCharges;

        internal TabPage tpCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpCharges != null)
                {
                }

                _tpCharges = value;
                if (_tpCharges != null)
                {
                }
            }
        }

        private DataGrid _dgPartsProductCharging;

        internal DataGrid dgPartsProductCharging
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartsProductCharging;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartsProductCharging != null)
                {
                    _dgPartsProductCharging.MouseUp -= dgPartsProductCharging_MouseUp;
                }

                _dgPartsProductCharging = value;
                if (_dgPartsProductCharging != null)
                {
                    _dgPartsProductCharging.MouseUp += dgPartsProductCharging_MouseUp;
                }
            }
        }

        private TextBox _txtAdditionalChargeTotal;

        internal TextBox txtAdditionalChargeTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAdditionalChargeTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAdditionalChargeTotal != null)
                {
                }

                _txtAdditionalChargeTotal = value;
                if (_txtAdditionalChargeTotal != null)
                {
                }
            }
        }

        private DataGrid _dgAdditionalCharges;

        internal DataGrid dgAdditionalCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAdditionalCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAdditionalCharges != null)
                {
                }

                _dgAdditionalCharges = value;
                if (_dgAdditionalCharges != null)
                {
                }
            }
        }

        private TextBox _txtAdditionalCharge;

        internal TextBox txtAdditionalCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAdditionalCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAdditionalCharge != null)
                {
                }

                _txtAdditionalCharge = value;
                if (_txtAdditionalCharge != null)
                {
                }
            }
        }

        private CheckBox _cbxVisitLockDown;

        internal CheckBox cbxVisitLockDown
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxVisitLockDown;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxVisitLockDown != null)
                {
                    _cbxVisitLockDown.CheckedChanged -= cbxVisitLockDown_CheckedChanged;
                }

                _cbxVisitLockDown = value;
                if (_cbxVisitLockDown != null)
                {
                    _cbxVisitLockDown.CheckedChanged += cbxVisitLockDown_CheckedChanged;
                }
            }
        }

        private Label _lblSellPrice;

        internal Label lblSellPrice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblSellPrice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblSellPrice != null)
                {
                }

                _lblSellPrice = value;
                if (_lblSellPrice != null)
                {
                }
            }
        }

        private Label _lblStatusWarning;

        internal Label lblStatusWarning
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblStatusWarning;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblStatusWarning != null)
                {
                }

                _lblStatusWarning = value;
                if (_lblStatusWarning != null)
                {
                }
            }
        }

        private GroupBox _gpbCharges;

        internal GroupBox gpbCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbCharges != null)
                {
                }

                _gpbCharges = value;
                if (_gpbCharges != null)
                {
                }
            }
        }

        private TextBox _txtJobValue;

        internal TextBox txtJobValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtJobValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtJobValue != null)
                {
                }

                _txtJobValue = value;
                if (_txtJobValue != null)
                {
                }
            }
        }

        private RadioButton _rdoJobValue;

        internal RadioButton rdoJobValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoJobValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoJobValue != null)
                {
                    _rdoJobValue.CheckedChanged -= rdoJobValue_CheckedChanged;
                }

                _rdoJobValue = value;
                if (_rdoJobValue != null)
                {
                    _rdoJobValue.CheckedChanged += rdoJobValue_CheckedChanged;
                }
            }
        }

        private RadioButton _rdoChargeOther;

        internal RadioButton rdoChargeOther
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoChargeOther;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoChargeOther != null)
                {
                    _rdoChargeOther.CheckedChanged -= rdoChargeOther_CheckedChanged;
                }

                _rdoChargeOther = value;
                if (_rdoChargeOther != null)
                {
                    _rdoChargeOther.CheckedChanged += rdoChargeOther_CheckedChanged;
                }
            }
        }

        private TextBox _txtPercentOfQuote;

        internal TextBox txtPercentOfQuote
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPercentOfQuote;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPercentOfQuote != null)
                {
                    _txtPercentOfQuote.TextChanged -= txtPercentOfQuote_TextChanged;
                }

                _txtPercentOfQuote = value;
                if (_txtPercentOfQuote != null)
                {
                    _txtPercentOfQuote.TextChanged += txtPercentOfQuote_TextChanged;
                }
            }
        }

        private RadioButton _rdoPercentageOfQuoteValue;

        internal RadioButton rdoPercentageOfQuoteValue
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _rdoPercentageOfQuoteValue;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_rdoPercentageOfQuoteValue != null)
                {
                    _rdoPercentageOfQuoteValue.CheckedChanged -= rdoPercentageOfQuoteValue_CheckedChanged;
                }

                _rdoPercentageOfQuoteValue = value;
                if (_rdoPercentageOfQuoteValue != null)
                {
                    _rdoPercentageOfQuoteValue.CheckedChanged += rdoPercentageOfQuoteValue_CheckedChanged;
                }
            }
        }

        private Label _lblPercent;

        internal Label lblPercent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPercent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPercent != null)
                {
                }

                _lblPercent = value;
                if (_lblPercent != null)
                {
                }
            }
        }

        private GroupBox _gpbInvoice;

        internal GroupBox gpbInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gpbInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gpbInvoice != null)
                {
                }

                _gpbInvoice = value;
                if (_gpbInvoice != null)
                {
                }
            }
        }

        private CheckBox _cbxReadyToBeInvoiced;

        internal CheckBox cbxReadyToBeInvoiced
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxReadyToBeInvoiced;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxReadyToBeInvoiced != null)
                {
                    _cbxReadyToBeInvoiced.CheckedChanged -= cbxReadyToBeInvoiced_CheckedChanged;
                }

                _cbxReadyToBeInvoiced = value;
                if (_cbxReadyToBeInvoiced != null)
                {
                    _cbxReadyToBeInvoiced.CheckedChanged += cbxReadyToBeInvoiced_CheckedChanged;
                }
            }
        }

        private TextBox _txtCharge;

        internal TextBox txtCharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCharge != null)
                {
                }

                _txtCharge = value;
                if (_txtCharge != null)
                {
                }
            }
        }

        private Label _lblEquals;

        internal Label lblEquals
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEquals;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEquals != null)
                {
                }

                _lblEquals = value;
                if (_lblEquals != null)
                {
                }
            }
        }

        private Label _lblQuotePercentageTotal;

        internal Label lblQuotePercentageTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuotePercentageTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuotePercentageTotal != null)
                {
                }

                _lblQuotePercentageTotal = value;
                if (_lblQuotePercentageTotal != null)
                {
                }
            }
        }

        private Label _Label30;

        private Label _lblOR;

        internal Label lblOR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblOR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblOR != null)
                {
                }

                _lblOR = value;
                if (_lblOR != null)
                {
                }
            }
        }

        private Label _lblRaiseInvoiceOn;

        internal Label lblRaiseInvoiceOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRaiseInvoiceOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRaiseInvoiceOn != null)
                {
                }

                _lblRaiseInvoiceOn = value;
                if (_lblRaiseInvoiceOn != null)
                {
                }
            }
        }

        private DateTimePicker _dtpRaiseInvoiceOn;

        internal DateTimePicker dtpRaiseInvoiceOn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpRaiseInvoiceOn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpRaiseInvoiceOn != null)
                {
                    _dtpRaiseInvoiceOn.ValueChanged -= dtpRaiseInvoiceOn_ValueChanged;
                }

                _dtpRaiseInvoiceOn = value;
                if (_dtpRaiseInvoiceOn != null)
                {
                    _dtpRaiseInvoiceOn.ValueChanged += dtpRaiseInvoiceOn_ValueChanged;
                }
            }
        }

        private TextBox _txtEngineerCostTotal;

        internal TextBox txtEngineerCostTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtEngineerCostTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtEngineerCostTotal != null)
                {
                }

                _txtEngineerCostTotal = value;
                if (_txtEngineerCostTotal != null)
                {
                }
            }
        }

        private Label _Label32;

        private Button _btnOrders;

        internal Button btnOrders
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOrders;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOrders != null)
                {
                    _btnOrders.Click -= btnOrders_Click;
                }

                _btnOrders = value;
                if (_btnOrders != null)
                {
                    _btnOrders.Click += btnOrders_Click;
                }
            }
        }

        private Button _btnInvoice;

        internal Button btnInvoice
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnInvoice;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnInvoice != null)
                {
                    _btnInvoice.Click -= btnInvoice_Click;
                }

                _btnInvoice = value;
                if (_btnInvoice != null)
                {
                    _btnInvoice.Click += btnInvoice_Click;
                }
            }
        }

        private GroupBox _grpAllocated;

        private DataGrid _dgPartsProductsAllocated;

        internal DataGrid dgPartsProductsAllocated
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgPartsProductsAllocated;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgPartsProductsAllocated != null)
                {
                    _dgPartsProductsAllocated.Click -= dgPartsProductsAllocated_Click;
                }

                _dgPartsProductsAllocated = value;
                if (_dgPartsProductsAllocated != null)
                {
                    _dgPartsProductsAllocated.Click += dgPartsProductsAllocated_Click;
                }
            }
        }

        private Button _btnAllocatedNotUsed;

        private Panel _Panel1;

        private Label _Label34;

        private Panel _Panel2;

        private Label _Label35;

        private Button _btnAllUsed;

        private Label _lblContractPerVisit;

        internal Label lblContractPerVisit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblContractPerVisit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblContractPerVisit != null)
                {
                }

                _lblContractPerVisit = value;
                if (_lblContractPerVisit != null)
                {
                }
            }
        }

        private Button _btnPrint;

        private Button _btnAddSoR;

        private TextBox _txtCurrentContract;

        internal TextBox txtCurrentContract
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCurrentContract;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCurrentContract != null)
                {
                }

                _txtCurrentContract = value;
                if (_txtCurrentContract != null)
                {
                }
            }
        }

        private Label _Label39;

        private Button _btnSearch;

        internal Button btnSearch
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSearch;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSearch != null)
                {
                    _btnSearch.Click -= btnSearch_Click;
                }

                _btnSearch = value;
                if (_btnSearch != null)
                {
                    _btnSearch.Click += btnSearch_Click;
                }
            }
        }

        private TabPage _tpWorksheets;

        internal TabPage tpWorksheets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpWorksheets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpWorksheets != null)
                {
                }

                _tpWorksheets = value;
                if (_tpWorksheets != null)
                {
                }
            }
        }

        private GroupBox _grpVisitWorksheet;

        internal GroupBox grpVisitWorksheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVisitWorksheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVisitWorksheet != null)
                {
                }

                _grpVisitWorksheet = value;
                if (_grpVisitWorksheet != null)
                {
                }
            }
        }

        private Label _Label7;

        private Label _Label8;

        private Label _Label40;

        private Label _Label41;

        private ComboBox _cboGasInstallationTightnessTest;

        internal ComboBox cboGasInstallationTightnessTest
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboGasInstallationTightnessTest;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboGasInstallationTightnessTest != null)
                {
                }

                _cboGasInstallationTightnessTest = value;
                if (_cboGasInstallationTightnessTest != null)
                {
                }
            }
        }

        private ComboBox _cboEmergencyControlAccessible;

        internal ComboBox cboEmergencyControlAccessible
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboEmergencyControlAccessible;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboEmergencyControlAccessible != null)
                {
                }

                _cboEmergencyControlAccessible = value;
                if (_cboEmergencyControlAccessible != null)
                {
                }
            }
        }

        private ComboBox _cboBonding;

        internal ComboBox cboBonding
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboBonding;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboBonding != null)
                {
                }

                _cboBonding = value;
                if (_cboBonding != null)
                {
                }
            }
        }

        private ComboBox _cboPropertyRented;

        internal ComboBox cboPropertyRented
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPropertyRented;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPropertyRented != null)
                {
                }

                _cboPropertyRented = value;
                if (_cboPropertyRented != null)
                {
                }
            }
        }

        private ComboBox _cboSignatureSelected;

        internal ComboBox cboSignatureSelected
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSignatureSelected;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSignatureSelected != null)
                {
                }

                _cboSignatureSelected = value;
                if (_cboSignatureSelected != null)
                {
                }
            }
        }

        private Label _Label42;

        private Label _Label43;

        private Label _Label44;

        private ComboBox _cboPaymentMethod;

        internal ComboBox cboPaymentMethod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPaymentMethod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPaymentMethod != null)
                {
                }

                _cboPaymentMethod = value;
                if (_cboPaymentMethod != null)
                {
                }
            }
        }

        private TextBox _txtAmountCollected;

        internal TextBox txtAmountCollected
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAmountCollected;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAmountCollected != null)
                {
                }

                _txtAmountCollected = value;
                if (_txtAmountCollected != null)
                {
                }
            }
        }

        private GroupBox _grpApplianceWorksheet;

        internal GroupBox grpApplianceWorksheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpApplianceWorksheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpApplianceWorksheet != null)
                {
                }

                _grpApplianceWorksheet = value;
                if (_grpApplianceWorksheet != null)
                {
                }
            }
        }

        private GroupBox _grpVisitDefects;

        internal GroupBox grpVisitDefects
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVisitDefects;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVisitDefects != null)
                {
                }

                _grpVisitDefects = value;
                if (_grpVisitDefects != null)
                {
                }
            }
        }

        private DataGrid _dgApplianceWorkSheets;

        internal DataGrid dgApplianceWorkSheets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgApplianceWorkSheets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgApplianceWorkSheets != null)
                {
                    _dgApplianceWorkSheets.DoubleClick -= dgApplianceWorkSheets_DoubleClick;
                }

                _dgApplianceWorkSheets = value;
                if (_dgApplianceWorkSheets != null)
                {
                    _dgApplianceWorkSheets.DoubleClick += dgApplianceWorkSheets_DoubleClick;
                }
            }
        }

        private DataGrid _dgVisitDefects;

        internal DataGrid dgVisitDefects
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgVisitDefects;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgVisitDefects != null)
                {
                    _dgVisitDefects.DoubleClick -= dgVisitDefects_DoubleClick;
                }

                _dgVisitDefects = value;
                if (_dgVisitDefects != null)
                {
                    _dgVisitDefects.DoubleClick += dgVisitDefects_DoubleClick;
                }
            }
        }

        private Button _btnRemoveVisitDefect;

        internal Button btnRemoveVisitDefect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveVisitDefect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveVisitDefect != null)
                {
                    _btnRemoveVisitDefect.Click -= btnRemoveVisitDefect_Click;
                }

                _btnRemoveVisitDefect = value;
                if (_btnRemoveVisitDefect != null)
                {
                    _btnRemoveVisitDefect.Click += btnRemoveVisitDefect_Click;
                }
            }
        }

        private Button _btnAddVisitDefect;

        internal Button btnAddVisitDefect
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddVisitDefect;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddVisitDefect != null)
                {
                    _btnAddVisitDefect.Click -= btnAddVisitDefect_Click;
                }

                _btnAddVisitDefect = value;
                if (_btnAddVisitDefect != null)
                {
                    _btnAddVisitDefect.Click += btnAddVisitDefect_Click;
                }
            }
        }

        private Button _btnRemoveApplianceWorkSheet;

        internal Button btnRemoveApplianceWorkSheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveApplianceWorkSheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveApplianceWorkSheet != null)
                {
                    _btnRemoveApplianceWorkSheet.Click -= btnRemoveApplianceWorkSheet_Click;
                }

                _btnRemoveApplianceWorkSheet = value;
                if (_btnRemoveApplianceWorkSheet != null)
                {
                    _btnRemoveApplianceWorkSheet.Click += btnRemoveApplianceWorkSheet_Click;
                }
            }
        }

        private ContextMenuStrip _PrintMenu;

        internal ContextMenuStrip PrintMenu
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PrintMenu;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PrintMenu != null)
                {
                }

                _PrintMenu = value;
                if (_PrintMenu != null)
                {
                }
            }
        }

        private ToolStripMenuItem _mnuGasSafetyInspectionBoilerServiceRecord;

        private Label _lblInvoiceAddressDetails;

        internal Label lblInvoiceAddressDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvoiceAddressDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvoiceAddressDetails != null)
                {
                }

                _lblInvoiceAddressDetails = value;
                if (_lblInvoiceAddressDetails != null)
                {
                }
            }
        }

        private Label _lblDepartment;

        private TextBox _txtNominalCode;

        internal TextBox txtNominalCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtNominalCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtNominalCode != null)
                {
                    _txtNominalCode.TextChanged -= txtNominalCode_TextChanged;
                }

                _txtNominalCode = value;
                if (_txtNominalCode != null)
                {
                    _txtNominalCode.TextChanged += txtNominalCode_TextChanged;
                }
            }
        }

        private Label _lblNominalCode;

        private Button _btnPrintGSR;

        private TabPage _tpAppliances;

        internal TabPage tpAppliances
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpAppliances;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpAppliances != null)
                {
                }

                _tpAppliances = value;
                if (_tpAppliances != null)
                {
                }
            }
        }

        private GroupBox _gpAppliances;

        private DataGrid _dgAssets;

        internal DataGrid dgAssets
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAssets;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAssets != null)
                {
                }

                _dgAssets = value;
                if (_dgAssets != null)
                {
                }
            }
        }

        private TabPage _tpOutcomes;

        internal TabPage tpOutcomes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpOutcomes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpOutcomes != null)
                {
                }

                _tpOutcomes = value;
                if (_tpOutcomes != null)
                {
                }
            }
        }

        private CheckBox _chkGasServiceCompleted;

        internal CheckBox chkGasServiceCompleted
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkGasServiceCompleted;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkGasServiceCompleted != null)
                {
                }

                _chkGasServiceCompleted = value;
                if (_chkGasServiceCompleted != null)
                {
                }
            }
        }

        private GroupBox _grpOutcomes;

        private Button _btnPrintSVR;

        internal Button btnPrintSVR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnPrintSVR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnPrintSVR != null)
                {
                    _btnPrintSVR.Click -= btnPrintSVR_Click;
                }

                _btnPrintSVR = value;
                if (_btnPrintSVR != null)
                {
                    _btnPrintSVR.Click += btnPrintSVR_Click;
                }
            }
        }

        private TabPage _tpQC;

        internal TabPage tpQC
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpQC;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpQC != null)
                {
                }

                _tpQC = value;
                if (_tpQC != null)
                {
                }
            }
        }

        private GroupBox _GroupBox4;

        private CheckBox _cbxEmailReceiptToCustomer;

        internal CheckBox cbxEmailReceiptToCustomer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cbxEmailReceiptToCustomer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cbxEmailReceiptToCustomer != null)
                {
                }

                _cbxEmailReceiptToCustomer = value;
                if (_cbxEmailReceiptToCustomer != null)
                {
                }
            }
        }

        private TextBox _txtAccountCode;

        internal TextBox txtAccountCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAccountCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAccountCode != null)
                {
                    _txtAccountCode.TextChanged -= txtAccountCode_TextChanged;
                }

                _txtAccountCode = value;
                if (_txtAccountCode != null)
                {
                    _txtAccountCode.TextChanged += txtAccountCode_TextChanged;
                }
            }
        }

        private Label _lblAccountCode;

        internal Label lblAccountCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAccountCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAccountCode != null)
                {
                }

                _lblAccountCode = value;
                if (_lblAccountCode != null)
                {
                }
            }
        }

        private Button _btnJob;

        private TextBox _txtPriceIncVAT;

        internal TextBox txtPriceIncVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPriceIncVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPriceIncVAT != null)
                {
                }

                _txtPriceIncVAT = value;
                if (_txtPriceIncVAT != null)
                {
                }
            }
        }

        private Label _lblPriceInvVAT;

        internal Label lblPriceInvVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPriceInvVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPriceInvVAT != null)
                {
                }

                _lblPriceInvVAT = value;
                if (_lblPriceInvVAT != null)
                {
                }
            }
        }

        private NumericUpDown _nudPartAllocatedQty;

        internal NumericUpDown nudPartAllocatedQty
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _nudPartAllocatedQty;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_nudPartAllocatedQty != null)
                {
                }

                _nudPartAllocatedQty = value;
                if (_nudPartAllocatedQty != null)
                {
                }
            }
        }

        private Label _lblAllocatedQuantity;

        internal Label lblAllocatedQuantity
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblAllocatedQuantity;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblAllocatedQuantity != null)
                {
                }

                _lblAllocatedQuantity = value;
                if (_lblAllocatedQuantity != null)
                {
                }
            }
        }

        private PictureBox _pbCustomerSignature;

        internal PictureBox pbCustomerSignature
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbCustomerSignature;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbCustomerSignature != null)
                {
                }

                _pbCustomerSignature = value;
                if (_pbCustomerSignature != null)
                {
                }
            }
        }

        private PictureBox _pbEngineerSignature;

        internal PictureBox pbEngineerSignature
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _pbEngineerSignature;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_pbEngineerSignature != null)
                {
                }

                _pbEngineerSignature = value;
                if (_pbEngineerSignature != null)
                {
                }
            }
        }

        private Label _lblEquipment;

        internal Label lblEquipment
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblEquipment;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblEquipment != null)
                {
                }

                _lblEquipment = value;
                if (_lblEquipment != null)
                {
                }
            }
        }

        private GroupBox _grpVisitWorksheetExtended;

        internal GroupBox grpVisitWorksheetExtended
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpVisitWorksheetExtended;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpVisitWorksheetExtended != null)
                {
                }

                _grpVisitWorksheetExtended = value;
                if (_grpVisitWorksheetExtended != null)
                {
                }
            }
        }

        private ComboBox _cboStrainerInspectedID;

        internal ComboBox cboStrainerInspectedID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStrainerInspectedID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStrainerInspectedID != null)
                {
                }

                _cboStrainerInspectedID = value;
                if (_cboStrainerInspectedID != null)
                {
                }
            }
        }

        private Label _Label57;

        private ComboBox _cboStrainerFittedID;

        internal ComboBox cboStrainerFittedID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboStrainerFittedID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboStrainerFittedID != null)
                {
                }

                _cboStrainerFittedID = value;
                if (_cboStrainerFittedID != null)
                {
                }
            }
        }

        private ComboBox _cboInstallationSafeToUseID;

        internal ComboBox cboInstallationSafeToUseID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInstallationSafeToUseID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInstallationSafeToUseID != null)
                {
                }

                _cboInstallationSafeToUseID = value;
                if (_cboInstallationSafeToUseID != null)
                {
                }
            }
        }

        private ComboBox _cboInstallationPipeWorkCorrectID;

        internal ComboBox cboInstallationPipeWorkCorrectID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboInstallationPipeWorkCorrectID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboInstallationPipeWorkCorrectID != null)
                {
                }

                _cboInstallationPipeWorkCorrectID = value;
                if (_cboInstallationPipeWorkCorrectID != null)
                {
                }
            }
        }

        private ComboBox _cboCorrectMaterialsUsedID;

        internal ComboBox cboCorrectMaterialsUsedID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCorrectMaterialsUsedID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCorrectMaterialsUsedID != null)
                {
                }

                _cboCorrectMaterialsUsedID = value;
                if (_cboCorrectMaterialsUsedID != null)
                {
                }
            }
        }

        private Label _Label58;

        private Label _Label59;

        private Label _Label60;

        private Label _Label61;

        private TextBox _txtVisualInspectionReason;

        internal TextBox txtVisualInspectionReason
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtVisualInspectionReason;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtVisualInspectionReason != null)
                {
                }

                _txtVisualInspectionReason = value;
                if (_txtVisualInspectionReason != null)
                {
                }
            }
        }

        private Label _Label68;

        private Label _Label69;

        private Label _Label70;

        private Label _Label62;

        private Label _Label63;

        private Label _Label64;

        private Label _Label65;

        private Label _Label66;

        private Label _Label67;

        private ComboBox _cboCertificateTypeID;

        internal ComboBox cboCertificateTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCertificateTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCertificateTypeID != null)
                {
                }

                _cboCertificateTypeID = value;
                if (_cboCertificateTypeID != null)
                {
                }
            }
        }

        private ComboBox _cboCODetectorFittedID;

        internal ComboBox cboCODetectorFittedID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCODetectorFittedID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCODetectorFittedID != null)
                {
                }

                _cboCODetectorFittedID = value;
                if (_cboCODetectorFittedID != null)
                {
                }
            }
        }

        private ComboBox _cboImmersionID;

        internal ComboBox cboImmersionID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboImmersionID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboImmersionID != null)
                {
                }

                _cboImmersionID = value;
                if (_cboImmersionID != null)
                {
                }
            }
        }

        private ComboBox _cboJacketID;

        internal ComboBox cboJacketID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboJacketID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboJacketID != null)
                {
                }

                _cboJacketID = value;
                if (_cboJacketID != null)
                {
                }
            }
        }

        private ComboBox _cboCylinderTypeID;

        internal ComboBox cboCylinderTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboCylinderTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboCylinderTypeID != null)
                {
                }

                _cboCylinderTypeID = value;
                if (_cboCylinderTypeID != null)
                {
                }
            }
        }

        private ComboBox _cboPartialHeatingID;

        internal ComboBox cboPartialHeatingID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboPartialHeatingID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboPartialHeatingID != null)
                {
                }

                _cboPartialHeatingID = value;
                if (_cboPartialHeatingID != null)
                {
                }
            }
        }

        private ComboBox _cboHeatingSystemTypeID;

        internal ComboBox cboHeatingSystemTypeID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboHeatingSystemTypeID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboHeatingSystemTypeID != null)
                {
                }

                _cboHeatingSystemTypeID = value;
                if (_cboHeatingSystemTypeID != null)
                {
                }
            }
        }

        private TextBox _txtApproxAgeOfBoiler;

        internal TextBox txtApproxAgeOfBoiler
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtApproxAgeOfBoiler;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtApproxAgeOfBoiler != null)
                {
                }

                _txtApproxAgeOfBoiler = value;
                if (_txtApproxAgeOfBoiler != null)
                {
                }
            }
        }

        private Label _Label56;

        private CheckBox _chkRecharge;

        internal CheckBox chkRecharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkRecharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkRecharge != null)
                {
                    _chkRecharge.CheckedChanged -= chkRecharge_CheckedChanged;
                }

                _chkRecharge = value;
                if (_chkRecharge != null)
                {
                    _chkRecharge.CheckedChanged += chkRecharge_CheckedChanged;
                }
            }
        }

        private TextBox _txtRadiators;

        internal TextBox txtRadiators
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtRadiators;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtRadiators != null)
                {
                }

                _txtRadiators = value;
                if (_txtRadiators != null)
                {
                }
            }
        }

        private ComboBox _cboVisualInspectionSatisfactoryID;

        internal ComboBox cboVisualInspectionSatisfactoryID
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVisualInspectionSatisfactoryID;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVisualInspectionSatisfactoryID != null)
                {
                }

                _cboVisualInspectionSatisfactoryID = value;
                if (_cboVisualInspectionSatisfactoryID != null)
                {
                }
            }
        }

        private Label _lblRechargeTicked;

        internal Label lblRechargeTicked
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblRechargeTicked;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblRechargeTicked != null)
                {
                }

                _lblRechargeTicked = value;
                if (_lblRechargeTicked != null)
                {
                }
            }
        }

        private TabPage _tpDocuments;

        internal TabPage tpDocuments
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _tpDocuments;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_tpDocuments != null)
                {
                }

                _tpDocuments = value;
                if (_tpDocuments != null)
                {
                }
            }
        }

        private Button _btnChangeOutcome;

        internal Button btnChangeOutcome
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnChangeOutcome;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnChangeOutcome != null)
                {
                    _btnChangeOutcome.Click -= btnChangeOutcome_Click;
                }

                _btnChangeOutcome = value;
                if (_btnChangeOutcome != null)
                {
                    _btnChangeOutcome.Click += btnChangeOutcome_Click;
                }
            }
        }

        private TextBox _txtScheduledTime2;

        internal TextBox txtScheduledTime2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtScheduledTime2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtScheduledTime2 != null)
                {
                }

                _txtScheduledTime2 = value;
                if (_txtScheduledTime2 != null)
                {
                }
            }
        }

        private Label _Label71;

        private Button _btnShowVisits;

        private RadioButton _CostsToOption3;

        internal RadioButton CostsToOption3
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CostsToOption3;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CostsToOption3 != null)
                {
                    _CostsToOption3.CheckedChanged -= radioButtonCostsTo_CheckedChanged;
                }

                _CostsToOption3 = value;
                if (_CostsToOption3 != null)
                {
                    _CostsToOption3.CheckedChanged += radioButtonCostsTo_CheckedChanged;
                }
            }
        }

        private RadioButton _CostsToOption2;

        internal RadioButton CostsToOption2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CostsToOption2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CostsToOption2 != null)
                {
                    _CostsToOption2.CheckedChanged -= radioButtonCostsTo_CheckedChanged;
                }

                _CostsToOption2 = value;
                if (_CostsToOption2 != null)
                {
                    _CostsToOption2.CheckedChanged += radioButtonCostsTo_CheckedChanged;
                }
            }
        }

        private RadioButton _CostsToOption1;

        internal RadioButton CostsToOption1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CostsToOption1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CostsToOption1 != null)
                {
                    _CostsToOption1.CheckedChanged -= radioButtonCostsTo_CheckedChanged;
                }

                _CostsToOption1 = value;
                if (_CostsToOption1 != null)
                {
                    _CostsToOption1.CheckedChanged += radioButtonCostsTo_CheckedChanged;
                }
            }
        }

        private GroupBox _GroupBox6;

        private GroupBox _grpAlarmInfo;

        internal GroupBox grpAlarmInfo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAlarmInfo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAlarmInfo != null)
                {
                }

                _grpAlarmInfo = value;
                if (_grpAlarmInfo != null)
                {
                }
            }
        }

        private TabPage _tpPhotos;

        private FlowLayoutPanel _flPhotos;

        internal FlowLayoutPanel flPhotos
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _flPhotos;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_flPhotos != null)
                {
                }

                _flPhotos = value;
                if (_flPhotos != null)
                {
                }
            }
        }

        private ComboBox _cboFTFCode;

        internal ComboBox cboFTFCode
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFTFCode;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFTFCode != null)
                {
                }

                _cboFTFCode = value;
                if (_cboFTFCode != null)
                {
                }
            }
        }

        private Label _Label74;

        private DataGrid _dgAdditional;

        internal DataGrid dgAdditional
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgAdditional;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgAdditional != null)
                {
                    _dgAdditional.DoubleClick -= dgAdditionalWorkSheets_DoubleClick;
                }

                _dgAdditional = value;
                if (_dgAdditional != null)
                {
                    _dgAdditional.DoubleClick += dgAdditionalWorkSheets_DoubleClick;
                }
            }
        }

        private ComboBox _cboRecharge;

        internal ComboBox cboRecharge
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRecharge;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRecharge != null)
                {
                    _cboRecharge.SelectedIndexChanged -= cboRecharge_SelectedIndexChanged;
                }

                _cboRecharge = value;
                if (_cboRecharge != null)
                {
                    _cboRecharge.SelectedIndexChanged += cboRecharge_SelectedIndexChanged;
                }
            }
        }

        private Label _Label75;

        private ComboBox _cboNccRad;

        internal ComboBox cboNccRad
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboNccRad;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboNccRad != null)
                {
                }

                _cboNccRad = value;
                if (_cboNccRad != null)
                {
                }
            }
        }

        private Label _Label76;

        private ToolStripPanel _BottomToolStripPanel;

        private ToolStripPanel _TopToolStripPanel;

        private ToolStripPanel _RightToolStripPanel;

        private ToolStripPanel _LeftToolStripPanel;

        private ToolStripContentPanel _ContentPanel;

        private ComboBox _cboSITimer;

        internal ComboBox cboSITimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboSITimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboSITimer != null)
                {
                }

                _cboSITimer = value;
                if (_cboSITimer != null)
                {
                }
            }
        }

        private ComboBox _cboFillDisc;

        internal ComboBox cboFillDisc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboFillDisc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboFillDisc != null)
                {
                }

                _cboFillDisc = value;
                if (_cboFillDisc != null)
                {
                }
            }
        }

        private Label _Label81;

        private Label _Label80;

        private Label _Label79;

        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        private TextBox _txtCustEmail;

        internal TextBox txtCustEmail
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCustEmail;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCustEmail != null)
                {
                }

                _txtCustEmail = value;
                if (_txtCustEmail != null)
                {
                }
            }
        }

        private Button _btnEditInvoiceNotes;

        internal Button btnEditInvoiceNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnEditInvoiceNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnEditInvoiceNotes != null)
                {
                    _btnEditInvoiceNotes.Click -= btnEditInvoiceNotes_Click;
                }

                _btnEditInvoiceNotes = value;
                if (_btnEditInvoiceNotes != null)
                {
                    _btnEditInvoiceNotes.Click += btnEditInvoiceNotes_Click;
                }
            }
        }

        private ComboBox _cboVATRate;

        internal ComboBox cboVATRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboVATRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboVATRate != null)
                {
                    _cboVATRate.SelectedIndexChanged -= cboVATRate_SelectedIndexChanged;
                }

                _cboVATRate = value;
                if (_cboVATRate != null)
                {
                    _cboVATRate.SelectedIndexChanged += cboVATRate_SelectedIndexChanged;
                }
            }
        }

        private Label _lblVAT;

        internal Label lblVAT
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblVAT;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblVAT != null)
                {
                }

                _lblVAT = value;
                if (_lblVAT != null)
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
                    _cboPaidBy.SelectedIndexChanged -= cboPaidBy_SelectedIndexChanged;
                }

                _cboPaidBy = value;
                if (_cboPaidBy != null)
                {
                    _cboPaidBy.SelectedIndexChanged += cboPaidBy_SelectedIndexChanged;
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

        private Label _lblcredit;

        internal Label lblcredit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblcredit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblcredit != null)
                {
                    _lblcredit.Click -= lblcredit_Click;
                }

                _lblcredit = value;
                if (_lblcredit != null)
                {
                    _lblcredit.Click += lblcredit_Click;
                }
            }
        }

        private TextBox _txtCreditAmount;

        internal TextBox txtCreditAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCreditAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCreditAmount != null)
                {
                }

                _txtCreditAmount = value;
                if (_txtCreditAmount != null)
                {
                }
            }
        }

        private Label _lblInvNo;

        internal Label lblInvNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvNo != null)
                {
                }

                _lblInvNo = value;
                if (_lblInvNo != null)
                {
                }
            }
        }

        private TextBox _txtInvNo;

        internal TextBox txtInvNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvNo != null)
                {
                }

                _txtInvNo = value;
                if (_txtInvNo != null)
                {
                }
            }
        }

        private Label _lblInvAmount;

        internal Label lblInvAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblInvAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblInvAmount != null)
                {
                }

                _lblInvAmount = value;
                if (_lblInvAmount != null)
                {
                }
            }
        }

        private TextBox _txtInvAmount;

        internal TextBox txtInvAmount
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtInvAmount;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtInvAmount != null)
                {
                }

                _txtInvAmount = value;
                if (_txtInvAmount != null)
                {
                }
            }
        }

        private Button _btnCreateServ;

        internal Button btnCreateServ
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCreateServ;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCreateServ != null)
                {
                    _btnCreateServ.Click -= btnCreateServ_Click;
                }

                _btnCreateServ = value;
                if (_btnCreateServ != null)
                {
                    _btnCreateServ.Click += btnCreateServ_Click;
                }
            }
        }

        private CheckBox _chkSORDesc;

        internal CheckBox chkSORDesc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkSORDesc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkSORDesc != null)
                {
                    _chkSORDesc.CheckedChanged -= chkSORDesc_CheckedChanged;
                }

                _chkSORDesc = value;
                if (_chkSORDesc != null)
                {
                    _chkSORDesc.CheckedChanged += chkSORDesc_CheckedChanged;
                }
            }
        }

        private GroupBox _grpAdditionalWorksheet;

        internal GroupBox grpAdditionalWorksheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _grpAdditionalWorksheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_grpAdditionalWorksheet != null)
                {
                }

                _grpAdditionalWorksheet = value;
                if (_grpAdditionalWorksheet != null)
                {
                }
            }
        }

        private Button _btnRemoveAdd;

        internal Button btnRemoveAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnRemoveAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnRemoveAdd != null)
                {
                }

                _btnRemoveAdd = value;
                if (_btnRemoveAdd != null)
                {
                }
            }
        }

        private Button _btnAddAdd;

        internal Button btnAddAdd
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddAdd;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddAdd != null)
                {
                }

                _btnAddAdd = value;
                if (_btnAddAdd != null)
                {
                }
            }
        }

        private DataGrid _DGSmokeComo;

        internal DataGrid DGSmokeComo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DGSmokeComo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DGSmokeComo != null)
                {
                    _DGSmokeComo.DoubleClick -= dgSmokeComoWorkSheets_DoubleClick;
                }

                _DGSmokeComo = value;
                if (_DGSmokeComo != null)
                {
                    _DGSmokeComo.DoubleClick += dgSmokeComoWorkSheets_DoubleClick;
                }
            }
        }

        private Button _btnRemoveSmokeComo;

        private Button _btnAddSmokeComo;

        private ContextMenuStrip _SVRs;

        internal ContextMenuStrip SVRs
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SVRs;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SVRs != null)
                {
                }

                _SVRs = value;
                if (_SVRs != null)
                {
                }
            }
        }

        private ToolStripMenuItem _svrmenu;

        private ToolStripMenuItem _JobSheetMenu;

        private ToolStripMenuItem _DomesticGSRToolStripMenuItem;

        internal ToolStripMenuItem DomesticGSRToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DomesticGSRToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DomesticGSRToolStripMenuItem != null)
                {
                    _DomesticGSRToolStripMenuItem.Click -= DomesticGSRToolStripMenuItem_Click;
                }

                _DomesticGSRToolStripMenuItem = value;
                if (_DomesticGSRToolStripMenuItem != null)
                {
                    _DomesticGSRToolStripMenuItem.Click += DomesticGSRToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _WarningNoticeToolStripMenuItem;

        internal ToolStripMenuItem WarningNoticeToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _WarningNoticeToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_WarningNoticeToolStripMenuItem != null)
                {
                    _WarningNoticeToolStripMenuItem.Click -= WarningNoticeToolStripMenuItem_Click;
                }

                _WarningNoticeToolStripMenuItem = value;
                if (_WarningNoticeToolStripMenuItem != null)
                {
                    _WarningNoticeToolStripMenuItem.Click += WarningNoticeToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _CommercialGSRToolStripMenuItem;

        internal ToolStripMenuItem CommercialGSRToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CommercialGSRToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CommercialGSRToolStripMenuItem != null)
                {
                    _CommercialGSRToolStripMenuItem.Click -= CommercialGSRToolStripMenuItem_Click;
                }

                _CommercialGSRToolStripMenuItem = value;
                if (_CommercialGSRToolStripMenuItem != null)
                {
                    _CommercialGSRToolStripMenuItem.Click += CommercialGSRToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _QCResultsToolStripMenuItem;

        internal ToolStripMenuItem QCResultsToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _QCResultsToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_QCResultsToolStripMenuItem != null)
                {
                    _QCResultsToolStripMenuItem.Click -= QCResultsToolStripMenuItem_Click;
                }

                _QCResultsToolStripMenuItem = value;
                if (_QCResultsToolStripMenuItem != null)
                {
                    _QCResultsToolStripMenuItem.Click += QCResultsToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ElectricalMinorWorksToolStripMenuItem;

        internal ToolStripMenuItem ElectricalMinorWorksToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ElectricalMinorWorksToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ElectricalMinorWorksToolStripMenuItem != null)
                {
                    _ElectricalMinorWorksToolStripMenuItem.Click -= ElectricalMinorWorksToolStripMenuItem_Click;
                }

                _ElectricalMinorWorksToolStripMenuItem = value;
                if (_ElectricalMinorWorksToolStripMenuItem != null)
                {
                    _ElectricalMinorWorksToolStripMenuItem.Click += ElectricalMinorWorksToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _AllGasPaperworkToolStripMenuItem;

        internal ToolStripMenuItem AllGasPaperworkToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _AllGasPaperworkToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_AllGasPaperworkToolStripMenuItem != null)
                {
                    _AllGasPaperworkToolStripMenuItem.Click -= AllGasPaperworkToolStripMenuItem_Click;
                }

                _AllGasPaperworkToolStripMenuItem = value;
                if (_AllGasPaperworkToolStripMenuItem != null)
                {
                    _AllGasPaperworkToolStripMenuItem.Click += AllGasPaperworkToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _CommercialCateringToolStripMenuItem;

        internal ToolStripMenuItem CommercialCateringToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CommercialCateringToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CommercialCateringToolStripMenuItem != null)
                {
                    _CommercialCateringToolStripMenuItem.Click -= CommercialCateringToolStripMenuItem_Click;
                }

                _CommercialCateringToolStripMenuItem = value;
                if (_CommercialCateringToolStripMenuItem != null)
                {
                    _CommercialCateringToolStripMenuItem.Click += CommercialCateringToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _SaffronUnventedWorkshhetToolStripMenuItem;

        internal ToolStripMenuItem SaffronUnventedWorkshhetToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SaffronUnventedWorkshhetToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SaffronUnventedWorkshhetToolStripMenuItem != null)
                {
                    _SaffronUnventedWorkshhetToolStripMenuItem.Click -= SaffronUnventedWorkshhetToolStripMenuItem_Click;
                }

                _SaffronUnventedWorkshhetToolStripMenuItem = value;
                if (_SaffronUnventedWorkshhetToolStripMenuItem != null)
                {
                    _SaffronUnventedWorkshhetToolStripMenuItem.Click += SaffronUnventedWorkshhetToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _PropertyMaintenanceWorksheetToolStripMenuItem;

        internal ToolStripMenuItem PropertyMaintenanceWorksheetToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PropertyMaintenanceWorksheetToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PropertyMaintenanceWorksheetToolStripMenuItem != null)
                {
                    _PropertyMaintenanceWorksheetToolStripMenuItem.Click -= PropertyMaintenanceWorksheetToolStripMenuItem_Click;
                }

                _PropertyMaintenanceWorksheetToolStripMenuItem = value;
                if (_PropertyMaintenanceWorksheetToolStripMenuItem != null)
                {
                    _PropertyMaintenanceWorksheetToolStripMenuItem.Click += PropertyMaintenanceWorksheetToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ASHPWorksheetToolStripMenuItem;

        internal ToolStripMenuItem ASHPWorksheetToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ASHPWorksheetToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ASHPWorksheetToolStripMenuItem != null)
                {
                    _ASHPWorksheetToolStripMenuItem.Click -= ASHPWorksheetToolStripMenuItem_Click;
                }

                _ASHPWorksheetToolStripMenuItem = value;
                if (_ASHPWorksheetToolStripMenuItem != null)
                {
                    _ASHPWorksheetToolStripMenuItem.Click += ASHPWorksheetToolStripMenuItem_Click;
                }
            }
        }

        private ComboBox _cboMeterCapped;

        internal ComboBox cboMeterCapped
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboMeterCapped;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboMeterCapped != null)
                {
                }

                _cboMeterCapped = value;
                if (_cboMeterCapped != null)
                {
                }
            }
        }

        private Label _Label73;

        private ComboBox _cboMeterLocation;

        internal ComboBox cboMeterLocation
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboMeterLocation;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboMeterLocation != null)
                {
                }

                _cboMeterLocation = value;
                if (_cboMeterLocation != null)
                {
                }
            }
        }

        private Label _Label72;

        private Label _Label82;

        private Label _Label78;

        private Label _Label77;

        private TextBox _txtProfitPerc;

        internal TextBox txtProfitPerc
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfitPerc;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfitPerc != null)
                {
                }

                _txtProfitPerc = value;
                if (_txtProfitPerc != null)
                {
                }
            }
        }

        private TextBox _txtProfit;

        internal TextBox txtProfit
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtProfit;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtProfit != null)
                {
                }

                _txtProfit = value;
                if (_txtProfit != null)
                {
                }
            }
        }

        private TextBox _txtCosts;

        internal TextBox txtCosts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtCosts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtCosts != null)
                {
                }

                _txtCosts = value;
                if (_txtCosts != null)
                {
                }
            }
        }

        private TextBox _txtSale;

        internal TextBox txtSale
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSale;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSale != null)
                {
                }

                _txtSale = value;
                if (_txtSale != null)
                {
                }
            }
        }

        private ComboBox _cboDept;

        internal ComboBox cboDept
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboDept;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboDept != null)
                {
                    _cboDept.SelectedIndexChanged -= cboDept_SelectedIndexChanged;
                }

                _cboDept = value;
                if (_cboDept != null)
                {
                    _cboDept.SelectedIndexChanged += cboDept_SelectedIndexChanged;
                }
            }
        }

        private CheckBox _chkShowJobCharges;

        internal CheckBox chkShowJobCharges
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkShowJobCharges;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkShowJobCharges != null)
                {
                    _chkShowJobCharges.CheckedChanged -= chkShowJobCharges_CheckedChanged;
                }

                _chkShowJobCharges = value;
                if (_chkShowJobCharges != null)
                {
                    _chkShowJobCharges.CheckedChanged += chkShowJobCharges_CheckedChanged;
                }
            }
        }

        private TextBox _txtPartProductCost;

        internal TextBox txtPartProductCost
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartProductCost;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartProductCost != null)
                {
                }

                _txtPartProductCost = value;
                if (_txtPartProductCost != null)
                {
                }
            }
        }

        private Label _lblPPTotalCost;

        private TextBox _txtPartsProductTotal;

        internal TextBox txtPartsProductTotal
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartsProductTotal;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartsProductTotal != null)
                {
                    _txtPartsProductTotal.Leave -= txtPartsProductTotal_Leave;
                }

                _txtPartsProductTotal = value;
                if (_txtPartsProductTotal != null)
                {
                    _txtPartsProductTotal.Leave += txtPartsProductTotal_Leave;
                }
            }
        }

        private Label _Label28;

        private GroupBox _GroupBox9;

        private RadioButton _rbStandard;

        private RadioButton _rbSite;

        private Label _lblQuantityWarning;

        internal Label lblQuantityWarning
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblQuantityWarning;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblQuantityWarning != null)
                {
                }

                _lblQuantityWarning = value;
                if (_lblQuantityWarning != null)
                {
                }
            }
        }

        private Button _btnRevertUsed;

        private GroupBox _grpOfficeQC;

        private ComboBox _cboQCJobType;

        internal ComboBox cboQCJobType
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCJobType;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCJobType != null)
                {
                }

                _cboQCJobType = value;
                if (_cboQCJobType != null)
                {
                }
            }
        }

        private Label _lblJobTypeCorrect;

        private GroupBox _grpQCField;

        private Label _lblQCPoorJobNotes;

        private ComboBox _cboQCEngineerPaymentRecieved;

        internal ComboBox cboQCEngineerPaymentRecieved
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCEngineerPaymentRecieved;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCEngineerPaymentRecieved != null)
                {
                }

                _cboQCEngineerPaymentRecieved = value;
                if (_cboQCEngineerPaymentRecieved != null)
                {
                }
            }
        }

        private Label _lblQCEngineerMonies;

        private ComboBox _cboQCPaymentSelection;

        internal ComboBox cboQCPaymentSelection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCPaymentSelection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCPaymentSelection != null)
                {
                }

                _cboQCPaymentSelection = value;
                if (_cboQCPaymentSelection != null)
                {
                }
            }
        }

        private Label _lblQCEngPaymentMethod;

        private ComboBox _cboQCAppliance;

        internal ComboBox cboQCAppliance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCAppliance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCAppliance != null)
                {
                }

                _cboQCAppliance = value;
                if (_cboQCAppliance != null)
                {
                }
            }
        }

        private ComboBox _cboQCPaymentCollection;

        internal ComboBox cboQCPaymentCollection
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCPaymentCollection;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCPaymentCollection != null)
                {
                }

                _cboQCPaymentCollection = value;
                if (_cboQCPaymentCollection != null)
                {
                }
            }
        }

        private Label _lblQCPaymentCollection;

        private ComboBox _cboQCJobUploadTimescale;

        internal ComboBox cboQCJobUploadTimescale
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCJobUploadTimescale;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCJobUploadTimescale != null)
                {
                }

                _cboQCJobUploadTimescale = value;
                if (_cboQCJobUploadTimescale != null)
                {
                }
            }
        }

        private Label _lblQCAppliance;

        private ComboBox _cboQCParts;

        internal ComboBox cboQCParts
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCParts;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCParts != null)
                {
                }

                _cboQCParts = value;
                if (_cboQCParts != null)
                {
                }
            }
        }

        private Label _lblJobUploadTimescale;

        private Label _lblQCParts;

        private ComboBox _cboQCLGSR;

        internal ComboBox cboQCLGSR
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCLGSR;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCLGSR != null)
                {
                }

                _cboQCLGSR = value;
                if (_cboQCLGSR != null)
                {
                }
            }
        }

        private Label _lblQCLGSR;

        private ComboBox _cboQCLabourTime;

        internal ComboBox cboQCLabourTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCLabourTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCLabourTime != null)
                {
                }

                _cboQCLabourTime = value;
                if (_cboQCLabourTime != null)
                {
                }
            }
        }

        private Label _lblQCLabourTime;

        private ComboBox _cboQCPaymentMethod;

        internal ComboBox cboQCPaymentMethod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCPaymentMethod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCPaymentMethod != null)
                {
                }

                _cboQCPaymentMethod = value;
                if (_cboQCPaymentMethod != null)
                {
                }
            }
        }

        private Label _lblPaymentMethod;

        private ComboBox _cboQCOrderNo;

        internal ComboBox cboQCOrderNo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCOrderNo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCOrderNo != null)
                {
                }

                _cboQCOrderNo = value;
                if (_cboQCOrderNo != null)
                {
                }
            }
        }

        private Label _lblOrderNo;

        private ComboBox _cboQCScheduleOfRate;

        internal ComboBox cboQCScheduleOfRate
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCScheduleOfRate;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCScheduleOfRate != null)
                {
                }

                _cboQCScheduleOfRate = value;
                if (_cboQCScheduleOfRate != null)
                {
                }
            }
        }

        private Label _lblScheduleRate;

        private ComboBox _cboQCCustomerDetails;

        internal ComboBox cboQCCustomerDetails
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCCustomerDetails;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCCustomerDetails != null)
                {
                }

                _cboQCCustomerDetails = value;
                if (_cboQCCustomerDetails != null)
                {
                }
            }
        }

        private Label _lblCustomerDetails;

        private DateTimePicker _dtpQCDocumentsRecieved;

        internal DateTimePicker dtpQCDocumentsRecieved
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dtpQCDocumentsRecieved;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dtpQCDocumentsRecieved != null)
                {
                }

                _dtpQCDocumentsRecieved = value;
                if (_dtpQCDocumentsRecieved != null)
                {
                }
            }
        }

        private CheckBox _chkQCDocumentsRecieved;

        internal CheckBox chkQCDocumentsRecieved
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkQCDocumentsRecieved;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkQCDocumentsRecieved != null)
                {
                    _chkQCDocumentsRecieved.CheckedChanged -= chkQCDocumentsRecieved_CheckedChanged;
                }

                _chkQCDocumentsRecieved = value;
                if (_chkQCDocumentsRecieved != null)
                {
                    _chkQCDocumentsRecieved.CheckedChanged += chkQCDocumentsRecieved_CheckedChanged;
                }
            }
        }

        private TextBox _txtQCPoorJobNotes;

        internal TextBox txtQCPoorJobNotes
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtQCPoorJobNotes;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtQCPoorJobNotes != null)
                {
                }

                _txtQCPoorJobNotes = value;
                if (_txtQCPoorJobNotes != null)
                {
                }
            }
        }

        private Button _btnUnselectAllPPA;

        private Button _btnSelectAllPPA;

        private GroupBox _grpSiteFuels;

        private DataGrid _dgSiteFuel;

        internal DataGrid dgSiteFuel
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dgSiteFuel;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dgSiteFuel != null)
                {
                    _dgSiteFuel.Click -= dgSiteFuel_Click;
                }

                _dgSiteFuel = value;
                if (_dgSiteFuel != null)
                {
                    _dgSiteFuel.Click += dgSiteFuel_Click;
                }
            }
        }

        private TextBox _txtActualTimeSpent;

        internal TextBox txtActualTimeSpent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtActualTimeSpent;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtActualTimeSpent != null)
                {
                }

                _txtActualTimeSpent = value;
                if (_txtActualTimeSpent != null)
                {
                }
            }
        }

        private TextBox _txtDifference;

        internal TextBox txtDifference
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDifference;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDifference != null)
                {
                }

                _txtDifference = value;
                if (_txtDifference != null)
                {
                }
            }
        }

        private TextBox _txtSORTimeAllowance;

        internal TextBox txtSORTimeAllowance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtSORTimeAllowance;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtSORTimeAllowance != null)
                {
                }

                _txtSORTimeAllowance = value;
                if (_txtSORTimeAllowance != null)
                {
                }
            }
        }

        private Label _Label52;

        private Label _Label51;

        private Label _Label50;

        private ComboBox _cboRecallEngineer;

        internal ComboBox cboRecallEngineer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRecallEngineer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRecallEngineer != null)
                {
                }

                _cboRecallEngineer = value;
                if (_cboRecallEngineer != null)
                {
                }
            }
        }

        private Label _Label49;

        private ComboBox _cboRecall;

        internal ComboBox cboRecall
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboRecall;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboRecall != null)
                {
                    _cboRecall.SelectedIndexChanged -= cboRecall_SelectedIndexChanged;
                }

                _cboRecall = value;
                if (_cboRecall != null)
                {
                    _cboRecall.SelectedIndexChanged += cboRecall_SelectedIndexChanged;
                }
            }
        }

        private Label _Label48;

        private ComboBox _cboQCCustSig;

        internal ComboBox cboQCCustSig
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cboQCCustSig;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cboQCCustSig != null)
                {
                }

                _cboQCCustSig = value;
                if (_cboQCCustSig != null)
                {
                }
            }
        }

        private Label _lblQCCustSig;

        private ToolStripMenuItem _CommissioningChecklistToolStripMenuItem;

        internal ToolStripMenuItem CommissioningChecklistToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _CommissioningChecklistToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_CommissioningChecklistToolStripMenuItem != null)
                {
                    _CommissioningChecklistToolStripMenuItem.Click -= CommissioningChecklistToolStripMenuItem_Click;
                }

                _CommissioningChecklistToolStripMenuItem = value;
                if (_CommissioningChecklistToolStripMenuItem != null)
                {
                    _CommissioningChecklistToolStripMenuItem.Click += CommissioningChecklistToolStripMenuItem_Click;
                }
            }
        }

        private CheckBox _chkPartsSelectAll;

        internal CheckBox chkPartsSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkPartsSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkPartsSelectAll != null)
                {
                    _chkPartsSelectAll.Click -= chkPartsSelectAll_Click;
                }

                _chkPartsSelectAll = value;
                if (_chkPartsSelectAll != null)
                {
                    _chkPartsSelectAll.Click += chkPartsSelectAll_Click;
                }
            }
        }

        private TextBox _txtPartsMarkUp;

        internal TextBox txtPartsMarkUp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtPartsMarkUp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtPartsMarkUp != null)
                {
                    _txtPartsMarkUp.Leave -= txtPartsMarkUp_Leave;
                }

                _txtPartsMarkUp = value;
                if (_txtPartsMarkUp != null)
                {
                    _txtPartsMarkUp.Leave += txtPartsMarkUp_Leave;
                }
            }
        }

        private CheckBox _chkTimesheetSelectAll;

        internal CheckBox chkTimesheetSelectAll
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkTimesheetSelectAll;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkTimesheetSelectAll != null)
                {
                    _chkTimesheetSelectAll.Click -= chkTimesheetSelectAll_Click;
                }

                _chkTimesheetSelectAll = value;
                if (_chkTimesheetSelectAll != null)
                {
                    _chkTimesheetSelectAll.Click += chkTimesheetSelectAll_Click;
                }
            }
        }

        private Label _lblPartsMarkUp;

        internal Label lblPartsMarkUp
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _lblPartsMarkUp;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_lblPartsMarkUp != null)
                {
                }

                _lblPartsMarkUp = value;
                if (_lblPartsMarkUp != null)
                {
                }
            }
        }

        private Label _lblAdditionalCharge;

        private ToolStripMenuItem _HotWorksPermitToolStripMenuItem;

        internal ToolStripMenuItem HotWorksPermitToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _HotWorksPermitToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_HotWorksPermitToolStripMenuItem != null)
                {
                    _HotWorksPermitToolStripMenuItem.Click -= HotWorksPermitToolStripMenuItem_Click;
                }

                _HotWorksPermitToolStripMenuItem = value;
                if (_HotWorksPermitToolStripMenuItem != null)
                {
                    _HotWorksPermitToolStripMenuItem.Click += HotWorksPermitToolStripMenuItem_Click;
                }
            }
        }

        private Button _btnAddApplianceWorksheet;

        internal Button btnAddApplianceWorksheet
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAddApplianceWorksheet;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAddApplianceWorksheet != null)
                {
                    _btnAddApplianceWorksheet.Click -= btnAddApplianceWorksheet_Click;
                }

                _btnAddApplianceWorksheet = value;
                if (_btnAddApplianceWorksheet != null)
                {
                    _btnAddApplianceWorksheet.Click += btnAddApplianceWorksheet_Click;
                }
            }
        }

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._tcWorkSheet = new System.Windows.Forms.TabControl();
            this._tpMainDetails = new System.Windows.Forms.TabPage();
            this._chkSORDesc = new System.Windows.Forms.CheckBox();
            this._btnEditInvoiceNotes = new System.Windows.Forms.Button();
            this._txtScheduledTime2 = new System.Windows.Forms.TextBox();
            this._Label71 = new System.Windows.Forms.Label();
            this._btnChangeOutcome = new System.Windows.Forms.Button();
            this._pbCustomerSignature = new System.Windows.Forms.PictureBox();
            this._pbEngineerSignature = new System.Windows.Forms.PictureBox();
            this._cbxEmailReceiptToCustomer = new System.Windows.Forms.CheckBox();
            this._cboSignatureSelected = new System.Windows.Forms.ComboBox();
            this._Label42 = new System.Windows.Forms.Label();
            this._dgJobItems = new System.Windows.Forms.DataGrid();
            this._Label12 = new System.Windows.Forms.Label();
            this._txtNotesToEngineer = new System.Windows.Forms.TextBox();
            this._Label6 = new System.Windows.Forms.Label();
            this._txtCustomer = new System.Windows.Forms.TextBox();
            this._cboEngineer = new System.Windows.Forms.ComboBox();
            this._txtNotesFromEngineer = new System.Windows.Forms.TextBox();
            this._cboOutcome = new System.Windows.Forms.ComboBox();
            this._txtOutcomeDetails = new System.Windows.Forms.TextBox();
            this._Label11 = new System.Windows.Forms.Label();
            this._txtUploadedBy = new System.Windows.Forms.TextBox();
            this._txtStatus = new System.Windows.Forms.TextBox();
            this._Label9 = new System.Windows.Forms.Label();
            this._Label5 = new System.Windows.Forms.Label();
            this._Label4 = new System.Windows.Forms.Label();
            this._Label3 = new System.Windows.Forms.Label();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._tpAppliances = new System.Windows.Forms.TabPage();
            this._gpAppliances = new System.Windows.Forms.GroupBox();
            this._dgAssets = new System.Windows.Forms.DataGrid();
            this._tpWorksheets = new System.Windows.Forms.TabPage();
            this._grpAdditionalWorksheet = new System.Windows.Forms.GroupBox();
            this._btnRemoveAdd = new System.Windows.Forms.Button();
            this._btnAddAdd = new System.Windows.Forms.Button();
            this._dgAdditional = new System.Windows.Forms.DataGrid();
            this._grpAlarmInfo = new System.Windows.Forms.GroupBox();
            this._btnRemoveSmokeComo = new System.Windows.Forms.Button();
            this._btnAddSmokeComo = new System.Windows.Forms.Button();
            this._DGSmokeComo = new System.Windows.Forms.DataGrid();
            this._grpVisitWorksheetExtended = new System.Windows.Forms.GroupBox();
            this._cboSITimer = new System.Windows.Forms.ComboBox();
            this._cboFillDisc = new System.Windows.Forms.ComboBox();
            this._Label81 = new System.Windows.Forms.Label();
            this._Label80 = new System.Windows.Forms.Label();
            this._Label79 = new System.Windows.Forms.Label();
            this._txtRadiators = new System.Windows.Forms.TextBox();
            this._txtVisualInspectionReason = new System.Windows.Forms.TextBox();
            this._Label68 = new System.Windows.Forms.Label();
            this._Label69 = new System.Windows.Forms.Label();
            this._Label70 = new System.Windows.Forms.Label();
            this._Label62 = new System.Windows.Forms.Label();
            this._Label63 = new System.Windows.Forms.Label();
            this._Label64 = new System.Windows.Forms.Label();
            this._Label65 = new System.Windows.Forms.Label();
            this._Label66 = new System.Windows.Forms.Label();
            this._Label67 = new System.Windows.Forms.Label();
            this._cboCertificateTypeID = new System.Windows.Forms.ComboBox();
            this._cboCODetectorFittedID = new System.Windows.Forms.ComboBox();
            this._cboVisualInspectionSatisfactoryID = new System.Windows.Forms.ComboBox();
            this._cboImmersionID = new System.Windows.Forms.ComboBox();
            this._cboJacketID = new System.Windows.Forms.ComboBox();
            this._cboCylinderTypeID = new System.Windows.Forms.ComboBox();
            this._cboPartialHeatingID = new System.Windows.Forms.ComboBox();
            this._cboHeatingSystemTypeID = new System.Windows.Forms.ComboBox();
            this._txtApproxAgeOfBoiler = new System.Windows.Forms.TextBox();
            this._cboStrainerInspectedID = new System.Windows.Forms.ComboBox();
            this._Label56 = new System.Windows.Forms.Label();
            this._Label57 = new System.Windows.Forms.Label();
            this._cboStrainerFittedID = new System.Windows.Forms.ComboBox();
            this._cboInstallationSafeToUseID = new System.Windows.Forms.ComboBox();
            this._cboInstallationPipeWorkCorrectID = new System.Windows.Forms.ComboBox();
            this._cboCorrectMaterialsUsedID = new System.Windows.Forms.ComboBox();
            this._Label58 = new System.Windows.Forms.Label();
            this._Label59 = new System.Windows.Forms.Label();
            this._Label60 = new System.Windows.Forms.Label();
            this._Label61 = new System.Windows.Forms.Label();
            this._grpVisitDefects = new System.Windows.Forms.GroupBox();
            this._btnAddVisitDefect = new System.Windows.Forms.Button();
            this._btnRemoveVisitDefect = new System.Windows.Forms.Button();
            this._dgVisitDefects = new System.Windows.Forms.DataGrid();
            this._grpApplianceWorksheet = new System.Windows.Forms.GroupBox();
            this._btnRemoveApplianceWorkSheet = new System.Windows.Forms.Button();
            this._dgApplianceWorkSheets = new System.Windows.Forms.DataGrid();
            this._btnAddApplianceWorksheet = new System.Windows.Forms.Button();
            this._grpVisitWorksheet = new System.Windows.Forms.GroupBox();
            this._cboMeterCapped = new System.Windows.Forms.ComboBox();
            this._Label73 = new System.Windows.Forms.Label();
            this._cboMeterLocation = new System.Windows.Forms.ComboBox();
            this._Label72 = new System.Windows.Forms.Label();
            this._txtAmountCollected = new System.Windows.Forms.TextBox();
            this._cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this._Label44 = new System.Windows.Forms.Label();
            this._Label43 = new System.Windows.Forms.Label();
            this._cboPropertyRented = new System.Windows.Forms.ComboBox();
            this._cboBonding = new System.Windows.Forms.ComboBox();
            this._cboEmergencyControlAccessible = new System.Windows.Forms.ComboBox();
            this._cboGasInstallationTightnessTest = new System.Windows.Forms.ComboBox();
            this._Label41 = new System.Windows.Forms.Label();
            this._Label40 = new System.Windows.Forms.Label();
            this._Label8 = new System.Windows.Forms.Label();
            this._Label7 = new System.Windows.Forms.Label();
            this._tpTimesheets = new System.Windows.Forms.TabPage();
            this._grpTimesheets = new System.Windows.Forms.GroupBox();
            this._txtActualTimeSpent = new System.Windows.Forms.TextBox();
            this._txtDifference = new System.Windows.Forms.TextBox();
            this._txtSORTimeAllowance = new System.Windows.Forms.TextBox();
            this._Label52 = new System.Windows.Forms.Label();
            this._Label51 = new System.Windows.Forms.Label();
            this._Label50 = new System.Windows.Forms.Label();
            this._Label22 = new System.Windows.Forms.Label();
            this._cboTimeSheetType = new System.Windows.Forms.ComboBox();
            this._Label14 = new System.Windows.Forms.Label();
            this._txtComments = new System.Windows.Forms.TextBox();
            this._dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this._dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this._dgTimeSheets = new System.Windows.Forms.DataGrid();
            this._btnAddTimeSheet = new System.Windows.Forms.Button();
            this._Label20 = new System.Windows.Forms.Label();
            this._Label21 = new System.Windows.Forms.Label();
            this._btnRemoveTimeSheet = new System.Windows.Forms.Button();
            this._txtScheduledTime = new System.Windows.Forms.TextBox();
            this._Label10 = new System.Windows.Forms.Label();
            this._tpPartsAndProducts = new System.Windows.Forms.TabPage();
            this._grpAllocated = new System.Windows.Forms.GroupBox();
            this._btnUnselectAllPPA = new System.Windows.Forms.Button();
            this._btnSelectAllPPA = new System.Windows.Forms.Button();
            this._btnRevertUsed = new System.Windows.Forms.Button();
            this._nudPartAllocatedQty = new System.Windows.Forms.NumericUpDown();
            this._lblAllocatedQuantity = new System.Windows.Forms.Label();
            this._btnAllUsed = new System.Windows.Forms.Button();
            this._Label35 = new System.Windows.Forms.Label();
            this._Panel2 = new System.Windows.Forms.Panel();
            this._Label34 = new System.Windows.Forms.Label();
            this._Panel1 = new System.Windows.Forms.Panel();
            this._btnAllocatedNotUsed = new System.Windows.Forms.Button();
            this._dgPartsProductsAllocated = new System.Windows.Forms.DataGrid();
            this._lblQuantityWarning = new System.Windows.Forms.Label();
            this._grpUsed = new System.Windows.Forms.GroupBox();
            this._lblEquipment = new System.Windows.Forms.Label();
            this._lblSellPrice = new System.Windows.Forms.Label();
            this._dgPartsAndProductsUsed = new System.Windows.Forms.DataGrid();
            this._btnAddPartProductUsed = new System.Windows.Forms.Button();
            this._nudQuantityUsed = new System.Windows.Forms.NumericUpDown();
            this._txtNameUsed = new System.Windows.Forms.TextBox();
            this._txtNumberUsed = new System.Windows.Forms.TextBox();
            this._Label13 = new System.Windows.Forms.Label();
            this._Label15 = new System.Windows.Forms.Label();
            this._Label16 = new System.Windows.Forms.Label();
            this._btnRemovePartProductUsed = new System.Windows.Forms.Button();
            this._btnFindProductUsed = new System.Windows.Forms.Button();
            this._btnFindPartUsed = new System.Windows.Forms.Button();
            this._tpOutcomes = new System.Windows.Forms.TabPage();
            this._grpOutcomes = new System.Windows.Forms.GroupBox();
            this._grpSiteFuels = new System.Windows.Forms.GroupBox();
            this._dgSiteFuel = new System.Windows.Forms.DataGrid();
            this._cboNccRad = new System.Windows.Forms.ComboBox();
            this._Label76 = new System.Windows.Forms.Label();
            this._cboRecharge = new System.Windows.Forms.ComboBox();
            this._Label75 = new System.Windows.Forms.Label();
            this._chkRecharge = new System.Windows.Forms.CheckBox();
            this._chkGasServiceCompleted = new System.Windows.Forms.CheckBox();
            this._tpQC = new System.Windows.Forms.TabPage();
            this._GroupBox4 = new System.Windows.Forms.GroupBox();
            this._grpQCField = new System.Windows.Forms.GroupBox();
            this._cboQCCustSig = new System.Windows.Forms.ComboBox();
            this._lblQCCustSig = new System.Windows.Forms.Label();
            this._cboRecallEngineer = new System.Windows.Forms.ComboBox();
            this._Label49 = new System.Windows.Forms.Label();
            this._cboRecall = new System.Windows.Forms.ComboBox();
            this._Label48 = new System.Windows.Forms.Label();
            this._dtpQCDocumentsRecieved = new System.Windows.Forms.DateTimePicker();
            this._chkQCDocumentsRecieved = new System.Windows.Forms.CheckBox();
            this._txtQCPoorJobNotes = new System.Windows.Forms.TextBox();
            this._lblQCPoorJobNotes = new System.Windows.Forms.Label();
            this._cboQCEngineerPaymentRecieved = new System.Windows.Forms.ComboBox();
            this._lblQCEngineerMonies = new System.Windows.Forms.Label();
            this._cboQCPaymentSelection = new System.Windows.Forms.ComboBox();
            this._lblQCEngPaymentMethod = new System.Windows.Forms.Label();
            this._cboQCAppliance = new System.Windows.Forms.ComboBox();
            this._cboQCPaymentCollection = new System.Windows.Forms.ComboBox();
            this._lblQCPaymentCollection = new System.Windows.Forms.Label();
            this._cboQCJobUploadTimescale = new System.Windows.Forms.ComboBox();
            this._lblQCAppliance = new System.Windows.Forms.Label();
            this._cboQCParts = new System.Windows.Forms.ComboBox();
            this._lblJobUploadTimescale = new System.Windows.Forms.Label();
            this._lblQCParts = new System.Windows.Forms.Label();
            this._cboQCLGSR = new System.Windows.Forms.ComboBox();
            this._lblQCLGSR = new System.Windows.Forms.Label();
            this._cboQCLabourTime = new System.Windows.Forms.ComboBox();
            this._lblQCLabourTime = new System.Windows.Forms.Label();
            this._grpOfficeQC = new System.Windows.Forms.GroupBox();
            this._cboQCPaymentMethod = new System.Windows.Forms.ComboBox();
            this._lblPaymentMethod = new System.Windows.Forms.Label();
            this._cboQCOrderNo = new System.Windows.Forms.ComboBox();
            this._lblOrderNo = new System.Windows.Forms.Label();
            this._cboQCScheduleOfRate = new System.Windows.Forms.ComboBox();
            this._lblScheduleRate = new System.Windows.Forms.Label();
            this._cboQCCustomerDetails = new System.Windows.Forms.ComboBox();
            this._lblCustomerDetails = new System.Windows.Forms.Label();
            this._cboQCJobType = new System.Windows.Forms.ComboBox();
            this._lblJobTypeCorrect = new System.Windows.Forms.Label();
            this._cboFTFCode = new System.Windows.Forms.ComboBox();
            this._Label74 = new System.Windows.Forms.Label();
            this._tpCharges = new System.Windows.Forms.TabPage();
            this._gpbInvoice = new System.Windows.Forms.GroupBox();
            this._cboDept = new System.Windows.Forms.ComboBox();
            this._btnCreateServ = new System.Windows.Forms.Button();
            this._txtInvAmount = new System.Windows.Forms.TextBox();
            this._txtCreditAmount = new System.Windows.Forms.TextBox();
            this._txtInvNo = new System.Windows.Forms.TextBox();
            this._cboPaidBy = new System.Windows.Forms.ComboBox();
            this._cboInvType = new System.Windows.Forms.ComboBox();
            this._cboVATRate = new System.Windows.Forms.ComboBox();
            this._txtPriceIncVAT = new System.Windows.Forms.TextBox();
            this._txtAccountCode = new System.Windows.Forms.TextBox();
            this._lblInvoiceAddressDetails = new System.Windows.Forms.Label();
            this._txtNominalCode = new System.Windows.Forms.TextBox();
            this._btnSearch = new System.Windows.Forms.Button();
            this._dtpRaiseInvoiceOn = new System.Windows.Forms.DateTimePicker();
            this._cbxReadyToBeInvoiced = new System.Windows.Forms.CheckBox();
            this._lblInvAmount = new System.Windows.Forms.Label();
            this._lblcredit = new System.Windows.Forms.Label();
            this._lblInvNo = new System.Windows.Forms.Label();
            this._lblPaidBy = new System.Windows.Forms.Label();
            this._lblInvType = new System.Windows.Forms.Label();
            this._lblVAT = new System.Windows.Forms.Label();
            this._lblNominalCode = new System.Windows.Forms.Label();
            this._lblAccountCode = new System.Windows.Forms.Label();
            this._lblPriceInvVAT = new System.Windows.Forms.Label();
            this._lblDepartment = new System.Windows.Forms.Label();
            this._lblRaiseInvoiceOn = new System.Windows.Forms.Label();
            this._gpbCharges = new System.Windows.Forms.GroupBox();
            this._chkShowJobCharges = new System.Windows.Forms.CheckBox();
            this._GroupBox6 = new System.Windows.Forms.GroupBox();
            this._Label82 = new System.Windows.Forms.Label();
            this._Label78 = new System.Windows.Forms.Label();
            this._Label77 = new System.Windows.Forms.Label();
            this._txtProfitPerc = new System.Windows.Forms.TextBox();
            this._txtProfit = new System.Windows.Forms.TextBox();
            this._CostsToOption1 = new System.Windows.Forms.RadioButton();
            this._txtCosts = new System.Windows.Forms.TextBox();
            this._CostsToOption3 = new System.Windows.Forms.RadioButton();
            this._txtSale = new System.Windows.Forms.TextBox();
            this._CostsToOption2 = new System.Windows.Forms.RadioButton();
            this._lblContractPerVisit = new System.Windows.Forms.Label();
            this._lblOR = new System.Windows.Forms.Label();
            this._Label30 = new System.Windows.Forms.Label();
            this._lblQuotePercentageTotal = new System.Windows.Forms.Label();
            this._lblEquals = new System.Windows.Forms.Label();
            this._GroupBox9 = new System.Windows.Forms.GroupBox();
            this._rbStandard = new System.Windows.Forms.RadioButton();
            this._rbSite = new System.Windows.Forms.RadioButton();
            this._lblPercent = new System.Windows.Forms.Label();
            this._txtPercentOfQuote = new System.Windows.Forms.TextBox();
            this._rdoPercentageOfQuoteValue = new System.Windows.Forms.RadioButton();
            this._txtCharge = new System.Windows.Forms.TextBox();
            this._rdoChargeOther = new System.Windows.Forms.RadioButton();
            this._rdoJobValue = new System.Windows.Forms.RadioButton();
            this._txtJobValue = new System.Windows.Forms.TextBox();
            this._gpbAdditionalCharges = new System.Windows.Forms.GroupBox();
            this._lblAdditionalCharge = new System.Windows.Forms.Label();
            this._btnAddAdditionalCharge = new System.Windows.Forms.Button();
            this._txtAdditionalCharge = new System.Windows.Forms.TextBox();
            this._btnRemoveAdditionalCharge = new System.Windows.Forms.Button();
            this._txtAdditionalChargeDescription = new System.Windows.Forms.TextBox();
            this._lblDescription = new System.Windows.Forms.Label();
            this._txtAdditionalChargeTotal = new System.Windows.Forms.TextBox();
            this._Label29 = new System.Windows.Forms.Label();
            this._dgAdditionalCharges = new System.Windows.Forms.DataGrid();
            this._gpbPartsAndProducts = new System.Windows.Forms.GroupBox();
            this._txtPartsMarkUp = new System.Windows.Forms.TextBox();
            this._chkPartsSelectAll = new System.Windows.Forms.CheckBox();
            this._txtPartProductCost = new System.Windows.Forms.TextBox();
            this._txtPartsProductTotal = new System.Windows.Forms.TextBox();
            this._Label28 = new System.Windows.Forms.Label();
            this._lblPPTotalCost = new System.Windows.Forms.Label();
            this._lblPartsMarkUp = new System.Windows.Forms.Label();
            this._dgPartsProductCharging = new System.Windows.Forms.DataGrid();
            this._gpbTimesheets = new System.Windows.Forms.GroupBox();
            this._chkTimesheetSelectAll = new System.Windows.Forms.CheckBox();
            this._txtEngineerCostTotal = new System.Windows.Forms.TextBox();
            this._txtTimesheetTotal = new System.Windows.Forms.TextBox();
            this._Label27 = new System.Windows.Forms.Label();
            this._Label32 = new System.Windows.Forms.Label();
            this._dgTimesheetCharges = new System.Windows.Forms.DataGrid();
            this._gpbScheduleOfRates = new System.Windows.Forms.GroupBox();
            this._btnAddSoR = new System.Windows.Forms.Button();
            this._txtScheduleOfRatesTotal = new System.Windows.Forms.TextBox();
            this._dgScheduleOfRateCharges = new System.Windows.Forms.DataGrid();
            this._Label26 = new System.Windows.Forms.Label();
            this._tpDocuments = new System.Windows.Forms.TabPage();
            this._tpPhotos = new System.Windows.Forms.TabPage();
            this._flPhotos = new System.Windows.Forms.FlowLayoutPanel();
            this._btnClose = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this._mnuAddChecklist = new System.Windows.Forms.ContextMenu();
            this._cbxVisitLockDown = new System.Windows.Forms.CheckBox();
            this._lblStatusWarning = new System.Windows.Forms.Label();
            this._btnOrders = new System.Windows.Forms.Button();
            this._btnInvoice = new System.Windows.Forms.Button();
            this._btnPrint = new System.Windows.Forms.Button();
            this._PrintMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._mnuGasSafetyInspectionBoilerServiceRecord = new System.Windows.Forms.ToolStripMenuItem();
            this._txtCurrentContract = new System.Windows.Forms.TextBox();
            this._Label39 = new System.Windows.Forms.Label();
            this._btnPrintGSR = new System.Windows.Forms.Button();
            this._btnPrintSVR = new System.Windows.Forms.Button();
            this._btnJob = new System.Windows.Forms.Button();
            this._lblRechargeTicked = new System.Windows.Forms.Label();
            this._btnShowVisits = new System.Windows.Forms.Button();
            this._BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this._TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this._RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this._LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this._ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this._Button1 = new System.Windows.Forms.Button();
            this._txtCustEmail = new System.Windows.Forms.TextBox();
            this._SVRs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._AllGasPaperworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._svrmenu = new System.Windows.Forms.ToolStripMenuItem();
            this._JobSheetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._DomesticGSRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._WarningNoticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._CommercialGSRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._QCResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ElectricalMinorWorksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._CommercialCateringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._SaffronUnventedWorkshhetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._PropertyMaintenanceWorksheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ASHPWorksheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._CommissioningChecklistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._HotWorksPermitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tcWorkSheet.SuspendLayout();
            this._tpMainDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._pbCustomerSignature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this._pbEngineerSignature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this._dgJobItems).BeginInit();
            this._tpAppliances.SuspendLayout();
            this._gpAppliances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgAssets).BeginInit();
            this._tpWorksheets.SuspendLayout();
            this._grpAdditionalWorksheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgAdditional).BeginInit();
            this._grpAlarmInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._DGSmokeComo).BeginInit();
            this._grpVisitWorksheetExtended.SuspendLayout();
            this._grpVisitDefects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgVisitDefects).BeginInit();
            this._grpApplianceWorksheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgApplianceWorkSheets).BeginInit();
            this._grpVisitWorksheet.SuspendLayout();
            this._tpTimesheets.SuspendLayout();
            this._grpTimesheets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgTimeSheets).BeginInit();
            this._tpPartsAndProducts.SuspendLayout();
            this._grpAllocated.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._nudPartAllocatedQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this._dgPartsProductsAllocated).BeginInit();
            this._grpUsed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgPartsAndProductsUsed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this._nudQuantityUsed).BeginInit();
            this._tpOutcomes.SuspendLayout();
            this._grpOutcomes.SuspendLayout();
            this._grpSiteFuels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgSiteFuel).BeginInit();
            this._tpQC.SuspendLayout();
            this._GroupBox4.SuspendLayout();
            this._grpQCField.SuspendLayout();
            this._grpOfficeQC.SuspendLayout();
            this._tpCharges.SuspendLayout();
            this._gpbInvoice.SuspendLayout();
            this._gpbCharges.SuspendLayout();
            this._GroupBox6.SuspendLayout();
            this._GroupBox9.SuspendLayout();
            this._gpbAdditionalCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgAdditionalCharges).BeginInit();
            this._gpbPartsAndProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgPartsProductCharging).BeginInit();
            this._gpbTimesheets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgTimesheetCharges).BeginInit();
            this._gpbScheduleOfRates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgScheduleOfRateCharges).BeginInit();
            this._tpPhotos.SuspendLayout();
            this._PrintMenu.SuspendLayout();
            this._SVRs.SuspendLayout();
            this.SuspendLayout();
            //
            // _tcWorkSheet
            //
            this._tcWorkSheet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._tcWorkSheet.Controls.Add(this._tpMainDetails);
            this._tcWorkSheet.Controls.Add(this._tpAppliances);
            this._tcWorkSheet.Controls.Add(this._tpWorksheets);
            this._tcWorkSheet.Controls.Add(this._tpTimesheets);
            this._tcWorkSheet.Controls.Add(this._tpPartsAndProducts);
            this._tcWorkSheet.Controls.Add(this._tpOutcomes);
            this._tcWorkSheet.Controls.Add(this._tpQC);
            this._tcWorkSheet.Controls.Add(this._tpCharges);
            this._tcWorkSheet.Controls.Add(this._tpDocuments);
            this._tcWorkSheet.Controls.Add(this._tpPhotos);
            this._tcWorkSheet.Location = new System.Drawing.Point(0, 64);
            this._tcWorkSheet.Name = "_tcWorkSheet";
            this._tcWorkSheet.SelectedIndex = 0;
            this._tcWorkSheet.Size = new System.Drawing.Size(1255, 678);
            this._tcWorkSheet.TabIndex = 1;
            //
            // _tpMainDetails
            //
            this._tpMainDetails.Controls.Add(this._chkSORDesc);
            this._tpMainDetails.Controls.Add(this._btnEditInvoiceNotes);
            this._tpMainDetails.Controls.Add(this._txtScheduledTime2);
            this._tpMainDetails.Controls.Add(this._Label71);
            this._tpMainDetails.Controls.Add(this._btnChangeOutcome);
            this._tpMainDetails.Controls.Add(this._pbCustomerSignature);
            this._tpMainDetails.Controls.Add(this._pbEngineerSignature);
            this._tpMainDetails.Controls.Add(this._cbxEmailReceiptToCustomer);
            this._tpMainDetails.Controls.Add(this._cboSignatureSelected);
            this._tpMainDetails.Controls.Add(this._Label42);
            this._tpMainDetails.Controls.Add(this._dgJobItems);
            this._tpMainDetails.Controls.Add(this._Label12);
            this._tpMainDetails.Controls.Add(this._txtNotesToEngineer);
            this._tpMainDetails.Controls.Add(this._Label6);
            this._tpMainDetails.Controls.Add(this._txtCustomer);
            this._tpMainDetails.Controls.Add(this._cboEngineer);
            this._tpMainDetails.Controls.Add(this._txtNotesFromEngineer);
            this._tpMainDetails.Controls.Add(this._cboOutcome);
            this._tpMainDetails.Controls.Add(this._txtOutcomeDetails);
            this._tpMainDetails.Controls.Add(this._Label11);
            this._tpMainDetails.Controls.Add(this._txtUploadedBy);
            this._tpMainDetails.Controls.Add(this._txtStatus);
            this._tpMainDetails.Controls.Add(this._Label9);
            this._tpMainDetails.Controls.Add(this._Label5);
            this._tpMainDetails.Controls.Add(this._Label4);
            this._tpMainDetails.Controls.Add(this._Label3);
            this._tpMainDetails.Controls.Add(this._Label2);
            this._tpMainDetails.Controls.Add(this._Label1);
            this._tpMainDetails.Location = new System.Drawing.Point(4, 22);
            this._tpMainDetails.Name = "_tpMainDetails";
            this._tpMainDetails.Size = new System.Drawing.Size(1247, 652);
            this._tpMainDetails.TabIndex = 0;
            this._tpMainDetails.Text = "Main Details";
            this._tpMainDetails.UseVisualStyleBackColor = true;
            //
            // _chkSORDesc
            //
            this._chkSORDesc.AutoSize = true;
            this._chkSORDesc.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this._chkSORDesc.Location = new System.Drawing.Point(128, 413);
            this._chkSORDesc.Name = "_chkSORDesc";
            this._chkSORDesc.Size = new System.Drawing.Size(394, 30);
            this._chkSORDesc.TabIndex = 35;
            this._chkSORDesc.Text = "Use SOR Descriptions for Invoice";
            this._chkSORDesc.UseVisualStyleBackColor = true;
            this._chkSORDesc.CheckedChanged += new System.EventHandler(this.chkSORDesc_CheckedChanged);
            //
            // _btnEditInvoiceNotes
            //
            this._btnEditInvoiceNotes.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnEditInvoiceNotes.Location = new System.Drawing.Point(11, 384);
            this._btnEditInvoiceNotes.Name = "_btnEditInvoiceNotes";
            this._btnEditInvoiceNotes.Size = new System.Drawing.Size(97, 23);
            this._btnEditInvoiceNotes.TabIndex = 34;
            this._btnEditInvoiceNotes.Text = "Edit Inv Notes";
            this._btnEditInvoiceNotes.Visible = false;
            this._btnEditInvoiceNotes.Click += new System.EventHandler(this.btnEditInvoiceNotes_Click);
            //
            // _txtScheduledTime2
            //
            this._txtScheduledTime2.Location = new System.Drawing.Point(128, 204);
            this._txtScheduledTime2.Name = "_txtScheduledTime2";
            this._txtScheduledTime2.ReadOnly = true;
            this._txtScheduledTime2.Size = new System.Drawing.Size(510, 21);
            this._txtScheduledTime2.TabIndex = 32;
            //
            // _Label71
            //
            this._Label71.Location = new System.Drawing.Point(8, 207);
            this._Label71.Name = "_Label71";
            this._Label71.Size = new System.Drawing.Size(104, 16);
            this._Label71.TabIndex = 33;
            this._Label71.Text = "Scheduled";
            //
            // _btnChangeOutcome
            //
            this._btnChangeOutcome.Location = new System.Drawing.Point(128, 171);
            this._btnChangeOutcome.Name = "_btnChangeOutcome";
            this._btnChangeOutcome.Size = new System.Drawing.Size(114, 23);
            this._btnChangeOutcome.TabIndex = 31;
            this._btnChangeOutcome.Text = "Change Outcome";
            this._btnChangeOutcome.UseVisualStyleBackColor = true;
            this._btnChangeOutcome.Click += new System.EventHandler(this.btnChangeOutcome_Click);
            //
            // _pbCustomerSignature
            //
            this._pbCustomerSignature.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._pbCustomerSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pbCustomerSignature.Location = new System.Drawing.Point(647, 207);
            this._pbCustomerSignature.Name = "_pbCustomerSignature";
            this._pbCustomerSignature.Size = new System.Drawing.Size(592, 119);
            this._pbCustomerSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pbCustomerSignature.TabIndex = 30;
            this._pbCustomerSignature.TabStop = false;
            //
            // _pbEngineerSignature
            //
            this._pbEngineerSignature.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._pbEngineerSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pbEngineerSignature.Location = new System.Drawing.Point(647, 44);
            this._pbEngineerSignature.Name = "_pbEngineerSignature";
            this._pbEngineerSignature.Size = new System.Drawing.Size(592, 121);
            this._pbEngineerSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pbEngineerSignature.TabIndex = 29;
            this._pbEngineerSignature.TabStop = false;
            //
            // _cbxEmailReceiptToCustomer
            //
            this._cbxEmailReceiptToCustomer.AutoSize = true;
            this._cbxEmailReceiptToCustomer.Location = new System.Drawing.Point(647, 390);
            this._cbxEmailReceiptToCustomer.Name = "_cbxEmailReceiptToCustomer";
            this._cbxEmailReceiptToCustomer.Size = new System.Drawing.Size(180, 17);
            this._cbxEmailReceiptToCustomer.TabIndex = 28;
            this._cbxEmailReceiptToCustomer.Text = "Email Receipt To Customer";
            this._cbxEmailReceiptToCustomer.UseVisualStyleBackColor = true;
            //
            // _cboSignatureSelected
            //
            this._cboSignatureSelected.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._cboSignatureSelected.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboSignatureSelected.Location = new System.Drawing.Point(714, 332);
            this._cboSignatureSelected.Name = "_cboSignatureSelected";
            this._cboSignatureSelected.Size = new System.Drawing.Size(525, 21);
            this._cboSignatureSelected.TabIndex = 27;
            //
            // _Label42
            //
            this._Label42.Location = new System.Drawing.Point(644, 335);
            this._Label42.Name = "_Label42";
            this._Label42.Size = new System.Drawing.Size(64, 23);
            this._Label42.TabIndex = 26;
            this._Label42.Text = "Signature";
            //
            // _dgJobItems
            //
            this._dgJobItems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgJobItems.DataMember = "";
            this._dgJobItems.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgJobItems.Location = new System.Drawing.Point(128, 450);
            this._dgJobItems.Name = "_dgJobItems";
            this._dgJobItems.Size = new System.Drawing.Size(1111, 196);
            this._dgJobItems.TabIndex = 9;
            this._dgJobItems.TabStop = false;
            this._dgJobItems.CurrentCellChanged += new System.EventHandler(this.dgJobItems_CurrentCellChanged);
            //
            // _Label12
            //
            this._Label12.Location = new System.Drawing.Point(8, 450);
            this._Label12.Name = "_Label12";
            this._Label12.Size = new System.Drawing.Size(80, 16);
            this._Label12.TabIndex = 25;
            this._Label12.Text = "Job Items";
            //
            // _txtNotesToEngineer
            //
            this._txtNotesToEngineer.Location = new System.Drawing.Point(128, 44);
            this._txtNotesToEngineer.Multiline = true;
            this._txtNotesToEngineer.Name = "_txtNotesToEngineer";
            this._txtNotesToEngineer.ReadOnly = true;
            this._txtNotesToEngineer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtNotesToEngineer.Size = new System.Drawing.Size(510, 66);
            this._txtNotesToEngineer.TabIndex = 10;
            this._txtNotesToEngineer.TabStop = false;
            //
            // _Label6
            //
            this._Label6.Location = new System.Drawing.Point(8, 40);
            this._Label6.Name = "_Label6";
            this._Label6.Size = new System.Drawing.Size(64, 16);
            this._Label6.TabIndex = 21;
            this._Label6.Text = "Notes";
            //
            // _txtCustomer
            //
            this._txtCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtCustomer.Location = new System.Drawing.Point(714, 173);
            this._txtCustomer.Name = "_txtCustomer";
            this._txtCustomer.Size = new System.Drawing.Size(525, 21);
            this._txtCustomer.TabIndex = 6;
            //
            // _cboEngineer
            //
            this._cboEngineer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._cboEngineer.Location = new System.Drawing.Point(714, 14);
            this._cboEngineer.Name = "_cboEngineer";
            this._cboEngineer.Size = new System.Drawing.Size(525, 21);
            this._cboEngineer.TabIndex = 4;
            //
            // _txtNotesFromEngineer
            //
            this._txtNotesFromEngineer.Location = new System.Drawing.Point(128, 335);
            this._txtNotesFromEngineer.Multiline = true;
            this._txtNotesFromEngineer.Name = "_txtNotesFromEngineer";
            this._txtNotesFromEngineer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtNotesFromEngineer.Size = new System.Drawing.Size(510, 72);
            this._txtNotesFromEngineer.TabIndex = 3;
            //
            // _cboOutcome
            //
            this._cboOutcome.Location = new System.Drawing.Point(128, 144);
            this._cboOutcome.Name = "_cboOutcome";
            this._cboOutcome.Size = new System.Drawing.Size(510, 21);
            this._cboOutcome.TabIndex = 1;
            this._cboOutcome.SelectedIndexChanged += new System.EventHandler(this.cboOutcome_SelectedIndexChanged);
            //
            // _txtOutcomeDetails
            //
            this._txtOutcomeDetails.Location = new System.Drawing.Point(128, 231);
            this._txtOutcomeDetails.Multiline = true;
            this._txtOutcomeDetails.Name = "_txtOutcomeDetails";
            this._txtOutcomeDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._txtOutcomeDetails.Size = new System.Drawing.Size(510, 95);
            this._txtOutcomeDetails.TabIndex = 2;
            //
            // _Label11
            //
            this._Label11.Location = new System.Drawing.Point(8, 234);
            this._Label11.Name = "_Label11";
            this._Label11.Size = new System.Drawing.Size(80, 16);
            this._Label11.TabIndex = 12;
            this._Label11.Text = "Details";
            //
            // _txtUploadedBy
            //
            this._txtUploadedBy.Location = new System.Drawing.Point(128, 116);
            this._txtUploadedBy.Name = "_txtUploadedBy";
            this._txtUploadedBy.ReadOnly = true;
            this._txtUploadedBy.Size = new System.Drawing.Size(510, 21);
            this._txtUploadedBy.TabIndex = 2;
            this._txtUploadedBy.TabStop = false;
            //
            // _txtStatus
            //
            this._txtStatus.Location = new System.Drawing.Point(128, 14);
            this._txtStatus.Name = "_txtStatus";
            this._txtStatus.ReadOnly = true;
            this._txtStatus.Size = new System.Drawing.Size(510, 21);
            this._txtStatus.TabIndex = 1;
            this._txtStatus.TabStop = false;
            //
            // _Label9
            //
            this._Label9.Location = new System.Drawing.Point(8, 147);
            this._Label9.Name = "_Label9";
            this._Label9.Size = new System.Drawing.Size(80, 19);
            this._Label9.TabIndex = 8;
            this._Label9.Text = "Outcome";
            //
            // _Label5
            //
            this._Label5.Location = new System.Drawing.Point(644, 176);
            this._Label5.Name = "_Label5";
            this._Label5.Size = new System.Drawing.Size(64, 16);
            this._Label5.TabIndex = 4;
            this._Label5.Text = "Customer";
            //
            // _Label4
            //
            this._Label4.Location = new System.Drawing.Point(8, 119);
            this._Label4.Name = "_Label4";
            this._Label4.Size = new System.Drawing.Size(80, 16);
            this._Label4.TabIndex = 3;
            this._Label4.Text = "Uploaded by";
            //
            // _Label3
            //
            this._Label3.Location = new System.Drawing.Point(8, 16);
            this._Label3.Name = "_Label3";
            this._Label3.Size = new System.Drawing.Size(56, 16);
            this._Label3.TabIndex = 2;
            this._Label3.Text = "Status";
            //
            // _Label2
            //
            this._Label2.Location = new System.Drawing.Point(8, 335);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(128, 24);
            this._Label2.TabIndex = 1;
            this._Label2.Text = "Invoice Notes";
            //
            // _Label1
            //
            this._Label1.Location = new System.Drawing.Point(644, 14);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(64, 16);
            this._Label1.TabIndex = 0;
            this._Label1.Text = "Engineer";
            //
            // _tpAppliances
            //
            this._tpAppliances.Controls.Add(this._gpAppliances);
            this._tpAppliances.Location = new System.Drawing.Point(4, 22);
            this._tpAppliances.Name = "_tpAppliances";
            this._tpAppliances.Padding = new System.Windows.Forms.Padding(3);
            this._tpAppliances.Size = new System.Drawing.Size(1247, 652);
            this._tpAppliances.TabIndex = 6;
            this._tpAppliances.Text = "Appliances";
            this._tpAppliances.UseVisualStyleBackColor = true;
            //
            // _gpAppliances
            //
            this._gpAppliances.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._gpAppliances.Controls.Add(this._dgAssets);
            this._gpAppliances.Location = new System.Drawing.Point(6, 6);
            this._gpAppliances.Name = "_gpAppliances";
            this._gpAppliances.Size = new System.Drawing.Size(1235, 640);
            this._gpAppliances.TabIndex = 0;
            this._gpAppliances.TabStop = false;
            this._gpAppliances.Text = "Appliances";
            //
            // _dgAssets
            //
            this._dgAssets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgAssets.DataMember = "";
            this._dgAssets.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgAssets.Location = new System.Drawing.Point(6, 20);
            this._dgAssets.Name = "_dgAssets";
            this._dgAssets.Size = new System.Drawing.Size(1223, 614);
            this._dgAssets.TabIndex = 2;
            //
            // _tpWorksheets
            //
            this._tpWorksheets.Controls.Add(this._grpAdditionalWorksheet);
            this._tpWorksheets.Controls.Add(this._grpAlarmInfo);
            this._tpWorksheets.Controls.Add(this._grpVisitWorksheetExtended);
            this._tpWorksheets.Controls.Add(this._grpVisitDefects);
            this._tpWorksheets.Controls.Add(this._grpApplianceWorksheet);
            this._tpWorksheets.Controls.Add(this._grpVisitWorksheet);
            this._tpWorksheets.Location = new System.Drawing.Point(4, 22);
            this._tpWorksheets.Name = "_tpWorksheets";
            this._tpWorksheets.Size = new System.Drawing.Size(1247, 652);
            this._tpWorksheets.TabIndex = 5;
            this._tpWorksheets.Text = "Worksheets";
            this._tpWorksheets.UseVisualStyleBackColor = true;
            //
            // _grpAdditionalWorksheet
            //
            this._grpAdditionalWorksheet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left;
            this._grpAdditionalWorksheet.Controls.Add(this._btnRemoveAdd);
            this._grpAdditionalWorksheet.Controls.Add(this._btnAddAdd);
            this._grpAdditionalWorksheet.Controls.Add(this._dgAdditional);
            this._grpAdditionalWorksheet.Location = new System.Drawing.Point(515, 259);
            this._grpAdditionalWorksheet.Name = "_grpAdditionalWorksheet";
            this._grpAdditionalWorksheet.Size = new System.Drawing.Size(360, 247);
            this._grpAdditionalWorksheet.TabIndex = 29;
            this._grpAdditionalWorksheet.TabStop = false;
            this._grpAdditionalWorksheet.Text = "Additional Worksheets";
            //
            // _btnRemoveAdd
            //
            this._btnRemoveAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnRemoveAdd.Location = new System.Drawing.Point(8, 218);
            this._btnRemoveAdd.Name = "_btnRemoveAdd";
            this._btnRemoveAdd.Size = new System.Drawing.Size(75, 23);
            this._btnRemoveAdd.TabIndex = 3;
            this._btnRemoveAdd.Text = "Remove";
            //
            // _btnAddAdd
            //
            this._btnAddAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAddAdd.Location = new System.Drawing.Point(275, 218);
            this._btnAddAdd.Name = "_btnAddAdd";
            this._btnAddAdd.Size = new System.Drawing.Size(75, 23);
            this._btnAddAdd.TabIndex = 4;
            this._btnAddAdd.Text = "Add";
            //
            // _dgAdditional
            //
            this._dgAdditional.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgAdditional.DataMember = "";
            this._dgAdditional.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgAdditional.Location = new System.Drawing.Point(6, 20);
            this._dgAdditional.Name = "_dgAdditional";
            this._dgAdditional.Size = new System.Drawing.Size(344, 192);
            this._dgAdditional.TabIndex = 0;
            this._dgAdditional.DoubleClick += new System.EventHandler(this.dgAdditionalWorkSheets_DoubleClick);
            //
            // _grpAlarmInfo
            //
            this._grpAlarmInfo.Controls.Add(this._btnRemoveSmokeComo);
            this._grpAlarmInfo.Controls.Add(this._btnAddSmokeComo);
            this._grpAlarmInfo.Controls.Add(this._DGSmokeComo);
            this._grpAlarmInfo.Location = new System.Drawing.Point(515, 8);
            this._grpAlarmInfo.Name = "_grpAlarmInfo";
            this._grpAlarmInfo.Size = new System.Drawing.Size(360, 242);
            this._grpAlarmInfo.TabIndex = 4;
            this._grpAlarmInfo.TabStop = false;
            this._grpAlarmInfo.Text = "Alarm Info";
            //
            // _btnRemoveSmokeComo
            //
            this._btnRemoveSmokeComo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnRemoveSmokeComo.Location = new System.Drawing.Point(12, 202);
            this._btnRemoveSmokeComo.Name = "_btnRemoveSmokeComo";
            this._btnRemoveSmokeComo.Size = new System.Drawing.Size(75, 23);
            this._btnRemoveSmokeComo.TabIndex = 30;
            this._btnRemoveSmokeComo.Text = "Remove";
            this._btnRemoveSmokeComo.Click += new System.EventHandler(this.btnRemoveSmokeComo_Click);
            //
            // _btnAddSmokeComo
            //
            this._btnAddSmokeComo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAddSmokeComo.Location = new System.Drawing.Point(275, 202);
            this._btnAddSmokeComo.Name = "_btnAddSmokeComo";
            this._btnAddSmokeComo.Size = new System.Drawing.Size(75, 23);
            this._btnAddSmokeComo.TabIndex = 31;
            this._btnAddSmokeComo.Text = "Add";
            this._btnAddSmokeComo.Click += new System.EventHandler(this.btnAddSmokeComo_Click);
            //
            // _DGSmokeComo
            //
            this._DGSmokeComo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._DGSmokeComo.DataMember = "";
            this._DGSmokeComo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._DGSmokeComo.Location = new System.Drawing.Point(12, 17);
            this._DGSmokeComo.Name = "_DGSmokeComo";
            this._DGSmokeComo.Size = new System.Drawing.Size(338, 181);
            this._DGSmokeComo.TabIndex = 29;
            this._DGSmokeComo.DoubleClick += new System.EventHandler(this.dgSmokeComoWorkSheets_DoubleClick);
            //
            // _grpVisitWorksheetExtended
            //
            this._grpVisitWorksheetExtended.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._grpVisitWorksheetExtended.Controls.Add(this._cboSITimer);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboFillDisc);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label81);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label80);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label79);
            this._grpVisitWorksheetExtended.Controls.Add(this._txtRadiators);
            this._grpVisitWorksheetExtended.Controls.Add(this._txtVisualInspectionReason);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label68);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label69);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label70);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label62);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label63);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label64);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label65);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label66);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label67);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboCertificateTypeID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboCODetectorFittedID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboVisualInspectionSatisfactoryID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboImmersionID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboJacketID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboCylinderTypeID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboPartialHeatingID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboHeatingSystemTypeID);
            this._grpVisitWorksheetExtended.Controls.Add(this._txtApproxAgeOfBoiler);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboStrainerInspectedID);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label56);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label57);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboStrainerFittedID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboInstallationSafeToUseID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboInstallationPipeWorkCorrectID);
            this._grpVisitWorksheetExtended.Controls.Add(this._cboCorrectMaterialsUsedID);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label58);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label59);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label60);
            this._grpVisitWorksheetExtended.Controls.Add(this._Label61);
            this._grpVisitWorksheetExtended.Location = new System.Drawing.Point(881, 8);
            this._grpVisitWorksheetExtended.Name = "_grpVisitWorksheetExtended";
            this._grpVisitWorksheetExtended.Size = new System.Drawing.Size(358, 636);
            this._grpVisitWorksheetExtended.TabIndex = 3;
            this._grpVisitWorksheetExtended.TabStop = false;
            this._grpVisitWorksheetExtended.Text = "Visit Worksheet - Extended";
            //
            // _cboSITimer
            //
            this._cboSITimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboSITimer.Location = new System.Drawing.Point(192, 449);
            this._cboSITimer.Name = "_cboSITimer";
            this._cboSITimer.Size = new System.Drawing.Size(160, 21);
            this._cboSITimer.TabIndex = 33;
            //
            // _cboFillDisc
            //
            this._cboFillDisc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboFillDisc.Location = new System.Drawing.Point(192, 422);
            this._cboFillDisc.Name = "_cboFillDisc";
            this._cboFillDisc.Size = new System.Drawing.Size(160, 21);
            this._cboFillDisc.TabIndex = 32;
            //
            // _Label81
            //
            this._Label81.Location = new System.Drawing.Point(6, 477);
            this._Label81.Name = "_Label81";
            this._Label81.Size = new System.Drawing.Size(180, 21);
            this._Label81.TabIndex = 31;
            this._Label81.Text = "Flue/Tank In loft details";
            //
            // _Label80
            //
            this._Label80.Location = new System.Drawing.Point(6, 423);
            this._Label80.Name = "_Label80";
            this._Label80.Size = new System.Drawing.Size(180, 21);
            this._Label80.TabIndex = 30;
            this._Label80.Text = "Filling Loop Disconnected?";
            //
            // _Label79
            //
            this._Label79.Location = new System.Drawing.Point(6, 449);
            this._Label79.Name = "_Label79";
            this._Label79.Size = new System.Drawing.Size(180, 21);
            this._Label79.TabIndex = 29;
            this._Label79.Text = "SI Timer Reset";
            //
            // _txtRadiators
            //
            this._txtRadiators.Location = new System.Drawing.Point(192, 287);
            this._txtRadiators.Name = "_txtRadiators";
            this._txtRadiators.Size = new System.Drawing.Size(160, 21);
            this._txtRadiators.TabIndex = 10;
            this._txtRadiators.Text = "0";
            //
            // _txtVisualInspectionReason
            //
            this._txtVisualInspectionReason.Location = new System.Drawing.Point(192, 476);
            this._txtVisualInspectionReason.Multiline = true;
            this._txtVisualInspectionReason.Name = "_txtVisualInspectionReason";
            this._txtVisualInspectionReason.Size = new System.Drawing.Size(160, 43);
            this._txtVisualInspectionReason.TabIndex = 15;
            //
            // _Label68
            //
            this._Label68.Location = new System.Drawing.Point(6, 397);
            this._Label68.Name = "_Label68";
            this._Label68.Size = new System.Drawing.Size(180, 21);
            this._Label68.TabIndex = 28;
            this._Label68.Text = "Flue/Tank In Loft Satisfactory\r\n";
            //
            // _Label69
            //
            this._Label69.Location = new System.Drawing.Point(6, 371);
            this._Label69.Name = "_Label69";
            this._Label69.Size = new System.Drawing.Size(180, 23);
            this._Label69.TabIndex = 27;
            this._Label69.Text = "Certificate Type";
            //
            // _Label70
            //
            this._Label70.Location = new System.Drawing.Point(6, 344);
            this._Label70.Name = "_Label70";
            this._Label70.Size = new System.Drawing.Size(180, 23);
            this._Label70.TabIndex = 26;
            this._Label70.Text = "Approx. Age Of Boiler";
            //
            // _Label62
            //
            this._Label62.Location = new System.Drawing.Point(6, 317);
            this._Label62.Name = "_Label62";
            this._Label62.Size = new System.Drawing.Size(180, 23);
            this._Label62.TabIndex = 25;
            this._Label62.Text = "CO Detector Fitted ";
            //
            // _Label63
            //
            this._Label63.Location = new System.Drawing.Point(6, 290);
            this._Label63.Name = "_Label63";
            this._Label63.Size = new System.Drawing.Size(180, 23);
            this._Label63.TabIndex = 24;
            this._Label63.Text = "Radiators";
            //
            // _Label64
            //
            this._Label64.Location = new System.Drawing.Point(6, 128);
            this._Label64.Name = "_Label64";
            this._Label64.Size = new System.Drawing.Size(180, 23);
            this._Label64.TabIndex = 23;
            this._Label64.Text = "Is Strainer Inspected";
            //
            // _Label65
            //
            this._Label65.Location = new System.Drawing.Point(6, 101);
            this._Label65.Name = "_Label65";
            this._Label65.Size = new System.Drawing.Size(180, 23);
            this._Label65.TabIndex = 22;
            this._Label65.Text = "Is Strainer Fitted";
            //
            // _Label66
            //
            this._Label66.Location = new System.Drawing.Point(6, 263);
            this._Label66.Name = "_Label66";
            this._Label66.Size = new System.Drawing.Size(180, 23);
            this._Label66.TabIndex = 21;
            this._Label66.Text = "Immersion";
            //
            // _Label67
            //
            this._Label67.Location = new System.Drawing.Point(6, 236);
            this._Label67.Name = "_Label67";
            this._Label67.Size = new System.Drawing.Size(180, 23);
            this._Label67.TabIndex = 20;
            this._Label67.Text = "Jacket";
            //
            // _cboCertificateTypeID
            //
            this._cboCertificateTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboCertificateTypeID.Location = new System.Drawing.Point(192, 368);
            this._cboCertificateTypeID.Name = "_cboCertificateTypeID";
            this._cboCertificateTypeID.Size = new System.Drawing.Size(160, 21);
            this._cboCertificateTypeID.TabIndex = 13;
            //
            // _cboCODetectorFittedID
            //
            this._cboCODetectorFittedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboCODetectorFittedID.Location = new System.Drawing.Point(192, 314);
            this._cboCODetectorFittedID.Name = "_cboCODetectorFittedID";
            this._cboCODetectorFittedID.Size = new System.Drawing.Size(160, 21);
            this._cboCODetectorFittedID.TabIndex = 11;
            //
            // _cboVisualInspectionSatisfactoryID
            //
            this._cboVisualInspectionSatisfactoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboVisualInspectionSatisfactoryID.Location = new System.Drawing.Point(192, 395);
            this._cboVisualInspectionSatisfactoryID.Name = "_cboVisualInspectionSatisfactoryID";
            this._cboVisualInspectionSatisfactoryID.Size = new System.Drawing.Size(160, 21);
            this._cboVisualInspectionSatisfactoryID.TabIndex = 14;
            //
            // _cboImmersionID
            //
            this._cboImmersionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboImmersionID.Location = new System.Drawing.Point(192, 260);
            this._cboImmersionID.Name = "_cboImmersionID";
            this._cboImmersionID.Size = new System.Drawing.Size(160, 21);
            this._cboImmersionID.TabIndex = 9;
            //
            // _cboJacketID
            //
            this._cboJacketID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboJacketID.Location = new System.Drawing.Point(192, 233);
            this._cboJacketID.Name = "_cboJacketID";
            this._cboJacketID.Size = new System.Drawing.Size(160, 21);
            this._cboJacketID.TabIndex = 8;
            //
            // _cboCylinderTypeID
            //
            this._cboCylinderTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboCylinderTypeID.Location = new System.Drawing.Point(192, 206);
            this._cboCylinderTypeID.Name = "_cboCylinderTypeID";
            this._cboCylinderTypeID.Size = new System.Drawing.Size(160, 21);
            this._cboCylinderTypeID.TabIndex = 7;
            //
            // _cboPartialHeatingID
            //
            this._cboPartialHeatingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboPartialHeatingID.Location = new System.Drawing.Point(192, 179);
            this._cboPartialHeatingID.Name = "_cboPartialHeatingID";
            this._cboPartialHeatingID.Size = new System.Drawing.Size(160, 21);
            this._cboPartialHeatingID.TabIndex = 6;
            //
            // _cboHeatingSystemTypeID
            //
            this._cboHeatingSystemTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboHeatingSystemTypeID.Location = new System.Drawing.Point(192, 152);
            this._cboHeatingSystemTypeID.Name = "_cboHeatingSystemTypeID";
            this._cboHeatingSystemTypeID.Size = new System.Drawing.Size(160, 21);
            this._cboHeatingSystemTypeID.TabIndex = 5;
            //
            // _txtApproxAgeOfBoiler
            //
            this._txtApproxAgeOfBoiler.Location = new System.Drawing.Point(192, 341);
            this._txtApproxAgeOfBoiler.Name = "_txtApproxAgeOfBoiler";
            this._txtApproxAgeOfBoiler.Size = new System.Drawing.Size(160, 21);
            this._txtApproxAgeOfBoiler.TabIndex = 12;
            this._txtApproxAgeOfBoiler.Text = "0";
            //
            // _cboStrainerInspectedID
            //
            this._cboStrainerInspectedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStrainerInspectedID.Location = new System.Drawing.Point(192, 125);
            this._cboStrainerInspectedID.Name = "_cboStrainerInspectedID";
            this._cboStrainerInspectedID.Size = new System.Drawing.Size(160, 21);
            this._cboStrainerInspectedID.TabIndex = 4;
            //
            // _Label56
            //
            this._Label56.Location = new System.Drawing.Point(6, 209);
            this._Label56.Name = "_Label56";
            this._Label56.Size = new System.Drawing.Size(180, 23);
            this._Label56.TabIndex = 9;
            this._Label56.Text = "Cylinder type ";
            //
            // _Label57
            //
            this._Label57.Location = new System.Drawing.Point(6, 182);
            this._Label57.Name = "_Label57";
            this._Label57.Size = new System.Drawing.Size(180, 23);
            this._Label57.TabIndex = 8;
            this._Label57.Text = "Partial Heating";
            //
            // _cboStrainerFittedID
            //
            this._cboStrainerFittedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboStrainerFittedID.Location = new System.Drawing.Point(192, 98);
            this._cboStrainerFittedID.Name = "_cboStrainerFittedID";
            this._cboStrainerFittedID.Size = new System.Drawing.Size(160, 21);
            this._cboStrainerFittedID.TabIndex = 3;
            //
            // _cboInstallationSafeToUseID
            //
            this._cboInstallationSafeToUseID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboInstallationSafeToUseID.Location = new System.Drawing.Point(192, 71);
            this._cboInstallationSafeToUseID.Name = "_cboInstallationSafeToUseID";
            this._cboInstallationSafeToUseID.Size = new System.Drawing.Size(160, 21);
            this._cboInstallationSafeToUseID.TabIndex = 2;
            //
            // _cboInstallationPipeWorkCorrectID
            //
            this._cboInstallationPipeWorkCorrectID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboInstallationPipeWorkCorrectID.Location = new System.Drawing.Point(192, 44);
            this._cboInstallationPipeWorkCorrectID.Name = "_cboInstallationPipeWorkCorrectID";
            this._cboInstallationPipeWorkCorrectID.Size = new System.Drawing.Size(160, 21);
            this._cboInstallationPipeWorkCorrectID.TabIndex = 1;
            //
            // _cboCorrectMaterialsUsedID
            //
            this._cboCorrectMaterialsUsedID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboCorrectMaterialsUsedID.Location = new System.Drawing.Point(192, 17);
            this._cboCorrectMaterialsUsedID.Name = "_cboCorrectMaterialsUsedID";
            this._cboCorrectMaterialsUsedID.Size = new System.Drawing.Size(160, 21);
            this._cboCorrectMaterialsUsedID.TabIndex = 0;
            //
            // _Label58
            //
            this._Label58.Location = new System.Drawing.Point(6, 155);
            this._Label58.Name = "_Label58";
            this._Label58.Size = new System.Drawing.Size(180, 23);
            this._Label58.TabIndex = 3;
            this._Label58.Text = "Heating System Type";
            //
            // _Label59
            //
            this._Label59.Location = new System.Drawing.Point(6, 74);
            this._Label59.Name = "_Label59";
            this._Label59.Size = new System.Drawing.Size(180, 23);
            this._Label59.TabIndex = 2;
            this._Label59.Text = "Installation Safe To Use ";
            //
            // _Label60
            //
            this._Label60.Location = new System.Drawing.Point(6, 47);
            this._Label60.Name = "_Label60";
            this._Label60.Size = new System.Drawing.Size(180, 23);
            this._Label60.TabIndex = 1;
            this._Label60.Text = "Installation Pipework Correct";
            //
            // _Label61
            //
            this._Label61.Location = new System.Drawing.Point(6, 20);
            this._Label61.Name = "_Label61";
            this._Label61.Size = new System.Drawing.Size(180, 23);
            this._Label61.TabIndex = 0;
            this._Label61.Text = "Correct Materials Used In Installation ";
            //
            // _grpVisitDefects
            //
            this._grpVisitDefects.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._grpVisitDefects.Controls.Add(this._btnAddVisitDefect);
            this._grpVisitDefects.Controls.Add(this._btnRemoveVisitDefect);
            this._grpVisitDefects.Controls.Add(this._dgVisitDefects);
            this._grpVisitDefects.Location = new System.Drawing.Point(8, 503);
            this._grpVisitDefects.Name = "_grpVisitDefects";
            this._grpVisitDefects.Size = new System.Drawing.Size(501, 141);
            this._grpVisitDefects.TabIndex = 2;
            this._grpVisitDefects.TabStop = false;
            this._grpVisitDefects.Text = "Visit Defects";
            //
            // _btnAddVisitDefect
            //
            this._btnAddVisitDefect.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAddVisitDefect.Location = new System.Drawing.Point(421, 109);
            this._btnAddVisitDefect.Name = "_btnAddVisitDefect";
            this._btnAddVisitDefect.Size = new System.Drawing.Size(75, 23);
            this._btnAddVisitDefect.TabIndex = 3;
            this._btnAddVisitDefect.Text = "Add";
            this._btnAddVisitDefect.Click += new System.EventHandler(this.btnAddVisitDefect_Click);
            //
            // _btnRemoveVisitDefect
            //
            this._btnRemoveVisitDefect.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnRemoveVisitDefect.Location = new System.Drawing.Point(8, 109);
            this._btnRemoveVisitDefect.Name = "_btnRemoveVisitDefect";
            this._btnRemoveVisitDefect.Size = new System.Drawing.Size(75, 23);
            this._btnRemoveVisitDefect.TabIndex = 2;
            this._btnRemoveVisitDefect.Text = "Remove";
            this._btnRemoveVisitDefect.Click += new System.EventHandler(this.btnRemoveVisitDefect_Click);
            //
            // _dgVisitDefects
            //
            this._dgVisitDefects.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgVisitDefects.DataMember = "";
            this._dgVisitDefects.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgVisitDefects.Location = new System.Drawing.Point(8, 20);
            this._dgVisitDefects.Name = "_dgVisitDefects";
            this._dgVisitDefects.Size = new System.Drawing.Size(485, 83);
            this._dgVisitDefects.TabIndex = 1;
            this._dgVisitDefects.DoubleClick += new System.EventHandler(this.dgVisitDefects_DoubleClick);
            //
            // _grpApplianceWorksheet
            //
            this._grpApplianceWorksheet.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left;
            this._grpApplianceWorksheet.Controls.Add(this._btnRemoveApplianceWorkSheet);
            this._grpApplianceWorksheet.Controls.Add(this._dgApplianceWorkSheets);
            this._grpApplianceWorksheet.Controls.Add(this._btnAddApplianceWorksheet);
            this._grpApplianceWorksheet.Location = new System.Drawing.Point(8, 256);
            this._grpApplianceWorksheet.Name = "_grpApplianceWorksheet";
            this._grpApplianceWorksheet.Size = new System.Drawing.Size(501, 247);
            this._grpApplianceWorksheet.TabIndex = 1;
            this._grpApplianceWorksheet.TabStop = false;
            this._grpApplianceWorksheet.Text = "Appliance Worksheets";
            //
            // _btnRemoveApplianceWorkSheet
            //
            this._btnRemoveApplianceWorkSheet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnRemoveApplianceWorkSheet.Location = new System.Drawing.Point(8, 218);
            this._btnRemoveApplianceWorkSheet.Name = "_btnRemoveApplianceWorkSheet";
            this._btnRemoveApplianceWorkSheet.Size = new System.Drawing.Size(75, 23);
            this._btnRemoveApplianceWorkSheet.TabIndex = 3;
            this._btnRemoveApplianceWorkSheet.Text = "Remove";
            this._btnRemoveApplianceWorkSheet.Click += new System.EventHandler(this.btnRemoveApplianceWorkSheet_Click);
            //
            // _dgApplianceWorkSheets
            //
            this._dgApplianceWorkSheets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgApplianceWorkSheets.DataMember = "";
            this._dgApplianceWorkSheets.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgApplianceWorkSheets.Location = new System.Drawing.Point(8, 20);
            this._dgApplianceWorkSheets.Name = "_dgApplianceWorkSheets";
            this._dgApplianceWorkSheets.Size = new System.Drawing.Size(485, 192);
            this._dgApplianceWorkSheets.TabIndex = 0;
            this._dgApplianceWorkSheets.DoubleClick += new System.EventHandler(this.dgApplianceWorkSheets_DoubleClick);
            //
            // _btnAddApplianceWorksheet
            //
            this._btnAddApplianceWorksheet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAddApplianceWorksheet.Location = new System.Drawing.Point(413, 218);
            this._btnAddApplianceWorksheet.Name = "_btnAddApplianceWorksheet";
            this._btnAddApplianceWorksheet.Size = new System.Drawing.Size(75, 23);
            this._btnAddApplianceWorksheet.TabIndex = 4;
            this._btnAddApplianceWorksheet.Text = "Add";
            this._btnAddApplianceWorksheet.Click += new System.EventHandler(this.btnAddApplianceWorksheet_Click);
            //
            // _grpVisitWorksheet
            //
            this._grpVisitWorksheet.Controls.Add(this._cboMeterCapped);
            this._grpVisitWorksheet.Controls.Add(this._Label73);
            this._grpVisitWorksheet.Controls.Add(this._cboMeterLocation);
            this._grpVisitWorksheet.Controls.Add(this._Label72);
            this._grpVisitWorksheet.Controls.Add(this._txtAmountCollected);
            this._grpVisitWorksheet.Controls.Add(this._cboPaymentMethod);
            this._grpVisitWorksheet.Controls.Add(this._Label44);
            this._grpVisitWorksheet.Controls.Add(this._Label43);
            this._grpVisitWorksheet.Controls.Add(this._cboPropertyRented);
            this._grpVisitWorksheet.Controls.Add(this._cboBonding);
            this._grpVisitWorksheet.Controls.Add(this._cboEmergencyControlAccessible);
            this._grpVisitWorksheet.Controls.Add(this._cboGasInstallationTightnessTest);
            this._grpVisitWorksheet.Controls.Add(this._Label41);
            this._grpVisitWorksheet.Controls.Add(this._Label40);
            this._grpVisitWorksheet.Controls.Add(this._Label8);
            this._grpVisitWorksheet.Controls.Add(this._Label7);
            this._grpVisitWorksheet.Location = new System.Drawing.Point(8, 8);
            this._grpVisitWorksheet.Name = "_grpVisitWorksheet";
            this._grpVisitWorksheet.Size = new System.Drawing.Size(501, 242);
            this._grpVisitWorksheet.TabIndex = 0;
            this._grpVisitWorksheet.TabStop = false;
            this._grpVisitWorksheet.Text = "Visit Worksheet";
            //
            // _cboMeterCapped
            //
            this._cboMeterCapped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboMeterCapped.Location = new System.Drawing.Point(216, 211);
            this._cboMeterCapped.Name = "_cboMeterCapped";
            this._cboMeterCapped.Size = new System.Drawing.Size(276, 21);
            this._cboMeterCapped.TabIndex = 15;
            //
            // _Label73
            //
            this._Label73.Location = new System.Drawing.Point(16, 214);
            this._Label73.Name = "_Label73";
            this._Label73.Size = new System.Drawing.Size(120, 23);
            this._Label73.TabIndex = 14;
            this._Label73.Text = "Meter Capped";
            //
            // _cboMeterLocation
            //
            this._cboMeterLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboMeterLocation.Location = new System.Drawing.Point(216, 182);
            this._cboMeterLocation.Name = "_cboMeterLocation";
            this._cboMeterLocation.Size = new System.Drawing.Size(276, 21);
            this._cboMeterLocation.TabIndex = 13;
            //
            // _Label72
            //
            this._Label72.Location = new System.Drawing.Point(16, 185);
            this._Label72.Name = "_Label72";
            this._Label72.Size = new System.Drawing.Size(120, 23);
            this._Label72.TabIndex = 12;
            this._Label72.Text = "Meter Location";
            //
            // _txtAmountCollected
            //
            this._txtAmountCollected.Location = new System.Drawing.Point(216, 155);
            this._txtAmountCollected.Name = "_txtAmountCollected";
            this._txtAmountCollected.Size = new System.Drawing.Size(276, 21);
            this._txtAmountCollected.TabIndex = 11;
            //
            // _cboPaymentMethod
            //
            this._cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboPaymentMethod.Location = new System.Drawing.Point(216, 128);
            this._cboPaymentMethod.Name = "_cboPaymentMethod";
            this._cboPaymentMethod.Size = new System.Drawing.Size(276, 21);
            this._cboPaymentMethod.TabIndex = 10;
            //
            // _Label44
            //
            this._Label44.Location = new System.Drawing.Point(16, 158);
            this._Label44.Name = "_Label44";
            this._Label44.Size = new System.Drawing.Size(120, 23);
            this._Label44.TabIndex = 9;
            this._Label44.Text = "Amount Collected";
            //
            // _Label43
            //
            this._Label43.Location = new System.Drawing.Point(16, 131);
            this._Label43.Name = "_Label43";
            this._Label43.Size = new System.Drawing.Size(100, 23);
            this._Label43.TabIndex = 8;
            this._Label43.Text = "Payment Method";
            //
            // _cboPropertyRented
            //
            this._cboPropertyRented.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboPropertyRented.Location = new System.Drawing.Point(216, 101);
            this._cboPropertyRented.Name = "_cboPropertyRented";
            this._cboPropertyRented.Size = new System.Drawing.Size(276, 21);
            this._cboPropertyRented.TabIndex = 7;
            //
            // _cboBonding
            //
            this._cboBonding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboBonding.Location = new System.Drawing.Point(216, 74);
            this._cboBonding.Name = "_cboBonding";
            this._cboBonding.Size = new System.Drawing.Size(276, 21);
            this._cboBonding.TabIndex = 6;
            //
            // _cboEmergencyControlAccessible
            //
            this._cboEmergencyControlAccessible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboEmergencyControlAccessible.Location = new System.Drawing.Point(216, 47);
            this._cboEmergencyControlAccessible.Name = "_cboEmergencyControlAccessible";
            this._cboEmergencyControlAccessible.Size = new System.Drawing.Size(276, 21);
            this._cboEmergencyControlAccessible.TabIndex = 5;
            //
            // _cboGasInstallationTightnessTest
            //
            this._cboGasInstallationTightnessTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cboGasInstallationTightnessTest.Location = new System.Drawing.Point(216, 20);
            this._cboGasInstallationTightnessTest.Name = "_cboGasInstallationTightnessTest";
            this._cboGasInstallationTightnessTest.Size = new System.Drawing.Size(276, 21);
            this._cboGasInstallationTightnessTest.TabIndex = 4;
            //
            // _Label41
            //
            this._Label41.Location = new System.Drawing.Point(16, 104);
            this._Label41.Name = "_Label41";
            this._Label41.Size = new System.Drawing.Size(128, 23);
            this._Label41.TabIndex = 3;
            this._Label41.Text = "Property Rented";
            //
            // _Label40
            //
            this._Label40.Location = new System.Drawing.Point(16, 77);
            this._Label40.Name = "_Label40";
            this._Label40.Size = new System.Drawing.Size(64, 23);
            this._Label40.TabIndex = 2;
            this._Label40.Text = "Bonding";
            //
            // _Label8
            //
            this._Label8.Location = new System.Drawing.Point(16, 50);
            this._Label8.Name = "_Label8";
            this._Label8.Size = new System.Drawing.Size(192, 23);
            this._Label8.TabIndex = 1;
            this._Label8.Text = "Emergency Control Accessible";
            //
            // _Label7
            //
            this._Label7.Location = new System.Drawing.Point(16, 23);
            this._Label7.Name = "_Label7";
            this._Label7.Size = new System.Drawing.Size(192, 23);
            this._Label7.TabIndex = 0;
            this._Label7.Text = "Gas Installation Tightness Test";
            //
            // _tpTimesheets
            //
            this._tpTimesheets.Controls.Add(this._grpTimesheets);
            this._tpTimesheets.Controls.Add(this._txtScheduledTime);
            this._tpTimesheets.Controls.Add(this._Label10);
            this._tpTimesheets.Location = new System.Drawing.Point(4, 22);
            this._tpTimesheets.Name = "_tpTimesheets";
            this._tpTimesheets.Size = new System.Drawing.Size(1247, 652);
            this._tpTimesheets.TabIndex = 2;
            this._tpTimesheets.Text = "Timesheets";
            this._tpTimesheets.UseVisualStyleBackColor = true;
            //
            // _grpTimesheets
            //
            this._grpTimesheets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._grpTimesheets.Controls.Add(this._txtActualTimeSpent);
            this._grpTimesheets.Controls.Add(this._txtDifference);
            this._grpTimesheets.Controls.Add(this._txtSORTimeAllowance);
            this._grpTimesheets.Controls.Add(this._Label52);
            this._grpTimesheets.Controls.Add(this._Label51);
            this._grpTimesheets.Controls.Add(this._Label50);
            this._grpTimesheets.Controls.Add(this._Label22);
            this._grpTimesheets.Controls.Add(this._cboTimeSheetType);
            this._grpTimesheets.Controls.Add(this._Label14);
            this._grpTimesheets.Controls.Add(this._txtComments);
            this._grpTimesheets.Controls.Add(this._dtpEndDate);
            this._grpTimesheets.Controls.Add(this._dtpStartDate);
            this._grpTimesheets.Controls.Add(this._dgTimeSheets);
            this._grpTimesheets.Controls.Add(this._btnAddTimeSheet);
            this._grpTimesheets.Controls.Add(this._Label20);
            this._grpTimesheets.Controls.Add(this._Label21);
            this._grpTimesheets.Controls.Add(this._btnRemoveTimeSheet);
            this._grpTimesheets.Location = new System.Drawing.Point(8, 48);
            this._grpTimesheets.Name = "_grpTimesheets";
            this._grpTimesheets.Size = new System.Drawing.Size(1231, 598);
            this._grpTimesheets.TabIndex = 3;
            this._grpTimesheets.TabStop = false;
            this._grpTimesheets.Text = "TimeSheets";
            //
            // _txtActualTimeSpent
            //
            this._txtActualTimeSpent.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._txtActualTimeSpent.Location = new System.Drawing.Point(348, 541);
            this._txtActualTimeSpent.Name = "_txtActualTimeSpent";
            this._txtActualTimeSpent.ReadOnly = true;
            this._txtActualTimeSpent.Size = new System.Drawing.Size(136, 21);
            this._txtActualTimeSpent.TabIndex = 70;
            //
            // _txtDifference
            //
            this._txtDifference.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._txtDifference.Location = new System.Drawing.Point(348, 571);
            this._txtDifference.Name = "_txtDifference";
            this._txtDifference.ReadOnly = true;
            this._txtDifference.Size = new System.Drawing.Size(136, 21);
            this._txtDifference.TabIndex = 72;
            //
            // _txtSORTimeAllowance
            //
            this._txtSORTimeAllowance.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._txtSORTimeAllowance.Location = new System.Drawing.Point(348, 509);
            this._txtSORTimeAllowance.Name = "_txtSORTimeAllowance";
            this._txtSORTimeAllowance.ReadOnly = true;
            this._txtSORTimeAllowance.Size = new System.Drawing.Size(136, 21);
            this._txtSORTimeAllowance.TabIndex = 68;
            //
            // _Label52
            //
            this._Label52.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label52.AutoSize = true;
            this._Label52.Location = new System.Drawing.Point(203, 577);
            this._Label52.Name = "_Label52";
            this._Label52.Size = new System.Drawing.Size(71, 13);
            this._Label52.TabIndex = 71;
            this._Label52.Text = "Difference:";
            //
            // _Label51
            //
            this._Label51.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label51.AutoSize = true;
            this._Label51.Location = new System.Drawing.Point(203, 544);
            this._Label51.Name = "_Label51";
            this._Label51.Size = new System.Drawing.Size(103, 13);
            this._Label51.TabIndex = 69;
            this._Label51.Text = "Act. Time Spent:";
            //
            // _Label50
            //
            this._Label50.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label50.AutoSize = true;
            this._Label50.Location = new System.Drawing.Point(203, 512);
            this._Label50.Name = "_Label50";
            this._Label50.Size = new System.Drawing.Size(130, 13);
            this._Label50.TabIndex = 67;
            this._Label50.Text = "SOR Time Allowance:";
            //
            // _Label22
            //
            this._Label22.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label22.Location = new System.Drawing.Point(506, 512);
            this._Label22.Name = "_Label22";
            this._Label22.Size = new System.Drawing.Size(72, 23);
            this._Label22.TabIndex = 66;
            this._Label22.Text = "Comments";
            //
            // _cboTimeSheetType
            //
            this._cboTimeSheetType.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._cboTimeSheetType.Location = new System.Drawing.Point(46, 509);
            this._cboTimeSheetType.Name = "_cboTimeSheetType";
            this._cboTimeSheetType.Size = new System.Drawing.Size(136, 21);
            this._cboTimeSheetType.TabIndex = 3;
            //
            // _Label14
            //
            this._Label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label14.Location = new System.Drawing.Point(5, 512);
            this._Label14.Name = "_Label14";
            this._Label14.Size = new System.Drawing.Size(41, 23);
            this._Label14.TabIndex = 64;
            this._Label14.Text = "Type";
            //
            // _txtComments
            //
            this._txtComments.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._txtComments.Location = new System.Drawing.Point(584, 509);
            this._txtComments.Multiline = true;
            this._txtComments.Name = "_txtComments";
            this._txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtComments.Size = new System.Drawing.Size(404, 83);
            this._txtComments.TabIndex = 4;
            //
            // _dtpEndDate
            //
            this._dtpEndDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._dtpEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this._dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpEndDate.Location = new System.Drawing.Point(46, 571);
            this._dtpEndDate.Name = "_dtpEndDate";
            this._dtpEndDate.Size = new System.Drawing.Size(136, 21);
            this._dtpEndDate.TabIndex = 2;
            //
            // _dtpStartDate
            //
            this._dtpStartDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._dtpStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this._dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dtpStartDate.Location = new System.Drawing.Point(46, 540);
            this._dtpStartDate.Name = "_dtpStartDate";
            this._dtpStartDate.Size = new System.Drawing.Size(136, 21);
            this._dtpStartDate.TabIndex = 1;
            this._dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            //
            // _dgTimeSheets
            //
            this._dgTimeSheets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgTimeSheets.DataMember = "";
            this._dgTimeSheets.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgTimeSheets.Location = new System.Drawing.Point(8, 30);
            this._dgTimeSheets.Name = "_dgTimeSheets";
            this._dgTimeSheets.Size = new System.Drawing.Size(1215, 466);
            this._dgTimeSheets.TabIndex = 7;
            this._dgTimeSheets.TabStop = false;
            //
            // _btnAddTimeSheet
            //
            this._btnAddTimeSheet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAddTimeSheet.Location = new System.Drawing.Point(1151, 569);
            this._btnAddTimeSheet.Name = "_btnAddTimeSheet";
            this._btnAddTimeSheet.Size = new System.Drawing.Size(72, 23);
            this._btnAddTimeSheet.TabIndex = 5;
            this._btnAddTimeSheet.Text = "Add";
            this._btnAddTimeSheet.Click += new System.EventHandler(this.btnAddTimeSheet_Click);
            //
            // _Label20
            //
            this._Label20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label20.Location = new System.Drawing.Point(5, 573);
            this._Label20.Name = "_Label20";
            this._Label20.Size = new System.Drawing.Size(35, 23);
            this._Label20.TabIndex = 28;
            this._Label20.Text = "End";
            //
            // _Label21
            //
            this._Label21.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label21.Location = new System.Drawing.Point(5, 544);
            this._Label21.Name = "_Label21";
            this._Label21.Size = new System.Drawing.Size(35, 23);
            this._Label21.TabIndex = 25;
            this._Label21.Text = "Start Date/Time";
            //
            // _btnRemoveTimeSheet
            //
            this._btnRemoveTimeSheet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnRemoveTimeSheet.Location = new System.Drawing.Point(1151, 534);
            this._btnRemoveTimeSheet.Name = "_btnRemoveTimeSheet";
            this._btnRemoveTimeSheet.Size = new System.Drawing.Size(72, 23);
            this._btnRemoveTimeSheet.TabIndex = 6;
            this._btnRemoveTimeSheet.Text = "Remove";
            this._btnRemoveTimeSheet.Click += new System.EventHandler(this.btnRemoveTimeSheet_Click);
            //
            // _txtScheduledTime
            //
            this._txtScheduledTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtScheduledTime.Location = new System.Drawing.Point(112, 16);
            this._txtScheduledTime.Name = "_txtScheduledTime";
            this._txtScheduledTime.ReadOnly = true;
            this._txtScheduledTime.Size = new System.Drawing.Size(1127, 21);
            this._txtScheduledTime.TabIndex = 1;
            //
            // _Label10
            //
            this._Label10.Location = new System.Drawing.Point(8, 16);
            this._Label10.Name = "_Label10";
            this._Label10.Size = new System.Drawing.Size(104, 16);
            this._Label10.TabIndex = 9;
            this._Label10.Text = "Scheduled time";
            //
            // _tpPartsAndProducts
            //
            this._tpPartsAndProducts.Controls.Add(this._grpAllocated);
            this._tpPartsAndProducts.Controls.Add(this._grpUsed);
            this._tpPartsAndProducts.Location = new System.Drawing.Point(4, 22);
            this._tpPartsAndProducts.Name = "_tpPartsAndProducts";
            this._tpPartsAndProducts.Size = new System.Drawing.Size(1247, 652);
            this._tpPartsAndProducts.TabIndex = 1;
            this._tpPartsAndProducts.Text = "Parts && Products";
            this._tpPartsAndProducts.UseVisualStyleBackColor = true;
            //
            // _grpAllocated
            //
            this._grpAllocated.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._grpAllocated.Controls.Add(this._btnUnselectAllPPA);
            this._grpAllocated.Controls.Add(this._btnSelectAllPPA);
            this._grpAllocated.Controls.Add(this._btnRevertUsed);
            this._grpAllocated.Controls.Add(this._nudPartAllocatedQty);
            this._grpAllocated.Controls.Add(this._lblAllocatedQuantity);
            this._grpAllocated.Controls.Add(this._btnAllUsed);
            this._grpAllocated.Controls.Add(this._Label35);
            this._grpAllocated.Controls.Add(this._Panel2);
            this._grpAllocated.Controls.Add(this._Label34);
            this._grpAllocated.Controls.Add(this._Panel1);
            this._grpAllocated.Controls.Add(this._btnAllocatedNotUsed);
            this._grpAllocated.Controls.Add(this._dgPartsProductsAllocated);
            this._grpAllocated.Controls.Add(this._lblQuantityWarning);
            this._grpAllocated.Location = new System.Drawing.Point(8, 8);
            this._grpAllocated.Name = "_grpAllocated";
            this._grpAllocated.Size = new System.Drawing.Size(1231, 275);
            this._grpAllocated.TabIndex = 1;
            this._grpAllocated.TabStop = false;
            this._grpAllocated.Text = "Parts && Products Allocated";
            //
            // _btnUnselectAllPPA
            //
            this._btnUnselectAllPPA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnUnselectAllPPA.Location = new System.Drawing.Point(438, 244);
            this._btnUnselectAllPPA.Name = "_btnUnselectAllPPA";
            this._btnUnselectAllPPA.Size = new System.Drawing.Size(98, 23);
            this._btnUnselectAllPPA.TabIndex = 34;
            this._btnUnselectAllPPA.Text = "Deselect All";
            this._btnUnselectAllPPA.Click += new System.EventHandler(this.btnUnselectAllPPA_Click);
            //
            // _btnSelectAllPPA
            //
            this._btnSelectAllPPA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnSelectAllPPA.Location = new System.Drawing.Point(334, 244);
            this._btnSelectAllPPA.Name = "_btnSelectAllPPA";
            this._btnSelectAllPPA.Size = new System.Drawing.Size(98, 23);
            this._btnSelectAllPPA.TabIndex = 33;
            this._btnSelectAllPPA.Text = "Select All";
            this._btnSelectAllPPA.Click += new System.EventHandler(this.btnSelectAllPPA_Click);
            //
            // _btnRevertUsed
            //
            this._btnRevertUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnRevertUsed.Location = new System.Drawing.Point(234, 244);
            this._btnRevertUsed.Name = "_btnRevertUsed";
            this._btnRevertUsed.Size = new System.Drawing.Size(96, 23);
            this._btnRevertUsed.TabIndex = 32;
            this._btnRevertUsed.Text = "Revert Used";
            this._btnRevertUsed.Click += new System.EventHandler(this.btnRevertUsed_Click);
            //
            // _nudPartAllocatedQty
            //
            this._nudPartAllocatedQty.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._nudPartAllocatedQty.Location = new System.Drawing.Point(937, 243);
            this._nudPartAllocatedQty.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._nudPartAllocatedQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudPartAllocatedQty.Name = "_nudPartAllocatedQty";
            this._nudPartAllocatedQty.Size = new System.Drawing.Size(64, 21);
            this._nudPartAllocatedQty.TabIndex = 29;
            this._nudPartAllocatedQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // _lblAllocatedQuantity
            //
            this._lblAllocatedQuantity.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._lblAllocatedQuantity.Location = new System.Drawing.Point(873, 243);
            this._lblAllocatedQuantity.Name = "_lblAllocatedQuantity";
            this._lblAllocatedQuantity.Size = new System.Drawing.Size(64, 23);
            this._lblAllocatedQuantity.TabIndex = 30;
            this._lblAllocatedQuantity.Text = "Quantity";
            //
            // _btnAllUsed
            //
            this._btnAllUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAllUsed.Location = new System.Drawing.Point(1015, 243);
            this._btnAllUsed.Name = "_btnAllUsed";
            this._btnAllUsed.Size = new System.Drawing.Size(96, 23);
            this._btnAllUsed.TabIndex = 2;
            this._btnAllUsed.Text = "Used";
            this._btnAllUsed.Click += new System.EventHandler(this.btnAllUsed_Click);
            //
            // _Label35
            //
            this._Label35.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label35.Location = new System.Drawing.Point(160, 249);
            this._Label35.Name = "_Label35";
            this._Label35.Size = new System.Drawing.Size(104, 16);
            this._Label35.TabIndex = 28;
            this._Label35.Text = "Distributed";
            //
            // _Panel2
            //
            this._Panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Panel2.BackColor = System.Drawing.Color.Lime;
            this._Panel2.Location = new System.Drawing.Point(136, 247);
            this._Panel2.Name = "_Panel2";
            this._Panel2.Size = new System.Drawing.Size(16, 16);
            this._Panel2.TabIndex = 27;
            //
            // _Label34
            //
            this._Label34.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label34.Location = new System.Drawing.Point(32, 249);
            this._Label34.Name = "_Label34";
            this._Label34.Size = new System.Drawing.Size(104, 16);
            this._Label34.TabIndex = 26;
            this._Label34.Text = "Not Distributed";
            //
            // _Panel1
            //
            this._Panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Panel1.BackColor = System.Drawing.Color.Red;
            this._Panel1.Location = new System.Drawing.Point(8, 246);
            this._Panel1.Name = "_Panel1";
            this._Panel1.Size = new System.Drawing.Size(16, 16);
            this._Panel1.TabIndex = 25;
            //
            // _btnAllocatedNotUsed
            //
            this._btnAllocatedNotUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAllocatedNotUsed.Location = new System.Drawing.Point(1119, 243);
            this._btnAllocatedNotUsed.Name = "_btnAllocatedNotUsed";
            this._btnAllocatedNotUsed.Size = new System.Drawing.Size(96, 23);
            this._btnAllocatedNotUsed.TabIndex = 3;
            this._btnAllocatedNotUsed.Text = "Not Used";
            this._btnAllocatedNotUsed.Click += new System.EventHandler(this.btnAllocatedNotUsed_Click);
            //
            // _dgPartsProductsAllocated
            //
            this._dgPartsProductsAllocated.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgPartsProductsAllocated.DataMember = "";
            this._dgPartsProductsAllocated.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgPartsProductsAllocated.Location = new System.Drawing.Point(8, 18);
            this._dgPartsProductsAllocated.Name = "_dgPartsProductsAllocated";
            this._dgPartsProductsAllocated.Size = new System.Drawing.Size(1215, 222);
            this._dgPartsProductsAllocated.TabIndex = 1;
            this._dgPartsProductsAllocated.TabStop = false;
            this._dgPartsProductsAllocated.Click += new System.EventHandler(this.dgPartsProductsAllocated_Click);
            //
            // _lblQuantityWarning
            //
            this._lblQuantityWarning.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._lblQuantityWarning.AutoSize = true;
            this._lblQuantityWarning.Location = new System.Drawing.Point(603, 249);
            this._lblQuantityWarning.Name = "_lblQuantityWarning";
            this._lblQuantityWarning.Size = new System.Drawing.Size(241, 13);
            this._lblQuantityWarning.TabIndex = 31;
            this._lblQuantityWarning.Text = "The quantity ordered will be carried over";
            this._lblQuantityWarning.Visible = false;
            //
            // _grpUsed
            //
            this._grpUsed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._grpUsed.Controls.Add(this._lblEquipment);
            this._grpUsed.Controls.Add(this._lblSellPrice);
            this._grpUsed.Controls.Add(this._dgPartsAndProductsUsed);
            this._grpUsed.Controls.Add(this._btnAddPartProductUsed);
            this._grpUsed.Controls.Add(this._nudQuantityUsed);
            this._grpUsed.Controls.Add(this._txtNameUsed);
            this._grpUsed.Controls.Add(this._txtNumberUsed);
            this._grpUsed.Controls.Add(this._Label13);
            this._grpUsed.Controls.Add(this._Label15);
            this._grpUsed.Controls.Add(this._Label16);
            this._grpUsed.Controls.Add(this._btnRemovePartProductUsed);
            this._grpUsed.Controls.Add(this._btnFindProductUsed);
            this._grpUsed.Controls.Add(this._btnFindPartUsed);
            this._grpUsed.Location = new System.Drawing.Point(8, 289);
            this._grpUsed.Name = "_grpUsed";
            this._grpUsed.Size = new System.Drawing.Size(1231, 360);
            this._grpUsed.TabIndex = 2;
            this._grpUsed.TabStop = false;
            this._grpUsed.Text = "Parts && Products Used";
            //
            // _lblEquipment
            //
            this._lblEquipment.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._lblEquipment.Location = new System.Drawing.Point(853, 296);
            this._lblEquipment.Name = "_lblEquipment";
            this._lblEquipment.Size = new System.Drawing.Size(100, 23);
            this._lblEquipment.TabIndex = 24;
            this._lblEquipment.Text = "Equipment?";
            this._lblEquipment.Visible = false;
            //
            // _lblSellPrice
            //
            this._lblSellPrice.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._lblSellPrice.Location = new System.Drawing.Point(1007, 296);
            this._lblSellPrice.Name = "_lblSellPrice";
            this._lblSellPrice.Size = new System.Drawing.Size(100, 23);
            this._lblSellPrice.TabIndex = 23;
            this._lblSellPrice.Text = "SELL PRICE";
            this._lblSellPrice.Visible = false;
            //
            // _dgPartsAndProductsUsed
            //
            this._dgPartsAndProductsUsed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgPartsAndProductsUsed.DataMember = "";
            this._dgPartsAndProductsUsed.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgPartsAndProductsUsed.Location = new System.Drawing.Point(8, 13);
            this._dgPartsAndProductsUsed.Name = "_dgPartsAndProductsUsed";
            this._dgPartsAndProductsUsed.Size = new System.Drawing.Size(1215, 283);
            this._dgPartsAndProductsUsed.TabIndex = 1;
            this._dgPartsAndProductsUsed.TabStop = false;
            //
            // _btnAddPartProductUsed
            //
            this._btnAddPartProductUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAddPartProductUsed.Enabled = false;
            this._btnAddPartProductUsed.Location = new System.Drawing.Point(1119, 328);
            this._btnAddPartProductUsed.Name = "_btnAddPartProductUsed";
            this._btnAddPartProductUsed.Size = new System.Drawing.Size(96, 23);
            this._btnAddPartProductUsed.TabIndex = 5;
            this._btnAddPartProductUsed.Text = "PICK ITEM";
            this._btnAddPartProductUsed.Click += new System.EventHandler(this.btnAddPartProduct_Click);
            //
            // _nudQuantityUsed
            //
            this._nudQuantityUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._nudQuantityUsed.Location = new System.Drawing.Point(1047, 328);
            this._nudQuantityUsed.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._nudQuantityUsed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._nudQuantityUsed.Name = "_nudQuantityUsed";
            this._nudQuantityUsed.Size = new System.Drawing.Size(64, 21);
            this._nudQuantityUsed.TabIndex = 4;
            this._nudQuantityUsed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // _txtNameUsed
            //
            this._txtNameUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtNameUsed.Location = new System.Drawing.Point(312, 328);
            this._txtNameUsed.Name = "_txtNameUsed";
            this._txtNameUsed.ReadOnly = true;
            this._txtNameUsed.Size = new System.Drawing.Size(671, 21);
            this._txtNameUsed.TabIndex = 8;
            //
            // _txtNumberUsed
            //
            this._txtNumberUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._txtNumberUsed.Location = new System.Drawing.Point(72, 328);
            this._txtNumberUsed.Name = "_txtNumberUsed";
            this._txtNumberUsed.ReadOnly = true;
            this._txtNumberUsed.Size = new System.Drawing.Size(184, 21);
            this._txtNumberUsed.TabIndex = 7;
            //
            // _Label13
            //
            this._Label13.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._Label13.Location = new System.Drawing.Point(983, 328);
            this._Label13.Name = "_Label13";
            this._Label13.Size = new System.Drawing.Size(64, 23);
            this._Label13.TabIndex = 16;
            this._Label13.Text = "Quantity";
            //
            // _Label15
            //
            this._Label15.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label15.Location = new System.Drawing.Point(264, 328);
            this._Label15.Name = "_Label15";
            this._Label15.Size = new System.Drawing.Size(64, 23);
            this._Label15.TabIndex = 15;
            this._Label15.Text = "Name";
            //
            // _Label16
            //
            this._Label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Label16.Location = new System.Drawing.Point(8, 328);
            this._Label16.Name = "_Label16";
            this._Label16.Size = new System.Drawing.Size(72, 23);
            this._Label16.TabIndex = 12;
            this._Label16.Text = "Number";
            //
            // _btnRemovePartProductUsed
            //
            this._btnRemovePartProductUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnRemovePartProductUsed.Location = new System.Drawing.Point(1119, 296);
            this._btnRemovePartProductUsed.Name = "_btnRemovePartProductUsed";
            this._btnRemovePartProductUsed.Size = new System.Drawing.Size(96, 23);
            this._btnRemovePartProductUsed.TabIndex = 6;
            this._btnRemovePartProductUsed.Text = "Remove";
            this._btnRemovePartProductUsed.Click += new System.EventHandler(this.btnRemovePartProduct_Click);
            //
            // _btnFindProductUsed
            //
            this._btnFindProductUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnFindProductUsed.Location = new System.Drawing.Point(104, 296);
            this._btnFindProductUsed.Name = "_btnFindProductUsed";
            this._btnFindProductUsed.Size = new System.Drawing.Size(88, 23);
            this._btnFindProductUsed.TabIndex = 3;
            this._btnFindProductUsed.Text = "Find Product";
            this._btnFindProductUsed.Click += new System.EventHandler(this.btnFindProduct_Click);
            //
            // _btnFindPartUsed
            //
            this._btnFindPartUsed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnFindPartUsed.Location = new System.Drawing.Point(8, 296);
            this._btnFindPartUsed.Name = "_btnFindPartUsed";
            this._btnFindPartUsed.Size = new System.Drawing.Size(88, 23);
            this._btnFindPartUsed.TabIndex = 2;
            this._btnFindPartUsed.Text = "Find Part";
            this._btnFindPartUsed.Click += new System.EventHandler(this.btnFindPart_Click);
            //
            // _tpOutcomes
            //
            this._tpOutcomes.Controls.Add(this._grpOutcomes);
            this._tpOutcomes.Location = new System.Drawing.Point(4, 22);
            this._tpOutcomes.Name = "_tpOutcomes";
            this._tpOutcomes.Padding = new System.Windows.Forms.Padding(3);
            this._tpOutcomes.Size = new System.Drawing.Size(1247, 652);
            this._tpOutcomes.TabIndex = 7;
            this._tpOutcomes.Text = "Outcomes";
            this._tpOutcomes.UseVisualStyleBackColor = true;
            //
            // _grpOutcomes
            //
            this._grpOutcomes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._grpOutcomes.Controls.Add(this._grpSiteFuels);
            this._grpOutcomes.Controls.Add(this._cboNccRad);
            this._grpOutcomes.Controls.Add(this._Label76);
            this._grpOutcomes.Controls.Add(this._cboRecharge);
            this._grpOutcomes.Controls.Add(this._Label75);
            this._grpOutcomes.Controls.Add(this._chkRecharge);
            this._grpOutcomes.Controls.Add(this._chkGasServiceCompleted);
            this._grpOutcomes.Location = new System.Drawing.Point(8, 6);
            this._grpOutcomes.Name = "_grpOutcomes";
            this._grpOutcomes.Size = new System.Drawing.Size(1231, 640);
            this._grpOutcomes.TabIndex = 2;
            this._grpOutcomes.TabStop = false;
            this._grpOutcomes.Text = "Tick those that have been completed on this visit";
            //
            // _grpSiteFuels
            //
            this._grpSiteFuels.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._grpSiteFuels.Controls.Add(this._dgSiteFuel);
            this._grpSiteFuels.Location = new System.Drawing.Point(3, 17);
            this._grpSiteFuels.Margin = new System.Windows.Forms.Padding(0);
            this._grpSiteFuels.Name = "_grpSiteFuels";
            this._grpSiteFuels.Padding = new System.Windows.Forms.Padding(0);
            this._grpSiteFuels.Size = new System.Drawing.Size(437, 390);
            this._grpSiteFuels.TabIndex = 15;
            this._grpSiteFuels.TabStop = false;
            this._grpSiteFuels.Text = "Site Fuel";
            //
            // _dgSiteFuel
            //
            this._dgSiteFuel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgSiteFuel.DataMember = "";
            this._dgSiteFuel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgSiteFuel.Location = new System.Drawing.Point(5, 19);
            this._dgSiteFuel.Name = "_dgSiteFuel";
            this._dgSiteFuel.Size = new System.Drawing.Size(429, 366);
            this._dgSiteFuel.TabIndex = 11;
            this._dgSiteFuel.Click += new System.EventHandler(this.dgSiteFuel_Click);
            //
            // _cboNccRad
            //
            this._cboNccRad.FormattingEnabled = true;
            this._cboNccRad.Location = new System.Drawing.Point(649, 108);
            this._cboNccRad.Name = "_cboNccRad";
            this._cboNccRad.Size = new System.Drawing.Size(180, 21);
            this._cboNccRad.TabIndex = 9;
            //
            // _Label76
            //
            this._Label76.AutoSize = true;
            this._Label76.Location = new System.Drawing.Point(458, 111);
            this._Label76.Name = "_Label76";
            this._Label76.Size = new System.Drawing.Size(172, 13);
            this._Label76.TabIndex = 8;
            this._Label76.Text = "Ncc Radiator Removal / Refit";
            //
            // _cboRecharge
            //
            this._cboRecharge.FormattingEnabled = true;
            this._cboRecharge.Location = new System.Drawing.Point(649, 81);
            this._cboRecharge.Name = "_cboRecharge";
            this._cboRecharge.Size = new System.Drawing.Size(180, 21);
            this._cboRecharge.TabIndex = 7;
            this._cboRecharge.SelectedIndexChanged += new System.EventHandler(this.cboRecharge_SelectedIndexChanged);
            //
            // _Label75
            //
            this._Label75.AutoSize = true;
            this._Label75.Location = new System.Drawing.Point(458, 84);
            this._Label75.Name = "_Label75";
            this._Label75.Size = new System.Drawing.Size(83, 13);
            this._Label75.TabIndex = 6;
            this._Label75.Text = "Recharge To:";
            //
            // _chkRecharge
            //
            this._chkRecharge.AutoSize = true;
            this._chkRecharge.Location = new System.Drawing.Point(458, 59);
            this._chkRecharge.Name = "_chkRecharge";
            this._chkRecharge.Size = new System.Drawing.Size(80, 17);
            this._chkRecharge.TabIndex = 2;
            this._chkRecharge.Text = "Recharge";
            this._chkRecharge.UseVisualStyleBackColor = true;
            this._chkRecharge.CheckedChanged += new System.EventHandler(this.chkRecharge_CheckedChanged);
            //
            // _chkGasServiceCompleted
            //
            this._chkGasServiceCompleted.AutoSize = true;
            this._chkGasServiceCompleted.Location = new System.Drawing.Point(458, 36);
            this._chkGasServiceCompleted.Name = "_chkGasServiceCompleted";
            this._chkGasServiceCompleted.Size = new System.Drawing.Size(135, 17);
            this._chkGasServiceCompleted.TabIndex = 1;
            this._chkGasServiceCompleted.Text = "Service Completed";
            this._chkGasServiceCompleted.UseVisualStyleBackColor = true;
            //
            // _tpQC
            //
            this._tpQC.Controls.Add(this._GroupBox4);
            this._tpQC.Location = new System.Drawing.Point(4, 22);
            this._tpQC.Name = "_tpQC";
            this._tpQC.Padding = new System.Windows.Forms.Padding(3);
            this._tpQC.Size = new System.Drawing.Size(1247, 652);
            this._tpQC.TabIndex = 8;
            this._tpQC.Text = "QC";
            this._tpQC.UseVisualStyleBackColor = true;
            //
            // _GroupBox4
            //
            this._GroupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._GroupBox4.Controls.Add(this._grpQCField);
            this._GroupBox4.Controls.Add(this._grpOfficeQC);
            this._GroupBox4.Location = new System.Drawing.Point(8, 0);
            this._GroupBox4.Name = "_GroupBox4";
            this._GroupBox4.Size = new System.Drawing.Size(1235, 646);
            this._GroupBox4.TabIndex = 0;
            this._GroupBox4.TabStop = false;
            this._GroupBox4.Text = "QC";
            //
            // _grpQCField
            //
            this._grpQCField.Controls.Add(this._cboQCCustSig);
            this._grpQCField.Controls.Add(this._lblQCCustSig);
            this._grpQCField.Controls.Add(this._cboRecallEngineer);
            this._grpQCField.Controls.Add(this._Label49);
            this._grpQCField.Controls.Add(this._cboRecall);
            this._grpQCField.Controls.Add(this._Label48);
            this._grpQCField.Controls.Add(this._dtpQCDocumentsRecieved);
            this._grpQCField.Controls.Add(this._chkQCDocumentsRecieved);
            this._grpQCField.Controls.Add(this._txtQCPoorJobNotes);
            this._grpQCField.Controls.Add(this._lblQCPoorJobNotes);
            this._grpQCField.Controls.Add(this._cboQCEngineerPaymentRecieved);
            this._grpQCField.Controls.Add(this._lblQCEngineerMonies);
            this._grpQCField.Controls.Add(this._cboQCPaymentSelection);
            this._grpQCField.Controls.Add(this._lblQCEngPaymentMethod);
            this._grpQCField.Controls.Add(this._cboQCAppliance);
            this._grpQCField.Controls.Add(this._cboQCPaymentCollection);
            this._grpQCField.Controls.Add(this._lblQCPaymentCollection);
            this._grpQCField.Controls.Add(this._cboQCJobUploadTimescale);
            this._grpQCField.Controls.Add(this._lblQCAppliance);
            this._grpQCField.Controls.Add(this._cboQCParts);
            this._grpQCField.Controls.Add(this._lblJobUploadTimescale);
            this._grpQCField.Controls.Add(this._lblQCParts);
            this._grpQCField.Controls.Add(this._cboQCLGSR);
            this._grpQCField.Controls.Add(this._lblQCLGSR);
            this._grpQCField.Controls.Add(this._cboQCLabourTime);
            this._grpQCField.Controls.Add(this._lblQCLabourTime);
            this._grpQCField.Location = new System.Drawing.Point(9, 158);
            this._grpQCField.Name = "_grpQCField";
            this._grpQCField.Size = new System.Drawing.Size(1220, 342);
            this._grpQCField.TabIndex = 38;
            this._grpQCField.TabStop = false;
            this._grpQCField.Text = "Field";
            //
            // _cboQCCustSig
            //
            this._cboQCCustSig.FormattingEnabled = true;
            this._cboQCCustSig.Location = new System.Drawing.Point(251, 198);
            this._cboQCCustSig.Name = "_cboQCCustSig";
            this._cboQCCustSig.Size = new System.Drawing.Size(277, 21);
            this._cboQCCustSig.TabIndex = 84;
            //
            // _lblQCCustSig
            //
            this._lblQCCustSig.AutoSize = true;
            this._lblQCCustSig.Location = new System.Drawing.Point(12, 201);
            this._lblQCCustSig.Name = "_lblQCCustSig";
            this._lblQCCustSig.Size = new System.Drawing.Size(111, 13);
            this._lblQCCustSig.TabIndex = 83;
            this._lblQCCustSig.Text = "Customer Signed:";
            //
            // _cboRecallEngineer
            //
            this._cboRecallEngineer.FormattingEnabled = true;
            this._cboRecallEngineer.Location = new System.Drawing.Point(847, 27);
            this._cboRecallEngineer.Name = "_cboRecallEngineer";
            this._cboRecallEngineer.Size = new System.Drawing.Size(353, 21);
            this._cboRecallEngineer.TabIndex = 82;
            //
            // _Label49
            //
            this._Label49.AutoSize = true;
            this._Label49.Location = new System.Drawing.Point(584, 27);
            this._Label49.Name = "_Label49";
            this._Label49.Size = new System.Drawing.Size(100, 13);
            this._Label49.TabIndex = 81;
            this._Label49.Text = "Recall Engineer:";
            //
            // _cboRecall
            //
            this._cboRecall.FormattingEnabled = true;
            this._cboRecall.Location = new System.Drawing.Point(251, 24);
            this._cboRecall.Name = "_cboRecall";
            this._cboRecall.Size = new System.Drawing.Size(277, 21);
            this._cboRecall.TabIndex = 80;
            this._cboRecall.SelectedIndexChanged += new System.EventHandler(this.cboRecall_SelectedIndexChanged);
            //
            // _Label48
            //
            this._Label48.AutoSize = true;
            this._Label48.Location = new System.Drawing.Point(12, 27);
            this._Label48.Name = "_Label48";
            this._Label48.Size = new System.Drawing.Size(46, 13);
            this._Label48.TabIndex = 79;
            this._Label48.Text = "Recall:";
            //
            // _dtpQCDocumentsRecieved
            //
            this._dtpQCDocumentsRecieved.Location = new System.Drawing.Point(251, 236);
            this._dtpQCDocumentsRecieved.Name = "_dtpQCDocumentsRecieved";
            this._dtpQCDocumentsRecieved.Size = new System.Drawing.Size(180, 21);
            this._dtpQCDocumentsRecieved.TabIndex = 78;
            this._dtpQCDocumentsRecieved.Visible = false;
            //
            // _chkQCDocumentsRecieved
            //
            this._chkQCDocumentsRecieved.AutoSize = true;
            this._chkQCDocumentsRecieved.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._chkQCDocumentsRecieved.Location = new System.Drawing.Point(15, 236);
            this._chkQCDocumentsRecieved.Name = "_chkQCDocumentsRecieved";
            this._chkQCDocumentsRecieved.Size = new System.Drawing.Size(164, 17);
            this._chkQCDocumentsRecieved.TabIndex = 77;
            this._chkQCDocumentsRecieved.Text = "All documents recieved:";
            this._chkQCDocumentsRecieved.UseVisualStyleBackColor = true;
            this._chkQCDocumentsRecieved.CheckedChanged += new System.EventHandler(this.chkQCDocumentsRecieved_CheckedChanged);
            //
            // _txtQCPoorJobNotes
            //
            this._txtQCPoorJobNotes.Location = new System.Drawing.Point(759, 198);
            this._txtQCPoorJobNotes.Multiline = true;
            this._txtQCPoorJobNotes.Name = "_txtQCPoorJobNotes";
            this._txtQCPoorJobNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtQCPoorJobNotes.Size = new System.Drawing.Size(441, 111);
            this._txtQCPoorJobNotes.TabIndex = 76;
            this._txtQCPoorJobNotes.Tag = "";
            //
            // _lblQCPoorJobNotes
            //
            this._lblQCPoorJobNotes.AutoSize = true;
            this._lblQCPoorJobNotes.Location = new System.Drawing.Point(584, 198);
            this._lblQCPoorJobNotes.Name = "_lblQCPoorJobNotes";
            this._lblQCPoorJobNotes.Size = new System.Drawing.Size(95, 13);
            this._lblQCPoorJobNotes.TabIndex = 40;
            this._lblQCPoorJobNotes.Text = "Poor job notes:";
            //
            // _cboQCEngineerPaymentRecieved
            //
            this._cboQCEngineerPaymentRecieved.FormattingEnabled = true;
            this._cboQCEngineerPaymentRecieved.Location = new System.Drawing.Point(847, 162);
            this._cboQCEngineerPaymentRecieved.Name = "_cboQCEngineerPaymentRecieved";
            this._cboQCEngineerPaymentRecieved.Size = new System.Drawing.Size(353, 21);
            this._cboQCEngineerPaymentRecieved.TabIndex = 39;
            //
            // _lblQCEngineerMonies
            //
            this._lblQCEngineerMonies.AutoSize = true;
            this._lblQCEngineerMonies.Location = new System.Drawing.Point(584, 162);
            this._lblQCEngineerMonies.Name = "_lblQCEngineerMonies";
            this._lblQCEngineerMonies.Size = new System.Drawing.Size(251, 13);
            this._lblQCEngineerMonies.TabIndex = 38;
            this._lblQCEngineerMonies.Text = "Engineer Cash/Cheque payment recieved:";
            //
            // _cboQCPaymentSelection
            //
            this._cboQCPaymentSelection.FormattingEnabled = true;
            this._cboQCPaymentSelection.Location = new System.Drawing.Point(847, 130);
            this._cboQCPaymentSelection.Name = "_cboQCPaymentSelection";
            this._cboQCPaymentSelection.Size = new System.Drawing.Size(353, 21);
            this._cboQCPaymentSelection.TabIndex = 37;
            //
            // _lblQCEngPaymentMethod
            //
            this._lblQCEngPaymentMethod.AutoSize = true;
            this._lblQCEngPaymentMethod.Location = new System.Drawing.Point(584, 130);
            this._lblQCEngPaymentMethod.Name = "_lblQCEngPaymentMethod";
            this._lblQCEngPaymentMethod.Size = new System.Drawing.Size(207, 13);
            this._lblQCEngPaymentMethod.TabIndex = 36;
            this._lblQCEngPaymentMethod.Text = "Correct payment method selected:";
            //
            // _cboQCAppliance
            //
            this._cboQCAppliance.FormattingEnabled = true;
            this._cboQCAppliance.Location = new System.Drawing.Point(847, 96);
            this._cboQCAppliance.Name = "_cboQCAppliance";
            this._cboQCAppliance.Size = new System.Drawing.Size(353, 21);
            this._cboQCAppliance.TabIndex = 35;
            //
            // _cboQCPaymentCollection
            //
            this._cboQCPaymentCollection.FormattingEnabled = true;
            this._cboQCPaymentCollection.Location = new System.Drawing.Point(251, 159);
            this._cboQCPaymentCollection.Name = "_cboQCPaymentCollection";
            this._cboQCPaymentCollection.Size = new System.Drawing.Size(277, 21);
            this._cboQCPaymentCollection.TabIndex = 16;
            //
            // _lblQCPaymentCollection
            //
            this._lblQCPaymentCollection.AutoSize = true;
            this._lblQCPaymentCollection.Location = new System.Drawing.Point(12, 162);
            this._lblQCPaymentCollection.Name = "_lblQCPaymentCollection";
            this._lblQCPaymentCollection.Size = new System.Drawing.Size(116, 13);
            this._lblQCPaymentCollection.TabIndex = 15;
            this._lblQCPaymentCollection.Text = "Payment collected:";
            //
            // _cboQCJobUploadTimescale
            //
            this._cboQCJobUploadTimescale.FormattingEnabled = true;
            this._cboQCJobUploadTimescale.Location = new System.Drawing.Point(251, 127);
            this._cboQCJobUploadTimescale.Name = "_cboQCJobUploadTimescale";
            this._cboQCJobUploadTimescale.Size = new System.Drawing.Size(277, 21);
            this._cboQCJobUploadTimescale.TabIndex = 14;
            //
            // _lblQCAppliance
            //
            this._lblQCAppliance.AutoSize = true;
            this._lblQCAppliance.Location = new System.Drawing.Point(584, 96);
            this._lblQCAppliance.Name = "_lblQCAppliance";
            this._lblQCAppliance.Size = new System.Drawing.Size(122, 13);
            this._lblQCAppliance.TabIndex = 34;
            this._lblQCAppliance.Text = "Appliance recorded:";
            //
            // _cboQCParts
            //
            this._cboQCParts.FormattingEnabled = true;
            this._cboQCParts.Location = new System.Drawing.Point(251, 93);
            this._cboQCParts.Name = "_cboQCParts";
            this._cboQCParts.Size = new System.Drawing.Size(277, 21);
            this._cboQCParts.TabIndex = 33;
            //
            // _lblJobUploadTimescale
            //
            this._lblJobUploadTimescale.AutoSize = true;
            this._lblJobUploadTimescale.Location = new System.Drawing.Point(12, 130);
            this._lblJobUploadTimescale.Name = "_lblJobUploadTimescale";
            this._lblJobUploadTimescale.Size = new System.Drawing.Size(159, 13);
            this._lblJobUploadTimescale.TabIndex = 13;
            this._lblJobUploadTimescale.Text = "Job uploaded in timescale:";
            //
            // _lblQCParts
            //
            this._lblQCParts.AutoSize = true;
            this._lblQCParts.Location = new System.Drawing.Point(12, 96);
            this._lblQCParts.Name = "_lblQCParts";
            this._lblQCParts.Size = new System.Drawing.Size(102, 13);
            this._lblQCParts.TabIndex = 32;
            this._lblQCParts.Text = "Parts confirmed:";
            //
            // _cboQCLGSR
            //
            this._cboQCLGSR.FormattingEnabled = true;
            this._cboQCLGSR.Location = new System.Drawing.Point(847, 62);
            this._cboQCLGSR.Name = "_cboQCLGSR";
            this._cboQCLGSR.Size = new System.Drawing.Size(353, 21);
            this._cboQCLGSR.TabIndex = 31;
            //
            // _lblQCLGSR
            //
            this._lblQCLGSR.AutoSize = true;
            this._lblQCLGSR.Location = new System.Drawing.Point(584, 62);
            this._lblQCLGSR.Name = "_lblQCLGSR";
            this._lblQCLGSR.Size = new System.Drawing.Size(90, 13);
            this._lblQCLGSR.TabIndex = 30;
            this._lblQCLGSR.Text = "LGSR missing:";
            //
            // _cboQCLabourTime
            //
            this._cboQCLabourTime.FormattingEnabled = true;
            this._cboQCLabourTime.Location = new System.Drawing.Point(251, 59);
            this._cboQCLabourTime.Name = "_cboQCLabourTime";
            this._cboQCLabourTime.Size = new System.Drawing.Size(277, 21);
            this._cboQCLabourTime.TabIndex = 29;
            //
            // _lblQCLabourTime
            //
            this._lblQCLabourTime.AutoSize = true;
            this._lblQCLabourTime.Location = new System.Drawing.Point(12, 62);
            this._lblQCLabourTime.Name = "_lblQCLabourTime";
            this._lblQCLabourTime.Size = new System.Drawing.Size(167, 13);
            this._lblQCLabourTime.TabIndex = 28;
            this._lblQCLabourTime.Text = "Labour/Travel time missing:";
            //
            // _grpOfficeQC
            //
            this._grpOfficeQC.Controls.Add(this._cboQCPaymentMethod);
            this._grpOfficeQC.Controls.Add(this._lblPaymentMethod);
            this._grpOfficeQC.Controls.Add(this._cboQCOrderNo);
            this._grpOfficeQC.Controls.Add(this._lblOrderNo);
            this._grpOfficeQC.Controls.Add(this._cboQCScheduleOfRate);
            this._grpOfficeQC.Controls.Add(this._lblScheduleRate);
            this._grpOfficeQC.Controls.Add(this._cboQCCustomerDetails);
            this._grpOfficeQC.Controls.Add(this._lblCustomerDetails);
            this._grpOfficeQC.Controls.Add(this._cboQCJobType);
            this._grpOfficeQC.Controls.Add(this._lblJobTypeCorrect);
            this._grpOfficeQC.Controls.Add(this._cboFTFCode);
            this._grpOfficeQC.Controls.Add(this._Label74);
            this._grpOfficeQC.Location = new System.Drawing.Point(9, 20);
            this._grpOfficeQC.Name = "_grpOfficeQC";
            this._grpOfficeQC.Size = new System.Drawing.Size(1220, 132);
            this._grpOfficeQC.TabIndex = 30;
            this._grpOfficeQC.TabStop = false;
            this._grpOfficeQC.Text = "Office";
            //
            // _cboQCPaymentMethod
            //
            this._cboQCPaymentMethod.FormattingEnabled = true;
            this._cboQCPaymentMethod.Location = new System.Drawing.Point(251, 90);
            this._cboQCPaymentMethod.Name = "_cboQCPaymentMethod";
            this._cboQCPaymentMethod.Size = new System.Drawing.Size(277, 21);
            this._cboQCPaymentMethod.TabIndex = 37;
            //
            // _lblPaymentMethod
            //
            this._lblPaymentMethod.AutoSize = true;
            this._lblPaymentMethod.Location = new System.Drawing.Point(12, 93);
            this._lblPaymentMethod.Name = "_lblPaymentMethod";
            this._lblPaymentMethod.Size = new System.Drawing.Size(158, 13);
            this._lblPaymentMethod.TabIndex = 36;
            this._lblPaymentMethod.Text = "Payment method detailed:";
            //
            // _cboQCOrderNo
            //
            this._cboQCOrderNo.FormattingEnabled = true;
            this._cboQCOrderNo.Location = new System.Drawing.Point(759, 57);
            this._cboQCOrderNo.Name = "_cboQCOrderNo";
            this._cboQCOrderNo.Size = new System.Drawing.Size(441, 21);
            this._cboQCOrderNo.TabIndex = 35;
            //
            // _lblOrderNo
            //
            this._lblOrderNo.AutoSize = true;
            this._lblOrderNo.Location = new System.Drawing.Point(584, 60);
            this._lblOrderNo.Name = "_lblOrderNo";
            this._lblOrderNo.Size = new System.Drawing.Size(150, 13);
            this._lblOrderNo.TabIndex = 34;
            this._lblOrderNo.Text = "Order number attached: ";
            //
            // _cboQCScheduleOfRate
            //
            this._cboQCScheduleOfRate.FormattingEnabled = true;
            this._cboQCScheduleOfRate.Location = new System.Drawing.Point(251, 54);
            this._cboQCScheduleOfRate.Name = "_cboQCScheduleOfRate";
            this._cboQCScheduleOfRate.Size = new System.Drawing.Size(277, 21);
            this._cboQCScheduleOfRate.TabIndex = 33;
            //
            // _lblScheduleRate
            //
            this._lblScheduleRate.AutoSize = true;
            this._lblScheduleRate.Location = new System.Drawing.Point(12, 57);
            this._lblScheduleRate.Name = "_lblScheduleRate";
            this._lblScheduleRate.Size = new System.Drawing.Size(208, 13);
            this._lblScheduleRate.TabIndex = 32;
            this._lblScheduleRate.Text = "Correct schedule of rates selected:";
            //
            // _cboQCCustomerDetails
            //
            this._cboQCCustomerDetails.FormattingEnabled = true;
            this._cboQCCustomerDetails.Location = new System.Drawing.Point(759, 20);
            this._cboQCCustomerDetails.Name = "_cboQCCustomerDetails";
            this._cboQCCustomerDetails.Size = new System.Drawing.Size(441, 21);
            this._cboQCCustomerDetails.TabIndex = 31;
            //
            // _lblCustomerDetails
            //
            this._lblCustomerDetails.AutoSize = true;
            this._lblCustomerDetails.Location = new System.Drawing.Point(584, 23);
            this._lblCustomerDetails.Name = "_lblCustomerDetails";
            this._lblCustomerDetails.Size = new System.Drawing.Size(157, 13);
            this._lblCustomerDetails.TabIndex = 30;
            this._lblCustomerDetails.Text = "Correct customer details: ";
            //
            // _cboQCJobType
            //
            this._cboQCJobType.FormattingEnabled = true;
            this._cboQCJobType.Location = new System.Drawing.Point(251, 20);
            this._cboQCJobType.Name = "_cboQCJobType";
            this._cboQCJobType.Size = new System.Drawing.Size(277, 21);
            this._cboQCJobType.TabIndex = 29;
            //
            // _lblJobTypeCorrect
            //
            this._lblJobTypeCorrect.AutoSize = true;
            this._lblJobTypeCorrect.Location = new System.Drawing.Point(12, 23);
            this._lblJobTypeCorrect.Name = "_lblJobTypeCorrect";
            this._lblJobTypeCorrect.Size = new System.Drawing.Size(157, 13);
            this._lblJobTypeCorrect.TabIndex = 28;
            this._lblJobTypeCorrect.Text = "Correct job type selected:";
            //
            // _cboFTFCode
            //
            this._cboFTFCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._cboFTFCode.FormattingEnabled = true;
            this._cboFTFCode.Location = new System.Drawing.Point(759, 90);
            this._cboFTFCode.Name = "_cboFTFCode";
            this._cboFTFCode.Size = new System.Drawing.Size(441, 21);
            this._cboFTFCode.TabIndex = 27;
            //
            // _Label74
            //
            this._Label74.AutoSize = true;
            this._Label74.Location = new System.Drawing.Point(584, 93);
            this._Label74.Name = "_Label74";
            this._Label74.Size = new System.Drawing.Size(65, 13);
            this._Label74.TabIndex = 26;
            this._Label74.Text = "FTF Code:";
            //
            // _tpCharges
            //
            this._tpCharges.Controls.Add(this._gpbInvoice);
            this._tpCharges.Controls.Add(this._gpbCharges);
            this._tpCharges.Controls.Add(this._gpbAdditionalCharges);
            this._tpCharges.Controls.Add(this._gpbPartsAndProducts);
            this._tpCharges.Controls.Add(this._gpbTimesheets);
            this._tpCharges.Controls.Add(this._gpbScheduleOfRates);
            this._tpCharges.Location = new System.Drawing.Point(4, 22);
            this._tpCharges.Name = "_tpCharges";
            this._tpCharges.Size = new System.Drawing.Size(1247, 652);
            this._tpCharges.TabIndex = 4;
            this._tpCharges.Text = "Visit Charges";
            this._tpCharges.UseVisualStyleBackColor = true;
            //
            // _gpbInvoice
            //
            this._gpbInvoice.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Right;
            this._gpbInvoice.Controls.Add(this._cboDept);
            this._gpbInvoice.Controls.Add(this._btnCreateServ);
            this._gpbInvoice.Controls.Add(this._txtInvAmount);
            this._gpbInvoice.Controls.Add(this._txtCreditAmount);
            this._gpbInvoice.Controls.Add(this._txtInvNo);
            this._gpbInvoice.Controls.Add(this._cboPaidBy);
            this._gpbInvoice.Controls.Add(this._cboInvType);
            this._gpbInvoice.Controls.Add(this._cboVATRate);
            this._gpbInvoice.Controls.Add(this._txtPriceIncVAT);
            this._gpbInvoice.Controls.Add(this._txtAccountCode);
            this._gpbInvoice.Controls.Add(this._lblInvoiceAddressDetails);
            this._gpbInvoice.Controls.Add(this._txtNominalCode);
            this._gpbInvoice.Controls.Add(this._btnSearch);
            this._gpbInvoice.Controls.Add(this._dtpRaiseInvoiceOn);
            this._gpbInvoice.Controls.Add(this._cbxReadyToBeInvoiced);
            this._gpbInvoice.Controls.Add(this._lblInvAmount);
            this._gpbInvoice.Controls.Add(this._lblcredit);
            this._gpbInvoice.Controls.Add(this._lblInvNo);
            this._gpbInvoice.Controls.Add(this._lblPaidBy);
            this._gpbInvoice.Controls.Add(this._lblInvType);
            this._gpbInvoice.Controls.Add(this._lblVAT);
            this._gpbInvoice.Controls.Add(this._lblNominalCode);
            this._gpbInvoice.Controls.Add(this._lblAccountCode);
            this._gpbInvoice.Controls.Add(this._lblPriceInvVAT);
            this._gpbInvoice.Controls.Add(this._lblDepartment);
            this._gpbInvoice.Controls.Add(this._lblRaiseInvoiceOn);
            this._gpbInvoice.Location = new System.Drawing.Point(717, 425);
            this._gpbInvoice.Name = "_gpbInvoice";
            this._gpbInvoice.Size = new System.Drawing.Size(522, 221);
            this._gpbInvoice.TabIndex = 6;
            this._gpbInvoice.TabStop = false;
            this._gpbInvoice.Text = "Ready To Be Invoiced";
            //
            // _cboDept
            //
            this._cboDept.FormattingEnabled = true;
            this._cboDept.Location = new System.Drawing.Point(315, 26);
            this._cboDept.Name = "_cboDept";
            this._cboDept.Size = new System.Drawing.Size(98, 21);
            this._cboDept.TabIndex = 32;
            this._cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            //
            // _btnCreateServ
            //
            this._btnCreateServ.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnCreateServ.Location = new System.Drawing.Point(8, 192);
            this._btnCreateServ.Name = "_btnCreateServ";
            this._btnCreateServ.Size = new System.Drawing.Size(159, 23);
            this._btnCreateServ.TabIndex = 31;
            this._btnCreateServ.Text = "Create Multiple Services";
            this._btnCreateServ.Click += new System.EventHandler(this.btnCreateServ_Click);
            //
            // _txtInvAmount
            //
            this._txtInvAmount.Location = new System.Drawing.Point(340, 190);
            this._txtInvAmount.Name = "_txtInvAmount";
            this._txtInvAmount.ReadOnly = true;
            this._txtInvAmount.Size = new System.Drawing.Size(74, 21);
            this._txtInvAmount.TabIndex = 27;
            this._txtInvAmount.Visible = false;
            //
            // _txtCreditAmount
            //
            this._txtCreditAmount.Location = new System.Drawing.Point(425, 190);
            this._txtCreditAmount.Name = "_txtCreditAmount";
            this._txtCreditAmount.ReadOnly = true;
            this._txtCreditAmount.Size = new System.Drawing.Size(91, 21);
            this._txtCreditAmount.TabIndex = 25;
            this._txtCreditAmount.Visible = false;
            //
            // _txtInvNo
            //
            this._txtInvNo.Location = new System.Drawing.Point(251, 190);
            this._txtInvNo.Name = "_txtInvNo";
            this._txtInvNo.ReadOnly = true;
            this._txtInvNo.Size = new System.Drawing.Size(76, 21);
            this._txtInvNo.TabIndex = 23;
            this._txtInvNo.Visible = false;
            //
            // _cboPaidBy
            //
            this._cboPaidBy.FormattingEnabled = true;
            this._cboPaidBy.Location = new System.Drawing.Point(249, 106);
            this._cboPaidBy.Name = "_cboPaidBy";
            this._cboPaidBy.Size = new System.Drawing.Size(164, 21);
            this._cboPaidBy.TabIndex = 19;
            this._cboPaidBy.Visible = false;
            this._cboPaidBy.SelectedIndexChanged += new System.EventHandler(this.cboPaidBy_SelectedIndexChanged);
            //
            // _cboInvType
            //
            this._cboInvType.FormattingEnabled = true;
            this._cboInvType.Location = new System.Drawing.Point(249, 64);
            this._cboInvType.Name = "_cboInvType";
            this._cboInvType.Size = new System.Drawing.Size(164, 21);
            this._cboInvType.TabIndex = 17;
            this._cboInvType.Visible = false;
            this._cboInvType.SelectedIndexChanged += new System.EventHandler(this.cboInvType_SelectedIndexChanged);
            //
            // _cboVATRate
            //
            this._cboVATRate.FormattingEnabled = true;
            this._cboVATRate.Location = new System.Drawing.Point(425, 63);
            this._cboVATRate.Name = "_cboVATRate";
            this._cboVATRate.Size = new System.Drawing.Size(90, 21);
            this._cboVATRate.TabIndex = 13;
            this._cboVATRate.Visible = false;
            this._cboVATRate.SelectedIndexChanged += new System.EventHandler(this.cboVATRate_SelectedIndexChanged);
            //
            // _txtPriceIncVAT
            //
            this._txtPriceIncVAT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this._txtPriceIncVAT.Location = new System.Drawing.Point(425, 106);
            this._txtPriceIncVAT.Name = "_txtPriceIncVAT";
            this._txtPriceIncVAT.ReadOnly = true;
            this._txtPriceIncVAT.Size = new System.Drawing.Size(91, 21);
            this._txtPriceIncVAT.TabIndex = 3;
            this._txtPriceIncVAT.Visible = false;
            //
            // _txtAccountCode
            //
            this._txtAccountCode.Location = new System.Drawing.Point(425, 24);
            this._txtAccountCode.Name = "_txtAccountCode";
            this._txtAccountCode.Size = new System.Drawing.Size(91, 21);
            this._txtAccountCode.TabIndex = 12;
            this._txtAccountCode.Visible = false;
            this._txtAccountCode.TextChanged += new System.EventHandler(this.txtAccountCode_TextChanged);
            //
            // _lblInvoiceAddressDetails
            //
            this._lblInvoiceAddressDetails.Location = new System.Drawing.Point(8, 43);
            this._lblInvoiceAddressDetails.Name = "_lblInvoiceAddressDetails";
            this._lblInvoiceAddressDetails.Size = new System.Drawing.Size(231, 127);
            this._lblInvoiceAddressDetails.TabIndex = 4;
            this._lblInvoiceAddressDetails.Visible = false;
            //
            // _txtNominalCode
            //
            this._txtNominalCode.Location = new System.Drawing.Point(249, 24);
            this._txtNominalCode.Name = "_txtNominalCode";
            this._txtNominalCode.Size = new System.Drawing.Size(47, 21);
            this._txtNominalCode.TabIndex = 9;
            this._txtNominalCode.TextChanged += new System.EventHandler(this.txtNominalCode_TextChanged);
            //
            // _btnSearch
            //
            this._btnSearch.Location = new System.Drawing.Point(177, 16);
            this._btnSearch.Name = "_btnSearch";
            this._btnSearch.Size = new System.Drawing.Size(62, 23);
            this._btnSearch.TabIndex = 1;
            this._btnSearch.Text = "Change";
            this._btnSearch.Visible = false;
            this._btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // _dtpRaiseInvoiceOn
            //
            this._dtpRaiseInvoiceOn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._dtpRaiseInvoiceOn.Location = new System.Drawing.Point(425, 148);
            this._dtpRaiseInvoiceOn.Name = "_dtpRaiseInvoiceOn";
            this._dtpRaiseInvoiceOn.Size = new System.Drawing.Size(91, 21);
            this._dtpRaiseInvoiceOn.TabIndex = 6;
            this._dtpRaiseInvoiceOn.Visible = false;
            this._dtpRaiseInvoiceOn.ValueChanged += new System.EventHandler(this.dtpRaiseInvoiceOn_ValueChanged);
            //
            // _cbxReadyToBeInvoiced
            //
            this._cbxReadyToBeInvoiced.Location = new System.Drawing.Point(8, 22);
            this._cbxReadyToBeInvoiced.Name = "_cbxReadyToBeInvoiced";
            this._cbxReadyToBeInvoiced.Size = new System.Drawing.Size(180, 16);
            this._cbxReadyToBeInvoiced.TabIndex = 0;
            this._cbxReadyToBeInvoiced.Text = "Ready To Be Invoiced To:";
            this._cbxReadyToBeInvoiced.CheckedChanged += new System.EventHandler(this.cbxReadyToBeInvoiced_CheckedChanged);
            //
            // _lblInvAmount
            //
            this._lblInvAmount.Location = new System.Drawing.Point(338, 172);
            this._lblInvAmount.Name = "_lblInvAmount";
            this._lblInvAmount.Size = new System.Drawing.Size(76, 17);
            this._lblInvAmount.TabIndex = 28;
            this._lblInvAmount.Text = "Inv Ex VAT";
            this._lblInvAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblInvAmount.Visible = false;
            //
            // _lblcredit
            //
            this._lblcredit.Location = new System.Drawing.Point(420, 173);
            this._lblcredit.Name = "_lblcredit";
            this._lblcredit.Size = new System.Drawing.Size(92, 14);
            this._lblcredit.TabIndex = 26;
            this._lblcredit.Text = "Credit Ex VAT";
            this._lblcredit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblcredit.Visible = false;
            this._lblcredit.Click += new System.EventHandler(this.lblcredit_Click);
            //
            // _lblInvNo
            //
            this._lblInvNo.Location = new System.Drawing.Point(249, 170);
            this._lblInvNo.Name = "_lblInvNo";
            this._lblInvNo.Size = new System.Drawing.Size(91, 17);
            this._lblInvNo.TabIndex = 24;
            this._lblInvNo.Text = "Invoice No.";
            this._lblInvNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblInvNo.Visible = false;
            //
            // _lblPaidBy
            //
            this._lblPaidBy.Location = new System.Drawing.Point(248, 89);
            this._lblPaidBy.Name = "_lblPaidBy";
            this._lblPaidBy.Size = new System.Drawing.Size(130, 17);
            this._lblPaidBy.TabIndex = 20;
            this._lblPaidBy.Text = "Paid By";
            this._lblPaidBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblPaidBy.Visible = false;
            //
            // _lblInvType
            //
            this._lblInvType.Location = new System.Drawing.Point(248, 48);
            this._lblInvType.Name = "_lblInvType";
            this._lblInvType.Size = new System.Drawing.Size(130, 17);
            this._lblInvType.TabIndex = 18;
            this._lblInvType.Text = "Invoice Type";
            this._lblInvType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblInvType.Visible = false;
            //
            // _lblVAT
            //
            this._lblVAT.Location = new System.Drawing.Point(420, 48);
            this._lblVAT.Name = "_lblVAT";
            this._lblVAT.Size = new System.Drawing.Size(94, 17);
            this._lblVAT.TabIndex = 14;
            this._lblVAT.Text = "VAT Rate";
            this._lblVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblVAT.Visible = false;
            //
            // _lblNominalCode
            //
            this._lblNominalCode.Location = new System.Drawing.Point(246, 9);
            this._lblNominalCode.Name = "_lblNominalCode";
            this._lblNominalCode.Size = new System.Drawing.Size(60, 14);
            this._lblNominalCode.TabIndex = 7;
            this._lblNominalCode.Text = "Nominal";
            this._lblNominalCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _lblAccountCode
            //
            this._lblAccountCode.Location = new System.Drawing.Point(420, 8);
            this._lblAccountCode.Name = "_lblAccountCode";
            this._lblAccountCode.Size = new System.Drawing.Size(107, 14);
            this._lblAccountCode.TabIndex = 11;
            this._lblAccountCode.Text = "Account Code";
            this._lblAccountCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblAccountCode.Visible = false;
            //
            // _lblPriceInvVAT
            //
            this._lblPriceInvVAT.Location = new System.Drawing.Point(420, 87);
            this._lblPriceInvVAT.Name = "_lblPriceInvVAT";
            this._lblPriceInvVAT.Size = new System.Drawing.Size(92, 16);
            this._lblPriceInvVAT.TabIndex = 2;
            this._lblPriceInvVAT.Text = "Price Inc VAT";
            this._lblPriceInvVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblPriceInvVAT.Visible = false;
            //
            // _lblDepartment
            //
            this._lblDepartment.Location = new System.Drawing.Point(312, 7);
            this._lblDepartment.Name = "_lblDepartment";
            this._lblDepartment.Size = new System.Drawing.Size(79, 16);
            this._lblDepartment.TabIndex = 8;
            this._lblDepartment.Text = "Cost Centre";
            this._lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _lblRaiseInvoiceOn
            //
            this._lblRaiseInvoiceOn.Location = new System.Drawing.Point(423, 130);
            this._lblRaiseInvoiceOn.Name = "_lblRaiseInvoiceOn";
            this._lblRaiseInvoiceOn.Size = new System.Drawing.Size(99, 16);
            this._lblRaiseInvoiceOn.TabIndex = 5;
            this._lblRaiseInvoiceOn.Text = "Raise Inv Date:";
            this._lblRaiseInvoiceOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblRaiseInvoiceOn.Visible = false;
            //
            // _gpbCharges
            //
            this._gpbCharges.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left;
            this._gpbCharges.Controls.Add(this._chkShowJobCharges);
            this._gpbCharges.Controls.Add(this._GroupBox6);
            this._gpbCharges.Controls.Add(this._lblContractPerVisit);
            this._gpbCharges.Controls.Add(this._lblOR);
            this._gpbCharges.Controls.Add(this._Label30);
            this._gpbCharges.Controls.Add(this._lblQuotePercentageTotal);
            this._gpbCharges.Controls.Add(this._lblEquals);
            this._gpbCharges.Controls.Add(this._GroupBox9);
            this._gpbCharges.Controls.Add(this._lblPercent);
            this._gpbCharges.Controls.Add(this._txtPercentOfQuote);
            this._gpbCharges.Controls.Add(this._rdoPercentageOfQuoteValue);
            this._gpbCharges.Controls.Add(this._txtCharge);
            this._gpbCharges.Controls.Add(this._rdoChargeOther);
            this._gpbCharges.Controls.Add(this._rdoJobValue);
            this._gpbCharges.Controls.Add(this._txtJobValue);
            this._gpbCharges.Location = new System.Drawing.Point(8, 425);
            this._gpbCharges.Name = "_gpbCharges";
            this._gpbCharges.Size = new System.Drawing.Size(603, 221);
            this._gpbCharges.TabIndex = 3;
            this._gpbCharges.TabStop = false;
            this._gpbCharges.Text = "Charges";
            //
            // _chkShowJobCharges
            //
            this._chkShowJobCharges.AutoSize = true;
            this._chkShowJobCharges.Location = new System.Drawing.Point(41, 187);
            this._chkShowJobCharges.Name = "_chkShowJobCharges";
            this._chkShowJobCharges.Size = new System.Drawing.Size(183, 17);
            this._chkShowJobCharges.TabIndex = 17;
            this._chkShowJobCharges.Text = "Show All Charges From Job";
            this._chkShowJobCharges.UseVisualStyleBackColor = true;
            this._chkShowJobCharges.CheckedChanged += new System.EventHandler(this.chkShowJobCharges_CheckedChanged);
            //
            // _GroupBox6
            //
            this._GroupBox6.Controls.Add(this._Label82);
            this._GroupBox6.Controls.Add(this._Label78);
            this._GroupBox6.Controls.Add(this._Label77);
            this._GroupBox6.Controls.Add(this._txtProfitPerc);
            this._GroupBox6.Controls.Add(this._txtProfit);
            this._GroupBox6.Controls.Add(this._CostsToOption1);
            this._GroupBox6.Controls.Add(this._txtCosts);
            this._GroupBox6.Controls.Add(this._CostsToOption3);
            this._GroupBox6.Controls.Add(this._txtSale);
            this._GroupBox6.Controls.Add(this._CostsToOption2);
            this._GroupBox6.Location = new System.Drawing.Point(8, 93);
            this._GroupBox6.Name = "_GroupBox6";
            this._GroupBox6.Size = new System.Drawing.Size(583, 82);
            this._GroupBox6.TabIndex = 16;
            this._GroupBox6.TabStop = false;
            this._GroupBox6.Text = "Costs To:";
            //
            // _Label82
            //
            this._Label82.Location = new System.Drawing.Point(266, 17);
            this._Label82.Name = "_Label82";
            this._Label82.Size = new System.Drawing.Size(101, 16);
            this._Label82.TabIndex = 23;
            this._Label82.Text = "Sale";
            //
            // _Label78
            //
            this._Label78.Location = new System.Drawing.Point(266, 57);
            this._Label78.Name = "_Label78";
            this._Label78.Size = new System.Drawing.Size(101, 19);
            this._Label78.TabIndex = 22;
            this._Label78.Text = "Profit";
            //
            // _Label77
            //
            this._Label77.Location = new System.Drawing.Point(266, 36);
            this._Label77.Name = "_Label77";
            this._Label77.Size = new System.Drawing.Size(101, 20);
            this._Label77.TabIndex = 21;
            this._Label77.Text = "Costs";
            //
            // _txtProfitPerc
            //
            this._txtProfitPerc.Location = new System.Drawing.Point(501, 57);
            this._txtProfitPerc.Name = "_txtProfitPerc";
            this._txtProfitPerc.ReadOnly = true;
            this._txtProfitPerc.Size = new System.Drawing.Size(76, 21);
            this._txtProfitPerc.TabIndex = 20;
            //
            // _txtProfit
            //
            this._txtProfit.Location = new System.Drawing.Point(373, 57);
            this._txtProfit.Name = "_txtProfit";
            this._txtProfit.ReadOnly = true;
            this._txtProfit.Size = new System.Drawing.Size(120, 21);
            this._txtProfit.TabIndex = 19;
            //
            // _CostsToOption1
            //
            this._CostsToOption1.AutoSize = true;
            this._CostsToOption1.Location = new System.Drawing.Point(33, 16);
            this._CostsToOption1.Name = "_CostsToOption1";
            this._CostsToOption1.Size = new System.Drawing.Size(74, 17);
            this._CostsToOption1.TabIndex = 13;
            this._CostsToOption1.TabStop = true;
            this._CostsToOption1.Text = "Contract";
            this._CostsToOption1.UseVisualStyleBackColor = true;
            this._CostsToOption1.CheckedChanged += new System.EventHandler(this.radioButtonCostsTo_CheckedChanged);
            //
            // _txtCosts
            //
            this._txtCosts.Location = new System.Drawing.Point(373, 34);
            this._txtCosts.Name = "_txtCosts";
            this._txtCosts.ReadOnly = true;
            this._txtCosts.Size = new System.Drawing.Size(120, 21);
            this._txtCosts.TabIndex = 18;
            //
            // _CostsToOption3
            //
            this._CostsToOption3.AutoSize = true;
            this._CostsToOption3.Location = new System.Drawing.Point(33, 62);
            this._CostsToOption3.Name = "_CostsToOption3";
            this._CostsToOption3.Size = new System.Drawing.Size(77, 17);
            this._CostsToOption3.TabIndex = 15;
            this._CostsToOption3.TabStop = true;
            this._CostsToOption3.Text = "Warranty";
            this._CostsToOption3.UseVisualStyleBackColor = true;
            this._CostsToOption3.CheckedChanged += new System.EventHandler(this.radioButtonCostsTo_CheckedChanged);
            //
            // _txtSale
            //
            this._txtSale.Location = new System.Drawing.Point(373, 12);
            this._txtSale.Name = "_txtSale";
            this._txtSale.ReadOnly = true;
            this._txtSale.Size = new System.Drawing.Size(120, 21);
            this._txtSale.TabIndex = 17;
            //
            // _CostsToOption2
            //
            this._CostsToOption2.AutoSize = true;
            this._CostsToOption2.Location = new System.Drawing.Point(33, 39);
            this._CostsToOption2.Name = "_CostsToOption2";
            this._CostsToOption2.Size = new System.Drawing.Size(91, 17);
            this._CostsToOption2.TabIndex = 14;
            this._CostsToOption2.TabStop = true;
            this._CostsToOption2.Text = "Chargeable";
            this._CostsToOption2.UseVisualStyleBackColor = true;
            this._CostsToOption2.CheckedChanged += new System.EventHandler(this.radioButtonCostsTo_CheckedChanged);
            //
            // _lblContractPerVisit
            //
            this._lblContractPerVisit.BackColor = System.Drawing.SystemColors.Info;
            this._lblContractPerVisit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lblContractPerVisit.Location = new System.Drawing.Point(507, 14);
            this._lblContractPerVisit.Name = "_lblContractPerVisit";
            this._lblContractPerVisit.Size = new System.Drawing.Size(85, 56);
            this._lblContractPerVisit.TabIndex = 3;
            this._lblContractPerVisit.Text = "Contract Job - Invoicing Per Visit";
            this._lblContractPerVisit.Visible = false;
            //
            // _lblOR
            //
            this._lblOR.Location = new System.Drawing.Point(8, 58);
            this._lblOR.Name = "_lblOR";
            this._lblOR.Size = new System.Drawing.Size(27, 26);
            this._lblOR.TabIndex = 5;
            this._lblOR.Text = "OR";
            //
            // _Label30
            //
            this._Label30.Location = new System.Drawing.Point(8, 34);
            this._Label30.Name = "_Label30";
            this._Label30.Size = new System.Drawing.Size(27, 18);
            this._Label30.TabIndex = 2;
            this._Label30.Text = "OR";
            //
            // _lblQuotePercentageTotal
            //
            this._lblQuotePercentageTotal.Location = new System.Drawing.Point(537, 73);
            this._lblQuotePercentageTotal.Name = "_lblQuotePercentageTotal";
            this._lblQuotePercentageTotal.Size = new System.Drawing.Size(34, 16);
            this._lblQuotePercentageTotal.TabIndex = 11;
            this._lblQuotePercentageTotal.Text = "N/A";
            //
            // _lblEquals
            //
            this._lblEquals.Location = new System.Drawing.Point(522, 73);
            this._lblEquals.Name = "_lblEquals";
            this._lblEquals.Size = new System.Drawing.Size(24, 16);
            this._lblEquals.TabIndex = 10;
            this._lblEquals.Text = "=";
            //
            // _GroupBox9
            //
            this._GroupBox9.Controls.Add(this._rbStandard);
            this._GroupBox9.Controls.Add(this._rbSite);
            this._GroupBox9.Location = new System.Drawing.Point(354, 177);
            this._GroupBox9.Name = "_GroupBox9";
            this._GroupBox9.Size = new System.Drawing.Size(238, 31);
            this._GroupBox9.TabIndex = 83;
            this._GroupBox9.TabStop = false;
            this._GroupBox9.Visible = false;
            //
            // _rbStandard
            //
            this._rbStandard.AutoSize = true;
            this._rbStandard.Checked = true;
            this._rbStandard.Location = new System.Drawing.Point(114, 10);
            this._rbStandard.Name = "_rbStandard";
            this._rbStandard.Size = new System.Drawing.Size(123, 17);
            this._rbStandard.TabIndex = 1;
            this._rbStandard.TabStop = true;
            this._rbStandard.Text = "Standard Markup";
            this._rbStandard.UseVisualStyleBackColor = true;
            //
            // _rbSite
            //
            this._rbSite.AutoSize = true;
            this._rbSite.Location = new System.Drawing.Point(11, 11);
            this._rbSite.Name = "_rbSite";
            this._rbSite.Size = new System.Drawing.Size(95, 17);
            this._rbSite.TabIndex = 0;
            this._rbSite.Text = "Site markup";
            this._rbSite.UseVisualStyleBackColor = true;
            //
            // _lblPercent
            //
            this._lblPercent.Location = new System.Drawing.Point(506, 73);
            this._lblPercent.Name = "_lblPercent";
            this._lblPercent.Size = new System.Drawing.Size(24, 16);
            this._lblPercent.TabIndex = 9;
            this._lblPercent.Text = "%";
            //
            // _txtPercentOfQuote
            //
            this._txtPercentOfQuote.Location = new System.Drawing.Point(381, 69);
            this._txtPercentOfQuote.Name = "_txtPercentOfQuote";
            this._txtPercentOfQuote.Size = new System.Drawing.Size(120, 21);
            this._txtPercentOfQuote.TabIndex = 8;
            this._txtPercentOfQuote.TextChanged += new System.EventHandler(this.txtPercentOfQuote_TextChanged);
            //
            // _rdoPercentageOfQuoteValue
            //
            this._rdoPercentageOfQuoteValue.Location = new System.Drawing.Point(41, 66);
            this._rdoPercentageOfQuoteValue.Name = "_rdoPercentageOfQuoteValue";
            this._rdoPercentageOfQuoteValue.Size = new System.Drawing.Size(175, 24);
            this._rdoPercentageOfQuoteValue.TabIndex = 7;
            this._rdoPercentageOfQuoteValue.Text = "Charge % of Quote Value";
            this._rdoPercentageOfQuoteValue.CheckedChanged += new System.EventHandler(this.rdoPercentageOfQuoteValue_CheckedChanged);
            //
            // _txtCharge
            //
            this._txtCharge.Location = new System.Drawing.Point(381, 44);
            this._txtCharge.Name = "_txtCharge";
            this._txtCharge.ReadOnly = true;
            this._txtCharge.Size = new System.Drawing.Size(120, 21);
            this._txtCharge.TabIndex = 6;
            //
            // _rdoChargeOther
            //
            this._rdoChargeOther.Location = new System.Drawing.Point(41, 41);
            this._rdoChargeOther.Name = "_rdoChargeOther";
            this._rdoChargeOther.Size = new System.Drawing.Size(171, 24);
            this._rdoChargeOther.TabIndex = 4;
            this._rdoChargeOther.Text = "Charge Other";
            this._rdoChargeOther.CheckedChanged += new System.EventHandler(this.rdoChargeOther_CheckedChanged);
            //
            // _rdoJobValue
            //
            this._rdoJobValue.Location = new System.Drawing.Point(41, 16);
            this._rdoJobValue.Name = "_rdoJobValue";
            this._rdoJobValue.Size = new System.Drawing.Size(149, 24);
            this._rdoJobValue.TabIndex = 0;
            this._rdoJobValue.Text = "Charge Visit Value";
            this._rdoJobValue.CheckedChanged += new System.EventHandler(this.rdoJobValue_CheckedChanged);
            //
            // _txtJobValue
            //
            this._txtJobValue.Location = new System.Drawing.Point(381, 19);
            this._txtJobValue.Name = "_txtJobValue";
            this._txtJobValue.ReadOnly = true;
            this._txtJobValue.Size = new System.Drawing.Size(120, 21);
            this._txtJobValue.TabIndex = 1;
            //
            // _gpbAdditionalCharges
            //
            this._gpbAdditionalCharges.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._gpbAdditionalCharges.Controls.Add(this._lblAdditionalCharge);
            this._gpbAdditionalCharges.Controls.Add(this._btnAddAdditionalCharge);
            this._gpbAdditionalCharges.Controls.Add(this._txtAdditionalCharge);
            this._gpbAdditionalCharges.Controls.Add(this._btnRemoveAdditionalCharge);
            this._gpbAdditionalCharges.Controls.Add(this._txtAdditionalChargeDescription);
            this._gpbAdditionalCharges.Controls.Add(this._lblDescription);
            this._gpbAdditionalCharges.Controls.Add(this._txtAdditionalChargeTotal);
            this._gpbAdditionalCharges.Controls.Add(this._Label29);
            this._gpbAdditionalCharges.Controls.Add(this._dgAdditionalCharges);
            this._gpbAdditionalCharges.Location = new System.Drawing.Point(617, 184);
            this._gpbAdditionalCharges.Name = "_gpbAdditionalCharges";
            this._gpbAdditionalCharges.Size = new System.Drawing.Size(622, 233);
            this._gpbAdditionalCharges.TabIndex = 5;
            this._gpbAdditionalCharges.TabStop = false;
            this._gpbAdditionalCharges.Text = "Additional Charges";
            //
            // _lblAdditionalCharge
            //
            this._lblAdditionalCharge.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._lblAdditionalCharge.Location = new System.Drawing.Point(8, 206);
            this._lblAdditionalCharge.Name = "_lblAdditionalCharge";
            this._lblAdditionalCharge.Size = new System.Drawing.Size(74, 20);
            this._lblAdditionalCharge.TabIndex = 9;
            this._lblAdditionalCharge.Text = "Charge";
            //
            // _btnAddAdditionalCharge
            //
            this._btnAddAdditionalCharge.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnAddAdditionalCharge.Location = new System.Drawing.Point(539, 204);
            this._btnAddAdditionalCharge.Name = "_btnAddAdditionalCharge";
            this._btnAddAdditionalCharge.Size = new System.Drawing.Size(75, 23);
            this._btnAddAdditionalCharge.TabIndex = 8;
            this._btnAddAdditionalCharge.Text = "Add";
            this._btnAddAdditionalCharge.UseVisualStyleBackColor = true;
            this._btnAddAdditionalCharge.Click += new System.EventHandler(this.btnAddAdditionalCharge_Click);
            //
            // _txtAdditionalCharge
            //
            this._txtAdditionalCharge.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._txtAdditionalCharge.Location = new System.Drawing.Point(88, 203);
            this._txtAdditionalCharge.Name = "_txtAdditionalCharge";
            this._txtAdditionalCharge.Size = new System.Drawing.Size(96, 21);
            this._txtAdditionalCharge.TabIndex = 7;
            //
            // _btnRemoveAdditionalCharge
            //
            this._btnRemoveAdditionalCharge.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnRemoveAdditionalCharge.Location = new System.Drawing.Point(8, 129);
            this._btnRemoveAdditionalCharge.Name = "_btnRemoveAdditionalCharge";
            this._btnRemoveAdditionalCharge.Size = new System.Drawing.Size(75, 23);
            this._btnRemoveAdditionalCharge.TabIndex = 1;
            this._btnRemoveAdditionalCharge.Text = "Remove";
            this._btnRemoveAdditionalCharge.UseVisualStyleBackColor = true;
            this._btnRemoveAdditionalCharge.Click += new System.EventHandler(this.btnRemoveAdditionalCharge_Click);
            //
            // _txtAdditionalChargeDescription
            //
            this._txtAdditionalChargeDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtAdditionalChargeDescription.Location = new System.Drawing.Point(88, 157);
            this._txtAdditionalChargeDescription.Multiline = true;
            this._txtAdditionalChargeDescription.Name = "_txtAdditionalChargeDescription";
            this._txtAdditionalChargeDescription.Size = new System.Drawing.Size(526, 40);
            this._txtAdditionalChargeDescription.TabIndex = 5;
            //
            // _lblDescription
            //
            this._lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._lblDescription.Location = new System.Drawing.Point(8, 161);
            this._lblDescription.Name = "_lblDescription";
            this._lblDescription.Size = new System.Drawing.Size(74, 23);
            this._lblDescription.TabIndex = 4;
            this._lblDescription.Text = "Description";
            //
            // _txtAdditionalChargeTotal
            //
            this._txtAdditionalChargeTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._txtAdditionalChargeTotal.Location = new System.Drawing.Point(541, 131);
            this._txtAdditionalChargeTotal.Name = "_txtAdditionalChargeTotal";
            this._txtAdditionalChargeTotal.ReadOnly = true;
            this._txtAdditionalChargeTotal.Size = new System.Drawing.Size(71, 21);
            this._txtAdditionalChargeTotal.TabIndex = 3;
            //
            // _Label29
            //
            this._Label29.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._Label29.Location = new System.Drawing.Point(492, 131);
            this._Label29.Name = "_Label29";
            this._Label29.Size = new System.Drawing.Size(40, 23);
            this._Label29.TabIndex = 2;
            this._Label29.Text = "Total";
            this._Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _dgAdditionalCharges
            //
            this._dgAdditionalCharges.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgAdditionalCharges.DataMember = "";
            this._dgAdditionalCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgAdditionalCharges.Location = new System.Drawing.Point(8, 20);
            this._dgAdditionalCharges.Name = "_dgAdditionalCharges";
            this._dgAdditionalCharges.Size = new System.Drawing.Size(606, 109);
            this._dgAdditionalCharges.TabIndex = 0;
            //
            // _gpbPartsAndProducts
            //
            this._gpbPartsAndProducts.Controls.Add(this._txtPartsMarkUp);
            this._gpbPartsAndProducts.Controls.Add(this._chkPartsSelectAll);
            this._gpbPartsAndProducts.Controls.Add(this._txtPartProductCost);
            this._gpbPartsAndProducts.Controls.Add(this._txtPartsProductTotal);
            this._gpbPartsAndProducts.Controls.Add(this._Label28);
            this._gpbPartsAndProducts.Controls.Add(this._lblPPTotalCost);
            this._gpbPartsAndProducts.Controls.Add(this._lblPartsMarkUp);
            this._gpbPartsAndProducts.Controls.Add(this._dgPartsProductCharging);
            this._gpbPartsAndProducts.Location = new System.Drawing.Point(8, 184);
            this._gpbPartsAndProducts.Name = "_gpbPartsAndProducts";
            this._gpbPartsAndProducts.Size = new System.Drawing.Size(603, 233);
            this._gpbPartsAndProducts.TabIndex = 1;
            this._gpbPartsAndProducts.TabStop = false;
            this._gpbPartsAndProducts.Text = "Parts && Products";
            //
            // _txtPartsMarkUp
            //
            this._txtPartsMarkUp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtPartsMarkUp.Enabled = false;
            this._txtPartsMarkUp.Location = new System.Drawing.Point(405, 203);
            this._txtPartsMarkUp.Name = "_txtPartsMarkUp";
            this._txtPartsMarkUp.Size = new System.Drawing.Size(37, 21);
            this._txtPartsMarkUp.TabIndex = 81;
            this._txtPartsMarkUp.Visible = false;
            this._txtPartsMarkUp.Leave += new System.EventHandler(this.txtPartsMarkUp_Leave);
            //
            // _chkPartsSelectAll
            //
            this._chkPartsSelectAll.AutoCheck = false;
            this._chkPartsSelectAll.AutoSize = true;
            this._chkPartsSelectAll.Location = new System.Drawing.Point(6, 205);
            this._chkPartsSelectAll.Name = "_chkPartsSelectAll";
            this._chkPartsSelectAll.Size = new System.Drawing.Size(79, 17);
            this._chkPartsSelectAll.TabIndex = 80;
            this._chkPartsSelectAll.Text = "Select All";
            this._chkPartsSelectAll.UseVisualStyleBackColor = true;
            this._chkPartsSelectAll.Click += new System.EventHandler(this.chkPartsSelectAll_Click);
            //
            // _txtPartProductCost
            //
            this._txtPartProductCost.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtPartProductCost.Location = new System.Drawing.Point(252, 203);
            this._txtPartProductCost.Name = "_txtPartProductCost";
            this._txtPartProductCost.ReadOnly = true;
            this._txtPartProductCost.Size = new System.Drawing.Size(71, 21);
            this._txtPartProductCost.TabIndex = 2;
            //
            // _txtPartsProductTotal
            //
            this._txtPartsProductTotal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtPartsProductTotal.Location = new System.Drawing.Point(525, 202);
            this._txtPartsProductTotal.Name = "_txtPartsProductTotal";
            this._txtPartsProductTotal.ReadOnly = true;
            this._txtPartsProductTotal.Size = new System.Drawing.Size(71, 21);
            this._txtPartsProductTotal.TabIndex = 4;
            this._txtPartsProductTotal.Leave += new System.EventHandler(this.txtPartsProductTotal_Leave);
            //
            // _Label28
            //
            this._Label28.Location = new System.Drawing.Point(448, 202);
            this._Label28.Name = "_Label28";
            this._Label28.Size = new System.Drawing.Size(72, 21);
            this._Label28.TabIndex = 3;
            this._Label28.Text = "Total Price";
            this._Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _lblPPTotalCost
            //
            this._lblPPTotalCost.Location = new System.Drawing.Point(174, 203);
            this._lblPPTotalCost.Name = "_lblPPTotalCost";
            this._lblPPTotalCost.Size = new System.Drawing.Size(72, 21);
            this._lblPPTotalCost.TabIndex = 79;
            this._lblPPTotalCost.Text = "Total Cost";
            this._lblPPTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _lblPartsMarkUp
            //
            this._lblPartsMarkUp.Location = new System.Drawing.Point(329, 202);
            this._lblPartsMarkUp.Name = "_lblPartsMarkUp";
            this._lblPartsMarkUp.Size = new System.Drawing.Size(70, 21);
            this._lblPartsMarkUp.TabIndex = 82;
            this._lblPartsMarkUp.Text = "Mark Up %";
            this._lblPartsMarkUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblPartsMarkUp.Visible = false;
            //
            // _dgPartsProductCharging
            //
            this._dgPartsProductCharging.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgPartsProductCharging.DataMember = "";
            this._dgPartsProductCharging.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgPartsProductCharging.Location = new System.Drawing.Point(9, 16);
            this._dgPartsProductCharging.Name = "_dgPartsProductCharging";
            this._dgPartsProductCharging.Size = new System.Drawing.Size(587, 181);
            this._dgPartsProductCharging.TabIndex = 0;
            this._dgPartsProductCharging.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgPartsProductCharging_MouseUp);
            //
            // _gpbTimesheets
            //
            this._gpbTimesheets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._gpbTimesheets.Controls.Add(this._chkTimesheetSelectAll);
            this._gpbTimesheets.Controls.Add(this._txtEngineerCostTotal);
            this._gpbTimesheets.Controls.Add(this._txtTimesheetTotal);
            this._gpbTimesheets.Controls.Add(this._Label27);
            this._gpbTimesheets.Controls.Add(this._Label32);
            this._gpbTimesheets.Controls.Add(this._dgTimesheetCharges);
            this._gpbTimesheets.Location = new System.Drawing.Point(617, 8);
            this._gpbTimesheets.Name = "_gpbTimesheets";
            this._gpbTimesheets.Size = new System.Drawing.Size(622, 170);
            this._gpbTimesheets.TabIndex = 4;
            this._gpbTimesheets.TabStop = false;
            this._gpbTimesheets.Text = "Timesheets";
            //
            // _chkTimesheetSelectAll
            //
            this._chkTimesheetSelectAll.AutoCheck = false;
            this._chkTimesheetSelectAll.AutoSize = true;
            this._chkTimesheetSelectAll.Location = new System.Drawing.Point(6, 142);
            this._chkTimesheetSelectAll.Name = "_chkTimesheetSelectAll";
            this._chkTimesheetSelectAll.Size = new System.Drawing.Size(79, 17);
            this._chkTimesheetSelectAll.TabIndex = 81;
            this._chkTimesheetSelectAll.Text = "Select All";
            this._chkTimesheetSelectAll.UseVisualStyleBackColor = true;
            this._chkTimesheetSelectAll.Click += new System.EventHandler(this.chkTimesheetSelectAll_Click);
            //
            // _txtEngineerCostTotal
            //
            this._txtEngineerCostTotal.Location = new System.Drawing.Point(382, 140);
            this._txtEngineerCostTotal.Name = "_txtEngineerCostTotal";
            this._txtEngineerCostTotal.ReadOnly = true;
            this._txtEngineerCostTotal.Size = new System.Drawing.Size(71, 21);
            this._txtEngineerCostTotal.TabIndex = 2;
            //
            // _txtTimesheetTotal
            //
            this._txtTimesheetTotal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtTimesheetTotal.Location = new System.Drawing.Point(540, 140);
            this._txtTimesheetTotal.Name = "_txtTimesheetTotal";
            this._txtTimesheetTotal.ReadOnly = true;
            this._txtTimesheetTotal.Size = new System.Drawing.Size(71, 21);
            this._txtTimesheetTotal.TabIndex = 4;
            this._txtTimesheetTotal.Leave += new System.EventHandler(this.txtTimesheetTotal_Leave);
            //
            // _Label27
            //
            this._Label27.Location = new System.Drawing.Point(462, 140);
            this._Label27.Name = "_Label27";
            this._Label27.Size = new System.Drawing.Size(72, 21);
            this._Label27.TabIndex = 3;
            this._Label27.Text = "Total Price";
            this._Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _Label32
            //
            this._Label32.Location = new System.Drawing.Point(308, 139);
            this._Label32.Name = "_Label32";
            this._Label32.Size = new System.Drawing.Size(68, 23);
            this._Label32.TabIndex = 1;
            this._Label32.Text = "Total Cost";
            this._Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _dgTimesheetCharges
            //
            this._dgTimesheetCharges.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgTimesheetCharges.DataMember = "";
            this._dgTimesheetCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgTimesheetCharges.Location = new System.Drawing.Point(6, 17);
            this._dgTimesheetCharges.Name = "_dgTimesheetCharges";
            this._dgTimesheetCharges.Size = new System.Drawing.Size(606, 118);
            this._dgTimesheetCharges.TabIndex = 0;
            this._dgTimesheetCharges.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgTimesheetCharges_MouseUp);
            //
            // _gpbScheduleOfRates
            //
            this._gpbScheduleOfRates.Controls.Add(this._btnAddSoR);
            this._gpbScheduleOfRates.Controls.Add(this._txtScheduleOfRatesTotal);
            this._gpbScheduleOfRates.Controls.Add(this._dgScheduleOfRateCharges);
            this._gpbScheduleOfRates.Controls.Add(this._Label26);
            this._gpbScheduleOfRates.Location = new System.Drawing.Point(8, 8);
            this._gpbScheduleOfRates.Name = "_gpbScheduleOfRates";
            this._gpbScheduleOfRates.Size = new System.Drawing.Size(603, 170);
            this._gpbScheduleOfRates.TabIndex = 0;
            this._gpbScheduleOfRates.TabStop = false;
            this._gpbScheduleOfRates.Text = "Schedule Of Rates";
            //
            // _btnAddSoR
            //
            this._btnAddSoR.Location = new System.Drawing.Point(6, 141);
            this._btnAddSoR.Name = "_btnAddSoR";
            this._btnAddSoR.Size = new System.Drawing.Size(75, 23);
            this._btnAddSoR.TabIndex = 1;
            this._btnAddSoR.Text = "Add";
            this._btnAddSoR.Click += new System.EventHandler(this.btnAddSoR_Click);
            //
            // _txtScheduleOfRatesTotal
            //
            this._txtScheduleOfRatesTotal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._txtScheduleOfRatesTotal.Location = new System.Drawing.Point(521, 143);
            this._txtScheduleOfRatesTotal.Name = "_txtScheduleOfRatesTotal";
            this._txtScheduleOfRatesTotal.ReadOnly = true;
            this._txtScheduleOfRatesTotal.Size = new System.Drawing.Size(71, 21);
            this._txtScheduleOfRatesTotal.TabIndex = 3;
            //
            // _dgScheduleOfRateCharges
            //
            this._dgScheduleOfRateCharges.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._dgScheduleOfRateCharges.DataMember = "";
            this._dgScheduleOfRateCharges.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this._dgScheduleOfRateCharges.Location = new System.Drawing.Point(8, 17);
            this._dgScheduleOfRateCharges.Name = "_dgScheduleOfRateCharges";
            this._dgScheduleOfRateCharges.Size = new System.Drawing.Size(585, 121);
            this._dgScheduleOfRateCharges.TabIndex = 0;
            this._dgScheduleOfRateCharges.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgScheduleOfRateCharges_MouseUp);
            //
            // _Label26
            //
            this._Label26.Location = new System.Drawing.Point(481, 141);
            this._Label26.Name = "_Label26";
            this._Label26.Size = new System.Drawing.Size(39, 23);
            this._Label26.TabIndex = 2;
            this._Label26.Text = "Total";
            this._Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // _tpDocuments
            //
            this._tpDocuments.Location = new System.Drawing.Point(4, 22);
            this._tpDocuments.Name = "_tpDocuments";
            this._tpDocuments.Size = new System.Drawing.Size(1247, 652);
            this._tpDocuments.TabIndex = 9;
            this._tpDocuments.Text = "Documents";
            this._tpDocuments.UseVisualStyleBackColor = true;
            //
            // _tpPhotos
            //
            this._tpPhotos.Controls.Add(this._flPhotos);
            this._tpPhotos.Location = new System.Drawing.Point(4, 22);
            this._tpPhotos.Name = "_tpPhotos";
            this._tpPhotos.Size = new System.Drawing.Size(1247, 652);
            this._tpPhotos.TabIndex = 10;
            this._tpPhotos.Text = "Photos";
            this._tpPhotos.UseVisualStyleBackColor = true;
            this._tpPhotos.Enter += new System.EventHandler(this.tpPhotos_Enter);
            //
            // _flPhotos
            //
            this._flPhotos.AutoScroll = true;
            this._flPhotos.AutoSize = true;
            this._flPhotos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._flPhotos.Location = new System.Drawing.Point(0, 0);
            this._flPhotos.Name = "_flPhotos";
            this._flPhotos.Size = new System.Drawing.Size(1247, 652);
            this._flPhotos.TabIndex = 2;
            //
            // _btnClose
            //
            this._btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnClose.Location = new System.Drawing.Point(8, 750);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(64, 23);
            this._btnClose.TabIndex = 3;
            this._btnClose.Text = "Close";
            this._btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // _btnSave
            //
            this._btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnSave.Location = new System.Drawing.Point(1183, 750);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(64, 23);
            this._btnSave.TabIndex = 6;
            this._btnSave.Text = "Save";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // _cbxVisitLockDown
            //
            this._cbxVisitLockDown.BackColor = System.Drawing.SystemColors.Info;
            this._cbxVisitLockDown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this._cbxVisitLockDown.Location = new System.Drawing.Point(8, 32);
            this._cbxVisitLockDown.Name = "_cbxVisitLockDown";
            this._cbxVisitLockDown.Size = new System.Drawing.Size(296, 24);
            this._cbxVisitLockDown.TabIndex = 5;
            this._cbxVisitLockDown.Text = "Visit locked down and ready for charging";
            this._cbxVisitLockDown.UseVisualStyleBackColor = false;
            this._cbxVisitLockDown.CheckedChanged += new System.EventHandler(this.cbxVisitLockDown_CheckedChanged);
            //
            // _lblStatusWarning
            //
            this._lblStatusWarning.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left
            | System.Windows.Forms.AnchorStyles.Right;
            this._lblStatusWarning.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this._lblStatusWarning.ForeColor = System.Drawing.Color.Red;
            this._lblStatusWarning.Location = new System.Drawing.Point(312, 32);
            this._lblStatusWarning.Name = "_lblStatusWarning";
            this._lblStatusWarning.Size = new System.Drawing.Size(736, 23);
            this._lblStatusWarning.TabIndex = 6;
            this._lblStatusWarning.Text = "Reversing this status will result in the lost of charge changes";
            this._lblStatusWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblStatusWarning.Visible = false;
            //
            // _btnOrders
            //
            this._btnOrders.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnOrders.Location = new System.Drawing.Point(148, 750);
            this._btnOrders.Name = "_btnOrders";
            this._btnOrders.Size = new System.Drawing.Size(64, 23);
            this._btnOrders.TabIndex = 4;
            this._btnOrders.Text = "Orders";
            this._btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            //
            // _btnInvoice
            //
            this._btnInvoice.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnInvoice.Location = new System.Drawing.Point(289, 750);
            this._btnInvoice.Name = "_btnInvoice";
            this._btnInvoice.Size = new System.Drawing.Size(64, 23);
            this._btnInvoice.TabIndex = 5;
            this._btnInvoice.Text = "Invoice";
            this._btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            //
            // _btnPrint
            //
            this._btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnPrint.Location = new System.Drawing.Point(1064, 750);
            this._btnPrint.Name = "_btnPrint";
            this._btnPrint.Size = new System.Drawing.Size(103, 23);
            this._btnPrint.TabIndex = 7;
            this._btnPrint.Text = "Print QC";
            this._btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            //
            // _PrintMenu
            //
            this._PrintMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mnuGasSafetyInspectionBoilerServiceRecord});
            this._PrintMenu.Name = "PrintMenu";
            this._PrintMenu.Size = new System.Drawing.Size(302, 26);
            //
            // _mnuGasSafetyInspectionBoilerServiceRecord
            //
            this._mnuGasSafetyInspectionBoilerServiceRecord.Name = "_mnuGasSafetyInspectionBoilerServiceRecord";
            this._mnuGasSafetyInspectionBoilerServiceRecord.Size = new System.Drawing.Size(301, 22);
            this._mnuGasSafetyInspectionBoilerServiceRecord.Text = "Gas Safety Inspection/Boiler Service Record";
            //
            // _txtCurrentContract
            //
            this._txtCurrentContract.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this._txtCurrentContract.Location = new System.Drawing.Point(1116, 38);
            this._txtCurrentContract.Name = "_txtCurrentContract";
            this._txtCurrentContract.ReadOnly = true;
            this._txtCurrentContract.Size = new System.Drawing.Size(135, 21);
            this._txtCurrentContract.TabIndex = 27;
            //
            // _Label39
            //
            this._Label39.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this._Label39.Location = new System.Drawing.Point(1054, 39);
            this._Label39.Name = "_Label39";
            this._Label39.Size = new System.Drawing.Size(63, 16);
            this._Label39.TabIndex = 26;
            this._Label39.Text = "Contract:";
            //
            // _btnPrintGSR
            //
            this._btnPrintGSR.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnPrintGSR.Location = new System.Drawing.Point(1064, 750);
            this._btnPrintGSR.Name = "_btnPrintGSR";
            this._btnPrintGSR.Size = new System.Drawing.Size(105, 23);
            this._btnPrintGSR.TabIndex = 29;
            this._btnPrintGSR.Text = "Print GSR";
            this._btnPrintGSR.Click += new System.EventHandler(this.btnPrintGSR_Click);
            //
            // _btnPrintSVR
            //
            this._btnPrintSVR.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnPrintSVR.Location = new System.Drawing.Point(1057, 750);
            this._btnPrintSVR.Name = "_btnPrintSVR";
            this._btnPrintSVR.Size = new System.Drawing.Size(112, 23);
            this._btnPrintSVR.TabIndex = 30;
            this._btnPrintSVR.Text = "Print...";
            this._btnPrintSVR.Click += new System.EventHandler(this.btnPrintSVR_Click);
            //
            // _btnJob
            //
            this._btnJob.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._btnJob.Location = new System.Drawing.Point(78, 750);
            this._btnJob.Name = "_btnJob";
            this._btnJob.Size = new System.Drawing.Size(64, 23);
            this._btnJob.TabIndex = 31;
            this._btnJob.Text = "Job";
            this._btnJob.Click += new System.EventHandler(this.btnJob_Click);
            //
            // _lblRechargeTicked
            //
            this._lblRechargeTicked.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this._lblRechargeTicked.ForeColor = System.Drawing.Color.Red;
            this._lblRechargeTicked.Location = new System.Drawing.Point(75, 4);
            this._lblRechargeTicked.Name = "_lblRechargeTicked";
            this._lblRechargeTicked.Size = new System.Drawing.Size(457, 23);
            this._lblRechargeTicked.TabIndex = 32;
            this._lblRechargeTicked.Text = "Recharge is Selected";
            this._lblRechargeTicked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lblRechargeTicked.Visible = false;
            //
            // _btnShowVisits
            //
            this._btnShowVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this._btnShowVisits.Location = new System.Drawing.Point(687, 750);
            this._btnShowVisits.Name = "_btnShowVisits";
            this._btnShowVisits.Size = new System.Drawing.Size(99, 23);
            this._btnShowVisits.TabIndex = 33;
            this._btnShowVisits.Text = "Show History";
            this._btnShowVisits.UseVisualStyleBackColor = true;
            this._btnShowVisits.Click += new System.EventHandler(this.btnShowVisits_Click);
            //
            // _BottomToolStripPanel
            //
            this._BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this._BottomToolStripPanel.Name = "_BottomToolStripPanel";
            this._BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this._BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            //
            // _TopToolStripPanel
            //
            this._TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this._TopToolStripPanel.Name = "_TopToolStripPanel";
            this._TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this._TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            //
            // _RightToolStripPanel
            //
            this._RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this._RightToolStripPanel.Name = "_RightToolStripPanel";
            this._RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this._RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            //
            // _LeftToolStripPanel
            //
            this._LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this._LeftToolStripPanel.Name = "_LeftToolStripPanel";
            this._LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this._LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            //
            // _ContentPanel
            //
            this._ContentPanel.Size = new System.Drawing.Size(150, 150);
            //
            // _Button1
            //
            this._Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this._Button1.Location = new System.Drawing.Point(218, 750);
            this._Button1.Name = "_Button1";
            this._Button1.Size = new System.Drawing.Size(64, 23);
            this._Button1.TabIndex = 34;
            this._Button1.Text = "Cust";
            this._Button1.Click += new System.EventHandler(this.Button1_Click);
            //
            // _txtCustEmail
            //
            this._txtCustEmail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this._txtCustEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtCustEmail.Location = new System.Drawing.Point(718, 8);
            this._txtCustEmail.Name = "_txtCustEmail";
            this._txtCustEmail.ReadOnly = true;
            this._txtCustEmail.Size = new System.Drawing.Size(533, 14);
            this._txtCustEmail.TabIndex = 36;
            //
            // _SVRs
            //
            this._SVRs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._AllGasPaperworkToolStripMenuItem,
            this._svrmenu,
            this._JobSheetMenu,
            this._DomesticGSRToolStripMenuItem,
            this._WarningNoticeToolStripMenuItem,
            this._CommercialGSRToolStripMenuItem,
            this._QCResultsToolStripMenuItem,
            this._ElectricalMinorWorksToolStripMenuItem,
            this._CommercialCateringToolStripMenuItem,
            this._SaffronUnventedWorkshhetToolStripMenuItem,
            this._PropertyMaintenanceWorksheetToolStripMenuItem,
            this._ASHPWorksheetToolStripMenuItem,
            this._CommissioningChecklistToolStripMenuItem,
            this._HotWorksPermitToolStripMenuItem});
            this._SVRs.Name = "SVRs";
            this._SVRs.Size = new System.Drawing.Size(251, 312);
            //
            // _AllGasPaperworkToolStripMenuItem
            //
            this._AllGasPaperworkToolStripMenuItem.Name = "_AllGasPaperworkToolStripMenuItem";
            this._AllGasPaperworkToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._AllGasPaperworkToolStripMenuItem.Text = "All Safety Paperwork";
            this._AllGasPaperworkToolStripMenuItem.Click += new System.EventHandler(this.AllGasPaperworkToolStripMenuItem_Click);
            //
            // _svrmenu
            //
            this._svrmenu.Name = "_svrmenu";
            this._svrmenu.Size = new System.Drawing.Size(250, 22);
            this._svrmenu.Text = "SVR";
            this._svrmenu.Click += new System.EventHandler(this.svrmenu_Click);
            //
            // _JobSheetMenu
            //
            this._JobSheetMenu.Name = "_JobSheetMenu";
            this._JobSheetMenu.Size = new System.Drawing.Size(250, 22);
            this._JobSheetMenu.Text = "Job Sheet";
            this._JobSheetMenu.Click += new System.EventHandler(this.JobSheetMenu_Click);
            //
            // _DomesticGSRToolStripMenuItem
            //
            this._DomesticGSRToolStripMenuItem.Name = "_DomesticGSRToolStripMenuItem";
            this._DomesticGSRToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._DomesticGSRToolStripMenuItem.Text = "Domestic LSR";
            this._DomesticGSRToolStripMenuItem.Click += new System.EventHandler(this.DomesticGSRToolStripMenuItem_Click);
            //
            // _WarningNoticeToolStripMenuItem
            //
            this._WarningNoticeToolStripMenuItem.Name = "_WarningNoticeToolStripMenuItem";
            this._WarningNoticeToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._WarningNoticeToolStripMenuItem.Text = "Warning Notice";
            this._WarningNoticeToolStripMenuItem.Click += new System.EventHandler(this.WarningNoticeToolStripMenuItem_Click);
            //
            // _CommercialGSRToolStripMenuItem
            //
            this._CommercialGSRToolStripMenuItem.Name = "_CommercialGSRToolStripMenuItem";
            this._CommercialGSRToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._CommercialGSRToolStripMenuItem.Text = "Commercial LSR";
            this._CommercialGSRToolStripMenuItem.Click += new System.EventHandler(this.CommercialGSRToolStripMenuItem_Click);
            //
            // _QCResultsToolStripMenuItem
            //
            this._QCResultsToolStripMenuItem.Name = "_QCResultsToolStripMenuItem";
            this._QCResultsToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._QCResultsToolStripMenuItem.Text = "QC Results";
            this._QCResultsToolStripMenuItem.Click += new System.EventHandler(this.QCResultsToolStripMenuItem_Click);
            //
            // _ElectricalMinorWorksToolStripMenuItem
            //
            this._ElectricalMinorWorksToolStripMenuItem.Name = "_ElectricalMinorWorksToolStripMenuItem";
            this._ElectricalMinorWorksToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._ElectricalMinorWorksToolStripMenuItem.Text = "Electrical Minor Works";
            this._ElectricalMinorWorksToolStripMenuItem.Click += new System.EventHandler(this.ElectricalMinorWorksToolStripMenuItem_Click);
            //
            // _CommercialCateringToolStripMenuItem
            //
            this._CommercialCateringToolStripMenuItem.Name = "_CommercialCateringToolStripMenuItem";
            this._CommercialCateringToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._CommercialCateringToolStripMenuItem.Text = "Commercial Catering";
            this._CommercialCateringToolStripMenuItem.Click += new System.EventHandler(this.CommercialCateringToolStripMenuItem_Click);
            //
            // _SaffronUnventedWorkshhetToolStripMenuItem
            //
            this._SaffronUnventedWorkshhetToolStripMenuItem.Name = "_SaffronUnventedWorkshhetToolStripMenuItem";
            this._SaffronUnventedWorkshhetToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._SaffronUnventedWorkshhetToolStripMenuItem.Text = "Saffron Unvented Worksheet";
            this._SaffronUnventedWorkshhetToolStripMenuItem.Click += new System.EventHandler(this.SaffronUnventedWorkshhetToolStripMenuItem_Click);
            //
            // _PropertyMaintenanceWorksheetToolStripMenuItem
            //
            this._PropertyMaintenanceWorksheetToolStripMenuItem.Name = "_PropertyMaintenanceWorksheetToolStripMenuItem";
            this._PropertyMaintenanceWorksheetToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._PropertyMaintenanceWorksheetToolStripMenuItem.Text = "Property Maintenance Worksheet";
            this._PropertyMaintenanceWorksheetToolStripMenuItem.Click += new System.EventHandler(this.PropertyMaintenanceWorksheetToolStripMenuItem_Click);
            //
            // _ASHPWorksheetToolStripMenuItem
            //
            this._ASHPWorksheetToolStripMenuItem.Name = "_ASHPWorksheetToolStripMenuItem";
            this._ASHPWorksheetToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._ASHPWorksheetToolStripMenuItem.Text = "Waveney ASHP Worksheet";
            this._ASHPWorksheetToolStripMenuItem.Click += new System.EventHandler(this.ASHPWorksheetToolStripMenuItem_Click);
            //
            // _CommissioningChecklistToolStripMenuItem
            //
            this._CommissioningChecklistToolStripMenuItem.Name = "_CommissioningChecklistToolStripMenuItem";
            this._CommissioningChecklistToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._CommissioningChecklistToolStripMenuItem.Text = "Commissioning Checklist";
            this._CommissioningChecklistToolStripMenuItem.Click += new System.EventHandler(this.CommissioningChecklistToolStripMenuItem_Click);
            //
            // _HotWorksPermitToolStripMenuItem
            //
            this._HotWorksPermitToolStripMenuItem.Name = "_HotWorksPermitToolStripMenuItem";
            this._HotWorksPermitToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this._HotWorksPermitToolStripMenuItem.Text = "Hot Works Permit";
            this._HotWorksPermitToolStripMenuItem.Click += new System.EventHandler(this.HotWorksPermitToolStripMenuItem_Click);
            //
            // FRMEngineerVisit
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(1255, 780);
            this.Controls.Add(this._btnPrintSVR);
            this.Controls.Add(this._txtCustEmail);
            this.Controls.Add(this._Button1);
            this.Controls.Add(this._btnShowVisits);
            this.Controls.Add(this._lblRechargeTicked);
            this.Controls.Add(this._btnJob);
            this.Controls.Add(this._btnPrintGSR);
            this.Controls.Add(this._txtCurrentContract);
            this.Controls.Add(this._Label39);
            this.Controls.Add(this._btnPrint);
            this.Controls.Add(this._btnInvoice);
            this.Controls.Add(this._btnOrders);
            this.Controls.Add(this._lblStatusWarning);
            this.Controls.Add(this._cbxVisitLockDown);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._tcWorkSheet);
            this.MinimumSize = new System.Drawing.Size(936, 664);
            this.Name = "FRMEngineerVisit";
            this.Text = "Engineer Visit";

            this.Controls.SetChildIndex(this._tcWorkSheet, 0);
            this.Controls.SetChildIndex(this._btnClose, 0);
            this.Controls.SetChildIndex(this._btnSave, 0);
            this.Controls.SetChildIndex(this._cbxVisitLockDown, 0);
            this.Controls.SetChildIndex(this._lblStatusWarning, 0);
            this.Controls.SetChildIndex(this._btnOrders, 0);
            this.Controls.SetChildIndex(this._btnInvoice, 0);
            this.Controls.SetChildIndex(this._btnPrint, 0);
            this.Controls.SetChildIndex(this._Label39, 0);
            this.Controls.SetChildIndex(this._txtCurrentContract, 0);
            this.Controls.SetChildIndex(this._btnPrintGSR, 0);
            this.Controls.SetChildIndex(this._btnJob, 0);
            this.Controls.SetChildIndex(this._lblRechargeTicked, 0);
            this.Controls.SetChildIndex(this._btnShowVisits, 0);
            this.Controls.SetChildIndex(this._Button1, 0);
            this.Controls.SetChildIndex(this._txtCustEmail, 0);
            this.Controls.SetChildIndex(this._btnPrintSVR, 0);
            this._tcWorkSheet.ResumeLayout(false);
            this._tpMainDetails.ResumeLayout(false);
            this._tpMainDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._pbCustomerSignature).EndInit();
            ((System.ComponentModel.ISupportInitialize)this._pbEngineerSignature).EndInit();
            ((System.ComponentModel.ISupportInitialize)this._dgJobItems).EndInit();
            this._tpAppliances.ResumeLayout(false);
            this._gpAppliances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this._dgAssets).EndInit();
            this._tpWorksheets.ResumeLayout(false);
            this._grpAdditionalWorksheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this._dgAdditional).EndInit();
            this._grpAlarmInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this._DGSmokeComo).EndInit();
            this._grpVisitWorksheetExtended.ResumeLayout(false);
            this._grpVisitWorksheetExtended.PerformLayout();
            this._grpVisitDefects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this._dgVisitDefects).EndInit();
            this._grpApplianceWorksheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this._dgApplianceWorkSheets).EndInit();
            this._grpVisitWorksheet.ResumeLayout(false);
            this._grpVisitWorksheet.PerformLayout();
            this._tpTimesheets.ResumeLayout(false);
            this._tpTimesheets.PerformLayout();
            this._grpTimesheets.ResumeLayout(false);
            this._grpTimesheets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgTimeSheets).EndInit();
            this._tpPartsAndProducts.ResumeLayout(false);
            this._grpAllocated.ResumeLayout(false);
            this._grpAllocated.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._nudPartAllocatedQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)this._dgPartsProductsAllocated).EndInit();
            this._grpUsed.ResumeLayout(false);
            this._grpUsed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgPartsAndProductsUsed).EndInit();
            ((System.ComponentModel.ISupportInitialize)this._nudQuantityUsed).EndInit();
            this._tpOutcomes.ResumeLayout(false);
            this._grpOutcomes.ResumeLayout(false);
            this._grpOutcomes.PerformLayout();
            this._grpSiteFuels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this._dgSiteFuel).EndInit();
            this._tpQC.ResumeLayout(false);
            this._GroupBox4.ResumeLayout(false);
            this._grpQCField.ResumeLayout(false);
            this._grpQCField.PerformLayout();
            this._grpOfficeQC.ResumeLayout(false);
            this._grpOfficeQC.PerformLayout();
            this._tpCharges.ResumeLayout(false);
            this._gpbInvoice.ResumeLayout(false);
            this._gpbInvoice.PerformLayout();
            this._gpbCharges.ResumeLayout(false);
            this._gpbCharges.PerformLayout();
            this._GroupBox6.ResumeLayout(false);
            this._GroupBox6.PerformLayout();
            this._GroupBox9.ResumeLayout(false);
            this._GroupBox9.PerformLayout();
            this._gpbAdditionalCharges.ResumeLayout(false);
            this._gpbAdditionalCharges.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgAdditionalCharges).EndInit();
            this._gpbPartsAndProducts.ResumeLayout(false);
            this._gpbPartsAndProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgPartsProductCharging).EndInit();
            this._gpbTimesheets.ResumeLayout(false);
            this._gpbTimesheets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgTimesheetCharges).EndInit();
            this._gpbScheduleOfRates.ResumeLayout(false);
            this._gpbScheduleOfRates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this._dgScheduleOfRateCharges).EndInit();
            this._tpPhotos.ResumeLayout(false);
            this._tpPhotos.PerformLayout();
            this._PrintMenu.ResumeLayout(false);
            this._SVRs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DataTable dtEngineerGetAll = App.DB.Engineer.Engineer_GetAll().Table;
        private DataTable dtPassFailNA = App.DB.Picklists.GetAll(Enums.PickListTypes.PassFailNA).Table;
        private DataTable dtYesNoNA = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNoNA).Table;
        private DataTable dtYesNo = App.DB.Picklists.GetAll(Enums.PickListTypes.YesNo).Table;

        public void LoadMe(object sender, EventArgs e)
        {
            LoadForm(sender, e, this);
            SetupJobItemsDataGrid();
            SetupPartsAndProductsDataGrid();
            SetupTimesheetDataGrid();
            SetupAdditionalChargeDataGrid();
            SetupSoRChargeDataGrid();
            SetupPartProductDataGrid();
            SetupTimeSheetChargeDataGrid();
            SetupVisitDefectDataGrid();
            SetupApplianceWorksheetDataGrid();
            SetupAssetDataGrid();
            SetupAdditionalDataGrid();
            SetupSmokeComoDG();
            SetupSiteFuelsDatagrid();
            EngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_New_As_Object(Helper.MakeIntegerValid(get_GetParameter(0)));
            mnuAddChecklist.MenuItems.Clear();
            var timesheetTypesDT = App.DB.Picklists.GetAll(Enums.PickListTypes.TimeSheetTypes).Table;
            for (int i = timesheetTypesDT.Rows.Count - 1; i >= 0; i -= 1)
            {
                if (timesheetTypesDT.Rows[i].Field<string>("Name") == "Travelling" | timesheetTypesDT.Rows[i].Field<string>("Name") == "Working")
                {
                    timesheetTypesDT.Rows.RemoveAt(i);
                }
            }

            var argc = cboTimeSheetType;
            Combo.SetUpCombo(ref argc, timesheetTypesDT, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            try
            {
                if (get_GetParameter(1) is object)
                {
                    LogCalloutForm = ((UCVisitBreakdown)get_GetParameter(1)).OnControl.OnContol.OnForm;
                }
                else
                {
                    LogCalloutForm = null;
                }
            }
            catch
            {
                LogCalloutForm = null;
            }

            if (Job.JobTypeID == (int)Enums.JobTypes.Installation)
            {
                btnCreateServ.Visible = true;
            }
            else
            {
                btnCreateServ.Visible = false;
            }

            if (App.IsRFT)
            {
                tcWorkSheet.TabPages.Remove(tpAppliances);
                tcWorkSheet.TabPages.Remove(tpWorksheets);
                tcWorkSheet.TabPages.Remove(tpOutcomes);
            }

            if (App.loggedInUser.Admin == false)
            {
                // Only admin users can edit info
                foreach (Control c in tpMainDetails.Controls)
                    c.Enabled = false;
                txtOutcomeDetails.ReadOnly = true;
                txtNotesFromEngineer.ReadOnly = true;
                txtOutcomeDetails.Enabled = true;
                txtNotesFromEngineer.Enabled = true;
                foreach (Control c in tpCharges.Controls)
                    c.Enabled = false;
                foreach (Control c in tpTimesheets.Controls)
                    c.Enabled = false;
                btnAddAdd.Visible = false;
                btnAddApplianceWorksheet.Visible = false;
                btnAddVisitDefect.Visible = false;
                btnRemoveAdd.Visible = false;
                btnRemoveApplianceWorkSheet.Visible = false;
                btnRemoveVisitDefect.Visible = false;
                tcWorkSheet.TabPages.Remove(tpQC);
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

        private UCDocumentsList DocumentsControl;

        private DataView _VisitDefectDataview;

        public DataView VisitDefectDataview
        {
            get
            {
                return _VisitDefectDataview;
            }

            set
            {
                _VisitDefectDataview = value;
                _VisitDefectDataview.AllowNew = false;
                _VisitDefectDataview.AllowEdit = false;
                _VisitDefectDataview.AllowDelete = false;
                _VisitDefectDataview.Table.TableName = Enums.TableNames.tblEngineerVisitDefects.ToString();
                dgVisitDefects.DataSource = VisitDefectDataview;
            }
        }

        private DataRow SelectedVisitDefectDataRow
        {
            get
            {
                if (!(dgVisitDefects.CurrentRowIndex == -1))
                {
                    return VisitDefectDataview[dgVisitDefects.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _ApplianceWorkSheetDataview;

        public DataView ApplianceWorkSheetDataview
        {
            get
            {
                return _ApplianceWorkSheetDataview;
            }

            set
            {
                _ApplianceWorkSheetDataview = value;
                _ApplianceWorkSheetDataview.AllowNew = false;
                _ApplianceWorkSheetDataview.AllowEdit = false;
                _ApplianceWorkSheetDataview.AllowDelete = false;
                _ApplianceWorkSheetDataview.Table.TableName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
                dgApplianceWorkSheets.DataSource = ApplianceWorkSheetDataview;
            }
        }

        private DataView _AdditionalWorkSheetDataview;

        public DataView AdditionalWorkSheetDataview
        {
            get
            {
                return _AdditionalWorkSheetDataview;
            }

            set
            {
                _AdditionalWorkSheetDataview = value;
                _AdditionalWorkSheetDataview.AllowNew = false;
                _AdditionalWorkSheetDataview.AllowEdit = false;
                _AdditionalWorkSheetDataview.AllowDelete = false;
                _AdditionalWorkSheetDataview.Table.TableName = Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
                dgAdditional.DataSource = AdditionalWorkSheetDataview;
            }
        }

        private DataView _SmokeComoDataview;

        public DataView SmokeComoDataview
        {
            get
            {
                return _SmokeComoDataview;
            }

            set
            {
                _SmokeComoDataview = value;
                _SmokeComoDataview.AllowNew = false;
                _SmokeComoDataview.AllowEdit = false;
                _SmokeComoDataview.AllowDelete = false;
                _SmokeComoDataview.Table.TableName = "Alarms";
                DGSmokeComo.DataSource = SmokeComoDataview;
            }
        }

        private DataRow SelectedApplianceWorkSheetDataRow
        {
            get
            {
                if (!(dgApplianceWorkSheets.CurrentRowIndex == -1))
                {
                    return ApplianceWorkSheetDataview[dgApplianceWorkSheets.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataRow SelectedAdditionalWorkSheetDataRow
        {
            get
            {
                if (!(dgAdditional.CurrentRowIndex == -1))
                {
                    return AdditionalWorkSheetDataview[dgAdditional.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataRow SelectedSmokeComoDataRow
        {
            get
            {
                if (!(DGSmokeComo.CurrentRowIndex == -1))
                {
                    return SmokeComoDataview[DGSmokeComo.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private FRMLogCallout _LogCalloutForm = null;

        public FRMLogCallout LogCalloutForm
        {
            get
            {
                return _LogCalloutForm;
            }

            set
            {
                _LogCalloutForm = value;
            }
        }

        private bool _updating = true;

        public bool Updating
        {
            get
            {
                return _updating;
            }

            set
            {
                _updating = value;
            }
        }

        private bool _Loading = true;

        public bool Loading
        {
            get
            {
                return _Loading;
            }

            set
            {
                _Loading = value;
            }
        }

        private EngineerVisit _EngineerVisit;

        public EngineerVisit EngineerVisit
        {
            get
            {
                return _EngineerVisit;
            }

            set
            {
                _EngineerVisit = value;
                Populate();
                tpDocuments.Controls.Clear();
                DocumentsControl = new UCDocumentsList(Enums.TableNames.tblEngineerVisit, EngineerVisit.EngineerVisitID);
                tpDocuments.Controls.Add(DocumentsControl);
            }
        }

        private DataView _JobItems;

        private DataView JobItems
        {
            get
            {
                return _JobItems;
            }

            set
            {
                _JobItems = value;
                _JobItems.AllowNew = false;
                _JobItems.AllowEdit = true;
                _JobItems.AllowDelete = false;
                _JobItems.Table.TableName = Enums.TableNames.tblJobItem.ToString();
                dgJobItems.DataSource = JobItems;
            }
        }

        private int _PartProductIDUsed = 0;

        public int PartProductIDUsed
        {
            get
            {
                return _PartProductIDUsed;
            }

            set
            {
                _PartProductIDUsed = value;
            }
        }

        private string _PartProductReferenceUsed = "";

        public string PartProductReferenceUsed
        {
            get
            {
                return _PartProductReferenceUsed;
            }

            set
            {
                _PartProductReferenceUsed = value;
            }
        }

        private Entity.Sites.Site _theSite;

        private Entity.Sites.Site theSite
        {
            get
            {
                return _theSite;
            }

            set
            {
                _theSite = value;
                var currentContract = App.DB.ContractOriginal.Get_Current_ForSite(theSite.SiteID);
                if (currentContract is null)
                {
                    txtCurrentContract.Text = "Not on contract";
                }
                else
                {
                    txtCurrentContract.Text = currentContract.ContractType + " - Expires " + currentContract.ContractEndDate.ToString("dd/MM/yyyy");
                }
            }
        }

        private DataView _AssetsTable = null;

        public DataView AssetsDataView
        {
            get
            {
                return _AssetsTable;
            }

            set
            {
                _AssetsTable = value;
                _AssetsTable.Table.TableName = Enums.TableNames.tblAsset.ToString();
                _AssetsTable.AllowNew = false;
                _AssetsTable.AllowEdit = false;
                _AssetsTable.AllowDelete = false;
                dgAssets.DataSource = AssetsDataView;
            }
        }

        private Entity.EngineerVisitQCs.EngineerVisitQC _QC;

        private Entity.EngineerVisitQCs.EngineerVisitQC QC
        {
            get
            {
                return _QC;
            }

            set
            {
                _QC = value;
            }
        }

        private Entity.JobLock.JobLock _JobLock;

        private Entity.JobLock.JobLock JobLock
        {
            get
            {
                return _JobLock;
            }

            set
            {
                _JobLock = value;
            }
        }

        private Entity.CustomerCharges.CustomerCharge _customerCharge;

        public Entity.CustomerCharges.CustomerCharge CustomerCharge
        {
            get
            {
                return _customerCharge;
            }

            set
            {
                _customerCharge = value;
                if (!(Helper.MakeIntegerValid(_customerCharge?.CustomerChargeID) > 0))
                {
                    var settings = App.DB.Manager.Get();
                    _customerCharge.SetMileageRate = Helper.MakeDoubleValid(settings?.MileageRate);
                    _customerCharge.SetPartsMarkup = Helper.MakeDoubleValid(settings?.PartsMarkup);
                    _customerCharge.SetRatesMarkup = Helper.MakeDoubleValid(settings?.RatesMarkup);
                }
            }
        }

        private int loops = 0;
        private bool isSpecialPart = false;

        private void SetupVisitDefectDataGrid()
        {
            var tbStyle = dgVisitDefects.TableStyles[0];
            var Product = new DataGridLabelColumn();
            Product.Format = "";
            Product.FormatInfo = null;
            Product.HeaderText = "Product";
            Product.MappingName = "typemakemodel";
            Product.ReadOnly = true;
            Product.Width = 100;
            Product.NullText = "";
            tbStyle.GridColumnStyles.Add(Product);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial Num";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 100;
            SerialNum.NullText = "";
            tbStyle.GridColumnStyles.Add(SerialNum);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 100;
            Location.NullText = "";
            tbStyle.GridColumnStyles.Add(Location);
            var Category = new DataGridLabelColumn();
            Category.Format = "";
            Category.FormatInfo = null;
            Category.HeaderText = "Category";
            Category.MappingName = "Category";
            Category.ReadOnly = true;
            Category.Width = 100;
            Category.NullText = "";
            tbStyle.GridColumnStyles.Add(Category);
            var WarningNoticeIssued = new DataGridLabelColumn();
            WarningNoticeIssued.Format = "";
            WarningNoticeIssued.FormatInfo = null;
            WarningNoticeIssued.HeaderText = "Warning Notice Issued";
            WarningNoticeIssued.MappingName = "WarningNoticeIssued";
            WarningNoticeIssued.ReadOnly = true;
            WarningNoticeIssued.Width = 80;
            WarningNoticeIssued.NullText = "";
            tbStyle.GridColumnStyles.Add(WarningNoticeIssued);
            var Disconnected = new DataGridLabelColumn();
            Disconnected.Format = "";
            Disconnected.FormatInfo = null;
            Disconnected.HeaderText = "Disconnected";
            Disconnected.MappingName = "Disconnected";
            Disconnected.ReadOnly = true;
            Disconnected.Width = 80;
            Disconnected.NullText = "";
            tbStyle.GridColumnStyles.Add(Disconnected);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblEngineerVisitDefects.ToString();
            dgVisitDefects.TableStyles.Add(tbStyle);
        }

        private void SetupApplianceWorksheetDataGrid()
        {
            var tbStyle = dgApplianceWorkSheets.TableStyles[0];
            var Product = new DataGridLabelColumn();
            Product.Format = "";
            Product.FormatInfo = null;
            Product.HeaderText = "Product";
            Product.MappingName = "typemakemodel";
            Product.ReadOnly = true;
            Product.Width = 100;
            Product.NullText = "";
            tbStyle.GridColumnStyles.Add(Product);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial Num";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 100;
            SerialNum.NullText = "";
            tbStyle.GridColumnStyles.Add(SerialNum);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 100;
            Location.NullText = "";
            tbStyle.GridColumnStyles.Add(Location);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblEngineerVisitAssetWorkSheet.ToString();
            dgApplianceWorkSheets.TableStyles.Add(tbStyle);
        }

        private void SetupSmokeComoDG()
        {
            var tbStyle = DGSmokeComo.TableStyles[0];
            var Comments = new DataGridLabelColumn();
            Comments.Format = "";
            Comments.FormatInfo = null;
            Comments.HeaderText = "Location";
            Comments.MappingName = "Location";
            Comments.ReadOnly = true;
            Comments.Width = 120;
            Comments.NullText = "";
            tbStyle.GridColumnStyles.Add(Comments);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 80;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            var PowerType = new DataGridLabelColumn();
            PowerType.Format = "";
            PowerType.FormatInfo = null;
            PowerType.HeaderText = "Power Type";
            PowerType.MappingName = "PowerType";
            PowerType.ReadOnly = true;
            PowerType.Width = 100;
            PowerType.NullText = "";
            tbStyle.GridColumnStyles.Add(PowerType);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yyyy HH:mm";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Date";
            StartDateTime.MappingName = "Date";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 100;
            StartDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            var DateType = new DataGridLabelColumn();
            DateType.Format = "";
            DateType.FormatInfo = null;
            DateType.HeaderText = "Date Type";
            DateType.MappingName = "DateType";
            DateType.ReadOnly = true;
            DateType.Width = 80;
            DateType.NullText = "";
            tbStyle.GridColumnStyles.Add(DateType);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = "Alarms";
            DGSmokeComo.TableStyles.Add(tbStyle);
        }

        private void SetupAdditionalDataGrid()
        {
            var tbStyle = dgAdditional.TableStyles[0];
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 250;
            Type.NullText = "";
            tbStyle.GridColumnStyles.Add(Type);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblEngineerVisitAdditionalChecks.ToString();
            dgAdditional.TableStyles.Add(tbStyle);
        }

        private void SetupJobItemsDataGrid()
        {
            Helper.SetUpDataGrid(dgJobItems);
            var tStyle = dgJobItems.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgJobItems.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Summary = new DataGridLabelColumn();
            Summary.Format = "";
            Summary.FormatInfo = null;
            Summary.HeaderText = "Summary";
            Summary.MappingName = "Summary";
            Summary.ReadOnly = true;
            Summary.Width = 600;
            Summary.NullText = "";
            tStyle.GridColumnStyles.Add(Summary);
            var NumAllocated = new DataGridLabelColumn();
            NumAllocated.Format = "";
            NumAllocated.FormatInfo = null;
            NumAllocated.HeaderText = "No. Of Units Allocated to Job";
            NumAllocated.MappingName = "NumAllocated";
            NumAllocated.ReadOnly = true;
            NumAllocated.Width = 75;
            NumAllocated.NullText = "";
            tStyle.GridColumnStyles.Add(NumAllocated);
            var NumUnitsUsed = new DataGridEditableTextBoxColumn();
            NumUnitsUsed.Format = "G";
            NumUnitsUsed.FormatInfo = null;
            NumUnitsUsed.HeaderText = "No.Of Units Used (Type value in cell)";
            NumUnitsUsed.MappingName = "NumUnitsUsed";
            NumUnitsUsed.ReadOnly = false;
            NumUnitsUsed.Width = 75;
            NumUnitsUsed.NullText = "";
            tStyle.GridColumnStyles.Add(NumUnitsUsed);
            tStyle.MappingName = Enums.TableNames.tblJobItem.ToString();
            dgJobItems.TableStyles.Add(tStyle);
        }

        public void SetupPartsAndProductsDataGrid()
        {
            Helper.SetUpDataGrid(dgPartsAndProductsUsed);
            var tStyle = dgPartsAndProductsUsed.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "type";
            type.ReadOnly = true;
            type.Width = 100;
            type.NullText = "";
            tStyle.GridColumnStyles.Add(type);
            var number = new DataGridLabelColumn();
            number.Format = "";
            number.FormatInfo = null;
            number.HeaderText = "Number";
            number.MappingName = "number";
            number.ReadOnly = true;
            number.Width = 250;
            number.NullText = "";
            tStyle.GridColumnStyles.Add(number);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 300;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var quantity = new DataGridLabelColumn();
            quantity.Format = "";
            quantity.FormatInfo = null;
            quantity.HeaderText = "Qty";
            quantity.MappingName = "quantity";
            quantity.ReadOnly = true;
            quantity.Width = 60;
            quantity.NullText = "";
            tStyle.GridColumnStyles.Add(quantity);
            var reference = new DataGridLabelColumn();
            reference.Format = "";
            reference.FormatInfo = null;
            reference.HeaderText = "Reference";
            reference.MappingName = "reference";
            reference.ReadOnly = true;
            reference.Width = 100;
            reference.NullText = "";
            tStyle.GridColumnStyles.Add(reference);
            var asset = new DataGridLabelColumn();
            asset.Format = "";
            asset.FormatInfo = null;
            asset.HeaderText = "Appliance";
            asset.MappingName = "asset";
            asset.ReadOnly = true;
            asset.Width = 75;
            asset.NullText = "";
            tStyle.GridColumnStyles.Add(asset);
            var BuyPrice = new DataGridLabelColumn();
            BuyPrice.Format = "C";
            BuyPrice.FormatInfo = null;
            BuyPrice.HeaderText = "Buy Price";
            BuyPrice.MappingName = "BuyPrice";
            BuyPrice.ReadOnly = true;
            BuyPrice.Width = 75;
            BuyPrice.NullText = "0";
            tStyle.GridColumnStyles.Add(BuyPrice);
            var SellPrice = new DataGridLabelColumn();
            SellPrice.Format = "C";
            SellPrice.FormatInfo = null;
            SellPrice.HeaderText = "Sell Price";
            SellPrice.MappingName = "SellPrice";
            SellPrice.ReadOnly = true;
            SellPrice.Width = 75;
            SellPrice.NullText = "0";
            tStyle.GridColumnStyles.Add(SellPrice);
            var OrderPartID = new DataGridLabelColumn();
            OrderPartID.Format = "";
            OrderPartID.FormatInfo = null;
            OrderPartID.HeaderText = "";
            OrderPartID.MappingName = "OrderPartID";
            OrderPartID.ReadOnly = true;
            OrderPartID.Width = 5;
            OrderPartID.NullText = "";
            tStyle.GridColumnStyles.Add(OrderPartID);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProducts.ToString();
            dgPartsAndProductsUsed.TableStyles.Add(tStyle);
        }

        private void SetupTimesheetDataGrid()
        {
            var tbStyle = dgTimeSheets.TableStyles[0];
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yyyy HH:mm";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Start Date&Time";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 180;
            StartDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(StartDateTime);
            var EndDateTime = new DataGridLabelColumn();
            EndDateTime.Format = "dd/MM/yyyy HH:mm";
            EndDateTime.FormatInfo = null;
            EndDateTime.HeaderText = "End Date&Time";
            EndDateTime.MappingName = "EndDateTime";
            EndDateTime.ReadOnly = true;
            EndDateTime.Width = 180;
            EndDateTime.NullText = "";
            tbStyle.GridColumnStyles.Add(EndDateTime);
            var TimeSheetType = new DataGridLabelColumn();
            TimeSheetType.Format = "";
            TimeSheetType.FormatInfo = null;
            TimeSheetType.HeaderText = "Timesheet Type";
            TimeSheetType.MappingName = "TimeSheetType";
            TimeSheetType.ReadOnly = true;
            TimeSheetType.Width = 180;
            TimeSheetType.NullText = "";
            tbStyle.GridColumnStyles.Add(TimeSheetType);
            var Comments = new DataGridLabelColumn();
            Comments.Format = "";
            Comments.FormatInfo = null;
            Comments.HeaderText = "Comments";
            Comments.MappingName = "Comments";
            Comments.ReadOnly = true;
            Comments.Width = 180;
            Comments.NullText = "";
            tbStyle.GridColumnStyles.Add(Comments);
            tbStyle.ReadOnly = true;
            tbStyle.MappingName = Enums.TableNames.tblEngineerVisitTimesheet.ToString();
            dgTimeSheets.TableStyles.Add(tbStyle);
        }

        public void SetupAssetDataGrid()
        {
            Helper.SetUpDataGrid(dgAssets);
            var tStyle = dgAssets.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            dgAssets.ReadOnly = false;
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Product = new DataGridLabelColumn();
            Product.Format = "";
            Product.FormatInfo = null;
            Product.HeaderText = "Product";
            Product.MappingName = "Product";
            Product.ReadOnly = true;
            Product.Width = 250;
            Product.NullText = "";
            tStyle.GridColumnStyles.Add(Product);
            var Location = new DataGridLabelColumn();
            Location.Format = "";
            Location.FormatInfo = null;
            Location.HeaderText = "Location";
            Location.MappingName = "Location";
            Location.ReadOnly = true;
            Location.Width = 75;
            Location.NullText = "";
            tStyle.GridColumnStyles.Add(Location);
            var SerialNum = new DataGridLabelColumn();
            SerialNum.Format = "";
            SerialNum.FormatInfo = null;
            SerialNum.HeaderText = "Serial";
            SerialNum.MappingName = "SerialNum";
            SerialNum.ReadOnly = true;
            SerialNum.Width = 75;
            SerialNum.NullText = "";
            tStyle.GridColumnStyles.Add(SerialNum);
            var GCNum = new DataGridLabelColumn();
            GCNum.Format = "";
            GCNum.FormatInfo = null;
            GCNum.HeaderText = "GC Number";
            GCNum.MappingName = "GCNumber";
            GCNum.ReadOnly = true;
            GCNum.Width = 75;
            GCNum.NullText = "";
            tStyle.GridColumnStyles.Add(GCNum);
            var YearOfManufacture = new DataGridLabelColumn();
            YearOfManufacture.Format = "";
            YearOfManufacture.FormatInfo = null;
            YearOfManufacture.HeaderText = "Year Of Manufacture";
            YearOfManufacture.MappingName = "YearOfManufacture";
            YearOfManufacture.ReadOnly = true;
            YearOfManufacture.Width = 75;
            YearOfManufacture.NullText = "";
            tStyle.GridColumnStyles.Add(YearOfManufacture);
            var ApproxValue = new DataGridLabelColumn();
            ApproxValue.Format = "C";
            ApproxValue.FormatInfo = null;
            ApproxValue.HeaderText = "Approx.Value";
            ApproxValue.MappingName = "ApproximateValue";
            ApproxValue.ReadOnly = true;
            ApproxValue.Width = 75;
            ApproxValue.NullText = "";
            tStyle.GridColumnStyles.Add(ApproxValue);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblAsset.ToString();
            dgAssets.TableStyles.Add(tStyle);
            Helper.RemoveEventHandlers(dgAssets);
        }

        private void FRMEngineerVisit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EngVisitCharge is object)
            {
                if (cbxReadyToBeInvoiced.Checked == true)
                {
                    string errorMsg = "";
                    if (EngVisitCharge.NominalCode.Trim().Length == 0)
                    {
                        errorMsg += "* Nominal Code is Mandatory" + Environment.NewLine;
                    }

                    if (EngVisitCharge.ForSageAccountCode.Trim().Length == 0)
                    {
                        errorMsg += "* Account Code is Mandatory" + Environment.NewLine;
                    }

                    if (EngVisitCharge.Department.Trim().Length == 0)
                    {
                        errorMsg += "* Department is Mandatory" + Environment.NewLine;
                    }

                    if (errorMsg.Length > 0)
                    {
                        e.Cancel = true;
                        App.ShowMessage("Cannot close for the following reasons:" + Environment.NewLine + errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            if (chkShowJobCharges.Checked)
            {
                ShutdownNonChargableVisits(e);
                if (e.Cancel)
                {
                    return;
                }
            }

            if (JobLock is object)
            {
                if (JobLock.UserID == App.loggedInUser.UserID)
                {
                    App.DB.JobLock.Delete(JobLock.JobLockID);
                }

                _readOnly = false;
            }
        }

        private void FRMEngineerVisit_Load(object sender, EventArgs e)
        {
            btnInvoice.Visible = false;
            LoadMe(sender, e);
            tcWorkSheet.TabPages.Remove(tpCharges);
            tcWorkSheet.SelectedTab = tpMainDetails;
            Loading = true;
            cbxVisitLockDown.Checked = EngineerVisit.VisitLocked;
            if (cbxVisitLockDown.Checked == true)
            {
                PopulateCharges(true);
            }

            Loading = false;
            if (Job is object)
            {
                if (Job.StatusEnumID >= (int)Enums.JobStatus.Complete)
                {
                    cbxVisitLockDown.Enabled = false;
                    cbxReadyToBeInvoiced.Enabled = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Modal)
            {
                Close();
            }
            else
            {
                Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnFindPart_Click(object sender, EventArgs e)
        {
            int partID = (int)App.FindRecord(Enums.TableNames.tblPart);
            if (!(partID == 0))
            {
                var part = App.DB.Part.Part_Get(partID);
                PartProductIDUsed = partID;
                PartProductReferenceUsed = part.Reference;
                isSpecialPart = part.IsSpecialPart;
                txtNumberUsed.Text = part.Number;
                txtNameUsed.Text = part.Name;
                nudQuantityUsed.Value = 1;
                lblSellPrice.Text = part.SellPrice.ToString();
                btnAddPartProductUsed.Text = "Add Part";
                btnAddPartProductUsed.Enabled = true;
                lblEquipment.Text = "False";
            }
        }

        private void btnFindProduct_Click(object sender, EventArgs e)
        {
            int productID = (int)App.FindRecord(Enums.TableNames.tblProduct);
            if (!(productID == 0))
            {
                var product = App.DB.Product.Product_Get(productID);
                PartProductIDUsed = productID;
                PartProductReferenceUsed = product.Reference;
                txtNumberUsed.Text = product.Number;
                txtNameUsed.Text = product.Name;
                nudQuantityUsed.Value = 1;
                lblSellPrice.Text = product.SellPrice.ToString();
                btnAddPartProductUsed.Text = "Add Product";
                btnAddPartProductUsed.Enabled = true;
            }
        }

        private void btnRemovePartProduct_Click(object sender, EventArgs e)
        {
            if (dgPartsAndProductsUsed.CurrentRowIndex > -1)
            {
                DataRow drPartsUsed = EngineerVisit.PartsAndProductsUsed.Table.Rows[this.dgPartsAndProductsUsed.CurrentRowIndex];
                if (drPartsUsed.Field<int>("LocationID") == 0 & drPartsUsed.Field<int>("AllocatedID") == 0)
                {
                    if (drPartsUsed.Field<string>("Type") == "Part")
                    {
                        App.DB.EngineerVisitsPartsAndProducts.PartsUsed_DeleteOne(Helper.MakeIntegerValid(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["UniqueID"]));
                    }
                    else
                    {
                        App.DB.EngineerVisitsPartsAndProducts.ProductsUsed_DeleteOne(Helper.MakeIntegerValid(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["UniqueID"]));
                    }

                    EngineerVisit.PartsAndProductsUsed.Table.AcceptChanges();
                    EngineerVisit.PartsAndProductsUsed.Table.Rows.RemoveAt(dgPartsAndProductsUsed.CurrentRowIndex);
                }
                else if (RemovePart(drPartsUsed.Field<int>("Quantity"), drPartsUsed.Field<string>("Name"), drPartsUsed.Field<string>("Type"), drPartsUsed.Field<int>("ID")))
                {
                    // REMOVE FROM DB
                    if (drPartsUsed.Field<string>("Type") == "Part")
                    {
                        App.DB.EngineerVisitsPartsAndProducts.PartsUsed_DeleteOne(Helper.MakeIntegerValid(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["UniqueID"]));
                    }
                    else
                    {
                        App.DB.EngineerVisitsPartsAndProducts.ProductsUsed_DeleteOne(Helper.MakeIntegerValid(EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["UniqueID"]));
                    }

                    EngineerVisit.PartsAndProductsUsed.Table.AcceptChanges();
                    EngineerVisit.PartsAndProductsUsed.Table.Rows.RemoveAt(dgPartsAndProductsUsed.CurrentRowIndex);
                }
            }
            else
            {
                App.ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddPartProduct_Click(object sender, EventArgs e)
        {
            if (PartProductIDUsed == 0)
            {
                App.ShowMessage("Part / Product not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (nudQuantityUsed.Value == 0)
            {
                App.ShowMessage("Quantity not selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var newRow = EngineerVisit.PartsAndProductsUsed.Table.NewRow();
            newRow["ID"] = PartProductIDUsed;
            if ((btnAddPartProductUsed.Text ?? "") == "Add Part")
            {
                newRow["Type"] = "Part";
                FRMChooseAsset dialogue;
                dialogue = (FRMChooseAsset)App.checkIfExists(typeof(FRMChooseAsset).Name, true);
                if (dialogue is null)
                {
                    dialogue = (FRMChooseAsset)Activator.CreateInstance(typeof(FRMChooseAsset));
                }
                // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                dialogue.ShowInTaskbar = false;
                dialogue.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
                dialogue.ShowDialog();
                dialogue.Close();
            }
            else
            {
                newRow["Type"] = "Product";
            }

            newRow["Number"] = txtNumberUsed.Text;
            newRow["Name"] = txtNameUsed.Text;
            newRow["Quantity"] = nudQuantityUsed.Value;
            newRow["Reference"] = PartProductReferenceUsed;
            newRow["SellPrice"] = lblSellPrice.Text;
            newRow["BuyPrice"] = lblSellPrice.Text;
            newRow["UniqueID"] = 0;
            if (isSpecialPart)
            {
                var f = new FRMSpecialOrder(0, 0, 0);
                f.ShowDialog();
                if (f.DialogResult == DialogResult.OK)
                {
                    newRow["Quantity"] = f.Quantity;
                    newRow["SellPrice"] = f.Price;
                    newRow["BuyPrice"] = f.Price;
                    newRow["SpecialPrice"] = f.Price;
                    newRow["Name"] = f.PartName;
                    newRow["SpecialDescription"] = f.PartName;
                    newRow["Number"] = f.SPN;
                    newRow["SpecialPartNumber"] = f.SPN;
                    newRow["LocationID"] = 0;
                    newRow["AllocatedID"] = 0;
                }
                else
                {
                    return;
                }
            }

            if ((btnAddPartProductUsed.Text ?? "") == "Add Part" & Convert.ToBoolean(lblEquipment.Text) == true)
            {
                EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(newRow);
                PartProductIDUsed = 0;
                txtNumberUsed.Text = "";
                txtNameUsed.Text = "";
                nudQuantityUsed.Value = 1;
                btnAddPartProductUsed.Text = "PICK ITEM";
                btnAddPartProductUsed.Enabled = false;
            }
            else if (DeclareWhereGotFrom(newRow.Field<int>("Quantity"), newRow.Field<string>("Name"), newRow.Field<string>("Type"), newRow.Field<int>("ID")))
            {
                EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(newRow);
                PartProductIDUsed = 0;
                txtNumberUsed.Text = "";
                txtNameUsed.Text = "";
                nudQuantityUsed.Value = 1;
                btnAddPartProductUsed.Text = "PICK ITEM";
                btnAddPartProductUsed.Enabled = false;
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Value = dtpStartDate.Value.AddMinutes(1);
        }

        private void btnAddTimeSheet_Click(object sender, EventArgs e)
        {
            if (!(dtpEndDate.Value.Date == dtpStartDate.Value.Date))
            {
                MessageBox.Show("Start Day must be the same as the End Day", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(dtpEndDate.Value > dtpStartDate.Value))
            {
                MessageBox.Show("End date & time must be after Start date & time", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(Convert.ToInt32(Combo.get_GetSelectedItemValue(cboTimeSheetType)) > 0))
            {
                MessageBox.Show("Select a Timesheet Type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

            foreach (DataRow timesheet in EngineerVisit.TimeSheets.Table.Rows)
            {
                if (dtpStartDate.Value >= Helper.MakeDateTimeValid(timesheet["StartDateTime"]) & dtpStartDate.Value <= Helper.MakeDateTimeValid(timesheet["EndDateTime"]))
                {
                    MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dtpEndDate.Value >= Helper.MakeDateTimeValid(timesheet["StartDateTime"]) & dtpEndDate.Value <= Helper.MakeDateTimeValid(timesheet["EndDateTime"]))
                {
                    MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dtpStartDate.Value <= Helper.MakeDateTimeValid(timesheet["StartDateTime"]) & dtpEndDate.Value >= Helper.MakeDateTimeValid(timesheet["EndDateTime"]))
                {
                    MessageBox.Show("This timesheet overlaps an existing timesheet.", "Overlap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            var newRow = EngineerVisit.TimeSheets.Table.NewRow();
            // TIMESHHETS ADD
            newRow["StartDateTime"] = dtpStartDate.Value;
            newRow["EndDateTime"] = dtpEndDate.Value;
            newRow["Comments"] = txtComments.Text;
            newRow["TimesheetTypeID"] = Convert.ToInt32(Combo.get_GetSelectedItemValue(cboTimeSheetType));
            newRow["TimesheetType"] = Combo.get_GetSelectedItemDescription(cboTimeSheetType);
            EngineerVisit.TimeSheets.Table.Rows.Add(newRow);

            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddMinutes(1);
            txtComments.Text = "";
            var argcombo = cboTimeSheetType;
            Combo.SetSelectedComboItem_By_Value(ref argcombo, "0");
        }

        private void btnRemoveTimeSheet_Click(object sender, EventArgs e)
        {
            if (dgTimeSheets.CurrentRowIndex > -1)
            {
                EngineerVisit.TimeSheets.Table.AcceptChanges();
                EngineerVisit.TimeSheets.Table.Rows.RemoveAt(dgTimeSheets.CurrentRowIndex);
            }
            else
            {
                App.ShowMessage("Please select item to remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbxVisitLockDown_CheckedChanged(object sender, EventArgs e)
        {
            if (loops == 0)
            {
                if (!Loading)
                {
                    if (cbxVisitLockDown.Checked)
                    {
                        if (PartsAndProductsAllocated.Table.Select("Status = " + false).Length > 0)
                        {
                            loops = 1;
                            cbxVisitLockDown.Checked = false;
                            App.ShowMessage("All allocated parts must be distributed before locking the visit down", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (Convert.ToInt32(Combo.get_GetSelectedItemValue(cboOutcome)) == (int)Enums.EngineerVisitOutcomes.Complete)
                        {
                            if (Job?.JobTypeID == (int?)Enums.JobTypes.Commission)
                            {
                                if (MessageBox.Show("Have You" + Environment.NewLine + "- Changed fuels?" + Environment.NewLine + "- Changed last service date?" + Environment.NewLine + "- Deactivated old Assets?", "Lock Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    App.ShowMessage("Please complete the tasks and then try again.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cbxVisitLockDown.Checked = false;
                                    return;
                                }
                            }
                        }

                        // This will : save any changes, lock visit down AND enable the visit charge tab-are you sure
                        if (MessageBox.Show("Any changes will now be saved, the visit details will be locked and the visit charges made available" + Environment.NewLine + "Do you want to continue?", "Lock Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (Save())
                            {
                                lblStatusWarning.Visible = true;
                                tcWorkSheet.TabPages.Add(tpCharges);
                                tpCharges.Visible = true;
                                tcWorkSheet.SelectedTab = tpCharges;
                                PopulateCharges(true);
                                tpPartsAndProducts.Enabled = false;
                                tpTimesheets.Enabled = true;
                                tpAppliances.Enabled = false;
                                tpOutcomes.Enabled = false;

                                // Me.tpMainDetails.Enabled = False
                                cboOutcome.Enabled = false;
                                txtOutcomeDetails.ReadOnly = true;
                                txtNotesFromEngineer.ReadOnly = true;
                                // dgJobItems.ReadOnly = True
                                cboEngineer.Enabled = false;
                                txtCustomer.Enabled = false;
                                cboSignatureSelected.Enabled = false;
                                cbxEmailReceiptToCustomer.Enabled = false;
                                btnEditInvoiceNotes.Visible = true;
                            }
                            else
                            {
                                cbxVisitLockDown.Checked = false;
                            }
                        }
                        else
                        {
                            cbxVisitLockDown.Checked = false;
                        }
                    }
                    else
                    {
                        if (App.DB.EngineerVisitCharge.EngineerVisitCharge_Check(EngineerVisit.EngineerVisitID) > 0)
                        {
                            loops = 1;
                            cbxVisitLockDown.Checked = true;
                            cbxVisitLockDown.Enabled = false;
                            return;
                        }

                        if (App.CurrentCustomerID != 2846)
                        {
                            if (App.EnterOverridePasswordINV())
                            {
                            }
                            else
                            {
                                loops = 1;
                                cbxVisitLockDown.Checked = true;
                                cbxVisitLockDown.Enabled = false;
                                return;
                            }
                        }

                        DeleteCharges();
                        lblStatusWarning.Visible = false;
                        tcWorkSheet.TabPages.Remove(tpCharges);
                        tcWorkSheet.SelectedTab = tpMainDetails;
                        tpPartsAndProducts.Enabled = true;
                        tpTimesheets.Enabled = true;
                        tpAppliances.Enabled = true;
                        tpOutcomes.Enabled = true;

                        // Me.tpMainDetails.Enabled = True
                        cboOutcome.Enabled = true;
                        txtOutcomeDetails.ReadOnly = false;
                        txtNotesFromEngineer.ReadOnly = false;
                        dgJobItems.ReadOnly = false;
                        cboEngineer.Enabled = true;
                        txtCustomer.Enabled = true;
                        cboSignatureSelected.Enabled = true;
                        cbxEmailReceiptToCustomer.Enabled = true;
                        btnEditInvoiceNotes.Visible = false;
                    }
                }
                else if (cbxVisitLockDown.Checked)
                {
                    lblStatusWarning.Visible = true;
                    tcWorkSheet.TabPages.Add(tpCharges);
                    tpCharges.Visible = true;
                    tcWorkSheet.SelectedTab = tpCharges;
                    tpPartsAndProducts.Enabled = false;
                    tpTimesheets.Enabled = true;
                    tpAppliances.Enabled = false;
                    tpOutcomes.Enabled = false;

                    // Me.tpMainDetails.Enabled = False
                    cboOutcome.Enabled = false;
                    txtOutcomeDetails.ReadOnly = true;
                    txtNotesFromEngineer.ReadOnly = true;
                    // dgJobItems.ReadOnly = True
                    cboEngineer.Enabled = false;
                    txtCustomer.Enabled = false;
                    cboSignatureSelected.Enabled = false;
                    cbxEmailReceiptToCustomer.Enabled = false;
                    btnEditInvoiceNotes.Visible = true;
                }
                else
                {
                    if (App.DB.EngineerVisitCharge.EngineerVisitCharge_Check(EngineerVisit.EngineerVisitID) > 0)
                    {
                        loops = 1;
                        cbxVisitLockDown.Checked = true;
                        cbxVisitLockDown.Enabled = false;
                        return;
                    }

                    lblStatusWarning.Visible = false;
                    tcWorkSheet.TabPages.Remove(tpCharges);
                    tcWorkSheet.SelectedTab = tpMainDetails;
                    tpPartsAndProducts.Enabled = true;
                    tpTimesheets.Enabled = true;
                    tpOutcomes.Enabled = true;

                    // Me.tpMainDetails.Enabled = True
                    cboOutcome.Enabled = true;
                    txtOutcomeDetails.ReadOnly = false;
                    txtNotesFromEngineer.ReadOnly = false;
                    dgJobItems.ReadOnly = false;
                    cboEngineer.Enabled = true;
                    txtCustomer.Enabled = true;
                    cboSignatureSelected.Enabled = true;
                    cbxEmailReceiptToCustomer.Enabled = true;
                    btnEditInvoiceNotes.Visible = false;
                }
            }
            else
            {
                loops = 0;
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Navigation.Navigate(Enums.MenuTypes.Spares) == true)
                {
                    if (Modal)
                    {
                        Close();
                    }
                    else
                    {
                        Dispose();
                    }

                    if (LogCalloutForm is object)
                    {
                        LogCalloutForm.CloseForm();
                    }

                    App.ShowForm(typeof(FRMOrderManager), false, new object[] { App.DB.Order.Orders_GetForEngineerVisit(EngineerVisit.EngineerVisitID), null });
                }
            }
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            string errorMsg = "";
            if (cbxReadyToBeInvoiced.Checked == false)
            {
                errorMsg += "* Visit is not ready to be invoiced" + Environment.NewLine;
            }

            if (EngVisitCharge.NominalCode.Trim().Length == 0)
            {
            }

            if (EngVisitCharge.ForSageAccountCode.Trim().Length == 0)
            {
                errorMsg += "* Account Code is Mandatory" + Environment.NewLine;
            }

            if (EngVisitCharge.Department.Trim().Length == 0)
            {
                errorMsg += "* Department is Mandatory" + Environment.NewLine;
            }

            if (errorMsg.Length > 0)
            {
                // e.Cancel = True
                App.ShowMessage("Cannot close for the following reasons:" + Environment.NewLine + errorMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (App.ShowMessage("This will close the current form and you will lose any changes that have not been saved. Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Navigation.Navigate(Enums.MenuTypes.Invoicing) == true)
                {
                    if (Modal)
                    {
                        Close();
                    }
                    else
                    {
                        Dispose();
                    }

                    if (LogCalloutForm is object)
                    {
                        LogCalloutForm.CloseForm();
                    }

                    var dv = App.DB.InvoiceToBeRaised.Invoices_GetAll_For_EngineerVisitChargeID(EngVisitCharge.EngineerVisitChargeID);
                    bool @checked = true;
                    if (dv.Table.Rows.Count > 0)
                    {
                        if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID((int)dv.Table.Rows[0]["InvoiceToBeRaisedID"]).Table.Rows.Count > 0)
                        {
                            @checked = false;
                        }
                    }

                    if (@checked == false)
                    {
                        App.ShowForm(typeof(FRMInvoicedManager), false, new object[] { dv, @checked, get_GetParameter(1) });
                    }
                    else
                    {
                        App.ShowForm(typeof(FRMInvoiceManager), false, new object[] { dv, @checked, get_GetParameter(1) });
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                DataTable dt = App.DB.ExecuteWithReturn("Select TestType From tblEngineerVisitAdditionalChecks Where EngineerVisitID = " + EngineerVisit.EngineerVisitID);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr.Field<int>("TestType") == (int)Enums.AdditionalChecksTypes.WorkInProgressAuditDomGASWork |
                        dr.Field<int>("TestType") == (int)Enums.AdditionalChecksTypes.PostCompleteAuditDomWork |
                        dr.Field<int>("TestType") == (int)Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork |
                        dr.Field<int>("TestType") == (int)Enums.AdditionalChecksTypes.WorkInProgressAuditCommercialGASWork)
                    {
                        var details = new ArrayList();
                        details.Add(EngineerVisit.EngineerVisitID);
                        details.Add(dr["TestType"]);
                        var oPrint = new Printing(details, "QC Results", Enums.SystemDocumentType.QCPrint);
                    }
                }
            }
        }

        private void dgVisitDefects_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedVisitDefectDataRow is null)
            {
                return;
            }

            DLGEngineerVisitDefect dialogue;
            dialogue = (DLGEngineerVisitDefect)App.checkIfExists(typeof(DLGEngineerVisitDefect).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGEngineerVisitDefect)Activator.CreateInstance(typeof(DLGEngineerVisitDefect));
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.Defect = App.DB.EngineerVisitDefects.EngineerVisitDefects_Get((int)SelectedVisitDefectDataRow["EngineerVisitDefectID"]);
            dialogue.EngineerVisit = EngineerVisit;
            dialogue.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
            dialogue.Updating = true;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID);
            }

            dialogue.Close();
        }

        private void dgApplianceWorkSheets_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedApplianceWorkSheetDataRow is null)
            {
                return;
            }

            DLGVisitAssetWorkSheet dialogue;
            dialogue = (DLGVisitAssetWorkSheet)App.checkIfExists(typeof(DLGVisitAssetWorkSheet).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGVisitAssetWorkSheet)Activator.CreateInstance(typeof(DLGVisitAssetWorkSheet));
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.Worksheet = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_Get((int)SelectedApplianceWorkSheetDataRow["EngineerVisitAssetWorkSheetID"]);
            dialogue.EngineerVisit = EngineerVisit;
            dialogue.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
            dialogue.Updating = true;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID);
            }

            dialogue.Close();
        }

        private void dgAdditionalWorkSheets_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedAdditionalWorkSheetDataRow is null)
            {
                return;
            }

            DLGVisitAdditionalWorkSheet dialogue;
            dialogue = (DLGVisitAdditionalWorkSheet)App.checkIfExists(typeof(DLGVisitAdditionalWorkSheet).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGVisitAdditionalWorkSheet)Activator.CreateInstance(typeof(DLGVisitAdditionalWorkSheet));
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.Worksheet = App.DB.EngineerVisitAdditional.EngineerVisitAdditional_Get((int)SelectedAdditionalWorkSheetDataRow["EngineerVisitAdditionalID"]);
            dialogue.EngineerVisit = EngineerVisit;
            dialogue.TheSite = theSite;
            dialogue.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
            dialogue.Updating = true;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                AdditionalWorkSheetDataview = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID, 0);
            }

            dialogue.Close();
        }

        private void dgSmokeComoWorkSheets_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedSmokeComoDataRow is null)
            {
                return;
            }

            FRMSmokeComo dialogue;
            dialogue = (FRMSmokeComo)App.checkIfExists(typeof(FRMSmokeComo).Name, true);
            if (dialogue is null)
            {
                dialogue = (FRMSmokeComo)Activator.CreateInstance(typeof(FRMSmokeComo));
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            var argc = dialogue.cboDetType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.TestType).Table.Select("PercentageRate = 1.00").CopyToDataTable(), "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = dialogue.cboPower;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll((Enums.PickListTypes)55).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc2 = dialogue.cboDateType;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.ComoDateType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            dialogue.AdditionalID = (int)SelectedSmokeComoDataRow["EngineerVisitAdditionalID"];
            dialogue.EngineerVisitID = EngineerVisit.EngineerVisitID;
            try
            {
                dialogue.dtpDate.Value = SelectedSmokeComoDataRow.Field<DateTime>("Date");
            }
            catch (Exception ex)
            {
                // dialogue.dtpDate.Enabled = False
                dialogue.chkNA.Checked = true;
                dialogue.dtpDate.Enabled = false;
            }

            var argcombo = dialogue.cboDetType;
            Combo.SetSelectedComboItem_By_Description(ref argcombo, SelectedSmokeComoDataRow.Field<string>("Type"));
            var argcombo1 = dialogue.cboPower;
            Combo.SetSelectedComboItem_By_Description(ref argcombo1, SelectedSmokeComoDataRow.Field<string>("PowerType"));
            var argcombo2 = dialogue.cboDateType;
            Combo.SetSelectedComboItem_By_Description(ref argcombo2, SelectedSmokeComoDataRow.Field<string>("DateType"));
            dialogue.txtLocation.Text = SelectedSmokeComoDataRow.Field<string>("Location");
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                SmokeComoDataview = App.DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(EngineerVisit.EngineerVisitID);
            }

            dialogue.Close();
        }

        private void btnAddSmokeComo_Click(object sender, EventArgs e)
        {
            FRMSmokeComo dialogue;
            dialogue = (FRMSmokeComo)App.checkIfExists(typeof(FRMSmokeComo).Name, true);
            if (dialogue is null)
            {
                dialogue = (FRMSmokeComo)Activator.CreateInstance(typeof(FRMSmokeComo));
            }

            dialogue.ShowInTaskbar = false;
            var argc = dialogue.cboDetType;
            Combo.SetUpCombo(ref argc, App.DB.Picklists.GetAll(Enums.PickListTypes.TestType).Table.Select("PercentageRate = 1.00").CopyToDataTable(), "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc1 = dialogue.cboPower;
            Combo.SetUpCombo(ref argc1, App.DB.Picklists.GetAll((Enums.PickListTypes)55).Table, "ManagerID", "Name", Enums.ComboValues.Please_Select);
            var argc2 = dialogue.cboDateType;
            Combo.SetUpCombo(ref argc2, DynamicDataTables.ComoDateType, "ValueMember", "DisplayMember", Enums.ComboValues.Please_Select);
            dialogue.EngineerVisitID = EngineerVisit.EngineerVisitID;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                SmokeComoDataview = App.DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(EngineerVisit.EngineerVisitID);
            }

            dialogue.Close();
        }

        private void btnRemoveSmokeComo_Click(object sender, EventArgs e)
        {
            if (SelectedSmokeComoDataRow is null)
            {
                return;
            }

            App.DB.EngineerVisitAdditional.Delete((int)SelectedSmokeComoDataRow["EngineerVisitAdditionalID"]);
            SmokeComoDataview = App.DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(EngineerVisit.EngineerVisitID);
        }

        private void btnAddVisitDefect_Click(object sender, EventArgs e)
        {
            DLGEngineerVisitDefect dialogue;
            dialogue = (DLGEngineerVisitDefect)App.checkIfExists(typeof(DLGEngineerVisitDefect).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGEngineerVisitDefect)Activator.CreateInstance(typeof(DLGEngineerVisitDefect));
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.Defect = new Entity.EngineerVisitDefectss.EngineerVisitDefects();
            dialogue.EngineerVisit = EngineerVisit;
            dialogue.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
            dialogue.Updating = false;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID);
            }

            dialogue.Close();
        }

        private void btnAddApplianceWorksheet_Click(object sender, EventArgs e)
        {
            DLGVisitAssetWorkSheet dialogue;
            dialogue = (DLGVisitAssetWorkSheet)App.checkIfExists(typeof(DLGVisitAssetWorkSheet).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGVisitAssetWorkSheet)Activator.CreateInstance(typeof(DLGVisitAssetWorkSheet));
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.Worksheet = new Entity.EngineerVisitAssetWorkSheets.EngineerVisitAssetWorkSheet();
            dialogue.EngineerVisit = EngineerVisit;
            dialogue.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
            dialogue.Updating = false;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID);
            }

            dialogue.Close();
        }

        private void btnAddAdd_Click(object sender, EventArgs e)
        {
            DLGVisitAdditionalWorkSheet dialogue;
            dialogue = (DLGVisitAdditionalWorkSheet)App.checkIfExists(typeof(DLGVisitAdditionalWorkSheet).Name, true);
            if (dialogue is null)
            {
                dialogue = (DLGVisitAdditionalWorkSheet)Activator.CreateInstance(typeof(DLGVisitAdditionalWorkSheet));
            }

            // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
            dialogue.ShowInTaskbar = false;
            dialogue.Worksheet = new Entity.EngineerVisitAdditionals.EngineerVisitAdditional();
            dialogue.EngineerVisit = EngineerVisit;
            dialogue.TheSite = theSite;
            dialogue.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
            dialogue.Updating = false;
            dialogue.ShowDialog();
            if (dialogue.DialogResult == DialogResult.OK)
            {
                AdditionalWorkSheetDataview = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID);
            }

            dialogue.Close();
        }

        private void btnRemoveVisitDefect_Click(object sender, EventArgs e)
        {
            if (SelectedVisitDefectDataRow is null)
            {
                return;
            }

            App.DB.EngineerVisitDefects.Delete((int)SelectedVisitDefectDataRow["EngineerVisitDefectID"]);
            VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID);
        }

        private void btnRemoveApplianceWorkSheet_Click(object sender, EventArgs e)
        {
            if (SelectedApplianceWorkSheetDataRow is null)
            {
                return;
            }

            App.DB.EngineerVisitAssetWorkSheet.Delete((int)SelectedApplianceWorkSheetDataRow["EngineerVisitAssetWorkSheetID"]);
            ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID);
        }

        private void btnRemoveAdd_Click(object sender, EventArgs e)
        {
            if (SelectedAdditionalWorkSheetDataRow is null)
            {
                return;
            }

            App.DB.EngineerVisitAdditional.Delete((int)SelectedAdditionalWorkSheetDataRow["EngineerVisitAdditionalID"]);
            ApplianceWorkSheetDataview = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID);
        }

        private void btnPrintGSR_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(theSite.CustomerID);
                var oPrint = new Printing(details, "Gas Safety Record ", Enums.SystemDocumentType.GSR);
                DocumentsControl.Populate();
            }
        }

        private void btnPrintSVR_Click(object sender, EventArgs e)
        {
            SVRs.Show(btnPrintSVR, new Point(0, 0));
        }

        private void dgJobItems_CurrentCellChanged(object sender, EventArgs e)
        {
        }

        private void cboRecall_SelectedIndexChanged(object sender, EventArgs e)
        {
            var switchExpr = Combo.get_GetSelectedItemValue(cboRecall);
            switch (switchExpr)
            {
                case var @case when @case == 0.ToString():
                case var case1 when case1 == 387.ToString():
                    {
                        var argcombo = cboRecallEngineer;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo, 0.ToString());
                        cboRecallEngineer.Enabled = false;
                        break;
                    }

                default:
                    {
                        cboRecallEngineer.Enabled = true;
                        break;
                    }
            }
        }

        private void btnJob_Click(object sender, EventArgs e)
        {
            bool showJob = true;
            var switchExpr = App.ShowMessage("This form will reload when the job form is closed. Do you want to save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (switchExpr)
            {
                case DialogResult.Yes:
                    {
                        showJob = Save();
                        break;
                    }

                case DialogResult.Cancel:
                    {
                        showJob = false;
                        break;
                    }
            }

            if (showJob)
            {
                App.ShowForm(typeof(FRMLogCallout), true, new object[] { Job.JobID, theSite.SiteID, this, null, EngineerVisit.EngineerVisitID });
                EngineerVisit = App.DB.EngineerVisits.EngineerVisits_Get_New_As_Object(Helper.MakeIntegerValid(get_GetParameter(0)));
            }
        }

        private void chkRecharge_CheckedChanged(object sender, EventArgs e)
        {
            lblRechargeTicked.Visible = chkRecharge.Checked;
        }

        private void Populate()
        {
            Job = App.DB.Job.Get(EngineerVisit.EngineerVisitID, Entity.Jobs.GetBy.EngineerVisitId);
            theSite = App.DB.Sites.Get(Job.PropertyID);
            if (App.loggedInUser.UserRegions.Count > 0)
            {
                if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + theSite.RegionID).Length < 1)
                {
                    string msg = "You do not have the necessary security permissions." + Environment.NewLine;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }
            }
            else
            {
                string msg = "You do not have the necessary security permissions." + Environment.NewLine;
                msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                throw new System.Security.SecurityException(msg);
            }

            var customer = App.DB.Customer.Customer_Get_ForSiteID(theSite.SiteID);
            var ho = App.DB.Sites.Get(customer.CustomerID, Entity.Sites.SiteSQL.GetBy.CustomerHq);
            Text = string.Format("Engineer Visit ID: {0}, Job No: {1}, Property: {2}, Customer: {3}", EngineerVisit.EngineerVisitID, Job.JobNumber, theSite.Name, customer.Name);
            App.CurrentCustomerID = customer.CustomerID;
            if (ho is object && ho.EmailAddress.Length > 0)
            {
                txtCustEmail.Text = "Customer Email: " + ho.EmailAddress;
            }
            else
            {
                txtCustEmail.Text = "";
            }

            bool closeMe = false;
            var switchExpr = EngineerVisit.StatusEnumID;
            switch (switchExpr)
            {
                case (int)Enums.VisitStatus.NOT_SET:
                    {
                        App.ShowMessage("This visit has not entered a visit life span yet.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        closeMe = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Parts_Need_Ordering:
                    {
                        App.ShowMessage("Parts Need Ordering for this visit, once ordered and recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        closeMe = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Waiting_For_Parts:
                    {
                        App.ShowMessage("This visit is waiting for parts, once recieved you may proceed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        closeMe = true;
                        break;
                    }

                case (int)Enums.VisitStatus.Ready_For_Schedule:
                    {
                        txtStatus.Text = "Ready For Schedule";
                        txtUploadedBy.Text = "Not Set";
                        break;
                    }

                case (int)Enums.VisitStatus.Scheduled:
                    {
                        txtStatus.Text = "Scheduled";
                        txtUploadedBy.Text = "Not Set";
                        break;
                    }

                case (int)Enums.VisitStatus.Downloaded:
                    {
                        App.ShowMessage("This visit is currently with an engineer, once returned you may view the details.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        closeMe = true;
                        break;
                    }

                default:
                    {
                        txtStatus.Text = EngineerVisit.VisitStatus;
                        if (EngineerVisit.ManualEntryByUserID == 0)
                        {
                            txtUploadedBy.Text = "Engineer via PDA (See timesheets for date)";
                        }
                        else
                        {
                            txtUploadedBy.Text = App.DB.User.Get(EngineerVisit.ManualEntryByUserID).Fullname + " via PC @ " + EngineerVisit.ManualEntryOn.ToString("dddd dd MMMM yyyy HH:mm:ss");
                        }

                        break;
                    }
            }

            if (closeMe)
            {
                if (Modal)
                {
                    Close();
                }
                else
                {
                    Dispose();
                }
            }
            else
            {
                if (EngineerVisit.OutcomeEnumID == 0)
                {
                    Updating = false;
                    cboOutcome.Enabled = true;
                }
                else
                {
                    cboEngineer.Enabled = false;
                    cboOutcome.Enabled = false;
                }

                var argcombo = cboOutcome;
                Combo.SetSelectedComboItem_By_Value(ref argcombo, EngineerVisit.OutcomeEnumID.ToString());
                var switchExpr1 = (Enums.EngineerVisitOutcomes)EngineerVisit.OutcomeEnumID;
                switch (switchExpr1)
                {
                    case Enums.EngineerVisitOutcomes.Carded:
                        {
                            btnChangeOutcome.Visible = true;
                            break;
                        }

                    case Enums.EngineerVisitOutcomes.Complete:
                        {
                            btnChangeOutcome.Visible = true;
                            break;
                        }

                    case Enums.EngineerVisitOutcomes.Further_Works:
                        {
                            btnChangeOutcome.Visible = true;
                            break;
                        }

                    case Enums.EngineerVisitOutcomes.Could_Not_Start:
                        {
                            btnChangeOutcome.Visible = true;
                            break;
                        }

                    default:
                        {
                            btnChangeOutcome.Visible = App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Servicing);
                            break;
                        }
                }

                txtOutcomeDetails.Text = EngineerVisit.OutcomeDetails;
                var argcombo1 = cboEngineer;
                Combo.SetSelectedComboItem_By_Value(ref argcombo1, EngineerVisit.EngineerID.ToString());
                if ((Convert.ToInt32(Combo.get_GetSelectedItemValue(cboEngineer)) == 0) & EngineerVisit.EngineerID > 0)
                {
                    var nc = new Combo(App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID).Name, EngineerVisit.EngineerID.ToString());
                    cboEngineer.Items.Add(nc);
                    var argcombo2 = cboEngineer;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo2, EngineerVisit.EngineerID.ToString());
                }

                if (EngineerVisit.CustomerSignature is object)
                {
                    pbCustomerSignature.Image = new Bitmap(new System.IO.MemoryStream(EngineerVisit.CustomerSignature));
                }

                txtCustomer.Text = EngineerVisit.CustomerName;
                if (EngineerVisit.EngineerSignature is object)
                {
                    pbEngineerSignature.Image = new Bitmap(new System.IO.MemoryStream(EngineerVisit.EngineerSignature));
                }

                txtNotesToEngineer.Text = EngineerVisit.NotesToEngineer;
                txtNotesFromEngineer.Text = EngineerVisit.NotesFromEngineer;
                txtScheduledTime.Text = "From ";
                if (EngineerVisit.StartDateTime == default)
                {
                    txtScheduledTime.Text += "'Not Set' ";
                }
                else
                {
                    txtScheduledTime.Text += EngineerVisit.StartDateTime.ToString("dddd dd MMMM yyyy HH:mm:ss");
                }

                txtScheduledTime.Text += " to ";
                if (EngineerVisit.EndDateTime == default)
                {
                    txtScheduledTime.Text += "'Not Set' ";
                }
                else
                {
                    txtScheduledTime.Text += EngineerVisit.EndDateTime.ToString("dddd dd MMMM yyyy HH:mm:ss");
                }

                // -------------------------------

                if (EngineerVisit.StartDateTime == default)
                {
                    txtScheduledTime2.Text += "'Not Set' ";
                }
                else
                {
                    txtScheduledTime2.Text += EngineerVisit.StartDateTime.ToString("ddd dd/MM/yyyy HH:mm:ss");
                }

                txtScheduledTime2.Text += "-";
                if (EngineerVisit.EndDateTime == default)
                {
                    txtScheduledTime2.Text += "'Not Set' ";
                }
                else
                {
                    txtScheduledTime2.Text += EngineerVisit.EndDateTime.ToString("ddd dd/MM/yyyy HH:mm:ss");
                }
                // --------------------------------

                JobItems = App.DB.EngineerVisits.EngineerVisitUnitsUsed_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID);
                dgPartsAndProductsUsed.DataSource = EngineerVisit.PartsAndProductsUsed;
                dgTimeSheets.DataSource = EngineerVisit.TimeSheets;
                TimesheetCalc();
                SmokeComoDataview = App.DB.EngineerVisitAdditional.EngineerVisitSmokeComo_GetForVisitDV(EngineerVisit.EngineerVisitID);
                ApplianceWorkSheetDataview = App.DB.EngineerVisitAssetWorkSheet.EngineerVisitAssetWorkSheet_GetForVisit(EngineerVisit.EngineerVisitID);
                VisitDefectDataview = App.DB.EngineerVisitDefects.EngineerVisitDefects_GetForEngineerVisit(EngineerVisit.EngineerVisitID);
                AdditionalWorkSheetDataview = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID);
                var argcombo3 = cboEmergencyControlAccessible;
                Combo.SetSelectedComboItem_By_Value(ref argcombo3, EngineerVisit.EmergencyControlAccessibleID.ToString());
                var argcombo4 = cboBonding;
                Combo.SetSelectedComboItem_By_Value(ref argcombo4, EngineerVisit.BondingID.ToString());
                var argcombo5 = cboGasInstallationTightnessTest;
                Combo.SetSelectedComboItem_By_Value(ref argcombo5, EngineerVisit.GasInstallationTightnessTestID.ToString());
                var argcombo6 = cboPropertyRented;
                Combo.SetSelectedComboItem_By_Value(ref argcombo6, EngineerVisit.PropertyRented.ToString());
                var argcombo7 = cboSignatureSelected;
                Combo.SetSelectedComboItem_By_Value(ref argcombo7, EngineerVisit.SignatureSelectedID.ToString());
                var argcombo8 = cboPaymentMethod;
                Combo.SetSelectedComboItem_By_Value(ref argcombo8, EngineerVisit.PaymentMethodID.ToString());
                var argcombo9 = cboRecharge;
                Combo.SetSelectedComboItem_By_Value(ref argcombo9, EngineerVisit.RechargeTypeID.ToString());
                var argcombo10 = cboNccRad;
                Combo.SetSelectedComboItem_By_Value(ref argcombo10, EngineerVisit.NccRadID.ToString());
                var argcombo11 = cboMeterLocation;
                Combo.SetSelectedComboItem_By_Value(ref argcombo11, EngineerVisit.MeterLocationID.ToString());
                var argcombo12 = cboMeterCapped;
                Combo.SetSelectedComboItem_By_Value(ref argcombo12, EngineerVisit.MeterCappedID.ToString());
                txtAmountCollected.Text = EngineerVisit.AmountCollected.ToString();
                chkGasServiceCompleted.Checked = EngineerVisit.GasServiceCompleted;
                PopulateSiteFuelDataGrid();
                chkRecharge.Checked = EngineerVisit.Recharge;
                PartsAndProductsAllocated = EngineerVisit.PartsAndProductsAllocated;

                // If AssetsDataView Is Nothing Then
                AssetsDataView = App.DB.Asset.Asset_GetForSite(Job.PropertyID);
                // End If

                foreach (DataRow row in AssetsDataView.Table.Rows)
                {
                    foreach (DataRow dr in App.DB.JobAsset.JobAsset_Get_For_Job(Job.JobID).Table.Rows)
                    {
                        if (row.Field<int>("AssetID") == dr.Field<int>("AssetID"))
                        {
                            row["Tick"] = true;
                            break;
                        }
                    }
                }

                cbxEmailReceiptToCustomer.Checked = EngineerVisit.EmailReceipt;
                QC = App.DB.EngineerVisitQCSQL.EngineerVisitQC_Get_EngineerVisitID(EngineerVisit.EngineerVisitID);
                if (QC is null)
                {
                    QC = new Entity.EngineerVisitQCs.EngineerVisitQC();
                }

                var argcombo13 = cboQCAppliance;
                Combo.SetSelectedComboItem_By_Value(ref argcombo13, QC.ApplianceRecorded.ToString());
                var argcombo14 = cboQCCustSig;
                Combo.SetSelectedComboItem_By_Value(ref argcombo14, QC.CustomerSigned.ToString());
                var argcombo15 = cboQCCustomerDetails;
                Combo.SetSelectedComboItem_By_Value(ref argcombo15, QC.CustomerDetailsIncorrect.ToString());
                var argcombo16 = cboQCEngineerPaymentRecieved;
                Combo.SetSelectedComboItem_By_Value(ref argcombo16, QC.EngineerPaymentReceived.ToString());
                var argcombo17 = cboQCJobType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo17, QC.JobTypeIncorrect.ToString());
                var argcombo18 = cboQCJobUploadTimescale;
                Combo.SetSelectedComboItem_By_Value(ref argcombo18, QC.JobUploadInTimeScale.ToString());
                var argcombo19 = cboQCLabourTime;
                Combo.SetSelectedComboItem_By_Value(ref argcombo19, QC.LabourTimeMissing.ToString());
                var argcombo20 = cboQCLGSR;
                Combo.SetSelectedComboItem_By_Value(ref argcombo20, QC.LGSRMissing.ToString());
                var argcombo21 = cboQCOrderNo;
                Combo.SetSelectedComboItem_By_Value(ref argcombo21, QC.OrderNumberAttached.ToString());
                var argcombo22 = cboQCParts;
                Combo.SetSelectedComboItem_By_Value(ref argcombo22, QC.PartsConfirmation.ToString());
                var argcombo23 = cboQCPaymentCollection;
                Combo.SetSelectedComboItem_By_Value(ref argcombo23, QC.PaymentCollection.ToString());
                var argcombo24 = cboQCPaymentMethod;
                Combo.SetSelectedComboItem_By_Value(ref argcombo24, QC.PaymentMethodDetailed.ToString());
                var argcombo25 = cboQCPaymentSelection;
                Combo.SetSelectedComboItem_By_Value(ref argcombo25, QC.PaymentMethodSelectionIncorrect.ToString());
                var argcombo26 = cboQCScheduleOfRate;
                Combo.SetSelectedComboItem_By_Value(ref argcombo26, QC.SorIncorrect.ToString());
                var argcombo27 = cboFTFCode;
                Combo.SetSelectedComboItem_By_Value(ref argcombo27, QC.FTFCode.ToString());
                var argcombo28 = cboRecall;
                Combo.SetSelectedComboItem_By_Value(ref argcombo28, QC.Recall.ToString());
                var argcombo29 = cboRecallEngineer;
                Combo.SetSelectedComboItem_By_Value(ref argcombo29, QC.EngineerID.ToString());
                txtQCPoorJobNotes.Text = QC.PoorJobNotes;
                chkQCDocumentsRecieved.Checked = QC.DocumentsRecieved;
                dtpQCDocumentsRecieved.Value = QC.DateDocumentsRecieved != default ? QC.DateDocumentsRecieved : DateTime.Now;
                Profitable();
                if (EngineerVisit.EngineerVisitNCCGSR is object)
                {
                    txtApproxAgeOfBoiler.Text = EngineerVisit.EngineerVisitNCCGSR.ApproxAgeOfBoiler.ToString();
                    txtRadiators.Text = EngineerVisit.EngineerVisitNCCGSR.Radiators.ToString();
                    txtVisualInspectionReason.Text = EngineerVisit.EngineerVisitNCCGSR.VisualInspectionReason;
                    var argcombo30 = cboCertificateTypeID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo30, EngineerVisit.EngineerVisitNCCGSR.CertificateTypeID.ToString());
                    var argcombo31 = cboCODetectorFittedID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo31, EngineerVisit.EngineerVisitNCCGSR.CODetectorFittedID.ToString());
                    var argcombo32 = cboCorrectMaterialsUsedID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo32, EngineerVisit.EngineerVisitNCCGSR.CorrectMaterialsUsedID.ToString());
                    var argcombo33 = cboCylinderTypeID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo33, EngineerVisit.EngineerVisitNCCGSR.CylinderTypeID.ToString());
                    var argcombo34 = cboHeatingSystemTypeID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo34, EngineerVisit.EngineerVisitNCCGSR.HeatingSystemTypeID.ToString());
                    var argcombo35 = cboImmersionID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo35, EngineerVisit.EngineerVisitNCCGSR.ImmersionID.ToString());
                    var argcombo36 = cboInstallationPipeWorkCorrectID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo36, EngineerVisit.EngineerVisitNCCGSR.InstallationPipeWorkCorrectID.ToString());
                    var argcombo37 = cboInstallationSafeToUseID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo37, EngineerVisit.EngineerVisitNCCGSR.InstallationSafeToUseID.ToString());
                    var argcombo38 = cboJacketID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo38, EngineerVisit.EngineerVisitNCCGSR.JacketID.ToString());
                    var argcombo39 = cboPartialHeatingID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo39, EngineerVisit.EngineerVisitNCCGSR.PartialHeatingID.ToString());
                    var argcombo40 = cboStrainerFittedID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo40, EngineerVisit.EngineerVisitNCCGSR.StrainerFittedID.ToString());
                    var argcombo41 = cboStrainerInspectedID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo41, EngineerVisit.EngineerVisitNCCGSR.StrainerInspectedID.ToString());
                    var argcombo42 = cboVisualInspectionSatisfactoryID;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo42, EngineerVisit.EngineerVisitNCCGSR.VisualInspectionSatisfactoryID.ToString());
                    var argcombo43 = cboSITimer;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo43, EngineerVisit.EngineerVisitNCCGSR.SITimerID.ToString());
                    var argcombo44 = cboFillDisc;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo44, EngineerVisit.EngineerVisitNCCGSR.FillDiscID.ToString());
                }

                var AdditionalDT = App.DB.EngineerVisitAdditional.EngineerVisitAdditionalWorkSheet_GetForVisitDV(EngineerVisit.EngineerVisitID).Table;

                // Dim AdditionalDT As Integer = DB.ExecuteWithReturn("SELECT COUNT(*) FROM tblEngineerVisitAdditionalChecks where (TestType = 69318 OR TestType = 69319 OR TestType = 69473 OR TestType = 69592) AND EngineerVisitID = " & EngineerVisit.EngineerVisitID & "")
                ASHPWorksheetToolStripMenuItem.Visible = false;
                CommercialGSRToolStripMenuItem.Visible = false;
                DomesticGSRToolStripMenuItem.Visible = false;
                WarningNoticeToolStripMenuItem.Visible = false;
                QCResultsToolStripMenuItem.Visible = false;
                ElectricalMinorWorksToolStripMenuItem.Visible = false;
                AllGasPaperworkToolStripMenuItem.Visible = true;
                CommercialCateringToolStripMenuItem.Visible = false;
                SaffronUnventedWorkshhetToolStripMenuItem.Visible = false;
                PropertyMaintenanceWorksheetToolStripMenuItem.Visible = false;
                CommissioningChecklistToolStripMenuItem.Visible = false;
                HotWorksPermitToolStripMenuItem.Visible = false;
                foreach (DataRow dr in AdditionalDT.Rows)
                {
                    var switchExpr2 = (int)dr["TestType"];
                    switch (switchExpr2)
                    {
                        case (int)Enums.AdditionalChecksTypes.WorkInProgressAuditDomGASWork:
                        case (int)Enums.AdditionalChecksTypes.PostCompleteAuditDomWork:
                        case (int)Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork:
                        case (int)Enums.AdditionalChecksTypes.WorkInProgressAuditCommercialGASWork:
                        case (int)Enums.AdditionalChecksTypes.ElectricalAudit:
                            {
                                QCResultsToolStripMenuItem.Visible = true;
                                break;
                            }

                        case (int)Enums.AdditionalChecksTypes.CommercialStrengthTestCP16:
                        case (int)Enums.AdditionalChecksTypes.CommercialPurgingTestCP16:
                        case (int)Enums.AdditionalChecksTypes.CommercialSiteChecksCP17:
                        case (int)Enums.AdditionalChecksTypes.CommercialTightnessTestCP16:
                            {
                                CommercialGSRToolStripMenuItem.Visible = true;
                                break;
                            }

                        case (int)Enums.AdditionalChecksTypes.EcoDanMaintenanceSheet:
                        case (int)Enums.AdditionalChecksTypes.SolarThermalReport:
                            {
                                ASHPWorksheetToolStripMenuItem.Visible = true;
                                break;
                            }

                        case (int)Enums.AdditionalChecksTypes.PropertyMaintenanceChecklist:
                            {
                                PropertyMaintenanceWorksheetToolStripMenuItem.Visible = true;
                                break;
                            }

                        case (int)Enums.AdditionalChecksTypes.SaffronUnventedReport:
                            {
                                SaffronUnventedWorkshhetToolStripMenuItem.Visible = true;
                                break;
                            }

                        case (int)Enums.AdditionalChecksTypes.CommercialCateringCP42:
                            {
                                CommercialCateringToolStripMenuItem.Visible = true;
                                break;
                            }

                        case (int)Enums.AdditionalChecksTypes.MinorWorksSingleCircuitElecCert:
                            {
                                ElectricalMinorWorksToolStripMenuItem.Visible = true;
                                break;
                            }

                        case (int)Enums.AdditionalChecksTypes.CommissioningChecklist:
                            {
                                CommissioningChecklistToolStripMenuItem.Visible = true;
                                break;
                            }

                        case (int)Enums.AdditionalChecksTypes.HotWorksPermit:
                            {
                                HotWorksPermitToolStripMenuItem.Visible = true;
                                break;
                            }
                    }
                }

                if (ApplianceWorkSheetDataview.Count > 0 | VisitDefectDataview.Count > 0)
                {
                    DomesticGSRToolStripMenuItem.Visible = true;
                }

                var drWarningNotices = (from x in VisitDefectDataview.Table.AsEnumerable()
                                        where Helper.MakeBooleanValid(x["WarningNoticeIssued"]) == true
                                        select x).ToArray();
                if (drWarningNotices.Length > 0)
                    WarningNoticeToolStripMenuItem.Visible = true;
            }

            int? jobLockUserId = JobLock?.UserID;
            if (jobLockUserId.HasValue && (jobLockUserId.Value != App.loggedInUser.UserID))
            {
                string message = "The job is currently being viewed by: " + JobLock.NameOfUserWhoLocked;
                MessageBox.Show(message, "READ ONLY - JOB LOCKED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MakeReadOnly();
                Text += " Job Locked by: " + JobLock.NameOfUserWhoLocked;
            }
        }

        private void TimesheetCalc()
        {
            double allowance = 0;
            foreach (DataRow itm in JobItems.Table.Rows)
                allowance += Helper.MakeDoubleValid(itm["NumAllocated"]) * Helper.MakeDoubleValid(itm["TimeInMins"]);
            double spent = 0;
            if (EngineerVisit.TimeSheets is object)
            {
                if (EngineerVisit.TimeSheets.Table is object)
                {
                    foreach (DataRow row in EngineerVisit.TimeSheets.Table.Rows)
                        spent += Helper.MakeDateTimeValid(row["EndDateTime"]).Subtract(Helper.MakeDateTimeValid(row["StartDateTime"])).TotalMinutes;
                }
            }

            txtSORTimeAllowance.Text = allowance.ToString();
            txtActualTimeSpent.Text = spent.ToString();
            txtDifference.Text = (allowance - spent).ToString();
        }

        private void Profitable()
        {
            if (EngVisitCharge is object)
            {
                double totalCost = 0;
                totalCost += Helper.MakeDoubleValid(txtEngineerCostTotal.Text);
                // totalCost += Helper.MakeDoubleValid(Me.txtAdditionalChargeTotal.Text)
                totalCost += Helper.MakeDoubleValid(txtPartProductCost.Text);
                txtSale.Text = txtJobValue.Text;
                txtCosts.Text = totalCost.ToString("C");
                txtProfit.Text = (Helper.MakeDoubleValid(txtSale.Text) - Helper.MakeDoubleValid(txtCosts.Text)).ToString("C");
                if (txtSale.Text.Length > 0)
                {
                    txtProfitPerc.Text = Math.Round(Helper.MakeDoubleValid(txtProfit.Text) / Helper.MakeDoubleValid(txtSale.Text) * 100, 2) + "%";
                }
                else
                {
                    txtProfitPerc.Text = "N/A";
                }

                double totalCharge = 0;
                var switchExpr = (Enums.JobChargingType)EngVisitCharge.ChargeTypeID;
                switch (switchExpr)
                {
                    case Enums.JobChargingType.JobValue:
                        {
                            totalCharge = Helper.MakeDoubleValid(txtJobValue.Text);
                            break;
                        }

                    case Enums.JobChargingType.NoChargeCallout:
                    case Enums.JobChargingType.NoChargeContractInvoice:
                    case Enums.JobChargingType.NoChargeMisc:
                        {
                            totalCharge = 0;
                            break;
                        }

                    case Enums.JobChargingType.PercentageOfQuote:
                        {
                            totalCharge = Helper.MakeDoubleValid(lblQuotePercentageTotal.Text);
                            break;
                        }

                    case Enums.JobChargingType.QuoteValue:
                        {
                            totalCharge = Helper.MakeDoubleValid(txtCharge.Text);
                            break;
                        }
                }
            }
        }

        private bool Save()
        {
            try
            {
                if (_readOnly)
                    return true;
                Cursor = Cursors.WaitCursor;
                if (App.loggedInUser.UserRegions.Count > 0)
                {
                    if (App.loggedInUser.UserRegions.Table.Select("RegionID = " + theSite.RegionID).Length < 1)
                    {
                        string msg = "You do not have the necessary security permissions." + Environment.NewLine;
                        msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                        throw new System.Security.SecurityException(msg);
                    }
                }
                else
                {
                    string msg = "You do not have the necessary security permissions." + Environment.NewLine;
                    msg += "Contact your administrator if you think this is wrong or you need the permissions changing.";
                    throw new System.Security.SecurityException(msg);
                }

                int fuelId = 0;
                if (SiteFuelsDataView.Table.Select("tick = 1").Length > 0)
                    fuelId = (int)SiteFuelsDataView.Table.Select("tick = 1")[0]["ManagerID"];
                if (chkGasServiceCompleted.Checked && fuelId == (int)Enums.FuelTypes.NA)
                {
                    App.ShowMessage("Please select correct fuel type." + Environment.NewLine + "Cannot find fuel, please contact your administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                EngineerVisit.IgnoreExceptionsOnSetMethods = true;
                EngineerVisit.SetEngineerID = Combo.get_GetSelectedItemValue(cboEngineer);
                EngineerVisit.SetNotesFromEngineer = txtNotesFromEngineer.Text.Trim();
                EngineerVisit.SetOutcomeEnumID = Combo.get_GetSelectedItemValue(cboOutcome);
                EngineerVisit.SetOutcomeDetails = txtOutcomeDetails.Text.Trim();
                EngineerVisit.SetCustomerName = txtCustomer.Text.Trim();
                EngineerVisit.SetVisitLocked = cbxVisitLockDown.Checked;
                EngineerVisit.SetAmountCollected = txtAmountCollected.Text;
                EngineerVisit.SetPaymentMethodID = Combo.get_GetSelectedItemValue(cboPaymentMethod);
                EngineerVisit.SetPropertyRented = Combo.get_GetSelectedItemValue(cboPropertyRented);
                EngineerVisit.SetBondingID = Combo.get_GetSelectedItemValue(cboBonding);
                EngineerVisit.SetEmergencyControlAccessibleID = Combo.get_GetSelectedItemValue(cboEmergencyControlAccessible);
                EngineerVisit.SetSignatureSelectedID = Combo.get_GetSelectedItemValue(cboSignatureSelected);
                EngineerVisit.SetGasInstallationTightnessTestID = Combo.get_GetSelectedItemValue(cboGasInstallationTightnessTest);
                EngineerVisit.SetGasServiceCompleted = chkGasServiceCompleted.Checked;
                EngineerVisit.SetFuelID = fuelId;
                EngineerVisit.SetEmailReceipt = cbxEmailReceiptToCustomer.Checked;
                EngineerVisit.SetRecharge = chkRecharge.Checked;
                EngineerVisit.setRechargeTypeID = Combo.get_GetSelectedItemValue(cboRecharge);
                EngineerVisit.setNccRadID = Combo.get_GetSelectedItemValue(cboNccRad);
                EngineerVisit.SetMeterCappedID = Combo.get_GetSelectedItemValue(cboMeterCapped);
                EngineerVisit.SetMeterLocationID = Combo.get_GetSelectedItemValue(cboMeterLocation);
                EngineerVisit.SetUseSORDescription = chkSORDesc.Checked;
                if (ScheduleOfRateCharges is object && chkSORDesc.Checked & ScheduleOfRateCharges.Table.Select("tick <> 0").Length == 0 & cbxReadyToBeInvoiced.Checked)
                {
                    App.ShowMessage("You Can not use SOR Descriptions for Invoicing without selecting chargeable SORS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (EngineerVisit.EngineerVisitNCCGSR is null)
                {
                    EngineerVisit.EngineerVisitNCCGSR = new Entity.EngineerVisitNCCGSRs.EngineerVisitNCCGSR();
                }

                EngineerVisit.EngineerVisitNCCGSR.SetApproxAgeOfBoiler = txtApproxAgeOfBoiler.Text;
                EngineerVisit.EngineerVisitNCCGSR.SetCertificateTypeID = Combo.get_GetSelectedItemValue(cboCertificateTypeID);
                EngineerVisit.EngineerVisitNCCGSR.SetCODetectorFittedID = Combo.get_GetSelectedItemValue(cboCODetectorFittedID);
                EngineerVisit.EngineerVisitNCCGSR.SetCorrectMaterialsUsedID = Combo.get_GetSelectedItemValue(cboCorrectMaterialsUsedID);
                EngineerVisit.EngineerVisitNCCGSR.SetCylinderTypeID = Combo.get_GetSelectedItemValue(cboCylinderTypeID);
                EngineerVisit.EngineerVisitNCCGSR.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                EngineerVisit.EngineerVisitNCCGSR.SetHeatingSystemTypeID = Combo.get_GetSelectedItemValue(cboHeatingSystemTypeID);
                EngineerVisit.EngineerVisitNCCGSR.SetImmersionID = Combo.get_GetSelectedItemValue(cboImmersionID);
                EngineerVisit.EngineerVisitNCCGSR.SetInstallationPipeWorkCorrectID = Combo.get_GetSelectedItemValue(cboInstallationPipeWorkCorrectID);
                EngineerVisit.EngineerVisitNCCGSR.SetInstallationSafeToUseID = Combo.get_GetSelectedItemValue(cboInstallationSafeToUseID);
                EngineerVisit.EngineerVisitNCCGSR.SetJacketID = Combo.get_GetSelectedItemValue(cboJacketID);
                EngineerVisit.EngineerVisitNCCGSR.SetPartialHeatingID = Combo.get_GetSelectedItemValue(cboPartialHeatingID);
                EngineerVisit.EngineerVisitNCCGSR.SetRadiators = txtRadiators.Text;
                EngineerVisit.EngineerVisitNCCGSR.SetStrainerFittedID = Combo.get_GetSelectedItemValue(cboStrainerFittedID);
                EngineerVisit.EngineerVisitNCCGSR.SetStrainerInspectedID = Combo.get_GetSelectedItemValue(cboStrainerInspectedID);
                EngineerVisit.EngineerVisitNCCGSR.SetVisualInspectionReason = txtVisualInspectionReason.Text;
                EngineerVisit.EngineerVisitNCCGSR.SetVisualInspectionSatisfactoryID = Combo.get_GetSelectedItemValue(cboVisualInspectionSatisfactoryID);
                EngineerVisit.EngineerVisitNCCGSR.SetFillDiscID = Combo.get_GetSelectedItemValue(cboFillDisc);
                EngineerVisit.EngineerVisitNCCGSR.SetSITimerID = Combo.get_GetSelectedItemValue(cboSITimer);
                if (EngineerVisit.EngineerVisitSMOKE is null)
                {
                    EngineerVisit.EngineerVisitSMOKE = new Entity.EngineerVisitAdditionals.EngineerVisitAdditional();
                }

                if (EngineerVisit.EngineerVisitCOMO is null)
                {
                    EngineerVisit.EngineerVisitCOMO = new Entity.EngineerVisitAdditionals.EngineerVisitAdditional();
                }

                var jV = new EngineerVisitValidator();
                jV.Validate(EngineerVisit, theSite.CustomerID);
                var switchExpr = EngineerVisit.StatusEnumID;
                switch (switchExpr)
                {
                    case (int)Enums.VisitStatus.Ready_For_Schedule:
                    case (int)Enums.VisitStatus.Scheduled:
                        {
                            if (App.ShowMessage("Are you sure you wish to manually complete this visit? (The outcome can not be altered from this point)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return false;
                            }

                            break;
                        }
                }

                QC.SetApplianceRecorded = Combo.get_GetSelectedItemValue(cboQCAppliance);
                QC.SetCustomerSigned = Combo.get_GetSelectedItemValue(cboQCCustSig);
                QC.SetCustomerDetailsIncorrect = Combo.get_GetSelectedItemValue(cboQCCustomerDetails);
                QC.SetEngineerPaymentReceived = Combo.get_GetSelectedItemValue(cboQCEngineerPaymentRecieved);
                QC.SetJobTypeIncorrect = Combo.get_GetSelectedItemValue(cboQCJobType);
                QC.SetJobUploadInTimeScale = Combo.get_GetSelectedItemValue(cboQCJobUploadTimescale);
                QC.SetLabourTimeMissing = Combo.get_GetSelectedItemValue(cboQCLabourTime);
                QC.SetLGSRMissing = Combo.get_GetSelectedItemValue(cboQCLGSR);
                QC.SetOrderNumberAttached = Combo.get_GetSelectedItemValue(cboQCOrderNo);
                QC.SetPartsConfirmation = Combo.get_GetSelectedItemValue(cboQCParts);
                QC.SetPaymentCollection = Combo.get_GetSelectedItemValue(cboQCPaymentCollection);
                QC.SetPaymentMethodDetailed = Combo.get_GetSelectedItemValue(cboQCPaymentMethod);
                QC.SetPaymentMethodSelectionIncorrect = Combo.get_GetSelectedItemValue(cboQCPaymentSelection);
                QC.SetSorIncorrect = Combo.get_GetSelectedItemValue(cboQCScheduleOfRate);
                QC.SetFTFCode = Combo.get_GetSelectedItemValue(cboFTFCode);
                QC.SetRecall = Combo.get_GetSelectedItemValue(cboRecall);
                QC.SetEngineerID = Combo.get_GetSelectedItemValue(cboRecallEngineer);
                QC.SetPoorJobNotes = txtQCPoorJobNotes.Text;
                QC.SetDocumentsRecieved = chkQCDocumentsRecieved.Checked;
                QC.DateDocumentsRecieved = chkQCDocumentsRecieved.Checked ? dtpQCDocumentsRecieved.Value : default;
                QC.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                if (QC.Exists)
                {
                    App.DB.EngineerVisitQCSQL.Update(QC);
                }
                else
                {
                    App.DB.EngineerVisitQCSQL.Insert(QC);
                }

                // GET JOW Priority
                var jow = App.DB.JobOfWorks.JobOfWork_Get(EngineerVisit.JobOfWorkID);
                // GET picklist wording for priority
                var pk = App.DB.Picklists.Get_One_As_Object(jow.Priority);
                // GET Recall Picklist ID
                int recallID = 0;
                var dtPriorities = App.DB.Picklists.GetAll(Enums.PickListTypes.JOWPriority).Table;
                foreach (DataRow drPriority in dtPriorities.Rows)
                {
                    if (drPriority.Field<string>("Name") == "RC - Recall")
                    {
                        recallID = drPriority.Field<int>("ManagerID");
                        break;
                    }
                }

                // if the user selects Recall = Yes, and the JOW Priority does not = Recall, it will be set to Recall.
                if ((Combo.get_GetSelectedItemDescription(cboRecall) ?? "") == "Yes")
                {
                    if (pk is null)
                    {
                        // Set to Recall
                        jow.SetPriority = recallID;
                        jow.PriorityDateSet = DateTime.Now;
                        App.DB.JobOfWorks.Update_Priority(jow);
                    }
                    else if ((pk.Name ?? "") != "RC - Recall")
                    {
                        // Set to Recall
                        jow.SetPriority = recallID;
                        jow.PriorityDateSet = DateTime.Now;
                        App.DB.JobOfWorks.Update_Priority(jow);
                    }
                }

                // if the user selects Recall = No, and the JOW Priority = Recall, the user will be asked what they would like to change this to.
                if ((Combo.get_GetSelectedItemDescription(cboRecall) ?? "") == "No")
                {
                    if (pk is object)
                    {
                        if ((pk.Name ?? "") == "RC - Recall")
                        {
                            // Select a Job Priority to set it too
                            var f = new FRMChangePriority();
                            f.ShowDialog();
                            jow.SetPriority = Combo.get_GetSelectedItemValue(f.cboJobType);
                            jow.PriorityDateSet = DateTime.Now;
                            App.DB.JobOfWorks.Update_Priority(jow);
                        }
                    }
                }

                EngineerVisit = App.DB.EngineerVisits.ManuallyComplete(EngineerVisit, JobItems, PartsAndProductsDistribution);
                Updating = true;
                return true;
            }
            catch (ValidationException vex)
            {
                string msg = "Please correct the following errors: " + Environment.NewLine + "{0}{1}";
                msg = string.Format(msg, Environment.NewLine, vex.Validator.CriticalMessagesString());
                App.ShowMessage(msg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            catch (Exception ex)
            {
                App.ShowMessage("Error saving details : " + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private DataView _AdditionalCharges;

        private DataView AdditionalCharges
        {
            get
            {
                return _AdditionalCharges;
            }

            set
            {
                _AdditionalCharges = value;
                _AdditionalCharges.AllowNew = false;
                _AdditionalCharges.AllowEdit = false;
                _AdditionalCharges.AllowDelete = false;
                _AdditionalCharges.Table.TableName = Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
                dgAdditionalCharges.DataSource = AdditionalCharges;
            }
        }

        private DataRow SelectedAdditionalChargesDataRow
        {
            get
            {
                if (!(dgAdditionalCharges.CurrentRowIndex == -1))
                {
                    return AdditionalCharges[dgAdditionalCharges.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _ScheduleOfRateCharges;

        private DataView ScheduleOfRateCharges
        {
            get
            {
                return _ScheduleOfRateCharges;
            }

            set
            {
                _ScheduleOfRateCharges = value;
                _ScheduleOfRateCharges.AllowNew = false;
                _ScheduleOfRateCharges.AllowEdit = true;
                _ScheduleOfRateCharges.AllowDelete = false;
                _ScheduleOfRateCharges.Table.TableName = Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
                dgScheduleOfRateCharges.DataSource = ScheduleOfRateCharges;
            }
        }

        private DataRow SelectedScheduleOfRateChargesDataRow
        {
            get
            {
                if (!(dgScheduleOfRateCharges.CurrentRowIndex == -1))
                {
                    return ScheduleOfRateCharges[dgScheduleOfRateCharges.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private EngineerVisitCharge _engVisitCharge;

        private EngineerVisitCharge EngVisitCharge
        {
            get
            {
                return _engVisitCharge;
            }

            set
            {
                _engVisitCharge = value;
                if (EngVisitCharge is null)
                {
                    btnInvoice.Visible = false;
                }
                else if (EngVisitCharge.InvoiceReadyID == (int)Enums.InvoiceReady.Ready)
                {
                    btnInvoice.Visible = true;
                }
                else
                {
                    btnInvoice.Visible = false;
                }
            }
        }

        private DataView _PartProductsCharges;

        private DataView PartProductsCharges
        {
            get
            {
                return _PartProductsCharges;
            }

            set
            {
                _PartProductsCharges = value;
                _PartProductsCharges.AllowNew = false;
                _PartProductsCharges.AllowEdit = false;
                _PartProductsCharges.AllowDelete = false;
                _PartProductsCharges.Table.TableName = Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
                dgPartsProductCharging.DataSource = PartProductsCharges;
            }
        }

        private DataRow SelectedPartProductsChargesDataRow
        {
            get
            {
                if (!(dgPartsProductCharging.CurrentRowIndex == -1))
                {
                    return PartProductsCharges[dgPartsProductCharging.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.Jobs.Job _Job;

        private Entity.Jobs.Job Job
        {
            get
            {
                return _Job;
            }

            set
            {
                _Job = value;
            }
        }

        private bool _readOnly = false;

        private void MakeReadOnly()
        {
            tpMainDetails.Enabled = false;
            tpAppliances.Enabled = false;
            grpVisitWorksheet.Enabled = false;
            grpVisitWorksheetExtended.Enabled = false;
            grpAlarmInfo.Enabled = false;
            grpVisitDefects.Enabled = false;
            grpApplianceWorksheet.Enabled = false;
            grpAdditionalWorksheet.Enabled = false;
            tpTimesheets.Enabled = false;
            grpTimesheets.Enabled = false;
            tpPartsAndProducts.Enabled = false;
            tpOutcomes.Enabled = false;
            tpQC.Enabled = false;
            tpCharges.Enabled = false;
            btnSave.Enabled = false;
            cbxVisitLockDown.Enabled = false;
            _readOnly = true;
        }

        private DataView _TimeSheetCharges;

        private DataView TimeSheetCharges
        {
            get
            {
                return _TimeSheetCharges;
            }

            set
            {
                _TimeSheetCharges = value;
                _TimeSheetCharges.AllowNew = false;
                _TimeSheetCharges.AllowEdit = true;
                _TimeSheetCharges.AllowDelete = false;
                _TimeSheetCharges.Table.TableName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
                dgTimesheetCharges.DataSource = TimeSheetCharges;
            }
        }

        private DataRow SelectedTimeSheetChargesDataRow
        {
            get
            {
                if (!(dgTimesheetCharges.CurrentRowIndex == -1))
                {
                    return TimeSheetCharges[dgTimesheetCharges.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private Entity.InvoiceToBeRaiseds.InvoiceToBeRaised _invoiceToBeRaised = null;

        public Entity.InvoiceToBeRaiseds.InvoiceToBeRaised InvoiceToBeRaised
        {
            get
            {
                return _invoiceToBeRaised;
            }

            set
            {
                _invoiceToBeRaised = value;
            }
        }

        public void SetupAdditionalChargeDataGrid()
        {
            Helper.SetUpDataGrid(dgAdditionalCharges);
            var tStyle = dgAdditionalCharges.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "ChargeDescription";
            Description.ReadOnly = true;
            Description.Width = 320;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var Charge = new DataGridLabelColumn();
            Charge.Format = "C";
            Charge.FormatInfo = null;
            Charge.HeaderText = "Charge";
            Charge.MappingName = "Charge";
            Charge.ReadOnly = true;
            Charge.Width = 100;
            Charge.NullText = "";
            tStyle.GridColumnStyles.Add(Charge);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.tblEngineerVisitAdditionalCharge.ToString();
            dgAdditionalCharges.TableStyles.Add(tStyle);
        }

        public void SetupSoRChargeDataGrid()
        {
            Helper.SetUpDataGrid(dgScheduleOfRateCharges);
            var tStyle = dgScheduleOfRateCharges.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgScheduleOfRateCharges.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Code = new DataGridLabelColumn();
            Code.Format = "";
            Code.FormatInfo = null;
            Code.HeaderText = "Code";
            Code.MappingName = "Code";
            Code.ReadOnly = true;
            Code.Width = 65;
            Code.NullText = "";
            tStyle.GridColumnStyles.Add(Code);
            var category = new DataGridLabelColumn();
            category.Format = "";
            category.FormatInfo = null;
            category.HeaderText = "Category";
            category.MappingName = "category";
            category.ReadOnly = true;
            category.Width = 75;
            category.NullText = "";
            tStyle.GridColumnStyles.Add(category);
            var Description = new DataGridLabelColumn();
            Description.Format = "";
            Description.FormatInfo = null;
            Description.HeaderText = "Description";
            Description.MappingName = "Summary";
            Description.ReadOnly = true;
            Description.Width = 85;
            Description.NullText = "";
            tStyle.GridColumnStyles.Add(Description);
            var NumUnitsUsed = new DataGridLabelColumn();
            NumUnitsUsed.Format = "";
            NumUnitsUsed.FormatInfo = null;
            NumUnitsUsed.HeaderText = "# Used";
            NumUnitsUsed.MappingName = "NumUnitsUsed";
            NumUnitsUsed.ReadOnly = true;
            NumUnitsUsed.Width = 52;
            NumUnitsUsed.NullText = "0";
            tStyle.GridColumnStyles.Add(NumUnitsUsed);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 60;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var Charge = new DataGridLabelColumn();
            Charge.Format = "C";
            Charge.FormatInfo = null;
            Charge.HeaderText = "Charge";
            Charge.MappingName = "Total";
            Charge.ReadOnly = true;
            Charge.Width = 65;
            Charge.NullText = "ï¿½0.00";
            tStyle.GridColumnStyles.Add(Charge);
            tStyle.MappingName = Enums.TableNames.tblEngineerVisitScheduleOfRateCharges.ToString();
            dgScheduleOfRateCharges.TableStyles.Add(tStyle);
        }

        public void SetupPartProductDataGrid()
        {
            Helper.SetUpDataGrid(dgPartsProductCharging);
            var tStyle = dgPartsProductCharging.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgScheduleOfRateCharges.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var Type = new DataGridLabelColumn();
            Type.Format = "";
            Type.FormatInfo = null;
            Type.HeaderText = "Type";
            Type.MappingName = "Type";
            Type.ReadOnly = true;
            Type.Width = 40;
            Type.NullText = "";
            tStyle.GridColumnStyles.Add(Type);
            var PartProduct = new DataGridLabelColumn();
            PartProduct.Format = "";
            PartProduct.FormatInfo = null;
            PartProduct.HeaderText = "Part/Product";
            PartProduct.MappingName = "Part/Product";
            PartProduct.ReadOnly = true;
            PartProduct.Width = 75;
            PartProduct.NullText = "";
            tStyle.GridColumnStyles.Add(PartProduct);
            var Asset = new DataGridLabelColumn();
            Asset.Format = "";
            Asset.FormatInfo = null;
            Asset.HeaderText = "Appliance (part applied to)";
            Asset.MappingName = "Asset";
            Asset.ReadOnly = true;
            Asset.Width = 60;
            Asset.NullText = "";
            tStyle.GridColumnStyles.Add(Asset);
            var Warranty = new DataGridLabelColumn();
            Warranty.Format = "";
            Warranty.FormatInfo = null;
            Warranty.HeaderText = "Warranty? (Appliance on)";
            Warranty.MappingName = "Warranty";
            Warranty.ReadOnly = true;
            Warranty.Width = 55;
            Warranty.NullText = "";
            tStyle.GridColumnStyles.Add(Warranty);
            var Cost = new DataGridLabelColumn();
            Cost.Format = "C";
            Cost.FormatInfo = null;
            Cost.HeaderText = "Cost";
            Cost.MappingName = "Rate";
            Cost.ReadOnly = true;
            Cost.Width = 45;
            Cost.NullText = "";
            tStyle.GridColumnStyles.Add(Cost);
            var Quantity = new DataGridLabelColumn();
            Quantity.Format = "";
            Quantity.FormatInfo = null;
            Quantity.HeaderText = "Qty";
            Quantity.MappingName = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Width = 40;
            Quantity.NullText = "";
            tStyle.GridColumnStyles.Add(Quantity);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 45;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var Charge = new DataGridLabelColumn();
            Charge.Format = "C";
            Charge.FormatInfo = null;
            Charge.HeaderText = "Charge";
            Charge.MappingName = "Total";
            Charge.ReadOnly = true;
            Charge.Width = 65;
            Charge.NullText = "ï¿½0.00";
            tStyle.GridColumnStyles.Add(Charge);
            tStyle.MappingName = Enums.TableNames.tblEngineerVisitPartProductCharges.ToString();
            dgPartsProductCharging.TableStyles.Add(tStyle);
        }

        public void SetupTimeSheetChargeDataGrid()
        {
            Helper.SetUpDataGrid(dgTimesheetCharges);
            var tStyle = dgTimesheetCharges.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.AllowSorting = false;
            tStyle.ReadOnly = false;
            dgTimesheetCharges.ReadOnly = false;
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var StartDateTime = new DataGridLabelColumn();
            StartDateTime.Format = "dd/MM/yy HH:mm";
            StartDateTime.FormatInfo = null;
            StartDateTime.HeaderText = "Start ";
            StartDateTime.MappingName = "StartDateTime";
            StartDateTime.ReadOnly = true;
            StartDateTime.Width = 95;
            StartDateTime.NullText = "";
            tStyle.GridColumnStyles.Add(StartDateTime);
            var EndDateTime = new DataGridLabelColumn();
            EndDateTime.Format = "dd/MM/yy HH:mm";
            EndDateTime.FormatInfo = null;
            EndDateTime.HeaderText = "End";
            EndDateTime.MappingName = "EndDateTime";
            EndDateTime.ReadOnly = true;
            EndDateTime.Width = 95;
            EndDateTime.NullText = "";
            tStyle.GridColumnStyles.Add(EndDateTime);
            var EngineerCost = new DataGridLabelColumn();
            EngineerCost.Format = "C";
            EngineerCost.FormatInfo = null;
            EngineerCost.HeaderText = "Eng. Cost";
            EngineerCost.MappingName = "EngineerCost";
            EngineerCost.ReadOnly = true;
            EngineerCost.Width = 80;
            EngineerCost.NullText = "";
            tStyle.GridColumnStyles.Add(EngineerCost);
            var Price = new DataGridLabelColumn();
            Price.Format = "C";
            Price.FormatInfo = null;
            Price.HeaderText = "Price";
            Price.MappingName = "Price";
            Price.ReadOnly = true;
            Price.Width = 60;
            Price.NullText = "";
            tStyle.GridColumnStyles.Add(Price);
            var TimesheetID = new DataGridLabelColumn();
            TimesheetID.Format = "";
            TimesheetID.FormatInfo = null;
            TimesheetID.HeaderText = "TimesheetID";
            TimesheetID.MappingName = "TimesheetID";
            TimesheetID.ReadOnly = true;
            TimesheetID.Width = 5;
            TimesheetID.NullText = "";
            tStyle.GridColumnStyles.Add(TimesheetID);
            tStyle.MappingName = Enums.TableNames.tblEngineerVisitTimeSheetCharges.ToString();
            dgTimesheetCharges.TableStyles.Add(tStyle);
        }

        private void btnAddAdditionalCharge_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            if (!(txtAdditionalChargeDescription.Text.Trim().Length > 0))
            {
                errMsg += "* Charge Description Required" + Environment.NewLine;
            }

            if (!(txtAdditionalCharge.Text.Trim().Length > 0))
            {
                errMsg += "* Charge Required" + Environment.NewLine;
            }
            else if (!txtAdditionalCharge.Text.All(char.IsDigit))
            {
                errMsg += "* Charge Must Be Numeric" + Environment.NewLine;
            }

            if (errMsg.Length > 0)
            {
                errMsg = "Please correct the following errors:" + Environment.NewLine + errMsg;
                MessageBox.Show(errMsg, "Additional Charge", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Insert(EngineerVisit.EngineerVisitID, txtAdditionalChargeDescription.Text, Helper.MakeDoubleValid(txtAdditionalCharge.Text));
                txtAdditionalCharge.Text = "";
                txtAdditionalChargeDescription.Text = "";
                PopulateAdditionalCharges();
            }
        }

        private void btnRemoveAdditionalCharge_Click(object sender, EventArgs e)
        {
            if (!(SelectedAdditionalChargesDataRow is null))
            {
                App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Delete((int)SelectedAdditionalChargesDataRow["EngineerVisitAdditionalChargeID"]);
                PopulateAdditionalCharges();
            }
        }

        private void dgScheduleOfRateCharges_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgScheduleOfRateCharges.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgScheduleOfRateCharges.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedScheduleOfRateChargesDataRow is null)
                {
                    return;
                }

                App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Delete((int)SelectedScheduleOfRateChargesDataRow["EngineerVisitScheduleOfRateChargesID"]);

                if (SelectedScheduleOfRateChargesDataRow.Field<bool>("tick") == false)
                {
                    App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID,
                        SelectedScheduleOfRateChargesDataRow.Field<int>("jobitemID"), SelectedScheduleOfRateChargesDataRow.Field<double>("Price"), 1);
                }
                else
                {
                    App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID,
                         SelectedScheduleOfRateChargesDataRow.Field<int>("jobitemID"), SelectedScheduleOfRateChargesDataRow.Field<double>("Price"), 0);
                }

                PopulateScheduleOfRateCharges();
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNominalCode_TextChanged(object sender, EventArgs e)
        {
            SaveVisitCharge();
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveVisitCharge();
        }

        private void txtAccountCode_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountCode.Text.Trim().Length == 0)
            {
                App.ShowMessage("Account code cannot be blank", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAccountCode.Text = EngVisitCharge.ForSageAccountCode;
                return;
            }

            SaveVisitCharge();
        }

        private void dgPartsProductCharging_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgPartsProductCharging.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgPartsProductCharging.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedPartProductsChargesDataRow is null)
                {
                    return;
                }

                double price = SelectedPartProductsChargesDataRow.Field<double>("Rate") * (1 + Helper.MakeIntegerValid(txtPartsMarkUp.Text) / 100);
                if (SelectedPartProductsChargesDataRow.Field<string>("Type") == "Part")
                {
                    try   // loosing the plot
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete((int)SelectedPartProductsChargesDataRow["ChargeID"]);
                    }
                    catch (Exception ex)
                    {
                    }

                    if (SelectedPartProductsChargesDataRow.Field<bool>("tick") == false)
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, (int)SelectedPartProductsChargesDataRow["UniqueID"], price, 1, SelectedPartProductsChargesDataRow.Field<double>("Rate"), SelectedPartProductsChargesDataRow.Field<int>("PartUsedID"));
                    }
                    else
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, (int)SelectedPartProductsChargesDataRow["UniqueID"], price, 0, SelectedPartProductsChargesDataRow.Field<double>("Rate"), SelectedPartProductsChargesDataRow.Field<int>("PartUsedID"));
                    }
                }
                else
                {
                    App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete(Helper.MakeIntegerValid(SelectedPartProductsChargesDataRow["ChargeID"]));
                    if (SelectedPartProductsChargesDataRow.Field<bool>("tick") == false)
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, (int)SelectedPartProductsChargesDataRow["UniqueID"], price, 1, SelectedPartProductsChargesDataRow.Field<double>("Rate"));
                    }
                    else
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, (int)SelectedPartProductsChargesDataRow["UniqueID"], price, 0, SelectedPartProductsChargesDataRow.Field<double>("Rate"));
                    }
                }

                PopulatePartsProductsCharges(false, true);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdoJobValue_CheckedChanged(object sender, EventArgs e)
        {
            // The Job Value
            if (rdoJobValue.Checked == true)
            {
                // Will always produce an invoice
                gpbInvoice.Enabled = true;
                ShowEditableVisitCharges();
                cbxReadyToBeInvoiced.Enabled = true;
                // Check we have the VisitCharges
                if (EngVisitCharge is object)
                {
                    // Make sure we're not overwriting status alreay set - shouldn't be possible
                    if ((Enums.InvoiceReady)EngVisitCharge.InvoiceReadyID == Enums.InvoiceReady.Ready)
                    {
                        cbxReadyToBeInvoiced.Checked = true;
                    }
                    else
                    {
                        cbxReadyToBeInvoiced.Checked = false;
                    }
                }

                txtPercentOfQuote.ReadOnly = true;
            }

            SaveVisitCharge();
        }

        private void rdoChargeOther_CheckedChanged(object sender, EventArgs e)
        {
            // Other Charges
            if (rdoChargeOther.Checked == true)
            {
                // Check we've got the job
                if (Job is object)
                {
                    // If it a quote we invoice
                    if ((Enums.JobDefinition)Job.JobDefinitionEnumID == Enums.JobDefinition.Quoted)
                    {
                        gpbInvoice.Enabled = true;
                        ShowEditableVisitCharges();
                        // Check we have the VisitCharges
                        if (EngVisitCharge is object)
                        {
                            // Make sure we're not overwriting status alreay set - shouldn't be possible
                            if ((Enums.InvoiceReady)EngVisitCharge.InvoiceReadyID == Enums.InvoiceReady.Ready)
                            {
                                cbxReadyToBeInvoiced.Checked = true;
                            }
                            else
                            {
                                cbxReadyToBeInvoiced.Checked = false;
                            }
                        }
                    }
                    else // Anthing else won't invoice
                    {
                        gpbInvoice.Enabled = false;
                        cbxReadyToBeInvoiced.Checked = false;
                        txtPartsMarkUp.Visible = false;
                        lblPartsMarkUp.Visible = false;
                        txtPartsMarkUp.Enabled = false;
                        txtPartsProductTotal.ReadOnly = true;
                        txtTimesheetTotal.ReadOnly = true;
                    }
                }

                txtPercentOfQuote.ReadOnly = true;
            }

            SaveVisitCharge();
        }

        private void rdoPercentageOfQuoteValue_CheckedChanged(object sender, EventArgs e)
        {
            // The Percentage of the quote
            if (rdoPercentageOfQuoteValue.Checked == true)
            {
                // Will always produce an invoice
                gpbInvoice.Enabled = true;
                ShowEditableVisitCharges();
                // Check we have the VisitCharges
                if (EngVisitCharge is object)
                {
                    // Make sure we're not overwriting status alreay set - shouldn't be possible
                    if ((Enums.InvoiceReady)EngVisitCharge.InvoiceReadyID == Enums.InvoiceReady.Ready)
                    {
                        cbxReadyToBeInvoiced.Checked = true;
                    }
                    else
                    {
                        cbxReadyToBeInvoiced.Checked = false;
                    }
                }

                txtPercentOfQuote.ReadOnly = false;
            }

            SaveVisitCharge();
        }

        private void txtPercentOfQuote_TextChanged(object sender, EventArgs e)
        {
            double percentage = 0.0;
            double percentTotal = 0.0;
            if (!(txtPercentOfQuote.Text.Trim().Length == 0))
            {
                if (txtPercentOfQuote.Text.All(char.IsDigit))
                {
                    percentage = Helper.MakeDoubleValid(txtPercentOfQuote.Text);
                    percentTotal = Helper.MakeDoubleValid(txtCharge.Text) / 100 * percentage;
                    lblQuotePercentageTotal.Text = percentTotal.ToString("C");
                    SaveVisitCharge();
                }
                else
                {
                    lblQuotePercentageTotal.Text = "ERROR";
                }
            }
            else
            {
                lblQuotePercentageTotal.Text = "ERROR";
            }
        }

        private void dgTimesheetCharges_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                DataGrid.HitTestInfo HitTestInfo;
                HitTestInfo = dgTimesheetCharges.HitTest(e.X, e.Y);
                if (HitTestInfo.Type == DataGrid.HitTestType.Cell)
                {
                    dgTimesheetCharges.CurrentRowIndex = HitTestInfo.Row;
                }

                if (!(HitTestInfo.Column == 0))
                {
                    return;
                }

                if (SelectedTimeSheetChargesDataRow is null)
                {
                    return;
                }

                if (SelectedTimeSheetChargesDataRow.Field<bool>("tick") == false)
                {
                    if (SelectedTimeSheetChargesDataRow.Field<int>("EngineerVisitTimesheetChargeID") == 0)
                    {
                        InsertEngineerTimnesheetCharge(SelectedTimeSheetChargesDataRow.Field<DateTime>("StartDateTime"), SelectedTimeSheetChargesDataRow.Field<DateTime>("EndDateTime"),
                            SelectedTimeSheetChargesDataRow.Field<int>("TimesheetID"), SelectedTimeSheetChargesDataRow.Field<int>("TimeSheetTypeID"), SelectedTimeSheetChargesDataRow.Field<double>("EngineerCost"),
                            true, SelectedTimeSheetChargesDataRow.Field<int>("EngineerVisitID"));
                    }
                    else
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(SelectedTimeSheetChargesDataRow.Field<int>("EngineerVisitTimesheetChargeID"), 1);
                    }
                }
                else
                {
                    App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update(SelectedTimeSheetChargesDataRow.Field<int>("EngineerVisitTimesheetChargeID"), 0);
                }

                PopulateTimeSheetCharges(false, true);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxReadyToBeInvoiced_CheckedChanged(object sender, EventArgs e)
        {
            if (EngVisitCharge is null)
            {
                return;
            }

            // If its checked then lock down the charging boxes
            if (cbxReadyToBeInvoiced.Checked)
            {
                double chargeableAmount = 0.0;
                if (Job.JobDefinitionEnumID == (int)Enums.JobDefinition.Quoted)
                {
                    var switchExpr = (Enums.JobChargingType)EngVisitCharge.ChargeTypeID;
                    switch (switchExpr)
                    {
                        case Enums.JobChargingType.JobValue:
                            {
                                chargeableAmount = EngVisitCharge.JobValue;
                                break;
                            }

                        case Enums.JobChargingType.PercentageOfQuote:
                            {
                                chargeableAmount = EngVisitCharge.Charge;
                                break;
                            }

                        case Enums.JobChargingType.QuoteValue:
                            {
                                chargeableAmount = Helper.MakeDoubleValid(txtCharge.Text);
                                break;
                            }
                    }
                }
                else
                {
                    chargeableAmount = EngVisitCharge.JobValue;
                }

                if (chargeableAmount > 0)
                {
                    SetPriceIncVAT();
                    gpbScheduleOfRates.Enabled = false;
                    gpbPartsAndProducts.Enabled = false;
                    gpbTimesheets.Enabled = false;
                    gpbAdditionalCharges.Enabled = false;
                    // gpbMileage.Enabled = False
                    gpbCharges.Enabled = false;
                    cbxVisitLockDown.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    App.ShowMessage("Charge Amount must be greater than zero", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxReadyToBeInvoiced.Checked = false;
                }
            }
            else
            {
                gpbScheduleOfRates.Enabled = true;
                gpbPartsAndProducts.Enabled = true;
                gpbTimesheets.Enabled = true;
                gpbAdditionalCharges.Enabled = true;
                // gpbMileage.Enabled = True
                gpbCharges.Enabled = true;
                cbxVisitLockDown.Enabled = true;
                btnSave.Enabled = true;
            }

            SaveVisitCharge();
            LoadReadyToBeInvoicedDetails();
        }

        private void SetPriceIncVAT()
        {
            if (EngVisitCharge is object)
            {
                Entity.VATRatess.VATRates vatRate;
                if (Helper.MakeDoubleValid(Combo.get_GetSelectedItemValue(cboVATRate)) < 1)
                {
                    vatRate = App.DB.VATRatesSQL.VATRates_Get(App.DB.VATRatesSQL.VATRates_Get_ByDate(dtpRaiseInvoiceOn.Value));
                }
                else
                {
                    vatRate = App.DB.VATRatesSQL.VATRates_Get(Convert.ToInt32(Combo.get_GetSelectedItemValue(cboVATRate)));
                }

                if (vatRate is object)
                {
                    txtPriceIncVAT.Text = (EngVisitCharge.JobValue * (1 + vatRate.VATRate / 100)).ToString("C");
                }
            }
        }

        private void dtpRaiseInvoiceOn_ValueChanged(object sender, EventArgs e)
        {
            if (InvoiceToBeRaised is null)
            {
                return;
            }

            SetPriceIncVAT();
            SaveInvoiceToBeRaisedDetails();
        }

        private void btnAddSoR_Click(object sender, EventArgs e)
        {
            var SoR = new DataTable();
            SoR.Columns.Add("ScheduleOfRatesCategoryID");
            SoR.Columns.Add("Category");
            SoR.Columns.Add("Code");
            SoR.Columns.Add("Description");
            SoR.Columns.Add("Price");
            SoR.Columns.Add("Quantity");
            SoR.Columns.Add("Total");
            SoR.Columns.Add("RateID");
            SoR.Columns.Add("TimeInMins");
            SoR.Columns.Add("SystemLinkID");
            var argDataviewToLinkToIn = new DataView(SoR);
            using (var f = new FRMSiteScheduleOfRateList(theSite.SiteID, ref argDataviewToLinkToIn, true, false))
            {
                f.ShowDialog();
            }

            foreach (DataRow newSoR in SoR.Rows)
            {
                var newJbItm = new Entity.JobItems.JobItem();
                newJbItm.SetJobOfWorkID = EngineerVisit.JobOfWorkID;
                newJbItm.SetQty = newSoR["Quantity"];
                newJbItm.SetRateID = newSoR["RateID"];
                newJbItm.SetSummary = newSoR["Description"];
                newJbItm.SetSystemLinkID = newSoR["SystemLinkID"];

                // SAVE TO JOB
                newJbItm = App.DB.JobItems.Insert(newJbItm);

                // SAVE VISIT UNITS USED
                App.DB.EngineerVisits.EngineerVisitUnitsUsed_Insert(EngineerVisit.EngineerVisitID, newJbItm.JobItemID, Helper.MakeDoubleValid(newJbItm.Qty));

                // SAVE TO ENGINEER VISIT SCHEDULE RATES CHARGES
                App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, newJbItm.JobItemID, Helper.MakeDoubleValid(newSoR["Price"]), 1);
            }

            JobItems = App.DB.EngineerVisits.EngineerVisitUnitsUsed_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID);
            dgJobItems.DataSource = JobItems;
            PopulateScheduleOfRateCharges();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (InvoiceToBeRaised is null)
            {
                return;
            }

            var frm = new FRMSelectInvoiceAddress(theSite.SiteID);
            if (!(frm.ShowDialog() == DialogResult.OK))
            {
                frm.Dispose();
                return;
            }

            InvoiceToBeRaised.SetAddressLinkID = frm.AddressLinkID;
            InvoiceToBeRaised.SetAddressTypeID = frm.AddressTypeID;
            frm.Dispose();
            SaveInvoiceToBeRaisedDetails();
        }

        private void ShowEditableVisitCharges()
        {
            if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.VisitCharge))
            {
                txtPartsMarkUp.Visible = true;
                lblPartsMarkUp.Visible = true;
                txtPartsMarkUp.Enabled = true;
                txtPartsProductTotal.ReadOnly = false;
                txtTimesheetTotal.ReadOnly = false;
            }
        }

        private void InsertCharges(Entity.QuoteJobs.QuoteJob jbQuote)
        {
            EngVisitCharge = new EngineerVisitCharge();

            // MileageRate
            var switchExpr = (Enums.JobDefinition)Job.JobDefinitionEnumID;
            switch (switchExpr)
            {
                case Enums.JobDefinition.Quoted:
                    {
                        if (jbQuote is null)
                        {
                            EngVisitCharge.SetLabourRate = App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID);
                            EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.JobValue;
                            EngVisitCharge.SetCharge = 0;
                            EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Not_Ready;
                        }
                        else
                        {
                            EngVisitCharge.SetLabourRate = Helper.MakeDoubleValid(jbQuote.MileageRate);
                            EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.QuoteValue;
                            EngVisitCharge.SetCharge = 0;
                            EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Not_Ready;
                        }

                        break;
                    }

                case Enums.JobDefinition.Contract:
                    {
                        // NEED TO SEE IF WE ARE INVOICING PER VISIT OR NOT?
                        int invoiceFreqID = App.DB.EngineerVisitCharge.EngineerVisitCharge_GetContractInvoiceFrequency(EngineerVisit.EngineerVisitID);
                        EngVisitCharge.SetLabourRate = App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_ContractJob(Job.JobID);
                        if ((Enums.InvoiceFrequency)invoiceFreqID == Enums.InvoiceFrequency.Per_Visit)
                        {
                            // IF IS THEN LETS CHARGE FOR THE VISIT
                            EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.JobValue;
                            EngVisitCharge.SetCharge = 0;
                            EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Not_Ready;
                            lblContractPerVisit.Visible = true;
                        }
                        else
                        {
                            EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.NoChargeContractInvoice;
                            EngVisitCharge.SetCharge = 0;
                            EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Never;
                            lblContractPerVisit.Visible = false;
                        }

                        break;
                    }

                case Enums.JobDefinition.Misc:
                    {
                        EngVisitCharge.SetLabourRate = App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID);
                        EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.NoChargeMisc;
                        EngVisitCharge.SetCharge = 0;
                        EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Never;
                        break;
                    }

                case Enums.JobDefinition.Callout:
                    {
                        EngVisitCharge.SetLabourRate = App.DB.EngineerVisitCharge.EngineerVisit_Get_MileageRate_For_Site(EngineerVisit.EngineerVisitID);
                        EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.JobValue;
                        EngVisitCharge.SetCharge = 0;
                        EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Not_Ready;
                        break;
                    }
            }

            CustomerCharge = App.DB.CustomerCharge.CustomerCharge_GetForCustomer(theSite.CustomerID);
            string CustomerNominal = "";
            CustomerNominal = App.DB.Customer.Customer_Get_ForSiteID(theSite.SiteID).Nominal;
            EngVisitCharge.SetNominalCode = CustomerNominal;
            var visitEngineer = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
            int cc = GetCostCentre();
            EngVisitCharge.SetDepartment = cc != -1 ? cc.ToString() : visitEngineer?.Department;
            EngVisitCharge.SetForSageAccountCode = "";
            EngVisitCharge.SetMainContractorDiscount = App.DB.EngineerVisitCharge.EngineerVisit_Get_CustomerContractorDiscount(EngineerVisit.EngineerVisitID);
            EngVisitCharge.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
            EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Insert(EngVisitCharge);

            // Schedule OF Rates
            double scheduleOfRatesTotal = 0.0;
            foreach (DataRow jobItemDR in JobItems.Table.Rows)
            {
                App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Insert(EngineerVisit.EngineerVisitID, (int)jobItemDR["JobItemID"], Helper.MakeDoubleValid(jobItemDR["Price"]), 1);
                scheduleOfRatesTotal += Helper.MakeDoubleValid(jobItemDR["Price"]);
            }

            // Part&Products

            txtPartsMarkUp.Text = CustomerCharge.PartsMarkup.ToString();
            foreach (DataRow row in EngineerVisit.PartsAndProductsUsed.Table.Rows)
            {
                if (row.Field<string>("Type") == "Part")
                {
                    App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, row.Field<int>("ID"), Helper.MakeDoubleValid(row["SellPrice"]), 1, GetPartProductCost(row), (int)row["UniqueID"]);
                }
                else
                {
                    App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, (int)row["ID"], Helper.MakeDoubleValid(row["SellPrice"]), 1, GetPartProductCost(row));
                }
            }

            bool tick = true;
            if (scheduleOfRatesTotal > 0)
            {
                tick = false; // Don't want both timesheets and schedule of rates - charging twice
            }

            // GET correct labour rates for a site
            double normalRate = 0.0;
            double timeNHalfRate = 0.0;
            double doubleRate = 0.0;
            double engineerCostNormal = 0.0;
            double engineerCostTimeHalf = 0.0;
            double engineerCostDouble = 0.0;
            if (visitEngineer is object)
            {
                engineerCostNormal = visitEngineer.CostToCompanyNormal;
                engineerCostTimeHalf = visitEngineer.CostToCompanyTimeAndHalf;
                engineerCostDouble = visitEngineer.CostToCompanyDouble;
                InsertVisitEngineer(visitEngineer);
            }

            if (CustomerCharge is object)
            {
                Entity.CustomerScheduleOfRates.CustomerScheduleOfRate TradeLabourRate;
                var custSorTable = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Get(theSite.CustomerID, Job.JobTypeID).Table;
                if (custSorTable.Rows.Count > 0)
                {
                    int id = (int)custSorTable.Rows[0]["CustomerScheduleOfRateID"];
                    TradeLabourRate = App.DB.CustomerScheduleOfRate.Get(id);  // Using a trade rate for a linked type of work
                    normalRate = TradeLabourRate.Price;
                    timeNHalfRate = TradeLabourRate.Price;
                    doubleRate = TradeLabourRate.Price;
                }

                foreach (DataRow timeSheet in EngineerVisit.TimeSheets.Table.Rows)
                    InsertEngineerTimnesheetCharge(timeSheet.Field<DateTime>("StartDateTime"), timeSheet.Field<DateTime>("EndDateTime"), (int)timeSheet["EngineerVisitTimeSheetID"], (int)timeSheet["TimeSheetTypeID"], 0, tick, EngineerVisit.EngineerVisitID);
            }
        }

        private void InsertVisitEngineer(Engineer engineer)
        {
            var evEngineer = new EngineerVisitEngineer()
            {
                EngineerVisitId = EngineerVisit.EngineerVisitID,
                EngineerId = engineer.EngineerID,
                Department = Helper.MakeIntegerValid(engineer.Department),
                OftecNo = engineer.OftecNo,
                GasSafeNo = engineer.GasSafeNo,
                ManagerId = engineer.ManagerUserID,
                CostToCompany = engineer.CostToCompanyNormal
            };
            evEngineer = App.DB.EvEngineer.Insert(evEngineer);
        }

        private void InsertEngineerTimnesheetCharge(DateTime StartDateTime, DateTime EndDateTime, int TimesheetID, int TimesheettypeID, double EngCost, bool Tick, int EngineerVisitID)
        {
            double normalRate = 0.0;
            double timeNHalfRate = 0.0;
            double doubleRate = 0.0;
            double engineerCostNormal = 0.0;
            double engineerCostTimeHalf = 0.0;
            double engineerCostDouble = 0.0;
            var eng = App.DB.Engineer.Engineer_Get(EngineerVisit.EngineerID);
            if (eng is object)
            {
                engineerCostNormal = eng.CostToCompanyNormal;
                engineerCostTimeHalf = eng.CostToCompanyTimeAndHalf;
                engineerCostDouble = eng.CostToCompanyDouble;
            }

            Entity.CustomerScheduleOfRates.CustomerScheduleOfRate TradeLabourRate;
            var custSorTable = App.DB.CustomerScheduleOfRate.Customer_Jobtype_Sor_Get(theSite.CustomerID, Job.JobTypeID).Table;
            if (custSorTable.Rows.Count > 0)
            {
                int id = (int)custSorTable.Rows[0]["CustomerScheduleOfRateID"];
                TradeLabourRate = App.DB.CustomerScheduleOfRate.Get(id);  // Using a trade rate for a linked type of work
                normalRate = TradeLabourRate.Price;
                timeNHalfRate = TradeLabourRate.Price;
                doubleRate = TradeLabourRate.Price;
            }

            double totalPrice = 0.0;
            string summaryStr = "";
            int bankHolidayRate = 0;
            double engineerCostTotal = 0.0;

            // see if bank holiday first
            bankHolidayRate = App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_BankHoliday(StartDateTime);
            if (bankHolidayRate == 0)
            {
                var timeSheetRates = new DataView();
                timeSheetRates = App.DB.EngineerVisitCharge.EngineerVisitTimesheetCharge_ByTimeSheet(TimesheetID);
                foreach (DataRow rate in timeSheetRates.Table.Rows)
                {
                    var switchExpr = (Enums.LabourTypes)(int)rate["rate"];
                    int total = rate.Field<int>("Total");
                    switch (switchExpr)
                    {
                        case Enums.LabourTypes.Basic:
                            {
                                totalPrice += total / 60 * normalRate;
                                summaryStr += "Basic: " + total + "mins@" + normalRate.ToString("C") + "/hr; ";
                                engineerCostTotal += total / 60 * engineerCostNormal;
                                break;
                            }

                        case Enums.LabourTypes.Time_And_Half:
                            {
                                totalPrice += total / 60 * timeNHalfRate;
                                summaryStr += "Time&Half: " + total + "mins@" + timeNHalfRate.ToString("C") + "/hr; ";
                                engineerCostTotal += total / 60 * engineerCostTimeHalf;
                                break;
                            }

                        case Enums.LabourTypes.Double:
                            {
                                totalPrice += total / 60 * doubleRate;
                                summaryStr += "Double: " + total + "mins@" + doubleRate.ToString("C") + "/hr; ";
                                engineerCostTotal += total / 60 * engineerCostDouble;
                                break;
                            }
                    }
                }
            }
            else
            {
                var switchExpr1 = (Enums.LabourTypes)bankHolidayRate;
                switch (switchExpr1)
                {
                    case Enums.LabourTypes.Basic:
                        {
                            totalPrice = (EndDateTime - StartDateTime).Minutes / 60 * normalRate;
                            summaryStr += "Bank Holiday Rate (Basic): " + (EndDateTime - StartDateTime).Minutes + "mins@" + normalRate.ToString("C") + "/hr; ";
                            engineerCostTotal += (EndDateTime - StartDateTime).Minutes / 60 * engineerCostNormal;
                            break;
                        }

                    case Enums.LabourTypes.Time_And_Half:
                        {
                            totalPrice = (EndDateTime - StartDateTime).Minutes / 60 * timeNHalfRate;
                            summaryStr += "Bank Holiday Rate (Time&Half): " + (EndDateTime - StartDateTime).Minutes + "mins@" + timeNHalfRate.ToString("C") + "/hr; ";
                            engineerCostTotal += (EndDateTime - StartDateTime).Minutes / 60 * engineerCostTimeHalf;
                            break;
                        }

                    case Enums.LabourTypes.Double:
                        {
                            totalPrice = (EndDateTime - StartDateTime).Minutes / 60 * doubleRate;
                            summaryStr += "Bank Holiday Rate (Double): " + (EndDateTime - StartDateTime).Minutes + "mins@" + doubleRate.ToString("C") + "/hr; ";
                            engineerCostTotal += (EndDateTime - StartDateTime).Minutes / 60 * engineerCostDouble;
                            break;
                        }
                }
            }

            if (EngCost > 0)
            {
                engineerCostTotal = EngCost;
            }

            App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Insert(EngineerVisitID, Convert.ToInt32(Tick), StartDateTime, EndDateTime, totalPrice, TimesheettypeID, summaryStr, engineerCostTotal);
        }

        private void DeleteCharges()
        {
            // Delete Charges
            if (EngVisitCharge is object)
            {
                App.DB.EngineerVisitCharge.EngineerVisitCharge_Delete(EngVisitCharge.EngineerVisitChargeID);
            }

            // Delete Additonal Charges
            if (AdditionalCharges is object)
            {
                foreach (DataRow addCharge in AdditionalCharges.Table.Rows)
                    App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Delete((int)addCharge["EngineerVisitAdditionalChargeID"]);
            }

            // Delete Schedule OF Rate
            if (ScheduleOfRateCharges is object)
            {
                foreach (DataRow SofR in ScheduleOfRateCharges.Table.Rows)
                    App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Delete((int)SofR["EngineerVisitScheduleOfRateChargesID"]);
            }

            App.DB.EvEngineer.Delete(EngineerVisit.EngineerVisitID, DeleteBy.EngineerVisitId);

            // Parts & Products
            App.DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Delete_For_EngineerVisitID(EngineerVisit.EngineerVisitID);

            // Timesheets
            App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Delete(EngineerVisit.EngineerVisitID);
            // Save()
        }

        private void PopulateCharges(bool initialLoad = false)
        {
            Loading = true;
            var jbQuote = new Entity.QuoteJobs.QuoteJob();
            // If its quoted work get the quote
            if (Job.JobDefinitionEnumID == (int)Enums.JobDefinition.Quoted)
            {
                jbQuote = App.DB.QuoteJob.Get(Job.QuoteID);
            }

            // See the charge reocrd alreay exists
            EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Get(EngineerVisit.EngineerVisitID);

            // if doesn't exist - insert
            if (EngVisitCharge is null)
            {
                InsertCharges(jbQuote);
            }

            if (Helper.MakeDoubleValid(txtPartsMarkUp.Text) == 0)
                txtPartsMarkUp.Text = EngVisitCharge.PartsMarkUp.ToString();

            // Make all additional quote labels invisible
            rdoPercentageOfQuoteValue.Visible = false;
            lblPercent.Visible = false;
            txtPercentOfQuote.Visible = false;
            txtCharge.Visible = false;
            lblEquals.Visible = false;
            lblQuotePercentageTotal.Visible = false;
            lblOR.Visible = false;

            // Check the radio button for the type of job charge
            var switchExpr = (Enums.JobChargingType)EngVisitCharge.ChargeTypeID;
            switch (switchExpr)
            {
                case Enums.JobChargingType.JobValue:
                    {
                        rdoJobValue.Checked = true;
                        break;
                    }

                case Enums.JobChargingType.PercentageOfQuote:
                    {
                        rdoPercentageOfQuoteValue.Checked = true;
                        txtPercentOfQuote.Text = EngVisitCharge.Charge.ToString();
                        break;
                    }

                default:
                    {
                        rdoChargeOther.Checked = true;
                        break;
                    }
            }

            // Now show other controls/text dependent on job definition
            var switchExpr1 = (Enums.JobDefinition)Job.JobDefinitionEnumID;
            switch (switchExpr1)
            {
                case Enums.JobDefinition.Quoted:
                    {
                        rdoChargeOther.Text = "No Charge For Callout Work";
                        break;
                    }

                case Enums.JobDefinition.Contract:
                    {
                        rdoChargeOther.Text = "No Charge - included On Contract Invoice";
                        break;
                    }

                case Enums.JobDefinition.Misc:
                    {
                        rdoChargeOther.Text = "No Charge For Miscellaneous Work";
                        break;
                    }

                case Enums.JobDefinition.Callout:
                    {
                        rdoChargeOther.Text = "No Charge For Callout Work";
                        break;
                    }
            }

            var switchExpr2 = (Enums.InvoiceReady)EngVisitCharge.InvoiceReadyID;
            switch (switchExpr2)
            {
                case Enums.InvoiceReady.Never:
                    {
                        cbxReadyToBeInvoiced.Checked = false;
                        cbxReadyToBeInvoiced.Enabled = false;
                        break;
                    }

                case Enums.InvoiceReady.Not_Ready:
                    {
                        cbxReadyToBeInvoiced.Checked = false;
                        cbxReadyToBeInvoiced.Enabled = true;
                        break;
                    }

                case Enums.InvoiceReady.Ready:
                    {
                        cbxReadyToBeInvoiced.Checked = true;
                        cbxReadyToBeInvoiced.Enabled = true;
                        break;
                    }
            }

            PopulateCostsTo();
            PopulateSageDetails();
            PopulateAdditionalCharges(true);
            PopulateScheduleOfRateCharges(true);
            PopulatePartsProductsCharges(true);
            PopulateTimeSheetCharges(true);
            CalculateJobValue();
            InvoiceToBeRaised = App.DB.InvoiceToBeRaised.InvoiceToBeRaised_Get_By_LinkID(EngVisitCharge.EngineerVisitChargeID, Enums.InvoiceType.Visit);
            var taxrateid = new DataTable();
            if (InvoiceToBeRaised is object) // at least we know this is past the stage of being readied for an invoice if not fully invoiced -  we need to check next if it is at ready to be invoiced or invoiced
            {
                DisplayInvoiceAddress(InvoiceToBeRaised.AddressLinkID, InvoiceToBeRaised.AddressTypeID);
                taxrateid = App.DB.ExecuteWithReturn("Select TOP(1) i.VATRateID, i.InvoiceNumber, i.TermID, i.PaidByID,il.Amount,il.CreditAmount from tblInvoiced i inner  JOIN (Select SUM(Amount) Amount , ISNULL(SUM(CreditAmount),0) CreditAmount, InvoicedID,InvoiceToBeRaisedID from tblInvoicedLines il2 LEFT JOIN tblInvoicedLinesCredit ilc On ilc.InvoicedLineID = il2.InvoicedLineID   Group by InvoicedID,InvoiceToBeRaisedID) il On il.invoicedid = i.InvoicedID  where InvoiceToBeRaisedID =  " + InvoiceToBeRaised.InvoiceToBeRaisedID);
                var readytobe = App.DB.ExecuteWithReturn("Select PaymentTermID,TaxrateID from tblInvoiceToBeRaised where InvoiceToBeRaisedID =  " + InvoiceToBeRaised.InvoiceToBeRaisedID);
                // brought in two tables to compare and use values ready to be invoice and invoiced

                if (taxrateid.Rows.Count == 0 || taxrateid.Rows[0].GetNullableValue<int?>("VATRateID") == null) // Check invoice details first if fail go looking for ready to be invoiced details..
                {
                    var argc = cboVATRate;
                    Combo.SetUpCombo(ref argc, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select);

                    if (readytobe is null || readytobe.Rows[0].GetNullableValue<int?>("TaxrateID") == null) // if not check if we have a rerady to be invoiced detailed if fail use default values..
                    {
                        var argcombo = cboVATRate;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo, 6.ToString());
                        var argcombo1 = cboInvType;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo1, 69482.ToString());
                    }
                    else // if they do exist use the ready to be invoiced details
                    {
                        var argcombo2 = cboVATRate;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo2, readytobe.Rows[0].GetValue<int>("TaxrateID").ToString());
                        var argcombo3 = cboInvType;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo3, readytobe.Rows[0].Field<int>("PaymentTermID").ToString());
                    }
                }
                else // if there are invoice details (an invoice has been raised) use the invoice details
                {
                    var argc1 = cboVATRate;
                    Combo.SetUpCombo(ref argc1, App.DB.VATRatesSQL.VATRates_GetAll_InputOrOutput('O').Table, "VATRateID", "Friendly", Enums.ComboValues.Please_Select);
                    var argcombo4 = cboVATRate;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo4, taxrateid.Rows[0].GetValue<int>("VATRateID").ToString());

                    if (taxrateid.Rows[0].GetNullableValue<int?>("TermID") != null)
                    {
                        var argcombo5 = cboInvType;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo5, taxrateid.Rows[0].GetValue<int>("TermID").ToString());
                        int? paidById = taxrateid.Rows[0].Field<int?>("PaidByID");
                        if (paidById.HasValue && (paidById.Value == (int)Enums.QuoteJobOfWorkTypes.Reciept))
                        {
                            var argcombo6 = cboPaidBy;
                            Combo.SetSelectedComboItem_By_Value(ref argcombo6, paidById.Value.ToString());
                        }
                    }
                    else
                    {
                        var argcombo7 = cboInvType;
                        Combo.SetSelectedComboItem_By_Value(ref argcombo7, 69482.ToString());
                    }

                    txtInvNo.Text = taxrateid.Rows[0].Field<string>("InvoiceNumber");
                    txtInvAmount.Text = taxrateid.Rows[0].Field<decimal>("Amount").ToString("C");
                    txtCreditAmount.Text = taxrateid.Rows[0].Field<decimal>("CreditAmount").ToString("C");
                }

                dtpRaiseInvoiceOn.Value = InvoiceToBeRaised.RaiseDate;
                int i = 0;
                if (App.DB.InvoicedLines.InvoicedLines_GetAll_ByInvoiceToBeRaisedID(InvoiceToBeRaised.InvoiceToBeRaisedID).Table.Rows.Count > 0)
                {
                    gpbInvoice.Enabled = false;
                }
                else
                {
                    gpbInvoice.Enabled = true;
                }
            }
            else
            {
                var argc2 = cboVATRate;
                Combo.SetUpCombo(ref argc2, App.DB.VATRatesSQL.VATRates_GetAll_Valid().Table, "VATRateID", "Description", Enums.ComboValues.Please_Select);
                var argcombo8 = cboVATRate;
                Combo.SetSelectedComboItem_By_Value(ref argcombo8, 6.ToString());
                var argcombo9 = cboInvType;
                Combo.SetSelectedComboItem_By_Value(ref argcombo9, 69482.ToString());
            }

            Loading = false;
            chkSORDesc.Checked = EngineerVisit.UseSORDescription;
            if (initialLoad)
            {
                chkShowJobCharges.Checked = EngVisitCharge.HasChargesFromJob;
            }

            if (chkSORDesc.Checked)
            {
                txtNotesFromEngineer.Enabled = false;
            }
            else
            {
                txtNotesFromEngineer.Enabled = true;
            }

            SaveVisitCharge(initialLoad);
            ShowEditableVisitCharges();
        }

        private void PopulateAdditionalCharges(bool batchRun = false)
        {
            AdditionalCharges = App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_GetAll(EngineerVisit.EngineerVisitID);
            double additionalChargeTotal = 0.0;
            foreach (DataRow charge in AdditionalCharges.Table.Rows)
                additionalChargeTotal += Helper.MakeDoubleValid(charge["Charge"]);
            txtAdditionalChargeTotal.Text = additionalChargeTotal.ToString("C");
            if (!batchRun)
                CalculateJobValue();
        }

        private void PopulateScheduleOfRateCharges(bool batchRun = false)
        {
            ScheduleOfRateCharges = App.DB.EngineerVisitCharge.EngineerVisitScheduleOfRatesCharge_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID);
            double SORChargeTotal = 0.0;
            foreach (DataRow charge in ScheduleOfRateCharges.Table.Rows)
            {
                if (Helper.MakeBooleanValid(charge["Tick"]))
                {
                    SORChargeTotal += Helper.MakeDoubleValid(charge["Total"]);
                }
            }

            txtScheduleOfRatesTotal.Text = SORChargeTotal.ToString("C");
            if (!batchRun)
                CalculateJobValue();
        }

        private void PopulateSageDetails()
        {
            int cc = GetCostCentre();
            if (EngVisitCharge is object)
            {
                txtNominalCode.Text = EngVisitCharge.NominalCode;
                if (string.IsNullOrEmpty(EngVisitCharge.Department))
                {
                    var argcombo = cboDept;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo, cc.ToString());
                }
                else
                {
                    var argcombo1 = cboDept;
                    Combo.SetSelectedComboItem_By_Value(ref argcombo1, EngVisitCharge.Department);
                }

                txtAccountCode.Text = EngVisitCharge.ForSageAccountCode;
            }
            else
            {
                txtNominalCode.Text = "";
                var argcombo2 = cboDept;
                Combo.SetSelectedComboItem_By_Value(ref argcombo2, cc.ToString());
                txtAccountCode.Text = "";
            }
        }

        private void PopulatePartsProductsCharges(bool batchRun = false, bool recalc = false)
        {
            if (chkShowJobCharges.Checked)
            {
                PartProductsCharges = App.DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_JobID(Job.JobID, EngineerVisit.EngineerVisitID);
            }
            else
            {
                PartProductsCharges = App.DB.EngineerVisitCharge.EngineerVisitPartsAndProductsCharge_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID);
            }

            decimal PPChargeTotal = 0.0M;
            decimal PPCostTotal = 0.0M;
            foreach (DataRow charge in PartProductsCharges.Table.Rows)
                PPCostTotal += (decimal)Helper.MakeDoubleValid(charge["Rate"]) * (decimal)Helper.MakeDoubleValid(charge["Quantity"]);
            if (EngVisitCharge.PartsPrice > 0)
                PPChargeTotal = EngVisitCharge.PartsPrice;
            if (recalc | EngVisitCharge.PartsPrice == 0)
            {
                PPChargeTotal = 0;
                foreach (DataRow charge in PartProductsCharges.Table.Rows)
                {
                    if (Helper.MakeBooleanValid(charge["Tick"]))
                    {
                        PPChargeTotal += (decimal)Helper.MakeDoubleValid(charge["Total"]);
                    }
                }
            }

            txtPartsProductTotal.Text = PPChargeTotal.ToString("C");
            txtPartProductCost.Text = PPCostTotal.ToString("C");
            int tickCount = (int)PartProductsCharges.Table.Select("Tick = " + true)?.Count();
            if (tickCount == PartProductsCharges.Count)
                chkPartsSelectAll.Checked = true;
            if (tickCount == 0)
                chkPartsSelectAll.Checked = false;
            if (!batchRun)
                CalculateJobValue();
        }

        private void PopulateTimeSheetCharges(bool batchRun = false, bool recalc = false)
        {
            if (chkShowJobCharges.Checked)
            {
                TimeSheetCharges = App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get_ForJob(Job.JobID);
            }
            else
            {
                TimeSheetCharges = App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Get(EngineerVisit.EngineerVisitID);
            }

            double tSChargeTotal = 0.0;
            double tsCostTotal = 0.0;
            foreach (DataRow charge in TimeSheetCharges.Table.Rows)
                tsCostTotal += Helper.MakeDoubleValid(charge["EngineerCost"]);
            if (EngVisitCharge.LabourPrice > 0)
                tSChargeTotal = Helper.MakeDoubleValid(EngVisitCharge.LabourPrice);
            if (recalc | EngVisitCharge.LabourPrice == 0)
            {
                tSChargeTotal = 0;
                foreach (DataRow charge in TimeSheetCharges.Table.Rows)
                {
                    if (Helper.MakeBooleanValid(charge["Tick"]))
                    {
                        tSChargeTotal += Helper.MakeDoubleValid(charge["Price"]);
                    }
                }
            }

            txtTimesheetTotal.Text = tSChargeTotal.ToString("C");
            txtEngineerCostTotal.Text = tsCostTotal.ToString("C");
            int tickCount = (int)TimeSheetCharges.Table.Select("Tick = " + true)?.Count();
            if (tickCount == TimeSheetCharges.Count)
                chkTimesheetSelectAll.Checked = true;
            if (tickCount == 0)
                chkTimesheetSelectAll.Checked = false;
            if (!batchRun)
                CalculateJobValue();
        }

        private void CalculateJobValue()
        {
            double JobValue = 0.0;
            JobValue += Helper.MakeDoubleValid(txtScheduleOfRatesTotal.Text.Replace("£", ""));
            JobValue += Helper.MakeDoubleValid(txtAdditionalChargeTotal.Text.Replace("£", ""));
            JobValue += Helper.MakeDoubleValid(txtPartsProductTotal.Text.Replace("£", ""));
            JobValue += Helper.MakeDoubleValid(txtTimesheetTotal.Text.Replace("£", ""));

            // MINUS OFF THE DISCOUNT
            txtJobValue.Text = JobValue.ToString("C");
            if (EngVisitCharge is null)
            {
                EngVisitCharge = new EngineerVisitCharge();
            }

            SaveVisitCharge();
            Profitable();
        }

        private void SaveVisitCharge(bool initialLoad = false)
        {
            if (!Loading)
            {
                if (EngVisitCharge is null)
                {
                    EngVisitCharge = new EngineerVisitCharge();
                }

                string department = Helper.MakeStringValid(Combo.get_GetSelectedItemValue(cboDept));
                if (Helper.IsValidInteger(department) && Helper.MakeIntegerValid(department) < 0)
                {
                    App.ShowMessage("Please select a department!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EngVisitCharge.SetNominalCode = txtNominalCode.Text.Trim();
                EngVisitCharge.SetDepartment = Combo.get_GetSelectedItemValue(cboDept);
                EngVisitCharge.SetForSageAccountCode = txtAccountCode.Text.Trim();
                EngVisitCharge.SetMainContractorDiscount = 0;
                EngVisitCharge.SetEngineerVisitID = EngineerVisit.EngineerVisitID;
                EngVisitCharge.SetJobValue = Helper.MakeDoubleValid(txtJobValue.Text.Replace("£", ""));
                EngVisitCharge.SetTaxRateID = Combo.get_GetSelectedItemValue(cboVATRate);
                if (rdoJobValue.Checked == true) // Job Value
                {
                    EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.JobValue;
                    EngVisitCharge.SetCharge = 0;
                    if (cbxReadyToBeInvoiced.Checked)
                    {
                        EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Ready;
                    }
                    else
                    {
                        EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Not_Ready;
                    }
                }
                else if (rdoPercentageOfQuoteValue.Checked == true) // Charging a percentage of a quote
                {
                    EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.PercentageOfQuote;
                    EngVisitCharge.SetCharge = Helper.MakeDoubleValid(txtPercentOfQuote.Text.Trim());
                    if (cbxReadyToBeInvoiced.Checked)
                    {
                        EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Ready;
                    }
                    else
                    {
                        EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Not_Ready;
                    }
                }
                else
                {
                    var switchExpr = (Enums.JobDefinition)Job.JobDefinitionEnumID;
                    switch (switchExpr)
                    {
                        case Enums.JobDefinition.Quoted:
                            {
                                EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.QuoteValue;
                                EngVisitCharge.SetCharge = 0;
                                EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Never;
                                break;
                            }

                        case Enums.JobDefinition.Contract:
                            {
                                EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.NoChargeContractInvoice;
                                EngVisitCharge.SetCharge = 0;
                                EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Never;
                                break;
                            }

                        case Enums.JobDefinition.Misc:
                            {
                                EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.NoChargeMisc;
                                EngVisitCharge.SetCharge = 0; // No charge
                                EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Never;
                                break;
                            }

                        case Enums.JobDefinition.Callout:
                            {
                                EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.NoChargeCallout;
                                EngVisitCharge.SetCharge = 0; // No charge
                                EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Never;
                                break;
                            }
                    }
                }

                EngVisitCharge.SetPartsMarkUp = Helper.MakeIntegerValid(txtPartsMarkUp.Text);
                EngVisitCharge.SetPartsPrice = Helper.MakeDoubleValid(txtPartsProductTotal.Text);
                EngVisitCharge.SetLabourPrice = Helper.MakeDoubleValid(txtTimesheetTotal.Text);
                EngVisitCharge.SetHasChargesFromJob = chkShowJobCharges.Checked;
                if (EngVisitCharge.Exists)
                {
                    App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge, Job);
                }
                else
                {
                    EngVisitCharge = App.DB.EngineerVisitCharge.EngineerVisitCharge_Insert(EngVisitCharge);
                    if (cbxReadyToBeInvoiced.Checked)
                    {
                        // Status Changed enter Job Audit
                        var jA = new Entity.JobAudits.JobAudit();
                        jA.SetJobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
                        jA.SetActionChange = "Visit Status changed to Ready to be Invoiced (Unique Visit ID: " + EngineerVisit.EngineerVisitID + ")";
                        App.DB.JobAudit.Insert(jA);
                    }
                }

                if (InvoiceToBeRaised is null & initialLoad)
                {
                    AutoInvoice();
                }
            }
        }

        private void AutoInvoice()
        {
            var ibcs = App.DB.Ibc.GetAll();
            if (ibcs.Table.Rows.Count == 0)
                return;
            var ibcSupplierIds = (from x in ibcs.Table.AsEnumerable()
                                  select x.Field<int>("SupplierId")).Distinct().ToList();
            var specialPartIds = new List<int>() { Consts.IbcPoPartID, Consts.SpecialOrderPartNumber };
            var drIBCs = EngineerVisit.PartsAndProductsAllocated.Table.Select("PartProductID IN (" + string.Join(",", specialPartIds.ToArray()) + ") AND SupplierID IN (" + string.Join(",", ibcSupplierIds.ToArray()) + ")");
            if (drIBCs.Length == 1 & EngineerVisit.OutcomeEnumID == (int)Enums.EngineerVisitOutcomes.Complete)
            {
                double poValue = Helper.MakeDoubleValid(drIBCs[0]["SellPrice"]);
                int supplierId = Helper.MakeIntegerValid(drIBCs[0]["SupplierID"]);
                if (poValue <= 0)
                    return;
                if (App.ShowMessage("Auto Invoice Visit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    UnCheckAllCharges();
                    var drIbc = (from x in ibcs.Table.AsEnumerable()
                                 where x.Field<int>("SupplierId") == supplierId
                                 select x).FirstOrDefault();
                    int department = Helper.MakeIntegerValid(drIbc["Department"]);
                    int costCentre = GetCostCentre();
                    if (txtNotesFromEngineer.Text.Contains("IBC") & costCentre < 0)
                    {
                        var invoiceNotes = txtNotesFromEngineer.Text.Split(new char[] { ' ' }).ToList();
                        string ibcDetails = invoiceNotes.Where(x => x.Contains("IBC")).FirstOrDefault();
                        int ibcCostCentre = Helper.GetNumber(ibcDetails);
                        var departments = App.DB.Picklists.GetAll(Enums.PickListTypes.Department);
                        if ((from x in departments.Table.AsEnumerable()
                             where Helper.MakeDoubleValid(x.Field<string>("Name")) == ibcCostCentre
                             select x).Count() > 0)
                        {
                            costCentre = ibcCostCentre;
                        }
                    }

                    if (costCentre == -1)
                    {
                        App.ShowMessage("Could not determine cost centre!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string nominal = Helper.MakeStringValid(drIbc["Nominal"]);
                    App.DB.EngineerVisitCharge.EngineerVisitAdditionalCharge_Insert(EngineerVisit.EngineerVisitID, "IBC" + costCentre + " - " + poValue.ToString("C"), poValue);
                    EngVisitCharge.SetChargeTypeID = (int)Enums.JobChargingType.JobValue;
                    EngVisitCharge.SetInvoiceReadyID = (int)Enums.InvoiceReady.Ready;
                    EngVisitCharge.SetDepartment = department;
                    EngVisitCharge.SetCharge = poValue;
                    EngVisitCharge.SetJobValue = poValue;
                    EngVisitCharge.SetForSageAccountCode = "IBC" + costCentre;
                    EngVisitCharge.SetPartsPrice = 0;
                    EngVisitCharge.SetLabourPrice = 0;
                    if (!string.IsNullOrWhiteSpace(nominal))
                    {
                        EngVisitCharge.SetNominalCode = nominal;
                    }

                    App.DB.EngineerVisitCharge.EngineerVisitCharge_Update(EngVisitCharge, Job);
                    var invoiceAddress = new Entity.InvoiceAddresss.InvoiceAddress();
                    invoiceAddress.SetAddress1 = "DEPT " + Combo.get_GetSelectedItemValue(cboDept);
                    invoiceAddress.SetAddress2 = App.TheSystem.Configuration.CompanyName;
                    invoiceAddress.SetAddress3 = App.TheSystem.Configuration.CompanyAddres1;
                    invoiceAddress.SetAddress4 = App.TheSystem.Configuration.CompanyAddres3;
                    invoiceAddress.SetAddress5 = string.Empty;
                    invoiceAddress.SetPostcode = App.TheSystem.Configuration.CompanyPostcode;
                    invoiceAddress.SetSiteID = Job.PropertyID;
                    int invoiceAddressId = (int)App.DB.InvoiceAddress.Insert(invoiceAddress)?.InvoiceAddressID;
                    int invoiceAddressTypeId = (int)Enums.InvoiceAddressType.Invoice;
                    var invoiceRaiseDate = EngineerVisit.StartDateTime;
                    if (invoiceRaiseDate == default || DateHelper.GetFirstDayOfMonth(invoiceRaiseDate) < DateHelper.GetFirstDayOfMonth(DateTime.Now))
                    {
                        var f = new FRMContractUpgradeDowngrade();
                        f.Text = "Select Date";
                        f.lblText.Text = "Please select invoice date";
                        f.ShowDialog();
                        if (f.DialogResult == DialogResult.OK)
                        {
                            invoiceRaiseDate = f.EffDate;
                        }
                    }

                    InvoiceToBeRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                    {
                        var withBlock = InvoiceToBeRaised;
                        withBlock.SetAddressLinkID = invoiceAddressId;
                        withBlock.SetAddressTypeID = invoiceAddressTypeId;
                        withBlock.RaiseDate = invoiceRaiseDate == default ? DateTime.Now : invoiceRaiseDate;
                        withBlock.SetInvoiceTypeID = (int)Enums.InvoiceType.Visit;
                        withBlock.SetLinkID = EngVisitCharge.EngineerVisitChargeID;
                        withBlock.SetCustomerID = theSite.CustomerID;
                        withBlock.SetTaxRateID = 7;
                        withBlock.SetPaymentTermID = 69482;
                    }

                    InvoiceToBeRaised = App.DB.InvoiceToBeRaised.Insert(InvoiceToBeRaised);
                    DisplayInvoiceAddress(InvoiceToBeRaised.AddressLinkID, InvoiceToBeRaised.AddressTypeID);
                    var invoice = new Entity.Invoiceds.Invoiced();
                    var invoiceNumber = new JobNumber();
                    invoiceNumber = App.DB.Job.GetNextJobNumber((Enums.JobDefinition)5);
                    {
                        var withBlock1 = invoice;
                        withBlock1.SetInvoiceNumber = invoiceNumber.Prefix + invoiceNumber.Number;
                        withBlock1.SetRaisedByUserID = App.loggedInUser.UserID;
                        withBlock1.RaisedDate = InvoiceToBeRaised.RaiseDate;
                        withBlock1.SetVATRateID = InvoiceToBeRaised.TaxRateID;
                        withBlock1.SetPaymentTermID = InvoiceToBeRaised.PaymentTermID;
                        withBlock1.SetPaidByID = InvoiceToBeRaised.PaidByID;
                    }

                    invoice = App.DB.Invoiced.Insert(invoice);
                    var invoiceLines = new Entity.InvoicedLiness.InvoicedLines();
                    {
                        var withBlock2 = invoiceLines;
                        withBlock2.SetAmount = EngVisitCharge.Charge;
                        withBlock2.SetInvoicedID = invoice.InvoicedID;
                        withBlock2.SetInvoiceToBeRaisedID = InvoiceToBeRaised.InvoiceToBeRaisedID;
                    }

                    invoiceLines = App.DB.InvoicedLines.Insert(invoiceLines);
                    if (App.ShowMessage("Do you want to view the invoice document?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var details = new ArrayList() { new ArrayList() { new ArrayList() { invoice.InvoicedID, theSite.RegionID } } };
                        var oPrint = new Printing(details, "Invoice", Enums.SystemDocumentType.Invoice, true);
                    }

                    PopulateCharges();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void SetInvoiceControls()
        {
            lblPriceInvVAT.Visible = cbxReadyToBeInvoiced.Checked;
            txtPriceIncVAT.Visible = cbxReadyToBeInvoiced.Checked;
            lblRaiseInvoiceOn.Visible = cbxReadyToBeInvoiced.Checked;
            dtpRaiseInvoiceOn.Visible = cbxReadyToBeInvoiced.Checked;
            lblInvoiceAddressDetails.Visible = cbxReadyToBeInvoiced.Checked;
            lblAccountCode.Visible = cbxReadyToBeInvoiced.Checked;
            txtAccountCode.Visible = cbxReadyToBeInvoiced.Checked;
            btnSearch.Visible = cbxReadyToBeInvoiced.Checked;
            lblVAT.Visible = cbxReadyToBeInvoiced.Checked;
            cboVATRate.Visible = cbxReadyToBeInvoiced.Checked;
            lblInvType.Visible = cbxReadyToBeInvoiced.Checked;
            cboInvType.Visible = cbxReadyToBeInvoiced.Checked;
            lblInvNo.Visible = cbxReadyToBeInvoiced.Checked;
            txtInvNo.Visible = cbxReadyToBeInvoiced.Checked;
            lblInvAmount.Visible = cbxReadyToBeInvoiced.Checked;
            txtInvAmount.Visible = cbxReadyToBeInvoiced.Checked;
            lblcredit.Visible = cbxReadyToBeInvoiced.Checked;
            txtCreditAmount.Visible = cbxReadyToBeInvoiced.Checked;
            if (EngVisitCharge.InvoiceReadyID == (int)Enums.InvoiceReady.Ready)
            {
                btnInvoice.Visible = true;
            }
            else
            {
                btnInvoice.Visible = false;
            }
        }

        private void LoadReadyToBeInvoicedDetails()
        {
            Job = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID);
            if (Loading == false)
            {
                dtpRaiseInvoiceOn.Value = DateTime.Now;
                if (EngineerVisit.StartDateTime != default)
                {
                    dtpRaiseInvoiceOn.Value = EngineerVisit.StartDateTime;
                }

                if (cbxReadyToBeInvoiced.Checked)
                {
                    SaveInvoiceToBeRaisedDetails();
                }
                else if (InvoiceToBeRaised is object)
                {
                    DeleteInvoiceToBeRaiseDetails();
                }
            }

            SetInvoiceControls();
        }

        private void SaveInvoiceToBeRaisedDetails()
        {
            if (Loading == false)
            {
                if (InvoiceToBeRaised is null)
                {
                    var frm = new FRMSelectInvoiceAddress(theSite.SiteID);
                    if (!(frm.ShowDialog() == DialogResult.OK))
                    {
                        frm.Dispose();
                        cbxReadyToBeInvoiced.Checked = false;
                        App.ShowMessage("An invoice address must be selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    InvoiceToBeRaised = new Entity.InvoiceToBeRaiseds.InvoiceToBeRaised();
                    InvoiceToBeRaised.SetAddressLinkID = frm.AddressLinkID;
                    InvoiceToBeRaised.SetAddressTypeID = frm.AddressTypeID;
                    frm.Dispose();
                }

                InvoiceToBeRaised.RaiseDate = dtpRaiseInvoiceOn.Value;
                InvoiceToBeRaised.SetInvoiceTypeID = (int)Enums.InvoiceType.Visit;
                InvoiceToBeRaised.SetLinkID = EngVisitCharge.EngineerVisitChargeID;
                InvoiceToBeRaised.SetCustomerID = App.DB.Customer.Customer_Get_ForSiteID(theSite.SiteID).CustomerID;
                InvoiceToBeRaised.SetTaxRateID = Combo.get_GetSelectedItemValue(cboVATRate);
                InvoiceToBeRaised.SetPaymentTermID = Combo.get_GetSelectedItemValue(cboInvType);
                InvoiceToBeRaised.SetPaidByID = Combo.get_GetSelectedItemValue(cboPaidBy);
                if (InvoiceToBeRaised.Exists == false)
                {
                    InvoiceToBeRaised = App.DB.InvoiceToBeRaised.Insert(InvoiceToBeRaised);
                }
                else
                {
                    App.DB.InvoiceToBeRaised.Update(InvoiceToBeRaised);
                }

                DisplayInvoiceAddress(InvoiceToBeRaised.AddressLinkID, InvoiceToBeRaised.AddressTypeID);
            }
        }

        private void DeleteInvoiceToBeRaiseDetails()
        {
            App.DB.InvoiceToBeRaised.Delete(InvoiceToBeRaised.InvoiceToBeRaisedID);
            InvoiceToBeRaised = null;
        }

        private double GetPartProductCost(DataRow dr)
        {
            string partProductColumnName = "ID";
            string Type = Convert.ToString(dr["Type"]);

            // WAS THE PART/PRODUCT ALLOCATED TO THE JOB ?
            // Dim sR As DataRow() = EngineerVisit.PartsAndProductsAllocated.Table.Select("Type='" & Type & "' AND PartProductID=" & dr(partProductColumnName))

            var Sr = EngineerVisit.PartsAndProductsAllocated.Table.Select("Type='" + Type + "' AND  ID=" + Helper.MakeIntegerValid(dr["AllocatedID"]));
            if (Sr.Length > 0)
            {
                // WAS IT ORDERED
                if (Helper.MakeIntegerValid(Sr[0]["OrderID"]) > 0)
                {
                    var dv = App.DB.Order.Order_ItemsGetAll((int)Sr[0]["OrderID"]);
                    DataRow[] pR;
                    // WAS IT SOURCED FROM SUPPLIER
                    if ((Enums.LocationType)(int)Sr[0]["OrderLocationTypeID"] == Enums.LocationType.Supplier)
                    {
                        pR = dv.Table.Select(Convert.ToString("Type='Order" + Type + "' AND PartProductID=" + dr[partProductColumnName]));
                    }
                    else  // FROM WAREHOUSE OR VAN
                    {
                        return GetSupplierBuyPrice(dr);
                        // pR = dv.Table.Select("Type='OrderLocation" & Type & "' AND PartProductID=" & dr(partProductColumnName))
                    }

                    // FOUND PART
                    if (pR.Length > 0)
                    {
                        return Helper.MakeDoubleValid((decimal)pR[0]["BuyPrice"] * (int)dr["Quantity"]);
                    }
                    else
                    {
                        // NOT FOUND TRY GET A BUY PRICE FROM SUPPLIER
                        return GetSupplierBuyPrice(dr);
                    }
                }
                else
                {
                    // NOT ORDERED TRY GET A BUY PRICE FROM SUPPLIER
                    return GetSupplierBuyPrice(dr);
                }
            }
            else
            {
                // NOT ALLOCATED TRY GET A BUY PRICE FROM SUPPLIER
                return GetSupplierBuyPrice(dr);
            }
        }

        private double GetSupplierBuyPrice(DataRow dr)
        {
            DataTable dt;
            if ((Helper.MakeStringValid(dr["Type"]).ToLower() ?? "") == "part")
            {
                dt = App.DB.PartSupplier.Get_ByPartID((int)dr["ID"]).Table;
                var drPre = dt.Select("Preferred=1");
                if (drPre.Length > 0)
                {
                    return Helper.MakeDoubleValid((decimal)drPre[0]["Price"]) * Helper.MakeDoubleValid(dr["Quantity"]);
                }

                double lowest = 0;
                if (dt.Rows.Count > 0)
                {
                    lowest = Helper.MakeDoubleValid(dt.Rows[0]["Price"]);
                    foreach (DataRow r in dt.Rows)
                    {
                        if (Convert.ToBoolean((decimal)r["Price"] < (decimal)lowest))
                        {
                            lowest = Helper.MakeDoubleValid(r["Price"]);
                        }
                    }
                }

                return lowest * Helper.MakeDoubleValid(dr["Quantity"]);
            }
            else
            {
                dt = App.DB.ProductSupplier.Get_ByProductID((int)dr["ID"]).Table;
            }

            if (dt.Rows.Count > 0)
            {
                return Helper.MakeDoubleValid(dt.Rows[0]["Price"]) * Helper.MakeDoubleValid(dr["Quantity"]);
            }
            else
            {
                return 0;
            }
        }

        private void DisplayInvoiceAddress(int AddressLinkID, int AddressTypeID)
        {
            string address = "";
            switch (AddressTypeID)
            {
                case (int)Enums.InvoiceAddressType.HQ:
                case (int)Enums.InvoiceAddressType.Site:
                    {
                        {
                            var withBlock = App.DB.Sites.Get(AddressLinkID);
                            if (withBlock.Name.Trim().Length > 0)
                            {
                                address += withBlock.Name + Environment.NewLine;
                            }

                            if (withBlock.Address1.Trim().Length > 0)
                            {
                                address += withBlock.Address1 + Environment.NewLine;
                            }

                            if (withBlock.Address2.Trim().Length > 0)
                            {
                                address += withBlock.Address2 + Environment.NewLine;
                            }

                            if (withBlock.Address3.Trim().Length > 0)
                            {
                                address += withBlock.Address3 + Environment.NewLine;
                            }

                            if (withBlock.Address4.Trim().Length > 0)
                            {
                                address += withBlock.Address4 + Environment.NewLine;
                            }

                            if (withBlock.Address5.Trim().Length > 0)
                            {
                                address += withBlock.Address5 + Environment.NewLine;
                            }

                            if (withBlock.Postcode.Trim().Length > 0)
                            {
                                address += withBlock.Postcode + Environment.NewLine;
                            }
                        }

                        lblInvoiceAddressDetails.Text = address;
                        break;
                    }

                case (int)Enums.InvoiceAddressType.Invoice:
                    {
                        {
                            var withBlock1 = App.DB.InvoiceAddress.InvoiceAddress_Get(AddressLinkID);
                            if (withBlock1.Address1.Trim().Length > 0)
                            {
                                address += withBlock1.Address1 + Environment.NewLine;
                            }

                            if (withBlock1.Address2.Trim().Length > 0)
                            {
                                address += withBlock1.Address2 + Environment.NewLine;
                            }

                            if (withBlock1.Address3.Trim().Length > 0)
                            {
                                address += withBlock1.Address3 + Environment.NewLine;
                            }

                            if (withBlock1.Address4.Trim().Length > 0)
                            {
                                address += withBlock1.Address4 + Environment.NewLine;
                            }

                            if (withBlock1.Address5.Trim().Length > 0)
                            {
                                address += withBlock1.Address5 + Environment.NewLine;
                            }

                            if (withBlock1.Postcode.Trim().Length > 0)
                            {
                                address += withBlock1.Postcode + Environment.NewLine;
                            }
                        }

                        break;
                    }

                default:
                    {
                        address += "Not selected";
                        break;
                    }
            }

            lblInvoiceAddressDetails.Text = address;
        }

        public int GetCostCentre()
        {
            var cc = App.DB.CostCentre.Get((int)Job?.JobTypeID, theSite.CustomerID, Entity.CostCentres.Enums.GetBy.JobTypeIdAndCutomerId)?.FirstOrDefault();
            return cc is object ? cc.CostCentreId : -1;
        }

        private void ShutdownNonChargableVisits(FormClosingEventArgs e)
        {
            var visits = App.DB.EngineerVisits.EngineerVisits_Get_All_JobID((int)Job?.JobID);
            if (visits.Count == 0)
                return;
            var openVisits = visits.Table.Select("StatusEnumID = " + (int)Enums.VisitStatus.Uploaded);
            if (openVisits.Length == 0)
                return;
            string msg = "This current visit has job releated charges." + Environment.NewLine + Environment.NewLine + "There are open relating visits, do you want to cost them off as non-chargeable?";
            var dialogResult = App.ShowMessage(msg, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    {
                        foreach (DataRow visit in openVisits)
                        {
                            int evId = Helper.MakeIntegerValid(visit["EngineerVisitID"]);
                            var ev = App.DB.EngineerVisits.EngineerVisits_Get_As_Object(evId);
                            if (ev is null)
                                continue;
                            ev.SetVisitLocked = true;
                            ev.SetStatusEnumID = (int)Enums.VisitStatus.Not_To_Be_Invoiced;
                            App.DB.EngineerVisits.Update(ev, 0, true);
                            var evc = new EngineerVisitCharge();
                            {
                                var withBlock = evc;
                                withBlock.SetEngineerVisitID = ev.EngineerVisitID;
                                withBlock.SetNominalCode = txtNominalCode.Text.Trim();
                                withBlock.SetDepartment = Combo.get_GetSelectedItemValue(cboDept).Trim();
                                withBlock.SetForSageAccountCode = txtAccountCode.Text.Trim();
                                withBlock.SetInvoiceReadyID = (int)Enums.InvoiceReady.Never;
                                withBlock.SetPartsMarkUp = Helper.MakeIntegerValid(txtPartsMarkUp.Text);
                                withBlock.SetMainContractorDiscount = 0;
                                withBlock.SetJobValue = 0;
                                withBlock.SetTaxRateID = 0;
                                withBlock.SetCharge = 0;
                                withBlock.SetPartsPrice = 0;
                                withBlock.SetLabourPrice = 0;
                                withBlock.SetHasChargesFromJob = false;
                            }

                            evc = App.DB.EngineerVisitCharge.EngineerVisitCharge_Insert(evc);
                        }

                        break;
                    }

                case DialogResult.Cancel:
                    {
                        e.Cancel = true;
                        return;
                    }

                default:
                    {
                        return;
                    }
            }
        }

        public class AllocatedStatusColourColumn : DataGridLabelColumn
        {
            protected override void Paint(Graphics g, Rectangle bounds, CurrencyManager source, int rowNum, Brush backBrush, Brush foreBrush, bool alignToRight)
            {
                base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                // set the color required dependant on the column value
                Brush brush;
                DataRowView dr = (DataRowView)source.List[rowNum];
                if (Helper.MakeBooleanValid(dr["Status"]))
                {
                    brush = Brushes.Lime;
                }
                else
                {
                    brush = Brushes.Red;
                }
                // color the row cell
                var rect = bounds;
                g.FillRectangle(brush, rect);
                g.DrawString("", DataGridTableStyle.DataGrid.Font, Brushes.MidnightBlue, RectangleF.FromLTRB(rect.X, rect.Y, rect.Right, rect.Bottom));
            }
        }

        public void SetupAllocatedDG()
        {
            Helper.SetUpDataGrid(dgPartsProductsAllocated);
            var tStyle = dgPartsProductsAllocated.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            var status = new AllocatedStatusColourColumn();
            status.Format = "";
            status.FormatInfo = null;
            status.HeaderText = "";
            status.MappingName = "Status";
            status.ReadOnly = true;
            status.Width = 15;
            status.NullText = "";
            tStyle.GridColumnStyles.Add(status);
            var Tick = new DataGridBoolColumn();
            Tick.HeaderText = "";
            Tick.MappingName = "Tick";
            Tick.ReadOnly = true;
            Tick.Width = 25;
            Tick.NullText = "";
            tStyle.GridColumnStyles.Add(Tick);
            var type = new DataGridLabelColumn();
            type.Format = "";
            type.FormatInfo = null;
            type.HeaderText = "Type";
            type.MappingName = "type";
            type.ReadOnly = true;
            type.Width = 60;
            type.NullText = "";
            tStyle.GridColumnStyles.Add(type);
            var number = new DataGridLabelColumn();
            number.Format = "";
            number.FormatInfo = null;
            number.HeaderText = "Number";
            number.MappingName = "number";
            number.ReadOnly = true;
            number.Width = 80;
            number.NullText = "";
            tStyle.GridColumnStyles.Add(number);
            var Name = new DataGridLabelColumn();
            Name.Format = "";
            Name.FormatInfo = null;
            Name.HeaderText = "Name";
            Name.MappingName = "Name";
            Name.ReadOnly = true;
            Name.Width = 300;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var quantity = new DataGridLabelColumn();
            quantity.Format = "";
            quantity.FormatInfo = null;
            quantity.HeaderText = "Qty Allocated";
            quantity.MappingName = "Quantity";
            quantity.ReadOnly = true;
            quantity.Width = 50;
            quantity.NullText = "";
            tStyle.GridColumnStyles.Add(quantity);
            var quantityRemaining = new DataGridLabelColumn();
            quantityRemaining.Format = "";
            quantityRemaining.FormatInfo = null;
            quantityRemaining.HeaderText = "Quantity Unallocated";
            quantityRemaining.MappingName = "QtyRemaining";
            quantityRemaining.ReadOnly = true;
            quantityRemaining.Width = 60;
            quantityRemaining.NullText = "";
            tStyle.GridColumnStyles.Add(quantityRemaining);
            var OrderReference = new DataGridLabelColumn();
            OrderReference.Format = "";
            OrderReference.FormatInfo = null;
            OrderReference.HeaderText = "Order Ref.";
            OrderReference.MappingName = "OrderReference";
            OrderReference.ReadOnly = true;
            OrderReference.Width = 75;
            OrderReference.NullText = "N/A";
            tStyle.GridColumnStyles.Add(OrderReference);
            var OrderStatus = new DataGridLabelColumn();
            OrderStatus.Format = "";
            OrderStatus.FormatInfo = null;
            OrderStatus.HeaderText = "Order Status";
            OrderStatus.MappingName = "OrderStatus";
            OrderStatus.ReadOnly = true;
            OrderStatus.Width = 75;
            OrderStatus.NullText = "N/A";
            tStyle.GridColumnStyles.Add(OrderStatus);
            var QuantityReceived = new DataGridLabelColumn();
            QuantityReceived.Format = "";
            QuantityReceived.FormatInfo = null;
            QuantityReceived.HeaderText = "Order Qty Received";
            QuantityReceived.MappingName = "QuantityReceived";
            QuantityReceived.ReadOnly = true;
            QuantityReceived.Width = 75;
            QuantityReceived.NullText = "N/A";
            tStyle.GridColumnStyles.Add(QuantityReceived);
            var CreditQty = new DataGridLabelColumn();
            CreditQty.Format = "";
            CreditQty.FormatInfo = null;
            CreditQty.HeaderText = "Qty Credit";
            CreditQty.MappingName = "CreditQty";
            CreditQty.ReadOnly = true;
            CreditQty.Width = 75;
            CreditQty.NullText = "0";
            tStyle.GridColumnStyles.Add(CreditQty);
            var BuyPrice = new DataGridLabelColumn();
            BuyPrice.Format = "C";
            BuyPrice.FormatInfo = null;
            BuyPrice.HeaderText = "Buy Price";
            BuyPrice.MappingName = "SellPrice";
            BuyPrice.ReadOnly = true;
            BuyPrice.Width = 75;
            BuyPrice.NullText = "0";
            tStyle.GridColumnStyles.Add(BuyPrice);
            tStyle.ReadOnly = true;
            tStyle.MappingName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsAllocated.ToString();
            dgPartsProductsAllocated.TableStyles.Add(tStyle);
        }

        private DataView _PartsAndProductsAllocated = null;

        public DataView PartsAndProductsAllocated
        {
            get
            {
                return _PartsAndProductsAllocated;
            }

            set
            {
                PartsAndProductsDistribution = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsDistributed_GetAll_For_Engineer_Visit(EngineerVisit.EngineerVisitID);
                PartsAndProductsDistribution.Table.Constraints.Clear();
                value.Table.AcceptChanges();
                value.Table.Columns.Add(new DataColumn("Status", Type.GetType("System.Boolean")));
                value.Table.Columns.Add(new DataColumn("Tick", typeof(bool)));
                // Value.Table.Columns("Tick").DefaultValue = False

                foreach (DataRow row in value.Table.Rows)
                {
                    row["Tick"] = false;
                    int distributed = 0;
                    bool creditcolumn = false;
                    int creditamt = 0;
                    foreach (DataRow distrow in PartsAndProductsDistribution.Table.Select(Convert.ToString("Type = '" + row["Type"] + "'")))
                    {
                        if (distrow.Field<int>("AllocatedID") == row.Field<int>("ID"))
                        {
                            distributed += (int)distrow["Quantity"];
                        }
                    }

                    foreach (DataColumn c in value.Table.Columns)
                    {
                        if ((c.ColumnName ?? "") == "CreditQty")
                        {
                            creditcolumn = true;
                            break;
                        }
                    }

                    if (creditcolumn == false)
                    {
                        creditamt = 0;
                    }
                    else if (row["CreditQty"] == DBNull.Value)
                    {
                        creditamt = 0;
                    }
                    else
                    {
                        creditamt = (int)row["CreditQty"];
                    }

                    if (row.Field<int>("OrderItemID") == 0)
                    {
                        row["Status"] = true;
                    }
                    else if (Convert.ToBoolean(distributed + creditamt >= (int)row["QtyRemaining"]))
                    {
                        row["Status"] = true;
                    }
                    else
                    {
                        row["Status"] = false;
                    }
                }

                value.Table.PrimaryKey = new DataColumn[] { value.Table.Columns["ID"] };
                _PartsAndProductsAllocated = value;
                _PartsAndProductsAllocated.Table.TableName = Enums.TableNames.NOT_IN_DATABASE_PartsAndProductsAllocated.ToString();
                _PartsAndProductsAllocated.AllowNew = false;
                _PartsAndProductsAllocated.AllowEdit = false;
                _PartsAndProductsAllocated.AllowDelete = false;
                dgPartsProductsAllocated.DataSource = PartsAndProductsAllocated;
                SetupAllocatedDG();
            }
        }

        private DataRow SelectedPartProductAllocatedDataRow
        {
            get
            {
                if (!(dgPartsProductsAllocated.CurrentRowIndex == -1))
                {
                    return PartsAndProductsAllocated[dgPartsProductsAllocated.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataRow SelectedPartProductUsedDataRow
        {
            get
            {
                if (!(dgPartsAndProductsUsed.CurrentRowIndex == -1))
                {
                    return PartsAndProductsUsed[dgPartsAndProductsUsed.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private DataView _PartsAndProductsUsed = null;

        public DataView PartsAndProductsUsed
        {
            get
            {
                return _PartsAndProductsUsed;
            }

            set
            {
                _PartsAndProductsUsed = value;
            }
        }

        private DataView _PartsAndProductsDistribution = null;

        public DataView PartsAndProductsDistribution
        {
            get
            {
                return _PartsAndProductsDistribution;
            }

            set
            {
                _PartsAndProductsDistribution = value;
            }
        }

        private void btnAllocatedNotUsed_Click(object sender, EventArgs e)
        {
            if (SelectedPartProductAllocatedDataRow is null)
            {
                App.ShowMessage("Please select a part or product to mark as not used", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int distributed = 0;
            foreach (DataRow row in PartsAndProductsDistribution.Table.Select(Convert.ToString("Type = '" + SelectedPartProductAllocatedDataRow["Type"] + "'")))
            {
                if ((int)row["AllocatedID"] == (int)SelectedPartProductAllocatedDataRow["ID"])
                {
                    distributed += (int)row["Quantity"];
                }
            }

            if (distributed == (int)SelectedPartProductAllocatedDataRow["Quantity"])
            {
                App.ShowMessage(Convert.ToString("Distribution is complete for this " + SelectedPartProductAllocatedDataRow["Type"]), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string msg = "Are you sure the remaining";
            msg += Convert.ToString(" " + ((int)SelectedPartProductAllocatedDataRow["Quantity"] - distributed) + ", ") + SelectedPartProductAllocatedDataRow["Name"] + "'s have not been used? This action cannot be reversed once the job details have been saved";
            if (App.ShowMessage(msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (Helper.MakeIntegerValid(SelectedPartProductAllocatedDataRow["OrderID"]) == 0)
            {
                PartsAndProductsDistribution.Table.AcceptChanges();
                var r = PartsAndProductsDistribution.Table.NewRow();
                r["Type"] = SelectedPartProductAllocatedDataRow["Type"];
                r["DistributedID"] = 0;
                r["LocationID"] = 0;
                r["AllocatedID"] = SelectedPartProductAllocatedDataRow["ID"];
                r["Other"] = false;
                r["Quantity"] = (int)SelectedPartProductAllocatedDataRow["Quantity"] - distributed;
                r["PartProductID"] = SelectedPartProductAllocatedDataRow["PartProductID"];
                r["OrderPartProductID"] = 0;
                r["StockTransactionType"] = (int)Enums.Transaction.StockIn;
                PartsAndProductsDistribution.Table.Rows.Add(r);
                SelectedPartProductAllocatedDataRow["Status"] = true;
            }
            else
            {
                int qtyReturned = 0;
                // IS THE PART ON A SUPPLIER PO THAT IS COMPLETE
                bool flagComleted = false;
                if ((int)SelectedPartProductAllocatedDataRow["OrderStatusID"] == (int)Enums.OrderStatus.Confirmed)
                {
                    if (App.ShowMessage("This order is still confirmed! Would you like to make it as complete now?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CompleteOrder((int)SelectedPartProductAllocatedDataRow["OrderItemID"]);
                        flagComleted = true;
                    }
                }

                if ((int)SelectedPartProductAllocatedDataRow["OrderLocationTypeID"] == (int)Enums.LocationType.Supplier & ((int)SelectedPartProductAllocatedDataRow["OrderStatusID"] >= (int)Enums.OrderStatus.Complete | flagComleted == true))
                {
                    var fAddPartToBeCredited = new FRMAddPartToBeCredited((int)SelectedPartProductAllocatedDataRow["Quantity"] - distributed);
                    if (fAddPartToBeCredited.ShowDialog() == DialogResult.OK)
                    {
                        qtyReturned = Helper.MakeIntegerValid(fAddPartToBeCredited.txtQtyToReturn.Text);
                    }

                    if (qtyReturned > 0)
                    {
                        // ADD TO DISTRIBUTION TABLE
                        var r = PartsAndProductsDistribution.Table.NewRow();
                        r["Type"] = SelectedPartProductAllocatedDataRow["Type"];
                        r["DistributedID"] = 0;
                        r["LocationID"] = 0;
                        r["AllocatedID"] = SelectedPartProductAllocatedDataRow["ID"];
                        r["Other"] = false;
                        r["Quantity"] = qtyReturned;
                        r["PartProductID"] = SelectedPartProductAllocatedDataRow["PartProductID"];
                        r["OrderPartProductID"] = SelectedPartProductAllocatedDataRow["OrderItemID"];
                        r["StockTransactionType"] = -1; // FOR A PART CREDIT
                        PartsAndProductsDistribution.Table.Rows.Add(r);
                        // ADD CREDITED TO DISTRIBUTED
                        distributed += qtyReturned;
                        SelectedPartProductAllocatedDataRow["Status"] = true;
                    }
                }

                if (Convert.ToBoolean((int)SelectedPartProductAllocatedDataRow["Quantity"] - distributed > 0))
                {
                    var frmDistribution = new FRMDistributeAllocated(false, (int)((int)SelectedPartProductAllocatedDataRow["Quantity"] - distributed), Convert.ToString(SelectedPartProductAllocatedDataRow["Name"]), Convert.ToString(SelectedPartProductAllocatedDataRow["Type"]), (int)SelectedPartProductAllocatedDataRow["PartProductID"], null);
                    if (frmDistribution.ShowDialog() == DialogResult.OK)
                    {
                        PartsAndProductsDistribution.Table.AcceptChanges();
                        foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                        {
                            if (Convert.ToBoolean((int)row["Quantity"] > 0))
                            {
                                var r = PartsAndProductsDistribution.Table.NewRow();
                                r["Type"] = SelectedPartProductAllocatedDataRow["Type"];
                                r["DistributedID"] = 0;
                                r["LocationID"] = row["LocationID"];
                                r["AllocatedID"] = SelectedPartProductAllocatedDataRow["ID"];
                                r["Other"] = false;
                                r["Quantity"] = row["Quantity"];
                                r["PartProductID"] = SelectedPartProductAllocatedDataRow["PartProductID"];
                                r["OrderPartProductID"] = SelectedPartProductAllocatedDataRow["OrderItemID"];
                                r["StockTransactionType"] = (int)Enums.Transaction.StockIn;
                                PartsAndProductsDistribution.Table.Rows.Add(r);
                            }
                        }

                        SelectedPartProductAllocatedDataRow["Status"] = true;
                    }
                }
            }
        }

        private void CompleteOrder(int OrderPartID)
        {
            var OrderPartz = App.DB.OrderPart.OrderPart_Get(OrderPartID);
            if (OrderPartz is null)
                return;
            var CurrentOrder = App.DB.Order.Order_Get(OrderPartz.OrderID);
            if (!(CurrentOrder.OrderStatusID == (int)Enums.OrderStatus.Confirmed))
            {
                App.ShowMessage("Order must be confirmed to Complete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var ItemsIncludedDataView = App.DB.Order.Order_ItemsGetAll(OrderPartz.OrderID);
            foreach (DataRow itemRow in ItemsIncludedDataView.Table.Rows)
            {
                if (!((int)itemRow["QuantityOnOrder"] == (int)itemRow["QuantityReceived"]))
                {
                    int quantityInput = (int)itemRow["QuantityOnOrder"] - (int)itemRow["QuantityReceived"];
                    var switchExpr = Convert.ToString(itemRow["Type"]);
                    switch (switchExpr)
                    {
                        case "OrderProduct":
                            {
                                var OrderProduct = new Entity.OrderProducts.OrderProduct();
                                var oProduct = new Entity.Products.Product();
                                OrderProduct = App.DB.OrderProduct.OrderProduct_Get((int)itemRow["ID"]);
                                var oProductSupplier = App.DB.ProductSupplier.ProductSupplier_Get(OrderProduct.ProductSupplierID);
                                oProduct = App.DB.Product.Product_Get(oProductSupplier.ProductID);
                                OrderProduct.SetQuantityReceived = OrderProduct.QuantityReceived + quantityInput;
                                App.DB.OrderProduct.Update(OrderProduct);
                                var switchExpr1 = CurrentOrder.OrderTypeID;
                                switch (switchExpr1)
                                {
                                    case (int)Enums.OrderType.Customer:
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)Enums.OrderType.Job:
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)Enums.OrderType.StockProfile:
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case (int)Enums.OrderType.Warehouse:
                                        {
                                            var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderProduct.OrderID);
                                            var oProductTransaction = new Entity.ProductTransactions.ProductTransaction();
                                            oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oProductTransaction.SetProductID = oProductSupplier.ProductID;
                                            oProductTransaction.SetOrderProductID = OrderProduct.OrderProductID;
                                            oProductTransaction.SetAmount = quantityInput * oProductSupplier.QuantityInPack;
                                            oProductTransaction.SetTransactionTypeID = (int)Enums.Transaction.StockIn;
                                            App.DB.ProductTransaction.Insert(oProductTransaction);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "OrderPart":
                            {
                                var OrderPart = new Entity.OrderParts.OrderPart();
                                OrderPart = App.DB.OrderPart.OrderPart_Get((int)itemRow["ID"]);
                                OrderPart.SetQuantityReceived = OrderPart.QuantityReceived + quantityInput;
                                App.DB.OrderPart.Update(OrderPart);
                                var switchExpr2 = CurrentOrder.OrderTypeID;
                                switch (switchExpr2)
                                {
                                    case (int)Enums.OrderType.Customer:
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)Enums.OrderType.Job:
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)Enums.OrderType.StockProfile:
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case (int)Enums.OrderType.Warehouse:
                                        {
                                            var oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderPart.OrderID);
                                            var oPartSupplier = App.DB.PartSupplier.PartSupplier_Get(OrderPart.PartSupplierID);
                                            var oPartTransaction = new Entity.PartTransactions.PartTransaction();
                                            oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oPartTransaction.SetPartID = oPartSupplier.PartID;
                                            oPartTransaction.SetOrderPartID = OrderPart.OrderPartID;
                                            oPartTransaction.SetAmount = quantityInput * oPartSupplier.QuantityInPack;
                                            oPartTransaction.SetTransactionTypeID = (int)Enums.Transaction.StockIn;
                                            App.DB.PartTransaction.Insert(oPartTransaction);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "OrderLocationProduct":
                            {
                                var OrderLocationProduct = App.DB.OrderLocationProduct.OrderLocationProduct_Get((int)itemRow["ID"]);
                                var oProductTransaction = App.DB.ProductTransaction.ProductTransaction_GetByOrderLocationProduct(OrderLocationProduct.OrderLocationProductID);
                                oProductTransaction.SetAmount = oProductTransaction.Amount + quantityInput;
                                App.DB.ProductTransaction.Update(oProductTransaction);
                                oProductTransaction.SetLocationID = OrderLocationProduct.LocationID;
                                oProductTransaction.SetProductID = OrderLocationProduct.ProductID;
                                oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID;
                                oProductTransaction.SetTransactionTypeID = (int)Enums.Transaction.StockOut;
                                oProductTransaction.SetAmount = -quantityInput;
                                App.DB.ProductTransaction.Insert(oProductTransaction);
                                OrderLocationProduct.SetQuantityReceived = OrderLocationProduct.QuantityReceived + quantityInput;
                                App.DB.OrderLocationProduct.Update(OrderLocationProduct);
                                var switchExpr3 = CurrentOrder.OrderTypeID;
                                switch (switchExpr3)
                                {
                                    case (int)Enums.OrderType.Customer:
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)Enums.OrderType.Job:
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)Enums.OrderType.StockProfile:
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case (int)Enums.OrderType.Warehouse:
                                        {
                                            Entity.OrderLocations.OrderLocation oOrderLocation;
                                            oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationProduct.OrderID);
                                            oProductTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oProductTransaction.SetTransactionTypeID = (int)Enums.Transaction.StockIn;
                                            oProductTransaction.SetOrderLocationProductID = OrderLocationProduct.OrderLocationProductID;
                                            oProductTransaction.SetAmount = quantityInput;
                                            oProductTransaction.SetProductID = OrderLocationProduct.ProductID;
                                            App.DB.ProductTransaction.Insert(oProductTransaction);
                                            break;
                                        }
                                }

                                break;
                            }

                        case "OrderLocationPart":
                            {
                                var OrderLocationPart = App.DB.OrderLocationPart.OrderLocationPart_Get((int)itemRow["ID"]);
                                var oPartTransaction = App.DB.PartTransaction.PartTransaction_GetByOrderLocationPart(OrderLocationPart.OrderLocationPartID);
                                oPartTransaction.SetAmount = oPartTransaction.Amount + quantityInput;
                                App.DB.PartTransaction.Update(oPartTransaction);
                                oPartTransaction.SetLocationID = OrderLocationPart.LocationID;
                                oPartTransaction.SetPartID = OrderLocationPart.PartID;
                                oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID;
                                oPartTransaction.SetTransactionTypeID = (int)Enums.Transaction.StockOut;
                                oPartTransaction.SetAmount = -quantityInput;
                                App.DB.PartTransaction.Insert(oPartTransaction);
                                OrderLocationPart.SetQuantityReceived = OrderLocationPart.QuantityReceived + quantityInput;
                                App.DB.OrderLocationPart.Update(OrderLocationPart);
                                var switchExpr4 = CurrentOrder.OrderTypeID;
                                switch (switchExpr4)
                                {
                                    case (int)Enums.OrderType.Customer:
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)Enums.OrderType.Job:
                                        {
                                            break;
                                        }
                                    // DO NOTHING
                                    case (int)Enums.OrderType.StockProfile:
                                        {
                                            break;
                                        }
                                    // DO NOTHING - THIS WILL BE DONE ON THE PDA
                                    case (int)Enums.OrderType.Warehouse:
                                        {
                                            Entity.OrderLocations.OrderLocation oOrderLocation;
                                            oOrderLocation = App.DB.OrderLocation.OrderLocation_GetForOrder(OrderLocationPart.OrderID);
                                            oPartTransaction.SetLocationID = oOrderLocation.LocationID;
                                            oPartTransaction.SetTransactionTypeID = (int)Enums.Transaction.StockIn;
                                            oPartTransaction.SetOrderLocationPartID = OrderLocationPart.OrderLocationPartID;
                                            oPartTransaction.SetAmount = quantityInput;
                                            oPartTransaction.SetPartID = OrderLocationPart.PartID;
                                            App.DB.PartTransaction.Insert(oPartTransaction);
                                            break;
                                        }
                                }

                                break;
                            }
                    }
                }
            }

            // Populate(CurrentOrder.OrderID)

            CurrentOrder.SetOrderStatusID = (int)Enums.OrderStatus.Complete;
            App.DB.Order.Update(CurrentOrder);
        }

        private bool DeclareWhereGotFrom(int Quantity, string NameIn, string TypeIn, int IDIn)
        {
            var frmDistribution = new FRMDistributeAllocated(true, Quantity, NameIn, TypeIn, IDIn, BuildAllocatedArray(IDIn, TypeIn));
            if (frmDistribution.ShowDialog() == DialogResult.OK)
            {
                PartsAndProductsDistribution.Table.AcceptChanges();
                foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                {
                    if (Convert.ToBoolean((int)row["Quantity"] > 0))
                    {
                        var r = PartsAndProductsDistribution.Table.NewRow();
                        r["Type"] = TypeIn;
                        r["DistributedID"] = 0;
                        r["LocationID"] = row["LocationID"];
                        r["AllocatedID"] = row["AllocatedID"];
                        if ((int)row["LocationID"] == 0 && (int)row["AllocatedID"] == 0)
                        {
                            r["Other"] = true;
                        }
                        else
                        {
                            r["Other"] = false;
                        }

                        r["Quantity"] = row["Quantity"];
                        r["PartProductID"] = IDIn;
                        r["OrderPartProductID"] = row["OrderPartProductID"];
                        r["StockTransactionType"] = row["StockTransactionType"];
                        PartsAndProductsDistribution.Table.Rows.Add(r);
                    }
                }

                foreach (DataRow row in PartsAndProductsAllocated.Table.Rows)
                {
                    int distributed = 0;
                    foreach (DataRow distrow in PartsAndProductsDistribution.Table.Select(Convert.ToString("Type = '" + row["Type"] + "'")))
                    {
                        if ((int)distrow["AllocatedID"] == (int)row["ID"])
                        {
                            distributed += (int)distrow["Quantity"];
                        }
                    }

                    if (Convert.ToBoolean(distributed >= (int)row["Quantity"]))
                    {
                        row["Status"] = true;
                    }
                    else
                    {
                        row["Status"] = false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private ArrayList BuildAllocatedArray(int PartProductIDIn, string TypeIn)
        {
            var arr = new ArrayList();
            foreach (DataRow row in PartsAndProductsAllocated.Table.Rows)
            {
                if ((bool)row["Status"] == false && (int)row["PartProductID"] == PartProductIDIn && (string)row["Type"] == TypeIn && Helper.MakeIntegerValid(row["OrderID"]) != 0)
                {
                    int distributed = 0;
                    foreach (DataRow dist in PartsAndProductsDistribution.Table.Select("Type = '" + TypeIn + "'"))
                    {
                        if ((int)dist["AllocatedID"] == (int)row["ID"])
                        {
                            distributed += (int)dist["Quantity"];
                        }
                    }

                    int amountAvailable = (int)row["Quantity"] - distributed;
                    if (amountAvailable >= 0)
                    {
                        var a = new ArrayList();
                        a.Add(row["ID"]);
                        a.Add(amountAvailable);
                        a.Add(row["OrderItemID"]);
                        arr.Add(a);
                    }
                }
            }

            return arr;
        }

        private bool RemovePart(int Quantity, string PartProductName, string Type, int PartProductID)
        {
            // IS THIS A PIECE OF EQUIPMENT?
            bool equipment = false;
            if ((Type ?? "") == "Part")
            {
                var oPart = App.DB.Part.Part_Get(PartProductID);
                if (oPart.Equipment == true)
                {
                    equipment = true;
                }
            }

            if (equipment == false)
            {
                int qtyReturned = 0;
                int distributed = 0;
                if (!(dgPartsProductsAllocated.CurrentRowIndex == -1))
                {
                    var fAddPartToBeCredited = new FRMAddPartToBeCredited((int)SelectedPartProductAllocatedDataRow["Quantity"] - distributed);
                    if (fAddPartToBeCredited.ShowDialog() == DialogResult.OK)
                    {
                        qtyReturned = Helper.MakeIntegerValid(fAddPartToBeCredited.txtQtyToReturn.Text);
                    }

                    if (qtyReturned > 0)
                    {
                        // ADD TO DISTRIBUTION TABLE
                        var r = PartsAndProductsDistribution.Table.NewRow();
                        r["Type"] = SelectedPartProductAllocatedDataRow["Type"];
                        r["DistributedID"] = 0;
                        r["LocationID"] = 0;
                        r["AllocatedID"] = SelectedPartProductAllocatedDataRow["ID"];
                        r["Other"] = false;
                        r["Quantity"] = qtyReturned;
                        r["PartProductID"] = SelectedPartProductAllocatedDataRow["PartProductID"];
                        r["OrderPartProductID"] = SelectedPartProductAllocatedDataRow["OrderItemID"];
                        r["StockTransactionType"] = -1; // FOR A PART CREDIT
                        PartsAndProductsDistribution.Table.Rows.Add(r);
                        // ADD CREDITED TO DISTRIBUTED
                        distributed += qtyReturned;
                        SelectedPartProductAllocatedDataRow["Status"] = true;
                    }

                    if (Convert.ToBoolean((int)SelectedPartProductAllocatedDataRow["Quantity"] - distributed > 0))
                    {
                        var frmDistribution = new FRMDistributeAllocated(false, Quantity, PartProductName, Type, PartProductID, null);
                        if (frmDistribution.ShowDialog() == DialogResult.OK)
                        {
                            PartsAndProductsDistribution.Table.AcceptChanges();
                            foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                            {
                                if (Convert.ToBoolean((int)row["Quantity"] > 0))
                                {
                                    var r = PartsAndProductsDistribution.Table.NewRow();
                                    r["Type"] = Type;
                                    r["DistributedID"] = 0;
                                    r["LocationID"] = row["LocationID"];
                                    r["AllocatedID"] = 0;
                                    r["Other"] = false;
                                    r["Quantity"] = row["Quantity"];
                                    r["PartProductID"] = PartProductID;
                                    r["OrderPartProductID"] = 0;
                                    r["StockTransactionType"] = (int)Enums.Transaction.StockIn;
                                    PartsAndProductsDistribution.Table.Rows.Add(r);
                                }
                            }

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (!(dgPartsAndProductsUsed.CurrentRowIndex == -1)) // PArtsUsed
                {
                    if (Convert.ToBoolean((int)EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["OrderPartID"] > 0))
                    {
                        var fAddPartToBeCredited = new FRMAddPartToBeCredited((int)EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Quantity"] - distributed);
                        if (fAddPartToBeCredited.ShowDialog() == DialogResult.OK)
                        {
                            qtyReturned = Helper.MakeIntegerValid(fAddPartToBeCredited.txtQtyToReturn.Text);
                        }
                    }

                    if (qtyReturned > 0)
                    {
                        // ADD TO DISTRIBUTION TABLE
                        var r = PartsAndProductsDistribution.Table.NewRow();
                        r["Type"] = EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Type"];
                        r["DistributedID"] = 0;
                        r["LocationID"] = 0;
                        r["AllocatedID"] = EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["AllocatedID"];
                        r["Other"] = false;
                        r["Quantity"] = qtyReturned;
                        r["PartProductID"] = EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["ID"];
                        r["OrderPartProductID"] = EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["OrderItemID"];
                        r["StockTransactionType"] = -1; // FOR A PART CREDIT
                        PartsAndProductsDistribution.Table.Rows.Add(r);
                        // ADD CREDITED TO DISTRIBUTED
                        distributed += qtyReturned;
                        // SelectedPartProductUsedDataRow.Item("Status") = True
                    }

                    if (Convert.ToBoolean((int)EngineerVisit.PartsAndProductsUsed.Table.Rows[dgPartsAndProductsUsed.CurrentRowIndex]["Quantity"] - distributed > 0))
                    {
                        var frmDistribution = new FRMDistributeAllocated(false, Quantity, PartProductName, Type, PartProductID, null);
                        if (frmDistribution.ShowDialog() == DialogResult.OK)
                        {
                            PartsAndProductsDistribution.Table.AcceptChanges();
                            foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                            {
                                if (Convert.ToBoolean((int)row["Quantity"] > 0))
                                {
                                    var r = PartsAndProductsDistribution.Table.NewRow();
                                    r["Type"] = Type;
                                    r["DistributedID"] = 0;
                                    r["LocationID"] = row["LocationID"];
                                    r["AllocatedID"] = 0;
                                    r["Other"] = false;
                                    r["Quantity"] = row["Quantity"];
                                    r["PartProductID"] = PartProductID;
                                    r["OrderPartProductID"] = 0;
                                    r["StockTransactionType"] = (int)Enums.Transaction.StockIn;
                                    PartsAndProductsDistribution.Table.Rows.Add(r);
                                }
                            }

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }

            return default;
        }

        private void btnAllUsed_Click(object sender, EventArgs e)
        {
            if (SelectedPartProductAllocatedDataRow is null)
            {
                App.ShowMessage("Please select a part or product to mark as fully used", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // lets check to see if we are moving multiple or individual part
            bool mulitple = false;
            int selectedCount = 0;
            foreach (DataRow dr in PartsAndProductsAllocated.Table.Rows)
            {
                if ((bool)dr["Tick"])
                {
                    selectedCount += 1;
                    if (selectedCount > 1)
                    {
                        mulitple = true;
                        break;
                    }
                }
            }

            if (mulitple)
            {
                foreach (DataRow dr in PartsAndProductsAllocated.Table.Rows)
                {
                    if ((bool)dr["Tick"] && ((int)dr["QtyRemaining"] > 0))
                    {
                        UsePart(dr, (int)dr["QtyRemaining"]);
                    }
                }
            }
            else
            {
                foreach (DataRow dr in PartsAndProductsAllocated.Table.Rows)
                {
                    if ((bool)dr["Tick"])
                    {
                        UsePart(dr, (int)nudPartAllocatedQty.Value);
                    }
                }
            }
        }

        public void UsePart(DataRow dr, int qty)
        {
            bool addUsed = false;
            int LocationID = 0;
            int distributed = 0;
            foreach (DataRow row in PartsAndProductsDistribution.Table.Select(Convert.ToString("Type = '" + dr["Type"] + "'")))
            {
                if ((int)row["AllocatedID"] == (int)dr["ID"])
                {
                    distributed += (int)row["Quantity"];
                }
            }

            if (Convert.ToBoolean(distributed >= (int)dr["Quantity"]))
            {
                App.ShowMessage(Convert.ToString("Distribution is complete for this " + dr["Type"]), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Helper.MakeIntegerValid(dr["OrderID"]) == 0)
            {
                var frmDistribution = new FRMDistributeAllocated(true, qty, Convert.ToString(dr["Name"]), Convert.ToString(dr["Type"]), (int)dr["PartProductID"], BuildAllocatedArray((int)dr["PartProductID"], Convert.ToString(dr["Type"])));
                if (frmDistribution.ShowDialog() == DialogResult.OK)
                {
                    PartsAndProductsDistribution.Table.AcceptChanges();
                    foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                    {
                        if (Convert.ToBoolean((int)row["QtyRemaining"] > 0))
                        {
                            var drA = PartsAndProductsDistribution.Table.Select(Convert.ToString("AllocatedID = " + dr["ID"]));
                            foreach (DataRow r in drA)
                            {
                                if (r is null)
                                {
                                    var drr = PartsAndProductsDistribution.Table.NewRow();
                                    drr["Type"] = dr["Type"];
                                    drr["DistributedID"] = 0;
                                    drr["LocationID"] = row["LocationID"];
                                    drr["AllocatedID"] = dr["ID"];
                                    if ((int)row["LocationID"] == 0)
                                    {
                                        drr["Other"] = true;
                                    }
                                    else
                                    {
                                        drr["Other"] = false;
                                    }

                                    drr["Quantity"] = qty;
                                    drr["PartProductID"] = dr["PartProductID"];
                                    drr["OrderPartProductID"] = 0;
                                    drr["StockTransactionType"] = (int)Enums.Transaction.StockOut;
                                    PartsAndProductsDistribution.Table.Rows.Add(drr);
                                    LocationID = (int)row["LocationID"];
                                }
                                else
                                {
                                    r["Quantity"] = (int)r["Quantity"] + qty;
                                }
                            }
                        }
                    }

                    dr["QtyRemaining"] = (int)dr["QtyRemaining"] - qty;
                    if (((int)dr["Quantity"] - (int)dr["QtyRemaining"]) == (int)dr["Quantity"])
                    {
                        dr["Status"] = true;
                    }

                    addUsed = true;
                }
            }
            else
            {
                // HAS THE ORDER BEEN RECEIVED?
                bool flagComleted = false;
                if ((int)dr["OrderStatusID"] == (int)Enums.OrderStatus.Confirmed)
                {
                    if (App.ShowMessage("This order is still confirmed! Would you like to make it as complete now?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        CompleteOrder((int)dr["OrderItemID"]);
                        flagComleted = true;
                    }
                }

                if (Helper.MakeIntegerValid(dr["QuantityOrdered"]) == Helper.MakeIntegerValid(dr["QuantityReceived"]) | flagComleted == true)
                {
                    PartsAndProductsDistribution.Table.AcceptChanges();
                    var drA = PartsAndProductsDistribution.Table.Select(Convert.ToString("AllocatedID = " + dr["ID"]));
                    foreach (DataRow r in drA)
                    {
                        if (r is null)
                        {
                            var drr = PartsAndProductsDistribution.Table.NewRow();
                            drr["Type"] = dr["Type"];
                            drr["DistributedID"] = 0;
                            drr["LocationID"] = 0;
                            drr["AllocatedID"] = dr["ID"];
                            drr["Other"] = false;
                            drr["Quantity"] = qty;
                            drr["PartProductID"] = dr["PartProductID"];
                            drr["OrderPartProductID"] = dr["OrderItemID"];
                            drr["StockTransactionType"] = 0;
                            PartsAndProductsDistribution.Table.Rows.Add(drr);
                        }
                        else
                        {
                            r["Quantity"] = (int)r["Quantity"] + qty;
                        }
                    }

                    dr["QtyRemaining"] = (int)dr["QtyRemaining"] - qty;
                    if (((int)dr["Quantity"] - (int)dr["QtyRemaining"]) == (int)dr["Quantity"])
                    {
                        dr["Status"] = true;
                    }

                    addUsed = true;
                }
                else if (App.ShowMessage("This is part that has been ordered but not fully received." + Environment.NewLine + "Would you like to continue and select stock from another location?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var frmDistribution = new FRMDistributeAllocated(true, qty, Convert.ToString(dr["Name"]), Convert.ToString(dr["Type"]), (int)dr["PartProductID"], BuildAllocatedArray((int)dr["PartProductID"], Convert.ToString(dr["Type"])));
                    if (frmDistribution.ShowDialog() == DialogResult.OK)
                    {
                        PartsAndProductsDistribution.Table.AcceptChanges();
                        foreach (DataRow row in frmDistribution.Locations.Table.Rows)
                        {
                            if (Convert.ToBoolean((int)row["QtyRemaining"] > 0))
                            {
                                var drA = PartsAndProductsDistribution.Table.Select(Convert.ToString("AllocatedID = " + dr["ID"]));
                                foreach (DataRow r in drA)
                                {
                                    if (r is null)
                                    {
                                        var drr = PartsAndProductsDistribution.Table.NewRow();
                                        drr["Type"] = dr["Type"];
                                        drr["DistributedID"] = 0;
                                        drr["LocationID"] = row["LocationID"];
                                        drr["AllocatedID"] = dr["ID"];
                                        if ((int)row["LocationID"] == 0)
                                        {
                                            drr["Other"] = true;
                                        }
                                        else
                                        {
                                            drr["Other"] = false;
                                        }

                                        drr["Quantity"] = qty;
                                        drr["PartProductID"] = dr["PartProductID"];
                                        drr["OrderPartProductID"] = 0;
                                        drr["StockTransactionType"] = (int)Enums.Transaction.StockOut;
                                        PartsAndProductsDistribution.Table.Rows.Add(drr);
                                        LocationID = (int)row["LocationID"];
                                    }
                                    else
                                    {
                                        r["Quantity"] = (int)r["Quantity"] + qty;
                                    }
                                }
                            }
                        }

                        dr["QtyRemaining"] = (int)dr["QtyRemaining"] - qty;
                        if (((int)dr["Quantity"] - (int)dr["QtyRemaining"]) == (int)dr["Quantity"])
                        {
                            dr["Status"] = true;
                        }

                        addUsed = true;
                    }
                }
            }

            if (addUsed)
            {
                var newRow = EngineerVisit.PartsAndProductsUsed.Table.NewRow();
                newRow["ID"] = dr["PartProductID"];
                newRow["AllocatedID"] = dr["ID"];
                newRow["Type"] = dr["Type"];
                newRow["Quantity"] = qty;
                if ((string)dr["Type"] == "Part")
                {
                    FRMChooseAsset dialogue;
                    dialogue = (FRMChooseAsset)App.checkIfExists(typeof(FRMChooseAsset).Name, true);
                    if (dialogue is null)
                    {
                        dialogue = (FRMChooseAsset)Activator.CreateInstance(typeof(FRMChooseAsset));
                    }
                    // dialogue.Icon = New Icon(dialogue.GetType(), "Logo.ico")
                    dialogue.ShowInTaskbar = false;
                    dialogue.JobID = App.DB.Job.Job_Get_For_An_EngineerVisit_ID(EngineerVisit.EngineerVisitID).JobID;
                    dialogue.Part = Convert.ToString(dr["Name"]);
                    dialogue.ShowDialog();
                    dialogue.Close();
                    var part = App.DB.Part.Part_Get((int)dr["PartProductID"]);
                    newRow["Number"] = part.Number;
                    newRow["Name"] = dr["Name"];
                    newRow["Reference"] = part.Reference;
                    newRow["SellPrice"] = dr["SellPrice"];
                    if (part.IsSpecialPart)
                    {
                        newRow["SpecialPrice"] = dr["SellPrice"];
                        newRow["BuyPrice"] = dr["SellPrice"];
                        newRow["SpecialDescription"] = dr["Name"];
                        newRow["Number"] = dr["Number"];
                        newRow["SpecialPartNumber"] = dr["Number"];
                    }
                }
                else
                {
                    var product = App.DB.Product.Product_Get((int)dr["PartProductID"]);
                    newRow["Number"] = product.Number;
                    newRow["Name"] = product.Name;
                    newRow["Reference"] = product.Reference;
                    newRow["SellPrice"] = product.SellPrice;
                }

                EngineerVisit.PartsAndProductsUsed.Table.Rows.Add(newRow);
            }
        }

        private DataView _PhotoDataview;

        public DataView PhotoDataview
        {
            get
            {
                return _PhotoDataview;
            }

            set
            {
                _PhotoDataview = value;
                _PhotoDataview.AllowNew = false;
                _PhotoDataview.AllowEdit = false;
                _PhotoDataview.AllowDelete = false;
                LoadPhotoControls();
            }
        }

        private void tpPhotos_Enter(object sender, EventArgs e)
        {
            if (EngineerVisit.Photos.Count < 1)
            {
                EngineerVisit.Photos = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisit.EngineerVisitID);
                PhotoDataview = EngineerVisit.Photos;
            }
        }

        private void LoadPhotoControls()
        {
            flPhotos.SuspendLayout();
            flPhotos.Controls.Clear();
            foreach (DataRow photoRow in PhotoDataview.Table.Rows)
            {
                var ucPhotoControl = new ucEngineerVisitPhoto();
                ucPhotoControl.Photo = Image.FromStream(new System.IO.MemoryStream((byte[])photoRow["Photo"]));
                ucPhotoControl.Caption = Convert.ToString(photoRow["Caption"]);
                ucPhotoControl.EngineerVisitPhotoID = (int)photoRow["EngineerVisitPhotoID"];
                ucPhotoControl.PhotoDeleteClicked += PhotoDeleteClicked;
                ucPhotoControl.PhotoCaptionChanged += PhotoCaptionChanged;
                flPhotos.Controls.Add(ucPhotoControl);
            }

            flPhotos.ResumeLayout();
        }

        private void PhotoCaptionChanged(int EngineerVisitPhotoID, string Caption)
        {
            var evPhoto = new Entity.EngineerVisitPhotos.EngineerVisitPhoto();
            evPhoto = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_Get(EngineerVisitPhotoID);
            evPhoto.SetCaption = Caption;
            App.DB.EngineerVisitPhotos.Update(evPhoto);
        }

        private void PhotoDeleteClicked(int EngineerVisitPhotoID)
        {
            if (MessageBox.Show("Are you sure you want to delete this photo?", "Delete Photo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                App.DB.EngineerVisitPhotos.Delete(EngineerVisitPhotoID);
            }

            EngineerVisit.Photos = App.DB.EngineerVisitPhotos.EngineerVisitPhoto_GetForVisit(EngineerVisit.EngineerVisitID);
            PhotoDataview = EngineerVisit.Photos;
        }

        private void btnChangeOutcome_Click(object sender, EventArgs e)
        {
            if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Supervisor))
            {
                cboOutcome.Enabled = true;
            }
        }

        private void cboOutcome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Combo.get_GetSelectedItemValue(cboOutcome)) == (int)Enums.EngineerVisitOutcomes.Complete)
            {
                chkGasServiceCompleted.Enabled = true;
                if (Job.JobTypeID == (int)Enums.JobTypes.ServiceCertificate | Job.JobTypeID == (int)Enums.JobTypes.Service)
                {
                    chkGasServiceCompleted.Checked = true;
                }
                else
                {
                    chkGasServiceCompleted.Checked = false;
                }
            }
            else
            {
                chkGasServiceCompleted.Enabled = false;
                chkGasServiceCompleted.Checked = false;
            }
        }

        private void btnShowVisits_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMSiteVisitManager), true, new object[] { Job.PropertyID });
        }

        private void radioButtonCostsTo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb is null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            // Ensure that the RadioButton.Checked property is true.
            if (rb.Checked)
            {
                if (!((rb.Text ?? "") == (EngineerVisit.CostsTo ?? "")))
                {
                    // Keep track of the selected RadioButton by saving a reference to it' value.
                    EngineerVisit.SetCostsTo = rb.Text;
                }
            }
        }

        private void PopulateCostsTo()
        {
            var switchExpr = EngineerVisit.CostsTo;
            switch (switchExpr)
            {
                case "Contract":
                    {
                        CostsToOption1.Checked = true;
                        break;
                    }

                case "Chargeable":
                    {
                        CostsToOption2.Checked = true;
                        break;
                    }

                case "Warranty":
                    {
                        CostsToOption3.Checked = true;
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private void cboRecharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Helper.MakeDoubleValid(Combo.get_GetSelectedItemValue(cboRecharge)) > 0)
            {
                lblRechargeTicked.Visible = true;
            }
            else
            {
                lblRechargeTicked.Visible = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            App.ShowForm(typeof(FRMCustomer), true, new object[] { App.CurrentCustomerID });
        }

        private void btnEditInvoiceNotes_Click(object sender, EventArgs e)
        {
            if (App.loggedInUser.HasAccessToModule(Enums.SecuritySystemModules.Invoicing))
            {
                txtNotesFromEngineer.ReadOnly = false;
                btnSave.Enabled = true;
            }
        }

        private void cboVATRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPriceIncVAT();
            SaveInvoiceToBeRaisedDetails();
        }

        private void cboInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Helper.MakeDoubleValid(Combo.get_GetSelectedItemValue(cboInvType)) == 69491)
            {
                lblPaidBy.Visible = true;
                cboPaidBy.Visible = true;
            }
            else
            {
                lblPaidBy.Visible = false;
                cboPaidBy.Visible = false;
            }

            SaveInvoiceToBeRaisedDetails();
        }

        private void cboPaidBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveInvoiceToBeRaisedDetails();
        }

        private void btnCreateServ_Click(object sender, EventArgs e)
        {
            var f = new FRMCreateServices();
            f.SiteID = theSite.SiteID;
            f.ShowDialog();
        }

        private void chkSORDesc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSORDesc.Checked)
            {
                txtNotesFromEngineer.Enabled = false;
            }
            else
            {
                txtNotesFromEngineer.Enabled = true;
            }
        }

        private void svrmenu_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                var oPrint = new Printing(details, "Site Visit Report ", Enums.SystemDocumentType.SVR);
            }
        }

        private void JobSheetMenu_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                var oPrint = new Printing(details, "JobSheet Report ", Enums.SystemDocumentType.JobSheet);
            }
        }

        private void DomesticGSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(theSite.CustomerID);
                var oPrint = new Printing(details, "Domestic GSR", Enums.SystemDocumentType.DomGSR);
                DocumentsControl.Populate();
            }
        }

        private void WarningNoticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(VisitDefectDataview);
                var oPrint = new Printing(details, "Warning Notice", Enums.SystemDocumentType.Warn);
            }
        }

        private void CommercialGSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(theSite.CustomerID);
                var oPrint = new Printing(details, "Commercial GSR", Enums.SystemDocumentType.ComGSR);
                DocumentsControl.Populate();
            }
        }

        private void QCResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dt = App.DB.ExecuteWithReturn("Select TestType From tblEngineerVisitAdditionalChecks Where EngineerVisitID = " + EngineerVisit.EngineerVisitID);
            foreach (DataRow dr in dt.Rows)
            {
                var switchExpr = Helper.MakeIntegerValid(dr["TestType"]);
                switch (switchExpr)
                {
                    case (int)Enums.AdditionalChecksTypes.WorkInProgressAuditDomGASWork:
                    case (int)Enums.AdditionalChecksTypes.PostCompleteAuditDomWork:
                    case (int)Enums.AdditionalChecksTypes.WorkInProgressAuditDomesticOilWork:
                    case (int)Enums.AdditionalChecksTypes.WorkInProgressAuditCommercialGASWork:
                    case (int)Enums.AdditionalChecksTypes.ElectricalAudit:
                        {
                            var details = new ArrayList();
                            details.Add(EngineerVisit.EngineerVisitID);
                            details.Add(dr["TestType"]);
                            var oPrint = new Printing(details, "QC Results", Enums.SystemDocumentType.QCPrint);
                            break;
                        }
                }
            }
        }

        private void ElectricalMinorWorksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                var oPrint = new Printing(details, "Electrical Minor Works", Enums.SystemDocumentType.ElecMinor);
            }
        }

        private void AllGasPaperworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(theSite.CustomerID);
                details.Add(VisitDefectDataview);
                var oPrint = new Printing(details, "Gas Safety Record ", Enums.SystemDocumentType.GSR);
                DocumentsControl.Populate();
            }
        }

        private void CommercialCateringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(theSite.CustomerID);
                var oPrint = new Printing(details, "Commercial Catering", Enums.SystemDocumentType.ComCat);
                DocumentsControl.Populate();
            }
        }

        private void SaffronUnventedWorkshhetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(theSite.CustomerID);
                var oPrint = new Printing(details, "Saffron Unvented Worksheet", Enums.SystemDocumentType.SaffUnv);
                DocumentsControl.Populate();
            }
        }

        private void PropertyMaintenanceWorksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(theSite.CustomerID);
                var oPrint = new Printing(details, "Property Maintenance Worksheer", Enums.SystemDocumentType.PropMaint);
                DocumentsControl.Populate();
            }
        }

        private void CommissioningChecklistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                var oPrint = new Printing(details, "Commissioning Checklist", Enums.SystemDocumentType.CommissioningChecklist);
            }
        }

        private void HotWorksPermitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                var oPrint = new Printing(details, "Hot Works Permit", Enums.SystemDocumentType.HotWorksPermit);
            }
        }

        private void ASHPWorksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                var details = new ArrayList();
                details.Add(EngineerVisit);
                details.Add(theSite.CustomerID);
                var oPrint = new Printing(details, "ASHP Worksheet", Enums.SystemDocumentType.ASHP);
                DocumentsControl.Populate();
            }
        }

        private void rbSite_CheckedChanged(object sender, EventArgs e)
        {
            PopulateCharges();
        }

        private void chkShowJobCharges_CheckedChanged(object sender, EventArgs e)
        {
            if (EngineerVisit is object)
            {
                PopulateCharges();
            }
        }

        private void lblcredit_Click(object sender, EventArgs e)
        {
        }

        private void dgPartsProductsAllocated_Click(object sender, EventArgs e)
        {
            lblAllocatedQuantity.Visible = true;
            nudPartAllocatedQty.Visible = true;
            lblQuantityWarning.Visible = false;
            if (SelectedPartProductAllocatedDataRow is null)
            {
                return;
            }

            bool selected = !Convert.ToBoolean(dgPartsProductsAllocated[dgPartsProductsAllocated.CurrentRowIndex, 1]);
            dgPartsProductsAllocated[dgPartsProductsAllocated.CurrentRowIndex, 1] = selected;
            int selectedCount = 0;
            foreach (DataRow dr in PartsAndProductsAllocated.Table.Rows)
            {
                if (Convert.ToBoolean(dr["Tick"]))
                {
                    selectedCount += 1;
                    if (selectedCount > 1)
                    {
                        lblAllocatedQuantity.Visible = false;
                        nudPartAllocatedQty.Visible = false;
                        lblQuantityWarning.Visible = true;
                    }
                }
            }
        }

        private void btnRevertUsed_Click(object sender, EventArgs e)
        {
            if (App.ShowMessage("You are about to revert the parts and products used! Do you wish to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EngineerVisit.PartsAndProductsAllocated = App.DB.EngineerVisitPartProductAllocated.EngineerVisitPartAndProductsAllocated_GetAll_For_Engineer_Visit(EngineerVisit.EngineerVisitID);
                PartsAndProductsAllocated = EngineerVisit.PartsAndProductsAllocated;
                EngineerVisit.PartsAndProductsUsed = App.DB.EngineerVisitsPartsAndProducts.EngineerVisitPartsAndProductsUsed_Get_For_EngineerVisitID(EngineerVisit.EngineerVisitID);
                dgPartsAndProductsUsed.DataSource = EngineerVisit.PartsAndProductsUsed;
            }
        }

        private void chkQCDocumentsRecieved_CheckedChanged(object sender, EventArgs e)
        {
            dtpQCDocumentsRecieved.Visible = chkQCDocumentsRecieved.Checked;
        }

        private void btnUnselectAllPPA_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in PartsAndProductsAllocated.Table.Rows)
            {
                dr["Tick"] = false;
                lblAllocatedQuantity.Visible = true;
                nudPartAllocatedQty.Visible = true;
                lblQuantityWarning.Visible = false;
            }
        }

        private void btnSelectAllPPA_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in PartsAndProductsAllocated.Table.Rows)
            {
                dr["Tick"] = true;
                lblAllocatedQuantity.Visible = false;
                nudPartAllocatedQty.Visible = false;
                lblQuantityWarning.Visible = true;
            }
        }

        public void SetupSiteFuelsDatagrid()
        {
            Helper.SetUpDataGrid(dgSiteFuel);
            var tStyle = dgSiteFuel.TableStyles[0];
            tStyle.GridColumnStyles.Clear();
            tStyle.ReadOnly = false;
            tStyle.AllowSorting = false;
            dgSiteFuel.ReadOnly = false;
            dgSiteFuel.AllowSorting = false;
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
            Name.Width = 110;
            Name.NullText = "";
            tStyle.GridColumnStyles.Add(Name);
            var serviceDue = new DataGridSiteFuelColumn();
            serviceDue.Format = "dd/MM/yyyy";
            serviceDue.FormatInfo = null;
            serviceDue.HeaderText = "Service Due";
            serviceDue.MappingName = "ServiceDue";
            serviceDue.ReadOnly = true;
            serviceDue.Width = 105;
            serviceDue.NullText = "";
            tStyle.GridColumnStyles.Add(serviceDue);
            var lastServiceDate = new DataGridSiteFuelColumn();
            lastServiceDate.Format = "dd/MM/yyyy";
            lastServiceDate.FormatInfo = null;
            lastServiceDate.HeaderText = "Service Date";
            lastServiceDate.MappingName = "ActualServiceDate";
            lastServiceDate.ReadOnly = true;
            lastServiceDate.Width = 105;
            lastServiceDate.NullText = "";
            tStyle.GridColumnStyles.Add(lastServiceDate);
            tStyle.MappingName = Enums.TableNames.tblSiteFuel.ToString();
            dgSiteFuel.TableStyles.Add(tStyle);
        }

        private DataView _dvSiteFuels = null;

        public DataView SiteFuelsDataView
        {
            get
            {
                return _dvSiteFuels;
            }

            set
            {
                _dvSiteFuels = value;
                _dvSiteFuels.AllowNew = false;
                _dvSiteFuels.AllowEdit = false;
                _dvSiteFuels.AllowDelete = false;
                _dvSiteFuels.Table.TableName = Enums.TableNames.tblSiteFuel.ToString();
                dgSiteFuel.DataSource = SiteFuelsDataView;
            }
        }

        private DataRow SelectedSiteFuelDataRow
        {
            get
            {
                if (!(dgSiteFuel.CurrentRowIndex == -1))
                {
                    return SiteFuelsDataView[dgSiteFuel.CurrentRowIndex].Row;
                }
                else
                {
                    return null;
                }
            }
        }

        private void PopulateSiteFuelDataGrid()
        {
            try
            {
                SiteFuelsDataView = App.DB.Sites.SiteFuel_Get_ForEngineerVisit(EngineerVisit.EngineerVisitID);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Form cannot setup : " + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgSiteFuel_Click(object sender, EventArgs e)
        {
            if (SelectedSiteFuelDataRow is null)
            {
                return;
            }

            foreach (DataRow dr in SiteFuelsDataView.Table.Rows)
                dr["tick"] = 0;
            bool selected = !Convert.ToBoolean(dgSiteFuel[dgSiteFuel.CurrentRowIndex, 0]);
            dgSiteFuel[dgSiteFuel.CurrentRowIndex, 0] = selected;
        }

        private void chkTimesheetSelectAll_Click(object sender, EventArgs e)
        {
            chkTimesheetSelectAll.Checked = !chkTimesheetSelectAll.Checked;
            try
            {
                if (chkTimesheetSelectAll.Checked)
                {
                    foreach (DataRow dr in TimeSheetCharges.Table.Rows)
                        App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update((int)dr["EngineerVisitTimesheetChargeID"], 1);
                }
                else
                {
                    foreach (DataRow dr in TimeSheetCharges.Table.Rows)
                        App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update((int)dr["EngineerVisitTimesheetChargeID"], 0);
                }

                PopulateTimeSheetCharges(false, true);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPartsSelectAll_Click(object sender, EventArgs e)
        {
            chkPartsSelectAll.Checked = !chkPartsSelectAll.Checked;
            try
            {
                if (chkPartsSelectAll.Checked)
                {
                    foreach (DataRow dr in PartProductsCharges.Table.Rows)
                    {
                        if ((string)dr["Type"] == "Part")
                        {
                            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete((int)dr["ChargeID"]);
                            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, (int)dr["UniqueID"], Helper.MakeDoubleValid(dr["Price"]), 1, Helper.MakeDoubleValid(dr["Cost"]), (int)dr["PartUsedID"]);
                        }
                        else
                        {
                            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete((int)dr["ChargeID"]);
                            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, (int)dr["UniqueID"], Helper.MakeDoubleValid(dr["Price"]), 1, Helper.MakeDoubleValid(dr["Cost"]));
                        }

                        dr["tick"] = true;
                    }
                }
                else
                {
                    foreach (DataRow dr in PartProductsCharges.Table.Rows)
                    {
                        if ((string)dr["Type"] == "Part")
                        {
                            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete((int)dr["ChargeID"]);
                            App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, (int)dr["UniqueID"], Helper.MakeDoubleValid(dr["Price"]), 0, Helper.MakeDoubleValid(dr["Cost"]), (int)dr["PartUsedID"]);
                        }
                        else
                        {
                            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete((int)dr["ChargeID"]);
                            App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, (int)dr["UniqueID"], Helper.MakeDoubleValid(dr["Price"]), 0, Helper.MakeDoubleValid(dr["Cost"]));
                        }

                        dr["tick"] = false;
                    }
                }

                PopulatePartsProductsCharges(false, true);
            }
            catch (Exception ex)
            {
                App.ShowMessage("Cannot change tick state : " + Environment.NewLine + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLabourMarkUp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow dr in TimeSheetCharges.Table.Rows)
                    App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update((int)dr["EngineerVisitTimesheetChargeID"], 1);
            }
            catch (Exception ex)
            {
            }
        }

        private void txtPartsMarkUp_Leave(object sender, EventArgs e)
        {
            try
            {
                App.DB.EngineerVisitCharge.EngineerVisitPartsCharge_Update_Price(EngineerVisit.EngineerVisitID, Helper.MakeIntegerValid(txtPartsMarkUp.Text));
                PopulatePartsProductsCharges();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtPartsProductTotal_Leave(object sender, EventArgs e)
        {
            CalculateJobValue();
        }

        private void txtTimesheetTotal_Leave(object sender, EventArgs e)
        {
            CalculateJobValue();
        }

        private void UnCheckAllCharges()
        {
            try
            {
                foreach (DataRow dr in PartProductsCharges.Table.Rows)
                {
                    if ((string)dr["Type"] == "Part")
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Delete((int)dr["ChargeID"]);
                        App.DB.EngineerVisitCharge.EngineerVisitPartCharge_Insert(EngineerVisit.EngineerVisitID, (int)dr["UniqueID"], Helper.MakeDoubleValid(dr["Price"]), 0, Helper.MakeDoubleValid(dr["Cost"]), (int)dr["PartUsedID"]);
                    }
                    else
                    {
                        App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Delete((int)dr["ChargeID"]);
                        App.DB.EngineerVisitCharge.EngineerVisitProductCharge_Insert(EngineerVisit.EngineerVisitID, (int)dr["UniqueID"], Helper.MakeDoubleValid(dr["Price"]), 0, Helper.MakeDoubleValid(dr["Cost"]));
                    }

                    dr["tick"] = false;
                }

                foreach (DataRow dr in TimeSheetCharges.Table.Rows)
                    App.DB.EngineerVisitCharge.EngineerVisitTimeSheetCharges_Update((int)dr["EngineerVisitTimesheetChargeID"], 0);
            }
            catch (Exception ex)
            {
            }
        }
    }
}